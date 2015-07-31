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
using ATMLModelLibrary.model.common;
using ATMLModelLibrary.model.equipment;
using ATMLCommonLibrary.forms;

namespace ATMLCommonLibrary.controls.lists
{
    public partial class ManufacturerContactListControl : ATMLListControl
    {
        private List<ManufacturerDataContact> _contacts = new List<ManufacturerDataContact>();

        public List<ManufacturerDataContact> Contacts
        {
            get { ControlsToData(); return _contacts; }
            set { _contacts = value; DataToControls(); }
        }

        public ManufacturerContactListControl()
        {
            InitializeComponent();
            InitListView();
        }

        private void InitListView()
        {
            DataObjectName = "Contact";
            DataObjectFormType = typeof(ContactForm);
            AddColumnData("Name", "name", .33);
            AddColumnData("Phone", "phoneNumber", .33);
            AddColumnData("Email", "email", .34);
            InitColumns();
        }



        private void DataToControls()
        {
            if (_contacts != null)
            {
                lvList.Items.Clear();
                foreach (ManufacturerDataContact contact in _contacts)
                    AddListViewObject(contact);
            }
        }

        private void ControlsToData()
        {
            _contacts = null;
            if (lvList.Items.Count > 0)
            {
                _contacts = new List<ManufacturerDataContact>();
                foreach (ListViewItem lvi in lvList.Items)
                    _contacts.Add((ManufacturerDataContact)lvi.Tag);
            }
        }

    }
}
