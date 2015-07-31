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
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using ATMLCommonLibrary.controls.awb;
using ATMLCommonLibrary.model;
using ATMLCommonLibrary.Properties;
using ATMLManagerLibrary.managers;
using mshtml;
using WeifenLuo.WinFormsUI.Docking;
using WebBrowser = System.Windows.Controls.WebBrowser;

namespace ATMLCommonLibrary.forms
{
    /**
     * The ATMLOutputWindow class displays all log messages to the user in a dockable window. By
     * default the output windo will be docked at the bottom of the ATML Workbench IDE. Each of the 4 
     * log message types are supported and their messages color coded. Error messages will be displayed
     * in red, Warn messages in brown, Info messages in blue and trace messages in black. A tool bar is
     * also included with the output window providing functionality to search for text within the messages,
     * clear the message window and to provide word wrap functionality.
     */
    public partial class ATMLOutputWindow : DockContent, IATMLDockableWindow
    {
        public const string TEMPLATE =
            "<html><head><script>window.onload=toBottom;function toBottom() {{ window.scrollTo(0, document.body.scrollHeight); }}</script><style>body{{ font-family:Verdana,sans-serif;font-size:8pt;}} table, th, td {{font-family:Verdana,sans-serif;font-size:8pt;}}</style></head><body>{0}</body></html>";

        private const string LINE_TEMPLATE =
            "<div style=\"display:table; block; width:100%;\"><div style=\"display:table-cell; float:left;width:35px;\">{0}</div><div style=\"display:table-cell;float:left;width:70px;\">{1:HH:mm:ss}</div><div style=\"display:table-cell;float:left;\">{2}</div></div>";

        private const string STACK_TRACE_TEMPLATE =
            "<div style=\"color:red; margin-top:0px;font-family: monospace; \">{0}</div>";

        private const string INFO_TEMPLATE  = "<span style=\"color:blue;\">{0}</span>";
        private const string WARN_TEMPLATE  = "<span style=\"color:brown;\">{0}</span>";
        private const string ERROR_TEMPLATE = "<span style=\"color:red; font-weight:bold; \">{0}</span>";

        private const string ERR = "ERR";
        private const string WRN = "WRN";
        private const string INF = "INF";
        private const string TRC = "TRC";
        private readonly WebBrowser _defaulBrowser;

        /**
         * Default constructor for an ATMLOutputWindow object
         */

        public ATMLOutputWindow()
        {
            InitializeComponent();
            LogManager.Instance.OnTrace += AtmlOutputWindowOnTrace;
            LogManager.Instance.OnError += ATMLOutputWindow_OnError;
            LogManager.Instance.OnInfo += ATMLOutputWindow_OnInfo;
            LogManager.Instance.OnWarn += ATMLOutputWindow_OnWarn;
            elementHost1.Child = _defaulBrowser = new WebBrowser();
        }

        public void CloseProject()
        {
        }


