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
#include <set>

#include <xercesc/util/XercesDefs.hpp>
#include <xercesc/util/Xerces_autoconf_config.hpp>
XERCES_CPP_NAMESPACE_BEGIN
	class DOMDocument;	
	class DOMElement;	
	class XercesDOMParser;
XERCES_CPP_NAMESPACE_END

#include "atlas.h"
#include "helper.h"
#include "exception.h"
#include "statements.h"

class StatementMetadata;

using namespace std;

class AtlasPerform : public AtlasStatement
{
public:

	AtlasPerform( ) : AtlasStatement( Atlas::ePERFORM ) { Init( ); }
	AtlasPerform( const AtlasPerform& other ) { Init( ); operator = ( other ); }
	~AtlasPerform( ) { GarbageCollect( ); }
	AtlasPerform& operator = ( const AtlasStatement& other );

	void InitFromXML( const StatementMetadata* pData );
	void Process( const Lookup* pLookup = 0 );
	void ToXML( string& strXML ) const { ToXML( strXML, false ); }
	void ToXML( string& strXML, const bool bParametersOnly ) const;

	unsigned int GetParametersCount( void ) const { return m_vectParameterValues.size( ); }

	string m_strProcedureName;
	string m_strCallStack;
	bool m_bRecursive;
	unsigned int m_uiProcedureId;
	vector< Atlas::AtlasData* > m_vectParameterValues;

protected:

	bool IsConnector( const string& str, const Lookup* pLookup );
	void Init( void ) 
	{ 
		m_bRecursive = false;
		m_uiProcedureId = 0;
	}

	void GarbageCollect( void )
	{ 
		const unsigned int uiSize = m_vectParameterValues.size( );
		if ( uiSize > 0 )
		{
			for ( unsigned int ui = 0; ui < uiSize; ++ui )
			{
				delete m_vectParameterValues[ ui ];
			}

			m_vectParameterValues.clear( );
		}
	}

};  // AtlasPerform