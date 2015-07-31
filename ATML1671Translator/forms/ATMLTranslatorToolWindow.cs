/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using ATML1671Translator.controls;
using ATML1671Translator.exceptions;
using ATML1671Translator.translator;
using ATMLCommonLibrary.model;
using ATMLCommonLibrary.model.navigator;
using ATMLCommonLibrary.utils;
using ATMLManagerLibrary.managers;
using ATMLModelLibrary.model;
using ATMLProject.managers;
using ATMLSignalModelLibrary.managers;
using ATMLUtilitiesLibrary;
using ScintillaNET;
using WeifenLuo.WinFormsUI.Docking;

namespace ATML1671Translator.forms
{
    public partial class ATMLTranslatorToolWindow : DockContent, IATMLDockableWindow, IATMLTranslatorConsumer
    {
        private const String BUILD_FILE_EXTENSION = "abf";
        private readonly BindingSource _bindingSource;
        private readonly ITranslatorNavigator _navigator;
        private readonly Dictionary<string, string> _sourceType = new Dictionary<string, string>();
        private readonly ATMLTranslatorOutputWindow _translatorOutputWindow;
        private XDocument _aixmlDocument;
        private bool _aixmlParseInProgress;
        private bool _aixmlTranslationInProgress;
        private string _originalProjectInfo;
        private ProjectInfo _projectInfo;
        private bool _projectOpened;
        private FileInfo _sourceFileInfo;
        private List<TranslationSourceInfo> _sourceFiles;
        private ATMLTranslator _translator;

        public ATMLTranslatorToolWindow( ITranslatorNavigator navigator )
        {
            InitializeComponent();
            InitSourceTypes();
            _bindingSource = new BindingSource();
            _navigator = navigator;
            _navigator.FileAdded += NavigatorOnFileAdded;
            _navigator.FileDeleted += NavigatorOnFileDeleted;
            _translatorOutputWindow = new ATMLTranslatorOutputWindow();
            edtSourceDocument.Lexing.Lexer = Lexer.Fortran;
            edtSourceDocument.ConfigurationManager.Language = "fortran";
            btnParseSourceDocument.Enabled = false;
            edtSourceDocument.ModifiedChanged += edtSourceDocument_ModifiedChanged;
            edtSourceDocument.KeyUp += edtSourceDocument_KeyUp;
            edtSourceDocument.NativeInterface.SetReadOnly( true );
            ProjectManager.Instance.ProjectOpened += InstanceOnProjectOpened;
            ProjectManager.Instance.ProjectClosing += InstanceOnProjectClosing;
            dgBuildList.Resize += DgBuildListOnResize;
            dgPropertyInfo.Columns.Add( "name", "Property" );
            dgPropertyInfo.Columns.Add( "value", "Value" );
            dgPropertyInfo.RowsDefaultCellStyle.BackColor = Color.Honeydew;
            dgPropertyInfo.Resize += ( sender, args ) => ResizePropertyGrid();
            dgPropertyInfo.EditingControlShowing += DgPropertyInfoOnEditingControlShowing;
            dgBuildList.ReadOnly = true;
            btnSaveTranslationConfig.Visible = false;
            btnUndo.Visible = false;
            ResizePropertyGrid();
            SetButtonStates();
        }

        public void CloseProject()
        {
            _projectOpened = false;
            lblFileName.Text = "";
            edtSourceDocument.Text = "";
            chkSegmentedSource.Checked = false;
            dgBuildList.DataSource = null;
            dgPropertyInfo.Rows.Clear();
            dgBuildList.Refresh();
            _sourceFiles.Clear();
            SetButtonStates();
        }

        public void RegisterATMLTranslator( ATMLTranslator translator )
        {
            _translator = translator;
            _translator.InputDocumentOpened += _translator_OpenSourceDocument;
            _translator.AixmlTranslationStarted += delegate
                                                   {
                                                       _aixmlTranslationInProgress = true;
                                                       SetButtonStates();
                                                   };
            _translator.AixmlTranslationCompleted += _translator_AixmlTranslationCompleted;
            _translator.AixmlParseStarted += delegate
                                             {
                                                 _aixmlParseInProgress = true;
                                                 SetButtonStates();
                                             };
            _translator.AixmlParseCompleted += TranslatorOnAixmlParseCompleted;
            _translatorOutputWindow.RegisterATMLTranslator( translator );
        }

