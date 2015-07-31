/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System.ComponentModel;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.driver.platform
{
    public partial class DriverPlatformPhysicalMemoryControl : ATMLControl
    {
        private HardwareItemDescriptionControlDriverPlatformPhysicalMemory _physicalMem;

        public DriverPlatformPhysicalMemoryControl()
        {
            InitializeComponent();
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public HardwareItemDescriptionControlDriverPlatformPhysicalMemory PhysicalMem
        {
            get
            {
                ControlsToData();
                return _physicalMem;
            }
            set
            {
                _physicalMem = value;
                DataToControls();
            }
        }

        private void DataToControls()
        {
            if (_physicalMem != null)
            {
                edtMinimum.Value = _physicalMem.minimum;
            }
        }

        private void ControlsToData()
        {
            if (_physicalMem == null)
                _physicalMem = new HardwareItemDescriptionControlDriverPlatformPhysicalMemory();
            _physicalMem.minimum = edtMinimum.GetValue<string>();
        }
    }
}