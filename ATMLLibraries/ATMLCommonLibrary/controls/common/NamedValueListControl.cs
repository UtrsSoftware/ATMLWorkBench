/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System.Collections.Generic;
using System.Windows.Forms;
using ATMLCommonLibrary.controls.lists;
using ATMLCommonLibrary.forms;
using ATMLModelLibrary.model.common;

namespace ATMLCommonLibrary.controls.common
{
    public partial class NamedValueListControl : ATMLListControl
    {
        private List<NamedValue> _namedValues;

        public NamedValueListControl()
        {
            InitializeComponent();
            InitListView();
        }

        public List<NamedValue> NamedValues
        {
            get
            {
                ControlsToData();
                return _namedValues != null && _namedValues.Count > 0 ? _namedValues : null;
            }
            set
            {
                _namedValues = value;
                DataToControls();
            }
        }

        private void InitListView()
        {
            DataObjectName = "NamedValue";
            DataObjectFormType = typeof (NameValueForm);
            AddColumnData("Name", "name", .50);
            AddColumnData("Value", "ToString()", .50);
            InitColumns();
        }

        private void ControlsToData()
        {
            _namedValues = null;
            if (Items.Count > 0)
            {
                _namedValues = new List<NamedValue>();
                foreach (ListViewItem lvi in Items)
                    _namedValues.Add((NamedValue) lvi.Tag);
            }
        }

        private void DataToControls()
        {
            if (_namedValues != null)
            {
                Items.Clear();
                foreach (NamedValue namedValue in _namedValues)
                    AddListViewObject(namedValue);
            }
        }
    }
}