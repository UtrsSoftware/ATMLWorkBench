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

namespace ATMLCommonLibrary.controls.driver.platform
{
    public partial class DriverControlOperatingSystemListControl : ATMLListControl
    {
        private List<DriverPlatformOperatingSystem> _osList = new List<DriverPlatformOperatingSystem>();

        public DriverControlOperatingSystemListControl()
        {
            InitializeComponent();
            InitListView();
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<DriverPlatformOperatingSystem> OSList
        {
            get
            {
                ControlsToData();
                return (_osList != null && _osList.Count == 0) ? null : _osList;
            }
            set
            {
                _osList = value;
                DataToControls();
            }
        }

        private void InitListView()
        {
            DataObjectName = "OperatingSystem";
            DataObjectFormType = typeof (DriverPlatformOperatingSystemForm);
            AddColumnData("Operating System", "ToString()", 1.0);
            InitColumns();
        }

        private void DataToControls()
        {
            if (_osList != null)
            {
                lvList.Items.Clear();
                foreach (DriverPlatformOperatingSystem operatingSystem in _osList)
                {
                    AddListViewObject(operatingSystem);
                }
            }
        }

        private void ControlsToData()
        {
            _osList = null;
            if (lvList.Items.Count > 0)
            {
                _osList = new List<DriverPlatformOperatingSystem>();
                foreach (ListViewItem lvi in lvList.Items)
                {
                    var operatingSystem = (DriverPlatformOperatingSystem) lvi.Tag;
                    _osList.Add(operatingSystem);
                }
            }
        }
    }
}