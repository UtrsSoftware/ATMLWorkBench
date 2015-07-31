/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

#pragma once

#include <string>
#include <vector>
#include <map>
#include <queue>

#define XERCES_STATIC_LIBRARY

#include <xercesc/util/XercesDefs.hpp>
#include <xercesc/util/Xerces_autoconf_config.hpp>
XERCES_CPP_NAMESPACE_BEGIN
	class DOMDocument;	
	class DOMElement;	
	class XercesDOMParser;
XERCES_CPP_NAMESPACE_END

#include "atlas.h"
#include "xml.h"

#ifdef CASS
	#include "cass/specific_instruments.h"
#else
	#error Need instruments implementation (i.e. CASS)
#endif

using namespace std;

class Lookup;
class CNX;
class AtlasSignalInfo;
class AtlasDeclareData;
class AtlasProcedure;
class AtlasCondition;
class StatementMetadata;
class AtlasGoto;
class AtlasLeave;
class AtlasRequires;
class AtlasRequire;
class AtlasComplexSignal;

class AtlasAttributes
{
public:

	enum eDataType
	{
		eUnknownDataType	= 0x000,
		eVariable			= 0x001,
		eKeyword			= 0x002,
		eDimension			= 0x004,
		eConstant			= 0x008,
		eString				= 0x010,
		eCharacter			= 0x020,
		eConnector			= 0x040,
		eDouble				= 0x080,
		eInteger			= 0x100
	};

	struct AtlasAttibuteValue
	{
		AtlasAttibuteValue( ) { Init( ); }
		AtlasAttibuteValue( const string& strValue, const unsigned int uiType, const unsigned int uiId ) : m_strValue( strValue ), m_uiType( uiType ), m_uiId( uiId ) { m_uiLineNumber = 0; }
		AtlasAttibuteValue( const AtlasAttibuteValue& other ) { Init( ); operator = ( other ); }
		AtlasAttibuteValue& operator = ( const AtlasAttibuteValue& other );

		bool IsVariable( void ) const { return ( eVariable == ( m_uiType & eVariable ) ); }
		bool IsKeyword( void ) const { return ( eKeyword == ( m_uiType & eKeyword ) ); }
		bool IsDimension( void ) const { return ( eDimension == ( m_uiType & eDimension ) ); }
		bool IsConstant( void ) const { return ( eConstant == ( m_uiType & eConstant ) ); }
		bool IsString( void ) const { return ( eString == ( m_uiType & eString ) ); }
		bool IsCharacter( void ) const { return ( eCharacter == ( m_uiType & eCharacter ) ); }
		bool IsConnector( void ) const { return ( eConnector == ( m_uiType & eConnector ) ); }
		bool IsDouble( void ) const { return ( eDouble == ( m_uiType & eDouble ) ); }
		bool IsInteger( void ) const { return ( eInteger == ( m_uiType & eInteger ) ); }

		void SetConnector( const bool bConnector ) { if ( bConnector ) { m_uiType |= eConnector; } else { m_uiType &= ~eConnector; } }
		void SetDouble( const bool bDouble ) { if ( bDouble ) { m_uiType |= eDouble; } else { m_uiType &= ~eDouble; } }
		void SetInteger( const bool bInteger ) { if ( bInteger ) { m_uiType |= eInteger; } else { m_uiType &= ~eInteger; } }

		XML::AttributeValue GetDataType( void ) const;
		XML::AttributeValue GetNumericType( void ) const;
		bool IsNumericType( void ) const;

		string m_strValue;
		unsigned int m_uiType;
		unsigned int m_uiId;
		unsigned int m_uiLineNumber;
		string m_strStatementNumber;

	protected:

		void Init( void )
		{
			m_uiType = eUnknownDataType;
			m_uiId = 0;
			m_uiLineNumber = 0;
		}
	};

	AtlasAttributes( const AtlasAttributes& other ) { Init( ); operator = ( other ); }
	virtual AtlasAttributes& operator = ( const AtlasAttributes& other );

	virtual void InitFromXML( const xercesc::DOMElement* pAIXMLvalue ) { InitFromXML( pAIXMLvalue, string( ) ); }
	virtual void InitFromXML( const xercesc::DOMElement* pAIXMLvalue, const string& strStatementNumber );
	virtual void Process( const Lookup* pLookup = 0 ) = 0;
	virtual void ToXML( string& strXML ) const = 0;

	void SetId( const string& strId ) { m_strId = strId; }
	const string& GetId( void ) const { return m_strId; }

