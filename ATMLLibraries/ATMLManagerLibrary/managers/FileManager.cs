/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Threading;
using System.Windows.Forms;
using ATMLModelLibrary.interfaces;
using ATMLModelLibrary.model;
using ATMLModelLibrary.model.common;
using ATMLModelLibrary.model.equipment;
using ATMLModelLibrary.model.uut;
using ATMLUtilitiesLibrary;
using Path = System.IO.Path;

namespace ATMLManagerLibrary.managers
{
    public delegate void FileSavedHandler(object sender, string fileName, byte[] content, AtmlFileType atmlFileType);

    /**
     * Provides common file access management methods. The FileManager is implemented as a Singleton
     * where a single instance is shared throught the application.
     * @author Paul Garrison
     * @date January 2014
     */

    public class FileManager
    {
        private static FileManager _instance;
        private FileSystemWatcher _fileWatcher;

        private FileManager()
        {
        }

        public static void RenameProjectFiles( string projectPath, string oldName, string newName )
        {
            List<string> fileList = new List<string>();
            GetFileNames(fileList, projectPath, true, "*" + oldName + "*.*");
            int i = 0;
        }


        public void RenameFile( string oldName, string newName )
        {
            FileInfo fi = new FileInfo( oldName );
            fi.MoveTo( newName );
        }


        public FileSystemWatcher FileWatcher
        {
            set { _fileWatcher = value; }
        }

        /**
         * Return a common instance of the FileManager object.
         */

        [MethodImpl( MethodImplOptions.Synchronized )]
        public static FileManager getInstance()
        {
            if (_instance == null)
            {
                _instance = new FileManager();
            }
            return _instance;
        }

        public static bool FileExists( string fileName )
        {
            return File.Exists( fileName );
        }


        /**
         * Set the project file that gets monitored for changes such as;
         * new files, file deletions, file renaming and content changes. 
         * All subdirectories will be monitored.
         */

        public static void SetFolderToMonitor( string folder )
        {
            getInstance().InitiFileWatcher( folder );
        }

        /**
         * Call to initialize a File Watcher
         */
        private void InitiFileWatcher( string path )
        {
            if (_fileWatcher == null)
            {
                _fileWatcher = new FileSystemWatcher();
                _fileWatcher.IncludeSubdirectories = true;
                _fileWatcher.NotifyFilter = NotifyFilters.LastAccess |
                                            NotifyFilters.LastWrite |
                                            NotifyFilters.FileName |
                                            NotifyFilters.DirectoryName;
                _fileWatcher.Changed += _fileWatcher_Changed;
                _fileWatcher.Created += _fileWatcher_Created;
                _fileWatcher.Deleted += _fileWatcher_Deleted;
                _fileWatcher.Renamed += _fileWatcher_Renamed;
            }
            _fileWatcher.Path = path;
            _fileWatcher.EnableRaisingEvents = true;
        }

        /**
         * File renamed File Watcher Handler.
         */
        private void _fileWatcher_Renamed( object sender, RenamedEventArgs e )
        {
            Console.WriteLine( "{0} - File {1} has been renamed to {2}", DateTime.Now.ToString( "yyyy-MM-dd H:mm:ss" ),
                               e.OldName, e.Name );
        }

        /**
         * File deleted File Watcher Handler.
         */
        private void _fileWatcher_Deleted(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine( "{0} - File {1} has been deleted", DateTime.Now.ToString( "yyyy-MM-dd H:mm:ss" ), e.Name );
        }

        /**
         * File created File Watcher Handler.
         */
        private void _fileWatcher_Created(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine( "{0} - File {1} has been created", DateTime.Now.ToString( "yyyy-MM-dd H:mm:ss" ), e.Name );
        }

        /**
         * File changed File Watcher Handler.
         */
        private void _fileWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine( "{0} - File {1} has been changed", DateTime.Now.ToString( "yyyy-MM-dd H:mm:ss" ), e.Name );
        }


        /**
         * Displays the file open dialog to allow the user to open an XML file. The directory
         * will not be restored to it's original position, but remain where the file was opened.
         * <br/><br/>
         * <strong>Usage:</strong><br/>
         * <pre>
         *      String xmlData;
         *      if( FileManager.OpenXmlFile( out xmlData ) )
         *      {
         *          // Do Something with xmlData
         *      }
         * </pre>
         * @param[out] xmlContent - The content of the selected file
         * @return true if a file was selected
         */

