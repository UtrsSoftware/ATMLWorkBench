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
using System.Windows.Forms;
using ATMLCommonLibrary.forms;
using ATMLDataAccessLibrary.db.beans;
using ATMLDataAccessLibrary.model;
using ATMLManagerLibrary.managers;
using ATMLModelLibrary.model.common;

namespace ATMLCommonLibrary.controls.document
{
    public partial class DocumentLibrarySelectionForm : ATMLForm
    {
        private Document _selectedDocument;

        public DocumentLibrarySelectionForm( List<string> selectedDocumentIds, dbDocument.DocumentType documentType )
        {
            InitializeComponent();

            cmbDocumentType.DataSource = Enum.GetNames(typeof(dbDocument.DocumentType));
            DocumentType = documentType;
            cmbDocumentType.SelectedIndex = cmbDocumentType.FindStringExact(Enum.GetName(typeof(dbDocument.DocumentType), documentType));

            Closing += DocumentLibrarySelectionForm_Closing;
            Load += DocumentLibrarySelectionForm_Load;
            documentLibraryListControl.DoubleClick += documentLibraryListControl_DoubleClick;
            documentLibraryListControl.Items.Clear();
            documentLibraryListControl.DefaultDocumentType = documentType;
            List<Document> documents = DocumentManager.GetDocumentsByType( (int) documentType );
            foreach (Document document in documents)
            {
                //--------------------------------------------------------------------------------------//
                //--- Only add to the Library List if the document is not already selected in a list ---//
                //--------------------------------------------------------------------------------------//
                //INFO: This may not work because an instrument may have multiple instances
                //if (selectedDocumentIds.Find( s => s == document.uuid ) == null) 
                    documentLibraryListControl.AddListViewObject( document );
            }
        }

        public dbDocument.DocumentType DocumentType { set; get; }

        public Document SelectedDocument
        {
            get { return _selectedDocument; }
            set { _selectedDocument = value; }
        }

        private void DocumentLibrarySelectionForm_Load( object sender, EventArgs e )
        {
            var docType = CacheManager.GetDocumentTypeCache().getItem( "" + (int) DocumentType ) as LuDocumentTypeBean;
            if (docType != null)
            {
                Text = string.Format( "Please Select a {0} Document", docType.typeName );
            }
        }

        private void documentLibraryListControl_DoubleClick( object sender, EventArgs e )
        {
            btnOk.PerformClick();
        }

        private void DocumentLibrarySelectionForm_Closing( object sender, CancelEventArgs e )
        {
            if (DialogResult.OK == DialogResult)
            {
                if (!documentLibraryListControl.HasSelected)
                    e.Cancel = true;
                else
                    _selectedDocument = documentLibraryListControl.SelectedObject as Document;
            }
        }

        private void cmbDocumentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDocumentType.SelectedIndex != -1)
            {
                dbDocument.DocumentType documentType = (dbDocument.DocumentType)Enum.Parse(typeof(dbDocument.DocumentType), cmbDocumentType.Text);
                documentLibraryListControl.Items.Clear();
                documentLibraryListControl.DefaultDocumentType = documentType;
                List<Document> documents = DocumentManager.GetDocumentsByType((int)documentType);
                foreach (Document document in documents)
                {
                    //--------------------------------------------------------------------------------------//
                    //--- Only add to the Library List if the document is not already selected in a list ---//
                    //--------------------------------------------------------------------------------------//
                    //INFO: This may not work because an instrument may have multiple instances
                    //if (selectedDocumentIds.Find( s => s == document.uuid ) == null) 
                    documentLibraryListControl.AddListViewObject(document);
                }
            }
        }
    }
}