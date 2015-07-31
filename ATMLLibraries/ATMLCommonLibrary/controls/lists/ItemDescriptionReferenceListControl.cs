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
using ATMLCommonLibrary.forms;
using ATMLModelLibrary.model.common;

namespace ATMLCommonLibrary.controls.lists
{
    public partial class ItemDescriptionReferenceListControl : ATMLListControl
    {
        private List<ItemDescriptionReference> _itemDescriptionReferences;

        public ItemDescriptionReferenceListControl()
        {
            InitializeComponent();
            InitListView();
        }

        private void InitListView()
        {
            DataObjectName = "ItemDescriptionReference";
            DataObjectFormType = typeof(ItemDescriptionReferenceForm);
            AddColumnData("Instrument", "ToString()", 1);
            InitColumns();
        }


        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<ItemDescriptionReference> ItemDescriptionReferences
        {
            get{ControlsToData(); return _itemDescriptionReferences; }
            set { _itemDescriptionReferences = value;DataToControls();}
        }

        private void ControlsToData()
        {
            if (lvList.Items.Count == 0)
            {
                _itemDescriptionReferences = null;
            }
            else
            {
                if (_itemDescriptionReferences == null)
                    _itemDescriptionReferences = new List<ItemDescriptionReference>();
                _itemDescriptionReferences.Clear();
                foreach (ListViewItem lvi in lvList.Items)
                    _itemDescriptionReferences.Add(lvi.Tag as ItemDescriptionReference);
            }
        }

        private void DataToControls()
        {
            if (_itemDescriptionReferences != null)
            {
                foreach (ItemDescriptionReference item in _itemDescriptionReferences)
                    AddListViewObject(item);
            }
        }
    }
}
