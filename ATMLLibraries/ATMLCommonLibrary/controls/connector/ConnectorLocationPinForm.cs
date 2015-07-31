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
using ATMLModelLibrary.model.common;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.forms
{
    public partial class ConnectorLocationPinForm : ATMLForm
    {
        private ConnectorLocation connectorLocation;
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ConnectorLocation ConnectorLocation
        {
            get { ControlsToData();  return connectorLocation; }
            set { connectorLocation = value; DataToControls(); }
        }

        public ConnectorLocationPinForm( PhysicalInterfaceConnectors connectors )
        {
            InitializeComponent();
            BackColor = ATMLUtilitiesLibrary.ATMLContext.COLOR_FORM;
            panel1.BackColor = ATMLUtilitiesLibrary.ATMLContext.COLOR_PANEL;
            connectorLocationPinControl.Connectors = connectors;
        }

        private void DataToControls()
        {
            if (connectorLocation == null)
                connectorLocation = new ConnectorLocation();
            connectorLocationPinControl.ConnectorLocationPin = connectorLocation;
        }

        private void ControlsToData()
        {
            if (connectorLocation == null)
                connectorLocation = new ConnectorLocation();
            connectorLocation = connectorLocationPinControl.ConnectorLocationPin;

        }

        private void ConnectorLocationPinForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void connectorLocationPinControl_Load(object sender, EventArgs e)
        {

        }
    }
}
