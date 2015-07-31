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
using ATMLModelLibrary.model.equipment;
using ATMLCommonLibrary.controls.lists;

namespace ATMLCommonLibrary.controls.bus
{
    public partial class BusListControl : ATMLListControl
    {
        private List<Bus> _buses;
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<Bus> Buses
        {
            get { ControlsToData();  return _buses != null && _buses.Count == 0 ? null : _buses; }
            set { _buses = value; DataToControls();  }
        }

        public BusListControl()
        {
            InitializeComponent();
            InitListView();
        }


        private void InitListView()
        {
            ListName = "Bus";
            DataObjectName = "Bus";
            DataObjectFormType = typeof(BusForm);
            AddColumnData("Type", "Type", .10);
            AddColumnData("Value", "ToString()", .90);
            InitColumns();
        }

        private void ControlsToData()
        {
            _buses = null;
            if (lvList.Items.Count > 0)
            {
                _buses = new List<Bus>();
                foreach (ListViewItem lvi in lvList.Items)
                {
                    _buses.Add((Bus)lvi.Tag);
                }
            }
        }

        private void DataToControls()
        {
            if (_buses != null)
            {
                lvList.Items.Clear();
                foreach (Bus bus in _buses)
                {
                    var lvi = new ListViewItem(bus.GetType().Name);
                    lvi.SubItems.Add(bus.ToString());
                    lvi.Tag = bus;
                    lvList.Items.Add(lvi);
                }
            }
        }
    }
}
