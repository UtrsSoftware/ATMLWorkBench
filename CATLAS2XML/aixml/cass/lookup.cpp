/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

#include "../cass/lookup.h"
#include "../helper.h"
#include "../aixml.h"
#include "../atlas.h"

// Xercesc XML Parser
#include <xercesc/dom/dom.hpp>

#if ( _DEBUG ) && ( WIN32 )
	#define WINVER 0x0600
	#include <afx.h>
	#define new DEBUG_NEW
	#undef THIS_FILE
	static char BASED_CODE THIS_FILE[ ] = __FILE__;
#endif

using namespace XERCES_CPP_NAMESPACE;


Lookup& Lookup::operator = ( const Lookup& other )
{
	if ( this != &other )
	{
		GarbageCollect( );

		map< int, Subfile* >::const_iterator it = other.m_mapSubfiles.begin( );
		const map< int, Subfile* >::const_iterator itEnd = other.m_mapSubfiles.end( );
	
		while ( it != itEnd )
		{
			Subfile* pSubfile = Lookup::AddSubfile( it->first );

			*pSubfile = *( it->second );
	
			it++;
		}
	}

	return *this;
}

void Lookup::Merge( const Lookup& other )
{
	if ( this != &other )
	{
		const int arraySubfileIds[ ] = { 1, 2, 5, 6, 7, 10 };
		const int iSubfileCount = ( sizeof( arraySubfileIds ) / sizeof( int ) );

		for ( int i = 0; i < iSubfileCount; i++ )
		{
			Subfile* pPrimarySubfile = GetSubfile( arraySubfileIds[ i ] );
			Subfile* pOtherSubfile = other.GetSubfile( arraySubfileIds[ i ] );
			const bool bPrimarySubfileExists = ( 0 != pPrimarySubfile );
			const bool bOtherSubfileExists = ( 0 != pOtherSubfile );

			if ( bPrimarySubfileExists || bOtherSubfileExists )
			{
				if ( bPrimarySubfileExists && bOtherSubfileExists )
				{
					pPrimarySubfile->Merge( *( pOtherSubfile ) );
				}
				else if ( bOtherSubfileExists )
				{
					AddSubfile( pOtherSubfile->m_iSubfileId )->Merge( *( pOtherSubfile ) );
				}
			}
		}
	}
}

Lookup::Subfile* Lookup::AddSubfile( const int iSubfileId )
{
	Subfile* pSubfile = Subfile::SubfileFactory( iSubfileId );

	if ( 0 == pSubfile )
	{
		throw Exception( Exception::eFailedToAllocateMemoryForNewpSubfileObject, __FILE__, __FUNCTION__, __LINE__ );
	}

	if ( m_mapSubfiles.end( ) != m_mapSubfiles.find( pSubfile->m_iSubfileId ) )
	{
		delete pSubfile;

		throw Exception( Exception::eDuplicateSubfileId, __FILE__, __FUNCTION__, __LINE__, AIXMLHelper::NumberToString< int >( pSubfile->m_iSubfileId ) );
	}

	m_mapSubfiles.insert( make_pair( pSubfile->m_iSubfileId, pSubfile ) );

	return pSubfile;
}


Lookup::Subfile* Lookup::GetSubfile( const int iSubfileId ) const
{
	Subfile* pSubfile = 0;
	const map< int, Subfile* >::const_iterator it = m_mapSubfiles.find( iSubfileId );

	if ( m_mapSubfiles.end( ) != it )
	{
		pSubfile = it->second;
	}

	return pSubfile;
}

void Lookup::GarbageCollect( void )
{
	map< int, Subfile* >::const_iterator it = m_mapSubfiles.begin( );
	const map< int, Subfile* >::const_iterator itEnd = m_mapSubfiles.end( );

	while ( it != itEnd )
	{
		delete it->second;

		it++;
	}

	m_mapSubfiles.clear( );
}

void Lookup::ProcessSubfile( const xercesc::DOMElement* pAIXMLvalue )
{
	const DOMNodeList* pAIXML_NodeList = pAIXMLvalue->getChildNodes( );

	if ( 0 == pAIXML_NodeList )
	{
		throw Exception( Exception::eFailedToGetSubfileChildNodes, __FILE__, __FUNCTION__, __LINE__ );
	}

	const XMLSize_t iMaxNodes = pAIXML_NodeList->getLength( );

	if ( 0 == iMaxNodes )
	{
		throw Exception( Exception::eInvalidNumberOfSubfileNodes, __FILE__, __FUNCTION__, __LINE__ );
	}

	const string strSubfileNum( AIXMLHelper::GetXercesString( pAIXMLvalue->getAttribute( AIXMLHelper::GetWString( AIXML::m_arrayXMLKeyWords[ AIXML::eNumAttribute ] ).c_str( ) ) ) );

	if ( !AIXMLHelper::IsUnsignedWholeNumber( strSubfileNum ) )
	{
		throw Exception( Exception::eInvalidSubfileNumber, __FILE__, __FUNCTION__, __LINE__ );
	}

	Lookup::Subfile* pSubfile = AddSubfile( AIXMLHelper::StringToNumber< int >( strSubfileNum ) );

	if ( ( 2 == pSubfile->m_iSubfileId ) || ( 10 == pSubfile->m_iSubfileId ) )
	{
		const map< int, Lookup::Subfile* >::const_iterator it = m_mapSubfiles.find( 1 );

		if ( m_mapSubfiles.end( ) == it )
		{
			throw Exception( Exception::eSubfile1SectionMustComeFirst, __FILE__, __FUNCTION__, __LINE__ );
		}

		if ( 2 == pSubfile->m_iSubfileId )
		{
			( ( Lookup::Subfile2* ) pSubfile )->m_pmapCassToAtlas = &( ( ( Lookup::Subfile1* ) it->second )->m_mapCassToAtlas );
			( ( Lookup::Subfile2* ) pSubfile )->m_pmapAtlasToCass = &( ( ( Lookup::Subfile1* ) it->second )->m_mapAtlasToCass );
		}
		else
		{
			( ( Lookup::Subfile10* ) pSubfile )->m_pmapCassToAtlas = &( ( ( Lookup::Subfile1* ) it->second )->m_mapCassToAtlas );
			( ( Lookup::Subfile10* ) pSubfile )->m_pmapAtlasToCass = &( ( ( Lookup::Subfile1* ) it->second )->m_mapAtlasToCass );
		}
	}

	string strAIXMLtagName;

	for ( XMLSize_t iCurrentNode = 0; iCurrentNode < iMaxNodes; iCurrentNode++ )
	{
		pAIXMLvalue = ( xercesc::DOMElement* ) pAIXML_NodeList->item( iCurrentNode );

		if ( 0 == pAIXMLvalue )
		{
			throw Exception( Exception::eFailedToGetXercesNodeListItem, __FILE__, __FUNCTION__, __LINE__ );
		}

		if ( xercesc::DOMNode::COMMENT_NODE == pAIXMLvalue->getNodeType( ) )
		{
			continue;
		}

		AIXMLHelper::GetXercesString( pAIXMLvalue->getTagName( ), strAIXMLtagName );

		if ( !strAIXMLtagName.empty( ) )
		{
			if ( AIXML::m_arrayXMLKeyWords[ AIXML::eMappingElement ] == strAIXMLtagName )
			{
				pSubfile->CreateSubfileMapping( pAIXMLvalue );
			}
		}
	}
}

string Lookup::GetSystemName( const string& strLabelName, const bool bThrowIfNotFound ) const
{
	string strSystemName;

	if ( !strLabelName.empty( ) )
	{
		const Subfile1* pSubfile1 = dynamic_cast< Subfile1* >( GetSubfile( 1 ) );

		if ( 0 == pSubfile1 )
		{
			throw Exception( Exception::eCannotFindPrimarySubfile1Object, __FILE__, __FUNCTION__, __LINE__ );
		}

		strSystemName = pSubfile1->GetSystemName( strLabelName );

		if ( bThrowIfNotFound && strSystemName.empty( ) )
		{
			throw Exception( Exception::eCannotFindPrimarySubfile1Label, __FILE__, __FUNCTION__, __LINE__, strLabelName );
		}
	}

	return strSystemName;
}

