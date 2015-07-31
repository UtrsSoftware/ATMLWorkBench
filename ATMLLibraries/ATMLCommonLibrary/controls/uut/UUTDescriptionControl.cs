/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.ComponentModel;
using System.Windows.Forms;
using ATMLModelLibrary.model.common;
using ATMLModelLibrary.model.uut;

namespace ATMLCommonLibrary.controls
{
    public partial class UUTDescriptionControl : ATMLControl
    {
        private UUTDescription _uut;


        public UUTDescriptionControl()
        {
            InitializeComponent();
            rbHardware.Checked = true;
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public UUTDescription UUT
        {
            get
            {
                ControlsToData();
                return _uut;
            }
            set
            {
                _uut = value;
                DataToControls();
            }
        }

        private void ControlsToData()
        {
            if (_uut == null)
                _uut = new UUTDescription();

            _uut.name = edtName.Text;
            _uut.version = edtVersion.GetValue<string>();
            _uut.uuid = edtUUID.GetValue<string>();
            _uut.Classified = securityClassificationControl.Classified;
            _uut.SecurityClassification = securityClassificationControl.SecurityClassification;

            if (rbHardware.Checked)
                _uut.Item = hardwareUUTControl.HardwareUUT;
            else if (rbSoftware.Checked)
                _uut.Item = softwareUUTControl.SoftwareUUT;
        }

        public void DataToControls()
        {
            if (_uut != null)
            {
                edtName.Text = _uut.name;
                edtVersion.Value = _uut.version;
                edtUUID.Value = _uut.uuid;
                securityClassificationControl.Classified = _uut.Classified;
                securityClassificationControl.SecurityClassification = _uut.SecurityClassification;

                //--------------------------------------------------------------//
                //--- Only Enable the Add UUID Button if the uuid is missing ---//
                //--------------------------------------------------------------//
                btnAddUUID.Enabled = String.IsNullOrEmpty(_uut.uuid);
                if (_uut.Item is HardwareUUT)
                {
                    var huut = _uut.Item as HardwareUUT;
                    hardwareUUTControl.HardwareUUT = huut;
                    rbHardware.Checked = true;
                }
                else if (_uut.Item is SoftwareUUT)
                {
                    var suut = _uut.Item as SoftwareUUT;
                    softwareUUTControl.SoftwareUUT = suut;
                    rbSoftware.Checked = true;
                }
                setControlStates();
            }
        }

        private void btnAddUUID_Click(object sender, EventArgs e)
        {
            Guid iid = Guid.NewGuid();
            edtUUID.Text = iid.ToString();
        }

        public void dataToControls(UUTDescription uutDescription)
        {
            ItemDescription itemDesc = uutDescription.Item;
        }

        private void rbHardware_CheckedChanged(object sender, EventArgs e)
        {
            setControlStates();
        }

        private void setControlStates()
        {
            hardwareUUTControl.Visible = rbHardware.Checked;
            softwareUUTControl.Visible = rbSoftware.Checked;
            hardwareUUTControl.Enabled = rbHardware.Checked;
            softwareUUTControl.Enabled = rbSoftware.Checked;
        }

        private void rbSoftware_CheckedChanged(object sender, EventArgs e)
        {
            setControlStates();
        }

        public override bool ValidateChildren()
        {
            return base.ValidateChildren();
        }

        public override bool ValidateChildren(ValidationConstraints validationConstraints)
        {
            setControlStates();
            bool isValid = base.ValidateChildren(validationConstraints);
            return isValid;
        }
    }
}