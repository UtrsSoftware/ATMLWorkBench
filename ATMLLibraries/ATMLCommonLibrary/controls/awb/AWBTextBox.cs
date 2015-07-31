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
using ATMLCommonLibrary.managers;

namespace ATMLCommonLibrary.controls.awb
{
    public partial class AWBTextBox : TextBox
    {
        private string _attributeName;

        public enum eValueType
        {
            xsString,
            xsInteger,
            xsLong,
            xsDouble,
            xsFloat,
            xsULong,
            xsUInteger
        };

        private object _value;

        private eValueType _valueType = eValueType.xsString;

        public AWBTextBox()
        {
            InitializeComponent();
            Enter += AWBTextBox_Enter;
        }

        public AWBTextBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public string DataLookupKey { set; get; }

        public object Value
        {
            get
            {
                if (!String.IsNullOrEmpty(base.Text))
                {
                    switch (_valueType)
                    {
                        case eValueType.xsDouble:
                            double dValue = 0d;
                            if (!double.TryParse(base.Text, out dValue))
                                MessageBox.Show(@"Invalid Type, expecting a double value", @"E R R O R",
                                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            else
                                _value = dValue;
                            break;
                        case eValueType.xsLong:
                            long lValue = 0l;
                            if (!long.TryParse(base.Text, out lValue))
                                MessageBox.Show(@"Invalid Type, expecting a long value", @"E R R O R",
                                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            else
                                _value = lValue;
                            break;
                        case eValueType.xsULong:
                            ulong ulValue = 0;
                            if (!ulong.TryParse(base.Text, out ulValue))
                                MessageBox.Show(@"Invalid Type, expecting an unsigned long value", @"E R R O R",
                                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            else
                                _value = ulValue;
                            break;
                        case eValueType.xsUInteger:
                            uint uiValue = 0;
                            if (!uint.TryParse(base.Text, out uiValue))
                                MessageBox.Show(@"Invalid Type, expecting an ubnsigned integer value", @"E R R O R",
                                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            else
                                _value = uiValue;
                            break;
                        case eValueType.xsInteger:
                            int iValue = 0;
                            if (!int.TryParse(base.Text, out iValue))
                                MessageBox.Show(@"Invalid Type, expecting an integer value", @"E R R O R",
                                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            else
                                _value = iValue;
                            break;
                        case eValueType.xsFloat:
                            float fValue = 0f;
                            if (!float.TryParse(base.Text, out fValue))
                                MessageBox.Show(@"Invalid Type, expecting a float value", @"E R R O R",
                                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            else
                                _value = fValue;
                            break;
                        case eValueType.xsString:
                            _value = String.IsNullOrWhiteSpace(base.Text) ? null : base.Text;
                            break;
                    }
                }
                else
                {
                    switch (_valueType)
                    {
                        case eValueType.xsDouble:
                            _value = 0d;
                            break;
                        case eValueType.xsLong:
                            _value = 0L;
                            break;
                        case eValueType.xsInteger:
                            _value = 0;
                            break;
                        case eValueType.xsFloat:
                            _value = 0f;
                            break;
                        case eValueType.xsUInteger:
                            _value = 0;
                            break;
                        case eValueType.xsULong:
                            _value = 0;
                            break;
                        case eValueType.xsString:
                            _value = null;
                            break;
                        default:
                            _value = null;
                            break;
                    }
                }
                return _value;
            }
            set { SetText(value); }
        }

        public eValueType ValueType
        {
            get { return _valueType; }
            set { _valueType = value; }
        }

        public override String Text
        {
            get
            {
                Tag = Value;
                return base.Text;
            }
            set
            {
                Tag = value;
                base.Text = value;
            }
        }

        public string AttributeName
        {
            get { return _attributeName; }
            set { _attributeName = value; }
        }

        private void AWBTextBox_Enter(object sender, EventArgs e)
        {
            FormManager.LastActiveControl = this;
            SelectAll();
        }

        public T GetValue<T>()
        {
            SetType(typeof(T));
            T val = (T)Value;
            return val;
        }

        private void SetType(Type _type)
        {
            if (_type == typeof (ulong))
                _valueType = eValueType.xsULong;
            else if (_type == typeof (uint))
                _valueType = eValueType.xsUInteger;
            else if (_type == typeof (int))
                _valueType = eValueType.xsInteger;
            else if (_type == typeof (long))
                _valueType = eValueType.xsLong;
            else if (_type == typeof (double))
                _valueType = eValueType.xsDouble;
            else if (_type == typeof (float))
                _valueType = eValueType.xsFloat;
            else if (_type == typeof (string))
                _valueType = eValueType.xsString;
        }

        private bool SetText(object value)
        {
            if (value != null)
                SetType(value.GetType());
            _value = value;
            base.Text = (value == null ? "" : value.ToString().Trim());
            //Console.WriteLine(@"setting " + Name + @" to " + base.Text + @" Handle: " + Handle);
            return value != null;
        }

        public void GetValue<T>(out T value)
        {
            SetType(typeof (T));
            value = (T) Value;
        }

        public bool HasValue()
        {
            return _value != null;
        }

    }
}