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
using ATMLModelLibrary.model.common;
using ATMLModelLibrary.model.equipment;
using ATMLModelLibrary.model.signal;

namespace ATMLCommonLibrary.controls.lists
{
    public partial class ManufacturerContactListView : ListView
    {
        private ManufacturerData manufacturer;
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ManufacturerData Manufacturer
        {
            get 
            {
                if (manufacturer != null 
                    && manufacturer.Contacts != null 
                    && manufacturer.Contacts.Count == 0) 
                    manufacturer.Contacts = null; 
                return manufacturer; }
            set 
            { 
                manufacturer = value;
                Items.Clear();
                if (manufacturer != null && manufacturer.Contacts != null )
                {
                    foreach( ManufacturerDataContact contact in manufacturer.Contacts )
                    {
                        ListViewItem item = new ListViewItem(contact.name);
                        item.SubItems.Add(contact.phoneNumber);
                        item.SubItems.Add(contact.email);
                        item.Tag = contact;
                        Items.Add(item);
                    }
                }
            }
        }

        public void AddContact(ManufacturerDataContact contact)
        {
            if (manufacturer.Contacts == null)
                manufacturer.Contacts = new List<ManufacturerDataContact>();
            manufacturer.Contacts.Add(contact);
            ListViewItem item = new ListViewItem(contact.name);
            item.SubItems.Add(contact.phoneNumber);
            item.SubItems.Add(contact.email);
            item.Tag = contact;
            Items.Add(item);
        }

        public ManufacturerContactListView()
        {
            InitializeComponent();
            initColumns();
        }

        public ManufacturerContactListView(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            initColumns();
        }

        private void initColumns()
        {
            Columns.Add("Name");
            Columns.Add("Phone");
            Columns.Add("Email");
            Columns[0].Width = -2;
            Columns[1].Width = -2;
            Columns[2].Width = -2;
        }

    }
}
