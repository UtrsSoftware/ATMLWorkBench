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

#include "../helper.h"


using namespace std;

class Instrument;

class SpecificInstrument
{
public:

	enum eInstrumentClass
	{
		eUnknownInstrumentClass = -1,
		eFILEClass,			// File System (doesn't actual exist in CASS, synthesizing it to handle I/O files)  
		ePRTClass,			// Printer		
		eCRTClass,			// Cathode Ray Tube
		eKBDClass,			// Keyboard
		eIMOMClass,			// Intermediate Maintenance Operations Management System
		eACPSClass,			// AC Power Supplies
		eACPSPMClass,		// UUT Power Monitor
		eDMMClass,			// Digital Multimeter
		eFTICClass,			// Frequency/Time Interval Counter
		ePGENClass,			// Pulse Generator
		eWDDClass,			// Instrumentation Built-In-Test
		eSTRGClass,			// System Trigger
		ePPLClass,			// Programmable Power Loads
		eWFRDClass,			// Waveform Digitizer and Waveform Digitizer Distribution
		eLFCClass,			// Low Frequency Calibrator
		eDCPSClass,			// DC Programmable Power Supplies
		eAWFGClass,			// Arbitrary Waveform Generator
		eCOMMIFClass,		// Communications Interface
		eSGMAClass,			// Synchro Generator/Measurement
		eVPGClass,			// Video Pattern Generator
		eSSSAClass,			// Microwave Transition Analyzer
		eEXTTRIGClass,		// External Trigger
		eSRCTRIGClass,		// Input Signal Trigger
		eHPPMClass,			// Power Meter And Spectrum Analyzer
		eHPSGClass,			// Frequency Synthesizer
		eGCGClass,			// Spread Spectrum
		ePFGAClass,			// Air Data Test System
		eRS485Class,		// RS485
		eDDCMPClass,		// DDCMP
		e485Class,			// 485M
		eHARPNClass,		// HARPN
		eSLAMClass,			// SLAM
		eINTTRIGClass,		// Internal Trigger
		eLOCTRIGClass,		// Local Trigger
		eTRIGREFClass,		// User-Defined Trigger
		eEOSPClass,			// Entire Electro-Optical Subsystem Plus
		eHPDTClass,			// High Power Device Test Set
		eRS_232Class,		// RS-232
		eRS_422Class,		// RS-422
		eARINC_429Class,	// ARINC-429
		eMIL_STD_1553Class,	// MIL-STD-1553
		eBTI_RS485Class,	// BTI-RS485
		eMCIClass,			// Modulation Control Interface
		eATIClass,			// Analog Test Instrument
		eCSSGClass,			// Comstron Signal Generator
		eDTUClass,			// Digital Test Unit
		eGPIClass,			// General Purpose Interface
		eHPSAClass			// Signal Analyzer 

		// NOTE: The ending enum is used in FOR loops, make sure to update loops
	};  // enum eInstrumentClass

	enum eInstrument
	{
		eUnknownInstrument = -1,
		eFILE,				// File System (doesn't actual exist in CASS, synthesizing it to handle I/O files)
		ePRT,				// Printer		
		eCRT,				// Cathode Ray Tube
		eKEYBOARDa,			// Keyboard
		eKEYBOARDb,			// Keyboard
		eIMOM,				// Intermediate Maintenance Operations Management System

		// Begin AC Power Supplies
		eACPSHV,			// High Voltage AC Power Supply No. 1
		eACPSHV_01,			// High Voltage AC Power Supply No. 2
		eACPSHV_02,			// High Voltage AC Power Supply No. 3
		eACPSHV_03,			// High Voltage AC Power Supply No. 4
		eACPSHVPC,			// High Voltage AC Power Supply Parallel Combo 'ACPSHV' 'ACPSHV#01'
		eACPSHVPC_01,		// High Voltage AC Power Supply Parallel Combo 'ACPSHV' 'ACPSHV#01' 'ACPSHV#02'
		eACPSHVPP,			// High Voltage AC Power Supply Phase Combo 'ACPSHV' 'ACPSHV#01'
		eACPSHVPP_01,		// High Voltage AC Power Supply Phase Combo 'ACPSHV' 'ACPSHV#01' 'ACPSHV#02'
		// End AC Power Supplies

