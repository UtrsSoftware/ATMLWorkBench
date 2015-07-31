/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

#include "Atlas.h"

#if ( _DEBUG ) && ( WIN32 )
	#define WINVER 0x0600
	#include <afx.h>
	#define new DEBUG_NEW
	#undef THIS_FILE
	static char BASED_CODE THIS_FILE[ ] = __FILE__;
#endif

bool Atlas::InitAll( void )
{
	InitAtlasVerb( );
	InitAtlasNoun( );
	InitAtlasNounModifier( );
	InitAtlasFunction( );
	InitAtlasSuffix( );
	InitAtlasPinDescriptor( );
	InitAtlasResource( );
	InitAtlasRequire( );
	InitUnitsOfMeasure( );
	InitAtlasInputOutput( );
	InitAtlasInputOutputAttribute( );
	InitAtlasSignalTo1641Signal( );
	InitAtlasDataType( );
	InitAtlasEvaluationFieldType( );
	InitAtlasSpecifyType( );

	return true;
}

void Atlas::InitAtlasVerb( void )
{
	const int iMax = ( eOUTPUT + 1 );

	for ( int i = 0; i < iMax; ++i )
	{
		m_mapAtlasStatementToAtlasStatementEnum.insert( make_pair( &m_arrayAtlasVerb[ i ].m_strAtlasStatement, ( eAtlasStatement ) i ) );
		m_mapAtlasStatementEnumToAtlasStatement.insert( make_pair( ( eAtlasStatement ) i, &m_arrayAtlasVerb[ i ].m_strAtlasStatement ) );

		if ( m_arrayAtlasVerb[ i ].m_bElectricalSignalOriented )
		{
			m_setElectricalSignalOrientedStatement.insert( ( eAtlasStatement ) i );
		}
	}
}

Atlas::eAtlasStatement Atlas::GetAtlasStatementEnum( const string& strAtlasStatement )
{
	eAtlasStatement e = eUnknownAtlasStatement;

	const map< const string*, eAtlasStatement, AIXMLHelper::cmpPointer >::const_iterator it = m_mapAtlasStatementToAtlasStatementEnum.find( &strAtlasStatement );
	const map< const string*, eAtlasStatement, AIXMLHelper::cmpPointer >::const_iterator itEnd = m_mapAtlasStatementToAtlasStatementEnum.end( );

	if ( itEnd != it )
	{
		e = it->second;
	}
	
	return e;
}

string Atlas::GetAtlasStatement( const Atlas::eAtlasStatement eStatement )
{
	string strStatement( m_UNKNOWN );

	const map< eAtlasStatement, const string* >::const_iterator it = m_mapAtlasStatementEnumToAtlasStatement.find( eStatement );
	const map< eAtlasStatement, const string* >::const_iterator itEnd = m_mapAtlasStatementEnumToAtlasStatement.end( );

	if ( itEnd != it )
	{
		strStatement = *( it->second );
	}

	return strStatement;
}

bool Atlas::IsElectricalSignalOrientedStatement( const eAtlasStatement eStatement )
{
	return ( m_setElectricalSignalOrientedStatement.end( ) != m_setElectricalSignalOrientedStatement.find( eStatement ) );
}

void Atlas::InitAtlasNoun( void )
{
	const int iMax = ( eAnalogAdd + 1 );

	for ( int i = 0; i < iMax; ++i )
	{
		m_mapAtlasNounToAtlasNounEnum.insert( make_pair( &m_arrayAtlasNoun[ i ].m_strAtlasNoun, ( eAtlasNoun ) i ) );
		m_mapAtlasNounEnumToAtlasNoun.insert( make_pair( ( eAtlasNoun ) i, &m_arrayAtlasNoun[ i ].m_strAtlasNoun ) );
		m_mapAtlasNounEnumToAtlasNounDescription.insert( make_pair( ( eAtlasNoun ) i, &m_arrayAtlasNoun[ i ].m_strAtlasNounDescription ) );
		m_mapAtlasNounEnumTo1641TSFEnum.insert( make_pair( ( eAtlasNoun ) i, m_arrayAtlasNoun[ i ].m_eTSF ) );
		m_mapAtlasNounEnumTo1641ModelEnum.insert( make_pair( ( eAtlasNoun ) i, m_arrayAtlasNoun[ i ].m_eModel ) );

		if ( m_arrayAtlasNoun[ i ].m_bElectricalSignalOriented )
		{
			m_setElectricalSignalOrientedNoun.insert( ( eAtlasNoun ) i );
		}
	}
}

bool Atlas::IsElectricalSignalOrientedNoun( const eAtlasNoun eNoun )
{
	return ( m_setElectricalSignalOrientedNoun.end( ) != m_setElectricalSignalOrientedNoun.find( eNoun ) );
}

Atlas::eAtlasNoun Atlas::GetAtlasNounEnum( const string& strAtlasNoun )
{
	eAtlasNoun e = eUnknownAtlasNoun;

	const map< const string*, eAtlasNoun, AIXMLHelper::cmpPointer >::const_iterator it = m_mapAtlasNounToAtlasNounEnum.find( &strAtlasNoun );
	const map< const string*, eAtlasNoun, AIXMLHelper::cmpPointer >::const_iterator itEnd = m_mapAtlasNounToAtlasNounEnum.end( );

	if ( itEnd != it )
	{
		e = it->second;
	}
	
	return e;
}

ieee1641::eTSF Atlas::Get1641TSFEnumByAtlasNoun( const string& strAtlasNoun )
{
	ieee1641::eTSF e = ieee1641::eUnknownTSF;

	Atlas::eAtlasNoun eAtlas = GetAtlasNounEnum( strAtlasNoun );

	if ( eUnknownAtlasNoun != eAtlas )
	{
		const map< eAtlasNoun, ieee1641::eTSF >::const_iterator it = m_mapAtlasNounEnumTo1641TSFEnum.find( eAtlas );
		const map< eAtlasNoun, ieee1641::eTSF >::const_iterator itEnd = m_mapAtlasNounEnumTo1641TSFEnum.end( );
	
		if ( itEnd != it )
		{
			e = it->second;
		}
	}

	return e;
}

ieee1641::eTSF Atlas::Get1641TSFEnumByAtlasNounEnum( const eAtlasNoun eNoun )
{
	ieee1641::eTSF e = ieee1641::eUnknownTSF;

	const map< eAtlasNoun, ieee1641::eTSF >::const_iterator it = m_mapAtlasNounEnumTo1641TSFEnum.find( eNoun );
	const map< eAtlasNoun, ieee1641::eTSF >::const_iterator itEnd = m_mapAtlasNounEnumTo1641TSFEnum.end( );

	if ( itEnd != it )
	{
		e = it->second;
	}

	return e;
}

string Atlas::GetAtlasNoun( const eAtlasNoun eNoun )
{
	string strNoun( m_UNKNOWN );

	const map< eAtlasNoun, const string* >::const_iterator it = m_mapAtlasNounEnumToAtlasNoun.find( eNoun );
	const map< eAtlasNoun, const string* >::const_iterator itEnd = m_mapAtlasNounEnumToAtlasNoun.end( );

	if ( itEnd != it )
	{
		strNoun = *( it->second );
	}

	return strNoun;
}

string Atlas::GetAtlasNounDescription( const eAtlasNoun eNoun )
{
	string strNounDescription( m_UNKNOWN );

	const map< eAtlasNoun, const string* >::const_iterator it = m_mapAtlasNounEnumToAtlasNounDescription.find( eNoun );
	const map< eAtlasNoun, const string* >::const_iterator itEnd = m_mapAtlasNounEnumToAtlasNounDescription.end( );

	if ( itEnd != it )
	{
		strNounDescription = *( it->second );
	}

	return strNounDescription;
}

ieee1641::eModel Atlas::Get1641ModelEnumByAtlasNounEnum( const eAtlasNoun eNoun )
{
	ieee1641::eModel eModel = ieee1641::eUnknownModel;

	const map< eAtlasNoun, ieee1641::eModel >::const_iterator it = m_mapAtlasNounEnumTo1641ModelEnum.find( eNoun );
	const map< eAtlasNoun, ieee1641::eModel >::const_iterator itEnd = m_mapAtlasNounEnumTo1641ModelEnum.end( );

	if ( itEnd != it )
	{
		eModel = it->second;
	}

	return eModel;
}

void Atlas::InitAtlasNounModifier( void )
{
	const int iMax = ( ePOWER_DELTA + 1 );

	for ( int i = 0; i < iMax; ++i )
	{
		m_mapAtlasNounModifierToAtlasNounModifierEnum.insert( make_pair( &m_arrayAtlasNounModifier[ i ].m_strAtlasNounModifier, ( eAtlasNounModifier ) i ) );
		m_mapAtlasNounModifierEnumToAtlasNounModifier.insert( make_pair( ( eAtlasNounModifier ) i, &m_arrayAtlasNounModifier[ i ].m_strAtlasNounModifier ) );
		m_mapAtlasNounModifierEnumToAtlasNounModifierDescription.insert( make_pair( ( eAtlasNounModifier ) i, &m_arrayAtlasNounModifier[ i ].m_strAtlasNounModifierDescription ) );
		m_mapAtlasNounModifierEnumTo1641ModelEnum.insert( make_pair( ( eAtlasNounModifier ) i, m_arrayAtlasNounModifier[ i ].m_eModel ) );
		m_mapAtlasNounModifierEnumTo1641BSCEnum.insert( make_pair( ( eAtlasNounModifier ) i, m_arrayAtlasNounModifier[ i ].m_eBCS ) );
		m_mapAtlasNounModifierEnumTo1641BSCAttributeEnum.insert( make_pair( ( eAtlasNounModifier ) i, m_arrayAtlasNounModifier[ i ].m_eBCSAttribute ) );
	}
}

void Atlas::InitAtlasFunction( void )
{
	const int iMax = ( eEXT + 1 );

	for ( int i = 0; i < iMax; ++i )
	{
		m_mapAtlasFunctionToAtlasFunctionEnum.insert( make_pair( &m_arrayAtlasFunction[ i ].m_strAtlasFunction, ( eAtlasFunction ) i ) );
		m_mapAtlasFunctionEnumToAtlasFunction.insert( make_pair( ( eAtlasFunction ) i, &m_arrayAtlasFunction[ i ].m_strAtlasFunction ) );
		m_mapAtlasFunctionEnumToAtlasFunctionDescription.insert( make_pair( ( eAtlasFunction ) i, &m_arrayAtlasFunction[ i ].m_strAtlasFunctionDescription ) );
		m_mapAtlasFunctionEnumTo1641BSCEnum.insert( make_pair( ( eAtlasFunction ) i, m_arrayAtlasFunction[ i ].m_eBSC ) );
		m_mapAtlasFunctionEnumTo1641ModelEnum.insert( make_pair( ( eAtlasFunction ) i, m_arrayAtlasFunction[ i ].m_eModel ) );
	}
}

void Atlas::InitAtlasSuffix( void )
{
	const int iMax = ( eREFSuffix + 1 );

	for ( int i = 0; i < iMax; ++i )
	{
		m_mapAtlasSuffixToAtlasSuffixEnum.insert( make_pair( &m_arrayAtlasModiferSuffix[ i ].m_strAtlasSuffix, ( eAtlasModifierSuffix ) i ) );
		m_mapAtlasSuffixEnumToAtlasSuffix.insert( make_pair( ( eAtlasModifierSuffix ) i, &m_arrayAtlasModiferSuffix[ i ].m_strAtlasSuffix ) );
		m_mapAtlasSuffixToAtlasSuffixDescription.insert( make_pair( ( eAtlasModifierSuffix ) i, &m_arrayAtlasModiferSuffix[ i ].m_strAtlasSuffixDescription ) );
		m_mapAtlasSuffixTo1641Qualifier.insert( make_pair( ( eAtlasModifierSuffix ) i, m_arrayAtlasModiferSuffix[ i ].m_eQualifier ) );
	}
}

bool Atlas::IsAtlasNounModifierEnum( const string& strAtlasNounModifier )
{
	return GetAtlasNounModifierEnum( strAtlasNounModifier, true ).IsValid( );
}

Atlas::AtlasSignalComponent Atlas::GetAtlasNounModifierEnum( const string& strAtlasNounModifier, const bool bFindClosest )
{
	AtlasSignalComponent e;

	const map< const string*, eAtlasNounModifier, AIXMLHelper::cmpPointer >::const_iterator it = m_mapAtlasNounModifierToAtlasNounModifierEnum.find( &strAtlasNounModifier );
	const map< const string*, eAtlasNounModifier, AIXMLHelper::cmpPointer >::const_iterator itEnd = m_mapAtlasNounModifierToAtlasNounModifierEnum.end( );

	if ( itEnd != it )
	{
		e.SetAtlasNounModifier( it->second );
	}
	else if ( bFindClosest )
	{
		string strTemp( strAtlasNounModifier );

		if ( AIXMLHelper::Trim( strTemp, false, true, AIXMLHelper::m_strNumeric ) )
		{
			e.SetAtlasNounModifier( GetAtlasNounModifierEnum( strTemp, false ).GetAtlasNounModifier( ) );
		}

		if ( !e.IsValid( ) )
		{
			const string strDash( "-" );

			while ( AIXMLHelper::TrimTo( strTemp, strDash, false, true ) )
			{
				e.SetAtlasNounModifier( GetAtlasNounModifierEnum( strTemp, false ).GetAtlasNounModifier( ) );

				if ( e.IsValid( ) )
				{
					break;
				}
			}
		}

		e.SetAtlasNounModifierSuffix( strAtlasNounModifier.substr( strTemp.length( ) ) );
	}
	
	return e;
}

string Atlas::GetAtlasNounModifier( const Atlas::eAtlasNounModifier eNounModifier )
{
	string strNounModifier( m_UNKNOWN );

	const map< eAtlasNounModifier, const string* >::const_iterator it = m_mapAtlasNounModifierEnumToAtlasNounModifier.find( eNounModifier );
	const map< eAtlasNounModifier, const string* >::const_iterator itEnd = m_mapAtlasNounModifierEnumToAtlasNounModifier.end( );

	if ( itEnd != it )
	{
		strNounModifier = *( it->second );
	}

	return strNounModifier;
}

string Atlas::GetAtlasNounModifierDescription( const Atlas::eAtlasNounModifier eNounModifier )
{
	string strNounModifierDescription( m_UNKNOWN );

	const map< eAtlasNounModifier, const string* >::const_iterator it = m_mapAtlasNounModifierEnumToAtlasNounModifierDescription.find( eNounModifier );
	const map< eAtlasNounModifier, const string* >::const_iterator itEnd = m_mapAtlasNounModifierEnumToAtlasNounModifierDescription.end( );

	if ( itEnd != it )
	{
		strNounModifierDescription = *( it->second );
	}

	return strNounModifierDescription;
}

ieee1641::eModel Atlas::Get1641ModelEnumByAtlasNounModifierEnum( const eAtlasNounModifier eNounModifier )
{
	ieee1641::eModel eModel = ieee1641::eUnknownModel;

	const map< eAtlasNounModifier, ieee1641::eModel >::const_iterator it = m_mapAtlasNounModifierEnumTo1641ModelEnum.find( eNounModifier );
	const map< eAtlasNounModifier, ieee1641::eModel >::const_iterator itEnd = m_mapAtlasNounModifierEnumTo1641ModelEnum.end( );

	if ( itEnd != it )
	{
		eModel = it->second;
	}

	return eModel;
}

Atlas::eAtlasModifierSuffix Atlas::GetAtlasSuffixEnum( const string& strAtlasSuffix )
{
	eAtlasModifierSuffix e = eUnknownAtlasSuffix;

	const map< const string*, eAtlasModifierSuffix, AIXMLHelper::cmpPointer >::const_iterator it = m_mapAtlasSuffixToAtlasSuffixEnum.find( &strAtlasSuffix );
	const map< const string*, eAtlasModifierSuffix, AIXMLHelper::cmpPointer >::const_iterator itEnd = m_mapAtlasSuffixToAtlasSuffixEnum.end( );

	if ( itEnd != it )
	{
		e = it->second;
	}

	return e;
}

string Atlas::GetAtlasSuffix( const Atlas::eAtlasModifierSuffix eSuffix )
{
	string strSuffix( m_UNKNOWN );

	const map< eAtlasModifierSuffix, const string* >::const_iterator it = m_mapAtlasSuffixEnumToAtlasSuffix.find( eSuffix );
	const map< eAtlasModifierSuffix, const string* >::const_iterator itEnd = m_mapAtlasSuffixEnumToAtlasSuffix.end( );

	if ( itEnd != it )
	{
		strSuffix = *( it->second );
	}

	return strSuffix;
}

string Atlas::GetAtlasSuffixDescription( const Atlas::eAtlasModifierSuffix eSuffix )
{
	string strSuffixDescription( m_UNKNOWN );

	const map< eAtlasModifierSuffix, const string* >::const_iterator it = m_mapAtlasSuffixToAtlasSuffixDescription.find( eSuffix );
	const map< eAtlasModifierSuffix, const string* >::const_iterator itEnd = m_mapAtlasSuffixToAtlasSuffixDescription.end( );

	if ( itEnd != it )
	{
		strSuffixDescription = *( it->second );
	}

	return strSuffixDescription;
}

ieee1641::eQualifier Atlas::Get1641QualifierEnumByAtlasSuffixEnum( const Atlas::eAtlasModifierSuffix eSuffix )
{
	ieee1641::eQualifier e = ieee1641::eUnknownQualifier;

	const map< eAtlasModifierSuffix, ieee1641::eQualifier >::const_iterator it = m_mapAtlasSuffixTo1641Qualifier.find( eSuffix );
	const map< eAtlasModifierSuffix, ieee1641::eQualifier >::const_iterator itEnd = m_mapAtlasSuffixTo1641Qualifier.end( );

	if ( itEnd != it )
	{
		e = it->second;
	}
	return e;
}

Atlas::eAtlasFunction Atlas::GetAtlasFunctionEnum( const string& strAtlasFunction )
{
	eAtlasFunction e = eUnknownAtlasFunction;

	const map< const string*, eAtlasFunction, AIXMLHelper::cmpPointer >::const_iterator it = m_mapAtlasFunctionToAtlasFunctionEnum.find( &strAtlasFunction );
	const map< const string*, eAtlasFunction, AIXMLHelper::cmpPointer >::const_iterator itEnd = m_mapAtlasFunctionToAtlasFunctionEnum.end( );

	if ( itEnd != it )
	{
		e = it->second;
	}

	return e;
}

ieee1641::eBSC Atlas::GetAtlasFunctionEnumTo1641BSCEnum( const Atlas::eAtlasFunction eFunction )
{
	ieee1641::eBSC e = ieee1641::eUnknownBSC;

	const map< eAtlasFunction, ieee1641::eBSC >::const_iterator it = m_mapAtlasFunctionEnumTo1641BSCEnum.find( eFunction );
	const map< eAtlasFunction, ieee1641::eBSC >::const_iterator itEnd = m_mapAtlasFunctionEnumTo1641BSCEnum.end( );

	if ( itEnd != it )
	{
		e = it->second;
	}

	return e;
}

