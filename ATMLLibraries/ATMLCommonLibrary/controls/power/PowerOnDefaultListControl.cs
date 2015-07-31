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

namespace ATMLCommonLibrary.controls.power
{
    public partial class PowerOnDefaultListControl : ATMLListControl
    {
        private List<NamedValue> _powerOnDefaults = new List<NamedValue>();

        public PowerOnDefaultListControl()
        {
            InitializeComponent();
            InitListView();
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<NamedValue> PowerOnDefaults
        {
            get
            {
                ControlsToData();
                return _powerOnDefaults;
            }
            set
            {
                _powerOnDefaults = value;
                DataToControls();
            }
        }

        private void InitListView()
        {
            ListName = "Power on Default";
            DataObjectName = "NamedValue";
            DataObjectFormType = typeof (NameValueForm);
            AddColumnData("Name", "name", .25);
            AddColumnData("Value", "ToString()", .75);
            InitColumns();
        }

        private void DataToControls()
        {
            if (_powerOnDefaults != null)
            {
                foreach (NamedValue namedValue in _powerOnDefaults)
                {
                    var lvi = new ListViewItem(namedValue.name);
                    lvi.SubItems.Add(namedValue.ToString());
                    lvi.Tag = namedValue;
                    lvList.Items.Add(lvi);
                }
            }
        }

        private void ControlsToData()
        {
            if (Items.Count == 0)
                _powerOnDefaults = null;
            else if (_powerOnDefaults == null)
                _powerOnDefaults = new List<NamedValue>();
            else
                _powerOnDefaults.Clear();

            if (_powerOnDefaults != null)
            {
                foreach (ListViewItem lvi in Items)
                {
                    var value = lvi.Tag as NamedValue;
                    _powerOnDefaults.Add(value);
                }
            }
        }
    }
}