/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
//using ATMLModelLibrary.model.common;
using System.ComponentModel;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.error
{
    public partial class ErrorControl : ATMLControl
    {
        private HardwareItemDescriptionError _hardwareItemDescriptionError;

        public ErrorControl()
        {
            InitializeComponent();
            edtDescriptionValidate.ErrorMessage = "Description is required";
            edtIDValidate.ErrorMessage = "ID is required";
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public HardwareItemDescriptionError HardwareItemDescriptionError
        {
            get
            {
                ControlsToData();
                return _hardwareItemDescriptionError;
            }
            set
            {
                _hardwareItemDescriptionError = value;
                DataToControls();
            }
        }

        private void DataToControls()
        {
            if (_hardwareItemDescriptionError != null)
            {
                edtDescription.Value = _hardwareItemDescriptionError.Description;
                edtID.Value = _hardwareItemDescriptionError.ID;
                edtSource.Value = _hardwareItemDescriptionError.source;
                edtType.Value = _hardwareItemDescriptionError.type;
            }
        }

        private void ControlsToData()
        {
            if (_hardwareItemDescriptionError == null)
                _hardwareItemDescriptionError = new HardwareItemDescriptionError();
            _hardwareItemDescriptionError.Description = edtDescription.GetValue<string>();
            _hardwareItemDescriptionError.ID = edtID.GetValue<string>();
            _hardwareItemDescriptionError.source = edtSource.GetValue<string>();
            _hardwareItemDescriptionError.type = edtType.GetValue<string>();
        }
    }
}