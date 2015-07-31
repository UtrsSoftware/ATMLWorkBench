/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System.ComponentModel;
using ATMLCommonLibrary.controls;
using ATMLCommonLibrary.controls.document;
using ATMLModelLibrary.model.common;

namespace ATML1671Reader.controls
{
    public partial class TestProgramDocumentationControl : DocumentControl
    {
        public TestProgramDocumentationControl()
        {
            InitializeComponent();
        }

        [Browsable( false ), DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
        public TestConfigurationDocumentation TestConfigurationDocumentation
        {
            set
            {
                base._document = value;
                DataToControls();
            }
            get
            {
                ControlsToData();
                return _document as TestConfigurationDocumentation;
            }
        }

        protected override void DataToControls()
        {
            base.DataToControls();
            var testConfigurationDocumentation = base._document as TestConfigurationDocumentation;
            if (testConfigurationDocumentation != null)
            {
                edtDocumentNumber.Value = testConfigurationDocumentation.documentNumber;
                edtLocation.Value = testConfigurationDocumentation.location;
            }
        }

        protected override void ControlsToData()
        {
            if (base._document == null)
                base._document = new TestConfigurationDocumentation();
            base.ControlsToData();
            var testConfigurationDocumentation = base._document as TestConfigurationDocumentation;
            if (testConfigurationDocumentation != null)
            {
                testConfigurationDocumentation.documentNumber = edtDocumentNumber.GetValue<string>();
                testConfigurationDocumentation.location = edtLocation.GetValue<string>();
            }
        }
    }
}