/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

#include "cass_video.h"
#include "atlas_noun_modifier.h"

#if ( _DEBUG ) && ( WIN32 )
	#define WINVER 0x0600
	#include <afx.h>
	#define new DEBUG_NEW
	#undef THIS_FILE
	static char BASED_CODE THIS_FILE[ ] = __FILE__;
#endif

void VideoHorizontalTiming::GarbageCollect( void )
{
	unsigned int uiSize = m_vectRanges.size( );
	for ( unsigned int ui = 0; ui < uiSize; ++ui )
	{
		delete m_vectRanges[ ui ].second;
	}
	m_vectRanges.clear( );
}

VideoHorizontalTiming& VideoHorizontalTiming::operator = ( const VideoHorizontalTiming& other )
{
	if ( this != &other )
	{
		GarbageCollect( );

		unsigned int uiSize = other.m_vectRanges.size( );
		if ( uiSize > 0 )
		{
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
					throw Exception( Exception::eFailedToCreateVideoObject, __FILE__, __FUNCTION__, __LINE__ );
				}
	
				m_vectRanges.push_back( make_pair( prOther.first, pRange ) );
			}
		}
	}

	return *this;
}

unsigned int VideoHorizontalTiming::Init( const string& strVirtualLabel, const vector< const AtlasAttributes::AtlasAttibuteValue* >& vectAttributes, const unsigned int uiStart, const set< Atlas::eAtlasNounModifier >& setTermination )
{
	unsigned int uiRet = uiStart;
	const unsigned int uiAttributes = vectAttributes.size( );
	const set< Atlas::eAtlasNounModifier >::const_iterator itEnd = setTermination.end( );

	while ( uiRet < uiAttributes )
	{
		string strAtlasNounModifier( vectAttributes[ uiRet ]->m_strValue );

		Atlas::AtlasSignalComponent AtlasNM( Atlas::GetAtlasNounModifierEnum( strAtlasNounModifier ) );

		if ( !AtlasNM.IsValid( ) )
		{
			string strError( strVirtualLabel );
				
			strError += ": Atlas noun/modifier: ";
			strError += strAtlasNounModifier;
	
			throw Exception( Exception::eUnknownAtlasNounModifierForCapability, __FILE__, __FUNCTION__, __LINE__, strError );
		}

		if ( itEnd != setTermination.find( AtlasNM.GetAtlasNounModifier( ) ) )
		{
			break;
		}

		++uiRet;

		if ( uiRet < uiAttributes )
		{
			const string& strWord = vectAttributes[ uiRet ]->m_strValue;

			if ( AtlasStatement::m_strRANGE == strWord )
			{
				Range* pRange = 0;
					
				try
				{
					pRange = new Range;
				}
				catch ( ... )
				{
					string strError( strVirtualLabel );
	
					strError += ": capability range";
	
					throw Exception( Exception::eFailedToCreateRangeObject, __FILE__, __FUNCTION__, __LINE__, strError );
				}

				m_vectRanges.push_back( make_pair( AtlasNM, pRange ) );
	
				uiRet = pRange->Init( strVirtualLabel, vectAttributes, uiRet + 1  );
			}
		}
	}

	return uiRet;
}

void VideoHorizontalTiming::Merge( const VideoHorizontalTiming& other )
{
	if ( this != &other )
	{
		Range::MergeSignalRanges( m_vectRanges, other.m_vectRanges );
	}
}

void VideoHorizontalTiming::InitSignalComponents( void )
{
	Range::InitSignalComponents( m_vectRanges );
}

bool VideoHorizontalTiming::HasNounModifier( const Atlas::eAtlasNounModifier eModifier ) const
{ 
	return Range::HasNounModifier( eModifier, m_vectRanges );
}

void VideoHorizontalTiming::ToXML( string& strXML )
{
	if ( m_vectRanges.size( ) > 0 )
	{
		strXML += XML::MakeOpenXmlElementWithChildren( XML::enHorizontalTiming );
	
		Range::ToXML( strXML, m_vectRanges );

		strXML += XML::MakeCloseXmlElementWithChildren( XML::enHorizontalTiming );
	}
}

void VideoVerticalTiming::GarbageCollect( void )
{
	unsigned int uiSize = m_vectRanges.size( );
	for ( unsigned int ui = 0; ui < uiSize; ++ui )
	{
		delete m_vectRanges[ ui ].second;
	}
	m_vectRanges.clear( );

	if ( 0 != m_pbNonInterlace )
	{
		delete m_pbNonInterlace;
		m_pbNonInterlace = 0;
	}

	if ( 0 != m_pbInterlace )
	{
		delete m_pbInterlace;
		m_pbInterlace = 0;
	}
}

