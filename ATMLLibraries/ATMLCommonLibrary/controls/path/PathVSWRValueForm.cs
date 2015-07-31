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
using ATMLCommonLibrary.controls.common;
using ATMLCommonLibrary.controls.equipment;

namespace ATMLCommonLibrary.controls.path
{
    public partial class PathVSWRValueForm : ATMLCommonLibrary.forms.ATMLForm
    {
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PathVSWRValue PathVSWRValue
        {
            get { return pathVSWRValueControl.PathVSWRValue; }
            set { pathVSWRValueControl.PathVSWRValue = value; }
        }
        public PathVSWRValueForm()
        {
            InitializeComponent();
        }

    }
}
