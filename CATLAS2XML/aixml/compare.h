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
#include "conditional.h"

class StatementMetadata;

using namespace std;

class AtlasCompare : public AtlasStatement
{
public:

	AtlasCompare( ) : AtlasStatement( Atlas::eCOMPARE ) { Init( ); }
	AtlasCompare( const AtlasCompare& other ) { Init( ); operator = ( other ); }
	~AtlasCompare( ) { GarbageCollect( ); }
	AtlasCompare& operator = ( const AtlasStatement& other );

	void InitFromXML( const StatementMetadata* pData );

	void Process( const Lookup* pLookup = 0 );
	void ToXML( string& strXML ) const;
	void VerifyIfBitwiseExpression( void );

	AtlasCondition::Expression* m_pExpression;

protected:

	void Init( void )
	{ 
		m_pExpression = 0;
	}

	void GarbageCollect( void )
	{ 
		if ( 0 != m_pExpression )
		{
			delete m_pExpression;
			m_pExpression = 0;
		}
	}

}; // class AtlasCompare