        private void edtSourceDocument_KeyUp( object sender, KeyEventArgs e )
        {
            try
            {
                if (e.Alt && e.Control && e.KeyCode == Keys.P && _sourceFileInfo != null)
                {
                    if (edtSourceDocument.Selection != null)
                    {
                        Line startLine = edtSourceDocument.Selection.Range.StartingLine;
                        Line endLine = edtSourceDocument.Selection.Range.EndingLine;
                        LogManager.Trace( "Extracting Procedure Starting on:{0}, Ending on:{1}", startLine.Number + 1,
                                          endLine.Number );
                        string projectName = ProjectManager.ProjectName;
                        if (string.IsNullOrEmpty( projectName ))
                            throw new Exception( "You must open a project in order to map signals." );
                        string xmlPath = Path.Combine( ATMLContext.ProjectTranslatorAixmlPath,
                                                       projectName + ".aixml.xml" );
                        if (!File.Exists( xmlPath ))
                            throw new TranslationException( "Mapping Failed: Missing AIXML File." );
                        if (_aixmlDocument == null)
                            _aixmlDocument = XDocument.Load( new MemoryStream( FileManager.ReadFile( xmlPath ) ) );
                        for (int i = startLine.Number + 1; i <= endLine.Number; i++)
                        {
                            XElement node = _aixmlDocument.XPathSelectElement(string.Format("//*[@line_number='{0}' and @file='{1}']", i, _sourceFileInfo.Name));
                            ProcessAtlasSource( node );
                        }
                    }
                }
            }
            catch (Exception err)
            {
                LogManager.Error( err );
            }
        }

        private void ProcessAtlasSource(XElement node)
        {
            if (node != null)
            {
                XName name = node.Name;
                if (name.LocalName.Equals( "line" ))
                {
                    //LogManager.Trace(string.Format("Comment {0} - {1}", node.Name, node.FirstNode ));
                }
                if (name.LocalName.Equals( "atlas_source" ))
                {
                    if (node.Parent != null)
                    {
                        if (node.Parent.Name.LocalName.Equals( "statement" ))
                        {
                            ProcessStatement( node.Parent );
                        }
                        else
                        {
                            LogManager.Trace(string.Format("Statement {0}", node.Parent.Name));
                        }
                    }
                }
            }
        }

        private void ProcessStatement( XElement node )
        {
            string delimiter = "-------------------------------------- {0} {1} --------------------------------------";
            XAttribute typeAttribute = node.Attribute( "type" );
            XAttribute procRefIdAttribute = node.Attribute( "proc_refid" );
            XAttribute refIdAttribute = node.Attribute( "refid" );
            if (typeAttribute != null)
            {
                string statementType = typeAttribute.Value;
                if ("PERFORM".Equals( statementType ))
                {
                    ProcessProcedure( procRefIdAttribute, refIdAttribute, delimiter );
                }
                else if ("IF THEN".Equals(statementType))
                {
                    XElement statements = node.XPathSelectElement(string.Format("statements" ));
                    if (statements != null)
                    {
                        foreach (XElement xElement in statements.Elements())
                        {
                            ProcessStatement( xElement );
                        }
                    }
                }
                else
                {
                    LogManager.Trace( string.Format( "Statement {0}", node.Attribute( "type" ).Value ) );
                }
            }
        }

        private void ProcessProcedure( XAttribute procRefIdAttribute, XAttribute refIdAttribute, string delimiter )
        {
            string procRefId = procRefIdAttribute != null
                                   ? procRefIdAttribute.Value
                                   : refIdAttribute != null ? refIdAttribute.Value : null;
            if (!string.IsNullOrEmpty( procRefId ))
            {
                //--- Lookup Procedure and extract whats done ---//
                XElement pnode =
                    _aixmlDocument.XPathSelectElement( string.Format( "//*[@id='{0}' ]/statements",
                                                                      procRefId ) );
                if (pnode != null)
                {
                    if (pnode.Parent != null)
                    {
                        XAttribute name = pnode.Parent.Attribute( "name" );
                        LogManager.Trace( string.Format( delimiter, "START", name == null ? "" : name.Value ) );
                        foreach (XElement xElement in pnode.Elements())
                        {
                            ProcessStatement( xElement );
                        }
                        LogManager.Trace( string.Format( delimiter, "END", name == null ? "" : name.Value ) );
                    }
                }
            }
        }

        public void UpdateProjectInfo()
        {
            InstanceOnProjectOpened( null );
        }

