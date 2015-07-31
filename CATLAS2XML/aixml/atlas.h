/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

#pragma once

#include <limits>
#include <string>
#include <map>
#include <set>
#include <vector>

#include "helper.h"
#include "exception.h"
#include "xml.h"
#include "ieee1641.h"

using namespace std;

class Atlas
{
public:

	enum eAtlasStatement
	{
		eUnknownAtlasStatement = -1,

		// Begin signal oriented
		eINITIATE,
		eSETUP,
		eCONNECT,
		eDISCONNECT,
		eIDENTIFY,
		eFETCH,
		eARM,			// 1995 Atlas
		eCHANGE,		// 1995 Atlas
		eAPPLY,
		eREMOVE,
		eMEASURE,
		eDEFINE,
		eREQUIRE,
		eMONITOR,
		eVERIFY,
		eREAD,
		eRESET,
		eEXTEND,
		eOPEN,			// 1985 Atlas Only
		eCLOSE,			// 1985 Atlas Only
		// End signal oriented

		// BEGIN: Don't change position/reorder below
		eIF_THEN,
		eELSE,
		eWHILE_THEN,
		eFOR_THEN,
		// END: Don't change position/reorder above

		eEND_IF,
		eEND_WHILE,
		eEND_FOR,
		eEND_DEFINE,
		eGO_TO,
		eLEAVE_PROCEDURE,
		eLEAVE_IF,
		eLEAVE_FOR,
		eLEAVE_WHILE,
		eTERMINATE_ATLAS_PROGRAM,
		ePERFORM,
		eDEFINE_PROCEDURE,
		eREAD_DATETIME,	// CASS, special case for the "READ" verb (simulated, doesn't actually exist)
		eDECLARE,
		eCALCULATE,
		eCOMPARE,		// CASS Only (not in 1985 Atlas standard, but is in the 1995 standard with the same syntax as CASS)
		eFILL,
		eDELAY,
		eWAIT_FOR,		// Contains CASS extension (MANUAL INTERVENTION) and Atlas 1985 and Atlas 1995 (differences between 1985 and 1995)
		eENABLE,		// CASS extension and 1995 Atlas standard (CASS and Atlas 1995 are different)
		eDISABLE,		// Atlas 1985 and Atlas 1995 (CASS and Atlas 1995 are identical)
		ePREPARE,		// CASS Only (in conjunction with eEXECUTE)
		eEXECUTE,		// CASS Only (in conjunction with ePREPARE)
		eFINISH,
		eDEFINE_COMPLEX_SIGNAL,	// CASS extension and 1995 Atlas standard
		eSPECIFY,		// CASS extension and 1995 Atlas standard (used in conjunction with eDEFINE_COMPLEX_SIGNAL)
		eCOMMENT,		// Not really an Atlas statement type
		// ------- UNHANDLED ------- // 
		eLEAVE_ATLAS,	// CASS extension
		eRESUME_ATLAS,	// CASS extension
		eDO_EXCHANGE,	// CASS extension and Atlas 1995
		eINPUT,			// CASS extension and Atlas 1985 and Atlas 1995
		eOUTPUT			// CASS extension and Atlas 1985 and Atlas 1995

		// NOTE: The ending enum is used in FOR loops, make sure to update loops
	};

	enum eAtlasResource
	{
		eUnknownAtlasResource = -1,
		eInputResource,
		eOutputResource,
		eIOResource,
		eSourceResource,
		eSensorResource,
		eTimerResource,
		eDigitalTimerResource,
		eLoadResource,
		eEventMonitorResource,
		eSTIMResource,
		eRESPResource,
		eSTIM_RESPResource,
		eSTIM_RESP_COMPResource		// CASS ONLY

		// NOTE: The ending enum is used in FOR loops, make sure to update loops
	};

	enum eAtlasRequire
	{
		eUnknownAtlasRequire = -1,
		eAtlasRequireControl,
		eAtlasRequireCapability,
		eAtlasRequireLimit,
		eAtlasRequireCNX

		// NOTE: The ending enum is used in FOR loops, make sure to update loops
	};

	enum eAtlasNoun
	{
		eUnknownAtlasNoun = -1,
		eACSignal,
		eADF,
		eAMSignal,
		eAmbient,
		eATC,
		eCommon,
		eComplexSignal,
		eDCSignal,
		eDisplacement,
		eDME,
		eDoppler,
		eEarth,
		eEMField,
		eEvents,
		eFluidSignal,
		eFMSignal,
		eHeat,
		eIFF,
		eILS,
		eImpedance,
		eLight,
		eLogicControl,
		eLogicData,
		eLogicLoad,
		eLogicReference,
		eManometric,
		ePAM,
		ePMSignal,
		ePulsedAC,
		ePulsedACTain,
		ePulsedDC,
		ePulsedDCTrain,
		ePulsedDoppler,
		eRadarSignal,
		eRampSignal,
		eRandomNoise,
		eResolver,
		eRotation,
		eShort,
		eSquareWave,
		eStepSignal,
		eSupCarSignal,
		eSynchro,
		eTACAN,
		eTimeInterval,
		eTriangularWaveSignal,
		eTurbineEngineData,
		eVibration,
		eVOR,
		eWaveform,

		// Additional Nouns not defined as "Noun" in the 716 
		// or
		// CASS specific

		eDigitalPattern,		// CASS ONLY
		ePassThruGating,		// CASS ONLY
		eVideoSignal,			// CASS ONLY
		eBuiltInTest,			// CASS ONLY
		ePulseModulatedSignal,	// CASS ONLY
		eAnalogAdd,				// CASS ONLY

		// NOTE: The ending enum is used in FOR loops, make sure to update loops
	};

	enum eAtlasNounModifier
	{
		eUnknownAtlasNounModifier = -1,
		eAC_COMP,
		eAC_COMP_FREQ,
		eAGE_RATE,
		eALT,
		eALT_RATE,
		eAM_COMP,
		eAM_SHIFT,
		eAMPL_MOD,
		eANGLE,
		eANGLE_ACCEL,
		eANGLE_RATE,
		eANT_SPEED_DEV,
		eATMOS,
		eATTEN,			// also a signal conditioning statement
		eBANDWIDTH,
		eBAROMETRIC_PRESS,
		eBIT_RATE,
		eBURST,
		eBURST_DROOP,
		eBURST_REP_RATE,
		eCAP,
		eCAR_AMPL,
		eCAR_FREQ,
		eCAR_HARMONICS,
		eCAR_PHASE,
		eCAR_RESID,
		eCHANNELxxx,
		eAtlasNounModifierCOMPL,
		eCONDUCTANCE,
		eCOUNT,
		eCREST_FACTOR,
		eCURRENT,
		eCURRENT_LMT,
		eCW_LEVEL,
		eDBL_INT,
		eDC_OFFSET,
		eDDM,
		eDEBRIS_COUNT,
		eDEBRIS_SIZE,
		eDEWPOINT,
		eDISS_FACTOR,
		eDISTANCE,
		eDISTORTION,
		eDOMINANT_MOD_SIG,
		eDOPPLER_BANDWIDTH,
		eDOPPLER_FREQ,
		eDOPPLER_SHIFT,
		eDROOP,
		eDUTY_CYCLE,
		eEFF,
		eEFFICACY,
		eFALL_TIME,
		eFIELD_STRENGTH,
		eFLUID_TYPE,
		eFLUX_DENS,
		eFM_COMP,
		eFORCE,
		eFORCE_RATE,
		eFREQ,
		eFREQ_DEV,
		eFREQ_ONE,
		eFREQ_QUIES,
		eFREQ_ZERO,
		eFREQ_PAIRING,
		eFREQ_WINDOW,
		eFUEL_SUPPLY,
		eGLIDE_SLOPE,
		eHARMONICS,
		eHARM_xxx_PHASE,
		eHARM_xxx_POWER,
		eHARM_xxx_VOLTAGE,
		eHI_MOD_FREQ,
		eHUMIDITY,
		eIAS,
		eIDENT_SIG,
		eIDENT_SIG_EP,
		eIDENT_SIG_FREQ,
		eIDENT_SIG_MOD,
		eILLUM,
		eIND,
		eINT,
		eLO_MOD_FREQ,
		eLOCALIZER,
		eLUMINANCE,
		eLUM_FLUX,
		eLUM_INT,
		eLUM_TEMP,
		eMAG_BEARING,
		eMARKER_BEACON,
		eMASS_FLOW,
		eMEAN_MOD,
		eMOD_AMPL,
		eMOD_DIST,
		eMOD_FREQ,
		eMOD_OFFSET,
		eMOD_PHASE,
		eMODE,
		eNEG_SLOPE,
		eNOISE,
		eNOISE_AMPL_DENS,
		eNOISE_PWR_DENS,
		eNON_HARMONICS,
		eNON_LIN,
		eOPER_TEMP,
		eOVERSHOOT,
		eP_AMPL,
		eP3_DEV,
		eP3_LEVEL,
		ePAIR_DROOP,
		ePAIR_SPACING,
		ePEAK_DEGEN,
		ePERIOD,
		ePHASE_ANGLE,
		ePHASE_DEV,
		ePHASE_JIT,
		ePHASE_SHIFT,
		ePLA,
		ePLA_RATE,
		ePOS_SLOPE,
		ePOWER,
		ePOWER_DIFF,
		ePRESHOOT,
		ePRESS_A,
		eSTATIC_PRESS_A,
		eTOTAL_PRESS_A,
		ePRESS_G,
		eSTATIC_PRESS_G,
		eTOTAL_PRESS_G,
		ePRESS_RATE,
		eSTATIC_PRESS_RATE,
		eTOTAL_PRESS_RATE,
		ePRESS_OSC_AMPL,
		ePRESS_OSC_FREQ,
		ePRF,
		ePULSE_CLASS,
		ePULSE_IDENT,
		ePULSE_POSN,
		ePULSE_SPECT,
		ePULSE_SPECT_THRESHOLD,
		ePULSE_WIDTH,
		ePULSES_EXCL,
		ePULSES_INCL,
		ePWR_LMT,
		eQ,
		eQUAD,
		eRADIAL,
		eRADIAL_RATE,
		eRANGE_PULSE_DEV,
		eRANGE_PULSE_ECHO,
		eREACTANCE,
		eREF_FREQ,
		eREF_INERTIAL,
		eREF_PHASE_FREQ,
		eREF_POWER,
		eREF_PULSES,
		eREF_PULSES_EXCL,
		eREF_PULSES_INCL,
		eREF_PULSES_DEV,
		eREF_UUT,
		eREF_VOLT,
		eREL_BEARING,
		eREL_BEARING_RATE,
		eRELATIVE_HUMIDITY,
		eRELATIVE_WIND,
		eREPLY_EFF,
		eRES,
		eRESP,
		eRINGING,
		eRISE_TIME,
		eROTOR_SPEED,
		eROUNDING,
		eSAMPLE,
		eSAMPLE_SPACING,
		eSAMPLE_TIME,
		eSAMPLE_WIDTH,
		eSETTLE_TIME,
		eSHAFT_SPEED,
		eSKEW_TIME,
		eSLANT_RANGE,
		eSLANT_RANGE_ACCEL,
		eSLANT_RANGE_RATE,
		eSLEW_RATE,
		eSLS_DEV,
		eSLS_LEVEL,
		eSPACING,
		eSPEC_GRAV,
		eSPEC_TEMP,
		eSQTR_DIST,
		eSQTR_RATE,
		eSTIM,
		eSUB_CAR_FREQ,
		eSUB_CAR_MOD,
		eSUSCEPTANCE,
		eSWEEP_TIME,
		eSWR,
		eTARGET_RANGE,
		eTARGET_RANGE_ACCEL,
		eTARGET_RANGE_RATE,
		eTAS,
		eTEMP,
		eSTATIC_TEMP,
		eTOTAL_TEMP,
		eTEMP_COEF_CAP,
		eTEMP_COEF_CURRENT,
		eTEMP_COEF_IND,
		eTEMP_COEF_REACT,
		eTEMP_COEF_RES,
		eTEMP_COEF_VOLT,
		eTHREE_PHASE_DELTA,
		eTHREE_PHASE_WYE,
		eTHRUST,
		eTIME,
		eTIME_ASYM,
		eTIME_JIT,
		eTORQUE,
		eTRANS_ONE,
		eTRANS_PERIOD,
		eTRANS_ZERO,
		eTRIG,
		eAtlasNounModifierTRUE,
		eTYPE,
		eUNDERSHOOT,
		eVALUE,
		eVAR_PHASE_FREQ,
		eVAR_PHASE_MOD,
		eVIBRATION_ACCEL,
		eVIBRATION_AMPL,
		eVIBRATION_RATE,
		eVOLTAGE,
		eVOLTAGE_ONE,
		eVOLTAGE_ZERO,
		eVOLTAGE_QUIES,
		eVOLTAGE_RAMPED,
		eVOLTAGE_STEPPED,
		eVOLT_LMT,
		eVOLUME_FLOW,
		eWAVE_LENGTH,
		eWIND_SPEED,
		eWORD_LENGTH,
		eWORD_RATE,
		eZERO_INDEX,
		eGATED,

