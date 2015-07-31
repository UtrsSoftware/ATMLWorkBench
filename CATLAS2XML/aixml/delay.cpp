/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

#include "delay.h"
#include "atlas_noun_modifier.h"
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


AtlasDelay& AtlasDelay::operator = ( const AtlasStatement& other )
{
	if ( this != &other )
	{
		AtlasStatement::operator = ( other );

		GarbageCollect( );

		const AtlasDelay* pother = dynamic_cast< const AtlasDelay* >( &other );

		if ( 0 != pother )
		{
			m_bMinumum = pother->m_bMinumum;
		}
	}

	return *this;
}

void AtlasDelay::Init( void )
{ 
	m_bMinumum = false;
	m_pTime = 0;
	m_pErrorLimit = 0;
}

void AtlasDelay::GarbageCollect( void )
{ 
	if ( 0 != m_pTime )
	{
		delete m_pTime;
		m_pTime = 0;
	}

	if ( 0 != m_pErrorLimit )
	{
		delete m_pErrorLimit;
		m_pErrorLimit = 0;
	}
}

void AtlasDelay::InitFromXML( const StatementMetadata* pData )
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

void AtlasDelay::Process( const Lookup* pLookup )
{
	const unsigned int uiSize = m_vectAttributes.size( );

	if ( uiSize > 0 )
	{
		for ( unsigned int ui = 0; ui < uiSize; ++ui )
		{
			const AtlasAttibuteValue* pAttibuteValue = m_vectAttributes[ ui ];

			if ( pAttibuteValue->IsKeyword( ) )
			{
				if ( AtlasStatement::m_strMIN == pAttibuteValue->m_strValue )
				{
					m_bMinumum = true;
				}
				else if ( m_strERRLMT == m_vectAttributes[ ui ]->m_strValue )
				{
					++ui;

					Atlas::AtlasErrorLimit errorLimit( NounModifier::GetAtlasErrorLimit( string( ), m_vectAttributes, ui, true ) );

					if ( errorLimit.IsLimit( ) )
					{
						GetVariables( &errorLimit );

						try
						{
							m_pErrorLimit = new Atlas::AtlasErrorLimit( errorLimit );
						}
						catch ( ... )
						{
							throw Exception( Exception::eFailedToCreateLimitObject, __FILE__, __FUNCTION__, __LINE__ );
						}
					}
					#if ( _DEBUG ) && ( WIN32 )
					else
					{
						DebugBreak( );
					}
					#endif
				}
				else if ( 0 != m_pTime )
				{
					const Atlas::AtlasUnitOfMeasure AtlasUnit( NounModifier::GetAtlasUnitOfMeasureByAlasUnit( pAttibuteValue->m_strValue, false ) );

					m_pTime->SetUnitOfMeasure( AtlasUnit );

					#if ( _DEBUG ) && ( WIN32 )
					if ( !AtlasUnit.IsUnit( ) )
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
			else if ( pAttibuteValue->IsVariable( ) )
			{
				#if ( _DEBUG ) && ( WIN32 )
				if ( 0 != m_pTime )
				{
					DebugBreak( );
				}
				#endif

				try
				{
					m_pTime = new Atlas::AtlasData( pAttibuteValue->m_strValue );
				}
				catch ( ... )
				{
					throw Exception( Exception::eFailedToCreateAtlasVariableObject, __FILE__, __FUNCTION__, __LINE__ );
				}

				m_multimapVariables.insert( make_pair( m_pTime->GetVariableName( ), m_pTime ) );
			}
			else if ( pAttibuteValue->IsConstant( ) )
			{
				#if ( _DEBUG ) && ( WIN32 )
				if ( 0 != m_pTime )
				{
					DebugBreak( );
				}
				#endif

				try
				{
					m_pTime = new Atlas::AtlasNumber( pAttibuteValue->m_strValue );
				}
				catch ( ... )
				{
					throw Exception( Exception::eFailedToCreateNumberObject, __FILE__, __FUNCTION__, __LINE__ );
				}
			}
		}
	}
}

void AtlasDelay::ToXML( string& strXML ) const
{
	if ( 0 != m_pTime )
	{
		const string strId( XML::MakeXmlAttributeNameValue( XML::anId, m_uiId ) );
		string strMinumum;

		if ( m_bMinumum )
		{
			strMinumum = XML::MakeXmlAttributeNameValue( XML::anMinimum, XML::avTrue );
		}

		strXML += XML::MakeOpenXmlElementWithChildren( XML::enDelay, strId, GetStatementCommentRefId_XML( ) );
	
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

		if ( 0 == m_pErrorLimit )
		{
			strXML += XML::MakeXmlElementNoChildren( XML::enNumber, m_pTime->ToXML( ), strMinumum );
		}
		else
		{
			strXML += XML::MakeOpenXmlElementWithChildren( XML::enNumber, m_pTime->ToXML( ) );

			strXML += m_pErrorLimit->ToXML( );

			strXML += XML::MakeCloseXmlElementWithChildren( XML::enNumber );
		}
		
		strXML += XML::MakeCloseXmlElementWithChildren( XML::enDelay );
	}
}