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
using ATMLCommonLibrary.controls.instrument;
using ATMLCommonLibrary.controls.lists;
using ATMLModelLibrary.model.common;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.equipment
{
    public partial class TestStationDescriptionInstrumentListControl : ATMLListControl
    {
        private List<TestStationDescriptionInstrument> _testStationDescriptionInstruments = new List<TestStationDescriptionInstrument>();

        public TestStationDescriptionInstrumentListControl()
        {
            InitializeComponent();
            InitListView();
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<TestStationDescriptionInstrument> TestStationDescriptionInstruments
        {
            get
            {
                ControlsToData(); return _testStationDescriptionInstruments; }
            set { _testStationDescriptionInstruments = value;
                DataToControls();
            }
        }

        private void InitListView()
        {
            DataObjectName = "TestStationDescriptionInstrument";
            DataObjectFormType = typeof(TestStationDescriptionInstrumentForm);
            AddColumnData("Id", "ID", .25);
            AddColumnData("Address", "Address", .25);
            AddColumnData("Location", "PhysicalLocation", .50);
            InitializeForm += new FormInitializationDelegate(TestStationDescriptionInstrumentListControl_InitializeForm);
           
            InitColumns();
        }

        void TestStationDescriptionInstrumentListControl_InitializeForm(Form form)
        {
            TestStationDescriptionInstrumentForm instrForm = form as TestStationDescriptionInstrumentForm;
            if (instrForm != null)
            {
                foreach (ListViewItem lvi in Items)
                {
                    TestStationDescriptionInstrument instr = lvi.Tag as TestStationDescriptionInstrument;
                    if (instr != null)
                    {
                        DocumentReference docRef = instr.Item as DocumentReference;
                        if( docRef != null )
                            instrForm.AddSelectedDocumentId( docRef.uuid );
                    }
                }
            }
        }

        private void TestStationDescriptionInstrument1_Load(object sender, EventArgs e)
        {

        }


        private void DataToControls()
        {
            if (_testStationDescriptionInstruments != null)
            {
                lvList.Items.Clear();
                foreach (TestStationDescriptionInstrument obj in _testStationDescriptionInstruments)
                {
                    AddListViewObject(obj);
                }
            }
        }

        private void ControlsToData()
        {
            _testStationDescriptionInstruments = null;
            if (lvList.Items.Count > 0)
            {
                _testStationDescriptionInstruments = new List<TestStationDescriptionInstrument>();
                foreach (ListViewItem lvi in lvList.Items)
                {
                    var obj = (TestStationDescriptionInstrument)lvi.Tag;
                    _testStationDescriptionInstruments.Add(obj);
                }
            }
        }
    }


}
