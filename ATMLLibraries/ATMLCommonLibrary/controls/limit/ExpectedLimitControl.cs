/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
using System;
using System.ComponentModel;
using ATMLCommonLibrary.controls.common;
using ATMLModelLibrary.model.common;

namespace ATMLCommonLibrary.controls.limit
{
    public partial class ExpectedLimitControl : ValueControl
    {
        private LimitExpected _expectedLimit;

        public ExpectedLimitControl()
        {
            InitializeComponent();
            cmbComparitor.DataSource = Enum.GetValues(typeof (EqualityComparisonOperator));
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public LimitExpected ExpectedLimit
        {
            get
            {
                ControlsToData();
                return _expectedLimit;
            }
            set
            {
                base.Value = _expectedLimit = value;
                DataToControls();
            }
        }

        protected void ControlsToData()
        {
            _expectedLimit = base.Value as LimitExpected;
            base.ControlsToData();
        }

        protected void DataToControls()
        {
            if (_expectedLimit != null)
            {
                base.DataToControls();
                cmbComparitor.SelectedIndex =
                    cmbComparitor.FindStringExact(Enum.GetName(typeof (EqualityComparisonOperator),
                        _expectedLimit.comparator));
            }
        }

        private void cmbValueType_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}