		// Begin: used for signal conditioning
		eBAND_PASS_FILTER,
		eDIVIDE,
		eDE_EMPHASIS,
		eGAIN,
		eHI_PASS_FILTER,
		eISOLATION,
		eLO_PASS_FILTER,
		eNOTCH_FILTER,
		ePRE_EMPHASIS,
		eROLLOFF,
		eROLLOFF_LOWER,
		eROLLOFF_UPPER,
		ePOWER_MARK,
		ePOWER_MARK_UPPER,
		ePOWER_MARK_LOWER,
		eFREQ_MARK,
		eFREQ_MARK_UPPER,
		eFREQ_MARK_LOWER,
		eFREQ_MARK_HARM,
		eFORWARD,
		eFORWARD_HOLD,
		eFORWARD_HOLD_RESET_HOLD,
		eFORWARD_HOLD_REVERSE_HOLD,
		eFORWARD_REVERSE,
		eREVERSE,
		eFSK,
		eSEQUENCE,
		eSEQUENCE_HOLD,
		eSEQUENCE_HOLD_RESET_HOLD,
		eSEQUENCE_STEP,
		// End: used for signal conditioning

		// Additional attributes not defined as "Noun Modifiers" in the 716 
		// or
		// CASS specific

		eMAX_TIME,
		eDELAY_,
		eCOUPLING,				// CASS Only
		eCOUPLING_REF,			// CASS Only
		eTEST_EQUIP_IMP,		// CASS Only
		eTRIG_OUT_DRIVE,		// CASS Only
		eSTART_PC,				// CASS Only
		eSTOP_PC,				// CASS Only
		eREF_VOLTAGE_P,			// CASS Only
		eSAMPLE_AV,				// CASS Only
		ePATTERN_SIZE,			// CASS Only
		ePATTERN_RATE,			// CASS Only
		PATTERN_HOLD_COUNT,		// CASS Only
		eSOURCE_IDENTIFIER,		// CASS Only
		eCIRCULATE,				// CASS Only
		eREF_SOURCE,			// CASS Only
		eSPEED_RATIO,			// CASS Only
		eVFMT,					// CASS Only
		eDOT_CLOCK,				// CASS Only
		eSWEEP_DELAY,			// CASS Only
		eHALF_CYCLE_DELAY,		// CASS Only
		eDWELL_TIME,			// CASS Only
		eBURST_DELAY,			// CASS Only
		eSWEEP_TYPE,			// CASS Only
		eSTEP_TIME,				// CASS Only
		eRATE,					// CASS Only
		eACTIVE,				// CASS Only
		eBLANK,					// CASS Only
		eTOTAL,					// CASS Only
		eSIZE,					// CASS Only
		eFRONT_PORCH,			// CASS Only
		eNON_INTERLACE,			// CASS Only
		eINTERLACE,				// CASS Only
		eANALOG_COMP,			// CASS Only
		eDIGITAL_COMP,			// CASS Only
		eDIGITAL_SEPARATE,		// CASS Only
		eON_VIDEO,				// CASS Only
		eEQ_BEFORE,				// CASS Only
		eEQ_AFTER,				// CASS Only
		eSERRATION,				// CASS Only
		eSWING,					// CASS Only
		eHORIZONTAL,			// CASS Only
		eVERTICAL,				// CASS Only
		eCOMPOSITE,				// CASS Only
		eCOLOR,					// CASS Only
		eMONO,					// CASS Only
		ePEDESTAL,				// CASS Only
		eBIAS,					// CASS Only
		eGAMMA,					// CASS Only
		eHORIZONTAL_TIMING,		// CASS Only
		eVERTICAL_TIMING,		// CASS Only
		eSYNC,					// CASS Only
		eSYNC_POLARITY,			// CASS Only
		eVIDEO,					// CASS Only
		eIMAGE,					// CASS Only
		eDRAW,					// CASS Only
		eIMAGE_PRIMITIVE,		// CASS Only
		eRECT,					// CASS Only
		eOVAL,					// CASS Only
		eLINE,					// CASS Only
		eDOT,					// CASS Only
		eGRID,					// CASS Only
		eH_GRILL,				// CASS Only
		eV_GRILL,				// CASS Only
		eASCII,					// CASS Only
		eSTRING,				// CASS Only
		eLIMITS,				// CASS Only
		eCENTERMARK,			// CASS Only
		eTRIANGLE,				// CASS Only
		eDISPFMT,				// CASS Only
		eHATCH_I_O,				// CASS Only
		eHATCH_O_I,				// CASS Only
		eCROSS,					// CASS Only
		eFILL_COLOR,			// CASS Only
		eWIDTH,					// CASS Only
		eHEIGHT,				// CASS Only
		eX1,					// CASS Only
		eX2,					// CASS Only
		eX3,					// CASS Only
		eXBOXES,				// CASS Only
		eY1,					// CASS Only
		eY2,					// CASS Only
		eY3,					// CASS Only
		eYBOXES,				// CASS Only
		eCHAR_CODE,				// CASS Only
		eFONT,					// CASS Only
		eFILL_PATT,				// CASS Only
		eFREQ_STEP,				// CASS Only
		eFREQ_STEP_TIME,		// CASS Only
		eFREQ_DELTA,			// CASS Only
		ePOWER_STEP,			// CASS Only
		ePOWER_DELTA,			// CASS Only

		// NOTE: The ending enum is used in FOR loops, make sure to update loops
	};

	enum eAtlasModifierSuffix
	{
		eUnknownAtlasSuffix = -1,
		ePSuffix,					
		ePPSuffix,
		eTRMSSuffix,
		eAVSuffix,
		ePOSSuffix,
		eNEGSuffix,
		eIN_PHASESuffix,
		eQUADSuffix,
		eINSTSuffix,
		ePHASESuffix,
		eASuffix,
		eBSuffix,
		eCSuffix,
		eABSuffix,
		eACSuffix,
		eBASuffix,
		eBCSuffix,
		eCASuffix,
		eCBSuffix,
		// BEGIN: Keep the following in order
		ePHASEASuffix,
		ePHASEBSuffix,
		ePHASECSuffix,
		ePHASEABSuffix,
		ePHASEACSuffix,
		ePHASEBASuffix,
		ePHASEBCSuffix,
		ePHASECASuffix,
		ePHASECBSuffix,
		// END
		eXSuffix,
		eYSuffix,
		eZSuffix,
		eRSuffix,
		eTHETASuffix,
		ePHISuffix,
		ePxxxSuffix,
		eQUIESSuffix,
		eONESuffix,
		eZEROSuffix,
		eJITTERSuffix,
		eRATESuffix,
		eREFSuffix

		// NOTE: The ending enum is used in FOR loops, make sure to update loops
	};

	enum eAtlasFunction
	{
		eUnknownAtlasFunction = -1,
		eAMFunction,
		eFMFunction,
		eLSSB,
		eMIX,
		ePHASE_LOCK,
		ePMFunction,
		ePAMFunction,
		ePULSE,
		eSUM,
		eSUPP_CAR,
		eSWEEP,
		eUSSB,
		eVECTOR,
		eMOD_INDEX,
		eMOD_FUNCTION,
		eLIN,
		eLOG,
		eAM_SENSITIVITY,
		eFREQ_DEVFunction,
		eFM_SENSITIVITY,
		eSUPPRESS_LEVEL,
		eSUMMATION,
		eDIFFERENCE,
		ePHASE_ANGLEFunction,
		ePHASE_JITFunction,
		ePHASE_DEVFunction,
		ePULSE_SENSITIVITY,
		ePHASE_SENSITIVITY,
		eVECTOR_TYPE,
		eBPSK,
		eQPSK,
		eOQPSK,
		e8PSK,
		eOQAM,
		e16QAM,
		e64QAM,
		e256QAM,
		eCPFSK,
		eBFSK,
		eMFSK,
		ePULSED,		// CASS ONLY (not sure?)
		eINTFunction,	// CASS ONLY
		eEXT			// CASS ONLY

		// NOTE: The ending enum is used in FOR loops, make sure to update loops
	};

	enum eAtlasSpecifyType
	{
		eUnknownAtlasSpecifyType = -1,
		eREFERENCE_SIGNAL,
		eMOD_SIGNAL,
		eMOD_SIGNAL_D,
		eMOD_SIGNAL_I,
		eMOD_SIGNAL_Q,
		eSWEEP_CONTROL,
		eREFERENCE_LEVEL,
		eOSCILLATOR,
		eCOMPONENT,
		eCARRIER

		// NOTE: The ending enum is used in FOR loops, make sure to update loops
	};

	enum eAtlasPinDescriptor
	{
		eUnknownAtlasPinDescriptor = -1,
		eHI,
		eLO,
		eHIRef,	// Doesn't directly exist in Atlas, used only for translating to 1641
		eLORef,	// Doesn't directly exist in Atlas, used only for translating to 1641
		eVIA,
		eA,
		eB,
		eC,
		eX,
		eY,
		eZ,
		eN,
		eAtlasPinDescriptorTRUE,
		eTO,
		eFROM,
		eSCREEN,
		eAtlasPinDescriptorCOMPL,
		eGUARD,
		eR1,
		eR2,
		eR3,
		eR4,
		eS1,
		eS2,
		eS3,
		eS4

		// NOTE: The ending enum is used in FOR loops, make sure to update loops
	};

	enum eUnitOfMeasure
	{
		eUnknownUnitOfMeasure = -1,
		eDegree,
		eRadian,
		eMilliradian,
		eMicroradian,
		eRevolution,
		eSteradian,
		eMillisteradian,
		eCycles,
		eFarad,
		eMicrofarad,
		eNanofarad,
		ePicofarad,
		eCoulomb,
		eKilocoulomb,
		eMicrocoulomb,
		eNanocoulomb,
		eSiemens,
		eAmpere,
		eKiloampere,
		eMilliampere,
		eMicroampere,
		eNanoampere,
		eBitsPerSecond,
		eKilobitsPerSecond,
		eMegabitsPerSecond,
		eDigit,
		eCharacter,
		eBits,
		eWordsPerSecond,
		eKilowordsPerSecond,
		eMegawordsPerSecond,
		eMeter,
		eKilometer,
		eMillimeter,
		eMicrometer,
		eNanometer,
		eInch,
		eFoot,
		eStatuteMile,
		eNauticalMile,
		eJoule,
		eKilojoule,
		eMillijoule,
		eElectronVolt,
		eKiloelectronVolt,
		eMegaelectronVolt,
		eCounts,
		eWeber,
		eMilliweber,
		eTesla,
		eMillitesla,
		eMicrotesla,
		eNanotesla,
		eNewton,
		eKilonewton,
		eMillinewton,
		eMicronewton,
		eHertz,
		eKilohertz,
		eMegahertz,
		eGigahertz,
		ePulsesPerSecond,
		eKilopulsesPerSecond,
		eLux,
		eHenry,
		eMillihenry,
		eMicrohenry,
		eNanohenry,
		ePicohenry,
		enit,
		eLumen,
		eCandela,
		eKilogram,
		eMilligram,
		eMicrogram,
		eNanogram,
		eWatt,
		eKilowatt,
		eMilliwatt,
		eMicrowatt,
		ePascal,
		eKilopascal,
		eMillipascal,
		eMicropascal,
		eMillibar,
		eMillimetersOfMercury,
		eInchesOfMercury,
		eSecond,
		eMillisecond,
		eMicrosecond,
		eNanosecond,
		ePicosecond,
		ePulse,
		eDecibel,
		ePercent,
		eOhm,
		eKilo,
		eMegohm,
		eDegreeKelvin,
		eDegreeCentigrade,
		eDegreeFarenheit,
		eMinute,
		eHour,
		eNewtonMeter,
		eMetersPerSecond,
		eFeetPerSecond,
		eKnot,
		eMachNumber,
		eRadianPerSecond,
		eVolt,
		eKilovolt,
		eMillivolt,
		eMicrovolt,
		eLiter,
		eMilliliter,
		eLine,
		eLines,
		eByte,
		eBytes,
		eWords,
		eDecibelMilliwatts,
		eDecibelWatt,
		eDecibelKilowatt,
		ePixels,
		eFootLambert

		// NOTE: The ending enum is used in FOR loops, make sure to update loops
	};

	enum eInputOutput
	{
		eUnknownInputOutput = -1,
		eDevice,
		eFile,
		eInput,
		eOutput,
		eInputAndOutput

		// NOTE: The ending enum is used in FOR loops, make sure to update loops
	};

	enum eInputOutputAttribute
	{
		eUnknownInputOutputAttribute = -1,
		eLINE_LENGTH,
		ePAGE_SIZE,
		eHARD_COPY,
		eFILE_ORGANIZATION,	// CASS Only
		eFILE_FORM,			// CASS Only
		eRECORD_TYPE,		// CASS Only
		eRECORD_LENGTH,		// CASS Only
		eSEQUENTIAL,		// CASS Only
		eFORMATTED,			// CASS Only
		eVARIABLE,			// CASS Only
		eRELATIVE,			// CASS Only
		eUNFORMATTED,		// CASS Only
		eFIXED,				// CASS Only
		eDIRECT				// CASS Only

		// NOTE: The ending enum is used in FOR loops, make sure to update loops
	};