        public static bool OpenXmlFile( out String xmlContent )
        {
            String fileName = "";
            return OpenFile( out xmlContent, out fileName, "XML files (*.xml)|*.xml|All files (*.*)|*.*" );
        }

        /**
         * Call to open an XML file. This method will open the Open File Dialog using a *.xml filter.
         * @param out xmlContent - will contain the xml file contents
         * @param out fileName - will contain the selected file name
         */
        public static bool OpenXmlFile( out String xmlContent, out String fileName )
        {
            return OpenFile( out xmlContent, out fileName, "XML files (*.xml)|*.xml|All files (*.*)|*.*" );
        }

        /**
         * Call to open a file. This method will open the Open File Dialog using the filter provided.
         * @param out xmlContent - will contain the xml file contents
         * @param out fileName - will contain the selected file name
         * @param filter - file filter to use to restrict files listed for selection.
         */
        public static bool OpenFile(out String xmlContent, out String fileName, String filter)
        {
            bool fileOpened = false;
            xmlContent = "";
            fileName = "";
            Stream inputStream = null;
            var openFileDlg = new OpenFileDialog();

            openFileDlg.Filter = filter;
            openFileDlg.FilterIndex = 1;
            openFileDlg.RestoreDirectory = false;

            if (openFileDlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    fileName = openFileDlg.FileName;
                    if (( inputStream = openFileDlg.OpenFile() ) != null)
                    {
                        using (inputStream)
                        {
                            var reader = new StreamReader( inputStream );
                            xmlContent = reader.ReadToEnd();
                            reader.Close();
                            fileOpened = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show( String.Format( MessageManager.getMessage( "FileManager.ReadFileError" ), ex.Message ) );
                }
            }
            return fileOpened;
        }

        public static bool OpenFile( out byte[] byteContent, out FileInfo fileInfo )
        {
            bool results = OpenFile( out byteContent, out fileInfo, "All files (*.*)|*.*" );
            return results;
        }

        public static bool OpenFile( out byte[] byteContent, out FileInfo fileInfo, String filter )
        {
            bool fileOpened = false;
            fileInfo = null;
            byteContent = new byte[] {};
            string fileName = "";
            var openFileDlg = new OpenFileDialog();

            openFileDlg.Filter = filter;
            openFileDlg.FilterIndex = 1;
            openFileDlg.RestoreDirectory = false;


            if (openFileDlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    fileName = openFileDlg.FileName;
                    fileInfo = new FileInfo( fileName );
                    byteContent = File.ReadAllBytes( fileName );
                    fileOpened = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show( String.Format( MessageManager.getMessage( "FileManager.ReadFileError" ), ex.Message ) );
                }
            }
            return fileOpened;
        }


        /**
         * Displays the Folder Selection dialog and returns the selected path.
         * <br/><br/>
         * <strong>Usage:</strong><br/>
         * <pre>
         *      String selectedPath;
         *      if( FileManager.OpenFolder( out selectedPath ) )
         *      {
         *          // Do Something with selectedPath
         *      }
         * </pre>
         * @param[out] selectedPath - The selected path
         * @return true if a path was selected
         */

        public static bool OpenFolder( out String selectedPath )
        {
            bool opened = false;
            selectedPath = null;
            var browser = new FolderBrowserDialog();
            if (DialogResult.OK == browser.ShowDialog())
            {
                selectedPath = browser.SelectedPath;
                opened = true;
            }
            return opened;
        }


        /**
         * Returns a list of sub folders found in the starting location provided.
         * @param[in] startingLocation - The starting location (directory)
         * @return a list of strings containing the names of all the sub directories in the starting location.
         */

        public static List<string> GetFolderNames( string startingLocation )
        {
            var folders = new List<string>();
            var di = new DirectoryInfo( startingLocation );
            foreach (DirectoryInfo subDir in di.EnumerateDirectories())
            {
                folders.Add( subDir.Name );
            }
            return folders;
        }

        public static bool WriteFile( byte[] fileContent )
        {
            return WriteFile( fileContent, null );
        }

        public static bool WriteFile( byte[] fileContent, string fileName )
        {
            return WriteFile(fileContent, "All files (*.*)|*.*", fileName);
        }

        /**
         * 
         * Saves the file contents to a file with the file name that
         * was selected from the File Save dialog.
         * @param fileContent - The contents of the file as a byte[]
         * @return - true if the file was successfully saved
         */

