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
using ATMLCommonLibrary.managers;
using ATMLManagerLibrary.managers;
using ATMLModelLibrary.model.common;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.lists
{
    public partial class SpecificationListControl : ATMLListControl
    {

        public SpecificationListControl()
        {
            InitializeComponent();
            lvList.FullRowSelect = true;
            lvList.HideSelection = false;
            lvList.View = View.Details;
            lvList.Columns.Add("Name");
            lvList.Columns[0].Width = lvList.Width;
            lvList.Resize += new EventHandler(lvList_Resize);
        }

        void lvList_Resize(object sender, EventArgs e)
        {
            if( lvList.Columns.Count >= 1 )
                lvList.Columns[0].Width = lvList.Width;
        }

        private void lvList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void AddItem(object item)
        {
            if (item is Specification)
            {
                Specification specification = item as Specification;
                ListViewItem lvi = new ListViewItem(specification.name);
                lvi.Tag = specification;
                lvi.BackColor = Color.LightYellow;
                lvList.Items.Add(lvi);
            }
            else if (item is SpecificationGroup)
            {
                SpecificationGroup specificationGroup = item as SpecificationGroup;
                ListViewItem lvi = new ListViewItem(specificationGroup.name);
                lvi.Tag = specificationGroup;
                lvi.BackColor = Color.LightGreen;
                lvList.Items.Add(lvi);
            }
        }

        protected override void btnAdd_Click(object sender, EventArgs e)
        {
            base.btnAdd_Click(sender, e);
            SpecificationForm form = new SpecificationForm();
            if (DialogResult.OK == form.ShowDialog())
            {
                object specificationItem = form.SpecificaionItem;
                if (specificationItem is Specification)
                {
                    Specification specification = specificationItem as Specification;
                    ListViewItem lvi = new ListViewItem(specification.name);
                    lvi.Tag = specification;
                    lvList.Items.Add(lvi);
                }
                else if (specificationItem is SpecificationGroup)
                {
                    SpecificationGroup group = specificationItem as SpecificationGroup;
                    ListViewItem lvi = new ListViewItem(group.name);
                    lvi.Tag = group;
                    lvList.Items.Add(lvi);
                }
            }
        }

        protected override void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvList.SelectedItems.Count > 0)
            {
                object specificationItem = lvList.SelectedItems[0].Tag;
                SpecificationForm form = new SpecificationForm();
                form.SpecificaionItem = specificationItem;
                if (DialogResult.OK == form.ShowDialog(this))
                {
                    specificationItem = form.SpecificaionItem;
                    if (specificationItem is Specification)
                    {
                        Specification specification = specificationItem as Specification;
                        lvList.SelectedItems[0].Tag = specification;
                        lvList.SelectedItems[0].SubItems[0].Text = specification.name;
                    }
                    else if (specificationItem is SpecificationGroup)
                    {
                        SpecificationGroup group = specificationItem as SpecificationGroup;
                        lvList.SelectedItems[0].Tag = group;
                        lvList.SelectedItems[0].SubItems[0].Text = group.name;
                    }
                }
            }
        }

        protected override void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvList.SelectedItems.Count > 0)
            {
                String prompt = MessageManager.getMessage("Generic.delete.prompt");
                String title = MessageManager.getMessage("Generic.title.verification");

                ListViewItem lvi = lvList.SelectedItems[0];
                object specificationItem = lvi.Tag;
                prompt = specificationItem is SpecificationGroup ? String.Format(prompt, "Specification Group", ((SpecificationGroup)specificationItem).name ):
                         specificationItem is Specification ? String.Format(prompt, "Specification", ((Specification)specificationItem).name ) : "";
                if (DialogResult.Yes == MessageBox.Show(prompt, 
                                                        title, 
                                                        MessageBoxButtons.YesNo, 
                                                        MessageBoxIcon.Question))
                {
                    lvi.Remove();
                }

            }
        }
    }
}
