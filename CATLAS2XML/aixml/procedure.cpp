/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

#include "procedure.h"
#include "exception.h"
#include "perform.h"
#include "declare.h"
#include "aixml.h"
#include "xml.h"

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


AtlasProcedure& AtlasProcedure::operator = ( const AtlasStatement& other )
{
	if ( this != &other )
	{
		AtlasStatementContainer::operator = ( other );

		GarbageCollect( );

		const AtlasProcedure* pother = dynamic_cast< const AtlasProcedure* >( &other );

		if ( 0 != pother )
		{
			m_strProcedureName = pother->m_strProcedureName;
			m_bNonAtlas = pother->m_bNonAtlas;
			m_eScope = pother->m_eScope;
		}
	}

	return *this;
}

void AtlasProcedure::InitFromXML( const xercesc::DOMElement* pAIXMLvalue, const Atlas::AtlasSourceStatement::eSourceType eSourcType, const string& strFilename )
{
	if ( 0 != pAIXMLvalue )
	{
		if ( m_bMainProcedure )
		{
			SetSourceStatementInfo( pAIXMLvalue, eSourcType, strFilename, string( ), 0 );
		}
		else
		{
			string strAIXMLtagName;
	
			const DOMAttr* pAttr = pAIXMLvalue->getAttributeNode( AIXMLHelper::GetWString( AIXML::m_arrayXMLKeyWords[ AIXML::eScopeAttribute ] ).c_str( ) );
	
			if ( 0 != pAttr )
			{
				AIXMLHelper::GetXercesString( pAttr->getValue( ), strAIXMLtagName );
	
				m_eScope = GetScopeEnum( strAIXMLtagName );
			}
	
			const xercesc::DOMElement* pDefineProcChild = pAIXMLvalue->getFirstElementChild( );
	
			if ( 0 != pDefineProcChild )
			{
				AIXMLHelper::GetXercesString( pDefineProcChild->getTagName( ), strAIXMLtagName );
		
				if ( AIXML::m_arrayXMLKeyWords[ AIXML::eNameElement ] == strAIXMLtagName )
				{
					const DOMAttr* pAttr = pDefineProcChild->getAttributeNode( AIXMLHelper::GetWString( AIXML::m_arrayXMLKeyWords[ AIXML::eNameAttribute ] ).c_str( ) );
			
					if ( 0 != pAttr )
					{
						AIXMLHelper::GetXercesString( pAttr->getValue( ), m_strProcedureName );
					}
				}
		
				m_uiId = SetSourceStatementInfo( pAIXMLvalue, eSourcType, strFilename, string( ), 0 );

				pDefineProcChild = pDefineProcChild->getNextElementSibling( );
	
				while ( 0 != pDefineProcChild )
				{
					AIXMLHelper::GetXercesString( pDefineProcChild->getTagName( ), strAIXMLtagName );
	
					if ( AIXML::m_arrayXMLKeyWords[ AIXML::eProcedureArgsElement ] == strAIXMLtagName )
					{
						const xercesc::DOMElement* pProcArguments = pDefineProcChild->getFirstElementChild( );
		
						while ( 0 != pProcArguments )
						{
							AtlasStatement::InitFromXML( pProcArguments );
			
							pProcArguments = pProcArguments->getNextElementSibling( );
						}
	
						m_vectTempParameters.insert( m_vectTempParameters.end( ), m_vectAttributes.begin( ), m_vectAttributes.end( ) );
						m_vectAttributes.clear( );
					}
					else if ( AIXML::m_arrayXMLKeyWords[ AIXML::eResultArgumentsElement ] == strAIXMLtagName )
					{
						const xercesc::DOMElement* pProcResults = pDefineProcChild->getFirstElementChild( );
		
						while ( 0 != pProcResults )
						{
							AtlasStatement::InitFromXML( pProcResults );
			
							pProcResults = pProcResults->getNextElementSibling( );
						}
	
						m_vectTempResults.insert( m_vectTempResults.end( ), m_vectAttributes.begin( ), m_vectAttributes.end( ) );
						m_vectAttributes.clear( );
					}
	
					pDefineProcChild = pDefineProcChild->getNextElementSibling( );
				}
			}
	
			pAIXMLvalue = pAIXMLvalue->getNextElementSibling( );
	
			if ( 0 != pAIXMLvalue )
			{
				AIXMLHelper::GetXercesString( pAIXMLvalue->getTagName( ), strAIXMLtagName );
	
				if ( AIXML::m_arrayXMLKeyWords[ AIXML::eLocalPreambleElement ] == strAIXMLtagName )
				{
					const xercesc::DOMElement* pLocalArguments = pAIXMLvalue->getFirstElementChild( );
	
					while ( 0 != pLocalArguments )
					{
						AIXMLHelper::GetXercesString( pLocalArguments->getTagName( ), strAIXMLtagName );
	
						if ( AIXML::m_arrayXMLKeyWords[ AIXML::eDeclareElement ] == strAIXMLtagName )
						{
							string strStatementNumber;

							const DOMAttr* pAttr = pLocalArguments->getAttributeNode( AIXMLHelper::GetWString( AIXML::m_arrayXMLKeyWords[ AIXML::eStatementNumberAttribute ] ).c_str( ) );
							if ( 0 != pAttr )
							{
								AIXMLHelper::GetXercesString( pAttr->getValue( ), strStatementNumber );
							}

							const xercesc::DOMElement* pArguments = pLocalArguments->getFirstElementChild( );
	
							while ( 0 != pArguments )
							{
								const xercesc::DOMElement* pArgument = pArguments->getFirstElementChild( );
	
								while ( 0 != pArgument )
								{
									AtlasStatement::InitFromXML( pArgument, strStatementNumber );
	
									pArgument = pArgument->getNextElementSibling( );
								}
	
								pArguments = pArguments->getNextElementSibling( );
							}
	
							if ( m_vectTempLocalPreample.size( ) > 0 )
							{
								m_vectTempLocalPreample.push_back( ( const AtlasAttibuteValue* ) 0 );
							}
	
							m_vectTempLocalPreample.insert( m_vectTempLocalPreample.end( ), m_vectAttributes.begin( ), m_vectAttributes.end( ) );
							m_vectAttributes.clear( );
						}
	
						pLocalArguments = pLocalArguments->getNextElementSibling( );
					}
				}
				else if ( AIXML::m_arrayXMLKeyWords[ AIXML::eStatementsElement ] == strAIXMLtagName )
				{
					m_pStatementsElement = pAIXMLvalue;
				}
				else if ( AIXML::m_arrayXMLKeyWords[ AIXML::eEndDefineElement ] == strAIXMLtagName )
				{
					SetSourceStatementInfo( m_EndStatement, pAIXMLvalue, eSourcType, strFilename, string( ) );
					m_EndStatement.SetAtlasStatement( Atlas::eEND_DEFINE );
				}
			}

			pAIXMLvalue = pAIXMLvalue->getNextElementSibling( );
	
			if ( 0 != pAIXMLvalue )
			{
				AIXMLHelper::GetXercesString( pAIXMLvalue->getTagName( ), strAIXMLtagName );
	
				if ( AIXML::m_arrayXMLKeyWords[ AIXML::eStatementsElement ] == strAIXMLtagName )
				{
					m_pStatementsElement = pAIXMLvalue;

					const DOMAttr* pAttr = m_pStatementsElement->getAttributeNode( AIXMLHelper::GetWString( AIXML::m_arrayXMLKeyWords[ AIXML::eIdAttribute ] ).c_str( ) );
			
					if ( 0 != pAttr )
					{
						string strContainerId;
			
						AIXMLHelper::GetXercesString( pAttr->getValue( ), strContainerId );
			
						m_uiStatementsId = AIXMLHelper::StringToNumber< unsigned int >( strContainerId );
					}
				}
				else if ( AIXML::m_arrayXMLKeyWords[ AIXML::eEndDefineElement ] == strAIXMLtagName )
				{
					SetSourceStatementInfo( m_EndStatement, pAIXMLvalue, eSourcType, strFilename, string( ) );
					m_EndStatement.SetAtlasStatement( Atlas::eEND_DEFINE );
				}

				if ( m_EndStatement.GetStatementNumber( ).empty( ) )
				{
					pAIXMLvalue = pAIXMLvalue->getNextElementSibling( );

					while ( 0 != pAIXMLvalue )
					{
						AIXMLHelper::GetXercesString( pAIXMLvalue->getTagName( ), strAIXMLtagName );
			
						if ( AIXML::m_arrayXMLKeyWords[ AIXML::eEndDefineElement ] == strAIXMLtagName )
						{
							SetSourceStatementInfo( m_EndStatement, pAIXMLvalue, eSourcType, strFilename, string( ) );
							m_EndStatement.SetAtlasStatement( Atlas::eEND_DEFINE );
						}

						pAIXMLvalue = pAIXMLvalue->getNextElementSibling( );
					}
				}
			}
		}
	}

	#if ( _DEBUG ) && ( WIN32 )
	if ( 0 == m_EndStatement.GetId( ) )
	{
		DebugBreak( );
	}
	#endif
}

