using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using ATMLCommonLibrary.forms;
using ATMLCommonLibrary.managers;
using ATMLCommonLibrary.model.navigator;
using ATMLCommonLibrary.utils;
using ATMLDataAccessLibrary.db.beans;
using ATMLManagerLibrary.controllers;
using ATMLManagerLibrary.events;
using ATMLManagerLibrary.managers;
using ATMLModelLibrary.interfaces;
using ATMLModelLibrary.model;
using ATMLModelLibrary.model.common;
using ATMLModelLibrary.model.uut;
using ATMLProject.model;
using ATMLProject.watchers;
using ATMLUtilitiesLibrary;
using Ionic.Zip;

namespace ATMLProject.managers
{
    public delegate void ProjectDelegate();

    public delegate void ProjectOpenDelegate( string testProgramSetName );

    public class ProjectManager
    {
        private static volatile ProjectManager _instance;
        private static readonly object syncRoot = new Object();
        private TestProgramSet _currentTestProgramSet;
        private UutWatcher _uutWatcher;

        private ProjectManager()
        {
            ATMLNavigator.Instance.CreateAbfFileClicked += Navigator_CreateAbfFileClicked;
            UUTController.Instance.AtmlObjectNameChanged += InstanceOnAtmlObjectNameChanged;
        }

        public TestProgramSet CurrentTestProgramSet
        {
            get { return _currentTestProgramSet; }
            set
            {
                _currentTestProgramSet = value;
                if (_currentTestProgramSet != null)
                    _currentTestProgramSet.AtmlFileSaved += CurrentTestProgramSetOnAtmlFileSaved;
            }
        }

        public static string ProjectName
        {
            get
            {
                string name = null;
                if (Instance.CurrentTestProgramSet != null)
                    name = Instance.CurrentTestProgramSet.TestSetName;
                return name;
            }
        }

        public static string ProjectPath
        {
            get { return Path.Combine( ATMLContext.TESTSET_PATH, ProjectName ); }
        }

        public static string AtmlPath
        {
            get { return Path.Combine( ProjectPath, "atml" ); }
        }

        public static string DocumentPath
        {
            get { return Path.Combine( ProjectPath, "doc" ); }
        }

        public static string ReaderPath
        {
            get { return Path.Combine( ProjectPath, "reader" ); }
        }

        public static string AllocatorPath
        {
            get { return Path.Combine( ProjectPath, "allocator" ); }
        }

        public static string TranslatorPath
        {
            get { return Path.Combine( ProjectPath, "translator" ); }
        }

        public static string TranslatorSourcePath
        {
            get { return Path.Combine( TranslatorPath, "source" ); }
        }

        public static ProjectManager Instance
        {
            get
            {
                lock (syncRoot)
                {
                    if (_instance == null)
                        _instance = new ProjectManager();
                }
                return _instance;
            }
        }

        public static ProjectInfo ProjectInfo
        {
            get
            {
                TestProgramSet currentTestProgramSet = Instance.CurrentTestProgramSet;
                return currentTestProgramSet != null ? currentTestProgramSet.ProjectInfo : null;
            }
            set
            {
                TestProgramSet currentTestProgramSet = Instance.CurrentTestProgramSet;
                currentTestProgramSet.ProjectInfo.ClassName = value.ClassName;
                SaveProjectInfo( currentTestProgramSet.ProjectInfo, currentTestProgramSet );
            }
        }

        public static TranslationInfo TranslationInfo
        {
            get
            {
                TestProgramSet currentTestProgramSet = Instance.CurrentTestProgramSet;
                return currentTestProgramSet != null ? currentTestProgramSet.ProjectInfo.TranslationInfo : null;
            }
            set
            {
                TestProgramSet currentTestProgramSet = Instance.CurrentTestProgramSet;
                currentTestProgramSet.ProjectInfo.TranslationInfo = value;
                SaveProjectInfo( currentTestProgramSet.ProjectInfo, currentTestProgramSet );
            }
        }

        public event FileSavedHandler AtmlFileSaved;
        public event ProjectOpenDelegate ProjectOpened;
        public event ProjectDelegate ProjectClosed;
        public event EventHandler ProjectClosing;

