/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

#include "ieee1641.h"

#if ( _DEBUG ) && ( WIN32 )
	#define WINVER 0x0600
	#include <afx.h>
	#define new DEBUG_NEW
	#undef THIS_FILE
	static char BASED_CODE THIS_FILE[ ] = __FILE__;
#endif

map< const string*, ieee1641::eQualifier, AIXMLHelper::cmpPointer > ieee1641::m_mapQualifierToEnum;
map< ieee1641::eQualifier, const string* > ieee1641::m_mapTSFEnumToQualifier;
map< const string*, ieee1641::eBSCAttribute, AIXMLHelper::cmpPointer > ieee1641::m_mapBSCAttributeToEnum;
map< ieee1641::eBSCAttribute, const string* > ieee1641::m_mapBSCAttributeEnumToBSCAttribute;
map< const string*, ieee1641::eBSC, AIXMLHelper::cmpPointer > ieee1641::m_mapBSCToEnum;
map< ieee1641::eBSC, const string* > ieee1641::m_mapBSCEnumToBSC;
map< const string*, ieee1641::eTSF, AIXMLHelper::cmpPointer > ieee1641::m_mapTSFToEnum;
map< ieee1641::eTSF, const string* > ieee1641::m_mapTSFEnumToTSF;
const string ieee1641::m_UNKNOWN( "UNKNOWN" );

const string ieee1641::m_arrayBSC[ ] = 
{
	"AM",
	"AndEvent",
	"Attenuator",
	"Average",
	"BandPass",
	"Channels",
	"Clock",
	"Constant",
	"Counter",
	"Decode",
	"Diff",
	"DigitalBus",
	"E",
	"Encode",
	"EventCount",
	"EventedEvent",
	"Exponential",
	"FFT",
	"Filter",
	"FM",
	"FourWire",
	"FourWireResolver",
	"HighPass",
	"Instantaneous",
	"Interval",
	"Inverse",
	"Limit",
	"Ln",
	"Load",
	"LowPass",
	"MaxInstantaneous",
	"Measure",
	"MinInstantaneous",
	"Modulator",
	"Negate",
	"Noise",
	"NonElectrical",
	"NotEvent",
	"Notch",
	"OrEvent",
	"PM",
	"ParallelDigital",
	"Peak",
	"PeakNeg",
	"PeakPos",
	"PeakToPeak",
	"Periodic",
	"ProbabilityEvent",
	"Product",
	"PulseDefn",
	"PulseDefns",
	"PulseTrain",
	"PulsedEvent",
	"RMS",
	"Ramp",
	"SelectCase",
	"SelectIf",
	"SerialData",
	"SerialDigital",
	"Series",
	"SignalDelay",
	"SinglePhase",
	"SingleRamp",
	"SingleTrapezoid",
	"Sinusoid",
	"SquareWave",
	"Step",
	"Sum",
	"SynchroResolver",
	"TSF",
	"ThreePhaseDelta",
	"ThreePhaseSynchro",
	"ThreePhaseWye",
	"ThreeWireComp",
	"TimeInterval",
	"TimedEvent",
	"Trapezoid",
	"Triangle",
	"TwoPhase",
	"TwoWire",
	"TwoWireComp",
	"WaveformRamp",
	"WaveformStep",
	"XOrEvent",

	// Derived values for Atlas relationships only
	string( m_arrayBSC[ eBandPass ] + "," + m_arrayBSC[ eNotch ] ),
	string( m_arrayBSC[ eSquareWave ] + "," + m_arrayBSC[ eTriangle ] ),
	string( m_arrayBSC[ eTrapezoid ] + "," + m_arrayBSC[ eSingleTrapezoid ] ),
	string( m_arrayBSC[ eSinusoid ] + "," + m_arrayBSC[ eModulator ] + "," + m_arrayBSC[ eFilter ] ),
	string( m_arrayBSC[ eAM ] + "," + m_arrayBSC[ eFM ] + "," + m_arrayBSC[ ePM ] ),
	string( m_arrayBSC[ ePeriodic ] + "," + m_arrayBSC[ eTimedEvent ] ),
	string( m_arrayBSC[ eSerialDigital ] + "," + m_arrayBSC[ eParallelDigital ] ),
	string( m_arrayBSC[ eTwoWire ] + "," + m_arrayBSC[ eFourWire ] ),
	string( m_arrayBSC[ eTwoWire ] + "," + m_arrayBSC[ eThreeWireComp ] + "," + m_arrayBSC[ eFourWire ] ),
	string( m_arrayBSC[ eSinglePhase ] + "," + m_arrayBSC[ eTwoPhase ] + "," + m_arrayBSC[ eThreePhaseDelta ] + "," + m_arrayBSC[ eThreePhaseWye ] ),
	string( m_arrayBSC[ eTwoPhase ] + "," + m_arrayBSC[ eThreePhaseDelta ] + "," + m_arrayBSC[ eThreePhaseWye ] ),
	string( m_arrayBSC[ eThreePhaseDelta ] + "," + m_arrayBSC[ eThreePhaseWye ] ),
	string( m_arrayBSC[ eSinglePhase ] + "," + m_arrayBSC[ eTwoPhase ] + "," + m_arrayBSC[ eThreePhaseWye ] ),
	string( m_arrayBSC[ eTwoWireComp ] + "," + m_arrayBSC[ eThreeWireComp ] )
};

