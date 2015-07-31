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
using ATMLCommonLibrary.controls.equipment;

namespace ATMLCommonLibrary.controls.path
{
    public partial class PathSParameterDataListControl : ATMLCommonLibrary.controls.lists.ATMLListControl
    {
        private List<PathSParameterSParameterData> _PathData = new List<PathSParameterSParameterData>();

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<PathSParameterSParameterData> PathData
        {
            get { ControlsToData(); return (_PathData != null && _PathData.Count == 0) ? null : _PathData; }
            set { _PathData = value; DataToControls(); }
        }
        public PathSParameterDataListControl()
        {
            InitializeComponent();
            InitListView();
        }
        private void InitListView()
        {
            DataObjectName = "PathSParameterSParameterData";
            DataObjectFormType = typeof(PathSParameterDataForm);
            AddColumnData("Magnitude", "Magnitude", .33);
            AddColumnData("Phase Angle", "PhaseAngle", .34);
            AddColumnData("Frequency", "Frequency", .33);
            InitColumns();
        }
        private void DataToControls()
        {
            if (_PathData != null)
            {
                lvList.Items.Clear();
                foreach (PathSParameterSParameterData pathdata in _PathData)
                {
                    AddListViewObject(pathdata);
                }
            }
        }
        private void ControlsToData()
        {
            _PathData = null;
            if (lvList.Items.Count > 0)
            {
                _PathData = new List<PathSParameterSParameterData>();
                foreach (ListViewItem lvi in lvList.Items)
                {
                    var pathdata = (PathSParameterSParameterData)lvi.Tag;
                    _PathData.Add(pathdata);
                }
            }
        }
    }
}
