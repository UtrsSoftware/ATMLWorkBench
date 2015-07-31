/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ATMLUtilitiesLibrary
{
    public class FileMonitorList : BlockingCollection<string>
    {
        private readonly string dir =
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        public FileMonitorList()
        {
            var fsw = new 
                FileSystemWatcher(dir);
            fsw.NotifyFilter =
                NotifyFilters.FileName | NotifyFilters.Size | NotifyFilters.LastWrite;
            fsw.Created += fsw_Created;
            fsw.Deleted += fsw_Deleted;
            fsw.EnableRaisingEvents = true;
            string[] files = Directory.GetFiles(dir);
            for (int i = 0; i < files.Length; i++)
            {
                base.Add(files[i]);
            }
        }

        private void fsw_Deleted(object sender, FileSystemEventArgs e)
        {
            Remove(e.FullPath); 
        }

        private void fsw_Created(object sender, FileSystemEventArgs e)
        {
            base.Add(e.FullPath);
        }

        private bool Remove( string itemToRemove)
        {
            lock (this)
            {
                string comparedItem;
                var itemsList = new List<string>();
                do
                {
                    var result = TryTake(out comparedItem);
                    if (!result)
                        return false;
                    if (!comparedItem.Equals(itemToRemove))
                    {
                        itemsList.Add(comparedItem);
                    }
                } while (!(comparedItem.Equals(itemToRemove)));
                Parallel.ForEach(itemsList, Add);
            }
            return true;
        }
    }
}