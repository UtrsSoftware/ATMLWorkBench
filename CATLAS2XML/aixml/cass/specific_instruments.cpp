/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

#include "../cass/specific_instruments.h"
#include "../atlas.h"

#if ( _DEBUG ) && ( WIN32 )
	#define WINVER 0x0600
	#include <afx.h>
	#define new DEBUG_NEW
	#undef THIS_FILE
	static char BASED_CODE THIS_FILE[ ] = __FILE__;
#endif

using namespace XERCES_CPP_NAMESPACE;

map< const string*, SpecificInstrument::eInstrument, AIXMLHelper::cmpPointer > SpecificInstrument::m_mapInstrumentTypes;
map< SpecificInstrument::eInstrument, const string* > SpecificInstrument::m_mapInstrumentEnumToName;
map< SpecificInstrument::eInstrument, const string* > SpecificInstrument::m_mapInstrumentEnumToDescription;
map< SpecificInstrument::eInstrument, SpecificInstrument::eInstrumentClass > SpecificInstrument::m_mapInstrumentEnumInstrumentClassEnum;
map< const string*, SpecificInstrument::eInstrumentClass, AIXMLHelper::cmpPointer > SpecificInstrument::m_mapInstrumentClasses;
map< SpecificInstrument::eInstrumentClass, const string* > SpecificInstrument::m_mapInstrumentClassEnumToName;
map< SpecificInstrument::eInstrumentClass, const string* > SpecificInstrument::m_mapInstrumentClassEnumToDescription;

const SpecificInstrument::CCI SpecificInstrument::m_arrayInstrumentClass[ ] = 
{
	CCI( "FILE",			"File System" ),
	CCI( "PRT",				"Printer" ),
	CCI( "CRT",				"Cathode Ray Tube" ),
	CCI( "KBD",				"Keyboard" ),
	CCI( "IMOM",			"Intermediate Maintenance Operations Management System" ),
	CCI( "ACPS",			"AC Power Supply" ),
	CCI( "ACPSPM",			"UUT Power Monitor" ),
	CCI( "DMM",				"Digital Multimeter" ),
	CCI( "FTIC",			"Frequency/Time Interval Counter" ),
	CCI( "PGEN",			"Pulse Generator" ),
	CCI( "WDD",				"Instrumentation Built-In-Test" ),
	CCI( "STRG",			"System Trigger" ),
	CCI( "PPL",				"Programmable Power Load" ),
	CCI( "WFRD",			"Waveform Digitizer and Waveform Digitizer Distribution" ),
	CCI( "LFC",				"Low Frequency Calibrator" ),
	CCI( "DCPS",			"DC Programmable Power Supply" ),
	CCI( "AWFG",			"Arbitrary Waveform Generator" ),
	CCI( "COMMIF",			"Communications Interface" ),
	CCI( "SGMA",			"Synchro Generator/Measurement" ),
	CCI( "VPG",				"Video Pattern Generator" ),
	CCI( "SSSA",			"Microwave Transition Analyzer" ),
	CCI( "EXTTRIG",			"External Trigger" ),
	CCI( "SRCTRIG",			"Input Signal Trigger" ),
	CCI( "HPPM",			"Power Meter And Spectrum Analyzer" ),
	CCI( "HPSG",			"Frequency Synthesizer" ),
	CCI( "GCG",				"Spread Spectrum" ),
	CCI( "PFGA",			"Air Data Test System" ),
	CCI( "RS485",			"RS485" ),
	CCI( "DDCMP",			"DDCMP" ),
	CCI( "485",				"485M" ),
	CCI( "HARPN",			"HARPN" ),
	CCI( "SLAM",			"SLAM" ),
	CCI( "INTTRIG",			"Internal Trigger" ),
	CCI( "LOCTRIG",			"Local Trigger" ),
	CCI( "TRIGREF",			"User-Defined Trigger" ),
	CCI( "EOSP",			"Entire Electro-Optical Subsystem Plus" ),
	CCI( "HPDT",			"High Power Device Test Set" ),
	CCI( "RS_232",			"RS-232" ),
	CCI( "RS_422",			"RS-422" ),
	CCI( "ARINC_429",		"ARINC-429" ),
	CCI( "MIL_STD_1553",	"MIL-STD-1553" ),
	CCI( "BTI_RS485",		"BTI-RS485" ),
	CCI( "MCI",				"Modulation Control Interface" ),
	CCI( "ATI",				"Analog Test Instrument" ),
	CCI( "CSSG",			"Comstron Signal Generator" ),
	CCI( "DTU",				"Digital Test Unit" ),
	CCI( "GPI",				"General Purpose Interface" ),
	CCI( "HPSA",			"Signal Analyzer " )
};

