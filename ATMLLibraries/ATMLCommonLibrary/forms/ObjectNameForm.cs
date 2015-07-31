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

namespace ATMLCommonLibrary.forms
{
    public sealed partial class ObjectNameForm : ATMLCommonLibrary.forms.ATMLForm
    {

        public ObjectNameForm( string title )
        {
            InitializeComponent();
            this.Text = title;
        }

        public string ObjectName{ get { return edtName.Text; }}

        public string RegularExpression
        {
            get { return regularExpressionValidator.RegularExpression; }
            set { regularExpressionValidator.RegularExpression = value; }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
