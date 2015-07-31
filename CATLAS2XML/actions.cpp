/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

#include <stdio.h>
#include <string.h>
#include <io.h>
#include "atlas_main.h"
#include "actions.h"

#if ( _DEBUG ) && ( WIN32 )
	#define WINVER 0x0600
	#include <afx.h>
	#define new DEBUG_NEW
	#undef THIS_FILE
	static char BASED_CODE THIS_FILE[ ] = __FILE__;
#endif																						 

#define EOF_CHAR 26 // End Of file marker.

unsigned int token_action::uiEntryPoint_count = 0;

uchar parse_action::includefile[ 256 ];
int   parse_action::define_name;

const unsigned int node_action::stmtnum_len = 6;
const unsigned int node_action::testnum_len = 4;
int   node_action::argno;
uchar node_action::xmlout[ 2048 ];
uchar node_action::indent[ 1024 ];
uchar node_action::idattr[ 32 ];
uchar node_action::neattr[ 32 ];

uchar node_action::last_stmtnum[ stmtnum_len + 1 ] = { 0 };
uchar node_action::last_testnum[ testnum_len + 1 ] = { 0 };
int   node_action::tagid = 0;
int   node_action::segment = 0;
int   node_action::process_commentblock = 0;

///////////////////////////////////////////////////////////////////////////////
//                                                                           // 
//		Token Actions

///////////////////////////////////////////////////////////////////////////////
//                                                                           // 

int token_action::CNXoff( int& t )
{
	CNXon = 0;
	return 0;
}

///////////////////////////////////////////////////////////////////////////////
//                                                                           // 

int token_action::CNXcheck( int& t )
{
	if ( CNXon )
	{
		t = T_PARTNO;

		while ( *token.end != ' ' && *token.end != '\t' && *token.end != '\n' && *token.end != ',' )
		{
			*token.end++;
		}

		return lookup( t );
	}

	return 0;
}

///////////////////////////////////////////////////////////////////////////////
//                                                                           // 

int token_action::CNXlookup( int& t )
{
	if ( CNXon )
	{
		t = T_PARTNO;
		
		while ( ( ' ' != *token.end ) && ( '\t' != *token.end ) && ( '\n' != *token.end ) && ( ',' != *token.end ) )
		{
			*token.end++;
		}
		
		return lookup( t );
	}
	
	return lookup( t );
}

///////////////////////////////////////////////////////////////////////////////
//                                                                           // 

int token_action::commentblock( int& t )
{
	// Goto '$' ...
A:		while ( ( '$' != *token.end ) && ( EOF_CHAR != *token.end ) )
		{
			if ( '\n' == *token.end++ )
			{
				linenumb++;
			}
		}

		if ( EOF_CHAR == *token.end )
		{
			t = 0; 
			return 0;
		}

	// Goto end of line ...
B:		while ( '\n' != *token.end )
		{
			token.end++;
		}

	// Bypass any more end of lines ...
C: 	do 
		{
			linenumb++;
			token.end++;
		}
		while ( '\n' == *token.end );

	// Check first character on the line for 'C'
   	const uchar ch = uppercase[ *token.end ];

	if ( 'C' == ch ) 
	{
		goto A;
	}

	// Check first character on the line for E or B...
	if ( ( 'E' == ch ) || ( 'B' == ch ) )
	{
	//	*token.end = ' '; old version
	//	token.end++;		old version
	//	goto D;				old version
	// new version 2015.01.16 pbm.
		*token.end--;	   // back up to '\n'.
		linenumb--;			// decrement line number. 
		goto D;        
	}    

	// Bypass blanks and tabs ...
	while ( ( ' ' == *token.end ) || ( '\t' == *token.end ) )
	{
		token.end++;
	}

	if ( '$' == *token.end )
	{
		goto B;
	}

	if ( '\n' == *token.end )
	{
		goto C;
	}

	if ( EOF_CHAR == *token.end ) // At <eof>?
	{
		// Segmented files sometimes have a comment at the end,
		// which causes an error on the next file read, so we 
		// have to ignore this comment at the <eof>. 
		//
		//	PrintConsole( false, "Ignoring comment at <eof>\n" );

		return -1; // Ignore this comment. 
	}

D:	if ( ( 0 == nd_mode ) && cOption::comments )
	{
	  	return lookup( t );
	}

	return 0;
}

///////////////////////////////////////////////////////////////////////////////
//                                                                           // 

int token_action::branchblock( int& t )
{
	// Goto '$' ...
A:		while ( ( '$' != *token.end ) && ( EOF_CHAR != *token.end ) )
		{
			if ( '\n' == *token.end++ )
			{
				linenumb++;
			}
		}

		if ( EOF_CHAR == *token.end )
		{	
			t = 0; 
			return 0;
		}

	// Goto end of line ...
B:		while ( '\n' != *token.end )
		{
			token.end++;
		}

	// Bypass any more end of lines ...
C:		do 
		{
			linenumb++;
			token.end++;
		}
		while ( '\n' == *token.end );

	// Check first character on the line for 'B'
   	const uchar ch = uppercase[ *token.end ];
	if ( 'B' == ch ) 
	{
		goto A;
	}

	// Check first character on the line for E or C...
	if ( ( 'E' == ch ) || ( 'C' == ch ) )
	{
		*token.end--;	   // back up to '\n'.
		linenumb--;			// decrement line number. 
		goto D;        
	}    

	// Bypass blanks and tabs ...
	while ( ( ' ' == *token.end ) || ( '\t' == *token.end ) )
	{
		token.end++;
	}

	if ( '$' == *token.end )
	{
		goto B;
	}
	
	if ( '\n' == *token.end )
	{
		goto C;
	}

	if ( EOF_CHAR == *token.end ) // At <eof>?
	{
		// Segmented files sometimes have a comment at the end,
		// which causes an error on the next file read, so we 
		// have to ignore this comment at the <eof>. 
		//
		//	PrintConsole( false, "Ignoring comment at <eof>\n" );
	
		return -1; // Ignore this comment. 
	}

D:	if ( 0 == nd_mode )
	{
	  	return lookup( t );
	}

	return 0;
}


///////////////////////////////////////////////////////////////////////////////
//                                                                           // 

int token_action::lucomment( int& t )
{
	if ( '\n' == *token.start )
	{
		token.start++;
		token.linenumb++;
	}

A:	while ( '\n' != *token.end )
	{
		token.end++;
	}

B:	token.end++; // skip over \n
	linenumb++;

	if ( '*' == *token.end )
	{
		goto A;
	}
	
	if ( '\n' == *token.end )
	{
		goto B;
	}

	while ( ( ' ' == *token.end ) || ( '\t' == *token.end ) )
	{
		token.end++; 
	}
	
	if ( '\n' == *token.end )
	{
		goto B;
	}
	
	if ( '\n' == *--token.end )
	{
		linenumb--;
	}
	
	if ( ( 0 == nd_mode ) && cOption::comments )
	{
		return lookup( t );
	}
	
	return 0;
}

///////////////////////////////////////////////////////////////////////////////
//                                                                           // 

int token_action::datablock( int& t )					// Look for Symbol.
{
	linenumb++;
	token.linenumb++;

   	while ( ( '$' != *token.end ) && ( EOF_CHAR != *token.end ) )
	{
		if ( '\n' == *token.end++ )
		{
			linenumb++;
		}
	}

	if ( EOF_CHAR == *token.end )
	{	
		t = 0; 
		return 0;
	}

	if ( 0 == nd_mode )										// If not in ND parsing mode.			
	{
		int sti;											// Symbol-table index.
		sti = add_symbol( t, token.start + 1, token.end );	// Add to symbol table. 
		return sti;											// Return symbol-table index. 
	}

	return 0;
}

