/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

#include <iostream>
#include <set>
#include <fstream>
#include <stdarg.h>
#include "CommandLine.h"
#include "xml.h"
#include "helper.h"

#if ( _DEBUG ) && ( WIN32 )
	#define WINVER 0x0600
	#include <afx.h>
	#define new DEBUG_NEW
	#undef THIS_FILE
	static char BASED_CODE THIS_FILE[ ] = __FILE__;
#endif																						 

map< string, pair< CommandLine::eSWITCH_TYPE, string > > CommandLine::m_mapSwitches;
string CommandLine::m_strCommandLineHelp;
string CommandLine::m_strCommandLineHelpHtml;
const string CommandLine::m_strHelpSwitch( "/?" );
const string CommandLine::m_strDirectoryDelim = InitStatics( ); // Keeps this last

string CommandLine::InitStatics( void )
{
	m_mapSwitches.insert( make_pair( "test_station=",		
		make_pair( eTestStation, 
		"Test station name (CASS, HYBRID, RTCASS, ECASS)." ) ) );
	m_mapSwitches.insert( make_pair( "uut_name=",			
		make_pair( eUUTName, 
		"Unit Under Test name." ) ) );
	m_mapSwitches.insert( make_pair( "uut_id=",				
		make_pair( eUUTId, 
		"Unit Under Test ID (usually a GUID)." ) ) );
	m_mapSwitches.insert( make_pair( "project_name=",		
		make_pair( eProjectName, 
		"TPS project name." ) ) );
	m_mapSwitches.insert( make_pair( "output_directory=",	
		make_pair( eOutputDirectory, 
		"Directory/folder location to create AIXML file(s)." ) ) );
	m_mapSwitches.insert( make_pair( "input_directory=",	
		make_pair( eInputDirectory, 
		"Directory/folder location for Atlas source files." ) ) );
	m_mapSwitches.insert( make_pair( "input_files=",		
		make_pair( eInputFilenames, 
		"Primary Atlas source file or for segmented Atlas sources, Atlas segment names in proper order (separated by a comma)." ) ) );
	m_mapSwitches.insert( make_pair( "console_html=",		
		make_pair( eConsoleHTML, 
		"Should the console output contain HTML tags (yes/no, default no)." ) ) );
	m_mapSwitches.insert( make_pair( "proc_hier=",
		make_pair( eCallHeir, 
		"Should the Procedure Call Hierarchy AIXML file be created (yes/no, default no)." ) ) );
	m_mapSwitches.insert( make_pair( "unused_proc=",
		make_pair( eUnusedProc, 
		"Should unused Atlas procedures and all their associated statements be included in the XML (yes/no, default no)." ) ) );
	m_mapSwitches.insert( make_pair( "ieee1641=",
		make_pair( eIEEE1641XML,
		"Should IEEE 1641 signal information be included in the XML (yes/no, default yes)." ) ) );
	m_mapSwitches.insert( make_pair( "ieee260.1=",
		make_pair( eIEEE260_1XML,
		"Should IEEE 260.1 Units of Measure be used instead of Atlas Units of Measure (yes/no, default yes)." ) ) );
	m_mapSwitches.insert( make_pair( "ast=",
		make_pair( eAST, 
		"Create an abstract syntax tree as a XML file in the output directory (yes/no, default no, project name.ast.xml)." ) ) );
	m_mapSwitches.insert( make_pair( "debug=",				
		make_pair( eDebug, 
		"Create a parser debug file in the output directory (yes/no, default no, project name.debug.txt)." ) ) );
	m_mapSwitches.insert( make_pair( m_strHelpSwitch,
		make_pair( eHelp, 
		"This help." ) ) );

	map< string, pair< eSWITCH_TYPE, string > >::const_iterator it;
	const map< string, pair< eSWITCH_TYPE, string > >::const_iterator itEnd = m_mapSwitches.end( );

	m_strCommandLineHelp = "Command Line Help\n\n";
	m_strCommandLineHelpHtml = "<b>Command Line Help</b><br/><br/>\n\n";

	for ( int i = ( eUknownSwitchType + 1 ); i <= eHelp; ++i )
	{
		it = m_mapSwitches.begin( );

		while ( itEnd != it )
		{
			if ( i == it->second.first )
			{
				m_strCommandLineHelp += it->first;
				m_strCommandLineHelp += "\n   ";
				m_strCommandLineHelp += it->second.second;

				m_strCommandLineHelpHtml += "<b>";
				m_strCommandLineHelpHtml += it->first;
				m_strCommandLineHelpHtml += "</b>";
				m_strCommandLineHelpHtml += "<br/>\n&nbsp;&nbsp;&nbsp;";
				m_strCommandLineHelpHtml += it->second.second;

				break;
			}

			++it;
		}

		m_strCommandLineHelp += "\n";
		m_strCommandLineHelpHtml += "<br/>\n";
	}

	m_strCommandLineHelp += "\n";
	m_strCommandLineHelpHtml += "<br/>\n";
  
	return string( "\\" );
}

