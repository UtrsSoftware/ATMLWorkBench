/*
* Copyright (c) 2014 Universal Technical Resource Services, inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using ATML1671Allocator.allocator;
using ATML1671Allocator.forms;
using ATML1671Reader.forms;
using ATML1671Reader.reader;
using ATML1671Translator.forms;
using ATML1671Translator.translator;
using ATMLCommonLibrary.controls.awb;
using ATMLCommonLibrary.controls.equipment;
using ATMLCommonLibrary.controls.instrument;
using ATMLCommonLibrary.controls.signal;
using ATMLCommonLibrary.controls.uut;
using ATMLCommonLibrary.forms;
using ATMLCommonLibrary.managers;
using ATMLCommonLibrary.model.navigator;
using ATMLCommonLibrary.utils;
using ATMLDataAccessLibrary.db.beans;
using ATMLDataAccessLibrary.db.daos;
using ATMLDataAccessLibrary.model;
using ATMLManagerLibrary.controllers;
using ATMLManagerLibrary.interfaces;
using ATMLManagerLibrary.managers;
using ATMLModelLibrary.interfaces;
using ATMLModelLibrary.model.common;
using ATMLModelLibrary.model.equipment;
using ATMLProject.managers;
using ATMLWorkBench.renderers;
using ATMLWorkBench.servers;
using mshtml;
using WeifenLuo.WinFormsUI.Docking;
using Path = System.IO.Path;
using Resources = ATMLWorkBench.Properties.Resources;
using ATMLUtilitiesLibrary;

namespace ATMLWorkBench
{
    /**
     * Primary Form for the ATML Workbench. All program control is initiated from 
     * this class. Instances of all the ATML Workbench tools resided in this class, as 
     * well as the Navigator and Output screens.
     * 
     * TODO: Need to make sure there is keyboard access for all functionality in the application.
     */

    public partial class MainFrame : Form
    {
        public const Int32 WM_SYSCOMMAND = 0x112;
        public const Int32 MF_BYPOSITION = 0x400;
        public const Int32 MF_SEPARATOR = 0x800;
        public const Int32 MNU_ABOUT = 1000;
        public const Int32 DEFAULT_PORT = 8081;

        #region Fields

        //private static GlobalMouseHook gmh;
        private static bool _beginSelection;

        private static readonly List<ATMLDocumentBaseForm> _openDocumentsList = new List<ATMLDocumentBaseForm>();

        /** Global Keybaord Hook, used primarily for cut and paste functionality */
        private static GlobalKeyboardHook _gkh;
        /** Instance of the Allocator Tool */
        private readonly ATMLAllocatorToolWindow _atmlAllocatorTool;
        /** Instance of the Reader Tool */
        private readonly ATMLReaderToolWindow _atmlReaderTool;
        /** Instance of the Translator Tool */
        private readonly ATMLTranslatorToolWindow _atmlTranslatorTool;
        private readonly LogFileController _logFileController;
        /** Instance of the Navigator Object */
        private readonly ATMLNavigator _navigator;
        /** Instance of the Navigator Window */
        private readonly ATMLNavigationWindow _navigatorWindow;
        /** Instance of the Output Window */
        private readonly ATMLOutputWindow _outputWindow;
        /** Instance of the Project Manager object */
        private readonly ProjectManager _projectManager;
        private ATMLAllocator _allocator;
        private DeserializeDockContent _deserializeDockContent;
        /** Instance of the Document Library Screen */
        private DocumentLibraryForm _documentLibraryForm;
        /** Port the HRRP Server utilizes */
        private int _httpPort;
        /** Instance of the HTTP Server - used to serve documents */
        private HttpServer _httpServer;
        /** Instance of the Instrument Library Form */
        private ATMLLibraryForm _instrumentLibrary;
        private ATMLReader _reader;
        private SignalModelLibraryForm _signalModelLibrary;
        /** Instance of the Test Adapter Library Form */
        private ATMLLibraryForm _testAdapterLibrary;
        /** Instance of the Test Station Library Form */
        private ATMLLibraryForm _testStationLibrary;
        /** Instance of the ATML Translator Engine */
        private ATMLTranslator _translator;
        /** Instance of the UUT Library Form */
        private ATMLLibraryForm _uutLibrary;
        /** Instance of the ATML Reader Engine*/

        #endregion

        #region Constructors

        public MainFrame()
        {
            InitializeComponent();

            ATMLContext context = ATMLContext.Instance;
            ATMLContext.APPLICATION_NAME = "ATML Workbench";
            ATMLContext.PropertyChanged += delegate { SetProperties(); };
            _logFileController = new LogFileController();
            LogManager.Info( "{0} is starting... ", ATMLContext.APPLICATION_NAME );

            Load += MainFrame_Load;
            Closed += MainFrame_Closed;
            _httpPort = (int) ATMLContext.GetProperty( "http.port", DEFAULT_PORT );
            btnDocumentServerStart_ButtonClick( this, null );
            menuStrip1.Renderer = new ATMLMenuRenderer();
            toolStrip1.Renderer = new ATMLMenuRenderer();
            projectNavigatorMenuItem.Checked = true;
            outputWindowMenuItem.Checked = true;
            if (!DAO.Valid)
            {
                throw new Exception( "Failed to obtain a database connection." );
            }

            //---------------------------------------------//
            //--- Setup Database Connection Information ---//
            //---------------------------------------------//
            ATMLOptionsForm.LoadContext();
            SetProperties();
            _navigator = ATMLNavigator.Instance;
            _reader = new ATMLReader( _navigator );
            _allocator = ATMLAllocator.Instance;
            _projectManager = ProjectManager.Instance;
            _translator = ATMLTranslator.Instance;
            _translator.SetNavigator( _navigator );

            //-----------------------------------//
            //--- Setup Global Keyboard Hooks ---//
            //-----------------------------------//
            if (_gkh == null)
            {
                //_gkh = GlobalKeyboardHook.GetGlobalKeyboardHook();
                //_gkh.KeyUp += gkh_KeyUp;
                //_gkh.HookedKeys.Add( Keys.Add );
                //_gkh.HookedKeys.Add( Keys.I );
                //_gkh.HookedKeys.Add( Keys.Enter );
            }

            //--------------------------------------------------------------------------------//
            //--- We are handling the mouse commands inside the ATML Preview Panel instead ---//
            //--- of using the globalmouse hook for right now. We'll investigate on        ---//
            //--- expanding the use of a global mouese hook for the selection/paste        ---//
            //--- functionality at a later date.                                           ---//
            //--------------------------------------------------------------------------------//
            /* 
            if (gmh == null)
            {
                gmh = GlobalMouseHook.Instance;
                gmh.Hook();
            }
            gmh.LeftButtonDown += gmh_LeftButtonDown;
            gmh.LeftButtonUp += gmh_LeftButtonUp;
            */


            dockPanel.SuspendLayout( true );

            //---------------------------//
            //--- Setup Output Window ---//
            //---------------------------//
            _outputWindow = new ATMLOutputWindow();
            _outputWindow.Show( dockPanel, DockState.DockBottom );

            //------------------------------//
            //--- Setup Navigator Window ---//
            //------------------------------//
            _navigatorWindow = new ATMLNavigationWindow( _navigator );
            _navigator.SelectATMLDocument += _navigator_SelectATMLDocument;
            _navigator.SelectReaderDocument += _navigator_SelectReaderDocument;
            _navigator.SelectSourceDocument += _navigator_SelectSourceDocument;
            _navigator.SelectATMLUUTDocument += NavigatorOnSelectAtmluutDocument;
            _navigator.SelectATMLTestConfiguration += _navigatorWindow_SelectATMLTestConfiguration;
            _navigator.SelectATMLInstrumentDocument += _navigator_SelectATMLInstrumentDocument;
            _navigator.SelectATMLTestDescriptionDocument += _navigatorWindow_SelectATMLTestDescription;
            _navigator.SelectATMLTestStationDocument += NavigatorOnSelectAtmlTestStationDocument;
            _navigator.SelectATMLTestAdapterDocument += NavigatorOnSelectAtmlTestAdapterDocument;
            _navigator.SelectDocument += _navigator_SelectDocument;
            _navigator.ProjectNameChangeRequested += NavigatorProjectNameChangeRequested;
            _navigatorWindow.Show( dockPanel, DockState.DockLeft );

            //-------------------------------//
            //--- Setup Translator Window ---//
            //-------------------------------//
            _atmlTranslatorTool = new ATMLTranslatorToolWindow( _navigator );
            _atmlTranslatorTool.Show( dockPanel, DockState.Document );
            _atmlTranslatorTool.InitWindows( _outputWindow.Pane );
            _atmlTranslatorTool.RegisterATMLTranslator( _translator );
            _atmlTranslatorTool.VisibleChanged += _atmlTranslatorTool_VisibleChanged;

            _translator.AixmlTranslationCompleted += delegate { SetStatusBarState( false ); };
            _translator.AixmlTranslationStarted += delegate
                                                   {
                                                       lblTranslating.Text = @"Translating AIXML...";
                                                       SetStatusBarState( true );
                                                   };
            _translator.AixmlParseCompleted += delegate { SetStatusBarState( false ); };
            _translator.AixmlParseStarted += delegate
                                             {
                                                 lblTranslating.Text = @"Parsing ATLAS...";
                                                 SetStatusBarState( true );
                                             };

            //---------------------------//
            //--- Setup Reader Window ---//
            //---------------------------//
            _atmlReaderTool = new ATMLReaderToolWindow( _navigator );
            _atmlReaderTool.Show( dockPanel, DockState.Document );
            _atmlReaderTool.InitWindows( _outputWindow.Pane );
            _atmlReaderTool.VisibleChanged += _atmlReaderTool_VisibleChanged;
            _atmlReaderTool.TestConfigurationSaved += AtmlReaderToolOnTestConfigurationSaved;
            _reader.InputDocumentTranslated += ReaderInputDocumentTranslated;
            _atmlReaderTool.RegisterATMLReader( _reader );
            AtmlActionController.Register( _atmlReaderTool );

            //------------------------------//
            //--- Setup Allocator Window ---//
            //------------------------------//
            _atmlAllocatorTool = new ATMLAllocatorToolWindow( dockPanel );
            _atmlAllocatorTool.Show( dockPanel, DockState.Document );
            _atmlAllocatorTool.InitWindows( _navigatorWindow.Pane, _outputWindow.Pane );
            _atmlAllocatorTool.VisibleChanged += _atmlAllocatorTool_VisibleChanged;

            _allocator.SignalAnalysisPerformed += AllocatorOnSignalAnalysisPerformed;


            //---------------------------------------------//
            //--- Assign Project Manager Event Handlers ---//
            //---------------------------------------------//
            _projectManager.ProjectClosed += ProjectClosed;
            _projectManager.ProjectOpened += ProjectOpened;


            TestConfigurationController.Instance.TestConfigurationChanged +=
                delegate { };
            UUTController.Instance.UutChanged += delegate { };

            //----------------------------------------------//
            //--- Assign Document Manager Event Handlers ---//
            //----------------------------------------------//
            DocumentManager.EditUUT +=
                delegate( IDocumentEditor source, Document document, object o, bool completion )
                {
                    UutManager.Instance.Edit( document, o, completion );
                };

            DocumentManager.EditInstrument +=
                delegate( IDocumentEditor source, Document document, object o, bool completion )
                {
                    var form = new InstrumentForm();
                    form.InstrumentDescription = o as InstrumentDescription;
                    if (DialogResult.OK == form.ShowDialog())
                    {
                        source.UpdateContent( form.InstrumentDescription.Serialize() );
                    }
                };

            DocumentManager.EditTestAdapter +=
                delegate( IDocumentEditor source, Document document, object o, bool completion )
                {
                    var form = new TestAdapterForm();
                    form.TestAdapterDescription = o as TestAdapterDescription1;
                    if (DialogResult.OK == form.ShowDialog())
                    {
                        source.UpdateContent( form.TestAdapterDescription.Serialize() );
                    }
                };

            DocumentManager.EditTestStation +=
                delegate( IDocumentEditor source, Document document, object o, bool completion )
                {
                    var form = new TestStationForm();
                    form.TestStationDescription = o as TestStationDescription11;
                    if (DialogResult.OK == form.ShowDialog())
                    {
                        source.UpdateContent( form.TestStationDescription.Serialize() );
                    }
                };

            _deserializeDockContent = GetContentFromPersistString;

            dockPanel.ResumeLayout( true, true );
        }

        private IDockContent GetContentFromPersistString( string persistString )
        {
            if (persistString == typeof (ATMLNavigationWindow).ToString())
                return _navigatorWindow;
            if (persistString == typeof (ATMLTranslatorToolWindow).ToString())
                return _atmlTranslatorTool;
            if (persistString == typeof (ATMLReaderToolWindow).ToString())
                return _atmlReaderTool;
            if (persistString == typeof (ATMLAllocatorToolWindow).ToString())
                return _atmlAllocatorTool;
            if (persistString == typeof (ATMLOutputWindow).ToString())
                return _outputWindow;
            // DummyDoc overrides GetPersistString to add extra information into persistString.
            // Any DockContent may override this value to add any needed information for deserialization.

            string[] parsedStrings = persistString.Split( new[] {','} );
            if (parsedStrings.Length != 3)
                return null;

            if (parsedStrings[0] != typeof (ATMLForm).ToString())
                return null;

            var dummyDoc = new ATMLForm();
            //if (parsedStrings[1] != string.Empty)
            //    dummyDoc.FileName = parsedStrings[1];
            //if (parsedStrings[2] != string.Empty)
            //    dummyDoc.Text = parsedStrings[2];

            return dummyDoc;
        }


        private void SetStatusBarState( bool showStatus )
        {
            if (InvokeRequired)
            {
                SetStatusBarStateCallback d = SetStatusBarState;
                Invoke( d, new object[] {showStatus} );
            }
            else
            {
                lblTranslating.Visible = showStatus;
                translationImage.Visible = showStatus;
                btnCloseProject.Enabled = !showStatus;
                btnDeleteProject.Enabled = !showStatus;
                btnAddProject.Enabled = !showStatus;
                btnExitProject.Enabled = !showStatus;
                btnOpenProject.Enabled = !showStatus;
                btnImportProject.Enabled = !showStatus;
                createNewATMLTPS.Enabled = !showStatus;
                openATMLTPS.Enabled = !showStatus;
                deleteATMLTPS.Enabled = !showStatus;
                importTPAR.Enabled = !showStatus;
                closeProject.Enabled = !showStatus;
            }
        }

        private void AllocatorOnSignalAnalysisPerformed( FileInfo fileInfo, byte[] content )
        {
            OpenDocument( fileInfo, true, false );
        }

        private void MainFrame_Closed( object sender, EventArgs e )
        {
            LogManager.Debug( "Mainframe has closed." );
        }

        private delegate void SetStatusBarStateCallback( bool state );

        #endregion

        #region Library Window State Change Handlers

        private void _uutLibrary_VisibleChanged( object sender, EventArgs e )
        {
            UUTsMenuItem.Checked = _uutLibrary.Visible;
        }

        private void _testStationLibrary_VisibleChanged( object sender, EventArgs e )
        {
            testStationsMenuItem.Checked = _testStationLibrary.Visible;
        }

        private void _instrumentLibrary_VisibleChanged( object sender, EventArgs e )
        {
            instrumentsMenuItem.Checked = _instrumentLibrary.Visible;
        }

        private void _testAdapterLibrary_VisibleChanged( object sender, EventArgs e )
        {
            testAdaptersMenuItem.Checked = _testAdapterLibrary.Visible;
        }

        #endregion

        #region Navigator Methods

        /**
         * Called when a Directory label is renamed in the Navigator.
         */

        private void NavigatorProjectNameChangeRequested( object sender, DirectoryInfo di, string newName,
                                                          EventArgs args )
        {
            if (!ProjectManager.RenameProject( di.Name, newName ))
            {
                var nodeLabelEditEventArgs = args as NodeLabelEditEventArgs;
                if (nodeLabelEditEventArgs != null)
                    nodeLabelEditEventArgs.CancelEdit = true;
            }
        }

        /**
         * Called when an item is selected in the Navigator.
         */

        private void _navigator_SelectDocument( object sender, FileInfo e )
        {
            if (InvokeRequired)
            {
                NavigatorSelectDocumentCallback d = _navigator_SelectDocument;
                Invoke( d, new[] {sender, e} );
            }
            else
            {
                OpenDocument( e );
            }
        }

        private void OpenDocument( FileInfo e, bool closeIfOpen = false, bool createFileWatcher = true )
        {
            if (InvokeRequired)
            {
                OpenDocumentCallback d = OpenDocument;
                Invoke( d, new object[] {e, closeIfOpen, createFileWatcher} );
            }
            else
            {
                bool docAlreadyOpen = false;
                string docName = e.Name;
                DockContentCollection col = dockPanel.Contents;
                foreach (DockContent item in col)
                {
                    if (item.Text != null && item.Text.Equals( docName ))
                    {
                        if (closeIfOpen)
                        {
                            item.Close();
                        }
                        else
                        {
                            docAlreadyOpen = true;
                        }

                        break;
                    }
                }


                if (docAlreadyOpen)
                {
                    LogManager.Warn( "Document {0} is already open.", docName );
                }
                else
                {
                    var form = new ATMLDocumentBaseForm();
                    form.FileInfo = e;
                    form.Show( dockPanel, DockState.Document );
                    form.WatchFile = createFileWatcher;
                    form.Closing += delegate( object sender, CancelEventArgs args )
                                    {
                                        var f = (ATMLDocumentBaseForm) sender;
                                        _openDocumentsList.Remove( f );
                                    };
                    _openDocumentsList.Add( form );
                    var mnuContextMenu = new ContextMenu();
                    form.TabPageContextMenu = mnuContextMenu;
                    var mnuItemNew = new MenuItem();
                    mnuItemNew.Text = @"Close";
                    mnuItemNew.Click += mnuItemNew_Click;
                    mnuContextMenu.MenuItems.Add( mnuItemNew );
                    mnuItemNew.Tag = form;

                    LogManager.Info( "File Opened - File:{0} Size(bytes):{1} Last Updated:{2} {3}",
                                     e.Name,
                                     e.Length,
                                     e.LastWriteTime.ToShortDateString(),
                                     e.LastWriteTime.ToShortTimeString() );
                }
            }
        }

        private void NavigatorOnSelectAtmluutDocument( object sender, FileInfo fileInfo )
        {
            /* Do Nothing Right Now */
        }

        private void NavigatorOnSelectAtmlTestAdapterDocument( object sender, FileInfo fileInfo )
        {
            OpenDocument( fileInfo, dbDocument.DocumentType.TEST_ADAPTER_DESCRIPTION );
        }

        private void NavigatorOnSelectAtmlTestStationDocument( object sender, FileInfo fileInfo )
        {
            OpenDocument( fileInfo, dbDocument.DocumentType.TEST_STATION_DESCRIPTION );
        }

        /**
         * Called when an ATML Instrument Description is selected in the Navigator.
         */

        private void _navigator_SelectATMLInstrumentDocument( object sender, FileInfo e )
        {
            OpenDocument( e, dbDocument.DocumentType.INSTRUMENT_DESCRIPTION );
        }

        /**
         * Called when an ATML Document is seleceted in the Navigator.
         */

        private void _navigator_SelectATMLDocument( object sender, FileInfo e )
        {
        }

        /**
         * Called when a Translator Source Document was selected in the Navigator.
         */

        private void _navigator_SelectSourceDocument( object sender, FileInfo e )
        {
            _atmlTranslatorTool.Activate();
        }

        /**
         * Called when a Reader Document was selected in the Navigator.
         */

        private void _navigator_SelectReaderDocument( object sender, FileInfo e, byte[] data )
        {
            _atmlReaderTool.Activate();
        }

        /**
         * Called when a Test Station Description was selected in the Navigator.
         */

        private void _navigatorWindow_SelectATMLTestStation( object sender, FileInfo e )
        {
        }

        /**
         * Called when a Test Description Document was selected int the Navigator.
         */

        private void _navigatorWindow_SelectATMLTestDescription( object sender, FileInfo e )
        {
            _atmlTranslatorTool.LoadTestDescriptionDocument( e );
        }

        /**
         * Called when a Test Configuration Description was selected in the Navigator.
         */

        private void _navigatorWindow_SelectATMLTestConfiguration( object sender, FileInfo e )
        {
            String f = File.ReadAllText( e.FullName );
            _atmlReaderTool.SetATMLDocumentContent( f );
            _atmlReaderTool.Activate();
        }

        private delegate void NavigatorSelectDocumentCallback( object sender, FileInfo e );

        private delegate void OpenDocumentCallback( FileInfo e,
                                                    bool closeIfOpen = false,
                                                    bool createFileWatcher = true );

        #endregion

        #region Allocator Event Handlers

        /**
         * Called when the Visibility State Changes on the Allocator Tool. Used to Check/Uncheck the
         * appropriate menu item.
         */

        private void _atmlAllocatorTool_VisibleChanged( object sender, EventArgs e )
        {
            allocatorMenuItem.Checked = _atmlAllocatorTool.Visible;
        }

        #endregion

        #region Reader Event Handlers

        /**
         * Called when the Visibility State Changes on the Reader Tool. Used to Check/Uncheck the
         * appropriate menu item.
         */

        private void _atmlReaderTool_VisibleChanged( object sender, EventArgs e )
        {
            readerToolItem.Checked = _atmlReaderTool.Visible;
        }

        /**
         * Called after the Reader Tool has Translated an input document into a Test Configuration Description.
         */

        private void ReaderInputDocumentTranslated( TestConfiguration15 testConfiguration )
        {
            ProjectManager.SaveATMLDocument( _projectManager.CurrentTestProgramSet.TestSetName,
                                             AtmlFileType.AtmlTypeTestConfiguration,
                                             Encoding.UTF8.GetBytes( testConfiguration.Serialize() ) );
            //_navigator.RefreshTree();
            //--- TODO: This should probably be moved to the navigator listening for a Save ATML File Event ---//
            string fileName = _projectManager.CurrentTestProgramSet.TestSetName +
                              ATMLContext.ATML_CONFIG_FILENAME_SUFFIX;
            string fullFileName = Path.Combine( ATMLContext.ProjectAtmlPath, fileName );
            var fi = new FileInfo( fullFileName );
            _navigator.AddAtmlDocument( fi, "atml" );
        }

        /**
         * Called when the user presses the Test Configuration Save Button.
         */

        private void AtmlReaderToolOnTestConfigurationSaved( TestConfiguration15 testConfiguration )
        {
            _atmlTranslatorTool.UpdateProjectInfo();
        }

        #endregion

        #region Translator Event Handlers

        /**
         * Called when the Visibility State Changes on the Translator Tool. Used to Check/Uncheck the
         * appropriate menu item.
         */

        private void _atmlTranslatorTool_VisibleChanged( object sender, EventArgs e )
        {
            translatorMenuItem.Checked = _atmlTranslatorTool.Visible;
        }

        #endregion

        #region Project Event Handlers

        /**
         * Called when the Project Manager Closes a project. This methods
         * Provides a CloseProject command to all the tools windows.
         */

        private void ProjectClosed()
        {
            _navigatorWindow.CloseProject();
            _atmlReaderTool.CloseProject();
            _atmlAllocatorTool.CloseProject();
            _atmlTranslatorTool.CloseProject();
            _outputWindow.CloseProject();
            foreach (ATMLDocumentBaseForm atmlDocumentBaseForm in _openDocumentsList.ToArray())
            {
                atmlDocumentBaseForm.Close();
            }
        }

        /**
         * Called when the Project Manager opens a project.
         */

        private void ProjectOpened( string testProgramSetName )
        {
            _navigatorWindow.TestProgramSetName = testProgramSetName;
            Text = @"ATML Workbench - " + _navigatorWindow.TestProgramSetName;
        }

        /**
         * Called when the Close Project button is clicked.
         */

        private void closeProject_Click( object sender, EventArgs e )
        {
            try
            {
                CloseProject( true );
            }
            catch (Exception err)
            {
                LogManager.Error( err );
            }
        }

        #endregion

        #region Tool Strip Click Event Handlers

        private void btnOpenFile_Click( object sender, EventArgs e )
        {
            try
            {
                byte[] data;
                FileInfo fi;
                if (FileManager.OpenFile( out data, out fi ))
                {
                    _navigator_SelectDocument( this, fi );
                }
            }
            catch (Exception err)
            {
                LogManager.Error( err );
            }
        }

        private void toolStripMenuItem1_Click( object sender, EventArgs e )
        {
            try
            {
            }
            catch (Exception err)
            {
                LogManager.Error( err );
            }
        }

        private void createNewATMLTestProgramSetToolStripMenuItem_Click( object sender, EventArgs e )
        {
            try
            {
                ProjectManager.CreateProject();
            }
            catch (Exception err)
            {
                LogManager.Error( err );
            }
        }

        private void openATMLTPS_Click( object sender, EventArgs e )
        {
            try
            {
                string testProgramSetName = null;
                if (ProjectManager.OpenProject( out testProgramSetName ))
                {
                    //_navigatorWindow.TestProgramSetName = testProgramSetName;
                    //Text = @"ATML Workbench - " + _navigatorWindow.TestProgramSetName;
                }
            }
            catch (Exception err)
            {
                LogManager.Error( err );
            }
        }

        private void deleteATMLTPS_Click( object sender, EventArgs e )
        {
            try
            {
                ProjectManager.DeleteProject();
            }
            catch (Exception err)
            {
                LogManager.Error( err );
            }
        }

        private void importTPAR_Click( object sender, EventArgs e )
        {
            try
            {
                ProjectManager.ImportTestProgramSet();
            }
            catch (Exception err)
            {
                LogManager.Error( err );
            }
        }

        private void exportTPAR_Click( object sender, EventArgs e )
        {
            try
            {
                ProjectManager.ExportTestProgramSet();
            }
            catch (Exception err)
            {
                LogManager.Error( err );
            }
        }

        private void exitToolStripMenuItem_Click( object sender, EventArgs e )
        {
            try
            {
                CloseProject( true );
                if (!ProjectManager.HasOpenProject())
                    Environment.Exit( 0 );
            }
            catch (Exception err)
            {
                LogManager.Error( err );
            }
        }

        #endregion

        #region Project Methods

        private void CloseProject( bool verifyWithUser )
        {
            if (ProjectManager.HasOpenProject())
            {
                Text = @"ATML Workbench";
                string message = string.Format( "Are you sure you want to close project \"{0}\"?",
                                                ProjectManager.ProjectName );

                if (!verifyWithUser || DialogResult.Yes == MessageBox.Show( message,
                                                                            @"V E R I F Y",
                                                                            MessageBoxButtons.YesNo,
                                                                            MessageBoxIcon.Question ))
                {
                    ProjectManager.CloseProject();
                    _navigator.SelectedFile = null;
                    _navigator.SelectedFolder = null;
                }
            }
        }

        #endregion

        #region Mainframe Methods

        private void SetProperties()
        {
            dockPanel.Skin.DockPaneStripSkin.ToolWindowGradient.ActiveCaptionGradient.StartColor =
                (Color) ATMLContext.GetProperty( "environment.visual.tool.active.gr1-color", Color.CornflowerBlue );
            dockPanel.Skin.DockPaneStripSkin.ToolWindowGradient.ActiveCaptionGradient.EndColor =
                (Color) ATMLContext.GetProperty( "environment.visual.tool.active.gr2-color", Color.DarkSlateGray );
            dockPanel.Skin.DockPaneStripSkin.ToolWindowGradient.ActiveCaptionGradient.TextColor =
                (Color) ATMLContext.GetProperty( "environment.visual.tool.active.text-color", Color.White );
            if (_httpServer.IsActive)
                StopHttpServer();
            _httpPort = (int) ATMLContext.GetProperty( "http.port", DEFAULT_PORT );
            StartHttpServer();
        }

        private void OpenDocument( FileInfo e, dbDocument.DocumentType documentType )
        {
            var form = new ATMLDocumentBaseForm();
            form.Document = DocumentManager.GetDocument( e.Name, (int) documentType );
            form.Show( dockPanel, DockState.Document );
        }

        // This utility method creates a ContextMenuStrip control
        // that has four ToolStripMenuItems showing the four 
        // possible combinations of image and check margins.
        internal ContextMenuStrip CreateCheckImageContextMenuStrip()
        {
            // Create a new ContextMenuStrip control.
            var checkImageContextMenuStrip = new ContextMenuStrip();

            // Create a ToolStripMenuItem with a
            // check margin and an image margin.
            var yesCheckYesImage =
                new ToolStripMenuItem( "Check, Image" );
            yesCheckYesImage.Checked = true;
            yesCheckYesImage.Image = CreateSampleBitmap();

            // Create a ToolStripMenuItem with no
            // check margin and with an image margin.
            var noCheckYesImage =
                new ToolStripMenuItem( "No Check, Image" );
            noCheckYesImage.Checked = false;
            noCheckYesImage.Image = CreateSampleBitmap();

            // Create a ToolStripMenuItem with a
            // check margin and without an image margin.
            var yesCheckNoImage =
                new ToolStripMenuItem( "Check, No Image" );
            yesCheckNoImage.Checked = true;

            // Create a ToolStripMenuItem with no
            // check margin and no image margin.
            var noCheckNoImage =
                new ToolStripMenuItem( "No Check, No Image" );
            noCheckNoImage.Checked = false;

            // Add the ToolStripMenuItems to the ContextMenuStrip control.
            checkImageContextMenuStrip.Items.Add( yesCheckYesImage );
            checkImageContextMenuStrip.Items.Add( noCheckYesImage );
            checkImageContextMenuStrip.Items.Add( yesCheckNoImage );
            checkImageContextMenuStrip.Items.Add( noCheckNoImage );

            return checkImageContextMenuStrip;
        }

        internal Bitmap CreateSampleBitmap()
        {
            // The Bitmap is a smiley face.
            var sampleBitmap = new Bitmap( 32, 32 );
            Graphics g = Graphics.FromImage( sampleBitmap );

            using (var p = new Pen( ProfessionalColors.ButtonPressedBorder ))
            {
                // Set the Pen width.
                p.Width = 4;

                // Set up the mouth geometry.
                Point[] curvePoints =
                {
                    new Point( 4, 14 ),
                    new Point( 16, 24 ),
                    new Point( 28, 14 )
                };

                // Draw the mouth.
                g.DrawCurve( p, curvePoints );

                // Draw the eyes.
                g.DrawEllipse( p, new Rectangle( new Point( 7, 4 ), new Size( 3, 3 ) ) );
                g.DrawEllipse( p, new Rectangle( new Point( 22, 4 ), new Size( 3, 3 ) ) );
            }

            return sampleBitmap;
        }

        #endregion

        #region Menu Click Event Handlers

        private void signalsMenuItem_Click( object sender, EventArgs e )
        {
            if (signalsMenuItem.Checked)
            {
                if (_signalModelLibrary == null)
                {
                    _signalModelLibrary = new SignalModelLibraryForm();
                    _signalModelLibrary.Show( dockPanel, DockState.Document );
                }
                else
                {
                    _signalModelLibrary.Show();
                }
            }
            else
            {
                if (_signalModelLibrary != null)
                    _signalModelLibrary.Hide();
            }
        }

        private void mnuItemNew_Click( object sender, EventArgs e )
        {
            var mnuItem = sender as MenuItem;
            if (mnuItem != null)
            {
                var form = mnuItem.Tag as Form;
                if (form != null)
                    form.Close();
            }
        }

        private void optionsMenuItem_Click( object sender, EventArgs e )
        {
            var form = new ATMLOptionsForm();
            form.ShowDialog();
        }

        private void projectNavigatorMenuItem_Click( object sender, EventArgs e )
        {
            if (projectNavigatorMenuItem.Checked)
                _navigatorWindow.Show();
            else
                _navigatorWindow.Hide();
        }

        private void outputWindowMenuItem_Click( object sender, EventArgs e )
        {
            if (outputWindowMenuItem.Checked)
                _outputWindow.Show();
            else
                _outputWindow.Hide();
        }

        private void documentsMenuItem_Click( object sender, EventArgs e )
        {
            if (documentsMenuItem.Checked)
            {
                if (_documentLibraryForm == null)
                {
                    _documentLibraryForm = new DocumentLibraryForm();
                    _documentLibraryForm.Show( dockPanel, DockState.Document );
                }
                _documentLibraryForm.Show();
            }
            else
            {
                if (_documentLibraryForm != null)
                    _documentLibraryForm.Hide();
            }
        }

        private void translatorToolStripMenuItem_Click( object sender, EventArgs e )
        {
            if (translatorMenuItem.Checked)
                _atmlTranslatorTool.Show();
            else
                _atmlTranslatorTool.Hide();
        }

        private void readerToolItem_Click( object sender, EventArgs e )
        {
            if (readerToolItem.Checked)
                _atmlReaderTool.Show();
            else
                _atmlReaderTool.Hide();
        }

        private void allocatorMenuItem_Click( object sender, EventArgs e )
        {
            if (allocatorMenuItem.Checked)
                _atmlAllocatorTool.Show();
            else
                _atmlAllocatorTool.Hide();
        }

        private void instrumentsMenuItem_Click( object sender, EventArgs e )
        {
            if (instrumentsMenuItem.Checked)
            {
                if (_instrumentLibrary == null)
                {
                    _instrumentLibrary = new ATMLLibraryForm( typeof (InstrumentListControl) );
                    _instrumentLibrary.VisibleChanged += _instrumentLibrary_VisibleChanged;
                    _instrumentLibrary.Show( dockPanel, DockState.Document );
                    AtmlActionController.Register( _instrumentLibrary );
                }
                _instrumentLibrary.Show();
            }
            else
            {
                if (_instrumentLibrary != null)
                    _instrumentLibrary.Hide();
            }
        }

        private void testStationsMenuItem_Click( object sender, EventArgs e )
        {
            if (testStationsMenuItem.Checked)
            {
                if (_testStationLibrary == null)
                {
                    _testStationLibrary = new ATMLLibraryForm( typeof (TestStationListControl) );
                    _testStationLibrary.VisibleChanged += _testStationLibrary_VisibleChanged;
                    _testStationLibrary.Show( dockPanel, DockState.Document );
                    AtmlActionController.Register( _testStationLibrary );
                }
                _testStationLibrary.Show();
            }
            else
            {
                if (_testStationLibrary != null)
                    _testStationLibrary.Hide();
            }
        }


        private void testAdaptersMenuItem_Click( object sender, EventArgs e )
        {
            if (testAdaptersMenuItem.Checked)
            {
                if (_testAdapterLibrary == null)
                {
                    _testAdapterLibrary = new ATMLLibraryForm( typeof (TestAdapterListControl) );
                    _testAdapterLibrary.VisibleChanged += _testAdapterLibrary_VisibleChanged;
                    _testAdapterLibrary.Show( dockPanel, DockState.Document );
                    AtmlActionController.Register( _testAdapterLibrary );
                }
                _testAdapterLibrary.Show();
            }
            else
            {
                if (_testAdapterLibrary != null)
                    _testAdapterLibrary.Hide();
            }
        }

        private void UUTsMenuItem_Click( object sender, EventArgs e )
        {
            if (UUTsMenuItem.Checked)
            {
                if (_uutLibrary == null)
                {
                    _uutLibrary = new ATMLLibraryForm( typeof (UUTDescriptionListControl) );
                    _uutLibrary.VisibleChanged += _uutLibrary_VisibleChanged;
                    _uutLibrary.Show( dockPanel, DockState.Document );
                    AtmlActionController.Register( _uutLibrary );
                }
                _uutLibrary.Show();
            }
            else
            {
                if (_uutLibrary != null)
                    _uutLibrary.Hide();
            }
        }

        #endregion

        #region HTTP Server Event Handlers

        private void StopHttpServer()
        {
            _httpServer.Stop();
            _httpServer = null;
            btnDocumentServerStart.Visible = true;
            btnDocumentServerStop.Visible = false;
        }

        private void StartHttpServer()
        {
            try
            {
                if (_httpServer == null)
                {
                    _httpServer = new DocumentServer( _httpPort, this );
                    _httpServer.OnStart += _httpServer_OnStart;
                    _httpServer.OnStop += _httpServer_OnStop;
                    _httpServer.OnError += _httpServer_OnError;
                    //btnStartServer.Text = "Stop Server";
                    var thread = new Thread( _httpServer.listen );
                    thread.Start();
                    //Text = "ATLAS Test Harness - Document Server is Running";
                }
                btnDocumentServerStart.Visible = false;
                btnDocumentServerStop.Visible = true;
            }
            catch (Exception ee)
            {
                SetHttpError(
                    string.Format(
                        "The Local HTTP Service has failed to start on port: {0}, probably due to a permissions setting.",
                        _httpPort ) );
                LogManager.Error( ee );
            }
        }

        private void btnDocumentServerStart_ButtonClick( object sender, EventArgs e )
        {
            StartHttpServer();
        }

        private void btnStopDocumentServer_ButtonClick( object sender, EventArgs e )
        {
            StopHttpServer();
        }

        private void _httpServer_OnStop( object sender )
        {
            try
            {
                lblDocumentServerStatus.Text = @"ATML Document Server - Stopped";
                lblDocumentServerStatus.BackColor = Color.Red;
                lblDocumentServerStatus.ForeColor = Color.Yellow;
                btnDocumentServerStart.Visible = true;
                btnDocumentServerStop.Visible = false;
                Invalidate();
                Update();
            }
            catch (Exception e)
            {
                LogManager.Error( e );
            }
        }

        private void _httpServer_OnError( object sender, string message )
        {
            try
            {
                SetHttpError( message );
                Invalidate();
                Update();
            }
            catch (Exception e)
            {
                LogManager.Error( e );
            }
        }

        private void SetHttpError( string message )
        {
            lblDocumentServerStatus.Text = @"ATML Document Server - ERROR - " + message;
            lblDocumentServerStatus.BackColor = Color.Red;
            lblDocumentServerStatus.ForeColor = Color.Yellow;
            btnDocumentServerStart.Visible = false;
            btnDocumentServerStop.Visible = false;
        }

        private void _httpServer_OnStart( object sender )
        {
            try
            {
                if (InvokeRequired)
                {
                    HttpServerStartCallback d = _httpServer_OnStart;
                    Invoke( d, new[] {sender} );
                }
                else
                {
                    lblDocumentServerStatus.Text = string.Format( "ATML Document Server - Running on port: {0}",
                                                                  _httpPort );
                    lblDocumentServerStatus.BackColor = Color.Green;
                    lblDocumentServerStatus.ForeColor = Color.Yellow;
                    btnDocumentServerStart.Visible = false;
                    btnDocumentServerStop.Visible = true;
                    Invalidate();
                    Update();
                }
            }
            catch (Exception e)
            {
                LogManager.Error( e );
            }
        }

        private delegate void HttpServerStartCallback( object sender );

        #endregion

        #region Mainframe Event Handlers

        private void MainFrame_Load( object sender, EventArgs e )
        {
        }

        private void MainFrame_FormClosing( object sender, FormClosingEventArgs e )
        {
            _httpServer.Stop();
            _httpServer = null;
            //string configFile = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "DockPanel.config");
            //dockPanel.SaveAsXml(configFile);
        }

        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad( e );
            //string configFile = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "DockPanel.config");
            //if (File.Exists(configFile))
            //    dockPanel.LoadFromXml(configFile, _deserializeDockContent);
        }

        private void gkh_KeyUp( object sender, KeyEventArgs e )
        {
            /*
            var command = new StringBuilder(edtCommandBar.Text);
            if (e.Control && e.Alt)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //readerFrame.ProcessCommand( command.ToString());
                    edtCommandBar.Text = "";
                }
                else
                {
                    command.Append(e.KeyCode).Append(" ");
                    edtCommandBar.Text = command.ToString();
                }
            }
             */
        }

        protected override void DestroyHandle()
        {
            CloseProject( false );
            base.DestroyHandle();
        }

        #endregion

        #region SYSTEM MENU

        [DllImport( "user32.dll" )]
        private static extern IntPtr GetSystemMenu( IntPtr hWnd, bool bRevert );

        [DllImport( "user32.dll" )]
        private static extern bool InsertMenu( IntPtr hMenu, Int32 wPosition, Int32 wFlags, Int32 wIDNewItem,
                                               string lpNewItem );

        protected override void WndProc( ref Message msg )
        {
            if (msg.Msg == WM_SYSCOMMAND)
            {
                switch (msg.WParam.ToInt32())
                {
                    case MNU_ABOUT:
                        btnAbout_Click( null, null );
                        return;
                    default:
                        break;
                }
            }
            base.WndProc( ref msg );
        }

        private void MainFrame_Load_1( object sender, EventArgs e )
        {
            IntPtr MenuHandle = GetSystemMenu( Handle, false );
            InsertMenu( MenuHandle, 5, MF_BYPOSITION | MF_SEPARATOR, 0, string.Empty ); // <-- Add a menu seperator
            InsertMenu( MenuHandle, 6, MF_BYPOSITION, MNU_ABOUT, "About" );
        }

        #endregion

        private void btnLogFiles_Click( object sender, EventArgs e )
        {
            string fileName;
            if (_logFileController.OpenLogFile( out fileName ))
            {
                var psi = new ProcessStartInfo( fileName ) {UseShellExecute = true};
                Process.Start( psi );
            }
        }

        private void btnAbout_Click( object sender, EventArgs e )
        {
            Stream streamXml = GetType().Assembly.GetManifestResourceStream( Resources.about_data );
            Stream streamXsl = GetType().Assembly.GetManifestResourceStream( Resources.about_style );
            var form = new ATMLXslTranslationForm( streamXml, streamXsl );
            form.Text = @"About";
            form.ShowDialog();
        }

        private void btnViewHelp_Click( object sender, EventArgs e )
        {
            //C:\Program Files (x86)\ATMLWorkbench\ATML Workbench.chm
            string helpFileName = Path.Combine(
                Environment.GetFolderPath( Environment.SpecialFolder.CommonApplicationData ),
                "UTRS", "ATMLWorkbench", "ATMLWorkbench.chm" );
            string helpUri = "file://" + helpFileName;


            if (File.Exists( helpFileName ))
                Help.ShowHelp( this, helpUri );
            else
                LogManager.Error( "Missing Help File: " + helpFileName );
        }

        private void btnReleaseNotes_Click( object sender, EventArgs e )
        {
            Stream streamXml = GetType().Assembly.GetManifestResourceStream( Resources.release_notes_data );
            Stream streamXsl = GetType().Assembly.GetManifestResourceStream( Resources.release_notes_style );
            var form = new ATMLXslTranslationForm( streamXml, streamXsl );
            form.Text = @"Release Notes";
            form.ShowDialog();
        }

        private void statisticsToolStripMenuItem_Click( object sender, EventArgs e )
        {
        }

        private void dockPanel_ActiveContentChanged( object sender, EventArgs e )
        {
        }

        private void tOOKHelpToolStripMenuItem_Click( object sender, EventArgs e )
        {
            string helpFileName = Path.Combine(
                Environment.GetFolderPath( Environment.SpecialFolder.CommonApplicationData ),
                "UTRS", "ATMLWorkbench", "TOOKHOME.chm" );
            string helpUri = "file://" + helpFileName;

            if (File.Exists( helpFileName ))
                Help.ShowHelp( this, helpUri );
            else
                LogManager.Error( "Missing Help File: " + helpFileName );
        }


        private void gmh_LeftButtonDown( object sender, MouseEventArgs e )
        {
            Console.WriteLine( "Left Mouse Down" );
            Control control = UTRSFormUtilities.GetVisibleChildUnderMouse( this );
            if (control != null)
            {
                Point pt = PointToClient( e.Location );
                Rectangle client = control.ClientRectangle;
                //client.Location = pt;
                Rectangle screen = RectangleToScreen( client );
                Console.WriteLine( "Client Point {0}", pt );
                Console.WriteLine( "Client {0}", client );
                Console.WriteLine( "Screen {0}", screen );
                Console.WriteLine( "Mouse 1 {0}", e.Location );
                Console.WriteLine( "Mouse 2 {0}", MousePosition );

                if (screen.Contains( e.Location ))
                {
                    _beginSelection = true;
                    Console.WriteLine( "Begin Selection" );
                }
            }
        }


        private void gmh_LeftButtonUp( object sender, MouseEventArgs e )
        {
            Console.WriteLine( "Left Mouse Up" );
            ProcessCopyPaste( sender, e );
        }

        private void ProcessCopyPaste( object sender, MouseEventArgs e )
        {
            Control control = UTRSFormUtilities.GetVisibleChildUnderMouse( this );
            if (control != null && ( control.Focused && _beginSelection ))
            {
                _beginSelection = false;
                Console.WriteLine( "End Selection" );
                Control activeControl = FormManager.LastActiveControl;
                if (activeControl is TextBox)
                {
                    if (control.Visible)
                    {
                        var webBrowser = control as WebBrowser;
                        var textBox = control as TextBox;
                        var editor = control as AWBEditor;
                        if (webBrowser != null)
                        {
                            if (webBrowser.Document != null)
                            {
                                var htmlDocument = webBrowser.Document.DomDocument as IHTMLDocument2;
                                if (htmlDocument != null)
                                {
                                    IHTMLSelectionObject currentSelection = htmlDocument.selection;
                                    if (currentSelection != null)
                                    {
                                        var range = currentSelection.createRange() as IHTMLTxtRange;
                                        if (range != null)
                                            activeControl.Text = range.text;
                                    }
                                }
                            }
                        }
                        if (editor != null)
                        {
                            LogManager.Trace( "Source Previewer is Visible: |{0}|", editor.Selection );

                            if (editor.Selection != null && !String.IsNullOrEmpty( ( editor.Selection.Text ) ))
                            {
                                activeControl.Text = editor.Selection.Text;
                            }
                        }
                        if (textBox != null)
                        {
                            LogManager.Trace( "Source Previewer is Visible: |{0}|", textBox.SelectedText );

                            if (textBox.SelectedText != null && !String.IsNullOrEmpty( ( textBox.SelectedText ) ))
                            {
                                activeControl.Text = textBox.SelectedText;
                            }
                        }
                    }
                }
            }
        }

        private void testApplicationScriptToolStripMenuItem_Click( object sender, EventArgs e )
        {
            Document xmlDocument = DocumentManager.GetDocumentByName( "test-script.xml" );
            Document xslDocument1 = DocumentManager.GetDocumentByName( "test-script-ids.xsl" );
            Document xslDocument2 = DocumentManager.GetDocumentByName( "test-script-form.xsl" );
            //--- Assign Ids to original XML ---//
            string xmlWithIds = XmlUtils.Transform( xslDocument1.DocumentContent, xmlDocument.DocumentContent );
            var form = new ATMLXslTranslationForm( Encoding.UTF8.GetBytes( xmlWithIds ), xslDocument2.DocumentContent );
            form.Text = @"Test";
            form.Closed += delegate
                           {
                               if (ProjectManager.HasOpenProject())
                                   FileManager.WriteFile( Path.Combine( ATMLContext.ProjectReportPath,
                                                                        ATMLContext.CurrentProjectName + ".html" ),
                                                          form.TranslatedData );
                           };
            form.Show();
        }

        private void aTLASStatisticsToolStripMenuItem_Click( object sender, EventArgs e )
        {
            try
            {
                string aixmlPath = ATMLContext.ProjectTranslatorAixmlPath;
                string fileName = Path.Combine( aixmlPath,
                                                ProjectManager.ProjectName + ATMLContext.AIXML_FILENAME_SUFFIX );
                if (FileManager.FileExists( fileName ))
                {
                    var atlasDocument = new XmlDocument();
                    byte[] xmlData = FileManager.ReadFile( fileName );
                    Document xslDocument = DocumentManager.GetDocumentByName( "atlas_statistics.xsl" );
                    if( xslDocument == null )
                        throw new Exception(string.Format("Missing ATLAS Statistics XSLT document \"{0}\" ", "atlas_statistics.xsl" ));
                    //--- Assign Ids to original XML ---//
                    atlasDocument.LoadXml( Encoding.UTF8.GetString( xmlData ) );
                    XmlElement root = atlasDocument.DocumentElement;
                    XmlElement signalMap = atlasDocument.CreateElement( "signal-mapping" );
                    root.AppendChild( signalMap );

                    var signalMappingDao = new SignalMappingDAO();
                    List<SourceSignalMapBean> sourceSignals = signalMappingDao.GetSourceSignals( "ATLAS" );
                    foreach (SourceSignalMapBean sourceSignalMapBean in sourceSignals)
                    {
                        string signalId = sourceSignalMapBean.id.ToString();
                        string sourceName = sourceSignalMapBean.sourceName;
                        string sourceType = sourceSignalMapBean.sourceType;
                        string targetName = sourceSignalMapBean.targetName;
                        string targetType = sourceSignalMapBean.targetType;
                        XmlElement signal = atlasDocument.CreateElement( "signal" );
                        signal.SetAttribute( "id", signalId );
                        signal.SetAttribute( "sourceName", sourceName );
                        signal.SetAttribute( "sourceType", sourceType );
                        signal.SetAttribute( "targetName", targetName );
                        signal.SetAttribute( "targetType", targetType );
                        signalMap.AppendChild( signal );
                        List<SourceSignalAttributeMapBean> attributes =
                            signalMappingDao.GetSignalAttributes( sourceSignalMapBean.id );
                        foreach (SourceSignalAttributeMapBean sourceSignalAttributeMapBean in attributes)
                        {
                            string attSourceName = sourceSignalAttributeMapBean.sourceName;
                            string attSourceType = sourceSignalAttributeMapBean.sourceType;
                            string attSourceDefault = sourceSignalAttributeMapBean.sourceDefault;
                            string attSourceSuffix = sourceSignalAttributeMapBean.sourceSuffix;
                            string attSourceUnit = sourceSignalAttributeMapBean.sourceUnit;
                            string attTargetName = sourceSignalAttributeMapBean.targetName;
                            string attTargetType = sourceSignalAttributeMapBean.targetType;
                            string attTargetDefault = sourceSignalAttributeMapBean.targetDefault;
                            string attTargetQualifier = sourceSignalAttributeMapBean.targetQualifier;
                            string attTargetUnit = sourceSignalAttributeMapBean.targetUnit;
                            string attId = sourceSignalAttributeMapBean.ID.ToString();

                            XmlElement signalAttribute = atlasDocument.CreateElement( "attribute" );
                            signalAttribute.SetAttribute( "id", attId );
                            signalAttribute.SetAttribute( "sourceName", attSourceName );
                            signalAttribute.SetAttribute( "sourceType", attSourceType );
                            signalAttribute.SetAttribute( "sourceDefault", attSourceDefault );
                            signalAttribute.SetAttribute( "sourceSuffix", attSourceSuffix );
                            signalAttribute.SetAttribute( "sourceUnit", attSourceUnit );
                            signalAttribute.SetAttribute( "targetName", attTargetName );
                            signalAttribute.SetAttribute( "targetType", attTargetType );
                            signalAttribute.SetAttribute( "targetDefault", attTargetDefault );
                            signalAttribute.SetAttribute( "targetQualifier", attTargetQualifier );
                            signalAttribute.SetAttribute( "targetUnit", attTargetUnit );
                            signal.AppendChild( signalAttribute );
                        }
                    }

                    var form = new ATMLXslTranslationForm( Encoding.UTF8.GetBytes( atlasDocument.InnerXml ),
                                                           xslDocument.DocumentContent );
                    form.Text = @"ATLAS Statistics";
                    form.Closed += delegate
                                   {
                                       if (ProjectManager.HasOpenProject())
                                           FileManager.WriteFile(
                                               Path.Combine( ATMLContext.ProjectReportPath, "atlas-statistics.html" ),
                                               form.TranslatedData );
                                   };
                    form.Show();
                }
            }
            catch (Exception err)
            {
                LogManager.Error( err );
            }
            finally
            {
            }
        }

        private void procedureHierarchyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string aixmlPath = ATMLContext.ProjectTranslatorAixmlPath;
            string fileName = Path.Combine( aixmlPath,
                                            ProjectManager.ProjectName + ATMLContext.AIXML_HIER_FILENAME_SUFFIX );
            try
            {
                if (!FileManager.FileExists( fileName ))
                    throw new Exception( string.Format( "Missing Procedure Hierarchy Source File: {0}", fileName ) );
                Document xslDocument = DocumentManager.GetDocumentByName("procedure-flow.xsl");
                if( xslDocument == null)
                    throw new Exception( string.Format( "Missing Procedure Hierarchy Translation File:: {0}", "procedure-flow.xsl" ) );
                byte[] xmlData = FileManager.ReadFile(fileName);
                var form = new ATMLXslTranslationForm(xmlData,xslDocument.DocumentContent);
                form.Text = @"ATLAS Procedure Hierarchy";
                form.Closed += delegate
                {
                    if (ProjectManager.HasOpenProject())
                        FileManager.WriteFile(
                            Path.Combine(ATMLContext.ProjectReportPath, "atlas-procedure-flow.html"),
                            form.TranslatedData);
                };
                form.Show();
            }
            catch (Exception err )
            {
                LogManager.Error( err );
            }

        }

        private void importMessagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageManager.ImportMessages();
        }

        private void exportMessagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageManager.ExportMessages();
        }


        //---------------------------------------------------------//
        //--- All Field Objects Required by the MainFrame class ---//
        //---------------------------------------------------------//

        //----------------------------------------------------------------------//
        //--- Standard Constructors used to instantiate a MainFrame instance ---//
        //----------------------------------------------------------------------//

        //-----------------------------------------------------------//
        //--- Methods used to handle Library object state changes ---//
        //-----------------------------------------------------------//

        //-------------------------//
        //--- NAVIGATOR METHODS ---//
        //-------------------------//

        //------------------------------------------------------//
        //--- Allocator Tool Specific Event Handling Methods ---//
        //------------------------------------------------------//

        //---------------------------------------------------//
        //--- Reader Tool Specific Event Handling Methods ---//
        //---------------------------------------------------//

        //-------------------------------------------------------//
        //--- Translator Tool Specific Event Handling Methods ---//
        //-------------------------------------------------------//

        //---------------------------------------------------------//
        //--- Project (Manager) Specific Event Handling Methods ---//
        //---------------------------------------------------------//

        //----------------------------------------------//
        //--- Tool Bar Button Event Handling Methods ---//
        //----------------------------------------------//

        //------------------------------------------//
        //--- Project (Manager) Specific Methods ---//
        //------------------------------------------//

        //----------------------------------//
        //--- Mainframe Specific Methods ---//
        //----------------------------------//

        //---------------------------------//
        //--- Menu Click Event Handlers ---//
        //---------------------------------//

        //----------------------------------//
        //--- HTTP Server Event Handlers ---//
        //----------------------------------//

        //--------------------------------//
        //--- Mainframe Event Handlers ---//
        //--------------------------------//

        //---------------------------//
        //--- System Menu Entries ---//
        //---------------------------//
    }
}