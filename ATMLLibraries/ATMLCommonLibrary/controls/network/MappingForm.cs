/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using ATMLCommonLibrary.forms;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.network
{
    public partial class MappingForm : ATMLForm
    {
        public MappingForm(HardwareItemDescription hardwareItemDescription )
        {
            InitializeComponent();
            mappingControl.HardwareItemDescription = hardwareItemDescription;
        }

        public Mapping Mapping
        {
            set { mappingControl.Mapping = value; }
            get { return mappingControl.Mapping; }
        }

    }
}
