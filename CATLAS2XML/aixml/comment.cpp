/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

#include "comment.h"
#include "DOMStatements.h"
#include "aixml.h"

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

void AtlasComment::Init( void )
{
	m_uiCommentLength = 0;
	m_bEntryPoint = false;
	m_bBranchDestination = false;
}

void AtlasComment::GarbageCollect( void )
{
	const unsigned int uiSize = m_vectCommentLines.size( );

	if ( uiSize > 0 )
	{
		for ( unsigned int ui = 0; ui < uiSize; ++ui )
		{
			delete m_vectCommentLines[ ui ];
		}
	
		m_vectCommentLines.clear( );
	}
}

AtlasComment& AtlasComment::operator = ( const AtlasStatement& other )
{
	if ( this != &other )
	{
		AtlasStatement::operator = ( other );

		GarbageCollect( );

		const AtlasComment* pother = dynamic_cast< const AtlasComment* >( &other );

		if ( 0 != pother )
		{
			m_uiCommentLength = pother->m_uiCommentLength;
			m_bEntryPoint = pother->m_bEntryPoint;
			m_bBranchDestination = pother->m_bBranchDestination;

			const unsigned int uiSize = pother->m_vectCommentLines.size( );
		
			if ( uiSize > 0 )
			{
				commentData* pCommentData = 0;

				for ( unsigned int ui = 0; ui < uiSize; ++ui )
				{
					try
					{
						pCommentData = new commentData( *( pother->m_vectCommentLines[ ui ] ) );
					}
					catch ( ... )
					{
						throw Exception( Exception::eFailedToAllocateMemoryForCommmentDataObject, __FILE__, __FUNCTION__, __LINE__ );
					}

					m_vectCommentLines.push_back( pCommentData );
				}
			}
		}
	}

	return *this;
}

void AtlasComment::InitFromXML( const StatementMetadata* pData )
{
	if ( 0 != pData )
	{
		if ( 0 != pData->m_pStatement )
		{
			const xercesc::DOMElement* pComment = pData->m_pStatement->getFirstElementChild( );
			string strAIXMLtagName;

			SetSourceStatementInfo( pData->m_pStatement, pData->m_eSourceType, pData->m_strFilename, pData->m_strParentProcedureName, pData->m_uiParentProcedureId );

			AIXMLHelper::GetXercesString( pData->m_pStatement->getTagName( ), strAIXMLtagName );

			if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eBranchTargetElement ] )
			{
				m_bBranchDestination = true;
			}
			else if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eEntryPointElement ] )
			{
				m_bEntryPoint = true;
			}

			while ( 0 != pComment )
			{
				string strComment;
				unsigned int uiId = 0;
				unsigned int uiLineNum = 0;
	
				AIXMLHelper::GetXercesString( pComment->getTagName( ), strAIXMLtagName );
		
				if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eCommentElement ] )
				{
					const xercesc::DOMNode* pCommentText = pComment->getFirstChild( );
					if ( 0 != pCommentText )
					{
						if ( DOMNode::TEXT_NODE == pCommentText->getNodeType( ) )
						{
							AIXMLHelper::GetXercesString( pCommentText->getTextContent( ), strComment );

							AIXMLHelper::Trim( strComment, false );

							const unsigned int uiSize = strComment.size( );

							if ( uiSize > 0 )
							{
								strComment = XML::TranslateToXmlEncodings( strComment );

								m_uiCommentLength += uiSize;
							}
						}
					}

					const DOMAttr* pAttr = pComment->getAttributeNode( AIXMLHelper::GetWString( AIXML::m_arrayXMLKeyWords[ AIXML::eNameAttribute ] ).c_str( ) );
					if ( 0 != pAttr )
					{
						AIXMLHelper::GetXercesString( pAttr->getValue( ), strComment );
	
						if ( !strComment.empty( ) )
						{
							strComment = XML::TranslateToXmlEncodings( strComment );
						}
					}
	
					pAttr = pComment->getAttributeNode( AIXMLHelper::GetWString( AIXML::m_arrayXMLKeyWords[ AIXML::eIdAttribute ] ).c_str( ) );
					if ( 0 != pAttr )
					{
						uiId = AIXMLHelper::StringToNumber< unsigned int >( AIXMLHelper::GetXercesString( pAttr->getValue( ) ) );
					}
	
					pAttr = pComment->getAttributeNode( AIXMLHelper::GetWString( AIXML::m_arrayXMLKeyWords[ AIXML::eLineAttribute ] ).c_str( ) );
					if ( 0 != pAttr )
					{
						uiLineNum = AIXMLHelper::StringToNumber< unsigned int >( AIXMLHelper::GetXercesString( pAttr->getValue( ) ) );
					}
	
					commentData* pCommentData = 0;

					try
					{
						pCommentData = new commentData( strComment, uiId, uiLineNum );
					}
					catch ( ... )
					{
						throw Exception( Exception::eFailedToAllocateMemoryForCommmentDataObject, __FILE__, __FUNCTION__, __LINE__ );
					}

					m_vectCommentLines.push_back( pCommentData );
				}
				#if ( _DEBUG ) && ( WIN32 )
				else
				{
					DebugBreak( );
				}
				#endif
	
				pComment = pComment->getNextElementSibling( );
			}

			#if ( _DEBUG ) && ( WIN32 )
			if ( 0 == m_vectCommentLines.size( ) )
			{
				if ( !m_bBranchDestination && !m_bEntryPoint )
				{
					DebugBreak( );
				}
			}
			#endif
		}
	}
}

void AtlasComment::ToXML( string& strXML ) const
{
	if ( m_uiCommentLength > 0 )
	{
		const unsigned int uiLines = m_vectCommentLines.size( );
	
		if ( uiLines > 0 )
		{
			const string strId( XML::MakeXmlAttributeNameValue( XML::anId, m_uiId ) );
			const string strLines( XML::MakeXmlAttributeNameValue( XML::anLines, uiLines ) );
			const string strStartingLine( XML::MakeXmlAttributeNameValue( XML::anStartingLine, m_vectCommentLines[ 0 ]->m_uiLineNum ) );
			string strEntryPoint;
			string strBranchPoint;
			string strProcedureName;
			string strProcedureId;

			if ( !m_strParentProcedureName.empty( ) )
			{
				strProcedureName = XML::MakeXmlAttributeNameValue( XML::anProcedure, m_strParentProcedureName );
			}

			if ( 0 != m_uiParentProcedureId )
			{
				strProcedureId = XML::MakeXmlAttributeNameValue( XML::anProcRefId, m_uiParentProcedureId );
			}

			if ( m_bEntryPoint )
			{
				strEntryPoint = XML::MakeXmlAttributeNameValue( XML::anEntryPoint, XML::avTrue );
			}

			if ( m_bBranchDestination )
			{
				strBranchPoint = XML::MakeXmlAttributeNameValue( XML::anBranchPoint, XML::avTrue );
			}

			strXML += XML::MakeOpenXmlElementWithChildren( XML::enComment, strId, strLines, strStartingLine, strProcedureName, strProcedureId, strBranchPoint, strEntryPoint );
	
			for ( unsigned int ui = 0; ui < uiLines; ++ui )
			{
				const commentData* pData = m_vectCommentLines[ ui ];
	
				strXML += XML::MakeXmlElementNoChildrenWithTextNode( XML::enLine, pData->m_strComment, XML::MakeXmlAttributeNameValue( XML::anLineNumber, pData->m_uiLineNum ) );
			}
	
			strXML += XML::MakeCloseXmlElementWithChildren( XML::enComment );
		}
	}
}