string Atlas::GetAtlasFunction( const eAtlasFunction eFunction )
{
	string strFunction( m_UNKNOWN );

	const map< eAtlasFunction, const string* >::const_iterator it = m_mapAtlasFunctionEnumToAtlasFunction.find( eFunction );
	const map< eAtlasFunction, const string* >::const_iterator itEnd = m_mapAtlasFunctionEnumToAtlasFunction.end( );

	if ( itEnd != it )
	{
		strFunction = *( it->second );
	}

	return strFunction;
}

string Atlas::GetAtlasFunctionDescription( const eAtlasFunction eFunction )
{
	string strFunctionDescription( m_UNKNOWN );

	const map< eAtlasFunction, const string* >::const_iterator it = m_mapAtlasFunctionEnumToAtlasFunctionDescription.find( eFunction );
	const map< eAtlasFunction, const string* >::const_iterator itEnd = m_mapAtlasFunctionEnumToAtlasFunctionDescription.end( );

	if ( itEnd != it )
	{
		strFunctionDescription = *( it->second );
	}

	return strFunctionDescription;
}

ieee1641::eModel Atlas::Get1641ModelEnumByAtlasFunctionEnum( const Atlas::eAtlasFunction eFunction )
{
	ieee1641::eModel e = ieee1641::eUnknownModel;

	const map< eAtlasFunction, ieee1641::eModel >::const_iterator it = m_mapAtlasFunctionEnumTo1641ModelEnum.find( eFunction );
	const map< eAtlasFunction, ieee1641::eModel >::const_iterator itEnd = m_mapAtlasFunctionEnumTo1641ModelEnum.end( );

	if ( itEnd != it )
	{
		e = it->second;
	}

	return e;
}

void Atlas::InitAtlasSpecifyType( void )
{
	const int iMax = ( eCARRIER + 1 );

	for ( int i = 0; i < iMax; ++i )
	{
		m_mapAtlasSpecifyTypeToAtlasSpecifyTypeEnum.insert( make_pair( &m_arrayAtlasSpecifyType[ i ], ( eAtlasSpecifyType ) i ) );
		m_mapAtlasSpecifyTypeEnumToAtlasSpecifyType.insert( make_pair( ( eAtlasSpecifyType ) i, &m_arrayAtlasSpecifyType[ i ] ) );
	}
}

Atlas::eAtlasSpecifyType Atlas::GetAtlasSpecifyTypeEnum( const string& strAtlasSpecifyType )
{
	eAtlasSpecifyType e = eUnknownAtlasSpecifyType;

	const map< const string*, eAtlasSpecifyType, AIXMLHelper::cmpPointer >::const_iterator it = m_mapAtlasSpecifyTypeToAtlasSpecifyTypeEnum.find( &strAtlasSpecifyType );
	const map< const string*, eAtlasSpecifyType, AIXMLHelper::cmpPointer >::const_iterator itEnd = m_mapAtlasSpecifyTypeToAtlasSpecifyTypeEnum.end( );

	if ( itEnd != it )
	{
		e = it->second;
	}

	return e;
}

string Atlas::GetAtlasSpecifyType( const Atlas::eAtlasSpecifyType eSpecifyType )
{
	string strSpecifyType( m_UNKNOWN );

	const map< eAtlasSpecifyType, const string* >::const_iterator it = m_mapAtlasSpecifyTypeEnumToAtlasSpecifyType.find( eSpecifyType );
	const map< eAtlasSpecifyType, const string* >::const_iterator itEnd = m_mapAtlasSpecifyTypeEnumToAtlasSpecifyType.end( );

	if ( itEnd != it )
	{
		strSpecifyType= *( it->second );
	}

	return strSpecifyType;
}

ieee1641::eBSC Atlas::Get1641BSCEnumByAtlasNounModifier( const string& strAtlasNounModifier )
{
	ieee1641::eBSC e = ieee1641::eUnknownBSC;

	AtlasSignalComponent eAtlas = GetAtlasNounModifierEnum( strAtlasNounModifier, true );

	if ( eAtlas.IsValid( ) )
	{
		const map< eAtlasNounModifier, ieee1641::eBSC >::const_iterator it = m_mapAtlasNounModifierEnumTo1641BSCEnum.find( eAtlas.GetAtlasNounModifier( ) );
		const map< eAtlasNounModifier, ieee1641::eBSC >::const_iterator itEnd = m_mapAtlasNounModifierEnumTo1641BSCEnum.end( );
	
		if ( itEnd != it )
		{
			e = it->second;
		}
	}

	return e;
}

ieee1641::eBSC Atlas::Get1641BSCEnumByAtlasNounModifierEnum( const eAtlasNounModifier eNounModifier )
{
	ieee1641::eBSC e = ieee1641::eUnknownBSC;

	const map< eAtlasNounModifier, ieee1641::eBSC >::const_iterator it = m_mapAtlasNounModifierEnumTo1641BSCEnum.find( eNounModifier );
	const map< eAtlasNounModifier, ieee1641::eBSC >::const_iterator itEnd = m_mapAtlasNounModifierEnumTo1641BSCEnum.end( );

	if ( itEnd != it )
	{
		e = it->second;
	}

	return e;
}

ieee1641::eBSCAttribute Atlas::Get1641BSCAttributeEnumByAtlasNounModifier( const string& strAtlasNounModifier )
{
	ieee1641::eBSCAttribute e = ieee1641::eUnknownBSCAttribute;

	AtlasSignalComponent eAtlas = GetAtlasNounModifierEnum( strAtlasNounModifier, true );

	if ( eAtlas.IsValid( ) )
	{
		const map< eAtlasNounModifier, ieee1641::eBSCAttribute >::const_iterator it = m_mapAtlasNounModifierEnumTo1641BSCAttributeEnum.find( eAtlas.GetAtlasNounModifier( ) );
		const map< eAtlasNounModifier, ieee1641::eBSCAttribute >::const_iterator itEnd = m_mapAtlasNounModifierEnumTo1641BSCAttributeEnum.end( );
	
		if ( itEnd != it )
		{
			e = it->second;
		}
	}

	return e;
}

ieee1641::eBSCAttribute Atlas::Get1641BSCAttributeEnumByAtlasNounModifierEnum( const eAtlasNounModifier eNounModifier )
{
	ieee1641::eBSCAttribute e = ieee1641::eUnknownBSCAttribute;

	const map< eAtlasNounModifier, ieee1641::eBSCAttribute >::const_iterator it = m_mapAtlasNounModifierEnumTo1641BSCAttributeEnum.find( eNounModifier );
	const map< eAtlasNounModifier, ieee1641::eBSCAttribute >::const_iterator itEnd = m_mapAtlasNounModifierEnumTo1641BSCAttributeEnum.end( );

	if ( itEnd != it )
	{
		e = it->second;
	}

	return e;
}

void Atlas::InitAtlasResource( void )
{
	const int iMax = ( eSTIM_RESP_COMPResource + 1 );

	for ( int i = 0; i < iMax; ++i )
	{
		m_mapAtlasResourceToAtlasResourceEnum.insert( make_pair( &m_arrayAtlasResource[ i ], ( eAtlasResource ) i ) );
		m_mapAtlasResourceEnumToAtlasResource.insert( make_pair( ( eAtlasResource ) i, &m_arrayAtlasResource[ i ] ) );
	}
}

Atlas::eAtlasResource Atlas::GetAtlasResoureEnum( const string& strAtlasResource )
{
	eAtlasResource e = eUnknownAtlasResource;

	const map< const string*, eAtlasResource, AIXMLHelper::cmpPointer >::const_iterator it = m_mapAtlasResourceToAtlasResourceEnum.find( &strAtlasResource );
	const map< const string*, eAtlasResource, AIXMLHelper::cmpPointer >::const_iterator itEnd = m_mapAtlasResourceToAtlasResourceEnum.end( );

	if ( itEnd != it )
	{
		e = it->second;
	}
	
	return e;
}

string Atlas::GetAtlasResoure( const eAtlasResource eResource )
{
	string strResource( m_UNKNOWN );

	const map< eAtlasResource, const string* >::const_iterator it = m_mapAtlasResourceEnumToAtlasResource.find( eResource );
	const map< eAtlasResource, const string* >::const_iterator itEnd = m_mapAtlasResourceEnumToAtlasResource.end( );

	if ( itEnd != it )
	{
		strResource = *( it->second );
	}

	return strResource;
}

void Atlas::InitAtlasRequire( void )
{
	const int iMax = ( eAtlasRequireCNX + 1 );

	for ( int i = 0; i < iMax; ++i )
	{
		m_mapAtlasRequireToAtlasRequireEnum.insert( make_pair( &m_arrayAtlasRequire[ i ], ( eAtlasRequire ) i ) );
		m_mapAtlasRequireEnumToAtlasRequire.insert( make_pair( ( eAtlasRequire ) i, &m_arrayAtlasRequire[ i ] ) );
	}
}

Atlas::eAtlasRequire Atlas::GetAtlasRequireEnum( const string& strAtlasRequire )
{
	eAtlasRequire e = eUnknownAtlasRequire;

	const map< const string*, eAtlasRequire, AIXMLHelper::cmpPointer >::const_iterator it = m_mapAtlasRequireToAtlasRequireEnum.find( &strAtlasRequire );
	const map< const string*, eAtlasRequire, AIXMLHelper::cmpPointer >::const_iterator itEnd = m_mapAtlasRequireToAtlasRequireEnum.end( );

	if ( itEnd != it )
	{
		e = it->second;
	}
	
	return e;
}

string Atlas::GetAtlasRequire( const eAtlasRequire eRequire )
{
	string strRequire( m_UNKNOWN );

	const map< eAtlasRequire, const string* >::const_iterator it = m_mapAtlasRequireEnumToAtlasRequire.find( eRequire );
	const map< eAtlasRequire, const string* >::const_iterator itEnd = m_mapAtlasRequireEnumToAtlasRequire.end( );

	if ( itEnd != it )
	{
		strRequire = *( it->second );
	}

	return strRequire;
}

void Atlas::InitAtlasInputOutput( void )
{
	const int iMax = ( eInputAndOutput + 1 );

	for ( int i = 0; i < iMax; ++i )
	{
		m_mapAtlasInputOutputToAtlasInputOutputEnum.insert( make_pair( &m_arrayAtlasInputOutput[ i ], ( eInputOutput ) i ) );
		m_mapAtlasInputOutputEnumToAtlasInputOutput.insert( make_pair( ( eInputOutput ) i, &m_arrayAtlasInputOutput[ i ] ) );
	}
}

Atlas::eInputOutput Atlas::GetAtlasInputOutputEnum( const string& strAtlasInputOutput )
{
	eInputOutput e = eUnknownInputOutput;

	const map< const string*, eInputOutput, AIXMLHelper::cmpPointer >::const_iterator it = m_mapAtlasInputOutputToAtlasInputOutputEnum.find( &strAtlasInputOutput );
	const map< const string*, eInputOutput, AIXMLHelper::cmpPointer >::const_iterator itEnd = m_mapAtlasInputOutputToAtlasInputOutputEnum.end( );

	if ( itEnd != it )
	{
		e = it->second;
	}
	
	return e;
}

string Atlas::GetAtlasInputOutput( const Atlas::eInputOutput eIO )
{
	string strIO( m_UNKNOWN );

	const map< eInputOutput, const string* >::const_iterator it = m_mapAtlasInputOutputEnumToAtlasInputOutput.find( eIO );
	const map< eInputOutput, const string* >::const_iterator itEnd = m_mapAtlasInputOutputEnumToAtlasInputOutput.end( );

	if ( itEnd != it )
	{
		strIO = *( it->second );
	}

	return strIO;
}

void Atlas::InitAtlasInputOutputAttribute( void )
{
	const int iMax = ( eDIRECT + 1 );

	for ( int i = 0; i < iMax; ++i )
	{
		m_mapAtlasInputOutputAttributeToAtlasInputOutputAttributeEnum.insert( make_pair( &m_arrayAtlasInputOutputAttribute[ i ], ( eInputOutputAttribute ) i ) );
		m_mapAtlasInputOutputAttributeEnumToAtlasInputOutputAttribute.insert( make_pair( ( eInputOutputAttribute ) i, &m_arrayAtlasInputOutputAttribute[ i ] ) );
	}
}

Atlas::eInputOutputAttribute Atlas::GetAtlasInputOutputAttributeEnum( const string& strAtlasInputOutputAttribute )
{
	eInputOutputAttribute e = eUnknownInputOutputAttribute;

	const map< const string*, eInputOutputAttribute, AIXMLHelper::cmpPointer >::const_iterator it = m_mapAtlasInputOutputAttributeToAtlasInputOutputAttributeEnum.find( &strAtlasInputOutputAttribute );
	const map< const string*, eInputOutputAttribute, AIXMLHelper::cmpPointer >::const_iterator itEnd = m_mapAtlasInputOutputAttributeToAtlasInputOutputAttributeEnum.end( );

	if ( itEnd != it )
	{
		e = it->second;
	}
	
	return e;
}

string Atlas::GetAtlasInputOutput( const Atlas::eInputOutputAttribute eIOAttribute )
{
	string strIOAttribute( m_UNKNOWN );

	const map< eInputOutputAttribute, const string* >::const_iterator it = m_mapAtlasInputOutputAttributeEnumToAtlasInputOutputAttribute.find( eIOAttribute );
	const map< eInputOutputAttribute, const string* >::const_iterator itEnd = m_mapAtlasInputOutputAttributeEnumToAtlasInputOutputAttribute.end( );

	if ( itEnd != it )
	{
		strIOAttribute = *( it->second );
	}

	return strIOAttribute;
}

void Atlas::InitAtlasDataType( void )
{
	const int iMax = ( eDIGITAL_SBCD + 1 );

	for ( int i = 0; i < iMax; ++i )
	{
		m_mapAtlasDataTypeToAtlasDataTypeEnum.insert( make_pair( &m_arrayAtlasDataType[ i ], ( eDataType ) i ) );
		m_mapAtlasDataTypeEnumToAtlasDataType.insert( make_pair( ( eDataType ) i, &m_arrayAtlasDataType[ i ] ) );
	}
}

Atlas::eDataType Atlas::GetAtlasDataTypeEnum( const string& strAtlasDataType )
{
	eDataType e = eUnknownDataType;

	const map< const string*, eDataType, AIXMLHelper::cmpPointer >::const_iterator it = m_mapAtlasDataTypeToAtlasDataTypeEnum.find( &strAtlasDataType );
	const map< const string*, eDataType, AIXMLHelper::cmpPointer >::const_iterator itEnd = m_mapAtlasDataTypeToAtlasDataTypeEnum.end( );

	if ( itEnd != it )
	{
		e = it->second;
	}
	
	return e;
}

string Atlas::GetAtlasDataType( const Atlas::eDataType eType )
{
	string strDataType( m_UNKNOWN );

	const map< eDataType, const string* >::const_iterator it = m_mapAtlasDataTypeEnumToAtlasDataType.find( eType );
	const map< eDataType, const string* >::const_iterator itEnd = m_mapAtlasDataTypeEnumToAtlasDataType.end( );

	if ( itEnd != it )
	{
		strDataType = *( it->second );
	}

	return strDataType;
}

void Atlas::InitAtlasEvaluationFieldType( void )
{
	const int iMax = ( eGE + 1 );

	for ( int i = 0; i < iMax; ++i )
	{
		m_mapAtlasEvaluationFieldTypeToAtlasEvaluationFieldTypeEnum.insert( make_pair( &m_arrayAtlasEvaluationFieldType[ i ], ( eEvaluationFieldType ) i ) );
		m_mapAtlasEvaluationFieldTypeEnumToAtlasEvaluationFieldType.insert( make_pair( ( eEvaluationFieldType ) i, &m_arrayAtlasEvaluationFieldType[ i ] ) );
	}
}

Atlas::eEvaluationFieldType Atlas::GetAtlasEvaluationFieldTypeEnum( const string& strAtlasEvaluationFieldType )
{
	eEvaluationFieldType e = eUnknownDataeEvaluationFieldType;

	const map< const string*, eEvaluationFieldType, AIXMLHelper::cmpPointer >::const_iterator it = m_mapAtlasEvaluationFieldTypeToAtlasEvaluationFieldTypeEnum.find( &strAtlasEvaluationFieldType );
	const map< const string*, eEvaluationFieldType, AIXMLHelper::cmpPointer >::const_iterator itEnd = m_mapAtlasEvaluationFieldTypeToAtlasEvaluationFieldTypeEnum.end( );

	if ( itEnd != it )
	{
		e = it->second;
	}
	
	return e;
}

string Atlas::GetAtlasEvaluationFieldType( const Atlas::eEvaluationFieldType eType )
{
	string strEvaluationFieldType( m_UNKNOWN );

	const map< eEvaluationFieldType, const string* >::const_iterator it = m_mapAtlasEvaluationFieldTypeEnumToAtlasEvaluationFieldType.find( eType );
	const map< eEvaluationFieldType, const string* >::const_iterator itEnd = m_mapAtlasEvaluationFieldTypeEnumToAtlasEvaluationFieldType.end( );

	if ( itEnd != it )
	{
		strEvaluationFieldType = *( it->second );
	}

	return strEvaluationFieldType;
}

void Atlas::InitAtlasPinDescriptor( void )
{
	const int iMax = ( eS4 + 1 );

	for ( int i = 0; i < iMax; ++i )
	{
		m_mapAtlasePinDescriptorToEnum.insert( make_pair( &m_arrayAtlasPinDescriptor[ i ].m_strAtlasPinDescriptor, ( eAtlasPinDescriptor ) i ) );
		m_mapAtlasPinDescriptorEnumToPinDescriptor.insert( make_pair( ( eAtlasPinDescriptor ) i, &m_arrayAtlasPinDescriptor[ i ].m_strAtlasPinDescriptor ) );
		m_mapAtlasPinDescriptorEnumToPinDescriptorDescription.insert( make_pair( ( eAtlasPinDescriptor ) i, &m_arrayAtlasPinDescriptor[ i ].m_strAtlasPinDescriptorDescription ) );
		m_mapAtlasPinDescriptorEnumTo1641BSCEnum.insert( make_pair( ( eAtlasPinDescriptor ) i, m_arrayAtlasPinDescriptor[ i ].m_eBCS ) );
		m_mapAtlasPinDescriptorEnumTo1641BSCAttributeEnum.insert( make_pair( ( eAtlasPinDescriptor ) i, m_arrayAtlasPinDescriptor[ i ].m_eBCSAttribute ) );
	}
}

Atlas::eAtlasPinDescriptor Atlas::GetAtlasPinDescriptorEnum( const string& strPinDescriptor )
{
	eAtlasPinDescriptor e = eUnknownAtlasPinDescriptor;

	const map< const string*, eAtlasPinDescriptor, AIXMLHelper::cmpPointer >::const_iterator it = m_mapAtlasePinDescriptorToEnum.find( &strPinDescriptor );
	const map< const string*, eAtlasPinDescriptor, AIXMLHelper::cmpPointer >::const_iterator itEnd = m_mapAtlasePinDescriptorToEnum.end( );

	if ( itEnd != it )
	{
		e = it->second;
	}
	
	return e;
}

