/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

#include "require.h"
#include "atlas_noun_modifier.h"
#include "cass_video.h"
#include "cnx.h"
#include "helper.h"
#include "aixml.h"

#ifdef CASS
	#include "cass/lookup.h"
#endif

// Xercesc XML Parser
#include <xercesc/dom/impl/DOMElementImpl.hpp>

#if ( _DEBUG ) && ( WIN32 )
	#define WINVER 0x0600
	#include <afx.h>
	#define new DEBUG_NEW
	#undef THIS_FILE
	static char BASED_CODE THIS_FILE[ ] = __FILE__;
#endif

using namespace XERCES_CPP_NAMESPACE;

set< Atlas::eAtlasNounModifier > AtlasRequire::VideoCapability::m_setLoopTermination;
const string AtlasRequire::Resource::m_strKeyDelimiter( ":" );

void AtlasRequire::Resource::GarbageCollect( void )
{
	const unsigned int uiSize = m_vectResourceInfo.size( );
	for ( unsigned int ui = 0; ui < uiSize; ++ui )
	{
		delete m_vectResourceInfo[ ui ].second;
	}
	m_vectResourceInfo.clear( );
}

void AtlasRequire::Control::GarbageCollect( )
{
	unsigned int uiSize = m_vectRanges.size( );
	for ( unsigned int ui = 0; ui < uiSize; ++ui )
	{
		delete m_vectRanges[ ui ].second;
	}
	m_vectRanges.clear( );

	uiSize = m_vectSettingsValues.size( );
	for ( unsigned int ui = 0; ui < uiSize; ++ui )
	{
		delete m_vectSettingsValues[ ui ].second;
	}
	m_vectSettingsValues.clear( );

	m_vectAtlasNounMod.clear( );
	m_vectAtlasNounModFunctions.clear( );

	if ( 0 != m_pstrTrigOutDrive )
	{
		delete m_pstrTrigOutDrive;
		m_pstrTrigOutDrive = 0;
	}

	if ( 0 != m_pSourceIndentifier )
	{
		delete m_pSourceIndentifier;
		m_pSourceIndentifier = 0;
	}

	if ( 0 != m_pCoupling )
	{
		delete m_pCoupling;
		m_pCoupling = 0;
	}

	if ( 0 != m_pMode )
	{
		delete m_pMode;
		m_pMode = 0;
	}

	if ( 0 != m_pCirculate )
	{
		delete m_pCirculate;
		m_pCirculate = 0;
	}
}

void AtlasRequire::Capability::GarbageCollect( void )
{
	unsigned int uiSize = m_vectRanges.size( );
	for ( unsigned int ui = 0; ui < uiSize; ++ui )
	{
		delete m_vectRanges[ ui ].second;
	}
	m_vectRanges.clear( );

	uiSize = m_vectSettingsValues.size( );
	for ( unsigned int ui = 0; ui < uiSize; ++ui )
	{
		delete m_vectSettingsValues[ ui ].second;
	}
	m_vectSettingsValues.clear( );

	uiSize = m_vectMaximums.size( );
	for ( unsigned int ui = 0; ui < uiSize; ++ui )
	{
		delete m_vectMaximums[ ui ].second;
	}
	m_vectMaximums.clear( );

	m_vectAtlasNounMod.clear( );
	m_vectAtlasNounModFunctions.clear( );

	if ( 0 != m_pCirculate )
	{
		delete m_pCirculate;
		m_pCirculate = 0;
	}

	if ( 0 != m_pCoupling )
	{
		delete m_pCoupling;
		m_pCoupling = 0;
	}

	if ( 0 != m_pCouplingRef )
	{
		delete m_pCouplingRef;
		m_pCouplingRef = 0;
	}
}

void AtlasRequire::FileCapability::GarbageCollect( void )
{
	const unsigned int uiSize = m_vectFileAttributes.size( );
	for ( unsigned int ui = 0; ui < uiSize; ++ui )
	{
		delete m_vectFileAttributes[ ui ];
	}
	m_vectFileAttributes.clear( );
}

void AtlasRequire::VideoCapability::GarbageCollect( void )
{
	if ( 0 != m_pVideoHorizontalTiming )
	{
		delete m_pVideoHorizontalTiming;
		m_pVideoHorizontalTiming = 0;
	}

	if ( 0 != m_pVideoVerticalTiming )
	{
		delete m_pVideoVerticalTiming;
		m_pVideoVerticalTiming = 0;
	}

	if ( 0 != m_pVideoSync )
	{
		delete m_pVideoSync;
		m_pVideoSync = 0;
	}

	if ( 0 != m_pVideoSyncPolarity )
	{
		delete m_pVideoSyncPolarity;
		m_pVideoSyncPolarity = 0;
	}

	if ( 0 != m_pVideoVideo )
	{
		delete m_pVideoVideo;
		m_pVideoVideo = 0;
	}

	if ( 0 != m_pVideoImage )
	{
		delete m_pVideoImage;
		m_pVideoImage = 0;
	}

	if ( 0 != m_pVideoDraw )
	{
		delete m_pVideoDraw;
		m_pVideoDraw = 0;
	}
}

void AtlasRequire::Limit::GarbageCollect( void )
{
	unsigned int uiSize = m_vectRanges.size( );
	for ( unsigned int ui = 0; ui < uiSize; ++ui )
	{
		delete m_vectRanges[ ui ].second;
	}
	m_vectRanges.clear( );

	uiSize = m_vectMaximums.size( );
	for ( unsigned int ui = 0; ui < uiSize; ++ui )
	{
		delete m_vectMaximums[ ui ].second;
	}
	m_vectMaximums.clear( );
}

void AtlasRequire::InitFromXML( const DOMElement* pAIXMLvalue )
{
	if ( eStartProcess == m_eLastProcessType )
	{
		try
		{
			m_pResource = new Resource( pAIXMLvalue );
		}
		catch( ... )
		{
			throw Exception( Exception::eFailedToCreateResourceObject, __FILE__, __FUNCTION__, __LINE__, m_strVirtualLabel );
		}

		m_pResource->SetId( m_strId );

		m_eLastProcessType = eResourceProcess;
	}
	else
	{
		const DOMElement* pAIXMLFirstChild = AIXMLHelper::GetFirstChildWhereAttributeExists( pAIXMLvalue, AIXML::m_arrayXMLKeyWords[ AIXML::eWordAttribute ] );

		if ( 0 != pAIXMLFirstChild )
		{
			const string strWord( AIXMLHelper::GetXercesString( pAIXMLFirstChild->getAttribute( AIXMLHelper::GetWString( AIXML::m_arrayXMLKeyWords[ AIXML::eWordAttribute ] ).c_str( ) ) ) );
	
			const Atlas::eAtlasRequire eType = Atlas::GetAtlasRequireEnum( strWord );

			switch ( eType )
			{
				case Atlas::eUnknownAtlasRequire:
					switch ( m_eLastProcessType )
					{
						case eResourceProcess:
							m_pResource->InitFromXML( pAIXMLvalue );
							break;
				
						case eControlProcess:
							m_pControl->InitFromXML( pAIXMLvalue );
							break;
				
						case eCapabilityProcess:
							m_pCapability->InitFromXML( pAIXMLvalue );
							break;
				
						case eLimitProcess:
							m_pLimit->InitFromXML( pAIXMLvalue );
							break;
				
						case eCNXProcess:
							m_pCNX->InitFromXML( pAIXMLvalue );
							break;
					}
					break;

				case Atlas::eAtlasRequireControl:
					try
					{
						m_pControl = new Control( pAIXMLvalue );
					}
					catch( ... )
					{
						throw Exception( Exception::eFailedToCreateControlObject, __FILE__, __FUNCTION__, __LINE__, m_strVirtualLabel );
					}

					m_pControl->SetId( m_strId );

					m_eLastProcessType = eControlProcess;
					break;

				case Atlas::eAtlasRequireCapability:
					m_pCapability = CapabilityFactory( m_strVirtualLabel, m_eInstrument, pAIXMLvalue );
					m_eLastProcessType = eCapabilityProcess;
					break;

				case Atlas::eAtlasRequireLimit:
					try
					{
						m_pLimit = new Limit( pAIXMLvalue );
					}
					catch( ... )
					{
						throw Exception( Exception::eFailedToCreateLimitObject, __FILE__, __FUNCTION__, __LINE__, m_strVirtualLabel );
					}

					m_pLimit->SetId( m_strId );

					m_eLastProcessType = eLimitProcess;
					break;

				case Atlas::eAtlasRequireCNX:
					try
					{
						m_pCNX = new CNX( pAIXMLvalue, true );
					}
					catch( ... )
					{
						throw Exception( Exception::eFailedToCreateCNXObject, __FILE__, __FUNCTION__, __LINE__, m_strVirtualLabel );
					}

					m_pCNX->SetId( m_strId );

					m_eLastProcessType = eCNXProcess;
					break;
			}
		}
	}
}

AtlasRequire::Capability* AtlasRequire::CapabilityFactory( const string& strVirtualLabel, const SpecificInstrument::eInstrument eType, const DOMElement* pAIXMLvalue )
{
	Capability* pCapability = 0;

	try
	{
		if ( SpecificInstrument::IsDeviceClass( SpecificInstrument::GetInstrumentClass( eType ) ) )
		{
			if ( 0 == pAIXMLvalue )
			{
				pCapability = new DeviceCapability( );
			}
			else
			{
				pCapability = new DeviceCapability( pAIXMLvalue );
			}
		}
		else if ( SpecificInstrument::IsFileClass( SpecificInstrument::GetInstrumentClass( eType ) ) )
		{
			if ( 0 == pAIXMLvalue )
			{
				pCapability = new FileCapability( );
			}
			else
			{
				pCapability = new FileCapability( pAIXMLvalue );
			}
		}
		else if ( SpecificInstrument::IsVideoClass( SpecificInstrument::GetInstrumentClass( eType ) ) )
		{
			if ( 0 == pAIXMLvalue )
			{
				pCapability = new VideoCapability( );
			}
			else
			{
				pCapability = new VideoCapability( pAIXMLvalue );
			}
		}
		else
		{
			if ( 0 == pAIXMLvalue )
			{
				pCapability = new Capability( );
			}
			else
			{
				pCapability = new Capability( pAIXMLvalue );
			}
		}
	}
	catch( ... )
	{
		throw Exception( Exception::eFailedToCreateCapabilityObject, __FILE__, __FUNCTION__, __LINE__, strVirtualLabel );
	}

	pCapability->SetId( strVirtualLabel );

	return pCapability;
}

void AtlasRequire::VideoCapability::Merge( const AtlasRequire::Capability& other )
{
	if ( this != &other )
	{
		Capability::Merge( other );

		const VideoCapability* pother = dynamic_cast< const VideoCapability* >( &other );
	
		if ( 0 != pother )
		{
			if ( ( 0 != m_pVideoHorizontalTiming ) && ( 0 != pother->m_pVideoHorizontalTiming ) )
			{
				m_pVideoHorizontalTiming->Merge( *( pother->m_pVideoHorizontalTiming ) );
			}
			else if ( 0 != pother->m_pVideoHorizontalTiming )
			{
				try
				{
					m_pVideoHorizontalTiming = new VideoHorizontalTiming( *( pother->m_pVideoHorizontalTiming ) );
				}
				catch( ... )
				{
					throw Exception( Exception::eFailedToCreateVideoObject, __FILE__, __FUNCTION__, __LINE__ );
				}
			}

			if ( ( 0 != m_pVideoVerticalTiming ) && ( 0 != pother->m_pVideoVerticalTiming ) )
			{
				m_pVideoVerticalTiming->Merge( *( pother->m_pVideoVerticalTiming ) );
			}
			else if ( 0 != pother->m_pVideoVerticalTiming )
			{
				try
				{
					m_pVideoVerticalTiming = new VideoVerticalTiming( *( pother->m_pVideoVerticalTiming ) );
				}
				catch( ... )
				{
					throw Exception( Exception::eFailedToCreateVideoObject, __FILE__, __FUNCTION__, __LINE__ );
				}
			}

			if ( ( 0 != m_pVideoSync ) && ( 0 != pother->m_pVideoSync ) )
			{
				m_pVideoSync->Merge( *( pother->m_pVideoSync ) );
			}
			else if ( 0 != pother->m_pVideoSync )
			{
				try
				{
					m_pVideoSync = new VideoSync( *( pother->m_pVideoSync ) );
				}
				catch( ... )
				{
					throw Exception( Exception::eFailedToCreateVideoObject, __FILE__, __FUNCTION__, __LINE__ );
				}
			}

			if ( ( 0 != m_pVideoSyncPolarity ) && ( 0 != pother->m_pVideoSyncPolarity ) )
			{
				m_pVideoSyncPolarity->Merge( *( pother->m_pVideoSyncPolarity ) );
			}
			else if ( 0 != pother->m_pVideoSyncPolarity )
			{
				try
				{
					m_pVideoSyncPolarity = new VideoSyncPolarity( *( pother->m_pVideoSyncPolarity ) );
				}
				catch( ... )
				{
					throw Exception( Exception::eFailedToCreateVideoObject, __FILE__, __FUNCTION__, __LINE__ );
				}
			}

			if ( ( 0 != m_pVideoVideo ) && ( 0 != pother->m_pVideoVideo ) )
			{
				m_pVideoVideo->Merge( *( pother->m_pVideoVideo ) );
			}
			else if ( 0 != pother->m_pVideoVideo )
			{
				try
				{
					m_pVideoVideo = new VideoVideo( *( pother->m_pVideoVideo ) );
				}
				catch( ... )
				{
					throw Exception( Exception::eFailedToCreateVideoObject, __FILE__, __FUNCTION__, __LINE__ );
				}
			}

			if ( ( 0 != m_pVideoImage )  && ( 0 != pother->m_pVideoImage ) )
			{
				m_pVideoImage->Merge( *( pother->m_pVideoImage ) );
			}
			else if ( 0 != pother->m_pVideoImage )
			{
				try
				{
					m_pVideoImage = new VideoImage( *( pother->m_pVideoImage ) );
				}
				catch( ... )
				{
					throw Exception( Exception::eFailedToCreateVideoObject, __FILE__, __FUNCTION__, __LINE__ );
				}
			}

			if ( ( 0 != m_pVideoDraw ) && ( 0 != pother->m_pVideoDraw ) )
			{
				m_pVideoDraw->Merge( *( pother->m_pVideoDraw ) );
			}
			else if ( 0 != pother->m_pVideoDraw )
			{
				try
				{
					m_pVideoDraw = new VideoDraw( *( pother->m_pVideoDraw ) );
				}
				catch( ... )
				{
					throw Exception( Exception::eFailedToCreateVideoObject, __FILE__, __FUNCTION__, __LINE__ );
				}
			}
		}
	}
}

