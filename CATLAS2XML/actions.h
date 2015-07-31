/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

#pragma once

#include "parser.h"

class token_action : public parser
{
	public:	
		static int   checkeof		( int& terminal_number );
		static int   commentblock	( int& terminal_number );
		static int   branchblock	( int& terminal_number );
		static int   codeblock		( int& terminal_number );
		static int   error			( int& terminal_number );
		static int   lookup			( int& terminal_number );
		static int   firstid		( int& terminal_number );
		static int	 datablock		( int& terminal_number );
		static int   lucomment		( int& terminal_number );
		static int   CNXoff			( int& terminal_number );
		static int   CNXcheck		( int& terminal_number );
		static int   CNXlookup		( int& terminal_number );

		static unsigned int uiEntryPoint_count;
};

class parse_action : public token_action
{
	public:	
		static int  Keyword         		( int prod_number ); 
		static int  BEGIN_ATLAS_PROGRAM		( int prod_number );
		static int  TERMINATE_ATLAS_PROGRAM ( int prod_number );
		static int  BEGIN_ATLAS_MODULE		( int prod_number );
		static int  TERMINATE_ATLAS_MODULE  ( int prod_number );
		static int  SEGMENT					( int prod_number );
		static int  END_SEGMENT				( int prod_number );
		static int  INCLUDE_ATLAS_MODULE 	( int prod_number );
		static int  LEAVE_ATLAS   			( int prod_number );
		static int  AtlasProgram			( int prod_number );
		static int  AtlasModule				( int prod_number );
		static int  Segment					( int prod_number );
		static int  IncludeFile   			( int prod_number );
		static int  Filename      			( int prod_number );
		static int  Message        			( int prod_number );
		static int  UsingDevice    			( int prod_number );
		static int  Lookup         			( int prod_number ); 
		static int  StatementNumber			( int prod_number ); 
		static int  UNKNOWN        			( int prod_number ); 
		static int  UnknownVerb      		( int prod_number ); 
		static int  Datafix        			( int prod_number ); 

		static int  define_name;
		static uchar includefile[ 256 ];
};

class node_action : public parse_action
{
	public:		
		static int   CommentBlock		( int node_number );
		static int   CommentLines		( int node_number );
		static int   BranchTarget		( int node_number );
		static int   EntryPoint			( int node_number );
		static int   LUCommentLines		( int node_number );
		static int   Segment			( int node_number );
		static int   AtlasProgram		( int node_number );
		static int   AtlasModule 		( int node_number );
		static int   CodeLines	   		( int node_number );
		static int   DataLines	   		( int node_number );
		static int   Range  	   		( int node_number );
		static int   Type  	   			( int node_number );
		static int   xml 				( int node_number );	
	
		static void  make_xml     		( int node_number, uchar* name );
		static uchar* convert_xml		( uchar* text );
		static uchar* GetFullStatementNumber( uchar* stmtnum );
	
		static void  emitstr( uchar* str );
	
		static int   argno;
		static uchar xmlout[ 2048 ];
		static uchar indent[ 1024 ];
		static uchar idattr[ 32 ];
		static uchar neattr[ 32 ];
		static uchar last_stmtnum[ 7 ];
		static uchar last_testnum[ 5 ];
		static int   tagid;
		static int   segment;
		static int   process_commentblock;
		static const unsigned int stmtnum_len;
		static const unsigned int testnum_len;
};