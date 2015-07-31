/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

#include <string.h>
#include "lexer.h"
#include "lexertables.h"

#if ( _DEBUG ) && ( WIN32 )
	#define WINVER 0x0600
	#include <afx.h>
	#define new DEBUG_NEW
	#undef THIS_FILE
	static char BASED_CODE THIS_FILE[ ] = __FILE__;
#endif																						 

extern uchar uppercase[ ];

/////////////////////////////////////////////////////////////////////////////////////////////////////
//                                                                                                 // 
//    DFASTAR Lexer (option /tm).
                 
Token   lexer::token;				// Token.
int     lexer::linenumb;			// Line number of token.
int     lexer::linenumb_printed;	// Line number printed already.
int     lexer::colnumb;				// Column number of token.
int     lexer::tab;					// Tab setting for the input file.
int     lexer::includeon;			// Include file switch is on?
int     lexer::lookupon;			// Lookup file switch is on?
int     lexer::CNXon;				// CNX switch is on?
uchar   lexer::path[ 256 ];			// Path (dir,filename,ext).

/////////////////////////////////////////////////////////////////////////////////////////////////////
//                                                                                                 //
//    lexer_init()

void lexer::init( uchar* patharg, int inc, int lu, uchar* input_start, int tab_value, int ln ) 
{
	strcpy( ( char* ) path, ( char* ) patharg );

	lookupon         = lu;
	includeon        = inc;
	CNXon            = 0;
	colnumb          = 0;
	linenumb         = ln;
	linenumb_printed = ln-1;
	tab              = tab_value;
	token.end        = input_start - 1;
}

/////////////////////////////////////////////////////////////////////////////////////////////////////
//                                                                                                 // 
//    get_token()

int lexer::get_token( )				// Medium lexer.		
{
	int x, y;						// State, next state.

	do 
	{
		x = 0;
		token.start = token.end;
		token.linenumb = linenumb;

		while ( ( y = Tm[ Tr[ x ] + Tc[ uppercase[ *token.end ] ] ] ) > 0 )
		{
			x = y;

			if ( '\n' == *token.end )
			{
				linenumb++;
			}

			token.end++;
		}
	}
	while ( token_number[ x ] < 0 );	// Ignore whitespace.	

	return token_number[ x ];			// Return token_number.	
}