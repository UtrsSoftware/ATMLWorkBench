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
#include <fstream>
#include "exception.h"

#include <xercesc/util/XercesDefs.hpp>
#include <xercesc/util/Xerces_autoconf_config.hpp>
XERCES_CPP_NAMESPACE_BEGIN
	class DOMDocument;	
	class DOMElement;	
	class XercesDOMParser;
XERCES_CPP_NAMESPACE_END

#include "Atlas.h"
#include "atlas_noun_modifier.h"
#include "program_tree.h"
#include "xml.h"
#include "DOMStatements.h"
#include "atlas_statistics.h"

class CommandLine;
class Lookup;
class Instruments;
class AtlasStatements;
class AtlasStatement;
class AtlasDeclareData;
class AtlasComplexSignal;
class AtlasRequires;
class AtlasComplexSignal;

using namespace std;

class AIXML
{
public:

	AIXML( const CommandLine* pCommandLine, const string& strParserVersion );
	~AIXML( ) { GarbageCollect( ); }

	bool Parse( const char* pASTxml, const unsigned int uiASTxmlLength );
	void ToXML( void );
	const AtlasStatistics* GetStatistics( void ) const { return &m_AtlasStatistics; }

	Exception::eErrorType GetError( void ) const { return m_excep.GetError( ); }
	string GetErrorText( const bool bIncludeCallInfo ) const { return m_excep.GetErrorText( bIncludeCallInfo ); }

	const string& GetParserVersion( void ) const { return m_strParserVersion; }

	unsigned int GetNextId( void ) { return ++m_uiNextId; }

	enum eXML
	{
		eUnknownXML = -1,
		eBeginElement,
		eTerminateBeginElement,
		eEndElement,
		eTerminateEndElement,
		eAtlasFileElement,
		eLookupElement,
		eSubfileElement,
		eNumAttribute,
		eMappingElement,
		eArgumentElement,
		eArgumentsElement,
		eNameAttribute,
		eIncludeGroupElement,
		eNumberOfElementsAttribute,
		eRequireElement,
		eKeywordElement,
		eCharacterElement,
		eWordAttribute,
		eTextAttribute,
		eConstantElement,
		eSignAttribute,
		eIncludeAtlasModuleElement,
		eFilenameElement,
		eLineAttribute,
		eStatementNumberAttribute,
		eIdAttribute,
		eProcedureGroupElement,
		eApplyElement,
		eStatementsElement,
		eSegmentElement,
		eDoGroupElement,
		eIfGroupElement,
		eWhileGroupElement,
		eForGroupElement,
		eDefineStatementsElement,
		eVariableElement,
		eMeasureElement,
		ePerformElement,
		eNameElement,
		eStringElement,
		eDefineProcedureElement,
		eIncludeNonAtlasModuleElement,
		eScopeAttribute,
		eExternalAttribute,
		eGlobalAttribute,
		eLocalAttribute,
		eProcedureArgsElement,
		eResultArgumentsElement,
		eLocalPreambleElement,
		eDeclareElement,
		eRequireStatementsElement,
		eVerifyElement,
		eSetupElement,
		eReadElement,
		eMonitorElement,
		eInitiateElement,
		eRemoveElement,
		eFetchElement,
		eConnectElement,
		eDisconnectElement,
		eArmElement,
		eChangeElement,
		eResetElement,
		eDeclareStatementsElement,
		eMainStatementsElement,
		eIfElement,
		eElseElement,
		eWhileElement,
		eForElement,
		eExpressionElement,
		eRelOpElement,
		eCompareOpElement,
		eBooleanElement,
		eUnaryOpElement,
		eArithOpElement,
		eVariableWSElement,
		eFunctionElement,
		eOperatorAttribute,
		eSubscriptElement,
		eUpLowLimitElement,
		eLowUpLimitElement,
		eBooleanOpElement,
		eEnumElement,
		eRangeElement,
		eRangeListElement,
		eEntryPointElement,
		eAssignmentElement,
		eDimensionElement,
		eNominalElement,
		eComplexSignalGroupElement,
		eDefineComplexSignalElement,
		eSpecifyElement,
		eGroupElement,
		eEndIfElement,
		eEndForElement,
		eEndWhileElement,
		eEndDefineElement,
		eCommentBlockElement,
		eCommentElement,
		eBranchTargetElement,
		eBeginAtlasProgramElement,
		eAtlasModuleElement,
		eAtlasProgramElement,
		eTerminateAtlasModuleElement,
		IPLGroupElement,
		eResumeAtlasElement,
		eCodeBlockElement,
		eTestNumberAttribute
	};
	static const string m_arrayXMLKeyWords[ ];

