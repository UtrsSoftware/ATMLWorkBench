/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.ComponentModel;
using ATMLDataAccessLibrary.model;
using ATMLModelLibrary.model.common;

namespace ATMLCommonLibrary.controls
{
    public delegate void DocumentReferenceSelectionDelegate( DocumentReference documentReference );

    public delegate void ItemDescriptionSelectionDelegate( ItemDescription itemDescription );

    public partial class ItemDescriptionReferenceControl : ATMLControl
    {
        private DocumentReference _documentReference;
        protected ItemDescriptionReference _itemDescriptionReference;
        private ItemDescription _itemDesxcription;

    /**
        * Sets/Gets the document type for the reference control. This will be used when pressing the 
        * "Find" button so that only documents of this type will be presented to the user.
        */
        public dbDocument.DocumentType DocumentType
        {
            set { documentReferenceControl.DocumentType = value; }
            get { return documentReferenceControl.DocumentType; }
        }

        public ItemDescriptionReferenceControl()
        {
            InitializeComponent();
            rbDefinition.CheckedChanged += rbDefinition_CheckedChanged;
            rbDocumentReference.CheckedChanged += rbDocumentReference_CheckedChanged;
            rbDefinition.Checked = true;
        }

        [Browsable( false ), DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
        public ItemDescriptionReference ItemDescriptionReference
        {
            get
            {
                ControlsToData();
                return _itemDescriptionReference;
            }
            set
            {
                _itemDescriptionReference = value;
                DataToControls();
            }
        }

        public event DocumentReferenceSelectionDelegate DocumentReferenceSelection;
        public event ItemDescriptionSelectionDelegate ItemDescriptionSelection;

        protected virtual void DataToControls()
        {
            if (_itemDescriptionReference != null)
            {
                if (_itemDescriptionReference.Item != null)
                {
                    rbDocumentReference.Checked = _itemDescriptionReference.Item is DocumentReference;
                    rbDefinition.Checked = _itemDescriptionReference.Item is ItemDescription;
                    documentReferenceControl.DocumentReference = _itemDescriptionReference.Item as DocumentReference;
                    itemDescriptionControl.ItemDescription = _itemDescriptionReference.Item as ItemDescription;
                }
            }
        }

        protected virtual void ControlsToData()
        {
            if( _itemDescriptionReference == null )
                _itemDescriptionReference = new ItemDescriptionReference();
            if (rbDocumentReference.Checked)
                _itemDescriptionReference.Item = documentReferenceControl.DocumentReference;
            else if (rbDefinition.Checked)
                _itemDescriptionReference.Item = itemDescriptionControl.ItemDescription;
        }

        protected virtual void OnDocumentReferenceSelection( DocumentReference documentReference )
        {
            DocumentReferenceSelectionDelegate handler = DocumentReferenceSelection;
            if (handler != null) handler( documentReference );
        }

        protected virtual void OnItemDescriptionSelection( ItemDescription itemDescription )
        {
            ItemDescriptionSelectionDelegate handler = ItemDescriptionSelection;
            if (handler != null) handler( itemDescription );
        }

        private void rbDefinition_CheckedChanged( object sender, EventArgs e )
        {
            OnItemDescriptionSelection( itemDescriptionControl.ItemDescription );
            SetControlStates();
        }

        private void rbDocumentReference_CheckedChanged( object sender, EventArgs e )
        {
            OnDocumentReferenceSelection( documentReferenceControl.DocumentReference );
            SetControlStates();
        }

        private void SetControlStates()
        {
            documentReferenceControl.Visible = rbDocumentReference.Checked;
            itemDescriptionControl.Visible = rbDefinition.Checked;
            if (rbDocumentReference.Checked)
            {
                if (panel1.Controls.IndexOf( documentReferenceControl ) == -1)
                    panel1.Controls.Add( documentReferenceControl );
                panel1.Controls.Remove( itemDescriptionControl );
            }
            if (rbDefinition.Checked)
            {
                if (panel1.Controls.IndexOf( itemDescriptionControl ) == -1)
                    panel1.Controls.Add( itemDescriptionControl );
                panel1.Controls.Remove( documentReferenceControl );
            }
        }

        public void EditDocumentObject()
        {
            if (documentReferenceControl.Visible)
                documentReferenceControl.EditDocumentObject();
        }
    }
}