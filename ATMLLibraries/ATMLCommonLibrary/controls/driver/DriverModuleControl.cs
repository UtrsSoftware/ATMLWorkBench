/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.driver
{
    public partial class DriverModuleControl : ATMLControl
    {
        private DriverModule _driverModule;

        public DriverModuleControl()
        {
            InitializeComponent();
        }

        public DriverItemChoiceType DriverItemChoiceType
        {
            set { gbTypeName.Text = Enum.GetName( typeof (DriverItemChoiceType), value ); }
            get
            {
                DriverItemChoiceType type;
                Enum.TryParse( gbTypeName.Text, out type );
                return type; 
            }
        }

        public DriverModule DriverModule
        {
            get
            {
                ControlsToData();
                return _driverModule;
            }
            set
            {
                _driverModule = value;
                DataToControls();
            }
        }


        protected void DataToControls()
        {
            if (_driverModule != null)
            {
                edtFileName.Value = _driverModule.fileName;
                edtInstallationDirectory.Value = _driverModule.installationDirectory;
            }
        }

        protected void ControlsToData()
        {
            if (_driverModule == null)
                _driverModule = new DriverModule();
            _driverModule.fileName = edtFileName.GetValue<string>();
            _driverModule.installationDirectory = edtInstallationDirectory.GetValue<string>();
        }
    }
}