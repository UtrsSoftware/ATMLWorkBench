/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

#include <stdio.h>
#include <fcntl.h>
#include <io.h>
#include <direct.h>
#include <time.h>
#include <stdarg.h>
#include "atlas_main.h"    
#include "parser.h"    
#include "aixml/CommandLine.h"
#include "aixml/aixml.h"

#if ( _DEBUG ) && ( WIN32 )
	#include <conio.h>

	#define WINVER 0x0600
	#include <afx.h>
	#define new DEBUG_NEW
	#undef THIS_FILE
	static char BASED_CODE THIS_FILE[ ] = __FILE__;
#endif																						 

#define EOL_CHAR 10	// End of line marker.
#define EOF_CHAR 26	// End of file marker.

// Begin - Version/Build Info (externs)
// 
// NOTE: When updating major/minor, build num, or copy right year values, 
// also update the Windows resource file (atlas.rc)
//
const unsigned char* build_date		= ( unsigned char* ) "3:00pm Friday, July 17th, 2015";
const unsigned char* major_version	= ( unsigned char* ) "1";
const unsigned char* minor_version	= ( unsigned char* ) "0";
const unsigned char* build_num		= ( unsigned char* ) "713";
const unsigned char* copyright_year	= ( unsigned char* ) "2015";
// End - Version/Build Info

// File scope
unsigned char deb_output[ 256 ]			= { 0 };
bool bFilesBeginTable					= false;
const char* pBeginTable					= "<table border=\"0\" cellpadding=\"0\">\n";
const char* pTableHeader				= "<tr><th colspan=\"2\" style=\"text-align: left;\">%s</th></tr>\n";
const char* pTableRow					= "<tr><td style=\"min-width: 60px; vertical-align: top; text-align: right; padding:0px 8px 0px 0px;\">%s</td><td>%s</td></tr>\n";
const char* pEndTable					= "</table>\n";
int n_errs								= 0;
int n_stmts								= 0;
int n_unkn								= 0;
unsigned int aixml_return_code			= 0;
// End file scope

// Externs
unsigned char primary_filename[ 256 ]	= { 0 };
unsigned int return_code				= 0;
// End Externs

// Class statics
int cOption::comments		= 1;
int cOption::console_html	= 0;
int cOption::debug			= 0; // 0, 1, or 2 (2-add node action text to the console)
int cOption::echo			= 0;
int cOption::exp			= 0;
int cOption::id				= 1;
int cOption::include		= 1;
int cOption::numel			= 1;
int cOption::lookup			= 1;
int cOption::spacing		= 1;
int cOption::xmlfile		= 0;

unsigned char*	cInput::input_start;		// First byte of include area.
unsigned char*	cInput::input_end;			// Byte after input.
unsigned char	cInput::dir[ 256 ];			// Directory of include file.
unsigned char	cInput::path[ 256 ];		// Path of include file.
unsigned char	cInput::filename[ 256 ];	// Filename of include file.
unsigned char	cInput::filetype[ 64 ];		// Filetype of include file.
unsigned char	cInput::filename_ext[ 256 ];
int				cInput::filedesc;		 
int				cInput::filesize;
int				cInput::lookupon;
int				cInput::segmenton;
int				cInput::lastfile;
int				cInput::quiton = 1;
int				cInput::help;
int				cInput::tmBegin = clock( );
unsigned int	cInput::input_array_size;
unsigned int	cInput::input_array_count;
unsigned char**	cInput::input_start_array;

unsigned char*	cInclude::input_start;			// First byte of include area.
unsigned char*	cInclude::input_end;			// Byte after input.
unsigned char	cInclude::dir[ 256 ];			// Directory of include file.
unsigned char	cInclude::path[ 256 ];			// Path of include file.
unsigned char	cInclude::filename[ 256 ];		// Filename of include file.
unsigned char	cInclude::filetype[ 64 ];		// Filetype of include file.
unsigned char   cInclude::filename_ext[ 256 ];	// Path to file (fn.ft).
int				cInclude::filedesc;		 
int				cInclude::filesize;
int				cInclude::lookupon;
unsigned char	cInclude::SavedPath[ 256 ];
unsigned char*	cInclude::SavedTokenEnd;
int				cInclude::SavedLinenumb;
unsigned int	cInclude::input_array_size;
unsigned int	cInclude::input_array_count;
unsigned char**	cInclude::input_start_array;

unsigned char	cOutput::dir[ ];		// Directory.
unsigned char	cOutput::filename[ ];	// Filename of output file.
unsigned char	cOutput::filetype[ ];	// Filetype of output file.
FILE*			cOutput::filedesc;		// File descriptor.
char*			cOutput::pxml_buffer = 0;
unsigned int	cOutput::xml_buffer_default_len = 1000000;
unsigned int	cOutput::xml_buffer_len;
unsigned int	cOutput::xml_buffer_pos;

unsigned char	cDebug::dir[ ];			// Directory.
unsigned char	cDebug::filename[ ];	// Filename of output file.
unsigned char	cDebug::filetype[ ];	// Filetype of output file.
FILE*			cDebug::filedesc;		// File descriptor.
// End class statics

// uppercase[ x ] gives the uppercase of x (extern)
unsigned char uppercase[ 256 ] =
{
	  0,  1,  2,  3,  4,  5,  6,  7,  8,  9, 10, 11, 12, 13, 14, 15,
	 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31,
	 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47,
	 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63,
	 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79,
	 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 92, 93, 94, 95,
	 96, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79,
	 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90,123,124,125,126,127,
	
	128,129,130,131,132,133,134,135,136,137,138,139,140,141,142,143,
	144,145,146,147,148,149,150,151,152,153,154,155,156,157,158,159,
	160,161,162,163,164,165,166,167,168,169,170,171,172,173,174,175,
	176,177,178,179,180,181,182,183,184,185,186,187,188,189,190,191,
	192,193,194,195,196,197,198,199,200,201,202,203,204,205,206,207,
	208,209,210,211,212,213,214,215,216,217,218,219,220,221,222,223,
	224,225,226,227,228,229,230,231,232,233,234,235,236,237,238,239,
	240,241,242,243,244,245,246,247,248,249,250,251,252,253,254,255
};

int main( const int iArgCount, const unsigned char* arrayArgs[ ] )
{
	Init( iArgCount, arrayArgs );

	//#define TEST_CASES
	#ifdef TEST_CASES
		#include "test_cases.h"  // Contains proprietary test information and is not included in open source distribution.
	#else
		BeginParse( iArgCount, arrayArgs );
	#endif

	return ( return_code > 0 ? return_code : aixml_return_code );
}

void Init( const int iArgCount, const unsigned char* arrayArgs[ ] )
{
	cOption::console_html = CommandLine::ConsoleHTML( iArgCount, ( const char** ) arrayArgs );

	CommandLine::PrintConsole( PrintConsoleFlags( CommandLine::eBold ), 
		"C/ATLAS to AIXML Parser\nVersion: %s.%s, Build: %s, Build Date: %s\nCopyright (c) %s Universal Technical Resource Services, Inc.\n\n",
		major_version,
		minor_version,
		build_num,
		build_date,
		copyright_year );
}