const SpecificInstrument::CII SpecificInstrument::m_arrayInstrument[ ] = 
{
	CII( "FILE",			eFILEClass,			"File System" ),
	CII( "PRT",				ePRTClass,			"Printer" ),
	CII( "CRT",				eCRTClass,			"Cathode Ray Tube" ),
	CII( "KEYBOARD",		eKBDClass,			"Keyboard" ),
	CII( "KBD",				eKBDClass,			"Keyboard" ),
	CII( "IMOM",			eIMOMClass,			"Intermediate Maintenance Operations Management System" ),
	CII( "ACPSHV",			eACPSClass,			"High Voltage AC Power Supply No. 1" ),
	CII( "ACPSHV#01",		eACPSClass,			"High Voltage AC Power Supply No. 2" ),
	CII( "ACPSHV#02",		eACPSClass,			"High Voltage AC Power Supply No. 3" ),
	CII( "ACPSHV#03",		eACPSClass,			"High Voltage AC Power Supply No. 4" ),
	CII( "ACPSHVPC",		eACPSClass,			"High Voltage AC Power Supply Parallel Combo 'ACPSHV' 'ACPSHV#01'" ),
	CII( "ACPSHVPC#01",		eACPSClass,			"High Voltage AC Power Supply Parallel Combo 'ACPSHV' 'ACPSHV#01' 'ACPSHV#02'" ),
	CII( "ACPSHVPP",		eACPSClass,			"High Voltage AC Power Supply Phase Combo 'ACPSHV' 'ACPSHV#01'" ),
	CII( "ACPSHVPP#01",		eACPSClass,			"High Voltage AC Power Supply Phase Combo 'ACPSHV' 'ACPSHV#01' 'ACPSHV#02'" ),
	CII( "ACPSPM",			eACPSPMClass,		"UUT Power Monitor" ),
	CII( "DMM",				eDMMClass,			"Digital Multimeter" ),
	CII( "DMM-OFFSET",		eDMMClass,			"Digital Multimeter Offset Compensated" ),
	CII( "FTICA",			eFTICClass,			"Frequency/Time Interval Counter Channel A" ),
	CII( "FTICB",			eFTICClass,			"Frequency/Time Interval Counter Channel B" ),
	CII( "PGENA",			ePGENClass,			"Pulse Generator Channel A" ),
	CII( "PGENB",			ePGENClass,			"Pulse Generator Channel B" ),
	CII( "WDD",				eWDDClass,			"CASS Instrumentation Built-In-Test" ),
	CII( "STRGA",			eSTRGClass,			"System Triggering Asset Channel A" ),
	CII( "STRGB",			eSTRGClass,			"System Triggering Asset Channel B" ),
	CII( "PPLDH",			ePPLClass,			"High Wattage Power Load" ),
	CII( "PPLDDC#01",		ePPLClass,			"DC Load Module A1" ),
	CII( "PPLDDC#02",		ePPLClass,			"DC Load Module A2" ),
	CII( "PPLDDC#03",		ePPLClass,			"DC Load Module A3" ),
	CII( "PPLDDC#04",		ePPLClass,			"DC Load Module A4" ),
	CII( "PPLDDC#05",		ePPLClass,			"DC Load Module A5" ),
	CII( "PPLDDC#06",		ePPLClass,			"DC Load Module A6" ),
	CII( "PPLDDCP#01",		ePPLClass,			"Parallel DC Load Module A1, A2" ),
	CII( "PPLDDCP#02",		ePPLClass,			"Parallel DC Load Module A2, A3" ),
	CII( "PPLDDCP#03",		ePPLClass,			"Parallel DC Load Module A3, A4" ),
	CII( "PPLDDCP#04",		ePPLClass,			"Parallel DC Load Module A4, A5" ),
	CII( "PPLDDCP#05",		ePPLClass,			"Parallel DC Load Module A5, A6" ),
	CII( "PPLDDCP#06",		ePPLClass,			"Parallel DC Load Module A1, A2, A3" ),
	CII( "PPLDDCP#07",		ePPLClass,			"Parallel DC Load Module A2, A3, A4" ),
	CII( "PPLDDCP#08",		ePPLClass,			"Parallel DC Load Module A3, A4, A5" ),
	CII( "PPLDDCP#09",		ePPLClass,			"Parallel DC Load Module A4, A5, A6" ),
	CII( "PPLDDCP#10",		ePPLClass,			"Parallel DC Load Module A1, A2, A3, A4" ),
	CII( "PPLDDCP#11",		ePPLClass,			"Parallel DC Load Module A2, A3, A4, A5" ),
	CII( "PPLDDCP#12",		ePPLClass,			"Parallel DC Load Module A3, A4, A5, A6" ),
	CII( "PPLDDCP#13",		ePPLClass,			"Parallel DC Load Module A1, A2, A3, A4, A5" ),
	CII( "PPLDDCP#14",		ePPLClass,			"Parallel DC Load Module A2, A3, A4, A5, A6" ),
	CII( "PPLDDCP#15",		ePPLClass,			"Parallel DC Load Module A1, A2, A3, A4, A5, A6" ),
	CII( "PPLDHCONCUR",		ePPLClass,			"High Wattage Programmable Load Constant Current Mode" ),
	CII( "WFRDA",			eWFRDClass,			"Waveform Digitizer Channel A" ),
	CII( "WFRDB",			eWFRDClass,			"Waveform Digitizer Channel B" ),
	CII( "WFRDC",			eWFRDClass,			"Waveform Digitizer Channel C" ),
	CII( "WFRDD",			eWFRDClass,			"Waveform Digitizer Channel D" ),
	CII( "WFRDA-INTDATA",	eWFRDClass,			"Waveform Digitizer Channel A (internal data)" ),
	CII( "WFRDB-INTDATA",	eWFRDClass,			"Waveform Digitizer Channel B (internal data)" ),
	CII( "WFRDC-INTDATA",	eWFRDClass,			"Waveform Digitizer Channel C (internal data)" ),
	CII( "WFRDD-INTDATA",	eWFRDClass,			"Waveform Digitizer Channel D (internal data)" ),
	CII( "WFRDA#02-ADD",	eWFRDClass,			"Waveform Digitizer Addition Channel A (DC coupled)" ),
	CII( "WFRDB#02-ADD",	eWFRDClass,			"Waveform Digitizer Addition Channel B (DC coupled)" ),
	CII( "WFRDC#02-ADD",	eWFRDClass,			"Waveform Digitizer Addition Channel C (DC coupled)" ),
	CII( "WFRDD#02-ADD",	eWFRDClass,			"Waveform Digitizer Addition Channel D (DC coupled)" ),
	CII( "WFRDA#02-SUBT",	eWFRDClass,			"Waveform Digitizer Subtraction Channel A (DC coupled)" ),  
	CII( "WFRDB#02-SUBT",	eWFRDClass,			"Waveform Digitizer Subtraction Channel B (DC coupled)" ),  
	CII( "WFRDC#02-SUBT",	eWFRDClass,			"Waveform Digitizer Subtraction Channel C (DC coupled)" ),  
	CII( "WFRDD#02-SUBT",	eWFRDClass,			"Waveform Digitizer Subtraction Channel D (DC coupled)" ),  
	CII( "WFRDA#02-MULT",	eWFRDClass,			"Waveform Digitizer Multiplication Channel A (DC coupled)" ),
	CII( "WFRDB#02-MULT",	eWFRDClass,			"Waveform Digitizer Multiplication Channel A (DC coupled)" ),
	CII( "WFRDC#02-MULT",	eWFRDClass,			"Waveform Digitizer Multiplication Channel A (DC coupled)" ),
	CII( "WFRDD#02-MULT",	eWFRDClass,			"Waveform Digitizer Multiplication Channel A (DC coupled)" ),
	CII( "WFRDA#03-ADD",	eWFRDClass,			"Waveform Digitizer Addition Channel A (1 MOHM impedance)" ),    
	CII( "WFRDB#03-ADD",	eWFRDClass,			"Waveform Digitizer Addition Channel B (1 MOHM impedance)" ),    
	CII( "WFRDC#03-ADD",	eWFRDClass,			"Waveform Digitizer Addition Channel C (1 MOHM impedance)" ),    
	CII( "WFRDD#03-ADD",	eWFRDClass,			"Waveform Digitizer Addition Channel D (1 MOHM impedance)" ),    
	CII( "WFRDA#03-SUBT",	eWFRDClass,			"Waveform Digitizer Subtraction Channel A (1 MOHM impedance)" ),
	CII( "WFRDB#03-SUBT",	eWFRDClass,			"Waveform Digitizer Subtraction Channel B (1 MOHM impedance)" ),
	CII( "WFRDC#03-SUBT",	eWFRDClass,			"Waveform Digitizer Subtraction Channel C (1 MOHM impedance)" ),
	CII( "WFRDD#03-SUBT",	eWFRDClass,			"Waveform Digitizer Subtraction Channel D (1 MOHM impedance)" ),
	CII( "WFRDA#03-MULT",	eWFRDClass,			"Waveform Digitizer Multiplication Channel A (1MOHM impedance)" ),
	CII( "WFRDB#03-MULT",	eWFRDClass,			"Waveform Digitizer Multiplication Channel B (1MOHM impedance)" ),
	CII( "WFRDC#03-MULT",	eWFRDClass,			"Waveform Digitizer Multiplication Channel C (1MOHM impedance)" ),
	CII( "WFRDD#03-MULT",	eWFRDClass,			"Waveform Digitizer Multiplication Channel D (1MOHM impedance)" ),
	CII( "WFRDA#03-INVERT",	eWFRDClass,			"Waveform Digitizer Invert Channel A" ), 
	CII( "WFRDB#03-INVERT",	eWFRDClass,			"Waveform Digitizer Invert Channel B" ), 
	CII( "WFRDC#03-INVERT",	eWFRDClass,			"Waveform Digitizer Invert Channel C" ), 
	CII( "WFRDD#03-INVERT",	eWFRDClass,			"Waveform Digitizer Invert Channel D" ), 
	CII( "LFCC",			eLFCClass,			"Low Frequency Calibrator" ),
	CII( "DCPSLVA",			eDCPSClass,			"Low Voltage DC Power Supply Type A No. 1" ),
	CII( "DCPSLVA#01",		eDCPSClass,			"Low Voltage DC Power Supply Type A No. 2" ),
	CII( "DCPSLVA#02",		eDCPSClass,			"Low Voltage DC Power Supply Type A No. 3" ),
	CII( "DCPSLVA#03",		eDCPSClass,			"Low Voltage DC Power Supply Type A No. 4" ),
	CII( "DCPSLVA#04",		eDCPSClass,			"Low Voltage DC Power Supply Type A No. 5" ),
	CII( "DCPSLVA#05",		eDCPSClass,			"Low Voltage DC Power Supply Type A No. 6" ),
	CII( "DCPSLVA#06",		eDCPSClass,			"Low Voltage DC Power Supply Type A No. 7" ),
	CII( "DCPSLVA#07",		eDCPSClass,			"Low Voltage DC Power Supply Type A No. 8" ),
	CII( "DCPSLVB",			eDCPSClass,			"Low Voltage DC Power Supply Type B" ),
	CII( "DCPSLVC",			eDCPSClass,			"Low Voltage DC Power Supply Type C No. 1" ),
	CII( "DCPSLVC#01",		eDCPSClass,			"Low Voltage DC Power Supply Type C No. 2" ),
	CII( "DCPSLVAP",		eDCPSClass,			"Low Voltage DC Power Supply Type A Parallel Combo 'DCPSLVA#05' 'DCPSLVA#06' 'DCPSLVA#07'" ),
	CII( "DCPSLVAP#01",		eDCPSClass,			"Low Voltage DC Power Supply Type A Parallel Combo 'DCPSLVA#05' 'DCPSLVA#06'" ),
	CII( "DCPSLVAP#02",		eDCPSClass,			"Low Voltage DC Power SupplyType A Parallel Combo 'DCPSLVA#06' 'DCPSLVA#07'" ),
	CII( "DCPSLVAP#03",		eDCPSClass,			"Low Voltage DC Power Supply Type A Parallel Combo 'DCPSLVA' 'DCPSLVA#01' 'DCPSLVA#02' 'DCPSLVA#03' 'DCPSLVA#04'" ),
	CII( "DCPSLVAP#04",		eDCPSClass,			"Low Voltage DC Power Supply Type A Parallel Combo 'DCPSLVA' 'DCPSLVA#01' 'DCPSLVA#02' 'DCPSLVA#03'" ),
	CII( "DCPSLVAP#05",		eDCPSClass,			"Low Voltage DC Power Supply Type A Parallel Combo 'DCPSLVA' 'DCPSLVA#01' 'DCPSLVA#02'" ),
	CII( "DCPSLVAP#06",		eDCPSClass,			"Low Voltage DC Power Supply Type A Parallel Combo 'DCPSLVA' 'DCPSLVA#01'" ),
	CII( "DCPSLVAP#07",		eDCPSClass,			"Low Voltage DC Power Supply Type A Parallel Combo 'DCPSLVA#01' 'DCPSLVA#02' 'DCPSLVA#03''DCPSLVA#04'" ),
	CII( "DCPSLVAP#08",		eDCPSClass,			"Low Voltage DC Power SupplyType A Parallel Combo 'DCPSLVA#01' 'DCPSLVA#02' 'DCPSLVA#03'" ),
	CII( "DCPSLVAP#09",		eDCPSClass,			"Low Voltage DC Power Supply Type A Parallel Combo 'DCPSLVA#01' 'DCPSLVA#02'" ),
	CII( "DCPSLVAP#10",		eDCPSClass,			"Low Voltage DC Power Supply Type A Parallel Combo 'DCPSLVA#02' 'DCPSLVA#03' 'DCPSLVA#04'" ),
	CII( "DCPSLVAP#11",		eDCPSClass,			"Low Voltage DC Power Supply Type A Parallel Combo 'DCPSLVA#02' 'DCPSLVA#03'" ),
	CII( "DCPSLVAP#12",		eDCPSClass,			"Low Voltage DC Power Supply Type A Parallel Combo 'DCPSLVA#03' 'DCPSLVA#04'" ),
	CII( "DCPSLVCP",		eDCPSClass,			"Low Voltage DC Power Supply Type C Parallel Combo 'DCPSLVC' 'DCPSLVC#01'" ),
	CII( "AWFGA",			eAWFGClass,			"Arbitrary Waveform Generator Channel A" ),
	CII( "AWFGB",			eAWFGClass,			"Arbitrary Waveform Generator Channel B" ),
	CII( "AWFGM",			eAWFGClass,			"Arbitrary Waveform Generator Cchannel A multiplexed with Channel B" ),
	CII( "COMMIF",			eCOMMIFClass,		"Communications Interface " ),
	CII( "SGMA#01",			eSGMAClass,			"Synchro Generator/Measurement No. 1" ),
	CII( "SGMA#02",			eSGMAClass,			"Synchro Generator/Measurement No. 2" ),
	CII( "SGMA#03",			eSGMAClass,			"Synchro Generator/Measurement No. 3" ),
	CII( "VPGSTTL",			eVPGClass,			"Video Pattern Generator TTL output" ),
	CII( "VPGSANA",			eVPGClass,			"Video Pattern Generator Analog output" ),
	CII( "VPGSNTSC",		eVPGClass,			"Video Pattern Generator NTSC/PAL TV output" ),
	CII( "SSSA",			eSSSAClass,			"RF Instrumentation: Microwave Transition Analyzer" ),
	CII( "SSSACAL",			eSSSAClass,			"RF Instrumentation: Microwave Transition Analyzer Calibration" ),
	CII( "SSSANA",			eSSSAClass,			"RF Instrumentation: HP Network Analyzer using the Microwave Transition Analyzer" ),
	CII( "SSSAPP",			eSSSAClass,			"RF Instrumentation: Peak Power Measurement using the Microwave Transition Analyzer" ),
	CII( "SSSAVV",			eSSSAClass,			"RF Instrumentation: HP Vector Voltmeter Measurement using the HP Microwave Transition Analyzer" ),
	CII( "SSSAAP",			eSSSAClass,			"RF Instrumentation: HP Array Processing using the Microwave Transition Analyzer" ),
	CII( "SSSASG",			eSSSAClass,			"RF Instrumentation: Microwave Transition Analyzer Signal Generation" ),
	CII( "EXTTRIG1",		eEXTTRIGClass,		"RF Instrumentation: External Trigger 1 " ),
	CII( "EXTTRIG2",		eEXTTRIGClass,		"RF Instrumentation: RF External Trigger 2" ),
	CII( "SRCTRIGA",		eSRCTRIGClass,		"RF Instrumentation: Input Signal Channel A" ), 
	CII( "SRCTRIGB",		eSRCTRIGClass,		"RF Instrumentation: Input Signal Channel B" ),
	CII( "HPPM1",			eHPPMClass,			"RF Instrumentation: Power Meter 1" ),
	CII( "HPPM2",			eHPPMClass,			"RF Instrumentation: Power Meter 2" ),
	CII( "HPPM1AZ",			eHPPMClass,			"RF Instrumentation: Power Meter And Spectrum Analyzer 1" ),
	CII( "HPPM2AZ",			eHPPMClass,			"RF Instrumentation: Power Meter And Spectrum Analyzer 2" ),
	CII( "HPPM1CAL",		eHPPMClass,			"RF Instrumentation: Power Meter 1 Calibration" ),
	CII( "HPPM2CAL",		eHPPMClass,			"RF Instrumentation: Power Meter 1 Calibration" ),
	CII( "HPSG2",			eHPSGClass,			"RF Instrumentation: Frequency Synthesizer 40 GHz" ),
	CII( "HPSG3",			eHPSGClass,			"RF Instrumentation: Frequency Synthesizer 20 GHz" ),
	CII( "GCG1",			eGCGClass,			"RF Instrumentation: Spread Spectrum, Generic Code Generator Number 1" ),
	CII( "GCG2",			eGCGClass,			"RF Instrumentation: Spread Spectrum, Generic Code Generator Number 2" ),
	CII( "GCG4",			eGCGClass,			"RF Instrumentation: Spread Spectrum, Generic Code Generator Number 4" ),
	CII( "PFGA",			ePFGAClass,			"Air Data Test System" ),
	CII( "PFGAZ",			ePFGAClass,			"Air Data Test System Zero Point Calibration" ),
	CII( "PFGAM",			ePFGAClass,			"Air Data Test System Mid Point Calibration" ), 
	CII( "PFGAF",			ePFGAClass,			"Air Data Test System Full Point Calibration" ), 
	CII( "PFGA-MM",			ePFGAClass,			"Air Data Test System Measurement Mode" ), 
	CII( "RS485",			eRS485Class,		"Advanced Communication Bus Interface - RS485" ), 
	CII( "RS485A",			eRS485Class,		"Advanced Communication Bus Interface - RS485 A" ),
	CII( "RS485B",			eRS485Class,		"Advanced Communication Bus Interface - RS485 B" ),
	CII( "RS485C",			eRS485Class,		"Advanced Communication Bus Interface - RS485 C" ),
	CII( "RS485AC",			eRS485Class,		"Advanced Communication Bus Interface - RS485 AC" ),
	CII( "RS485BC",			eRS485Class,		"Advanced Communication Bus Interface - RS485 BC" ),
	CII( "DDCMPA",			eDDCMPClass,		"Advanced Communication Bus Interface - DDCMP A" ),
	CII( "DDCMPB",			eDDCMPClass,		"Advanced Communication Bus Interface - DDCMP B" ),
	CII( "DDCMPAC",			eDDCMPClass,		"Advanced Communication Bus Interface - DDCMP AC" ),
	CII( "DDCMPBC",			eDDCMPClass,		"Advanced Communication Bus Interface - DDCMP BC" ),
	CII( "485M",			eDDCMPClass,		"Advanced Communication Bus Interface - 485M" ),
	CII( "485MA",			e485Class,			"Advanced Communication Bus Interface - 485M A" ),
	CII( "485MB",			e485Class,			"Advanced Communication Bus Interface - 485M B" ),
	CII( "485MC",			e485Class,			"Advanced Communication Bus Interface - 485M C" ),
	CII( "485MAC",			e485Class,			"Advanced Communication Bus Interface - 485M AC" ),
	CII( "485MBC",			e485Class,			"Advanced Communication Bus Interface - 485M BC" ),
	CII( "HARPNA",			eHARPNClass,		"Advanced Communication Bus Interface - HARPN A" ),
	CII( "HARPNB",			eHARPNClass,		"Advanced Communication Bus Interface - HARPN B" ),
	CII( "HARPNAC",			eHARPNClass,		"Advanced Communication Bus Interface - HARPN AC" ),
	CII( "HARPNBC",			eHARPNClass,		"Advanced Communication Bus Interface - HARPN BC" ),
	CII( "SLAMA",			eSLAMClass,			"Advanced Communication Bus Interface - SLAM A" ),
	CII( "SLAMB",			eSLAMClass,			"Advanced Communication Bus Interface - SLAM B" ),
	CII( "SLAMAC",			eSLAMClass,			"Advanced Communication Bus Interface - SLAM AC" ),
	CII( "SLAMBC",			eSLAMClass,			"Advanced Communication Bus Interface - SLAM BC" ),
	CII( "SYSTRIG1",		eSTRGClass,			"System Trigger Bus 1" ),
	CII( "SYSTRIG2",		eSTRGClass,			"System Trigger Bus 2" ),
	CII( "EXTTRIG",			eEXTTRIGClass,		"External Trigger" ),
	CII( "INTTRIG",			eINTTRIGClass,		"Internal Trigger" ),
	CII( "LOCTRIG1",		eLOCTRIGClass,		"Local Trigger Bus 1" ),
	CII( "LOCTRIG2",		eLOCTRIGClass,		"Local Trigger Bus 2" ),
	CII( "TRIGREF",			eTRIGREFClass,		"User-Defined Trigger" ),
	CII( "EOSP",			eEOSPClass,			"Entire Electro-Optical Subsystem Plus" ),
	CII( "EOSPSOURCE",		eEOSPClass,			"Entire Electro-Optical Subsystem Plus Source" ),
	CII( "EOSPIRSRC",		eEOSPClass,			"Electro-Optical Subsystem Plus IR Source Only" ),
	CII( "EOSPLST",			eEOSPClass,			"Electro-Optical Subsystem Plus IR LST Only" ),
	CII( "EOSPTVSRC",		eEOSPClass,			"Electro-Optical Subsystem Plus IRVisible Source Only" ),
	CII( "EOSPWFOVUS",		eEOSPClass,			"Electro-Optical Subsystem Plus IRWFOVUS Only" ),
	CII( "OSPSOURCE-T1",	eEOSPClass,			"Electro-Optical Subsystem Plus IRGenerated Primary Target" ),
	CII( "OSPLZSRC-T1",		eEOSPClass,			"Electro-Optical Subsystem Plus IRLaser Source Only" ), 
	CII( "EOSPIR",			eEOSPClass,			"Electro-Optical Subsystem Plus IRIR Only" ), 
	CII( "EOSPIRMSB",		eEOSPClass,			"Electro-Optical Subsystem Plus IRIR MSB Only" ),
	CII( "EOSPVID",			eEOSPClass,			"Electro-Optical Subsystem Plus IRVideo Only" ),
	CII( "EOSPTV",			eEOSPClass,			"Electro-Optical Subsystem Plus IRVisible Only" ), 
	CII( "EOSPTVMSB",		eEOSPClass,			"Electro-Optical Subsystem Plus IRVisible MSB Only" ), 
	CII( "EOSPAC",			eEOSPClass,			"Electro-Optical Subsystem Plus IRAutocollimation Only" ), 
	CII( "EOSPFPA",			eEOSPClass,			"Electro-Optical Subsystem Plus IRFPA Only" ), 
	CII( "EOSPLZ",			eEOSPClass,			"Electro-Optical Subsystem Plus IRLaser Only" ),    
	CII( "HPDTAPU",			eHPDTClass,			"High Power Device Test Set: AC Power Unit" ), 
	CII( "HPDTLCU",			eHPDTClass,			"High Power Device Test Set: Liquid Cooling Unit" ), 
	CII( "HPDTDA",			eHPDTClass,			"High Power Device Test Set: ITA Digital to Analog Convertor" ), 
	CII( "HPDTAD",			eHPDTClass,			"High Power Device Test Set: ITA Analog to Digital Converter" ), 
	CII( "HPDTRY",			eHPDTClass,			"High Power Device Test Set: SITA Relay" ),
	CII( "HPDTITA",			eHPDTClass,			"High Power Device Test Set: SITA" ),
	CII( "HPDTDO",			eHPDTClass,			"High Power Device Test Set: ITA Discrete Output" ),
	CII( "HPDTDI",			eHPDTClass,			"High Power Device Test Set: ITA Discrete Input" ),
	CII( "HPDTBSTM",		eHPDTClass,			"High Power Device Test Set: SITA Interface Bus Stimulus" ),
	CII( "HPDTBRSP",		eHPDTClass,			"High Power Device Test Set: SITA Interface Bus Response" ),
	CII( "HPDTRHM",			eHPDTClass,			"High Power Device Test Set: Radiation Hazard Monitor" ),
	CII( "HPDTCMTR",		eHPDTClass,			"High Power Device Test Set: Calorimeter" ),
	CII( "RS-232-C",		eRS_232Class,		"Bus Test Instrument: RS-232-C" ),
	CII( "RS-232-CN",		eRS_232Class,		"Bus Test Instrument: RS-232-CN" ),
	CII( "RS-232-D",		eRS_232Class,		"Bus Test Instrument: RS-232-D" ),
	CII( "RS-232-DN",		eRS_232Class,		"Bus Test Instrument: RS-232-DN" ),
	CII( "RS-422-C",		eRS_422Class,		"Bus Test Instrument: RS-422-C" ),
	CII( "RS-422-CN",		eRS_422Class,		"Bus Test Instrument: RS-422-CN" ),
	CII( "RS-422-D",		eRS_422Class,		"Bus Test Instrument: RS-422-D" ),
	CII( "RS-422-DN",		eRS_422Class,		"Bus Test Instrument: RS-422-DN" ),
	CII( "ARINC-429-C",		eARINC_429Class,	"Bus Test Instrument: ARINC-429-C" ),
	CII( "ARINC-429-CN",	eARINC_429Class,	"Bus Test Instrument: ARINC-429-CN" ),
	CII( "ARINC-429-D",		eARINC_429Class,	"Bus Test Instrument: ARINC-429-D" ),
	CII( "ARINC-429-DN",	eARINC_429Class,	"Bus Test Instrument: ARINC-429-DN" ),
	CII( "MIL-STD-1553A-C",	eMIL_STD_1553Class,	"Bus Test Instrument: MIL-STD-1553A-C" ),
	CII( "MIL-STD-1553A-D",	eMIL_STD_1553Class,	"Bus Test Instrument: MIL-STD-1553A-D" ),
	CII( "MIL-STD-1553B-C",	eMIL_STD_1553Class,	"Bus Test Instrument: MIL-STD-1553B-C" ),
	CII( "MIL-STD-1553B-D",	eMIL_STD_1553Class,	"Bus Test Instrument: MIL-STD-1553B-D" ),
	CII( "MIL-STD-1553A-CN",eMIL_STD_1553Class,	"Bus Test Instrument: MIL-STD-1553A-CN" ),
	CII( "MIL-STD-1553A-DN",eMIL_STD_1553Class,	"Bus Test Instrument: MIL-STD-1553A-DN" ),
	CII( "MIL-STD-1553B-CN",eMIL_STD_1553Class,	"Bus Test Instrument: MIL-STD-1553B-CN" ),
	CII( "MIL-STD-1553B-DN",eMIL_STD_1553Class,	"Bus Test Instrument: MIL-STD-1553B-DN" ),
	CII( "BTI-RS485A",		eBTI_RS485Class,	"Bus Test Instrument: BTI-RS485A" ),
	CII( "BTI-RS485B",		eBTI_RS485Class,	"Bus Test Instrument: BTI-RS485B" ),
	CII( "BTI-RS485",		eBTI_RS485Class,	"Bus Test Instrument: BTI-RS485" ),
	CII( "BTI-RS485C",		eBTI_RS485Class,	"Bus Test Instrument: BTI-RS485C" ),
	CII( "BTI-RS485AC",		eBTI_RS485Class,	"Bus Test Instrument: BTI-RS485AC" ),
	CII( "BTI-RS485BC",		eBTI_RS485Class,	"Bus Test Instrument: BTI-RS485BC" ),
	CII( "MCI",				eMCIClass,			"Modulation Control Interface" ),
	CII( "ATI",				eATIClass,			"MAC PCEXEC Analog Test Instrument" ),
	CII( "ARINC429",		eARINC_429Class,	"MAC PCEXEC Bus Test Instrument: ARINC429" ),
	CII( "MS1553",			eMIL_STD_1553Class,	"MAC PCEXEC Bus Test Instrument: MS1553" ),
	CII( "RS232",			eRS_232Class,		"MAC PCEXEC Bus Test Instrument: RS232" ),
	CII( "RS422",			eRS_422Class,		"MAC PCEXEC Bus Test Instrument: RS422" ),
	CII( "ACPS",			eACPSClass,			"MAC PCEXEC AC Power Supply" ),
	CII( "AWFG",			eAWFGClass,			"MAC PCEXEC Arbitrary Waveform Generator" ),
	CII( "CSSG",			eCSSGClass,			"MAC PCEXEC Comstron Signal Generator" ),
	CII( "DCPS",			eDCPSClass,			"MAC PCEXEC DC Programmable Power Supply" ),
	CII( "DTU",				eDTUClass,			"MAC PCEXEC Digital Test Unit" ),
	CII( "FTIC",			eFTICClass,			"MAC PCEXEC Frequency Time Interval Counter" ),
	CII( "GPI",				eGPIClass,			"MAC PCEXEC General Purpose Interface" ),
	CII( "HPPM",			eHPPMClass,			"MAC PCEXEC Hewlett Packard Power Meter" ),
	CII( "HPSA",			eHPSAClass,			"MAC PCEXEC Hewlett Packard Signal Analyzer" ), 
	CII( "HPSG",			eHPSGClass,			"MAC PCEXEC Hewlett Packard Signal Generator" ), 
	CII( "LFC",				eLFCClass,			"MAC PCEXEC Low Frequency Calibration" ),
	CII( "PGEN",			ePGENClass,			"MAC PCEXEC Pulse Generator" ),
	CII( "PPL",				ePPLClass,			"MAC PCEXEC Programmable Power Load" ),
	CII( "SGMA",			eSGMAClass,			"MAC PCEXEC Syncho Generation/Measurement Assembly" ),
	CII( "STRG",			eSTRGClass,			"MAC PCEXEC System Trigger" ),
	CII( "VPG",				eVPGClass,			"MAC PCEXEC Video Pattern Generator" ),
	CII( "WFRD",			eWFRDClass,			"MAC PCEXEC Waveform Digitizer" )
};

