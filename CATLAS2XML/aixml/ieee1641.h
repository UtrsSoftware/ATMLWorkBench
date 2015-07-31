/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

#pragma once

#include <string>
#include <map>

#include "helper.h"

using namespace std;

class ieee1641
{
public:

	enum eModel
	{
		eUnknownModel	= -1,
		eStandardModel	= 0x01,
		eCassModel		= 0x02
	};

	enum eTSF
	{
		eUnknownTSF = -1,
		eAC_SIGNAL,
		eAM_SIGNAL,
		eDC_SIGNAL,
		eDIGITAL_PARALLEL,
		eDIGITAL_SERIAL,
		eDIGITAL_TEST,
		eDME_INTERROGATION,
		eDME_RESPONSE,
		eFM_SIGNAL,
		eILS_GLIDE_SLOPE,
		eILS_LOCALIZER,
		eILS_MARKER,
		ePM_SIGNAL,
		ePULSED_AC_SIGNAL,
		ePULSED_AC_TRAIN,
		ePULSED_DC_SIGNAL,
		ePULSED_DC_TRAIN,
		eRADAR_RX_SIGNAL,
		eRADAR_TX_SIGNAL,
		eRAMP_SIGNAL,
		eRANDOM_NOISE,
		eRESOLVER,
		eRS_232e,
		eSQUARE_WAVE,
		eSSR_INTERROGATION,
		eSSR_RESPONSE,
		eSTEP_SIGNAL,
		eSUP_CAR_SIGNAL,
		eSYNCHRO,
		eTACAN,
		eTRIANGULAR_WAVE_SIGNAL,
		eVOR,

		// Begin: Not in 1641 standard
		eIMPEDANCE,
		ePULSE_MODULATED_SIGNAL,
		// End: Not in 1641 standard

		// Derived values for Atlas relationships only
		eSSR_COMBINED,
		eDME_COMBINED,
		eILS_COMBINED,
		eDIGITAL_COMBINED,
		eRADAR_COMBINED

		// NOTE: The ending enum is used in FOR loops, make sure to update loops
	};

	enum eBSC
	{
		eUnknownBSC = -1,
		eAM,
		eAndEvent,
		eAttenuator,
		eAverage,
		eBandPass,
		eBSC_Channels,
		eClock,
		eConstant,
		eCounter,
		eDecode,
		eDiff,
		eDigitalBus,
		eE,
		eEncode,
		eEventCount,
		eEventedEvent,
		eExponential,
		eFFT,
		eFilter,
		eFM,
		eFourWire,
		eFourWireResolver,
		eHighPass,
		eInstantaneous,
		eInterval,
		eInverse,
		eBSC_Limit,
		eLn,
		eLoad,
		eLowPass,
		eMaxInstantaneous,
		eMeasure,
		eMinInstantaneous,
		eModulator,
		eNegate,
		eNoise,
		eNonElectrical,
		eNotEvent,
		eNotch,
		eOrEvent,
		ePM,
		eParallelDigital,
		ePeak,
		ePeakNeg,
		ePeakPos,
		ePeakToPeak,
		ePeriodic,
		eProbabilityEvent,
		eProduct,
		ePulseDefn,
		ePulseDefns,
		ePulseTrain,
		ePulsedEvent,
		eRMS,
		eRamp,
		eSelectCase,
		eSelectIf,
		eSerialData,
		eSerialDigital,
		eSeries,
		eSignalDelay,
		eSinglePhase,
		eSingleRamp,
		eSingleTrapezoid,
		eSinusoid,
		eSquareWave,
		eStep,
		eSum,
		eSynchroResolver,
		eeBSC_TSF,
		eThreePhaseDelta,
		eThreePhaseSynchro,
		eThreePhaseWye,
		eThreeWireComp,
		eTimeInterval,
		eTimedEvent,
		eTrapezoid,
		eTriangle,
		eTwoPhase,
		eTwoWire,
		eTwoWireComp,
		eWaveformRamp,
		eWaveformStep,
		eXOrEvent,

		// Derived values for Atlas relationships only
		eBandpass_Notch,
		eSquareWave_Triangle,
		eTrapezoid_SingleTrapezoid,
		eSinusoid_Modulator_Filter,
		eAM_FM_PM,
		ePeriodic_TimedEvent,
		eSerialDigital_ParallelDigital,
		eTwoWire_FourWire,
		eTwoWire_ThreeWireComp_FourWire,
		eSinglePhase_TwoPhase_ThreePhaseDelta_ThreePhaseWye,
		eTwoPhase_ThreePhaseDelta_ThreePhaseWye,
		eThreePhaseDelta_ThreePhaseWye,
		eSinglePhase_TwoPhase_ThreePhaseWye,
		eTwoWireComp_ThreeWireComp
		
		// NOTE: The ending enum is used in FOR loops, make sure to update loops
	};

