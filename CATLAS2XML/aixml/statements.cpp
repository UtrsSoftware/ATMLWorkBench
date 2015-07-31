/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

#include <algorithm>
#include "statements.h"
#include "helper.h"
#include "aixml.h"
#include "DOMStatements.h"
#include "require.h"
#include "procedure.h"
#include "declare.h"
#include "conditional.h"
#include "perform.h"
#include "cnx.h"
#include "atlas_noun_modifier.h"
#include "complex_signal.h"
#include "goto.h"
#include "leave.h"
#include "fill.h"

// Xercesc XML Parser
#include <xercesc/dom/dom.hpp>

#if ( _DEBUG ) && ( WIN32 )
	#define WINVER 0x0600
	#include <afx.h>
	#define new DEBUG_NEW
	#undef THIS_FILE
	static char BASED_CODE THIS_FILE[ ] = __FILE__;
#endif

#ifdef CASS
	#include "cass/lookup.h"
#endif

using namespace XERCES_CPP_NAMESPACE;

const string AtlasStatement::m_strBackSlash( "\\" );
const string AtlasStatement::m_strFrontSlash( "/" );
const string AtlasStatement::m_strMinus( "-" );
const string AtlasStatement::m_strPlus( "+" );
const string AtlasStatement::m_strLeftParen( "(" );
const string AtlasStatement::m_strRightParen( ")" );
const string AtlasStatement::m_strDash( "-" );
const string AtlasStatement::m_strUnderscore( "_" );
const string AtlasStatement::m_strDot( ".");
const string AtlasStatement::m_strColon( ":");
const string AtlasStatement::m_strAssign( "=" );

const string AtlasStatement::m_strMAIN_PROC_NAME( "C/ATLAS_MAIN_PROCEDURAL_STRUCTURE" );
const string AtlasStatement::m_strRANGE( "RANGE" );
const string AtlasStatement::m_strFROM( "FROM" );
const string AtlasStatement::m_strMIN( "MIN" );
const string AtlasStatement::m_strMAX( "MAX" );
const string AtlasStatement::m_strCNX( "CNX" );
const string AtlasStatement::m_strSHORT( "SHORT" );
const string AtlasStatement::m_strUSING( "USING" );
const string AtlasStatement::m_strAS( "AS" );
const string AtlasStatement::m_strTHRU( "THRU" );
const string AtlasStatement::m_strChannelA( "CHANA" );
const string AtlasStatement::m_strChannelB( "CHANB" );
const string AtlasStatement::m_strAC( "AC" );
const string AtlasStatement::m_strDC( "DC" );
const string AtlasStatement::m_strTO( "TO" );
const string AtlasStatement::m_strEVENT( "EVENT" );
const string AtlasStatement::m_strERRLMT( "ERRLMT" );
const string AtlasStatement::m_strINTO( "INTO" );
const string AtlasStatement::m_strBY( "BY" );
const string AtlasStatement::m_strCONTINUOUS( "CONTINUOUS" );
const string AtlasStatement::m_strPOS( "POS" );
const string AtlasStatement::m_strNEG( "NEG" );
const string AtlasStatement::m_strFILE( "FILE" );
const string AtlasStatement::m_strNONE( "NONE" );
const string AtlasStatement::m_strREF( "REF" );
const string AtlasStatement::m_strFALSE( "FALSE" );
const string AtlasStatement::m_strTRUE( "TRUE" );
const string AtlasStatement::m_strSTORE( "STORE" );
const string AtlasStatement::m_strLIST( "LIST" );
const string AtlasStatement::m_strGLOBAL( "GLOBAL" );
const string AtlasStatement::m_strEXTERNAL( "EXTERNAL" );
const string AtlasStatement::m_strDATE( "DATE" );
const string AtlasStatement::m_strALL( "ALL" );
const string AtlasStatement::m_strCOMPLEX( "COMPLEX" );
const string AtlasStatement::m_strSIGNAL( "SIGNAL" );
const string AtlasStatement::m_strFUNCTION( "FUNCTION" );
const string AtlasStatement::m_strFORMAT( "FORMAT" );
const string AtlasStatement::m_strMANUAL( "MANUAL" );
const string AtlasStatement::m_strINTERVENTION( "INTERVENTION" );
const string AtlasStatement::m_strNEW( "NEW" );
const string AtlasStatement::m_strOLD( "OLD" );
const string AtlasStatement::m_strFILEACCESS( "FILE-ACCESS" );
const string AtlasStatement::m_strCONCURRENT( "CONCURRENT" );
const string AtlasStatement::m_strOPERATION( "OPERATION" );
const string AtlasStatement::m_strSTEP( "STEP" );

AtlasAttributes::AtlasAttibuteValue& AtlasAttributes::AtlasAttibuteValue::operator = ( const AtlasAttibuteValue& other )
{
	if ( this != &other )
	{
		m_strValue = other.m_strValue;
		m_uiType = other.m_uiType;
		m_uiId = other.m_uiId;
		m_uiLineNumber = other.m_uiLineNumber;
		m_strStatementNumber = other.m_strStatementNumber;
	}

	return *this;
}

XML::AttributeValue AtlasAttributes::AtlasAttibuteValue::GetNumericType( void ) const
{
	XML::AttributeValue avType = XML::avUnknown;

	if ( IsDouble( ) )
	{
		avType = XML::avDecimal;
	}
	else if ( IsInteger( ) )
	{
		avType = XML::avInteger;
	}

	return avType;
}

bool AtlasAttributes::AtlasAttibuteValue::IsNumericType( void ) const
{
	return ( XML::avUnknown != GetNumericType( ) );
}

XML::AttributeValue AtlasAttributes::AtlasAttibuteValue::GetDataType( void ) const
{
	XML::AttributeValue avType = XML::avUnknown;

	if ( IsString( ) )
	{
		avType = XML::avChar;
	}
	else if ( IsConstant( ) || IsVariable( ) )
	{
		if ( IsDouble( ) )
		{
			avType = XML::avDecimal;
		}
		else if ( IsInteger( ) )
		{
			avType = XML::avInteger;
		}
		else if ( IsConstant( ) )
		{
			avType = XML::avConstant;
		}
		else
		{
			avType = XML::avVariable;
		}
	}
	else if ( IsConnector( ) )
	{
		avType = XML::avConnector;
	}
	else if ( IsKeyword( ) )
	{
		if ( !m_strValue.empty( ) )
		{
			// 753 pre-declared-enumeration: "FALSE" | "TRUE" | "BNR" | "B1C" | "B2C" | "BSM" | "BCD" | "SBCD" | "ASCII7" | "ISO7"

			if ( ( AtlasStatement::m_strFALSE == m_strValue ) || ( AtlasStatement::m_strTRUE == m_strValue ) )
			{
				avType = XML::avBoolean;
			}
		}
	}

	return avType;
}

void AtlasAttributes::GarbageCollect( void )
{
	const unsigned int uiSize = m_vectAttributes.size( );

	if ( uiSize > 0 )
	{
		for ( unsigned int ui = 0; ui < uiSize; ++ui )
		{
			const AtlasAttibuteValue* pAttibuteValue = m_vectAttributes[ ui ];

			if ( 0 != pAttibuteValue )
			{
				delete pAttibuteValue;
			}
		}

		m_vectAttributes.clear( );
	}
}

void AtlasAttributes::SetAttributes( const vector< const AtlasAttibuteValue* >& vectAttributes, const bool bTransferOwnership )
{ 
	GarbageCollect( );

	if ( bTransferOwnership )
	{
		m_vectAttributes = vectAttributes;
	}
	else
	{
		const unsigned int uiSize = vectAttributes.size( );

		if ( uiSize > 0 )
		{
			AtlasAttibuteValue* pAtlasAttibuteValue = 0;

			m_vectAttributes.reserve( uiSize );

			for ( unsigned int ui = 0; ui < uiSize; ++ui )
			{
				try
				{
					pAtlasAttibuteValue = new AtlasAttibuteValue( *( vectAttributes[ ui ] ) );
				}
				catch ( ... )
				{
					throw Exception( Exception::eFailedToCreateAttributeValueObject, __FILE__, __FUNCTION__, __LINE__, m_strId );
				}

				m_vectAttributes.push_back( pAtlasAttibuteValue );
			}
		}
	}
}

void AtlasAttributes::InitFromXML( const DOMElement* pAIXMLvalue, const string& strStatementNumber )
{
	const DOMNodeList* pAIXML_NodeList = pAIXMLvalue->getChildNodes( );

	if ( 0 == pAIXML_NodeList )
	{
		throw Exception( Exception::eFailedToGetRequireChildNodes, __FILE__, __FUNCTION__, __LINE__ );
	}

	const XMLSize_t iMaxNodes = pAIXML_NodeList->getLength( );

	if ( 0 == iMaxNodes )
	{
		throw Exception( Exception::eInvalidNumberOfRequireNodes, __FILE__, __FUNCTION__, __LINE__ );
	}

	string strAIXMLtagName;
	vector< AtlasAttibuteValue* > vectAttributes;
	const bool bStatement = !strStatementNumber.empty( );
	bool bConcatinateSlash = false;
	bool bConcatinateMinus = false;
	bool bConcatinatePlus = false;
	bool bLeftParen =  false;

	for ( XMLSize_t iCurrentNode = 0; iCurrentNode < iMaxNodes; iCurrentNode++ )
	{
		pAIXMLvalue = ( DOMElement* ) pAIXML_NodeList->item( iCurrentNode );

		if ( 0 == pAIXMLvalue )
		{
			throw Exception( Exception::eFailedToGetXercesNodeListItem, __FILE__, __FUNCTION__, __LINE__ );
		}

		if ( DOMNode::COMMENT_NODE == pAIXMLvalue->getNodeType( ) )
		{
			continue;
		}

		AIXMLHelper::GetXercesString( pAIXMLvalue->getTagName( ), strAIXMLtagName );

		if ( !strAIXMLtagName.empty( ) )
		{
			static const wstring wstrNameAttribute( AIXMLHelper::GetWString( AIXML::m_arrayXMLKeyWords[ AIXML::eNameAttribute ] ) );
			static const wstring wstrWordAttribute( AIXMLHelper::GetWString( AIXML::m_arrayXMLKeyWords[ AIXML::eWordAttribute ] ) );
			static const wstring wstrTextAttribute( AIXMLHelper::GetWString( AIXML::m_arrayXMLKeyWords[ AIXML::eTextAttribute ] ) );
			static const wstring wstrSignAttribute( AIXMLHelper::GetWString( AIXML::m_arrayXMLKeyWords[ AIXML::eSignAttribute ] ) );
			static const wstring wstrIdAttribute( AIXMLHelper::GetWString( AIXML::m_arrayXMLKeyWords[ AIXML::eIdAttribute ] ) );
			static const wstring wstrLineNumAttribute( AIXMLHelper::GetWString( AIXML::m_arrayXMLKeyWords[ AIXML::eLineAttribute ] ) );

			const bool bVariable = ( AIXML::m_arrayXMLKeyWords[ AIXML::eVariableElement ] == strAIXMLtagName );
			const bool bKeyword = ( AIXML::m_arrayXMLKeyWords[ AIXML::eKeywordElement ] == strAIXMLtagName );
			const bool bConstant = ( AIXML::m_arrayXMLKeyWords[ AIXML::eConstantElement ] == strAIXMLtagName );
			const bool bCharacter = ( AIXML::m_arrayXMLKeyWords[ AIXML::eCharacterElement ] == strAIXMLtagName );
			const bool bString = ( AIXML::m_arrayXMLKeyWords[ AIXML::eStringElement ] == strAIXMLtagName );
			AtlasAttibuteValue* pAtlasAttibuteValue = 0;
			bool bPushBack = true;
			unsigned int uiDataType = eUnknownDataType;
			unsigned int uiId = 0;
			unsigned int uiLineNumber = 0;
			string strValue;

			if ( bVariable )
			{
				uiDataType = eVariable;
			}
			else if ( bKeyword )
			{
				uiDataType = eKeyword;
			}
			else if ( bConstant )
			{
				uiDataType = eConstant;
			}
			else if ( bString )
			{
				uiDataType = eString;
			}
			else if ( bCharacter )
			{
				uiDataType = eCharacter;
			}

			if ( bLeftParen )
			{
				uiDataType |= eDimension;
			}

			const DOMAttr* pAttr = pAIXMLvalue->getAttributeNode( wstrIdAttribute.c_str( ) );
			if ( 0 != pAttr )
			{
				string strId;
	
				AIXMLHelper::GetXercesString( pAttr->getValue( ), strId );
	
				uiId = AIXMLHelper::StringToNumber< unsigned int >( strId );
			}

			pAttr = pAIXMLvalue->getAttributeNode( wstrLineNumAttribute.c_str( ) );
			if ( 0 != pAttr )
			{
				string strLineNum;
	
				AIXMLHelper::GetXercesString( pAttr->getValue( ), strLineNum );
	
				uiLineNumber = AIXMLHelper::StringToNumber< unsigned int >( strLineNum );
			}

			pAttr = pAIXMLvalue->getAttributeNode( wstrWordAttribute.c_str( ) );
			if ( 0 == pAttr )
			{
				pAttr = pAIXMLvalue->getAttributeNode( wstrNameAttribute.c_str( ) );
			}

			if ( 0 != pAttr )
			{
				strValue = AIXMLHelper::GetXercesString( pAttr->getValue( ), ( ( eString == ( uiDataType & eString ) ) ? false : true ) );
			}
			else
			{
				pAttr = pAIXMLvalue->getAttributeNode( wstrTextAttribute.c_str( ) );

				if ( 0 != pAttr )
				{
					strValue = AIXMLHelper::GetXercesString( pAttr->getValue( ), ( ( eString == ( uiDataType & eString ) ) ? false : true ) );

					if ( bCharacter )
					{
						if ( ( AtlasStatement::m_strLeftParen == strValue ) 
							|| ( AtlasStatement::m_strRightParen == strValue ) 
							|| ( AtlasStatement::m_strFrontSlash == strValue )
							|| ( AtlasStatement::m_strMinus == strValue )
							|| ( AtlasStatement::m_strPlus == strValue )
							|| ( AtlasStatement::m_strAssign == strValue ) )
						{
							if ( AtlasStatement::m_strFrontSlash == strValue )
							{
								bConcatinateSlash = true;
							}
							else if ( AtlasStatement::m_strMinus == strValue )
							{
								bConcatinateMinus = true;
							}
							else if ( AtlasStatement::m_strPlus == strValue )
							{
								bConcatinatePlus = true;
							}
							else if ( AtlasStatement::m_strLeftParen == strValue )
							{
								bLeftParen = true;
							}
							else if ( AtlasStatement::m_strRightParen == strValue )
							{
								bLeftParen = false;
							}

							// The "assign" character is used in the FILL statement

							if ( AtlasStatement::m_strAssign != strValue )
							{
								bPushBack = false;
							}
						}
						else
						{
							string strError( strValue );

							if ( m_strId.empty( ) )
							{
								strError += " [";
								strError += m_strId;
								strError += "]";
							}

							throw Exception( Exception::eUnexpectedCharacterFound, __FILE__, __FUNCTION__, __LINE__, strError );
						}
					}
				}
				else
				{
					throw Exception( Exception::eNoKnownAttributesFound, __FILE__, __FUNCTION__, __LINE__, m_strId );
				}
			}

			if ( bPushBack )
			{
				if ( bConstant )
				{
					pAttr = pAIXMLvalue->getAttributeNode( wstrSignAttribute.c_str( ) );

					if ( 0 != pAttr )
					{
						strValue.insert( 0, AIXMLHelper::GetXercesString( pAttr->getValue( ) ) );
					}
				}

				if ( bConcatinateSlash )
				{
					if ( vectAttributes.size( ) > 0 )
					{
						string& strBack = vectAttributes.back( )->m_strValue;
	
						strBack += AtlasStatement::m_strFrontSlash;
						strBack += strValue;
					}
					else
					{
						// This should probably never happen

						strValue.insert( 0, AtlasStatement::m_strFrontSlash );

						try
						{
							pAtlasAttibuteValue = new AtlasAttibuteValue( strValue, uiDataType, uiId );
						}
						catch ( ... )
						{
							throw Exception( Exception::eFailedToCreateAttributeValueObject, __FILE__, __FUNCTION__, __LINE__, m_strId );
						}

						if ( uiLineNumber > 0 )
						{
							pAtlasAttibuteValue->m_uiLineNumber = uiLineNumber;
						}

						if ( bStatement )
						{
							pAtlasAttibuteValue->m_strStatementNumber = strStatementNumber;
						}

						vectAttributes.push_back( pAtlasAttibuteValue );
					}

					bConcatinateSlash = false;
				}
				else
				{
					if ( bConcatinateMinus || bConcatinatePlus )
					{
						strValue.insert( 0, ( bConcatinateMinus ? AtlasStatement::m_strMinus : AtlasStatement::m_strPlus ) );

						bConcatinateMinus = false;
						bConcatinatePlus = false;
					}

					/*
					// Handled siuation where there was a dimension directly next to a number
					// (no space inbetween). According to the Atlas 716 BNF this should not be 
					// allowed, but I guess CASS allowed for it.

					// Removed 11/6/2014 - Atlas parser now handling the situation.
					// Split off trailing non-numeric characters except when used
					// within the CNX area of a statement. In the CNX area its okay
					// that non-numeric characters follow numbers (i.e. 1J1-23) because
					// CNX information can be alpha-numeric.

					const string::size_type stLoc = AIXMLHelper::NumberDimensionPos( strValue );

					if ( string::npos != stLoc )
					{
						vectAttributes.push_back( strValue.substr( 0, stLoc ) );
						vectAttributes.push_back( strValue.substr( stLoc ) );
					}
					else
					{
						vectAttributes.push_back( strValue );
					}
					*/

					try
					{
						pAtlasAttibuteValue = new AtlasAttibuteValue( strValue, uiDataType, uiId );
					}
					catch ( ... )
					{
						throw Exception( Exception::eFailedToCreateAttributeValueObject, __FILE__, __FUNCTION__, __LINE__, m_strId );
					}

					if ( uiLineNumber > 0 )
					{
						pAtlasAttibuteValue->m_uiLineNumber = uiLineNumber;
					}

					if ( bStatement )
					{
						pAtlasAttibuteValue->m_strStatementNumber = strStatementNumber;
					}

					vectAttributes.push_back( pAtlasAttibuteValue );
				}
			}
		}
	}

	if ( 0 == vectAttributes.size( ) )
	{
		throw Exception( Exception::eNoAttributesFound, __FILE__, __FUNCTION__, __LINE__, m_strId );
	}

	m_vectAttributes.insert( m_vectAttributes.end( ), vectAttributes.begin( ), vectAttributes.end( ) );
}