const string ieee1641::m_arrayBSCAttribute[ ] = 
{
	"a",
	"acceleration",
	"ac_ampl",
	"accn",
	"ampl",
	"amplitude",
	"angle",
	"angle_rate",
	"atten",
	"b",
	"baud_rate",
	"bearing",
	"c",
	"car_ampl",
	"car_freq",
	"Carrier",
	"carrierFrequency",
	"centerFrequency",
	"channels",
	"channelWidth",
	"clock_period",
	"comp",
	"Conn",
	"data",
	"data_bits",
	"data_value",
	"data_word",
	"datatype",
	"dc_ampl",
	"dc_offset",
	"delay",
	"duration",
	"duty_cycle",	// dutyCycle
	"encoding",
	"fall_time",	// fallTime
	"flow_control",
	"freq",
	"freq_dev",
	"frequency",
	"frequencyBand",
	"frequencyDeviation",
	"from",
	"gain",
	"Gate",
	"hi",
	"hiRef",
	"In",
	"int_freq",
	"int_rate",
	"limit",
	"lo",
	"logic_H_value",
	"logic_L_value",
	"logic_one_value",
	"logic_zero_value",
	"loRef",
	"marker_freq",
	"mod_ampl",
	"mod_depth",
	"mod_freq",
	"mod_index",
	"mode",
	"modIndex",
	"n",
	"name",
	"ninety_level",
	"onefifty_level",
	"p_delay",
	"p_duration",
	"p_repetition",
	"p3_level",
	"p3_start",
	"parity",
	"passBandRipple",
	"period",
	"phase",
	"phaseDeviation",
	"phase_dev",
	"pins",
	"pinsGate",
	"pinsIn",
	"pinsOut",
	"pinsSync",
	"prf",
	"probability",
	"pulse_train",
	"pulseClass",
	"pulses",
	"pulseWidth",
	"r1",
	"r2",
	"r3",
	"r4",
	"range",
	"range_accn",
	"range_rate",
	"rate",
	"reactance",
	"reftype",
	"repetition",
	"reply_eff",
	"resistance",
	"resp_freq",
	"resp_H_value",
	"resp_L_value",
	"rise_time",
	"riseTime",
	"rollOff",
	"s1",
	"s2",
	"s3",
	"s4",
	"scriptEngine",
	"seed",
	"sls_dev",
	"sls_level",
	"start",
	"start_time",
	"stim_H_value",
	"stim_L_value",
	"stop_bits",
	"stopBandRipple",
	"susceptance",
	"Sync",
	"to",
	"trans_ratio",
	"true",
	"type",
	"via",
	"width",
	"x",
	"y",
	"z",
	"zero_index",

	// Not 1n 1641, added to support Atlas mappings
	"bandwidth",
	"burst",
	"car_harmonics",
	"current",
	"current_lmt",
	"overshoot",
	"power",
	"preshoot",
	"q_factor",
	"ref_volt",
	"spacing",
	"sweep_time",
	"undershoot",
	"volt_lmt",

	// Derived values for Atlas relationships only
	string( m_arrayBSCAttribute[ eFrequency ] + "," + m_arrayBSCAttribute[ eCarrierFrequency ] + "," + m_arrayBSCAttribute[ eCenterFrequency ] ),
};

const string ieee1641::m_arrayQualifier[ ] = 
{
	"trms",
	"pk_pk",
	"pk",
	"pk_pos",
	"pk_neg",
	"av",
	"inst",
	"inst_max",
	"inst_min"
};

