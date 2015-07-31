/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ATMLDataAccessLibrary.db.beans;

namespace ATMLDataAccessLibrary.model
{

    public class dbDocument : DocumentBean
    {
        public enum DocumentType
        {
            NONE,                           //  0
            INSTRUMENT_DESCRIPTION,         //  1
            CAPABILITY_LIBRARY,             //  2
            TEST_STATION_DESCRIPTION,       //  3
            TEST_ADAPTER_DESCRIPTION,       //  4
            UUT_DESCRIPTION,                //  5
            TEST_CONFIGURATION,             //  6
            TEST_DESCRIPTION,               //  7
            TRD,                            //  8
            TEST_PROGRAM_SET,               //  9
            WIRE_LIST,                      // 10
            SCHEMATIC,                      // 11
            GENERAL_DOCUMENTATION,          // 12
            PROCEDURE,                      // 13
            XML_STYLE_SHEET,                // 14
            TSR,                            // 15 - 
            OTPI,                           // 16 - 
            OTPM,                           // 17 - 
            TPI,                            // 18 - 
            TM,                             // 19 - 
            TEC,                            // 20 - 
            TSF_LIBRARY_INSTANCE,           // 21
            XML_SCHEMA,                     // 22
            XML_DATA,                       // 23
            SUP_SOFTWARE,                   // 24
            COMPONENT_DESCRIPTION           // 25
        }

        public dbDocument()
            : base()
        {
            UUID = Guid.NewGuid();
            IncludeKeyOnInsert = true;
        }

    }
}