AtlasAttributes& AtlasAttributes::operator = ( const AtlasAttributes& other )
{
	if ( this != &other )
	{
		GarbageCollect( );

		m_bProcessed = other.m_bProcessed;
		m_strId = other.m_strId;

		const unsigned int uiSize = other.m_vectAttributes.size( );
	
		if ( uiSize > 0 )
		{
			AtlasAttibuteValue* pAtlasAttibuteValue = 0;

			m_vectAttributes.reserve( uiSize );

			for ( unsigned int ui = 0; ui < uiSize; ++ui )
			{
				try
				{
					pAtlasAttibuteValue = new AtlasAttibuteValue( *( other.m_vectAttributes[ ui ] ) );
				}
				catch ( ... )
				{
					throw Exception( Exception::eFailedToCreateAttributeValueObject, __FILE__, __FUNCTION__, __LINE__, m_strId );
				}

				m_vectAttributes.push_back( pAtlasAttibuteValue );
			}
		}
	}

	return *this;
}

bool AtlasSignalVerb::Compare::operator( )( const pair< Atlas::AtlasSignalComponent, Atlas::AtlasStatementCharacteristic* >& l, const pair< Atlas::AtlasSignalComponent, Atlas::AtlasStatementCharacteristic* >& r )
{
	return ( ( string ) l.first < ( string ) r.first );
}

AtlasStatement& AtlasSignalVerb::operator = ( const AtlasStatement& other )
{
	if ( this != &other )
	{
		AtlasStatement::operator = ( other );

		GarbageCollect( );

		const AtlasSignalVerb* pother = dynamic_cast< const AtlasSignalVerb* >( &other );

		if ( 0 != pother )
		{
			m_strVirtualLabel	= pother->m_strVirtualLabel;
			m_strSystemName		= pother->m_strSystemName;
			m_eInstrument		= pother->m_eInstrument;
			m_PrimarySignalComponent = pother->m_PrimarySignalComponent;
		}
	}

	return *this;
}

AtlasStatement::eScope AtlasStatement::GetScopeEnum( const string& strScope )
{
	eScope eScopeType = eUnknownScope;

	if ( strScope == AIXML::m_arrayXMLKeyWords[ AIXML::eExternalAttribute ] )
	{
		eScopeType = eExternal;
	}
	else if ( strScope == AIXML::m_arrayXMLKeyWords[ AIXML::eGlobalAttribute ] )
	{
		eScopeType = eGlobal;
	}
	else if ( strScope == AIXML::m_arrayXMLKeyWords[ AIXML::eLocalAttribute ] )
	{
		eScopeType = eLocal;
	}

	return eScopeType;
}

unsigned int AtlasStatement::GetCommentId( const xercesc::DOMElement* pAIXMLvalue )
{
	unsigned int uiCommentId = 0;

	if ( 0 != pAIXMLvalue )
	{
		const xercesc::DOMElement* pAIXMLprev = pAIXMLvalue->getPreviousElementSibling( );
		string strAIXMLtagName;

		if ( 0 == pAIXMLprev )
		{
			// There are times when the parent's sibling may contain the comment

			const xercesc::DOMNode* pParent = pAIXMLvalue->getParentNode( );

			if ( 0 != pParent )
			{
				if ( DOMNode::ELEMENT_NODE == pParent->getNodeType( ) )
				{
					pAIXMLprev = ( xercesc::DOMElement* ) pParent;

					if ( 0 != pAIXMLprev )
					{
						AIXMLHelper::GetXercesString( pAIXMLprev->getTagName( ), strAIXMLtagName );

						pAIXMLprev = pAIXMLprev->getPreviousElementSibling( );
					}
				}
			}
		}

		while ( 0 != pAIXMLprev )
		{
			AIXMLHelper::GetXercesString( pAIXMLprev->getTagName( ), strAIXMLtagName );

			const bool bCommentBlock = ( AIXML::m_arrayXMLKeyWords[ AIXML::eCommentBlockElement ] == strAIXMLtagName );
			const bool bBranchTarget = ( AIXML::m_arrayXMLKeyWords[ AIXML::eBranchTargetElement ] == strAIXMLtagName );
			const bool bEntryPoint = ( AIXML::m_arrayXMLKeyWords[ AIXML::eEntryPointElement ] == strAIXMLtagName );

			if ( bCommentBlock || bBranchTarget || bEntryPoint )
			{
				if ( HasCommentText( pAIXMLprev ) )
				{
					const DOMAttr* pAttr = pAIXMLprev->getAttributeNode( AIXMLHelper::GetWString( AIXML::m_arrayXMLKeyWords[ AIXML::eIdAttribute ] ).c_str( ) );
					if ( 0 != pAttr )
					{
						string strId;
				
						AIXMLHelper::GetXercesString( pAttr->getValue( ), strId );
				
						uiCommentId = AIXMLHelper::StringToNumber< unsigned int >( strId );
					}
					#if ( _DEBUG ) && ( WIN32 )
					else
					{
						DebugBreak( );
					}
					#endif

					break;
				}
				else
				{
					pAIXMLprev = pAIXMLprev->getPreviousElementSibling( );
				}
			}
			else
			{
				break;
			}
		}
	}

	return uiCommentId;
}

bool AtlasStatement::HasCommentText( const xercesc::DOMElement* pAIXMLvalue )
{
	const xercesc::DOMElement* pComment = pAIXMLvalue->getFirstElementChild( );
	bool bHasCommentText = false;

	if ( 0 != pComment )
	{
		string strAIXMLtagName;
		string strComment;
	
		while ( 0 != pComment )
		{
			AIXMLHelper::GetXercesString( pComment->getTagName( ), strAIXMLtagName );
	
			if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eCommentElement ] )
			{
				const xercesc::DOMNode* pCommentText = pComment->getFirstChild( );
				if ( 0 != pCommentText )
				{
					if ( DOMNode::TEXT_NODE == pCommentText->getNodeType( ) )
					{
						AIXMLHelper::GetXercesString( pCommentText->getTextContent( ), strComment );
	
						AIXMLHelper::Trim( strComment, false );
	
						if ( strComment.size( ) > 0 )
						{
							bHasCommentText = true;
							break;
						}
					}
				}
			}
	
			pComment = pComment->getNextElementSibling( );
		}
	}

	return bHasCommentText;
}

AtlasStatement& AtlasStatement::operator = ( const AtlasStatement& other )
{
	if ( this != &other )
	{
		GarbageCollect( );

		AtlasAttributes::operator = ( other );

		m_bProcessed				= other.m_bProcessed;
		m_eAtlasStatement			= other.m_eAtlasStatement;
		m_vectAtlasSourceStatement	= other.m_vectAtlasSourceStatement;
		m_uiId						= other.m_uiId;
		m_uiParentProcedureId		= other.m_uiParentProcedureId;
		m_strParentProcedureName	= other.m_strParentProcedureName;
		m_uiConditionalStatementsId	= other.m_uiConditionalStatementsId;

		// Can't copy pointers
		//m_multimapVariables			= other.m_multimapVariables;
	}

	return *this;
}

unsigned int AtlasStatement::SetSourceStatementInfo( const xercesc::DOMElement* pAIXMLvalue, const Atlas::AtlasSourceStatement::eSourceType eSourcType, const string& strFilename, const string& strParentProcname, const unsigned int uiParentProcId )
{
	unsigned int uId = 0;

	if ( 0 != pAIXMLvalue )
	{
		Atlas::AtlasSourceStatement ss;

		SetSourceStatementInfo( ss, pAIXMLvalue, eSourcType, strFilename, strParentProcname );

		ss.SetAtlasStatement( m_eAtlasStatement );

		if ( 0 == m_vectAtlasSourceStatement.size( ) )
		{
			m_vectAtlasSourceStatement.push_back( ss );
		}
		else
		{
			m_vectAtlasSourceStatement.front( ) = ss;
		}

		uId = ss.GetId( );
	}

	m_strParentProcedureName = strParentProcname;
	m_uiId = uId;
	m_uiParentProcedureId = uiParentProcId;

	return uId;
}

void AtlasStatement::SetSourceStatementInfo( Atlas::AtlasSourceStatement& ss, const xercesc::DOMElement* pAIXMLvalue, const Atlas::AtlasSourceStatement::eSourceType eSourcType, const string& strFilename, const string& strParentProcname )
{
	const DOMAttr* pAttr = pAIXMLvalue->getAttributeNode( AIXMLHelper::GetWString( AIXML::m_arrayXMLKeyWords[ AIXML::eStatementNumberAttribute ] ).c_str( ) );
	if ( 0 != pAttr )
	{
		string strStatementNum;

		AIXMLHelper::GetXercesString( pAttr->getValue( ), strStatementNum );

		ss.SetStatementNumber( strStatementNum );
	}
	else
	{
		pAttr = pAIXMLvalue->getAttributeNode( AIXMLHelper::GetWString( AIXML::m_arrayXMLKeyWords[ AIXML::eTestNumberAttribute ] ).c_str( ) );
		if ( 0 != pAttr )
		{
			string strTestNum;
	
			AIXMLHelper::GetXercesString( pAttr->getValue( ), strTestNum );
	
			ss.SetTestNumber( strTestNum );
		}
	}

	pAttr = pAIXMLvalue->getAttributeNode( AIXMLHelper::GetWString( AIXML::m_arrayXMLKeyWords[ AIXML::eLineAttribute ] ).c_str( ) );
	if ( 0 != pAttr )
	{
		string strLineNum;

		AIXMLHelper::GetXercesString( pAttr->getValue( ), strLineNum );

		ss.SetLineNumber( AIXMLHelper::StringToNumber< unsigned int >( strLineNum ) );
	}

	pAttr = pAIXMLvalue->getAttributeNode( AIXMLHelper::GetWString( AIXML::m_arrayXMLKeyWords[ AIXML::eIdAttribute ] ).c_str( ) );
	if ( 0 != pAttr )
	{
		string strId;

		AIXMLHelper::GetXercesString( pAttr->getValue( ), strId );

		ss.SetId( AIXMLHelper::StringToNumber< unsigned int >( strId ) );
	}

	ss.SetCommentId( GetCommentId( pAIXMLvalue ) );
	ss.SetSourceType( eSourcType );
	ss.SetFilename( strFilename );
	ss.SetParentProcname( strParentProcname );
}

void AtlasStatement::ProcessVariableSymbols( const map< string, vector< AtlasDeclareData* >* >& mapDeclares, const map< Atlas::AtlasData::eBuiltInType, AtlasDeclareData* >& mapBuiltinDeclares, const AtlasProcedure* pProcedure, const vector< pair< string, Atlas::AtlasSourceStatement::eSourceType > >* pvectAtlasSourceFiles )
{
	if ( ( m_multimapVariables.size( ) > 0 ) && ( mapBuiltinDeclares.size( ) > 0 ) )
	{
		map< string, vector< AtlasDeclareData* >* >::const_iterator itDeclares;
		const map< string, vector< AtlasDeclareData* >* >::const_iterator itDeclaresEnd = mapDeclares.end( );
		multimap< string, Atlas::AtlasData* >::const_iterator itVars = m_multimapVariables.begin( );
		const multimap< string, Atlas::AtlasData* >::const_iterator itVarsEnd = m_multimapVariables.end( );
		map< Atlas::AtlasData::eBuiltInType, AtlasDeclareData* >::const_iterator itBuiltInDeclares;
		const map< Atlas::AtlasData::eBuiltInType, AtlasDeclareData* >::const_iterator itBuiltInDeclaresEnd = mapBuiltinDeclares.end( );
		const string strFilename( GetSourceInfo( )->GetFilename( ) );
		bool bSegmentedSource = false;

		while ( itVarsEnd != itVars )
		{
			const AtlasDeclareData* pDeclareData = ( 0 == pProcedure ? 0 : pProcedure->GetVariable( itVars->first ) );
			Atlas::AtlasData* pData = itVars->second;

			if ( 0 != pDeclareData )
			{
				SetProcedureSymbolInfo( pDeclareData, pData );
			}
			else
			{
				const Atlas::AtlasData::eBuiltInType eBuiltIntype = itVars->second->GetBuiltInType( );

				if ( Atlas::AtlasData::eUnknownBuiltInType != eBuiltIntype )
				{
					itBuiltInDeclares = mapBuiltinDeclares.find( eBuiltIntype );

					if ( itBuiltInDeclaresEnd != itBuiltInDeclares )
					{
						pData->SetScopeType( Atlas::AtlasData::eBuiltIn );
						pData->SetVariableRefId( itBuiltInDeclares->second->m_Source.GetId( ) );
						pData->SetAtlasDataType( itBuiltInDeclares->second->m_Declare.m_eDataType );
						++( itBuiltInDeclares->second->m_uiUseCount );
					}
					#if ( _DEBUG ) && ( WIN32 )
					else
					{
						DebugBreak( );
					}
					#endif
				}
				else
				{
					itDeclares = mapDeclares.find( itVars->first );
		
					if ( itDeclaresEnd != itDeclares )
					{
						SetDeclareSymbolInfo( strFilename, itDeclares->second, pData, pvectAtlasSourceFiles );
					}
					#if ( _DEBUG ) && ( WIN32 )
					else
					{
						if ( itVars->second->IsRefIdRequired( ) )
						{
							DebugBreak( );
						}
					}
					#endif
				}
			}

			++itVars;
		}
	}
}

