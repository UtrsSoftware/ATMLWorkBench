/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
using System;
using System.ComponentModel;
using System.Windows.Forms;
using ATMLModelLibrary.model.common;

namespace ATMLCommonLibrary.controls.datum
{
    public partial class DatumTypeControl : ATMLControl
    {
        private int _defaultComparitor = -1;

        private int _defaultDataType = 1;

        private DatumType _datum;

        private bool _locked;

        protected Value _value;

        public bool LockTypes
        {
            get { return _locked; }
            set
            {
                _locked = value;
                SetControlStates();
            }
        }


        public DatumTypeControl()
        {
            InitializeComponent();
            edtDatum.Label = lblValue;
            standardUnitControl.OnChange += standardUnitControl_OnChange;
            if (!this.IsInDesignMode())
            {
                cmbDatumType.DataSource = Enum.GetNames(typeof (Datum.DatumTypes));
                cmbDatumType.SelectedIndex = (int)ATMLModelLibrary.model.common.Datum.DatumTypes.DOUBLE;
                SetEditStates();
            }
        }

        public int DefaultDataType
        {
            get { return _defaultDataType; }
            set
            {
                _defaultDataType = value;
                cmbDatumType.SelectedIndex = value;
            }
        }


        public int DefaultComparitor
        {
            get { return _defaultComparitor; }
            set { _defaultComparitor = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DatumType Datum
        {
            get
            {
                ControlsToData();
                return _datum;
            }
            set
            {
                _datum = value;
                DataToControls();
            }
        }

        private void standardUnitControl_OnChange(string stdUnit)
        {
            //edtNonStandardUnit.Value = null;
        }

        private void DataToControls()
        {
            if (_datum != null)
            {
                Initializing = true;
                chkResolution.Checked = _datum.ResolutionSpecified;
                if (chkResolution.Checked)
                    edtResolution.Value = Convert.ToDecimal(_datum.Resolution);
                chkConfidence.Checked = _datum.ConfidenceSpecified;
                if (chkConfidence.Checked)
                    edtConfidence.Value = Convert.ToDecimal(_datum.Confidence);
                edtNonStandardUnit.Value = _datum.nonStandardUnit;
                standardUnitControl.StandardUnit = _datum.standardUnit;
                qualifierComboBox.SelectedItem = _datum.unitQualifier;
                ATMLModelLibrary.model.common.Datum.SetDatumType(cmbDatumType, _datum);
                edtDatum.DatumType = _datum;
                errorLimitControl.Limit = _datum.ErrorLimits;
                errorLimitControl.DefaultLimitType = edtDatum.DatumTypeIndex;
                errorLimitControl.DefaultStandardUnit = _datum.standardUnit;
                errorLimitControl.DefaultComparitor = _defaultComparitor;
                errorLimitControl.DefaultValue = edtDatum.Value;
                rangeLimitControl.Limit = _datum.Range;
                rangeLimitControl.DefaultLimitType = edtDatum.DatumTypeIndex;
                rangeLimitControl.DefaultComparitor = _defaultComparitor;
                rangeLimitControl.DefaultStandardUnit = _datum.standardUnit;
                rangeLimitControl.DefaultValue = edtDatum.Value;
                SetControlStates();
                Initializing = false;
                //cmbDatumType.Enabled = false; //--- Do not allow to edit the type ---//

                cmbDatumType.Enabled =
                edtNonStandardUnit.Enabled = 
                standardUnitControl.Enabled = !LockTypes;
            }
        }

        private void ControlsToData()
        {
            if (_datum == null)
                _datum = ATMLModelLibrary.model.common.Datum.GetDatumFromType(cmbDatumType);
            _datum = edtDatum.DatumType;
            _datum.ResolutionSpecified = chkResolution.Checked;
            if (chkResolution.Checked)
                _datum.Resolution = Convert.ToDouble(edtResolution.Value);
            _datum.ConfidenceSpecified = chkConfidence.Checked;
            if (chkConfidence.Checked)
                _datum.Confidence = Convert.ToDouble(edtConfidence.Value);
            _datum.nonStandardUnit = edtNonStandardUnit.GetValue<string>();
            _datum.standardUnit = standardUnitControl.StandardUnit;
            _datum.unitQualifier = qualifierComboBox.SelectedItem as String;
            _datum.ErrorLimits = errorLimitControl.Limit;
            _datum.Range = rangeLimitControl.Limit;
        }


        private void chkResolution_CheckedChanged(object sender, EventArgs e)
        {
            SetControlStates();
        }

        private void chkConfidence_CheckedChanged(object sender, EventArgs e)
        {
            SetControlStates();
        }

        private void SetControlStates()
        {
            edtResolution.Enabled = chkResolution.Checked;
            edtConfidence.Enabled = chkConfidence.Checked;
            cmbDatumType.Enabled = !_locked;
            standardUnitControl.Enabled = !_locked;
            edtNonStandardUnit.Enabled = !_locked;
            qualifierComboBox.Enabled = !_locked;
        }

        private void DatumTypeControl_Validating(object sender, CancelEventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetEditStates();
        }

        private void SetEditStates()
        {
            edtDatum.DatumTypeIndex = cmbDatumType.SelectedIndex;
        }

        private void edtNonStandardUnit_KeyUp(object sender, KeyEventArgs e)
        {
            //if( !string.IsNullOrEmpty(edtNonStandardUnit.Text) )
            //    standardUnitControl.Clear();
        }
    }
}