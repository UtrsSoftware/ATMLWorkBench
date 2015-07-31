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
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ATMLModelLibrary.model.common;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.bus
{
    public partial class DeviceCategorySelectionComboBox : ComboBox
    {
        public DeviceCategorySelectionComboBox()
        {
            InitializeComponent();
            DataSource = Enum.GetNames(typeof(DeviceCategory));
        }

        public DeviceCategorySelectionComboBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