	enum eDataType
	{
		eUnknownDataType = -1,
		eENUMERATION,
		eDECIMAL,
		eINTEGER,
		eLONG_DECIMAL,
		eLONG_INTEGER,	// CASS Only
		eCHAR,
		eBIT,
		eBITS,
		eCONNECTION,
		eCONN,
		eBOOLEAN,
		eMSGCHAR,
		eDIGITAL,
		eDIGITAL_BNR,
		eDIGITAL_B1C,
		eDIGITAL_B2C,
		eDIGITAL_BSM,
		eDIGITAL_BCD,
		eDIGITAL_SBCD

		// NOTE: The ending enum is used in FOR loops, make sure to update loops
	};

	enum eEvaluationFieldType
	{
		eUnknownDataeEvaluationFieldType = -1,
		eNOM,	// Nominal
		eUL,	// Upper Limit
		eLL,	// Lower Limit
		eGT,	// Greater Than
		eLT,	// Less Than
		eEQ,	// Equal
		eNE,	// Not Equal
		eLE,	// Less Than Equal
		eGE		// Greater Than Equal

		// NOTE: The ending enum is used in FOR loops, make sure to update loops
	};

	class AtlasDeclare
	{
	public:
		enum eAttributes
		{
			eGlobal		= 0x001,
			eExternal	= 0x002,
			eLocal		= 0x004,
			eStore		= 0x008,
			eList		= 0x010,
			eConstant	= 0x020,
			eVariable	= 0x040,
			eParameter	= 0x080,
			eResult		= 0x100,
			eProcedure	= 0x200,
			eBuiltIn	= 0x400
		};

		AtlasDeclare( ) { Init( ); }
		AtlasDeclare( const AtlasDeclare& other ) { operator = ( other ); }
		AtlasDeclare& operator = ( const AtlasDeclare& other );

		void Clear( void ) { Init( ); }
		bool IsValid( void ) const;

		void SetGlobal( const bool bSet ) { if ( bSet ) { m_uiAttributes |= eGlobal; } else { m_uiAttributes &= ~eGlobal; } }
		void SetExternal( const bool bSet ) { if ( bSet ) { m_uiAttributes |= eExternal; } else { m_uiAttributes &= ~eExternal; } }
		void SetLocal( const bool bSet ) { if ( bSet ) { m_uiAttributes |= eLocal; } else { m_uiAttributes &= ~eLocal; } }
		void SetStore( const bool bSet ) { if ( bSet ) { m_uiAttributes |= eStore; } else { m_uiAttributes &= ~eStore; } }
		void SetList( const bool bSet ) { if ( bSet ) { m_uiAttributes |= eList; } else { m_uiAttributes &= ~eList; } }
		void SetConstant( const bool bSet ) { if ( bSet ) { m_uiAttributes |= eConstant; } else { m_uiAttributes &= ~eConstant; } }
		void SetVariable( const bool bSet ) { if ( bSet ) { m_uiAttributes |= eVariable; } else { m_uiAttributes &= ~eVariable; } }
		void SetParameter( const bool bSet ) { if ( bSet ) { m_uiAttributes |= eParameter; } else { m_uiAttributes &= ~eParameter; } }
		void SetResult( const bool bSet ) { if ( bSet ) { m_uiAttributes |= eResult; } else { m_uiAttributes &= ~eResult; } }
		void SetProcedure( const bool bSet ) { if ( bSet ) { m_uiAttributes |= eProcedure; } else { m_uiAttributes &= ~eProcedure; } }
		void SetBuiltIn( const bool bSet ) { if ( bSet ) { m_uiAttributes |= eBuiltIn; } else { m_uiAttributes &= ~eBuiltIn; } }

		bool IsGlobal( void ) const { return ( eGlobal == ( m_uiAttributes & eGlobal ) ); }
		bool IsExternal( void ) const { return ( eExternal == ( m_uiAttributes & eExternal ) ); }
		bool IsLocal( void ) const { return ( eLocal == ( m_uiAttributes & eLocal ) ); }
		bool IsStore( void ) const { return ( eStore == ( m_uiAttributes & eStore ) ); }
		bool IsList( void ) const { return ( eList == ( m_uiAttributes & eList ) ); }
		bool IsConstant( void ) const { return ( eConstant == ( m_uiAttributes & eConstant ) ); }
		bool IsVariable( void ) const { return ( eVariable == ( m_uiAttributes & eVariable ) ); }
		bool IsParameter( void ) const { return ( eParameter == ( m_uiAttributes & eParameter ) ); }
		bool IsResult( void ) const { return ( eResult == ( m_uiAttributes & eResult ) ); }
		bool IsProcedure( void ) const { return ( eProcedure == ( m_uiAttributes & eProcedure ) ); }
		bool IsBuiltIn( void ) const { return ( eBuiltIn == ( m_uiAttributes & eBuiltIn ) ); }

		string ToXML( const unsigned int uiId, const unsigned int uiCommentId ) const;

		static XML::AttributeValue GetDataTypeAttributeValue( const eDataType eType );

		bool IsAtlasNumericDataType( void ) const;

		eDataType m_eDataType;
		eDataType m_eSubDataType;
		eDataType m_eDigialType;
		unsigned int m_uiAttributes;
		unsigned int m_uiDataLength;
		unsigned int m_uiListSize;
		string m_strVarName;

	protected:

		void Init( void )
		{
			m_eSubDataType = eUnknownDataType;
			m_eDataType = eUnknownDataType;
			m_eDigialType = eUnknownDataType;
			m_uiAttributes = 0;
			m_uiDataLength = 0;
			m_uiListSize = 0;
		}

	};  // AtlasDeclare

	class AtlasSourceStatement
	{
	public:

		enum eToXML
		{
			eXmlAll					= 0x001,
			eXmlFilename			= 0x002,
			eXmlProcname			= 0x004,
			eXmlStatementNumber		= 0x008,
			eXmlLineNumber			= 0x010,
			eXmlId					= 0x020,
			eXmlAtlasStatement		= 0x040,
			eXmlSourceType			= 0x080,
			eXmlCommentId			= 0x100
		};

		enum eSourceType
		{
			eUnknownSourceType = -1,
			eAtlasProgram,
			eAtlasModule,
			eAtlasNonModule,
			eAtlasSegment,
			eCassProgramLookup,
			eCassModuleLookup
		};

		AtlasSourceStatement( ) { Init( ); }
		AtlasSourceStatement( const unsigned int uiId ) { Init( ); m_uiId = uiId; }
		AtlasSourceStatement( const eSourceType eType, const eAtlasStatement eStatement, const string& strFilename, const string& strStatementNumber, const unsigned int uiLineNumber, const unsigned int uiId, const unsigned int uiCommentId ) :
			m_strFilename( strFilename ),
			m_uiLineNumber( uiLineNumber ),
			m_uiId( uiId ),
			m_eAtlasStatement( eStatement ),
			m_eSourceType( eType ),
			m_uiCommentId( uiCommentId )
		{  SetStatementNumber( strStatementNumber ); }

		AtlasSourceStatement( const AtlasSourceStatement& other ) { Init( ); operator = ( other ); }
		AtlasSourceStatement& operator = ( const AtlasSourceStatement& other )
		{
			if ( this != &other )
			{
				m_eSourceType			= other.m_eSourceType;
				m_eAtlasStatement		= other.m_eAtlasStatement;
				m_strFilename			= other.m_strFilename;
				m_strParentProcname		= other.m_strParentProcname;
				m_strStatementNumber	= other.m_strStatementNumber;
				m_strTestNumber			= other.m_strTestNumber;
				m_strStepNumber			= other.m_strStepNumber;
				m_uiLineNumber			= other.m_uiLineNumber;
				m_uiCommentId			= other.m_uiCommentId;
				m_uiId					= other.m_uiId;
				m_bBeginTest			= other.m_bBeginTest;
			}

			return *this;
		}
		bool operator == ( const AtlasSourceStatement& other ) const
		{
			bool bIsEqual = true;

			if ( this != &other )
			{
				bIsEqual = ( ( m_eSourceType == other.m_eSourceType )
					&& ( m_eAtlasStatement == other.m_eAtlasStatement ) 
					&& ( m_strFilename == other.m_strFilename ) 
					&& ( m_strParentProcname == other.m_strParentProcname )
					&& ( m_strStatementNumber == other.m_strStatementNumber )
					&& ( m_strTestNumber == other.m_strTestNumber )
					&& ( m_strStepNumber == other.m_strStepNumber )
					&& ( m_uiLineNumber == other.m_uiLineNumber )
					&& ( m_uiCommentId == other.m_uiCommentId )
					&& ( m_uiId == other.m_uiId )
					&& ( m_bBeginTest == other.m_bBeginTest ) );
			}

			return bIsEqual;
		}
		bool operator != ( const AtlasSourceStatement& other ) const { return !( operator == ( other ) ); }

		void SetSourceType( const eSourceType eType ) { m_eSourceType = eType; }
		void SetAtlasStatement( const eAtlasStatement eStatement ) { m_eAtlasStatement = eStatement; }
		void SetFilename( const string& strFilename ) { m_strFilename = strFilename; }
		void SetParentProcname( const string& strProcname ) { m_strParentProcname = strProcname; }
		void SetStatementNumber( const string& strStatementNumber );
		void SetTestNumber( const string& strTestNumber ) { m_strTestNumber = strTestNumber; }
		void SetStepNumber( const string& strStepNumber );
		void SetLineNumber( const unsigned int uiLineNumber ) { m_uiLineNumber = uiLineNumber; }
		void SetCommentId( const unsigned int uiCommentId ) { m_uiCommentId = uiCommentId; }
		void SetId( const unsigned int uiId ) { m_uiId = uiId; }
		const eSourceType& GetSourceType( void ) const { return m_eSourceType; }
		const eAtlasStatement& GetAtlasStatement( void ) const { return m_eAtlasStatement; }
		const string& GetFilename( void ) const { return m_strFilename; }
		const string& GetParentProcname( void ) const { return m_strParentProcname; }
		const string& GetStatementNumber( void ) const { return m_strStatementNumber; }
		const string& GetTestNumber( void ) const { return m_strTestNumber; }
		const string& GetStepNumber( void ) const { return m_strStepNumber; }
		const bool& IsBeginTest( void ) const { return m_bBeginTest; }

		const unsigned int& GetLineNumber( void ) const { return m_uiLineNumber; }
		const unsigned int& GetCommentId( void ) const { return m_uiCommentId; }
		const unsigned int& GetId( void ) const { return m_uiId; }
		XML::AttributeValue GetSourceTypeName( void ) const { return GetSourceTypeName( m_eSourceType ); }

		static XML::AttributeValue GetSourceTypeName( const eSourceType eType );

		string ToXML( const unsigned int uiFields ) const;

	protected:

		string m_strFilename;
		string m_strParentProcname;
		string m_strStatementNumber;
		string m_strTestNumber;
		string m_strStepNumber;
		unsigned int m_uiLineNumber;
		unsigned int m_uiId;
		unsigned int m_uiCommentId;
		eAtlasStatement m_eAtlasStatement;
		eSourceType m_eSourceType;
		bool m_bBeginTest;

		void Init( void )
		{
			m_uiLineNumber = 0;
			m_uiCommentId = 0;
			m_uiId = 0;
			m_eAtlasStatement = eUnknownAtlasStatement;
			m_eSourceType = eUnknownSourceType;
			m_bBeginTest = false;
		}
	};  // class AtlasSourceStatement

	class AtlasSignalComponent
	{
	public:

		AtlasSignalComponent( ) { Init( ); }
		AtlasSignalComponent( const eAtlasNoun eNoun, const eAtlasNounModifier eNounModifier = eUnknownAtlasNounModifier, Atlas::eAtlasFunction eFunction = eUnknownAtlasFunction );
		AtlasSignalComponent( const AtlasSignalComponent& other ) { Init( ); operator = ( other ); }
		~AtlasSignalComponent( ) { }
		AtlasSignalComponent& operator = ( const AtlasSignalComponent& other );
		bool operator == ( const AtlasSignalComponent& other ) const;
		bool operator != ( const AtlasSignalComponent& other ) const { return !( operator == ( other ) ); }

		operator string( void ) const;

		bool IsValid( void ) const;
		string ToXML( const XML::ElementName eName = XML::enSignalComponent ) const;

		void Set1641( void );
		void Set1641Connect( const ieee1641::eBSC eConnectBSC );

		void SetAtlasNoun( const eAtlasNoun eNoun ) { m_eAtlasNoun = eNoun; }
		void SetAtlasNounResource( const eAtlasResource eResource ) { m_eAtlasNounResource = eResource; }
		void SetAtlasNounModifier( const eAtlasNounModifier eNounModifier ) { m_eAtlasNounModifier = eNounModifier; }
		void SetAtlasNounModifierRequire( const eAtlasRequire eRequire ) { m_setAtlasNounModifierRequire.insert( eRequire ); }
		void SetAtlasNounModifierSuffix( const string& strSuffix );
		void SetAtlasFunction( const eAtlasFunction eFunction ) { m_eAtlasFunction = eFunction; }
		void SetAtlasPinDescriptor( const eAtlasPinDescriptor ePinDescriptor ) { m_eAtlasPinDescriptor = ePinDescriptor; }