///////////////////////////////////////////////////////////////////////////////
//                                                                           // 

int token_action::codeblock( int& t )
{
	linenumb++;
	token.linenumb++;
	
	while ( ( '$' != *token.end ) && ( EOF_CHAR != *token.end ) )
	{
		if ( '\n' == *token.end++ )
		{
			linenumb++;
		}
	}

	if ( EOF_CHAR == *token.end )
	{
		t = 0; 
		return 0;
	}

	// Back up to beginning of RESUME statement ...	
	while ( '\n' != *token.end )
	{
		token.end--;
	}

	token.end++;

	if ( 0 == nd_mode )
	{
		int sti;											// Symbol-table index.

		sti = add_symbol( t, token.start + 1, token.end );	// Add to symbol table. 

		return sti;											// Return symbol-table index. 
	}

	return 0;
}

///////////////////////////////////////////////////////////////////////////////
//                                                                           // 

int token_action::checkeof( int& t )
{
	if ( includeon )						// Processing an include file?
	{
		t = arg_numb[ tact_arg[ t ] ];		// Return {inceof} token.
	}
	else if ( lookupon )					// Processing a lookup file?
	{
		t = arg_numb[ tact_arg[ t ] ];		// Return {inceof} token.
	}

	return 0;								// Return continue. 
}

///////////////////////////////////////////////////////////////////////////////
//                                                                           // 

int token_action::error( int& t )
{
	if ( token.end == token.start )
	{
		token.end++;
	}

	return 0; 
}

///////////////////////////////////////////////////////////////////////////////
//                                                                           // 

int token_action::lookup( int& t ) // Look for Symbol.
{
	if ( 0 == nd_mode )
	{
		int sti;										// Symbol-table index.

		sti = add_symbol( t, token.start, token.end );	// Add to symbol table. 

		return sti;										// Return symbol-table index. 
	}

	return 0;
}

///////////////////////////////////////////////////////////////////////////////
//                                                                           // 

int token_action::firstid( int& t ) // Look for Symbol.
{
	if ( lookupon ) // In lookup file?
	{
		if ( 0 == nd_mode ) // Not in lookahead parser?
		{
			if ( '\n' == *token.start )
			{
				token.start++;
				token.linenumb++;
			}

			int sti = add_symbol( t, token.start, token.end );	// Add to symbol table. 

			return sti; // Return symbol-table index. 
		}

		return 0;
	}
	else // In ATLAS file!
	{
		if ( '\n' == *token.start ) // If at beginning of line.
		{
			token.start++;
			token.linenumb++;

			switch ( uppercase[ *token.start ] )
			{
				case '0': 
				case '1': 
				case '2': 
				case '3': 
				case '4': 
				case '5': 
				case '6': 
				case '7': 
				case '8': 
				case '9': 
				{
					t = T_INTEGER;

					if ( 0 == nd_mode )
					{
						return lookup( t );
					}
					else 
					{
						return 0;
					}
				}
				case 'B': 
				{
					t = T_BRANCH_TARGET;
					return branchblock( t );
				}
				case 'C': // Comment.
				{
					t = T_COMMENT;
					return commentblock( t );
				}
				case 'E': 
				{
					//token.end = token.start+1;			// REMOVED 20150120 by PBM.
					//return -1; // Skip over this token.	// REMOVED 20150120 by PBM.

					int iRet = 0;

					++uiEntryPoint_count;

					if ( 1 == uiEntryPoint_count )
					{
						// *** HACK ALERT *** by Jonathan Ott  3/19/2015
						//
						// This is a total hack for handling 'E's on the "BEGIN, ATLAS" statement.
						// 'E's are handled correctly for other statement types. But not with the 
						// "BEGIN, ATLAS" statement. It's probably something in the grammar file,
						// I'm just not sure. Returning zero in from this method means "skip this 
						// token" (the 'E'). We don't really want to skip it, but if the execution 
						// continues as before, the following error occurs:
						// 
						// r-1379.as(17) : Error  E000100  BEGIN, ATLAS PROGRAM 'R-1379'
						// r-1379.as(17) : Error -^ at E {entry_point}
						//
						// Parse stack:
						//
						//           2 lookup_file
						//          94 comment
						//          50 fstatno
						//
						// In state 7, expecting one of the following:
						//
						//           2 <integer>
						//          45 'BEGIN'
						//
						//
						// Actually, it doesn't make any sense for an 'E' to be used on the "BEGIN, 
						// ATLAS" statement. But in one of the 18 test cases, it was used that way. 
						// With this special HACK handling, no ENTRY_POINT element is placed in the 
						// XML, so there is no record of there ever being an 'E' on the "BEGIN, ATLAS" 
						// statement. But since the "BEGIN, ATLAS" statement doesn't actually "execute", 
						// it really doesn't matter.

						const char* pchBeginAtlas = "BEGIN,ATLASPROGRAM";
						const unsigned int uiBeginAtlasLength = 18;
						char chBeginAtlas[ uiBeginAtlasLength + 1 ];
						unsigned short uiPos = 0;

						uchar* puchStart = token.end;

						while ( ( 0 != *puchStart++ ) && ( uiPos < uiBeginAtlasLength ) )
						{
							if ( ' ' != *puchStart )
							{
								chBeginAtlas[ uiPos++ ] = *puchStart;
							}
						}

						if ( uiBeginAtlasLength == uiPos )
						{
							chBeginAtlas[ uiBeginAtlasLength ] = 0;

							if ( 0 == strncmp( chBeginAtlas, pchBeginAtlas, uiBeginAtlasLength ) )
							{
								iRet = -1;
							}
						}
					}

					if ( 0 == iRet )
					{
						token.end = token.start+1;				// ADDED 20150120 by PBM.
						t = T_ENTRY;							// ADDED 20150120 by PBM.

						if ( ( ' ' == *token.end ) || ( '\'' == *token.end ) )
						{
							iRet = -1;
						}
					}

					return iRet;
				}
			}

			return 0; // Don't store in symbol table.
		}

		if ( 0 == CNXon ) // Not in CNX exception?
		{
			uchar *p = token.start;

			while ( p < token.end )
			{
				switch ( *p )
				{
					case '0': 
					case '1': 
					case '2': 
					case '3': 
					case '4': 
					case '5': 
					case '6': 
					case '7': 
					case '8': 
					case '9': 
					{
						t = T_INTEGER;
						p++; // continue
						break;
					}
					default:
					{
						if ( p > token.start ) // Any digits seen yet?
						{
							token.end = p;		// Separate the digits from the rest.
						}

						goto Done;
					}
				}
			}
		}

Done:	if ( 0 == nd_mode )
		{
			return lookup( t );
		}

		return 0; // Don't store in symbol table.
	}
}

///////////////////////////////////////////////////////////////////////////////
//                                                                           // 
//		Parse Actions

///////////////////////////////////////////////////////////////////////////////
//                                                                           // 

int parse_action::Keyword( int p )
{
	CNXon = 1;

	return 1;
}

///////////////////////////////////////////////////////////////////////////////
//                                                                           // 

int parse_action::BEGIN_ATLAS_PROGRAM( int p ) 
{
	in_pgm = 1;
	in_mod = 0;
	in_seg = 0;
	n_pgm_statements = 1;

	return 1; // OK
}

///////////////////////////////////////////////////////////////////////////////
//                                                                           // 