CommandLine::CommandLine( )
{ 
	Clear( );
}

void CommandLine::Clear( void )
{
	m_bAST = false;
	m_bHelp = false;
	m_bDebug = false;
	m_bConsoleHTML = false;
	m_bProcedureCallHierarchyXML = false;
	m_bUnusedProcXML = false;
	m_bIEEE1641XML = true;
	m_bIEEE260_1XML = true;
	m_eTestStation = eUnknownTestStation;

	m_strProjectName.clear( );
	m_strOutputFilename.clear( );
	m_strFullOutputFilename.clear( );
	m_strProcHierOutputFilename.clear( );
	m_strFullProcHierOutputFilename.clear( );
	m_strOutputDirectory.clear( );
	m_strInputDirectory.clear( );
	m_InputFilenamesAsABF.clear( );
	m_strPrimaryFilenameWithExt.clear( );
	m_strPrimaryFilename.clear( );
	m_strPrimaryFilenameExt.clear( );
	m_strUUTName.clear( );
	m_strUUTId.clear( );
	m_strASTFilename.clear( );
	m_strDebugFilename.clear( );
	m_vectInputFilenames.clear( );
	m_excep.Clear( );
}

bool CommandLine::Init( const unsigned int iArgCount, const char* arrayArgs[ ] )
{
	bool bRet = false;

	Clear( );

	try
	{
		set< eSWITCH_TYPE > setSwitches;

		if  ( iArgCount > m_mapSwitches.size( ) ) 
		{
			throw Exception( Exception::eInvalidCommandLineArguments, __FILE__, __FUNCTION__, __LINE__ );
		}
			
		if  ( 0 == arrayArgs )
		{
			throw Exception( Exception::eInvalidCommandLineArgmentsArray, __FILE__, __FUNCTION__, __LINE__ );
		}

		if ( iArgCount <= 2 )
		{
			if  ( 1 == iArgCount )
			{
				m_bHelp = true;
			}
			else if ( string( m_strHelpSwitch ) == arrayArgs[ 1 ] )
			{
				m_bHelp = true;
			}
		}

		if ( !m_bHelp )
		{
			for ( unsigned int ui = 1; ui < iArgCount; ++ui )
			{
				const pair< eSWITCH_TYPE, string > pr = GetSwitchType( arrayArgs[ ui ] );
	
				if ( eUknownSwitchType == pr.first )
				{
					throw Exception( Exception::eUnknownCommandLineSwitch, __FILE__, __FUNCTION__, __LINE__, arrayArgs[ ui ] );
				}
	
				if ( setSwitches.end( ) != setSwitches.find( pr.first ) )
				{
					throw Exception( Exception::eDuplicateCommandLineSwitch, __FILE__, __FUNCTION__, __LINE__, arrayArgs[ ui ] );
				}
	
				setSwitches.insert( pr.first );

				switch ( pr.first )
				{
					case eTestStation:
						{
							const string strStation( AIXMLHelper::ToUpper( pr.second ) );

							if ( "CASS" == strStation )
							{
								m_eTestStation = eCASS;
							}
							else if ( "HYBRID" == strStation )
							{
								m_eTestStation = eHYBRID;
							}
							else if ( "RTCASS" == strStation )
							{
								m_eTestStation = eRTCASS;
							}
							else if ( "ECASS" == strStation )
							{
								m_eTestStation = eECASS;
							}
						}
						break;
	
					case eUUTName:
						m_strUUTName = pr.second;
						break;
	
					case eUUTId:
						m_strUUTId = pr.second;
						break;
	
					case eProjectName:
						m_strProjectName = pr.second;
						break;
	
					case eOutputDirectory:
						m_strOutputDirectory = pr.second;
						if ( !m_strOutputDirectory.empty( ) )
						{
							if ( !AIXMLHelper::EndsWith( m_strOutputDirectory, m_strDirectoryDelim ) )
							{
								m_strOutputDirectory += m_strDirectoryDelim;
							}
						}
						break;
	
					case eInputDirectory:
						m_strInputDirectory = pr.second;
						if ( !m_strInputDirectory.empty( ) )
						{
							if ( !AIXMLHelper::EndsWith( m_strInputDirectory, m_strDirectoryDelim ) )
							{
								m_strInputDirectory += m_strDirectoryDelim;
							}
						}
						break;
	
					case eInputFilenames:
						if ( !pr.second.empty( ) )
						{
							m_vectInputFilenames = AIXMLHelper::SplitString< string >( pr.second, "," );
						}
						break;
	
					case eCallHeir:
						if ( Yes( pr.second ) )
						{
							m_bProcedureCallHierarchyXML = true;
						}
						break;

					case eUnusedProc:
						if ( Yes( pr.second ) )
						{
							m_bUnusedProcXML = true;
						}
						break;

					case eIEEE1641XML:
						if ( No( pr.second ) )
						{
							m_bIEEE1641XML = false;
						}
						break;

					case eIEEE260_1XML:
						if ( No( pr.second ) )
						{
							m_bIEEE260_1XML = false;
						}
						break;
		
					case eAST:
						if ( Yes( pr.second ) )
						{
							m_bAST = true;
						}
						break;
		
					case eDebug:
						if ( Yes( pr.second ) )
						{
							m_bDebug = true;
						}
						break;
		
					case eHelp:
						m_bHelp = true;
						break;
				}

				if ( m_bHelp )
				{
					break;
				}
			}
		}

		if ( !m_bHelp )
		{
			////////////////////////////////////
	
			if ( 0 == m_strProjectName.size( ) )
			{
				throw Exception( Exception::eInvalidProjectName, __FILE__, __FUNCTION__, __LINE__ );
			}
	
			////////////////////////////////////

			m_strOutputFilename = m_strProjectName;
			m_strOutputFilename += ".aixml.xml";
	
			m_strFullOutputFilename = m_strOutputDirectory;
			m_strFullOutputFilename += m_strOutputFilename;
			ofstream xmlOutFile( m_strFullOutputFilename.c_str( ) );
			if ( !xmlOutFile.is_open( ) )
			{
				throw Exception( Exception::eCannotOpenOutputAIXMLFile, __FILE__, __FUNCTION__, __LINE__ );
			}
			xmlOutFile.close( );
			
			////////////////////////////////////

			////////////////////////////////////

			m_strProcHierOutputFilename = m_strProjectName;
			m_strProcHierOutputFilename += ".proc_hier.aixml.xml";
	
			m_strFullProcHierOutputFilename = m_strOutputDirectory;
			m_strFullProcHierOutputFilename += m_strProcHierOutputFilename;

			if ( m_bProcedureCallHierarchyXML )
			{
				ofstream xmlProcHierOutFile( m_strFullProcHierOutputFilename.c_str( ) );
				if ( !xmlProcHierOutFile.is_open( ) )
				{
					throw Exception( Exception::eCannotOpenOutputAIXMLFile, __FILE__, __FUNCTION__, __LINE__ );
				}
				xmlProcHierOutFile.close( );
			}
			
			////////////////////////////////////

			const unsigned int uiInputFilenames = m_vectInputFilenames.size( );
			if ( 0 == uiInputFilenames )
			{
				throw Exception( Exception::eInvalidInputAtlasFilename, __FILE__, __FUNCTION__, __LINE__ );
			}
			string strInputDirectory( m_strInputDirectory );
			for ( unsigned int ui = 0; ui < uiInputFilenames; ++ui )
			{
				string strTemp( m_vectInputFilenames[ ui ] );
	
				if ( !strInputDirectory.empty( ) )
				{
					strTemp.insert( 0, strInputDirectory );
				}
	
				ifstream aixmlFile( strTemp.c_str( ) );
		
				if ( !aixmlFile.is_open( ) )
				{
					throw Exception( Exception::eCannotOpenInputAtlasSourceFile, __FILE__, __FUNCTION__, __LINE__, AIXMLHelper::StripPath( strTemp ) );
				}
		
				aixmlFile.close( );
			}
	
			////////////////////////////////////
	
			if ( 0 == m_strUUTName.length( ) )
			{
				throw Exception( Exception::eInvalidUUTName, __FILE__, __FUNCTION__, __LINE__ );
			}
	
			////////////////////////////////////
	
			if ( 0 == m_strUUTId.length( ) )
			{
				throw Exception( Exception::eInvalidUUTId, __FILE__, __FUNCTION__, __LINE__ );
			}
	
			////////////////////////////////////
	
			if ( eUnknownTestStation == m_eTestStation )
			{
				throw Exception( Exception::eInvalidTestStation, __FILE__, __FUNCTION__, __LINE__ );
			}
	
			SetInstanceData( );
	
			bRet = true;
		}
	}
	catch( const Exception& e )
	{
		m_excep = e;
	}

	return bRet;
}

