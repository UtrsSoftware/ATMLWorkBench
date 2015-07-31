/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using ATMLCommonLibrary.forms;
using ATMLModelLibrary.model.uut;

namespace ATMLCommonLibrary.controls.uut
{
    public partial class UUTStatusCodeForm : ATMLForm
    {
        private SoftwareUUTStatusCode _statusCode;

        public UUTStatusCodeForm()
        {
            InitializeComponent();
        }

        public SoftwareUUTStatusCode SoftwareUUTStatusCode
        {
            get
            {
                ControlsToData();
                return _statusCode;
            }
            set
            {
                _statusCode = value;
                DataToControls();
            }
        }

        private void ControlsToData()
        {
            if (_statusCode == null)
                _statusCode = new SoftwareUUTStatusCode();
            _statusCode.CodeMeaning = edtStatusMeaning.GetValue<string>();
            _statusCode.CodeString = edtStatusCode.GetValue<string>();
            _statusCode.codeID = edtStatusId.GetValue<string>();
        }

        private void DataToControls()
        {
            if (_statusCode != null)
            {
                edtStatusMeaning.Value = _statusCode.CodeMeaning;
                edtStatusCode.Value = _statusCode.CodeString;
                edtStatusId.Value = _statusCode.codeID;
            }
        }
    }
}