SpecificInstrument::eInstrument Lookup::GetInstrumentEnum( const string& strLabelName, const bool bThrowIfNotFound ) const
{
	SpecificInstrument::eInstrument eInstr = SpecificInstrument::eUnknownInstrument;

	if ( !strLabelName.empty( ) )
	{
		const Subfile1* pSubfile1 = dynamic_cast< Subfile1* >( GetSubfile( 1 ) );

		if ( 0 == pSubfile1 )
		{
			throw Exception( Exception::eCannotFindPrimarySubfile1Object, __FILE__, __FUNCTION__, __LINE__ );
		}

		eInstr = pSubfile1->GetInstrumentEnum( strLabelName );

		if ( bThrowIfNotFound && ( SpecificInstrument::eUnknownInstrument == eInstr ) )
		{
			throw Exception( Exception::eCannotFindPrimarySubfile1Label, __FILE__, __FUNCTION__, __LINE__, strLabelName );
		}
	}

	return eInstr;
}

Lookup::Subfile* Lookup::Subfile::SubfileFactory( const int iSubfileId )
{
	Subfile* pSubfile = 0;

	// NOTE: Per CASS documentation, SUBFILE 3, 4, 8, and 9 are not used

	try
	{
		switch ( iSubfileId )
		{
			case 1:
				pSubfile = new Subfile1;
				break;
	
			case 2:
				pSubfile = new Subfile2;
				break;
	
			case 5:
				pSubfile = new Subfile5;
				break;
	
			case 6:
				pSubfile = new Subfile6;
				break;
	
			case 7:
				pSubfile = new Subfile7;
				break;
	
			case 10:
				pSubfile = new Subfile10;
				break;
	
			default:
				throw Exception( Exception::eUnknownSubfileType, __FILE__, __FUNCTION__, __LINE__, AIXMLHelper::NumberToString< int >( iSubfileId ) );
				break;
		}
	}
	catch ( ... )
	{
		// No throw, caller throws
	}

	if ( 0 != pSubfile )
	{
		pSubfile->m_iSubfileId = iSubfileId;
	}

	return pSubfile;
}

void Lookup::Subfile1::GarbageCollect( void )
{
	if ( m_mapCassToAtlas.size( ) > 0 )
	{
		map< string, set< string >* >::const_iterator it = m_mapCassToAtlas.begin( );
		const map< string, set< string >* >::const_iterator itEnd = m_mapCassToAtlas.end( );

		while ( it != itEnd )
		{
			delete it->second;

			it++;
		}

		m_mapCassToAtlas.clear( );
	}
}


void Lookup::Subfile2::GarbageCollect( void )
{
	if ( m_mapCassToPinInfo.size( ) > 0 )
	{
		map< string, PinInfo* >::const_iterator it = m_mapCassToPinInfo.begin( );
		const map< string, PinInfo* >::const_iterator itEnd = m_mapCassToPinInfo.end( );

		while ( it != itEnd )
		{
			delete it->second;

			it++;
		}
	}
}


void Lookup::Subfile6::GarbageCollect( void )
{
	if ( m_mapEventToPinDescriptor.size( ) > 0 )
	{
		map< string, set< string >* >::const_iterator it = m_mapEventToPinDescriptor.begin( );
		const map< string, set< string >* >::const_iterator itEnd = m_mapEventToPinDescriptor.end( );

		while ( it != itEnd )
		{
			delete it->second;

			it++;
		}

		m_mapEventToPinDescriptor.clear( );
	}
}

void Lookup::Subfile10::GarbageCollect( void )
{
	if ( m_mapCassToPinInfo.size( ) > 0 )
	{
		map< string, PinInfo* >::const_iterator it = m_mapCassToPinInfo.begin( );
		const map< string, PinInfo* >::const_iterator itEnd = m_mapCassToPinInfo.end( );

		while ( it != itEnd )
		{
			delete it->second;

			it++;
		}
	}
}


string Lookup::Subfile1::GetSystemName( const string& strLabelName ) const
{
	const map< string, string >::const_iterator it = m_mapAtlasToCass.find( strLabelName );
	const map< string, string >::const_iterator itEnd = m_mapAtlasToCass.end( );
	string strSystemName;

	if ( itEnd != it )
	{
		strSystemName = it->second;
	}

	return strSystemName;
}

SpecificInstrument::eInstrument Lookup::Subfile1::GetInstrumentEnum( const string& strLabelName ) const
{
	const map< string, SpecificInstrument::eInstrument >::const_iterator it = m_mapAtlasToInstrumentEnum.find( strLabelName );
	const map< string, SpecificInstrument::eInstrument >::const_iterator itEnd = m_mapAtlasToInstrumentEnum.end( );
	SpecificInstrument::eInstrument eInstr = SpecificInstrument::eUnknownInstrument;

	if ( itEnd != it )
	{
		eInstr = it->second;
	}

	return eInstr;
}

void Lookup::Subfile1::CreateSubfileMapping( const DOMElement* pAIXMLvalue )
{
	const DOMNodeList* pAIXML_NodeList = pAIXMLvalue->getChildNodes( );

	if ( 0 == pAIXML_NodeList )
	{
		throw Exception( Exception::eFailedToGetMappingChildNodes, __FILE__, __FUNCTION__, __LINE__ );
	}

	const XMLSize_t iMaxNodes = pAIXML_NodeList->getLength( );

	if ( 0 == iMaxNodes )
	{
		throw Exception( Exception::eInvalidNumberOfMappingNodes, __FILE__, __FUNCTION__, __LINE__ );
	}

	string strAIXMLtagName;
	string strAtlasName;
	string strCassName;

	for ( XMLSize_t iCurrentNode = 0; iCurrentNode < iMaxNodes; iCurrentNode++ )
	{
		pAIXMLvalue = ( xercesc::DOMElement* ) pAIXML_NodeList->item( iCurrentNode );

		if ( 0 == pAIXMLvalue )
		{
			throw Exception( Exception::eFailedToGetXercesNodeListItem, __FILE__, __FUNCTION__, __LINE__ );
		}

		if ( xercesc::DOMNode::COMMENT_NODE == pAIXMLvalue->getNodeType( ) )
		{
			continue;
		}

		AIXMLHelper::GetXercesString( pAIXMLvalue->getTagName( ), strAIXMLtagName );

		if ( !strAIXMLtagName.empty( ) )
		{
			if ( AIXML::m_arrayXMLKeyWords[ AIXML::eArgumentElement ] == strAIXMLtagName )
			{
				if ( strAtlasName.empty( ) )
				{
					AIXMLHelper::GetXercesString( pAIXMLvalue->getAttribute( AIXMLHelper::GetWString( AIXML::m_arrayXMLKeyWords[ AIXML::eNameAttribute ] ).c_str( ) ), strAtlasName );
				}
				else if ( strCassName.empty( ) )
				{
					AIXMLHelper::GetXercesString( pAIXMLvalue->getAttribute( AIXMLHelper::GetWString( AIXML::m_arrayXMLKeyWords[ AIXML::eNameAttribute ] ).c_str( ) ), strCassName );
				}
				else
				{
					throw Exception( Exception::eMoreThanTwoMappingsArgumentsWereFoundSubfile1, __FILE__, __FUNCTION__, __LINE__ );
				}
			}
		}
	}

	if ( strAtlasName.empty( ) )
	{
		throw Exception( Exception::eCannotFindAtlasNameForMappingSubfile1, __FILE__, __FUNCTION__, __LINE__ );
	}

	if ( strCassName.empty( ) )
	{
		throw Exception( Exception::eCannotFindCassNameForMappingSubfile1, __FILE__, __FUNCTION__, __LINE__ );
	}

	AddMapping( strAtlasName, strCassName );
}

Lookup::Subfile& Lookup::Subfile1::operator = ( const Lookup::Subfile& other )
{
	if ( this != &other )
	{
		if ( m_iSubfileId == other.m_iSubfileId )
		{
			const Subfile1& otherSub1 = ( Subfile1& ) other;

			m_mapAtlasToCass = otherSub1.m_mapAtlasToCass;
			m_mapAtlasToInstrumentEnum = otherSub1.m_mapAtlasToInstrumentEnum;

			map< string, set< string >* >::const_iterator it = otherSub1.m_mapCassToAtlas.begin( );
			const map< string, set< string >* >::const_iterator itEnd = otherSub1.m_mapCassToAtlas.end( );
			set< string >* psetAtlasNames = 0;
		
			while ( it != itEnd )
			{
				try
				{
					psetAtlasNames = new set< string >( );
				}
				catch ( ... )
				{
					throw Exception( Exception::eFailedToAllocateMemoryForNewAtlasSetSubfile1, __FILE__, __FUNCTION__, __LINE__ );
				}
		
				m_mapCassToAtlas.insert( make_pair( it->first, psetAtlasNames ) );

				*psetAtlasNames = *( it->second );

				it++;
			}
		}
	}

	return *this;
}

