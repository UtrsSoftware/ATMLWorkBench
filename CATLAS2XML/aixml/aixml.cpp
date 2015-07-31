/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

#include <sstream>
#include <algorithm>
#include "aixml.h"
#include "helper.h"
#include "statements.h"
#include "CommandLine.h"
#include "complex_signal.h"
#include "cass/lookup.h"

// Atlas statement types
#include "require.h"
#include "perform.h"
#include "procedure.h"
#include "declare.h"
#include "conditional.h"
#include "calculate.h"
#include "compare.h"
#include "fill.h"
#include "delay.h"
#include "wait_for.h"
#include "enable.h"
#include "disable.h"
#include "prepare.h"
#include "execute.h"
#include "finish.h"
#include "goto.h"
#include "leave.h"
#include "comment.h"
#include "leave_resume_atlas.h"
#include "specify.h"

// Xercesc XML Parser
#include <xercesc/dom/DOMException.hpp>
#include <xercesc/framework/MemBufInputSource.hpp>
#include <xercesc/util/PlatformUtils.hpp>
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

unsigned int AIXML::m_uiNextId = 0;
map< const string*, Atlas::eAtlasStatement, AIXMLHelper::cmpPointer > AIXML::m_mapElementStatmentToAtlasStatementEnum;
map< Atlas::eAtlasStatement, pair< XML::ElementName, XML::ElementName > > AIXML::m_mapElementStatmentToAtlasStatementXMLElementNames;
const string AIXML::m_strXMLVersion( "1.0" );
const string AIXML::m_strXMLEncoding( "UTF-8" );

const string AIXML::m_arrayXMLKeyWords[ ] = 
{ 
	"<",
	">",
	"</",
	">",
	"AtlasFile",
	"Lookup",
	"SUBFILE",
	"num",
	"Mapping",
	"Argument",
	"Arguments",
	"name",
	"IncludeGroup",
	"num_element",
	"REQUIRE",
	"Keyword",
	"Character",
	"word",
	"text",
	"Constant",
	"sign",
	"INCLUDE_ATLAS_MODULE",
	"Filename",
	"line",
	"statno",
	"id",
	"ProcedureGroup",
	"APPLY",
	"Statements",
	"Segment",
	"DoGroup",
	"IfGroup",
	"WhileGroup",
	"ForGroup",
	"DefineStatements",
	"Variable",
	"MEASURE",
	"PERFORM",
	"Name",
	"String",
	"DEFINE_PROCEDURE",
	"INCLUDE_NON_ATLAS_MODULE",
	"scope",
	"external",
	"global",
	"local",
	"ProcedureArguments",
	"ResultArguments",
	"LocalPreamble",
	"DECLARE",
	"RequireStatements",
	"VERIFY",
	"SETUP",
	"READ",
	"MONITOR",
	"INITIATE",
	"REMOVE",
	"FETCH",
	"CONNECT",
	"DISCONNECT",
	"ARM",
	"CHANGE",
	"RESET",
	"DeclareStatements",
	"MainStatements",
	"IF",
	"ELSE",
	"WHILE",
	"FOR",
	"Expression",
	"RelOp",
	"CompareOp",
	"Boolean",
	"UnaryOp",
	"ArithOp",
	"VariableWS",
	"Function",
	"op",
	"Subscript",
	"UpLowLimit",
	"LowUpLimit",
	"BooleanOp",
	"Enum",
	"Range",
	"RangeList",
	"ENTRY_POINT",
	"Assignment",
	"Dim",
	"Nominal",
	"ComplexSignalGroup",
	"DEFINE_COMPLEX_SIGNAL",
	"SPECIFY",
	"Group",
	"END_IF",
	"END_FOR",
	"END_WHILE",
	"END_DEFINE",
	"CommentBlock",
	"Comment",
	"BRANCH_TARGET",
	"BEGIN_ATLAS_PROGRAM",
	"AtlasModule",
	"AtlasProgram",
	"TERMINATE_ATLAS_MODULE",
	"IPLGroup",
	"RESUME_ATLAS",
	"CodeBlock",
	"test_num"
};

const AIXML::ASTI AIXML::m_arrayAtlasVerb[ ] = 
{
	ASTI( "INITIATE",			Atlas::eINITIATE,			XML::enInitiates,		XML::enInitiate ),
	ASTI( "SETUP",				Atlas::eSETUP,				XML::enSetups,			XML::enSetup ),
	ASTI( "CONNECT",			Atlas::eCONNECT,			XML::enConnects,		XML::enConnect ),
	ASTI( "DISCONNECT",			Atlas::eDISCONNECT,			XML::enDisconnects,		XML::enDisconnect ),
	ASTI( "IDENTIFY",			Atlas::eIDENTIFY,			XML::enIdentifies,		XML::enIdentify ),
	ASTI( "FETCH",				Atlas::eFETCH,				XML::enFetches,			XML::enFetch ),
	ASTI( "ARM",				Atlas::eARM,				XML::enArms,			XML::enArm ),
	ASTI( "CHANGE",				Atlas::eCHANGE,				XML::enChanges,			XML::enChange ),
	ASTI( "APPLY",				Atlas::eAPPLY,				XML::enApplies,			XML::enApply ),
	ASTI( "REMOVE",				Atlas::eREMOVE,				XML::enRemoves,			XML::enRemove ),
	ASTI( "MEASURE",			Atlas::eMEASURE,			XML::enMeasures,		XML::enMeasure ),
	ASTI( "REQUIRE",			Atlas::eREQUIRE,			XML::enRequires,		XML::enRequire ),
	ASTI( "MONITOR",			Atlas::eMONITOR,			XML::enMonitors,		XML::enMonitor ),
	ASTI( "VERIFY",				Atlas::eVERIFY,				XML::enVerifies,		XML::enVerify ),
	ASTI( "READ",				Atlas::eREAD,				XML::enReads,			XML::enRead ),
	ASTI( "RESET",				Atlas::eRESET,				XML::enResets,			XML::enReset ),
	ASTI( "EXTEND",				Atlas::eEXTEND,				XML::enExtends,			XML::enExtend ),
	ASTI( "DEFINE PROCEDURE",	Atlas::eDEFINE_PROCEDURE,	XML::enProcedures,		XML::enProcedure ),
	ASTI( "DECLARE",			Atlas::eDECLARE,			XML::enDeclares,		XML::enDeclare ),
	ASTI( "CALCULATE",			Atlas::eCALCULATE,			XML::enCalculates,		XML::enCalculate ),
	ASTI( "CLOSE",				Atlas::eCLOSE,				XML::enCloses,			XML::enClose ),
	ASTI( "COMPARE",			Atlas::eCOMPARE,			XML::enCompares,		XML::enCompare ),
	ASTI( "DELAY",				Atlas::eDELAY,				XML::enDelays,			XML::enDelay ),
	ASTI( "DISABLE",			Atlas::eDISABLE,			XML::enDisables,		XML::enDisable ),
	ASTI( "DO_EXCHANGE",		Atlas::eDO_EXCHANGE,		XML::enDoExchanges,		XML::enDoExchange ),
	ASTI( "ENABLE",				Atlas::eENABLE,				XML::enEnables,			XML::enEnable ),
	ASTI( "EXECUTE",			Atlas::eEXECUTE,			XML::enExecutes,		XML::enExecute ),
	ASTI( "FILL",				Atlas::eFILL,				XML::enFills,			XML::enFill ),
	ASTI( "FINISH",				Atlas::eFINISH,				XML::enFinishes,		XML::enFinish ),
	ASTI( "INPUT",				Atlas::eINPUT,				XML::enInputs,			XML::enInput ),
	ASTI( "OPEN",				Atlas::eOPEN,				XML::enOpens,			XML::enOpen ),
	ASTI( "OUTPUT",				Atlas::eOUTPUT,				XML::enOutputs,			XML::enOutput ),
	ASTI( "PREPARE",			Atlas::ePREPARE,			XML::enPrepares,		XML::enPrepare ),
	ASTI( "WAIT_FOR",			Atlas::eWAIT_FOR,			XML::enWaitFors,		XML::enWaitFor ),
	ASTI( "DEFINE",				Atlas::eDEFINE,				XML::enUnknown,			XML::enUnknown ),
	ASTI( "LEAVE",				Atlas::eLEAVE_PROCEDURE,	XML::enUnknown,			XML::enUnknown ),
	ASTI( "LEAVE_IF",			Atlas::eLEAVE_IF,			XML::enUnknown,			XML::enUnknown ),
	ASTI( "LEAVE_FOR",			Atlas::eLEAVE_FOR,			XML::enUnknown,			XML::enUnknown ),
	ASTI( "LEAVE_WHILE",		Atlas::eLEAVE_WHILE,		XML::enUnknown,			XML::enUnknown ),
	ASTI( "GO_TO",				Atlas::eGO_TO,				XML::enUnknown,			XML::enUnknown ),
	ASTI( "IF",					Atlas::eIF_THEN,			XML::enUnknown,			XML::enUnknown ),
	ASTI( "ELSE",				Atlas::eELSE,				XML::enUnknown,			XML::enUnknown ),
	ASTI( "WHILE",				Atlas::eWHILE_THEN,			XML::enUnknown,			XML::enUnknown ),
	ASTI( "FOR",				Atlas::eFOR_THEN,			XML::enUnknown,			XML::enUnknown ),
	ASTI( "PERFORM",			Atlas::ePERFORM,			XML::enUnknown,			XML::enPerform ),
	ASTI( "LEAVE_ATLAS",		Atlas::eLEAVE_ATLAS,		XML::enLeaveAtlases,	XML::enLeaveAtlas ),
	ASTI( "RESUME_ATLAS",		Atlas::eRESUME_ATLAS,		XML::enResumeAtlases,	XML::enResumeAtlas )
};
const unsigned int AIXML::m_uiAtlasStatements = ( sizeof( AIXML::m_arrayAtlasVerb ) / sizeof( AIXML::ASTI ) );

const string AIXML::m_arrayXPath[ ] = 
{
	"AtlasFile\\Lookup",
	"AtlasFile\\AtlasProgram\\ProgramPreamble\\IncludeStatements",
	"IncludeGroup\\IncludeFile\\Lookup",
	"AtlasFile\\AtlasProgram\\ProgramPreamble\\RequireStatements",
	"IncludeGroup\\IncludeFile\\AtlasModule\\ModulePreamble\\RequireStatements",
	"AtlasFile\\AtlasProgram\\ProgramPreamble",
	"AtlasFile\\AtlasProgram\\MainStatements",
	"DEFINE_PROCEDURE\\Name",
	"IncludeFile\\AtlasModule\\ModulePreamble",
	"AtlasFile\\AtlasProgram\\ProgramPreamble\\DeclareStatements",
	"AtlasFile\\AtlasProgram\\TERMINATE_ATLAS_PROGRAM",
	"AtlasFile\\AtlasProgram\\BEGIN_ATLAS_PROGRAM\\ProgramName"
};

AIXML::AIXML( const CommandLine* pCommandLine, const string& strParserVersion ) : 
	m_strParserVersion( strParserVersion ), 
	m_pDoc( 0 ), 
	m_pRoot( 0 ),
	m_parser( 0 ),
	m_pMainStatements( 0 ),
	m_pTerminateStatement( 0 ),
	m_pMergedLookup( 0 ),
	m_pMergedRequires( 0 ),
	m_bXercesInit( false ),
	m_bHasSegments( false ),
	m_bProcedureCallHierarchyXML( false ),
	m_bExcludeUnused( false ),
	m_bIEEE1641XML( true ),
	m_bIEEE260_1XML( true ),
	m_uiProgTreeStartMain( 0 ),
	m_uiProgTreeEndMain( 0 ),
	m_uiMainProcId( 0 ),
	m_uiUsedProcCount( 1 ), // One for the main procedural structure
	m_eStationType( XML::avUnknown ),
	m_pCommentsDOMStatements( 0 )
{
	if ( 0 != pCommandLine )
	{
		m_strOutputFilename = pCommandLine->GetOutputFilename( true );
		m_strProcHierOutputFilename = pCommandLine->GetProcHierOutputFilename( true );
		m_strUUTName = pCommandLine->GetUUTName( );
		m_strUUTId = pCommandLine->GetUUTId( );
		m_bProcedureCallHierarchyXML = pCommandLine->ProcedureCallHierarchyXML( );
		m_bExcludeUnused = !pCommandLine->UnusedProcXML( );
		m_bIEEE1641XML = pCommandLine->IEEE1641XML( );
		m_bIEEE260_1XML = pCommandLine->IEEE260_1XML( );

		Atlas::AtlasSignalComponent::Set1641ToXML( m_bIEEE1641XML );
		Atlas::AtlasUnitOfMeasure::Set260_1XML( m_bIEEE260_1XML );

		switch ( pCommandLine->GetTestStation( ) )
		{
			case CommandLine::eCASS:
				m_eStationType = XML::avCass;
				break;

			case CommandLine::eHYBRID:
				m_eStationType = XML::avHybridCass;
				break;

			case CommandLine::eRTCASS:
				m_eStationType = XML::avRtcass;
				break;
				
			case CommandLine::eECASS:
				m_eStationType = XML::avEcass;
				break;
		}
	}
}

bool AIXML::Parse( const char* pASTxml, const unsigned int uiASTxmlLength )
{
	const bool bBuildProgramTree = true;
	bool bRet = false;

	try
	{
		// *** TODO ***
		//
		// Partially completed procedural statements (contained in test cases).
		// Only the verb name has been parsed and is contained in the AIXML.
		// Need to parse each statement's attributes. Method "BuildUnhandledStatements"
		// processes these statements currently. To fully complete all three, it makes
		// the most sense to complete the preamble statements that are listed below. The
		// uncompleted preamble statements are used by these partially completed statements.
		//    INPUT
		//    OUTPUT
		//    DO EXCHANGE
		//
		// Uncompleted.
		//   Procedural statements
		//      ENABLE EVENT - CASS Atlas (not in test cases)
		//      DISABLE EVENT - CASS Atlas (not in test cases)
		//      DO DIGITAL TEST - In test cases, but appears to be always commented out (replaced with L200 stuff?)
		//
		//   Preamble statements (used by procedural statements, need to link with the "ref_id" of the following statements)
		//      IDENTIFY EVENT - In test cases but can't find in 1985 Atlas or CASS documentation but is in 1995 Atlas
		//      IDENTIFY BUS PROTOCOL - CASS Atlas
		//      DEFINE EXCHANGE - CASS and 1995 Atlas
		//      DEFINE MESSAGE - 1985 Atlas


		XMLPlatformUtils::Initialize( );

		m_bXercesInit = true;

		Init( pASTxml, uiASTxmlLength );

		CreateBuiltInVariables( );

		BuildLookups( );

		SetAtlasSources( );

		BuildDeclares( );
		BuildRequires( );
		BuildProcedures( );
		BuildComments( );
		BuildComplexSignals( );

		GetProcedureStatements( );
		BuildPerforms( );
		ProcessProcedureSymbolTable( );

		BuildRegularStatements( );

		BuildUnhandledStatements( );

		ProcessDeclareSymbolTable( );
		ProcessDeclares( );
		BuildProcedureStatements( );
		ProcessDigitalExpressions( );
		SetStatementsParent( );
		ProcessGotoLeaveStatements( );
		BuildProgramTree( bBuildProgramTree );
		BuildStatistics( );
		MergeRequireInfo( );

		#if ( _DEBUG )
			VerifyStatementOrder( );
		#endif

		PreliminaryGarbageCollect( );

		bRet = true;
	}
	catch ( const Exception& e )
	{
		m_excep = e;
	}
	catch ( const DOMException& e )
	{
		m_excep.SetInfo( Exception::eXercesException, __FILE__, __FUNCTION__, __LINE__, AIXMLHelper::GetXercesString( e.getMessage( ) ) );
	}
	catch ( const XMLException& e )
	{
		m_excep.SetInfo( Exception::eXercesException, __FILE__, __FUNCTION__, __LINE__, AIXMLHelper::GetXercesString( e.getMessage( ) ) );
	}

	return bRet;
}

void AIXML::Init( const char* pASTxml, const unsigned int uiASTxmlLength )
{
	m_xmlOutFile.open( m_strOutputFilename.c_str( ), ( ofstream::out | ofstream::binary ) );

	if ( !m_xmlOutFile.is_open( ) )
	{
		throw Exception( Exception::eCannotOpenOutputAIXMLFile, __FILE__, __FUNCTION__, __LINE__ );
	}

	if ( m_bProcedureCallHierarchyXML && !m_strProcHierOutputFilename.empty( ) )
	{
		m_xmlProcHierOutFile.open( m_strProcHierOutputFilename.c_str( ), ( ofstream::out | ofstream::binary ) );
	
		if ( !m_xmlProcHierOutFile.is_open( ) )
		{
			throw Exception( Exception::eCannotOpenOutputProcHierAIXMLFile, __FILE__, __FUNCTION__, __LINE__ );
		}
	}

	if ( 0 == uiASTxmlLength )
	{
		throw Exception( Exception::eInvalidASTLength, __FILE__, __FUNCTION__, __LINE__ );
	}

	string strOverAllClosingTag( m_arrayXMLKeyWords[ eEndElement ] );
	strOverAllClosingTag += m_arrayXMLKeyWords[ eAtlasFileElement ];
	strOverAllClosingTag += m_arrayXMLKeyWords[ eTerminateEndElement ];

	const unsigned int uiDoubleEndMarkerLen = ( strOverAllClosingTag.length( ) * 2 );

	if ( uiASTxmlLength <= uiDoubleEndMarkerLen )
	{
		throw Exception( Exception::eFailedToAssignXMLInputBuffer, __FILE__, __FUNCTION__, __LINE__ );
	}

	const string strEndOfXmlStream( ( pASTxml + uiASTxmlLength ) - uiDoubleEndMarkerLen );

	if ( string::npos == strEndOfXmlStream.find( strOverAllClosingTag ) )
	{
		throw Exception( Exception::eFailedToLocateFinalClosingElement, __FILE__, __FUNCTION__, __LINE__ );
	}

	try
	{
		m_parser = new XercesDOMParser( );
	}
	catch ( ... )
	{
		throw Exception( Exception::eFailedToCreateXercesParser, __FILE__, __FUNCTION__, __LINE__ );
	}

	MemBufInputSource memBufIS( ( const unsigned char* const ) pASTxml, uiASTxmlLength, "AIXML", false );

	m_parser->parse( memBufIS );

	m_pDoc = m_parser->getDocument( );

	if ( 0 == m_pDoc )
	{
		throw Exception( Exception::eFailedToGetDocumentFromXercesParser, __FILE__, __FUNCTION__, __LINE__ );
	}

	m_pRoot = m_pDoc->getDocumentElement( );

	if ( 0 == m_pRoot )
	{
		throw Exception( Exception::eFailedToGetRootElementFromXercesParser, __FILE__, __FUNCTION__, __LINE__ );
	}

	const string strRootTagName( AIXMLHelper::GetXercesString( m_pRoot->getTagName( ) ) );

	if ( m_arrayXMLKeyWords[ eAtlasFileElement ] != strRootTagName )
	{
		throw Exception( Exception::eFailedToLocateRootXMLElement, __FILE__, __FUNCTION__, __LINE__ );
	}

	m_pMainStatements = AIXMLHelper::FindElementPath( m_pRoot, m_arrayXPath[ ePrimaryMainPath ], true );
	m_pTerminateStatement = AIXMLHelper::FindElementPath( m_pRoot, m_arrayXPath[ eTerminateStatementPath ], true );

	const xercesc::DOMElement* pFirstChild = m_pMainStatements->getFirstElementChild( );
	const xercesc::DOMElement* pChild = pFirstChild;
	string strSegmentName;

	for ( int i = 0; i < 2; i++ )
	{
		while ( 0 != pChild )
		{
			const DOMAttr* pAttr = pChild->getAttributeNode( AIXMLHelper::GetWString( m_arrayXMLKeyWords[ eLineAttribute ] ).c_str( ) );
			if ( 0 != pAttr )
			{
				string strLineNum;
	
				AIXMLHelper::GetXercesString( pAttr->getValue( ), strLineNum );

				m_MainSourceStatement.SetLineNumber( AIXMLHelper::StringToNumber< unsigned int >( strLineNum ) );

				pAttr = pChild->getAttributeNode( AIXMLHelper::GetWString( m_arrayXMLKeyWords[ eStatementNumberAttribute ] ).c_str( ) );
				if ( 0 != pAttr )
				{
					string strStatementNum;

					AIXMLHelper::GetXercesString( pAttr->getValue( ), strStatementNum );
		
					m_MainSourceStatement.SetStatementNumber( strStatementNum );
				}

				if ( !strSegmentName.empty( ) )
				{
					m_MainSourceStatement.SetSourceType( Atlas::AtlasSourceStatement::eAtlasSegment );
					m_MainSourceStatement.SetFilename( strSegmentName );
				}
				else
				{
					m_MainSourceStatement.SetSourceType( Atlas::AtlasSourceStatement::eAtlasProgram );

					if ( !m_strPrimaryAtlasFilename.empty( ) )
					{
						m_MainSourceStatement.SetFilename( m_strPrimaryAtlasFilename );
					}
				}

				break;
			}

			pChild = pChild->getNextElementSibling( );
		}

		if ( m_MainSourceStatement.GetFilename( ).empty( ) )
		{
			string strAIXMLtagName;

			pChild = pFirstChild;

			AIXMLHelper::GetXercesString( pChild->getTagName( ), strAIXMLtagName );

			if ( m_arrayXMLKeyWords[ eSegmentElement ] == strAIXMLtagName )
			{
				const DOMAttr* pAttr = pChild->getAttributeNode( AIXMLHelper::GetWString( m_arrayXMLKeyWords[ eNameAttribute ] ).c_str( ) );
				if ( 0 != pAttr )
				{
					AIXMLHelper::GetXercesString( pAttr->getValue( ), strSegmentName );

					VerifyIfExtension( strSegmentName );

					strSegmentName = AIXMLHelper::StripPath( strSegmentName );
				}

				pChild = pChild->getFirstElementChild( );
			}
			else
			{
				break;
			}
		}
		else
		{
			break;
		}
	}

	const xercesc::DOMElement* pLastChild = m_pRoot->getLastElementChild( );
	const xercesc::DOMElement* pPrevLastChild = 0;

	while ( 0 != pLastChild )
	{
		pPrevLastChild = pLastChild;

		pLastChild = pLastChild->getLastElementChild( );
	}

	if ( 0 != pPrevLastChild )
	{
		const DOMAttr* pIdAttr = pPrevLastChild->getAttributeNode( AIXMLHelper::GetWString( m_arrayXMLKeyWords[ eIdAttribute ] ).c_str( ) );

		if ( 0 != pIdAttr )
		{
			m_uiNextId = AIXMLHelper::StringToNumber< unsigned int >( AIXMLHelper::GetXercesString( pIdAttr->getValue( ) ) );
		}
	}

	#if ( _DEBUG ) && ( WIN32 )
	if ( 0 == m_uiNextId )
	{
		DebugBreak( );
	}
	#endif

	const int iMax = ( m_uiAtlasStatements + 1 );
	for ( int i = 0; i < iMax; ++i )
	{
		m_mapElementStatmentToAtlasStatementEnum.insert( make_pair( &m_arrayAtlasVerb[ i ].m_strAtlasStatement, m_arrayAtlasVerb[ i ].m_eAtlasStatement ) );
		m_mapElementStatmentToAtlasStatementXMLElementNames.insert( make_pair( m_arrayAtlasVerb[ i ].m_eAtlasStatement, make_pair( m_arrayAtlasVerb[ i ].m_ePluralElementName, m_arrayAtlasVerb[ i ].m_eSingalElementName ) ) );
	}
}

void AIXML::BuildLookups( void )
{
	BuildLookup( AIXMLHelper::FindElementPath( m_pRoot, m_arrayXPath[ eParentLookupPath ] ) );

	const DOMElement* pIncludes = AIXMLHelper::FindElementPath( m_pRoot, m_arrayXPath[ eIncludeStatementsPath ], false );

	if ( 0 != pIncludes )
	{
		BuildIncludeFileLookups( pIncludes );
	}

	MergeLookups( );
}

void AIXML::BuildRequires( void )
{
	BuildRequire( AIXMLHelper::FindElementPath( m_pRoot, m_arrayXPath[ eParentRequirePath ] ), m_strPrimaryAtlasFilename, Atlas::AtlasSourceStatement::eAtlasProgram );

	const DOMElement* pIncludes = AIXMLHelper::FindElementPath( m_pRoot, m_arrayXPath[ eIncludeStatementsPath ], false );

	if ( 0 != pIncludes )
	{
		BuildIncludeFileRequires( pIncludes );
	}
}

void AIXML::MergeRequireInfo( void )
{
	// Don't change the order...

	MergeRequires( );

	MergeInstruments( );

	MergeClasses( );

	MergeSignals( );
}

void AIXML::BuildComments( void )
{
	FileInfo commentStatementsFI;

	commentStatementsFI.m_strFilename = m_strPrimaryAtlasFilename;

	BuildComments( m_pRoot, &commentStatementsFI );

	if ( 0 != m_pCommentsDOMStatements )
	{
		const unsigned int uiCommentsCount = m_pCommentsDOMStatements->m_vectStatements.size( );
		vector< AtlasStatement* >* pvectStatements = 0;
		string strLastFilename;

		for ( unsigned int ui = 0; ui < uiCommentsCount; ++ui )
		{
			const StatementMetadata* pdata = m_pCommentsDOMStatements->m_vectStatements[ ui ];
			AtlasComment* pAtlasComment = 0;

			try
			{
				pAtlasComment = new AtlasComment;
			}
			catch ( ... )
			{
				throw Exception( Exception::eFailedToAllocateMemoryForNewStatementObject, __FILE__, __FUNCTION__, __LINE__ );
			}

			auto_ptr< AtlasStatement > autoptr( pAtlasComment );

			pAtlasComment->InitFromXML( pdata );

			if ( pAtlasComment->m_uiCommentLength > 0 )
			{
				if ( strLastFilename != pdata->m_strFilename )
				{
					const map< string, pair< Atlas::AtlasSourceStatement::eSourceType, vector< AtlasStatement* >* > >::const_iterator it = m_mapComments.find( pdata->m_strFilename );
					const map< string, pair< Atlas::AtlasSourceStatement::eSourceType, vector< AtlasStatement* >* > >::const_iterator itEnd = m_mapComments.end( );
	
					if ( itEnd == it )
					{
						try
						{
							pvectStatements = new vector< AtlasStatement* >( );
						}
						catch ( ... )
						{
							throw Exception( Exception::eFailedToCreateVectorObject, __FILE__, __FUNCTION__, __LINE__ );
						}
	
						m_mapComments.insert( make_pair( pdata->m_strFilename, make_pair( pdata->m_eSourceType, pvectStatements ) ) );
					}
					else
					{
						pvectStatements = it->second.second;
					}
				}
	
				pvectStatements->push_back( autoptr.release( ) );
			}
			else
			{
				delete autoptr.release( );
			}
		}
	}
}

