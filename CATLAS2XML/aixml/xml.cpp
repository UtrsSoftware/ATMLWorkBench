/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

#include "xml.h"
#include "helper.h"

#if ( _DEBUG ) && ( WIN32 )
	#define WINVER 0x0600
	#include <afx.h>
	#define new DEBUG_NEW
	#undef THIS_FILE
	static char BASED_CODE THIS_FILE[ ] = __FILE__;
#endif

int XML::m_iIndentCount = 0;
bool XML::m_bXMLIndent = true;
const string XML::m_strXMLElementBegin( "<" );
const string XML::m_strXMLElementEnd( ">\r\n" );
const string XML::m_strXMLElementCloseWithElement( "</" );
const string XML::m_strXMLElementCloseWithoutElement( "/>\r\n" );
const string XML::m_strXMLAssign( "=" );
const string XML::m_strSpace( " " );
const string XML::m_strDoubleQuote( "\"" );
map< const string*, XML::ElementName, AIXMLHelper::cmpPointer > XML::m_mapElemementNameToEnum;
map< const string*, XML::AttributeName, AIXMLHelper::cmpPointer > XML::m_mapAttributeNameToEnum;
map< const string*, XML::AttributeValue, AIXMLHelper::cmpPointer > XML::m_mapAttributeValueToEnum;

const std::string XML::m_arrayElementNames[ ] = 
{
	"UNKNOWN",						
	"atlas_source",
	"file",
	"organization",
	"form",
	"record_type",
	"record_length",
	"atlas",
	"signal_oriented_statements",
	"apply_statement",
	"applies",
	"signal_component",
	"noun",
	"noun_modifier",
	"function",
	"connector",
	"ieee_1641",
	"tsf",
	"bsc",
	"attribute",
	"qualifiers",
	"qualifier",
	"range",
	"number",
	"event",
	"from",
	"to",
	"thru",
	"start",
	"end",
	"text",
	"error_limit",
	"by",
	"continuous",
	"require_statement",
	"requires",
	"requires_by_virtual_label",
	"requires_by_system_name",
	"measure_statement",
	"measures",
	"apply",
	"noun_modifiers",
	"ranges",
	"numbers",
	"settings",
	"setting",
	"capability",
	"line_length",
	"page_size",
	"hard_copy",
	"ac",
	"dc",
	"require",
	"atlas_sources",
	"definition",
	"require_types",
	"require_type",
	"control",
	"modifiers", 
	"modifier",
	"limit",
	"maximums",
	"maximum",
	"channel_a",
	"channel_b",
	"measure",
	"measured_characteristics",
	"measured_characteristic",
	"modifier_functions",
	"modifier_function",
	"connection",
	"cnx",
	"ref",
	"descriptors",
	"descriptor",
	"pins",
	"pin",
	"image",
	"horizontal_timing",
	"vertical_timing",
	"non_interlace",
	"interlace",
	"sync",
	"on_video",
	"type",
	"serration",
	"sync_polarity",
	"horizontal",
	"vertical",
	"composite",
	"video",
	"draw",
	"ttl",
	"signals",
	"signal",
	"statements",
	"statement",
	"signal_name",
	"source_files",
	"uut",
	"procedure_call_hierarchy",
	"perform",
	"parameters",
	"parameter",
	"procedures",
	"procedure",
	"results",
	"result",
	"verify_statement",
	"verifies",
	"verify",
	"evaluations",
	"evaluation",
	"setup_statement",
	"setups",
	"setup",
	"read_statement",
	"reads",
	"read",
	"read_datetimes",
	"read_datetime",
	"monitor_statement",
	"monitors",
	"monitor",
	"initiate_statement",
	"initiates",
	"initiate",
	"remove_statement",
	"removes",
	"remove",
	"complex_signal",
	"fetch_statement",
	"fetches",
	"fetch",
	"gated",
	"connect_statement",
	"connects",
	"connect",
	"disconnect_statement",
	"disconnects",
	"disconnect",
	"arm_statement",
	"arms",
	"arm",
	"change_statement",
	"changes",
	"change",
	"reset_statement",
	"resets",
	"reset",
	"declares",
	"declare",
	"preamble",
	"requires_by_signal",
	"requires_by_class",
	"instrument_classes",
	"instrument_class",
	"resources",
	"resource",
	"datetime",
	"condition",
	"lower",
	"upper",
	"boolean",
	"upper_limit",
	"lower_limit",
	"index",
	"left",
	"right",
	"arithmetic",
	"compare",
	"arithmetic_function",
	"argument",
	"bitwise",
	"iterator",
	"initialize",
	"list",
	"variable",
	"constant",
	"builtin_declares",
	"identifies",
	"identify",
	"calculates",
	"calculate",
	"closes",
	"close",
	"compares",
	"delays",
	"delay",
	"disables",
	"disable",
	"do_exchanges",
	"do_exchange",
	"enables",
	"enable",
	"executes",
	"execute",
	"fills",
	"fill",
	"finishes",
	"finish",
	"opens",
	"open",
	"outputs",
	"output",
	"prepares",
	"prepare",
	"wait_fors",
	"wait_for",
	"close_statement",
	"open_statement",
	"assignment",
	"inputs",
	"input",
	"extends",
	"extend",
	"assign",
	"nominal",
	"concurrent_operation",
	"specifies",
	"specify",
	"target",
	"comments",
	"comment",
	"line",
	"leave_atlases",
	"leave_atlas",
	"resume_atlases",
	"resume_atlas",
	"ipl_blocks",
	"ipl_block",
	"ipls",
	"ipl",
	"assignments_by_statement",
	"assignments_by_value",
	"test_numbers",
	"test",
	"variables",
	"statistics",
	"nouns",
	"aixml"
};
const unsigned int XML::m_uiElementNameCount = ( sizeof( XML::m_arrayElementNames ) / sizeof( string ) );