        private void TranslatorOnAixmlParseCompleted( object sender, EventArgs eventArgs )
        {
            this.UIThreadInvoke( delegate
                                 {
                                     _aixmlParseInProgress = false;
                                     SetButtonStates();
                                 } );
        }

        private void _translator_AixmlTranslationCompleted( object sender, EventArgs e )
        {
            this.UIThreadInvoke( delegate
                                 {
                                     var td = sender as string;
                                     _aixmlTranslationInProgress = false;
                                     SetButtonStates();
                                     if (td != null)
                                         ATMLTranslator.CompareTestDescriptionToSource( td );
                                 } );
        }

        private void SetButtonStates()
        {
            btnUndo.Visible = btnSave.Visible = _projectOpened && IsDirty();
            btnParseSourceDocument.Enabled = _projectInfo != null
                                             && _projectInfo.TranslationInfo != null
                                             && !btnSave.Visible
                                             && !_aixmlTranslationInProgress
                                             && !_aixmlParseInProgress
                                             && _projectOpened;
            btnBuildSignalMap.Enabled = !_aixmlTranslationInProgress && !_aixmlParseInProgress && _projectOpened;
            btnTranslateAIXML.Enabled = !_aixmlTranslationInProgress && !_aixmlParseInProgress && _projectOpened;
        }

        private void InstanceOnProjectClosing( object sender, EventArgs eventArgs )
        {
            if (IsDirty())
            {
                if (DialogResult.Yes ==
                    MessageBox.Show( @"Would you like to save the current Translation Configuration?", @"V E R I F Y",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question ))
                {
                    SaveProjectInfo();
                }
            }
        }

        private void InitSourceTypes()
        {
            _sourceType.Add( "ATLAS", "translator.atlas.source.ext" );
            cmbSourceTypes.DataSource = new BindingSource( _sourceType, null );
            cmbSourceTypes.DisplayMember = "Key";
            cmbSourceTypes.ValueMember = "Value";
            cmbSourceTypes.SelectedIndex = 0;
        }

        /**
         * Called when a file is deleted from the Navigator. If
         * the file is a source file and contained in the 
         * Build List it will be removed from the build list.
         */

        private void NavigatorOnFileDeleted( FileInfo fi )
        {
            try
            {
                if (IsFileInSourceFolder( fi ) && HasFileInBuildList( fi ))
                {
                    foreach (TranslationSourceInfo translationSourceInfo in _sourceFiles.ToArray())
                    {
                        if (translationSourceInfo.FileName.Equals( fi.Name ))
                        {
                            _sourceFiles.Remove( translationSourceInfo );
                            //SaveProjectInfo();
                            SetButtonStates();
                            _bindingSource.ResetBindings( false );
                            break;
                        }
                    }
                }
            }
            catch (Exception err)
            {
                LogManager.SourceError( ATMLTranslator.SOURCE, err );
            }
        }

        /**
         * Called when a file has been added to the Navigator.
         * We look to see if is a Translator source file and
         * is source code file. If it is we will automatically 
         * add it to the build list.
         */

        private void NavigatorOnFileAdded( FileInfo fi )
        {
            try
            {
                if (IsFileInSourceFolder( fi ))
                {
                    var property = cmbSourceTypes.SelectedValue as string;
                    if (property == null) throw new Exception( "No Selected Source Item" );
                    var sourceFileExtensions = ATMLContext.GetProperty( property ) as string;
                    if (sourceFileExtensions == null)
                        throw new Exception( string.Format( "Failed to find property [{0}]", property ) );
                    if (sourceFileExtensions.Contains( fi.Extension ))
                    {
                        if (!HasFileInBuildList( fi ))
                        {
                            var si = new TranslationSourceInfo( fi.Name );
                            _sourceFiles.Add( si );
                            //SaveProjectInfo();
                            SetButtonStates();
                            _bindingSource.ResetBindings( false );
                        }
                    }
                }
            }
            catch (Exception err)
            {
                LogManager.SourceError( ATMLTranslator.SOURCE, err );
            }
        }

        /**
         * Determines if the file provided is located within the Translator
         * source folder.
         */

        private static bool IsFileInSourceFolder( FileInfo fi )
        {
            return fi.Directory != null && "source".Equals( fi.Directory.Name );
        }

        /**
         * Refreshes the datasource for the Build List.
         */

//        private void ResetBuildList()
//        {
//            dgBuildList.SuspendLayout();
//            dgBuildList.DataSource = null;
//            dgBuildList.DataSource = _sourceFiles;
//            dgBuildList.Update();
//            SetSourceGridState();
//            dgBuildList.ResumeLayout();
//        }

