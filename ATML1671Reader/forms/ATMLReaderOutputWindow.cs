/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using ATML1671Reader.reader;
using ATMLCommonLibrary.forms;
using ATMLModelLibrary;
using ATMLModelLibrary.interfaces;
using ATMLModelLibrary.model.common;
using ATMLProject.managers;
using ATMLSchemaLibrary.managers;
using ATMLUtilitiesLibrary;

namespace ATML1671Reader.forms
{
    public partial class ATMLReaderOutputWindow : ATMLDocumentBaseForm, IATMLReaderConsumer
    {
        public ATMLReaderOutputWindow()
        {
            InitializeComponent();
            this.toolStrip1.Items.Add( btnValidate );
            atmlPreviewPanel.InitForXML();
            ProjectManager.Instance.AtmlFileSaved += ATMLReaderOutputWindow_AtmlFileSaved;
        }


        public void RegisterATMLReader( ATMLReader reader )
        {
            reader.OpenInputDocument += reader_OpenInputDocument;
            reader.ParseableInputDocument += reader_ParseableInputDocument;
            reader.AtmlDocumentOpened += LoadOutputText;
            reader.AtmlFileOpened += LoadOutputText;
            reader.InputDocumentTranslated += LoadOutputText;
            reader.NavigableInputDocument += reader_NavigableInputDocument;
            reader.BeginOpenDocument += reader_BeginOpenDocument;
            reader.ProjectOpened += reader_ProjectOpened;
            reader.ProjectClosed += reader_ProjectClosed;
        }

        private void ATMLReaderOutputWindow_AtmlFileSaved( object sender, 
                                                           string fileName, 
                                                           byte[] content,
                                                           AtmlFileType atmlFileType )
        {
            if (atmlFileType == AtmlFileType.AtmlTypeTestConfiguration)
            {
                atmlPreviewPanel.Text = Encoding.UTF8.GetString( content );
                atmlPreviewPanel.InitForXML();
            }
        }

        private void reader_ProjectClosed()
        {
            ReleaseDocumentWatcher();
        }

        protected void reader_ProjectOpened( string testProgramSetName )
        {
            string projectPath = Path.Combine( ATMLContext.TESTSET_PATH, testProgramSetName, "atml" );
            CreateDocumentWatcher( projectPath, "*1671.4.xml" );
        }

        private void reader_BeginOpenDocument()
        {
        }

        private void reader_NavigableInputDocument()
        {
        }

        private void LoadOutputText( Document document )
        {
            atmlPreviewPanel.Open( document );
        }

        private void LoadOutputText( FileInfo fileInfo, byte[] content )
        {
            FileInfo = fileInfo;
            atmlPreviewPanel.Open( fileInfo, content );
        }

        private void LoadOutputText( TestConfiguration15 testConfiguration )
        {
            //No need to do this now that we have a file watcher
            //ATMLOutputText = testConfiguration.Serialize();
        }

        private void reader_ParseableInputDocument()
        {
        }

        private void reader_OpenInputDocument( FileInfo fileInfo, byte[] content )
        {
            FileInfo = fileInfo;
        }

        protected override bool ProcessCmdKey( ref Message msg, Keys keyData )
        {
            if (keyData == ( Keys.Control | Keys.F4 ))
            {
                Console.Beep();
                return true;
            }
            return base.ProcessCmdKey( ref msg, keyData );
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            StringBuilder error = new StringBuilder(1024 * 1024 * 6);
            if( !SchemaManager.ValidateXml(atmlPreviewPanel.Text, ATMLCommon.TestConfigurationNameSpace, error) )
            {
                ATMLErrorForm.ShowValidationMessage(
                    string.Format("The Test Configuration has failed validation against the ATML schema."),
                    error.ToString(),
                    "Note: This error will not prevent you from continuing.");
            }
            else
            {
                MessageBox.Show(@"This Test Configuration has generated a valid ATML document.");
            }
        }
    }
}