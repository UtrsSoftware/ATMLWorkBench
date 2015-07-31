/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
using System.ComponentModel;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.bus
{
    public partial class PCIeControl : PCIControl
    {
        public PCIeControl()
        {
            InitializeComponent();
            InitControls();
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PCIe PCIe
        {
            set
            {
                Bus = value;
                DataToControls();
            }
            get
            {
                ControlsToData();
                return _bus as PCIe;
            }
        }

        protected override void DataToControls()
        {
            if (_bus == null) return;
            base.DataToControls();
            edtLanes.Text = "" + ((PCIe) _bus).numberOfLanes;
        }

        protected override void ControlsToData()
        {
            if (_bus == null)
                _bus = new PCIe();
            base.ControlsToData();
            int d;
            if (int.TryParse(edtLanes.Text, out d))
                ((PCIe) _bus).numberOfLanes = d;
        }
    }
}