/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Web;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Xsl;
using ATMLCommonLibrary.utils;
using ATMLManagerLibrary.managers;
using ATMLModelLibrary.model.common;
using ATMLUtilitiesLibrary;

namespace ATMLCommonLibrary.forms
{
    public partial class ATMLXslTranslationForm : Form
    {
        private string _tempFileName;
        private byte[] _xmlData;
        private byte[] _translatedData;
        private Document _xmlDocument;
        private byte[] _xslData;
        private Document _xslDocument;

        public ATMLXslTranslationForm( string xmlFileName, string xslFileName )
        {
            InitializeComponent();
            webBrowser.DocumentCompleted += webBrowser_DocumentCompleted;
            LoadContent( xmlFileName, xslFileName );
        }

        public ATMLXslTranslationForm( Stream xmlFile, Stream xslFile )
        {
            InitializeComponent();
            webBrowser.DocumentCompleted += webBrowser_DocumentCompleted;
            LoadContent( xmlFile, xslFile );
        }

        public ATMLXslTranslationForm( byte[] xmlFile, byte[] xslFile )
        {
            InitializeComponent();
            webBrowser.DocumentCompleted += webBrowser_DocumentCompleted;
            LoadContent( xmlFile, xslFile );
        }

        public ATMLXslTranslationForm( Document xmlFile, Document xslFile )
        {
            InitializeComponent();
            webBrowser.DocumentCompleted += webBrowser_DocumentCompleted;
            webBrowser.Navigating += webBrowser_Navigating;
            LoadContent( xmlFile, xslFile );
        }

        public byte[] XmlData
        {
            get { return _xmlData; }
        }

        public byte[] TranslatedData
        {
            get { return _translatedData; }
        }

        private void webBrowser_Navigating( object sender, WebBrowserNavigatingEventArgs e )
        {
        }

        private void webBrowser_DocumentCompleted( object sender, WebBrowserDocumentCompletedEventArgs e )
        {
            try
            {
                ProcessSubmit(e);
            }
            catch (Exception ex)
            {
                LogManager.Error(ex);
            }
        }

        private void ProcessSubmit(WebBrowserDocumentCompletedEventArgs e)
        {
            NameValueCollection urlParameters = HttpUtility.ParseQueryString( e.Url.ToString() );
            if (urlParameters.Count > 0 && XmlData != null)
            {
                bool processedParams = false;
                var xml = new XmlDocument();
                xml.LoadXml( Encoding.UTF8.GetString( XmlData ) );
                foreach (string k in urlParameters.AllKeys)
                {
                    string key = k;
                    if (!string.IsNullOrEmpty( key ))
                    {
                        string value = urlParameters.Get( key );
                        processedParams = true;
                        if (key.Contains( "?" ))
                            key = key.Substring( key.IndexOf( "?", StringComparison.Ordinal ) + 1 );
                        string[] parts = key.Split( ':' );
                        if (parts.Length > 1)
                        {
                            string id = "RES-" + parts[1];
                            XmlNodeList nl = xml.SelectNodes( string.Format( "//result[@id='{0}']", id ) );
                            if (nl.Count > 0)
                            {
                                var element = nl[0] as XmlElement;
                                if (element != null)
                                {
                                    if ("text".Equals( parts[0] ))
                                    {
                                        element.AppendChild( xml.CreateTextNode( value ) );
                                    }
                                    else
                                    {
                                        element.SetAttribute( parts[0], value );
                                    }
                                }
                            }
                        }
                        LogManager.Trace( "{0}={1}", key, urlParameters.Get( key ) );
                    }
                    if (processedParams)
                    {
                        var sw = new StringWriter();
                        XmlWriter writer = new UTRSXmlWriter( sw );
                        xml.WriteTo( writer );
                        _xmlData = Encoding.UTF8.GetBytes( sw.ToString() );
                        string html = XmlUtils.Transform( _xslData, XmlData );
                        _translatedData = Encoding.UTF8.GetBytes( html );
                        File.WriteAllText( _tempFileName, html );
                        webBrowser.Navigate( _tempFileName );
                    }
                }
            }
        }


        private void LoadContent( Stream xmlFile, Stream xslFile )
        {
            try
            {
                Load( xmlFile, xslFile );
            }
            catch (Exception e)
            {
                LogManager.Error( e );
            }
        }

