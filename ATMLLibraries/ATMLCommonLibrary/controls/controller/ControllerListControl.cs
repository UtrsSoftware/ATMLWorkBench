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

namespace ATMLCommonLibrary.controls.controller
{
    public partial class ControllerListControl : ATMLListControl
    {
        private List<Controller> _controller = new List<Controller>();

        public ControllerListControl()
        {
            InitializeComponent();
            InitListView();
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<Controller> Controller
        {
            get
            {
                ControlsToData();
                return (_controller != null && _controller.Count == 0) ? null : _controller;
            }
            set
            {
                _controller = value;
                DataToControls();
            }
        }

        private void InitListView()
        {
            DataObjectName = "Controller";
            DataObjectFormType = typeof (ControllerForm);
            AddColumnData("Name", "name", .33);
            AddColumnData("Description", "Description", .33);
            AddColumnData("Physical Memory", "PhysicalMemory", .34);
            InitColumns();
        }

        private void DataToControls()
        {
            if (_controller != null)
            {
                lvList.Items.Clear();
                foreach (Controller controller in _controller)
                {
                    AddListViewObject(controller);
                }
            }
        }

        private void ControlsToData()
        {
            _controller = null;
            if (lvList.Items.Count > 0)
            {
                _controller = new List<Controller>();
                foreach (ListViewItem lvi in lvList.Items)
                {
                    var contrlr = (Controller) lvi.Tag;
                    _controller.Add(contrlr);
                }
            }
        }
    }
}