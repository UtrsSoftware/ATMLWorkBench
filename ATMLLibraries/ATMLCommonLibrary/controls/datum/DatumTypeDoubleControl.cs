/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ATMLCommonLibrary.forms;
using ATMLModelLibrary.model.common;

namespace ATMLCommonLibrary.controls.datum
{
    public partial class DatumTypeDoubleControl : ATMLControl
    {
        private boolean _useFlowControl;

        private @double _doubleValue;

        public DatumTypeDoubleControl()
        {
            InitializeComponent();
            standardUnitControl.OnChange += new StandardUnitControl.OnChangeDelegate(standardUnitControl_OnChange);
        }

        void standardUnitControl_OnChange(string stdUnit)
        {
            if (_doubleValue != null )
                _doubleValue.standardUnit = standardUnitControl.StandardUnit;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public @double DoubleValue
        {
            get{ControlsToData(); return _doubleValue; }
            set { _doubleValue = value;DataToControls();}
        }

        public boolean UseFlowControl
        {
            get { return _useFlowControl; }
            set { _useFlowControl = value; }
        }

        private void DataToControls()
        {
            if (_doubleValue != null)
            {
                edtDoubleValue.Value = _doubleValue.value;
                lblDoubleDescription.Text = _doubleValue.ToString();
                standardUnitControl.StandardUnit = _doubleValue.standardUnit;
            }
        }

        private void ControlsToData()
        {
            if (!edtDoubleValue.HasValue())
                _doubleValue = null;
            else
            {
                if (_doubleValue == null)
                    _doubleValue = new @double();
                _doubleValue.value = edtDoubleValue.GetValue<double>();
                _doubleValue.standardUnit = standardUnitControl.StandardUnit;
            }
        }

        private void btnDatum_Click(object sender, EventArgs e)
        {
            DatumForm form = new DatumForm();
            ControlsToData();
            form.Datum = _doubleValue;
            if (DialogResult.OK == form.ShowDialog())
            {
                _doubleValue = form.Datum as @double;
                DataToControls();
            }
        }

        private void edtDoubleValue_KeyDown(object sender, KeyEventArgs e)
        {
            bool isNum = char.IsNumber((char) e.KeyCode);
            e.SuppressKeyPress = !isNum;
        }
    }
}
