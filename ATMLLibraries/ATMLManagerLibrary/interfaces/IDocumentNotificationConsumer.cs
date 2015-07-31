/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ATMLManagerLibrary.interfaces
{
    public interface IDocumentNotificationConsumer
    {
        void DocumentOpened(string documentName);
        void DocumentClosed(string documentName);
        void DocumentRenamed(string oldName, string newName);
        void DocumentDeleted(string documentName);
        void DocumentChanged(string documentName);
    }
}
