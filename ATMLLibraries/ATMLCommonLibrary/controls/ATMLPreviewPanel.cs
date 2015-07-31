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
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Windows.Forms;
using ATMLCommonLibrary.managers;
using ATMLCommonLibrary.utils;
using ATMLManagerLibrary.managers;
using ATMLUtilitiesLibrary;
using Microsoft.Win32;
using mshtml;
using ScintillaNET;
using Document = ATMLModelLibrary.model.common.Document;
using STATSTG = System.Runtime.InteropServices.ComTypes.STATSTG;

namespace ATMLCommonLibrary.controls
{
    public delegate void WebDocumentLoadedDelegate( WebBrowser webBrowser );

    public delegate void SourceDoucumentLoadedDelegate();

    public delegate void XmlDocumentLoadedDelegate();

    public partial class ATMLPreviewPanel : ATMLControl
    {
        private bool _beginSelection;
        private byte[] _content;
        private string _fileExtension;
        private string _fileName;
        private bool _isAssigned = false;
        private object _officePreviewInstance;
        private int cookie = -1;
        private IConnectionPoint icp;

        public ATMLPreviewPanel()
        {
            InitializeComponent();
            webBrowser.DocumentCompleted += WebBrowserDocumentCompleted;
            sourcePreviewer.Show();
            webBrowser.Show();
            InitEditor();

            sourcePreviewer.NativeInterface.UpdateUI +=
                delegate( object sender, NativeScintillaEventArgs args ) { OnScintillaUiEvent( args ); };

            //this.previewPanel

            //GlobalMouseHook.Instance.LeftButtonUp += new MouseEventHandler(Instance_LeftButtonUp);
        }

        public int CurrentPos
        {
            set
            {
                if (sourcePreviewer.Visible)
                {
                    sourcePreviewer.CurrentPos = value;
                }
            }
            get
            {
                int line = 0;
                if (sourcePreviewer.Visible)
                    line = sourcePreviewer.CurrentPos;
                return line;
            }
        }

        public bool IsOfficePreviewDocument
        {
            get { return _officePreviewInstance != null; }
        }

        public bool Modified
        {
            get { return sourcePreviewer.Modified; }
            set { sourcePreviewer.Modified = value; }
        }

        public bool ReadOnly
        {
            get
            {
                bool readOnly = false;
                if (webBrowser.Visible && webBrowser.Document != null)
                {
                    var doc = (IHTMLDocument2) webBrowser.Document.DomDocument;
                    readOnly = "On".Equals( doc.designMode );
                }
                else if (sourcePreviewer.Visible)
                {
                    readOnly = sourcePreviewer.IsReadOnly;
                }
                return readOnly;
            }
            set
            {
                if (webBrowser.Visible && webBrowser.Document != null)
                {
                    var doc = (IHTMLDocument2) webBrowser.Document.DomDocument;
                    doc.designMode = value ? "On" : "Off";
                }
                else if (sourcePreviewer.Visible)
                {
                    sourcePreviewer.IsReadOnly = value;
                }
            }
        }

        public override string Text
        {
            get { return sourcePreviewer.Text; }
            set
            {
                bool priorState = sourcePreviewer.IsReadOnly;
                sourcePreviewer.IsReadOnly = false;
                sourcePreviewer.Text = value;
                sourcePreviewer.IsReadOnly = priorState;
                sourcePreviewer.Invalidate();
                sourcePreviewer.Update();
                if (!string.IsNullOrWhiteSpace( value ))
                {
                    sourcePreviewer.Visible = true;
                    webBrowser.Visible = false;
                    previewPanel.Visible = false;
                }
            }
        }

        public bool IsWordWrap
        {
            get { return sourcePreviewer.IsWordWrap; }
        }

        public bool CanGoBack
        {
            get { return webBrowser.CanGoBack; }
        }

        public bool CanGoForward
        {
            get { return webBrowser.CanGoForward; }
        }

        public bool IsWebDocument
        {
            get { return webBrowser.Visible; }
        }