VideoVerticalTiming& VideoVerticalTiming::operator = ( const VideoVerticalTiming& other )
{
	if ( this != &other )
	{
		GarbageCollect( );

		unsigned int uiSize = other.m_vectRanges.size( );
		if ( uiSize > 0 )
		{
			for ( unsigned int ui = 0; ui < uiSize; ++ui )
			{
				const pair< Atlas::AtlasSignalComponent, Range* >& prOther = other.m_vectRanges[ ui ];
				Range* pRange = 0;
				
				try
				{
					pRange = new Range( *( prOther.second ) );
				}
				catch ( ... )
				{
					throw Exception( Exception::eFailedToCreateVideoObject, __FILE__, __FUNCTION__, __LINE__ );
				}
	
				m_vectRanges.push_back( make_pair( prOther.first, pRange ) );
			}
		}

		if ( 0 != other.m_pbNonInterlace )
		{
			try
			{
				m_pbNonInterlace = new bool( *( other.m_pbNonInterlace ) );
			}
			catch ( ... )
			{
				throw Exception( Exception::eFailedToCreateBoolObject, __FILE__, __FUNCTION__, __LINE__ );
			}
		}

		if ( 0 != other.m_pbInterlace )
		{
			try
			{
				m_pbInterlace = new bool( *( other.m_pbInterlace ) );
			}
			catch ( ... )
			{
				throw Exception( Exception::eFailedToCreateBoolObject, __FILE__, __FUNCTION__, __LINE__ );
			}
		}
	}

	return *this;
}

unsigned int VideoVerticalTiming::Init( const string& strVirtualLabel, const vector< const AtlasAttributes::AtlasAttibuteValue* >& vectAttributes, const unsigned int uiStart, const set< Atlas::eAtlasNounModifier >& setTermination )
{
	unsigned int uiRet = uiStart;
	const unsigned int uiAttributes = vectAttributes.size( );
	const set< Atlas::eAtlasNounModifier >::const_iterator itEnd = setTermination.end( );

	while ( uiRet < uiAttributes )
	{
		string strAtlasNounModifier( vectAttributes[ uiRet ]->m_strValue );

		Atlas::AtlasSignalComponent AtlasNM( Atlas::GetAtlasNounModifierEnum( strAtlasNounModifier ) );

		if ( !AtlasNM.IsValid( ) )
		{
			string strError( strVirtualLabel );
				
			strError += ": Atlas noun/modifier: ";
			strError += strAtlasNounModifier;
	
			throw Exception( Exception::eUnknownAtlasNounModifierForCapability, __FILE__, __FUNCTION__, __LINE__, strError );
		}

		if ( itEnd != setTermination.find( AtlasNM.GetAtlasNounModifier( ) ) )
		{
			break;
		}

		++uiRet;

		if ( uiRet < uiAttributes )
		{
			const string& strWord = vectAttributes[ uiRet ]->m_strValue;

			if ( AtlasStatement::m_strRANGE == strWord )
			{
				Range* pRange = 0;
				
				try
				{
					pRange = new Range;
				}
				catch ( ... )
				{
					string strError( strVirtualLabel );
	
					strError += ": capability range";
	
					throw Exception( Exception::eFailedToCreateRangeObject, __FILE__, __FUNCTION__, __LINE__, strError );
				}

				m_vectRanges.push_back( make_pair( AtlasNM, pRange ) );
	
				uiRet = pRange->Init( strVirtualLabel, vectAttributes, uiRet + 1  );
			}
			else
			{
				switch ( AtlasNM.GetAtlasNounModifier( ) )
				{
					case Atlas::eNON_INTERLACE:
						if ( 0 != m_pbNonInterlace )
						{
							throw Exception( Exception::ePointerAlreadyUsed, __FILE__, __FUNCTION__, __LINE__, strVirtualLabel );
						}
			
						try
						{
							m_pbNonInterlace = new bool( true );
						}
						catch ( ... )
						{
							throw Exception( Exception::eFailedToCreateBoolObject, __FILE__, __FUNCTION__, __LINE__, strVirtualLabel );
						}
						break;

					case Atlas::eINTERLACE:
						if ( 0 != m_pbInterlace )
						{
							throw Exception( Exception::ePointerAlreadyUsed, __FILE__, __FUNCTION__, __LINE__, strVirtualLabel );
						}
			
						try
						{
							m_pbInterlace = new bool( true );
						}
						catch ( ... )
						{
							throw Exception( Exception::eFailedToCreateBoolObject, __FILE__, __FUNCTION__, __LINE__, strVirtualLabel );
						}
						break;
				}
			}
		}
	}

	return uiRet;
}

void VideoVerticalTiming::Merge( const VideoVerticalTiming& other )
{
	if ( this != &other )
	{
		Range::MergeSignalRanges( m_vectRanges, other.m_vectRanges );

		if ( ( 0 != m_pbNonInterlace ) && ( 0 != other.m_pbNonInterlace ) )
		{
			if ( !( *( m_pbNonInterlace ) ) )
			{
				*( m_pbNonInterlace ) = *( other.m_pbNonInterlace );
			}
		}
		else if ( 0 != other.m_pbNonInterlace )
		{
			try
			{
				m_pbNonInterlace = new bool( *( other.m_pbNonInterlace )  );
			}
			catch ( ... )
			{
				throw Exception( Exception::eFailedToCreateBoolObject, __FILE__, __FUNCTION__, __LINE__ );
			}
		}

		if ( ( 0 != m_pbInterlace ) && ( 0 != other.m_pbInterlace ) )
		{
			if ( !( *( m_pbInterlace ) ) )
			{
				*( m_pbInterlace ) = *( other.m_pbInterlace );
			}
		}
		else if ( 0 != other.m_pbInterlace )
		{
			try
			{
				m_pbInterlace = new bool( *( other.m_pbInterlace )  );
			}
			catch( ... )
			{
				throw Exception( Exception::eFailedToCreateBoolObject, __FILE__, __FUNCTION__, __LINE__ );
			}
		}
	}
}