void Lookup::Subfile1::AddMapping( const string& strAtlasName, const string& strCassName )
{
	if ( m_mapAtlasToCass.end( ) != m_mapAtlasToCass.find( strAtlasName ) )
	{
		throw Exception( Exception::eDuplicateAtlasNameInMappingSubfile1, __FILE__, __FUNCTION__, __LINE__, strAtlasName );
	}

	SpecificInstrument::eInstrument eInstr = SpecificInstrument::GetInstrument( strCassName, true );

	if ( SpecificInstrument::eUnknownInstrument == eInstr )
	{
		throw Exception( Exception::eCannotFindSystemNameEnumBySystemName, __FILE__, __FUNCTION__, __LINE__, strCassName );
	}

	if ( m_mapAtlasToInstrumentEnum.end( ) == m_mapAtlasToInstrumentEnum.find( strAtlasName ) )
	{
		m_mapAtlasToInstrumentEnum.insert( make_pair( strAtlasName, eInstr ) );
	}

	m_mapAtlasToCass.insert( make_pair( strAtlasName, strCassName ) );

	set< string >* psetAtlasNames = 0;
	const map< string, set< string >* >::const_iterator it = m_mapCassToAtlas.find( strCassName );

	if ( m_mapCassToAtlas.end( ) == it )
	{
		try
		{
			psetAtlasNames = new set< string >( );
		}
		catch ( ... )
		{
			throw Exception( Exception::eFailedToAllocateMemoryForNewAtlasSetSubfile1, __FILE__, __FUNCTION__, __LINE__ );
		}

		m_mapCassToAtlas.insert( make_pair( strCassName, psetAtlasNames ) );
	}
	else
	{
		psetAtlasNames = it->second;
	}

	psetAtlasNames->insert( strAtlasName );
}

void Lookup::Subfile1::Merge( const Subfile& other )
{
	if ( this != &other )
	{
		if ( 1 != other.m_iSubfileId )
		{
			string strError( "Was expecting SUBFILE 1, found SUBFILE " );

			strError += AIXMLHelper::NumberToString< int >( other.m_iSubfileId );

			throw Exception( Exception::eUnexpectedSubfileId, __FILE__, __FUNCTION__, __LINE__, strError );
		}

		Subfile1* pOtherSubfile1 = ( Subfile1* ) &other;

		if ( pOtherSubfile1->m_mapAtlasToCass.size( ) > 0 )
		{
			map< string, string >::const_iterator itA2COther = pOtherSubfile1->m_mapAtlasToCass.begin( );
			const map< string, string >::const_iterator itA2CEndOther = pOtherSubfile1->m_mapAtlasToCass.end( );
			const map< string, string >::const_iterator itA2CEnd = m_mapAtlasToCass.end( );
			map< string, set< string >* >::const_iterator itC2AOther = pOtherSubfile1->m_mapCassToAtlas.begin( );
			const map< string, set< string >* >::const_iterator itC2AEndOther = pOtherSubfile1->m_mapCassToAtlas.end( );
			map< string, set< string >* >::const_iterator itC2A;
			const map< string, set< string >* >::const_iterator itC2AEnd = m_mapCassToAtlas.end( );

			map< string, SpecificInstrument::eInstrument >::const_iterator itA2IOther = pOtherSubfile1->m_mapAtlasToInstrumentEnum.begin( );
			const map< string, SpecificInstrument::eInstrument >::const_iterator itA2IEndOther = pOtherSubfile1->m_mapAtlasToInstrumentEnum.end( );
			const map< string, SpecificInstrument::eInstrument >::const_iterator itA2IEnd = m_mapAtlasToInstrumentEnum.end( );

			while ( itA2IEndOther != itA2IOther )
			{
				if ( itA2IEnd == m_mapAtlasToInstrumentEnum.find( itA2IOther->first ) )
				{
					m_mapAtlasToInstrumentEnum.insert( make_pair( itA2IOther->first, itA2IOther->second ) );
				}

				++itA2IOther;
			}

			while ( itA2CEndOther != itA2COther )
			{
				if ( itA2CEnd == m_mapAtlasToCass.find( itA2COther->first ) )
				{
					m_mapAtlasToCass.insert( make_pair( itA2COther->first, itA2COther->second ) );
				}

				++itA2COther;
			}

			while ( itC2AEndOther != itC2AOther )
			{
				itC2A = m_mapCassToAtlas.find( itC2AOther->first );

				if ( itC2AEnd == itC2A )
				{
					set< string >* pSet = 0;
					
					try
					{
						pSet = new set< string >( );
					}
					catch ( ... )
					{
						throw Exception( Exception::eFailedToAllocateMemoryForNewAtlasSetSubfile1, __FILE__, __FUNCTION__, __LINE__ );
					}

					m_mapCassToAtlas.insert( make_pair( itC2AOther->first, pSet ) );

					*pSet = *( itC2AOther->second );
				}
				else
				{
					set< string >* pSet = itC2A->second;
					const set< string >* pOtherSet = itC2AOther->second;

					set< string >::const_iterator itOtherSet = pOtherSet->begin( );
					const set< string >::const_iterator itEndOtherSet = pOtherSet->end( );
					const set< string >::const_iterator itEndSet = pSet->end( );

					while ( itEndOtherSet != itOtherSet )
					{
						if ( itEndSet == pSet->find( *itOtherSet ) )
						{
							pSet->insert( *itOtherSet );
						}

						++itOtherSet;
					}
				}

				++itC2AOther;
			}
		}
	}
}

void Lookup::Subfile2::CreateSubfileMapping( const DOMElement* pAIXMLvalue )
{
	const DOMNodeList* pAIXML_NodeList = pAIXMLvalue->getChildNodes( );

	if ( 0 == pAIXML_NodeList )
	{
		throw Exception( Exception::eFailedToGetMappingChildNodes, __FILE__, __FUNCTION__, __LINE__ );
	}

	const XMLSize_t iMaxNodes = pAIXML_NodeList->getLength( );

	if ( 0 == iMaxNodes )
	{
		throw Exception( Exception::eInvalidNumberOfMappingNodes, __FILE__, __FUNCTION__, __LINE__ );
	}

	string strAIXMLtagName;
	string strName;
	set< string >* pPins = 0;

	for ( XMLSize_t iCurrentNode = 0; iCurrentNode < iMaxNodes; iCurrentNode++ )
	{
		pAIXMLvalue = ( xercesc::DOMElement* ) pAIXML_NodeList->item( iCurrentNode );

		if ( 0 == pAIXMLvalue )
		{
			throw Exception( Exception::eFailedToGetXercesNodeListItem, __FILE__, __FUNCTION__, __LINE__ );
		}

		if ( xercesc::DOMNode::COMMENT_NODE == pAIXMLvalue->getNodeType( ) )
		{
			continue;
		}

		AIXMLHelper::GetXercesString( pAIXMLvalue->getTagName( ), strAIXMLtagName );

		if ( !strAIXMLtagName.empty( ) )
		{
			if ( AIXML::m_arrayXMLKeyWords[ AIXML::eArgumentElement ] == strAIXMLtagName )
			{
				AIXMLHelper::GetXercesString( pAIXMLvalue->getAttribute( AIXMLHelper::GetWString( AIXML::m_arrayXMLKeyWords[ AIXML::eNameAttribute ] ).c_str( ) ), strName );

				if ( strName.empty( ) )
				{
					throw Exception( Exception::eEmptyMappingSubfile2, __FILE__, __FUNCTION__, __LINE__ );
				}

				if ( 0 == pPins )
				{
					pPins = AddMapping( strName );
				}
				else
				{
					pPins->insert( strName );
				}
			}
		}
	}
}

