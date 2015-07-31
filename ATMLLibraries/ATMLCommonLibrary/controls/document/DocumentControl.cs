/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.ComponentModel;
using System.Text;
using ATMLCommonLibrary.controls.validators;
using ATMLCommonLibrary.forms;
using ATMLDataAccessLibrary.db.beans;
using ATMLDataAccessLibrary.model;
using ATMLManagerLibrary.interfaces;
using ATMLManagerLibrary.managers;
using ATMLModelLibrary.model.common;
using ATMLModelLibrary.model.equipment;
using ATMLUtilitiesLibrary;
using ScintillaNET;
using Document = ATMLModelLibrary.model.common.Document;

namespace ATMLCommonLibrary.controls.document
{
    public delegate void DocumentChangeDelegate( Document document, bool isDirty );

    public partial class DocumentControl : ATMLControl, IDocumentEditor, IValidatable
    {
        protected Document _document = null;
        private bool _validationEnabled = true;

        public DocumentControl()
        {
            InitializeComponent();
            DocumentManager.Instance.DocumentChanged += DocumentControl_DocumentSaved;
            edtItem.NativeInterface.UpdateUI+=delegate
                                              {
                                                  edtItem.Tag = edtItem.CurrentPos;
                                              };
            rbText.Checked = true;
        }

        public bool HasDocument
        {
            get
            {
                bool hasDocument = ( Document != null && !string.IsNullOrEmpty( Document.Item ) &&
                                     !string.IsNullOrEmpty( Document.uuid ) );
                return hasDocument;
            }
        }

