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

namespace ATMLCommonLibrary.controls.control.tool
{
    public partial class ControlToolControl : VersionIdentifierControl
    {
        //private HardwareItemDescriptionControlTool _hardwareItemDescriptionControlTool;

        public ControlToolControl()
        {
            InitializeComponent();
            Validating += ControlToolControl_Validating;
        }

        public HardwareItemDescriptionControlTool HardwareItemDescriptionControlTool
        {
            get
            {
                ControlsToData();
                return _versionIdentifier as HardwareItemDescriptionControlTool;
            }
            set
            {
                _versionIdentifier = value;
                DataToControls();
            }
        }

        private void ControlToolControl_Validating(object sender, CancelEventArgs e)
        {
            var tool = _versionIdentifier as HardwareItemDescriptionControlTool;
            string saved = tool == null ? null : tool.Serialize();
            ControlsToData();
            ValidateToSchema(tool);
            _versionIdentifier = string.IsNullOrEmpty(saved)
                ? null
                : HardwareItemDescriptionControlTool.Deserialize(saved);
        }

        private new void DataToControls()
        {
            base.DataToControls();
            var hardwareItemDescriptionControlTool = _versionIdentifier as HardwareItemDescriptionControlTool;
            if (hardwareItemDescriptionControlTool != null)
            {
                controlToolDependancyListControl1.VersionIdentifiers = hardwareItemDescriptionControlTool.Dependencies;
                edtFilePath.Value = hardwareItemDescriptionControlTool.filePath;
            }
        }

        private new void ControlsToData()
        {
            if (_versionIdentifier == null)
                _versionIdentifier = new HardwareItemDescriptionControlTool();
            base.ControlsToData();
            var hardwareItemDescriptionControlTool = _versionIdentifier as HardwareItemDescriptionControlTool;
            if (hardwareItemDescriptionControlTool != null)
            {
                hardwareItemDescriptionControlTool.Dependencies = controlToolDependancyListControl1.VersionIdentifiers;
                hardwareItemDescriptionControlTool.filePath = edtFilePath.GetValue<string>();
            }
        }
    }
}