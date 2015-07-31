/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

#include <time.h>
#include "helper.h"
#include "exception.h"

// Xercesc XML Parser
#include <xercesc/dom/dom.hpp>

#if ( _DEBUG ) && ( WIN32 )
	#define WINVER 0x0600
	#include <afx.h>
	#define new DEBUG_NEW
	#undef THIS_FILE
	static char BASED_CODE THIS_FILE[ ] = __FILE__;
#endif

using namespace XERCES_CPP_NAMESPACE;

const string AIXMLHelper::m_strWhiteSpace( "\t\n\v\f\r " );
const wstring AIXMLHelper::m_wstrWhiteSpace( L"\t\n\v\f\r " );
const string AIXMLHelper::m_strNumeric( "0123456789" );
const wstring AIXMLHelper::m_wstrNumeric( L"0123456789" );
const string AIXMLHelper::m_strBackSlash( "\\" );
const string AIXMLHelper::m_strDot( "." );

void AIXMLHelper::GetXercesString( const XMLCh* const pXercesWide, string& str, const bool bTrim )
{
	char* pchText = 0;

	str.clear( );

	try
	{
		pchText = XMLString::transcode( pXercesWide );

		if ( 0 != pchText )
		{
			str = pchText;

			if ( bTrim )
			{   
				Trim( str, true, true );
			}
		}
	}
	catch( ... )
	{
	}

	if ( 0 != pchText )
	{
		XMLString::release( &pchText );
	}
}

bool AIXMLHelper::TrimTo( string& str, const string& strTrimChars, const bool bLeft, const bool bRight )
{
	const string::size_type stLength = str.length( );
	bool bRet = false;

	if ( stLength > 0 )
	{
		if ( bLeft )
		{
			const string::size_type stPos = str.find_first_of( strTrimChars );

			if ( string::npos != stPos )
			{
				str.erase( 0, stPos + 1 );
			}
		}
	
		if ( bRight )
		{
			const string::size_type stPos = str.find_last_of( strTrimChars );

			if ( string::npos != stPos )
			{
				str.erase( stPos );
			}
		}

		bRet = ( stLength != str.length( ) );

		if ( bRet )
		{
			// Trim any additional characters

			Trim( str, bLeft, bRight, strTrimChars );
		}
	}

	return bRet;
}


bool AIXMLHelper::Trim( string& str, const bool bLeft, const bool bRight, const string& strTrimChars )
{
	const string& strTrim = ( 0 == strTrimChars.length( ) ? m_strWhiteSpace : strTrimChars );
	const string::size_type stLength = str.length( );
	bool bRet = false;

	if ( stLength > 0 )
	{
		if ( bLeft )
		{
			str.erase( 0, str.find_first_not_of( strTrim ) );
		}
	
		if ( bRight )
		{
			str.erase( str.find_last_not_of( strTrim ) + 1 );
		}

		bRet = ( stLength != str.length( ) );
	}

	return bRet;
}

bool AIXMLHelper::Trim( wstring& wstr, const bool bLeft, const bool bRight, const wstring& wstrTrimChars )
{
	const wstring& strTrim = ( 0 == wstrTrimChars.length( ) ? m_wstrWhiteSpace : wstrTrimChars );
	const string::size_type stLength = wstr.length( );
	bool bRet = false;

	if ( stLength > 0 )
	{
		if ( bLeft )
		{
			wstr.erase( 0, wstr.find_first_not_of( strTrim ) );
		}
	
		if ( bRight )
		{
			wstr.erase( wstr.find_last_not_of( strTrim ) + 1 );
		}

		bRet = ( stLength != wstr.length( ) );
	}

	return bRet;
}

bool AIXMLHelper::StartsWith( const string& strTarget, const string& strStartsWith )
{
	bool bStartsWith = false;

	if ( !strTarget.compare( 0, strStartsWith.size( ), strStartsWith ) )
	{
		bStartsWith = true;
	}

	return bStartsWith;
}

bool AIXMLHelper::EndsWith( const string& strTarget, const string& strEndsWith )
{
	bool bEndsWith = false;

	if ( strEndsWith.size( ) <= strTarget.size( ) )
	{
		bEndsWith = equal( strEndsWith.rbegin( ), strEndsWith.rend( ), strTarget.rbegin( ) );
	}

	return bEndsWith;
}

bool AIXMLHelper::Contains( const string& strTarget, const string& strContains )
{
	return ( string::npos != strTarget.find( strContains ) );
}

