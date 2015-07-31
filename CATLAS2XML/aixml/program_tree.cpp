/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

#include "program_tree.h"
#include "statements.h"
#include "perform.h"
#include "xml.h"
#include "helper.h"

void ProgamTree::CreateTree( iterator itItem, const map< string, vector< AtlasStatement* > >& mapProcCalls, map< string, pair< string, unsigned int > >& mapProcsCalled, const vector< AtlasStatement* >* pVect )
{
	/*

	// Test code for "Tree"

	Tree< string > tree;
	
	Tree< string >::iteratorHash itHash( 0 );
	
	string strFruit( "fruit" );
		string strApple( "apple" );
		string strOrange( "orange" );
	
	string strVegtable( "vegtable" );
		string strCarrot( "carrot" );
		string strCelery( "celery" );
	
	string strMeat( "meat" );
		string strSteak( "steak" );
		string strChicken( "chicken" );
		string strHamburger( "hamburger" );
	
	Tree< string >::ePosition ePos = Tree< string >::eFirst;
	
	Tree< string >::iterator it = tree.begin( );
	Tree< string >::iterator itEnd = tree.end( );
	
	Tree< string >::iterator itFruit = tree.insert( it, strFruit, Tree< string >::eSibling, ePos );
	Tree< string >::iterator itVegtable = tree.insert( it, strVegtable, Tree< string >::eSibling, ePos );
	Tree< string >::iterator itMeat = tree.insert( it, strMeat, Tree< string >::eSibling, ePos );
	
	Tree< string >::iterator itApple = tree.insert( itFruit, strApple, Tree< string >::eChild, ePos );
	Tree< string >::iterator itOrange = tree.insert( itFruit, strOrange, Tree< string >::eChild, ePos );
	
	Tree< string >::iterator itCarrot = tree.insert( itVegtable, strCarrot, Tree< string >::eChild, ePos );
	Tree< string >::iterator itCelery = tree.insert( itVegtable, strCelery, Tree< string >::eChild, ePos );
	
	Tree< string >::iterator itSteak = tree.insert( itMeat, strSteak, Tree< string >::eChild, ePos );
	Tree< string >::iterator itHamburger = tree.insert( itMeat, strHamburger, Tree< string >::eChild, ePos );
	Tree< string >::iterator itChicken = tree.insert( itMeat, strChicken, Tree< string >::eChild, ePos );
	
	itHash = itMeat.hash( );
	
	Tree< string >::iterator itMeatCopy( itHash );
	
	tree.erase( itChicken, false );
	tree.erase( itHamburger, false );
	tree.erase( itSteak, false );
	
	tree.erase( itMeat, true );
	tree.erase( itVegtable, true );
	tree.erase( itFruit, true );
	
	it = tree.begin( );
	
	while ( itEnd != it )
	{
		const unsigned int uiiii = it.size( );
	
		string str( *it );
	
		Tree< string >::iterator itChild = it.firstChild( );
		
		while ( itEnd != itChild )
		{
			unsigned int ui = itChild.size( );
	
			string str1( *itChild );
		
			++itChild;
		}
	
		++it;
	}
	
	*/

	if ( 0 == pVect )
	{
		pVect = GetProcStatements( mapProcCalls, AtlasStatement::m_strMAIN_PROC_NAME );
	}

	const unsigned int uiSize = pVect->size( );
	const map< string, pair< string, unsigned int > >::const_iterator itProcsCalledEnd = mapProcsCalled.end( );

	for ( unsigned int ui = 0; ui < uiSize; ++ui )
	{
		AtlasStatement* pStatement = pVect->at( ui );

		if ( Atlas::ePERFORM == pStatement->m_eAtlasStatement )
		{
			const string strProcedureName( ( ( AtlasPerform* ) pStatement )->m_strProcedureName );
			eRelationship eRelate = eSibling;
			string strProcKey( strProcedureName );

			strProcKey += AtlasStatement::m_strColon;
			strProcKey += AIXMLHelper::NumberToString< unsigned int >( ( ( AtlasPerform* ) pStatement )->m_uiProcedureId );

			if ( itProcsCalledEnd == mapProcsCalled.find( strProcKey ) )
			{
				mapProcsCalled.insert( make_pair( strProcKey, make_pair( strProcedureName, ( ( AtlasPerform* ) pStatement )->m_uiProcedureId ) ) );
			}

			if ( itItem.isValid( ) && ( 0 == ui ) )
			{
				eRelate = eChild;
			}

			iterator itNew = Tree< AtlasStatement* >::insert( itItem, pStatement, eRelate, eLast );

			if ( eChild == eRelate )
			{
				itItem = itNew;
			}

			const vector< AtlasStatement* >* pvectProc = GetProcStatements( mapProcCalls, strProcedureName );

			if ( 0 != pvectProc )
			{
				if ( !Recursion( strProcedureName ) )
				{
					CreateTree( itNew, mapProcCalls, mapProcsCalled, pvectProc );

					PopProcedureCall( strProcedureName );
				}
				else
				{
					( ( AtlasPerform* ) pStatement )->m_strCallStack = GetCallStack( );
					( ( AtlasPerform* ) pStatement )->m_bRecursive = true;

					ClearQueue( );
				}
			}
		}
		else
		{
			insert( itItem, pStatement, eSibling, eLast );
		}
	}
}