string Atlas::GetAtlasPinDescriptor( const eAtlasPinDescriptor ePinDescriptor )
{
	string strPinDescriptor( m_UNKNOWN );

	const map< eAtlasPinDescriptor, const string* >::const_iterator it = m_mapAtlasPinDescriptorEnumToPinDescriptor.find( ePinDescriptor );
	const map< eAtlasPinDescriptor, const string* >::const_iterator itEnd = m_mapAtlasPinDescriptorEnumToPinDescriptor.end( );

	if ( itEnd != it )
	{
		strPinDescriptor = *( it->second );
	}

	return strPinDescriptor;
}

string Atlas::GetAtlasPinDescriptorDescription( const eAtlasPinDescriptor ePinDescriptor )
{
	string strPinDescriptorDescription( m_UNKNOWN );

	const map< eAtlasPinDescriptor, const string* >::const_iterator it = m_mapAtlasPinDescriptorEnumToPinDescriptorDescription.find( ePinDescriptor );
	const map< eAtlasPinDescriptor, const string* >::const_iterator itEnd = m_mapAtlasPinDescriptorEnumToPinDescriptorDescription.end( );

	if ( itEnd != it )
	{
		strPinDescriptorDescription = *( it->second );
	}

	return strPinDescriptorDescription;
}


ieee1641::eBSC Atlas::Get1641BSCEnumByAtlasPinDescriptorEnum( const eAtlasPinDescriptor ePinDescriptor )
{
	ieee1641::eBSC e = ieee1641::eUnknownBSC;

	const map< eAtlasPinDescriptor, ieee1641::eBSC >::const_iterator it = m_mapAtlasPinDescriptorEnumTo1641BSCEnum.find( ePinDescriptor );
	const map< eAtlasPinDescriptor, ieee1641::eBSC >::const_iterator itEnd = m_mapAtlasPinDescriptorEnumTo1641BSCEnum.end( );

	if ( itEnd != it )
	{
		e = it->second;
	}
	
	return e;
}

ieee1641::eBSCAttribute Atlas::Get1641BSCAttributeEnumByAtlasPinDescriptorEnum( const eAtlasPinDescriptor ePinDescriptor )
{
	ieee1641::eBSCAttribute e = ieee1641::eUnknownBSCAttribute;

	const map< eAtlasPinDescriptor, ieee1641::eBSCAttribute >::const_iterator it = m_mapAtlasPinDescriptorEnumTo1641BSCAttributeEnum.find( ePinDescriptor );
	const map< eAtlasPinDescriptor, ieee1641::eBSCAttribute >::const_iterator itEnd = m_mapAtlasPinDescriptorEnumTo1641BSCAttributeEnum.end( );

	if ( itEnd != it )
	{
		e = it->second;
	}
	
	return e;
}

void Atlas::InitUnitsOfMeasure( void )
{
	const int iMax = ( eFootLambert + 1 );

	for ( int i = 0; i < iMax; ++i )
	{
		m_mapAtlasUnitOfMeasureToEnum.insert( make_pair( &m_arrayUnitsOfMeasure[ i ].m_strAtlasUnitOfMeasure, ( eUnitOfMeasure ) i ) );
		m_mapSIUnitOfMeasureToEnum.insert( make_pair( &m_arrayUnitsOfMeasure[ i ].m_strInternationalSystemUnitOfMeasure, ( eUnitOfMeasure ) i ) );
		m_mapUnitOfMeasureEnumToAtlasUnitOfMeasure.insert( make_pair( ( eUnitOfMeasure ) i, &m_arrayUnitsOfMeasure[ i ].m_strAtlasUnitOfMeasure ) );
		m_mapUnitOfMeasureEnumToSIUnitOfMeasure.insert( make_pair( ( eUnitOfMeasure ) i, &m_arrayUnitsOfMeasure[ i ].m_strInternationalSystemUnitOfMeasure ) );
		m_mapUnitOfMeasureEnumToUnitOfMeasureDescription.insert( make_pair( ( eUnitOfMeasure ) i, &m_arrayUnitsOfMeasure[ i ].m_strUnitOfMeasureDescription ) );
	}
}


Atlas::eUnitOfMeasure Atlas::GetUnitOfMeasureEnumByAlasUnit( const string& strUnitOfMeasure )
{
	eUnitOfMeasure e = eUnknownUnitOfMeasure;

	const map< const string*, eUnitOfMeasure, AIXMLHelper::cmpPointer >::const_iterator it = m_mapAtlasUnitOfMeasureToEnum.find( &strUnitOfMeasure );
	const map< const string*, eUnitOfMeasure, AIXMLHelper::cmpPointer >::const_iterator itEnd = m_mapAtlasUnitOfMeasureToEnum.end( );

	if ( itEnd != it )
	{
		e = it->second;
	}
	
	return e;
}

Atlas::eUnitOfMeasure Atlas::GetUnitOfMeasureEnumByUnit( const string& strUnitOfMeasure )
{
	eUnitOfMeasure e = eUnknownUnitOfMeasure;

	const map< const string*, eUnitOfMeasure, AIXMLHelper::cmpPointer >::const_iterator it = m_mapSIUnitOfMeasureToEnum.find( &strUnitOfMeasure );
	const map< const string*, eUnitOfMeasure, AIXMLHelper::cmpPointer >::const_iterator itEnd = m_mapSIUnitOfMeasureToEnum.end( );

	if ( itEnd != it )
	{
		e = it->second;
	}
	
	return e;
}

string Atlas::GetAtlasUnitOfMeasure( const Atlas::eUnitOfMeasure eUnit )
{
	string strAtlasUnitOfMeasure( m_UNKNOWN );

	const map< eUnitOfMeasure, const string* >::const_iterator it = m_mapUnitOfMeasureEnumToAtlasUnitOfMeasure.find( eUnit );
	const map< eUnitOfMeasure, const string* >::const_iterator itEnd = m_mapUnitOfMeasureEnumToAtlasUnitOfMeasure.end( );

	if ( itEnd != it )
	{
		strAtlasUnitOfMeasure = *( it->second );
	}

	return strAtlasUnitOfMeasure;
}

string Atlas::GetUnitOfMeasure( const Atlas::eUnitOfMeasure eUnit )
{
	string strUnitOfMeasure( m_UNKNOWN );

	const map< eUnitOfMeasure, const string* >::const_iterator it = m_mapUnitOfMeasureEnumToSIUnitOfMeasure.find( eUnit );
	const map< eUnitOfMeasure, const string* >::const_iterator itEnd = m_mapUnitOfMeasureEnumToSIUnitOfMeasure.end( );

	if ( itEnd != it )
	{
		strUnitOfMeasure = *( it->second );
	}

	return strUnitOfMeasure;
}

string Atlas::GetUnitOfMeasureDescription( const Atlas::eUnitOfMeasure eUnit )
{
	string strUnitOfMeasureDescription( m_UNKNOWN );

	const map< eUnitOfMeasure, const string* >::const_iterator it = m_mapUnitOfMeasureEnumToUnitOfMeasureDescription.find( eUnit );
	const map< eUnitOfMeasure, const string* >::const_iterator itEnd = m_mapUnitOfMeasureEnumToUnitOfMeasureDescription.end( );

	if ( itEnd != it )
	{
		strUnitOfMeasureDescription = *( it->second );
	}

	return strUnitOfMeasureDescription;
}

void Atlas::InitAtlasSignalTo1641Signal( void )
{
	eAtlasNoun eLastNoun = eUnknownAtlasNoun;
	unsigned int ui = 0;
	AtlasSignal as;

	while ( ui < m_uiAtlasSignalCount )
	{
		const AS1S& a = m_arrayAtlasSignalTo1641Signal[ ui ];

		as.Init( );

		as.m_eAtlasNoun = a.m_eAtlasNoun;
		as.m_e1641TSF = Atlas::Get1641TSFEnumByAtlasNounEnum( as.m_eAtlasNoun );
		eLastNoun = a.m_eAtlasNoun;

		while ( eLastNoun == a.m_eAtlasNoun )
		{
			as.m_mapNM_1641.insert( make_pair( a.m_eAtlasNounModifier, make_pair( a.m_eBCS, a.m_eBCSAttribute ) ) );

			++ui;

			if ( ui == m_uiAtlasSignalCount ) 
			{
				break;
			}

			eLastNoun = a.m_eAtlasNoun;

			( AS1S& ) a = m_arrayAtlasSignalTo1641Signal[ ui ];
		}

		m_mapAtlasSignalTo1641Signal.insert( make_pair( as.m_eAtlasNoun, as ) );
	}
}

Atlas::AtlasData& Atlas::AtlasData::operator = ( const Atlas::AtlasData& other )
{
	if ( this != &other )
	{
		m_strVariableName	= other.m_strVariableName;
		m_eScopeType		= other.m_eScopeType;
		m_eBuiltInType		= other.m_eBuiltInType;
		m_uiVariableRefId	= other.m_uiVariableRefId;
		m_eAtlasDataType	= other.m_eAtlasDataType;
		m_eDataType			= other.m_eDataType;
		m_UnitOfMeasure		= other.m_UnitOfMeasure;
	}

	return *this;
}

bool Atlas::AtlasData::IsBitwiseDataType( void ) const
{
	bool bIsBitwiseDataType = false;

	switch ( m_eAtlasDataType )
	{
		case eBIT:
		case eBITS:
		case eDIGITAL:
		case eDIGITAL_BNR:
		case eDIGITAL_B1C:
		case eDIGITAL_B2C:
		case eDIGITAL_BSM:
		case eDIGITAL_BCD:
		case eDIGITAL_SBCD:
			bIsBitwiseDataType = true;
			break;
	}

	return bIsBitwiseDataType;
}

bool Atlas::AtlasData::IsAtlasNumericDataType( void ) const
{
	bool bIsNumeric = false;

	switch ( m_eAtlasDataType )
	{
		case eDECIMAL:
		case eLONG_DECIMAL:
		case eINTEGER:
		case eLONG_INTEGER:
			bIsNumeric = true;
			break;
	}

	return bIsNumeric;
}

string Atlas::AtlasData::ToXML( const bool bVariableNameVerficiation ) const
{
	string strXML;

	if ( !m_strVariableName.empty( ) )
	{
		const XML::AttributeValue avScope = GetScopeAttributeValue( );
		const XML::AttributeValue avDataType = GetDataTypeAttributeValue( );

		strXML.reserve( 50 );

		strXML += XML::MakeXmlAttributeNameValue( XML::anVariableName, m_strVariableName );
		strXML += XML::MakeXmlAttributeNameValue( XML::anType, avDataType );
		strXML += m_UnitOfMeasure.ToXML( );
		strXML += XML::MakeXmlAttributeNameValue( XML::anScope, avScope );
		strXML += XML::MakeXmlAttributeNameValue( XML::anRefId, m_uiVariableRefId );

		#if ( _DEBUG ) && ( WIN32 )
		if ( 0 == m_uiVariableRefId )
		{
			DebugBreak( );
		}
		if ( XML::avUnknown == avScope )
		{
			DebugBreak( );
		}
		if ( XML::avUnknown == avDataType )
		{
			DebugBreak( );
		}
		#endif		 
	}

	return strXML;
}

string Atlas::AtlasData::GetHashValue( void ) const
{
	string strHashValue( m_strVariableName );
	strHashValue += ":";
	strHashValue += AIXMLHelper::NumberToString< unsigned int >( m_uiVariableRefId );

	return strHashValue;
}

XML::AttributeValue Atlas::AtlasData::GetDataTypeAttributeValue( void ) const
{
	XML::AttributeValue avDataType = XML::avUnknown;

	if ( eUnknownDataType == m_eDataType )
	{
		if ( Atlas::eUnknownDataType != m_eAtlasDataType )
		{
			avDataType = AtlasDeclare::GetDataTypeAttributeValue( m_eAtlasDataType );
		}
	}
	else
	{
		switch ( m_eDataType )
		{
			case eDouble:
				avDataType = XML::avDecimal;
				break;

			case eInteger:
				avDataType = XML::avInteger;
				break;

			case eBinary:
				avDataType = XML::avBinary;
				break;

			case eHexadecimal:
				avDataType = XML::avHexadecimal;
				break;

			case eOctal:
				avDataType = XML::avOctal;
				break;

			case eConnector:
				avDataType = XML::avConnector;
				break;

			case eBoolean:
				avDataType = XML::avBoolean;
				break;

			case eString:
				avDataType = XML::avChar;
				break;
		}
	}

	return avDataType;
}

XML::AttributeValue Atlas::AtlasData::GetScopeAttributeValue( void ) const
{
	XML::AttributeValue avScope = XML::avUnknown;

	switch ( m_eScopeType )
	{
		case eGlobal:
			avScope = XML::avGlobal;
			break;

		case eFileLocal:
			avScope = XML::avFileLocal;
			break;

		case eSegmentLocal:
			avScope = XML::avSegmentLocal;
			break;

		case eProcedureLocal:
			avScope = XML::avProcLocal;
			break;

		case eProcedureParameter:
			avScope = XML::avProcParam;
			break;

		case eProcedureResult:
			avScope = XML::avProcResult;
			break;

		case eBuiltIn:
			avScope = XML::avBuiltIn;
			break;
	}

	return avScope;
}

void Atlas::AtlasNumber::Init( void )
{
	m_dValue					= numeric_limits< double >::quiet_NaN( );
	m_bSymmetricalErrorLimit	= false;
	m_eDataType					= eUnknownDataType;
	m_eAtlasDataType			= Atlas::eUnknownDataType;

	m_strValue.erase( );
	m_strVariableName.erase( );
	m_UnitOfMeasure.Clear( );
}

bool Atlas::AtlasNumber::IsNaN( void ) const
{
	return ( 1 == ::_isnan( m_dValue ) );
}

bool Atlas::AtlasNumber::ReplaceIfLarger( const AtlasNumber& other )
{
	bool bReplace = false;

	if ( this != &other )
	{
		if ( m_strVariableName.empty( ) )
		{
			const bool bNan = IsNaN( );
			const bool bOtherNan = other.IsNaN( );
	
			if ( !bNan && !bOtherNan )
			{
				if ( operator != ( other ) )
				{
					if ( m_UnitOfMeasure == other.m_UnitOfMeasure )
					{
						if ( other.m_dValue > m_dValue )
						{
							bReplace = true;
						}
					}
					else
					{
						// -- TODO --
						// Are the units of measure compatiable (i.e. eVolt vs. eKilovolt, or eVolt vs. eMilliliter [no conversion, doesn't make sense])
						// If so, recalculate a new base then compare.
	
						#if ( _DEBUG ) && ( WIN32 )
							//DebugBreak( );
						#endif
					}
				}
			} 
			else if ( bNan && !bOtherNan )
			{
				bReplace = true;
			}
		}
	}

	if ( bReplace )
	{
		operator = ( other );
	}

	return bReplace;
}

bool Atlas::AtlasNumber::ReplaceIfSmaller( const AtlasNumber& other )
{
	bool bReplace = false;

	if ( this != &other )
	{
		if ( m_strVariableName.empty( ) )
		{
			const bool bNan = IsNaN( );
			const bool bOtherNan = other.IsNaN( );
	
			if ( !bNan && !bOtherNan )
			{
				if ( operator != ( other ) )
				{
					if ( m_UnitOfMeasure == other.m_UnitOfMeasure )
					{
						if ( other.m_dValue < m_dValue )
						{
							bReplace = true;
						}
					}
					else
					{
						// -- TODO --
						// Are the units of measure compatiable (i.e. eVolt vs. eKilovolt, or eVolt vs. eMilliliter [no conversion, doesn't make sense])
						// If so, recalculate a new base then compare.
	
						#if ( _DEBUG ) && ( WIN32 )
							//DebugBreak( );
						#endif
					}
				}
			} 
			else if ( bNan && !bOtherNan )
			{
				bReplace = true;
			}
		}
	}

	if ( bReplace )
	{
		operator = ( other );
	}

	return bReplace;
}

string Atlas::AtlasNumber::ToXML( const bool bVariableNameVerficiation ) const
{
	string strXML;

	if ( bVariableNameVerficiation && IsVariableName( ) )
	{
		strXML.reserve( 50 );

		strXML += AtlasData::ToXML( );
	}
	else if ( !IsNaN( ) )
	{
		strXML.reserve( 50 );

		strXML += XML::MakeXmlAttributeNameValue( XML::anValue, m_strValue );

		switch ( m_eDataType )
		{
			case eDouble:
				strXML += XML::MakeXmlAttributeNameValue( XML::anType, XML::avDecimal );
				break;

			case eInteger:
				strXML += XML::MakeXmlAttributeNameValue( XML::anType, XML::avInteger );
				break;

			case eBinary:
				strXML += XML::MakeXmlAttributeNameValue( XML::anType, XML::avDigital );
				strXML += XML::MakeXmlAttributeNameValue( XML::anDigital, XML::avBinary );
				break;

			case eHexadecimal:
				strXML += XML::MakeXmlAttributeNameValue( XML::anType, XML::avDigital );
				strXML += XML::MakeXmlAttributeNameValue( XML::anDigital, XML::avHexadecimal );
				break;

			case eOctal:
				strXML += XML::MakeXmlAttributeNameValue( XML::anType, XML::avDigital );
				strXML += XML::MakeXmlAttributeNameValue( XML::anDigital, XML::avOctal );
				break;
		}

		if ( !strXML.empty( ) )
		{
			strXML += m_UnitOfMeasure.ToXML( );
		}
	}

	return strXML;
}

