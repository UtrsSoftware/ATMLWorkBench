/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.ComponentModel;
using ATMLManagerLibrary.managers;
using ATMLModelLibrary.model;

namespace ATMLCommonLibrary.controls.physical
{
    public partial class PhysicalTypeErrorLimitControl : ATMLControl
    {
        private ErrorLimit _errorLimit;

        public PhysicalTypeErrorLimitControl()
        {
            InitializeComponent();
            edtConfidence.ValueChanged += quantity_ConfValueChanged;
            edtLLValue.ValueChanged += quantity_LLValueChanged;
            edtResolution.ValueChanged += quantity_ResValueChanged;
            edtULValue.ValueChanged += quantity_ULValueChanged;
            //cbLLPrefix.SelectedValueChanged += quantity_LLValueChanged;
            cbLLPrefix.SelectedValueChanged += cbLLPrefix_SelectedValueChanged;
            //cbLLUnit.SelectedValueChanged += quantity_LLValueChanged;
            cbLLUnit.SelectedValueChanged += cbLLUnit_SelectedValueChanged;
            //cbResPrefix.SelectedValueChanged += quantity_ResValueChanged;
            cbResPrefix.SelectedValueChanged += cbResPrefix_SelectedValueChanged;
            //cbResUnit.SelectedValueChanged += quantity_ResValueChanged;
            cbResUnit.SelectedValueChanged += cbResUnit_SelectedValueChanged;
            //cbULPrefix.SelectedValueChanged += quantity_ULValueChanged;
            cbULPrefix.SelectedValueChanged += cbULPrefix_SelectedValueChanged;
            //cbULUnit.SelectedValueChanged += quantity_ULValueChanged;
            cbULUnit.SelectedValueChanged += cbULUnit_SelectedValueChanged;

            if (!this.IsInDesignMode())
            {
                CacheManager.LoadStandardUnitMeasurementComboBox( cbLLUnit );
                CacheManager.LoadStandardUnitPrefixComboBox( cbLLPrefix );
                CacheManager.LoadStandardUnitMeasurementComboBox( cbULUnit );
                CacheManager.LoadStandardUnitPrefixComboBox( cbULPrefix );
                CacheManager.LoadStandardUnitMeasurementComboBox( cbResUnit );
                CacheManager.LoadStandardUnitPrefixComboBox( cbResPrefix );
            }
        }

