/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

#pragma once

#define XERCES_STATIC_LIBRARY

#include <string>
#include <vector>
#include <map>
#include <set>

#include <xercesc/util/XercesDefs.hpp>
#include <xercesc/util/Xerces_autoconf_config.hpp>
XERCES_CPP_NAMESPACE_BEGIN
	class DOMDocument;	
	class DOMElement;	
	class XercesDOMParser;
XERCES_CPP_NAMESPACE_END

#include "atlas.h"
#include "helper.h"
#include "exception.h"
#include "statements.h"
#include "xml.h"

class StatementMetadata;

using namespace std;

class AtlasCondition : public AtlasStatementContainer
{
public:

	class ExpressionBase
	{
	public:

		ExpressionBase( ) { }
		virtual ~ExpressionBase( ) { }

		virtual void ToXML( string& strXML, const XML::ElementName eParentElementName, const XML::ElementName eSingalTermElementName, const XML::AttributeValue eSingalTermAttributeValue ) const = 0;

	protected:

		static void ChangeBooleanExpToBitwiseExp( Atlas::AtlasTermBase** ppExpression );

	};  // class ExpressionBase

	class Expression : public ExpressionBase
	{
	public:

		Expression( ) : m_pExpression( 0 ) { }
		virtual ~Expression( ) { GarbageCollect( ); }

		void Set( Atlas::AtlasTermBase* pTermBase );
		Atlas::AtlasTermBase* Get( void ) const { return m_pExpression; }

		void ToXML( string& strXML, const XML::ElementName eParentElementName, const XML::ElementName eSingalTermElementName, const XML::AttributeValue eSingalTermAttributeValue ) const;

		void ChangeBooleanExpToBitwiseExp( void ) { ExpressionBase::ChangeBooleanExpToBitwiseExp( &m_pExpression ); }
		XML::AttributeValue GetAssignmentType( void ) const;
		string GetAssignValue_XML( const XML::ElementName eName ) const;

	protected:

		Atlas::AtlasTermBase* m_pExpression;

		void GarbageCollect( void );

	};  // class Expression

	class IfExpression : public Expression
	{
	public:

		IfExpression( ) : Expression( ), m_pElse( 0 ) { }
		~IfExpression( ) { }

		void SetELSE( const AtlasCondition* pElse ) 
		{
			m_pElse = pElse;

			if ( 0 != m_pElse )
			{
				if ( Atlas::eELSE != m_pElse->m_eAtlasStatement )
				{
					m_pElse = 0;
				}
			}
		}

		const AtlasCondition* GetELSE( void ) const { return m_pElse; }

	protected:

		const AtlasCondition* m_pElse;	// Used only with IF statements that contain an ELSE part.

	};  // class IfExpression

	class WhileExpression : public Expression
	{
	public:

		WhileExpression( ) : Expression( ) { }
		~WhileExpression( ) { }

	protected:
	};  // class IfExpression

	class ForExpression : public ExpressionBase
	{
	public:

		ForExpression( ) : ExpressionBase( ), m_pVariable( 0 ) { }
		~ForExpression( ) { GarbageCollect( ); }

		void SetVariable( Atlas::AtlasTermBase* pVariable ) { SetValue( pVariable, &m_pVariable) ; }
		Atlas::AtlasTermBase* GetVariable( void ) const { return m_pVariable; }

		virtual void ToXML( string& strXML, const XML::ElementName eParentElementName, const XML::ElementName eSingalTermElementName, const XML::AttributeValue eSingalTermAttributeValue ) const = 0;

	protected:

		Atlas::AtlasTermBase* m_pVariable;

		void SetValue( Atlas::AtlasTermBase* pValue, Atlas::AtlasTermBase** pp );
		void GarbageCollect( void );
		void GarbageCollect( Atlas::AtlasTermBase** pp );
	};

	class ForSequenceExpression : public ForExpression
	{
	public:

		ForSequenceExpression( ) : ForExpression( ), m_pStartValue( 0 ), m_pEndValue( 0 ), m_pByValue( 0 ) { }
		~ForSequenceExpression( ) { GarbageCollect( ); }

		void SetStartValue( Atlas::AtlasTermBase* pValue ) { SetValue( pValue, &m_pStartValue ); }
		Atlas::AtlasTermBase* GetStartValue( void ) const { return m_pStartValue; }

		void SetEndValue( Atlas::AtlasTermBase* pValue ) { SetValue( pValue, &m_pEndValue ); }
		Atlas::AtlasTermBase* GetEndValue( void ) const { return m_pEndValue; }

		void SetByValue( Atlas::AtlasTermBase* pValue ) { SetValue( pValue, &m_pByValue ); }
		Atlas::AtlasTermBase* GetByValue( void ) const { return m_pByValue; }

		void ToXML( string& strXML, const XML::ElementName eParentElementName, const XML::ElementName eSingalTermElementName, const XML::AttributeValue eSingalTermAttributeValue ) const;

	protected:

		void ToXML( string& strXML, const XML::ElementName eName, Atlas::AtlasTermBase* pValue ) const;

		Atlas::AtlasTermBase* m_pStartValue;
		Atlas::AtlasTermBase* m_pEndValue;
		Atlas::AtlasTermBase* m_pByValue;

