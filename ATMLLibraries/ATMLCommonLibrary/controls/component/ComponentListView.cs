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
using ATMLCommonLibrary.model;
using ATMLModelLibrary.model.common;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.lists
{
    public partial class ComponentListView : ListView
    {
        public ComponentListView()
        {
            InitializeComponent();
            FullRowSelect = true;
            Columns.Clear();
            Columns.Add("ID");
            Columns.Add("Name/UUID");
        }

        public ComponentListView(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            FullRowSelect = true;
            Columns.Clear();
            Columns.Add("ID");
            Columns.Add("Name/UUID");
        }

        public void addItemComponent(HardwareItemDescriptionComponent itemComponent)
        {
            ListViewItem item = new ListViewItem(itemComponent.ID);
            object obj = itemComponent.Item;
            if (obj is ItemDescription)
            {
                ItemDescription desc = (ItemDescription)obj;
                string name = desc.name;
                item.SubItems.Add(name);
            }
            else if (obj is DocumentReference)
            {
                DocumentReference doc = (DocumentReference)obj;
                string uuid = doc.uuid;
                item.SubItems.Add(uuid);
            }

            item.Tag = itemComponent;
            this.Items.Add(item);
        }

        public void addItemComponents(List<HardwareItemDescriptionComponent> itemComponents)
        {
            this.Items.Clear();
            foreach (HardwareItemDescriptionComponent itemComponent in itemComponents)
                addItemComponent(itemComponent);
        }
    
    }
}
