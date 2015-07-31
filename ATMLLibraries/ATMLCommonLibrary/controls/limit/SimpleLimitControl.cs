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

namespace ATMLCommonLibrary.controls.limit
{
    public partial class SimpleLimitControl : ATMLControl
    {
        public delegate void OnSingleLimitChangeDelegate(SingleLimit selectedLimit);

        public delegate void OnExpectedLimitChangeDelegate(LimitExpected expectedLimit);

        public delegate void OnSelectSingleLimitDelegate(SingleLimit selectedLimit);

        public delegate void OnSelectExpectedLimitDelegate(LimitExpected expectedLimit);

        public enum ControlType
        {
            SimpleLimit,
            ExpectedLimit
        }

        private LimitExpected _expectedLimit = new LimitExpected();

        private ControlType _limitControlType = ControlType.SimpleLimit;
        private bool _showTitle = true;
        private bool _showTextPanel = true;
        private SingleLimit _singleLimit = new SingleLimit();
        private DatumType datum;

        public SimpleLimitControl()
        {
            InitializeComponent();
            SetComparitorDataSource();
            cmbLimitType.DataSource = Enum.GetNames(typeof (Datum.DatumTypes));
            standardUnitControl.OnChange += standardUnitControl_OnChange;
            //--------------------------------------------------//
            //--- Make sure the combos are initialized empty ---//
            //--------------------------------------------------//
            //cmbLimitComparitor.SelectedIndex = -1;
            cmbLimitType.SelectedIndex = -1;
            ShowTitle = true;
            textPanel.Visible = false;
        }

        public int DefaultComparitorIndex
        {
            set { cmbLimitComparitor.SelectedIndex = value; }
        }

        public int DefaultLimitType
        {
            set { cmbLimitType.SelectedIndex = value; }
        }

        public string DefaultStandardUnit
        {
            set { standardUnitControl.StandardUnit = value; }
        }

