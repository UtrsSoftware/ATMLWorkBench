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

namespace ATMLUtilitiesLibrary
{
    public interface UTRSFileWatchable
    {
        void FileChanged( object sender, FileSystemEventArgs fileSystemEventArgs );
        void FileCreated( object sender, FileSystemEventArgs fileSystemEventArgs );
        void FileDeleted( object sender, FileSystemEventArgs fileSystemEventArgs );
        void FileRenamed( object sender, FileSystemEventArgs fileSystemEventArgs );
    }

    public sealed class UTRSFileWatcher
    {
        private static UTRSFileWatcher _instance;
        private static readonly object _lock = new object();

        private readonly Dictionary<UTRSFileWatchable, FileSystemWatcher> _fileWatchers;

        private UTRSFileWatcher()
        {
            _fileWatchers = new Dictionary<UTRSFileWatchable, FileSystemWatcher>();
        }

        public static UTRSFileWatcher Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                            _instance = new UTRSFileWatcher();
                    }
                }
                return _instance;
            }
        }

        public void WatchFile( UTRSFileWatchable sender, string documentPath, string documentName )
        {
            if (!_fileWatchers.ContainsKey( sender ))
            {
                var watcher = new FileSystemWatcher();
                watcher.Path = documentPath;
                watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName |
                                       NotifyFilters.DirectoryName;
                // Only watch text files.
                watcher.Filter = documentName;
                watcher.Changed += sender.FileChanged;
                watcher.Created += sender.FileCreated;
                watcher.Deleted += sender.FileDeleted;
                watcher.Renamed += sender.FileRenamed;
                watcher.EnableRaisingEvents = true;
                _fileWatchers.Add( sender, watcher );
            }
        }

        public bool ReleaseWatcher( UTRSFileWatchable sender )
        {
            bool ok = false;
            if (_fileWatchers.ContainsKey( sender ))
            {
                _fileWatchers.Remove( sender );
                GC.Collect();
                ok = true;
            }
            return ok;
        }

        public bool PauseWatcher( UTRSFileWatchable sender )
        {
            return ChangeWatcherState( sender, false );
        }

        public bool RestartWatcher( UTRSFileWatchable sender )
        {
            return ChangeWatcherState( sender, true );
        }

        private bool ChangeWatcherState( UTRSFileWatchable sender, bool state )
        {
            bool ok = false;
            if (_fileWatchers.ContainsKey( sender ))
            {
                FileSystemWatcher watcher = _fileWatchers[sender];
                watcher.EnableRaisingEvents = state;
                ok = true;
            }
            return ok;
        }
    }
}