pair< CommandLine::eSWITCH_TYPE, string > CommandLine::GetSwitchType( const string& strSwitch )
{
	pair< CommandLine::eSWITCH_TYPE, string > prRet( eUknownSwitchType, string( ) );
	string::size_type stPos = strSwitch.find( "=" );

	if ( string::npos != stPos )
	{
		const string strLeft( AIXMLHelper::ToLower( strSwitch.substr( 0, stPos + 1 ) ) );

		if ( !strLeft.empty( ) )
		{
			const map< string, pair< eSWITCH_TYPE, string > >::const_iterator it = m_mapSwitches.find( strLeft );
	
			if ( m_mapSwitches.end( ) != it )
			{
				prRet.first = it->second.first;
				prRet.second = strSwitch.substr( stPos + 1 );
				AIXMLHelper::Trim( prRet.second );
			}
		}
	}
	else if ( strSwitch == m_strHelpSwitch )
	{
		prRet.first = eHelp;
	}

	return prRet;
}

void CommandLine::SetInstanceData( void )
{
	const unsigned int uiInputFilenames = m_vectInputFilenames.size( );

	if ( uiInputFilenames > 0 )
	{
		if ( uiInputFilenames > 1 )
		{
			for ( unsigned int ui = 0; ui < uiInputFilenames; ++ui )
			{
				if ( !m_InputFilenamesAsABF.empty( ) )
				{
					m_InputFilenamesAsABF += "\n";
				}
		
				m_InputFilenamesAsABF += m_vectInputFilenames[ ui ];
			}
		}

		m_strPrimaryFilenameWithExt = m_vectInputFilenames[ 0 ];
		m_strPrimaryFilename = m_strPrimaryFilenameWithExt;

		const string::size_type st = m_strPrimaryFilename.find_last_of( "." );

		if ( st != string::npos )
		{
			m_strPrimaryFilename = m_strPrimaryFilename.substr( 0, st );
			m_strPrimaryFilenameExt = m_strPrimaryFilenameWithExt.substr( st );
		}
	}

	m_strASTFilename = GetOutputDirectory( );
	m_strASTFilename += GetPrimaryFilename( false );
	m_strASTFilename += ".ast.xml";

	m_strDebugFilename = GetOutputDirectory( );
	m_strDebugFilename += GetPrimaryFilename( false );
	m_strDebugFilename += ".debug.txt";
}