		eACPSPM,			// UUT Power Monitor

		// Begin Digital Multimeter
		eDMM,				// Digital Multimeter
		eDMM_OFFSET,		// Digital Multimeter Offset Compensated
		// End Digital Multimeter

		// Begin Frequency/Time Interval Counter
		eFTICA,				// Frequency/Time Interval Counter Channel A
		eFTICB,				// Frequency/Time Interval Counter Channel B
		// End Frequency/Time Interval Counter

		// Begin Pulse Generator
		ePGENA,				// Pulse Generator Channel A
		ePGENB,				// Pulse Generator Channel B
		// End Pulse Generator

		eWDD,				// CASS Instrumentation Built-In-Test

		// Begin System Triggering Asset
		eSTRGA,				// System Triggering Asset Channel A
		eSTRGB,				// System Triggering Asset Channel B
		// End System Triggering Asset

		// Begin Programmable Power Loads
		ePPLDH,				// High Wattage Power Loads
		ePPLDDC_01,			// DC Load Module A1
		ePPLDDC_02,			// DC Load Module A2
		ePPLDDC_03,			// DC Load Module A3
		ePPLDDC_04,			// DC Load Module A4
		ePPLDDC_05,			// DC Load Module A5
		ePPLDDC_06,			// DC Load Module A6
		ePPLDDCP_01,		// Parallel DC Load Module A1, A2
		ePPLDDCP_02,		// Parallel DC Load Module A2, A3
		ePPLDDCP_03,		// Parallel DC Load Module A3, A4
		ePPLDDCP_04,		// Parallel DC Load Module A4, A5
		ePPLDDCP_05,		// Parallel DC Load Module A5, A6
		ePPLDDCP_06,		// Parallel DC Load Module A1, A2, A3
		ePPLDDCP_07,		// Parallel DC Load Module A2, A3, A4
		ePPLDDCP_08,		// Parallel DC Load Module A3, A4, A5
		ePPLDDCP_09,		// Parallel DC Load Module A4, A5, A6
		ePPLDDCP_10,		// Parallel DC Load Module A1, A2, A3, A4
		ePPLDDCP_11,		// Parallel DC Load Module A2, A3, A4, A5
		ePPLDDCP_12,		// Parallel DC Load Module A3, A4, A5, A6
		ePPLDDCP_13,		// Parallel DC Load Module A1, A2, A3, A4, A5
		ePPLDDCP_14,		// Parallel DC Load Module A2, A3, A4, A5, A6
		ePPLDDCP_15,		// Parallel DC Load Module A1, A2, A3, A4, A5, A6
		ePPLDHCONCUR,		// High Wattage Programmable Load Constant Current Mode
		// End Programmable Power Loads