int parse_action::TERMINATE_ATLAS_PROGRAM( int p )
{
	in_pgm = 0;
	in_mod = 0;
	in_seg = 0;

	return 1; // OK
}

///////////////////////////////////////////////////////////////////////////////
//                                                                           // 

int parse_action::BEGIN_ATLAS_MODULE( int p ) 
{
	if ( in_pgm )
	{
		n_pgm_statements--;
	}

	in_pgm = 0;
	in_mod = 1;
	in_seg = 0;
	n_mod_statements = 1;

	return 1; // OK
}

///////////////////////////////////////////////////////////////////////////////
//                                                                           // 

int parse_action::TERMINATE_ATLAS_MODULE( int p )
{
	in_pgm = 1;
	in_mod = 0;
	in_seg = 0;

	return 1; // OK
}

///////////////////////////////////////////////////////////////////////////////
//                                                                           // 

int parse_action::SEGMENT( int p )
{
	n_statements--;						// Don't count SEGMENT statement.

	if ( in_pgm )						// Don't count SEGMENT statement.
	{
		n_pgm_statements--;  
	}

	in_pgm = 0;
	in_mod = 0;
	in_seg = 1;
	n_seg_statements = 0;				// Don't count SEGMENT statement.

	return 1; // OK
}

///////////////////////////////////////////////////////////////////////////////
//                                                                           // 

int parse_action::END_SEGMENT( int p )
{
	n_statements--;						// Don't count END_SEGMENT statement.
	in_pgm = 1;
	in_mod = 0;
	in_seg = 0;
	n_seg_statements--;					// Don't count END_SEGMENT statement.

	return 1; // OK
}

///////////////////////////////////////////////////////////////////////////////
//                                                                           // 

int parse_action::StatementNumber( int p )
{
	n_statements++;

	if ( in_pgm )
	{
		n_pgm_statements++;
	}

	if ( in_mod )
	{
		n_mod_statements++;
	}

	if ( in_seg )
	{
		n_seg_statements++;
	}

	return 1; // OK
}

///////////////////////////////////////////////////////////////////////////////
//                                                                           // 

int parse_action::UnknownVerb( int p ) 
{
	n_unknowns++;

	int i = pact_arg[ p ];
	int a = arg_numb[ i ];
	int sti = PS[ a - 1 ].sti;
	
	PrintConsole( false, "%s(%d) : Unknown statement verb \"%s\" here.\n", path, linenumb, symbol_name( sti ) );
	
	return_code |= RC_UNKNOWN_STATEMENT;
	
	return 1; // OK
}

///////////////////////////////////////////////////////////////////////////////
//                                                                           // 

int parse_action::Filename( int pr )
{
	int i = pact_arg[ pr ];					// Get first argument index.
	int sti = PS[ arg_numb[ i ] - 1 ].sti;	// Get sti for first argument.

	strcpy( ( char* ) includefile, ( char* ) remove_quotes( symbol_name( sti ) ) );

	uchar* p = includefile;
	uchar* q = includefile;

	for ( p = includefile; 0 != *p; p++ )
	{
		if ( ( ' ' != *p ) && ( '\t' != *p ) )
		{
			*q++ = *p;
		}
	}

	*q = 0;

	return 1; // OK
}

///////////////////////////////////////////////////////////////////////////////
//                                                                           // 

int parse_action::INCLUDE_ATLAS_MODULE( int p )
{
	if ( cOption::include )
	{
		n_includefiles++;
		cInclude::Check( includefile );

		if ( cOption::lookup )
		{ 
			cInclude::Save( );

			if ( 0 == cInclude::Open( cInput::dir, cInclude::filename, ( uchar* ) ".lu", 1 ) )
			{
				goto A; 
			}

			cInclude::Read( );
			lexer::init( cInclude::path, 1, 1, cInclude::input_start, 3, 0 );
		}
		else 
		{ 
			cInclude::Save( );
A:			cInclude::Open( cInput::dir, cInclude::filename, cInclude::filetype, 0 );
			cInclude::Read( );
			lexer::init( cInclude::path, 1, 0, cInclude::input_start, 3, 0 );
		}
	}

	return 1; 
}

///////////////////////////////////////////////////////////////////////////////
//                                                                           // 

int parse_action::Lookup( int pr ) 
{
	if ( includeon )	// Include file?
	{
		cInclude::Open( cInput::dir, cInclude::filename, cInclude::filetype, 0 );
		cInclude::Read( );
		lexer::init( cInclude::path, 1, 0, cInclude::input_start, 3, 0 );
	}
	else				// Original file! 
	{
		cInput::Open( cInput::dir, cInput::filename, cInput::filetype, 0 );
		cInput::Read( 0 );
		lexer::init( cInput::path, 0, 0, cInput::input_start, 3, 0 );
	}

	return 1; 
}

///////////////////////////////////////////////////////////////////////////////
//                                                                           // 

int parse_action::IncludeFile( int p ) // Not needed.    
{
	if ( cOption::include )
	{
		cInclude::Reset( );
	}

	return 1; // OK
}

///////////////////////////////////////////////////////////////////////////////
//                                                                           // 

int parse_action::Message( int p )
{
	while ( '\n' != *token.end )
	{
		token.end++;
	}

	*token.end = 0x01; // Replace '\n' with 0x01 for "data".
	//linenumb++;  // REMOVED 20141124 by PBM.

	return 1; // OK
}



///////////////////////////////////////////////////////////////////////////////
//                                                                           // 

int parse_action::UsingDevice( int pr )
{
/*		int i = pact_arg[pr];
		int a = arg_numb[i];
		int sti = PS[a-1].sti;
		if (strcmp (symbol_name(sti), "'CRT'"    ) == 0
		||	 strcmp (symbol_name(sti), "'PRINTER'") == 0)
*/
	uchar* x; 
	uchar* p = token.end; 
	
	while ( ( ' ' == *p ) || ( '\t' == *p ) )	// Passover whitespace.
	{
		p++;
	}
	
	if ( ',' == *p ) 
	{
		p++;								// Skip over ','						   

		while ( ( ' ' == *p ) || ( '\t' == *p ) )		// Passover whitespace.
		{
			p++;	
		}
	}
	
	//while (*p != '\n' && *p != '$') p++;
	while ( ( '\n' != *p ) && ( '$' != *p ) && ( 0x01 != *p ) )	// Fixed 20141002 by PBM.
	{
		p++;	
	}
	
	if ( '\n' == *p )
	{
		x = p--;

		while ( ( ' ' == *p ) || ( '\t' == *p ) )
		{
			p--;
		}

		if ( ( ',' == *p ) || ( '\'' == *p ) )	// Replace '\n' with 0x01 for "data".
		{
			*x = 0x01;
		}
	}
	
	return 1; // OK
}

///////////////////////////////////////////////////////////////////////////////
//                                                                           // 

int parse_action::LEAVE_ATLAS( int prod )
{
	while ( '$' != *token.start )
	{
		token.start--;
	}
	
	token.end = token.start+1;
	
	while ( '\n' != *token.end )	// Go to end of line character.
	{
		token.end++;
	}
	
	*token.end = 0x02; // Code block character. 
	
	return 1; // OK
}

///////////////////////////////////////////////////////////////////////////////
//                                                                           // 

int parse_action::AtlasProgram( int prod )
{
	// Set statement count in next node to be created ... 

	node[ n_nodes ].stmt = n_pgm_statements; // Stuff this number in stmt. 

	return 1; // OK
}

///////////////////////////////////////////////////////////////////////////////
//                                                                           // 

