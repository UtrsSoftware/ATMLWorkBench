/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System.Collections.Generic;
using System.Windows.Forms;
using ATMLCommonLibrary.controls.lists;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.control.tool
{
    public partial class ControlToolListControl : ATMLListControl
    {
        private List<HardwareItemDescriptionControlTool> _hardwareItemDescriptionControlTool =
            new List<HardwareItemDescriptionControlTool>();

        public ControlToolListControl()
        {
            InitializeComponent();
            InitListView();
        }

        public List<HardwareItemDescriptionControlTool> HardwareItemDescriptionControlTool
        {
            get
            {
                ControlsToData();
                return (_hardwareItemDescriptionControlTool != null && _hardwareItemDescriptionControlTool.Count == 0)
                    ? null
                    : _hardwareItemDescriptionControlTool;
            }
            set
            {
                _hardwareItemDescriptionControlTool = value;
                DataToControls();
            }
        }

        private void InitListView()
        {
            DataObjectName = "HardwareItemDescriptionControlTool";
            DataObjectFormType = typeof (ControlToolControlForm);
            AddColumnData("Name", "name", .25);
            AddColumnData("Version", "version", .25);
            AddColumnData("Qualifier", "qualifier", .25);
            AddColumnData("File Path", "filePath", .25);
            InitColumns();
        }

        private void DataToControls()
        {
            if (_hardwareItemDescriptionControlTool != null)
            {
                lvList.Items.Clear();
                foreach (HardwareItemDescriptionControlTool controltool in _hardwareItemDescriptionControlTool)
                {
                    AddListViewObject(controltool);
                }
            }
        }

        private void ControlsToData()
        {
            _hardwareItemDescriptionControlTool = null;
            if (lvList.Items.Count > 0)
            {
                _hardwareItemDescriptionControlTool = new List<HardwareItemDescriptionControlTool>();
                foreach (ListViewItem lvi in lvList.Items)
                {
                    var obj = (HardwareItemDescriptionControlTool) lvi.Tag;
                    _hardwareItemDescriptionControlTool.Add(obj);
                }
            }
        }
    }
}