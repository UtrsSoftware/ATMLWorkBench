/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

#include "cnx.h"
#include "helper.h"

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


void CNX::GarbageCollect( void )
{
	map< Atlas::eAtlasPinDescriptor, CNXInfo* >::const_iterator it = m_mapCNX.begin( );
	map< Atlas::eAtlasPinDescriptor, CNXInfo* >::const_iterator itEnd = m_mapCNX.end( );

	while ( itEnd != it )
	{
		delete it->second;

		++it;
	}
	m_mapCNX.clear( );


	it = m_mapREF.begin( );
	itEnd = m_mapREF.end( );

	while ( itEnd != it )
	{
		delete it->second;

		++it;
	}
	m_mapREF.clear( );
}

void CNX::ToXML( string& strXML ) const
{
	const unsigned int uiCNX = m_mapCNX.size( );
	const unsigned int uiREF = m_mapREF.size( );

	if ( ( uiCNX > 0 ) || ( uiREF > 0 ) )
	{
		strXML += XML::MakeOpenXmlElementWithChildren( XML::enConnection );

		if ( uiCNX > 0 )
		{
			ToXML( strXML, XML::enCnx, m_mapCNX );
		}
			
		if ( uiREF > 0 )
		{
			ToXML( strXML, XML::enRef, m_mapREF );
		}

		strXML += XML::MakeCloseXmlElementWithChildren( XML::enConnection );
	}
}

void CNX::ToXML( string& strXML, const XML::ElementName eElementName, const map< Atlas::eAtlasPinDescriptor, CNXInfo* >& mapCNX ) const
{
	map< Atlas::eAtlasPinDescriptor, CNXInfo* >::const_iterator it = mapCNX.begin( );
	map< Atlas::eAtlasPinDescriptor, CNXInfo* >::const_iterator itEnd = mapCNX.end( );

	strXML += XML::MakeOpenXmlElementWithChildren( eElementName );

	while ( itEnd != it )
	{
		CNXInfo* pCNXInfo = it->second;

		if ( 0 != pCNXInfo )
		{
			strXML += XML::MakeOpenXmlElementWithChildren( XML::enConnector );

			if ( !m_bRequireStatement )
			{
				pCNXInfo->ToXML( strXML );
			}

			strXML += pCNXInfo->m_ASC.ToXML( );

			strXML += XML::MakeCloseXmlElementWithChildren( XML::enConnector );
		}

		++it;
	}

	strXML += XML::MakeCloseXmlElementWithChildren( eElementName );
}