// *** KEEP THIS LAST FOR ALL STATIC INITIALIZERS ****
const bool SpecificInstrument::m_bInitAll = SpecificInstrument::InitAll( );

bool SpecificInstrument::InitAll( void )
{
	InitInstrumentClasses( );
	InitInstruments( );

	return true;
}

void SpecificInstrument::InitInstrumentClasses( void )
{
	const int iMax = ( eHPSAClass + 1 );

	for ( int i = 0; i < iMax; i++ )
	{
		m_mapInstrumentClasses.insert( make_pair( &m_arrayInstrumentClass[ i ].m_strClassName, ( eInstrumentClass ) i ) );
		m_mapInstrumentClassEnumToName.insert( make_pair( ( eInstrumentClass ) i, &m_arrayInstrumentClass[ i ].m_strClassName ) );
		m_mapInstrumentClassEnumToDescription.insert( make_pair( ( eInstrumentClass ) i, &m_arrayInstrumentClass[ i ].m_strClassDescription ) );
	}
}


void SpecificInstrument::InitInstruments( void )
{
	const int iMax = ( eWFRD + 1 );

	for ( int i = 0; i < iMax; i++ )
	{
		m_mapInstrumentTypes.insert( make_pair( &m_arrayInstrument[ i ].m_strSystemName, ( eInstrument ) i ) );
		m_mapInstrumentEnumToName.insert( make_pair( ( eInstrument ) i, &m_arrayInstrument[ i ].m_strSystemName ) );
		m_mapInstrumentEnumToDescription.insert( make_pair( ( eInstrument ) i, &m_arrayInstrument[ i ].m_strSystemNameDescription ) );
		m_mapInstrumentEnumInstrumentClassEnum.insert( make_pair( ( eInstrument ) i, m_arrayInstrument[ i ].m_eInstrumentClass ) );
	}
}