bool Atlas::AtlasNumber::Set( const string& strNumber, const AtlasUnitOfMeasure& AtlasUnit )
{
	const unsigned int uiSize = strNumber.length( );
	bool bSet = false;

	Init( );

	if ( uiSize > 0 )
	{
		bool bHex = false;
		bool bBin = false;
		bool bOct = false;

		if ( uiSize > 1 )
		{
			char chFirst = strNumber[ 0 ];

			if ( ( chFirst >= 'A' ) && ( chFirst <= 'Z' ) )
			{
				chFirst += 32;
			}

			bHex = ( 'x' == chFirst );
			bBin = ( 'b' == chFirst );
			bOct = ( 'o' == chFirst );
	
			if ( bHex || bBin || bOct )
			{
				if ( ( '\'' != strNumber[ 1 ] ) && ( '\'' != strNumber[ uiSize - 1 ] ) )
				{
					bHex = false;
					bBin = false;
					bOct = false;
				}
			}
		}

		if ( bHex || bBin || bOct )
		{
			m_strValue = strNumber.substr( 2, ( uiSize - 3 ) );

			if ( bBin )
			{
				m_dValue = ( double ) AIXMLHelper::BinaryStringToNumber( m_strValue );
				m_eDataType = eBinary;
				m_eAtlasDataType = eDIGITAL;
			}
			else if ( bHex )
			{
				m_dValue = ( double ) AIXMLHelper::HexStringToNumber( m_strValue );
				m_eDataType = eHexadecimal;
				m_eAtlasDataType = eDIGITAL;
			}
			else
			{
				m_dValue = ( double ) AIXMLHelper::OctalStringToNumber( m_strValue );
				m_eDataType = eOctal;
				m_eAtlasDataType = eDIGITAL;
			}

			m_UnitOfMeasure = AtlasUnit;

			bSet = true;
		}
		else
		{
			string strTempNumber( strNumber );
			unsigned int uiErrorLimit = 0;
		
			if ( strTempNumber.size( ) >= 2 )
			{
				const unsigned int uiCount = ( strTempNumber[ 0 ] + strTempNumber[ 1 ] );
		
				if ( uiCount == ( '+' + '-' ) )
				{
					uiErrorLimit = 2;
				}
			}
		
			if ( uiErrorLimit > 0 )
			{
				strTempNumber = strNumber.substr( uiErrorLimit );
				m_bSymmetricalErrorLimit = true;
			}
	
			if ( AIXMLHelper::IsNumber( strTempNumber ) )
			{
				m_dValue = AIXMLHelper::StringToNumber< double >( strTempNumber );
				m_strValue = strTempNumber;
				m_UnitOfMeasure = AtlasUnit;
	
				if ( string::npos == strTempNumber.find_first_of( "Ee." ) )
				{
					m_eDataType = eInteger;
					m_eAtlasDataType = eINTEGER;
				}
				else
				{
					m_eDataType = eDouble;
					m_eAtlasDataType = eDECIMAL;
				}
	
				bSet = true;
			}
		}
	}

	return bSet;
}

Atlas::AtlasNumber& Atlas::AtlasNumber::operator = ( const Atlas::AtlasNumber& other )
{
	if ( this != &other )
	{
		AtlasData::operator = ( other );

		m_dValue					= other.m_dValue;
		m_strValue					= other.m_strValue;
		m_bSymmetricalErrorLimit	= other.m_bSymmetricalErrorLimit;
	}

	return *this;
}

bool Atlas::AtlasNumber::operator == ( const Atlas::AtlasNumber& other ) const
{
	bool bRet = false;

	if ( this == &other )
	{
		bRet = true;
	}
	else
	{
		if ( !m_strVariableName.empty( ) || !other.m_strVariableName.empty( ) )
		{
			bRet = ( m_strVariableName == other.m_strVariableName );
		}
		else
		{
			const bool bIsNan = IsNaN( );
			const bool bIsNanOther = other.IsNaN( );
			
			if ( !bIsNan && !bIsNanOther )
			{
				bRet = ( m_dValue == other.m_dValue );
	
				if ( bRet )
				{
					bRet = ( m_UnitOfMeasure == other.m_UnitOfMeasure );
				}
			}
			else if ( bIsNan && bIsNanOther )
			{
				bRet = true;
			}
		}
	}

	return bRet;
}

bool Atlas::AtlasNumber::operator != ( const Atlas::AtlasNumber& other ) const
{
	return !( operator == ( other ) );
}

bool Atlas::AtlasNumber::operator < ( const AtlasNumber& other ) const
{
	bool bRet = true;

	if ( this == &other )
	{
		bRet = false;
	}
	else
	{
		if ( !m_strVariableName.empty( ) || !other.m_strVariableName.empty( ) )
		{
			bRet = ( m_strVariableName < other.m_strVariableName );
		}
		else
		{
			const bool bIsNan = IsNaN( );
			const bool bIsNanOther = other.IsNaN( );
			
			if ( !bIsNan && !bIsNanOther )
			{
				bRet = ( m_dValue < other.m_dValue );
			}
			else if ( bIsNan && bIsNanOther )
			{
				bRet = false;
			}
		}
	}

	return bRet;
}

bool Atlas::AtlasNumber::operator <= ( const AtlasNumber& other ) const
{
	bool bRet = ( operator < ( other ) );

	if ( !bRet )
	{
		bRet = ( operator == ( other ) );
	}

	return bRet;
}

bool Atlas::AtlasNumber::operator > ( const AtlasNumber& other ) const
{
	bool bRet = true;

	if ( this == &other )
	{
		bRet = false;
	}
	else
	{
		if ( !m_strVariableName.empty( ) || !other.m_strVariableName.empty( ) )
		{
			bRet = ( m_strVariableName > other.m_strVariableName );
		}
		else
		{
			const bool bIsNan = IsNaN( );
			const bool bIsNanOther = other.IsNaN( );
			
			if ( !bIsNan && !bIsNanOther )
			{
				bRet = ( m_dValue > other.m_dValue );
			}
			else if ( bIsNan && bIsNanOther )
			{
				bRet = false;
			}
		}
	}

	return bRet;
}

bool Atlas::AtlasNumber::operator >= ( const AtlasNumber& other ) const
{
	bool bRet = ( operator > ( other ) );

	if ( !bRet )
	{
		bRet = ( operator == ( other ) );
	}

	return bRet;
}

Atlas::AtlasNumber::operator int( void ) const
{
	int i = 0;

	if ( !IsNaN( ) )
	{
		i = ( int ) m_dValue;
	}

	return i;
}


Atlas::AtlasNumber::operator long( void ) const
{
	long l = 0;

	if ( !IsNaN( ) )
	{
		l = ( long ) m_dValue;
	}

	return l;
}

void Atlas::AtlasNumber::SetDataType( const eDataType eType )
{ 
	m_eDataType = eType;

	switch ( m_eDataType )
	{
		case eDouble:
			m_eAtlasDataType = eDECIMAL;
			break;

		case eInteger:
			m_eAtlasDataType = eINTEGER;
			break;

		case eBinary:
			m_eAtlasDataType = eDIGITAL;
			break;

		case eHexadecimal:
			m_eAtlasDataType = eDIGITAL;
			break;

		case eOctal:
			m_eAtlasDataType = eDIGITAL;
			break;
	}
}

void Atlas::AtlasNumber::SetAtlasDataType( const Atlas::eDataType eType )
{ 
	m_eAtlasDataType = eType;

	switch ( m_eAtlasDataType )
	{
		case eDECIMAL:
		case eLONG_DECIMAL:
			m_eDataType = eDouble;
			break;

		case eINTEGER:
		case eLONG_INTEGER:
			m_eDataType = eInteger;
			break;

		case eDIGITAL:
			m_eDataType = eBinary;
			//m_eDataType = eHexadecimal;
			//m_eDataType = eOctal;
			break;
	}
}

bool Atlas::AtlasNumber::IsNegative( void ) const
{
	bool bIsNegative = false;

	if ( !IsNaN( ) )
	{
		if ( m_dValue < ( double ) 0 )
		{
			bIsNegative = true;
		}
	}

	return bIsNegative;
}


bool Atlas::AtlasNumber::IsWholeNumber( void ) const
{
	bool bIsWholeNumber = false;

	if ( !IsNaN( ) )
	{
		double dIntPart = 0;

		::modf( m_dValue, &dIntPart );

		if ( m_dValue == dIntPart )
		{
			bIsWholeNumber = true;
		}
	}

	return bIsWholeNumber;
}

string Atlas::AtlasNumber::GetNumber( const bool bIncludeUnitOfMeasure ) const
{
	string strNumber;

	if ( !IsNaN( ) )
	{
		strNumber = m_strValue;

		if ( bIncludeUnitOfMeasure )
		{
			if ( m_UnitOfMeasure.IsUnit( ) )
			{
				strNumber += " ";
				strNumber += ( string ) m_UnitOfMeasure;
			}
		}
	}

	return strNumber;
}

Atlas::AtlasSignalComponent::AtlasSignalComponent( const eAtlasNoun eNoun, const eAtlasNounModifier eNounModifier, Atlas::eAtlasFunction eFunction ) 
{ 
	Init( ); 
	
	m_eAtlasNoun			= eNoun; 
	m_eAtlasNounModifier	= eNounModifier; 
	m_eAtlasFunction		= eFunction;
}


Atlas::AtlasSignalComponent& Atlas::AtlasSignalComponent::operator = ( const Atlas::AtlasSignalComponent& other )
{
	if ( this != &other )
	{
		m_eAtlasNoun					= other.m_eAtlasNoun;
		m_eAtlasNounResource			= other.m_eAtlasNounResource;
		m_eAtlasNounModifier			= other.m_eAtlasNounModifier;
		m_setAtlasNounModifierRequire	= other.m_setAtlasNounModifierRequire;
		m_eAtlasFunction				= other.m_eAtlasFunction;
		m_eAtlasPinDescriptor			= other.m_eAtlasPinDescriptor;
		m_strSuffix						= other.m_strSuffix;
		m_vectSuffix					= other.m_vectSuffix;
		m_iTSF							= other.m_iTSF;
		m_i1641BSC						= other.m_i1641BSC;
		m_i1641BSCAttribute				= other.m_i1641BSCAttribute;
		m_vect1641Qualifier				= other.m_vect1641Qualifier;
		m_strPhase						= other.m_strPhase;
	}

	return *this;
}

bool Atlas::AtlasSignalComponent::operator == ( const Atlas::AtlasSignalComponent& other ) const
{
	bool bEqual = true;

	if ( this != &other )
	{
		if ( m_eAtlasNoun != other.m_eAtlasNoun )
		{
			bEqual = false;
		}
		else if ( m_eAtlasNounModifier != other.m_eAtlasNounModifier )
		{
			bEqual = false;
		}
		else if ( m_strSuffix != other.m_strSuffix )
		{
			bEqual = false;
		}
		else if ( m_eAtlasFunction != other.m_eAtlasFunction )
		{
			bEqual = false;
		}
		else if ( m_eAtlasPinDescriptor != other.m_eAtlasPinDescriptor )
		{
			bEqual = false;
		}
	}

	return bEqual;
}

Atlas::AtlasSignalComponent::operator string( void ) const
{
	const string strColon( ":" );
	string strRet;

	strRet += GetAtlasNounAsString( );
	strRet += strColon;
	strRet += GetAtlasNounModifierAsString( );
	if ( !m_strSuffix.empty( ) )
	{
		strRet += strColon;
		strRet += m_strSuffix;
	}
	strRet += strColon;
	strRet += GetAtlasFunctionAsString( );
	strRet += strColon;
	strRet += GetAtlasPinDescriptorAsString( );

	return strRet;
}	

void Atlas::AtlasSignalComponent::SetAtlasNounModifierSuffix( const string& strSuffix ) 
{
	m_strSuffix = strSuffix;

	if ( !m_strSuffix.empty( ) )
	{
		const string strSuffixDelim( "-" );
		static map< eAtlasModifierSuffix, eAtlasModifierSuffix > mapPhases;
		vector< string > vectSuffix;

		if ( 0 == mapPhases.size( ) )
		{
			mapPhases.insert( make_pair( eASuffix, ePHASEASuffix ) );
			mapPhases.insert( make_pair( eBSuffix, ePHASEBSuffix ) );
			mapPhases.insert( make_pair( eCSuffix, ePHASECSuffix ) );
			mapPhases.insert( make_pair( eABSuffix,ePHASEABSuffix ) );
			mapPhases.insert( make_pair( eACSuffix,ePHASEACSuffix ) );
			mapPhases.insert( make_pair( eBASuffix,ePHASEBASuffix ) );
			mapPhases.insert( make_pair( eBCSuffix,ePHASEBCSuffix ) );
			mapPhases.insert( make_pair( eCASuffix,ePHASECASuffix ) );
			mapPhases.insert( make_pair( eCBSuffix,ePHASECBSuffix ) );
		}

		AIXMLHelper::Trim( m_strSuffix, true, false, strSuffixDelim );
	
		vectSuffix = AIXMLHelper::SplitString< string >( m_strSuffix, strSuffixDelim );
	
		const unsigned int uiSize = vectSuffix.size( );

		if ( uiSize > 0 )
		{
			eAtlasModifierSuffix eSuffix = eUnknownAtlasSuffix;
			eAtlasModifierSuffix eLastSuffix = eUnknownAtlasSuffix;
			int iLastNumber = -1;

			for ( unsigned int ui = 0; ui < uiSize; ++ui )
			{
				eSuffix = GetAtlasSuffixEnum( vectSuffix[ ui ] );

				if ( eUnknownAtlasSuffix != eSuffix )
				{
					bool bPushBack = true;

					if ( ePHASESuffix == eLastSuffix )
					{
						const map< eAtlasModifierSuffix, eAtlasModifierSuffix >::const_iterator it = mapPhases.find( eSuffix );

						if ( mapPhases.end( ) != it )
						{
							m_vectSuffix.back( ).first = it->second;
							bPushBack = false;
						}
					}

					if ( bPushBack )
					{
						m_vectSuffix.push_back( make_pair( eSuffix, -1 ) );
					}
				}
				else if ( AIXMLHelper::IsNumber( vectSuffix[ ui ] ) )
				{
					// Needs more work...

					// Not handling situations where numbers are used as part of the suffixes or
					// not are suffixes are handled properly.

					// Numbers should be placed in into "second": m_vectSuffix< first, second >
					// Defaulting to -1 when no number.

					iLastNumber = AIXMLHelper::StringToNumber< int >( vectSuffix[ ui ] );
				}
				else 
				{
					// Nees more work...

					// What to do with unknown suffixes?
				}

				eLastSuffix = eSuffix;
			}
		}
	}
}

bool Atlas::AtlasSignalComponent::IsValid( void ) const
{ 
	bool bGood = false;

	if ( Atlas::eUnknownAtlasNoun != m_eAtlasNoun )
	{
		bGood = true;
	}
	else if ( Atlas::eUnknownAtlasNounModifier != m_eAtlasNounModifier )
	{
		bGood = true;
	}

	return bGood; 
}

bool Atlas::AtlasSignalComponent::IsValid1641( void ) const
{
	bool bGood = false;

	if ( m_iInvalid1641Value != m_iTSF )
	{
		bGood = true;
	}
	else if ( m_iInvalid1641Value != m_i1641BSC )
	{
		bGood = true;
	}
	else if ( m_iInvalid1641Value != m_i1641BSCAttribute )
	{
		bGood = true;
	}
	else if ( m_vect1641Qualifier.size( ) > 0 )
	{
		bGood = true;
	}

	return bGood; 
}

void Atlas::AtlasSignalComponent::Set1641Connect( const ieee1641::eBSC eConnectBSC )
{
	Init1641( );

	if ( IsValid( ) || ( eUnknownAtlasPinDescriptor != m_eAtlasPinDescriptor ) )
	{
		const AtlasSignal* pAtlasSignal = 0; 

		if ( eUnknownAtlasNoun != m_eAtlasNoun )
		{
			pAtlasSignal = GetAtlasSignal( m_eAtlasNoun );
		}

		if ( 0 != pAtlasSignal )
		{
			m_iTSF = pAtlasSignal->m_e1641TSF;
		}

		if ( eUnknownAtlasPinDescriptor != m_eAtlasPinDescriptor )
		{
			m_i1641BSC = eConnectBSC;
			m_i1641BSCAttribute = Get1641BSCAttributeEnumByAtlasPinDescriptorEnum( m_eAtlasPinDescriptor );
		}
	}
}

void Atlas::AtlasSignalComponent::Set1641( void )
{
	Init1641( );

	if ( IsValid( ) )
	{
		const AtlasSignal* pAtlasSignal = 0; 

		if ( eUnknownAtlasNoun != m_eAtlasNoun )
		{
			pAtlasSignal = GetAtlasSignal( m_eAtlasNoun );
		}

		if ( 0 != pAtlasSignal )
		{
			m_iTSF = pAtlasSignal->m_e1641TSF;

			if ( eUnknownAtlasNounModifier != m_eAtlasNounModifier )
			{
				const pair< ieee1641::eBSC, ieee1641::eBSCAttribute >* ppr = pAtlasSignal->Get1641Info( m_eAtlasNounModifier );

				if ( 0 != ppr )
				{
					m_i1641BSC = ppr->first;
					m_i1641BSCAttribute = ppr->second;
				}
			}
	
			/*
			if ( eUnknownAtlasFunction != m_eAtlasFunction )
			{
				// m_i1641BSC
				// m_i1641BSCAttribute
			}
			*/

			const unsigned int uiSuffixes = m_vectSuffix.size( );
	
			if ( uiSuffixes > 0 )
			{
				for ( unsigned int ui = 0; ui < uiSuffixes; ++ui )
				{
					const ieee1641::eQualifier eQualifier = Atlas::Get1641QualifierEnumByAtlasSuffixEnum( m_vectSuffix[ ui ].first );
	
					if ( ieee1641::eUnknownQualifier != eQualifier )
					{
						m_vect1641Qualifier.push_back( eQualifier );
					}
					else if ( ( m_vectSuffix[ ui ].first >= ePHASEASuffix ) && ( m_vectSuffix[ ui ].first <= ePHASECBSuffix ) )
					{
						static map< eAtlasModifierSuffix, eAtlasModifierSuffix > mapPhases;
				
						if ( 0 == mapPhases.size( ) )
						{
							mapPhases.insert( make_pair( ePHASEASuffix, eASuffix ) );
							mapPhases.insert( make_pair( ePHASEBSuffix, eBSuffix ) );
							mapPhases.insert( make_pair( ePHASECSuffix, eCSuffix ) );
							mapPhases.insert( make_pair( ePHASEABSuffix, eABSuffix ) );
							mapPhases.insert( make_pair( ePHASEACSuffix, eACSuffix ) );
							mapPhases.insert( make_pair( ePHASEBASuffix, eBASuffix ) );
							mapPhases.insert( make_pair( ePHASEBCSuffix, eBCSuffix ) );
							mapPhases.insert( make_pair( ePHASECASuffix, eCASuffix ) );
							mapPhases.insert( make_pair( ePHASECBSuffix, eCBSuffix ) );
						}
	
						m_strPhase = AIXMLHelper::ToLower( Atlas::GetAtlasSuffix( mapPhases.find( m_vectSuffix[ ui ].first )->second ) );
					}
				}
			}
		}
	}
}

string Atlas::AtlasSignalComponent::ToXML( const XML::ElementName eName ) const
{
	string strXML;

	if ( IsValid( ) || ( eUnknownAtlasPinDescriptor != m_eAtlasPinDescriptor ) )
	{
		strXML.reserve( 500 );

		strXML += XML::MakeOpenXmlElementWithChildren( eName );

		ToXMLAtlas( strXML );

		if ( m_b1641ToXML )
		{
			if ( IsValid1641( ) )
			{
				ToXML1641( strXML );
			}
		}

		strXML += XML::MakeCloseXmlElementWithChildren( eName );
	}

	return strXML;
}

string Atlas::AtlasSignalComponent::GetAtlasNounModifierRequireDescription( void ) const
{
	const unsigned int uiSize = m_setAtlasNounModifierRequire.size( );
	string strDescription;

	if ( uiSize > 0 )
	{
		set< eAtlasRequire >::const_iterator it = m_setAtlasNounModifierRequire.begin( );
		const set< eAtlasRequire >::const_iterator itEnd = m_setAtlasNounModifierRequire.end( );

		while ( itEnd != it )
		{
			if ( !strDescription.empty( ) )
			{
				strDescription += ",";
			}

			strDescription += Atlas::GetAtlasRequire( *it );

			++it;
		}
	}

	return strDescription;
}

