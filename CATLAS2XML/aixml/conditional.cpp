/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

#include "conditional.h"
#include "procedure.h"
#include "exception.h"
#include "aixml.h"

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

const string AtlasCondition::m_strEND( "END_" );

AtlasCondition& AtlasCondition::operator = ( const AtlasStatement& other )
{
	if ( this != &other )
	{
		AtlasStatementContainer::operator = ( other );

		GarbageCollect( );

		const AtlasCondition* pother = dynamic_cast< const AtlasCondition* >( &other );

		if ( 0 != pother )
		{
			m_uiNestLevel = pother->m_uiNestLevel;
			m_uiStatementsId = pother->m_uiStatementsId;
		}
	}

	return *this;
}

void AtlasCondition::InitFromXML( const StatementMetadata* pData )
{
	if ( 0 != pData )
	{
		if ( 0 != pData->m_pStatement )
		{
			string strAIXMLtagName;
	
			SetSourceStatementInfo( pData->m_pStatement, pData->m_eSourceType, pData->m_strFilename, pData->m_strParentProcedureName, pData->m_uiParentProcedureId );

			m_uiConditionalStatementsId = pData->m_uiParentConditionalStatementsId;

			const xercesc::DOMElement* pStatements = pData->m_pStatement->getNextElementSibling( );

			if ( 0 != pStatements )
			{
				AIXMLHelper::GetXercesString( pStatements->getTagName( ), strAIXMLtagName );
		
				if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eStatementsElement ] )
				{
					m_pStatementsElement = pStatements;
		
					const DOMAttr* pAttr = m_pStatementsElement->getAttributeNode( AIXMLHelper::GetWString( AIXML::m_arrayXMLKeyWords[ AIXML::eIdAttribute ] ).c_str( ) );
			
					if ( 0 != pAttr )
					{
						string strContainerId;
			
						AIXMLHelper::GetXercesString( pAttr->getValue( ), strContainerId );
			
						m_uiStatementsId = AIXMLHelper::StringToNumber< unsigned int >( strContainerId );
					}

					const xercesc::DOMElement* pNextConditionPart = pStatements->getNextElementSibling( );
			
					while ( 0 != pNextConditionPart )
					{
						AIXMLHelper::GetXercesString( pNextConditionPart->getTagName( ), strAIXMLtagName );

						if ( AIXMLHelper::StartsWith( strAIXMLtagName, m_strEND ) )
						{
							switch ( m_eAtlasStatement )
							{
								case Atlas::eIF_THEN:
									if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eEndIfElement ] )
									{
										SetSourceStatementInfo( m_EndStatement, pNextConditionPart, pData->m_eSourceType, pData->m_strFilename, pData->m_strParentProcedureName );
										m_EndStatement.SetAtlasStatement( Atlas::eEND_IF );
									}
									else if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eElseElement ] )
									{
										pNextConditionPart = pNextConditionPart->getNextElementSibling( );
	
										if ( 0 != pNextConditionPart )
										{
											pNextConditionPart = pNextConditionPart->getNextElementSibling( );
		
											if ( 0 != pNextConditionPart )
											{
												AIXMLHelper::GetXercesString( pNextConditionPart->getTagName( ), strAIXMLtagName );
		
												if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eEndIfElement ] )
												{
													SetSourceStatementInfo( m_EndStatement, pNextConditionPart, pData->m_eSourceType, pData->m_strFilename, pData->m_strParentProcedureName );
													m_EndStatement.SetAtlasStatement( Atlas::eEND_IF );
												}
											}
										}
										#if ( _DEBUG ) && ( WIN32 )
										else
										{
											DebugBreak( );
										}
										#endif
									}
									break;
	
								case Atlas::eELSE:
									if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eEndIfElement ] )
									{
										SetSourceStatementInfo( m_EndStatement, pNextConditionPart, pData->m_eSourceType, pData->m_strFilename, pData->m_strParentProcedureName );
										m_EndStatement.SetAtlasStatement( Atlas::eEND_IF );
									}
									break;
	
								case Atlas::eWHILE_THEN:
									if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eEndWhileElement ] )
									{
										SetSourceStatementInfo( m_EndStatement, pNextConditionPart, pData->m_eSourceType, pData->m_strFilename, pData->m_strParentProcedureName );
										m_EndStatement.SetAtlasStatement( Atlas::eEND_WHILE );
									}
									break;
	
								case Atlas::eFOR_THEN:
									if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eEndForElement ] )
									{
										SetSourceStatementInfo( m_EndStatement, pNextConditionPart, pData->m_eSourceType, pData->m_strFilename, pData->m_strParentProcedureName );
										m_EndStatement.SetAtlasStatement( Atlas::eEND_FOR );
									}
									break;
							}
						}
	
						pNextConditionPart = pNextConditionPart->getNextElementSibling( );
					}
				}
				else
				{
					// Conditional that contains no statements

					const xercesc::DOMElement* pNextConditionPart = pStatements;

					if ( !AIXMLHelper::StartsWith( strAIXMLtagName, m_strEND ) )
					{
						pNextConditionPart = pStatements->getNextElementSibling( );
					}

					while ( 0 != pNextConditionPart )
					{
						AIXMLHelper::GetXercesString( pNextConditionPart->getTagName( ), strAIXMLtagName );

						if ( AIXMLHelper::StartsWith( strAIXMLtagName, m_strEND ) )
						{
							switch ( m_eAtlasStatement )
							{
								case Atlas::eIF_THEN:
									if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eEndIfElement ] )
									{
										SetSourceStatementInfo( m_EndStatement, pNextConditionPart, pData->m_eSourceType, pData->m_strFilename, pData->m_strParentProcedureName );
										m_EndStatement.SetAtlasStatement( Atlas::eEND_IF );
									}
									break;

								case Atlas::eELSE:
									if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eEndIfElement ] )
									{
										SetSourceStatementInfo( m_EndStatement, pNextConditionPart, pData->m_eSourceType, pData->m_strFilename, pData->m_strParentProcedureName );
										m_EndStatement.SetAtlasStatement( Atlas::eEND_IF );
									}
									break;
	
								case Atlas::eWHILE_THEN:
									if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eEndWhileElement ] )
									{
										SetSourceStatementInfo( m_EndStatement, pNextConditionPart, pData->m_eSourceType, pData->m_strFilename, pData->m_strParentProcedureName );
										m_EndStatement.SetAtlasStatement( Atlas::eEND_WHILE );
									}
									break;
	
								case Atlas::eFOR_THEN:
									if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eEndForElement ] )
									{
										SetSourceStatementInfo( m_EndStatement, pNextConditionPart, pData->m_eSourceType, pData->m_strFilename, pData->m_strParentProcedureName );
										m_EndStatement.SetAtlasStatement( Atlas::eEND_FOR );
									}
									break;
							}
						}

						pNextConditionPart = pNextConditionPart->getNextElementSibling( );
					}
				}
			}
		
			switch ( m_eAtlasStatement )
			{
				case Atlas::eIF_THEN:
					InitIFFromXML( pData->m_pStatement );
					break;
		
				case Atlas::eELSE:
					InitELSEFromXML( pData->m_pStatement );
					break;
		
				case Atlas::eWHILE_THEN:
					InitWHILEFromXML( pData->m_pStatement );
					break;
		
				case Atlas::eFOR_THEN:
					InitFORFromXML( pData->m_pStatement );
					break;
			}
		}
	}

	#if ( _DEBUG ) && ( WIN32 )
	if ( 0 == m_EndStatement.GetId( ) )
	{
		DebugBreak( );
	}
	#endif
}

void AtlasCondition::InitIFFromXML( const xercesc::DOMElement* pAIXMLvalue )
{
	string strAIXMLtagName;
	AIXMLHelper::GetXercesString( pAIXMLvalue->getTagName( ), strAIXMLtagName );

	if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eIfElement ] )
	{
		try
		{
			m_pExpression = new IfExpression;
		}
		catch ( ... )
		{
			throw Exception( Exception::eFailedToCreateBooleanExpressionObject, __FILE__, __FUNCTION__, __LINE__ );
		}

		ProcessExpression( pAIXMLvalue, ( Expression* ) m_pExpression );
	}
	#if ( _DEBUG ) && ( WIN32 )
	else
	{
		DebugBreak( );
	}
	#endif
}

void AtlasCondition::InitELSEFromXML( const xercesc::DOMElement* pAIXMLvalue )
{
	string strAIXMLtagName;
	AIXMLHelper::GetXercesString( pAIXMLvalue->getTagName( ), strAIXMLtagName );

	if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eElseElement ] )
	{
		;
	}
	#if ( _DEBUG ) && ( WIN32 )
	else
	{
		DebugBreak( );
	}
	#endif
}

void AtlasCondition::InitWHILEFromXML( const xercesc::DOMElement* pAIXMLvalue )
{
	string strAIXMLtagName;
	AIXMLHelper::GetXercesString( pAIXMLvalue->getTagName( ), strAIXMLtagName );

	if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eWhileElement ] )
	{
		try
		{
			m_pExpression = new WhileExpression;
		}
		catch ( ... )
		{
			throw Exception( Exception::eFailedToCreateBooleanExpressionObject, __FILE__, __FUNCTION__, __LINE__ );
		}

		ProcessExpression( pAIXMLvalue, ( Expression* ) m_pExpression );
	}
	#if ( _DEBUG ) && ( WIN32 )
	else
	{
		DebugBreak( );
	}
	#endif
}

void AtlasCondition::InitFORFromXML( const xercesc::DOMElement* pAIXMLvalue )
{
	string strAIXMLtagName;
	AIXMLHelper::GetXercesString( pAIXMLvalue->getTagName( ), strAIXMLtagName );

	if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eForElement ] )
	{
		if ( IsForSequenceExpression( pAIXMLvalue ) )
		{
			try
			{
				m_pExpression = new ForSequenceExpression;
			}
			catch ( ... )
			{
				throw Exception( Exception::eFailedToCreateForExpressionObject, __FILE__, __FUNCTION__, __LINE__ );
			}

			ProcessExpression( pAIXMLvalue, ( ForSequenceExpression* ) m_pExpression );
		}
		else
		{
			try
			{
				m_pExpression = new ForListExpression;
			}
			catch ( ... )
			{
				throw Exception( Exception::eFailedToCreateForExpressionObject, __FILE__, __FUNCTION__, __LINE__ );
			}

			ProcessExpression( pAIXMLvalue, ( ForListExpression* ) m_pExpression );
		}
	}
	#if ( _DEBUG ) && ( WIN32 )
	else
	{
		DebugBreak( );
	}
	#endif
}