	struct CompareRequire
	{
		bool operator( )( const AtlasStatement* l, const AtlasStatement* r );
	};

protected:

	struct FileInfo
	{
		FileInfo(  ) : m_bInclude( false ), m_bLookup( false ), m_bSegment( false ), m_uiProcId( 0 ) { }
		FileInfo( const FileInfo& other ) { operator = ( other ); }
		FileInfo& operator = ( const FileInfo& other )
		{
			if ( this != &other )
			{
				m_bInclude		= other.m_bInclude;
				m_bLookup		= other.m_bLookup;
				m_bSegment		= other.m_bSegment;
				m_strFilename	= other.m_strFilename;
				m_strProcName	= other.m_strProcName;
				m_uiProcId		= other.m_uiProcId;
			}

			return *this;
		}

		bool m_bInclude;
		bool m_bLookup;
		bool m_bSegment;
		unsigned int m_uiProcId;
		string m_strFilename;
		string m_strProcName;
	};

	enum eXmlPaths
	{
		eParentLookupPath,
		eIncludeStatementsPath,
		eIncludeFileLookupPath,
		eParentRequirePath,
		eIncludeFileModuleRequirePath,
		ePrimaryPreamblePath,
		ePrimaryMainPath,
		eDefineProcedurePath,
		eIncludeAtlasModulePreamblePath,
		eParentDeclarePath,
		eTerminateStatementPath,
		eBeginAtlasProgramProgramNamePath
	};
	static const string m_arrayXPath[ ];