void VideoVerticalTiming::InitSignalComponents( void )
{
	Range::InitSignalComponents( m_vectRanges );
}

bool VideoVerticalTiming::HasNounModifier( const Atlas::eAtlasNounModifier eModifier ) const
{ 
	bool bHasNounModifier = false;

	if ( Range::HasNounModifier( eModifier, m_vectRanges ) )
	{
		bHasNounModifier = true;
	}
	else if ( ( 0 != m_pbNonInterlace ) && ( Atlas::eNON_INTERLACE == eModifier ) )
	{
		bHasNounModifier = true;
	}
	else if ( ( 0 != m_pbInterlace ) && ( Atlas::eINTERLACE == eModifier ) )
	{
		bHasNounModifier = true;
	}

	return bHasNounModifier;
}


void VideoVerticalTiming::ToXML( string& strXML )
{
	if ( ( m_vectRanges.size( ) > 0 ) || ( 0 != m_pbNonInterlace ) || ( 0 != m_pbInterlace ) )
	{
		strXML += XML::MakeOpenXmlElementWithChildren( XML::enVerticalTiming );
	
		Range::ToXML( strXML, m_vectRanges );

		if ( 0 != m_pbNonInterlace )
		{
			if ( *m_pbNonInterlace )
			{
				XML::MakeXmlElementNoChildren( XML::enNonInterlace );
			}
		}

		if ( 0 != m_pbInterlace )
		{
			if ( *m_pbInterlace )
			{
				XML::MakeXmlElementNoChildren( XML::enInterlace );
			}
		}

		strXML += XML::MakeCloseXmlElementWithChildren( XML::enVerticalTiming );
	}
}

void VideoSync::GarbageCollect( void )
{
	unsigned int uiSize = m_vectRanges.size( );
	for ( unsigned int ui = 0; ui < uiSize; ++ui )
	{
		delete m_vectRanges[ ui ].second;
	}
	m_vectRanges.clear( );

	m_vectSynchronizations.clear( );

	m_iBitField = 0;
}

VideoSync& VideoSync::operator = ( const VideoSync& other )
{
	if ( this != &other )
	{
		GarbageCollect( );

		m_vectSynchronizations = other.m_vectSynchronizations;
		m_iBitField = other.m_iBitField;

		unsigned int uiSize = other.m_vectRanges.size( );
		if ( uiSize > 0 )
		{
			for ( unsigned int ui = 0; ui < uiSize; ++ui )
			{
				const pair< Atlas::AtlasSignalComponent, Range* >& prOther = other.m_vectRanges[ ui ];
				Range* pRange = 0;
				
				try
				{
					pRange = new Range( *( prOther.second ) );
				}
				catch ( ... )
				{
					throw Exception( Exception::eFailedToCreateVideoObject, __FILE__, __FUNCTION__, __LINE__ );
				}
	
				m_vectRanges.push_back( make_pair( prOther.first, pRange ) );
			}
		}
	}

	return *this;
}

unsigned int VideoSync::Init( const string& strVirtualLabel, const vector< const AtlasAttributes::AtlasAttibuteValue* >& vectAttributes, const unsigned int uiStart, const set< Atlas::eAtlasNounModifier >& setTermination )
{
	unsigned int uiRet = uiStart;
	const unsigned int uiAttributes = vectAttributes.size( );
	const set< Atlas::eAtlasNounModifier >::const_iterator itEnd = setTermination.end( );

	while ( uiRet < uiAttributes )
	{
		string strAtlasNounModifier( vectAttributes[ uiRet ]->m_strValue );

		Atlas::AtlasSignalComponent AtlasNM( Atlas::GetAtlasNounModifierEnum( strAtlasNounModifier ) );

		if ( !AtlasNM.IsValid( ) )
		{
			string strError( strVirtualLabel );
				
			strError += ": Atlas noun/modifier: ";
			strError += strAtlasNounModifier;
	
			throw Exception( Exception::eUnknownAtlasNounModifierForCapability, __FILE__, __FUNCTION__, __LINE__, strError );
		}

		if ( itEnd != setTermination.find( AtlasNM.GetAtlasNounModifier( ) ) )
		{
			break;
		}

		++uiRet;

		if ( uiRet < uiAttributes )
		{
			const string& strWord = vectAttributes[ uiRet ]->m_strValue;

			if ( AtlasStatement::m_strRANGE == strWord )
			{
				Range* pRange = 0;
				
				try
				{
					pRange = new Range;
				}
				catch ( ... )
				{
					string strError( strVirtualLabel );
	
					strError += ": capability range";
	
					throw Exception( Exception::eFailedToCreateRangeObject, __FILE__, __FUNCTION__, __LINE__, strError );
				}

				m_vectRanges.push_back( make_pair( AtlasNM, pRange ) );
	
				uiRet = pRange->Init( strVirtualLabel, vectAttributes, uiRet + 1  );
			}
			else
			{
				switch ( AtlasNM.GetAtlasNounModifier( ) )
				{
					case Atlas::eON_VIDEO:
						{
							static map< string, eBitFieldValue > mapColors;

							if ( 0 == mapColors.size( ) )
							{
								mapColors.insert( make_pair( "RED", eRed ) );
								mapColors.insert( make_pair( "GREEN", eGreen ) );
								mapColors.insert( make_pair( "BLUE", eBlue ) );
								mapColors.insert( make_pair( "RED-GREEN", eRedGreen ) );
								mapColors.insert( make_pair( "RED-BLUE", eRedBlue ) );
								mapColors.insert( make_pair( "GREEN-BLUE", eGreenBlue ) );
								mapColors.insert( make_pair( "RED-GREEN-BLUE", eRedGreenBlue ) );
							}

							SetBitField( uiRet, uiAttributes, vectAttributes, mapColors );
						}
						break;

					case Atlas::eTYPE:
						{
							static map< string, eBitFieldValue > mapTypes;

							if ( 0 == mapTypes.size( ) )
							{
								mapTypes.insert( make_pair( "AMERICAN", eAmerican ) );
								mapTypes.insert( make_pair( "EUROPEAN", eEuropean ) );
							}

							SetBitField( uiRet, uiAttributes, vectAttributes, mapTypes );
						}
						break;

					case Atlas::eSERRATION:
						{
							static map< string, eBitFieldValue > mapTypes;

							if ( 0 == mapTypes.size( ) )
							{
								mapTypes.insert( make_pair( "ON", eOn ) );
								mapTypes.insert( make_pair( "OFF", eOff ) );
							}

							SetBitField( uiRet, uiAttributes, vectAttributes, mapTypes );
						}
						break;

					default:
						m_vectSynchronizations.push_back( AtlasNM );
						break;
				}
			}
		}
	}

	return uiRet;
}

