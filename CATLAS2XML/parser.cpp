/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "atlas_main.h"
#include "actions.h"   
#include "parser.h"
#include "parsertables.h"

#if ( _DEBUG ) && ( WIN32 )
	#define WINVER 0x0600
	#include <afx.h>
	#define new DEBUG_NEW
	#undef THIS_FILE
	static char BASED_CODE THIS_FILE[ ] = __FILE__;
#endif

#undef  UINT_MAX
#define UINT_MAX 0xffffffff // For hasing algorithm.			
#define STKSIZE        1000 // Parser-stack size.    
#define EOF_CHAR         26 // End Of file marker.

// 6/24/2015 JJO - Used as part of the hack code in function "reduce"
int iStatementNumberNodeNameIndex = -1;

/////////////////////////////////////////////////////////////////////////////////////////////////////
//                                                                                                 //
//    LRSTAR Parser.

// Parser class variables (accessed from outside "parser.cpp")
int     parser::n_errors;
int     parser::n_unknowns;
int     parser::n_statements;
int     parser::in_pgm;
int     parser::in_mod;
int     parser::in_seg;
int     parser::n_pgm_statements;
int     parser::n_mod_statements;
int     parser::n_seg_statements;
int     parser::n_includefiles;
int     parser::status;
int     parser::nd_mode;
int     parser::nd_level_max;
PStack* parser::PS;                  

// Internal parser stuff ...
static int     max_errs;
static int     state;
static int     nd_level;
static int     nd_level_hi;
static int     topstate;
static PStack  P_stack[ STKSIZE ];
static RStack  R_stack[ STKSIZE ];
static PStack* PS_end;                  
static PStack* PX;
static RStack* RS; 

// Symbol-table stuff ...
Symbol* Symtab::symbol;
int     Symtab::cell;
int     Symtab::sti;
int     Symtab::length;
int     Symtab::n_symbols;
int     Symtab::n_keywords;
uint    Symtab::hashdiv;
int*	Symtab::hashvec;
int	    Symtab::max_cells;
int	    Symtab::max_symbols;

// AST stuff ...
Node*   AST::node;
int     AST::root;
int     AST::n_nodes;
int     AST::max_nodes;

static uchar* T_list;		// Terminal symbol list (0 or 1).
static int*   P_list;		// Production list.

/////////////////////////////////////////////////////////////////////////////////////////////////////
//                                                                                                 // 
//    parser -  initialization																  

int parser::init( int max_symb, int max_node )
{
	parser::n_errors					= 0;
	parser::n_unknowns					= 0;
	parser::n_statements				= 0;
	parser::in_pgm						= 0;
	parser::in_mod						= 0;
	parser::in_seg						= 0;
	parser::n_pgm_statements			= 0;
	parser::n_mod_statements			= 0;
	parser::n_seg_statements			= 0;
	parser::n_includefiles				= 0;
	parser::status						= 0;
	parser::nd_mode						= 0;
	parser::nd_level_max				= 0;

	parse_action::define_name			= 0;

	token_action::uiEntryPoint_count	= 0;

	node_action::argno					= 0;
	node_action::tagid					= 0;
	node_action::segment				= 0;
	node_action::process_commentblock	= 0;

	if ( !init_symtab( max_symb ) )					// Initialize the symbol table.
	{
		return 0;        
	}

	if ( !init_ast( max_node ) )					// Initialize the AST. 
	{
		return 0;           
	}

	token.start = ( uchar* ) "";                    // Make a blank symbol.
	token.end   = token.start + 1;

	add_symbol( 0, token.start, token.end );		// Add it to the symbol table.

	n_errors		= 0;							// Set number of errors.    
	n_unknowns		= 0;							// Set number of unknown statements.    
	n_statements	= 0;							// Set number of statements.    
	max_errs		= 10;							// Set max number of errors.

	PS				= P_stack;						// Set parse-stack pointer.   
	PS_end			= P_stack + STKSIZE;			// Set parse-stack end pointer.   
	nd_mode			= 0;							// Nondeterministic mode of parsing (no).
	state			= 0;
	nd_level_max	= 0;

	// 6/24/2015 JJO - Used as part of the hack code in function "reduce"
	if ( -1 == iStatementNumberNodeNameIndex )
	{
		for ( int i = 0; i < n_nodenames; ++i )
		{
			if ( 0 == strcmp( node_name[ i ], "StatementNumber" ) )
			{
				iStatementNumberNodeNameIndex = i;
				break;
			}
		}
	}

	return 1; // Return OK.
}

/////////////////////////////////////////////////////////////////////////////////////////////////////
//                                                                                                 // 
//    parser -  termination

void parser::term( )
{
	if ( 0 == n_errors )
	{
		print_symtab( ( uchar** ) term_symb );	// Print the symbol table contents.
		print_ast( );							// Print the AST, if ast option indicates.

		traverse( );							// Traverse the AST, calling the AST actions.
	}

	term_ast( );
	term_symtab( );
}

/////////////////////////////////////////////////////////////////////////////////////////////////////
//                                                                                                 // 
//		LR Parser

