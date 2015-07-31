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
#include "xml.h"

#ifdef CASS
	#include "cass/specific_instruments.h"
#else
	#error Need instruments implementation (i.e. CASS)
#endif

using namespace std;

class Lookup;
class Range;
class SettingValues;
class SourceIndentifier;
class Coupling;
class Mode;
class Circulate;
class VideoHorizontalTiming;
class VideoVerticalTiming;
class VideoSync;
class VideoSyncPolarity;
class VideoVideo;
class VideoImage;
class VideoDraw;
class CNX;
class AtlasSignalInfo;

class AtlasRequire : public AtlasSignalVerb
{
protected:

	enum eProcessType
	{
		eStartProcess,
		eResourceProcess,
		eControlProcess,
		eCapabilityProcess,
		eLimitProcess,
		eCNXProcess,
		eEndProcess
	};  // enum eProcessType

public:

	class Resource : public AtlasAttributes
	{
		class ResourceBase
		{ 
		public:

			virtual void Init( const vector< const AtlasAttributes::AtlasAttibuteValue* >& vectAttributes, const string& strVirtualLabel ) = 0;
			virtual ~ResourceBase( ) { }
			virtual ResourceBase& operator = ( const ResourceBase& other ) = 0
			{
				if ( this != &other )
				{
					// No data elements...
				}

				return *this;
			}
			virtual bool operator == ( const ResourceBase& other ) const = 0 { return true; }
			virtual bool operator != ( const ResourceBase& other ) const = 0 { return false; }
			virtual void ToXML( string& strXML ) const = 0;
			virtual operator string( void ) const = 0;
			virtual Atlas::eAtlasNoun GetAtlasNoun( void ) const = 0;
			virtual Atlas::eAtlasResource GetAtlasResource( void ) const = 0;
			virtual void InitSignalComponents( void ) = 0;
			virtual Atlas::AtlasSignalComponent* GetSignalComponent( void ) = 0;

		protected:

			ResourceBase( ) { }
			ResourceBase( const ResourceBase& other ) { operator = ( other ); }
		};  // class ResourceBase

		class InputOutput : public ResourceBase
		{
		public:

			InputOutput( ) : ResourceBase( ) { Init( ); }
			InputOutput( const InputOutput& other ) { Init( ); operator = ( other ); }
			InputOutput( const Atlas::eInputOutput eIOType ) : ResourceBase( ) { Init( ); m_eIOType = eIOType; }
			ResourceBase& operator = ( const ResourceBase& other );
			bool operator == ( const ResourceBase& other ) const;
			bool operator != ( const ResourceBase& other ) const { return !( operator == ( other ) ); }
			operator string( void ) const;
			Atlas::AtlasSignalComponent* GetSignalComponent( void ) { return ( Atlas::AtlasSignalComponent* ) 0; }

			void Init( const vector< const AtlasAttributes::AtlasAttibuteValue* >& vectAttributes, const string& strVirtualLabel );
			void ToXML( string& strXML ) const;
			Atlas::eAtlasNoun GetAtlasNoun( void ) const { return Atlas::eUnknownAtlasNoun; }
			Atlas::eAtlasResource GetAtlasResource( void ) const
			{ 
				Atlas::eAtlasResource eResource = Atlas::eUnknownAtlasResource;

				switch ( m_eIOType )
				{
					case Atlas::eInput:
						eResource = Atlas::eInputResource;
						break;

					case Atlas::eOutput:
						eResource = Atlas::eOutputResource;
						break;

					case Atlas::eInputAndOutput:
						eResource = Atlas::eIOResource;
						break;
				}

				return eResource;
			}
			void InitSignalComponents( void ) { /* do nothing */ }

			Atlas::eInputOutput m_eIOType;
			Atlas::eInputOutput m_eType;

		protected:

			void Init( void )
			{
				m_eType	= Atlas::eUnknownInputOutput;
				m_eIOType = Atlas::eUnknownInputOutput;
			}
		};  // class InputOutput

		class Source : public ResourceBase
		{
		public:

			Source( ) :	ResourceBase( ) { Init( ); }
			Source( const Source& other ) :	ResourceBase( ) { Init( ); operator = ( other ); }
			ResourceBase& operator = ( const ResourceBase& other );
			bool operator == ( const ResourceBase& other ) const;
			bool operator != ( const ResourceBase& other ) const { return !( operator == ( other ) ); }
			operator string( void ) const;

