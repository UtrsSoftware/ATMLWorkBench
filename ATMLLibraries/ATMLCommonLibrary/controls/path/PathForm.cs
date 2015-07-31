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
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.path
{
    public partial class PathForm : ATMLCommonLibrary.forms.ATMLForm
    {

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Path Path
        {
            get { return pathControl.Path; }
            set { pathControl.Path = value; }
        }

        public HardwareItemDescription HardwareItemDescription
        {
            get { return pathControl.HardwareItemDescription; }
            set { pathControl.HardwareItemDescription = value; }
        }

        public PathForm()
        {
            InitializeComponent();
           
        }

        private void PathForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (!ValidateChildren())
                {
                    e.Cancel = true;
                }
            }
        }

    }
}
