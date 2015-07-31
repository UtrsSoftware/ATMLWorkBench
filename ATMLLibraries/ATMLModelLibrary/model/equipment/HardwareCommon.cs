/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Text;
using System.Text.RegularExpressions;
using ATMLDataAccessLibrary.model;
using ATMLModelLibrary.interfaces;
using ATMLModelLibrary.model.common;
using ATMLSchemaLibrary.managers;
using ATMLUtilitiesLibrary;

namespace ATMLModelLibrary.model.equipment
{

    public partial class FacilitiesRequirements
    {
        public bool Validate(SchemaValidationResult errors)
        {
            object testSubject = this;
            return SchemaManager.Validate("urn:IEEE-1671:2010:HardwareCommon", "FacilitiesRequirements", testSubject, errors);
        }
    }

    public partial class Specifications
    {
        public bool Validate(SchemaValidationResult errors)
        {
            object testSubject = this;
            return SchemaManager.Validate("urn:IEEE-1671:2010:HardwareCommon", "Specifications", testSubject, errors);
        }
    }

    public partial class Switching
    {
        public bool Validate(SchemaValidationResult errors)
        {
            object testSubject = this;
            return SchemaManager.Validate("urn:IEEE-1671:2010:HardwareCommon", "Switching", testSubject, errors);
        }
    }

    public partial class DriverPlatformOperatingSystem
    {
        public override string ToString()
        {
            return string.Format( "Service Pack:{0} : {1}", this._servicePack, base.ToString() );
        }
    }

    public abstract partial class Driver
    {
        public override string ToString()
        {
            return string.Format( "{0} : {1} : {2}", this.GetType().Name,
                                  Enum.GetName( typeof (DriverItemChoiceType), this.ItemElementName ),
                                  this.Item );
        }
    }

