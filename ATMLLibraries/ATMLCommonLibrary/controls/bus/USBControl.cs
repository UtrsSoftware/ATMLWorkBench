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
    public partial class USBControl : BusControl
    {
        public USBControl()
        {
            InitializeComponent();
            InitControls();
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public USB USB
        {
            set
            {
                Bus = value;
                DataToControls();
            }
            get
            {
                ControlsToData();
                return (USB) _bus;
            }
        }


        protected override void DataToControls()
        {
            if (_bus == null)
                return;
            base.DataToControls();
            var usb = (USB) _bus;
            versionIdentifierControl.VersionIdentifier = usb.Version;
        }

        protected override void ControlsToData()
        {
            if (_bus == null)
                _bus = new USB();
            base.ControlsToData();
            var usb = (USB)_bus;
            usb.Version = versionIdentifierControl.VersionIdentifier;
        }
    }
}