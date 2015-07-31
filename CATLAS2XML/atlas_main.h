/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

#pragma once

#include <string>

class cOption
{
	public:
		static int comments;	// Comments output to the ".xml" file.
		static int console_html;// Console info output to ".con" file.
		static int debug;		// Debug info output to ".txt" file.
		static int echo;		// Echo source code to screen.
		static int exp;			// Expecting information for syntax errors.
		static int id;			// Add "id" attribute.
		static int include;		// Handle "include" files.
		static int lookup;		// Handle "lookup" files.
		static int numel;		// Add "num_element" attribute.
		static int spacing;		// Spacing for indentation in XML output.
		static int xmlfile;		// xml output file spec.
};

class cInput
{
	public:
		static unsigned char* input_start;			// First byte of input area.              
		static unsigned char* input_end;			// Byte after input.                      
		static unsigned char  dir[ 256 ];			// Directory (folder) of file.
		static unsigned char  filename[ 256 ];		// Filename of input file.
		static unsigned char  filetype[ 64 ];		// Filetype of input file.
		static unsigned char  path[ 256 ];			// Path to file (dir/fn.ft).
		static unsigned char  filename_ext[ 256 ];	// Path to file (fn.ft).
		static int filesize;
		static int filedesc;
		static int lookupon;
		static int segmenton;
		static int lastfile;
		static int quiton;
		static int help;
		static int tmBegin;

		static int Open( unsigned char* dir, unsigned char* fn, unsigned char* ft, int lu );
		static int Read( const char* pFileContents );
		static int Close( void );
		static void GarbageCollect( void );

	protected:

		static void AddInputStart( unsigned char* pInputStart );

		static unsigned char** input_start_array;
		static unsigned int input_array_size;
		static unsigned int input_array_count;
};

class cOutput 
{
	public:

		static void WriteXmlBuffer( const unsigned char* puchXML );
		static void WriteXmlFile( const unsigned char* puchXML );

		static const char* GetXmlBuffer( void ) { return pxml_buffer; }
		static unsigned int GetXmlBufferLen( void ) { return xml_buffer_pos; }

		static int Init( const unsigned char* fn );
		static void Term( void );

		static void GarbageCollect( void );

		static unsigned char dir[ 256 ];		// Directory.
		static unsigned char filename[ 256 ];	// File name.  
		static unsigned char filetype[ 64 ];	// File type.  

	protected:

		static FILE* filedesc;					// File descriptor.
		static char* pxml_buffer;
		static unsigned int xml_buffer_default_len;
		static unsigned int xml_buffer_len;
		static unsigned int xml_buffer_pos;
};

class cInclude
{
	public:
		static unsigned char* input_start;			// First byte of input area.              
		static unsigned char* input_end;			// Byte after input.                      
		static unsigned char dir[ 256 ];			// Directory of include file.
		static unsigned char filename[ 256 ];		// Filename of include file.
		static unsigned char filetype[ 64 ];		// Filetype of include file.
		static unsigned char path[ 256 ];			// Path of include file.
		static unsigned char filename_ext[ 256 ];	// Path to file (fn.ft).
		static int filesize;
		static int filedesc;
		static int lookupon;
		static unsigned char  SavedPath[ 256 ];	
		static unsigned char* SavedTokenEnd;
		static int SavedLinenumb;

		static int   Check( const unsigned char* fn );
		static int   Open( const unsigned char* dir, const unsigned char* fn, const unsigned char* ft, const int lu );
		static int   Read( void );
		static void  Save( void );
		static void  Reset( void );
		static void  GarbageCollect( void );

	protected:

		static void AddInputStart( unsigned char* pInputStart );

		static unsigned char** input_start_array;
		static unsigned int input_array_size;
		static unsigned int input_array_count;
};

class cDebug
{
	public:
		static unsigned char dir[ 256 ];		// Directory.
		static unsigned char filename[ 256 ];	// File name.  
		static unsigned char filetype[ 64 ];	// File type.  
		static FILE* filedesc;					// File descriptor.

		static int Init( const unsigned char* fn );
		static void Term( void );
};

extern void PrintConsole( const bool bIsError, const char* format, ... );
extern unsigned int return_code;
extern unsigned char  primary_filename[ 256 ];
extern const unsigned char* major_version;
extern const unsigned char* minor_version;
extern const unsigned char* build_num;
extern const unsigned char* build_date;
extern const unsigned char* copyright_year;
extern unsigned char uppercase[ 256 ];

#define RC_NO_ERRORS				0x00000
#define RC_NO_FILESPEC				0x00001	// 1
#define RC_INVALID_FILESPEC			0x00002	// 2
#define RC_INVALID_OPTION			0x00004	// 4
#define RC_FILE_NOT_FOUND			0x00008	// 8
#define RC_FILE_READ_ERROR			0x00010	// 16
#define RC_FILE_WRITE_ERROR			0x00020	// 32
#define RC_INCLUDE_ERROR			0x00040	// 64
#define RC_SYNTAX_ERROR				0x00080	// 128
#define RC_SYMBOL_OVERFLOW			0x00100	// 256
#define RC_AST_OVERFLOW				0x00200	// 512
#define RC_MEMORY_OVERFLOW			0x00400	// 1024
#define RC_INTERNAL_ERROR			0x00800	// 2048
#define RC_UNKNOWN_STATEMENT		0x01000	// 4096
// If adding more, update functon "Quit". 

class CommandLine;
class AtlasStatistics;

int main( const int iArgCount, const unsigned char* arrayArgs[ ] );
unsigned char* Number( const int x );
unsigned char* Number( const int x, const char* pFormat );
unsigned char* Number( const unsigned char* pnum, const char* pFormat );
int	ReadBuildFile( unsigned char* dir, unsigned char* fn, unsigned char* ft, unsigned char**& filespec, const char* pFileContents );
int Split( unsigned char* arg, unsigned char* dir, unsigned char* fn, unsigned char* ft, unsigned char* def );
unsigned int PrintConsoleFlags( const unsigned int uiPringFlags = 0 );
void CloseFilesHtmlTable( void );
void Init( void );
void Init( const int iArgCount, const unsigned char* arrayArgs[ ] );
void BeginParse( const int iArgCount, const unsigned char* arrayArgs[ ] );
int ParseAtlas( const CommandLine* pCommandLine );
void Quit( const AtlasStatistics* pAtlasStatistics );
void DisplayErrorMessage( void );
void DisplayStatistics( const AtlasStatistics* pAtlasStatistics );
