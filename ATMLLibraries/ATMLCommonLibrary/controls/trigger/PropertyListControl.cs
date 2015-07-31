/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using ATMLCommonLibrary.controls.lists;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.trigger
{
    public partial class PropertyListControl : ATMLListControl
    {
        private List<TriggerPropertyGroup> properties = new List<TriggerPropertyGroup>();

        public PropertyListControl()
        {
            InitializeComponent();
            InitListView();
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<TriggerPropertyGroup> Properties
        {
            get
            {
                ControlsToData();
                return properties.Count == 0 ? null : properties;
            }
            set
            {
                if (value != null) properties = value.ToList();
                DataToControls();
            }
        }

        protected void DataToControls()
        {
            foreach (TriggerPropertyGroup property in properties)
            {
                AddListViewObject(property);
            }
        }

        protected void ControlsToData()
        {
            properties.Clear();
            foreach (ListViewItem lvi in lvList.Items)
            {
                properties.Add(lvi.Tag as TriggerPropertyGroup);
            }
        }

        private void InitListView()
        {
            DataObjectName = "Property";
            DataObjectFormType = typeof (TriggerPropertyForm);
            AddColumnData("Name", "name", .50);
            AddColumnData("Description", "Description", .50);
            InitColumns();
        }
    }
}