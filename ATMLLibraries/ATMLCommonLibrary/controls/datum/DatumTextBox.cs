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
    public partial class DatumTextBox : ATMLControl
    {
        private DatumType _datumType;
        private Label _label;

        public DatumTextBox()
        {
            InitializeComponent();
            edtImaginary.TextAlign = HorizontalAlignment.Right;
            edtReal.TextAlign = HorizontalAlignment.Right;
            SetControlStates();
        }

        public int DatumTypeIndex
        {
            set { SetEditStates(value); }
            get { return GetEditStates(); }
        }

        public Label Label
        {
            get { return _label; }
            set { _label = value; }
        }


        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DatumType DatumType
        {
            get
            {
                ControlsToData();
                return _datumType;
            }
            set
            {
                _datumType = value;
                DataToControls();
            }
        }


        public object Value
        {
            set
            {
                if (value is DatumType)
                {
                    DatumType = value as DatumType;
                }
                else if (value is double)
                {
                    var d = new @double();
                    d.value = (double) value;
                    DatumType = d;
                }
                else if (value is float)
                {
                    var d = new @double();
                    d.value = (float) value;
                    DatumType = d;
                }
                else if (value is int)
                {
                    var i = new integer();
                    i.value = (int) value;
                    DatumType = i;
                }
                else if (value is long)
                {
                    var l = new @long();
                    l.value = (long) value;
                    DatumType = l;
                }
                else if (value is uint)
                {
                    var i = new unsignedInteger();
                    i.value = (uint) value;
                    DatumType = i;
                }
                else if (value is ulong)
                {
                    var l = new unsignedLong();
                    l.value = (ulong) value;
                    DatumType = l;
                }
                else if (value is string)
                {
                    var s = new @string();
                    s.Value = (string) value;
                    DatumType = s;
                }
                else if (value is bool)
                {
                    var b = new boolean();
                    b.value = (bool) value;
                    DatumType = b;
                }
                else if (value is DateTime)
                {
                    var d = new dateTime();
                    d.value = (DateTime) value;
                    DatumType = d;
                }
                else if (value is DateTime)
                {
                    var d = new dateTime();
                    d.value = (DateTime) value;
                    DatumType = d;
                }

                //--- TODO: Need to figure how to hanle these values if they defaults ---//
                /*
                    if (datumType is binary)
                        value = edtValue.GetValue<string>();
                    else if (datumType is complex)
                    {
                        //((complex)datumType).real = edtReal.GetValue<double>();
                        //((complex)datumType).imaginary = edtImaginary.GetValue<double>();
                    }
                    else if (datumType is hexadecimal)
                        value = edtValue.GetValue<string>();
                    else if (datumType is octal)
                        value = edtValue.GetValue<string>();
                */
            }


            get
            {
                object value = null;
                if (_datumType != null)
                {
                    if (_datumType is binary)
                        value = edtValue.GetValue<string>();
                    else if (_datumType is boolean)
                        value = rbTrue.Checked;
                    else if (_datumType is complex)
                    {
                        //((complex)datumType).real = edtReal.GetValue<double>();
                        //((complex)datumType).imaginary = edtImaginary.GetValue<double>();
                    }
                    else if (_datumType is dateTime)
                        value = dateTimeValue.Value;
                    else if (_datumType is @double)
                        value = edtValue.GetValue<double>();
                    else if (_datumType is hexadecimal)
                        value = edtValue.GetValue<string>();
                    else if (_datumType is integer)
                        value = edtValue.GetValue<int>();
                    else if (_datumType is @long)
                        value = edtValue.GetValue<long>();
                    else if (_datumType is octal)
                        value = edtValue.GetValue<string>();
                    else if (_datumType is @string)
                        value = edtValue.GetValue<string>();
                    else if (_datumType is unsignedInteger)
                        value = edtValue.GetValue<uint>();
                    else if (_datumType is unsignedLong)
                        value = edtValue.GetValue<ulong>();
                }
                return value;
            }
        }


        private void ControlsToData()
        {
            if (_datumType != null)
            {
                if (_datumType is binary)
                    ((binary) _datumType).value = edtValue.GetValue<string>();
                else if (_datumType is boolean)
                    ((boolean) _datumType).value = rbTrue.Checked;
                else if (_datumType is complex)
                {
                    ((complex) _datumType).real = edtReal.GetValue<double>();
                    ((complex) _datumType).imaginary = edtImaginary.GetValue<double>();
                }
                else if (_datumType is dateTime)
                    ((dateTime) _datumType).value = dateTimeValue.Value;
                else if (_datumType is @double)
                    ((@double) _datumType).value = edtValue.GetValue<double>();
                else if (_datumType is hexadecimal)
                    ((hexadecimal) _datumType).value = edtValue.GetValue<string>();
                else if (_datumType is integer)
                    ((integer) _datumType).value = edtValue.GetValue<int>();
                else if (_datumType is @long)
                    ((@long) _datumType).value = edtValue.GetValue<long>();
                else if (_datumType is octal)
                    ((octal) _datumType).value = edtValue.GetValue<string>();
                else if (_datumType is @string)
                    ((@string) _datumType).Value = edtValue.GetValue<string>();
                else if (_datumType is unsignedInteger)
                    ((unsignedInteger) _datumType).value = edtValue.GetValue<uint>();
                else if (_datumType is unsignedLong)
                    ((unsignedLong) _datumType).value = edtValue.GetValue<ulong>();
            }
        }

        private void DataToControls()
        {
            if (_datumType != null)
            {
                if (_datumType is binary)
                    edtValue.Value = ((binary) _datumType).value;
                else if (_datumType is boolean)
                {
                    rbTrue.Checked = ((boolean) _datumType).value;
                    rbFalse.Checked = !((boolean) _datumType).value;
                }
                else if (_datumType is complex)
                {
                    edtReal.Value = ((complex) _datumType).real;
                    edtImaginary.Value = ((complex) _datumType).imaginary;
                }
                else if (_datumType is dateTime)
                    try
                    {
                        dateTimeValue.Value = ((dateTime) _datumType).value;
                    }
                    catch (Exception e)
                    {
                        dateTimeValue.Value = DateTime.Now;
                    }
                else if (_datumType is @double)
                    edtValue.Value = ((@double) _datumType).value;
                else if (_datumType is hexadecimal)
                    edtValue.Value = ((hexadecimal) _datumType).value;
                else if (_datumType is integer)
                    edtValue.Value = ((integer) _datumType).value;
                else if (_datumType is @long)
                    edtValue.Value = ((@long) _datumType).value;
                else if (_datumType is octal)
                    edtValue.Value = ((octal) _datumType).value;
                else if (_datumType is @string)
                    edtValue.Value = ((@string) _datumType).Value;
                else if (_datumType is unsignedInteger)
                    edtValue.Value = ((unsignedInteger) _datumType).value;
                else if (_datumType is unsignedLong)
                    edtValue.Value = ((unsignedLong) _datumType).value;

                SetControlStates();
            }
        }

        private void SetLabelText(String text)
        {
            if (_label != null)
                _label.Text = text;
        }

        private void SetControlStates()
        {
            dateTimeValue.Enabled = dateTimeValue.Visible = false;
            edtValue.Enabled = edtValue.Visible = false;
            edtImaginary.Enabled = edtImaginary.Visible = false;
            edtReal.Enabled = edtReal.Visible = false;
            rbFalse.Enabled = rbFalse.Visible = false;
            rbTrue.Enabled = rbTrue.Visible = false;

            if (_datumType is binary)
            {
                edtValue.Enabled = true;
                edtValue.Visible = true;
                edtValue.TextAlign = HorizontalAlignment.Left;
                SetLabelText("Binary");
            }
            else if (_datumType is boolean)
            {
                rbFalse.Enabled = true;
                rbFalse.Visible = true;
                rbTrue.Visible = true;
                SetLabelText("Boolean");
            }
            else if (_datumType is complex)
            {
                edtImaginary.Enabled = true;
                edtImaginary.Visible = true;
                edtReal.Visible = true;
                SetLabelText("Real/Imaginary");
            }
            else if (_datumType is dateTime)
            {
                dateTimeValue.Enabled = true;
                dateTimeValue.Visible = true;
                SetLabelText("Date Time");
            }
            else if (_datumType is @double)
            {
                edtValue.Enabled = true;
                edtValue.Visible = true;
                edtValue.TextAlign = HorizontalAlignment.Right;
                SetLabelText("Double");
            }
            else if (_datumType is hexadecimal)
            {
                edtValue.Enabled = true;
                edtValue.Visible = true;
                edtValue.TextAlign = HorizontalAlignment.Left;
                SetLabelText("Hexadecimal");
            }
            else if (_datumType is integer)
            {
                edtValue.Enabled = true;
                edtValue.Visible = true;
                edtValue.TextAlign = HorizontalAlignment.Right;
                SetLabelText("Integer");
            }
            else if (_datumType is @long)
            {
                edtValue.Enabled = true;
                edtValue.Visible = true;
                edtValue.TextAlign = HorizontalAlignment.Right;
                SetLabelText("Long");
            }
            else if (_datumType is octal)
            {
                edtValue.Enabled = true;
                edtValue.Visible = true;
                edtValue.TextAlign = HorizontalAlignment.Left;
                SetLabelText("Octal");
            }
            else if (_datumType is @string)
            {
                edtValue.Enabled = true;
                edtValue.Visible = true;
                edtValue.TextAlign = HorizontalAlignment.Left;
                SetLabelText("String");
            }
            else if (_datumType is unsignedInteger)
            {
                edtValue.Enabled = true;
                edtValue.Visible = true;
                edtValue.TextAlign = HorizontalAlignment.Right;
                SetLabelText("Unsigned Integer");
            }
            else if (_datumType is unsignedLong)
            {
                edtValue.Enabled = true;
                edtValue.Visible = true;
                edtValue.TextAlign = HorizontalAlignment.Right;
                SetLabelText("Unsigned Long");
            }
        }


        private void SetEditStates(int idx)
        {
            switch (idx)
            {
                case (int) Datum.DatumTypes.BINARY:
                    DatumType = new binary();
                    break;
                case (int) Datum.DatumTypes.BOOL:
                    DatumType = new boolean();
                    break;
                case (int) Datum.DatumTypes.COMPLEX:
                    DatumType = new complex();
                    break;
                case (int) Datum.DatumTypes.DATETIME:
                    DatumType = new dateTime();
                    break;
                case (int) Datum.DatumTypes.DOUBLE:
                    DatumType = new @double();
                    break;
                case (int) Datum.DatumTypes.HEX:
                    DatumType = new hexadecimal();
                    break;
                case (int) Datum.DatumTypes.INT:
                    DatumType = new integer();
                    break;
                case (int) Datum.DatumTypes.LONG:
                    DatumType = new @long();
                    break;
                case (int) Datum.DatumTypes.OCT:
                    DatumType = new octal();
                    break;
                case (int) Datum.DatumTypes.STRING:
                    DatumType = new @string();
                    break;
                case (int) Datum.DatumTypes.UINT:
                    DatumType = new unsignedInteger();
                    break;
                case (int) Datum.DatumTypes.ULONG:
                    DatumType = new unsignedLong();
                    break;
            }
        }


        private int GetEditStates()
        {
            int idx = -1;
            DatumType datumType = DatumType;
            if (datumType is binary)
                idx = (int) Datum.DatumTypes.BINARY;
            else if (datumType is boolean)
                idx = (int) Datum.DatumTypes.BOOL;
            else if (datumType is complex)
                idx = (int) Datum.DatumTypes.COMPLEX;
            else if (datumType is dateTime)
                idx = (int) Datum.DatumTypes.DATETIME;
            else if (datumType is @double)
                idx = (int) Datum.DatumTypes.DOUBLE;
            else if (datumType is hexadecimal)
                idx = (int) Datum.DatumTypes.HEX;
            else if (datumType is integer)
                idx = (int) Datum.DatumTypes.INT;
            else if (datumType is @long)
                idx = (int) Datum.DatumTypes.LONG;
            else if (datumType is octal)
                idx = (int) Datum.DatumTypes.OCT;
            else if (datumType is @string)
                idx = (int) Datum.DatumTypes.STRING;
            else if (datumType is unsignedInteger)
                idx = (int) Datum.DatumTypes.UINT;
            else if (datumType is unsignedLong)
                idx = (int) Datum.DatumTypes.ULONG;

            return idx;
        }

        private void DatumTextBox_Resize(object sender, EventArgs e)
        {
            SetControlWidths();
        }

        private void SetControlWidths()
        {
            edtReal.Width = Width/2;
            edtImaginary.Width = Width - edtReal.Width;
        }

        private void rbTrue_CheckedChanged(object sender, EventArgs e)
        {
            //Validate();
        }

        private void rbFalse_CheckedChanged(object sender, EventArgs e)
        {
            //Validate(true);
        }

        private void edtReal_KeyUp(object sender, KeyEventArgs e)
        {
            Datum.ValidateDatumValue(DatumType, null, errorProvider, edtReal, edtImaginary.Value);
        }

        private void edtImaginary_KeyUp(object sender, KeyEventArgs e)
        {
            Datum.ValidateDatumValue(DatumType, null, errorProvider, edtImaginary, edtImaginary.Value);
        }

        private void edtValue_KeyUp(object sender, KeyEventArgs e)
        {
            Datum.ValidateDatumValue(DatumType, null, errorProvider, edtValue, edtValue.Value);
        }

        private void dateTimeValue_ValueChanged(object sender, EventArgs e)
        {
            //Datum.ValidateDatumValue(this.DatumType, null, errorProvider, edtImaginary);
        }

        private void DatumTextBox_Validating(object sender, CancelEventArgs e)
        {
        }
    }
}