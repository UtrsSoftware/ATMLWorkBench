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
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;
using ATML1671Translator.exceptions;
using ATMLDataAccessLibrary.db.beans;
using ATMLDataAccessLibrary.model;
using ATMLManagerLibrary.managers;
using ATMLModelLibrary.model;
using ATMLModelLibrary.model.common;
using ATMLProject.managers;
using ATMLUtilitiesLibrary;

namespace ATML1671Translator.translator
{
    public class AixmlTranslator
    {
        public event TranslatedInputDocumentDelegate Translated;
        public event EventHandler Parsed;
        Process _exeProcess = new Process();


        protected virtual void OnParsed( FileInfo fi )
        {
            var args = new ParserEventArgs();
            args.ParsedFileInfo = fi;
            EventHandler handler = Parsed;
            if (handler != null) handler( this, args );
        }

        protected virtual void OnTranslated( TestDescription testdescription, string xml )
        {
            TranslatedInputDocumentDelegate handler = Translated;
            if (handler != null) handler( testdescription, xml );
        }


        public void Parse()
        {
            try
            {
                ProjectInfo pi = ProjectManager.ProjectInfo;
                if (pi == null || pi.TranslationInfo == null)
                    throw new TranslationException( "Failed to obtain the Translation Configuration" );

                bool isSegmented = pi.TranslationInfo.Segmented;
                string atlasPath = GetAtlasParserDirectory();
                string projectName = pi.ProjectName;
                string projectId = pi.Uuid;
                string uutName = pi.UutName;
                string uutId = pi.UutId;
                string testStation = pi.ClassName;
                string inputFile = isSegmented ? pi.TranslationInfo.SourcesAsAstring : pi.TranslationInfo.PrimaryFile;

                if (string.IsNullOrEmpty( testStation ))
                    throw new TranslationException( "You must select a Test Station in the Translator Configuration." );

                if (string.IsNullOrEmpty( uutId ))
                    throw new TranslationException( "You must select a UUT." );

                if (string.IsNullOrEmpty( uutName ))
                    throw new TranslationException( "You must select a UUT." );

                var atlasFile =
                    (String)ATMLContext.GetProperty("translator.atlas.parser.application-file", "catlas2aixml.exe");
                atlasFile = Path.Combine( atlasPath, atlasFile );

                if (!File.Exists( atlasFile ))
                    throw new TranslationException(String.Format("Failed to find the ATLAS Parsing Application ({0})", atlasFile));

                //if (_sourceFileInfo == null)
                //    throw new Exception( "The source file is missing." );

                _exeProcess = new Process();
                string xmlPath = ATMLContext.ProjectTranslatorAixmlPath;
                string projectPath = Path.Combine( ATMLContext.TESTSET_PATH, ProjectManager.ProjectName );
                string sourcePath = ATMLContext.ProjectTranslatorSourcePath;
                string aixmlFileName = Path.Combine( xmlPath, projectName + ".aixml.xml" );
                LogManager.Debug( "Obtained Translator Configuration." );
                //string fileName = _sourceFileInfo.Name;

                if (sourcePath == null)
                    throw new TranslationException("Missing Translator Source Path.");

                var args = new StringBuilder();
                args.Append( "\"input_files=" ).Append( inputFile ).Append( "\" " );
                args.Append( "\"test_station=" ).Append( testStation ).Append( "\" " );
                args.Append( "\"uut_name=" ).Append( uutName ).Append( "\" " );
                args.Append( "\"uut_id=" ).Append( uutId ).Append( "\" " );
                args.Append( "\"project_name=" ).Append( projectName ).Append( "\" " );
                args.Append( "\"output_directory=" ).Append( xmlPath ).Append( "\" " );
                args.Append( "\"input_directory=" ).Append( sourcePath ).Append( "\" " );
                args.Append( "\"console_html=" ).Append( "yes" ).Append( "\" " );
                args.Append("\"proc_hier=").Append("yes").Append("\" ");

                LogManager.Debug( "Obtained Parser Arguments." );
                LogManager.Debug( "Executing parser \"{0}\" [{1}] on {2}", atlasFile, args.ToString(),
                                  inputFile );
                LogManager.SourceTrace( ATMLTranslator.SOURCE, "Parsing ATLAS Source Files..." );

                ProcessStartInfo startInfo = _exeProcess.StartInfo;
                startInfo.CreateNoWindow = false;
                startInfo.UseShellExecute = false;
                startInfo.WorkingDirectory = sourcePath;
                startInfo.FileName = atlasFile;
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo.Arguments = args.ToString();
                startInfo.RedirectStandardOutput = true;
                startInfo.RedirectStandardInput = true;
                startInfo.RedirectStandardError = true;
                startInfo.CreateNoWindow = true;

                _exeProcess.EnableRaisingEvents = true;
                _exeProcess.OutputDataReceived += exeProcess_OutputDataReceived;
                _exeProcess.ErrorDataReceived += exeProcess_ErrorDataReceived;
                _exeProcess.Exited += delegate( object sender, EventArgs eventArgs )
                                     {
                                         FileInfo fileInfo = null;
                                         if (_exeProcess != null)
                                         {
                                             int errorCode = _exeProcess.ExitCode;
                                             if (errorCode > 0)
                                             {
                                                 LogManager.SourceError( ATMLTranslator.SOURCE,
                                                                         "The ATLAS Parser has Failed." );
                                             }
                                             else
                                             {
                                                 LogManager.SourceInfo( ATMLTranslator.SOURCE,
                                                                        "The ATLAS Parser has Successfully Completed.");
                                                 fileInfo = new FileInfo( aixmlFileName );
                                             }
                                         }
                                         //Always call OnParsed to clear parsing states.
                                         OnParsed(fileInfo);
                                         _exeProcess.Close();
                                     };

                // Start the process with the info we specified.
                // Call WaitForExit and then the using statement will close.
                _exeProcess.Start();

                var sb = new StringBuilder();
                using (StreamReader stdOut = _exeProcess.StandardOutput)
                {
                    do
                    {
                        sb.Append( stdOut.ReadLine() );
                    } while (!stdOut.EndOfStream); //Loops until the stream ends
                    LogManager.SourceTrace( ATMLTranslator.SOURCE, sb.ToString() );
                }
            }
            catch (TranslationException err)
            {
                OnParsed(null);
                LogManager.SourceError(ATMLTranslator.SOURCE, err.Message);
            }
            catch (Exception err)
            {
                OnParsed( null );
                LogManager.SourceError( ATMLTranslator.SOURCE, err );
            }
            finally
            {
            }
        }