        protected virtual void OnProjectClosing()
        {
            EventHandler handler = ProjectClosing;
            if (handler != null) handler( this, EventArgs.Empty );
        }
        private void InstanceOnAtmlObjectNameChanged( object sender, AtmlNameChangedEventArgs atmlNameChangedEventArgs )
        {
            string oldName = atmlNameChangedEventArgs.OldName;
            string newName = atmlNameChangedEventArgs.NewName;
            string uuid = atmlNameChangedEventArgs.Uuid;
            Document document = DocumentManager.GetDocument( uuid );
            if (document != null && _currentTestProgramSet != null)
            {
                string path = Path.Combine( ATMLContext.TESTSET_PATH, _currentTestProgramSet.TestSetName, "atml" );
                FileManager.WriteFile( Path.Combine( path, newName ), document.DocumentContent );
                FileManager.DeleteFile( Path.Combine( path, oldName ) );
            }
        }

        private void CurrentTestProgramSetOnAtmlFileSaved( object sender, string fileName, byte[] content,
                                                           AtmlFileType atmlFileType )
        {
            OnAtmlFileSaved( sender, fileName, content, atmlFileType );
        }

        protected virtual void OnAtmlFileSaved( object sender, string fileName, byte[] content,
                                                AtmlFileType atmlFileType )
        {
            FileSavedHandler handler = AtmlFileSaved;
            if (handler != null) handler( sender, fileName, content, atmlFileType );
        }

        private void Navigator_CreateAbfFileClicked( object sender, DirectoryInfo e, string name, EventArgs args )
        {
            var sb = new StringBuilder();
            var dlg = new OpenFileDialog();
            dlg.Multiselect = true;
            dlg.InitialDirectory = e.FullName;
            if (DialogResult.OK == dlg.ShowDialog())
            {
                foreach (string fileName in dlg.FileNames)
                {
                    var fi = new FileInfo( fileName );
                    LogManager.Trace( fi.Name );
                    sb.Append( fi.Name ).Append( Environment.NewLine );
                }
                string abfFileName = Path.Combine( e.FullName, ProjectName + ".abf" );
                bool createFile = true;
                if (File.Exists( abfFileName ))
                {
                    DialogResult dr =
                        MessageBox.Show(
                            string.Format( "ATML Build File \"{0}{1}\" already exists. Would you like to overwrite it?",
                                           ProjectName, ".abf" ),
                            @"V E R I F I C A T I O N", MessageBoxButtons.YesNo, MessageBoxIcon.Question );
                    createFile = ( dr == DialogResult.Yes );
                }
                if (createFile)
                {
                    File.Delete( abfFileName );
                    byte[] content = Encoding.UTF8.GetBytes( sb.ToString() );
                    using (FileStream fs = File.Create( abfFileName ))
                    {
                        fs.Write( content, 0, content.Length );
                        fs.Close();
                        var fi = new FileInfo( abfFileName );
                        ATMLNavigator.Instance.AddSourceDocument( fi );
                    }
                }
            }
        }

        protected virtual void OnProjectOpened( string testProgramSetName )
        {
            _uutWatcher = new UutWatcher();
            ATMLContext.CurrentProjectName = testProgramSetName;
            ProjectOpenDelegate handler = ProjectOpened;
            if (handler != null) handler( testProgramSetName );
        }

        protected virtual void OnProjectClosed()
        {
            ProjectDelegate handler = ProjectClosed;
            if (handler != null) handler();
            if (_uutWatcher != null) _uutWatcher.Close();
            ATMLContext.CurrentProjectName = null;
            _uutWatcher = null;
        }

        public static bool HasOpenProject()
        {
            return Instance.CurrentTestProgramSet != null;
        }

        public static void CloseProject()
        {
            Instance.Close();
        }

        public void Close()
        {
            if (CurrentTestProgramSet != null)
            {
                OnProjectClosing();
                FormManager.CloseAllForms();
                string name = CurrentTestProgramSet.TestSetName;
                CurrentTestProgramSet.Close();
                CurrentTestProgramSet = null;
                OnProjectClosed();
                LogManager.Trace( "Project \"{0}\" has been closed", name );
            }
        }


