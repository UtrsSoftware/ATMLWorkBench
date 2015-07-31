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
using System.Threading;
using System.Windows.Forms;
using ATMLManagerLibrary.events;
using ATMLManagerLibrary.managers;
using ATMLUtilitiesLibrary;

namespace ATMLCommonLibrary.model.navigator
{
    public class ATMLNavigator : INavigator, IReaderNavigator, ITranslatorNavigator
    {
        private static ATMLNavigator _instance;
        private static object _objectLock = new Object();

        public event NavigationAddDocumentHandler TranslatorDocumentAdded;
        public event NavigationAddDocumentHandler AtmlDocumentAdded;
        public event NavigationAddDocumentHandler TestDescriptionDocumentAdded;
        public event NavigationAddDocumentHandler SourceDocumentAdded;
        public event SelectDocumentHandler SelectDocument;
        public event SelectDocumentHandler SelectATMLDocument;
        public event SelectDocumentHandler SelectATMLUUTDocument;
        public event SelectDocumentHandler SelectATMLTestConfiguration;
        public event SelectDocumentHandler SelectATMLInstrumentDocument;
        public event SelectDocumentHandler SelectATMLTestAdapterDocument;
        public event SelectDocumentHandler SelectATMLTestStationDocument;
        public event SelectDocumentHandler SelectATMLTestDescriptionDocument;
        public event SelectDocumentHandler SelectSourceDocument;
        public event SelectDocumentDataHandler SelectReaderDocument;
        public event NavigationFileHandler FileAdded;
        public event NavigationFileHandler FileDeleted;
        public event EventHandler FileRemoved;
        public event EventHandler TreeRefreshed;
        public event DirectoryDelegate CreateAbfFileClicked;
        public event DirectoryDelegate ProjectNameChangeRequested;

        private ATMLNavigator()
        {
        }

        public FileInfo SelectedFile { get; set; }
        public DirectoryInfo SelectedFolder { get; set; }

