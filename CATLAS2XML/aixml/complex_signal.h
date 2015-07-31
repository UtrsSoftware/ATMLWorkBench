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

class AtlasSignalInfo;
class AtlasStatistics;
class AtlasRequires;

using namespace std;

class AtlasComplexSignal : public AtlasStatement
{
public:

	AtlasComplexSignal( const AtlasRequires* pRequireStatements ) : AtlasStatement( Atlas::eDEFINE_COMPLEX_SIGNAL ) { Init( ); m_pRequireStatements = pRequireStatements; }
	AtlasComplexSignal( const AtlasComplexSignal& other ) { Init( ); operator = ( other ); }
	~AtlasComplexSignal( ) { GarbageCollect( ); }
	AtlasComplexSignal& operator = ( const AtlasStatement& other );

	void InitFromXML( const xercesc::DOMElement* pAIXMLvalue, const Atlas::AtlasSourceStatement::eSourceType eSourcType, const string& strFilename );
	void Process( const Lookup* pLookup = 0 );
	void ToXML( string& strXML ) const;
	void ProcessVariableSymbols( const map< string, vector< AtlasDeclareData* >* >& mapDeclares, const map< Atlas::AtlasData::eBuiltInType, AtlasDeclareData* >& mapBuiltinDeclares, const AtlasProcedure* pProcedure, const vector< pair< string, Atlas::AtlasSourceStatement::eSourceType > >* pvectAtlasSourceFiles );
	void InitSignalInfo( AtlasSignalInfo* pInformation ) const;
	void SetStatistics( AtlasStatistics* pStatistics ) const;

	string m_strSignalName;
	eScope m_eScope;
	bool m_bUsed;
	vector< AtlasStatement* > m_vectSpecify;
	const AtlasRequires* m_pRequireStatements;

protected:

	void Init( void );
	void GarbageCollect( void );

};  // AtlasComplexSignal