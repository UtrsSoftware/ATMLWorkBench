/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

#pragma once

#include <string>
#include <map>
#include <vector>
#include "exception.h"

using namespace std;

class CommandLine
{
public:

	enum eTEST_STATION
	{
		eUnknownTestStation = -1,
		eCASS,
		eHYBRID,
		eRTCASS,
		eECASS
	};

	enum ePRINT_CONSOLE
	{
		eInformation		= 0x0000,
		eError				= 0x0001,
		eHtml				= 0x0002,
		eBold				= 0x0004,
		eNoEncoding			= 0x0008,
		eNoSearchReplace	= 0x0010
	};

	CommandLine( );

	bool Init( const unsigned int iArgCount, const char* arrayArgs[ ] );
	void Clear( void );

	bool Help( void ) const { return m_bHelp; }
	bool AST( void ) const { return m_bAST; }
	bool Debug( void ) const { return m_bDebug; }
	bool ConsoleHTML( void ) const { return m_bConsoleHTML; }
	bool ProcedureCallHierarchyXML( void ) const { return m_bProcedureCallHierarchyXML; }
	bool UnusedProcXML( void ) const { return m_bUnusedProcXML; }
	bool IEEE1641XML( void ) const { return m_bIEEE1641XML; }
	bool IEEE260_1XML( void ) const { return m_bIEEE260_1XML; }
	static bool ConsoleHTML( const unsigned int argc, const char* argv[ ] );
	eTEST_STATION GetTestStation( void ) const				{ return m_eTestStation; }
	const vector< string >& GetInputFilenames( void ) const	{ return m_vectInputFilenames; }
	const string& GetPrimaryFilename( const bool bExtension ) const { return ( bExtension ? m_strPrimaryFilenameWithExt : m_strPrimaryFilename ); }
	const string& GetPrimaryFilenameExtension( void ) const { return m_strPrimaryFilenameExt; }
	const string& GetInputFilenamesAsABF( void ) const		{ return m_InputFilenamesAsABF; }
	const string& GetOutputFilename( const bool bIncludePath ) const { return bIncludePath ? m_strFullOutputFilename : m_strOutputFilename; }
	const string& GetProcHierOutputFilename( const bool bIncludePath ) const { return bIncludePath ? m_strFullProcHierOutputFilename : m_strProcHierOutputFilename; }
	const string& GetOutputDirectory( void ) const			{ return m_strOutputDirectory; }
	const string& GetInputDirectory( void ) const			{ return m_strInputDirectory; }
	const string& GetProjectName( void ) const				{ return m_strProjectName; }
	const string& GetUUTName( void ) const					{ return m_strUUTName; }
	const string& GetUUTId( void ) const					{ return m_strUUTId; }
	const string& GetASTFilename( void ) const				{ return m_strASTFilename; }
	const string& GetDebugFilename( void ) const			{ return m_strDebugFilename; }
	static const string& GetHelp( const bool bHtml )		{ return bHtml ? m_strCommandLineHelpHtml : m_strCommandLineHelp; }

	Exception::eErrorType GetError( void ) const { return m_excep.GetError( ); }
	string GetErrorText( const bool bIncludeCallInfo ) const { return m_excep.GetErrorText( bIncludeCallInfo ); }

	static void PrintConsole( const unsigned int uiPrintFlags /* bit field of "ePRINT_CONSOLE" */, const char* format, ... );
	static void PrintConsole( const unsigned int uiPrintFlags /* bit field of "ePRINT_CONSOLE" */, const char* format, const va_list& argptr );

protected:

	enum eSWITCH_TYPE
	{
		eUknownSwitchType = -1,

		// There is a specific order, the display on the 
		// console order (it can be changed). Other then 
		// "eUknownSwitchType", don't give specific enum 
		// values, let the compiler do it.

		eInputFilenames,
		eInputDirectory,
		eOutputDirectory,
		eTestStation,
		eProjectName,
		eUUTName,
		eUUTId,
		eConsoleHTML,
		eCallHeir,
		eUnusedProc,
		eIEEE1641XML,
		eIEEE260_1XML,
		eAST,
		eDebug,
		eHelp	// Help should always be last, can't be moved.
	};

	static pair< eSWITCH_TYPE, string > GetSwitchType( const string& strSwitch );
	void SetInstanceData( void );
	static bool Yes( const string strCLSwitch );
	static bool No( const string strCLSwitch );

	bool m_bHelp;
	bool m_bAST;
	bool m_bDebug;
	bool m_bConsoleHTML;
	bool m_bProcedureCallHierarchyXML;
	bool m_bUnusedProcXML;
	bool m_bIEEE1641XML;
	bool m_bIEEE260_1XML;
	eTEST_STATION m_eTestStation;
	vector< string > m_vectInputFilenames;
	string m_strProjectName;
	string m_strOutputFilename;
	string m_strFullOutputFilename;
	string m_strProcHierOutputFilename;
	string m_strFullProcHierOutputFilename;
	string m_strOutputDirectory;
	string m_strInputDirectory;
	string m_InputFilenamesAsABF;
	string m_strPrimaryFilenameWithExt;
	string m_strPrimaryFilename;
	string m_strPrimaryFilenameExt;
	string m_strUUTName;
	string m_strUUTId;
	string m_strASTFilename;
	string m_strDebugFilename;
	Exception m_excep;

	static string InitStatics( void );

	static map< string, pair< eSWITCH_TYPE, string > > m_mapSwitches;
	static const string m_strDirectoryDelim;
	static const string m_strHelpSwitch;
	static string m_strCommandLineHelp;
	static string m_strCommandLineHelpHtml;
};