void AIXMLHelper::GetWstring( const string& strSTL, wstring& wstr, const bool bTrim )
{
	wchar_t* pchText = 0;

	wstr.clear( );

	try
	{
		pchText = XMLString::transcode( strSTL.c_str( ) );

		if ( 0 != pchText )
		{
			wstr = pchText;

			if ( bTrim )
			{   
				Trim( wstr, true, true );
			}
		}
	}
	catch( ... )
	{
	}

	if ( 0 != pchText )
	{
		XMLString::release( &pchText );
	}
}

unsigned char AIXMLHelper::NumberOfDecimalPlaces( const string& str )
{
	unsigned char uchDecimalPlaces = 0;
	const string::size_type stLength = str.length( );

	if ( stLength > 0 )
	{
		const string strDecimal( "." );

		const string::size_type stPos = str.find_last_of( strDecimal );

		if ( string::npos != stPos )
		{
			uchDecimalPlaces = ( unsigned char ) ( stLength - stPos );

			--uchDecimalPlaces;
		}
	}

	return uchDecimalPlaces;
}

bool AIXMLHelper::IsUnsignedWholeNumber( const string& str )
{
	bool bRet = false;

	if ( !str.empty( ) )
	{
		string::size_type pos = 0;

		/* Handling sign at the beginning of the string

		const char chFirst = str[ 0 ];

		if ( ( '-' == chFirst ) || ( '+' == chFirst ) )
		{
			pos = 1;
		}

		*/

		bRet = ( string::npos == str.find_first_not_of( m_strNumeric, pos ) );
	}

	return bRet;
}

bool AIXMLHelper::IsNumber( const string& str )
{
	std::istringstream num( str );
	double dbl = 0.0;
	bool bRet = false;

	num >> dbl;

	if ( !num.fail( ) )
	{
		// This second test is important! This makes sure that the entire string was converted to a number
		if ( num.eof( ) ) 
		{
			bRet = true;
		}
	}

	return bRet;
}

string::size_type AIXMLHelper::NumberDimensionPos( const string& str )
{
	string::size_type stLocation = string::npos;
	const string::size_type stLength = str.size( );

	if ( stLength > 0 )
	{
		const char chFirst = str[ 0 ];
		const char chLast = str[ stLength - 1 ];

		if ( ( chFirst >= '0' ) && ( chFirst <= '9' ) || ( '.' == chFirst ) || ( '-' == chFirst ) || ( '+' == chFirst ) )
		{
			// Starts as a number

			if ( ( chLast >= '0' ) && ( chLast <= '9' ) || ( '.' == chLast ) )
			{
				; // Ends as a number, so the entire string is probably a number, we're done.
			}
			else
			{
				for ( int i = ( int ) ( stLength - 1 ); i >= 0; --i )
				{
					const char chCurr = str[ i ];

					if ( ( chCurr >= '0' ) && ( chCurr <= '9' ) || ( '.' == chCurr ) )
					{
						stLocation = ( string::size_type ) i;
						++stLocation;
						break;
					}
				}
			}
		}
	}

	return stLocation;
}

char AIXMLHelper::ScientificNotationPlaces( const string& str )
{
	char chPlaces = 0;

	if ( str.length( ) > 0 ) 
	{
		const string strLow( "e" );
		const string strUp( "E" );

		string::size_type stPos = str.find( strLow );

		if ( string::npos == stPos )
		{
			stPos = str.find( strUp );
		}

		if ( string::npos != stPos )
		{
			chPlaces = ( char ) AIXMLHelper::StringToNumber< int >( str.substr( stPos + 1 ) );
		}
	}

	return chPlaces;
}

