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
    public partial class DriverPlatformControl : ATMLControl
    {
        private HardwareItemDescriptionControlDriverPlatform _platform;

        public DriverPlatformControl()
        {
            InitializeComponent();
        }

        [Browsable( false ), DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
        public HardwareItemDescriptionControlDriverPlatform Platform
        {
            get
            {
                ControlsToData();
                return _platform;
            }
            set
            {
                _platform = value;
                DataToControls();
            }
        }

        private void DataToControls()
        {
            if (_platform != null)
            {
                Processor.Processor = _platform.Processor;
                HardDisk.HardDisk = _platform.HardDisk;
                OperatingSystem.OSList = _platform.OperatingSystem;
                PhysicalMem.PhysicalMem = _platform.PhysicalMemory;
            }
        }

        private void ControlsToData()
        {
            if (_platform == null)
                _platform = new HardwareItemDescriptionControlDriverPlatform();
            _platform.Processor = Processor.Processor;
            _platform.HardDisk = HardDisk.HardDisk;
            _platform.OperatingSystem = OperatingSystem.OSList;
            _platform.PhysicalMemory = PhysicalMem.PhysicalMem;
        }
    }
}