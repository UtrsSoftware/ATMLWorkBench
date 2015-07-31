/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

#pragma once

#define XERCES_STATIC_LIBRARY

#include <string>
#include <vector>
#include <map>

#include <xercesc/util/XercesDefs.hpp>
#include <xercesc/util/Xerces_autoconf_config.hpp>
XERCES_CPP_NAMESPACE_BEGIN
	class DOMDocument;	
	class DOMElement;	
	class XercesDOMParser;
XERCES_CPP_NAMESPACE_END

#include "statements.h"

using namespace std;

class AtlasDeclareData
{
public:

	AtlasDeclareData( ) : m_eBuiltInType( Atlas::AtlasData::eUnknownBuiltInType ), m_pData( 0 ), m_uiUseCount( 0 ) { }
	AtlasDeclareData( const Atlas::AtlasDeclare& declare, const Atlas::AtlasSourceStatement& source, const Atlas::AtlasData::eBuiltInType eBuiltInType = Atlas::AtlasData::eUnknownBuiltInType ) : m_Declare( declare ), m_Source( source ), m_eBuiltInType( eBuiltInType ), m_pData( 0 ), m_uiUseCount( 0 ) { }
	~AtlasDeclareData( ) { GarbageCollect( ); }

	Atlas::AtlasDeclare m_Declare;
	Atlas::AtlasSourceStatement m_Source;
	Atlas::AtlasData::eBuiltInType m_eBuiltInType;
	Atlas::AtlasData* m_pData;
	vector< AtlasStatement* > m_vectAssignments;
	vector< AtlasStatement* > m_vectSignalOriented;
	vector< AtlasStatement* > m_vectNonSignalOriented;
	unsigned int m_uiUseCount;

	string ToXML( const XML::ElementName enName ) const;
	string Assignments_ToXML( void ) const;

protected:

	void GarbageCollect( void )
	{
		if ( 0 != m_pData )
		{
			delete m_pData;
			m_pData = 0;
		}

		m_vectAssignments.clear( );
		m_vectSignalOriented.clear( );
		m_vectNonSignalOriented.clear( );
		m_uiUseCount = 0;
	}

};  // AtlasDeclareData

class AtlasDeclare : public AtlasStatement
{
public:

	AtlasDeclare& operator = ( const AtlasStatement& other ) { return *this; }

	void InitFromXML( const xercesc::DOMElement* pAIXMLvalue, const Atlas::AtlasSourceStatement::eSourceType eSourcType, const string& strFilename );
	void Process( const Lookup* pLookup = 0 ) { }
	void Process( vector< AtlasDeclareData* >& vectDeclares, const Lookup* pLookup = 0 );
	void ToXML( string& ) const { }

	static void GetDeclares( const vector< const AtlasAttibuteValue* >& vectSourceDeclares, vector< AtlasDeclareData* >& vectDeclares, Atlas::AtlasSourceStatement& source );

};  // AtlasDeclare