        private bool HasFileInBuildList( FileInfo fi )
        {
            bool ok2Add = false;
            foreach (TranslationSourceInfo translationSourceInfo in _sourceFiles)
            {
                if (fi.Name.Equals( translationSourceInfo.FileName ))
                {
                    ok2Add = true;
                    break;
                }
            }
            return ok2Add;
        }

        private void ResizePropertyGrid()
        {
            if (dgPropertyInfo.Columns.Count > 0)
            {
                int rows = dgPropertyInfo.Rows.GetRowsHeight( DataGridViewElementStates.Visible );
                int header = dgPropertyInfo.ColumnHeadersHeight;
                int height = dgPropertyInfo.Height;
                bool vbarVisible = ( height - header ) < rows;
                if (dgPropertyInfo.Columns.Count >= 2 )
                {
                    dgPropertyInfo.Columns[0].Width = (int) ( dgPropertyInfo.Width*.30 );
                    dgPropertyInfo.Columns[1].Width = dgPropertyInfo.Width -
                                                      ( dgPropertyInfo.Columns[0].Width
                                                        + ( vbarVisible ? SystemInformation.VerticalScrollBarWidth : 0 )
                                                        + 3 );
                }
            }
        }

        private void DgBuildListOnResize( object sender, EventArgs eventArgs )
        {
            ResizeSourceList();
        }

        private bool IsDirty()
        {
            return _projectInfo != null
                   && !string.IsNullOrEmpty( _originalProjectInfo )
                   && !_originalProjectInfo.Equals( XmlUtils.SerializeObject( _projectInfo ) );
        }

        private void InstanceOnProjectOpened( string testProgramSetName )
        {
            try
            {
                dgPropertyInfo.Rows.Clear();
                _projectOpened = true;
                _projectInfo = ProjectManager.ProjectInfo;
                _originalProjectInfo = XmlUtils.SerializeObject( _projectInfo );
                _projectInfo.TranslationInfo = _projectInfo.TranslationInfo ?? new TranslationInfo();
                chkSegmentedSource.Checked = _projectInfo.TranslationInfo.Segmented;
                _sourceFiles = _projectInfo.TranslationInfo.SourceFiles;

                var fileNames = new List<string>();
                if (_projectInfo != null)
                {
                    CreatePropertyInfoComboRow( "Station Type", _projectInfo.ClassName );
                    dgPropertyInfo.Rows.Add( CreatePropertyInfoTextRow( "Project Name", _projectInfo.ProjectName ) );
                    dgPropertyInfo.Rows.Add( CreatePropertyInfoTextRow( "ID", _projectInfo.Uuid ) );
                    dgPropertyInfo.Rows.Add( CreatePropertyInfoTextRow( "UUT", _projectInfo.UutName ) );
                    dgPropertyInfo.Rows.Add( CreatePropertyInfoTextRow( "UUT ID", _projectInfo.UutId ) );
                }
                FileManager.GetFileNames( fileNames, ATMLContext.ProjectTranslatorSourcePath, false, "*.as", true );
                if (_sourceFiles == null)
                {
                    _sourceFiles = new List<TranslationSourceInfo>();
                    foreach (string fileName in fileNames)
                    {
                        _sourceFiles.Add( new TranslationSourceInfo( fileName ) );
                    }
                    if (_sourceFiles.Count > 0)
                        _sourceFiles[0].Primary = true;
                    _projectInfo.TranslationInfo.SourceFiles = _sourceFiles;
                }
                _bindingSource.DataSource = _sourceFiles;
                dgBuildList.DataSource = _bindingSource;
                dgBuildList.CellClick += DgBuildListOnCellClick;
                dgBuildList.CellValueChanged += DgBuildListOnCellValueChanged;
                dgBuildList.CellMouseUp += DgBuildListOnCellMouseUp;
                SetSourceGridState();
                SetButtonStates();
                ResizePropertyGrid();
            }
            catch (Exception err)
            {
                LogManager.Error( err );
            }
        }

        private DataGridViewRow CreatePropertyInfoTextRow( string name, string value )
        {
            var r1 = new DataGridViewRow();
            DataGridViewCell cell1 = new DataGridViewTextBoxCell();
            DataGridViewCell cell2 = new DataGridViewTextBoxCell();
            cell1.Value = name;
            cell2.Value = value;
            r1.Cells.Add( cell1 );
            r1.Cells.Add( cell2 );
            return r1;
        }

