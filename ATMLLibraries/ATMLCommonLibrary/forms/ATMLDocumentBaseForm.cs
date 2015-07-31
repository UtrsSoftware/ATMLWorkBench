/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using ATMLCommonLibrary.controls;
using ATMLCommonLibrary.model;
using ATMLManagerLibrary.delegates;
using ATMLManagerLibrary.managers;
using ATMLModelLibrary.model.test;
using ScintillaNET;
using WeifenLuo.WinFormsUI.Docking;
using Document = ATMLModelLibrary.model.common.Document;

namespace ATMLCommonLibrary.forms
{

    public partial class ATMLDocumentBaseForm : DockContent, IATMLDockableWindow
    {
        private Document _document;
        private FileInfo _fileInfo;
        private FileSystemWatcher _fileWatcher;
        private bool _watchFile;
        private bool _allowSave = true;
        private bool _isXmlDocument = false;
        public event EventHandler CaretPosChanged;

        public ATMLDocumentBaseForm()
        {
            InitializeComponent();
            atmlPreviewPanel.SourceDocumentLoaded += atmlPreviewPanel_SourceDocumentLoaded;
            atmlPreviewPanel.XmlDocumentLoaded += atmlPreviewPanel_XmlDocumentLoaded;
            atmlPreviewPanel.AtlasDocumentLoaded+=AtmlPreviewPanelOnAtlasDocumentLoaded;
            atmlPreviewPanel.SourceDocumentLoaded+=AtmlPreviewPanelOnSourceDocumentLoaded;
            atmlPreviewPanel.WebDocumentLoaded += atmlPreviewPanel_WebDocumentLoaded;
            atmlPreviewPanel.PreviewDocumentLoaded+=AtmlPreviewPanelOnPreviewDocumentLoaded;
            atmlPreviewPanel.ScintillaUIEvent+= delegate
                                                {
                                                    ATMLDocumentEventArgs a = new ATMLDocumentEventArgs();
                                                    a.CaretPos = atmlPreviewPanel.CurrentCaretPosition();
                                                    OnCaretPosChanged(a);
                                                };
            if (btnWordWrap.Checked)
                if (btnWordWrap.Checked)
                btnWordWrap.BackColor = Color.AliceBlue;
            else
                btnWordWrap.BackColor = Color.Transparent;

        }



        protected virtual void OnCaretPosChanged(ATMLDocumentEventArgs args)
        {
            EventHandler handler = CaretPosChanged;
            if (handler != null) handler(this, args);
        }

        private void AtmlPreviewPanelOnSourceDocumentLoaded( object sender, EventArgs eventArgs )
        {
            OnSourceDocumentLoaded();
        }

        private void AtmlPreviewPanelOnAtlasDocumentLoaded( object sender, EventArgs eventArgs )
        {
            OnAtlasDocumentLoaded();
        }

        private void AtmlPreviewPanelOnPreviewDocumentLoaded( object sender, EventArgs eventArgs )
        {
           btnWordWrap.Visible 
               = btnCollapseAll.Visible 
               = btnExpandAll.Visible 
               = btnSave.Visible 
               = btnBack.Visible 
               = btnForward.Visible 
               = btnPrint.Visible
               = false;
        }

        public event EventHandler XmlDocumentLoaded;
        public event EventHandler AtlasDocumentLoaded;
        public event EventHandler SourceDocumentLoaded;

        protected virtual void OnSourceDocumentLoaded()
        {
            EventHandler handler = SourceDocumentLoaded;
            if (handler != null) handler( this, EventArgs.Empty );
        }

