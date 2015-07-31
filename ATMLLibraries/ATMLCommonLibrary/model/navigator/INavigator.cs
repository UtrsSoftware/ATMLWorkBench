/*
* Copyright (c) 2014 Universal Technical Resource Services, inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.IO;

namespace ATMLCommonLibrary.model.navigator
{
    public delegate void NavigationFileHandler(FileInfo fi);

    public delegate void DirectoryDelegate(object sender, DirectoryInfo e, string name, EventArgs args);

    public delegate void SelectDocumentHandler(object sender, FileInfo e);

    public delegate void SelectDocumentDataHandler(object sender, FileInfo e, byte[] data);

    public delegate void NavigationAddDocumentHandler(FileInfo fi, string documentType);

    public interface INavigator
    {
        event NavigationFileHandler FileAdded;
        event NavigationFileHandler FileDeleted;
        event DirectoryDelegate ProjectNameChangeRequested;
    }
}