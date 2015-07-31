/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System.Xml.Serialization;
using ATMLDataAccessLibrary.model;
using ATMLModelLibrary.interfaces;
using ATMLUtilitiesLibrary;

namespace ATMLModelLibrary.model.uut
{
    public partial class UUTDescription : IAtmlObject
    {
        private bool? _deleted;
        private bool? _classified;
        private string _securityClassification;

        [XmlAttribute("classified")]
        public bool Classified
        {
            get
            {
                if (_classified.HasValue)
                {
                    return _classified.Value;
                }
                return default(bool);
            }
            set
            {
                _classified = null;
                if (!value) //If the value is false set to null
                    _classified = null;
                else
                    _classified = true;
            }
        }

        [XmlIgnore]
        public bool classifiedSpecified
        {
            get { return _classified.HasValue; }
            set
            {
                if (value == false)
                {
                    _classified = null;
                }
            }
        }


        [XmlAttribute("securityClassification")]
        public string SecurityClassification
        {
            get { return _securityClassification; }
            set { _securityClassification = value; }
        }

        public override string ToString()
        {
            return name + " - " + _item;
        }

        public bool IsDeleted(bool? deleted = null)
        {
            if (deleted != null)
                _deleted = deleted;
            return _deleted ?? false;
        }

        public string GetAtmlId()
        {
            return uuid;
        }

        public string GetAtmlName()
        {
            return FileUtils.MakeGoodFileName(Item.Identification.ModelName);
        }

        public string GetAtmlFileName()
        {
            return string.Concat(GetAtmlName(), ATMLContext.ATML_UUT_FILENAME_SUFFIX);
        }

        public string GetAtmlFileContext()
        {
            return ATMLContext.CONTEXT_TYPE_XML;
        }

        public dbDocument.DocumentType GetAtmlDocumentType()
        {
            return dbDocument.DocumentType.UUT_DESCRIPTION;
        }

        public AtmlFileType GetAtmlFileType()
        {
            return AtmlFileType.AtmlTypeTestConfiguration;
        }

    }
}