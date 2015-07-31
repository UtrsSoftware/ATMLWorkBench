/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

#include "perform.h"
#include "exception.h"
#include "aixml.h"
#include "DOMStatements.h"
#include "xml.h"

#ifdef CASS
	#include "cass/lookup.h"
#else
	#error Need instruments implementation (i.e. CASS)
#endif


// Xercesc XML Parser
#include <xercesc/dom/dom.hpp>

#if ( _DEBUG ) && ( WIN32 )
	#define WINVER 0x0600
	#include <afx.h>
	#define new DEBUG_NEW
	#undef THIS_FILE
	static char BASED_CODE THIS_FILE[ ] = __FILE__;
#endif

using namespace XERCES_CPP_NAMESPACE;


AtlasPerform& AtlasPerform::operator = ( const AtlasStatement& other )
{
	if ( this != &other )
	{
		AtlasStatement::operator = ( other );

		GarbageCollect( );

		const AtlasPerform* pother = dynamic_cast< const AtlasPerform* >( &other );

		if ( 0 != pother )
		{
			m_strProcedureName = pother->m_strProcedureName;
			m_strCallStack = pother->m_strCallStack;
			m_bRecursive = pother->m_bRecursive;
		}
	}

	return *this;
}

void AtlasPerform::InitFromXML( const StatementMetadata* pData )
{
	if ( 0 != pData )
	{
		if ( 0 != pData->m_pStatement )
		{
			string strAIXMLtagName;
	
			SetSourceStatementInfo( pData->m_pStatement, pData->m_eSourceType, pData->m_strFilename, pData->m_strParentProcedureName, pData->m_uiParentProcedureId );
	
			m_uiConditionalStatementsId = pData->m_uiParentConditionalStatementsId;
	
			const xercesc::DOMElement* pStatement = pData->m_pStatement->getFirstElementChild( );
	
			AIXMLHelper::GetXercesString( pStatement->getTagName( ), strAIXMLtagName );
	
			if ( AIXML::m_arrayXMLKeyWords[ AIXML::eNameElement ] == strAIXMLtagName )
			{
				const DOMAttr* pAttr = pStatement->getAttributeNode( AIXMLHelper::GetWString( AIXML::m_arrayXMLKeyWords[ AIXML::eNameAttribute ] ).c_str( ) );
	
				if ( 0 != pAttr )
				{
					AIXMLHelper::GetXercesString( pAttr->getValue( ), m_strProcedureName );
				}
	
				pStatement = pStatement->getNextElementSibling( );
	
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
				}
			}
		}
	}
}

void AtlasPerform::Process( const Lookup* pLookup )
{
	if ( !m_bProcessed )
	{
		const unsigned int uiSize = m_vectAttributes.size( );
	
		if ( uiSize > 0 )
		{
			for ( unsigned int ui = 0; ui < uiSize; ++ui )
			{
				AtlasAttibuteValue* pAttibuteValue = ( AtlasAttibuteValue* ) m_vectAttributes[ ui ];
				const XML::AttributeValue avType = pAttibuteValue->GetDataType( );
	
				if ( XML::avUnknown == avType )
				{
					if ( pAttibuteValue->IsKeyword( ) )
					{
						if ( IsConnector( pAttibuteValue->m_strValue, pLookup ) )
						{
							Atlas::AtlasConnector* pConnector = 0;
								
							try
							{
								pConnector = new Atlas::AtlasConnector( pAttibuteValue->m_strValue );
							}
							catch ( ... )
							{
								throw Exception( Exception::eFailedToCreateConnectorObject, __FILE__, __FUNCTION__, __LINE__ );
							}

							m_vectParameterValues.push_back( pConnector );
						}
						else
						{
							#if ( _DEBUG ) && ( WIN32 )
								DebugBreak( );
							#endif
						}
					}
					else
					{
						#if ( _DEBUG ) && ( WIN32 )
							DebugBreak( );
						#endif
					}
				}
				else
				{
					switch ( avType )
					{
						case XML::avConstant:
							{
								Atlas::AtlasNumber* pNumber = 0;
									
								try
								{
									pNumber = new Atlas::AtlasNumber( pAttibuteValue->m_strValue );
								}
								catch ( ... )
								{
									throw Exception( Exception::eFailedToCreateNumberObject, __FILE__, __FUNCTION__, __LINE__ );
								}
								
								m_vectParameterValues.push_back( pNumber );
							}
							break;

						case XML::avChar:
							{
								Atlas::AtlasString* pString = 0;
									
								try
								{
									pString = new Atlas::AtlasString( pAttibuteValue->m_strValue );
								}
								catch ( ... )
								{
									throw Exception( Exception::eFailedToCreateStringObject, __FILE__, __FUNCTION__, __LINE__ );
								}
								
								m_vectParameterValues.push_back( pString );
							}
							break;

						case XML::avVariable:
							{
								Atlas::AtlasData* pVar = 0;
									
								try
								{
									pVar = new Atlas::AtlasData;
								}
								catch ( ... )
								{
									throw Exception( Exception::eFailedToCreateAtlasVariableObject, __FILE__, __FUNCTION__, __LINE__ );
								}

								pVar->SetVariableName( pAttibuteValue->m_strValue );
								
								m_vectParameterValues.push_back( pVar );
								m_multimapVariables.insert( make_pair( pVar->GetVariableName( ), pVar ) );
							}
							break;

						case XML::avBoolean:
							{
								Atlas::AtlasBool* pBool = 0;
									
								try
								{
									pBool = new Atlas::AtlasBool( AtlasStatement::m_strTRUE == pAttibuteValue->m_strValue );
								}
								catch ( ... )
								{
									throw Exception( Exception::eFailedToCreateAtlasBooleanObject, __FILE__, __FUNCTION__, __LINE__ );
								}
								
								m_vectParameterValues.push_back( pBool );
							}
							break;

						default:
							#if ( _DEBUG ) && ( WIN32 )
								DebugBreak( );
							#endif
							break;
					}
				}
			}
		}

		m_bProcessed = true;
	}
}