void VideoSync::Merge( const VideoSync& other )
{
	if ( this != &other )
	{
		NounModifier::MergeAtlasSignalComponents( m_vectSynchronizations, other.m_vectSynchronizations );
		Range::MergeSignalRanges( m_vectRanges, other.m_vectRanges );

		m_iBitField |= other.m_iBitField;
	}
}

void VideoSync::SetBitField( unsigned int& uiRet, const unsigned int uiAttributes, const vector< const AtlasAttributes::AtlasAttibuteValue* >& vectAttributes, const map< string, eBitFieldValue >& mapBitValues )
{
	map< string, eBitFieldValue >::const_iterator it;
	const map< string, eBitFieldValue >::const_iterator itEnd = mapBitValues.end( );

	while ( uiRet < uiAttributes )
	{
		it = mapBitValues.find( vectAttributes[ uiRet ]->m_strValue );

		if ( itEnd == it )
		{
			break;
		}

		m_iBitField |= it->second;

		++uiRet;
	}
}

void VideoSync::InitSignalComponents( void )
{
	NounModifier::InitSignalComponents( m_vectSynchronizations );
	Range::InitSignalComponents( m_vectRanges );
}

bool VideoSync::HasNounModifier( const Atlas::eAtlasNounModifier eModifier ) const 
{ 
	bool bHasNounModifier = false;

	if ( Range::HasNounModifier( eModifier, m_vectRanges ) )
	{
		bHasNounModifier = true;
	}
	else if ( NounModifier::HasNounModifier( eModifier, m_vectSynchronizations ) )
	{
		bHasNounModifier = true;
	}
	else if ( 0 != m_iBitField )
	{
		switch ( eModifier )
		{
			case Atlas::eON_VIDEO:
				if ( eRed == ( m_iBitField & eRed ) )
				{
					bHasNounModifier = true;
				}
				else if ( eGreen == ( m_iBitField & eGreen ) )
				{
					bHasNounModifier = true;
				}
				else if ( eBlue == ( m_iBitField & eBlue ) )
				{
					bHasNounModifier = true;
				}
				else if ( eRedGreen == ( m_iBitField & eRedGreen ) )
				{
					bHasNounModifier = true;
				}
				else if ( eRedBlue == ( m_iBitField & eRedBlue ) )
				{
					bHasNounModifier = true;
				}
				else if ( eGreenBlue == ( m_iBitField & eGreenBlue ) )
				{
					bHasNounModifier = true;
				}
				else if ( eRedGreenBlue == ( m_iBitField & eRedGreenBlue ) )
				{
					bHasNounModifier = true;
				}
				break;

			case Atlas::eTYPE:
				if ( eAmerican == ( m_iBitField & eAmerican ) )
				{
					bHasNounModifier = true;
				}
				else if ( eEuropean == ( m_iBitField & eEuropean ) )
				{
					bHasNounModifier = true;
				}
				break;

			case Atlas::eSERRATION:
				if ( eOn == ( m_iBitField & eOn ) )
				{
					bHasNounModifier = true;
				}
				else if ( eOff == ( m_iBitField & eOff ) )
				{
					bHasNounModifier = true;
				}
				break;
		}
	}

	return bHasNounModifier;
}

