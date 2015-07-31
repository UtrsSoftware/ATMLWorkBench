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
using ATML1671Reader.forms;
using ATMLModelLibrary.model.common;

namespace ATML1671Reader.controls
{
    public partial class TestProgramDocumentationListControl : ATMLCommonLibrary.controls.lists.ATMLListControl
    {

        private List<TestConfigurationDocumentation> _documentations =
            new List<TestConfigurationDocumentation>();


        public TestProgramDocumentationListControl()
        {
            InitializeComponent();
            InitListView();
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<TestConfigurationDocumentation> TestConfigurationDocumentation
        {
            get
            {
                ControlsToData();
                return _documentations;
            }
            set
            {
                _documentations = value;
                DataToControls();
            }
        }

        private void InitListView()
        {
            DataObjectName = "TestConfigurationDocumentation";
            DataObjectFormType = typeof(TestProgramDocumentationForm);
            AddColumnData("Doc. No.", "documentNumber", .20);
            AddColumnData("Location", "location", .20);
            AddColumnData("Name", "name", .20);
            AddColumnData("UUID", "uuid", .40);
            InitColumns();
        }

        private void DataToControls()
        {
            if (_documentations != null)
            {
                lvList.Items.Clear();
                foreach (TestConfigurationDocumentation doc in _documentations)
                {
                    AddListViewObject(doc);
                }
            }
        }

        private void ControlsToData()
        {
            _documentations = null;
            if (lvList.Items.Count > 0)
            {
                _documentations = new List<TestConfigurationDocumentation>();
                foreach (ListViewItem lvi in lvList.Items)
                {
                    var doc = (TestConfigurationDocumentation)lvi.Tag;
                    _documentations.Add(doc);
                }
            }
        }

    }
}