        public static ATMLNavigator Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_objectLock)
                    {
                        if (_instance == null)
                        {
                            _instance = new ATMLNavigator();
                        }
                    }
                }
                return _instance;
            }
        }

        protected virtual void OnFileRemoved( AtmlNavigatorEventArgs args )
        {
            EventHandler handler = FileRemoved;
            if (handler != null) handler(this, args);
        }

        public void AddTranslatorDocument(FileInfo fi, string documentType)
        {
            if (fi != null && fi.Exists)
            {
                TranslatorDocumentAdded(fi, documentType);
                if (fi.Exists && fi.Length > 0)
                    OnSelectDocument(fi);
            }
        }

        public void AddAtmlDocument(FileInfo fi, string documentType)
        {
            if (fi != null && fi.Exists)
            {
                AtmlDocumentAdded(fi, documentType);
                if (fi.Exists && fi.Length > 0)
                    OnSelectDocument(fi);
            }
        }


        public void AddTestDescriptionDocument(FileInfo fi)
        {
            if (fi != null && fi.Exists)
            {
                //OnOnAddTestDescriptionDocument(fi);
                if (fi.Exists && fi.Length > 0)
                    OnSelectDocument(fi);
            }
        }

        public FileInfo GetSelectedFile()
        {
            return SelectedFile;
        }

        protected virtual void OnTreeRefreshed()
        {
            EventHandler handler = TreeRefreshed;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        public void RefreshTree()
        {
        }

        public void ClearFiles()
        {
            SelectedFile = null;
            SelectedFolder = null;
        }

        protected virtual void OnDeleteFile(FileInfo fi)
        {
            NavigationFileHandler handler = FileDeleted;
            if (handler != null) handler(fi);
        }

        protected virtual void OnAddFile(FileInfo fi)
        {
            NavigationFileHandler handler = FileAdded;
            if (handler != null) handler(fi);
        }

        protected virtual void OnProjectNameChangeRequested(DirectoryInfo e, string newName, EventArgs args)
        {
            DirectoryDelegate handler = ProjectNameChangeRequested;
            if (handler != null) handler(this, e, newName, args );
        }


        public void AddSourceDocument(FileInfo fi)
        {
            if (fi != null && fi.Exists)
            {
                SourceDocumentAdded(fi, "source");
                OnSelectSourceDocument(fi);
            }
        }

        protected virtual void OnCreateAbfFileClicked(DirectoryInfo e, string name)
        {
            DirectoryDelegate handler = CreateAbfFileClicked;
            if (handler != null) handler(this, e, name, null );
        }

        protected virtual void OnSelectAtmlDocument(FileInfo e)
        {
            SelectDocumentHandler handler = SelectATMLDocument;
            if (handler != null) handler(this, e);
        }

        protected virtual void OnSelectDocument(FileInfo e)
        {
            SelectDocumentHandler handler = SelectDocument;
            if (handler != null) handler(this, e);
        }

        protected virtual void OnSelectATMLInstrument(FileInfo e)
        {
            SelectDocumentHandler handler = SelectATMLInstrumentDocument;
            if (handler != null) handler(this, e);
        }

        protected virtual void OnSelectATMLUUT(FileInfo e)
        {
            SelectDocumentHandler handler = SelectATMLUUTDocument;
            if (handler != null) handler(this, e);
        }

        protected virtual void OnSelectAtmlTestAdapterDocument(FileInfo e)
        {
            SelectDocumentHandler handler = SelectATMLTestAdapterDocument;
            if (handler != null) handler(this, e);
        }

        protected virtual void OnSelectAtmlTestStationDocument(FileInfo e)
        {
            SelectDocumentHandler handler = SelectATMLTestStationDocument;
            if (handler != null) handler(this, e);
        }

        public void RemoveAtmlFile( string fileName )
        {
            AtmlNavigatorEventArgs args = new AtmlNavigatorEventArgs();
            args.FileName = fileName;
            args.AtmlFolderType = AtmlNavigatorEventArgs.FolderType.Atml;
            OnFileRemoved( args );
        }

        public void AddFiles(DirectoryInfo di)
        {
            if (di != null)
            {
                var files = new List<FileInfo>();
                if (FileManager.SelectFiles( files ))
                {
                    foreach (FileInfo fi in files)
                    {
                        bool newFile = true;
                        bool ok2Copy = true;
                        string target = Path.Combine( di.FullName, fi.Name );
                        if (File.Exists( target ))
                        {
                            newFile = false;
                            ok2Copy = false;
                            string message =
                                string.Format( "File \"{0}\" already exists, would you like to overwrite it?",
                                               fi.Name );
                            if (DialogResult.Yes == MessageBox.Show( message,
                                                                     @"V E R I F Y",
                                                                     MessageBoxButtons.YesNo,
                                                                     MessageBoxIcon.Question ))
                            {
                                FileManager.DeleteFile( target );
                                ok2Copy = true;
                                //TODO: Overwrite file needs to be implemented.
                                //LogManager.Warn( "Overwrite file needs to be implemented." );
                            }
                        }
                        if (ok2Copy)
                        {
                            File.Copy( fi.FullName, target );
                            if (newFile)
                            {
                                var fileNew = new FileInfo( target );
                                OnAddFile( fileNew );
                            }
                        }
                    }
                }
            }
        }

        public void RenameProject(DirectoryInfo di, string newName, EventArgs args)
        {
            OnProjectNameChangeRequested(di, newName, args);
        }

        public bool DeleteFile(FileInfo fi)
        {
            bool deleted = false;
            string message = string.Format("Are you sure you want to delete file \"{0}\"", fi.Name);
            //TODO: Put In Message Database
            if (DialogResult.Yes ==
                MessageBox.Show(message, @"V E R I F Y", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                string name = fi.Name;
                DateTime now = DateTime.Now;
                fi.IsReadOnly = false;
                fi.Delete();
                OnDeleteFile(fi);
                LogManager.Info("File Deleted - File:{0} Date:{1} {2}",
                    name,
                    now.ToShortDateString(),
                    now.ToShortTimeString());
                deleted = true;
            }
            return deleted;
        }

        /**
         * Called when the Navigator Tree item has been double clicked.
         */

        public void SelectTreeDocument()
        {
            if (SelectedFolder != null && SelectedFile != null)
            {
                if (SelectedFolder.Name == @"atml")
                {
                    if (SelectedFile.Name.Contains("1671.1"))
                    {
                        OnSelectATMLTestDescriptionDocument(SelectedFile);
                    }
                    else if (SelectedFile.Name.Contains("1671.2"))
                    {
                        OnSelectATMLInstrument(SelectedFile);
                    }
                    else if (SelectedFile.Name.Contains("1671.3"))
                    {
                        OnSelectATMLUUT(SelectedFile);
                        OnSelectDocument(SelectedFile); 
                    }
                    else if (SelectedFile.Name.Contains("1671.4"))
                    {
                        OnSelectAtmlTestConfiguration(SelectedFile);
                    }
                    else if (SelectedFile.Name.Contains("1671.5"))
                    {
                        OnSelectAtmlTestAdapterDocument(SelectedFile);
                    }
                    else if (SelectedFile.Name.Contains("1671.6"))
                    {
                        OnSelectAtmlTestStationDocument(SelectedFile);
                    }
                    else
                    {
                        OnSelectAtmlDocument(SelectedFile);
                    }
                }
                else if (SelectedFolder.Name == @"reader")
                {
                    OnSelectReaderDocument(SelectedFile);
                }
                else if (SelectedFolder.Name == @"source")
                {
                    OnSelectSourceDocument(SelectedFile);
                }
                else
                {
                    OnSelectDocument(SelectedFile);
                }
            }
        }

        protected virtual void OnSelectReaderDocument(FileInfo e)
        {
            SelectDocumentDataHandler handler = SelectReaderDocument;
            if (handler != null) handler(this, e, File.ReadAllBytes(e.FullName));
        }

        protected virtual void OnSelectAtmlTestConfiguration(FileInfo e)
        {
            SelectDocumentHandler handler = SelectATMLTestConfiguration;
            if (handler != null) handler(this, e);
        }

        protected virtual void OnSelectATMLTestDescriptionDocument(FileInfo e)
        {
            SelectDocumentHandler handler = SelectATMLTestDescriptionDocument;
            if (handler != null) handler(this, e);
        }

        protected virtual void OnSelectSourceDocument(FileInfo e)
        {
            SelectDocumentHandler handler = SelectSourceDocument;
            if (handler != null) handler(this, e);
        }

        public void CreateAbfFile(DirectoryInfo di)
        {
            OnCreateAbfFileClicked(di, "");
        }
    }
}