        private static string GetAtlasParserDirectory()
        {
            string path = "";
            try
            {
                path = ATMLContext.PROGRAM_PATH;
            }
            catch (Exception e)
            {
                LogManager.SourceError( ATMLTranslator.SOURCE, e.Message );
            }
            return path;
        }

        private void exeProcess_ErrorDataReceived( object sender, DataReceivedEventArgs e )
        {
            //LogManager.Error(e.Data);
        }

        private void exeProcess_OutputDataReceived( object sender, DataReceivedEventArgs e )
        {
            //LogManager.Trace( e.Data );
        }


        public void Translate()
        {
            try
            {
                LogManager.SourceTrace( ATMLTranslator.SOURCE,
                                        "Beginning Translation of the AIXML document to the 1671.1 Test Description..." );
                ProjectInfo pi = ProjectManager.ProjectInfo;
                if (pi == null || pi.TranslationInfo == null)
                    throw new TranslationException( "Failed to obtain the Translation Configuration" );

                string projectName = pi.ProjectName;
                string projectId = pi.Uuid;
                string uutName = pi.UutName;
                string uutId = pi.UutId;
                string testStation = pi.ClassName;
                bool isSegmented = pi.TranslationInfo.Segmented;
                DateTime startTime = DateTime.Now;

                string xmlPath = Path.Combine( ATMLContext.ProjectTranslatorAixmlPath, projectName + ".aixml.xml" );
                string atmlPath = ATMLContext.ProjectAtmlPath;
                //(String)ATMLContext.GetProperty("environment.atml.xml-path");

                if (String.IsNullOrWhiteSpace( projectName ))
                {
                    LogManager.SourceWarn( ATMLTranslator.SOURCE,
                                           "You must open a project with source code to translate." );
                }
                else
                {
                    //string projectPath = ATMLContext.PROJECT_PATH;// Path.Combine( ATMLContext.TESTSET_PATH, projectName );
                    //                    xmlPath = xmlPath.Replace( "${FILENAME}", ProjectManager.ProjectName + ".atml" )
                    //                                     .Replace( "${PROJECTPATH}", projectPath );
                    Document xslDocument = DocumentManager.GetDocument( "D7F7A05B-DB5F-4E93-BF2C-F79CF72F6047" );
                    //XSLT Translation Document
                    //atmlPath = atmlPath.Replace( "${PROJECTPATH}", projectPath );
                    if (xslDocument != null)
                    {
                        try
                        {
                            var ok2Translate = true;
                            var sb = new StringBuilder();
                            var settings = new XmlWriterSettings();
                            var fi = new FileInfo(Path.Combine(atmlPath, ProjectManager.ProjectName + ".1671.1.xml"));
                            settings.Indent = true;
                            settings.IndentChars = "  ";
                            settings.NewLineChars = "\r\n";
                            settings.NewLineHandling = NewLineHandling.Replace;
                            var xslt = new XslCompiledTransform();
                            if (!File.Exists( xmlPath ))
                                throw new TranslationException( "Translation Failed: Missing AIXML File." );
                            if (fi.Exists)
                                ok2Translate =
                                    MessageBox.Show(
                                        string.Format( "A Test Description for {0} already exists, would you like to overwrite it?", ProjectManager.ProjectName ),
                                        @"Overwrite Test Description", MessageBoxButtons.YesNo, MessageBoxIcon.Question ) ==
                                    DialogResult.Yes;
                            if (!ok2Translate)
                            {
                                LogManager.Trace( "AIXML Translation to ATML 1671.1 has been canceled." );
                            }
                            else
                            {
                                using (XmlWriter writer = XmlWriter.Create( sb, settings ))
                                {
                                    var xmlDocument = new XPathDocument( xmlPath );
                                    xslt.Load(
                                        XmlReader.Create(
                                            new StringReader( Encoding.UTF8.GetString( xslDocument.DocumentContent ) ) ) );
                                    var xslArg = new XsltArgumentList();
                                    var obj = new TranslationLibrary();
                                    xslArg.AddExtensionObject( "urn:utrs.atml-translator-tools", obj );
                                    xslArg.XsltMessageEncountered +=
                                        delegate( object sender, XsltMessageEncounteredEventArgs args )
                                        {
                                            LogManager.SourceError( ATMLTranslator.SOURCE, args.Message );
                                        };
                                    xslt.Transform( xmlDocument, xslArg, writer, null );
                                    DateTime stopTime = DateTime.Now;
                                    TimeSpan diff = stopTime - startTime;
                                    LogManager.SourceTrace( ATMLTranslator.SOURCE, "Translation Time: {0}",
                                                            diff.ToString() );
                                }
                                FileManager.WriteFile( fi.FullName, Encoding.UTF8.GetBytes( sb.ToString() ) );
                                LogManager.SourceTrace( ATMLTranslator.SOURCE, "File \"{0}\" has been saved. ", fi.Name );

                                try
                                {
                                    TestDescription td = TestDescription.Deserialize( sb.ToString() );
                                    OnTranslated( td, sb.ToString() );
                                    Document document = DocumentManager.GetDocument( fi.Name,
                                                                                     (int)
                                                                                     dbDocument.DocumentType
                                                                                               .TEST_DESCRIPTION );
                                    if (document == null)
                                    {
                                        document = new Document();
                                        document.uuid = td.uuid;
                                        document.DocumentType = dbDocument.DocumentType.TEST_DESCRIPTION;
                                        document.ContentType = DocumentManager.DetermineContentType( fi.Name );
                                        document.DataState = BASEBean.eDataState.DS_ADD;
                                    }
                                    else
                                    {
                                        document.DataState = BASEBean.eDataState.DS_EDIT;
                                    }
                                    document.FileInfo = fi;
                                    document.name = fi.Name;
                                    document.Description = "Test Description for " + projectName;
                                    document.DocumentContent = Encoding.UTF8.GetBytes( sb.ToString() );
                                    document.version = td.version;
                                    DocumentManager.SaveDocument( document );
                                }
                                catch (Exception e)
                                {
                                    OnTranslated( null, null );
                                    LogManager.SourceWarn( ATMLTranslator.SOURCE,
                                                           "Failed to create a TestDescription object at this time." );
                                    LogManager.Debug( e );
                                }
                            }
                        }
                        catch (TranslationException e)
                        {
                            OnTranslated( null, null );
                            LogManager.SourceError( ATMLTranslator.SOURCE, e.Message );
                        }
                        catch (Exception e)
                        {
                            OnTranslated( null, null );
                            LogManager.SourceError( ATMLTranslator.SOURCE, e,
                                                    "Error translating AIXML for Project: {0} XML Path: {1} ATML Path: {2}",
                                                    projectName, xmlPath, atmlPath );
                        }
                    }
                }
            }
            catch (Exception e)
            {
                LogManager.SourceError( ATMLTranslator.SOURCE, e );
            }
        }
    }

    public class ParserEventArgs : EventArgs
    {
        public FileInfo ParsedFileInfo { set; get; }
    }
}