void VideoSync::ToXML( string& strXML )
{
	if ( ( m_vectRanges.size( ) > 0 ) || ( m_vectSynchronizations.size( ) > 0 ) || ( 0 != m_iBitField ) )
	{
		strXML += XML::MakeOpenXmlElementWithChildren( XML::enSync );
	
		Range::ToXML( strXML, m_vectRanges );
		NounModifier::ToXML( strXML, m_vectSynchronizations, XML::enModifiers, XML::enModifier );

		if ( 0 != m_iBitField )
		{
			string strColorAttributes;
			string strType;
			string strSerration;

			// ON-VIDEO
			if ( m_iBitField & eRed )
			{
				strColorAttributes += XML::MakeXmlAttributeNameValue( XML::anRed, XML::avTrue );
			}
			if ( m_iBitField & eGreen )
			{
				strColorAttributes += XML::MakeXmlAttributeNameValue( XML::anGreen, XML::avTrue );
			}
			if ( m_iBitField & eBlue )
			{
				strColorAttributes += XML::MakeXmlAttributeNameValue( XML::anBlue, XML::avTrue );
			}
			if ( m_iBitField & eRedGreen )
			{
				strColorAttributes += XML::MakeXmlAttributeNameValue( XML::anRedGreen, XML::avTrue );
			}
			if ( m_iBitField & eRedBlue )
			{
				strColorAttributes += XML::MakeXmlAttributeNameValue( XML::anRedBlue, XML::avTrue );
			}
			if ( m_iBitField & eGreenBlue )
			{
				strColorAttributes += XML::MakeXmlAttributeNameValue( XML::anGreenBlue, XML::avTrue );
			}
			if ( m_iBitField & eRedGreenBlue )
			{
				strColorAttributes += XML::MakeXmlAttributeNameValue( XML::anRedGreenBlue, XML::avTrue );
			}
			if ( !strColorAttributes.empty( ) )
			{
				strXML += XML::MakeXmlElementNoChildren( XML::enOnVideo, strColorAttributes );
			}


			// TYPE
			if ( m_iBitField & eAmerican )
			{
				strType += XML::MakeXmlAttributeNameValue( XML::anAmerican, XML::avTrue );
			}
			if ( m_iBitField & eEuropean )
			{
				strType += XML::MakeXmlAttributeNameValue( XML::anEuropean, XML::avTrue );
			}
			if ( !strType.empty( ) )
			{
				strXML += XML::MakeXmlElementNoChildren( XML::enType, strType );
			}
			

			// SERRATION
			if ( m_iBitField & eOn )
			{
				strSerration += XML::MakeXmlAttributeNameValue( XML::anOn, XML::avTrue );
			}
			if ( m_iBitField & eOff )
			{
				strSerration += XML::MakeXmlAttributeNameValue( XML::anOff, XML::avTrue );
			}
			if ( !strSerration.empty( ) )
			{
				strXML += XML::MakeXmlElementNoChildren( XML::enSerration, strSerration );
			}
		}

		strXML += XML::MakeCloseXmlElementWithChildren( XML::enSync );
	}
}

VideoSyncPolarity& VideoSyncPolarity::operator = ( const VideoSyncPolarity& other )
{
	if ( this != &other )
	{
		GarbageCollect( );

		m_iBitField = other.m_iBitField;
	}

	return *this;
}

unsigned int VideoSyncPolarity::Init( const string& strVirtualLabel, const vector< const AtlasAttributes::AtlasAttibuteValue* >& vectAttributes, const unsigned int uiStart, const set< Atlas::eAtlasNounModifier >& setTermination )
{
	unsigned int uiRet = uiStart;
	const unsigned int uiAttributes = vectAttributes.size( );
	const set< Atlas::eAtlasNounModifier >::const_iterator itEnd = setTermination.end( );

	while ( uiRet < uiAttributes )
	{
		string strAtlasNounModifier( vectAttributes[ uiRet ]->m_strValue );

		Atlas::AtlasSignalComponent AtlasNM( Atlas::GetAtlasNounModifierEnum( strAtlasNounModifier ) );

		if ( !AtlasNM.IsValid( ) )
		{
			string strError( strVirtualLabel );
				
			strError += ": Atlas noun/modifier: ";
			strError += strAtlasNounModifier;
	
			throw Exception( Exception::eUnknownAtlasNounModifierForCapability, __FILE__, __FUNCTION__, __LINE__, strError );
		}

		if ( itEnd != setTermination.find( AtlasNM.GetAtlasNounModifier( ) ) )
		{
			break;
		}

		++uiRet;

		if ( uiRet < uiAttributes )
		{
			for ( int i = 0; ( ( i < 2 ) && ( uiRet < uiAttributes ) ); ++i, ++uiRet )
			{
				const string& strWord = vectAttributes[ uiRet ]->m_strValue;
				const bool bPos = ( AtlasStatement::m_strPOS == strWord );
				const bool bNeg = ( AtlasStatement::m_strNEG == strWord );
	
				if ( bPos || bNeg )
				{
					switch ( AtlasNM.GetAtlasNounModifier( ) )
					{
						case Atlas::eHORIZONTAL:
							m_iBitField |= ( bPos ? eHorizontalPos : eHorizontalNeg );
							break;
		
						case Atlas::eVERTICAL:
							m_iBitField |= ( bPos ? eVerticalPos : eVerticalNeg );
							break;
		
						case Atlas::eCOMPOSITE:
							m_iBitField |= ( bPos ? eCompositePos : eCompositeNeg );
							break;
		
						default:
							if ( 0 == i )
							{
								string strError( strVirtualLabel );
									
								strError += ": noun/modifier: ";
								strError += strAtlasNounModifier;
						
								throw Exception( Exception::eUnexpectedAttributeForVideoCapability, __FILE__, __FUNCTION__, __LINE__, strError );
							}
						break;
					}
				}
				else if ( 0 == i )
				{
					string strError( strVirtualLabel );
						
					strError += ": noun/modifier: ";
					strError += strAtlasNounModifier;
			
					throw Exception( Exception::eUnexpectedAttributeForVideoCapability, __FILE__, __FUNCTION__, __LINE__, strError );
				}
			}
		}
	}

	return uiRet;
}

