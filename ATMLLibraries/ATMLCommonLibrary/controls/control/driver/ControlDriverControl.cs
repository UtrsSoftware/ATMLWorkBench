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

namespace ATMLCommonLibrary.controls.control.driver
{
    public partial class ControlDriverControl : VersionIdentifierControl
    {
        public ControlDriverControl()
        {
            InitializeComponent();
            
        }

        [Browsable( false ), DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
        public HardwareItemDescriptionControlDriver HardwareItemDescriptionControlDriver
        {
            get
            {
                ControlsToData();
                return _versionIdentifier as HardwareItemDescriptionControlDriver;
            }
            set
            {
                _versionIdentifier = value;
                DataToControls();
            }
        }

        protected override void DataToControls()
        {
            base.DataToControls();
            var driver = _versionIdentifier as HardwareItemDescriptionControlDriver;
            if (driver != null)
            {
                controlDriverManufacturerControl.ManufacturerData = driver.Manufacturer;
                controlDriverDependenciesControl.Dependencies = driver.Dependencies;
                controlDriverPlatformControl.Platform = driver.Platform;
                controlDriverSelectionControl.DriverSelect = driver.Type;
            }
        }

        protected override void ControlsToData()
        {
            if (_versionIdentifier == null)
                _versionIdentifier = new HardwareItemDescriptionControlDriver();
            base.ControlsToData();
            var driver = _versionIdentifier as HardwareItemDescriptionControlDriver;
            if (driver != null)
            {
                driver.Manufacturer = controlDriverManufacturerControl.ManufacturerData;
                driver.Dependencies = controlDriverDependenciesControl.Dependencies;
                driver.Platform = controlDriverPlatformControl.Platform;
                driver.Type = controlDriverSelectionControl.DriverSelect;
            }
        }
    }
}