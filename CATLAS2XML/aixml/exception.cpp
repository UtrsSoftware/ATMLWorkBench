/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

#include "exception.h"
#include "aixml.h"
#include "helper.h"

#if ( _DEBUG ) && ( WIN32 )
	#define WINVER 0x0600
	#include <afx.h>
	#define new DEBUG_NEW
	#undef THIS_FILE
	static char BASED_CODE THIS_FILE[ ] = __FILE__;
#endif

string Exception::GetErrorText( const bool bIncludeCallInfo ) const
{
	string strErrorLevelText( "No Error" );

	switch ( m_eErrorType )
	{
		case eInvalidCommandLineArguments:
			strErrorLevelText = "Invalid number of command line argments";
			break;

		case eInvalidCommandLineArgmentsArray:
			strErrorLevelText = "Invalid command line argments array";
			break;

		case eInvalidInputAtlasFilename:
			strErrorLevelText = "Invalid input Atlas filename";
			break;

		case eCannotOpenOutputAIXMLFile:
			strErrorLevelText = "Cannot open AIXML file for writing";
			break;

		case eCannotOpenOutputProcHierAIXMLFile:
			strErrorLevelText = "Cannot open AIXML procedure hierarchy file for writing";
			break;

		case eInvalidASTLength:
			strErrorLevelText = "Invalid abstract syntax tree length";
			break;

		case eFailedToAssignXMLInputBuffer:
			strErrorLevelText = "Failed to assign XML input buffer";
			break;

		case eFailedToLocateFinalClosingElement:
			{
				string strOverAllClosingTag( AIXML::m_arrayXMLKeyWords[ AIXML::eEndElement ] );
				strOverAllClosingTag += AIXML::m_arrayXMLKeyWords[ AIXML::eAtlasFileElement ];
				strOverAllClosingTag += AIXML::m_arrayXMLKeyWords[ AIXML::eTerminateEndElement ];

				strErrorLevelText = "Failed to locate final closing tag: ";

				strErrorLevelText += strOverAllClosingTag;
			}
			break;

		case eFailedToGetDocumentFromXercesParser:
			strErrorLevelText = "Failed to get document from Xerces parser";
			break;

		case eFailedToGetRootElementFromXercesParser:
			strErrorLevelText = "Failed to get root element from Xerces parser";
			break;

		case eXercesException:
			if ( !m_strErrorText.empty( ) )
			{
				strErrorLevelText = "Xerces error: ";
				strErrorLevelText += m_strErrorText;
			}
			else
			{
				strErrorLevelText = "Unknown Xerces DOM error";
			}
			break;

		case eFailedToCreateXercesParser:
			strErrorLevelText = "Failed create Xerces parser";
			break;

		case eFailedToGetLookupChildNodes:
			strErrorLevelText = "Failed to get ";
			strErrorLevelText += AIXML::m_arrayXMLKeyWords[ AIXML::eLookupElement ];
			strErrorLevelText += " child nodes";
			break;

		case eInvalidNumberOfLookupNodes:
			strErrorLevelText = "Invalid number of ";
			strErrorLevelText += AIXML::m_arrayXMLKeyWords[ AIXML::eLookupElement ];
			strErrorLevelText += " nodes";
			break;

		case eFailedToGetXercesNodeListItem:
			strErrorLevelText = "Failed to get Xerces node list item";
			break;

		case eFailedToAllocateMemoryForNewLookupObject:
			strErrorLevelText = "Failed to create new ";
			strErrorLevelText += AIXML::m_arrayXMLKeyWords[ AIXML::eLookupElement ];
			strErrorLevelText += " object";
			break;

		case eFailedToGetSubfileChildNodes:
			strErrorLevelText = "Failed to get ";
			strErrorLevelText += AIXML::m_arrayXMLKeyWords[ AIXML::eSubfileElement ];
			strErrorLevelText += " child nodes";
			break;

		case eInvalidNumberOfSubfileNodes:
			strErrorLevelText = "Invalid number of ";
			strErrorLevelText += AIXML::m_arrayXMLKeyWords[ AIXML::eSubfileElement ];
			strErrorLevelText += " nodes";
			break;

		case eFailedToAllocateMemoryForNewpSubfileObject:
			strErrorLevelText = "Failed to create new ";
			strErrorLevelText += AIXML::m_arrayXMLKeyWords[ AIXML::eSubfileElement ];
			strErrorLevelText += " object";
			break;

		case eInvalidSubfileNumber:
			strErrorLevelText = "Invalid ";
			strErrorLevelText += AIXML::m_arrayXMLKeyWords[ AIXML::eSubfileElement ];
			strErrorLevelText += " number";
			break;

		case eFailedToGetMappingChildNodes:
			strErrorLevelText = "Failed to get ";
			strErrorLevelText += AIXML::m_arrayXMLKeyWords[ AIXML::eMappingElement ];
			strErrorLevelText += " child nodes";
			break;

		case eInvalidNumberOfMappingNodes:
			strErrorLevelText = "Invalid number of ";
			strErrorLevelText += AIXML::m_arrayXMLKeyWords[ AIXML::eMappingElement ];
			strErrorLevelText += " nodes";
			break;

		case eMoreThanTwoMappingsArgumentsWereFoundSubfile1:
			strErrorLevelText = "More than two ";
			strErrorLevelText += AIXML::m_arrayXMLKeyWords[ AIXML::eMappingElement ];
			strErrorLevelText += " ";
			strErrorLevelText += AIXML::m_arrayXMLKeyWords[ AIXML::eArgumentElement ];
			strErrorLevelText += " were found in SUBFILE1";
			break;

		case eCannotFindAtlasNameForMappingSubfile1:
			strErrorLevelText = "Cannot find Atlas name for ";
			strErrorLevelText += AIXML::m_arrayXMLKeyWords[ AIXML::eMappingElement ];
			strErrorLevelText += " for SUBFILE 1";
			break;

		case eCannotFindCassNameForMappingSubfile1:
			strErrorLevelText = "Cannot find CASS name for ";
			strErrorLevelText += AIXML::m_arrayXMLKeyWords[ AIXML::eMappingElement ];
			strErrorLevelText += " for SUBFILE 1";
			break;

		case eDuplicateAtlasNameInMappingSubfile1:
			strErrorLevelText = "Duplicate Atlas name in ";
			strErrorLevelText += AIXML::m_arrayXMLKeyWords[ AIXML::eMappingElement ];
			strErrorLevelText += ": ";
			strErrorLevelText += m_strErrorText;
			strErrorLevelText += " for SUBFILE 1";
			break;

		case eFailedToAllocateMemoryForNewAtlasSetSubfile1:
			strErrorLevelText = "Failed to create new set for SUBFILE 1";
			break;

		case eUnknownSubfileType:
			strErrorLevelText = "Unknown Subfile type: ";
			strErrorLevelText += m_strErrorText;
			break;

		case eEmptyMappingSubfile2:
			strErrorLevelText = "Empty ";
			strErrorLevelText += AIXML::m_arrayXMLKeyWords[ AIXML::eNameAttribute ];
			strErrorLevelText += " in ";
			strErrorLevelText += AIXML::m_arrayXMLKeyWords[ AIXML::eArgumentElement ];
			strErrorLevelText += " tag in SUBFILE 2";
			break;

		case eDuplicateSubfileId:
			strErrorLevelText = "Duplicate SUBFILE id: ";
			strErrorLevelText += m_strErrorText;
			break;

		case eSubfile1SectionMustComeFirst:
			strErrorLevelText = "SUBFILE 1 must come before all other SUBFILE sections";
			break;

		case eUnknownOrMissingCNXTypeInSubfile2:
			strErrorLevelText = "Unknown or missing CNX descriptor in SUBFILE 2: ";
			strErrorLevelText += m_strErrorText;
			break;

		case eUnknownOrMissingNameInSubfile2:
			strErrorLevelText = "Unknown or missing user pin name in SUBFILE 2: ";
			strErrorLevelText += m_strErrorText;
			break;

		case eFailedToAllocateMemoryForNewPinInfoObjectSubfile2:
			strErrorLevelText = "Failed to create new PinInfo object in SUBFILE 2";
			break;

		case eUnknownOrMissingSystemNameInSubfile2:
			strErrorLevelText = "Unknown or missing CASS system name in SUBFILE 2: ";
			strErrorLevelText += m_strErrorText;
			break;

		case eMoreThanTwoMappingsArgumentsWereFoundSubfile5:
			strErrorLevelText = "More than two ";
			strErrorLevelText += AIXML::m_arrayXMLKeyWords[ AIXML::eMappingElement ];
			strErrorLevelText += " ";
			strErrorLevelText += AIXML::m_arrayXMLKeyWords[ AIXML::eArgumentElement ];
			strErrorLevelText += " were found in SUBFILE5";
			break;

		case eCannotFindAtlasEventForMappingSubfile5:
			strErrorLevelText = "Cannot find Atlas event name for ";
			strErrorLevelText += AIXML::m_arrayXMLKeyWords[ AIXML::eMappingElement ];
			strErrorLevelText += " for SUBFILE 5";
			break;

		case eCannotFindCassTriggerSourceForMappingSubfile5:
			strErrorLevelText = "Cannot find CASS trigger source for ";
			strErrorLevelText += AIXML::m_arrayXMLKeyWords[ AIXML::eMappingElement ];
			strErrorLevelText += " for SUBFILE 5";
			break;

		case eDuplicateAtlasEventInMappingSubfile5:
			strErrorLevelText = "Duplicate Atlas event in ";
			strErrorLevelText += AIXML::m_arrayXMLKeyWords[ AIXML::eMappingElement ];
			strErrorLevelText += ": ";
			strErrorLevelText += m_strErrorText;
			strErrorLevelText += " for SUBFILE 5";
			break;

		case eDuplicateAtlasEventInMappingSubfile6:
			strErrorLevelText = "Duplicate Atlas event in ";
			strErrorLevelText += AIXML::m_arrayXMLKeyWords[ AIXML::eMappingElement ];
			strErrorLevelText += ": ";
			strErrorLevelText += m_strErrorText;
			strErrorLevelText += " for SUBFILE 6";
			break;

		case eFailedToAllocateMemoryForNewAtlasSetSubfile6:
			strErrorLevelText = "Failed to create new set for SUBFILE 6";
			break;

		case eCannotFindAtlasEventForMappingSubfile6:
			strErrorLevelText = "Cannot find Atlas event name for ";
			strErrorLevelText += AIXML::m_arrayXMLKeyWords[ AIXML::eMappingElement ];
			strErrorLevelText += " for SUBFILE 6";
			break;

		case ePinDescriptorIsEmptyForSubfile6:
			strErrorLevelText = "Pin descriptor is empty for SUBFILE 6";
			break;

		case eFailedToCreatePinDescriptorSetForSubfile6:
			strErrorLevelText = "Failed to craete pin descriptor set for SUBFILE 6";
			break;

		case eNoPinDescriptorWereFoundForSubfile6:
			strErrorLevelText = "No pin descriptor was found for SUBFILE 6";
			break;

		case eMoreThanTwoMappingsArgumentsWereFoundSubfile7:
			strErrorLevelText = "More than two ";
			strErrorLevelText += AIXML::m_arrayXMLKeyWords[ AIXML::eMappingElement ];
			strErrorLevelText += " ";
			strErrorLevelText += AIXML::m_arrayXMLKeyWords[ AIXML::eArgumentElement ];
			strErrorLevelText += " were found in SUBFILE 7";
			break;

		case eCannotFindLabelForMappingSubfile7:
			strErrorLevelText = "Cannot find virtual label for ";
			strErrorLevelText += AIXML::m_arrayXMLKeyWords[ AIXML::eMappingElement ];
			strErrorLevelText += " for SUBFILE 7";
			break;

		case eCannotFindCassNameForMappingSubfile7:
			strErrorLevelText = "Cannot find CASS name for ";
			strErrorLevelText += AIXML::m_arrayXMLKeyWords[ AIXML::eMappingElement ];
			strErrorLevelText += " for SUBFILE 7";
			break;

		case eDuplicateLabelInMappingSubfile7:
			strErrorLevelText = "Duplicate label in ";
			strErrorLevelText += AIXML::m_arrayXMLKeyWords[ AIXML::eMappingElement ];
			strErrorLevelText += ": ";
			strErrorLevelText += m_strErrorText;
			strErrorLevelText += " for SUBFILE 7";
			break;

		case eEmptyMappingSubfile10:
			strErrorLevelText = "Empty ";
			strErrorLevelText += AIXML::m_arrayXMLKeyWords[ AIXML::eNameAttribute ];
			strErrorLevelText += " in ";
			strErrorLevelText += AIXML::m_arrayXMLKeyWords[ AIXML::eArgumentElement ];
			strErrorLevelText += " tag in SUBFILE 10";
			break;

		case eUnknownOrMissingCNXTypeInSubfile10:
			strErrorLevelText = "Unknown or missing CNX descriptor in SUBFILE 10: ";
			strErrorLevelText += m_strErrorText;
			break;

		case eUnknownOrMissingNameInSubfile10:
			strErrorLevelText = "Unknown or missing user pin name in SUBFILE 10: ";
			strErrorLevelText += m_strErrorText;
			break;

		case eUnknownOrMissingSystemNameInSubfile10:
			strErrorLevelText = "Unknown or missing CASS system name in SUBFILE 10: ";
			strErrorLevelText += m_strErrorText;
			break;

		case eFailedToAllocateMemoryForNewPinInfoObjectSubfile10:
			strErrorLevelText = "Failed to create new PinInfo object in SUBFILE 10";
			break;

		case eCouldNotFindElementInPath:
			strErrorLevelText = "Could not find element in path: ";
			strErrorLevelText += m_strErrorText;
			break;

		case eSourceXMLDoesNotContainNumberOfElementsAttribute:
			strErrorLevelText = "Source XML does not contain the ";
			strErrorLevelText += AIXML::m_arrayXMLKeyWords[ AIXML::eNumberOfElementsAttribute ];
			strErrorLevelText += " attribute in parent elements";
			break;

		case eCouldNotFindXMLPathForIncludeFile:
			strErrorLevelText = "Cound not include file element in path: ";
			strErrorLevelText += m_strErrorText;
			break;

		case eNoLookupInformationCouldBeFound:
			strErrorLevelText = "No Lookup information could be found";
			break;

		case eUnexpectedSubfileId:
			strErrorLevelText = "Unexpected SUBFILE id. ";
			strErrorLevelText += m_strErrorText;
			break;

		case eFailedToGetRequireChildNodes:
			strErrorLevelText = "Failed to get ";
			strErrorLevelText += AIXML::m_arrayXMLKeyWords[ AIXML::eRequireElement ];
			strErrorLevelText += " child nodes";
			break;

		case eInvalidNumberOfRequireNodes:
			strErrorLevelText = "Invalid number of ";
			strErrorLevelText += AIXML::m_arrayXMLKeyWords[ AIXML::eRequireElement ];
			strErrorLevelText += " nodes";

			if ( !m_strErrorText.empty( ) )
			{
				strErrorLevelText += ": ";
				strErrorLevelText += m_strErrorText;
			}
			break;

		case eFailedToAllocateMemoryForNewInstrumentsObject:
			strErrorLevelText = "Failed to create new Instruments object";
			break;

		case eFailedToGetFirstElementChildForRequireStatement:
			strErrorLevelText = "Failed to get first XML element child for Require statement";
			break;

		case eFailedToGetVirtualLabelNameForRequireStatement:
			strErrorLevelText = "Failed to get virtual label name for Require statement";
			break;

		case eCannotFindPrimarySubfile1Object:
			strErrorLevelText = "Cannot find primary Subfile1 object";
			break;

		case eCannotFindPrimarySubfile1Label:
			strErrorLevelText = "Cannot find primary Subfile1 virtual label: ";
			strErrorLevelText += m_strErrorText;
			break;

		case eCannotFindSystemNameByLabel:
			strErrorLevelText = "Cannot find system name by virtual label: ";
			strErrorLevelText += m_strErrorText;
			break;

		case eCannotFindSystemNameEnumBySystemName:
			strErrorLevelText = "Cannot find system name enum by system name: ";
			strErrorLevelText += m_strErrorText;
			break;

		case eFailedToCreateResourceObject:
			strErrorLevelText = "Failed to create Resource object for virtual label ";
			strErrorLevelText += m_strErrorText;
			break;

		case eFailedToCreateControlObject:
			strErrorLevelText = "Failed to create Control object for virtual label: ";
			strErrorLevelText += m_strErrorText;
			break;

		case eFailedToCreateCapabilityObject:
			strErrorLevelText = "Failed to create Capability object for virtual label: ";
			strErrorLevelText += m_strErrorText;
			break;

		case eFailedToCreateLimitObject:
			strErrorLevelText = "Failed to create Limit object for virtual label: ";
			strErrorLevelText += m_strErrorText;
			break;

		case eFailedToCreateCNXObject:
			strErrorLevelText = "Failed to create CNX object";
			if ( !m_strErrorText.empty( ) )
			{
				strErrorLevelText += " for virtual label ";
				strErrorLevelText += m_strErrorText;
			}
			break;

		case eUnknownResourceType:
			strErrorLevelText = "Unknown resource type: ";
			strErrorLevelText += m_strErrorText;
			break;

		case eUnexpectedCharacterFound:
			strErrorLevelText = "Unexpected character found: ";
			strErrorLevelText += m_strErrorText;
			break;

		case eFailedToAllocateMemoryForNewResourceConfigObject:
			strErrorLevelText = "Failed to create new Resource config object: ";
			strErrorLevelText += m_strErrorText;
			break;

		case eResourceConfigUnderConstruction:
			strErrorLevelText = "Resource config object under construction: ";
			strErrorLevelText += m_strErrorText;
			break;

		case eInvalidNumberOfAttributesForResourceSource:
			strErrorLevelText = "Invalid number of attributes for resource source: ";
			strErrorLevelText += m_strErrorText;
			break;

		case eUnknownAtlasNounForResourceSource:
			strErrorLevelText = "Unknown Atlas noun for resource source: ";
			strErrorLevelText += m_strErrorText;
			break;

		case eInvalidNumberOfAttributesForResourceOutput:
			strErrorLevelText = "Invalid number of attributes for resource output: ";
			strErrorLevelText += m_strErrorText;
			break;

		case eInvalidNumberOfAttributesForResourceSensor:
			strErrorLevelText = "Invalid number of attributes for resource sensor: ";
			strErrorLevelText += m_strErrorText;
			break;

		case eUnknownAtlasNounModifierForResourceSensor:
			strErrorLevelText = "Unknown Atlas noun/modifier for resource sensor: ";
			strErrorLevelText += m_strErrorText;
			break;

		case eUnknownAtlasNounForResourceSensor:
			strErrorLevelText = "Unknown Atlas noun for resource sensor: ";
			strErrorLevelText += m_strErrorText;
			break;

		case eInvalidNumberOfAttributesForCapability:
			strErrorLevelText = "Invalid number of attributes for capability: ";
			strErrorLevelText += m_strErrorText;
			break;

		case eUnknownAtlasNounModifierForCapability:
			strErrorLevelText = "Unknown Atlas noun/modifier for capability: ";
			strErrorLevelText += m_strErrorText;
			break;

		case eInvalidNumberOfAttributesForDeviceCapability:
			strErrorLevelText = "Invalid number of attributes for device capability: ";
			strErrorLevelText += m_strErrorText;
			break;

		case eLineLengthIsNotNumericForDeviceCapability:
			strErrorLevelText = "Line length is not numeric for device capability: ";
			strErrorLevelText += m_strErrorText;
			break;

		case ePageSizeIsNotNumericForDeviceCapability:
			strErrorLevelText = "Page size is not numeric for device capability: ";
			strErrorLevelText += m_strErrorText;
			break;

		case eUnknownDataTypeForDeviceCapability:
			strErrorLevelText = "Unkown data type for device capability: ";
			strErrorLevelText += m_strErrorText;
			break;

		case eFailedToCreateRangeObject:
			strErrorLevelText = "Failed to create Range object";
			if ( !m_strErrorText.empty( ) )
			{
				strErrorLevelText += " for virtual label ";
				strErrorLevelText += m_strErrorText;
			}
			break;

		case eInvalidNumber:
			strErrorLevelText = "Invalid number for virtual label ";
			strErrorLevelText += m_strErrorText;
			break;

		case eFailedToCreateCouplingObject:
			strErrorLevelText = "Failed to create Coupling object";
			if ( !m_strErrorText.empty( ) )
			{
				strErrorLevelText += " for virtual label ";
				strErrorLevelText += m_strErrorText;
			}
			break;

		case eInvalidNumberOfAttributesForControl:
			strErrorLevelText = "Invalid number of attributes for control: ";
			strErrorLevelText += m_strErrorText;
			break;

		case eUnknownAtlasNounModifierForControl:
			strErrorLevelText = "Unknown Atlas noun/modifier for control: ";
			strErrorLevelText += m_strErrorText;
			break;

		case eInvalidNumberOfRangeAttributes:
			strErrorLevelText = "Invalid number of range attributes: ";
			strErrorLevelText += m_strErrorText;
			break;

		case eFailedToCreateNumberObject:
			strErrorLevelText = "Failed to create Number object";
			if ( !m_strErrorText.empty( ) )
			{
				strErrorLevelText += " for virtual label ";
				strErrorLevelText += m_strErrorText;
			}
			break;

		case eInvalidNumberOfAttributesForCNX:
			strErrorLevelText = "Invalid number of attributes for CNX: ";
			strErrorLevelText += m_strErrorText;
			break;

		case eUnknownAtlasCnxDescriptor:
			strErrorLevelText = "Unknown Atlas CNX descriptor: ";
			strErrorLevelText += m_strErrorText;
			break;

		case eUnknownInputOutputType:
			strErrorLevelText = "Unknown input/output type: ";
			strErrorLevelText += m_strErrorText;
			break;

		case eUnknownFileOranizationForFileCapability:
			strErrorLevelText = "Unknown file organization: ";
			strErrorLevelText += m_strErrorText;
			break;

		case eUnknownFileFormForFileCapability:
			strErrorLevelText = "Unknown file form: ";
			strErrorLevelText += m_strErrorText;
			break;

		case eUnknownFileRecordTypeForFileCapability:
			strErrorLevelText = "Unknown file record type: ";
			strErrorLevelText += m_strErrorText;
			break;

		case eRecordLengthIsNotNumericForFileCapability:
			strErrorLevelText = "Record length is not numeric for file capability: ";
			strErrorLevelText += m_strErrorText;
			break;

		case eUnexpectedAttributeForFileCapability:
			strErrorLevelText = "Unexpected attribute for file capability: ";
			strErrorLevelText += m_strErrorText;
			break;

		case eUnexpectedAttributeForDeviceCapability:
			strErrorLevelText = "Unexpected attribute for device capability: ";
			strErrorLevelText += m_strErrorText;
			break;

		case eUnknownDataTypeForFileCapability:
			strErrorLevelText = "Unknown data type for file capability: ";
			strErrorLevelText += m_strErrorText;
			break;

		case eFailedToCreateStringObject:
			strErrorLevelText = "Failed to create String object";
			if ( !m_strErrorText.empty( ) )
			{
				strErrorLevelText += " for virtual label ";
				strErrorLevelText += m_strErrorText;
			}
			break;

		case eUnknownDataType:
			strErrorLevelText = "Unknown data type";
			if ( !m_strErrorText.empty( ) )
			{
				strErrorLevelText += " for virtual label ";
				strErrorLevelText += m_strErrorText;
			}
			break;

		case eInvalidNumberOfAttributesForResourceLoad:
			strErrorLevelText = "Invalid number of attributes for resource load: ";
			strErrorLevelText += m_strErrorText;
			break;

		case eUnknownAtlasNounForResourceLoad:
			strErrorLevelText = "Unknown Atlas noun for resource load: ";
			strErrorLevelText += m_strErrorText;
			break;

		case eInvalidArrayPositionToCreateNumber:
			strErrorLevelText = "Invalid array position to create number";
			if ( !m_strErrorText.empty( ) )
			{
				strErrorLevelText += " for virtual label ";
				strErrorLevelText += m_strErrorText;
			}
			break;

		case eFailedToCreateSourceIndentifierObject:
			strErrorLevelText = "Failed to create Source Identifier object";
			if ( !m_strErrorText.empty( ) )
			{
				strErrorLevelText += " for virtual label ";
				strErrorLevelText += m_strErrorText;
			}
			break;

		case eFailedToCreateModeObject:
			strErrorLevelText = "Failed to create Mode object";
			if ( !m_strErrorText.empty( ) )
			{
				strErrorLevelText += " for virtual label ";
				strErrorLevelText += m_strErrorText;
			}
			break;

		case eFailedToCreateBoolObject:
			strErrorLevelText = "Failed to create Bool object";
			if ( !m_strErrorText.empty( ) )
			{
				strErrorLevelText += " for virtual label ";
				strErrorLevelText += m_strErrorText;
			}
			break;

		case eFailedToCreateCirculateObject:
			strErrorLevelText = "Failed to create Circulate object";
			if ( !m_strErrorText.empty( ) )
			{
				strErrorLevelText += " for virtual label ";
				strErrorLevelText += m_strErrorText;
			}
			break;

		case eFailedToCreateSettingsValuesObject:
			strErrorLevelText = "Failed to create Settings Values object";
			if ( !m_strErrorText.empty( ) )
			{
				strErrorLevelText += " for virtual label ";
				strErrorLevelText += m_strErrorText;
			}
			break;

		case eTooManyDataTypesForUnitOfMeasure:
			strErrorLevelText = "Too many data types for unit of measure";
			break;

		case eUnknownAtlasFunctionForCapability:
			strErrorLevelText = "Unknown Atlas function for capability: ";
			strErrorLevelText += m_strErrorText;
			break;

		case ePointerAlreadyUsed:
			strErrorLevelText = "Pointer already used: ";
			strErrorLevelText += m_strErrorText;
			break;

		case eInvalidNumberOfAttributesForResourceStimRespComp:
			strErrorLevelText = "Invalid number of attributes for resource STIM-RESP-COMP: ";
			strErrorLevelText += m_strErrorText;
			break;

		case eUnknownAtlasNounForResourceStimRespComp:
			strErrorLevelText = "Unknown Atlas noun for resource STIM-RESP-COMP: ";
			strErrorLevelText += m_strErrorText;
			break;

		case eUnexpectedAttributeForVideoCapability:
			strErrorLevelText = "Unexpected attribute for video capability: ";
			strErrorLevelText += m_strErrorText;
			break;

		case eFailedToCreateVideoObject:
			strErrorLevelText = "Failed to create Video object";
			if ( !m_strErrorText.empty( ) )
			{
				strErrorLevelText += " for virtual label ";
				strErrorLevelText += m_strErrorText;
			}
			break;

		case eSourceXMLDoesNotContainNameAttributeThatContainsSourceFilename:
			strErrorLevelText = "Source XML does not contain \"name\" attribute that contains the primary source filename";
			break;

		case eSourceXMLDoesNotContainNameAttributeThatContainsIncludeSourceLineNumber:
			strErrorLevelText = "Source XML does not contain \"line\" attribute that contains the source file line number(s)";
			break;

		case eSourceXMLDoesNotContainNameAttributeThatContainsIncludeSourceStatementNumber:
			strErrorLevelText = "Source XML does not contain \"line\" attribute that contains the source file statement number(s)";
			break;

		case eMergeInstrumentsHaveSameLabelDifferentTypes:
			strErrorLevelText = "Merged instruments have same virtual label but are different types: ";
			strErrorLevelText += m_strErrorText;
			break;

		case eFailedToCreateFileAttributesObject:
			strErrorLevelText = "Failed to create file attributes object";
			if ( !m_strErrorText.empty( ) )
			{
				strErrorLevelText += " for virtual label ";
				strErrorLevelText += m_strErrorText;
			}
			break;

		case eFailedToAllocateMemoryForNewStatementObject:
			strErrorLevelText = "Failed to create new Statement object";
			if ( !m_strErrorText.empty( ) )
			{
				strErrorLevelText += ": ";
				strErrorLevelText += m_strErrorText;
			}
			break;

		case eNoKnownAttributesFound:
			strErrorLevelText = "No known attribute name(s)";
			if ( !m_strErrorText.empty( ) )
			{
				strErrorLevelText += " [id=";
				strErrorLevelText += m_strErrorText;
				strErrorLevelText += "]";
			}
			break;

		case eNoAttributesFound:
			strErrorLevelText = "No attribute(s) found";
			if ( !m_strErrorText.empty( ) )
			{
				strErrorLevelText += ": ";
				strErrorLevelText += m_strErrorText;
			}
			break;

		case eUnexpectedStatementType:
			strErrorLevelText = "Unexpected Statement type";
			if ( !m_strErrorText.empty( ) )
			{
				strErrorLevelText += ": ";
				strErrorLevelText += m_strErrorText;
			}
			break;

		case eNoStatementInformationCouldBeFound:
			strErrorLevelText = "No Statement information could be found";
			if ( !m_strErrorText.empty( ) )
			{
				strErrorLevelText += ": ";
				strErrorLevelText += m_strErrorText;
			}
			break;

		case eFailedToGetChildNodes:
			strErrorLevelText = "Failed to get child nodes";
			break;

		case eUnknownAtlasNoun:
			strErrorLevelText = "Unknown Atlas noun";
			if ( !m_strErrorText.empty( ) )
			{
				strErrorLevelText += ": ";
				strErrorLevelText += m_strErrorText;
			}
			break;

		case eFailedToCreateCNXInfoObject:
			strErrorLevelText = "Failed to create CNXInfo object";
			break;

		case eFailedToCreateAttributeValueObject:
			strErrorLevelText = "Failed to create attribute value object";
			if ( !m_strErrorText.empty( ) )
			{
				strErrorLevelText += ": ";
				strErrorLevelText += m_strErrorText;
			}
			break;

		case eUnknownAtlasNounModifier:
			strErrorLevelText = "Unknown Atlas noun/modifier";
			if ( !m_strErrorText.empty( ) )
			{
				strErrorLevelText += ": ";
				strErrorLevelText += m_strErrorText;
			}
			break;

		case eFailedToCreateAtlasCharacteristicObject:
			strErrorLevelText = "Failed to create Atlas characteristic object";
			if ( !m_strErrorText.empty( ) )
			{
				strErrorLevelText += ": ";
				strErrorLevelText += m_strErrorText;
			}
			break;

		case eFailedToCreateEvaluationStatementObject:
			strErrorLevelText = "Failed to create Atlas evaluation statement object";
			if ( !m_strErrorText.empty( ) )
			{
				strErrorLevelText += ": ";
				strErrorLevelText += m_strErrorText;
			}
			break;

		case eUnexpectedREAD_DateConfiguration:
			strErrorLevelText = "Unexpected READ DATE configuration";
			if ( !m_strErrorText.empty( ) )
			{
				strErrorLevelText += " for virtual label ";
				strErrorLevelText += m_strErrorText;
			}
			break;

		case eFailedToCreateVectorObject:
			strErrorLevelText = "Failed to create vector";
			if ( !m_strErrorText.empty( ) )
			{
				strErrorLevelText += " for virtual label ";
				strErrorLevelText += m_strErrorText;
			}
			break;

		case eFailedToCreateSignalInfoObject:
			strErrorLevelText = "Failed to create signal information object";
			break;

		case eFailedToCreateObject:
			strErrorLevelText = "Failed to create object";
			break;

		case eFailedToCreateAtlasStringObject:
			strErrorLevelText = "Failed to create Atlas string object";
			if ( !m_strErrorText.empty( ) )
			{
				strErrorLevelText += " for virtual label ";
				strErrorLevelText += m_strErrorText;
			}
			break;

		case eFailedToCreateConnectorObject:
			strErrorLevelText = "Failed to create Atlas connector object";
			if ( !m_strErrorText.empty( ) )
			{
				strErrorLevelText += " for virtual label ";
				strErrorLevelText += m_strErrorText;
			}
			break;

		case eFailedToCreateAtlasBooleanObject:
			strErrorLevelText = "Failed to create Atlas boolean object";
			if ( !m_strErrorText.empty( ) )
			{
				strErrorLevelText += " for virtual label ";
				strErrorLevelText += m_strErrorText;
			}
			break;

		case eFailedToCreateAtlasVariableObject:
			strErrorLevelText = "Failed to create Atlas variable object";
			if ( !m_strErrorText.empty( ) )
			{
				strErrorLevelText += " for virtual label ";
				strErrorLevelText += m_strErrorText;
			}
			break;

		case eFailedToCreateArithmeticExpressionObject:
			strErrorLevelText = "Failed to create Atlas arithmetic expression object";
			if ( !m_strErrorText.empty( ) )
			{
				strErrorLevelText += " for virtual label ";
				strErrorLevelText += m_strErrorText;
			}
			break;

		case eFailedToAllocateMemoryForAtlasCalculateObject:
			strErrorLevelText = "Failed to create Atlas calculate object";
			if ( !m_strErrorText.empty( ) )
			{
				strErrorLevelText += " for virtual label ";
				strErrorLevelText += m_strErrorText;
			}
			break;

		case eFailedToAllocateMemoryForNewDOMStatementsObject:
			strErrorLevelText = "Failed to create DOM statements object";
			if ( !m_strErrorText.empty( ) )
			{
				strErrorLevelText += " for virtual label ";
				strErrorLevelText += m_strErrorText;
			}
			break;

		case eFailedToCreateBooleanExpressionObject:
			strErrorLevelText = "Failed to create Atlas boolean expression object";
			if ( !m_strErrorText.empty( ) )
			{
				strErrorLevelText += " for virtual label ";
				strErrorLevelText += m_strErrorText;
			}
			break;

		case eFailedToAllocateMemoryForAtlasConditionalObject:
			strErrorLevelText = "Failed to create Atlas conditional object";
			if ( !m_strErrorText.empty( ) )
			{
				strErrorLevelText += " for virtual label ";
				strErrorLevelText += m_strErrorText;
			}
			break;

		case eFailedToAllocateMemoryForAtlasStatementObject:
			strErrorLevelText = "Failed to create Atlas statement object";
			if ( !m_strErrorText.empty( ) )
			{
				strErrorLevelText += " for virtual label ";
				strErrorLevelText += m_strErrorText;
			}
			break;

		case eFailedToAllocateMemoryForAtlasFillObject:
			strErrorLevelText = "Failed to create Atlas fill object";
			if ( !m_strErrorText.empty( ) )
			{
				strErrorLevelText += " for virtual label ";
				strErrorLevelText += m_strErrorText;
			}
			break;

		case eFailedToCreateMapObject:
			strErrorLevelText = "Failed to create map";
			if ( !m_strErrorText.empty( ) )
			{
				strErrorLevelText += " for virtual label ";
				strErrorLevelText += m_strErrorText;
			}
			break;

		case eInvalidUUTName:
			strErrorLevelText = "Invalid UUT name";
			break;

		case eInvalidUUTId:
			strErrorLevelText = "Invalid UUT id";
			break;

		case eInvalidTestStation:
			strErrorLevelText = "Invalid Test Station name";
			break;

		case eInvalidProjectName:
			strErrorLevelText = "Invalid Project name";
			break;

		case eCannotOpenInputAtlasSourceFile:
			strErrorLevelText = "Cannot open Atlas source file";
			if ( !m_strErrorText.empty( ) )
			{
				strErrorLevelText += ": \"";
				strErrorLevelText += m_strErrorText;
				strErrorLevelText += "\"";
			}
			break;

		case eUnknownCommandLineSwitch:
			strErrorLevelText = "Unknown command line switch: ";
			strErrorLevelText += m_strErrorText;
			break;

		case eDuplicateCommandLineSwitch:
			strErrorLevelText = "Duplicate command line switch: ";
			strErrorLevelText += m_strErrorText;
			break;

		case eUnknownAtlasFunction:
			strErrorLevelText = "Unknown Atlas function: ";
			strErrorLevelText += m_strErrorText;
			break;

		case eFailedToAllocateMemoryForComplexSignalObject:
			strErrorLevelText = "Failed to create new Complex Signal object";
			break;

		case eFailedToCreateProcedureSet:
			strErrorLevelText = "Failed to create new procedure set object";
			break;

		case eFailedToAllocateMemoryForNewDeclareDataObject:
			strErrorLevelText = "Failed to create new Declare data object";
			break;

		case eFailedToCreateTestDataObject:
			strErrorLevelText = "Failed to create new Test Data object";
			break;

		case eFailedToAllocateMemoryForAtlasSpecifyObject:
			strErrorLevelText = "Failed to create Atlas specify object";
			break;

		case eFailedToAllocateMemoryForCommmentDataObject:
			strErrorLevelText = "Failed to create comment data object";
			break;

		case eFailedToAllocateMemoryForExpressionObject:
			strErrorLevelText = "Failed to create expression object";
			break;

		case eFailedToCreateForExpressionObject:
			strErrorLevelText = "Failed to create \"FOR\" expression object";
			break;

		case eFailedToCreateCompareExpressionObject:
			strErrorLevelText = "Failed to create compare object";
			break;

		case eFailedToCreateBitwiseExpressionObject:
			strErrorLevelText = "Failed to create bitwise object";
			break;

		case eFailedToCreateLimitTermObject:
			strErrorLevelText = "Failed to create limit term object";
			break;

		case eFailedToCreateAtlasTermObject:
			strErrorLevelText = "Failed to create Atlas term object";
			break;

		case eFailedToCreateMathFunctionObject:
			strErrorLevelText = "Failed to create math function object";
			break;

		case eFailedToCreateFileObject:
			strErrorLevelText = "Failed to create file object";
			break;

		case eFailedToCreatePairObject:
			strErrorLevelText = "Failed to create pair object";
			break;

		case eCannotFindRequireForVirtualLabel:
			strErrorLevelText = "Cannot find REQUIRE";
			if ( !m_strErrorText.empty( ) )
			{
				strErrorLevelText += " for virtual label ";
				strErrorLevelText += m_strErrorText;
			}
			break;
	}

	AIXMLHelper::Trim( strErrorLevelText );

	const int iLength = strErrorLevelText.length( );

	if ( iLength > 0 )
	{
		const char chPeriod = '.';

		if ( chPeriod != strErrorLevelText[ iLength - 1 ] )
		{
			strErrorLevelText += chPeriod;
		}
	}

	if ( ( eNoError != m_eErrorType ) && bIncludeCallInfo )
	{
		string strFilename;
		string strMethod;
		string strLineNumber;

		if ( !m_strFilename.empty( ) )
		{
			strFilename = "file: ";
			strFilename += m_strFilename;
		}

		if ( !m_strMethod.empty( ) )
		{
			strMethod = "method: ";
			strMethod += m_strMethod;
		}

		if ( -1 != m_iLineNumber )
		{
			strLineNumber = "line: ";
			strLineNumber += AIXMLHelper::NumberToString< int >( m_iLineNumber );
		}

		if ( !strFilename.empty( ) || !strMethod.empty( ) || !strLineNumber.empty( ) )
		{
			string strFileErrorInfo = "  [";

			if ( !strFilename.empty( ) )
			{
				strFileErrorInfo += strFilename;
			}

			if ( !strMethod.empty( ) )
			{
				if ( !strFileErrorInfo.empty( ) )
				{
					strFileErrorInfo += ", ";
				}

				strFileErrorInfo += strMethod;
			}

			if ( !strLineNumber.empty( ) )
			{
				if ( !strFileErrorInfo.empty( ) )
				{
					strFileErrorInfo += ", ";
				}

				strFileErrorInfo += strLineNumber;
			}

			strFileErrorInfo += "]";

			strErrorLevelText += strFileErrorInfo;
		 
		}
	}

	return strErrorLevelText;
}

void Exception::Clear( void )
{
	m_eErrorType = eNoError;
	m_iLineNumber = -1;
	m_strFilename.clear( );
	m_strMethod.clear( );
	m_strErrorText.clear( );
}
