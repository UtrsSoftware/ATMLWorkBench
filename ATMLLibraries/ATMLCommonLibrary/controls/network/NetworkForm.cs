/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using ATMLCommonLibrary.forms;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.network
{
    public partial class NetworkForm : ATMLForm
    {
        public bool CapabilityMapMode { set { networkControl.CapabilityMapMode = value; } get
        {
            return networkControl.CapabilityMapMode;
        } }

        public NetworkForm()
        {
            InitializeComponent();
        }

        public HardwareItemDescription HardwareItemDescription
        {
            set { networkControl.HardwareItemDescription = value; }
        }

        public Network Network
        {
            set { networkControl.Network = value; }
            get { return networkControl.Network; }
        }
    }
}