        private void CreatePropertyInfoComboRow( string name, string value )
        {
            var r1 = new DataGridViewRow();
            var cell1 = new DataGridViewTextBoxCell();
            var cell2 = new DataGridViewComboBoxCell();
            cell1.Value = name;
            r1.Cells.Add( cell1 );
            r1.Cells.Add( cell2 );
            cell2.Items.Add( "CASS" );
            cell2.Items.Add( "ECASS" );
            cell2.Items.Add( "RTCASS" );
            cell2.Items.Add( "HYBRID" );
            cell2.ReadOnly = false;
            dgPropertyInfo.Rows.Add( r1 );
            cell2.Value = value;
        }

        private void DgPropertyInfoOnEditingControlShowing( object sender,
                                                            DataGridViewEditingControlShowingEventArgs
                                                                dataGridViewEditingControlShowingEventArgs )
        {
            var comboBox = dataGridViewEditingControlShowingEventArgs.Control as ComboBox;
            if (comboBox != null) comboBox.SelectedIndexChanged += LastColumnComboSelectionChanged;
        }

        private void LastColumnComboSelectionChanged( object sender, EventArgs e )
        {
            Point currentcell = dgPropertyInfo.CurrentCellAddress;
            int r = currentcell.Y;
            int c = currentcell.X;
            if (r == 0 && c == 1)
            {
                var sendingCb = sender as DataGridViewComboBoxEditingControl;
                var cell = (DataGridViewComboBoxCell) dgPropertyInfo.Rows[r].Cells[c];
                if (cell != null)
                {
                    if (sendingCb != null)
                    {
                        _projectInfo.ClassName = sendingCb.EditingControlFormattedValue.ToString();
                        SetButtonStates();
                    }
                }
            }
        }

        private void DgBuildListOnCellMouseUp( object sender,
                                               DataGridViewCellMouseEventArgs dataGridViewCellMouseEventArgs )
        {
            bool segmented = chkSegmentedSource.Checked;
            int ridx = dataGridViewCellMouseEventArgs.RowIndex;
            int cidx = dataGridViewCellMouseEventArgs.ColumnIndex;
            if (cidx == 0)
            {
                foreach (DataGridViewRow dataGridViewRow in dgBuildList.Rows)
                {
                    dataGridViewRow.Cells[0].Value = null;
                    dataGridViewRow.DefaultCellStyle.BackColor = segmented ? Color.White : Color.WhiteSmoke;
                    dataGridViewRow.DefaultCellStyle.ForeColor = segmented ? Color.Black : Color.DarkGray;
                    dgBuildList.InvalidateRow( dataGridViewRow.Index );
                    _sourceFiles[dataGridViewRow.Index].Primary = false;
                }
                TranslationSourceInfo ti = _sourceFiles[ridx];
                ti.Primary = true;
                _sourceFiles.Remove( ti );
                _sourceFiles.Insert( 0, ti );
                _bindingSource.ResetBindings( false );
                ColorBuildGrid();
                foreach (DataGridViewRow dataGridViewRow in dgBuildList.Rows)
                    dataGridViewRow.Selected = dataGridViewRow.Index == 0;
                SetButtonStates();
            }
        }

        private void SetSourceGridState()
        {
            if (toolStrip3.Items.Count > 1)
                toolStrip3.Items[2].Visible = chkSegmentedSource.Checked;
            if (toolStrip3.Items.Count > 2)
                toolStrip3.Items[3].Visible = chkSegmentedSource.Checked;

            bool segmented = chkSegmentedSource.Checked;
            foreach (DataGridViewRow dataGridViewRow in dgBuildList.Rows)
            {
                dataGridViewRow.DefaultCellStyle.BackColor = segmented ? Color.White : Color.WhiteSmoke;
                dataGridViewRow.DefaultCellStyle.ForeColor = segmented ? Color.Black : Color.DarkGray;
                dgBuildList.InvalidateRow( dataGridViewRow.Index );
            }
            dgBuildList.Update();
            dgBuildList.Refresh();
            ColorBuildGrid();
            ResizeSourceList();
        }

        private void ColorBuildGrid()
        {
            if (dgBuildList.Rows.Count > 0)
            {
                dgBuildList.Rows[0].DefaultCellStyle.BackColor = Color.Honeydew;
                dgBuildList.Rows[0].DefaultCellStyle.ForeColor = Color.Black;
            }
        }