void BeginParse( const int iArgCount, const unsigned char* arrayArgs[ ] )
{
	const string strVersion( string( ( char* ) major_version ) + string( "." ) + string( ( char* ) minor_version ) );
	const bool bParseOnly = false;
	const bool bAST = false;
	AtlasStatistics atlasStatistics;
	CommandLine cl;

	try
	{
		if ( cl.Init( iArgCount, ( const char** ) arrayArgs ) )
		{
			if ( 0 == ParseAtlas( &cl ) )
			{
				if ( cl.AST( ) || bAST )
				{
					FILE* pFileAST = fopen( cl.GetASTFilename( ).c_str( ), "w" );
				
					if ( 0 != pFileAST )
					{
						fwrite( cOutput::GetXmlBuffer( ), sizeof( char ), cOutput::GetXmlBufferLen( ), pFileAST );

						fclose( pFileAST );
					}
				}

				if ( !bParseOnly )
				{
					AIXML ai( &cl, strVersion );
			
					if ( ai.Parse( cOutput::GetXmlBuffer( ), cOutput::GetXmlBufferLen( ) ) )
					{
						cInput::GarbageCollect( );
						cOutput::GarbageCollect( );
						cInclude::GarbageCollect( );

						ai.ToXML( );

						atlasStatistics = ai.GetStatistics( );
					}
					else
					{
						#if ( _DEBUG )
							CommandLine::PrintConsole( PrintConsoleFlags( CommandLine::eError ), "%s\n", ai.GetErrorText( true ).c_str( ) );
						#else
							CommandLine::PrintConsole( PrintConsoleFlags( CommandLine::eError ), ai.GetErrorText( false ).c_str( ) );
						#endif
			
						aixml_return_code = ai.GetError( );
					}
				}
			}
		}
		else if ( cl.Help( ) )
		{
			cInput::help = 1;

			printf( CommandLine::GetHelp( cOption::console_html == 1 ? true : false ).c_str( ) );
		}
		else
		{
			#if ( _DEBUG )
				CommandLine::PrintConsole( PrintConsoleFlags( CommandLine::eError ), "%s\n", cl.GetErrorText( true ).c_str( ) );
			#else
				CommandLine::PrintConsole( PrintConsoleFlags( CommandLine::eError ), "%s\n", cl.GetErrorText( false ).c_str( ) );
			#endif

	
			aixml_return_code = cl.GetError( );
		}
	}
	catch ( const unsigned int uiReturnCode )
	{
		const unsigned int ui = uiReturnCode;
	}
	catch ( ... )
	{
		CommandLine::PrintConsole( PrintConsoleFlags( CommandLine::eError ), "\nUnhandled Exception\n" );

		return_code = RC_INTERNAL_ERROR;
	}

	cInput::GarbageCollect( );
	cOutput::GarbageCollect( );
	cInclude::GarbageCollect( );

	Quit( &atlasStatistics );

	if ( return_code > 0 )
	{
		const string& strOutputFilename = cl.GetOutputFilename( true );
		if ( !strOutputFilename.empty( ) )
		{
			_unlink( strOutputFilename.c_str( ) );
		}

		if ( cl.ProcedureCallHierarchyXML( ) )
		{
			const string& strProcHierOutputFilename = cl.GetProcHierOutputFilename( true );

			if ( !strProcHierOutputFilename.empty( ) )
			{
				_unlink( cl.GetProcHierOutputFilename( true ).c_str( ) );
			}
		}
	}
}

int ParseAtlas( const CommandLine* pCommandLine )
{
	const char* pOutput = "Output";
	const char* pFilesHeading = "Files";
	const char* pszABF = ".abf";
	unsigned char** filespec = 0;
	unsigned char directory[ 256 ];
	int n_files = 0;
	int nl = 0;
	int lu = 0;
	int i = 0;
	int j = 0; 


	strcpy( ( char* ) cInput::filename,		pCommandLine->GetPrimaryFilename( false ).c_str( ) );
	strcpy( ( char* ) cOutput::dir,			pCommandLine->GetOutputDirectory( ).c_str( ) );
	strcat( ( char* ) cOutput::filename,	pCommandLine->GetOutputFilename( false ).c_str( ) );
	strcat( ( char* ) cOutput::filetype,	pCommandLine->GetPrimaryFilenameExtension( ).c_str( ) );
	strcpy( ( char* ) primary_filename,		( char* ) cInput::filename );
	strcpy( ( char* ) deb_output,			pCommandLine->GetDebugFilename( ).c_str( ) );
	strcpy( ( char* ) cInput::dir,			pCommandLine->GetInputDirectory( ).c_str( ) );
	strcpy( ( char* ) cInput::filename,		pCommandLine->GetPrimaryFilename( false ).c_str( ) );


	if ( pCommandLine->Debug( ) )
	{
		cOption::debug = 1;
	}

	if ( pCommandLine->GetInputFilenames( ).size( ) > 1 )
	{
		strcpy( ( char* ) cInput::filetype, pszABF );
	}
	else
	{
		strcpy( ( char* ) cInput::filetype, ( char* ) pCommandLine->GetPrimaryFilenameExtension( ).c_str( ) );
	}

	if ( pCommandLine->GetInputFilenames( ).size( ) > 1 )
	{	
		n_files = ReadBuildFile( cInput::dir, cInput::filename, cInput::filetype, filespec, pCommandLine->GetInputFilenamesAsABF( ).c_str( ) );

		if ( n_files <= 0 )
		{
			goto RET;
		}

		Split( filespec[ 0 ], directory, cInput::filename, cInput::filetype, ( unsigned char* ) ".as" );
	}

	if ( cOption::console_html )
	{
		bFilesBeginTable = true;

		CommandLine::PrintConsole( PrintConsoleFlags( CommandLine::eNoEncoding | CommandLine::eNoSearchReplace ), pBeginTable );
		CommandLine::PrintConsole( PrintConsoleFlags( CommandLine::eNoEncoding | CommandLine::eNoSearchReplace ), pTableHeader, pFilesHeading );
	}
	else
	{
		CommandLine::PrintConsole( PrintConsoleFlags( ), "%s\n", pFilesHeading );
	}

	if ( cOption::lookup )
	{ 
		lu = 1;

		try
		{
			if ( 0 == cInput::Open( cInput::dir, cInput::filename, ( unsigned char* ) ".lu", lu ) )
			{
				goto A;
			}
	
			if ( 0 == cInput::Read( 0 ) )
			{
				goto RET;
			}
		}
		catch( const unsigned int uiReturnCode )
		{
			if ( 0 != filespec )
			{
				delete filespec;
				filespec = 0;
			}

			throw uiReturnCode;
		}
	}
	else 
	{ 
A:		lu = 0;

		try
		{
			if ( 0 == cInput::Open( cInput::dir, cInput::filename, cInput::filetype, lu ) )
			{
				goto RET;
			}
	
			if ( 0 == cInput::Read( 0 ) )
			{
				goto RET;
			}
		}
		catch( const unsigned int uiReturnCode )
		{
			if ( 0 != filespec )
			{
				delete filespec;
				filespec = 0;
			}

			throw uiReturnCode;
		}
	}

	if ( cOption::debug )
	{
		cDebug::Init( deb_output );
	}

	// Parse the original file ...
	if ( 0 == parser::init( 100000, 1000000 ) )
	{
		goto RET;
	}

	try
	{
		lexer::init( cInput::path, 0, lu, cInput::input_start, 3, 0 );
	
		nl = parser::parse( n_errs, n_stmts, n_unkn );
	}
	catch( const unsigned int uiReturnCode )
	{
		if ( 0 != filespec )
		{
			delete filespec;
			filespec = 0;
		}

		throw uiReturnCode;
	}

	if ( ( return_code > 0 ) && ( return_code < RC_UNKNOWN_STATEMENT ) )
	{
		goto RET;
	}

	// Parse the rest of the file (if they exist) ...
	if ( nl < 0 ) // Unfinished parse (from segments)
	{
		i = 1;
		j = 1;
		cInput::lastfile = 0;

Loop:	if ( i >= n_files )
		{
			CloseFilesHtmlTable( );
			CommandLine::PrintConsole( PrintConsoleFlags( CommandLine::eError ), "\nParsing is still unfinished at <eof>.\n" );
			return_code |= RC_SYNTAX_ERROR;

			goto RET;
		}

		Split( filespec[ i ], directory, cInput::filename, cInput::filetype, ( unsigned char* ) ".as" );

		if	( 0 == cInput::Open( cInput::dir, cInput::filename, cInput::filetype, 0 ) )
		{
			goto RET;
		}

		cInput::segmenton = 1;

		if ( ( i + 1 ) == n_files )
		{
			cInput::lastfile = 1;
		}

		try
		{
			cInput::Read( 0 );
	
			lexer::init( cInput::path, 0, 0, cInput::input_start, 3, -1 );
	
			nl = parser::parse( n_errs, n_stmts, n_unkn );
		}
		catch( const unsigned int uiReturnCode )
		{
			if ( 0 != filespec )
			{
				delete filespec;
				filespec = 0;
			}

			throw uiReturnCode;
		}

		if ( return_code > 0 )
		{
			goto RET;
		}

		i++;

		if ( nl < 0 )
		{
			goto Loop;
		}

		if ( i < n_files )
		{
			goto Loop;
		}
	}

	if ( cOption::console_html )
	{
		CommandLine::PrintConsole( PrintConsoleFlags( CommandLine::eNoEncoding | CommandLine::eNoSearchReplace ), pTableRow, pOutput, pCommandLine->GetOutputFilename( false ).c_str( ) );

		if ( pCommandLine->ProcedureCallHierarchyXML( ) )
		{
			CommandLine::PrintConsole( PrintConsoleFlags( CommandLine::eNoEncoding | CommandLine::eNoSearchReplace ), pTableRow, pOutput, pCommandLine->GetProcHierOutputFilename( false ).c_str( ) );
		}

		CloseFilesHtmlTable( );
	}
	else
	{
		CommandLine::PrintConsole( PrintConsoleFlags( ), "   %s   %s \n", pOutput, pCommandLine->GetOutputFilename( false ).c_str( ) );

		if ( pCommandLine->ProcedureCallHierarchyXML( ) )
		{
			CommandLine::PrintConsole( PrintConsoleFlags( ), "   %s   %s \n", pOutput, pCommandLine->GetProcHierOutputFilename( false ).c_str( ) );
		}
	}


	// Write out the XML stream, and garbage collect
	parser::term( );

	if ( cOption::xmlfile && ( 0 == n_errs ) )
	{
		cOutput::Term( );
	}

RET: if ( 0 != filespec )
	{
		delete filespec;
		filespec = 0;
	}

	return return_code;
}