int parser::parse( int& n_errs, int& n_stmts, int& n_unkns )
{
	int p;                                          			// Production (rule) number.  
	int t;                                          			// Terminal symbol number. 
	int x;                                    					// State number.  
	int y;                                      				// Next state number.  
	
	x = state;													// Get saved state.

Read: t = get_token( );											// Get incoming token.

	if ( cOption::echo )
	{
		prt_line( );
	}

	if ( tact_numb[ t ] >= 0 )			            			// If token action ...         
	{
		token.sti = ( *tact_func[ tact_numb[ t ] ] )( t ); 		// Call token-action function.

		if ( 0 == token.sti )
		{
			goto A;												// Added 2015.01.13 pbm.
		}

		if ( token.sti < 0 )
		{
			goto Read;											// Skip this token.
		}
	}
	else 
	{
A:		token.sti = -t;											// Symbol-table index. Changed 2015.01.13 pbm.
	}

	topstate = x;												// Save current state.
	RS = R_stack;												// Reset restore-stack pointer.
	PX = PS;													// Save parse-stack pointer.

Shft: if ( Bm[ Br[ x ] + Bc[ t ] ] & Bmask[ t ] )				// Check B-matrix for shift action. 
	{
		y = Tm[ Tr[ x ] + Tc[ t ] ];							// Get next state from terminal transition matrix.

Stck:	if ( ++PS >= PS_end )									// Check for stack overflow.
		{
			goto Over;
		}

		PS->state = x;											// Put current state on stack.  
		PS->sym   = t;											// Put terminal number on stack.
		PS->sti   = token.sti;									// Put token symbol table index on stack.
		PS->line  = token.linenumb;								// Put its line number on stack.
		PS->node  = 0;											// Set node on stack to zero.   
		
		x = y;

		while ( x <= 0 )										// While shift-reduce actions. 
		{
			p = -x;												// Reduce stack by production p.	
			PS -= PL[ p ];										// Reduce stack ptr by production length. 
			PS->sym = -head_numb[ p ];							// Put head symbol number on stack.
			
			if ( !reduce( p ) )									// Call reduce action with rule number.
			{
				goto Ret;
			}
			
			x = Nm[ Nr [ PS->state ] + Nc[ p ] ];				// Get next state from nonterminal transition.
		}

		goto Read;												// Go to read next token.
	}

	if ( ( ( p = Rr[ x ] ) > 0 ) || ( ( p = Rm[ Rc[ t ] - p ] ) > 0 ) )	// Get reduction?
	{
Red:	PS -= PL[ p ];											// Reduce parse stack ptr by rule length - 1. 

		if ( PL[ p ] < 0 )										// Null production?
		{	
			if ( PS >= PS_end )									// Check for overflow.
			{
				goto Over;
			}

			( ++RS )->ptr = PS;									// Save parse-stack pointer.
			RS->state = PS->state;								// Save old state before replacing it.
			PS->node  = 0;										// Clear node pointer.
			PS->state = x;										// Stack current state, replacing old state.
		}

		while ( 1 )
		{
			PS->sym = -head_numb[ p ];							// Put head symbol number on stack.

      		if ( !reduce( p ) )									// Call reduce action with rule number.
			{
				goto Ret;
			}

			x = Nm[ Nr[ PS->state ] + Nc[ p ] ];				// Get next state from nonterminal transition.

			if ( x > 0 ) 
			{
				goto Shft;										// Continue parsing.
			}

			p = -x;												// Set production number.
			PS -= PL[ p ];										// Reduce parse stack ptr by rule length - 1. 
		}
	}

	if ( nd_state[ x ] )										// Nondeterministic state?
	{
		nd_level_hi = 0;

		y = nd_lookahead( P_stack, PS, x, t );
		
		if ( nd_level_hi > nd_level_max )
		{
			nd_level_max = nd_level_hi;
		}

		if ( 2147483647 != y )
		{
			if ( y > 0 )										// Shift and Goto?
			{
				if ( y > ACCEPT_STATE )							// Shift and reduce?
				{
					y = ( ACCEPT_STATE - y );					// Convert to production #
				}
				
				goto Stck;										// Go stack this token. 
			}

			p = -y;												// Get production.

			goto Red;											// Go to reduce.
		}
	}

	if ( ACCEPT_STATE == x )									// If Goal production.  
	{
		PS -= PL[ 0 ];											// Reduce parse stack ptr by rule length - 1. 
		PS->sym = 0;											// Put head symbol number on stack.

		if ( !reduce( 0 ) )										// Call reduce action with rule number.
		{
			goto Ret;
		}

		if ( linenumb > 0 )										// Reduce line number by one.
		{
			linenumb = --linenumb;
		}

Ret:	root = n_nodes-1;										// Point at last node. 

		n_errs = n_errors;										// Return number of errors. 
		n_unkns = n_unknowns;									// Return number of knowns statements.
		n_stmts = n_statements;									// Return number of statements. 

		return linenumb;										// Return number of lines parsed.
	}

	if ( eof_symb == t )
	{
		state = x;												// Save state.
		return -1;												// Unfinished parse. 
	}

	n_errors++;
	return_code |= RC_SYNTAX_ERROR;
	prt_error( ( uchar* ) term_symb[ t ] );						// Print syntax error message. 
	prt_stack( );												// Print parse stack.
	expecting( );												// Print syntax help (list of expected tokens). 
	goto Ret;													// Quit. 

	// Error recovery can produce so many erroneous errors, which confuses the user. 
	// It's better to stop at the first error. 
	// PS = recover (PS, t);		// Recover from error. 
	// if (PS == 0) goto Ret;		// Failure
	// x = (PS+1)->state;			// Get resume state.
	// goto Read;

Over: PrintConsole( true, "\nParser stack overflow.\n\n" );
	return_code |= RC_INTERNAL_ERROR;
	goto Ret;													// Return negative number of lines for failure. 
}

/////////////////////////////////////////////////////////////////////////////////////////////////////
//                                                                                                 // 
//    nd_lookahead  

int parser::nd_lookahead( PStack* P_stack, PStack* PS, int x, int t )
{
	int i;
	int p;
	int nla;											// Number of lookaheads.
	int k = 0;											// Number of actions. 
	int max_nla = 0;									// Maximum number of lookaheads. 
	int actn = 2147483647;								// ND action (defaults to error).
	int saved_linenumb = linenumb;						// Saved line number.

	PStack  S_stack[ STKSIZE ];							// State stack.
	PStack* SS_end = ( S_stack + STKSIZE );				// State stack end pointer.

	nd_level++;

	if ( nd_level > nd_level_hi )
	{
		nd_level_hi = nd_level;
	}

	int* action = 0;
	int* nlas = 0;
		
	try
	{
		action = new int[ n_terms ];
	}
	catch ( ... )
	{
		PrintConsole( true, "Failed to allocate memory for nondeterministic action" );
		return_code |= RC_MEMORY_OVERFLOW;
		throw return_code;
	}

	try
	{
		nlas = new int[ n_terms ];
	}
	catch ( ... )
	{
		delete [ ] action;

		PrintConsole( true, "Failed to allocate memory for nondeterministic lookaheads" );
		return_code |= RC_MEMORY_OVERFLOW;
		throw return_code;
	}

	nd_mode = 1;	

	for ( i = nd_start[ x ]; i < nd_start[ x + 1 ]; i++ )
	{
		if ( t == nd_term[ i ] ) 
		{
			PStack* P  = P_stack;	// Parser stack pointer.       
			PStack* SS = S_stack;	// State  stack pointer.       

			while ( P < PS ) 
			{
				( ++SS )->state = ( ++P )->state;
			}

			nla = nd_parse( S_stack, SS, SS_end, x, t, nd_action[ i ] );

			if ( nla > max_nla )
			{
				max_nla = nla;
			}

			action[ k ] = nd_action[ i ];
			nlas[ k++ ] = nla;
		}
		else if ( nd_term[ i ] > t )	// nd_term is sorted, so we are done.
		{
			break;
		}
	}

	linenumb = saved_linenumb;
	nd_mode = 0;					

	if ( max_nla > 0 )
	{
		int count_shift  = 0;
		int count_null   = 0;
		int count_reduce = 0;

		for ( i = 0; i < k; i++ )
		{
			if ( nlas[ i ] == max_nla && action[ i ] > 0 ) // shift?
			{
				count_shift++;

				if ( 2147483647 == actn )
				{
					actn = action[ i ];
				}
			}
		}

		for ( i = 0; i < k; i++ )
		{
			if ( nlas[ i ] == max_nla && action[ i ] < 0 && PL[ -action[ i ] ] < 0 ) // null reduce?
			{
				count_null++;

				if ( 2147483647 == actn )
				{
					actn = action[ i ];
				}
			}
		}

		for ( i = 0; i < k; i++ )
		{
			if ( nlas[ i ] == max_nla && action[ i ] <= 0 && PL[ -action[ i ] ] >= 0 )
			{
				count_reduce++;

				if ( 2147483647 == actn )
				{
					actn = action[ i ];
				}
			}
		}

		if ( ( count_reduce > 1 ) || ( count_null > 1 ) || ( count_shift > 1 ) )
		{
			prt_error( ( uchar* ) term_symb[ t ] );
			PrintConsole( true, "Ambiguous decision in state %d at lookahead %s\n\n", x, term_symb[ t ] );
			prt_stack( );

			for ( i = 0; i < k; i++ )
			{
				if ( max_nla == nlas[ i ] ) 
				{
					if ( action[ i ] > 0 ) 
					{
						if ( action[ i ] > ACCEPT_STATE )			// Shift-reduce action?
						{
							p = action[ i ] - ACCEPT_STATE;			// Convert to production #
							prt_prod( ( uchar* ) "   shift-reduce", p, ( uchar* ) "" );
						}
						else
						{
							PrintConsole( false,        "   goto        %6d\n",  action[ i ]);
						}
					}
					else
					{
						prt_prod( ( uchar* ) "   reduce      ", -action[ i ], ( uchar* ) "" );
					}
				}
			}
			
			return_code |= RC_INTERNAL_ERROR;

			if ( 0 != nlas )
			{
				delete [ ] nlas;
			}
			
			if ( 0 != action )
			{
				delete [ ] action;
			}
			
			throw return_code;
		}
	}

	delete [ ] nlas;
	delete [ ] action;

	nd_level--;
	
	return actn;
}

