/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

namespace ATMLCommonLibrary.forms
{
    public partial class ATMLSelectionCheckListForm : ATMLForm
    {
        private readonly List<string> columnNames = new List<string>();
        private readonly ATMLSelectionCheckListContext context;
        private List<object> selectedObjects = new List<object>();

        public ATMLSelectionCheckListForm(ATMLSelectionCheckListContext context)
        {
            InitializeComponent();
            this.context = context;
            lblSelectionLabel.Text = context.SelectionLabelText;
            cmbSelect.DataSource = context.SelectionData;
            cmbSelect.SelectedIndexChanged += cmbSelect_SelectedIndexChanged;
            lvCheckList.CheckBoxes = true;

            Type type = Type.GetType(context.ListItemClassName);
            foreach (PropertyInfo pi in type.GetProperties())
            {
                if (pi.PropertyType.Name.Equals("String"))
                {
                    lvCheckList.Columns.Add(pi.Name);
                    columnNames.Add(pi.Name);
                }
            }

            if (columnNames.Count > 0)
            {
                int width = lvCheckList.Width/columnNames.Count;
                for (int i = 0; i < columnNames.Count; i++)
                    lvCheckList.Columns[i].Width = width;
            }
        }

        private void cmbSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            object selectedItem = cmbSelect.SelectedItem;
            PropertyInfo info = selectedItem.GetType().GetProperty(context.SelectionListClassName);
            if (info == null)
                throw new Exception("Invalid Class Name: " + context.SelectionListClassName);
            object list = info.GetValue(selectedItem, null);
            if (list.GetType().IsGenericType && list is IEnumerable)
            {
                lvCheckList.Items.Clear();
                var enumerable = (IEnumerable) list;
                IEnumerator enumerator = enumerable.GetEnumerator();

                while (enumerator.MoveNext())
                {
                    object obj = enumerator.Current;
                    var lvi = new ListViewItem();
                    lvi.Tag = obj;
                    int i = 0;
                    foreach (string name in columnNames)
                    {
                        PropertyInfo pi = obj.GetType().GetProperty(name);
                        var value = (String) pi.GetValue(obj, null);
                        lvi.SubItems.Add(value);
                    }
                    lvCheckList.Items.Add(lvi);
                }
            }
        }
    }


    public class ATMLSelectionCheckListContext
    {
        public object SelectionObject { set; get; }
        public string SelectionLabelText { set; get; }
        public string SelectionListClassName { set; get; }
        public string ListItemClassName { set; get; }
        public string ListItemObjectName { set; get; }
        public object SelectionData { get; set; }
    }
}