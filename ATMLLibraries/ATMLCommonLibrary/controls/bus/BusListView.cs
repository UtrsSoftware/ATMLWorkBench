/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
using System.ComponentModel;
using System.Windows.Forms;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.bus
{
    public partial class BusListView : ListView
    {
        public BusListView()
        {
            InitializeComponent();
            initColumns();
        }

        public BusListView(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            initColumns();
        }

        private void initColumns()
        {
            Columns.Clear();
            Columns.Add("Type");
            Columns.Add("Address");
        }

        public int AddBus(Bus bus)
        {
            var item = new ListViewItem(bus.GetType().Name);
            item.SubItems.Add(bus.defaultAddress);
            item.Tag = bus;
            return Items.Add(item).Index;
        }
    }
}