		// Begin Waveform Digitizer and Waveform Digitizer Distribution
		eWFRDA,				// Waveform Digitizer Channel A
		eWFRDB,				// Waveform Digitizer Channel B
		eWFRDC,				// Waveform Digitizer Channel C
		eWFRDD,				// Waveform Digitizer Channel D
		eWFRDA_INTDATA,		// Waveform Digitizer Channel A (internal data)
		eWFRDB_INTDATA,		// Waveform Digitizer Channel B (internal data)
		eWFRDC_INTDATA,		// Waveform Digitizer Channel C (internal data)
		eWFRDD_INTDATA,		// Waveform Digitizer Channel D (internal data)
		eWFRDA_02_ADD,		// Waveform Digitizer Addition Channel A (DC coupled)
		eWFRDB_02_ADD,		// Waveform Digitizer Addition Channel B (DC coupled)
		eWFRDC_02_ADD,		// Waveform Digitizer Addition Channel C (DC coupled)
		eWFRDD_02_ADD,		// Waveform Digitizer Addition Channel D (DC coupled)
		eWFRDA_02_SUBT,		// Waveform Digitizer Subtraction Channel A (DC coupled)  
		eWFRDB_02_SUBT,		// Waveform Digitizer Subtraction Channel B (DC coupled)  
		eWFRDC_02_SUBT,		// Waveform Digitizer Subtraction Channel C (DC coupled)  
		eWFRDD_02_SUBT,		// Waveform Digitizer Subtraction Channel D (DC coupled)  
		eWFRDA_02_MULT,		// Waveform Digitizer Multiplication Channel A (DC coupled)
		eWFRDB_02_MULT,		// Waveform Digitizer Multiplication Channel A (DC coupled)
		eWFRDC_02_MULT,		// Waveform Digitizer Multiplication Channel A (DC coupled)
		eWFRDD_02_MULT,		// Waveform Digitizer Multiplication Channel A (DC coupled)
		eWFRDA_03_ADD,		// Waveform Digitizer Addition Channel A (1 MOHM impedance)    
		eWFRDB_03_ADD,		// Waveform Digitizer Addition Channel B (1 MOHM impedance)    
		eWFRDC_03_ADD,		// Waveform Digitizer Addition Channel C (1 MOHM impedance)    
		eWFRDD_03_ADD,		// Waveform Digitizer Addition Channel D (1 MOHM impedance)    
		eWFRDA_03_SUBT,		// Waveform Digitizer Subtraction Channel A (1 MOHM impedance)
		eWFRDB_03_SUBT,		// Waveform Digitizer Subtraction Channel B (1 MOHM impedance)
		eWFRDC_03_SUBT,		// Waveform Digitizer Subtraction Channel C (1 MOHM impedance)
		eWFRDD_03_SUBT,		// Waveform Digitizer Subtraction Channel D (1 MOHM impedance)
		eWFRDA_03_MULT,		// Waveform Digitizer Multiplication Channel A (1MOHM impedance)
		eWFRDB_03_MULT,		// Waveform Digitizer Multiplication Channel B (1MOHM impedance)
		eWFRDC_03_MULT,		// Waveform Digitizer Multiplication Channel C (1MOHM impedance)
		eWFRDD_03_MULT,		// Waveform Digitizer Multiplication Channel D (1MOHM impedance)
		eWFRDA_03_INVERT,	// Waveform Digitizer Invert Channel A 
		eWFRDB_03_INVERT,	// Waveform Digitizer Invert Channel B 
		eWFRDC_03_INVERT,	// Waveform Digitizer Invert Channel C 
		eWFRDD_03_INVERT,	// Waveform Digitizer Invert Channel D 
		// End Waveform Digitizer and Waveform Digitizer Distribution

		eLFCC,				// Low Frequency Calibrator

		// Begin DC Programmable Power Supplies 
		eDCPSLVA,			// Low Voltage DC Power Supply Type A No. 1
		eDCPSLVA_01,		// Low Voltage DC Power Supply Type A No. 2
		eDCPSLVA_02,		// Low Voltage DC Power Supply Type A No. 3
		eDCPSLVA_03,		// Low Voltage DC Power Supply Type A No. 4
		eDCPSLVA_04,		// Low Voltage DC Power Supply Type A No. 5
		eDCPSLVA_05,		// Low Voltage DC Power Supply Type A No. 6
		eDCPSLVA_06,		// Low Voltage DC Power Supply Type A No. 7
		eDCPSLVA_07,		// Low Voltage DC Power Supply Type A No. 8
		eDCPSLVB,			// Low Voltage DC Power Supply Type B
		eDCPSLVC,			// Low Voltage DC Power Supply Type C No. 1
		eDCPSLVC_01,		// Low Voltage DC Power Supply Type C No. 2
		eDCPSLVAP,			// Low Voltage DC Power Supply Type A Parallel Combo 'DCPSLVA#05' 'DCPSLVA#06' 'DCPSLVA#07'
		eDCPSLVAP_01,		// Low Voltage DC Power Supply Type A Parallel Combo 'DCPSLVA#05' 'DCPSLVA#06'
		eDCPSLVAP_02,		// Low Voltage DC Power SupplyType A Parallel Combo 'DCPSLVA#06' 'DCPSLVA#07'
		eDCPSLVAP_03,		// Low Voltage DC Power Supply Type A Parallel Combo 'DCPSLVA' 'DCPSLVA#01' 'DCPSLVA#02' 'DCPSLVA#03' 'DCPSLVA#04'
		eDCPSLVAP_04,		// Low Voltage DC Power Supply Type A Parallel Combo 'DCPSLVA' 'DCPSLVA#01' 'DCPSLVA#02' 'DCPSLVA#03'
		eDCPSLVAP_05,		// Low Voltage DC Power Supply Type A Parallel Combo 'DCPSLVA' 'DCPSLVA#01' 'DCPSLVA#02'
		eDCPSLVAP_06,		// Low Voltage DC Power Supply Type A Parallel Combo 'DCPSLVA' 'DCPSLVA#01'
		eDCPSLVAP_07,		// Low Voltage DC Power Supply Type A Parallel Combo 'DCPSLVA#01' 'DCPSLVA#02' 'DCPSLVA#03''DCPSLVA#04'
		eDCPSLVAP_08,		// Low Voltage DC Power SupplyType A Parallel Combo 'DCPSLVA#01' 'DCPSLVA#02' 'DCPSLVA#03'
		eDCPSLVAP_09,		// Low Voltage DC Power Supply Type A Parallel Combo 'DCPSLVA#01' 'DCPSLVA#02'
		eDCPSLVAP_10,		// Low Voltage DC Power Supply Type A Parallel Combo 'DCPSLVA#02' 'DCPSLVA#03' 'DCPSLVA#04'
		eDCPSLVAP_11,		// Low Voltage DC Power Supply Type A Parallel Combo 'DCPSLVA#02' 'DCPSLVA#03'
		eDCPSLVAP_12,		// Low Voltage DC Power Supply Type A Parallel Combo 'DCPSLVA#03' 'DCPSLVA#04'
		eDCPSLVCP,			// Low Voltage DC Power Supply Type C Parallel Combo 'DCPSLVC' 'DCPSLVC#01'
		// End DC Programmable Power Supplies 

