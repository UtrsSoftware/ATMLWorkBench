/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

#include "wait_for.h"
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


AtlasWaitFor& AtlasWaitFor::operator = ( const AtlasStatement& other )
{
	if ( this != &other )
	{
		AtlasStatement::operator = ( other );

		GarbageCollect( );

		const AtlasWaitFor* pother = dynamic_cast< const AtlasWaitFor* >( &other );

		if ( 0 != pother )
		{
			m_bMinumum = pother->m_bMinumum;
			m_bManualIntervention = pother->m_bManualIntervention;
		}
	}

	return *this;
}

void AtlasWaitFor::Init( void )
{ 
	m_bMinumum = false;
	m_pTime = 0;
	m_pErrorLimit = 0;
}

void AtlasWaitFor::GarbageCollect( void )
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

void AtlasWaitFor::InitFromXML( const StatementMetadata* pData )
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

void AtlasWaitFor::Process( const Lookup* pLookup )
{
	const unsigned int uiSize = m_vectAttributes.size( );

	if ( uiSize > 0 )
	{
		// *** TODO: Need to handle "WAIT FOR EVENT" (differences exist between 1985 and 1995 standards)
		// TIMER (not in 1985)
		// DIGITAL TIMER (not in 1985)
		//
		//
		// "WAIT FOR TIME" and "WAIT FOR MANUAL INTERVENTION" handled.

		if ( 2 == uiSize )
		{
			const AtlasAttibuteValue* pAttibuteValue1 = m_vectAttributes[ 0 ];
			const AtlasAttibuteValue* pAttibuteValue2 = m_vectAttributes[ 1 ];

			if ( pAttibuteValue1->IsKeyword( ) && pAttibuteValue2->IsKeyword( ) )
			{
				const bool bManual = ( AtlasStatement::m_strMANUAL == pAttibuteValue1->m_strValue );
				const bool bIntervention = ( AtlasStatement::m_strINTERVENTION == pAttibuteValue2->m_strValue );

				if ( bManual && bIntervention )
				{
					m_bManualIntervention = true;
				}
			}
		}

		if ( !m_bManualIntervention )
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
}

void AtlasWaitFor::ToXML( string& strXML ) const
{
	if ( ( 0 != m_pTime ) || m_bManualIntervention )
	{
		const string strId( XML::MakeXmlAttributeNameValue( XML::anId, m_uiId ) );
		string strManualIntervention;

		if ( m_bManualIntervention )
		{
			strManualIntervention = XML::MakeXmlAttributeNameValue( XML::anManualIntervention, XML::avTrue );
		}

		strXML += XML::MakeOpenXmlElementWithChildren( XML::enWaitFor, strId, strManualIntervention, GetStatementCommentRefId_XML( ) );
	
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

		if ( !m_bManualIntervention )
		{
			string strMinumum;
	
			if ( m_bMinumum )
			{
				strMinumum = XML::MakeXmlAttributeNameValue( XML::anMinimum, XML::avTrue );
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
		}
		
		strXML += XML::MakeCloseXmlElementWithChildren( XML::enWaitFor );
	}
}