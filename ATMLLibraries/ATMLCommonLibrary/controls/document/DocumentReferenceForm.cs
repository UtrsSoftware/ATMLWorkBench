/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using ATMLCommonLibrary.forms;
using ATMLDataAccessLibrary.model;
using ATMLModelLibrary.model.common;

namespace ATMLCommonLibrary.controls.document
{
    public partial class DocumentReferenceForm : ATMLForm
    {

        public DocumentReferenceForm()
        {
            InitializeComponent();
        }

        /**
        * Sets/Gets the document type for the reference control. This will be used when pressing the 
        * "Find" button so that only documents of this type will be presented to the user.
        */
        public dbDocument.DocumentType DocumentType
        {
            set { documentReferenceControl1.DocumentType = value; }
            get { return documentReferenceControl1.DocumentType; }
        }

        public DocumentReference DocumentReference
        {
            set { documentReferenceControl1.DocumentReference = value; }
            get { return documentReferenceControl1.DocumentReference; }
        }

        public void AddSelectedDocumentId( string uuid )
        {
            documentReferenceControl1.AddSelectedDocumentId( uuid );
        }

        private void btnEditDocumentObject_Click( object sender, EventArgs e )
        {
            documentReferenceControl1.EditDocumentObject();
        }
    }
}