	void SetAttributes( const vector< const AtlasAttibuteValue* >& vectAttributes, const bool bTransferOwnership );

protected:

	AtlasAttributes( ) { Init( ); }
	AtlasAttributes( const xercesc::DOMElement* pAIXMLvalue ) { Init( ); InitFromXML( pAIXMLvalue ); }
	void Init( void ) { m_bProcessed = false; }
	void GarbageCollect( void );
	virtual ~AtlasAttributes( ) { GarbageCollect( ); }

	vector< const AtlasAttibuteValue* > m_vectAttributes;
	string m_strId;
	bool m_bProcessed;

};  // class AtlasAttributes

class AtlasStatement : public AtlasAttributes
{
public:

	enum eScope
	{
		eUnknownScope,
		eExternal,
		eGlobal,
		eLocal
	};

	AtlasStatement( const Atlas::eAtlasStatement eStatement ) : AtlasAttributes( ) { Init( );  m_eAtlasStatement = eStatement; }
	AtlasStatement( const AtlasStatement& other ) { Init( ); operator = ( other ); }
	virtual ~AtlasStatement( ) { GarbageCollect( ); }
	virtual AtlasStatement& operator = ( const AtlasStatement& other ) = 0;

	virtual void Process( const Lookup* pLookup ) = 0;
	virtual void ProcessVariableSymbols( const map< string, vector< AtlasDeclareData* >* >& mapDeclares, const map< Atlas::AtlasData::eBuiltInType, AtlasDeclareData* >& mapBuiltinDeclares, const AtlasProcedure* pProcedure, const vector< pair< string, Atlas::AtlasSourceStatement::eSourceType > >* pvectAtlasSourceFiles );
	unsigned int SetSourceStatementInfo( const xercesc::DOMElement* pAIXMLvalue, const Atlas::AtlasSourceStatement::eSourceType eSourcType, const string& strFilename, const string& strParentProcname, const unsigned int uiParentProcId );
	static void SetSourceStatementInfo( Atlas::AtlasSourceStatement& ss, const xercesc::DOMElement* pAIXMLvalue, const Atlas::AtlasSourceStatement::eSourceType eSourcType, const string& strFilename, const string& strParentProcname );
	void InitId( void );
	string GetStatementType( void ) const { return Atlas::GetAtlasStatement( m_eAtlasStatement ); }

	string GetParentProcedureName( const unsigned uiPos = 0 ) const;
	const Atlas::AtlasSourceStatement* GetSourceInfo( const unsigned uiPos = 0 ) const;
	unsigned int GetStatementLineNumber( const unsigned uiPos = 0 ) const;
	string GetStatementNumber( const unsigned uiPos = 0 ) const;
	string GetStatementTestNumber( const unsigned uiPos = 0 ) const;
	void SetStatementTestNumber( const string& strTestNumber, const unsigned uiPos = 0 );
	string GetStatementStepNumber( const unsigned uiPos = 0 ) const;
	bool GetStatementIsBeginTest( const unsigned uiPos = 0 ) const;
	string GetStatementFilename( const unsigned uiPos = 0 ) const;
	string GetStatementParentProcname( const unsigned uiPos = 0 ) const;
	unsigned int GetStatementCommentId( const unsigned uiPos = 0 ) const;
	string GetStatementCommentRefId_XML( void ) const;
	string GetStatementTestNumber_XML( void ) const;
	string GetStatementBeginTest_XML( void ) const;
	void InitSourceInfo( const AtlasStatement* pAtlasStatement );
	virtual unsigned int GetStatementId( void ) const { return m_uiId; }
	void GarbageCollectAtlasAttributes( void ) { AtlasAttributes::GarbageCollect( ); }
	bool IsVariable( const string& strVarName, const unsigned int uiVarId ) const;

	Atlas::eAtlasStatement m_eAtlasStatement;
	bool m_bProcessed;
	unsigned int m_uiId;
	unsigned int m_uiParentProcedureId;
	unsigned int m_uiConditionalStatementsId;
	AtlasProcedure* m_pProcedureStatement;
	AtlasCondition* m_pConditionalStatement;
	string m_strParentProcedureName;
	vector< Atlas::AtlasSourceStatement > m_vectAtlasSourceStatement;
	multimap< string, Atlas::AtlasData* > m_multimapVariables;

	static eScope GetScopeEnum( const string& strScope );
	static unsigned int GetCommentId( const xercesc::DOMElement* pAIXMLvalue );

