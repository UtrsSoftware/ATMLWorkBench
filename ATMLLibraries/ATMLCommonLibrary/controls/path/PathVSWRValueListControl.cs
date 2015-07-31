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
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.path
{
    public partial class PathVSWRValueListControl : ATMLCommonLibrary.controls.lists.ATMLListControl
    {
        private List<PathVSWRValue> _pathVSWR = new List<PathVSWRValue>();

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<PathVSWRValue> PathVSWR
        {
            get { ControlsToData(); return (_pathVSWR != null && _pathVSWR.Count == 0) ? null : _pathVSWR; ; }
            set { _pathVSWR = value; DataToControls(); }
        }
        public PathVSWRValueListControl()
        {
            InitializeComponent();
            InitListView();
        }
        private void InitListView()
        {
            DataObjectName = "PathVSWRValue";
            DataObjectFormType = typeof(PathVSWRValueForm);
            AddColumnData("Frequency", "Frequency", .50);
            AddColumnData("Input Port", "inputPort", .50);
           
            InitColumns();
        }

        private void DataToControls()
        {
            if (_pathVSWR != null)
            {
                lvList.Items.Clear();
                foreach (PathVSWRValue vswrvalue in _pathVSWR)
                {
                    AddListViewObject(vswrvalue);
                }
            }
        }

        private void ControlsToData()
        {
            _pathVSWR = null;
            if (lvList.Items.Count > 0)
            {
                _pathVSWR = new List<PathVSWRValue>();
                foreach (ListViewItem lvi in lvList.Items)
                {
                    var vswrvalue = (PathVSWRValue)lvi.Tag;
                    _pathVSWR.Add(vswrvalue);
                }
            }
        }
    }
}
