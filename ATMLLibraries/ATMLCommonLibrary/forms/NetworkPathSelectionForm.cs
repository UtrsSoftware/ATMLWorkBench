/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using ATMLManagerLibrary.managers;
using ATMLModelLibrary.model.common;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.forms
{
    public partial class NetworkPathSelectionForm : ATMLForm
    {
        private readonly HardwareItemDescription _hardwareItemDescription;
        private Mapping _mapping;

        public bool CapabilitiesOnly { set; get; }

        public NetworkPathSelectionForm(HardwareItemDescription hardwareItemDescription, bool capabilitiesOnly = false )
        {
            CapabilitiesOnly = capabilitiesOnly;
            _hardwareItemDescription = hardwareItemDescription;
            InitializeComponent();
            InitializeListView();
        }


        /**
         * Specifies which items in the check list should be checked in the case of the "set" and 
         * which items were checked in the case of the "get"
         */

        public List<string> CheckedNodePaths
        {
            get
            {
                var checkedNodes = new List<string>();
                foreach (ListViewItem lvi in lvNetworkPaths.CheckedItems)
                    checkedNodes.Add( lvi.Tag != null ? lvi.Tag.ToString() : "***" );
                return checkedNodes;
            }
            set
            {
                foreach (string checkedItem in value)
                {
                    foreach (ListViewItem lvi in lvNetworkPaths.Items)
                    {
                        //------------------------------------------------------------------------//
                        //--- Make sure we don't uncheck an item that has already been checked ---//
                        //------------------------------------------------------------------------//
                        if (lvi.Tag != null && checkedItem.Equals( lvi.Tag.ToString() ))
                        {
                            lvi.Checked = true;
                            break;
                        }
                    }
                }
            }
        }

        /**
         * Used when dealing with Capability Mappings. When this is used then only
         * Resources and Capability Ports should be used.
         *
         */
        public Mapping Mapping
        {
            get
            {
                ControlsToData();
                return _mapping;
            }
            set
            {
                _mapping = value;
                DataToControls();
            }
        }

        protected void DataToControls()
        {
        }

        protected void ControlsToData()
        {
        }

        private void InitializeListView()
        {
            lvNetworkPaths.Columns.Add( "Network Node" );
            lvNetworkPaths.Resize += lvNetworkPaths_Resize;
            if (_hardwareItemDescription != null)
            {
                string typeName = _hardwareItemDescription.GetType().Name;
                lvNetworkPaths.Groups.Add( new ListViewGroup( typeName, typeName ) );
                if (!CapabilitiesOnly)
                {
                    ProcessHardwareItemInterfaces( typeName );
                    ProcessHardwareItemComponents();
                }
                ProcessHardwareItemResources();
                ProcessHardwareItemObjects();
            }
            SetColumns();
        }


        private void ProcessHardwareItemObjects()
        {
            var instrumentDescription = _hardwareItemDescription as InstrumentDescription;
            var testStationDescription = _hardwareItemDescription as TestStationDescription11;
            var testAdapterDescription = _hardwareItemDescription as TestAdapterDescription;
            if (instrumentDescription != null)
                ProcessInstrumentPath( instrumentDescription );
            else if (testStationDescription != null)
                ProcessTestStationPath( testStationDescription );
            else if (testAdapterDescription != null)
                ProcessTestAdapterPath( testAdapterDescription );
        }


        /**
         * Called when the Hardware Description is an Instrument.
         */

        private void ProcessInstrumentPath( InstrumentDescription instrumentDescription )
        {
            Capabilities capabilities = instrumentDescription.Capabilities;
            ProcessCapabilitites( capabilities );
            if( !CapabilitiesOnly )
                ProcessHardwareItemSwitching( instrumentDescription.Switching );
        }

        /**
         * Called when the Hardware Description is a Test Station.
         */

        private void ProcessTestStationPath( TestStationDescription11 testStationDescription )
        {
            Capabilities capabilities = testStationDescription.Capabilities;
            ProcessCapabilitites( capabilities );
            if (!CapabilitiesOnly)
                ProcessHardwareItemSwitching(testStationDescription.Switching);
        }

        /**
         * Called when the Hardware Description is a Test Adapter.
         */

        private void ProcessTestAdapterPath( TestAdapterDescription testAdapterDescription )
        {
            Capabilities capabilities = testAdapterDescription.Capabilities;
            TestEquipmentTerminalBlocks terminalBlocks = testAdapterDescription.TerminalBlocks;
            ProcessCapabilitites( capabilities );
            if (!CapabilitiesOnly)
            {
                ProcessTerminalBlocks( terminalBlocks );
                ProcessHardwareItemSwitching( testAdapterDescription.Switching );
            }
        }

        /**
         * Call to Add Terminal Blocks to the selection list view. Each item
         * in the list will hold an XPath representation of the Terminal Blocks.
         */

        private void ProcessTerminalBlocks( TestEquipmentTerminalBlocks terminalBlocks )
        {
            if (terminalBlocks != null)
            {
                var g = new ListViewGroup( "Terminal Blocks", "Terminal Blocks" );
                lvNetworkPaths.Groups.Add( g );
                foreach (TestEquipmentTerminalBlocksTerminalBlock terminalBlock in terminalBlocks.TerminalBlock)
                {
                    Interface tbInterface = terminalBlock.Interface;
                    if (tbInterface != null)
                    {
                        List<Port> ports = tbInterface.Ports;
                        if (ports != null)
                        {
                            foreach (Port port in ports)
                            {
                                var xpath = new StringBuilder( "//" );
                                xpath.Append( XPathManager.DeterminePathName( _hardwareItemDescription ) );
                                xpath.Append( "/" ).Append( XPathManager.DeterminePathName( terminalBlocks ) );
                                xpath.Append( "/" ).Append( XPathManager.DeterminePathName( terminalBlock ) );
                                xpath.Append( "[@name=\"" ).Append( terminalBlock.name ).Append( "\"]" );
                                xpath.Append( "/" ).Append( XPathManager.DeterminePathName( tbInterface ) );
                                xpath.Append( "/" ).Append( XPathManager.DeterminePathName( ports ) );
                                xpath.Append( "/" ).Append( XPathManager.DeterminePathName( port ) );
                                xpath.Append( "[@name=\"" ).Append( port.name ).Append( "\"]" );
                                string pathValues = NetworkNode.ExtractPathValues( xpath.ToString() );
                                var lvi = new ListViewItem( pathValues );
                                lvi.Tag = xpath.ToString();
                                lvi.Group = g;
                                lvNetworkPaths.Items.Add( lvi );
                            }
                        }
                    }
                }
            }
        }

        /**
         * Call to Add Capabilities to the selection list view. Each item
         * in the list will hold an XPath representation of the Capabilities.
         */

        private void ProcessCapabilitites( Capabilities capabilities )
        {
            if (capabilities != null)
            {
                var g = new ListViewGroup( "Capabilities", "Capabilities" );
                lvNetworkPaths.Groups.Add( g );
                if (capabilities.Items != null )
                {
                    foreach (object item in capabilities.Items)
                    {
                        var capability = item as Capability;
                        if (capability != null)
                        {
                            Interface capabilityInterface = capability.Interface;
                            if (capabilityInterface != null)
                            {
                                List<Port> ports = capabilityInterface.Ports;
                                if (ports != null)
                                {
                                    foreach (Port port in ports)
                                    {
                                        var xpath = new StringBuilder( "//" );
                                        xpath.Append( XPathManager.DeterminePathName( _hardwareItemDescription ) );
                                        xpath.Append( "/" ).Append( XPathManager.DeterminePathName( capabilities ) );
                                        xpath.Append( "/" ).Append( XPathManager.DeterminePathName( capability ) );
                                        xpath.Append( "[@name=\"" )
                                             .Append( capability.name )
                                             .Append( "\"]" );
                                        xpath.Append( "/" )
                                             .Append( XPathManager.DeterminePathName( capabilityInterface ) );
                                        xpath.Append( "/" ).Append( XPathManager.DeterminePathName( ports ) );
                                        xpath.Append( "/" )
                                             .Append( XPathManager.DeterminePathName( port ) );
                                        xpath.Append( "[@name=\"" ).Append( port.name ).Append( "\"]" );
                                        string pathValues = NetworkNode.ExtractPathValues( xpath.ToString() );
                                        var lvi = new ListViewItem( pathValues );
                                        lvi.Tag = xpath.ToString();
                                        lvi.Group = g;
                                        lvNetworkPaths.Items.Add( lvi );
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        /**
         * Call to Add Resources to the selection list view. Each item
         * in the list will hold an XPath representation of the Resource.
         */

        private void ProcessHardwareItemResources()
        {
            var instrumentDescription = _hardwareItemDescription as InstrumentDescription;
            var testEquipment = _hardwareItemDescription as TestEquipment;
            if (instrumentDescription != null || testEquipment != null )
            {
                var g = new ListViewGroup( "Resources", "Resources" );
                lvNetworkPaths.Groups.Add( g );
                List<Resource> resourceList = null;
                resourceList = instrumentDescription != null ? instrumentDescription.Resources : testEquipment.Resources;

                if (resourceList != null)
                {
                    foreach (Resource resource in resourceList)
                    {
                        Interface resouceInterface = resource.Interface;
                        if (resouceInterface != null)
                        {
                            List<Port> ports = resouceInterface.Ports;
                            if (ports != null)
                            {
                                foreach (Port port in ports)
                                {
                                    var xpath = new StringBuilder( "//" );
                                    xpath.Append( XPathManager.DeterminePathName( _hardwareItemDescription ) );
                                    xpath.Append( "/" ).Append( XPathManager.DeterminePathName( resourceList ) );
                                    xpath.Append( "/" ).Append( XPathManager.DeterminePathName( resource ) );
                                    xpath.Append( "[@name=\"" )
                                         .Append( resource.name )
                                         .Append( "\"]" );
                                    xpath.Append( "/" ).Append( XPathManager.DeterminePathName( resouceInterface ) );
                                    xpath.Append( "/" ).Append( XPathManager.DeterminePathName( ports ) );
                                    xpath.Append( "/" )
                                         .Append( XPathManager.DeterminePathName( port ) );
                                    xpath.Append( "[@name=\"" ).Append( port.name ).Append( "\"]" );
                                    string pathValues = NetworkNode.ExtractPathValues( xpath.ToString() );
                                    var lvi = new ListViewItem( pathValues );
                                    lvi.Tag = xpath.ToString();
                                    lvi.Group = g;
                                    lvNetworkPaths.Items.Add( lvi );
                                }
                            }
                        }
                    }
                }
            }
        }

        /**
         * Call to Add Components to the selection list view. Each item
         * in the list will hold an XPath representation of the Component.
        */

        private void ProcessHardwareItemComponents()
        {
            List<HardwareItemDescriptionComponent> componentList = _hardwareItemDescription.Components;
            if (componentList != null)
            {
                var g = new ListViewGroup( "Components", "Components" );
                lvNetworkPaths.Groups.Add( g );
                foreach (HardwareItemDescriptionComponent cmp in componentList)
                {
                    string componentName = cmp.ID;
                    object itemRef = cmp.Item;
                    if (itemRef != null)
                    {
                        var idesc = itemRef as HardwareItemDescription;
                        if (idesc != null)
                        {
                            List<object> interfaces = idesc.Interface;
                            if (interfaces != null)
                            {
                                foreach (object @interface in interfaces)
                                {
                                    var iports = @interface as PhysicalInterfacePorts;
                                    if (iports != null)
                                    {
                                        List<PhysicalInterfacePortsPort> moreports = iports.Port;
                                        if (moreports != null)
                                        {
                                            foreach (PhysicalInterfacePortsPort physicalInterfacePortsPort in moreports)
                                            {
                                                var xpath = new StringBuilder( "//" );
                                                xpath.Append( XPathManager.DeterminePathName( _hardwareItemDescription ) );
                                                xpath.Append( "/" )
                                                     .Append( XPathManager.DeterminePathName( componentList ) );
                                                xpath.Append( "/" ).Append( XPathManager.DeterminePathName( cmp ) );
                                                xpath.Append( "[@ID=\"" )
                                                     .Append( componentName )
                                                     .Append( "\"]/c:Definition" );
                                                xpath.Append( "/" )
                                                     .Append( XPathManager.DeterminePathName( interfaces ) );
                                                xpath.Append( "/" )
                                                     .Append( XPathManager.DeterminePathName( moreports ) );
                                                xpath.Append( "/" )
                                                     .Append( XPathManager.DeterminePathName( physicalInterfacePortsPort ) );
                                                xpath.Append( "[@name=\"" )
                                                     .Append( physicalInterfacePortsPort.name )
                                                     .Append( "\"]" );

                                                string pathValues = NetworkNode.ExtractPathValues( xpath.ToString() );
                                                var lvi = new ListViewItem( pathValues );
                                                lvi.Tag = xpath.ToString();
                                                lvi.Group = g;
                                                lvNetworkPaths.Items.Add( lvi );
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }


        /**
         * Call to Add Switches to the selection list view. Each item
         * in the list will hold an XPath representation of the Switch.
         */

        private void ProcessHardwareItemSwitching( Switching switching )
        {
            if (switching != null)
            {
                var g = new ListViewGroup( "Switching", "Switching" );
                lvNetworkPaths.Groups.Add( g );
                foreach (object item in switching.Items)
                {
                    if (item != null)
                    {
                        var idesc = item as Switch;
                        if (idesc != null)
                        {
                            Interface interfaces = idesc.Interface;
                            if (interfaces != null)
                            {
                                foreach (Port port in interfaces.Ports)
                                {
                                    if (port != null)
                                    {
                                        var xpath = new StringBuilder( "//" );
                                        xpath.Append( XPathManager.DeterminePathName( _hardwareItemDescription ) );
                                        xpath.Append( "/" ).Append( XPathManager.DeterminePathName( switching ) );
                                        xpath.Append( "/" ).Append( XPathManager.DeterminePathName( item ) );
                                        xpath.Append( "[@name=\"" )
                                             .Append( idesc.name )
                                             .Append( "\"]" );
                                        xpath.Append( "/" ).Append( XPathManager.DeterminePathName( interfaces ) );
                                        xpath.Append( "/" ).Append( XPathManager.DeterminePathName( interfaces.Ports ) );
                                        xpath.Append( "/" )
                                             .Append( XPathManager.DeterminePathName( port ) );
                                        xpath.Append( "[@name=\"" )
                                             .Append( port.name )
                                             .Append( "\"]" );

                                        string pathValues = NetworkNode.ExtractPathValues( xpath.ToString() );
                                        var lvi = new ListViewItem( pathValues );
                                        lvi.Tag = xpath.ToString();
                                        lvi.Group = g;
                                        lvNetworkPaths.Items.Add( lvi );
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        /**
         * Call to Add Interfaces to the selection list view. Each item
         * in the list will hold an XPath representation of the Interface.
         */

        private void ProcessHardwareItemInterfaces( string typeName )
        {
            List<object> ports = _hardwareItemDescription.Interface;
            if (ports != null)
            {
                foreach (object port in ports)
                {
                    var pip = port as PhysicalInterfacePorts;
                    if (pip != null)
                    {
                        List<PhysicalInterfacePortsPort> pipps = pip.Port;
                        if (pipps != null)
                        {
                            foreach (PhysicalInterfacePortsPort pipp in pipps)
                            {
                                var xpath = new StringBuilder( "//" );
                                xpath.Append( XPathManager.DeterminePathName( _hardwareItemDescription ) );
                                xpath.Append( "/" ).Append( XPathManager.DeterminePathName( ports ) );
                                xpath.Append( "/" ).Append( XPathManager.DeterminePathName( pipps ) );
                                xpath.Append( "/" ).Append( XPathManager.DeterminePathName( pipp ) );
                                string name = pipp.name;
                                string direction = pipp.directionSpecified ? pipp.direction.ToString() : "";
                                string type = pipp.typeSpecified ? pipp.type.ToString() : "";
                                //ListViewItem lvi = new ListViewItem(name);
                                xpath.Append( "[@name=\"" ).Append( name ).Append( "\"]" );
                                string pathValues = NetworkNode.ExtractPathValues( xpath.ToString() );
                                var lvi = new ListViewItem( pathValues );
                                lvi.Tag = xpath.ToString();
                                //lvi.Tag = pipp;
                                lvi.Group = lvNetworkPaths.Groups[typeName];
                                lvNetworkPaths.Items.Add( lvi );
                            }
                        }
                    }
                }
            }
        }

        private void lvNetworkPaths_Resize( object sender, EventArgs e )
        {
            SetColumns();
        }

        private void SetColumns()
        {
            if (lvNetworkPaths.Columns.Count >= 1)
                lvNetworkPaths.Columns[0].Width = lvNetworkPaths.Width;
        }
    }
}