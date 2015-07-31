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
#include <set>

#define XERCES_STATIC_LIBRARY

#include <xercesc/util/XercesDefs.hpp>
#include <xercesc/util/Xerces_autoconf_config.hpp>
XERCES_CPP_NAMESPACE_BEGIN
	class DOMDocument;	
	class DOMElement;	
	class XercesDOMParser;
XERCES_CPP_NAMESPACE_END

using namespace std;

#include "../exception.h"
#include "../statements.h"

class Lookup
{
public:

	struct Subfile;

	Lookup( ) { }
	Lookup( const Lookup& other ) { GarbageCollect( ); operator = ( other ); }
	Lookup& operator = ( const Lookup& other );
	~Lookup( ) { GarbageCollect( ); }

	void Merge( const Lookup& other );

	Subfile* AddSubfile( const int iSubfileId );
	Subfile* GetSubfile( const int iSubfileId ) const;
	void ProcessSubfile( const xercesc::DOMElement* pAIXMLvalue );
	string GetSystemName( const string& strLabelName, const bool bThrowIfNotFound = true ) const;
	SpecificInstrument::eInstrument GetInstrumentEnum( const string& strLabelName, const bool bThrowIfNotFound = true ) const;

	// ******** SUBFILES 1, 2. 5. 6, 7, 10 **********

	struct PinInfo
	{
		map< Atlas::eAtlasPinDescriptor, map< string, set< string > > > m_mapPins; // CNX Descriptor (HI, LO, etc.), map< user pin name, set station patchboard pin descriptors > 

		const map< string, set< string > >* GetUserPinNames( const Atlas::eAtlasPinDescriptor ePinDescriptor )
		{
			const map< Atlas::eAtlasPinDescriptor, map< string, set< string > > >::iterator it = m_mapPins.find( ePinDescriptor );
			map< string, set< string > >* pMap = 0;
		
			if ( m_mapPins.end( ) != it )
			{
				pMap = &( it->second ) ;
			}

			return pMap;
		}

		bool IsUserPinName( const string& strName ) const
		{
			map< Atlas::eAtlasPinDescriptor, map< string, set< string > > >::const_iterator it = m_mapPins.begin( );
			const map< Atlas::eAtlasPinDescriptor, map< string, set< string > > >::const_iterator itEnd = m_mapPins.end( );
			bool bIsPinName = false;

			while ( itEnd != it )
			{
				map< string, set< string > >::const_iterator it2 = it->second.begin( );
				const map< string, set< string > >::const_iterator it2End = it->second.end( );
	
				while ( it2End != it2 )
				{
					if ( strName == it2->first )
					{
						bIsPinName = true;
						it = itEnd;
						break;
					}

					++it2;
				}

				if ( itEnd != it )
				{
					++it;
				}
			}

			return bIsPinName;
		}
	};

	struct Subfile
	{
		virtual ~Subfile( ) { }

		int m_iSubfileId;

		virtual void CreateSubfileMapping( const xercesc::DOMElement* pAIXMLvalue ) = 0;
		virtual void Merge( const Subfile& other ) = 0;
		virtual Subfile& operator = ( const Subfile& other ) = 0;

		static Subfile* SubfileFactory( const int iSubfileId );

	protected:

		Subfile( void ) : m_iSubfileId( 0 ) { }
	};

	// Maps the ATLAS USING '<label>' to the CASS system name (SSNAME)
	struct Subfile1 : public Subfile 
	{
		Subfile1( const Subfile1& other ) { GarbageCollect( ); operator = ( other ); }
		~Subfile1( ) { GarbageCollect( ); }
		Subfile& operator = ( const Subfile& other );

		void Merge( const Subfile& other );

		void AddMapping( const string& strAtlasName, const string& strCassName );
		void CreateSubfileMapping( const xercesc::DOMElement* pAIXMLvalue );
		string GetSystemName( const string& strLabelName ) const;
		SpecificInstrument::eInstrument GetInstrumentEnum( const string& strLabelName ) const;

		map< string, string > m_mapAtlasToCass;										// Maps the ATLAS USING '<label>' to the CASS system name (SSNAME)
		map< string, SpecificInstrument::eInstrument > m_mapAtlasToInstrumentEnum;	// Maps the ATLAS USING '<label>' to the Instrument::eInstrument enum
		map< string, set< string >* > m_mapCassToAtlas;								// Maps the CASS system name (SSNAME) to the ATLAS USING '<label>'

	protected:

		Subfile1( void ) { }
		void GarbageCollect( void ); 

	friend struct Subfile;
	};

	// Forward reference for friending
	struct Subfile10;

	// Maps the general purpose switch assemblies in the GPI, and the RF switching resources, to the connection field(s)
	struct Subfile2 : public Subfile 
	{
		Subfile2( const Subfile2& other ) { GarbageCollect( ); operator = ( other ); }
		Subfile& operator = ( const Subfile& other );
		~Subfile2( ) { GarbageCollect( ); }

		void Merge( const Subfile& other );

		set< string >* AddMapping( const string& strSystemNameCombo );
		void CreateSubfileMapping( const xercesc::DOMElement* pAIXMLvalue );
		PinInfo* GetPinInfo( const string& strSystemName );
		const set< string >* GetPinInfoSet( const string& strSystemName, const Atlas::eAtlasPinDescriptor ePinDescriptor, const string& strUserPinName );

