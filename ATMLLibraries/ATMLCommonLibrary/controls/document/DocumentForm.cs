/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows.Forms;
using ATMLCommonLibrary.forms;
using ATMLCommonLibrary.Properties;
using ATMLDataAccessLibrary.db.beans;
using ATMLDataAccessLibrary.model;
using ATMLManagerLibrary.managers;
using ATMLModelLibrary.model.common;
using ATMLUtilitiesLibrary;

namespace ATMLCommonLibrary.controls.document
{
    public partial class DocumentForm : ATMLForm
    {
        public DocumentForm()
        {
            InitializeComponent();
            CacheManager.LoadDocumentTypeComboBox( cmbDocumentType );
            documentControl.DocumentChanged += DocumentChanged;
            btnSaveToDatabase.Enabled = false;
        }

        public DocumentForm( dbDocument.DocumentType documentType ) : this()
        {
            SelectDocumentType( documentType );
        }

        public dbDocument.DocumentType DocumentType
        {
            set
            {
                SelectDocumentType( value );
                btnEditDocumentObject.Visible = DocumentManager.IsEditableDocumentType( value );
                if (documentControl.Document != null)
                    documentControl.Document.DocumentType = value;
            }
        }

        [Browsable( false ), DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
        public Document Document
        {
            get
            {
                Document document = documentControl.Document;
                var type = cmbDocumentType.SelectedItem as DocumentType;
                if (type != null && type.typeId != null)
                    document.DocumentType =
                        (dbDocument.DocumentType) Enum.ToObject( typeof (dbDocument.DocumentType), type.typeId );
                return document;
            }
            set
            {
                documentControl.Document = value;
                Text = CreateTitle( value );
                SelectDocumentType( value.DocumentType );
            }
        }

        private void SelectDocumentType( dbDocument.DocumentType documentType )
        {
            foreach (DocumentType type in cmbDocumentType.Items)
            {
                if (type.typeId == (int) documentType)
                    cmbDocumentType.SelectedItem = type;
            }
        }

        private void DocumentChanged( Document value, bool isDirty )
        {
            Text = CreateTitle( value );
            btnSaveToDatabase.Enabled = isDirty;
        }

        private static string CreateTitle( Document value )
        {
            return string.Format( "{0} Document: {1} ", IsAddMode( value ) ? "Add" : "Edit",
                                  value.name );
        }

        private static bool IsAddMode( Document value )
        {
            return value.DataState == BASEBean.eDataState.DS_ADD;
        }

        private void btnImportDocument_Click( object sender, EventArgs e )
        {
            byte[] content = {};
            String fileName = "";
            String extension = "";
            String uuid = null;
            FileInfo fileInfo = null;
            var document_uri = (string) ATMLContext.GetProperty( "environment.document-location" );
            Document existingDocument = documentControl.Document;
            if (existingDocument != null)
            {
                uuid = existingDocument.uuid;
            }

            if (FileManager.OpenFile( out content, out fileInfo ))
            {
                fileName = fileInfo.Name;
                extension = fileInfo.Extension;
                
                var document = new Document();
                document.DocumentContent = content;
                document.name = fileName;
                document.uuid = string.IsNullOrEmpty( uuid ) ? Guid.NewGuid().ToString() : uuid;
                document.FileInfo = fileInfo;
                document.ContentType = DocumentManager.GetContentType(extension);
                if (existingDocument != null)
                {
                    document.Description = existingDocument.Description;
                    document.DocumentType = existingDocument.DocumentType;
                    document.controlNumber = existingDocument.controlNumber;
                    document.version = existingDocument.version;
                }
                if (document.ItemElementName == DocumentItemChoiceType.Text)
                    document.Item = Encoding.UTF8.GetString( content );
                else
                    document.Item = document_uri + "?uuid=" + document.uuid;
                documentControl.Document = document;
                if (document.ItemElementName == DocumentItemChoiceType.Text)
                    documentControl.UpdateContent( Encoding.UTF8.GetString( content ) );
            }
        }

        private void btnExportDocument_Click( object sender, EventArgs e )
        {
            FileManager.WriteFile( documentControl.Document.DocumentContent, documentControl.Document.name );
        }

        private void btnOk_Click( object sender, EventArgs e )
        {
            SaveToDatabase();
        }

        private void DocumentForm_FormClosing( object sender, FormClosingEventArgs e )
        {
            if (documentControl.IsDirty())
            {
                DialogResult result = MessageBox.Show( Resources.Would_you_like_to_save_your_changes, Resources.V_E_R_I_F_Y,
                                                       MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question );
                if (DialogResult.Yes == result)
                {
                    SaveToDatabase();
                }
                else if (DialogResult.Cancel == result)
                {
                    e.Cancel = true;
                }
            }
        }

        private void btnSaveToDatabase_Click( object sender, EventArgs e )
        {
            SaveToDatabase();
        }

        private void SaveToDatabase()
        {
            try
            {
                documentControl.Document = Document;
                documentControl.SaveDocument();
                LogManager.Trace( "Document \"{0}\" has been saved to the database.", documentControl.Document.name );
            }
            catch (Exception err)
            {
                LogManager.Error( err,
                                  "An error has occurred saving document \"{0}\" to the database. \nError: {1} \n{2}",
                                  documentControl.Document.name, err.Message, documentControl.Document.Dump );
            }
        }

        private void btnEditDocumentObject_Click( object sender, EventArgs e )
        {
            documentControl.EditDocumentObject();
        }
    }
}