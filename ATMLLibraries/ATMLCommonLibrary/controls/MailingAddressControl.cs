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
using System.Windows.Forms;
using ATMLCommonLibrary.controls.validators;
using ATMLDataAccessLibrary.db.beans;
using ATMLDataAccessLibrary.model;
using ATMLManagerLibrary.managers;
using ATMLModelLibrary.model.common;

namespace ATMLCommonLibrary.controls
{
    public partial class MailingAddressControl : ATMLControl, IValidatable
    {
        private readonly Color _clrReadOnly = Color.Honeydew;
        private readonly Color _clrWrite = Color.White;
        private MailingAddress _mailingAddress;

        public MailingAddressControl()
        {
            InitializeComponent();

            cbMailingCountry.DisplayMember = LuCountryBean._COUNTRY_NAME;
            cbMailingCountry.ValueMember = LuCountryBean._COUNTRY_NAME;
            cbMailingState.DisplayMember = LuStateBean._STATE_NAME;
            cbMailingState.ValueMember = LuStateBean._STATE_CODE;
            if (!this.IsInDesignMode())
            {
                Cache countryCache = CacheManager.getCache( LuCountryBean._TABLE_NAME );
                countryCache.loadComboBox( cbMailingCountry );
            }
        }

        public bool ValidationEndabled
        {
            set
            {
                requiredAddress1Validator.IsEnabled = value;
                requiredCityValidator.IsEnabled = value;
                requiredPostalCodeValidator.IsEnabled = value;
            }
            get
            {
                return requiredAddress1Validator.IsEnabled && requiredCityValidator.IsEnabled &&
                       requiredPostalCodeValidator.IsEnabled;
            }
        }


        [Browsable( false ), DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
        public MailingAddress MailingAddress
        {
            get
            {
                ControlsToData();
                return _mailingAddress;
            }
            set
            {
                _mailingAddress = value;
                DataToControls();
            }
        }


        private void DataToControls()
        {
            if (_mailingAddress != null)
            {
                edtMailingAddress1.Value = _mailingAddress.Address1;
                edtMailingAddress2.Value = _mailingAddress.Address2;
                edtMailingCity.Value = _mailingAddress.City;
                edtMailingPostalCode.Value = _mailingAddress.PostalCode;
                cbMailingCountry.SelectedIndex = cbMailingCountry.FindStringExact( _mailingAddress.Country );
                foreach (var obj in cbMailingState.Items)
                {
                    LuStateBean state = obj as LuStateBean;
                    if (state != null && state.stateCode.Equals( _mailingAddress.State ))
                    {
                        cbMailingState.SelectedIndex = cbMailingState.FindStringExact( state.stateName );
                        break;
                    }
                }
            }
        }

        private void ControlsToData()
        {
            if (HasAnyAddressData)
            {
                if (_mailingAddress == null)
                    _mailingAddress = new MailingAddress();
                var country = cbMailingCountry.SelectedItem as LuCountryBean;
                var state = cbMailingState.SelectedItem as LuStateBean;
                _mailingAddress.Address1 = edtMailingAddress1.GetValue<string>();
                _mailingAddress.Address2 = edtMailingAddress2.GetValue<string>();
                _mailingAddress.City = edtMailingCity.GetValue<string>();
                _mailingAddress.PostalCode = edtMailingPostalCode.GetValue<string>();
                _mailingAddress.Country = ( country == null ? null : country.countryName );
                _mailingAddress.State = ( state == null ? null : state.stateCode );
            }
            else
            {
                _mailingAddress = null;
            }
        }


        public void Clear()
        {
            edtMailingAddress1.Value = null;
            edtMailingAddress2.Value = null;
            edtMailingCity.Value = null;
            edtMailingPostalCode.Value = null;
            cbMailingCountry.SelectedIndex = -1;
            cbMailingState.SelectedIndex = -1;
        }


        private void cbMailingCountry_SelectedIndexChanged( object sender, EventArgs e )
        {
            LoadStateComboBox();
        }

        private void LoadStateComboBox()
        {
            var country = (dbCountry) cbMailingCountry.SelectedItem;
            if (country != null)
            {
                cbMailingState.Items.Clear();
                cbMailingState.SelectedIndex = -1;
                foreach (dbState state in country.States)
                {
                    cbMailingState.Items.Add( state );
                }
            }
        }

        public bool HasAnyAddressData
        {
            get
            {
                return edtMailingAddress1.Text != null
                       || edtMailingAddress2.Text != null
                       || edtMailingCity.Text != null
                       || edtMailingPostalCode.Text != null
                       || cbMailingCountry.SelectedIndex != -1
                       || cbMailingState.SelectedIndex != -1;
            }
        }

        private void cbMailingCountry_BindingContextChanged( object sender, EventArgs e )
        {
        }

        private void cbMailingCountry_ValueMemberChanged( object sender, EventArgs e )
        {
        }

        private void cbMailingCountry_SelectedValueChanged( object sender, EventArgs e )
        {
            LoadStateComboBox();
        }

        private void cbMailingCountry_TextChanged( object sender, EventArgs e )
        {
        }

        private void cbMailingState_BindingContextChanged( object sender, EventArgs e )
        {
            foreach (dbState state in cbMailingState.Items)
            {
                if (state.stateCode.Equals( _mailingAddress.State ) || state.stateName.Equals( _mailingAddress.State ))
                {
                    cbMailingState.SelectedItem = state;
                    break;
                }
            }
        }

        private void panel2_Paint( object sender, PaintEventArgs e )
        {
        }

        protected override void OnEnabledChanged( EventArgs e )
        {
            base.OnEnabledChanged( e );
            edtMailingAddress1.BackColor = Enabled ? _clrWrite : _clrReadOnly;
            edtMailingAddress2.BackColor = Enabled ? _clrWrite : _clrReadOnly;
            edtMailingCity.BackColor = Enabled ? _clrWrite : _clrReadOnly;
            edtMailingPostalCode.BackColor = Enabled ? _clrWrite : _clrReadOnly;
            cbMailingCountry.BackColor = Enabled ? _clrWrite : _clrReadOnly;
            cbMailingState.BackColor = Enabled ? _clrWrite : _clrReadOnly;
        }


        public bool Ok2Validate()
        {
            return HasAnyAddressData;
        }
    }
}