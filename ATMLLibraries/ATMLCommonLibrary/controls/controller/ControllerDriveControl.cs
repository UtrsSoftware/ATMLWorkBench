/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System.ComponentModel;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.controller
{
    public partial class ControllerDriveControl : ATMLCommonLibrary.controls.ATMLControl
    {
        private ControllerDrive _controllerDrive;

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ControllerDrive ControllerDrive
        {
            get { ControlsToData(); return _controllerDrive; }
            set { _controllerDrive = value; DataTocontrols(); }
        }
        public ControllerDriveControl()
        {
            InitializeComponent();
        }
        private void DataTocontrols()
        {
            if (_controllerDrive != null)
            {
                DatumSize.DoubleValue = _controllerDrive.Size;
                edtName.Value = _controllerDrive.name;
                BDcheck.Checked = _controllerDrive.bootDrive;
            }
        }
        private void ControlsToData()
        {
            if (_controllerDrive == null)
                _controllerDrive = new ControllerDrive();
            _controllerDrive.bootDrive = BDcheck.Checked;
            _controllerDrive.name = edtName.GetValue<string>();
            _controllerDrive.Size = DatumSize.DoubleValue;
        }
    }
}