Lookup::Subfile& Lookup::Subfile2::operator = ( const Lookup::Subfile& other )
{
	if ( this != &other )
	{
		if ( m_iSubfileId == other.m_iSubfileId )
		{
			const Subfile2& otherSub2 = ( Subfile2& ) other;

			m_pmapCassToAtlas = otherSub2.m_pmapCassToAtlas;
			m_pmapAtlasToCass = otherSub2.m_pmapAtlasToCass;

			map< string, PinInfo* >::const_iterator it = otherSub2.m_mapCassToPinInfo.begin( );
			const map< string, PinInfo* >::const_iterator itEnd = otherSub2.m_mapCassToPinInfo.end( );
			PinInfo* pPinInfo = 0;
		
			while ( it != itEnd )
			{
				try
				{
					pPinInfo = new PinInfo;
				}
				catch ( ... )
				{
					throw Exception( Exception::eFailedToAllocateMemoryForNewPinInfoObjectSubfile2, __FILE__, __FUNCTION__, __LINE__ );
				}
		
				m_mapCassToPinInfo.insert( make_pair( it->first, pPinInfo ) );

				pPinInfo->m_mapPins = it->second->m_mapPins;

				it++;
			}
		}
	}

	return *this;
}

set< string >* Lookup::Subfile2::AddMapping( const string& strSystemNameCombo, map< string, PinInfo* >& mapCassToPinInfo, const map< string, set< string >* >* pmapCassToAtlas, const map< string, string >* pmapAtlasToCass, const Exception::eErrorType e1, const Exception::eErrorType e2, const Exception::eErrorType e3, const Exception::eErrorType e4 )
{
	static const string arrayInstruments[ ]  = { "SHORT", "NORMAL-VIDEO" };
	static const int iInstrumentCount = ( sizeof( arrayInstruments ) / sizeof( string ) );
	static const int iNormalVideoPos = 1;
	map< string, set< string >* >::const_iterator itC2A = pmapCassToAtlas->end( );
	const map< string, set< string >* >::const_iterator itC2ABegin = pmapCassToAtlas->begin( );
	set< string >* pPins = 0;
	PinInfo* pPinInfo = 0;
	bool bNormalVideo = false;
	string strTemp( strSystemNameCombo );
	string strSystemName;
	string strUserPinName;
	Atlas::eAtlasPinDescriptor eCNXDescriptor = Atlas::eUnknownAtlasPinDescriptor;

	do
	{
		--itC2A;

		if ( 0 == strTemp.compare( 0, itC2A->first.size( ), itC2A->first ) )
		{
			strSystemName = itC2A->first;

			strTemp = strTemp.substr( itC2A->first.size( ) );

			if ( !strTemp.empty( ) )
			{
				for ( int i = Atlas::eHI; i <= ( int ) Atlas::eS4; i++ )
				{
					const string& strPinDescriptor = Atlas::GetAtlasPinDescriptor( ( Atlas::eAtlasPinDescriptor ) i );

					if ( 0 == strTemp.compare( 0, strPinDescriptor.size( ), strPinDescriptor ) )
					{
						eCNXDescriptor = ( Atlas::eAtlasPinDescriptor ) i;
	
						strUserPinName = strTemp.substr( strPinDescriptor.size( ) );
	
						if ( strUserPinName.empty( ) )
						{
							throw Exception( e4, __FILE__, __FUNCTION__, __LINE__, strSystemNameCombo );
						}
	
						break;
					}
				}
			}

			break;
		}

	} while ( itC2A != itC2ABegin );


	if ( !strSystemName.empty( ) && ( Atlas::eUnknownAtlasPinDescriptor == eCNXDescriptor ) )
	{
		map< string, string >::const_iterator itA2C = pmapAtlasToCass->end( );
		const map< string, string >::const_iterator itA2CBegin = pmapAtlasToCass->begin( );

		strSystemName.clear( );
		strUserPinName.clear( );

		strTemp = strSystemNameCombo;

		do
		{
			--itA2C;
	
			if ( 0 == strTemp.compare( 0, itA2C->first.size( ), itA2C->first ) )
			{
				strSystemName = itA2C->first;
	
				strTemp = strTemp.substr( itA2C->first.size( ) );
	
				if ( !strTemp.empty( ) )
				{
					for ( int i = Atlas::eHI; i <= ( int ) Atlas::eS4; i++ )
					{
						const string& strPinDescriptor = Atlas::GetAtlasPinDescriptor( ( Atlas::eAtlasPinDescriptor ) i );

						if ( 0 == strTemp.compare( 0, strPinDescriptor.size( ), strPinDescriptor ) )
						{
							eCNXDescriptor = ( Atlas::eAtlasPinDescriptor ) i;
		
							strUserPinName = strTemp.substr( strPinDescriptor.size( ) );
		
							if ( strUserPinName.empty( ) )
							{
								throw Exception( e4, __FILE__, __FUNCTION__, __LINE__, strSystemNameCombo );
							}
		
							break;
						}
					}
				}
	
				break;
			}
	
		} while ( itA2C != itA2CBegin );
	}

	if ( strSystemName.empty( ) )
	{
		const SpecificInstrument::eInstrument eInstrType = SpecificInstrument::GetInstrument( strSystemNameCombo, true, &strSystemName );
	
		if ( SpecificInstrument::eUnknownInstrument != eInstrType )
		{
			strTemp = strTemp.substr( strSystemName.size( ) );

			if ( !strTemp.empty( ) )
			{
				for ( int i = Atlas::eHI; i <= ( int ) Atlas::eS4; i++ )
				{
					const string& strPinDescriptor = Atlas::GetAtlasPinDescriptor( ( Atlas::eAtlasPinDescriptor ) i );

					if ( 0 == strTemp.compare( 0, strPinDescriptor.size( ), strPinDescriptor ) )
					{
						eCNXDescriptor = ( Atlas::eAtlasPinDescriptor ) i;
	
						strUserPinName = strTemp.substr( strPinDescriptor.size( ) );
	
						if ( strUserPinName.empty( ) )
						{
							throw Exception( e4, __FILE__, __FUNCTION__, __LINE__, strSystemNameCombo );
						}
	
						break;
					}
				}
			}
		}
	}

	if ( strSystemName.empty( ) )
	{
		for ( int i = 0; i < iInstrumentCount; i++ )
		{
			if ( 0 == strTemp.compare( 0, arrayInstruments[ i ].size( ), arrayInstruments[ i ] ) )
			{
				strSystemName = arrayInstruments[ i ];

				if ( iNormalVideoPos == i )
				{
					bNormalVideo = true;
				}
	
				strTemp = strTemp.substr( arrayInstruments[ i ].size( ) );

				if ( !strTemp.empty( ) )
				{
					for ( int i = Atlas::eHI; i <= ( int ) Atlas::eS4; i++ )
					{
						const string& strPinDescriptor = Atlas::GetAtlasPinDescriptor( ( Atlas::eAtlasPinDescriptor ) i );

						if ( 0 == strTemp.compare( 0, strPinDescriptor.size( ), strPinDescriptor ) )
						{
							eCNXDescriptor = ( Atlas::eAtlasPinDescriptor ) i;
		
							strUserPinName = strTemp.substr( strPinDescriptor.size( ) );
		
							if ( strUserPinName.empty( ) )
							{
								throw Exception( e4, __FILE__, __FUNCTION__, __LINE__, strSystemNameCombo );
							}
		
							break;
						}
					}
				}
	
				break;
			}
		}
	}

	if ( strSystemName.empty( ) )
	{
		throw Exception( e2, __FILE__, __FUNCTION__, __LINE__, strSystemNameCombo );
	}

	if ( Atlas::eUnknownAtlasPinDescriptor == eCNXDescriptor )
	{
		if ( !bNormalVideo )
		{
			throw Exception( e1, __FILE__, __FUNCTION__, __LINE__, strSystemNameCombo );
		}
	}

	if ( strUserPinName.empty( ) )
	{
		if ( !bNormalVideo )
		{
			throw Exception( e4, __FILE__, __FUNCTION__, __LINE__, strSystemNameCombo );
		}
	}

	const map< string, PinInfo* > ::const_iterator itCass = mapCassToPinInfo.find( strSystemName );	

	if ( mapCassToPinInfo.end( ) == itCass )
	{
		try
		{
			pPinInfo = new PinInfo;
		}
		catch ( ... )
		{
			throw Exception( e3, __FILE__, __FUNCTION__, __LINE__ );
		}

		mapCassToPinInfo.insert( make_pair( strSystemName, pPinInfo ) );
	}
	else
	{
		pPinInfo = itCass->second;
	}

	const map< Atlas::eAtlasPinDescriptor, map< string, set< string > > >::iterator itPins = pPinInfo->m_mapPins.find( eCNXDescriptor );

	if ( pPinInfo->m_mapPins.end( ) == itPins )
	{
		#pragma warning( disable:4503 )

		pair< map< Atlas::eAtlasPinDescriptor, map< string, set< string > > >::iterator, bool > pr1 = pPinInfo->m_mapPins.insert( make_pair( eCNXDescriptor, map< string, set< string > >( ) ) );

		const pair< map< string, set< string > >::iterator, bool > pr2 = pr1.first->second.insert( make_pair( strUserPinName, set< string >( ) ) );

		pPins = &( pr2.first->second );
	}
	else
	{
		const pair< map< string, set< string > >::iterator, bool > pr = itPins->second.insert( make_pair( strUserPinName, set< string >( ) ) );

		pPins = &( pr.first->second );
	}

	return pPins;
}