void Atlas::AtlasSignalComponent::ToXMLAtlas( string& strXML ) const
{
	if ( IsValid( ) || ( eUnknownAtlasPinDescriptor != m_eAtlasPinDescriptor ) )
	{
		strXML += XML::MakeOpenXmlElementWithChildren( XML::enAtlas );

		if ( eUnknownAtlasNoun != m_eAtlasNoun )
		{
			const string strType( XML::MakeXmlAttributeNameValue( XML::anType, GetAtlasNounAsString( ) ) );
			const string strDescription( XML::MakeXmlAttributeNameValue( XML::anDescription, GetAtlasNounDescription( ) ) );
			string strResource;

			if ( eUnknownAtlasResource != m_eAtlasNounResource )
			{
				strResource = XML::MakeXmlAttributeNameValue( XML::anResource, GetAtlasNounResourceDescription( ) );
			}

			strXML += XML::MakeXmlElementNoChildren( XML::enNoun, strType, strDescription, strResource );
		}

		if ( eUnknownAtlasNounModifier != m_eAtlasNounModifier )
		{
			const string strType( XML::MakeXmlAttributeNameValue( XML::anType, GetAtlasNounModifierAsString( ) ) );
			const string strDescription( XML::MakeXmlAttributeNameValue( XML::anDescription, GetAtlasNounModifierDescription( ) ) );
			string strRequire;
			string strSuffix;

			if ( m_setAtlasNounModifierRequire.size( ) > 0 )
			{
				strRequire = XML::MakeXmlAttributeNameValue( XML::anRequire, GetAtlasNounModifierRequireDescription( ) );
			}

			if ( !m_strSuffix.empty( ) )
			{
				strSuffix = XML::MakeXmlAttributeNameValue( XML::anSuffix, m_strSuffix );
			}
		
			strXML += XML::MakeXmlElementNoChildren( XML::enNounModifier, strType, strDescription, strSuffix, strRequire );
		}

		if ( eUnknownAtlasFunction != m_eAtlasFunction )
		{
			const string strType( XML::MakeXmlAttributeNameValue( XML::anType, GetAtlasFunction( ) ) );
			const string strDescription( XML::MakeXmlAttributeNameValue( XML::anDescription, GetAtlasFunctionDescription( ) ) );

			strXML += XML::MakeXmlElementNoChildren( XML::enFunction, strType, strDescription );
		}

		if ( eUnknownAtlasPinDescriptor != m_eAtlasPinDescriptor )
		{
			const string strType( XML::MakeXmlAttributeNameValue( XML::anType, GetAtlasPinDescriptorAsString( ) ) );
			const string strDescription( XML::MakeXmlAttributeNameValue( XML::anDescription, GetAtlasPinDescriptorDescription( ) ) );

			strXML += XML::MakeXmlElementNoChildren( XML::enConnector, strType, strDescription );
		}

		strXML += XML::MakeCloseXmlElementWithChildren( XML::enAtlas );
	}
}

void Atlas::AtlasSignalComponent::ToXML1641( string& strXML ) const
{
	if ( IsValid1641( ) )
	{
		strXML += XML::MakeOpenXmlElementWithChildren( XML::enIeee_1641 );

		if ( m_iInvalid1641Value != m_iTSF )
		{
			const string strType( XML::MakeXmlAttributeNameValue( XML::anType, ieee1641::GetTSF( ( ieee1641::eTSF ) m_iTSF ) ) );

			strXML += XML::MakeXmlElementNoChildren( XML::enTSF, strType );
		}

		if ( m_iInvalid1641Value != m_i1641BSC )
		{
			const string strType( XML::MakeXmlAttributeNameValue( XML::anType, ieee1641::GetBSC( ( ieee1641::eBSC ) m_i1641BSC ) ) );

			strXML += XML::MakeXmlElementNoChildren( XML::enBSC, strType );
		}

		if ( m_iInvalid1641Value != m_i1641BSCAttribute )
		{
			const string strType( XML::MakeXmlAttributeNameValue( XML::anType, ieee1641::GetBSCAttribute( ( ieee1641::eBSCAttribute ) m_i1641BSCAttribute ) ) );
			string strPhase;

			if ( !m_strPhase.empty( ) )
			{
				strPhase = XML::MakeXmlAttributeNameValue( XML::anPhase, m_strPhase );
			}

			strXML += XML::MakeXmlElementNoChildren( XML::enAttribute, strType, strPhase );
		}

		const unsigned int uiSize = m_vect1641Qualifier.size( );
		if ( uiSize > 0 )
		{
			strXML += XML::MakeOpenXmlElementWithChildren( XML::enQualifiers );

			for ( unsigned int ui = 0; ui < uiSize; ++ui )
			{
				const string strType( XML::MakeXmlAttributeNameValue( XML::anType, ieee1641::GetQualifier( m_vect1641Qualifier[ ui ] ) ) );

				strXML += XML::MakeXmlElementNoChildren( XML::enQualifier, strType );
			}

			strXML += XML::MakeCloseXmlElementWithChildren( XML::enQualifiers );
		}

		strXML += XML::MakeCloseXmlElementWithChildren( XML::enIeee_1641 );
	}
}

void Atlas::AtlasStatementCharacteristic::Init( void )
{
	m_pNumber = 0;
	m_pRange = 0;
	m_pErrorLimit = 0;
	m_prStartEnd = 0;
	m_pstrEventName1 = 0;
	m_pstrEventName2 = 0;
	m_pstrAttributeValue = 0;
	m_uiCharacteristics = 0;
}

void Atlas::AtlasStatementCharacteristic::GarbageCollect( void )
{
	if ( 0 != m_pNumber )
	{
		delete m_pNumber;
		m_pNumber = 0;
	}

	if ( 0 != m_pRange )
	{
		delete m_pRange;
		m_pRange = 0;
	}

	if ( 0 != m_pErrorLimit )
	{
		delete m_pErrorLimit;
		m_pErrorLimit = 0;
	}

	if ( 0 != m_prStartEnd )
	{
		if ( 0 != m_prStartEnd->first )
		{
			delete m_prStartEnd->first;
		}

		if ( 0 != m_prStartEnd->second )
		{
			delete m_prStartEnd->second;
		}

		delete m_prStartEnd;
		m_prStartEnd = 0;
	}

	if ( 0 != m_pstrEventName1 )
	{
		delete m_pstrEventName1;
		m_pstrEventName1 = 0;
	}

	if ( 0 != m_pstrEventName2 )
	{
		delete m_pstrEventName2;
		m_pstrEventName2 = 0;
	}

	if ( 0 != m_pstrAttributeValue )
	{
		delete m_pstrAttributeValue;
		m_pstrAttributeValue = 0;
	}

	m_uiCharacteristics = 0;
}

Atlas::AtlasStatementCharacteristic& Atlas::AtlasStatementCharacteristic::operator = ( const Atlas::AtlasStatementCharacteristic& other )
{
	if ( this != &other )
	{
		GarbageCollect( );

		if ( 0 != other.m_pNumber )
		{
			try
			{
				m_pNumber = new AtlasNumber( *( other.m_pNumber ) );
			}
			catch ( ... )
			{
				throw Exception( Exception::eFailedToCreateNumberObject, __FILE__, __FUNCTION__, __LINE__ );
			}
		}
	
		if ( 0 != other.m_pRange )
		{
			try
			{
				m_pRange = new AtlasRange( *( other.m_pRange ) );
			}
			catch ( ... )
			{
				throw Exception( Exception::eFailedToCreateRangeObject, __FILE__, __FUNCTION__, __LINE__ );
			}
		}

		if ( 0 != other.m_pErrorLimit )
		{
			try
			{
				m_pErrorLimit = new AtlasErrorLimit( *( other.m_pErrorLimit ) );
			}
			catch ( ... )
			{
				throw Exception( Exception::eFailedToCreateLimitObject, __FILE__, __FUNCTION__, __LINE__ );
			}
		}

		if ( 0 != other.m_prStartEnd )
		{
			try
			{
				m_prStartEnd = new pair< AtlasNumber*, AtlasNumber* >( );
			}
			catch ( ... )
			{
				throw Exception( Exception::eFailedToCreatePairObject, __FILE__, __FUNCTION__, __LINE__ );
			}

			if ( 0 != m_prStartEnd )
			{
				if ( 0 != other.m_prStartEnd->first )
				{
					try
					{
						m_prStartEnd->first = new AtlasNumber( *( m_prStartEnd->first ) );
					}
					catch ( ... )
					{
						throw Exception( Exception::eFailedToCreateNumberObject, __FILE__, __FUNCTION__, __LINE__ );
					}
				}

				if ( 0 != other.m_prStartEnd->second )
				{
					try
					{
						m_prStartEnd->second = new AtlasNumber( *( m_prStartEnd->second ) );
					}
					catch ( ... )
					{
						throw Exception( Exception::eFailedToCreateNumberObject, __FILE__, __FUNCTION__, __LINE__ );
					}
				}
			}
		}

		if ( 0 != other.m_pstrEventName1 )
		{
			try
			{
				m_pstrEventName1 = new string( *( other.m_pstrEventName1 ) );
			}
			catch ( ... )
			{
				throw Exception( Exception::eFailedToCreateStringObject, __FILE__, __FUNCTION__, __LINE__ );
			}
		}

		if ( 0 != other.m_pstrEventName2 )
		{
			try
			{
				m_pstrEventName2 = new string( *( other.m_pstrEventName2 ) );
			}
			catch ( ... )
			{
				throw Exception( Exception::eFailedToCreateStringObject, __FILE__, __FUNCTION__, __LINE__ );
			}
		}

		if ( 0 != other.m_pstrAttributeValue )
		{
			try
			{
				m_pstrAttributeValue = new string( *( m_pstrAttributeValue ) );
			}
			catch ( ... )
			{
				throw Exception( Exception::eFailedToCreateStringObject, __FILE__, __FUNCTION__, __LINE__ );
			}
		}

		m_uiCharacteristics = other.m_uiCharacteristics;
	}

	return *this;
}

void Atlas::AtlasStatementCharacteristic::SetNumber( Atlas::AtlasNumber* pNumber, const bool bTransferOwnership )
{ 
	if ( 0 != m_pNumber )
	{
		delete m_pNumber;
		m_pNumber = 0;
	}

	if ( bTransferOwnership )
	{
		m_pNumber = pNumber;
	}
	else if ( 0 != pNumber )
	{
		try
		{
			m_pNumber = new AtlasNumber( *( pNumber ) );
		}
		catch ( ... )
		{
			throw Exception( Exception::eFailedToCreateNumberObject, __FILE__, __FUNCTION__, __LINE__ );
		}
	}
}

void Atlas::AtlasStatementCharacteristic::SetRange( Atlas::AtlasRange* pRange, const bool bTransferOwnership )
{ 
	if ( 0 != m_pRange )
	{
		delete m_pRange;
		m_pRange = 0;
	}

	if ( bTransferOwnership )
	{
		m_pRange = pRange;
	}
	else if ( 0 != pRange )
	{
		try
		{
			m_pRange = new AtlasRange( *( pRange ) );
		}
		catch ( ... )
		{
			throw Exception( Exception::eFailedToCreateRangeObject, __FILE__, __FUNCTION__, __LINE__ );
		}
	}
}

void Atlas::AtlasStatementCharacteristic::SetErrorLimit( Atlas::AtlasErrorLimit* pErrorLimit, const bool bTransferOwnership )
{
	if ( 0 != m_pErrorLimit )
	{
		delete m_pErrorLimit;
		m_pErrorLimit = 0;
	}

	if ( bTransferOwnership )
	{
		m_pErrorLimit = pErrorLimit;
	}
	else if ( 0 != pErrorLimit )
	{
		try
		{
			m_pErrorLimit = new AtlasErrorLimit( *( pErrorLimit ) );
		}
		catch ( ... )
		{
			throw Exception( Exception::eFailedToCreateLimitObject, __FILE__, __FUNCTION__, __LINE__ );
		}
	}
}

void Atlas::AtlasStatementCharacteristic::SetStartNumber( Atlas::AtlasNumber* pNumber, const bool bTransferOwnership )
{
	if ( 0 != m_prStartEnd )
	{
		if ( 0 != m_prStartEnd->first )
		{
			delete m_prStartEnd->first;
			m_prStartEnd->first = 0;

			if ( ( 0 == m_prStartEnd->second ) && ( 0 == pNumber ) )
			{
				delete m_prStartEnd;
				m_prStartEnd = 0;
			}
		}
	}

	if ( 0 != pNumber )
	{
		if ( 0 == m_prStartEnd )
		{
			try
			{
				m_prStartEnd = new pair< AtlasNumber*, AtlasNumber* >( );
			}
			catch ( ... )
			{
				throw Exception( Exception::eFailedToCreatePairObject, __FILE__, __FUNCTION__, __LINE__ );
			}
		}

		if ( 0 != m_prStartEnd )
		{
			if ( bTransferOwnership )
			{
				m_prStartEnd->first = pNumber;
			}
			else
			{
				try
				{
					m_prStartEnd->first = new AtlasNumber( *( pNumber ) );
				}
				catch ( ... )
				{
					throw Exception( Exception::eFailedToCreateNumberObject, __FILE__, __FUNCTION__, __LINE__ );
				}
			}
		}
	}
}

void Atlas::AtlasStatementCharacteristic::SetEndNumber( Atlas::AtlasNumber* pNumber, const bool bTransferOwnership )
{
	if ( 0 != m_prStartEnd )
	{
		if ( 0 != m_prStartEnd->second )
		{
			delete m_prStartEnd->second;
			m_prStartEnd->second = 0;

			if ( ( 0 == m_prStartEnd->first ) && ( 0 == pNumber ) )
			{
				delete m_prStartEnd;
				m_prStartEnd = 0;
			}
		}
	}

	if ( 0 != pNumber )
	{
		if ( 0 == m_prStartEnd )
		{
			try
			{
				m_prStartEnd = new pair< AtlasNumber*, AtlasNumber* >( );
			}
			catch ( ... )
			{
				throw Exception( Exception::eFailedToCreatePairObject, __FILE__, __FUNCTION__, __LINE__ );
			}
		}

		if ( 0 != m_prStartEnd )
		{
			if ( bTransferOwnership )
			{
				m_prStartEnd->second = pNumber;
			}
			else
			{
				try
				{
					m_prStartEnd->second = new AtlasNumber( *( pNumber ) );
				}
				catch ( ... )
				{
					throw Exception( Exception::eFailedToCreateNumberObject, __FILE__, __FUNCTION__, __LINE__ );
				}
			}
		}
	}
}

void Atlas::AtlasStatementCharacteristic::SetEventName1( string* pstrEventName, const bool bTransferOwnership )
{
	if ( 0 != m_pstrEventName1 )
	{
		delete m_pstrEventName1;
		m_pstrEventName1 = 0;
	}

	if ( bTransferOwnership )
	{
		m_pstrEventName1 = pstrEventName;
	}
	else if ( 0 != pstrEventName )
	{
		try
		{
			m_pstrEventName1 = new string( *( pstrEventName ) );
		}
		catch ( ... )
		{
			throw Exception( Exception::eFailedToCreateStringObject, __FILE__, __FUNCTION__, __LINE__ );
		}
	}
}

void Atlas::AtlasStatementCharacteristic::SetEventName2( string* pstrEventName, const bool bTransferOwnership )
{
	if ( 0 != m_pstrEventName2 )
	{
		delete m_pstrEventName2;
		m_pstrEventName2 = 0;
	}

	if ( bTransferOwnership )
	{
		m_pstrEventName2 = pstrEventName;
	}
	else if ( 0 != pstrEventName )
	{
		try
		{
			m_pstrEventName2 = new string( *( pstrEventName ) );
		}
		catch ( ... )
		{
			throw Exception( Exception::eFailedToCreateStringObject, __FILE__, __FUNCTION__, __LINE__ );
		}
	}
}

void Atlas::AtlasStatementCharacteristic::SetAttributeValue( string* pstrAttrValue, const bool bTransferOwnership )
{
	if ( 0 != m_pstrAttributeValue )
	{
		delete m_pstrAttributeValue;
		m_pstrAttributeValue = 0;
	}

	if ( bTransferOwnership )
	{
		m_pstrAttributeValue = pstrAttrValue;
	}
	else if ( 0 != pstrAttrValue )
	{
		try
		{
			m_pstrAttributeValue = new string( *( pstrAttrValue ) );
		}
		catch ( ... )
		{
			throw Exception( Exception::eFailedToCreateStringObject, __FILE__, __FUNCTION__, __LINE__ );
		}
	}
}

bool Atlas::AtlasStatementCharacteristic::IsValid( void ) const
{
	bool bIsValid = false;

	do
	{
		if ( 0 != m_pErrorLimit )
		{
			if ( m_pErrorLimit->IsLimit( ) )
			{
				bIsValid = true;
				break;
			}
		}
	
		if ( 0 != m_pRange )
		{
			if ( m_pRange->IsRange( ) )
			{
				bIsValid = true;
				break;
			}
		}
	
		if ( 0 != m_prStartEnd ) 
		{
			if ( 0 != m_prStartEnd->first )
			{
				bIsValid = true;
				break;
			}

			if ( 0 != m_prStartEnd->second )
			{
				bIsValid = true;
				break;
			}
		}
	
		if ( 0 != m_pNumber )
		{
			bIsValid = true;
			break;
		}

		if ( 0 != m_pstrEventName1 )
		{
			bIsValid = true;
			break;
		}

		if ( 0 != m_pstrEventName2 )
		{
			bIsValid = true;
			break;
		}

		if ( 0 != m_pstrAttributeValue )
		{
			bIsValid = true;
			break;
		}
	}
	while ( false );

	return bIsValid;
}

