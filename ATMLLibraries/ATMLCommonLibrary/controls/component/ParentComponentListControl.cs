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
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ATMLCommonLibrary.controls.lists;
using ATMLCommonLibrary.forms;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.component
{
    public partial class ParentComponentListControl : ATMLListControl
    {
        private List<HardwareItemDescriptionComponent1> _itemComponents = new List<HardwareItemDescriptionComponent1>();


        public ParentComponentListControl()
        {
            InitializeComponent();
            InitListView();
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<HardwareItemDescriptionComponent1> ItemComponents
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
            DataObjectName = "ParentItemComponent";
            DataObjectFormType = typeof (ComponentForm);
            AddColumnData("Id", "ID", .20);
            AddColumnData("Value", "ToString()", .80);
            InitializeForm+= delegate( Form form )
                             {
                                 ComponentForm compForm = form as ComponentForm;
                                 if (compForm != null)
                                     compForm.IsParentComponent = true;
                             };
            InitColumns();
        }


        private void DataToControls()
        {
            Items.Clear();
            if (_itemComponents != null)
            {
                foreach (HardwareItemDescriptionComponent1 component in _itemComponents)
                    AddListViewObject(component);
            }
        }

        private void ControlsToData()
        {
            if( _itemComponents != null )
                _itemComponents.Clear();

            if (lvList.Items.Count == 0)
            {
                _itemComponents = null;
            }
            else
            {
                if (_itemComponents == null)
                    _itemComponents = new List<HardwareItemDescriptionComponent1>();
                foreach (ListViewItem lvi in lvList.Items)
                    _itemComponents.Add(lvi.Tag as HardwareItemDescriptionComponent1);
            }
        }
    }
}