/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

#include <algorithm>
#include "atlas_noun_modifier.h"
#include "aixml.h"
#include "require.h"
#include "complex_signal.h"

#if ( _DEBUG ) && ( WIN32 )
	#define WINVER 0x0600
	#include <afx.h>
	#define new DEBUG_NEW
	#undef THIS_FILE
	static char BASED_CODE THIS_FILE[ ] = __FILE__;
#endif

Atlas::AtlasNumber* NounModifier::GetAtlasVariable( const string& strVirtualLabel, const vector< const AtlasAttributes::AtlasAttibuteValue* >& vectAttributes, unsigned int& uiStart, const bool bIncrementCounter )
{
	const unsigned int uiAttributes = vectAttributes.size( );
	Atlas::AtlasNumber* pNumber = 0;

	if ( uiStart < uiAttributes )
	{
		if ( vectAttributes[ uiStart ]->IsVariable( ) )
		{
			try
			{
				pNumber = new Atlas::AtlasNumber;
			}
			catch ( ... )
			{
				throw Exception( Exception::eFailedToCreateNumberObject, __FILE__, __FUNCTION__, __LINE__, strVirtualLabel );
			}

			pNumber->SetVariableName( vectAttributes[ uiStart ]->m_strValue );

			++uiStart;

			// Does it have a unit of measure?
			if ( uiStart < uiAttributes )
			{
				const Atlas::AtlasUnitOfMeasure AtlasUnit = GetAtlasUnitOfMeasureByAlasUnit( vectAttributes[ uiStart ]->m_strValue, false, strVirtualLabel );
			
				if ( AtlasUnit.IsUnit( ) )
				{
					pNumber->SetUnitOfMeasure( AtlasUnit );
		
					++uiStart;
				}
			}

			if ( !bIncrementCounter )
			{
				--uiStart;
			}
		}
	}

	return pNumber;
}

Atlas::AtlasErrorLimit NounModifier::GetAtlasErrorLimit( const string& strVirtualLabel, const vector< const AtlasAttributes::AtlasAttibuteValue* >& vectAttributes, unsigned int& uiStart, const bool bIncrementCounter )
{
	const unsigned int uiAttributes = vectAttributes.size( );
	Atlas::AtlasErrorLimit elRet;

	if ( uiStart < uiAttributes )
	{
		auto_ptr< Atlas::AtlasNumber > autopErrorLimit1;
		auto_ptr< Atlas::AtlasNumber > autopErrorLimit2;

		if ( vectAttributes[ uiStart ]->IsConstant( ) )
		{
			autopErrorLimit1.reset( GetAtlasNumber( strVirtualLabel, vectAttributes, uiStart, true ) );

			if ( !autopErrorLimit1->IsNaN( ) )
			{
				if ( autopErrorLimit1->IsSymmetricalErrorLimit( ) )
				{
					string strErrorLimit( autopErrorLimit1->GetNumber( false ) );

					if ( !strErrorLimit.empty( ) )
					{
						strErrorLimit[ 0 ] = '-';

						Atlas::AtlasNumber* pAtlasNumber = 0;

						try
						{
							pAtlasNumber = new Atlas::AtlasNumber( strErrorLimit );
						}
						catch ( ... )
						{
							throw Exception( Exception::eFailedToCreateNumberObject, __FILE__, __FUNCTION__, __LINE__, strVirtualLabel );
						}

						autopErrorLimit2.reset( pAtlasNumber );

						pAtlasNumber->SetUnitOfMeasure( autopErrorLimit1->GetUnitOfMeasure( ) );
					}
				}
			}
		}
		else if ( vectAttributes[ uiStart ]->IsVariable( ) )
		{
			Atlas::AtlasNumber* pAtlasNumber = 0;
				
			try
			{
				pAtlasNumber = new Atlas::AtlasNumber;
			}
			catch ( ... )
			{
				throw Exception( Exception::eFailedToCreateNumberObject, __FILE__, __FUNCTION__, __LINE__, strVirtualLabel );
			}

			autopErrorLimit1.reset( pAtlasNumber );

			pAtlasNumber->SetVariableName( vectAttributes[ uiStart ]->m_strValue );

			++uiStart;

			// Does it have a unit of measure?
			if ( uiStart < uiAttributes )
			{
				const Atlas::AtlasUnitOfMeasure AtlasUnit = GetAtlasUnitOfMeasureByAlasUnit( vectAttributes[ uiStart ]->m_strValue, false, strVirtualLabel );
			
				if ( AtlasUnit.IsUnit( ) )
				{
					pAtlasNumber->SetUnitOfMeasure( AtlasUnit );

					++uiStart;
				}
			}
		}

		if ( 0 == autopErrorLimit2.get( ) )
		{
			if ( uiStart < uiAttributes )
			{
				if ( vectAttributes[ uiStart ]->IsConstant( ) )
				{
					autopErrorLimit2.reset( GetAtlasNumber( strVirtualLabel, vectAttributes, uiStart, true ) );
				}
				else if ( vectAttributes[ uiStart ]->IsVariable( ) )
				{
					Atlas::AtlasNumber* pAtlasNumber = 0;
					
					try
					{
						pAtlasNumber = new Atlas::AtlasNumber;
					}
					catch ( ... )
					{
						throw Exception( Exception::eFailedToCreateNumberObject, __FILE__, __FUNCTION__, __LINE__, strVirtualLabel );
					}
		
					autopErrorLimit2.reset( pAtlasNumber );
		
					pAtlasNumber->SetVariableName( vectAttributes[ uiStart ]->m_strValue );
		
					++uiStart;
		
					// Does it have a unit of measure?
					if ( uiStart < uiAttributes )
					{
						const Atlas::AtlasUnitOfMeasure AtlasUnit = GetAtlasUnitOfMeasureByAlasUnit( vectAttributes[ uiStart ]->m_strValue, false, strVirtualLabel );
					
						if ( AtlasUnit.IsUnit( ) )
						{
							pAtlasNumber->SetUnitOfMeasure( AtlasUnit );
	
							++uiStart;
						}
					}
				}
		}
		}

		if ( !bIncrementCounter )
		{
			--uiStart;
		}
	
		elRet.SetLimit1( autopErrorLimit1.release( ) );
		elRet.SetLimit2( autopErrorLimit2.release( ) );
	}

	return elRet;
}

Atlas::AtlasNumber* NounModifier::GetAtlasNumber( const string& strVirtualLabel, const vector< const AtlasAttributes::AtlasAttibuteValue* >& vectAttributes, unsigned int& uiStart, const bool bIncrementCounter )
{
	const unsigned int uiAttributes = vectAttributes.size( );

	if ( ( uiStart + 1 ) >= uiAttributes )
	{
		throw Exception( Exception::eInvalidArrayPositionToCreateNumber, __FILE__, __FUNCTION__, __LINE__, strVirtualLabel );
	}

	string strNumber( vectAttributes[ uiStart ]->m_strValue );
	unsigned int uiSymmetricalErrorLimit = 0;

	if ( strNumber.size( ) >= 2 )
	{
		const unsigned int uiCount = ( strNumber[ 0 ] + strNumber[ 1 ] );

		if ( uiCount == ( '+' + '-' ) )
		{
			uiSymmetricalErrorLimit = 2;
		}
	}

	if ( uiSymmetricalErrorLimit > 0 )
	{
		strNumber = '+';
		strNumber += vectAttributes[ uiStart ]->m_strValue.substr( uiSymmetricalErrorLimit );
	}

	Atlas::AtlasNumber* pAtlasNumber = 0;
	
	try
	{
		pAtlasNumber = new Atlas::AtlasNumber( VerifyNumber( strNumber, strVirtualLabel ) );
	}
	catch ( ... )
	{
		throw Exception( Exception::eFailedToCreateNumberObject, __FILE__, __FUNCTION__, __LINE__, strVirtualLabel );
	}

	++uiStart;

	const Atlas::AtlasUnitOfMeasure AtlasUnit = GetAtlasUnitOfMeasureByAlasUnit( vectAttributes[ uiStart ]->m_strValue, false, strVirtualLabel );

	if ( !AtlasUnit.IsUnit( ) )
	{
		--uiStart;
	}

	if ( bIncrementCounter )
	{
		++uiStart;
	}

	pAtlasNumber->SetUnitOfMeasure( AtlasUnit );

	if ( uiSymmetricalErrorLimit > 0 )
	{
		pAtlasNumber->SetSymmetricalErrorLimit( true );
	}

	return pAtlasNumber;
}

const string& NounModifier::VerifyNumber( const string& strNumber, const string& strVirtualLabel )
{
	if ( !AIXMLHelper::IsNumber( strNumber ) )
	{
		string strError( strVirtualLabel );

		strError += ": ";
		strError += strNumber;

		throw Exception( Exception::eInvalidNumber, __FILE__, __FUNCTION__, __LINE__, strError );
	}

	return strNumber;
}

Atlas::AtlasUnitOfMeasure NounModifier::GetAtlasUnitOfMeasureByAlasUnit( const string& strUnit, const bool bThrowOnNotFound, const string& strVirtualLabel, Exception::eErrorType e )
{
	Atlas::AtlasUnitOfMeasure AtlasUnit;
	Atlas::eUnitOfMeasure eUnit = Atlas::eUnknownUnitOfMeasure;
	Atlas::eUnitOfMeasure eAcceleration = Atlas::eUnknownUnitOfMeasure;
	Atlas::eUnitOfMeasure eAccelerationUnit = Atlas::eUnknownUnitOfMeasure;
	bool bFoundError = true;

	if ( strUnit.length( ) > 0 )
	{
		if ( string::npos == strUnit.find( AtlasStatement::m_strFrontSlash ) )
		{
			eUnit = Atlas::GetUnitOfMeasureEnumByAlasUnit( strUnit );

			bFoundError = ( Atlas::eUnknownUnitOfMeasure == eUnit );
		}
		else
		{
			const vector< string > vectUnitNames( AIXMLHelper::SplitString< string >( strUnit, AtlasStatement::m_strFrontSlash ) );
			const unsigned int uiSize = vectUnitNames.size( );

			if ( uiSize < 4 )
			{
				bFoundError = false;

				if ( uiSize == 3 )
				{
					eAccelerationUnit = Atlas::GetUnitOfMeasureEnumByAlasUnit( vectUnitNames[ 2 ] );

					bFoundError = ( Atlas::eUnknownUnitOfMeasure == eAccelerationUnit );
				}

				if ( !bFoundError )
				{
					eUnit = Atlas::GetUnitOfMeasureEnumByAlasUnit( vectUnitNames[ 0 ] );
					eAcceleration = Atlas::GetUnitOfMeasureEnumByAlasUnit( vectUnitNames[ 1 ] );

					bFoundError = ( ( Atlas::eUnknownUnitOfMeasure == eUnit ) || ( Atlas::eUnknownUnitOfMeasure == eAcceleration ) );
				}
			}
			else if ( bThrowOnNotFound )
			{
				string strError( strVirtualLabel );
					
				strError += ": data type: ";
				strError += strUnit;
		
				if ( Exception::eUnknownError == e )
				{
					e = Exception::eTooManyDataTypesForUnitOfMeasure;
				}

				throw Exception( e, __FILE__, __FUNCTION__, __LINE__, strError );
			}
		}
	}

	if ( bFoundError )
	{
		if ( bThrowOnNotFound )
		{
			string strError( strVirtualLabel );
				
			strError += ": data type: ";
			strError += strUnit;
	
			if ( Exception::eUnknownError == e )
			{
				e = Exception::eUnknownDataType;
			}
	
			throw Exception( e, __FILE__, __FUNCTION__, __LINE__, strError );
		}
	}
	else
	{
		AtlasUnit.Set( eUnit, eAcceleration, eAccelerationUnit );
	}

	return AtlasUnit;
}