		const eAtlasNoun& GetAtlasNoun( void ) const { return m_eAtlasNoun; }
		const eAtlasResource& GetAtlasNounResource( void ) const { return m_eAtlasNounResource; }
		string GetAtlasNounAsString( void ) const { return Atlas::GetAtlasNoun( m_eAtlasNoun ); }
		string GetAtlasNounDescription( void ) const { return Atlas::GetAtlasNounDescription( m_eAtlasNoun ); }
		string GetAtlasNounResourceDescription( void ) const { return Atlas::GetAtlasResoure( m_eAtlasNounResource ); }

		const eAtlasNounModifier& GetAtlasNounModifier( void ) const { return m_eAtlasNounModifier; }
		const set< eAtlasRequire >& GetAtlasNounModifierRequire( void ) const { return m_setAtlasNounModifierRequire; }
		string GetAtlasNounModifierAsString( void ) const { return Atlas::GetAtlasNounModifier( m_eAtlasNounModifier ); }
		string GetAtlasNounModifierDescription( void ) const { return Atlas::GetAtlasNounModifierDescription( m_eAtlasNounModifier ); }
		string GetAtlasNounModifierRequireDescription( void ) const;
		const string& GetAtlasNounModifierSuffix( void ) const { return m_strSuffix; }

		const Atlas::eAtlasFunction& GetAtlasFunction( void ) const { return m_eAtlasFunction; }
		string GetAtlasFunctionAsString( void ) const { return Atlas::GetAtlasFunction( m_eAtlasFunction ); }
		string GetAtlasFunctionDescription( void ) const { return Atlas::GetAtlasFunctionDescription( m_eAtlasFunction ); }

		const eAtlasPinDescriptor& GetAtlasPinDescriptor( void ) const { return m_eAtlasPinDescriptor; }
		string GetAtlasPinDescriptorAsString( void ) const { return Atlas::GetAtlasPinDescriptor( m_eAtlasPinDescriptor ); }
		string GetAtlasPinDescriptorDescription( void ) const { return Atlas::GetAtlasPinDescriptorDescription( m_eAtlasPinDescriptor ); }

		static void Set1641ToXML( const bool bSet ) { m_b1641ToXML = bSet; }
		static bool Get1641ToXML( void ) { return m_b1641ToXML; }

	protected:

		void ToXMLAtlas( string& strXML ) const;
		void ToXML1641( string& strXML ) const;
		bool IsValid1641( void ) const;

		void Init( void )
		{
			m_eAtlasNoun				= eUnknownAtlasNoun;
			m_eAtlasNounResource		= eUnknownAtlasResource;
			m_eAtlasNounModifier		= eUnknownAtlasNounModifier;
			m_eAtlasFunction			= eUnknownAtlasFunction;
			m_eAtlasPinDescriptor		= eUnknownAtlasPinDescriptor;

			m_setAtlasNounModifierRequire.clear( );

			Init1641( );
		}

		void Init1641( void )
		{
			m_iTSF				= m_iInvalid1641Value;
			m_i1641BSC			= m_iInvalid1641Value;
			m_i1641BSCAttribute	= m_iInvalid1641Value;
			m_vect1641Qualifier.clear( );
			m_strPhase.clear( );
		}

		eAtlasNoun m_eAtlasNoun;
		eAtlasResource m_eAtlasNounResource;
		eAtlasNounModifier m_eAtlasNounModifier;
		set< eAtlasRequire > m_setAtlasNounModifierRequire;
		eAtlasFunction m_eAtlasFunction;
		eAtlasPinDescriptor m_eAtlasPinDescriptor; 
		vector< pair< eAtlasModifierSuffix, int > > m_vectSuffix;
		string m_strSuffix;

		int m_iTSF;
		int m_i1641BSC;
		int m_i1641BSCAttribute;
		string m_strPhase;
		vector< ieee1641::eQualifier > m_vect1641Qualifier;

		static const int m_iInvalid1641Value;
		static bool m_b1641ToXML;

	};  // class AtlasSignalComponent

	class AtlasUnitOfMeasure
	{
	public:

		AtlasUnitOfMeasure( ) { Init( ); }
		AtlasUnitOfMeasure( const AtlasUnitOfMeasure& other ) { Init( ); operator = ( other ); }
		AtlasUnitOfMeasure( const eUnitOfMeasure eUnit, const eUnitOfMeasure eAcceleration = eUnknownUnitOfMeasure, const eUnitOfMeasure eAccelerationUnit = eUnknownUnitOfMeasure ) { Set( eUnit, eAcceleration, eAccelerationUnit ); }
		AtlasUnitOfMeasure& operator = ( const AtlasUnitOfMeasure& other )
		{
			if ( this != &other )
			{
				m_eUnit	= other.m_eUnit;
				m_eAcceleration = other.m_eAcceleration;
				m_eAccelerationUnit = other.m_eAccelerationUnit;
			}

			return *this;
		}
		bool operator == ( const AtlasUnitOfMeasure& other ) const
		{
			bool bIsEqual = true;

			if ( this != &other )
			{
				bIsEqual = ( ( m_eUnit == other.m_eUnit ) 
					&& ( m_eAcceleration == other.m_eAcceleration ) 
					&& ( m_eAccelerationUnit == other.m_eAccelerationUnit ) );
			}

			return bIsEqual;
		}
		bool operator != ( const AtlasUnitOfMeasure& other ) const { return !( operator == ( other ) ); }

		operator string( void ) const
		{
			string strRet;

			if ( eUnknownUnitOfMeasure != m_eUnit )
			{
				const string strFrontSlash( "/" );

				strRet = GetAtlasUnitOfMeasure( m_eUnit );

				if ( eUnknownUnitOfMeasure != m_eAcceleration )
				{
					strRet += strFrontSlash;
					strRet += GetAtlasUnitOfMeasure( m_eAcceleration );

					if ( eUnknownUnitOfMeasure != m_eAccelerationUnit )
					{
						strRet += strFrontSlash;
						strRet += GetAtlasUnitOfMeasure( m_eAccelerationUnit );
					}
				}
			}

			return strRet;
		}

		void Set( const eUnitOfMeasure eUnit, const eUnitOfMeasure eAcceleration = eUnknownUnitOfMeasure, const eUnitOfMeasure eAccelerationUnit = eUnknownUnitOfMeasure ) { m_eUnit = eUnit; m_eAcceleration = eAcceleration; m_eAccelerationUnit = eAccelerationUnit; }

		bool IsUnit( void ) const { return ( Atlas::eUnknownUnitOfMeasure != m_eUnit ); }

		const eUnitOfMeasure& GetUnit( void ) const { return m_eUnit; }
		const eUnitOfMeasure& GetAcceleration( void ) const { return m_eAcceleration; }
		const eUnitOfMeasure& GetAccelerationUnit( void ) const { return m_eAccelerationUnit; }

		void Clear( void ) { Init( ); }

		string ToXML( void ) const
		{
			string strXML;

			strXML.reserve( 32 );

			if ( eUnknownUnitOfMeasure != m_eUnit )
			{
				strXML += XML::MakeXmlAttributeNameValue( XML::anUnit, ( m_b260_1XML ? Atlas::GetUnitOfMeasure( m_eUnit ) : Atlas::GetAtlasUnitOfMeasure( m_eUnit ) ) );
			}

			if ( eUnknownUnitOfMeasure != m_eAcceleration )
			{
				strXML += XML::MakeXmlAttributeNameValue( XML::anAccel, ( m_b260_1XML ? Atlas::GetUnitOfMeasure( m_eAcceleration ) : Atlas::GetAtlasUnitOfMeasure( m_eAcceleration ) ) );
			}

			if ( eUnknownUnitOfMeasure != m_eAccelerationUnit )
			{
				strXML += XML::MakeXmlAttributeNameValue( XML::anAccelUnit, ( m_b260_1XML ? Atlas::GetUnitOfMeasure( m_eAccelerationUnit ) : Atlas::GetAtlasUnitOfMeasure( m_eAccelerationUnit ) ) );
			}

			return strXML;
		}

		static void Set260_1XML( const bool bSet ) { m_b260_1XML = bSet; }
		static bool Get260_1XML( void ) { return m_b260_1XML; }

	protected:

		static bool m_b260_1XML;

		eUnitOfMeasure m_eUnit;
		eUnitOfMeasure m_eAcceleration;
		eUnitOfMeasure m_eAccelerationUnit;

		void Init( void )
		{
			m_eUnit = eUnknownUnitOfMeasure;
			m_eAcceleration = eUnknownUnitOfMeasure;
			m_eAccelerationUnit = eUnknownUnitOfMeasure;
		}
	};  // class AtlasUnitOfMeasure

	class AtlasData
	{
	public:

		enum eDataType
		{
			eUnknownDataType,
			eDouble,
			eInteger,
			eBinary,
			eHexadecimal,
			eOctal,
			eConnector,
			eBoolean,
			eString
		};

		enum eScopeType
		{
			eUnknownScopeType,
			eGlobal,
			eFileLocal,
			eSegmentLocal,
			eProcedureLocal,
			eProcedureParameter,
			eProcedureResult,
			eBuiltIn
		};

		enum eBuiltInType
		{
			eUnknownBuiltInType,
			eNoGo,
			eGo,
			eMaxTime,
			eLo,
			eHi,
			eTrue,
			eFalse
		};

		AtlasData( ) : 
			m_eScopeType( eUnknownScopeType ), 
			m_eBuiltInType( eUnknownBuiltInType ), 
			m_uiVariableRefId( 0 ), 
			m_eAtlasDataType( Atlas::eUnknownDataType ), 
			m_eDataType( eUnknownDataType ),
			m_bRefIdRequired( true )
		{ }
		AtlasData( const string& strVariableName ) : 
			m_eScopeType( eUnknownScopeType ), 
			m_eBuiltInType( eUnknownBuiltInType ), 
			m_uiVariableRefId( 0 ), 
			m_eAtlasDataType( Atlas::eUnknownDataType ), 
			m_eDataType( eUnknownDataType ),
			m_strVariableName( strVariableName ),
			m_bRefIdRequired( true )
		{ }
		AtlasData( const AtlasData& other ) { operator = ( other ); }
		virtual ~AtlasData( ) { }
		AtlasData& operator = ( const AtlasData& other );

		bool IsVariableName( void ) const { return !m_strVariableName.empty( ); }

		const string& GetVariableName( void ) const { return m_strVariableName; }
		void SetVariableName( const string& strVariableName ) { m_strVariableName = strVariableName; }

		virtual void SetAtlasDataType( const Atlas::eDataType eType ) { m_eAtlasDataType = eType; }
		Atlas::eDataType GetAtlasDataType( void ) const { return m_eAtlasDataType; }

		virtual void SetDataType( const eDataType eType ) { m_eDataType = eType; }
		eDataType GetDataType( void ) const { return m_eDataType; }

		void SetUnitOfMeasure( const AtlasUnitOfMeasure AtlasUnit ) { m_UnitOfMeasure = AtlasUnit; }
		const AtlasUnitOfMeasure& GetUnitOfMeasure( void ) const { return m_UnitOfMeasure; }

		bool IsBitwiseDataType( void ) const;
		bool IsAtlasNumericDataType( void ) const;

		void SetScopeType( const eScopeType eType ) { m_eScopeType = eType; }
		eScopeType GetScopeType( void ) const { return m_eScopeType; }

		void SetBuiltInType( const eBuiltInType eType ) { m_eBuiltInType = eType; }
		eBuiltInType GetBuiltInType( void ) const { return m_eBuiltInType; }

		void SetVariableRefId( const unsigned int uiRefId ) { m_uiVariableRefId = uiRefId; }
		unsigned int GetVariableRefId( void ) const { return m_uiVariableRefId; }

		void SetRefIdRequired( const bool bSet ) { m_bRefIdRequired = bSet; }
		unsigned int IsRefIdRequired( void ) const { return m_bRefIdRequired; }

		string GetHashValue( void ) const;

		virtual string ToXML( const bool bVariableNameVerficiation = true ) const;

	protected:

		XML::AttributeValue GetDataTypeAttributeValue( void ) const;
		XML::AttributeValue GetScopeAttributeValue( void ) const;

		string m_strVariableName;
		eScopeType m_eScopeType;
		eBuiltInType m_eBuiltInType;
		Atlas::eDataType m_eAtlasDataType;
		eDataType m_eDataType;
		unsigned int m_uiVariableRefId;
		AtlasUnitOfMeasure m_UnitOfMeasure;
		bool m_bRefIdRequired;

	};  // class AtlasData

	class AtlasString : public AtlasData
	{
	public:

		AtlasString( ) : AtlasData( ){ Init( ); }
		AtlasString( const string& str ) : AtlasData( ) 
		{ 
			Init( ); 
			
			try { m_pstrData = new string( str ); }
			catch ( ... ) { throw Exception( Exception::eFailedToCreateStringObject, __FILE__, __FUNCTION__, __LINE__ ); }
		}
		AtlasString( const AtlasString& other ) : AtlasData( ) { operator = ( other ); }
		~AtlasString( ) { GarbageCollect( ); }

		AtlasString& operator = ( const AtlasString& other )
		{
			if ( this != &other )
			{
				AtlasData::operator = ( other );

				if ( 0 == other.m_pstrData )
				{
					GarbageCollect( );
				}
				else if ( 0 == m_pstrData )
				{
					try
					{
						m_pstrData = new string( *( other.m_pstrData ) );
					}
					catch ( ... )
					{
						throw Exception( Exception::eFailedToCreateStringObject, __FILE__, __FUNCTION__, __LINE__ );
					}
				}
				else
				{
					*m_pstrData = *( other.m_pstrData );
				}
			}

			return *this;
		}