int parse_action::AtlasModule( int prod )
{
	// Set statement count in next node to be created ... 

	node[ n_nodes ].stmt = n_mod_statements; // Stuff this number in stmt. 

	return 1; // OK
}

///////////////////////////////////////////////////////////////////////////////
//                                                                           // 

int parse_action::Segment( int prod )
{
	// Set statement count in next node to be created ... 

	node[ n_nodes ].stmt = n_seg_statements; // Stuff this number in stmt. 

	return 1; // OK
}

///////////////////////////////////////////////////////////////////////////////
//                                                                           // 
//		Node Actions

///////////////////////////////////////////////////////////////////////////////
//                                                                           // 

int node_action::AtlasProgram( int n )
{
	if ( 2 == cOption::debug )
	{
		PrintConsole( false, "-> AtlasProgram\n" );
	}

	switch ( status )
	{
		case TOP_DOWN:	 
		{
			int nc = 0;	

			for ( int c = node[ n ].child; c != 0; c = node[ c ].next )
			{
				nc++;
			}

			if ( cOption::id )
			{
				sprintf( ( char* ) idattr, " id=\"%d\"", ++tagid );
			}
			else
			{
				*idattr = 0;
			}

			if ( cOption::numel )
			{
				sprintf( ( char* ) neattr, " num_element=\"%d\"", nc );
			}
			else
			{
				*neattr = 0;
			}

			sprintf( ( char* ) xmlout, "<%s%s%s num_stmt=\"%d\">\n", 
				node_name[ node[ n ].id ], idattr, neattr, node[ n ].stmt );

			emitstr( xmlout );
		}
		break;

		case PASS_OVER: 
			break;

		case BOTTOM_UP: 
			sprintf( ( char* ) xmlout, "</%s>\n", node_name[ node[ n ].id ] );
			emitstr( xmlout );
			break;
	}

	return 1; // OK
}

///////////////////////////////////////////////////////////////////////////////
//                                                                           // 

int node_action::AtlasModule( int n )
{
	if ( 2 == cOption::debug )
	{
		PrintConsole( false, "-> AtlasModule\n" );
	}

	switch ( status )
	{
		case TOP_DOWN:	 
		{
			int nc = 0;	

			for ( int c = node[ n ].child; 0 != c; c = node[ c ].next )
			{
				nc++;
			}

			if ( cOption::id )
			{
				sprintf( ( char* ) idattr, " id=\"%d\"", ++tagid );
			}
			else
			{
				*idattr = 0;
			}

			if ( cOption::numel )
			{
				sprintf( ( char* ) neattr, " num_element=\"%d\"", nc );
			}
			else
			{
				*neattr = 0;
			}

			sprintf( ( char* ) xmlout, "<%s%s%s num_stmt=\"%d\">\n", 
				node_name[ node[ n ].id ], idattr, neattr, node[ n ].stmt );

			emitstr( xmlout );
		}
		break;

		case PASS_OVER: 
			break;

		case BOTTOM_UP: 
			sprintf( ( char* ) xmlout, "</%s>\n", node_name[ node[ n ].id ] );
			emitstr( xmlout ); 
			break;
	}

	return 1; // OK
}

///////////////////////////////////////////////////////////////////////////////
//                                                                           // 

int node_action::Segment( int n )
{
	if ( 2 == cOption::debug )
	{
		PrintConsole( false, "-> Segment\n" );
	}

	switch ( status )
	{
		case TOP_DOWN:	 
		{
			/*
				+ SegmentFile
				| + SEGMENT (000000)
				| | + StatementNumber (000000)
				| | + Name ('2053as218_1')
			*/

			int nc = 0;	

			for ( int c = node[ n ].child; 0 != c; c = node[ c ].next )
			{
				nc++;
			}

			int x = node[ n ].child;			
				x = node[ x ].child;
			    x = node[ x ].next;		
				x = node[ x ].sti;	

			if ( cOption::id )
			{
				sprintf( ( char* ) idattr, " id=\"%d\"", ++tagid );
			}
			else
			{
				*idattr = 0;
			}

			if ( cOption::numel )
			{
				sprintf( ( char* ) neattr, " num_element=\"%d\"", nc );
			}
			else
			{
				*neattr = 0;
			}

			sprintf( ( char* ) xmlout, "<%s%s%s num=\"%d\" name=\"%s%s%s\" num_stmt=\"%d\">\n", 
				node_name[ node[ n ].id ], idattr, neattr, ++segment, cInput::dir, remove_quotes( symbol_name( x ) ), cInput::filetype, node[ n ].stmt );
			emitstr( xmlout ); 
		}
		break;

		case PASS_OVER:
			break;

		case BOTTOM_UP: 
			sprintf( ( char* ) xmlout, "</%s>\n", node_name[ node[ n ].id ] );
			emitstr( xmlout);
			break;
	}

	return 1; // OK
}

///////////////////////////////////////////////////////////////////////////////
//                                                                           // 

int node_action::BranchTarget( int n )
{
	if ( 2 == cOption::debug )
	{
		PrintConsole( false, "-> BRANCH_TARGET\n" );
	}

	switch ( status )
	{
		case TOP_DOWN:	 
			if ( cOption::id )
			{
				sprintf( ( char* ) idattr, " id=\"%d\"", ++tagid );
			}
			else
			{
				*idattr = 0;
			}
	
			sprintf( ( char* ) xmlout, "<BRANCH_TARGET%s line=\"%04d\">\n", idattr, node[ n ].line ); 
			emitstr( xmlout );
			CommentLines( n );
			break;

		case PASS_OVER: 
			break;

		case BOTTOM_UP: 
	  		emitstr( ( uchar* ) "</BRANCH_TARGET>\n" ); 
			break;
	}

    return 1; // OK
}

///////////////////////////////////////////////////////////////////////////////
//                                                                           // 

int node_action::EntryPoint( int n )
{
	if ( 2 == cOption::debug )
	{
		PrintConsole( false, "-> ENTRY_POINT\n" );
	}

	int i = node[ n ].sti;					// Symbol name index

	switch ( status )
	{
		case TOP_DOWN:	 
			if ( cOption::id )
			{
				sprintf( ( char* ) idattr, " id=\"%d\"", ++tagid );
			}
			else
			{
				*idattr = 0;
			}

			if ( 0 == strcmp( ( char* ) symbol_name( i ), "{entry_point}" ) )
			{
  				sprintf( ( char* ) xmlout, "<ENTRY_POINT%s line=\"%04d\"/>\n", idattr, node[ n ].line );
	  			emitstr( xmlout );

				if ( cOption::spacing )
				{
					indent[ strlen( ( char* ) indent ) - 2 ] = 0;
				}
			}
			else
			{
  				sprintf( ( char* ) xmlout, "<ENTRY_POINT%s line=\"%04d\">\n", idattr, node[ n ].line ); 
	  			emitstr( xmlout );
				CommentLines( n );
			}
			break;

		case PASS_OVER: 
			break;

		case BOTTOM_UP: 
			if ( 0 != strcmp( ( char* ) symbol_name( i ), "{entry_point}" ) )
			{
	  			emitstr( ( uchar* ) "</ENTRY_POINT>\n" ); 
			}
			break;
	}

    return 1; // OK
}


///////////////////////////////////////////////////////////////////////////////
//                                                                           // 

