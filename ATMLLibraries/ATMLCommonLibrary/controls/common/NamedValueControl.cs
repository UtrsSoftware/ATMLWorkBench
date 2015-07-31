/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
using System;
using System.ComponentModel;
using ATMLModelLibrary.model.common;

namespace ATMLCommonLibrary.controls.common
{
    public partial class NamedValueControl : ValueControl
    {
        public NamedValueControl()
        {
            InitializeComponent();
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public NamedValue NamedValue
        {
            get
            {
                ControlsToData();
                return Value as NamedValue;
            }
            set
            {
                Value = value;
                DataToControls();
            }
        }

        protected override void DataToControls()
        {
            base.DataToControls();
            if (_value is NamedValue)
            {
                var namedValue = _value as NamedValue;
                edtName.Value = namedValue.name;
            }
        }

        protected override void ControlsToData()
        {
            if (_value == null)
                _value = new NamedValue();
            base.ControlsToData();
            ((NamedValue) _value).name = edtName.GetValue<string>();
        }

        private void collectionControl_Load(object sender, EventArgs e)
        {
        }
    }
}