void AtlasRequire::VideoCapability::Process( const Lookup* pLookup )
{
	if ( !m_bProcessed )
	{
		const unsigned int uiAttributes = m_vectAttributes.size( );
		
		if ( 0 == uiAttributes )
		{
			throw Exception( Exception::eInvalidNumberOfAttributesForDeviceCapability, __FILE__, __FUNCTION__, __LINE__, m_strId );
		}

		unsigned int uiPos = 1; 

		while ( uiPos < uiAttributes )
		{
			string strAtlasNounModifier( m_vectAttributes[ uiPos ]->m_strValue );

			Atlas::AtlasSignalComponent AtlasNM( Atlas::GetAtlasNounModifierEnum( strAtlasNounModifier ) );

			if ( !AtlasNM.IsValid( ) )
			{
				string strError( m_strId );
					
				strError += ": Atlas noun/modifier: ";
				strError += strAtlasNounModifier;
		
				throw Exception( Exception::eUnknownAtlasNounModifierForCapability, __FILE__, __FUNCTION__, __LINE__, strError );
			}

			++uiPos;

			AtlasNM.SetAtlasNoun( m_eNoun );

			if ( uiPos < uiAttributes )
			{
				switch ( AtlasNM.GetAtlasNounModifier( ) )
				{
					case Atlas::eHORIZONTAL_TIMING:
					{
						if ( 0 != m_pVideoHorizontalTiming )
						{
							throw Exception( Exception::ePointerAlreadyUsed, __FILE__, __FUNCTION__, __LINE__, m_strId );
						}
	
						try
						{
							m_pVideoHorizontalTiming = new VideoHorizontalTiming;
						}
						catch( ... )
						{
							string strError( m_strId );
			
							strError += ": capability Horizontal Timing";
			
							throw Exception( Exception::eFailedToCreateVideoObject, __FILE__, __FUNCTION__, __LINE__, strError );
						}

						uiPos = m_pVideoHorizontalTiming->Init( m_strId, m_vectAttributes, uiPos, m_setLoopTermination );
					}
					break;

					case Atlas::eVERTICAL_TIMING:
					{
						if ( 0 != m_pVideoVerticalTiming )
						{
							throw Exception( Exception::ePointerAlreadyUsed, __FILE__, __FUNCTION__, __LINE__, m_strId );
						}
	
						try
						{
							m_pVideoVerticalTiming = new VideoVerticalTiming;
						}
						catch( ... )
						{
							string strError( m_strId );
			
							strError += ": capability Vertical Timing";
			
							throw Exception( Exception::eFailedToCreateVideoObject, __FILE__, __FUNCTION__, __LINE__, strError );
						}
	
						uiPos = m_pVideoVerticalTiming->Init( m_strId, m_vectAttributes, uiPos, m_setLoopTermination );
					}
					break;
	
					case Atlas::eSYNC:
					{
						if ( 0 != m_pVideoSync )
						{
							throw Exception( Exception::ePointerAlreadyUsed, __FILE__, __FUNCTION__, __LINE__, m_strId );
						}
	
						try
						{
							m_pVideoSync = new VideoSync;
						}
						catch( ... )
						{
							string strError( m_strId );
			
							strError += ": capability Sync";
			
							throw Exception( Exception::eFailedToCreateVideoObject, __FILE__, __FUNCTION__, __LINE__, strError );
						}
	
						uiPos = m_pVideoSync->Init( m_strId, m_vectAttributes, uiPos, m_setLoopTermination );
					}
					break;

					case Atlas::eSYNC_POLARITY:
					{
						if ( 0 != m_pVideoSyncPolarity )
						{
							throw Exception( Exception::ePointerAlreadyUsed, __FILE__, __FUNCTION__, __LINE__, m_strId );
						}
	
						try
						{
							m_pVideoSyncPolarity = new VideoSyncPolarity;
						}
						catch( ... )
						{
							string strError( m_strId );
			
							strError += ": capability Sync Polarity";
			
							throw Exception( Exception::eFailedToCreateVideoObject, __FILE__, __FUNCTION__, __LINE__, strError );
						}
	
						uiPos = m_pVideoSyncPolarity->Init( m_strId, m_vectAttributes, uiPos, m_setLoopTermination );
					}
					break;
	
					case Atlas::eVIDEO:
					{
						if ( 0 != m_pVideoVideo )
						{
							throw Exception( Exception::ePointerAlreadyUsed, __FILE__, __FUNCTION__, __LINE__, m_strId );
						}
	
						try
						{
							m_pVideoVideo = new VideoVideo;
						}
						catch( ... )
						{
							string strError( m_strId );
			
							strError += ": capability Video";
			
							throw Exception( Exception::eFailedToCreateVideoObject, __FILE__, __FUNCTION__, __LINE__, strError );
						}
	
						uiPos = m_pVideoVideo->Init( m_strId, m_vectAttributes, uiPos, m_setLoopTermination );
					}
					break;

					case Atlas::eIMAGE:
					{
						if ( 0 != m_pVideoImage )
						{
							throw Exception( Exception::ePointerAlreadyUsed, __FILE__, __FUNCTION__, __LINE__, m_strId );
						}
	
						try
						{
							m_pVideoImage = new VideoImage;
						}
						catch( ... )
						{
							string strError( m_strId );
			
							strError += ": capability Video Image";
			
							throw Exception( Exception::eFailedToCreateVideoObject, __FILE__, __FUNCTION__, __LINE__, strError );
						}

						Range* pImageRange = 0;

						try
						{
							pImageRange = new Range;
						}
						catch( ... )
						{
							throw Exception( Exception::eFailedToCreateRangeObject, __FILE__, __FUNCTION__, __LINE__, m_strId );
						}

						m_pVideoImage->m_vectRanges.push_back( make_pair( AtlasNM, pImageRange ) );

						uiPos = pImageRange->Init( m_strId, m_vectAttributes, uiPos + 1  );
					}
					break;

					case Atlas::eDRAW:
					{
						if ( 0 != m_pVideoDraw )
						{
							throw Exception( Exception::ePointerAlreadyUsed, __FILE__, __FUNCTION__, __LINE__, m_strId );
						}
	
						try
						{
							m_pVideoDraw = new VideoDraw;
						}
						catch( ... )
						{
							string strError( m_strId );
			
							strError += ": capability Draw";
			
							throw Exception( Exception::eFailedToCreateVideoObject, __FILE__, __FUNCTION__, __LINE__, strError );
						}
	
						uiPos = m_pVideoDraw->Init( m_strId, m_vectAttributes, uiPos, m_setLoopTermination );
					}
					break;

					default:
					{
						const string& strWord = m_vectAttributes[ uiPos ]->m_strValue;
		
						if ( m_strRANGE == strWord )
						{
							Range* pRange = 0;

							try
							{
								pRange = new Range;
							}
							catch( ... )
							{
								string strError( m_strId );
				
								strError += ": capability range";
				
								throw Exception( Exception::eFailedToCreateRangeObject, __FILE__, __FUNCTION__, __LINE__, strError );
							}
		
							m_vectRanges.push_back( make_pair( AtlasNM, pRange ) );
				
							uiPos = pRange->Init( m_strId, m_vectAttributes, uiPos + 1  );
						}
					}
					break;
				}
			}
		}
	}
}

void AtlasRequire::VideoCapability::InitSignalComponents( void )
{
	if ( 0 != m_pVideoHorizontalTiming )
	{
		m_pVideoHorizontalTiming->InitSignalComponents( );
	}

	if ( 0 != m_pVideoVerticalTiming )
	{
		m_pVideoVerticalTiming->InitSignalComponents( );
	}

	if ( 0 != m_pVideoSync )
	{
		m_pVideoSync->InitSignalComponents( );
	}

	if ( 0 != m_pVideoSyncPolarity )
	{
		m_pVideoSyncPolarity->InitSignalComponents( );
	}

	if ( 0 != m_pVideoVideo )
	{
		m_pVideoVideo->InitSignalComponents( );
	}

	if ( 0 != m_pVideoImage )
	{
		m_pVideoImage->InitSignalComponents( );
	}

	if ( 0 != m_pVideoDraw )
	{
		m_pVideoDraw->InitSignalComponents( );
	}
}

bool AtlasRequire::VideoCapability::HasCapability( void ) const
{
	bool bCapability = false;

	if ( 0 != m_pVideoHorizontalTiming )
	{
		bCapability = true;
	}
	else if ( 0 != m_pVideoVerticalTiming )
	{
		bCapability = true;
	}
	else if ( 0 != m_pVideoSync )
	{
		bCapability = true;
	}
	else if ( 0 != m_pVideoSyncPolarity )
	{
		bCapability = true;
	}
	else if ( 0 != m_pVideoVideo )
	{
		bCapability = true;
	}
	else if ( 0 != m_pVideoImage )
	{
		bCapability = true;
	}
	else if ( 0 != m_pVideoDraw )
	{
		bCapability = true;
	}

	return bCapability;
}

bool AtlasRequire::VideoCapability::HasNounModifier( const Atlas::eAtlasNounModifier eModifier ) const
{
	bool bHasNounModifier = Capability::HasNounModifier( eModifier );

	if ( !bHasNounModifier )
	{
		if ( !bHasNounModifier && ( 0 != m_pVideoHorizontalTiming )	)
		{
			if ( eModifier == Atlas::eHORIZONTAL_TIMING )
			{
				bHasNounModifier = true;
			}
			else
			{
				bHasNounModifier = m_pVideoHorizontalTiming->HasNounModifier( eModifier );
			}
		}

		if ( !bHasNounModifier && ( 0 != m_pVideoVerticalTiming ) )
		{
			if ( eModifier == Atlas::eVERTICAL_TIMING )
			{
				bHasNounModifier = true;
			}
			else
			{
				bHasNounModifier = m_pVideoVerticalTiming->HasNounModifier( eModifier );
			}
		}

		if ( !bHasNounModifier && ( 0 != m_pVideoSync ) )
		{
			if ( eModifier == Atlas::eSYNC )
			{
				bHasNounModifier = true;
			}
			else
			{
				bHasNounModifier = m_pVideoSync->HasNounModifier( eModifier );
			}
		}

		if ( !bHasNounModifier && ( 0 != m_pVideoSyncPolarity ) )
		{
			if ( eModifier == Atlas::eSYNC_POLARITY )
			{
				bHasNounModifier = true;
			}
			else
			{
				bHasNounModifier = m_pVideoSyncPolarity->HasNounModifier( eModifier );
			}
		}

		if ( !bHasNounModifier && ( 0 != m_pVideoVideo ) )
		{
			if ( eModifier == Atlas::eVIDEO )
			{
				bHasNounModifier = true;
			}
			else
			{
				bHasNounModifier = m_pVideoVideo->HasNounModifier( eModifier );
			}
		}

		if ( !bHasNounModifier && ( 0 != m_pVideoImage ) )
		{
			if ( eModifier == Atlas::eIMAGE )
			{
				bHasNounModifier = true;
			}
			else
			{
				bHasNounModifier = m_pVideoImage->HasNounModifier( eModifier );
			}
		}

		if ( !bHasNounModifier && ( 0 != m_pVideoDraw )	 )
		{
			if ( eModifier == Atlas::eDRAW )
			{
				bHasNounModifier = true;
			}
			else
			{
				bHasNounModifier = m_pVideoDraw->HasNounModifier( eModifier );
			}
		}
	}

	return bHasNounModifier;

}

void AtlasRequire::VideoCapability::ToXML( string& strXML ) const
{
	if ( HasCapability( ) )
	{
		strXML += XML::MakeOpenXmlElementWithChildren( XML::enCapability );

		if ( 0 != m_pVideoHorizontalTiming )
		{
			m_pVideoHorizontalTiming->ToXML( strXML );
		}
	
		if ( 0 != m_pVideoVerticalTiming )
		{
			m_pVideoVerticalTiming->ToXML( strXML );
		}
	
		if ( 0 != m_pVideoSync )
		{
			m_pVideoSync->ToXML( strXML );
		}
	
		if ( 0 != m_pVideoSyncPolarity )
		{
			m_pVideoSyncPolarity->ToXML( strXML );
		}
	
		if ( 0 != m_pVideoVideo )
		{
			m_pVideoVideo->ToXML( strXML );
		}
	
		if ( 0 != m_pVideoImage )
		{
			m_pVideoImage->ToXML( strXML );
		}
	
		if ( 0 != m_pVideoDraw )
		{
			m_pVideoDraw->ToXML( strXML );
		}

		strXML += XML::MakeCloseXmlElementWithChildren( XML::enCapability );
	}
}

void AtlasRequire::FileCapability::ToXML( string& strXML ) const
{
	const unsigned int uiSize = m_vectFileAttributes.size( );

	if ( uiSize > 0 )
	{
		strXML += XML::MakeOpenXmlElementWithChildren( XML::enCapability );

		for ( unsigned int ui = 0; ui < uiSize; ++ui )
		{
			m_vectFileAttributes[ ui ]->ToXML( strXML );
		}

		strXML += XML::MakeCloseXmlElementWithChildren( XML::enCapability );
	}
}

void AtlasRequire::FileCapability::Merge( const AtlasRequire::Capability& other )
{
	if ( this != &other )
	{
		Capability::Merge( other );

		const FileCapability* pother = dynamic_cast< const FileCapability* >( &other );
	
		if ( 0 != pother )
		{
			const unsigned int uiSize = m_vectFileAttributes.size( );
			const unsigned int uiSizeOther = pother->m_vectFileAttributes.size( );

			if ( ( uiSize > 0 ) && ( uiSizeOther > 0 ) )
			{
				map< string, unsigned int > mapVect;
		
				for ( unsigned int ui = 0; ui < uiSize; ++ui )
				{
					mapVect.insert( make_pair( ( string ) *( m_vectFileAttributes[ ui ] ), ui ) );
				}
		
				map< string, unsigned int >::const_iterator it;
				const map< string, unsigned int >::const_iterator itEnd = mapVect.end( );
		
				// If only in other, copy
				for ( unsigned int ui = 0; ui < uiSizeOther; ++ui )
				{
					it = mapVect.find( ( string ) *( pother->m_vectFileAttributes[ ui ] ) );
		
					if ( itEnd == it )
					{
						const FileAttributes* pFileAttributesOther = pother->m_vectFileAttributes[ ui ];
						FileAttributes* pFileAttributes = 0;

						try
						{
							pFileAttributes = new FileAttributes( *( pFileAttributesOther ) );
						}
						catch( ... )
						{
							throw Exception( Exception::eFailedToCreateFileAttributesObject, __FILE__, __FUNCTION__, __LINE__ );
						}
			
						m_vectFileAttributes.push_back( pFileAttributes );
					}
				}
			}
			else if ( uiSizeOther > 0 )
			{
				for ( unsigned int ui = 0; ui < uiSizeOther; ++ui )
				{
					const FileAttributes* pFileAttributesOther = pother->m_vectFileAttributes[ ui ];

					FileAttributes* pFileAttributes = 0;

					try
					{
						pFileAttributes = new FileAttributes( *( pFileAttributesOther ) );
					}
					catch( ... )
					{
						throw Exception( Exception::eFailedToCreateFileAttributesObject, __FILE__, __FUNCTION__, __LINE__ );
					}
		
					m_vectFileAttributes.push_back( pFileAttributes );
				}
			}
		}
	}
}

void AtlasRequire::FileCapability::Process( const Lookup* pLookup )
{
	if ( !m_bProcessed )
	{
		const unsigned int uiAttributes = m_vectAttributes.size( );
		
		if ( 0 == uiAttributes )
		{
			throw Exception( Exception::eInvalidNumberOfAttributesForDeviceCapability, __FILE__, __FUNCTION__, __LINE__, m_strId );
		}

		FileAttributes* pFileAttributes = 0;

		try
		{
			pFileAttributes = new FileAttributes;
		}
		catch( ... )
		{
			throw Exception( Exception::eFailedToCreateFileAttributesObject, __FILE__, __FUNCTION__, __LINE__, m_strId );
		}

		m_vectFileAttributes.push_back( pFileAttributes );

		for ( unsigned int ui = 1; ui < uiAttributes; ++ui )
		{
			Atlas::eInputOutputAttribute eAttribute = Atlas::GetAtlasInputOutputAttributeEnum( m_vectAttributes[ ui ]->m_strValue );

			switch ( eAttribute )
			{
				case Atlas::eFILE_ORGANIZATION:
					++ui;
					if ( ui < uiAttributes )
					{
						pFileAttributes->m_eFileOrganization = Atlas::GetAtlasInputOutputAttributeEnum( m_vectAttributes[ ui ]->m_strValue );

						if ( Atlas::eUnknownInputOutputAttribute == pFileAttributes->m_eFileOrganization )
						{
							string strError( m_strId );
								
							strError += ": file organization: ";
							strError += m_vectAttributes[ ui ]->m_strValue;

							throw Exception( Exception::eUnknownFileOranizationForFileCapability, __FILE__, __FUNCTION__, __LINE__, m_strId );
						}
					}
					break;

				case Atlas::eFILE_FORM:
					++ui;
					if ( ui < uiAttributes )
					{
						pFileAttributes->m_eFileForm = Atlas::GetAtlasInputOutputAttributeEnum( m_vectAttributes[ ui ]->m_strValue );

						if ( Atlas::eUnknownInputOutputAttribute == pFileAttributes->m_eFileForm )
						{
							string strError( m_strId );
								
							strError += ": file form: ";
							strError += m_vectAttributes[ ui ]->m_strValue;

							throw Exception( Exception::eUnknownFileFormForFileCapability, __FILE__, __FUNCTION__, __LINE__, m_strId );
						}
					}
					break;

				case Atlas::eRECORD_TYPE:
					++ui;
					if ( ui < uiAttributes )
					{
						pFileAttributes->m_eRecordType = Atlas::GetAtlasInputOutputAttributeEnum( m_vectAttributes[ ui ]->m_strValue );

						if ( Atlas::eUnknownInputOutputAttribute == pFileAttributes->m_eRecordType )
						{
							string strError( m_strId );
								
							strError += ": file record type: ";
							strError += m_vectAttributes[ ui ]->m_strValue;

							throw Exception( Exception::eUnknownFileRecordTypeForFileCapability, __FILE__, __FUNCTION__, __LINE__, m_strId );
						}
					}
					break;

				case Atlas::eRECORD_LENGTH:
					++ui;
					if ( ui < uiAttributes )
					{
						if ( !AIXMLHelper::IsUnsignedWholeNumber( m_vectAttributes[ ui ]->m_strValue ) )
						{
							string strError( m_strId );
								
							strError += ": record length: ";
							strError += m_vectAttributes[ ui ]->m_strValue;
				
							throw Exception( Exception::eRecordLengthIsNotNumericForFileCapability, __FILE__, __FUNCTION__, __LINE__, strError );
						}

						pFileAttributes->m_RecordLength.Set( m_vectAttributes[ ui ]->m_strValue );

						++ui;
						if ( ui < uiAttributes )
						{
							pFileAttributes->m_RecordLength.SetUnitOfMeasure( NounModifier::GetAtlasUnitOfMeasureByAlasUnit( m_vectAttributes[ ui ]->m_strValue, true, m_strId, Exception::eUnknownDataTypeForFileCapability ) );
						}
					}
					break;

				default:
				{
					string strError( m_strId );
						
					strError += ": attribute: ";
					strError += m_vectAttributes[ ui ]->m_strValue;
		
					throw Exception( Exception::eUnexpectedAttributeForFileCapability, __FILE__, __FUNCTION__, __LINE__, strError );
				}
			}
		}
	}
}

void AtlasRequire::FileCapability::InitSignalComponents( void )
{
	// None
}

AtlasRequire::Capability& AtlasRequire::FileCapability::operator = ( const AtlasRequire::Capability& other )
{
	if ( this != &other )
	{
		Capability::operator = ( other );

		GarbageCollect( );

		const FileCapability* pother = dynamic_cast< const FileCapability* >( &other );
	
		if ( 0 != pother )
		{
			const unsigned int uiSize = pother->m_vectFileAttributes.size( );

			if ( uiSize > 0 )
			{
				m_vectFileAttributes.reserve( uiSize );

				for ( unsigned int ui = 0; ui < uiSize; ++ui )
				{
					const FileAttributes* pOtherFileAttributes = pother->m_vectFileAttributes[ ui ];
					FileAttributes* pFileAttributes = 0;
		
					if ( 0 != pOtherFileAttributes )
					{
						try
						{
							pFileAttributes = new FileAttributes;
						}
						catch( ... )
						{
							throw Exception( Exception::eFailedToCreateFileAttributesObject, __FILE__, __FUNCTION__, __LINE__ );
						}
	
						*( pFileAttributes ) = *( pOtherFileAttributes );
					}
		
					m_vectFileAttributes.push_back( pFileAttributes );
				}
			}
		}
	}

	return *this;
}

