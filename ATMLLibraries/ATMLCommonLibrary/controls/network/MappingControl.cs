/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System.Windows.Forms;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.network
{
    public partial class MappingControl : ATMLControl
    {

        public MappingControl()
        {
            InitializeComponent();
            networkListControl.CapabilityMapMode = true;
        }

        public HardwareItemDescription HardwareItemDescription
        {
            get { return networkListControl.HardwareItemDescription; }
            set { networkListControl.HardwareItemDescription = value; }
        }

        public Mapping Mapping
        {
            get { return networkListControl.Mapping; }
            set { networkListControl.Mapping = value; }
        }

    }
}