const std::string XML::m_arrayAttributeNames[ ] = 
{
	"UNKNOWN",
	"statement",
	"file",
	"statement_number", 
	"line_number",
	"id",
	"file_type",
	"procedure",
	"unit",
	"acceleration",
	"acceleration_unit",
	"type",
	"version",
	"encoding",
	"program_name",
	"count",
	"value",
	"variable",
	"description",
	"suffix",
	"phase",
	"maximum",
	"minimum",
	"event_name",
	"class_count",
	"virtual_label",
	"system_name",
	"class",
	"class_description",
	"noun",
	"name",
	"dimension",
	"red",
	"green",
	"blue",
	"red_green",
	"red_blue",
	"green_blue",
	"red_green_blue",
	"american",
	"european",
	"on",
	"off",
	"positive",
	"negative",
	"nouns",
	"recursive",
	"call_stack",
	"non_atlas",
	"list_length",
	"secondary_type",
	"data_length",
	"entry_point",
	"refid",
	"all",
	"scope",
	"digital_format",
	"eval_type",
	"variable_name",
	"unary_operator",
	"operator",
	"function",
	"main_procedure",
	"unhandled_statement_type",
	"digital",
	"index",
	"start_index",
	"thru_index",
	"list",
	"manual_intervention",
	"new",
	"access",
	"complex_signal",
	"specify_type",
	"complex_function",
	"proc_refid",
	"leave_procedure",
	"resource",
	"require",
	"comment_refid",
	"lines",
	"branch_point",
	"starting_line",
	"ipl_refid",
	"statement_type",
	"assignment_by_expression",
	"else_refid",
	"test_number",
	"number",
	"begin_test",
	"unused",
	"unused_count",
	"create_datetime",
	"signal_oriented",
	"proc_hier",
	"unused_proc",
	"ieee1641",
	"ieee260.1"
};
const unsigned int XML::m_uiAttributeNameCount = ( sizeof( XML::m_arrayAttributeNames ) / sizeof( string ) );