    public partial class HardwareItemDescriptionControlDriver
    {
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (this._type != null)
                sb.Append( string.Format( "{0}", _type.ToString() ) );
            else
                sb.Append( base.ToString());
            return sb.ToString();
        }
    }

    public partial class DriverModule
    {
        public override string ToString()
        {
            return string.Format( "{0}", _fileName );
        }
    }

    public partial class DriverUnified
    {
        public override string ToString()
        {
            return string.Format("{0} : {1}, {2} : {3}", 
                                  Enum.GetName(typeof(DriverItemChoiceType), DriverItemChoiceType.Bit32), 
                                  this.Bit32,
                                  Enum.GetName(typeof(DriverItemChoiceType), DriverItemChoiceType.Bit64),
                                  this.Bit64);
        }
    }

    public partial class NetworkNodePath
    {
        public override string ToString()
        {
            return string.Format( "{0}",
                                  string.IsNullOrEmpty( _documentId )
                                      ? string.IsNullOrEmpty( _value ) ? "Unknown" : _value
                                      : _documentId );
        }
    }

    public partial class TestStationDescription11 : IAtmlObject
    {
        private bool? _deleted;

        public bool IsDeleted( bool? deleted = null )
        {
            if (deleted != null)
                _deleted = deleted;
            return _deleted ?? false;
        }

        public string GetAtmlId()
        {
            return uuid;
        }

        public string GetAtmlName()
        {
            return Identification.ModelName;
        }

        public string GetAtmlFileName()
        {
            return string.Concat( GetAtmlName(), ATMLContext.ATML_STATION_FILENAME_SUFFIX );
        }

        public string GetAtmlFileContext()
        {
            return ATMLContext.CONTEXT_TYPE_XML;
        }

        public dbDocument.DocumentType GetAtmlDocumentType()
        {
            return dbDocument.DocumentType.TEST_STATION_DESCRIPTION;
        }

        public AtmlFileType GetAtmlFileType()
        {
            return AtmlFileType.AtmlTypeTestStation;
        }

        public new bool Validate( SchemaValidationResult errors )
        {
            object testSubject = this;
            return SchemaManager.Validate( TestStationNameSpace, "TestStationDescription", testSubject, errors );
        }
    }

    //[XmlTypeAttribute(Namespace = "urn:IEEE-1671:2010:HardwareCommon")]
    public partial class Trigger
    {
        public bool Validate( SchemaValidationResult errors )
        {
            object testSubject = this;
            return SchemaManager.Validate( ATMLCommon.HardwareCommonNameSpace, "Trigger", testSubject, errors );
        }
    }


    public partial class TestEquipmentTerminalBlocks
    {
        public bool Validate( SchemaValidationResult errors )
        {
            object testSubject = this;
            return SchemaManager.Validate( ATMLCommon.TestEquipmentNameSpace, "TerminalBlocks", testSubject,
                                           errors );
        }
    }

    public partial class TestEquipmentTerminalBlocksTerminalBlock
    {
        public new bool Validate( SchemaValidationResult errors )
        {
            object testSubject = this;
            return SchemaManager.Validate( ATMLCommon.TestEquipmentNameSpace, "TerminalBlock", testSubject,
                                           errors );
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append( name );
            return string.Format( sb.ToString() );
        }
    }

    public partial class HardwareItemDescriptionControlTool
    {
        public new bool Validate( SchemaValidationResult errors )
        {
            object testSubject = this;
            return SchemaManager.Validate( ATMLCommon.HardwareCommonNameSpace, GetType().Name, testSubject,
                                           errors );
        }
    }

    public partial class VersionIdentifier
    {
        public bool Validate( SchemaValidationResult errors )
        {
            object testSubject = this;
            return SchemaManager.Validate( ATMLCommon.HardwareCommonNameSpace, GetType().Name,
                                           testSubject, errors );
        }

        public override string ToString()
        {
            return string.Format( "Version: {0} {1}", this._version, Enum.GetName( typeof (VersionIdentifierQualifier), _qualifier ) );
        }
    }

    public partial class Path
    {
        public override string ToString()
        {
            var sb = new StringBuilder();
            if (_pathNodes != null)
            {
                foreach (PathNode pathNode in _pathNodes)
                {
                    sb.Append( pathNode.Path.Value ).Append( " → " );
                }
                if (sb.ToString().EndsWith( " → " ))
                    sb.Length = sb.Length - 3;
            }
            return string.Format( sb.ToString() );
        }

        public bool Validate( SchemaValidationResult errors )
        {
            object testSubject = this;
            return SchemaManager.Validate( ATMLCommon.TestEquipmentNameSpace, GetType().Name, testSubject,
                                           errors );
        }
    }

    public partial class Capabilities
    {
        public void Save()
        {
            if (_items != null)
            {
                foreach (object item in _items)
                {
                    if (item is Capability)
                    {
                    }
                    else if (item is DocumentReference)
                    {
                    }
                }
            }
        }

        public bool Validate(SchemaValidationResult errors)
        {
            object testSubject = this;
            return SchemaManager.Validate("urn:IEEE-1671:2010:HardwareCommon", "Capabilities", testSubject, errors);
        }

        public override string ToString()
        {
            return string.Format( "Capability Count: {0}, Mapping Count: {1}",
                                  Items != null ? Items.Count : 0,
                                  CapabilityMap != null ? CapabilityMap.Count : 0 );
        }
    }

    public partial class Capability
    {
        public override string ToString()
        {
            return string.IsNullOrEmpty( name ) ? base.ToString() : name;
        }

        public bool Validate( SchemaValidationResult errors )
        {
            object testSubject = this;
            return SchemaManager.Validate( ATMLCommon.HardwareCommonNameSpace, GetType().Name, testSubject,
                                           errors );
        }
    }

    public partial class PowerSpecificationsAC
    {
        public override string ToString()
        {
            return string.Format( "AC Power - Voltage: {0}, Frequency:{1}, Power:{2}", _voltage, _frequency, _item );
        }

        public bool Validate( SchemaValidationResult errors )
        {
            object testSubject = this;
            return SchemaManager.Validate( ATMLCommon.HardwareCommonNameSpace, "AC", testSubject, errors );
        }
    }

    public partial class RepeatedItem
    {
        public bool Validate( SchemaValidationResult errors )
        {
            object testSubject = this;
            return SchemaManager.Validate( ATMLCommon.HardwareCommonNameSpace, "RepeatedItem", testSubject,
                                           errors );
        }
    }

    public partial class PowerSpecificationsDC
    {
        public bool Validate( SchemaValidationResult errors )
        {
            object testSubject = this;
            return SchemaManager.Validate( ATMLCommon.HardwareCommonNameSpace, "DC", testSubject, errors );
        }

        public override string ToString()
        {
            return string.Format( "DC Power - Voltage: {0}, Power:{1}", _voltage, _item );
        }
    }

    public partial class ControllerOperatingSystem
    {
        public override string ToString()
        {
            return string.Format( "{0} version:{1} description:{2}", name, version, Description );
        }

        public bool Validate( SchemaValidationResult errors )
        {
            object testSubject = this;
            return SchemaManager.Validate( TestEquipmentNameSpace, "OperatingSystem", testSubject,
                                           errors );
        }
    }

    public partial class HardwareItemDescriptionControlToolDriver
    {
        public override string ToString()
        {
            const string type = "Driver";
            return string.Format( "{0}", type );
        }

        public bool Validate( SchemaValidationResult errors )
        {
            object testSubject = this;
            return SchemaManager.Validate( ATMLCommon.HardwareCommonNameSpace, "Driver", testSubject, errors );
        }
    }

    public partial class HardwareItemDescriptionControlToolSoftware
    {
        public override string ToString()
        {
            const string type = "Software";
            return string.Format( "{0}", type );
        }

        public bool Validate( SchemaValidationResult errors )
        {
            object testSubject = this;
            return SchemaManager.Validate( ATMLCommon.HardwareCommonNameSpace, "Software", testSubject,
                                           errors );
        }
    }

    public abstract partial class ControlLanguage
    {
        public override string ToString()
        {
            string type = GetType().Name;
            return string.Format( "{0} {1}", type, _documentation != null ? _documentation.name : "" );
        }
    }

    public partial class Generic
    {
        public bool Validate( SchemaValidationResult errors )
        {
            object testSubject = this;
            return SchemaManager.Validate( ATMLCommon.HardwareCommonNameSpace, "Generic", testSubject,
                                           errors );
        }
    }

    public partial class Register
    {
        public bool Validate( SchemaValidationResult errors )
        {
            object testSubject = this;
            return SchemaManager.Validate( ATMLCommon.HardwareCommonNameSpace, "Register", testSubject,
                                           errors );
        }
    }


    public partial class SCPI
    {
        public bool Validate( SchemaValidationResult errors )
        {
            object testSubject = this;
            return SchemaManager.Validate( ATMLCommon.HardwareCommonNameSpace, "SCPI", testSubject,
                                           errors );
        }
    }


    public partial class HardwareItemDescriptionComponent
    {
        public string XPath
        {
            get { return "hd:Component"; }
        }

        public override string ToString()
        {
            return this.Item == null ? "" : Item.ToString();
        }


        public bool Validate( SchemaValidationResult errors )
        {
            object testSubject = this;
            return SchemaManager.Validate( ATMLCommon.HardwareCommonNameSpace, "Component", testSubject,
                                           errors );
        }
    }


    public partial class Mapping
    {
        public override string ToString()
        {
            var sb = new StringBuilder();
            if (_map != null && _map.Count > 0)
            {
                foreach (Network network in _map)
                {
                    sb.Append( network ).Append( ", " );
                }
            }

            if (sb.ToString().EndsWith(", "))
                sb.Length = sb.Length - 2;

            if (sb.Length == 0)
                sb.Append( "[No Nodes have been added]" );

            return sb.ToString();
        }
    }


    public partial class Network
    {
        public override string ToString()
        {
            var sb = new StringBuilder();
            if (Node != null)
            {
                foreach (NetworkNode networkNode in Node)
                {
                    sb.Append( networkNode ).Append( " → " );
                }
                if (sb.ToString().EndsWith( " → " ))
                    sb.Length = sb.Length - 3;
            }
            else
            {
                sb.Append( "[No Nodes have been added]" );
            }

            return sb.ToString();
        }
    }

    public partial class NetworkNode
    {
        public override string ToString()
        {
            return Path != null ? ExtractPathValues( Path.Value ) : "[Invalid Path]";
        }

        public static string ExtractPathValues( string path )
        {
            var sb = new StringBuilder();
            int i = 0;
            path = path.Replace( "'", "\"" );
            foreach (Match match in Regex.Matches( path, "\"([^\"]*)\"" ))
            {
                if (i > 0)
                    sb.Append( " [ " );
                sb.Append( match.ToString().Replace( "\"", "" ) );
                if (i++ > 0)
                    sb.Append( " ]" );
            }
            if (sb.Length == 0)
                sb.Append( path );
            return sb.ToString();
        }
    }


    public partial class Resource
    {
        public override string ToString()
        {
            return name;
        }

        public bool Validate( SchemaValidationResult errors )
        {
            object testSubject = this;
            return SchemaManager.Validate( ATMLCommon.HardwareCommonNameSpace, "Resource", testSubject,
                                           errors );
        }
    }

    public abstract partial class TriggerPropertyGroup
    {
        public override string ToString()
        {
            return name;
        }

        public bool Validate( SchemaValidationResult errors )
        {
            object testSubject = this;
            return SchemaManager.Validate( ATMLCommon.HardwareCommonNameSpace, "TriggerPropertyGroup",
                                           testSubject, errors );
        }
    }

    public partial class LXI
    {
        public override string ToString()
        {
            var sb = new StringBuilder();
            if (!String.IsNullOrEmpty( defaultAddress ))
                sb.Append( "addr:" ).Append( defaultAddress ).Append( " " );
            sb.Append( "dhcp:" ).Append( supportsDHCP ? "Yes" : "No" ).Append( " " );
            sb.Append( "ver:" ).Append( LXIVersion ).Append( " " );
            sb.Append( "class:" ).Append( @class ).Append( " " );
            return sb.ToString();
        }
    }

    public partial class USB
    {
        public override string ToString()
        {
            var sb = new StringBuilder();
            if (!String.IsNullOrEmpty( defaultAddress ))
                sb.Append( "addr:" ).Append( defaultAddress ).Append( " " );
            if (!String.IsNullOrEmpty( Version.name ))
                sb.Append( "name:" ).Append( Version.name ).Append( " " );
            sb.Append( "ver:" ).Append( Version.version ).Append( " " );
            sb.Append( "qual:" )
              .Append( Enum.GetName( typeof (VersionIdentifierQualifier), Version.qualifier ) )
              .Append( " " );
            return sb.ToString();
        }
    }

    public partial class VME
    {
        public override string ToString()
        {
            var sb = new StringBuilder();
            if (!String.IsNullOrEmpty( defaultAddress ))
                sb.Append( "addr:" ).Append( defaultAddress ).Append( " " );
            else
                sb.Append( "VME Bus" );
            return sb.ToString();
        }
    }

    public partial class Ethernet
    {
        public override string ToString()
        {
            var sb = new StringBuilder();
            if (!String.IsNullOrEmpty( defaultAddress ))
                sb.Append( "addr:" ).Append( defaultAddress ).Append( " " );
            sb.Append( "dhcp:" ).Append( supportsDHCP ? "Yes" : "No" ).Append( " " );
            return sb.ToString();
        }
    }


    public partial class PCI
    {
        public override string ToString()
        {
            var sb = new StringBuilder();
            if (!String.IsNullOrEmpty( defaultAddress ))
                sb.Append( "addr:" ).Append( defaultAddress ).Append( " " );
            sb.Append( "vendor:" ).Append( vendorID ).Append( " " );
            sb.Append( "device:" ).Append( deviceID ).Append( " " );
            return sb.ToString();
        }
    }

    public partial class PCIe
    {
        public override string ToString()
        {
            var sb = new StringBuilder();
            if (!String.IsNullOrEmpty( defaultAddress ))
                sb.Append( "addr:" ).Append( defaultAddress ).Append( " " );
            sb.Append( "vendor:" ).Append( vendorID ).Append( " " );
            sb.Append( "device:" ).Append( deviceID ).Append( " " );
            sb.Append( "lanes:" ).Append( numberOfLanes ).Append( " " );
            return sb.ToString();
        }
    }

    public partial class EIA232
    {
        public override string ToString()
        {
            var sb = new StringBuilder();
            if (!String.IsNullOrEmpty( defaultAddress ))
                sb.Append( "addr:" ).Append( defaultAddress ).Append( " " );
            return sb.ToString();
        }
    }

    public partial class IEEE1394
    {
        public override string ToString()
        {
            var sb = new StringBuilder();
            if (!String.IsNullOrEmpty( defaultAddress ))
                sb.Append( "addr:" ).Append( defaultAddress ).Append( " " );
            return sb.ToString();
        }
    }

    public partial class IEEE488
    {
        public override string ToString()
        {
            var sb = new StringBuilder();
            if (!String.IsNullOrEmpty( defaultAddress ))
                sb.Append( "addr:" ).Append( defaultAddress ).Append( " " );
            return sb.ToString();
        }
    }

    public partial class PXI
    {
        public override string ToString()
        {
            var sb = new StringBuilder();
            if (!String.IsNullOrEmpty( defaultAddress ))
                sb.Append( "addr:" ).Append( defaultAddress ).Append( " " );
            sb.Append( "vendor:" ).Append( vendorID ).Append( " " );
            sb.Append( "device:" ).Append( deviceID ).Append( " " );
            sb.Append( "slots:" ).Append( slots ).Append( " " );
            if (_supportedClockSources.@internal
                || _supportedClockSources.external
                || _supportedClockSources.backplane)
            {
                sb.Append( "clocks:" );
                if (_supportedClockSources.@internal)
                    sb.Append( "internal " );
                if (_supportedClockSources.external)
                    sb.Append( "external " );
                if (_supportedClockSources.backplane)
                    sb.Append( "backplane " );
            }

            return sb.ToString();
        }
    }

    public partial class PXIe
    {
        public override string ToString()
        {
            var sb = new StringBuilder();
            if (!String.IsNullOrEmpty( defaultAddress ))
                sb.Append( "addr:" ).Append( defaultAddress ).Append( " " );
            sb.Append( "vendor:" ).Append( vendorID ).Append( " " );
            sb.Append( "device:" ).Append( deviceID ).Append( " " );
            sb.Append( "slots:" ).Append( slots ).Append( " " );
            sb.Append( "lanes:" ).Append( numberOfLanes ).Append( " " );
            if (SupportedClockSources.@internal
                || SupportedClockSources.external
                || SupportedClockSources.backplane)
            {
                sb.Append( "clocks:" );
                if (SupportedClockSources.@internal)
                    sb.Append( "internal " );
                if (SupportedClockSources.external)
                    sb.Append( "external " );
                if (SupportedClockSources.backplane)
                    sb.Append( "backplane " );
            }

            return sb.ToString();
        }
    }

    public partial class VXI
    {
        public override string ToString()
        {
            var sb = new StringBuilder();
            if (!String.IsNullOrEmpty( defaultAddress ))
                sb.Append( "addr:" ).Append( defaultAddress ).Append( " " );
            sb.Append( "addr:" ).Append( _addressSpace ).Append( " " );
            sb.Append( "class:" ).Append( _deviceClass ).Append( " " );
            sb.Append( "mfg:" ).Append( manufacturerID ).Append( " " );
            sb.Append( "mod:" ).Append( modelCode ).Append( " " );
            sb.Append( "slots:" ).Append( slots ).Append( " " );
            if (_supportedClockSources.@internal
                || _supportedClockSources.external
                || _supportedClockSources.backplane)
            {
                sb.Append( "clocks:" );
                if (_supportedClockSources.@internal)
                    sb.Append( "internal " );
                if (_supportedClockSources.external)
                    sb.Append( "external " );
                if (_supportedClockSources.backplane)
                    sb.Append( "backplane " );
            }

            return sb.ToString();
        }
    }
}