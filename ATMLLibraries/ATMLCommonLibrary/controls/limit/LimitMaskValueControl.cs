/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.ComponentModel;
using ATMLCommonLibrary.controls.common;
using ATMLModelLibrary.model.common;

namespace ATMLCommonLibrary.controls.limit
{
    public partial class LimitMaskValueControl : ValueControl
    {
        public LimitMaskValueControl()
        {
            InitializeComponent();
            if (!this.IsInDesignMode())
            {
                cbOperations.DataSource = Enum.GetNames(typeof (MaskOperator));
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public LimitMaskMaskValue LimitMaskValue
        {
            get
            {
                ControlsToData();
                return _value as LimitMaskMaskValue;
            }
            set
            {
                _value = value;
                DataToControls();
            }
        }

        protected override void DataToControls()
        {
            base.DataToControls();
            var maskValue = _value as LimitMaskMaskValue;
            if (maskValue != null)
            {
                edtName.Value = maskValue.name;
                cbOperations.SelectedValue = Enum.GetName(typeof (MaskOperator), maskValue.operation);
            }
        }

        protected override void ControlsToData()
        {
            if (_value == null)
                _value = new LimitMaskMaskValue();
            base.ControlsToData();
            var maskValue = _value as LimitMaskMaskValue;
            if (maskValue != null)
            {
                maskValue.name = edtName.GetValue<string>();
                maskValue.operation = (MaskOperator) Enum.Parse(typeof (MaskOperator), cbOperations.SelectedText, true);
            }
        }
    }
}