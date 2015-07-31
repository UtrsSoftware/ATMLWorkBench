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
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ATMLModelLibrary.model.equipment;
using ATMLModelLibrary.model.common;

namespace ATMLCommonLibrary.controls.common
{
    public partial class CollectionListView : ListView
    {
        private Collection collection;
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Collection Collection
        {
            get { return collection; }
            set { collection = value; DataToControls(); }
        }


        public CollectionListView()
        {
            InitializeComponent();
            initColumns();
        }

        public CollectionListView(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            initColumns();
        }

        public void initColumns()
        {
            Columns.Clear();
            Columns.Add("Name");
            Columns.Add("Type");
        }

        public int AddCollectionItem(CollectionItem item)
        {
            ListViewItem lvItem = new ListViewItem(item.name);
            lvItem.SubItems.Add(item.Item.GetType().Name);
            lvItem.Tag = item;
            return Items.Add(lvItem).Index;
        }

        private void DataToControls()
        {
            if (collection != null)
            {
                Items.Clear();
                foreach (CollectionItem item in collection.Item)
                {
                    AddCollectionItem(item);
                }
            }
        }
    }
}
