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
using System.Text;
using ATMLDataAccessLibrary.model;
using ATMLModelLibrary.interfaces;
using ATMLUtilitiesLibrary;

namespace ATMLModelLibrary.model
{

    public partial class TestDescription : IAtmlObject
    {
        private bool? _deleted = null;

        public bool IsDeleted( bool? deleted = null )
        {
            return _deleted ?? false;
            ;
        }

        public string GetAtmlId()
        {
            return _uuid;
        }

        public string GetAtmlName()
        {
            return _name;
        }

        public string GetAtmlFileName()
        {
            return string.Concat( GetAtmlName(), ATMLContext.ATML_TEST_DESC_FILENAME_SUFFIX );
        }

        public string GetAtmlFileContext()
        {
            return ATMLContext.CONTEXT_TYPE_XML;
        }

        public string GetAtmlFileDescription()
        {
            string description = string.Format("XML Representation of Test Description {0}", GetAtmlName());
            return description;
        }

        public dbDocument.DocumentType GetAtmlDocumentType()
        {
            return dbDocument.DocumentType.TEST_DESCRIPTION;
        }

        public AtmlFileType GetAtmlFileType()
        {
            return AtmlFileType.AtmlTypeTestDescription;
        }
    }
}
