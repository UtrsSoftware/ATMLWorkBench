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
using ATMLCommonLibrary.controls;
using ATMLDataAccessLibrary.model;
using ATMLModelLibrary.model.common;
using ATMLUtilitiesLibrary;

namespace ATML1671Reader.controls
{
    public partial class TpsSoftwareReferenceControl : ATMLControl
    {
        private ConfigurationSoftwareReference _configurationSoftwareReference;

        public TpsSoftwareReferenceControl()
        {
            InitializeComponent();
            documentControl.ValidationEnabled = false;
            itemDescriptionReferenceControl.DocumentType = dbDocument.DocumentType.SUP_SOFTWARE;
            foreach (TabPage page in tabControl1.TabPages)
                page.BackColor = ATMLContext.COLOR_PANEL;
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ConfigurationSoftwareReference ConfigurationSoftwareReference
        {
            set
            {
                 _configurationSoftwareReference = value;
                DataToControls();
            }
            get
            {
                ControlsToData();
                return _configurationSoftwareReference;
            }
        }

        public bool IsDirty()
        {
            return !_configurationSoftwareReference.Serialize().Equals( UndoBuffer );
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //panel1.Visible = tabControl1.SelectedIndex == 0;
            //panel2.Visible = tabControl1.SelectedIndex == 1;
        }

        protected virtual void DataToControls()
        {
            if (_configurationSoftwareReference != null)
            {
                itemDescriptionReferenceControl.ItemDescriptionReference = _configurationSoftwareReference;
                documentControl.Document = _configurationSoftwareReference.Documentation;
                checkSumControl.Checksum = _configurationSoftwareReference.Checksum;
                edtItemRef.Value = _configurationSoftwareReference.ItemRef;
                edtType.Value = _configurationSoftwareReference.type;
            }
        }

        protected virtual void ControlsToData()
        {
            
            if (_configurationSoftwareReference == null)
                _configurationSoftwareReference = new ConfigurationSoftwareReference();
            if (_configurationSoftwareReference != null)
            {
                ItemDescriptionReference itemRef = itemDescriptionReferenceControl.ItemDescriptionReference;
                _configurationSoftwareReference.Item = itemRef.Item;
                _configurationSoftwareReference.Checksum = checkSumControl.Checksum;
                _configurationSoftwareReference.ItemRef = edtItemRef.GetValue<string>();
                _configurationSoftwareReference.type = edtType.GetValue<string>();
                _configurationSoftwareReference.Documentation = documentControl.Document;
                if (_configurationSoftwareReference.Documentation != null 
                        && string.IsNullOrEmpty( _configurationSoftwareReference.Documentation.uuid ) 
                        && string.IsNullOrEmpty( _configurationSoftwareReference.Documentation.name )
                        && string.IsNullOrEmpty( _configurationSoftwareReference.Documentation.Item ) 
                    )
                {
                    _configurationSoftwareReference.Documentation = null;
                }
            }
             
        }
    }
}