void AtlasCondition::Process( const Lookup* pLookup )
{
	if ( 0 != m_pExpression )
	{
		if ( 0 != dynamic_cast< const ForListExpression* >( m_pExpression ) )
		{
			ProcessVariableSymbols( ( ( ForListExpression* ) m_pExpression )->GetVariable( ) );

			const unsigned int uiSize = ( ( ForListExpression* ) m_pExpression )->GetListItemCount( );

			for ( unsigned int ui = 0; ui < uiSize; ++ui )
			{
				ProcessVariableSymbols( ( ( ForListExpression* ) m_pExpression )->GetListItem( ui ) );
			}
		}
		else if ( 0 != dynamic_cast< const ForSequenceExpression* >( m_pExpression ) )
		{
			ProcessVariableSymbols( ( ( ForSequenceExpression* ) m_pExpression )->GetVariable( ) );
			ProcessVariableSymbols( ( ( ForSequenceExpression* ) m_pExpression )->GetStartValue( ) );
			ProcessVariableSymbols( ( ( ForSequenceExpression* ) m_pExpression )->GetEndValue( ) );
			ProcessVariableSymbols( ( ( ForSequenceExpression* ) m_pExpression )->GetByValue( ) );
		}
		else
		{
			ProcessVariableSymbols( ( ( Expression* ) m_pExpression )->Get( ) );
		}
	}
}

void AtlasCondition::ToXML( string& strXML, const set< unsigned int >* psetEntryPointIds ) const
{
	const string strBeginTest( GetStatementBeginTest_XML( ) );
	const string strTestNumber( GetStatementTestNumber_XML( ) );
	const string strCommentId( GetStatementCommentRefId_XML( ) );
	string strEntryPoint;
	string strElseRefId;

	if ( 0 != psetEntryPointIds )
	{
		if ( psetEntryPointIds->end( ) != psetEntryPointIds->find( m_uiId ) )
		{
			strEntryPoint = XML::MakeXmlAttributeNameValue( XML::anEntryPoint, XML::avTrue );
		}
	}

	if ( Atlas::eIF_THEN == m_eAtlasStatement )
	{
		const AtlasCondition* pElseCondition = ( ( IfExpression* ) m_pExpression )->GetELSE( );

		if ( 0 != pElseCondition )
		{
			strElseRefId = XML::MakeXmlAttributeNameValue( XML::anElseRefId, pElseCondition->m_uiId );
		}
	}

	strXML += XML::MakeOpenXmlElementWithChildren( XML::enStatement, XML::MakeXmlAttributeNameValue( XML::anType, GetStatementType( ) ), XML::MakeXmlAttributeNameValue( XML::anId, m_uiId ), strElseRefId, strTestNumber, strBeginTest, strCommentId, strEntryPoint );

	unsigned int uiSize = m_vectAtlasSourceStatement.size( );
	if ( uiSize > 0 )
	{
		unsigned int uiFields = Atlas::AtlasSourceStatement::eXmlFilename;

		uiFields |= Atlas::AtlasSourceStatement::eXmlStatementNumber;
		uiFields |= Atlas::AtlasSourceStatement::eXmlLineNumber;
		uiFields |= Atlas::AtlasSourceStatement::eXmlSourceType;

		strXML += m_vectAtlasSourceStatement[ 0 ].ToXML( uiFields );
	}

	if ( 0 != m_pExpression )
	{
		m_pExpression->ToXML( strXML, XML::enCondition, XML::enBoolean, XML::avBoolean );
	}

	Statements_ToXML( strXML );

	strXML += XML::MakeCloseXmlElementWithChildren( XML::enStatement );
}

void AtlasCondition::ProcessExpression( const xercesc::DOMElement* pAIXMLvalue, Expression* pExpression )
{
	if ( 0 != pAIXMLvalue )
	{
		const xercesc::DOMElement* pExpressionXML = pAIXMLvalue;
		string strAIXMLtagName;

		AIXMLHelper::GetXercesString( pExpressionXML->getTagName( ), strAIXMLtagName );
			
		if ( strAIXMLtagName != AIXML::m_arrayXMLKeyWords[ AIXML::eExpressionElement ] )
		{
			pExpressionXML = pAIXMLvalue->getFirstElementChild( );
		}
	
		if ( 0 != pExpressionXML )
		{
			AIXMLHelper::GetXercesString( pExpressionXML->getTagName( ), strAIXMLtagName );
		
			if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eExpressionElement ] )
			{
				const xercesc::DOMElement* pExpressionChild = pExpressionXML->getFirstElementChild( );

				while ( 0 != pExpressionChild )
				{
					AIXMLHelper::GetXercesString( pExpressionChild->getTagName( ), strAIXMLtagName );

					if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eRelOpElement ] )
					{
						Atlas::AtlasBooleanExpression* pBooleanExpression = 0;
							
						try
						{
							pBooleanExpression = new Atlas::AtlasBooleanExpression;
						}
						catch ( ... )
						{
							throw Exception( Exception::eFailedToCreateBooleanExpressionObject, __FILE__, __FUNCTION__, __LINE__ );
						}

						pExpression->Set( pBooleanExpression );

						ProcessBooleanOperator( pExpressionChild, pBooleanExpression );
					}
					else if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eCompareOpElement ] )
					{
						Atlas::AtlasCompareExpression* pCompareExpression = 0;
							
						try
						{
							pCompareExpression = new Atlas::AtlasCompareExpression;
						}
						catch ( ... )
						{
							throw Exception( Exception::eFailedToCreateCompareExpressionObject, __FILE__, __FUNCTION__, __LINE__ );
						}

						pExpression->Set( pCompareExpression );

						ProcessCompareOperator( pExpressionChild, pCompareExpression );
					}
					else if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eBooleanOpElement ] )
					{
						Atlas::AtlasBitwiseExpression* pBitwiseExpression = 0;
							
						try
						{
							pBitwiseExpression = new Atlas::AtlasBitwiseExpression;
						}
						catch ( ... )
						{
							throw Exception( Exception::eFailedToCreateBitwiseExpressionObject, __FILE__, __FUNCTION__, __LINE__ );
						}

						pExpression->Set( pBitwiseExpression );

						ProcessBooleanOperator( pExpressionChild, pBitwiseExpression );
					}
					else if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eArithOpElement ] )
					{
						Atlas::AtlasArithmeticExpression* pArithmeticExpression = 0;
							
						try
						{
							pArithmeticExpression = new Atlas::AtlasArithmeticExpression;
						}
						catch ( ... )
						{
							throw Exception( Exception::eFailedToCreateArithmeticExpressionObject, __FILE__, __FUNCTION__, __LINE__ );
						}

						pExpression->Set( pArithmeticExpression );

						ProcessArithmeticOperator( pExpressionChild, pArithmeticExpression );
					}
					else if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eBooleanElement ] )
					{
						pExpression->Set( GetBoolean( pExpressionChild ) );
					}
					else if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eUnaryOpElement ] )
					{
						pExpression->Set( GetUnaryOp( pExpressionChild, 0 ) );
					}
					else if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eVariableElement ] )
					{
						pExpression->Set( GetVariable( pExpressionChild, 0, false ) );
					}
					else if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eVariableWSElement ] ) // [W]ith [S]ubscript
					{
						pExpression->Set( GetVariable( pExpressionChild, 0, true ) );
					}
					else if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eConstantElement ] )
					{
						pExpression->Set( GetConstant( pExpressionChild, 0 ) );
					}
					else if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eKeywordElement ] )
					{
						pExpression->Set( GetKeyword( pExpressionChild, 0 ) );
					}
					else if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eEnumElement ] )
					{
						pExpression->Set( GetKeyword( pExpressionChild, 0 ) );
					}
					else if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eStringElement ] )
					{
						pExpression->Set( GetString( pExpressionChild, 0 ) );
					}
					else if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eFunctionElement ] )
					{
						pExpression->Set( GetFunction( pExpressionChild, 0 ) );
					}
					#if ( _DEBUG ) && ( WIN32 )
					else
					{
						DebugBreak( );
					}
					#endif

					pExpressionChild = pExpressionChild->getNextElementSibling( );
				}
			}
			#if ( _DEBUG ) && ( WIN32 )
			else
			{
				DebugBreak( );
			}
			#endif
		}
		#if ( _DEBUG ) && ( WIN32 )
		else
		{
			DebugBreak( );
		}
		#endif
	}
}

void AtlasCondition::ProcessExpression( const xercesc::DOMElement* pAIXMLvalue, ForSequenceExpression* pForExpression )
{
	if ( 0 != pAIXMLvalue )
	{
		const xercesc::DOMElement* pExpressionXML = pAIXMLvalue->getFirstElementChild( );
	
		if ( 0 != pExpressionXML )
		{
			string strAIXMLtagName;
			AIXMLHelper::GetXercesString( pExpressionXML->getTagName( ), strAIXMLtagName );

			if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eVariableElement ] )
			{
				pForExpression->SetVariable( GetVariable( pExpressionXML, 0, false ) );
			}
			else if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eVariableWSElement ] ) // [W]ith [S]ubscript
			{
				pForExpression->SetVariable( GetVariable( pExpressionXML, 0, true ) );
			}
			#if ( _DEBUG ) && ( WIN32 )
			else
			{
				DebugBreak( );
			}
			#endif

			pExpressionXML = pExpressionXML->getNextElementSibling( );

			if ( 0 != pExpressionXML )
			{
				AIXMLHelper::GetXercesString( pExpressionXML->getTagName( ), strAIXMLtagName );
	
				if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eRangeElement ] )
				{
					const xercesc::DOMElement* pRange = pExpressionXML->getFirstElementChild( );
					string strKeyword;

					while ( 0 != pRange )
					{
						AIXMLHelper::GetXercesString( pRange->getTagName( ), strAIXMLtagName );

						if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eKeywordElement ] )
						{
							strKeyword.clear( );

							const DOMAttr* pAttr = pRange->getAttributeNode( AIXMLHelper::GetWString( AIXML::m_arrayXMLKeyWords[ AIXML::eWordAttribute ] ).c_str( ) );
					
							if ( 0 != pAttr )
							{
								AIXMLHelper::GetXercesString( pAttr->getValue( ), strKeyword );
							}
						}
						else if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eExpressionElement ] )
						{
							const xercesc::DOMElement* pExpression = pRange->getFirstElementChild( );

							if ( 0 != pExpression )
							{
								AIXMLHelper::GetXercesString( pExpression->getTagName( ), strAIXMLtagName );
								Atlas::AtlasTerm* pTerm = 0;

								if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eVariableElement ] )
								{
									pTerm = GetVariable( pExpression, 0, false );
								}
								else if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eVariableWSElement ] ) // [W]ith [S]ubscript
								{
									pTerm = GetVariable( pExpression, 0, true );
								}
								else if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eConstantElement ] )
								{
									pTerm = GetConstant( pExpression, 0 );
								}
								else if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eUnaryOpElement ] )
								{
									pTerm = GetUnaryOp( pExpression, 0 );
								}
								else if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eArithOpElement ] )
								{
									try
									{
										pTerm = new Atlas::AtlasArithmeticExpression;
									}
									catch ( ... )
									{
										throw Exception( Exception::eFailedToCreateArithmeticExpressionObject, __FILE__, __FUNCTION__, __LINE__ );
									}

									ProcessArithmeticOperator( pExpression, ( Atlas::AtlasArithmeticExpression* ) pTerm );
								}
								#if ( _DEBUG ) && ( WIN32 )
								else
								{
									DebugBreak( );
								}
								#endif

								if ( 0 != pTerm )
								{
									if ( strKeyword.empty( ) )
									{
										pForExpression->SetStartValue( pTerm );
									}
									else if ( "THRU" == strKeyword )
									{
										pForExpression->SetEndValue( pTerm );
									}
									else if ( "BY" == strKeyword )
									{
										pForExpression->SetByValue( pTerm );
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
						#if ( _DEBUG ) && ( WIN32 )
						else
						{
							DebugBreak( );
						}
						#endif

						pRange = pRange->getNextElementSibling( );
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
	}
}

