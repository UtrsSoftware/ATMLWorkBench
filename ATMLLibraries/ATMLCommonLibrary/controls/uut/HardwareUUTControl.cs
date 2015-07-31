/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using ATMLCommonLibrary.controls.hardware;
using ATMLModelLibrary.model.uut;

namespace ATMLCommonLibrary.controls.uut
{
    public partial class HardwareUUTControl : HardwareItemDescriptionControl
    {
        public HardwareUUTControl()
        {
            InitializeComponent();
        }

        public HardwareUUT HardwareUUT
        {
            get
            {
                ControlsToData();
                return _hardwareItemDescription as HardwareUUT;
            }
            set
            {
                _hardwareItemDescription = value;
                DataToControls();
            }
        }

        protected void ControlsToData()
        {
            if (_hardwareItemDescription == null)
                _hardwareItemDescription = new HardwareUUT();
            base.ControlsToData();
            //hu.Warnings;
            //hu.StatusCodes;
        }

        protected void DataToControls()
        {
            base.DataToControls();
            if (_hardwareItemDescription != null)
            {
                var hu = _hardwareItemDescription as HardwareUUT;
                //hu.Warnings;
                //hu.StatusCodes;
            }
        }
    }
}