        public bool IsXmlDocument
        {
            get { return sourcePreviewer.Visible; }
        }

        public Point CurrentCaretPosition()
        {
            int col = sourcePreviewer.GetColumn( sourcePreviewer.CurrentPos );
            int row = sourcePreviewer.Lines.FromPosition( sourcePreviewer.CurrentPos ).Number;
            return new Point( row + 1, col + 1 );
        }

        public event EventHandler ScintillaUIEvent;

        protected virtual void OnScintillaUiEvent( NativeScintillaEventArgs args )
        {
            EventHandler handler = ScintillaUIEvent;
            if (handler != null) handler( this, args );
        }

        public void Print()
        {
            if (webBrowser.Visible)
                webBrowser.ShowPrintPreviewDialog();
            else if (sourcePreviewer.Visible)
                sourcePreviewer.Printing.PrintPreview();
        }

        protected override void DestroyHandle()
        {
            Clear();
            base.DestroyHandle();
        }

        protected override void CreateHandle()
        {
            base.CreateHandle();
            //Redocking this window causes the handle to be destroyed and recreated
            if (_content != null)
            {
                Open( _fileName, _fileExtension, _content );
            }
        }

        public void InitForXML()
        {
            sourcePreviewer.InitForXML();
        }

        public void InitForATLAS()
        {
            sourcePreviewer.InitForATLAS();
        }

        public void InitForText()
        {
            sourcePreviewer.InitForText();
        }

        public event XmlDocumentLoadedDelegate XmlDocumentLoaded;
        public event WebDocumentLoadedDelegate WebDocumentLoaded;
        public event EventHandler SourceDocumentLoaded;
        public event EventHandler AtlasDocumentLoaded;

        protected virtual void OnSourceDocumentLoaded()
        {
            EventHandler handler = SourceDocumentLoaded;
            if (handler != null) handler( this, EventArgs.Empty );
        }

        protected virtual void OnAtlasDocumentLoaded()
        {
            EventHandler handler = AtlasDocumentLoaded;
            if (handler != null) handler( this, EventArgs.Empty );
        }

        protected virtual void OnXmlDocumentLoaded()
        {
            XmlDocumentLoadedDelegate handler = XmlDocumentLoaded;
            if (handler != null) handler();
        }

        public event EventHandler PreviewDocumentLoaded;

        protected virtual void OnPreviewDocumentLoaded()
        {
            EventHandler handler = PreviewDocumentLoaded;
            if (handler != null) handler( this, EventArgs.Empty );
        }


        private void InitEditor()
        {
            sourcePreviewer.ConfigurationManager.Language = "xml";
            sourcePreviewer.IsReadOnly = false;
            sourcePreviewer.Lexing.Lexer = Lexer.Xml;
            sourcePreviewer.Folding.IsEnabled = true;
            sourcePreviewer.MatchBraces = true;
            sourcePreviewer.IsBraceMatching = true;
            sourcePreviewer.Lexing.SetProperty( "fold", "1" );
            sourcePreviewer.Lexing.SetProperty( "fold.html", "1" );
            sourcePreviewer.UndoRedo.EmptyUndoBuffer();
            sourcePreviewer.Modified = false;
        }

        private void WebBrowserDocumentCompleted( object sender, WebBrowserDocumentCompletedEventArgs e )
        {
            if (webBrowser.Document != null)
            {
                webBrowser.Document.MouseDown += delegate { _beginSelection = true; };
                webBrowser.Document.MouseUp += delegate
                                               {
                                                   if (ModifierKeys.HasFlag( Keys.Control ))
                                                   {
                                                       ProcessPasteFromWebBrowser();
                                                   }
                                               };
                OnWebDocumentLoaded();
            }
        }

        private void ProcessPasteFromWebBrowser()
        {
            if (_beginSelection)
            {
                _beginSelection = false;
                var activeControl = FormManager.LastActiveControl as TextBox;
                if (activeControl != null && webBrowser.Document != null)
                {
                    var htmlDocument = webBrowser.Document.DomDocument as IHTMLDocument2;
                    if (htmlDocument != null)
                    {
                        IHTMLSelectionObject currentSelection = htmlDocument.selection;
                        if (currentSelection != null)
                        {
                            var range = currentSelection.createRange() as IHTMLTxtRange;
                            if (range != null)
                                activeControl.SelectedText = range.text;
                        }
                    }
                }
            }
        }