        public static void CreateProject()
        {
            var form = new ATMLProjectCreationForm(); //ObjectNameForm("Create Test Program Set Name");
            //form.RegularExpression = @"^([A-Z]|[a-z]|[0-9]|_|-|\.|\s)+$";
            if (DialogResult.OK == form.ShowDialog())
            {
                UUTDescription uut = form.UutDescription;
                CreateProject( form.ProjectInfo );

                //UutManager.FindUUT()

                //--- Check if uut exists or not ---//
                var bean = new AssetIdentificationBean();
                bean.assetType = "Part";
                bean.assetNumber = uut.name;
                bean.uuid = Guid.Parse( uut.uuid );

                //DocumentManager.SaveDocument( new Document());
            }
        }


        public static void CreateProject( ProjectInfo projectInfo )
        {
            //--- Prompt for a test set name ---//
            //--- Check if the name exisists ---//
            //--- If name exists then notify the user, ask if they want to open that test set ---//
            //--- Otherwise create the test set and open it ---//
            if (projectInfo != null)
            {
                TestProgramSet currentTestProgramSet = TestProgramSet.CreateTestSet( projectInfo.ProjectName );
                if (currentTestProgramSet != null)
                {
                    SaveProjectInfo( projectInfo, currentTestProgramSet );
                    OpenProject( projectInfo.ProjectName );
                    Document uutDescriptionDocument = DocumentManager.GetDocument( projectInfo.UutId );
                    if (uutDescriptionDocument != null)
                    {
                        SaveATMLDocument( UutManager.BuildAtmlFileName( projectInfo.UutName ),
                                          AtmlFileType.AtmlTypeUut,
                                          uutDescriptionDocument.DocumentContent );
                    }

                    //--- Create a Test Description ---//
                    if (uutDescriptionDocument != null)
                    {
                        var uutDoc = new DocumentReference();
                        uutDoc.ID = "UUT1";
                        uutDoc.uuid = uutDescriptionDocument.uuid;
                        var uutRef = new ItemDescriptionReference();
                        uutRef.Item = uutDoc;
                        var testConfiguration = new TestConfiguration15();
                        testConfiguration.uuid = Guid.NewGuid().ToString();
                        testConfiguration.TestedUUTs.Add( uutRef );
                        SaveATMLDocument( projectInfo.ProjectName + ATMLContext.ATML_CONFIG_FILENAME_SUFFIX,
                                          AtmlFileType.AtmlTypeTestConfiguration,
                                          Encoding.UTF8.GetBytes( testConfiguration.Serialize() ) );
                    }
                }
            }
        }

        private static void SaveProjectInfo( ProjectInfo projectInfo, TestProgramSet currentTestProgramSet )
        {
            FileManager.WriteFile( currentTestProgramSet.TestSetDirectory.FullName + @"\project-info.xml",
                                   Encoding.UTF8.GetBytes( projectInfo.Serialize() ) );
        }

        public static void ProcessUutChanges( UUTDescription uut )
        {
            TestProgramSet currentTestProgramSet = Instance.CurrentTestProgramSet;
            if (currentTestProgramSet != null)
            {
                ProjectInfo pi = currentTestProgramSet.ProjectInfo;
                if (pi != null)
                {
                    pi.UutId = uut.uuid;
                    pi.UutName = uut.Item.Identification.ModelName;
                    SaveProjectInfo( pi, currentTestProgramSet );
                }
            }
        }

        public static bool OpenProject( out string testSetName )
        {
            if (HasOpenProject())
                CloseProject();

            testSetName = null;
            //--- Display a list of available test sets and open the one that is selected ---//
            TestProgramSet tps = null;
            if (TestProgramSet.SelectTestSet( out tps ))
            {
                using (new HourGlass())
                {
                    Instance.CurrentTestProgramSet = tps;
                    if (Instance.CurrentTestProgramSet != null)
                    {
                        try
                        {
                            byte[] data =
                                FileManager.ReadFile(
                                    Path.Combine( Instance.CurrentTestProgramSet.TestSetDirectory.FullName,
                                                  ATMLContext.PROJECT_INFO_FILENAME ) );
                            Instance.CurrentTestProgramSet.ProjectInfo = new ProjectInfo( data );
                        }
                        catch (Exception)
                        {
                            ProjectInfo pi = CreateProjectInfoFile();
                            Instance.CurrentTestProgramSet.ProjectInfo = pi;
                        }
                        testSetName = Instance.CurrentTestProgramSet.TestSetName;
                        Instance.OnProjectOpened( testSetName );
                        LogManager.Trace( "Project \"{0}\" has been opened", testSetName );
                    }
                }
            }

            return testSetName != null;
        }
        private static ProjectInfo CreateProjectInfoFile()
        {
            var pi = new ProjectInfo();
            pi.ProjectName = Instance.CurrentTestProgramSet.TestSetName;
            pi.Uuid = Guid.NewGuid().ToString();
            if (UutManager.ProjectHasUUT( pi.ProjectName ))
            {
                UUTDescription uut = UutManager.GetProjectUUT( pi.ProjectName );
                if (uut != null)
                {
                    pi.UutName = uut.name;
                    pi.UutId = uut.uuid;
                }
            }
            string fileName = Path.Combine( ATMLContext.TESTSET_PATH, pi.ProjectName, "project-info.xml" );
            FileManager.WriteFile( fileName, Encoding.UTF8.GetBytes( pi.Serialize() ) );
            LogManager.Warn(
                "Failed to find the project information file so a new file has been created." );
            return pi;
        }

