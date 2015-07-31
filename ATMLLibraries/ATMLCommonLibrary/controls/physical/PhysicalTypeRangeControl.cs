/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Windows.Forms;
using ATMLManagerLibrary.managers;
using ATMLModelLibrary.model;

namespace ATMLCommonLibrary.controls.physical
{
    public partial class PhysicalTypeRangeControl : UserControl
    {
        private Quantity _magnitude;
        private RangingInformation _rangingInformation;

        public PhysicalTypeRangeControl()
        {
            InitializeComponent();
            edtLLValue.ValueChanged += quantity_ValueChanged;
            cbLLPrefix.SelectedValueChanged += quantity_ValueChanged;
            cbLLPrefix.SelectedValueChanged += cbLLPrefix_SelectedValueChanged;
            cbLLUnit.SelectedValueChanged += quantity_ValueChanged;
            cbLLUnit.SelectedValueChanged += cbLLUnit_SelectedValueChanged;
            edtULValue.ValueChanged += quantity_ValueChanged;
            cbULPrefix.SelectedValueChanged += quantity_ValueChanged;
            cbULPrefix.SelectedValueChanged += cbULPrefix_SelectedValueChanged;
            cbULUnit.SelectedValueChanged += quantity_ValueChanged;
            cbULUnit.SelectedValueChanged += cbULUnit_SelectedValueChanged;

            if (!this.IsInDesignMode())
            {
                CacheManager.LoadStandardUnitMeasurementComboBox(cbLLUnit);
                CacheManager.LoadStandardUnitPrefixComboBox(cbLLPrefix);
                CacheManager.LoadStandardUnitMeasurementComboBox(cbULUnit);
                CacheManager.LoadStandardUnitPrefixComboBox(cbULPrefix);
            }
        }

        public RangingInformation RangingInformation
        {
            get { return _rangingInformation; }
            set
            {
                _rangingInformation = value;
                DataToControls();
            }
        }

        public Quantity Magnitude
        {
            set { _magnitude = value; }
        }

        private void cbLLUnit_SelectedValueChanged(object sender, EventArgs e)
        {
            if (edtLLValue.Quantity == null)
                edtLLValue.Quantity = new Quantity();
            if (edtLLValue.Quantity.Unit == null)
                edtLLValue.Quantity.Unit = new StandardUnit();
            edtLLValue.Quantity.Unit.Unit = cbLLUnit.SelectedValue as string;
        }

        private void cbLLPrefix_SelectedValueChanged(object sender, EventArgs e)
        {
            if (edtLLValue.Quantity == null)
                edtLLValue.Quantity = new Quantity();
            if (edtLLValue.Quantity.Unit == null)
                edtLLValue.Quantity.Unit = new StandardUnit();
            edtLLValue.Quantity.Unit.Prefix = cbLLPrefix.SelectedValue as string;
        }

        private void cbULUnit_SelectedValueChanged(object sender, EventArgs e)
        {
            if (edtULValue.Quantity == null)
                edtULValue.Quantity = new Quantity();
            if (edtULValue.Quantity.Unit == null)
                edtULValue.Quantity.Unit = new StandardUnit();
            edtULValue.Quantity.Unit.Unit = cbULUnit.SelectedValue as string;
        }

        private void cbULPrefix_SelectedValueChanged(object sender, EventArgs e)
        {
            if (edtULValue.Quantity == null)
                edtULValue.Quantity = new Quantity();
            if (edtULValue.Quantity.Unit == null)
                edtULValue.Quantity.Unit = new StandardUnit();
            edtULValue.Quantity.Unit.Prefix = cbULPrefix.SelectedValue as string;
        }

        private void quantity_ValueChanged(object sender, EventArgs e)
        {
            if (_rangingInformation != null)
            {
                var originalErrorLimit = _rangingInformation.Clone() as ErrorLimit;
                if (originalErrorLimit != null)
                {
                    ControlsToData();
                    edtErrorLimit.Text = _rangingInformation.ToString();
                    _rangingInformation = originalErrorLimit.Clone() as RangingInformation;
                }
            }
        }

        protected void DataToControls()
        {
            if (_rangingInformation != null)
            {
                edtLLValue.Quantity = _rangingInformation.FromQuantity;
                edtULValue.Quantity = _rangingInformation.ToQuantity;
                if (_rangingInformation.FromQuantity.Unit.HasPrefix())
                    cbLLPrefix.SelectedValue = _rangingInformation.FromQuantity.Unit.Prefix;
                else
                    cbLLPrefix.SelectedIndex = -1;

                if (_rangingInformation.FromQuantity.Unit.HasUnit())
                    cbLLUnit.SelectedValue = _rangingInformation.FromQuantity.Unit.Unit;
                else
                    cbLLUnit.SelectedIndex = -1;

                if (_rangingInformation.ToQuantity.Unit.HasPrefix())
                    cbULPrefix.SelectedValue = _rangingInformation.ToQuantity.Unit.Prefix;
                else
                    cbULPrefix.SelectedIndex = -1;

                if (_rangingInformation.ToQuantity.Unit.HasUnit())
                    cbULUnit.SelectedValue = _rangingInformation.ToQuantity.Unit.Unit;
                else
                    cbULUnit.SelectedIndex = -1;

                if (_rangingInformation.ErrorLimit != null)
                {
                    edtErrorLimit.Text = _rangingInformation.ErrorLimit.ToString();
                    edtErrorLimit.Tag = _rangingInformation.ErrorLimit;
                }
            }
        }

        protected void ControlsToData()
        {
            if (_rangingInformation == null)
                _rangingInformation = new RangingInformation();
            _rangingInformation.FromQuantity = edtLLValue.Quantity;
            _rangingInformation.ToQuantity = edtULValue.Quantity;

            if (_rangingInformation.FromQuantity.Unit.HasPrefix())
                cbLLPrefix.SelectedValue = _rangingInformation.FromQuantity.Unit.Prefix;
            else
                cbLLPrefix.SelectedIndex = -1;

            if (_rangingInformation.FromQuantity.Unit.HasUnit())
                cbLLUnit.SelectedValue = _rangingInformation.FromQuantity.Unit.Unit;
            else
                cbLLUnit.SelectedIndex = -1;
        }

        private void btnLimit_Click(object sender, EventArgs e)
        {
            PhysicalTypeErrorLimitForm form = new PhysicalTypeErrorLimitForm();
            if( _rangingInformation != null )
                form.ErrorLimit = _rangingInformation.ErrorLimit;
            if (DialogResult.OK == form.ShowDialog())
            {
                ErrorLimit limit = form.ErrorLimit;
                edtErrorLimit.Text = limit.ToString();
                edtErrorLimit.Tag = limit;
            }
        }
    }
}