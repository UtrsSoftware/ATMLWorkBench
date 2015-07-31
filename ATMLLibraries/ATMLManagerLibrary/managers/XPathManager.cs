/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Collections.Generic;
using ATMLModelLibrary.model.common;
using ATMLModelLibrary.model.equipment;
using ATMLModelLibrary.model.uut;

namespace ATMLManagerLibrary.managers
{
    public class XPathManager
    {
        public static string DeterminePathName(object obj)
        {
            String path = "";
            if (obj is HardwareUUT)
                path = "uut:Hardware";
            else if (obj is SoftwareUUT)
                path = "uut:Software";
            else if (obj is TestAdapterDescription1 || obj is TestAdapterDescription )
                path = "tad:TestAdapterDescription";
            else if (obj is InstrumentDescription)
                path = "inst:InstrumentDescription";
            else if (obj is TestStationDescription11 || obj is TestStationDescription )
                path = "tsd:TestStationDescription";
            else if (obj is List<Resource>)
                path = "inst:Resources";
            else if (obj is Resource)
                path = "hc:Resource";
            else if (obj is Interface)
                path = "hc:Interface";
            else if (obj is Capabilities)
                path = "inst:Capabilities";
            else if (obj is Capability)
                path = "hc:Capability";
            else if (obj is TestEquipmentTerminalBlocks)
                path = "he:TerminalBlocks";
            else if (obj is TestEquipmentTerminalBlocksTerminalBlock)
                path = "he:TerminalBlock";
            else if (obj is HardwareItemDescriptionComponent)
                path = "hc:Component";
            else if (obj is List<HardwareItemDescriptionComponent>)
                path = "hc:Components";
            else if (obj is Port )
                path = "c:Port";
            else if (obj is List<Port> || obj is List<PhysicalInterfacePortsPort>)
                path = "c:Ports";
            else if (obj is List<object>)
                path = "c:Interface";
            else if (obj is Switching)
                path = "te:Switching";
            else if (obj is Switch)
                path = "hc:Switch";
            return path;
        }
    }
}