			void Init( const vector< const AtlasAttributes::AtlasAttibuteValue* >& vectAttributes, const string& strVirtualLabel );
			void ToXML( string& strXML ) const;
			Atlas::eAtlasNoun GetAtlasNoun( void ) const { return m_AtlasSignalComponent.GetAtlasNoun( ); }
			Atlas::eAtlasResource GetAtlasResource( void ) const { return Atlas::eSourceResource; }
			void InitSignalComponents( void ) { m_AtlasSignalComponent.Set1641( ); }
			Atlas::AtlasSignalComponent* GetSignalComponent( void ) { return &m_AtlasSignalComponent; }

			Atlas::AtlasSignalComponent m_AtlasSignalComponent;

		protected:

			void Init( void )
			{
			}
		};  // class Source

		class Sensor : public ResourceBase
		{
		public:

			Sensor( ) : ResourceBase( ) { Init( ); }
			Sensor( const Sensor& other ) : ResourceBase( ) { Init( ); operator = ( other ); }
			ResourceBase& operator = ( const ResourceBase& other );
			bool operator == ( const ResourceBase& other ) const;
			bool operator != ( const ResourceBase& other ) const { return !( operator == ( other ) ); }
			operator string( void ) const;

			void Init( const vector< const AtlasAttributes::AtlasAttibuteValue* >& vectAttributes, const string& strVirtualLabel );
			Atlas::eAtlasNoun GetAtlasNoun( void ) const { return m_AtlasMeasuredCharacteristic.GetAtlasNoun( ); }
			Atlas::eAtlasResource GetAtlasResource( void ) const { return Atlas::eSensorResource; }
			void InitSignalComponents( void ) { m_AtlasMeasuredCharacteristic.Set1641( ); }
			Atlas::AtlasSignalComponent* GetSignalComponent( void ) { return &m_AtlasMeasuredCharacteristic; }
			void ToXML( string& strXML ) const;

			Atlas::AtlasSignalComponent m_AtlasMeasuredCharacteristic;

		protected:

			void Init( void )
			{
			}
		};  // class Sensor


		class Load : public ResourceBase
		{
		public:

			Load( ) : ResourceBase( ) { Init( ); }
			Load( const Sensor& other ) : ResourceBase( ) { Init( ); operator = ( other ); }
			ResourceBase& operator = ( const ResourceBase& other );
			bool operator == ( const ResourceBase& other ) const;
			bool operator != ( const ResourceBase& other ) const { return !( operator == ( other ) ); }
			operator string( void ) const;

			void Init( const vector< const AtlasAttributes::AtlasAttibuteValue* >& vectAttributes, const string& strVirtualLabel );
			void ToXML( string& strXML ) const;
			Atlas::eAtlasNoun GetAtlasNoun( void ) const { return m_AtlasSignalComponent.GetAtlasNoun( ); }
			Atlas::eAtlasResource GetAtlasResource( void ) const { return Atlas::eLoadResource; }
			void InitSignalComponents( void ) { m_AtlasSignalComponent.Set1641( ); }
			Atlas::AtlasSignalComponent* GetSignalComponent( void ) { return &m_AtlasSignalComponent; }

			Atlas::AtlasSignalComponent m_AtlasSignalComponent;

		protected:

			void Init( void )
			{
			}
		};  // class Load


		class StimRespComp : public ResourceBase
		{
		public:

			StimRespComp( ) : ResourceBase( ) { Init( ); }
			StimRespComp( const Sensor& other ) : ResourceBase( ) { Init( ); operator = ( other ); }
			ResourceBase& operator = ( const ResourceBase& other );
			bool operator == ( const ResourceBase& other ) const;
			bool operator != ( const ResourceBase& other ) const { return !( operator == ( other ) ); }
			operator string( void ) const;
			Atlas::eAtlasNoun GetAtlasNoun( void ) const { return m_AtlasSignalComponent.GetAtlasNoun( ); }
			Atlas::eAtlasResource GetAtlasResource( void ) const { return Atlas::eSTIM_RESP_COMPResource; }
			void InitSignalComponents( void ) { m_AtlasSignalComponent.Set1641( ); }
			Atlas::AtlasSignalComponent* GetSignalComponent( void ) { return &m_AtlasSignalComponent; }