const std::string XML::m_arrayAttributeValues[ ] = 
{
	"UNKNOWN",							
	"true",
	"false",
	"cass",
	"constant",
	"variable",
	"char",
	"program",
	"module",
	"segment",
	"boolean",
	"connector",
	"decimal",
	"integer",
	"non_module",
	"bit",
	"bits",
	"digital",
	"nominal",
	"upper_limit",
	"lower_limit",
	"greater_than",
	"less_than",
	"equal",
	"not_equal",
	"less_than_equal",
	"greater_than_equal",
	"global",
	"external",
	"local",
	"unsigned_positive_binary_number",
	"ones_complement_binary_number",
	"twos_complement_binary_number",
	"sign_plus_magnitude_binary_number",
	"binary_coded_decimal_number",
	"sign_plus_magnitude_binary_coded_decimal_number",
	"file_local",
	"segment_local",
	"proc_local",
	"proc_param",
	"proc_result",
	"binary",
	"hexadecimal",
	"octal",
	"limits",
	"not",
	"and",
	"or",
	"xor",
	"+",
	"-",
	"*",
	"/",
	"**",
	">",
	"<",
	"=",
	"!=",
	">=",
	"<=",
	"compare",
	"abs",
	"alog",
	"atan",
	"cos",
	"exp",
	"int",
	"ln",
	"log",
	"sin",
	"sqrt",
	"tan",
	"shift_left",
	"shift_right",
	"arith_shift_left",
	"arith_shift_right",
	"rotate_left",
	"rotate_right",
	"sequence",
	"list",
	"builtin",
	"assign",
	"bitwise",
	"arithmetic_function",
	"arithmetic",
	"enumeration",
	"hybrid_cass",
	"rtcass",
	"ecass",
	"program_lookup",
	"module_lookup",
	"yes",
	"no"
};
const unsigned int XML::m_uiAttributeValueCount = ( sizeof( XML::m_arrayAttributeValues ) / sizeof( string ) );

// *** KEEP THIS LAST FOR ALL STATIC INITIALIZERS ****
const bool XML::m_bInitStatics = InitStatics( );

bool XML::InitStatics( void )
{
	for ( unsigned int ui = 0; ui < m_uiElementNameCount; ++ui )
	{
		m_mapElemementNameToEnum.insert( make_pair( &( m_arrayElementNames[ ui ] ), ( ElementName ) ui ) );
	}

	for ( unsigned int ui = 0; ui < m_uiAttributeNameCount; ++ui )
	{
		m_mapAttributeNameToEnum.insert( make_pair( &( m_arrayAttributeNames[ ui ] ), ( AttributeName ) ui ) );
	}

	for ( unsigned int ui = 0; ui < m_uiAttributeValueCount; ++ui )
	{
		m_mapAttributeValueToEnum.insert( make_pair( &( m_arrayAttributeValues[ ui ] ), ( AttributeValue ) ui ) );
	}

	return true;
}

string XML::MakeXmlAttributeNameValue( const AttributeName eName, const string& strValue )
{
	const unsigned int uiSize = m_arrayAttributeNames[ eName ].size( ) + strValue.size( ) + 4; // plus four... space, two delims and assignment
	string strRet;

	strRet.reserve( uiSize ); 
		
	strRet += m_strSpace;
	strRet += m_arrayAttributeNames[ eName ];
	strRet += m_strXMLAssign;
	strRet += m_strDoubleQuote;
	strRet += TranslateToXmlEncodings( strValue );
	strRet += m_strDoubleQuote;

	return strRet;
}


string XML::MakeXmlAttributeNameValue( const AttributeName eName, const AttributeValue eValue )
{
	return MakeXmlAttributeNameValue( eName, m_arrayAttributeValues[ eValue ] ); 
}