void AIXML::BuildComments( const xercesc::DOMElement* pElement, FileInfo* pFileInfo )
{
	if ( 0 != pElement )
	{
		string strAIXMLtagName;

		while ( 0 != pElement )
		{
			AIXMLHelper::GetXercesString( pElement->getTagName( ), strAIXMLtagName );

			if ( m_arrayXMLKeyWords[ eIncludeNonAtlasModuleElement ] == strAIXMLtagName )
			{
				break;
			}
			else if ( m_arrayXMLKeyWords[ eDefineProcedureElement ] == strAIXMLtagName )
			{
				const DOMAttr* pAttr = pElement->getAttributeNode( AIXMLHelper::GetWString( m_arrayXMLKeyWords[ eIdAttribute ] ).c_str( ) );

				if ( 0 != pAttr )
				{
					pFileInfo->m_uiProcId = AIXMLHelper::StringToNumber< unsigned int >( AIXMLHelper::GetXercesString( pAttr->getValue( ) ) );
				}

				const xercesc::DOMElement* pChild = pElement->getFirstElementChild( );
	
				if ( 0 != pChild )
				{
					pAttr = pChild->getAttributeNode( AIXMLHelper::GetWString( m_arrayXMLKeyWords[ eNameAttribute ] ).c_str( ) );
	
					if ( 0 != pAttr )
					{
						AIXMLHelper::GetXercesString( pAttr->getValue( ), pFileInfo->m_strProcName );
					}
				}
			}
			else if ( m_arrayXMLKeyWords[ eEndDefineElement ] == strAIXMLtagName )
			{
				pFileInfo->m_strProcName.clear( );
				pFileInfo->m_uiProcId = 0;
			}
			else if ( m_arrayXMLKeyWords[ eMainStatementsElement ] == strAIXMLtagName )
			{
				pFileInfo->m_strFilename = m_strPrimaryAtlasFilename;
				pFileInfo->m_uiProcId = m_uiMainProcId;
				pFileInfo->m_strProcName = AtlasStatement::m_strMAIN_PROC_NAME;

				pFileInfo->m_bLookup = false;
				pFileInfo->m_bInclude = false;
				pFileInfo->m_bSegment = false;
			}
			else if ( m_arrayXMLKeyWords[ eAtlasProgramElement ] == strAIXMLtagName )
			{
				pFileInfo->m_strFilename = m_strPrimaryAtlasFilename;

				pFileInfo->m_bLookup = false;
				pFileInfo->m_bInclude = false;
				pFileInfo->m_bSegment = false;
			}
			else if ( m_arrayXMLKeyWords[ eAtlasModuleElement ] == strAIXMLtagName )
			{
				pFileInfo->m_strFilename = AIXMLHelper::StripExtension( pFileInfo->m_strFilename );
				VerifyIfExtension( pFileInfo->m_strFilename );

				pFileInfo->m_bLookup = false;
				pFileInfo->m_bInclude = true;
				pFileInfo->m_bSegment = false;
			}
			else if ( m_arrayXMLKeyWords[ eTerminateAtlasModuleElement ] == strAIXMLtagName )
			{
				pFileInfo->m_strFilename = m_strPrimaryAtlasFilename;
			}
			else if ( m_arrayXMLKeyWords[ eIncludeAtlasModuleElement ] == strAIXMLtagName )
			{
				pFileInfo->m_bInclude = true;

				pFileInfo->m_bSegment = false;
				pFileInfo->m_bLookup = false;
			}
			else if ( m_arrayXMLKeyWords[ eLookupElement ] == strAIXMLtagName )
			{
				pFileInfo->m_bLookup = true;
				pFileInfo->m_strFilename = AIXMLHelper::StripExtension( pFileInfo->m_strFilename );
				pFileInfo->m_strFilename += ".lu";

				pFileInfo->m_bSegment = false;
			}
			else if ( m_arrayXMLKeyWords[ eFilenameElement ] == strAIXMLtagName )
			{
				const DOMAttr* pAttr = pElement->getAttributeNode( AIXMLHelper::GetWString( m_arrayXMLKeyWords[ eNameAttribute ] ).c_str( ) );

				if ( 0 != pAttr )
				{
					AIXMLHelper::GetXercesString( pAttr->getValue( ), pFileInfo->m_strFilename );

					VerifyIfExtension( pFileInfo->m_strFilename );

					pFileInfo->m_strFilename = AIXMLHelper::StripPath( pFileInfo->m_strFilename );
				}
			}
			else if ( m_arrayXMLKeyWords[ eSegmentElement ] == strAIXMLtagName )
			{
				pFileInfo->m_bSegment = true;

				const DOMAttr* pAttr = pElement->getAttributeNode( AIXMLHelper::GetWString( m_arrayXMLKeyWords[ eNameAttribute ] ).c_str( ) );

				if ( 0 != pAttr )
				{
					AIXMLHelper::GetXercesString( pAttr->getValue( ), pFileInfo->m_strFilename );

					VerifyIfExtension( pFileInfo->m_strFilename );

					pFileInfo->m_strFilename = AIXMLHelper::StripPath( pFileInfo->m_strFilename );
				}

				pFileInfo->m_bLookup = false;
				pFileInfo->m_bInclude = false;
			}
			else
			{
				const bool bCommentBlock = ( m_arrayXMLKeyWords[ eCommentBlockElement ] == strAIXMLtagName );
				const bool bBranchTarget = ( m_arrayXMLKeyWords[ eBranchTargetElement ] == strAIXMLtagName );
				const bool bEntryPoint = ( m_arrayXMLKeyWords[ eEntryPointElement ] == strAIXMLtagName );

				if ( bCommentBlock || bBranchTarget || bEntryPoint )
				{
					const DOMStatements* GetDOMStatements( const Atlas::eAtlasStatement eStatement );
	
					if ( 0 == m_pCommentsDOMStatements )
					{
						try
						{
							m_pCommentsDOMStatements = new DOMStatements;
						}
						catch ( ... )
						{
							throw Exception( Exception::eFailedToAllocateMemoryForNewDOMStatementsObject, __FILE__, __FUNCTION__, __LINE__ );
						}
		
						m_mapDOMElementStatements.insert( make_pair( Atlas::eCOMMENT, m_pCommentsDOMStatements ) );
					}
	
					StatementMetadata metaData;
	
					if ( pFileInfo->m_bLookup )
					{
						if ( pFileInfo->m_bInclude )
						{
							metaData.m_eSourceType = Atlas::AtlasSourceStatement::eCassModuleLookup;
						}
						else
						{
							metaData.m_eSourceType = Atlas::AtlasSourceStatement::eCassProgramLookup;
						}
					}
					else if ( pFileInfo->m_bSegment )
					{
						metaData.m_eSourceType = Atlas::AtlasSourceStatement::eAtlasSegment;
					}
					else
					{
						if ( pFileInfo->m_bInclude )
						{
							metaData.m_eSourceType = Atlas::AtlasSourceStatement::eAtlasModule;
						}
						else
						{
							metaData.m_eSourceType = Atlas::AtlasSourceStatement::eAtlasProgram;
						}
					}
	
					metaData.m_pStatement = pElement;
					metaData.m_strFilename = pFileInfo->m_strFilename;
					metaData.m_strParentProcedureName = pFileInfo->m_strProcName;
					metaData.m_uiParentProcedureId = pFileInfo->m_uiProcId;
	
					m_pCommentsDOMStatements->InsertMetadata( metaData );
				}
				}

			const xercesc::DOMElement* pChild = pElement->getFirstElementChild( );

			if ( 0 != pChild )
			{
				BuildComments( pChild, pFileInfo );
			}

			pElement = pElement->getNextElementSibling( );
		}
	}
}

void AIXML::BuildDeclares( void )
{
	map< string, pair< const Atlas::AtlasSourceStatement::eSourceType, vector< const DOMElement* > > > mapDeclares;

	BuildDeclare( AIXMLHelper::FindElementPath( m_pRoot, m_arrayXPath[ eParentDeclarePath ], false ), m_strPrimaryAtlasFilename, Atlas::AtlasSourceStatement::eAtlasProgram, mapDeclares );

	const DOMElement* pIncludes = AIXMLHelper::FindElementPath( m_pRoot, m_arrayXPath[ eIncludeStatementsPath ], false );

	if ( 0 != pIncludes )
	{
		BuildIncludeFileDeclares( pIncludes, mapDeclares );
	}

	if ( mapDeclares.size( ) > 0 )
	{
		InitDeclares( mapDeclares );
	}
}

void AIXML::BuildIncludeFileDeclares( const xercesc::DOMElement* pIncludes, map< string, pair< const Atlas::AtlasSourceStatement::eSourceType, vector< const DOMElement* > > >& mapDeclares )
{
	if ( 0 != pIncludes )
	{
		const xercesc::DOMElement* pAIXMLvalue = pIncludes->getFirstElementChild( );
	
		if ( 0 == pAIXMLvalue )
		{
			throw Exception( Exception::eFailedToGetChildNodes, __FILE__, __FUNCTION__, __LINE__ );
		}
	
		while ( 0 != pAIXMLvalue )
		{
			string strAIXMLtagName;
	
			AIXMLHelper::GetXercesString( pAIXMLvalue->getTagName( ), strAIXMLtagName );
	
			if ( m_arrayXMLKeyWords[ eIncludeGroupElement ] == strAIXMLtagName )
			{
				const xercesc::DOMElement* pModule = pAIXMLvalue->getFirstElementChild( );

				if ( 0 != pModule )
				{
					AIXMLHelper::GetXercesString( pModule->getTagName( ), strAIXMLtagName );

					if ( strAIXMLtagName == m_arrayXMLKeyWords[ eIncludeAtlasModuleElement ] )
					{
						const xercesc::DOMElement* pModuleChild = pModule->getFirstElementChild( );
						string strFilename;

						if ( 0 != pModuleChild )
						{
							const DOMAttr* pAttr = pModuleChild->getAttributeNode( AIXMLHelper::GetWString( m_arrayXMLKeyWords[ eNameAttribute ] ).c_str( ) );
		
							if ( 0 != pAttr )
							{
								AIXMLHelper::GetXercesString( pAttr->getValue( ), strFilename );

								VerifyIfExtension( strFilename );

								strFilename = AIXMLHelper::StripPath( strFilename );
							}
						}

						pModule = pModule->getNextElementSibling( );

						if ( 0 != pModule )
						{
							const xercesc::DOMElement* pPreamble = AIXMLHelper::FindElementPath( pModule, m_arrayXPath[ eIncludeAtlasModulePreamblePath ], false );

							if ( 0 != pPreamble )
							{
								const xercesc::DOMElement* pPreambleChild = pPreamble->getFirstElementChild( );

								if ( 0 != pPreambleChild )
								{
									BuildDeclare( pPreambleChild, strFilename, Atlas::AtlasSourceStatement::eAtlasModule, mapDeclares );
								}
							}
						}
					}
				}
			}
	
			pAIXMLvalue = pAIXMLvalue->getNextElementSibling( );
		}
	}
}

void AIXML::BuildDeclare( const DOMElement* pPreambleChild, const string& strSourceFilename, const Atlas::AtlasSourceStatement::eSourceType eSourceType, map< string, pair< const Atlas::AtlasSourceStatement::eSourceType, vector< const DOMElement* > > >& mapDeclares )
{
	vector< const DOMElement* >* pvectDeclares = 0;

	while ( 0 != pPreambleChild )
	{
		string strAIXMLtagName;

		AIXMLHelper::GetXercesString( pPreambleChild->getTagName( ), strAIXMLtagName );

		if ( m_arrayXMLKeyWords[ eDeclareStatementsElement ] == strAIXMLtagName )
		{
			const DOMElement* pDeclareChild = pPreambleChild->getFirstElementChild( );

			while ( 0 != pDeclareChild )
			{
				AIXMLHelper::GetXercesString( pDeclareChild->getTagName( ), strAIXMLtagName );
		
				if ( m_arrayXMLKeyWords[ eDeclareElement ] == strAIXMLtagName )
				{
					if ( 0 == pvectDeclares )
					{
						pair< map< string, pair< const Atlas::AtlasSourceStatement::eSourceType, vector< const DOMElement* > > >::iterator, bool > prRet = mapDeclares.insert( make_pair( strSourceFilename, make_pair( eSourceType, vector< const DOMElement* >( ) ) ) );

						if ( prRet.second )
						{
							pvectDeclares = &( prRet.first->second.second );
						}
					}

					if ( 0 != pvectDeclares )
					{
						pvectDeclares->push_back( pDeclareChild );
					}
				}

				pDeclareChild = pDeclareChild->getNextElementSibling( );
			}
		}

		pPreambleChild = pPreambleChild->getNextElementSibling( );
	}
}

void AIXML::InitDeclares( map< string, pair< const Atlas::AtlasSourceStatement::eSourceType, vector< const xercesc::DOMElement* > > >& mapDeclares )
{
	map< string, pair< const Atlas::AtlasSourceStatement::eSourceType, vector< const xercesc::DOMElement* > > >::const_iterator it = mapDeclares.begin( );
	const map< string, pair< const Atlas::AtlasSourceStatement::eSourceType, vector< const xercesc::DOMElement* > > >::const_iterator itEnd = mapDeclares.end( );
	map< string, vector< AtlasDeclareData* >* >::const_iterator itDeclare;
	const map< string, vector< AtlasDeclareData* >* >::const_iterator itDeclareEnd = m_mapDeclares.end( );
	AtlasDeclare declare;

	while ( itEnd != it )
	{
		const string& strFilename = it->first;
		const Atlas::AtlasSourceStatement::eSourceType eSourceType = it->second.first;
		vector< const xercesc::DOMElement* > vectDOMDeclares = it->second.second;
		const unsigned int uiDOMSize = vectDOMDeclares.size( );

		for ( unsigned int ui = 0; ui < uiDOMSize; ++ui )
		{
			vector< AtlasDeclareData* > vectDeclares;

			declare.InitFromXML( vectDOMDeclares[ ui ], eSourceType, strFilename );

			declare.Process( vectDeclares );

			const unsigned int uiDeclares = vectDeclares.size( );

			if ( uiDeclares > 0 )
			{
				for ( unsigned int ui = 0; ui < uiDeclares; ++ui )
				{
					itDeclare = m_mapDeclares.find( vectDeclares[ ui ]->m_Declare.m_strVarName );
	
					if ( itDeclareEnd == itDeclare )
					{
						vector< AtlasDeclareData* >* pvectStatements = 0;
							
						try
						{
							pvectStatements = new vector< AtlasDeclareData* >( );
						}
						catch ( ... )
						{
							throw Exception( Exception::eFailedToCreateVectorObject, __FILE__, __FUNCTION__, __LINE__ );
						}

						m_mapDeclares.insert( make_pair( vectDeclares[ ui ]->m_Declare.m_strVarName, pvectStatements ) );
	
						pvectStatements->push_back( vectDeclares[ ui ] );
					}
					else
					{
						itDeclare->second->push_back( vectDeclares[ ui ] );
					}
				}
			}
		}

		++it;
	}
}

void AIXML::BuildComplexSignals( void )
{
	map< string, pair< const Atlas::AtlasSourceStatement::eSourceType, vector< const DOMElement* > > > mapComplexSignals;

	BuildComplexSignal( AIXMLHelper::FindElementPath( m_pRoot, m_arrayXPath[ ePrimaryPreamblePath ], false ), m_strPrimaryAtlasFilename, Atlas::AtlasSourceStatement::eAtlasProgram, mapComplexSignals );

	const DOMElement* pIncludes = AIXMLHelper::FindElementPath( m_pRoot, m_arrayXPath[ eIncludeStatementsPath ], false );

	if ( 0 != pIncludes )
	{
		BuildIncludeFileComplexSignals( pIncludes, mapComplexSignals );
	}

	if ( mapComplexSignals.size( ) > 0 )
	{
		InitComplexSignals( mapComplexSignals );
	}
}

void AIXML::BuildComplexSignal( const xercesc::DOMElement* pPreambleChild, const string& strSourceFilename, const Atlas::AtlasSourceStatement::eSourceType eSourceType, map< string, pair< const Atlas::AtlasSourceStatement::eSourceType, vector< const xercesc::DOMElement* > > >& mapComplexSignals )
{
	vector< const DOMElement* >* pvectComplexSignals = 0;

	if ( 0 != pPreambleChild )
	{
		pPreambleChild = pPreambleChild->getFirstElementChild( );

		while ( 0 != pPreambleChild )
		{
			string strAIXMLtagName;
	
			AIXMLHelper::GetXercesString( pPreambleChild->getTagName( ), strAIXMLtagName );
	
			if ( m_arrayXMLKeyWords[ eDefineStatementsElement ] == strAIXMLtagName )
			{
				const DOMElement* pDefineChild = pPreambleChild->getFirstElementChild( );
	
				while ( 0 != pDefineChild )
				{
					AIXMLHelper::GetXercesString( pDefineChild->getTagName( ), strAIXMLtagName );
			
					if ( m_arrayXMLKeyWords[ eComplexSignalGroupElement ] == strAIXMLtagName )
					{
						if ( 0 == pvectComplexSignals )
						{
							pair< map< string, pair< const Atlas::AtlasSourceStatement::eSourceType, vector< const DOMElement* > > >::iterator, bool > prRet = mapComplexSignals.insert( make_pair( strSourceFilename, make_pair( eSourceType, vector< const DOMElement* >( ) ) ) );
	
							if ( prRet.second )
							{
								pvectComplexSignals = &( prRet.first->second.second );
							}
						}
	
						if ( 0 != pvectComplexSignals )
						{
							pvectComplexSignals->push_back( pDefineChild );
						}
					}
	
					pDefineChild = pDefineChild->getNextElementSibling( );
				}
			}
	
			pPreambleChild = pPreambleChild->getNextElementSibling( );
		}
	}
}

void AIXML::BuildIncludeFileComplexSignals( const xercesc::DOMElement* pIncludes, map< string, pair< const Atlas::AtlasSourceStatement::eSourceType, vector< const DOMElement* > > >& mapComplexSignals )
{
	if ( 0 != pIncludes )
	{
		const xercesc::DOMElement* pAIXMLvalue = pIncludes->getFirstElementChild( );
	
		if ( 0 == pAIXMLvalue )
		{
			throw Exception( Exception::eFailedToGetChildNodes, __FILE__, __FUNCTION__, __LINE__ );
		}
	
		while ( 0 != pAIXMLvalue )
		{
			string strAIXMLtagName;
	
			AIXMLHelper::GetXercesString( pAIXMLvalue->getTagName( ), strAIXMLtagName );
	
			if ( m_arrayXMLKeyWords[ eIncludeGroupElement ] == strAIXMLtagName )
			{
				const xercesc::DOMElement* pModule = pAIXMLvalue->getFirstElementChild( );

				if ( 0 != pModule )
				{
					AIXMLHelper::GetXercesString( pModule->getTagName( ), strAIXMLtagName );

					if ( strAIXMLtagName == m_arrayXMLKeyWords[ eIncludeAtlasModuleElement ] )
					{
						const xercesc::DOMElement* pModuleChild = pModule->getFirstElementChild( );
						string strFilename;

						if ( 0 != pModuleChild )
						{
							const DOMAttr* pAttr = pModuleChild->getAttributeNode( AIXMLHelper::GetWString( m_arrayXMLKeyWords[ eNameAttribute ] ).c_str( ) );
		
							if ( 0 != pAttr )
							{
								AIXMLHelper::GetXercesString( pAttr->getValue( ), strFilename );

								VerifyIfExtension( strFilename );

								strFilename = AIXMLHelper::StripPath( strFilename );
							}
						}

						pModule = pModule->getNextElementSibling( );

						if ( 0 != pModule )
						{
							const xercesc::DOMElement* pPreamble = AIXMLHelper::FindElementPath( pModule, m_arrayXPath[ eIncludeAtlasModulePreamblePath ], false );

							if ( 0 != pPreamble )
							{
								BuildComplexSignal( pPreamble, strFilename, Atlas::AtlasSourceStatement::eAtlasModule, mapComplexSignals );
							}
						}
					}
				}
			}
	
			pAIXMLvalue = pAIXMLvalue->getNextElementSibling( );
		}
	}
}

void AIXML::InitComplexSignals( map< string, pair< const Atlas::AtlasSourceStatement::eSourceType, vector< const xercesc::DOMElement* > > >& mapComplexSignals )
{
	map< string, pair< const Atlas::AtlasSourceStatement::eSourceType, vector< const xercesc::DOMElement* > > >::const_iterator it = mapComplexSignals.begin( );
	const map< string, pair< const Atlas::AtlasSourceStatement::eSourceType, vector< const xercesc::DOMElement* > > >::const_iterator itEnd = mapComplexSignals.end( );
	map< string, vector< AtlasComplexSignal* >* >::const_iterator itComplexSignal;
	const map< string, vector< AtlasComplexSignal* >* >::const_iterator itComplexSignalEnd = m_mapComplexSignals.end( );

	while ( itEnd != it )
	{
		const string& strFilename = it->first;
		const Atlas::AtlasSourceStatement::eSourceType eSourceType = it->second.first;
		vector< const xercesc::DOMElement* > vectDOMComplexSignals = it->second.second;
		const unsigned int uiDOMSize = vectDOMComplexSignals.size( );
		AtlasComplexSignal* pComplexSignal = 0;
		auto_ptr< AtlasComplexSignal > autoptr;

		for ( unsigned int ui = 0; ui < uiDOMSize; ++ui )
		{
			try
			{
				pComplexSignal = new AtlasComplexSignal( GetRequires( ( Atlas::AtlasSourceStatement::eAtlasSegment == eSourceType ? m_strPrimaryAtlasFilename : strFilename ) ) );
			}
			catch ( ... )
			{
				throw Exception( Exception::eFailedToAllocateMemoryForComplexSignalObject, __FILE__, __FUNCTION__, __LINE__ );
			}

			autoptr.reset( pComplexSignal );

			autoptr->InitFromXML( vectDOMComplexSignals[ ui ], eSourceType, strFilename );

			if ( AtlasStatement::eExternal != autoptr->m_eScope )
			{
				itComplexSignal = m_mapComplexSignals.find( autoptr->m_strSignalName );
		
				if ( itComplexSignalEnd == itComplexSignal )
				{
					vector< AtlasComplexSignal* >* pvectStatements = 0;
						
					try
					{
						pvectStatements = new vector< AtlasComplexSignal* >( );
					}
					catch ( ... )
					{
						throw Exception( Exception::eFailedToCreateVectorObject, __FILE__, __FUNCTION__, __LINE__ );
					}
	
					m_mapComplexSignals.insert( make_pair( autoptr->m_strSignalName, pvectStatements ) );
		
					pvectStatements->push_back( autoptr.release( ) );
				}
				else
				{
					itComplexSignal->second->push_back( autoptr.release( ) );
				}
			}
			else
			{
				delete autoptr.release( );
			}
		}

		++it;
	}

	if ( m_mapComplexSignals.size( ) > 0 )
	{
		itComplexSignal = m_mapComplexSignals.begin( );
	
		while ( itComplexSignalEnd != itComplexSignal )
		{
			vector< AtlasComplexSignal* >* pvect = itComplexSignal->second;
			const unsigned int uiSize = pvect->size( );

			for ( unsigned int ui = 0; ui < uiSize; ++ui )
			{
				AtlasComplexSignal* pComplexSignal = pvect->at( ui );

				pComplexSignal->Process( m_pMergedLookup );
			}

			++itComplexSignal;
		}

		m_AtlasSignalInfo.SetComplexSignals( &m_mapComplexSignals );
	}
}

void AIXML::BuildRegularStatements( void )
{
	BuildConditionalStatements( Atlas::eIF_THEN );
	BuildConditionalStatements( Atlas::eELSE );
	BuildConditionalStatements( Atlas::eWHILE_THEN );
	BuildConditionalStatements( Atlas::eFOR_THEN );

	BuildSignalOrientedVerb( Atlas::eAPPLY,			XML::enApply,		false );
	BuildSignalOrientedVerb( Atlas::eMEASURE,		XML::enMeasure,		true );
	BuildSignalOrientedVerb( Atlas::eMONITOR,		XML::enMonitor,		true );
	BuildSignalOrientedVerb( Atlas::eVERIFY,		XML::enVerify,		true );
	BuildSignalOrientedVerb( Atlas::eSETUP,			XML::enSetup,		true );
	BuildSignalOrientedVerb( Atlas::eREAD,			XML::enRead,		true );
	BuildSignalOrientedVerb( Atlas::eINITIATE,		XML::enInitiate,	true );
	BuildSignalOrientedVerb( Atlas::eREMOVE,		XML::enRemove,		true );
	BuildSignalOrientedVerb( Atlas::eFETCH,			XML::enFetch,		true );
	BuildSignalOrientedVerb( Atlas::eCONNECT,		XML::enConnect,		true );
	BuildSignalOrientedVerb( Atlas::eDISCONNECT,	XML::enDisconnect,	true );
	BuildSignalOrientedVerb( Atlas::eARM,			XML::enArm,			true );
	BuildSignalOrientedVerb( Atlas::eCHANGE,		XML::enChange,		true );
	BuildSignalOrientedVerb( Atlas::eRESET,			XML::enReset,		true );
	BuildSignalOrientedVerb( Atlas::eOPEN,			XML::enOpen,		true );
	BuildSignalOrientedVerb( Atlas::eCLOSE,			XML::enClose,		true );

	BuildCalculates( );

	BuildFills( );

	BuildLeaveResumes( );

	BuildStatements< AtlasCompare >( Atlas::eCOMPARE );
	BuildStatements< AtlasDelay >( Atlas::eDELAY );
	BuildStatements< AtlasWaitFor >( Atlas::eWAIT_FOR );
	BuildStatements< AtlasEnable >( Atlas::eENABLE );
	BuildStatements< AtlasDisable >( Atlas::eDISABLE );
	BuildStatements< AtlasPrepare >( Atlas::ePREPARE );
	BuildStatements< AtlasExecute >( Atlas::eEXECUTE );
	BuildStatements< AtlasFinish >( Atlas::eFINISH );
	BuildStatements< AtlasGoto >( Atlas::eGO_TO );

	BuildLeaveStatements( Atlas::eLEAVE_PROCEDURE );
	BuildLeaveStatements( Atlas::eLEAVE_IF );
	BuildLeaveStatements( Atlas::eLEAVE_FOR );
	BuildLeaveStatements( Atlas::eLEAVE_WHILE );
}

void AIXML::BuildSignalOrientedVerb( const Atlas::eAtlasStatement eStatement, const XML::ElementName eVerbElementName, const bool bHasMeasureCharacteristics )
{
	const DOMStatements* pDOMStatements = 0;
	vector< AtlasStatement* >* pvectStatements = 0;
	const unsigned int uiStatementCount = CreateStatementVector( eStatement, &pDOMStatements, &pvectStatements );

	if ( uiStatementCount > 0 )
	{
		const bool bIsReadVerb = ( Atlas::eREAD == eStatement );
		vector< unsigned int > vectReadDates;

		for ( unsigned int ui = 0; ui < uiStatementCount; ++ui )
		{
			const StatementMetadata* pdata = pDOMStatements->m_vectStatements[ ui ];

			AtlasActionSignalVerb* pAtlasActionSignalVerb = 0;
				
			try
			{
				pAtlasActionSignalVerb = new AtlasActionSignalVerb( eStatement, 
								eVerbElementName, 
								bHasMeasureCharacteristics, 
								GetRequires( ( Atlas::AtlasSourceStatement::eAtlasSegment == pdata->m_eSourceType ? m_strPrimaryAtlasFilename : pdata->m_strFilename ) ) );
			}
			catch ( ... )
			{
				throw Exception( Exception::eFailedToAllocateMemoryForNewStatementObject, __FILE__, __FUNCTION__, __LINE__ );
			}

			pvectStatements->push_back( pAtlasActionSignalVerb );

			pAtlasActionSignalVerb->InitFromXML( pdata );

			pAtlasActionSignalVerb->Process( m_pMergedLookup );

			if ( bIsReadVerb )
			{
				if ( 0 != pAtlasActionSignalVerb->m_pReadDate )
				{
					vectReadDates.push_back( ui );
				}
			}
		}
	
		if ( bIsReadVerb )
		{
			const int iSize = ( int ) vectReadDates.size( );

			if ( iSize > 0 )
			{
				vector< AtlasStatement* >* pvectReadDates = 0;
					
				try
				{
					pvectReadDates = new vector< AtlasStatement* >( );
				}
				catch ( ... )
				{
					throw Exception( Exception::eFailedToCreateVectorObject, __FILE__, __FUNCTION__, __LINE__ );
				}
		
				m_mapStatements.insert( make_pair( Atlas::eREAD_DATETIME, pvectReadDates ) );

				const vector< AtlasStatement* >::const_iterator itBeginDate( pvectReadDates->begin( ) );
				const vector< AtlasStatement* >::const_iterator itBeginRead( pvectStatements->begin( ) );

				for ( int i = ( iSize - 1 ); i > -1; --i )
				{
					pvectReadDates->insert( itBeginDate, pvectStatements->at( vectReadDates[ i ] ) );
					pvectStatements->erase( itBeginRead + vectReadDates[ i ] );
				}

				if ( 0 == pvectStatements->size( ) )
				{
					const map< const Atlas::eAtlasStatement, vector< AtlasStatement* >* >::const_iterator itStatement = m_mapStatements.find( eStatement );
				
					if ( m_mapStatements.end( ) != itStatement )
					{
						delete pvectStatements;

						m_mapStatements.erase( itStatement );
					}

					const map< Atlas::eAtlasStatement, DOMStatements* >::const_iterator itDOMStatement = m_mapDOMElementStatements.find( Atlas::eREAD );
				
					if ( m_mapDOMElementStatements.end( ) != itDOMStatement )
					{
						m_mapDOMElementStatements.insert( make_pair( Atlas::eREAD_DATETIME, itDOMStatement->second ) );

						m_mapDOMElementStatements.erase( itDOMStatement );
					}
				}
			}
		}
	}
}

void AIXML::BuildCalculates( void )
{
	const DOMStatements* pDOMStatements = 0;
	vector< AtlasStatement* >* pvectCalculates = 0;
	const unsigned int uiCalculateCount = CreateStatementVector( Atlas::eCALCULATE, &pDOMStatements, &pvectCalculates );

	if ( uiCalculateCount > 0 )
	{
		vector< AtlasStatement* > vectNestedCalculates;

		for ( unsigned int ui = 0; ui < uiCalculateCount; ++ui )
		{
			const StatementMetadata* pdata = pDOMStatements->m_vectStatements[ ui ];

			AtlasCalculate* pCalculate = 0;

			try
			{
				pCalculate = new AtlasCalculate;
			}
			catch ( ... )
			{
				throw Exception( Exception::eFailedToAllocateMemoryForAtlasCalculateObject, __FILE__, __FUNCTION__, __LINE__ );
			}

			pvectCalculates->push_back( pCalculate );

			pCalculate->InitFromXML( pdata, vectNestedCalculates );
			pCalculate->Process( m_pMergedLookup );

			const unsigned int uiNestedCalculates = vectNestedCalculates.size( );

			if ( uiNestedCalculates > 0 )
			{
				for ( unsigned int ui = 0; ui < uiNestedCalculates; ++ui )
				{
					AtlasCalculate*	pNestedCalculate = ( AtlasCalculate* ) vectNestedCalculates[ ui ];

					pNestedCalculate->m_uiNestId = GetNextId( );

					pvectCalculates->push_back( pNestedCalculate );

					pNestedCalculate->Process( m_pMergedLookup );
				}

				vectNestedCalculates.clear( );
			}
		}
	}
}

