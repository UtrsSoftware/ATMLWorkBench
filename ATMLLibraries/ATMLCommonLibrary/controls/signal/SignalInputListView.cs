/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.ComponentModel;
using System.Windows.Forms;
using ATMLCommonLibrary.controls.awb;
using ATMLModelLibrary.model.signal.basic;

namespace ATMLCommonLibrary.controls.signal
{
    public partial class SignalInputListView : AWBListView
    {
        public SignalInputListView()
        {
            InitializeComponent();
            initColumns();
        }

        public SignalInputListView(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            initColumns();
        }

        private void initColumns()
        {
            FullRowSelect = true;
            View = View.Details;
            Columns.Clear();
            Columns.Add("Name");
            Columns.Add("In");
            Columns.Add("Max Channels");
            SetColumnsWidths();
        }

        private void SetColumnsWidths()
        {
            if (Columns.Count >= 3)
            {
                Columns[0].Width = (int) ( Width*.33 );
                Columns[1].Width = (int) ( Width*.33 );
                Columns[2].Width = Width - ( Columns[0].Width + Columns[1].Width );
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            SetColumnsWidths();
        }

        public int addSignalInput(SignalIN input)
        {
            var item = new ListViewItem(input.name);
            item.SubItems.Add(input.In == null ? "" : input.In.ToString());
            item.SubItems.Add("" + input.maxChannels);
            item.Tag = input;
            item = Items.Add(item);
            if (item.Index%2 == 0)
            {
                item.BackColor = AltColor1;
            }
            else
            {
                item.BackColor = AltColor2;
            }
            return item.Index;
        }

        public void addSignalInputs(SignalIN[] inputs)
        {
            foreach (SignalIN input in inputs)
            {
                addSignalInput(input);
            }
        }
    }
}