void AtlasStatement::SetProcedureSymbolInfo( const AtlasDeclareData* pDeclareData, Atlas::AtlasData* pData )
{
	if ( pDeclareData->m_Declare.IsParameter( ) )
	{
		pData->SetScopeType( Atlas::AtlasData::eProcedureParameter );
	}
	else if ( pDeclareData->m_Declare.IsResult( ) )
	{
		pData->SetScopeType( Atlas::AtlasData::eProcedureResult );
	}
	else
	{
		pData->SetScopeType( Atlas::AtlasData::eProcedureLocal );
	}
				
	pData->SetVariableRefId( pDeclareData->m_Source.GetId( ) );

	#if ( _DEBUG ) && ( WIN32 )
	if ( Atlas::eUnknownDataType != pData->GetAtlasDataType( ) )
	{
		if ( pDeclareData->m_Declare.m_eDataType != pData->GetAtlasDataType( ) )
		{
			DebugBreak( );
		}
	}
	#endif

	pData->SetAtlasDataType( pDeclareData->m_Declare.m_eDataType );
}

void AtlasStatement::SetDeclareSymbolInfo( const string strFilename, const vector< AtlasDeclareData* >* pvectDeclares, Atlas::AtlasData* pData, const vector< pair< string, Atlas::AtlasSourceStatement::eSourceType > >* pvectAtlasSourceFiles )
{
	const unsigned int uiDeclares = pvectDeclares->size( );
	const AtlasDeclareData* pGlobalVar = 0;
	const AtlasDeclareData* pLocalVar = 0;
	bool bSegmentLocal = false;

	for ( unsigned int ui = 0; ui < uiDeclares; ++ui )
	{
		const AtlasDeclareData* pVar = pvectDeclares->at( ui );

		if ( pVar->m_Declare.IsGlobal( ) )
		{
			pGlobalVar = pVar;
		}
		else if ( strFilename == pVar->m_Source.GetFilename( ) && !pVar->m_Declare.IsExternal( ) )
		{
			pLocalVar = pVar;
			break;
		}
	}

	if ( ( 0 == pLocalVar ) && ( 0 == pGlobalVar ) )
	{
		if ( 0 != pvectAtlasSourceFiles )
		{
			unsigned int uiSourceFileCount = pvectAtlasSourceFiles->size( );
			bool bSegmentedSource = false;
			string strProgramFilename;

			for ( unsigned int ui = 0 ; ui < uiSourceFileCount; ++ui )
			{
				const pair< string, Atlas::AtlasSourceStatement::eSourceType >& pr = pvectAtlasSourceFiles->at( ui );

				if ( Atlas::AtlasSourceStatement::eAtlasProgram == pr.second )
				{
					strProgramFilename = pr.first;
				}
				else if ( Atlas::AtlasSourceStatement::eAtlasSegment == pr.second )
				{
					if ( pr.first == strFilename )
					{
						bSegmentedSource = true;

						if ( !strProgramFilename.empty( ) )
						{
							break;
						}
					}
				}
			}

			if ( bSegmentedSource && !strProgramFilename.empty( ) )
			{
				for ( unsigned int ui = 0; ui < uiDeclares; ++ui )
				{
					const AtlasDeclareData* pVar = pvectDeclares->at( ui );

					if ( strProgramFilename == pVar->m_Source.GetFilename( ) )
					{
						pLocalVar = pVar;
						bSegmentLocal = true;
						break;
					}
				}
			}
		}
	}

	if ( 0 != pLocalVar )
	{
		if ( bSegmentLocal )
		{
			pData->SetScopeType( Atlas::AtlasData::eSegmentLocal );
		}
		else
		{
			pData->SetScopeType( Atlas::AtlasData::eFileLocal );
		}

		pData->SetVariableRefId( pLocalVar->m_Source.GetId( ) );

		#if ( _DEBUG ) && ( WIN32 )
		if ( Atlas::eUnknownDataType != pData->GetAtlasDataType( ) )
		{
			if ( pLocalVar->m_Declare.m_eDataType != pData->GetAtlasDataType( ) )
			{
				if ( !pLocalVar->m_Declare.IsAtlasNumericDataType( ) || !pData->IsAtlasNumericDataType( ) )
				{
					DebugBreak( );
				}
			}
		}
		#endif

		pData->SetAtlasDataType( pLocalVar->m_Declare.m_eDataType );
	}
	else if ( 0 != pGlobalVar )
	{
		pData->SetScopeType( Atlas::AtlasData::eGlobal );
		pData->SetVariableRefId( pGlobalVar->m_Source.GetId( ) );

		#if ( _DEBUG ) && ( WIN32 )
		if ( Atlas::eUnknownDataType != pData->GetAtlasDataType( ) )
		{
			if ( pGlobalVar->m_Declare.m_eDataType != pData->GetAtlasDataType( ) )
			{
				DebugBreak( );
			}
		}
		#endif

		pData->SetAtlasDataType( pGlobalVar->m_Declare.m_eDataType );
	}
	#if ( _DEBUG ) && ( WIN32 )
	else
	{
		DebugBreak( );
	}
	#endif
}

string AtlasStatement::GetParentProcedureName( const unsigned uiPos ) const
{
	const unsigned int uiSize = m_vectAtlasSourceStatement.size( );
	string strProcName;

	if ( uiPos < uiSize )
	{
		strProcName = m_vectAtlasSourceStatement[ uiPos ].GetParentProcname( );
	}

	return strProcName;
}

const Atlas::AtlasSourceStatement* AtlasStatement::GetSourceInfo( const unsigned uiPos ) const
{
	const unsigned int uiSize = m_vectAtlasSourceStatement.size( );
	const Atlas::AtlasSourceStatement* pAtlasSourceStatement = 0;

	if ( uiPos < uiSize )
	{
		pAtlasSourceStatement = &( m_vectAtlasSourceStatement[ uiPos ] );
	}

	return pAtlasSourceStatement;
}

string AtlasStatement::GetStatementNumber( const unsigned uiPos ) const
{
	const Atlas::AtlasSourceStatement* pSourceInfo = GetSourceInfo( uiPos );
	string strStatementNumber;

	if ( 0 != pSourceInfo )
	{
		strStatementNumber = pSourceInfo->GetStatementNumber( );
	}

	return strStatementNumber;
}

string AtlasStatement::GetStatementTestNumber( const unsigned uiPos ) const
{
	const Atlas::AtlasSourceStatement* pSourceInfo = GetSourceInfo( uiPos );
	string strTestNumber;

	if ( 0 != pSourceInfo )
	{
		strTestNumber = pSourceInfo->GetTestNumber( );
	}

	return strTestNumber;
}

bool AtlasStatement::GetStatementIsBeginTest( const unsigned uiPos ) const
{
	const Atlas::AtlasSourceStatement* pSourceInfo = GetSourceInfo( uiPos );
	bool bIsBeginTest = false;

	if ( 0 != pSourceInfo )
	{
		bIsBeginTest = pSourceInfo->IsBeginTest( );
	}

	return bIsBeginTest;
}

void AtlasStatement::SetStatementTestNumber( const string& strTestNumber, const unsigned uiPos )
{
	Atlas::AtlasSourceStatement* pSourceInfo = ( Atlas::AtlasSourceStatement* ) GetSourceInfo( uiPos );

	if ( 0 != pSourceInfo )
	{
		pSourceInfo->SetTestNumber( strTestNumber );
	}
}

string AtlasStatement::GetStatementStepNumber( const unsigned uiPos ) const
{
	const Atlas::AtlasSourceStatement* pSourceInfo = GetSourceInfo( uiPos );
	string strStepNumber;

	if ( 0 != pSourceInfo )
	{
		strStepNumber = pSourceInfo->GetStepNumber( );
	}

	return strStepNumber;
}

string AtlasStatement::GetStatementParentProcname( const unsigned uiPos ) const
{
	const Atlas::AtlasSourceStatement* pSourceInfo = GetSourceInfo( uiPos );
	string strParentProcname;

	if ( 0 != pSourceInfo )
	{
		strParentProcname = pSourceInfo->GetParentProcname( );
	}

	return strParentProcname;
}

unsigned int AtlasStatement::GetStatementLineNumber( const unsigned uiPos ) const
{
	const Atlas::AtlasSourceStatement* pSourceInfo = GetSourceInfo( uiPos );
	unsigned int uiLineNumber = 0;

	if ( 0 != pSourceInfo )
	{
		uiLineNumber = pSourceInfo->GetLineNumber( );
	}

	return uiLineNumber;
}

string AtlasStatement::GetStatementFilename( const unsigned uiPos ) const
{
	const Atlas::AtlasSourceStatement* pSourceInfo = GetSourceInfo( uiPos );
	string strFilename;

	if ( 0 != pSourceInfo )
	{
		strFilename = pSourceInfo->GetFilename( );
	}

	return strFilename;
}

unsigned int AtlasStatement::GetStatementCommentId( const unsigned uiPos ) const
{
	const Atlas::AtlasSourceStatement* pSourceInfo = GetSourceInfo( uiPos );
	unsigned int uiCommentId = 0;

	if ( 0 != pSourceInfo )
	{
		uiCommentId = pSourceInfo->GetCommentId( );
	}

	return uiCommentId;
}

string AtlasStatement::GetStatementCommentRefId_XML( void ) const
{
	const unsigned int uiCommentId = GetStatementCommentId( );
	string strRet;

	if ( uiCommentId > 0 )
	{
		strRet = XML::MakeXmlAttributeNameValue( XML::anCommentRefId, uiCommentId );
	}

	return strRet;
}

string AtlasStatement::GetStatementTestNumber_XML( void ) const
{
	string strTestNumber( GetStatementTestNumber( ) );

	if ( !strTestNumber.empty( ) )
	{
		strTestNumber = XML::MakeXmlAttributeNameValue( XML::anTestNumber, strTestNumber );
	}
	#if ( _DEBUG ) && ( WIN32 )
	else
	{
		DebugBreak( );
	}
	#endif

	return strTestNumber;
}

string AtlasStatement::GetStatementBeginTest_XML( void ) const
{
	string strBeginTest;

	if ( GetStatementIsBeginTest( ) )
	{
		strBeginTest = XML::MakeXmlAttributeNameValue( XML::anBeginTest, XML::avTrue );
	}

	return strBeginTest;
}

bool AtlasStatement::IsVariable( const string& strVarName, const unsigned int uiVarId ) const
{
	bool bIsVariable = false;

	if ( m_multimapVariables.size( ) > 0 )
	{
		multimap< string, Atlas::AtlasData* >::const_iterator it = m_multimapVariables.find( strVarName );
		const multimap< string, Atlas::AtlasData* >::const_iterator itEnd = m_multimapVariables.end( );

		while ( itEnd != it )
		{
			if ( strVarName == it->first )
			{
				if ( it->second->GetVariableRefId( ) == uiVarId )
				{
					bIsVariable = true;
				}
			}
			else
			{
				break;
			}

			++it;
		}
	}

	return bIsVariable;
}

void AtlasStatement::InitSourceInfo( const AtlasStatement* pAtlasStatement )
{
	if ( 0 != pAtlasStatement )
	{
		m_uiId						= pAtlasStatement->m_uiId;
		m_vectAtlasSourceStatement	= pAtlasStatement->m_vectAtlasSourceStatement;
		m_uiParentProcedureId		= pAtlasStatement->m_uiParentProcedureId;
		m_strParentProcedureName	= pAtlasStatement->m_strParentProcedureName;
		m_uiConditionalStatementsId	= pAtlasStatement->m_uiConditionalStatementsId;

		#if ( _DEBUG ) && ( WIN32 )
		if ( 0 == m_uiId )
		{
			DebugBreak( );
		}
		#endif
	}
}

void AtlasStatement::InitId( void )
{
	if ( m_vectAtlasSourceStatement.size( ) > 0 )
	{
		m_uiId = m_vectAtlasSourceStatement[ 0 ].GetId( );
	}
}

void AtlasStatement::ProcessVariableSymbols( const Atlas::AtlasTermBase* pTermBase )
{
	if ( 0 != pTermBase )
	{
		if ( 0 != dynamic_cast< const Atlas::AtlasMathFunction* >( pTermBase ) )
		{
			ProcessVariableSymbols( ( ( Atlas::AtlasMathFunction* ) pTermBase )->GetTerm( false ) );
		}
		else if ( 0 != dynamic_cast< const Atlas::AtlasExpression* >( pTermBase ) )
		{
			ProcessVariableSymbols( ( ( Atlas::AtlasExpression* ) pTermBase )->GetLeftExp( false ) );
			ProcessVariableSymbols( ( ( Atlas::AtlasExpression* ) pTermBase )->GetRightExp( false ) );
		}
		else if ( 0 != dynamic_cast< const Atlas::AtlasLimitTerm* >( pTermBase ) )
		{
			ProcessVariableSymbols( ( ( Atlas::AtlasLimitTerm* ) pTermBase )->GetLimitNumber( ) );
			ProcessVariableSymbols( ( ( Atlas::AtlasLimitTerm* ) pTermBase )->GetLowerLimit( ) );
			ProcessVariableSymbols( ( ( Atlas::AtlasLimitTerm* ) pTermBase )->GetUpperLimit( ) );
		}
		else
		{
			Atlas::AtlasData* pAtlasData = ( ( Atlas::AtlasTerm* ) pTermBase )->GetTerm( false );

			if ( 0 != pAtlasData )
			{
				if ( pAtlasData->IsVariableName( ) )
				{
					m_multimapVariables.insert( make_pair( pAtlasData->GetVariableName( ), pAtlasData ) );
				}
			}

			pAtlasData = ( ( Atlas::AtlasTerm* ) pTermBase )->GetSubscriptTerm( false );

			if ( 0 != pAtlasData )
			{
				if ( pAtlasData->IsVariableName( ) )
				{
					m_multimapVariables.insert( make_pair( pAtlasData->GetVariableName( ), pAtlasData ) );
				}
			}
		}
	}
}

void AtlasStatements::InitId( void )
{
	const unsigned int uiSize = m_vectStatement.size( );

	if ( uiSize > 0 )
	{
		for ( unsigned int ui = 0; ui < uiSize; ++ui )
		{
			m_vectStatement[ ui ]->InitId( );
		}
	}
}

AtlasStatements& AtlasStatements::operator = ( const AtlasStatements& other )
{
	if ( this != &other )
	{
		GarbageCollect( );

		const unsigned int uiSize = other.m_vectStatement.size( );
	
		if ( uiSize > 0 )
		{
			AtlasStatement* pStatementOther = 0;
			AtlasStatement* pStatement = 0;

			for ( unsigned int ui = 0; ui < uiSize; ++ui )
			{
				pStatementOther = other.m_vectStatement[ ui ];

				pStatement = StatementFactory( pStatementOther );

				if ( 0 == pStatement )
				{
					throw Exception( Exception::eFailedToAllocateMemoryForNewStatementObject, __FILE__, __FUNCTION__, __LINE__ );
				}

				*pStatement = *( pStatementOther );
			}
		}

		m_bProcessed = other.m_bProcessed;

		#ifdef CASS
			m_pLookup = other.m_pLookup;
		#endif
	}

	return *this;
}