set< string >* Lookup::Subfile2::AddMapping( const string& strSystemNameCombo )
{
	return AddMapping( strSystemNameCombo, 
		m_mapCassToPinInfo, 
		m_pmapCassToAtlas, 
		m_pmapAtlasToCass, 
		Exception::eUnknownOrMissingCNXTypeInSubfile2,
		Exception::eUnknownOrMissingSystemNameInSubfile2, 
		Exception::eFailedToAllocateMemoryForNewPinInfoObjectSubfile2,
		Exception::eUnknownOrMissingNameInSubfile2 );
}

void Lookup::Subfile2::Merge( const Subfile& other )
{
	if ( this != &other )
	{
		if ( 2 != other.m_iSubfileId )
		{
			string strError( "Was expecting SUBFILE 2, found SUBFILE " );

			strError += AIXMLHelper::NumberToString< int >( other.m_iSubfileId );

			throw Exception( Exception::eUnexpectedSubfileId, __FILE__, __FUNCTION__, __LINE__, strError );
		}

		Subfile2* pOtherSubfile2 = ( Subfile2* ) &other;

		if ( pOtherSubfile2->m_mapCassToPinInfo.size( ) > 0 )
		{
			map< string, PinInfo* >::const_iterator itC2POther = pOtherSubfile2->m_mapCassToPinInfo.begin( );
			const map< string, PinInfo* >::const_iterator itC2PEndOther = pOtherSubfile2->m_mapCassToPinInfo.end( );
			map< string, PinInfo* >::const_iterator itC2P;
			const map< string, PinInfo* >::const_iterator itC2PEnd = m_mapCassToPinInfo.end( );

			while ( itC2POther != itC2PEndOther )
			{
				itC2P = m_mapCassToPinInfo.find( itC2POther->first );

				if ( itC2PEnd == itC2P )
				{
					PinInfo* pPinInfo = 0;
						
					try
					{
						pPinInfo = new PinInfo;
					}
					catch ( ... )
					{
						throw Exception( Exception::eFailedToAllocateMemoryForNewPinInfoObjectSubfile2, __FILE__, __FUNCTION__, __LINE__ );
					}

					m_mapCassToPinInfo.insert( make_pair( itC2POther->first, pPinInfo ) );

					pPinInfo->m_mapPins = itC2POther->second->m_mapPins;
				}
				else
				{
					const map< Atlas::eAtlasPinDescriptor, map< string, set< string > > >& mapCNXOther = itC2POther->second->m_mapPins;
					map< Atlas::eAtlasPinDescriptor, map< string, set< string > > >& mapCNX = itC2P->second->m_mapPins;

					map< Atlas::eAtlasPinDescriptor, map< string, set< string > > >::const_iterator itCNX2PinNameOther = mapCNXOther.begin( );
					const map< Atlas::eAtlasPinDescriptor, map< string, set< string > > >::const_iterator itCNX2PinNameEndOther = mapCNXOther.end( );
					map< Atlas::eAtlasPinDescriptor, map< string, set< string > > >::iterator itCNX2PinName;
					const map< Atlas::eAtlasPinDescriptor, map< string, set< string > > >::const_iterator itCNX2PinNameEnd = mapCNX.end( );

					while ( itCNX2PinNameEndOther != itCNX2PinNameOther )
					{
						itCNX2PinName = mapCNX.find( itCNX2PinNameOther->first );
	
						if ( itCNX2PinNameEnd == itCNX2PinName )
						{
							mapCNX.insert( make_pair( itCNX2PinNameOther->first, itCNX2PinNameOther->second ) );
						}
						else
						{
							const map< string, set< string > >& mapPinsOther = itCNX2PinNameOther->second;
							map< string, set< string > >& mapPins = itCNX2PinName->second;

							map< string, set< string > >::const_iterator itPin2SetOther = mapPinsOther.begin( );
							const map< string, set< string > >::const_iterator itPin2SetEndOther = mapPinsOther.end( );
							map< string, set< string > >::iterator itPin2Set;
							map< string, set< string > >::const_iterator itPin2SetEnd = mapPins.end( );

							while ( itPin2SetEndOther != itPin2SetOther )
							{
								itPin2Set = mapPins.find( itPin2SetOther->first );
			
								if ( itPin2SetEnd == itPin2Set )
								{
									mapPins.insert( make_pair( itPin2SetOther->first, itPin2SetOther->second ) );
								}
								else
								{
									set< string >& Set = itPin2Set->second;
									const set< string >& OtherSet = itPin2SetOther->second;
			
									set< string >::const_iterator itOtherSet = OtherSet.begin( );
									const set< string >::const_iterator itEndOtherSet = OtherSet.end( );
									const set< string >::const_iterator itEndSet = Set.end( );
			
									while ( itEndOtherSet != itOtherSet )
									{
										if ( itEndSet == Set.find( *itOtherSet ) )
										{
											Set.insert( *itOtherSet );
										}
			
										itOtherSet++;
									}
								}

								itPin2SetOther++;
							}
						}

						itCNX2PinNameOther++;
					}
				}

				itC2POther++;
			}
		}
	}
}

Lookup::PinInfo* Lookup::Subfile2::GetPinInfo( const string& strSystemName )
{
	PinInfo* pPinInfo = 0;

	const map< string, PinInfo* >::iterator it = m_mapCassToPinInfo.find( strSystemName );

	if ( m_mapCassToPinInfo.end( ) != it )
	{
		pPinInfo = it->second;
	}

	return pPinInfo;
}

const set< string >* Lookup::Subfile2::GetPinInfoSet( const string& strSystemName, const Atlas::eAtlasPinDescriptor ePinDescriptor, const string& strUserPinName )
{
	const set< string >* pSet = 0;

	PinInfo* pPinInfo = GetPinInfo( strSystemName );

	if ( 0 != pPinInfo )
	{
		const map< string, set< string > >* pPinMap = pPinInfo->GetUserPinNames( ePinDescriptor );

		if ( 0 != pPinMap )
		{
			const map< string, set< string > >::const_iterator it = pPinMap->find( strUserPinName );
			const map< string, set< string > >::const_iterator itEnd = pPinMap->end( );

			if ( itEnd != it )
			{
				pSet = &( it->second );
			}
		}
	}

	return pSet;
}


