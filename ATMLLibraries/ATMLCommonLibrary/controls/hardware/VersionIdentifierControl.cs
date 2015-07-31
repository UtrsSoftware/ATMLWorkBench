/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
using System;
using System.ComponentModel;
using System.Reflection;
using ATMLCommonLibrary.utils;
using ATMLModelLibrary.model.equipment;
using ATMLUtilitiesLibrary;
using DataGridViewNumericUpDownElements;

namespace ATMLCommonLibrary.controls.hardware
{
    public partial class VersionIdentifierControl : ATMLControl
    {
        protected VersionIdentifier _versionIdentifier;

        public VersionIdentifierControl()
        {
            InitializeComponent();
            cmbVersionIdentifierQualifier.DataSource = Enum.GetNames(typeof (VersionIdentifierQualifier));
            Validating += new CancelEventHandler(VersionIdentifierControl_Validating);
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public VersionIdentifier VersionIdentifier
        {
            get
            {
                ControlsToData();
                return _versionIdentifier;
            }
            set
            {
                _versionIdentifier = value;
                DataToControls();
            }
        }


        virtual protected void DataToControls()
        {
            if (_versionIdentifier == null)
                return;
            edtVersion.Value = _versionIdentifier.version;
            edtVersionName.Value = _versionIdentifier.name;
            cmbVersionIdentifierQualifier.SelectedItem = Enum.GetName(typeof (VersionIdentifierQualifier),
                _versionIdentifier.qualifier);
        }

        virtual protected void ControlsToData()
        {
            if (_versionIdentifier == null)
                _versionIdentifier = new VersionIdentifier();
            _versionIdentifier.version = edtVersion.GetValue<string>();
            _versionIdentifier.name = edtVersionName.GetValue<string>();
            _versionIdentifier.qualifier =
                (VersionIdentifierQualifier)
                    Enum.Parse(typeof (VersionIdentifierQualifier), (string) cmbVersionIdentifierQualifier.SelectedItem);
        }

        void VersionIdentifierControl_Validating(object sender, CancelEventArgs e)
        {
            string saved = null;
            if( _versionIdentifier != null )
                saved = XmlUtils.SerializeObject( _versionIdentifier );
            ControlsToData();
            ValidateToSchema(_versionIdentifier);
            if (saved == null)
                _versionIdentifier = null;
            else
                _versionIdentifier = (VersionIdentifier)XmlUtils.DeserializeObject(_versionIdentifier, saved);

        }

        private void lblVersionQualifier_Click(object sender, EventArgs e)
        {

        }

    }
}