			void Init( const vector< const AtlasAttributes::AtlasAttibuteValue* >& vectAttributes, const string& strVirtualLabel );
			void ToXML( string& strXML ) const;

			Atlas::AtlasSignalComponent m_AtlasSignalComponent;

		protected:

			void Init( void )
			{
			}
		};  // class StimRespComp

		/*
		class Timer : public ResourceBase
		{
		};

		class DigitalTimer : public ResourceBase
		{
		};

		class EventMonitor : public ResourceBase
		{
		};
		*/

	public:

		Resource( ) : AtlasAttributes( ) { Init( ); }
		Resource( const Resource& other ) : AtlasAttributes( ) { Init( ); operator = ( other ); }
		Resource( const xercesc::DOMElement* pAIXMLvalue ) : AtlasAttributes( pAIXMLvalue ) { Init( ); }
		~Resource( ) { GarbageCollect( ); }
		Resource& operator = ( const Resource& other );

		void Merge( const Resource& other );
		void ToXML( string& strXML ) const;
		void Process( const Lookup* pLookup = 0 );
		void InitSignalComponents( void );
		ResourceBase* CreateResource( const Atlas::eAtlasResource eResourceType, const string& strVirtualLabel );
		Atlas::eAtlasNoun GetAtlasNoun( void ) const
		{ 
			Atlas::eAtlasNoun eNoun = Atlas::eUnknownAtlasNoun;
	
			if ( m_vectResourceInfo.size( ) > 0 )
			{
				eNoun = m_vectResourceInfo[ 0 ].second->GetAtlasNoun( );
			}

			return eNoun;
		}
		Atlas::eAtlasResource GetAtlasResource( void ) const
		{ 
			Atlas::eAtlasResource eResource = Atlas::eUnknownAtlasResource;
	
			if ( m_vectResourceInfo.size( ) > 0 )
			{
				eResource = m_vectResourceInfo[ 0 ].second->GetAtlasResource( );
			}

			return eResource;
		}

		vector< pair< Atlas::eAtlasResource, ResourceBase* > > m_vectResourceInfo;

		static const string m_strKeyDelimiter;

	protected:

		void GarbageCollect( void );

		void Init( void )
		{
		}
	};  // class Resource

	class Control : public AtlasAttributes
	{
	public:

		Control( ) : AtlasAttributes( ) { Init( ); }
		Control( const Control& other ) : AtlasAttributes( ) { Init( ); operator = ( other ); }
		Control( const xercesc::DOMElement* pAIXMLvalue ) : AtlasAttributes( pAIXMLvalue ) { Init( ); }
		~Control( ) { GarbageCollect( ); }
		Control& operator = ( const Control& other );

		void Merge( const Control& other );
		void ToXML( string& strXML ) const;
		string ToSignalXML( const Atlas::AtlasSignalComponent& component ) const;
		void Process( const Lookup* pLookup = 0 );
		void InitSignalComponents( void );
		bool HasNounModifier( const Atlas::eAtlasNounModifier eModifier ) const;

		vector< pair< Atlas::AtlasSignalComponent, Range* > > m_vectRanges;
		vector< pair< Atlas::AtlasSignalComponent, SettingValues* > > m_vectSettingsValues;
		vector< Atlas::AtlasSignalComponent > m_vectAtlasNounMod;
		vector< Atlas::AtlasSignalComponent > m_vectAtlasNounModFunctions;
		string* m_pstrTrigOutDrive;
		SourceIndentifier* m_pSourceIndentifier;
		Coupling* m_pCoupling;
		Mode* m_pMode;
		Circulate* m_pCirculate;
		Atlas::eAtlasNoun m_eNoun;

	protected:

		void GarbageCollect( );

		void Init( void )
		{
			m_eNoun = Atlas::eUnknownAtlasNoun;
			m_pstrTrigOutDrive = 0;
			m_pSourceIndentifier = 0;
			m_pCoupling = 0;
			m_pMode = 0;
			m_pCirculate = 0;
		}
	};  // class Control

	class Capability : public AtlasAttributes
	{
	public:

		Capability( ) : AtlasAttributes( ) { Init( ); }
		Capability( const Capability& other ) : AtlasAttributes( ) { Init( ); operator = ( other ); }
		Capability( const xercesc::DOMElement* pAIXMLvalue ) : AtlasAttributes( pAIXMLvalue ) { Init( ); }
		virtual ~Capability( ) { GarbageCollect( ); }
		virtual Capability& operator = ( const Capability& other );

		virtual void Merge( const Capability& other );
		virtual void ToXML( string& strXML ) const;
		string ToSignalXML( const Atlas::AtlasSignalComponent& component ) const;
		void Process( const Lookup* pLookup = 0 );
		virtual void InitSignalComponents( void );
		virtual bool HasNounModifier( const Atlas::eAtlasNounModifier eModifier ) const;

		vector< pair< Atlas::AtlasSignalComponent, Range* > > m_vectRanges;
		vector< pair< Atlas::AtlasSignalComponent, SettingValues* > > m_vectSettingsValues;
		vector< Atlas::AtlasSignalComponent > m_vectAtlasNounMod;
		vector< Atlas::AtlasSignalComponent > m_vectAtlasNounModFunctions;
		vector< pair< Atlas::AtlasSignalComponent, Atlas::AtlasNumber* > > m_vectMaximums;
		Coupling* m_pCoupling;
		Coupling* m_pCouplingRef;
		Circulate* m_pCirculate;
		Atlas::eAtlasNoun m_eNoun;

	protected:

		virtual void GarbageCollect( void );

		void Init( void )
		{
			m_eNoun = Atlas::eUnknownAtlasNoun;
			m_pCirculate = 0;
			m_pCoupling = 0;
			m_pCouplingRef = 0;
		}
	};  // class Capability

	class DeviceCapability : public Capability
	{
	public:

		DeviceCapability( ) : Capability( ) { Init( ); }
		DeviceCapability( const DeviceCapability& other ) : Capability( ) { Init( ); operator = ( other ); }
		DeviceCapability( const xercesc::DOMElement* pAIXMLvalue ) : Capability( pAIXMLvalue ) { Init( ); }
		Capability& operator = ( const Capability& other );

		void Merge( const Capability& other );
		void ToXML( string& strXML ) const;
		void Process( const Lookup* pLookup = 0 );
		void InitSignalComponents( void );

		Atlas::AtlasNumber m_LineLength;
		Atlas::AtlasNumber m_PageSize;
		bool m_bHardCopy;

	protected:

		void Init( void )
		{
			m_bHardCopy = false;
		}
	};  // class DeviceCapability

	class FileCapability : public Capability
	{
	public:

		struct FileAttributes
		{
			FileAttributes( ) { Init( ); }
			FileAttributes( const FileAttributes& other ) { Init( ); operator = ( other ); }
			FileAttributes& operator = ( const FileAttributes& other )
			{
				if ( this != &other )
				{
					m_eFileOrganization = other.m_eFileOrganization;
					m_eFileForm			= other.m_eFileForm;
					m_eRecordType		= other.m_eRecordType;
					m_RecordLength		= other.m_RecordLength;
				}

				return *this;
			}
			operator string( void ) const
			{
				const string strColon( ":" );
				string strRet;
					
				strRet += AIXMLHelper::NumberToString< int >( ( int ) m_eFileOrganization );
				strRet += strColon;
				strRet += AIXMLHelper::NumberToString< int >( ( int ) m_eFileForm );
				strRet += strColon;
				strRet += AIXMLHelper::NumberToString< int >( ( int ) m_eRecordType );
				strRet += strColon;
				strRet += ( string ) m_RecordLength;

				return strRet;
			}

			void ToXML( string& strXML ) const
			{
				strXML += XML::MakeOpenXmlElementWithChildren( XML::enFile );
				strXML += XML::MakeXmlElementNoChildren( XML::enOrganization, XML::MakeXmlAttributeNameValue( XML::anType, Atlas::GetAtlasInputOutput( m_eFileOrganization ) ) );
				strXML += XML::MakeXmlElementNoChildren( XML::enForm, XML::MakeXmlAttributeNameValue( XML::anType, Atlas::GetAtlasInputOutput( m_eFileForm ) ) );
				strXML += XML::MakeXmlElementNoChildren( XML::enRecordType, XML::MakeXmlAttributeNameValue( XML::anType, Atlas::GetAtlasInputOutput( m_eRecordType ) ) );
				strXML += XML::MakeXmlElementNoChildren( XML::enRecordLength, m_RecordLength.ToXML( ) );
				strXML += XML::MakeCloseXmlElementWithChildren( XML::enFile );
			}

