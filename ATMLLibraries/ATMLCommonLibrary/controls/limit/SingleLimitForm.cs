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
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ATMLCommonLibrary.controls.limit;
using ATMLModelLibrary.model.common;



namespace ATMLCommonLibrary.controls.limit
{
    public partial class SingleLimitForm : ATMLCommonLibrary.forms.ATMLForm
    {

        public SingleLimit SingleLimit
        {
            get { return this.singleLimitControl.SingleLimit; }
            set { this.singleLimitControl.SingleLimit = value; }
        }

        public SingleLimitForm()
        {
            InitializeComponent();
        }

        public SingleLimitForm( SingleLimit limit )
        {
            InitializeComponent();
            SingleLimit = limit;
        }

    }
}