        protected virtual void OnWebDocumentLoaded()
        {
            WebDocumentLoadedDelegate handler = WebDocumentLoaded;
            if (handler != null) handler( webBrowser );
        }

        public void Clear()
        {
            UnloadPreview();
            webBrowser.DocumentText = "";
            sourcePreviewer.Text = "";
            sourcePreviewer.Visible = false;
            webBrowser.Visible = true;
            _officePreviewInstance = null;
            sourcePreviewer.Modified = false;
            InitEditor();
        }

        public void Find()
        {
            if (sourcePreviewer.Visible)
                sourcePreviewer.Select();
            SendKeys.Send( "^f" );
        }

        public void Back()
        {
            if (webBrowser.Visible)
            {
                webBrowser.GoBack();
            }
        }

        public void Forward()
        {
            if (webBrowser.Visible)
            {
                webBrowser.GoForward();
            }
        }

        public void Open( FileInfo fileInfo, byte[] content )
        {
            Open( fileInfo.FullName, fileInfo.Extension, content );
        }

        public void Open( Document document )
        {
            if (document != null && !string.IsNullOrEmpty( document.name ))
            {
                int idx = document.name.LastIndexOf( '.' );
                string ext = idx == -1 ? ".txt" : document.name.Substring( idx );
                Open( document.name, ext, document.DocumentContent );
            }
            else
            {
                LogManager.Error( "Missing Document or Document Name" );
            }
        }

        public void Open( string fileName, string fileExtension, byte[] content )
        {
            _fileExtension = fileExtension;
            _fileName = fileName;
            _content = content;

            var encoding = new UTF8Encoding();

            const String sMSG_NOPREVIEW =
                "<h3 style=\"color:red;\" >Preview reader is unavailable for this file type.</h3>";
            const String sMSG_CANNOT_PREVIEW = "<h3 style=\"color:red;\" >Unable to preview this document.</h3>";
            const String sMSG_NO_LOCAL =
                "<h3 style=\"color:red;\" >You must have a local copy of this file to preview it.</h3>";
            //Need to use active document

            //String extension = fi.Extension.ToLower().Trim();
            var sourceTypes = (String) ATMLContext.GetProperty( "environment.source.filetypes" );
            var browserTypes = (String) ATMLContext.GetProperty( "environment.browser.filetypes" );
            var supportedTypes = (String) ATMLContext.GetProperty( "environment.supported.filetypes" );
            try
            {
                //if( string.IsNullOrEmpty( sourceTypes ) || )


                string extension = fileExtension.ToLower();
                if (!supportedTypes.Contains( extension ))
                {
                    PreviewHtml(
                        encoding.GetBytes( sMSG_NOPREVIEW + "<br />" + extension +
                                           " file types are not supported at this time." ) );
                }
                else
                {
                    String tempFileName = fileName;

                    if (sourceTypes.Contains( extension ))
                    {
                        sourcePreviewer.ConfigurationManager.Language = extension.Substring( 1 );
                        PreviewSource( encoding.GetString( content ), extension );
                    }
                    else
                    {
                        if (webBrowser.Document != null)
                        {
                            webBrowser.Document.OpenNew( true );
                        }
                        webBrowser.Navigate( "about:blank" );

                        try
                        {
                            using (new HourGlass())
                            {
                                Guid guid = GetPreviewHandlerGUID( fileName );
                                if (browserTypes.Contains( extension ))
                                    PreviewHtml( tempFileName );
                                else if (UTRSOfficeUtils.IsInstalled( UTRSOfficeUtils.MSOfficeApplications.Word )
                                         && UTRSOfficeUtils.IsWordDocument( extension ))
                                    PreviewHtml( UTRSOfficeUtils.OfficeDocToHtml( fileName,
                                                                                  UTRSOfficeUtils.MSOfficeApplications
                                                                                                 .Word ) );
                                else if (UTRSOfficeUtils.IsInstalled( UTRSOfficeUtils.MSOfficeApplications.Excel )
                                         && UTRSOfficeUtils.IsExcelDocument( extension ))
                                    PreviewHtml( UTRSOfficeUtils.OfficeDocToHtml( fileName,
                                                                                  UTRSOfficeUtils.MSOfficeApplications
                                                                                                 .Excel ) );
                                else if (UTRSOfficeUtils.IsInstalled( UTRSOfficeUtils.MSOfficeApplications.PowerPoint )
                                         && UTRSOfficeUtils.IsPowerPointDocument( extension ))
                                    PreviewHtml( UTRSOfficeUtils.OfficeDocToHtml( fileName,
                                                                                  UTRSOfficeUtils.MSOfficeApplications
                                                                                                 .PowerPoint ) );
                                else if (guid != Guid.Empty)
                                    PreView( guid, tempFileName );
                                else
                                {
                                    PreviewHtml(
                                        encoding.GetBytes( sMSG_NOPREVIEW +
                                                           "<br />Could not find a preview handler for " +
                                                           extension ) );
                                }
                            }
                        }
                        catch (Exception ee)
                        {
                            LogManager.Error( ee, sMSG_CANNOT_PREVIEW );
                            PreviewHtml(
                                encoding.GetBytes( sMSG_CANNOT_PREVIEW +
                                                   "<br />An error has occurred attempting to preview this document: <br />" +
                                                   ee.Message ) );
                        }
                    }
                }
            }
            catch (Exception e)
            {
                LogManager.Error( e, "Failed to open preview for file {0} ", fileName );
                LogManager.Debug(
                    "Error opening Preview. Data Dump:\n File Name: {0}{1}\nSource Types:{2}\nBrowser Types:{3}\nSupported Type:{4}\nStack Trace:\n{5}",
                    fileName, fileExtension, sourceTypes, browserTypes, supportedTypes, e.StackTrace );
            }
            Cursor = Cursors.Default;
        }