string SpecificInstrument::GetInstrumentName( SpecificInstrument::eInstrument e )
{
	string strName( Atlas::m_UNKNOWN );

	const map< eInstrument, const string* >::const_iterator it = m_mapInstrumentEnumToName.find( e );
	const map< eInstrument, const string* >::const_iterator itEnd = m_mapInstrumentEnumToName.end( );

	if ( itEnd != it )
	{
		strName = *( it->second );
	}

	return strName;
}

string SpecificInstrument::GetInstrumentDescription( SpecificInstrument::eInstrument e )
{
	string strDescription( Atlas::m_UNKNOWN );

	const map< eInstrument, const string* >::const_iterator it = m_mapInstrumentEnumToDescription.find( e );
	const map< eInstrument, const string* >::const_iterator itEnd = m_mapInstrumentEnumToDescription.end( );

	if ( itEnd != it )
	{
		strDescription = *( it->second );
	}

	return strDescription;
}

SpecificInstrument::eInstrumentClass SpecificInstrument::GetInstrumentClass( SpecificInstrument::eInstrument e )
{
	eInstrumentClass eClass = eUnknownInstrumentClass;

	const map< eInstrument, eInstrumentClass >::const_iterator it = m_mapInstrumentEnumInstrumentClassEnum.find( e );
	const map< eInstrument, eInstrumentClass >::const_iterator itEnd = m_mapInstrumentEnumInstrumentClassEnum.end( );

	if ( itEnd != it )
	{
		eClass = it->second;
	}

	return eClass;
}
 
