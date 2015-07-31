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
using System.Windows.Forms;
using ATMLCommonLibrary.controls.switching;
using ATMLCommonLibrary.managers;
using ATMLManagerLibrary.managers;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.lists
{
    public partial class SwitchingListControl : ATMLListControl
    {
        private readonly List<Item> _switchItems = new List<Item>();
        private InstrumentDescription _instrument;

        private Switching _switching;

        public SwitchingListControl()
        {
            InitializeComponent();
            InitList();
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public InstrumentDescription Instrument
        {
            get
            {
                _instrument.Switching = Switching;
                return _instrument;
            }
            set
            {
                _instrument = value;
                Switching = _instrument.Switching;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Switching Switching
        {
            get
            {
                ControlsToData();
                return _switching;
            }
            set
            {
                _switching = value;
                DataToControls();
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected List<Item> SwitchItems
        {
            get { return _switchItems != null && _switchItems.Count > 0 ? _switchItems : null; }
            set
            {
                _switchItems.Clear();
                if (value != null)
                {
                    _switchItems.AddRange(value);
                }
            }
        }

        private void DataToControls()
        {
            if (_switching != null)
            {
                SwitchItems = _switching.Items;
                foreach (Item item in _switchItems)
                {
                    AddSwitchItem(item);
                }
            }
        }

        private void AddSwitchItem(Item item)
        {
            var lvi = new ListViewItem(item.GetType().Name);
            lvi.SubItems.Add(item.name);
            lvi.SubItems.Add(item.Description);
            lvi.Tag = item;
            lvList.Items.Add(lvi);
        }

        private void ControlsToData()
        {
            if (lvList.Items.Count == 0)
            {
                _switching = null;
            }
            else
            {
                _switchItems.Clear();
                foreach (ListViewItem item in lvList.Items)
                {
                    _switchItems.Add((Item) item.Tag);
                }
                if( _switching == null )
                    _switching = new Switching();
                _switching.Items = _switchItems;
            }

        }


        private void InitList()
        {
            lvList.Columns.Add("Type");
            lvList.Columns.Add("Name");
            lvList.Columns.Add("Description");
            SizeColumns();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            SizeColumns();
        }

        private void SizeColumns()
        {
            if (lvList.Columns.Count >= 3)
            {
                lvList.Columns[0].Width = (int) (lvList.Width*.20);
                lvList.Columns[1].Width = (int) (lvList.Width*.30);
                lvList.Columns[2].Width = lvList.Width - (lvList.Columns[0].Width + lvList.Columns[1].Width);
            }
        }

        protected override void btnAdd_Click(object sender, EventArgs e)
        {
            var form = new SwitchForm(_instrument);
            if (DialogResult.OK == form.ShowDialog())
            {
                Item switchItem = form.SwitchItem;
                if (switchItem == null)
                    switchItem = new Switch();
                AddSwitchItem(switchItem);
            }
        }

        protected override void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvList.Columns.Count > 0)
            {
                var switchItem = (Item) lvList.SelectedItems[0].Tag;
                String prompt = String.Format(MessageManager.getMessage("Generic.delete.prompt"), "switch item",
                    switchItem.name);
                String title = MessageManager.getMessage("Generic.title.verification");
                if (DialogResult.Yes == MessageBox.Show(prompt,
                    title,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question))
                {
                    lvList.SelectedItems[0].Remove();
                }
            }
        }

        protected override void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvList.SelectedItems.Count > 0)
            {
                var form = new SwitchForm(_instrument);
                form.SwitchItem = lvList.SelectedItems[0].Tag as Item;
                if (DialogResult.OK == form.ShowDialog())
                {
                    Item switchItem = form.SwitchItem;
                    lvList.SelectedItems[0].Tag = switchItem;
                    lvList.SelectedItems[0].SubItems[1].Text = switchItem.name;
                    lvList.SelectedItems[0].SubItems[2].Text = switchItem.Description;
                }
            }
        }
    }
}