void AtlasProcedure::Process( const Lookup* pLookup )
{
	if ( !m_bProcessed )
	{
		if ( !m_bMainProcedure )
		{
			unsigned int uiSize = m_vectTempParameters.size( );
			if ( uiSize > 0 )
			{
				for ( unsigned int ui = 0; ui < uiSize; ++ui )
				{
					AtlasAttibuteValue* pAttibuteValue = ( AtlasAttibuteValue* ) m_vectTempParameters[ ui ];
	
					AtlasDeclareData* pAtlasDeclareData = 0;
						
					try
					{
						pAtlasDeclareData = new AtlasDeclareData;
					}
					catch ( ... )
					{
						throw Exception( Exception::eFailedToAllocateMemoryForNewDeclareDataObject, __FILE__, __FUNCTION__, __LINE__ );
					}
	
					m_vectParameters.push_back( pAtlasDeclareData );
	
					pAtlasDeclareData->m_Declare.SetProcedure( true );

					if ( pAttibuteValue->IsConstant( ) )
					{
						pAtlasDeclareData->m_Declare.SetConstant( true );
					}
					else if ( pAttibuteValue->IsVariable( ) )
					{
						pAtlasDeclareData->m_Declare.SetVariable( true );
						pAtlasDeclareData->m_Declare.m_strVarName = pAttibuteValue->m_strValue;
					}
				}
			}
	
			uiSize = m_vectTempResults.size( );
			if ( uiSize > 0 )
			{
				for ( unsigned int ui = 0; ui < uiSize; ++ui )
				{
					AtlasAttibuteValue* pAttibuteValue = ( AtlasAttibuteValue* ) m_vectTempResults[ ui ];
	
					AtlasDeclareData* pAtlasDeclareData = 0;
						
					try
					{
						pAtlasDeclareData = new AtlasDeclareData;
					}
					catch ( ... )
					{
						throw Exception( Exception::eFailedToAllocateMemoryForNewDeclareDataObject, __FILE__, __FUNCTION__, __LINE__ );
					}
	
					m_vectResults.push_back( pAtlasDeclareData );
	
					pAtlasDeclareData->m_Declare.SetProcedure( true );

					if ( pAttibuteValue->IsConstant( ) )
					{
						pAtlasDeclareData->m_Declare.SetConstant( true );
					}
					else if ( pAttibuteValue->IsVariable( ) )
					{
						pAtlasDeclareData->m_Declare.SetVariable( true );
						pAtlasDeclareData->m_Declare.m_strVarName = pAttibuteValue->m_strValue;
					}
				}
			}
	
			uiSize = m_vectTempLocalPreample.size( );
			if ( uiSize > 0 )
			{
				Atlas::AtlasSourceStatement source;

				if ( m_vectAtlasSourceStatement.size( ) > 0 )
				{
					source = m_vectAtlasSourceStatement[ 0 ];

					source.SetAtlasStatement( Atlas::eDECLARE );
					source.SetParentProcname( string( ) );
				}

				AtlasDeclare::GetDeclares( m_vectTempLocalPreample, m_vectDeclares, source );
			}
	
			GarbageCollectTemp( );
	
			uiSize = m_vectDeclares.size( );
			if ( uiSize > 0 )
			{
				const unsigned int uiParamsSize = m_vectParameters.size( );
				const unsigned int uiResultsSize = m_vectResults.size( );
	
				if ( ( uiParamsSize > 0 ) || ( uiResultsSize > 0 ) )
				{
					map< string, unsigned int > mapVarNameIndex;
	
					for ( unsigned int ui = 0; ui < uiSize; ++ui )
					{
						mapVarNameIndex.insert( make_pair( m_vectDeclares[ ui ]->m_Declare.m_strVarName, ui ) );
					}
	
					map< string, unsigned int >::const_iterator it;
					const map< string, unsigned int >::const_iterator itEnd = mapVarNameIndex.end( );
					bool bErase = false;
	
					for ( unsigned int ui = 0; ui < uiParamsSize; ++ui )
					{
						it = mapVarNameIndex.find( m_vectParameters[ ui ]->m_Declare.m_strVarName );
	
						if ( itEnd != it )
						{
							*( m_vectParameters[ ui ] ) = *( m_vectDeclares[ it->second ] );

							m_vectParameters[ ui ]->m_Declare.SetParameter( true );

							delete m_vectDeclares[ it->second ];
	
							m_vectDeclares[ it->second ] = 0;
	
							bErase = true;
						}
					}

					for ( unsigned int ui = 0; ui < uiResultsSize; ++ui )
					{
						it = mapVarNameIndex.find( m_vectResults[ ui ]->m_Declare.m_strVarName );
	
						if ( itEnd != it )
						{
							*( m_vectResults[ ui ] ) = *( m_vectDeclares[ it->second ] );
	
							m_vectResults[ ui ]->m_Declare.SetResult( true );

							delete m_vectDeclares[ it->second ];
	
							m_vectDeclares[ it->second ] = 0;
	
							bErase = true;
						}
					}
	
					if ( bErase )
					{
						for ( int i = ( int ) ( uiSize - 1 ); i >= 0; --i )
						{
							if ( 0 == m_vectDeclares[ i ] )
							{
								m_vectDeclares.erase( m_vectDeclares.begin( ) + i );
							}
						}
					}
				}
			}
		}

		m_bProcessed = true;
	}
}

