/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using ATMLCommonLibrary.forms;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.error
{
    public partial class ErrorForm : ATMLForm
    {
        public ErrorForm()
        {
            InitializeComponent();
        }

        public HardwareItemDescriptionError HardwareItemDescriptionError
        {
            get { return _errorControl.HardwareItemDescriptionError; }
            set { _errorControl.HardwareItemDescriptionError = value; }
        }
    }
}