void AtlasStatements::GarbageCollect( void )
{
	const unsigned int uiSize = m_vectStatement.size( );

	if ( uiSize > 0 )
	{
		for ( unsigned int ui = 0; ui < uiSize; ++ui )
		{
			delete m_vectStatement[ ui ];
		}

		m_vectStatement.clear( );
	}
}

void AtlasStatements::Process( void )
{
	if ( !m_bProcessed )
	{
		const unsigned int uiSize = m_vectStatement.size( );
	
		if ( uiSize > 0 )
		{
			for ( unsigned int ui = 0; ui < uiSize; ++ui )
			{
				#ifdef CASS
					m_vectStatement[ ui ]->Process( m_pLookup );
				#else
					m_vectStatement[ ui ]->ProcessXML( );
				#endif
			}
		}

		m_bProcessed = true;
	}
}

bool AtlasStatements::IsFileSystemFromXML( const xercesc::DOMElement* pAIXMLvalue )
{
	bool bIsFileSystem = false;

	pAIXMLvalue = pAIXMLvalue->getNextElementSibling( );

	if ( 0 != pAIXMLvalue )
	{
		pAIXMLvalue	= pAIXMLvalue->getFirstElementChild( );

		if ( 0 != pAIXMLvalue )
		{
			pAIXMLvalue = pAIXMLvalue->getNextElementSibling( );

			if ( 0 != pAIXMLvalue )
			{
				string strAIXMLtagName;

				AIXMLHelper::GetXercesString( pAIXMLvalue->getTagName( ), strAIXMLtagName );

				if ( !strAIXMLtagName.empty( ) )
				{
					if ( AIXML::m_arrayXMLKeyWords[ AIXML::eKeywordElement ] == strAIXMLtagName )
					{
						static const wstring wstrWordAttribute( AIXMLHelper::GetWString( AIXML::m_arrayXMLKeyWords[ AIXML::eWordAttribute ] ) );
						string strValue;
			
						const DOMAttr* pAttr = pAIXMLvalue->getAttributeNode( wstrWordAttribute.c_str( ) );
			
						if ( 0 != pAttr )
						{
							strValue = AIXMLHelper::GetXercesString( pAttr->getValue( ) );

							if ( !strValue.empty( ) )
							{
								if ( AtlasStatement::m_strFILE == strValue )
								{
									bIsFileSystem = true;
								}
							}
						}
					}
				}
			}
		}
	}

	return bIsFileSystem;
}


void AtlasActionSignalVerb::GarbageCollect( void )
{
	if ( 0 != m_pReadDate )
	{
		delete m_pReadDate;
		m_pReadDate = 0;
	}

	if ( 0 != m_pCNX )
	{
		delete m_pCNX;
		m_pCNX = 0;
	}

	if ( 0 != m_pFromToEvent )
	{
		delete m_pFromToEvent;
		m_pFromToEvent = 0;
	}

	if ( 0 != m_pGatedEvent )
	{
		delete m_pGatedEvent;
		m_pGatedEvent = 0;
	}

	if ( 0 != m_pSyncEvent )
	{
		delete m_pSyncEvent;
		m_pSyncEvent = 0;
	}

	if ( 0 != m_pEvaluationStatement )
	{
		delete m_pEvaluationStatement;
		m_pEvaluationStatement = 0;
	}

	unsigned int uiSize = m_vectMeasuredCharacteristic.size( );
	if ( uiSize > 0 )
	{
		for ( unsigned int ui = 0; ui < uiSize; ++ui )
		{
			if ( 0 != m_vectMeasuredCharacteristic[ ui ].second )
			{
				delete m_vectMeasuredCharacteristic[ ui ].second;
			}
		}

		m_vectMeasuredCharacteristic.clear( );
	}

	uiSize = m_vectAtlasNounMod.size( );
	if ( uiSize > 0 )
	{
		for ( unsigned int ui = 0; ui < uiSize; ++ui )
		{
			if ( 0 != m_vectAtlasNounMod[ ui ].second )
			{
				delete m_vectAtlasNounMod[ ui ].second;
			}
		}

		m_vectAtlasNounMod.clear( );
	}

	uiSize = m_mapErrorLimits.size( );
	if ( uiSize > 0 )
	{
		m_mapErrorLimits.clear( );
	}
}

AtlasStatement& AtlasActionSignalVerb::operator = ( const AtlasStatement& other )
{
	if ( this != &other )
	{
		AtlasSignalVerb::operator = ( other );

		GarbageCollect( );

		const AtlasActionSignalVerb* pother = dynamic_cast< const AtlasActionSignalVerb* >( &other );

		if ( 0 != pother )
		{
			m_eVerbElementName = pother->m_eVerbElementName;
			m_bHasMeasureCharacteristics = pother->m_bHasMeasureCharacteristics;
			m_bRemoveAll = pother->m_bRemoveAll;
			m_bComplexSignal = pother->m_bComplexSignal;
			m_strComplexSignalName = pother->m_strComplexSignalName;
			m_uiComplexSignalRefId = pother->m_uiComplexSignalRefId;
			m_pRequireStatements = pother->m_pRequireStatements;
			m_pmapComplexSignals = pother->m_pmapComplexSignals;

			if ( 0 != pother->m_pReadDate )
			{
				try
				{
					m_pReadDate = new Atlas::AtlasString( *pother->m_pReadDate );
				}
				catch ( ... )
				{
					throw Exception( Exception::eFailedToCreateAtlasStringObject, __FILE__, __FUNCTION__, __LINE__, m_strVirtualLabel );
				}
			}

			if ( 0 != pother->m_pCNX )
			{
				try
				{
					m_pCNX = new CNX( *pother->m_pCNX );
				}
				catch ( ... )
				{
					throw Exception( Exception::eFailedToCreateCNXObject, __FILE__, __FUNCTION__, __LINE__, m_strVirtualLabel );
				}
			}

			if ( 0 != pother->m_pEvaluationStatement )
			{
				try
				{
					m_pEvaluationStatement = new Atlas::AtlasEvaluationStatement( *pother->m_pEvaluationStatement );
				}
				catch ( ... )
				{
					throw Exception( Exception::eFailedToCreateEvaluationStatementObject, __FILE__, __FUNCTION__, __LINE__, m_strVirtualLabel );
				}
			}

			if ( 0 != pother->m_pFromToEvent )
			{
				try
				{
					m_pFromToEvent = new Atlas::AtlasStatementCharacteristic( *pother->m_pFromToEvent );
				}
				catch ( ... )
				{
					throw Exception( Exception::eFailedToCreateAtlasCharacteristicObject, __FILE__, __FUNCTION__, __LINE__, m_strVirtualLabel );
				}
			}

			if ( 0 != pother->m_pGatedEvent )
			{
				try
				{
					m_pGatedEvent = new Atlas::AtlasStatementCharacteristic( *pother->m_pGatedEvent );
				}
				catch ( ... )
				{
					throw Exception( Exception::eFailedToCreateAtlasCharacteristicObject, __FILE__, __FUNCTION__, __LINE__, m_strVirtualLabel );
				}
			}

			if ( 0 != pother->m_pSyncEvent )
			{
				try
				{
					m_pSyncEvent = new Atlas::AtlasStatementCharacteristic( *pother->m_pSyncEvent );
				}
				catch ( ... )
				{
					throw Exception( Exception::eFailedToCreateAtlasCharacteristicObject, __FILE__, __FUNCTION__, __LINE__, m_strVirtualLabel );
				}
			}

			unsigned int uiSize = pother->m_vectMeasuredCharacteristic.size( );
			if ( uiSize > 0 )
			{
				for ( unsigned int ui = 0; ui < uiSize; ++ui )
				{
					const pair< Atlas::AtlasSignalComponent, Atlas::AtlasNumber* >& pr = pother->m_vectMeasuredCharacteristic[ ui ];

					Atlas::AtlasNumber* pVar = 0; 
						
					try
					{
						pVar = new Atlas::AtlasNumber( *( pr.second ) );
					}
					catch ( ... )
					{
						throw Exception( Exception::eFailedToCreateNumberObject, __FILE__, __FUNCTION__, __LINE__, m_strVirtualLabel );
					}

					m_vectMeasuredCharacteristic.push_back( make_pair( pr.first, pVar ) );
				}
			}

			uiSize = pother->m_vectAtlasNounMod.size( );
			if ( uiSize > 0 )
			{
				for ( unsigned int ui = 0; ui < uiSize; ++ui )
				{
					const pair< Atlas::AtlasSignalComponent, Atlas::AtlasStatementCharacteristic* >& pr = pother->m_vectAtlasNounMod[ ui ];

					Atlas::AtlasStatementCharacteristic* pAtlasCharacteristic = 0;
						
					try
					{
						pAtlasCharacteristic = new Atlas::AtlasStatementCharacteristic( *( pr.second ) );
					}
					catch ( ... )
					{
						throw Exception( Exception::eFailedToCreateAtlasCharacteristicObject, __FILE__, __FUNCTION__, __LINE__, m_strVirtualLabel );
					}

					m_vectAtlasNounMod.push_back( make_pair( pr.first, pAtlasCharacteristic ) );
				}
			}

			uiSize = pother->m_mapErrorLimits.size( );
			if ( uiSize > 0 )
			{
				map< unsigned int, Atlas::AtlasErrorLimit >::const_iterator it = pother->m_mapErrorLimits.begin( );
				const map< unsigned int, Atlas::AtlasErrorLimit >::const_iterator itEnd = pother->m_mapErrorLimits.end( );
				Atlas::AtlasErrorLimit errorLimit;
		
				while ( itEnd != it )
				{
					if ( it->second.IsLimit( ) )
					{
						errorLimit = it->second;

						m_mapErrorLimits.insert( make_pair( it->first, errorLimit ) );
					}
		
					++it;
				}
			}
		}
	}

	return *this;
}

void AtlasActionSignalVerb::Process( const Lookup* pLookup )
{
	if ( !m_bProcessed )
	{
		const unsigned int uiSize = m_vectAttributes.size( );
	
		if ( uiSize > 0 )
		{
			if ( ( 1 == uiSize ) && ( Atlas::eREMOVE == m_eAtlasStatement ) )
			{
				if ( m_strALL == m_vectAttributes[ 0 ]->m_strValue )
				{
					m_bRemoveAll = true;
				}
			}
			else
			{
				vector< const AtlasAttibuteValue* > cnx;
				bool bCalledPrimarySignal = false;
	
				for ( unsigned int ui = 0; ui < uiSize; ++ui )
				{
					if ( 0 == ui )
					{
						if ( m_strCOMPLEX == m_vectAttributes[ 0 ]->m_strValue )
						{
							if ( uiSize > 1 )
							{
								if ( m_strSIGNAL == m_vectAttributes[ 1 ]->m_strValue )
								{
									m_bComplexSignal = true;
									m_PrimarySignalComponent.SetAtlasNoun( Atlas::eComplexSignal );
								}
								#if ( _DEBUG ) && ( WIN32 )
								else
								{
									DebugBreak( );
								}
								#endif
							}

							if ( m_bComplexSignal )
							{
								if ( uiSize > 2 )
								{
									m_strComplexSignalName = m_vectAttributes[ 2 ]->m_strValue;
	
									ui += 3;
	
									if ( ui >= uiSize )
									{
										break;
									}
								}
							}
							else
							{
								ui += 2;

								if ( ui >= uiSize )
								{
									break;
								}
							}
						}
					}

					if ( m_bHasMeasureCharacteristics && ( 0 == ui ) )
					{
						try
						{
							GetMeasuredCharacteristics( ui );
	
							if ( 0 == m_vectMeasuredCharacteristic.size( ) )
							{
								if ( 0 == ui )
								{
									if ( !m_bComplexSignal )
									{
										SetPrimarySignal( ui, pLookup );
										bCalledPrimarySignal = true;
									}
								}
							}
						}
						catch( const Exception& excp )
						{
							if ( Atlas::eREAD == m_eAtlasStatement )
							{
								if ( string::npos != excp.m_strErrorText.find( m_strDATE ) )
								{
									GetDateVariable( );
		
									break;
								}
							}
	
							throw excp;
						}
					}
					else if ( !m_PrimarySignalComponent.IsValid( ) && !m_bComplexSignal && !bCalledPrimarySignal )
					{
						SetPrimarySignal( ui, pLookup );
						bCalledPrimarySignal = true;
					}
					else if ( ( Atlas::eVERIFY == m_eAtlasStatement ) && ( 0 == m_pEvaluationStatement ) )
					{
						m_pEvaluationStatement = NounModifier::GetAtlasEvaluationField( m_strVirtualLabel, m_vectAttributes, ui, false );
	
						if ( 0 == m_pEvaluationStatement )
						{
							throw Exception( Exception::eFailedToCreateEvaluationStatementObject, __FILE__, __FUNCTION__, __LINE__, m_strVirtualLabel );
						}

						GetVariables( m_pEvaluationStatement );
					}
					else
					{
						ProcessAdditionalStatementConfiguration( uiSize, ui, cnx );
					}
				}
	
				if ( cnx.size( ) > 0 )
				{
					ProcessCNXConfiguration( cnx, pLookup );
				}
	
				if ( m_vectAtlasNounMod.size( ) > 0 )
				{
					if ( Atlas::eVideoSignal != m_PrimarySignalComponent.GetAtlasNoun( ) )
					{
						sort( m_vectAtlasNounMod.begin( ), m_vectAtlasNounMod.end( ), Compare( ) );
					}
				}
			}
		}

		m_bProcessed = true;
	}

	InitSignalComponents( );
}

void AtlasActionSignalVerb::ProcessAdditionalStatementConfiguration( const unsigned int uiSize, unsigned int& ui, vector< const AtlasAttibuteValue* >& cnx )
{
	const string& strWord = m_vectAttributes[ ui ]->m_strValue;
	
	if ( ui < uiSize )
	{
		if ( ( m_strCNX == strWord ) || ( cnx.size( ) > 0 ) )
		{
			AtlasAttibuteValue* pAtlasAttibuteValue = 0;

			try
			{
				pAtlasAttibuteValue = new AtlasAttibuteValue( *( m_vectAttributes[ ui ] ) );
			}
			catch ( ... )
			{
				throw Exception( Exception::eFailedToCreateAttributeValueObject, __FILE__, __FUNCTION__, __LINE__, m_strVirtualLabel );
			}
	
			cnx.push_back( pAtlasAttibuteValue );
		}
		else
		{
			Atlas::AtlasSignalComponent AtlasNM( Atlas::GetAtlasNounModifierEnum( strWord ) );
	
			if ( !AtlasNM.IsValid( ) )
			{
				if ( m_strFROM == strWord )
				{
					#if ( _DEBUG ) && ( WIN32 )
					if ( 0 != m_pFromToEvent )
					{
						DebugBreak( );
					}
					#endif
	
					m_pFromToEvent = NounModifier::GetAtlasCharacteristic( m_strVirtualLabel, m_vectAttributes, ui, false );
	
					return;
				}
				else
				{
					string strError( m_strVirtualLabel );
					
					strError += ": Atlas noun/modifier: ";
					strError += m_vectAttributes[ ui ]->m_strValue;
			
					throw Exception( Exception::eUnknownAtlasNounModifier, __FILE__, __FUNCTION__, __LINE__, strError );
				}
			}
	
			AtlasNM.SetAtlasNoun( m_PrimarySignalComponent.GetAtlasNoun( ) );
	
			++ui;
	
			if ( ui < uiSize )
			{
				Atlas::AtlasStatementCharacteristic* pCharacteristic = NounModifier::GetAtlasCharacteristic( m_strVirtualLabel, m_vectAttributes, ui, false );
	
				if ( 0 == pCharacteristic )
				{
					switch ( AtlasNM.GetAtlasNounModifier( ) )
					{
						case Atlas::eREF_SOURCE:
						{
							Atlas::eAtlasFunction eFunction = Atlas::GetAtlasFunctionEnum( m_vectAttributes[ ui ]->m_strValue );

							if ( Atlas::eUnknownAtlasFunction == eFunction )
							{
								string strError( m_strId );
				
								strError += ": ";
								strError += m_vectAttributes[ ui ]->m_strValue;
				
								throw Exception( Exception::eUnknownAtlasFunction, __FILE__, __FUNCTION__, __LINE__, strError );
							}

							AtlasNM.SetAtlasFunction( eFunction );

							m_vectAtlasNounMod.push_back( make_pair( AtlasNM, pCharacteristic ) );
						}
						break;

						default:
						{
							m_vectAtlasNounMod.push_back( make_pair( AtlasNM, pCharacteristic ) );
							--ui;
						}
						break;
					}
				}
				else
				{
					switch ( AtlasNM.GetAtlasNounModifier( ) )
					{
						//case Atlas::eREF_SOURCE
						//	m_vectAtlasNounMod.push_back( make_pair( AtlasNM, pCharacteristic ) );
						//	GetVariables( pCharacteristic );
						//	break;

						case Atlas::eGATED:
							#if ( _DEBUG ) && ( WIN32 )
							if ( 0 != m_pGatedEvent )
							{
								DebugBreak( );
							}
							#endif
							m_pGatedEvent = pCharacteristic;
							m_pGatedEvent->SetGated( true );
							break;
	
						case Atlas::eSYNC:
							#if ( _DEBUG ) && ( WIN32 )
							if ( 0 != m_pSyncEvent )
							{
								DebugBreak( );
							}
							#endif
							m_pSyncEvent = pCharacteristic;
							m_pSyncEvent->SetSync( true );
							break;
	
						default:
							m_vectAtlasNounMod.push_back( make_pair( AtlasNM, pCharacteristic ) );
							GetVariables( pCharacteristic );
							break;
					}
				}
			}
		}
	}
}

