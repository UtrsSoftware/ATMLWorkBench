/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

#include "declare.h"
#include "exception.h"
#include "aixml.h"
#include "calculate.h"
#include "fill.h"
#include "xml.h"

// Xercesc XML Parser
#include <xercesc/parsers/XercesDOMParser.hpp>
#include <xercesc/dom/dom.hpp>

#if ( _DEBUG ) && ( WIN32 )
	#define WINVER 0x0600
	#include <afx.h>
	#define new DEBUG_NEW
	#undef THIS_FILE
	static char BASED_CODE THIS_FILE[ ] = __FILE__;
#endif

using namespace XERCES_CPP_NAMESPACE;


void AtlasDeclare::InitFromXML( const xercesc::DOMElement* pAIXMLvalue, const Atlas::AtlasSourceStatement::eSourceType eSourcType, const string& strFilename )
{
	AtlasStatement::GarbageCollect( );
	AtlasAttributes::GarbageCollect( );

	if ( 0 != pAIXMLvalue )
	{
		string strAIXMLtagName;

		SetSourceStatementInfo( pAIXMLvalue, eSourcType, strFilename, string( ), 0 );

		pAIXMLvalue = pAIXMLvalue->getFirstElementChild( );

		AIXMLHelper::GetXercesString( pAIXMLvalue->getTagName( ), strAIXMLtagName );

		if ( AIXML::m_arrayXMLKeyWords[ AIXML::eArgumentsElement ] == strAIXMLtagName )
		{
			pAIXMLvalue = pAIXMLvalue->getFirstElementChild( );

			while ( 0 != pAIXMLvalue )
			{
				AtlasStatement::InitFromXML( pAIXMLvalue );

				pAIXMLvalue = pAIXMLvalue->getNextElementSibling( );
			}
		}
	}
}

void AtlasDeclare::Process( vector< AtlasDeclareData* >& vectDeclares, const Lookup* pLookup )
{
	Atlas::AtlasSourceStatement source;

	if ( m_vectAtlasSourceStatement.size( ) > 0 )
	{
		source = m_vectAtlasSourceStatement[ 0 ];

		source.SetAtlasStatement( Atlas::eDECLARE );
		source.SetParentProcname( string( ) );
	}

	GetDeclares( m_vectAttributes, vectDeclares, source );
}

