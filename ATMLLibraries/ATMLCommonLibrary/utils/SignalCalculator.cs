/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Windows.Forms;
using ATMLModelLibrary.model.signal.basic;

namespace ATMLCommonLibrary.utils
{
    public partial class SignalCalculator : Form
    {
        private object _lastPhysicalPart;
        private double _value;

        public SignalCalculator()
        {
            InitializeComponent();
            var dv = new DisplayValue();
            dv.ValueChanged += dv_ValueChanged;
            edtDisplay.Tag = dv;
            cmbQualifier.DataSource = Enum.GetNames(typeof (qualifier));
        }

        private void dv_ValueChanged(object sender, EventArgs e)
        {
            edtDisplay.Text = edtDisplay.Tag.ToString();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            SetDisplayValue(@"1");
        }

        private void ResetOnZero()
        {
            if ("0".Equals(edtDisplay.Text))
                edtDisplay.Text = "";
        }

        private bool HasSign()
        {
            return edtDisplay.Text.StartsWith("+") || edtDisplay.Text.StartsWith("-") || edtDisplay.Text.StartsWith("+");
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            SetDisplayValue(@"0");
        }

        private void btnPoint_Click(object sender, EventArgs e)
        {
            var dv = edtDisplay.Tag as DisplayValue;
            dv.Value = ".";
            double.TryParse(dv.Value, out _value);
        }

        private void btnMilli_Click(object sender, EventArgs e)
        {
            var dv = edtDisplay.Tag as DisplayValue;
            dv.SiPrefix = "m";
        }

        private void btnCenti_Click(object sender, EventArgs e)
        {
            var dv = edtDisplay.Tag as DisplayValue;
            dv.SiPrefix = "c";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            SetDisplayValue(@"2");
        }

        private void SetDisplayValue(string value)
        {
            var dv = edtDisplay.Tag as DisplayValue;
            dv.Value = value;
            _value = double.Parse(dv.Value);
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            SetDisplayValue(@"3");
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            SetDisplayValue(@"4");
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            SetDisplayValue(@"5");
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            SetDisplayValue(@"6");
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            SetDisplayValue(@"7");
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            SetDisplayValue(@"8");
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            SetDisplayValue(@"9");
        }

        private void btnClearEntry_Click(object sender, EventArgs e)
        {
            if (lbPhysicalParts.SelectedItem != null)
                lbPhysicalParts.Items.RemoveAt(lbPhysicalParts.SelectedIndex);
            edtDisplay.Text = "0";
            ((DisplayValue) edtDisplay.Tag).Clear();
            DisplayPhysicalParts();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lbPhysicalParts.Items.Clear();
            edtDisplay.Text = "0";
            lblPhysicalData.Text = "";
            DisplayPhysicalParts();
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
        }

        private void btnMega_Click(object sender, EventArgs e)
        {
            var dv = edtDisplay.Tag as DisplayValue;
            dv.SiPrefix = "M";
        }

        private void btnKilo_Click(object sender, EventArgs e)
        {
            var dv = edtDisplay.Tag as DisplayValue;
            dv.SiPrefix = "k";
        }

        private void btnGiga_Click(object sender, EventArgs e)
        {
            var dv = edtDisplay.Tag as DisplayValue;
            dv.SiPrefix = "G";
        }

        private void btnTera_Click(object sender, EventArgs e)
        {
            var dv = edtDisplay.Tag as DisplayValue;
            dv.SiPrefix = "T";
        }

        private void btnYotta_Click(object sender, EventArgs e)
        {
            var dv = edtDisplay.Tag as DisplayValue;
            dv.SiPrefix = "Y";
        }

        private void btnZetta_Click(object sender, EventArgs e)
        {
            var dv = edtDisplay.Tag as DisplayValue;
            dv.SiPrefix = "Z";
        }

        private void btnExa_Click(object sender, EventArgs e)
        {
            var dv = edtDisplay.Tag as DisplayValue;
            dv.SiPrefix = "E";
        }

        private void btnPeta_Click(object sender, EventArgs e)
        {
            var dv = edtDisplay.Tag as DisplayValue;
            dv.SiPrefix = "P";
        }

        private void btnYocto_Click(object sender, EventArgs e)
        {
            var dv = edtDisplay.Tag as DisplayValue;
            dv.SiPrefix = "y";
        }

        private void btnZepto_Click(object sender, EventArgs e)
        {
            var dv = edtDisplay.Tag as DisplayValue;
            dv.SiPrefix = "z";
        }