void AIXML::BuildCompares( void )
{
	const DOMStatements* pDOMStatements = GetDOMStatements( Atlas::eCOMPARE );

	if ( 0 != pDOMStatements )
	{
		unsigned int uiStatementCount = pDOMStatements->m_vectStatements.size( );

		if ( uiStatementCount > 0 )
		{
			vector< AtlasStatement* >* pvectStatements = 0;
				
			try
			{
				pvectStatements = new vector< AtlasStatement* >( );
			}
			catch ( ... )
			{
				throw Exception( Exception::eFailedToCreateVectorObject, __FILE__, __FUNCTION__, __LINE__ );
			}

			pvectStatements->reserve( uiStatementCount );

			m_mapStatements.insert( make_pair( Atlas::eCOMPARE, pvectStatements ) );

			for ( unsigned int ui = 0; ui < uiStatementCount; ++ui )
			{
				const StatementMetadata* pdata = pDOMStatements->m_vectStatements[ ui ];

				AtlasCompare* pStatement = 0;
				
				try
				{
					pStatement = new AtlasCompare;
				}
				catch ( ... )
				{
					throw Exception( Exception::eFailedToAllocateMemoryForAtlasStatementObject, __FILE__, __FUNCTION__, __LINE__ );
				}

				pvectStatements->push_back( pStatement );

				pStatement->InitFromXML( pdata );
			}
		}
	}

	vector< AtlasStatement* >* pVect = GetStatementVector( Atlas::eCOMPARE );

	if ( 0 != pVect )
	{
		const unsigned int uiStatements = pVect->size( );

		for ( unsigned int ui = 0; ui < uiStatements; ++ui )
		{
			pVect->at( ui )->Process( m_pMergedLookup );
		}
	}
}

void AIXML::BuildFills( void )
{
	const DOMStatements* pDOMStatements = 0;
	vector< AtlasStatement* >* pvectFills = 0;
	const unsigned int uiFillCount = CreateStatementVector( Atlas::eFILL, &pDOMStatements, &pvectFills );

	if ( uiFillCount > 0 )
	{
		vector< AtlasStatement* > vectNestedFills;
		map< string, vector< AtlasStatement* >* >::const_iterator it;
		const map< string, map< unsigned int, AtlasStatement* >* >::const_iterator itEnd = m_mapProcedures.end( );
		const vector< pair< string, Atlas::AtlasSourceStatement::eSourceType > >* pvectAtlasSourceFiles = 0;
		const AtlasProcedure* pProcedure = 0;

		if ( m_bHasSegments )
		{
			pvectAtlasSourceFiles = &m_vectAtlasSourceFiles;
		}

		for ( unsigned int ui = 0; ui < uiFillCount; ++ui )
		{
			const StatementMetadata* pdata = pDOMStatements->m_vectStatements[ ui ];

			AtlasFill* pFill = 0;
				
			try
			{
				pFill = new AtlasFill;
			}
			catch ( ... )
			{
				throw Exception( Exception::eFailedToAllocateMemoryForAtlasFillObject, __FILE__, __FUNCTION__, __LINE__ );
			}

			pvectFills->push_back( pFill );

			pFill->InitFromXML( pdata, vectNestedFills );

			pProcedure = ( AtlasProcedure* ) GetProcedure( pFill->m_strParentProcedureName, pFill->m_uiParentProcedureId );
			pFill->Process( &m_mapDeclares, pProcedure, pvectAtlasSourceFiles, m_pMergedLookup );

			const unsigned int uiNestedFills = vectNestedFills.size( );

			if ( uiNestedFills > 0 )
			{
				for ( unsigned int ui = 0; ui < uiNestedFills; ++ui )
				{
					pFill = ( AtlasFill* ) vectNestedFills[ ui ];

					pFill->m_uiNestId = GetNextId( );

					pvectFills->push_back( pFill );

					pProcedure = ( AtlasProcedure* ) GetProcedure( pFill->m_strParentProcedureName, pFill->m_uiParentProcedureId );
					pFill->Process( &m_mapDeclares, pProcedure, pvectAtlasSourceFiles, m_pMergedLookup );
				}

				vectNestedFills.clear( );
			}
		}
	}
}

void AIXML::BuildLeaveResumes( void )
{
	const DOMStatements* pDOMStatements = 0;
	vector< AtlasStatement* >* pvectLeaves = 0;
	vector< AtlasStatement* >* pvectResumes = 0;
	const unsigned int uiLeaveCount = CreateStatementVector( Atlas::eLEAVE_ATLAS, &pDOMStatements, &pvectLeaves );

	if ( uiLeaveCount > 0 )
	{
		try
		{
			pvectResumes = new vector< AtlasStatement* >( );
		}
		catch ( ... )
		{
			throw Exception( Exception::eFailedToCreateVectorObject, __FILE__, __FUNCTION__, __LINE__ );
		}

		pvectResumes->reserve( uiLeaveCount );

		m_mapStatements.insert( make_pair( Atlas::eRESUME_ATLAS, pvectResumes ) );

		for ( unsigned int ui = 0; ui < uiLeaveCount; ++ui )
		{
			const StatementMetadata* pdata = pDOMStatements->m_vectStatements[ ui ];

			for ( unsigned int ui2 = 0; ui2 < 2; ++ui2 )
			{
				AtlasLeaveResume* pStatement = 0;
					
				try
				{
					pStatement = new AtlasLeaveResume( 0 == ui2 ? Atlas::eLEAVE_ATLAS : Atlas::eRESUME_ATLAS );
				}
				catch ( ... )
				{
					throw Exception( Exception::eFailedToAllocateMemoryForAtlasStatementObject, __FILE__, __FUNCTION__, __LINE__ );
				}

				( 0 == ui2 ? pvectLeaves : pvectResumes )->push_back( pStatement );
	
				pStatement->InitFromXML( pdata );
				pStatement->Process( m_pMergedLookup );
			}
		}
	}
}

void AIXML::BuildPerforms( void )
{
	const DOMStatements* pDOMStatements = GetDOMStatements( Atlas::ePERFORM );

	if ( 0 != pDOMStatements )
	{
		unsigned int uiPerformCount = pDOMStatements->m_vectStatements.size( );

		if ( uiPerformCount > 0 )
		{
			vector< AtlasStatement* >* pvectStatements = 0;
			unsigned int uiStartMain = 0;
			unsigned int uiEndMain = 0;

			try
			{
				pvectStatements = new vector< AtlasStatement* >( );
			}
			catch ( ... )
			{
				throw Exception( Exception::eFailedToCreateVectorObject, __FILE__, __FUNCTION__, __LINE__ );
			}

			pvectStatements->reserve( uiPerformCount );
	
			m_mapStatements.insert( make_pair( Atlas::ePERFORM, pvectStatements ) );

			for ( unsigned int ui = 0; ui < uiPerformCount; ++ui )
			{
				const StatementMetadata* pdata = pDOMStatements->m_vectStatements[ ui ];

				AtlasPerform* pPerform = 0;
					
				try
				{
					pPerform = new AtlasPerform;
				}
				catch ( ... )
				{
					throw Exception( Exception::eFailedToAllocateMemoryForNewStatementObject, __FILE__, __FUNCTION__, __LINE__ );
				}

				pvectStatements->push_back( pPerform );

				pPerform->InitFromXML( pdata );
			}

			uiPerformCount = pvectStatements->size( );

			if ( uiPerformCount > 0 )
			{
				for ( unsigned int ui = 0; ui < uiPerformCount; ++ui )
				{
					AtlasStatement* pStatement = pvectStatements->at( ui );
	
					if ( 0 == uiStartMain )
					{
						if ( AtlasStatement::m_strMAIN_PROC_NAME == pStatement->GetParentProcedureName( ) )
						{
							uiStartMain = ui;
						}
					}
					else if ( 0 == uiEndMain )
					{
						if ( AtlasStatement::m_strMAIN_PROC_NAME != pStatement->GetParentProcedureName( ) )
						{
							uiEndMain = ui;
						}
					}
	
					pStatement->Process( m_pMergedLookup );
				}
			}
	
			m_uiProgTreeStartMain = uiStartMain;
			m_uiProgTreeEndMain = uiEndMain;
	
			if ( m_uiProgTreeStartMain > 0 )
			{
				if ( 0 == m_uiProgTreeEndMain )
				{
					m_uiProgTreeEndMain = ( uiPerformCount - 1 );
				}
			}
		}
	}
}

