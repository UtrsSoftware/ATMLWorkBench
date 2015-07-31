/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.ComponentModel;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.forms
{
    public partial class CapabilityForm : ATMLForm
    {
        private Capability _capability;

        public CapabilityForm(object dataObject)
        {
            InitializeComponent();
            capabilityControl.Instrument = dataObject as InstrumentDescription;
            capabilityControl.TestAdapterDescription = dataObject as TestAdapterDescription1;
            capabilityControl.TestStationDescription = dataObject as TestStationDescription11;
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
                DataToControls();
            }
        }

        private void DataToControls()
        {
            capabilityControl.Capability = _capability;
        }

        private void ControlsToData()
        {
            _capability = capabilityControl.Capability;
        }

        private void capabilityControl_Load(object sender, EventArgs e)
        {
        }
    }
}