	static const string m_strBackSlash;
	static const string m_strFrontSlash;
	static const string m_strMinus;
	static const string m_strPlus;
	static const string m_strLeftParen;
	static const string m_strRightParen;
	static const string m_strDash;
	static const string m_strUnderscore;
	static const string m_strDot;
	static const string m_strColon;
	static const string m_strAssign;

	static const string m_strMAIN_PROC_NAME;
	static const string m_strRANGE;
	static const string m_strFROM;
	static const string m_strMIN;
	static const string m_strMAX;
	static const string m_strCNX;
	static const string m_strSHORT;
	static const string m_strUSING;
	static const string m_strAS;
	static const string m_strTHRU;
	static const string m_strChannelA;
	static const string m_strChannelB;
	static const string m_strAC;
	static const string m_strDC;
	static const string m_strTO;
	static const string m_strEVENT;
	static const string m_strERRLMT;
	static const string m_strINTO;
	static const string m_strBY;
	static const string m_strCONTINUOUS;
	static const string m_strPOS;
	static const string m_strNEG;
	static const string m_strFILE;
	static const string m_strNONE;
	static const string m_strREF;
	static const string m_strFALSE;
	static const string m_strTRUE;
	static const string m_strSTORE;
	static const string m_strLIST;
	static const string m_strGLOBAL;
	static const string m_strEXTERNAL;
	static const string m_strDATE;
	static const string m_strALL;
	static const string m_strCOMPLEX;
	static const string m_strSIGNAL;
	static const string m_strFUNCTION;
	static const string m_strFORMAT;
	static const string m_strMANUAL;
	static const string m_strINTERVENTION;
	static const string m_strNEW;
	static const string m_strOLD;
	static const string m_strFILEACCESS;
	static const string m_strCONCURRENT;
	static const string m_strOPERATION;
	static const string m_strSTEP;

protected:

	AtlasStatement( ) { Init( ); }
	static void SetProcedureSymbolInfo( const AtlasDeclareData* pDeclareData, Atlas::AtlasData* pData );
	static void SetDeclareSymbolInfo( const string strFilename, const vector< AtlasDeclareData* >* pvectDeclares, Atlas::AtlasData* pData, const vector< pair< string, Atlas::AtlasSourceStatement::eSourceType > >* pvectAtlasSourceFiles );

	void ProcessVariableSymbols( const Atlas::AtlasTermBase* pTermBase );
	void GetVariables( Atlas::AtlasErrorLimit* pErrorLimit );
	static bool HasCommentText( const xercesc::DOMElement* pAIXMLvalue );

	void Init( void ) 
	{ 
		m_eAtlasStatement = Atlas::eUnknownAtlasStatement;
		m_bProcessed = false;
		m_uiId = 0;
		m_uiParentProcedureId = 0;
		m_uiConditionalStatementsId = 0;
		m_pProcedureStatement = 0;
		m_pConditionalStatement = 0;
	}

	void GarbageCollect( void ) 
	{ 
		Init( );

		m_vectAtlasSourceStatement.clear( );
	}

}; // class AtlasStatement

class AtlasStatementContainer : public AtlasStatement
{
public:

	AtlasStatementContainer( const Atlas::eAtlasStatement eStatement ) : AtlasStatement( eStatement ) { Init( ); }
	AtlasStatementContainer( const AtlasStatementContainer& other ) { Init( ); operator = ( other ); }
	virtual ~AtlasStatementContainer( ) { GarbageCollect( ); }
	virtual AtlasStatement& operator = ( const AtlasStatement& other ) = 0;

	void InsertStatement( AtlasStatement* pStatement );
	bool SetBranchDestinationRefId( AtlasStatement* pStatement, const AtlasProcedure* pProcedure ) const;
	void VerifyStatementOrder( void ) const;

	const xercesc::DOMElement* m_pStatementsElement;
	unsigned int m_uiStatementsId;

protected:

	class TestData
	{
	public:

		TestData( const string& strTestName, const bool bBeginTest, const AtlasStatement* pStatement ) : m_bBeginTest( bBeginTest ), m_strTestName( strTestName )
		{ 
			m_setTestStatements.insert( pStatement );
		}

		string m_strTestName;
		bool m_bBeginTest;
		set< const AtlasStatement* > m_setTestStatements;
	};

	multimap< unsigned int, AtlasStatement* > m_mapStatements;
	map< string, TestData* > m_mapTestNumberData;