        public void ExpandAll()
        {
            if (sourcePreviewer.Visible)
            {
                //string key = ATMLPleaseWait.Show(string.Format("Expanding {0} lines of code ", sourcePreviewer.Lines.Count));
                sourcePreviewer.UnfoldAll();
                //ATMLPleaseWait.Hide(key);
            }
        }

        public void CollapseAll()
        {
            if (sourcePreviewer.Visible)
            {
                //string key = ATMLPleaseWait.Show(string.Format("Collapsing {0} lines of code ", sourcePreviewer.Lines.Count));
                sourcePreviewer.FoldAll();
                //ATMLPleaseWait.Hide(key);
            }
        }

        public void ToggleWordWrap()
        {
            if (sourcePreviewer.Visible)
            {
                sourcePreviewer.ToggleWordWrap();
            }
        }

        private void PreviewHtml( Uri file )
        {
            webBrowser.Url = file;
            previewPanel.Visible = false;
            sourcePreviewer.Visible = false;
            webBrowser.Visible = true;
        }

        private void PreviewHtml( String file )
        {
            webBrowser.Url = new Uri( file );
            previewPanel.Visible = false;
            sourcePreviewer.Visible = false;
            webBrowser.Visible = true;
        }


        private void PreviewHtml( byte[] content )
        {
            webBrowser.DocumentStream = new MemoryStream( content );
            previewPanel.Visible = false;
            sourcePreviewer.Visible = false;
            webBrowser.Visible = true;
        }

        private void PreviewSource( String content, String extension )
        {
            sourcePreviewer.IsReadOnly = false;
            sourcePreviewer.Text = content;
            previewPanel.Visible = false;
            webBrowser.Visible = false;
            sourcePreviewer.Visible = true;
            InitForText();
            OnSourceDocumentLoaded();
            if (extension.EndsWith( ".xml" ))
            {
                InitForXML();
                OnXmlDocumentLoaded();
            }
            if (extension.EndsWith( ".as" ) || extension.EndsWith( ".atl" ))
            {
                InitForATLAS();
                OnAtlasDocumentLoaded();
            }
        }

