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
using System.Windows.Forms;
using ATMLModelLibrary.model.common;
using ATMLCommonLibrary.utils;
using Value = ATMLCommonLibrary.utils.Value;

namespace ATMLCommonLibrary.controls.limit
{
    public partial class LimitControl : ATMLControl
    {
        public const int NO_VALUE = -1;
        public const int LIMIT_EXPECTED = 0;
        public const int LIMIT_MASK = 1;
        public const int LIMIT_PAIR = 2;
        public const int LIMIT_SINGLE = 3;

        private int _defaultComparitor = NO_VALUE;

        private int _defaultLimitType = NO_VALUE;

        private string _defaultStandardUnit;

        private object _defaultValue;

        protected Limit _limit;
        private UserControl _limitTypeControl;

        public LimitControl()
        {
            InitializeComponent();
            cmbOperator.DataSource = Enum.GetNames(typeof (LogicalOperator));
            cmbOperator.SelectedIndex = NO_VALUE;
        }

        public int DefaultComparitor
        {
            get { return _defaultComparitor; }
            set { _defaultComparitor = value; }
        }

        public int DefaultLimitType
        {
            get { return _defaultLimitType; }
            set { _defaultLimitType = value; }
        }

        public string DefaultStandardUnit
        {
            get { return _defaultStandardUnit; }
            set { _defaultStandardUnit = value; }
        }

        public object DefaultValue
        {
            get { return _defaultValue; }
            set { _defaultValue = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Limit Limit
        {
            get
            {
                ControlsToData();
                return _limit;
            }
            set
            {
                _limit = value;
                DataToControls();
            }
        }

        virtual protected void ControlsToData()
        {
            if (_limit == null)
                _limit = new Limit();
            _limit.Description = edtLimitDescription.GetValue<string>();
            _limit.name = edtLimitName.GetValue<string>();
            _limit.operatorSpecified = cmbOperator.SelectedIndex != -1;
            if (_limit.operatorSpecified)
                _limit.@operator =
                    (LogicalOperator) Enum.Parse(typeof (LogicalOperator), (String) cmbOperator.SelectedValue);

            //TODO: Add Limit Extension if needed

            switch (cmbLimitType.SelectedIndex)
            {
                case LIMIT_EXPECTED:
                    _limit.Item = ((ExpectedLimitSimpleControl) _limitTypeControl).LimitExpected;
                    break;
                case LIMIT_MASK:
                    _limit.Item = ((LimitMaskControl) _limitTypeControl).LimitMask;
                    break;
                case LIMIT_PAIR:
                    _limit.Item = ((LimitPairControl) _limitTypeControl).LimitPair;
                    break;
                case LIMIT_SINGLE:
                    _limit.Item = ((SingleLimitSimpleControl) _limitTypeControl).SingleLimit;
                    break;
                case NO_VALUE:
                    _limit = null;
                    break;
            }
        }

        virtual protected void DataToControls()
        {
            if (_limit == null)
                _limit = new Limit();

            InitLimitTypeCombo();
            SetControlStates();
            edtLimitName.Text = _limit.name;
            edtLimitDescription.Text = _limit.Description;

            if (_limit.operatorSpecified)
                cmbOperator.SelectedValue = _limit.@operator;

            if (_limit.Item is LimitMask)
                ((LimitMaskControl) _limitTypeControl).LimitMask = (LimitMask) _limit.Item;
            else if (_limit.Item is LimitExpected)
                ((ExpectedLimitSimpleControl) _limitTypeControl).LimitExpected = (LimitExpected) _limit.Item;
            else if (_limit.Item is LimitPair)
                ((LimitPairControl) _limitTypeControl).LimitPair = (LimitPair) _limit.Item;
            else if (_limit.Item is SingleLimit)
                ((SingleLimitSimpleControl) _limitTypeControl).SingleLimit = (SingleLimit) _limit.Item;
        }

        private void InitLimitTypeCombo()
        {
            if (_limit.Item is LimitMask)
                cmbLimitType.SelectedIndex = LIMIT_MASK;
            else if (_limit.Item is LimitExpected)
                cmbLimitType.SelectedIndex = LIMIT_EXPECTED;
            else if (_limit.Item is LimitPair)
                cmbLimitType.SelectedIndex = LIMIT_PAIR;
            else if (_limit.Item is SingleLimit)
                cmbLimitType.SelectedIndex = LIMIT_SINGLE;
        }

        private void cmbLimitType_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetControlStates();
        }