        public static string OpenProject( string projectName )
        {
            string testSetName = null;
            ProjectManager pm = Instance;
            TestProgramSet tps = TestProgramSet.OpenTestSet( projectName );
            if (tps != null)
            {
                if (HasOpenProject())
                    CloseProject();
                pm.CurrentTestProgramSet = tps;

                string projectFileName = Path.Combine( Instance.CurrentTestProgramSet.TestSetDirectory.FullName,
                                                       ATMLContext.PROJECT_INFO_FILENAME );
                if (!FileManager.FileExists( projectFileName ))
                    //Project Info File will not exist if it is an old project format is read.
                {
                    pm.CurrentTestProgramSet.ProjectInfo = CreateProjectInfoFile();
                }
                else
                {
                    byte[] data = FileManager.ReadFile( projectFileName );
                    pm.CurrentTestProgramSet.ProjectInfo = new ProjectInfo( data );
                }
                pm.OnProjectOpened( projectName );
                LogManager.Trace( "Project \"{0}\" has been opened", pm.CurrentTestProgramSet.TestSetName );
            }
            return pm.CurrentTestProgramSet.TestSetName;
        }

        public static bool RenameProject( string oldProjectName, string newProjectName )
        {
            bool projectRenamed = false;
            ProjectManager pm = Instance;
            TestProgramSet ts = pm.CurrentTestProgramSet;
            if (ts != null)
            {
                string oldPath = Path.Combine( ATMLContext.TESTSET_PATH, oldProjectName );
                string newPath = Path.Combine( ATMLContext.TESTSET_PATH, newProjectName );

                try
                {
                    if (Directory.Exists( newPath ))
                    {
                        LogManager.Warn( "Project {0} already exists.", newProjectName );
                    }
                    else
                    {
                        CloseProject();
                        FileManager.CopyFolder( oldPath, newPath, true );
                        OpenProject( newProjectName );
                        FileManager.DeleteDirectory( oldPath, true );
                        ProjectInfo pi = ProjectInfo;
                        pi.ProjectName = newProjectName;
                        SaveProjectInfo( pi, Instance.CurrentTestProgramSet );
                        LogManager.Trace( "Project {0} renamed to {1}.", oldProjectName, newProjectName );
                        //Loop through file looking for old project name - rename with new file names
                        FileManager.RenameProjectFiles( newPath, oldProjectName, newProjectName );
                        projectRenamed = true;
                    }
                }
                catch (Exception e)
                {
                    LogManager.Error( e, "Failed to rename folder {0}\n{1}", newProjectName, e.Message );
                }
            }
            return projectRenamed;
        }

        public static bool HasProject( string projectName )
        {
            return TestProgramSet.HasTestProgramSet( projectName );
        }