int node_action::CommentBlock( int n )
{
	int iRet = 0;  // Not OK

	if ( 2 == cOption::debug )
	{
		PrintConsole( false, "-> CommentBlock\n" );
	}

	// NOTE: The "process_commentblock" variable is a hack to handle multiple 
	// comments per comment block. One Atlas 'C' statement should have been 
	// considered one comment block. But one 'C' statement followed by another 
	// is a comment block as far as the way the grammar was designed. Using this 
	// variable, the outer "CommentBlock" element is created when function 
	// CommentLines is called.

	if ( cOption::comments && process_commentblock )
	{
		switch ( status )
		{
			case TOP_DOWN:	 
				if ( cOption::id )
				{
					sprintf( ( char* ) idattr, " id=\"%d\"", ++tagid );
				}
				else
				{
					*idattr = 0;
				}

				if ( 0 != node[ n ].child )
				{																	   
			  		sprintf( ( char* ) xmlout, "<CommentBlock%s>\n", idattr );
			  		emitstr( xmlout );

					iRet =	1;
				}
				break;

			case PASS_OVER: 
				break;

			case BOTTOM_UP: 
				if ( 0 != node[ n ].child )
				{
				  	emitstr( ( uchar* ) "</CommentBlock>\n" ); 
					iRet =	1;
				}
				break;
		}
	}

	return iRet;
}

///////////////////////////////////////////////////////////////////////////////
//                                                                           // 

int node_action::CommentLines( int n )
{
	if ( 2 == cOption::debug )
	{
		PrintConsole( false, "-> CommentLines\n" );
	}

	if ( cOption::comments )
	{
		switch ( status )
		{
			case TOP_DOWN:	 
			{
				int iCommentBlockRet = 1;
				int iOpenCommentBlock = 0;
				uchar* x;
				uchar ch;
				uchar line[ 256 ];
				int sti = node[ n ].sti;
				int lineno = node[ n ].line;	
				uchar* p = symbol[ sti ].name;
				int iTerm = symbol[ sti ].term;
				uchar* end = ( p + symbol[ sti ].length );

			A:	*p  = ' ';	// Atlas comments leadoff with a 'C', change it to a space

				if ( T_COMMENT == iTerm )
				{
					status = TOP_DOWN;
					process_commentblock = 1;
					iCommentBlockRet = CommentBlock( node[ n ].parent );
					process_commentblock = 0;
				}

				if ( iCommentBlockRet )
				{
					iOpenCommentBlock = 1;

					do 
					{
						x = line;
			
						while ( ( '\n' != *p ) && ( '$' != *p ) && ( p < end ) )
						{
							*x++ = *p++;
						}
			
						ch = *p++;
						x--;
			
						while ( ( ' ' == *x ) || ( '\t' == *x ) )
						{
							x--;
						}
			
						*++x = 0;
			
						for ( x = line; ( ' ' == *x ) || ( '\t' == *x ); x++ );
			
						x = convert_xml( x );
			
						if ( cOption::id )
						{
							sprintf( ( char* ) idattr, " id=\"%d\"", ++tagid );
						}
						else
						{
							*idattr = 0;
						}
			
						if ( 0 == *x )
						{
					  	     sprintf( ( char* ) xmlout, "<Comment%s line=\"%04d\"/>\n", idattr, lineno++ );
						}
						else
						{
							sprintf( ( char* ) xmlout, "<Comment%s line=\"%04d\">%s</Comment>\n", idattr, lineno++, x );
						}
			
						emitstr( xmlout );
			
						if ( cOption::spacing )
						{
							indent[ strlen( ( char* ) indent ) - 2 ] = 0;
						}
			
						if ( p >= end )
						{
							break;
						}
					}
					while ( '$' != ch );
				
				B:	while ( '\n' != *p )
					{
						p++;
					}
				
					if ( ++p < end )
					{
						if ( 'C' == *p )
						{
							if ( ( T_COMMENT == iTerm ) && iOpenCommentBlock )
							{
								status = BOTTOM_UP;
								process_commentblock = 1;
								CommentBlock( node[ n ].parent );
								process_commentblock = 0;
								iOpenCommentBlock = 0;
							}

							goto A; 
						}
				
						goto B;
					}

					if ( ( T_COMMENT == iTerm ) && iOpenCommentBlock )
					{
						status = BOTTOM_UP;
						process_commentblock = 1;
						CommentBlock( node[ n ].parent );
						process_commentblock = 0;
						iOpenCommentBlock = 0;
					}
				}
		
				break;
			}
			break;

			case PASS_OVER:
				break;

			case BOTTOM_UP: 
				break;
		}
	}

	return 1; // OK
}

///////////////////////////////////////////////////////////////////////////////
//                                                                           // 

int node_action::LUCommentLines( int n )
{
	if ( 2 == cOption::debug )
	{
		PrintConsole( false, "-> LUCommentLines\n" );
	}

	if ( cOption::comments )
	{
		switch ( status )
		{
			case TOP_DOWN:	 
			{
				int lineno = node[ n ].line;		// Get line number.
				uchar line[ 256 ];
				int sti = node[ n ].sti;
				uchar* a = symbol[ sti ].name;
				uchar* end = a + symbol[ sti ].length;
				uchar* b = a;
				uchar* x;
				uchar ch;

				if ( cOption::id )
				{
					sprintf( ( char* ) idattr, " id=\"%d\"", ++tagid );
				}
				else
				{
					*idattr = 0;
				}

			  	sprintf( ( char* ) xmlout, "<CommentBlock%s>\n", idattr );
			  	emitstr( xmlout );

				do 
				{
					x = line;

					while ( ( '\n' != *b ) && ( b < end ) )
					{
						*x++ = *b++;
					}

					if ( '\n' != *b )
					{
						goto A;
					}

					ch = *b++;
					x--;

					while ( ( ' ' == *x ) || ( '\t' == *x ) )
					{
						x--;
					}

					*++x = 0;

					for ( x = line; ( ' ' == *x ) || ( '\t' == *x ); x++ );

					x = convert_xml( x );

					if ( cOption::id )
					{
						sprintf( ( char* ) idattr, " id=\"%d\"", ++tagid );
					}
					else
					{
						*idattr = 0;
					}

					if ( 0 == *x )
					{
				  	     sprintf( ( char* ) xmlout, "<Comment%s line=\"%04d\"/>\n", idattr, lineno++ );
					}
					else
					{
						sprintf( ( char* ) xmlout, "<Comment%s line=\"%04d\">%s</Comment>\n", idattr, lineno++, x );
					}

					emitstr( xmlout );

					if ( cOption::spacing )
					{
						indent[ strlen( ( char* ) indent ) - 2 ] = 0;
					}
				}
				while ( '\n' == ch );

A:				if ( cOption::spacing )
				{
					indent[ strlen( ( char* ) indent ) - 2 ] = 0;
				}

			  	emitstr( ( uchar* ) "</CommentBlock>\n" );

				if ( cOption::spacing )
				{
					indent[ strlen ( ( char* ) indent ) - 2 ] = 0;
				}
			}
			break;

			case PASS_OVER:
				break;

			case BOTTOM_UP: 
				break;
		}
	}

	return 1; // OK
}

///////////////////////////////////////////////////////////////////////////////
//                                                                           // 