		// Begin Arbitrary Waveform Generator
		eAWFGA,				// Arbitrary Waveform Generator Channel A
		eAWFGB,				// Arbitrary Waveform Generator Channel B
		eAWFGM,				// Arbitrary Waveform Generator Cchannel A multiplexed with Channel B
		// End Arbitrary Waveform Generator

		eCOMMIF,			// Communications Interface

		// Begin Synchro Generator/Measurement
		eSGMA_01,			// Synchro Generator/Measurement No. 1
		eSGMA_02,			// Synchro Generator/Measurement No. 2
		eSGMA_03,			// Synchro Generator/Measurement No. 3
		// End Synchro Generator/Measurement

		// Begin Video Pattern Generator
		eVPGSTTL,			// Video Pattern Generator TTL output
		eVPGSANA,			// Video Pattern Generator Analog output
		eVPGSNTSC,			// Video Pattern Generator NTSC/PAL TV output
		// End Video Pattern Generator

		// Begin RF Instrumentation: Microwave Transition Analyzer 
		eSSSA,				// RF Instrumentation: Microwave Transition Analyzer
		eSSSACAL,			// RF Instrumentation: Microwave Transition Analyzer Calibration
		eSSSANA,			// RF Instrumentation: HP Network Analyzer using the Microwave Transition Analyzer
		eSSSAPP,			// RF Instrumentation: Peak Power Measurement using the Microwave Transition Analyzer
		eSSSAVV,			// RF Instrumentation: HP Vector Voltmeter Measurement using the HP Microwave Transition Analyzer
		eSSSAAP,			// RF Instrumentation: HP Array Processing using the Microwave Transition Analyzer
		eSSSASG,			// RF Instrumentation: Microwave Transition Analyzer Signal Generation
		eEXTTRIG1,			// RF Instrumentation: External Trigger 1  
		eEXTTRIG2,			// RF Instrumentation: RF External Trigger 2
		eSRCTRIGA,			// RF Instrumentation: Input Signal Channel A 
		eSRCTRIGB,			// RF Instrumentation: Input Signal Channel B
		// End RF Instrumentation: Microwave Transition Analyzer 

		// Begin RF Instrumentation: Power Meter And Spectrum Analyzer
		eHPPM1,				// RF Instrumentation: Power Meter 1
		eHPPM2,				// RF Instrumentation: Power Meter 2
		eHPPM1AZ,			// RF Instrumentation: Power Meter And Spectrum Analyzer 1
		eHPPM2AZ,			// RF Instrumentation: Power Meter And Spectrum Analyzer 2
		eHPPM1CAL,			// RF Instrumentation: Power Meter 1 Calibration
		eHPPM2CAL,			// RF Instrumentation: Power Meter 1 Calibration
		// End Begin RF Instrumentation: Power Meter And Spectrum Analyzer