/////////////////////////////////////////////////////////////////////////////////////////////////////
//                                                                                                 // 
//		nd_parse - nondeterministic parse

int parser::nd_parse( PStack* P_stack, PStack* PS, PStack* PS_end, int x, int t, int y )
{
	int		p;
	int		sti;
	int		lookaheads;
	uchar*	TS = token.start;
	uchar*	TE = token.end;
	int		LN = token.linenumb;

	lookaheads = 0;

	goto Act;

Read: t = get_token( );												// Get first token. 

	if ( tact_numb[ t ] >= 0 )										// Need this if-statement for typedef names.         
	{
		sti = ( *tact_func[ tact_numb[ t ] ] )( t );				// Call token-action function, maybe change t.

		if ( sti < 0 )
		{
			goto Read;
		}
	}


Shft: if ( Bm[ Br[ x ] + Bc[ t ] ] & Bmask[ t ] )					// Check B-matrix for shift action. 
	{
		y = Tm[ Tr[ x ] + Tc[ t ] ];								// Get next state from terminal transition matrix.

Stck:	if (++PS >= PS_end)
		{
			goto Over;
		}

		if ( LOOKAHEADS == ++lookaheads )
		{
			goto Ret;
		}

		PS->state = x;												// Put current state on stack.   
		x = y;

		while ( x < 0 )												// While shift-reduce actions. 
		{
			PS -= PL[ -x ];											// Reduce stack ptr by production length. 
			x = Nm[ Nr[ PS->state ] + Nc[ -x ] ];					// Get next state from nonterminal transition matrix.
		}

		goto Read;													// Go to read next token.
	}

	if ( ( p = Rr[ x ] ) > 0 || ( p = Rm[ Rc[ t ] - p ] ) > 0 )		// Get reduction?
	{
Red:	PS -= PL[ p ];												// Reduce parse stack ptr by rule length - 1. 

		if ( PL[ p ] < 0 )											// Null production?
		{	
			if ( PS >= PS_end )										// Check for stack overflow.
			{
				goto Over;
			}

			PS->state = x;											// Stack current state, replacing old state.
		}

		while ( 1 ) 
		{
			x = Nm[ Nr[ PS->state ] + Nc[ p ] ];					// Get next state from nonterminal transition.

			if ( x > 0 )											// If a state, continue parsing.
			{
				goto Shft;											
			}

			p = -x;													// Make the production number positive.
			PS -= PL[ p ];											// Reduce parse stack ptr by rule length - 1. 
		}
	}

	if ( nd_state[ x ] )											// Nondeterministic state?
	{
		y = nd_lookahead( P_stack, PS, x, t );

		if ( 2147483647 != y )
		{
Act:		if ( y > 0 )											// Shift and Goto?
			{
				if ( y > ACCEPT_STATE )								// Shift and reduce?
				{
					y = ( ACCEPT_STATE - y );						// Convert to production #
				}
				
				goto Stck;											// Go shift this token. 
			}

			p = -y;													// Get production.
			goto Red;												// Reduce.
		}
	}

	if ( ACCEPT_STATE == x )										// If Goal production.  
	{
		lookaheads = LOOKAHEADS;
	}

Ret:  token.start    = TS; 
      token.end      = TE;
      token.linenumb = LN;

      return lookaheads;											// Error, return zero lookaheads.

Over: PrintConsole( true, "\nParser stack overflow.\n\n" );
		return_code |= RC_INTERNAL_ERROR;
		throw return_code;

		return 0;
}

/////////////////////////////////////////////////////////////////////////////////////////////////////
//                                                                                                 // 
//		recover() - Recover from the error.

PStack* parser::recover( PStack* PS, int t )
{
	while ( t != eof_symb )
	{
		if ( STMT_END == t )
		{
			while ( PS > P_stack )
			{
				if ( -STMT_BEG == PS->sym )
				{
					return --PS; // success
				}
			
				PS--;
			}
			
			return 0; 
		}
		
		t = get_token( );
	}
	
	return 0; // failure
}

/////////////////////////////////////////////////////////////////////////////////////////////////////
//                                                                                                 // 
//		restore() - Restore the parse stack.

int parser::restore( )
{
	PS = PX;

	while ( RS > R_stack )				// Restore PS, RS and states.
	{
		RS->ptr->state = RS->state;		// Reset state to saved state.
		RS--;
	}

	return topstate;
}

/////////////////////////////////////////////////////////////////////////////////////////////////////
//                                                                                                 // 
//		reduce