void NounModifier::MergeSignalNumbers( vector< pair< Atlas::AtlasSignalComponent, Atlas::AtlasNumber* > >& vectNumbers, const vector< pair< Atlas::AtlasSignalComponent, Atlas::AtlasNumber* > >& vectOtherNumbers, const bool bMaximumMerge )
{
	const unsigned int uiSize = vectNumbers.size( );
	const unsigned int uiSizeOther = vectOtherNumbers.size( );

	if ( ( uiSize > 0 ) && ( uiSizeOther > 0 ) )
	{
		map< string, unsigned int > mapVect;
		map< string, unsigned int > mapVectOther;

		for ( unsigned int ui = 0; ui < uiSize; ++ui )
		{
			mapVect.insert( make_pair( ( string ) vectNumbers[ ui ].first, ui ) );
		}

		for ( unsigned int ui = 0; ui < uiSizeOther; ++ui )
		{
			mapVectOther.insert( make_pair( ( string ) vectOtherNumbers[ ui ].first, ui ) );
		}

		map< string, unsigned int >::const_iterator it;
		const map< string, unsigned int >::const_iterator itEnd = mapVect.end( );
		map< string, unsigned int >::const_iterator itOther;
		const map< string, unsigned int >::const_iterator itEndOther = mapVectOther.end( );

		// If in both, merge
		for ( unsigned int ui = 0; ui < uiSize; ++ui )
		{
			itOther = mapVectOther.find( vectNumbers[ ui ].first );

			if ( itEndOther != itOther )
			{
				if ( bMaximumMerge )
				{
					vectNumbers[ ui ].second->ReplaceIfLarger( *( vectOtherNumbers[ itOther->second ].second ) );
				}
				else
				{
					vectNumbers[ ui ].second->ReplaceIfSmaller( *( vectOtherNumbers[ itOther->second ].second ) );
				}
			}
		}

		// If only in other, copy
		for ( unsigned int ui = 0; ui < uiSizeOther; ++ui )
		{
			it = mapVect.find( vectOtherNumbers[ ui ].first );

			if ( itEnd == it )
			{
				const pair< Atlas::AtlasSignalComponent, Atlas::AtlasNumber* >& prOther = vectOtherNumbers[ ui ];
				Atlas::AtlasNumber* pNumber = 0;
					
				try
				{
					pNumber = new Atlas::AtlasNumber( *( prOther.second ) );
				}
				catch ( ... )
				{
					throw Exception( Exception::eFailedToCreateNumberObject, __FILE__, __FUNCTION__, __LINE__ );
				}
	
				vectNumbers.push_back( make_pair( prOther.first, pNumber ) );
			}
		}
	}
	else if ( uiSizeOther > 0 )
	{
		for ( unsigned int ui = 0; ui < uiSizeOther; ++ui )
		{
			const pair< Atlas::AtlasSignalComponent, Atlas::AtlasNumber* >& prOther = vectOtherNumbers[ ui ];
			Atlas::AtlasNumber* pNumber = 0;
			
			try
			{
				pNumber = new Atlas::AtlasNumber( *( prOther.second ) );
			}
			catch ( ... )
			{
				throw Exception( Exception::eFailedToCreateNumberObject, __FILE__, __FUNCTION__, __LINE__ );
			}

			vectNumbers.push_back( make_pair( prOther.first, pNumber ) );
		}
	}
}

void NounModifier::MergeAtlasSignalComponents( vector< Atlas::AtlasSignalComponent >& vectAtlasSignalComponents, const vector< Atlas::AtlasSignalComponent >& vectOtherAtlasSignalComponents )
{
	const unsigned int uiSize = vectAtlasSignalComponents.size( );
	const unsigned int uiSizeOther = vectOtherAtlasSignalComponents.size( );

	if ( ( uiSize > 0 ) && ( uiSizeOther > 0 ) )
	{
		map< string, unsigned int > mapVect;

		for ( unsigned int ui = 0; ui < uiSize; ++ui )
		{
			mapVect.insert( make_pair( ( string ) vectAtlasSignalComponents[ ui ], ui ) );
		}

		map< string, unsigned int >::const_iterator it;
		const map< string, unsigned int >::const_iterator itEnd = mapVect.end( );

		// If only in other, copy
		for ( unsigned int ui = 0; ui < uiSizeOther; ++ui )
		{
			it = mapVect.find( ( string ) vectOtherAtlasSignalComponents[ ui ] );

			if ( itEnd == it )
			{
				vectAtlasSignalComponents.push_back( vectOtherAtlasSignalComponents[ ui ] );
			}
		}
	}
	else if ( uiSizeOther > 0 )
	{
		for ( unsigned int ui = 0; ui < uiSizeOther; ++ui )
		{
			vectAtlasSignalComponents.push_back( vectOtherAtlasSignalComponents[ ui ] );
		}
	}
}

void NounModifier::ToXML( string& strXML, const vector< Atlas::AtlasSignalComponent >& vectAtlasSignalComponents, const XML::ElementName eParentName, const XML::ElementName eChildName )
{
	const unsigned int uiSignal = vectAtlasSignalComponents.size( );

	if ( uiSignal > 0 )
	{
		strXML += XML::MakeOpenXmlElementWithChildren( eParentName, XML::MakeXmlAttributeNameValue( XML::anCount, uiSignal ) );

		for ( unsigned int ui = 0; ui < uiSignal; ++ui )
		{
			strXML += XML::MakeOpenXmlElementWithChildren( eChildName );
			strXML += vectAtlasSignalComponents[ ui ].ToXML( );
			strXML += XML::MakeCloseXmlElementWithChildren( eChildName );
		}
	
		strXML += XML::MakeCloseXmlElementWithChildren( eParentName );
	}
}

void NounModifier::ToXML( string& strXML, const vector< pair< Atlas::AtlasSignalComponent, Atlas::AtlasNumber* > >& vectNumbers, const XML::ElementName eOutterName, const XML::ElementName eInnerName )
{
	const unsigned int uiNumbers = vectNumbers.size( );

	if ( uiNumbers > 0 )
	{
		strXML += XML::MakeOpenXmlElementWithChildren( eOutterName, XML::MakeXmlAttributeNameValue( XML::anCount, uiNumbers ) );

		for ( unsigned int ui = 0; ui < uiNumbers; ++ui )
		{
			const pair< Atlas::AtlasSignalComponent, Atlas::AtlasNumber* >& pr = vectNumbers[ ui ];

			strXML += XML::MakeOpenXmlElementWithChildren( eInnerName );

			strXML += pr.first.ToXML( );

			if ( 0 != pr.second )
			{
				if ( !pr.second->IsNaN( ) )
				{
					strXML += XML::MakeXmlElementNoChildren( XML::enNumber, pr.second->ToXML( ) );
				}
			}

			strXML += XML::MakeCloseXmlElementWithChildren( eInnerName );
		}
	
		strXML += XML::MakeCloseXmlElementWithChildren( eOutterName );
	}
}

void NounModifier::InitSignalComponents( vector< Atlas::AtlasSignalComponent >& vectSignalComps )
{
	const unsigned int uiSignalComps = vectSignalComps.size( );

	if ( uiSignalComps > 0 )
	{
		for ( unsigned int ui = 0; ui < uiSignalComps; ++ui )
		{
			vectSignalComps[ ui ].Set1641( );
		}
	}
}

void NounModifier::InitSignalComponents( vector< pair< Atlas::AtlasSignalComponent, Atlas::AtlasNumber* > >& vectNumbers )
{
	const unsigned int uiNumbers = vectNumbers.size( );

	if ( uiNumbers > 0 )
	{
		for ( unsigned int ui = 0; ui < uiNumbers; ++ui )
		{
			vectNumbers[ ui ].first.Set1641( );
		}
	}
}

bool NounModifier::HasNounModifier( const Atlas::eAtlasNounModifier eModifier, const vector< Atlas::AtlasSignalComponent >& vectAtlasNounMod )
{
	const unsigned int uiSize = vectAtlasNounMod.size( );
	bool bHasNounModifier = false;

	for ( unsigned int ui = 0; ui < uiSize; ++ui )
	{
		if ( eModifier == vectAtlasNounMod[ ui ].GetAtlasNounModifier( ) )
		{
			bHasNounModifier = true;
			break;
		}
	}

	return bHasNounModifier;
}

bool NounModifier::HasNounModifier( const Atlas::eAtlasNounModifier eModifier, const vector< pair< Atlas::AtlasSignalComponent, Atlas::AtlasNumber* > >& vectNumbers )
{
	const unsigned int uiSize = vectNumbers.size( );
	bool bHasNounModifier = false;

	for ( unsigned int ui = 0; ui < uiSize; ++ui )
	{
		if ( eModifier == vectNumbers[ ui ].first.GetAtlasNounModifier( ) )
		{
			bHasNounModifier = true;
			break;
		}
	}

	return bHasNounModifier;
}

Mode& Mode::operator = ( const Mode& other )
{
	if ( this != &other )
	{
		GarbageCollect( );

		m_vectMode = other.m_vectMode;
		m_eNoun = other.m_eNoun;
	}

	return *this;
}

unsigned int Mode::Init( const string& strVirtualLabel, vector< const AtlasAttributes::AtlasAttibuteValue* >& vectAttributes, const unsigned int uiStart )
{
	const unsigned int uiSize = vectAttributes.size( );
	unsigned int uiRet = uiStart;

	while ( uiRet < uiSize )
	{
		const Atlas::eAtlasFunction eFunction = Atlas::GetAtlasFunctionEnum( vectAttributes[ uiRet ]->m_strValue );

		if ( Atlas::eUnknownAtlasFunction != eFunction )
		{
			Atlas::AtlasSignalComponent AtlasSig( m_eNoun, Atlas::eUnknownAtlasNounModifier, eFunction );

			m_vectMode.push_back( AtlasSig );
			++uiRet;
		}
		else
		{
			break;
		}
	}

	return uiRet;
}

void Mode::InitSignalComponents( void )
{
	NounModifier::InitSignalComponents( m_vectMode );
}

void Mode::Merge( const Mode& other )
{
	if ( this != &other )
	{
		MergeAtlasSignalComponents( m_vectMode, other.m_vectMode );
	}
}

Circulate& Circulate::operator = ( const Circulate& other )
{
	if ( this != &other )
	{
		GarbageCollect( );

		if ( 0 != other.m_pCount )
		{
			try
			{
				m_pCount = new Atlas::AtlasNumber( *( other.m_pCount ) );
			}
			catch ( ... )
			{
				throw Exception( Exception::eFailedToCreateNumberObject, __FILE__, __FUNCTION__, __LINE__ );
			}
		}

		if ( 0 != other.m_pbContinuous )
		{
			try
			{
				m_pbContinuous = new bool( *( other.m_pbContinuous ) );
			}
			catch ( ... )
			{
				throw Exception( Exception::eFailedToCreateBoolObject, __FILE__, __FUNCTION__, __LINE__ );
			}
		}
	}

	return *this;
}

unsigned int Circulate::Init( const string& strVirtualLabel, vector< const AtlasAttributes::AtlasAttibuteValue* >& vectAttributes, const unsigned int uiStart )
{
	const unsigned int uiSize = vectAttributes.size( );
	unsigned int uiRet = uiStart;

	if ( uiRet < uiSize )
	{
		if ( AtlasStatement::m_strCONTINUOUS == vectAttributes[ uiRet ]->m_strValue )
		{
			if ( 0 != m_pbContinuous )
			{
				throw Exception( Exception::ePointerAlreadyUsed, __FILE__, __FUNCTION__, __LINE__, strVirtualLabel );
			}

			try
			{
				m_pbContinuous = new bool( true );
			}
			catch ( ... )
			{
				throw Exception( Exception::eFailedToCreateBoolObject, __FILE__, __FUNCTION__, __LINE__, strVirtualLabel );
			}

			++uiRet;
		}
		else if ( AIXMLHelper::IsNumber( vectAttributes[ uiRet ]->m_strValue ) )
		{
			m_pCount = GetAtlasNumber( strVirtualLabel, vectAttributes, uiRet );
		}
	}

	return uiRet;
}

