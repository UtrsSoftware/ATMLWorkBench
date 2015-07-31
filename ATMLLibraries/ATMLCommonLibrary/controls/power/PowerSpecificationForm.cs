/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using ATMLCommonLibrary.forms;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.power
{
    public partial class PowerSpecificationForm : ATMLForm
    {
        public PowerSpecificationForm()
        {
            InitializeComponent();
        }

        public object PowerRequirement
        {
            set
            {
                if (value is PowerSpecificationsAC)
                {
                    acPowerSpecificationControl.ACPower = value as PowerSpecificationsAC;
                    rbACPower.Checked = true;
                }
                if (value is PowerSpecificationsDC)
                {
                    dcPowerSpecificationControl.DCPower = value as PowerSpecificationsDC;
                    rbDCPower.Checked = true;
                }
            }
            get
            {
                return rbACPower.Checked
                    ? acPowerSpecificationControl.ACPower
                    : (object) dcPowerSpecificationControl.DCPower;
            }
        }

        private void rbACPower_CheckedChanged(object sender, EventArgs e)
        {
            dcPowerSpecificationControl.Enabled = dcPowerSpecificationControl.Visible = rbDCPower.Checked;
            acPowerSpecificationControl.Enabled = acPowerSpecificationControl.Visible = rbACPower.Checked;
        }

        private void rbDCPower_CheckedChanged(object sender, EventArgs e)
        {
            dcPowerSpecificationControl.Enabled = dcPowerSpecificationControl.Visible = rbDCPower.Checked;
            acPowerSpecificationControl.Enabled = acPowerSpecificationControl.Visible = rbACPower.Checked;
        }

       
    }
}