		bool IsUserPinName( const string& strName ) const
		{
			map< string, PinInfo* >::const_iterator it = m_mapCassToPinInfo.begin( );
			const map< string, PinInfo* >::const_iterator itEnd = m_mapCassToPinInfo.end( );
			bool bIsPinName = false;

			while ( itEnd != it )
			{
				if ( it->second->IsUserPinName( strName ) )
				{
					bIsPinName = true;
					break;
				}

				++it;
			}

			return bIsPinName;
		}

		map< string, PinInfo* > m_mapCassToPinInfo;				// Maps system name (SSNAME) to pin out information
		const map< string, set< string >* >* m_pmapCassToAtlas;	// Maps the CASS system name (SSNAME) to the ATLAS USING '<label>' [from SUBFILE 1]
		const map< string, string >* m_pmapAtlasToCass;			// Maps the ATLAS USING '<label>' to the CASS system name (SSNAME) [from SUBFILE 1]

	protected:

		Subfile2( void ) : m_pmapCassToAtlas( 0 ), m_pmapAtlasToCass( 0 ) { }
		void GarbageCollect( void ); 

		static set< string >* AddMapping( const string& strSystemNameCombo, map< string, PinInfo* >& mapCassToPinInfo, const map< string, set< string >* >* pmapCassToAtlas, const map< string, string >* pmapAtlasToCass, const Exception::eErrorType e1, const Exception::eErrorType e2, const Exception::eErrorType e3, const Exception::eErrorType e4 );

	friend struct Subfile;
	friend struct Subfile10;
	};

	// Maps the ATLAS IDENTIFY EVENT '<event>' names to the CASS trigger sources
	struct Subfile5 : public Subfile 
	{
		Subfile5( const Subfile5& other ) { GarbageCollect( ); operator = ( other ); }
		Subfile& operator = ( const Subfile& other );

		void Merge( const Subfile& other );

		void AddMapping( const string& strAtlasEvent, const string& strTriggerSource );
		void CreateSubfileMapping( const xercesc::DOMElement* pAIXMLvalue );

		map< string, string > m_mapEventToTrigger;	// Maps the ATLAS IDENTIFY EVENT '<event>' names to the CASS trigger sources

	protected:

		Subfile5( void ) { }
		void GarbageCollect( void ) { m_mapEventToTrigger.clear( ); }

	friend struct Subfile;
	};

	// Contains the IDENTIFY EVENT '<event>' connection information
	struct Subfile6 : public Subfile 
	{
		Subfile6( const Subfile6& other ) { GarbageCollect( ); operator = ( other ); }
		Subfile& operator = ( const Subfile& other );
		~Subfile6( ) { GarbageCollect( ); }

		void Merge( const Subfile& other );

		set< string >* AddMapping( const string& strAtlasEvent );
		void CreateSubfileMapping( const xercesc::DOMElement* pAIXMLvalue );

		map< string, set< string >* > m_mapEventToPinDescriptor;	// Maps the ATLAS IDENTIFY EVENT '<event>' names to the station patchboard pin descriptor

	protected:

		Subfile6( void ) { }
		void GarbageCollect( void );

	friend struct Subfile;
	};

	// Used to specify the need for the use of switching resources and/or ancillary assets (GPI, RFI, DTU, AGCS, ATI, FAST488)
	struct Subfile7 : public Subfile 
	{
		Subfile7( const Subfile7& other ) { GarbageCollect( ); operator = ( other ); }
		Subfile& operator = ( const Subfile& other );

		void Merge( const Subfile& other );

		void AddMapping( const string& strAtlasEvent, const string& strLabel );
		void CreateSubfileMapping( const xercesc::DOMElement* pAIXMLvalue );

		map< string, string > m_mapLabelToCass;	// Maps the virtual label to the CASS legal system name

	protected:

		Subfile7( void ) { }
		void GarbageCollect( void ) { m_mapLabelToCass.clear( ); }

	friend struct Subfile;
	};

	// Contains the ATLAS OPEN and CLOSE verb functionality information for establishing 
	// instrumentation path(s) within the CASS station, and/or calibrations paths within the 
	// applicable instrument. 
	struct Subfile10 : public Subfile 
	{
		Subfile10( const Subfile10& other ) { GarbageCollect( ); operator = ( other ); }
		Subfile& operator = ( const Subfile& other );
		~Subfile10( ) { GarbageCollect( ); }

		void Merge( const Subfile& other );

		set< string >* AddMapping( const string& strSystemNameCombo );
		void CreateSubfileMapping( const xercesc::DOMElement* pAIXMLvalue );

		map< string, PinInfo* > m_mapCassToPinInfo;				// Maps system name (SSNAME) to pin out information
		const map< string, set< string >* >* m_pmapCassToAtlas;	// Maps the CASS system name (SSNAME) to the ATLAS USING '<label>' [from SUBFILE 1]
		const map< string, string >* m_pmapAtlasToCass;			// Maps the ATLAS USING '<label>' to the CASS system name (SSNAME) [from SUBFILE 1]

	protected:

		Subfile10( void ) : m_pmapCassToAtlas( 0 ), m_pmapAtlasToCass( 0 ) { }
		void GarbageCollect( void );

	friend struct Subfile;
	};

protected:

	void GarbageCollect( void );

	map< int, Subfile* > m_mapSubfiles;
};