		void GarbageCollect( void );

	};  // class ForSequenceExpression

	class ForListExpression : public ForExpression
	{
	public:

		ForListExpression( ) : ForExpression( ) { }
		~ForListExpression( ) { GarbageCollect( ); }

		void SetListItem( Atlas::AtlasTermBase* pItem ) { m_vectExpression.push_back( pItem ); }
		unsigned int GetListItemCount( void ) const { return m_vectExpression.size( ); }
		Atlas::AtlasTermBase* GetListItem( const unsigned int uiPos ) const;

		void ToXML( string& strXML, const XML::ElementName eParentElementName, const XML::ElementName eSingalTermElementName, const XML::AttributeValue eSingalTermAttributeValue ) const;

	protected:

		vector< Atlas::AtlasTermBase* > m_vectExpression;

		void GarbageCollect( void );

	};  // class ForListExpression

	AtlasCondition( const Atlas::eAtlasStatement eStatement, const unsigned int uiNestLevel ) : AtlasStatementContainer( eStatement ), m_uiNestLevel( uiNestLevel ) { Init( ); }
	AtlasCondition( const AtlasCondition& other ) { Init( ); operator = ( other ); }
	~AtlasCondition( ) { GarbageCollect( ); }
	AtlasCondition& operator = ( const AtlasStatement& other );

	void InitFromXML( const StatementMetadata* pData );

	void Process( const Lookup* pLookup = 0 );
	void ToXML( string& strXML ) const { ToXML( strXML, 0 ); }
	void ToXML( string& strXML, const set< unsigned int >* psetEntryPointIds ) const;
	void VerifyIfBitwiseExpression( void );
	const string& GetEndStatementNumber( void ) const { return m_EndStatement.GetStatementNumber( ); }

	unsigned int m_uiNestLevel;
	ExpressionBase* m_pExpression;
	Atlas::AtlasSourceStatement m_EndStatement;

protected:

	AtlasCondition( ) { Init( ); }

	static void VerifyIfBitwiseExpression( ExpressionBase* pExpression );
	static bool VerifyIfBitwiseExpression( Atlas::AtlasTermBase* pTermBase );

	void InitIFFromXML( const xercesc::DOMElement* pAIXMLvalue );
	void InitELSEFromXML( const xercesc::DOMElement* pAIXMLvalue );
	void InitWHILEFromXML( const xercesc::DOMElement* pAIXMLvalue );
	void InitFORFromXML( const xercesc::DOMElement* pAIXMLvalue );
	void ProcessExpression( const xercesc::DOMElement* pAIXMLvalue, ForSequenceExpression* pForExpression );
	void ProcessExpression( const xercesc::DOMElement* pAIXMLvalue, ForListExpression* pForExpression );

	static void ProcessExpression( const xercesc::DOMElement* pAIXMLvalue, Expression* pExpression );
	static void ProcessCompareOperator( const xercesc::DOMElement* pCompareOp, Atlas::AtlasCompareExpression* pCompareExpression );
	static void ProcessBooleanOperator( const xercesc::DOMElement* pBooleanOp, Atlas::AtlasBooleanExpression* pBooleanExp );
	static void ProcessArithmeticOperator( const xercesc::DOMElement* pArithOp, Atlas::AtlasArithmeticExpression* pArithExp );
	static void ProcessBooleanOperator( const xercesc::DOMElement* pBooleanOp, Atlas::AtlasBitwiseExpression* pBitwiseExpression );

	static Atlas::AtlasTerm* GetConstant( const xercesc::DOMElement* pAIXMLvalue, Atlas::AtlasExpression* pExpression );
	static Atlas::AtlasTerm* GetString( const xercesc::DOMElement* pAIXMLvalue, Atlas::AtlasExpression* pExpression );
	static Atlas::AtlasTerm* GetVariable( const xercesc::DOMElement* pAIXMLvalue, Atlas::AtlasExpression* pExpression, const bool bSubscript );
	static Atlas::AtlasTerm* GetKeyword( const xercesc::DOMElement* pAIXMLvalue, Atlas::AtlasExpression* pExpression );
	static Atlas::AtlasTerm* GetUnaryOp( const xercesc::DOMElement* pAIXMLvalue, Atlas::AtlasExpression* pExpression );
	static Atlas::AtlasTermBase* GetFunction( const xercesc::DOMElement* pAIXMLvalue, Atlas::AtlasExpression* pExpression );
	static Atlas::AtlasTermBase* GetBoolean( const xercesc::DOMElement* pBooleanOp );
	static bool GetDimension( const xercesc::DOMElement* ppAIXMLvalue, Atlas::AtlasData* pData );

	static bool IsForSequenceExpression( const xercesc::DOMElement* pAIXMLvalue );

	static const string m_strEND;

	void Init( void )
	{ 
		m_pExpression = 0;
	}

	void GarbageCollect( void )
	{ 
		if ( 0 != m_pExpression )
		{
			delete m_pExpression;
			m_pExpression = 0;
		}
	}

	friend class AtlasCalculate;
	friend class AtlasCompare;

}; // class AtlasCondition
