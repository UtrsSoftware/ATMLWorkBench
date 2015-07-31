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

class AtlasCalculate : public AtlasStatement
{
public:

	AtlasCalculate( ) : AtlasStatement( Atlas::eCALCULATE ) { Init( ); }
	AtlasCalculate( const AtlasCalculate& other ) { Init( ); operator = ( other ); }
	~AtlasCalculate( ) { GarbageCollect( ); }
	AtlasCalculate& operator = ( const AtlasStatement& other );

	void InitFromXML( const StatementMetadata* pData, vector< AtlasStatement* >& vectNestedCalculates );

	void Process( const Lookup* pLookup = 0 );
	void ToXML( string& strXML ) const;
	void GetAssignValue_XML( const XML::ElementName eName, set < string >& setAssignedByValue ) const;
	void VerifyIfBitwiseExpression( void );
	virtual unsigned int GetStatementId( void ) const;
	XML::AttributeValue GetAssignmentType( void ) const;
	bool IsListVariable( void ) const;
	const Atlas::AtlasData* GetListVariableSubscript( void ) const;

	Atlas::AtlasTermBase* m_pVariable;
	AtlasCondition::Expression* m_pExpression;
	unsigned int m_uiNestId;

protected:

	void Init( void );
	void GarbageCollect( void );
	void ProcessAssignment( const xercesc::DOMElement* pAssignment );

}; // class AtlasCalculate