	AtlasStatementContainer* GetStatementsChild( const unsigned int uiId );
	void Statements_ToXML( string& strXML ) const { Statements_ToXML( strXML, 0 ); }
	void Statements_ToXML( string& strXML, const set< unsigned int >* psetEntryPointIds ) const;
	bool SetBranchDestinationRefId( AtlasGoto* pGotoStatement ) const;
	void SetBranchDestinationRefId( AtlasGoto* pGotoStatement, const AtlasCondition* pConditionStatement ) const;
	bool SetBranchDestinationRefId( const AtlasLeave* pLeaveStatement, deque< pair< Atlas::eAtlasStatement, const AtlasStatement* > >& dequeConditionalIds ) const;
	void SetStatementsParent( AtlasProcedure* pProcedureStatement );
	const AtlasStatement* GetNextAtlasStatement( const AtlasStatement* pStatement ) const;
	void VerifyStatementOrder( const string& strFilename, unsigned int& uiPreviousLineNumber, const multimap< unsigned int, AtlasStatement* >* pmapStatements ) const;
	void AddTestNumber( const AtlasStatement* pStatement );
	void GetChildrenTestNumberStatements( map< string, TestData* >& mapTestNumberData ) const;
	void GetTestNumberStatementVariables( const map< string, TestData* >& mapTestNumberData, map< string, map< string, const Atlas::AtlasData* > >& mapTestVariables ) const;
	void GetTestNumberStatementSignalOrientedVerbs( const map< string, TestData* >& mapTestNumberData, map< string, map< unsigned int, const AtlasStatement* > >& mapSignalOrientedVerbs ) const;

	static void SetElseWithMatchingIfStatement( const multimap< unsigned int, AtlasStatement* >* pMultimap, multimap< unsigned int, AtlasStatement* >::iterator it );

	AtlasStatementContainer( ) { Init( ); }

	void Init( void )
	{
		m_pStatementsElement = 0;
		m_uiStatementsId = 0;
	}

	void GarbageCollect( void );

}; // class AtlasContainer


class AtlasSignalVerb : public AtlasStatement
{
public:

	AtlasSignalVerb( const Atlas::eAtlasStatement eStatement ) : AtlasStatement( eStatement ) { Init( ); }
	AtlasSignalVerb( const AtlasSignalVerb& other ) { Init( ); operator = ( other ); }
	virtual ~AtlasSignalVerb( ) { GarbageCollect( ); }
	virtual AtlasStatement& operator = ( const AtlasStatement& other ) = 0;

	virtual void InitSignalComponents( void ) = 0;
	virtual void InitSignalInfo( AtlasSignalInfo* pInformation ) { }

	string m_strVirtualLabel;
	string m_strSystemName;
	SpecificInstrument::eInstrument m_eInstrument;
	Atlas::AtlasSignalComponent m_PrimarySignalComponent;

	struct Compare
	{
		bool operator( )( const pair< Atlas::AtlasSignalComponent, Atlas::AtlasStatementCharacteristic* >& l, const pair< Atlas::AtlasSignalComponent, Atlas::AtlasStatementCharacteristic* >& r );
	};

protected:

	AtlasSignalVerb( ) { Init( ); }

	void Init( void ) 
	{ 
		m_eInstrument = SpecificInstrument::eUnknownInstrument;
	}

	void GarbageCollect( void ) 
	{ 
		Init( );

		m_strVirtualLabel.clear( );
		m_strSystemName.clear( );
	}

}; // class AtlasVerb

class AtlasActionSignalVerb : public AtlasSignalVerb
{
public:

	AtlasActionSignalVerb( const Atlas::eAtlasStatement eStatement, const XML::ElementName eVerbElementName, const bool bHasMeasureCharacteristics, const AtlasRequires* pRequireStatements ) : AtlasSignalVerb( eStatement ) { Init( ); m_eVerbElementName = eVerbElementName; m_bHasMeasureCharacteristics = bHasMeasureCharacteristics; m_pRequireStatements = pRequireStatements; }
	AtlasActionSignalVerb( const AtlasActionSignalVerb& other ) { Init( ); operator = ( other ); }
	virtual ~AtlasActionSignalVerb( ) { GarbageCollect( ); }
	AtlasStatement& operator = ( const AtlasStatement& other );

	void Process( const Lookup* pLookup = 0 );
	void ToXML( string& strXML ) const { ToXML( strXML, string( ) ); }
	void ToXML( string& strXML, const string& strAddtionalTopLevelAttributes ) const;
	void InitSignalComponents( void );
	void InitSignalInfo( AtlasSignalInfo* pInformation );
	void InitFromXML( const StatementMetadata* pData );

