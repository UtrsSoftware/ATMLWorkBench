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
class AtlasDeclareData;
class AtlasProcedure;

using namespace std;

class AtlasFill : public AtlasStatement
{
public:

	AtlasFill( ) : AtlasStatement( Atlas::eFILL ) { Init( ); }
	AtlasFill( const AtlasFill& other ) { Init( ); operator = ( other ); }
	~AtlasFill( ) { GarbageCollect( ); }
	AtlasFill& operator = ( const AtlasStatement& other );

	void InitFromXML( const StatementMetadata* pData, vector< AtlasStatement* >& vectNestedFills );

	void Process( const Lookup* pLookup = 0 ) { }
	void Process( const map< string, vector< AtlasDeclareData* >* >* pmapDeclares, const AtlasProcedure* pProcedure, const vector< pair< string, Atlas::AtlasSourceStatement::eSourceType > >* pvectAtlasSourceFiles, const Lookup* pLookup = 0 );
	void ProcessVariableSymbols( const map< string, vector< AtlasDeclareData* >* >& mapDeclares, const map< Atlas::AtlasData::eBuiltInType, AtlasDeclareData* >& mapBuiltinDeclares, const AtlasProcedure* pProcedure, const vector< pair< string, Atlas::AtlasSourceStatement::eSourceType > >* pvectAtlasSourceFiles );
	void ToXML( string& strXML ) const;
	void GetAssignValue_XML( const XML::ElementName eName, set < string >& setAssignedByValue ) const;

	virtual unsigned int GetStatementId( void ) const;

	Atlas::AtlasData* m_pVariableName;
	Atlas::AtlasData* m_pVariableValue;
	vector< pair< pair< unsigned int, unsigned int >, Atlas::AtlasData* > >* m_pvectList;
	unsigned int m_uiNestId;

protected:

	void Init( void );
	void GarbageCollect( void );
	void ProcessXML( vector< AtlasStatement* >& vectNestedFills );
	void GetMetaData( const unsigned int uiSize, unsigned int& uiVariableCount, bool& bIsList );
	void ProcessListXML( const unsigned int uiSize, const unsigned int uiVariableCount, vector< AtlasStatement* >& vectNestedFills );
	void ProcessStoreXML( const unsigned int uiSize, const unsigned int uiVariableCount, vector< AtlasStatement* >& vectNestedFills );
	Atlas::AtlasData* GetData( const AtlasAttibuteValue* pValue, const bool bBoolAsBuiltIn );
	void SetDataType( const map< string, vector< AtlasDeclareData* >* >* pmapDeclares, const AtlasProcedure* pProcedure, const vector< pair< string, Atlas::AtlasSourceStatement::eSourceType > >* pvectAtlasSourceFiles );
	void ProcessVector( const unsigned int uiSize, const map< string, vector< AtlasDeclareData* >* >* pmapDeclares, const AtlasProcedure* pProcedure, const vector< pair< string, Atlas::AtlasSourceStatement::eSourceType > >* pvectAtlasSourceFiles );
	void ProcessVariable( const unsigned int uiSize, const map< string, vector< AtlasDeclareData* >* >* pmapDeclares, const AtlasProcedure* pProcedure, const vector< pair< string, Atlas::AtlasSourceStatement::eSourceType > >* pvectAtlasSourceFiles );
	void GetThruAllDataVectorRange( const unsigned int uiSize, unsigned int& uiPos, unsigned int& uiPosThru );
	void Assignment_ToXML( string& strXML ) const;

}; // class AtlasFill