        private Guid GetPreviewHandlerGUID( string filename )
        {
            RegistryKey ext = Registry.ClassesRoot.OpenSubKey( Path.GetExtension( filename ) );
            if (ext != null)
            {
                RegistryKey test = ext.OpenSubKey( "shellex\\{8895b1c6-b41f-4c1c-a562-0d564250836f}" );
                if (test != null) return new Guid( Convert.ToString( test.GetValue( null ) ) );

                string className = Convert.ToString( ext.GetValue( null ) );
                if (className != null)
                {
                    test =
                        Registry.ClassesRoot.OpenSubKey( className + "\\shellex\\{8895b1c6-b41f-4c1c-a562-0d564250836f}" );
                    if (test != null) return new Guid( Convert.ToString( test.GetValue( null ) ) );
                }
            }
            return Guid.Empty;
        }


        private void PreView( Guid guid, string fileName )
        {
            var encoding = new UTF8Encoding();
            webBrowser.Visible = false;
            sourcePreviewer.Visible = false;

            var fi = new FileInfo( fileName );
            if (fi.Length == 0)
            {
                PreviewHtml( encoding.GetBytes( "" ) );
                return;
            }

            UnloadPreview();

            //get type by clsid
            Type previewerType = Type.GetTypeFromCLSID( guid );

            //create instance
            _officePreviewInstance = Activator.CreateInstance( previewerType );

            var ows = (IObjectWithSite) _officePreviewInstance;
            var ph = (IPreviewHandler) _officePreviewInstance;
            var iwf = _officePreviewInstance as IInitializeWithFile;
            var iws = _officePreviewInstance as IInitializeWithStream;

            //now we need to initialize the object
            if (iws != null)
            {
                var ms = new MemoryStream( _content );
                var stream = new StreamWrapper( ms ); //File.Open(fileName, FileMode.Open));
                iws.Initialize( stream, 0 );
            }
            else if (iwf != null)
            {
                iwf.Initialize( fileName, 0 );
            }
            else
            {
                throw new Exception( string.Format(
                    "Failed to locate an initialization interface for document type {0}", previewerType.FullName ) );
            }

            //set the current form (implements IPreviewHandlerFrame)
            ows.SetSite( this );
            previewPanel.Visible = true;

            //set size
            var rect = new RECT();
            rect.left = 0;
            rect.top = 0;
            rect.bottom = previewPanel.Height;
            rect.right = previewPanel.Width;

            ph.SetWindow( previewPanel.Handle, ref rect );
            ph.SetRect( ref rect );

            //perform the preview
            ph.DoPreview();
            ph.SetFocus();
            OnPreviewDocumentLoaded();
        }

        private void previewPanel_Resize( object sender, EventArgs e )
        {
            if (_officePreviewInstance is IPreviewHandler)
            {
                //Rectangle rect = previewPanel.ClientRectangle;
                try
                {
                    var rect = new RECT();
                    rect.left = 0;
                    rect.top = 0;
                    rect.right = previewPanel.Width;
                    rect.bottom = previewPanel.Height;
                    ( (IPreviewHandler) _officePreviewInstance ).SetRect( ref rect );
                }
                catch (Exception err)
                {
                    LogManager.Debug( err );
                }
            }
        }


        public void UnloadPreview()
        {
            if (_officePreviewInstance != null)
            {
                ( (IPreviewHandler) _officePreviewInstance ).Unload();
                Marshal.FinalReleaseComObject( _officePreviewInstance );
                _officePreviewInstance = null;
                GC.Collect();
            }
        }


        private void sourcePreviewer_KeyUp( object sender, KeyEventArgs e )
        {
        }