	void Init( const char* pASTxml, const unsigned int uiASTxmlLength );
	void BuildLookups( void );
	void BuildIncludeFileLookups( const xercesc::DOMElement* pAIXMLvalue );
	void BuildLookup( const xercesc::DOMElement* pAIXMLvalue );
	void MergeLookups( void );
	void BuildRequires( void );
	void BuildComments( void );
	void BuildComments( const xercesc::DOMElement* pElement, FileInfo* pFileInfo );
	void BuildDeclares( void );
	void BuildComplexSignals( void );
	void BuildIncludeFileRequires( const xercesc::DOMElement* pAIXMLvalue );
	void BuildIncludeFileDeclares( const xercesc::DOMElement* pIncludes, map< string, pair< const Atlas::AtlasSourceStatement::eSourceType, vector< const xercesc::DOMElement* > > >& mapDeclares );
	void BuildIncludeFileComplexSignals( const xercesc::DOMElement* pIncludes, map< string, pair< const Atlas::AtlasSourceStatement::eSourceType, vector< const xercesc::DOMElement* > > >& mapComplexSignals );
	void BuildRequire( const xercesc::DOMElement* pPreambleChild, const string& strSourceFilename, const Atlas::AtlasSourceStatement::eSourceType eSourceType );
	void BuildDeclare( const xercesc::DOMElement* pPreambleChild, const string& strSourceFilename, const Atlas::AtlasSourceStatement::eSourceType eSourceType, map< string, pair< const Atlas::AtlasSourceStatement::eSourceType, vector< const xercesc::DOMElement* > > >& mapDeclares );
	void BuildComplexSignal( const xercesc::DOMElement* pPreambleChild, const string& strSourceFilename, const Atlas::AtlasSourceStatement::eSourceType eSourceType, map< string, pair< const Atlas::AtlasSourceStatement::eSourceType, vector< const xercesc::DOMElement* > > >& mapComplexSignals );
	void ProcessRequire( const xercesc::DOMElement* pAIXMLvalue, AtlasStatements* pAtlasStatements, const string& strSourceFilename, const Atlas::AtlasSourceStatement::eSourceType eSourceType );
	void CreateRequire( const xercesc::DOMElement* pAIXMLvalue, AtlasStatements* pAtlasStatements, const Atlas::AtlasSourceStatement& requireStatement );
	void MergeRequires( void );
	void MergeRequireInfo( void );
	void MergeInstruments( void );
	void MergeSignals( void );
	void MergeClasses( void );
	void BuildStatistics( void );
	void ProcessProcedureSymbolTable( void );
	void ProcessDeclareSymbolTable( void );
	void ProcessDeclares( void );
	void BuildProcedureStatements( void );
	void ProcessDigitalExpressions( void );
	void ProcessGotoLeaveStatements( void );
	void SetStatementsParent( void );
	void ProcessDigitalExpressions( vector< AtlasStatement* >* pStatements );
	void BuildProcedureStatements( vector< AtlasStatement* >* pvectStatements );
	void ProcessGotoLeaveStatements( vector< AtlasStatement* >* pvectStatements );
	void BuildProcedureConditionalStatements( void );
	vector< AtlasStatement* >* GetStatementVector( const Atlas::eAtlasStatement eStatement ) const;
	const DOMStatements* GetDOMStatements( const Atlas::eAtlasStatement eStatement );
	const AtlasStatement* GetScopedProcedure( const AtlasStatement* pStatement, const map< unsigned int, AtlasStatement* >* pmapProcs ) const;
	const AtlasStatement* GetProcedure( const string strProcName, const unsigned int uiProcedureId ) const;
	void SetEntryPointId( const xercesc::DOMElement* pStatement );
	const AtlasRequires* GetRequires( const string& strFilename ) const;
	void SetRequireUsed( const string& strVirtualLabel );
	bool IsProcedureUsed( const string& strProcName, const unsigned int uiProcId ) const;
	bool IsDeclareUsed( const AtlasDeclareData* pDeclareData ) const;
	bool SetComplexSignalUsage( AtlasComplexSignal* pComplexSignal );

	void BuildProgramTree( const bool bBuildProgramTree );

	void BuildSignalOrientedVerb( const Atlas::eAtlasStatement eStatement, const XML::ElementName eVerbElementName, const bool bHasMeasureCharacteristics );
	void BuildRegularStatements( void );
	void BuildPerforms( void );
	void BuildProcedures( void );
	void BuildConditionalStatements( const Atlas::eAtlasStatement eStatement );
	void BuildLeaveStatements( const Atlas::eAtlasStatement eStatement );
	void BuildCalculates( void );
	void BuildCompares( void );
	void BuildFills( void );
	void BuildLeaveResumes( void );
	void BuildUnhandledStatements( void );

	void GetProcedureStatements( void );
	void GetPreampleStatements( StatementMetadata* pStatementMetadata );
	void GetPreampleIncludeStatements( void );
	void GetMainStatements( void );
	const xercesc::DOMElement* GetStatement( StatementMetadata* pStatementMetadata, unsigned int uiContainerId, unsigned int uiNesting );
	void GetProcedureStatements( const xercesc::DOMElement* pAIXMLvalue, const string& strFilename, const Atlas::AtlasSourceStatement::eSourceType eSourceType );
	void InitDeclares( map< string, pair< const Atlas::AtlasSourceStatement::eSourceType, vector< const xercesc::DOMElement* > > >& mapDeclares );
	void InitComplexSignals( map< string, pair< const Atlas::AtlasSourceStatement::eSourceType, vector< const xercesc::DOMElement* > > >& mapComplexSignals );

	void SetAtlasSources( void );
	void GetIncludeFilenames( void );
	void GetProgramName( void );
	void GetSegmentedFilenames( void );