int parser::reduce( int p )
{
	if ( pact_numb[ p ] >= 0 )	  							// PARSE ACTION ?  
	{	   
		if ( 0 == ( *pact_func[ pact_numb[ p ] ] )( p ) )
		{
			return 0;										// Call parse action with production number.
		}
	}
	
	int psi;	 											// Parse Stack Index.
	
	if ( node_numb[ p ] >= 0 )   							// MAKE NODE ?
	{
		if ( n_nodes >= max_nodes )							// If too many nodes?  
		{
			PrintConsole( true, "Number of AST nodes exceeds limit of %d.\n", max_nodes );
			return_code |= RC_AST_OVERFLOW;
			
			throw return_code;
		}
	
		node[ n_nodes ].id     = node_numb[ p ];			// Set node id. 
		node[ n_nodes ].prod   = p;							// Put production (rule) number in node.
		node[ n_nodes ].prev   = 0;							// Set prev to nonexistent.
		node[ n_nodes ].next   = 0;							// Set next to nonexistent.
		node[ n_nodes ].child  = 0;							// Set child to nonexistent.
		node[ n_nodes ].parent = 0;							// Set parent to nonexistent.
	
		if ( pact_arg[ p ] >= 0 )							// If parse-action argument specified in grammar.
		{
			psi = arg_numb[ pact_arg[ p ] ] - 1;			// Get parse-stack index.

			if ( psi >= 0 )
			{
				node[ n_nodes ].sti  = PS[ psi ].sti;		// Move sti from parse stack to node.
				node[ n_nodes ].line = PS[ psi ].line;		// Move line from parse stack to node.
			}
			else
			{
				node[ n_nodes ].sti = 0;					// Set symbol-table index to zero.
				node[ n_nodes ].line = 0;					// Set line number to zero.

				// 6/24/2015 JJO - BEGIN HACK
				//
				// Hack to correct issue where the Atlas source code line number will be
				// zero when there is no statement number for lines that contain an Atlas 
				// verb.
				//
				// NOTE: It appears that the only time this "else" is entered is when there
				// is no statement number. So it could be an overkill to create and use 
				// variable "iStatementNumberNodeNameIndex". Instead of just assigning zero
				// as the original code did, we could just assign "token.linenumb" and do 
				// without the condition test first.
				//
				// The reason this is a hack and not a bug fix is that the real problem/bug 
				// for this issue is that the node that contains the Atlas verb symbol will 
				// contain the incorrect line number. Variable PS which is a pointer into 
				// array P_stack will be set to the wrong offset. The offset is determined 
				// by production rule information that is used as indices into lookup tables.
				// The code that updates variable PS is in function "parser::parse".
				//
				if ( iStatementNumberNodeNameIndex == node[ n_nodes ].id )
				{
					node[ n_nodes ].line = token.linenumb;
				}
				//
				// END HACK
			}
		} 
		else
		{
			node[ n_nodes ].sti = 0;						// Set symbol-table index to zero.
			node[ n_nodes ].line = 0;						// Set line number to zero.
		}

		psi = linkup( p );									// Linkup the nodes in this rule. 

		if ( psi >= 0 )										// Any nodes found in this rule?
		{
			node[ n_nodes ].child = PS[ psi ].node;			// Define child. 
			node[ PS[ psi ].node ].parent = n_nodes;		// Define parent.
		}

		PS[ 0 ].node = n_nodes;								// Define this node in the parse stack.
		PS[ 0 ].last = n_nodes;								// Define this node in the parse stack.

		n_nodes++;								
	}  
	else													// Check for nodes not linked?
	{
		psi = linkup( p );									// Get parse-stack index.  

	  	if ( psi > 0 )										// If we have a node here ...
		{
		  	PS[ 0 ].node = PS[ psi ].node;					// Move node to 1st position.
		  	PS[ 0 ].last = PS[ psi ].last;					// Move last also.
		}	
	}  
	
	return 1; // OK. 
}

/////////////////////////////////////////////////////////////////////////////////////////////////////
//                                                                                                 // 
//		linkup

int parser::linkup( int p )
{
	int next = -1;
	int i;

	if ( 0 == reverse[ p ] )										// IF NOT TO REVERSE THE ORDER. 
	{
		for ( i = PL[ p ]; i >= 0; i-- )							// For each tail pointer. 
		{
			if ( PS[ i ] .node > 0 )								// If tail points to node.	  
			{
				if ( next >= 0 )									// If one waiting.        
				{
					node[ PS[ i ].last ].next = PS[ next ].node;	// Define next node.
					node[ PS[ next ].node ].prev = PS[ i ].last;	// Define previous node.
					PS[ i ].last = PS[ next ].last;					// Change last to next last.
				}

				next = i;											// Next = Curr.  
			}
		}  
	}
	else															// REVERSE THE ORDER.
	{
		for ( i = 0; i <= PL[ p ]; i++ )							// For each tail pointer. 
		{
			if ( PS[ i ].node > 0 )									// If tail points to node.
			{
				if ( next >= 0 )									// If one waiting.        
				{
					node[ PS[ i ].last ].next = PS[ next ].node;	// Define next node.
					node[ PS[ next ].node].prev = PS[ i ].last;		// Define previous node.
					PS[ i ].last = PS[ next ].last;					// Change last to next last.
				}

				next = i;											// Next = Curr.  
			}  
		}  
	}

	return next;
}

/////////////////////////////////////////////////////////////////////////////////////////////////////
//                                                                                                 // 
//    prt_error	

void parser::prt_error( uchar *symb )
{       
	int  i, col, ln1, ln2;
	uchar string[ 256 ], *ls1, *ls2, *le1, *le2, *p, c;
	
	PrintConsole( false, "\nError at %s\n", symb );

	// Get first line number ...
	ln1 = token.linenumb;

	// Get first line start ...
	for ( ls1 = token.start; '\n' != *ls1; ls1-- );
	ls1++;

	// Get first line end ...
	for ( le1 = token.start; '\n' != *le1; le1++ );

	// Get last line number ...
	ln2 = token.linenumb;
	for ( p = token.start; p < token.end; p++ )
	{
		if ( '\n' == *p )
		{
			ln2++;
		}
	}

	// Get last line start ...
	for ( ls2 = token.end-1; '\n' != *ls2; ls2-- ); 
	ls2++;

	// Get last line end ...
	for ( le2 = token.end; '\n' != *le2; le2++ );
	*le1 = 0;
	*le2 = 0;

	if ( '\n' == *token.start )
	{
		ln1--;
	}

	PrintConsole( false, "\n%s(%d) : Error  %s\n", path, ln1, ls1 );
	
	col = 1;

	for ( p = ls1; p < token.start; p++ )
	{
		if ( '\t' == *p )
		{
			*p = ' ';
		}

		col++;
	}

	for ( i = 0; i < col; i++ )
	{
		string[ i ] = '-';
	}

	string[ col ] = 0;

	PrintConsole( false, "%s(%d) : Error %s^ ", path, ln1, string );

	if ( *token.start <= 32 )
	{
		int x = *token.start;

		if ( x < 0 )
		{
			x += 256;
		}

		PrintConsole( false, "at \\%d %s\n\n", x, symb );
	}
	else
	{
		if ( token.end == token.start )
		{
			token.end++;
		}

		if ( token.end > le1 ) 
		{
			if ( '\n' == *token.start )
			{
				*token.start = 0;
			}

            if ( EOF_CHAR == *token.end )
			{
				linenumb--;
			}

			c = *le1; 
			*le1 = 0;

			PrintConsole( false, "starts here\n" );
			PrintConsole( false, "\n%s(%d) : Error  %s\n", path, ln2, ls2 );

			col = 1;

			for ( p = ls2; p < token.end; p++ )
			{
				if ( '\t' == *p )
				{
					*p = ' ';
				}

				col++;
			}

			for ( i = 0; i < col; i++ )
			{
				string[ i ] = '-';
			}

			string[ col ] = 0;

			PrintConsole( false, "%s(%d) : Error %s^ ", path, ln2, string );
			PrintConsole( false, "ends here.\n\n" );

			*le1 = c;
		}
		else
		{
			c = *token.end; 
			*token.end = 0;

			if ( '\n' == *token.start )
			{
				*token.start = 0;
			}

			PrintConsole( false, "at %s %s\n\n", token.start, symb );

			*token.end = c;
		}
	}
}