AtlasRequire::Capability& AtlasRequire::VideoCapability::operator = ( const AtlasRequire::Capability& other )
{
	if ( this != &other )
	{
		Capability::operator = ( other );

		const VideoCapability* pother = dynamic_cast< const VideoCapability* >( &other );
	
		if ( 0 != pother )
		{
			GarbageCollect( );

			if ( 0 != pother->m_pVideoHorizontalTiming )
			{
				try
				{
					m_pVideoHorizontalTiming = new VideoHorizontalTiming( *( pother->m_pVideoHorizontalTiming ) );
				}
				catch( ... )
				{
					throw Exception( Exception::eFailedToCreateVideoObject, __FILE__, __FUNCTION__, __LINE__ );
				}
			}

			if ( 0 != pother->m_pVideoVerticalTiming )
			{
				try
				{
					m_pVideoVerticalTiming = new VideoVerticalTiming( *( pother->m_pVideoVerticalTiming ) );
				}
				catch( ... )
				{
					throw Exception( Exception::eFailedToCreateVideoObject, __FILE__, __FUNCTION__, __LINE__ );
				}
			}

			if ( 0 != pother->m_pVideoSync )
			{
				try
				{
					m_pVideoSync = new VideoSync( *( pother->m_pVideoSync ) );
				}
				catch( ... )
				{
					throw Exception( Exception::eFailedToCreateVideoObject, __FILE__, __FUNCTION__, __LINE__ );
				}
			}

			if ( 0 != pother->m_pVideoSyncPolarity )
			{
				try
				{
					m_pVideoSyncPolarity = new VideoSyncPolarity( *( pother->m_pVideoSyncPolarity ) );
				}
				catch( ... )
				{
					throw Exception( Exception::eFailedToCreateVideoObject, __FILE__, __FUNCTION__, __LINE__ );
				}
			}

			if ( 0 != pother->m_pVideoVideo )
			{
				try
				{
					m_pVideoVideo = new VideoVideo( *( pother->m_pVideoVideo ) );
				}
				catch( ... )
				{
					throw Exception( Exception::eFailedToCreateVideoObject, __FILE__, __FUNCTION__, __LINE__ );
				}
			}

			if ( 0 != pother->m_pVideoImage )
			{
				try
				{
					m_pVideoImage = new VideoImage( *( pother->m_pVideoImage ) );
				}
				catch( ... )
				{
					throw Exception( Exception::eFailedToCreateVideoObject, __FILE__, __FUNCTION__, __LINE__ );
				}
			}

			if ( 0 != pother->m_pVideoDraw )
			{
				try
				{
					m_pVideoDraw = new VideoDraw( *( pother->m_pVideoDraw ) );
				}
				catch( ... )
				{
					throw Exception( Exception::eFailedToCreateVideoObject, __FILE__, __FUNCTION__, __LINE__ );
				}
			}
		}
	}

	return *this;
}

void AtlasRequire::DeviceCapability::Merge( const AtlasRequire::Capability& other )
{
	if ( this != &other )
	{
		Capability::Merge( other );

		const DeviceCapability* pother = dynamic_cast< const DeviceCapability* >( &other );
	
		if ( 0 != pother )
		{
			m_LineLength.ReplaceIfLarger( pother->m_LineLength );
			m_PageSize.ReplaceIfLarger( pother->m_PageSize );

			if ( !m_bHardCopy )
			{
				m_bHardCopy = pother->m_bHardCopy;
			}
		}
	}
}

AtlasRequire::Capability& AtlasRequire::DeviceCapability::operator = ( const AtlasRequire::Capability& other )
{
	if ( this != &other )
	{
		Capability::operator = ( other );

		const DeviceCapability* pother = dynamic_cast< const DeviceCapability* >( &other );
	
		if ( 0 != pother )
		{
			m_LineLength	= pother->m_LineLength;
			m_PageSize		= pother->m_PageSize;
			m_bHardCopy		= pother->m_bHardCopy;
		}
	}

	return *this;
}

void AtlasRequire::DeviceCapability::ToXML( string& strXML ) const
{
	strXML += XML::MakeOpenXmlElementWithChildren( XML::enCapability );

	strXML += XML::MakeXmlElementNoChildren( XML::enLineLength, m_LineLength.ToXML( ) );
	strXML += XML::MakeXmlElementNoChildren( XML::enPageSize, m_PageSize.ToXML( ) );

	if ( m_bHardCopy )
	{
		strXML += XML::MakeXmlElementNoChildren( XML::enHardCopy );
	}

	strXML += XML::MakeCloseXmlElementWithChildren( XML::enCapability );
}

void AtlasRequire::DeviceCapability::Process( const Lookup* pLookup )
{
	if ( !m_bProcessed )
	{
		const unsigned int uiAttributes = m_vectAttributes.size( );
		
		if ( 0 == uiAttributes )
		{
			throw Exception( Exception::eInvalidNumberOfAttributesForDeviceCapability, __FILE__, __FUNCTION__, __LINE__, m_strId );
		}

		for ( unsigned int ui = 1; ui < uiAttributes; ++ui )
		{
			Atlas::eInputOutputAttribute eAttribute = Atlas::GetAtlasInputOutputAttributeEnum( m_vectAttributes[ ui ]->m_strValue );

			switch ( eAttribute )
			{
				case Atlas::eLINE_LENGTH:
					++ui;
					if ( ui < uiAttributes )
					{
						if ( !AIXMLHelper::IsUnsignedWholeNumber( m_vectAttributes[ ui ]->m_strValue ) )
						{
							string strError( m_strId );
								
							strError += ": line length: ";
							strError += m_vectAttributes[ ui ]->m_strValue;
				
							throw Exception( Exception::eLineLengthIsNotNumericForDeviceCapability, __FILE__, __FUNCTION__, __LINE__, strError );
						}

						m_LineLength.Set( m_vectAttributes[ ui ]->m_strValue );

						++ui;
						if ( ui < uiAttributes )
						{
							m_LineLength.SetUnitOfMeasure( NounModifier::GetAtlasUnitOfMeasureByAlasUnit( m_vectAttributes[ ui ]->m_strValue, true, m_strId, Exception::eUnknownDataTypeForDeviceCapability ) );
						}
					}
					break;

				case Atlas::ePAGE_SIZE:
					++ui;
					if ( ui < uiAttributes )
					{
						if ( !AIXMLHelper::IsUnsignedWholeNumber( m_vectAttributes[ ui ]->m_strValue ) )
						{
							string strError( m_strId );
								
							strError += ": page size: ";
							strError += m_vectAttributes[ ui ]->m_strValue;
				
							throw Exception( Exception::ePageSizeIsNotNumericForDeviceCapability, __FILE__, __FUNCTION__, __LINE__, strError );
						}

						m_PageSize.Set( m_vectAttributes[ ui ]->m_strValue );

						++ui;
						if ( ui < uiAttributes )
						{
							m_PageSize.SetUnitOfMeasure( NounModifier::GetAtlasUnitOfMeasureByAlasUnit( m_vectAttributes[ ui ]->m_strValue, true, m_strId, Exception::eUnknownDataTypeForDeviceCapability ) );
						}
					}
					break;

				case Atlas::eHARD_COPY:
					m_bHardCopy = true;
					break;

				default:
				{
					string strError( m_strId );
						
					strError += ": attribute: ";
					strError += m_vectAttributes[ ui ]->m_strValue;
		
					throw Exception( Exception::eUnexpectedAttributeForDeviceCapability, __FILE__, __FUNCTION__, __LINE__, strError );
				}
			}
		}
	}
}

void AtlasRequire::DeviceCapability::InitSignalComponents( void )
{
	// None
}

void AtlasRequire::Capability::Merge( const AtlasRequire::Capability& other )
{
	if ( this != &other )
	{
		Range::MergeSignalRanges( m_vectRanges, other.m_vectRanges );
		SettingValues::MergeSignalSettings( m_vectSettingsValues, other.m_vectSettingsValues );
		NounModifier::MergeAtlasSignalComponents( m_vectAtlasNounMod, other.m_vectAtlasNounMod );
		NounModifier::MergeAtlasSignalComponents( m_vectAtlasNounModFunctions, other.m_vectAtlasNounModFunctions );
		NounModifier::MergeSignalNumbers( m_vectMaximums, other.m_vectMaximums, true );

		if ( ( 0 != m_pCoupling ) && ( 0 != other.m_pCoupling ) )
		{
			m_pCoupling->Merge( *( other.m_pCoupling ) );
		}
		else if ( 0 != other.m_pCoupling )
		{
			try
			{
				m_pCoupling = new Coupling( *( other.m_pCoupling ) );
			}
			catch( ... )
			{
				throw Exception( Exception::eFailedToCreateCouplingObject, __FILE__, __FUNCTION__, __LINE__ );
			}
		}

		if ( ( 0 != m_pCouplingRef ) && ( 0 != other.m_pCouplingRef ) )
		{
			m_pCouplingRef->Merge( *( other.m_pCouplingRef ) );
		}
		else if ( 0 != other.m_pCouplingRef )
		{
			try
			{
				m_pCouplingRef = new Coupling( *( other.m_pCouplingRef ) );
			}
			catch( ... )
			{
				throw Exception( Exception::eFailedToCreateCouplingObject, __FILE__, __FUNCTION__, __LINE__ );
			}
		}

		if ( ( 0 != m_pCirculate ) && ( 0 != other.m_pCirculate ) )
		{
			m_pCirculate->Merge( *( other.m_pCirculate ) );
		}
		else if ( 0 != other.m_pCirculate )
		{
			try
			{
				m_pCirculate = new Circulate( *( other.m_pCirculate ) );
			}
			catch( ... )
			{
				throw Exception( Exception::eFailedToCreateCirculateObject, __FILE__, __FUNCTION__, __LINE__ );
			}
		}
	}
}

AtlasRequire::Capability& AtlasRequire::Capability::operator = ( const AtlasRequire::Capability& other )
{
	if ( this != &other )
	{
		AtlasAttributes::operator = ( other );

		GarbageCollect( );

		m_vectAtlasNounMod = other.m_vectAtlasNounMod;
		m_vectAtlasNounModFunctions = other.m_vectAtlasNounModFunctions;
		m_eNoun = other.m_eNoun;

		unsigned int uiSize = other.m_vectRanges.size( );
		if ( uiSize > 0 )
		{
			m_vectRanges.reserve( uiSize );

			for ( unsigned int ui = 0; ui < uiSize; ++ui )
			{
				const pair< Atlas::AtlasSignalComponent, Range* >& prOther = other.m_vectRanges[ ui ];
				Range* pRange = 0;

				try
				{
					pRange = new Range( *( prOther.second ) );
				}
				catch( ... )
				{
					throw Exception( Exception::eFailedToCreateRangeObject, __FILE__, __FUNCTION__, __LINE__ );
				}
	
				m_vectRanges.push_back( make_pair( prOther.first, pRange ) );
			}
		}

		uiSize = other.m_vectSettingsValues.size( );
		if ( uiSize > 0 )
		{
			m_vectSettingsValues.reserve( uiSize );

			for ( unsigned int ui = 0; ui < uiSize; ++ui )
			{
				const pair< Atlas::AtlasSignalComponent, SettingValues* >& prOther = other.m_vectSettingsValues[ ui ];
				SettingValues* pSettingValues = 0;

				try
				{
					pSettingValues = new SettingValues( *( prOther.second ) );
				}
				catch( ... )
				{
					throw Exception( Exception::eFailedToCreateSettingsValuesObject, __FILE__, __FUNCTION__, __LINE__ );
				}
	
				m_vectSettingsValues.push_back( make_pair( prOther.first, pSettingValues ) );
			}
		}

		uiSize = other.m_vectMaximums.size( );
		if ( uiSize > 0 )
		{
			m_vectMaximums.reserve( uiSize );

			for ( unsigned int ui = 0; ui < uiSize; ++ui )
			{
				const pair< Atlas::AtlasSignalComponent, Atlas::AtlasNumber* >& prOther = other.m_vectMaximums[ ui ];
				Atlas::AtlasNumber* pNumber = 0;

				try
				{
					pNumber = new Atlas::AtlasNumber( *( prOther.second ) );
				}
				catch( ... )
				{
					throw Exception( Exception::eFailedToCreateNumberObject, __FILE__, __FUNCTION__, __LINE__ );
				}
	
				m_vectMaximums.push_back( make_pair( prOther.first, pNumber ) );
			}
		}

		if ( 0 != other.m_pCoupling )
		{
			try
			{
				m_pCoupling = new Coupling( *( other.m_pCoupling ) );
			}
			catch( ... )
			{
				throw Exception( Exception::eFailedToCreateCouplingObject, __FILE__, __FUNCTION__, __LINE__ );
			}
		}

		if ( 0 != other.m_pCouplingRef )
		{
			try
			{
				m_pCouplingRef = new Coupling( *( other.m_pCouplingRef ) );
			}
			catch( ... )
			{
				throw Exception( Exception::eFailedToCreateCouplingObject, __FILE__, __FUNCTION__, __LINE__ );
			}
		}

		if ( 0 != other.m_pCirculate )
		{
			try
			{
				m_pCirculate = new Circulate( *( other.m_pCirculate ) );
			}
			catch( ... )
			{
				throw Exception( Exception::eFailedToCreateCirculateObject, __FILE__, __FUNCTION__, __LINE__ );
			}
		}
	}

	return *this;
}

void AtlasRequire::Capability::ToXML( string& strXML ) const
{
	strXML += XML::MakeOpenXmlElementWithChildren( XML::enCapability );

	SettingValues::ToXML( strXML, m_vectSettingsValues );
	Range::ToXML( strXML, m_vectRanges );
	NounModifier::ToXML( strXML, m_vectAtlasNounModFunctions, XML::enModifierFunctions, XML::enModifierFunction );
	NounModifier::ToXML( strXML, m_vectMaximums, XML::enMaximums, XML::enMaximum );

	bool bNounModfiers = false;

	bNounModfiers = ( m_vectAtlasNounMod.size( ) > 0 );

	if ( 0 != m_pCoupling )
	{
		bNounModfiers = true;
	}
	if ( 0 != m_pCouplingRef )
	{
		bNounModfiers = true;
	}
	if ( 0 != m_pCirculate )
	{
		bNounModfiers = true;
	}

	if ( bNounModfiers )
	{
		strXML += XML::MakeOpenXmlElementWithChildren( XML::enNounModifiers );

		const unsigned int uiNounMods = m_vectAtlasNounMod.size( );

		if ( uiNounMods > 0 )
		{
			for ( unsigned int ui = 0; ui < uiNounMods; ++ui )
			{
				strXML += XML::MakeOpenXmlElementWithChildren( XML::enNounModifier );

				strXML += m_vectAtlasNounMod[ ui ].ToXML( );

				strXML += XML::MakeCloseXmlElementWithChildren( XML::enNounModifier );
			}
		}

		if ( 0 != m_pCoupling )
		{
			if ( m_pCoupling->m_bAC || m_pCoupling->m_bDC )
			{
				const Atlas::AtlasSignalComponent modifier( m_eNoun, Atlas::eCOUPLING );

				strXML += XML::MakeOpenXmlElementWithChildren( XML::enNounModifier );

				strXML += modifier.ToXML( );
	
				if ( m_pCoupling->m_bAC )
				{
					strXML += XML::MakeXmlElementNoChildren( XML::enAc );
				}

				if ( m_pCoupling->m_bDC )
				{
					strXML += XML::MakeXmlElementNoChildren( XML::enAc );
				}
	
				strXML += XML::MakeCloseXmlElementWithChildren( XML::enNounModifier );
			}
		}

		if ( 0 != m_pCouplingRef )
		{
			if ( m_pCouplingRef->m_bAC || m_pCouplingRef->m_bDC )
			{
				const Atlas::AtlasSignalComponent modifier( m_eNoun, Atlas::eCOUPLING_REF );

				strXML += XML::MakeOpenXmlElementWithChildren( XML::enNounModifier );
				strXML += modifier.ToXML( );
	
				if ( m_pCouplingRef->m_bAC )
				{
					strXML += XML::MakeXmlElementNoChildren( XML::enAc );
				}

				if ( m_pCouplingRef->m_bDC )
				{
					strXML += XML::MakeXmlElementNoChildren( XML::enDc );
				}
	
				strXML += XML::MakeCloseXmlElementWithChildren( XML::enNounModifier );
			}
		}

		if ( 0 != m_pCirculate )
		{
			if ( ( 0 != m_pCirculate->m_pCount ) || ( 0 != m_pCirculate->m_pbContinuous ) )
			{
				const Atlas::AtlasSignalComponent modifier( m_eNoun, Atlas::eCIRCULATE );

				strXML += XML::MakeOpenXmlElementWithChildren( XML::enNounModifier );
				strXML += modifier.ToXML( );
	
				if ( ( 0 != m_pCirculate->m_pCount ) )
				{
					strXML += XML::MakeXmlElementNoChildren( XML::enNumber, m_pCirculate->m_pCount->ToXML( ) );
				}

				if ( 0 != m_pCirculate->m_pbContinuous )
				{
					if ( *( m_pCirculate->m_pbContinuous ) )
					{
						strXML += XML::MakeXmlElementNoChildren( XML::enContinuous );
					}
				}
	
				strXML += XML::MakeCloseXmlElementWithChildren( XML::enNounModifier );
			}
		}

		strXML += XML::MakeCloseXmlElementWithChildren( XML::enNounModifiers );
	}

	strXML += XML::MakeCloseXmlElementWithChildren( XML::enCapability );
}

