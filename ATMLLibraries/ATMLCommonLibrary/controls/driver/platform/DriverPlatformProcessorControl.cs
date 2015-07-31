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
    public partial class DriverPlatformProcessorControl : ATMLControl
    {
        private DriverPlatformProcessor _processor;

        public DriverPlatformProcessorControl()
        {
            InitializeComponent();
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DriverPlatformProcessor Processor
        {
            get
            {
                ControlsToData();
                return _processor;
            }
            set
            {
                _processor = value;
                DataToControls();
            }
        }

        private void DataToControls()
        {
            if (_processor != null)
            {
                edtSpeed.Value = _processor.speed;
            }
        }

        private void ControlsToData()
        {
            if (_processor == null)
                _processor = new DriverPlatformProcessor();
            _processor.speed = edtSpeed.GetValue<string>();
        }
    }
}