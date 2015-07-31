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
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ATMLCommonLibrary.forms;
using ATMLModelLibrary.model.common;

namespace ATMLCommonLibrary.controls.lists
{
    public partial class ItemDescriptionListControl : ATMLCommonLibrary.controls.lists.ATMLListControl
    {
        private List<ItemDescription> _itemsDescriptions;
 
        public ItemDescriptionListControl()
        {
            InitializeComponent();
            InitListView();
        }

        public List<ItemDescription> ItemsDescriptions
        {
            get
            {
                ControlsToData(); 
                return _itemsDescriptions; 
            }
            set 
            { 
                _itemsDescriptions = value;
                DataToControls(); 
            }
        }

        private void DataToControls()
        {
            if (_itemsDescriptions != null)
            {
                lvList.Items.Clear();
                foreach (ItemDescription item in _itemsDescriptions)
                {
                    AddListViewObject(item);
                }
            }
        }

        private void ControlsToData()
        {
            _itemsDescriptions = null;
            if (lvList.Items.Count > 0)
            {
                _itemsDescriptions = new List<ItemDescription>();
                foreach (ListViewItem lvi in lvList.Items)
                {
                    var items = (ItemDescription)lvi.Tag;
                    _itemsDescriptions.Add(items);
                }
            } 
        }

        private void InitListView()
        {
            DataObjectName = "ItemDescription";
            DataObjectFormType = typeof(ItemDescriptionForm);
            AddColumnData("Name", "name", .25);
            AddColumnData("Version", "version", .25);
            AddColumnData("Description", "Description", .50);
            InitColumns();
        }

    }
}