		void Set( const string& str )
		{ 
			if ( 0 == m_pstrData )
			{
				try
				{
					m_pstrData = new string( str );
				}
				catch ( ... )
				{
					throw Exception( Exception::eFailedToCreateStringObject, __FILE__, __FUNCTION__, __LINE__ );
				}
			}
			else
			{
				*m_pstrData = str;
			}
		}
		const string* Get( void ) const { return m_pstrData; }

		string ToXML( const bool bVariableNameVerficiation = true ) const
		{
			string strXML;

			if ( bVariableNameVerficiation && IsVariableName( ) )
			{
				strXML.reserve( 50 );

				strXML += AtlasData::ToXML( );
			}
			else if ( 0 != m_pstrData )
			{
				strXML.reserve( 50 );

				strXML += XML::MakeXmlAttributeNameValue( XML::anValue, *m_pstrData );
				strXML += XML::MakeXmlAttributeNameValue( XML::anType, XML::avChar );
			}

			return strXML;
		}

	protected:

		void Init( void )
		{
			m_pstrData = 0;
			m_eAtlasDataType = Atlas::eMSGCHAR; 
			m_eDataType = eString;
		}

		void GarbageCollect( void )
		{
			if ( 0 != m_pstrData )
			{
				delete m_pstrData;
				m_pstrData = 0;
			}
		}

		string* m_pstrData;

	};  // class AtlasString

	class AtlasBool : public AtlasData
	{
	public:

		AtlasBool( ) : AtlasData( ) { Init( ); }
		AtlasBool( const bool b ) : AtlasData( )
		{ 
			Init( ); 
			
			try { m_pbData = new bool( b ); }
			catch ( ... ) { throw Exception( Exception::eFailedToCreateBoolObject, __FILE__, __FUNCTION__, __LINE__ ); }
		}
		AtlasBool( const AtlasBool& other ) : AtlasData( ) { operator = ( other ); }
		~AtlasBool( ) { GarbageCollect( ); }

		AtlasBool& operator = ( const AtlasBool& other )
		{
			if ( this != &other )
			{
				AtlasData::operator = ( other );

				if ( 0 == other.m_pbData )
				{
					GarbageCollect( );
				}
				else if ( 0 == m_pbData )
				{
					try
					{
						m_pbData = new bool( *( other.m_pbData ) );
					}
					catch ( ... )
					{
						throw Exception( Exception::eFailedToCreateBoolObject, __FILE__, __FUNCTION__, __LINE__ );
					}
				}
				else
				{
					*m_pbData = *( other.m_pbData );
				}
			}

			return *this;
		}

		void Set( const bool b )
		{ 
			if ( 0 == m_pbData )
			{
				try
				{
					m_pbData = new bool( b );
				}
				catch ( ... )
				{
					throw Exception( Exception::eFailedToCreateBoolObject, __FILE__, __FUNCTION__, __LINE__ );
				}
			}
			else
			{
				*m_pbData = b;
			}
		}
		const bool* Get( void ) const { return m_pbData; }

		string ToXML( const bool bVariableNameVerficiation = true ) const
		{
			string strXML;

			if ( bVariableNameVerficiation && IsVariableName( ) )
			{
				strXML.reserve( 50 );

				strXML += AtlasData::ToXML( );
			}
			else if ( 0 != m_pbData )
			{
				strXML.reserve( 50 );

				strXML += XML::MakeXmlAttributeNameValue( XML::anValue, ( *m_pbData ? XML::avTrue : XML::avFalse ) );
				strXML += XML::MakeXmlAttributeNameValue( XML::anType, XML::avBoolean );
			}

			return strXML;
		}

	protected:

		void Init( void )
		{
			m_pbData = 0;
			m_eAtlasDataType = Atlas::eBOOLEAN; 
			m_eDataType = eBoolean;
		}

		void GarbageCollect( void )
		{
			if ( 0 != m_pbData )
			{
				delete m_pbData;
				m_pbData = 0;
			}
		}

		bool* m_pbData;

	};  // class AtlasBool

	class AtlasConnector : public AtlasData
	{
	public:

		AtlasConnector( ) : AtlasData( ) { Init( ); }
		AtlasConnector( const string& strConnector ) : AtlasData( ) 
		{ 
			Init( ); 

			try { m_pstrConnector = new string( strConnector ); }
			catch ( ... ) { throw Exception( Exception::eFailedToCreateConnectorObject, __FILE__, __FUNCTION__, __LINE__ ); }
		}
		AtlasConnector( const AtlasConnector& other ) : AtlasData( ) { operator = ( other ); }
		~AtlasConnector( ) { GarbageCollect( ); }

		AtlasConnector& operator = ( const AtlasConnector& other )
		{
			if ( this != &other )
			{
				AtlasData::operator = ( other );

				if ( 0 == other.m_pstrConnector )
				{
					GarbageCollect( );
				}
				else if ( 0 == m_pstrConnector )
				{
					try
					{
						m_pstrConnector = new string( *( other.m_pstrConnector ) );
					}
					catch ( ... )
					{
						throw Exception( Exception::eFailedToCreateConnectorObject, __FILE__, __FUNCTION__, __LINE__ );
					}
				}
				else
				{
					*m_pstrConnector = *( other.m_pstrConnector );
				}
			}

			return *this;
		}

		void Set( const string& strConnector )
		{
			if ( 0 == m_pstrConnector )
			{
				try
				{
					m_pstrConnector = new string( strConnector );
				}
				catch ( ... )
				{
					throw Exception( Exception::eFailedToCreateConnectorObject, __FILE__, __FUNCTION__, __LINE__ );
				}
			}
			else
			{
				*m_pstrConnector = strConnector;
			}
		}
		const string* Get( void ) const { return m_pstrConnector; }

		string ToXML( const bool bVariableNameVerficiation = true ) const
		{
			string strXML;

			if ( bVariableNameVerficiation && IsVariableName( ) )
			{
				strXML.reserve( 50 );

				strXML += AtlasData::ToXML( );
			}
			else if ( 0 != m_pstrConnector )
			{
				strXML.reserve( 50 );

				strXML += XML::MakeXmlAttributeNameValue( XML::anValue, *m_pstrConnector );
				strXML += XML::MakeXmlAttributeNameValue( XML::anType, XML::avConnector );
			}

			return strXML;
		}

	protected:

		void Init( void )
		{
			m_pstrConnector = 0;
			m_eAtlasDataType = Atlas::eCONNECTION; 
			m_eDataType = eConnector;
		}

		void GarbageCollect( void )
		{
			if ( 0 != m_pstrConnector )
			{
				delete m_pstrConnector;
				m_pstrConnector = 0;
			}
		}

		string* m_pstrConnector;

	};  // class AtlasConnector

	class AtlasNumber : public AtlasData
	{
	public:

		AtlasNumber( ) : AtlasData( ) { Init( ); }
		AtlasNumber( const AtlasNumber& other ) : AtlasData( ) { Init( ); operator = ( other ); }
		AtlasNumber( const string& strNumber, const AtlasUnitOfMeasure& AtlasUnit = AtlasUnitOfMeasure( ) ) : AtlasData( ) { Set( strNumber, AtlasUnit ); }

		bool ReplaceIfLarger( const AtlasNumber& other );
		bool ReplaceIfSmaller( const AtlasNumber& other );

		string ToXML( const bool bVariableNameVerficiation = true ) const;

		bool IsNaN( void ) const;

		bool Set( const string& strNumber, const AtlasUnitOfMeasure& AtlasUnit = AtlasUnitOfMeasure( ) );
		void Clear( void ) { Init( ); } // After execution, method IsNaN will return true

		void SetSymmetricalErrorLimit( const bool bSet ) { m_bSymmetricalErrorLimit = bSet; }
		bool IsSymmetricalErrorLimit( void ) const { return m_bSymmetricalErrorLimit; }

		void SetAtlasDataType( const Atlas::eDataType eType );
		void SetDataType( const eDataType eType );

		// The following are only meaningful when method IsNaN is false
		bool IsNegative( void ) const;
		bool IsWholeNumber( void ) const;

		// Returns an empty string if method IsNaN is true
		string GetNumber( const bool bIncludeUnitOfMeasure ) const; 

		operator double( void ) const { return m_dValue; }
		operator string( void ) const { return GetNumber( false ); }
		// The follow return zero if method IsNaN is true
		operator int( void ) const;
		operator long( void ) const;

		AtlasNumber& operator = ( const AtlasNumber& other );

		// The following comparitors don't use m_eUnitOfMeasure in comparison
		bool operator == ( const AtlasNumber& other ) const;
		bool operator != ( const AtlasNumber& other ) const;
		bool operator < ( const AtlasNumber& other ) const;
		bool operator <= ( const AtlasNumber& other ) const;
		bool operator > ( const AtlasNumber& other ) const;
		bool operator >= ( const AtlasNumber& other ) const;

	protected:

		double m_dValue;
		string m_strValue;
		bool m_bSymmetricalErrorLimit;

		void Init( void );
	};  // class AtlasNumber

	class AtlasErrorLimit
	{
	public:

		AtlasErrorLimit( ) { Init( ); }
		AtlasErrorLimit( const AtlasErrorLimit& other ) { Init( ); operator = ( other ); }
		~AtlasErrorLimit( ) { GarbageCollect( ); }

		AtlasErrorLimit& operator = ( const AtlasErrorLimit& other );

		bool IsLimit( void ) const;

		void SetLimit1( AtlasNumber* pNumber, const bool bTransferOwnership = true );
		void SetLimit2( AtlasNumber* pNumber, const bool bTransferOwnership = true );

		AtlasNumber* GetLimit1( void ) const { return m_pLimit1; }
		AtlasNumber* GetLimit2( void ) const { return m_pLimit2; }

		AtlasNumber* ReleaseLimit1( void ) { AtlasNumber* p = m_pLimit1; m_pLimit1 = 0; return p; }
		AtlasNumber* ReleaseLimit2( void ) { AtlasNumber* p = m_pLimit2; m_pLimit2 = 0; return p; }

		string ToXML( void ) const;

	protected:

		AtlasNumber* m_pLimit1;
		AtlasNumber* m_pLimit2;

		void Init( void );
		void GarbageCollect( void );

	};  // class AtlasErrorLimit

	class AtlasEvaluationStatement
	{
	public:

		AtlasEvaluationStatement( ) { Init( ); }
		AtlasEvaluationStatement( const AtlasEvaluationStatement& other ) { operator = ( other ); }
		AtlasEvaluationStatement& operator = ( const AtlasEvaluationStatement& other );
		~AtlasEvaluationStatement( ) { GarbageCollect( ); }

		void SetField1( const eEvaluationFieldType eType, const AtlasNumber& num ) { SetField( eType, num, &m_pField1 ); }
		void SetField2( const eEvaluationFieldType eType, const AtlasNumber& num ) { SetField( eType, num, &m_pField2 ); }
		void SetField3( const eEvaluationFieldType eType, const AtlasNumber& num ) { SetField( eType, num, &m_pField3 ); }

		pair< eEvaluationFieldType, AtlasNumber >* GetField1( void ) const { return m_pField1; }
		pair< eEvaluationFieldType, AtlasNumber >* GetField2( void ) const { return m_pField2; }
		pair< eEvaluationFieldType, AtlasNumber >* GetField3( void ) const { return m_pField3; }

		void RemoveField1( void ) { RemoveField( &m_pField1 ); }
		void RemoveField2( void ) { RemoveField( &m_pField2 ); }
		void RemoveField3( void ) { RemoveField( &m_pField3 ); }

		string ToXML( void ) const;

	protected:

		pair< eEvaluationFieldType, AtlasNumber >* m_pField1;
		pair< eEvaluationFieldType, AtlasNumber >* m_pField2;
		pair< eEvaluationFieldType, AtlasNumber >* m_pField3;

		void SetField( const eEvaluationFieldType eType, const AtlasNumber& num, pair< eEvaluationFieldType, AtlasNumber >** ppField );
		void RemoveField( pair< eEvaluationFieldType, AtlasNumber >** ppField );
		string ToXML_EvaluationField( pair< eEvaluationFieldType, AtlasNumber >* pField ) const;
		void GarbageCollect( void );
		void Init( void );

	}; // class AtlasEvaluationStatement

	class AtlasRange
	{
	public:

		AtlasRange( ) { Init( ); }
		AtlasRange( const AtlasRange& other ) { Init( ); operator = ( other ); }
		~AtlasRange( ) { GarbageCollect( ); }

		AtlasRange& operator = ( const AtlasRange& other );

		void Merge( const AtlasRange& other );

		bool IsRange( void ) const;

		void SetRange1( AtlasNumber* pNumber, const bool bTransferOwnership = true );
		void SetRange2( AtlasNumber* pNumber, const bool bTransferOwnership = true );
		void SetByValue( AtlasNumber* pNumber, const bool bTransferOwnership = true );
		void SetContinuous( const bool bContinuous ) { m_bContinuous = bContinuous; }

