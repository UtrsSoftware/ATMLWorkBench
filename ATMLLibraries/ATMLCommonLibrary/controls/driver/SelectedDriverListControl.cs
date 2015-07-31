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
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.driver
{
    public partial class SelectedDriverListControl : ATMLListControl
    {
        private List<Driver> _drivers = new List<Driver>();

        public SelectedDriverListControl()
        {
            InitializeComponent();
            InitListView();
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<Driver> Drivers
        {
            get
            {
                ControlsToData();
                return (_drivers != null && _drivers.Count == 0) ? null : _drivers;
            }
            set
            {
                _drivers = value;
                DataToControls();
            }
        }

        private void InitListView()
        {
            DataObjectName = "Driver";
            DataObjectFormType = typeof (DriverSelectionForm);
            AddColumnData("Driver", "Driver", 1.0);
            InitColumns();
        }

        private void DataToControls()
        {
            if (_drivers != null)
            {
                lvList.Items.Clear();
                foreach (Driver driver in _drivers)
                {
                    AddListViewObject(driver);
                }
            }
        }

        private void ControlsToData()
        {
            _drivers = null;
            if (lvList.Items.Count > 0)
            {
                _drivers = new List<Driver>();
                foreach (ListViewItem lvi in lvList.Items)
                {
                    var driver = (Driver) lvi.Tag;
                    _drivers.Add(driver);
                }
            }
        }
    }
}