void Lookup::Subfile5::CreateSubfileMapping( const DOMElement* pAIXMLvalue )
{
	const DOMNodeList* pAIXML_NodeList = pAIXMLvalue->getChildNodes( );

	if ( 0 == pAIXML_NodeList )
	{
		throw Exception( Exception::eFailedToGetMappingChildNodes, __FILE__, __FUNCTION__, __LINE__ );
	}

	const XMLSize_t iMaxNodes = pAIXML_NodeList->getLength( );

	if ( 0 == iMaxNodes )
	{
		throw Exception( Exception::eInvalidNumberOfMappingNodes, __FILE__, __FUNCTION__, __LINE__ );
	}

	string strAIXMLtagName;
	string strAtlasEvent;
	string strTriggerSource;

	for ( XMLSize_t iCurrentNode = 0; iCurrentNode < iMaxNodes; iCurrentNode++ )
	{
		pAIXMLvalue = ( xercesc::DOMElement* ) pAIXML_NodeList->item( iCurrentNode );

		if ( 0 == pAIXMLvalue )
		{
			throw Exception( Exception::eFailedToGetXercesNodeListItem, __FILE__, __FUNCTION__, __LINE__ );
		}

		if ( xercesc::DOMNode::COMMENT_NODE == pAIXMLvalue->getNodeType( ) )
		{
			continue;
		}

		AIXMLHelper::GetXercesString( pAIXMLvalue->getTagName( ), strAIXMLtagName );

		if ( !strAIXMLtagName.empty( ) )
		{
			if ( AIXML::m_arrayXMLKeyWords[ AIXML::eArgumentElement ] == strAIXMLtagName )
			{
				if ( strAtlasEvent.empty( ) )
				{
					AIXMLHelper::GetXercesString( pAIXMLvalue->getAttribute( AIXMLHelper::GetWString( AIXML::m_arrayXMLKeyWords[ AIXML::eNameAttribute ] ).c_str( ) ), strAtlasEvent );
				}
				else if ( strTriggerSource.empty( ) )
				{
					AIXMLHelper::GetXercesString( pAIXMLvalue->getAttribute( AIXMLHelper::GetWString( AIXML::m_arrayXMLKeyWords[ AIXML::eNameAttribute ] ).c_str( ) ), strTriggerSource );
				}
				else
				{
					throw Exception( Exception::eMoreThanTwoMappingsArgumentsWereFoundSubfile5, __FILE__, __FUNCTION__, __LINE__ );
				}
			}
		}
	}

	if ( strAtlasEvent.empty( ) )
	{
		throw Exception( Exception::eCannotFindAtlasEventForMappingSubfile5, __FILE__, __FUNCTION__, __LINE__ );
	}

	if ( strTriggerSource.empty( ) )
	{
		throw Exception( Exception::eCannotFindCassTriggerSourceForMappingSubfile5, __FILE__, __FUNCTION__, __LINE__ );
	}

	AddMapping( strAtlasEvent, strTriggerSource );
}

Lookup::Subfile& Lookup::Subfile5::operator = ( const Lookup::Subfile& other )
{
	if ( this != &other )
	{
		if ( m_iSubfileId == other.m_iSubfileId )
		{
			const Subfile5& otherSub5 = ( Subfile5& ) other;

			m_mapEventToTrigger = otherSub5.m_mapEventToTrigger;
		}
	}

	return *this;
}

void Lookup::Subfile5::AddMapping( const string& strAtlasEvent, const string& strTriggerSource )
{
	if ( m_mapEventToTrigger.end( ) != m_mapEventToTrigger.find( strAtlasEvent ) )
	{
		throw Exception( Exception::eDuplicateAtlasEventInMappingSubfile5, __FILE__, __FUNCTION__, __LINE__, strAtlasEvent );
	}

	m_mapEventToTrigger.insert( make_pair( strAtlasEvent, strTriggerSource ) );
}

void Lookup::Subfile5::Merge( const Subfile& other )
{
	if ( this != &other )
	{
		if ( 5 != other.m_iSubfileId )
		{
			string strError( "Was expecting SUBFILE 5, found SUBFILE " );

			strError += AIXMLHelper::NumberToString< int >( other.m_iSubfileId );

			throw Exception( Exception::eUnexpectedSubfileId, __FILE__, __FUNCTION__, __LINE__, strError );
		}

		Subfile5* pOtherSubfile5 = ( Subfile5* ) &other;

		if ( pOtherSubfile5->m_mapEventToTrigger.size( ) > 0 )
		{
			map< string, string >::const_iterator itE2TOther = pOtherSubfile5->m_mapEventToTrigger.begin( );
			const map< string, string >::const_iterator itE2TEndOther = pOtherSubfile5->m_mapEventToTrigger.end( );
			const map< string, string >::const_iterator itE2TEnd = m_mapEventToTrigger.end( );

			while ( itE2TEndOther != itE2TOther )
			{
				if ( itE2TEnd == m_mapEventToTrigger.find( itE2TOther->first ) )
				{
					m_mapEventToTrigger.insert( make_pair( itE2TOther->first, itE2TOther->second ) );
				}

				itE2TOther++;
			}
		}
	}
}

void Lookup::Subfile6::CreateSubfileMapping( const DOMElement* pAIXMLvalue )
{
	const DOMNodeList* pAIXML_NodeList = pAIXMLvalue->getChildNodes( );

	if ( 0 == pAIXML_NodeList )
	{
		throw Exception( Exception::eFailedToGetMappingChildNodes, __FILE__, __FUNCTION__, __LINE__ );
	}

	const XMLSize_t iMaxNodes = pAIXML_NodeList->getLength( );

	if ( 0 == iMaxNodes )
	{
		throw Exception( Exception::eInvalidNumberOfMappingNodes, __FILE__, __FUNCTION__, __LINE__ );
	}

	string strAIXMLtagName;
	string strAttributeValue;
	set< string >* pSetPinDescriptor = 0;

	for ( XMLSize_t iCurrentNode = 0; iCurrentNode < iMaxNodes; iCurrentNode++ )
	{
		pAIXMLvalue = ( xercesc::DOMElement* ) pAIXML_NodeList->item( iCurrentNode );

		if ( 0 == pAIXMLvalue )
		{
			throw Exception( Exception::eFailedToGetXercesNodeListItem, __FILE__, __FUNCTION__, __LINE__ );
		}

		if ( xercesc::DOMNode::COMMENT_NODE == pAIXMLvalue->getNodeType( ) )
		{
			continue;
		}

		AIXMLHelper::GetXercesString( pAIXMLvalue->getTagName( ), strAIXMLtagName );

		if ( !strAIXMLtagName.empty( ) )
		{
			if ( AIXML::m_arrayXMLKeyWords[ AIXML::eArgumentElement ] == strAIXMLtagName )
			{
				if ( 0 == pSetPinDescriptor )
				{
					AIXMLHelper::GetXercesString( pAIXMLvalue->getAttribute( AIXMLHelper::GetWString( AIXML::m_arrayXMLKeyWords[ AIXML::eNameAttribute ] ).c_str( ) ), strAttributeValue );

					if ( strAttributeValue.empty( ) )
					{
						throw Exception( Exception::eCannotFindAtlasEventForMappingSubfile6, __FILE__, __FUNCTION__, __LINE__ );
					}

					pSetPinDescriptor = AddMapping( strAttributeValue );
				}
				else
				{
					AIXMLHelper::GetXercesString( pAIXMLvalue->getAttribute( AIXMLHelper::GetWString( AIXML::m_arrayXMLKeyWords[ AIXML::eNameAttribute ] ).c_str( ) ), strAttributeValue );

					if ( strAttributeValue.empty( ) )
					{
						throw Exception( Exception::ePinDescriptorIsEmptyForSubfile6, __FILE__, __FUNCTION__, __LINE__ );
					}

					pSetPinDescriptor->insert( strAttributeValue );
				}
			}
		}
	}

	if ( 0 == pSetPinDescriptor )
	{
		throw Exception( Exception::eFailedToCreatePinDescriptorSetForSubfile6, __FILE__, __FUNCTION__, __LINE__ );
	}

	if ( 0 == pSetPinDescriptor->size( ) )
	{
		throw Exception( Exception::eNoPinDescriptorWereFoundForSubfile6, __FILE__, __FUNCTION__, __LINE__ );
	}
}

Lookup::Subfile& Lookup::Subfile6::operator = ( const Lookup::Subfile& other )
{
	if ( this != &other )
	{
		if ( m_iSubfileId == other.m_iSubfileId )
		{
			const Subfile6& otherSub6 = ( Subfile6& ) other;

			map< string, set< string >* >::const_iterator it = otherSub6.m_mapEventToPinDescriptor.begin( );
			const map< string, set< string >* >::const_iterator itEnd = otherSub6.m_mapEventToPinDescriptor.end( );
			set< string >* psetPinDescripter = 0;
		
			while ( it != itEnd )
			{
				try
				{
					psetPinDescripter = new set< string >( );
				}
				catch ( ... )
				{
					throw Exception( Exception::eFailedToAllocateMemoryForNewAtlasSetSubfile6, __FILE__, __FUNCTION__, __LINE__ );
				}
		
				m_mapEventToPinDescriptor.insert( make_pair( it->first, psetPinDescripter ) );

				*psetPinDescripter = *( it->second );

				it++;
			}
		}
	}

	return *this;
}

