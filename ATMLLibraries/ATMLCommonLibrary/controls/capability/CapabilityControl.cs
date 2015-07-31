/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;
using ATMLCommonLibrary.utils;
using ATMLManagerLibrary.managers;
using ATMLModelLibrary.model.common;
using ATMLModelLibrary.model.equipment;
using ATMLModelLibrary.model.signal.basic;
using ATMLUtilitiesLibrary;

namespace ATMLCommonLibrary.controls.capability
{
    public partial class CapabilityControl : ATMLControl
    {
        private string _equipmentUuid;
        private Capability _capability;
        private Signal _signal;

        public CapabilityControl()
        {
            InitializeComponent();
            InitControls();
            interfaceListControl.PortAdded += interfaceListControl_PortAdded;
            interfaceListControl.PortChanged += interfaceListControl_PortChanged;
            interfaceListControl.PortRemoved += interfaceListControl_PortRemoved;
            Validating += CapabilityControl_Validating;
            
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public InstrumentDescription Instrument
        {
            get { return interfaceListControl.Instrument; }
            set { interfaceListControl.Instrument = value;
                if( value != null )_equipmentUuid = value.uuid;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TestStationDescription11 TestStationDescription
        {
            get { return interfaceListControl.TestStationDescription; }
            set
            {
                interfaceListControl.TestStationDescription = value;
                if (value != null) _equipmentUuid = value.uuid;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TestAdapterDescription1 TestAdapterDescription
        {
            get { return interfaceListControl.TestAdapterDescription; }
            set
            {
                interfaceListControl.TestAdapterDescription = value;
                if (value != null) _equipmentUuid = value.uuid;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Capability Capability
        {
            get
            {
                ControlsToData();
                return _capability;
            }
            set
            {
                _capability = value;
                interfaceListControl.ParentCapability = value;
                DataToControls();
            }
        }

        private void CapabilityControl_Validating(object sender, CancelEventArgs e)
        {
        }

        private void interfaceListControl_PortRemoved(object sender, EventArgs e)
        {
            SetAvailablePorts();
        }

        private void interfaceListControl_PortChanged(object sender, EventArgs e)
        {
            SetAvailablePorts();
        }

        private void interfaceListControl_PortAdded(object sender, EventArgs e)
        {
            SetAvailablePorts();
        }

        private void SetAvailablePorts()
        {
            signalControl.AvailableIns.Clear();
            signalControl.AvailableOuts.Clear();

            
            foreach (ListViewItem lvi in interfaceListControl.Items)
            {
                var port = lvi.Tag as Port;
                if (port != null)
                {
                    PortDirection direction = port.direction;
                    if (direction == PortDirection.Input || direction == PortDirection.BiDirectional)
                        signalControl.AvailableIns.Add(port);
                    if (direction == PortDirection.Output || direction == PortDirection.BiDirectional)
                        signalControl.AvailableOuts.Add(port);
                }
            }
        }

        private void interfaceListControl_Load(object sender, EventArgs e)
        {
        }

        private void signalControl1_Load(object sender, EventArgs e)
        {
        }

        private void DataToControls()
        {
            //------------------------------------------------------------//
            //--- Create a new Capability if we don't already have one ---//
            //------------------------------------------------------------//
            if (_capability == null)
                _capability = new Capability();

            //----------------------------------------//
            //--- Now lets start grabbing the data ---//
            //----------------------------------------//
            edtName.Value = _capability.name;
            edtDescription.Value = _capability.Description;
            interfaceListControl.Interface = _capability.Interface;
            Extension ext = _capability.SignalDescription;

            //------------------------------------------------------------//
            //--- Process the SignalDescription as a Extension element ---//
            //------------------------------------------------------------//
            if (ext != null)
            {
                List<XmlElement> any = ext.Any;
                if (any.Count > 0)
                {
                    //-------------------------------------------------//
                    //--- Make sure we're dealing with a Signal tag ---//
                    //-------------------------------------------------//
                    if ("Signal".Equals(any[0].LocalName))
                    {
                        _signal = new Signal();
                        _signal = Signal.Deserialize(any[0].OuterXml.Trim());
                        signalControl.Signal = _signal;

                        //-------------------------------------//
                        //--- Time to walk the Signal Items ---//
                        //-------------------------------------//
                        foreach (object item in _signal.Items)
                        {
                            String sigName = item.GetType().Name;
                            foreach (PropertyInfo prop in item.GetType().GetProperties())
                            {
                                try
                                {
                                    //Console.Write(prop.Name);
                                    //Console.Write("\t");
                                    //Console.Write(prop.PropertyType);
                                    //Console.Write("\t");
                                    //Console.WriteLine(prop.GetValue(item, null));
                                }
                                catch (Exception eee)
                                {
                                }
                            }
                        }
                    }
                }
            }
        }

        private void ControlsToData()
        {
            if (_capability == null)
                _capability = new Capability();
            _capability.name = edtName.GetValue<string>();
            _capability.Description = edtDescription.GetValue<string>();
            _capability.Interface = interfaceListControl.Interface;
            _signal = signalControl.Signal;
            SignalFunctionType sft = signalControl.SignalFunctionType;
            try
            {
                XmlElement elm = XmlUtils.Object2XmlElement(_signal);
                if (elm != null)
                {
                    if (_capability.SignalDescription == null)
                        _capability.SignalDescription = new Extension();
                    if (_capability.SignalDescription.Any == null)
                        _capability.SignalDescription.Any = new List<XmlElement>();
                    _capability.SignalDescription.Any.Clear();
                    _capability.SignalDescription.Any.Add(elm);
                }
            }
            catch (Exception e)
            {
                LogManager.Error(e);
            }
        }

        private void tabControl_Selected(object sender, TabControlEventArgs e)
        {
            if (_capability != null && _capability.Interface != null && _capability.Interface.Ports != null)
            {
                signalControl.Ports = _capability.Interface.Ports.ToList<object>();
            }
        }
    }
}