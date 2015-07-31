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
#include "xml.h"

#ifdef CASS
	#include "cass/specific_instruments.h"
	#include "cass/lookup.h"
#else
	#error Need instruments implementation (i.e. CASS)
#endif

using namespace std;

class Lookup;


class CNX : public AtlasAttributes
{
protected:

	struct CNXInfo
	{
		CNXInfo( ) : m_eAtlasPinDescriptor( Atlas::eUnknownAtlasPinDescriptor ), m_uiVirtualDataType( eUnknownDataType ), m_uiVirtualPhysicalDataType( eUnknownDataType ) { }
		CNXInfo( const CNX& other ) { operator = ( other ); }
		CNXInfo& operator = ( const CNXInfo& other )
		{
			if ( this != &other )
			{
				m_ASC = other.m_ASC;
				m_uiVirtualDataType = other.m_uiVirtualDataType;
				m_uiVirtualPhysicalDataType = other.m_uiVirtualPhysicalDataType;
				m_eAtlasPinDescriptor = other.m_eAtlasPinDescriptor;
				m_mapVirtualToPhysicalConn = other.m_mapVirtualToPhysicalConn;
			}
		}

		void ToXML( string& strXML ) const;

		Atlas::eAtlasPinDescriptor m_eAtlasPinDescriptor;
		Atlas::AtlasSignalComponent m_ASC;
		unsigned int m_uiVirtualDataType;
		unsigned int m_uiVirtualPhysicalDataType;
		map< string, set< string > > m_mapVirtualToPhysicalConn; // virtual name, connection set
	};

public:

	CNX( const bool bRequireStatement ) : AtlasAttributes( ) { Init( );  m_bRequireStatement = bRequireStatement; }
	CNX( const CNX& other ) : AtlasAttributes( ) { Init( ); operator = ( other ); }
	CNX( const xercesc::DOMElement* pAIXMLvalue, const bool bRequireStatement ) : AtlasAttributes( pAIXMLvalue ) { Init( ); m_bRequireStatement = bRequireStatement; }
	~CNX( ) { GarbageCollect( ); }
	CNX& operator = ( const CNX& other );

	void Merge( const CNX& other );
	void ToXML( string& strXML ) const;
	void Process( const Lookup* pLookup = 0 );
	void InitSignalComponents( void );
	ieee1641::eBSC GetConnection1641BSC( const Atlas::eAtlasPinDescriptor ePinDescriptor, const bool bREF );

	map< Atlas::eAtlasPinDescriptor, CNXInfo* > m_mapCNX;
	map< Atlas::eAtlasPinDescriptor, CNXInfo* > m_mapREF;
	string m_strSystemName;
	Atlas::eAtlasNoun m_eNoun;
	bool m_bRequireStatement;

protected:

	void GarbageCollect( void );

	void ToXML( string& strXML, const XML::ElementName eElementName, const map< Atlas::eAtlasPinDescriptor, CNXInfo* >& mapCNX ) const;

	void Init( void )
	{
		m_eNoun = Atlas::eUnknownAtlasNoun;
		m_bRequireStatement = true;
	}
};  // class CNX