        private void DgBuildListOnCellClick( object sender, DataGridViewCellEventArgs dataGridViewCellEventArgs )
        {
            dgBuildList.CommitEdit( DataGridViewDataErrorContexts.CurrentCellChange );
        }

        private void DgBuildListOnCellValueChanged( object sender, DataGridViewCellEventArgs dataGridViewCellEventArgs )
        {
            if (dataGridViewCellEventArgs.ColumnIndex == 0)
                dgBuildList.CancelEdit();
        }

        private void ResizeSourceList()
        {
            if (dgBuildList.Columns.Count > 1)
            {
                dgBuildList.Columns[0].Width = 50;
                dgBuildList.Columns[1].Width = dgBuildList.Width - 50;
            }
        }

        private void edtSourceDocument_ModifiedChanged( object sender, EventArgs e )
        {
            btnSave.Visible = edtSourceDocument.Modified;
        }

        private void _translator_OpenSourceDocument( FileInfo fi, byte[] content )
        {
            _sourceFileInfo = fi;
            edtSourceDocument.Text = "";
            if (content != null && content.Length > 0)
                edtSourceDocument.Text = Encoding.UTF8.GetString( content );
            lblFileName.Text = fi.Name;
            edtSourceDocument.Modified = false;
        }

        public void LoadTestDescriptionDocument( FileInfo fi )
        {
            _translatorOutputWindow.TestDescriptionFile = fi;
        }

        public void InitWindows( DockPane outputPane )
        {
            _translatorOutputWindow.Show( outputPane, DockAlignment.Right, .50 );
        }

        private void ATMLTranslatorToolWindow_Activated( object sender, EventArgs e )
        {
            if (_translatorOutputWindow.DockState != DockState.Document
                && _translatorOutputWindow.DockState != DockState.Float)
                _translatorOutputWindow.Show();
        }

        private void ATMLTranslatorToolWindow_Deactivate( object sender, EventArgs e )
        {
            if (_translatorOutputWindow.DockState != DockState.Document
                && _translatorOutputWindow.DockState != DockState.Float)
                _translatorOutputWindow.Hide();
        }


        private void ATMLTranslatorToolWindow_DragDrop( object sender, DragEventArgs e )
        {
            if (_translator.Extension.EndsWith( BUILD_FILE_EXTENSION ))
            {
                var draggedNode = (TreeNode) e.Data.GetData( typeof (TreeNode) );
                var fi = draggedNode.Tag as FileInfo;
                if (fi != null)
                {
                    edtSourceDocument.Text += ( fi.Name + "\r\n" );
                    _translator.SetContent( Encoding.UTF8.GetBytes( edtSourceDocument.Text ) );
                    _translator.SaveSourceDocument();
                }
            }
        }

        private void ATMLTranslatorToolWindow_DragEnter( object sender, DragEventArgs e )
        {
            e.Effect = ( _translator.Extension.EndsWith( BUILD_FILE_EXTENSION ) )
                           ? DragDropEffects.All
                           : DragDropEffects.None;
        }

        private void ATMLTranslatorToolWindow_DragOver( object sender, DragEventArgs e )
        {
            e.Effect = ( _translator.Extension.EndsWith( BUILD_FILE_EXTENSION ) )
                           ? DragDropEffects.All
                           : DragDropEffects.None;
        }

        private void edtSourceDocument_DragOver( object sender, DragEventArgs e )
        {
            e.Effect = ( _translator.Extension.EndsWith( BUILD_FILE_EXTENSION ) )
                           ? DragDropEffects.All
                           : DragDropEffects.None;
        }

        private void edtSourceDocument_DragEnter( object sender, DragEventArgs e )
        {
            e.Effect = ( _translator.Extension.EndsWith( BUILD_FILE_EXTENSION ) )
                           ? DragDropEffects.All
                           : DragDropEffects.None;
        }

        private void edtSourceDocument_DragDrop( object sender, DragEventArgs e )
        {
            e.Effect = ( _translator.Extension.EndsWith( BUILD_FILE_EXTENSION ) )
                           ? DragDropEffects.All
                           : DragDropEffects.None;
        }

        private void ATMLTranslatorToolWindow_DragLeave( object sender, EventArgs e )
        {
        }

        private void edtSourceDocument_DragLeave( object sender, EventArgs e )
        {
        }

        private void edtSourceDocument_TextChanged( object sender, EventArgs e )
        {
        }

