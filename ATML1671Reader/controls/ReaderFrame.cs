/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using ATML1671Reader;
using ATML1671Reader.reader;
using ATMLCommonLibrary;
using ATMLCommonLibrary.forms;
using ATMLCommonLibrary.model;
using ATMLModelLibrary.model.common;

namespace UTRS1671Reader.controls
{
    public delegate void ParseDocumentDelegate();
    public delegate void OpenReaderDocumentDelegate();

    public partial class ReaderFrame : UserControl, ITestConfigurationChangeListener, ICommandProcessor, IATMLDockableWindow
    {

        public event ParseDocumentDelegate ParseDocument;
        public event OpenReaderDocumentDelegate OpenReaderDocument;

        public ReaderFrame()
        {
            InitializeComponent();

            btnNavBack.Enabled = false;
            btnNavForward.Enabled = false;
            inputDocumentPreviewPanel.WebDocumentLoaded += inputDocumentPreviewPanel_WebDocumentLoaded;
            SetButtonStates();
        }

        public void CloseProject()
        {
            inputDocumentPreviewPanel.Clear();
            lblInputDocument.Text = @"Input Document";
        }

        public void ProcessCommand(string command)
        {
            if (command.Contains("Add I"))
            {
                var form = new InstrumentForm();
                form.Show();
            }
        }

        public void OnTestConfigurationChange()
        {
            Trace.WriteLine("Test Configuration Change");
        }

        protected virtual void OnOpenReaderDocument()
        {
            OpenReaderDocumentDelegate handler = OpenReaderDocument;
            if (handler != null) handler();
        }

        protected virtual void OnParseDocument()
        {
            ParseDocumentDelegate handler = ParseDocument;
            if (handler != null) handler();
        }

        public void RegisterATMLReader(ATMLReader reader)
        {
            reader.OpenInputDocument += reader_OpenInputDocument;
            reader.ParseableInputDocument += reader_ParseableInputDocument;
            reader.InputDocumentTranslated += ReaderInputDocumentTranslated;
            reader.NavigableInputDocument += _reader_NavigatableInputDocument;
            reader.BeginOpenDocument += _reader_BeginOpenDocument;
        }


        private void inputDocumentPreviewPanel_WebDocumentLoaded(WebBrowser webBrowser)
        {
            btnNavBack.Enabled = webBrowser.CanGoBack;
            btnNavForward.Enabled = webBrowser.CanGoForward;
        }


        private void _reader_BeginOpenDocument()
        {
            btnNavBack.Visible = false;
            btnNavForward.Visible = false;
            btnParseInputDocument.Visible = false;
        }

        private void _reader_NavigatableInputDocument()
        {
            btnNavBack.Visible = true;
            btnNavForward.Visible = true;
        }

        private void ReaderInputDocumentTranslated(TestConfiguration15 testConfiguration)
        {
        }

        private void reader_ParseableInputDocument()
        {
            btnParseInputDocument.Visible = true;
        }

        private void reader_OpenInputDocument(FileInfo fileInfo, byte[] content)
        {
            inputDocumentPreviewPanel.Open(fileInfo, content);
            lblInputDocument.Text = fileInfo.Name;
            SetButtonStates();
            
        }

        private void btnParseInputDocument_Click(object sender, EventArgs e)
        {
            OnParseDocument();
        }

        private void SetButtonStates()
        {
        }

        public void SetReaderDocumentContent(FileInfo fileInfo, byte[] content)
        {
            inputDocumentPreviewPanel.Open(fileInfo, content);
            lblInputDocument.Text = fileInfo.Name;
            SetButtonStates();
        }


        private void btnOpenInputDocument_Click(object sender, EventArgs e)
        {
            OnOpenReaderDocument();
        }

        private void btnNavBack_Click(object sender, EventArgs e)
        {
            inputDocumentPreviewPanel.Back();
        }

        private void btnNavForward_Click(object sender, EventArgs e)
        {
            inputDocumentPreviewPanel.Forward();
        }
    }
}