void CNX::Process( const Lookup* pLookup )
{
	if ( !m_bProcessed )
	{
		const unsigned int uiAttributes = m_vectAttributes.size( );
		
		if ( uiAttributes < 2 )
		{
			throw Exception( Exception::eInvalidNumberOfAttributesForCNX, __FILE__, __FUNCTION__, __LINE__, m_strId );
		}

		map< Atlas::eAtlasPinDescriptor, CNXInfo* >::const_iterator it;
		map< Atlas::eAtlasPinDescriptor, CNXInfo* >* pmapCNX = 0;
		CNXInfo* pCNXInfo = 0;
		bool bRef = false;
		bool bExist = false;

		for ( unsigned int ui = 1; ui < uiAttributes; ++ui )
		{
			Atlas::eAtlasPinDescriptor ePinDescriptor = Atlas::GetAtlasPinDescriptorEnum( m_vectAttributes[ ui ]->m_strValue );

			if ( Atlas::eUnknownAtlasPinDescriptor == ePinDescriptor )
			{
				if ( AtlasStatement::m_strREF == m_vectAttributes[ ui ]->m_strValue )
				{
					bRef = true;
					continue;
				}
			}

			if ( Atlas::eUnknownAtlasPinDescriptor == ePinDescriptor )
			{
				string strError( m_strId );
					
				strError += ": Atlas CNX descriptor: ";
				strError += m_vectAttributes[ ui ]->m_strValue;
		
				throw Exception( Exception::eUnknownAtlasCnxDescriptor, __FILE__, __FUNCTION__, __LINE__, strError );
			}

			if ( bRef )
			{
				pmapCNX = &m_mapREF;

				if ( Atlas::eHI == ePinDescriptor )
				{
					ePinDescriptor = Atlas::eHIRef;
				}
				else if ( Atlas::eLO == ePinDescriptor )
				{
					ePinDescriptor = Atlas::eLORef;
				}
			}
			else
			{
				pmapCNX = &( m_mapCNX );
			}

			it = pmapCNX->find( ePinDescriptor );

			if ( pmapCNX->end( ) == it )
			{
				try
				{
					pCNXInfo = new CNXInfo;
				}
				catch ( ... )
				{
					throw Exception( Exception::eFailedToCreateCNXInfoObject, __FILE__, __FUNCTION__, __LINE__ );
				}

				pCNXInfo->m_ASC.SetAtlasNoun( m_eNoun );
				pCNXInfo->m_eAtlasPinDescriptor = ePinDescriptor;
				pCNXInfo->m_ASC.SetAtlasPinDescriptor( ePinDescriptor );
				pCNXInfo->m_uiVirtualDataType = m_vectAttributes[ ui ]->m_uiType;

				pmapCNX->insert( make_pair( ePinDescriptor, pCNXInfo ) );

				bExist = false;
			}
			else
			{
				pCNXInfo = it->second;
				bExist = true;
			}

			if ( !m_bRequireStatement )
			{
				if ( ++ui < uiAttributes )
				{
					if ( 0 != pLookup )
					{
						Lookup::Subfile2* pSubfile2 = ( Lookup::Subfile2* ) pLookup->GetSubfile( 2 );

						if ( 0 != pSubfile2 )
						{
							const set< string >* pPinSet = pSubfile2->GetPinInfoSet( m_strSystemName, ePinDescriptor, m_vectAttributes[ ui ]->m_strValue );

							if ( 0 != pPinSet )
							{
								pCNXInfo->m_mapVirtualToPhysicalConn.insert( make_pair( m_vectAttributes[ ui ]->m_strValue, *( pPinSet ) ) );

								++ui;

								for ( ; ui < uiAttributes; ++ui )
								{
									ePinDescriptor = Atlas::GetAtlasPinDescriptorEnum( m_vectAttributes[ ui ]->m_strValue );

									if ( Atlas::eUnknownAtlasPinDescriptor != ePinDescriptor )
									{
										--ui;
										break;
									}

									pPinSet = pSubfile2->GetPinInfoSet( m_strSystemName, ePinDescriptor, m_vectAttributes[ ui ]->m_strValue );
		
									if ( 0 != pPinSet )
									{
										pCNXInfo->m_mapVirtualToPhysicalConn.insert( make_pair( m_vectAttributes[ ui ]->m_strValue, *( pPinSet ) ) );
									}
									else if ( AtlasStatement::m_strNONE == m_vectAttributes[ ui ]->m_strValue )
									{
										if ( ++ui < uiAttributes )
										{
											if ( AtlasStatement::m_strNONE == m_vectAttributes[ ui ]->m_strValue )
											{
												set< string > setNone;
		
												setNone.insert( AtlasStatement::m_strNONE );
		
												pCNXInfo->m_mapVirtualToPhysicalConn.insert( make_pair( AtlasStatement::m_strNONE, setNone ) );
											}
											else
											{
												--ui;
											}
										}
									}
								}
							}
							else if ( AtlasStatement::m_strNONE == m_vectAttributes[ ui ]->m_strValue )
							{
								if ( ++ui < uiAttributes )
								{
									if ( AtlasStatement::m_strNONE == m_vectAttributes[ ui ]->m_strValue )
									{
										set< string > setNone;

										setNone.insert( AtlasStatement::m_strNONE );

										pCNXInfo->m_mapVirtualToPhysicalConn.insert( make_pair( AtlasStatement::m_strNONE, setNone ) );
									}
									else
									{
										--ui;
									}
								}
								else
								{
									set< string > setNone;

									pCNXInfo->m_mapVirtualToPhysicalConn.insert( make_pair( AtlasStatement::m_strNONE, setNone ) );
								}
							}
							else if ( m_vectAttributes[ ui ]->m_uiType & eVariable )
							{
								if ( ++ui < uiAttributes )
								{
									if ( m_vectAttributes[ ui ]->m_uiType & eVariable )
									{
										pCNXInfo->m_uiVirtualPhysicalDataType = m_vectAttributes[ ui ]->m_uiType;

										set< string > setVariable;

										setVariable.insert( m_vectAttributes[ ui ]->m_strValue );

										pCNXInfo->m_mapVirtualToPhysicalConn.insert( make_pair( m_vectAttributes[ ui - 1 ]->m_strValue, setVariable ) );
									}
									else
									{
										--ui;
									}
								}
							}
						}
					}
				}
			}
		}

		m_bProcessed = true;
	}
}