void Circulate::Merge( const Circulate& other )
{
	if ( this != &other )
	{
		if ( ( 0 != m_pCount ) && ( 0 != other.m_pCount ) )
		{
			m_pCount->ReplaceIfLarger( *( other.m_pCount ) );
		}
		else if ( 0 != other.m_pCount )
		{
			try
			{
				m_pCount = new Atlas::AtlasNumber( *( other.m_pCount ) );
			}
			catch ( ... )
			{
				throw Exception( Exception::eFailedToCreateNumberObject, __FILE__, __FUNCTION__, __LINE__ );
			}
		}

		if ( ( 0 != m_pbContinuous ) && ( 0 != other.m_pbContinuous ) )
		{
			// -- TODO --
			// Not sure which should take precedence?
	
			#if ( _DEBUG ) && ( WIN32 )
				//DebugBreak( );
			#endif
		}
		else if ( 0 != other.m_pbContinuous )
		{
			try
			{
				m_pbContinuous = new bool( *( other.m_pbContinuous ) );
			}
			catch ( ... )
			{
				throw Exception( Exception::eFailedToCreateBoolObject, __FILE__, __FUNCTION__, __LINE__ );
			}
		}
	}
}

SourceIndentifier& SourceIndentifier::operator = ( const SourceIndentifier& other )
{
	if ( this != &other )
	{
		m_bChannelA = other.m_bChannelA;
		m_bChannelB = other.m_bChannelB;
	}

	return *this;
}

unsigned int SourceIndentifier::Init( const string& strVirtualLabel, vector< const AtlasAttributes::AtlasAttibuteValue* >& vectAttributes, const unsigned int uiStart )
{
	const unsigned int uiSize = vectAttributes.size( );
	unsigned int uiRet = uiStart;

	for ( int i = 0; i < 2; i++ )
	{
		if ( uiRet < uiSize )
		{
			if ( AtlasStatement::m_strChannelA == vectAttributes[ uiRet ]->m_strValue )
			{
				m_bChannelA = true;
				++uiRet;
			}
			else if ( AtlasStatement::m_strChannelB == vectAttributes[ uiRet ]->m_strValue )
			{
				m_bChannelB = true;
				++uiRet;
			}
		}
		else
		{
			break;
		}
	}

	return uiRet;
}

void SourceIndentifier::Merge( const SourceIndentifier& other )
{
	if ( this != &other )
	{
		if ( !m_bChannelA )
		{
			m_bChannelA = other.m_bChannelA;
		}

		if ( !m_bChannelB )
		{
			m_bChannelB = other.m_bChannelB;
		}
	}
}

Coupling& Coupling::operator = ( const Coupling& other )
{
	if ( this != &other )
	{
		m_bAC = other.m_bAC;
		m_bDC = other.m_bDC;
	}

	return *this;
}

unsigned int Coupling::Init( const string& strVirtualLabel, const vector< const AtlasAttributes::AtlasAttibuteValue* >& vectAttributes, const unsigned int uiStart )
{
	const unsigned int uiSize = vectAttributes.size( );
	unsigned int uiRet = uiStart;

	for ( int i = 0; i < 2; i++ )
	{
		if ( uiRet < uiSize )
		{
			if ( AtlasStatement::m_strAC == vectAttributes[ uiRet ]->m_strValue )
			{
				m_bAC = true;
				++uiRet;
			}
			else if ( AtlasStatement::m_strDC == vectAttributes[ uiRet ]->m_strValue )
			{
				m_bDC = true;
				++uiRet;
			}
		}
		else
		{
			break;
		}
	}

	return uiRet;
}

void Coupling::Merge( const Coupling& other )
{
	if ( this != &other )
	{
		if ( !m_bAC )
		{
			m_bAC = other.m_bAC;
		}

		if ( !m_bDC )
		{
			m_bDC = other.m_bDC;
		}
	}
}

SettingValues& SettingValues::operator = ( const SettingValues& other )
{
	if ( this != &other )
	{
		GarbageCollect( );

		m_bContinuous = other.m_bContinuous;

		const unsigned int uiSize = other.m_vectValues.size( );

		for ( unsigned int ui = 0; ui < uiSize; ++ui )
		{
			Atlas::AtlasNumber* pAtlasNumberOther = other.m_vectValues[ ui ];
			Atlas::AtlasNumber* pAtlasNumber = 0;

			try
			{
				pAtlasNumber = new Atlas::AtlasNumber( *pAtlasNumberOther );
			}
			catch ( ... )
			{
				throw Exception( Exception::eFailedToCreateNumberObject, __FILE__, __FUNCTION__, __LINE__ );
			}

			m_vectValues.push_back( pAtlasNumber );
		}
	}

	return *this;
}

unsigned int SettingValues::Init( const string& strVirtualLabel, const vector< const AtlasAttributes::AtlasAttibuteValue* >& vectAttributes, const unsigned int uiStart )
{
	const unsigned int uiSize = vectAttributes.size( );
	unsigned int uiRet = uiStart;

	while ( uiRet < uiSize )
	{
		if ( AIXMLHelper::IsNumber( vectAttributes[ uiRet ]->m_strValue ) )
		{
			Atlas::AtlasNumber* pNumber = 0;
			
			try
			{
				pNumber = new Atlas::AtlasNumber( vectAttributes[ uiRet ]->m_strValue );
			}
			catch ( ... )
			{
				throw Exception( Exception::eFailedToCreateNumberObject, __FILE__, __FUNCTION__, __LINE__, strVirtualLabel );
			}

			m_vectValues.push_back( pNumber );

			++uiRet;

			if ( uiRet < uiSize )
			{
				const Atlas::AtlasUnitOfMeasure AtlasUnit = GetAtlasUnitOfMeasureByAlasUnit( vectAttributes[ uiRet ]->m_strValue, false );
	
				if ( Atlas::eUnknownUnitOfMeasure != AtlasUnit.GetUnit( ) )
				{
					pNumber->SetUnitOfMeasure( AtlasUnit );
	
					++uiRet;
				}
			}
		}
		else
		{
			break;
		}
	}

	if ( uiRet < uiSize )
	{
		if ( AtlasStatement::m_strCONTINUOUS == vectAttributes[ uiRet ]->m_strValue )
		{
			m_bContinuous = true;

			++uiRet;
		}
	}

	return uiRet;
}

void SettingValues::ToXML( string& strXML ) const
{
	const unsigned int uiSettings = m_vectValues.size( );

	if ( uiSettings > 0 )
	{
		strXML += XML::MakeOpenXmlElementWithChildren( XML::enNumbers );

		for ( unsigned int ui = 0; ui < uiSettings; ++ui )
		{
			strXML += XML::MakeXmlElementNoChildren( XML::enNumber, m_vectValues[ ui ]->ToXML( ) );
		}

		strXML += XML::MakeCloseXmlElementWithChildren( XML::enNumbers );
	}
}

void SettingValues::InitSignalComponents( vector< pair< Atlas::AtlasSignalComponent, SettingValues* > >& vectSettings )
{
	const unsigned int uiSettings = vectSettings.size( );

	if ( uiSettings > 0 )
	{
		for ( unsigned int ui = 0; ui < uiSettings; ++ui )
		{
			vectSettings[ ui ].first.Set1641( );
		}
	}
}

bool SettingValues::HasNounModifier( const Atlas::eAtlasNounModifier eModifier, const vector< pair< Atlas::AtlasSignalComponent, SettingValues* > >& vectSettings )
{
	const unsigned int uiSize = vectSettings.size( );
	bool bHasNounModifier = false;

	for ( unsigned int ui = 0; ui < uiSize; ++ui )
	{
		if ( eModifier == vectSettings[ ui ].first.GetAtlasNounModifier( ) )
		{
			bHasNounModifier = true;
			break;
		}
	}

	return bHasNounModifier;
}

void SettingValues::Merge( const SettingValues& other )
{
	if ( this != &other )
	{
		const unsigned int uiSize = m_vectValues.size( );
		const unsigned int uiSizeOther = other.m_vectValues.size( );

		if ( ( uiSize > 0 ) && ( uiSizeOther > 0 ) )
		{
			map< string, unsigned int > mapVect;
	
			for ( unsigned int ui = 0; ui < uiSize; ++ui )
			{
				mapVect.insert( make_pair( m_vectValues[ ui ]->GetNumber( true ), ui ) );
			}
	
			map< string, unsigned int >::const_iterator it;
			const map< string, unsigned int >::const_iterator itEnd = mapVect.end( );
	
			// If only in other, copy
			for ( unsigned int ui = 0; ui < uiSizeOther; ++ui )
			{
				it = mapVect.find( other.m_vectValues[ ui ]->GetNumber( true ) );
	
				if ( itEnd == it )
				{
					Atlas::AtlasNumber* pAtlasNumber = 0;

					try
					{
						pAtlasNumber = new Atlas::AtlasNumber( *( other.m_vectValues[ ui ] ) );
					}
					catch ( ... )
					{
						throw Exception( Exception::eFailedToCreateNumberObject, __FILE__, __FUNCTION__, __LINE__ );
					}
		
					m_vectValues.push_back( pAtlasNumber );
				}
			}
		}
		else if ( uiSizeOther > 0 )
		{
			for ( unsigned int ui = 0; ui < uiSizeOther; ++ui )
			{
				Atlas::AtlasNumber* pAtlasNumber = 0;
				
				try
				{
					pAtlasNumber = new Atlas::AtlasNumber( *( other.m_vectValues[ ui ] ) );
				}
				catch ( ... )
				{
					throw Exception( Exception::eFailedToCreateNumberObject, __FILE__, __FUNCTION__, __LINE__ );
				}
	
				m_vectValues.push_back( pAtlasNumber );
			}
		}

		if ( m_bContinuous != other.m_bContinuous )
		{
			// -- TODO --
			// Not sure which should take precedence?
	
			#if ( _DEBUG ) && ( WIN32 )
				DebugBreak( );
			#endif
		}
	}
}

void SettingValues::MergeSignalSettings( vector< pair< Atlas::AtlasSignalComponent, SettingValues* > >& vectSettings, const vector< pair< Atlas::AtlasSignalComponent, SettingValues* > >& vectOtherSettings )
{
	const unsigned int uiSize = vectSettings.size( );
	const unsigned int uiSizeOther = vectOtherSettings.size( );

	if ( ( uiSize > 0 ) && ( uiSizeOther > 0 ) )
	{
		map< string, unsigned int > mapVect;
		map< string, unsigned int > mapVectOther;

		for ( unsigned int ui = 0; ui < uiSize; ++ui )
		{
			mapVect.insert( make_pair( ( string ) vectSettings[ ui ].first, ui ) );
		}

		for ( unsigned int ui = 0; ui < uiSizeOther; ++ui )
		{
			mapVectOther.insert( make_pair( ( string ) vectOtherSettings[ ui ].first, ui ) );
		}

		map< string, unsigned int >::const_iterator it;
		const map< string, unsigned int >::const_iterator itEnd = mapVect.end( );
		map< string, unsigned int >::const_iterator itOther;
		const map< string, unsigned int >::const_iterator itEndOther = mapVectOther.end( );

		// If in both, merge
		for ( unsigned int ui = 0; ui < uiSize; ++ui )
		{
			itOther = mapVectOther.find( vectSettings[ ui ].first );

			if ( itEndOther != itOther )
			{
				vectSettings[ ui ].second->Merge( *( vectOtherSettings[ itOther->second ].second ) );
			}
		}

		// If only in other, copy
		for ( unsigned int ui = 0; ui < uiSizeOther; ++ui )
		{
			it = mapVect.find( vectOtherSettings[ ui ].first );

			if ( itEnd == it )
			{
				const pair< Atlas::AtlasSignalComponent, SettingValues* >& prOther = vectOtherSettings[ ui ];
				SettingValues* pSettingValues = 0;
				
				try
				{
					pSettingValues = new SettingValues( *( prOther.second ) );
				}
				catch ( ... )
				{
					throw Exception( Exception::eFailedToCreateSettingsValuesObject, __FILE__, __FUNCTION__, __LINE__ );
				}
	
				vectSettings.push_back( make_pair( prOther.first, pSettingValues ) );
			}
		}
	}
	else if ( uiSizeOther > 0 )
	{
		for ( unsigned int ui = 0; ui < uiSizeOther; ++ui )
		{
			const pair< Atlas::AtlasSignalComponent, SettingValues* >& prOther = vectOtherSettings[ ui ];
			SettingValues* pSettingValues = 0;
			
			try
			{
				pSettingValues = new SettingValues( *( prOther.second ) );
			}
			catch ( ... )
			{
				throw Exception( Exception::eFailedToCreateSettingsValuesObject, __FILE__, __FUNCTION__, __LINE__ );
			}

			vectSettings.push_back( make_pair( prOther.first, pSettingValues ) );
		}
	}
}

