/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

#include "Atlas.h"
#include "atlas_statistics.h"

#if ( _DEBUG ) && ( WIN32 )
	#define WINVER 0x0600
	#include <afx.h>
	#define new DEBUG_NEW
	#undef THIS_FILE
	static char BASED_CODE THIS_FILE[ ] = __FILE__;
#endif

AtlasStatistics& AtlasStatistics::operator = ( const AtlasStatistics& other )
{
	if ( this != &other )
	{
		m_mapSignalCounts = other.m_mapSignalCounts;
		m_mapStatementCounts = other.m_mapStatementCounts;
	}

	return *this;
}

AtlasStatistics& AtlasStatistics::operator = ( const AtlasStatistics* pother )
{
	AtlasStatistics& ret = *this;

	if ( 0 != pother )
	{
		ret = operator = ( *pother );
	}

	return ret;
}

void AtlasStatistics::SetSignalCount( const Atlas::eAtlasNoun eNoun, const unsigned int uiCount )
{
	const map< Atlas::eAtlasNoun, unsigned int >::iterator it = m_mapSignalCounts.find( eNoun );
	const map< Atlas::eAtlasNoun, unsigned int >::const_iterator itEnd = m_mapSignalCounts.end( );

	if ( itEnd == it )
	{
		m_mapSignalCounts.insert( make_pair( eNoun, uiCount ) );
	}
	else
	{
		it->second += uiCount;
	}
}

void AtlasStatistics::SetStatementCount( const Atlas::eAtlasStatement eStatement, const unsigned int uiCount )
{
	const map< Atlas::eAtlasStatement, unsigned int >::iterator it = m_mapStatementCounts.find( eStatement );
	const map< Atlas::eAtlasStatement, unsigned int >::const_iterator itEnd = m_mapStatementCounts.end( );

	if ( itEnd == it )
	{
		m_mapStatementCounts.insert( make_pair( eStatement, uiCount ) );
	}
	else
	{
		it->second += uiCount;
	}
}

const map< string, unsigned int >& AtlasStatistics::GetSignalCountsSortedByName( void ) const
{
	map< Atlas::eAtlasNoun, unsigned int >::const_iterator it = m_mapSignalCounts.begin( );
	const map< Atlas::eAtlasNoun, unsigned int >::const_iterator itEnd = m_mapSignalCounts.end( );

	( ( map< string, unsigned int >& ) m_mapSignalCountsByName ).clear( );

	while ( itEnd != it )
	{
		( ( map< string, unsigned int >& ) m_mapSignalCountsByName ).insert( make_pair( Atlas::GetAtlasNoun( it->first ), it->second ) );

		++it;
	}

	return m_mapSignalCountsByName;
}

const map< string, unsigned int >& AtlasStatistics::GetStatementsCountsSortedByName( void ) const
{
	map< Atlas::eAtlasStatement, unsigned int >::const_iterator it = m_mapStatementCounts.begin( );
	const map< Atlas::eAtlasStatement, unsigned int >::const_iterator itEnd = m_mapStatementCounts.end( );
	
	( ( map< string, unsigned int >& ) m_mapStatementCountsByName ).clear( );

	while ( itEnd != it )
	{
		( ( map< string, unsigned int >& ) m_mapStatementCountsByName ).insert( make_pair( Atlas::GetAtlasStatement( it->first ), it->second ) );

		++it;
	}

	return m_mapStatementCountsByName;
}