void AtlasActionSignalVerb::ProcessCNXConfiguration( const vector< const AtlasAttibuteValue* >& cnx, const Lookup* pLookup )
{
	try
	{
		m_pCNX = new CNX( false );
	}
	catch ( ... )
	{
		throw Exception( Exception::eFailedToCreateCNXObject, __FILE__, __FUNCTION__, __LINE__, m_strVirtualLabel );
	}
	
	m_pCNX->SetAttributes( cnx, true );
	m_pCNX->m_eNoun = m_PrimarySignalComponent.GetAtlasNoun( );
	m_pCNX->m_strSystemName = m_strSystemName;
	
	m_pCNX->Process( pLookup );
}

void AtlasActionSignalVerb::GetVariables( Atlas::AtlasStatementCharacteristic* pStatementCharacteristic )
{
	if ( 0 != pStatementCharacteristic )
	{
		Atlas::AtlasNumber* pNumber = pStatementCharacteristic->GetNumber( );
		Atlas::AtlasRange* pRange = pStatementCharacteristic->GetRange( );
		Atlas::AtlasErrorLimit* pErrorLimit = pStatementCharacteristic->GetErrorLimit( );
		Atlas::AtlasNumber* pStartNumber = pStatementCharacteristic->GetStartNumber( );
		Atlas::AtlasNumber* pEndNumber = pStatementCharacteristic->GetEndNumber( );

		if ( 0 != pNumber )
		{
			if ( pNumber->IsVariableName( ) )
			{
				m_multimapVariables.insert( make_pair( pNumber->GetVariableName( ), pNumber ) );
			}
		}

		if ( 0 != pRange )
		{
			Atlas::AtlasNumber* pRange1 = pRange->GetRange1( );
			Atlas::AtlasNumber* pRange2 = pRange->GetRange2( );
			Atlas::AtlasNumber* bRangeBy = pRange->GetByValue( );

			if ( 0 != pRange1 )
			{
				if ( pRange1->IsVariableName( ) )
				{
					m_multimapVariables.insert( make_pair( pRange1->GetVariableName( ), pRange1 ) );
				}
			}

			if ( 0 != pRange2 )
			{
				if ( pRange2->IsVariableName( ) )
				{
					m_multimapVariables.insert( make_pair( pRange2->GetVariableName( ), pRange2 ) );
				}
			}

			if ( 0 != bRangeBy )
			{
				if ( bRangeBy->IsVariableName( ) )
				{
					m_multimapVariables.insert( make_pair( bRangeBy->GetVariableName( ), bRangeBy ) );
				}
			}
		}

		AtlasStatement::GetVariables( pErrorLimit );

		if ( 0 != pStartNumber )
		{
			if ( pStartNumber->IsVariableName( ) )
			{
				m_multimapVariables.insert( make_pair( pStartNumber->GetVariableName( ), pStartNumber ) );
			}
		}

		if ( 0 != pEndNumber )
		{
			if ( pEndNumber->IsVariableName( ) )
			{
				m_multimapVariables.insert( make_pair( pEndNumber->GetVariableName( ), pEndNumber ) );
			}
		}
	}
}

void AtlasStatement::GetVariables( Atlas::AtlasErrorLimit* pErrorLimit )
{
	if ( 0 != pErrorLimit )
	{
		Atlas::AtlasNumber* pLimit1 = pErrorLimit->GetLimit1( );
		Atlas::AtlasNumber* pLimit2 = pErrorLimit->GetLimit2( );

		if ( 0 != pLimit1 )
		{
			if ( pLimit1->IsVariableName( ) )
			{
				m_multimapVariables.insert( make_pair( pLimit1->GetVariableName( ), pLimit1 ) );
			}
		}

		if ( 0 != pLimit2 )
		{
			if ( pLimit2->IsVariableName( ) )
			{
				m_multimapVariables.insert( make_pair( pLimit2->GetVariableName( ), pLimit2 ) );
			}
		}
	}
}

void AtlasActionSignalVerb::GetVariables( Atlas::AtlasEvaluationStatement* pEvaluationStatement )
{
	if ( 0 != pEvaluationStatement )
	{
		pair< Atlas::eEvaluationFieldType, Atlas::AtlasNumber >* pField1 = pEvaluationStatement->GetField1( );
		pair< Atlas::eEvaluationFieldType, Atlas::AtlasNumber >* pField2 = pEvaluationStatement->GetField2( ); 
		pair< Atlas::eEvaluationFieldType, Atlas::AtlasNumber >* pField3 = pEvaluationStatement->GetField3( );

		if ( 0 != pField1 )
		{
			if ( pField1->second.IsVariableName( ) )
			{
				m_multimapVariables.insert( make_pair( pField1->second.GetVariableName( ), &( pField1->second ) ) );
			}
		}

		if ( 0 != pField2 )
		{
			if ( pField2->second.IsVariableName( ) )
			{
				m_multimapVariables.insert( make_pair( pField2->second.GetVariableName( ), &( pField2->second ) ) );
			}
		}

		if ( 0 != pField3 )
		{
			if ( pField3->second.IsVariableName( ) )
			{
				m_multimapVariables.insert( make_pair( pField3->second.GetVariableName( ), &( pField3->second ) ) );
			}
		}
	}
}

void AtlasActionSignalVerb::ToXML( string& strXML, const string& strAddtionalTopLevelAttributes ) const
{
	const string strId( 0 == m_uiId ? string( ) : XML::MakeXmlAttributeNameValue( XML::anId, m_uiId ) );
	const string strCommentRefId( GetStatementCommentRefId_XML( ) );
	unsigned int uiFields = Atlas::AtlasSourceStatement::eXmlFilename;
	
	uiFields |= Atlas::AtlasSourceStatement::eXmlStatementNumber;
	uiFields |= Atlas::AtlasSourceStatement::eXmlLineNumber;
	uiFields |= Atlas::AtlasSourceStatement::eXmlSourceType;
	uiFields |= Atlas::AtlasSourceStatement::eXmlProcname;

	if ( m_bRemoveAll )
	{
		strXML += XML::MakeOpenXmlElementWithChildren( m_eVerbElementName, strAddtionalTopLevelAttributes, XML::MakeXmlAttributeNameValue( XML::anAll, XML::avTrue ), strId, strCommentRefId );

		const unsigned int uiSourceStatments = m_vectAtlasSourceStatement.size( );
		if ( uiSourceStatments > 0 )
		{
			strXML += m_vectAtlasSourceStatement[ 0 ].ToXML( uiFields  );
		}

		strXML += XML::MakeCloseXmlElementWithChildren( m_eVerbElementName );
	}
	else if ( 0 != m_pReadDate )
	{
		strXML += XML::MakeOpenXmlElementWithChildren( XML::enReadDateTime, strAddtionalTopLevelAttributes, strId, strCommentRefId ); 

		const unsigned int uiSourceStatments = m_vectAtlasSourceStatement.size( );
		if ( uiSourceStatments > 0 )
		{
			strXML += m_vectAtlasSourceStatement[ 0 ].ToXML( uiFields );
		}

		strXML += XML::MakeXmlElementNoChildren( XML::enDatetime, m_pReadDate->ToXML( ) );

		strXML += XML::MakeCloseXmlElementWithChildren( XML::enReadDateTime );
	}
	else
	{
		if ( Atlas::eShort == m_PrimarySignalComponent.GetAtlasNoun( ) )
		{
			strXML += XML::MakeOpenXmlElementWithChildren( m_eVerbElementName, strAddtionalTopLevelAttributes, strId, strCommentRefId );
		}
		else
		{
			string strVirtualLabel;
			string strSystemName;
			string strClass;
			string strClassDescription;

			if ( !m_strVirtualLabel.empty( ) )
			{
				strVirtualLabel = XML::MakeXmlAttributeNameValue( XML::anVirtualLabel, m_strVirtualLabel );
			}

			if ( !m_strSystemName.empty( ) )
			{
				strSystemName = XML::MakeXmlAttributeNameValue( XML::anSystemName, m_strSystemName );
			}

			if ( SpecificInstrument::eUnknownInstrument != m_eInstrument )
			{
				strClass = XML::MakeXmlAttributeNameValue( XML::anClass, SpecificInstrument::GetInstrumentClass( SpecificInstrument::GetInstrumentClass( m_eInstrument ) ) );
				strClassDescription = XML::MakeXmlAttributeNameValue( XML::anClassDescription, SpecificInstrument::GetInstrumentClassDescription( SpecificInstrument::GetInstrumentClass( m_eInstrument ) ) );
			}

			strXML += XML::MakeOpenXmlElementWithChildren( m_eVerbElementName, 
				strAddtionalTopLevelAttributes,
				strVirtualLabel,
				strSystemName, 
				strClass,
				strClassDescription,
				strId,
				strCommentRefId );
		}
	
		const unsigned int uiSourceStatments = m_vectAtlasSourceStatement.size( );
		if ( uiSourceStatments > 0 )
		{
			strXML += m_vectAtlasSourceStatement[ 0 ].ToXML( uiFields );
		}
		
		if ( m_bComplexSignal )
		{
			strXML += XML::MakeXmlElementNoChildren( XML::enSignalComponent, XML::MakeXmlAttributeNameValue( XML::anComplexSignal, XML::avTrue ), XML::MakeXmlAttributeNameValue( XML::anRefId, m_uiComplexSignalRefId ) );
		}
		else
		{
			strXML += m_PrimarySignalComponent.ToXML( );
		}

		if ( 0 != m_pEvaluationStatement )
		{
			strXML += m_pEvaluationStatement->ToXML( );
		}

		unsigned int uiSize = m_vectMeasuredCharacteristic.size( );
		if ( uiSize > 0 )
		{
			const string strVariableAttr( XML::MakeXmlAttributeNameValue( XML::anVariable, XML::avTrue ) );
			const map< unsigned int, Atlas::AtlasErrorLimit >::const_iterator itEnd = m_mapErrorLimits.end( );
			map< unsigned int, Atlas::AtlasErrorLimit >::const_iterator it;
			const unsigned int uiErrorLimits = m_mapErrorLimits.size( );
	
			strXML += XML::MakeOpenXmlElementWithChildren( XML::enMeasuredCharacteristics );
	
			strXML += XML::MakeOpenXmlElementWithChildren( XML::enNounModifiers, XML::MakeXmlAttributeNameValue( XML::anCount, uiSize ) );
	
			for ( unsigned int ui = 0; ui < uiSize; ++ui )
			{
				strXML += XML::MakeOpenXmlElementWithChildren( XML::enNounModifier );
	
				const pair< Atlas::AtlasSignalComponent, Atlas::AtlasNumber* >& pr = m_vectMeasuredCharacteristic[ ui ];
	
				strXML += pr.first.ToXML( );
	
				if ( 0 != pr.second )
				{
					strXML += XML::MakeXmlElementNoChildren( XML::enMeasuredCharacteristic, pr.second->ToXML( ) );
				}
	
				if ( uiErrorLimits > 0 )
				{
					it = m_mapErrorLimits.find( ui );
		
					if ( itEnd != it )
					{
						strXML += it->second.ToXML( );
					}
				}
	
				strXML += XML::MakeCloseXmlElementWithChildren( XML::enNounModifier );
			}
	
			strXML += XML::MakeCloseXmlElementWithChildren( XML::enNounModifiers );
			strXML += XML::MakeCloseXmlElementWithChildren( XML::enMeasuredCharacteristics );
		}
		
		uiSize = m_vectAtlasNounMod.size( );
		if ( uiSize > 0 )
		{
			if ( Atlas::eVideoSignal != m_PrimarySignalComponent.GetAtlasNoun( ) )
			{
				strXML += XML::MakeOpenXmlElementWithChildren( XML::enNounModifiers, XML::MakeXmlAttributeNameValue( XML::anCount, uiSize ) );
		
				for ( unsigned int ui = 0; ui < uiSize; ++ui )
				{
					strXML += XML::MakeOpenXmlElementWithChildren( XML::enNounModifier );
	
					const pair< Atlas::AtlasSignalComponent, Atlas::AtlasStatementCharacteristic* >& pr = m_vectAtlasNounMod[ ui ];
	
					strXML += pr.first.ToXML( );
	
					if ( 0 != pr.second )
					{
						pr.second->ToXML( strXML );
					}
	
					strXML += XML::MakeCloseXmlElementWithChildren( XML::enNounModifier );
				}
	
				strXML += XML::MakeCloseXmlElementWithChildren( XML::enNounModifiers );
			}
			else
			{
				static set< Atlas::eAtlasNounModifier > setVideo;
				static set< Atlas::eAtlasNounModifier >::const_iterator itEnd;
	
				if ( 0 == setVideo.size( ) )
				{
					setVideo.insert( Atlas::eHORIZONTAL_TIMING );
					setVideo.insert( Atlas::eVERTICAL_TIMING );
					setVideo.insert( Atlas::eSYNC );
					setVideo.insert( Atlas::eSYNC_POLARITY );
					setVideo.insert( Atlas::eVIDEO );
					setVideo.insert( Atlas::eIMAGE );
					setVideo.insert( Atlas::eDRAW );
	
					itEnd = setVideo.end( );
				}
	
				vector< pair< unsigned int, vector< unsigned int > > > vectVideoSignal;
	
				for ( unsigned int ui = 0; ui < uiSize; ++ui )
				{
					const pair< Atlas::AtlasSignalComponent, Atlas::AtlasStatementCharacteristic* >& pr = m_vectAtlasNounMod[ ui ];
	
					vectVideoSignal.push_back( make_pair( ui, vector< unsigned int >( ) ) );
	
					if ( itEnd != setVideo.find( pr.first.GetAtlasNounModifier( ) ) )
					{
						pair< unsigned int, vector< unsigned int > >& pr2 = vectVideoSignal.back( );
	
						for ( ++ui; ui < uiSize; ++ui )
						{
							const pair< Atlas::AtlasSignalComponent, Atlas::AtlasStatementCharacteristic* >& pr3 = m_vectAtlasNounMod[ ui ];
	
							if ( itEnd != setVideo.find( pr3.first.GetAtlasNounModifier( ) ) )
							{
								--ui;
								break;
							}
	
							pr2.second.push_back( ui );
						}
					}
				}
	
				const unsigned int uiIndex = vectVideoSignal.size( );
	
				if ( uiIndex > 0 )
				{
					strXML += XML::MakeOpenXmlElementWithChildren( XML::enNounModifiers, XML::MakeXmlAttributeNameValue( XML::anCount, uiIndex ) );
	
					for ( unsigned int ui = 0; ui < uiIndex; ++ui )
					{
						const pair< unsigned int, vector< unsigned int > >& pr = vectVideoSignal[ ui ];
	
						const unsigned int uiAttributes = pr.second.size( );
	
						if ( 0 == uiAttributes )
						{
							strXML += XML::MakeOpenXmlElementWithChildren( XML::enNounModifier );
			
							const pair< Atlas::AtlasSignalComponent, Atlas::AtlasStatementCharacteristic* >& pr2 = m_vectAtlasNounMod[ pr.first ];
			
							strXML += pr2.first.ToXML( );
			
							if ( 0 != pr2.second )
							{
								pr2.second->ToXML( strXML );
							}
			
							strXML += XML::MakeCloseXmlElementWithChildren( XML::enNounModifier );
						}
						else
						{
							const pair< Atlas::AtlasSignalComponent, Atlas::AtlasStatementCharacteristic* >& pr2 = m_vectAtlasNounMod[ pr.first ];
							const string strNounModElement( AIXMLHelper::SearchAndReplace< string >( AIXMLHelper::ToLower( pr2.first.GetAtlasNounModifierAsString( ) ), m_strDash, m_strUnderscore ) );
							const XML::ElementName eElementName = XML::GetElementNameEnum( strNounModElement );
	
							strXML += XML::MakeOpenXmlElementWithChildren( eElementName );
	
							strXML += pr2.first.ToXML( );
	
							strXML += XML::MakeOpenXmlElementWithChildren( XML::enNounModifiers, XML::MakeXmlAttributeNameValue( XML::anCount, uiAttributes ) );
							
							for ( unsigned int ui2 = 0; ui2 < uiAttributes; ++ui2 )
							{
								strXML += XML::MakeOpenXmlElementWithChildren( XML::enNounModifier );
				
								const pair< Atlas::AtlasSignalComponent, Atlas::AtlasStatementCharacteristic* >& pr3 = m_vectAtlasNounMod[ pr.second[ ui2 ] ];
				
								strXML += pr3.first.ToXML( );
				
								if ( 0 != pr3.second )
								{
									pr3.second->ToXML( strXML );
								}
				
								strXML += XML::MakeCloseXmlElementWithChildren( XML::enNounModifier );
							}
	
							strXML += XML::MakeCloseXmlElementWithChildren( XML::enNounModifiers );
	
							strXML += XML::MakeCloseXmlElementWithChildren( eElementName );
						}
					}
	
					strXML += XML::MakeCloseXmlElementWithChildren( XML::enNounModifiers );
				}
			}
		}

		if ( 0 != m_pSyncEvent )
		{
			m_pSyncEvent->ToXML( strXML );
		}

		if ( 0 != m_pGatedEvent )
		{
			m_pGatedEvent->ToXML( strXML );
		}
	
		if ( 0 != m_pFromToEvent )
		{
			m_pFromToEvent->ToXML( strXML );
		}
		
		if ( 0 != m_pCNX )
		{
			m_pCNX->ToXML( strXML );
		}
		
		strXML += XML::MakeCloseXmlElementWithChildren( m_eVerbElementName );
	}
}