void AtlasCondition::ProcessExpression( const xercesc::DOMElement* pAIXMLvalue, ForListExpression* pForExpression )
{
	if ( 0 != pAIXMLvalue )
	{
		const xercesc::DOMElement* pExpressionXML = pAIXMLvalue->getFirstElementChild( );
	
		if ( 0 != pExpressionXML )
		{
			string strAIXMLtagName;
			AIXMLHelper::GetXercesString( pExpressionXML->getTagName( ), strAIXMLtagName );

			if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eVariableElement ] )
			{
				pForExpression->SetVariable( GetVariable( pExpressionXML, 0, false ) );
			}
			else if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eVariableWSElement ] ) // [W]ith [S]ubscript
			{
				pForExpression->SetVariable( GetVariable( pExpressionXML, 0, true ) );
			}
			#if ( _DEBUG ) && ( WIN32 )
			else
			{
				DebugBreak( );
			}
			#endif

			pExpressionXML = pExpressionXML->getNextElementSibling( );

			if ( 0 != pExpressionXML )
			{
				AIXMLHelper::GetXercesString( pExpressionXML->getTagName( ), strAIXMLtagName );
	
				if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eRangeListElement ] )
				{
					const xercesc::DOMElement* pRangeList = pExpressionXML->getFirstElementChild( );
					string strKeyword;

					while ( 0 != pRangeList )
					{
						AIXMLHelper::GetXercesString( pRangeList->getTagName( ), strAIXMLtagName );

						if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eExpressionElement ] )
						{
							const xercesc::DOMElement* pExpression = pRangeList->getFirstElementChild( );

							if ( 0 != pExpression )
							{
								AIXMLHelper::GetXercesString( pExpression->getTagName( ), strAIXMLtagName );
								Atlas::AtlasTerm* pTerm = 0;

								if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eVariableElement ] )
								{
									pTerm = GetVariable( pExpression, 0, false );
								}
								else if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eVariableWSElement ] ) // [W]ith [S]ubscript
								{
									pTerm = GetVariable( pExpression, 0, true );
								}
								else if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eConstantElement ] )
								{
									pTerm = GetConstant( pExpression, 0 );
								}
								else if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eUnaryOpElement ] )
								{
									pTerm = GetUnaryOp( pExpression, 0 );
								}
								else if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eArithOpElement ] )
								{
									try
									{
										pTerm = new Atlas::AtlasArithmeticExpression;
									}
									catch ( ... )
									{
										throw Exception( Exception::eFailedToCreateArithmeticExpressionObject, __FILE__, __FUNCTION__, __LINE__ );
									}

									ProcessArithmeticOperator( pExpression, ( Atlas::AtlasArithmeticExpression* ) pTerm );
								}
								#if ( _DEBUG ) && ( WIN32 )
								else
								{
									DebugBreak( );
								}
								#endif

								if ( 0 != pTerm )
								{
									pForExpression->SetListItem( pTerm );
								}
								#if ( _DEBUG ) && ( WIN32 )
								else
								{
									DebugBreak( );
								}
								#endif
							}
						}

						pRangeList = pRangeList->getNextElementSibling( );
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
	}
}

void AtlasCondition::ProcessCompareOperator( const xercesc::DOMElement* pCompareOp, Atlas::AtlasCompareExpression* pCompareExpression )
{
	if ( 0 != pCompareOp )
	{
		string strAIXMLtagName;
		const DOMAttr* pAttr = pCompareOp->getAttributeNode( AIXMLHelper::GetWString( AIXML::m_arrayXMLKeyWords[ AIXML::eOperatorAttribute ] ).c_str( ) );

		if ( 0 != pAttr )
		{
			string strOperator;

			AIXMLHelper::GetXercesString( pAttr->getValue( ), strOperator );

			const Atlas::AtlasCompareExpression::eCompareOperator eOp = Atlas::AtlasCompareExpression::GetOperator( strOperator );

			#if ( _DEBUG ) && ( WIN32 )
			if ( Atlas::AtlasCompareExpression::eUnknownCompareOperator == eOp )
			{
				DebugBreak( );
			}
			#endif

			pCompareExpression->SetOperator( eOp );
		}

		const xercesc::DOMElement* pCompareOpChild = pCompareOp->getFirstElementChild( );
	
		while ( 0 != pCompareOpChild )
		{
			AIXMLHelper::GetXercesString( pCompareOpChild->getTagName( ), strAIXMLtagName );
		
			if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eArithOpElement ] )
			{
				Atlas::AtlasArithmeticExpression* pArithmeticExpression = 0;
					
				try
				{
					pArithmeticExpression = new Atlas::AtlasArithmeticExpression;
				}
				catch ( ... )
				{
					throw Exception( Exception::eFailedToCreateArithmeticExpressionObject, __FILE__, __FUNCTION__, __LINE__ );
				}

				if ( 0 == pCompareExpression->GetLeftExp( false ) )
				{
					pCompareExpression->SetLeftExp( pArithmeticExpression );
				}
				else
				{
					pCompareExpression->SetRightExp( pArithmeticExpression );
				}

				ProcessArithmeticOperator( pCompareOpChild, pArithmeticExpression );
			}
			else if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eVariableElement ] )
			{
				GetVariable( pCompareOpChild, pCompareExpression, false );
			}
			else if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eVariableWSElement ] ) // [W]ith [S]ubscript
			{
				GetVariable( pCompareOpChild, pCompareExpression, true );
			}
			else if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eConstantElement ] )
			{
				GetConstant( pCompareOpChild, pCompareExpression );
			}
			else if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eUnaryOpElement ] )
			{
				GetUnaryOp( pCompareOpChild, pCompareExpression );
			}
			else if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eFunctionElement ] )
			{
				GetFunction( pCompareOpChild, pCompareExpression );
			}
			else if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eStringElement ] )
			{
				GetString( pCompareOpChild, pCompareExpression );
			}
			else if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eRelOpElement ] )
			{
				Atlas::AtlasBooleanExpression* pBooleanExpression = 0;

				try
				{
					pBooleanExpression = new Atlas::AtlasBooleanExpression;
				}
				catch ( ... )
				{
					throw Exception( Exception::eFailedToCreateBooleanExpressionObject, __FILE__, __FUNCTION__, __LINE__ );
				}

				if ( 0 == pCompareExpression->GetLeftExp( false ) )
				{
					pCompareExpression->SetLeftExp( pBooleanExpression );
				}
				else
				{
					pCompareExpression->SetRightExp( pBooleanExpression );
				}

				ProcessBooleanOperator( pCompareOpChild, pBooleanExpression );
			}
			else if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eBooleanOpElement ] )
			{
				Atlas::AtlasBitwiseExpression* pBitwiseExpression = 0;
				
				try
				{
					pBitwiseExpression = new Atlas::AtlasBitwiseExpression;
				}
				catch ( ... )
				{
					throw Exception( Exception::eFailedToCreateBitwiseExpressionObject, __FILE__, __FUNCTION__, __LINE__ );
				}

				if ( 0 == pCompareExpression->GetLeftExp( false ) )
				{
					pCompareExpression->SetLeftExp( pBitwiseExpression );
				}
				else
				{
					pCompareExpression->SetRightExp( pBitwiseExpression );
				}

				ProcessBooleanOperator( pCompareOpChild, pBitwiseExpression );
			}
			#if ( _DEBUG ) && ( WIN32 )
			else
			{
				DebugBreak( );
			}
			#endif

			pCompareOpChild = pCompareOpChild->getNextElementSibling( );
		}
	}
}

void AtlasCondition::ProcessBooleanOperator( const xercesc::DOMElement* pBooleanOp, Atlas::AtlasBooleanExpression* pBooleanExp )
{
	if ( 0 != pBooleanOp )
	{
		string strAIXMLtagName;
		const DOMAttr* pAttr = pBooleanOp->getAttributeNode( AIXMLHelper::GetWString( AIXML::m_arrayXMLKeyWords[ AIXML::eOperatorAttribute ] ).c_str( ) );
		if ( 0 != pAttr )
		{
			string strOperator;

			AIXMLHelper::GetXercesString( pAttr->getValue( ), strOperator );

			const Atlas::AtlasBooleanExpression::eBooleanOperator eOp = Atlas::AtlasBooleanExpression::GetOperator( strOperator );

			#if ( _DEBUG ) && ( WIN32 )
			if ( Atlas::AtlasBooleanExpression::eUnknownLogicalOperator == eOp )
			{
				DebugBreak( );
			}
			#endif

			pBooleanExp->SetOperator( eOp );
		}

		const xercesc::DOMElement* pBooleanOpChild = pBooleanOp->getFirstElementChild( );

		while ( 0 != pBooleanOpChild )
		{
			AIXMLHelper::GetXercesString( pBooleanOpChild->getTagName( ), strAIXMLtagName );
		
			if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eRelOpElement ] )
			{
				Atlas::AtlasBooleanExpression* pBooleanExpression = 0;
					
				try
				{
					pBooleanExpression = new Atlas::AtlasBooleanExpression;
				}
				catch ( ... )
				{
					throw Exception( Exception::eFailedToCreateBooleanExpressionObject, __FILE__, __FUNCTION__, __LINE__ );
				}

				if ( 0 == pBooleanExp->GetLeftExp( false ) )
				{
					pBooleanExp->SetLeftExp( pBooleanExpression );
				}
				else
				{
					pBooleanExp->SetRightExp( pBooleanExpression );
				}

				ProcessBooleanOperator( pBooleanOpChild, pBooleanExpression );
			}
			else if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eVariableElement ] )
			{
				GetVariable( pBooleanOpChild, pBooleanExp, false );
			}
			else if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eVariableWSElement ] ) // [W]ith [S]ubscript
			{
				GetVariable( pBooleanOpChild, pBooleanExp, true );
			}
			else if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eConstantElement ] )
			{
				GetConstant( pBooleanOpChild, pBooleanExp );
			}
			else if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eUnaryOpElement ] )
			{
				GetUnaryOp( pBooleanOpChild, pBooleanExp );
			}
			else if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eKeywordElement ] )
			{
				GetKeyword( pBooleanOpChild, pBooleanExp );
			}
			else if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eBooleanOpElement ] )
			{
				Atlas::AtlasBitwiseExpression* pBitwiseExpression = 0;
				
				try
				{
					pBitwiseExpression = new Atlas::AtlasBitwiseExpression;
				}
				catch ( ... )
				{
					throw Exception( Exception::eFailedToCreateBitwiseExpressionObject, __FILE__, __FUNCTION__, __LINE__ );
				}

				if ( 0 == pBooleanExp->GetLeftExp( false ) )
				{
					pBooleanExp->SetLeftExp( pBitwiseExpression );
				}
				else
				{
					pBooleanExp->SetRightExp( pBitwiseExpression );
				}

				ProcessBooleanOperator( pBooleanOpChild, pBitwiseExpression );
			}
			#if ( _DEBUG ) && ( WIN32 )
			else
			{
				DebugBreak( );
			}
			#endif

			pBooleanOpChild = pBooleanOpChild->getNextElementSibling( );
		}
	}
}