int node_action::DataLines( int n )
{
	if ( 2 == cOption::debug )
	{
		PrintConsole( false, "-> DataLines\n" );
	}

	switch ( status )
	{
		case TOP_DOWN:	 
		{
			int lineno = node[ n ].line;		// Get line number.
			uchar line[ 256 ];
			int sti = node[ n ].sti;
			uchar* b = symbol[ sti ].name;	
			uchar* x;
			uchar ch;

			do 
			{
				x = line;

				while ( ( '\n' != *b ) && ( '$' != *b ) )
				{
					*x++ = *b++;
				}

				ch = *b++;
				x--;
				
				while ( ( ' ' == *x ) || ( '\t' == *x ) )
				{
					x--;
				}

				*++x = 0;

				for ( x = line; ( ' ' == *x ) || ( '\t' == *x ); x++ );

				x = convert_xml( x );

				if ( cOption::id )
				{
					sprintf( ( char* ) idattr, " id=\"%d\"", ++tagid );
				}
				else
				{
					*idattr = 0;
				}

				if ( 0 == *x )
				{
					sprintf( ( char* ) xmlout, "<Data%s line=\"%d\"/>\n", idattr, lineno++ );
				}
				else
				{
					sprintf( ( char* ) xmlout, "<Data%s line=\"%d\">%s</Data>\n", idattr, lineno++, x );
				}

				emitstr( xmlout );

				if ( cOption::spacing )
				{
					indent[ strlen( ( char* ) indent ) - 2 ] = 0;
				}
			}
			while ( '$' != ch );
		}
		break;

		case PASS_OVER: 
			break;

		case BOTTOM_UP: 
			break;
	}

	return 1; // OK
}

///////////////////////////////////////////////////////////////////////////////
//                                                                           // 

int node_action::CodeLines( int n )
{
	if ( 2 == cOption::debug )
	{
		PrintConsole( false, "-> CodeLines\n" );
	}

	switch ( status )
	{
		case TOP_DOWN:	 
		{
			int lineno = node[ n ].line;		// Get line number.
			uchar line[ 256 ];
			int sti = node[ n ].sti;
			uchar* p = symbol[ sti ].name;	
			uchar* q = p + symbol[ sti ].length;
			uchar* x;

			do 
			{
				x = line;

				while ( '\n' != *p )
				{
					*x++ = *p++;
				}

				x--;

				while ( ( ' ' == *x ) || ( '\t' == *x ) )
				{
					x--;
				}

				*++x = 0;

				for ( x = line; ( ' ' == *x ) || ( '\t' == *x ); x++ );

				x = convert_xml( x );

				if ( cOption::id )
				{
					sprintf( ( char* ) idattr, " id=\"%d\"", ++tagid );
				}
				else
				{
					*idattr = 0;
				}

				if ( 0 == *x )
				{
					sprintf( ( char* ) xmlout, "<Code%s line=\"%04d\"/>\n", idattr, lineno++ );
				}
				else
				{
					sprintf( ( char* ) xmlout, "<Code%s line=\"%04d\">%s</Code>\n", idattr, lineno++, x );
				}

				emitstr( xmlout );

				if ( cOption::spacing )
				{
					indent[ strlen( ( char* ) indent ) - 2 ] = 0;
				}
			}
			while ( ++p < q );
		}
		break;

		case PASS_OVER:
			break;

		case BOTTOM_UP: 
			break;
	}

	return 1; // OK
}

///////////////////////////////////////////////////////////////////////////////
//                                                                           // 

int node_action::Range( int n )
{
	if ( 2 == cOption::debug )
	{
		PrintConsole( false, "-> Range\n" );
	}

	switch ( status )
	{
		case TOP_DOWN:				 
		{
			char fromstr[ 32 ];
			char thrustr[ 32 ];
			int from    = node[ n ].child;
			int thru    = node[ from ].next;
			int fromsti = node[ from ].sti;
			int thrusti = node[ thru ].sti;

			if ( cOption::id )
			{
				sprintf( ( char* ) idattr, " id=\"%d\"", ++tagid );
			}
			else
			{
				*idattr = 0;
			}

			strcpy( fromstr, ( char* ) symbol_name( fromsti ) );
			strcpy( thrustr, ( char* ) symbol_name( thrusti ) );

			sprintf( ( char* ) xmlout, "<%s%s num_element=\"1\" line=\"%d\" from=\"%s\" thru=\"%s\">\n", node_name[ node[ n ].id ], idattr, node[ n ].line, fromstr, thrustr );
			emitstr( xmlout ); 
		}
		break;

		case PASS_OVER: 
			break;

		case BOTTOM_UP: 
			sprintf( ( char* ) xmlout, "</%s>\n", node_name[ node[ n ].id ] );
			emitstr( xmlout );
			break;
	}

	return 1; // OK
}

///////////////////////////////////////////////////////////////////////////////
//                                                                           // 

int node_action::Type( int n )
{
	if ( 2 == cOption::debug )
	{
		PrintConsole( false, "-> Type\n" );
	}

	switch ( status )
	{
		case TOP_DOWN:				 
		{
			int ct;							// child of type.
			int nx;							// next.
			int p   = node[ n ].parent;		// parent, Variable.
			int gp  = node[ p ].parent;		// grandparent, MemberTypedef.
			int c   = node[ gp ].child;		// child, member_vars.
			int t   = node[ c ].next;		// next,  member_type.
			int sti = node[ t ].sti;		// symbol table index.			 

			if ( cOption::id )
			{
				sprintf( ( char* ) idattr, " id=\"%d\"", ++tagid );
			}
			else
			{
				*idattr = 0;
			}

			if ( 0 == node[ t ].child )
			{
				sprintf( ( char* ) xmlout, "<Type%s line=\"%d\">%s</Type>\n", idattr, node[ t ].line, remove_quotes( symbol_name( sti ) ) );
				emitstr( xmlout );

				if ( cOption::spacing )
				{
					indent[ strlen( ( char* ) indent ) - 2 ] = 0;
				}
			}
			else
			{
				sprintf( ( char* ) xmlout, "<Type%s num_element=\"1\" line=\"%d\">%s\n", idattr, node[ t ].line, remove_quotes( symbol_name( sti ) ) ) ;
				emitstr( xmlout );

				ct = node[ t ].child;		 // child of type, member size.

				if ( 0 == node[ ct ].child ) // Size?
				{
					sti = node[ ct ].sti;	 // <integer>.

					if ( cOption::id )
					{
						sprintf( ( char* )idattr, " id=\"%d\"", ++tagid );
					}
					else
					{
						*idattr = 0;
					}

					sprintf( ( char* ) xmlout, "<%s%s num_element=\"1\" line=\"%d\">%s\n", node_name[ node[ ct ].id ], idattr, node[ ct ].line, symbol_name( sti ) );
					emitstr( xmlout );
				}
				else							 // Range!
				{
					char fromstr[ 32 ];
					char thrustr[ 32 ];
					int from    = node[ ct ].child;
					int thru    = node[ from ].next;
					int fromsti = node[ from ].sti;
					int thrusti = node[ thru ].sti;

					if ( cOption::id )
					{
						sprintf( ( char* ) idattr, " id=\"%d\"", ++tagid );
					}
					else
					{
						*idattr = 0;
					}

					strcpy( fromstr, ( char* ) symbol_name( fromsti ) );
					strcpy( thrustr, ( char* ) symbol_name( thrusti ) );

					sprintf( ( char* ) xmlout, "<%s%s num_element=\"1\" line=\"%d\" from=\"%s\" thru=\"%s\">\n", node_name[ node[ ct ].id ], idattr, node[ ct ].line, fromstr, thrustr );
					emitstr( xmlout );
				}

				nx  = node[ ct ].next;	// next child, member type.
				sti = node[ nx ].sti;	// name

				if ( cOption::id )
				{
					sprintf( ( char* ) idattr, " id=\"%d\"", ++tagid );
				}
				else
				{
					*idattr = 0;
				}

				sprintf( ( char* ) xmlout, "<%s%s line=\"%d\">%s</%s>\n", node_name[ node[ nx ].id ], idattr, node[ nx ].line, remove_quotes( symbol_name( sti ) ), node_name[node[ nx ].id ] );
				emitstr( xmlout );

				if ( cOption::spacing )
				{
					indent[ strlen( ( char* ) indent ) - 2 ] = 0;
				}

				if ( cOption::spacing )
				{
					indent[ strlen ( ( char* ) indent ) - 2 ] = 0;
				}

				sprintf( ( char* ) xmlout, "</%s>\n", node_name[ node[ ct ].id ] );
				emitstr( xmlout );

				if ( cOption::spacing )
				{
					indent[ strlen( ( char* ) indent ) - 2 ] = 0;
				}

				if ( cOption::spacing ) 
				{
					indent[ strlen( ( char* ) indent ) - 2 ] = 0;
				}

				sprintf( ( char* ) xmlout, "</Type>\n" );
				emitstr( xmlout ); 

				if ( cOption::spacing )
				{
					indent[ strlen( ( char* ) indent ) - 2 ] = 0;
				}
			}
		}
		break;

		case PASS_OVER: 
			break;

		case BOTTOM_UP: 
			break;
	}

	return 1; // OK
}

