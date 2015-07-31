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
using ATMLModelLibrary.model.common;
using ATMLSchemaLibrary.managers;

namespace ATMLModelLibrary.model.equipment
{

    public partial class OperationalRequirements
    {
        public bool Validate(SchemaValidationResult errors)
        {
            object testSubject = this;
            return SchemaManager.Validate("urn:IEEE-1671:2010:HardwareCommon", "OperationalRequirements", testSubject, errors);
        }
    }


    public partial class HardwareItemDescription
    {

       public bool HasDoument(String guid)
        {
            bool hasDocument = false;
            if (this.Documentation != null)
            {
                foreach (Document document in this.Documentation)
                {
                    if (document.uuid.Equals(guid))
                    {
                        hasDocument = true;
                        break;
                    }
                }
            }
            return hasDocument;
        }

        public Document FindDoument(String guid)
        {
            Document foundDocument = null;
            foreach (Document document in this.Documentation)
            {
                if (document.uuid.Equals(guid))
                {
                    foundDocument = document;
                    break;
                }
            }
            return foundDocument;
        }

        public void AddDocument(Document document)
        {
            if (String.IsNullOrEmpty(document.uuid))
                document.uuid = Guid.NewGuid().ToString();
            if (!HasDoument(document.uuid))
            {
                List<Document> list = new List<Document>();
                if (Documentation != null)
                    list = Documentation.ToList();
                list.Add(document);
                Documentation = list;
            }

        }

    }


}
