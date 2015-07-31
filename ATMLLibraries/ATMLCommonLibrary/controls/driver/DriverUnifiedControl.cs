/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.driver
{
    public partial class DriverUnifiedControl : ATMLControl
    {
        private DriverUnified _driverUnified;

        public DriverUnifiedControl()
        {
            InitializeComponent();
            driverModule32BitControl.DriverItemChoiceType = DriverItemChoiceType.Bit32;
            driverModule64BitControl.DriverItemChoiceType = DriverItemChoiceType.Bit64;
        }

        public DriverUnified DriverUnified
        {
            get { ControlsToData(); return _driverUnified; }
            set { _driverUnified = value; DataToControls(); }
        }

        protected void ControlsToData()
        {
            if( _driverUnified == null )
                _driverUnified = new DriverUnified();
            _driverUnified.Bit32 = driverModule32BitControl.DriverModule;
            _driverUnified.Bit64 = driverModule64BitControl.DriverModule;
        }

        protected void DataToControls()
        {
            if (_driverUnified != null)
            {
                driverModule32BitControl.DriverModule = _driverUnified.Bit32;
                driverModule64BitControl.DriverModule = _driverUnified.Bit64;
            }
        }

    }
}
