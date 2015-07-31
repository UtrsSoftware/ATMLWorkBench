/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
using System.Windows.Forms;
using ATMLModelLibrary.model.common;

namespace ATMLCommonLibrary.controls.limit
{
    public partial class ExpectedLimitSimpleControl : UserControl
    {
        public ExpectedLimitSimpleControl()
        {
            InitializeComponent();
            simpleLimitControl.LimitControlType = SimpleLimitControl.ControlType.ExpectedLimit;
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


        public LimitExpected LimitExpected
        {
            get { return simpleLimitControl.ExpectedLimit; }
            set { simpleLimitControl.ExpectedLimit = value; }
        }
    }
}