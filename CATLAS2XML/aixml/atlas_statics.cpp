/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

#include "Atlas.h"

#if ( _DEBUG ) && ( WIN32 )
	#define WINVER 0x0600
	#include <afx.h>
	#define new DEBUG_NEW
	#undef THIS_FILE
	static char BASED_CODE THIS_FILE[ ] = __FILE__;
#endif

const string Atlas::AtlasTerm::m_strRawClassName( typeid( Atlas::AtlasTerm ).raw_name( ) );
const string Atlas::AtlasMathFunction::m_strRawClassName( typeid( Atlas::AtlasMathFunction ).raw_name( ) );
const string Atlas::m_UNKNOWN( "UNKNOWN" );
const int Atlas::AtlasSignalComponent::m_iInvalid1641Value = -2;
bool Atlas::AtlasSignalComponent::m_b1641ToXML = true;
bool Atlas::AtlasUnitOfMeasure::m_b260_1XML = true;
set< Atlas::eAtlasNoun > Atlas::m_setElectricalSignalOrientedNoun;
set< Atlas::eAtlasStatement > Atlas::m_setElectricalSignalOrientedStatement;
map< const string*, Atlas::eAtlasStatement, AIXMLHelper::cmpPointer > Atlas::m_mapAtlasStatementToAtlasStatementEnum;
map< Atlas::eAtlasStatement, const string* > Atlas::m_mapAtlasStatementEnumToAtlasStatement;
map< const string*, Atlas::eAtlasNoun, AIXMLHelper::cmpPointer > Atlas::m_mapAtlasNounToAtlasNounEnum;
map< const string*, Atlas::eAtlasNounModifier, AIXMLHelper::cmpPointer > Atlas::m_mapAtlasNounModifierToAtlasNounModifierEnum;
map< const string*, Atlas::eAtlasPinDescriptor, AIXMLHelper::cmpPointer > Atlas::m_mapAtlasePinDescriptorToEnum;
map< Atlas::eAtlasPinDescriptor, const string* > Atlas::m_mapAtlasPinDescriptorEnumToPinDescriptor;
map< Atlas::eAtlasPinDescriptor, const string* > Atlas::m_mapAtlasPinDescriptorEnumToPinDescriptorDescription;
map< Atlas::eAtlasPinDescriptor, ieee1641::eBSC > Atlas::m_mapAtlasPinDescriptorEnumTo1641BSCEnum;
map< Atlas::eAtlasPinDescriptor, ieee1641::eBSCAttribute > Atlas::m_mapAtlasPinDescriptorEnumTo1641BSCAttributeEnum;
map< Atlas::eAtlasNoun, const string* > Atlas::m_mapAtlasNounEnumToAtlasNoun;
map< Atlas::eAtlasNoun, const string* > Atlas::m_mapAtlasNounEnumToAtlasNounDescription;
map< Atlas::eAtlasNoun, ieee1641::eModel > Atlas::m_mapAtlasNounEnumTo1641ModelEnum;
map< Atlas::eAtlasNounModifier, const string* > Atlas::m_mapAtlasNounModifierEnumToAtlasNounModifierDescription;
map< Atlas::eAtlasNounModifier, ieee1641::eModel > Atlas::m_mapAtlasNounModifierEnumTo1641ModelEnum;
map< Atlas::eAtlasNounModifier, const string* > Atlas::m_mapAtlasNounModifierEnumToAtlasNounModifier;
map< Atlas::eAtlasNoun, ieee1641::eTSF > Atlas::m_mapAtlasNounEnumTo1641TSFEnum;
map< Atlas::eAtlasNounModifier, ieee1641::eBSC > Atlas::m_mapAtlasNounModifierEnumTo1641BSCEnum;
map< Atlas::eAtlasNounModifier, ieee1641::eBSCAttribute > Atlas::m_mapAtlasNounModifierEnumTo1641BSCAttributeEnum;
map< const string*, Atlas::eAtlasFunction, AIXMLHelper::cmpPointer > Atlas::m_mapAtlasFunctionToAtlasFunctionEnum;
map< Atlas::eAtlasFunction, const string* > Atlas::m_mapAtlasFunctionEnumToAtlasFunction;
map< Atlas::eAtlasFunction, const string* > Atlas::m_mapAtlasFunctionEnumToAtlasFunctionDescription;
map< Atlas::eAtlasFunction, ieee1641::eBSC > Atlas::m_mapAtlasFunctionEnumTo1641BSCEnum;
map< Atlas::eAtlasFunction, ieee1641::eModel > Atlas::m_mapAtlasFunctionEnumTo1641ModelEnum;
map< const string*, Atlas::eAtlasModifierSuffix, AIXMLHelper::cmpPointer > Atlas::m_mapAtlasSuffixToAtlasSuffixEnum;
map< Atlas::eAtlasModifierSuffix, const string* > Atlas::m_mapAtlasSuffixEnumToAtlasSuffix;
map< Atlas::eAtlasModifierSuffix, const string* > Atlas::m_mapAtlasSuffixToAtlasSuffixDescription;
map< Atlas::eAtlasModifierSuffix, ieee1641::eQualifier > Atlas::m_mapAtlasSuffixTo1641Qualifier;
map< const string*, Atlas::eAtlasResource, AIXMLHelper::cmpPointer > Atlas::m_mapAtlasResourceToAtlasResourceEnum;
map< Atlas::eAtlasResource, const string* > Atlas::m_mapAtlasResourceEnumToAtlasResource;
map< const string*, Atlas::eAtlasRequire, AIXMLHelper::cmpPointer > Atlas::m_mapAtlasRequireToAtlasRequireEnum;
map< Atlas::eAtlasRequire, const string* > Atlas::m_mapAtlasRequireEnumToAtlasRequire;
map< const string*, Atlas::eUnitOfMeasure, AIXMLHelper::cmpPointer > Atlas::m_mapAtlasUnitOfMeasureToEnum;
map< const string*, Atlas::eUnitOfMeasure, AIXMLHelper::cmpPointer > Atlas::m_mapSIUnitOfMeasureToEnum;
map< Atlas::eUnitOfMeasure, const string* > Atlas::m_mapUnitOfMeasureEnumToAtlasUnitOfMeasure;
map< Atlas::eUnitOfMeasure, const string* > Atlas::m_mapUnitOfMeasureEnumToSIUnitOfMeasure;
map< Atlas::eUnitOfMeasure, const string* > Atlas::m_mapUnitOfMeasureEnumToUnitOfMeasureDescription;
map< const string*, Atlas::eInputOutput, AIXMLHelper::cmpPointer > Atlas::m_mapAtlasInputOutputToAtlasInputOutputEnum;
map< Atlas::eInputOutput, const string* > Atlas::m_mapAtlasInputOutputEnumToAtlasInputOutput;
map< const string*, Atlas::eInputOutputAttribute, AIXMLHelper::cmpPointer > Atlas::m_mapAtlasInputOutputAttributeToAtlasInputOutputAttributeEnum;
map< Atlas::eInputOutputAttribute, const string* > Atlas::m_mapAtlasInputOutputAttributeEnumToAtlasInputOutputAttribute;
map< Atlas::eAtlasNoun, const Atlas::AtlasSignal > Atlas::m_mapAtlasSignalTo1641Signal;
map< const string*, Atlas::eDataType, AIXMLHelper::cmpPointer > Atlas::m_mapAtlasDataTypeToAtlasDataTypeEnum;
map< Atlas::eDataType, const string* > Atlas::m_mapAtlasDataTypeEnumToAtlasDataType;
map< const string*, Atlas::eEvaluationFieldType, AIXMLHelper::cmpPointer > Atlas::m_mapAtlasEvaluationFieldTypeToAtlasEvaluationFieldTypeEnum;
map< Atlas::eEvaluationFieldType, const string* > Atlas::m_mapAtlasEvaluationFieldTypeEnumToAtlasEvaluationFieldType;
map< const string*, Atlas::eAtlasSpecifyType, AIXMLHelper::cmpPointer > Atlas::m_mapAtlasSpecifyTypeToAtlasSpecifyTypeEnum;
map< Atlas::eAtlasSpecifyType, const string* > Atlas::m_mapAtlasSpecifyTypeEnumToAtlasSpecifyType;


const Atlas::ASTI Atlas::m_arrayAtlasVerb[ ] = 
{
	// Begin signal oriented
	ASTI( "INITIATE",				true ),
	ASTI( "SETUP",					true ),
	ASTI( "CONNECT",				true ),
	ASTI( "DISCONNECT",				true ),
	ASTI( "IDENTIFY",				true ),
	ASTI( "FETCH",					true ),
	ASTI( "ARM",					true ),
	ASTI( "CHANGE",					true ),
	ASTI( "APPLY",					true ),
	ASTI( "REMOVE",					true ),
	ASTI( "MEASURE",				true ),
	ASTI( "DEFINE",					true ),
	ASTI( "REQUIRE",				true ),
	ASTI( "MONITOR",				true ),
	ASTI( "VERIFY",					true ),
	ASTI( "READ",					true ),
	ASTI( "RESET",					true ),
	ASTI( "EXTEND",					true ),
	ASTI( "OPEN",					true ),
	ASTI( "CLOSE",					true ),
	// End signal oriented
	ASTI( "IF THEN",				false ),
	ASTI( "ELSE",					false ),
	ASTI( "WHILE THEN",				false ),
	ASTI( "FOR THEN",				false ),
	ASTI( "END IF",					false ),
	ASTI( "END WHILE",				false ),
	ASTI( "END FOR",				false ),
	ASTI( "END DEFINE",				false ),
	ASTI( "GO TO",					false ),
	ASTI( "LEAVE PROCEDURE",		false ),
	ASTI( "LEAVE IF",				false ),
	ASTI( "LEAVE FOR",				false ),
	ASTI( "LEAVE WHILE",			false ),
	ASTI( "TERMINATE ATLAS PROGRAM",false ),
	ASTI( "PERFORM",				false ),
	ASTI( "DEFINE PROCEDURE",		false ),
	ASTI( "READ DATETIME",			false ), // CASS special case for the "READ" verb
	ASTI( "DECLARE",				false ),
	ASTI( "CALCULATE",				false ),
	ASTI( "COMPARE",				false ),
	ASTI( "FILL",					false ),
	ASTI( "DELAY",					false ),
	ASTI( "WAIT FOR",				false ),
	ASTI( "ENABLE",					false ),
	ASTI( "DISABLE",				false ),
	ASTI( "PREPARE",				false ),
	ASTI( "EXECUTE",				false ),
	ASTI( "FINISH",					false ),
	ASTI( "DEFINE COMPLEX SIGNAL",	false ),
	ASTI( "SPECIFY",				false ),
	ASTI( "COMMENT",				false ),
	ASTI( "LEAVE ATLAS",			false ),
	ASTI( "RESUME ATLAS",			false ),
	ASTI( "DO EXCHANGE",			false ),
	ASTI( "INPUT",					false ),
	ASTI( "OUTPUT",					false )
};

const string Atlas::m_arrayAtlasResource[ ] = 
{
	"INPUT",
	"OUTPUT",
	"I-O",
	"SOURCE",
	"SENSOR",
	"TIMER",
	"DIGITAL TIMER",
	"LOAD",
	"EVENT MONITOR",
	"STIM",
	"RESP",
	"STIM-RESP",
	"STIM-RESP-COMP"
};

const string Atlas::m_arrayAtlasRequire[ ] = 
{
    "CONTROL",
	"CAPABILITY",
	"LIMIT",
	"CNX"
};

const string Atlas::m_arrayAtlasInputOutput[ ] = 
{
    "DEVICE",
	"FILE",
	m_arrayAtlasResource[ eInputResource ],
	m_arrayAtlasResource[ eOutputResource ],
	m_arrayAtlasResource[ eIOResource ]

};

