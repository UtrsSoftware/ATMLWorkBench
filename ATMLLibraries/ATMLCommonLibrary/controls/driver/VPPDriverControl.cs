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
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.driver
{
    public partial class VPPDriverControl : ATMLCommonLibrary.controls.driver.DriverControl
    {

        public VPPDriverControl()
        {
            InitializeComponent();
        }

        public new VPP Driver
        {
            get { ControlsToData(); return _driver as VPP; }
            set { _driver = value; DataToControls(); }
        }

        protected override void ControlsToData()
        {
            if (_driver == null)
                _driver = new VPP();
            base.ControlsToData();
            var vpp = _driver as VPP;
            if (vpp != null)
            {
                vpp.prefix = edtPrefix.GetValue<string>();
            }
        }

        protected override void DataToControls()
        {
            base.DataToControls();
            var vpp = _driver as VPP;
            if (vpp != null)
            {
                edtPrefix.Value = vpp.prefix;
            }
        }

        protected override void OnValidating(CancelEventArgs e)
        {
            //string saved = _versionIdentifier == null ? null : _versionIdentifier.Serialize();
            //ControlsToData();
            //ValidateToSchema(_versionIdentifier);
            //_versionIdentifier = string.IsNullOrEmpty(saved) ? null : VersionIdentifier.Deserialize(saved);
        }

    }
}