void AtlasCondition::ProcessArithmeticOperator( const xercesc::DOMElement* pArithOp, Atlas::AtlasArithmeticExpression* pArithExp )
{
	if ( 0 != pArithOp )
	{
		string strAIXMLtagName;
		const DOMAttr* pAttr = pArithOp->getAttributeNode( AIXMLHelper::GetWString( AIXML::m_arrayXMLKeyWords[ AIXML::eOperatorAttribute ] ).c_str( ) );

		if ( 0 != pAttr )
		{
			string strOperator;

			AIXMLHelper::GetXercesString( pAttr->getValue( ), strOperator );

			const Atlas::AtlasArithmeticExpression::eMathOperator eOp = Atlas::AtlasArithmeticExpression::GetOperator( strOperator );

			#if ( _DEBUG ) && ( WIN32 )
			if ( Atlas::AtlasArithmeticExpression::eUnknownMathOperator == eOp )
			{
				DebugBreak( );
			}
			#endif

			pArithExp->SetOperator( eOp );
		}

		const xercesc::DOMElement* pArithOpChild = pArithOp->getFirstElementChild( );

		while ( 0 != pArithOpChild )
		{
			AIXMLHelper::GetXercesString( pArithOpChild->getTagName( ), strAIXMLtagName );
				
			if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eArithOpElement ] )
			{
				Atlas::AtlasArithmeticExpression* pArithmeticExpression = 0;
					
				try
				{
					pArithmeticExpression = new Atlas::AtlasArithmeticExpression;
				}
				catch ( ... )
				{
					throw Exception( Exception::eFailedToCreateArithmeticExpressionObject, __FILE__, __FUNCTION__, __LINE__ );
				}

				if ( 0 == pArithmeticExpression )
				{
					throw Exception( Exception::eFailedToCreateArithmeticExpressionObject, __FILE__, __FUNCTION__, __LINE__ );
				}

				if ( 0 == pArithExp->GetLeftExp( false ) )
				{
					pArithExp->SetLeftExp( pArithmeticExpression );
				}
				else
				{
					pArithExp->SetRightExp( pArithmeticExpression );
				}

				ProcessArithmeticOperator( pArithOpChild, pArithmeticExpression );
			}
			else if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eVariableElement ] )
			{
				GetVariable( pArithOpChild, pArithExp, false );
			}
			else if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eVariableWSElement ] )
			{
				GetVariable( pArithOpChild, pArithExp, true );
			}
			else if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eConstantElement ] )
			{
				GetConstant( pArithOpChild, pArithExp );
			}
			else if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eFunctionElement ] )
			{
				GetFunction( pArithOpChild, pArithExp );
			}
			else if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eUnaryOpElement ] )
			{
				GetUnaryOp( pArithOpChild, pArithExp );
			}
			#if ( _DEBUG ) && ( WIN32 )
			else
			{
				DebugBreak( );
			}
			#endif

			pArithOpChild = pArithOpChild->getNextElementSibling( );
		}
	}
}

Atlas::AtlasTermBase* AtlasCondition::GetBoolean( const xercesc::DOMElement* pBooleanOp )
{
	const xercesc::DOMElement* pBooleanChild = pBooleanOp->getFirstElementChild( );
	Atlas::AtlasLimitTerm* pBooleanExp = 0;

	if ( 0 != pBooleanChild )
	{
		string strAIXMLtagName;
		const DOMAttr* pAttr = 0;
		Atlas::AtlasTerm* pTerm = 0;

		AIXMLHelper::GetXercesString( pBooleanChild->getTagName( ), strAIXMLtagName );

		if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eVariableElement ] )
		{
			pTerm = GetVariable( pBooleanChild, 0, false );

			try
			{
				pBooleanExp = new Atlas::AtlasLimitTerm;
			}
			catch ( ... )
			{
				throw Exception( Exception::eFailedToCreateLimitTermObject, __FILE__, __FUNCTION__, __LINE__ );
			}

			pBooleanExp->SetLimitNumber( pTerm );
		}
		else if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eVariableWSElement ] )
		{
			pTerm = GetVariable( pBooleanChild, 0, true );

			try
			{
				pBooleanExp = new Atlas::AtlasLimitTerm;
			}
			catch ( ... )
			{
				throw Exception( Exception::eFailedToCreateLimitTermObject, __FILE__, __FUNCTION__, __LINE__ );
			}

			pBooleanExp->SetLimitNumber( pTerm );
		}
			#if ( _DEBUG ) && ( WIN32 )
		else
		{
			DebugBreak( );
		}
		#endif

		if ( 0 != pBooleanExp )
		{
			pBooleanChild = pBooleanChild->getNextElementSibling( );
	
			if ( 0 != pBooleanChild )
			{
				AIXMLHelper::GetXercesString( pBooleanChild->getTagName( ), strAIXMLtagName );

				if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eNominalElement ] )
				{
					const xercesc::DOMElement* pNominalChild = pBooleanChild->getFirstElementChild( );

					AIXMLHelper::GetXercesString( pNominalChild->getTagName( ), strAIXMLtagName );
		
					if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eVariableElement ] )
					{
						pBooleanExp->SetNominalLimit( GetVariable( pNominalChild, 0, false ) );
					}
					else if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eVariableWSElement ] )
					{
						pBooleanExp->SetNominalLimit( GetVariable( pNominalChild, 0, true ) );
					}
					else if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eConstantElement ] )
					{
						pBooleanExp->SetNominalLimit( GetConstant( pNominalChild, 0 ) );
					}
					#if ( _DEBUG ) && ( WIN32 )
					else
					{
						DebugBreak( );
					}
					#endif

					pBooleanChild = pBooleanChild->getNextElementSibling( );
				}

				AIXMLHelper::GetXercesString( pBooleanChild->getTagName( ), strAIXMLtagName );

				const bool bUpLow = ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eUpLowLimitElement ] );
				const bool bLowUp = ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eLowUpLimitElement ] );
	
				if ( bUpLow || bLowUp )
				{
					const xercesc::DOMElement* pUplowlimitChild = pBooleanChild->getFirstElementChild( );
	
					if ( 0 != pUplowlimitChild )
					{
						for ( int i = 0; ( ( i < 2 ) && ( 0 != pUplowlimitChild ) ); ++i )
						{
							AIXMLHelper::GetXercesString( pUplowlimitChild->getTagName( ), strAIXMLtagName );
				
							if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eVariableElement ] )
							{
								pTerm = GetVariable( pUplowlimitChild, 0, false );
							}
							else if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eVariableWSElement ] )
							{
								pTerm = GetVariable( pUplowlimitChild, 0, true );
							}
							else if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eConstantElement ] )
							{
								pTerm = GetConstant( pUplowlimitChild, 0 );
							}
							#if ( _DEBUG ) && ( WIN32 )
							else
							{
								DebugBreak( );
							}
							#endif
	
							if ( 0 == i )
							{
								if ( bUpLow )
								{
									pBooleanExp->SetUpperLimit( pTerm );
								}
								else
								{
									pBooleanExp->SetLowerLimit( pTerm );
								}
							}
							else
							{
								if ( bUpLow )
								{
									pBooleanExp->SetLowerLimit( pTerm );
								}
								else
								{
									pBooleanExp->SetUpperLimit( pTerm );
								}
							}
	
							pUplowlimitChild = pUplowlimitChild->getNextElementSibling( );
						}
					}
				}
				#if ( _DEBUG ) && ( WIN32 )
				else
				{
					DebugBreak( );
				}
				#endif
	
				#if ( _DEBUG ) && ( WIN32 )
				if ( !pBooleanExp->IsValid( ) )
				{
					DebugBreak( );
				}
				#endif
			}
			#if ( _DEBUG ) && ( WIN32 )
			else
			{
				DebugBreak( );
			}
			#endif
		}
		#if ( _DEBUG ) && ( WIN32 )
		else
		{
			DebugBreak( );
		}
		#endif
	}

	return pBooleanExp;
}

void AtlasCondition::ProcessBooleanOperator( const xercesc::DOMElement* pBooleanOp, Atlas::AtlasBitwiseExpression* pBitwiseExpression )
{
	const xercesc::DOMElement* pBooleanChild = pBooleanOp->getFirstElementChild( );
	Atlas::AtlasLimitTerm* pBooleanOpExp = 0;

	if ( 0 != pBooleanOp )
	{
		string strAIXMLtagName;
		const DOMAttr* pAttr = pBooleanOp->getAttributeNode( AIXMLHelper::GetWString( AIXML::m_arrayXMLKeyWords[ AIXML::eOperatorAttribute ] ).c_str( ) );

		if ( 0 != pAttr )
		{
			string strOperator;

			AIXMLHelper::GetXercesString( pAttr->getValue( ), strOperator );

			const Atlas::AtlasBitwiseExpression::eBitwiseOperator eOp = Atlas::AtlasBitwiseExpression::GetOperator( strOperator );

			#if ( _DEBUG ) && ( WIN32 )
			if ( Atlas::AtlasBitwiseExpression::eUnknownBitwiseOperator == eOp )
			{
				DebugBreak( );
			}
			#endif

			pBitwiseExpression->SetOperator( eOp );
		}

		const xercesc::DOMElement* pBooleanOpChild = pBooleanOp->getFirstElementChild( );

		while ( 0 != pBooleanOpChild )
		{
			AIXMLHelper::GetXercesString( pBooleanOpChild->getTagName( ), strAIXMLtagName );
				
			if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eVariableElement ] )
			{
				GetVariable( pBooleanOpChild, pBitwiseExpression, false );
			}
			else if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eVariableWSElement ] )
			{
				GetVariable( pBooleanOpChild, pBitwiseExpression, true );
			}
			else if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eConstantElement ] )
			{
				GetConstant( pBooleanOpChild, pBitwiseExpression );
			}
			#if ( _DEBUG ) && ( WIN32 )
			else
			{
				DebugBreak( );
			}
			#endif

			pBooleanOpChild = pBooleanOpChild->getNextElementSibling( );
		}
	}
}

