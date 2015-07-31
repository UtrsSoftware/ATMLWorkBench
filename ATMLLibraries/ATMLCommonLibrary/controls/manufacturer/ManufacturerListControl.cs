/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using ATMLCommonLibrary.controls.lists;
using ATMLCommonLibrary.forms;
using ATMLModelLibrary.model.common;

namespace ATMLCommonLibrary.controls.manufacturer
{
    public partial class ManufacturerListControl : ATMLListControl
    {
        private List<ManufacturerData> _manufacturers;

        public ManufacturerListControl()
        {
            InitializeComponent();
            InitListView();
            InitializeForm += ManufacturerListControl_InitializeForm;
        }

        void ManufacturerListControl_InitializeForm(Form form)
        {
            var manufacturerForm = form as ManufacturerForm;
            if (manufacturerForm != null)
            {
                manufacturerForm.ValidationEndabled = true;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<ManufacturerData> Manufacturers
        {
            get
            {
                ControlsToData();
                return (_manufacturers != null && _manufacturers.Count == 0) ? null : _manufacturers;
            }
            set
            {
                _manufacturers = value;
                DataToControls();
            }
        }

        private void InitListView()
        {
            DataObjectName = "ManufacturerData";
            DataObjectFormType = typeof (ManufacturerForm);
            AddColumnData("Name", "name", .30);
            AddColumnData("Cage Code", "cageCode", .20);
            AddColumnData("URL", "URL", .50);
            InitColumns();
        }

        public void DataToControls()
        {
            if (_manufacturers != null)
            {
                lvList.Items.Clear();
                foreach (ManufacturerData data in _manufacturers)
                {
                    AddListViewObject(data);
                }
            }
        }

        private void ControlsToData()
        {
            _manufacturers = null;
            if (lvList.Items.Count > 0)
            {
                _manufacturers = new List<ManufacturerData>();
                foreach (ListViewItem lvi in lvList.Items)
                {
                    var resource = (ManufacturerData) lvi.Tag;
                    _manufacturers.Add(resource);
                }
            }
        }
    }
}