/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

#pragma once

#include <string>
#include <vector>
#include <set>
#include <map>

#include "atlas.h"
#include "exception.h"
#include "statements.h"
#include "xml.h"

using namespace std;

class AtlasRequire;
class AtlasComplexSignal;

class NounModifier
{
public:

	static Atlas::AtlasNumber* GetAtlasNumber( const string& strVirtualLabel, const vector< const AtlasAttributes::AtlasAttibuteValue* >& vectAttributes, unsigned int& uiStart, const bool bIncrementCounter = true );
	static Atlas::AtlasNumber* GetAtlasVariable( const string& strVirtualLabel, const vector< const AtlasAttributes::AtlasAttibuteValue* >& vectAttributes, unsigned int& uiStart, const bool bIncrementCounter = true );
	static Atlas::AtlasErrorLimit GetAtlasErrorLimit( const string& strVirtualLabel, const vector< const AtlasAttributes::AtlasAttibuteValue* >& vectAttributes, unsigned int& uiStart, const bool bIncrementCounter = true );
	static Atlas::AtlasStatementCharacteristic* GetAtlasCharacteristic( const string& strVirtualLabel, const vector< const AtlasAttributes::AtlasAttibuteValue* >& vectAttributes, unsigned int& uiStart, const bool bIncrementCounter = true );
	static Atlas::AtlasEvaluationStatement* GetAtlasEvaluationField( const string& strVirtualLabel, const vector< const AtlasAttributes::AtlasAttibuteValue* >& vectAttributes, unsigned int& uiStart, const bool bIncrementCounter = true );
	static Atlas::AtlasUnitOfMeasure GetAtlasUnitOfMeasureByAlasUnit( const string& strUnit, const bool bThrowOnNotFound, const string& strVirtualLabel = string( ), Exception::eErrorType e = Exception::eUnknownError );
	static const string& VerifyNumber( const string& strNumber, const string& strVirtualLabel );

	static void MergeSignalNumbers( vector< pair< Atlas::AtlasSignalComponent, Atlas::AtlasNumber* > >& vectNumbers, const vector< pair< Atlas::AtlasSignalComponent, Atlas::AtlasNumber* > >& vectOtherNumbers, const bool bMaximumMerge );
	static void MergeAtlasSignalComponents( vector< Atlas::AtlasSignalComponent >& vectAtlasSignalComponents, const vector< Atlas::AtlasSignalComponent >& vectOtherAtlasSignalComponents );

	static void ToXML( string& strXML, const vector< Atlas::AtlasSignalComponent >& vectAtlasSignalComponents, const XML::ElementName eParentName, const XML::ElementName eChildName );
	static void ToXML( string& strXML, const vector< pair< Atlas::AtlasSignalComponent, Atlas::AtlasNumber* > >& vectNumbers, const XML::ElementName eOutterName, const XML::ElementName eInnerName );

	static void InitSignalComponents( vector< Atlas::AtlasSignalComponent >& vectSignalComps );
	static void InitSignalComponents( vector< pair< Atlas::AtlasSignalComponent, Atlas::AtlasNumber* > >& vectNumbers );

	static bool HasNounModifier( const Atlas::eAtlasNounModifier eModifier, const vector< Atlas::AtlasSignalComponent >& vectAtlasNounMod );
	static bool HasNounModifier( const Atlas::eAtlasNounModifier eModifier, const vector< pair< Atlas::AtlasSignalComponent, Atlas::AtlasNumber* > >& vectNumbers );

protected:
};

class Mode : public NounModifier
{
public:

	Mode( ) { Init( ); }
	Mode( const Mode& other ) { Init( ); operator = ( other ); }
	~Mode( ) { GarbageCollect( ); }
	Mode& operator = ( const Mode& other );

	void Merge( const Mode& other );
	unsigned int Init( const string& strVirtualLabel, vector< const AtlasAttributes::AtlasAttibuteValue* >& vectAttributes, const unsigned int uiStart );
	void InitSignalComponents( void );
	bool HasNounModifier( const Atlas::eAtlasNounModifier eModifier ) const { return NounModifier::HasNounModifier( eModifier, m_vectMode ); }

	vector< Atlas::AtlasSignalComponent > m_vectMode;
	Atlas::eAtlasNoun m_eNoun;

protected:

	void GarbageCollect( void )
	{
		m_vectMode.clear( );
		m_eNoun = Atlas::eUnknownAtlasNoun;
	}

	void Init( void )
	{
		m_eNoun = Atlas::eUnknownAtlasNoun;
	}
};  // class Mode

class Circulate : public NounModifier
{
public:

	Circulate( ) { Init( ); }
	Circulate( const Circulate& other ) { Init( ); operator = ( other ); }
	~Circulate( ) { GarbageCollect( ); }
	Circulate& operator = ( const Circulate& other );

	void Merge( const Circulate& other );
	unsigned int Init( const string& strVirtualLabel, vector< const AtlasAttributes::AtlasAttibuteValue* >& vectAttributes, const unsigned int uiStart );

	Atlas::AtlasNumber* m_pCount;
	bool* m_pbContinuous;

protected:

	void GarbageCollect( void )
	{
		if ( 0 != m_pCount )
		{
			delete m_pCount;
			m_pCount = 0;
		}

		if ( 0 != m_pbContinuous )
		{
			delete m_pbContinuous;
			m_pbContinuous = 0;
		}
	}

	void Init( void )
	{
		m_pbContinuous = 0;
		m_pCount = 0;
	}
};  // class Mode

class SourceIndentifier : public NounModifier
{
public:

	SourceIndentifier( ) { Init( ); }
	SourceIndentifier( const SourceIndentifier& other ) { Init( ); operator = ( other ); }
	~SourceIndentifier( ) { }
	SourceIndentifier& operator = ( const SourceIndentifier& other );

	void Merge( const SourceIndentifier& other );
	unsigned int Init( const string& strVirtualLabel, vector< const AtlasAttributes::AtlasAttibuteValue* >& vectAttributes, const unsigned int uiStart );

	bool m_bChannelA;
	bool m_bChannelB;

protected:

	void Init( void )
	{
		m_bChannelA = false;
		m_bChannelB = false;
	}
};  // class SourceIndentifier

class Coupling : public NounModifier
{
public:

	Coupling( ) { Init( ); }
	Coupling( const Coupling& other ) { Init( ); operator = ( other ); }
	Coupling& operator = ( const Coupling& other );

	void Merge( const Coupling& other );
	unsigned int Init( const string& strVirtualLabel, const vector< const AtlasAttributes::AtlasAttibuteValue* >& vectRangeAttributes, const unsigned int uiStart );

	bool m_bAC;
	bool m_bDC;

protected:

	void Init( void )
	{
		m_bAC = false;
		m_bDC = false;
	}
};  // class Coupling

class SettingValues : public NounModifier
{
public:

	SettingValues( ) { Init( ); }
	SettingValues( const SettingValues& other ) { Init( ); operator = ( other ); }
	SettingValues& operator = ( const SettingValues& other );
	~SettingValues( ) { GarbageCollect( ); }

	void Merge( const SettingValues& other );
	unsigned int Init( const string& strVirtualLabel, const vector< const AtlasAttributes::AtlasAttibuteValue* >& vectLoadValueAttributes, const unsigned int uiStart );
	void ToXML( string& strXML ) const;

	vector< Atlas::AtlasNumber* > m_vectValues;
	bool m_bContinuous;

	static void MergeSignalSettings( vector< pair< Atlas::AtlasSignalComponent, SettingValues* > >& vectSettings, const vector< pair< Atlas::AtlasSignalComponent, SettingValues* > >& vectOtherSettings );
	static void ToXML( string& strXML, const vector< pair< Atlas::AtlasSignalComponent, SettingValues* > >& vectSettings );
	static void InitSignalComponents( vector< pair< Atlas::AtlasSignalComponent, SettingValues* > >& vectSettings );
	static bool HasNounModifier( const Atlas::eAtlasNounModifier eModifier, const vector< pair< Atlas::AtlasSignalComponent, SettingValues* > >& vectSettings );

protected:

	void GarbageCollect( void )
	{
		const unsigned uiSize = m_vectValues.size( );

		for ( unsigned int ui = 0; ui < uiSize; ++ui )
		{
			delete m_vectValues[ ui ];
		}

		m_vectValues.clear( );
	}

	void Init( void )
	{
		m_bContinuous = false;
	}
};  // class SettingValues