Atlas::AtlasTerm* AtlasCondition::GetConstant( const xercesc::DOMElement* pAIXMLvalue, Atlas::AtlasExpression* pExpression )
{
	const DOMAttr* pAttr = pAIXMLvalue->getAttributeNode( AIXMLHelper::GetWString( AIXML::m_arrayXMLKeyWords[ AIXML::eTextAttribute ] ).c_str( ) );
	Atlas::AtlasTerm* pTerm = 0;

	if ( 0 != pAttr )
	{
		string strConstant;

		AIXMLHelper::GetXercesString( pAttr->getValue( ), strConstant );

		if ( !strConstant.empty( ) )
		{
			pAttr = pAIXMLvalue->getAttributeNode( AIXMLHelper::GetWString( AIXML::m_arrayXMLKeyWords[ AIXML::eSignAttribute ] ).c_str( ) );
			if ( 0 != pAttr )
			{
				string strSign;
	
				AIXMLHelper::GetXercesString( pAttr->getValue( ), strSign );
	
				if ( 1 == strSign.size( ) )
				{
					if ( '-' == strSign[ 0 ] )
					{
						strConstant.insert( strConstant.begin( ), '-' );
					}
					else if ( '+' == strSign[ 0 ] )
					{
						strConstant.insert( strConstant.begin( ), '+' );
					}
					#if ( _DEBUG ) && ( WIN32 )
					else
					{
						DebugBreak( );
					}
					#endif
				}
				#if ( _DEBUG ) && ( WIN32 )
				else
				{
					DebugBreak( );
				}
				#endif
			}

			try
			{
				pTerm = new Atlas::AtlasTerm;
			}
			catch ( ... )
			{
				throw Exception( Exception::eFailedToCreateAtlasTermObject, __FILE__, __FUNCTION__, __LINE__ );
			}

			if ( 0 != pExpression )
			{
				if ( 0 == pExpression->GetLeftExp( false ) )
				{
					pExpression->SetLeftExp( pTerm );
				}
				else if ( 0 == pExpression->GetRightExp( false ) )
				{
					pExpression->SetRightExp( pTerm );
				}
				#if ( _DEBUG ) && ( WIN32 )
				else
				{
					DebugBreak( );
				}
				#endif
			}

			Atlas::AtlasNumber* pNumber = 0;
				
			try
			{
				pNumber = new Atlas::AtlasNumber( strConstant );
			}
			catch ( ... )
			{
				throw Exception( Exception::eFailedToCreateNumberObject, __FILE__, __FUNCTION__, __LINE__ );
			}

			pTerm->SetTerm( pNumber );

			GetDimension( pAIXMLvalue->getFirstElementChild( ), pNumber );
		}
		#if ( _DEBUG ) && ( WIN32 )
		else
		{
			DebugBreak( );
		}
		#endif
	}

	return pTerm;
}

bool AtlasCondition::GetDimension( const xercesc::DOMElement* pAIXMLvalue, Atlas::AtlasData* pData )
{
	bool bGotDimension = false;

	if ( ( 0 != pAIXMLvalue ) && ( 0 != pData ) )
	{
		//const xercesc::DOMElement* pDimension = pAIXMLvalue->getFirstElementChild( );
	
		if ( 0 != pAIXMLvalue )
		{
			string strAIXMLtagName;
	
			AIXMLHelper::GetXercesString( pAIXMLvalue->getTagName( ), strAIXMLtagName );
	
			if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eDimensionElement ] )
			{
				const DOMAttr* pAttr = pAIXMLvalue->getAttributeNode( AIXMLHelper::GetWString( AIXML::m_arrayXMLKeyWords[ AIXML::eTextAttribute ] ).c_str( ) );
			
				if ( 0 != pAttr )
				{
					string strDimension;
			
					AIXMLHelper::GetXercesString( pAttr->getValue( ), strDimension );
	
					if ( !strDimension.empty( ) )
					{
						pData->SetUnitOfMeasure( NounModifier::GetAtlasUnitOfMeasureByAlasUnit( strDimension, false ) );

						bGotDimension = pData->GetUnitOfMeasure( ).IsUnit( );
					}
				}
				#if ( _DEBUG ) && ( WIN32 )
				else
				{
					DebugBreak( );
				}
				#endif

				#if ( _DEBUG ) && ( WIN32 )
				if ( !bGotDimension )
				{
					DebugBreak( );
				}
				#endif
			}
			#if ( _DEBUG ) && ( WIN32 )
			else
			{
				DebugBreak( );
			}
			#endif
		}
	}

	return bGotDimension;
}

Atlas::AtlasTerm* AtlasCondition::GetVariable( const xercesc::DOMElement* pAIXMLvalue, Atlas::AtlasExpression* pExpression, const bool bSubscript )
{
	const xercesc::DOMElement* pVariableWSchild = pAIXMLvalue;
	Atlas::AtlasTerm* pTerm = 0;

	if ( bSubscript )
	{
		pVariableWSchild = pAIXMLvalue->getFirstElementChild( );
	}

	if ( 0 != pVariableWSchild )
	{
		const DOMAttr* pAttr = pVariableWSchild->getAttributeNode( AIXMLHelper::GetWString( AIXML::m_arrayXMLKeyWords[ AIXML::eNameAttribute ] ).c_str( ) );
		Atlas::AtlasData* pVariable = 0;

		if ( 0 != pAttr )
		{
			string strName;
	
			AIXMLHelper::GetXercesString( pAttr->getValue( ), strName );
	
			if ( !strName.empty( ) )
			{
				try
				{
					pTerm = new Atlas::AtlasTerm;
				}
				catch ( ... )
				{
					throw Exception( Exception::eFailedToCreateAtlasTermObject, __FILE__, __FUNCTION__, __LINE__ );
				}
	
				if ( 0 != pExpression )
				{
					if ( 0 == pExpression->GetLeftExp( false ) )
					{
						pExpression->SetLeftExp( pTerm );
					}
					else if ( 0 == pExpression->GetRightExp( false ) )
					{
						pExpression->SetRightExp( pTerm );
					}
					#if ( _DEBUG ) && ( WIN32 )
					else
					{
						DebugBreak( );
					}
					#endif
				}
	
				try
				{
					pVariable = new Atlas::AtlasData;
				}
				catch ( ... )
				{
					throw Exception( Exception::eFailedToCreateAtlasVariableObject, __FILE__, __FUNCTION__, __LINE__ );
				}
	
				pTerm->SetTerm( pVariable );
	
				pVariable->SetVariableName( strName );

				if ( !bSubscript )
				{
					GetDimension( pVariableWSchild->getFirstElementChild( ), pVariable );
				}
			}
		}

		if ( bSubscript )
		{
			if ( 0 != pTerm )
			{
				pVariableWSchild = pVariableWSchild->getNextElementSibling( );
	
				if ( 0 != pVariableWSchild )
				{
					string strAIXMLtagName;
	
					AIXMLHelper::GetXercesString( pVariableWSchild->getTagName( ), strAIXMLtagName );
	
					if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eSubscriptElement ] )
					{
						const xercesc::DOMElement* pSubscriptChild = pVariableWSchild->getFirstElementChild( );
	
						if ( 0 != pSubscriptChild )
						{
							const xercesc::DOMElement* pExpressionChild = pSubscriptChild->getFirstElementChild( );
	
							if ( 0 != pExpressionChild )
							{
								string strSubscript;

								while ( 0 != pExpressionChild )
								{
									AIXMLHelper::GetXercesString( pExpressionChild->getTagName( ), strAIXMLtagName );
					
									if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eVariableElement ] )
									{
										pAttr = pExpressionChild->getAttributeNode( AIXMLHelper::GetWString( AIXML::m_arrayXMLKeyWords[ AIXML::eNameAttribute ] ).c_str( ) );

										AIXMLHelper::GetXercesString( pAttr->getValue( ), strSubscript );

										Atlas::AtlasData* pSubscriptTerm = 0;
											
										try
										{
											pSubscriptTerm = new Atlas::AtlasData;
										}
										catch ( ... )
										{
											throw Exception( Exception::eFailedToCreateAtlasVariableObject, __FILE__, __FUNCTION__, __LINE__ );
										}
							
										pTerm->SetSubscriptTerm( pSubscriptTerm );
							
										pSubscriptTerm->SetVariableName( strSubscript );
									}
									else if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eConstantElement ] )
									{
										pAttr = pExpressionChild->getAttributeNode( AIXMLHelper::GetWString( AIXML::m_arrayXMLKeyWords[ AIXML::eTextAttribute ] ).c_str( ) );

										AIXMLHelper::GetXercesString( pAttr->getValue( ), strSubscript );

										Atlas::AtlasNumber* pSubscriptNumber = 0;
											
										try
										{
											pSubscriptNumber = new Atlas::AtlasNumber( strSubscript );
										}
										catch ( ... )
										{
											throw Exception( Exception::eFailedToCreateNumberObject, __FILE__, __FUNCTION__, __LINE__ );
										}
							
										pTerm->SetSubscriptTerm( pSubscriptNumber );
									}
									#if ( _DEBUG ) && ( WIN32 )
									else
									{
										DebugBreak( );
									}
									#endif

									if ( !strSubscript.empty( ) )
									{
										break;
									}

									pExpressionChild = pExpressionChild->getNextElementSibling( );
								}
							}
						}
					}
					#if ( _DEBUG ) && ( WIN32 )
					else
					{
						DebugBreak( );
					}
					#endif

					GetDimension( pVariableWSchild->getNextElementSibling( ), pVariable );
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

	return pTerm;
}

