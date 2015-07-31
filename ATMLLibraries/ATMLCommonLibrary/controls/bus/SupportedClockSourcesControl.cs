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

namespace ATMLCommonLibrary.controls.bus
{
    public partial class SupportedClockSourcesControl : ATMLControl
    {
        private SupportedClockSources _supportedClockSources;

        public SupportedClockSourcesControl()
        {
            InitializeComponent();
            InitControls();
        }

        public String Title
        {
            set { gbFrame.Text = value; }
            get { return gbFrame.Text; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SupportedClockSources SupportedClockSources
        {
            get
            {
                ControlsToData();
                return _supportedClockSources;
            }
            set
            {
                _supportedClockSources = value;
                DataToControls();
            }
        }

        private void DataToControls()
        {
            if (_supportedClockSources != null)
            {
                chkBackplane.Checked = _supportedClockSources.backplane;
                chkInternal.Checked = _supportedClockSources.@internal;
                chkExternal.Checked = _supportedClockSources.external;
            }
        }

        private void ControlsToData()
        {
            if (_supportedClockSources == null)
                _supportedClockSources = new SupportedClockSources();
            _supportedClockSources.backplane = chkBackplane.Checked;
            _supportedClockSources.@internal = chkInternal.Checked;
            _supportedClockSources.external = chkExternal.Checked;
        }
    }
}