int	ReadBuildFile( unsigned char* dir, unsigned char* fn, unsigned char* ft, unsigned char**& filespec, const char* pFileContents )
{
	int i;
	int nf;
	unsigned char  ch;
	unsigned char* p;
	unsigned char* q;

	cInput::Read( pFileContents );

	nf = 0;
	p  = cInput::input_start;

	while ( EOF_CHAR != *p )
	{
		if ( '\n' == *p++ )
		{
			nf++;
		}
	}

	try
	{
		filespec = new unsigned char*[ nf ];
	}
	catch ( ... )
	{
		CommandLine::PrintConsole( PrintConsoleFlags( ), "Failed to create new filename array.\n" );

		return_code |= RC_MEMORY_OVERFLOW;

		throw return_code;
	}

	p = cInput::input_start;
	i = 0;

	do 
	{
		// Find first nonblank ...
		while ( ( ' ' == *p ) || ( '\t' == *p ) )
		{
			p++;
		}

		q = p;
	
		// Find end of filename ...
		while ( ( ' ' != *q ) && ( '\t' != *q ) && ( '\n' != *q ) )
		{
			q++;
		}

		ch = *q;
		*q = 0;
	
		// If not empty ...
		if ( 0 != *p )
		{
			filespec[ i++ ] = p;
		}

		if ( '\n' != ch )
		{
			q++;

			while ( '\n' != *q )
			{
				q++;
			}
		}

		q++;
		p = q;
	}
	while ( EOF_CHAR != *p );

	return i;
}

void Quit( const AtlasStatistics* pAtlasStatistics )
{
	if ( !cInput::help )
	{
		if ( ( return_code > 0 ) || ( aixml_return_code > 0 ) )
		{
			DisplayErrorMessage( );
		}
		else
		{
			DisplayStatistics( pAtlasStatistics );
		}
	}

	#if defined( _DEBUG )
		#if defined( TEST_CASES )
			// Do nothing...
		#else
		  	CommandLine::PrintConsole( 0, "Press any key to continue ...\n" );
		  	while ( !_kbhit( ) );
			_getch( );
		#endif
	#endif
}

