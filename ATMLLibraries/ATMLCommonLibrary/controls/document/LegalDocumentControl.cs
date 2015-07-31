/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ATMLCommonLibrary.controls.document;
using ATMLModelLibrary.model.common;
using ATMLModelLibrary.model.equipment;


namespace ATMLCommonLibrary.controls.hardware
{

    public partial class LegalDocumentControl : DocumentControl
    {
        public Document LegalDocument
        {
            get { ControlsToData();  return base.Document; }
            set { base.Document = value; DataToControls(); }
        }

        public LegalDocumentControl()
        {
            InitializeComponent();
            cmbLegalDocumentType.DataSource = Enum.GetNames(typeof(HardwareItemDescriptionLegalDocumentsItemsChoiceType));
        }

        private void DataToControls()
        {
            Document document = base.Document;
            if ( document != null)
            {
                cmbLegalDocumentType.SelectedItem = Enum.GetName(typeof(HardwareItemDescriptionLegalDocumentsItemsChoiceType), document.LegalDocumentType );
            }
        }

        private void ControlsToData()
        {
            Document document = base.Document;
            if (document != null)
            {
                document.LegalDocumentType = (HardwareItemDescriptionLegalDocumentsItemsChoiceType)Enum.Parse(typeof(HardwareItemDescriptionLegalDocumentsItemsChoiceType), (String)cmbLegalDocumentType.SelectedItem);
            }
        }

    }
}