set< string >* Lookup::Subfile6::AddMapping( const string& strAtlasEvent )
{
	set< string >* pSet = 0;

	if ( m_mapEventToPinDescriptor.end( ) != m_mapEventToPinDescriptor.find( strAtlasEvent ) )
	{
		throw Exception( Exception::eDuplicateAtlasEventInMappingSubfile6, __FILE__, __FUNCTION__, __LINE__, strAtlasEvent );
	}

	try
	{
		pSet = new set< string >( );
	}
	catch ( ... )
	{
		throw Exception( Exception::eFailedToAllocateMemoryForNewAtlasSetSubfile6, __FILE__, __FUNCTION__, __LINE__ );
	}

	m_mapEventToPinDescriptor.insert( make_pair( strAtlasEvent, pSet ) );

	return pSet;
}

void Lookup::Subfile6::Merge( const Subfile& other )
{
	if ( this != &other )
	{
		if ( 6 != other.m_iSubfileId )
		{
			string strError( "Was expecting SUBFILE 6, found SUBFILE " );

			strError += AIXMLHelper::NumberToString< int >( other.m_iSubfileId );

			throw Exception( Exception::eUnexpectedSubfileId, __FILE__, __FUNCTION__, __LINE__, strError );
		}

		Subfile6* pOtherSubfile6 = ( Subfile6* ) &other;

		if ( pOtherSubfile6->m_mapEventToPinDescriptor.size( ) > 0 )
		{
			map< string, set< string >* >::const_iterator itE2PDOther = pOtherSubfile6->m_mapEventToPinDescriptor.begin( );
			const map< string, set< string >* >::const_iterator itE2PDEndOther = pOtherSubfile6->m_mapEventToPinDescriptor.end( );
			map< string, set< string >* >::const_iterator itE2PD;
			const map< string, set< string >* >::const_iterator itE2PDEnd = m_mapEventToPinDescriptor.end( );

			while ( itE2PDOther != itE2PDEndOther )
			{
				itE2PD = m_mapEventToPinDescriptor.find( itE2PDOther->first );

				if ( itE2PDEnd == itE2PD )
				{
					set< string >* pSet = 0;
					
					try
					{
						pSet = new set< string >( );
					}
					catch ( ... )
					{
						throw Exception( Exception::eFailedToAllocateMemoryForNewAtlasSetSubfile1, __FILE__, __FUNCTION__, __LINE__ );
					}

					m_mapEventToPinDescriptor.insert( make_pair( itE2PDOther->first, pSet ) );

					*pSet = *( itE2PDOther->second );
				}
				else
				{
					set< string >* pSet = itE2PD->second;
					const set< string >* pOtherSet = itE2PDOther->second;

					set< string >::const_iterator itOtherSet = pOtherSet->begin( );
					const set< string >::const_iterator itEndOtherSet = pOtherSet->end( );
					const set< string >::const_iterator itEndSet = pSet->end( );

					while ( itEndOtherSet != itOtherSet )
					{
						if ( itEndSet == pSet->find( *itOtherSet ) )
						{
							pSet->insert( *itOtherSet );
						}

						itOtherSet++;
					}
				}

				itE2PDOther++;
			}
		}
	}
}

void Lookup::Subfile7::CreateSubfileMapping( const DOMElement* pAIXMLvalue )
{
	const DOMNodeList* pAIXML_NodeList = pAIXMLvalue->getChildNodes( );

	if ( 0 == pAIXML_NodeList )
	{
		throw Exception( Exception::eFailedToGetMappingChildNodes, __FILE__, __FUNCTION__, __LINE__ );
	}

	const XMLSize_t iMaxNodes = pAIXML_NodeList->getLength( );

	if ( 0 == iMaxNodes )
	{
		throw Exception( Exception::eInvalidNumberOfMappingNodes, __FILE__, __FUNCTION__, __LINE__ );
	}

	string strAIXMLtagName;
	string strLabel;
	string strCassName;

	for ( XMLSize_t iCurrentNode = 0; iCurrentNode < iMaxNodes; iCurrentNode++ )
	{
		pAIXMLvalue = ( xercesc::DOMElement* ) pAIXML_NodeList->item( iCurrentNode );

		if ( 0 == pAIXMLvalue )
		{
			throw Exception( Exception::eFailedToGetXercesNodeListItem, __FILE__, __FUNCTION__, __LINE__ );
		}

		if ( xercesc::DOMNode::COMMENT_NODE == pAIXMLvalue->getNodeType( ) )
		{
			continue;
		}

		AIXMLHelper::GetXercesString( pAIXMLvalue->getTagName( ), strAIXMLtagName );

		if ( !strAIXMLtagName.empty( ) )
		{
			if ( AIXML::m_arrayXMLKeyWords[ AIXML::eArgumentElement ] == strAIXMLtagName )
			{
				if ( strLabel.empty( ) )
				{
					AIXMLHelper::GetXercesString( pAIXMLvalue->getAttribute( AIXMLHelper::GetWString( AIXML::m_arrayXMLKeyWords[ AIXML::eNameAttribute ] ).c_str( ) ), strLabel );
				}
				else if ( strCassName.empty( ) )
				{
					AIXMLHelper::GetXercesString( pAIXMLvalue->getAttribute( AIXMLHelper::GetWString( AIXML::m_arrayXMLKeyWords[ AIXML::eNameAttribute ] ).c_str( ) ), strCassName );
				}
				else
				{
					throw Exception( Exception::eMoreThanTwoMappingsArgumentsWereFoundSubfile7, __FILE__, __FUNCTION__, __LINE__ );
				}
			}
		}
	}

	if ( strLabel.empty( ) )
	{
		throw Exception( Exception::eCannotFindLabelForMappingSubfile7, __FILE__, __FUNCTION__, __LINE__ );
	}

	if ( strCassName.empty( ) )
	{
		throw Exception( Exception::eCannotFindCassNameForMappingSubfile7, __FILE__, __FUNCTION__, __LINE__ );
	}

	AddMapping( strLabel, strCassName );
}

Lookup::Subfile& Lookup::Subfile7::operator = ( const Lookup::Subfile& other )
{
	if ( this != &other )
	{
		if ( m_iSubfileId == other.m_iSubfileId )
		{
			const Subfile7& otherSub7 = ( Subfile7& ) other;

			m_mapLabelToCass = otherSub7.m_mapLabelToCass;
		}
	}

	return *this;
}

void Lookup::Subfile7::AddMapping( const string& strLabel, const string& strCassName )
{
	if ( m_mapLabelToCass.end( ) != m_mapLabelToCass.find( strLabel ) )
	{
		throw Exception( Exception::eDuplicateLabelInMappingSubfile7, __FILE__, __FUNCTION__, __LINE__, strLabel );
	}

	m_mapLabelToCass.insert( make_pair( strLabel, strCassName ) );
}

void Lookup::Subfile7::Merge( const Subfile& other )
{
	if ( this != &other )
	{
		if ( 7 != other.m_iSubfileId )
		{
			string strError( "Was expecting SUBFILE 7, found SUBFILE " );

			strError += AIXMLHelper::NumberToString< int >( other.m_iSubfileId );

			throw Exception( Exception::eUnexpectedSubfileId, __FILE__, __FUNCTION__, __LINE__, strError );
		}

		Subfile7* pOtherSubfile7 = ( Subfile7* ) &other;

		if ( pOtherSubfile7->m_mapLabelToCass.size( ) > 0 )
		{
			map< string, string >::const_iterator itL2COther = pOtherSubfile7->m_mapLabelToCass.begin( );
			const map< string, string >::const_iterator itL2CEndOther = pOtherSubfile7->m_mapLabelToCass.end( );
			const map< string, string >::const_iterator itL2CEnd = m_mapLabelToCass.end( );

			while ( itL2CEndOther != itL2COther )
			{
				if ( itL2CEnd == m_mapLabelToCass.find( itL2COther->first ) )
				{
					m_mapLabelToCass.insert( make_pair( itL2COther->first, itL2COther->second ) );
				}

				itL2COther++;
			}
		}
	}
}

