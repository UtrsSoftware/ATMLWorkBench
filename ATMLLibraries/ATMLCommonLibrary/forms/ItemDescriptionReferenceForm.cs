/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using ATMLDataAccessLibrary.model;
using ATMLModelLibrary.model.common;

namespace ATMLCommonLibrary.forms
{
    public partial class ItemDescriptionReferenceForm : ATMLForm
    {

        public dbDocument.DocumentType DocumentType
        {
            set { itemDescriptionReferenceControl1.DocumentType = value; }
            get { return itemDescriptionReferenceControl1.DocumentType; }
        }

        public ItemDescriptionReferenceForm()
        {
            InitializeComponent();
            itemDescriptionReferenceControl1.DocumentReferenceSelection +=
                itemDescriptionReferenceControl1_DocumentReferenceSelection;
            itemDescriptionReferenceControl1.ItemDescriptionSelection +=
                itemDescriptionReferenceControl1_ItemDescriptionSelection;
        }

        public ItemDescriptionReference ItemDescriptionReference
        {
            get { return itemDescriptionReferenceControl1.ItemDescriptionReference; }
            set { itemDescriptionReferenceControl1.ItemDescriptionReference = value; }
        }

        private void itemDescriptionReferenceControl1_ItemDescriptionSelection(ItemDescription itemDescription)
        {
            btnEditDocumentObject.Visible = false;
        }

        private void itemDescriptionReferenceControl1_DocumentReferenceSelection(DocumentReference documentReference)
        {
            btnEditDocumentObject.Visible = true;
        }

        private void btnEditDocumentObject_Click(object sender, System.EventArgs e)
        {
            itemDescriptionReferenceControl1.EditDocumentObject();
        }
    }
}