void DisplayErrorMessage( void )
{
	if ( cOption::console_html )
	{
		CommandLine::PrintConsole( PrintConsoleFlags( CommandLine::eNoEncoding ), "\n<b>Return Code</b> = %d\n\n", ( return_code > 0 ? return_code : aixml_return_code ) );
	}
	else
	{
		CommandLine::PrintConsole( PrintConsoleFlags( ), "\nReturn code = %d\n\n", ( return_code > 0 ? return_code : aixml_return_code ) );
	}

	if ( return_code > 0 )
	{
		if ( return_code & RC_NO_FILESPEC )
		{
			CommandLine::PrintConsole( PrintConsoleFlags( CommandLine::eError ), 
			"No input file specification.\n" );
		}

		if ( return_code & RC_INVALID_FILESPEC )
		{
			CommandLine::PrintConsole( PrintConsoleFlags( CommandLine::eError ), 
			"Invalid file specification.\n" );
		}

		if ( return_code & RC_INVALID_OPTION )
		{
			CommandLine::PrintConsole( PrintConsoleFlags( CommandLine::eError ), 
			"Invalid program option.\n" );
		}

		if ( return_code & RC_FILE_NOT_FOUND )
		{
			CommandLine::PrintConsole( PrintConsoleFlags( CommandLine::eError ), 
			"File not found.\n" );
		}

		if ( return_code & RC_FILE_READ_ERROR )
		{
			CommandLine::PrintConsole( PrintConsoleFlags( CommandLine::eError ), 
			"File read error\n" );
		}

		if ( return_code & RC_FILE_WRITE_ERROR )
		{
			CommandLine::PrintConsole( PrintConsoleFlags( CommandLine::eError ), 
			"File write error\n" );
		}

		if ( return_code & RC_INCLUDE_ERROR )
		{
			CommandLine::PrintConsole( PrintConsoleFlags( CommandLine::eError ), 
			"Include error\n" );
		}

		if ( return_code & RC_SYNTAX_ERROR )
		{
			CommandLine::PrintConsole( PrintConsoleFlags( CommandLine::eError ), 
			"Syntax error.\n" );
		}

		if ( return_code & RC_SYMBOL_OVERFLOW )
		{
			CommandLine::PrintConsole( PrintConsoleFlags( CommandLine::eError ), 
			"Symbol-table overflow.\n" );
		}

		if ( return_code & RC_AST_OVERFLOW )
		{
			CommandLine::PrintConsole( PrintConsoleFlags( CommandLine::eError ), 
			"AST overflow.\n" );
		}

		if ( return_code & RC_MEMORY_OVERFLOW )
		{
			CommandLine::PrintConsole( PrintConsoleFlags( CommandLine::eError ), 
			"Memory allocation error.\n" );
		}

		if ( return_code & RC_INTERNAL_ERROR )
		{
			CommandLine::PrintConsole( PrintConsoleFlags( CommandLine::eError ), 
			"Internal error.\n" );
		}

		if ( return_code & RC_UNKNOWN_STATEMENT )
		{
			CommandLine::PrintConsole( PrintConsoleFlags( CommandLine::eError ), 
			"Unknown statement verb.\n" );
		}
	}

	CommandLine::PrintConsole( PrintConsoleFlags( ), "\n" );
}

void DisplayStatistics( const AtlasStatistics* pAtlasStatistics )
{
	int tmTemp;
	int tmEnd;
	int tmThou;
	int tmSec;
	int iStatementPercent = 0;

	// Compute time used ...
	tmEnd = clock( ); // Get end time.
	tmTemp = ( tmEnd - cInput::tmBegin );

	if ( 0 == tmTemp )
	{
		tmTemp = 1;
	}

	tmThou = ( ( tmTemp * 1000 ) / CLOCKS_PER_SEC );
	tmSec  = ( tmThou / 1000 );
	tmThou -= ( tmSec * 1000 );

	if ( n_stmts > 0 )
	{
		iStatementPercent = ( ( n_stmts - n_errs - n_unkn ) * 100 / n_stmts );
	}

	CommandLine::PrintConsole( PrintConsoleFlags( ), "\n" );

	const string strStatisticsHeader( "Statistics" );
	pair< string, string > arrayStats[ 10 ];
	const char* pSecondsFormat = "%4d.";
	const char* pSecondsPartFormat = "%03ld";
	const char* pNumberFormat = "%8s";
	unsigned int uiNounCount = 0;
	unsigned int uiStatementCount = 0;
	const unsigned int uiPrintFlags = PrintConsoleFlags( );
	const int iMinFirstColWidth = 50;
	const int iFirstColumnCellPadding = 8;
	int iCount = 0;

	if ( cOption::console_html )
	{
		pSecondsFormat = "%d.";
		pNumberFormat = "%s";
	}

	if ( 0 != pAtlasStatistics )
	{
		uiNounCount = pAtlasStatistics->GetSignalCount( );
		uiStatementCount = pAtlasStatistics->GetStatementCount( );
	}

	arrayStats[ iCount ].first += ( const char* ) Number( tmSec, pSecondsFormat );
	arrayStats[ iCount++ ].first += ( const char* ) Number( tmThou, pSecondsPartFormat );
	arrayStats[ iCount++ ].first += ( const char* ) Number( Number( n_stmts ), pNumberFormat );
	arrayStats[ iCount++ ].first += ( const char* ) Number( Number( n_errs ), pNumberFormat );
	arrayStats[ iCount++ ].first += ( const char* ) Number( Number( n_unkn ), pNumberFormat );
	arrayStats[ iCount++ ].first += ( const char* ) Number( Number( uiNounCount ), pNumberFormat );
	arrayStats[ iCount++ ].first += ( const char* ) Number( Number( uiStatementCount ), pNumberFormat );
	arrayStats[ iCount++ ].first += ( const char* ) Number( Number( parser::n_symbols ), pNumberFormat );
	arrayStats[ iCount++ ].first += ( const char* ) Number( Number( parser::n_nodes ), pNumberFormat );
	arrayStats[ iCount++ ].first += ( const char* ) Number( Number( parser::nd_level_max ), pNumberFormat );
	arrayStats[ iCount++ ].first += ( const char* ) Number( Number( iStatementPercent ), pNumberFormat );

	iCount = 0;
	arrayStats[ iCount++ ].second = "seconds total time";
	arrayStats[ iCount++ ].second = "statements processed";
	arrayStats[ iCount++ ].second = "statements with an error";
	arrayStats[ iCount++ ].second = "statements with an unknown verb";
	arrayStats[ iCount++ ].second = ( 1 == uiNounCount ? "noun type" : "noun types" );
	arrayStats[ iCount++ ].second = ( 1 == uiStatementCount ? "statement type" : "statement types" );
	arrayStats[ iCount++ ].second = "symbols in symbol table";
	arrayStats[ iCount++ ].second = "nodes in abstract-syntax tree";
	arrayStats[ iCount++ ].second = "levels of nondeterministic parsing reached";
	arrayStats[ iCount++ ].second = "percent successful";

	if ( cOption::console_html )
	{
		const unsigned int uiPrintFlagsNoEncoding = ( uiPrintFlags | CommandLine::eNoEncoding | CommandLine::eNoSearchReplace );

		CommandLine::PrintConsole( uiPrintFlagsNoEncoding, pBeginTable );
		CommandLine::PrintConsole( uiPrintFlagsNoEncoding, pTableHeader, strStatisticsHeader.c_str( ) );

		for ( int i = 0; i < iCount; ++i )
		{
			CommandLine::PrintConsole( PrintConsoleFlags( CommandLine::eNoEncoding | CommandLine::eNoSearchReplace ), pTableRow, arrayStats[ i ].first.c_str( ), arrayStats[ i ].second.c_str( ) );
		}

		CommandLine::PrintConsole( uiPrintFlagsNoEncoding, pEndTable );
	}
	else
	{
		CommandLine::PrintConsole( uiPrintFlags, "%s\n", strStatisticsHeader.c_str( ) );

		for ( int i = 0; i < iCount; ++i )
		{
			CommandLine::PrintConsole( uiPrintFlags, arrayStats[ i ].first.c_str( ) );
			CommandLine::PrintConsole( uiPrintFlags, " " );
			CommandLine::PrintConsole( uiPrintFlags, arrayStats[ i ].second.c_str( ) );
			CommandLine::PrintConsole( uiPrintFlags, ".\n" );
		}
	}

	if ( 0 != pAtlasStatistics )
	{
		const map< string, unsigned int >& mapSignalCounts = pAtlasStatistics->GetSignalCountsSortedByName( );
		const map< string, unsigned int >& mapStatementCounts = pAtlasStatistics->GetStatementsCountsSortedByName( );
		const string strNounsHeader( "Nouns Processed" );
		const string strStatementsHeader( "Statements Processed" );

		if ( cOption::console_html )
		{
			const unsigned int uiPrintFlagsNoEncoding = ( uiPrintFlags | CommandLine::eNoEncoding | CommandLine::eNoSearchReplace );

			if ( mapSignalCounts.size( ) > 0 )
			{
				map< string, unsigned int >::const_iterator it = mapSignalCounts.begin( );
				const map< string, unsigned int >::const_iterator itEnd = mapSignalCounts.end( );

				CommandLine::PrintConsole( uiPrintFlagsNoEncoding, "<br/>" );
				CommandLine::PrintConsole( uiPrintFlagsNoEncoding, pBeginTable );
				CommandLine::PrintConsole( PrintConsoleFlags( CommandLine::eNoEncoding | CommandLine::eNoSearchReplace ), pTableHeader, strNounsHeader.c_str( ) );

				while ( itEnd != it )
				{
					CommandLine::PrintConsole( PrintConsoleFlags( CommandLine::eNoEncoding | CommandLine::eNoSearchReplace ), pTableRow, ( const char* ) Number( Number( it->second ), pNumberFormat ), it->first.c_str( ) );

					++it;
				}

				CommandLine::PrintConsole( uiPrintFlagsNoEncoding, pEndTable );
			}

			if ( mapStatementCounts.size( ) > 0 )
			{
				map< string, unsigned int >::const_iterator it = mapStatementCounts.begin( );
				const map< string, unsigned int >::const_iterator itEnd = mapStatementCounts.end( );

				CommandLine::PrintConsole( uiPrintFlagsNoEncoding, "<br/>" );
				CommandLine::PrintConsole( uiPrintFlagsNoEncoding, pBeginTable );
				CommandLine::PrintConsole( PrintConsoleFlags( CommandLine::eNoEncoding | CommandLine::eNoSearchReplace ), pTableHeader, strStatementsHeader.c_str( ) );

				while ( itEnd != it )
				{
					CommandLine::PrintConsole( PrintConsoleFlags( CommandLine::eNoEncoding | CommandLine::eNoSearchReplace ), pTableRow, ( const char* ) Number( Number( it->second ), pNumberFormat ), it->first.c_str( ) );

					++it;
				}

				CommandLine::PrintConsole( uiPrintFlagsNoEncoding, pEndTable );
			}
		}
		else
		{
			if ( mapSignalCounts.size( ) > 0 )
			{
				map< string, unsigned int >::const_iterator it = mapSignalCounts.begin( );
				const map< string, unsigned int >::const_iterator itEnd = mapSignalCounts.end( );

				CommandLine::PrintConsole( uiPrintFlags, "\n%s\n", strNounsHeader.c_str( ) );

				while ( itEnd != it )
				{
					CommandLine::PrintConsole( uiPrintFlags, ( const char* ) Number( Number( it->second ), pNumberFormat ) );
					CommandLine::PrintConsole( uiPrintFlags, " " );
					CommandLine::PrintConsole( uiPrintFlags, it->first.c_str( ) );
					CommandLine::PrintConsole( uiPrintFlags, "\n" );

					++it;
				}
			}

			if ( mapStatementCounts.size( ) > 0 )
			{
				map< string, unsigned int >::const_iterator it = mapStatementCounts.begin( );
				const map< string, unsigned int >::const_iterator itEnd = mapStatementCounts.end( );

				CommandLine::PrintConsole( uiPrintFlags, "\n%s\n", strStatementsHeader.c_str( ) );

				while ( itEnd != it )
				{
					CommandLine::PrintConsole( uiPrintFlags, ( const char* ) Number( Number( it->second ), pNumberFormat ) );
					CommandLine::PrintConsole( uiPrintFlags, " " );
					CommandLine::PrintConsole( uiPrintFlags, it->first.c_str( ) );
					CommandLine::PrintConsole( uiPrintFlags, "\n" );

					++it;
				}
			}
		}
	}

	if ( cOption::console_html )
	{
		CommandLine::PrintConsole( PrintConsoleFlags( CommandLine::eNoEncoding ), "\n<b>Return code</b> = %d", return_code );
	}
	else
	{
		CommandLine::PrintConsole( PrintConsoleFlags( ), "\nReturn code = %d", return_code );
	}

	CommandLine::PrintConsole( PrintConsoleFlags( ), "\n" );
}

