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
    public partial class ControllerDriveListControl : ATMLListControl
    {
        private List<ControllerDrive> _controllerDrive = new List<ControllerDrive>();

        public ControllerDriveListControl()
        {
            InitializeComponent();
            InitListView();
            InitializeForm += ControllerDriveListControl_InitializeForm;
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<ControllerDrive> ControllerDrive
        {
            get
            {
                ControlsToData();
                return (_controllerDrive != null && _controllerDrive.Count == 0) ? null : _controllerDrive;
            }
            set
            {
                _controllerDrive = value;
                DataToControls();
            }
        }

        private void ControllerDriveListControl_InitializeForm(Form form)
        {
            form.Text = @"Controller Drive";
        }

        private void InitListView()
        {
            DataObjectName = "ControllerDrive";
            DataObjectFormType = typeof (ControllerDriveForm);
            AddColumnData("Size", "Size", .33);
            AddColumnData("Name", "name", .33);
            AddColumnData("Boot Drive", "bootDrive", .34);
            InitColumns();
        }

        private void DataToControls()
        {
            if (_controllerDrive != null)
            {
                lvList.Items.Clear();
                foreach (ControllerDrive controllerdrive in _controllerDrive)
                {
                    AddListViewObject(controllerdrive);
                }
            }
        }

        private void ControlsToData()
        {
            _controllerDrive = null;
            if (lvList.Items.Count > 0)
            {
                _controllerDrive = new List<ControllerDrive>();
                foreach (ListViewItem lvi in lvList.Items)
                {
                    var cd = (ControllerDrive) lvi.Tag;
                    _controllerDrive.Add(cd);
                }
            }
        }
    }
}