Atlas::AtlasTerm* AtlasCondition::GetKeyword( const xercesc::DOMElement* pAIXMLvalue, Atlas::AtlasExpression* pExpression )
{
	const DOMAttr* pAttr = pAIXMLvalue->getAttributeNode( AIXMLHelper::GetWString( AIXML::m_arrayXMLKeyWords[ AIXML::eWordAttribute ] ).c_str( ) );
	Atlas::AtlasTerm* pTerm = 0;

	if ( 0 == pAttr )
	{
		pAttr = pAIXMLvalue->getAttributeNode( AIXMLHelper::GetWString( AIXML::m_arrayXMLKeyWords[ AIXML::eTextAttribute ] ).c_str( ) );
	}

	if ( 0 != pAttr )
	{
		string strBuiltIn;

		AIXMLHelper::GetXercesString( pAttr->getValue( ), strBuiltIn );

		if ( !strBuiltIn.empty( ) )
		{
			try
			{
				pTerm = new Atlas::AtlasTerm;
			}
			catch ( ... )
			{
				throw Exception( Exception::eFailedToCreateAtlasTermObject, __FILE__, __FUNCTION__, __LINE__ );
			}

			if ( 0 != pExpression )
			{
				if ( 0 == pExpression->GetLeftExp( false ) )
				{
					pExpression->SetLeftExp( pTerm );
				}
				else if ( 0 == pExpression->GetRightExp( false ) )
				{
					pExpression->SetRightExp( pTerm );
				}
				#if ( _DEBUG ) && ( WIN32 )
				else
				{
					DebugBreak( );
				}
				#endif
			}

			Atlas::AtlasTerm::eBuiltIn eBuiltIn = Atlas::AtlasTerm::GetBuiltIn( strBuiltIn );

			#if ( _DEBUG ) && ( WIN32 )
			if ( Atlas::AtlasTerm::eUnknownBuiltIn == eBuiltIn )
			{
				DebugBreak( );
			}
			#endif

			pTerm->SetTerm( eBuiltIn );
		}
	}

	return pTerm;
}

Atlas::AtlasTerm* AtlasCondition::GetString( const xercesc::DOMElement* pAIXMLvalue, Atlas::AtlasExpression* pExpression )
{
	const DOMAttr* pAttr = pAIXMLvalue->getAttributeNode( AIXMLHelper::GetWString( AIXML::m_arrayXMLKeyWords[ AIXML::eTextAttribute ] ).c_str( ) );
	Atlas::AtlasTerm* pTerm = 0;

	if ( 0 != pAttr )
	{
		string strText;

		AIXMLHelper::GetXercesString( pAttr->getValue( ), strText );

		if ( !strText.empty( ) )
		{
			try
			{
				pTerm = new Atlas::AtlasTerm;
			}
			catch ( ... )
			{
				throw Exception( Exception::eFailedToCreateAtlasTermObject, __FILE__, __FUNCTION__, __LINE__ );
			}

			if ( 0 != pExpression )
			{
				if ( 0 == pExpression->GetLeftExp( false ) )
				{
					pExpression->SetLeftExp( pTerm );
				}
				else if ( 0 == pExpression->GetRightExp( false ) )
				{
					pExpression->SetRightExp( pTerm );
				}
				#if ( _DEBUG ) && ( WIN32 )
				else
				{
					DebugBreak( );
				}
				#endif
			}

			Atlas::AtlasString* pString = 0;
				
			try
			{
				pString = new Atlas::AtlasString( strText );
			}
			catch ( ... )
			{
				throw Exception( Exception::eFailedToCreateStringObject, __FILE__, __FUNCTION__, __LINE__ );
			}

			pTerm->SetTerm( pString );
		}
	}

	return pTerm;
}

Atlas::AtlasTerm* AtlasCondition::GetUnaryOp( const xercesc::DOMElement* pAIXMLvalue, Atlas::AtlasExpression* pExpression )
{
	const DOMAttr* pAttr = pAIXMLvalue->getAttributeNode( AIXMLHelper::GetWString( AIXML::m_arrayXMLKeyWords[ AIXML::eOperatorAttribute ] ).c_str( ) );
	Atlas::AtlasTerm* pTerm = 0;

	if ( 0 != pAttr )
	{
		string strOperator;
		char chSign = -1;

		AIXMLHelper::GetXercesString( pAttr->getValue( ), strOperator );

		if ( !strOperator.empty( ) )
		{
			const Atlas::AtlasTerm::eUnaryOperator eOp = Atlas::AtlasTerm::GetOperator( strOperator );

			if ( Atlas::AtlasTerm::eUnknownUnaryOperator == eOp )
			{
				if ( '-' == strOperator[ 0 ] )
				{
					chSign = '-';
				}
			}

			const xercesc::DOMElement* pUnaryOpChild = pAIXMLvalue->getFirstElementChild( );

			if ( 0 != pUnaryOpChild )
			{
				string strAIXMLtagName;

				AIXMLHelper::GetXercesString( pUnaryOpChild->getTagName( ), strAIXMLtagName );

				if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eVariableElement ] )
				{
					pTerm = GetVariable( pUnaryOpChild, pExpression, false );
				}
				else if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eVariableWSElement ] ) // [W]ith [S]ubscript
				{
					pTerm = GetVariable( pUnaryOpChild, pExpression, true );
				}
				else if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eConstantElement ] )
				{
					pTerm = GetConstant( pUnaryOpChild, pExpression );

					if ( -1 != chSign )
					{
						// Corrects an issue within the parser grammar.

						if ( 0 != pTerm )
						{
							Atlas::AtlasNumber* pNumber = dynamic_cast< Atlas::AtlasNumber* >( pTerm->GetTerm( false ) );

							if ( 0 != pNumber )
							{
								if ( !pNumber->IsNaN( ) )
								{
									string strNumber( pNumber->GetNumber( false ) );

									if ( !strNumber.empty( ) )
									{
										strNumber.insert( strNumber.begin( ), chSign );

										pNumber->Set( strNumber, pNumber->GetUnitOfMeasure( ) );
									}
								}
							}
						}
					}
				}
				else if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eKeywordElement ] )
				{
					pTerm = GetKeyword( pUnaryOpChild, pExpression );
				}
				else if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eArithOpElement ] )
				{
					try
					{
						pTerm = new Atlas::AtlasArithmeticExpression;
					}
					catch ( ... )
					{
						throw Exception( Exception::eFailedToCreateArithmeticExpressionObject, __FILE__, __FUNCTION__, __LINE__ );
					}

					if ( 0 != pExpression )
					{
						if ( 0 == pExpression->GetLeftExp( false ) )
						{
							pExpression->SetLeftExp( pTerm );
						}
						else
						{
							pExpression->SetRightExp( pTerm );
						}
					}

					ProcessArithmeticOperator( pUnaryOpChild, ( Atlas::AtlasArithmeticExpression* ) pTerm );
				}
				#if ( _DEBUG ) && ( WIN32 )
				else
				{
					DebugBreak( );
				}
				#endif

				if ( 0 != pTerm )
				{
					pTerm->SetOperator( eOp );
				}
			}
		}
	}

	return pTerm;
}

Atlas::AtlasTermBase* AtlasCondition::GetFunction( const xercesc::DOMElement* pAIXMLvalue, Atlas::AtlasExpression* pExpression )
{
	const DOMAttr* pAttr = pAIXMLvalue->getAttributeNode( AIXMLHelper::GetWString( AIXML::m_arrayXMLKeyWords[ AIXML::eNameAttribute ] ).c_str( ) );
	Atlas::AtlasTermBase* pRetTerm = 0;

	if ( 0 != pAttr )
	{
		string strFunction;

		AIXMLHelper::GetXercesString( pAttr->getValue( ), strFunction );

		if ( !strFunction.empty( ) )
		{
			const Atlas::AtlasMathFunction::eFunction eFN = Atlas::AtlasMathFunction::GetFunction( strFunction );

			#if ( _DEBUG ) && ( WIN32 )
			if ( Atlas::AtlasMathFunction::eUnknownFunction == eFN )
			{
				DebugBreak( );
			}
			#endif

			try
			{
				pRetTerm = new Atlas::AtlasMathFunction;
			}
			catch ( ... )
			{
				throw Exception( Exception::eFailedToCreateMathFunctionObject, __FILE__, __FUNCTION__, __LINE__ );
			}

			( ( Atlas::AtlasMathFunction* ) pRetTerm )->SetFunction( eFN );

			const xercesc::DOMElement* pFunctionChild = pAIXMLvalue->getFirstElementChild( );
		
			if ( 0 != pFunctionChild )
			{
				string strAIXMLtagName;

				AIXMLHelper::GetXercesString( pFunctionChild->getTagName( ), strAIXMLtagName );
		
				if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eArgumentsElement ] )
				{
					const xercesc::DOMElement* pArgumentsChild = pFunctionChild->getFirstElementChild( );

					if ( 0 != pArgumentsChild )
					{
						AIXMLHelper::GetXercesString( pArgumentsChild->getTagName( ), strAIXMLtagName );

						if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eExpressionElement ] )
						{
							const xercesc::DOMElement* pExpressionChild = pArgumentsChild->getFirstElementChild( );
		
							if ( 0 != pExpressionChild )
							{
								Atlas::AtlasTerm* pTerm = 0;
								AIXMLHelper::GetXercesString( pExpressionChild->getTagName( ), strAIXMLtagName );

								if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eVariableElement ] )
								{
									pTerm = GetVariable( pExpressionChild, 0, false );
								}
								else if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eVariableWSElement ] ) // [W]ith [S]ubscript
								{
									pTerm = GetVariable( pExpressionChild, 0, true );
								}
								else if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eConstantElement ] )
								{
									pTerm = GetConstant( pExpressionChild, 0 );
								}
								else if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eArithOpElement ] )
								{
									try
									{
										pTerm = new Atlas::AtlasArithmeticExpression;
									}
									catch ( ... )
									{
										throw Exception( Exception::eFailedToCreateArithmeticExpressionObject, __FILE__, __FUNCTION__, __LINE__ );
									}
			
									ProcessArithmeticOperator( pExpressionChild, ( Atlas::AtlasArithmeticExpression* ) pTerm );
								}
								#if ( _DEBUG ) && ( WIN32 )
								else
								{
									DebugBreak( );
								}
								#endif

								if ( 0 != pTerm )
								{
									( ( Atlas::AtlasMathFunction* ) pRetTerm )->SetTerm( pTerm );

									if ( 0 != pExpression )
									{
										if ( 0 == pExpression->GetLeftExp( false ) )
										{
											pExpression->SetLeftExp( ( Atlas::AtlasTerm* ) pRetTerm );
										}
										else if ( 0 == pExpression->GetRightExp( false ) )
										{
											pExpression->SetRightExp( ( Atlas::AtlasTerm* ) pRetTerm );
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
						}
					}
				}
			}
		}
	}

	return pRetTerm;
}