		// Begin RF Instrumentation: Frequency Synthesizer
		eHPSG2,				// RF Instrumentation: Frequency Synthesizer 40 GHz
		eHPSG3,				// RF Instrumentation: Frequency Synthesizer 20 GHz
		// End RF Instrumentation: Frequency Synthesizer

		// Begin RF Instrumentation: Spread Spectrum
		eGCG1,				// RF Instrumentation: Spread Spectrum, Generic Code Generator Number 1
		eGCG2,				// RF Instrumentation: Spread Spectrum, Generic Code Generator Number 2
		eGCG4,				// RF Instrumentation: Spread Spectrum, Generic Code Generator Number 4
		// End RF Instrumentation: Spread Spectrum

		// Begin Air Data Test System
		ePFGA,				// Air Data Test System 
		ePFGAZ,				// Air Data Test System Zero Point Calibration
		ePFGAM,				// Air Data Test System Mid Point Calibration 
		ePFGAF,				// Air Data Test System Full Point Calibration 
		ePFGA_MM,			// Air Data Test System Measurement Mode 
		// End Air Data Test System

		// Begin - Advanced Communication Bus Interface (ACBI)
		eRS485,				// Advanced Communication Bus Interface - RS485 
		eRS485A,			// Advanced Communication Bus Interface - RS485 A
		eRS485B,			// Advanced Communication Bus Interface - RS485 B
		eRS485C,			// Advanced Communication Bus Interface - RS485 C
		eRS485AC,			// Advanced Communication Bus Interface - RS485 AC
		eRS485BC,			// Advanced Communication Bus Interface - RS485 BC
		eDDCMPA,			// Advanced Communication Bus Interface - DDCMP A
		eDDCMPB,			// Advanced Communication Bus Interface - DDCMP B
		eDDCMPAC,			// Advanced Communication Bus Interface - DDCMP AC
		eDDCMPBC,			// Advanced Communication Bus Interface - DDCMP BC
		e485M,				// Advanced Communication Bus Interface - 485M
		e485MA,				// Advanced Communication Bus Interface - 485M A
		e485MB,				// Advanced Communication Bus Interface - 485M B
		e485MC,				// Advanced Communication Bus Interface - 485M C
		e485MAC,			// Advanced Communication Bus Interface - 485M AC
		e485MBC,			// Advanced Communication Bus Interface - 485M BC
		eHARPNA,			// Advanced Communication Bus Interface - HARPN A
		eHARPNB,			// Advanced Communication Bus Interface - HARPN B
		eHARPNAC,			// Advanced Communication Bus Interface - HARPN AC
		eHARPNBC,			// Advanced Communication Bus Interface - HARPN BC
		eSLAMA,				// Advanced Communication Bus Interface - SLAM A
		eSLAMB,				// Advanced Communication Bus Interface - SLAM B
		eSLAMAC,			// Advanced Communication Bus Interface - SLAM AC
		eSLAMBC,			// Advanced Communication Bus Interface - SLAM BC
		// End - Advanced Communication Bus Interface (ACBI)

		// Begin - Triggering 
		eSYSTRIG1,			// System Trigger Bus 1
		eSYSTRIG2,			// System Trigger Bus 2
		eEXTTRIG,			// External Trigger
		eINTTRIG,			// Internal Trigger
		eLOCTRIG1,			// Local Trigger Bus 1
		eLOCTRIG2,			// Local Trigger Bus 2
		eTRIGREF,			// User-Defined Trigger
		// End - Triggering 

