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
using System.Text;

namespace ATMLCommonLibrary.model.navigator
{
    public interface IReaderNavigator : INavigator
    {
        event SelectDocumentHandler SelectATMLTestConfiguration;
        event SelectDocumentDataHandler SelectReaderDocument;
        void AddAtmlDocument( FileInfo fi, string documentType );
    }

}
