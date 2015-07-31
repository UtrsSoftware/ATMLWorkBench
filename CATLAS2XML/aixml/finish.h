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

class AtlasFinish : public AtlasStatement
{
public:

	AtlasFinish( ) : AtlasStatement( Atlas::eFINISH ) { }
	AtlasFinish( const AtlasFinish& other ) { Init( ); operator = ( other ); }
	AtlasFinish& operator = ( const AtlasStatement& other );

	void InitFromXML( const StatementMetadata* pData );

	void Process( const Lookup* pLookup = 0 );
	void ToXML( string& strXML ) const;

protected:

}; // class AtlasFinish
