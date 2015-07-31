/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.ComponentModel;
using System.Text;
using ATMLCommonLibrary.forms;
using ATMLDataAccessLibrary.db.daos;
using ATMLDataAccessLibrary.managers;
using ATMLDataAccessLibrary.model;
using ATMLManagerLibrary.managers;
using ATMLModelLibrary.model.common;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.capability
{
    public partial class CapabilityReferenceForm : ATMLForm
    {
        //private InstrumentDescription _instrumentDescription = null;
        private DocumentReference _documentReference;

        public CapabilityReferenceForm()
        {
            InitializeComponent();
            capabilityListControl.ReferenceOnly = true;
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public InstrumentDescription InstrumentDescription
        {
            get { return capabilityListControl.InstrumentDescription; }
            set
            {
                capabilityListControl.InstrumentDescription = value;
                /*capabilityListControl.InstrumentDescription = _instrumentDescription;*/
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TestStationDescription11 TestStationDescription
        {
            get { return capabilityListControl.TestStationDescription; }
            set { capabilityListControl.TestStationDescription = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TestAdapterDescription TestAdapterDescription
        {
            get { return capabilityListControl.TestAdapterDescription; }
            set { capabilityListControl.TestAdapterDescription = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DocumentReference DocumentReference
        {
            get
            {
                ControlsToData();
                return _documentReference;
            }
            set
            {
                _documentReference = value;
                DataToControls();
            }
        }


        private void DataToControls()
        {
            if (_documentReference != null)
            {
                Document document = null;

                edtName.Value = _documentReference.ID;
                edtVersion.Value = "";
                edtUUID.Value = _documentReference.uuid;
                if (DocumentManager.HasDocument(_documentReference.uuid))
                {
                    document = DocumentManager.GetDocument(_documentReference.uuid);
                    String xml = Encoding.UTF8.GetString(document.DocumentContent);
                    Capabilities1 capabilities = Capabilities1.Deserialize(xml);
                    capabilityListControl.CapabilityItems = capabilities.Items;
                    _documentReference.DocumentContent = Encoding.UTF8.GetBytes(xml);
                    _documentReference.DocumentType = dbDocument.DocumentType.CAPABILITY_LIBRARY;
                    _documentReference.DocumentName = document.name;
                    _documentReference.ContentType = document.ContentType;
                    if (capabilityListControl.InstrumentDescription != null &&
                        !capabilityListControl.InstrumentDescription.HasDoument(document.uuid))
                    {
                        capabilityListControl.InstrumentDescription.AddDocument(document);
                    }
                    else if (capabilityListControl.TestAdapterDescription != null &&
                             !capabilityListControl.TestAdapterDescription.HasDoument(document.uuid))
                    {
                        capabilityListControl.TestAdapterDescription.AddDocument(document);
                    }
                    else if (capabilityListControl.TestStationDescription != null &&
                             !capabilityListControl.TestStationDescription.HasDoument(document.uuid))
                    {
                        capabilityListControl.TestStationDescription.AddDocument(document);
                    }
                }
            }
        }

        private void ControlsToData()
        {
        }


        private void btnImportCapabilityDocument_Click(object sender, EventArgs e)
        {
            String xml;
            String fileName;
            DocumentDAO dao = DataManager.getDocumentDAO();
            if (FileManager.OpenXmlFile(out xml, out fileName))
            {
                Capabilities1 capabilities = Capabilities1.Deserialize(xml);
                String uuid = capabilities.uuid;
                String name = capabilities.name;
                String version = capabilities.version;
                var document = new dbDocument();
                bool isNew = !dao.hasDocument(uuid);
                _documentReference.DocumentContent = Encoding.UTF8.GetBytes(xml);
                _documentReference.DocumentType = dbDocument.DocumentType.CAPABILITY_LIBRARY;
                _documentReference.DocumentName = document.documentName;
                _documentReference.ContentType = document.contentType;
                if (capabilityListControl.InstrumentDescription != null
                    && !capabilityListControl.InstrumentDescription.HasDoument(document.UUID.ToString()))
                {
                    Document doc = GetDocument(document, xml);
                    capabilityListControl.InstrumentDescription.AddDocument(doc);
                }
                else if (capabilityListControl.TestAdapterDescription != null
                         && !capabilityListControl.TestAdapterDescription.HasDoument(document.UUID.ToString()))
                {
                    Document doc = GetDocument(document, xml);
                    capabilityListControl.TestAdapterDescription.AddDocument(doc);
                }
                else if (capabilityListControl.TestStationDescription != null
                         && !capabilityListControl.TestStationDescription.HasDoument(document.UUID.ToString()))
                {
                    Document doc = GetDocument(document, xml);
                    capabilityListControl.TestStationDescription.AddDocument(doc);
                }
            }
        }

        private static Document GetDocument(dbDocument document, string xml)
        {
            var doc = new Document();
            doc.uuid = document.UUID.ToString();
            doc.name = document.documentName;
            doc.version = document.documentVersion;
            doc.DocumentContent = Encoding.UTF8.GetBytes(xml);
            doc.ContentType = DocumentManager.GetContentType(".xml");
            return doc;
        }

        private void btnSearchDatabase_Click(object sender, EventArgs e)
        {
            //TODO: Browse the database for a Library File. As files are selected - show signals available
            //TODO: Make sure not to select documents already selected ( use uuid )
        }
    }
}