ieee1641::eBSC CNX::GetConnection1641BSC( const Atlas::eAtlasPinDescriptor ePinDescriptor, const bool bREF )
{
	map< Atlas::eAtlasPinDescriptor, CNXInfo* >& mapCNX = ( bREF ? m_mapREF : m_mapCNX );
	ieee1641::eBSC eConnectBSC = ieee1641::eUnknownBSC;

	if ( mapCNX.size( ) > 0 )
	{
		static unsigned int uiHi	= 0x001;
		static unsigned int uiLow	= 0x002;
		static unsigned int uiA		= 0x004;
		static unsigned int uiB		= 0x008;
		static unsigned int uiC		= 0x010;
		static unsigned int uiN		= 0x020;
		static unsigned int uiTrue	= 0x040;
		static unsigned int uiComp	= 0x080;
		static unsigned int uiVia	= 0x100;

		map< Atlas::eAtlasPinDescriptor, CNXInfo* >::iterator it = mapCNX.begin( );
		const map< Atlas::eAtlasPinDescriptor, CNXInfo* >::const_iterator itEnd = mapCNX.end( );
		const unsigned int uiCount = mapCNX.size( );
		unsigned int uiConnFlags = 0;

		while ( itEnd != it )
		{
			switch ( it->first )
			{
				case Atlas::eHI:
				case Atlas::eHIRef:
					uiConnFlags |= uiHi;
					break;
				case Atlas::eLO:
				case Atlas::eLORef:
					uiConnFlags |= uiLow;
					break;
				case Atlas::eA:
					uiConnFlags |= uiA;
					break;
				case Atlas::eB:
					uiConnFlags |= uiB;
					break;
				case Atlas::eC:
					uiConnFlags |= uiC;
					break;
				case Atlas::eN:
					uiConnFlags |= uiN;
					break;
				case Atlas::eAtlasPinDescriptorTRUE:
					uiConnFlags |= uiTrue;
					break;
				case Atlas::eAtlasPinDescriptorCOMPL:
					uiConnFlags |= uiComp;
					break;
				case Atlas::eVIA:
					uiConnFlags |= uiVia;
					break;
			}

			++it;
		}

		eConnectBSC = Atlas::Get1641BSCEnumByAtlasPinDescriptorEnum( ePinDescriptor );

		switch ( eConnectBSC )
		{
			case ieee1641::eTwoWire_FourWire:
				if ( uiCount > 2 )
				{
					if ( ( uiConnFlags & uiHi ) && ( uiConnFlags & uiLow ) && ( uiConnFlags & uiVia ) )
					{
						if ( Atlas::eVIA == ePinDescriptor )
						{
							eConnectBSC = ieee1641::eSeries;
						}
						else
						{
							eConnectBSC = ieee1641::eTwoWire;
						}
					}
				}
				else
				{
					if ( ( Atlas::eHIRef == ePinDescriptor ) || ( Atlas::eLORef == ePinDescriptor ) )
					{
						eConnectBSC = ieee1641::eFourWire;
					}
					else
					{
						if ( 0 == m_mapREF.size( ) )
						{
							eConnectBSC = ieee1641::eTwoWire;
						}
						else
						{
							eConnectBSC = ieee1641::eFourWire;
						}
					}
				}
				break;
			case ieee1641::eTwoWire_ThreeWireComp_FourWire:
				if ( 2 == uiCount )
				{
					if ( ( uiConnFlags & uiHi ) && ( uiConnFlags & uiLow ) )
					{
						if ( m_mapREF.size( ) > 0 )
						{
							eConnectBSC = ieee1641::eFourWire;
						}
						else
						{
							eConnectBSC = ieee1641::eTwoWire;
						}
					}
				}
				else if ( 3 == uiCount )
				{
					if ( ( uiConnFlags & uiTrue ) && ( uiConnFlags & uiComp ) && ( uiConnFlags & uiLow ) )
					{
						eConnectBSC = ieee1641::eThreeWireComp;
					}
					else if ( ( uiConnFlags & uiHi ) && ( uiConnFlags & uiLow ) && ( uiConnFlags & uiVia ) )
					{
						if ( Atlas::eVIA == ePinDescriptor )
						{
							eConnectBSC = ieee1641::eSeries;
						}
						else
						{
							eConnectBSC = ieee1641::eTwoWire;
						}
					}
				}
				break;
			case ieee1641::eSinglePhase_TwoPhase_ThreePhaseDelta_ThreePhaseWye:
				if ( 2 == uiCount )
				{
					if ( ( uiConnFlags & uiA ) && ( uiConnFlags & uiN ) )
					{
						eConnectBSC = ieee1641::eSinglePhase;
					}
				}
				else if ( 3 == uiCount )
				{
					if ( ( uiConnFlags & uiA ) && ( uiConnFlags & uiB ) && ( uiConnFlags & uiN ) )
					{
						eConnectBSC = ieee1641::eTwoPhase;
					}
					else if ( ( uiConnFlags & uiA ) && ( uiConnFlags & uiB ) && ( uiConnFlags & uiC ) )
					{
						eConnectBSC = ieee1641::eThreePhaseDelta;
					}
				}
				else if ( 4 == uiCount )
				{
					if ( ( uiConnFlags & uiA ) && ( uiConnFlags & uiB ) && ( uiConnFlags & uiC ) && ( uiConnFlags & uiN ) )
					{
						eConnectBSC = ieee1641::eThreePhaseWye;
					}
				}
				break;
			case ieee1641::eTwoPhase_ThreePhaseDelta_ThreePhaseWye:
				if ( 3 == uiCount )
				{
					if ( ( uiConnFlags & uiA ) && ( uiConnFlags & uiB ) && ( uiConnFlags & uiN ) )
					{
						eConnectBSC = ieee1641::eTwoPhase;
					}
					else if ( ( uiConnFlags & uiA ) && ( uiConnFlags & uiB ) && ( uiConnFlags & uiC ) )
					{
						eConnectBSC = ieee1641::eThreePhaseDelta;
					}
				}
				else if ( 4 == uiCount )
				{
					if ( ( uiConnFlags & uiA ) && ( uiConnFlags & uiB ) && ( uiConnFlags & uiC ) && ( uiConnFlags & uiN ) )
					{
						eConnectBSC = ieee1641::eThreePhaseWye;
					}
				}
				break;
			case ieee1641::eThreePhaseDelta_ThreePhaseWye:
				if ( 3 == uiCount )
				{
					if ( ( uiConnFlags & uiA ) && ( uiConnFlags & uiB ) && ( uiConnFlags & uiC ) )
					{
						eConnectBSC = ieee1641::eThreePhaseDelta;
					}
				}
				else if ( 4 == uiCount )
				{
					if ( ( uiConnFlags & uiA ) && ( uiConnFlags & uiB ) && ( uiConnFlags & uiC ) && ( uiConnFlags & uiN ) )
					{
						eConnectBSC = ieee1641::eThreePhaseWye;
					}
				}
				break;
			case ieee1641::eSinglePhase_TwoPhase_ThreePhaseWye:
				if ( 2 == uiCount )
				{
					if ( ( uiConnFlags & uiA ) && ( uiConnFlags & uiN ) )
					{
						eConnectBSC = ieee1641::eSinglePhase;
					}
				}
				else if ( 3 == uiCount )
				{
					if ( ( uiConnFlags & uiA ) && ( uiConnFlags & uiB ) && ( uiConnFlags & uiN ) )
					{
						eConnectBSC = ieee1641::eTwoPhase;
					}
				}
				else if ( 4 == uiCount )
				{
					if ( ( uiConnFlags & uiA ) && ( uiConnFlags & uiB ) && ( uiConnFlags & uiC ) && ( uiConnFlags & uiN ) )
					{
						eConnectBSC = ieee1641::eThreePhaseWye;
					}
				}
				break;
			case ieee1641::eTwoWireComp_ThreeWireComp:
				if ( 2 == uiCount )
				{
					if ( ( uiConnFlags & uiTrue ) && ( uiConnFlags & uiComp ) )
					{
						eConnectBSC = ieee1641::eTwoWireComp;
					}
				}
				else if ( 3 == uiCount )
				{
					if ( ( uiConnFlags & uiTrue ) && ( uiConnFlags & uiComp ) && ( uiConnFlags & uiLow ) )
					{
						eConnectBSC = ieee1641::eTwoWireComp;
					}
				}
				break;
		}
	}

	return eConnectBSC;
}