const string ieee1641::m_arrayTSF[ ] = 
{
	"AC_SIGNAL",
	"AM_SIGNAL",
	"DC_SIGNAL",
	"DIGITAL_PARALLEL",
	"DIGITAL_SERIAL",
	"DIGITAL_TEST",
	"DME_INTERROGATION",
	"DME_RESPONSE",
	"FM_SIGNAL",
	"ILS_GLIDE_SLOPE",
	"ILS_LOCALIZER",
	"ILS_MARKER",
	"PM_SIGNAL",
	"PULSED_AC_SIGNAL",
	"PULSED_AC_TRAIN",
	"PULSED_DC_SIGNAL",
	"PULSED_DC_TRAIN",
	"RADAR_RX_SIGNAL",
	"RADAR_TX_SIGNAL",
	"RAMP_SIGNAL",
	"RANDOM_NOISE",
	"RESOLVER",
	"RS_232",
	"SQUARE_WAVE",
	"SSR_INTERROGATION",
	"SSR_RESPONSE",
	"STEP_SIGNAL",
	"SUP_CAR_SIGNAL",
	"SYNCHRO",
	"TACAN",
	"TRIANGULAR_WAVE_SIGNAL",
	"VOR",
	"IMPEDANCE",
	"PULSE_MODULATED_SIGNAL",

	// Derived values for Atlas relationships only
	string( m_arrayTSF[ eSSR_INTERROGATION ] + "," + m_arrayTSF[ eSSR_RESPONSE ] ),
	string( m_arrayTSF[ eDME_INTERROGATION ] + "," + m_arrayTSF[ eDME_RESPONSE ] ),
	string( m_arrayTSF[ eILS_GLIDE_SLOPE ] + "," + m_arrayTSF[ eILS_LOCALIZER ] + "," + m_arrayTSF[ eILS_MARKER ] ),
	string( m_arrayTSF[ eDIGITAL_PARALLEL ] + "," + m_arrayTSF[ eDIGITAL_SERIAL ] ),
	string( m_arrayTSF[ eRADAR_RX_SIGNAL ] + "," + m_arrayTSF[ eRADAR_TX_SIGNAL ] )
};

// *** KEEP THIS LAST FOR ALL STATIC INITIALIZERS ****
const bool ieee1641::m_bInitAll = ieee1641::InitAll( );

bool ieee1641::InitAll( void )
{
	InitTSF( );
	InitBSC( );
	InitBSCAttribute( );
	InitQualifier( );

	return true;
}

void ieee1641::InitQualifier( void )
{
	const int iMax = ( eInst_MinQualifier + 1 );

	for ( int i = 0; i < iMax; ++i )
	{
		m_mapQualifierToEnum.insert( make_pair( &m_arrayQualifier[ i ], ( eQualifier ) i ) );
		m_mapTSFEnumToQualifier.insert( make_pair( ( eQualifier ) i, &m_arrayQualifier[ i ] ) );
	}
}

void ieee1641::InitBSCAttribute( void )
{
	const int iMax = ( eFrequency_CarrierFrequency_CenterFrequency + 1 );

	for ( int i = 0; i < iMax; ++i )
	{
		m_mapBSCAttributeToEnum.insert( make_pair( &m_arrayBSCAttribute[ i ], ( eBSCAttribute ) i ) );
		m_mapBSCAttributeEnumToBSCAttribute.insert( make_pair( ( eBSCAttribute ) i, &m_arrayBSCAttribute[ i ] ) );
	}
}

void ieee1641::InitBSC( void )
{
	const int iMax = ( eTwoWireComp_ThreeWireComp + 1 );

	for ( int i = 0; i < iMax; ++i )
	{
		m_mapBSCToEnum.insert( make_pair( &m_arrayBSC[ i ], ( eBSC ) i ) );
		m_mapBSCEnumToBSC.insert( make_pair( ( eBSC ) i, &m_arrayBSC[ i ] ) );
	}
}

void ieee1641::InitTSF( void )
{
	const int iMax = ( eRADAR_COMBINED + 1 );

	for ( int i = 0; i < iMax; ++i )
	{
		m_mapTSFToEnum.insert( make_pair( &m_arrayTSF[ i ], ( eTSF ) i ) );
		m_mapTSFEnumToTSF.insert( make_pair( ( eTSF ) i, &m_arrayTSF[ i ] ) );
	}
}

