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
    public partial class PCIControl : BusControl
    {
        public PCIControl()
        {
            InitializeComponent();
            InitControls();
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PCI PCI
        {
            set
            {
                Bus = value;
                DataToControls();
            }
            get
            {
                ControlsToData();
                return _bus as PCI;
            }
        }

        protected override void DataToControls()
        {
            if (_bus == null) return;
            base.DataToControls();
            edtDeviceId.Value = ((PCI) _bus).deviceID;
            edtVendorId.Value = ((PCI) _bus).vendorID;
        }

        protected override void ControlsToData()
        {
            if (_bus == null)
                _bus = new PCI();
            base.ControlsToData();
            ((PCI) _bus).deviceID = edtDeviceId.GetValue<string>();
            ((PCI) _bus).vendorID = edtVendorId.GetValue<string>();
        }
    }
}