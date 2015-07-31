/*
* Copyright (c) 2014 Universal Technical Resource Services, inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;
using System.Xml.XPath;
using System.Xml.Xsl;
using ATML1671Translator.exceptions;
using ATML1671Translator.forms;
using ATMLCommonLibrary.model.navigator;
using ATMLManagerLibrary.delegates;
using ATMLManagerLibrary.managers;
using ATMLModelLibrary.model;
using ATMLModelLibrary.model.common;
using ATMLProject.managers;
using ATMLProject.model;
using ATMLSchemaLibrary.managers;
using ATMLUtilitiesLibrary;

namespace ATML1671Translator.translator
{
    public delegate void TranslatedInputDocumentDelegate( TestDescription testDescription, string xml );

    public class ATMLTranslator
    {
        public static string SOURCE = "Translator";
        private const String PARSIBLE_DOCUMENT_EXTENSIONS = ".xml";
        private const String NAVIGABLE_DOCUMENT_EXTENSIONS = ".htm, .html";

        private ITranslatorNavigator _navigator;
        private byte[] _content;
        private String _documentName;
        private String _extension;
        private FileInfo _sourceFileInfo;
        private TestDescription _currentTestDescription;
        private static ATMLTranslator _instance;
        private static object _lockObject = new object();


        private ATMLTranslator()
        {
            ProjectManager.Instance.ProjectOpened += ATMLTranslator_ProjectOpened;
            ProjectManager.Instance.ProjectClosed += ATMLTranslator_ProjectClosed;
        }

        public void SetNavigator( ITranslatorNavigator navigator )
        {
            _navigator = navigator;
            _navigator.SelectATMLTestDescriptionDocument += _navigator_SelectATMLTestDescription;
            _navigator.SelectSourceDocument += _navigator_SelectSourceDocument;
        }

        public byte[] Content
        {
            get { return _content; }
        }

        public string Extension
        {
            get { return _extension; }
        }

        public TestDescription CurrentTestDescription
        {
            get { return _currentTestDescription; }
        }

        public static ATMLTranslator Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lockObject )
                    {
                        if (_instance == null)
                        {
                            _instance = new ATMLTranslator();
                        }
                    }
                }
                return _instance;
            }
        }

        public event AtmlDocumentOpenDelegate AtmlDocumentOpened;
        public event AtmlFileOpenDelegate AtmlFileOpened;
        public event InputDocumentOpenDelegate InputDocumentOpened;
        public event TranslatedInputDocumentDelegate InputDocumentTranslated;
        public event TranslatedInputDocumentDelegate TestDescriptionOpened;
        public event ProjectDelegate ProjectClosed;
        public event ProjectOpenDelegate ProjectOpened;
        public event EventHandler AixmlTranslationStarted;
        public event EventHandler AixmlTranslationCompleted;
        public event EventHandler AixmlParseStarted;
        public event EventHandler AixmlParseCompleted;

        protected virtual void OnAixmlParseStarted()
        {
            EventHandler handler = AixmlParseStarted;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        protected virtual void OnAixmlParseCompleted()
        {
            EventHandler handler = AixmlParseCompleted;
            if (handler != null) handler( this, EventArgs.Empty );
        }

        protected virtual void OnTestDescriptionOpened(TestDescription testdescription, string xml)
        {
            TranslatedInputDocumentDelegate handler = TestDescriptionOpened;
            if (handler != null) handler(testdescription, xml);
        }

        protected virtual void OnAixmlTranslationCompleted(string xmlTestDescription)
        {
            EventHandler handler = AixmlTranslationCompleted;
            if (handler != null) handler(xmlTestDescription, EventArgs.Empty);
        }

        protected virtual void OnAixmlTranslationStarted()
        {
            EventHandler handler = AixmlTranslationStarted;
            if (handler != null) handler( this, EventArgs.Empty );
        }

        protected virtual void OnAtmlFileOpened( FileInfo fi, byte[] content )
        {
            AtmlFileOpenDelegate handler = AtmlFileOpened;
            if (handler != null) handler( fi, content );
        }


        private void ATMLTranslator_ProjectClosed()
        {
            _sourceFileInfo = null;
            _content = null;
            _extension = null;
            OnProjectClosed();
        }

        protected virtual void OnProjectClosed()
        {
            ProjectDelegate handler = ProjectClosed;
            if (handler != null) handler();
        }

        protected virtual void OnProjectOpened( string testProgramSetName )
        {
            ProjectOpenDelegate handler = ProjectOpened;
            if (handler != null) handler( testProgramSetName );
        }

        private void ATMLTranslator_ProjectOpened( string testProgramSetName )
        {
            OnProjectOpened( testProgramSetName );
            string projectPath = Path.Combine( ATMLContext.TESTSET_PATH, testProgramSetName, "atml" );
            string fileName = Path.Combine( projectPath, testProgramSetName + ".1671.1.xml" );
            LoadTestDescriptionFile( fileName );
        }

        private void LoadTestDescriptionFile( string fileName )
        {
            if (File.Exists( fileName ))
            {
                byte[] content = FileManager.ReadFile( fileName );
                var fi = new FileInfo( fileName );
                OnAtmlFileOpened( fi, content );
                try
                {
                    _currentTestDescription = TestDescription.Deserialize(Encoding.UTF8.GetString(content));
                    //OnTestDescriptionCreated( testDescription );
                    OnTestDescriptionOpened(_currentTestDescription, Encoding.UTF8.GetString(content));
                }
                catch (Exception e)
                {
                    LogManager.SourceWarn( ATMLTranslator.SOURCE, "Failed to Deserialize Test Description \"{0}\"", fileName );
                }
            }
        }


        protected virtual void OnAtmlDocumentOpened( Document document )
        {
            AtmlDocumentOpenDelegate handler = AtmlDocumentOpened;
            if (handler != null) handler( document );
        }

        protected virtual void OnTestDescriptionCreated( TestDescription td, string xml )
        {
            LogManager.SourceInfo(ATMLTranslator.SOURCE, "The Test Description has been created and is ready for use.");
            TranslatedInputDocumentDelegate handler = InputDocumentTranslated;
            if (handler != null) handler( td, xml );
            OnAixmlTranslationCompleted(xml);
        }

        public static void CompareTestDescriptionToSource( string xmlTestDescription )
        {
            var comparer = new ATMLSourceComparer();
            comparer.TargetCode = xmlTestDescription;
            comparer.Closing += delegate( object sender, CancelEventArgs args )
                                {
                                    var form = sender as ATMLSourceComparer;
                                    if (form != null)
                                    {
                                        if (DialogResult.OK == form.DialogResult)
                                        {
                                        }
                                    }
                                };
            comparer.Show();
        }

        protected virtual void OnDocumentParsed( TestDescription td, string xml )
        {
            TranslatedInputDocumentDelegate handler = InputDocumentTranslated;
            if (handler != null) handler( td, xml );
        }

        protected virtual void OnOpenSourceDocument( FileInfo fi, byte[] content )
        {
            InputDocumentOpenDelegate handler = InputDocumentOpened;
            if (handler != null) handler( fi, content );
        }

        private void _navigator_SelectSourceDocument( object sender, FileInfo e )
        {
            string s = File.ReadAllText( e.FullName );
            SetContent( e, Encoding.UTF8.GetBytes( s ) );
            OnOpenSourceDocument( e, Encoding.UTF8.GetBytes( s ) );
            _sourceFileInfo = e;
        }

        private void _navigator_SelectATMLTestDescription( object sender, FileInfo e )
        {
        }


        public void SetContent( FileInfo fileInfo, byte[] content )
        {
            _documentName = fileInfo.Name;
            _extension = fileInfo.Extension;
            _content = content;
        }

        public void SetContent( byte[] content )
        {
            _content = content;
        }

        public void SaveSourceDocument()
        {
            File.WriteAllBytes( _sourceFileInfo.FullName, _content );
        }


        public void TranslateAIXML()
        {
            AixmlTranslator translator = new AixmlTranslator();
            translator.Translated+=OnTestDescriptionCreated;
            Thread tr = new Thread(translator.Translate);
            tr.Start();
            OnAixmlTranslationStarted();
            while (!tr.IsAlive)
            {
            }
            
        }

        public void ParseSourceDocument()
        {
            try
            {
                AixmlTranslator translator = new AixmlTranslator();
                translator.Parsed += delegate(object sender, EventArgs args)
                                     {
                                         var pea = args as ParserEventArgs;
                                         if (pea != null && pea.ParsedFileInfo != null )
                                         {
                                             _navigator.AddTranslatorDocument( pea.ParsedFileInfo, "aixml" );
                                         }
                                         OnAixmlParseCompleted();
                                     };
                Thread tr = new Thread(translator.Parse);
                tr.Start();
                OnAixmlParseStarted();
                while (!tr.IsAlive)
                {
                }
            }
            catch (Exception e )
            {
                LogManager.SourceError(ATMLTranslator.SOURCE, e);
            }
        }


        public bool IsParsible()
        {
            return ( PARSIBLE_DOCUMENT_EXTENSIONS.Contains( _extension ) && _content.Length > 0 );
        }

        public bool IsNavigatable()
        {
            return ( NAVIGABLE_DOCUMENT_EXTENSIONS.Contains( _extension ) );
        }

        public void TranslateAIXMLDocument()
        {
            if (_content != null && IsParsible())
            {
                try
                {
                    //---------------------------------//
                    //--- Setup XML reader settings ---//
                    //---------------------------------//
                    ValidationEventHandler validationHandler = (s, ee) => LogManager.SourceError(ATMLTranslator.SOURCE, ee.Exception);
                    var settings = new XmlReaderSettings();
                    settings.ValidationType = ValidationType.None;
                    settings.ValidationFlags = XmlSchemaValidationFlags.None;
                    settings.ValidationEventHandler += validationHandler;

                    string content = Encoding.UTF8.GetString( _content );
                    if (string.IsNullOrWhiteSpace( content ))
                        return;
                    using (var sr = new StringReader( content ))
                    {
                        using (XmlReader xrXml = new XmlTextReader( sr ))
                        {
                            var doc = new XPathDocument( xrXml );

                            string xsdName = SchemaManager.GetSchemaName( Encoding.UTF8.GetString( _content ) );
                            string xslName = xsdName.Replace( ".xsd", ".xsl" );

                            StringReader xslReader = GetXSLReader( xslName );
                            var xr = new XmlTextReader( xslReader );
                            var xslt = new XslCompiledTransform();
                            xslt.Load( xr );

                            //--------------------------------------------------------------------------//
                            //--- Create an XsltArgumentList for custom transformation functionality ---//
                            //--------------------------------------------------------------------------//
                            var xslArg = new XsltArgumentList();
                            xslArg.AddParam( "documentName", "", ProjectManager.ProjectName + ".1671.4.xml" );

                            // Add an object to calculate the new book price.
                            var obj = new TranslationLibrary();
                            //TODO: Figure out all the functionality required for translation
                            xslArg.AddExtensionObject( "urn:utrs.atml-translator-tools", obj );

                            //---------------------------//
                            //--- Transform the file. ---//
                            //---------------------------//
                            using (var w = new StringWriter())
                            {
                                var stringBuilder = new StringBuilder();
                                var xws = new XmlWriterSettings();
                                xws.OmitXmlDeclaration = true;
                                xws.Indent = true;
                                xws.NewLineOnAttributes = false;
                                xws.NamespaceHandling = NamespaceHandling.OmitDuplicates;
                                using (XmlWriter xmlWriter = XmlWriter.Create( stringBuilder, xws ))
                                {
                                    xslt.Transform( doc, xslArg, xmlWriter );
                                    LogManager.SourceTrace(ATMLTranslator.SOURCE, "ATML Test Description translation Completed");
                                    try
                                    {
                                        string xmlOut = stringBuilder.ToString();

                                        FileManager.WriteFile( Encoding.UTF8.GetBytes( xmlOut ) );
                                    }
                                    catch (Exception e)
                                    {
                                        LogManager.SourceError(ATMLTranslator.SOURCE, 
                                            "An error has occurred attempting to marshall the translated document into an ATML Test Configuration object.",
                                            e );
                                    }
                                    //OnTranslatedInputDocument(stringBuilder.ToString(), _testConfiguration);
                                }
                            }
                        }
                    }
                }
                catch (Exception ee)
                {
                    LogManager.SourceError(ATMLTranslator.SOURCE, ee, "An error has occurred attempting to process the input document.");
                }
            }
        }


        private static StringReader GetXSLReader( string xslName )
        {
            //-------------------------------------------//
            //--- Lookup the document in the database ---//
            //-------------------------------------------//
            Document document = DocumentManager.GetDocument( xslName, 14 );
            if (document == null)
                throw new Exception( string.Format( "Failed to find XSL style sheet {0}", xslName ) );
            LogManager.SourceTrace(ATMLTranslator.SOURCE, string.Format("Loading XSL Style Sheet {0}", xslName));
            var xslReader = new StringReader( Encoding.UTF8.GetString( document.DocumentContent ) );
            return xslReader;
        }

        private void exeProcess_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
        }

        private void exeProcess_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
        }
    }
}