		// Begin Electro-Optical Subsystem Plus (EOSP)
		eEOSP,				// Entire Electro-Optical Subsystem Plus
		eEOSPSOURCE,		// Entire Electro-Optical Subsystem Plus Source
		eEOSPIRSRC,			// Electro-Optical Subsystem Plus IR Source Only
		eEOSPLST,			// Electro-Optical Subsystem Plus IR LST Only
		eEOSPTVSRC,			// Electro-Optical Subsystem Plus IRVisible Source Only
		eEOSPWFOVUS,		// Electro-Optical Subsystem Plus IRWFOVUS Only   
		EOSPSOURCE_T1,		// Electro-Optical Subsystem Plus IRGenerated Primary Target 
		EOSPLZSRC_T1,		// Electro-Optical Subsystem Plus IRLaser Source Only 
		eEOSPIR,			// Electro-Optical Subsystem Plus IRIR Only 
		eEOSPIRMSB,			// Electro-Optical Subsystem Plus IRIR MSB Only
		eEOSPVID,			// Electro-Optical Subsystem Plus IRVideo Only
		eEOSPTV,			// Electro-Optical Subsystem Plus IRVisible Only 
		eEOSPTVMSB,			// Electro-Optical Subsystem Plus IRVisible MSB Only 
		eEOSPAC,			// Electro-Optical Subsystem Plus IRAutocollimation Only 
		eEOSPFPA,			// Electro-Optical Subsystem Plus IRFPA Only 
		eEOSPLZ,			// Electro-Optical Subsystem Plus IRLaser Only    
		// End Electro-Optical Subsystem Plus (EOSP)

		// Begin High Power Device Test Set
		eHPDTAPU,			// High Power Device Test Set: AC Power Unit 
		eHPDTLCU,			// High Power Device Test Set: Liquid Cooling Unit 
		eHPDTDA,			// High Power Device Test Set: ITA Digital to Analog Convertor 
		eHPDTAD,			// High Power Device Test Set: ITA Analog to Digital Converter 
		eHPDTRY,			// High Power Device Test Set: SITA Relay
		eHPDTITA,			// High Power Device Test Set: SITA
		eHPDTDO,			// High Power Device Test Set: ITA Discrete Output
		eHPDTDI,			// High Power Device Test Set: ITA Discrete Input
		eHPDTBSTM,			// High Power Device Test Set: SITA Interface Bus Stimulus
		eHPDTBRSP,			// High Power Device Test Set: SITA Interface Bus Response
		eHPDTRHM,			// High Power Device Test Set: Radiation Hazard Monitor
		eHPDTCMTR,			// High Power Device Test Set: Calorimeter
		// End High Power Device Test Set

		// Begin - Bus Test Instrument
		eRS_232_C,			// Bus Test Instrument: RS-232-C
		eRS_232_CN,			// Bus Test Instrument: RS-232-CN
		eRS_232_D,			// Bus Test Instrument: RS-232-D
		eRS_232_DN,			// Bus Test Instrument: RS-232-DN
		eRS_422_C,			// Bus Test Instrument: RS-422-C
		eRS_422_CN,			// Bus Test Instrument: RS-422-CN
		eRS_422_D,			// Bus Test Instrument: RS-422-D
		eRS_422_DN,			// Bus Test Instrument: RS-422-DN
		eARINC_429_C,		// Bus Test Instrument: ARINC-429-C
		eARINC_429_CN,		// Bus Test Instrument: ARINC-429-CN
		eARINC_429_D,		// Bus Test Instrument: ARINC-429-D
		eARINC_429_DN,		// Bus Test Instrument: ARINC-429-DN
		eMIL_STD_1553A_C,	// Bus Test Instrument: MIL-STD-1553A-C
		eMIL_STD_1553A_D,	// Bus Test Instrument: MIL-STD-1553A-D
		eMIL_STD_1553B_C,	// Bus Test Instrument: MIL-STD-1553B-C
		eMIL_STD_1553B_D,	// Bus Test Instrument: MIL-STD-1553B-D
		eMIL_STD_1553A_CN,	// Bus Test Instrument: MIL-STD-1553A-CN
		eMIL_STD_1553A_DN,	// Bus Test Instrument: MIL-STD-1553A-DN
		eMIL_STD_1553B_CN,	// Bus Test Instrument: MIL-STD-1553B-CN
		eMIL_STD_1553B_DN,	// Bus Test Instrument: MIL-STD-1553B-DN
		eBTI_RS485A,		// Bus Test Instrument: BTI-RS485A
		eBTI_RS485B,		// Bus Test Instrument: BTI-RS485B
		eBTI_RS485,			// Bus Test Instrument: BTI-RS485
		eBTI_RS485C,		// Bus Test Instrument: BTI-RS485C
		eBTI_RS485AC,		// Bus Test Instrument: BTI-RS485AC
		eBTI_RS485BC,		// Bus Test Instrument: BTI-RS485BC
		// End - Bus Test Instrument

		eMCI,				// Modulation Control Interface

		// Begin - MAC PCEXEC
		eATI,				// MAC PCEXEC Analog Test Instrument

