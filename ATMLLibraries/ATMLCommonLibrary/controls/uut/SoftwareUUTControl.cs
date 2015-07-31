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
using ATMLCommonLibrary.controls.document;
using ATMLModelLibrary.model.common;
using ATMLModelLibrary.model.uut;

namespace ATMLCommonLibrary.controls.uut
{
    public partial class SoftwareUUTControl : ItemDescriptionControl
    {
        public SoftwareUUTControl()
        {
            InitializeComponent();
            warningTextList.AddColumn( "Warning", "warning" );
            //documentListControl.Initialize( typeof(Document), 
            //                                    typeof(DocumentForm), 
            //                                    new Tuple<string, string, double>("Name", "ToString()", 1.0 )
            //                                    );
            statusCodeListControl.Initialize(typeof(SoftwareUUTStatusCode), 
                                                typeof(UUTStatusCodeForm),
                                                new Tuple<string, string, double>("Id", "codeID", .15),
                                                new Tuple<string, string, double>("Code", "CodeString", .15),
                                                new Tuple<string, string, double>("Meaning", "CodeMeaning", .70)
                                                );
        }

        public SoftwareUUT SoftwareUUT
        {
            get{return ItemDescription as SoftwareUUT; }
            set { ItemDescription = value; }
        }

        override protected void ControlsToData()
        {
            if (itemDescription == null)
                itemDescription = new SoftwareUUT();
            base.ControlsToData();
            var softwareUUT = itemDescription as SoftwareUUT;
            if (softwareUUT != null)
            {
                List<object> warnings = new List<object>();
                if (documentListControl.Items.Count > 0 )
                    warnings.AddRange(documentListControl.Harvest<Document>());
                if (warningTextList.RowCount > 0 )
                    warnings.AddRange(warningTextList.GetColumnValues(0));
                softwareUUT.Warnings = warnings.Count > 0 ? warnings : null;
                softwareUUT.StatusCodes = statusCodeListControl.Harvest<SoftwareUUTStatusCode>();
            }
        }

        override protected void DataToControls()
        {
            base.DataToControls();
            if (itemDescription != null)
            {
                var softwareUUT = itemDescription as SoftwareUUT;
                if (softwareUUT != null)
                {
                    statusCodeListControl.Populate(softwareUUT.StatusCodes);
                    warningTextList.Clear();
                    documentListControl.Clear();
                    if (softwareUUT.Warnings != null)
                    {
                        foreach (var warning in softwareUUT.Warnings)
                        {
                            var text = warning as string;
                            var document = warning as Document;
                            if (!string.IsNullOrWhiteSpace( text ))
                            {
                                warningTextList.AddColumnData( warningTextList.AddRow(), "warning", text );
                            }
                            else if (document != null)
                            {
                                documentListControl.AddListViewObject( document );
                            }
                        }
                    }
                }
            }
        }
    }
}