///////////////////////////////////////////////////////////////////////////////
//                                                                           // 

uchar* node_action::convert_xml( uchar* text )
{
	static uchar output[ 2048 ];

	if ( 0 == *text )
	{
		return text;
	}

	uchar* p = text;
	uchar* q = output;
	uchar* puchLast = ( output + sizeof( output ) );

	do
	{
		if ( q == puchLast )
		{
			#if ( _DEBUG ) && ( WIN32 )
				DebugBreak( );
			#endif

			*q = 0;
			break;
		}

		switch ( *p )
		{
			case '"':  *q++ = '&'; *q++ = 'q'; *q++ = 'u'; *q++ = 'o'; *q++ = 't'; *q++ = ';'; break;
		  	case '&':  *q++ = '&'; *q++ = 'a'; *q++ = 'm'; *q++ = 'p'; *q++ = ';'; break;
			case '<':  *q++ = '&'; *q++ = 'l'; *q++ = 't'; *q++ = ';'; break;
			case '>':  *q++ = '&'; *q++ = 'g'; *q++ = 't'; *q++ = ';'; break;
		 	case 130:  *q++ = '\''; break; // single low-9 quotation mark
		 	case 132:  *q++ = '\"'; break; // double low-9 quotation mark
		 	case 139:  *q++ = '<'; break;  // single left-pointing angle quotation mark
		 	case 145:  *q++ = '\''; break; // left single quotation mark
		 	case 146:  *q++ = '\''; break; // right single quotation mark
		 	case 147:  *q++ = '\"'; break; // left double quotation mark
		 	case 148:  *q++ = '\"'; break; // right double quotation mark
		 	case 150:  *q++ = '-'; break;  // en dash
		 	case 151:  *q++ = '-'; break;  // em dash
		 	case 152:  *q++ = '~'; break;  // small tilde
		 	case 155:  *q++ = '>'; break;  // single right-pointing angle quotation mark
		 	case 160:  *q++ = ' '; break;  // no-break space
		 	case 166:  *q++ = '|'; break;  // broken bar
		 	case 183:  *q++ = '.'; break;  // middle dot
			default:   *q++ = *p;
		}
	}
	while ( 0 != *++p );

	*q = 0;

	return output;
}

/////////////////////////////////////////////////////////////////////////////////////////////////////
//                                                                                                 // 
  