void AtlasPerform::ToXML( string& strXML, const bool bParametersOnly ) const
{
	string strNameAttr;
	string strIdAttr;
	string strProcRefId;
	string strRecursizeAttr;
	string strCallStackAttr;

	if ( bParametersOnly )
	{
		unsigned int uiSize = m_vectAtlasSourceStatement.size( );
		if ( uiSize > 0 )
		{
			unsigned int uiFields = Atlas::AtlasSourceStatement::eXmlFilename;
	
			uiFields |= Atlas::AtlasSourceStatement::eXmlStatementNumber;
			uiFields |= Atlas::AtlasSourceStatement::eXmlLineNumber;
			uiFields |= Atlas::AtlasSourceStatement::eXmlSourceType;
	
			strXML += m_vectAtlasSourceStatement[ 0 ].ToXML( uiFields );
		}
	}
	else
	{
		strNameAttr = XML::MakeXmlAttributeNameValue( XML::anName, m_strProcedureName );
		strIdAttr = XML::MakeXmlAttributeNameValue( XML::anId, m_uiId );
		strProcRefId = XML::MakeXmlAttributeNameValue( XML::anProcRefId, m_uiProcedureId );
	
		if ( m_bRecursive )
		{
			strRecursizeAttr = XML::MakeXmlAttributeNameValue( XML::anRecursive, XML::avTrue );
		}
	
		if ( !m_strCallStack.empty( ) )
		{
			strCallStackAttr = XML::MakeXmlAttributeNameValue( XML::anCallStack, m_strCallStack );
		}
	}

	const unsigned int uiSize = m_vectParameterValues.size( );

	if ( 0 == uiSize )
	{
		if ( !bParametersOnly )
		{
			strXML += XML::MakeXmlElementNoChildren( XML::enPerform, strNameAttr, strIdAttr, strProcRefId, strRecursizeAttr, strCallStackAttr );
		}
	}
	else
	{
		if ( !bParametersOnly )
		{
			strXML += XML::MakeOpenXmlElementWithChildren( XML::enPerform, strNameAttr, strIdAttr, strProcRefId, strRecursizeAttr, strCallStackAttr );
		}

		strXML += XML::MakeOpenXmlElementWithChildren( XML::enParameters, XML::MakeXmlAttributeNameValue( XML::anCount, uiSize ) );

		for ( unsigned int ui = 0; ui < uiSize; ++ui )
		{
			strXML += XML::MakeXmlElementNoChildren( XML::enParameter, m_vectParameterValues[ ui ]->ToXML( ) );
		}

		strXML += XML::MakeCloseXmlElementWithChildren( XML::enParameters );

		if ( !bParametersOnly )
		{
			strXML += XML::MakeCloseXmlElementWithChildren( XML::enPerform );
		}
	}
}

bool AtlasPerform::IsConnector( const string& str, const Lookup* pLookup )
{
	bool bIsConnector = false;

	if ( !str.empty( ) && ( 0 != pLookup ) )
	{
		Lookup::Subfile2* pSubfile2 = ( Lookup::Subfile2* ) pLookup->GetSubfile( 2 );

		if ( 0 != pSubfile2 )
		{
			bIsConnector = pSubfile2->IsUserPinName( str );
		}
	}

	return bIsConnector;
}