		AtlasNumber* GetRange1( void ) const { return m_pRange1; }
		AtlasNumber* GetRange2( void ) const { return m_pRange2; }
		AtlasNumber* GetByValue( void ) const { return m_pByValue; }
		bool GetContinuous( void ) const { return m_bContinuous; }

		AtlasNumber* ReleaseRange1( void ) { AtlasNumber* p = m_pRange1; m_pRange1 = 0; return p; }
		AtlasNumber* ReleaseRange2( void ) { AtlasNumber* p = m_pRange2; m_pRange2 = 0; return p; }
		AtlasNumber* ReleaseByValue( void ) { AtlasNumber* p = m_pByValue; m_pByValue = 0; return p; }

		string ToXML( void ) const;

	protected:

		Atlas::AtlasNumber* m_pRange1;
		Atlas::AtlasNumber* m_pRange2;
		Atlas::AtlasNumber* m_pByValue;
		bool m_bContinuous;

		void Init( void );
		void GarbageCollect( void );

	}; // class AtlasRange

	class AtlasStatementCharacteristic
	{
	public:

		enum eCharacteristic
		{
			eMax					= 0x0001,
			eMin					= 0x0002,
			eDimension				= 0x0004,
			eThru					= 0x0008,
			eFrom					= 0x0010,
			eEvent					= 0x0020,
			eGated					= 0x0040,
			eSync					= 0x0080
		};

		AtlasStatementCharacteristic( ) { Init( ); }
		AtlasStatementCharacteristic( const AtlasStatementCharacteristic& other ) { Init( ); operator = ( other ); }
		~AtlasStatementCharacteristic( ) { GarbageCollect( ); }

		AtlasStatementCharacteristic& operator = ( const AtlasStatementCharacteristic& other );

		void SetNumber( AtlasNumber* pNumber, const bool bTransferOwnership = true );
		void SetRange( AtlasRange* pRange, const bool bTransferOwnership = true );
		void SetErrorLimit( AtlasErrorLimit* pErrorLimit, const bool bTransferOwnership = true );
		void SetStartNumber( AtlasNumber* pNumber, const bool bTransferOwnership = true );
		void SetEndNumber( AtlasNumber* pNumber, const bool bTransferOwnership = true );
		void SetEventName1( string* pstrEventName, const bool bTransferOwnership = true );
		void SetEventName2( string* pstrEventName, const bool bTransferOwnership = true );
		void SetAttributeValue( string* pstrVarValue, const bool bTransferOwnership = true );

		AtlasNumber* GetNumber( void ) const { return m_pNumber; }
		AtlasRange* GetRange( void ) const { return m_pRange; }
		AtlasErrorLimit* GetErrorLimit( void ) const { return m_pErrorLimit; }
		AtlasNumber* GetStartNumber( void ) const { AtlasNumber* pRet = 0; if ( 0 != m_prStartEnd ) { pRet = m_prStartEnd->first; } return pRet; }
		AtlasNumber* GetEndNumber( void ) const { AtlasNumber* pRet = 0; if ( 0 != m_prStartEnd ) { pRet = m_prStartEnd->second; } return pRet; }
		string* GetEventName1( void ) const { return m_pstrEventName1; }
		string* GetEventName2( void ) const { return m_pstrEventName1; }
		string* GetAttributeValue( void ) const { return m_pstrAttributeValue; }

		bool IsValid( void ) const;

		bool IsSync( void ) const { return ( eSync == ( m_uiCharacteristics & eSync ) ); }
		void SetSync( const bool bSync ) { if ( bSync ) { m_uiCharacteristics |= eSync; } else { m_uiCharacteristics &= ~eSync; } }

		bool IsGated( void ) const { return ( eGated == ( m_uiCharacteristics & eGated ) ); }
		void SetGated( const bool bGated ) { if ( bGated ) { m_uiCharacteristics |= eGated; } else { m_uiCharacteristics &= ~eGated; } }

		bool IsEvent( void ) const { return ( eEvent == ( m_uiCharacteristics & eEvent ) ); }
		void SetEvent( const bool bEvent ) { if ( bEvent ) { m_uiCharacteristics |= eEvent; } else { m_uiCharacteristics &= ~eEvent; } }

		bool IsFrom( void ) const { return ( eFrom == ( m_uiCharacteristics & eFrom ) ); }
		void SetFrom( const bool bFrom ) { if ( bFrom ) { m_uiCharacteristics |= eFrom; } else { m_uiCharacteristics &= ~eFrom; } }

		bool IsMax( void ) const { return ( eMax == ( m_uiCharacteristics & eMax ) ); }
		void SetMax( const bool bMax ) { if ( bMax ) { m_uiCharacteristics |= eMax; } else { m_uiCharacteristics &= ~eMax; } }

		bool IsMin( void ) const { return ( eMin == ( m_uiCharacteristics & eMin ) ); }
		void SetMin( const bool bMin ) { if ( bMin ) { m_uiCharacteristics |= eMin; } else { m_uiCharacteristics &= ~eMin; } }

		bool IsThru( void ) const { return ( eThru == ( m_uiCharacteristics & eThru ) ); }
		void SetThru( const bool bThru ) { if ( bThru ) { m_uiCharacteristics |= eThru; } else { m_uiCharacteristics &= ~eThru; } }

		bool IsDimension( void ) const { return ( eDimension == ( m_uiCharacteristics & eDimension ) ); }
		void SetDimension( const bool bDimension ) { if ( bDimension ) { m_uiCharacteristics |= eDimension; } else { m_uiCharacteristics &= ~eDimension; } }

		void ToXML( string& strXML ) const;

	protected:

		AtlasNumber* m_pNumber;
		AtlasRange* m_pRange;
		AtlasErrorLimit* m_pErrorLimit;
		pair< AtlasNumber*, AtlasNumber* >* m_prStartEnd;
		string* m_pstrEventName1;
		string* m_pstrEventName2;
		string* m_pstrAttributeValue;
		unsigned int m_uiCharacteristics;

		void Init( void );
		void GarbageCollect( void );

	};  // class AtlasStatementCharacteristic

	class AtlasTermBase
	{
	public:

		AtlasTermBase( ) { }
		virtual ~AtlasTermBase( ) { }

		virtual void ToXML( string& strXML, const XML::ElementName eName ) const = 0;

	protected:
	};

	class AtlasTerm : public AtlasTermBase
	{
	public:

		enum eUnaryOperator
		{
			eUnknownUnaryOperator = -1,
			eNotOperator,
		};

		enum eBuiltIn
		{
			eUnknownBuiltIn = -1,
			eMaxTimeBuiltIn,
			eGoBuiltIn,
			eNoGoBuiltIn,
			eLoBuiltIn,
			eHiBuiltIn,
			eTrueBuiltIn,
			eFalseBuiltIn
		};

		AtlasTerm( ) : m_pTerm( 0 ), m_pSubscriptTerm( 0 ), m_eUnaryOperator( eUnknownUnaryOperator ) { }
		virtual ~AtlasTerm( ) { GarbageCollect( ); }

		void SetTerm( AtlasData* pTerm );
		void SetTerm( const eBuiltIn eBuiltin );
		AtlasData* GetTerm( const bool bTransferOwnership );

		void SetSubscriptTerm( AtlasData* pSubscript );
		AtlasData* GetSubscriptTerm( const bool bTransferOwnership );

		void SetOperator( const eUnaryOperator eOperator ) { m_eUnaryOperator = eOperator; }
		eUnaryOperator GetOperator( void ) const { return m_eUnaryOperator; }

		void ToXML( string& strXML, const XML::ElementName eName ) const;
		string GetAssignValue_XML( const XML::ElementName eName ) const;

		static eUnaryOperator GetOperator( const string& strOperator );
		static eBuiltIn GetBuiltIn( const string& strBuiltIn );

		static const string& GetRawClassName( void ) { return m_strRawClassName; }

	protected:

		AtlasData* m_pTerm;
		AtlasData* m_pSubscriptTerm;
		eUnaryOperator m_eUnaryOperator;

		static const string m_strRawClassName;

		void GarbageCollect( void );

	};  // class AtlasTerm

	class AtlasLimitTerm : public AtlasTermBase
	{
	public:

		AtlasLimitTerm( ) : m_pLimitNumber( 0 ), m_pNominalLimit( 0 ), m_pLowerLimit( 0 ), m_pUpperLimit( 0 ) { }
		virtual ~AtlasLimitTerm( ) { GarbageCollect( ); }

		void SetLimitNumber( AtlasTerm* pTerm, const bool bTransferOwnership = true ) { SetValue( pTerm, &m_pLimitNumber, bTransferOwnership ); }
		void SetNominalLimit( AtlasTerm* pTerm, const bool bTransferOwnership = true ) { SetValue( pTerm, &m_pNominalLimit, bTransferOwnership ); };
		void SetLowerLimit( AtlasTerm* pTerm, const bool bTransferOwnership = true ) { SetValue( pTerm, &m_pLowerLimit, bTransferOwnership ); };
		void SetUpperLimit( AtlasTerm* pTerm, const bool bTransferOwnership = true ) { SetValue( pTerm, &m_pUpperLimit, bTransferOwnership ); };

		AtlasTerm* GetLimitNumber( void ) const { return m_pLimitNumber; }
		AtlasTerm* GetNominalLimit( void ) const { return m_pNominalLimit; }
		AtlasTerm* GetLowerLimit( void ) const { return m_pLowerLimit; }
		AtlasTerm* GetUpperLimit( void ) const { return m_pUpperLimit; }

		void ToXML( string& strXML, const XML::ElementName eName ) const;

		bool IsValid( void ) const { return ( ( 0 != m_pLimitNumber ) && ( 0 != m_pLowerLimit ) && ( 0 != m_pUpperLimit ) ); }

	protected:

		void GarbageCollect( void );
		void SetValue( AtlasTerm* pSource, AtlasTerm** ppTarget, const bool bTransferOwnership );

		AtlasTerm* m_pLimitNumber;
		AtlasTerm* m_pNominalLimit;
		AtlasTerm* m_pLowerLimit;
		AtlasTerm* m_pUpperLimit;
	};

	class AtlasExpression : public AtlasTerm
	{
	public:

		AtlasExpression( ) { Init( ); }
		virtual ~AtlasExpression( ) { GarbageCollect( ); }

		virtual void SetLeftExp( AtlasTerm* pLeftExp ) { SetExp( pLeftExp, true ); }
		virtual void SetRightExp( AtlasTerm* pRightExp ) { SetExp( pRightExp, false ); }

		AtlasTerm* GetLeftExp( const bool bTransferOwnership )
		{ 
			AtlasTerm* pTerm = m_pLeftExp;

			if ( bTransferOwnership )
			{
				m_pLeftExp = 0;
			}

			return pTerm;
		}
		AtlasTerm* GetRightExp( const bool bTransferOwnership )
		{ 
			AtlasTerm* pTerm = m_pRightExp;

			if ( bTransferOwnership )
			{
				m_pRightExp = 0;
			}

			return pTerm;
		}

		virtual void ToXML( string& strXML, const XML::ElementName eName ) const = 0;

	protected:

		void Init( void );

		void GarbageCollect( void );

		void SetExp( AtlasTerm* pSourceExp, const bool bLeft );

		void ToXML( string& strXML, const XML::ElementName eName, const string& strOperator ) const;

		AtlasTerm* m_pLeftExp;
		AtlasTerm* m_pRightExp;
	};

	class AtlasArithmeticExpression : public AtlasExpression
	{
		// Order of operations in math
		//
		// [P]lease [E]xcuse [M]y [D]ear [A]unt [S]ally
		//
		// [P]arentheses 
		// [E]xponents 
		// [M]ultiplication and [D]ivision - left to right
		// [A]ddition and [S]ubtraction - left to right
		//
		// Some examples using an "expression tree"
		//
		// 3 + 5 * 7 = 3 + 35 = 38
		//        (+)         
		//        / \        
		//       /   \       
		//      3    (*)     
		//           /  \     
		//          5    7   
		//
		//
		// (1 + 3) * (8 - 4) = 4 * 4 = 16
		//        (*)         
		//        / \        
		//       /   \       
		//     (+)   (-)     
		//     / \   / \     
		//    1   3 8  4   
		// 
		//
		//    ((A*B)+(C/D))  
		//        (+)         
		//        / \        
		//       /   \       
		//     (*)   (/)     
		//     / \   / \     
		//    A   B C   D   
		//   
		//   
		//   ( 1.00 * ( A + B ) / A ) - ( C * B ) / A
		//        (-)         
		//        / \        
		//       /    \       
		//     (/)      \(/) 
		//     /  \      / \   
		//    /    \    /   A     
		//  (*)     A  (*)                     
		//  /  \       / \                   
		// /    \     /   \                   
		//1.00  (+)  C     B                   
		//      /  \                     
		//     /    \                     
		//    A      B                                          
		//

	public:

		enum eMathOperator
		{
			eUnknownMathOperator = -1,
			eAdditionMathOperator,	// +
			eSubtraction,			// -
			eMultiplication,		// *
			eDivision,				// /
			eExponentiation			// **
		};

		AtlasArithmeticExpression( ) : m_eMathOperator( eUnknownMathOperator ) { }

		void SetOperator( const eMathOperator eOperator ) { m_eMathOperator = eOperator; }
		eMathOperator GetOperator( void ) const { return m_eMathOperator; }

		void ToXML( string& strXML, const XML::ElementName eName ) const;