class Range : public NounModifier
{
public:

	Range( ) { }
	Range( const Range& other ) { operator = ( other ); }
	Range& operator = ( const Range& other );

	void Merge( const Range& other ) { m_Range.Merge( other.m_Range ); }
	unsigned int Init( const string& strVirtualLabel, const vector< const AtlasAttributes::AtlasAttibuteValue* >& vectRangeAttributes, const unsigned int uiStart );
	string ToXML( void ) const { return m_Range.ToXML( ); }

	Atlas::AtlasRange m_Range;

	static void MergeSignalRanges( vector< pair< Atlas::AtlasSignalComponent, Range* > >& vectRanges, const vector< pair< Atlas::AtlasSignalComponent, Range* > >& vectOtherRanges );
	static void ToXML( string& strXML, const vector< pair< Atlas::AtlasSignalComponent, Range* > >& vectRanges );
	static void InitSignalComponents( vector< pair< Atlas::AtlasSignalComponent, Range* > >& vectRanges );
	static bool HasNounModifier( const Atlas::eAtlasNounModifier eModifier, const vector< pair< Atlas::AtlasSignalComponent, Range* > >& vectRanges );

};  // class Range

class AtlasSignalInfo
{
protected:

public:

	enum eModifierType
	{
		eRanges,
		eSettingValues,
		eMaximums,
		eMinimums
	};

	AtlasSignalInfo( ) : m_pmapComplexSignals( 0 ) { }
	~AtlasSignalInfo( ) { GarbageCollect( ); }

	void SetSignal( const Atlas::eAtlasNoun eNoun, const Atlas::eAtlasStatement eStatement );
	void SetComponent( const Atlas::AtlasSignalComponent& signal );
	void SetInstrument( const Atlas::eAtlasNoun eNoun, const SpecificInstrument::eInstrument eInstrument, const Atlas::eAtlasResource eResource );
	void SetRequire( const AtlasRequire* pRequire );

	void SetComplexSignals( const map< string, vector< AtlasComplexSignal* >* >* pmapComplexSignals ) { m_pmapComplexSignals = pmapComplexSignals; }
	unsigned int SetComplexSignal( const string& strSignalName, const string& strFilename, const Atlas::eAtlasStatement eStatement );

	template < typename T > void SetComponentValues( const Atlas::eAtlasNoun eNoun, const vector< pair< Atlas::AtlasSignalComponent, T* > >& vectModifiers, const Atlas::eAtlasRequire eRequireType, const eModifierType eType )
	{
		void* pMap = 0;
		SignalInfo* pSignalInfo = 0;
	
		if ( GetComponentPtrs( eNoun, eRequireType, eType, &pSignalInfo, &pMap ) )
		{
			map< string, T* >** ppmapModifiers = ( map< string, T* >** ) pMap;
	
			const unsigned int uiModifiers = vectModifiers.size( );
	
			if ( uiModifiers > 0 )
			{
				if ( pSignalInfo->m_mapSignalModifiers.size( ) > 0 )
				{
					if ( 0 == *ppmapModifiers )
					{
						try
						{
							*ppmapModifiers = new map< string, T* >( );
						}
						catch ( ... )
						{
							throw Exception( Exception::eFailedToCreateObject, __FILE__, __FUNCTION__, __LINE__ );
						}
					}
	
					map< string, pair< Atlas::AtlasSignalComponent, unsigned int > >::const_iterator it;
					const map< string, pair< Atlas::AtlasSignalComponent, unsigned int > >::const_iterator itEnd = pSignalInfo->m_mapSignalModifiers.end( );
					const map< string, T* >::const_iterator itModifiers = ( *ppmapModifiers )->end( );
	
					for ( unsigned int ui = 0; ui < uiModifiers; ++ui )
					{
						const pair< Atlas::AtlasSignalComponent, T* >& pr = vectModifiers[ ui ];
						const string strModifier( pr.first );
	
						if ( itEnd != pSignalInfo->m_mapSignalModifiers.find( strModifier ) )
						{
							if ( itModifiers == ( *ppmapModifiers )->find( strModifier ) )
							{
								T* pObject = 0;
									
								try
								{
									pObject = new T( *( pr.second ) );
								}
								catch ( ... )
								{
									throw Exception( Exception::eFailedToCreateObject, __FILE__, __FUNCTION__, __LINE__ );
								}
	
								( *ppmapModifiers )->insert( make_pair( strModifier, pObject ) );
							}
						}
					}
				}
			}
		}
	}

