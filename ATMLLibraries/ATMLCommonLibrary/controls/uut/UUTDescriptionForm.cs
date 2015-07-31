/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Text;
using System.Windows.Forms;
using ATMLModelLibrary;
using ATMLModelLibrary.interfaces;
using ATMLModelLibrary.model.uut;
using ATMLSchemaLibrary.managers;

namespace ATMLCommonLibrary.forms
{
    public partial class UUTDescriptionForm : ATMLForm
    {

        public UUTDescriptionForm()
        {
            InitializeComponent();
            InitViewButton( btnViewATML );
            CloseOnSave = false;
            Saved += delegate { UpdateAtmlViewContent(UUTDescription); };
        }

        public UUTDescription UUTDescription
        {
            get { return uutDescriptionControl1.UUT; }
            set { uutDescriptionControl1.UUT = value; }
        }

        private void chkClassified_CheckedChanged(object sender, EventArgs e)
        {
            //edtSecurityClassification.Visible = chkClassified.Checked;
        }

        private void identificationControl16_Load(object sender, EventArgs e)
        {
        }

        private void btnAddUUID_Click(object sender, EventArgs e)
        {
        }

        private void uutDescriptionControl1_Load(object sender, EventArgs e)
        {
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            StringBuilder error = new StringBuilder(1024 * 1024 * 6);
            UUTDescription uut = UUTDescription;
            if( !SchemaManager.ValidateXml(uut.Serialize(), ATMLCommon.UUTNameSpace, error) )
            {
                ATMLErrorForm.ShowValidationMessage(
                    string.Format("The \"{0}\" UUT has failed validation against the {1} ATML schema.",
                        uut.name, ATMLCommon.UUTNameSpace ),
                    error.ToString(),
                    "Note: This error will not prevent you from continuing.");
            }
            else
            {
                MessageBox.Show(@"This UUT generated valid ATML");
            }
        }

        private void btnViewATML_Click(object sender, EventArgs e)
        {
            ShowAtmlContent(UUTDescription);
        }

    }
}