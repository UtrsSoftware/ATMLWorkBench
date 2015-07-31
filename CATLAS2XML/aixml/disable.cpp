/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

#include "disable.h"
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


AtlasDisable& AtlasDisable::operator = ( const AtlasStatement& other )
{
	if ( this != &other )
	{
		AtlasStatement::operator = ( other );

		GarbageCollect( );

		const AtlasDisable* pother = dynamic_cast< const AtlasDisable* >( &other );

		if ( 0 != pother )
		{
		}
	}

	return *this;
}

void AtlasDisable::Init( void )
{ 
	m_pFilename = 0;
}

void AtlasDisable::GarbageCollect( void )
{ 
	if ( 0 != m_pFilename )
	{
		delete m_pFilename;
		m_pFilename = 0;
	}
}

void AtlasDisable::InitFromXML( const StatementMetadata* pData )
{
	if ( 0 != pData )
	{
		if ( 0 != pData->m_pStatement )
		{
			string strAIXMLtagName;
	
			m_uiConditionalStatementsId = pData->m_uiParentConditionalStatementsId;
	
			SetSourceStatementInfo( pData->m_pStatement, pData->m_eSourceType, pData->m_strFilename, pData->m_strParentProcedureName, pData->m_uiParentProcedureId );
	
			const xercesc::DOMElement* pStatement = pData->m_pStatement->getFirstElementChild( );
	
			AIXMLHelper::GetXercesString( pStatement->getTagName( ), strAIXMLtagName );
	
			if ( AIXML::m_arrayXMLKeyWords[ AIXML::eArgumentsElement ] == strAIXMLtagName )
			{
				pStatement = pStatement->getFirstElementChild( );
	
				while ( 0 != pStatement )
				{
					AtlasStatement::InitFromXML( pStatement );

					pStatement = pStatement->getNextElementSibling( );
				}
			}
		}
	}
}

void AtlasDisable::Process( const Lookup* pLookup )
{
	const unsigned int uiSize = m_vectAttributes.size( );

	if ( 2 == uiSize )
	{
		if ( AtlasStatement::m_strFILE == m_vectAttributes[ 0 ]->m_strValue )
		{
			if ( m_vectAttributes[ 1 ]->IsVariable( ) )
			{
				try
				{
					m_pFilename = new Atlas::AtlasString( m_vectAttributes[ 1 ]->m_strValue );
				}
				catch ( ... )
				{
					throw Exception( Exception::eFailedToCreateStringObject, __FILE__, __FUNCTION__, __LINE__ );
				}

				m_pFilename->SetVariableName( m_vectAttributes[ 1 ]->m_strValue );
				m_pFilename->SetRefIdRequired( false );
	
				m_multimapVariables.insert( make_pair( m_vectAttributes[ 1 ]->m_strValue, m_pFilename ) );
			}
			else if ( m_vectAttributes[ 1 ]->IsString( ) )
			{
				try
				{
					m_pFilename = new Atlas::AtlasString( m_vectAttributes[ 1 ]->m_strValue );
				}
				catch ( ... )
				{
					throw Exception( Exception::eFailedToCreateStringObject, __FILE__, __FUNCTION__, __LINE__ );
				}
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
}

void AtlasDisable::ToXML( string& strXML ) const
{
	const string strId( XML::MakeXmlAttributeNameValue( XML::anId, m_uiId ) );
	string strFilename;

	strXML += XML::MakeOpenXmlElementWithChildren( XML::enDisable, strId, GetStatementCommentRefId_XML( ) );

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

	if ( 0 != m_pFilename )
	{
		if ( 0 == m_pFilename->GetVariableRefId( ) )
		{
			strFilename = XML::MakeXmlAttributeNameValue( XML::anName, *( m_pFilename->Get( ) ) );
		}
		else
		{
			strFilename = m_pFilename->AtlasData::ToXML( false );
		}
	
		strXML += XML::MakeXmlElementNoChildren( XML::enFile, strFilename );
	}

	strXML += XML::MakeCloseXmlElementWithChildren( XML::enDisable );
}