int Split( unsigned char* arg, unsigned char* dir, unsigned char* fn, unsigned char* ft, unsigned char* def )
{
	// Define directory and move to path ...
	unsigned char* f;
	unsigned char* p;
	unsigned char* x = 0;

	for ( p = arg; 0 != *p; p++ )	// Scan filename specified.
	{
		if ( '\\' == *p )
		{
			x = p;					// Get last \.
		}
	}

	if ( 0 == x )					// Directory not specified?
	{
		dir[ 0 ] = 0;				// Empty directory.
	}
	else							// Directory specified!
	{
		if ( '*' != arg[ 0 ] ) 		// Not '*'?
		{
			strcpy( ( char* ) dir, ( char* ) arg );	// Override directory.     
			dir[ x - arg + 1 ] = 0;
		}
	}

	// Define filename and filetype, move to path ...
	if ( 0 == x )
	{
		f = arg;				// Start of filename.
	}
	else
	{
		f = x + 1;				// Start of filename.
	}

	x = 0;

	for ( p = f; 0 != *p; p++ )	// Scan filename specified.
	{
		if ( '.' == *p )
		{
			x = p;				// Get last dot.
		}
	}

	if ( 0 == x )				// Filetype not specified?
	{
		if ( ( '*' != f[ 0 ] ) && ( 0 != f[ 0 ] ) )
		{
			strcpy( ( char* ) fn, ( char* ) f );	// Override filename.
		}

		strcpy( ( char* ) ft, ( char* ) def );		// Use default filetype. 
	}
	else
	{
		if ( ( '*' != f[ 0 ] ) && ( 0 != f[ 0 ] ) )
		{
			*x = 0; 
			strcpy( ( char* ) fn, ( char* ) f );	// Override filename.
			*x = '.'; 
		}

		strcpy( ( char* ) ft, ( char* ) x );		// Use specified filetype. 
	}

	return 1;
}

int cInput::Open( unsigned char* dir, unsigned char* fn, unsigned char* ft, int lu )
{
	strcpy( ( char* ) path, ( char* ) dir );
	strcat( ( char* ) path, ( char* ) fn );
	strcat( ( char* ) path, ( char* ) ft );

	strcpy( ( char* ) filename_ext, ( char* ) fn );
	strcat( ( char* ) filename_ext, ( char* ) ft );

	// Try to open the file ...
	lookupon = lu;
	filedesc = _open( ( char* ) path, 0 );	// Open the file.

	if ( filedesc < 0 )						// If open error.  
	{
		if ( lookupon )
		{
			CloseFilesHtmlTable( );
			CommandLine::PrintConsole( PrintConsoleFlags( ), "\nLookup \"%s\" was not found.\n", filename_ext );
			return_code |= RC_FILE_NOT_FOUND;

			throw return_code;
		}
		else
		{
			if ( quiton )
			{
				CloseFilesHtmlTable( );
				CommandLine::PrintConsole( PrintConsoleFlags( ), "\nInput \"%s\" was not found.\n", filename_ext );
				return_code |= RC_FILE_NOT_FOUND;

				throw return_code;
			}

			return 0;
		}
	}

	return 1;
}