void VideoSyncPolarity::Merge( const VideoSyncPolarity& other )
{
	if ( this != &other )
	{
		m_iBitField |= other.m_iBitField;
	}
}

void VideoSyncPolarity::InitSignalComponents( void )
{
	// None
}

bool VideoSyncPolarity::HasNounModifier( const Atlas::eAtlasNounModifier eModifier ) const
{
	bool bHasNounModifier = false;

	if ( m_iBitField > 0 )
	{
		switch ( eModifier )
		{
			case Atlas::eHORIZONTAL:
				if ( eHorizontalPos == ( m_iBitField & eHorizontalPos ) )
				{
					bHasNounModifier = true;
				}
				else if ( eHorizontalNeg == ( m_iBitField & eHorizontalNeg ) )
				{
					bHasNounModifier = true;
				}
				break;

			case Atlas::eVERTICAL:
				if ( eVerticalPos == ( m_iBitField & eVerticalPos ) )
				{
					bHasNounModifier = true;
				}
				else if ( eVerticalNeg == ( m_iBitField & eVerticalNeg ) )
				{
					bHasNounModifier = true;
				}
				break;

			case Atlas::eCOMPOSITE:
				if ( eCompositePos == ( m_iBitField & eCompositePos ) )
				{
					bHasNounModifier = true;
				}
				else if ( eCompositeNeg == ( m_iBitField & eCompositeNeg ) )
				{
					bHasNounModifier = true;
				}
				break;
		}
	}

	return bHasNounModifier;
}

void VideoSyncPolarity::ToXML( string& strXML )
{
	if ( 0 != m_iBitField )
	{
		strXML += XML::MakeOpenXmlElementWithChildren( XML::enSyncPolarity );
	
		if ( 0 != m_iBitField )
		{
			string strHorizontal;
			string strVertical;
			string strComposite;

			// HORIZONTAL
			if ( m_iBitField & eHorizontalPos )
			{
				strHorizontal += XML::MakeXmlAttributeNameValue( XML::anPositive, XML::avTrue );
			}
			if ( m_iBitField & eHorizontalNeg )
			{
				strHorizontal += XML::MakeXmlAttributeNameValue( XML::anNegative, XML::avTrue );
			}
			if ( !strHorizontal.empty( ) )
			{
				strXML += XML::MakeXmlElementNoChildren( XML::enHorizontal, strHorizontal );
			}


			// VERTICAL
			if ( m_iBitField & eVerticalPos )
			{
				strVertical += XML::MakeXmlAttributeNameValue( XML::anPositive, XML::avTrue );
			}
			if ( m_iBitField & eVerticalNeg )
			{
				strVertical += XML::MakeXmlAttributeNameValue( XML::anNegative, XML::avTrue );
			}
			if ( !strVertical.empty( ) )
			{
				strXML += XML::MakeXmlElementNoChildren( XML::enVertical, strVertical );
			}
			

			// COMPOSITE
			if ( m_iBitField & eCompositePos )
			{
				strComposite += XML::MakeXmlAttributeNameValue( XML::anPositive, XML::avTrue );
			}
			if ( m_iBitField & eCompositeNeg )
			{
				strComposite += XML::MakeXmlAttributeNameValue( XML::anNegative, XML::avTrue );
			}
			if ( !strComposite.empty( ) )
			{
				strXML += XML::MakeXmlElementNoChildren( XML::enComposite, strComposite );
			}
		}

		strXML += XML::MakeCloseXmlElementWithChildren( XML::enSyncPolarity );
	}
}

void VideoVideo::GarbageCollect( void )
{
	unsigned int uiSize = m_vectRanges.size( );
	for ( unsigned int ui = 0; ui < uiSize; ++ui )
	{
		delete m_vectRanges[ ui ].second;
	}
	m_vectRanges.clear( );

	m_vectTypes.clear( );
}

VideoVideo& VideoVideo::operator = ( const VideoVideo& other )
{
	if ( this != &other )
	{
		GarbageCollect( );

		m_vectTypes = other.m_vectTypes;

		unsigned int uiSize = other.m_vectRanges.size( );
		if ( uiSize > 0 )
		{
			for ( unsigned int ui = 0; ui < uiSize; ++ui )
			{
				const pair< Atlas::AtlasSignalComponent, Range* >& prOther = other.m_vectRanges[ ui ];
				Range* pRange = 0;

				try
				{
					pRange = new Range( *( prOther.second ) );
				}
				catch ( ... )
				{
					throw Exception( Exception::eFailedToCreateVideoObject, __FILE__, __FUNCTION__, __LINE__ );
				}
	
				m_vectRanges.push_back( make_pair( prOther.first, pRange ) );
			}
		}
	}

	return *this;
}

