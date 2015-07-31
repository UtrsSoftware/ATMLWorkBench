/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
using System;
using System.ComponentModel;
using ATMLCommonLibrary.controls;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary
{
    public partial class PXIBackplaneVoltagesControl : ATMLControl
    {
        private PXIBackplaneVoltages _PXIBackplaneVoltages;

        public PXIBackplaneVoltagesControl()
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
        public PXIBackplaneVoltages PXIBackplaneVoltages
        {
            get
            {
                ControlsToData();
                return _PXIBackplaneVoltages;
            }
            set
            {
                _PXIBackplaneVoltages = value;
                DataToControls();
            }
        }

        private void ControlsToData()
        {
            if (_PXIBackplaneVoltages == null)
                _PXIBackplaneVoltages = new PXIBackplaneVoltages();
            _PXIBackplaneVoltages.minus_12 = (double) edtMinus12.Value;
            _PXIBackplaneVoltages.plus_12 = (double) edtPlus12.Value;
            _PXIBackplaneVoltages.plus_33 = (double) edtPlus3_3.Value;
            _PXIBackplaneVoltages.plus_5 = (double) edtPlus5.Value;
        }

        private void DataToControls()
        {
            if (_PXIBackplaneVoltages != null)
            {
                edtMinus12.Value = (Decimal) _PXIBackplaneVoltages.minus_12;
                edtPlus12.Value = (Decimal) _PXIBackplaneVoltages.plus_12;
                edtPlus3_3.Value = (Decimal) _PXIBackplaneVoltages.plus_33;
                edtPlus5.Value = (Decimal) _PXIBackplaneVoltages.plus_5;
            }
        }
    }
}