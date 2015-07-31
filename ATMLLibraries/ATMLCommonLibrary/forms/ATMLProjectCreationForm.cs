/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.ComponentModel;
using System.Windows.Forms;
using ATMLCommonLibrary.controls.uut;
using ATMLModelLibrary.model;
using ATMLModelLibrary.model.uut;
using ATMLUtilitiesLibrary;

namespace ATMLCommonLibrary.forms
{
    public partial class ATMLProjectCreationForm : ATMLForm
    {
        private ProjectInfo _projectInfo;
        private UUTDescription _uutDescription;

        public ATMLProjectCreationForm()
        {
            InitializeComponent();
            edtUUID.Value = Guid.NewGuid().ToString();
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public UUTDescription UutDescription
        {
            get { return _uutDescription; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ProjectInfo ProjectInfo
        {
            get { return _projectInfo; }
        }


        /**
         * To create a new project we need to have a UUT selected - this should be the same UUT identifier located
         * in the TPSI file. TODO: Should we create a project from the TPSI file - open the TPSI here?
         */

        private void btnSelectUUT_Click(object sender, EventArgs e)
        {
            var form = new ATMLLibraryForm(typeof (UUTDescriptionListControl));
            if (DialogResult.OK == form.ShowDialog())
            {
                errorProvider1.SetError(edtProjectName, "");
                errorProvider1.SetError(edtUUT, "");
                _uutDescription = form.SelectedObject as UUTDescription;
                if (_uutDescription != null)
                {
                    edtUUT.Value = _uutDescription.ToString();
                    if (!edtProjectName.HasValue())
                        edtProjectName.Value = _uutDescription.Item.Identification.ModelName;
                }
            }
        }

        private void btnOk_Click_1(object sender, EventArgs e)
        {
            _projectInfo = new ProjectInfo();
            _projectInfo.ProjectTitle = edtProjectName.GetValue<string>();
            _projectInfo.ProjectName = FileUtils.MakeGoodFileName( edtProjectName.GetValue<string>() );
            _projectInfo.Uuid = edtUUID.GetValue<string>();
            if (_uutDescription != null)
            {
                _projectInfo.UutId = _uutDescription.uuid;
                _projectInfo.UutName = _uutDescription.Item.Identification.ModelName;
            }
        }

        private void btnCreateUUID_Click(object sender, EventArgs e)
        {
            edtUUID.Value = Guid.NewGuid().ToString();
        }
    }
}