void AtlasDeclare::GetDeclares( const vector< const AtlasAttibuteValue* >& vectSourceDeclares, vector< AtlasDeclareData* >& vectDeclares, Atlas::AtlasSourceStatement& source )
{
	const unsigned int uiSize = vectSourceDeclares.size( );

	if ( uiSize > 0 )
	{
		vector< pair< string, pair< unsigned int, unsigned int > > > vectVariables;
		Atlas::AtlasDeclare declare;
		unsigned int uiLineNumber = 0;
		const string* pstrStatementNumber = 0;
		bool bFormat = false;

		for ( unsigned int ui = 0; ui < uiSize; ++ui )
		{
			const AtlasAttibuteValue* pAttibuteValue = vectSourceDeclares[ ui ];

			if ( 0 == pAttibuteValue )
			{
				const unsigned int uiVarSize = vectVariables.size( );

				for ( unsigned int uiVar = 0; uiVar < uiVarSize; ++uiVar )
				{
					declare.m_strVarName = vectVariables[ uiVar ].first;
					declare.m_uiListSize = vectVariables[ uiVar ].second.first;

					source.SetId( vectVariables[ uiVar ].second.second );
					source.SetLineNumber( uiLineNumber );

					if ( 0 != pstrStatementNumber )
					{
						source.SetStatementNumber( *pstrStatementNumber );
					}

					if ( !declare.IsGlobal( ) && !declare.IsExternal( ) )
					{
						declare.SetLocal( true );
					}

					AtlasDeclareData* pAtlasDeclareData = 0;
					
					try
					{
						pAtlasDeclareData = new AtlasDeclareData( declare, source );
					}
					catch ( ... )
					{
						throw Exception( Exception::eFailedToAllocateMemoryForNewDeclareDataObject, __FILE__, __FUNCTION__, __LINE__ );
					}

					vectDeclares.push_back( pAtlasDeclareData );
				}

				declare.Clear( );
				vectVariables.clear( );

				uiLineNumber = 0;
				pstrStatementNumber = 0;

				continue;
			}

			if ( 0 == uiLineNumber )
			{
				uiLineNumber = pAttibuteValue->m_uiLineNumber;
			}

			if ( 0 == pstrStatementNumber )
			{
				if ( !pAttibuteValue->m_strStatementNumber.empty( ) )
				{
					pstrStatementNumber = &( pAttibuteValue->m_strStatementNumber );
				}
			}

			if ( !declare.IsGlobal( ) && !declare.IsExternal( ) )
			{
				if ( AtlasStatement::m_strGLOBAL == pAttibuteValue->m_strValue )
				{
					declare.SetGlobal( true );
					continue;
				}
				else if ( AtlasStatement::m_strEXTERNAL == pAttibuteValue->m_strValue )
				{
					declare.SetExternal( true );
					continue;
				}
			}

			if ( Atlas::eUnknownDataType == declare.m_eDataType )
			{
				declare.m_eDataType = Atlas::GetAtlasDataTypeEnum( pAttibuteValue->m_strValue );

				#if ( _DEBUG ) && ( WIN32 )
					if ( Atlas::eUnknownDataType == declare.m_eDataType )
					{
						DebugBreak( );
					}
				#endif

				continue;
			}

			if ( !declare.IsStore( ) && !declare.IsList( ) )
			{
				if ( AtlasStatement::m_strSTORE == pAttibuteValue->m_strValue )
				{
					declare.SetStore( true );
					continue;
				}
				else if ( AtlasStatement::m_strLIST == pAttibuteValue->m_strValue )
				{
					declare.SetList( true );
					continue;
				}
			}

			if ( 0 == vectVariables.size( ) )
			{
				for ( ; ui < uiSize; ++ui )
				{
					pAttibuteValue = vectSourceDeclares[ ui ];

					if ( 0 != pAttibuteValue )
					{
						if ( pAttibuteValue->IsVariable( ) )
						{
							vectVariables.push_back( make_pair( pAttibuteValue->m_strValue, make_pair( 0, pAttibuteValue->m_uiId ) ) );
							declare.SetVariable( true );

							pair< string, pair< unsigned int, unsigned int > >& pr = vectVariables.back( );

							if ( declare.IsList( ) )
							{
								if ( ( ui + 1 ) < uiSize )
								{
									++ui;

									pAttibuteValue = vectSourceDeclares[ ui ];

									if ( 0 != pAttibuteValue )
									{
										if ( pAttibuteValue->IsConstant( ) )
										{
											pr.second.first = AIXMLHelper::StringToNumber< unsigned int >( pAttibuteValue->m_strValue );
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
										--ui;
										break;
									}
								}
							}
						}
						else
						{
							--ui;
							break;
						}
					}
					else
					{
						--ui;
						break;
					}
				}

				continue;
			}

			if ( Atlas::eDIGITAL == declare.m_eDataType )
			{
				if ( !bFormat )
				{
					if ( AtlasStatement::m_strFORMAT == pAttibuteValue->m_strValue )
					{
						bFormat = true;
						continue;
					}
				}
				else if ( Atlas::eUnknownDataType == declare.m_eDigialType )
				{
					declare.m_eDigialType = Atlas::GetAtlasDataTypeEnum( pAttibuteValue->m_strValue );
					continue;
				}
			}

			if ( 0 == declare.m_uiDataLength )
			{
				if ( pAttibuteValue->IsConstant( ) )
				{
					declare.m_uiDataLength = AIXMLHelper::StringToNumber< unsigned int >( pAttibuteValue->m_strValue );
					continue;
				}
			}

			if ( Atlas::eUnknownDataType == declare.m_eSubDataType )
			{
				declare.m_eSubDataType = Atlas::GetAtlasDataTypeEnum( pAttibuteValue->m_strValue );
				continue;
			}
		}

		if ( Atlas::eUnknownDataType != declare.m_eDataType )
		{
			const unsigned int uiVarSize = vectVariables.size( );
	
			for ( unsigned int uiVar = 0; uiVar < uiVarSize; ++uiVar )
			{
				declare.m_strVarName = vectVariables[ uiVar ].first;
				declare.m_uiListSize = vectVariables[ uiVar ].second.first;
	
				source.SetId( vectVariables[ uiVar ].second.second );
				source.SetLineNumber( uiLineNumber );

				if ( 0 != pstrStatementNumber )
				{
					source.SetStatementNumber( *pstrStatementNumber );
				}

				if ( !declare.IsGlobal( ) && !declare.IsExternal( ) )
				{
					declare.SetLocal( true );
				}

				AtlasDeclareData* pAtlasDeclareData = 0;
					
				try
				{
					pAtlasDeclareData = new AtlasDeclareData( declare, source );
				}
				catch ( ... )
				{
					throw Exception( Exception::eFailedToAllocateMemoryForNewDeclareDataObject, __FILE__, __FUNCTION__, __LINE__ );
				}
	
				vectDeclares.push_back( pAtlasDeclareData );
			}
		}
	}
}

string AtlasDeclareData::ToXML( const XML::ElementName enName ) const
{
	string strXML;

	if ( Atlas::AtlasData::eUnknownBuiltInType == m_eBuiltInType )
	{
		strXML += XML::MakeOpenXmlElementWithChildren( enName, m_Declare.ToXML( m_Source.GetId( ), m_Source.GetCommentId( ) ) );

		unsigned int uiFields = Atlas::AtlasSourceStatement::eXmlFilename;
		uiFields |= Atlas::AtlasSourceStatement::eXmlStatementNumber;
		uiFields |= Atlas::AtlasSourceStatement::eXmlLineNumber;
		uiFields |= Atlas::AtlasSourceStatement::eXmlSourceType;
		uiFields |= Atlas::AtlasSourceStatement::eXmlProcname;
	
		strXML += m_Source.ToXML( uiFields );

		strXML += XML::MakeCloseXmlElementWithChildren( enName );
	}
	else
	{
		// All built-in variables are of boolean type

		string strInitialValue;

		if ( Atlas::AtlasData::eTrue == m_eBuiltInType )
		{
			strInitialValue = XML::MakeXmlAttributeNameValue( XML::anValue, XML::avTrue );
		}
		else
		{
			strInitialValue = XML::MakeXmlAttributeNameValue( XML::anValue, XML::avFalse );
		}

		strXML += XML::MakeXmlElementNoChildren( enName, m_Declare.ToXML( m_Source.GetId( ), m_Source.GetCommentId( ) ), strInitialValue );
	}

	return strXML;
}

string AtlasDeclareData::Assignments_ToXML( void ) const
{
	const unsigned int uiAssigments = m_vectAssignments.size( );
	string strXML;

	if ( uiAssigments > 0 )
	{
		unsigned int uiAssignsByExpression = 0;
		set < string > setAssignedByValue;

		strXML += XML::MakeOpenXmlElementWithChildren( XML::enAssignmentsByStatement, XML::MakeXmlAttributeNameValue( XML::anCount, uiAssigments ) );

		for ( unsigned int ui = 0; ui < uiAssigments; ++ui )
		{
			const AtlasStatement* pAtlasStatement = m_vectAssignments[ ui ];
			string strAttributes;

			strAttributes += XML::MakeXmlAttributeNameValue( XML::anStatementType, pAtlasStatement->GetStatementType( ) );
			strAttributes += XML::MakeXmlAttributeNameValue( XML::anRefId, pAtlasStatement->GetStatementId( ) );

			if ( Atlas::eFILL == pAtlasStatement->m_eAtlasStatement )
			{
				strAttributes.insert( 0, XML::MakeXmlAttributeNameValue( XML::anType, XML::avAssign ) );

				strXML += XML::MakeXmlElementNoChildren( XML::enAssignment, strAttributes );
			}
			else if ( Atlas::eCALCULATE == pAtlasStatement->m_eAtlasStatement )
			{
				const XML::AttributeValue avAssignType = ( ( AtlasCalculate* ) pAtlasStatement )->GetAssignmentType( );

				if ( XML::avAssign != avAssignType )
				{
					++uiAssignsByExpression;
				}
				else
				{
					if ( ( ( AtlasCalculate* ) pAtlasStatement )->IsListVariable( ) )
					{
						const Atlas::AtlasData* pData = ( ( AtlasCalculate* ) pAtlasStatement )->GetListVariableSubscript( );

						if ( 0 != pData )
						{
							if ( pData->IsVariableName( ) )
							{
								++uiAssignsByExpression;
							}
							else if ( 0 == dynamic_cast< const Atlas::AtlasNumber* >( pData ) )
							{
								++uiAssignsByExpression;
							}
						}
					}
				}

				strAttributes.insert( 0, XML::MakeXmlAttributeNameValue( XML::anType, avAssignType ) );

				strXML += XML::MakeXmlElementNoChildren( XML::enAssignment, strAttributes );
			}
			#if ( _DEBUG ) && ( WIN32 )
			else
			{
				DebugBreak( );
			}
			#endif
		}

		strXML += XML::MakeCloseXmlElementWithChildren( XML::enAssignmentsByStatement );

		//////////////////////////////////////////////////////////////////////////////

		for ( unsigned int ui = 0; ui < uiAssigments; ++ui )
		{
			const AtlasStatement* pAtlasStatement = m_vectAssignments[ ui ];
			string strValueXML;

			if ( Atlas::eFILL == pAtlasStatement->m_eAtlasStatement )
			{
				( ( AtlasFill* ) pAtlasStatement )->GetAssignValue_XML( XML::enAssign, setAssignedByValue );
			}
			else if ( Atlas::eCALCULATE == pAtlasStatement->m_eAtlasStatement )
			{
				( ( AtlasCalculate* ) pAtlasStatement )->GetAssignValue_XML( XML::enAssign, setAssignedByValue );
			}
		}

		if ( setAssignedByValue.size( ) > 0 )
		{
			const string strTab( "\t" );
			set< string >::const_iterator it = setAssignedByValue.begin( );
			const set< string >::const_iterator itEnd = setAssignedByValue.end( );

			strXML += XML::MakeOpenXmlElementWithChildren( XML::enAssignmentsByValue, XML::MakeXmlAttributeNameValue( XML::anCount, setAssignedByValue.size( ) ), XML::MakeXmlAttributeNameValue( XML::anAssignmentByExpression, uiAssignsByExpression ) );

			while ( itEnd != it )
			{
				strXML += strTab;
				strXML += *it;

				++it;
			}
	
			strXML += XML::MakeCloseXmlElementWithChildren( XML::enAssignmentsByValue );
		}
	}

	return strXML;
}