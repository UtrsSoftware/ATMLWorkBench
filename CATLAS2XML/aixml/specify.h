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

class CNX;
class AtlasRequires;

using namespace std;

class AtlasSpecify : public AtlasActionSignalVerb
{
public:

	AtlasSpecify( const AtlasRequires* pRequireStatements ) : AtlasActionSignalVerb( Atlas::eSPECIFY, XML::enSpecify, false, pRequireStatements ) { Init( ); }
	AtlasSpecify( const AtlasSpecify& other ) : AtlasActionSignalVerb( Atlas::eSPECIFY, XML::enSpecify, false, other.m_pRequireStatements ) { Init( ); operator = ( other ); }
	~AtlasSpecify( ) { GarbageCollect( ); }
	AtlasSpecify& operator = ( const AtlasStatement& other );

	void InitFromXML( const xercesc::DOMElement* pAIXMLvalue, const Atlas::AtlasSourceStatement::eSourceType eSourcType, const string& strFilename );
	void Process( const Lookup* pLookup = 0 );
	void ToXML( string& strXML ) const;

	bool m_bComplexFunction;
	Atlas::eAtlasSpecifyType m_eAtlasSpecifyType;

protected:

	void GetConfiguration( const unsigned int uiSize, unsigned int& ui, const Lookup* pLookup );
	void Init( void );
	void GarbageCollect( void );
};