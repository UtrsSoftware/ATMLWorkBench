/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using ATMLCommonLibrary.controls.lists;
using ATMLCommonLibrary.forms;
using ATMLModelLibrary.model.common;
using ATMLDataAccessLibrary.model;

namespace ATMLCommonLibrary.controls.document
{
    public partial class DocumentLibraryListControl : ATMLListControl
    {
        private dbDocument.DocumentType _defaultDocumentType;

        public DocumentLibraryListControl() 
        {
            InitializeComponent();
            InitListView();
            InitializeForm += DocumentLibraryListControl_InitializeForm;
        }

        void DocumentLibraryListControl_InitializeForm(System.Windows.Forms.Form form)
        {
            DocumentForm docForm = form as DocumentForm;
            if (docForm != null)
            {
                docForm.DocumentType = _defaultDocumentType;
            }
        }

        public dbDocument.DocumentType DefaultDocumentType
        {
            get { return _defaultDocumentType; }
            set { _defaultDocumentType = value; }
        }

        private void InitListView()
        {
            var document = new Document();
            DataObjectName = "Document";
            DataObjectFormType = typeof (DocumentForm);
            AddColumnData("Type", "DocumentType", .20);
            AddColumnData("Name", "name", .30);
            AddColumnData("Description", "Description", .25);
            AddColumnData("uuid", "uuid", .25);
            InitColumns();
        }
    }
}