void AtlasActionSignalVerb::InitSignalComponents( void )
{
	const AtlasRequire* pRequire = 0;

	if ( ( 0 == m_pReadDate ) && !m_bRemoveAll )
	{
		const Atlas::eAtlasNoun& eNoun = m_PrimarySignalComponent.GetAtlasNoun( );

		if ( ( Atlas::eShort != eNoun ) && ( Atlas::eComplexSignal != eNoun ) )
		{
			if ( 0 != m_pRequireStatements )
			{
				pRequire = m_pRequireStatements->GetRequire( m_strVirtualLabel );
			}

			if ( 0 == pRequire )
			{
				throw Exception( Exception::eCannotFindRequireForVirtualLabel, __FILE__, __FUNCTION__, __LINE__, m_strVirtualLabel );
			}
		}
	}

	m_PrimarySignalComponent.Set1641( );

	if ( 0 != m_pCNX )
	{
		m_pCNX->InitSignalComponents( );
	}

	unsigned int uiSize = m_vectMeasuredCharacteristic.size( );
	if ( uiSize > 0 )
	{
		for ( unsigned int ui = 0; ui < uiSize; ++ui )
		{
			Atlas::AtlasSignalComponent& sigComp = m_vectMeasuredCharacteristic[ ui ].first;

			sigComp.SetAtlasNoun( m_PrimarySignalComponent.GetAtlasNoun( ) );
			sigComp.Set1641( );
			SetCompResouce_Require( &sigComp, pRequire );
		}
	}

	uiSize = m_vectAtlasNounMod.size( );
	if ( uiSize > 0 )
	{
		for ( unsigned int ui = 0; ui < uiSize; ++ui )
		{
			Atlas::AtlasSignalComponent& sigComp = m_vectAtlasNounMod[ ui ].first;

			sigComp.Set1641( );
			SetCompResouce_Require( &sigComp, pRequire );
		}
	}
}

void AtlasActionSignalVerb::SetCompResouce_Require( Atlas::AtlasSignalComponent* psigComp, const AtlasRequire* pRequire )
{
	if ( ( 0 != pRequire ) && ( 0 != psigComp ) )
	{
		if ( 0 != pRequire->m_pResource )
		{
			psigComp->SetAtlasNounResource( pRequire->m_pResource->GetAtlasResource( ) );
			m_PrimarySignalComponent.SetAtlasNounResource( pRequire->m_pResource->GetAtlasResource( ) );
		}

		if ( 0 != pRequire->m_pControl )
		{
			if ( pRequire->m_pControl->HasNounModifier( psigComp->GetAtlasNounModifier( ) ) )
			{
				psigComp->SetAtlasNounModifierRequire( Atlas::eAtlasRequireControl );
			}
		}

		if ( 0 != pRequire->m_pCapability )
		{
			if ( pRequire->m_pCapability->HasNounModifier( psigComp->GetAtlasNounModifier( ) ) )
			{
				psigComp->SetAtlasNounModifierRequire( Atlas::eAtlasRequireCapability );
			}
		}

		if ( 0 != pRequire->m_pLimit )
		{
			if ( pRequire->m_pLimit->HasNounModifier( psigComp->GetAtlasNounModifier( ) ) )
			{
				psigComp->SetAtlasNounModifierRequire( Atlas::eAtlasRequireLimit );
			}
		}

		#if ( _DEBUG ) && ( WIN32 )
		if ( Atlas::eUnknownAtlasResource == psigComp->GetAtlasNounResource( ) )
		{
			DebugBreak( );
		}
		if ( 0 == psigComp->GetAtlasNounModifierRequire( ).size( ) )
		{
			//DebugBreak( );
		}
		#endif
	}
	else if ( 0 != pRequire )
	{
		if ( 0 != pRequire->m_pResource )
		{
			m_PrimarySignalComponent.SetAtlasNounResource( pRequire->m_pResource->GetAtlasResource( ) );
		}
	}

	#if ( _DEBUG ) && ( WIN32 )
	if ( Atlas::eUnknownAtlasResource == m_PrimarySignalComponent.GetAtlasNounResource( ) )
	{
		DebugBreak( );
	}
	#endif
}

void AtlasActionSignalVerb::InitSignalInfo( AtlasSignalInfo* pInformation )
{
	if ( 0 != pInformation )
	{
		if ( !m_bComplexSignal && m_PrimarySignalComponent.IsValid( ) )
		{
			pInformation->SetSignal( m_PrimarySignalComponent.GetAtlasNoun( ), m_eAtlasStatement );
	
			const unsigned int uiSize = m_vectAtlasNounMod.size( );
			if ( uiSize > 0 )
			{
				for ( unsigned int ui = 0; ui < uiSize; ++ui )
				{
					pInformation->SetComponent( m_vectAtlasNounMod[ ui ].first );
				}
			}
		}
		else if ( m_bComplexSignal )
		{
			if ( !m_strComplexSignalName.empty( ) )
			{
				m_uiComplexSignalRefId = pInformation->SetComplexSignal( m_strComplexSignalName, GetStatementFilename( ), m_eAtlasStatement );
			}
			#if ( _DEBUG ) && ( WIN32 )
			else
			{
				DebugBreak( );
			}
			#endif
		}
	}
}

void AtlasActionSignalVerb::GetDateVariable( void )
{
	if ( 6 != m_vectAttributes.size( ) )
	{
		throw Exception( Exception::eUnexpectedREAD_DateConfiguration, __FILE__, __FUNCTION__, __LINE__, m_strVirtualLabel );
	}

	m_eAtlasStatement = Atlas::eREAD_DATETIME;

	try
	{
		m_pReadDate = new Atlas::AtlasString;
	}
	catch ( ... )
	{
		throw Exception( Exception::eFailedToCreateAtlasStringObject, __FILE__, __FUNCTION__, __LINE__, m_strVirtualLabel );
	}

	m_pReadDate->SetVariableName( m_vectAttributes[ 2 ]->m_strValue );

	m_multimapVariables.insert( make_pair( m_pReadDate->GetVariableName( ), m_pReadDate ) );

	if ( m_vectAtlasSourceStatement.size( ) > 0 )
	{
		m_vectAtlasSourceStatement[ 0 ].SetAtlasStatement( Atlas::eREAD_DATETIME );
	}
}

void AtlasActionSignalVerb::SetPrimarySignal( unsigned int& uiPos, const Lookup* pLookup )
{
	const unsigned int uiSize = m_vectAttributes.size( );
	const unsigned int uiStartPos = uiPos;
	string strSignalName;

	for ( ; uiPos < uiSize; ++uiPos )
	{
		if ( ( 0 == uiPos ) && ( m_strSHORT == m_vectAttributes[ uiPos ]->m_strValue ) )
		{
			Atlas::eAtlasNoun eNoun = Atlas::GetAtlasNounEnum( m_vectAttributes[ uiPos ]->m_strValue );
	
			if ( Atlas::eUnknownAtlasNoun == eNoun )
			{
				throw Exception( Exception::eUnknownAtlasNoun, __FILE__, __FUNCTION__, __LINE__, strSignalName );
			}
	
			m_PrimarySignalComponent.SetAtlasNoun( eNoun );
	
			m_strSystemName = Atlas::GetAtlasNoun( Atlas::eShort );
		}
		else if ( m_strUSING == m_vectAttributes[ uiPos ]->m_strValue )
		{
			Atlas::eAtlasNoun eNoun = Atlas::GetAtlasNounEnum( strSignalName );
	
			if ( Atlas::eUnknownAtlasNoun == eNoun )
			{
				throw Exception( Exception::eUnknownAtlasNoun, __FILE__, __FUNCTION__, __LINE__, strSignalName );
			}
	
			m_PrimarySignalComponent.SetAtlasNoun( eNoun );
	
			++uiPos;
	
			if ( uiPos < m_vectAttributes.size( ) )
			{
				m_strVirtualLabel = m_vectAttributes[ uiPos ]->m_strValue;
	
				#ifdef CASS
					m_eInstrument = pLookup->GetInstrumentEnum( m_strVirtualLabel, false );
					m_strSystemName = pLookup->GetSystemName( m_strVirtualLabel, false );
				#else
					SpecificInstrument::eInstrument eInstrumentType = SpecificInstrument::GetInstrument( m_strVirtualLabel, false );
					m_strSystemName = m_strVirtualLabel;
				#endif
			}
		}
		else
		{
			if ( !strSignalName.empty( ) )
			{
				strSignalName += " ";
			}
	
			strSignalName += m_vectAttributes[ uiPos ]->m_strValue;
		}

		if ( m_PrimarySignalComponent.IsValid( ) )
		{
			break;
		}
	}

	if ( !m_PrimarySignalComponent.IsValid( ) )
	{
		uiPos = uiStartPos;
	}
}

void AtlasActionSignalVerb::InitFromXML( const StatementMetadata* pData )
{
	if ( 0 != pData )
	{
		if ( 0 != pData->m_pStatement )
		{
			string strAIXMLtagName;
	
			m_uiConditionalStatementsId = pData->m_uiParentConditionalStatementsId;
	
			SetSourceStatementInfo( pData->m_pStatement, pData->m_eSourceType, pData->m_strFilename, pData->m_strParentProcedureName, pData->m_uiParentProcedureId );
	
			const xercesc::DOMElement* pStatement = pData->m_pStatement->getFirstElementChild( );
	
			AIXMLHelper::GetXercesString( pStatement->getTagName( ), strAIXMLtagName );
	
			if ( AIXML::m_arrayXMLKeyWords[ AIXML::eArgumentsElement ] == strAIXMLtagName )
			{
				pStatement = pStatement->getFirstElementChild( );
	
				while ( 0 != pStatement )
				{
					AtlasStatement::InitFromXML( pStatement );
	
					pStatement = pStatement->getNextElementSibling( );
				}
			}
		}
	}
}

void AtlasActionSignalVerb::GetMeasuredCharacteristics( unsigned int& uiPos )
{
	const unsigned int uiSize = m_vectAttributes.size( );
	Atlas::AtlasErrorLimit errorLimit;

	for ( ; uiPos < uiSize; ++uiPos )
	{
		if ( m_vectAttributes[ uiPos ]->IsDimension( ) )
		{
			const Atlas::AtlasSignalComponent AtlasNM( Atlas::GetAtlasNounModifierEnum( m_vectAttributes[ uiPos ]->m_strValue ) );

			if ( !AtlasNM.IsValid( ) )
			{
				string strError( m_strVirtualLabel );
					
				strError += ": Atlas noun/modifier: ";
				strError += m_vectAttributes[ uiPos ]->m_strValue;
		
				throw Exception( Exception::eUnknownAtlasNounModifier, __FILE__, __FUNCTION__, __LINE__, strError );
			}

			++uiPos;

			const unsigned int uiLastPos = uiPos;

			if ( uiPos < uiSize )
			{
				if ( m_strERRLMT == m_vectAttributes[ uiPos ]->m_strValue )
				{
					++uiPos;

					errorLimit = NounModifier::GetAtlasErrorLimit( m_strVirtualLabel, m_vectAttributes, uiPos, true );

					#if ( _DEBUG ) && ( WIN32 )
					if ( !errorLimit.IsLimit( ) )
					{
						DebugBreak( );
					}
					#endif
				}
			}

			if ( uiPos < uiSize )
			{
				if ( m_strINTO == m_vectAttributes[ uiPos ]->m_strValue )
				{
					++uiPos;

					string strVarName;
	
					if ( uiPos < uiSize )
					{
						strVarName = m_vectAttributes[ uiPos ]->m_strValue;

						Atlas::AtlasNumber* pVar = 0;
							
						try
						{
							pVar = new Atlas::AtlasNumber;
						}
						catch ( ... )
						{
							throw Exception( Exception::eFailedToCreateNumberObject, __FILE__, __FUNCTION__, __LINE__, m_strVirtualLabel );
						}

						pVar->SetVariableName( m_vectAttributes[ uiPos ]->m_strValue );

						m_vectMeasuredCharacteristic.push_back( make_pair( AtlasNM, pVar ) );

						m_multimapVariables.insert( make_pair( pVar->GetVariableName( ), pVar ) );

						if ( errorLimit.IsLimit( ) )
						{
							AtlasStatement::GetVariables( &errorLimit );

							m_mapErrorLimits.insert( make_pair( ( m_vectMeasuredCharacteristic.size( ) - 1 ), errorLimit ) );
						}
					}
				}
				else
				{
					m_vectMeasuredCharacteristic.push_back( make_pair( AtlasNM, ( Atlas::AtlasNumber* ) 0 ) );

					if ( errorLimit.IsLimit( ) )
					{
						AtlasStatement::GetVariables( &errorLimit );

						m_mapErrorLimits.insert( make_pair( ( m_vectMeasuredCharacteristic.size( ) - 1 ), errorLimit ) );
					}

					--uiPos;
				}
			}

			if ( uiLastPos == uiPos )
			{
				--uiPos;
			}
		}
		else
		{
			if ( uiPos > 0 )
			{
				--uiPos;
			}

			break;
		}
	}
}

