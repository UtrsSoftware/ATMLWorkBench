/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System.ComponentModel;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.control.driver
{
    public partial class ControlDriverDependenciesControl : ATMLControl
    {
        private ControlDriverDependencies _dependencies;

        public ControlDriverDependenciesControl()
        {
            InitializeComponent();
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ControlDriverDependencies Dependencies
        {
            get
            {
                ControlsToData();
                return _dependencies;
            }
            set
            {
                _dependencies = value;
                DataToControls();
            }
        }

        private void DataToControls()
        {
            if (_dependencies != null)
            {
                versionIdentifierFirmwareListControl.VersionIdentifiers = _dependencies.Firmware;
            }
        }

        private void ControlsToData()
        {
            if (_dependencies == null)
                _dependencies = new ControlDriverDependencies();
            _dependencies.Firmware = versionIdentifierFirmwareListControl.VersionIdentifiers;
        }
    }
}