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
using ATML1671Translator.translator;
using ATMLCommonLibrary.forms;
using ATMLCommonLibrary.model;
using ATMLCommonLibrary.utils;
using ATMLManagerLibrary.managers;
using ATMLModelLibrary;
using ATMLModelLibrary.interfaces;
using ATMLModelLibrary.model.common;
using ATMLProject.managers;
using ATMLSchemaLibrary.managers;
using ATMLUtilitiesLibrary;

namespace ATML1671Translator.forms
{
    public partial class ATMLTranslatorOutputWindow : ATMLDocumentBaseForm, IATMLDockableWindow, IATMLTranslatorConsumer
    {
        private FileInfo _fileInfo;

        public ATMLTranslatorOutputWindow()
        {
            InitializeComponent();
            toolStrip1.Items.Add( btnCompare );
            toolStrip1.Items.Add( btnValidate );
            ProjectManager.Instance.AtmlFileSaved += ATMLTranslatorOutputWindow_AtmlFileSaved;
            atmlPreviewPanel.InitForXML();
            atmlPreviewPanel.ReadOnly = false;
            atmlPreviewPanel.TextChanged += edtOutputDocument_TextChanged;
            SetControlStates();
            btnCollapseAll.Visible = true;
            btnExpandAll.Visible = true;
            btnWordWrap.Visible = true;
            btnSave.Click += btnSave_Click;

            this.MinimizeBox = true;
            this.MaximizeBox = true;

        }

        public FileInfo TestDescriptionFile
        {
            set
            {
                _fileInfo = value;
                Text = _fileInfo.Name;
                atmlPreviewPanel.Text = Encoding.UTF8.GetString( File.ReadAllBytes( _fileInfo.FullName ) );
                atmlPreviewPanel.Modified = false;
                SetControlStates();
            }
        }

        public void CloseProject()
        {
            atmlPreviewPanel.Text = "";
            atmlPreviewPanel.Modified = false;
            SetControlStates();
        }

        public void RegisterATMLTranslator( ATMLTranslator translator )
        {
            translator.AtmlDocumentOpened += translator_AtmlDocumentOpened;
            translator.AtmlFileOpened += translator_AtmlFileOpened;
            translator.ProjectOpened += translator_ProjectOpened;
            translator.ProjectClosed += translator_ProjectClosed;
        }

        private void translator_AtmlFileOpened( FileInfo fileInfo, byte[] content )
        {
            atmlPreviewPanel.Open( fileInfo, content );
            _fileInfo = fileInfo;
            SetControlStates();
        }

        private void translator_ProjectClosed()
        {
            ReleaseDocumentWatcher();
            atmlPreviewPanel.Clear();
        }

        protected void translator_ProjectOpened( string testProgramSetName )
        {
            string projectPath = Path.Combine( ATMLContext.TESTSET_PATH, testProgramSetName, "atml" );
            CreateDocumentWatcher( projectPath, "*1671.1.xml" );
            atmlPreviewPanel.ReadOnly = false;
        }

        private void SetControlStates()
        {
            bool hasTest = !string.IsNullOrWhiteSpace( atmlPreviewPanel.Text );
            btnCompare.Visible = hasTest;
            btnValidate.Visible = hasTest;
            btnCompare.Enabled = hasTest;
            btnCompare.Enabled = hasTest;
        }

        private void translator_AtmlDocumentOpened( Document document )
        {
        }

        private void edtOutputDocument_TextChanged( object sender, EventArgs e )
        {
            SetControlStates();
        }

        private void ATMLTranslatorOutputWindow_AtmlFileSaved( object sender, string fileName, byte[] content,
                                                               AtmlFileType atmlFileType )
        {
            if (atmlFileType == AtmlFileType.AtmlTypeTestDescription)
            {
                atmlPreviewPanel.Text = Encoding.UTF8.GetString( content );
                atmlPreviewPanel.InitForXML();
                SetControlStates();
            }
        }

        private void ATMLTranslatorOutputWindow_Activated( object sender, EventArgs e )
        {
        }

        private void ATMLTranslatorOutputWindow_Deactivate( object sender, EventArgs e )
        {
        }

        private void btnSave_Click( object sender, EventArgs e )
        {
            if (_fileInfo != null)
            {
                if (FileManager.WriteFile( _fileInfo.FullName, Encoding.UTF8.GetBytes( atmlPreviewPanel.Text ) ))
                    LogManager.SourceTrace(ATMLTranslator.SOURCE, "ATML File \"{0}\" has been saved.", _fileInfo.Name);
            }
        }

        private void btnCompare_Click( object sender, EventArgs e )
        {
            var comparer = new ATMLSourceComparer();

            comparer.TargetCode = atmlPreviewPanel.Text;
            comparer.Closing += delegate
                                {
                                    var form = sender as ATMLSourceComparer;
                                    if (form != null)
                                    {
                                        if (DialogResult.OK == form.DialogResult)
                                        {
                                        }
                                    }
                                };

            comparer.Show( DockPanel );
        }

        private void btnValidate_Click( object sender, EventArgs e )
        {
            try
            {
                HourGlass.Start();
                var error = new StringBuilder( 1024*1024*6 );
                if (!SchemaManager.ValidateXml( atmlPreviewPanel.Text, ATMLCommon.TestDescriptionNameSpace, error ))
                {
                    HourGlass.Stop();
                    ATMLErrorForm.ShowValidationMessage(
                        string.Format( "The Test Description has failed validation against the ATML schema." ),
                        error.ToString(),
                        "Note: This error will not prevent you from continuing." );
                }
                else
                {
                    HourGlass.Stop();
                    MessageBox.Show( @"This Test Description has generated a valid ATML document." );
                }
            }
            finally
            {
                HourGlass.Stop();
            }
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
    }
}