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
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ATMLModelLibrary.model.common;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.forms
{

    public partial class IdentificationNumberForm : ATMLForm
    {
        private IdentificationNumber identificationNumber;
        public IdentificationNumber IdentificationNumber
        {
            get { ControlsToData();  return identificationNumber; }
            set { identificationNumber = value; DataToControls(); }
        }

        public IdentificationNumberForm()
        {
            InitializeComponent();
            cmbType.Items.Clear();
            cmbType.DataSource = Enum.GetValues( typeof(IdentificationNumberType) );
        }


        private void DataToControls()
        {
            edtNumber.Value = identificationNumber.number;
            //edtQualifier.Value = identificationNumber.qualifier;
            cmbType.SelectedItem = identificationNumber.type;
            if (identificationNumber is ManufacturerIdentificationNumber)
            {
                edtManufacturerName.Value = ((ManufacturerIdentificationNumber)identificationNumber).manufacturerName;
                rbManufacturerId.Checked = true;
                rbUserId.Checked = false;
            }
            else
            {
                rbManufacturerId.Checked = false;
                rbUserId.Checked = true;
                edtQualifier.Value = ((UserDefinedIdentificationNumber)identificationNumber).qualifier;
            }
            SetControlStates();

        }

        private void ControlsToData()
        {
            identificationNumber.number = edtNumber.GetValue<string>();
            //identificationNumber.qualifier = edtQualifier.GetValue<string>();
            identificationNumber.type = (IdentificationNumberType)cmbType.SelectedItem;
            if (identificationNumber is ManufacturerIdentificationNumber)
                ((ManufacturerIdentificationNumber)identificationNumber).manufacturerName = edtManufacturerName.GetValue<string>();
            if (identificationNumber is UserDefinedIdentificationNumber)
                ((UserDefinedIdentificationNumber)identificationNumber).qualifier = edtQualifier.GetValue<string>();
        }

        private void IdentificationNumberForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if( System.Windows.Forms.DialogResult.OK == this.DialogResult )
            {
                e.Cancel = !ValidateChildren();
            }
        }

        private Boolean isValid()
        {
            return true;
        }

        private void HelpCursorOn(object sender, EventArgs e)
        {
            Cursor = Cursors.Help;
        }

        private void HelpCursorOff(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void rbManufacturerId_CheckedChanged(object sender, EventArgs e)
        {
            if (!(identificationNumber is ManufacturerIdentificationNumber))
                identificationNumber = new ManufacturerIdentificationNumber();
            SetControlStates();
        }

        private void rbUserId_CheckedChanged(object sender, EventArgs e)
        {
            if (!(identificationNumber is UserDefinedIdentificationNumber))
                identificationNumber = new UserDefinedIdentificationNumber();
            SetControlStates();
        }

        private void SetControlStates()
        {
            if (identificationNumber != null)
            {
                edtQualifier.Enabled = rbUserId.Checked;
                edtManufacturerName.Enabled = rbManufacturerId.Checked;
            }
            lblMfrName.RequiredField = rbManufacturerId.Checked;
            lblQualifier.RequiredField = rbUserId.Checked;
            lblMfrName.Invalidate();
            lblQualifier.Invalidate();
            requiredMfrNameValidator.IsEnabled = rbManufacturerId.Checked;
            requiredQualifierValidator.IsEnabled = rbUserId.Checked;
            Update();
        }

        private void edtQualifier_Validating(object sender, CancelEventArgs e)
        {
            if (rbUserId.Checked && String.IsNullOrEmpty(edtQualifier.Text))
            {
            }
        }

        private void edtManufacturerName_Validating(object sender, CancelEventArgs e)
        {

        }


    }
}