void CNX::InitSignalComponents( void )
{
	if ( m_mapCNX.size( ) > 0 )
	{
		map< Atlas::eAtlasPinDescriptor, CNXInfo* >::iterator it = m_mapCNX.begin( );
		map< Atlas::eAtlasPinDescriptor, CNXInfo* >::const_iterator itEnd = m_mapCNX.end( );

		while ( itEnd != it )
		{
			it->second->m_ASC.Set1641Connect( GetConnection1641BSC( it->first, false ) );

			++it;
		}
	}	

	if ( m_mapREF.size( ) > 0 )
	{
		map< Atlas::eAtlasPinDescriptor, CNXInfo* >::iterator it = m_mapREF.begin( );
		map< Atlas::eAtlasPinDescriptor, CNXInfo* >::const_iterator itEnd = m_mapREF.end( );

		while ( itEnd != it )
		{
			it->second->m_ASC.Set1641Connect( GetConnection1641BSC( it->first, true ) );

			++it;
		}
	}	
}

CNX& CNX::operator = ( const CNX& other )
{
	if ( this != &other )
	{
		AtlasAttributes::operator = ( other );

		GarbageCollect( );

		m_mapCNX.clear( );
		m_mapREF.clear( );

		m_eNoun = other.m_eNoun;
		m_bRequireStatement = other.m_bRequireStatement;
		m_strSystemName = other.m_strSystemName;

		if ( other.m_mapCNX.size( ) > 0 )
		{
			map< Atlas::eAtlasPinDescriptor, CNXInfo* >::const_iterator it = other.m_mapCNX.begin( );
			map< Atlas::eAtlasPinDescriptor, CNXInfo* >::const_iterator itEnd = other.m_mapCNX.end( );

			while ( itEnd != it )
			{
				CNXInfo* pCNXInfo = 0;
				
				try
				{
					pCNXInfo = new CNXInfo( *( it->second ) );
				}
				catch ( ... )
				{
					throw Exception( Exception::eFailedToCreateCNXInfoObject, __FILE__, __FUNCTION__, __LINE__ );
				}

				m_mapCNX.insert( make_pair( it->first, pCNXInfo ) );

				++it;
			}
		}

		if ( other.m_mapREF.size( ) > 0 )
		{
			map< Atlas::eAtlasPinDescriptor, CNXInfo* >::const_iterator it = other.m_mapREF.begin( );
			map< Atlas::eAtlasPinDescriptor, CNXInfo* >::const_iterator itEnd = other.m_mapREF.end( );

			while ( itEnd != it )
			{
				CNXInfo* pCNXInfo = 0;
				
				try
				{
					pCNXInfo = new CNXInfo( *( it->second ) );
				}
				catch ( ... )
				{
					throw Exception( Exception::eFailedToCreateCNXInfoObject, __FILE__, __FUNCTION__, __LINE__ );
				}

				m_mapREF.insert( make_pair( it->first, pCNXInfo ) );

				++it;
			}
		}
	}

	return *this;
}

