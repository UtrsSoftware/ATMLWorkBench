/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

#include "compare.h"
#include "conditional.h"
#include "exception.h"
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


AtlasCompare& AtlasCompare::operator = ( const AtlasStatement& other )
{
	if ( this != &other )
	{
		AtlasStatement::operator = ( other );

		GarbageCollect( );

		const AtlasCompare* pother = dynamic_cast< const AtlasCompare* >( &other );

		if ( 0 != pother )
		{
		}
	}

	return *this;
}

void AtlasCompare::InitFromXML( const StatementMetadata* pData )
{
	if ( 0 != pData )
	{
		if ( 0 != pData->m_pStatement )
		{
			string strAIXMLtagName;

			SetSourceStatementInfo( pData->m_pStatement, pData->m_eSourceType, pData->m_strFilename, pData->m_strParentProcedureName, pData->m_uiParentProcedureId );
	
			m_uiConditionalStatementsId = pData->m_uiParentConditionalStatementsId;

			try
			{
				m_pExpression = new AtlasCondition::Expression;
			}
			catch ( ... )
			{
				throw Exception( Exception::eFailedToAllocateMemoryForExpressionObject, __FILE__, __FUNCTION__, __LINE__ );
			}
	
			AtlasCondition::ProcessExpression( pData->m_pStatement->getFirstElementChild( ), m_pExpression );
		}
	}
}

void AtlasCompare::Process( const Lookup* pLookup )
{
	if ( 0 != m_pExpression )
	{
		ProcessVariableSymbols( m_pExpression->Get( ) );
	}
}

void AtlasCompare::VerifyIfBitwiseExpression( void )
{ 
	AtlasCondition::VerifyIfBitwiseExpression( m_pExpression );
}

void AtlasCompare::ToXML( string& strXML ) const
{
	if ( 0 != m_pExpression )
	{
		const string strId( XML::MakeXmlAttributeNameValue( XML::anId, m_uiId ) );
	
		strXML += XML::MakeOpenXmlElementWithChildren( XML::enCompare, strId, GetStatementCommentRefId_XML( ) );
	
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
	
		if ( 0 != m_pExpression )
		{
			m_pExpression->ToXML( strXML, XML::enAssignment, XML::enAssign, XML::avAssign );
		}

		strXML += XML::MakeCloseXmlElementWithChildren( XML::enCompare );
	}
}