void SettingValues::ToXML( string& strXML, const vector< pair< Atlas::AtlasSignalComponent, SettingValues* > >& vectSettings )
{
	const unsigned int uiSettings = vectSettings.size( );

	if ( uiSettings > 0 )
	{
		strXML += XML::MakeOpenXmlElementWithChildren( XML::enSettings );

		for ( unsigned int ui = 0; ui < uiSettings; ++ui )
		{
			const pair< Atlas::AtlasSignalComponent, SettingValues* >& pr = vectSettings[ ui ];

			strXML += XML::MakeOpenXmlElementWithChildren( XML::enSetting );

			strXML += pr.first.ToXML( );
			pr.second->ToXML( strXML );

			strXML += XML::MakeCloseXmlElementWithChildren( XML::enSetting );
		}
	
		strXML += XML::MakeCloseXmlElementWithChildren( XML::enSettings );
	}
}

Range& Range::operator = ( const Range& other )
{
	if ( this != &other )
	{
		m_Range = other.m_Range;
	}

	return *this;
}

unsigned int Range::Init( const string& strVirtualLabel, const vector< const AtlasAttributes::AtlasAttibuteValue* >& vectAttributes, const unsigned int uiStart )
{
	const unsigned int uiSize = vectAttributes.size( );
	unsigned int uiRet = ( uiStart + 5 );
	int iLowValue = uiStart;
	int iHighValue = ( uiStart + 3 );
	int iLowUnitOfMeasure = ( uiStart + 1 );
	int iHighUnitOfMeasure = ( uiStart + 4 );
	int iMaxRead = iHighUnitOfMeasure;
	bool bUnitOfMeasure = true;
	Atlas::AtlasUnitOfMeasure UOMLow;
	Atlas::AtlasUnitOfMeasure UOMHigh;

	if ( AtlasStatement::m_strTO == vectAttributes[ uiStart + 1 ]->m_strValue )
	{
		// No Units of measure

		bUnitOfMeasure = false;
		iLowUnitOfMeasure = -1;
		iHighUnitOfMeasure = -1;
		iHighValue = ( uiStart + 2 );
		iMaxRead = iHighValue;
		uiRet -= 2;
	}
	else if ( AtlasStatement::m_strTO != vectAttributes[ uiStart + 2 ]->m_strValue )
	{
		iHighValue--;
		iHighUnitOfMeasure--;
		iMaxRead--;
		uiRet--;
	}

	if ( ( unsigned int ) iMaxRead >= uiSize )
	{
		throw Exception( Exception::eInvalidNumberOfRangeAttributes, __FILE__, __FUNCTION__, __LINE__, strVirtualLabel );
	}

	if ( -1 != iLowUnitOfMeasure )
	{
		UOMLow = GetAtlasUnitOfMeasureByAlasUnit( vectAttributes[ iLowUnitOfMeasure ]->m_strValue, true, strVirtualLabel, Exception::eUnknownDataType );
	}

	if ( -1 != iHighUnitOfMeasure )
	{
		UOMHigh = GetAtlasUnitOfMeasureByAlasUnit( vectAttributes[ iHighUnitOfMeasure ]->m_strValue, true, strVirtualLabel, Exception::eUnknownDataType );
	}

	Atlas::AtlasNumber* pNumber = 0;
	
	try
	{
		pNumber = new Atlas::AtlasNumber;
	}
	catch ( ... )
	{
		throw Exception( Exception::eFailedToCreateNumberObject, __FILE__, __FUNCTION__, __LINE__ );
	}

	m_Range.SetRange1( pNumber );

	if ( vectAttributes[ iLowValue ]->IsConstant( ) )
	{
		pNumber->Set( VerifyNumber( vectAttributes[ iLowValue ]->m_strValue, strVirtualLabel ), UOMLow );
	}
	else
	{
		pNumber->SetVariableName( vectAttributes[ iLowValue ]->m_strValue );
	}

	try
	{
		pNumber = new Atlas::AtlasNumber;
	}
	catch ( ... )
	{
		throw Exception( Exception::eFailedToCreateNumberObject, __FILE__, __FUNCTION__, __LINE__ );
	}

	m_Range.SetRange2( pNumber );

	if ( vectAttributes[ iHighValue ]->IsConstant( ) )
	{
		pNumber->Set( VerifyNumber( vectAttributes[ iHighValue ]->m_strValue, strVirtualLabel ), UOMHigh );
	}
	else
	{
		pNumber->SetVariableName( vectAttributes[ iHighValue ]->m_strValue );
	}

	if ( uiRet < uiSize )
	{
		if ( AtlasStatement::m_strBY == vectAttributes[ uiRet ]->m_strValue )
		{
			if ( ( uiRet + 1 ) < uiSize )
			{
				const bool bIsConstant = vectAttributes[ uiRet + 1 ]->IsConstant( );
				const bool bIsVariable = vectAttributes[ uiRet + 1 ]->IsVariable( );

				if ( bIsConstant || bIsVariable )
				{
					const string& strValue = vectAttributes[ uiRet + 1 ]->m_strValue;

					try
					{
						pNumber = new Atlas::AtlasNumber;
					}
					catch ( ... )
					{
						throw Exception( Exception::eFailedToCreateNumberObject, __FILE__, __FUNCTION__, __LINE__ );
					}
				
					m_Range.SetByValue( pNumber );

					if ( bIsConstant )
					{
						pNumber->Set( VerifyNumber( strValue, strVirtualLabel ) );
					}
					else
					{
						pNumber->SetVariableName( strValue );
					}

					uiRet += 2;

					if ( uiRet < uiSize )
					{
						Atlas::AtlasUnitOfMeasure AtlasUnit( GetAtlasUnitOfMeasureByAlasUnit( vectAttributes[ uiRet ]->m_strValue, false ) );

						if ( AtlasUnit.IsUnit( ) )
						{
							++uiRet;

							pNumber->SetUnitOfMeasure( AtlasUnit );
						}
					}
				}
			}
		}
	}

	if ( uiRet < uiSize )
	{
		if ( AtlasStatement::m_strCONTINUOUS == vectAttributes[ uiRet ]->m_strValue )
		{
			m_Range.SetContinuous( true );
			++uiRet;
		}
	}

	return uiRet;
}

void Range::MergeSignalRanges( vector< pair< Atlas::AtlasSignalComponent, Range* > >& vectRanges, const vector< pair< Atlas::AtlasSignalComponent, Range* > >& vectOtherRanges )
{
	const unsigned int uiSize = vectRanges.size( );
	const unsigned int uiSizeOther = vectOtherRanges.size( );

	if ( ( uiSize > 0 ) && ( uiSizeOther > 0 ) )
	{
		map< string, unsigned int > mapVect;
		map< string, unsigned int > mapVectOther;

		for ( unsigned int ui = 0; ui < uiSize; ++ui )
		{
			mapVect.insert( make_pair( ( string ) vectRanges[ ui ].first, ui ) );
		}

		for ( unsigned int ui = 0; ui < uiSizeOther; ++ui )
		{
			mapVectOther.insert( make_pair( ( string ) vectOtherRanges[ ui ].first, ui ) );
		}

		map< string, unsigned int >::const_iterator it;
		const map< string, unsigned int >::const_iterator itEnd = mapVect.end( );
		map< string, unsigned int >::const_iterator itOther;
		const map< string, unsigned int >::const_iterator itEndOther = mapVectOther.end( );

		// If in both, merge
		for ( unsigned int ui = 0; ui < uiSize; ++ui )
		{
			itOther = mapVectOther.find( vectRanges[ ui ].first );

			if ( itEndOther != itOther )
			{
				vectRanges[ ui ].second->Merge( *( vectOtherRanges[ itOther->second ].second ) );
			}
		}

		// If only in other, copy
		for ( unsigned int ui = 0; ui < uiSizeOther; ++ui )
		{
			it = mapVect.find( vectOtherRanges[ ui ].first );

			if ( itEnd == it )
			{
				const pair< Atlas::AtlasSignalComponent, Range* >& prOther = vectOtherRanges[ ui ];
				Range* pRange = 0;
				
				try
				{
					pRange = new Range( *( prOther.second ) );
				}
				catch ( ... )
				{
					throw Exception( Exception::eFailedToCreateRangeObject, __FILE__, __FUNCTION__, __LINE__ );
				}
	
				vectRanges.push_back( make_pair( prOther.first, pRange ) );
			}
		}
	}
	else if ( uiSizeOther > 0 )
	{
		for ( unsigned int ui = 0; ui < uiSizeOther; ++ui )
		{
			const pair< Atlas::AtlasSignalComponent, Range* >& prOther = vectOtherRanges[ ui ];
			Range* pRange = 0;
			
			try
			{
				pRange = new Range( *( prOther.second ) );
			}
			catch ( ... )
			{
				throw Exception( Exception::eFailedToCreateRangeObject, __FILE__, __FUNCTION__, __LINE__ );
			}

			vectRanges.push_back( make_pair( prOther.first, pRange ) );
		}
	}
}

void Range::ToXML( string& strXML, const vector< pair< Atlas::AtlasSignalComponent, Range* > >& vectRanges )
{
	const unsigned int uiRanges = vectRanges.size( );

	if ( uiRanges > 0 )
	{
		strXML += XML::MakeOpenXmlElementWithChildren( XML::enRanges );

		for ( unsigned int ui = 0; ui < uiRanges; ++ui )
		{
			const pair< Atlas::AtlasSignalComponent, Range* >& pr = vectRanges[ ui ];

			strXML += XML::MakeOpenXmlElementWithChildren( XML::enRange );

			strXML += pr.first.ToXML( );
			strXML += pr.second->ToXML( );

			strXML += XML::MakeCloseXmlElementWithChildren( XML::enRange );
		}
	
		strXML += XML::MakeCloseXmlElementWithChildren( XML::enRanges );
	}
}

void Range::InitSignalComponents( vector< pair< Atlas::AtlasSignalComponent, Range* > >& vectRanges )
{
	const unsigned int uiRanges = vectRanges.size( );

	if ( uiRanges > 0 )
	{
		for ( unsigned int ui = 0; ui < uiRanges; ++ui )
		{
			vectRanges[ ui ].first.Set1641( );
		}
	}
}

