/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ATMLManagerLibrary.managers;
using ATMLModelLibrary.model;
using ATMLModelLibrary.model.signal.basic;

namespace ATMLCommonLibrary.controls.physical
{
    public partial class PhysicalTypeControl : ATMLControl
    {
        private Physical _physical;

        public PhysicalTypeControl()
        {
            InitializeComponent();
            dgErrorLimits.EditingControlShowing += dgErrorLimits_EditingControlShowing;
            

            if (!this.IsInDesignMode())
            {
                dgErrlmtLLSignColumn.Items.Clear();
                dgErrlmtLLSignColumn.Items.Add(Quantity.PLUS);
                dgErrlmtLLSignColumn.Items.Add(Quantity.MINUS);
                dgErrlmtLLSignColumn.Items.Add(Quantity.PLUSMINUS1);
                dgErrlmtULSignColumn.Items.Add(Quantity.PLUS);
                dgErrlmtULSignColumn.Items.Add(Quantity.MINUS);
                dgErrlmtULSignColumn.Items.Add(Quantity.PLUSMINUS1);
                cbQualifier.Items.Clear();
                cbQualifier.Items.AddRange(Enum.GetNames(typeof (qualifier)).ToArray<object>());
                CacheManager.LoadStandardUnitMeasurementComboBox(dgRangesLLUnitColumn);
                CacheManager.LoadStandardUnitPrefixComboBox(dgRangesLLPrefixColumn);
                CacheManager.LoadStandardUnitMeasurementComboBox(dgRangesULUnitColumn);
                CacheManager.LoadStandardUnitPrefixComboBox(dgRangesULPrefixColumn);
                CacheManager.LoadStandardUnitMeasurementComboBox(dgErrlmtLLUnitColumn);
                CacheManager.LoadStandardUnitPrefixComboBox(dgErrlmtLLPrefixColumn);
                CacheManager.LoadStandardUnitMeasurementComboBox(dgErrlmtULUnitColumn);
                CacheManager.LoadStandardUnitPrefixComboBox(dgErrlmtULPrefixColumn);
                CacheManager.LoadStandardUnitMeasurementComboBox(dgErrlmtResUnitColumn);
                CacheManager.LoadStandardUnitPrefixComboBox(dgErrlmtResPrefixColumn);
            }
        }

        public Physical PhysicalValue
        {
            get
            {
                ControlsToData();
                return _physical;
            }
            set
            {
                _physical = value;
                DataToControls();
            }
        }

        private void dgErrorLimits_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn
                && e.RowIndex >= 0
                && e.ColumnIndex == 0)
            {
                PhysicalTypeErrorLimitForm form = new PhysicalTypeErrorLimitForm();
                DataGridViewRow row = dgErrorLimits.Rows[e.RowIndex];
                form.ErrorLimit = row.Tag as ErrorLimit;
                if (DialogResult.OK == form.ShowDialog())
                {
                    SetRowData(row, form.ErrorLimit);
                }
            }
        }

        private void DataToControls()
        {
            if (_physical != null)
            {
                QualifiedQuantity qq = _physical.Magnitude;
                if( qq != null )
                    edtValue.Value = (decimal) qq.Magnitude;
                edtPhysicalTypeValue.Text = _physical.Value;
                //standardUnitControl.StandardUnit = 
                cbQualifier.SelectedIndex = qq!=null && qq.HasQualifier ? cbQualifier.FindString(qq.Qualifier.ToString()) : -1;
                foreach (ErrorLimit errorLimit in _physical.ErrorLimits)
                {
                    DataGridViewRow row = dgErrorLimits.Rows[dgErrorLimits.Rows.Add()];
                    SetRowData(row, errorLimit );
                }

                foreach (RangingInformation range in _physical.Ranges)
                {
                    int idx = dgRanges.Rows.Add(
                                        range.FromQuantity.Value, 
                                        range.FromQuantity.Unit.HasPrefix()?range.FromQuantity.Unit.Prefix : "",
                                        range.FromQuantity.Unit.HasUnit()?range.FromQuantity.Unit.Unit : "",
                                        range.ToQuantity.Value, 
                                        range.ToQuantity.Unit.HasPrefix()?range.ToQuantity.Unit.Prefix : "",
                                        range.ToQuantity.Unit.HasUnit()?range.ToQuantity.Unit.Unit : "",
                                        range.ErrorLimit!=null?range.ErrorLimit.ToString():"[Press to Add/Edit the Error Limit]"
                                      );
                    dgRanges.Rows[idx].Tag = range;
                }
            }
        }

        private static void SetRowData(DataGridViewRow row, ErrorLimit errorLimit )
        {
            int idx = 0;
            row.Tag = errorLimit;
            row.Cells[idx + 1].Value = Quantity.MINUS;
            if (errorLimit.MinusQuantity != null)
            {
                row.Cells[idx + 2].Value = Math.Abs(errorLimit.MinusQuantity.Value);
                if (errorLimit.MinusQuantity.Unit.HasPrefix())
                    row.Cells[idx + 3].Value = errorLimit.MinusQuantity.Unit.Prefix;
                if (errorLimit.MinusQuantity.Unit.HasUnit())
                    row.Cells[idx + 4].Value = errorLimit.MinusQuantity.Unit.Unit;
            }
            if (errorLimit.PlusQuantity != null)
            {
                row.Cells[idx + 5].Value = Quantity.PLUS;
                row.Cells[idx + 6].Value = Math.Abs(errorLimit.PlusQuantity.Value);
                if (errorLimit.PlusQuantity.Unit.HasPrefix())
                    row.Cells[idx + 7].Value = errorLimit.PlusQuantity.Unit.Prefix;
                if (errorLimit.PlusQuantity.Unit.HasUnit())
                    row.Cells[idx + 8].Value = errorLimit.PlusQuantity.Unit.Unit;
            }

            if (errorLimit.Confidence != null)
            {
                row.Cells[idx + 9].Value = errorLimit.Confidence.Value;
            }

            if (errorLimit.Resolution != null)
            {
                row.Cells[idx + 10].Value = errorLimit.Resolution.Value;
                row.Cells[idx + 11].Value = errorLimit.Resolution.Unit.Prefix;
                row.Cells[idx + 12].Value = errorLimit.Resolution.Unit.Unit;
            }
        }

        private void ControlsToData()
        {
        }

        private void dgErrorLimits_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
        }

        private void dgErrorLimits_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dgErrorLimits_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var itemID = e.Control as TextBox;
            if (dgErrorLimits.CurrentCell.ColumnIndex == 1 && itemID != null) //Where the ColumnIndex of your "itemID"
            {
                itemID.KeyPress += itemID_KeyPress;
            }
        }

        private void itemID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dgRanges_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn
                && e.RowIndex >= 0 
                && e.RowIndex != dgRanges.NewRowIndex
                && e.ColumnIndex == dgRangesULErrlmtColumn.Index)
            {
                PhysicalTypeErrorLimitForm form = new PhysicalTypeErrorLimitForm();
                DataGridViewRow row = dgRanges.Rows[e.RowIndex];
                RangingInformation range = row.Tag as RangingInformation;
                if (range != null)
                {
                    form.ErrorLimit = range.ErrorLimit;
                    if (DialogResult.OK == form.ShowDialog())
                    {
                        range.ErrorLimit = form.ErrorLimit;
                        row.Tag = range;
                        senderGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = range.ErrorLimit == null ? "[Press to Add/Edit the Error Limit]" : range.ErrorLimit.ToString();
                    }
                }
            }
        }
    }

}