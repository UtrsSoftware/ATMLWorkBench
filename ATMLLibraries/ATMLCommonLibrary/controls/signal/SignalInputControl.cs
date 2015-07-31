/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.ComponentModel;
using System.Drawing;
using ATMLCommonLibrary.forms;
using ATMLModelLibrary.model.signal.basic;

namespace ATMLCommonLibrary.controls.signal
{
    public partial class SignalInputControl : ATMLControl
    {
        private SignalIN _signalInput;

        public SignalInputControl()
        {
            InitializeComponent();
            cmbSignalInputType.Enabled = false;
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SignalIN SignalInput
        {
            get
            {
                ControlsToData();
                return _signalInput;
            }
            set
            {
                _signalInput = value;
                DataToControls();
            }
        }

        private void DataToControls()
        {
            if (_signalInput != null)
            {
                edtSignalInputName.Text = _signalInput.name;
                edtMaxChannels.Text = "" + _signalInput.maxChannels;
                if (_signalInput.InSpecified)
                    cmbSignalInputType.SelectedItem = _signalInput.In;
                else
                    cmbSignalInputType.SelectedIndex = -1;
            }
        }

        private void ControlsToData()
        {
            if (_signalInput != null)
            {
                _signalInput.name = edtSignalInputName.Text;
                _signalInput.maxChannels = Int32.Parse(edtMaxChannels.Text);
                _signalInput.InSpecified = cmbSignalInputType.SelectedItem != null;
                if (chkInputType.Checked)
                    _signalInput.In = (SignalININ) cmbSignalInputType.SelectedItem;
                else
                    _signalInput.In = SignalININ.In;
                setControlStates();
            }
        }

        private void chkInputGate_CheckedChanged(object sender, EventArgs e)
        {
            setControlStates();
        }

        private void setControlStates()
        {
            cmbSignalInputType.Enabled = chkInputType.Checked;
            if (!chkInputType.Checked)
            {
                errorProvider.SetError(cmbSignalInputType, "");
                cmbSignalInputType.BackColor = Color.White;
                cmbSignalInputType.SelectedIndex = -1;
            }
        }

        private void SignalInputControl_Validating(object sender, CancelEventArgs e)
        {
            if (ParentForm is SignalInputForm)
            {
                foreach (SignalIN input in ((SignalInputForm) ParentForm).SignalInputList)
                {
                    if (_signalInput != input
                        && input.In == SignalININ.Gate
                        && cmbSignalInputType.SelectedItem != null
                        && ((SignalININ) cmbSignalInputType.SelectedItem) == SignalININ.Gate)
                    {
                        errorProvider.SetError(cmbSignalInputType,
                            "A signal input has already been entered with an input type \"Gate\" assigned,\nonly 1 signal input may have an input type of \"Gate\" assigned");
                        cmbSignalInputType.BackColor = Color.LightPink;
                        e.Cancel = true;
                        break;
                    }
                }
            }
        }

        private void chkInputType_CheckedChanged(object sender, EventArgs e)
        {
            setControlStates();
        }
    }
}