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
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ATMLCommonLibrary.controls;
using ATMLModelLibrary.model.common;
using ATMLModelLibrary.model.equipment;


namespace ATMLCommonLibrary.forms
{
    public partial class PhysicalInterfacePortForm : ATMLForm
    {
        private PhysicalInterfacePortsPort port;
        public PhysicalInterfacePortsPort Port
        {
            get { ControlsToData();  return port; }
            set { port = value; DataToControls(); }
        }

        public PhysicalInterfacePortForm( PhysicalInterfaceConnectors connectors )
        {
            InitializeComponent();
            physicalInterfacePortControl.Connectors = connectors;
        }

        private void DataToControls()
        {
            this.physicalInterfacePortControl.Port = port;
        }

        private void ControlsToData()
        {
            port = this.physicalInterfacePortControl.Port;
        }

        private void physicalInterfacePortControl_Load(object sender, EventArgs e)
        {

        }
    }
}
