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
using ATMLModelLibrary.model.common;

namespace ATMLCommonLibrary.controls.limit
{
    public partial class LimitPairControl : ATMLControl
    {
        private LimitPair _limitPair;

        public LimitPairControl()
        {
            InitializeComponent();
        }

        public int DefaultComparitor
        {
            set
            {
                simpleLimitControl1.DefaultComparitorIndex = value;
                simpleLimitControl2.DefaultLimitType = value;
            }
        }

        public int DefaultLimitType
        {
            set
            {
                simpleLimitControl1.DefaultLimitType = value;
                simpleLimitControl2.DefaultLimitType = value;
            }
        }

        public string DefaultStandardUnit
        {
            set
            {
                if (simpleLimitControl1.SingleLimit != null) simpleLimitControl1.DefaultStandardUnit = value;
                if (simpleLimitControl2.SingleLimit != null) simpleLimitControl2.DefaultStandardUnit = value;
            }
        }

        public object DefaultValue
        {
            set
            {
                if (simpleLimitControl1.SingleLimit != null) simpleLimitControl1.DefaultValue = value;
                if (simpleLimitControl2.SingleLimit != null) simpleLimitControl2.DefaultValue = value;
            }
        }


        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public LimitPair LimitPair
        {
            get
            {
                ControlsToData();
                return _limitPair;
            }
            set
            {
                _limitPair = value;
                DataToControls();
            }
        }

        private void DataToControls()
        {
            if (_limitPair != null)
            {
                Initializing = true;
                edtName.Value = _limitPair.name;
                edtNominalValue.Value = _limitPair.Nominal;
                cmbOperator.SelectedIndex =
                    cmbOperator.FindStringExact(Enum.GetName(typeof (LogicalOperator), _limitPair.@operator));
                List<SingleLimit> pair = _limitPair.Limit;
                if (pair.Count > 0)
                {
                    simpleLimitControl1.SingleLimit = pair[0];
                }
                if (pair.Count > 1)
                {
                    simpleLimitControl2.SingleLimit = pair[1];
                }
                Initializing = false;
            }
        }


        private void ControlsToData()
        {
            InitLimitPair();

            _limitPair.name = edtName.GetValue<string>();
            //limitPair.Nominal = edtNominalValue.GetValue<string>();
            if (cmbOperator.SelectedItem != null)
                _limitPair.@operator =
                    (LogicalOperator) Enum.Parse(typeof (LogicalOperator), (String) cmbOperator.SelectedItem);
            SingleLimit limit1 = simpleLimitControl1.SingleLimit;
            SingleLimit limit2 = simpleLimitControl2.SingleLimit;

            _limitPair.Limit[0] = limit1;
            _limitPair.Limit[1] = limit2;
        }


        private void InitLimitPair()
        {
            if (_limitPair == null)
                _limitPair = new LimitPair();

            if (_limitPair.Limit == null)
                _limitPair.Limit = new List<SingleLimit>();

            if (_limitPair.Limit.Count < 1)
                _limitPair.Limit.Add(new SingleLimit());
            if (_limitPair.Limit.Count < 2)
                _limitPair.Limit.Add(new SingleLimit());
        }

    }
}