bool Range::HasNounModifier( const Atlas::eAtlasNounModifier eModifier, const vector< pair< Atlas::AtlasSignalComponent, Range* > >& vectRanges )
{
	const unsigned int uiSize = vectRanges.size( );
	bool bHasNounModifier = false;

	for ( unsigned int ui = 0; ui < uiSize; ++ui )
	{
		if ( eModifier == vectRanges[ ui ].first.GetAtlasNounModifier( ) )
		{
			bHasNounModifier = true;
			break;
		}
	}

	return bHasNounModifier;
}

Atlas::AtlasStatementCharacteristic* NounModifier::GetAtlasCharacteristic( const string& strVirtualLabel, const vector< const AtlasAttributes::AtlasAttibuteValue* >& vectAttributes, unsigned int& uiStart, const bool bIncrementCounter )
{
	Atlas::AtlasStatementCharacteristic* pCharacteristic = 0;
	const unsigned int uiAttributes = vectAttributes.size( );

	if ( uiStart < uiAttributes )
	{
		try
		{
			pCharacteristic = new Atlas::AtlasStatementCharacteristic;
		}
		catch ( ... )
		{
			throw Exception( Exception::eFailedToCreateAtlasCharacteristicObject, __FILE__, __FUNCTION__, __LINE__, strVirtualLabel );
		}

		// Is Constant?
		if ( uiStart < uiAttributes )
		{
			if ( vectAttributes[ uiStart ]->IsConstant( ) )
			{
				if ( AIXMLHelper::IsNumber( vectAttributes[ uiStart ]->m_strValue ) )
				{
					pCharacteristic->SetNumber( GetAtlasNumber( strVirtualLabel, vectAttributes, uiStart, true ) );
				}
			}
		}

		// Is Variable?
		if ( uiStart < uiAttributes )
		{
			if ( vectAttributes[ uiStart ]->IsVariable( ) )
			{
				#if ( _DEBUG ) && ( WIN32 )
					if ( 0 != pCharacteristic->GetNumber( ) )
					{
						DebugBreak( );
					}
				#endif

				pCharacteristic->SetNumber( GetAtlasVariable( strVirtualLabel, vectAttributes, uiStart, true ) );
			}
		}

		// Is Dimension?
		if ( uiStart < uiAttributes )
		{
			if ( vectAttributes[ uiStart ]->IsDimension( ) )
			{
				if ( AIXMLHelper::IsNumber( vectAttributes[ uiStart ]->m_strValue ) )
				{
					if ( vectAttributes[ uiStart ]->IsConstant( ) )
					{
						if ( AIXMLHelper::IsNumber( vectAttributes[ uiStart ]->m_strValue ) )
						{
							Atlas::AtlasNumber* pNumber = 0;
							
							try
							{
								pNumber = new Atlas::AtlasNumber;
							}
							catch ( ... )
							{
								throw Exception( Exception::eFailedToCreateNumberObject, __FILE__, __FUNCTION__, __LINE__ );
							}

							pCharacteristic->SetDimension( true );
							pCharacteristic->SetStartNumber( pNumber );

							pNumber->Set( vectAttributes[ uiStart ]->m_strValue );

							++uiStart;
						}
					}
					else if ( vectAttributes[ uiStart ]->IsVariable( ) )
					{
						pCharacteristic->SetDimension( true );
						pCharacteristic->SetStartNumber( GetAtlasVariable( strVirtualLabel, vectAttributes, uiStart, true ) );
					}
	
					if ( uiStart < uiAttributes )
					{
						if ( AtlasStatement::m_strTHRU == vectAttributes[ uiStart ]->m_strValue )
						{
							pCharacteristic->SetThru( true );
		
							++uiStart;
				
							if ( uiStart < uiAttributes )
							{
								if ( vectAttributes[ uiStart ]->IsConstant( ) )
								{
									if ( AIXMLHelper::IsNumber( vectAttributes[ uiStart ]->m_strValue ) )
									{
										Atlas::AtlasNumber* pNumber = 0;
										
										try
										{
											pNumber = new Atlas::AtlasNumber;
										}
										catch ( ... )
										{
											throw Exception( Exception::eFailedToCreateNumberObject, __FILE__, __FUNCTION__, __LINE__ );
										}

										pNumber->Set( vectAttributes[ uiStart ]->m_strValue );

										pCharacteristic->SetDimension( true );
										pCharacteristic->SetEndNumber( pNumber );
		
										++uiStart;
									}
								}
								else if ( vectAttributes[ uiStart ]->IsVariable( ) )
								{
									pCharacteristic->SetDimension( true );
									pCharacteristic->SetEndNumber( GetAtlasVariable( strVirtualLabel, vectAttributes, uiStart, true ) );
								}
							}
						}
					}
				}
			}
		}

		// Is Range?
		if ( uiStart < uiAttributes )
		{
			if ( AtlasStatement::m_strRANGE == vectAttributes[ uiStart ]->m_strValue )
			{
				Atlas::AtlasRange* pRange = 0;
				
				try
				{
					pRange = new Atlas::AtlasRange;
				}
				catch ( ... )
				{
					throw Exception( Exception::eFailedToCreateRangeObject, __FILE__, __FUNCTION__, __LINE__ );
				}

				pCharacteristic->SetRange( pRange );

				++uiStart;
	
				if ( uiStart < uiAttributes )
				{
					if ( vectAttributes[ uiStart ]->IsConstant( ) )
					{
						if ( AIXMLHelper::IsNumber( vectAttributes[ uiStart ]->m_strValue ) )
						{
							pRange->SetRange1( GetAtlasNumber( strVirtualLabel, vectAttributes, uiStart, true ) );
						}
					}
					else if ( vectAttributes[ uiStart ]->IsVariable( ) )
					{
						pRange->SetRange1( GetAtlasVariable( strVirtualLabel, vectAttributes, uiStart, true ) );
					}
			
					if ( uiStart < uiAttributes )
					{
						if ( AtlasStatement::m_strTO == vectAttributes[ uiStart ]->m_strValue )
						{
							++uiStart;

							if ( uiStart < uiAttributes )
							{
								if ( vectAttributes[ uiStart ]->IsConstant( ) )
								{
									if ( AIXMLHelper::IsNumber( vectAttributes[ uiStart ]->m_strValue ) )
									{
										pRange->SetRange2( GetAtlasNumber( strVirtualLabel, vectAttributes, uiStart, true ) );
									}
								}
								else if ( vectAttributes[ uiStart ]->IsVariable( ) )
								{
									pRange->SetRange2( GetAtlasVariable( strVirtualLabel, vectAttributes, uiStart, true ) );
								}
							}
						}
					}
				}
			}
		}

		// Is From?
		if ( uiStart < uiAttributes )
		{
			if ( AtlasStatement::m_strFROM == vectAttributes[ uiStart ]->m_strValue )
			{
				++uiStart;

				pCharacteristic->SetFrom( true );
	
				if ( uiStart < uiAttributes )
				{
					if ( vectAttributes[ uiStart ]->IsVariable( ) )
					{
						pCharacteristic->SetEventName1( ( string* ) &( vectAttributes[ uiStart ]->m_strValue ), false );

						++uiStart;
					}
					else 
					{
						#if ( _DEBUG ) && ( WIN32 )
							DebugBreak( );
						#endif
					}
			
					if ( uiStart < uiAttributes )
					{
						if ( AtlasStatement::m_strTO == vectAttributes[ uiStart ]->m_strValue )
						{
							++uiStart;

							if ( uiStart < uiAttributes )
							{
								if ( vectAttributes[ uiStart ]->IsVariable( ) )
								{
									pCharacteristic->SetEventName2( ( string* ) &( vectAttributes[ uiStart ]->m_strValue ), false );
			
									++uiStart;
								}
								else
								{
									#if ( _DEBUG ) && ( WIN32 )
										DebugBreak( );
									#endif
								}
							}
						}
					}
				}
			}
		}

		// Is Min or Max?
		if ( uiStart < uiAttributes )
		{
			const bool bMin = ( AtlasStatement::m_strMIN == vectAttributes[ uiStart ]->m_strValue ); 
			const bool bMax = ( AtlasStatement::m_strMAX == vectAttributes[ uiStart ]->m_strValue );

			if ( bMin || bMax )
			{
				++uiStart;

				if ( bMin )
				{
					pCharacteristic->SetMin( true );
				}
				else
				{
					pCharacteristic->SetMax( true );
				}
	
	
				if ( uiStart < uiAttributes )
				{
					if ( vectAttributes[ uiStart ]->IsConstant( ) )
					{
						if ( AIXMLHelper::IsNumber( vectAttributes[ uiStart ]->m_strValue ) )
						{
							#if ( _DEBUG ) && ( WIN32 )
								if ( 0 != pCharacteristic->GetNumber( ) )
								{
									DebugBreak( );
								}
							#endif

							pCharacteristic->SetNumber( GetAtlasNumber( strVirtualLabel, vectAttributes, uiStart, true ) );
						}
					}
					else if ( vectAttributes[ uiStart ]->IsVariable( ) )
					{
						#if ( _DEBUG ) && ( WIN32 )
							if ( 0 != pCharacteristic->GetNumber( ) )
							{
								DebugBreak( );
							}
						#endif

						pCharacteristic->SetNumber( GetAtlasVariable( strVirtualLabel, vectAttributes, uiStart, true ) );
					}
				}
			}
		}

		// Is To?
		if ( uiStart < uiAttributes )
		{
			if ( AtlasStatement::m_strTO == vectAttributes[ uiStart ]->m_strValue )
			{
				++uiStart;
	
				if ( uiStart < uiAttributes )
				{
					if ( AtlasStatement::m_strEVENT == vectAttributes[ uiStart ]->m_strValue )
					{
						pCharacteristic->SetEvent( true );
	
						++uiStart;
			
						if ( uiStart < uiAttributes )
						{
							if ( vectAttributes[ uiStart ]->IsVariable( ) )
							{
								#if ( _DEBUG ) && ( WIN32 )
									if ( 0 != pCharacteristic->GetEventName1( ) )
									{
										DebugBreak( );
									}
								#endif

								pCharacteristic->SetEventName1( ( string* ) &( vectAttributes[ uiStart ]->m_strValue ), false );
	
								++uiStart;
							}
							else
							{
								#if ( _DEBUG ) && ( WIN32 )
									DebugBreak( );
								#endif
							}
						}
					}
				}
			}
		}

		// Is Error Limit?
		if ( uiStart < uiAttributes )
		{
			if ( AtlasStatement::m_strERRLMT == vectAttributes[ uiStart ]->m_strValue )
			{
				++uiStart;

				Atlas::AtlasErrorLimit errorLimit( GetAtlasErrorLimit( strVirtualLabel, vectAttributes, uiStart, true ) );

				if ( errorLimit.IsLimit( ) )
				{
					pCharacteristic->SetErrorLimit( &errorLimit, false );
				}
			}
		}

		if ( !pCharacteristic->IsValid( ) )
		{
			bool bDelete = true;

			if ( uiStart < uiAttributes )
			{
				bool bAttribute = true;

				if ( ( AtlasStatement::m_strCNX == vectAttributes[ uiStart ]->m_strValue ) || Atlas::IsAtlasNounModifierEnum( vectAttributes[ uiStart ]->m_strValue ) )
				{
					bAttribute = false;
				}

				if ( bAttribute )
				{
					pCharacteristic->SetAttributeValue( ( string* ) &( vectAttributes[ uiStart ]->m_strValue ), false );

					++uiStart;

					bDelete = false;
				}
			}

			if ( bDelete )
			{
				delete pCharacteristic;
				pCharacteristic = 0;
			}
		}

		if ( !bIncrementCounter )
		{
			if ( 0 != pCharacteristic )
			{
				--uiStart;
			}
		}
	}

	return pCharacteristic;
}

