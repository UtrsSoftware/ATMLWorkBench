/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System.ComponentModel;
using ATMLCommonLibrary.forms;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.control.driver
{
    public partial class ControlDriverForm : ATMLForm
    {
        public ControlDriverForm()
        {
            InitializeComponent();
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public HardwareItemDescriptionControlDriver HardwareItemDescriptionControlDriver
        {
            get { return controlDriverControl1.HardwareItemDescriptionControlDriver; }
            set { controlDriverControl1.HardwareItemDescriptionControlDriver = value; }
        }

    }
}
