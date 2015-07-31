/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using ATMLManagerLibrary.controllers;
using ATMLCommonLibrary.managers;
using ATMLCommonLibrary.model;
using ATMLManagerLibrary.managers;
using ATMLModelLibrary.model.common;
using ATMLDataAccessLibrary.db.beans;
using ATMLDataAccessLibrary.model;
using WeifenLuo.WinFormsUI.Docking;

namespace ATMLCommonLibrary.forms
{
    public partial class DocumentLibraryForm : DockContent, IATMLDockableWindow
    {
        public DocumentLibraryForm()
        {
            InitializeComponent();
            CacheManager.LoadDocumentTypeComboBox(cmbDocumentType);
            documentLibraryListControl.CompletedAdd += documentLibraryListControl_CompletedAdd;
            documentLibraryListControl.CompletedDelete += documentLibraryListControl_CompletedDelete;
            documentLibraryListControl.CompletedEdit += documentLibraryListControl_CompletedEdit;
        }

        public void CloseProject()
        {
        }

        private void documentLibraryListControl_CompletedEdit(object obj)
        {
            SaveDocument(obj, BASEBean.eDataState.DS_EDIT);
        }

        private void documentLibraryListControl_CompletedDelete(object obj)
        {
            SaveDocument(obj, BASEBean.eDataState.DS_DELETE);
        }

        private void documentLibraryListControl_CompletedAdd(object obj)
        {
            SaveDocument(obj, BASEBean.eDataState.DS_ADD );
        }
        
        private void SaveDocument(object obj, BASEBean.eDataState dataState)
        {
            if (obj is Document)
            {
                Document document = obj as Document;
                if (cmbDocumentType.SelectedItem != null)
                {
                    var type = (DocumentType) cmbDocumentType.SelectedItem;
                    if (type != null)
                    {
                        document.ContentType = type.contentType;
                        if (type.typeId != null) document.DocumentType = (dbDocument.DocumentType) type.typeId;
                    }
                }
                ((Document) obj).DataState = dataState;
                PersistanceController.Save((Document)obj);
            }
        }

        private void cmbDocumentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Filter List based on type
            var type = cmbDocumentType.SelectedItem as DocumentType;
            if (type != null && type.typeId != null )
            {
                documentLibraryListControl.Items.Clear();
                if (type.typeId != null)
                    documentLibraryListControl.DefaultDocumentType = (dbDocument.DocumentType)type.typeId;
                List<Document> documents = DocumentManager.GetDocumentsByType( type.typeId.Value );
                foreach (Document document in documents)
                {
                    documentLibraryListControl.AddListViewObject(document);
                }
            }
        }

        private void documentListControl_Load(object sender, EventArgs e)
        {
        }

        private void documentLibraryListControl_Load(object sender, EventArgs e)
        {
        }

        private void documentLibraryListControl1_Load(object sender, EventArgs e)
        {
        }
    }
}