void AtlasProcedure::ToXML( string& strXML, const set< unsigned int >* psetEntryPointIds ) const
{
	const string strId( XML::MakeXmlAttributeNameValue( XML::anId, m_uiId ) );
	unsigned int uiCommentId = 0;
	string strCommentRefId;
	string strNonAtlas;
	string strMainEntry;
	string strTestNumbers;
	string strUsed;

	if ( m_bMainProcedure )
	{
		const multimap< unsigned int, AtlasStatement* >::const_iterator it = m_mapStatements.begin( );
		const multimap< unsigned int, AtlasStatement* >::const_iterator itEnd = m_mapStatements.end( );

		if ( itEnd != it )
		{
			uiCommentId = it->second->GetStatementCommentId( );
		}
	}
	else
	{
		uiCommentId = GetStatementCommentId( );
	}

	if ( 0 != uiCommentId )
	{
		strCommentRefId = XML::MakeXmlAttributeNameValue( XML::anCommentRefId, uiCommentId );
	}

	if ( m_bNonAtlas )
	{
		strNonAtlas = XML::MakeXmlAttributeNameValue( XML::anNonAtlas, XML::avTrue );
	}

	if ( m_bMainProcedure )
	{
		strMainEntry = XML::MakeXmlAttributeNameValue( XML::anMainProcedure, XML::avTrue );
	}

	if ( !m_bUsed && !m_bMainProcedure )
	{
		strUsed = XML::MakeXmlAttributeNameValue( XML::anUnused, XML::avTrue );
	}

	strXML += XML::MakeOpenXmlElementWithChildren( XML::enProcedure, XML::MakeXmlAttributeNameValue( XML::anName, m_strProcedureName ), strId, strMainEntry, strNonAtlas, strCommentRefId, strUsed );

	unsigned int uiSize = m_vectAtlasSourceStatement.size( );
	if ( uiSize > 0 )
	{
		unsigned int uiFields = Atlas::AtlasSourceStatement::eXmlFilename;

		uiFields |= Atlas::AtlasSourceStatement::eXmlStatementNumber;
		uiFields |= Atlas::AtlasSourceStatement::eXmlLineNumber;
		uiFields |= Atlas::AtlasSourceStatement::eXmlSourceType;

		if ( !m_bMainProcedure )
		{
			uiFields |= Atlas::AtlasSourceStatement::eXmlAtlasStatement;
		}
		else if ( Atlas::eUnknownAtlasStatement != m_vectAtlasSourceStatement[ 0 ].GetAtlasStatement( ) )
		{
			uiFields |= Atlas::AtlasSourceStatement::eXmlAtlasStatement;
		}

		strXML += m_vectAtlasSourceStatement[ 0 ].ToXML( uiFields );
	}

	uiSize = m_vectParameters.size( );
	if ( uiSize > 0 )
	{
		strXML += XML::MakeOpenXmlElementWithChildren( XML::enParameters, XML::MakeXmlAttributeNameValue( XML::anCount, uiSize ) );
	
		for ( unsigned int ui = 0; ui < uiSize; ++ui )
		{
			strXML += m_vectParameters[ ui ]->ToXML( XML::enParameter );
		}

		strXML += XML::MakeCloseXmlElementWithChildren( XML::enParameters );
	}

	uiSize = m_vectResults.size( );
	if ( uiSize > 0 )
	{
		strXML += XML::MakeOpenXmlElementWithChildren( XML::enResults, XML::MakeXmlAttributeNameValue( XML::anCount, uiSize ) );
	
		for ( unsigned int ui = 0; ui < uiSize; ++ui )
		{
			strXML += m_vectResults[ ui ]->ToXML( XML::enResult );
		}

		strXML += XML::MakeCloseXmlElementWithChildren( XML::enResults );
	}

	uiSize = m_vectDeclares.size( );
	if ( uiSize > 0 )
	{
		strXML += XML::MakeOpenXmlElementWithChildren( XML::enPreamble );

		for ( unsigned int ui = 0; ui < uiSize; ++ui )
		{
			strXML += m_vectDeclares[ ui ]->ToXML( XML::enDeclare );
		}

		strXML += XML::MakeCloseXmlElementWithChildren( XML::enPreamble );
	}

	GetTestNumbers_ToXML( strTestNumbers );

	strXML += strTestNumbers;

	Statements_ToXML( strXML, psetEntryPointIds );

	strXML += XML::MakeCloseXmlElementWithChildren( XML::enProcedure );
}