void Atlas::AtlasStatementCharacteristic::ToXML( string& strXML ) const
{
	const string strVariableAttr( XML::MakeXmlAttributeNameValue( XML::anVariable, XML::avTrue ) );
	string strBeginingXML;
	string strEndingXML;

	// Is Range?
	if ( 0 != m_pRange )
	{
		strEndingXML += XML::MakeOpenXmlElementWithChildren( XML::enRange );

		strEndingXML += m_pRange->ToXML( );
	
		strEndingXML += XML::MakeCloseXmlElementWithChildren( XML::enRange );
	}

	// Is From?
	if ( IsFrom( ) )
	{
		XML::ElementName enElement = XML::enEvent;

		if ( IsGated( ) )
		{
			enElement = XML::enGated;
		}

		strEndingXML += XML::MakeOpenXmlElementWithChildren( enElement ); 

		if ( 0 != m_pstrEventName1 )
		{
			strEndingXML += XML::MakeXmlElementNoChildren( XML::enFrom, XML::MakeXmlAttributeNameValue( XML::anEventName, *m_pstrEventName1 ) );
		}

		if ( 0 != m_pstrEventName2 )
		{
			strEndingXML += XML::MakeXmlElementNoChildren( XML::enTo, XML::MakeXmlAttributeNameValue( XML::anEventName, *m_pstrEventName2 ) );
		}

		strEndingXML += XML::MakeCloseXmlElementWithChildren( enElement );
	}

	// Is Thru?
	if ( IsThru( ) )
	{
		strEndingXML += XML::MakeOpenXmlElementWithChildren( XML::enThru ); 

		if ( IsDimension( ) )
		{
			if ( 0 != m_prStartEnd )
			{
				if ( 0 != m_prStartEnd->first )
				{
					strEndingXML += XML::MakeXmlElementNoChildren( XML::enStart, m_prStartEnd->first->ToXML( ) );
				}

				if ( 0 != m_prStartEnd->second )
				{
					strEndingXML += XML::MakeXmlElementNoChildren( XML::enEnd, m_prStartEnd->second->ToXML( ) );
				}
			}
		}

		strEndingXML += XML::MakeCloseXmlElementWithChildren( XML::enThru );
	}

	if ( IsDimension( ) && !IsThru( ) )
	{
		if ( 0 != m_prStartEnd )
		{
			if ( 0 != m_prStartEnd->first )
			{
				strEndingXML += XML::MakeXmlElementNoChildren( XML::enStart, m_prStartEnd->first->ToXML( ) );
			}

			if ( 0 != m_prStartEnd->second )
			{
				strEndingXML += XML::MakeXmlElementNoChildren( XML::enEnd, m_prStartEnd->second->ToXML( ) );
			}
		}
	}

	// Is Event?
	if ( IsEvent( ) )
	{
		if ( 0 != m_pstrEventName1 )
		{
			XML::ElementName enElement = XML::enEvent;

			if ( IsSync( ) )
			{
				enElement = XML::enSync;
			}

			strEndingXML += XML::MakeXmlElementNoChildren( enElement, XML::MakeXmlAttributeNameValue( XML::anEventName, *m_pstrEventName1 ) );
		}
	}

	// Is Error Limit?
	if ( 0 != m_pErrorLimit )
	{
		strEndingXML += m_pErrorLimit->ToXML( );
	}

	if ( 0 != m_pstrAttributeValue )
	{
		const string strDash( "-" );
		const string strUnderscore( "_" );
		const string strValueAttr( XML::MakeXmlAttributeNameValue( XML::anValue, AIXMLHelper::SearchAndReplace< string >( AIXMLHelper::ToLower( *m_pstrAttributeValue ), strDash, strUnderscore ) ) );

		strEndingXML += XML::MakeXmlElementNoChildren( XML::enText, strValueAttr );
	}

	if ( 0 != m_pNumber )
	{
		string strAttributeNameValue;

		// Is Min or Max?
		if ( IsMax( ) || IsMin( ) )
		{
			strAttributeNameValue = XML::MakeXmlAttributeNameValue( IsMax( ) ? XML::anMaximum : XML::anMinimum, XML::avTrue );
		}

		strBeginingXML += XML::MakeXmlElementNoChildren( XML::enNumber, m_pNumber->ToXML( ), strAttributeNameValue );
	}

	strXML += strBeginingXML;
	strXML += strEndingXML;
}

Atlas::AtlasErrorLimit& Atlas::AtlasErrorLimit::operator = ( const Atlas::AtlasErrorLimit& other )
{
	if ( this != &other )
	{
		GarbageCollect( );

		if ( 0 != other.m_pLimit1 )
		{
			try
			{
				m_pLimit1 = new Atlas::AtlasNumber( *( other.m_pLimit1 ) );
			}
			catch ( ... )
			{
				throw Exception( Exception::eFailedToCreateNumberObject, __FILE__, __FUNCTION__, __LINE__ );
			}
		}

		if ( 0 != other.m_pLimit2 )
		{
			try
			{
				m_pLimit2 = new Atlas::AtlasNumber( *( other.m_pLimit2 ) );
			}
			catch ( ... )
			{
				throw Exception( Exception::eFailedToCreateNumberObject, __FILE__, __FUNCTION__, __LINE__ );
			}
		}
	}

	return *this;
}

bool Atlas::AtlasErrorLimit::IsLimit( void ) const
{
	bool bIsLimit = false;

	if ( 0 != m_pLimit1 )
	{
		bIsLimit = true;
	}
	else if ( 0 != m_pLimit2 )
	{
		bIsLimit = true;
	}

	return bIsLimit;
}

void Atlas::AtlasErrorLimit::Init( void )
{
	m_pLimit1 = 0;
	m_pLimit2 = 0;
}

void Atlas::AtlasErrorLimit::GarbageCollect( void )
{
	if ( 0 != m_pLimit1 )
	{
		delete m_pLimit1;
		m_pLimit1 = 0;
	}

	if ( 0 != m_pLimit2 )
	{
		delete m_pLimit2;
		m_pLimit2 = 0;
	}
}

void Atlas::AtlasErrorLimit::SetLimit1( Atlas::AtlasNumber* pNumber, const bool bTransferOwnership )
{
	if ( 0 != m_pLimit1 )
	{
		delete m_pLimit1;
		m_pLimit1 = 0;
	}

	if ( bTransferOwnership )
	{
		m_pLimit1 = pNumber;
	}
	else if ( 0 != pNumber )
	{
		try
		{
			m_pLimit1 = new AtlasNumber( *( pNumber ) );
		}
		catch ( ... )
		{
			throw Exception( Exception::eFailedToCreateNumberObject, __FILE__, __FUNCTION__, __LINE__ );
		}
	}
}

void Atlas::AtlasErrorLimit::SetLimit2( Atlas::AtlasNumber* pNumber, const bool bTransferOwnership )
{
	if ( 0 != m_pLimit2 )
	{
		delete m_pLimit2;
		m_pLimit2 = 0;
	}

	if ( bTransferOwnership )
	{
		m_pLimit2 = pNumber;
	}
	else if ( 0 != pNumber )
	{
		try
		{
			m_pLimit2 = new AtlasNumber( *( pNumber ) );
		}
		catch ( ... )
		{
			throw Exception( Exception::eFailedToCreateNumberObject, __FILE__, __FUNCTION__, __LINE__ );
		}
	}
}

string Atlas::AtlasErrorLimit::ToXML( void ) const
{
	string strXML;

	if ( IsLimit( ) )
	{
		strXML.reserve( 150 );

		AtlasNumber* pLimitLow = m_pLimit1;
		AtlasNumber* pLimitHigh = m_pLimit2;

		if ( ( 0 != pLimitLow ) && ( 0 != pLimitHigh ) )
		{
			if ( !pLimitLow->IsVariableName( ) && !pLimitHigh->IsVariableName( ) )
			{
				if ( *pLimitLow > *pLimitHigh )
				{
					AtlasNumber* pTemp = pLimitHigh;
	
					pLimitHigh = pLimitLow;
					pLimitLow = pTemp;
				}
			}
		}

		strXML += XML::MakeOpenXmlElementWithChildren( XML::enErrorLimit ); 

		if ( 0 != pLimitLow )
		{
			strXML += XML::MakeXmlElementNoChildren( XML::enFrom, pLimitLow->ToXML( ) );
		}

		if ( 0 != pLimitHigh )
		{
			strXML += XML::MakeXmlElementNoChildren( XML::enTo, pLimitHigh->ToXML( ) );
		}

		strXML += XML::MakeCloseXmlElementWithChildren( XML::enErrorLimit );
	}

	return strXML;
}

Atlas::AtlasRange& Atlas::AtlasRange::operator = ( const Atlas::AtlasRange& other )
{
	if ( this != &other )
	{
		GarbageCollect( );

		m_bContinuous = other.m_bContinuous;

		if ( 0 != other.m_pRange1 )
		{
			try
			{
				m_pRange1 = new Atlas::AtlasNumber( *( other.m_pRange1 ) );
			}
			catch ( ... )
			{
				throw Exception( Exception::eFailedToCreateNumberObject, __FILE__, __FUNCTION__, __LINE__ );
			}
		}

		if ( 0 != other.m_pRange2 )
		{
			try
			{
				m_pRange2 = new Atlas::AtlasNumber( *( other.m_pRange2 ) );
			}
			catch ( ... )
			{
				throw Exception( Exception::eFailedToCreateNumberObject, __FILE__, __FUNCTION__, __LINE__ );
			}
		}

		if ( 0 != other.m_pByValue )
		{
			try
			{
				m_pByValue = new Atlas::AtlasNumber( *( other.m_pByValue ) );
			}
			catch ( ... )
			{
				throw Exception( Exception::eFailedToCreateNumberObject, __FILE__, __FUNCTION__, __LINE__ );
			}
		}
	}

	return *this;
}

bool Atlas::AtlasRange::IsRange( void ) const
{
	bool bRange = false;

	if ( 0 != m_pRange1 )
	{
		bRange = true;
	}
	else if ( 0 != m_pRange2 )
	{
		bRange = true;
	}

	return bRange;
}

void Atlas::AtlasRange::SetRange1( Atlas::AtlasNumber* pNumber, const bool bTransferOwnership )
{
	if ( 0 != m_pRange1 )
	{
		delete m_pRange1;
		m_pRange1 = 0;
	}

	if ( bTransferOwnership )
	{
		m_pRange1 = pNumber;
	}
	else if ( 0 != pNumber )
	{
		try
		{
			m_pRange1 = new AtlasNumber( *( pNumber ) );
		}
		catch ( ... )
		{
			throw Exception( Exception::eFailedToCreateNumberObject, __FILE__, __FUNCTION__, __LINE__ );
		}
	}
}

void Atlas::AtlasRange::SetRange2( Atlas::AtlasNumber* pNumber, const bool bTransferOwnership )
{
	if ( 0 != m_pRange2 )
	{
		delete m_pRange2;
		m_pRange2 = 0;
	}

	if ( bTransferOwnership )
	{
		m_pRange2 = pNumber;
	}
	else if ( 0 != pNumber )
	{
		try
		{
			m_pRange2 = new AtlasNumber( *( pNumber ) );
		}
		catch ( ... )
		{
			throw Exception( Exception::eFailedToCreateNumberObject, __FILE__, __FUNCTION__, __LINE__ );
		}
	}
}

void Atlas::AtlasRange::SetByValue( Atlas::AtlasNumber* pNumber, const bool bTransferOwnership )
{
	if ( 0 != m_pByValue )
	{
		delete m_pByValue;
		m_pByValue = 0;
	}

	if ( bTransferOwnership )
	{
		m_pByValue = pNumber;
	}
	else if ( 0 != pNumber )
	{
		try
		{
			m_pByValue = new AtlasNumber( *( pNumber ) );
		}
		catch ( ... )
		{
			throw Exception( Exception::eFailedToCreateNumberObject, __FILE__, __FUNCTION__, __LINE__ );
		}
	}
}

void Atlas::AtlasRange::Init( void )
{
	m_pRange1 = 0;
	m_pRange2 = 0;
	m_pByValue = 0;
	m_bContinuous = false;
}

void Atlas::AtlasRange::GarbageCollect( void )
{
	if ( 0 != m_pRange1 )
	{
		delete m_pRange1;
		m_pRange1 = 0;
	}

	if ( 0 != m_pRange2 )
	{
		delete m_pRange2;
		m_pRange2 = 0;
	}

	if ( 0 != m_pByValue )
	{
		delete m_pByValue;
		m_pByValue = 0;
	}

	m_bContinuous = false;
}

void Atlas::AtlasRange::Merge( const AtlasRange& other )
{
	if ( this != &other )
	{
		if ( ( 0 != m_pRange1 ) && ( 0 != other.m_pRange1 ) )
		{
			m_pRange1->ReplaceIfSmaller( *( other.m_pRange1 ) );
		}
		else if ( 0 != other.m_pRange1 )
		{
			try
			{
				m_pRange1 = new AtlasNumber( *( other.m_pRange1 ) );
			}
			catch ( ... )
			{
				throw Exception( Exception::eFailedToCreateNumberObject, __FILE__, __FUNCTION__, __LINE__ );
			}
		}

		if ( ( 0 != m_pRange2 ) && ( 0 != other.m_pRange2 ) )
		{
			m_pRange2->ReplaceIfLarger( *( other.m_pRange2 ) );
		}
		else if ( 0 != other.m_pRange2 )
		{
			try
			{
				m_pRange2 = new AtlasNumber( *( other.m_pRange2 ) );
			}
			catch ( ... )
			{
				throw Exception( Exception::eFailedToCreateNumberObject, __FILE__, __FUNCTION__, __LINE__ );
			}
		}

		if ( ( 0 != m_pByValue ) && ( 0 != other.m_pByValue ) )
		{
			// -- TODO --
			// Not sure which should take precedence?
	
			#if ( _DEBUG ) && ( WIN32 )
				//DebugBreak( );
			#endif
		}
		else if ( 0 != other.m_pByValue )
		{
			try
			{
				m_pByValue = new AtlasNumber( *( other.m_pByValue ) );
			}
			catch ( ... )
			{
				throw Exception( Exception::eFailedToCreateNumberObject, __FILE__, __FUNCTION__, __LINE__ );
			}
		}

		if ( m_bContinuous != other.m_bContinuous )
		{
			// -- TODO --
			// Not sure which should take precedence?
	
			#if ( _DEBUG ) && ( WIN32 )
				//DebugBreak( );
			#endif
		}
	}
}

string Atlas::AtlasRange::ToXML( void ) const
{
	string strXML;

	if ( IsRange( ) )
	{
		strXML.reserve( 100 );
	
		if ( 0 != m_pRange1 )
		{
			strXML += XML::MakeXmlElementNoChildren( XML::enFrom, m_pRange1->ToXML( ) );
		}
	
		if ( 0 != m_pRange2 )
		{
			strXML += XML::MakeXmlElementNoChildren( XML::enTo, m_pRange2->ToXML( ) );
		}
	
		if ( 0 != m_pByValue )
		{
			strXML += XML::MakeXmlElementNoChildren( XML::enBy, m_pByValue->ToXML( ) );
		}
	
		if ( m_bContinuous )
		{
			strXML += XML::MakeXmlElementNoChildren( XML::enContinuous );
		}
	}

	return strXML;
}

Atlas::AtlasDeclare& Atlas::AtlasDeclare::operator = ( const Atlas::AtlasDeclare& other )
{
	if ( this != &other )
	{
		m_eDataType		= other.m_eDataType;
		m_eSubDataType	= other.m_eSubDataType;
		m_eDigialType	= other.m_eDigialType;
		m_uiAttributes	= other.m_uiAttributes;
		m_uiDataLength	= other.m_uiDataLength;
		m_uiListSize	= other.m_uiListSize;
		m_strVarName	= other.m_strVarName;
	}
	
	return *this;
}

bool Atlas::AtlasDeclare::IsValid( void ) const
{
	bool bIsValid = false;

	if ( !m_strVarName.empty( ) )
	{
		if ( eUnknownDataType != m_eDataType )
		{
			const unsigned int uiScope = ( IsGlobal( ) + IsExternal( ) + IsLocal( ) );

			if ( 1 == uiScope )
			{
				const bool bStore = IsStore( );
				const bool bList = IsList( );
	
				if ( bStore || bList )
				{
					if ( eDIGITAL == m_eDataType )
					{
						if ( eUnknownDataType != m_eDigialType )
						{
							bIsValid = true;
						}
					}
					else
					{
						bIsValid = true;
					}
	
					if ( bList && bIsValid )
					{
						bIsValid = false;
		
						if ( m_uiListSize > 0 )
						{
							if ( ( eCHAR == m_eSubDataType )
								|| ( eBIT == m_eSubDataType )
								|| ( eBITS == m_eSubDataType ) )
							{
								if ( m_uiDataLength > 0 )
								{
									bIsValid = true;
								}
							}
							else
							{
								bIsValid = true;
							}
						}
					}
				}
			}
		}
	}

	return bIsValid;
}

XML::AttributeValue Atlas::AtlasDeclare::GetDataTypeAttributeValue( const eDataType eType )
{
	XML::AttributeValue avDataType = XML::avUnknown;

	switch ( eType )
	{
		case eENUMERATION:
			avDataType = XML::avEnumeration;
			break;

		case eDECIMAL:
		case eLONG_DECIMAL:
			avDataType = XML::avDecimal;
			break;

		case eINTEGER:
		case eLONG_INTEGER:
			avDataType = XML::avInteger;
			break;

		case eMSGCHAR:
		case eCHAR:
			avDataType = XML::avChar;
			break;

		case eCONNECTION:
		case eCONN:
			avDataType = XML::avConnector;
			break;

		case eBIT:
			avDataType = XML::avBit;
			break;

		case eBITS:
			avDataType = XML::avBits;
			break;

		case eBOOLEAN:
			avDataType = XML::avBoolean;
			break;

		case eDIGITAL:
			avDataType = XML::avDigital;
			break;

		case eDIGITAL_BNR:
			avDataType = XML::avBinary;
			break;

		case eDIGITAL_B1C:
			avDataType = XML::avBinaryOnesComp;
			break;

		case eDIGITAL_B2C:
			avDataType = XML::avBinaryTwoComp;
			break;

		case eDIGITAL_BSM:
			avDataType = XML::avBinaryMagnitude;
			break;

		case eDIGITAL_BCD:
			avDataType = XML::avBinaryCodedDecimal;
			break;

		case eDIGITAL_SBCD:
			avDataType = XML::avBinaryCodedDecimalMagnitude;
			break;
	}

	return avDataType;
}

bool Atlas::AtlasDeclare::IsAtlasNumericDataType( void ) const
{
	bool bIsNumeric = false;

	switch ( m_eDataType )
	{
		case eDECIMAL:
		case eLONG_DECIMAL:
		case eINTEGER:
		case eLONG_INTEGER:
			bIsNumeric = true;
			break;
	}

	return bIsNumeric;
}

