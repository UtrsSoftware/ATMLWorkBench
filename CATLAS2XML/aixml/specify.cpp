/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

#include "specify.h"
#include "exception.h"
#include "cnx.h"
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


AtlasSpecify& AtlasSpecify::operator = ( const AtlasStatement& other )
{
	if ( this != &other )
	{
		AtlasActionSignalVerb::operator = ( other );

		GarbageCollect( );

		const AtlasSpecify* pother = dynamic_cast< const AtlasSpecify* >( &other );

		if ( 0 != pother )
		{
			m_bComplexFunction = pother->m_bComplexFunction;
			m_eAtlasSpecifyType = pother->m_eAtlasSpecifyType;
		}
	}

	return *this;
}

void AtlasSpecify::Init( void )
{ 
	m_bComplexFunction = false;
	m_eAtlasSpecifyType = Atlas::eUnknownAtlasSpecifyType;
}

void AtlasSpecify::GarbageCollect( void )
{ 
}

void AtlasSpecify::InitFromXML( const xercesc::DOMElement* pAIXMLvalue, const Atlas::AtlasSourceStatement::eSourceType eSourcType, const string& strFilename )
{
	if ( 0 != pAIXMLvalue )
	{
		string strAIXMLtagName;

		m_uiId = SetSourceStatementInfo( pAIXMLvalue, eSourcType, strFilename, string( ), 0 );

		const xercesc::DOMElement* pSpecifyChild = pAIXMLvalue->getFirstElementChild( );

		if ( 0 != pSpecifyChild )
		{
			AIXMLHelper::GetXercesString( pSpecifyChild->getTagName( ), strAIXMLtagName );

			if ( AIXML::m_arrayXMLKeyWords[ AIXML::eArgumentsElement ] == strAIXMLtagName )
			{
				const xercesc::DOMElement* pArgument = pSpecifyChild->getFirstElementChild( );

				while ( 0 != pArgument )
				{
					AtlasStatement::InitFromXML( pArgument );

					pArgument = pArgument->getNextElementSibling( );
				}
			}
		}
	}
}

void AtlasSpecify::Process( const Lookup* pLookup )
{
	if ( !m_bProcessed )
	{
		const unsigned int uiSize = m_vectAttributes.size( );
	
		if ( uiSize > 4 )
		{
			unsigned int ui = 0;
			string strAtlasNoun;
			Atlas::eAtlasNoun eNoun = Atlas::eUnknownAtlasNoun;

			if ( AtlasStatement::m_strAS == m_vectAttributes[ ui ]->m_strValue )
			{
				++ui;

				m_eAtlasSpecifyType = Atlas::GetAtlasSpecifyTypeEnum( m_vectAttributes[ ui++ ]->m_strValue );
			}
			else if ( ( AtlasStatement::m_strCOMPLEX == m_vectAttributes[ ui ]->m_strValue ) && ( AtlasStatement::m_strFUNCTION == m_vectAttributes[ ++ui ]->m_strValue ) )
			{
				++ui;
				m_bComplexFunction = true;
			}

			for ( ; ui < uiSize; ++ui )
			{
				if ( !strAtlasNoun.empty( ) )
				{
					strAtlasNoun += " ";
				}
		
				strAtlasNoun += m_vectAttributes[ ui ]->m_strValue;
		
				eNoun = Atlas::GetAtlasNounEnum( strAtlasNoun );
		
				if ( Atlas::eUnknownAtlasNoun != eNoun )
				{
					m_PrimarySignalComponent.SetAtlasNoun( eNoun );
					break;
				}
			}
		
			if ( Atlas::eUnknownAtlasNoun != eNoun )
			{
				GetConfiguration( uiSize, ui, pLookup );
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

		m_bProcessed = true;
	}

	InitSignalComponents( );
}

void AtlasSpecify::GetConfiguration( const unsigned int uiSize, unsigned int& ui, const Lookup* pLookup )
{
	++ui;

	if ( ui < uiSize )
	{
		if ( AtlasStatement::m_strUSING == m_vectAttributes[ ui ]->m_strValue )
		{
			++ui;

			if ( ui < uiSize )
			{
				m_strVirtualLabel = m_vectAttributes[ ui ]->m_strValue;

				#ifdef CASS
					m_eInstrument = pLookup->GetInstrumentEnum( m_strVirtualLabel, false );
					m_strSystemName = pLookup->GetSystemName( m_strVirtualLabel, false );
				#else
					m_eInstrument = SpecificInstrument::GetInstrument( m_strVirtualLabel, false );
					m_strSystemName = m_strVirtualLabel;
				#endif
			
				if ( SpecificInstrument::eUnknownInstrument != m_eInstrument )
				{
					vector< const AtlasAttibuteValue* > cnx;

					++ui;
	
					for ( ; ui < uiSize; ++ui )
					{
						ProcessAdditionalStatementConfiguration( uiSize, ui, cnx );
					}

					if ( cnx.size( ) > 0 )
					{
						ProcessCNXConfiguration( cnx, pLookup );
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
		#if ( _DEBUG ) && ( WIN32 )
		else
		{
			DebugBreak( );
		}
		#endif
	}
}

void AtlasSpecify::ToXML( string& strXML ) const
{
	string strAddtionalAttributes;

	if ( m_bComplexFunction )
	{
		strAddtionalAttributes = XML::MakeXmlAttributeNameValue( XML::anComplexFunction, XML::avTrue );
	}
	else
	{
		strAddtionalAttributes = XML::MakeXmlAttributeNameValue( XML::anSpecifyType, Atlas::GetAtlasSpecifyType( m_eAtlasSpecifyType ) );
	}

	AtlasActionSignalVerb::ToXML( strXML, strAddtionalAttributes );
}