        [Browsable( false )]
        [DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
        public Document Document
        {
            get
            {
                ControlsToData();
                return _document;
            }
            set
            {
                _document = value;
                DataToControls();
            }
        }

        public bool ValidationEnabled
        {
            get { return _validationEnabled; }
            set
            {
                _validationEnabled
                    = requiredUUIDValidator.IsEnabled
                      = requiredTypeValidator.IsEnabled
                        = requiredNameValidator.IsEnabled
                          = value;
            }
        }

        public void UpdateContent( string content )
        {
            edtItem.Text = content;
        }

        public event DocumentChangeDelegate DocumentChanged;

        protected virtual void OnDocumentChanged( Document document, bool isDirty )
        {
            DocumentChangeDelegate handler = DocumentChanged;
            if (handler != null) handler( document, isDirty );
        }


        private void DocumentControl_DocumentSaved( Document document )
        {
            if (document != null)
            {
                edtItem.Text = Encoding.UTF8.GetString( document.DocumentContent );
                edtItem.CurrentPos = edtItem.Tag is int ? (int)edtItem.Tag : 0;
            }
        }

        public void SaveDocument()
        {
            ControlsToData();
            edtItem.SaveDocument();
        }


        private void rbText_CheckedChanged( object sender, EventArgs e )
        {
            //edtItem.Multiline = true;
            //edtItem.ScrollBars = ScrollBars.Both;
            lblItem.Text = "Text";
            if (_document != null && _document.DocumentContent != null)
            {
                edtItem.Text = Encoding.UTF8.GetString( _document.DocumentContent );
                _document.ItemElementName = DocumentItemChoiceType.Text;
            }
        }

        private void rbURL_CheckedChanged( object sender, EventArgs e )
        {
            //edtItem.ScrollBars = ScrollBars.None;
            //edtItem.Multiline = false;
            lblItem.Text = @"URL";
            if (_document != null)
            {
                var document_uri = (string) ATMLContext.GetProperty( "environment.document-location" );
                edtItem.Text = document_uri + @"?uuid=" + _document.uuid;
                _document.ItemElementName = DocumentItemChoiceType.URL;
            }
        }

        private void btnAddGUID_Click( object sender, EventArgs e )
        {
            Guid iid = Guid.NewGuid();
            edtUUID.Text = iid.ToString();
        }

        protected virtual void DataToControls()
        {
            if (_document != null)
            {
                rbText.Tag = DocumentItemChoiceType.Text;
                rbURL.Tag = DocumentItemChoiceType.URL;
                //rbText.Checked = ( _document.ItemElementName == DocumentItemChoiceType.Text );
                rbURL.Checked = ( _document.ItemElementName == DocumentItemChoiceType.URL );
                rbText.Checked = !rbURL.Checked;
                edtControlNumber.Text = _document.controlNumber;
                edtDocumentName.Text = _document.name;
                edtUUID.Text = _document.uuid;
                edtItem.Text = _document.Item;
                edtVersion.Text = _document.version;
                edtItem.Document = _document;
                edtDescription.Value = _document.Description;
                edtItem.InitForXML();
                btnExpandAll.Visible = btnCollapseAll.Visible = edtItem.IsXML;
            }
        }

        protected virtual void ControlsToData()
        {
            if (_document == null)
            {
                _document = edtItem.Document;
            }
            else
            {
                _document.Item = edtItem.Text;
            }
            _document.controlNumber = edtControlNumber.GetValue<string>();
            _document.name = edtDocumentName.GetValue<string>();
            _document.uuid = edtUUID.GetValue<string>();
            _document.version = edtVersion.GetValue<string>();
            _document.Description = edtDescription.GetValue<string>();
            if (rbText.Checked)
            {
                _document.ItemElementName = DocumentItemChoiceType.Text;
                _document.DocumentContent = Encoding.UTF8.GetBytes( edtItem.Text );
            }
            if (rbURL.Checked)
            {
                _document.ItemElementName = DocumentItemChoiceType.URL;
            }
        }

        private void edtDocumentName_TextChanged( object sender, EventArgs e )
        {
            var doc = new Document();
            if (_document != null)
                doc.DataState = _document.DataState;
            doc.name = edtDocumentName.GetValue<String>();
            OnDocumentChanged( doc, false );
        }

        private void edtItem_TextChanged( object sender, EventArgs e )
        {
            var doc = new Document();
            if (_document != null)
                doc.DataState = _document.DataState;
            doc.name = edtDocumentName.GetValue<String>() + ( edtItem.UndoRedo.CanUndo ? "*" : "" );
            OnDocumentChanged( doc, edtItem.UndoRedo.CanUndo );
        }

        public bool IsDirty()
        {
            return edtItem.UndoRedo.CanUndo;
        }

        public void EditDocumentObject()
        {
            try
            {
                ControlsToData();
                if (_document.DataState == BASEBean.eDataState.DS_ADD && string.IsNullOrWhiteSpace( edtItem.Text ))
                {
                    if (_document.DocumentType == dbDocument.DocumentType.INSTRUMENT_DESCRIPTION)
                    {
                        var instrument = new InstrumentDescription();
                        instrument.name = edtDocumentName.GetValue<string>();
                        instrument.uuid = edtUUID.GetValue<string>();
                        instrument.Description = edtDescription.GetValue<string>();
                        _document.DocumentContent = Encoding.UTF8.GetBytes( instrument.Serialize() );
                    }
                    edtItem.Text = Encoding.UTF8.GetString( _document.DocumentContent );
                    SaveDocument();
                }

                if (DocumentManager.EditDocument( this, _document, edtUUID.GetValue<string>(),
                                                  Encoding.UTF8.GetString( _document.DocumentContent ), false ))
                {
                    edtItem.Text = _document.Item;
                }
            }
            catch (Exception e)
            {
                ATMLErrorForm.ShowError( e );
            }
        }

        public bool Ok2Validate()
        {
            return HasDocument;
        }

        private void btnCollapseAll_Click(object sender, EventArgs e)
        {
            edtItem.FoldAll();
        }

        private void btnExpandAll_Click(object sender, EventArgs e)
        {
            edtItem.UnfoldAll();
        }
    }
}