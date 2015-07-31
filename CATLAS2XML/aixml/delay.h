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

class AtlasDelay : public AtlasStatement
{
public:

	AtlasDelay( ) : AtlasStatement( Atlas::eDELAY ) { Init( ); }
	AtlasDelay( const AtlasDelay& other ) { Init( ); operator = ( other ); }
	~AtlasDelay( ) { GarbageCollect( ); }
	AtlasDelay& operator = ( const AtlasStatement& other );

	void InitFromXML( const StatementMetadata* pData );

	void Process( const Lookup* pLookup = 0 );
	void ToXML( string& strXML ) const;

	bool m_bMinumum;
	Atlas::AtlasData* m_pTime;
	Atlas::AtlasErrorLimit* m_pErrorLimit;

protected:

	void Init( void );
	void GarbageCollect( void );

}; // class AtlasDelay