        private void LoadContent( byte[] xmlFile, byte[] xslFile )
        {
            try
            {
                Load( xmlFile, xslFile );
            }
            catch (Exception e)
            {
                LogManager.Error( e );
            }
        }


        private void LoadContent( string xmlFileName, string xslFileName )
        {
            try
            {
                Document xmlAbout = DocumentManager.GetDocumentByName( xmlFileName );
                Document xslAbout = DocumentManager.GetDocumentByName( xslFileName );
                Load( xslAbout, xmlAbout );
            }
            catch (Exception e)
            {
                LogManager.Error( e );
            }
        }

        private void LoadContent( Document xml, Document xsl )
        {
            try
            {
                Load( xsl, xml );
            }
            catch (Exception e)
            {
                LogManager.Error( e );
            }
        }

        private void Load( Document xsl, Document xml )
        {
            _xmlDocument = xml;
            _xslDocument = xsl;

            var xslTransform = new XslCompiledTransform();
            using (var stringReader = new StringReader( Encoding.UTF8.GetString( xsl.DocumentContent ) ))
            {
                using (XmlReader xslt = XmlReader.Create( stringReader ))
                {
                    xslTransform.Load( xslt );
                }
            }

            using (var writer = new StringWriter())
            {
                using (
                    XmlReader input =
                        XmlReader.Create( new StringReader( Encoding.UTF8.GetString( xml.DocumentContent ) ) ))
                {
                    _xmlData = xml.DocumentContent;
                    xslTransform.Transform( input, null, writer );
                    _tempFileName = Path.GetTempFileName() + ".html";
                    File.WriteAllText( _tempFileName, writer.ToString() );
                    webBrowser.Navigate( "file://" + _tempFileName ); //"about:blank");
                    _translatedData = Encoding.UTF8.GetBytes(writer.ToString());
                }
            }
        }

        private void Load( Stream xmlFile, Stream xslFile )
        {
            var xslTransform = new XslCompiledTransform();
            using (XmlReader xslt = XmlReader.Create( xslFile ))
            {
                xslTransform.Load( xslt );
            }

            using (var writer = new StringWriter())
            {
                using (XmlReader input = XmlReader.Create( xmlFile ))
                {
                    xslTransform.Transform( input, null, writer );
                    _tempFileName = Path.GetTempFileName() + ".html";
                    File.WriteAllText( _tempFileName, writer.ToString() );
                    webBrowser.Navigate( "file://" + _tempFileName ); //"about:blank");
                    _translatedData = Encoding.UTF8.GetBytes(writer.ToString());
                }
            }
        }

        private void Load( byte[] xmlFile, byte[] xslFile )
        {
            var xslTransform = new XslCompiledTransform();
            _xmlData = xmlFile;
            _xslData = xslFile;
            using (var memory = new MemoryStream( xslFile, 0, xslFile.Length ))
            {
                using (XmlReader xslt = XmlReader.Create( memory ))
                {
                    xslTransform.Load( xslt );
                }
            }

            using (var writer = new StringWriter())
            {
                using (var memory = new MemoryStream( xmlFile, 0, xmlFile.Length ))
                {
                    using (XmlReader input = XmlReader.Create( memory ))
                    {
                        xslTransform.Transform( input, null, writer );
                        _tempFileName = Path.GetTempFileName() + ".html";
                        File.WriteAllText( _tempFileName, writer.ToString() );
                        webBrowser.Navigate( "file://" + _tempFileName ); //"about:blank");
                        _translatedData = Encoding.UTF8.GetBytes(writer.ToString());

                        //webBrowser.Navigate( "about:blank" );
                        //if (webBrowser.Document != null) webBrowser.Document.Write( writer.ToString() );
                    }
                }
            }
        }

        private void btnClose_Click( object sender, EventArgs e )
        {
            Close();
        }

        protected override void OnClosing( CancelEventArgs e )
        {
            try
            {
                if (!string.IsNullOrEmpty( _tempFileName ))
                    File.Delete( _tempFileName );
            }
            catch (Exception err)
            {
                /* Do Nothing */
            }
            base.OnClosing( e );
        }
    }
}