int node_action::xml( int n ) 
{
	const char* pszStatNo = "statno";

	switch ( status )
	{
		case TOP_DOWN:	 
		{
			uchar* ts1				= ( uchar* ) "";				// Text string 1.
			uchar* ts2				= ( uchar* ) "";				// text string 2.
			int ai					= nact_arg[ node[ n ].prod ];	// Argument index.
			int a1					= arg_numb[ ai ];				// Argument number 1.
			int a2					= arg_numb[ ai + 1 ];			// Argument number 2.
			int i					= node[ n ].sti;				// Symbol name index
			int lineno				= node[ n ].line;				// Symbol line number
			int c					= 0;							// Child pointer.
			int nc					= 0;							// Number of children.
			bool bStatementNumber	= false;						// Does this node contain the statement number?

			for ( c = node[ n ].child; 0 != c; c = node[ c ].next )
			{
				nc++;
			}

			if ( a1 >= 0 ) 
			{
				ts1 = ( uchar* ) arg_text[ a1 ];						// text string 1. 

				if ( 0 == strcmp( ( char* ) ts1, pszStatNo ) )			// "statno" gets special handling.
				{
					if ( nc > 0 )										// fstatno on this line?
					{
						bStatementNumber = true;
						lineno = node[ node[ n ].child ].line;			// Get line number.
						i = node[ node[ n ].child ].sti;				// Get statement number index from child.
						nc--;											// Less one for the statement number.
					}
				}
				else if ( 0 == strcmp( ( char* ) ts1, "num_stmt" ) )	// "num_stmt" gets special handling. 
				{
					if ( cOption::id )
					{
						sprintf( ( char* ) idattr, " id=\"%d\"", ++tagid );
					}
					else
					{
						*idattr = 0;
					}

					if ( cOption::numel )
					{
						sprintf( ( char* ) neattr, " num_element=\"%d\"", nc );
					}
					else
					{
						*neattr = 0;
					}

					sprintf( ( char* ) xmlout, "<%s version=\"%s.%s\" build=\"%s\"%s%s %s=\"%d\" name=\"%s%s%s\">\n", 
						node_name[ node[ n ].id ], major_version, minor_version, build_num, idattr, neattr, ts1, n_statements, cInput::dir, primary_filename, cInput::filetype );

					goto B;
				}
			}

			if ( a2 >= 0 )
			{
				ts2 = ( uchar* ) arg_text[ a2 ];	// text string 2. 
			}

			if ( cOption::id )
			{
				sprintf( ( char* ) idattr, " id=\"%d\"", ++tagid );
			}
			else
			{
				*idattr = 0;
			}

			if ( cOption::numel )
			{
				sprintf( ( char* ) neattr, " num_element=\"%d\"", nc );
			}
			else
			{
				*neattr = 0;
			}

			if ( 0 == i )						// No symbol in this node?			
			{
				if ( 0 == nc )
				{
					if ( bStatementNumber )		// This would happen if there wasn't a statement number in the source
					{
						sprintf( ( char* ) xmlout, "<%s%s test_num=\"%s\" line=\"%d\"/>\n", node_name[ node[ n ].id ], idattr, last_testnum, lineno );
					}
					else
					{
						sprintf( ( char* ) xmlout, "<%s%s/>\n",  node_name[ node[ n ].id ], idattr );
					}
				}
				else
				{
					if ( bStatementNumber )		// This would happen if there wasn't a statement number in the source
					{
						sprintf( ( char* ) xmlout, "<%s%s%s test_num=\"%s\" line=\"%d\">\n", node_name[ node[ n ].id ], idattr, neattr, last_testnum, lineno );
					}
					else
					{
						sprintf( ( char* ) xmlout, "<%s%s%s>\n", node_name[ node[ n ].id ], idattr, neattr );
					}
				}
			}
			else if ( i < 0 )					// Terminal symbol (keyword).
			{
				if ( 0 == nc )
				{
					if ( 0 == ts1[ 0 ] )		// No attribute?
					{
						sprintf( ( char* )xmlout, "<%s%s line=\"%d\">%s</%s>\n", 
						node_name[ node[ n ].id ], idattr, lineno, ( char* ) convert_xml( remove_quotes( ( uchar* ) term_symb[ -i] ) ), node_name[ node[ n ].id ] );
					}
					else if ( 0 == ts2[ 0 ] )
					{
					  sprintf( ( char* ) xmlout, "<%s%s line=\"%d\" %s=\"%s\"/>\n", 
					  ( uchar* ) node_name[ node[ n ].id ], idattr, lineno, ts1, convert_xml( remove_quotes ( ( uchar* ) term_symb[ -i ] ) ) );
					}
					else
					{
					  sprintf( ( char* ) xmlout, "<%s%s line=\"%d\" %s=\"%s\" %s/>\n", 
					  ( uchar* ) node_name[ node[ n ].id ], idattr, lineno, ts1, convert_xml( remove_quotes( ( uchar* ) term_symb[ -i ] ) ), ts2 );
					}
				}
				else 
				{
					if ( 0 == ts1[ 0 ] )		// No attribute?
					{
						sprintf( ( char* )xmlout, "<%s%s%s line=\"%d\" ?=\"%s\">\n", 
						( uchar* ) node_name[node[ n ].id ], idattr, neattr, lineno, ts1, convert_xml( remove_quotes( ( uchar* ) term_symb[ -i ] ) ) );
					}
					else if ( 0 == ts2[ 0 ] )
					{
						sprintf( ( char* ) xmlout, "<%s%s%s line=\"%d\" %s=\"%s\">\n", 
						(uchar*)node_name[node[n].id], idattr, neattr, lineno, ts1, convert_xml( remove_quotes( ( uchar* ) term_symb[ -i ] ) ) );
					}
					else
					{
						sprintf( ( char* ) xmlout, "<%s%s%s line=\"%d\" %s=\"%s\" %s>\n", 
						( uchar* ) node_name[ node[ n ].id ], idattr, neattr, lineno, ts1, convert_xml( remove_quotes( ( uchar* ) term_symb[ -i ] ) ), ts2 );
					}
				}
			}
			else								// Symbol-table index.
			{
				if ( 0 == nc )
				{
					if ( 0 == ts1[ 0 ] )		// No attribute?
					{
						sprintf( ( char* ) xmlout, "<%s%s line=\"%d\">%s</%s>\n", 
						( uchar* ) node_name[ node[ n ].id ], idattr, lineno, convert_xml( remove_quotes( symbol_name( i ) ) ), ( uchar* ) node_name[ node[ n ].id ] );
					}
					else if ( 0 == ts2[ 0 ] )
					{
						uchar* value = symbol_name( i );

						if ( bStatementNumber )
						{
							value = GetFullStatementNumber( value );
						}

						sprintf( ( char* ) xmlout, "<%s%s line=\"%d\" %s=\"%s\"/>\n", 
						( uchar* ) node_name[ node[ n ].id ], idattr, lineno, ts1, convert_xml( remove_quotes( value ) ) );
					}
					else
					{
						sprintf( ( char* ) xmlout, "<%s%s line=\"%d\" %s=\"%s\" %s/>\n", 
						( uchar* ) node_name[ node[ n ].id ], idattr, lineno, ts1, convert_xml( remove_quotes( symbol_name( i ) ) ) , ts2 );
					}
				}
				else 
				{
					if ( 0 == ts1[ 0 ] )		// No attribute (error)?
					{
						sprintf( ( char* ) xmlout, "<%s%s%s line=\"%d\" ?=\"%s\">\n", 
						( uchar* ) node_name[ node[ n ].id ], idattr, neattr, lineno, convert_xml( remove_quotes( symbol_name( i ) ) ) );
					}
					else if ( 0 == ts2[ 0 ] )
					{
						uchar* value = symbol_name( i );

						if ( bStatementNumber )
						{
							value = GetFullStatementNumber( value );
						}

						sprintf( ( char* ) xmlout, "<%s%s%s line=\"%d\" %s=\"%s\">\n", 
						( uchar* ) node_name[ node[ n ].id ], idattr, neattr, lineno, ts1, convert_xml( remove_quotes( value ) ) );
					}
					else
					{
						uchar* value = symbol_name( i );

						if ( bStatementNumber )
						{
							value = GetFullStatementNumber( value );
						}

						sprintf( ( char* ) xmlout, "<%s%s%s line=\"%d\" %s=\"%s\" %s>\n", 
						( uchar* ) node_name[ node[ n ].id ], idattr, neattr, lineno, ts1, convert_xml( remove_quotes( value ) ), ts2 );
					}
				}
			}

B:			emitstr( xmlout );
		}
		break;

		case PASS_OVER: 
			break;

		case BOTTOM_UP: 
		{
			uchar* ts1	= ( uchar* ) "";					// text string 1.
			int ai		= nact_arg[ node[ n ].prod ];		// argument index.
			int a1		= arg_numb[ ai ];					// argument number 1.
			int i		= node[ n ].sti;					// Symbol name index.
			int c		= 0;								// child pointer.
			int nc		= 0;								// number of children.

			for ( c = node[ n ].child; 0 != c; c = node[ c ].next )
			{
				nc++;
			}

			if ( a1 >= 0 ) 
			{
				ts1 = ( uchar* ) arg_text[ a1 ];

				if ( 0 == strcmp( ( char* ) ts1, pszStatNo ) )
				{
					nc--;
				}
			}

			if ( nc <= 0 )
			{
				emitstr( ( uchar* ) "" );
			}
			else 
			{
				sprintf( ( char* ) xmlout, "</%s>\n", node_name[ node[ n ].id ] );
				emitstr( xmlout );
			}
		}
		break;
	}

	return 1; // OK
}


/////////////////////////////////////////////////////////////////////////////////////////////////////
//                                                                                                 // 
//    GetFullStatementNumber
  
uchar* node_action::GetFullStatementNumber( uchar* stmtnum )
{
	uchar* ret_stmtnum = stmtnum;

	if ( 0 != stmtnum )
	{
		const int iStmtLen = strlen( ( char* ) stmtnum );

		if ( ( iStmtLen > 0 ) && ( iStmtLen < ( stmtnum_len + 1 ) ) )
		{
			if ( stmtnum_len == iStmtLen )
			{
				strncpy( ( char* ) last_stmtnum, ( char* ) stmtnum, stmtnum_len );
			}
			else
			{
				const int iLastStmtLen = strlen( ( char* ) last_stmtnum );

				memcpy( last_stmtnum + ( iLastStmtLen - iStmtLen ), stmtnum, iStmtLen );
			}

			ret_stmtnum = last_stmtnum;
		}

		memcpy( last_testnum, last_stmtnum, testnum_len );
	}

	return ret_stmtnum;
}

/////////////////////////////////////////////////////////////////////////////////////////////////////
//                                                                                                 // 
//    emitstr
  
void node_action::emitstr( uchar* str )
{
	if ( 0 == *str )
	{
		goto Ret;
	}

	if ( 0 == status )
	{
		if ( cOption::spacing )
		{
			strcat( ( char* ) indent, "  " );
		}
	}

	cOutput::WriteXmlBuffer( indent );
	cOutput::WriteXmlBuffer( str );

	if ( cOption::xmlfile )
	{
		cOutput::WriteXmlFile( indent );
		cOutput::WriteXmlFile( str );
	}

Ret:	if ( 2 == status )
		{
			if ( cOption::spacing )
			{
				indent[ strlen ( ( char* ) indent ) - 2 ] = 0;
			}
		}
}

//                                                                                                 // 
/////////////////////////////////////////////////////////////////////////////////////////////////////
