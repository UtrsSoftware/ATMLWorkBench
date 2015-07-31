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

namespace ATMLCommonLibrary.controls.path
{
    public partial class PathListControl : ATMLListControl
    {
        private List<Path> _paths = new List<Path>();
        private HardwareItemDescription _hardwareItemDescription;

        public PathListControl()
        {
            InitializeComponent();
            InitListView();
            InitializeForm += new FormInitializationDelegate(PathListControl_InitializeForm);
        }

        void PathListControl_InitializeForm(Form form)
        {
            PathForm pathForm = form as PathForm;
            if (pathForm != null)
                pathForm.HardwareItemDescription = _hardwareItemDescription;
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<Path> Paths
        {
            get
            {
                ControlsToData();
                return (_paths != null && _paths.Count == 0) ? null : _paths;
            }
            set
            {
                _paths = value;
                DataToControls();
            }
        }

        public HardwareItemDescription HardwareItemDescription
        {
            get { return _hardwareItemDescription; }
            set { _hardwareItemDescription = value; }
        }

        private void InitListView()
        {
            DataObjectName = "Path";
            DataObjectFormType = typeof (PathForm);
            AddColumnData("Name", "name", 0.25);
            AddColumnData("Path", "ToString()", 0.75);
            InitColumns();
        }

        private void DataToControls()
        {
            if (_paths != null)
            {
                lvList.Items.Clear();
                foreach (Path path in _paths)
                {
                    AddListViewObject(path);
                }
            }
        }

        private void ControlsToData()
        {
            _paths = null;
            if (lvList.Items.Count > 0)
            {
                _paths = new List<Path>();
                foreach (ListViewItem lvi in lvList.Items)
                {
                    var path = (Path) lvi.Tag;
                    _paths.Add(path);
                }
            }
        }
    }
}