const DOMElement* AIXMLHelper::FindElementPath( const DOMElement* pAIXMLvalue, const string& strPath, const bool bThrowIfNotFound )
{
	const DOMElement* pTarget = 0;

	if ( !strPath.empty( ) && ( 0 != pAIXMLvalue ) )
	{
		const string strBackSlash( "\\" );
		const vector< string > vectTagNames = AIXMLHelper::SplitString< string >( strPath, strBackSlash );
		const unsigned int uiElements = vectTagNames.size( );

		if ( uiElements > 0 )
		{
			string strAIXMLtagName;
			unsigned int uiStartPos = 0;
	
			GetXercesString( pAIXMLvalue->getTagName( ), strAIXMLtagName );

			if ( vectTagNames[ 0 ] == strAIXMLtagName )
			{
				uiStartPos++;
			}

			pTarget = pAIXMLvalue;

			for ( unsigned int ui = uiStartPos; ui < uiElements; ui++ )
			{
				const DOMNodeList* pAIXML_NodeList = pTarget->getChildNodes( );
	
				if ( 0 == pAIXML_NodeList )
				{
					throw Exception( Exception::eFailedToGetLookupChildNodes, __FILE__, __FUNCTION__, __LINE__ );
				}
	
				const XMLSize_t iMaxNodes = pAIXML_NodeList->getLength( );
	
				if ( 0 == iMaxNodes )
				{
					throw Exception( Exception::eInvalidNumberOfLookupNodes, __FILE__, __FUNCTION__, __LINE__ );
				}
	
				pTarget = 0;
	
				for ( XMLSize_t iCurrentNode = 0; iCurrentNode < iMaxNodes; iCurrentNode++ )
				{
					const DOMElement* pAIXMLElement = ( DOMElement* ) pAIXML_NodeList->item( iCurrentNode );
			
					if ( 0 == pAIXMLElement )
					{
						throw Exception( Exception::eFailedToGetXercesNodeListItem, __FILE__, __FUNCTION__, __LINE__ );
					}
			
					if ( DOMNode::COMMENT_NODE == pAIXMLElement->getNodeType( ) )
					{
						continue;
					}
			
					GetXercesString( pAIXMLElement->getTagName( ), strAIXMLtagName );
			
					if ( !strAIXMLtagName.empty( ) )
					{
						if ( vectTagNames[ ui ] == strAIXMLtagName )
						{
							pTarget = pAIXMLElement;
							break;
						}
					}
				}
	
				if ( 0 == pTarget )
				{
					if ( bThrowIfNotFound )
					{
						string strError( strPath );
						strError += ", element: ";
						strError += vectTagNames[ ui ];
	
						throw Exception( Exception::eCouldNotFindElementInPath, __FILE__, __FUNCTION__, __LINE__, strError );
					}

					break;
				}
			}
		}
	}

	if ( bThrowIfNotFound )
	{
		if ( 0 == pTarget )
		{
			throw Exception( Exception::eCouldNotFindElementInPath, __FILE__, __FUNCTION__, __LINE__, strPath );
		}
	}

	return pTarget;
}

const DOMElement* AIXMLHelper::GetFirstChildWhereAttributeExists( const DOMElement* pAIXMLvalue, const string& strAttributeName )
{
	const DOMNodeList* pAIXML_NodeList = pAIXMLvalue->getChildNodes( );
	const DOMElement* pFirstChild = 0;

	if ( 0 != pAIXML_NodeList )
	{
		const XMLSize_t iMaxNodes = pAIXML_NodeList->getLength( );

		if ( iMaxNodes > 0 )
		{
			const wstring wstrAttributeName( AIXMLHelper::GetWString( strAttributeName ) );

			for ( XMLSize_t iCurrentNode = 0; iCurrentNode < iMaxNodes; iCurrentNode++ )
			{
				pAIXMLvalue = ( DOMElement* ) pAIXML_NodeList->item( iCurrentNode );
		
				if ( 0 == pAIXMLvalue )
				{
					continue;
				}
		
				if ( DOMNode::ELEMENT_NODE == pAIXMLvalue->getNodeType( ) )
				{
					const DOMAttr* pAttr = pAIXMLvalue->getAttributeNode( wstrAttributeName.c_str( ) );
	
					if ( 0 != pAttr )
					{
						pFirstChild = pAIXMLvalue;
						break;
					}
				}
			}
		}
	}

	return pFirstChild;
}

string AIXMLHelper::ToUpper( const string& str )
{
	string strRet( str );

	const unsigned int uiLength = strRet.length( );

	if ( uiLength > 0 )
	{
		const unsigned char uchDiff = ( 'A' - 'a' );

	    for ( unsigned int uiPos = 0; uiPos < uiLength; ++uiPos )
	    {
			char chChar = strRet[ uiPos ];
	
	        if ( chChar >= 'a' && chChar <= 'z' )
			{ 
				chChar += uchDiff;

				strRet[ uiPos ] = chChar;
			}
	    }
	}

    return strRet;
}

string AIXMLHelper::ToLower( const string& str )
{
	string strRet( str );

	const unsigned int uiLength = strRet.length( );

	if ( uiLength > 0 )
	{
		const unsigned char uchDiff = ( 'A' - 'a' );

	    for ( unsigned int uiPos = 0; uiPos < uiLength; ++uiPos )
	    {
			char chChar = strRet[ uiPos ];
	
	        if ( chChar >= 'A' && chChar <= 'Z' )
			{ 
				chChar -= uchDiff;

				strRet[ uiPos ] = chChar;
			}
	    }
	}

    return strRet;
}

