/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using ATMLCommonLibrary.forms;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.control.tool
{
    public partial class ControlToolDependancyForm : ATMLForm
    {
        private VersionIdentifier _toolDependancy;

        public ControlToolDependancyForm()
        {
            InitializeComponent();
            rbDriver.Checked = true;
        }

        public VersionIdentifier ToolDependancy
        {
            get
            {
                ControlsToData();
                return _toolDependancy;
            }
            set
            {
                _toolDependancy = value;
                DataToControls();
            }
        }


        private void DataToControls()
        {
            if (_toolDependancy != null)
            {
                rbDriver.Checked = _toolDependancy is HardwareItemDescriptionControlToolDriver;
                rbSoftware.Checked = _toolDependancy is HardwareItemDescriptionControlToolSoftware;
                controlToolDependancyControl1.VersionIdentifier = _toolDependancy;
            }
        }

        private void ControlsToData()
        {
            if (_toolDependancy == null)
            {
                if (rbDriver.Checked)
                    _toolDependancy = new HardwareItemDescriptionControlToolDriver();
                else if (rbSoftware.Checked)
                    _toolDependancy = new HardwareItemDescriptionControlToolSoftware();
            }
            else
            {
                if( _toolDependancy is HardwareItemDescriptionControlToolDriver && rbSoftware.Checked )
                    _toolDependancy = new HardwareItemDescriptionControlToolSoftware();
                else if ( _toolDependancy is HardwareItemDescriptionControlToolSoftware && rbDriver.Checked )
                    _toolDependancy = new HardwareItemDescriptionControlToolDriver();
            }

            if (_toolDependancy != null)
            {
                _toolDependancy.name = controlToolDependancyControl1.VersionIdentifier.name;
                _toolDependancy.qualifier = controlToolDependancyControl1.VersionIdentifier.qualifier;
                _toolDependancy.version = controlToolDependancyControl1.VersionIdentifier.version;
            }
        }
    }
}