/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;

namespace ATMLManagerLibrary.events
{
    public class AtmlNavigatorEventArgs : EventArgs
    {
        private FolderType _atmlFolderType;
        private string _fileName;

        public enum FolderType
        {
            Allocator,
            Reader,
            Translator,
            Atml,
            Docs
        }

        public FolderType AtmlFolderType
        {
            get { return _atmlFolderType; }
            set { _atmlFolderType = value; }
        }

        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }
    }
}