int cInput::Read( const char* pFileContents )
{
	int nb;													// Number of bytes read.
	int len;
	unsigned char string[ 256 ];

	filesize = ( 0 == pFileContents ? _filelength( filedesc ) : strlen( pFileContents ) );		// Get filesize.

	try
	{
		input_start = new unsigned char [ filesize + 518 ];		// Get some memory.
	}
	catch ( ... )
	{
		CommandLine::PrintConsole( PrintConsoleFlags( ), "Failed to allocate memory for input file contents.\n" );

		return_code |= RC_MEMORY_OVERFLOW;

		throw return_code;
	}

	if ( 0 == input_start )
	{
		CloseFilesHtmlTable( );

		if ( lookupon )
		{
			CommandLine::PrintConsole( PrintConsoleFlags( ), "\nLookup \"%s\" is too large for available memory.\n", filename_ext );
		}
		else
		{
			CommandLine::PrintConsole( PrintConsoleFlags( ), "\nInput \"%s\" is too large for available memory.\n", filename_ext );
		}

		return_code |= RC_MEMORY_OVERFLOW;

		throw return_code;
	}

	AddInputStart( input_start );

	*input_start++ = '\n';									// Put <eol> at beginning. 

	if ( segmenton )
	{
		len = sprintf( ( char* ) string, " 000000 SEGMENT, '%s' $\n", cInput::filename );
		memcpy( input_start, string, len );
		input_start += len;
	}
	else
	{
		len = 0;
	}

	if ( 0 == pFileContents )
	{
		nb = _read( filedesc, ( char* ) input_start, filesize );	// Read size bytes into buffer. 
	}
	else
	{
		memcpy( input_start, pFileContents, filesize );
		nb = filesize;
	}

	if ( nb <= 0 )													// If read error.               
	{
		CloseFilesHtmlTable( );

		if ( lookupon )
		{
			CommandLine::PrintConsole( PrintConsoleFlags( ), "\nLookup \"%s\" is not readable.\n", filename_ext );
		}
		else
		{
			CommandLine::PrintConsole( PrintConsoleFlags( ), "\nInput \"%s\" is not readable.\n", filename_ext );
		}

		return_code |= RC_FILE_READ_ERROR;

		throw return_code;
	}

	if ( lookupon )							// Lookup file?
	{
		if ( cOption::console_html )
		{
			CommandLine::PrintConsole( PrintConsoleFlags( CommandLine::eNoEncoding | CommandLine::eNoSearchReplace ), pTableRow, "Lookup", filename_ext );
		}
		else
		{
			CommandLine::PrintConsole( PrintConsoleFlags( ), "   Lookup   %s \n", filename_ext );
		}
	}
	else if ( 0 == pFileContents )
	{
		if ( cOption::console_html )
		{
			if ( segmenton )
			{
				CommandLine::PrintConsole( PrintConsoleFlags( CommandLine::eNoEncoding | CommandLine::eNoSearchReplace ), pTableRow, "Segment", filename_ext );
			}
			else
			{
				CommandLine::PrintConsole( PrintConsoleFlags( CommandLine::eNoEncoding | CommandLine::eNoSearchReplace ), pTableRow, "Primary", filename_ext );
			}
		}
		else
		{
			if ( segmenton )
			{
				CommandLine::PrintConsole( PrintConsoleFlags( ), "   Segment  %s \n", filename_ext );
			}
			else
			{
				CommandLine::PrintConsole( PrintConsoleFlags( ), "   Primary  %s \n", filename_ext );
			}
		}
	}

	input_end = input_start + nb;				// Set end-of-buffer pointer.         
	input_start -= len;							// Reset input_start to beginning.
	*input_end++ = EOL_CHAR;					// Put end-of-line here.

	if ( segmenton )
	{
		len = sprintf( ( char* ) string, " 999999 END, SEGMENT $\n" );

		if ( 0 == lastfile )
		{
A: 			memcpy( input_end, string, len );
			input_end += len;										  
		}
		else // Last file!
		{
			// Find TERMINATE statement ...						  
			unsigned char* p = ( input_end - 1 );

B:  		while ( ( 'T' != *p ) && ( p > input_start ) )
			{
				p--;
			}

			if ( 'T' == *p )
			{
				if ( 0 == strncmp( ( char* ) p, "TERMINATE", 9 ) )
				{
					while ( '\n' != *p )	// Fine start of line.
					{
						p--; 
					}

					p++;

					memcpy( ( char* ) p + len, ( char* ) p, input_end - p );	// Move TERMINATE down.
					memcpy( ( char* ) p, ( char* ) string, len );				// Insert END SEGMENT. 

					input_end += len;

					goto C;
				}

				p--;
				goto B;
			}
			goto A;
		}
	}

C:    *input_end++ = EOL_CHAR;					// Put end-of-line here.
      *input_end++ = EOF_CHAR;					// Put first <eof> here.
      *input_end++ = EOF_CHAR;					// Put second <eof> here. 
      *input_end++ = EOL_CHAR;					// Put end-of-line here.
      *input_end++ = 0;							// Put zero byte here. 

	if ( 0 != pFileContents )
	{
		_close( filedesc );						// Close file.                        
	}

	return 1;
}

int cInput::Close( )
{
	_close( filedesc );

	return 1;
}

int cInclude::Check( const unsigned char* fn ) // Check the filename.
{
	unsigned char* p;
	unsigned char* x;
	unsigned char filespec[ 256 ];

	strcpy( ( char* ) filespec, ( char* ) fn );

	x = 0;

	for ( p = filespec, x = 0; 0 != *p; p++ ) 
	{
		if ( '.' == *p )	 // last dot
		{
			x = p;
		}
	}

	if ( 0 != x )
	{
		*x = 0;
	}

	if ( 0 == strcmp( ( char* ) cInput::filename, ( char* ) filespec ) )
	{
		CloseFilesHtmlTable( );
		CommandLine::PrintConsole( PrintConsoleFlags( ), "\nInclude \"%s\" is the same as the original file.\n", filespec );
		CommandLine::PrintConsole( PrintConsoleFlags( ), "         %s(%d) : INCLUDE statement is here.\n", cInput::path, lexer::linenumb );
		return_code |= RC_INCLUDE_ERROR;

		throw return_code;
	}

	if ( 0 != x ) // File extention present?
	{	
		strcpy( ( char* ) filename, ( char* ) filespec );
		*x = '.';

		strcpy( ( char* ) filetype, ( char* ) x );
		strcpy( ( char* ) path,     ( char* ) dir );
		strcat( ( char* ) path,     ( char* ) filename );
		strcat( ( char* ) path,     ( char* ) filetype );
										    
		filedesc = _open( ( char* ) path, 0 );	// Open the file.             

		if ( filedesc >= 0 )
		{
			return 1;	// If success return.
		}

		*x = 0;
	}

	strcpy( ( char* ) filename, ( char* ) filespec );
	strcpy( ( char* ) filetype, ( char* ) cInput::filetype );  // Original filetype!

	return 1;
}