        public object DefaultValue
        {
            set { edtDatumType.Value = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SingleLimit SingleLimit
        {
            get
            {
                ControlsToData();
                return _singleLimit;
            }
            set
            {
                _singleLimit = value;
                DataToControls();
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public LimitExpected LimitExpected
        {
            get
            {
                ControlsToData();
                return ExpectedLimit;
            }
            set
            {
                ExpectedLimit = value;
                DataToControls();
            }
        }

        public String LimitName
        {
            get { return btnLimit.Text; }
            set { btnLimit.Text = value; }
        }

        public bool ShowTitle
        {
            get { return _showTitle; }
            set
            {
                _showTitle = value;
                lblComparitor.Visible = _showTitle;
                lblStandardUnit.Visible = _showTitle;
                lblType.Visible = _showTitle;
                lblValue.Visible = _showTitle;
            }
        }

        public ControlType LimitControlType
        {
            get { return _limitControlType; }
            set
            {
                _limitControlType = value;
                SetComparitorDataSource();
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public LimitExpected ExpectedLimit
        {
            get{ ControlsToData(); return _expectedLimit; }
            set { _expectedLimit = value; DataToControls(); }
        }

        public bool ShowTextPanel
        {
            get { return _showTextPanel; }
            set 
            { 
                textPanel.Visible = _showTextPanel = value;
                datumPanel.Visible = !value;
            }
        }

        public event OnSelectSingleLimitDelegate OnSelectLimit;
        public event OnSingleLimitChangeDelegate LimitChanged;
        public event OnSelectExpectedLimitDelegate SelectExpectedLimit;

        protected virtual void OnSelectExpectedLimit(LimitExpected expectedlimit)
        {
            OnSelectExpectedLimitDelegate handler = SelectExpectedLimit;
            if (handler != null) handler(expectedlimit);
        }

        public event OnExpectedLimitChangeDelegate ExpectedLimitChanged;

        protected virtual void OnExpectedLimitChanged(LimitExpected expectedlimit)
        {
            OnExpectedLimitChangeDelegate handler = ExpectedLimitChanged;
            if (handler != null) handler(expectedlimit);
        }

        private void SetComparitorDataSource()
        {
            if (_limitControlType == ControlType.SimpleLimit)
                cmbLimitComparitor.DataSource = Enum.GetNames(typeof (ComparisonOperator));
            else if (_limitControlType == ControlType.ExpectedLimit)
                cmbLimitComparitor.DataSource = Enum.GetNames(typeof (EqualityComparisonOperator));
        }

        private void standardUnitControl_OnChange(string stdUnit)
        {
            if (!Initializing)
            {
                ControlsToData();
                if (LimitChanged != null)
                    LimitChanged(_singleLimit);
            }
        }

        private void DataToControls()
        {
            if (_singleLimit != null || _expectedLimit != null)
            {
                Initializing = true;
                object item = null;
                if (_singleLimit != null && _limitControlType == ControlType.SimpleLimit)
                {
                    cmbLimitComparitor.SelectedIndex =
                        cmbLimitComparitor.FindStringExact(Enum.GetName(typeof (ComparisonOperator),
                            _singleLimit.comparator));
                    item = _singleLimit.Item;
                }
                else if (_expectedLimit != null && _limitControlType == ControlType.ExpectedLimit )
                {
                    cmbLimitComparitor.SelectedIndex =
                        cmbLimitComparitor.FindStringExact(Enum.GetName(typeof (EqualityComparisonOperator),
                            _expectedLimit.comparator));
                    item = _expectedLimit.Item;
                }

                ShowTextPanel = false;
                if (item is DatumType)
                {
                    datum = item as DatumType;
                    standardUnitControl.StandardUnit = datum.standardUnit;
                    //edtLimitValue.Value = Datum.GetDatumValue(datum);
                    edtDatumType.DatumType = datum;
                    Datum.SetDatumType(cmbLimitType, datum);
                }
                else
                {
                    ShowTextPanel = true;
                    if (item != null)
                        lblText.Text = item.ToString();
                }
                Initializing = false;
            }
        }

        private void ControlsToData()
        {
            InitLimit();

            if (datum == null)
                datum = Datum.GetDatumFromType(cmbLimitType);
            //Datum.SetDatumValue(edtLimitValue.GetValue<string>(), datum);
            datum = edtDatumType.DatumType;
            if (datum != null)
                datum.standardUnit = standardUnitControl.StandardUnit;

            if (_limitControlType == ControlType.SimpleLimit)
            {
                _singleLimit.Item = datum;
                if (cmbLimitComparitor.SelectedValue != null)
                    _singleLimit.comparator =
                        (ComparisonOperator)
                            Enum.Parse(typeof (ComparisonOperator), (String) cmbLimitComparitor.SelectedValue);
            }
            else if (_limitControlType == ControlType.ExpectedLimit)
            {
                _expectedLimit.Item = datum;
                if (cmbLimitComparitor.SelectedValue != null)
                    _expectedLimit.comparator =
                        (EqualityComparisonOperator)
                            Enum.Parse(typeof (EqualityComparisonOperator), (String) cmbLimitComparitor.SelectedValue);
            }
        }

        private void InitLimit()
        {
            if (_singleLimit == null && _limitControlType == ControlType.SimpleLimit)
                _singleLimit = new SingleLimit();
            else if (_expectedLimit == null && _limitControlType == ControlType.ExpectedLimit)
                _expectedLimit = new LimitExpected();
        }

        private void cmbLimit1Comparitor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Initializing)
            {
                ControlsToData();
                if (LimitChanged != null)
                    LimitChanged(_singleLimit);
            }
        }

        private void cmbLimit1Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Initializing)
            {
                datum = Datum.GetDatumFromType(cmbLimitType);
                edtDatumType.DatumType = datum;
                ControlsToData();
                if (LimitChanged != null)
                    LimitChanged(_singleLimit);
            }
        }


        private void edtLimit1Value_Validating(object sender, CancelEventArgs e)
        {
            edtDatumType.Validate();
            //Datum.ValidateDatumValue(datum, e, errorProvider, edtDatumType);
        }

        private void btnLimit1_Click(object sender, EventArgs e)
        {
            //Datum.SetDatumValue(edtDatumType.Value, datum);
            datum = edtDatumType.DatumType;
            ControlsToData(); //Load the limit item
            if (_limitControlType == ControlType.SimpleLimit)
            {
                _singleLimit.Item = datum;
                if (cmbLimitComparitor.SelectedValue != null )
                    _singleLimit.comparator = (ComparisonOperator)Enum.Parse( typeof (ComparisonOperator), 
                                                                             (String) cmbLimitComparitor.SelectedValue);
                var form = new SingleLimitForm(_singleLimit);
                RegisterForm( form );
                form.Closed += delegate(object sndr, EventArgs ee)
                {
                    UnRegisterForm((Form)sndr);
                    if (ee is FormClosedEventArgs)
                    {
                        var f = (Form)sndr;
                        if (DialogResult.OK == f.DialogResult)
                        {
                            try
                            {
                                SingleLimit = form.SingleLimit;
                                if (OnSelectLimit != null)
                                    OnSelectLimit(_singleLimit);
                                if (LimitChanged != null)
                                    LimitChanged(_singleLimit);
                            }
                            catch (Exception err)
                            {
                                MessageBox.Show(@"Error: " + err.Message, @"E R R O R");
                            }
                        }
                    }
                };
                form.Show();
            }
            else if (_limitControlType == ControlType.ExpectedLimit)
            {
                _expectedLimit.Item = datum;
                _expectedLimit.comparator =
                    (EqualityComparisonOperator)
                        Enum.Parse(typeof(EqualityComparisonOperator), (String)cmbLimitComparitor.SelectedValue);
                var form = new ExpectedLimitForm(_expectedLimit);
                RegisterForm( form );
                form.Closed += delegate(object sndr, EventArgs ee)
                {
                    UnRegisterForm((Form)sndr);
                    if (ee is FormClosedEventArgs)
                    {
                        var f = (Form)sndr;
                        if (DialogResult.OK == f.DialogResult)
                        {
                            try
                            {
                                ExpectedLimit = form.LimitExpected;
                            }
                            catch (Exception err)
                            {
                                MessageBox.Show(@"Error: " + err.Message, @"E R R O R");
                            }
                        }
                    }
                };
                form.Show();
            }
        }

        private void SimpleLimitControl_Load(object sender, EventArgs e)
        {
            if (!this.IsInDesignMode())
            {
            }
        }

        private void edtLimitValue_KeyUp(object sender, KeyEventArgs e)
        {
            ControlsToData();
            if (LimitChanged != null)
                LimitChanged(_singleLimit);
        }

        private void lblText_Click(object sender, EventArgs e)
        {

        }
    }
}