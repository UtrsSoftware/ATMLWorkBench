/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System.ComponentModel;
using ATMLCommonLibrary.controls.hardware;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.driver.platform
{
    public partial class DriverPlatformOperatingSystemControl : VersionIdentifierControl
    {
        public DriverPlatformOperatingSystemControl()
        {
            InitializeComponent();
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DriverPlatformOperatingSystem OperatingSystem
        {
            get
            {
                ControlsToData();
                return _versionIdentifier as DriverPlatformOperatingSystem;
            }
            set
            {
                _versionIdentifier = value;
                DataToControls();
            }
        }

        private void DataToControls()
        {
            if (_versionIdentifier != null)
            {
                var OS = _versionIdentifier as DriverPlatformOperatingSystem;
                base.DataToControls();
                if (OS != null)
                {
                    edtServicePack.Value = OS.servicePack;
                }
            }
        }

        private void ControlsToData()
        {
            if (_versionIdentifier == null)
                _versionIdentifier = new DriverPlatformOperatingSystem();
            base.ControlsToData();
            var OS = _versionIdentifier as DriverPlatformOperatingSystem;
            if (OS == null)
            {
                OS.servicePack = edtServicePack.GetValue<string>();
            }
        }
    }
}