void CNX::Merge( const CNX& other )
{
	if ( this != &other )
	{
		map< Atlas::eAtlasPinDescriptor, CNXInfo* >::const_iterator itEnd = m_mapCNX.end( );
		map< Atlas::eAtlasPinDescriptor, CNXInfo* >::const_iterator itOther = other.m_mapCNX.begin( );
		map< Atlas::eAtlasPinDescriptor, CNXInfo* >::const_iterator itEndOther = other.m_mapCNX.end( );

		while ( itEndOther != itOther )
		{
			if ( itEnd == m_mapCNX.find( itOther->first ) )
			{
				CNXInfo* pCNXInfo = 0;
				
				try
				{
					pCNXInfo = new CNXInfo( *( itOther->second ) );
				}
				catch ( ... )
				{
					throw Exception( Exception::eFailedToCreateCNXInfoObject, __FILE__, __FUNCTION__, __LINE__ );
				}

				m_mapCNX.insert( make_pair( itOther->first, pCNXInfo ) );
			}

			++itOther;
		}

		itEnd = m_mapREF.end( );
		itOther = other.m_mapREF.begin( );
		itEndOther = other.m_mapREF.end( );

		while ( itEndOther != itOther )
		{
			if ( itEnd == m_mapREF.find( itOther->first ) )
			{
				CNXInfo* pCNXInfo = 0;
				
				try
				{
					pCNXInfo = new CNXInfo( *( itOther->second ) );
				}
				catch ( ... )
				{
					throw Exception( Exception::eFailedToCreateCNXInfoObject, __FILE__, __FUNCTION__, __LINE__ );
				}

				m_mapREF.insert( make_pair( itOther->first, pCNXInfo ) );
			}

			++itOther;
		}
	}
}

