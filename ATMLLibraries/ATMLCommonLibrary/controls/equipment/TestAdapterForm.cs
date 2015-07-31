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
using ATMLModelLibrary;
using ATMLModelLibrary.model.equipment;
using ATMLSchemaLibrary.managers;

namespace ATMLCommonLibrary.controls.equipment
{
    public partial class TestAdapterForm : ATMLForm
    {
        public TestAdapterForm()
        {
            InitializeComponent();
            InitViewButton(btnViewATML);
            Saved += TestAdapterForm_Saved;
        }

        [Browsable( false ), DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
        public TestAdapterDescription1 TestAdapterDescription
        {
            get { return testAdapterControl1.TestAdapter; }
            set { testAdapterControl1.TestAdapter = value; }
        }

        private void TestAdapterForm_Saved( object sender, EventArgs e )
        {
            UpdateAtmlViewContent( TestAdapterDescription );
            testAdapterControl1.Invalidate();
            Update();
        }

        private void btnValidate_Click( object sender, EventArgs e )
        {
            var error = new StringBuilder( 1024*1024*6 );
            TestAdapterDescription1 adapter = TestAdapterDescription;
            if (!SchemaManager.ValidateXml( adapter.Serialize(), ATMLCommon.TestAdapterNameSpace, error ))
            {
                string name = GetName( adapter );
                ATMLErrorForm.ShowValidationMessage(
                    string.Format( "The \"{0}\" Test Adapter has failed validation against the {1} ATML schema.", name,
                                   ATMLCommon.TestAdapterNameSpace ),
                    error.ToString(), "Note: This error will not prevent you from continuing." );
            }
            else
            {
                MessageBox.Show( @"This Test Adapter generated valid ATML" );
            }
        }

        private static string GetName( TestAdapterDescription1 adapter )
        {
            string name = adapter.name;
            if (string.IsNullOrEmpty( name ))
            {
                if (adapter.Identification != null && !string.IsNullOrEmpty( adapter.Identification.ModelName ))
                {
                    name = adapter.Identification.ModelName;
                }
                else
                {
                    name = adapter.uuid;
                }
            }
            return name;
        }

        private void btnViewATML_Click( object sender, EventArgs e )
        {
            TestAdapterDescription1 testAdapterDescription = testAdapterControl1.TestAdapter;
            ShowAtmlContent( testAdapterDescription );
        }
    }
}