	unsigned int GetSignalCount( void ) const { return ( m_mapSignals.size( ) + m_mapComplexSignals.size( ) ); }
	unsigned int GetSignalComponentCount( const Atlas::eAtlasNoun eNoun ) const;

	bool IsSignal( const Atlas::eAtlasNoun eNoun ) const;

	void ToXML( string& strXML, const bool bExcludeUnused ) const;

protected:

	class SignalInfo
	{
	public:

		SignalInfo( const Atlas::eAtlasNoun eAtlasNoun ) : 
			m_eAtlasNoun( eAtlasNoun ), 
			m_uiTotal( 1 ),
			m_pmapSignalModifierCapabilityRanges( 0 ),
			m_pmapSignalModifierCapabilitySettingValues( 0 ),
			m_pmapSignalModifierCapabilityMaximums( 0 ),
			m_pmapSignalModifierControlRanges( 0 ),
			m_pmapSignalModifierControlSettingValues( 0 ),
			m_pmapSignalModifierLimitRanges( 0 ),
			m_pmapSignalModifierLimitMaximums( 0 )
		{ }
		SignalInfo( const string& strComplexName ) : 
			m_strComplexName( strComplexName ), 
			m_eAtlasNoun( Atlas::eUnknownAtlasNoun ),
			m_uiTotal( 1 ),
			m_pmapSignalModifierCapabilityRanges( 0 ),
			m_pmapSignalModifierCapabilitySettingValues( 0 ),
			m_pmapSignalModifierCapabilityMaximums( 0 ),
			m_pmapSignalModifierControlRanges( 0 ),
			m_pmapSignalModifierControlSettingValues( 0 ),
			m_pmapSignalModifierLimitRanges( 0 ),
			m_pmapSignalModifierLimitMaximums( 0 )
		{ }
		~SignalInfo( ) { GarbageCollect( ); }

		void ToXML( string& strXML ) const;
		void TotalsByStatementType_ToXML( string& strXML ) const;

		Atlas::eAtlasNoun m_eAtlasNoun;
		string m_strComplexName;
		unsigned int m_uiTotal;
		map< Atlas::eAtlasStatement, unsigned int > m_mapStatements; // Totals by statement type
		map< SpecificInstrument::eInstrument, set< Atlas::eAtlasResource > > m_mapInstruments;
		map< string, pair< Atlas::AtlasSignalComponent, unsigned int > > m_mapSignalModifiers;

		// Capability
		map< string, Range* >* m_pmapSignalModifierCapabilityRanges;
		map< string, SettingValues* >* m_pmapSignalModifierCapabilitySettingValues;
		map< string, Atlas::AtlasNumber* >* m_pmapSignalModifierCapabilityMaximums;

		// Control
		map< string, Range* >* m_pmapSignalModifierControlRanges;
		map< string, SettingValues* >* m_pmapSignalModifierControlSettingValues;

		// Limit
		map< string, Range* >* m_pmapSignalModifierLimitRanges;
		map< string, Atlas::AtlasNumber* >* m_pmapSignalModifierLimitMaximums;

		// Requires
		vector< const AtlasRequire* > m_vectRequires;

		const void* GetModifierValue( const string& strComponentName, Atlas::eAtlasRequire eRequireType, const eModifierType eType ) const;

	protected:

		void GarbageCollect( void );

	};  // class SignalInfo


	void GarbageCollect( void );
	SignalInfo* GetSignal( const Atlas::eAtlasNoun eNoun ) const;

	map< Atlas::eAtlasNoun, SignalInfo* > m_mapSignals;
	map< unsigned int, SignalInfo* > m_mapComplexSignals;
	const map< string, vector< AtlasComplexSignal* >* >* m_pmapComplexSignals;

	bool GetComponentPtrs( const Atlas::eAtlasNoun eNoun, const Atlas::eAtlasRequire eRequireType, const eModifierType eType, SignalInfo** pSignalInfo, void** pppMap );

};  // class AtlasSignalInfo