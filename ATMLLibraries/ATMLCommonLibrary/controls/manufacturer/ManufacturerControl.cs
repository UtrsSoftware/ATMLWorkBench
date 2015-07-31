/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ATMLCommonLibrary.controls.validators;
using ATMLModelLibrary.model.common;

namespace ATMLCommonLibrary.controls.manufacturer
{
    public partial class ManufacturerControl : ATMLControl, IValidatable
    {
        private readonly Color _clrReadOnly = Color.Honeydew;
        private readonly Color _clrWrite = Color.White;
        private ManufacturerData _manufacturerData;

        public ManufacturerControl()
        {
            InitializeComponent();
            SetControlStates();
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ManufacturerData ManufacturerData
        {
            get
            {
                ControlsToData();
                return _manufacturerData;
            }
            set
            {
                _manufacturerData = value;
                DataToControls();
            }
        }

        public bool ValidationEndabled
        {
            set 
            { 
                requiredNameValidator.IsEnabled = value;
                mailingAddressControl.ValidationEndabled = value;
            }
            get
            {
                return requiredNameValidator.IsEnabled && mailingAddressControl.ValidationEndabled; 
            }
        }

        public void Clear()
        {
            edtManufacturerName.Value = null;
            edtManufacturerFaxNumber.Value = null;
            edtManufacturerCageCode.Value = null;
            edtManufacturerURL.Value = null;
            mailingAddressControl.Clear();
        }

        private void DataToControls()
        {
            if (_manufacturerData != null)
            {
                edtManufacturerName.Value = _manufacturerData.name;
                edtManufacturerFaxNumber.Value = _manufacturerData.FaxNumber;
                edtManufacturerCageCode.Value = _manufacturerData.cageCode;
                edtManufacturerURL.Value = _manufacturerData.URL;
                //----------------------------------------------------//
                //--- We need to check all of the member variables ---//
                //----------------------------------------------------//
                chkHasAddress.Checked = (_manufacturerData.MailingAddress != null
                                         && (_manufacturerData.MailingAddress.Address1 != null
                                             || _manufacturerData.MailingAddress.Address2 != null
                                             || _manufacturerData.MailingAddress.City != null
                                             || _manufacturerData.MailingAddress.State != null
                                             || _manufacturerData.MailingAddress.Country != null
                                             || _manufacturerData.MailingAddress.PostalCode != null));
                mailingAddressControl.MailingAddress = _manufacturerData.MailingAddress;
                manufacturerContactListControl.Contacts = _manufacturerData.Contacts;
                SetControlStates();
            }
        }

        private void ControlsToData()
        {
            if (HasAnyManufacturerData)
            {
                if (_manufacturerData == null)
                    _manufacturerData = new ManufacturerData();
                _manufacturerData.name = edtManufacturerName.GetValue<string>();
                _manufacturerData.FaxNumber = edtManufacturerFaxNumber.GetValue<string>();
                _manufacturerData.cageCode = edtManufacturerCageCode.GetValue<string>();
                _manufacturerData.URL = edtManufacturerURL.GetValue<string>();
                _manufacturerData.MailingAddress = chkHasAddress.Checked ? mailingAddressControl.MailingAddress : null;
                _manufacturerData.Contacts = manufacturerContactListControl.Contacts;
            }
            else
            {
                _manufacturerData = null;
            }
        }

        private void chkHasAddress_CheckedChanged(object sender, EventArgs e)
        {
            SetControlStates();
        }

        private void SetControlStates()
        {
            mailingAddressControl.Enabled = chkHasAddress.Checked;
            mailingAddressControl.AutoValidate = ( chkHasAddress.Checked
                ? AutoValidate.EnableAllowFocusChange
                : AutoValidate.Disable );
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            edtManufacturerCageCode.BackColor = Enabled ? _clrWrite : _clrReadOnly;
            edtManufacturerFaxNumber.BackColor = Enabled ? _clrWrite : _clrReadOnly;
            edtManufacturerName.BackColor = Enabled ? _clrWrite : _clrReadOnly;
            edtManufacturerURL.BackColor = Enabled ? _clrWrite : _clrReadOnly;
            mailingAddressControl.Enabled = chkHasAddress.Checked;
        }

        private void chkHasAddress_CheckedChanged_1(object sender, EventArgs e)
        {
            SetControlStates();
        }


        public bool HasAnyManufacturerData
        {
            get
            {
                string name = edtManufacturerName.GetValue<string>();
                string FaxNumber = edtManufacturerFaxNumber.GetValue<string>();
                string cageCode = edtManufacturerCageCode.GetValue<string>();
                string URL = edtManufacturerURL.GetValue<string>();
                ICollection Contacts = manufacturerContactListControl.Contacts;

                return !string.IsNullOrEmpty( name )
                       || !string.IsNullOrEmpty( FaxNumber )
                       || !string.IsNullOrEmpty( cageCode )
                       || !string.IsNullOrEmpty( URL )
                       || chkHasAddress.Checked
                       || Contacts != null;
            }
        }


        public bool Ok2Validate()
        {
            return HasAnyManufacturerData;
        }
    }
}