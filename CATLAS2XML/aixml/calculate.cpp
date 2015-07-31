/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

#include "calculate.h"
#include "conditional.h"
#include "exception.h"
#include "aixml.h"

// Xercesc XML Parser
#include <xercesc/parsers/XercesDOMParser.hpp>
#include <xercesc/dom/dom.hpp>

#if ( _DEBUG ) && ( WIN32 )
	#define WINVER 0x0600
	#include <afx.h>
	#define new DEBUG_NEW
	#undef THIS_FILE
	static char BASED_CODE THIS_FILE[ ] = __FILE__;
#endif

using namespace XERCES_CPP_NAMESPACE;


AtlasCalculate& AtlasCalculate::operator = ( const AtlasStatement& other )
{
	if ( this != &other )
	{
		AtlasStatement::operator = ( other );

		GarbageCollect( );

		const AtlasCalculate* pother = dynamic_cast< const AtlasCalculate* >( &other );

		if ( 0 != pother )
		{
		}
	}

	return *this;
}

void AtlasCalculate::Init( void )
{ 
	m_pExpression = 0;
	m_pVariable = 0;
	m_uiNestId = 0;
}

void AtlasCalculate::GarbageCollect( void )
{ 
	if ( 0 != m_pExpression )
	{
		delete m_pExpression;
		m_pExpression = 0;
	}

	if ( 0 != m_pVariable )
	{
		delete m_pVariable;
		m_pVariable = 0;
	}
}

void AtlasCalculate::InitFromXML( const StatementMetadata* pData, vector< AtlasStatement* >& vectNestedCalculates )
{
	if ( 0 != pData )
	{
		if ( 0 != pData->m_pStatement )
		{
			string strAIXMLtagName;

			SetSourceStatementInfo( pData->m_pStatement, pData->m_eSourceType, pData->m_strFilename, pData->m_strParentProcedureName, pData->m_uiParentProcedureId );
	
			m_uiConditionalStatementsId = pData->m_uiParentConditionalStatementsId;

			const xercesc::DOMElement* pAssignment = pData->m_pStatement->getFirstElementChild( );
			unsigned int uiCalculate = 0;

			while ( 0 != pAssignment )
			{
				++uiCalculate;

				AIXMLHelper::GetXercesString( pAssignment->getTagName( ), strAIXMLtagName );
		
				if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eAssignmentElement ] )
				{
					if ( 1 == uiCalculate )
					{
						ProcessAssignment( pAssignment );
					}
					else
					{
						AtlasCalculate* pCalculate = 0;
							
						try
						{
							pCalculate = new AtlasCalculate;
						}
						catch ( ... )
						{
							throw Exception( Exception::eFailedToAllocateMemoryForAtlasCalculateObject, __FILE__, __FUNCTION__, __LINE__ );
						}

						vectNestedCalculates.push_back( pCalculate );

						pCalculate->InitSourceInfo( this );

						if ( pCalculate->m_vectAtlasSourceStatement.size( ) > 0 )
						{
							const DOMAttr* pAttr = pAssignment->getAttributeNode( AIXMLHelper::GetWString( AIXML::m_arrayXMLKeyWords[ AIXML::eLineAttribute ] ).c_str( ) );
							if ( 0 != pAttr )
							{
								string strLineNum;
					
								AIXMLHelper::GetXercesString( pAttr->getValue( ), strLineNum );
					
								pCalculate->m_vectAtlasSourceStatement.back( ).SetLineNumber( AIXMLHelper::StringToNumber< unsigned int >( strLineNum ) );
							}
						}

						pCalculate->ProcessAssignment( pAssignment );
					}
				}

				pAssignment = pAssignment->getNextElementSibling( );
			}
		}
	}
}

void AtlasCalculate::Process( const Lookup* pLookup )
{
	if ( 0 != m_pVariable )
	{
		ProcessVariableSymbols( m_pVariable );
	}

	if ( 0 != m_pExpression )
	{
		ProcessVariableSymbols( m_pExpression->Get( ) );
	}
}