/////////////////////////////////////////////////////////////////////////////////////////////////////
//                                                                                                 // 

void parser::prt_stack( ) // Print parser stack.
{
	PrintConsole( false, "Parse stack:\n\n" );

	for ( PStack* ps = P_stack+1; ps <= PS; ps++ )
	{
		uchar* symbol;
		int sym = ps->sym;

		if ( sym >= 0 )
		{
			symbol = ( uchar* ) term_symb[ sym ];
		}
		else
		{
			symbol = ( uchar* ) head_symb[ sym = -sym ];
		}

		PrintConsole( false, "\t%4d %s\n", sym, symbol );
	}

	PrintConsole( false, "\n" );
}

/////////////////////////////////////////////////////////////////////////////////////////////////////
//                                                                                                 // 
//		expecting // Print expecting list. 

void parser::expecting( )
{
	int  t;
	int  x;
	int* seq;
	state  = restore( ); // Restore the parse stack. 

	try
	{
		seq = new int[ n_terms ];
	}
	catch ( ... )
	{
		PrintConsole( true, "Failed to allocate memory for sort sequence" );
		return_code |= RC_MEMORY_OVERFLOW;
		throw return_code;
	}

	try
	{
		P_list = new int[ n_prods ];
	}
	catch ( ... )
	{
		delete [ ] seq;

		PrintConsole( true, "Failed to allocate memory for prodoction list." );
		return_code |= RC_MEMORY_OVERFLOW;
		throw return_code;
	}

	try
	{
		T_list = new uchar[ n_terms ];
	}
	catch ( ... )
	{
		delete [ ] P_list;
		delete [ ] seq;

		PrintConsole( true, "Failed to allocate memory for terminal symbol list." );
		return_code |= RC_MEMORY_OVERFLOW;
		throw return_code;
	}

	for ( t = 0; t < n_terms; t++ )
	{
		T_list[ t ] = 0;
	}
	
	PrintConsole( true, "In state %d, expecting one of the following:\n\n", state );
	
	collect( state ); // Collect all terminal symbols expected. 
	sort_names( ( uchar** ) term_symb, n_terms, seq );

	for ( t = 0; t < n_terms; t++ )
	{
		x = seq[ t ];

		if ( T_list[ x ] )
		{
			if ( '<' == term_symb[ x ][ 0 ] )
			{
				PrintConsole( false, "\t%4d %-20s\n", x, term_symb[x] );
			}
		}
	}

	for ( t = 0; t < n_terms; t++ )
	{
		x = seq[ t ];

		if ( T_list[ x ] )
		{
			if ( '<' != term_symb[ x ][ 0 ] )
			{
				PrintConsole( false, "\t%4d %-20s\n", x, term_symb[ x ] );
			}
		}
	}

	PrintConsole( false, "\n" );

	delete [ ] P_list;
	delete [ ] T_list;
	delete [ ] seq;
}

/////////////////////////////////////////////////////////////////////////////////////////////////////
//                                                                                                 // 
//		collect: Collect terminals that cause a transition or reduction.			                     

void parser::collect( int x )
{
	int t, p, q, i, la, n_red;

	// Transitions to next state? ...
	for ( t = 0; t < n_terms; t++)						// For all terminals.
	{
		if ( Bm[ Br[ x ] + Bc[ t ] ] & Bmask[ t ] )		// Accept this terminal?
		{
			T_list[ t ] = 1;							// Mark this terminal.
		}
	}

	n_red  = 0;											// Reset to zero reductions. 

	// Reductions in this state? ...
	if ( ( p = Rr[ x ] ) > 0 )							// Default reduction?
	{
		P_list[ n_red++ ] = p;							// Add this production to list.
	}
	else												// Reductions based on lookaheads!    		
	{
		for ( la = 0; la < n_terms; la++ )				// For all lookaheads.
		{
			if ( ( q = Rm[ Rc[ la ] - p ] ) > 0 )		// Got a reduction on this terminal?
			{	
				T_list[ la ] = 1;						// Mark this terminal.

				for ( i = 0; i < n_red; i++ )			// For all reductions in the list.
				{
					if ( P_list[ i ] == q )				// Already in this list?
					{
						goto Next;
					}
				}

				P_list[ n_red++ ] = q;					// Add this production to list.
			}

Next:       continue;
		}

		for ( i = nd_start[ x ]; i < nd_start[ x + 1 ]; i++ )	// For all nondeterministic terminals.
		{
			T_list[ nd_term[ i ] ] = 1;							// Mark this terminal.
			p = -nd_action[ i ];								// Get action.

			if ( p > 0 )										// Is it a production?
			{
				for ( int j = 0; j < n_red; j++ )				// For all reductions in the list.
				{
					if ( P_list[ j ] == p )						// Already in this list?
					{
						goto Next2;
					}
				}

				P_list[ n_red++ ] = p;							// Add this production to list.
			}

Next2:		continue;
		}
	}

	// MAKE REDUCTIONS ...
	for ( i = 0; i < n_red; i++ )
	{
		p = P_list[ i ];

		if ( PL[ p ] < 0 )							// Null production?
		{
			PS++;									// Increment stack pointer.
			PS->state = x;							// Stack state.

			goto Cont;
		}

		do			  
		{
			PS -= PL[ p ];							// Reduce parse stack pointer. 
Cont:		p = -Nm[ Nr[ PS->state ] + Nc[ p ] ];	// Get production or next state.
		}
		while ( p > 0 );

		collect( -p );								// Go collect terminals.	
	}	  
}

////////////////////////////////////////////////////////////////////////////////
//                                                                            //

