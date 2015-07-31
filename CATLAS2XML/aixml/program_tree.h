/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

#pragma once

#include <string>
#include <map>
#include <vector>
#include <set>
#include <map>
#include <deque>
#include "tree.h"

using namespace std;

class AtlasStatement;

class ProgamTree : public Tree< AtlasStatement* >
{
public:

	void CreateTree( iterator itItem, const map< string, vector< AtlasStatement* > >& mapProcCalls, map< string, pair< string, unsigned int > >& mapProcsCalled, const vector< AtlasStatement* >* pVect = 0 );

	void ToXML( string& strXML, const unsigned int uiMainStatementsId, const bool bProceduresOnly ) const;

protected:

	void ToXML( iterator& it, string& strXML, const bool bProceduresOnly ) const;
	const vector< AtlasStatement* >* GetProcStatements( const map< string, vector< AtlasStatement* > >& mapProcCalls, const string& strProcName );
	bool Recursion( const string& strProcedureName );
	void PopProcedureCall( const string& strProcedureName );
	string GetCallStack( void ) const;
	void ClearQueue( void );

	set< string > m_setProcCalls;
	deque< string > m_dequeProcCallStack;
};