void AtlasCalculate::ProcessAssignment( const xercesc::DOMElement* pAssignment )
{
	#if ( _DEBUG ) && ( WIN32 )
	{
		const DOMAttr* pAttr = pAssignment->getAttributeNode( AIXMLHelper::GetWString( AIXML::m_arrayXMLKeyWords[ AIXML::eOperatorAttribute ] ).c_str( ) );
		if ( 0 != pAttr )
		{
			string strOperator;

			AIXMLHelper::GetXercesString( pAttr->getValue( ), strOperator );

			if ( strOperator != "=" )
			{
				DebugBreak( );
			}
		}
	}
	#endif

	const xercesc::DOMElement* pVariable = pAssignment->getFirstElementChild( );
	string strAIXMLtagName;

	if ( 0 != pVariable )
	{
		AIXMLHelper::GetXercesString( pVariable->getTagName( ), strAIXMLtagName );

		if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eVariableElement ] )
		{
			m_pVariable = AtlasCondition::GetVariable( pVariable, 0, false );
		}
		else if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eVariableWSElement ] ) // [W]ith [S]ubscript
		{
			m_pVariable = AtlasCondition::GetVariable( pVariable, 0, true );
		}
		#if ( _DEBUG ) && ( WIN32 )
		else
		{
			DebugBreak( );
		}
		#endif
	}
	#if ( _DEBUG ) && ( WIN32 )
	else
	{
		DebugBreak( );
	}
	#endif

	const xercesc::DOMElement* pExpression = pVariable->getNextElementSibling( );

	if ( 0 != pExpression )
	{
		try
		{
			m_pExpression = new AtlasCondition::Expression;
		}
		catch ( ... )
		{
			throw Exception( Exception::eFailedToCreateArithmeticExpressionObject, __FILE__, __FUNCTION__, __LINE__ );
		}

		AtlasCondition::ProcessExpression( pExpression, m_pExpression );

		#if ( _DEBUG ) && ( WIN32 )
		{
			const xercesc::DOMElement* pNext = pExpression->getNextElementSibling( );

			if ( 0 != pNext )
			{
				DebugBreak( );
			}
		}
		#endif
	}
	#if ( _DEBUG ) && ( WIN32 )
	else
	{
		DebugBreak( );
	}
	#endif
}

void AtlasCalculate::VerifyIfBitwiseExpression( void )
{ 
	AtlasCondition::VerifyIfBitwiseExpression( m_pExpression );
}

void AtlasCalculate::ToXML( string& strXML ) const
{
	if ( ( 0 != m_pVariable ) && ( 0 != m_pExpression ) )
	{
		const string strId( XML::MakeXmlAttributeNameValue( XML::anId, ( 0 == m_uiNestId ? m_uiId : m_uiNestId ) ) );
	
		strXML += XML::MakeOpenXmlElementWithChildren( XML::enCalculate, strId, GetStatementCommentRefId_XML( ) );
	
		unsigned int uiSize = m_vectAtlasSourceStatement.size( );
		if ( uiSize > 0 )
		{
			unsigned int uiFields = Atlas::AtlasSourceStatement::eXmlFilename;
	
			uiFields |= Atlas::AtlasSourceStatement::eXmlStatementNumber;
			uiFields |= Atlas::AtlasSourceStatement::eXmlLineNumber;
			uiFields |= Atlas::AtlasSourceStatement::eXmlSourceType;
			uiFields |= Atlas::AtlasSourceStatement::eXmlProcname;
	
			strXML += m_vectAtlasSourceStatement[ 0 ].ToXML( uiFields );
		}
	
		if ( Atlas::AtlasTerm::GetRawClassName( ) == typeid( *m_pVariable ).raw_name( ) )
		{
			m_pVariable->ToXML( strXML, XML::enVariable );
		}
		#if ( _DEBUG ) && ( WIN32 )
		else
		{
			DebugBreak( );
		}
		#endif
	
		m_pExpression->ToXML( strXML, XML::enAssignment, XML::enAssign, XML::avAssign );

		strXML += XML::MakeCloseXmlElementWithChildren( XML::enCalculate );
	}
}

void AtlasCalculate::GetAssignValue_XML( const XML::ElementName eName, set < string >& setAssignedByValue ) const
{
	if ( 0 != m_pExpression )
	{
		if ( XML::avAssign == GetAssignmentType( ) )
		{
			const string strXML( m_pExpression->GetAssignValue_XML( eName ) );

			if ( !strXML.empty( ) )
			{
				setAssignedByValue.insert( strXML );
			}
		}
	}
}

unsigned int AtlasCalculate::GetStatementId( void ) const
{ 
	unsigned int uiRet = m_uiId;

	if ( 0 != m_uiNestId )
	{
		uiRet = m_uiNestId;
	}

	#if ( _DEBUG ) && ( WIN32 )
	if ( 0 == uiRet )
	{
		DebugBreak( );
	}
	#endif

	return uiRet;
}

XML::AttributeValue AtlasCalculate::GetAssignmentType( void ) const
{
	XML::AttributeValue avType = XML::avUnknown;

	if ( 0 != m_pExpression )
	{
		avType = m_pExpression->GetAssignmentType( );
	}

	return avType;
}

bool AtlasCalculate::IsListVariable( void ) const
{
	bool bIsListVariable = false;

	if ( 0 != m_pVariable )
	{
		if ( 0 != dynamic_cast< Atlas::AtlasTerm* >( m_pVariable ) )
		{
			if ( 0 != ( ( Atlas::AtlasTerm* ) m_pVariable )->GetSubscriptTerm( false ) )
			{
				bIsListVariable = true;
			}
		}
	}

	return bIsListVariable;
}

const Atlas::AtlasData* AtlasCalculate::GetListVariableSubscript( void ) const
{
	const Atlas::AtlasData* pData = 0;

	if ( 0 != m_pVariable )
	{
		if ( 0 != dynamic_cast< Atlas::AtlasTerm* >( m_pVariable ) )
		{
			pData = ( ( Atlas::AtlasTerm* ) m_pVariable )->GetSubscriptTerm( false );
		}
	}

	return pData;
}