const string Atlas::m_arrayAtlasInputOutputAttribute[ ] = 
{
	"LINE-LENGTH",
	"PAGE-SIZE",
	"HARD-COPY",
	"FILE-ORGANIZATION",
	"FILE-FORM",
	"RECORD-TYPE",
	"RECORD-LENGTH",
	"SEQUENTIAL",
	"FORMATTED",
	"VARIABLE",
	"RELATIVE",
	"UNFORMATTED",
	"FIXED",
	"DIRECT"
};

const string Atlas::m_arrayAtlasDataType[ ] = 
{
	"ENUMERATION",
	"DECIMAL",
	"INTEGER",
	"LONG-DECIMAL",
	"LONG-INTEGER",
	"CHAR",
	"BIT",
	"BITS",
	"CONNECTION",
	"CONN",
	"BOOLEAN",
	"MSGCHAR",
	"DIGITAL",
	"BNR",
	"B1C",
	"B2C",
	"BSM",
	"BCD",
	"SBCD"
};

const string Atlas::m_arrayAtlasEvaluationFieldType[ ] = 
{
	"NOM",
	"UL",
	"LL",
	"GT",
	"LT",
	"EQ",
	"NE",
	"LE",
	"GE"	
};

const string Atlas::m_arrayAtlasSpecifyType[ ] = 
{
	"REFERENCE-SIGNAL",
	"MOD-SIGNAL",
	"MOD-SIGNAL-D",
	"MOD-SIGNAL-I",
	"MOD-SIGNAL-Q",
	"SWEEP-CONTROL",
	"REFERENCE-LEVEL",
	"OSCILLATOR",
	"COMPONENT",
	"CARRIER"
};	 

const Atlas::ANI Atlas::m_arrayAtlasNoun[ ] = 
{
	ANI( "AC SIGNAL",				ieee1641::eAC_SIGNAL,				ieee1641::eStandardModel, true, "Alternating Current Signal" ),
	ANI( "ADF",						ieee1641::eUnknownTSF,				ieee1641::eStandardModel, false, "Automatic Direction Finder" ),
	ANI( "AM SIGNAL",				ieee1641::eAM_SIGNAL,				ieee1641::eStandardModel, true, "Amplitude Modulation Signal" ),
	ANI( "AMBIENT",					ieee1641::eUnknownTSF,				ieee1641::eStandardModel, false, "Ambient Conditions" ),
	ANI( "ATC",						ieee1641::eSSR_COMBINED,			ieee1641::eStandardModel, false, "Air Traffic Control" ),
	ANI( "COMMON",					ieee1641::eUnknownTSF,				ieee1641::eStandardModel, false, "Common" ),
	ANI( "COMPLEX SIGNAL",			ieee1641::eUnknownTSF,				ieee1641::eStandardModel, true, "Complex Signal" ),
	ANI( "DC SIGNAL",				ieee1641::eDC_SIGNAL,				ieee1641::eStandardModel, true, "Direct Current Signal" ),
	ANI( "DISPLACEMENT",			ieee1641::eUnknownTSF,				ieee1641::eStandardModel, false, "Displacement" ),
	ANI( "DME",						ieee1641::eDME_COMBINED,			ieee1641::eStandardModel, false, "Distance Measuring Equipment" ),
	ANI( "DOPPLER",					ieee1641::eUnknownTSF,				ieee1641::eStandardModel, false, "Doppler" ),
	ANI( "EARTH",					ieee1641::eUnknownTSF,				ieee1641::eStandardModel, false, "Earth" ),
	ANI( "EM FIELD",				ieee1641::eUnknownTSF,				ieee1641::eStandardModel, true, "Electro Magnetic Field" ),
	ANI( "EVENTS",					ieee1641::eUnknownTSF,				ieee1641::eStandardModel, false, "Events" ),
	ANI( "FLUID SIGNAL",			ieee1641::eUnknownTSF,				ieee1641::eStandardModel, false, "Fluid Signal" ),
	ANI( "FM SIGNAL",				ieee1641::eFM_SIGNAL,				ieee1641::eStandardModel, true, "Frequency Modulation Signal" ),
	ANI( "HEAT",					ieee1641::eUnknownTSF,				ieee1641::eStandardModel, false, "Heat" ),
	ANI( "IFF",						ieee1641::eSSR_COMBINED,			ieee1641::eStandardModel, false, "Identification, Friend or Foe" ),
	ANI( "ILS",						ieee1641::eILS_COMBINED,			ieee1641::eStandardModel, false, "Instrument Landing System" ),
	ANI( "IMPEDANCE",				ieee1641::eIMPEDANCE,				ieee1641::eStandardModel, true, "Impedance" ),
	ANI( "LIGHT",					ieee1641::eUnknownTSF,				ieee1641::eStandardModel, false, "Light" ),
	ANI( "LOGIC CONTROL",			ieee1641::eDIGITAL_COMBINED,		ieee1641::eStandardModel, false, "Logic Control" ),
	ANI( "LOGIC DATA",				ieee1641::eDIGITAL_COMBINED,		ieee1641::eStandardModel, false, "Logic Data" ),
	ANI( "LOGIC LOAD",				ieee1641::eUnknownTSF,				ieee1641::eStandardModel, false, "Logic Load" ),
	ANI( "LOGIC REFERENCE",			ieee1641::eDIGITAL_COMBINED,		ieee1641::eStandardModel, false, "Logic Reference" ),
	ANI( "MANOMETRIC",				ieee1641::eUnknownTSF,				ieee1641::eStandardModel, false, "Manometric" ),
	ANI( "PAM",						ieee1641::eUnknownTSF,				ieee1641::eStandardModel, true, "Pulse Amplitude Modulation" ),
	ANI( "PM SIGNAL",				ieee1641::ePM_SIGNAL,				ieee1641::eStandardModel, true, "Phase Modulated Signal" ),
	ANI( "PULSED AC",				ieee1641::ePULSED_AC_SIGNAL,		ieee1641::eStandardModel, true, "Pulsed Alternating Current Signal" ),
	ANI( "PULSED AC TRAIN",			ieee1641::ePULSED_AC_TRAIN,			ieee1641::eStandardModel, true, "Pulsed Alternating Current Signal Train" ),
	ANI( "PULSED DC",				ieee1641::ePULSED_DC_SIGNAL,		ieee1641::eStandardModel, true, "Pulsed Direct Current Signal" ),
	ANI( "PULSED DC TRAIN",			ieee1641::ePULSED_DC_TRAIN,			ieee1641::eStandardModel, true, "Pulsed Direct Current Signal Train" ),
	ANI( "PULSED DOPPLER",			ieee1641::eUnknownTSF,				ieee1641::eStandardModel, false, "Pulsed Doppler" ),
	ANI( "RADAR SIGNAL",			ieee1641::eRADAR_COMBINED,			ieee1641::eStandardModel, true, "Radar Signal" ),
	ANI( "RAMP SIGNAL",				ieee1641::eRAMP_SIGNAL,				ieee1641::eStandardModel, true, "Ramp Signal" ),
	ANI( "RANDOM NOISE",			ieee1641::eRANDOM_NOISE,			ieee1641::eStandardModel, false, "Radom Noise" ),
	ANI( "RESOLVER",				ieee1641::eRESOLVER,				ieee1641::eStandardModel, true, "Resolver" ),
	ANI( "ROTATION",				ieee1641::eUnknownTSF,				ieee1641::eStandardModel, false, "Rotation" ),
	ANI( "SHORT",					ieee1641::eUnknownTSF,				ieee1641::eStandardModel, true, "Short" ),
	ANI( "SQUARE WAVE",				ieee1641::eSQUARE_WAVE,				ieee1641::eStandardModel, true, "Square Wave" ),
	ANI( "STEP SIGNAL",				ieee1641::eSTEP_SIGNAL,				ieee1641::eStandardModel, true, "Step Signal" ),
	ANI( "SUP CAR SIGNAL",			ieee1641::eSUP_CAR_SIGNAL,			ieee1641::eStandardModel, true, "Suppressed Carrier Signal" ),
	ANI( "SYNCHRO",					ieee1641::eSYNCHRO,					ieee1641::eStandardModel, true, "Synchro" ),
	ANI( "TACAN",					ieee1641::eTACAN,					ieee1641::eStandardModel, false, "Tactical Air Navigation" ),
	ANI( "TIME INTERVAL",			ieee1641::eUnknownTSF,				ieee1641::eStandardModel, false, "Time Interval" ),
	ANI( "TRIANGULAR WAVE SIGNAL",	ieee1641::eTRIANGULAR_WAVE_SIGNAL,	ieee1641::eStandardModel, true, "Triangular Wave Signal" ),
	ANI( "TURBINE ENGINE DATA",		ieee1641::eUnknownTSF,				ieee1641::eStandardModel, false, "Turbine Engine Data" ),
	ANI( "VIBRATION",				ieee1641::eUnknownTSF,				ieee1641::eStandardModel, false, "Vibration" ),
	ANI( "VOR",						ieee1641::eVOR,						ieee1641::eStandardModel, true, "VHF Omnidirectional Radio Range" ),
	ANI( "WAVEFORM",				ieee1641::eUnknownTSF,				ieee1641::eStandardModel, true, "Waveform" ),
	ANI( "DIGITAL PATTERN",			ieee1641::eUnknownTSF,				ieee1641::eCassModel, false, "Digital Pattern" ),
	ANI( "PASS THRU GATING",		ieee1641::eUnknownTSF,				ieee1641::eCassModel, false, "Pass Thru Gating" ),
	ANI( "VIDEO SIGNAL",			ieee1641::eUnknownTSF,				ieee1641::eCassModel, true, "Video Signal" ),
	ANI( "BUILT-IN TEST",			ieee1641::eUnknownTSF,				ieee1641::eCassModel, false, "Built-in Test" ),
	ANI( "PULSE MODULATED SIGNAL",	ieee1641::ePULSE_MODULATED_SIGNAL,	ieee1641::eCassModel, true, "Pulse Modulated Signal" ),
	ANI( "ANALOG ADD",				ieee1641::eUnknownTSF,				ieee1641::eCassModel, false, "Analog Add" )
};

const Atlas::ASI Atlas::m_arrayAtlasModiferSuffix[ ] = 
{
	ASI( "P",			ieee1641::ePkQualifier,			"Peak" ),
	ASI( "PP",			ieee1641::ePk_PkQualifier,		"Peak-To-Peak" ),
	ASI( "TRMS",		ieee1641::eTrmsQualifier,		"True Root Mean Square" ),
	ASI( "AV",			ieee1641::eAvQualifier,			"Average" ),
	ASI( "POS",			ieee1641::ePk_PosQualifier,		"Positive" ),
	ASI( "NEG",			ieee1641::ePk_NegQualifier,		"Negative" ),
	ASI( "IN-PHASE",	ieee1641::eUnknownQualifier,	"In-Phase" ),
	ASI( "QUAD",		ieee1641::eUnknownQualifier,	"Quadrature Component" ),
	ASI( "INST",		ieee1641::eInstQualifier,		"Instantaneous" ),
	ASI( "PHASE",		ieee1641::eUnknownQualifier,	"Phase" ),
	ASI( "A",			ieee1641::eUnknownQualifier,	"A" ),
	ASI( "B",			ieee1641::eUnknownQualifier,	"B" ),
	ASI( "C",			ieee1641::eUnknownQualifier,	"C" ),
	ASI( "AB",			ieee1641::eUnknownQualifier,	"AB" ),
	ASI( "AC",			ieee1641::eUnknownQualifier,	"AB" ),
	ASI( "BA",			ieee1641::eUnknownQualifier,	"BA" ),
	ASI( "BC",			ieee1641::eUnknownQualifier,	"BC" ),
	ASI( "CA",			ieee1641::eUnknownQualifier,	"CA" ),
	ASI( "CB",			ieee1641::eUnknownQualifier,	"CB" ),
	ASI( "PHASE-A",		ieee1641::eUnknownQualifier,	"Phase A" ),
	ASI( "PHASE-B",		ieee1641::eUnknownQualifier,	"Phase B" ),
	ASI( "PHASE-C",		ieee1641::eUnknownQualifier,	"Phase C" ),
	ASI( "PHASE-AB",	ieee1641::eUnknownQualifier,	"Phase AB" ),
	ASI( "PHASE-AC",	ieee1641::eUnknownQualifier,	"Phase AC" ),
	ASI( "PHASE-BA",	ieee1641::eUnknownQualifier,	"Phase BA" ),
	ASI( "PHASE-BC",	ieee1641::eUnknownQualifier,	"Phase BC" ),
	ASI( "PHASE-CA",	ieee1641::eUnknownQualifier,	"Phase CA" ),
	ASI( "PHASE-CB",	ieee1641::eUnknownQualifier,	"Phase CB" ),
	ASI( "X",			ieee1641::eUnknownQualifier,	"X Orthogonal Axis" ),
	ASI( "Y",			ieee1641::eUnknownQualifier,	"Y Orthogonal Axis" ),
	ASI( "Z",			ieee1641::eUnknownQualifier,	"Z Orthogonal Axis" ),
	ASI( "R",			ieee1641::eUnknownQualifier,	"Radial Axis" ),
	ASI( "THETA",		ieee1641::eUnknownQualifier,	"Theta" ),
	ASI( "PHI",			ieee1641::eUnknownQualifier,	"Phi" ),
	ASI( "Pxxx",		ieee1641::eUnknownQualifier,	"Pulse" ),
	ASI( "QUIES",		ieee1641::eUnknownQualifier,	"Quiescent Signal" ),
	ASI( "ONE",			ieee1641::eUnknownQualifier,	"One" ),
	ASI( "ZERO",		ieee1641::eUnknownQualifier,	"Zero" ),
	ASI( "JITTER",		ieee1641::eUnknownQualifier,	"Jitter" ),
	ASI( "RATE",		ieee1641::eUnknownQualifier,	"Rate" ),
	ASI( "REF",			ieee1641::eUnknownQualifier,	"Reference" )
};

