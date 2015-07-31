/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

#pragma once

#define XERCES_STATIC_LIBRARY

#include <string>
#include <vector>
#include <map>
#include <set>

#include <xercesc/util/XercesDefs.hpp>
#include <xercesc/util/Xerces_autoconf_config.hpp>
XERCES_CPP_NAMESPACE_BEGIN
	class DOMDocument;	
	class DOMElement;	
	class XercesDOMParser;
XERCES_CPP_NAMESPACE_END

#include "atlas.h"
#include "helper.h"
#include "exception.h"
#include "statements.h"

class AtlasDeclareData;

using namespace std;

class AtlasProcedure : public AtlasStatementContainer
{
public:

	AtlasProcedure( ) : AtlasStatementContainer( Atlas::eDEFINE_PROCEDURE ) { Init( ); }
	AtlasProcedure( const AtlasProcedure& other ) { Init( ); operator = ( other ); }
	~AtlasProcedure( ) { GarbageCollect( ); }
	AtlasProcedure& operator = ( const AtlasStatement& other );

	void InitFromXML( const xercesc::DOMElement* pAIXMLvalue, const Atlas::AtlasSourceStatement::eSourceType eSourcType, const string& strFilename );
	void Process( const Lookup* pLookup = 0 );
	void ToXML( string& strXML ) const { ToXML( strXML, 0 ); }
	void ToXML( string& strXML, const set< unsigned int >* psetEntryPointIds ) const;
	const AtlasDeclareData* GetVariable( const string& strVarName ) const;
	void SetStatementsParent( void );
	const string& GetEndStatementNumber( void ) const { return m_EndStatement.GetStatementNumber( ); }
	void GetTestNumbers_ToXML( string& strXML ) const;

	string m_strProcedureName;
	bool m_bNonAtlas;
	bool m_bMainProcedure;
	bool m_bUsed;
	eScope m_eScope;
	Atlas::AtlasSourceStatement m_EndStatement;

	vector< AtlasDeclareData* > m_vectParameters;
	vector< AtlasDeclareData* > m_vectResults;
	vector< AtlasDeclareData* > m_vectDeclares;

protected:

	vector< const AtlasAttibuteValue* > m_vectTempParameters;
	vector< const AtlasAttibuteValue* > m_vectTempResults;
	vector< const AtlasAttibuteValue* > m_vectTempLocalPreample;

	void Init( void ) 
	{ 
		m_bNonAtlas = false;
		m_bMainProcedure = false;
		m_bUsed = false;
		m_eScope = eUnknownScope;
	}

	void GarbageCollect( void );
	void GarbageCollectTemp( void );

};  // AtlasProcedure