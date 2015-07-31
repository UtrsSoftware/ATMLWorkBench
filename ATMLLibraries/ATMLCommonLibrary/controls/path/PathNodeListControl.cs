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
    public partial class PathNodeListControl : ATMLListControl
    {
        private HardwareItemDescription _hardwareItemDescription;
        private List<PathNode> _pathNode = new List<PathNode>();

        public PathNodeListControl()
        {
            InitializeComponent();
            InitListView();
            Validating += PathNodeListControl_Validating;
            InitializeForm += PathNodeListControl_InitializeForm;
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<PathNode> PathNode
        {
            get
            {
                ControlsToData();
                return (_pathNode != null && _pathNode.Count == 0) ? null : _pathNode;
            }
            set
            {
                _pathNode = value;
                DataToControls();
            }
        }

        public HardwareItemDescription HardwareItemDescription
        {
            get { return _hardwareItemDescription; }
            set { _hardwareItemDescription = value; }
        }

        private void PathNodeListControl_InitializeForm(Form form)
        {
            var pathNodeForm = form as PathNodeForm;
            if (pathNodeForm != null)
                pathNodeForm.HardwareItemDescription = _hardwareItemDescription;
        }

        private void PathNodeListControl_Validating(object sender, CancelEventArgs e)
        {
            if (Items.Count < 2)
            {
                //error
            }
        }

        private void InitListView()
        {
            DataObjectName = "PathNode";
            DataObjectFormType = typeof (PathNodeForm);
            AddColumnData("Name", "name", 1.0);
            InitColumns();
        }

        private void DataToControls()
        {
            if (_pathNode != null)
            {
                lvList.Items.Clear();
                foreach (PathNode pathnode in _pathNode)
                {
                    AddListViewObject(pathnode);
                }
            }
        }

        private void ControlsToData()
        {
            _pathNode = null;
            if (lvList.Items.Count > 0)
            {
                _pathNode = new List<PathNode>();
                foreach (ListViewItem lvi in lvList.Items)
                {
                    var pathNode = (PathNode) lvi.Tag;
                    _pathNode.Add(pathNode);
                }
            }
        }

        public override bool ValidateChildren()
        {
            bool valid = base.ValidateChildren();
            errorProvider.Clear();
            if (lvList.Items.Count < 2)
            {
                valid = false;
                errorProvider.SetError(lvList, "There must be at least 2 Path Nodes");
            }
            return valid;
        }
    }
}