void parser::sort_names( uchar** name, int n, int* seq )
{
   /* seq - the sorted sequence:
	         name[seq[0]] gives the first name in the sorted list.

				example:
				name[0] = "c", seq[0] = 3
				name[1] = "d", seq[1] = 2
				name[2] = "b", seq[2] = 0
				name[3] = "a", seq[3] = 1
	 */

	const char* pszMemoryErrorMsg = "Failed to allocate memory for bubble sort.";
	uchar** P, *P_temp;
	int* L, L_temp, seq_temp, i, j, leng, c;

	try
	{
		L = new int[ n ];
	}
	catch ( ... )
	{
		PrintConsole( true, pszMemoryErrorMsg );
		return_code |= RC_MEMORY_OVERFLOW;
		throw return_code;
	}

	try
	{
		P = new uchar*[ n ];
	}
	catch ( ... )
	{
		delete [ ] L;

		PrintConsole( true, pszMemoryErrorMsg );
		return_code |= RC_MEMORY_OVERFLOW;
		throw return_code;
	}

	for ( i = 0; i < n; i++ )
	{
		P[ i ]   = name[ i ];
		L[ i ]   = strlen( ( char* )name[ i ] );
		seq[ i ] = i;
	}

	for ( i = 1; i < n; i++ )	// Bubble sort algorithm.
	{
		P_temp   = P[ i ];
		L_temp   = L[ i ];
		seq_temp = seq[ i ];
		j        = i - 1;

		do
		{
			leng = L[ j ];

			if ( L_temp < L[j] )
			{
				leng = L_temp;
			}

			c = strncmp( ( char* ) P_temp, ( char* ) P[ j ], leng );

			if ( ( c < 0 ) || ( ( c == 0 ) && ( L_temp < L[ j ] ) ) )
			{
				P[ j + 1 ]		= P[ j ];
				L[ j + 1 ]		= L[ j ];
				seq[ j + 1 ]	= seq[ j ];
				P[ j ]			= P_temp;
				L[ j ]			= L_temp;
				seq[ j ]		= seq_temp;
			}
            else
			{
				break;
			}
         }
         while ( --j >= 0 );
      }

      delete [ ] L;
      delete [ ] P;
}

/////////////////////////////////////////////////////////////////////////////////////////////////////
//                                                                                                 // 
//    prt_prod                                                                                     

void parser::prt_prod( uchar* prefix, int p, uchar* suffix )
{
	PrintConsole( false, "%s%6d %s <- ", prefix, p, head_symb[ head_numb[ p ] ] );
	
	int i;
	int first = f_tail[ p ];
	int next_first = f_tail[ p + 1 ];

	for ( i = first; i < next_first; i++ )
	{
		uchar* symb;
		int   s = tail[ i ];

		if ( s >= 0 )
		{
			symb = ( uchar* ) term_symb[ s ];
		}
		else
		{
			symb = ( uchar* ) head_symb[ -s ];
		}

		PrintConsole( false, "%s ", symb );
	}

	PrintConsole( false, "%s\n", suffix );
}

/////////////////////////////////////////////////////////////////////////////////////////////////////
//                                                                                                 // 
//    init_symtab

int parser::init_symtab( int max_symb )
{
	const char* pszMemoryErrorMsg = "Not enough memory available for Symbol Table.\n";
	int i; 

	if ( max_symb <= 0 )
	{	
		PrintConsole( true, "Maximum number of symbols cannot be zero or negative.\n" );
		return_code |= RC_INTERNAL_ERROR;

		throw return_code;
	}

	max_symbols   = max_symb;
	max_cells     = ( 2 * max_symbols );
	hashdiv       = ( UINT_MAX / max_cells + 1 );
	n_symbols	  = 0;
	n_keywords	  = 0;


	try
	{
		symbol = new Symbol[ max_symbols ];
	}
	catch ( ... )
	{
		PrintConsole( true, pszMemoryErrorMsg );
		return_code |= RC_MEMORY_OVERFLOW;
		throw return_code;
	}

	try
	{
		hashvec = new int[ max_cells ];
	}
	catch ( ... )
	{
		PrintConsole( true, pszMemoryErrorMsg );
		return_code |= RC_MEMORY_OVERFLOW;
		throw return_code;
	}

	for ( i = 0; i < max_cells; i++ )
	{
		hashvec[ i ] = -1;
	}

	return 1; // Return OK.
}
													        
/////////////////////////////////////////////////////////////////////////////////////////////////////
//                                                                                                 // 
//    term_symtab

void parser::term_symtab( ) 
{
	delete [ ] symbol;
	symbol = 0;

	delete [ ] hashvec;
	hashvec = 0;
}

/////////////////////////////////////////////////////////////////////////////////////////////////////
//                                                                                                 // 
//    add_symb - add symbol to table.     											                        

int	parser::add_symbol( int t, uchar* token_start, uchar* token_end )
{
	sti = get_symbol( token_start, token_end );

	if ( sti < 0 ) 
	{
		sti = n_symbols;

		if ( n_symbols >= max_symbols )				// Reached maximum number? 
		{
			PrintConsole( true, "\nNumber of symbols exceeds %d.\n\n", max_symbols );
			return_code |= RC_SYMBOL_OVERFLOW;

			throw return_code;
		}

		hashvec[ cell ] = n_symbols;			// Put symbol number into hash vector.     

		symbol[ n_symbols ].name = token_start;	// Define pointer to symbol name.
		symbol[ n_symbols ].length = length;	// Define symbol name length.
		symbol[ n_symbols ].term = t;			// Define terminal number (<identifier>, <string>, <number>, ...)
		symbol[ n_symbols ].type = 0;			// Define type as undefined (zero).
		symbol[ n_symbols ].scope= 0;			// Define scope as undefined (zero).
		symbol[ n_symbols ].cell = cell;		// Define hash vector cell number for this symbol.

		n_symbols++;							// Increment number of symbols.
	}

	return sti;									// Return symbol-table index.
}

/////////////////////////////////////////////////////////////////////////////////////////////////////
//                                                                                                 // 
//    get_symbol - get symbol number from table.									                        

int parser::get_symbol( uchar* token_start, uchar* token_end )
{
	uchar* p = token_start;					 	// Point at start.
	length = token_end - token_start;  			// Set length. 
	uint hash = length;         	   			// Set hash to length. 
	int i = 0;						   			// Set shift value to 0.

	do											// Assume length != 0
	{
		hash += *p << i;
		i += 4;		                  			
		i %= 32;
	}
	while ( ++p < token_end );

	cell = hash % max_cells; 					// Get first cell.
	i = hashvec [ cell ];			   			// Get symbol index.

	if ( i >= 0 ) 
	{
		p = token_start;						// Point at token start.

		do
		{
			if ( symbol[ i ].length == length )	// If lengths are equal ...
			{
				uchar* q = symbol[ i ].name;	// Point at symbol name.
				int j = 0; 

				do 
				{
					if ( p[ j ] != q[ j ] )		// If characters not equal ...		
					{
						goto Cont;	
					}
				}
				while ( ++j < length );			// while end not reached. 

				return i;						// Found it.
			}

			Cont:    cell = ( ( hash *= 65549 ) / hashdiv );		// Get new cell number.

			i = hashvec[ cell ];				// Get symbol index.
		}
		while ( i >= 0 );      					// While not empty slot.
	}

	return i;									// Return symbol number.
}