			Atlas::eInputOutputAttribute m_eFileOrganization;
			Atlas::eInputOutputAttribute m_eFileForm;
			Atlas::eInputOutputAttribute m_eRecordType;
			Atlas::AtlasNumber m_RecordLength;

		protected:
			void Init( void )
			{
				m_eFileOrganization	= Atlas::eUnknownInputOutputAttribute;
				m_eFileForm			= Atlas::eUnknownInputOutputAttribute;
				m_eRecordType		= Atlas::eUnknownInputOutputAttribute;
			}
		};

		FileCapability( ) : Capability( ) { Init( ); }
		FileCapability( const FileCapability& other ) : Capability( ) { Init( ); operator = ( other ); }
		FileCapability( const xercesc::DOMElement* pAIXMLvalue ) : Capability( pAIXMLvalue ) { Init( ); }
		~FileCapability( ) { GarbageCollect( ); }
		Capability& operator = ( const Capability& other );

		void Merge( const Capability& other );
		void ToXML( string& strXML ) const;
		void Process( const Lookup* pLookup = 0 );
		void InitSignalComponents( void );

		vector< FileAttributes* > m_vectFileAttributes;

	protected:

		void GarbageCollect( void );

		void Init( void ) { }

	};  // class FileCapability


	class VideoCapability : public Capability
	{
	public:

		VideoCapability( ) : Capability( ) { Init( ); }
		VideoCapability( const VideoCapability& other ) : Capability( ) { Init( ); operator = ( other ); }
		VideoCapability( const xercesc::DOMElement* pAIXMLvalue ) : Capability( pAIXMLvalue ) { Init( ); }
		~VideoCapability( ) { GarbageCollect( ); }
		Capability& operator = ( const Capability& other );

		void Merge( const Capability& other );
		void ToXML( string& strXML ) const;
		void Process( const Lookup* pLookup = 0 );
		void InitSignalComponents( void );
		bool HasCapability( void ) const;
		bool HasNounModifier( const Atlas::eAtlasNounModifier eModifier ) const;

		VideoHorizontalTiming* m_pVideoHorizontalTiming;
		VideoVerticalTiming* m_pVideoVerticalTiming;
		VideoSync* m_pVideoSync;
		VideoSyncPolarity* m_pVideoSyncPolarity;
		VideoVideo* m_pVideoVideo;
		VideoImage* m_pVideoImage;
		VideoDraw* m_pVideoDraw;

		static set< Atlas::eAtlasNounModifier > m_setLoopTermination;

	protected:

		void GarbageCollect( void );

		void Init( void )
		{
			if ( 0 == m_setLoopTermination.size( ) )
			{
				m_setLoopTermination.insert( Atlas::eHORIZONTAL_TIMING );
				m_setLoopTermination.insert( Atlas::eVERTICAL_TIMING );
				m_setLoopTermination.insert( Atlas::eSYNC );
				m_setLoopTermination.insert( Atlas::eSYNC_POLARITY );
				m_setLoopTermination.insert( Atlas::eVIDEO );
				m_setLoopTermination.insert( Atlas::eIMAGE );
				m_setLoopTermination.insert( Atlas::eDRAW );
			}

			m_pVideoHorizontalTiming = 0;
			m_pVideoVerticalTiming = 0;
			m_pVideoSync = 0;
			m_pVideoSyncPolarity = 0;
			m_pVideoVideo = 0;
			m_pVideoImage = 0;
			m_pVideoDraw = 0;
		}

	};  // class VideoCapability

	class Limit : public AtlasAttributes
	{
	public:

		Limit( ) : AtlasAttributes( ) { Init( ); }
		Limit( const Limit& other ) : AtlasAttributes( ) { Init( ); operator = ( other ); }
		Limit( const xercesc::DOMElement* pAIXMLvalue ) : AtlasAttributes( pAIXMLvalue )	{ Init( ); }
		~Limit( ) { GarbageCollect( ); }
		Limit& operator = ( const Limit& other );

		void Merge( const Limit& other );
		void ToXML( string& strXML ) const;
		string ToSignalXML( const Atlas::AtlasSignalComponent& component ) const;
		void Process( const Lookup* pLookup = 0 );
		void InitSignalComponents( void );
		bool HasNounModifier( const Atlas::eAtlasNounModifier eModifier ) const;