string AtlasRequire::Capability::ToSignalXML( const Atlas::AtlasSignalComponent& component ) const
{
	string strXML;
	const Range* pRange = 0;
	const SettingValues* pSettingValues = 0;
	const Atlas::AtlasNumber* pNumber = 0;
	const unsigned int uiRanges = m_vectRanges.size( );
	const unsigned int uiSettingsValues = m_vectSettingsValues.size( );
	const unsigned int uiMaximums = m_vectMaximums.size( );

	for ( unsigned int ui = 0; ui < uiRanges; ++ui )
	{
		const pair< Atlas::AtlasSignalComponent, Range* >& pr = m_vectRanges[ ui ];

		if ( pr.first == component )
		{
			pRange = pr.second;
			break;
		}
	}
	
	for ( unsigned int ui = 0; ui < uiSettingsValues; ++ui )
	{
		const pair< Atlas::AtlasSignalComponent, SettingValues* >& pr = m_vectSettingsValues[ ui ];

		if ( pr.first == component )
		{
			pSettingValues = pr.second;
			break;
		}
	}

	for ( unsigned int ui = 0; ui < uiMaximums; ++ui )
	{
		const pair< Atlas::AtlasSignalComponent, Atlas::AtlasNumber* >& pr = m_vectMaximums[ ui ];

		if ( pr.first == component )
		{
			pNumber = pr.second;
			break;
		}
	}

	if ( ( 0 != pRange ) || ( 0 != pSettingValues ) || ( 0 != pNumber ) )
	{
		if ( 0 != pRange )
		{
			strXML += XML::MakeOpenXmlElementWithChildren( XML::enRange );

			strXML += pRange->ToXML( );

			strXML += XML::MakeCloseXmlElementWithChildren( XML::enRange );
		}

		if ( 0 != pSettingValues )
		{
			strXML += XML::MakeOpenXmlElementWithChildren( XML::enSetting );

			pSettingValues->ToXML( strXML );

			strXML += XML::MakeCloseXmlElementWithChildren( XML::enSetting );
		}

		if ( 0 != pNumber )
		{
			strXML += XML::MakeXmlElementNoChildren( XML::enMaximum, pNumber->ToXML( ) );
		}
	}

	return strXML;
}

void AtlasRequire::Capability::Process( const Lookup* pLookup )
{
	if ( !m_bProcessed )
	{
		const unsigned int uiAttributes = m_vectAttributes.size( );
		
		if ( uiAttributes < 2 )
		{
			throw Exception( Exception::eInvalidNumberOfAttributesForCapability, __FILE__, __FUNCTION__, __LINE__, m_strId );
		}

		unsigned int uiPos = 1; 

		while ( uiPos < uiAttributes )
		{
			string strAtlasNounModifier( m_vectAttributes[ uiPos ]->m_strValue );

			Atlas::AtlasSignalComponent AtlasNM( Atlas::GetAtlasNounModifierEnum( strAtlasNounModifier ) );

			if ( !AtlasNM.IsValid( ) )
			{
				string strError( m_strId );
					
				strError += ": Atlas noun/modifier: ";
				strError += strAtlasNounModifier;
		
				throw Exception( Exception::eUnknownAtlasNounModifierForCapability, __FILE__, __FUNCTION__, __LINE__, strError );
			}

			++uiPos;

			AtlasNM.SetAtlasNoun( m_eNoun );

			if ( uiPos < uiAttributes )
			{
				const string& strWord = m_vectAttributes[ uiPos ]->m_strValue;

				if ( m_strRANGE == strWord )
				{
					Range* pRange = 0;

					try
					{
						pRange = new Range;
					}
					catch( ... )
					{
						string strError( m_strId );
		
						strError += ": capability range";
		
						throw Exception( Exception::eFailedToCreateRangeObject, __FILE__, __FUNCTION__, __LINE__, strError );
					}

					m_vectRanges.push_back( make_pair( AtlasNM, pRange ) );
		
					uiPos = pRange->Init( m_strId, m_vectAttributes, uiPos + 1  );
				}
				else if ( m_strMAX == strWord )
				{
					m_vectMaximums.push_back( make_pair( AtlasNM, NounModifier::GetAtlasNumber( m_strId, m_vectAttributes, ++uiPos ) ) );
				}
				else if ( AIXMLHelper::IsNumber( strWord ) )
				{
					SettingValues* pValues = 0;

					try
					{
						pValues = new SettingValues( );
					}
					catch( ... )
					{
						throw Exception( Exception::eFailedToCreateSettingsValuesObject, __FILE__, __FUNCTION__, __LINE__, m_strId );
					}

					m_vectSettingsValues.push_back( make_pair( AtlasNM, pValues ) );

					uiPos = pValues->Init( m_strId, m_vectAttributes, uiPos );
				}
				else
				{
					switch ( AtlasNM.GetAtlasNounModifier( ) )
					{
						case Atlas::eCIRCULATE:
						{
							if ( 0 != m_pCirculate )
							{
								throw Exception( Exception::ePointerAlreadyUsed, __FILE__, __FUNCTION__, __LINE__, m_strId );
							}

							try
							{
								m_pCirculate = new Circulate;
							}
							catch( ... )
							{
								string strError( m_strId );
				
								strError += ": capability Circulate";
				
								throw Exception( Exception::eFailedToCreateCirculateObject, __FILE__, __FUNCTION__, __LINE__, strError );
							}
		
							uiPos = m_pCirculate->Init( m_strId, m_vectAttributes, uiPos );
						}
						break;

						case Atlas::eSWEEP_TYPE:
						case Atlas::eREF_SOURCE:
						{
							Atlas::eAtlasFunction eFunction = Atlas::GetAtlasFunctionEnum( m_vectAttributes[ uiPos ]->m_strValue );

							if ( Atlas::eUnknownAtlasFunction == eFunction )
							{
								string strError( m_strId );
				
								strError += ": ";
								strError += m_vectAttributes[ uiPos ]->m_strValue;
				
								throw Exception( Exception::eUnknownAtlasFunctionForCapability, __FILE__, __FUNCTION__, __LINE__, strError );
							}

							AtlasNM.SetAtlasFunction( eFunction );

							m_vectAtlasNounModFunctions.push_back( AtlasNM );
							++uiPos;

							if ( uiPos < uiAttributes )
							{
								// Handle bug in CASS extension?
								//
								// Where conflicting function names are found...
								// Examples
								// REF-SOURCE INT EXT,
								// SWEEP-TYPE LIN LOG,

								eFunction = Atlas::GetAtlasFunctionEnum( m_vectAttributes[ uiPos ]->m_strValue );

								if ( Atlas::eUnknownAtlasFunction != eFunction )
								{
									if ( ( Atlas::eINTFunction == eFunction ) 
										|| ( Atlas::eEXT == eFunction )
										|| ( Atlas::eLIN == eFunction )											
										|| ( Atlas::eLOG == eFunction ))
									{
										++uiPos;
									}
								}
							}
						}
						break;

						case Atlas::eCOUPLING_REF:
						case Atlas::eCOUPLING:
						{
							Coupling** ppCoupling = ( Atlas::eCOUPLING_REF == AtlasNM.GetAtlasNounModifier( ) ? &m_pCouplingRef : &m_pCoupling );

							try
							{
								*( ppCoupling ) = new Coupling;
							}
							catch( ... )
							{
								string strError( m_strId );
				
								strError += ": capability coupling";
				
								throw Exception( Exception::eFailedToCreateCouplingObject, __FILE__, __FUNCTION__, __LINE__, strError );
							}

							uiPos = ( *( ppCoupling ) )->Init( m_strId, m_vectAttributes, uiPos );
						}
						break;

						default:
						{
							m_vectAtlasNounMod.push_back( AtlasNM );
						}
						break;
					}
				}
			}
		}

		m_bProcessed = true;
	}
}

bool AtlasRequire::Capability::HasNounModifier( const Atlas::eAtlasNounModifier eModifier ) const
{
	bool bHasNounModifier = false;

	if ( Range::HasNounModifier( eModifier, m_vectRanges ) )
	{
		bHasNounModifier = true;
	}
	else if ( SettingValues::HasNounModifier( eModifier, m_vectSettingsValues ) )
	{
		bHasNounModifier = true;
	}
	else if ( NounModifier::HasNounModifier( eModifier, m_vectAtlasNounMod ) )
	{
		bHasNounModifier = true;
	}
	else if ( NounModifier::HasNounModifier( eModifier, m_vectAtlasNounModFunctions ) )
	{
		bHasNounModifier = true;
	}
	else if ( NounModifier::HasNounModifier( eModifier, m_vectMaximums ) )
	{
		bHasNounModifier = true;
	}
	else if ( ( 0 != m_pCoupling ) && ( Atlas::eCOUPLING == eModifier ) )
	{
		bHasNounModifier = true;
	}
	else if ( ( 0 != m_pCouplingRef ) && ( Atlas::eCOUPLING_REF == eModifier ) )
	{
		bHasNounModifier = true;
	}
	else if ( ( 0 != m_pCirculate ) && ( Atlas::eCIRCULATE == eModifier) )
	{
		bHasNounModifier = true;
	}

	return bHasNounModifier;
}

void AtlasRequire::Capability::InitSignalComponents( void )
{
	Range::InitSignalComponents( m_vectRanges );
	SettingValues::InitSignalComponents( m_vectSettingsValues );
	NounModifier::InitSignalComponents( m_vectAtlasNounMod );
	NounModifier::InitSignalComponents( m_vectAtlasNounModFunctions );
	NounModifier::InitSignalComponents( m_vectMaximums );
}

void AtlasRequire::Limit::ToXML( string& strXML ) const
{
	strXML += XML::MakeOpenXmlElementWithChildren( XML::enLimit );
	Range::ToXML( strXML, m_vectRanges );
	NounModifier::ToXML( strXML, m_vectMaximums, XML::enMaximums, XML::enMaximum );
	strXML += XML::MakeCloseXmlElementWithChildren( XML::enLimit );
}

string AtlasRequire::Limit::ToSignalXML( const Atlas::AtlasSignalComponent& component ) const
{
	string strXML;
	const Range* pRange = 0;
	const Atlas::AtlasNumber* pNumber = 0;
	const unsigned int uiRanges = m_vectRanges.size( );
	const unsigned int uiMaximums = m_vectMaximums.size( );

	for ( unsigned int ui = 0; ui < uiRanges; ++ui )
	{
		const pair< Atlas::AtlasSignalComponent, Range* >& pr = m_vectRanges[ ui ];

		if ( pr.first == component )
		{
			pRange = pr.second;
			break;
		}
	}
	
	for ( unsigned int ui = 0; ui < uiMaximums; ++ui )
	{
		const pair< Atlas::AtlasSignalComponent, Atlas::AtlasNumber* >& pr = m_vectMaximums[ ui ];

		if ( pr.first == component )
		{
			pNumber = pr.second;
			break;
		}
	}

	if ( ( 0 != pRange ) || ( 0 != pNumber ) )
	{
		if ( 0 != pRange )
		{
			strXML += XML::MakeOpenXmlElementWithChildren( XML::enRange );

			strXML += pRange->ToXML( );

			strXML += XML::MakeCloseXmlElementWithChildren( XML::enRange );
		}

		if ( 0 != pNumber )
		{
			strXML += XML::MakeXmlElementNoChildren( XML::enMaximum, pNumber->ToXML( ) );
		}
	}

	return strXML;
}

bool AtlasRequire::Limit::HasNounModifier( const Atlas::eAtlasNounModifier eModifier ) const
{
	bool bHasNounModifier = false;

	if ( Range::HasNounModifier( eModifier, m_vectRanges ) )
	{
		bHasNounModifier = true;
	}
	else if ( NounModifier::HasNounModifier( eModifier, m_vectMaximums ) )
	{
		bHasNounModifier = true;
	}

	return bHasNounModifier;
}

void AtlasRequire::Limit::Process( const Lookup* pLookup )
{
	if ( !m_bProcessed )
	{
		const unsigned int uiAttributes = m_vectAttributes.size( );
		
		if ( uiAttributes < 2 )
		{
			throw Exception( Exception::eInvalidNumberOfAttributesForControl, __FILE__, __FUNCTION__, __LINE__, m_strId );
		}

		unsigned int uiPos = 1; 
		string strNounModifierSuffix;

		while ( uiPos < uiAttributes )
		{
			string strAtlasNounModifier( m_vectAttributes[ uiPos ]->m_strValue );

			Atlas::AtlasSignalComponent AtlasNM( Atlas::GetAtlasNounModifierEnum( strAtlasNounModifier ) );

			if ( !AtlasNM.IsValid( ) )
			{
				string strError( m_strId );
					
				strError += ": Atlas noun/modifier: ";
				strError += strAtlasNounModifier;
		
				throw Exception( Exception::eUnknownAtlasNounModifierForControl, __FILE__, __FUNCTION__, __LINE__, strError );
			}

			++uiPos;

			AtlasNM.SetAtlasNoun( m_eNoun );

			if ( uiPos < uiAttributes )
			{
				const string& strWord = m_vectAttributes[ uiPos ]->m_strValue;

				if ( m_strRANGE == strWord )
				{
					Range* pRange = 0;

					try
					{
						pRange = new Range;
					}
					catch( ... )
					{
						string strError( m_strId );
		
						strError += ": limit range";
		
						throw Exception( Exception::eFailedToCreateRangeObject, __FILE__, __FUNCTION__, __LINE__, strError );
					}

					m_vectRanges.push_back( make_pair( AtlasNM, pRange ) );
		
					uiPos = pRange->Init( m_strId, m_vectAttributes, uiPos + 1 );
				}
				else if ( m_strMAX == strWord )
				{
					m_vectMaximums.push_back( make_pair( AtlasNM, NounModifier::GetAtlasNumber( m_strId, m_vectAttributes, ++uiPos ) ) );
				}
			}
		}

		m_bProcessed = true;
	}
}

void AtlasRequire::Limit::InitSignalComponents( void )
{
	Range::InitSignalComponents( m_vectRanges );
	NounModifier::InitSignalComponents( m_vectMaximums );
}

void AtlasRequire::Control::ToXML( string& strXML ) const
{
	strXML += XML::MakeOpenXmlElementWithChildren( XML::enControl );
	
	Range::ToXML( strXML, m_vectRanges );
	SettingValues::ToXML( strXML, m_vectSettingsValues );
	NounModifier::ToXML( strXML, m_vectAtlasNounModFunctions, XML::enModifiers, XML::enModifier );

	bool bNounModfiers = false;

	bNounModfiers = ( m_vectAtlasNounMod.size( ) > 0 );

	if ( 0 != m_pstrTrigOutDrive )
	{
		bNounModfiers = true;
	}
	if ( 0 != m_pSourceIndentifier )
	{
		bNounModfiers = true;
	}
	if ( 0 != m_pCoupling )
	{
		bNounModfiers = true;
	}
	if ( 0 != m_pMode )
	{
		bNounModfiers = true;
	}
	if ( 0 != m_pCirculate )
	{
		bNounModfiers = true;
	}

	if ( bNounModfiers )
	{
		strXML += XML::MakeOpenXmlElementWithChildren( XML::enNounModifiers );

		const unsigned int uiNounMods = m_vectAtlasNounMod.size( );

		if ( uiNounMods > 0 )
		{
			for ( unsigned int ui = 0; ui < uiNounMods; ++ui )
			{
				strXML += XML::MakeOpenXmlElementWithChildren( XML::enNounModifier );

				m_vectAtlasNounMod[ ui ].ToXML( );

				strXML += XML::MakeCloseXmlElementWithChildren( XML::enNounModifier );
			}
		}

		if ( 0 != m_pstrTrigOutDrive )
		{
			const Atlas::AtlasSignalComponent modifier( m_eNoun, Atlas::eTRIG_OUT_DRIVE );

			strXML += XML::MakeOpenXmlElementWithChildren( XML::enNounModifiers );
			strXML += modifier.ToXML( );
			strXML += XML::MakeXmlElementNoChildren( XML::GetElementNameEnum( *m_pstrTrigOutDrive ) );
			strXML += XML::MakeCloseXmlElementWithChildren( XML::enNounModifiers );
		}

		if ( 0 != m_pSourceIndentifier )
		{
			if ( m_pSourceIndentifier->m_bChannelA || m_pSourceIndentifier->m_bChannelB )
			{
				const Atlas::AtlasSignalComponent modifier( m_eNoun, Atlas::eSOURCE_IDENTIFIER );

				strXML += XML::MakeOpenXmlElementWithChildren( XML::enNounModifier );
				strXML += modifier.ToXML( );
	
				if ( m_pSourceIndentifier->m_bChannelA )
				{
					strXML += XML::MakeXmlElementNoChildren( XML::enChannelA );
				}

				if ( m_pSourceIndentifier->m_bChannelB )
				{
					strXML += XML::MakeXmlElementNoChildren( XML::enChannelB );
				}

				strXML += XML::MakeCloseXmlElementWithChildren( XML::enNounModifier );
			}
		}

		if ( 0 != m_pCoupling )
		{
			if ( m_pCoupling->m_bAC || m_pCoupling->m_bDC )
			{
				const Atlas::AtlasSignalComponent modifier( m_eNoun, Atlas::eCOUPLING );

				strXML += XML::MakeOpenXmlElementWithChildren( XML::enNounModifier );
				strXML += modifier.ToXML( );
	
				if ( m_pCoupling->m_bAC )
				{
					strXML += XML::MakeXmlElementNoChildren( XML::enAc );
				}

				if ( m_pCoupling->m_bDC )
				{
					strXML += XML::MakeXmlElementNoChildren( XML::enDc );
				}
	
				strXML += XML::MakeCloseXmlElementWithChildren( XML::enNounModifier );
			}
		}

		if ( 0 != m_pMode )
		{
			const unsigned uiSize = m_pMode->m_vectMode.size( );

			if ( uiSize > 0 )
			{
				const Atlas::AtlasSignalComponent modifier( m_eNoun, Atlas::eMODE );

				strXML += XML::MakeOpenXmlElementWithChildren( XML::enNounModifier );
				strXML += modifier.ToXML( );

				NounModifier::ToXML( strXML, m_pMode->m_vectMode, XML::enModifierFunctions, XML::enModifierFunction );

				strXML += XML::MakeCloseXmlElementWithChildren( XML::enNounModifier );
			}
		}

		if ( 0 != m_pCirculate )
		{
			if ( ( 0 != m_pCirculate->m_pCount ) || ( 0 != m_pCirculate->m_pbContinuous ) )
			{
				const Atlas::AtlasSignalComponent modifier( m_eNoun, Atlas::eCIRCULATE );

				strXML += XML::MakeOpenXmlElementWithChildren( XML::enNounModifier );
				strXML += modifier.ToXML( );
	
				if ( ( 0 != m_pCirculate->m_pCount ) )
				{
					strXML += XML::MakeXmlElementNoChildren( XML::enNumber, m_pCirculate->m_pCount->ToXML( ) );
				}

				if ( 0 != m_pCirculate->m_pbContinuous )
				{
					if ( *( m_pCirculate->m_pbContinuous ) )
					{
						strXML += XML::MakeXmlElementNoChildren( XML::enContinuous );
					}
				}
	
				strXML += XML::MakeCloseXmlElementWithChildren( XML::enNounModifier );
			}
		}

		strXML += XML::MakeCloseXmlElementWithChildren( XML::enNounModifiers );
	}

	strXML += XML::MakeCloseXmlElementWithChildren( XML::enControl );
}

