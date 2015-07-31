/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
using System.ComponentModel;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.control
{
    public partial class ControlControl : ATMLControl
    {
        private HardwareItemDescriptionControl _hardwareItemDescriptionControl;

        public ControlControl()
        {
            InitializeComponent();
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public HardwareItemDescriptionControl HardwareHardwareItemDescriptionControl
        {
            get
            {
                ControlsToData();
                return _hardwareItemDescriptionControl;
            }
            set
            {
                _hardwareItemDescriptionControl = value;
                DataToControls();
            }
        }

        private void DataToControls()
        {
            if (_hardwareItemDescriptionControl != null)
            {
                firmwareListControl.Firmwares = _hardwareItemDescriptionControl.Firmwares;
                driverListControl.HardwareItemDescriptionControlDrivers = _hardwareItemDescriptionControl.Drivers;
                controlLanguageListControl.ControlLanguages = _hardwareItemDescriptionControl.ControlLanguages;
                toolsListControl.HardwareItemDescriptionControlTool = _hardwareItemDescriptionControl.Tools;
            }
        }

        private void ControlsToData()
        {
            if (HasData())
            {
                if (_hardwareItemDescriptionControl == null)
                    _hardwareItemDescriptionControl = new HardwareItemDescriptionControl();
                _hardwareItemDescriptionControl.Firmwares = firmwareListControl.Firmwares;
                _hardwareItemDescriptionControl.ControlLanguages = controlLanguageListControl.ControlLanguages;
                _hardwareItemDescriptionControl.Drivers = driverListControl.HardwareItemDescriptionControlDrivers;
                _hardwareItemDescriptionControl.Tools = toolsListControl.HardwareItemDescriptionControlTool;
            }
            else
            {
                _hardwareItemDescriptionControl = null;
            }
        }

        private bool HasData()
        {
            int count = 0;
            if (firmwareListControl.Firmwares != null)
                count += firmwareListControl.Firmwares.Count;
            if (controlLanguageListControl.ControlLanguages != null)
                count += controlLanguageListControl.ControlLanguages.Count;
            if (driverListControl.HardwareItemDescriptionControlDrivers != null)
                count += driverListControl.HardwareItemDescriptionControlDrivers.Count;
            if (toolsListControl.HardwareItemDescriptionControlTool != null)
                count += toolsListControl.HardwareItemDescriptionControlTool.Count;
            return count > 0;
        }
    }
}