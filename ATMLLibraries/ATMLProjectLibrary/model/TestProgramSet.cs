using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using ATMLCommonLibrary.forms;
using ATMLCommonLibrary.utils;
using ATMLManagerLibrary.managers;
using ATMLModelLibrary.interfaces;
using ATMLModelLibrary.model;
using ATMLProject.exceptions;
using ATMLProject.managers;
using ATMLProject.Properties;
using ATMLUtilitiesLibrary;
using Ionic.Zip;

namespace ATMLProject.model
{
    public class TestProgramSet
    {
        private DirectoryInfo _testSetDirectory;
        private String _testSetName;

        public string TestSetName
        {
            get { return _testSetName; }
            set { _testSetName = value; }
        }

        public DirectoryInfo TestSetDirectory
        {
            get { return _testSetDirectory; }
        }

        public ProjectInfo ProjectInfo { get; set; }
        public event FileSavedHandler AtmlFileSaved;

        public void Close()
        {
            ProjectInfo = null;
            _testSetDirectory = null;
            _testSetName = null;
        }

        protected virtual void OnAtmlFileSaved( string fileName, byte[] content, AtmlFileType atmlFileType )
        {
            FileSavedHandler handler = AtmlFileSaved;
            if (handler != null) handler( this, fileName, content, atmlFileType );
        }

        public void LoadTreeView( TreeView treeView )
        {
        }

        public void CreateTestSetArchive( String testSetName )
        {
            String testSetPath = ATMLContext.TESTSET_PATH;
            testSetName = CleanTestSetName( testSetName );
            String fullPathName = Path.Combine( testSetPath, testSetName );
            var dlg = new SaveFileDialog();
            dlg.DefaultExt = ATMLContext.TESTSET_ARCHIVE_EXT;
            dlg.FileName = testSetName;
            if (DialogResult.OK == dlg.ShowDialog())
            {
                var zip = new ZipFile();
                zip.AddDirectory( _testSetDirectory.FullName );
                zip.Save( dlg.FileName );
                LogManager.Trace( "The Test Program Set has been archived to \"{0}\"", dlg.FileName );
            }
        }

        public static bool HasTestProgramSet( string testSetName )
        {
            string testSetPath = GetTestSetPath();
            testSetName = CleanTestSetName( testSetName );
            String rootPathName = Path.Combine( testSetPath, testSetName );
            return Directory.Exists( rootPathName );
        }

        /**
         * CreateTestSet will create or modify and existing Test Set folder structure to conform
         * with the structure specified in the resource file called "folder_structure.xml"
         * A TestProgramSet object instance will be returned for the name specified.
         */

        public static TestProgramSet CreateTestSet( String testSetName )
        {
            Stream stream =
                ProjectManager.Instance.GetType().Assembly.GetManifestResourceStream( Resources.FileStructure );
            if (stream == null)
                throw new Exception( "Failed to load the File Structure resources." );
            var reader = new XmlTextReader( stream );
            var document = new XmlDocument();
            document.Load( reader );
            XmlElement root = document.DocumentElement;

            string testSetPath = GetTestSetPath();
            testSetName = CleanTestSetName( testSetName );

            String rootPathName = Path.Combine( testSetPath, testSetName );
            var testSet = new TestProgramSet();
            testSet._testSetName = testSetName;
            if (!Directory.Exists( rootPathName ))
                testSet._testSetDirectory = Directory.CreateDirectory( rootPathName );
            else
                testSet._testSetDirectory = new DirectoryInfo( rootPathName );

            ProcessFolderNode( root, rootPathName );
            return testSet;
        }

        /**
         * Processes each folder specified in the XML tree where a directory will be created
         * for each folder name if not already there. This method will be called 
         * recursively for sub folders.
         */

        private static void ProcessFolderNode( XmlElement root, String rootPathName )
        {
            foreach (XmlNode child in root.ChildNodes)
            {
                var element = child as XmlElement;
                if (element != null)
                {
                    if ("folder".Equals( child.Name ))
                    {
                        string name = element.GetAttribute( "name" );
                        String sourcePath = Path.Combine( rootPathName, name );
                        if (!Directory.Exists( sourcePath ))
                            Directory.CreateDirectory( sourcePath );
                        if (element.HasChildNodes)
                            ProcessFolderNode( element, sourcePath );
                    }
                }
            }
        }

        private static string GetTestSetPath()
        {
            //-----------------------------//
            //--- Get the Test Set Path ---//
            //-----------------------------//
            String testSetPath = ATMLContext.TESTSET_PATH;
            if (!Directory.Exists( testSetPath ))
                Directory.CreateDirectory( testSetPath );
            return testSetPath;
        }