string AtlasRequire::Control::ToSignalXML( const Atlas::AtlasSignalComponent& component ) const
{
	string strXML;
	const Range* pRange = 0;
	const SettingValues* pSettingValues = 0;
	unsigned int uiRanges = m_vectRanges.size( );
	unsigned int uiSettingsValues = m_vectSettingsValues.size( );

	for ( unsigned int ui = 0; ui < uiRanges; ++ui )
	{
		const pair< Atlas::AtlasSignalComponent, Range* >& pr = m_vectRanges[ ui ];

		if ( pr.first == component )
		{
			pRange = pr.second;
			break;
		}
	}
	
	for ( unsigned int ui = 0; ui < uiSettingsValues; ++ui )
	{
		const pair< Atlas::AtlasSignalComponent, SettingValues* >& pr = m_vectSettingsValues[ ui ];

		if ( pr.first == component )
		{
			pSettingValues = pr.second;
			break;
		}
	}

	if ( ( 0 != pRange ) || ( 0 != pSettingValues ) )
	{
		if ( 0 != pRange )
		{
			strXML += XML::MakeOpenXmlElementWithChildren( XML::enRange );

			strXML += pRange->ToXML( );

			strXML += XML::MakeCloseXmlElementWithChildren( XML::enRange );
		}

		if ( 0 != pSettingValues )
		{
			strXML += XML::MakeOpenXmlElementWithChildren( XML::enSetting );

			pSettingValues->ToXML( strXML );

			strXML += XML::MakeCloseXmlElementWithChildren( XML::enSetting );
		}
	}

	return strXML;
}

void AtlasRequire::Control::Process( const Lookup* pLookup )
{
	if ( !m_bProcessed )
	{
		const unsigned int uiAttributes = m_vectAttributes.size( );
		
		if ( uiAttributes < 2 )
		{
			throw Exception( Exception::eInvalidNumberOfAttributesForControl, __FILE__, __FUNCTION__, __LINE__, m_strId );
		}

		unsigned int uiPos = 1; 

		while ( uiPos < uiAttributes )
		{
			string strAtlasNounModifier( m_vectAttributes[ uiPos ]->m_strValue );

			Atlas::AtlasSignalComponent AtlasNM( Atlas::GetAtlasNounModifierEnum( strAtlasNounModifier ) );

			if ( !AtlasNM.IsValid( ) )
			{
				string strError( m_strId );
					
				strError += ": Atlas noun/modifier: ";
				strError += strAtlasNounModifier;
		
				throw Exception( Exception::eUnknownAtlasNounModifierForControl, __FILE__, __FUNCTION__, __LINE__, strError );
			}

			++uiPos;

			AtlasNM.SetAtlasNoun( m_eNoun );

			if ( uiPos < uiAttributes )
			{
				bool bRangeWithoutRangeKeyword = false;
				const string& strWord = m_vectAttributes[ uiPos ]->m_strValue;

				if ( Atlas::eDELAY == AtlasNM.GetAtlasNounModifier( ) )
				{
					bRangeWithoutRangeKeyword = true;
				}

				if ( ( m_strRANGE == strWord ) || bRangeWithoutRangeKeyword )
				{
					Range* pRange = 0;

					try
					{
						pRange = new Range;
					}
					catch( ... )
					{
						string strError( m_strId );
		
						strError += ": control range";
		
						throw Exception( Exception::eFailedToCreateRangeObject, __FILE__, __FUNCTION__, __LINE__, strError );
					}

					m_vectRanges.push_back( make_pair( AtlasNM, pRange ) );
		
					uiPos = pRange->Init( m_strId, m_vectAttributes, uiPos + 1 );
				}
				else if ( AIXMLHelper::IsNumber( strWord ) )
				{
					SettingValues* pValues = 0;

					try
					{
						pValues = new SettingValues( );
					}
					catch( ... )
					{
						throw Exception( Exception::eFailedToCreateSettingsValuesObject, __FILE__, __FUNCTION__, __LINE__, m_strId );
					}

					m_vectSettingsValues.push_back( make_pair( AtlasNM, pValues ) );

					uiPos = pValues->Init( m_strId, m_vectAttributes, uiPos );
				}
				else
				{
					switch ( AtlasNM.GetAtlasNounModifier( ) )
					{
						case Atlas::eREF_SOURCE:
							{
								Atlas::eAtlasFunction eFunction = Atlas::GetAtlasFunctionEnum( m_vectAttributes[ uiPos ]->m_strValue );

								if ( Atlas::eUnknownAtlasFunction == eFunction )
								{
									string strError( m_strId );
					
									strError += ": ";
									strError += m_vectAttributes[ uiPos ]->m_strValue;
					
									throw Exception( Exception::eUnknownAtlasFunctionForCapability, __FILE__, __FUNCTION__, __LINE__, strError );
								}

								AtlasNM.SetAtlasFunction( eFunction );

								m_vectAtlasNounModFunctions.push_back( AtlasNM );
								++uiPos;

								if ( uiPos < uiAttributes )
								{
									// Handle bug in CASS extension?
									//
									// Where both function names are found...
									// Example: REF-SOURCE INT EXT,

									eFunction = Atlas::GetAtlasFunctionEnum( m_vectAttributes[ uiPos ]->m_strValue );
	
									if ( ( Atlas::eINTFunction == eFunction ) || ( Atlas::eEXT == eFunction ) )
									{
										++uiPos;
									}
								}
							}
							break;

						case Atlas::eCIRCULATE:
						{
							if ( 0 != m_pCirculate )
							{
								throw Exception( Exception::ePointerAlreadyUsed, __FILE__, __FUNCTION__, __LINE__, m_strId );
							}

							try
							{
								m_pCirculate = new Circulate;
							}
							catch( ... )
							{
								string strError( m_strId );
				
								strError += ": control Circulate";
				
								throw Exception( Exception::eFailedToCreateCirculateObject, __FILE__, __FUNCTION__, __LINE__, strError );
							}
		
							uiPos = m_pCirculate->Init( m_strId, m_vectAttributes, uiPos );
						}
						break;

						case Atlas::eMODE:
						{
							if ( 0 != m_pMode )
							{
								throw Exception( Exception::ePointerAlreadyUsed, __FILE__, __FUNCTION__, __LINE__, m_strId );
							}

							try
							{
								m_pMode = new Mode;
							}
							catch( ... )
							{
								string strError( m_strId );
				
								strError += ": control Mode";
				
								throw Exception( Exception::eFailedToCreateModeObject, __FILE__, __FUNCTION__, __LINE__, strError );
							}

							m_pMode->m_eNoun = m_eNoun;
		
							uiPos = m_pMode->Init( m_strId, m_vectAttributes, uiPos );
						}
						break;

						case Atlas::eCOUPLING:
						{
							if ( 0 != m_pCoupling )
							{
								throw Exception( Exception::ePointerAlreadyUsed, __FILE__, __FUNCTION__, __LINE__, m_strId );
							}

							try
							{
								m_pCoupling = new Coupling;
							}
							catch( ... )
							{
								string strError( m_strId );
				
								strError += ": control coupling";
				
								throw Exception( Exception::eFailedToCreateCouplingObject, __FILE__, __FUNCTION__, __LINE__, strError );
							}
		
							uiPos = m_pCoupling->Init( m_strId, m_vectAttributes, uiPos );
						}
						break;

						case Atlas::eTRIG_OUT_DRIVE:
						{
							if ( 0 != m_pstrTrigOutDrive )
							{
								throw Exception( Exception::ePointerAlreadyUsed, __FILE__, __FUNCTION__, __LINE__, m_strId );
							}

							try
							{
								m_pstrTrigOutDrive = new string( m_vectAttributes[ uiPos ]->m_strValue );
							}
							catch( ... )
							{
								throw Exception( Exception::eFailedToCreateStringObject, __FILE__, __FUNCTION__, __LINE__, m_strId );
							}
		
							++uiPos;
						}
						break;

						case Atlas::eSOURCE_IDENTIFIER:
						{
							if ( 0 != m_pSourceIndentifier )
							{
								throw Exception( Exception::ePointerAlreadyUsed, __FILE__, __FUNCTION__, __LINE__, m_strId );
							}

							try
							{
								m_pSourceIndentifier = new SourceIndentifier;
							}
							catch( ... )
							{
								throw Exception( Exception::eFailedToCreateStringObject, __FILE__, __FUNCTION__, __LINE__, m_strId );
							}

							uiPos = m_pSourceIndentifier->Init( m_strId, m_vectAttributes, uiPos );
						}
						break;

						default:
						{
							m_vectAtlasNounMod.push_back( AtlasNM );
						}
						break;
					}
				}
			}
		}

		m_bProcessed = true;
	}
}

bool AtlasRequire::Control::HasNounModifier( const Atlas::eAtlasNounModifier eModifier ) const
{
	bool bHasNounModifier = false;

	if ( Range::HasNounModifier( eModifier, m_vectRanges ) )
	{
		bHasNounModifier = true;
	}
	else if ( SettingValues::HasNounModifier( eModifier, m_vectSettingsValues ) )
	{
		bHasNounModifier = true;
	}
	else if ( NounModifier::HasNounModifier( eModifier, m_vectAtlasNounMod ) )
	{
		bHasNounModifier = true;
	}
	else if ( NounModifier::HasNounModifier( eModifier, m_vectAtlasNounModFunctions ) )
	{
		bHasNounModifier = true;
	}
	else if ( ( 0 != m_pstrTrigOutDrive ) && ( Atlas::eTRIG_OUT_DRIVE == eModifier ) )
	{
		bHasNounModifier = true;
	}
	else if ( ( 0 != m_pSourceIndentifier ) && ( Atlas::eSOURCE_IDENTIFIER == eModifier ) )
	{
		bHasNounModifier = true;
	}
	else if ( ( 0 != m_pCoupling ) && ( Atlas::eCOUPLING == eModifier ) )
	{
		bHasNounModifier = true;
	}
	else if ( ( 0 != m_pMode ) && ( Atlas::eMODE == eModifier ) )
	{
		bHasNounModifier = true;
	}
	else if ( ( 0 != m_pCirculate ) && ( Atlas::eCIRCULATE == eModifier ) )
	{
		bHasNounModifier = true;
	}

	return bHasNounModifier;
}

void AtlasRequire::Control::InitSignalComponents( void )
{
	Range::InitSignalComponents( m_vectRanges );
	SettingValues::InitSignalComponents( m_vectSettingsValues );
	NounModifier::InitSignalComponents( m_vectAtlasNounMod );
	NounModifier::InitSignalComponents( m_vectAtlasNounModFunctions );

	if ( 0 != m_pMode )
	{
		m_pMode->InitSignalComponents( );
	}
}

void AtlasRequire::Resource::ToXML( string& strXML ) const
{
	const unsigned int uiResourceInfo = m_vectResourceInfo.size( );

	if ( uiResourceInfo > 0 )
	{
		strXML += XML::MakeOpenXmlElementWithChildren( XML::enRequireTypes );

		for ( unsigned int ui = 0; ui < uiResourceInfo; ++ui )
		{
			const pair< Atlas::eAtlasResource, ResourceBase* >& pr = m_vectResourceInfo[ ui ];

			strXML += XML::MakeOpenXmlElementWithChildren( XML::enRequireType, XML::MakeXmlAttributeNameValue( XML::anType, Atlas::GetAtlasResoure( pr.first ) ) );
			pr.second->ToXML( strXML );
			strXML += XML::MakeCloseXmlElementWithChildren( XML::enRequireType );
		}
	
		strXML += XML::MakeCloseXmlElementWithChildren( XML::enRequireTypes );
	}
}

void AtlasRequire::Resource::Process( const Lookup* pLookup )
{
	if ( !m_bProcessed )
	{
		const Atlas::eAtlasResource eType = Atlas::GetAtlasResoureEnum( m_vectAttributes[ 0 ]->m_strValue );
	
		if ( Atlas::eUnknownAtlasResource == eType )
		{
			throw Exception( Exception::eUnknownResourceType, __FILE__, __FUNCTION__, __LINE__, m_vectAttributes[ 0 ]->m_strValue );
		}

		ResourceBase* pResourceBase = CreateResource( eType, m_strId );

		m_vectResourceInfo.push_back( make_pair( eType, pResourceBase ) );

		pResourceBase->Init( m_vectAttributes, m_strId );

		m_bProcessed = true;
	}
}

void AtlasRequire::Resource::InitSignalComponents( void )
{
	const unsigned int uiResources = m_vectResourceInfo.size( );

	if ( uiResources > 0 )
	{
		for ( unsigned int ui = 0; ui < uiResources; ++ui )
		{
			m_vectResourceInfo[ ui ].second->InitSignalComponents( );
		}
	}
}

void AtlasRequire::GarbageCollect( void )
{
	if ( 0 != m_pResource )
	{
		delete m_pResource;
		m_pResource = 0;
	}

	if ( 0 != m_pControl )
	{
		delete m_pControl;
		m_pControl = 0;
	}

	if ( 0 != m_pCapability )
	{
		delete m_pCapability;
		m_pCapability = 0;
	}

	if ( 0 != m_pLimit )
	{
		delete m_pLimit;
		m_pLimit = 0;
	}

	if ( 0 != m_pCNX )
	{
		delete m_pCNX;
		m_pCNX = 0;
	}
}

AtlasRequire::Resource::ResourceBase* AtlasRequire::Resource::CreateResource( const Atlas::eAtlasResource eResourceType, const string& strVirtualLabel )
{
	ResourceBase* pResourceBase = 0;

	try
	{
		switch ( eResourceType )
		{
			case Atlas::eInputResource:
				pResourceBase = new InputOutput( Atlas::eInput );
				break;
		
			case Atlas::eOutputResource:
				pResourceBase = new InputOutput( Atlas::eOutput );
				break;
		
			case Atlas::eIOResource:
				pResourceBase = new InputOutput( Atlas::eInputAndOutput );
				break;
		
			case Atlas::eSourceResource:
				pResourceBase = new Source( );
				break;
		
			case Atlas::eSensorResource:
				pResourceBase = new Sensor( );
				break;
		
			case Atlas::eLoadResource:
				pResourceBase = new Load( );
				break;
	
			case Atlas::eSTIM_RESP_COMPResource:
				pResourceBase = new StimRespComp( );
				break;
	
			case Atlas::eTimerResource:
			case Atlas::eDigitalTimerResource:
			case Atlas::eEventMonitorResource:
			case Atlas::eSTIMResource:
			case Atlas::eRESPResource:
			case Atlas::eSTIM_RESPResource:
				{
					string strError( strVirtualLabel );
	
					if ( strError.empty( ) )
					{
						strError = Atlas::m_UNKNOWN;
					}
	
					strError += ": resource: ";
					strError += m_vectAttributes[ 0 ]->m_strValue;
		
					throw Exception( Exception::eResourceConfigUnderConstruction, __FILE__, __FUNCTION__, __LINE__, strError );
				}
				break;
		}
	}
	catch( ... )
	{
		throw Exception( Exception::eFailedToAllocateMemoryForNewResourceConfigObject, __FILE__, __FUNCTION__, __LINE__, m_vectAttributes[ 0 ]->m_strValue );
	}

	return pResourceBase;
}

void AtlasRequire::Resource::StimRespComp::ToXML( string& strXML ) const
{
	strXML += m_AtlasSignalComponent.ToXML( );
}

AtlasRequire::Resource::ResourceBase& AtlasRequire::Resource::StimRespComp::operator = ( const AtlasRequire::Resource::ResourceBase& other )
{
	if ( this != &other )
	{
		ResourceBase::operator = ( other );

		const StimRespComp* pother = dynamic_cast< const StimRespComp* >( &other );
	
		if ( 0 != pother )
		{
			m_AtlasSignalComponent = pother->m_AtlasSignalComponent;
		}
	}
	
	return *this;
}

bool AtlasRequire::Resource::StimRespComp::operator == ( const AtlasRequire::Resource::ResourceBase& other ) const
{
	bool bEqual = true;

	if ( this != &other )
	{
		bEqual = ResourceBase::operator == ( other );

		if ( bEqual )
		{
			const StimRespComp* pother = dynamic_cast< const StimRespComp* >( &other );
		
			if ( 0 != pother )
			{
				if ( m_AtlasSignalComponent != pother->m_AtlasSignalComponent )
				{
					bEqual = false;
				}
			}
		}
	}
	
	return bEqual;
}

AtlasRequire::Resource::StimRespComp::operator string( void ) const
{
	return ( string ) m_AtlasSignalComponent;
}

