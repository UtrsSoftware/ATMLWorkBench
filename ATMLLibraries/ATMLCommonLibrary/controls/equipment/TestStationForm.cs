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
using System.Windows.Forms;
using ATMLCommonLibrary.forms;
using ATMLManagerLibrary.managers;
using ATMLModelLibrary;
using ATMLModelLibrary.model.equipment;
using ATMLSchemaLibrary.managers;

namespace ATMLCommonLibrary.controls.equipment
{
    public partial class TestStationForm : ATMLForm
    {
        public TestStationForm()
        {
            InitializeComponent();
            InitViewButton( btnViewATML );
            Saved += delegate { UpdateAtmlViewContent(TestStationDescription); };
            Canceled += delegate
                        {
                            if (!string.IsNullOrWhiteSpace( originalSerializedATMLObject ))
                            {
                                testStationControl2.TestStationDescription =
                                    TestStationDescription11.Deserialize( originalSerializedATMLObject );
                            }
                        };
        }

        [Browsable( false ), DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
        public TestStationDescription11 TestStationDescription
        {
            set
            {
                originalSerializedATMLObject = value.Serialize();
                testStationControl2.TestStationDescription =
                    TestStationDescription11.Deserialize( originalSerializedATMLObject ); //Make a copy of the original
            }
            get { return testStationControl2.TestStationDescription; }
        }

        protected override void OnSaved()
        {
            base.OnSaved();
            TestStationDescription11 testStation = testStationControl2.TestStationDescription;
            if (testStation != null)
                UpdateAtmlViewContent( testStation );
        }

        private void btnCancel_Click_1( object sender, EventArgs e )
        {
        }

        private void btnValidate_Click( object sender, EventArgs e )
        {
            try
            {
                var error = new StringBuilder(1024 * 1024 * 6);
                TestStationDescription11 testStation = TestStationDescription;
                if (testStation != null)
                {
                    if (!SchemaManager.ValidateXml( testStation.Serialize(), ATMLCommon.TestStationNameSpace, error ))
                    {
                        ATMLErrorForm.ShowValidationMessage(
                            string.Format(
                                "The \"{0}\" Test Station has failed validation against the ATML {1} schema.",
                                testStation.name, ATMLCommon.TestStationNameSpace ),
                            error.ToString(),
                            "Note: This error will not prevent you from continuing." );
                    }
                    else
                    {
                        MessageBox.Show( @"This Test Station generated valid ATML" );
                    }
                }
            }
            catch (Exception err)
            {
                LogManager.Error( err );
            }
        }

        private void btnViewATML_Click( object sender, EventArgs e )
        {
            TestStationDescription testStationDescription = testStationControl2.TestStationDescription;
            ShowAtmlContent(testStationDescription);
        }
    }
}