        [Browsable( false ), DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
        public ErrorLimit ErrorLimit
        {
            get
            {
                ControlsToData();
                return _errorLimit;
            }
            set
            {
                _errorLimit = value;
                DataToControls();
            }
        }

        private void cbULUnit_SelectedValueChanged( object sender, EventArgs e )
        {
            if (edtULValue.Quantity == null)
                edtULValue.Quantity = new Quantity();
            if (edtULValue.Quantity.Unit == null)
                edtULValue.Quantity.Unit = new StandardUnit();
            edtULValue.Quantity.Unit.Unit = cbULUnit.SelectedValue as string;
            if (_errorLimit != null)
                edtErrorLimit.Text = _errorLimit.ToString();
        }

        private void cbULPrefix_SelectedValueChanged( object sender, EventArgs e )
        {
            if (edtULValue.Quantity == null)
                edtULValue.Quantity = new Quantity();
            if (edtULValue.Quantity.Unit == null)
                edtULValue.Quantity.Unit = new StandardUnit();
            edtULValue.Quantity.Unit.Prefix = cbULPrefix.SelectedValue as string;
            if (_errorLimit != null)
                edtErrorLimit.Text = _errorLimit.ToString();
        }

        private void cbResUnit_SelectedValueChanged( object sender, EventArgs e )
        {
            if (edtResolution.Quantity == null)
                edtResolution.Quantity = new Quantity();
            if (edtResolution.Quantity.Unit == null)
                edtResolution.Quantity.Unit = new StandardUnit();
            edtResolution.Quantity.Unit.Unit = cbResUnit.SelectedValue as string;
            if (_errorLimit != null)
                edtErrorLimit.Text = _errorLimit.ToString();
        }

        private void cbResPrefix_SelectedValueChanged( object sender, EventArgs e )
        {
            if (edtResolution.Quantity == null)
                edtResolution.Quantity = new Quantity();
            if (edtResolution.Quantity.Unit == null)
                edtResolution.Quantity.Unit = new StandardUnit();
            edtResolution.Quantity.Unit.Prefix = cbResPrefix.SelectedValue as string;
            if (_errorLimit != null)
                edtErrorLimit.Text = _errorLimit.ToString();
        }

        private void cbLLUnit_SelectedValueChanged( object sender, EventArgs e )
        {
            if (edtLLValue.Quantity == null)
                edtLLValue.Quantity = new Quantity();
            if (edtLLValue.Quantity.Unit == null)
                edtLLValue.Quantity.Unit = new StandardUnit();
            edtLLValue.Quantity.Unit.Unit = cbLLUnit.SelectedValue as string;
            if (_errorLimit != null )
                edtErrorLimit.Text = _errorLimit.ToString();
        }

        private void cbLLPrefix_SelectedValueChanged( object sender, EventArgs e )
        {
            if (edtLLValue.Quantity == null)
                edtLLValue.Quantity = new Quantity();
            if (edtLLValue.Quantity.Unit == null)
                edtLLValue.Quantity.Unit = new StandardUnit();
            edtLLValue.Quantity.Unit.Prefix = cbLLPrefix.SelectedValue as string;
            if (_errorLimit != null)
                edtErrorLimit.Text = _errorLimit.ToString();
        }

        private void quantity_LLValueChanged( object sender, EventArgs e )
        {
            if( _errorLimit == null )
                _errorLimit = new ErrorLimit();
            _errorLimit.MinusQuantity = edtLLValue.Quantity;
            edtErrorLimit.Text = _errorLimit.ToString();
        }

        private void quantity_ULValueChanged(object sender, EventArgs e)
        {
            if (_errorLimit == null)
                _errorLimit = new ErrorLimit();
            _errorLimit.PlusQuantity = edtULValue.Quantity;
            edtErrorLimit.Text = _errorLimit.ToString();
        }

        private void quantity_ResValueChanged(object sender, EventArgs e)
        {
            if (_errorLimit == null)
                _errorLimit = new ErrorLimit();
            _errorLimit.Resolution = edtResolution.Quantity;
            edtErrorLimit.Text = _errorLimit.ToString();
        }

        private void quantity_ConfValueChanged(object sender, EventArgs e)
        {
            if (_errorLimit == null)
                _errorLimit = new ErrorLimit();
            _errorLimit.Confidence = edtConfidence.Quantity;
            edtErrorLimit.Text = _errorLimit.ToString();
        }

        protected void DataToControls()
        {
            if (_errorLimit != null)
            {
                if (_errorLimit.MinusQuantity != null)
                {
                    edtLLValue.Quantity = _errorLimit.MinusQuantity;
                    if (_errorLimit.MinusQuantity.Unit != null
                        && _errorLimit.MinusQuantity.Unit.HasPrefix())
                        cbLLPrefix.SelectedValue = _errorLimit.MinusQuantity.Unit.Prefix;
                    else
                        cbLLPrefix.SelectedIndex = -1;


                    if (_errorLimit.MinusQuantity.Unit != null && _errorLimit.MinusQuantity.Unit.HasUnit())
                        cbLLUnit.SelectedValue = _errorLimit.MinusQuantity.Unit.Unit;
                    else
                        cbLLUnit.SelectedIndex = -1;
                }
                if (_errorLimit.PlusQuantity != null)
                {
                    edtULValue.Quantity = _errorLimit.PlusQuantity;
                    if (_errorLimit.PlusQuantity.Unit != null && _errorLimit.PlusQuantity.Unit.HasPrefix())
                        cbULPrefix.SelectedValue = _errorLimit.PlusQuantity.Unit.Prefix;
                    else
                        cbULPrefix.SelectedIndex = -1;
                    if (_errorLimit.PlusQuantity.Unit != null && _errorLimit.PlusQuantity.Unit.HasUnit())
                        cbULUnit.SelectedValue = _errorLimit.PlusQuantity.Unit.Unit;
                    else
                        cbULUnit.SelectedIndex = -1;
                }

                if (_errorLimit.Confidence != null)
                {
                    edtConfidence.Quantity = _errorLimit.Confidence;
                }

                if (_errorLimit.Resolution != null)
                {
                    edtResolution.Quantity = _errorLimit.Resolution;
                    if (_errorLimit.Resolution.Unit != null && _errorLimit.Resolution.Unit.HasPrefix())
                        cbResPrefix.SelectedValue = _errorLimit.Resolution.Unit.Prefix;
                    else
                        cbResPrefix.SelectedIndex = -1;
                    if (_errorLimit.Resolution.Unit != null && _errorLimit.Resolution.Unit.HasUnit())
                        cbResUnit.SelectedValue = _errorLimit.Resolution.Unit.Unit;
                    else
                        cbResUnit.SelectedIndex = -1;
                }

                edtErrorLimit.Text = _errorLimit.ToString();
            }
        }

        protected void ControlsToData()
        {
            if (_errorLimit == null)
                _errorLimit = new ErrorLimit();
            _errorLimit.MinusQuantity = edtLLValue.Quantity;
            _errorLimit.PlusQuantity = edtULValue.Quantity;
            _errorLimit.Confidence = edtConfidence.Quantity;
            _errorLimit.Resolution = edtResolution.Quantity;
            edtErrorLimit.Text = _errorLimit.ToString();
        }

        private void chkIncludeResolution_CheckedChanged( object sender, EventArgs e )
        {
            SetControlStates();
        }

        private void SetControlStates()
        {
            edtResolution.Enabled = chkIncludeResolution.Checked;
            cbResPrefix.Enabled = chkIncludeResolution.Checked;
            cbResUnit.Enabled = chkIncludeResolution.Checked;
        }
    }
}