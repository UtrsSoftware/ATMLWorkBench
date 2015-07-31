/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

#include "leave.h"
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


AtlasLeave& AtlasLeave::operator = ( const AtlasStatement& other )
{
	if ( this != &other )
	{
		AtlasStatement::operator = ( other );

		GarbageCollect( );

		const AtlasLeave* pother = dynamic_cast< const AtlasLeave* >( &other );

		if ( 0 != pother )
		{
			m_strStatementNumber = pother->m_strStatementNumber;
			m_strProcedureName = pother->m_strProcedureName;
			m_uiRefId = pother->m_uiRefId;
		}
	}

	return *this;
}

void AtlasLeave::InitFromXML( const StatementMetadata* pData )
{
	if ( 0 != pData )
	{
		if ( 0 != pData->m_pStatement )
		{
			string strAIXMLtagName;
	
			m_uiConditionalStatementsId = pData->m_uiParentConditionalStatementsId;
	
			SetSourceStatementInfo( pData->m_pStatement, pData->m_eSourceType, pData->m_strFilename, pData->m_strParentProcedureName, pData->m_uiParentProcedureId );
	
			const xercesc::DOMElement* pStatement = pData->m_pStatement->getFirstElementChild( );

			if ( 0 != pStatement )
			{
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
				else if ( AIXML::m_arrayXMLKeyWords[ AIXML::eGroupElement ] == strAIXMLtagName )
				{
					const DOMAttr* pAttr = pStatement->getAttributeNode( AIXMLHelper::GetWString( AIXML::m_arrayXMLKeyWords[ AIXML::eNameAttribute ] ).c_str( ) );

					if ( 0 != pAttr )
					{
						AIXMLHelper::GetXercesString( pAttr->getValue( ), m_strProcedureName );
					}
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

void AtlasLeave::Process( const Lookup* pLookup )
{
	const unsigned int uiSize = m_vectAttributes.size( );

	if ( uiSize > 0 )
	{
		if ( 2 == uiSize )
		{
			if ( AtlasStatement::m_strSTEP == m_vectAttributes[ 0 ]->m_strValue )
			{
				m_strStatementNumber = m_vectAttributes[ 1 ]->m_strValue;
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

Atlas::eAtlasStatement AtlasLeave::GetConditionalStatementType( void ) const
{
	Atlas::eAtlasStatement eStatement = Atlas::eUnknownAtlasStatement;

	switch ( m_eAtlasStatement )
	{
		case Atlas::eLEAVE_PROCEDURE:
			eStatement = Atlas::eDEFINE_PROCEDURE;
			break;

		case Atlas::eLEAVE_IF:
			eStatement = Atlas::eIF_THEN;
			break;

		case Atlas::eLEAVE_FOR:
			eStatement = Atlas::eFOR_THEN;
			break;

		case Atlas::eLEAVE_WHILE:
			eStatement = Atlas::eWHILE_THEN;
			break;
	}

	return eStatement;
}

void AtlasLeave::ToXML( string& strXML ) const
{
	const string strCommentId( GetStatementCommentRefId_XML( ) );
	const string strBeginTest( GetStatementBeginTest_XML( ) );
	const string strTestNumber( GetStatementTestNumber_XML( ) );

	strXML += XML::MakeOpenXmlElementWithChildren( XML::enStatement, XML::MakeXmlAttributeNameValue( XML::anType, GetStatementType( ) ), XML::MakeXmlAttributeNameValue( XML::anId, m_uiId ), strTestNumber, strBeginTest, strCommentId );

	unsigned int uiSize = m_vectAtlasSourceStatement.size( );
	if ( uiSize > 0 )
	{
		unsigned int uiFields = Atlas::AtlasSourceStatement::eXmlFilename;

		uiFields |= Atlas::AtlasSourceStatement::eXmlStatementNumber;
		uiFields |= Atlas::AtlasSourceStatement::eXmlLineNumber;
		uiFields |= Atlas::AtlasSourceStatement::eXmlSourceType;

		strXML += m_vectAtlasSourceStatement[ 0 ].ToXML( uiFields );
	}

	string strRefId;
	string strStatementNumber;

	if ( !m_strStatementNumber.empty( ) )
	{
		strStatementNumber = XML::MakeXmlAttributeNameValue( XML::anStatementNumber, m_strStatementNumber );
	}

	if ( Atlas::eLEAVE_PROCEDURE != m_eAtlasStatement )
	{
		if ( -1 == m_uiRefId )
		{
			strRefId = XML::MakeXmlAttributeNameValue( XML::anLeaveProcedure, XML::avTrue );
		}
		else
		{
			strRefId = XML::MakeXmlAttributeNameValue( XML::anRefId, m_uiRefId );
		}

		strXML += XML::MakeXmlElementNoChildren( XML::enTarget, strStatementNumber, strRefId );
	}

	strXML += XML::MakeCloseXmlElementWithChildren( XML::enStatement );
}