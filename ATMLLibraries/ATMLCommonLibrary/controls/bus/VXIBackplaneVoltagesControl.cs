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
    public partial class VXIBackplaneVoltagesControl : ATMLControl
    {
        private VXIBackplaneVoltages _VXIBackplaneVoltages;

        public VXIBackplaneVoltagesControl()
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
        public VXIBackplaneVoltages VXIBackplaneVoltages
        {
            get
            {
                ControlsToData();
                return _VXIBackplaneVoltages;
            }
            set
            {
                _VXIBackplaneVoltages = value;
                DataToControls();
            }
        }

        private void DataToControls()
        {
            if (_VXIBackplaneVoltages != null)
            {
                edtMinus12.Value = (decimal) _VXIBackplaneVoltages.minus_12;
                edtMinus2.Value = (decimal) _VXIBackplaneVoltages.minus_2;
                edtMinus24.Value = (decimal) _VXIBackplaneVoltages.minus_24;
                edtMinus52.Value = (decimal) _VXIBackplaneVoltages.minus_52;
                edtPlus12.Value = (decimal) _VXIBackplaneVoltages.plus_12;
                edtPlus24.Value = (decimal) _VXIBackplaneVoltages.plus_24;
                edtPlus5.Value = (decimal) _VXIBackplaneVoltages.plus_5;
                edtPlus5Standby.Value = (decimal) _VXIBackplaneVoltages.plus_5_standby;
            }
        }

        private void ControlsToData()
        {
            if (_VXIBackplaneVoltages == null)
                _VXIBackplaneVoltages = new VXIBackplaneVoltages();
            _VXIBackplaneVoltages.minus_12 = (double) edtMinus12.Value;
            _VXIBackplaneVoltages.minus_2 = (double) edtMinus2.Value;
            _VXIBackplaneVoltages.minus_24 = (double) edtMinus24.Value;
            _VXIBackplaneVoltages.minus_52 = (double) edtMinus52.Value;
            _VXIBackplaneVoltages.plus_12 = (double) edtPlus12.Value;
            _VXIBackplaneVoltages.plus_24 = (double) edtPlus24.Value;
            _VXIBackplaneVoltages.plus_5 = (double) edtPlus5.Value;
            _VXIBackplaneVoltages.plus_5_standby = (double) edtPlus5Standby.Value;
        }
    }
}