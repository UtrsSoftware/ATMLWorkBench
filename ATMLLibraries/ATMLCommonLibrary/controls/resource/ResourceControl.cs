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
using ATMLModelLibrary.model.common;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls
{
    public partial class ResourceControl : RepeatedItemControl
    {
        public ResourceControl()
        {
            InitializeComponent();
            InitControls();
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Resource Resource
        {
            get
            {
                ControlsToData();
                return (Resource) Item;
            }
            set
            {
                RepeatedItem = value;
                DataToControls();
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }

        private void triggerListControl_Load(object sender, EventArgs e)
        {
        }

        private void DataToControls()
        {
            base.DataToControls();
            if (Item != null && Item is Resource)
            {
                var resource = Item as Resource;
                edtIndex.Value = resource.index;
                if (resource.Interface != null)
                    portListControl.Ports = resource.Interface.Ports;
                triggerListControl.Resource = resource;
            }
        }

        private void ControlsToData()
        {
            base.ControlsToData();
            if (Item != null && Item is Resource)
            {
                var resource = Item as Resource;
                resource.index = edtIndex.GetValue<int>();
                if (resource.Interface == null)
                    resource.Interface = new Interface();
                resource.Interface.Ports = portListControl.Ports;
                Resource rc = triggerListControl.Resource;
                resource.Triggers = rc.Triggers;
            }
        }

        private void ResourceControl_Validating(object sender, CancelEventArgs e)
        {
        }
    }
}