/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

#define XERCES_STATIC_LIBRARY

#pragma once

#include <string>
#include <vector>

#include <xercesc/util/XercesDefs.hpp>
#include <xercesc/util/Xerces_autoconf_config.hpp>
XERCES_CPP_NAMESPACE_BEGIN
	class DOMDocument;	
	class DOMElement;	
	class XercesDOMParser;
XERCES_CPP_NAMESPACE_END

#include "atlas.h"

class StatementMetadata
{
public:

	StatementMetadata( ) :
		m_pStatement( 0 ), 
		m_eSourceType( Atlas::AtlasSourceStatement::eUnknownSourceType ), 
		m_uiParentProcedureId( 0 ), 
		m_uiParentConditionalStatementsId( 0 ),
		m_uiConditionalNestLevel( 0 ) { }

	StatementMetadata( const xercesc::DOMElement* pStatement,
		const string& strFilename, 
		const Atlas::AtlasSourceStatement::eSourceType eSourceType ) :
		m_pStatement( pStatement ), 
		m_strFilename( strFilename ), 
		m_eSourceType( eSourceType ), 
		m_uiParentProcedureId( 0 ), 
		m_uiParentConditionalStatementsId( 0 ),
		m_uiConditionalNestLevel( 0 ) { }

	StatementMetadata( const xercesc::DOMElement* pStatement, 
		const string& strFilename, 
		const Atlas::AtlasSourceStatement::eSourceType eSourceType, 
		const string& strParentProcedureName, 
		unsigned int uiParentProcedureId, 
		unsigned int uiParentConditionalStatementsId,
		unsigned int uiConditionalNestLevel ) : 
		m_pStatement( pStatement ), 
		m_strFilename( strFilename ), 
		m_eSourceType( eSourceType ), 
		m_strParentProcedureName( strParentProcedureName ), 
		m_uiParentProcedureId( uiParentProcedureId ), 
		m_uiParentConditionalStatementsId( uiParentConditionalStatementsId ),
		m_uiConditionalNestLevel( uiConditionalNestLevel ) { }

	StatementMetadata( const StatementMetadata& other ) { operator = ( other ); }

	StatementMetadata& operator = ( const StatementMetadata& other )
	{
		if ( this != &other )
		{
			m_pStatement = other.m_pStatement;
			m_strFilename = other.m_strFilename;
			m_eSourceType = other.m_eSourceType;
			m_strParentProcedureName = other.m_strParentProcedureName;
			m_uiParentProcedureId = other.m_uiParentProcedureId;
			m_uiParentConditionalStatementsId = other.m_uiParentConditionalStatementsId;
			m_uiConditionalNestLevel = other.m_uiConditionalNestLevel;
		}

		return *this;
	}

	void ClearVolatile( void )
	{
		m_pStatement = 0;
		m_uiParentConditionalStatementsId = 0;
		m_uiConditionalNestLevel = 0;
	}

	const xercesc::DOMElement* m_pStatement;
	string m_strFilename;
	string m_strParentProcedureName;
	unsigned int m_uiParentProcedureId;
	unsigned int m_uiParentConditionalStatementsId;
	unsigned int m_uiConditionalNestLevel;
	Atlas::AtlasSourceStatement::eSourceType m_eSourceType;
};

class DOMStatements
{
public:

	DOMStatements( ) { }
	~DOMStatements( )
	{
		const unsigned int uiSize = m_vectStatements.size( );

		for ( unsigned int ui = 0; ui < uiSize; ++ui )
		{
			delete m_vectStatements[ ui ];
		}
	}

	void InsertMetadata( const StatementMetadata& metaData )
	{
		StatementMetadata* pStatementMetadata = 0;
			
		try
		{
			pStatementMetadata = new StatementMetadata( metaData );
		}
		catch ( ... )
		{
			throw Exception( Exception::eFailedToCreateObject, __FILE__, __FUNCTION__, __LINE__ );
		}

		m_vectStatements.push_back( pStatementMetadata );
	}

	void InsertMetadata( const xercesc::DOMElement* pStatement, 
		const string& strFilename, 
		const Atlas::AtlasSourceStatement::eSourceType eSourceType, 
		const string& strParentProcedureName, 
		unsigned int uiParentProcedureId, 
		unsigned int uiParentConditionalStatementsId )
	{

		StatementMetadata* pStatementMetadata = 0;

		try
		{
			pStatementMetadata = new StatementMetadata( pStatement, strFilename, eSourceType, strParentProcedureName, uiParentProcedureId, uiParentConditionalStatementsId, 0 );
		}
		catch ( ... )
		{
			throw Exception( Exception::eFailedToCreateObject, __FILE__, __FUNCTION__, __LINE__ );
		}

		m_vectStatements.push_back( pStatementMetadata );
	}

	vector< StatementMetadata* > m_vectStatements;
};