int cInclude::Open( const unsigned char* dir, const unsigned char* fn, const unsigned char* ft, const int lu )
{
	strcpy( ( char* ) path, ( char* ) dir );
	strcat( ( char* ) path, ( char* ) fn );
	strcat( ( char* ) path, ( char* ) ft );

	strcpy( ( char* ) filename_ext, ( char* ) fn );
	strcat( ( char* ) filename_ext, ( char* ) ft );

	// Try to open the file ...
	lookupon = lu;
	filedesc = _open( ( char* ) path, 0 );	// Open the file.             

	if ( filedesc < 0 )						// If open error.             
	{
		if ( lookupon )
		{
			CloseFilesHtmlTable( );
			CommandLine::PrintConsole( PrintConsoleFlags( ), "\nLookup  \"%s\" was not found.\n", filename_ext );
			CommandLine::PrintConsole( PrintConsoleFlags( ), "         %s(%d) : INCLUDE statement is here.\n", AIXMLHelper::StripPath( ( char* ) SavedPath ).c_str( ), SavedLinenumb );
			return_code |= RC_FILE_NOT_FOUND;

			throw return_code;
		}
		else
		{
			CloseFilesHtmlTable( );
			CommandLine::PrintConsole( PrintConsoleFlags( ), "\nInclude \"%s\" was not found.\n", filename_ext );
			CommandLine::PrintConsole( PrintConsoleFlags( ), "         %s(%d) : INCLUDE statement is here.\n", AIXMLHelper::StripPath( ( char* ) SavedPath ).c_str( ), SavedLinenumb );
			return_code |= RC_FILE_NOT_FOUND;

			throw return_code;
		}
	}

	return 1;
}

int cInclude::Read( void )
{
	int nb;	

	filesize = _filelength( filedesc );					// Get filesize.

	try
	{
		input_start = new unsigned char[ filesize + 6 ];	// Allocate memory for file contents
	}
	catch ( ... )
	{
		CommandLine::PrintConsole( PrintConsoleFlags( ), "Failed to allocate memory for input include file contents.\n" );

		return_code |= RC_MEMORY_OVERFLOW;

		throw return_code;
	}

	if ( 0 == input_start )
	{
		CloseFilesHtmlTable( );

		if ( lookupon )
		{
			CommandLine::PrintConsole( PrintConsoleFlags( ), "\nLookup \"%s\" is too large for available memory.\n", filename_ext );
			CommandLine::PrintConsole( PrintConsoleFlags( ), "        %s(%d) : INCLUDE statement is here.\n", AIXMLHelper::StripPath( ( char* ) SavedPath ).c_str( ), SavedLinenumb );
		}
		else
		{
			CommandLine::PrintConsole( PrintConsoleFlags( ), "\nInclude \"%s\" is too large for available memory.\n", filename_ext );
			CommandLine::PrintConsole( PrintConsoleFlags( ), "         %s(%d) : INCLUDE statement is here.\n", AIXMLHelper::StripPath( ( char* ) SavedPath ).c_str( ), SavedLinenumb );
		}

		return_code |= RC_MEMORY_OVERFLOW;

		throw return_code;
	}

	AddInputStart( input_start );

	*input_start++ = '\n';							// Put <eol> at beginning. 
	nb = _read( filedesc, input_start, filesize );	// Read file into buffer. 

	if ( nb <= 0 )									// If read error.
	{
		CloseFilesHtmlTable( );

		if ( lookupon )
		{
			CommandLine::PrintConsole( PrintConsoleFlags( ), "\nLookup \"%s\" cannot be read \n", filename_ext );
			CommandLine::PrintConsole( PrintConsoleFlags( ), "        %s(%d) : INCLUDE statement is here.\n", AIXMLHelper::StripPath( ( char* ) SavedPath ).c_str( ), SavedLinenumb );
		}
		else
		{
			CommandLine::PrintConsole( PrintConsoleFlags( ), "\nInclude \"%s\" cannot be read \n", filename_ext );
			CommandLine::PrintConsole( PrintConsoleFlags( ), "         %s(%d) : INCLUDE statement is here.\n", AIXMLHelper::StripPath( ( char* ) SavedPath ).c_str( ), SavedLinenumb );
		}

		return_code |= RC_FILE_READ_ERROR;

		throw return_code;
	}

	if ( lookupon )							// Lookup file?
	{
		if ( cOption::console_html )
		{
			CommandLine::PrintConsole( PrintConsoleFlags( CommandLine::eNoEncoding | CommandLine::eNoSearchReplace ), pTableRow, "Lookup", filename_ext );
		}
		else
		{
			CommandLine::PrintConsole( PrintConsoleFlags( ), "   Lookup   %s \n", filename_ext );
		}
	}
	else
	{
		if ( cOption::console_html )
		{
			CommandLine::PrintConsole( PrintConsoleFlags( CommandLine::eNoEncoding | CommandLine::eNoSearchReplace ), pTableRow, "Include", filename_ext );
		}
		else
		{
			CommandLine::PrintConsole( PrintConsoleFlags( ), "   Include  %s \n", filename_ext );
		}
	}

	_close( filedesc );				// Close file.

	input_end = input_start + nb;	// Set end-of-buffer pointer.         
	*input_end++ = EOL_CHAR;		// Put end-of-line here.
	*input_end++ = EOF_CHAR;		// Put first <eof> here.
	*input_end++ = EOF_CHAR;		// Put second <eof> here. 
	*input_end++ = EOL_CHAR;		// Put end-of-line here.
	*input_end++ = 0;				// Put zero byte here. 

	return 1;
}

void cInclude::Save( void )
{
	strcpy( ( char* ) SavedPath, ( char* ) lexer::path );
	
	SavedTokenEnd = lexer::token.end;
	SavedLinenumb = lexer::linenumb;
}

void cInclude::Reset( void )
{
	strcpy( ( char* ) lexer::path, ( char* ) SavedPath );

	lexer::token.end = SavedTokenEnd;
	lexer::linenumb  = SavedLinenumb;
	lexer::includeon = 0;
	lexer::lookupon  = 0;
}

int cOutput::Init( const unsigned char* fn )
{
	if ( 0 != dir[ 0 ] )
	{
		if  ( 0 != _chdir( ( char* ) dir ) )
		{
			_mkdir( ( char* ) dir );
		}
		else
		{
			_chdir ( "..\\" );
		}
	}

	filedesc = fopen( ( char* ) fn, "w" );

	if ( 0 == filedesc )
	{
		CloseFilesHtmlTable( );
		CommandLine::PrintConsole( PrintConsoleFlags( ), "Output  \"%s\" cannot be created.\n", fn );
		return_code |= RC_FILE_WRITE_ERROR;

		return 0;
	}

	CommandLine::PrintConsole( PrintConsoleFlags( ), "Output  \"%s\" \n", fn );

	return 1;
}
                                        