string XML::MakeXmlAttributeNameValue( const AttributeName eName, const int iValue ) 
{ 
	return MakeXmlAttributeNameValue( eName, AIXMLHelper::NumberToString< int >( iValue ) ); 
}

string XML::MakeXmlAttributeNameValue( const AttributeName eName, const unsigned int uiValue )
{ 
	return MakeXmlAttributeNameValue( eName, AIXMLHelper::NumberToString< unsigned int >( uiValue ) ); 
}

string XML::MakeXmlAttributeNameValue( const AttributeName eName, const double dValue )
{ 
	return MakeXmlAttributeNameValue( eName, AIXMLHelper::NumberToString< double >( dValue ) );
}

string XML::MakeXmlElementNoChildrenWithTextNode( const ElementName eName, const string& strTextNodeValue, const string& strAttib1, const string& strAttib2, const string& strAttib3, const string& strAttib4, const string& strAttib5, const string& strAttib6, const string& strAttib7, const string& strAttib8 )
{
	const unsigned int uiElementSize = m_arrayElementNames[ eName ].size( );
	string strRet;

	if ( uiElementSize > 0 )
	{
		unsigned int uiReserve = ( uiElementSize + 5 );
	
		if ( !strAttib1.empty( ) )
		{
			uiReserve += strAttib1.size( );
		}
	
		if ( !strAttib2.empty( ) )
		{
			uiReserve += strAttib2.size( );
		}
	
		if ( !strAttib3.empty( ) )
		{
			uiReserve += strAttib3.size( );
		}
	
		if ( !strAttib4.empty( ) )
		{
			uiReserve += strAttib4.size( );
		}
	
		if ( !strAttib5.empty( ) )
		{
			uiReserve += strAttib5.size( );
		}
	
		if ( !strAttib6.empty( ) )
		{
			uiReserve += strAttib6.size( );
		}

		if ( !strAttib7.empty( ) )
		{
			uiReserve += strAttib7.size( );
		}

		if ( !strAttib8.empty( ) )
		{
			uiReserve += strAttib8.size( );
		}

		if ( m_bXMLIndent )
		{
			uiReserve += m_iIndentCount;
		}

		strRet.reserve( uiReserve );

		strRet += InsertIndent( true );
		strRet += m_strXMLElementBegin;
		strRet += m_arrayElementNames[ eName ];

		strRet += strAttib1;
		strRet += strAttib2;
		strRet += strAttib3;
		strRet += strAttib4;
		strRet += strAttib5;
		strRet += strAttib6;
		strRet += strAttib7;
		strRet += strAttib8;
		strRet += ">";

		strRet += strTextNodeValue;

		strRet += m_strXMLElementCloseWithElement;
		strRet += m_arrayElementNames[ eName ];
		strRet += m_strXMLElementEnd;

		--m_iIndentCount;
	}

	return strRet;
}

string XML::MakeXmlElementNoChildren( const ElementName eName, const string& strAttib1, const string& strAttib2, const string& strAttib3, const string& strAttib4, const string& strAttib5, const string& strAttib6, const string& strAttib7, const string& strAttib8 )
{
	const unsigned int uiElementSize = m_arrayElementNames[ eName ].size( );
	string strRet;

	if ( uiElementSize > 0 )
	{
		unsigned int uiReserve = ( uiElementSize + 5 );
	
		if ( !strAttib1.empty( ) )
		{
			uiReserve += strAttib1.size( );
		}
	
		if ( !strAttib2.empty( ) )
		{
			uiReserve += strAttib2.size( );
		}
	
		if ( !strAttib3.empty( ) )
		{
			uiReserve += strAttib3.size( );
		}
	
		if ( !strAttib4.empty( ) )
		{
			uiReserve += strAttib4.size( );
		}
	
		if ( !strAttib5.empty( ) )
		{
			uiReserve += strAttib5.size( );
		}
	
		if ( !strAttib6.empty( ) )
		{
			uiReserve += strAttib6.size( );
		}

		if ( !strAttib7.empty( ) )
		{
			uiReserve += strAttib7.size( );
		}

		if ( !strAttib8.empty( ) )
		{
			uiReserve += strAttib8.size( );
		}

		if ( m_bXMLIndent )
		{
			uiReserve += m_iIndentCount;
		}

		strRet.reserve( uiReserve );

		strRet += InsertIndent( true );
		strRet += m_strXMLElementBegin;
		strRet += m_arrayElementNames[ eName ];

		strRet += strAttib1;
		strRet += strAttib2;
		strRet += strAttib3;
		strRet += strAttib4;
		strRet += strAttib5;
		strRet += strAttib6;
		strRet += strAttib7;
		strRet += strAttib8;

		strRet += m_strXMLElementCloseWithoutElement;

		--m_iIndentCount;
	}

	return strRet;
}

