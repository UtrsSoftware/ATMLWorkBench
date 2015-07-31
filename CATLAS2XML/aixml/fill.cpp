/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

#include "fill.h"
#include "declare.h"
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


AtlasFill& AtlasFill::operator = ( const AtlasStatement& other )
{
	if ( this != &other )
	{
		AtlasStatement::operator = ( other );

		GarbageCollect( );

		const AtlasFill* pother = dynamic_cast< const AtlasFill* >( &other );

		if ( 0 != pother )
		{
		}
	}

	return *this;
}

void AtlasFill::Init( void )
{ 
	m_pVariableName = 0;
	m_pVariableValue = 0;
	m_pvectList = 0;
	m_uiNestId = 0;
}

void AtlasFill::GarbageCollect( void )
{ 
	if ( 0 != m_pVariableName )
	{
		delete m_pVariableName;
		m_pVariableName = 0;
	}

	if ( 0 != m_pVariableValue )
	{
		delete m_pVariableValue;
		m_pVariableValue = 0;
	}

	if ( 0 != m_pvectList )
	{
		const unsigned int uiSize = m_pvectList->size( );

		for ( unsigned int ui = 0; ui < uiSize; ++ui )
		{
			if ( 0 != m_pvectList->at( ui ).second )
			{
				delete m_pvectList->at( ui ).second;
			}
		}

		delete m_pvectList;
		m_pvectList = 0;
	}
}

void AtlasFill::InitFromXML( const StatementMetadata* pData, vector< AtlasStatement* >& vectNestedFills )
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

				ProcessXML( vectNestedFills );
			}
		}
	}
}

void AtlasFill::Process( const map< string, vector< AtlasDeclareData* >* >* pmapDeclares, const AtlasProcedure* pProcedure, const vector< pair< string, Atlas::AtlasSourceStatement::eSourceType > >* pvectAtlasSourceFiles, const Lookup* pLookup )
{
	const unsigned int uiSize = m_vectAttributes.size( );

	if ( uiSize > 0 )
	{
		if ( 0 != m_pvectList )
		{
			ProcessVector( uiSize, pmapDeclares, pProcedure, pvectAtlasSourceFiles );
		}
		else if ( 0 == m_pVariableName )
		{
			ProcessVariable( uiSize, pmapDeclares, pProcedure, pvectAtlasSourceFiles );
		}
		#if ( _DEBUG ) && ( WIN32 )
		else
		{
			DebugBreak( );
		}
		#endif
	}
}

void AtlasFill::ProcessXML( vector< AtlasStatement* >& vectNestedFills )
{
	const unsigned int uiSize = m_vectAttributes.size( );

	if ( uiSize > 0 )
	{
		unsigned int uiVariableCount = 0;
		bool bIsList = false;

		GetMetaData( uiSize, uiVariableCount, bIsList );

		if ( uiVariableCount > 1 )
		{
			for ( unsigned int ui = 1; ui < uiVariableCount; ++ui )
			{
				AtlasFill* pFill = 0;
					
				try
				{
					pFill = new AtlasFill;
				}
				catch ( ... )
				{
					throw Exception( Exception::eFailedToAllocateMemoryForAtlasFillObject, __FILE__, __FUNCTION__, __LINE__ );
				}

				vectNestedFills.push_back( pFill );

				pFill->InitSourceInfo( this );

				if ( bIsList )
				{
					try
					{
						pFill->m_pvectList = new vector< pair< pair< unsigned int, unsigned int >, Atlas::AtlasData* > >( );
					}
					catch ( ... )
					{
						throw Exception( Exception::eFailedToCreateVectorObject, __FILE__, __FUNCTION__, __LINE__ );
					}
				}
			}

			if ( bIsList )
			{
				ProcessListXML( uiSize, uiVariableCount, vectNestedFills );
			}
			else
			{
				ProcessStoreXML( uiSize, uiVariableCount, vectNestedFills );
			}

			const vector< const AtlasAttibuteValue* >::const_iterator itBegin = m_vectAttributes.begin( );

			for ( int i = ( int ) ( uiSize - 1 ); i > -1; --i )
			{
				if ( 0 == m_vectAttributes[ i ] )
				{
					m_vectAttributes.erase( itBegin + i );
				}
			}
		}

		if ( bIsList )
		{
			try
			{
				m_pvectList = new vector< pair< pair< unsigned int, unsigned int >, Atlas::AtlasData* > >( );
			}
			catch ( ... )
			{
				throw Exception( Exception::eFailedToCreateVectorObject, __FILE__, __FUNCTION__, __LINE__ );
			}
		}
	}
}