	enum eBSCAttribute
	{
		eUnknownBSCAttribute = -1,
		eA,
		eAcceleration,
		eAc_ampl,
		eAccn,
		eAmpl,
		eAmplitude,
		eAngle,
		eAngle_rate,
		eAtten,
		eB,
		eBaud_rate,
		eBearing,
		eC,
		eCar_ampl,
		eCar_freq,
		eCarrier,
		eCarrierFrequency,
		eCenterFrequency,
		eBSCAttribute_Channels,
		eChannelWidth,
		eClock_period,
		eComp,
		eConn,
		eData,
		eData_bits,
		eData_value,
		eData_word,
		eDatatype,
		eDc_ampl,
		eDc_offset,
		eDelay,
		eDuration,
		eDutyCycle,
		eEncoding,
		eFallTime,
		eFlow_control,
		eFreq,
		eFreq_dev,
		eFrequency,
		eFrequencyBand,
		eFrequencyDeviation,
		eFrom,
		eGain,
		eGate,
		eHi,
		eHiRef,
		eIn,
		eInt_freq,
		eInt_rate,
		eBSCAttribute_Limit,
		eLo,
		eLogic_H_value,
		eLogic_L_value,
		eLogic_one_value,
		eLogic_zero_value,
		eLoRef,
		eMarker_freq,
		eMod_ampl,
		eMod_depth,
		eMod_freq,
		eMod_index,
		eMode,
		eModIndex,
		eN,
		eName,
		eNinety_level,
		eOnefifty_level,
		eP_delay,
		eP_duration,
		eP_repetition,
		eP3_level,
		eP3_start,
		eParity,
		ePassBandRipple,
		ePeriod,
		ePhase,
		ePhaseDeviation,
		ePhase_dev,
		ePins,
		ePinsGate,
		ePinsIn,
		ePinsOut,
		ePinsSync,
		ePrf,
		eProbability,
		ePulse_train,
		ePulseClass,
		ePulses,
		ePulseWidth,
		eR1,
		eR2,
		eR3,
		eR4,
		eRange,
		eRange_accn,
		eRange_rate,
		eRate,
		eReactance,
		eReftype,
		eRepetition,
		eReply_eff,
		eResistance,
		eResp_freq,
		eResp_H_value,
		eResp_L_value,
		eRise_time,
		eRiseTime,
		eRollOff,
		eS1,
		eS2,
		eS3,
		eS4,
		eScriptEngine,
		eSeed,
		eSls_dev,
		eSls_level,
		eStart,
		eStart_time,
		eStim_H_value,
		eStim_L_value,
		eStop_bits,
		eStopBandRipple,
		eSusceptance,
		eSync,
		eTo,
		eTrans_ratio,
		eTrue,
		eType,
		eVia,
		eWidth,
		eX,
		eY,
		eZ,
		eZero_index,
		eBandwidth,
		eBurst,
		eCar_harmonics,
		eCurrent,
		eCurrent_lmt,
		eOvershoot,
		ePower,
		ePreshoot,
		eQ_factor,
		eRef_volt,
		eSpacing,
		eSweep_time,
		eUndershoot,
		eVolt_lmt,
		
		// Derived values for Atlas relationships only
		eFrequency_CarrierFrequency_CenterFrequency

		// NOTE: The ending enum is used in FOR loops, make sure to update loops
	};

	enum eQualifier
	{
		eUnknownQualifier = -1,
		eTrmsQualifier,
		ePk_PkQualifier,
		ePkQualifier,
		ePk_PosQualifier,
		ePk_NegQualifier,
		eAvQualifier,
		eInstQualifier,
		eInst_MaxQualifier,
		eInst_MinQualifier

		// NOTE: The ending enum is used in FOR loops, make sure to update loops
	};

	static eTSF GetTSFEnum( const string& strTSF );
	static string GetTSF( const eTSF eTSF );
	static eBSC GetBSCEnum( const string& strBSC );
	static string GetBSC( const eBSC eBSC );
	static eQualifier GetQualifierEnum( const string& strQualifier );
	static string GetQualifier( const eQualifier eQualifier );
	static eBSCAttribute GetBSCAttributeEnum( const string& strBSCAttribute );
	static string GetBSCAttribute( const eBSCAttribute eBSCAttribute );
	static string GetModel( const eModel eModel );

	static const string m_UNKNOWN;

protected:

	static const bool m_bInitAll;

	static bool InitAll( void );

	static void InitTSF( void );
	static void InitBSC( void );
	static void InitBSCAttribute( void );
	static void InitQualifier( void );

	static map< const string*, eQualifier, AIXMLHelper::cmpPointer > m_mapQualifierToEnum;
	static map< eQualifier, const string* > m_mapTSFEnumToQualifier;

	static map< const string*, eBSCAttribute, AIXMLHelper::cmpPointer > m_mapBSCAttributeToEnum;
	static map< eBSCAttribute, const string* > m_mapBSCAttributeEnumToBSCAttribute;

	static map< const string*, eBSC, AIXMLHelper::cmpPointer > m_mapBSCToEnum;
	static map< eBSC, const string* > m_mapBSCEnumToBSC;

	static map< const string*, eTSF, AIXMLHelper::cmpPointer > m_mapTSFToEnum;
	static map< eTSF, const string* > m_mapTSFEnumToTSF;

	static const string m_arrayTSF[ ];
	static const string m_arrayBSC[ ];
	static const string m_arrayBSCAttribute[ ];
	static const string m_arrayQualifier[ ];
};