/////////////////////////////////////////////////////////////////////////////////////////////////////
//                                                                                                 // 
//    print - print symbol table contents.     										                        

void parser::print_symtab( uchar* term_symb[ ] )
{
	if ( cOption::debug )
	{
		if ( n_symbols > 1 )
		{
			fprintf( cDebug::filedesc, "Symbol Table ...\n\n" );
			fprintf( cDebug::filedesc, "  sti  leng  type  term  \n" );
		
			for ( int i = 1; i < n_symbols; i++ )
			{
				fprintf( cDebug::filedesc, "%5d %5d %5d %5d   %-30s  %s\n",
					i,
					symbol[ i ].length,
					symbol[ i ].type,
					symbol[ i ].term, 
					term_symb[ symbol[ i ].term ],
					symbol_name( i ) ); 
			}   

			fprintf( cDebug::filedesc, "\n" );
		}
		else
		{
			fprintf( cDebug::filedesc, "Symbol Table is empty!\n\n" );
		}
	}
}

/////////////////////////////////////////////////////////////////////////////////////////////////////
//                                                                                                 // 
//    symname - get symbol name. 

uchar* parser::symbol_name( int i )
{
	static uchar name[ 2048 ];
	int L;
	uchar* p;

	if ( 0 == i ) 
	{
		name[ 0 ] = 0;
	}
	else if ( i < 0 )
	{
		p = ( uchar* ) term_symb[ -i ];

		for ( i = 0; p[ i ] != 0; i++ )
		{
			name[ i ] = p[ i ];
		}

		name[ i ] = 0;
	}
	else
	{
		p = symbol[ i ].name;
		L = symbol[ i ].length;

		if ( L >= sizeof( name ) ) 
		{
			#if ( _DEBUG ) && ( WIN32 )
				DebugBreak( );
			#endif

			L = ( sizeof( name ) - 5 );

			for ( i = 0; i < L; i++ )
			{
				name[ i ] = p[ i ];
			}

			name[ i++ ] = ' ';
			name[ i++ ] = '.';
			name[ i++ ] = '.';
			name[ i++ ] = '.';
			name[ i ] = 0;
		}
		else
		{
			for ( i = 0; i < L; i++ )
			{
				name[ i ] = p[ i ];
			}

			name[ i ] = 0;
		}
	}

	return name;
}

///////////////////////////////////////////////////////////////////////////////
//                                                                           // 

uchar* parser::remove_quotes( uchar* x )
{
	static uchar str[ 2048 ];

	uchar* p = x;

	if ( '\'' == *p )
	{
		p++; 
	}
	else if ( 145 == *p )
	{
		p++; 
	}
	else if ( 146 == *p )
	{
		p++; 
	}

	int checkforendquote = 0;

	if ( p > x )
	{
		checkforendquote = 1;
	}
	else if ( ( 'C' == *p ) && ( '\'' == *( p + 1 ) ) )	// Fixed 20140924 by PBM.
	{
		p += 2; 
		checkforendquote = 1;
	}

	uchar* q = str;

	while ( *p != 0 )
	{
		*q++ = *p++;
	}

	if ( checkforendquote )
	{
		if ( ( '\'' == *( q - 1 ) ) || ( 145 == *( q - 1 ) ) || ( 146 == *( q - 1 ) ) )
		{
			q--;
		}
	}

	*q = 0;		// Fixed 20140924 by PBM.

	return str;
}

/////////////////////////////////////////////////////////////////////////////////////////////////////
//																										                     // 
//    ABSTRACT-SYNTAX-TREE FUNCTIONS														                     

static uchar numeric[ 256 ] = /* numeric[ x ] gives 1..10 for digits 0..9 */
{
  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
  1,  2,  3,  4,  5,  6,  7,  8,  9, 10,  0,  0,  0,  0,  0,  0,
  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0 
};

Stack* AST::stack;
int    AST::stacki;

uchar draw_plus[ ]  = "+ ";                     
uchar draw_vbar[ ]  = "| ";
uchar draw_last[ ]  = "+ ";
uchar draw_space[ ] = "  ";

int*  AST::counter;
uchar  AST::indent[ 256 ];

static int space_before = 0;

/////////////////////////////////////////////////////////////////////////////////////////////////////
//                                                                                                 // 
//    init_ast                                                                                     

int parser::init_ast( int Max_nodes )
{
	max_nodes = Max_nodes;

	if ( max_nodes <= 0 )
	{	
		PrintConsole( true, "Maximum number of AST nodes cannot be %d.\n", max_nodes );
		return 0; // Return error.
	}

	try
	{
		node = new Node[ max_nodes ]; 
	}
	catch ( ... )
	{
		PrintConsole( true, "Not enough memory available for %d AST nodes.\n", max_nodes );
		return_code |= RC_MEMORY_OVERFLOW;
		throw return_code;
	}

	root             =  0;	// In case of internal error.
	node[ 0 ].id     = -1; // Undefined.
	node[ 0 ].prod   =  0;          
	node[ 0 ].sti    =  0;          
	node[ 0 ].line   =  0;								
	node[ 0 ].next   =  0;          
	node[ 0 ].prev   =  0;							   
	node[ 0 ].child  =  0;          
	node[ 0 ].parent =  0;							   
	n_nodes          =  1;  
	
	return 1; // Return OK.
}

/////////////////////////////////////////////////////////////////////////////////////////////////////
//                                                                                                 // 
//    term_ast                                                                                     

void parser::term_ast( )
{
	delete [ ] node;
	node = 0;

	delete [ ] stack;
	stack = 0;

	delete [ ] counter;
	counter = 0;
}

/////////////////////////////////////////////////////////////////////////////////////////////////////
//                                                                                                 // 
//    print_ast ()                                                                                 

void parser::print_ast( )
{
	if ( cOption::debug )
	{
		if ( n_nodes > 1 )
		{
			print_ast( root );
		}
		else
		{
			fprintf( cDebug::filedesc, "AST is empty.\n\n" );
		}
	}
}

/////////////////////////////////////////////////////////////////////////////////////////////////////
//                                                                                                 // 
//    print_ast(n)                                                                                

