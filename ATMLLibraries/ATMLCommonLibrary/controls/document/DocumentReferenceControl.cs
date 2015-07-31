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
using System.Text;
using System.Windows.Forms;
using ATMLCommonLibrary.controls.equipment;
using ATMLCommonLibrary.forms;
using ATMLCommonLibrary.managers;
using ATMLManagerLibrary.interfaces;
using ATMLManagerLibrary.managers;
using ATMLModelLibrary.model.common;
using ATMLModelLibrary.model.equipment;
using ATMLModelLibrary.model.uut;
using ATMLDataAccessLibrary.model;

namespace ATMLCommonLibrary.controls.document
{

    public partial class DocumentReferenceControl : UserControl, IDocumentEditor
    {
        private List<string> _allReadySelectedDocument = new List<string>();
        private Document _document = null;
        private DocumentReference _documentReference;
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DocumentReference DocumentReference
        {
            get { ControlsToData(); return _documentReference; }
            set { _documentReference = value; DataToControls(); }
        }

        /**
         * Sets/Gets the document type for the reference control. This will be used when pressing the 
         * "Find" button so that only documents of this type will be presented to the user.
         */
        public dbDocument.DocumentType DocumentType { set; get; }

        public List<string> AllReadySelectedDocument
        {
            set { _allReadySelectedDocument = value; }
        }

        public void AddSelectedDocumentId( string uuid )
        {
            _allReadySelectedDocument.Add(uuid);
        }


        protected virtual void ControlsToData()
        {
            if (_documentReference == null)
                _documentReference = new DocumentReference();
            _documentReference.ID = edtDocumentID.Text;
            _documentReference.uuid = edtUUID.Text;
        }

        protected virtual void DataToControls()
        {
            if (_documentReference != null)
            {
                edtUUID.Text = _documentReference.uuid;
                edtDocumentID.Text = _documentReference.ID;
                _document = DocumentManager.GetDocument(_documentReference.uuid);
                if( _document == null )
                    LogManager.Error("There is no document in the document library for uuid \"{0}\"", _documentReference.uuid );
                else
                    atmlPreviewPanel.Open(_document);
            }
        }

        public DocumentReferenceControl()
        {
            InitializeComponent();
            DocumentManager.Instance.DocumentChanged += DocumentReferenceControlDocumentChanged;
        }

        private void btnReferenceLookup_Click(object sender, EventArgs e)
        {
            //TODO: Lookup Document
            DocumentLibrarySelectionForm form =
                new DocumentLibrarySelectionForm(_allReadySelectedDocument, DocumentType );
            if (DialogResult.OK == form.ShowDialog())
            {
                Document document = form.SelectedDocument;
                if (document != null)
                {
                    atmlPreviewPanel.Open(document);
                    _documentReference = new DocumentReference();
                    _documentReference.uuid = document.uuid;
                    _documentReference.ID = document.name;
                    DataToControls();
                }
            }
        }

        public void EditDocumentObject()
        {
            try
            {
                DocumentManager.EditDocument(this, _document, edtUUID.GetValue<string>(), Encoding.UTF8.GetString(_document.DocumentContent), true);
            }
            catch (Exception e)
            {
                ATMLErrorForm.ShowError(e);
            }
            
        }

        void DocumentReferenceControlDocumentChanged(Document document)
        {
            atmlPreviewPanel.Open(_document);
        }

        public void UpdateContent(string content)
        {
            _document.DocumentContent = Encoding.UTF8.GetBytes(content);
            atmlPreviewPanel.Open(_document);
        }
    }
}