ieee1641::eTSF ieee1641::GetTSFEnum( const string& strTSF )
{
	eTSF e = eUnknownTSF;

	const map< const string*, eTSF, AIXMLHelper::cmpPointer >::const_iterator it = m_mapTSFToEnum.find( &strTSF );
	const map< const string*, eTSF, AIXMLHelper::cmpPointer >::const_iterator itEnd = m_mapTSFToEnum.end( );

	if ( itEnd != it )
	{
		e = it->second;
	}
	
	return e;
}

string ieee1641::GetTSF( const ieee1641::eTSF eTSF )
{
	string strTSF( m_UNKNOWN );

	const map< ieee1641::eTSF, const string* >::const_iterator it = m_mapTSFEnumToTSF.find( eTSF );
	const map< ieee1641::eTSF, const string* >::const_iterator itEnd = m_mapTSFEnumToTSF.end( );

	if ( itEnd != it )
	{
		strTSF = *( it->second );
	}

	return strTSF;
}

ieee1641::eBSC ieee1641::GetBSCEnum( const string& strBSC )
{
	eBSC e = eUnknownBSC;

	const map< const string*, eBSC, AIXMLHelper::cmpPointer >::const_iterator it = m_mapBSCToEnum.find( &strBSC );
	const map< const string*, eBSC, AIXMLHelper::cmpPointer >::const_iterator itEnd = m_mapBSCToEnum.end( );

	if ( itEnd != it )
	{
		e = it->second;
	}
	
	return e;
}

string ieee1641::GetBSC( const ieee1641::eBSC eBSC )
{
	string strBSC( m_UNKNOWN );

	const map< ieee1641::eBSC, const string* >::const_iterator it = m_mapBSCEnumToBSC.find( eBSC );
	const map< ieee1641::eBSC, const string* >::const_iterator itEnd = m_mapBSCEnumToBSC.end( );

	if ( itEnd != it )
	{
		strBSC = *( it->second );
	}

	return strBSC;
}

ieee1641::eQualifier ieee1641::GetQualifierEnum( const string& strQualifier )
{
	eQualifier e = eUnknownQualifier;

	const map< const string*, eQualifier, AIXMLHelper::cmpPointer >::const_iterator it = m_mapQualifierToEnum.find( &strQualifier );
	const map< const string*, eQualifier, AIXMLHelper::cmpPointer >::const_iterator itEnd = m_mapQualifierToEnum.end( );

	if ( itEnd != it )
	{
		e = it->second;
	}
	
	return e;
}

string ieee1641::GetQualifier( const ieee1641::eQualifier eQualifier )
{
	string strQualifier( m_UNKNOWN );

	const map< ieee1641::eQualifier, const string* >::const_iterator it = m_mapTSFEnumToQualifier.find( eQualifier );
	const map< ieee1641::eQualifier, const string* >::const_iterator itEnd = m_mapTSFEnumToQualifier.end( );

	if ( itEnd != it )
	{
		strQualifier = *( it->second );
	}

	return strQualifier;
}

ieee1641::eBSCAttribute ieee1641::GetBSCAttributeEnum( const string& strBSCAttribute )
{
	eBSCAttribute e = eUnknownBSCAttribute;

	const map< const string*, eBSCAttribute, AIXMLHelper::cmpPointer >::const_iterator it = m_mapBSCAttributeToEnum.find( &strBSCAttribute );
	const map< const string*, eBSCAttribute, AIXMLHelper::cmpPointer >::const_iterator itEnd = m_mapBSCAttributeToEnum.end( );

	if ( itEnd != it )
	{
		e = it->second;
	}
	
	return e;
}

string ieee1641::GetBSCAttribute( const ieee1641::eBSCAttribute eBSCAttribute )
{
	string strBSCAttribute( m_UNKNOWN );

	const map< ieee1641::eBSCAttribute, const string* >::const_iterator it = m_mapBSCAttributeEnumToBSCAttribute.find( eBSCAttribute );
	const map< ieee1641::eBSCAttribute, const string* >::const_iterator itEnd = m_mapBSCAttributeEnumToBSCAttribute.end( );

	if ( itEnd != it )
	{
		strBSCAttribute = *( it->second );
	}

	return strBSCAttribute;
}

string ieee1641::GetModel( const eModel eModel )
{
	const string strStandard( "standard" );
	const string strCASS( "cass" );
	string strModel( m_UNKNOWN );

	switch ( eModel )
	{
		case eStandardModel:
			strModel = strStandard;
			break;

		case eCassModel:
			strModel = strCASS;
			break;
	}

	return strModel;
}