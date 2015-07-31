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
    public partial class ControllerOperatingSystemListControl : ATMLListControl
    {
        private List<ControllerOperatingSystem> _operatingSystems = new List<ControllerOperatingSystem>();

        public ControllerOperatingSystemListControl()
        {
            InitializeComponent();
            InitListView();
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<ControllerOperatingSystem> OperatingSystems
        {
            get
            {
                ControlsToData();
                return (_operatingSystems != null && _operatingSystems.Count == 0) ? null : _operatingSystems;
            }
            set
            {
                _operatingSystems = value;
                DataToControls();
            }
        }

        private void InitListView()
        {
            DataObjectName = "OperatingSystems";
            DataObjectFormType = typeof (ControllerOperatingSystemsForm);
            AddColumnData("Operating System", "ToString()", 1.0);
            InitColumns();
            InitializeForm += ControllerOperatingSystemListControl_InitializeForm;
        }

        private void ControllerOperatingSystemListControl_InitializeForm(Form form)
        {
            form.Text = @"Operating System";
        }

        private void DataToControls()
        {
            if (_operatingSystems != null)
            {
                lvList.Items.Clear();
                foreach (ControllerOperatingSystem cntrolOs in _operatingSystems)
                {
                    AddListViewObject(cntrolOs);
                }
            }
        }

        private void ControlsToData()
        {
            _operatingSystems = null;
            if (lvList.Items.Count > 0)
            {
                _operatingSystems = new List<ControllerOperatingSystem>();
                foreach (ListViewItem lvi in lvList.Items)
                {
                    var cntrlOS = (ControllerOperatingSystem) lvi.Tag;
                    _operatingSystems.Add(cntrlOS);
                }
            }
        }
    }
}