Atlas::AtlasEvaluationStatement* NounModifier::GetAtlasEvaluationField( const string& strVirtualLabel, const vector< const AtlasAttributes::AtlasAttibuteValue* >& vectAttributes, unsigned int& uiStart, const bool bIncrementCounter )
{
	Atlas::AtlasEvaluationStatement* pEvaluationStatement = 0;
	const unsigned int uiAttributes = vectAttributes.size( );

	if ( uiStart < uiAttributes )
	{
		try
		{
			pEvaluationStatement = new Atlas::AtlasEvaluationStatement;
		}
		catch ( ... )
		{
			throw Exception( Exception::eFailedToCreateEvaluationStatementObject, __FILE__, __FUNCTION__, __LINE__, strVirtualLabel );
		}

		for ( unsigned int ui = 1; ui < 4; ++ui )
		{
			const Atlas::AtlasNumber* pNumber = 0;
			const Atlas::eEvaluationFieldType eType = Atlas::GetAtlasEvaluationFieldTypeEnum( vectAttributes[ uiStart ]->m_strValue );
	
			if ( Atlas::eUnknownDataeEvaluationFieldType == eType )
			{
				break;
			}
			else
			{
				++uiStart;
	
				if ( vectAttributes[ uiStart ]->IsConstant( ) )
				{
					if ( AIXMLHelper::IsNumber( vectAttributes[ uiStart ]->m_strValue ) )
					{
						pNumber = GetAtlasNumber( strVirtualLabel, vectAttributes, uiStart, true );
					}
				}
				else if ( vectAttributes[ uiStart ]->IsVariable( ) )
				{
					pNumber = GetAtlasVariable( strVirtualLabel, vectAttributes, uiStart, true );
				}
	
				if ( 0 != pNumber )
				{
					if ( 0 == pEvaluationStatement->GetField1( ) )
					{
						pEvaluationStatement->SetField1( eType, *pNumber );
					}
					else if ( 0 == pEvaluationStatement->GetField2( ) )
					{
						pEvaluationStatement->SetField2( eType, *pNumber );
					}
					else if ( 0 == pEvaluationStatement->GetField3( ) )
					{
						pEvaluationStatement->SetField3( eType, *pNumber );
					}

					delete pNumber;
				}
			}
		}

		if ( 0 == pEvaluationStatement->GetField1( ) )
		{
			delete pEvaluationStatement;
			pEvaluationStatement = 0;
		}
		else if ( !bIncrementCounter )
		{
			--uiStart;
		}
	}

	return pEvaluationStatement;
}

void AtlasSignalInfo::SetSignal( const Atlas::eAtlasNoun eNoun, const Atlas::eAtlasStatement eStatement )
{
	if ( Atlas::IsElectricalSignalOrientedNoun( eNoun ) )
	{
		SignalInfo* pSignalInfo = GetSignal( eNoun );
	
		if ( 0 == pSignalInfo )
		{
			try
			{
				pSignalInfo = new SignalInfo( eNoun );
			}
			catch ( ... )
			{
				throw Exception( Exception::eFailedToCreateSignalInfoObject, __FILE__, __FUNCTION__, __LINE__ );
			}
	
			m_mapSignals.insert( make_pair( eNoun, pSignalInfo ) );
		}
		else
		{
			++( pSignalInfo->m_uiTotal );
		}
	
		if ( 0 != pSignalInfo )
		{
			const map< Atlas::eAtlasStatement, unsigned int >::iterator it = pSignalInfo->m_mapStatements.find( eStatement );
			const map< Atlas::eAtlasStatement, unsigned int >::const_iterator itEnd = pSignalInfo->m_mapStatements.end( );
	
			if ( itEnd == it )
			{
				pSignalInfo->m_mapStatements.insert( make_pair( eStatement, 1U ) );
			}
			else
			{
				++( it->second );
			}
		}
	}
}

void AtlasSignalInfo::SetComponent( const Atlas::AtlasSignalComponent& signal )
{
	if ( signal.IsValid( ) )
	{
		const Atlas::eAtlasNoun eNoun = signal.GetAtlasNoun( );

		if ( Atlas::IsElectricalSignalOrientedNoun( eNoun ) )
		{
			SignalInfo* pSignalInfo = GetSignal( eNoun );
		
			if ( 0 == pSignalInfo )
			{
				try
				{
					pSignalInfo = new SignalInfo( eNoun );
				}
				catch ( ... )
				{
					throw Exception( Exception::eFailedToCreateSignalInfoObject, __FILE__, __FUNCTION__, __LINE__ );
				}
		
				m_mapSignals.insert( make_pair( eNoun, pSignalInfo ) );
			}
		
			if ( 0 != pSignalInfo )
			{
				const map< string, pair< Atlas::AtlasSignalComponent, unsigned int > >::iterator it = pSignalInfo->m_mapSignalModifiers.find( ( string ) signal );
				const map< string, pair< Atlas::AtlasSignalComponent, unsigned int > >::const_iterator itEnd = pSignalInfo->m_mapSignalModifiers.end( );
	
				if ( itEnd == it )
				{
					pSignalInfo->m_mapSignalModifiers.insert( make_pair( ( string ) signal, make_pair( signal, 1U ) ) );
				}
				else
				{
					++( it->second.second );
				}
			}
		}
	}
}

bool AtlasSignalInfo::GetComponentPtrs( const Atlas::eAtlasNoun eNoun, const Atlas::eAtlasRequire eRequireType, const eModifierType eType, SignalInfo** ppSignalInfo, void** ppMap )
{
	if ( Atlas::IsElectricalSignalOrientedNoun( eNoun ) )
	{
		*ppSignalInfo = GetSignal( eNoun );

		if ( 0 != *ppSignalInfo )
		{
			switch ( eRequireType )
			{
				case Atlas::eAtlasRequireControl:
					switch ( eType )
					{
						case eRanges:
							*ppMap = ( void** ) &( ( *ppSignalInfo )->m_pmapSignalModifierControlRanges );
							break;

						case eSettingValues:
							*ppMap = ( void** ) &( ( *ppSignalInfo )->m_pmapSignalModifierControlSettingValues );
							break;

						case eMaximums:
							break;
					}
					break;

				case Atlas::eAtlasRequireCapability:
					switch ( eType )
					{
						case eRanges:
							*ppMap = ( void** ) &( ( *ppSignalInfo )->m_pmapSignalModifierCapabilityRanges );
							break;

						case eSettingValues:
							*ppMap = ( void** ) &( ( *ppSignalInfo )->m_pmapSignalModifierCapabilitySettingValues );
							break;

						case eMaximums:
							*ppMap = ( void** ) &( ( *ppSignalInfo )->m_pmapSignalModifierCapabilityMaximums );
							break;
					}
					break;

				case Atlas::eAtlasRequireLimit:
					switch ( eType )
					{
						case eRanges:
							*ppMap = ( void** ) &( ( *ppSignalInfo )->m_pmapSignalModifierLimitRanges );
							break;

						case eSettingValues:
							break;

						case eMaximums:
							*ppMap = ( void** ) &( ( *ppSignalInfo )->m_pmapSignalModifierLimitMaximums );
							break;
					}
					break;
			}
		}
	}

	return ( ( 0 != *ppMap ) && ( 0 != *ppSignalInfo ) );
}

void AtlasSignalInfo::SetInstrument( const Atlas::eAtlasNoun eNoun, const SpecificInstrument::eInstrument eInstrument, const Atlas::eAtlasResource eResource )
{
	if ( Atlas::IsElectricalSignalOrientedNoun( eNoun ) )
	{
		SignalInfo* pSignalInfo = GetSignal( eNoun );
	
		if ( 0 == pSignalInfo )
		{
			try
			{
				pSignalInfo = new SignalInfo( eNoun );
			}
			catch ( ... )
			{
				throw Exception( Exception::eFailedToCreateSignalInfoObject, __FILE__, __FUNCTION__, __LINE__ );
			}
	
			m_mapSignals.insert( make_pair( eNoun, pSignalInfo ) );
		}
	
		if ( 0 != pSignalInfo )
		{
			const map< SpecificInstrument::eInstrument, set< Atlas::eAtlasResource > >::iterator it = pSignalInfo->m_mapInstruments.find( eInstrument );
	
			if ( pSignalInfo->m_mapInstruments.end( ) == it )
			{
				pair< map< SpecificInstrument::eInstrument, set< Atlas::eAtlasResource > >::iterator, bool > prRet = pSignalInfo->m_mapInstruments.insert( make_pair( eInstrument, set< Atlas::eAtlasResource >( ) ) );
	
				if ( prRet.second )
				{
					prRet.first->second.insert( eResource );
				}
			}
			else if ( it->second.end( ) == it->second.find( eResource ) )
			{
				it->second.insert( eResource );
			}
		}
	}
}

void AtlasSignalInfo::SetRequire( const AtlasRequire* pRequire )
{
	if ( 0 != pRequire )
	{
		const Atlas::eAtlasNoun eNoun = pRequire->GetAtlasNoun( );

		if ( Atlas::IsElectricalSignalOrientedNoun( eNoun ) )
		{
			AtlasSignalInfo::SignalInfo* pSignalInfo = GetSignal( eNoun );
	
			if ( 0 != pSignalInfo )
			{
				pSignalInfo->m_vectRequires.push_back( pRequire );
			}
		}
	}
}

unsigned int AtlasSignalInfo::GetSignalComponentCount( const Atlas::eAtlasNoun eNoun ) const
{
	unsigned int uiRet = 0;

	if ( Atlas::IsElectricalSignalOrientedNoun( eNoun ) )
	{
		SignalInfo* pSignalInfo = GetSignal( eNoun );
	
		if ( 0 != pSignalInfo )
		{
			uiRet = pSignalInfo->m_mapSignalModifiers.size( );
		}
	}

	return uiRet;
}

bool AtlasSignalInfo::IsSignal( const Atlas::eAtlasNoun eNoun ) const
{
	return ( 0 != GetSignal( eNoun ) );
}

unsigned int AtlasSignalInfo::SetComplexSignal( const string& strSignalName, const string& strFilename, const Atlas::eAtlasStatement eStatement )
{
	unsigned int uiId = 0;

	if ( 0 != m_pmapComplexSignals )
	{
		const map< string, vector< AtlasComplexSignal* >* >::const_iterator it = m_pmapComplexSignals->find( strSignalName );

		if ( m_pmapComplexSignals->end( ) != it )
		{
			const vector< AtlasComplexSignal* >* pvect = it->second;
			const unsigned int uiSize = pvect->size( );
			const AtlasComplexSignal* pSignal = 0;

			if ( 1 == uiSize )
			{
				pSignal = pvect->at( 0 );
				uiId = pSignal->m_uiId;
			}
			else
			{
				const AtlasComplexSignal* pGlobal = 0;

				for ( unsigned int ui= 0; ui < uiSize; ++ui )
				{
					const AtlasComplexSignal* pStatement = ( AtlasComplexSignal* ) pvect->at( ui );

					if ( strFilename == pStatement->GetStatementFilename( ) )
					{
						pSignal = pStatement;
						uiId = pStatement->m_uiId;
						break;
					}
					else if ( AtlasStatement::eGlobal == pStatement->m_eScope )
					{
						pGlobal = pStatement;
						pSignal = pStatement;
					}
				}

				if ( 0 == uiId )
				{
					if ( 0 != pGlobal )
					{
						uiId = pGlobal->m_uiId;
					}
				}
			}
	
			if ( 0 != uiId )
			{
				if ( 0 != pSignal )
				{
					const map< unsigned int, SignalInfo* >::const_iterator itComplex = m_mapComplexSignals.find( uiId );
					SignalInfo* pSignalInfo = 0;

					if ( m_mapComplexSignals.end( ) == itComplex )
					{
						try
						{
							pSignalInfo = new SignalInfo( strSignalName );
						}
						catch ( ... )
						{
							throw Exception( Exception::eFailedToCreateSignalInfoObject, __FILE__, __FUNCTION__, __LINE__ );
						}
				
						m_mapComplexSignals.insert( make_pair( uiId, pSignalInfo ) );
					}
					else
					{
						pSignalInfo = itComplex->second;
						++( pSignalInfo->m_uiTotal );
					}

					const map< Atlas::eAtlasStatement, unsigned int >::iterator itStatement = pSignalInfo->m_mapStatements.find( eStatement );

					if ( pSignalInfo->m_mapStatements.end( ) == itStatement )
					{
						pSignalInfo->m_mapStatements.insert( make_pair( eStatement, 1 ) );
					}
					else
					{
						++( itStatement->second );
					}
				}
				#if ( _DEBUG ) && ( WIN32 )
				else
				{
					DebugBreak( );
				}
				#endif
			}
			#if ( _DEBUG ) && ( WIN32 )
			else
			{
				DebugBreak( );
			}
			#endif
		}
	}

	return uiId;
}

