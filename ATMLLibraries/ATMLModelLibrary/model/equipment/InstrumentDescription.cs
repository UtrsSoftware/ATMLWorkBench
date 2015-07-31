/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System.Text;
using System.Xml.Serialization;
using ATMLDataAccessLibrary.db.daos;
using ATMLDataAccessLibrary.model;
using ATMLModelLibrary.interfaces;
using ATMLModelLibrary.model.common;
using ATMLSchemaLibrary.managers;
using ATMLUtilitiesLibrary;

namespace ATMLModelLibrary.model.equipment
{
    public partial class InstrumentDescription : IAtmlObject
    {
        private bool? _deleted = null;

        private bool _classified;
        private string _securityClassification;

        [XmlAttribute]
        public bool classified
        {
            get { return _classified; }
            set { _classified = value; }
        }

        [XmlAttribute]
        public string securityClassification
        {
            get { return _securityClassification; }
            set { _securityClassification = value; }
        }

        public bool Validate(SchemaValidationResult errors)
        {
            object testSubject = this;
            return SchemaManager.Validate("urn:IEEE-1671.2:2012:InstrumentDescription", "InstrumentDescription", testSubject, errors);
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
            return this.Identification.ModelName;
        }

        public string GetAtmlFileName()
        {
            return string.Concat(GetAtmlName(), ATMLContext.ATML_INSTRUMENT_FILENAME_SUFFIX);
        }

        public string GetAtmlFileDescription()
        {
            string description = string.Format( "XML Representation of Instrument Description {0}", GetAtmlName() );
            if (!string.IsNullOrEmpty( this.Description ))
                description = this.Description;
            return description;
        }

        public string GetAtmlFileContext()
        {
            return ATMLContext.CONTEXT_TYPE_XML;
        }

        public dbDocument.DocumentType GetAtmlDocumentType()
        {
            return dbDocument.DocumentType.INSTRUMENT_DESCRIPTION;
        }

        public AtmlFileType GetAtmlFileType()
        {
            return AtmlFileType.AtmlTypeInstrument;
        }
    }

    public partial class Bus
    {
        public void Save()
        {
        }

        public bool Validate(SchemaValidationResult errors)
        {
            object testSubject = this;
            return SchemaManager.Validate("urn:IEEE-1671.2:2012:InstrumentDescription", "Bus", testSubject, errors);
        }
    
    }

}