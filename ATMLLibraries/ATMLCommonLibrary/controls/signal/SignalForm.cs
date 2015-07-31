/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.ComponentModel;
using ATMLModelLibrary.model.signal.basic;

namespace ATMLCommonLibrary.forms
{
    public partial class SignalForm : ATMLForm
    {
        private Signal _signal;
        private SignalFunctionType _signalFunctionType;

        public SignalForm()
        {
            InitializeComponent();
            Signal = new Signal();
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SignalFunctionType SignalFunctionType
        {
            get { return _signalFunctionType; }
            set
            {
                _signalFunctionType = value;
                signalControl.SignalFunctionType = _signalFunctionType;
            }
        }


        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Signal Signal
        {
            get
            {
                ControlsToData();
                return _signal;
            }
            set
            {
                _signal = value;
                DataToControls();
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void SignalForm_Load(object sender, EventArgs e)
        {
        }

        private void signalControl1_Load(object sender, EventArgs e)
        {
        }

        private void DataToControls()
        {
            signalControl.Signal = _signal;
        }

        private void ControlsToData()
        {
            _signal = signalControl.Signal;
        }
    }
}