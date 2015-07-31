/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

#pragma once

#include <string>

class Exception
{
public:

	enum eErrorType
	{
		eUnknownError = -1,
		eNoError = 0,

		eInvalidCommandLineArguments = 20000,
		eInvalidCommandLineArgmentsArray,
		eInvalidInputAtlasFilename,
		eCannotOpenOutputAIXMLFile,
		eCannotOpenOutputProcHierAIXMLFile,
		eInvalidASTLength,
		eFailedToAssignXMLInputBuffer,
		eFailedToLocateFinalClosingElement,
		eFailedToGetDocumentFromXercesParser,
		eFailedToGetRootElementFromXercesParser,
		eXercesException,
		eFailedToLocateRootXMLElement,
		eFailedToCreateXercesParser,
		eFailedToGetLookupChildNodes,
		eInvalidNumberOfLookupNodes,
		eFailedToGetXercesNodeListItem,
		eFailedToAllocateMemoryForNewLookupObject,
		eFailedToGetSubfileChildNodes,
		eInvalidNumberOfSubfileNodes,
		eFailedToAllocateMemoryForNewpSubfileObject,
		eInvalidSubfileNumber,
		eFailedToGetMappingChildNodes,
		eInvalidNumberOfMappingNodes,
		eMoreThanTwoMappingsArgumentsWereFoundSubfile1,
		eCannotFindAtlasNameForMappingSubfile1,
		eCannotFindCassNameForMappingSubfile1,
		eDuplicateAtlasNameInMappingSubfile1,
		eFailedToAllocateMemoryForNewAtlasSetSubfile1,
		eUnknownSubfileType,
		eEmptyMappingSubfile2,
		eDuplicateSubfileId,
		eSubfile1SectionMustComeFirst,
		eUnknownOrMissingCNXTypeInSubfile2,
		eUnknownOrMissingNameInSubfile2,
		eFailedToAllocateMemoryForNewPinInfoObjectSubfile2,
		eUnknownOrMissingSystemNameInSubfile2,
		eMoreThanTwoMappingsArgumentsWereFoundSubfile5,
		eCannotFindAtlasEventForMappingSubfile5,
		eCannotFindCassTriggerSourceForMappingSubfile5,
		eDuplicateAtlasEventInMappingSubfile5,
		eDuplicateAtlasEventInMappingSubfile6,
		eFailedToAllocateMemoryForNewAtlasSetSubfile6,
		eCannotFindAtlasEventForMappingSubfile6,
		ePinDescriptorIsEmptyForSubfile6,
		eFailedToCreatePinDescriptorSetForSubfile6,
		eNoPinDescriptorWereFoundForSubfile6,
		eMoreThanTwoMappingsArgumentsWereFoundSubfile7,
		eCannotFindLabelForMappingSubfile7,
		eCannotFindCassNameForMappingSubfile7,
		eDuplicateLabelInMappingSubfile7,
		eEmptyMappingSubfile10,
		eUnknownOrMissingCNXTypeInSubfile10,
		eUnknownOrMissingNameInSubfile10,
		eUnknownOrMissingSystemNameInSubfile10,
		eFailedToAllocateMemoryForNewPinInfoObjectSubfile10,
		eCouldNotFindElementInPath,
		eSourceXMLDoesNotContainNumberOfElementsAttribute,
		eCouldNotFindXMLPathForIncludeFile,
		eNoLookupInformationCouldBeFound,
		eUnexpectedSubfileId,
		eFailedToGetRequireChildNodes,
		eInvalidNumberOfRequireNodes,
		eFailedToAllocateMemoryForNewInstrumentsObject,
		eFailedToGetFirstElementChildForRequireStatement,
		eFailedToGetVirtualLabelNameForRequireStatement,
		eCannotFindPrimarySubfile1Object,
		eCannotFindPrimarySubfile1Label,
		eCannotFindSystemNameByLabel,
		eCannotFindSystemNameEnumBySystemName,
		eFailedToCreateResourceObject,
		eFailedToCreateControlObject,
		eFailedToCreateCapabilityObject,
		eFailedToCreateLimitObject,
		eFailedToCreateCNXObject,
		eUnknownResourceType,
		eUnexpectedCharacterFound,
		eFailedToAllocateMemoryForNewResourceConfigObject,
		eResourceConfigUnderConstruction,
		eInvalidNumberOfAttributesForResourceSource,
		eUnknownAtlasNounForResourceSource,
		eInvalidNumberOfAttributesForResourceOutput,
		eInvalidNumberOfAttributesForResourceSensor,
		eUnknownAtlasNounModifierForResourceSensor,
		eUnknownAtlasNounForResourceSensor,
		eInvalidNumberOfAttributesForCapability,
		eUnknownAtlasNounModifierForCapability,
		eInvalidNumberOfAttributesForDeviceCapability,
		eLineLengthIsNotNumericForDeviceCapability,
		ePageSizeIsNotNumericForDeviceCapability,
		eUnknownDataTypeForDeviceCapability,
		eFailedToCreateRangeObject,
		eInvalidNumber,
		eFailedToCreateCouplingObject,
		eInvalidNumberOfAttributesForControl,
		eUnknownAtlasNounModifierForControl,
		eInvalidNumberOfRangeAttributes,
		eFailedToCreateNumberObject,
		eInvalidNumberOfAttributesForCNX,
		eUnknownAtlasCnxDescriptor,
		eUnknownInputOutputType,
		eUnknownFileOranizationForFileCapability,
		eUnknownFileFormForFileCapability,
		eUnknownFileRecordTypeForFileCapability,
		eRecordLengthIsNotNumericForFileCapability,
		eUnexpectedAttributeForFileCapability,
		eUnexpectedAttributeForDeviceCapability,
		eUnknownDataTypeForFileCapability,
		eFailedToCreateStringObject,
		eUnknownDataType,
		eInvalidNumberOfAttributesForResourceLoad,
		eUnknownAtlasNounForResourceLoad,
		eInvalidArrayPositionToCreateNumber,
		eFailedToCreateSourceIndentifierObject,
		eFailedToCreateModeObject,
		eFailedToCreateBoolObject,
		eFailedToCreateCirculateObject,
		eFailedToCreateSettingsValuesObject,
		eTooManyDataTypesForUnitOfMeasure,
		eUnknownAtlasFunctionForCapability,
		ePointerAlreadyUsed,
		eInvalidNumberOfAttributesForResourceStimRespComp,
		eUnknownAtlasNounForResourceStimRespComp,
		eUnexpectedAttributeForVideoCapability,
		eFailedToCreateVideoObject,
		eSourceXMLDoesNotContainNameAttributeThatContainsSourceFilename,
		eSourceXMLDoesNotContainNameAttributeThatContainsIncludeSourceLineNumber,
		eSourceXMLDoesNotContainNameAttributeThatContainsIncludeSourceStatementNumber,
		eMergeInstrumentsHaveSameLabelDifferentTypes,
		eFailedToCreateFileAttributesObject,
		eFailedToAllocateMemoryForNewStatementObject,
		eNoKnownAttributesFound,
		eNoAttributesFound,
		eUnexpectedStatementType,
		eNoStatementInformationCouldBeFound,
		eFailedToGetChildNodes,
		eUnknownAtlasNoun,
		eFailedToCreateCNXInfoObject,
		eFailedToCreateAttributeValueObject,
		eUnknownAtlasNounModifier,
		eFailedToCreateAtlasCharacteristicObject,
		eFailedToCreateEvaluationStatementObject,
		eUnexpectedREAD_DateConfiguration,
		eFailedToCreateVectorObject,
		eFailedToCreateSignalInfoObject,
		eFailedToCreateObject,
		eFailedToCreateAtlasStringObject,
		eFailedToCreateConnectorObject,
		eFailedToCreateAtlasBooleanObject,
		eFailedToCreateAtlasVariableObject,
		eFailedToCreateArithmeticExpressionObject,
		eFailedToAllocateMemoryForAtlasCalculateObject,
		eFailedToAllocateMemoryForNewDOMStatementsObject,
		eFailedToCreateBooleanExpressionObject,
		eFailedToAllocateMemoryForAtlasConditionalObject,
		eFailedToAllocateMemoryForAtlasStatementObject,
		eFailedToAllocateMemoryForAtlasFillObject,
		eFailedToCreateMapObject,
		eInvalidUUTName,
		eInvalidUUTId,
		eInvalidTestStation,
		eInvalidProjectName,
		eCannotOpenInputAtlasSourceFile,
		eUnknownCommandLineSwitch,
		eDuplicateCommandLineSwitch,
		eUnknownAtlasFunction,
		eFailedToAllocateMemoryForComplexSignalObject,
		eFailedToCreateProcedureSet,
		eFailedToAllocateMemoryForNewDeclareDataObject,
		eFailedToCreateTestDataObject,
		eFailedToAllocateMemoryForAtlasSpecifyObject,
		eFailedToAllocateMemoryForCommmentDataObject,
		eFailedToAllocateMemoryForExpressionObject,
		eFailedToCreateForExpressionObject,
		eFailedToCreateCompareExpressionObject,
		eFailedToCreateBitwiseExpressionObject,
		eFailedToCreateLimitTermObject,
		eFailedToCreateAtlasTermObject,
		eFailedToCreateMathFunctionObject,
		eFailedToCreateFileObject,
		eFailedToCreatePairObject,
		eCannotFindRequireForVirtualLabel,

