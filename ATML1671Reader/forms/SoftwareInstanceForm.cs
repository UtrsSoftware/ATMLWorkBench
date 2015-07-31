/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System.ComponentModel;
using ATMLCommonLibrary.forms;
using ATMLDataAccessLibrary.model;
using ATMLModelLibrary.model.common;

namespace ATML1671Reader.forms
{
    public partial class SoftwareInstanceForm : ATMLForm
    {
        /**
        * Sets/Gets the document type for the reference control. This will be used when pressing the 
        * "Find" button so that only documents of this type will be presented to the user.
        */
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public dbDocument.DocumentType DocumentType
        {
            set { softwareInstanceControl1.DocumentType = value; }
            get { return softwareInstanceControl1.DocumentType; }
        }

        public SoftwareInstanceForm()
        {
            InitializeComponent();
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SoftwareInstance SoftwareInstance
        {
            get { return softwareInstanceControl1.SoftwareInstance; }
            set { softwareInstanceControl1.SoftwareInstance = value; }
        }
    }
}