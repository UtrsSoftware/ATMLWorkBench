/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using ATMLModelLibrary.model.common;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.capability
{
    public partial class CapabilitiesControl : ATMLControl
    {
        private Capabilities _capabilities;

        public event EventHandler DataObjectRequested;
        protected virtual void OnDataObjectRequested(DataObjectRequestEventArgs eventArgs)
        {
            EventHandler handler = DataObjectRequested;
            if (handler != null) handler(this, eventArgs);
        }

        public CapabilitiesControl()
        {
            InitializeComponent();
            InitControls();
            capabilityListControl1.CompletedAdd += capabilityListControl1_CompletedAdd;
            capabilityListControl1.CompletedEdit += capabilityListControl1_CompletedEdit;
            capabilityListControl1.DataObjectRequested += ( sender, args ) => OnDataObjectRequested( args as DataObjectRequestEventArgs );
        }

        void capabilityListControl1_CompletedEdit(object obj)
        {
            Capability capability = obj as Capability;
            if (capability != null)
            {
                ICollection<Port> ports = capability.Interface.Ports;
                foreach (Port port in ports)
                {
                    /*
                    Network network = new Network();
                    network.Node.Add( new NetworkNode(){Path = port.ToString() } );
                    Mapping mapping = new Mapping();
                    mapping.Map = new List<Network>();
                    foreach (var key in port.MappedPorts.Keys)
                    {

                    }
                     * */
                }
                //mappingListControl1.Mappings

            }
            
        }

        void capabilityListControl1_CompletedAdd(object obj)
        {
            
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Capabilities Capabilities
        {
            get
            {
                ControlsToData();
                return _capabilities;
            }
            set
            {
                _capabilities = value;
                DataToControls();
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public InstrumentDescription InstrumentDescription
        {
            set { capabilityListControl1.InstrumentDescription = value; 
                mappingListControl1.HardwareItemDescription = value; }
            get { return capabilityListControl1.InstrumentDescription; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TestAdapterDescription TestAdapterDescription
        {
            set { capabilityListControl1.TestAdapterDescription = value; 
                mappingListControl1.HardwareItemDescription = value; }
            get { return capabilityListControl1.TestAdapterDescription; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TestStationDescription11 TestStationDescription
        {
            set { capabilityListControl1.TestStationDescription = value;
                mappingListControl1.HardwareItemDescription = value;
            }
            get { return capabilityListControl1.TestStationDescription; }
        }

        private void DataToControls()
        {
            if (_capabilities != null)
            {
                capabilityListControl1.CapabilityItems = _capabilities.Items;
                mappingListControl1.Mappings = _capabilities.CapabilityMap;
                mappingListControl1.HardwareItemDescription = InstrumentDescription;
            }
        }

        private void ControlsToData()
        {
            if (HasCapabilities())
            {
                _capabilities = null;
            }
            else
            {
                if (_capabilities == null)
                    _capabilities = new Capabilities();
                _capabilities.Items = capabilityListControl1.CapabilityItems;
                _capabilities.CapabilityMap = mappingListControl1.Mappings;
            }
        }

        private bool HasCapabilities()
        {
            return (capabilityListControl1.CapabilityItems == null || capabilityListControl1.CapabilityItems.Count == 0)
                   && (mappingListControl1.Mappings == null || mappingListControl1.Mappings.Count == 0);
        }
    }
}