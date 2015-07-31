/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

#pragma once

#include <string>
#include "atlas.h"
#include "statements.h"
#include "xml.h"

class StatementMetadata;

using namespace std;

class AtlasLeave : public AtlasStatement
{
public:

	AtlasLeave( const Atlas::eAtlasStatement eStatement ) : AtlasStatement( eStatement ), m_uiRefId( 0 ) { }
	AtlasLeave( const AtlasLeave& other ) { Init( ); operator = ( other ); }
	AtlasLeave& operator = ( const AtlasStatement& other );

	void InitFromXML( const StatementMetadata* pData );
	void Process( const Lookup* pLookup = 0 );
	Atlas::eAtlasStatement GetConditionalStatementType( void ) const;

	void ToXML( string& strXML ) const;

	string m_strStatementNumber;
	string m_strProcedureName;
	unsigned int m_uiRefId;

protected:

}; // class AtlasLeave