		static eMathOperator GetOperator( const string& strOperator );

	protected:

		eMathOperator m_eMathOperator;

	};  // class AtlasArithmeticExpression

	class AtlasCompareExpression : public AtlasExpression
	{
	public:

		enum eCompareOperator
		{
			eUnknownCompareOperator = -1,
			eGreaterThanOperator,
			eLessThanOperator,
			eEqualOperator,
			eNotEqualOperator,
			eGreaterThanEqualOperator,
			eLessThanEqualOperator
		};

		AtlasCompareExpression( ) : m_eCompareOperator( eUnknownCompareOperator ) { }

		void SetOperator( const eCompareOperator eOperator ) { m_eCompareOperator = eOperator; }
		eCompareOperator GetOperator( void ) const { return m_eCompareOperator; }

		void ToXML( string& strXML, const XML::ElementName eName ) const;

		static eCompareOperator GetOperator( const string& strOperator );

	protected:

		eCompareOperator m_eCompareOperator;

	};  // class AtlasCompareExpression

	class AtlasBooleanExpression : public AtlasExpression
	{
	public:

		enum eBooleanOperator
		{
			eUnknownLogicalOperator = -1,
			eAndOperator,
			eOrOperator,
			eXorOperator			// Both differ (one is true, the other is false)
		};

		AtlasBooleanExpression( ) : m_eBooleanOperator( eUnknownLogicalOperator ) { }

		void SetOperator( const eBooleanOperator eOperator ) { m_eBooleanOperator = eOperator; }
		eBooleanOperator GetOperator( void ) const { return m_eBooleanOperator; }

		void ToXML( string& strXML, const XML::ElementName eName ) const;

		static eBooleanOperator GetOperator( const string& strOperator );

	protected:

		eBooleanOperator m_eBooleanOperator;

	};  // class AtlasBooleanExpression

	class AtlasBitwiseExpression : public AtlasExpression
	{
	public:

		enum eBitwiseOperator
		{
			eUnknownBitwiseOperator = -1,
			eAndOperator,
			eOrOperator,
			eXorOperator,
			eNotOperator,
			eShiftLeftOperator,
			eShiftRightOperator,
			eArithShiftLeftOperator,
			eArithShiftRightOperator,
			eRotateLeftOperator,
			eRotateRightOperator
		};

		AtlasBitwiseExpression( ) : m_eBitwiseOperator( eUnknownBitwiseOperator ) { }

		void TransferBooleanExpression( Atlas::AtlasBooleanExpression& boolExpression );

		void SetOperator( const eBitwiseOperator eOperator ) { m_eBitwiseOperator = eOperator; }
		eBitwiseOperator GetOperator( void ) const { return m_eBitwiseOperator; }

		void ToXML( string& strXML, const XML::ElementName eName ) const;

		static eBitwiseOperator GetOperator( const string& strOperator );

	protected:

		eBitwiseOperator m_eBitwiseOperator;

	};  // class AtlasBitwiseExpression

	class AtlasMathFunction : public AtlasTermBase
	{
	public:

		enum eFunction
		{
			eUnknownFunction	= -1,
			eABS_Function,		// Absolute Value (HAVE EXAMPLES)
			eALOG_Function,		// Common Antilog (base 10)
			eATAN_Function,		// Arc Tangent
			eCOS_Function,		// Cosine
			eEXP_Function,		// Exponential (e^)
			eINT_Function,		// Integer Part of a Truncated Decimal Number (HAVE EXAMPLES)
			eLN_Function,		// Natural Log (Ln A)
			eLOG_Function,		// Common Log (base 10) (HAVE EXAMPLES)
			eSIN_Function,		// Sine
			eSQRT_Function,		// Square Root (HAVE EXAMPLES)
			eTAN_Function		// Tangent
		};

		AtlasMathFunction( ) : m_eFunction( eUnknownFunction ), m_pTermBase( 0 ) { }
		~AtlasMathFunction( ) { GarbageCollect( ); }

		void SetFunction( const eFunction eFunc ) { m_eFunction = eFunc; }
		eFunction GetFunction( void ) const { return m_eFunction; }

		void SetTerm( AtlasTermBase* pTermBase );
		AtlasTermBase* GetTerm( const bool bTransferownership );

		void ToXML( string& strXML, const XML::ElementName eName ) const;

		static eFunction GetFunction( const string& strFunction );

		static const string& GetRawClassName( void ) { return m_strRawClassName; }

	protected:

		eFunction m_eFunction;
		AtlasTermBase* m_pTermBase;

		void GarbageCollect( void )
		{
			if ( 0 != m_pTermBase )
			{
				delete m_pTermBase;
				m_pTermBase = 0;
			}
		}

		static const string m_strRawClassName;

	};  // AtlasMathFunction

	// Atlas Statement Lookups
	static eAtlasStatement GetAtlasStatementEnum( const string& strAtlasStatement );
	static string GetAtlasStatement( const eAtlasStatement eStatement );
	static bool IsElectricalSignalOrientedStatement( const eAtlasStatement eStatement );

	// Atlas Noun Lookups
	static eAtlasNoun GetAtlasNounEnum( const string& strAtlasNoun );
	static string GetAtlasNoun( const eAtlasNoun eNoun );
	static string GetAtlasNounDescription( const eAtlasNoun eNoun );
	static ieee1641::eModel Get1641ModelEnumByAtlasNounEnum( const eAtlasNoun eNoun );
	static ieee1641::eTSF Get1641TSFEnumByAtlasNounEnum( const eAtlasNoun eNoun );
	static ieee1641::eTSF Get1641TSFEnumByAtlasNoun( const string& strAtlasNoun );
	static bool IsElectricalSignalOrientedNoun( const eAtlasNoun eNoun );

	// Atlas Noun Modifier Lookups
	static bool IsAtlasNounModifierEnum( const string& strAtlasNounModifier );
	static AtlasSignalComponent GetAtlasNounModifierEnum( const string& strAtlasNounModifier ) { return GetAtlasNounModifierEnum( strAtlasNounModifier, true ); }
	static string GetAtlasNounModifier( const eAtlasNounModifier eNounModifier );
	static string GetAtlasNounModifierDescription( const eAtlasNounModifier eNounModifier );
	static ieee1641::eModel Get1641ModelEnumByAtlasNounModifierEnum( const eAtlasNounModifier eNounModifier );

	// Atlas Noun Modifier Suffix Lookups
	static eAtlasModifierSuffix GetAtlasSuffixEnum( const string& strAtlasSuffix );
	static string GetAtlasSuffix( const eAtlasModifierSuffix eSuffix );
	static string GetAtlasSuffixDescription( const eAtlasModifierSuffix eSuffix );
	static ieee1641::eQualifier Get1641QualifierEnumByAtlasSuffixEnum( const eAtlasModifierSuffix eSuffix );

	// Atlas Function/Function Characteristics Lookups
	static eAtlasFunction GetAtlasFunctionEnum( const string& strAtlasFunction );
	static ieee1641::eBSC GetAtlasFunctionEnumTo1641BSCEnum( const eAtlasFunction eFunction );
	static string GetAtlasFunction( const eAtlasFunction eFunction );
	static string GetAtlasFunctionDescription( const eAtlasFunction eFunction );
	static ieee1641::eModel Get1641ModelEnumByAtlasFunctionEnum( const eAtlasFunction eFunction );

	// Atlas Specify Type Lookups
	static eAtlasSpecifyType GetAtlasSpecifyTypeEnum( const string& strAtlasSpecifyType );
	static string GetAtlasSpecifyType( const eAtlasSpecifyType eSpecifyType );

	// 1641 BCS enums by Atlas Noun Modifier Lookups
	static ieee1641::eBSC Get1641BSCEnumByAtlasNounModifier( const string& strAtlasNounModifier );
	static ieee1641::eBSC Get1641BSCEnumByAtlasNounModifierEnum( const eAtlasNounModifier eNounModifier );

	// 1641 BCS Attribute enums by Atlas Noun Modifier Lookups
	static ieee1641::eBSCAttribute Get1641BSCAttributeEnumByAtlasNounModifier( const string& strAtlasNounModifier );
	static ieee1641::eBSCAttribute Get1641BSCAttributeEnumByAtlasNounModifierEnum( const eAtlasNounModifier eNounModifier );

	// Atlas Resource Lookups
	static eAtlasResource GetAtlasResoureEnum( const string& strAtlasResource );
	static string GetAtlasResoure( const eAtlasResource eResource );

	// Atlas Require Lookups
	static eAtlasRequire GetAtlasRequireEnum( const string& strAtlasRequire );
	static string GetAtlasRequire( const eAtlasRequire eRequire );

	// Atlas Pin Descriptor Lookups
	static eAtlasPinDescriptor GetAtlasPinDescriptorEnum( const string& strPinDescriptor );
	static string GetAtlasPinDescriptor( const eAtlasPinDescriptor ePinDescriptor );
	static string GetAtlasPinDescriptorDescription( const eAtlasPinDescriptor ePinDescriptor );
	static ieee1641::eBSC Get1641BSCEnumByAtlasPinDescriptorEnum( const eAtlasPinDescriptor ePinDescriptor );
	static ieee1641::eBSCAttribute Get1641BSCAttributeEnumByAtlasPinDescriptorEnum( const eAtlasPinDescriptor ePinDescriptor );

	// Units of Measure Lookups
	static eUnitOfMeasure GetUnitOfMeasureEnumByAlasUnit( const string& strUnitOfMeasure );
	static eUnitOfMeasure GetUnitOfMeasureEnumByUnit( const string& strUnitOfMeasure );
	static string GetAtlasUnitOfMeasure( const eUnitOfMeasure eUnit );
	static string GetUnitOfMeasure( const eUnitOfMeasure eUnit );
	static string GetUnitOfMeasureDescription( const eUnitOfMeasure eUnit );

	// Input/Output Lookups
	static eInputOutput GetAtlasInputOutputEnum( const string& strAtlasInputOutput );
	static string GetAtlasInputOutput( const eInputOutput eIO );

	// Input/Output Attribute Lookups
	static eInputOutputAttribute GetAtlasInputOutputAttributeEnum( const string& strAtlasInputOutputAttribute );
	static string GetAtlasInputOutput( const eInputOutputAttribute eIOAttribute );

	// Data Type Lookups
	static eDataType GetAtlasDataTypeEnum( const string& strAtlasDataType );
	static string GetAtlasDataType( const Atlas::eDataType eType );

	// Evaluation Field Type Lookups
	static eEvaluationFieldType GetAtlasEvaluationFieldTypeEnum( const string& strAtlasEvaluationStatementType );
	static string GetAtlasEvaluationFieldType( const eEvaluationFieldType eType );

	static const string m_UNKNOWN;

protected:

	static const bool m_bInitAll;

	static bool InitAll( void );

	static void InitAtlasVerb( void );
	static void InitAtlasNoun( void );
	static void InitAtlasNounModifier( void );
	static void InitAtlasSuffix( void );
	static void InitAtlasFunction( void );
	static void InitAtlasPinDescriptor( void );
	static void InitAtlasResource( void );
	static void InitAtlasRequire( void );
	static void InitUnitsOfMeasure( void );
	static void InitAtlasInputOutput( void );
	static void InitAtlasInputOutputAttribute( void );
	static void InitAtlasSignalTo1641Signal( void );
	static void InitAtlasDataType( void );
	static void InitAtlasEvaluationFieldType( void );
	static void InitAtlasSpecifyType( void );

	static AtlasSignalComponent GetAtlasNounModifierEnum( const string& strAtlasNounModifier, const bool bFindClosest );

	static map< const string*, eAtlasStatement, AIXMLHelper::cmpPointer > m_mapAtlasStatementToAtlasStatementEnum;
	static map< eAtlasStatement, const string* > m_mapAtlasStatementEnumToAtlasStatement;
	static set< eAtlasStatement > m_setElectricalSignalOrientedStatement;

	static map< const string*, eAtlasNoun, AIXMLHelper::cmpPointer > m_mapAtlasNounToAtlasNounEnum;
	static map< const string*, eAtlasNounModifier, AIXMLHelper::cmpPointer > m_mapAtlasNounModifierToAtlasNounModifierEnum;
	static map< eAtlasNoun, ieee1641::eTSF > m_mapAtlasNounEnumTo1641TSFEnum;
	static set< eAtlasNoun > m_setElectricalSignalOrientedNoun;