	vector< pair< Atlas::AtlasSignalComponent, Atlas::AtlasStatementCharacteristic* > > m_vectAtlasNounMod;
	vector< pair< Atlas::AtlasSignalComponent, Atlas::AtlasNumber* > > m_vectMeasuredCharacteristic;	// N/A for APPLY
	map< unsigned int, Atlas::AtlasErrorLimit > m_mapErrorLimits;	// N/A for APPLY
	Atlas::AtlasStatementCharacteristic* m_pFromToEvent;
	Atlas::AtlasStatementCharacteristic* m_pGatedEvent;
	Atlas::AtlasStatementCharacteristic* m_pSyncEvent;
	Atlas::AtlasEvaluationStatement* m_pEvaluationStatement;	// VERIFY statement only
	CNX* m_pCNX;
	XML::ElementName m_eVerbElementName;
	bool m_bHasMeasureCharacteristics;
	bool m_bRemoveAll;
	bool m_bComplexSignal;
	string m_strComplexSignalName;
	unsigned int m_uiComplexSignalRefId;
	const AtlasRequires* m_pRequireStatements;
	const map< string, vector< AtlasComplexSignal* >* >* m_pmapComplexSignals;

	// HACK ALERT: Handles the CASS extension that uses the READ verb to get the current date/time
	Atlas::AtlasString* m_pReadDate;

protected:

	void GetDateVariable( void );
	void SetPrimarySignal( unsigned int& uiPos, const Lookup* pLookup );
	void GetMeasuredCharacteristics( unsigned int& uiPos );
	void GetVariables( Atlas::AtlasStatementCharacteristic* pStatementCharacteristic );
	void GetVariables( Atlas::AtlasEvaluationStatement* pEvaluationStatement );
	void ProcessAdditionalStatementConfiguration( const unsigned int uiSize, unsigned int& ui, vector< const AtlasAttibuteValue* >& cnx );
	void ProcessCNXConfiguration( const vector< const AtlasAttibuteValue* >& cnx, const Lookup* pLookup );
	void SetCompResouce_Require( Atlas::AtlasSignalComponent* psigComp, const AtlasRequire* pRequire );

	void Init( void )
	{
		m_eVerbElementName = XML::enUnknown;
		m_pCNX = 0;
		m_pFromToEvent = 0;
		m_pGatedEvent = 0;
		m_pSyncEvent = 0;
		m_pEvaluationStatement = 0;
		m_bHasMeasureCharacteristics = false;
		m_bRemoveAll = false;
		m_bComplexSignal = false;
		m_uiComplexSignalRefId = 0;
		m_pReadDate = 0;
		m_pRequireStatements = 0;
	}

	void GarbageCollect( void );

};  // AtlasActionSignalVerb

class AtlasUnhandledStatement : public AtlasStatement
{
public:

	AtlasUnhandledStatement( const Atlas::eAtlasStatement eStatement, const XML::ElementName eElementName ) : AtlasStatement( eStatement ), m_eElementName( eElementName ) {  }
	AtlasUnhandledStatement( const AtlasUnhandledStatement& other ) { operator = ( other ); }
	AtlasUnhandledStatement& operator = ( const AtlasStatement& other );

	void InitFromXML( const StatementMetadata* pData );
	void Process( const Lookup* pLookup = 0 ) { }
	void ToXML( string& strXML ) const;

	XML::ElementName m_eElementName;

protected:

};  // AtlasUnhandledStatement

class AtlasStatements
{
public:

	AtlasStatements( const AtlasStatements& other ) { operator = ( other ); }
	AtlasStatements( ) : m_pLookup( 0 ), m_bProcessed( false ) { }
	#ifdef CASS
		AtlasStatements( const Lookup* pLookup ) : m_pLookup( pLookup ), m_bProcessed( false ) { }
	#endif
	virtual ~AtlasStatements( ) { GarbageCollect( ); }
	virtual AtlasStatements& operator = ( const AtlasStatements& other );

	virtual AtlasStatement* StatementFactory( const xercesc::DOMElement* pAIXMLvalue, const Atlas::eAtlasStatement eStatementType ) = 0;
	virtual AtlasStatement* StatementFactory( const AtlasStatement* pAtlasStatement ) = 0;

	void Process( void );

	unsigned int GetCount( void ) const { return m_vectStatement.size( ); }
	void InitId( void );

	const AtlasStatement* GetStatement( const unsigned int uiStatement );

protected:

	vector< AtlasStatement* > m_vectStatement;

	#ifdef CASS
		const Lookup* m_pLookup;
	#endif
	bool m_bProcessed;

	bool IsFileSystemFromXML( const xercesc::DOMElement* pAIXMLvalue );

	void GarbageCollect( void );

};  // class AtlasStatements