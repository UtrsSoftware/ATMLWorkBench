/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

#include "leave_resume_atlas.h"
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


AtlasLeaveResume& AtlasLeaveResume::operator = ( const AtlasStatement& other )
{
	if ( this != &other )
	{
		AtlasStatement::operator = ( other );

		GarbageCollect( );

		const AtlasLeaveResume* pother = dynamic_cast< const AtlasLeaveResume* >( &other );

		if ( 0 != pother )
		{
			m_uiIPLRefId = pother->m_uiIPLRefId;
			m_IPLStartLine = pother->m_IPLStartLine;

			//m_pvectIPL
		}
	}

	return *this;
}

void AtlasLeaveResume::InitFromXML( const StatementMetadata* pData )
{
	if ( 0 != pData )
	{
		if ( 0 != pData->m_pStatement )
		{
			const bool bResume = ( Atlas::eRESUME_ATLAS == m_eAtlasStatement );
			string strAIXMLtagName;
	
			m_uiConditionalStatementsId = pData->m_uiParentConditionalStatementsId;
	
			const xercesc::DOMElement* pStatement = pData->m_pStatement->getFirstElementChild( );

			if ( 0 != pStatement )
			{
				if ( bResume )
				{
					while ( 0 != pStatement )
					{
						AIXMLHelper::GetXercesString( pStatement->getTagName( ), strAIXMLtagName );
				
						if ( AIXML::m_arrayXMLKeyWords[ AIXML::eCodeBlockElement ] == strAIXMLtagName )
						{
							const DOMAttr* pAttr = pStatement->getAttributeNode( AIXMLHelper::GetWString( AIXML::m_arrayXMLKeyWords[ AIXML::eIdAttribute ] ).c_str( ) );
							if ( 0 != pAttr )
							{
								string strId;
		
								AIXMLHelper::GetXercesString( pAttr->getValue( ), strId );
	
								m_uiIPLRefId = AIXMLHelper::StringToNumber< unsigned int >( strId );
							}
						}
						else if ( AIXML::m_arrayXMLKeyWords[ AIXML::eResumeAtlasElement ] == strAIXMLtagName )
						{
							SetSourceStatementInfo( pStatement, pData->m_eSourceType, pData->m_strFilename, pData->m_strParentProcedureName, pData->m_uiParentProcedureId );

							break;
						}

						pStatement = pStatement->getNextElementSibling( );
					}
				}
				else
				{
					SetSourceStatementInfo( pStatement, pData->m_eSourceType, pData->m_strFilename, pData->m_strParentProcedureName, pData->m_uiParentProcedureId );

					while ( 0 != pStatement )
					{
						AIXMLHelper::GetXercesString( pStatement->getTagName( ), strAIXMLtagName );
				
						if ( AIXML::m_arrayXMLKeyWords[ AIXML::eCodeBlockElement ] == strAIXMLtagName )
						{
							const DOMAttr* pAttr = pStatement->getAttributeNode( AIXMLHelper::GetWString( AIXML::m_arrayXMLKeyWords[ AIXML::eIdAttribute ] ).c_str( ) );
							if ( 0 != pAttr )
							{
								string strId;
		
								AIXMLHelper::GetXercesString( pAttr->getValue( ), strId );
	
								m_uiIPLRefId = AIXMLHelper::StringToNumber< unsigned int >( strId );
							}

							const xercesc::DOMElement* pCode = pStatement->getFirstElementChild( );

							if ( 0 != pCode )
							{
								try
								{
									m_pvectIPL = new vector< pair< unsigned int, string > >( );
								}
								catch ( ... )
								{
									throw Exception( Exception::eFailedToCreateVectorObject, __FILE__, __FUNCTION__, __LINE__ );
								}

								while ( 0 != pCode )
								{
									unsigned int uiLine = 0;
									string strIPL;

									const DOMAttr* pAttr = pCode->getAttributeNode( AIXMLHelper::GetWString( AIXML::m_arrayXMLKeyWords[ AIXML::eLineAttribute ] ).c_str( ) );
									if ( 0 != pAttr )
									{
										string strLine;
				
										AIXMLHelper::GetXercesString( pAttr->getValue( ), strLine );
			
										uiLine = AIXMLHelper::StringToNumber< unsigned int >( strLine );
									}

									const xercesc::DOMNode* pIPL = pCode->getFirstChild( );
									if ( 0 != pIPL )
									{
										if ( DOMNode::TEXT_NODE == pIPL->getNodeType( ) )
										{
											AIXMLHelper::GetXercesString( pIPL->getTextContent( ), strIPL );
										}
									}

									if ( 0 == m_IPLStartLine )
									{
										m_IPLStartLine = uiLine;
									}

									m_pvectIPL->push_back( make_pair( uiLine, strIPL ) );

									pCode = pCode->getNextElementSibling( );
								}
							}

							break;
						}

						pStatement = pStatement->getNextElementSibling( );
					}
				}
			}
		}
	}
}

void AtlasLeaveResume::Process( const Lookup* pLookup )
{
	const unsigned int uiSize = m_vectAttributes.size( );

	if ( 0 == uiSize )
	{
	}
	#if ( _DEBUG ) && ( WIN32 )
	else
	{
		DebugBreak( );
	}
	#endif
}

void AtlasLeaveResume::ToXML( string& strXML ) const
{
	const bool bResume = ( Atlas::eRESUME_ATLAS == m_eAtlasStatement );
	const XML::ElementName eName = ( bResume ? XML::enResumeAtlas : XML::enLeaveAtlas );
	const string strId( XML::MakeXmlAttributeNameValue( XML::anId, m_uiId ) );
	const string strIPLRefId( XML::MakeXmlAttributeNameValue( XML::anIPLRefId, m_uiIPLRefId ) );

	strXML += XML::MakeOpenXmlElementWithChildren( eName, strId, GetStatementCommentRefId_XML( ), strIPLRefId );

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

	strXML += XML::MakeCloseXmlElementWithChildren( eName );
}