void cOutput::Term( void )
{
	fclose( filedesc );
}

void cOutput::WriteXmlBuffer( const unsigned char* puchXML )
{
	const int iLen = strlen( ( char* ) puchXML );

	if ( iLen > 0 )
	{
		if ( ( xml_buffer_pos + iLen ) > xml_buffer_len )
		{
			xml_buffer_len += xml_buffer_default_len;

			char* pbuff = 0;

			try
			{
				pbuff = ( char* ) new char[ xml_buffer_len];
			}
			catch ( ... )
			{
				CloseFilesHtmlTable( );

				CommandLine::PrintConsole( PrintConsoleFlags( ), "XML output too large for available memory.\n" );

				return_code |= RC_MEMORY_OVERFLOW;

				throw return_code;
			}

			memcpy( pbuff, pxml_buffer, xml_buffer_pos );

			delete pxml_buffer;

			pxml_buffer = pbuff;
		}

		memcpy( ( pxml_buffer + xml_buffer_pos ), puchXML, iLen );

		xml_buffer_pos += iLen;
	}
}

void cOutput::WriteXmlFile( const unsigned char* puchXML )
{
	fprintf( cOutput::filedesc, ( char* ) puchXML );
}

int cDebug::Init( const unsigned char* fn )
{
	if ( 0 != dir[ 0 ] )
	{
		if  ( 0 != _chdir( ( char* ) dir ) )
		{
			_mkdir( ( char* ) dir );
		}
		else
		{
			_chdir( "..\\" );
		}
	}

	filedesc = fopen( ( char* ) fn, "w" );

	if ( 0 == filedesc )
	{
		CloseFilesHtmlTable( );
		CommandLine::PrintConsole( PrintConsoleFlags( ), "Output  \"%s\" cannot be created.\n", fn );
		return_code |= RC_FILE_WRITE_ERROR;

		return 0;
	}

	return 1;
}
                                        
void cDebug::Term( void )
{
	if ( 0 != filedesc )
	{
		fclose( filedesc );
	}
}

unsigned char* Number( const int x )
{
	int i, j, k;
	unsigned char buff[ 16 ];
	static unsigned char string[ 16 ] = "               ";
	
	_itoa( x, ( char* ) buff, 10 );

	k = strlen( ( char* ) buff );

	i = k + ( k - 1 ) / 3;
	string[ i-- ] = 0;
	j = 0;

	while ( 1 )
	{
		string[ i-- ] = buff[ --k ];

		if ( i < 0 )
		{
			break;
		}

		if ( 0 == ( ++j % 3 ) )
		{
			string[ i-- ] = ',';
		}
	}

	return string;
}

unsigned char* Number( const int x, const char* pFormat )
{
	static unsigned char string[ 16 ] = { 0 };

	sprintf( ( char* ) string, pFormat, x );

	return string;
}

unsigned char* Number( const unsigned char* pnum, const char* pFormat )
{
	static unsigned char string[ 16 ] = { 0 };

	sprintf( ( char* ) string, pFormat, pnum );

	return string;
}

void cOutput::GarbageCollect( void )
{
	if ( 0 != pxml_buffer )
	{
		delete pxml_buffer;

		pxml_buffer = 0;
		xml_buffer_pos = 0;
		xml_buffer_len = 0;
	}
}

void cInput::GarbageCollect( void )
{
	if ( 0 != input_start_array )
	{
		for ( unsigned int ui = 0; ui < input_array_count; ++ui )
		{
			delete input_start_array[ ui ];
		}

		delete input_start_array;

		input_start_array = 0;
		input_array_count = 0;
		input_array_size = 0;
	}
}

void cInclude::GarbageCollect( void )
{
	if ( 0 != input_start_array )
	{
		for ( unsigned int ui = 0; ui < input_array_count; ++ui )
		{
			delete input_start_array[ ui ];
		}

		delete input_start_array;

		input_start_array = 0;
		input_array_count = 0;
		input_array_size = 0;
	}
}

void cInput::AddInputStart( unsigned char* pInputStart )
{
	if ( input_array_size < ( input_array_count + 1 ) )
	{
		if ( 0 == input_array_size )
		{
			input_array_size = 10;
		}
		else
		{
			input_array_size += input_array_size;
		}

		unsigned char** parray = 0;

		try
		{
			parray = new unsigned char*[ input_array_size ];
		}
		catch ( ... )
		{
			CommandLine::PrintConsole( PrintConsoleFlags( ), "Failed to allocate memory for input file array.\n" );

			return_code |= RC_MEMORY_OVERFLOW;

			throw return_code;
		}

		memcpy( parray, input_start_array, ( sizeof( unsigned char* ) * input_array_count ) );

		delete input_start_array;

		input_start_array = parray;
	}

	input_start_array[ input_array_count++ ] = pInputStart;
}

void cInclude::AddInputStart( unsigned char* pInputStart )
{
	if ( input_array_size < ( input_array_count + 1 ) )
	{
		if ( 0 == input_array_size )
		{
			input_array_size = 10;
		}
		else
		{
			input_array_size += input_array_size;
		}

		unsigned char** parray = 0;
		
		try
		{
			parray = new unsigned char*[ input_array_size ];
		}
		catch ( ... )
		{
			CommandLine::PrintConsole( PrintConsoleFlags( ), "Failed to allocate memory for input include file array.\n" );

			return_code |= RC_MEMORY_OVERFLOW;

			throw return_code;
		}

		memcpy( parray, input_start_array, ( sizeof( unsigned char* ) * input_array_count ) );

		delete input_start_array;

		input_start_array = parray;
	}

	input_start_array[ input_array_count++ ] = pInputStart;
}

void Init( void )
{
	cOption::console_html = 0;

	cInput::filedesc		= 0; 
	cInput::filesize		= 0;
	cInput::input_start		= 0;
	cInput::input_end		= 0;
	cInput::lookupon		= 0;
	cInput::segmenton		= 0;
	cInput::lastfile		= 0;

	cInclude::input_start	= 0;
	cInclude::input_end		= 0;
	cInclude::filedesc		= 0;
	cInclude::filesize		= 0;
	cInclude::lookupon		= 0;
	cInclude::SavedTokenEnd	= 0;
	cInclude::SavedLinenumb	= 0;

	cDebug::Term( );

	cInput::GarbageCollect( );
	cOutput::GarbageCollect( );
	cInclude::GarbageCollect( );
}


void PrintConsole( const bool bIsError, const char* format, ... ) 
{
	va_list argptr;

	va_start( argptr, format );

	CommandLine::PrintConsole( PrintConsoleFlags( ( bIsError ? CommandLine::eError : 0 ) ), format, argptr );

	va_end( argptr );
}

unsigned int PrintConsoleFlags( const unsigned int uiPringFlags )
{
	return ( uiPringFlags | ( cOption::console_html ? CommandLine::eHtml : 0 ));
}

void CloseFilesHtmlTable( void )
{
	if ( bFilesBeginTable )
	{
		CommandLine::PrintConsole( PrintConsoleFlags( CommandLine::eNoEncoding | CommandLine::eNoSearchReplace ), pEndTable );

		bFilesBeginTable = false;
	}
}