unsigned int VideoVideo::Init( const string& strVirtualLabel, const vector< const AtlasAttributes::AtlasAttibuteValue* >& vectAttributes, const unsigned int uiStart, const set< Atlas::eAtlasNounModifier >& setTermination )
{
	unsigned int uiRet = uiStart;
	const unsigned int uiAttributes = vectAttributes.size( );
	const set< Atlas::eAtlasNounModifier >::const_iterator itEnd = setTermination.end( );

	while ( uiRet < uiAttributes )
	{
		string strAtlasNounModifier( vectAttributes[ uiRet ]->m_strValue );

		Atlas::AtlasSignalComponent AtlasNM( Atlas::GetAtlasNounModifierEnum( strAtlasNounModifier ) );

		if ( !AtlasNM.IsValid( ) )
		{
			string strError( strVirtualLabel );
				
			strError += ": Atlas noun/modifier: ";
			strError += strAtlasNounModifier;
	
			throw Exception( Exception::eUnknownAtlasNounModifierForCapability, __FILE__, __FUNCTION__, __LINE__, strError );
		}

		if ( itEnd != setTermination.find( AtlasNM.GetAtlasNounModifier( ) ) )
		{
			break;
		}

		++uiRet;

		if ( uiRet < uiAttributes )
		{
			const string& strWord = vectAttributes[ uiRet ]->m_strValue;

			if ( AtlasStatement::m_strRANGE == strWord )
			{
				Range* pRange = 0;
				
				try
				{
					pRange = new Range;
				}
				catch ( ... )
				{
					string strError( strVirtualLabel );
	
					strError += ": capability range";
	
					throw Exception( Exception::eFailedToCreateRangeObject, __FILE__, __FUNCTION__, __LINE__, strError );
				}

				m_vectRanges.push_back( make_pair( AtlasNM, pRange ) );
	
				uiRet = pRange->Init( strVirtualLabel, vectAttributes, uiRet + 1  );
			}
			else
			{
				m_vectTypes.push_back( AtlasNM );
			}
		}
	}

	return uiRet;
}

void VideoVideo::Merge( const VideoVideo& other )
{
	if ( this != &other )
	{
		NounModifier::MergeAtlasSignalComponents( m_vectTypes, other.m_vectTypes );
		Range::MergeSignalRanges( m_vectRanges, other.m_vectRanges );
	}
}

void VideoVideo::InitSignalComponents( void )
{
	NounModifier::InitSignalComponents( m_vectTypes );
	Range::InitSignalComponents( m_vectRanges );
}

bool VideoVideo::HasNounModifier( const Atlas::eAtlasNounModifier eModifier ) const
{ 
	bool bHasNounModifier = false;

	if ( Range::HasNounModifier( eModifier, m_vectRanges ) )
	{
		bHasNounModifier = true;
	}
	else if ( NounModifier::HasNounModifier( eModifier, m_vectTypes ) )
	{
		bHasNounModifier = true;
	}

	return bHasNounModifier;
}


void VideoVideo::ToXML( string& strXML )
{
	if ( ( m_vectTypes.size( ) > 0 ) || ( m_vectRanges.size( ) > 0 ) )
	{
		strXML += XML::MakeOpenXmlElementWithChildren( XML::enVideo );
	
		Range::ToXML( strXML, m_vectRanges );
		NounModifier::ToXML( strXML, m_vectTypes, XML::enModifiers, XML::enModifier );

		strXML += XML::MakeCloseXmlElementWithChildren( XML::enVideo );
	}
}

void VideoImage::GarbageCollect( void )
{
	const unsigned int uiSize = m_vectRanges.size( );

	for ( unsigned int ui = 0; ui < uiSize; ++ui )
	{
		delete m_vectRanges[ ui ].second;
	}
	m_vectRanges.clear( );
}

VideoImage& VideoImage::operator = ( const VideoImage& other )
{
	if ( this != &other )
	{
		GarbageCollect( );

		const unsigned int uiSize = other.m_vectRanges.size( );

		if ( uiSize > 0 )
		{
			for ( unsigned int ui = 0; ui < uiSize; ++ui )
			{
				const pair< Atlas::AtlasSignalComponent, Range* >& prOther = other.m_vectRanges[ ui ];
				Range* pRange = 0;
				
				try
				{
					pRange = new Range( *( prOther.second ) );
				}
				catch ( ... )
				{
					throw Exception( Exception::eFailedToCreateVideoObject, __FILE__, __FUNCTION__, __LINE__ );
				}
	
				m_vectRanges.push_back( make_pair( prOther.first, pRange ) );
			}
		}
	}

	return *this;
}

void VideoImage::Merge( const VideoImage& other )
{
	if ( this != &other )
	{
		Range::MergeSignalRanges( m_vectRanges, other.m_vectRanges );
	}
}

void VideoImage::InitSignalComponents( void )
{
	Range::InitSignalComponents( m_vectRanges );
}