string Atlas::AtlasDeclare::ToXML( const unsigned int uiId, const unsigned int uiCommentId ) const
{
	string strXML;
	const XML::AttributeValue avDataType = GetDataTypeAttributeValue( m_eDataType );
	const XML::AttributeValue avSecondarDataType = GetDataTypeAttributeValue( m_eSubDataType );
	const XML::AttributeValue avDigitalType = GetDataTypeAttributeValue( m_eDigialType );

	strXML.reserve( 32 );

	if ( !m_strVarName.empty( ) )
	{
		strXML += XML::MakeXmlAttributeNameValue( XML::anName, m_strVarName );
	}
	
	if ( XML::avUnknown != avDataType )
	{
		strXML += XML::MakeXmlAttributeNameValue( XML::anType, avDataType );
	}

	if ( IsGlobal( ) )
	{
		strXML += XML::MakeXmlAttributeNameValue( XML::anScope, XML::avGlobal );
	}
	else if ( IsExternal( ) )
	{
		strXML += XML::MakeXmlAttributeNameValue( XML::anScope, XML::avExternal );
	}
	else if ( IsLocal( ) )
	{
		strXML += XML::MakeXmlAttributeNameValue( XML::anScope, XML::avLocal );
	}
	else if ( IsBuiltIn( ) )
	{
		strXML += XML::MakeXmlAttributeNameValue( XML::anScope, XML::avBuiltIn );
	}

	//	bool IsStore( void ) const { return ( eStore == ( m_uiAttributes & eStore ) ); }

	if ( IsList( ) )
	{
		strXML += XML::MakeXmlAttributeNameValue( XML::anList, XML::avTrue );

		if ( m_uiListSize > 0 )
		{
			strXML += XML::MakeXmlAttributeNameValue( XML::anListLength, m_uiListSize );
		}
	}

	//bool IsConstant( void ) const { return ( eConstant == ( m_uiAttributes & eConstant ) ); }

	if ( XML::avUnknown != avDigitalType )
	{
		strXML += XML::MakeXmlAttributeNameValue( XML::anDigitalFormat, avDigitalType );
	}

	if ( XML::avUnknown != avSecondarDataType )
	{
		strXML += XML::MakeXmlAttributeNameValue( XML::anSecondaryType, avSecondarDataType );
	}

	if ( m_uiDataLength > 0 )
	{
		strXML += XML::MakeXmlAttributeNameValue( XML::anDataLength, m_uiDataLength );
	}

	if ( IsVariable( ) )
	{
		strXML += XML::MakeXmlAttributeNameValue( XML::anVariable, XML::avTrue );
	}

	if ( uiId > 0 )
	{
		strXML += XML::MakeXmlAttributeNameValue( XML::anId, uiId );
	}

	if ( uiCommentId > 0 )
	{
		strXML += XML::MakeXmlAttributeNameValue( XML::anCommentRefId, uiCommentId );
	}

	return strXML;
}

Atlas::AtlasEvaluationStatement& Atlas::AtlasEvaluationStatement::operator = ( const Atlas::AtlasEvaluationStatement& other )
{
	if ( this != &other )
	{
		GarbageCollect( );

		if ( 0 != other.m_pField1 )
		{
			try
			{
				m_pField1 = new pair< eEvaluationFieldType, AtlasNumber >( *( other.m_pField1 ) );
			}
			catch ( ... )
			{
				throw Exception( Exception::eFailedToCreatePairObject, __FILE__, __FUNCTION__, __LINE__ );
			}
		}
	
		if ( 0 != other.m_pField2 )
		{
			try
			{
				m_pField2 = new pair< eEvaluationFieldType, AtlasNumber >( *( other.m_pField2 ) );
			}
			catch ( ... )
			{
				throw Exception( Exception::eFailedToCreatePairObject, __FILE__, __FUNCTION__, __LINE__ );
			}
		}

		if ( 0 != other.m_pField3 )
		{
			try
			{
				m_pField3 = new pair< eEvaluationFieldType, AtlasNumber >( *( other.m_pField3 ) );
			}
			catch ( ... )
			{
				throw Exception( Exception::eFailedToCreatePairObject, __FILE__, __FUNCTION__, __LINE__ );
			}
		}
	}

	return *this;
}

void Atlas::AtlasEvaluationStatement::SetField( const Atlas::eEvaluationFieldType eType, const Atlas::AtlasNumber& num, pair< Atlas::eEvaluationFieldType, Atlas::AtlasNumber >** ppField )
{
	if ( 0 == *ppField )
	{
		try
		{
			*ppField = new pair< eEvaluationFieldType, AtlasNumber >( make_pair( eType, num ) );
		}
		catch ( ... )
		{
			throw Exception( Exception::eFailedToCreatePairObject, __FILE__, __FUNCTION__, __LINE__ );
		}
	}
	else
	{
		( *ppField )->first = eType;
		( *ppField )->second = num;
	}
}

void Atlas::AtlasEvaluationStatement::RemoveField( pair< Atlas::eEvaluationFieldType, Atlas::AtlasNumber >** ppField )
{
	if ( 0 != *ppField )
	{
		delete *ppField;
		*ppField = 0;
	}
}

void Atlas::AtlasEvaluationStatement::GarbageCollect( void )
{
	if ( 0 != m_pField1 )
	{
		delete m_pField1;
		m_pField1 = 0;
	}

	if ( 0 != m_pField2 )
	{
		delete m_pField2;
		m_pField2 = 0;
	}

	if ( 0 != m_pField3 )
	{
		delete m_pField3;
		m_pField3 = 0;
	}
}

void Atlas::AtlasEvaluationStatement::Init( void )
{
	m_pField1 = 0;
	m_pField2 = 0;
	m_pField3 = 0;
}

string Atlas::AtlasEvaluationStatement::ToXML_EvaluationField( pair< Atlas::eEvaluationFieldType, Atlas::AtlasNumber >* pField ) const
{
	XML::AttributeValue avType = XML::avUnknown;

	switch ( pField->first )
	{
		case eNOM:
			avType = XML::avNominal;
			break;
		case eUL:
			avType = XML::avUpperLimit;
			break;
		case eLL:
			avType = XML::avLowerLimit;
			break;
		case eGT:
			avType = XML::avGreaterThan;
			break;
		case eLT:
			avType = XML::avLessThan;
			break;
		case eEQ:
			avType = XML::avEqual;
			break;
		case eNE:
			avType = XML::avNotEqual;
			break;
		case eLE:
			avType = XML::avLessThanEqual;
			break;
		case eGE:	
			avType = XML::avGreaterThanEqual;
			break;
	}

	return XML::MakeXmlElementNoChildren( XML::enEvaluation, XML::MakeXmlAttributeNameValue( XML::anEvalType, avType ), pField->second.ToXML( ) );
}

string Atlas::AtlasEvaluationStatement::ToXML( void ) const
{
	const bool bField1 = ( 0 != m_pField1 );
	const bool bField2 = ( 0 != m_pField2 );
	const bool bField3 = ( 0 != m_pField3 );
	const unsigned int iCount = ( bField1 + bField2 + bField3 );
	string strXML;

	if ( iCount > 0 )
	{
		strXML.reserve( strXML.capacity( ) * iCount );

		strXML += XML::MakeOpenXmlElementWithChildren( XML::enEvaluations );

		if ( bField1 )
		{
			strXML += ToXML_EvaluationField( m_pField1 );
		}
	
		if ( bField2 )
		{
			strXML += ToXML_EvaluationField( m_pField2 );
		}
	
		if ( 0 != bField3 )
		{
			strXML += ToXML_EvaluationField( m_pField3 );
		}

		strXML += XML::MakeCloseXmlElementWithChildren( XML::enEvaluations );
	}

	return strXML;
}

void Atlas::AtlasTerm::GarbageCollect( void )
{
	if ( 0 != m_pTerm )
	{
		delete m_pTerm;
		m_pTerm = 0;
	}

	if ( 0 != m_pSubscriptTerm )
	{
		delete m_pSubscriptTerm;
		m_pSubscriptTerm = 0;
	}
}

void Atlas::AtlasTerm::SetTerm( AtlasData* pTerm )
{
	if ( 0 != m_pTerm )
	{
		delete m_pTerm;
		m_pTerm = 0;
	}

	m_pTerm = pTerm;
}

void Atlas::AtlasTerm::SetTerm( const Atlas::AtlasTerm::eBuiltIn eBuiltin )
{
	if ( 0 != m_pTerm )
	{
		delete m_pTerm;
		m_pTerm = 0;
	}

	switch ( eBuiltin )
	{
		case eMaxTimeBuiltIn:
			try { m_pTerm = new Atlas::AtlasNumber; }
			catch ( ... ) { throw Exception( Exception::eFailedToCreateNumberObject, __FILE__, __FUNCTION__, __LINE__ ); }
			m_pTerm->SetVariableName( "MAX-TIME" );
			m_pTerm->SetBuiltInType( AtlasData::eMaxTime );
			break;

		case eGoBuiltIn:
			try { m_pTerm = new Atlas::AtlasData; }
			catch ( ... ) { throw Exception( Exception::eFailedToCreateAtlasVariableObject, __FILE__, __FUNCTION__, __LINE__ ); }
			m_pTerm->SetVariableName( "GO" );
			m_pTerm->SetBuiltInType( AtlasData::eGo );
			break;

		case eNoGoBuiltIn:
			try { m_pTerm = new Atlas::AtlasData; }
			catch ( ... ) { throw Exception( Exception::eFailedToCreateAtlasVariableObject, __FILE__, __FUNCTION__, __LINE__ ); }
			m_pTerm->SetVariableName( "NOGO" );
			m_pTerm->SetBuiltInType( AtlasData::eNoGo );
			break;

		case eLoBuiltIn:
			try { m_pTerm = new Atlas::AtlasData; }
			catch ( ... ) { throw Exception( Exception::eFailedToCreateAtlasVariableObject, __FILE__, __FUNCTION__, __LINE__ ); }
			m_pTerm->SetVariableName( "LO" );
			m_pTerm->SetBuiltInType( AtlasData::eLo );
			break;

		case eHiBuiltIn:
			try { m_pTerm = new Atlas::AtlasData; }
			catch ( ... ) { throw Exception( Exception::eFailedToCreateAtlasVariableObject, __FILE__, __FUNCTION__, __LINE__ ); }
			m_pTerm->SetVariableName( "HI" );
			m_pTerm->SetBuiltInType( AtlasData::eHi );
			break;

		case eTrueBuiltIn:
			try { m_pTerm = new Atlas::AtlasBool( true ); }
			catch ( ... ) { throw Exception( Exception::eFailedToCreateBoolObject, __FILE__, __FUNCTION__, __LINE__ ); }
			m_pTerm->SetVariableName( "TRUE" );
			m_pTerm->SetBuiltInType( AtlasData::eTrue );
			break;

		case eFalseBuiltIn:
			try { m_pTerm = new Atlas::AtlasBool( false ); }
			catch ( ... ) { throw Exception( Exception::eFailedToCreateBoolObject, __FILE__, __FUNCTION__, __LINE__ ); }
			m_pTerm->SetVariableName( "FALSE" );
			m_pTerm->SetBuiltInType( AtlasData::eFalse );
			break;
	}
}

Atlas::AtlasData* Atlas::AtlasTerm::GetTerm( const bool bTransferOwnership )
{
	AtlasData* pRet = m_pTerm;

	if ( bTransferOwnership )
	{
		m_pTerm = 0;
	}

	return pRet;
}

void Atlas::AtlasTerm::SetSubscriptTerm( AtlasData* pSubscriptTerm )
{
	if ( 0 != m_pSubscriptTerm )
	{
		delete m_pSubscriptTerm;
		m_pSubscriptTerm = 0;
	}

	m_pSubscriptTerm = pSubscriptTerm;
}

Atlas::AtlasData* Atlas::AtlasTerm::GetSubscriptTerm( const bool bTransferOwnership )
{
	AtlasData* pRet = m_pSubscriptTerm;

	if ( bTransferOwnership )
	{
		m_pSubscriptTerm = 0;
	}

	return pRet;
}

Atlas::AtlasTerm::eUnaryOperator Atlas::AtlasTerm::GetOperator( const string& strOperator )
{
	eUnaryOperator eOp = eUnknownUnaryOperator;

	if ( strOperator.size( ) > 0 )
	{
		if ( "NOT" == strOperator )
		{
			eOp = eNotOperator;
		}
	}

	return eOp;
}

Atlas::AtlasTerm::eBuiltIn Atlas::AtlasTerm::GetBuiltIn( const string& strBuiltIn )
{
	eBuiltIn eIn = eUnknownBuiltIn;

	if ( strBuiltIn.size( ) > 0 )
	{
		if ( "MAX-TIME" == strBuiltIn )
		{
			eIn = eMaxTimeBuiltIn;
		}
		else if ( "GO" == strBuiltIn )
		{
			eIn = eGoBuiltIn;
		}
		else if ( "NOGO" == strBuiltIn )
		{
			eIn = eNoGoBuiltIn;
		}
		else if ( "LO" == strBuiltIn )
		{
			eIn = eLoBuiltIn;
		}
		else if ( "HI" == strBuiltIn )
		{
			eIn = eHiBuiltIn;
		}
		else if ( "TRUE" == strBuiltIn )
		{
			eIn = eTrueBuiltIn;
		}
		else if ( "FALSE" == strBuiltIn )
		{
			eIn = eFalseBuiltIn;
		}
	}

	return eIn;
}

void Atlas::AtlasExpression::Init( void )
{
	m_pLeftExp = 0;
	m_pRightExp = 0;	
}

void Atlas::AtlasExpression::GarbageCollect( void )
{
	if ( 0 != m_pLeftExp )
	{
		delete m_pLeftExp;
		m_pLeftExp = 0;
	}

	if ( 0 != m_pRightExp )
	{
		delete m_pRightExp;
		m_pRightExp = 0;
	}
}

void Atlas::AtlasExpression::ToXML( string& strXML, const XML::ElementName eName, const string& strOperator ) const
{
	strXML += XML::MakeOpenXmlElementWithChildren( eName, strOperator );

	if ( 0 != m_pLeftExp )
	{
		if ( AtlasTerm::GetRawClassName( ) == typeid( *m_pLeftExp ).raw_name( ) )
		{
			m_pLeftExp->ToXML( strXML, XML::enLeft );
		}
		else
		{
			strXML += XML::MakeOpenXmlElementWithChildren( XML::enLeft );

			m_pLeftExp->ToXML( strXML, XML::enUnknown );

			strXML += XML::MakeCloseXmlElementWithChildren( XML::enLeft );
		}
	}

	if ( 0 != m_pRightExp )
	{
		if ( AtlasTerm::GetRawClassName( ) == typeid( *m_pRightExp ).raw_name( ) )
		{
			m_pRightExp->ToXML( strXML, XML::enRight );
		}
		else
		{
			strXML += XML::MakeOpenXmlElementWithChildren( XML::enRight );

			m_pRightExp->ToXML( strXML, XML::enUnknown );

			strXML += XML::MakeCloseXmlElementWithChildren( XML::enRight );
		}
	}

	strXML += XML::MakeCloseXmlElementWithChildren( eName );

	#if ( _DEBUG ) && ( WIN32 )
		if ( strOperator.empty( ) )
		{
			DebugBreak( );
		}
	
		if ( 0 == m_pLeftExp )
		{
			DebugBreak( );
		}
	
		if ( 0 == m_pRightExp )
		{
			DebugBreak( );
		}
	#endif

}

Atlas::AtlasArithmeticExpression::eMathOperator Atlas::AtlasArithmeticExpression::GetOperator( const string& strOperator )
{
	eMathOperator eOp = eUnknownMathOperator;
	const unsigned int uiSize = strOperator.size( );

	if ( 1 == uiSize )
	{
		switch ( strOperator[ 0 ] )
		{
			case '+':
				eOp = eAdditionMathOperator;
				break;

			case '-':
				eOp = eSubtraction;
				break;

			case '*':
				eOp = eMultiplication;
				break;

			case '/':
				eOp = eDivision;
				break;
		}
	}
	else if ( 2 == uiSize )
	{
		if ( ( '*' == strOperator[ 0 ] ) && ( '*' == strOperator[ 1 ] ) )
		{
			eOp = eExponentiation;
		}
	}

	return eOp;
}

Atlas::AtlasCompareExpression::eCompareOperator Atlas::AtlasCompareExpression::GetOperator( const string& strOperator )
{
	eCompareOperator eOp = eUnknownCompareOperator;
	const unsigned int uiSize = strOperator.size( );

	if ( 2 == uiSize )
	{
		if ( "GT" == strOperator )
		{
			eOp = eGreaterThanOperator;
		}
		else if ( "LT" == strOperator )
		{
			eOp = eLessThanOperator;
		}
		else if ( "EQ" == strOperator )
		{
			eOp = eEqualOperator;
		}
		else if ( "NE" == strOperator )
		{
			eOp = eNotEqualOperator;
		}
		else if ( "GE" == strOperator )
		{
			eOp = eGreaterThanEqualOperator;
		}
		else if ( "LE" == strOperator )
		{
			eOp = eLessThanEqualOperator;
		}
	}

	return eOp;
}

void Atlas::AtlasExpression::SetExp( AtlasTerm* pSourceExp, const bool bLeft )
{
	if ( bLeft )
	{
		if ( 0 != m_pLeftExp )
		{
			delete m_pLeftExp;
			m_pLeftExp = 0;
		}
	
		m_pLeftExp = pSourceExp;
	}
	else
	{
		if ( 0 != m_pRightExp )
		{
			delete m_pRightExp;
			m_pRightExp = 0;
		}
	
		m_pRightExp = pSourceExp;
	}
}

Atlas::AtlasBooleanExpression::eBooleanOperator Atlas::AtlasBooleanExpression::GetOperator( const string& strOperator )
{
	eBooleanOperator eOp = eUnknownLogicalOperator;

	if ( strOperator.size( ) > 0 )
	{
		if ( "AND" == strOperator )
		{
			eOp = eAndOperator;
		}
		else if ( "OR" == strOperator )
		{
			eOp = eOrOperator;
		}
		else if ( "XOR" == strOperator )
		{
			eOp = eXorOperator;
		}
	}

	return eOp;
}

void Atlas::AtlasBitwiseExpression::TransferBooleanExpression( Atlas::AtlasBooleanExpression& boolExpression )
{
	switch ( boolExpression.GetOperator( ) )
	{
		case AtlasBooleanExpression::eAndOperator:
			m_eBitwiseOperator = eAndOperator;
			break;

		case AtlasBooleanExpression::eOrOperator:
			m_eBitwiseOperator = eOrOperator;
			break;

		case AtlasBooleanExpression::eXorOperator:
			m_eBitwiseOperator = eXorOperator;
			break;
	}

	SetLeftExp( boolExpression.GetLeftExp( true ) );
	SetRightExp( boolExpression.GetRightExp( true ) );
}

Atlas::AtlasBitwiseExpression::eBitwiseOperator Atlas::AtlasBitwiseExpression::GetOperator( const string& strOperator )
{
	eBitwiseOperator eOp = eUnknownBitwiseOperator;

	if ( strOperator.size( ) > 0 )
	{
		if ( "AND" == strOperator )
		{
			eOp = eAndOperator;
		}
		else if ( "OR" == strOperator )
		{
			eOp = eOrOperator;
		}
		else if ( "XOR" == strOperator )
		{
			eOp = eXorOperator;
		}
		else if ( "NOT" == strOperator )
		{
			eOp = eNotOperator;
		}
		else if ( "SHIFT-LEFT" == strOperator )
		{
			eOp = eShiftLeftOperator;
		}
		else if ( "SHIFT-RIGHT" == strOperator )
		{
			eOp = eShiftRightOperator;
		}
		else if ( "ARITH-SHIFT-LEFT" == strOperator )
		{
			eOp = eArithShiftLeftOperator;
		}
		else if ( "ARITH-SHIFT-RIGHT" == strOperator )
		{
			eOp = eArithShiftRightOperator;
		}
		else if ( "ROTATE-LEFT" == strOperator )
		{
			eOp = eRotateLeftOperator;
		}
		else if ( "ROTATE-RIGHT" == strOperator )
		{
			eOp = eRotateRightOperator;
		}
	}

	return eOp;
}