void AtlasRequire::Resource::StimRespComp::Init( const vector< const AtlasAttributes::AtlasAttibuteValue* >& vectAttributes, const string& strVirtualLabel )
{
	const unsigned uiAttributes = vectAttributes.size( );

	if ( uiAttributes < 2 )
	{
		throw Exception( Exception::eInvalidNumberOfAttributesForResourceStimRespComp, __FILE__, __FUNCTION__, __LINE__, strVirtualLabel );
	}

	string strAtlasNoun;

	for ( unsigned int ui = 1; ui < uiAttributes; ++ui )
	{
		if ( !strAtlasNoun.empty( ) )
		{
			strAtlasNoun += " ";
		}

		strAtlasNoun += vectAttributes[ ui ]->m_strValue;
	}

	m_AtlasSignalComponent.SetAtlasNoun( Atlas::GetAtlasNounEnum( strAtlasNoun ) );

	if ( Atlas::eUnknownAtlasNoun == m_AtlasSignalComponent.GetAtlasNoun( ) )
	{
		string strError( strVirtualLabel );
			
		strError += ": Atlas noun: ";
		strError += strAtlasNoun;

		throw Exception( Exception::eUnknownAtlasNounForResourceStimRespComp, __FILE__, __FUNCTION__, __LINE__, strError );
	}
}

AtlasRequire::Resource::ResourceBase& AtlasRequire::Resource::Load::operator = ( const AtlasRequire::Resource::ResourceBase& other )
{
	if ( this != &other )
	{
		ResourceBase::operator = ( other );

		const Load* pother = dynamic_cast< const Load* >( &other );
	
		if ( 0 != pother )
		{
			m_AtlasSignalComponent = pother->m_AtlasSignalComponent;
		}
	}
	
	return *this;
}

bool AtlasRequire::Resource::Load::operator == ( const AtlasRequire::Resource::ResourceBase& other ) const
{
	bool bEqual = true;

	if ( this != &other )
	{
		bEqual = ResourceBase::operator == ( other );

		if ( bEqual )
		{
			const Load* pother = dynamic_cast< const Load* >( &other );
		
			if ( 0 != pother )
			{
				if ( m_AtlasSignalComponent != pother->m_AtlasSignalComponent )
				{
					bEqual = false;
				}
			}
		}
	}
	
	return bEqual;
}

AtlasRequire::Resource::Load::operator string( void ) const
{
	return ( string ) m_AtlasSignalComponent;
}

void AtlasRequire::Resource::Load::Init( const vector< const AtlasAttributes::AtlasAttibuteValue* >& vectAttributes, const string& strVirtualLabel )
{
	const unsigned uiAttributes = vectAttributes.size( );

	if ( uiAttributes < 2 )
	{
		throw Exception( Exception::eInvalidNumberOfAttributesForResourceLoad, __FILE__, __FUNCTION__, __LINE__, strVirtualLabel );
	}

	string strAtlasNoun;

	for ( unsigned int ui = 1; ui < uiAttributes; ++ui )
	{
		if ( !strAtlasNoun.empty( ) )
		{
			strAtlasNoun += " ";
		}

		strAtlasNoun += vectAttributes[ ui ]->m_strValue;
	}

	m_AtlasSignalComponent.SetAtlasNoun( Atlas::GetAtlasNounEnum( strAtlasNoun ) );

	if ( Atlas::eUnknownAtlasNoun == m_AtlasSignalComponent.GetAtlasNoun( ) )
	{
		string strError( strVirtualLabel );
			
		strError += ": Atlas noun: ";
		strError += strAtlasNoun;

		throw Exception( Exception::eUnknownAtlasNounForResourceLoad, __FILE__, __FUNCTION__, __LINE__, strError );
	}
}

void AtlasRequire::Resource::Load::ToXML( string& strXML ) const
{
	strXML += m_AtlasSignalComponent.ToXML( );
}

AtlasRequire::Resource::ResourceBase& AtlasRequire::Resource::Sensor::operator = ( const AtlasRequire::Resource::ResourceBase& other )
{
	if ( this != &other )
	{
		ResourceBase::operator = ( other );

		const Sensor* pother = dynamic_cast< const Sensor* >( &other );
	
		if ( 0 != pother )
		{
			m_AtlasMeasuredCharacteristic = pother->m_AtlasMeasuredCharacteristic;
		}
	}
	
	return *this;
}

bool AtlasRequire::Resource::Sensor::operator == ( const AtlasRequire::Resource::ResourceBase& other ) const
{
	bool bEqual = true;

	if ( this != &other )
	{
		bEqual = ResourceBase::operator == ( other );

		if ( bEqual )
		{
			const Sensor* pother = dynamic_cast< const Sensor* >( &other );
		
			if ( 0 != pother )
			{
				if ( m_AtlasMeasuredCharacteristic != pother->m_AtlasMeasuredCharacteristic )
				{
					bEqual = false;
				}
			}
		}
	}
	
	return bEqual;
}

AtlasRequire::Resource::Sensor::operator string( void ) const
{
	return ( string ) m_AtlasMeasuredCharacteristic;
}

void AtlasRequire::Resource::Sensor::Init( const vector< const AtlasAttributes::AtlasAttibuteValue* >& vectAttributes, const string& strVirtualLabel )
{
	const unsigned uiAttributes = vectAttributes.size( );

	if ( uiAttributes < 3 )
	{
		throw Exception( Exception::eInvalidNumberOfAttributesForResourceSensor, __FILE__, __FUNCTION__, __LINE__, strVirtualLabel );
	}

	string strNounModifierSuffix;

	m_AtlasMeasuredCharacteristic = Atlas::GetAtlasNounModifierEnum( vectAttributes[ 1 ]->m_strValue );

	if ( !m_AtlasMeasuredCharacteristic.IsValid( ) )
	{
		string strError( strVirtualLabel );
			
		strError += ": Atlas noun/modifier: ";
		strError += vectAttributes[ 1 ]->m_strValue;

		throw Exception( Exception::eUnknownAtlasNounModifierForResourceSensor, __FILE__, __FUNCTION__, __LINE__, strError );
	}

	string strAtlasNoun;

	for ( unsigned int ui = 2; ui < uiAttributes; ++ui )
	{
		if ( !strAtlasNoun.empty( ) )
		{
			strAtlasNoun += " ";
		}

		strAtlasNoun += vectAttributes[ ui ]->m_strValue;
	}

	m_AtlasMeasuredCharacteristic.SetAtlasNoun( Atlas::GetAtlasNounEnum( strAtlasNoun ) );

	if ( Atlas::eUnknownAtlasNoun == m_AtlasMeasuredCharacteristic.GetAtlasNoun( ) )
	{
		string strError( strVirtualLabel );
			
		strError += ": Atlas noun: ";
		strError += strAtlasNoun;

		throw Exception( Exception::eUnknownAtlasNounForResourceSensor, __FILE__, __FUNCTION__, __LINE__, strError );
	}
}

void AtlasRequire::Resource::Sensor::ToXML( string& strXML ) const
{
	strXML += m_AtlasMeasuredCharacteristic.ToXML( );
}

AtlasRequire::Resource::ResourceBase& AtlasRequire::Resource::Source::operator = ( const AtlasRequire::Resource::ResourceBase& other )
{
	if ( this != &other )
	{
		ResourceBase::operator = ( other );

		const Source* pother = dynamic_cast< const Source* >( &other );
	
		if ( 0 != pother )
		{
			m_AtlasSignalComponent = pother->m_AtlasSignalComponent;
		}
	}
	
	return *this;
}

bool AtlasRequire::Resource::Source::operator == ( const AtlasRequire::Resource::ResourceBase& other ) const
{
	bool bEqual = true;

	if ( this != &other )
	{
		bEqual = ResourceBase::operator == ( other );

		if ( bEqual )
		{
			const Source* pother = dynamic_cast< const Source* >( &other );
		
			if ( 0 != pother )
			{
				if ( m_AtlasSignalComponent != pother->m_AtlasSignalComponent )
				{
					bEqual = false;
				}
			}
		}
	}
	
	return bEqual;
}

AtlasRequire::Resource::Source::operator string( void ) const
{
	return ( string ) m_AtlasSignalComponent;
}

void AtlasRequire::Resource::Source::Init( const vector< const AtlasAttributes::AtlasAttibuteValue* >& vectAttributes, const string& strVirtualLabel )
{
	const unsigned uiAttributes = vectAttributes.size( );

	if ( uiAttributes < 2 )
	{
		throw Exception( Exception::eInvalidNumberOfAttributesForResourceSource, __FILE__, __FUNCTION__, __LINE__, strVirtualLabel );
	}

	string strAtlasNoun;

	for ( unsigned int ui = 1; ui < uiAttributes; ++ui )
	{
		if ( !strAtlasNoun.empty( ) )
		{
			strAtlasNoun += " ";
		}

		strAtlasNoun += vectAttributes[ ui ]->m_strValue;
	}

	m_AtlasSignalComponent.SetAtlasNoun( Atlas::GetAtlasNounEnum( strAtlasNoun ) );

	if ( Atlas::eUnknownAtlasNoun == m_AtlasSignalComponent.GetAtlasNoun( ) )
	{
		string strError( strVirtualLabel );
			
		strError += ": Atlas noun: ";
		strError += strAtlasNoun;

		throw Exception( Exception::eUnknownAtlasNounForResourceSource, __FILE__, __FUNCTION__, __LINE__, strError );
	}
}

void AtlasRequire::Resource::Source::ToXML( string& strXML ) const
{
	strXML += m_AtlasSignalComponent.ToXML( );
}

AtlasRequire::Resource::ResourceBase& AtlasRequire::Resource::InputOutput::operator = ( const AtlasRequire::Resource::ResourceBase& other )
{
	if ( this != &other )
	{
		ResourceBase::operator = ( other );

		const InputOutput* pother = dynamic_cast< const InputOutput* >( &other );
	
		if ( 0 != pother )
		{
			m_eIOType = pother->m_eIOType;
			m_eType = pother->m_eType;
		}
	}
	
	return *this;
}

bool AtlasRequire::Resource::InputOutput::operator == ( const AtlasRequire::Resource::ResourceBase& other ) const
{
	bool bEqual = true;

	if ( this != &other )
	{
		bEqual = ResourceBase::operator == ( other );

		if ( bEqual )
		{
			const InputOutput* pother = dynamic_cast< const InputOutput* >( &other );
		
			if ( 0 != pother )
			{
				if ( m_eIOType != pother->m_eIOType )
				{
					bEqual = false;
				}
				else if ( m_eType != pother->m_eType )
				{
					bEqual = false;
				}
			}
		}
	}
	
	return bEqual;
}

AtlasRequire::Resource::InputOutput::operator string( void ) const
{
	string strRet;
		
	strRet += ( AIXMLHelper::NumberToString< int >( ( int ) m_eIOType ) );
	strRet += m_strKeyDelimiter;
	strRet += ( AIXMLHelper::NumberToString< int >( ( int ) m_eType ) );

	return strRet;
}

void AtlasRequire::Resource::InputOutput::Init( const vector< const AtlasAttributes::AtlasAttibuteValue* >& vectAttributes, const string& strVirtualLabel )
{
	const int unsigned uiAttributes = vectAttributes.size( );

	if ( uiAttributes < 2 )
	{
		throw Exception( Exception::eInvalidNumberOfAttributesForResourceOutput, __FILE__, __FUNCTION__, __LINE__, strVirtualLabel );
	}

	m_eType = Atlas::GetAtlasInputOutputEnum( vectAttributes[ 1 ]->m_strValue );

	if ( Atlas::eUnknownInputOutput == m_eType )
	{
		string strError( strVirtualLabel );
			
		strError += ": I/O Type: ";
		strError += vectAttributes[ 1 ]->m_strValue;

		throw Exception( Exception::eUnknownInputOutputType, __FILE__, __FUNCTION__, __LINE__, strError );
	}
}

void AtlasRequire::Resource::InputOutput::ToXML( string& strXML ) const
{
	strXML += XML::MakeOpenXmlElementWithChildren( XML::enDefinition );
	strXML += XML::MakeXmlElementNoChildren( XML::enAtlas, XML::MakeXmlAttributeNameValue( XML::anNoun, Atlas::GetAtlasInputOutput( m_eType ) ) );
	strXML += XML::MakeCloseXmlElementWithChildren( XML::enDefinition );
}

void AtlasRequire::Process( const Lookup* pLookup )
{
	if ( !m_bProcessed )
	{
		Atlas::eAtlasNoun eNoun = Atlas::eUnknownAtlasNoun;

		if ( 0 != m_pResource )
		{
			m_pResource->Process( pLookup );

			eNoun = m_pResource->GetAtlasNoun( );
		}

		if ( 0 != m_pControl )
		{
			m_pControl->m_eNoun = eNoun;
			m_pControl->Process( pLookup );
		}

		if ( 0 != m_pCapability )
		{
			m_pCapability->m_eNoun = eNoun;
			m_pCapability->Process( pLookup );
		}

		if ( 0 != m_pLimit )
		{
			m_pLimit->m_eNoun = eNoun;
			m_pLimit->Process( pLookup );
		}

		if ( 0 != m_pCNX )
		{
			m_pCNX->m_eNoun = eNoun;
			m_pCNX->Process( pLookup );
		}

		InitSignalComponents( );

		m_bProcessed = true;
	}
}

AtlasStatement& AtlasRequire::operator = ( const AtlasStatement& other )
{
	if ( this != &other )
	{
		AtlasSignalVerb::operator = ( other );

		GarbageCollect( );

		const AtlasRequire* pother = dynamic_cast< const AtlasRequire* >( &other );

		if ( 0 != pother )
		{
			m_eLastProcessType	= pother->m_eLastProcessType;
			m_bInstrument		= pother->m_bInstrument;
			m_bUsed				= pother->m_bUsed;

			if ( 0 != pother->m_pResource )
			{
				try
				{
					m_pResource = new Resource( *( pother->m_pResource ) );
				}
				catch( ... )
				{
					throw Exception( Exception::eFailedToCreateResourceObject, __FILE__, __FUNCTION__, __LINE__, m_strVirtualLabel );
				}
			}
	
			if ( 0 != pother->m_pControl )
			{
				try
				{
					m_pControl = new Control( *( pother->m_pControl ) );
				}
				catch( ... )
				{
					throw Exception( Exception::eFailedToCreateControlObject, __FILE__, __FUNCTION__, __LINE__, m_strVirtualLabel );
				}
			}
	
			if ( 0 != pother->m_pCapability )
			{
				m_pCapability = CapabilityFactory( m_strVirtualLabel, m_eInstrument, 0 );
		
				*m_pCapability = *( pother->m_pCapability );
			}
	
			if ( 0 != pother->m_pLimit )
			{
				try
				{
					m_pLimit = new Limit( *pother->m_pLimit );
				}
				catch( ... )
				{
					throw Exception( Exception::eFailedToCreateLimitObject, __FILE__, __FUNCTION__, __LINE__, m_strVirtualLabel );
				}
			}
	
			if ( 0 != pother->m_pCNX )
			{
				try
				{
					m_pCNX = new CNX( *pother->m_pCNX );
				}
				catch( ... )
				{
					throw Exception( Exception::eFailedToCreateCNXObject, __FILE__, __FUNCTION__, __LINE__, m_strVirtualLabel );
				}
			}
		}
	}

	return *this;
}

AtlasRequire::Limit& AtlasRequire::Limit::operator = ( const AtlasRequire::Limit& other )
{
	if ( this != &other )
	{
		AtlasAttributes::operator = ( other );

		GarbageCollect( );

		m_eNoun = other.m_eNoun;

		unsigned int uiSize = other.m_vectRanges.size( );
		if ( uiSize > 0 )
		{
			m_vectRanges.reserve( uiSize );

			for ( unsigned int ui = 0; ui < uiSize; ++ui )
			{
				const pair< Atlas::AtlasSignalComponent, Range* >& prOther = other.m_vectRanges[ ui ];
				Range* pRange = 0;

				try
				{
					pRange = new Range( *( prOther.second ) );
				}
				catch( ... )
				{
					throw Exception( Exception::eFailedToCreateRangeObject, __FILE__, __FUNCTION__, __LINE__ );
				}
	
				m_vectRanges.push_back( make_pair( prOther.first, pRange ) );
			}
		}

		uiSize = other.m_vectMaximums.size( );
		if ( uiSize > 0 )
		{
			m_vectMaximums.reserve( uiSize );

			for ( unsigned int ui = 0; ui < uiSize; ++ui )
			{
				const pair< Atlas::AtlasSignalComponent, Atlas::AtlasNumber* >& prOther = other.m_vectMaximums[ ui ];
				Atlas::AtlasNumber* pNumber = 0;

				try
				{
					pNumber = new Atlas::AtlasNumber( *( prOther.second ) );
				}
				catch( ... )
				{
					throw Exception( Exception::eFailedToCreateNumberObject, __FILE__, __FUNCTION__, __LINE__ );
				}
	
				m_vectMaximums.push_back( make_pair( prOther.first, pNumber ) );
			}
		}
	}

	return *this;
}

