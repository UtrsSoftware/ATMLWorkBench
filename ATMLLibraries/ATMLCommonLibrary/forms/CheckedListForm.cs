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
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ATMLCommonLibrary.model;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.forms
{
    public partial class CheckedListForm : ATMLForm
    {
        private String propertyName = null;
        private List<object> listItems = new List<object>();
        public List<object> ListItems
        {
            get { return listItems; }
        }

        public void AddListItem(object item, bool selected )
        {
            ListViewItem lvi = null;
            listItems.Add(item);
            if (propertyName == null)
            {
                lvi = new ListViewItem(item.ToString());
            }
            else
            {
                System.Reflection.PropertyInfo pi = item.GetType().GetProperty(propertyName);
                lvi = new ListViewItem((String) pi.GetValue(item, null));
            }
            lvi.Tag = item;
            chkList.Items.Add(lvi, selected );
        }

        /**
         * Constructs a new CheckedListForm object.
         * @param propertyName - The name of the property to use as the text of the checked list box item.
         */
        public CheckedListForm(String propertyName)
        {
            this.propertyName = propertyName;
            InitializeComponent();
        }

        public CheckedListForm()
        {
            InitializeComponent();
        }


        private List<object> selectedItems = new List<object>();
        public List<object> SelectedIems
        {
            get
            {
                selectedItems.Clear();
                foreach (ListViewItem item in chkList.CheckedItems)
                    selectedItems.Add(item.Tag);
                return selectedItems;
            }
        }
    }
}
