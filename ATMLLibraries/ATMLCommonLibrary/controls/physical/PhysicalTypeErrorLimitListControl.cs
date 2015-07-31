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
    public partial class PhysicalTypeErrorLimitListControl : ATMLListControl
    {
        private List<ErrorLimit> _errorLimits;

        public PhysicalTypeErrorLimitListControl()
        {
            InitializeComponent();
            InitListView();
        }

        private void InitListView()
        {
            DataObjectName = "ErrorLimit";
            DataObjectFormType = typeof(PhysicalTypeErrorLimitForm);
            AddColumnData("Uncertainty", "ToString", 1 );
            InitColumns();
        }


        public List<ErrorLimit> ErrorLimits
        {
            get { ControlsToData(); return _errorLimits; }
            set { _errorLimits = value; DataToControls(); }
        }

        protected void DataToControls()
        {
            if (_errorLimits != null)
            {
                lvList.Items.Clear();
                foreach (ErrorLimit errorLimit in _errorLimits)
                {
                    AddListViewObject(errorLimit);
                }
            }
        }

        protected void ControlsToData()
        {
            if (_errorLimits == null)
                _errorLimits = new List<ErrorLimit>();
            _errorLimits.Clear();
            if (lvList.Items.Count > 0)
            {
                foreach (ListViewItem lvi in lvList.Items)
                {
                    _errorLimits.Add(lvi.Tag as ErrorLimit);
                }
            }
        }
    }
}
