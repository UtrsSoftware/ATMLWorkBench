/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using ATMLCommonLibrary.managers;
using ATMLDataAccessLibrary.db.beans;
using ATMLManagerLibrary.managers;

namespace ATMLCommonLibrary.controls
{
    public partial class StandardUnitControl : ATMLControl
    {
        public delegate void OnChangeDelegate(String stdUnit);

        private String _standardUnit;

        public StandardUnitControl()
        {
            InitializeComponent();
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public String StandardUnit
        {
            get
            {
                ControlsToData();
                return _standardUnit;
            }
            set
            {
                _standardUnit = value;
                DataToControls();
            }
        }

        public event OnChangeDelegate OnChange;

        public void Clear()
        {
            edtStnUnit.Clear();
            cmbPrefix.SelectedIndex = -1;
            cmbStdUnit.SelectedIndex = -1;
        }

        private void ControlsToData()
        {
            _standardUnit = edtStnUnit.Text;
        }

        private void DataToControls()
        {
            if (_standardUnit != null)
            {
                Initializing = true;
                edtStnUnit.Text = _standardUnit;
                SetLimitCombos();
                Initializing = false;
            }
        }

        private void StandardUnitControl_Load(object sender, EventArgs e)
        {
            if (!this.IsInDesignMode() && cmbStdUnit.Items.Count == 0)
            {
                String originalValue = edtStnUnit.Text;
                CacheManager.LoadStandardUnitMeasurementComboBox(cmbStdUnit);
                CacheManager.LoadStandardUnitPrefixComboBox(cmbPrefix);
                if (String.IsNullOrEmpty(originalValue))
                {
                    cmbPrefix.SelectedIndex = -1;
                    cmbStdUnit.SelectedIndex = -1;
                }
                edtStnUnit.Text = originalValue;
                SetLimitCombos();
            }
        }

        private void SetLimitCombos()
        {
            if (!String.IsNullOrEmpty(edtStnUnit.Text))
            {
                String stdUnit = edtStnUnit.Text;
                String prefix = "";
                //-----------------------------------------------------------------------------------------//
                //--- Lookup standard unit - if not found strip off 1st letter for prefix and try again ---//
                //-----------------------------------------------------------------------------------------//
                cmbStdUnit.SelectedValue = stdUnit;
                if (cmbStdUnit.SelectedValue == null)
                {
                    prefix = stdUnit.Substring(0, 1);
                    stdUnit = stdUnit.Substring(1);
                    cmbStdUnit.SelectedValue = stdUnit;
                    cmbPrefix.SelectedValue = prefix;
                }
                else //--- If the standard unit is found then clear out the prefix ---//
                {
                    cmbPrefix.SelectedIndex = -1;
                }
            }
        }

        private void cmbPrefix1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Initializing)
            {
                var sb = new StringBuilder();
                var spBean = cmbPrefix.SelectedItem as StandardUnitPrefixBean;
                var sumBean = cmbStdUnit.SelectedItem as StandardUnitMeasurementBean;
                if (spBean != null)
                    sb.Append(spBean.symbol);
                if (sumBean != null)
                    sb.Append(sumBean.symbol);
                edtStnUnit.Text = sb.ToString();
                edtStnUnit.SelectionStart = edtStnUnit.TextLength;
                edtStnUnit.SelectionLength = 0;
            }
        }

        private void cmbStdUnit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Initializing)
            {
                var sb = new StringBuilder();
                var spBean = cmbPrefix.SelectedItem as StandardUnitPrefixBean;
                var sumBean = cmbStdUnit.SelectedItem as StandardUnitMeasurementBean;
                if (spBean != null)
                    sb.Append(spBean.symbol);
                if (sumBean != null)
                    sb.Append(sumBean.symbol);
                edtStnUnit.Text = sb.ToString();
                edtStnUnit.SelectionStart = edtStnUnit.TextLength;
                edtStnUnit.SelectionLength = 0;
            }
        }

        private void edtStnUnit_TextChanged(object sender, EventArgs e)
        {
            if (OnChange != null)
                OnChange(edtStnUnit.Text);
        }

        private void edtStnUnit_KeyUp(object sender, KeyEventArgs e)
        {
            SetLimitCombos();
        }
    }
}