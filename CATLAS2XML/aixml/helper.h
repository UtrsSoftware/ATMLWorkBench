/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

#pragma once

#define XERCES_STATIC_LIBRARY

#include <string>
#include <vector>
#include <sstream>

#include <xercesc/util/XercesDefs.hpp>
#include <xercesc/util/Xerces_autoconf_config.hpp>
XERCES_CPP_NAMESPACE_BEGIN
	class DOMDocument;	
	class DOMElement;	
	class XercesDOMParser;
XERCES_CPP_NAMESPACE_END

using namespace std;

class AIXMLHelper
{
public:

	static void GetXercesString( const XMLCh* const pXercesWide, string& str, const bool bTrim = true );
	static string GetXercesString( const XMLCh* const pXercesWide, const bool bTrim = true ) { string str; GetXercesString( pXercesWide, str, bTrim ); return str; }
	
	static void GetWstring( const string& strSTL, wstring& wstr, const bool bTrim = false );
	static wstring GetWString( const string& strSTL, const bool bTrim = false ) { wstring wstr; GetWstring( strSTL, wstr, bTrim ); return wstr; }
	
	static bool TrimTo( string& str, const string& strTrimChars, const bool bLeft = true, const bool bRight = true );
	static bool Trim( string& str, const bool bLeft = true, const bool bRight = true, const string& strTrimChars = string( ) );
	static bool Trim( wstring& str, const bool bLeft = false, const bool bRight = false, const wstring& wstrTrimChars = wstring( ) );
	static bool Contains( const string& strTarget, const string& strContains );
	static bool StartsWith( const string& strTarget, const string& strStartsWith );
	static bool EndsWith( const string& strTarget, const string& strEndsWith );
	static bool IsUppercase( const string& str );
	static bool IsLowercase( const string& str );
	static string ToUpper( const string& str );
	static string ToLower( const string& str );
	static unsigned char NumberOfDecimalPlaces( const string& str );
	static char ScientificNotationPlaces( const string& str );
	static bool IsUnsignedWholeNumber( const string& str );
	static bool IsNumber( const string& str );
	static string::size_type NumberDimensionPos( const string& str );  // Returns position of number's dimension or string::npos if not found
	static long BinaryStringToNumber( const string& strNumber ) { return ::strtol( strNumber.c_str( ), 0, 2 ); }
	static long OctalStringToNumber( const string& strNumber ) { return ::strtol( strNumber.c_str( ), 0, 8 ); }
	static long HexStringToNumber( const string& strNumber ) { return ::strtol( strNumber.c_str( ), 0, 16 ); }
	static string StripPath( const string& strFilename );
	static string StripExtension( const string& strFilename );
	static string GetExtension( const string& strFilename );
	static string GetCurrenctTimeAsISO8601Format( void );
	
	struct cmpPointer
	{
	    template < typename T > bool operator( ) ( const T* a, const T* b ) const { return *a < *b; }
	};

	template < typename T > static string NumberToString( const T num )
	{
		stringstream ss;
		ss << num;
	
		return ss.str( );
	}
	template < typename T > static T StringToNumber( const string& str )
	{
		stringstream ss( str );
		T result;
	
		return ss >> result ? result : 0;
	}

	template< typename T > static T SearchAndReplace( const T& strSource, const T& strFind, const T& strReplaceWith )
	{
	    T::size_type stFlen = strFind.size( );
	    T::size_type stRlen = strReplaceWith.size( );
		T strTarget( strSource );
	
	    for ( T::size_type stPos = 0; T::npos != ( stPos = strTarget.find( strFind, stPos ) ); stPos += stRlen )
	    {
	        strTarget.replace( stPos, stFlen, strReplaceWith );
	    }
	
	    return strTarget;
	}

	template< typename T > static vector< T > SplitString( const T& str, const T& delimiters )
	{
	    vector< T > vect;
	    T::size_type start = 0;
	    T::size_type pos = str.find_first_of( delimiters, start );
	
	    while ( pos != T::npos )
		{
	        if ( pos != start ) // ignore empty tokens
			{
	            vect.push_back( str.substr( start, pos - start ) ) ;
			}
	
	        start = pos + 1;
	
	        pos = str.find_first_of( delimiters, start );
	    }
	
	    if ( start < str.length( ) ) // ignore trailing delimiter
		{
	        vect.push_back( str.substr( start, str.length( ) - start ) ); // add what's left of the string
		}
	
	    return vect;
	}
	
	static const xercesc::DOMElement* FindElementPath( const xercesc::DOMElement* pAIXMLvalue, const string& strPath, const bool bThrowIfNotFound = true );
	static const xercesc::DOMElement* GetFirstChildWhereAttributeExists( const xercesc::DOMElement* pAIXMLvalue, const string& strAttributeName );

	static const string m_strWhiteSpace;
	static const wstring m_wstrWhiteSpace;

	static const string m_strNumeric;
	static const wstring m_wstrNumeric;

	static const string m_strBackSlash;
	static const string m_strDot;
};