        private void SetControlStates()
        {
            if (_limitTypeControl != null)
                panel1.Controls.Clear();

            switch (cmbLimitType.SelectedIndex)
            {
                case LIMIT_EXPECTED:
                    _limitTypeControl = new ExpectedLimitSimpleControl();
                    break;
                case LIMIT_PAIR:
                    _limitTypeControl = new LimitPairControl();
                    ((LimitPairControl) _limitTypeControl).DefaultComparitor = _defaultComparitor;
                    ((LimitPairControl) _limitTypeControl).DefaultLimitType = _defaultLimitType;
                    ((LimitPairControl) _limitTypeControl).DefaultStandardUnit = _defaultStandardUnit;
                    ((LimitPairControl) _limitTypeControl).DefaultValue = _defaultValue;
                    break;
                case LIMIT_MASK:
                    _limitTypeControl = new LimitMaskControl();
                    break;
                case LIMIT_SINGLE:
                    _limitTypeControl = new SingleLimitSimpleControl();
                    ((SingleLimitSimpleControl) _limitTypeControl).DefaultLimitType = _defaultLimitType;
                    ((SingleLimitSimpleControl) _limitTypeControl).DefaultStandardUnit = _defaultStandardUnit;
                    ((SingleLimitSimpleControl) _limitTypeControl).DefaultValue = _defaultValue;
                    break;
            }

            if (_limitTypeControl != null)
            {
                _limitTypeControl.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left)
                                           | AnchorStyles.Right;
                _limitTypeControl.Location = new Point(0, 0);
                _limitTypeControl.Name = "limitTypeControl";
                _limitTypeControl.Size = new Size(417, 176);
                _limitTypeControl.TabIndex = 9;
                _limitTypeControl.Dock = DockStyle.Fill;
                panel1.Controls.Add(_limitTypeControl);
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string input1 = edtQuickEntry.Text;
            string input2 = null;
            int idx = input1.IndexOf(" to ", System.StringComparison.Ordinal);
            if (idx != -1)
            {
                input2 = input1.Substring(idx + " to ".Length );
                input1 = input1.Substring(0, idx);
            }

            bool useLimitPair = false;
            List<Value> values1 = ElectricalUtils.ParseExpression(input1);
            List<Value> values2 = null;
            if (input2 != null)
            {
                values2 = ElectricalUtils.ParseExpression(input2);
                useLimitPair = true;
            }

            if (values1.Count > 0)
            {
                Value value1 = values1[0];
                ErrorLimit errorLimit1 = value1.errorLimit;
                Value resolution1 = value1.resoluion;
                string unit1 = value1.unit;
                string val1 = value1.value;
                @double datum1 = value1.@double;
                _limit = new Limit();
                if (!useLimitPair)
                {
                    cmbLimitType.SelectedIndex = LIMIT_EXPECTED;
                    var le = new LimitExpected { Item = datum1 };
                    _limit.Item = le;
                    //20msV errlmt 0.01% res 1mV range 50mV to 10V  range 100mV to 20V
                }
                else
                {
                    cmbLimitType.SelectedIndex = LIMIT_PAIR;
                    SingleLimit limit1 = new SingleLimit();
                    SingleLimit limit2 = new SingleLimit();
                    limit1.comparator = ComparisonOperator.GE;
                    limit2.comparator = ComparisonOperator.LE;
                    var lp = new LimitPair {Limit = new List<SingleLimit> {limit1, limit2}};
                    limit1.Item = datum1;
                    if ( values2.Count > 0)
                    {
                        Value value2 = values2[0];
                        ErrorLimit errorLimit2 = value2.errorLimit;
                        Value resolution2 = value2.resoluion;
                        string unit2 = value2.unit;
                        string val2 = value2.value;
                        @double datum2 = value2.@double;
                        limit2.Item = datum2;
                        //20mV errlmt 0.01% res 1mV range 50mV to 10V  range 100mV to 20V
                    }
                    _limit.Item = lp;
                }
                DataToControls();
            }

        }

        private void edtQuickEntry_KeyUp(object sender, KeyEventArgs e)
        {
        }

        private void edtQuickEntry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSubmit.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

        /*
         *  this.limitPairControl = new ATMLCommonLibrary.controls.limit.LimitPairControl();
            this.limitMaskControl = new ATMLCommonLibrary.controls.limit.LimitMaskControl();
            this.singleLimitControl = new ATMLCommonLibrary.controls.limit.SingleLimitControl();
            this.limitExpectedControl = new ATMLCommonLibrary.controls.limit.LimitExpectedControl();
         * 
         * 
         *  this.Controls.Add(this.limitExpectedControl);

         *  private LimitMaskControl limitMaskControl;
            private LimitPairControl limitPairControl;
            private LimitExpectedControl limitExpectedControl;
            private SingleLimitControl singleLimitControl;

            // 
            // limitPairControl
            // 
            this.limitPairControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.limitPairControl.LimitPair = null;
            this.limitPairControl.Location = new System.Drawing.Point(17, 156);
            this.limitPairControl.Name = "limitPairControl";
            this.limitPairControl.Size = new System.Drawing.Size(417, 176);
            this.limitPairControl.TabIndex = 9;
         */
    }
}