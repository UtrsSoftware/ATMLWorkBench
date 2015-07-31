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
    public partial class BusControl : ATMLControl
    {
        protected Bus _bus;
        public BusControl()
        {
            InitializeComponent();
            InitControls();
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Bus Bus
        {
            get
            {
                ControlsToData();
                return _bus;
            }
            set
            {
                _bus = value;
                DataToControls();
            }
        }

        protected virtual void DataToControls()
        {
            if (_bus != null)
            {
                edtDefaultAddress.Value = _bus.defaultAddress;
            }
        }

        protected virtual void ControlsToData()
        {
            if (_bus != null)
            {
                _bus.defaultAddress = edtDefaultAddress.GetValue<string>();
            }
        }
    }
}