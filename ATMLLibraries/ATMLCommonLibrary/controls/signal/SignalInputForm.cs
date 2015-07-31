/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using ATMLModelLibrary.model.signal.basic;
using ATMLUtilitiesLibrary;

namespace ATMLCommonLibrary.forms
{
    public partial class SignalInputForm : Form
    {
        private SignalIN signalInput;
        private List<SignalIN> signalInputList;

        public SignalInputForm() : this(new List<SignalIN>())
        {
        }

        public SignalInputForm(List<SignalIN> signalInputList)
        {
            this.signalInputList = signalInputList;
            signalInput = new SignalIN();
            InitializeComponent();
            BackColor = ATMLContext.COLOR_FORM;
            panel1.BackColor = ATMLContext.COLOR_PANEL;
            Validating += SignalInputForm_Validating;
            signalInputControl.SignalInput = signalInput;
        }

        public List<SignalIN> SignalInputList
        {
            get { return signalInputList; }
            set { signalInputList = value; }
        }

        public SignalIN SignalInput
        {
            get
            {
                ControlsToData();
                return signalInput;
            }
            set
            {
                signalInput = value;
                DataToControls();
            }
        }

        private void SignalInputForm_Validating(object sender, CancelEventArgs e)
        {
            if (!signalInputControl.Validate())
            {
                e.Cancel = true;
            }

            foreach (SignalIN input in signalInputList)
            {
                if (input != signalInput && signalInput.InSpecified && input.InSpecified)
                {
                    errorProvider.SetError(signalInputControl,
                        "A Gate has already been specified for input " + input.name +
                        "., Only 1 gate may be set for the list of signal inputs");
                }
            }
        }

        private void DataToControls()
        {
            signalInputControl.SignalInput = signalInput;
        }

        private void ControlsToData()
        {
            signalInput = signalInputControl.SignalInput;
        }

        private void SignalInputForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult.OK == DialogResult)
            {
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
        }
    }
}