void AtlasProcedure::GetTestNumbers_ToXML( string& strXML ) const
{
	map< string, map< string, const Atlas::AtlasData* > > mapTestVariables;
	map< string, map< unsigned int, const AtlasStatement* > > mapSignalOrientedVerbs;
	map< string, TestData* > mapTestNumberData( m_mapTestNumberData );

	GetChildrenTestNumberStatements( mapTestNumberData );

	GetTestNumberStatementVariables( mapTestNumberData, mapTestVariables );

	GetTestNumberStatementSignalOrientedVerbs( mapTestNumberData, mapSignalOrientedVerbs );

	const unsigned int uiSize = mapTestNumberData.size( );

	if ( uiSize > 0 )
	{
		map< string, TestData* >::const_iterator it = mapTestNumberData.begin( );
		const map< string, TestData* >::const_iterator itEnd = mapTestNumberData.end( );

		strXML += XML::MakeOpenXmlElementWithChildren( XML::enTestNumbers, XML::MakeXmlAttributeNameValue( XML::anCount, uiSize ) );
	
		while ( itEnd != it )
		{
			const TestData* pTestData = it->second;
			string strBeginTest;

			if ( pTestData->m_bBeginTest )
			{
				strBeginTest = XML::MakeXmlAttributeNameValue( XML::anBeginTest, XML::avTrue );
			}

			map< string, map< string, const Atlas::AtlasData* > >::const_iterator itTestVariables = mapTestVariables.find( it->first );
			map< string, map< unsigned int, const AtlasStatement* > >::const_iterator itTestSignalVerbs = mapSignalOrientedVerbs.find( it->first );

			if ( ( mapTestVariables.end( ) != itTestVariables ) || ( mapSignalOrientedVerbs.end( ) != itTestSignalVerbs ) )
			{
				const map< string, const Atlas::AtlasData* >* pmapVariables = 0;
				const map< unsigned int, const AtlasStatement* >* pmapSignalVerbs = 0;
				unsigned int uiVerbs = 0;
				unsigned int uiVariables = 0;

				if ( mapTestVariables.end( ) != itTestVariables )
				{
					pmapVariables = &( itTestVariables->second );
					uiVariables = pmapVariables->size( );
				}
					
				if ( mapSignalOrientedVerbs.end( ) != itTestSignalVerbs )
				{
					pmapSignalVerbs = &( itTestSignalVerbs->second );
					uiVerbs = pmapSignalVerbs->size( );
				}

				if ( ( uiVariables > 0 ) || ( uiVerbs > 0 ) )
				{
					strXML += XML::MakeOpenXmlElementWithChildren( XML::enTest, XML::MakeXmlAttributeNameValue( XML::anNumber, it->first ), strBeginTest );

					if ( uiVariables > 0 )
					{
						map< string, const Atlas::AtlasData* >::const_iterator itVar = pmapVariables->begin( );
						const map< string, const Atlas::AtlasData* >::const_iterator itVarEnd = pmapVariables->end( );

						strXML += XML::MakeOpenXmlElementWithChildren( XML::enVariables, XML::MakeXmlAttributeNameValue( XML::anCount, uiVariables ) );
		
						while ( itVarEnd != itVar )
						{
							strXML += XML::MakeXmlElementNoChildren( XML::enVariable, itVar->second->ToXML( ) );
		
							++itVar;
						}

						strXML += XML::MakeCloseXmlElementWithChildren( XML::enVariables );
					}

					if ( uiVerbs > 0 )
					{
						map< unsigned int, const AtlasStatement* >::const_iterator itVerb = pmapSignalVerbs->begin( );
						const map< unsigned int, const AtlasStatement* >::const_iterator itVerbEnd = pmapSignalVerbs->end( );
						unsigned int uiCount = 1;

						strXML += XML::MakeOpenXmlElementWithChildren( XML::enSignalOrientedStatements, XML::MakeXmlAttributeNameValue( XML::anCount, uiVerbs ) );
		
						while ( itVerbEnd != itVerb )
						{
							static string strLocalSignal( "ls" );
							const AtlasSignalVerb* pSignalStatement = ( AtlasSignalVerb* ) itVerb->second;
							const string strType( XML::MakeXmlAttributeNameValue( XML::anType, pSignalStatement->GetStatementType( ) ) );
							const string strRefId( XML::MakeXmlAttributeNameValue( XML::anRefId, pSignalStatement->m_uiId ) );
							string strResource;
							string strIdValue( strLocalSignal );
							string strId;

							if ( Atlas::eUnknownAtlasResource != pSignalStatement->m_PrimarySignalComponent.GetAtlasNounResource( ) )
							{
								strResource = XML::MakeXmlAttributeNameValue( XML::anResource, pSignalStatement->m_PrimarySignalComponent.GetAtlasNounResourceDescription( ) );
							}

							strIdValue += pTestData->m_strTestName;
							strIdValue += AtlasStatement::m_strDash;
							strIdValue += AIXMLHelper::NumberToString< unsigned int >( uiCount++ );

							strId = XML::MakeXmlAttributeNameValue( XML::anId, strIdValue );

							strXML += XML::MakeXmlElementNoChildren( XML::enStatement, strType, strRefId, strResource, strId );
//el.SetAttribute( "id", string.Format( "ls{0}-{1}", testNo, counter++ ) );

							++itVerb;
						}

						strXML += XML::MakeCloseXmlElementWithChildren( XML::enSignalOrientedStatements );
					}

					strXML += XML::MakeCloseXmlElementWithChildren( XML::enTest );
				}
				else 
				{
					strXML += XML::MakeXmlElementNoChildren( XML::enTest, XML::MakeXmlAttributeNameValue( XML::anNumber, pTestData->m_strTestName ), strBeginTest );
				}
			}
			else
			{
				strXML += XML::MakeXmlElementNoChildren( XML::enTest, XML::MakeXmlAttributeNameValue( XML::anNumber, pTestData->m_strTestName ), strBeginTest );
			}

			++it;
		}

		strXML += XML::MakeCloseXmlElementWithChildren( XML::enTestNumbers );
	}
}

