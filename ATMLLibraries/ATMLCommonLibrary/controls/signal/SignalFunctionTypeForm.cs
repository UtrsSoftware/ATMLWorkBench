/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
using System;
using System.Collections.Generic;

namespace ATMLCommonLibrary.forms
{
    public partial class SignalFunctionTypeForm : ATMLForm
    {

        public SignalFunctionTypeForm()
        {
            InitializeComponent();
        }

        public List<string> AvailableSignalParts
        {
            get { return signalFunctionTypeControl.AvailableSignalParts; }
            set { signalFunctionTypeControl.AvailableSignalParts = value; }
        }


        public object SignalFunctionType
        {
            get
            {
                return signalFunctionTypeControl.SignalFunctionType;
            }
            set
            {
                signalFunctionTypeControl.SignalFunctionType = value;
                if (value != null)
                    Text = @"Signal Function Type - " + value.GetType().Name;
            }
        }

    }
}