/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
#pragma once

#define uchar  unsigned char
#define ushort unsigned short
#define uint   unsigned int

class Token		 
{
public:
	uchar* start;		// Start of token.
	uchar* end;			// End   of token (character following token).
	int    linenumb;	// Input line number.
	int    colnumb;		// Input column number.
	int    sti;			// Symbol table index.
};

class lexer 
{
public:
	static Token  token;
	static int    tab;
	static int    linenumb;
	static int    linenumb_printed;
	static int    colnumb;
	static int    includeon;
	static int    lookupon;
	static int    CNXon;
	static uchar  path[ 256 ];
	static void   init( uchar*, int, int, uchar*, int, int );
	static int    get_token( );
};