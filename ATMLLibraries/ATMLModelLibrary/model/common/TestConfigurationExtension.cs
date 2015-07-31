/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System.Text;
using System.Xml;
using System.Xml.Serialization;
using ATMLDataAccessLibrary.model;
using ATMLModelLibrary.interfaces;
using ATMLSchemaLibrary.managers;
using ATMLUtilitiesLibrary;

namespace ATMLModelLibrary.model.common
{
    public partial class TestConfigurationTestEquipmentItem
    {
        public override string ToString()
        {
            return string.Format( "{0}", this.Item );
        }
    }

    public partial class TestConfiguration15 : IAtmlObject
    {
        private bool _classified;
        private bool? _deleted;
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

        [XmlIgnore]
        public string AtmlName { get; set; }

        public bool IsDeleted( bool? deleted = null )
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
            return AtmlName;
        }

        public string GetAtmlFileName()
        {
            return string.Concat( GetAtmlName(), ATMLContext.ATML_CONFIG_FILENAME_SUFFIX );
        }

        public string GetAtmlFileContext()
        {
            return ATMLContext.CONTEXT_TYPE_XML;
        }

        public string GetAtmlFileDescription()
        {
            string description = string.Format("XML Representation of Test Configuration {0}", GetAtmlName());
            return description;
        }

        public dbDocument.DocumentType GetAtmlDocumentType()
        {
            return dbDocument.DocumentType.TEST_CONFIGURATION;
        }

        public AtmlFileType GetAtmlFileType()
        {
            return AtmlFileType.AtmlTypeTestConfiguration;
        }

        public bool Validate( SchemaValidationResult errors )
        {
            object testSubject = this;
            return SchemaManager.Validate( "urn:IEEE-1671.4:2009.03:TestConfiguration", "TestConfiguration", testSubject,
                                           errors );
        }
    }
}