AtlasRequire::Control& AtlasRequire::Control::operator = ( const AtlasRequire::Control& other )
{
	if ( this != &other )
	{
		AtlasAttributes::operator = ( other );

		GarbageCollect( );

		m_vectAtlasNounMod = other.m_vectAtlasNounMod;
		m_vectAtlasNounModFunctions = other.m_vectAtlasNounModFunctions;
		m_eNoun = other.m_eNoun;

		if ( 0 != other.m_pstrTrigOutDrive )
		{
			try
			{
				m_pstrTrigOutDrive = new string( *other.m_pstrTrigOutDrive );
			}
			catch( ... )
			{
				throw Exception( Exception::eFailedToCreateStringObject, __FILE__, __FUNCTION__, __LINE__ );
			}
		}

		if ( 0 != other.m_pSourceIndentifier )
		{
			try
			{
				m_pSourceIndentifier = new SourceIndentifier( *other.m_pSourceIndentifier );
			}
			catch( ... )
			{
				throw Exception( Exception::eFailedToCreateSourceIndentifierObject, __FILE__, __FUNCTION__, __LINE__ );
			}
		}

		if ( 0 != other.m_pCoupling )
		{
			try
			{
				m_pCoupling = new Coupling( *( other.m_pCoupling ) );
			}
			catch( ... )
			{
				throw Exception( Exception::eFailedToCreateCouplingObject, __FILE__, __FUNCTION__, __LINE__ );
			}
		}

		if ( 0 != other.m_pMode )
		{
			try
			{
				m_pMode = new Mode( *( other.m_pMode ) );
			}
			catch( ... )
			{
				throw Exception( Exception::eFailedToCreateModeObject, __FILE__, __FUNCTION__, __LINE__ );
			}
		}

		if ( 0 != other.m_pCirculate )
		{
			try
			{
				m_pCirculate = new Circulate( *( other.m_pCirculate ) );
			}
			catch( ... )
			{
				throw Exception( Exception::eFailedToCreateCirculateObject, __FILE__, __FUNCTION__, __LINE__ );
			}
		}

		unsigned int uiSize = other.m_vectRanges.size( );
		if ( uiSize > 0 )
		{
			m_vectRanges.reserve( uiSize );

			for ( unsigned int ui = 0; ui < uiSize; ++ui )
			{
				const pair< Atlas::AtlasSignalComponent, Range* >& prOther = other.m_vectRanges[ ui ];
				Range* pRange = 0;

				try
				{
					pRange = new Range( *( prOther.second ) );
				}
				catch( ... )
				{
					throw Exception( Exception::eFailedToCreateRangeObject, __FILE__, __FUNCTION__, __LINE__ );
				}
	
				m_vectRanges.push_back( make_pair( prOther.first, pRange ) );
			}
		}

		uiSize = other.m_vectSettingsValues.size( );
		if ( uiSize > 0 )
		{
			m_vectSettingsValues.reserve( uiSize );

			for ( unsigned int ui = 0; ui < uiSize; ++ui )
			{
				const pair< Atlas::AtlasSignalComponent, SettingValues* >& prOther = other.m_vectSettingsValues[ ui ];
				SettingValues* pLoadValues = 0;

				try
				{
					pLoadValues = new SettingValues( *( prOther.second ) );
				}
				catch( ... )
				{
					throw Exception( Exception::eFailedToCreateSettingsValuesObject, __FILE__, __FUNCTION__, __LINE__ );
				}
	
				m_vectSettingsValues.push_back( make_pair( prOther.first, pLoadValues ) );
			}
		}
	}

	return *this;
}

AtlasRequire::Resource& AtlasRequire::Resource::operator = ( const AtlasRequire::Resource& other )
{
	if ( this != &other )
	{
		AtlasAttributes::operator = ( other );

		GarbageCollect( );

		const unsigned int uiSize = other.m_vectResourceInfo.size( );

		if ( uiSize > 0 )
		{
			m_vectResourceInfo.reserve( uiSize );

			for ( unsigned int ui = 0; ui < uiSize; ++ui )
			{
				const pair< Atlas::eAtlasResource, ResourceBase* >& pr = other.m_vectResourceInfo[ ui ];
				ResourceBase* pResourceBase = 0;
	
				if ( 0 != pr.second )
				{
					pResourceBase = CreateResource( pr.first, string( ) );
	
					*( pResourceBase ) = *( pr.second );
				}
	
				m_vectResourceInfo.push_back( make_pair( pr.first, pResourceBase ) );
			}
		}
	}

	return *this;
}

bool AtlasRequire::IsUsed( void ) const
{
	bool bUsed = m_bUsed;

	if ( 0 != m_pResource )
	{
		// NOTE: JJO 7/2/2015 - Once the INPUT/OUTPUT statments have been completed
		// this switch statement should be removed. Just dirctly return variable
		// "m_bUsed"


		switch ( m_pResource->GetAtlasResource( ) )
		{
			case Atlas::eUnknownAtlasResource:
			case Atlas::eInputResource:
			case Atlas::eOutputResource:
			case Atlas::eIOResource:
				bUsed = true;
				break;
		}
	}

	return bUsed;
}

void AtlasRequire::ToXML( string& strXML, const unsigned int uiBitfield ) const
{
	const bool bCreateAtlasSourcesElement = ( eCreateAtlasSourcesElement == ( uiBitfield & eCreateAtlasSourcesElement ) );
	const bool bSignalOnly = ( eSignalOnly == ( uiBitfield & eSignalOnly ) );
	const bool bClassOnly = ( eClassOnly == ( uiBitfield & eClassOnly ) );
	const bool bUsedAttribute = ( eUsedAttribute == ( uiBitfield & eUsedAttribute ) );

	if ( bSignalOnly )
	{
		strXML += XML::MakeOpenXmlElementWithChildren( XML::enRequire );
	}
	else if ( bClassOnly )
	{
		strXML += XML::MakeOpenXmlElementWithChildren( XML::enRequire, 
			XML::MakeXmlAttributeNameValue( XML::anClass, SpecificInstrument::GetInstrumentClass( SpecificInstrument::GetInstrumentClass( m_eInstrument ) ) ),
			XML::MakeXmlAttributeNameValue( XML::anClassDescription, SpecificInstrument::GetInstrumentClassDescription( SpecificInstrument::GetInstrumentClass( m_eInstrument ) ) ) );
	}
	else
	{
		string strUnused;

		if ( bUsedAttribute )
		{
			if ( !IsUsed( ) )
			{
				strUnused = XML::MakeXmlAttributeNameValue( XML::anUnused, XML::avTrue );
			}
		}

		strXML += XML::MakeOpenXmlElementWithChildren( XML::enRequire, 
			( m_bInstrument ? string( ) : XML::MakeXmlAttributeNameValue( XML::anVirtualLabel, m_strVirtualLabel ) ),
			XML::MakeXmlAttributeNameValue( XML::anSystemName, m_strSystemName ), 
			XML::MakeXmlAttributeNameValue( XML::anClass, SpecificInstrument::GetInstrumentClass( SpecificInstrument::GetInstrumentClass( m_eInstrument ) ) ),
			XML::MakeXmlAttributeNameValue( XML::anClassDescription, SpecificInstrument::GetInstrumentClassDescription( SpecificInstrument::GetInstrumentClass( m_eInstrument ) ) ),
			( 0 == m_uiId ? string( ) : XML::MakeXmlAttributeNameValue( XML::anId, m_uiId ) ),
			GetStatementCommentRefId_XML( ),
			strUnused );
	}

	const unsigned int uiSourceStatments = m_vectAtlasSourceStatement.size( );

	if ( uiSourceStatments > 0 )
	{
		if ( bSignalOnly )
		{
			Atlas::AtlasSignalComponent asc( GetAtlasNoun( ) );
			asc.Set1641( ); 

			strXML += asc.ToXML( XML::enSignalName );
		}

		if ( bCreateAtlasSourcesElement )
		{
			strXML += XML::MakeOpenXmlElementWithChildren( XML::enAtlasSources );
		}

		for ( unsigned int ui = 0; ui < uiSourceStatments; ++ui )
		{
			strXML += m_vectAtlasSourceStatement[ ui ].ToXML( Atlas::AtlasSourceStatement::eXmlAll );

			if ( !bCreateAtlasSourcesElement )
			{
				break;
			}
		}

		if ( bCreateAtlasSourcesElement )
		{
			strXML += XML::MakeCloseXmlElementWithChildren( XML::enAtlasSources );
		}
	}

	if ( 0 != m_pResource )
	{
		m_pResource->ToXML( strXML );
	}

	if ( 0 != m_pControl )
	{
		m_pControl->ToXML( strXML );
	}

	if ( 0 != m_pCapability )
	{
		m_pCapability->ToXML( strXML );
	}

	if ( 0 != m_pLimit )
	{
		m_pLimit->ToXML( strXML );
	}

	if ( 0 != m_pCNX )
	{
		m_pCNX->ToXML( strXML );
	}

	strXML += XML::MakeCloseXmlElementWithChildren( XML::enRequire );
}

void AtlasRequire::ToSignalXML( string& strXML, const map< string, pair< Atlas::AtlasSignalComponent, unsigned int > >& mapSignalModifiers ) const
{
	map< string, pair< Atlas::AtlasSignalComponent, unsigned int > >::const_iterator it = mapSignalModifiers.begin( );
	const map< string, pair< Atlas::AtlasSignalComponent, unsigned int > >::const_iterator itEnd = mapSignalModifiers.end( );
	string strControlXML;
	string strCapabilityXML;
	string strLimitXML;
	string strModifiersXML;
	unsigned int uiModifiers = 0;

	XML::IncrementXMLIndent( 2 );

	while ( itEnd != it )
	{
		if ( 0 != m_pControl )
		{
			XML::IncrementXMLIndent( 2 );
			strControlXML = m_pControl->ToSignalXML( it->second.first );
			XML::DecrementXMLIndent( 2 );
		}
	
		if ( 0 != m_pCapability )
		{
			XML::IncrementXMLIndent( 2 );
			strCapabilityXML = m_pCapability->ToSignalXML( it->second.first );
			XML::DecrementXMLIndent( 2 );
		}
	
		if ( 0 != m_pLimit )
		{
			XML::IncrementXMLIndent( 2 );
			strLimitXML = m_pLimit->ToSignalXML( it->second.first );
			XML::DecrementXMLIndent( 2 );
		}

		const bool bControXML = !strControlXML.empty( );
		const bool bCapabilityXML = !strCapabilityXML.empty( );
		const bool bLimitXML = !strLimitXML.empty( );
		const unsigned int uiAttributes = ( bControXML + bCapabilityXML + bLimitXML );
	
		if ( uiAttributes > 0 )
		{
			++uiModifiers;

			strModifiersXML += XML::MakeOpenXmlElementWithChildren( XML::enModifier );

			strModifiersXML += it->second.first.ToXML( );

			if ( bControXML )
			{
				strModifiersXML += XML::MakeOpenXmlElementWithChildren( XML::enControl );
	
				strModifiersXML += strControlXML;
	
				strModifiersXML += XML::MakeCloseXmlElementWithChildren( XML::enControl );
			}
		
			if ( bCapabilityXML )
			{
				strModifiersXML += XML::MakeOpenXmlElementWithChildren( XML::enCapability );
	
				strModifiersXML += strCapabilityXML;
	
				strModifiersXML += XML::MakeCloseXmlElementWithChildren( XML::enCapability );
			}
		
			if ( bLimitXML )
			{
				strModifiersXML += XML::MakeOpenXmlElementWithChildren( XML::enLimit );
	
				strModifiersXML += strLimitXML;
	
				strModifiersXML += XML::MakeCloseXmlElementWithChildren( XML::enLimit );
			}

			strModifiersXML += XML::MakeCloseXmlElementWithChildren( XML::enModifier );
		}

		++it;
	}

	XML::DecrementXMLIndent( 2 );

	if ( !strModifiersXML.empty( ) )
	{
		strXML += XML::MakeOpenXmlElementWithChildren( XML::enRequire, 
			( m_bInstrument ? string( ) : XML::MakeXmlAttributeNameValue( XML::anVirtualLabel, m_strVirtualLabel ) ),
			XML::MakeXmlAttributeNameValue( XML::anSystemName, m_strSystemName ), 
			XML::MakeXmlAttributeNameValue( XML::anClass, SpecificInstrument::GetInstrumentClass( SpecificInstrument::GetInstrumentClass( m_eInstrument ) ) ),
			XML::MakeXmlAttributeNameValue( XML::anClassDescription, SpecificInstrument::GetInstrumentClassDescription( SpecificInstrument::GetInstrumentClass( m_eInstrument ) ) ),
			( 0 == m_uiId ? string( ) : XML::MakeXmlAttributeNameValue( XML::anId, m_uiId ) ) );

		const unsigned int uiSourceStatments = m_vectAtlasSourceStatement.size( );

		if ( uiSourceStatments > 0 )
		{
			strXML += XML::MakeOpenXmlElementWithChildren( XML::enAtlasSources );

			for ( unsigned int ui = 0; ui < uiSourceStatments; ++ui )
			{
				strXML += m_vectAtlasSourceStatement[ ui ].ToXML( Atlas::AtlasSourceStatement::eXmlAll );
			}

			strXML += XML::MakeCloseXmlElementWithChildren( XML::enAtlasSources );
		}

		if ( 0 != m_pResource )
		{
			m_pResource->ToXML( strXML );
		}

		strXML += XML::MakeOpenXmlElementWithChildren( XML::enModifiers, XML::MakeXmlAttributeNameValue( XML::anCount, uiModifiers ) );
		strXML += strModifiersXML;
		strXML += XML::MakeCloseXmlElementWithChildren( XML::enModifiers );
		strXML += XML::MakeCloseXmlElementWithChildren( XML::enRequire );
	}
}

void AtlasRequire::Limit::Merge( const AtlasRequire::Limit& other )
{
	if ( this != &other )
	{
		Range::MergeSignalRanges( m_vectRanges, other.m_vectRanges );
		NounModifier::MergeSignalNumbers( m_vectMaximums, other.m_vectMaximums, true );
	}
}

void AtlasRequire::Control::Merge( const AtlasRequire::Control& other )
{
	if ( this != &other )
	{
		Range::MergeSignalRanges( m_vectRanges, other.m_vectRanges );
		SettingValues::MergeSignalSettings( m_vectSettingsValues, other.m_vectSettingsValues );
		NounModifier::MergeAtlasSignalComponents( m_vectAtlasNounMod, other.m_vectAtlasNounMod );
		NounModifier::MergeAtlasSignalComponents( m_vectAtlasNounModFunctions, other.m_vectAtlasNounModFunctions );

		if ( ( 0 == m_pstrTrigOutDrive ) && ( 0 != other.m_pstrTrigOutDrive ) )
		{
			try
			{
				m_pstrTrigOutDrive = new string( *( other.m_pstrTrigOutDrive ) );
			}
			catch( ... )
			{
				throw Exception( Exception::eFailedToCreateStringObject, __FILE__, __FUNCTION__, __LINE__ );
			}
		}

		if ( ( 0 != m_pSourceIndentifier ) && ( 0 != other.m_pSourceIndentifier ) )
		{
			m_pSourceIndentifier->Merge( *( other.m_pSourceIndentifier ) );
		}
		else if ( 0 != other.m_pSourceIndentifier )
		{
			try
			{
				m_pSourceIndentifier = new SourceIndentifier( *( other.m_pSourceIndentifier ) );
			}
			catch( ... )
			{
				throw Exception( Exception::eFailedToCreateSourceIndentifierObject, __FILE__, __FUNCTION__, __LINE__ );
			}
		}

		if ( ( 0 != m_pCoupling ) && ( 0 != other.m_pCoupling ) )
		{
			m_pCoupling->Merge( *( other.m_pCoupling ) );
		}
		else if ( 0 != other.m_pCoupling )
		{
			try
			{
				m_pCoupling = new Coupling( *( other.m_pCoupling ) );
			}
			catch( ... )
			{
				throw Exception( Exception::eFailedToCreateCouplingObject, __FILE__, __FUNCTION__, __LINE__ );
			}
		}

		if ( ( 0 != m_pMode ) && ( 0 != other.m_pMode ) )
		{
			m_pMode->Merge( *( other.m_pMode ) );
		}
		else if ( 0 != other.m_pMode )
		{
			try
			{
				m_pMode = new Mode( *( other.m_pMode ) );
			}
			catch( ... )
			{
				throw Exception( Exception::eFailedToCreateModeObject, __FILE__, __FUNCTION__, __LINE__ );
			}
		}

		if ( ( 0 != m_pCirculate ) && ( 0 != other.m_pCirculate ) )
		{
			m_pCirculate->Merge( *( other.m_pCirculate ) );
		}
		else if ( 0 != other.m_pCirculate )
		{
			try
			{
				m_pCirculate = new Circulate( *( other.m_pCirculate ) );
			}
			catch( ... )
			{
				throw Exception( Exception::eFailedToCreateCirculateObject, __FILE__, __FUNCTION__, __LINE__ );
			}
		}
	}
}

void AtlasRequire::Resource::Merge( const AtlasRequire::Resource& other )
{
	if ( this != &other )
	{
		const unsigned int uiSize = m_vectResourceInfo.size( );
		const unsigned int uiSizeOther = other.m_vectResourceInfo.size( );
	
		if ( ( uiSize > 0 ) && ( uiSizeOther > 0 ) )
		{
			map< string, unsigned int > mapVect;
	
			for ( unsigned int ui = 0; ui < uiSize; ++ui )
			{
				const pair< Atlas::eAtlasResource, ResourceBase* >& pr = m_vectResourceInfo[ ui ];
				string strKey( AIXMLHelper::NumberToString< int >( ( int ) pr.first ) );
				strKey += m_strKeyDelimiter;
				strKey += ( string ) *( pr.second );

				mapVect.insert( make_pair( strKey, ui ) );
			}
	
			map< string, unsigned int >::const_iterator it;
			const map< string, unsigned int >::const_iterator itEnd = mapVect.end( );
	
			// If only in other, copy
			for ( unsigned int ui = 0; ui < uiSizeOther; ++ui )
			{
				const pair< Atlas::eAtlasResource, ResourceBase* >& pr = other.m_vectResourceInfo[ ui ];
				string strKey( AIXMLHelper::NumberToString< int >( ( int ) pr.first ) );
				strKey += m_strKeyDelimiter;
				strKey += ( string ) *( pr.second );

				it = mapVect.find( strKey );
	
				if ( itEnd == it )
				{
					const pair< Atlas::eAtlasResource, ResourceBase* >& pr = other.m_vectResourceInfo[ ui ];
					ResourceBase* pResourceBase = 0;
		
					if ( 0 != pr.second )
					{
						pResourceBase = CreateResource( pr.first, string( ) );
		
						*( pResourceBase ) = *( pr.second );
					}
		
					m_vectResourceInfo.push_back( make_pair( pr.first, pResourceBase ) );
				}
			}
		}
		else if ( uiSizeOther > 0 )
		{
			for ( unsigned int ui = 0; ui < uiSizeOther; ++ui )
			{
				const pair< Atlas::eAtlasResource, ResourceBase* >& pr = other.m_vectResourceInfo[ ui ];
				ResourceBase* pResourceBase = 0;
	
				if ( 0 != pr.second )
				{
					pResourceBase = CreateResource( pr.first, string( ) );
	
					*( pResourceBase ) = *( pr.second );
				}
	
				m_vectResourceInfo.push_back( make_pair( pr.first, pResourceBase ) );
			}
		}
	}
}