	void AIXML_ToXML( string& strXML, const string& strISO8601Time ) const;
	void UUT_ToXML( string& strXML ) const;
	void AtlasSources_ToXML( string& strXML ) const;
	void Comments_ToXML( string& strXML ) const;
	void IPLBlocks_ToXML( string& strXML ) const;
	void Signals_ToXML( string& strXML ) const;
	void SignalOrientedStatements_ToXML( string& strXML ) const;
	void Require_ToXML( string& strXML ) const;
	void Procedures_ToXML( string& strXML ) const;
	void ProgramTree_ToXML( const string& strISO8601Time );
	void RemainingStatements_ToXML( string& strXML ) const;
	void Statements_ToXML( string& strXML, const XML::ElementName eOuterName, const XML::ElementName enInnerName, const vector< AtlasStatement* >* pvectStatements ) const;
	void Declares_ToXML( string& strXML ) const;
	void BuiltIns_ToXML( string& strXML ) const;
	void Statistics_ToXML( string& strXML ) const;

	void GarbageCollect( void );
	void PreliminaryGarbageCollect( void );
	void VerifyIfExtension( string& strFilename );
	void CreateBuiltInVariables( void );
	void CreateBuiltInVariable( const string& strName, const Atlas::eDataType dataType, const Atlas::AtlasData::eBuiltInType builtinType );
	unsigned int CreateStatementVector( const Atlas::eAtlasStatement eStatement, const DOMStatements** ppDOMStatements, vector< AtlasStatement* >** ppvect );
	void VerifyStatementOrder( void );

	XML::AttributeValue m_eStationType;
	unsigned int m_uiProgTreeStartMain;
	unsigned int m_uiProgTreeEndMain;
	unsigned int m_uiMainProcId;
	unsigned int m_uiUsedProcCount;
	bool m_bXercesInit;
	bool m_bHasSegments;
	bool m_bProcedureCallHierarchyXML;
	bool m_bExcludeUnused;
	bool m_bIEEE1641XML;
	bool m_bIEEE260_1XML;
	string m_strUUTName;
	string m_strUUTId;
	string m_strOutputFilename;
	string m_strProcHierOutputFilename;
	string m_strParserVersion;
	string m_strPrimaryAtlasFilename;
	string m_strAtlasProgramName;
	string m_strAtlasBaseFilename;
	string m_strAtlasFileExtension;
	Exception m_excep;
	ofstream m_xmlOutFile;
	ofstream m_xmlProcHierOutFile;
	vector< pair< string, Atlas::AtlasSourceStatement::eSourceType > > m_vectAtlasSourceFiles;
	vector< Lookup* > m_vectLookups; // Position zero contains the Lookup of the primary file
	set< unsigned int > m_setEntryPointIds;
	Lookup* m_pMergedLookup;
	AtlasStatements* m_pMergedRequires;
	map< string, AtlasStatement* > m_mapMergedInstruments;
	map< Atlas::eAtlasNoun, AtlasStatement* > m_mapMergedSignals;
	map< string, AtlasStatement* > m_mapMergedInstrumentClasses;
	xercesc::XercesDOMParser* m_parser;
	const xercesc::DOMDocument* m_pDoc;
	const xercesc::DOMElement* m_pRoot;
	const xercesc::DOMElement* m_pMainStatements;
	const xercesc::DOMElement* m_pTerminateStatement;
	Atlas::AtlasSourceStatement m_MainSourceStatement;
	map< Atlas::eAtlasStatement, DOMStatements* > m_mapDOMElementStatements;
	map< string, vector< pair< Atlas::AtlasSourceStatement::eSourceType, const xercesc::DOMElement* > > > m_mapAllProcedures;  // < filename, vector< file type, element pointer > >
	map< Atlas::AtlasData::eBuiltInType, AtlasDeclareData* > m_mapBuiltinDeclares;
	map< string, vector< AtlasComplexSignal* >* > m_mapComplexSignals;
	set< string > m_setVirtualLabelsFoundInRequires;
	AtlasSignalInfo m_AtlasSignalInfo;
	AtlasStatistics m_AtlasStatistics;
	ProgamTree m_ProgramTree;
	DOMStatements* m_pCommentsDOMStatements;