AtlasStatement& AtlasStatementContainer::operator = ( const AtlasStatement& other )
{
	if ( this != &other )
	{
		AtlasStatement::operator = ( other );

		GarbageCollect( );

		const AtlasStatementContainer* pother = dynamic_cast< const AtlasStatementContainer* >( &other );

		if ( 0 != pother )
		{
			m_mapStatements = pother->m_mapStatements;
			m_pStatementsElement = pother->m_pStatementsElement;
			m_uiStatementsId = pother->m_uiStatementsId;
		}
	}

	return *this;
}

void AtlasStatementContainer::InsertStatement( AtlasStatement* pStatement )
{
	const multimap< unsigned int, AtlasStatement* >::const_iterator itEnd = m_mapStatements.end( );
	bool bElse = false;

	if ( 0 == pStatement->m_uiConditionalStatementsId )
	{
		AtlasCondition* pCondition = dynamic_cast< AtlasCondition* >( pStatement );
		unsigned int uiId = pStatement->m_uiId;

		AddTestNumber( pStatement ); 

		if ( m_uiId != uiId )
		{
			if ( 0 != pCondition )
			{
				if ( 0 != pCondition->m_uiStatementsId )
				{
					if ( 0 != pCondition->m_uiStatementsId )
					{
						uiId = pCondition->m_uiStatementsId;
					}

					bElse = ( Atlas::eELSE == pCondition->m_eAtlasStatement );
				}
			}

			const multimap< unsigned int, AtlasStatement* >::iterator itInsert = m_mapStatements.insert( make_pair( uiId, pStatement ) );

			if ( bElse )
			{
				SetElseWithMatchingIfStatement( &m_mapStatements, itInsert );
			}
		}
	}
	else
	{
		AtlasStatementContainer* pChildContainer = GetStatementsChild( pStatement->m_uiConditionalStatementsId );
	
		if ( 0 != pChildContainer )
		{
			AtlasCondition* pCondition = dynamic_cast< AtlasCondition* >( pStatement );
			unsigned int uiId = pStatement->m_uiId;
	
			if ( 0 != pCondition )
			{
				if ( 0 != pCondition->m_uiStatementsId )
				{
					uiId = pCondition->m_uiStatementsId;
				}

				bElse = ( Atlas::eELSE == pCondition->m_eAtlasStatement );
			}

			pChildContainer->AddTestNumber( pStatement );

			const multimap< unsigned int, AtlasStatement* >::iterator itInsert = pChildContainer->m_mapStatements.insert( make_pair( uiId, pStatement ) );

			if ( bElse )
			{
				SetElseWithMatchingIfStatement( &( pChildContainer->m_mapStatements ), itInsert );
			}
		}
		#if ( _DEBUG ) && ( WIN32 )
		else
		{
			DebugBreak( );
		}
		#endif
	}
}

void AtlasStatementContainer::AddTestNumber( const AtlasStatement* pStatement )
{
	const string strTestNumber( pStatement->GetStatementTestNumber( ) );
	const bool bFirstStep = ( pStatement->GetStatementIsBeginTest( ) );
	const map< string, TestData* >::iterator it = m_mapTestNumberData.find( strTestNumber );

	if ( m_mapTestNumberData.end( ) == it )
	{
		TestData* pTestData = 0;

		try
		{
			pTestData = new TestData( strTestNumber, bFirstStep, pStatement );
		}
		catch ( ... )
		{
			throw Exception( Exception::eFailedToCreateTestDataObject, __FILE__, __FUNCTION__, __LINE__, m_strId );
		}

		m_mapTestNumberData.insert( make_pair( strTestNumber, pTestData ) );
	}
	else
	{
		TestData* pTestData = it->second;

		if ( bFirstStep )
		{
			pTestData->m_bBeginTest = bFirstStep;
		}

		pTestData->m_setTestStatements.insert( pStatement );
	}
}

void AtlasStatementContainer::SetElseWithMatchingIfStatement( const multimap< unsigned int, AtlasStatement* >* pMultimap, multimap< unsigned int, AtlasStatement* >::iterator it )
{
	if ( pMultimap->begin( ) != it )
	{
		const AtlasCondition* pElseCondition = ( AtlasCondition* ) it->second;

		--it;

		if ( Atlas::eIF_THEN == it->second->m_eAtlasStatement )
		{
			AtlasCondition::IfExpression* pIfExpression = ( AtlasCondition::IfExpression* ) ( ( AtlasCondition* ) it->second )->m_pExpression;

			if ( 0 != pIfExpression )
			{
				pIfExpression->SetELSE( pElseCondition );
			}
		}
		#if ( _DEBUG ) && ( WIN32 )
		else
		{
			DebugBreak( );
		}
		#endif
	}
}

bool AtlasStatementContainer::SetBranchDestinationRefId( AtlasStatement* pStatement, const AtlasProcedure* pProcedure ) const
{
	AtlasGoto* pGotoStatement = dynamic_cast< AtlasGoto* >( pStatement );
	bool bSet = false;

	if ( 0 != pGotoStatement )
	{
		if ( SetBranchDestinationRefId( pGotoStatement ) )
		{
			bSet = true;

			pGotoStatement->m_uiProcRefId = pProcedure->m_uiId;
		}
		else if ( pProcedure->GetEndStatementNumber( ) == pGotoStatement->m_strStatementNumber )
		{
			bSet = true;

			pGotoStatement->m_uiRefId = -1;
			pGotoStatement->m_uiProcRefId = pProcedure->m_uiId;
		}
	}
	else
	{
		AtlasLeave* pLeaveStatement = dynamic_cast< AtlasLeave* >( pStatement );

		if ( 0 != pLeaveStatement )
		{
			if ( Atlas::eLEAVE_PROCEDURE == pLeaveStatement->m_eAtlasStatement )
			{
				bSet = true;
			}
			else
			{
				deque< pair< Atlas::eAtlasStatement, const AtlasStatement* > > dequeConditionalIds;

				bSet = SetBranchDestinationRefId( pLeaveStatement, dequeConditionalIds );

				if ( bSet )
				{
					const Atlas::eAtlasStatement eStatement = pLeaveStatement->GetConditionalStatementType( );
					const unsigned int uiSize = dequeConditionalIds.size( );

					bSet = false;

					if ( uiSize > 0 )
					{
						if ( pLeaveStatement->m_strStatementNumber.empty( ) )
						{
							for ( int i = ( uiSize - 1 ); i > -1; --i )
							{
								const pair< Atlas::eAtlasStatement, const AtlasStatement* >& pr = dequeConditionalIds[ i ];

								if ( eStatement == pr.second->m_eAtlasStatement )
								{
									const AtlasStatement* pNextStatement = GetNextAtlasStatement( pr.second );

									if ( 0 != pNextStatement )
									{
										pLeaveStatement->m_uiRefId = pNextStatement->m_uiId;
									}
									else
									{
										pLeaveStatement->m_uiRefId = -1;
									}

									bSet = true;
									break;
								}
							}
						}
						else
						{
							for ( int i = ( uiSize - 1 ); i > -1; --i )
							{
								const pair< Atlas::eAtlasStatement, const AtlasStatement* >& pr = dequeConditionalIds[ i ];

								if ( eStatement == pr.second->m_eAtlasStatement )
								{
									if ( pLeaveStatement->m_strStatementNumber == pr.second->GetStatementNumber( ) )
									{
										pLeaveStatement->m_uiRefId = pr.second->m_uiId;
										bSet = true;

										break;
									}
								}
							}
						}
					}
				}

				#if ( _DEBUG ) && ( WIN32 )
				if ( !bSet )
				{
					DebugBreak( );
				}
				#endif
			}
		}
		#if ( _DEBUG ) && ( WIN32 )
		else
		{
			DebugBreak( );
		}
		#endif
	}

	return bSet;
}

bool AtlasStatementContainer::SetBranchDestinationRefId( AtlasGoto* pGotoStatement ) const
{
	multimap< unsigned int, AtlasStatement* >::const_iterator it = m_mapStatements.begin( );
	const multimap< unsigned int, AtlasStatement* >::const_iterator itEnd = m_mapStatements.end( );
	bool bSet = false;

	if ( 0 != pGotoStatement->m_uiConditionalStatementsId )
	{
		while ( itEnd != it )
		{
			const AtlasStatement* pStatement = it->second;

			if ( pStatement->GetStatementNumber( ) == pGotoStatement->m_strStatementNumber )
			{
				pGotoStatement->m_uiRefId = pStatement->m_uiId;
			}
			else
			{
				const AtlasCondition* pCondition = dynamic_cast< const AtlasCondition* >( pStatement );

				if ( 0 != pCondition )
				{
					if ( pCondition->GetEndStatementNumber( ) == pGotoStatement->m_strStatementNumber )
					{
						SetBranchDestinationRefId( pGotoStatement, pCondition );
					}
					else
					{
						pCondition->SetBranchDestinationRefId( pGotoStatement );
					}
				}
			}

			if ( 0 != pGotoStatement->m_uiRefId )
			{
				pGotoStatement->m_uiRefId;
				bSet = true;
				break;
			}

			++it;
		}
	}
	else
	{
		while ( itEnd != it )
		{
			const AtlasStatement* pStatement = it->second;

			if ( pStatement->GetStatementNumber( ) == pGotoStatement->m_strStatementNumber )
			{
				pGotoStatement->m_uiRefId = pStatement->m_uiId;
				bSet = true;
				break;
			}
			else
			{
				const AtlasCondition* pCondition = dynamic_cast< const AtlasCondition* >( pStatement );

				if ( 0 != pCondition )
				{
					if ( pCondition->GetEndStatementNumber( ) == pGotoStatement->m_strStatementNumber )
					{
						if ( ( Atlas::eIF_THEN == pCondition->m_eAtlasStatement ) || ( Atlas::eELSE == pCondition->m_eAtlasStatement ) )
						{
							// For IF/ELSE statements, going to the END statement is the same 
							// as going to the next statement

							const AtlasStatement* pNextStatement = GetNextAtlasStatement( pCondition );

							if ( 0 == pNextStatement )
							{
								pGotoStatement->m_uiRefId = -1;
							}
							else
							{
								pGotoStatement->m_uiRefId = pNextStatement->m_uiId;
							}
						}
						else
						{
							// For WHILEs and FORs, going to the END statement is the same as 
							// going to the WHILE or FOR.

							pGotoStatement->m_uiRefId = pStatement->m_uiId;
						}
					}
				}
			}

			++it;
		}
	}

	return bSet;
}

void AtlasStatementContainer::SetBranchDestinationRefId( AtlasGoto* pGotoStatement, const AtlasCondition* pConditionStatement ) const
{
	if ( ( Atlas::eIF_THEN == pConditionStatement->m_eAtlasStatement ) || ( Atlas::eELSE == pConditionStatement->m_eAtlasStatement ) )
	{
		// For IF/ELSE statements, going to the END statement is the same 
		// as going to the next statement

		const AtlasStatement* pNextStatement = GetNextAtlasStatement( pConditionStatement );

		if ( 0 == pNextStatement )
		{
			pGotoStatement->m_uiRefId = -1;
		}
		else
		{
			pConditionStatement = dynamic_cast< const AtlasCondition* >( pNextStatement );

			if ( 0 != pConditionStatement )
			{
				if ( pConditionStatement->GetEndStatementNumber( ) == pGotoStatement->m_strStatementNumber )
				{
					pNextStatement = GetNextAtlasStatement( pConditionStatement );

					if ( 0 == pNextStatement )
					{
						pGotoStatement->m_uiRefId = -1;
					}
					else
					{
						pGotoStatement->m_uiRefId = pNextStatement->m_uiId;
					}
				}
				else
				{
					pGotoStatement->m_uiRefId = pNextStatement->m_uiId;
				}
			}
			else
			{
				pGotoStatement->m_uiRefId = pNextStatement->m_uiId;
			}
		}
	}
	else
	{
		// For WHILEs and FORs, going to the END statement is the same as 
		// going to the WHILE or FOR.

		pGotoStatement->m_uiRefId = pConditionStatement->m_uiId;
	}
}

bool AtlasStatementContainer::SetBranchDestinationRefId( const AtlasLeave* pLeaveStatement, deque< pair< Atlas::eAtlasStatement, const AtlasStatement* > >& dequeConditionalIds ) const
{
	multimap< unsigned int, AtlasStatement* >::const_iterator it = m_mapStatements.begin( );
	const multimap< unsigned int, AtlasStatement* >::const_iterator itEnd = m_mapStatements.end( );
	bool bSet = false;

	while ( itEnd != it )
	{
		const AtlasStatement* pStatement = it->second;

		if ( pStatement->m_uiId == pLeaveStatement->m_uiId )
		{
			bSet = true;
			break;
		}
		else
		{
			const AtlasCondition* pCondition = dynamic_cast< const AtlasCondition* >( pStatement );

			if ( 0 != pCondition )
			{
				dequeConditionalIds.push_back( make_pair( pCondition->m_eAtlasStatement, pCondition ) );

				if ( pCondition->SetBranchDestinationRefId( pLeaveStatement, dequeConditionalIds ) )
				{
					bSet = true;
					break;
				}
				else
				{
					dequeConditionalIds.pop_back( );
				}
			}
		}

		++it;
	}

	return bSet;
}

const AtlasStatement* AtlasStatementContainer::GetNextAtlasStatement( const AtlasStatement* pStatement ) const
{
	const AtlasStatement* pRetStatement = 0;

	if ( 0 != pStatement )
	{
		const multimap< unsigned int, AtlasStatement* >* pmapParentStatements = 0;
		bool bProcedure = false;
	
		if ( 0 != pStatement->m_pConditionalStatement )
		{
			pmapParentStatements = &( ( ( AtlasStatementContainer* ) pStatement->m_pConditionalStatement )->m_mapStatements );
		}
		else if ( 0 != pStatement->m_pProcedureStatement )
		{
			pmapParentStatements = &( ( ( AtlasStatementContainer* ) pStatement->m_pProcedureStatement )->m_mapStatements );
			bProcedure = true;
		}
	
		if ( 0 != pmapParentStatements )
		{
			multimap< unsigned int, AtlasStatement* >::const_iterator it;
			const multimap< unsigned int, AtlasStatement* >::const_iterator itEnd = pmapParentStatements->end( );
			const AtlasStatementContainer* pStatementContainer = dynamic_cast< const AtlasStatementContainer* >( pStatement );
			const unsigned int uiId = ( 0 == pStatementContainer ? pStatement->m_uiId : pStatementContainer->m_uiStatementsId );
	
			it = pmapParentStatements->find( uiId );
	
			if ( itEnd != it )
			{
				++it;
	
				if ( itEnd != it )
				{
					pRetStatement = it->second;
				}
				else if ( !bProcedure )
				{
					pRetStatement = GetNextAtlasStatement( pStatement->m_pConditionalStatement );
				}
			}
		}
	}

	return pRetStatement;
}