void Lookup::Subfile10::CreateSubfileMapping( const DOMElement* pAIXMLvalue )
{
	const DOMNodeList* pAIXML_NodeList = pAIXMLvalue->getChildNodes( );

	if ( 0 == pAIXML_NodeList )
	{
		throw Exception( Exception::eFailedToGetMappingChildNodes, __FILE__, __FUNCTION__, __LINE__ );
	}

	const XMLSize_t iMaxNodes = pAIXML_NodeList->getLength( );

	if ( 0 == iMaxNodes )
	{
		throw Exception( Exception::eInvalidNumberOfMappingNodes, __FILE__, __FUNCTION__, __LINE__ );
	}

	string strAIXMLtagName;
	string strName;
	set< string >* pPins = 0;

	for ( XMLSize_t iCurrentNode = 0; iCurrentNode < iMaxNodes; iCurrentNode++ )
	{
		pAIXMLvalue = ( xercesc::DOMElement* ) pAIXML_NodeList->item( iCurrentNode );

		if ( 0 == pAIXMLvalue )
		{
			throw Exception( Exception::eFailedToGetXercesNodeListItem, __FILE__, __FUNCTION__, __LINE__ );
		}

		if ( xercesc::DOMNode::COMMENT_NODE == pAIXMLvalue->getNodeType( ) )
		{
			continue;
		}

		AIXMLHelper::GetXercesString( pAIXMLvalue->getTagName( ), strAIXMLtagName );

		if ( !strAIXMLtagName.empty( ) )
		{
			if ( AIXML::m_arrayXMLKeyWords[ AIXML::eArgumentElement ] == strAIXMLtagName )
			{
				AIXMLHelper::GetXercesString( pAIXMLvalue->getAttribute( AIXMLHelper::GetWString( AIXML::m_arrayXMLKeyWords[ AIXML::eNameAttribute ] ).c_str( ) ), strName );

				if ( strName.empty( ) )
				{
					throw Exception( Exception::eEmptyMappingSubfile10, __FILE__, __FUNCTION__, __LINE__ );
				}

				if ( 0 == pPins )
				{
					pPins = AddMapping( strName );
				}
				else
				{
					pPins->insert( strName );
				}
			}
		}
	}
}

Lookup::Subfile& Lookup::Subfile10::operator = ( const Lookup::Subfile& other )
{
	if ( this != &other )
	{
		if ( m_iSubfileId == other.m_iSubfileId )
		{
			const Subfile10& otherSub10 = ( Subfile10& ) other;

			m_pmapCassToAtlas = otherSub10.m_pmapCassToAtlas;
			m_pmapAtlasToCass = otherSub10.m_pmapAtlasToCass;

			map< string, PinInfo* >::const_iterator it = otherSub10.m_mapCassToPinInfo.begin( );
			const map< string, PinInfo* >::const_iterator itEnd = otherSub10.m_mapCassToPinInfo.end( );
			PinInfo* pPinInfo = 0;
		
			while ( it != itEnd )
			{
				try
				{
					pPinInfo = new PinInfo;
				}
				catch ( ... )
				{
					throw Exception( Exception::eFailedToAllocateMemoryForNewPinInfoObjectSubfile10, __FILE__, __FUNCTION__, __LINE__ );
				}
		
				m_mapCassToPinInfo.insert( make_pair( it->first, pPinInfo ) );

				pPinInfo->m_mapPins = it->second->m_mapPins;

				it++;
			}
		}
	}

	return *this;
}

set< string >* Lookup::Subfile10::AddMapping( const string& strSystemNameCombo )
{
	return Lookup::Subfile2::AddMapping( strSystemNameCombo, 
		m_mapCassToPinInfo, 
		m_pmapCassToAtlas, 
		m_pmapAtlasToCass, 
		Exception::eUnknownOrMissingCNXTypeInSubfile10, 
		Exception::eUnknownOrMissingSystemNameInSubfile10, 
		Exception::eFailedToAllocateMemoryForNewPinInfoObjectSubfile10,
		Exception::eUnknownOrMissingNameInSubfile10 );
}

void Lookup::Subfile10::Merge( const Subfile& other )
{
	if ( this != &other )
	{
		if ( 10 != other.m_iSubfileId )
		{
			string strError( "Was expecting SUBFILE 10, found SUBFILE " );

			strError += AIXMLHelper::NumberToString< int >( other.m_iSubfileId );

			throw Exception( Exception::eUnexpectedSubfileId, __FILE__, __FUNCTION__, __LINE__, strError );
		}

		Subfile10* pOtherSubfile10 = ( Subfile10* ) &other;

		if ( pOtherSubfile10->m_mapCassToPinInfo.size( ) > 0 )
		{
			map< string, PinInfo* >::const_iterator itC2POther = pOtherSubfile10->m_mapCassToPinInfo.begin( );
			const map< string, PinInfo* >::const_iterator itC2PEndOther = pOtherSubfile10->m_mapCassToPinInfo.end( );
			map< string, PinInfo* >::const_iterator itC2P;
			const map< string, PinInfo* >::const_iterator itC2PEnd = m_mapCassToPinInfo.end( );

			while ( itC2POther != itC2PEndOther )
			{
				itC2P = m_mapCassToPinInfo.find( itC2POther->first );

				if ( itC2PEnd == itC2P )
				{
					PinInfo* pPinInfo = 0;
						
					try
					{
						pPinInfo = new PinInfo;
					}
					catch ( ... )
					{
						throw Exception( Exception::eFailedToAllocateMemoryForNewPinInfoObjectSubfile2, __FILE__, __FUNCTION__, __LINE__ );
					}

					m_mapCassToPinInfo.insert( make_pair( itC2POther->first, pPinInfo ) );

					pPinInfo->m_mapPins = itC2POther->second->m_mapPins;
				}
				else
				{
					const map< Atlas::eAtlasPinDescriptor, map< string, set< string > > >& mapCNXOther = itC2POther->second->m_mapPins;
					map< Atlas::eAtlasPinDescriptor, map< string, set< string > > >& mapCNX = itC2P->second->m_mapPins;

					map< Atlas::eAtlasPinDescriptor, map< string, set< string > > >::const_iterator itCNX2PinNameOther = mapCNXOther.begin( );
					const map< Atlas::eAtlasPinDescriptor, map< string, set< string > > >::const_iterator itCNX2PinNameEndOther = mapCNXOther.end( );
					map< Atlas::eAtlasPinDescriptor, map< string, set< string > > >::iterator itCNX2PinName;
					const map< Atlas::eAtlasPinDescriptor, map< string, set< string > > >::const_iterator itCNX2PinNameEnd = mapCNX.end( );

					while ( itCNX2PinNameEndOther != itCNX2PinNameOther )
					{
						itCNX2PinName = mapCNX.find( itCNX2PinNameOther->first );
	
						if ( itCNX2PinNameEnd == itCNX2PinName )
						{
							mapCNX.insert( make_pair( itCNX2PinNameOther->first, itCNX2PinNameOther->second ) );
						}
						else
						{
							const map< string, set< string > >& mapPinsOther = itCNX2PinNameOther->second;
							map< string, set< string > >& mapPins = itCNX2PinName->second;

							map< string, set< string > >::const_iterator itPin2SetOther = mapPinsOther.begin( );
							const map< string, set< string > >::const_iterator itPin2SetEndOther = mapPinsOther.end( );
							map< string, set< string > >::iterator itPin2Set;
							map< string, set< string > >::const_iterator itPin2SetEnd = mapPins.end( );

							while ( itPin2SetEndOther != itPin2SetOther )
							{
								itPin2Set = mapPins.find( itPin2SetOther->first );
			
								if ( itPin2SetEnd == itPin2Set )
								{
									mapPins.insert( make_pair( itPin2SetOther->first, itPin2SetOther->second ) );
								}
								else
								{
									set< string >& Set = itPin2Set->second;
									const set< string >& OtherSet = itPin2SetOther->second;
			
									set< string >::const_iterator itOtherSet = OtherSet.begin( );
									const set< string >::const_iterator itEndOtherSet = OtherSet.end( );
									const set< string >::const_iterator itEndSet = Set.end( );
			
									while ( itEndOtherSet != itOtherSet )
									{
										if ( itEndSet == Set.find( *itOtherSet ) )
										{
											Set.insert( *itOtherSet );
										}
			
										itOtherSet++;
									}
								}

								itPin2SetOther++;
							}
						}

						itCNX2PinNameOther++;
					}
				}

				itC2POther++;
			}
		}
	}
}