        private void sourcePreviewer_MouseUp( object sender, MouseEventArgs e )
        {
            if (ModifierKeys.HasFlag( Keys.Control ))
            {
                var activeControl = FormManager.LastActiveControl as TextBox;
                if (activeControl != null && !activeControl.IsDisposed)
                {
                    if (sourcePreviewer.Selection != null && !String.IsNullOrEmpty( ( sourcePreviewer.Selection.Text ) ))
                    {
                        activeControl.SelectedText = sourcePreviewer.Selection.Text;
                    }
                }
            }
        }

        private void Instance_LeftButtonUp( object sender, MouseEventArgs e )
        {
        }
    }

    internal class StreamWrapper : IStream
    {
        private Stream stream;

        public StreamWrapper( Stream stream )
        {
            this.stream = stream;
        }

        #region IStream Members

        public void Clone( out IStream ppstm )
        {
            ppstm = null;
        }

        public void Commit( int grfCommitFlags )
        {
        }

        public void CopyTo( IStream pstm, long cb, IntPtr pcbRead, IntPtr pcbWritten )
        {
        }

        public void LockRegion( long libOffset, long cb, int dwLockType )
        {
        }

        public void Read( byte[] pv, int cb, IntPtr pcbRead )
        {
            int actual = stream.Read( pv, 0, cb );
            Marshal.WriteInt32( pcbRead, actual );
        }

        public void Revert()
        {
        }

        public void Seek( long dlibMove, int dwOrigin, IntPtr plibNewPosition )
        {
            long actual = stream.Seek( dlibMove, (SeekOrigin) dwOrigin );
        }

        public void SetSize( long libNewSize )
        {
        }

        public void Stat( out STATSTG pstatstg, int grfStatFlag )
        {
            pstatstg = new STATSTG();
        }

        public void UnlockRegion( long libOffset, long cb, int dwLockType )
        {
        }

        public void Write( byte[] pv, int cb, IntPtr pcbWritten )
        {
        }

        #endregion

        ~StreamWrapper()
        {
            if (stream != null)
            {
                stream.Close();
                stream.Dispose();
                stream = null;
            }
        }
    }
}

[ComImport, InterfaceType( ComInterfaceType.InterfaceIsIUnknown ), Guid( "8895b1c6-b41f-4c1c-a562-0d564250836f" )]
internal interface IPreviewHandler
{
    void SetWindow( IntPtr hwnd, ref RECT rect );
    void SetRect( ref RECT rect );
    void DoPreview();
    void Unload();
    void SetFocus();
    void QueryFocus( out IntPtr phwnd );

    [PreserveSig]
    uint TranslateAccelerator( ref MSG pmsg );
}

[ComImport, InterfaceType( ComInterfaceType.InterfaceIsIUnknown ), Guid( "b7d14566-0509-4cce-a71f-0a554233bd9b" )]
internal interface IInitializeWithFile
{
    void Initialize( [MarshalAs( UnmanagedType.LPWStr )] string pszFilePath, uint grfMode );
}

[ComImport, InterfaceType( ComInterfaceType.InterfaceIsIUnknown ), Guid( "b824b49d-22ac-4161-ac8a-9916e8fa3f7f" )]
internal interface IInitializeWithStream
{
    void Initialize( IStream pstream, uint grfMode );
}

[StructLayout( LayoutKind.Sequential )]
internal struct RECT
{
    public int left;
    public int top;
    public int right;
    public int bottom;

    public Rectangle ToRectangle()
    {
        return Rectangle.FromLTRB( left, top, right, bottom );
    }
}

[StructLayout( LayoutKind.Sequential )]
internal struct MSG
{
    public IntPtr hwnd;
    public int message;
    public IntPtr wParam;
    public IntPtr lParam;
    public int time;
    public int pt_x;
    public int pt_y;
}

[ComImport, InterfaceType( ComInterfaceType.InterfaceIsIUnknown ), Guid( "fc4801a3-2ba9-11cf-a229-00aa003d7352" )]
public interface IObjectWithSite
{
    void SetSite( [In, MarshalAs( UnmanagedType.IUnknown )] object pUnkSite );
    void GetSite( ref Guid riid, [MarshalAs( UnmanagedType.IUnknown )] out object ppvSite );
}