void AIXML::BuildProgramTree( const bool bBuildProgramTree )
{
	if ( bBuildProgramTree )
	{
		vector< AtlasStatement* >* pvectPerforms = GetStatementVector( Atlas::ePERFORM );

		if ( 0 != pvectPerforms )
		{
			const unsigned int uiSize = pvectPerforms->size( );
		
			if ( uiSize > 0 )
			{
				map< string, pair< string, unsigned int > > mapProcsCalled;
				map< string, vector< AtlasStatement* > > mapProcCalls;
				pair< map< string, vector< AtlasStatement* > >::iterator, bool > prRet1 = mapProcCalls.insert( make_pair( AtlasStatement::m_strMAIN_PROC_NAME, vector< AtlasStatement* >( ) ) );
				vector< AtlasStatement* >& vectProcCalls1 = prRet1.first->second;
		
				for ( unsigned int ui = m_uiProgTreeStartMain; ui <= m_uiProgTreeEndMain; ++ui )
				{
					vectProcCalls1.push_back( pvectPerforms->at( ui ) );
				}
		
				if ( m_uiProgTreeStartMain > 0 )
				{
					for ( unsigned int ui = 0; ui < m_uiProgTreeStartMain; ++ui )
					{
						const string strParentProcName( pvectPerforms->at( ui )->GetParentProcedureName( ) );
		
						pair< map< string, vector< AtlasStatement* > >::iterator, bool > prRet2 = mapProcCalls.insert( make_pair( strParentProcName, vector< AtlasStatement* >( ) ) );
						vector< AtlasStatement* >& vectProcCalls2 = prRet2.first->second;
		
						while ( strParentProcName == pvectPerforms->at( ui )->GetParentProcedureName( ) && ( ui < m_uiProgTreeStartMain ) )
						{
							vectProcCalls2.push_back( pvectPerforms->at( ui ) );
							++ui;
		
							if ( ui == m_uiProgTreeStartMain )
							{
								break;
							}
						}
		
						if ( ui < m_uiProgTreeStartMain )
						{
							--ui;
						}
					}
				}
		
				if ( ( m_uiProgTreeEndMain + 1 ) < uiSize )
				{
					for ( unsigned int ui = ( m_uiProgTreeEndMain + 1 ); ui < uiSize; ++ui )
					{
						const string strParentProcName( pvectPerforms->at( ui )->GetParentProcedureName( ) );
		
						pair< map< string, vector< AtlasStatement* > >::iterator, bool > prRet3 = mapProcCalls.insert( make_pair( strParentProcName, vector< AtlasStatement* >( ) ) );
						vector< AtlasStatement* >& vectProcCalls3 = prRet3.first->second;
		
						while ( strParentProcName == pvectPerforms->at( ui )->GetParentProcedureName( ) && ( ui < uiSize ) )
						{
							vectProcCalls3.push_back( pvectPerforms->at( ui ) );
							++ui;
		
							if ( ui == uiSize )
							{
								break;
							}
						}
		
						if ( ui < uiSize )
						{
							--ui;
						}
					}
				}
		
				m_ProgramTree.CreateTree( ProgamTree::iterator( ), mapProcCalls, mapProcsCalled );

				if ( mapProcsCalled.size( ) > 0 )
				{
					map< string, pair< string, unsigned int > >::const_iterator it = mapProcsCalled.begin( );
					map< string, map< unsigned int, AtlasStatement* >* >::const_iterator itProcs = m_mapProcedures.find( AtlasStatement::m_strMAIN_PROC_NAME );
					const map< string, pair< string, unsigned int > >::const_iterator itEnd = mapProcsCalled.end( );

					// Adding in the main procedural structure
					if ( m_mapProcedures.end( ) != itProcs )
					{
						const map< unsigned int, AtlasStatement* >::const_iterator itProc = itProcs->second->find( m_uiMainProcId );

						if ( itProcs->second->end( ) != itProc )
						{
							( ( AtlasProcedure* ) itProc->second )->m_bUsed = true;
							++m_uiUsedProcCount;
						}
					}

					while ( itEnd != it )
					{
						itProcs = m_mapProcedures.find( it->second.first );

						if ( m_mapProcedures.end( ) != itProcs )
						{
							const map< unsigned int, AtlasStatement* >::const_iterator itProc = itProcs->second->find( it->second.second );

							if ( itProcs->second->end( ) != itProc )
							{
								( ( AtlasProcedure* ) itProc->second )->m_bUsed = true;
								++m_uiUsedProcCount;
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

						++it;
					}
				}
			}
		}
	}
}

void AIXML::BuildIncludeFileRequires( const xercesc::DOMElement* pAIXMLvalue )
{
	const DOMNodeList* pAIXML_NodeList = pAIXMLvalue->getChildNodes( );

	if ( 0 == pAIXML_NodeList )
	{
		throw Exception( Exception::eFailedToGetMappingChildNodes, __FILE__, __FUNCTION__, __LINE__ );
	}

	const XMLSize_t iMaxNodes = pAIXML_NodeList->getLength( );

	if ( 0 == iMaxNodes )
	{
		throw Exception( Exception::eInvalidNumberOfMappingNodes, __FILE__, __FUNCTION__, __LINE__ );
	}

	string strAIXMLtagName;
	string strFilename;

	for ( XMLSize_t iCurrentNode = 0; iCurrentNode < iMaxNodes; iCurrentNode++ )
	{
		pAIXMLvalue = ( const DOMElement* ) pAIXML_NodeList->item( iCurrentNode );

		if ( 0 == pAIXMLvalue )
		{
			throw Exception( Exception::eFailedToGetXercesNodeListItem, __FILE__, __FUNCTION__, __LINE__ );
		}

		if ( DOMNode::COMMENT_NODE == pAIXMLvalue->getNodeType( ) )
		{
			continue;
		}

		AIXMLHelper::GetXercesString( pAIXMLvalue->getTagName( ), strAIXMLtagName );

		if ( !strAIXMLtagName.empty( ) )
		{
			if ( m_arrayXMLKeyWords[ eIncludeGroupElement ] == strAIXMLtagName )
			{
				const DOMElement* pIncludeAtlasModule = pAIXMLvalue->getFirstElementChild( );

				if ( 0 != pIncludeAtlasModule )
				{
					AIXMLHelper::GetXercesString( pIncludeAtlasModule->getTagName( ), strAIXMLtagName );

					if ( m_arrayXMLKeyWords[ eIncludeAtlasModuleElement ] == strAIXMLtagName )
					{
						const DOMElement* pFilename = pIncludeAtlasModule->getFirstElementChild( );
		
						if ( 0 != pFilename )
						{
							AIXMLHelper::GetXercesString( pFilename->getTagName( ), strAIXMLtagName );

							if ( m_arrayXMLKeyWords[ eFilenameElement ] == strAIXMLtagName )
							{
								const DOMAttr* pAttr = pFilename->getAttributeNode( AIXMLHelper::GetWString( m_arrayXMLKeyWords[ eNameAttribute ] ).c_str( ) );
			
								if ( 0 != pAttr )
								{
									AIXMLHelper::GetXercesString( pAttr->getValue( ), strFilename );

									VerifyIfExtension( strFilename );

									strFilename = AIXMLHelper::StripPath( strFilename );
								}
							}
						}
					}
				}

				const DOMElement* pIncludeFileModule = AIXMLHelper::FindElementPath( pAIXMLvalue, m_arrayXPath[ eIncludeFileModuleRequirePath ], false );

				if ( 0 == pIncludeFileModule )
				{
					const DOMAttr* pAttr = pAIXMLvalue->getAttributeNode( AIXMLHelper::GetWString( m_arrayXMLKeyWords[ eNumberOfElementsAttribute ] ).c_str( ) );

					if ( 0 == pAttr )
					{
						throw Exception( Exception::eSourceXMLDoesNotContainNumberOfElementsAttribute, __FILE__, __FUNCTION__, __LINE__ );
					}

					const int iElements = AIXMLHelper::StringToNumber< int >( AIXMLHelper::GetXercesString( pAttr->getValue( ) ) );

					if ( 1 == iElements )
					{
						continue;
					}

					throw Exception( Exception::eCouldNotFindXMLPathForIncludeFile, __FILE__, __FUNCTION__, __LINE__, m_arrayXPath[ eIncludeFileLookupPath ] );
				}

				if ( strFilename.empty( ) )
				{
					throw Exception( Exception::eSourceXMLDoesNotContainNameAttributeThatContainsSourceFilename, __FILE__, __FUNCTION__, __LINE__ );
				}

				if ( !m_strAtlasFileExtension.empty( ) )
				{
					if ( string::npos == strFilename.find_last_of( AtlasStatement::m_strDot ) )
					{
						strFilename += AtlasStatement::m_strDot;
						strFilename += m_strAtlasFileExtension;
					}
				}

				BuildRequire( pIncludeFileModule, strFilename, Atlas::AtlasSourceStatement::eAtlasModule );

				strFilename.clear( );
			}
		}
	}
}

void AIXML::MergeRequires( void )
{
	const unsigned int uiStatements = m_vectRequires.size( );

	if ( 0 == uiStatements )
	{
		throw Exception( Exception::eNoStatementInformationCouldBeFound, __FILE__, __FUNCTION__, __LINE__ );
	}

	try
	{
		m_pMergedRequires = new AtlasRequires( *m_vectRequires[ 0 ] );
	}
	catch ( ... )
	{
		throw Exception( Exception::eFailedToAllocateMemoryForNewInstrumentsObject, __FILE__, __FUNCTION__, __LINE__ );
	}

	m_vectRequires[ 0 ]->InitId( );

	if ( uiStatements > 1 )
	{
		for ( unsigned int ui = 1; ui < uiStatements; ui++ )
		{
			if ( 0 != m_vectRequires[ ui ] )
			{
				( ( AtlasRequires* ) m_pMergedRequires )->Merge( *( ( AtlasRequires* ) m_vectRequires[ ui ] ) );
				m_vectRequires[ ui ]->InitId( );
			}
		}
	}
}

void AIXML::MergeInstruments( void )
{
	const AtlasStatement* pStatement;
	map< string, AtlasStatement* >::const_iterator it;

	( ( AtlasRequires* ) m_pMergedRequires )->ResetIterator( );
		
	while ( 0 != ( pStatement = ( ( AtlasRequires* ) m_pMergedRequires )->GetNext( ) ) ) 
	{
		if ( m_bExcludeUnused )
		{
			if ( !( ( AtlasRequire* ) pStatement )->IsUsed( ) )
			{
				pStatement = 0;
			}
		}

		if ( 0 != pStatement )
		{
			const string& strSystemName = ( ( AtlasSignalVerb* ) pStatement )->m_strSystemName;
	
			it = m_mapMergedInstruments.find( strSystemName );
	
			if ( m_mapMergedInstruments.end( ) == it )
			{
				AtlasRequire* pAtlasRequire = 0;
					
				try
				{
					pAtlasRequire = new AtlasRequire( pStatement->m_eAtlasStatement );
				}
				catch ( ... )
				{
					throw Exception( Exception::eFailedToAllocateMemoryForNewStatementObject, __FILE__, __FUNCTION__, __LINE__ );
				}
	
				m_mapMergedInstruments.insert( make_pair( strSystemName, pAtlasRequire ) );
	
				*pAtlasRequire = *pStatement;
	
				pAtlasRequire->m_bInstrument = true;
			}
			else
			{
				( ( AtlasRequire* ) it->second )->Merge( *( ( AtlasRequire* ) pStatement ), false );
			}
		}
	}
}

void AIXML::MergeSignals( void )
{
	const unsigned int uiRequires = m_vectRequires.size( );
	if ( uiRequires > 0 )
	{
		map< Atlas::eAtlasNoun, AtlasStatement* >::const_iterator itMS;
		const map< Atlas::eAtlasNoun, AtlasStatement* >::const_iterator itMSEnd = m_mapMergedSignals.end( );
		const AtlasStatement* pStatement;
	
		for ( unsigned int ui = 0; ui < uiRequires; ui++ )
		{
			const AtlasStatements* pStatements = m_vectRequires[ ui ];

			if ( 0 != pStatements )
			{
				( ( AtlasRequires* ) pStatements )->ResetIterator( );

				while ( 0 != ( pStatement = ( ( AtlasRequires* ) pStatements )->GetNext( ) ) ) 
				{
					if ( m_bExcludeUnused )
					{
						if ( !( ( AtlasRequire* ) pStatement )->IsUsed( ) )
						{
							pStatement = 0;
						}
					}
			
					if ( 0 != pStatement )
					{
						const Atlas::eAtlasNoun eNoun = ( ( AtlasRequire* ) pStatement )->GetAtlasNoun( );
	
						if ( Atlas::eUnknownAtlasNoun != eNoun )
						{
							itMS = m_mapMergedSignals.find( eNoun );
				
							if ( itMSEnd == itMS )
							{
								AtlasRequire* pRequire = 0;
									
								try
								{
									pRequire = new AtlasRequire( pStatement->m_eAtlasStatement );
								}
								catch ( ... )
								{
									throw Exception( Exception::eFailedToAllocateMemoryForNewStatementObject, __FILE__, __FUNCTION__, __LINE__ );
								}
					
								m_mapMergedSignals.insert( make_pair( eNoun, pRequire ) );
					
								*pRequire = *pStatement;
							}
							else
							{
								( ( AtlasRequire* ) itMS->second )->Merge( *( ( AtlasRequire* ) pStatement ), true );
							}
						}
					}
				}
			}
		}

		if ( m_mapMergedSignals.size( ) > 0 )
		{
			map< Atlas::eAtlasNoun, AtlasStatement* >::const_iterator it = m_mapMergedSignals.begin( );
			const map< Atlas::eAtlasNoun, AtlasStatement* >::const_iterator itEnd = m_mapMergedSignals.end( );
	
			while ( itEnd != it )
			{
				( ( AtlasRequire* ) it->second )->InitSignalInfo( &m_AtlasSignalInfo, AtlasRequire::eModifiers );
	
				++it;
			}
		}
	}
}

void AIXML::MergeClasses( void )
{
	const unsigned int uiRequires = m_vectRequires.size( );
	if ( uiRequires > 0 )
	{
		map< string, AtlasStatement* >::const_iterator itMC;
		const map< string, AtlasStatement* >::const_iterator itMCEnd = m_mapMergedInstrumentClasses.end( );
		const AtlasStatement* pStatement;
	
		for ( unsigned int ui = 0; ui < uiRequires; ui++ )
		{
			const AtlasStatements* pStatements = m_vectRequires[ ui ];

			if ( 0 != pStatements )
			{
				( ( AtlasRequires* ) pStatements )->ResetIterator( );

				while ( 0 != ( pStatement = ( ( AtlasRequires* ) pStatements )->GetNext( ) ) ) 
				{
					if ( m_bExcludeUnused )
					{
						if ( !( ( AtlasRequire* ) pStatement )->IsUsed( ) )
						{
							pStatement = 0;
						}
					}
			
					if ( 0 != pStatement )
					{
						const string strClassname( SpecificInstrument::GetInstrumentClass( SpecificInstrument::GetInstrumentClass( ( ( AtlasSignalVerb* ) pStatement )->m_eInstrument ) ) );
	
						if ( !strClassname.empty( ) )
						{
							itMC = m_mapMergedInstrumentClasses.find( strClassname );
				
							if ( itMCEnd == itMC )
							{
								AtlasRequire* pRequire = 0;
									
								try
								{
									pRequire = new AtlasRequire( pStatement->m_eAtlasStatement );
								}
								catch ( ... )
								{
									throw Exception( Exception::eFailedToAllocateMemoryForNewStatementObject, __FILE__, __FUNCTION__, __LINE__ );
								}
					
								m_mapMergedInstrumentClasses.insert( make_pair( strClassname, pRequire ) );
					
								*pRequire = *pStatement;
							}
							else
							{
								( ( AtlasRequire* ) itMC->second )->Merge( *( ( AtlasRequire* ) pStatement ), true );
							}
						}
					}
				}
			}
		}

		if ( m_mapMergedInstrumentClasses.size( ) > 0 )
		{
			map< string, AtlasStatement* >::const_iterator it = m_mapMergedInstrumentClasses.begin( );
			const map< string, AtlasStatement* >::const_iterator itEnd = m_mapMergedInstrumentClasses.end( );
	
			while ( itEnd != it )
			{
				( ( AtlasRequire* ) it->second )->InitSignalInfo( &m_AtlasSignalInfo, AtlasRequire::eInstruments );
	
				++it;
			}
		}
	}
}

void AIXML::BuildRequire( const DOMElement* pPreambleChild, const string& strSourceFilename, const Atlas::AtlasSourceStatement::eSourceType eSourceType )
{
	while ( 0 != pPreambleChild )
	{
		string strAIXMLtagName;

		AIXMLHelper::GetXercesString( pPreambleChild->getTagName( ), strAIXMLtagName );
	
		if ( m_arrayXMLKeyWords[ eRequireStatementsElement ] == strAIXMLtagName )
		{
			const DOMNodeList* pAIXML_NodeList = pPreambleChild->getChildNodes( );
		
			if ( 0 == pAIXML_NodeList )
			{
				throw Exception( Exception::eFailedToGetRequireChildNodes, __FILE__, __FUNCTION__, __LINE__ );
			}
		
			const XMLSize_t iMaxNodes = pAIXML_NodeList->getLength( );
		
			if ( 0 == iMaxNodes )
			{
				throw Exception( Exception::eInvalidNumberOfRequireNodes, __FILE__, __FUNCTION__, __LINE__ );
			}
		
			AtlasRequires* pAtlasStatements = 0;
				
			try
			{
				pAtlasStatements = new AtlasRequires( m_pMergedLookup );
			}
			catch ( ... )
			{
				throw Exception( Exception::eFailedToAllocateMemoryForNewInstrumentsObject, __FILE__, __FUNCTION__, __LINE__ );
			}
		
			m_vectRequires.push_back( pAtlasStatements );

			if ( m_mapRequiresByFilename.end( ) == m_mapRequiresByFilename.find( strSourceFilename ) )
			{
				m_mapRequiresByFilename.insert( make_pair( strSourceFilename, pAtlasStatements ) );
			}
			#if ( _DEBUG ) && ( WIN32 )
			else
			{
				DebugBreak( );
			}
			#endif
		
			for ( XMLSize_t iCurrentNode = 0; iCurrentNode < iMaxNodes; iCurrentNode++ )
			{
				const DOMElement* pRequireElement = ( const DOMElement* ) pAIXML_NodeList->item( iCurrentNode );
		
				if ( 0 == pRequireElement )
				{
					throw Exception( Exception::eFailedToGetXercesNodeListItem, __FILE__, __FUNCTION__, __LINE__ );
				}
		
				if ( DOMNode::COMMENT_NODE == pRequireElement->getNodeType( ) )
				{
					continue;
				}
		
				AIXMLHelper::GetXercesString( pRequireElement->getTagName( ), strAIXMLtagName );
		
				if ( !strAIXMLtagName.empty( ) )
				{
					if ( m_arrayXMLKeyWords[ eRequireElement ] == strAIXMLtagName )
					{
						ProcessRequire( pRequireElement, pAtlasStatements, strSourceFilename, eSourceType );
					}
				}
			}
		
			pAtlasStatements->Process( );
		}

		pPreambleChild = pPreambleChild->getNextElementSibling( );
	}
}

void AIXML::ProcessRequire( const DOMElement* pAIXMLvalue, AtlasStatements* pAtlasStatements, const string& strSourceFilename, const Atlas::AtlasSourceStatement::eSourceType eSourceType )
{
	string strStatementNumber;
	unsigned int uiLineNumber = 0;
	unsigned int uiId = 0;
	unsigned int uiCommentId = AtlasStatement::GetCommentId( pAIXMLvalue );

	const DOMAttr* pIdAttr = pAIXMLvalue->getAttributeNode( AIXMLHelper::GetWString( m_arrayXMLKeyWords[ eIdAttribute ] ).c_str( ) );
	if ( 0 != pIdAttr )
	{
		uiId = AIXMLHelper::StringToNumber< unsigned int >( AIXMLHelper::GetXercesString( pIdAttr->getValue( ) ) );
	}

	const DOMAttr* pLineAttr = pAIXMLvalue->getAttributeNode( AIXMLHelper::GetWString( m_arrayXMLKeyWords[ eLineAttribute ] ).c_str( ) );
	if ( 0 != pLineAttr )
	{
		uiLineNumber = AIXMLHelper::StringToNumber< unsigned int >( AIXMLHelper::GetXercesString( pLineAttr->getValue( ) ) );
	}

	if ( 0 == uiLineNumber )
	{
		throw Exception( Exception::eSourceXMLDoesNotContainNameAttributeThatContainsIncludeSourceLineNumber, __FILE__, __FUNCTION__, __LINE__ );
	}

	const DOMAttr* pStatementAttr = pAIXMLvalue->getAttributeNode( AIXMLHelper::GetWString( m_arrayXMLKeyWords[ eStatementNumberAttribute ] ).c_str( ) );
	if ( 0 != pStatementAttr )
	{
		strStatementNumber = AIXMLHelper::GetXercesString( pStatementAttr->getValue( ) );
	}

	if ( strStatementNumber.empty( ) )
	{
		throw Exception( Exception::eSourceXMLDoesNotContainNameAttributeThatContainsIncludeSourceStatementNumber, __FILE__, __FUNCTION__, __LINE__ );
	}

	const DOMNodeList* pAIXML_NodeList = pAIXMLvalue->getChildNodes( );

	if ( 0 == pAIXML_NodeList )
	{
		throw Exception( Exception::eFailedToGetRequireChildNodes, __FILE__, __FUNCTION__, __LINE__ );
	}

	const XMLSize_t iMaxNodes = pAIXML_NodeList->getLength( );

	if ( 0 == iMaxNodes )
	{
		throw Exception( Exception::eInvalidNumberOfRequireNodes, __FILE__, __FUNCTION__, __LINE__ );
	}

	string strAIXMLtagName;

	for ( XMLSize_t iCurrentNode = 0; iCurrentNode < iMaxNodes; iCurrentNode++ )
	{
		pAIXMLvalue = ( const DOMElement* ) pAIXML_NodeList->item( iCurrentNode );

		if ( 0 == pAIXMLvalue )
		{
			throw Exception( Exception::eFailedToGetXercesNodeListItem, __FILE__, __FUNCTION__, __LINE__ );
		}

		if ( DOMNode::COMMENT_NODE == pAIXMLvalue->getNodeType( ) )
		{
			continue;
		}

		AIXMLHelper::GetXercesString( pAIXMLvalue->getTagName( ), strAIXMLtagName );

		if ( !strAIXMLtagName.empty( ) )
		{
			if ( m_arrayXMLKeyWords[ eArgumentsElement ] == strAIXMLtagName )
			{
				Atlas::AtlasSourceStatement requireStatement( eSourceType, Atlas::eREQUIRE, strSourceFilename, strStatementNumber, uiLineNumber, uiId, uiCommentId );

				CreateRequire( pAIXMLvalue, pAtlasStatements, requireStatement );
			}
		}
	}
}

void AIXML::CreateRequire( const DOMElement* pAIXMLvalue, AtlasStatements* pAtlasStatements, const Atlas::AtlasSourceStatement& requireStatement )
{
	const DOMNodeList* pAIXML_NodeList = pAIXMLvalue->getChildNodes( );

	if ( 0 == pAIXML_NodeList )
	{
		throw Exception( Exception::eFailedToGetRequireChildNodes, __FILE__, __FUNCTION__, __LINE__ );
	}

	const XMLSize_t iMaxNodes = pAIXML_NodeList->getLength( );

	if ( 0 == iMaxNodes )
	{
		throw Exception( Exception::eInvalidNumberOfRequireNodes, __FILE__, __FUNCTION__, __LINE__ );
	}

	AtlasStatement* pAtlasStatement = 0;
	string strAIXMLtagName;

	for ( XMLSize_t iCurrentNode = 0; iCurrentNode < iMaxNodes; iCurrentNode++ )
	{
		pAIXMLvalue = ( const DOMElement* ) pAIXML_NodeList->item( iCurrentNode );

		if ( 0 == pAIXMLvalue )
		{
			throw Exception( Exception::eFailedToGetXercesNodeListItem, __FILE__, __FUNCTION__, __LINE__ );
		}

		if ( DOMNode::COMMENT_NODE == pAIXMLvalue->getNodeType( ) )
		{
			continue;
		}

		AIXMLHelper::GetXercesString( pAIXMLvalue->getTagName( ), strAIXMLtagName );

		if ( !strAIXMLtagName.empty( ) )
		{
			if ( m_arrayXMLKeyWords[ eArgumentElement ] == strAIXMLtagName )
			{
				if ( 0 == pAtlasStatement )
				{
					pAtlasStatement = pAtlasStatements->StatementFactory( pAIXMLvalue, Atlas::eREQUIRE );

					pAtlasStatement->m_vectAtlasSourceStatement.push_back( requireStatement );
				}
				else
				{
					pAtlasStatement->InitFromXML( pAIXMLvalue );
				}
			}
		}
	}
}

void AIXML::BuildLookup( const DOMElement* pAIXMLvalue )
{
	const DOMNodeList* pAIXML_NodeList = pAIXMLvalue->getChildNodes( );

	if ( 0 == pAIXML_NodeList )
	{
		throw Exception( Exception::eFailedToGetLookupChildNodes, __FILE__, __FUNCTION__, __LINE__ );
	}

	const XMLSize_t iMaxNodes = pAIXML_NodeList->getLength( );

	if ( 0 == iMaxNodes )
	{
		throw Exception( Exception::eInvalidNumberOfLookupNodes, __FILE__, __FUNCTION__, __LINE__ );
	}

	Lookup* pLookup = 0;
		
	try
	{
		pLookup = new Lookup( );
	}
	catch ( ... )
	{
		throw Exception( Exception::eFailedToAllocateMemoryForNewLookupObject, __FILE__, __FUNCTION__, __LINE__ );
	}

	m_vectLookups.push_back( pLookup );

	string strAIXMLtagName;

	for ( XMLSize_t iCurrentNode = 0; iCurrentNode < iMaxNodes; iCurrentNode++ )
	{
		pAIXMLvalue = ( const DOMElement* ) pAIXML_NodeList->item( iCurrentNode );

		if ( 0 == pAIXMLvalue )
		{
			throw Exception( Exception::eFailedToGetXercesNodeListItem, __FILE__, __FUNCTION__, __LINE__ );
		}

		if ( DOMNode::COMMENT_NODE == pAIXMLvalue->getNodeType( ) )
		{
			continue;
		}

		AIXMLHelper::GetXercesString( pAIXMLvalue->getTagName( ), strAIXMLtagName );

		if ( !strAIXMLtagName.empty( ) )
		{
			if ( m_arrayXMLKeyWords[ eSubfileElement ] == strAIXMLtagName )
			{
				pLookup->ProcessSubfile( pAIXMLvalue );
			}
		}
	}
}

void AIXML::BuildIncludeFileLookups( const DOMElement* pAIXMLvalue )
{
	const DOMNodeList* pAIXML_NodeList = pAIXMLvalue->getChildNodes( );

	if ( 0 == pAIXML_NodeList )
	{
		throw Exception( Exception::eFailedToGetMappingChildNodes, __FILE__, __FUNCTION__, __LINE__ );
	}

	const XMLSize_t iMaxNodes = pAIXML_NodeList->getLength( );

	if ( 0 == iMaxNodes )
	{
		throw Exception( Exception::eInvalidNumberOfMappingNodes, __FILE__, __FUNCTION__, __LINE__ );
	}

	string strAIXMLtagName;

	for ( XMLSize_t iCurrentNode = 0; iCurrentNode < iMaxNodes; iCurrentNode++ )
	{
		pAIXMLvalue = ( const DOMElement* ) pAIXML_NodeList->item( iCurrentNode );

		if ( 0 == pAIXMLvalue )
		{
			throw Exception( Exception::eFailedToGetXercesNodeListItem, __FILE__, __FUNCTION__, __LINE__ );
		}

		if ( DOMNode::COMMENT_NODE == pAIXMLvalue->getNodeType( ) )
		{
			continue;
		}

		AIXMLHelper::GetXercesString( pAIXMLvalue->getTagName( ), strAIXMLtagName );

		if ( !strAIXMLtagName.empty( ) )
		{
			if ( m_arrayXMLKeyWords[ eIncludeGroupElement ] == strAIXMLtagName )
			{
				const DOMElement* pIncludeFileLookup = AIXMLHelper::FindElementPath( pAIXMLvalue, m_arrayXPath[ eIncludeFileLookupPath ], false );

				if ( 0 == pIncludeFileLookup )
				{
					const DOMAttr* pAttr = pAIXMLvalue->getAttributeNode( AIXMLHelper::GetWString( m_arrayXMLKeyWords[ eNumberOfElementsAttribute ] ).c_str( ) );

					if ( 0 == pAttr )
					{
						throw Exception( Exception::eSourceXMLDoesNotContainNumberOfElementsAttribute, __FILE__, __FUNCTION__, __LINE__ );
					}

					const int iElements = AIXMLHelper::StringToNumber< int >( AIXMLHelper::GetXercesString( pAttr->getValue( ) ) );

					if ( 1 == iElements )
					{
						continue;
					}

					throw Exception( Exception::eCouldNotFindXMLPathForIncludeFile, __FILE__, __FUNCTION__, __LINE__, m_arrayXPath[ eIncludeFileLookupPath ] );
				}

				BuildLookup( pIncludeFileLookup );
			}
		}
	}
}

void AIXML::MergeLookups( void )
{
	const unsigned int uiLookups = m_vectLookups.size( );

	if ( 0 == uiLookups )
	{
		throw Exception( Exception::eNoLookupInformationCouldBeFound, __FILE__, __FUNCTION__, __LINE__ );
	}

	try
	{
		m_pMergedLookup = new Lookup( *m_vectLookups[ 0 ] );
	}
	catch ( ... )
	{
		throw Exception( Exception::eFailedToAllocateMemoryForNewLookupObject, __FILE__, __FUNCTION__, __LINE__ );
	}

	if ( uiLookups > 1 )
	{
		for ( unsigned int ui = 1; ui < uiLookups; ui++ )
		{
			if ( 0 != m_vectLookups[ ui ] )
			{
				m_pMergedLookup->Merge( *( m_vectLookups[ ui ] ) );
			}
		}
	}
}

void AIXML::PreliminaryGarbageCollect( void )
{
	if ( m_mapDOMElementStatements.size( ) > 0 )
	{
		map< Atlas::eAtlasStatement, DOMStatements* >::const_iterator it = m_mapDOMElementStatements.begin( );
		const map< Atlas::eAtlasStatement, DOMStatements* >::const_iterator itEnd = m_mapDOMElementStatements.end( );

		while ( itEnd != it )
		{
			delete it->second;

			++it;
		}

		m_mapDOMElementStatements.clear( );
	}

	if ( m_mapStatements.size( ) > 0 )
	{
		map< const Atlas::eAtlasStatement, vector< AtlasStatement* >* >::const_iterator it = m_mapStatements.begin( );
		const map< const Atlas::eAtlasStatement, vector< AtlasStatement* >* >::const_iterator itEnd = m_mapStatements.end( );

		while ( itEnd != it )
		{
			vector< AtlasStatement* >* pvect = it->second;

			if ( 0 != pvect )
			{
				const unsigned int uiSize = pvect->size( );

				for ( unsigned int ui = 0; ui < uiSize; ++ui )
				{
					pvect->at( ui )->GarbageCollectAtlasAttributes( );
				}
			}

			++it;
		}
	}

	const unsigned int uiRequires = m_vectRequires.size( );
	if ( uiRequires > 0 )
	{
		AtlasStatement* pStatement;
	
		for ( unsigned int ui = 0; ui < uiRequires; ui++ )
		{
			AtlasStatements* pStatements = m_vectRequires[ ui ];

			if ( 0 != pStatements )
			{
				( ( AtlasRequires* ) pStatements )->ResetIterator( );

				while ( 0 != ( pStatement = ( AtlasStatement* ) ( ( AtlasRequires* ) pStatements )->GetNext( ) ) ) 
				{
					pStatement->GarbageCollectAtlasAttributes( );
				}
			}
		}
	}

	m_setVirtualLabelsFoundInRequires.clear( );

	if ( 0 != m_parser )
	{
		delete m_parser;
		m_parser = 0;
	}

	if ( m_bXercesInit )
	{
		XMLPlatformUtils::Terminate( );
		m_bXercesInit = false;
	}
}

void AIXML::GarbageCollect( void )
{
	PreliminaryGarbageCollect( );

	if ( m_xmlOutFile.is_open( ) )
	{
		m_xmlOutFile.close( );
	}

	if ( 0 != m_pMergedLookup )
	{
		delete m_pMergedLookup;
		m_pMergedLookup = 0;
	}

	if ( 0 != m_pMergedRequires )
	{
		delete m_pMergedRequires;
		m_pMergedRequires = 0;
	}

	if ( m_mapMergedInstruments.size( ) > 0 )
	{
		map< string, AtlasStatement* >::const_iterator it = m_mapMergedInstruments.begin( );
		const map< string, AtlasStatement* >::const_iterator itEnd = m_mapMergedInstruments.end( );

		while ( itEnd != it )
		{
			delete it->second;
			++it;
		}

		m_mapMergedInstruments.clear( );
	}

	if ( m_mapMergedSignals.size( ) > 0 )
	{
		map< Atlas::eAtlasNoun, AtlasStatement* >::const_iterator it = m_mapMergedSignals.begin( );
		const map< Atlas::eAtlasNoun, AtlasStatement* >::const_iterator itEnd = m_mapMergedSignals.end( );

		while ( itEnd != it )
		{
			delete it->second;
			++it;
		}

		m_mapMergedSignals.clear( );
	}

	if ( m_mapMergedInstrumentClasses.size( ) > 0 )
	{
		map< string, AtlasStatement* >::const_iterator it = m_mapMergedInstrumentClasses.begin( );
		const map< string, AtlasStatement* >::const_iterator itEnd = m_mapMergedInstrumentClasses.end( );

		while ( itEnd != it )
		{
			delete it->second;
			++it;
		}

		m_mapMergedInstrumentClasses.clear( );
	}

	if ( m_mapProcedures.size( ) > 0 )
	{
		map< string, map< unsigned int, AtlasStatement* >* >::const_iterator it = m_mapProcedures.begin( );
		const map< string, map< unsigned int, AtlasStatement* >* >::const_iterator itEnd = m_mapProcedures.end( );

		while ( itEnd != it )
		{
			delete it->second;
			++it;
		}

		m_mapProcedures.clear( );
	}

	if ( m_mapExternalProcedures.size( ) > 0 )
	{
		map< string, set< unsigned int >* >::const_iterator it = m_mapExternalProcedures.begin( );
		const map< string, set< unsigned int >* >::const_iterator itEnd = m_mapExternalProcedures.end( );

		while ( itEnd != it )
		{
			delete it->second;
			++it;
		}

		m_mapExternalProcedures.clear( );
	}

	if ( m_mapDeclares.size( ) > 0 )
	{
		map< string, vector< AtlasDeclareData* >* >::const_iterator it = m_mapDeclares.begin( );
		const map< string, vector< AtlasDeclareData* >* >::const_iterator itEnd = m_mapDeclares.end( );

		while ( itEnd != it )
		{
			const unsigned int uiSize = it->second->size( );

			for ( unsigned int ui = 0; ui < uiSize; ++ui )
			{
				delete it->second->at( ui );
			}

			delete it->second;

			++it;
		}

		m_mapDeclares.clear( );
	}

	if ( m_mapStatements.size( ) > 0 )
	{
		map< const Atlas::eAtlasStatement, vector< AtlasStatement* >* >::const_iterator it = m_mapStatements.begin( );
		const map< const Atlas::eAtlasStatement, vector< AtlasStatement* >* >::const_iterator itEnd = m_mapStatements.end( );

		while ( itEnd != it )
		{
			const unsigned int uiSize = it->second->size( );
			for ( unsigned int ui = 0; ui < uiSize; ui++ )
			{
				delete it->second->at( ui );
			}

			delete it->second;
			++it;
		}

		m_mapStatements.clear( );
	}

	unsigned int uiSize = m_vectLookups.size( );
	if ( uiSize > 0 )
	{
		for ( unsigned int ui = 0; ui < uiSize; ui++ )
		{
			delete m_vectLookups[ ui ];
		}

		m_vectLookups.clear( );
	}

	uiSize = m_vectRequires.size( );
	if ( uiSize > 0 )
	{
		for ( unsigned int ui = 0; ui < uiSize; ui++ )
		{
			delete m_vectRequires[ ui ];
		}

		m_vectRequires.clear( );
		m_mapRequiresByFilename.clear( );
	}

	if ( m_mapBuiltinDeclares.size( ) > 0 )
	{
		map< Atlas::AtlasData::eBuiltInType, AtlasDeclareData* >::const_iterator it = m_mapBuiltinDeclares.begin( );
		const map< Atlas::AtlasData::eBuiltInType, AtlasDeclareData* >::const_iterator itEnd = m_mapBuiltinDeclares.end( );

		while ( itEnd != it )
		{
			delete it->second;

			++it;
		}

		m_mapBuiltinDeclares.clear( );
	}

	if ( m_mapDOMElementStatements.size( ) > 0 )
	{
		map< Atlas::eAtlasStatement, DOMStatements* >::const_iterator it = m_mapDOMElementStatements.begin( );
		const map< Atlas::eAtlasStatement, DOMStatements* >::const_iterator itEnd = m_mapDOMElementStatements.end( );

		while ( itEnd != it )
		{
			delete it->second;

			++it;
		}

		m_mapDOMElementStatements.clear( );
	}

	if ( m_mapComplexSignals.size( ) > 0 )
	{
		map< string, vector< AtlasComplexSignal* >* >::const_iterator it = m_mapComplexSignals.begin( );
		const map< string, vector< AtlasComplexSignal* >* >::const_iterator itEnd = m_mapComplexSignals.end( );

		while ( itEnd != it )
		{
			const unsigned int uiSize = it->second->size( );

			for ( unsigned int ui = 0; ui < uiSize; ++ui )
			{
				delete it->second->at( ui );
			}

			delete it->second;

			++it;
		}

		m_mapComplexSignals.clear( );
	}

	if ( m_mapComments.size( ) > 0 )
	{
		map< string, pair< Atlas::AtlasSourceStatement::eSourceType, vector< AtlasStatement* >* > >::const_iterator it = m_mapComments.begin( );
		const map< string, pair< Atlas::AtlasSourceStatement::eSourceType, vector< AtlasStatement* >* > >::const_iterator itEnd = m_mapComments.end( );

		while ( itEnd != it )
		{
			const unsigned int uiSize = it->second.second->size( );

			for ( unsigned int ui = 0; ui < uiSize; ++ui )
			{
				delete it->second.second->at( ui );
			}

			delete it->second.second;

			++it;
		}
	}
}

void AIXML::SetAtlasSources( void )
{
	const DOMAttr* pAttr = m_pRoot->getAttributeNode( AIXMLHelper::GetWString( m_arrayXMLKeyWords[ eNameAttribute ] ).c_str( ) );

	if ( 0 == pAttr )
	{
		throw Exception( Exception::eSourceXMLDoesNotContainNameAttributeThatContainsSourceFilename, __FILE__, __FUNCTION__, __LINE__ );
	}

	AIXMLHelper::GetXercesString( pAttr->getValue( ), m_strPrimaryAtlasFilename );

	if ( !m_strPrimaryAtlasFilename.empty( ) )
	{
		m_strPrimaryAtlasFilename = AIXMLHelper::StripPath( m_strPrimaryAtlasFilename );
		m_strAtlasBaseFilename = AIXMLHelper::StripExtension( m_strPrimaryAtlasFilename );
		m_strAtlasFileExtension = AIXMLHelper::GetExtension( m_strPrimaryAtlasFilename );

		m_strAtlasBaseFilename = AIXMLHelper::ToUpper( m_strAtlasBaseFilename );

		m_strPrimaryAtlasFilename = m_strAtlasBaseFilename;
		m_strPrimaryAtlasFilename += AtlasStatement::m_strDot;
		m_strPrimaryAtlasFilename += m_strAtlasFileExtension;
	}

	GetProgramName( );

	GetIncludeFilenames( );

	GetSegmentedFilenames( );

	m_vectAtlasSourceFiles.push_back( make_pair( m_strPrimaryAtlasFilename, Atlas::AtlasSourceStatement::eAtlasProgram ) );

	if ( m_vectAtlasSourceFiles.size( ) > 1 )
	{
		sort( m_vectAtlasSourceFiles.begin( ), m_vectAtlasSourceFiles.end( ), CompareAtlasFilename( ) );
	}
}

void AIXML::GetProgramName( void )
{
	const DOMElement* pBeginAtlasProgramProgramName = AIXMLHelper::FindElementPath( m_pRoot, m_arrayXPath[ eBeginAtlasProgramProgramNamePath ], false );

	if ( 0 != pBeginAtlasProgramProgramName )
	{
		const DOMAttr* pAttr = pBeginAtlasProgramProgramName->getAttributeNode( AIXMLHelper::GetWString( m_arrayXMLKeyWords[ eNameAttribute ] ).c_str( ) );

		if ( 0 != pAttr )
		{
			AIXMLHelper::GetXercesString( pAttr->getValue( ), m_strAtlasProgramName );
		}
	}
}

void AIXML::GetIncludeFilenames( void )
{
	const DOMElement* pIncludes = AIXMLHelper::FindElementPath( m_pRoot, m_arrayXPath[ eIncludeStatementsPath ], false );

	if ( 0 != pIncludes )
	{
		const xercesc::DOMElement* pAIXMLvalue = pIncludes->getFirstElementChild( );
	
		if ( 0 == pAIXMLvalue )
		{
			throw Exception( Exception::eFailedToGetChildNodes, __FILE__, __FUNCTION__, __LINE__ );
		}
	
		while ( 0 != pAIXMLvalue )
		{
			string strAIXMLtagName;
	
			AIXMLHelper::GetXercesString( pAIXMLvalue->getTagName( ), strAIXMLtagName );
	
			if ( m_arrayXMLKeyWords[ eIncludeGroupElement ] == strAIXMLtagName )
			{
				const xercesc::DOMElement* pModule = pAIXMLvalue->getFirstElementChild( );

				if ( 0 != pModule )
				{
					AIXMLHelper::GetXercesString( pModule->getTagName( ), strAIXMLtagName );

					if ( strAIXMLtagName == m_arrayXMLKeyWords[ eIncludeAtlasModuleElement ] )
					{
						const xercesc::DOMElement* pModuleChild = pModule->getFirstElementChild( );
						string strFilename;

						if ( 0 != pModuleChild )
						{
							const DOMAttr* pAttr = pModuleChild->getAttributeNode( AIXMLHelper::GetWString( m_arrayXMLKeyWords[ eNameAttribute ] ).c_str( ) );
		
							if ( 0 != pAttr )
							{
								AIXMLHelper::GetXercesString( pAttr->getValue( ), strFilename );

								if ( !strFilename.empty( ) )
								{
									VerifyIfExtension( strFilename );

									strFilename = AIXMLHelper::StripPath( strFilename );

									m_vectAtlasSourceFiles.push_back( make_pair( strFilename, Atlas::AtlasSourceStatement::eAtlasModule ) );
								}
							}
						}
					}
				}
			}

			pAIXMLvalue = pAIXMLvalue->getNextElementSibling( );
		}
	}
}

void AIXML::GetSegmentedFilenames( void )
{
	if ( 0 != m_pMainStatements )
	{
		const xercesc::DOMElement* pAIXMLvalue = m_pMainStatements->getFirstElementChild( );
	
		if ( 0 == pAIXMLvalue )
		{
			throw Exception( Exception::eFailedToGetChildNodes, __FILE__, __FUNCTION__, __LINE__ );
		}
	
		map< string, vector< pair< Atlas::AtlasSourceStatement::eSourceType, pair< string, const xercesc::DOMElement* > > > >::iterator it;
	
		while ( 0 != pAIXMLvalue )
		{
			string strAIXMLtagName;
	
			AIXMLHelper::GetXercesString( pAIXMLvalue->getTagName( ), strAIXMLtagName );
	
			if ( m_arrayXMLKeyWords[ eSegmentElement ] == strAIXMLtagName )
			{
				string strSegmentFilename;
				const DOMAttr* pAttr = pAIXMLvalue->getAttributeNode( AIXMLHelper::GetWString( m_arrayXMLKeyWords[ eNameAttribute ] ).c_str( ) );
	
				if ( 0 != pAttr )
				{
					AIXMLHelper::GetXercesString( pAttr->getValue( ), strSegmentFilename );

					if ( !strSegmentFilename.empty( ) )
					{
						VerifyIfExtension( strSegmentFilename );

						strSegmentFilename = AIXMLHelper::StripPath( strSegmentFilename );

						m_vectAtlasSourceFiles.push_back( make_pair( strSegmentFilename, Atlas::AtlasSourceStatement::eAtlasSegment ) );
					}
				}

				m_bHasSegments = true;
			}

			pAIXMLvalue = pAIXMLvalue->getNextElementSibling( );
		}
	}
}

void AIXML::GetProcedureStatements( const xercesc::DOMElement* pPreample, const string& strFilename, const Atlas::AtlasSourceStatement::eSourceType eSourceType )
{
	if ( 0 != pPreample )
	{
		const xercesc::DOMElement* pPreampleChild = pPreample->getFirstElementChild( );
	
		if ( 0 == pPreampleChild )
		{
			throw Exception( Exception::eFailedToGetChildNodes, __FILE__, __FUNCTION__, __LINE__ );
		}

		while ( 0 != pPreampleChild )
		{
			string strAIXMLtagName;

			AIXMLHelper::GetXercesString( pPreampleChild->getTagName( ), strAIXMLtagName );

			if ( m_arrayXMLKeyWords[ eDefineStatementsElement ] == strAIXMLtagName )
			{
				const xercesc::DOMElement* pAIXMLvalue = pPreampleChild->getFirstElementChild( );

				if ( 0 != pAIXMLvalue )
				{
					map< string, vector< pair< Atlas::AtlasSourceStatement::eSourceType, const xercesc::DOMElement* > > >::iterator it;

					while ( 0 != pAIXMLvalue )
					{
						AIXMLHelper::GetXercesString( pAIXMLvalue->getTagName( ), strAIXMLtagName );
				
						if ( m_arrayXMLKeyWords[ eProcedureGroupElement ] == strAIXMLtagName )
						{
							const xercesc::DOMElement* pProcedure = AIXMLHelper::FindElementPath( pAIXMLvalue, m_arrayXMLKeyWords[ eDefineProcedureElement ], false );
				
							if ( 0 != pProcedure )
							{
								it = m_mapAllProcedures.find( strFilename );
					
								if ( it == m_mapAllProcedures.end( ) )
								{
									vector< pair< Atlas::AtlasSourceStatement::eSourceType, const xercesc::DOMElement* > > vect;
					
									vect.push_back( make_pair( eSourceType, pProcedure ) );
					
									m_mapAllProcedures.insert( make_pair( strFilename, vect ) );
								}
								else
								{
									it->second.push_back( make_pair( eSourceType, pProcedure ) );
								}
							}
						}
				
						pAIXMLvalue = pAIXMLvalue->getNextElementSibling( );
					}
				}
			}

			pPreampleChild = pPreampleChild->getNextElementSibling( );
		}
	}
}

void AIXML::GetPreampleStatements( StatementMetadata* pStatementMetadata )
{
	if ( 0 != pStatementMetadata->m_pStatement )
	{
		const xercesc::DOMElement* pPreampleChild = pStatementMetadata->m_pStatement->getFirstElementChild( );
	
		if ( 0 == pPreampleChild )
		{
			throw Exception( Exception::eFailedToGetChildNodes, __FILE__, __FUNCTION__, __LINE__ );
		}

		while ( 0 != pPreampleChild )
		{
			string strAIXMLtagName;
	
			AIXMLHelper::GetXercesString( pPreampleChild->getTagName( ), strAIXMLtagName );

			if ( m_arrayXMLKeyWords[ eDefineStatementsElement ] == strAIXMLtagName )
			{
				const xercesc::DOMElement* pAIXMLvalue = pPreampleChild->getFirstElementChild( );

				if ( 0 != pAIXMLvalue )
				{
					map< Atlas::eAtlasStatement, DOMStatements* >::iterator it;
				
					while ( 0 != pAIXMLvalue )
					{
						AIXMLHelper::GetXercesString( pAIXMLvalue->getTagName( ), strAIXMLtagName );
				
						if ( m_arrayXMLKeyWords[ eProcedureGroupElement ] == strAIXMLtagName )
						{
							string strProcName;
							unsigned int uiParentProcedureId = 0;
				
							const xercesc::DOMElement* pDefindProc = AIXMLHelper::FindElementPath( pAIXMLvalue, m_arrayXPath[ eDefineProcedurePath ], false );
							if ( 0 != pDefindProc )
							{
								const DOMAttr* pAttr = pDefindProc->getAttributeNode( AIXMLHelper::GetWString( m_arrayXMLKeyWords[ eNameAttribute ] ).c_str( ) );
								if ( 0 != pAttr )
								{
									AIXMLHelper::GetXercesString( pAttr->getValue( ), strProcName );
								}

								pAttr = pDefindProc->getAttributeNode( AIXMLHelper::GetWString( m_arrayXMLKeyWords[ eIdAttribute ] ).c_str( ) );
								if ( 0 != pAttr )
								{
									string strProcId;

									AIXMLHelper::GetXercesString( pAttr->getValue( ), strProcId );

									uiParentProcedureId = AIXMLHelper::StringToNumber< unsigned int >( strProcId );
								}

								// Want the id of the parent element
								--uiParentProcedureId;
							}

							pStatementMetadata->m_strParentProcedureName = strProcName;
							pStatementMetadata->m_uiParentProcedureId = uiParentProcedureId;

							const xercesc::DOMElement* pStatements = AIXMLHelper::FindElementPath( pAIXMLvalue, m_arrayXMLKeyWords[ eStatementsElement ], false );
				
							if ( 0 != pStatements )
							{
								const xercesc::DOMElement* pStatement = pStatements->getFirstElementChild( );
				
								while ( 0 != pStatement )
								{
									pStatementMetadata->m_pStatement = pStatement;

									AIXMLHelper::GetXercesString( pStatement->getTagName( ), strAIXMLtagName );
				
									Atlas::eAtlasStatement eStatement = GetAtlasStatementEnum( strAIXMLtagName );

									if ( Atlas::eUnknownAtlasStatement == eStatement )
									{
										if ( m_arrayXMLKeyWords[ IPLGroupElement ] == strAIXMLtagName )
										{
											eStatement = Atlas::eLEAVE_ATLAS;
										}
									}

									if ( Atlas::eUnknownAtlasStatement != eStatement )
									{
										it = m_mapDOMElementStatements.find( eStatement );
							
										if ( it == m_mapDOMElementStatements.end( ) )
										{
											DOMStatements* pDOMStatements = 0;
												
											try
											{
												pDOMStatements = new DOMStatements;
											}
											catch ( ... )
											{
												throw Exception( Exception::eFailedToAllocateMemoryForNewDOMStatementsObject, __FILE__, __FUNCTION__, __LINE__ );
											}

											m_mapDOMElementStatements.insert( make_pair( eStatement, pDOMStatements ) );

											pDOMStatements->InsertMetadata( *pStatementMetadata );
										}
										else
										{
											it->second->InsertMetadata( *pStatementMetadata );
										}
									}
									else
									{
										GetStatement( pStatementMetadata, 0, 0 );

										pStatementMetadata->ClearVolatile( );
									}
				
									pStatement = pStatement->getNextElementSibling( );
								}
							}
						}
				
						pAIXMLvalue = pAIXMLvalue->getNextElementSibling( );
					}
				}
			}

			pPreampleChild = pPreampleChild->getNextElementSibling( );
		}
	}
}

void AIXML::GetMainStatements( void )
{
	if ( 0 != m_pMainStatements )
	{
		const xercesc::DOMElement* pAIXMLvalue = m_pMainStatements->getFirstElementChild( );
	
		if ( 0 == pAIXMLvalue )
		{
			throw Exception( Exception::eFailedToGetChildNodes, __FILE__, __FUNCTION__, __LINE__ );
		}
	
		map< Atlas::eAtlasStatement, DOMStatements* >::iterator it;
		bool bEntryPoint = false;

		StatementMetadata metaDataPrimary;
		StatementMetadata metaDataSegment;

		metaDataPrimary.m_strFilename = m_strPrimaryAtlasFilename;
		metaDataPrimary.m_eSourceType = Atlas::AtlasSourceStatement::eAtlasProgram;
		metaDataPrimary.m_strParentProcedureName = AtlasStatement::m_strMAIN_PROC_NAME;
		metaDataPrimary.m_uiParentProcedureId = m_uiMainProcId;

		metaDataSegment.m_eSourceType = Atlas::AtlasSourceStatement::eAtlasSegment;
		metaDataSegment.m_strParentProcedureName = AtlasStatement::m_strMAIN_PROC_NAME;
		metaDataSegment.m_uiParentProcedureId = m_uiMainProcId;
	
		while ( 0 != pAIXMLvalue )
		{
			string strAIXMLtagName;
	
			AIXMLHelper::GetXercesString( pAIXMLvalue->getTagName( ), strAIXMLtagName );
	
			if ( m_arrayXMLKeyWords[ eSegmentElement ] == strAIXMLtagName )
			{
				string strSegmentFilename;
				const DOMAttr* pAttr = pAIXMLvalue->getAttributeNode( AIXMLHelper::GetWString( m_arrayXMLKeyWords[ eNameAttribute ] ).c_str( ) );
	
				if ( 0 != pAttr )
				{
					AIXMLHelper::GetXercesString( pAttr->getValue( ), strSegmentFilename );

					VerifyIfExtension( strSegmentFilename );

					strSegmentFilename = AIXMLHelper::StripPath( strSegmentFilename );
				}

				metaDataSegment.m_strFilename = strSegmentFilename;
	
				const xercesc::DOMElement* pStatement = pAIXMLvalue->getFirstElementChild( );
	
				while ( 0 != pStatement )
				{
					AIXMLHelper::GetXercesString( pStatement->getTagName( ), strAIXMLtagName );

					metaDataSegment.m_pStatement = pStatement;
	
					const Atlas::eAtlasStatement eStatement = GetAtlasStatementEnum( strAIXMLtagName );

					if ( Atlas::eUnknownAtlasStatement != eStatement )
					{
						it = m_mapDOMElementStatements.find( eStatement );
			
						if ( it == m_mapDOMElementStatements.end( ) )
						{
							DOMStatements* pDOMStatements = 0;
								
							try
							{
								pDOMStatements = new DOMStatements;
							}
							catch ( ... )
							{
								throw Exception( Exception::eFailedToAllocateMemoryForNewDOMStatementsObject, __FILE__, __FUNCTION__, __LINE__ );
							}

							m_mapDOMElementStatements.insert( make_pair( eStatement, pDOMStatements ) );

							pDOMStatements->InsertMetadata( metaDataSegment );
						}
						else
						{
							it->second->InsertMetadata( metaDataSegment );
						}

						if ( bEntryPoint )
						{
							SetEntryPointId( pStatement );
							bEntryPoint = false;
						}
					}
					else if ( m_arrayXMLKeyWords[ eEntryPointElement ] == strAIXMLtagName )
					{
						bEntryPoint = true;
					}
					else
					{
						const xercesc::DOMElement* pNestedStatement = GetStatement( &metaDataSegment, 0, 0 );

						metaDataSegment.ClearVolatile( );

						if ( bEntryPoint )
						{
							SetEntryPointId( pNestedStatement );
							bEntryPoint = false;
						}
					}
	
					pStatement = pStatement->getNextElementSibling( );
				}
			}
			else 
			{
				const Atlas::eAtlasStatement eStatement = GetAtlasStatementEnum( strAIXMLtagName );

				metaDataPrimary.m_pStatement = pAIXMLvalue;

				if ( Atlas::eUnknownAtlasStatement != eStatement )
				{
					it = m_mapDOMElementStatements.find( eStatement );
		
					if ( it == m_mapDOMElementStatements.end( ) )
					{
						DOMStatements* pDOMStatements = 0;

						try
						{
							pDOMStatements = new DOMStatements;
						}
						catch ( ... )
						{
							throw Exception( Exception::eFailedToAllocateMemoryForNewDOMStatementsObject, __FILE__, __FUNCTION__, __LINE__ );
						}

						m_mapDOMElementStatements.insert( make_pair( eStatement, pDOMStatements ) );
	
						pDOMStatements->InsertMetadata( metaDataPrimary );
					}
					else
					{
						it->second->InsertMetadata( metaDataPrimary );
					}

					if ( bEntryPoint )
					{
						SetEntryPointId( pAIXMLvalue );
						bEntryPoint = false;
					}
				}
				else if ( m_arrayXMLKeyWords[ eEntryPointElement ] == strAIXMLtagName )
				{
					bEntryPoint = true;
				}
				else
				{
					const xercesc::DOMElement* pNestedStatement = GetStatement( &metaDataPrimary, 0, 0 );

					metaDataPrimary.ClearVolatile( );

					if ( bEntryPoint )
					{
						SetEntryPointId( pNestedStatement );
						bEntryPoint = false;
					}
				}
			}
	
			pAIXMLvalue = pAIXMLvalue->getNextElementSibling( );
		}
	}
}

void AIXML::GetPreampleIncludeStatements( void )
{
	const DOMElement* pIncludes = AIXMLHelper::FindElementPath( m_pRoot, m_arrayXPath[ eIncludeStatementsPath ], false );

	if ( 0 != pIncludes )
	{
		const xercesc::DOMElement* pAIXMLvalue = pIncludes->getFirstElementChild( );
	
		if ( 0 == pAIXMLvalue )
		{
			throw Exception( Exception::eFailedToGetChildNodes, __FILE__, __FUNCTION__, __LINE__ );
		}
	
		while ( 0 != pAIXMLvalue )
		{
			string strAIXMLtagName;
	
			AIXMLHelper::GetXercesString( pAIXMLvalue->getTagName( ), strAIXMLtagName );
	
			if ( m_arrayXMLKeyWords[ eIncludeGroupElement ] == strAIXMLtagName )
			{
				const xercesc::DOMElement* pModule = pAIXMLvalue->getFirstElementChild( );

				if ( 0 != pModule )
				{
					AIXMLHelper::GetXercesString( pModule->getTagName( ), strAIXMLtagName );

					if ( strAIXMLtagName == m_arrayXMLKeyWords[ eIncludeAtlasModuleElement ] )
					{
						const xercesc::DOMElement* pModuleChild = pModule->getFirstElementChild( );
						string strFilename;

						if ( 0 != pModuleChild )
						{
							const DOMAttr* pAttr = pModuleChild->getAttributeNode( AIXMLHelper::GetWString( m_arrayXMLKeyWords[ eNameAttribute ] ).c_str( ) );
		
							if ( 0 != pAttr )
							{
								AIXMLHelper::GetXercesString( pAttr->getValue( ), strFilename );

								VerifyIfExtension( strFilename );

								strFilename = AIXMLHelper::StripPath( strFilename );
							}
						}

						pModule = pModule->getNextElementSibling( );

						if ( 0 != pModule )
						{
							const xercesc::DOMElement* pPreample = AIXMLHelper::FindElementPath( pModule, m_arrayXPath[ eIncludeAtlasModulePreamblePath ], false );

							if ( 0 != pPreample )
							{
								StatementMetadata metaData( pPreample, strFilename, Atlas::AtlasSourceStatement::eAtlasModule );

								GetPreampleStatements( &metaData );
							}
						}
					}
				}
			}
	
			pAIXMLvalue = pAIXMLvalue->getNextElementSibling( );
		}
	}
}

const xercesc::DOMElement* AIXML::GetStatement( StatementMetadata* pStatementMetadata, unsigned int uiContainerId, unsigned int uiNesting )
{
	const xercesc::DOMElement* pAIXMLvalue = pStatementMetadata->m_pStatement;
	const xercesc::DOMElement* pRet = 0;
	string strStatement;

	AIXMLHelper::GetXercesString( pAIXMLvalue->getTagName( ), strStatement );

	const eXML xmlType = GetConditionalContainer( strStatement );

	if ( eUnknownXML != xmlType )
	{
		if ( eStatementsElement == xmlType )
		{
			const DOMAttr* pAttr = pAIXMLvalue->getAttributeNode( AIXMLHelper::GetWString( m_arrayXMLKeyWords[ eIdAttribute ] ).c_str( ) );
	
			if ( 0 != pAttr )
			{
				string strContainerId;
	
				AIXMLHelper::GetXercesString( pAttr->getValue( ), strContainerId );
	
				uiContainerId = AIXMLHelper::StringToNumber< unsigned int >( strContainerId );
			}
		}
		else if ( eDoGroupElement != xmlType )
		{
			++uiNesting;
		}

		pStatementMetadata->m_uiConditionalNestLevel = uiNesting;

		pAIXMLvalue = pAIXMLvalue->getFirstElementChild( );

		if ( 0 != pAIXMLvalue )
		{
			while ( 0 != pAIXMLvalue )
			{
				pStatementMetadata->m_pStatement = pAIXMLvalue;

				AIXMLHelper::GetXercesString( pAIXMLvalue->getTagName( ), strStatement );
		
				const Atlas::eAtlasStatement eStatement = GetAtlasStatementEnum( strStatement );

				if ( Atlas::eUnknownAtlasStatement != eStatement )
				{
					const map< Atlas::eAtlasStatement, DOMStatements* >::iterator it = m_mapDOMElementStatements.find( eStatement );

					pRet = pAIXMLvalue;

					pStatementMetadata->m_uiParentConditionalStatementsId = uiContainerId;

					if ( it == m_mapDOMElementStatements.end( ) )
					{
						DOMStatements* pDOMStatements = 0;

						try
						{
							pDOMStatements = new DOMStatements;
						}
						catch ( ... )
						{
							throw Exception( Exception::eFailedToAllocateMemoryForNewDOMStatementsObject, __FILE__, __FUNCTION__, __LINE__ );
						}

						m_mapDOMElementStatements.insert( make_pair( eStatement, pDOMStatements ) );

						pDOMStatements->InsertMetadata( *pStatementMetadata );
					}
					else
					{
						it->second->InsertMetadata( *pStatementMetadata );
					}
				}
				else
				{
					GetStatement( pStatementMetadata, uiContainerId, uiNesting );

					pStatementMetadata->m_uiConditionalNestLevel = uiNesting;
				}
		
				pAIXMLvalue = pAIXMLvalue->getNextElementSibling( );
			}
		}
	}

	return pRet;
}

AIXML::eXML AIXML::GetConditionalContainer( const string& strStatement )
{
	eXML eType = eUnknownXML;

	if ( m_arrayXMLKeyWords[ eStatementsElement ] == strStatement )
	{
		eType = eStatementsElement;
	}
	else if ( m_arrayXMLKeyWords[ eIfGroupElement ] == strStatement )
	{
		eType = eIfGroupElement;
	}
	else if ( m_arrayXMLKeyWords[ eForGroupElement ]  == strStatement )
	{
		eType = eForGroupElement;
	}
	else if ( m_arrayXMLKeyWords[ eWhileGroupElement ] == strStatement )
	{
		eType = eWhileGroupElement;
	}
	//
	// COMMENTING OUT FOR NOW
	// 
	// The 18 test cases didn't have this statement type.
	//
	//else if ( m_arrayXMLKeyWords[ eDoGroupElement ] == strStatement )
	//{
	//	eType = eDoGroupElement;
	//}

 	return eType;
}

void AIXML::ToXML( void )
{
	const string strISO8601Time( AIXMLHelper::GetCurrenctTimeAsISO8601Format( ) );
	string strXML;

	strXML.reserve( 2000000 );

	strXML += XML::GetXmlVersionAndEncoding( m_strXMLVersion, m_strXMLEncoding );

	strXML += XML::MakeOpenXmlElementWithChildren( XML::enAtlas, XML::MakeXmlAttributeNameValue( XML::anProgramName, m_strAtlasProgramName ), XML::MakeXmlAttributeNameValue( XML::anType, m_eStationType ) );
		AIXML_ToXML( strXML, strISO8601Time );
		UUT_ToXML( strXML );
		AtlasSources_ToXML( strXML );
		Comments_ToXML( strXML );
		IPLBlocks_ToXML( strXML );
		Signals_ToXML( strXML );
		BuiltIns_ToXML( strXML );
		Declares_ToXML( strXML );
		SignalOrientedStatements_ToXML( strXML );
		RemainingStatements_ToXML( strXML );
		Procedures_ToXML( strXML );
		Statistics_ToXML( strXML );
	strXML += XML::MakeCloseXmlElementWithChildren( XML::enAtlas );

	m_xmlOutFile << strXML;

	ProgramTree_ToXML( strISO8601Time );
}

void AIXML::Require_ToXML( string& strXML ) const
{
	unsigned int uiMergedRequires = 0;
	bool bIsXML = false;

	if ( 0 != m_pMergedRequires )
	{
		if ( m_bExcludeUnused )
		{
			uiMergedRequires = ( ( AtlasRequires* ) m_pMergedRequires )->GetUsedCount( );
		}
		else
		{
			uiMergedRequires = m_pMergedRequires->GetCount( );
		}

		if ( uiMergedRequires > 0 )
		{
			bIsXML = true;
		}
	}

	if ( !bIsXML )
	{
		if ( m_mapMergedInstruments.size( ) > 0 )
		{
			bIsXML = true;
		}
	}

	if ( !bIsXML )
	{
		if ( m_bExcludeUnused )
		{
			const unsigned int uiSize = m_vectRequires.size( );

			for ( unsigned int ui = 0; ui < uiSize; ++ui )
			{
				if ( ( ( AtlasRequires* ) m_vectRequires[ ui ] )->GetUsedCount( ) > 0 )
				{
					bIsXML = true;
					break;
				}
			}
		}
		else
		{
			if ( m_vectRequires.size( ) > 0 )
			{
				bIsXML = true;
			}
		}
	}

	if ( !bIsXML )
	{
		if ( m_mapMergedSignals.size( ) > 0 )
		{
			bIsXML = true;
		}
	}

	if ( !bIsXML )
	{
		if ( m_mapMergedInstrumentClasses.size( ) > 0 )
		{
			bIsXML = true;
		}
	}

	if ( bIsXML )
	{
		strXML += XML::MakeOpenXmlElementWithChildren( XML::enRequireStatement );

		const unsigned int uiRequires = m_vectRequires.size( );
		if ( uiRequires > 0 )
		{
			const AtlasStatement* pStatement;
			unsigned int uiRequireCount = 0;
			vector< const AtlasStatement* > vectRequires;
		
			for ( unsigned int ui = 0; ui < uiRequires; ui++ )
			{
				const AtlasStatements* pStatements = m_vectRequires[ ui ];

				if ( 0 != pStatements )
				{
					( ( AtlasRequires* ) pStatements )->ResetIterator( );

					if ( m_bExcludeUnused )
					{
						while ( 0 != ( pStatement = ( ( AtlasRequires* ) pStatements )->GetNext( ) ) ) 
						{
							if ( ( ( AtlasRequire* ) pStatement )->IsUsed( ) )
							{
								vectRequires.push_back( pStatement );
							}
						}
					}
					else
					{
						while ( 0 != ( pStatement = ( ( AtlasRequires* ) pStatements )->GetNext( ) ) ) 
						{
							vectRequires.push_back( pStatement );
						}
					}
				}
			}

			uiRequireCount = vectRequires.size( );

			if ( uiRequireCount > 0 )
			{
				sort( vectRequires.begin( ), vectRequires.end( ), CompareRequire( ) );
	
				strXML += XML::MakeOpenXmlElementWithChildren( XML::enRequires, XML::MakeXmlAttributeNameValue( XML::anCount, uiRequireCount ) );
	
				for ( unsigned int ui = 0; ui < uiRequireCount; ui++ )
				{
					( ( AtlasRequire* ) vectRequires[ ui ] )->ToXML( strXML, AtlasRequire::eUsedAttribute );
				}
	
				strXML += XML::MakeCloseXmlElementWithChildren( XML::enRequires );
			}
		}

		if ( 0 != m_pMergedRequires )
		{
			if ( uiMergedRequires > 0 )
			{
				const AtlasStatement* pStatement;
					
				strXML += XML::MakeOpenXmlElementWithChildren( XML::enRequiresByVirtualLabel, XML::MakeXmlAttributeNameValue( XML::anCount, uiMergedRequires ) );
			
				( ( AtlasRequires* ) m_pMergedRequires )->ResetIterator( );

				if ( m_bExcludeUnused )
				{
					while ( 0 != ( pStatement = ( ( AtlasRequires* ) m_pMergedRequires )->GetNext( ) ) ) 
					{
						if ( ( ( AtlasRequire* ) pStatement )->IsUsed( ) )
						{
							pStatement->ToXML( strXML );
						}
					}
				}
				else
				{
					while ( 0 != ( pStatement = ( ( AtlasRequires* ) m_pMergedRequires )->GetNext( ) ) ) 
					{
						pStatement->ToXML( strXML );
					}
				}
		
				strXML += XML::MakeCloseXmlElementWithChildren( XML::enRequiresByVirtualLabel );
			}
		}			
		const unsigned int uiInstrumentCount = m_mapMergedInstruments.size( );
		if ( uiInstrumentCount > 0 )
		{
			map< string, AtlasStatement* >::const_iterator it = m_mapMergedInstruments.begin( );
			const map< string, AtlasStatement* >::const_iterator itEnd = m_mapMergedInstruments.end( );
			set< string > setInstrumentClasses;
	
			while ( itEnd != it )
			{
				setInstrumentClasses.insert( SpecificInstrument::GetInstrumentClass( SpecificInstrument::GetInstrumentClass( ( ( AtlasRequire* ) it->second )->m_eInstrument ) ) );
	
				++it;
			}
				
			strXML += XML::MakeOpenXmlElementWithChildren( XML::enRequiresBySystemName, 
					XML::MakeXmlAttributeNameValue( XML::anCount, uiInstrumentCount ),
					XML::MakeXmlAttributeNameValue( XML::anClassCount, setInstrumentClasses.size( ) ) );
	
			it = m_mapMergedInstruments.begin( );
			while ( itEnd != it )
			{
				it->second->ToXML( strXML );
				++it;
			}
	
			strXML += XML::MakeCloseXmlElementWithChildren( XML::enRequiresBySystemName );
		}

		unsigned int uiSignalsCount = m_mapMergedSignals.size( );
		if ( uiSignalsCount > 0 )
		{
			map< Atlas::eAtlasNoun, AtlasStatement* >::const_iterator it = m_mapMergedSignals.begin( );
			const map< Atlas::eAtlasNoun, AtlasStatement* >::const_iterator itEnd = m_mapMergedSignals.end( );
			vector< AtlasStatement* > vectSignals;

			while ( itEnd != it )
			{
				if ( m_AtlasSignalInfo.IsSignal( it->first ) )
				{
					vectSignals.push_back( it->second );
				}

				++it;
			}

			uiSignalsCount = vectSignals.size( );

			if ( uiSignalsCount > 0 )
			{
				strXML += XML::MakeOpenXmlElementWithChildren( XML::enRequiresBySignal, XML::MakeXmlAttributeNameValue( XML::anCount, uiSignalsCount ) );

				for ( unsigned int ui = 0; ui < uiSignalsCount; ++ui )
				{
					( ( AtlasRequire* ) vectSignals[ ui ] )->ToXML( strXML, AtlasRequire::eCreateAtlasSourcesElement | AtlasRequire::eSignalOnly );
				}
	
				strXML += XML::MakeCloseXmlElementWithChildren( XML::enRequiresBySignal );
			}
		}

		unsigned int uiClassesCount = m_mapMergedInstrumentClasses.size( );
		if ( uiClassesCount > 0 )
		{
			map< string, AtlasStatement* >::const_iterator it = m_mapMergedInstrumentClasses.begin( );
			const map< string, AtlasStatement* >::const_iterator itEnd = m_mapMergedInstrumentClasses.end( );

			strXML += XML::MakeOpenXmlElementWithChildren( XML::enRequiresByClass, XML::MakeXmlAttributeNameValue( XML::anCount, uiClassesCount ) );

			while ( itEnd != it )
			{
				( ( AtlasRequire* ) it->second )->ToXML( strXML, AtlasRequire::eCreateAtlasSourcesElement | AtlasRequire::eClassOnly );
				++it;
			}

			strXML += XML::MakeCloseXmlElementWithChildren( XML::enRequiresByClass );
		}

		strXML += XML::MakeCloseXmlElementWithChildren( XML::enRequireStatement );
	}
}

void AIXML::Statements_ToXML( string& strXML, const XML::ElementName eOuterName, const XML::ElementName enInnerName, const vector< AtlasStatement* >* pvectStatements ) const
{
	if ( 0 != pvectStatements )
	{
		unsigned int uiStatementsCount = pvectStatements->size( );
		vector< AtlasStatement* > vectUsed;

		if ( m_bExcludeUnused )
		{
			unsigned int uiTemp = 0;

			for ( unsigned int ui = 0; ui < uiStatementsCount; ++ui )
			{
				const AtlasStatement* pStatement = pvectStatements->at( ui );

				if ( IsProcedureUsed( pStatement->m_strParentProcedureName, pStatement->m_uiParentProcedureId ) )
				{
					vectUsed.push_back( ( AtlasStatement* ) pStatement );
					++uiTemp;
				}
			}

			if ( uiTemp < uiStatementsCount )
			{
				uiStatementsCount = uiTemp;
				pvectStatements = &vectUsed;
			}
		}
	
		if ( uiStatementsCount > 0 )
		{
			const string strCount( XML::MakeXmlAttributeNameValue( XML::anCount, uiStatementsCount ) );
			const AtlasUnhandledStatement* pUnhandled = dynamic_cast< const AtlasUnhandledStatement* >( pvectStatements->at( 0 ) );
			const bool bHasOuter = ( XML::enUnknown != eOuterName );
			const bool bHasInner = ( XML::enUnknown != enInnerName );
			string strUnhandledStatementType;

			if ( 0 != pUnhandled )
			{
				strUnhandledStatementType = XML::MakeXmlAttributeNameValue( XML::anUnhandledStatementType, XML::avTrue );
			}

			if ( bHasOuter )
			{
				if ( !bHasInner )
				{
					strXML += XML::MakeOpenXmlElementWithChildren( eOuterName, strCount, strUnhandledStatementType ); 
				}
				else
				{
					strXML += XML::MakeOpenXmlElementWithChildren( eOuterName ); 
				}
			}
	
			if ( bHasInner )
			{
				strXML += XML::MakeOpenXmlElementWithChildren( enInnerName, strCount, strUnhandledStatementType );
			}

			for ( unsigned int ui = 0; ui < uiStatementsCount; ++ui )
			{
				pvectStatements->at( ui )->ToXML( strXML );
			}
	
			if ( XML::enUnknown != enInnerName )
			{
				strXML += XML::MakeCloseXmlElementWithChildren( enInnerName );
			}
	
			if ( XML::enUnknown != eOuterName )
			{
				strXML += XML::MakeCloseXmlElementWithChildren( eOuterName );
			}
		}
	}
}

void AIXML::RemainingStatements_ToXML( string& strXML ) const
{
	if ( m_mapStatements.size( ) > 0 )
	{
		set< Atlas::eAtlasStatement > setExclude;

		// Begin signal oriented
		setExclude.insert( Atlas::eAPPLY );
		setExclude.insert( Atlas::eMEASURE );
		setExclude.insert( Atlas::eMONITOR );
		setExclude.insert( Atlas::eVERIFY );
		setExclude.insert( Atlas::eSETUP );
		setExclude.insert( Atlas::eREAD );
		setExclude.insert( Atlas::eINITIATE );
		setExclude.insert( Atlas::eREMOVE );
		setExclude.insert( Atlas::eFETCH );
		setExclude.insert( Atlas::eCONNECT );
		setExclude.insert( Atlas::eDISCONNECT );
		setExclude.insert( Atlas::eARM );
		setExclude.insert( Atlas::eCHANGE );
		setExclude.insert( Atlas::eRESET );
		setExclude.insert( Atlas::eOPEN );
		setExclude.insert( Atlas::eCLOSE );
		setExclude.insert( Atlas::eREQUIRE );  // Not used just for signals, other stuff also (CRT, PRINTER, ect.)
		// End signal oriented

		// Being procedural
		setExclude.insert( Atlas::ePERFORM );
		setExclude.insert( Atlas::eDEFINE_PROCEDURE );
		setExclude.insert( Atlas::eIF_THEN );
		setExclude.insert( Atlas::eELSE );
		setExclude.insert( Atlas::eWHILE_THEN );
		setExclude.insert( Atlas::eFOR_THEN );
		setExclude.insert( Atlas::eGO_TO );
		setExclude.insert( Atlas::eLEAVE_PROCEDURE );
		setExclude.insert( Atlas::eLEAVE_IF );
		setExclude.insert( Atlas::eLEAVE_FOR );
		setExclude.insert( Atlas::eLEAVE_WHILE );
		// End procedural

		// Begin others
		setExclude.insert( Atlas::eIDENTIFY );
		setExclude.insert( Atlas::eEXTEND );
		setExclude.insert( Atlas::eCOMMENT );
		setExclude.insert( Atlas::eDEFINE );
		setExclude.insert( Atlas::eDECLARE );
		// End others


		const set< Atlas::eAtlasStatement >::const_iterator itExcludeEnd = setExclude.end( );
		map< const Atlas::eAtlasStatement, vector< AtlasStatement* >* >::const_iterator it = m_mapStatements.begin( );
		const map< const Atlas::eAtlasStatement, vector< AtlasStatement* >* >::const_iterator itEnd = m_mapStatements.end( );
		map< string, pair< vector< AtlasStatement* >*, XML::ElementName > > mapSorted;

		strXML += XML::MakeOpenXmlElementWithChildren( XML::enStatements );

		while ( itEnd != it )
		{
			if ( itExcludeEnd == setExclude.find( it->first ) )
			{
				const pair< XML::ElementName, XML::ElementName >* pPair = GetAtlasStatementXMLElementNames( it->first );

				if ( 0 != pPair )
				{
					mapSorted.insert( make_pair( XML::GetElementName( pPair->first ), make_pair( it->second, pPair->first ) ) );
				}
				else if ( Atlas::eREAD_DATETIME == it->first )  // Special case, simulated statement type
				{
					mapSorted.insert( make_pair( XML::GetElementName( XML::enReadDateTimes ), make_pair( it->second, XML::enReadDateTimes ) ) );
				}
			}

			++it;
		}

		if ( mapSorted.size( ) > 0 )
		{
			map< string, pair< vector< AtlasStatement* >*, XML::ElementName > >::const_iterator it2 = mapSorted.begin( );
			const map< string, pair< vector< AtlasStatement* >*, XML::ElementName > >::const_iterator itEnd2 = mapSorted.end( );

			while ( itEnd2 != it2 )
			{
				Statements_ToXML( strXML, it2->second.second, XML::enUnknown, it2->second.first );

				++it2;
			}
		}

		strXML += XML::MakeCloseXmlElementWithChildren( XML::enStatements );
	}
}

bool AIXML::CompareRequire::operator( )( const AtlasStatement* l, const AtlasStatement* r )
{
	return ( AIXMLHelper::ToLower( ( ( AtlasSignalVerb* ) l )->m_strVirtualLabel ) < AIXMLHelper::ToLower( ( ( AtlasSignalVerb* ) r )->m_strVirtualLabel ) );
}

bool AIXML::CompareAtlasFilename::operator( )( const pair< string, Atlas::AtlasSourceStatement::eSourceType >& l, const pair< string, Atlas::AtlasSourceStatement::eSourceType >& r )
{
	return ( AIXMLHelper::ToLower( l.first ) < AIXMLHelper::ToLower( r.first ) );
}

bool AIXML::CompareConditional::operator( )( const AtlasStatement* l, const AtlasStatement* r )
{
	const unsigned int uiLnestLevel	= ( ( AtlasCondition* ) l )->m_uiNestLevel;
	const unsigned int uiRnestLevel	= ( ( AtlasCondition* ) r )->m_uiNestLevel;
	const unsigned int uiLparentId	= l->m_uiParentProcedureId;
	const unsigned int uiRparentId	= r->m_uiParentProcedureId;
	const unsigned int uiLlineNum	= l->GetStatementLineNumber( );
	const unsigned int uiRlineNum	= r->GetStatementLineNumber( );
	bool bLess;

	if ( uiLnestLevel == uiRnestLevel )
	{
		if ( uiLparentId == uiRparentId )
		{
			bLess = ( uiLlineNum < uiRlineNum );
		}
		else 
		{
			bLess = ( uiLparentId == uiRparentId );
		}
	}
	else
	{
		bLess = ( uiLnestLevel < uiRnestLevel );
	}

	return bLess;
}

void AIXML::BuildStatistics( void )
{
	if ( m_mapProcedures.size( ) > 0 )
	{
		map< string, map< unsigned int, AtlasStatement* >* >::const_iterator it = m_mapProcedures.begin( );
		map< string, map< unsigned int, AtlasStatement* >* >::const_iterator itEnd = m_mapProcedures.end( );

		if ( m_bExcludeUnused )
		{
			while ( itEnd != it )
			{
				map< unsigned int, AtlasStatement* >::const_iterator it2 = it->second->begin( );
				const map< unsigned int, AtlasStatement* >::const_iterator it2End = it->second->end( );

				while ( it2End != it2 )
				{
					if ( ( ( AtlasProcedure* ) it2->second )->m_bUsed )
					{
						if ( !( ( AtlasProcedure* ) it2->second )->m_bMainProcedure )
						{
							m_AtlasStatistics.SetStatementCount( Atlas::eDEFINE_PROCEDURE, 1 );
						}
					}

					++it2;
				}

				++it;
			}
		}
		else
		{
			while ( itEnd != it )
			{
				if ( AtlasStatement::m_strMAIN_PROC_NAME != it->first )
				{
					m_AtlasStatistics.SetStatementCount( Atlas::eDEFINE_PROCEDURE, it->second->size( ) );
				}
	
				++it;
			}
		}
	}


	if ( m_mapDeclares.size( ) > 0 )
	{
		map< string, vector< AtlasDeclareData* >* >::const_iterator it = m_mapDeclares.begin( );
		map< string, vector< AtlasDeclareData* >* >::const_iterator itEnd = m_mapDeclares.end( );

		if ( m_bExcludeUnused )
		{
			while ( itEnd != it )
			{
				const vector< AtlasDeclareData* >* pvectDeclares = it->second;
				const unsigned int uiSize = pvectDeclares->size( );
	
				for ( unsigned int ui = 0; ui < uiSize; ++ui )
				{
					AtlasDeclareData* pAtlasDeclareData = pvectDeclares->at( ui );

					if ( pAtlasDeclareData->m_Declare.IsExternal( ) )
					{
						m_AtlasStatistics.SetStatementCount( Atlas::eDECLARE, 1 );
					}
					else
					{
						if ( IsDeclareUsed( pAtlasDeclareData ) )
						{
							m_AtlasStatistics.SetStatementCount( Atlas::eDECLARE, 1 );
						}
					}
				}
	
				++it;
			}
		}
		else
		{
			while ( itEnd != it )
			{
				m_AtlasStatistics.SetStatementCount( Atlas::eDECLARE, it->second->size( ) );
	
				++it;
			}
		}
	}
	

	if ( m_mapStatements.size( ) > 0 )
	{
		map< const Atlas::eAtlasStatement, vector< AtlasStatement* >* >::const_iterator it = m_mapStatements.begin( );
		const map< const Atlas::eAtlasStatement, vector< AtlasStatement* >* >::const_iterator itEnd = m_mapStatements.end( );

		while ( itEnd != it )
		{
			if ( Atlas::IsElectricalSignalOrientedStatement( it->first ) )
			{
				vector< AtlasStatement* >* pvect = it->second;
				const unsigned int uiSize = pvect->size( );

				if ( m_bExcludeUnused )
				{
					for ( unsigned int ui = 0; ui < uiSize; ui++ )
					{
						AtlasActionSignalVerb* pSignalVerb = ( AtlasActionSignalVerb* ) pvect->at( ui );
	
						if ( IsProcedureUsed( pSignalVerb->m_strParentProcedureName, pSignalVerb->m_uiParentProcedureId ) )
						{
							m_AtlasStatistics.SetStatementCount( it->first, 1 );

							SetRequireUsed( pSignalVerb->m_strVirtualLabel );

							pSignalVerb->InitSignalInfo( &m_AtlasSignalInfo );
		
							const Atlas::eAtlasNoun eNoun = pSignalVerb->m_PrimarySignalComponent.GetAtlasNoun( );
		
							if ( Atlas::eUnknownAtlasNoun != eNoun )
							{
								m_AtlasStatistics.SetSignalCount( eNoun, 1 );
							}
							#if ( _DEBUG ) && ( WIN32 )
							else if ( !pSignalVerb->m_bRemoveAll )
							{
								DebugBreak( );
							}
							#endif
						}
					}
				}
				else
				{
					m_AtlasStatistics.SetStatementCount( it->first, uiSize );

					for ( unsigned int ui = 0; ui < uiSize; ui++ )
					{
						AtlasActionSignalVerb* pSignalVerb = ( AtlasActionSignalVerb* ) pvect->at( ui );
	
						pSignalVerb->InitSignalInfo( &m_AtlasSignalInfo );

						SetRequireUsed( pSignalVerb->m_strVirtualLabel );
	
						const Atlas::eAtlasNoun eNoun = pSignalVerb->m_PrimarySignalComponent.GetAtlasNoun( );
	
						if ( Atlas::eUnknownAtlasNoun != eNoun )
						{
							m_AtlasStatistics.SetSignalCount( eNoun, 1 );
						}
						#if ( _DEBUG ) && ( WIN32 )
						else if ( !pSignalVerb->m_bRemoveAll )
						{
							DebugBreak( );
						}
						#endif
					}
				}
			}
			else
			{
				if ( Atlas::eDEFINE_PROCEDURE != it->first )
				{
					if ( m_bExcludeUnused )
					{
						vector< AtlasStatement* >* pvect = it->second;
						const unsigned int uiSize = pvect->size( );
	
						for ( unsigned int ui = 0; ui < uiSize; ++ui )
						{
							const AtlasStatement* pStatement = pvect->at( ui );
	
							if ( IsProcedureUsed( pStatement->m_strParentProcedureName, pStatement->m_uiParentProcedureId ) )
							{
								m_AtlasStatistics.SetStatementCount( it->first, 1 );

								//	NOTE: Once INPUT/OUTPUT done, add code to handle REQUIREs being used
							}
						}
					}
					else
					{
						m_AtlasStatistics.SetStatementCount( it->first, it->second->size( ) );

						//	NOTE: Once INPUT/OUTPUT done, add code to handle REQUIREs being used
					}
				}
			}

			++it;
		}
	}


	if ( m_mapComplexSignals.size( ) > 0 )
	{
		map< string, vector< AtlasComplexSignal* >* >::const_iterator it = m_mapComplexSignals.begin( );
		const map< string, vector< AtlasComplexSignal* >* >::const_iterator itEnd = m_mapComplexSignals.end( );

		while ( itEnd != it )
		{
			const unsigned int uiSize = it->second->size( );

			if ( m_bExcludeUnused )
			{
				for ( unsigned int ui = 0; ui < uiSize; ++ui )
				{
					AtlasComplexSignal* pComplexSignal = ( AtlasComplexSignal* ) it->second->at( ui );
	
					if ( SetComplexSignalUsage( pComplexSignal ) )
					{
						pComplexSignal->InitSignalInfo( &m_AtlasSignalInfo );
						pComplexSignal->SetStatistics( &m_AtlasStatistics );
					}
				}
			}
			else
			{
				for ( unsigned int ui = 0; ui < uiSize; ++ui )
				{
					AtlasComplexSignal* pComplexSignal = ( AtlasComplexSignal* ) it->second->at( ui );
					
					SetComplexSignalUsage( pComplexSignal );
					
					pComplexSignal->InitSignalInfo( &m_AtlasSignalInfo );
					pComplexSignal->SetStatistics( &m_AtlasStatistics );
				}
			}

			++it;
		}
	}


	const unsigned int uiRequires = m_vectRequires.size( );
	if ( uiRequires > 0 )
	{
		const AtlasStatement* pStatement;

		if ( m_bExcludeUnused )
		{
			for ( unsigned int ui = 0; ui < uiRequires; ui++ )
			{
				const AtlasStatements* pStatements = m_vectRequires[ ui ];
	
				if ( 0 != pStatements )
				{
					( ( AtlasRequires* ) pStatements )->ResetIterator( );
	
					while ( 0 != ( pStatement = ( ( AtlasRequires* ) pStatements )->GetNext( ) ) ) 
					{
						if ( ( ( AtlasRequire* ) pStatement )->IsUsed( ) )
						{
							( ( AtlasRequire* ) pStatement )->InitSignalInfo( &m_AtlasSignalInfo, AtlasRequire::eAll );
							m_AtlasStatistics.SetStatementCount( Atlas::eREQUIRE, 1 );
						}
					}
				}
			}
		}
		else
		{
			for ( unsigned int ui = 0; ui < uiRequires; ui++ )
			{
				const AtlasStatements* pStatements = m_vectRequires[ ui ];
	
				if ( 0 != pStatements )
				{
					m_AtlasStatistics.SetStatementCount( Atlas::eREQUIRE, pStatements->GetCount( ) );

					( ( AtlasRequires* ) pStatements )->ResetIterator( );
	
					while ( 0 != ( pStatement = ( ( AtlasRequires* ) pStatements )->GetNext( ) ) ) 
					{
						( ( AtlasRequire* ) pStatement )->InitSignalInfo( &m_AtlasSignalInfo, AtlasRequire::eAll );
					}
				}
			}
		}
	}
}

void AIXML::ProcessProcedureSymbolTable( void )
{
	vector< AtlasStatement* >* pvectProcedures = GetStatementVector( Atlas::eDEFINE_PROCEDURE );

	if ( 0 != pvectProcedures )
	{
		unsigned int uiSize = pvectProcedures->size( );
	
		if ( uiSize > 0 )
		{
			const set< string >::const_iterator itNonAtlasEnd = m_setNonAtlasProcedures.end( );
			map< string, map< unsigned int, AtlasStatement* >* >::iterator itAtlas;
			const map< string, map< unsigned int, AtlasStatement* >* >::const_iterator itAtlasEnd = m_mapProcedures.end( );
		
			for ( unsigned int ui = 0; ui < uiSize; ++ui )
			{
				AtlasProcedure* pProcedure = ( AtlasProcedure* ) pvectProcedures->at( ui );

				if ( itNonAtlasEnd != m_setNonAtlasProcedures.find( pProcedure->m_strProcedureName ) )
				{
					pProcedure->m_bNonAtlas = true;
	
					itAtlas = m_mapProcedures.find( pProcedure->m_strProcedureName );
	
					if ( itAtlasEnd == itAtlas )
					{
						map< unsigned int, AtlasStatement* >* pmapProcedures = 0;
							
						try
						{
							pmapProcedures = new map< unsigned int, AtlasStatement* >( );
						}
						catch ( ... )
						{
							throw Exception( Exception::eFailedToCreateMapObject, __FILE__, __FUNCTION__, __LINE__ );
						}

						m_mapProcedures.insert( make_pair( pProcedure->m_strProcedureName, pmapProcedures ) );
	
						pmapProcedures->insert( make_pair( pProcedure->m_uiId, pProcedure ) );
					}
					else
					{
						itAtlas->second->insert( make_pair( pProcedure->m_uiId, pProcedure ) );
					}
				}
				else
				{
					itAtlas = m_mapProcedures.find( pProcedure->m_strProcedureName );
	
					if ( itAtlasEnd == itAtlas )
					{
						map< unsigned int, AtlasStatement* >* pmapProcedures = 0;
					
						try
						{
							pmapProcedures = new map< unsigned int, AtlasStatement* >( );
						}
						catch ( ... )
						{
							throw Exception( Exception::eFailedToCreateMapObject, __FILE__, __FUNCTION__, __LINE__ );
						}

						m_mapProcedures.insert( make_pair( pProcedure->m_strProcedureName, pmapProcedures ) );
	
						pmapProcedures->insert( make_pair( pProcedure->m_uiId, pProcedure ) );
					}
					else
					{
						itAtlas->second->insert( make_pair( pProcedure->m_uiId, pProcedure ) );
					}
				}
			}
	
			vector< AtlasStatement* >* pvectPerforms = GetStatementVector( Atlas::ePERFORM );
			if ( 0 != pvectPerforms )
			{
				uiSize = pvectPerforms->size( );
		
				for ( unsigned int ui = 0; ui < uiSize; ++ui )
				{
					AtlasPerform* pPerform = ( AtlasPerform* ) pvectPerforms->at( ui );

					itAtlas = m_mapProcedures.find( pPerform->m_strProcedureName );
		
					if ( itAtlasEnd != itAtlas )
					{
						const map< unsigned int, AtlasStatement* >* pmapProcs = itAtlas->second;
		
						if ( 1 == pmapProcs->size( ) )
						{
							pPerform->m_uiProcedureId = pmapProcs->begin( )->second->m_uiId;
						}
						else
						{
							const AtlasStatement* pProc = GetScopedProcedure( pPerform, pmapProcs );
		
							if ( 0 != pProc )
							{
								pPerform->m_uiProcedureId = pProc->m_uiId;
							}
						}
					}
				}
			}
		}
	}
}

void AIXML::ProcessDeclareSymbolTable( void )
{
	if ( m_mapStatements.size( ) > 0 )
	{
		map< const Atlas::eAtlasStatement, vector< AtlasStatement* >* >::const_iterator itStatements = m_mapStatements.begin( );
		const map< const Atlas::eAtlasStatement, vector< AtlasStatement* >* >::const_iterator itStatementsEnd = m_mapStatements.end( );
		const vector< pair< string, Atlas::AtlasSourceStatement::eSourceType > >* pvectAtlasSourceFiles = 0;

		if ( m_bHasSegments )
		{
			pvectAtlasSourceFiles = &m_vectAtlasSourceFiles;
		}
	
		while ( itStatementsEnd != itStatements )
		{
			const vector< AtlasStatement* >& vectStatements = *( itStatements->second );
			const unsigned int uiStatements = vectStatements.size( );
	
			for ( unsigned int ui = 0; ui < uiStatements; ++ui )
			{
				AtlasStatement* pStatement = vectStatements[ ui ];

				const AtlasProcedure* pProcedure = ( AtlasProcedure* ) GetProcedure( pStatement->m_strParentProcedureName, pStatement->m_uiParentProcedureId );

				pStatement->ProcessVariableSymbols( m_mapDeclares, m_mapBuiltinDeclares, pProcedure, pvectAtlasSourceFiles );
			}
	
			++itStatements;
		}
	}

	if ( m_mapComplexSignals.size( ) > 0 )
	{
		map< string, vector< AtlasComplexSignal* >* >::const_iterator it = m_mapComplexSignals.begin( );
		const map< string, vector< AtlasComplexSignal* >* >::const_iterator itEnd = m_mapComplexSignals.end( );
		const vector< pair< string, Atlas::AtlasSourceStatement::eSourceType > >* pvectAtlasSourceFiles = 0;

		if ( m_bHasSegments )
		{
			pvectAtlasSourceFiles = &m_vectAtlasSourceFiles;
		}

		while ( itEnd != it )
		{
			const unsigned int uiSize = it->second->size( );

			for ( unsigned int ui = 0; ui < uiSize; ++ui )
			{
				it->second->at( ui )->ProcessVariableSymbols( m_mapDeclares, m_mapBuiltinDeclares, 0, pvectAtlasSourceFiles );
			}

			++it;
		}
	}
}

void AIXML::ProcessDeclares( void )
{
	if ( m_mapDeclares.size( ) > 0 )
	{
		map< string, vector< AtlasDeclareData* >* >::const_iterator it = m_mapDeclares.begin( );
		const map< string, vector< AtlasDeclareData* >* >::const_iterator itEnd = m_mapDeclares.end( );

		while ( itEnd != it )
		{
			const vector< AtlasDeclareData* >* pvect = it->second;
			const unsigned int uiSize = pvect->size( );

			for ( unsigned int ui = 0; ui < uiSize; ++ui )
			{
				AtlasDeclareData* pDeclareData = pvect->at( ui );
				map< const Atlas::eAtlasStatement, vector< AtlasStatement* >* >::const_iterator itStatements = m_mapStatements.begin( );
				const map< const Atlas::eAtlasStatement, vector< AtlasStatement* >* >::const_iterator itStatementEnd = m_mapStatements.end( );

				while ( itStatementEnd != itStatements )
				{
					const vector< AtlasStatement* >* pvectStatements = itStatements->second;
					const unsigned int uiStatements = pvectStatements->size( );

					if ( uiStatements > 0 )
					{
						if ( Atlas::eFILL == itStatements->first )
						{
							for ( unsigned int ui2 = 0; ui2 < uiStatements; ++ui2 )
							{
								const AtlasFill* pFill = ( AtlasFill* ) pvectStatements->at( ui2 );
	
								if ( 0 != pFill->m_pVariableName )
								{
									if ( pDeclareData->m_Declare.m_strVarName == pFill->m_pVariableName->GetVariableName( ) )
									{
										pDeclareData->m_vectAssignments.push_back( ( AtlasStatement* ) pFill );
									}
								}
							}
						}
						else if ( Atlas::eCALCULATE == itStatements->first )
						{
							for ( unsigned int ui2 = 0; ui2 < uiStatements; ++ui2 )
							{
								const AtlasCalculate* pCalculate = ( AtlasCalculate* ) pvectStatements->at( ui2 );
	
								if ( 0 != pCalculate->m_pVariable )
								{
									if ( Atlas::AtlasTerm::GetRawClassName( ) == typeid( *pCalculate->m_pVariable ).raw_name( ) )
									{
										const Atlas::AtlasData* pCalcData = ( ( Atlas::AtlasTerm* ) pCalculate->m_pVariable )->GetTerm( false );
	
										if ( pDeclareData->m_Declare.m_strVarName == pCalcData->GetVariableName( ) )
										{
											pDeclareData->m_vectAssignments.push_back( ( AtlasStatement* ) pCalculate );
										}
									}
								}
							}
						}
						else
						{
							for ( unsigned int ui2 = 0; ui2 < uiStatements; ++ui2 )
							{
								AtlasStatement* pStatement = pvectStatements->at( ui2 );

								if ( pStatement->IsVariable( pDeclareData->m_Declare.m_strVarName, pDeclareData->m_Source.GetId( ) ) )
								{
									if ( 0 != dynamic_cast< const AtlasActionSignalVerb* >( pStatement ) )
									{
										pDeclareData->m_vectSignalOriented.push_back( pStatement );
									}
									else
									{
										pDeclareData->m_vectNonSignalOriented.push_back( pStatement );
									}
								}
							}
						}
					}

					++itStatements;
				}
			}

			++it;
		}
	}
}

void AIXML::BuildProcedureStatements( void )
{
	if ( m_mapStatements.size( ) > 0 )
	{
		BuildProcedureConditionalStatements( );

		map< const Atlas::eAtlasStatement, vector< AtlasStatement* >* >::const_iterator it = m_mapStatements.begin( );
		const map< const Atlas::eAtlasStatement, vector< AtlasStatement* >* >::const_iterator itEnd = m_mapStatements.end( );

		while ( itEnd != it )
		{
			if ( ( it->first < Atlas::eIF_THEN ) || ( it->first > Atlas::eFOR_THEN ) )
			{
				BuildProcedureStatements( it->second );
			}

			++it;
		}
	}
}

void AIXML::BuildProcedureConditionalStatements( void )
{
	if ( m_mapProcedures.size( ) > 0 )
	{
		map< string, map< unsigned int, AtlasStatement* >* >::iterator it;
		const map< string, map< unsigned int, AtlasStatement* >* >::const_iterator itEnd = m_mapProcedures.end( );
		vector< AtlasStatement* >* pvectIf = GetStatementVector( Atlas::eIF_THEN );
		vector< AtlasStatement* >* pvectElse = GetStatementVector( Atlas::eELSE );
		vector< AtlasStatement* >* pvectWhile = GetStatementVector( Atlas::eWHILE_THEN );
		vector< AtlasStatement* >* pvectFor = GetStatementVector( Atlas::eFOR_THEN );
		AtlasCondition* pCondition = 0;
		unsigned int uiMaxLevels = 0;
		unsigned int uiIfSize = 0;
		unsigned int uiElseSize = 0;
		unsigned int uiWhileSize = 0;
		unsigned int uiForSize = 0;
		unsigned int uiIfIndex = 0;
		unsigned int uiElseIndex = 0;
		unsigned int uiWhileIndex = 0;
		unsigned int uiForIndex = 0;
	
		if ( 0 != pvectIf )
		{
			pCondition = ( AtlasCondition* ) pvectIf->back( );
	
			if ( pCondition->m_uiNestLevel > uiMaxLevels )
			{
				uiMaxLevels = pCondition->m_uiNestLevel;
			}
	
			uiIfSize = pvectIf->size( );
		}
	
		if ( 0 != pvectElse )
		{
			pCondition = ( AtlasCondition* ) pvectElse->back( );
	
			if ( pCondition->m_uiNestLevel > uiMaxLevels )
			{
				uiMaxLevels = pCondition->m_uiNestLevel;
			}
	
			uiElseSize = pvectElse->size( );
		}
	
		if ( 0 != pvectWhile )
		{
			pCondition = ( AtlasCondition* ) pvectWhile->back( );
	
			if ( pCondition->m_uiNestLevel > uiMaxLevels )
			{
				uiMaxLevels = pCondition->m_uiNestLevel;
			}
	
			uiWhileSize = pvectWhile->size( );
		}
	
		if ( 0 != pvectFor )
		{
			pCondition = ( AtlasCondition* ) pvectFor->back( );
	
			if ( pCondition->m_uiNestLevel > uiMaxLevels )
			{
				uiMaxLevels = pCondition->m_uiNestLevel;
			}
	
			uiForSize = pvectFor->size( );
		}

		for ( unsigned int uiLevel = 1; uiLevel <= uiMaxLevels; ++uiLevel )
		{
			for ( unsigned int ui = 1; ui < 5; ++ui )
			{
				unsigned int* puiSize = 0;
				unsigned int* puiIndex = 0;
				vector< AtlasStatement* >* pvect = 0;

				switch ( ui )
				{
					case 1:
						puiSize = &uiIfSize;
						puiIndex = &uiIfIndex;
						pvect = pvectIf;
						break;
	
					case 2:
						puiSize = &uiElseSize;
						puiIndex = &uiElseIndex;
						pvect = pvectElse;
						break;
	
					case 3:
						puiSize = &uiWhileSize;
						puiIndex = &uiWhileIndex;
						pvect = pvectWhile;
						break;
	
					case 4:
						puiSize = &uiForSize;
						puiIndex = &uiForIndex;
						pvect = pvectFor;
						break;
				}

				if ( *puiIndex < *puiSize )
				{
					for ( ; *puiIndex < *puiSize; ++( *puiIndex ) )
					{
						pCondition = ( AtlasCondition* ) pvect->at( *puiIndex );

						if ( uiLevel != pCondition->m_uiNestLevel )
						{
							break;
						}

						it = m_mapProcedures.find( pCondition->m_strParentProcedureName );
				
						if ( itEnd != it )
						{
							const map< unsigned int, AtlasStatement* >* pmapProcs = it->second;

							if ( 1 == pmapProcs->size( ) )
							{
								( ( AtlasProcedure* ) pmapProcs->begin( )->second )->InsertStatement( pCondition );
							}
							else
							{
								const AtlasStatement* pProc = GetScopedProcedure( pCondition, pmapProcs );
		
								if ( 0 != pProc )
								{
									( ( AtlasProcedure* ) pProc )->InsertStatement( pCondition );
								}
								#if ( _DEBUG ) && ( WIN32 )
								else
								{
									DebugBreak( );
								}
								#endif
							}
						}
					}
				}
			}
		}
	}
}

void AIXML::BuildProcedureStatements( vector< AtlasStatement* >* pvectStatements )
{
	if ( ( 0 != pvectStatements ) && ( m_mapProcedures.size( ) > 0 ) )
	{
		const unsigned int uiSize = pvectStatements->size( );

		if ( uiSize > 0 )
		{
			map< string, map< unsigned int, AtlasStatement* >* >::iterator it;
			const map< string, map< unsigned int, AtlasStatement* >* >::const_iterator itEnd = m_mapProcedures.end( );

			for ( unsigned int ui = 0; ui < uiSize; ++ui )
			{
				AtlasStatement* pStatement = pvectStatements->at( ui );
	
				it = m_mapProcedures.find( pStatement->m_strParentProcedureName );
	
				if ( itEnd != it )
				{
					const map< unsigned int, AtlasStatement* >* pmapProcs = it->second;

					if ( 1 == pmapProcs->size( ) )
					{
						( ( AtlasProcedure* ) pmapProcs->begin( )->second )->InsertStatement( pStatement );
					}
					else
					{
						const AtlasStatement* pProc = GetScopedProcedure( pStatement, pmapProcs );

						if ( 0 != pProc )
						{
							( ( AtlasProcedure* ) pProc )->InsertStatement( pStatement );
						}
						#if ( _DEBUG ) && ( WIN32 )
						else
						{
							DebugBreak( );
						}
						#endif
					}
				}
			}
		}
	}
}

void AIXML::ProcessGotoLeaveStatements( void )
{
	ProcessGotoLeaveStatements( GetStatementVector( Atlas::eGO_TO ) );
	ProcessGotoLeaveStatements( GetStatementVector( Atlas::eLEAVE_PROCEDURE ) );
	ProcessGotoLeaveStatements( GetStatementVector( Atlas::eLEAVE_IF ) );
	ProcessGotoLeaveStatements( GetStatementVector( Atlas::eLEAVE_FOR ) );
	ProcessGotoLeaveStatements( GetStatementVector( Atlas::eLEAVE_WHILE ) );
}

void AIXML::ProcessGotoLeaveStatements( vector< AtlasStatement* >* pvectStatements )
{
	if ( 0 != pvectStatements )
	{
		const unsigned int uiSize = pvectStatements->size( );

		if ( uiSize > 0 )
		{
			for ( unsigned int ui = 0; ui < uiSize; ++ui )
			{
				AtlasStatement* pStatement = pvectStatements->at( ui );
				AtlasProcedure* pProcedure = ( AtlasProcedure* ) GetProcedure( pStatement->m_strParentProcedureName, pStatement->m_uiParentProcedureId );

				if ( 0 != pProcedure )
				{
					bool bSet = pProcedure->SetBranchDestinationRefId( pStatement, pProcedure );

					if ( !bSet && ( m_uiMainProcId != pProcedure->m_uiId ) )
					{
						pProcedure = ( AtlasProcedure* ) GetProcedure( AtlasStatement::m_strMAIN_PROC_NAME, m_uiMainProcId );

						if ( 0 != pProcedure )
						{
							bSet = pProcedure->SetBranchDestinationRefId( pStatement, pProcedure );
						}
					}

					#if ( _DEBUG ) && ( WIN32 )
					if ( !bSet )
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
			}
		}
	}
}

void AIXML::ProcessDigitalExpressions( void )
{
	ProcessDigitalExpressions( GetStatementVector( Atlas::eIF_THEN ) );
	ProcessDigitalExpressions( GetStatementVector( Atlas::eWHILE_THEN ) );
	ProcessDigitalExpressions( GetStatementVector( Atlas::eFOR_THEN ) );
	ProcessDigitalExpressions( GetStatementVector( Atlas::eCALCULATE ) );
	ProcessDigitalExpressions( GetStatementVector( Atlas::eCOMPARE ) );
}

void AIXML::ProcessDigitalExpressions( vector< AtlasStatement* >* pStatements )
{
	if ( 0 != pStatements )
	{
		const unsigned int uiSize = pStatements->size( );

		if ( uiSize > 0 )
		{
			if ( 0 != dynamic_cast< const AtlasCondition* >( pStatements->at( 0 ) ) )
			{
				for ( unsigned int ui = 0; ui < uiSize; ++ui )
				{
					( ( AtlasCondition* ) pStatements->at( ui ) )->VerifyIfBitwiseExpression( );
				}
			}
			else if ( 0 != dynamic_cast< const AtlasCalculate* >( pStatements->at( 0 ) ) )
			{
				for ( unsigned int ui = 0; ui < uiSize; ++ui )
				{
					( ( AtlasCalculate* ) pStatements->at( ui ) )->VerifyIfBitwiseExpression( );
				}
			}
			else if ( 0 != dynamic_cast< const AtlasCompare* >( pStatements->at( 0 ) ) )
			{
				for ( unsigned int ui = 0; ui < uiSize; ++ui )
				{
					( ( AtlasCompare* ) pStatements->at( ui ) )->VerifyIfBitwiseExpression( );
				}
			}
		}
	}
}

void AIXML::SetStatementsParent( void )
{
	map< string, map< unsigned int, AtlasStatement* >* >::const_iterator it = m_mapProcedures.begin( );
	const map< string, map< unsigned int, AtlasStatement* >* >::const_iterator itEnd = m_mapProcedures.end( );

	while ( itEnd != it )
	{
		map< unsigned int, AtlasStatement* >::const_iterator it2 = it->second->begin( );
		const map< unsigned int, AtlasStatement* >::const_iterator it2End = it->second->end( );

		while ( it2End != it2 )
		{
			( ( AtlasProcedure* ) it2->second )->SetStatementsParent( );

			++it2;
		}

		++it;
	}
}

void AIXML::AIXML_ToXML( string& strXML, const string& strISO8601Time ) const
{
	strXML += XML::MakeXmlElementNoChildren( XML::enAIXML, 
		XML::MakeXmlAttributeNameValue( XML::anVersion, m_strParserVersion ),
		XML::MakeXmlAttributeNameValue( XML::anCreateDateTime, strISO8601Time ),
		XML::MakeXmlAttributeNameValue( XML::anProcHier, ( m_bProcedureCallHierarchyXML ? XML::avYes : XML::avNo ) ),
		XML::MakeXmlAttributeNameValue( XML::anUnusedProc, ( !m_bExcludeUnused ? XML::avYes : XML::avNo ) ),
		XML::MakeXmlAttributeNameValue( XML::anIEEE1641, ( m_bIEEE1641XML ? XML::avYes : XML::avNo ) ),
		XML::MakeXmlAttributeNameValue( XML::anIEEE260_1, ( m_bIEEE260_1XML ? XML::avYes : XML::avNo ) ) );
}

void AIXML::UUT_ToXML( string& strXML ) const
{
	strXML += XML::MakeXmlElementNoChildren( XML::enUut, 
		XML::MakeXmlAttributeNameValue( XML::anName, m_strUUTName ), 
		XML::MakeXmlAttributeNameValue( XML::anId, m_strUUTId ) ); 
}

void AIXML::AtlasSources_ToXML( string& strXML ) const
{
	const unsigned int uiSize = m_vectAtlasSourceFiles.size( );

	if ( uiSize > 0 )
	{
		strXML += XML::MakeOpenXmlElementWithChildren( XML::enSoureFiles, XML::MakeXmlAttributeNameValue( XML::anCount, uiSize ) ); 

		for ( unsigned int ui = 0; ui < uiSize; ++ui )
		{
			const pair< string, Atlas::AtlasSourceStatement::eSourceType >& pr = m_vectAtlasSourceFiles[ ui ];

			strXML += XML::MakeXmlElementNoChildren( XML::enFile, 
				XML::MakeXmlAttributeNameValue( XML::anName, pr.first ), 
				XML::MakeXmlAttributeNameValue( XML::anType, Atlas::AtlasSourceStatement::GetSourceTypeName( pr.second ) ) ); 
		}

		strXML += XML::MakeCloseXmlElementWithChildren( XML::enSoureFiles );
	}
}

void AIXML::Signals_ToXML( string& strXML ) const
{
	if ( m_AtlasSignalInfo.GetSignalCount( ) > 0 )
	{
		m_AtlasSignalInfo.ToXML( strXML, m_bExcludeUnused );
	}
}

void AIXML::Comments_ToXML( string& strXML ) const
{
	if ( m_mapComments.size( ) > 0 )
	{
		if ( m_bExcludeUnused )
		{
			map< string, pair< Atlas::AtlasSourceStatement::eSourceType, vector< AtlasStatement* >* > >::const_iterator it = m_mapComments.begin( );
			const map< string, pair< Atlas::AtlasSourceStatement::eSourceType, vector< AtlasStatement* >* > >::const_iterator itEnd = m_mapComments.end( );
	
			strXML += XML::MakeOpenXmlElementWithChildren( XML::enComments, XML::MakeXmlAttributeNameValue( XML::anCount, m_mapComments.size( ) ) ); 
	
			while ( itEnd != it )
			{
				unsigned int uiSize = it->second.second->size( );

				if ( uiSize > 0 )
				{
					unsigned int uiTemp = 0;

					for ( unsigned int ui = 0; ui < uiSize; ++ui )
					{
						AtlasStatement* pStatement = it->second.second->at( ui );

						if ( !pStatement->m_strParentProcedureName.empty( ) || ( pStatement->m_uiParentProcedureId > 0 ) )
						{
							if ( IsProcedureUsed( pStatement->m_strParentProcedureName, pStatement->m_uiParentProcedureId ) )
							{
								++uiTemp;
							}
						}
						else
						{
							++uiTemp;
						}
					}

					uiSize = uiTemp;
				}
	
				if ( uiSize > 0 )
				{
					strXML += XML::MakeOpenXmlElementWithChildren( XML::enFile, 
						XML::MakeXmlAttributeNameValue( XML::anName, it->first ), 
						XML::MakeXmlAttributeNameValue( XML::anFileType, Atlas::AtlasSourceStatement::GetSourceTypeName( it->second.first ) ),
						XML::MakeXmlAttributeNameValue( XML::anCount, uiSize ) ); 
	
					for ( unsigned int ui = 0; ui < uiSize; ++ui )
					{
						AtlasStatement* pStatement = it->second.second->at( ui );
						bool bToXML = true;

						if ( !pStatement->m_strParentProcedureName.empty( ) || ( pStatement->m_uiParentProcedureId > 0 ) )
						{
							if ( !IsProcedureUsed( pStatement->m_strParentProcedureName, pStatement->m_uiParentProcedureId ) )
							{
								bToXML = false;
							}
						}

						if ( bToXML )
						{
							pStatement->ToXML( strXML );
						}
					}
	
					strXML += XML::MakeCloseXmlElementWithChildren( XML::enFile );
				}
	
				++it;
			}
	
			strXML += XML::MakeCloseXmlElementWithChildren( XML::enComments );
		}
		else
		{
			map< string, pair< Atlas::AtlasSourceStatement::eSourceType, vector< AtlasStatement* >* > >::const_iterator it = m_mapComments.begin( );
			const map< string, pair< Atlas::AtlasSourceStatement::eSourceType, vector< AtlasStatement* >* > >::const_iterator itEnd = m_mapComments.end( );
	
			strXML += XML::MakeOpenXmlElementWithChildren( XML::enComments, XML::MakeXmlAttributeNameValue( XML::anCount, m_mapComments.size( ) ) ); 
	
			while ( itEnd != it )
			{
				const unsigned int uiSize = it->second.second->size( );
	
				if ( uiSize > 0 )
				{
					strXML += XML::MakeOpenXmlElementWithChildren( XML::enFile, 
						XML::MakeXmlAttributeNameValue( XML::anName, it->first ), 
						XML::MakeXmlAttributeNameValue( XML::anFileType, Atlas::AtlasSourceStatement::GetSourceTypeName( it->second.first ) ),
						XML::MakeXmlAttributeNameValue( XML::anCount, uiSize ) ); 
	
					for ( unsigned int ui = 0; ui < uiSize; ++ui )
					{
						it->second.second->at( ui )->ToXML( strXML );
					}
	
					strXML += XML::MakeCloseXmlElementWithChildren( XML::enFile );
				}
	
				++it;
			}
	
			strXML += XML::MakeCloseXmlElementWithChildren( XML::enComments );
		}
	}
}

void AIXML::IPLBlocks_ToXML( string& strXML ) const
{
	vector< AtlasStatement* >* pvectLeaveAtlas = GetStatementVector( Atlas::eLEAVE_ATLAS );

	if ( 0 != pvectLeaveAtlas )
	{
		unsigned int uiIPLBlocks = pvectLeaveAtlas->size( );

		if ( m_bExcludeUnused )
		{
			unsigned int uiTemp = 0;

			for ( unsigned int ui = 0; ui < uiIPLBlocks; ++ui )
			{
				const AtlasStatement* pStatement = pvectLeaveAtlas->at( ui );

				if ( IsProcedureUsed( pStatement->m_strParentProcedureName, pStatement->m_uiParentProcedureId ) )
				{
					++uiTemp;
				}
			}

			if ( uiTemp < uiIPLBlocks )
			{
				uiIPLBlocks = uiTemp;
			}
		}


		if ( uiIPLBlocks > 0 )
		{
			strXML += XML::MakeOpenXmlElementWithChildren( XML::enIPLBlocks, XML::MakeXmlAttributeNameValue( XML::anCount, uiIPLBlocks ) ); 

			for ( unsigned int ui = 0; ui < uiIPLBlocks; ++ui )
			{
				const AtlasLeaveResume* pLeave = ( AtlasLeaveResume* ) pvectLeaveAtlas->at( ui );

				if ( IsProcedureUsed( pLeave->m_strParentProcedureName, pLeave->m_uiParentProcedureId ) )
				{
					if ( 0 != pLeave->m_pvectIPL )
					{
						const unsigned int uiIPLBlock = pLeave->m_pvectIPL->size( );
	
						if ( uiIPLBlock > 0 )
						{
							strXML += XML::MakeOpenXmlElementWithChildren( XML::enIPLBlock, XML::MakeXmlAttributeNameValue( XML::anId, pLeave->m_uiIPLRefId ), XML::MakeXmlAttributeNameValue( XML::anCount, uiIPLBlock ) ); 
	
							const Atlas::AtlasSourceStatement* pSourceInfo = pLeave->GetSourceInfo( );
	
							if ( 0 != pSourceInfo )
							{
								Atlas::AtlasSourceStatement ss( *pSourceInfo );
	
								unsigned int uiFields = Atlas::AtlasSourceStatement::eXmlFilename;
						
								uiFields |= Atlas::AtlasSourceStatement::eXmlLineNumber;
								uiFields |= Atlas::AtlasSourceStatement::eXmlSourceType;
								uiFields |= Atlas::AtlasSourceStatement::eXmlProcname;
	
								ss.SetLineNumber( pLeave->m_IPLStartLine );
						
								strXML += ss.ToXML( uiFields );
							}
		
							strXML += XML::MakeOpenXmlElementWithChildren( XML::enIPLs ); 
	
							for ( unsigned int ui2 = 0; ui2 < uiIPLBlock; ++ui2 )
							{
								const pair< unsigned int, string >& pr = pLeave->m_pvectIPL->at( ui2 );
	
								strXML += XML::MakeXmlElementNoChildrenWithTextNode( XML::enIPL, pr.second );
							}
	
							strXML += XML::MakeCloseXmlElementWithChildren( XML::enIPLs );
		
							strXML += XML::MakeCloseXmlElementWithChildren( XML::enIPLBlock );
						}
					}
				}
			}

			strXML += XML::MakeCloseXmlElementWithChildren( XML::enIPLBlocks );
		}
	}
}

void AIXML::BuiltIns_ToXML( string& strXML ) const
{
	unsigned int uiBuiltIns = 0;

	if ( m_bExcludeUnused )
	{
		map< Atlas::AtlasData::eBuiltInType, AtlasDeclareData* >::const_iterator it = m_mapBuiltinDeclares.begin( );
		const map< Atlas::AtlasData::eBuiltInType, AtlasDeclareData* >::const_iterator itEnd = m_mapBuiltinDeclares.end( );

		while ( itEnd != it )
		{
			if ( it->second->m_uiUseCount > 0 )
			{
				++uiBuiltIns;
			}

			++it;
		}
	}
	else
	{
		uiBuiltIns = m_mapBuiltinDeclares.size( );
	}

	if ( uiBuiltIns > 0 )
	{
		map< Atlas::AtlasData::eBuiltInType, AtlasDeclareData* >::const_iterator it = m_mapBuiltinDeclares.begin( );
		const map< Atlas::AtlasData::eBuiltInType, AtlasDeclareData* >::const_iterator itEnd = m_mapBuiltinDeclares.end( );

		strXML += XML::MakeOpenXmlElementWithChildren( XML::enBuiltInDeclares, XML::MakeXmlAttributeNameValue( XML::anCount, uiBuiltIns ) ); 

		while ( itEnd != it )
		{
			if ( m_bExcludeUnused )
			{
				if ( it->second->m_uiUseCount > 0 )
				{
					strXML += it->second->ToXML( XML::enDeclare );
				}
			}
			else
			{
				strXML += it->second->ToXML( XML::enDeclare );
			}

			++it;
		}

		strXML += XML::MakeCloseXmlElementWithChildren( XML::enBuiltInDeclares );
	}
}

void AIXML::Declares_ToXML( string& strXML ) const
{
	if ( m_mapDeclares.size( ) > 0 )
	{
		map< string, vector< AtlasDeclareData* >* >::const_iterator it = m_mapDeclares.begin( );
		const map< string, vector< AtlasDeclareData* >* >::const_iterator itEnd = m_mapDeclares.end( );
		unsigned int uiDeclares = 0;

		while ( itEnd != it )
		{
			const vector< AtlasDeclareData* >* pvectDeclares = it->second;
			const unsigned int uiSize = pvectDeclares->size( );

			for ( unsigned int ui = 0; ui < uiSize; ++ui )
			{
				AtlasDeclareData* pAtlasDeclareData = pvectDeclares->at( ui );

				if ( !pAtlasDeclareData->m_Declare.IsExternal( ) )
				{
					if ( m_bExcludeUnused )
					{
						if ( IsDeclareUsed( pAtlasDeclareData ) )
						{
							++uiDeclares;
						}
					}
					else
					{
						++uiDeclares;
					}
				}
			}

			++it;
		}

		if ( uiDeclares > 0 )
		{
			it = m_mapDeclares.begin( );

			strXML += XML::MakeOpenXmlElementWithChildren( XML::enDeclares, XML::MakeXmlAttributeNameValue( XML::anCount, uiDeclares ) ); 

			while ( itEnd != it )
			{
				const vector< AtlasDeclareData* >* pvectDeclares = it->second;
				const unsigned int uiSize = pvectDeclares->size( );
	
				for ( unsigned int ui = 0; ui < uiSize; ++ui )
				{
					AtlasDeclareData* pAtlasDeclareData = pvectDeclares->at( ui );

					if ( !pAtlasDeclareData->m_Declare.IsExternal( ) )
					{
						const bool bUsed = IsDeclareUsed( pAtlasDeclareData );
						string strUnused;

						if ( !m_bExcludeUnused )
						{
							if ( !bUsed )
							{
								strUnused = XML::MakeXmlAttributeNameValue( XML::anUnused, XML::avTrue );
							}
						}

						strXML += XML::MakeOpenXmlElementWithChildren( XML::enDeclare, pAtlasDeclareData->m_Declare.ToXML( pAtlasDeclareData->m_Source.GetId( ), pAtlasDeclareData->m_Source.GetCommentId( ) ), strUnused ); 

						strXML += pAtlasDeclareData->m_Source.ToXML( Atlas::AtlasSourceStatement::eXmlAll );
						strXML += pAtlasDeclareData->Assignments_ToXML( );

						strXML += XML::MakeCloseXmlElementWithChildren( XML::enDeclare );
					}
			}
	
				++it;
			}

			strXML += XML::MakeCloseXmlElementWithChildren( XML::enDeclares );
		}
	}
}

void AIXML::SignalOrientedStatements_ToXML( string& strXML ) const
{
	strXML += XML::MakeOpenXmlElementWithChildren( XML::enSignalOrientedStatements );
		Statements_ToXML( strXML, XML::enApplyStatement,		XML::enApplies,		GetStatementVector( Atlas::eAPPLY ) );
		Statements_ToXML( strXML, XML::enArmStatement,			XML::enArms,		GetStatementVector( Atlas::eARM ) );
		Statements_ToXML( strXML, XML::enChangeStatement,		XML::enChanges,		GetStatementVector( Atlas::eCHANGE ) );
		Statements_ToXML( strXML, XML::enCloseStatement,		XML::enCloses,		GetStatementVector( Atlas::eCLOSE ) );
		Statements_ToXML( strXML, XML::enConnectStatement,		XML::enConnects,	GetStatementVector( Atlas::eCONNECT ) );
		Statements_ToXML( strXML, XML::enDisconnectStatement,	XML::enDisconnects,	GetStatementVector( Atlas::eDISCONNECT ) );
		Statements_ToXML( strXML, XML::enFetchStatement,		XML::enFetches,		GetStatementVector( Atlas::eFETCH ) );
		Statements_ToXML( strXML, XML::enInitiateStatement,		XML::enInitiates,	GetStatementVector( Atlas::eINITIATE ) );
		Statements_ToXML( strXML, XML::enMeasureStatement,		XML::enMeasures,	GetStatementVector( Atlas::eMEASURE ) );
		Statements_ToXML( strXML, XML::enMonitorStatement,		XML::enMonitor,		GetStatementVector( Atlas::eMONITOR ) );
		Statements_ToXML( strXML, XML::enOpenStatement,			XML::enOpen,		GetStatementVector( Atlas::eOPEN ) );
		Statements_ToXML( strXML, XML::enReadStatement,			XML::enReads,		GetStatementVector( Atlas::eREAD ) );
		Statements_ToXML( strXML, XML::enRemoveStatement,		XML::enRemoves,		GetStatementVector( Atlas::eREMOVE ) );
		Require_ToXML( strXML );
		Statements_ToXML( strXML, XML::enResetStatement,		XML::enResets,		GetStatementVector( Atlas::eRESET ) );
		Statements_ToXML( strXML, XML::enSetupStatement,		XML::enSetups,		GetStatementVector( Atlas::eSETUP ) );
		Statements_ToXML( strXML, XML::enVerifyStatement,		XML::enVerifies,	GetStatementVector( Atlas::eVERIFY ) );
	strXML += XML::MakeCloseXmlElementWithChildren( XML::enSignalOrientedStatements );
}

void AIXML::ProgramTree_ToXML( const string& strISO8601Time )
{
	if ( m_bProcedureCallHierarchyXML && !m_strProcHierOutputFilename.empty( ) )
	{
		if ( m_ProgramTree.size( ) > 0 )
		{
			string strXML;

			strXML.reserve( 1000000 );

			strXML += XML::GetXmlVersionAndEncoding( m_strXMLVersion, m_strXMLEncoding );

			strXML += XML::MakeOpenXmlElementWithChildren( XML::enAtlas, XML::MakeXmlAttributeNameValue( XML::anProgramName, m_strAtlasProgramName ), XML::MakeXmlAttributeNameValue( XML::anType, m_eStationType ) );
				AIXML_ToXML( strXML, strISO8601Time );
				UUT_ToXML( strXML );
				AtlasSources_ToXML( strXML );
				strXML += XML::MakeOpenXmlElementWithChildren( XML::enProcedureCallHierarchy, XML::MakeXmlAttributeNameValue( XML::anCount, m_ProgramTree.size( ) ) );
					m_ProgramTree.ToXML( strXML, m_MainSourceStatement.GetId( ), true );
				strXML += XML::MakeCloseXmlElementWithChildren( XML::enProcedureCallHierarchy );
			strXML += XML::MakeCloseXmlElementWithChildren( XML::enAtlas );

			m_xmlProcHierOutFile << strXML;
		}
		else if ( 1 == m_uiUsedProcCount ) // No procedures defined, just the main procedural structure
		{
			string strXML;

			strXML.reserve( 10000 );

			strXML += XML::GetXmlVersionAndEncoding( m_strXMLVersion, m_strXMLEncoding );

			strXML += XML::MakeOpenXmlElementWithChildren( XML::enAtlas, XML::MakeXmlAttributeNameValue( XML::anProgramName, m_strAtlasProgramName ), XML::MakeXmlAttributeNameValue( XML::anType, m_eStationType ) );
				AIXML_ToXML( strXML, strISO8601Time );
				UUT_ToXML( strXML );
				AtlasSources_ToXML( strXML );
				strXML += XML::MakeOpenXmlElementWithChildren( XML::enProcedureCallHierarchy, XML::MakeXmlAttributeNameValue( XML::anCount, 1 ) );
					strXML += XML::MakeXmlElementNoChildren( XML::enPerform, 
						XML::MakeXmlAttributeNameValue( XML::anName, AtlasStatement::m_strMAIN_PROC_NAME ), 
						XML::MakeXmlAttributeNameValue( XML::anProcRefId, m_uiMainProcId ), 
						XML::MakeXmlAttributeNameValue( XML::anCount, 0 ) ); 
				strXML += XML::MakeCloseXmlElementWithChildren( XML::enProcedureCallHierarchy );
			strXML += XML::MakeCloseXmlElementWithChildren( XML::enAtlas );

			m_xmlProcHierOutFile << strXML;
		}
	}
}

void AIXML::Procedures_ToXML( string& strXML ) const
{
	if ( m_mapProcedures.size( ) > 0 )
	{
		map< string, map< unsigned int, AtlasStatement* >* >::const_iterator it = m_mapProcedures.begin( );
		const map< string, map< unsigned int, AtlasStatement* >* >::const_iterator itEnd = m_mapProcedures.end( );
		unsigned int uiProcedures = 0;
		string strUnusedCount;

		if ( m_bExcludeUnused )
		{
			while ( itEnd != it )
			{
				map< unsigned int, AtlasStatement* >::const_iterator it2 = it->second->begin( );
				const map< unsigned int, AtlasStatement* >::const_iterator it2End = it->second->end( );

				while ( it2End != it2 )
				{
					if ( ( ( AtlasProcedure* ) it2->second )->m_bUsed )
					{
						++uiProcedures;
					}

					++it2;
				}
	
				++it;
			}
		}
		else
		{
			while ( itEnd != it )
			{
				uiProcedures += it->second->size( );
	
				++it;
			}
		}

		it = m_mapProcedures.begin( );

		if ( !m_bExcludeUnused )
		{
			if ( uiProcedures > m_uiUsedProcCount )
			{
				strUnusedCount = XML::MakeXmlAttributeNameValue( XML::anUnusedCount, ( uiProcedures - m_uiUsedProcCount ) );
			}
		}

		strXML += XML::MakeOpenXmlElementWithChildren( XML::enProcedures, 
			XML::MakeXmlAttributeNameValue( XML::anCount, uiProcedures ), 
			strUnusedCount ); 

		while ( itEnd != it )
		{
			const map< unsigned int, AtlasStatement* >* pmapProcs = it->second;
			map< unsigned int, AtlasStatement* >::const_iterator it2 = pmapProcs->begin( );
			const map< unsigned int, AtlasStatement* >::const_iterator it2End = pmapProcs->end( );

			while ( it2End != it2 )
			{
				AtlasProcedure* pProcedure = ( AtlasProcedure* ) it2->second;
				bool bXML = true;

				if ( m_bExcludeUnused )
				{
					if ( !pProcedure->m_bUsed )
					{
						bXML = false;
					}
				}

				if ( bXML )
				{
					if ( pProcedure->m_bMainProcedure )
					{
						pProcedure->ToXML( strXML, &m_setEntryPointIds );
					}
					else
					{
						pProcedure->ToXML( strXML );
					}
				}

				++it2;
			}

			++it;
		}

		strXML += XML::MakeCloseXmlElementWithChildren( XML::enProcedures );
	}
}

void AIXML::BuildProcedures( void )
{
	const DOMElement* pPrimaryProcedurePath = AIXMLHelper::FindElementPath( m_pRoot, m_arrayXPath[ ePrimaryPreamblePath ], false );

	if ( 0 != pPrimaryProcedurePath )
	{
		GetProcedureStatements( pPrimaryProcedurePath, m_strPrimaryAtlasFilename, Atlas::AtlasSourceStatement::eAtlasProgram );
	
		const DOMElement* pIncludes = AIXMLHelper::FindElementPath( m_pRoot, m_arrayXPath[ eIncludeStatementsPath ], false );
	
		if ( 0 != pIncludes )
		{
			const xercesc::DOMElement* pAIXMLvalue = pIncludes->getFirstElementChild( );
		
			if ( 0 == pAIXMLvalue )
			{
				throw Exception( Exception::eFailedToGetChildNodes, __FILE__, __FUNCTION__, __LINE__ );
			}
		
			while ( 0 != pAIXMLvalue )
			{
				const DOMElement* pPreamble = AIXMLHelper::FindElementPath( pAIXMLvalue, m_arrayXPath[ eIncludeAtlasModulePreamblePath ], false );
	
				if ( 0 != pPreamble )
				{
					const DOMElement* pBeginAtlasModule = pPreamble->getPreviousElementSibling( );
					string strFilename;

					if ( 0 != pBeginAtlasModule )
					{
						const xercesc::DOMElement* pModuleName = pBeginAtlasModule->getFirstElementChild( );

						if ( 0 != pModuleName )
						{
							const DOMAttr* pAttr = pModuleName->getAttributeNode( AIXMLHelper::GetWString( m_arrayXMLKeyWords[ eNameAttribute ] ).c_str( ) );
		
							if ( 0 != pAttr )
							{
								AIXMLHelper::GetXercesString( pAttr->getValue( ), strFilename );

								VerifyIfExtension( strFilename );

								strFilename = AIXMLHelper::StripPath( strFilename );
							}
						}
					}

					GetProcedureStatements( pPreamble, strFilename, Atlas::AtlasSourceStatement::eAtlasModule );
				}
				else
				{
					const xercesc::DOMElement* pBeginNonAtlasModule = pAIXMLvalue->getFirstElementChild( );
				
					if ( 0 != pBeginNonAtlasModule )
					{
						string strAIXMLtagName;
		
						AIXMLHelper::GetXercesString( pBeginNonAtlasModule->getTagName( ), strAIXMLtagName );

						if ( m_arrayXMLKeyWords[ eIncludeNonAtlasModuleElement ] == strAIXMLtagName )
						{
							const xercesc::DOMElement* pAtlasNonModuleName = pBeginNonAtlasModule->getFirstElementChild( );
	
							if ( 0 != pAtlasNonModuleName )
							{
								const DOMAttr* pAttr = pAtlasNonModuleName->getAttributeNode( AIXMLHelper::GetWString( m_arrayXMLKeyWords[ eNameAttribute ] ).c_str( ) );
			
								if ( 0 != pAttr )
								{
									string strFilename;

									AIXMLHelper::GetXercesString( pAttr->getValue( ), strFilename );

									if ( !strFilename.empty( ) )
									{
										m_setNonAtlasProcedures.insert( strFilename );
									}
								}
							}
						}
					}
				}
		
				pAIXMLvalue = pAIXMLvalue->getNextElementSibling( );
			}
		}

		vector< AtlasStatement* >* pvectProcedures = 0;
			
		try
		{
			pvectProcedures = new vector< AtlasStatement* >( );
		}
		catch ( ... )
		{
			throw Exception( Exception::eFailedToCreateVectorObject, __FILE__, __FUNCTION__, __LINE__ );
		}
		m_mapStatements.insert( make_pair( Atlas::eDEFINE_PROCEDURE, pvectProcedures ) );



		AtlasProcedure* pProcedure = 0;
		try { pProcedure = new AtlasProcedure; } catch ( ... ) { throw Exception( Exception::eFailedToAllocateMemoryForNewStatementObject, __FILE__, __FUNCTION__, __LINE__ ); }
		pvectProcedures->push_back( pProcedure );
		pProcedure->m_bMainProcedure = true;
		pProcedure->m_bUsed = true;
		pProcedure->m_eScope = AtlasStatement::eLocal;
		pProcedure->m_strProcedureName = AtlasStatement::m_strMAIN_PROC_NAME;
		pProcedure->m_pStatementsElement = m_pMainStatements;
		pProcedure->SetSourceStatementInfo( pProcedure->m_EndStatement, m_pTerminateStatement, m_MainSourceStatement.GetSourceType( ), m_MainSourceStatement.GetFilename( ), string( ) );
		pProcedure->m_EndStatement.SetAtlasStatement( Atlas::eTERMINATE_ATLAS_PROGRAM );
		pProcedure->InitFromXML( m_pMainStatements, m_MainSourceStatement.GetSourceType( ), m_MainSourceStatement.GetFilename( ) );
		pProcedure->m_uiStatementsId = pProcedure->m_uiId;
		m_MainSourceStatement.SetId( pProcedure->m_uiId );
		if ( m_MainSourceStatement.GetFilename( ).empty( ) )
		{
			m_MainSourceStatement.SetFilename( m_strPrimaryAtlasFilename );
		}
		if ( 0 == pProcedure->m_vectAtlasSourceStatement.size( ) )
		{
			pProcedure->m_vectAtlasSourceStatement.push_back( m_MainSourceStatement );
		}
		else
		{
			pProcedure->m_vectAtlasSourceStatement[ 0 ] = m_MainSourceStatement;
		}
		m_uiMainProcId = pProcedure->m_uiId;


		if ( m_mapAllProcedures.size( ) > 0 )
		{
			map< string, vector< pair< Atlas::AtlasSourceStatement::eSourceType, const xercesc::DOMElement* > > >::const_iterator it = m_mapAllProcedures.begin( );
			const map< string, vector< pair< Atlas::AtlasSourceStatement::eSourceType, const xercesc::DOMElement* > > >::const_iterator itEnd = m_mapAllProcedures.end( );
	
			while ( itEnd != it )
			{
				const string& strFilename = it->first;
				const vector< pair< Atlas::AtlasSourceStatement::eSourceType, const xercesc::DOMElement* > >& vectProcedures = it->second;
				const unsigned int uiProcedureCount = vectProcedures.size( );
				const set< string >::const_iterator itNonAtlasEnd = m_setNonAtlasProcedures.end( );
				auto_ptr< AtlasProcedure > proc;
	
				for ( unsigned int ui = 0; ui < uiProcedureCount; ++ui )
				{
					const pair< Atlas::AtlasSourceStatement::eSourceType, const xercesc::DOMElement* >& pr = vectProcedures[ ui ];
	
					try
					{
						pProcedure = new AtlasProcedure;
					}
					catch ( ... )
					{
						throw Exception( Exception::eFailedToAllocateMemoryForNewStatementObject, __FILE__, __FUNCTION__, __LINE__ );
					}

					bool bPushBack = true;

					proc.reset( pProcedure );

					pProcedure->InitFromXML( pr.second, pr.first, it->first );

					if ( AtlasStatement::eExternal == pProcedure->m_eScope )
					{
						bPushBack = false;

						if ( itNonAtlasEnd != m_setNonAtlasProcedures.find( pProcedure->m_strProcedureName ) )
						{
							bPushBack = true;
						}
						else
						{
							const map< string, set< unsigned int >* >::const_iterator itExternal = m_mapExternalProcedures.find( pProcedure->m_strProcedureName );

							if ( m_mapExternalProcedures.end( ) == itExternal )
							{
								set< unsigned int >* pSet = 0;
									
								try
								{
									pSet = new set< unsigned int >( );
								}
								catch ( ... )
								{
									throw Exception( Exception::eFailedToCreateProcedureSet, __FILE__, __FUNCTION__, __LINE__ );
								}

								m_mapExternalProcedures.insert( make_pair( pProcedure->m_strProcedureName, pSet ) );

								pSet->insert( pProcedure->m_uiId );
							}
							else
							{
								itExternal->second->insert( pProcedure->m_uiId );
							}
						}
					}

					if ( bPushBack )
					{
						if ( 0 != pvectProcedures )
						{
							pvectProcedures->push_back( pProcedure );
						}
					}
					else
					{
						delete pProcedure;
					}

					proc.release( );
				}
	
				++it;
			}

			if ( 0 != pvectProcedures )
			{
				const unsigned int uiSize = pvectProcedures->size( );
	
				if ( uiSize > 0 )
				{
					for ( unsigned int ui = 0; ui < uiSize; ++ui )
					{
						pvectProcedures->at( ui )->Process( m_pMergedLookup );
					}
				}
			}

			m_mapAllProcedures.clear( );
		}
	}
}

void AIXML::BuildConditionalStatements( const Atlas::eAtlasStatement eStatement )
{
	const DOMStatements* pDOMStatements = 0;
	vector< AtlasStatement* >* pvectConditional = 0;
	const unsigned int uiConditionalCount = CreateStatementVector( eStatement, &pDOMStatements, &pvectConditional );

	if ( uiConditionalCount > 0 )
	{
		for ( unsigned int ui = 0; ui < uiConditionalCount; ++ui )
		{
			const StatementMetadata* pdata = pDOMStatements->m_vectStatements[ ui ];

			AtlasCondition* pCondition = 0;
			
			try
			{
				pCondition = new AtlasCondition( eStatement, pdata->m_uiConditionalNestLevel );
			}
			catch ( ... )
			{
				throw Exception( Exception::eFailedToAllocateMemoryForAtlasConditionalObject, __FILE__, __FUNCTION__, __LINE__ );
			}

			pvectConditional->push_back( pCondition );

			pCondition->InitFromXML( pdata );

			if ( Atlas::eELSE != eStatement )
			{
				// ELSEs don't need any further processing

				pCondition->Process( m_pMergedLookup );
			}
		}

		sort( pvectConditional->begin( ), pvectConditional->end( ), CompareConditional( ) );
	}
}

void AIXML::BuildLeaveStatements( const Atlas::eAtlasStatement eStatement )
{
	const DOMStatements* pDOMStatements = 0;
	vector< AtlasStatement* >* pvectLeave = 0;
	const unsigned int uiLeaveCount = CreateStatementVector( eStatement, &pDOMStatements, &pvectLeave );

	if ( uiLeaveCount > 0 )
	{
		for ( unsigned int ui = 0; ui < uiLeaveCount; ++ui )
		{
			const StatementMetadata* pdata = pDOMStatements->m_vectStatements[ ui ];

			AtlasLeave* pStatement = 0;
				
			try
			{
				pStatement = new AtlasLeave( eStatement );
			}
			catch ( ... )
			{
				throw Exception( Exception::eFailedToAllocateMemoryForAtlasStatementObject, __FILE__, __FUNCTION__, __LINE__ );
			}

			pvectLeave->push_back( pStatement );

			pStatement->InitFromXML( pdata );
			pStatement->Process( m_pMergedLookup );
		}
	}
}

void AIXML::BuildUnhandledStatements( void )
{
	map< Atlas::eAtlasStatement, DOMStatements* >::const_iterator it = m_mapDOMElementStatements.begin( );
	const map< Atlas::eAtlasStatement, DOMStatements* >::const_iterator itEnd = m_mapDOMElementStatements.end( );

	while ( itEnd != it )
	{
		if ( Atlas::eCOMMENT != it->first )
		{
			if ( 0 == GetStatementVector( it->first ) )
			{
				const DOMStatements* pdomStatements = it->second;
				const unsigned uiSize = pdomStatements->m_vectStatements.size( );
	
				if ( uiSize > 0 )
				{
					AtlasUnhandledStatement* pStatement = 0;
					XML::ElementName eName = XML::enUnknown;
					vector< AtlasStatement* >* pvectStatements = 0;
					
					try
					{
						pvectStatements = new vector< AtlasStatement* >( );
					}
					catch ( ... )
					{
						throw Exception( Exception::eFailedToCreateVectorObject, __FILE__, __FUNCTION__, __LINE__ );
					}
			
					m_mapStatements.insert( make_pair( it->first, pvectStatements ) );
	
					const pair< XML::ElementName, XML::ElementName >* pPair = GetAtlasStatementXMLElementNames( it->first );
	
					if ( 0 != pPair )
					{
						eName = pPair->second;
					}
	
					for ( unsigned int ui = 0; ui < uiSize; ++ui )
					{
						const StatementMetadata* pdata = pdomStatements->m_vectStatements[ ui ];
	
						try
						{
							pStatement = new AtlasUnhandledStatement( it->first, eName );
						}
						catch ( ... )
						{
							throw Exception( Exception::eFailedToAllocateMemoryForNewStatementObject, __FILE__, __FUNCTION__, __LINE__ );
						}
		
						pvectStatements->push_back( pStatement );
	
						pStatement->InitFromXML( pdata );
					}
				}
			}
		}

		++it;
	}
}

vector< AtlasStatement* >* AIXML::GetStatementVector( const Atlas::eAtlasStatement eStatement ) const
{
	vector< AtlasStatement* >* pVect = 0;

	const map< const Atlas::eAtlasStatement, vector< AtlasStatement* >* >::const_iterator it = m_mapStatements.find( eStatement );

	if ( m_mapStatements.end( ) != it )
	{
		pVect = it->second;
	}

	return pVect;
}

const DOMStatements* AIXML::GetDOMStatements( const Atlas::eAtlasStatement eStatement )
{
	const map< Atlas::eAtlasStatement, DOMStatements* >::const_iterator it = m_mapDOMElementStatements.find( eStatement );
	const DOMStatements* pDOMStatements = 0;

	if ( m_mapDOMElementStatements.end( ) != it )
	{
		pDOMStatements = it->second;
	}

	return pDOMStatements;
}

void AIXML::VerifyIfExtension( string& strFilename )
{
	if ( !strFilename.empty( ) )
	{
		if ( !m_strAtlasFileExtension.empty( ) )
		{
			if ( string::npos == strFilename.find_last_of( AtlasStatement::m_strDot ) )
			{
				strFilename += AtlasStatement::m_strDot;
				strFilename += m_strAtlasFileExtension;
			}
		}
	}
}

const AtlasStatement* AIXML::GetScopedProcedure( const AtlasStatement* pStatement, const map< unsigned int, AtlasStatement* >* pmapProcs ) const
{
	const AtlasStatement* pScopedProc = 0;

	if ( 0 != pStatement )
	{
		const Atlas::AtlasSourceStatement* pStatementSource = pStatement->GetSourceInfo( );

		if ( 0 != pStatementSource )
		{
			map< unsigned int, AtlasStatement* >::const_iterator it = pmapProcs->begin( );
			const map< unsigned int, AtlasStatement* >::const_iterator itEnd = pmapProcs->end( );
			const string& strStatementFilename = pStatementSource->GetFilename( );
			const AtlasProcedure* pGlobalProcedure = 0;
			const AtlasProcedure* pLocalProcedure = 0;

			while ( itEnd != it )
			{
				AtlasProcedure* pProcedure = ( AtlasProcedure* ) it->second;

				if ( AtlasStatement::eGlobal == pProcedure->m_eScope )
				{
					pGlobalProcedure = pProcedure;
				}

				const Atlas::AtlasSourceStatement* pProcedureSource = pProcedure->GetSourceInfo( );

				if ( 0 != pProcedureSource )
				{
					if ( strStatementFilename == pProcedureSource->GetFilename( ) )
					{
						pLocalProcedure = pProcedure;
						break;
					}
				}



				++it;
			}

			if ( 0 != pLocalProcedure )
			{
				pScopedProc = pLocalProcedure;
			}
			else if ( 0 != pGlobalProcedure )
			{
				pScopedProc = pGlobalProcedure;
			}
			#if ( _DEBUG ) && ( WIN32 )
			else
			{
				DebugBreak( );
			}
			#endif
		}
	}

	return pScopedProc;
}

const AtlasStatement* AIXML::GetProcedure( const string strProcName, const unsigned int uiProcedureId ) const
{
	const map< string, map< unsigned int, AtlasStatement* >* >::const_iterator it = m_mapProcedures.find( strProcName );
	const AtlasStatement* pProcedure = 0;

	if ( m_mapProcedures.end( ) != it )
	{
		const map< unsigned int, AtlasStatement* >* pmapProcs = it->second;
		const map< unsigned int, AtlasStatement* >::const_iterator it2 = pmapProcs->find( uiProcedureId );

		if ( pmapProcs->end( ) != it2 )
		{
			pProcedure = it2->second;
		}
		#if ( _DEBUG ) && ( WIN32 )
		else
		{
			DebugBreak( );
		}
		#endif
	}

	return pProcedure;
}

void AIXML::CreateBuiltInVariables( void )
{
	CreateBuiltInVariable( "NOGO",		Atlas::eBOOLEAN, Atlas::AtlasData::eNoGo );
	CreateBuiltInVariable( "GO",		Atlas::eBOOLEAN, Atlas::AtlasData::eGo );
	CreateBuiltInVariable( "MAX-TIME",	Atlas::eBOOLEAN, Atlas::AtlasData::eMaxTime );
	CreateBuiltInVariable( "LO",		Atlas::eBOOLEAN, Atlas::AtlasData::eLo );
	CreateBuiltInVariable( "HI",		Atlas::eBOOLEAN, Atlas::AtlasData::eHi );
	CreateBuiltInVariable( "TRUE",		Atlas::eBOOLEAN, Atlas::AtlasData::eTrue );
	CreateBuiltInVariable( "FALSE",		Atlas::eBOOLEAN, Atlas::AtlasData::eFalse );
}

void AIXML::CreateBuiltInVariable( const string& strName, const Atlas::eDataType dataType, const Atlas::AtlasData::eBuiltInType builtinType )
{
	Atlas::AtlasSourceStatement source( GetNextId( ) );
	Atlas::AtlasDeclare declare;
	AtlasDeclareData* pDeclareData = 0;
	
	declare.m_strVarName = strName;
	declare.SetBuiltIn( true );
	declare.m_eDataType = dataType;

	try
	{
		pDeclareData = new AtlasDeclareData( declare, source, builtinType );
	}
	catch ( ... )
	{
		throw Exception( Exception::eFailedToAllocateMemoryForNewDeclareDataObject, __FILE__, __FUNCTION__, __LINE__ );
	}

	m_mapBuiltinDeclares.insert( make_pair( builtinType, pDeclareData ) );
}

void AIXML::GetProcedureStatements( void )
{
	const DOMElement* pPrimaryPreample = AIXMLHelper::FindElementPath( m_pRoot, m_arrayXPath[ ePrimaryPreamblePath ], false );
	if ( 0 != pPrimaryPreample )
	{
		StatementMetadata metaData( pPrimaryPreample, m_strPrimaryAtlasFilename, Atlas::AtlasSourceStatement::eAtlasProgram );

		GetPreampleStatements( &metaData );
	}

	GetMainStatements( );

	GetPreampleIncludeStatements( );
}

Atlas::eAtlasStatement AIXML::GetAtlasStatementEnum( const string& strAtlasStatement )
{
	Atlas::eAtlasStatement eStatement = Atlas::eUnknownAtlasStatement;
	const map< const string*, Atlas::eAtlasStatement, AIXMLHelper::cmpPointer >::const_iterator it = m_mapElementStatmentToAtlasStatementEnum.find( &strAtlasStatement );
	const map< const string*, Atlas::eAtlasStatement, AIXMLHelper::cmpPointer >::const_iterator itEnd = m_mapElementStatmentToAtlasStatementEnum.end( );

	if ( itEnd != it )
	{
		eStatement = it->second;
	}

	return eStatement;
}

const pair< XML::ElementName, XML::ElementName >*AIXML::GetAtlasStatementXMLElementNames( const Atlas::eAtlasStatement eStatement )
{
	const pair< XML::ElementName, XML::ElementName >* ppair = 0;

	const map< Atlas::eAtlasStatement, pair< XML::ElementName, XML::ElementName > >::const_iterator it = m_mapElementStatmentToAtlasStatementXMLElementNames.find( eStatement );
	const map< Atlas::eAtlasStatement, pair< XML::ElementName, XML::ElementName > >::const_iterator itEnd = m_mapElementStatmentToAtlasStatementXMLElementNames.end( );

	if ( itEnd != it )
	{
		ppair = &( it->second );
	}

	return ppair;
}

void AIXML::SetEntryPointId( const xercesc::DOMElement* pStatement )
{
	unsigned int uiEntryPointId = 0;

	if ( 0 != pStatement )
	{
		#if ( _DEBUG ) && ( WIN32 )
		{
			string strAIXMLtagName;

			AIXMLHelper::GetXercesString( pStatement->getTagName( ), strAIXMLtagName );

			if ( Atlas::eUnknownAtlasStatement == GetAtlasStatementEnum( strAIXMLtagName ) )
			{
				DebugBreak( );
			}
		}
		#endif

		const DOMAttr* pIdAttr = pStatement->getAttributeNode( AIXMLHelper::GetWString( m_arrayXMLKeyWords[ eIdAttribute ] ).c_str( ) );

		if ( 0 != pIdAttr )
		{
			uiEntryPointId = AIXMLHelper::StringToNumber< unsigned int >( AIXMLHelper::GetXercesString( pIdAttr->getValue( ) ) );
		}

		if ( 0 != uiEntryPointId )
		{
			m_setEntryPointIds.insert( uiEntryPointId );
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
}

unsigned int AIXML::CreateStatementVector( const Atlas::eAtlasStatement eStatement, const DOMStatements** ppDOMStatements, vector< AtlasStatement* >** ppvect )
{
	unsigned int uiCount = 0;

	*ppDOMStatements = GetDOMStatements( eStatement );

	if ( 0 != *ppDOMStatements )
	{
		uiCount = ( *ppDOMStatements )->m_vectStatements.size( );

		if ( uiCount > 0 )
		{
			try
			{
				*ppvect = new vector< AtlasStatement* >( );
			}
			catch ( ... )
			{
				throw Exception( Exception::eFailedToCreateVectorObject, __FILE__, __FUNCTION__, __LINE__ );
			}

			m_mapStatements.insert( make_pair( eStatement, *ppvect ) );

			( *ppvect )->reserve( uiCount );
		}
	}

	return uiCount;
}

const AtlasRequires* AIXML::GetRequires( const string& strFilename ) const
{
	const map< string, AtlasStatements* >::const_iterator it = m_mapRequiresByFilename.find( strFilename );
	const AtlasRequires* pRequires = 0;

	if ( m_mapRequiresByFilename.end( ) != it )
	{
		pRequires = ( AtlasRequires* ) it->second;
	}

	return pRequires;
}

void AIXML::SetRequireUsed( const string& strVirtualLabel )
{
	if ( !strVirtualLabel.empty( ) )
	{
		const bool bExists = ( m_setVirtualLabelsFoundInRequires.end( ) != m_setVirtualLabelsFoundInRequires.find( strVirtualLabel ) );
	
		if ( !bExists )
		{
			const unsigned uiRequires = m_vectRequires.size( );
			bool bFound = false;
		
			if ( uiRequires > 0 )
			{
				for ( unsigned int ui = 0; ui < uiRequires; ui++ )
				{
					AtlasRequires* pRequires = ( AtlasRequires* ) m_vectRequires[ ui ];
		
					if ( 0 != pRequires )
					{
						AtlasRequire* pRequire = ( AtlasRequire* )  pRequires->GetRequire( strVirtualLabel );
	
						if ( 0 != pRequire )
						{
							m_setVirtualLabelsFoundInRequires.insert( strVirtualLabel );
							pRequire->SetUsed( true );
							bFound = true;
						}
					}
				}
			}
	
			#if ( _DEBUG ) && ( WIN32 )
			if ( !bFound )
			{
				DebugBreak( );
			}
			#endif
		}
	}
}

bool AIXML::IsProcedureUsed( const string& strProcName, const unsigned int uiProcId ) const
{
	bool bIsUsed = ( uiProcId == m_uiMainProcId );

	if ( !bIsUsed )
	{
		const map< string, map< unsigned int, AtlasStatement* >* >::const_iterator itProcs = m_mapProcedures.find( strProcName );
	
		if ( m_mapProcedures.end( ) != itProcs )
		{
			const map< unsigned int, AtlasStatement* >::const_iterator itProc = itProcs->second->find( uiProcId );
	
			if ( itProcs->second->end( ) != itProc )
			{
				bIsUsed = ( ( AtlasProcedure* ) itProc->second )->m_bUsed;
			}
			#if ( _DEBUG ) && ( WIN32 )
			else
			{
				const map< string, set< unsigned int >* >::const_iterator itExternalProcs = m_mapExternalProcedures.find( strProcName );

				if ( m_mapExternalProcedures.end( ) != itExternalProcs )
				{
					const set< unsigned int >::const_iterator itProcId = itExternalProcs->second->find( uiProcId );

					if ( itExternalProcs->second->end( ) == itProcId )
					{
						DebugBreak( );
					}
				}
				else
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

	return bIsUsed;
}

bool AIXML::IsDeclareUsed( const AtlasDeclareData* pDeclareData ) const
{
	bool bIsUsedByProcedure = false;
	const unsigned int uiAssignments = pDeclareData->m_vectAssignments.size( );
	const unsigned int uiSignalOriented = pDeclareData->m_vectSignalOriented.size( );
	const unsigned int uiNonSignalOriented = pDeclareData->m_vectNonSignalOriented.size( );

	if ( ( uiAssignments + uiSignalOriented + uiNonSignalOriented ) > 0 )
	{
		for ( unsigned int ui = 0; ui < 3; ++ui )
		{
			const vector< AtlasStatement* >* pvect = 0;
			const unsigned int* pSize = 0;

			switch ( ui )
			{
				case 0:
					if ( uiAssignments > 0 )
					{
						pvect = &( pDeclareData->m_vectAssignments );
						pSize = &uiAssignments;
					}
					break;

				case 1:
					if ( uiSignalOriented > 0 )
					{
						pvect = &( pDeclareData->m_vectSignalOriented );
						pSize = &uiSignalOriented;
					}
					break;

				case 2:
					if ( uiNonSignalOriented > 0 )
					{
						pvect = &( pDeclareData->m_vectNonSignalOriented );
						pSize = &uiNonSignalOriented;
					}
					break;
			}

			if ( 0 != pvect )
			{
				for ( unsigned int ui2 = 0; ui2 < *pSize; ++ui2 )
				{
					const AtlasStatement* pStatement = pvect->at( ui2 );

					if ( IsProcedureUsed( pStatement->m_strParentProcedureName, pStatement->m_uiParentProcedureId ) )
					{
						bIsUsedByProcedure = true;
						break;
					}
				}
			}

			if ( bIsUsedByProcedure )
			{
				break;
			}
		}
	}

	return bIsUsedByProcedure;
}

bool AIXML::SetComplexSignalUsage( AtlasComplexSignal* pComplexSignal )
{
	bool bIsUsed = false;

	if ( m_mapStatements.size( ) > 0 )
	{
		map< const Atlas::eAtlasStatement, vector< AtlasStatement* >* >::const_iterator it = m_mapStatements.begin( );
		const map< const Atlas::eAtlasStatement, vector< AtlasStatement* >* >::const_iterator itEnd = m_mapStatements.end( );

		while ( itEnd != it )
		{
			if ( Atlas::IsElectricalSignalOrientedStatement( it->first ) )
			{
				vector< AtlasStatement* >* pvect = it->second;
				const unsigned int uiSize = pvect->size( );

				for ( unsigned int ui = 0; ui < uiSize; ++ui )
				{
					const AtlasActionSignalVerb* pStatement = ( AtlasActionSignalVerb* ) pvect->at( ui );

					if ( pStatement->m_bComplexSignal )
					{
						if ( IsProcedureUsed( pStatement->m_strParentProcedureName, pStatement->m_uiParentProcedureId ) )
						{
							if ( pComplexSignal->m_strSignalName == pStatement->m_strComplexSignalName )
							{
								const unsigned int uiSpecify = pComplexSignal->m_vectSpecify.size( );
				
								if ( uiSpecify > 0 )
								{
									for ( unsigned int ui2 = 0; ui2 < uiSpecify; ++ui2 )
									{
										AtlasSpecify* pSpecify = ( AtlasSpecify* ) pComplexSignal->m_vectSpecify[ ui2 ];
	
										SetRequireUsed( pSpecify->m_strVirtualLabel );
									}
								}
	
								pComplexSignal->m_bUsed = true;
								bIsUsed = true;
	
								break;
							}
						}
					}
				}

				if ( bIsUsed )
				{
					break;
				}
			}

			++it;
		}
	}	
	
	return bIsUsed;
}

void AIXML::VerifyStatementOrder( void )
{
	if ( m_mapProcedures.size( ) > 0 )
	{
		map< string, map< unsigned int, AtlasStatement* >* >::const_iterator it1 = m_mapProcedures.begin( );
		const map< string, map< unsigned int, AtlasStatement* >* >::const_iterator it1End = m_mapProcedures.end( );

		while ( it1End != it1 )
		{
			map< unsigned int, AtlasStatement* >::const_iterator it2 = it1->second->begin( );
			const map< unsigned int, AtlasStatement* >::const_iterator it2End = it1->second->end( );

			while ( it2End != it2 )
			{
				const AtlasProcedure* pProcedure = ( AtlasProcedure* ) it2->second;

				pProcedure->VerifyStatementOrder( );

				++it2;
			}

			++it1;
		}
	}
}

void AIXML::Statistics_ToXML( string& strXML ) const
{
	const map< string, unsigned int >& mapSignalCounts = m_AtlasStatistics.GetSignalCountsSortedByName( );
	const map< string, unsigned int >& mapStatementCounts = m_AtlasStatistics.GetStatementsCountsSortedByName( );
	const unsigned int uiSignalCounts = mapSignalCounts.size( );
	const unsigned int uiStatementCounts = mapStatementCounts.size( );

	if ( ( uiSignalCounts + uiStatementCounts ) > 0 )
	{
		strXML += XML::MakeOpenXmlElementWithChildren( XML::enStatistics );

		if ( uiSignalCounts > 0 )
		{
			map< string, unsigned int >::const_iterator it = mapSignalCounts.begin( );
			const map< string, unsigned int >::const_iterator itEnd = mapSignalCounts.end( );

			strXML += XML::MakeOpenXmlElementWithChildren( XML::enNouns, XML::MakeXmlAttributeNameValue( XML::anCount, uiSignalCounts ) );

			while ( itEnd != it )
			{
				strXML += XML::MakeXmlElementNoChildren( XML::enNoun, 
					XML::MakeXmlAttributeNameValue( XML::anName, it->first ),
					XML::MakeXmlAttributeNameValue( XML::anCount, it->second ) );

				++it;
			}
			
			strXML += XML::MakeCloseXmlElementWithChildren( XML::enNouns );
		}

		if ( uiStatementCounts > 0 )
		{
			map< string, unsigned int >::const_iterator it = mapStatementCounts.begin( );
			const map< string, unsigned int >::const_iterator itEnd = mapStatementCounts.end( );

			strXML += XML::MakeOpenXmlElementWithChildren( XML::enStatements, XML::MakeXmlAttributeNameValue( XML::anCount, uiStatementCounts ) );
			
			while ( itEnd != it )
			{
				const string& strStatementName = it->first;
				string strSignalOriented;

				if ( Atlas::IsElectricalSignalOrientedStatement( Atlas::GetAtlasStatementEnum( strStatementName ) ) )
				{
					strSignalOriented = XML::MakeXmlAttributeNameValue( XML::anSignalOriented, XML::avTrue );
				}

				strXML += XML::MakeXmlElementNoChildren( XML::enStatement, 
					XML::MakeXmlAttributeNameValue( XML::anName, strStatementName ),
					strSignalOriented,
					XML::MakeXmlAttributeNameValue( XML::anCount, it->second ) );

				++it;
			}

			strXML += XML::MakeCloseXmlElementWithChildren( XML::enStatements );
		}

		strXML += XML::MakeCloseXmlElementWithChildren( XML::enStatistics );
	}
}