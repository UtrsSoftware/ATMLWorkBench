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
    public partial class PathSParameterListCntrlListCntrl : ATMLCommonLibrary.controls.lists.ATMLListControl
    {
       private List<PathSParameter> _PathList = new List<PathSParameter>();

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<PathSParameter> PathList
        {
            get { ControlsToData(); return (_PathList != null && _PathList.Count == 0) ? null : _PathList; }
            set { _PathList = value; DataToControls(); }
        }

        public PathSParameterListCntrlListCntrl()
        {
            InitializeComponent();
            InitListView();
        }

        private void InitListView()
        {
            DataObjectName = "PathSParameter";
            DataObjectFormType = typeof(PathSParameterForm);
            AddColumnData("Input Port", "inputPort", .50);
            AddColumnData("Output Port", "outputPort", .50);
            InitColumns();
        }

        private void DataToControls()
        {
            if (_PathList != null)
            {
                lvList.Items.Clear();
                foreach (PathSParameter pathlist in _PathList)
                {
                    AddListViewObject(pathlist);
                }
            }
        }

        private void ControlsToData()
        {
            _PathList = null;
            if (lvList.Items.Count > 0)
            {
                _PathList = new List<PathSParameter>();
                foreach (ListViewItem lvi in lvList.Items)
                {
                    var pathlist = (PathSParameter)lvi.Tag;
                    _PathList.Add(pathlist);
                }
            }
        }
    }
}