void parser::print_ast( int n ) // Print subtree.
{
	if ( ( n < n_nodes ) && ( n > 0 ) )
	{
		uchar indent[ 512 ];

		strcpy( ( char* ) indent, ( char* ) draw_space );

		fprintf( cDebug::filedesc, "Abstract Syntax Tree ...\n\n" );
		fprintf( cDebug::filedesc, "  node  prev  next parent child  line   sti \n" );
	
		traverse( indent, n ); // Start AST traversal.    

		fprintf( cDebug::filedesc, "\n" );
	}
	else 
	{
		fprintf( cDebug::filedesc, "Internal error, node %d is not in AST.\n\n", n );
	}
}

/////////////////////////////////////////////////////////////////////////////////////////////////////
//                                                                                                 //
//    traverse                                                                                     

void parser::traverse( uchar* indent, int n )
{
	while ( node[ n ].next > 0 )
	{
		strcat( ( char* ) indent, ( char* ) draw_plus );
		
		print_node( indent, n );
		indent[ strlen( ( char* ) indent ) - 2 ] = 0;
		
		if ( node[ n ].child > 0 )
		{
			strcat( ( char* ) indent, ( char* ) draw_vbar );
			traverse( indent, node[n].child );
			indent[ strlen( ( char* ) indent ) - 2 ] = 0;
		}
		
		n = node[ n ].next;
	}
		
	strcat( ( char* ) indent, ( char* ) draw_last );
	print_node( indent, n );
	indent[ strlen( ( char* ) indent ) - 2 ] = 0;
	
	if ( node[ n ].child > 0 )
	{
		strcat( ( char* ) indent, ( char* ) draw_space );
		traverse( indent, node[ n ].child );
		indent[ strlen( ( char* ) indent) - 2 ] = 0;
	}
}

/////////////////////////////////////////////////////////////////////////////////////////////////////
//                                                                                                 //
//    print_node                                                                                   

void parser::print_node( uchar *indent, int n )  /* Print this node function. */
{
	int i;
	int sti;
	sti = node[ n ].sti;

	fprintf( cDebug::filedesc, " %5d %5d %5d %6d %5d %5d %5d %s%s",
		n, 
		node[ n ].prev, 
		node[ n ].next, 
		node[ n ].parent, 
		node[ n ].child, 
		node[ n ].line, 
		sti, 
		indent, 
		node_name[node[n].id]);

	if ( 0 != sti ) // zero means no symbol.
	{
		uchar* q;
		int L;
		uchar string[ 100 ];

		if ( sti > 0 ) // a symbol found in the input file?
		{
			q = symbol[ sti ].name;
			L = symbol[ sti ].length;
		}
		else // a terminal symbol of the grammar!
		{	
			q = ( uchar* ) term_symb[ -sti ];
			L = strlen( ( char* ) q );
		}

		if ( L > 99 )
		{
			L = 99;
		}

		for ( i = 0; i < L; i++, q++ ) // Replace '\n' with \1
		{
			if ( '\n' == *q )
			{
				string[ i ] =  1; // one = happy face.
			}
			else
			{
				string[ i ] = *q;
			}
		}

		string[ i ] = 0;
	//	fprintf (cDebug::filedesc, " (%s,%s,%d)", string, term_symb [symbol[sti].term], symbol[sti].type);
		fprintf( cDebug::filedesc, " (%s)", string );
	}

	fprintf( cDebug::filedesc, "\n" );
}

static uchar spaces[ 100 ];

/////////////////////////////////////////////////////////////////////////////////////////////////////
//                                                                                                 // 
//    traverse                                                                                     

void parser::traverse( )
{
	if ( n_nodes > 1 )			// Any nodes in the tree? 
	{
		if ( n_nodeactns > 0 )	// Any AST actions?
		{
			const char* pszMemoryErrorMsg = "Failed to allocate memory for AST traversal.";
			int i;

			stacki  = -1;

			try
			{
				stack = new Stack[ STKSIZE ];
			}
			catch ( ... )
			{
				PrintConsole( true, pszMemoryErrorMsg );
				return_code |= RC_MEMORY_OVERFLOW;
				throw return_code;
			}

			try
			{
				counter = new int[ n_nodenames ];
			}
			catch ( ... )
			{
				PrintConsole( true, pszMemoryErrorMsg );
				return_code |= RC_MEMORY_OVERFLOW;
				throw return_code;
			}


			for ( i = 0; i < n_nodenames; i++ )
			{
				counter[ i ] = 0;
			}

			// fprintf( cDebug::filedesc, "Output ...\n\n" );

			traverse( root );	// Start AST traversal.

			// fprintf( cDebug::filedesc, "\n" );
		}
	}
}

/////////////////////////////////////////////////////////////////////////////////////////////////////
//                                                                                                 //
//    traverse (n)                                                                                 

void parser::traverse( int n )
{
	int c, i, p, na;

	i = node[ n ].id;
	p = node[ n ].prod;
	counter[ i ]++;
	stacki++;
	stack[ stacki ].id = i;
	stack[ stacki ].counter = counter[ i ];
	na = nact_numb[ p ];

	if ( na >= 0 )
	{
		status = TOP_DOWN;
		( *nact_func[ na ] )( n );
	}

	c = node[ n ].child;                

	while ( c > 0 )
	{
		traverse( c );

		if ( c = node[ c ].next )
		{
			if ( na >= 0 )
			{
				status = PASS_OVER;
				( *nact_func[ na ] )( n );
			}
		}  
	}  

	if ( na >= 0 ) 
	{
		status = BOTTOM_UP;
		( *nact_func[ na ] )( n );
	}

	stacki--;
}

/////////////////////////////////////////////////////////////////////////////////////////////////////
//                                                                                                 // 

void parser::prt_line( ) // Print current line being parsed.
{
	if ( linenumb > linenumb_printed )
	{
		linenumb_printed = linenumb;

		if ( EOF_CHAR != *token.start ) // Not end of file?
		{
			uchar* ls = token.start;
			uchar* le = token.end;
		
			// Find line start.
			while ( ( '\n' != *ls ) && ( 1 != *ls ) && ( 2 != *ls ) )
			{
				ls--; 
			}

			ls++;
		
			// Find line end.
			while ( ( '\n' != *le ) && ( 1 != *ls ) && ( 2 != *ls ) )
			{
				le++;
			}

			*le = 0;
		
			// Print line. 
			if ( cOption::echo )
			{
				PrintConsole( false,                  "%6d  %s\n", linenumb, ls );
			}

			if ( cOption::debug )
			{
				fprintf( cDebug::filedesc, "%6d  %s\n", linenumb, ls );
			}

			*le = '\n';
		}
		else
		{
			// Print blank line. 
			if ( cOption::echo )
			{
				PrintConsole( false,                   "\n");
			}

			if ( cOption::debug )
			{
				fprintf( cDebug::filedesc, "\n" );
			}
		}
	}
}