void AtlasFill::ProcessListXML( const unsigned int uiSize, const unsigned int uiVariableCount, vector< AtlasStatement* >& vectNestedFills )
{
	unsigned int ui;

	for ( ui = 0; ui < uiVariableCount; ++ui )
	{
		if ( ui > 0 )
		{
			( ( AtlasFill* ) vectNestedFills[ ui - 1 ] )->m_vectAttributes.push_back( m_vectAttributes[ ui ] );
			m_vectAttributes[ ui ] = 0;
		}
	}

	for ( ; ui < uiSize; ++ui )
	{
		if ( m_vectAttributes[ ui ]->IsDimension( ) )
		{
			for ( unsigned int ui2 = 1; ui2 < uiVariableCount; ++ui2 )
			{
				AtlasAttributes::AtlasAttibuteValue* pAttibuteValue = 0;
					
				try
				{
					pAttibuteValue = new AtlasAttributes::AtlasAttibuteValue( *( m_vectAttributes[ ui ] ) );
				}
				catch ( ... )
				{
					throw Exception( Exception::eFailedToCreateAttributeValueObject, __FILE__, __FUNCTION__, __LINE__ );
				}

				( ( AtlasFill* ) vectNestedFills[ ui2 - 1 ] )->m_vectAttributes.push_back( pAttibuteValue );
			}

			++ui;

			for ( unsigned int uiNestPos = 0; ui < uiSize; ++ui, ++uiNestPos )
			{
				if ( m_vectAttributes[ ui ]->IsDimension( ) )
				{
					ui = ( ui - 1 );
					break;
				}
				else
				{
					if ( uiNestPos > 0 )
					{
						( ( AtlasFill* ) vectNestedFills[ uiNestPos - 1 ] )->m_vectAttributes.push_back( m_vectAttributes[ ui ] );
						m_vectAttributes[ ui ] = 0;
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
	}
}

void AtlasFill::ProcessStoreXML( const unsigned int uiSize, const unsigned int uiVariableCount, vector< AtlasStatement* >& vectNestedFills )
{
	bool bVarNames = false;
	unsigned int ui;

	for ( ui = 0; ui < uiVariableCount; ++ui )
	{
		if ( ui > 0 )
		{
			( ( AtlasFill* ) vectNestedFills[ ui - 1 ] )->m_vectAttributes.push_back( m_vectAttributes[ ui ] );
			m_vectAttributes[ ui ] = 0;
		}
	}

	for ( unsigned int uiNestPos = 0; ui < uiSize; ++ui, ++uiNestPos )
	{
		if ( uiNestPos > 0 )
		{
			( ( AtlasFill* ) vectNestedFills[ uiNestPos - 1 ] )->m_vectAttributes.push_back( m_vectAttributes[ ui ] );
			m_vectAttributes[ ui ] = 0;
		}
	}
}

void AtlasFill::GetMetaData( const unsigned int uiSize, unsigned int& uiVariableCount, bool& bIsList )
{
	for ( unsigned int ui = 0; ui < uiSize; ++ui )
	{
		const AtlasAttibuteValue* pAttibuteValue = m_vectAttributes[ ui ];

		if ( pAttibuteValue->IsVariable( ) )
		{
			++uiVariableCount;
		}
		else
		{
			if ( pAttibuteValue->IsDimension( ) )
			{
				bIsList = true;
			}

			break;
		}
	}
}

unsigned int AtlasFill::GetStatementId( void ) const
{ 
	unsigned int uiRet = m_uiId;

	if ( 0 != m_uiNestId )
	{
		uiRet = m_uiNestId;
	}

	#if ( _DEBUG ) && ( WIN32 )
	if ( 0 == uiRet )
	{
		DebugBreak( );
	}
	#endif

	return uiRet;
}

Atlas::AtlasData* AtlasFill::GetData( const AtlasAttibuteValue* pValue, const bool bBoolAsBuiltIn )
{
	Atlas::AtlasData* pData = 0;

	if ( pValue->IsConstant( ) )
	{
		try
		{
			pData = new Atlas::AtlasNumber( pValue->m_strValue );
		}
		catch ( ... )
		{
			throw Exception( Exception::eFailedToCreateNumberObject, __FILE__, __FUNCTION__, __LINE__ );
		}
	}
	else if ( pValue->IsString( ) )
	{
		try
		{
			pData = new Atlas::AtlasString( pValue->m_strValue );
		}
		catch ( ... )
		{
			throw Exception( Exception::eFailedToCreateStringObject, __FILE__, __FUNCTION__, __LINE__ );
		}
	}
	else if ( pValue->IsKeyword( ) )
	{
		const bool bTrue = ( AtlasStatement::m_strTRUE == pValue->m_strValue );
		const bool bFalse = ( AtlasStatement::m_strFALSE == pValue->m_strValue );

		if ( bTrue || bFalse )
		{
			if ( bBoolAsBuiltIn )
			{
				try
				{
					pData = new Atlas::AtlasData( pValue->m_strValue );
				}
				catch ( ... )
				{
					throw Exception( Exception::eFailedToCreateAtlasVariableObject, __FILE__, __FUNCTION__, __LINE__ );
				}

				pData->SetAtlasDataType( Atlas::eBOOLEAN );
				pData->SetDataType( Atlas::AtlasData::eBoolean );
				pData->SetScopeType( Atlas::AtlasData::eBuiltIn );
				pData->SetBuiltInType( bTrue ? Atlas::AtlasData::eTrue : Atlas::AtlasData::eFalse );
			}
			else
			{
				try
				{
					pData = new Atlas::AtlasBool( bTrue ? true : false );
				}
				catch ( ... )
				{
					throw Exception( Exception::eFailedToCreateBoolObject, __FILE__, __FUNCTION__, __LINE__ );
				}
			}
		}
		else
		{
			const Atlas::eDataType eType = m_pVariableName->GetAtlasDataType( );

			if ( ( Atlas::eCONNECTION == eType ) || ( Atlas::eCONN == eType ) )
			{
				try
				{
					pData = new Atlas::AtlasConnector( pValue->m_strValue );
				}
				catch ( ... )
				{
					throw Exception( Exception::eFailedToCreateConnectorObject, __FILE__, __FUNCTION__, __LINE__ );
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
	#if ( _DEBUG ) && ( WIN32 )
	else
	{
		DebugBreak( );
	}
	#endif

	return pData;
}

void AtlasFill::SetDataType( const map< string, vector< AtlasDeclareData* >* >* pmapDeclares, const AtlasProcedure* pProcedure, const vector< pair< string, Atlas::AtlasSourceStatement::eSourceType > >* pvectAtlasSourceFiles )
{
	const string& strName = m_pVariableName->GetVariableName( );

	if ( 0 != pProcedure )
	{
		const AtlasDeclareData* pDeclareData = pProcedure->GetVariable( strName );

		if ( 0 != pDeclareData )
		{
			SetProcedureSymbolInfo( pDeclareData, m_pVariableName );
						
			#if ( _DEBUG ) && ( WIN32 )
			if ( pDeclareData->m_Declare.m_eDataType != m_pVariableName->GetAtlasDataType( ) )
			{
				DebugBreak( );
			}
			#endif
		}
		else
		{
			map< string, vector< AtlasDeclareData* >* >::const_iterator itDeclares;
			const map< string, vector< AtlasDeclareData* >* >::const_iterator itDeclaresEnd = pmapDeclares->end( );
	
			itDeclares = pmapDeclares->find( strName );
	
			if ( itDeclaresEnd != itDeclares )
			{
				SetDeclareSymbolInfo( GetSourceInfo( )->GetFilename( ), itDeclares->second, m_pVariableName, pvectAtlasSourceFiles );
			}
			#if ( _DEBUG ) && ( WIN32 )
			else
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

	#if ( _DEBUG ) && ( WIN32 )
	if ( Atlas::eUnknownDataType == m_pVariableName->GetAtlasDataType( ) )
	{
		DebugBreak( );
	}
	#endif
}

void AtlasFill::ProcessVector( const unsigned int uiSize, const map< string, vector< AtlasDeclareData* >* >* pmapDeclares, const AtlasProcedure* pProcedure, const vector< pair< string, Atlas::AtlasSourceStatement::eSourceType > >* pvectAtlasSourceFiles )
{
	if ( uiSize > 1 )
	{
		unsigned int uiPos = 0;
		unsigned int uiPosThru = 0;

		GetThruAllDataVectorRange( uiSize, uiPos, uiPosThru );

		#if ( _DEBUG ) && ( WIN32 )
		if ( 0 != m_pVariableName )
		{
			DebugBreak( );
		}
		#endif

		try
		{
			m_pVariableName = new Atlas::AtlasData;
		}
		catch ( ... )
		{
			throw Exception( Exception::eFailedToCreateAtlasVariableObject, __FILE__, __FUNCTION__, __LINE__ );
		}

		if ( 0 != m_pVariableName )
		{
			m_pVariableName->SetVariableName( m_vectAttributes[ 0 ]->m_strValue );
		}

		SetDataType( pmapDeclares, pProcedure, pvectAtlasSourceFiles );

		if ( uiPos > 0 )
		{
			for ( unsigned int ui = 4; ui < uiSize; ++ui )
			{
				const AtlasAttibuteValue* pAttibuteValue = m_vectAttributes[ ui ];

				if ( !pAttibuteValue->IsCharacter( ) )
				{
					Atlas::AtlasData* pData = GetData( pAttibuteValue, true );
	
					m_pvectList->push_back( make_pair( make_pair( uiPos, uiPos ), pData ) );

					++uiPos;
				}
				else
				{
					#if ( _DEBUG ) && ( WIN32 )
					if ( AtlasStatement::m_strAssign != pAttibuteValue->m_strValue )
					{
						DebugBreak( );
					}
					#endif
	
					continue;
				}
			}
		}
		else
		{
			for ( unsigned int ui = 1; ui < uiSize; ++ui )
			{
				const AtlasAttibuteValue* pAttibuteValue = m_vectAttributes[ ui ];
	
				if ( pAttibuteValue->IsDimension( ) )
				{
					if ( !pAttibuteValue->IsKeyword( ) )
					{
						if ( 0 == uiPos )
						{
							uiPos = AIXMLHelper::StringToNumber< unsigned int >( m_vectAttributes[ ui ]->m_strValue );
						}
						else if ( 0 == uiPosThru )
						{
							uiPosThru = AIXMLHelper::StringToNumber< unsigned int >( m_vectAttributes[ ui ]->m_strValue );
						}
					}
				}
				else if ( pAttibuteValue->IsCharacter( ) )
				{
					#if ( _DEBUG ) && ( WIN32 )
					if ( AtlasStatement::m_strAssign != pAttibuteValue->m_strValue )
					{
						DebugBreak( );
					}
					#endif
	
					uiPos = 0;
					uiPosThru = 0;
	
					continue;
				}
				else
				{
					#if ( _DEBUG ) && ( WIN32 )
					if ( 0 == uiPos )
					{
						DebugBreak( );
					}
					#endif
	
					Atlas::AtlasData* pData = GetData( m_vectAttributes[ ui ], true );
	
					if ( 0 == uiPosThru )
					{
						uiPosThru = uiPos;
					}
	
					m_pvectList->push_back( make_pair( make_pair( uiPos, uiPosThru ), pData ) );
	
					uiPos = 0;
					uiPosThru = 0;
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
}

void AtlasFill::ProcessVariable( const unsigned int uiSize, const map< string, vector< AtlasDeclareData* >* >* pmapDeclares, const AtlasProcedure* pProcedure, const vector< pair< string, Atlas::AtlasSourceStatement::eSourceType > >* pvectAtlasSourceFiles )
{
	if ( 2 == uiSize )
	{
		m_pVariableName = GetData( m_vectAttributes[ 1 ], false );

		if ( 0 != m_pVariableName )
		{
			m_pVariableName->SetVariableName( m_vectAttributes[ 0 ]->m_strValue );
			SetDataType( pmapDeclares, pProcedure, pvectAtlasSourceFiles );
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

void AtlasFill::GetThruAllDataVectorRange( const unsigned int uiSize, unsigned int& uiPos, unsigned int& uiPosThru )
{
	if ( uiSize > 4 )
	{
		unsigned int __uiPos = 0;
		unsigned int __uiPosThru = 0;
		unsigned int ui = 1;

		if ( m_vectAttributes[ ui ]->IsDimension( ) )
		{
			__uiPos = AIXMLHelper::StringToNumber< unsigned int >( m_vectAttributes[ ui++ ]->m_strValue );

			if ( __uiPos > 0 )
			{
				if ( m_vectAttributes[ ui++ ]->IsKeyword( ) )
				{
					if ( m_vectAttributes[ ui ]->IsDimension( ) )
					{
						__uiPosThru = AIXMLHelper::StringToNumber< unsigned int >( m_vectAttributes[ ui++ ]->m_strValue );

						if ( __uiPosThru >= __uiPos )
						{
							bool bAllData = true;
							unsigned int uiValues = 0;

							for ( ; ui < uiSize; ++ui )
							{
								const AtlasAttibuteValue* pAttibuteValue = m_vectAttributes[ ui ];

								if ( pAttibuteValue->IsKeyword( ) || pAttibuteValue->IsDimension( ) )
								{
									bAllData = false;
									break;
								}

								++uiValues;
							}

							if ( bAllData )
							{
								if ( uiValues > 1 )
								{
									uiPos = __uiPos;
									uiPosThru = __uiPosThru;
								}
							}
						}
					}
				}
			}
		}
	}
}

void AtlasFill::ToXML( string& strXML ) const
{
	if ( 0 != m_pVariableName )
	{
		const string strId( XML::MakeXmlAttributeNameValue( XML::anId, ( 0 == m_uiNestId ? m_uiId : m_uiNestId ) ) );
	
		strXML += XML::MakeOpenXmlElementWithChildren( XML::enFill, strId, GetStatementCommentRefId_XML( ) );
	
		unsigned int uiSize = m_vectAtlasSourceStatement.size( );
		if ( uiSize > 0 )
		{
			unsigned int uiFields = Atlas::AtlasSourceStatement::eXmlFilename;
	
			uiFields |= Atlas::AtlasSourceStatement::eXmlStatementNumber;
			uiFields |= Atlas::AtlasSourceStatement::eXmlLineNumber;
			uiFields |= Atlas::AtlasSourceStatement::eXmlSourceType;
			uiFields |= Atlas::AtlasSourceStatement::eXmlProcname;
	
			strXML += m_vectAtlasSourceStatement[ 0 ].ToXML( uiFields );
		}

		Assignment_ToXML( strXML );

		strXML += XML::MakeCloseXmlElementWithChildren( XML::enFill );
	}
}

void AtlasFill::Assignment_ToXML( string& strXML ) const
{
	if ( 0 == m_pvectList )
	{
		strXML += XML::MakeXmlElementNoChildren( XML::enVariable, m_pVariableName->AtlasData::ToXML( ) );

		strXML += XML::MakeOpenXmlElementWithChildren( XML::enAssignment );

		strXML += XML::MakeXmlElementNoChildren( XML::enAssign, ( 0 != m_pVariableValue ? m_pVariableValue : m_pVariableName )->ToXML( false ) );

		strXML += XML::MakeCloseXmlElementWithChildren( XML::enAssignment );
	}
	else
	{
		const unsigned int uiSize = m_pvectList->size( );
		string strListAttribute;

		strXML += XML::MakeXmlElementNoChildren( XML::enVariable, m_pVariableName->ToXML( ) );

		strListAttribute = XML::MakeXmlAttributeNameValue( XML::anList, XML::avTrue );

		strXML += XML::MakeOpenXmlElementWithChildren( XML::enAssignment, strListAttribute );

		for ( unsigned int ui = 0; ui < uiSize; ++ui )
		{
			const pair< pair< unsigned int, unsigned int >, Atlas::AtlasData* >& pr = m_pvectList->at( ui );

			if ( pr.first.first == pr.first.second )
			{
				strXML += XML::MakeXmlElementNoChildren( XML::enAssign, XML::MakeXmlAttributeNameValue( XML::anIndex, pr.first.first ), pr.second->ToXML( false ) );
			}
			else
			{
				strXML += XML::MakeXmlElementNoChildren( XML::enAssign, XML::MakeXmlAttributeNameValue( XML::anStartIndex, pr.first.first ), XML::MakeXmlAttributeNameValue( XML::anThruIndex, pr.first.second ), pr.second->ToXML( false ) );
			}
		}

		strXML += XML::MakeCloseXmlElementWithChildren( XML::enAssignment );
	}
}

void AtlasFill::GetAssignValue_XML( const XML::ElementName eName, set < string >& setAssignedByValue ) const
{
	if ( 0 == m_pvectList )
	{
		const string strXML( XML::MakeXmlElementNoChildren( eName, m_pVariableName->ToXML( false ) ) );

		if ( !strXML.empty( ) )
		{
			setAssignedByValue.insert( strXML );
		}
	}
	else
	{
		const unsigned int uiSize = m_pvectList->size( );
		string strXML;

		for ( unsigned int ui = 0; ui < uiSize; ++ui )
		{
			const pair< pair< unsigned int, unsigned int >, Atlas::AtlasData* >& pr = m_pvectList->at( ui );

			if ( pr.first.first == pr.first.second )
			{
				strXML = XML::MakeXmlElementNoChildren( eName, XML::MakeXmlAttributeNameValue( XML::anIndex, pr.first.first ), pr.second->ToXML( false ) );

				if ( !strXML.empty( ) )
				{
					setAssignedByValue.insert( strXML );
				}
			}
			else
			{
				const string strIndexedXML( pr.second->ToXML( false ) );

				for ( unsigned int ui2 = pr.first.first; ui2 <= pr.first.second; ++ui2 )
				{
					strXML = XML::MakeXmlElementNoChildren( eName, XML::MakeXmlAttributeNameValue( XML::anIndex, ui2 ), strIndexedXML );

					if ( !strXML.empty( ) )
					{
						setAssignedByValue.insert( strXML );
					}
				}
			}
		}
	}
}

void AtlasFill::ProcessVariableSymbols( const map< string, vector< AtlasDeclareData* >* >& mapDeclares, const map< Atlas::AtlasData::eBuiltInType, AtlasDeclareData* >& mapBuiltinDeclares, const AtlasProcedure* pProcedure, const vector< pair< string, Atlas::AtlasSourceStatement::eSourceType > >* pvectAtlasSourceFiles )
{
	if ( mapBuiltinDeclares.size( ) > 0 )
	{
		if ( 0 != m_pVariableName )
		{
			m_multimapVariables.insert( make_pair( m_pVariableName->GetVariableName( ), m_pVariableName ) );

			const Atlas::AtlasBool* pBool = dynamic_cast< const Atlas::AtlasBool* >( m_pVariableName );
		
			if ( 0 != pBool )
			{
				const bool bSet = *( pBool->Get( ) );
				const map< Atlas::AtlasData::eBuiltInType, AtlasDeclareData* >::const_iterator itBuiltInDeclares = mapBuiltinDeclares.find( bSet ? Atlas::AtlasData::eTrue : Atlas::AtlasData::eFalse );

				try
				{
					m_pVariableValue = new Atlas::AtlasData( itBuiltInDeclares->second->m_Declare.m_strVarName );
				}
				catch ( ... )
				{
					throw Exception( Exception::eFailedToCreateAtlasVariableObject, __FILE__, __FUNCTION__, __LINE__ );
				}

				m_pVariableValue->SetAtlasDataType( Atlas::eBOOLEAN );
				m_pVariableValue->SetDataType( Atlas::AtlasData::eBoolean );
				m_pVariableValue->SetScopeType( Atlas::AtlasData::eBuiltIn );
				m_pVariableValue->SetBuiltInType( bSet ? Atlas::AtlasData::eTrue : Atlas::AtlasData::eFalse );
				m_pVariableValue->SetVariableRefId( itBuiltInDeclares->second->m_Source.GetId( ) );
				++( itBuiltInDeclares->second->m_uiUseCount );
			}
		}
		else if ( 0 != m_pvectList )
		{
			const unsigned int uiSize = m_pvectList->size( );

			for ( unsigned int ui = 0; ui < uiSize; ++ui )
			{
				const pair< pair< unsigned int, unsigned int >, Atlas::AtlasData* >& pr = m_pvectList->at( ui );

				if ( Atlas::eBOOLEAN == pr.second->GetAtlasDataType( ) )
				{
					const string& strVarName = pr.second->GetVariableName( );

					const bool bSet = ( strVarName == m_strTRUE ? true : false );
					const map< Atlas::AtlasData::eBuiltInType, AtlasDeclareData* >::const_iterator itBuiltInDeclares = mapBuiltinDeclares.find( bSet ? Atlas::AtlasData::eTrue : Atlas::AtlasData::eFalse );

					if ( m_multimapVariables.end( ) == m_multimapVariables.find( strVarName ) )
					{
						++( itBuiltInDeclares->second->m_uiUseCount );
						pr.second->SetVariableRefId( itBuiltInDeclares->second->m_Source.GetId( ) );
						m_multimapVariables.insert( make_pair( strVarName, pr.second ) );
					}
				}
			}
		}
	}
}