const vector< AtlasStatement* >* ProgamTree::GetProcStatements( const map< string, vector< AtlasStatement* > >& mapProcCalls, const string& strProcName )
{
	const map< string, vector< AtlasStatement* > >::const_iterator it = mapProcCalls.find( strProcName );
	const map< string, vector< AtlasStatement* > >::const_iterator itEnd = mapProcCalls.end( );
	const vector< AtlasStatement* >* pVect = 0;

	if ( itEnd != it )
	{
		pVect = &( it->second );
	}

	return pVect;
}

void ProgamTree::ToXML( string& strXML, const unsigned int uiMainStatementsId, const bool bProceduresOnly ) const
{
	const string strProcName( XML::MakeXmlAttributeNameValue( XML::anName, AtlasStatement::m_strMAIN_PROC_NAME ) );
	const string strProcRefId( XML::MakeXmlAttributeNameValue( XML::anProcRefId, uiMainStatementsId ) );
	const string strCount( XML::MakeXmlAttributeNameValue( XML::anCount, begin( ).size( ) ) );

	// No "perform" id since the top level procedure call is not really done with a perform, its simulated.

	strXML += XML::MakeOpenXmlElementWithChildren( XML::enPerform, strProcName, strProcRefId, strCount );

	ToXML( begin( ), strXML, bProceduresOnly );

	strXML += XML::MakeCloseXmlElementWithChildren( XML::enPerform );
}

void ProgamTree::ToXML( ProgamTree::iterator& it, string& strXML, const bool bProceduresOnly ) const
{
	const iterator itEnd = end( );

	while ( itEnd != it )
	{
		const AtlasStatement* pStatement = *it;

		if ( it.isParent( ) )
		{
			const AtlasPerform* pPerform = ( AtlasPerform* ) pStatement;
			const string strProcName( XML::MakeXmlAttributeNameValue( XML::anName, pPerform->m_strProcedureName ) );
			const string strId( XML::MakeXmlAttributeNameValue( XML::anId, pPerform->m_uiId ) );
			const string strProcRefId( XML::MakeXmlAttributeNameValue( XML::anProcRefId, pPerform->m_uiProcedureId ) );
			const string strCount( XML::MakeXmlAttributeNameValue( XML::anCount, it.size( true ) ) );

			strXML += XML::MakeOpenXmlElementWithChildren( XML::enPerform, strProcName, strId, strProcRefId, strCount );

			ToXML( it.firstChild( ), strXML, bProceduresOnly );

			strXML += XML::MakeCloseXmlElementWithChildren( XML::enPerform );
		}
		else
		{
			if ( ( Atlas::ePERFORM == pStatement->m_eAtlasStatement ) && bProceduresOnly )
			{
				pStatement->ToXML( strXML );
			}
			else
			{
				pStatement->ToXML( strXML );
			}
		}

		++it;
	}
}

bool ProgamTree::Recursion( const string& strProcedureName )
{
	bool bRecursion = false;

	if ( m_setProcCalls.end( ) != m_setProcCalls.find( strProcedureName ) )
	{
		bRecursion = true;
	}
	else
	{
		m_setProcCalls.insert( strProcedureName );
		m_dequeProcCallStack.push_back( strProcedureName );
	}

	return bRecursion;
}

void ProgamTree::PopProcedureCall( const string& strProcedureName )
{
	set< string >::iterator it = m_setProcCalls.find( strProcedureName );

	if ( m_setProcCalls.end( ) != it )
	{
		m_setProcCalls.erase( it );

		m_dequeProcCallStack.pop_back( );
	}
}

string ProgamTree::GetCallStack( void ) const
{
	string strRecursiveCalls;

	const unsigned int uiSize = m_dequeProcCallStack.size( );

	for ( unsigned int ui = 0; ui < uiSize; ++ui )
	{
		if ( !strRecursiveCalls.empty( ) )
		{
			strRecursiveCalls += AtlasStatement::m_strFrontSlash;
		}

		strRecursiveCalls += m_dequeProcCallStack[ ui ];
	}

	return strRecursiveCalls;
}

void ProgamTree::ClearQueue( void )
{
	m_dequeProcCallStack.clear( );
	m_setProcCalls.clear( );
}