void AtlasStatementContainer::GarbageCollect( void )
{
	m_mapStatements.clear( );

	const unsigned int uiSize = m_mapTestNumberData.size( );

	if ( uiSize > 0 )
	{
		map< string, TestData* >::const_iterator it = m_mapTestNumberData.begin( );
		const map< string, TestData* >::const_iterator itEnd = m_mapTestNumberData.end( );

		while ( itEnd != it )
		{
			delete it->second;

			++it;
		}
	}
}

void AtlasStatementContainer::SetStatementsParent( AtlasProcedure* pProcedureStatement )
{
	multimap< unsigned int, AtlasStatement* >::const_iterator it = m_mapStatements.begin( );
	const multimap< unsigned int, AtlasStatement* >::const_iterator itEnd = m_mapStatements.end( );
	const bool bConditional = ( 0 != dynamic_cast< AtlasCondition* >( this ) );
	AtlasStatementContainer* pContainer = 0;

	while ( itEnd != it )
	{
		AtlasStatement* pStatement = it->second;

		pStatement->m_pProcedureStatement = pProcedureStatement;

		if ( bConditional )
		{
			pStatement->m_pConditionalStatement = ( AtlasCondition* ) this;
		}

		pContainer = dynamic_cast< AtlasStatementContainer* >( pStatement );

		if ( 0 != pContainer )
		{
			pContainer->SetStatementsParent( pProcedureStatement );
		}

		++it;
	}
}

AtlasStatementContainer* AtlasStatementContainer::GetStatementsChild( const unsigned int uiId )
{
	AtlasStatementContainer* pRetContainer = 0;

	if ( m_mapStatements.size( ) > 0 )
	{
		multimap< unsigned int, AtlasStatement* >::const_iterator it = m_mapStatements.find( uiId );
		const multimap< unsigned int, AtlasStatement* >::const_iterator itEnd = m_mapStatements.end( );

		if ( itEnd != it )
		{
			AtlasStatementContainer* pContainer = dynamic_cast< AtlasStatementContainer* >( it->second );

			if ( 0 != pContainer )
			{
				pRetContainer = pContainer;
			}
		}
		else
		{
			it = m_mapStatements.begin( );
	
			while ( itEnd != it )
			{
				AtlasCondition* pCondition = dynamic_cast< AtlasCondition* >( it->second );

				if ( 0 != pCondition )
				{
					pRetContainer = pCondition->GetStatementsChild( uiId );

					if ( 0 != pRetContainer )
					{
						break;
					}
				}

				++it;
			}
		}
	}

	return pRetContainer;
}

void AtlasStatementContainer::Statements_ToXML( string& strXML, const set< unsigned int >* psetEntryPointIds ) const
{
	if ( m_mapStatements.size( ) > 0 )
	{
		strXML += XML::MakeOpenXmlElementWithChildren( XML::enStatements, XML::MakeXmlAttributeNameValue( XML::anCount, m_mapStatements.size( ) ) );

		multimap< unsigned int, AtlasStatement* >::const_iterator it = m_mapStatements.begin( );
		const multimap< unsigned int, AtlasStatement* >::const_iterator itEnd = m_mapStatements.end( );
		const bool bHaveEntryPoints = ( 0 != psetEntryPointIds );
		string strEntryPointText;
		string strEntryPoint;
		string strCommentId;
		string strTestNumber;
		string strBeginTest;


		if ( bHaveEntryPoints )
		{
			strEntryPointText = XML::MakeXmlAttributeNameValue( XML::anEntryPoint, XML::avTrue );
		}

		while ( itEnd != it )
		{
			unsigned int uiId = it->second->GetStatementId( );

			if ( bHaveEntryPoints )
			{
				strEntryPoint.clear( );

				if ( psetEntryPointIds->end( ) != psetEntryPointIds->find( uiId ) )
				{
					strEntryPoint = strEntryPointText;
				}
			}

			strCommentId = it->second->GetStatementCommentRefId_XML( );
			strTestNumber = it->second->GetStatementTestNumber_XML( );
			strBeginTest = it->second->GetStatementBeginTest_XML( );

			switch ( it->second->m_eAtlasStatement )
			{
				case Atlas::ePERFORM:
				{
					AtlasPerform* pPerform = ( AtlasPerform* ) it->second;
					string strRecursizeAttr;

					if ( pPerform->m_bRecursive )
					{
						strRecursizeAttr = XML::MakeXmlAttributeNameValue( XML::anRecursive, XML::avTrue );
					}
	
					uiId = pPerform->m_uiProcedureId;

					if ( 0 == pPerform->GetParametersCount( ) )
					{
						strXML += XML::MakeOpenXmlElementWithChildren( XML::enStatement, XML::MakeXmlAttributeNameValue( XML::anType, it->second->GetStatementType( ) ), XML::MakeXmlAttributeNameValue( XML::anId, it->second->m_uiId ), XML::MakeXmlAttributeNameValue( XML::anProcRefId, uiId ), strTestNumber, strBeginTest, strCommentId, strEntryPoint, strRecursizeAttr );
						
						unsigned int uiSize = pPerform->m_vectAtlasSourceStatement.size( );
						if ( uiSize > 0 )
						{
							unsigned int uiFields = Atlas::AtlasSourceStatement::eXmlFilename;
					
							uiFields |= Atlas::AtlasSourceStatement::eXmlStatementNumber;
							uiFields |= Atlas::AtlasSourceStatement::eXmlLineNumber;
							uiFields |= Atlas::AtlasSourceStatement::eXmlSourceType;
					
							strXML += pPerform->m_vectAtlasSourceStatement[ 0 ].ToXML( uiFields );
						}
	
						strXML += XML::MakeCloseXmlElementWithChildren( XML::enStatement );
					}
					else
					{
						strXML += XML::MakeOpenXmlElementWithChildren( XML::enStatement, XML::MakeXmlAttributeNameValue( XML::anType, it->second->GetStatementType( ) ), XML::MakeXmlAttributeNameValue( XML::anId, it->second->m_uiId ), XML::MakeXmlAttributeNameValue( XML::anProcRefId, uiId ), strTestNumber, strBeginTest, strCommentId, strEntryPoint, strRecursizeAttr );
	
						pPerform->ToXML( strXML, true );
	
						strXML += XML::MakeCloseXmlElementWithChildren( XML::enStatement );
					}
				}
				break;

				case Atlas::eGO_TO:
				case Atlas::eLEAVE_PROCEDURE:
				case Atlas::eLEAVE_IF:
				case Atlas::eLEAVE_FOR:
				case Atlas::eLEAVE_WHILE:
					it->second->ToXML( strXML );
					break;

				default:
				{
					AtlasCondition* pCondition = dynamic_cast< AtlasCondition* >( it->second );
			
					if ( 0 != pCondition )
					{
						pCondition->ToXML( strXML, psetEntryPointIds );
					}
					else
					{
						strXML += XML::MakeXmlElementNoChildren( XML::enStatement, XML::MakeXmlAttributeNameValue( XML::anType, it->second->GetStatementType( ) ), XML::MakeXmlAttributeNameValue( XML::anRefId, uiId ), strTestNumber, strBeginTest, strCommentId, strEntryPoint );
					}
				}
				break;
			}

			++it;
		}

		strXML += XML::MakeCloseXmlElementWithChildren( XML::enStatements );
	}
}

void AtlasStatementContainer::VerifyStatementOrder( void ) const
{ 
	unsigned int uiLineNumber = 0;

	VerifyStatementOrder( GetStatementFilename( ), uiLineNumber, &m_mapStatements );
}

void AtlasStatementContainer::GetChildrenTestNumberStatements( map< string, AtlasStatementContainer::TestData* >& mapTestNumberData ) const
{
	multimap< unsigned int, AtlasStatement* >::const_iterator it = m_mapStatements.begin( );
	const multimap< unsigned int, AtlasStatement* >::const_iterator itEnd = m_mapStatements.end( );

	while ( itEnd != it )
	{
		AtlasStatementContainer* pContainer = dynamic_cast< AtlasStatementContainer* >( it->second );

		if ( 0 != pContainer )
		{
			map< string, TestData* >::const_iterator it2 = pContainer->m_mapTestNumberData.begin( );
			map< string, TestData* >::const_iterator it2End = pContainer->m_mapTestNumberData.end( );

			while ( it2End != it2 )
			{
				const map< string, AtlasStatementContainer::TestData* >::const_iterator itTestData = mapTestNumberData.find( it2->first );

				if ( mapTestNumberData.end( ) == itTestData )
				{
					mapTestNumberData.insert( make_pair( it2->first, it2->second ) );
				}
				else
				{
					itTestData->second->m_setTestStatements.insert( it2->second->m_setTestStatements.begin( ), it2->second->m_setTestStatements.end( ) );
				}

				++it2;
			}

			pContainer->GetChildrenTestNumberStatements( mapTestNumberData );
		}

		++it;
	}
}

void AtlasStatementContainer::GetTestNumberStatementVariables( const map< string, TestData* >& mapTestNumberData, map< string, map< string, const Atlas::AtlasData* > >& mapTestVariables ) const
{
	map< string, TestData* >::const_iterator itTestNumbers = mapTestNumberData.begin( );
	const map< string, TestData* >::const_iterator itTestNumbersEnd = mapTestNumberData.end( );

	while ( itTestNumbersEnd != itTestNumbers )
	{
		const string& strTestName = itTestNumbers->first;
		set< const AtlasStatement* >::const_iterator itStatements = itTestNumbers->second->m_setTestStatements.begin( );
		const set< const AtlasStatement* >::const_iterator itEndStatements = itTestNumbers->second->m_setTestStatements.end( );
		const pair< map< string, map< string, const Atlas::AtlasData* > >::iterator, bool > prVariables = mapTestVariables.insert( make_pair( strTestName, map< string, const Atlas::AtlasData* >( ) ) );

		if ( prVariables.second )
		{
			map< string, const Atlas::AtlasData* >& mapVariables = prVariables.first->second;

			while ( itEndStatements != itStatements )
			{
				multimap< string, Atlas::AtlasData* >::const_iterator itVariables = ( *itStatements )->m_multimapVariables.begin( );
				const multimap< string, Atlas::AtlasData* >::const_iterator itEndVariables = ( *itStatements )->m_multimapVariables.end( );
	
				while ( itEndVariables != itVariables )
				{
					const Atlas::AtlasData* pAtlasData = itVariables->second;
	
					if ( pAtlasData->GetVariableRefId( ) > 0 )
					{
						const string strVarNameHash( pAtlasData->GetHashValue( ) );
		
						if ( mapVariables.end( ) == mapVariables.find( strVarNameHash ) )
						{
							mapVariables.insert( make_pair( strVarNameHash, pAtlasData ) );
						}
					}
	
					++itVariables;
				}
	
				++itStatements;
			}
		}
		#if ( _DEBUG ) && ( WIN32 )
		else
		{
			DebugBreak( );
		}
		#endif

		++itTestNumbers;
	}
}

void AtlasStatementContainer::GetTestNumberStatementSignalOrientedVerbs( const map< string, TestData* >& mapTestNumberData, map< string, map< unsigned int, const AtlasStatement* > >& mapSignalOrientedVerbs ) const
{
	map< string, TestData* >::const_iterator it = mapTestNumberData.begin( );
	const map< string, TestData* >::const_iterator itEnd = mapTestNumberData.end( );

	while ( itEnd != it )
	{
		set< const AtlasStatement* >::const_iterator it2 = it->second->m_setTestStatements.begin( );
		const set< const AtlasStatement* >::const_iterator it2End = it->second->m_setTestStatements.end( );

		while ( it2End != it2 )
		{
			const AtlasActionSignalVerb* pActionSignalVerb = dynamic_cast< const AtlasActionSignalVerb* >( *it2 );

			if ( 0 != pActionSignalVerb )
			{
				const map< string, map< unsigned int, const AtlasStatement* > >::iterator itVerb = mapSignalOrientedVerbs.find( it->first );

				if ( mapSignalOrientedVerbs.end( ) == itVerb )
				{
					pair< map< string, map< unsigned int, const AtlasStatement* > >::iterator, bool > prRet = mapSignalOrientedVerbs.insert( make_pair( it->first, map< unsigned int, const AtlasStatement* >( ) ) );

					prRet.first->second.insert( make_pair( pActionSignalVerb->m_uiId, pActionSignalVerb ) );
				}
				else
				{
					itVerb->second.insert( make_pair( pActionSignalVerb->m_uiId, pActionSignalVerb ) );
				}
			}

			++it2;
		}

		++it;
	}
}

void AtlasStatementContainer::VerifyStatementOrder( const string& strFilename, unsigned int& uiPreviousLineNumber, const multimap< unsigned int, AtlasStatement* >* pmapStatements ) const
{
	if ( 0 != pmapStatements )
	{
		multimap< unsigned int, AtlasStatement* >::const_iterator it = pmapStatements->begin( );
		const multimap< unsigned int, AtlasStatement* >::const_iterator itEnd = pmapStatements->end( );

		while ( itEnd != it )
		{
			const unsigned int uiLineNumber = it->second->GetStatementLineNumber( );

			if ( uiLineNumber < uiPreviousLineNumber )
			{
				const string strStatmentFilename( it->second->GetStatementFilename( ) );

				if ( strStatmentFilename == strFilename )
				{
					//DebugBreak( );
				}
				else
				{
					uiPreviousLineNumber = uiLineNumber;
				}
			}
			else
			{
				uiPreviousLineNumber = uiLineNumber;
			}

			const AtlasStatementContainer* pContainer = dynamic_cast< const AtlasStatementContainer* >( it->second );

			if ( 0 != pContainer )
			{
				pContainer->VerifyStatementOrder( pContainer->GetStatementFilename( ), uiPreviousLineNumber, &( pContainer->m_mapStatements ) );
			}

			++it;
		}
	}
}

AtlasUnhandledStatement& AtlasUnhandledStatement::operator = ( const AtlasStatement& other )
{ 
	AtlasStatement::operator = ( other );

	const AtlasUnhandledStatement* pother = dynamic_cast< const AtlasUnhandledStatement* >( &other );

	if ( 0 != pother )
	{
		m_eElementName = pother->m_eElementName;
	}

	return *this;
}

void AtlasUnhandledStatement::InitFromXML( const StatementMetadata* pData )
{
	if ( 0 != pData )
	{
		if ( 0 != pData->m_pStatement )
		{
			string strAIXMLtagName;
	
			SetSourceStatementInfo( pData->m_pStatement, pData->m_eSourceType, pData->m_strFilename, pData->m_strParentProcedureName, pData->m_uiParentProcedureId );
	
			m_uiConditionalStatementsId = pData->m_uiParentConditionalStatementsId;
		}
	}
}

void AtlasUnhandledStatement::ToXML( string& strXML ) const
{
	const string strId( 0 == m_uiId ? string( ) : XML::MakeXmlAttributeNameValue( XML::anId, m_uiId ) );
	const string strCommentRefId( GetStatementCommentRefId_XML( ) );

	strXML += XML::MakeOpenXmlElementWithChildren( m_eElementName, strId, strCommentRefId );

	const unsigned int uiSourceStatments = m_vectAtlasSourceStatement.size( );
	if ( uiSourceStatments > 0 )
	{
		unsigned int uiFields = Atlas::AtlasSourceStatement::eXmlFilename;

		uiFields |= Atlas::AtlasSourceStatement::eXmlStatementNumber;
		uiFields |= Atlas::AtlasSourceStatement::eXmlLineNumber;
		uiFields |= Atlas::AtlasSourceStatement::eXmlSourceType;
		uiFields |= Atlas::AtlasSourceStatement::eXmlProcname;

		strXML += m_vectAtlasSourceStatement[ 0 ].ToXML( uiFields );
	}

	strXML += XML::MakeCloseXmlElementWithChildren( m_eElementName );
}