void AtlasProcedure::GarbageCollect( void )
{
	GarbageCollectTemp( );

	unsigned int uiSize = m_vectParameters.size( );
	if ( uiSize > 0 )
	{
		for ( unsigned int ui = 0; ui < uiSize; ++ui )
		{
			delete m_vectParameters[ ui ];
		}
		m_vectParameters.clear( );
	}

	uiSize = m_vectResults.size( );
	if ( uiSize > 0 )
	{
		for ( unsigned int ui = 0; ui < uiSize; ++ui )
		{
			delete m_vectResults[ ui ];
		}
		m_vectResults.clear( );
	}

	uiSize = m_vectDeclares.size( );
	if ( uiSize > 0 )
	{
		for ( unsigned int ui = 0; ui < uiSize; ++ui )
		{
			delete m_vectDeclares[ ui ];
		}
		m_vectDeclares.clear( );
	}
}

void AtlasProcedure::GarbageCollectTemp( void )
{
	unsigned int uiSize = m_vectTempParameters.size( );
	if ( uiSize > 0 )
	{
		for ( unsigned int ui = 0; ui < uiSize; ++ui )
		{
			delete m_vectTempParameters[ ui ];
		}
		m_vectTempParameters.clear( );
	}

	uiSize = m_vectTempResults.size( );
	if ( uiSize > 0 )
	{
		for ( unsigned int ui = 0; ui < uiSize; ++ui )
		{
			delete m_vectTempResults[ ui ];
		}
		m_vectTempResults.clear( );
	}

	uiSize = m_vectTempLocalPreample.size( );
	if ( uiSize > 0 )
	{
		for ( unsigned int ui = 0; ui < uiSize; ++ui )
		{
			const AtlasAttibuteValue* pAttibuteValue = m_vectTempLocalPreample[ ui ];

			if ( 0 != pAttibuteValue )
			{
				delete pAttibuteValue;
			}
		}
		m_vectTempLocalPreample.clear( );
	}
}

const AtlasDeclareData* AtlasProcedure::GetVariable( const string& strVarName ) const
{
	const AtlasDeclareData* pDeclareData = 0;

	for ( int i = 0; i < 3; ++i )
	{
		const vector< AtlasDeclareData* >* pvectParameters;

		switch ( i )
		{
			case 0:
				pvectParameters = &m_vectParameters;
				break;

			case 1:
				pvectParameters = &m_vectResults;
				break;

			case 2:
				pvectParameters = &m_vectDeclares;
				break;
		}

		const unsigned int uiSize = pvectParameters->size( );

		for ( unsigned int ui = 0; ui < uiSize; ++ui )
		{
			AtlasDeclareData* pDeclare = pvectParameters->at( ui );

			if ( pDeclare->m_Declare.IsVariable( ) )
			{
				if ( strVarName == pDeclare->m_Declare.m_strVarName )
				{
					pDeclareData = pDeclare;
					break;
				}
			}
		}

		if ( 0 != pDeclareData )
		{
			break;
		}
	}

	return pDeclareData;
}

void AtlasProcedure::SetStatementsParent( void )
{
	AtlasStatementContainer::SetStatementsParent( this );
}