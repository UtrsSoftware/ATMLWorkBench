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

#include "Atlas.h"
#include "helper.h"
#include "exception.h"
#include "statements.h"
#include "atlas_noun_modifier.h"

using namespace std;

class Range;

class VideoHorizontalTiming
{
public:

	VideoHorizontalTiming( ) { }
	VideoHorizontalTiming( const VideoHorizontalTiming& other ) { operator = ( other ); }
	~VideoHorizontalTiming( ) { GarbageCollect( ); }
	VideoHorizontalTiming& operator = ( const VideoHorizontalTiming& other );

	void Merge( const VideoHorizontalTiming& other );
	unsigned int Init( const string& strVirtualLabel, const vector< const AtlasAttributes::AtlasAttibuteValue* >& vectAttributes, const unsigned int uiStart, const set< Atlas::eAtlasNounModifier >& setTermination );
	void InitSignalComponents( void );
	bool HasNounModifier( const Atlas::eAtlasNounModifier eModifier ) const;
	void ToXML( string& strXML );

	vector< pair< Atlas::AtlasSignalComponent, Range* > > m_vectRanges;

protected:

	void GarbageCollect( void );
};  // class VideoHorizontalTiming

class VideoVerticalTiming
{
public:

	VideoVerticalTiming( ) { Init( ); }
	VideoVerticalTiming( const VideoVerticalTiming& other ) { Init( ); operator = ( other ); }
	~VideoVerticalTiming( ) { GarbageCollect( ); }
	VideoVerticalTiming& operator = ( const VideoVerticalTiming& other );

	void Merge( const VideoVerticalTiming& other );
	unsigned int Init( const string& strVirtualLabel, const vector< const AtlasAttributes::AtlasAttibuteValue* >& vectAttributes, const unsigned int uiStart, const set< Atlas::eAtlasNounModifier >& setTermination );
	void InitSignalComponents( void );
	bool HasNounModifier( const Atlas::eAtlasNounModifier eModifier ) const;
	void ToXML( string& strXML );

	vector< pair< Atlas::AtlasSignalComponent, Range* > > m_vectRanges;
	bool* m_pbNonInterlace;
	bool* m_pbInterlace;

protected:

	void GarbageCollect( void );

	void Init( void )
	{
		m_pbNonInterlace = 0;
		m_pbInterlace = 0;
	}
};  // class VideoVerticalTiming

class VideoSync
{
public:

	enum eBitFieldValue
	{
		eRed			= 0x0001,
		eGreen			= 0x0002,
		eBlue			= 0x0004,
		eRedGreen		= 0x0008,
		eRedBlue		= 0x0010,
		eGreenBlue		= 0x0020,
		eRedGreenBlue	= 0x0040,
		eAmerican		= 0x0080,
		eEuropean		= 0x0100,
		eOn				= 0x0200,
		eOff			= 0x0400
	};

	VideoSync( ) { Init( ); }
	VideoSync( const VideoSync& other ) { Init( ); operator = ( other ); }
	~VideoSync( ) { GarbageCollect( ); }
	VideoSync& operator = ( const VideoSync& other );

	void Merge( const VideoSync& other );
	unsigned int Init( const string& strVirtualLabel, const vector< const AtlasAttributes::AtlasAttibuteValue* >& vectAttributes, const unsigned int uiStart, const set< Atlas::eAtlasNounModifier >& setTermination );
	void InitSignalComponents( void );
	bool HasNounModifier( const Atlas::eAtlasNounModifier eModifier ) const;
	void ToXML( string& strXML );

	vector< Atlas::AtlasSignalComponent > m_vectSynchronizations;
	vector< pair< Atlas::AtlasSignalComponent, Range* > > m_vectRanges;
	int m_iBitField;

protected:

	void SetBitField( unsigned int& uiRet, const unsigned int uiAttributes, const vector< const AtlasAttributes::AtlasAttibuteValue* >& vectAttributes, const map< string, eBitFieldValue >& mapBitValues );

	void GarbageCollect( void );

	void Init( void )
	{
		m_iBitField = 0;
	}
};  // class VideoSync

class VideoSyncPolarity
{
public:

