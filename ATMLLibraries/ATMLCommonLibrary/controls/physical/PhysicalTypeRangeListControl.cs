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
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ATMLCommonLibrary.controls.lists;
using ATMLModelLibrary.model;

namespace ATMLCommonLibrary.controls.physical
{
    public partial class PhysicalTypeRangeListControl : ATMLListControl
    {
        private List<RangingInformation> _ranges;
        public PhysicalTypeRangeListControl()
        {
            InitializeComponent();
            InitListView();
        }

        public List<RangingInformation> Ranges
        {
            get { return _ranges; }
            set { _ranges = value; }
        }

        private void InitListView()
        {
            DataObjectName = "Range";
            DataObjectFormType = typeof(PhysicalTypeRangeForm);
            AddColumnData("Range", "ToString", 1);
            InitColumns();
        }

        protected void DataToControls()
        {
            if (Ranges != null)
            {
                lvList.Items.Clear();
                foreach (RangingInformation range in Ranges)
                {
                    AddListViewObject(range);
                }
            }
        }

        protected void ControlsToData()
        {
            if (_ranges == null)
                _ranges = new List<RangingInformation>();
            _ranges.Clear();
            if (lvList.Items.Count > 0)
            {
                foreach (ListViewItem lvi in lvList.Items)
                {
                    _ranges.Add(lvi.Tag as RangingInformation);
                }
            }
        }

    }
}
