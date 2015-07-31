/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
using System;
using System.ComponentModel;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.bus
{
    public partial class VXITriggerLinesControl : ATMLControl
    {
        private VXITriggerLines _vxiTriggerLines;

        public VXITriggerLinesControl()
        {
            InitializeComponent();
            InitControls();
        }

        public String Title
        {
            set { gbFrame.Text = value; }
            get { return gbFrame.Text; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public VXITriggerLines VXITriggerLines
        {
            get
            {
                ControlsToData();
                return _vxiTriggerLines;
            }
            set
            {
                _vxiTriggerLines = value;
                DataToControls();
            }
        }

        private void chkSource_CheckedChanged(object sender, EventArgs e)
        {
            SetControlStates();
        }

        private void chkSense_CheckedChanged(object sender, EventArgs e)
        {
            SetControlStates();
        }

        private void SetControlStates()
        {
            edtSource.Enabled = chkSource.Checked;
            edtSense.Enabled = chkSense.Checked;
        }


        private void DataToControls()
        {
            if (_vxiTriggerLines == null)
                return;
            chkSource.Checked = _vxiTriggerLines.sourceSpecified;
            chkSense.Checked = _vxiTriggerLines.senseSpecified;
            edtSense.Value = _vxiTriggerLines.sense;
            edtSource.Value = _vxiTriggerLines.source;
        }

        private void ControlsToData()
        {
            if (_vxiTriggerLines == null)
                _vxiTriggerLines = new VXITriggerLines();
            _vxiTriggerLines.sourceSpecified = chkSource.Checked;
            _vxiTriggerLines.senseSpecified = chkSense.Checked;
            _vxiTriggerLines.sense = chkSense.Checked ? (int) edtSense.Value : 0;
            _vxiTriggerLines.source = chkSource.Checked ? (int) edtSource.Value : 0;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}