	// Statement containers
	map< string, pair< Atlas::AtlasSourceStatement::eSourceType, vector< AtlasStatement* >* > > m_mapComments;	// <filename, <source file type, comment blocks>>
	map< const Atlas::eAtlasStatement, vector< AtlasStatement* >* > m_mapStatements;							// <statement type, vector of statements>
	set< string > m_setNonAtlasProcedures;																		// <names of non-Atlas procedures>
	map< string, map< unsigned int, AtlasStatement* >* > m_mapProcedures;										// <procedure name (atlas and non-atlas), <procedure id, procedure class>>
	map< string, set< unsigned int >* > m_mapExternalProcedures;												// <external procedure name, <procedure id>>
	map< string, vector< AtlasDeclareData* >* > m_mapDeclares;													// <variable name, vector of variable meta data>
	vector< AtlasStatements* > m_vectRequires;																	// Position zero contains the Requires of the primary file
	map< string, AtlasStatements* > m_mapRequiresByFilename;													// <filename, require statements>
	// End statement containers

	static unsigned int m_uiNextId;
	static const string m_strXMLVersion;
	static const string m_strXMLEncoding;

	struct ASTI  // [A]tlas [ST]atement [I]nformation
	{
		ASTI( const string& strAtlasStatement, const Atlas::eAtlasStatement eAtlasStatement, const XML::ElementName ePluralElementName, const XML::ElementName eSingalElementName ) :
			m_strAtlasStatement( strAtlasStatement ),
			m_eAtlasStatement( eAtlasStatement ),
			m_ePluralElementName( ePluralElementName ),
			m_eSingalElementName( eSingalElementName )
		{ }

		string m_strAtlasStatement;
		Atlas::eAtlasStatement m_eAtlasStatement;
		XML::ElementName m_ePluralElementName;
		XML::ElementName m_eSingalElementName;
	};
	static const ASTI m_arrayAtlasVerb[ ];
	static const unsigned int m_uiAtlasStatements;

	static map< const string*, Atlas::eAtlasStatement, AIXMLHelper::cmpPointer > m_mapElementStatmentToAtlasStatementEnum;
	static map< Atlas::eAtlasStatement, pair< XML::ElementName, XML::ElementName > > m_mapElementStatmentToAtlasStatementXMLElementNames;

	static eXML GetConditionalContainer( const string& strStatement );
	static Atlas::eAtlasStatement GetAtlasStatementEnum( const string& strAtlasStatement );
	static const pair< XML::ElementName, XML::ElementName >* GetAtlasStatementXMLElementNames( const Atlas::eAtlasStatement eStatement );

	struct CompareAtlasFilename
	{
		bool operator( )( const pair< string, Atlas::AtlasSourceStatement::eSourceType >& l, const pair< string, Atlas::AtlasSourceStatement::eSourceType >& r );
	};

	struct CompareConditional
	{
		bool operator( )( const AtlasStatement* l, const AtlasStatement* r );
	};

	template< typename T > void BuildStatements( const Atlas::eAtlasStatement eStatement )
	{
		const DOMStatements* pDOMStatements = 0;
		vector< AtlasStatement* >* pvectStatements = 0;
		const unsigned int uiStatementCount = CreateStatementVector( eStatement, &pDOMStatements, &pvectStatements );
	
		if ( uiStatementCount > 0 )
		{
			for ( unsigned int ui = 0; ui < uiStatementCount; ++ui )
			{
				const StatementMetadata* pdata = pDOMStatements->m_vectStatements[ ui ];

				T* pStatement = 0;
					
				try
				{
					pStatement = new T;
				}
				catch ( ... )
				{
					throw Exception( Exception::eFailedToAllocateMemoryForAtlasStatementObject, __FILE__, __FUNCTION__, __LINE__ );
				}

				pvectStatements->push_back( pStatement );

				pStatement->InitFromXML( pdata );
				pStatement->Process( m_pMergedLookup );
			}
		}
	}
};