		vector< pair< Atlas::AtlasSignalComponent, Range* > > m_vectRanges;
		vector< pair< Atlas::AtlasSignalComponent, Atlas::AtlasNumber* > > m_vectMaximums;
		Atlas::eAtlasNoun m_eNoun;

	protected:

		void GarbageCollect( void );

		void Init( void )
		{ 
			m_eNoun = Atlas::eUnknownAtlasNoun;
		}
	};  // class Limit

	enum eToXMLBitField
	{
		eCreateAtlasSourcesElement	= 0x01,
		eSignalOnly					= 0x02,
		eClassOnly					= 0x04,
		eAll						= 0x08,
		eInstruments				= 0x10,
		eModifiers					= 0x20,
		eUsedAttribute				= 0x40
	};

	AtlasRequire( const Atlas::eAtlasStatement eStatement ) : AtlasSignalVerb( eStatement ) { Init( ); }
	AtlasRequire( const AtlasRequire& other ) { Init( ); operator = ( other ); }
	~AtlasRequire( ) { GarbageCollect( ); }
	AtlasStatement& operator = ( const AtlasStatement& other );

	void InitFromXML( const xercesc::DOMElement* pAIXMLvalue );
	void Process( const Lookup* pLookup = 0 );
	void Merge( const AtlasRequire& other, const bool bMergeSignalOnly );
	void ToXML( string& strXML ) const { ToXML( strXML, eCreateAtlasSourcesElement ); }
	void ToXML( string& strXML, const unsigned int uiBitfield ) const;
	void ToSignalXML( string& strXML, const map< string, pair< Atlas::AtlasSignalComponent, unsigned int > >& mapSignalModifiers ) const;
	void InitSignalComponents( void );
	bool HasSignal( void ) const;
	Atlas::eAtlasNoun GetAtlasNoun( void ) const;
	void InitSignalInfo( AtlasSignalInfo* pInformation, const unsigned int uiBitfield );

	void SetUsed( const bool bUsed ) { m_bUsed = bUsed; }
	bool IsUsed( void ) const;

	eProcessType m_eLastProcessType;
	Resource* m_pResource;
	Control* m_pControl;
	Capability* m_pCapability;
	Limit* m_pLimit;
	CNX* m_pCNX;
	bool m_bInstrument;

protected:

	bool m_bUsed;

	static Capability* CapabilityFactory( const string& strVirtualLabel, const SpecificInstrument::eInstrument eType, const xercesc::DOMElement* pAIXMLvalue );

	void Init( void )
	{
		m_eLastProcessType	= eStartProcess;
		m_bInstrument		= false;
		m_bUsed				= false;
		m_pResource			= 0;
		m_pControl			= 0;
		m_pCapability		= 0;
		m_pLimit			= 0;
		m_pCNX				= 0;
	}

	void GarbageCollect( void );

};  // class AtlasRequire

class AtlasRequires : public AtlasStatements
{
public:

	AtlasRequires( const AtlasStatements& other ) : AtlasStatements( ) { operator = ( other ); }
	AtlasRequires( ) : AtlasStatements( ) { m_it = m_mapRequires.end( ); }
	#ifdef CASS
		AtlasRequires( const Lookup* pLookup ) : AtlasStatements( pLookup ) { m_it = m_mapRequires.end( ); }
	#endif
	~AtlasRequires( ) { }
	AtlasRequires& operator = ( const AtlasStatements& other );

	AtlasStatement* StatementFactory( const xercesc::DOMElement* pAIXMLvalue, const Atlas::eAtlasStatement eStatementType );
	AtlasStatement* StatementFactory( const AtlasStatement* pOtherAtlasStatement );

	void Merge( const AtlasRequires& other );

	unsigned int GetUsedCount( void ) const;

	void ResetIterator( void ) { m_it = m_mapRequires.end( ); }
	const AtlasRequire* GetNext( void );

	const AtlasRequire* GetRequire( const string& strVirtualLabel ) const;

protected:

	map< string, AtlasStatement* > m_mapRequires; // <virtual label>, require attributes
	map< string, AtlasStatement* >::const_iterator m_it;

};  // AtlasRequires
