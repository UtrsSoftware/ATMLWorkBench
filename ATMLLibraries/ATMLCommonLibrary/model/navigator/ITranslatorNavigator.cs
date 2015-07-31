/*
* Copyright (c) 2014 Universal Technical Resource Services, inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace ATMLCommonLibrary.model.navigator
{
    public interface ITranslatorNavigator
    {
        event NavigationFileHandler FileAdded;
        event NavigationFileHandler FileDeleted;
        event SelectDocumentHandler SelectATMLTestDescriptionDocument;
        event SelectDocumentHandler SelectSourceDocument;
        void AddTranslatorDocument(FileInfo fi, string documentType);
        void AddTestDescriptionDocument(FileInfo fi);
        FileInfo GetSelectedFile();
    }
}