bool AIXMLHelper::IsUppercase( const string& str )
{
	bool bIsUppercase = false;
	const unsigned int uiSize = str.size( );

	if ( uiSize > 0 )
	{
		bIsUppercase = true;

		for ( unsigned int ui = 0; ui < uiSize; ++ui )
		{
			if ( ::islower( str[ ui ] ) )
			{
				bIsUppercase = false;
				break;
			}
		}
	}

	return bIsUppercase;
}

bool AIXMLHelper::IsLowercase( const string& str )
{
	bool bIsLowercase = false;
	const unsigned int uiSize = str.size( );

	if ( uiSize > 0 )
	{
		bIsLowercase = true;

		for ( unsigned int ui = 0; ui < uiSize; ++ui )
		{
			if ( ::isupper( str[ ui ] ) )
			{
				bIsLowercase = false;
				break;
			}
		}
	}

	return bIsLowercase;
}

string AIXMLHelper::StripPath( const string& strFilename )
{
	string::size_type stPos = strFilename.find_last_of( m_strBackSlash );
	string strRet( strFilename );

	if ( string::npos != stPos )
	{
		++stPos;

		if ( stPos < strFilename.size( ) )
		{
			strRet = strFilename.substr( stPos );
		}
	}

	return strRet;
}

string AIXMLHelper::StripExtension( const string& strFilename )
{
	string::size_type stPos = strFilename.find_last_of( m_strDot );
	string strRet( strFilename );

	if ( string::npos != stPos )
	{
		strRet = strFilename.substr( 0, stPos );
	}

	return strRet;
}

string AIXMLHelper::GetExtension( const string& strFilename )
{
	string::size_type stPos = strFilename.find_last_of( m_strDot );
	string strRet( strFilename );

	if ( string::npos != stPos )
	{
		++stPos;

		if ( stPos < strFilename.size( ) )
		{
			strRet = strFilename.substr( stPos );
		}
	}

	return strRet;
}

string AIXMLHelper::GetCurrenctTimeAsISO8601Format( void )
{
	// ISO 8601 format: YYYY-MM-DDThh:mm:ss.sTZD
	//
	// Where 
	//    YYYY = four-digit year
	//    -
    //    MM   = two-digit month (01=January, etc.)
	//    -
    //    DD   = two-digit day of month (01 through 31)
	//    T
    //    hh   = two digits of hour (00 through 23) (am/pm NOT allowed)
	//    :
    //    mm   = two digits of minute (00 through 59)
	//    :
    //    ss   = two digits of second (00 through 59)
	//    .
    //    s    = one or more digits representing a decimal fraction of a second
    //    TZD  = time zone designator (Z or +hh:mm or -hh:mm)

	time_t tmRawTime;
	string strTime;

	if ( time( &tmRawTime ) > -1 )
	{
		tm* ptm = 0;
		tm localTime;
	    tm gmtTime;
		char tmbuffer[ 80 ];
	
		ptm = localtime( &tmRawTime );
		memcpy( &localTime, ptm, sizeof( tm ) );
	
	    ptm = gmtime( &tmRawTime );
		memcpy( &gmtTime, ptm, sizeof( tm ) );

		if ( strftime( tmbuffer, sizeof( tmbuffer ), "%Y-%m-%dT%H:%M:%S.0", &localTime ) > 0 )
		{
			const unsigned int uiLocalTimeSeconds = ( localTime.tm_sec + ( localTime.tm_min * 60 ) + ( ( localTime.tm_hour * 60 ) * 60 ) );
			const unsigned int uiGMTTimeSeconds = ( gmtTime.tm_sec + ( gmtTime.tm_min * 60 ) + ( ( gmtTime.tm_hour * 60 ) * 60 ) );
			const int iDiff = ( int ) ( uiLocalTimeSeconds - uiGMTTimeSeconds );
			const unsigned int uiHourDiff = ( abs( iDiff ) / 3600 );
			const unsigned int uiMinDiff = ( iDiff % 3600 );

			strTime += tmbuffer;
			strTime += ( iDiff < 0 ? "-" : "+" );
			strTime += ( uiHourDiff < 10 ? "0" : "" );
			strTime += NumberToString< int >( uiHourDiff );
			strTime += ":";
			strTime += ( uiMinDiff < 10 ? "0" : "" );
			strTime += NumberToString< int >( uiMinDiff );
		}
	}

	return strTime;
}