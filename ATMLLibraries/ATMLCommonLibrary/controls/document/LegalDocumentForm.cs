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
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using ATMLManagerLibrary.managers;
using ATMLModelLibrary.model.common;
using ATMLModelLibrary.model.equipment;
using ATMLUtilitiesLibrary;

namespace ATMLCommonLibrary.controls.document
{
    public partial class LegalDocumentForm : ATMLCommonLibrary.forms.ATMLForm
    {

        [EditorBrowsable(EditorBrowsableState.Never)]
        public Document LegalDocument
        {
            set { legalDocumentsControl.LegalDocument = value; }
            get { return legalDocumentsControl.LegalDocument; }
        }


        public LegalDocumentForm()
        {
            InitializeComponent();
        }

        public LegalDocumentForm( Document document )
        {
            InitializeComponent();
            this.LegalDocument = document;
        }

        private void btnImportDocument_Click(object sender, EventArgs e)
        {
            byte[] content = { };
            String fileName = "";
            String extension = "";
            FileInfo fileInfo = null;
            string document_uri = (string)ATMLContext.GetProperty("environment.document-location");

            if (FileManager.OpenFile(out content, out fileInfo))
            {
                fileName = fileInfo.Name;
                extension = fileInfo.Extension;
                var document = new Document();
                document.DocumentContent = content;
                document.name = fileName;
                document.uuid = Guid.NewGuid().ToString();
                document.FileInfo = fileInfo;
                if (document.ItemElementName == DocumentItemChoiceType.Text)
                    document.Item = Encoding.UTF8.GetString(content);
                else
                    document.Item = document_uri + "?uuid=" + document.uuid;
                legalDocumentsControl.Document = document;
            }
        }

        private void btnExportDocument_Click(object sender, EventArgs e)
        {
            FileManager.WriteFile(legalDocumentsControl.Document.DocumentContent, legalDocumentsControl.Document.name);
        }

        private void btnSaveToDatabase_Click(object sender, EventArgs e)
        {
            SaveToDatabase();
        }

        private void SaveToDatabase()
        {
            try
            {
                legalDocumentsControl.Document = LegalDocument;
                legalDocumentsControl.SaveDocument();
                LogManager.Trace("Legal Document \"{0}\" has been saved to the database.", legalDocumentsControl.Document.name);
            }
            catch (Exception err)
            {
                LogManager.Error(err, "An error has occurred saving legal document \"{0}\" to the database. \nError: {1} \n{2}",
                    legalDocumentsControl.Document.name, err.Message, legalDocumentsControl.Document.Dump);
            }
        }



    }
}