bool VideoImage::HasNounModifier( const Atlas::eAtlasNounModifier eModifier ) const
{ 
	return Range::HasNounModifier( eModifier, m_vectRanges );
}

void VideoImage::ToXML( string& strXML )
{
	if ( m_vectRanges.size( ) > 0 )
	{
		strXML += XML::MakeOpenXmlElementWithChildren( XML::enImage );
	
		Range::ToXML( strXML, m_vectRanges );

		strXML += XML::MakeCloseXmlElementWithChildren( XML::enImage );
	}
}

void VideoDraw::GarbageCollect( void )
{
	unsigned int uiSize = m_vectRanges.size( );
	for ( unsigned int ui = 0; ui < uiSize; ++ui )
	{
		delete m_vectRanges[ ui ].second;
	}
	m_vectRanges.clear( );

	m_vectTypes.clear( );
}

VideoDraw& VideoDraw::operator = ( const VideoDraw& other )
{
	if ( this != &other )
	{
		GarbageCollect( );

		m_vectTypes = other.m_vectTypes;

		unsigned int uiSize = other.m_vectRanges.size( );
		if ( uiSize > 0 )
		{
			for ( unsigned int ui = 0; ui < uiSize; ++ui )
			{
				const pair< Atlas::AtlasSignalComponent, Range* >& prOther = other.m_vectRanges[ ui ];
				Range* pRange = 0;
				
				try
				{
					pRange = new Range( *( prOther.second ) );
				}
				catch ( ... )
				{
					throw Exception( Exception::eFailedToCreateVideoObject, __FILE__, __FUNCTION__, __LINE__ );
				}
	
				m_vectRanges.push_back( make_pair( prOther.first, pRange ) );
			}
		}
	}

	return *this;
}

unsigned int VideoDraw::Init( const string& strVirtualLabel, const vector< const AtlasAttributes::AtlasAttibuteValue* >& vectAttributes, const unsigned int uiStart, const set< Atlas::eAtlasNounModifier >& setTermination )
{
	unsigned int uiRet = uiStart;
	const unsigned int uiAttributes = vectAttributes.size( );
	const set< Atlas::eAtlasNounModifier >::const_iterator itEnd = setTermination.end( );

	while ( uiRet < uiAttributes )
	{
		string strAtlasNounModifier( vectAttributes[ uiRet ]->m_strValue );

		Atlas::AtlasSignalComponent AtlasNM( Atlas::GetAtlasNounModifierEnum( strAtlasNounModifier ) );

		if ( !AtlasNM.IsValid( ) )
		{
			string strError( strVirtualLabel );
				
			strError += ": Atlas noun/modifier: ";
			strError += strAtlasNounModifier;
	
			throw Exception( Exception::eUnknownAtlasNounModifierForCapability, __FILE__, __FUNCTION__, __LINE__, strError );
		}

		if ( itEnd != setTermination.find( AtlasNM.GetAtlasNounModifier( ) ) )
		{
			break;
		}

		++uiRet;

		if ( uiRet < uiAttributes )
		{
			const string& strWord = vectAttributes[ uiRet ]->m_strValue;

			if ( AtlasStatement::m_strRANGE == strWord )
			{
				Range* pRange = 0;
				
				try
				{
					pRange = new Range;
				}
				catch ( ... )
				{
					string strError( strVirtualLabel );
	
					strError += ": capability range";
	
					throw Exception( Exception::eFailedToCreateRangeObject, __FILE__, __FUNCTION__, __LINE__, strError );
				}

				m_vectRanges.push_back( make_pair( AtlasNM, pRange ) );
	
				uiRet = pRange->Init( strVirtualLabel, vectAttributes, uiRet + 1  );
			}
			else
			{
				m_vectTypes.push_back( AtlasNM );
			}
		}
	}

	return uiRet;
}

void VideoDraw::Merge( const VideoDraw& other )
{
	if ( this != &other )
	{
		NounModifier::MergeAtlasSignalComponents( m_vectTypes, other.m_vectTypes );
		Range::MergeSignalRanges( m_vectRanges, other.m_vectRanges );
	}
}

void VideoDraw::InitSignalComponents( void )
{
	NounModifier::InitSignalComponents( m_vectTypes );
	Range::InitSignalComponents( m_vectRanges );
}

bool VideoDraw::HasNounModifier( const Atlas::eAtlasNounModifier eModifier ) const
{ 
	bool bHasNounModifier = false;

	if ( Range::HasNounModifier( eModifier, m_vectRanges ) )
	{
		bHasNounModifier = true;
	}
	else if ( NounModifier::HasNounModifier( eModifier, m_vectTypes ) )
	{
		bHasNounModifier = true;
	}

	return bHasNounModifier;
}


void VideoDraw::ToXML( string& strXML )
{
	if ( ( m_vectTypes.size( ) > 0 ) || ( m_vectRanges.size( ) > 0 ) )
	{
		strXML += XML::MakeOpenXmlElementWithChildren( XML::enDraw );
	
		Range::ToXML( strXML, m_vectRanges );
		NounModifier::ToXML( strXML, m_vectTypes, XML::enModifiers, XML::enModifier );

		strXML += XML::MakeCloseXmlElementWithChildren( XML::enDraw );
	}
}