SpecificInstrument::eInstrument SpecificInstrument::GetInstrument( const string& strSystemName, const bool bFindClosest, string* pstrCassName )
{
	eInstrument e = eUnknownInstrument;

	map< const string*, eInstrument, AIXMLHelper::cmpPointer >::const_iterator it = m_mapInstrumentTypes.find( &strSystemName );
	const map< const string*, eInstrument, AIXMLHelper::cmpPointer >::const_iterator itEnd = m_mapInstrumentTypes.end( );

	if ( itEnd != it )
	{
		e = it->second;

		if ( 0 != pstrCassName )
		{
			pstrCassName->assign( strSystemName );
		}
	}
	else if ( bFindClosest )
	{
		// We didn't find it. 
		//
		// Lets see if its one of the instruments types that appends additional information.
		// Example: DCPSLV - Low Voltage DC Power Supply
		// Also ending with: type A, B, C, AP <type A Parallel Combo>, or CP <type C Parallel Combo>)
		//
		// NOTE: method lower_bound returns an iterator pointing to the first element in the container 
		// whose key is not considered to go before k (i.e., either it is equivalent or goes after).

		it = m_mapInstrumentTypes.lower_bound( &strSystemName );

		if ( itEnd != it )
		{
			const map< const string*, eInstrument, AIXMLHelper::cmpPointer >::const_iterator itBegin = m_mapInstrumentTypes.begin( );

			it--;

			while ( itBegin != it )
			{
				if ( AIXMLHelper::StartsWith( strSystemName, *( it->first ) ) )
				{
					e = it->second;
	
					if ( 0 != pstrCassName )
					{
						pstrCassName->assign( *( it->first ) );
					}

					break;
				}

				it--;
			}
		}
		else
		{
			// Past the end of the map

			const map< const string*, eInstrument, AIXMLHelper::cmpPointer >::const_reverse_iterator rit = m_mapInstrumentTypes.rbegin( );
			const map< const string*, eInstrument, AIXMLHelper::cmpPointer >::const_reverse_iterator ritEnd = m_mapInstrumentTypes.rend( );

			if ( ritEnd != rit )
			{
				if ( AIXMLHelper::StartsWith( strSystemName, *( rit->first ) ) )
				{
					e = rit->second;
	
					if ( 0 != pstrCassName )
					{
						pstrCassName->assign( *( rit->first ) );
					}
				}
			}
		}
	}

	return e;
}