        private void btnSave_Click( object sender, EventArgs e )
        {
            try
            {
                //_translator.SetContent( Encoding.UTF8.GetBytes( edtSourceDocument.Text ) );
                //_translator.SaveSourceDocument();
                SaveProjectInfo();
                //SetButtonStates();
                //edtSourceDocument.Modified = false;
            }
            catch (Exception err)
            {
                LogManager.SourceError( ATMLTranslator.SOURCE, err );
                throw;
            }
        }

        private void SaveProjectInfo()
        {
            _projectInfo.TranslationInfo.Segmented = chkSegmentedSource.Checked;
            ProjectManager.ProjectInfo = _projectInfo;
            _originalProjectInfo = XmlUtils.SerializeObject( _projectInfo );
            SetButtonStates();
        }

        private void btnParseSourceDocument_Click( object sender, EventArgs e )
        {
            try
            {
                HourGlass.Start();
                _translator.ParseSourceDocument();
            }
            catch (Exception err)
            {
                LogManager.SourceError( ATMLTranslator.SOURCE, err );
                throw;
            }
            finally
            {
                HourGlass.Stop();
            }
        }

        private void btnTranslateAIXML_Click( object sender, EventArgs e )
        {
            try
            {
                HourGlass.Start();
                _translator.TranslateAIXML();
            }
            catch (Exception err)
            {
                LogManager.SourceError( ATMLTranslator.SOURCE, err );
                throw;
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

        private void btnBuildSignalMap_Click( object sender, EventArgs e )
        {
            try
            {
                HourGlass.Start();
                var mapper = new SignalMapper();
                //var xmlPath = (String) ATMLContext.GetProperty( "translator.parser.xml-path" );
                string projectName = ProjectManager.ProjectName;
                if (string.IsNullOrEmpty( projectName ))
                    throw new Exception( "You must open a project in order to map signals." );
                //string projectPath = Path.Combine( ATMLContext.TESTSET_PATH, projectName );
                string xmlPath = Path.Combine( ATMLContext.ProjectTranslatorAixmlPath, projectName + ".aixml.xml" );
                if (!File.Exists( xmlPath ))
                    throw new TranslationException( "Mapping Failed: Missing AIXML File." );

                mapper.Process( FileManager.ReadFile( xmlPath ) );

                var form = new ATMLSignalMappingForm( mapper.UsedSignalsList ) {TreeModel = SignalManager.Instance.TSFSignalTree};
                HourGlass.Stop();
                form.ShowDialog( this );
            }
            catch (Exception err)
            {
                LogManager.SourceError( ATMLTranslator.SOURCE, err );
            }
            finally
            {
                HourGlass.Stop();
            }
        }

        private void chkSegmentedSource_CheckedChanged( object sender, EventArgs e )
        {
            if (dgBuildList.Columns.Count > 0)
            {
                SetSourceGridState();
                _projectInfo.TranslationInfo.Segmented = chkSegmentedSource.Checked;
                SetButtonStates();
            }
            ResizeSourceList();
        }

        private void btnSaveTranslationConfig_Click( object sender, EventArgs e )
        {
            SaveProjectInfo();
            LogManager.SourceTrace( ATMLTranslator.SOURCE, "The Translation Configuration has been saved." );
        }

        private void btnMoveRowUp_Click( object sender, EventArgs e )
        {
            if (dgBuildList.SelectedRows.Count > 0)
            {
                int i = 0;
                var rows = new int[dgBuildList.SelectedRows.Count];
                foreach (DataGridViewRow row in dgBuildList.SelectedRows)
                    rows[i++] = row.Index;
                Array.Sort( rows );
                int top = 1;
                foreach (int row in rows)
                {
                    if (row > 0)
                    {
                        TranslationSourceInfo ti = _sourceFiles[row];
                        int idx = Math.Max( row - 1, top );
                        _sourceFiles.RemoveAt( row );
                        _sourceFiles.Insert( idx, ti );
                        dgBuildList.Rows[row].Selected = false;
                        dgBuildList.Rows[idx].Selected = true;
                        if (idx == top)
                            top += 1;
                    }
                }
                //_bindingSource.ResetBindings(false);
                dgBuildList.Update();
                SetButtonStates();
                dgBuildList.Refresh();
                ColorBuildGrid();
            }
        }

        private void btnMoveRowDown_Click( object sender, EventArgs e )
        {
            if (dgBuildList.SelectedRows.Count > 0)
            {
                int i = 0;
                var rows = new int[dgBuildList.SelectedRows.Count];
                foreach (DataGridViewRow row in dgBuildList.SelectedRows)
                    rows[i++] = row.Index;
                Array.Sort( rows );
                i = dgBuildList.SelectedRows.Count;
                int bottom = _sourceFiles.Count;
                for (int x = i - 1; x >= 0; x--)
                {
                    int row = rows[x];
                    if (row > 0)
                    {
                        TranslationSourceInfo ti = _sourceFiles[row];
                        int idx = Math.Min( row + 1, bottom - 1 );
                        _sourceFiles.RemoveAt( row );
                        _sourceFiles.Insert( idx, ti );
                        dgBuildList.Rows[row].Selected = false;
                        dgBuildList.Rows[idx].Selected = true;
                        if (idx == ( bottom - 1 ))
                            bottom -= 1;
                    }
                }
                //_bindingSource.ResetBindings(false);
                dgBuildList.Update();
                SetButtonStates();
                dgBuildList.Refresh();
                ColorBuildGrid();
            }
        }

        private void btnAddSource_Click( object sender, EventArgs e )
        {
            var ofd = new OpenFileDialog();
            if (DialogResult.OK == ofd.ShowDialog())
            {
                foreach (string fileName in ofd.FileNames)
                {
                    var fi = new FileInfo( fileName );
                    if (fi.Exists)
                    {
                        var tsi = new TranslationSourceInfo( fi.Name );
                        if (Ok2AddFileToBuildList( fi ))
                        {
                            _sourceFiles.Add( tsi );
                            _bindingSource.ResetBindings( false );
                            SetButtonStates();
                        }
                    }
                }
            }
        }

        private bool Ok2AddFileToBuildList( FileInfo fi )
        {
            bool ok2Add = true;
            foreach (TranslationSourceInfo translationSourceInfo in _sourceFiles)
            {
                if (translationSourceInfo.FileName.Equals( fi.Name ))
                {
                    ok2Add = false;
                    break;
                }
            }
            return ok2Add;
        }

        private void btnDeleteSource_Click( object sender, EventArgs e )
        {
            try
            {
                if (dgBuildList.SelectedRows.Count > 0)
                {
                    var rowsToDelete = new int[dgBuildList.SelectedRows.Count];
                    int i = 0;
                    foreach (DataGridViewRow selectedRow in dgBuildList.SelectedRows)
                    {
                        rowsToDelete[i++] = selectedRow.Index;
                    }
                    Array.Sort( rowsToDelete );
                    for (int idx = rowsToDelete.Length - 1; idx >= 0; idx--)
                    {
                        _sourceFiles.RemoveAt( rowsToDelete[idx] );
                    }
                    _bindingSource.ResetBindings( false );
                    SetButtonStates();
                }
            }
            catch (Exception err)
            {
                LogManager.SourceError( ATMLTranslator.SOURCE, err );
            }
        }

        private void dgBuildList_DragOver( object sender, DragEventArgs e )
        {
            FileInfo fileInfo = _navigator.GetSelectedFile();
            e.Effect = ( fileInfo != null && Ok2AddFileToBuildList( fileInfo ) )
                           ? DragDropEffects.All
                           : DragDropEffects.None;
        }

        private void dgBuildList_DragDrop( object sender, DragEventArgs e )
        {
            FileInfo fileInfo = _navigator.GetSelectedFile();
            if (fileInfo != null)
            {
                var tsi = new TranslationSourceInfo( fileInfo.Name );
                if (Ok2AddFileToBuildList( fileInfo ))
                {
                    _sourceFiles.Add( tsi );
                    _bindingSource.ResetBindings( false );
                    SetButtonStates();
                }
            }
        }

        private void dgBuildList_DragEnter( object sender, DragEventArgs e )
        {
            FileInfo fileInfo = _navigator.GetSelectedFile();
            e.Effect = ( fileInfo != null && Ok2AddFileToBuildList( fileInfo ) )
                           ? DragDropEffects.All
                           : DragDropEffects.None;
        }

        private void btnUndo_Click( object sender, EventArgs e )
        {
            ProjectInfo pi = ProjectInfo.Deserialize( _originalProjectInfo );
            _projectInfo.Copy( pi );
            ProjectManager.ProjectInfo = pi;
            InstanceOnProjectOpened( null );
        }

        private delegate void SetEventCallback( object sender, EventArgs e );
    }
}