        private WebBrowser GetActiveBrowser( object source )
        {
            WebBrowser activeBrowser = null;
            this.UIThreadInvoke( delegate
                                 {
                                     activeBrowser = elementHost1.Child as WebBrowser;
                                     var tab = source as string;
                                     if (string.IsNullOrEmpty( tab ))
                                     {
                                         tabControl.SelectTab( tabControl.TabPages[0] );
                                     }
                                     else
                                     {
                                         TabPage selectedPage = null;
                                         foreach (TabPage tabPage in tabControl.TabPages)
                                         {
                                             if (tabPage.Text.Equals( tab ))
                                             {
                                                 selectedPage = tabPage;
                                                 break;
                                             }
                                         }
                                         if (selectedPage == null)
                                         {
                                             selectedPage = new TabPage( tab );
                                             tabControl.TabPages.Add( selectedPage );
                                             var output = new WebBrowser();
                                             var elementHost = new ElementHost();
                                             elementHost.Dock = DockStyle.Fill;
                                             elementHost.Location = new Point( 3, 3 );
                                             elementHost.MinimumSize = new Size( 20, 20 );
                                             elementHost.Name = "output" + tabControl.TabPages.Count;
                                             elementHost.Size = new Size( 704, 155 );
                                             elementHost.TabIndex = 1;
                                             elementHost.Child = output;
                                             selectedPage.Controls.Add( elementHost );
                                         }
                                         tabControl.SelectTab( selectedPage );
                                         var host = selectedPage.Controls[0] as ElementHost;
                                         if (host != null)
                                             activeBrowser = host.Child as WebBrowser;
                                     }
                                 } );
            return activeBrowser;
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

        /**
         * Called when the log mananger encounters an error message.
         */

        private void ATMLOutputWindow_OnError( string message, string stackTrace, object source = null )
        {
            var outputText = new StringBuilder();
            message = message.Trim();
            if (message.Equals( Resources.CRLF ))
                message = "";
            if (!message.Contains( Resources.HTML_BR ))
                message = message.Replace( Resources.CRLF, Resources.HTML_BR );
            outputText.Append( string.Format( ERROR_TEMPLATE, message ) );
            if (stackTrace != null)
            {
                outputText.Append( string.Format( STACK_TRACE_TEMPLATE, stackTrace ) );
            }
            WriteOutputText( ERR, outputText.ToString(), GetActiveBrowser( source ) );
        }

        /**
         * Called when the log mananger encounters an information message.
         */

        private void ATMLOutputWindow_OnInfo( string message, object source = null )
        {
            var outputText = new StringBuilder();
            message = message.Replace( Resources.CRLF, Resources.HTML_BR );
            outputText
                .Append( string.Format( INFO_TEMPLATE, message ) )
                .Append( Resources.HTML_BR );
            WriteOutputText( INF, outputText.ToString(), GetActiveBrowser( source ) );
        }

        /**
         * Called when the log mananger encounters an warning message.
         */

        private void ATMLOutputWindow_OnWarn( string message, object source = null )
        {
            var outputText = new StringBuilder();
            message = message.Replace( Resources.CRLF, Resources.HTML_BR );
            outputText
                .Append( string.Format( WARN_TEMPLATE, message ) )
                .Append( Resources.HTML_BR );
            WriteOutputText( WRN, outputText.ToString(), GetActiveBrowser( source ) );
        }

        /**
         * Called when the log mananger encounters an trace message.
         */

        private void AtmlOutputWindowOnTrace( string message, object source = null )
        {
            var outputText = new StringBuilder();
            outputText.Append( message ).Append( Resources.HTML_BR );
            WriteOutputText( TRC, outputText.ToString(), GetActiveBrowser( source ) );
        }

        /**
         * Called when the output window encounters an clear window event.
         */

        private void btnClear_Click( object sender, EventArgs e )
        {
            ClearBrowsers();
        }

        private void ClearBrowsers()
        {
            foreach (TabPage tabPage in tabControl.TabPages)
            {
                WebBrowser browser = GetActiveBrowser( tabPage.Text );
                ClearOutputBrowser( browser );
            }
        }

        private void ClearOutputBrowser( WebBrowser browser )
        {
            if (browser != null)
            {
                browser.NavigateToString( string.Format( TEMPLATE, "" ) );
                browser.Tag = "";
            }
        }

        /**
         * Writes the text provided to the output window. The text
         * will be appended below any existing text already in the 
         * window.
         */

        private void WriteOutputText( string prefix, string outputText, WebBrowser activeBrowser )
        {
            try
            {
                this.UIThreadInvoke( delegate
                                     {
                                         if (activeBrowser == null)
                                             activeBrowser = _defaulBrowser;
                                         if (activeBrowser.Tag == null)
                                             activeBrowser.Tag = "";
                                         var s = activeBrowser.Tag as string;
                                         string bodyText = s +
                                                           string.Format( LINE_TEMPLATE, prefix, DateTime.Now,
                                                                          outputText );
                                         activeBrowser.Tag = bodyText;
                                         activeBrowser.NavigateToString( string.Format( TEMPLATE, bodyText ) );
                                     } );
            }
            catch (Exception e)
            {
                Console.Write( e.Message );
            }
        }

        /**
         * Called when the output window encounters a word wrap event.
         */

        private void btnTextWrap_Click( object sender, EventArgs e )
        {
            //GetActiveBrowser().ScrollBarsEnabled = !GetActiveBrowser().ScrollBarsEnabled;
        }

        private WebBrowser GetActiveBrowser()
        {
            WebBrowser activeBrowser = null;
            TabPage selectedPage = tabControl.SelectedTab;
            if (selectedPage != null)
            {
                if (selectedPage.Controls.Count > 0)
                {
                    activeBrowser = _defaulBrowser;
                    var host = selectedPage.Controls[0] as ElementHost;
                    if (host != null)
                        activeBrowser = host.Child as WebBrowser;
                }
            }
            return activeBrowser;
        }

        /**
         * Called when the output window encounters a find event.
         */

        private void btnFind_Click( object sender, EventArgs e )
        {
            WebBrowser webBrowser = GetActiveBrowser();
            if (webBrowser != null)
            {
                webBrowser.Focus();
                SendKeys.Send( "^f" );
            }
        }

        private void btnPrint_Click( object sender, EventArgs e )
        {
            WebBrowser browser = GetActiveBrowser();
            if (browser != null)
            {
                var doc = browser.Document as IHTMLDocument2;
                if (doc != null) doc.execCommand( "Print", true, null );
            }
        }
    }

    internal class HtmlTempFile : Object
    {
        public HtmlTempFile()
        {
            FileName = Path.GetTempFileName() + ".htm";
        }

        public StreamWriter Writer { set; get; }
        public string FileName { set; get; }

        public void Destroy()
        {
            try
            {
                Writer.Close();
                File.Delete( FileName );
            }
            catch (Exception e)
            {
                LogManager.Error( e );
            }
        }

        public void Write( string text )
        {
            File.WriteAllText( FileName, text );
        }
    }
}