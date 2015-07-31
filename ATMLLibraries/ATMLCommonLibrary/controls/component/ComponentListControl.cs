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
using ATMLCommonLibrary.forms;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.lists
{
    public partial class ComponentListControl : ATMLListControl
    {
        private List<HardwareItemDescriptionComponent> _itemComponents = new List<HardwareItemDescriptionComponent>();


        public ComponentListControl()
        {
            InitializeComponent();
            InitListView();
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<HardwareItemDescriptionComponent> ItemComponents
        {
            get
            {
                ControlsToData();
                return _itemComponents;
            }
            set
            {
                if (value != null)
                {
                    _itemComponents = value;
                    DataToControls();
                }
            }
        }

        private void InitListView()
        {
            DataObjectName = "ItemComponent";
            DataObjectFormType = typeof (ComponentForm);
            AddColumnData("Id", "ID", .20);
            AddColumnData("Value", "ToString()", .80);
            InitColumns();
        }


        private void DataToControls()
        {
            Items.Clear();
            if (_itemComponents != null)
            {
                foreach (HardwareItemDescriptionComponent component in _itemComponents)
                    AddListViewObject(component);
            }
        }

        private void ControlsToData()
        {
            if (_itemComponents != null )
                _itemComponents.Clear();

            if (lvList.Items.Count == 0)
            {
                _itemComponents = null;
            }
            else
            {
                if (_itemComponents == null)
                    _itemComponents = new List<HardwareItemDescriptionComponent>();
                foreach (ListViewItem lvi in lvList.Items)
                    _itemComponents.Add(lvi.Tag as HardwareItemDescriptionComponent);
            }
        }
    }
}