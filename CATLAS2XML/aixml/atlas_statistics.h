/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

#pragma once

#include <map>
#include "Atlas.h"

class AtlasStatistics
{
public:

	AtlasStatistics( ) { }
	AtlasStatistics( const AtlasStatistics& other ) { operator = ( other ); }
	AtlasStatistics& operator = ( const AtlasStatistics& other );
	AtlasStatistics& operator = ( const AtlasStatistics* pother );

	unsigned int GetSignalCount( void ) const { return m_mapSignalCounts.size( ); }
	const map< Atlas::eAtlasNoun, unsigned int >& GetSignalCounts( void ) const { return m_mapSignalCounts; };
	const map< string, unsigned int >& GetSignalCountsSortedByName( void ) const;
	void SetSignalCount( const Atlas::eAtlasNoun eNoun, const unsigned int uiCount );

	unsigned int GetStatementCount( void ) const { return m_mapStatementCounts.size( ); }
	const map< Atlas::eAtlasStatement, unsigned int >& GetStatementsCounts( void ) const { return m_mapStatementCounts; };
	const map< string, unsigned int >& GetStatementsCountsSortedByName( void ) const;
	void SetStatementCount( const Atlas::eAtlasStatement eStatement, const unsigned int uiCount );

protected:

	map< Atlas::eAtlasNoun, unsigned int > m_mapSignalCounts;
	map< string, unsigned int > m_mapSignalCountsByName;

	map< Atlas::eAtlasStatement, unsigned int > m_mapStatementCounts;
	map< string, unsigned int > m_mapStatementCountsByName;
};