string XML::MakeOpenXmlElementWithChildren( const ElementName eName, const string& strAttib1, const string& strAttib2, const string& strAttib3, const string& strAttib4, const string& strAttib5, const string& strAttib6, const string& strAttib7, const string& strAttib8 )
{
	const unsigned int uiElementSize = m_arrayElementNames[ eName ].size( );
	string strRet;

	if ( uiElementSize > 0 )
	{
		unsigned int uiReserve = ( uiElementSize + 4 );
	
		if ( !strAttib1.empty( ) )
		{
			uiReserve += strAttib1.size( );
		}
	
		if ( !strAttib2.empty( ) )
		{
			uiReserve += strAttib2.size( );
		}
	
		if ( !strAttib3.empty( ) )
		{
			uiReserve += strAttib3.size( );
		}
	
		if ( !strAttib4.empty( ) )
		{
			uiReserve += strAttib4.size( );
		}
	
		if ( !strAttib5.empty( ) )
		{
			uiReserve += strAttib5.size( );
		}
	
		if ( !strAttib6.empty( ) )
		{
			uiReserve += strAttib6.size( );
		}

		if ( !strAttib7.empty( ) )
		{
			uiReserve += strAttib7.size( );
		}

		if ( !strAttib8.empty( ) )
		{
			uiReserve += strAttib8.size( );
		}

		if ( m_bXMLIndent )
		{
			uiReserve += m_iIndentCount;
		}

		strRet.reserve( uiReserve );
	
		strRet += InsertIndent( true );
		strRet += m_strXMLElementBegin;
		strRet += m_arrayElementNames[ eName ];

		strRet += strAttib1;
		strRet += strAttib2;
		strRet += strAttib3;
		strRet += strAttib4;
		strRet += strAttib5;
		strRet += strAttib6;
		strRet += strAttib7;
		strRet += strAttib8;
	
		strRet += m_strXMLElementEnd;
	}

	return strRet;
}

string XML::MakeCloseXmlElementWithChildren( const ElementName eName )
{
	string strRet( InsertIndent( false ) );

	strRet += m_strXMLElementCloseWithElement;
	strRet += m_arrayElementNames[ eName ];
	strRet += m_strXMLElementEnd;

	return strRet;
}

string XML::TranslateToXmlEncodings( const string& strArg )
{
	unsigned int uiTranslations = 0;
	const unsigned int uiSize = strArg.size( );
	string strRet;

	if ( uiSize > 0 )
	{
		strRet.reserve( uiSize );
		unsigned char uchTest = 0;

		for ( unsigned int ui = 0; ui < uiSize; ++ui )
		{
			uchTest = ( unsigned char ) strArg[ ui ];

			if ( uchTest > ( unsigned char ) 127 )
			{
				strRet += '&';
				strRet += '#';
				strRet += AIXMLHelper::NumberToString< unsigned int >( uchTest );
				strRet += ';';
			}
			else
			{
				static const string strAmp( "&amp;" );
				static const string strLt( "&lt;" );
				static const string strGt( "&gt;" );
				static const string strQuot( "&quot;" );

				switch ( uchTest )
				{
					case '&':
						strRet += strAmp;
						break;
					case '<':
						strRet += strLt;
						break;
					case '>':
						strRet += strGt;
						break;
					case '\"':
						strRet += strQuot;
						break;
					default:
						strRet += uchTest;
						break;
				}
			}
		}
	}

	return strRet;
}

