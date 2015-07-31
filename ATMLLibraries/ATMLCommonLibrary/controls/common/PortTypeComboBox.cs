/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ATMLModelLibrary.model.common;

namespace ATMLCommonLibrary.controls.common
{
    [ToolboxBitmap(typeof (ComboBox))]
    public partial class PortTypeComboBox : ComboBox
    {
        public PortTypeComboBox()
        {
            InitializeComponent();
            Items.Add( "" );
            if (!this.IsInDesignMode())
                Items.AddRange(Enum.GetNames(typeof (PortType)));
            SelectedIndex = -1;
        }

        public PortTypeComboBox(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            Items.Add("");
            if (!this.IsInDesignMode())
                Items.AddRange(Enum.GetNames(typeof (PortType)));
            SelectedIndex = -1;
        }
    }
}