		eLastErrorLevel // Don't add any after this one
	};

	Exception( ) : m_eErrorType( eNoError ), m_iLineNumber( -1 ) { }
	Exception( const eErrorType eType, const std::string& strFilename, const std::string& strMethod, const int iLineNumber, const std::string& strErrorText = std::string( ) )
	{
		SetInfo( eType, strFilename, strMethod, iLineNumber, strErrorText );
	}

	Exception& operator = ( const Exception& other )
	{
		if ( &other != this )
		{
			m_eErrorType = other.m_eErrorType;
			m_strFilename = other.m_strFilename;
			m_strMethod = other.m_strMethod;
			m_strErrorText = other.m_strErrorText;
			m_iLineNumber = other.m_iLineNumber;
		}
	
		return *this;
	}

	void SetInfo( const eErrorType eType, const std::string& strFilename, const std::string& strMethod, const int iLineNumber, const std::string& strErrorText = std::string( ) )
	{
		m_eErrorType = eType;
		m_strFilename = strFilename;
		m_strMethod = strMethod;
		m_iLineNumber = iLineNumber;
		m_strErrorText = strErrorText;
	}

	std::string GetErrorText( const bool bIncludeCallInfo ) const;
	eErrorType GetError( void ) const { return m_eErrorType; }

	void Clear( void );

	eErrorType m_eErrorType;
	std::string m_strFilename;
	std::string m_strMethod;
	std::string m_strErrorText;
	int m_iLineNumber;
};