	static map< eAtlasNoun, const string* > m_mapAtlasNounEnumToAtlasNoun;
	static map< eAtlasNoun, const string* > m_mapAtlasNounEnumToAtlasNounDescription;
	static map< eAtlasNoun, ieee1641::eModel > m_mapAtlasNounEnumTo1641ModelEnum;
	static map< eAtlasNounModifier, const string* > m_mapAtlasNounModifierEnumToAtlasNounModifier;
	static map< eAtlasNounModifier, const string* > m_mapAtlasNounModifierEnumToAtlasNounModifierDescription;
	static map< eAtlasNounModifier, ieee1641::eModel > m_mapAtlasNounModifierEnumTo1641ModelEnum;
	static map< eAtlasNounModifier, ieee1641::eBSC > m_mapAtlasNounModifierEnumTo1641BSCEnum;
	static map< eAtlasNounModifier, ieee1641::eBSCAttribute > m_mapAtlasNounModifierEnumTo1641BSCAttributeEnum;
	static map< const string*, eAtlasFunction, AIXMLHelper::cmpPointer > m_mapAtlasFunctionToAtlasFunctionEnum;
	static map< eAtlasFunction, const string* > m_mapAtlasFunctionEnumToAtlasFunction;
	static map< eAtlasFunction, const string* > m_mapAtlasFunctionEnumToAtlasFunctionDescription;
	static map< eAtlasFunction, ieee1641::eBSC > m_mapAtlasFunctionEnumTo1641BSCEnum;
	static map< eAtlasFunction, ieee1641::eModel > m_mapAtlasFunctionEnumTo1641ModelEnum;
	static map< const string*, eAtlasModifierSuffix, AIXMLHelper::cmpPointer > m_mapAtlasSuffixToAtlasSuffixEnum;
	static map< eAtlasModifierSuffix, const string* > m_mapAtlasSuffixEnumToAtlasSuffix;
	static map< eAtlasModifierSuffix, const string* > m_mapAtlasSuffixToAtlasSuffixDescription;
	static map< eAtlasModifierSuffix, ieee1641::eQualifier > m_mapAtlasSuffixTo1641Qualifier;

	static map< const string*, eAtlasResource, AIXMLHelper::cmpPointer > m_mapAtlasResourceToAtlasResourceEnum;
	static map< eAtlasResource, const string* > m_mapAtlasResourceEnumToAtlasResource;

	static map< const string*, eAtlasRequire, AIXMLHelper::cmpPointer > m_mapAtlasRequireToAtlasRequireEnum;
	static map< eAtlasRequire, const string* > m_mapAtlasRequireEnumToAtlasRequire;

	static map< const string*, eAtlasPinDescriptor, AIXMLHelper::cmpPointer > m_mapAtlasePinDescriptorToEnum;
	static map< eAtlasPinDescriptor, const string* > m_mapAtlasPinDescriptorEnumToPinDescriptor;
	static map< eAtlasPinDescriptor, const string* > m_mapAtlasPinDescriptorEnumToPinDescriptorDescription;
	static map< eAtlasPinDescriptor, ieee1641::eBSC > m_mapAtlasPinDescriptorEnumTo1641BSCEnum;
	static map< eAtlasPinDescriptor, ieee1641::eBSCAttribute > m_mapAtlasPinDescriptorEnumTo1641BSCAttributeEnum;

	static map< const string*, eUnitOfMeasure, AIXMLHelper::cmpPointer > m_mapAtlasUnitOfMeasureToEnum;
	static map< const string*, eUnitOfMeasure, AIXMLHelper::cmpPointer > m_mapSIUnitOfMeasureToEnum;
	static map< eUnitOfMeasure, const string* > m_mapUnitOfMeasureEnumToAtlasUnitOfMeasure;
	static map< eUnitOfMeasure, const string* > m_mapUnitOfMeasureEnumToSIUnitOfMeasure;
	static map< eUnitOfMeasure, const string* > m_mapUnitOfMeasureEnumToUnitOfMeasureDescription;

	static map< const string*, eAtlasSpecifyType, AIXMLHelper::cmpPointer > m_mapAtlasSpecifyTypeToAtlasSpecifyTypeEnum;
	static map< eAtlasSpecifyType, const string* > m_mapAtlasSpecifyTypeEnumToAtlasSpecifyType;

	static map< const string*, eInputOutput, AIXMLHelper::cmpPointer > m_mapAtlasInputOutputToAtlasInputOutputEnum;
	static map< eInputOutput, const string* > m_mapAtlasInputOutputEnumToAtlasInputOutput;

	static map< const string*, eInputOutputAttribute, AIXMLHelper::cmpPointer > m_mapAtlasInputOutputAttributeToAtlasInputOutputAttributeEnum;
	static map< eInputOutputAttribute, const string* > m_mapAtlasInputOutputAttributeEnumToAtlasInputOutputAttribute;

	static map< const string*, eDataType, AIXMLHelper::cmpPointer > m_mapAtlasDataTypeToAtlasDataTypeEnum;
	static map< eDataType, const string* > m_mapAtlasDataTypeEnumToAtlasDataType;

	static map< const string*, eEvaluationFieldType, AIXMLHelper::cmpPointer > m_mapAtlasEvaluationFieldTypeToAtlasEvaluationFieldTypeEnum;
	static map< eEvaluationFieldType, const string* > m_mapAtlasEvaluationFieldTypeEnumToAtlasEvaluationFieldType;

	struct ANI  // [A]tlas [N]oun [I]nformation
	{
		ANI( const string& strAtlasNoun, const ieee1641::eTSF eTSF, const ieee1641::eModel eModel, const bool bElectricalSignalOriented, const string& strAtlasNounDescription ) :
			m_strAtlasNoun( strAtlasNoun ),
			m_strAtlasNounDescription( strAtlasNounDescription ),
			m_eTSF( eTSF ),
			m_eModel( eModel ),
			m_bElectricalSignalOriented( bElectricalSignalOriented )
		{ }

		string m_strAtlasNoun;
		string m_strAtlasNounDescription;
		ieee1641::eModel m_eModel;
		ieee1641::eTSF m_eTSF;
		bool m_bElectricalSignalOriented;
	};
	static const ANI m_arrayAtlasNoun[ ];

	struct ASTI  // [A]tlas [ST]atement [I]nformation
	{
		ASTI( const string& strAtlasStatement, const bool bElectricalSignalOriented ) :
			m_strAtlasStatement( strAtlasStatement ),
			m_bElectricalSignalOriented( bElectricalSignalOriented )
		{ }

		string m_strAtlasStatement;
		bool m_bElectricalSignalOriented;
	};
	static const ASTI m_arrayAtlasVerb[ ];

	struct AMNI  // [A]tlas [N]oun [M]odifier [I]nformation
	{
		AMNI( const string& strAtlasNounModifier, const ieee1641::eBSC eBCS, const ieee1641::eBSCAttribute eBCSAttribute, const ieee1641::eModel eModel, const string& strAtlasNounModifierDescription ) :
			m_strAtlasNounModifier( strAtlasNounModifier ),
			m_eBCS( eBCS ),
			m_eBCSAttribute( eBCSAttribute ),
			m_eModel( eModel ),
			m_strAtlasNounModifierDescription( strAtlasNounModifierDescription )
		{ }

		string m_strAtlasNounModifier;
		string m_strAtlasNounModifierDescription;
		ieee1641::eModel m_eModel;
		ieee1641::eBSC m_eBCS;
		ieee1641::eBSCAttribute m_eBCSAttribute;
	};
	static const AMNI m_arrayAtlasNounModifier[ ];

	struct ASI  // [A]tlas [S]uffix [I]nformation
	{
		ASI( const string& strAtlasSuffix, const ieee1641::eQualifier eQualifier, const string& strAtlasSuffixDescription ) :
			m_strAtlasSuffix( strAtlasSuffix ),
			m_eQualifier( eQualifier ),
			m_strAtlasSuffixDescription( strAtlasSuffixDescription )
		{ }

		string m_strAtlasSuffix;
		string m_strAtlasSuffixDescription;
		ieee1641::eQualifier m_eQualifier;
	};
	static const ASI m_arrayAtlasModiferSuffix[ ];

	struct AFI // [A]tlas [F]unction [I]nformation
	{
		AFI( const string& strAtlasFunction, const ieee1641::eBSC eBSC, const ieee1641::eModel eModel, const string& strAtlasFunctionDescription ) :
			m_strAtlasFunction( strAtlasFunction ),
			m_eBSC( eBSC ),
			m_eModel( eModel ),
			m_strAtlasFunctionDescription( strAtlasFunctionDescription )
		{ }

		string m_strAtlasFunction;
		string m_strAtlasFunctionDescription;
		ieee1641::eBSC m_eBSC;
		ieee1641::eModel m_eModel;
	};
	static const AFI m_arrayAtlasFunction[ ];

	struct AUMI  // [A]tlas [U]nit of [M]easure [I]nformation
	{
		AUMI( const string& strAtlasUnitOfMeasure, const string& strInternationalSystemUnitOfMeasure, const string& strUnitOfMeasureDescription ) :
			m_strAtlasUnitOfMeasure( strAtlasUnitOfMeasure ),
			m_strInternationalSystemUnitOfMeasure( strInternationalSystemUnitOfMeasure ),
			m_strUnitOfMeasureDescription( strUnitOfMeasureDescription )
		{ }

		string m_strAtlasUnitOfMeasure;
		string m_strInternationalSystemUnitOfMeasure; // a.k.a. SI (Système International / IEEE 260.1 )
		string m_strUnitOfMeasureDescription;
	};
	static const AUMI m_arrayUnitsOfMeasure[ ]; 

	struct APDI // [A]tlas [P]in [D]escriptor [I]nformation
	{
		APDI( const string& strAtlasPinDescriptor, const ieee1641::eBSC eBCS, const ieee1641::eBSCAttribute eBCSAttribute, const ieee1641::eModel eModel, const string& strAtlasPinDescriptorDescription ) :
			m_strAtlasPinDescriptor( strAtlasPinDescriptor ),
			m_strAtlasPinDescriptorDescription( strAtlasPinDescriptorDescription ),
			m_eBCS( eBCS ),
			m_eBCSAttribute( eBCSAttribute ),
			m_eModel( eModel )
		{ }

		string m_strAtlasPinDescriptor;
		string m_strAtlasPinDescriptorDescription;
		ieee1641::eModel m_eModel;
		ieee1641::eBSC m_eBCS;
		ieee1641::eBSCAttribute m_eBCSAttribute;
	};
	static const APDI m_arrayAtlasPinDescriptor[ ];

	struct AS1S // [A]tlas [S]ignal to [1]641 [S]ignal
	{
		AS1S( const eAtlasNoun eNoun, const eAtlasNounModifier eNounModifier, const ieee1641::eBSC eBCS, const ieee1641::eBSCAttribute eBCSAttribute ) :
			m_eAtlasNoun( eNoun ),
			m_eAtlasNounModifier( eNounModifier ),
			m_eBCS( eBCS ),
			m_eBCSAttribute( eBCSAttribute )
		{ }

		eAtlasNoun m_eAtlasNoun;
		eAtlasNounModifier m_eAtlasNounModifier;
		ieee1641::eBSC m_eBCS;
		ieee1641::eBSCAttribute m_eBCSAttribute;
	};
	static const AS1S m_arrayAtlasSignalTo1641Signal[ ];
	static const unsigned int m_uiAtlasSignalCount;

	static const string m_arrayAtlasResource[ ];
	static const string m_arrayAtlasRequire[ ];
	static const string m_arrayAtlasInputOutput[ ];
	static const string m_arrayAtlasInputOutputAttribute[ ];
	static const string m_arrayAtlasDataType[ ];
	static const string m_arrayAtlasEvaluationFieldType[ ];
	static const string m_arrayAtlasSpecifyType[ ];

	class AtlasSignal
	{
	public:

		AtlasSignal( ) { Init( ); }
		AtlasSignal( const AtlasSignal& other ) { Init( ); operator = ( other ); }
		AtlasSignal& operator = ( const AtlasSignal& other )
		{
			if ( this != &other )
			{
				m_eAtlasNoun	= other.m_eAtlasNoun;
				m_e1641TSF = other.m_e1641TSF;
				m_mapNM_1641 = other.m_mapNM_1641;
			}

			return *this;
		}

		const pair< ieee1641::eBSC, ieee1641::eBSCAttribute >* Get1641Info( const eAtlasNounModifier eNounModifier ) const
		{
			const pair< ieee1641::eBSC, ieee1641::eBSCAttribute >* ppr = 0;

			const map< eAtlasNounModifier, pair< ieee1641::eBSC, ieee1641::eBSCAttribute > >::const_iterator it = m_mapNM_1641.find( eNounModifier );
			const map< eAtlasNounModifier, pair< ieee1641::eBSC, ieee1641::eBSCAttribute > >::const_iterator itEnd = m_mapNM_1641.end( );
		
			if ( itEnd != it )
			{
				ppr = &( it->second );
			}

			return ppr;
		}

		void Init( void )
		{
			m_eAtlasNoun = eUnknownAtlasNoun;
			m_e1641TSF = ieee1641::eUnknownTSF;
			m_mapNM_1641.clear( );
		}

		eAtlasNoun m_eAtlasNoun;
		ieee1641::eTSF m_e1641TSF;
		map< eAtlasNounModifier, pair< ieee1641::eBSC, ieee1641::eBSCAttribute > > m_mapNM_1641;

	protected:

	};  // class AtlasSignal

	static map< eAtlasNoun, const AtlasSignal > m_mapAtlasSignalTo1641Signal;

	static const AtlasSignal* GetAtlasSignal( const eAtlasNoun eNoun )
	{
		const AtlasSignal* pAtlasSignal = 0;

		const map< eAtlasNoun, const AtlasSignal >::const_iterator it = m_mapAtlasSignalTo1641Signal.find( eNoun );
		const map< eAtlasNoun, const AtlasSignal >::const_iterator itEnd = m_mapAtlasSignalTo1641Signal.end( );
	
		if ( itEnd != it )
		{
			pAtlasSignal = &( it->second );
		}

		return pAtlasSignal;
	}
};
