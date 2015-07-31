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
using ATMLModelLibrary.model.common;
using ATMLModelLibrary.model.equipment;
using ATMLCommonLibrary.controls.lists;
using ATMLCommonLibrary.controls.common;

namespace ATMLCommonLibrary.controls.switching
{
    public partial class MatrixSwitchControl : ItemControl
    {

        private MatrixSwitch matrixSwitch;
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MatrixSwitch MatrixSwitch
        {
            get { ControlsToData(); return matrixSwitch; }
            set { matrixSwitch = value; DataToControls();  }
        }

        public MatrixSwitchControl()
        {
            InitializeComponent();
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

        private void DataToControls()
        {
            Item = matrixSwitch;
            if (matrixSwitch != null)
            {

                if (matrixSwitch.Columns != null)
                {
                    lvColumns.Items.Clear();
                    foreach (MatrixPort port in matrixSwitch.Columns)
                    {
                        AddListViewItem(port, lvColumns);
                    }
                }
                if (matrixSwitch.Columns != null)
                {
                    lvRows.Items.Clear();
                    foreach (MatrixPort port in matrixSwitch.Rows)
                    {
                        AddListViewItem(port, lvRows);
                    }
                }
            }
        }

        private void AddListViewItem(MatrixPort port, ATMLListControl listView)
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

        private void ControlsToData()
        {
            if (Item != null)
            {
                matrixSwitch = (MatrixSwitch)Item;
                List<MatrixPort> columns = new List<MatrixPort>();
                List<MatrixPort> rows = new List<MatrixPort>();
                foreach (ListViewItem lvi in lvColumns.Items)
                    columns.Add(lvi.Tag as MatrixPort);
                foreach (ListViewItem lvi in lvRows.Items)
                    rows.Add(lvi.Tag as MatrixPort);
                matrixSwitch.Columns = columns.Count == 0 ? null : columns;
                matrixSwitch.Rows = rows.Count == 0 ? null : rows;
            }
        }

        void lvRows_OnAdd()
        {
            AddMatrixPort(lvRows);
        }

        void lvRows_OnEdit()
        {
            EditMatrixPort(lvRows);
        }

        void lvRows_OnDelete()
        {
            DeleteMatrixPort(lvRows);
        }

        void lvColumns_OnAdd()
        {
            AddMatrixPort(lvColumns);
        }

        void lvColumns_OnEdit()
        {
            EditMatrixPort(lvColumns);
        }

        void lvColumns_OnDelete()
        {
            DeleteMatrixPort(lvColumns);
        }

        private void DeleteMatrixPort(lists.ATMLListControl listView)
        {
            if (listView.SelectedItems.Count > 0)
            {
                MatrixPort port = (MatrixPort)listView.SelectedItems[0].Tag;
                String prompt = String.Format(MessageManager.getMessage("Generic.delete.prompt"), "matrix port", port.name);
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

        private void EditMatrixPort(lists.ATMLListControl listView)
        {
            if (lvColumns.SelectedItems.Count > 0)
            {
                ListViewItem lvi = listView.SelectedItems[0];
                MatrixPortForm form = new MatrixPortForm();
                form.MatrixPort = (MatrixPort)lvi.Tag;
                if (DialogResult.OK == form.ShowDialog())
                {
                    MatrixPort port = form.MatrixPort;
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

        private void AddMatrixPort(lists.ATMLListControl listView)
        {
            MatrixPortForm form = new MatrixPortForm();
            form.MatrixPort = new MatrixPort();
            if (DialogResult.OK == form.ShowDialog())
            {
                MatrixPort port = form.MatrixPort;
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

        private void lvColumns_Load(object sender, EventArgs e)
        {

        }

        
    }
}