string XML::GetXmlVersionAndEncoding( const string& strVersion, const string& strEncoding )
{
	string strXML;

	strXML += m_strXMLElementBegin;
	strXML += "?xml";
	strXML += MakeXmlAttributeNameValue( anVersion, strVersion );
	strXML += MakeXmlAttributeNameValue( anEncoding, strEncoding );
	strXML += "?";
	strXML += m_strXMLElementEnd;

	return strXML;
}

const string& XML::GetElementName( const ElementName eName )
{
	return m_arrayElementNames[ eName ];
}

const string& XML::GetAttributeName( const AttributeName eName )
{
	return m_arrayAttributeNames[ eName ];
}

const string& XML::GetAttributeValue( const AttributeValue eValue )
{
	return m_arrayAttributeValues[ eValue ];
}

XML::ElementName XML::GetElementNameEnum( const string& strElementName )
{
	XML::ElementName eName = enUnknown;

	const map< const string*, ElementName, AIXMLHelper::cmpPointer >::const_iterator it = m_mapElemementNameToEnum.find( &AIXMLHelper::ToLower( strElementName ) );
	const map< const string*, ElementName, AIXMLHelper::cmpPointer >::const_iterator itEnd = m_mapElemementNameToEnum.end( );

	if ( itEnd != it )
	{
		eName = it->second;
	}
	
	return eName;
}

XML::AttributeName XML::GetAttributeNameEnum( const string& strAttributeName )
{
	XML::AttributeName eName = anUnknown;

	const map< const string*, AttributeName, AIXMLHelper::cmpPointer >::const_iterator it = m_mapAttributeNameToEnum.find( &AIXMLHelper::ToLower( strAttributeName ) );
	const map< const string*, AttributeName, AIXMLHelper::cmpPointer >::const_iterator itEnd = m_mapAttributeNameToEnum.end( );

	if ( itEnd != it )
	{
		eName = it->second;
	}

	return eName;
}

XML::AttributeValue XML::GetAttributeValueEnum( const string& strAttributeValue )
{
	XML::AttributeValue eName = avUnknown;

	const map< const string*, AttributeValue, AIXMLHelper::cmpPointer >::const_iterator it = m_mapAttributeValueToEnum.find( &AIXMLHelper::ToLower( strAttributeValue ) );
	const map< const string*, AttributeValue, AIXMLHelper::cmpPointer >::const_iterator itEnd = m_mapAttributeValueToEnum.end( );

	if ( itEnd != it )
	{
		eName = it->second;
	}

	return eName;
}

string XML::InsertIndent( const bool bOpen )
{
	string strIndent;

	if ( m_bXMLIndent )
	{
		if ( !bOpen )
		{
			--m_iIndentCount;
		}

		if ( m_iIndentCount < 0 )
		{
			m_iIndentCount = 0;
		}

		if ( m_iIndentCount > 0 )
		{
			strIndent = string( m_iIndentCount, '\t' );
		}

		if ( bOpen )
		{
			++m_iIndentCount;
		}
	}

	return strIndent;
}

void XML::IncrementXMLIndent( unsigned int uiCount )
{
	m_iIndentCount += ( int ) uiCount;
}

void XML::DecrementXMLIndent( unsigned int uiCount )
{
	m_iIndentCount -= ( int ) uiCount;

	if ( m_iIndentCount < 0 )
	{
		m_iIndentCount = 0;
	}
}
