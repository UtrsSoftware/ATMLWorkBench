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
    public partial class SingleLimitControl : ValueControl
    {
        private SingleLimit singleLimit;

        public SingleLimitControl()
        {
            InitializeComponent();
            cmbComparitor.DataSource = Enum.GetValues(typeof (ComparisonOperator));
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SingleLimit SingleLimit
        {
            get
            {
                ControlsToData();
                return singleLimit;
            }
            set
            {
                base.Value = singleLimit = value;
                DataToControls();
            }
        }

        private void ControlsToData()
        {
            singleLimit = base.Value as SingleLimit;
            base.ControlsToData();
        }

        private void DataToControls()
        {
            if (singleLimit != null)
            {
                base.DataToControls();
                cmbComparitor.SelectedIndex =
                    cmbComparitor.FindStringExact(Enum.GetName(typeof (ComparisonOperator), singleLimit.comparator));
            }
        }

        private void cmbValueType_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}