        private static String CleanTestSetName( string testSetName )
        {
            //-------------------------------------------------//
            //--- Just in case we need to do something here ---//
            //-------------------------------------------------//
            return testSetName;
        }

        /**
         * Searches for the document in the reader folder. A boolean true 
         * is returned if the document exists.
         */

        public Boolean HasReaderDocument( string documentName )
        {
            string fullFileName = GetTestSetPath() + @"\reader\" + documentName;
            return File.Exists( fullFileName );
        }

        /**
         * Returns the contents of the reader document specified by the document name provided.
         */

        public byte[] GetReaderDocument( string documentName )
        {
            string fullFileName = GetTestSetPath() + @"\reader\" + documentName;
            return File.ReadAllBytes( fullFileName );
        }

        public void SaveReaderDocument( string documentName, byte[] contentBytes )
        {
            string fullFileName = TestSetDirectory + @"\reader\" + documentName;
            if (File.Exists( fullFileName ))
                File.Delete( fullFileName );
            File.WriteAllBytes( fullFileName, contentBytes );
        }

        public void SaveReaderATMLDocument( string documentName, byte[] contentBytes, bool forceOverWrite )
        {
            SaveATMLDocument( documentName, AtmlFileType.AtmlTypeTestConfiguration, contentBytes, forceOverWrite );
        }

        public void RemoveATMLDocument( string documentName, AtmlFileType atmlDocNo )
        {
            documentName = AddDocumentSuffix( documentName, atmlDocNo );
            string folder = Path.Combine( TestSetDirectory.FullName, "atml" );
            string fullFileName = Path.Combine( folder, documentName );
            FileManager.DeleteFile( fullFileName );
        }

        public void SaveATMLDocument( string documentName, AtmlFileType atmlDocNo, byte[] contentBytes,
                                      bool forceOverWrite )
        {
            documentName = AddDocumentSuffix( documentName, atmlDocNo );
            string folder = TestSetDirectory + @"\atml\";
            string fullFileName = Path.Combine( folder, documentName );
            bool ok2Save = true;
            if (!forceOverWrite && File.Exists( fullFileName ))
            {
                ok2Save = DialogResult.Yes ==
                          MessageBox.Show(
                              string.Format( "File name {0} already exists. Are you sure you want to overwrite it?",
                                             documentName ),
                              @"O V E R W R I T E  F I L E ", MessageBoxButtons.YesNo, MessageBoxIcon.Question );
            }
            if (ok2Save)
            {
                File.WriteAllBytes( fullFileName, contentBytes );
                LogManager.Debug( "File {0} has been written to {1}", documentName, folder );
                OnAtmlFileSaved( documentName, contentBytes, atmlDocNo );
            }
        }

        private static string AddDocumentSuffix( string documentName, AtmlFileType atmlDocNo )
        {
            if (!documentName.Contains( "1671" ))
                documentName = documentName + ".1671." + (int) atmlDocNo;
            if (!documentName.ToLower().EndsWith( ".xml" ))
                documentName = documentName + ".xml";
            return documentName;
        }

        public static TestProgramSet OpenTestSet( String testSetName )
        {
            string testSetPath = GetTestSetPath();
            testSetName = CleanTestSetName( testSetName );
            string fullPath = Path.Combine( testSetPath, testSetName );
            TestProgramSet testSet = CreateTestSet( testSetName ); //new TestProgramSet();
            testSet._testSetDirectory = new DirectoryInfo( fullPath );
            testSet._testSetName = testSetName;
            return testSet;
        }

        public static bool SelectTestSet( out TestProgramSet testSet )
        {
            testSet = null;
            string testSetPath = GetTestSetPath();
            //FileManager.OpenFolder(out testSetPath);
            var form = new DirectorySelectionForm( testSetPath );
            form.Text = @"Select Test Program Set Project";
            if (DialogResult.OK == form.ShowDialog())
            {
                using (new HourGlass())
                {
                    string testSetName = form.SelectedFolder;
                    testSet = OpenTestSet( testSetName );
                }
            }
            return testSet != null;
        }


        public static void DeleteTestSet( String testSetName )
        {
            //--- Display a list of available test sets and open the one that is selected ---//
            string testSetPath = GetTestSetPath();
            testSetName = CleanTestSetName( testSetName );
            string fullPath = Path.Combine( testSetPath, testSetName );
            if (!Directory.Exists( fullPath ))
                throw new TestSetNotFoundException();
            Directory.Delete( fullPath, true );
        }

        public static void ImportTestSet()
        {
            //--- Open file that has a .tpar extention ----//
            //--- Use the file name as the test set name ---//
            //--- Validate the test set name for the correct format ---//
            //--- Check for the existance of a test set with the same name ---//
            //--- If a test set with the same name already exists then ask the user if they would like to replace it ---//
        }

        public static void ExportTestSet()
        {
        }
    }
}