void Atlas::AtlasLimitTerm::GarbageCollect( void )
{
	if ( 0 != m_pLimitNumber )
	{
		delete m_pLimitNumber;
		m_pLimitNumber = 0;
	}

	if ( 0 != m_pNominalLimit )
	{
		delete m_pNominalLimit;
		m_pNominalLimit = 0;
	}

	if ( 0 != m_pLowerLimit )
	{
		delete m_pLowerLimit;
		m_pLowerLimit = 0;
	}

	if ( 0 != m_pUpperLimit )
	{
		delete m_pUpperLimit;
		m_pUpperLimit = 0;
	}
}

void Atlas::AtlasLimitTerm::SetValue( AtlasTerm* pSource, AtlasTerm** ppTarget, const bool bTransferOwnership )
{
	if ( 0 == *ppTarget )
	{
		delete *ppTarget;
		*ppTarget = 0;
	}

	if ( bTransferOwnership )
	{
		*ppTarget = pSource;
	}
	else
	{
		try
		{
			*ppTarget = new AtlasTerm( *pSource );
		}
		catch ( ... )
		{
			throw Exception( Exception::eFailedToCreateLimitTermObject, __FILE__, __FUNCTION__, __LINE__ );
		}
	}
}

void Atlas::AtlasTerm::ToXML( string& strXML, const XML::ElementName eName ) const
{
	string strUnaryOp;

	if ( eUnknownUnaryOperator != m_eUnaryOperator )
	{
		switch ( m_eUnaryOperator )
		{
			case eNotOperator:
				strUnaryOp = XML::MakeXmlAttributeNameValue( XML::anUnaryOperator, XML::avNot );
				break;
		}
	}

	if ( 0 != m_pTerm )
	{
		if ( 0 != m_pSubscriptTerm )
		{
			strXML += XML::MakeOpenXmlElementWithChildren( eName, m_pTerm->ToXML( ), strUnaryOp );

			strXML += XML::MakeXmlElementNoChildren( XML::enIndex, m_pSubscriptTerm->ToXML( ) );

			strXML += XML::MakeCloseXmlElementWithChildren( eName );
		}
		else
		{
			strXML += XML::MakeXmlElementNoChildren( eName, m_pTerm->ToXML( ), strUnaryOp );
		}
	}
	#if ( _DEBUG ) && ( WIN32 )
	else
	{
		DebugBreak( );
	}
	#endif
}

string Atlas::AtlasTerm::GetAssignValue_XML(const XML::ElementName eName ) const
{
	string strXML;
	string strUnaryOp;

	if ( eUnknownUnaryOperator != m_eUnaryOperator )
	{
		switch ( m_eUnaryOperator )
		{
			case eNotOperator:
				strUnaryOp = XML::MakeXmlAttributeNameValue( XML::anUnaryOperator, XML::avNot );
				break;
		}
	}

	if ( 0 != m_pTerm )
	{
		if ( !m_pTerm->IsVariableName( ) )
		{
			string strSubscript;
			bool bGetAssign = true;
	
			if ( 0 != m_pSubscriptTerm )
			{
				if ( m_pSubscriptTerm->IsVariableName( ) )
				{
					bGetAssign = false;
				}
				else if ( 0 == dynamic_cast< const Atlas::AtlasNumber* >( m_pSubscriptTerm ) )
				{
					bGetAssign = false;
				}
				else
				{
					strSubscript = ( ( Atlas::AtlasNumber* ) m_pSubscriptTerm )->GetNumber( false );
				}
	
				if ( bGetAssign )
				{
					strXML += XML::MakeXmlElementNoChildren( eName, strSubscript, m_pTerm->ToXML( ), strUnaryOp );
				}
			}
			else
			{
				strXML += XML::MakeXmlElementNoChildren( eName, strSubscript, m_pTerm->ToXML( ), strUnaryOp );
			}
		}
	}
	#if ( _DEBUG ) && ( WIN32 )
	else
	{
		DebugBreak( );
	}
	#endif

	return strXML;
}

void Atlas::AtlasLimitTerm::ToXML( string& strXML, const XML::ElementName eName ) const
{
	const bool bLimitNumber = ( 0 != m_pLimitNumber );
	const bool bLowerLimit = ( 0 != m_pLowerLimit );
	const bool bUpperLimit = ( 0 != m_pUpperLimit );

	if ( bLimitNumber && bLowerLimit && bUpperLimit )
	{
		m_pLimitNumber->ToXML( strXML, XML::enLimit );

		if ( 0 != m_pNominalLimit )
		{
			m_pNominalLimit->ToXML( strXML, XML::enNominal );
		}

		m_pUpperLimit->ToXML( strXML, XML::enUpperLimit );

		m_pLowerLimit->ToXML( strXML, XML::enLowerLimit );
	}
	#if ( _DEBUG ) && ( WIN32 )
	else
	{
		DebugBreak( );
	}
	#endif
}

void Atlas::AtlasBooleanExpression::ToXML( string& strXML, const XML::ElementName eName ) const
{
	string strBooleanOp;

	switch ( m_eBooleanOperator )
	{
		case eAndOperator:
			strBooleanOp = XML::MakeXmlAttributeNameValue( XML::anOperator, XML::avAnd );
			break;

		case eOrOperator:
			strBooleanOp = XML::MakeXmlAttributeNameValue( XML::anOperator, XML::avOr );
			break;

		case eXorOperator:
			strBooleanOp = XML::MakeXmlAttributeNameValue( XML::anOperator, XML::avXor );
			break;
	}

	AtlasExpression::ToXML( strXML, ( XML::enUnknown == eName ? XML::enBoolean : eName ), strBooleanOp );
}

void Atlas::AtlasArithmeticExpression::ToXML( string& strXML, const XML::ElementName eName ) const
{
	string strArithOp;

	switch ( m_eMathOperator )
	{
		case eAdditionMathOperator:
			strArithOp = XML::MakeXmlAttributeNameValue( XML::anOperator, XML::avAddition );
			break;

		case eSubtraction:
			strArithOp = XML::MakeXmlAttributeNameValue( XML::anOperator, XML::avSubtraction );
			break;

		case eMultiplication:
			strArithOp = XML::MakeXmlAttributeNameValue( XML::anOperator, XML::avMultiplication );
			break;

		case eDivision:
			strArithOp = XML::MakeXmlAttributeNameValue( XML::anOperator, XML::avDivision );
			break;

		case eExponentiation:
			strArithOp = XML::MakeXmlAttributeNameValue( XML::anOperator, XML::avExponentiation );
			break;
	}

	AtlasExpression::ToXML( strXML, ( XML::enUnknown == eName ? XML::enArithmetic : eName ), strArithOp );
}

void Atlas::AtlasCompareExpression::ToXML( string& strXML, const XML::ElementName eName ) const
{
	string strCompareOp;

	switch ( m_eCompareOperator )
	{
		case eGreaterThanOperator:
			strCompareOp = XML::MakeXmlAttributeNameValue( XML::anOperator, XML::avGreaterThanOperator );
			break;

		case eLessThanOperator:
			strCompareOp = XML::MakeXmlAttributeNameValue( XML::anOperator, XML::avLessThanOperator );
			break;

		case eEqualOperator:
			strCompareOp = XML::MakeXmlAttributeNameValue( XML::anOperator, XML::avEqualOperator );
			break;

		case eNotEqualOperator:
			strCompareOp = XML::MakeXmlAttributeNameValue( XML::anOperator, XML::avNotEqualOperator );
			break;

		case eGreaterThanEqualOperator:
			strCompareOp = XML::MakeXmlAttributeNameValue( XML::anOperator, XML::avGreaterThanEqualOperator );
			break;

		case eLessThanEqualOperator:
			strCompareOp = XML::MakeXmlAttributeNameValue( XML::anOperator, XML::avLessThanEqualOperator );
			break;
	}

	AtlasExpression::ToXML( strXML, ( XML::enUnknown == eName ? XML::enCompare : eName ), strCompareOp );
}

void Atlas::AtlasBitwiseExpression::ToXML( string& strXML, const XML::ElementName eName ) const
{
	string strBitwiseOp;

	switch ( m_eBitwiseOperator )
	{
		case eAndOperator:
			strBitwiseOp = XML::MakeXmlAttributeNameValue( XML::anOperator, XML::avAnd );
			break;

		case eOrOperator:
			strBitwiseOp = XML::MakeXmlAttributeNameValue( XML::anOperator, XML::avOr );
			break;

		case eXorOperator:
			strBitwiseOp = XML::MakeXmlAttributeNameValue( XML::anOperator, XML::avXor );
			break;

		case eNotOperator:
			strBitwiseOp = XML::MakeXmlAttributeNameValue( XML::anOperator, XML::avNot );
			break;

		case eShiftLeftOperator:
			strBitwiseOp = XML::MakeXmlAttributeNameValue( XML::anOperator, XML::avShiftLeft );
			break;

		case eShiftRightOperator:
			strBitwiseOp = XML::MakeXmlAttributeNameValue( XML::anOperator, XML::avShiftRight );
			break;

		case eArithShiftLeftOperator:
			strBitwiseOp = XML::MakeXmlAttributeNameValue( XML::anOperator, XML::avArithShiftLeft );
			break;

		case eArithShiftRightOperator:
			strBitwiseOp = XML::MakeXmlAttributeNameValue( XML::anOperator, XML::avArithShiftRight );
			break;

		case eRotateLeftOperator:
			strBitwiseOp = XML::MakeXmlAttributeNameValue( XML::anOperator, XML::avRotateLeft );
			break;

		case eRotateRightOperator:
			strBitwiseOp = XML::MakeXmlAttributeNameValue( XML::anOperator, XML::avRotateRight );
			break;
	}

	AtlasExpression::ToXML( strXML, ( XML::enUnknown == eName ? XML::enBitwise : eName ), strBitwiseOp );
}

void Atlas::AtlasMathFunction::SetTerm( Atlas::AtlasTermBase* pTermBase )
{
	if ( 0 != m_pTermBase )
	{
		delete m_pTermBase;
	}

	m_pTermBase = pTermBase;
}

Atlas::AtlasTermBase* Atlas::AtlasMathFunction::GetTerm( const bool bTransferownership )
{
	AtlasTermBase* pRet = m_pTermBase;

	if ( bTransferownership )
	{
		m_pTermBase = 0;
	}

	return pRet;
}

void Atlas::AtlasMathFunction::ToXML( string& strXML, const XML::ElementName eName ) const
{
	string strMathFunc;

	switch( m_eFunction )
	{
		case eABS_Function:
			strMathFunc = XML::MakeXmlAttributeNameValue( XML::anFunction, XML::avABS_Function );
			break;

		case eALOG_Function:
			strMathFunc = XML::MakeXmlAttributeNameValue( XML::anFunction, XML::avALOG_Function );
			break;

		case eATAN_Function:
			strMathFunc = XML::MakeXmlAttributeNameValue( XML::anFunction, XML::avATAN_Function );
			break;

		case eCOS_Function:
			strMathFunc = XML::MakeXmlAttributeNameValue( XML::anFunction, XML::avCOS_Function );
			break;

		case eEXP_Function:
			strMathFunc = XML::MakeXmlAttributeNameValue( XML::anFunction, XML::avEXP_Function );
			break;

		case eINT_Function:
			strMathFunc = XML::MakeXmlAttributeNameValue( XML::anFunction, XML::avINT_Function );
			break;

		case eLN_Function:
			strMathFunc = XML::MakeXmlAttributeNameValue( XML::anFunction, XML::avLN_Function );
			break;

		case eLOG_Function:
			strMathFunc = XML::MakeXmlAttributeNameValue( XML::anFunction, XML::avLOG_Function );
			break;

		case eSIN_Function:
			strMathFunc = XML::MakeXmlAttributeNameValue( XML::anFunction, XML::avSIN_Function );
			break;

		case eSQRT_Function:
			strMathFunc = XML::MakeXmlAttributeNameValue( XML::anFunction, XML::avSQRT_Function );
			break;

		case eTAN_Function:
			strMathFunc = XML::MakeXmlAttributeNameValue( XML::anFunction, XML::avTAN_Function );
			break;
	}

	#if ( _DEBUG ) && ( WIN32 )
		if ( strMathFunc.empty( ) )
		{
			DebugBreak( );
		}
	#endif

	strXML += XML::MakeOpenXmlElementWithChildren( ( XML::enUnknown == eName ? XML::enArithmeticFunction : eName ), strMathFunc );

	if ( 0 != m_pTermBase )
	{
		if ( AtlasTerm::GetRawClassName( ) == typeid( *m_pTermBase ).raw_name( ) )
		{
			( ( AtlasTerm* ) m_pTermBase )->ToXML( strXML, XML::enArgument );
		}
		else
		{
			strXML += XML::MakeOpenXmlElementWithChildren( XML::enArgument );

			m_pTermBase->ToXML( strXML, XML::enUnknown );
			
			strXML += XML::MakeCloseXmlElementWithChildren( XML::enArgument );
		}
	}

	strXML += XML::MakeCloseXmlElementWithChildren( ( XML::enUnknown == eName ? XML::enArithmeticFunction : eName ) );
}

Atlas::AtlasMathFunction::eFunction Atlas::AtlasMathFunction::GetFunction( const string& strFunction )
{
	eFunction eFN = eUnknownFunction;

	if ( strFunction.size( ) > 0 )
	{
		if ( "ABS" == strFunction )
		{
			eFN = eABS_Function;
		}
		else if ( "ALOG" == strFunction )
		{
			eFN = eALOG_Function;
		}
		else if ( "ATAN" == strFunction )
		{
			eFN = eATAN_Function;
		}
		else if ( "COS" == strFunction )
		{
			eFN = eCOS_Function;
		}
		else if ( "EXP" == strFunction )
		{
			eFN = eEXP_Function;
		}
		else if ( "INT" == strFunction )
		{
			eFN = eINT_Function;
		}
		else if ( "LN" == strFunction )
		{
			eFN = eLN_Function;
		}
		else if ( "LOG" == strFunction )
		{
			eFN = eLOG_Function;
		}
		else if ( "SIN" == strFunction )
		{
			eFN = eSIN_Function;
		}
		else if ( "SQRT" == strFunction )
		{
			eFN = eSQRT_Function;
		}
		else if ( "TAN" == strFunction )
		{
			eFN = eTAN_Function;
		}
	}

	return eFN;
}

void Atlas::AtlasSourceStatement::SetStatementNumber( const string& strStatementNumber )
{ 
	m_strStatementNumber = strStatementNumber;

	const unsigned int uiLen = m_strStatementNumber.size( );

	switch ( uiLen )
	{
		case 0:
			m_strTestNumber.clear( );
			m_strStepNumber.clear( );
			m_bBeginTest = false;
			break;

		case 2:
			// This case should never happen.
			SetStepNumber( m_strStatementNumber );
			break;

		case 6:
			m_strTestNumber = m_strStatementNumber.substr( 0, 4 );
			SetStepNumber( m_strStatementNumber.substr( 4, 3 ) );
			break;

		default:
			#if ( _DEBUG ) && ( WIN32 )
				DebugBreak( );
			#endif
			break;
	}
}

void Atlas::AtlasSourceStatement::SetStepNumber( const string& strStepNumber )
{ 
	m_strStepNumber = strStepNumber;
	m_bBeginTest = false;

	if ( !m_strStepNumber.empty( ) )
	{
		static const string strFirstStep( "00" );

		if ( strFirstStep == m_strStepNumber )
		{
			m_bBeginTest = true;
		}
	}
}

XML::AttributeValue Atlas::AtlasSourceStatement::GetSourceTypeName( const eSourceType eType )
{
	XML::AttributeValue avType = XML::avUnknown;

	switch ( eType )
	{
		case eAtlasProgram:
			avType = XML::avProgram;
			break;

		case eAtlasModule:
			avType = XML::avModule;
			break;

		case eAtlasNonModule:
			avType = XML::avNonModule;
			break;

		case eAtlasSegment:
			avType = XML::avSegment;
			break;

		case eCassProgramLookup:
			avType = XML::avProgramLookup;
			break;

		case eCassModuleLookup:
			avType = XML::avModuleLookup;
			break;
	}

	return avType;
}

string Atlas::AtlasSourceStatement::ToXML( const unsigned int uiFields ) const
{
	const bool bAll = ( eXmlAll == ( uiFields & eXmlAll ) );
	string strVerb;
	string strFile;
	string strStatementNumber;
	string strLineNumber;
	string strId;
	string strCommentRefId;
	string strFileType;
	string strProcName;

	if ( bAll || ( eXmlAtlasStatement == ( uiFields & eXmlAtlasStatement ) ) )
	{
		strVerb = XML::MakeXmlAttributeNameValue( XML::anStatement, Atlas::GetAtlasStatement( m_eAtlasStatement ) );
	}

	if ( bAll || ( eXmlFilename == ( uiFields & eXmlFilename ) ) )
	{
		strFile = XML::MakeXmlAttributeNameValue( XML::anFile, m_strFilename );

		#if ( _DEBUG ) && ( WIN32 )
		{
			if ( strFile.empty( ) )
			{
				DebugBreak( );
			}
		}
		#endif
	}

	if ( bAll || ( eXmlStatementNumber == ( uiFields & eXmlStatementNumber ) ) )
	{
		strStatementNumber = XML::MakeXmlAttributeNameValue( XML::anStatementNumber, m_strStatementNumber );
	}

	if ( bAll || ( eXmlLineNumber == ( uiFields & eXmlLineNumber ) ) )
	{
		strLineNumber = XML::MakeXmlAttributeNameValue( XML::anLineNumber, m_uiLineNumber );

		#if ( _DEBUG ) && ( WIN32 )
		{
			if ( 0 == m_uiLineNumber )
			{
				DebugBreak( );
			}
		}
		#endif
	}

	if ( bAll || ( eXmlId == ( uiFields & eXmlId ) ) )
	{
		strId = XML::MakeXmlAttributeNameValue( XML::anId, m_uiId );

		#if ( _DEBUG ) && ( WIN32 )
		{
			if ( 0 == m_uiId )
			{
				DebugBreak( );
			}
		}
		#endif
	}

	if ( bAll || ( eXmlCommentId == ( uiFields & eXmlCommentId ) ) )
	{
		if ( 0 != m_uiCommentId )
		{
			strCommentRefId = XML::MakeXmlAttributeNameValue( XML::anCommentRefId, m_uiCommentId );
		}
	}

	if ( bAll || ( eXmlSourceType == ( uiFields & eXmlSourceType ) ) )
	{
		strFileType = XML::MakeXmlAttributeNameValue( XML::anFileType, GetSourceTypeName( ) );
	}

	if ( bAll || ( eXmlProcname == ( uiFields & eXmlProcname ) ) )
	{
		if ( !m_strParentProcname.empty( ) )
		{
			strProcName = XML::MakeXmlAttributeNameValue( XML::anProcedure, m_strParentProcname );
		}
	}

	return XML::MakeXmlElementNoChildren( XML::enAlasSource, strVerb, strFile, strStatementNumber, strLineNumber, strId, strFileType, strProcName, strCommentRefId );
}