        /**
         * Physically remove the project from the project folder. The project must be opened
         * on order to delete it. If the user accepts the verification to delete the project
         * the project will be unloaded then all folders and files will be removed. This process
         * does NOT remove any related files from the document library.
         */
        public static void DeleteProject()
        {
            TestProgramSet testSet = Instance.CurrentTestProgramSet;
            if (testSet != null)
            {
                string testSetName = testSet.TestSetName;
                string fullName = testSet.TestSetDirectory.FullName;
                if (DialogResult.Yes ==
                    MessageBox.Show(
                        string.Format( "Are you sure you want to delete Test Set Project \"{0}\"?", testSetName ),
                        @"V E R I F Y",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question ))
                {
                    HourGlass.Start();
                    try
                    {
                        CloseProject();
                        GC.Collect();
                        if (FileManager.DeleteDirectory( fullName, true ))
                            LogManager.Trace( "Test Set Project \"{0}\" has been deleted.", testSetName );
                    }
                    catch (Exception err)
                    {
                        LogManager.Error( err.Message );
                    }
                    finally
                    {
                        HourGlass.Stop();
                    }
                }
            }
        }

        public static void ImportTestProgramSet()
        {
            String testSetPath = ATMLContext.TESTSET_PATH;
            var dlg = new OpenFileDialog();
            dlg.DefaultExt = ATMLContext.TESTSET_ARCHIVE_EXT;
            if (DialogResult.OK == dlg.ShowDialog())
            {
                string name = dlg.SafeFileName;
                name = name.Substring( 0, name.LastIndexOf( ".", StringComparison.Ordinal ) );
                string path = Path.Combine( testSetPath, name );

                bool ok2save = true;
                bool hasExisting = false;
                if (Directory.Exists( path ))
                {
                    hasExisting = true;
                    ok2save = DialogResult.Yes ==
                              MessageBox.Show(
                                  "Test Program Set \"" + name + "\" already exists. Would you like to over write it?",
                                  "V E R I F Y", MessageBoxButtons.YesNo, MessageBoxIcon.Question );
                }
                if (ok2save)
                {
                    HourGlass.Start();
                    try
                    {
                        CloseProject();
                        ZipFile zip = ZipFile.Read( dlg.FileName );
                        zip.ExtractAll( path, ExtractExistingFileAction.OverwriteSilently );
                        LogManager.Trace( "The Test Program Set has been unarchived to \"{0}\"", path );
                        OpenProject( name );
                    }
                    catch (Exception exception)
                    {
                        LogManager.Error( exception );
                    }
                    finally
                    {
                        HourGlass.Stop();
                    }
                }
            }
        }

        public static void ExportTestProgramSet()
        {
            CreateTestSetArchive();
        }


        public static Boolean HasReaderDocument( string documentName )
        {
            TestProgramSet currenTestProgramSet = Instance.CurrentTestProgramSet;
            if (currenTestProgramSet == null)
                throw new Exception( "There is no test program set opened." );
            return currenTestProgramSet.HasReaderDocument( documentName );
        }

        public static byte[] GetReaderDocument( string documentName )
        {
            TestProgramSet currenTestProgramSet = Instance.CurrentTestProgramSet;
            if (currenTestProgramSet == null)
                throw new Exception( "There is no test program set opened." );
            return currenTestProgramSet.GetReaderDocument( documentName );
        }

        public static void SaveReaderDocument( string documentName, byte[] contentBytes )
        {
            TestProgramSet currenTestProgramSet = Instance.CurrentTestProgramSet;
            if (currenTestProgramSet == null)
                throw new Exception( "There is no test program set opened." );
            currenTestProgramSet.SaveReaderDocument( documentName, contentBytes );
        }

        public static void SaveATMLDocument( string documentName, AtmlFileType atmlType, byte[] contentBytes,
                                             bool forceOverWrite = false )
        {
            TestProgramSet currenTestProgramSet = Instance.CurrentTestProgramSet;
            if (currenTestProgramSet != null)
                currenTestProgramSet.SaveATMLDocument( documentName, atmlType, contentBytes, forceOverWrite );
        }

        public static void RemoveATMLDocument( string documentName, AtmlFileType atmlType )
        {
            TestProgramSet currenTestProgramSet = Instance.CurrentTestProgramSet;
            if (currenTestProgramSet != null)
                currenTestProgramSet.RemoveATMLDocument( documentName, atmlType );
            ATMLNavigator.Instance.RemoveAtmlFile( documentName );
        }

        public static void CreateTestSetArchive()
        {
            TestProgramSet currenTestProgramSet = Instance.CurrentTestProgramSet;
            if (currenTestProgramSet == null)
                throw new Exception( "There is no test program set opened." );
            currenTestProgramSet.CreateTestSetArchive( currenTestProgramSet.TestSetName );
        }
    }
}