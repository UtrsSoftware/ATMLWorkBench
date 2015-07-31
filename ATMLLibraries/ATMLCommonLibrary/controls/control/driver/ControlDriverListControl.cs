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
using ATMLCommonLibrary.forms;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.control.driver
{
    public partial class ControlDriverListControl : ATMLListControl
    {
        private List<HardwareItemDescriptionControlDriver> _hardwareItemDescriptionControlDrivers =
            new List<HardwareItemDescriptionControlDriver>();


        public ControlDriverListControl()
        {
            InitializeComponent();
            InitListView();
            InitializeForm+= delegate( Form form )
                                  {
                                      var atmlForm = form as ATMLForm;
                                      if (atmlForm != null)
                                          atmlForm.CloseOnSave = true;
                                  };
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<HardwareItemDescriptionControlDriver> HardwareItemDescriptionControlDrivers
        {
            get
            {
                ControlsToData();
                return _hardwareItemDescriptionControlDrivers;
            }
            set
            {
                _hardwareItemDescriptionControlDrivers = value;
                DataToControls();
            }
        }

        private void DataToControls()
        {
            if (_hardwareItemDescriptionControlDrivers != null)
            {
                lvList.Items.Clear();
                foreach (HardwareItemDescriptionControlDriver driver in _hardwareItemDescriptionControlDrivers)
                {
                    AddListViewObject(driver);
                }
            }
        }

        private void ControlsToData()
        {
            _hardwareItemDescriptionControlDrivers = null;
            if (lvList.Items.Count > 0)
            {
                _hardwareItemDescriptionControlDrivers = new List<HardwareItemDescriptionControlDriver>();
                foreach (ListViewItem lvi in lvList.Items)
                {
                    var obj = (HardwareItemDescriptionControlDriver) lvi.Tag;
                    _hardwareItemDescriptionControlDrivers.Add(obj);
                }
            }
        }

        private void InitListView()
        {
            DataObjectName = "HardwareItemDescriptionControlDriver";
            DataObjectFormType = typeof (ControlDriverForm);
            AddColumnData("Value", "ToString()", 1.00);
            InitColumns();
        }
    }
}