void AtlasCondition::ExpressionBase::ChangeBooleanExpToBitwiseExp( Atlas::AtlasTermBase** ppExpression )
{
	if ( 0 != *ppExpression )
	{
		if ( 0 != dynamic_cast< const Atlas::AtlasBooleanExpression* >( *ppExpression ) )
		{
			Atlas::AtlasBooleanExpression* pBooleanExpression = ( Atlas::AtlasBooleanExpression* ) *ppExpression;
			Atlas::AtlasBitwiseExpression* pBitwiseExpression = 0;
				
			try
			{
				pBitwiseExpression = new Atlas::AtlasBitwiseExpression;
			}
			catch ( ... )
			{
				throw Exception( Exception::eFailedToCreateBitwiseExpressionObject, __FILE__, __FUNCTION__, __LINE__ );
			}

			pBitwiseExpression->TransferBooleanExpression( *pBooleanExpression );

			delete *ppExpression;

			*ppExpression = pBitwiseExpression;
		}
	}
}

void AtlasCondition::Expression::Set( Atlas::AtlasTermBase* pTermBase )
{
	#if ( _DEBUG ) && ( WIN32 )
	if ( 0 != m_pExpression )
	{
		DebugBreak( );
	}
	#endif

	GarbageCollect( ); 
	
	m_pExpression = pTermBase;
}

void AtlasCondition::Expression::GarbageCollect( void )
{
	if ( 0 != m_pExpression )
	{
		delete m_pExpression;
		m_pExpression = 0;
	}
}

void AtlasCondition::ForExpression::SetValue( Atlas::AtlasTermBase* pValue, Atlas::AtlasTermBase** pp )
{
	#if ( _DEBUG ) && ( WIN32 )
	if ( 0 != *pp )
	{
		DebugBreak( );
	}
	#endif

	GarbageCollect( pp );

	*pp = pValue;
}

void AtlasCondition::ForExpression::GarbageCollect( void )
{
	GarbageCollect( &m_pVariable );
}

void AtlasCondition::ForExpression::GarbageCollect( Atlas::AtlasTermBase** pp )
{
	if ( 0 != *pp )
	{
		delete *pp;
		*pp = 0;
	}
}

void AtlasCondition::ForSequenceExpression::GarbageCollect( void )
{
	AtlasCondition::ForExpression::GarbageCollect( &m_pStartValue );
	AtlasCondition::ForExpression::GarbageCollect( &m_pEndValue );
	AtlasCondition::ForExpression::GarbageCollect( &m_pByValue );
}

void AtlasCondition::ForListExpression::GarbageCollect( void )
{
	const unsigned int uiSize = m_vectExpression.size( );

	if ( uiSize > 0 )
	{
		for ( unsigned int ui = 0; ui < uiSize; ++ui )
		{
			delete m_vectExpression[ ui ];
		}

		m_vectExpression.clear( );
	}
}

Atlas::AtlasTermBase* AtlasCondition::ForListExpression::GetListItem( const unsigned int uiPos ) const
{
	Atlas::AtlasTermBase* pTerm = 0;

	if ( uiPos < m_vectExpression.size( ) )
	{
		pTerm = m_vectExpression[ uiPos ];
	}

	return pTerm;
}

void AtlasCondition::Expression::ToXML( string& strXML, const XML::ElementName eParentElementName, const XML::ElementName eSingalTermElementName, const XML::AttributeValue eSingalTermAttributeValue ) const
{
	if ( 0 != m_pExpression )
	{
		if ( 0 != dynamic_cast< Atlas::AtlasMathFunction* >( m_pExpression ) )
		{
			strXML += XML::MakeOpenXmlElementWithChildren( eParentElementName, XML::MakeXmlAttributeNameValue( XML::anType, XML::avArithmeticFunction ) );

			m_pExpression->ToXML( strXML, XML::enUnknown );

			strXML += XML::MakeCloseXmlElementWithChildren( eParentElementName );
		}
		else if ( 0 != dynamic_cast< Atlas::AtlasBitwiseExpression* >( m_pExpression ) )
		{
			strXML += XML::MakeOpenXmlElementWithChildren( eParentElementName, XML::MakeXmlAttributeNameValue( XML::anType, XML::avBitwise ) );

			m_pExpression->ToXML( strXML, XML::enUnknown );

			strXML += XML::MakeCloseXmlElementWithChildren( eParentElementName );
		}
		else if ( 0 != dynamic_cast< Atlas::AtlasArithmeticExpression* >( m_pExpression ) )
		{
			strXML += XML::MakeOpenXmlElementWithChildren( eParentElementName, XML::MakeXmlAttributeNameValue( XML::anType, XML::avArithmetic ) );

			m_pExpression->ToXML( strXML, XML::enUnknown );

			strXML += XML::MakeCloseXmlElementWithChildren( eParentElementName );
		}
		else if ( 0 != dynamic_cast< Atlas::AtlasLimitTerm* >( m_pExpression ) )
		{
			strXML += XML::MakeOpenXmlElementWithChildren( eParentElementName, XML::MakeXmlAttributeNameValue( XML::anType, XML::avLimits ) );

			m_pExpression->ToXML( strXML, XML::enUnknown );

			strXML += XML::MakeCloseXmlElementWithChildren( eParentElementName );
		}
		else if ( 0 != dynamic_cast< Atlas::AtlasBooleanExpression* >( m_pExpression ) )
		{
			strXML += XML::MakeOpenXmlElementWithChildren( eParentElementName, XML::MakeXmlAttributeNameValue( XML::anType, XML::avBoolean ) );

			m_pExpression->ToXML( strXML, XML::enUnknown );

			strXML += XML::MakeCloseXmlElementWithChildren( eParentElementName );
		}
		else if ( 0 != dynamic_cast< Atlas::AtlasCompareExpression* >( m_pExpression ) )
		{
			strXML += XML::MakeOpenXmlElementWithChildren( eParentElementName, XML::MakeXmlAttributeNameValue( XML::anType, XML::avCompare ) );

			m_pExpression->ToXML( strXML, XML::enUnknown );

			strXML += XML::MakeCloseXmlElementWithChildren( eParentElementName );
		}
		else if ( 0 != dynamic_cast< Atlas::AtlasTerm* >( m_pExpression ) )
		{
			strXML += XML::MakeOpenXmlElementWithChildren( eParentElementName, XML::MakeXmlAttributeNameValue( XML::anType, eSingalTermAttributeValue ) );

			m_pExpression->ToXML( strXML, eSingalTermElementName );

			strXML += XML::MakeCloseXmlElementWithChildren( eParentElementName );
		}
		#if ( _DEBUG ) && ( WIN32 )
		else
		{
			DebugBreak( );
		}
		#endif
	}
}

XML::AttributeValue AtlasCondition::Expression::GetAssignmentType( void ) const
{
	XML::AttributeValue avType = XML::avUnknown;

	if ( 0 != m_pExpression )
	{
		if ( 0 != dynamic_cast< Atlas::AtlasMathFunction* >( m_pExpression ) )
		{
			avType = XML::avArithmeticFunction;
		}
		else if ( 0 != dynamic_cast< Atlas::AtlasBitwiseExpression* >( m_pExpression ) )
		{
			avType = XML::avBitwise;
		}
		else if ( 0 != dynamic_cast< Atlas::AtlasArithmeticExpression* >( m_pExpression ) )
		{
			avType = XML::avArithmetic;
		}
		else if ( 0 != dynamic_cast< Atlas::AtlasLimitTerm* >( m_pExpression ) )
		{
			avType = XML::avLimits;
		}
		else if ( 0 != dynamic_cast< Atlas::AtlasBooleanExpression* >( m_pExpression ) )
		{
			avType = XML::avBoolean;
		}
		else if ( 0 != dynamic_cast< Atlas::AtlasCompareExpression* >( m_pExpression ) )
		{
			avType = XML::avCompare;
		}
		else if ( 0 != dynamic_cast< Atlas::AtlasTerm* >( m_pExpression ) )
		{
			avType = XML::avAssign;
		}
		#if ( _DEBUG ) && ( WIN32 )
		else
		{
			DebugBreak( );
		}
		#endif
	}

	return avType;
}

string AtlasCondition::Expression::GetAssignValue_XML( const XML::ElementName eName ) const
{
	string strXML;

	if ( XML::avAssign == GetAssignmentType( ) )
	{
		if ( 0 != dynamic_cast< Atlas::AtlasTerm* >( m_pExpression ) )
		{
			strXML = ( ( Atlas::AtlasTerm* ) m_pExpression )->GetAssignValue_XML( eName );
		}
	}

	return strXML;
}

void AtlasCondition::ForSequenceExpression::ToXML( string& strXML, const XML::ElementName eParentElementName, const XML::ElementName eSingalTermElementName, const XML::AttributeValue eSingalTermAttributeValue ) const
{
	strXML += XML::MakeOpenXmlElementWithChildren( eParentElementName, XML::MakeXmlAttributeNameValue( XML::anType, XML::avSequence ) );

	ToXML( strXML, XML::enIterator, m_pVariable );
	ToXML( strXML, XML::enInitialize, m_pStartValue );
	ToXML( strXML, XML::enThru, m_pEndValue );
	ToXML( strXML, XML::enBy, m_pByValue );

	strXML += XML::MakeCloseXmlElementWithChildren( eParentElementName );

	#if ( _DEBUG ) && ( WIN32 )
		if ( 0 == m_pVariable )
		{
			DebugBreak( );
		}
	
		if ( 0 == m_pStartValue )
		{
			DebugBreak( );
		}
	
		if ( 0 == m_pEndValue )
		{
			DebugBreak( );
		}
	#endif
}

void AtlasCondition::ForSequenceExpression::ToXML( string& strXML, const XML::ElementName eName, Atlas::AtlasTermBase* pValue ) const
{
	if ( 0 != pValue )
	{
		if ( Atlas::AtlasTerm::GetRawClassName( ) == typeid( *pValue ).raw_name( ) )
		{
			pValue->ToXML( strXML, eName );
		}
		else
		{
			strXML += XML::MakeOpenXmlElementWithChildren( eName );

			pValue->ToXML( strXML, XML::enUnknown );

			strXML += XML::MakeCloseXmlElementWithChildren( eName );
		}
	}
}

