/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.IO;
using System.Windows.Forms;
using ATML1671Reader.controls;
using ATML1671Reader.reader;
using ATMLCommonLibrary.model;
using ATMLCommonLibrary.model.navigator;
using ATMLManagerLibrary.delegates;
using ATMLManagerLibrary.interfaces;
using ATMLModelLibrary.interfaces;
using ATMLModelLibrary.model.common;
using WeifenLuo.WinFormsUI.Docking;

namespace ATML1671Reader.forms
{
    public partial class ATMLReaderToolWindow : DockContent, IATMLDockableWindow, IATMLReaderConsumer, IAtmlActionable
    {
        private readonly TestConfigurationForm _configurationForm;
        private readonly ATMLReaderOutputWindow _readerOutputWindow;
        private IReaderNavigator _navigator;
        private ATMLReader _reader;

        public ATMLReaderToolWindow( IReaderNavigator navigator )
        {
            InitializeComponent();
            _navigator = navigator;
            _readerOutputWindow = new ATMLReaderOutputWindow();
            _configurationForm = new TestConfigurationForm();

            readerFrameControl.ParseDocument += ReaderFrameParseDocument;
            readerFrameControl.OpenReaderDocument += ReaderFrameOpenReaderDocument;

            _configurationForm.TestConfigurationSaved += _configurationForm_TestConfigurationSaved;
            _navigator.SelectATMLTestConfiguration += _navigator_SelectATMLTestConfiguration;
            _navigator.SelectReaderDocument += _navigator_SelectReaderDocument;
            _readerOutputWindow.DocumentSaved += _readerOutputWindow_DocumentSaved;

            _configurationForm.AtmlObjectAction += _configurationForm_AtmlObjectAction;

            //_configurationForm.AtmlUutAction += new AtmlActionDeligate<UUTDescription>(_configurationForm_AtmlUutAction);
            //_configurationForm.AtmlTestConfigurationAction += new AtmlActionDeligate<TestConfiguration15>(_configurationForm_AtmlTestConfigurationAction);
        }
        public event AtmlActionDeligate<IAtmlObject> AtmlObjectAction;

        public void CloseProject()
        {
            readerFrameControl.CloseProject();
            _configurationForm.CloseProject();
            _readerOutputWindow.CloseProject();
        }

        public void RegisterATMLReader( ATMLReader reader )
        {
            _reader = reader;
            _reader.OpenInputDocument += _reader_OpenInputDocument;
            _reader.ParseableInputDocument += _reader_ParseableInputDocument;
            _reader.NavigableInputDocument += _reader_NavigableInputDocument;
            _reader.BeginOpenDocument += _reader_BeginOpenDocument;
            _configurationForm.RegisterATMLReader( _reader );
            readerFrameControl.RegisterATMLReader( _reader );
            _readerOutputWindow.RegisterATMLReader( reader );
        }
        public event TestConfigurationSaveHandler TestConfigurationSaved;


        protected override bool ProcessCmdKey( ref Message msg, Keys keyData )
        {
            if (keyData == ( Keys.Control | Keys.F4 ))
            {
                Console.Beep();
                return true;
            }
            return base.ProcessCmdKey( ref msg, keyData );
        }

        protected virtual void OnTestConfigurationSaved( TestConfiguration15 testconfiguration )
        {
            TestConfigurationSaveHandler handler = TestConfigurationSaved;
            if (handler != null) handler( testconfiguration );
        }

        private IAtmlObject _configurationForm_AtmlObjectAction( IAtmlObject obj, AtmlActionType actionType,
                                                                 EventArgs args )
        {
            OnAtmlObjectAction( obj, actionType, args );
            return obj;
        }

        //private TestConfiguration15 _configurationForm_AtmlTestConfigurationAction(TestConfiguration15 obj,
        //    AtmlActionType actionType, EventArgs args)
        // {
        //     return obj;
        // }

        //private TestConfiguration15 _configurationForm_AtmlAction(TestConfiguration15 obj, AtmlActionType actionType,
        //    EventArgs args)
        // {
        //    OnAtmlAction(obj, actionType, args);
        //   return obj;
        //}

        //private UUTDescription _configurationForm_AtmlUutAction(UUTDescription obj, AtmlActionType actionType,
        //    EventArgs args)
        // {
        //OnAtmlAction(obj, actionType, args);
        //     OnAtmlObjectAction(obj, actionType, args);
        //     return obj;
        // }

        private void _readerOutputWindow_DocumentSaved( FileInfo fileInfo, byte[] content )
        {
            _configurationForm.LoadTestConfiguration( fileInfo, content );
        }

        private void _configurationForm_TestConfigurationSaved( TestConfiguration15 testConfiguration )
        {
            OnTestConfigurationSaved( testConfiguration );
        }

        private void _navigator_SelectReaderDocument( object sender, FileInfo e, byte[] data )
        {
            readerFrameControl.SetReaderDocumentContent( e, data );
        }

        private void _navigator_OpenReaderDocument( object sender, FileInfo e, byte[] data )
        {
        }

        private void _navigator_SelectATMLTestConfiguration( object sender, FileInfo e )
        {
        }

        private void ReaderFrameOpenReaderDocument()
        {
            _reader.OpenReaderDocument();
        }

        private void ReaderFrameParseDocument()
        {
            if (_reader != null)
            {
                Cursor = Cursors.WaitCursor;
                _reader.TranslateInputDocument();
                Cursor = Cursors.Default;
            }
        }

        public void InitWindows( DockPane outputPane )
        {
            _readerOutputWindow.Show( outputPane, DockAlignment.Right, .50 );
            _configurationForm.Show( DockPanel, DockState.DockRight );
        }


        private void _reader_BeginOpenDocument()
        {
        }

        private void _reader_NavigableInputDocument()
        {
        }

        private void _reader_ParseableInputDocument()
        {
        }

        private void _reader_OpenInputDocument( FileInfo fileInfo, byte[] content )
        {
        }

        public void SetATMLDocumentContent( String atmlContent )
        {
            //readerFrameControl.ATML(atmlContent);
        }

        public void SetReaderDocumentContent( FileInfo fileInfo, byte[] content )
        {
        }

        private void readerFrame1_Load( object sender, EventArgs e )
        {
        }

        private void ATMLReaderToolWindow_Activated( object sender, EventArgs e )
        {
            if (_readerOutputWindow.DockState != DockState.Document
                && _readerOutputWindow.DockState != DockState.Float)
                _readerOutputWindow.Show();
            if (_configurationForm.DockState != DockState.Float)
                _configurationForm.Show();
        }

        private void ATMLReaderToolWindow_Deactivate( object sender, EventArgs e )
        {
            if (_readerOutputWindow.DockState != DockState.Document
                && _readerOutputWindow.DockState != DockState.Float)
                _readerOutputWindow.Hide();
            if (_configurationForm.DockState != DockState.Float)
                _configurationForm.Hide();
        }

        protected virtual IAtmlObject OnAtmlObjectAction( IAtmlObject obj, AtmlActionType actiontype, EventArgs args )
        {
            AtmlActionDeligate<IAtmlObject> handler = AtmlObjectAction;
            if (handler != null)
                obj = handler( obj, actiontype, args );
            return obj;
        }
    }
}