        public static bool WriteFile( byte[] fileContent, string filter, string fileName  )
        {
            bool saved = false;
            try
            {
                Stream fs;
                var saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = filter;
                saveFileDialog1.FilterIndex = 1;
                saveFileDialog1.RestoreDirectory = true;
                if (fileName != null)
                {
                    saveFileDialog1.FileName = fileName;
                    saveFileDialog1.InitialDirectory = Path.GetDirectoryName( fileName );
                }
                if (DialogResult.OK == saveFileDialog1.ShowDialog())
                {
                    fileName = saveFileDialog1.FileName;
                    fs = saveFileDialog1.OpenFile();
                    fs.Write( fileContent, 0, fileContent.Length );
                    fs.Close();
                    saved = true;
                }
            }
            catch (Exception e)
            {
                LogManager.Error( e, "An error has occurred writing to file \"{0}\"", fileName );
            }
            return saved;
        }

        /**
         * Saves the file contents to a file with the file name of that provided.
         * @param fileName - The full name of the file to be saved (ie. file path with file name)
         * @param fileContent - The contents of the file as a byte[]
         * @return - true if the file was successfully saved
         */

        public static bool WriteFile( String fileName, byte[] fileContent )
        {
            bool fileSaved = false;
            try
            {
                using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite))
                {
                    if (fileContent != null)
                    {
                        fs.Write( fileContent, 0, fileContent.Length );
                        fileSaved = true;
                    }
                }
            }
            catch (Exception e)
            {
                LogManager.Error( e, "An error has occurred writing to file \"{0}\"", fileName );
            }
            return fileSaved;
        }


        public static byte[] ReadFile( String fileName )
        {
            FileInfo fi;
            Console.WriteLine("{0} = {1}", fileName, FileUtils.EncodeFileName(fileName));
            return ReadFile( fileName, out fi );
        }

        public static byte[] ReadFile( String fileName, out FileInfo fi )
        {
            fi = new FileInfo( fileName );
            byte[] data;
            var buffer = new byte[16*1024];
            using (Stream fs =  OpenFile( fi, 5 ) )
            {
                using (var ms = new MemoryStream())
                {
                    int read;
                    while (( read = fs.Read( buffer, 0, buffer.Length ) ) > 0)
                    {
                        ms.Write( buffer, 0, read );
                    }
                    data = ms.ToArray();
                }
            }
            return data;
        }

        private static Stream OpenFile( FileInfo fi, int timeOut )
        {
            Stream stream = null;
            try
            {
                stream = File.Open(fi.FullName, FileMode.Open, FileAccess.Read, FileShare.Read);
            }
            catch (Exception e )
            {
                if (timeOut-- <= 0)
                    throw e;

                Thread.Sleep( 100 );
                stream = OpenFile( fi, timeOut );
            }
            return stream;
        }

        /**
         * Returns a list of all the file names within a directory selected from the select folder dialog.
         * <br/><br/>
         * <strong>Usage:</strong><br/>
         * <pre>
         *     xmlEditor.Text = "";
         *     List<String> fileNames = new List<string>();
         *     if (FileManager.GetFileNames(fileNames, true))
         *     {
         *         foreach (String file in fileNames)
         *             xmlEditor.Text += (file + "\r\n");
         *     }
         * </pre>
         * 
         * @param fileList - A List of all file names found in the provided directory name
         * @param recurse - Set to true if sub directories are to be traversed for their files as well
         * 
         */

        public static bool GetFileNames( List<string> fileList, bool recurse )
        {
            return GetFileNames( fileList, recurse, "*.*" );
        }

        public static bool GetFileNames( List<string> fileList, bool recurse, String searchPattern )
        {
            bool foundFiles = false;
            String parentDirectory;
            if (OpenFolder( out parentDirectory ))
                foundFiles = GetFileNames( fileList, parentDirectory, recurse, searchPattern );
            return foundFiles;
        }


        /**
         * Returns a list of all the file names within the specified directory.
         * <br/><br/>
         * <strong>Usage:</strong><br/>
         * <pre>
         *     xmlEditor.Text = "";
         *     List<String> fileNames = new List<string>();
         *     if (FileManager.GetFileNames(fileNames, "C:\\java", true))
         *     {
         *         foreach (String file in fileNames)
         *             xmlEditor.Text += (file + "\r\n");
         *     }
         * </pre>
         * @param fileList - A List of all file names found in the provided directory name
         * @param parentDirectory - The name of the directory to seach for;
         * @param recurse - Set to true if sub directories are to be traversed for their files as well
         * 
         */

        public static bool GetFileNames(List<string> fileList, 
                                        string parentDirectory, 
                                        bool recurse, 
                                        bool useShortNames = false)
        {
            return GetFileNames( fileList, parentDirectory, recurse, "*.*", useShortNames );
        }

        public static bool GetFileNames( List<string> fileList, string parentDirectory, bool recurse,
                                         String searchPattern, bool useShortNames = false )
        {
            // Process the list of files found in the directory. 
            string[] fileEntries = Directory.GetFiles(parentDirectory, searchPattern);
            foreach (string fileName in fileEntries)
            {
                FileInfo fi = new FileInfo( fileName );
                fileList.Add( useShortNames?fi.Name:fileName );
            }

            // Recurse into subdirectories of this directory. 
            if (recurse)
            {
                string[] subdirectoryEntries = Directory.GetDirectories( parentDirectory );
                foreach (string subdirectory in subdirectoryEntries)
                    GetFileNames( fileList, subdirectory, recurse, useShortNames );
            }

            return fileList.Count > 0;
        }

        public static void CopyFolder( string sourceDirName, string destDirName, bool copySubDirs )
        {
            // Get the subdirectories for the specified directory.
            var dir = new DirectoryInfo( sourceDirName );
            DirectoryInfo[] dirs = dir.GetDirectories();

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName );
            }

            // If the destination directory doesn't exist, create it. 
            if (!Directory.Exists( destDirName ))
            {
                Directory.CreateDirectory( destDirName );
            }

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine( destDirName, file.Name );
                file.CopyTo( temppath, false );
            }

            // If copying subdirectories, copy them and their contents to new location. 
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine( destDirName, subdir.Name );
                    CopyFolder( subdir.FullName, temppath, copySubDirs );
                }
            }
        }


        public static bool SelectFiles( List<FileInfo> files )
        {
            bool success = false;

            var dlg = new OpenFileDialog();
            dlg.Multiselect = true;
            if (DialogResult.OK == dlg.ShowDialog())
            {
                foreach (string name in dlg.FileNames)
                    files.Add( new FileInfo( name ) );
                success = true;
            }

            return success;
        }

        public static void DeleteFile( string fullFileName )
        {
            if (File.Exists( fullFileName ))
                File.Delete( fullFileName );
        }

        public static void DeleteDirectory( string path )
        {
            DeleteDirectory( path, false );
        }

        public static bool DeleteDirectory( string path, bool recursive )
        {
            bool deleted = true;
            try
            {
                /*
                // Delete all files and sub-folders?
                if (recursive)
                {
                    // Yep... Let's do this
                    string[] subfolders = Directory.GetDirectories( path );
                    foreach (string s in subfolders)
                    {
                        DeleteDirectory( s, recursive );
                    }
                }

                // Get all files of the folder
                string[] files = Directory.GetFiles( path );
                foreach (string f in files)
                {
                    // Get the attributes of the file
                    FileAttributes attr = File.GetAttributes( f );

                    // Is this file marked as 'read-only'?
                    if (( attr & FileAttributes.ReadOnly ) == FileAttributes.ReadOnly)
                    {
                        // Yes... Remove the 'read-only' attribute, then
                        File.SetAttributes( f, attr ^ FileAttributes.ReadOnly );
                    }

                    // Delete the file
                    File.Delete( f );
                }

                // When we get here, all the files of the folder were
                // already deleted, so we just delete the empty folder
                var di = new DirectoryInfo(path);
                if ((di.Attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                    di.Attributes &= ~FileAttributes.ReadOnly;
                Thread.Sleep( 100 );
                 */
                //Directory.Delete( path, true );

                try { DeleteDir(path); }
                catch (Exception)
                {
                    Thread.Sleep(1000); try { DeleteDir(path); }
                    catch (Exception) { Thread.Sleep(1000); DeleteDir(path); }
                }
            }
            catch (Exception e)
            {
                LogManager.Error( e, "An error has occurred deleting directory \"{0}\"", path );
                deleted = false;
            }
            return deleted;
        }

        private static void DeleteDir( string path )
        {
            ClearAttributes(path);
            Directory.Delete( path, true );
        }

        private static void ClearAttributes(string strDest)
        {
            if (Directory.Exists(strDest))
            {
                DirectoryInfo diFolder = new DirectoryInfo(strDest);
                diFolder.Attributes = FileAttributes.Normal;
                string[] files = files = Directory.GetFiles(strDest);
                foreach (string file in files)
                {
                    File.SetAttributes(file, FileAttributes.Normal);
                }
                string[] subDirs = Directory.GetDirectories(strDest);

                foreach (string dir in subDirs)
                {
                    ClearAttributes(dir);
                }
            }
        }
    }
}