        protected virtual void OnXmlDocumentLoaded()
        {
            EventHandler handler = XmlDocumentLoaded;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        protected virtual void OnAtlasDocumentLoaded()
        {
            EventHandler handler = AtlasDocumentLoaded;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        public Document Document
        {
            get { return _document; }
            set
            {
                _document = value;
                if (_document != null)
                {
                    atmlPreviewPanel.Open(_document);
                    Text = _document.name;
                }
            }
        }

        public FileInfo FileInfo
        {
            get { return _fileInfo; }
            set
            {
                _fileInfo = value;
                using (var fs = File.Open(_fileInfo.FullName, FileMode.Open, FileAccess.Read, FileShare.Read ) )
                {
                    var data = new byte[fs.Length];
                    fs.Read(data, 0, data.Length);
                    atmlPreviewPanel.Open(_fileInfo, data);
                    Text = _fileInfo.Name;
                }
            }
        }

        public String Content
        {
            get { return atmlPreviewPanel.Text; }
            set
            {
                int curPos = atmlPreviewPanel.CurrentPos;
                atmlPreviewPanel.Text = value; 
                btnPrint.Visible = btnForward.Visible = btnBack.Visible = atmlPreviewPanel.IsWebDocument;
                
                atmlPreviewPanel.CurrentPos = curPos;
            }
        }

        public bool WatchFile
        {
            get { return _fileWatcher != null; }
            set
            {
                if (_fileInfo == null )
                    throw new InvalidOperationException("FileInfo has not been set");
                if (value )
                    CreateDocumentWatcher(_fileInfo.DirectoryName, _fileInfo.Name);
                else
                    ReleaseDocumentWatcher();
            }
        }

        public bool AllowSave
        {
            get { return _allowSave; }
            set 
            { 
                _allowSave = value;
                btnSave.Visible = false;
            }
        }

        public bool IsXmlDocument
        {
            get { return _isXmlDocument; }
            set { _isXmlDocument = value; if( _isXmlDocument ) this.atmlPreviewPanel_XmlDocumentLoaded(); }
        }

        public virtual void CloseProject()
        {
            atmlPreviewPanel.Clear();
            _document = null;
        }

        public event FileSavedDelegate DocumentSaved;

        protected virtual void OnDocumentSaved(FileInfo fileInfo, byte[] content)
        {
            FileSavedDelegate handler = DocumentSaved;
            if (handler != null) handler(fileInfo, content);
        }

        protected override void DestroyHandle()
        {
            base.DestroyHandle();
        }

        protected override void OnClosed(EventArgs e)
        {
            atmlPreviewPanel.Clear();
            ReleaseDocumentWatcher();
            base.OnClosed(e);
        }

        protected void ReleaseDocumentWatcher()
        {
            if (_fileWatcher != null)
                _fileWatcher.EnableRaisingEvents = false;
            _fileWatcher = null;
        }

        protected void CreateDocumentWatcher(string documentPath, string documentName)
        {
            LogManager.Debug("Creating Document Watcher Created for {0}\\{1}", documentPath, documentName);
            if (!string.IsNullOrWhiteSpace(documentPath))
            {
                if (_fileWatcher == null)
                    _fileWatcher = new FileSystemWatcher();
                _fileWatcher.Path = documentPath;
                _fileWatcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName |
                                            NotifyFilters.DirectoryName;
                // Only watch for the loaded document.
                _fileWatcher.Filter = documentName;
                _fileWatcher.Changed += _fileWatcher_Changed;
                _fileWatcher.Created += _fileWatcher_Changed;
                _fileWatcher.Error+=delegate( object sender, ErrorEventArgs args ) { LogManager.Error( args.GetException() ); };
                _fileWatcher.EnableRaisingEvents = true;
                LogManager.Debug("Document Watcher Created for {0}\\{1}", documentPath, documentName);
            }
        }

        private delegate void FileWatcherChangedCallback( object sender, FileSystemEventArgs e );
        private void _fileWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            try
            {
                LogManager.Debug("Document Change Detected for {0}", e.FullPath);
                if (InvokeRequired)
                {
                    FileWatcherChangedCallback d = _fileWatcher_Changed;
                    Invoke( d, new[] {sender, e} );
                }
                else
                {
                    atmlPreviewPanel.Text = "";
                    LoadFile( e.FullPath );
                }
            }
            catch (Exception err )
            {
                LogManager.Error( err );
            }
        }

        protected void LoadFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                FileInfo fi;
                byte[] data;
                try
                {
                    data = FileManager.ReadFile(fileName, out fi);
                }
                catch (Exception)
                {
                    Thread.Sleep( 1000 );
                    data = FileManager.ReadFile(fileName, out fi);
                }
                
                if (data.Length > 0)
                {
                    atmlPreviewPanel.Text = Encoding.UTF8.GetString(data);
                }
            }
        }

        private void atmlPreviewPanel_XmlDocumentLoaded()
        {
            btnCollapseAll.Visible = true;
            btnExpandAll.Visible = true;
            btnFind.Visible = true;
            btnWordWrap.Visible = true;
            btnSave.Visible = true;
            btnPrint.Visible = true;
            btnBack.Visible = false;
            btnForward.Visible = false;
            OnXmlDocumentLoaded();
        }

        private void atmlPreviewPanel_WebDocumentLoaded(WebBrowser webBrowser)
        {
            btnSave.Visible = false;
            btnBack.Visible = true;
            btnPrint.Visible = true;
            btnExportDocument.Visible = false;
            btnForward.Visible = true;
            btnBack.Enabled = atmlPreviewPanel.CanGoBack;
            btnForward.Enabled = atmlPreviewPanel.CanGoForward;
        }