SpecificInstrument::eInstrumentClass SpecificInstrument::GetInstrumentClassEnum( const string& strClassName )
{
	SpecificInstrument::eInstrumentClass eClass = eUnknownInstrumentClass;

	const map< const string*, eInstrumentClass, AIXMLHelper::cmpPointer >::const_iterator it = m_mapInstrumentClasses.find( &strClassName );
	const map< const string*, eInstrumentClass, AIXMLHelper::cmpPointer >::const_iterator itEnd = m_mapInstrumentClasses.end( );

	if ( itEnd != it )
	{
		eClass = it->second;
	}

	return eClass;
}

string SpecificInstrument::GetInstrumentClass( const eInstrumentClass eClass )
{
	string strClassName( Atlas::m_UNKNOWN );

	const map< eInstrumentClass, const string* >::const_iterator it = m_mapInstrumentClassEnumToName.find( eClass );
	const map< eInstrumentClass, const string* >::const_iterator itEnd = m_mapInstrumentClassEnumToName.end( );

	if ( itEnd != it )
	{
		strClassName = *( it->second );
	}

	return strClassName;
}

string SpecificInstrument::GetInstrumentClassDescription( const eInstrumentClass eClass )
{
	string strClassDescription( Atlas::m_UNKNOWN );

	const map< eInstrumentClass, const string* >::const_iterator it = m_mapInstrumentClassEnumToDescription.find( eClass );
	const map< eInstrumentClass, const string* >::const_iterator itEnd = m_mapInstrumentClassEnumToDescription.end( );

	if ( itEnd != it )
	{
		strClassDescription = *( it->second );
	}

	return strClassDescription;
}

bool SpecificInstrument::IsFileClass( const eInstrumentClass eClass )
{
	return ( eFILEClass == eClass );
}

bool SpecificInstrument::IsDeviceClass( const eInstrumentClass eClass )
{
	bool bIsDeviceClass = false;

	if ( ( ePRTClass == eClass ) 
		|| ( eCRTClass == eClass ) 
		|| ( eKBDClass == eClass ) 
		|| ( eIMOMClass == eClass ) )
	{
		bIsDeviceClass = true;
	}

	return bIsDeviceClass;
}

bool SpecificInstrument::IsVideoClass( const eInstrumentClass eClass )
{
	return ( eVPGClass == eClass );
}