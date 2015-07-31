/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

#include "complex_signal.h"
#include "atlas_noun_modifier.h"
#include "specify.h"
#include "exception.h"
#include "aixml.h"
#include "atlas_statistics.h"

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


AtlasComplexSignal& AtlasComplexSignal::operator = ( const AtlasStatement& other )
{
	if ( this != &other )
	{
		AtlasStatement::operator = ( other );

		GarbageCollect( );

		const AtlasComplexSignal* pother = dynamic_cast< const AtlasComplexSignal* >( &other );

		if ( 0 != pother )
		{
		}
	}

	return *this;
}

void AtlasComplexSignal::Init( void )
{ 
	m_eScope = eLocal;
	m_bUsed = false;
	m_strSignalName.clear( );
	m_pRequireStatements = 0;
}

void AtlasComplexSignal::GarbageCollect( void )
{ 
	const unsigned int uiSize = m_vectSpecify.size( );

	if ( uiSize > 0 )
	{
		for ( unsigned int ui = 0; ui < uiSize; ++ui )
		{
			delete m_vectSpecify[ ui ];
		}

		m_vectSpecify.clear( );
	}

	Init( );
}

void AtlasComplexSignal::InitFromXML( const xercesc::DOMElement* pAIXMLvalue, const Atlas::AtlasSourceStatement::eSourceType eSourcType, const string& strFilename )
{
	if ( 0 != pAIXMLvalue )
	{
		unsigned int uiCommentId = GetCommentId( pAIXMLvalue );
		string strAIXMLtagName;

		const xercesc::DOMElement* pDefineCSChild = pAIXMLvalue->getFirstElementChild( );

		if ( 0 != pDefineCSChild )
		{
			AIXMLHelper::GetXercesString( pDefineCSChild->getTagName( ), strAIXMLtagName );

			if ( AIXML::m_arrayXMLKeyWords[ AIXML::eDefineComplexSignalElement ] == strAIXMLtagName )
			{
				const DOMAttr* pAttr = pDefineCSChild->getAttributeNode( AIXMLHelper::GetWString( AIXML::m_arrayXMLKeyWords[ AIXML::eScopeAttribute ] ).c_str( ) );
			
				if ( 0 != pAttr )
				{
					AIXMLHelper::GetXercesString( pAttr->getValue( ), strAIXMLtagName );
			
					m_eScope = GetScopeEnum( strAIXMLtagName );
				}

				const xercesc::DOMElement* pComplexSignalName = pDefineCSChild->getFirstElementChild( );

				if ( 0 != pComplexSignalName )
				{
					AIXMLHelper::GetXercesString( pComplexSignalName->getTagName( ), strAIXMLtagName );

					if ( AIXML::m_arrayXMLKeyWords[ AIXML::eNameElement ] == strAIXMLtagName )
					{
						pAttr = pComplexSignalName->getAttributeNode( AIXMLHelper::GetWString( AIXML::m_arrayXMLKeyWords[ AIXML::eNameAttribute ] ).c_str( ) );
				
						if ( 0 != pAttr )
						{
							AIXMLHelper::GetXercesString( pAttr->getValue( ), m_strSignalName );
						}
					}
				}

				m_uiId = SetSourceStatementInfo( pDefineCSChild, eSourcType, strFilename, string( ), 0 );

				if ( uiCommentId > 0 )
				{
					if ( m_vectAtlasSourceStatement.size( ) > 0 )
					{
						m_vectAtlasSourceStatement[ 0 ].SetCommentId( uiCommentId );
					}
				}
		
				const xercesc::DOMElement* pStatements = pDefineCSChild->getNextElementSibling( );

				if ( 0 != pStatements )
				{
					const xercesc::DOMElement* pStatement = pStatements->getFirstElementChild( );

					while ( 0 != pStatement )
					{
						AIXMLHelper::GetXercesString( pStatement->getTagName( ), strAIXMLtagName );
			
						if ( AIXML::m_arrayXMLKeyWords[ AIXML::eSpecifyElement ] == strAIXMLtagName )
						{
							AtlasSpecify* pSpecify = 0;
								
							try
							{
								pSpecify = new AtlasSpecify( m_pRequireStatements );
							}
							catch ( ... )
							{
								throw Exception( Exception::eFailedToAllocateMemoryForAtlasSpecifyObject, __FILE__, __FUNCTION__, __LINE__ );
							}

							m_vectSpecify.push_back( pSpecify );

							pSpecify->InitFromXML( pStatement, eSourcType, strFilename );
						}

						pStatement = pStatement->getNextElementSibling( );
					}
				}
			}
		}
	}
}

void AtlasComplexSignal::Process( const Lookup* pLookup )
{
	const unsigned int uiSize = m_vectSpecify.size( );

	if ( uiSize > 0 )
	{
		for ( unsigned int ui = 0; ui < uiSize; ++ui )
		{
			m_vectSpecify[ ui ]->Process( pLookup );
		}
	}
}

void AtlasComplexSignal::ProcessVariableSymbols( const map< string, vector< AtlasDeclareData* >* >& mapDeclares, const map< Atlas::AtlasData::eBuiltInType, AtlasDeclareData* >& mapBuiltinDeclares, const AtlasProcedure* pProcedure, const vector< pair< string, Atlas::AtlasSourceStatement::eSourceType > >* pvectAtlasSourceFiles )
{
	const unsigned int uiSize = m_vectSpecify.size( );

	if ( uiSize > 0 )
	{
		for ( unsigned int ui = 0; ui < uiSize; ++ui )
		{
			m_vectSpecify[ ui ]->ProcessVariableSymbols( mapDeclares, mapBuiltinDeclares, pProcedure, pvectAtlasSourceFiles );
		}
	}
}

void AtlasComplexSignal::InitSignalInfo( AtlasSignalInfo* pInformation ) const
{
	const unsigned int uiSize = m_vectSpecify.size( );

	for ( unsigned int ui = 0; ui < uiSize; ++ui )
	{
		 ( ( AtlasSpecify* ) m_vectSpecify[ ui ] )->InitSignalInfo( pInformation );
	}
}

void AtlasComplexSignal::SetStatistics( AtlasStatistics* pStatistics ) const
{
	const unsigned int uiSize = m_vectSpecify.size( );

	pStatistics->SetStatementCount( Atlas::eSPECIFY, uiSize );

	for ( unsigned int ui = 0; ui < uiSize; ++ui )
	{
		AtlasSpecify* pSpecify = ( AtlasSpecify* ) m_vectSpecify[ ui ];

		pStatistics->SetSignalCount( pSpecify->m_PrimarySignalComponent.GetAtlasNoun( ), 1 );
	}
}

void AtlasComplexSignal::ToXML( string& strXML ) const
{
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

	strXML += XML::MakeXmlElementNoChildren( XML::enSignalName, XML::MakeXmlAttributeNameValue( XML::anName, m_strSignalName ) );

	const unsigned int uiSpecifies = m_vectSpecify.size( );

	if ( uiSpecifies > 0 )
	{
		strXML += XML::MakeOpenXmlElementWithChildren( XML::enSpecifies, XML::MakeXmlAttributeNameValue( XML::anCount, uiSpecifies ) );

		for ( unsigned int ui = 0; ui < uiSpecifies; ++ui )
		{
			m_vectSpecify[ ui ]->ToXML( strXML );
		}

		strXML += XML::MakeCloseXmlElementWithChildren( XML::enSpecifies );
	}
}