/*
	"-JITTER" | "-RATE"
	"-RATE"
	"-AV" | "-P" | "-PP" | "-TRMS"
	"-AV" | "-P"
	
	posneg				- { "POS" | "NEG" }
	xxx					- digit [ digit [ digit ] ] ;
	param-sfx			- { "-AV" | "-P" | "-PP" | "-P-NEG" | "-P-POS" | "-TRMS" }
	angle-sfx			- { "THETA" | "PHI" | "-X" | "-Y" | "-Z" | "-R" }
	mod-channel			- unsigned-integer-number [ "-X" | "-Y" ]
	ampl-sfx			- { param-sfx [ "-IN-PHASE" | "-QUAD" ] | "-IN-PHASE" | "-QUAD" } | "INST" }
	phase-sfx			- { "-PHASE-A" | "-PHASE-AB" | "-PHASE-AC" | "-PHASE-B" | "-PHASE-BC" | "-PHASE-CB" | "-PHASE-C" | "-PHASE-CA" | "-PHASE-BA" }
	pulse-sfx			- "-P" xxx
	log-noun-mod-sfx	- { "-ONE" | "-QUIES" | "-ZERO" }
	dist-sfx			- { "-X" | "-Y" | "-Z" | "-R" }
	flux-dens-sfx		- { "-IN-PHASE" | "-QUAD" }
	mod-atc-mode		- { "A" | "B" | "C" | "D" | "A-C" }
	mod-iff-mode		- {"1" | "2" | "3-A" | "3-C" | "4" | "C" }
	mod-tacan-mode		- { "RO" | "GA" | "AA" | "AB" } "-" { "I" | "N" }
	pulse-posn-sfx		- { { "-A" | "-B" | "-C" | "-D" } { "1" | "2" | "3" | "4" | "5" } | "-X" | "-SPI" | "-" unsigned-integer-number }
	pulse-spacing-sfx	- pulse-sfx "-" posneg pulse-sfx "-" posneg
	mod-trans-bits		- { "0" | "1" | "Q" } % [ "OR" { "0" | "1" | "Q" } % ]
	vibration-sfx		- { "-P" | "-PP" | "-TRMS" }
*/