        private void atmlPreviewPanel_SourceDocumentLoaded(object sender, EventArgs e)
        {
            btnFind.Visible = true;
            btnPrint.Visible = true;
            btnExportDocument.Visible = true;
            btnBack.Visible = false;
            btnForward.Visible = false;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            atmlPreviewPanel.Find();
        }

        private void btnExpandAll_Click(object sender, EventArgs e)
        {
            atmlPreviewPanel.ExpandAll();
        }

        private void btnCollapseAll_Click(object sender, EventArgs e)
        {
            atmlPreviewPanel.CollapseAll();
        }

        private void btnWordWrap_Click(object sender, EventArgs e)
        {
            atmlPreviewPanel.ToggleWordWrap();
            btnWordWrap.Checked = atmlPreviewPanel.IsWordWrap;
            if (btnWordWrap.Checked)
                btnWordWrap.BackColor = Color.AliceBlue;
            else
                btnWordWrap.BackColor = Color.Transparent;
        }

        /**
         * Called when the Save/OK button is pressed. This will save the
         * document contents to a file using the information provided in 
         * the FileInfo class.
         */
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_fileInfo != null && _allowSave )
            {
                _fileWatcher.EnableRaisingEvents = false;
                byte[] data = Encoding.UTF8.GetBytes(atmlPreviewPanel.Text);
                var fs = new FileStream(_fileInfo.FullName, FileMode.Truncate, FileAccess.Write);
                using (fs)
                {
                    //-------------------------------------------------------//
                    //--- Determine if the document is an XML document    ---//
                    //--- If it is we'll load an XDocument with the       ---//
                    //--- text and set some basic formatting instructions ---//
                    //--- and writing the value back out to the preview   ---//
                    //--- window. This is done only for text formatting   ---//
                    //--- purposes.                                       ---//
                    //-------------------------------------------------------//
                    if (atmlPreviewPanel.Text.StartsWith("<?xml"))
                    {
                        string text = atmlPreviewPanel.Text.Trim();
                        using (var ms = new MemoryStream())
                        {
                            string byteOrderMarkUtf8 = Encoding.UTF8.GetString( Encoding.UTF8.GetPreamble() );
                            if (text.StartsWith( byteOrderMarkUtf8 ))
                                text = text.Remove( 0, byteOrderMarkUtf8.Length );
                            XDocument document = XDocument.Parse( text );
                            //------------------------------------------------------------------------------------//
                            //--- Set Basic Formatting Information - make sure the XML Declaration is included ---//
                            //------------------------------------------------------------------------------------//
                            var settings = new XmlWriterSettings();
                            settings.OmitXmlDeclaration = false;
                            settings.Indent = true;
                            settings.NewLineOnAttributes = false;
                            settings.CloseOutput = true;
                            try
                            {
                                using (XmlWriter xmlWriter = XmlWriter.Create( ms, settings ))
                                {
                                    int line = atmlPreviewPanel.CurrentPos;
                                    document.Save( xmlWriter );
                                    xmlWriter.Flush();
                                    data = ms.ToArray();
                                    atmlPreviewPanel.Text = Encoding.UTF8.GetString( data );
                                    atmlPreviewPanel.CurrentPos = line;
                                }
                            }
                            catch (Exception)
                            {
                                LogManager.Error( "An error has occurred attempting to cleanup the XML file formatting." );
                            }
                        }
                    }
                    fs.Write(data, 0, data.Length);
                    fs.Close();
                    _fileWatcher.EnableRaisingEvents = true;
                    OnDocumentSaved(_fileInfo, data);
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            atmlPreviewPanel.Back();
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            atmlPreviewPanel.Forward();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            atmlPreviewPanel.Print();
        }

        public void CollapseAll()
        {
            atmlPreviewPanel.CollapseAll();
        }

        public void ExpandAll()
        {
            atmlPreviewPanel.ExpandAll();
        }

        private void btnExportDocument_Click(object sender, EventArgs e)
        {
            string fileName = this.Text;
            string documentDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string data = atmlPreviewPanel.Text;
            if (!string.IsNullOrWhiteSpace( data ))
                FileManager.WriteFile(Encoding.UTF8.GetBytes(data), Path.Combine(documentDir, fileName));
        }

    }

    public class ATMLDocumentEventArgs : EventArgs
    {
        public Point CaretPos { set; get; }
    }


}