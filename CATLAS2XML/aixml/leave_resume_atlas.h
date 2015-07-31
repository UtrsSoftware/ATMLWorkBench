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

class AtlasLeaveResume : public AtlasStatement
{
public:

	AtlasLeaveResume( const Atlas::eAtlasStatement eStatement ) : AtlasStatement( eStatement ) { Init( ); }
	AtlasLeaveResume( const AtlasLeaveResume& other ) { Init( ); operator = ( other ); }
	AtlasLeaveResume& operator = ( const AtlasStatement& other );
	~AtlasLeaveResume( ) { GarbageCollect( ); }

	void InitFromXML( const StatementMetadata* pData );

	void Process( const Lookup* pLookup = 0 );
	void ToXML( string& strXML ) const;

	unsigned int m_uiIPLRefId;
	unsigned int m_IPLStartLine;
	vector< pair< unsigned int, string > >* m_pvectIPL;  // line number, ipl statement

protected:

	void Init( void )
	{
		m_uiIPLRefId = 0;
		m_IPLStartLine = 0;
		m_pvectIPL = 0;
	}

	void GarbageCollect( void )
	{
		if ( 0 != m_pvectIPL )
		{
			delete m_pvectIPL;
			m_pvectIPL = 0;
		}
	}

}; // class AtlasLeaveResume
