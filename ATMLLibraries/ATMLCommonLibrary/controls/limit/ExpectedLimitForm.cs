/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
using ATMLCommonLibrary.forms;
using ATMLModelLibrary.model.common;

namespace ATMLCommonLibrary.controls.limit
{
    public partial class ExpectedLimitForm : ATMLForm
    {
        public ExpectedLimitForm()
        {
            InitializeComponent();
        }

        public ExpectedLimitForm(LimitExpected limit)
        {
            InitializeComponent();
            LimitExpected = limit;
        }

        public LimitExpected LimitExpected
        {
            get { return expectedLimitControl.ExpectedLimit; }
            set { expectedLimitControl.ExpectedLimit = value; }
        }
    }
}