        private void btnAtto_Click(object sender, EventArgs e)
        {
            var dv = edtDisplay.Tag as DisplayValue;
            dv.SiPrefix = "a";
        }

        private void btnFemto_Click(object sender, EventArgs e)
        {
            var dv = edtDisplay.Tag as DisplayValue;
            dv.SiPrefix = "f";
        }

        private void btnPico_Click(object sender, EventArgs e)
        {
            var dv = edtDisplay.Tag as DisplayValue;
            dv.SiPrefix = "p";
        }

        private void btnNano_Click(object sender, EventArgs e)
        {
            var dv = edtDisplay.Tag as DisplayValue;
            dv.SiPrefix = "n";
        }

        private void btnMicro_Click(object sender, EventArgs e)
        {
            var dv = edtDisplay.Tag as DisplayValue;
            dv.SiPrefix = "μ";
        }

        private void btnDeci_Click(object sender, EventArgs e)
        {
            var dv = edtDisplay.Tag as DisplayValue;
            dv.SiPrefix = "d";
        }

        private void btnDeka_Click(object sender, EventArgs e)
        {
            var dv = edtDisplay.Tag as DisplayValue;
            dv.SiPrefix = "da";
        }

        private void btnHecto_Click(object sender, EventArgs e)
        {
            var dv = edtDisplay.Tag as DisplayValue;
            dv.SiPrefix = "h";
        }

        private void btnErrLmt_Click(object sender, EventArgs e)
        {
            _lastPhysicalPart = new ErrorLimit();
            lbPhysicalParts.SelectedIndex = lbPhysicalParts.Items.Add(_lastPhysicalPart);
            DisplayPhysicalParts();
        }

        private void DisplayPhysicalParts()
        {
            lblPhysicalData.Text = "";
            foreach (object physicalPart in lbPhysicalParts.Items)
            {
                lblPhysicalData.Text += physicalPart + " ";
            }
        }

        private void lbPhysicalParts_SelectedIndexChanged(object sender, EventArgs e)
        {
            _lastPhysicalPart = lbPhysicalParts.SelectedItem;
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            var errLimit = _lastPhysicalPart as ErrorLimit;
            if (errLimit != null)
            {
                errLimit.From = new Value();
                errLimit.From.value = edtDisplay.Text;
            }

            lbPhysicalParts.Invalidate();
            Update();
            DisplayPhysicalParts();
        }

        private void btnPlusMinus_Click(object sender, EventArgs e)
        {
            var dv = edtDisplay.Tag as DisplayValue;
            string value = dv.Prefix;
            if (value.StartsWith("+"))
                value = value.Replace("+", "-");
            else if (value.StartsWith("-"))
                value = value.Replace("-", "±");
            else if (value.StartsWith("±"))
                value = value.Replace("±", "");
            else
                value = "+" + value;

            dv.Prefix = value;
            edtDisplay.Text = dv.ToString();
            DisplayPhysicalParts();
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            var dv = edtDisplay.Tag as DisplayValue;
            dv.Suffix = "%";
            DisplayPhysicalParts();
        }

        private void btnVolts_Click(object sender, EventArgs e)
        {
            var dv = edtDisplay.Tag as DisplayValue;
            dv.Suffix = "V";
            DisplayPhysicalParts();
        }
    }

    internal class DisplayValue
    {
        private string _prefix = "";
        private string _siPrefix = "";
        private string _suffix = "";
        private string _value = "0";

        public DisplayValue()
        {
        }

        public DisplayValue(string prefix, string value, string suffix)
        {
            _prefix = prefix;
            _suffix = suffix;
            _value = value;
        }

        public string Prefix
        {
            get { return _prefix; }
            set
            {
                _prefix = value;
                OnValueChanged();
            }
        }

        public string Suffix
        {
            get { return _suffix; }
            set
            {
                _suffix = value;
                OnValueChanged();
            }
        }

        public string Value
        {
            get { return _value; }
            set
            {
                if (_value.StartsWith("0"))
                    _value = "";
                _value += value;
                OnValueChanged();
            }
        }

        public string SiPrefix
        {
            get { return _siPrefix; }
            set
            {
                _siPrefix = value;
                if (_suffix == "%")
                    _suffix = "";
                OnValueChanged();
            }
        }

        public event EventHandler ValueChanged;

        protected virtual void OnValueChanged()
        {
            EventHandler handler = ValueChanged;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        public override string ToString()
        {
            return Prefix + Value + SiPrefix + Suffix;
        }

        public void Clear()
        {
            _value = "";
            _prefix = "";
            _suffix = "";
            _siPrefix = "";
        }
    }
}