const Atlas::AMNI Atlas::m_arrayAtlasNounModifier[ ] =
{
	AMNI( "AC-COMP",				ieee1641::eSinusoid,					ieee1641::eAmplitude,									ieee1641::eStandardModel, "Alternating Current Component" ),
	AMNI( "AC-COMP-FREQ",			ieee1641::eSinusoid,					ieee1641::eFrequency,									ieee1641::eStandardModel, "Alternating Current Component Frequency" ),
	AMNI( "AGE-RATE",				ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Aging Rate" ),
	AMNI( "ALT",					ieee1641::eConstant,					ieee1641::eAmplitude,									ieee1641::eStandardModel, "Altitude" ),
	AMNI( "ALT-RATE",				ieee1641::eSignalDelay,					ieee1641::eRate,										ieee1641::eStandardModel, "Altitude Rate" ),
	AMNI( "AM-COMP",				ieee1641::eSinusoid,					ieee1641::eAmplitude,									ieee1641::eStandardModel, "Amplitude Modulation Component" ),
	AMNI( "AM-SHIFT",				ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Amplitude Modulation Shift" ),
	AMNI( "AMPL-MOD",				ieee1641::eAM,							ieee1641::eModIndex,									ieee1641::eStandardModel, "Amplitude Codulation" ), //[ "-C" "Course" | "-F" "Fine"  ]
	AMNI( "ANGLE", 					ieee1641::eConstant,					ieee1641::eAmplitude,									ieee1641::eStandardModel, "Angle of Rotation" ), // [ angle-sfx ]
	AMNI( "ANGLE-ACCEL",			ieee1641::eSignalDelay,					ieee1641::eAcceleration,								ieee1641::eStandardModel, "Angle of Rotation Acceleration" ), //	[ angle-sfx ]
	AMNI( "ANGLE-RATE",				ieee1641::eSignalDelay,					ieee1641::eRate,										ieee1641::eStandardModel, "Angle of Rotation Rate" ), // [ angle-sfx ]
	AMNI( "ANT-SPEED-DEV",			ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Antenna Speed Deviation" ),
	AMNI( "ATMOS",					ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Standard Model Atmosphere" ),
	AMNI( "ATTEN",					ieee1641::eAttenuator,					ieee1641::eGain,										ieee1641::eStandardModel, "Attenuation" ),
	AMNI( "BANDWIDTH",				ieee1641::eBandpass_Notch,				ieee1641::eFrequencyBand,								ieee1641::eStandardModel, "Bandwidth" ),
	AMNI( "BAROMETRIC-PRESS",		ieee1641::eConstant,					ieee1641::eAmplitude,									ieee1641::eStandardModel, "Barometric Pressure" ),
	AMNI( "BIT-RATE",				ieee1641::eSerialData,					ieee1641::ePeriod,										ieee1641::eStandardModel, "BIT Rate" ),
	AMNI( "BURST",					ieee1641::ePulseDefns,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Burst Length" ),
	AMNI( "BURST-DROOP",			ieee1641::ePulseDefns,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Burst Droop" ),
	AMNI( "BURST-REP-RATE",			ieee1641::ePulseDefns,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Burst Repetition Rate" ),
	AMNI( "CAP",					ieee1641::eConstant,					ieee1641::eAmplitude,									ieee1641::eStandardModel, "Capacitance" ),
	AMNI( "CAR-AMPL",				ieee1641::eSinusoid,					ieee1641::eAmplitude,									ieee1641::eStandardModel, "Carrier Amplitude" ),
	AMNI( "CAR-FREQ",				ieee1641::eSinusoid,					ieee1641::eFrequency,									ieee1641::eStandardModel, "Carrier Frequency" ),
	AMNI( "CAR-HARMONICS",			ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Carrier Harmonics" ),
	AMNI( "CAR-PHASE",				ieee1641::eSinusoid,					ieee1641::ePhase,										ieee1641::eStandardModel, "Carrier Phase" ),
	AMNI( "CAR-RESID",				ieee1641::eSinusoid,					ieee1641::eAmplitude,									ieee1641::eStandardModel, "Carrier Residual" ),
	AMNI( "CHANNELxxx",				ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Channel" ), // mod-channel: unsigned-integer-number [ "-X" | "-Y" ]
	AMNI( "COMPL",					ieee1641::eConstant,					ieee1641::eAmplitude,									ieee1641::eStandardModel, "Complement" ),
	AMNI( "CONDUCTANCE",			ieee1641::eConstant,					ieee1641::eAmplitude,									ieee1641::eStandardModel, "Conductance" ),
	AMNI( "COUNT",					ieee1641::eCounter,						ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Count" ),
	AMNI( "CREST-FACTOR",			ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Crest Factor" ),
	AMNI( "CURRENT",				ieee1641::eConstant,					ieee1641::eAmplitude,									ieee1641::eStandardModel, "Current" ), //  [ ampl-sfx | phase-sfx | pulse-sfx | log-noun-mod-sfx ]
	AMNI( "CURRENT-LMT",			ieee1641::eConstant,					ieee1641::eAmplitude,									ieee1641::eStandardModel, "Current Limit" ),
	AMNI( "CW-LEVEL",				ieee1641::eConstant,					ieee1641::eAmplitude,									ieee1641::eStandardModel, "Continuous-wave Level" ),
	AMNI( "DBL-INT",				ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Double Interrogation" ),
	AMNI( "DC-OFFSET",				ieee1641::eConstant,					ieee1641::eAmplitude,									ieee1641::eStandardModel, "Direct Current Offset" ),
	AMNI( "DDM",					ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Difference in Depth of Modulation" ),
	AMNI( "DEBRIS-COUNT",			ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Debris Count" ),
	AMNI( "DEBRIS-SIZE",			ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Debris Size" ),
	AMNI( "DEWPOINT",				ieee1641::eConstant,					ieee1641::eAmplitude,									ieee1641::eStandardModel, "Dewpoint" ),
	AMNI( "DISS-FACTOR",			ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Dissipation Factor" ),
	AMNI( "DISTANCE",				ieee1641::eUnknownBSC,					ieee1641::eAmplitude,									ieee1641::eStandardModel, "Distance" ), // [ dist-sfx | angle-sfx ]
	AMNI( "DISTORTION",				ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Total Distortion" ),
	AMNI( "DOMINANT-MOD-SIG",		ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Dominant Modulating Signal" ),
	AMNI( "DOPPLER-BANDWIDTH",		ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Doppler Bandwidth" ),
	AMNI( "DOPPLER-FREQ",			ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Doppler Frequency" ),
	AMNI( "DOPPLER-SHIFT",			ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Doppler Shift" ),
	AMNI( "DROOP",					ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Droop" ), // [ pulse-sfx ]		
	AMNI( "DUTY-CYCLE",				ieee1641::eSquareWave_Triangle,			ieee1641::eDutyCycle,									ieee1641::eStandardModel, "Duty Cycle" ),
	AMNI( "EFF",					ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Efficiency" ),
	AMNI( "EFFICACY",				ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Efficacy" ),
	AMNI( "FALL-TIME",				ieee1641::eTrapezoid_SingleTrapezoid,	ieee1641::eFallTime,									ieee1641::eStandardModel, "Fall Time" ), // [ pulse-sfx ]
	AMNI( "FIELD-STRENGTH",			ieee1641::eUnknownBSC,					ieee1641::eAmplitude,									ieee1641::eStandardModel, "Field Strength" ),
	AMNI( "FLUID-TYPE",				ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Fluid Type" ),
	AMNI( "FLUX-DENS",				ieee1641::eUnknownBSC,					ieee1641::eAmplitude,									ieee1641::eStandardModel, "Flux Density" ), // [ flux-dens-sfx ]
	AMNI( "FM-COMP",				ieee1641::eFM,							ieee1641::eFrequencyDeviation,							ieee1641::eStandardModel, "Frequency Modulation Component" ),
	AMNI( "FORCE",					ieee1641::eConstant,					ieee1641::eAmplitude,									ieee1641::eStandardModel, "Force" ),
	AMNI( "FORCE-RATE",				ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Force Rate" ),
	AMNI( "FREQ",					ieee1641::eSinusoid_Modulator_Filter,	ieee1641::eFrequency_CarrierFrequency_CenterFrequency,	ieee1641::eStandardModel, "Frequency" ),
	AMNI( "FREQ-DEV",				ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Frequency Deviation" ),
	AMNI( "FREQ-ONE",				ieee1641::eSinusoid,					ieee1641::eFrequency,									ieee1641::eStandardModel, "Frequency-One" ),
	AMNI( "FREQ-QUIES",				ieee1641::eSinusoid,					ieee1641::eFrequency,									ieee1641::eStandardModel, "Frequency-Zero" ),
	AMNI( "FREQ-ZERO",				ieee1641::eSinusoid,					ieee1641::eFrequency,									ieee1641::eStandardModel, "Frequency Quiescent" ),
	AMNI( "FREQ-PAIRING",			ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Frequency Pairing" ),
	AMNI( "FREQ-WINDOW",			ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Frequency Window" ),
	AMNI( "FUEL-SUPPLY",			ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Fuel Supply" ),
	AMNI( "GLIDE-SLOPE",			ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Glide Slope" ),
	AMNI( "HARMONICS",				ieee1641::eSinusoid,					ieee1641::eAmplitude,									ieee1641::eStandardModel, "Harmonic Distortion" ),
	AMNI( "HARM-xxx-PHASE",			ieee1641::eSinusoid,					ieee1641::ePhase,										ieee1641::eStandardModel, "Phase of the xxx Harmonic" ),
	AMNI( "HARM-xxx-POWER",			ieee1641::eSinusoid,					ieee1641::eAmplitude,									ieee1641::eStandardModel, "Power of the xxx Harmonic" ),
	AMNI( "HARM-xxx-VOLTAGE",		ieee1641::eSinusoid,					ieee1641::eAmplitude,									ieee1641::eStandardModel, "Voltage of the xxx Harmonic" ),
	AMNI( "HI-MOD-FREQ",			ieee1641::eSinusoid,					ieee1641::eAmplitude,									ieee1641::eStandardModel, "High Modulation Frequency" ),
	AMNI( "HUMIDITY",				ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Humidity" ),
	AMNI( "IAS",					ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Indicated Airspeed" ),
	AMNI( "IDENT-SIG",				ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Identification Signal" ),
	AMNI( "IDENT-SIG-EP",			ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Identification Signal EP" ),
	AMNI( "IDENT-SIG-FREQ",			ieee1641::eSinusoid,					ieee1641::eFrequency,									ieee1641::eStandardModel, "Identification Signal Frequency" ),
	AMNI( "IDENT-SIG-MOD",			ieee1641::eAM,							ieee1641::eModIndex,									ieee1641::eStandardModel, "Identification Signal Modulation" ),
	AMNI( "ILLUM",					ieee1641::eUnknownBSC,					ieee1641::eAmplitude,									ieee1641::eStandardModel, "Illumination" ),
	AMNI( "IND",					ieee1641::eUnknownBSC,					ieee1641::eAmplitude,									ieee1641::eStandardModel, "Inductance" ),
	AMNI( "INT",					ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Interrogation" ), // { "-JITTER" | "-RATE" }
	AMNI( "LO-MOD-FREQ",			ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Low Modulation Frequency" ),
	AMNI( "LOCALIZER",				ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Localizer" ),
	AMNI( "LUMINANCE",				ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Luminance" ),
	AMNI( "LUM-FLUX",				ieee1641::eUnknownBSC,					ieee1641::eAmplitude,									ieee1641::eStandardModel, "Luminous Flux" ),
	AMNI( "LUM-INT",				ieee1641::eUnknownBSC,					ieee1641::eAmplitude,									ieee1641::eStandardModel, "Luminous Intensity" ),
	AMNI( "LUM-TEMP",				ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Luminous Temperature" ),
	AMNI( "MAG-BEARING",			ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Magnetic Bearing" ), // [ "-RATE" ]
	AMNI( "MARKER-BEACON",			ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Marker Beacon" ),
	AMNI( "MASS-FLOW",				ieee1641::eUnknownBSC,					ieee1641::eAmplitude,									ieee1641::eStandardModel, "Mass Flow" ),
	AMNI( "MEAN-MOD",				ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Mean Modulation" ),
	AMNI( "MOD-AMPL",				ieee1641::eAM_FM_PM,					ieee1641::eIn,											ieee1641::eStandardModel, "Modulation Amplitude" ),
	AMNI( "MOD-DIST",				ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Modulation Distortion" ),
	AMNI( "MOD-FREQ",				ieee1641::eAM_FM_PM,					ieee1641::eIn,											ieee1641::eStandardModel, "Modulation Frequency" ),
	AMNI( "MOD-OFFSET",				ieee1641::eConstant,					ieee1641::eAmplitude,									ieee1641::eStandardModel, "Modulation Offset" ),
	AMNI( "MOD-PHASE",				ieee1641::eSinusoid,					ieee1641::ePhase,										ieee1641::eStandardModel, "Modulation Phase" ),
	AMNI( "MODE",					ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Mode" ), // [ mod-atc-mode | mod-iff-mode | mod-tacan-mode ]
	AMNI( "NEG-SLOPE",				ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Negative Slope" ),
	AMNI( "NOISE",					ieee1641::eNoise,						ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Noise Amplitude" ), // [ "-AV" | "-P" | "-PP" | "-TRMS" ]
	AMNI( "NOISE-AMPL-DENS",		ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Noise Amplitude Density" ),
	AMNI( "NOISE-PWR-DENS",			ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Noise Power Density" ),
	AMNI( "NON-HARMONICS",			ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Non-Harmonic Distortion" ),
	AMNI( "NON-LIN",				ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Non-Linearity" ),
	AMNI( "OPER-TEMP",				ieee1641::eUnknownBSC,					ieee1641::eAmplitude,									ieee1641::eStandardModel, "Operating Temperature" ),
	AMNI( "OVERSHOOT",				ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Overshoot" ), // [ pulse-sfx ]
	AMNI( "P-AMPL",					ieee1641::ePeak,						ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Peak Pulse Amplitude" ),	
	AMNI( "P3-DEV",					ieee1641::ePulseDefns,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "P3 Pulse Deviation" ),
	AMNI( "P3-LEVEL",				ieee1641::ePulseDefns,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "P3 Pulse Level" ),
	AMNI( "PAIR-DROOP",				ieee1641::ePulseDefns,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Pulse Pair Droop" ),
	AMNI( "PAIR-SPACING",			ieee1641::ePulseDefns,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Pair Spacing" ),
	AMNI( "PEAK-DEGEN",				ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Peak Degeneration" ),
	AMNI( "PERIOD",					ieee1641::ePeriodic_TimedEvent,			ieee1641::ePeriod,										ieee1641::eStandardModel, "Period" ),
	AMNI( "PHASE-ANGLE",			ieee1641::eSinusoid,					ieee1641::ePhase,										ieee1641::eStandardModel, "Phase Angle" ),
	AMNI( "PHASE-DEV",				ieee1641::ePM,							ieee1641::ePhaseDeviation,								ieee1641::eStandardModel, "Phase Deviation" ),
	AMNI( "PHASE-JIT",				ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Phase Jitter" ),
	AMNI( "PHASE-SHIFT",			ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Phase Shift" ),
	AMNI( "PLA",					ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Power Lever Angle" ),
	AMNI( "PLA-RATE",				ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Power Lever Angle Rate" ),
	AMNI( "POS-SLOPE",				ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Positive Slope" ),
	AMNI( "POWER",					ieee1641::eUnknownBSC,					ieee1641::eAmplitude,									ieee1641::eStandardModel, "Power" ), // [ "-AV" | "-P" ]
	AMNI( "POWER-DIFF",				ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Power Differential" ),
	AMNI( "PRESHOOT",				ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Preshoot" ), // [ pulse-sfx ]
	AMNI( "PRESS-A",				ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Absolute Pressure" ),
	AMNI( "STATIC-PRESS-A",			ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Static Absolute Pressure" ), // prefix
	AMNI( "TOTAL-PRESS-A",			ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Total Absolute Pressure" ), // prefix
	AMNI( "PRESS-G",				ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Gauge Pressure" ),
	AMNI( "STATIC-PRESS-G",			ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Static Gauge Pressure" ), // prefix
	AMNI( "TOTAL-PRESS-G",			ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Total Gauge Pressure" ), // prefix
	AMNI( "PRESS-RATE",				ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Pressure Rate" ),
	AMNI( "STATIC-PRESS-RATE",		ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Static Pressure Rate" ), // prefix
	AMNI( "TOTAL-PRESS-RATE",		ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Total Pressure Rate" ), // prefix
	AMNI( "PRESS-OSC-AMPL",			ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Pressure Oscillation Amplitude" ),
	AMNI( "PRESS-OSC-FREQ",			ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Pressure Oscillation Frequency" ),
	AMNI( "PRF",					ieee1641::eTimedEvent,					ieee1641::ePeriod,										ieee1641::eStandardModel, "Pulse Repetition Frequency" ),
	AMNI( "PULSE-CLASS",			ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Pulse Class" ),
	AMNI( "PULSE-IDENT",			ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Pulse Identification" ),
	AMNI( "PULSE-POSN",				ieee1641::ePulseDefns,					ieee1641::eStart,										ieee1641::eStandardModel, "Pulse Position of Pulse x" ), // pulse-posn-sfx
	AMNI( "PULSE-SPECT",			ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Pulse Spectrum" ),
	AMNI( "PULSE-SPECT-THRESHOLD",	ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Pulse Spectrum Threshold" ),
	AMNI( "PULSE-WIDTH",			ieee1641::ePulseDefns,					ieee1641::ePulseWidth,									ieee1641::eStandardModel, "Pulse Width" ), // [ pulse-sfx ]
	AMNI( "PULSES-EXCL",			ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Pulses Excluded" ),
	AMNI( "PULSES-INCL",			ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Pulses Included" ),
	AMNI( "PWR-LMT",				ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Power Limit" ),
	AMNI( "Q",						ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Quality Factor" ),
	AMNI( "QUAD",					ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Quadrature Voltage" ),
	AMNI( "RADIAL",					ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Radial" ),
	AMNI( "RADIAL-RATE",			ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Radial Rate" ),
	AMNI( "RANGE-PULSE-DEV",		ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Range Pulse Deviation" ),
	AMNI( "RANGE-PULSE-ECHO",		ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Range Pulse Echo" ),
	AMNI( "REACTANCE",				ieee1641::eLoad,						ieee1641::eReactance,									ieee1641::eStandardModel, "Reactance" ),
	AMNI( "REF-FREQ",				ieee1641::eSinusoid,					ieee1641::eFrequency,									ieee1641::eStandardModel, "Reference Frequency" ),
	AMNI( "REF-INERTIAL",			ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Reference Inertial" ),
	AMNI( "REF-PHASE-FREQ",			ieee1641::eSinusoid,					ieee1641::eFrequency,									ieee1641::eStandardModel, "Reference Phase Modulation Frequency" ),
	AMNI( "REF-POWER",				ieee1641::eUnknownBSC,					ieee1641::eAmplitude,									ieee1641::eStandardModel, "Reference Power" ),
	AMNI( "REF-PULSES",				ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Reference Pulses" ),
	AMNI( "REF-PULSES-EXCL",		ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Reference Pulses Excluded" ),
	AMNI( "REF-PULSES-INCL",		ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Reference Pulses Included" ),
	AMNI( "REF-PULSES-DEV",			ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Reference Pulses Deviation" ),
	AMNI( "REF-UUT",				ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Reference UUT" ),
	AMNI( "REF-VOLT",				ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Reference Voltage" ),
	AMNI( "REL-BEARING",			ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Relative Bearing" ),
	AMNI( "REL-BEARING-RATE",		ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Relative Bearing Rate" ),
	AMNI( "RELATIVE-HUMIDITY",		ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Relative Humidity" ),
	AMNI( "RELATIVE-WIND",			ieee1641::eUnknownBSC,					ieee1641::eAmplitude,									ieee1641::eStandardModel, "Relative Wind" ),
	AMNI( "REPLY-EFF",				ieee1641::eProbabilityEvent,			ieee1641::eProbability,									ieee1641::eStandardModel, "Reply Efficiency" ),
	AMNI( "RES",					ieee1641::eLoad,						ieee1641::eAmplitude,									ieee1641::eStandardModel, "Resistance" ),
	AMNI( "RESP",					ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Response" ),
	AMNI( "RINGING",				ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Ringing" ), // [ pulse-sfx ]
	AMNI( "RISE-TIME",				ieee1641::eTrapezoid_SingleTrapezoid,	ieee1641::eRiseTime,									ieee1641::eStandardModel, "Rise Time" ), // [ pulse-sfx ]
	AMNI( "ROTOR-SPEED",			ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Rotor Speed" ),
	AMNI( "ROUNDING",				ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Rounding" ), // [ pulse-sfx ]
	AMNI( "SAMPLE",					ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Sample" ),
	AMNI( "SAMPLE-SPACING",			ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Sample Spacing" ),
	AMNI( "SAMPLE-TIME",			ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Sample Time" ),
	AMNI( "SAMPLE-WIDTH",			ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Sample Width" ),
	AMNI( "SETTLE-TIME",			ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Settle Time" ),
	AMNI( "SHAFT-SPEED",			ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Shaft Speed" ),
	AMNI( "SKEW-TIME",				ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Skew Time" ),
	AMNI( "SLANT-RANGE",			ieee1641::eConstant,					ieee1641::eAmplitude,									ieee1641::eStandardModel, "Slant Range" ),
	AMNI( "SLANT-RANGE-ACCEL",		ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Slant Range Acceleration" ),
	AMNI( "SLANT-RANGE-RATE",		ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Slant Range Rate" ),
	AMNI( "SLEW-RATE",				ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Slew Rate" ),
	AMNI( "SLS-DEV",				ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Side-Lobe-Suppression Deviation" ),
	AMNI( "SLS-LEVEL",				ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Side-Lobe-Suppression Level" ),
	AMNI( "SPACING",				ieee1641::ePulseDefns,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Spacing" ), // pulse-spacing-sfx
	AMNI( "SPEC-GRAV",				ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Specific Gravity" ),
	AMNI( "SPEC-TEMP",				ieee1641::eUnknownBSC,					ieee1641::eAmplitude,									ieee1641::eStandardModel, "Specification Temperature" ),
	AMNI( "SQTR-DIST",				ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Squitter Distribution" ), // [ "-" xxx ]
	AMNI( "SQTR-RATE",				ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Squitter Rate" ),
	AMNI( "STIM",					ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Stimulus" ),
	AMNI( "SUB-CAR-FREQ",			ieee1641::eSinusoid,					ieee1641::eFrequency,									ieee1641::eStandardModel, "Sub-Carrier Frequency" ),
	AMNI( "SUB-CAR-MOD",			ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Sub-Carrier Modulation" ),
	AMNI( "SUSCEPTANCE",			ieee1641::eLoad,						ieee1641::eSusceptance,									ieee1641::eStandardModel, "Susceptance" ),
	AMNI( "SWEEP-TIME",				ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Sweep Time" ),
	AMNI( "SWR",					ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Standing Wave Ratio" ),
	AMNI( "TARGET-RANGE",			ieee1641::eConstant,					ieee1641::eAmplitude,									ieee1641::eStandardModel, "Target Range" ),
	AMNI( "TARGET-RANGE-ACCEL",		ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Target Range Acceleration" ),
	AMNI( "TARGET-RANGE-RATE",		ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Target Range Rate" ),
	AMNI( "TAS",					ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "True Airspeed" ),
	AMNI( "TEMP",					ieee1641::eUnknownBSC,					ieee1641::eAmplitude,									ieee1641::eStandardModel, "Temperature" ),
	AMNI( "STATIC-TEMP",			ieee1641::eUnknownBSC,					ieee1641::eAmplitude,									ieee1641::eStandardModel, "Static Temperature" ), // prefix
	AMNI( "TOTAL-TEMP",				ieee1641::eUnknownBSC,					ieee1641::eAmplitude,									ieee1641::eStandardModel, "Total  Temperature" ), // prefix
	AMNI( "TEMP-COEF-CAP",			ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Capacitance Temperature Coefficient" ),
	AMNI( "TEMP-COEF-CURRENT",		ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Current Temperature Coefficient" ),
	AMNI( "TEMP-COEF-IND",			ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Inductance Temperature Coefficient" ),
	AMNI( "TEMP-COEF-REACT",		ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Reactance Temperature Coefficient" ),
	AMNI( "TEMP-COEF-RES",			ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Resistance Temperature Coefficient" ),
	AMNI( "TEMP-COEF-VOLT",			ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Voltage Temperature Coefficient" ),
	AMNI( "THREE-PHASE-DELTA",		ieee1641::eThreePhaseDelta,				ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Three Phase Delta" ),
	AMNI( "THREE-PHASE-WYE",		ieee1641::eThreePhaseWye,				ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Three Phase Wye" ),
	AMNI( "THRUST",					ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Thrust" ),
	AMNI( "TIME",					ieee1641::eUnknownBSC,					ieee1641::eAmplitude,									ieee1641::eStandardModel, "Time" ),
	AMNI( "TIME-ASYM",				ieee1641::eThreePhaseDelta,				ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Time Asymmetry" ),
	AMNI( "TIME-JIT",				ieee1641::eThreePhaseDelta,				ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Time Jitter" ),
	AMNI( "TORQUE",					ieee1641::eUnknownBSC,					ieee1641::eAmplitude,									ieee1641::eStandardModel, "Torque" ),
	AMNI( "TRANS-ONE",				ieee1641::eThreePhaseDelta,				ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Transition-One" ), // mod-trans-bits
	AMNI( "TRANS-PERIOD",			ieee1641::eThreePhaseDelta,				ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Transition-Period" ), // mod-trans-bits
	AMNI( "TRANS-ZERO",				ieee1641::eThreePhaseDelta,				ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Transition-Zero" ), // mod-trans-bits
	AMNI( "TRIG",					ieee1641::eConstant,					ieee1641::eAmplitude,									ieee1641::eStandardModel, "Trigger" ),
	AMNI( "TRUE",					ieee1641::eConstant,					ieee1641::eAmplitude,									ieee1641::eStandardModel, "True" ),
	AMNI( "TYPE",					ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Type" ),
	AMNI( "UNDERSHOOT",				ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Undershoot" ), // [ pulse-sfx ]
	AMNI( "VALUE",					ieee1641::eSerialDigital_ParallelDigital,ieee1641::eData,										ieee1641::eStandardModel, "Value" ),
	AMNI( "VAR-PHASE-FREQ",			ieee1641::eSinusoid,					ieee1641::eFrequency,									ieee1641::eStandardModel, "Variable Phase Frequency" ),
	AMNI( "VAR-PHASE-MOD",			ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Variable Phase Modulation" ),
	AMNI( "VIBRATION-ACCEL",		ieee1641::eSignalDelay,					ieee1641::eAcceleration,								ieee1641::eStandardModel, "Vibration Acceleration" ),
	AMNI( "VIBRATION-AMPL",			ieee1641::eSinusoid,					ieee1641::eAmplitude,									ieee1641::eStandardModel, "Vibration Amplitude" ), // vibration-sfx
	AMNI( "VIBRATION-RATE",			ieee1641::eSignalDelay,					ieee1641::eRate,										ieee1641::eStandardModel, "Vibration Rate" ),
	AMNI( "VOLTAGE",				ieee1641::eUnknownBSC,					ieee1641::eAmplitude,									ieee1641::eStandardModel, "Voltage" ), // [ ampl-sfx | phase-sfx | pulse-sfx ]
	AMNI( "VOLTAGE-ONE",			ieee1641::eConstant,					ieee1641::eAmplitude,									ieee1641::eStandardModel, "Voltage-One" ),
	AMNI( "VOLTAGE-ZERO",			ieee1641::eConstant,					ieee1641::eAmplitude,									ieee1641::eStandardModel, "Voltage-Zero" ),
	AMNI( "VOLTAGE-QUIES",			ieee1641::eConstant,					ieee1641::eAmplitude,									ieee1641::eStandardModel, "Voltage Quiescent" ),
	AMNI( "VOLTAGE-RAMPED",			ieee1641::eWaveformRamp,				ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Voltage Ramped" ),
	AMNI( "VOLTAGE-STEPPED",		ieee1641::eWaveformStep,				ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Voltage Stepped" ),
	AMNI( "VOLT-LMT",				ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Voltage Limit" ),
	AMNI( "VOLUME-FLOW",			ieee1641::eUnknownBSC,					ieee1641::eAmplitude,									ieee1641::eStandardModel, "Volume Flow" ),
	AMNI( "WAVE-LENGTH",			ieee1641::eSinusoid,					ieee1641::eFrequency,									ieee1641::eStandardModel, "Wave Length" ),
	AMNI( "WIND-SPEED",				ieee1641::eUnknownBSC,					ieee1641::eAmplitude,									ieee1641::eStandardModel, "Wind Speed" ),
	AMNI( "WORD-LENGTH",			ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Word Length" ),
	AMNI( "WORD-RATE",				ieee1641::eParallelDigital,				ieee1641::ePeriod,										ieee1641::eStandardModel, "Word Rate" ),
	AMNI( "ZERO-INDEX",				ieee1641::eConstant,					ieee1641::eAmplitude,									ieee1641::eStandardModel, "Zero Power" ),
	AMNI( "GATED",					ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Gated" ),
	AMNI( "BAND-PASS-FILTER",		ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Band Pass Filter" ),
	AMNI( "DIVIDE",					ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Divide" ),
	AMNI( "DE-EMPHASIS",			ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "De-emphasis" ),
	AMNI( "GAIN",					ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Gain" ),
	AMNI( "HI-PASS-FILTER",			ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Hi-pass Filter" ),
	AMNI( "ISOLATION",				ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Isolation" ),
	AMNI( "LO-PASS-FILTER",			ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Lo-pass Filter" ),
	AMNI( "NOTCH-FILTER",			ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Notch Filter" ),
	AMNI( "PRE-EMPHASIS",			ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Pre-emphasis" ),
	AMNI( "ROLLOFF",				ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Rolloff" ),
	AMNI( "ROLLOFF-LOWER",			ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Rolloff Lower" ),
	AMNI( "ROLLOFF-UPPER",			ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Rolloff Upper" ),
	AMNI( "POWER-MARK",				ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Power Mark" ),
	AMNI( "POWER-MARK-UPPER",		ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Power Mark Upper" ),
	AMNI( "POWER-MARK-LOWER",		ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Power Mark Lower" ),
	AMNI( "FREQ-MARK",				ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Freq Mark" ),
	AMNI( "FREQ-MARK-UPPER",		ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Freq Mark Upper" ),
	AMNI( "FREQ-MARK-LOWER",		ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Freq Mark Lower" ),
	AMNI( "FREQ-MARK-HARM",			ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Freq Mark Harmonic" ),
	AMNI( "FORWARD",				ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Forward" ),
	AMNI( "FORWARD-HOLD",			ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Forward Hold" ),
	AMNI( "FORWARD-HOLD-RESET-HOLD",ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Forward Hold Reset Hold" ),
	AMNI( "FORWARD-HOLD-REVERSE-HOLD",ieee1641::eUnknownBSC,				ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Forward Hold Reverse Hold" ),
	AMNI( "FORWARD-REVERSE",		ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Forward Reverse" ),
	AMNI( "REVERSE",				ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Reverse" ),
	AMNI( "FSK",					ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Frequency Sweeping" ),
	AMNI( "SEQUENCE",				ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Sequence" ),
	AMNI( "SEQUENCE-HOLD",			ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Sequence Hold" ),
	AMNI( "SEQUENCE-HOLD-RESET-HOLD",ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Sequence Hold Reset Hold" ),
	AMNI( "SEQUENCE-STEP",			ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Sequence Step" ),
	AMNI( "MAX-TIME",				ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "Maximum Time" ),
	AMNI( "DELAY",					ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eStandardModel, "DELAY" ),
	AMNI( "COUPLING",				ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "Coupling" ),
	AMNI( "COUPLING-REF",			ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "Coupling Reference" ),
	AMNI( "TEST-EQUIP-IMP",			ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "Test Equipment Impedance" ),
	AMNI( "TRIG-OUT-DRIVE",			ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "Trigger Output Mode" ),
	AMNI( "START-PC",				ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "Starting Percentage" ),
	AMNI( "STOP-PC",				ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "Stopping Percentage" ),
	AMNI( "REF-VOLTAGE-P",			ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "Reference Measurement of the Pulse Amplitude" ),
	AMNI( "SAMPLE-AV",				ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "Number of Periods to Average" ),
	AMNI( "PATTERN-SIZE",			ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "Pattern Size" ),
	AMNI( "PATTERN-RATE",			ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "Pattern Rate" ),
	AMNI( "PATTERN-HOLD-COUNT",		ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "Pattern Hold Count" ),
	AMNI( "SOURCE-IDENTIFIER",		ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "Source Indentifier" ),
	AMNI( "CIRCULATE",				ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "Circulate" ),
	AMNI( "REF-SOURCE",				ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "Source Reference Voltage" ),
	AMNI( "SPEED-RATIO",			ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "Speed Ratio" ),
	AMNI( "VFMT",					ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "Video Format" ),
	AMNI( "DOT-CLOCK",				ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "Frequency of the Master Clock" ),
	AMNI( "SWEEP-DELAY",			ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "Sweep Delay" ),
	AMNI( "HALF-CYCLE-DELAY",		ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "Half Cycle Delay" ),
	AMNI( "DWELL-TIME",				ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "Dwell Time" ),
	AMNI( "BURST-DELAY",			ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "Burst Delay" ),
	AMNI( "SWEEP-TYPE",				ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "Sweep Type" ),
	AMNI( "STEP-TIME",				ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "Step Time" ),
	AMNI( "RATE",					ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "Rate" ),
	AMNI( "ACTIVE",					ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "Active" ),
	AMNI( "BLANK",					ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "Blank" ),
	AMNI( "TOTAL",					ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "Total" ),
	AMNI( "SIZE",					ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "Size" ),
	AMNI( "FRONT-PORCH",			ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "Front Porch" ),
	AMNI( "NON-INTERLACE",			ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "Non-interlace" ),
	AMNI( "INTERLACE",				ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "Interlace" ),
	AMNI( "ANALOG-COMP",			ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "Analog Comp" ),
	AMNI( "DIGITAL-COMP",			ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "Digital Comp" ),
	AMNI( "DIGITAL-SEPARATE",		ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "Digital Separate" ),
	AMNI( "ON-VIDEO",				ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "On-video" ),
	AMNI( "EQ-BEFORE",				ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "Equal Before" ),
	AMNI( "EQ-AFTER",				ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "Equal After" ),
	AMNI( "SERRATION",				ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "Serration" ),
	AMNI( "SWING",					ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "Swing" ),
	AMNI( "HORIZONTAL",				ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "Horizontal" ),
	AMNI( "VERTICAL",				ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "Vertical" ),
	AMNI( "COMPOSITE",				ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "Composite" ),
	AMNI( "COLOR",					ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "Color" ),
	AMNI( "MONO",					ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "Mono" ),
	AMNI( "PEDESTAL",				ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "Pedestal" ),
	AMNI( "BIAS",					ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "Bais" ),
	AMNI( "GAMMA",					ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "Gamma" ),
	AMNI( "HORIZONTAL-TIMING",		ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "Horizontal Timing" ),
	AMNI( "VERTICAL-TIMING",		ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "Vertical Timing" ),
	AMNI( "SYNC",					ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "Synchronization" ),
	AMNI( "SYNC-POLARITY",			ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "Synchronization Polarity" ),
	AMNI( "VIDEO",					ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "Video" ),
	AMNI( "IMAGE",					ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "Image" ),
	AMNI( "DRAW",					ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "Draw" ),
	AMNI( "IMAGE-PRIMITIVE",		ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "Image Primitive" ),
	AMNI( "RECT",					ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "Rectangle" ),
	AMNI( "OVAL",					ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "Oval" ),
	AMNI( "LINE",					ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "Line" ),
	AMNI( "DOT",					ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "Dot" ),
	AMNI( "GRID",					ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "Grid" ),
	AMNI( "H-GRILL",				ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "Horizontal Grill" ),
	AMNI( "V-GRILL",				ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "Vertical Grill" ),
	AMNI( "ASCII",					ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "ASCII" ),
	AMNI( "STRING",					ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "String" ),
	AMNI( "LIMITS",					ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "Limits" ),
	AMNI( "CENTERMARK",				ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "Centermark" ),
	AMNI( "TRIANGLE",				ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "Triangle" ),
	AMNI( "DISPFMT",				ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "Display Format" ),
	AMNI( "HATCH_I-O",				ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "Hatch I-O" ),
	AMNI( "HATCH_O-I",				ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "Hatch O-I" ),
	AMNI( "CROSS",					ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "Cross" ),
	AMNI( "FILL-COLOR",				ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "Fill Color" ),
	AMNI( "WIDTH",					ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "Width" ),
	AMNI( "HEIGHT",					ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "Height" ),
	AMNI( "X1",						ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "X1" ),
	AMNI( "X2",						ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "X2" ),
	AMNI( "X3",						ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "X3" ),
	AMNI( "XBOXES",					ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "X Boxes" ),
	AMNI( "Y1",						ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "Y1" ),
	AMNI( "Y2",						ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "Y2"  ),
	AMNI( "Y3",						ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "Y3" ),
	AMNI( "YBOXES",					ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "Y Boxes" ),
	AMNI( "CHAR-CODE",				ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "Character Code" ),
	AMNI( "FONT",					ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "Font" ),
	AMNI( "FILL-PATT",				ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "Fill Pattern" ),
	AMNI( "FREQ-STEP",				ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "Frequency Step" ),
	AMNI( "FREQ-STEP-TIME",			ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "Frequency Step Time" ),
	AMNI( "FREQ-DELTA",				ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "Frequency Delta" ),
	AMNI( "POWER-STEP",				ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "Power Step" ),
	AMNI( "POWER-DELTA",			ieee1641::eUnknownBSC,					ieee1641::eUnknownBSCAttribute,							ieee1641::eCassModel, "Power Delta" )
};

const Atlas::AFI Atlas::m_arrayAtlasFunction[ ] =
{
	AFI( "AM",					ieee1641::eAM,			ieee1641::eStandardModel,	"Amplitude Modulation" ),
	AFI( "FM",					ieee1641::eFM,			ieee1641::eStandardModel,	"Frequency Modulation" ),
	AFI( "LSSB",				ieee1641::eUnknownBSC,	ieee1641::eStandardModel,	"Lower Single Side Band" ),
	AFI( "MIX",					ieee1641::eUnknownBSC,	ieee1641::eStandardModel,	"Heterodyne Conversion" ),
	AFI( "PHASE-LOCK",			ieee1641::eUnknownBSC,	ieee1641::eStandardModel,	"Constant Phase Angle" ),
	AFI( "PM",					ieee1641::ePM,			ieee1641::eStandardModel,	"Phase Modulation" ),
	AFI( "PAM",					ieee1641::eUnknownBSC,	ieee1641::eStandardModel,	"Pulse Amplitude Modulation" ),
	AFI( "PULSE",				ieee1641::eUnknownBSC,	ieee1641::eStandardModel,	"Pulse Modulation" ),
	AFI( "SUM",					ieee1641::eUnknownBSC,	ieee1641::eStandardModel,	"Summing" ),
	AFI( "SUPP-CAR",			ieee1641::eUnknownBSC,	ieee1641::eStandardModel,	"Suppressed Carrier" ),
	AFI( "SWEEP",				ieee1641::eUnknownBSC,	ieee1641::eStandardModel,	"Sweep Parameter" ),
	AFI( "USSB",				ieee1641::eUnknownBSC,	ieee1641::eStandardModel,	"Upper Single Side Band Modulation" ),
	AFI( "VECTOR",				ieee1641::eUnknownBSC,	ieee1641::eStandardModel,	"Vector Modulation" ),
	AFI( "MOD-INDEX",			ieee1641::eUnknownBSC,	ieee1641::eStandardModel,	"Modulation Ratio" ),
	AFI( "MOD-FUNCTION",		ieee1641::eUnknownBSC,	ieee1641::eStandardModel,	"Modulation Function" ),
	AFI( "LIN",					ieee1641::eUnknownBSC,	ieee1641::eStandardModel,	"Linear" ),
	AFI( "LOG",					ieee1641::eUnknownBSC,	ieee1641::eStandardModel,	"Logarithmic" ),
	AFI( "AM-SENSITIVITY",		ieee1641::eUnknownBSC,	ieee1641::eStandardModel,	"Percent of Amplitude Modulation" ),
	AFI( "FREQ-DEV",			ieee1641::eUnknownBSC,	ieee1641::eStandardModel,	"Frequency Deviation" ),
	AFI( "FM-SENSITIVITY",		ieee1641::eUnknownBSC,	ieee1641::eStandardModel,	"Frequency Modulation Deviation" ),
	AFI( "SUPPRESS-LEVEL",		ieee1641::eUnknownBSC,	ieee1641::eStandardModel,	"Reduced from the Reference" ),
	AFI( "SUMMATION",			ieee1641::eUnknownBSC,	ieee1641::eStandardModel,	"Summing Type Mixing" ),
	AFI( "DIFFERENCE",			ieee1641::eUnknownBSC,	ieee1641::eStandardModel,	"Difference Type Mixing" ),
	AFI( "PHASE-ANGLE",			ieee1641::eUnknownBSC,	ieee1641::eStandardModel,	"Phase Angle" ),
	AFI( "PHASE-JIT",			ieee1641::eUnknownBSC,	ieee1641::eStandardModel,	"Phase Jitter" ),
	AFI( "PHASE-DEV",			ieee1641::eUnknownBSC,	ieee1641::eStandardModel,	"Phase Deviation" ),
	AFI( "PULSE-SENSITIVITY",	ieee1641::eUnknownBSC,	ieee1641::eStandardModel,	"On/Off Thresholds of a Modulating Pulse Signal" ),
	AFI( "PHASE-SENSITIVITY",	ieee1641::eUnknownBSC,	ieee1641::eStandardModel,	"Percent of Phase Deviation" ),
	AFI( "VECTOR-TYPE",			ieee1641::eUnknownBSC,	ieee1641::eStandardModel,	"Vector Modulation Mode" ),
	AFI( "BPSK",				ieee1641::eUnknownBSC,	ieee1641::eStandardModel,	"Binary Phase Shift Keying" ),
	AFI( "QPSK",				ieee1641::eUnknownBSC,	ieee1641::eStandardModel,	"Quadrature Phase Shift Keying" ),
	AFI( "OQPSK",				ieee1641::eUnknownBSC,	ieee1641::eStandardModel,	"Offset Quadrature Phase Shift Keying" ),
	AFI( "8PSK",				ieee1641::eUnknownBSC,	ieee1641::eStandardModel,	"8 Phase Shift Keying" ),
	AFI( "OQAM",				ieee1641::eUnknownBSC,	ieee1641::eStandardModel,	"Offset Quadrature Amplitude Modulation" ),
	AFI( "16QAM",				ieee1641::eUnknownBSC,	ieee1641::eStandardModel,	"16 Offset Quadrature Amplitude Modulation" ),
	AFI( "64QAM",				ieee1641::eUnknownBSC,	ieee1641::eStandardModel,	"64 Offset Quadrature Amplitude Modulation" ),
	AFI( "256QAM",				ieee1641::eUnknownBSC,	ieee1641::eStandardModel,	"256 Offset Quadrature Amplitude Modulation" ),
	AFI( "CPFSK",				ieee1641::eUnknownBSC,	ieee1641::eStandardModel,	"Continuous Phase Frequency Shift Keying" ),
	AFI( "BFSK",				ieee1641::eUnknownBSC,	ieee1641::eStandardModel,	"Binary Frequency Shift Keying" ),
	AFI( "MFSK",				ieee1641::eUnknownBSC,	ieee1641::eStandardModel,	"Multiple Frequency Shift Keying" ),
	AFI( "PULSED",				ieee1641::eUnknownBSC,	ieee1641::eCassModel,		"Pulsed Modulation" ),
	AFI( "INT",					ieee1641::eUnknownBSC,	ieee1641::eCassModel,		"Internal" ),
	AFI( "EXT",					ieee1641::eUnknownBSC,	ieee1641::eCassModel,		"External" )
};

const Atlas::AUMI Atlas::m_arrayUnitsOfMeasure[ ] = 
{
	AUMI( "DEG",			"deg",		"Degree" ),
	AUMI( "RAD",			"rad",		"Radian" ),
	AUMI( "MRAD",			"mrad",		"Milliradian" ),
	AUMI( "URAD",			"urad",		"Microradian" ),
	AUMI( "REV",			"r",		"Revolution" ),
	AUMI( "SR",				"sr",		"Steradian" ),
	AUMI( "MSR",			"msr",		"Millisteradian" ),
	AUMI( "CYCLES",			"CL",		"Cycles" ),
	AUMI( "FD",				"F",		"Farad" ),
	AUMI( "UFD",			"uF",		"Microfarad" ),
	AUMI( "NFD",			"nF",		"Nanofarad" ),
	AUMI( "PFD",			"pF",		"Picofarad" ),
	AUMI( "C",				"C",		"Coulomb" ),
	AUMI( "KC",				"kC",		"Kilocoulomb" ),
	AUMI( "UC",				"uC",		"Microcoulomb" ),
	AUMI( "NC",				"nC",		"Nanocoulomb" ),
	AUMI( "S",				"S",		"Siemens" ),
	AUMI( "A",				"A",		"Ampere" ),
	AUMI( "KA",				"kA",		"Kiloampere" ),
	AUMI( "MA",				"mA",		"Milliampere" ),
	AUMI( "UA",				"uA",		"Microampere" ),
	AUMI( "NA",				"nA",		"Nanoampere" ),
	AUMI( "BITS/SECOND",	"b/s",		"Bits per Second" ),
	AUMI( "KBITS/SEC",		"kb/s",		"Kilobits per Second" ),
	AUMI( "MBITS/SEC",		"Mb/s",		"Megabits per Second" ),
	AUMI( "DIGITS",			"digits",	"Digits" ),
	AUMI( "CHAR",			"char",		"Character" ),
	AUMI( "BITS",			"bits",		"Bits" ),
	AUMI( "WORDS/SEC",		"w/s",		"Words per Second" ),
	AUMI( "KWORDS/SEC",		"kw/s",		"Kilowords per Second" ),
	AUMI( "MWORDS/SEC",		"mw/s",		"Megawords per Second" ),
	AUMI( "M",				"M",		"Meter" ),
	AUMI( "KM",				"kM",		"Kilometer" ),
	AUMI( "MM",				"mM",		"Millimeter" ),
	AUMI( "UM",				"uM",		"Micrometer" ),
	AUMI( "NM",				"nM",		"Nanometer" ),
	AUMI( "IN",				"in",		"Inch" ),
	AUMI( "FT",				"ft",		"Foot" ),
	AUMI( "S-MILE",			"mi",		"Statute Mile" ),
	AUMI( "N-MILE",			"nmi",		"Nautical Mile" ),
	AUMI( "J",				"J",		"Joule" ),
	AUMI( "KJ",				"kJ",		"Kilojoule" ),
	AUMI( "MJ",				"mJ",		"Millijoule" ),
	AUMI( "EV",				"eV",		"Electron Volt" ),
	AUMI( "KEV",			"keV",		"Kiloelectron Volt" ),
	AUMI( "MEV",			"MeV",		"Megaelectron Volt" ),
	AUMI( "TIMES",			"X",		"Counts" ),
	AUMI( "WB",				"Wb",		"Weber" ),
	AUMI( "MWB",			"mWb",		"Milliweber" ),
	AUMI( "T",				"T",		"Tesla" ),
	AUMI( "MT",				"mT",		"Millitesla" ),
	AUMI( "UT",				"uT",		"Microtesla" ),
	AUMI( "GAM",			"nT",		"Nanotesla" ),
	AUMI( "N",				"N",		"Newton" ),
	AUMI( "KN",				"kN",		"Kilonewton" ),
	AUMI( "MN",				"mN",		"Millinewton" ),
	AUMI( "UN",				"uN",		"Micronewton" ),
	AUMI( "HZ",				"Hz",		"Hertz" ),
	AUMI( "KHZ",			"kHz",		"Kilohertz" ),
	AUMI( "MHZ",			"MHz",		"Megahertz" ),
	AUMI( "GHZ",			"GHz",		"Gigahertz" ),
	AUMI( "PPS",			"p/s",		"Pulses per Second" ),
	AUMI( "KPPS",			"kp/s",		"Kilopulses per Second" ),
	AUMI( "LX",				"lx",		"Lux" ),
	AUMI( "H",				"H",		"Henry" ),
	AUMI( "MH",				"mH",		"Millihenry" ),
	AUMI( "UH",				"uH",		"Microhenry" ),
	AUMI( "NH",				"nH",		"Nanohenry" ),
	AUMI( "PH",				"pH",		"Picohenry" ),
	AUMI( "NT",				"nt",		"nit" ),
	AUMI( "LM",				"lm",		"Lumen" ),
	AUMI( "CD",				"cd",		"Candela" ),
	AUMI( "KG",				"kg",		"Kilogram" ),
	AUMI( "G",				"mg",		"Milligram" ),
	AUMI( "MG",				"ug",		"Microgram" ),
	AUMI( "UG",				"ng",		"Nanogram" ),
	AUMI( "W",				"W",		"Watt" ),
	AUMI( "KW",				"kW",		"Kilowatt" ),
	AUMI( "MW",				"mW",		"Milliwatt" ),
	AUMI( "UW",				"uW",		"Microwatt" ),
	AUMI( "PA",				"Pa",		"Pascal" ),
	AUMI( "KPA",			"kPa",		"Kilopascal" ),
	AUMI( "MPA",			"mPa",		"Millipascal" ),
	AUMI( "UPA",			"uPa",		"Micropascal" ),
	AUMI( "MB",				"mbar",		"Millibar" ),
	AUMI( "MMHG",			"mmHg",		"Millimeters of Mercury" ),
	AUMI( "INHG",			"inHg",		"Inches of Mercury" ),
	AUMI( "SEC",			"s",		"Second" ),
	AUMI( "MSEC",			"ms",		"Millisecond" ),
	AUMI( "USEC",			"us",		"Microsecond" ),
	AUMI( "NSEC",			"ns",		"Nanosecond" ),
	AUMI( "PSEC",			"ps",		"Picosecond" ),
	AUMI( "PULSES",			"P",		"Pulses" ),
	AUMI( "DB",				"dB",		"Decibel" ),
	AUMI( "PC",				"pct",		"Percent" ),
	AUMI( "OHM",			"Ohm",		"Ohm" ),
	AUMI( "KOHM",			"KOhm",		"Kilohm" ),
	AUMI( "MOHM",			"MOhm",		"Megohm" ),
	AUMI( "DEGK",			"K",		"Degree Kelvin" ),
	AUMI( "DEGC",			"degC",		"Degree Centigrade" ),
	AUMI( "DEGF",			"degF",		"Degree Farenheit" ),
	AUMI( "MIN",			"min",		"Minute" ),
	AUMI( "HR",				"h",		"Hour" ),
	AUMI( "N-M",			"Nm",		"Newton-Meter" ),
	AUMI( "M/SEC",			"m/s",		"Meters per Second" ),
	AUMI( "FT/SEC",			"ft/s",		"Feet per Second" ),
	AUMI( "KT",				"kn",		"Knot" ),
	AUMI( "MACH",			"Ma",		"Mach Number" ),
	AUMI( "RAD/SEC",		"rad/s",	"Radian per Second" ),
	AUMI( "V",				"V",		"Volt" ),
	AUMI( "KV",				"kV",		"Kilovolt" ),
	AUMI( "MV",				"mV",		"Millivolt" ),
	AUMI( "UV",				"uV",		"Microvolt" ),
	AUMI( "L",				"l",		"Liter" ),
	AUMI( "ML",				"ml",		"Milliliter" ),
	AUMI( "LINE",			"ll",		"Line" ),
	AUMI( "LINES",			"ll",		"Lines" ),
	AUMI( "BYTE",			"B",		"Byte" ),
	AUMI( "BYTES",			"B",		"Bytes" ),
	AUMI( "WORDS",			"ws",		"Words" ),
	AUMI( "DBM",			"dBm",		"Decibel-milliwatt" ),
	AUMI( "DBW",			"dBW",		"Decibel Watt" ),
	AUMI( "DBK",			"dBk",		"Decibel-kilowatt" ),
	AUMI( "PIXELS",			"px",		"Picture Element" ),
	AUMI( "FT-L",			"ft-L",		"Foot-Lambert" ),
};

const Atlas::APDI Atlas::m_arrayAtlasPinDescriptor[ ] = 
{
	APDI( "HI",		ieee1641::eTwoWire_FourWire,									ieee1641::eHi,						ieee1641::eStandardModel,		"\"Hot\" connection or return side of a two-wire circuit" ),
	APDI( "LO",		ieee1641::eTwoWire_ThreeWireComp_FourWire,						ieee1641::eLo,						ieee1641::eStandardModel,		"\"Cold\" connection or return side of a two-wire circuit" ),
	APDI( "REF HI",	ieee1641::eFourWire,											ieee1641::eHi,						ieee1641::eStandardModel,		"\"Hot\" connection or return side of a two-wire circuit" ),
	APDI( "REF LO",	ieee1641::eFourWire,											ieee1641::eLo,						ieee1641::eStandardModel,		"\"Cold\" connection or return side of a two-wire circuit" ),
	APDI( "VIA",	ieee1641::eSeries,												ieee1641::eVia,						ieee1641::eStandardModel,		"Series Type or Port Connection" ),
	APDI( "A",		ieee1641::eSinglePhase_TwoPhase_ThreePhaseDelta_ThreePhaseWye,	ieee1641::eA,						ieee1641::eStandardModel,		"Phase Connection A" ),
	APDI( "B",		ieee1641::eTwoPhase_ThreePhaseDelta_ThreePhaseWye,				ieee1641::eB,						ieee1641::eStandardModel,		"Phase Connection B" ),
	APDI( "C",		ieee1641::eThreePhaseDelta_ThreePhaseWye,						ieee1641::eC,						ieee1641::eStandardModel,		"Phase Connection C" ),
	APDI( "X",		ieee1641::eThreePhaseSynchro,									ieee1641::eX,						ieee1641::eStandardModel,		"Three-wire Synchro Stator Connection X" ),
	APDI( "Y",		ieee1641::eThreePhaseSynchro,									ieee1641::eY,						ieee1641::eStandardModel,		"Three-wire Synchro Stator Connection Y" ),
	APDI( "Z",		ieee1641::eThreePhaseSynchro,									ieee1641::eZ,						ieee1641::eStandardModel,		"Three-wire Synchro Stator Connection Z" ),
	APDI( "N",		ieee1641::eSinglePhase_TwoPhase_ThreePhaseWye,					ieee1641::eN,						ieee1641::eStandardModel,		"Neutral Connection" ),
	APDI( "TRUE",	ieee1641::eTwoWireComp_ThreeWireComp,							ieee1641::eTrue,					ieee1641::eStandardModel,		"Connection for the \"true\" signal of a differential digital signal" ),
	APDI( "TO",		ieee1641::eNonElectrical,										ieee1641::eTo,						ieee1641::eStandardModel,		"Only a single connection is required" ),
	APDI( "FROM",	ieee1641::eNonElectrical,										ieee1641::eFrom,					ieee1641::eStandardModel,		"Connection that carries flow from the UUT" ),
	APDI( "SCREEN",	ieee1641::eUnknownBSC,											ieee1641::eUnknownBSCAttribute,		ieee1641::eUnknownModel,		"Electro-static Shield Connection" ),
	APDI( "COMPL",	ieee1641::eTwoWireComp_ThreeWireComp,							ieee1641::eTrue,					ieee1641::eStandardModel,		"Complement Signal Connection" ),
	APDI( "GUARD",	ieee1641::eUnknownBSC,											ieee1641::eUnknownBSCAttribute,		ieee1641::eUnknownModel,		"Guard Terminal Connection" ),
	APDI( "R1",		ieee1641::eSynchroResolver,										ieee1641::eR1,						ieee1641::eStandardModel,		"Synchro-Resolver Rotor Connection 1" ),
	APDI( "R2",		ieee1641::eSynchroResolver,										ieee1641::eR2,						ieee1641::eStandardModel,		"Synchro-Resolver Rotor Connection 2" ),
	APDI( "R3",		ieee1641::eSynchroResolver,										ieee1641::eR3,						ieee1641::eStandardModel,		"Synchro-Resolver Rotor Connection 3" ),
	APDI( "R4",		ieee1641::eSynchroResolver,										ieee1641::eR4,						ieee1641::eStandardModel,		"Synchro-Resolver Rotor Connection 4" ),
	APDI( "S1",		ieee1641::eFourWireResolver,									ieee1641::eS1,						ieee1641::eStandardModel,		"Four-wire Resolver Stator Connection 1" ),
	APDI( "S2",		ieee1641::eFourWireResolver,									ieee1641::eS2,						ieee1641::eStandardModel,		"Four-wire Resolver Stator Connection 2" ),
	APDI( "S3",		ieee1641::eFourWireResolver,									ieee1641::eS3,						ieee1641::eStandardModel,		"Four-wire Resolver Stator Connection 3" ),
	APDI( "S4",		ieee1641::eFourWireResolver,									ieee1641::eS4,						ieee1641::eStandardModel,		"Four-wire Resolver Stator Connection 4" )
};

const Atlas::AS1S Atlas::m_arrayAtlasSignalTo1641Signal[ ] = 
{
	AS1S( eACSignal,				eVOLTAGE,		ieee1641::eSinusoid,			ieee1641::eAc_ampl ),
	AS1S( eACSignal,				eFREQ,			ieee1641::eSinusoid,			ieee1641::eFreq ),
	AS1S( eACSignal,				ePHASE_ANGLE,	ieee1641::eSinusoid,			ieee1641::ePhase ),
	AS1S( eACSignal,				eDC_OFFSET,		ieee1641::eConstant,			ieee1641::eDc_offset ),
	AS1S( eACSignal,				ePOWER,			ieee1641::eUnknownBSC,			ieee1641::ePower ),
	AS1S( eACSignal,				eSWEEP_TIME,	ieee1641::eUnknownBSC,			ieee1641::eSweep_time ),
	AS1S( eACSignal,				eMODE,			ieee1641::eUnknownBSC,			ieee1641::eMode ),
	AS1S( eACSignal,				eMOD_FREQ,		ieee1641::eUnknownBSC,			ieee1641::eMod_freq ),
	AS1S( eACSignal,				eFREQ_DEV,		ieee1641::eUnknownBSC,			ieee1641::eFreq_dev ),
	AS1S( eACSignal,				eDUTY_CYCLE,	ieee1641::eUnknownBSC,			ieee1641::eDutyCycle ),
	AS1S( eACSignal,				ePERIOD,		ieee1641::eUnknownBSC,			ieee1641::ePeriod ),
	AS1S( eACSignal,				eCURRENT,		ieee1641::eUnknownBSC,			ieee1641::eCurrent ),

	AS1S( eDCSignal,				eVOLTAGE,		ieee1641::eConstant,			ieee1641::eDc_ampl ),
	AS1S( eDCSignal,				eAC_COMP_FREQ,	ieee1641::eSinusoid,			ieee1641::eFreq ),
	AS1S( eDCSignal,				eAC_COMP,		ieee1641::eSinusoid,			ieee1641::eAc_ampl ),
	AS1S( eDCSignal,				ePOWER,			ieee1641::eUnknownBSC,			ieee1641::ePower ),
	AS1S( eDCSignal,				eCURRENT,		ieee1641::eUnknownBSC,			ieee1641::eCurrent ),

	AS1S( eImpedance,				eRES,			ieee1641::eLoad,				ieee1641::eResistance ),
	AS1S( eImpedance,				eCURRENT_LMT,	ieee1641::eUnknownBSC,			ieee1641::eCurrent_lmt ),
	AS1S( eImpedance,				eFREQ,			ieee1641::eSinusoid,			ieee1641::eFreq ),
	AS1S( eImpedance,				eREF_VOLT,		ieee1641::eUnknownBSC,			ieee1641::eRef_volt ),
	AS1S( eImpedance,				eREACTANCE,		ieee1641::eUnknownBSC,			ieee1641::eReactance ),		
	AS1S( eImpedance,				eVOLT_LMT,		ieee1641::eUnknownBSC,			ieee1641::eVolt_lmt ),
	AS1S( eImpedance,				eQ,				ieee1641::eUnknownBSC,			ieee1641::eQ_factor ),

	AS1S( ePulseModulatedSignal,	eCAR_FREQ,		ieee1641::eSinusoid,			ieee1641::eCar_freq ),
	AS1S( ePulseModulatedSignal,	eMOD_FREQ,		ieee1641::eSinusoid,			ieee1641::eMod_freq ),
	AS1S( ePulseModulatedSignal,	ePOWER,			ieee1641::eUnknownBSC,			ieee1641::ePower ),
	AS1S( ePulseModulatedSignal,	eDUTY_CYCLE,	ieee1641::eUnknownBSC,			ieee1641::eDutyCycle ),			
	AS1S( ePulseModulatedSignal,	eMODE,			ieee1641::eUnknownBSC,			ieee1641::eMode ),			
	AS1S( ePulseModulatedSignal,	eFREQ_DEV,		ieee1641::eUnknownBSC,			ieee1641::eFreq_dev ),			
	AS1S( ePulseModulatedSignal,	eBURST,			ieee1641::eUnknownBSC,			ieee1641::eBurst ),
	AS1S( ePulseModulatedSignal,	eCAR_HARMONICS,	ieee1641::eUnknownBSC,			ieee1641::eCar_harmonics ),
	AS1S( ePulseModulatedSignal,	eCAR_AMPL,		ieee1641::eFM,					ieee1641::eCar_ampl ),
	AS1S( ePulseModulatedSignal,	ePHASE_DEV,		ieee1641::eFM,					ieee1641::ePhase_dev ),
	AS1S( ePulseModulatedSignal,	eMOD_AMPL,		ieee1641::eSinusoid,			ieee1641::eMod_ampl ),

	AS1S( ePulsedDC,				eVOLTAGE,		ieee1641::eSinusoid,			ieee1641::eDc_ampl ),
	AS1S( ePulsedDC,				eFREQ,			ieee1641::eSinusoid,			ieee1641::eFreq ),
	AS1S( ePulsedDC,				ePRF,			ieee1641::eTimedEvent,			ieee1641::ePrf ),
	AS1S( ePulsedDC,				eDC_OFFSET,		ieee1641::eUnknownBSC,			ieee1641::eDc_offset ),			
	AS1S( ePulsedDC,				eFALL_TIME,		ieee1641::eUnknownBSC,			ieee1641::eFallTime ),			
	AS1S( ePulsedDC,				eDUTY_CYCLE,	ieee1641::eUnknownBSC,			ieee1641::eDutyCycle ),
	AS1S( ePulsedDC,				eSPACING,		ieee1641::eUnknownBSC,			ieee1641::eSpacing ),
	AS1S( ePulsedDC,				ePERIOD,		ieee1641::eUnknownBSC,			ieee1641::ePeriod ),
	AS1S( ePulsedDC,				eOVERSHOOT,		ieee1641::eUnknownBSC,			ieee1641::eOvershoot ),
	AS1S( ePulsedDC,				eUNDERSHOOT,	ieee1641::eUnknownBSC,			ieee1641::eUndershoot ),
	AS1S( ePulsedDC,				ePOWER,			ieee1641::eUnknownBSC,			ieee1641::ePower ),
	AS1S( ePulsedDC,				ePRESHOOT,		ieee1641::eUnknownBSC,			ieee1641::ePreshoot ),

	AS1S( ePulsedDCTrain,			eVOLTAGE,		ieee1641::eConstant,			ieee1641::eDc_ampl ),
	AS1S( ePulsedDCTrain,			eDC_OFFSET,		ieee1641::eUnknownBSC,			ieee1641::eDc_offset ),			
	AS1S( ePulsedDCTrain,			eFALL_TIME,		ieee1641::eUnknownBSC,			ieee1641::eFallTime ),			
	AS1S( ePulsedDCTrain,			eSPACING,		ieee1641::eUnknownBSC,			ieee1641::eSpacing ),
	AS1S( ePulsedDCTrain,			ePRF,			ieee1641::eUnknownBSC,			ieee1641::ePrf ),
	AS1S( ePulsedDCTrain,			eOVERSHOOT,		ieee1641::eUnknownBSC,			ieee1641::eOvershoot ),
	AS1S( ePulsedDCTrain,			eUNDERSHOOT,	ieee1641::eUnknownBSC,			ieee1641::eUndershoot ),
	AS1S( ePulsedDCTrain,			ePERIOD,		ieee1641::eUnknownBSC,			ieee1641::ePeriod ),				
	
	AS1S( eResolver,				eANGLE,			ieee1641::eSinusoid,			ieee1641::eAngle ),
	AS1S( eResolver,				eVOLTAGE,		ieee1641::eSinusoid,			ieee1641::eAmpl ),
	AS1S( eResolver,				eFREQ,			ieee1641::eSinusoid,			ieee1641::eFreq ),
	AS1S( eResolver,				eZERO_INDEX,	ieee1641::eSinusoid,			ieee1641::eZero_index ),
	AS1S( eResolver,				eANGLE_RATE,	ieee1641::eSinusoid,			ieee1641::eAngle_rate ),
	AS1S( eResolver,				eBANDWIDTH,		ieee1641::eUnknownBSC,			ieee1641::eBandwidth ),

	AS1S( eSquareWave,				eVOLTAGE,		ieee1641::eSquareWave,			ieee1641::eAmpl ),
	AS1S( eSquareWave,				ePERIOD,		ieee1641::eSquareWave,			ieee1641::ePeriod ),
	AS1S( eSquareWave,				eDC_OFFSET,		ieee1641::eConstant,			ieee1641::eDc_offset ),
	AS1S( eSquareWave,				eFREQ,			ieee1641::eUnknownBSC,			ieee1641::eFreq ),			
	AS1S( eSquareWave,				eFALL_TIME,		ieee1641::eUnknownBSC,			ieee1641::eFallTime ),			
	AS1S( eSquareWave,				eDUTY_CYCLE,	ieee1641::eUnknownBSC,			ieee1641::eDutyCycle ),
	AS1S( eSquareWave,				eCURRENT,		ieee1641::eUnknownBSC,			ieee1641::eCurrent ),
	AS1S( eSquareWave,				eOVERSHOOT,		ieee1641::eUnknownBSC,			ieee1641::eOvershoot ),
	AS1S( eSquareWave,				eUNDERSHOOT,	ieee1641::eUnknownBSC,			ieee1641::eUndershoot ),

	AS1S( eSynchro,					eANGLE,			ieee1641::eSinusoid,			ieee1641::eAngle ),
	AS1S( eSynchro,					eVOLTAGE,		ieee1641::eSinusoid,			ieee1641::eAmpl ),
	AS1S( eSynchro,					eFREQ,			ieee1641::eSinusoid,			ieee1641::eFreq ),
	AS1S( eSynchro,					eZERO_INDEX,	ieee1641::eSinusoid,			ieee1641::eZero_index ),
	AS1S( eSynchro,					eANGLE_RATE,	ieee1641::eSinusoid,			ieee1641::eAngle_rate )
};		  
const unsigned int Atlas::m_uiAtlasSignalCount = ( sizeof( Atlas::m_arrayAtlasSignalTo1641Signal ) / sizeof( AS1S ) );

// *** KEEP THIS LAST FOR ALL STATIC INITIALIZERS ****
const bool Atlas::m_bInitAll = Atlas::InitAll( );