void AtlasSignalInfo::ToXML( string& strXML, const bool bExcludeUnused ) const
{
	unsigned int uiSignals = m_mapSignals.size( );
	unsigned int uiComplexSignals = 0;

	if ( 0 != m_pmapComplexSignals )
	{
		map< string, vector< AtlasComplexSignal* >* >::const_iterator itComplexSignal = m_pmapComplexSignals->begin( );
		const map< string, vector< AtlasComplexSignal* >* >::const_iterator itComplexSignalEnd = m_pmapComplexSignals->end( );

		if ( bExcludeUnused )
		{
			while ( itComplexSignalEnd != itComplexSignal )
			{
				vector< AtlasComplexSignal* >* pvect = itComplexSignal->second;
				const unsigned int uiSize = pvect->size( );
	
				for ( unsigned int ui = 0; ui < uiSize; ++ui )
				{
					if ( pvect->at( ui )->m_bUsed )
					{
						++uiComplexSignals;
					}
				}
	
				uiSignals += itComplexSignal->second->size( );
	
				++itComplexSignal;
			}
		}
		else
		{
			while ( itComplexSignalEnd != itComplexSignal )
			{
				uiComplexSignals += itComplexSignal->second->size( );
	
				++itComplexSignal;
			}
		}

		uiSignals += uiComplexSignals;
	}

	if ( uiSignals > 0 )
	{
		map< Atlas::eAtlasNoun, SignalInfo* >::const_iterator itSignals = m_mapSignals.begin( );
		const map< Atlas::eAtlasNoun, SignalInfo* >::const_iterator itSignalsEnd = m_mapSignals.end( );

		strXML += XML::MakeOpenXmlElementWithChildren( XML::enSignals, XML::MakeXmlAttributeNameValue( XML::anCount, uiSignals ) );

		if ( ( 0 != m_pmapComplexSignals ) && ( uiComplexSignals > 0 ) )
		{
			map< string, vector< AtlasComplexSignal* >* >::const_iterator itComplexSignal = m_pmapComplexSignals->begin( );
			const map< string, vector< AtlasComplexSignal* >* >::const_iterator itComplexSignalEnd = m_pmapComplexSignals->end( );
			map< unsigned int, SignalInfo* >::const_iterator itComplexSignalInfo;
			const map< unsigned int, SignalInfo* >::const_iterator itComplexSignalInfoEnd = m_mapComplexSignals.end( );

			while ( itComplexSignalEnd != itComplexSignal )
			{
				vector< AtlasComplexSignal* >* pvect = itComplexSignal->second;
				const unsigned int uiSize = pvect->size( );
	
				for ( unsigned int ui= 0; ui < uiSize; ++ui )
				{
					const AtlasComplexSignal* pComplexSignal = pvect->at( ui );
					bool bProcess = true;

					if ( bExcludeUnused )
					{
						bProcess = pComplexSignal->m_bUsed;
					}

					if ( bProcess )
					{
						const unsigned int uiId = pComplexSignal->m_uiId;
						const unsigned int uiCommentId = pComplexSignal->GetStatementCommentId( );
						string strTotals;
						string strCommentRefId;
	
						itComplexSignalInfo = m_mapComplexSignals.find( uiId );
	
						if ( itComplexSignalInfoEnd != itComplexSignalInfo )
						{
							strTotals = XML::MakeXmlAttributeNameValue( XML::anCount, itComplexSignalInfo->second->m_uiTotal );
						}
	
						if ( uiCommentId > 0 )
						{
							strCommentRefId = XML::MakeXmlAttributeNameValue( XML::anCommentRefId, uiCommentId );
						}
	
						strXML += XML::MakeOpenXmlElementWithChildren( XML::enComplexSignal, strTotals, XML::MakeXmlAttributeNameValue( XML::anId, uiId ), strCommentRefId );
	
						pComplexSignal->ToXML( strXML );
	
						if ( itComplexSignalInfoEnd != itComplexSignalInfo )
						{
							itComplexSignalInfo->second->TotalsByStatementType_ToXML( strXML );
						}
	
						strXML += XML::MakeCloseXmlElementWithChildren( XML::enComplexSignal );
					}
				}
	
				++itComplexSignal;
			}
		}

		while ( itSignalsEnd != itSignals )
		{
			itSignals->second->ToXML( strXML );

			++itSignals;
		}

		strXML += XML::MakeCloseXmlElementWithChildren( XML::enSignals );
	}
}

void AtlasSignalInfo::GarbageCollect( void )
{
	if ( m_mapSignals.size( ) > 0 )
	{
		map< Atlas::eAtlasNoun, SignalInfo* >::const_iterator it = m_mapSignals.begin( );
		const map< Atlas::eAtlasNoun, SignalInfo* >::const_iterator itEnd = m_mapSignals.end( );

		while ( itEnd != it )
		{
			delete it->second;

			++it;
		}

		m_mapSignals.clear( );
	}

	if ( m_mapComplexSignals.size( ) > 0 )
	{
		map< unsigned int, SignalInfo* >::const_iterator it = m_mapComplexSignals.begin( );
		const map< unsigned int, SignalInfo* >::const_iterator itEnd = m_mapComplexSignals.end( );

		while ( itEnd != it )
		{
			delete it->second;

			++it;
		}

		m_mapComplexSignals.clear( );
	}
}

AtlasSignalInfo::SignalInfo* AtlasSignalInfo::GetSignal( const Atlas::eAtlasNoun eNoun ) const
{
	map< Atlas::eAtlasNoun, SignalInfo* >::const_iterator it = m_mapSignals.find( eNoun );
	SignalInfo* pSignalInfo = 0;

	if ( m_mapSignals.end( ) != it )
	{
		pSignalInfo = it->second;
	}

	return pSignalInfo;
}

void AtlasSignalInfo::SignalInfo::GarbageCollect( void )
{
	if ( 0 != m_pmapSignalModifierCapabilityRanges )
	{
		if ( m_pmapSignalModifierCapabilityRanges->size( ) > 0 )
		{
			map< string, Range* >::const_iterator it = m_pmapSignalModifierCapabilityRanges->begin( );
			const map< string, Range* >::const_iterator itEnd = m_pmapSignalModifierCapabilityRanges->end( );
	
			while ( itEnd != it )
			{
				delete it->second;
	
				++it;
			}
		}

		delete m_pmapSignalModifierCapabilityRanges;
		m_pmapSignalModifierCapabilityRanges = 0;
	}

	if ( 0 != m_pmapSignalModifierCapabilitySettingValues )
	{
		if ( m_pmapSignalModifierCapabilitySettingValues->size( ) > 0 )
		{
			map< string, SettingValues* >::const_iterator it = m_pmapSignalModifierCapabilitySettingValues->begin( );
			const map< string, SettingValues* >::const_iterator itEnd = m_pmapSignalModifierCapabilitySettingValues->end( );
	
			while ( itEnd != it )
			{
				delete it->second;
	
				++it;
			}
		}

		delete m_pmapSignalModifierCapabilitySettingValues;
		m_pmapSignalModifierCapabilitySettingValues = 0;
	}

	if ( 0 != m_pmapSignalModifierCapabilityMaximums )
	{
		if ( m_pmapSignalModifierCapabilityMaximums->size( ) > 0 )
		{
			map< string, Atlas::AtlasNumber* >::const_iterator it = m_pmapSignalModifierCapabilityMaximums->begin( );
			const map< string, Atlas::AtlasNumber* >::const_iterator itEnd = m_pmapSignalModifierCapabilityMaximums->end( );
	
			while ( itEnd != it )
			{
				delete it->second;
	
				++it;
			}
		}

		delete m_pmapSignalModifierCapabilityMaximums;
		m_pmapSignalModifierCapabilityMaximums = 0;
	}

	if ( 0 != m_pmapSignalModifierControlRanges )
	{
		if ( m_pmapSignalModifierControlRanges->size( ) > 0 )
		{
			map< string, Range* >::const_iterator it = m_pmapSignalModifierControlRanges->begin( );
			const map< string, Range* >::const_iterator itEnd = m_pmapSignalModifierControlRanges->end( );
	
			while ( itEnd != it )
			{
				delete it->second;
	
				++it;
			}
		}

		delete m_pmapSignalModifierControlRanges;
		m_pmapSignalModifierControlRanges = 0;
	}

	if ( 0 != m_pmapSignalModifierControlSettingValues )
	{
		if ( m_pmapSignalModifierControlSettingValues->size( ) > 0 )
		{
			map< string, SettingValues* >::const_iterator it = m_pmapSignalModifierControlSettingValues->begin( );
			const map< string, SettingValues* >::const_iterator itEnd = m_pmapSignalModifierControlSettingValues->end( );
	
			while ( itEnd != it )
			{
				delete it->second;
	
				++it;
			}
		}

		delete m_pmapSignalModifierControlSettingValues;
		m_pmapSignalModifierControlSettingValues = 0;
	}

	if ( 0 != m_pmapSignalModifierLimitRanges )
	{
		if ( m_pmapSignalModifierLimitRanges->size( ) > 0 )
		{
			map< string, Range* >::const_iterator it = m_pmapSignalModifierLimitRanges->begin( );
			const map< string, Range* >::const_iterator itEnd = m_pmapSignalModifierLimitRanges->end( );
	
			while ( itEnd != it )
			{
				delete it->second;
	
				++it;
			}
		}

		delete m_pmapSignalModifierLimitRanges;
		m_pmapSignalModifierLimitRanges = 0;
	}

	if ( 0 != m_pmapSignalModifierLimitMaximums )
	{
		if ( m_pmapSignalModifierLimitMaximums->size( ) > 0 )
		{
			map< string, Atlas::AtlasNumber* >::const_iterator it = m_pmapSignalModifierLimitMaximums->begin( );
			const map< string, Atlas::AtlasNumber* >::const_iterator itEnd = m_pmapSignalModifierLimitMaximums->end( );
	
			while ( itEnd != it )
			{
				delete it->second;
	
				++it;
			}
		}

		delete m_pmapSignalModifierLimitMaximums;
		m_pmapSignalModifierLimitMaximums = 0;
	}
}

