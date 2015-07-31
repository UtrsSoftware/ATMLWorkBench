/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

//using ATMLManagerLibrary.managers;
using System;
using System.Text;
using System.Xml.Serialization;
using ATMLDataAccessLibrary.db.beans;
using ATMLDataAccessLibrary.db.daos;
using ATMLDataAccessLibrary.model;
using ATMLModelLibrary.interfaces;
using ATMLModelLibrary.model.common;
using ATMLUtilitiesLibrary;

namespace ATMLModelLibrary.model.equipment
{
    public partial class TestAdapterDescription1 : IAtmlObject
    {
        private bool? _deleted;
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


        public void Save()
        {
            string content = Serialize();
            var document = new dbDocument();
            var dao = new DocumentDAO();
            bool documentExists = dao.hasDocument(uuid);
            //if( !documentExists )
            //    LogManager.Trace("Creating new Test Adapter Description with uuid of {0}", uuid);
            //else
            //    LogManager.Trace("Saving Test Adapter Description with uuid of {0}", uuid);

            document.contentType = "text/xml";
            document.documentDescription = "Test Adapter";
            document.documentName = Identification.ModelName;
            document.documentVersion = version;
            document.documentSize = content.Length;
            document.documentTypeId = (int) dbDocument.DocumentType.TEST_ADAPTER_DESCRIPTION;
            document.documentContent = Encoding.UTF8.GetBytes(content);
            document.UUID = Guid.Parse(uuid);
            document.DataState = documentExists ? BASEBean.eDataState.DS_EDIT : BASEBean.eDataState.DS_ADD;
            document.save();

            foreach (IdentificationNumber idNumber in Identification.IdentificationNumbers)
            {
                string type = Enum.GetName(typeof (IdentificationNumberType), idNumber.type);
                string number = idNumber.number;
                var asset = new AssetIdentificationBean();
                asset.assetNumber = number;
                asset.assetType = type;
                asset.uuid = Guid.Parse(uuid);
                asset.DetermineDataState();
                asset.save();
            }
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
            return Identification.ModelName;
        }

        public string GetAtmlFileName()
        {
            return string.Concat(GetAtmlName(), ATMLContext.ATML_ADAPTER_FILENAME_SUFFIX);
        }

        public string GetAtmlFileContext()
        {
            return ATMLContext.CONTEXT_TYPE_XML;
        }

        public dbDocument.DocumentType GetAtmlDocumentType()
        {
            return dbDocument.DocumentType.TEST_ADAPTER_DESCRIPTION;
        }

        public AtmlFileType GetAtmlFileType()
        {
            return AtmlFileType.AtmlTypeTestAdapter;
        }

    }
}