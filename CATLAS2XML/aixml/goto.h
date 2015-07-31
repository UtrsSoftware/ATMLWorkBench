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

class StatementMetadata;

using namespace std;

class AtlasGoto : public AtlasStatement
{
public:

	AtlasGoto( ) : AtlasStatement( Atlas::eGO_TO ), m_uiRefId( 0 ), m_uiProcRefId( 0 ) { }
	AtlasGoto( const AtlasGoto& other ) { Init( ); operator = ( other ); }
	AtlasGoto& operator = ( const AtlasStatement& other );

	void InitFromXML( const StatementMetadata* pData );

	void Process( const Lookup* pLookup = 0 );
	void ToXML( string& strXML ) const;

	string m_strStatementNumber;
	unsigned int m_uiProcRefId;
	unsigned int m_uiRefId;

protected:

}; // class AtlasGoto