bool CommandLine::ConsoleHTML( const unsigned int iArgCount, const char* arrayArgs[ ] )
{
	bool bConsoleHTML = false;

	for ( unsigned int ui = 1; ui < iArgCount; ++ui )
	{
		const pair< eSWITCH_TYPE, string > pr = GetSwitchType( arrayArgs[ ui ] );

		if ( eConsoleHTML == pr.first )
		{
			if ( Yes( pr.second ) )
			{
				bConsoleHTML = true;
			}
		}
	}

	return bConsoleHTML;
}

void CommandLine::PrintConsole( const unsigned int uiPrintFlags, const char* format, ... ) 
{
	va_list argptr;
	
	va_start( argptr, format );

	PrintConsole( uiPrintFlags, format, argptr );

	va_end( argptr );
}

void CommandLine::PrintConsole( const unsigned int uiPrintFlags /* bit field of "ePRINT_CONSOLE" */, const char* format, const va_list& argptr )
{
	char* pBuff = 0;

	try
	{
		const bool bHtml = ( eHtml == ( uiPrintFlags & eHtml ) );
		const bool bError = ( eError == ( uiPrintFlags & eError ) );
		const bool bBold = ( eBold == ( uiPrintFlags & eBold ) );
		const bool bNoEncoding = ( eNoEncoding == ( uiPrintFlags & eNoEncoding ) );
		const bool bNoSearchReplace = ( eNoSearchReplace == ( uiPrintFlags & eNoSearchReplace ) );
		
		int iMaxLength = vsnprintf( 0, 0, format, argptr );
	
		if ( iMaxLength > 0 )
		{
			pBuff = new char[ iMaxLength + 1 ];
	
			pBuff[ iMaxLength ] = 0;
	
			iMaxLength = vsnprintf( pBuff, iMaxLength, format, argptr );
		}
	
		if ( 0 != pBuff )
		{
			if ( bHtml )
			{
				string strXlated;
					
				if ( bNoEncoding )
				{
					strXlated = pBuff;
				}
				else
				{
					strXlated = XML::TranslateToXmlEncodings( pBuff );
				}
	
				if ( bBold )
				{
					strXlated.insert( 0, "<b>" );
					strXlated += "</b>";
				}
	
				if ( bError )
				{
					strXlated.insert( 0, "<span style=\"color:red; font-weight:bold; \">" );
					strXlated += "</span>";
				}

				if ( !bNoSearchReplace )
				{
					strXlated = AIXMLHelper::SearchAndReplace< string >( strXlated, "\n", "<br/>\n" );
				}
	
				printf( strXlated.c_str( ) );
			}
			else
			{
				printf( pBuff );
			}
		}
	}
	catch( ... )
	{
	}

	if ( 0 != pBuff )
	{
		delete [ ] pBuff;
	}
}

bool CommandLine::Yes( const string strCLSwitch )
{
	const string strSwitch( AIXMLHelper::ToUpper( strCLSwitch ) );

	return ( ( "YES" == strSwitch ) || ( "Y" == strSwitch ) || ( "1" == strSwitch ) );
}

bool CommandLine::No( const string strCLSwitch )
{
	const string strSwitch( AIXMLHelper::ToUpper( strCLSwitch ) );

	return ( ( "NO" == strSwitch ) || ( "N" == strSwitch ) || ( "0" == strSwitch ) );
}