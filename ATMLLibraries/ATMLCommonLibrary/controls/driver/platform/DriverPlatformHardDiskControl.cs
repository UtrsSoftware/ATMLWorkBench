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
    public partial class DriverPlatformHardDiskControl : ATMLCommonLibrary.controls.ATMLControl
    {
        private HardwareItemDescriptionControlDriverPlatformHardDisk _hardDisk;

        
        public DriverPlatformHardDiskControl()
        {
            InitializeComponent();
        }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public HardwareItemDescriptionControlDriverPlatformHardDisk HardDisk
        {
            get { ControlsToData(); return _hardDisk; }
            set { _hardDisk = value; DataToControls(); }
        }

        private void DataToControls()
        {
            if (_hardDisk != null)
            {
                edtHardDisk.Value = _hardDisk.minimum;
            }
        }
        private void ControlsToData()
        {
            if (_hardDisk == null)
                _hardDisk = new HardwareItemDescriptionControlDriverPlatformHardDisk();
            _hardDisk.minimum=edtHardDisk.GetValue<string>();
        }
    }
}
