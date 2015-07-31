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
using ATMLCommonLibrary.managers;
using ATMLManagerLibrary.managers;
using ATMLModelLibrary.model.equipment;
using ATMLModelLibrary.model.common;
using ATMLCommonLibrary.controls.common;

namespace ATMLCommonLibrary.controls.switching
{
    public partial class CrossPointSwitchControl : ItemControl
    {
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public CrossPointSwitch CrossPointSwitch
        {
            get { ControlsToData();  return (CrossPointSwitch)Item; }
            set { Item = value; DataToControls();  }
        }

        public CrossPointSwitchControl()
        {
            InitializeComponent();
            InitControls();

            lvColumns.OnAdd += new lists.ATMLListControl.OnAddDelegate(lvColumns_OnAdd);
            lvColumns.OnEdit += new lists.ATMLListControl.OnEditDelegate(lvColumns_OnEdit);
            lvColumns.OnDelete += new lists.ATMLListControl.OnDeleteDelegate(lvColumns_OnDelete);

            lvRows.OnAdd += new lists.ATMLListControl.OnAddDelegate(lvRows_OnAdd);
            lvRows.OnEdit += new lists.ATMLListControl.OnEditDelegate(lvRows_OnEdit);
            lvRows.OnDelete += new lists.ATMLListControl.OnDeleteDelegate(lvRows_OnDelete);

            lvColumns.Columns.Add("Name");
            lvColumns.Columns.Add("Description");
            lvColumns.Columns.Add("Base Idx");
            lvColumns.Columns.Add("Count");
            lvColumns.Columns.Add("Inc By");
            lvColumns.Columns.Add("Rep Char");

            lvRows.Columns.Add("Name");
            lvRows.Columns.Add("Description");
            lvRows.Columns.Add("Base Idx");
            lvRows.Columns.Add("Count");
            lvRows.Columns.Add("Inc By");
            lvRows.Columns.Add("Rep Char");
        }

        void lvRows_OnDelete()
        {
            DeleteSwitchPort(lvRows);  
        }

        void lvRows_OnEdit()
        {
            EditSwitchPort(lvRows);            
        }

        void lvRows_OnAdd()
        {
            AddSwitchPort(lvRows);
        }

        void lvColumns_OnDelete()
        {
            DeleteSwitchPort(lvColumns);
        }

        void lvColumns_OnEdit()
        {
            EditSwitchPort(lvColumns);
        }

        void lvColumns_OnAdd()
        {
            AddSwitchPort(lvColumns);
        }

        protected void ControlsToData()
        {
            if (_item == null)
                _item = new CrossPointSwitch();
            CrossPointSwitch crossPointSwitch = _item as CrossPointSwitch;
            crossPointSwitch.lineCount = edtLineCount.GetValue<int>();
            if (lvColumns.Items.Count > 0)
            {
                crossPointSwitch.Columns = new List<SwitchPort>();
                foreach (ListViewItem lvi in lvColumns.Items)
                    crossPointSwitch.Columns.Add((SwitchPort)lvi.Tag);
            }
            if (lvRows.Items.Count > 0)
            {
                crossPointSwitch.Rows = new List<SwitchPort>();
                foreach (ListViewItem lvi in lvRows.Items)
                    crossPointSwitch.Rows.Add((SwitchPort)lvi.Tag);
            }
        }

        protected void DataToControls()
        {
            CrossPointSwitch crossPointSwitch = _item as CrossPointSwitch;
            if (crossPointSwitch != null)
            {
                edtLineCount.Value = crossPointSwitch.lineCount;
                if (crossPointSwitch.Columns != null)
                {
                    lvColumns.Items.Clear();
                    foreach (SwitchPort port in crossPointSwitch.Columns)
                    {
                        AddListViewItem(port, lvColumns);
                    }
                }
                if (crossPointSwitch.Rows != null)
                {
                    lvRows.Items.Clear();
                    foreach (SwitchPort port in crossPointSwitch.Rows)
                    {
                        AddListViewItem(port, lvRows);
                    }
                }
            }
        }


        private void AddListViewItem(SwitchPort port, lists.ATMLListControl listView)
        {
            ListViewItem lvi = new ListViewItem(port.name);
            lvi.SubItems.Add(port.Description);
            lvi.SubItems.Add(port.baseIndexSpecified ? "" + port.baseIndex : "");
            lvi.SubItems.Add(port.countSpecified ? "" + port.count : "");
            lvi.SubItems.Add(port.incrementBySpecified ? "" + port.incrementBy : "");
            lvi.SubItems.Add(port.replacementCharacter);
            lvi.Tag = port;
            listView.Items.Add(lvi);
        }


        private void AddSwitchPort(lists.ATMLListControl listView)
        {
            SwitchPortForm form = new SwitchPortForm();
            form.SwitchPort = new SwitchPort();
            if (DialogResult.OK == form.ShowDialog())
            {
                SwitchPort port = form.SwitchPort;
                ListViewItem lvi = new ListViewItem(port.name);
                lvi.SubItems.Add(port.Description);
                lvi.SubItems.Add(port.baseIndexSpecified ? "" + port.baseIndex : "");
                lvi.SubItems.Add(port.countSpecified ? "" + port.count : "");
                lvi.SubItems.Add(port.incrementBySpecified ? "" + port.incrementBy : "");
                lvi.SubItems.Add(port.replacementCharacter);
                lvi.Tag = port;
                listView.Items.Add(lvi);
            }
        }

        private void EditSwitchPort(lists.ATMLListControl listView)
        {
            if (lvColumns.SelectedItems.Count > 0)
            {
                ListViewItem lvi = listView.SelectedItems[0];
                SwitchPortForm form = new SwitchPortForm();
                form.SwitchPort = (SwitchPort)lvi.Tag;
                if (DialogResult.OK == form.ShowDialog())
                {
                    SwitchPort port = form.SwitchPort;
                    lvi.SubItems[0].Text = port.name;
                    lvi.SubItems[1].Text = port.Description;
                    lvi.SubItems[2].Text = port.baseIndexSpecified ? "" + port.baseIndex : "";
                    lvi.SubItems[3].Text = port.countSpecified ? "" + port.count : "";
                    lvi.SubItems[4].Text = port.incrementBySpecified ? "" + port.incrementBy : "";
                    lvi.SubItems[5].Text = port.replacementCharacter;
                    lvi.Tag = port;
                }
            }
        }

        private void DeleteSwitchPort(lists.ATMLListControl listView)
        {
            if (listView.SelectedItems.Count > 0)
            {
                SwitchPort port = (SwitchPort)listView.SelectedItems[0].Tag;
                String prompt = String.Format(MessageManager.getMessage("Generic.delete.prompt"), "switch port", port.name);
                String title = MessageManager.getMessage("Generic.title.verification");
                if (DialogResult.Yes == MessageBox.Show(prompt,
                                                         title,
                                                         MessageBoxButtons.YesNo,
                                                         MessageBoxIcon.Question))
                {
                    listView.SelectedItems[0].Remove();
                }

            }
        }

    }
}
