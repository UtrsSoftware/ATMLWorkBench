/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

#include "enable.h"
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


AtlasEnable& AtlasEnable::operator = ( const AtlasStatement& other )
{
	if ( this != &other )
	{
		AtlasStatement::operator = ( other );

		GarbageCollect( );

		const AtlasEnable* pother = dynamic_cast< const AtlasEnable* >( &other );

		if ( 0 != pother )
		{
		}
	}

	return *this;
}

void AtlasEnable::Init( void )
{ 
	m_pCassExtension_File = 0;
}

void AtlasEnable::GarbageCollect( void )
{ 
	if ( 0 != m_pCassExtension_File )
	{
		delete m_pCassExtension_File;
		m_pCassExtension_File = 0;
	}
}

void AtlasEnable::InitFromXML( const StatementMetadata* pData )
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

void AtlasEnable::Process( const Lookup* pLookup )
{
	const unsigned int uiSize = m_vectAttributes.size( );

	if ( uiSize > 0 )
	{
		if ( AtlasStatement::m_strFILE == m_vectAttributes[ 0 ]->m_strValue )
		{
			GetFileInfo( uiSize );
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

void AtlasEnable::GetFileInfo( const unsigned int uiSize )
{
	if ( 5 == uiSize )
	{
		try
		{
			m_pCassExtension_File = new CassExtension_File;
		}
		catch ( ... )
		{
			throw Exception( Exception::eFailedToCreateFileObject, __FILE__, __FUNCTION__, __LINE__ );
		}

		if ( AtlasStatement::m_strNEW == m_vectAttributes[ 1 ]->m_strValue )
		{
			m_pCassExtension_File->m_bNew = true;
		}
		else if ( AtlasStatement::m_strOLD == m_vectAttributes[ 1 ]->m_strValue )
		{
			m_pCassExtension_File->m_bNew = false;
		}
		#if ( _DEBUG ) && ( WIN32 )
		else
		{
			DebugBreak( );
		}
		#endif

		if ( m_vectAttributes[ 2 ]->IsVariable( ) )
		{
			m_pCassExtension_File->m_Filename.SetVariableName( m_vectAttributes[ 2 ]->m_strValue );
			m_pCassExtension_File->m_Filename.Set( m_vectAttributes[ 2 ]->m_strValue );
			m_pCassExtension_File->m_Filename.SetRefIdRequired( false );

			m_multimapVariables.insert( make_pair( m_vectAttributes[ 2 ]->m_strValue, &( m_pCassExtension_File->m_Filename ) ) );
		}
		else if ( m_vectAttributes[ 2 ]->IsString( ) )
		{
			m_pCassExtension_File->m_Filename.Set( m_vectAttributes[ 2 ]->m_strValue );
		}
		#if ( _DEBUG ) && ( WIN32 )
		else
		{
			DebugBreak( );
		}
		#endif

		if ( AtlasStatement::m_strFILEACCESS == m_vectAttributes[ 3 ]->m_strValue )
		{
			m_pCassExtension_File->m_eFileAccess = Atlas::GetAtlasInputOutputAttributeEnum( m_vectAttributes[ 4 ]->m_strValue );

			#if ( _DEBUG ) && ( WIN32 )
			if ( Atlas::eUnknownInputOutputAttribute == m_pCassExtension_File->m_eFileAccess )
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
	#if ( _DEBUG ) && ( WIN32 )
	else
	{
		DebugBreak( );
	}
	#endif
}

void AtlasEnable::ToXML( string& strXML ) const
{
	const string strId( XML::MakeXmlAttributeNameValue( XML::anId, m_uiId ) );

	strXML += XML::MakeOpenXmlElementWithChildren( XML::enEnable, strId, GetStatementCommentRefId_XML( ) );

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

	if ( 0 != m_pCassExtension_File )
	{
		m_pCassExtension_File->ToXML( strXML );
	}

	strXML += XML::MakeCloseXmlElementWithChildren( XML::enEnable );
}

void AtlasEnable::CassExtension_File::ToXML( string& strXML ) const
{
	const string strNew( XML::MakeXmlAttributeNameValue( XML::anNew, ( m_bNew ? XML::avTrue : XML::avFalse ) ) );
	const string strFileAccess( XML::MakeXmlAttributeNameValue( XML::anAccess, Atlas::GetAtlasInputOutput( m_eFileAccess ) ) );
	string strFilename;

	if ( 0 == m_Filename.GetVariableRefId( ) )
	{
		strFilename = XML::MakeXmlAttributeNameValue( XML::anName, *( m_Filename.Get( ) ) );
	}
	else
	{
		strFilename = m_Filename.AtlasData::ToXML( false );
	}

	strXML += XML::MakeXmlElementNoChildren( XML::enFile, strFilename, strNew, strFileAccess );
}