	enum eBitFieldValue
	{
		eHorizontalPos	= 0x0001,
		eHorizontalNeg	= 0x0002,
		eVerticalPos	= 0x0004,
		eVerticalNeg	= 0x0008,
		eCompositePos	= 0x0010,
		eCompositeNeg	= 0x0020
	};

	VideoSyncPolarity( ) { Init( ); }
	VideoSyncPolarity( const VideoSyncPolarity& other ) { Init( ); operator = ( other ); }
	~VideoSyncPolarity( ) { GarbageCollect( ); }
	VideoSyncPolarity& operator = ( const VideoSyncPolarity& other );

	void Merge( const VideoSyncPolarity& other );
	unsigned int Init( const string& strVirtualLabel, const vector< const AtlasAttributes::AtlasAttibuteValue* >& vectAttributes, const unsigned int uiStart, const set< Atlas::eAtlasNounModifier >& setTermination );
	void InitSignalComponents( void );
	bool HasNounModifier( const Atlas::eAtlasNounModifier eModifier ) const;
	void ToXML( string& strXML );

	int m_iBitField;

protected:

	void SetBitField( unsigned int& uiRet, const unsigned int uiAttributes, const vector< pair< string, unsigned int > >& vectAttributes, const map< string, eBitFieldValue >& mapBitValues );

	void GarbageCollect( void )
	{
		m_iBitField = 0;
	}

	void Init( void )
	{
		m_iBitField = 0;
	}
};  // class VideoSyncPolarity

class VideoVideo
{
public:

	VideoVideo( ) { Init( ); }
	VideoVideo( const VideoVideo& other ) { Init( ); operator = ( other ); }
	~VideoVideo( ) { GarbageCollect( ); }
	VideoVideo& operator = ( const VideoVideo& other );

	void Merge( const VideoVideo& other );
	unsigned int Init( const string& strVirtualLabel, const vector< const AtlasAttributes::AtlasAttibuteValue* >& vectAttributes, const unsigned int uiStart, const set< Atlas::eAtlasNounModifier >& setTermination );
	void InitSignalComponents( void );
	bool HasNounModifier( const Atlas::eAtlasNounModifier eModifier ) const;
	void ToXML( string& strXML );

	vector< Atlas::AtlasSignalComponent > m_vectTypes;
	vector< pair< Atlas::AtlasSignalComponent, Range* > > m_vectRanges;

protected:

	void GarbageCollect( void );

	void Init( void )
	{
	}
};  // class VideoVideo

class VideoImage
{
public:

	VideoImage( ) { Init( ); }
	VideoImage( const VideoImage& other ) { Init( ); operator = ( other ); }
	~VideoImage( ) { GarbageCollect( ); }
	VideoImage& operator = ( const VideoImage& other );

	void Merge( const VideoImage& other );
	void InitSignalComponents( void );
	bool HasNounModifier( const Atlas::eAtlasNounModifier eModifier ) const;
	void ToXML( string& strXML );

	vector< pair< Atlas::AtlasSignalComponent, Range* > > m_vectRanges;

protected:

	void GarbageCollect( void );

	void Init( void )
	{
	}
};  // class VideoImage

class VideoDraw
{
public:

	VideoDraw( ) { Init( ); }
	VideoDraw( const VideoDraw& other ) { Init( ); operator = ( other ); }
	~VideoDraw( ) { GarbageCollect( ); }
	VideoDraw& operator = ( const VideoDraw& other );

	void Merge( const VideoDraw& other );
	unsigned int Init( const string& strVirtualLabel, const vector< const AtlasAttributes::AtlasAttibuteValue* >& vectAttributes, const unsigned int uiStart, const set< Atlas::eAtlasNounModifier >& setTermination );
	void InitSignalComponents( void );
	bool HasNounModifier( const Atlas::eAtlasNounModifier eModifier ) const;
	void ToXML( string& strXML );

	vector< Atlas::AtlasSignalComponent > m_vectTypes;
	vector< pair< Atlas::AtlasSignalComponent, Range* > > m_vectRanges;

protected:

	void GarbageCollect( void );

	void Init( void )
	{
	}
};  // class VideoDraw