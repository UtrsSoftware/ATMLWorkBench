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
using ATMLCommonLibrary.controls.lists;
using ATMLCommonLibrary.forms;
using ATMLModelLibrary.model.common;

namespace ATMLCommonLibrary.controls.common
{
    public partial class PortListControl : ATMLListControl
    {
        private List<Port> ports;

        public PortListControl()
        {
            InitializeComponent();
            InitListView();
        }


        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<Port> Ports
        {
            get
            {
                ControlsToData();
                return ports==null || ports.Count == 0 ? null : ports;
            }
            set
            {
                ports = value;
                DataToControls();
            }
        }

        private event mappingDelegate OnMapping;


        private void InitListView()
        {
            DataObjectName = "Port";
            DataObjectFormType = typeof(PortForm);
            AddColumnData("Name", "ToString()", 1.00);
            InitColumns();
        }


        private void ControlsToData()
        {
            ports = null;
            if (Items.Count > 0)
            {
                ports = new List<Port>();
                foreach (ListViewItem lvi in Items)
                    ports.Add((Port) lvi.Tag);
            }
        }

        private void DataToControls()
        {
            if (ports != null)
            {
                Items.Clear();
                foreach (Port port in ports)
                    AddListViewObject(port);
            }
        }
 
        private void btnMapping_Click(object sender, EventArgs e)
        {
            if (OnMapping != null)
                OnMapping();
        }

        private delegate void mappingDelegate();
    }
}