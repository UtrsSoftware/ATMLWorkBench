/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
using System.ComponentModel;
using ATMLModelLibrary.model.common;

namespace ATMLCommonLibrary.controls.limit
{
    public partial class SingleLimitSimpleControl : ATMLControl
    {
        public SingleLimitSimpleControl()
        {
            InitializeComponent();
            simpleLimitControl.OnSelectLimit += simpleLimitControl_OnSelectLimit;
            simpleLimitControl.LimitChanged += simpleLimitControl_LimitChanged;
        }

        public int DefaultLimitType
        {
            set { if (simpleLimitControl != null) simpleLimitControl.DefaultLimitType = value; }
        }

        public string DefaultStandardUnit
        {
            set { if (simpleLimitControl != null) simpleLimitControl.DefaultStandardUnit = value; }
        }

        public object DefaultValue
        {
            set { if (simpleLimitControl != null) simpleLimitControl.DefaultValue = value; }
        }


        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SingleLimit SingleLimit
        {
            get { return simpleLimitControl.SingleLimit; }
            set { simpleLimitControl.SingleLimit = value; }
        }

        private void simpleLimitControl_LimitChanged(SingleLimit selectedLimit)
        {
            lblLimitString.Text = selectedLimit.ToString();
        }

        private void simpleLimitControl_OnSelectLimit(SingleLimit selectedLimit)
        {
            lblLimitString.Text = selectedLimit.ToString();
        }
    }
}