		// Begin - Bus Test Instrument
		eARINC429,			// MAC PCEXEC Bus Test Instrument: ARINC429
		eMS1553,			// MAC PCEXEC Bus Test Instrument: MS1553
		eRS232,				// MAC PCEXEC Bus Test Instrument: RS232
		eRS422,				// MAC PCEXEC Bus Test Instrument: RS422
		// End - Bus Test Instrument

		eACPS,				// MAC PCEXEC AC Power Supply
		eAWFG,				// MAC PCEXEC Arbitrary Waveform Generator
		eCSSG,				// MAC PCEXEC Comstron Signal Generator
		eDCPS,				// MAC PCEXEC DC Programmable Power Supply
		eDTU,				// MAC PCEXEC Digital Test Unit
		eFTIC,				// MAC PCEXEC Frequency Time Interval Counter
		eGPI,				// MAC PCEXEC General Purpose Interface
		eHPPM,				// MAC PCEXEC Hewlett Packard Power Meter
		eHPSA,				// MAC PCEXEC Hewlett Packard Signal Analyzer 
		eHPSG,				// MAC PCEXEC Hewlett Packard Signal Generator 
		eLFC,				// MAC PCEXEC Low Frequency Calibration
		ePGEN,				// MAC PCEXEC Pulse Generator
		ePPL,				// MAC PCEXEC Programmable Power Loads
		eSGMA,				// MAC PCEXEC Syncho Generation/Measurement Assembly
		eSTRG,				// MAC PCEXEC System Trigger
		eVPG,				// MAC PCEXEC Video Pattern Generator
		eWFRD				// MAC PCEXEC Waveform Digitizer 
		// End - MAC PCEXEC

		// NOTE: The ending enum is used in FOR loops, make sure to update loops
	};  // enum eInstrument

	static bool IsFileClass( const eInstrumentClass eClass );
	static bool IsDeviceClass( const eInstrumentClass eClass );
	static bool IsVideoClass( const eInstrumentClass eClass );

	static eInstrument GetInstrument( const string& strSystemName, const bool bFindClosest, string* pstrCassName = 0 );
	static string GetInstrumentName( eInstrument e );
	static string GetInstrumentDescription( eInstrument e );
	static eInstrumentClass GetInstrumentClass( eInstrument e );

	static eInstrumentClass GetInstrumentClassEnum( const string& strClassName );
	static string GetInstrumentClass( const eInstrumentClass eClass );
	static string GetInstrumentClassDescription( const eInstrumentClass eClass );

protected:

	struct CCI // [C]ASS [C]lass [I]nformation
	{
		CCI( const string& strClassName, const string& strClassDescription ) : 
			m_strClassName( strClassName ), 
			m_strClassDescription( strClassDescription )
		{ }

		string m_strClassName;
		string m_strClassDescription;
	};
	static const CCI m_arrayInstrumentClass[ ];

	struct CII // [C]ASS [I]nstrument [I]nformation
	{
		CII( const string& strSystemName, const eInstrumentClass eInstrumentClass, const string& strSystemNameDescription ) : 
			m_strSystemName( strSystemName ), 
			m_strSystemNameDescription( strSystemNameDescription ), 
			m_eInstrumentClass( eInstrumentClass )
		{ }

		string m_strSystemName;
		string m_strSystemNameDescription;
		eInstrumentClass m_eInstrumentClass;
	};
	static const CII m_arrayInstrument[ ];


	static const bool m_bInitAll;

	static bool InitAll( void );
	static void InitInstrumentClasses( void );
	static void InitInstruments( void );

	static map< const string*, eInstrument, AIXMLHelper::cmpPointer > m_mapInstrumentTypes;
	static map< eInstrument, const string* > m_mapInstrumentEnumToName;
	static map< eInstrument, const string* > m_mapInstrumentEnumToDescription;
	static map< eInstrument, eInstrumentClass > m_mapInstrumentEnumInstrumentClassEnum;

	static map< const string*, eInstrumentClass, AIXMLHelper::cmpPointer > m_mapInstrumentClasses;
	static map< eInstrumentClass, const string* > m_mapInstrumentClassEnumToName;
	static map< eInstrumentClass, const string* > m_mapInstrumentClassEnumToDescription;
};