void AtlasRequire::Merge( const AtlasRequire& other, const bool bMergeSignalOnly )
{
	if ( this != &other )
	{
		if ( !bMergeSignalOnly )
		{
			if ( m_eInstrument != other.m_eInstrument )
			{
				const string& strInstrument = SpecificInstrument::GetInstrumentName( m_eInstrument );
				const string& strOtherInstrument = SpecificInstrument::GetInstrumentName( other.m_eInstrument );
				string strError( m_strVirtualLabel );
	
				strError += ": ";
				strError += m_strVirtualLabel;
				strError += ", (";
				strError += strInstrument;
				strError += ", ";
				strError += strOtherInstrument;
	
				throw Exception( Exception::eMergeInstrumentsHaveSameLabelDifferentTypes, __FILE__, __FUNCTION__, __LINE__, strError );
			}

			if ( m_strSystemName != other.m_strSystemName )
			{
				string strError( m_strVirtualLabel );

				strError += ": ";
				strError += m_strVirtualLabel;
				strError += ", (";
				strError += m_strSystemName;
				strError += ", ";
				strError += other.m_strSystemName;

				throw Exception( Exception::eMergeInstrumentsHaveSameLabelDifferentTypes, __FILE__, __FUNCTION__, __LINE__, strError );
			}
		}

		if ( other.m_vectAtlasSourceStatement.size( ) > 0 )
		{
			m_vectAtlasSourceStatement.push_back( other.m_vectAtlasSourceStatement.front( ) );
		}

		if ( ( 0 != m_pResource ) && ( 0 != other.m_pResource ) )
		{
			m_pResource->Merge( *( other.m_pResource ) );
		}
		else if ( 0 != other.m_pResource )
		{
			try
			{
				m_pResource = new Resource( *( other.m_pResource ) );
			}
			catch( ... )
			{
				throw Exception( Exception::eFailedToCreateResourceObject, __FILE__, __FUNCTION__, __LINE__, m_strVirtualLabel );
			}
		}

		if ( ( 0 != m_pControl ) && ( 0 != other.m_pControl ) )
		{
			m_pControl->Merge( *( other.m_pControl ) );
		}
		else if ( 0 != other.m_pControl )
		{
			try
			{
				m_pControl = new Control( *( other.m_pControl ) );
			}
			catch( ... )
			{
				throw Exception( Exception::eFailedToCreateControlObject, __FILE__, __FUNCTION__, __LINE__, m_strVirtualLabel );
			}
		}

		if ( ( 0 != m_pCapability ) && ( 0 != other.m_pCapability ) )
		{
			m_pCapability->Merge( *( other.m_pCapability ) );
		}
		else if ( 0 != other.m_pCapability )
		{
			try
			{
				m_pCapability = new Capability( *( other.m_pCapability ) );
			}
			catch( ... )
			{
				throw Exception( Exception::eFailedToCreateCapabilityObject, __FILE__, __FUNCTION__, __LINE__, m_strVirtualLabel );
			}

			m_pCapability->SetId( m_strId );
		}

		if ( ( 0 != m_pLimit ) && ( 0 != other.m_pLimit ) )
		{
			m_pLimit->Merge( *( other.m_pLimit ) );
		}
		else if ( 0 != other.m_pLimit )
		{
			try
			{
				m_pLimit = new Limit( *( other.m_pLimit ) );
			}
			catch( ... )
			{
				throw Exception( Exception::eFailedToCreateLimitObject, __FILE__, __FUNCTION__, __LINE__, m_strVirtualLabel );
			}
		}

		if ( ( 0 != m_pCNX ) && ( 0 != other.m_pCNX ) )
		{
			m_pCNX->Merge( *( other.m_pCNX ) );
		}
		else if ( 0 != other.m_pCNX )
		{
			try
			{
				m_pCNX = new CNX( *( other.m_pCNX ) );
			}
			catch( ... )
			{
				throw Exception( Exception::eFailedToCreateCNXObject, __FILE__, __FUNCTION__, __LINE__, m_strVirtualLabel );
			}
		}
	}
}

void AtlasRequire::InitSignalComponents( void )
{
	if ( 0 != m_pResource )
	{
		m_pResource->InitSignalComponents( );
	}

	if ( 0 != m_pControl )
	{
		m_pControl->InitSignalComponents( );
	}

	if ( 0 != m_pCapability )
	{
		m_pCapability->InitSignalComponents( );
	}

	if ( 0 != m_pLimit )
	{
		m_pLimit->InitSignalComponents( );
	}

	if ( 0 != m_pCNX )
	{
		m_pCNX->InitSignalComponents( );
	}
}

bool AtlasRequire::HasSignal( void ) const
{
	bool bHasSignal = false;

	if ( 0 != m_pResource )
	{
		if ( Atlas::eUnknownAtlasNoun != m_pResource->GetAtlasNoun( ) )
		{
			bHasSignal = true;
		}
	}

	return bHasSignal;
}

void AtlasRequire::InitSignalInfo( AtlasSignalInfo* pInformation, const unsigned int uiBitfield )
{
	if ( 0 != pInformation )
	{
		if ( HasSignal( ) )
		{
			const bool bInstruments	= ( eInstruments == ( uiBitfield & eInstruments ) );
			const bool bModifiers = ( eModifiers == ( uiBitfield & eModifiers ) );
			const bool bAll = ( eAll == ( uiBitfield & eAll ) );

			if ( bAll )
			{
				pInformation->SetRequire( this );
			}
			else
			{
				if ( bInstruments )
				{
					if ( 0 != m_pResource )
					{
						const unsigned int uiSize = m_pResource->m_vectResourceInfo.size( );
			
						for ( unsigned int ui = 0; ui < uiSize; ++ui )
						{
							const Atlas::AtlasSignalComponent* pAtlasSignalComponent = m_pResource->m_vectResourceInfo[ ui ].second->GetSignalComponent( );
			
							if ( 0 != pAtlasSignalComponent )
							{
								pInformation->SetInstrument( pAtlasSignalComponent->GetAtlasNoun( ), m_eInstrument, m_pResource->m_vectResourceInfo[ ui ].first );
							}
						}
					}
				}
	
				if ( bModifiers )
				{
					if ( 0 != m_pControl )
					{
						pInformation->SetComponentValues< Range >( m_pControl->m_eNoun, m_pControl->m_vectRanges, Atlas::eAtlasRequireControl, AtlasSignalInfo::eRanges );
						pInformation->SetComponentValues< SettingValues >( m_pControl->m_eNoun, m_pControl->m_vectSettingsValues, Atlas::eAtlasRequireControl, AtlasSignalInfo::eSettingValues );
					}
		
					if ( 0 != m_pCapability )
					{
						pInformation->SetComponentValues< Range >( m_pCapability->m_eNoun, m_pCapability->m_vectRanges, Atlas::eAtlasRequireCapability, AtlasSignalInfo::eRanges );
						pInformation->SetComponentValues< SettingValues >( m_pCapability->m_eNoun, m_pCapability->m_vectSettingsValues, Atlas::eAtlasRequireCapability, AtlasSignalInfo::eSettingValues );
						pInformation->SetComponentValues< Atlas::AtlasNumber >( m_pCapability->m_eNoun, m_pCapability->m_vectMaximums, Atlas::eAtlasRequireCapability, AtlasSignalInfo::eMaximums );
					}
		
					if ( 0 != m_pLimit )
					{
						pInformation->SetComponentValues< Range >( m_pLimit->m_eNoun, m_pLimit->m_vectRanges, Atlas::eAtlasRequireLimit, AtlasSignalInfo::eRanges );
						pInformation->SetComponentValues< Atlas::AtlasNumber >( m_pLimit->m_eNoun, m_pLimit->m_vectMaximums, Atlas::eAtlasRequireLimit, AtlasSignalInfo::eMaximums );
					}
				}
			}
		}
	}
}

Atlas::eAtlasNoun AtlasRequire::GetAtlasNoun( void ) const
{
	Atlas::eAtlasNoun eNoun = Atlas::eUnknownAtlasNoun;

	if ( 0 != m_pResource )
	{
		eNoun = m_pResource->GetAtlasNoun( );
	}

	return eNoun;
}

unsigned int AtlasRequires::GetUsedCount( void ) const
{
	map< string, AtlasStatement* >::const_iterator it = m_mapRequires.begin( );
	const map< string, AtlasStatement* >::const_iterator itEnd = m_mapRequires.end( );
	unsigned int uiUsedCount = 0;

	while ( itEnd != it )
	{
		if ( ( ( AtlasRequire* ) it->second )->IsUsed( ) )
		{
			++uiUsedCount;
		}

		++it;
	}

	return uiUsedCount;
}

const AtlasRequire* AtlasRequires::GetNext( void )
{
	const AtlasRequire* pAtlasRequire = 0;

	if ( m_mapRequires.end( ) == m_it )
	{
		m_it = m_mapRequires.begin( );
	}
	else
	{
		m_it++;
	}

	if ( m_mapRequires.end( ) != m_it )
	{
		pAtlasRequire = ( AtlasRequire* ) m_it->second;
	}

	return pAtlasRequire;
}

const AtlasRequire* AtlasRequires::GetRequire( const string& strVirtualLabel ) const
{
	const map< string, AtlasStatement* >::const_iterator it = m_mapRequires.find( strVirtualLabel );
	const AtlasRequire* pRequire = 0;

	if ( m_mapRequires.end( ) != it )
	{
		pRequire = ( AtlasRequire* ) it->second;
	}

	return pRequire;
}

AtlasRequires& AtlasRequires::operator = ( const AtlasStatements& other )
{
	if ( this != &other )
	{
		AtlasStatements::operator = ( other );

		const AtlasRequires* pother = dynamic_cast< const AtlasRequires* >( &other );
	
		if ( 0 != pother )
		{
			m_mapRequires.clear( );

			const unsigned int uiSize = m_vectStatement.size( );

			if ( uiSize > 0 )
			{
				for ( unsigned int ui = 0; ui < uiSize; ++ui )
				{
					m_mapRequires.insert( make_pair( ( ( AtlasSignalVerb* ) m_vectStatement[ ui ] )->m_strVirtualLabel, m_vectStatement[ ui ] ) );
				}
			}

			m_it = m_mapRequires.end( );
		}
	}

	return *this;
}

AtlasStatement* AtlasRequires::StatementFactory( const AtlasStatement* pOtherAtlasStatement )
{
	AtlasRequire* pAtlasRequire = 0;

	if ( 0 != pOtherAtlasStatement )
	{
		const AtlasRequire* pOtherAtlasRequire = dynamic_cast< const AtlasRequire* >( pOtherAtlasStatement );

		if ( 0 == pOtherAtlasRequire )
		{
			throw Exception( Exception::eUnexpectedStatementType, __FILE__, __FUNCTION__, __LINE__, "expected REQUIRE statement type" );
		}

		if ( Atlas::eREQUIRE != pOtherAtlasStatement->m_eAtlasStatement )
		{
			throw Exception( Exception::eUnexpectedStatementType, __FILE__, __FUNCTION__, __LINE__, "expected REQUIRE" );
		}
	
		try
		{
			pAtlasRequire = new AtlasRequire( pOtherAtlasStatement->m_eAtlasStatement );
		}
		catch( ... )
		{
			throw Exception( Exception::eFailedToAllocateMemoryForNewStatementObject, __FILE__, __FUNCTION__, __LINE__ );
		}
	
		pAtlasRequire->m_strVirtualLabel = pOtherAtlasRequire->m_strVirtualLabel;
		pAtlasRequire->m_strSystemName = pOtherAtlasRequire->m_strSystemName;
		pAtlasRequire->m_eInstrument = pOtherAtlasRequire->m_eInstrument;

		m_vectStatement.push_back( pAtlasRequire );
	
		m_mapRequires.insert( make_pair( pAtlasRequire->m_strVirtualLabel, pAtlasRequire ) );
	
		m_it = m_mapRequires.end( );
	}

	if ( 0 == pAtlasRequire )
	{
		throw Exception( Exception::eFailedToAllocateMemoryForNewStatementObject, __FILE__, __FUNCTION__, __LINE__ );
	}

	return pAtlasRequire;
}

AtlasStatement* AtlasRequires::StatementFactory( const DOMElement* pAIXMLvalue, const Atlas::eAtlasStatement eStatementType )
{
	AtlasRequire* pAtlasRequire = 0;

	if ( Atlas::eREQUIRE != eStatementType )
	{
		throw Exception( Exception::eUnexpectedStatementType, __FILE__, __FUNCTION__, __LINE__, "expected REQUIRE" );
	}

	const DOMElement* pFirstChildvalue = pAIXMLvalue->getFirstElementChild( );

	if ( 0 == pFirstChildvalue )
	{
		throw Exception( Exception::eFailedToGetFirstElementChildForRequireStatement, __FILE__, __FUNCTION__, __LINE__ );
	}

	const string strVirtualLabel( AIXMLHelper::GetXercesString( pFirstChildvalue->getAttribute( AIXMLHelper::GetWString( AIXML::m_arrayXMLKeyWords[ AIXML::eNameAttribute ] ).c_str( ) ) ) );

	if ( strVirtualLabel.empty( ) )
	{
		throw Exception( Exception::eFailedToGetVirtualLabelNameForRequireStatement, __FILE__, __FUNCTION__, __LINE__ );
	}

	#ifdef CASS
		SpecificInstrument::eInstrument eInstrumentType = m_pLookup->GetInstrumentEnum( strVirtualLabel, false );
		string strSystemName( m_pLookup->GetSystemName( strVirtualLabel, false ) );
	#else
		SpecificInstrument::eInstrument eInstrumentType = SpecificInstrument::GetInstrument( strVirtualLabel, false );
		string strSystemName( strVirtualLabel );
	#endif

	if ( SpecificInstrument::eUnknownInstrument == eInstrumentType )
	{
		// Can't find the system name, lets see if its a filename.
		// To do this we need to do a look-a-head in the XML.

		if ( IsFileSystemFromXML( pAIXMLvalue ) )
		{
			eInstrumentType = SpecificInstrument::eFILE;
			strSystemName = SpecificInstrument::GetInstrumentName( eInstrumentType );
		}
		else
		{
			// Lets verify that the virtual label is not really an actual device/instrument name

			eInstrumentType = SpecificInstrument::GetInstrument( strVirtualLabel, false );

			if ( ( SpecificInstrument::eUnknownInstrument == eInstrumentType ) )
			{
				throw Exception( Exception::eCannotFindSystemNameByLabel, __FILE__, __FUNCTION__, __LINE__, strVirtualLabel );
			}

			strSystemName = SpecificInstrument::GetInstrumentName( eInstrumentType );
		}
	}

	try
	{
		pAtlasRequire = new AtlasRequire( eStatementType );
	}
	catch( ... )
	{
		throw Exception( Exception::eFailedToAllocateMemoryForNewStatementObject, __FILE__, __FUNCTION__, __LINE__, strVirtualLabel );
	}

	pAtlasRequire->SetId( strVirtualLabel );
	pAtlasRequire->m_strVirtualLabel = strVirtualLabel;
	pAtlasRequire->m_strSystemName = strSystemName;
	pAtlasRequire->m_eInstrument = eInstrumentType;

	m_vectStatement.push_back( pAtlasRequire );

	m_mapRequires.insert( make_pair( strVirtualLabel, pAtlasRequire ) );

	m_it = m_mapRequires.end( );

	return pAtlasRequire;
}

void AtlasRequires::Merge( const AtlasRequires& other )
{
	if ( this != &other )
	{
		map< string, AtlasStatement* >::const_iterator it;
		map< string, AtlasStatement* >::const_iterator itOther = other.m_mapRequires.begin( );
		const map< string, AtlasStatement* >::const_iterator itOtherEnd = other.m_mapRequires.end( );
		AtlasStatement* pAtlasStatementOther = 0;
		AtlasStatement* pAtlasStatement = 0;

		while ( itOther != itOtherEnd )
		{
			it = m_mapRequires.find( itOther->first );

			if ( m_mapRequires.end( ) == it )
			{
				pAtlasStatementOther = itOther->second;

				if ( 0 != dynamic_cast< const AtlasRequire* >( pAtlasStatementOther ) )
				{
					try
					{
						pAtlasStatement = new AtlasRequire( pAtlasStatementOther->m_eAtlasStatement );
					}
					catch( ... )
					{
						throw Exception( Exception::eFailedToAllocateMemoryForNewStatementObject, __FILE__, __FUNCTION__, __LINE__, ( ( const AtlasRequire* ) pAtlasStatementOther )->m_strVirtualLabel );
					}
				
					m_vectStatement.push_back( pAtlasStatement );
					m_mapRequires.insert( make_pair( itOther->first, pAtlasStatement ) );
			
					*pAtlasStatement = *pAtlasStatementOther;
				}
			}
			else if ( 0 != itOther->second )
			{
				pAtlasStatementOther = dynamic_cast< AtlasRequire* >( itOther->second );
				pAtlasStatement = dynamic_cast< AtlasRequire* >( it->second );

				if ( ( 0 != pAtlasStatementOther ) && ( 0 != pAtlasStatement ) )
				{
					( ( AtlasRequire* ) pAtlasStatement )->Merge( *( ( AtlasRequire* ) pAtlasStatementOther ), false );
				}
			}

			++itOther;
		}
	}
}