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

class AtlasComment : public AtlasStatement
{
public:

	struct commentData
	{
		commentData( const string& strComment, const unsigned int uiId, const unsigned int uiLineNum ) :
			m_strComment( strComment ), 
			m_uiId( uiId ), 
			m_uiLineNum( uiLineNum )
		{ }
		commentData( const AtlasComment& other ) { operator = ( other ); }
		commentData& operator = ( const commentData& other )
		{
			if ( this != &other )
			{
				m_strComment = other.m_strComment;
				m_uiId	= other.m_uiId;
				m_uiLineNum = other.m_uiLineNum;
			}

			return *this;
		}

		string m_strComment;
		unsigned int m_uiId;
		unsigned int m_uiLineNum;
	};

	AtlasComment( ) : AtlasStatement( Atlas::eCOMMENT ) { Init( ); }
	AtlasComment( const AtlasComment& other ) { Init( ); operator = ( other ); }
	~AtlasComment( ) { GarbageCollect( ); }
	AtlasComment& operator = ( const AtlasStatement& other );

	void InitFromXML( const StatementMetadata* pData );

	void Process( const Lookup* pLookup = 0 ) { }
	void ToXML( string& strXML ) const;

	vector< commentData* > m_vectCommentLines;
	unsigned int m_uiCommentLength;
	bool m_bEntryPoint;
	bool m_bBranchDestination;

	void Init( void );
	void GarbageCollect( void );

}; // class AtlasComment
