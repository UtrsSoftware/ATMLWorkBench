/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using ATMLModelLibrary.model;

namespace ATMLCommonLibrary.controls.awb
{
    public partial class AWBQuantityControl : NumericUpDown
    {
        private Quantity _quantity;


        public AWBQuantityControl()
        {
            InitializeComponent();
            this.Text = "";
        }

        public AWBQuantityControl(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            this.Text = "";
        }

        public Quantity Quantity
        {
            get
            {
                ControlsToData();
                return _quantity;
            }
            set
            {
                try
                {
                    _quantity = value;
                    if (_quantity != null)
                    {
                        Value = Convert.ToDecimal(_quantity.Value);
                        _quantity.ValueChanged += delegate { Text = _quantity.ToString(); };
                    }
                }
                catch (Exception)
                {
                    /* Do Nothing */
                    Text = @"ERROR";
                }
            }
        }

        protected override void OnValueChanged(EventArgs e)
        {
            ControlsToData();
            base.OnValueChanged(e);
        }

        private void ControlsToData()
        {
            if (_quantity == null)
                _quantity = new Quantity(Value);
            else
                _quantity.Value = Decimal.ToDouble(Value);
        }

        protected override void UpdateEditText()
        {
            var sb = new StringBuilder();
            sb.Append(Value.ToString(CultureInfo.InvariantCulture));
            if (_quantity != null && _quantity.Unit != null)
            {
                sb.Append(" ");
                if (_quantity.Unit.HasPrefix())
                    sb.Append(_quantity.Unit.Prefix);
                if (_quantity.Unit.HasUnit())
                    sb.Append(_quantity.Unit.Unit);
            }
            Text = sb.ToString().Trim();
        }
    }
}