void AtlasCondition::ForListExpression::ToXML( string& strXML, const XML::ElementName eParentElementName, const XML::ElementName eSingalTermElementName, const XML::AttributeValue eSingalTermAttributeValue ) const
{
	const unsigned int uiExpressions = m_vectExpression.size( );

	strXML += XML::MakeOpenXmlElementWithChildren( eParentElementName, XML::MakeXmlAttributeNameValue( XML::anType, XML::avList ) );

	if ( 0 != m_pVariable )
	{
		m_pVariable->ToXML( strXML, XML::enIterator );
	}

	if ( uiExpressions > 0 )
	{
		strXML += XML::MakeOpenXmlElementWithChildren( XML::enList, XML::MakeXmlAttributeNameValue( XML::anCount, uiExpressions ) );

		for ( unsigned int ui = 0; ui < uiExpressions; ++ui )
		{
			Atlas::AtlasTermBase* pTermBase = m_vectExpression[ ui ];

			if ( Atlas::AtlasTerm::GetRawClassName( ) == typeid( *pTermBase ).raw_name( ) )
			{
				Atlas::AtlasTerm* pTerm = ( Atlas::AtlasTerm* ) pTermBase;

				if ( pTerm->GetTerm( false )->IsVariableName( ) )
				{
					pTerm->ToXML( strXML, XML::enVariable );
				}
				else
				{
					pTerm->ToXML( strXML, XML::enConstant );
				}
			}
			else
			{
				pTermBase->ToXML( strXML, XML::enUnknown );
			}
		}

		strXML += XML::MakeCloseXmlElementWithChildren( XML::enList );
	}

	strXML += XML::MakeCloseXmlElementWithChildren( eParentElementName );

	#if ( _DEBUG ) && ( WIN32 )
		if ( 0 == m_pVariable )
		{
			DebugBreak( );
		}

		if ( 0 == m_vectExpression.size( ) )
		{
			DebugBreak( );
		}
	#endif
}

bool AtlasCondition::IsForSequenceExpression( const xercesc::DOMElement* pAIXMLvalue )
{
	bool bIsForSequenceExpression = false;

	if ( 0 != pAIXMLvalue )
	{
		const xercesc::DOMElement* pExpressionXML = pAIXMLvalue->getFirstElementChild( );
	
		if ( 0 != pExpressionXML )
		{
			pExpressionXML = pExpressionXML->getNextElementSibling( );

			if ( 0 != pExpressionXML )
			{
				string strAIXMLtagName;

				AIXMLHelper::GetXercesString( pExpressionXML->getTagName( ), strAIXMLtagName );
	
				if ( strAIXMLtagName == AIXML::m_arrayXMLKeyWords[ AIXML::eRangeElement ] )
				{
					bIsForSequenceExpression = true;
				}
			}
		}
	}

	return bIsForSequenceExpression;
}

void AtlasCondition::VerifyIfBitwiseExpression( void )
{ 
	VerifyIfBitwiseExpression( m_pExpression );
}

void AtlasCondition::VerifyIfBitwiseExpression( ExpressionBase* pExpression )
{
	if ( 0 != pExpression )
	{
		if ( 0 != dynamic_cast< const ForListExpression* >( pExpression ) )
		{
			VerifyIfBitwiseExpression( ( ( ForListExpression* ) pExpression )->GetVariable( ) );

			const unsigned int uiSize = ( ( ForListExpression* ) pExpression )->GetListItemCount( );

			for ( unsigned int ui = 0; ui < uiSize; ++ui )
			{
				VerifyIfBitwiseExpression( ( ( ForListExpression* ) pExpression )->GetListItem( ui ) );
			}
		}
		else if ( 0 != dynamic_cast< const ForSequenceExpression* >( pExpression ) )
		{
			VerifyIfBitwiseExpression( ( ( ForSequenceExpression* ) pExpression )->GetVariable( ) );
			VerifyIfBitwiseExpression( ( ( ForSequenceExpression* ) pExpression )->GetStartValue( ) );
			VerifyIfBitwiseExpression( ( ( ForSequenceExpression* ) pExpression )->GetEndValue( ) );
			VerifyIfBitwiseExpression( ( ( ForSequenceExpression* ) pExpression )->GetByValue( ) );
		}
		else
		{
			if ( VerifyIfBitwiseExpression( ( ( Expression* ) pExpression )->Get( ) ) )
			{
				( ( Expression* ) pExpression )->ChangeBooleanExpToBitwiseExp( );
			}
		}
	}
}


bool AtlasCondition::VerifyIfBitwiseExpression( Atlas::AtlasTermBase* pTermBase )
{
	bool bIsBooleanAsDigital = false;

	if ( 0 != pTermBase )
	{
		if ( 0 != dynamic_cast< const Atlas::AtlasBooleanExpression* >( pTermBase ) )
		{
			Atlas::AtlasTerm* pLeftTerm = ( ( Atlas::AtlasBooleanExpression* ) pTermBase )->GetLeftExp( false );
			Atlas::AtlasTerm* pRightTerm = ( ( Atlas::AtlasBooleanExpression* ) pTermBase )->GetRightExp( false );
			bool bLeftBitwise = false;
			bool bRightBitwise = false;

			if ( 0 != pLeftTerm )
			{
				if ( Atlas::AtlasTerm::GetRawClassName( ) == typeid( *pLeftTerm ).raw_name( ) )
				{
					Atlas::AtlasData* pLeft = ( ( Atlas::AtlasTerm* ) pLeftTerm )->GetTerm( false );

					bLeftBitwise = pLeft->IsBitwiseDataType( );
				}
				else
				{
					if ( 0 != dynamic_cast< const Atlas::AtlasBitwiseExpression* >( pLeftTerm ) )
					{
						bLeftBitwise = true;
					}
					else
					{
						bLeftBitwise = VerifyIfBitwiseExpression( pLeftTerm );
	
						if ( bLeftBitwise )
						{
							Atlas::AtlasBooleanExpression* pBooleanExpression = ( Atlas::AtlasBooleanExpression* ) pLeftTerm;
							Atlas::AtlasBitwiseExpression* pBitwiseExpression = 0;
								
							try
							{
								pBitwiseExpression = new Atlas::AtlasBitwiseExpression;
							}
							catch ( ... )
							{
								throw Exception( Exception::eFailedToCreateBitwiseExpressionObject, __FILE__, __FUNCTION__, __LINE__ );
							}
			
							pBitwiseExpression->TransferBooleanExpression( *pBooleanExpression );
			
							( ( Atlas::AtlasExpression* ) pTermBase )->SetLeftExp( pBitwiseExpression );
						}
					}
				}
			}

			if ( 0 != pRightTerm )
			{
				if ( Atlas::AtlasTerm::GetRawClassName( ) == typeid( *pRightTerm ).raw_name( ) )
				{
					Atlas::AtlasData* pRight = ( ( Atlas::AtlasTerm* ) pRightTerm )->GetTerm( false );

					bRightBitwise = pRight->IsBitwiseDataType( );
				}
				else
				{
					if ( 0 != dynamic_cast< const Atlas::AtlasBitwiseExpression* >( pLeftTerm ) )
					{
						bRightBitwise = true;
					}
					else
					{
						bRightBitwise = VerifyIfBitwiseExpression( pRightTerm );
	
						if ( bRightBitwise )
						{
							Atlas::AtlasBooleanExpression* pBooleanExpression = ( Atlas::AtlasBooleanExpression* ) pRightTerm;
							Atlas::AtlasBitwiseExpression* pBitwiseExpression = 0;
								
							try
							{
								pBitwiseExpression = new Atlas::AtlasBitwiseExpression;
							}
							catch ( ... )
							{
								throw Exception( Exception::eFailedToCreateBitwiseExpressionObject, __FILE__, __FUNCTION__, __LINE__ );
							}
			
							pBitwiseExpression->TransferBooleanExpression( *pBooleanExpression );
			
							( ( Atlas::AtlasExpression* ) pTermBase )->SetRightExp( pBitwiseExpression );
						}
					}
				}
			}

			if ( bLeftBitwise && bRightBitwise )
			{
				bIsBooleanAsDigital = true;
			}

			#if ( _DEBUG ) && ( WIN32 )
			if ( !bIsBooleanAsDigital && ( bLeftBitwise || bRightBitwise ) )
			{
				DebugBreak( );
			}
			#endif
		}
		else if ( 0 != dynamic_cast< const Atlas::AtlasExpression* >( pTermBase ) )
		{
			Atlas::AtlasTerm* pAtlasTermLeft = ( ( Atlas::AtlasExpression* ) pTermBase )->GetLeftExp( false );
			if ( VerifyIfBitwiseExpression( pAtlasTermLeft ) )
			{
				Atlas::AtlasBooleanExpression* pBooleanExpression = ( Atlas::AtlasBooleanExpression* ) pAtlasTermLeft;
				Atlas::AtlasBitwiseExpression* pBitwiseExpression = 0;
					
				try
				{
					pBitwiseExpression = new Atlas::AtlasBitwiseExpression;
				}
				catch ( ... )
				{
					throw Exception( Exception::eFailedToCreateBitwiseExpressionObject, __FILE__, __FUNCTION__, __LINE__ );
				}

				pBitwiseExpression->TransferBooleanExpression( *pBooleanExpression );

				( ( Atlas::AtlasExpression* ) pTermBase )->SetLeftExp( pBitwiseExpression );
			}

			Atlas::AtlasTerm* pAtlasTermRight = ( ( Atlas::AtlasExpression* ) pTermBase )->GetRightExp( false );
			if ( VerifyIfBitwiseExpression( pAtlasTermRight ) )
			{
				Atlas::AtlasBooleanExpression* pBooleanExpression = ( Atlas::AtlasBooleanExpression* ) pAtlasTermRight;
				Atlas::AtlasBitwiseExpression* pBitwiseExpression = 0;
					
				try
				{
					pBitwiseExpression = new Atlas::AtlasBitwiseExpression;
				}
				catch ( ... )
				{
					throw Exception( Exception::eFailedToCreateBitwiseExpressionObject, __FILE__, __FUNCTION__, __LINE__ );
				}

				pBitwiseExpression->TransferBooleanExpression( *pBooleanExpression );

				( ( Atlas::AtlasExpression* ) pTermBase )->SetRightExp( pBitwiseExpression );
			}
		}
		else if ( 0 != dynamic_cast< const Atlas::AtlasMathFunction* >( pTermBase ) )
		{
			VerifyIfBitwiseExpression( ( ( Atlas::AtlasMathFunction* ) pTermBase )->GetTerm( false ) );
		}
		else if ( 0 != dynamic_cast< const Atlas::AtlasLimitTerm* >( pTermBase ) )
		{
			VerifyIfBitwiseExpression( ( ( Atlas::AtlasLimitTerm* ) pTermBase )->GetLimitNumber( ) );
			VerifyIfBitwiseExpression( ( ( Atlas::AtlasLimitTerm* ) pTermBase )->GetLowerLimit( ) );
			VerifyIfBitwiseExpression( ( ( Atlas::AtlasLimitTerm* ) pTermBase )->GetUpperLimit( ) );
		}
		/*
		else
		{
			Atlas::AtlasData* pAtlasData = ( ( Atlas::AtlasTerm* ) pTermBase )->GetTerm( false );

			if ( 0 != pAtlasData )
			{
				if ( pAtlasData->IsVariableName( ) )
				{
				}
			}

			pAtlasData = ( ( Atlas::AtlasTerm* ) pTermBase )->GetSubscriptTerm( false );

			if ( 0 != pAtlasData )
			{
				if ( pAtlasData->IsVariableName( ) )
				{
				}
			}
		}
		*/
	}

	return bIsBooleanAsDigital;
}