const void* AtlasSignalInfo::SignalInfo::GetModifierValue( const string& strComponentName, Atlas::eAtlasRequire eRequireType, const eModifierType eType ) const
{
	const void* pValue = 0;

	map< string, Range* >::const_iterator itRanges;
	map< string, SettingValues* >::const_iterator itSettings;
	map< string, Atlas::AtlasNumber* >::const_iterator itMaximums;

	switch ( eRequireType )
	{
		case Atlas::eAtlasRequireControl:
			switch ( eType )
			{
				case eRanges:
					if ( 0 != m_pmapSignalModifierControlRanges )
					{
						itRanges = m_pmapSignalModifierControlRanges->find( strComponentName );

						if ( m_pmapSignalModifierControlRanges->end( ) != itRanges )
						{
							pValue = itRanges->second;
						}
					}
					break;

				case eSettingValues:
					if ( 0 != m_pmapSignalModifierControlSettingValues )
					{
						itSettings = m_pmapSignalModifierControlSettingValues->find( strComponentName );

						if ( m_pmapSignalModifierControlSettingValues->end( ) != itSettings )
						{
							pValue = itSettings->second;
						}
					}
					break;

				case eMaximums:
					break;
			}
			break;

		case Atlas::eAtlasRequireCapability:
			switch ( eType )
			{
				case eRanges:
					if ( 0 != m_pmapSignalModifierCapabilityRanges )
					{
						itRanges = m_pmapSignalModifierCapabilityRanges->find( strComponentName );

						if ( m_pmapSignalModifierCapabilityRanges->end( ) != itRanges )
						{
							pValue = itRanges->second;
						}
					}
					break;

				case eSettingValues:
					if ( 0 != m_pmapSignalModifierCapabilitySettingValues )
					{
						itSettings = m_pmapSignalModifierCapabilitySettingValues->find( strComponentName );

						if ( m_pmapSignalModifierCapabilitySettingValues->end( ) != itSettings )
						{
							pValue = itSettings->second;
						}
					}
					break;

				case eMaximums:
					if ( 0 != m_pmapSignalModifierCapabilityMaximums )
					{
						itMaximums = m_pmapSignalModifierCapabilityMaximums->find( strComponentName );

						if ( m_pmapSignalModifierCapabilityMaximums->end( ) != itMaximums )
						{
							pValue = itMaximums->second;
						}
					}
					break;
			}
			break;

		case Atlas::eAtlasRequireLimit:
			switch ( eType )
			{
				case eRanges:
					if ( 0 != m_pmapSignalModifierLimitRanges )
					{
						itRanges = m_pmapSignalModifierLimitRanges->find( strComponentName );

						if ( m_pmapSignalModifierLimitRanges->end( ) != itRanges )
						{
							pValue = itRanges->second;
						}
					}
					break;

				case eMaximums:
					if ( 0 != m_pmapSignalModifierLimitMaximums )
					{
						itMaximums = m_pmapSignalModifierLimitMaximums->find( strComponentName );

						if ( m_pmapSignalModifierLimitMaximums->end( ) != itMaximums )
						{
							pValue = itMaximums->second;
						}
					}
					break;
			}
			break;
	}

	return pValue;
}

void AtlasSignalInfo::SignalInfo::ToXML( string& strXML ) const
{
	strXML += XML::MakeOpenXmlElementWithChildren( XML::enSignal, XML::MakeXmlAttributeNameValue( XML::anCount, m_uiTotal ) );

	Atlas::AtlasSignalComponent asc( m_eAtlasNoun );
	asc.Set1641( ); 

	strXML += asc.ToXML( XML::enSignalName );

	if ( m_mapInstruments.size( ) > 0 )
	{
		map< SpecificInstrument::eInstrument, set< Atlas::eAtlasResource > >::const_iterator it = m_mapInstruments.begin( );
		const map< SpecificInstrument::eInstrument, set< Atlas::eAtlasResource > >::const_iterator itEnd = m_mapInstruments.end( );

		strXML += XML::MakeOpenXmlElementWithChildren( XML::enInstrumentClasses, XML::MakeXmlAttributeNameValue( XML::anCount, m_mapInstruments.size( ) ) );

		while ( itEnd != it )
		{
			strXML += XML::MakeOpenXmlElementWithChildren( XML::enInstrumentClass, 
				XML::MakeXmlAttributeNameValue( XML::anName, SpecificInstrument::GetInstrumentClass( SpecificInstrument::GetInstrumentClass( it->first ) ) ),
				XML::MakeXmlAttributeNameValue( XML::anDescription, SpecificInstrument::GetInstrumentClassDescription( SpecificInstrument::GetInstrumentClass( it->first ) ) ) );

			if ( it->second.size( ) > 0 )
			{
				set< Atlas::eAtlasResource >::const_iterator itResource = it->second.begin( );
				const set< Atlas::eAtlasResource >::const_iterator itResourceEnd = it->second.end( );
	
				strXML += XML::MakeOpenXmlElementWithChildren( XML::enResources );

				while ( itResourceEnd != itResource )
				{
					strXML += XML::MakeXmlElementNoChildren( XML::enResource, XML::MakeXmlAttributeNameValue( XML::anType, Atlas::GetAtlasResoure( *itResource ) ) );

					++itResource;
				}

				strXML += XML::MakeCloseXmlElementWithChildren( XML::enResources );
			}

			strXML += XML::MakeCloseXmlElementWithChildren( XML::enInstrumentClass );

			++it;
		}

		strXML += XML::MakeCloseXmlElementWithChildren( XML::enInstrumentClasses );
	}

	if ( m_mapSignalModifiers.size( ) > 0 )
	{
		const unsigned int uiRequireCount = m_vectRequires.size( );
		if ( uiRequireCount > 0 )
		{
			sort( ( ( vector< const AtlasRequire* >& ) m_vectRequires ).begin( ), ( ( vector< const AtlasRequire* >& ) m_vectRequires ).end( ), AIXML::CompareRequire( ) );
	
			strXML += XML::MakeOpenXmlElementWithChildren( XML::enRequires, XML::MakeXmlAttributeNameValue( XML::anCount, uiRequireCount ) );
	
			for ( unsigned int ui = 0; ui < uiRequireCount; ui++ )
			{
				m_vectRequires[ ui ]->ToSignalXML( strXML, m_mapSignalModifiers );
			}
	
			strXML += XML::MakeCloseXmlElementWithChildren( XML::enRequires );
		}
	}

	TotalsByStatementType_ToXML( strXML );

	if ( m_mapSignalModifiers.size( ) > 0 )
	{
		map< string, pair< Atlas::AtlasSignalComponent, unsigned int > >::const_iterator it = m_mapSignalModifiers.begin( );
		const map< string, pair< Atlas::AtlasSignalComponent, unsigned int > >::const_iterator itEnd = m_mapSignalModifiers.end( );
		const Range* pControlRange = 0;
		const SettingValues* pControlSetting = 0;
		const Range* pCapabilityRange = 0;
		const SettingValues* pCapabilitySetting = 0;
		const Atlas::AtlasNumber* pCapabilityMaximum = 0;
		const Range* pLimitRange = 0;
		const Atlas::AtlasNumber* pLimitMaximum = 0;

		strXML += XML::MakeOpenXmlElementWithChildren( XML::enModifiers, XML::MakeXmlAttributeNameValue( XML::anCount, m_mapSignalModifiers.size( ) ) );

		while ( itEnd != it )
		{
			strXML += XML::MakeOpenXmlElementWithChildren( XML::enModifier, XML::MakeXmlAttributeNameValue( XML::anCount, it->second.second ) );

			strXML += it->second.first.ToXML( );

			pControlRange = ( Range* ) GetModifierValue( it->first, Atlas::eAtlasRequireControl, AtlasSignalInfo::eRanges );
			pControlSetting = ( SettingValues* ) GetModifierValue( it->first, Atlas::eAtlasRequireControl, AtlasSignalInfo::eSettingValues );
			pCapabilityRange = ( Range* ) GetModifierValue( it->first, Atlas::eAtlasRequireCapability, AtlasSignalInfo::eRanges );
			pCapabilitySetting = ( SettingValues* ) GetModifierValue( it->first, Atlas::eAtlasRequireCapability, AtlasSignalInfo::eSettingValues );
			pCapabilityMaximum = ( Atlas::AtlasNumber* ) GetModifierValue( it->first, Atlas::eAtlasRequireCapability, AtlasSignalInfo::eMaximums );
			pLimitRange = ( Range* ) GetModifierValue( it->first, Atlas::eAtlasRequireLimit, AtlasSignalInfo::eRanges );
			pLimitMaximum = ( Atlas::AtlasNumber* ) GetModifierValue( it->first, Atlas::eAtlasRequireLimit, AtlasSignalInfo::eMaximums );

			if ( ( 0 != pControlRange ) || ( 0 != pControlSetting ) )
			{
				strXML += XML::MakeOpenXmlElementWithChildren( XML::enControl );

				if ( 0 != pControlRange )
				{
					strXML += XML::MakeOpenXmlElementWithChildren( XML::enRange );

					strXML += pControlRange->ToXML( );

					strXML += XML::MakeCloseXmlElementWithChildren( XML::enRange );
				}
					
				if ( 0 != pControlSetting )
				{
					strXML += XML::MakeOpenXmlElementWithChildren( XML::enSetting );
		
					pControlSetting->ToXML( strXML );

					strXML += XML::MakeCloseXmlElementWithChildren( XML::enSetting );
				}

				strXML += XML::MakeCloseXmlElementWithChildren( XML::enControl );
			}

			if ( ( 0 != pCapabilityRange ) || ( 0 != pCapabilitySetting ) || ( 0 != pCapabilityMaximum ) )
			{
				strXML += XML::MakeOpenXmlElementWithChildren( XML::enCapability );

				if ( 0 != pCapabilityRange )
				{
					strXML += XML::MakeOpenXmlElementWithChildren( XML::enRange );

					strXML += pCapabilityRange->ToXML( );

					strXML += XML::MakeCloseXmlElementWithChildren( XML::enRange );
				}

				if ( 0 != pCapabilitySetting )
				{
					strXML += XML::MakeOpenXmlElementWithChildren( XML::enSetting );
		
					pCapabilitySetting->ToXML( strXML );

					strXML += XML::MakeCloseXmlElementWithChildren( XML::enSetting );
				}

				if ( 0 != pCapabilityMaximum )
				{
					strXML += XML::MakeXmlElementNoChildren( XML::enMaximum, pCapabilityMaximum->ToXML( ) );
				}

				strXML += XML::MakeCloseXmlElementWithChildren( XML::enCapability );
			}

			if ( ( 0 != pLimitRange ) || ( 0 != pLimitMaximum ) )
			{
				strXML += XML::MakeOpenXmlElementWithChildren( XML::enLimit );

				if ( 0 != pLimitRange )
				{
					strXML += XML::MakeOpenXmlElementWithChildren( XML::enRange );

					strXML += pLimitRange->ToXML( );

					strXML += XML::MakeCloseXmlElementWithChildren( XML::enRange );
				}

				if ( 0 != pLimitMaximum )
				{
					strXML += XML::MakeXmlElementNoChildren( XML::enMaximum, pLimitMaximum->ToXML( ) );
				}

				strXML += XML::MakeCloseXmlElementWithChildren( XML::enLimit );
			}

			strXML += XML::MakeCloseXmlElementWithChildren( XML::enModifier );

			++it;
		}

		strXML += XML::MakeCloseXmlElementWithChildren( XML::enModifiers );
	}

	strXML += XML::MakeCloseXmlElementWithChildren( XML::enSignal );
}

void AtlasSignalInfo::SignalInfo::TotalsByStatementType_ToXML( string& strXML ) const
{
	if ( m_mapStatements.size( ) > 0 )
	{
		map< Atlas::eAtlasStatement, unsigned int >::const_iterator it = m_mapStatements.begin( );
		const map< Atlas::eAtlasStatement, unsigned int >::const_iterator itEnd = m_mapStatements.end( );

		strXML += XML::MakeOpenXmlElementWithChildren( XML::enStatements );

		while ( itEnd != it )
		{
			strXML += XML::MakeXmlElementNoChildren( XML::enStatement,
				XML::MakeXmlAttributeNameValue( XML::anName, Atlas::GetAtlasStatement( it->first ) ),
				XML::MakeXmlAttributeNameValue( XML::anCount, it->second ) );

			++it;
		}

		strXML += XML::MakeCloseXmlElementWithChildren( XML::enStatements );
	}
}