void CNX::CNXInfo::ToXML( string& strXML ) const
{
	if ( m_mapVirtualToPhysicalConn.size( ) > 0 )
	{
		map< string, set< string > >::const_iterator it = m_mapVirtualToPhysicalConn.begin( );
		const map< string, set< string > >::const_iterator itEnd = m_mapVirtualToPhysicalConn.end( );
	
		strXML += XML::MakeOpenXmlElementWithChildren( XML::enDescriptors );

		while ( itEnd != it )
		{
			const set< string>& setPins = it->second;
			string strAttribute1( XML::MakeXmlAttributeNameValue( XML::anName, it->first ) );
			string strAttribute2;
			string strAttribute3;

			if ( m_uiVirtualDataType & eVariable )
			{
				strAttribute2 = XML::MakeXmlAttributeNameValue( XML::anVariable, XML::avTrue );
			}

			if ( m_uiVirtualDataType & eDimension )
			{
				strAttribute3 = XML::MakeXmlAttributeNameValue( XML::anDimension, XML::avTrue );
			}

			strXML += XML::MakeOpenXmlElementWithChildren( XML::enDescriptor, strAttribute1, strAttribute2, strAttribute3 );

			if ( setPins.size( ) > 0 )
			{
				set< string >::const_iterator itPins = setPins.begin( );
				const set< string >::const_iterator itPinsEnd = setPins.end( );

				strXML += XML::MakeOpenXmlElementWithChildren( XML::enPins );

				while ( itPinsEnd != itPins )
				{
					strAttribute1 = XML::MakeXmlAttributeNameValue( XML::anName, *itPins );

					if ( m_uiVirtualPhysicalDataType & eVariable )
					{
						strAttribute2 = XML::MakeXmlAttributeNameValue( XML::anVariable, XML::avTrue );
					}
		
					if ( m_uiVirtualPhysicalDataType & eDimension )
					{
						strAttribute3 = XML::MakeXmlAttributeNameValue( XML::anDimension, XML::avTrue );
					}

					strXML += XML::MakeXmlElementNoChildren( XML::enPin, strAttribute1, strAttribute2, strAttribute3 );

					++itPins;
				}

				strXML += XML::MakeCloseXmlElementWithChildren( XML::enPins );
			}

			strXML += XML::MakeCloseXmlElementWithChildren( XML::enDescriptor );

			++it;
		}

		strXML += XML::MakeCloseXmlElementWithChildren( XML::enDescriptors );
	}
}