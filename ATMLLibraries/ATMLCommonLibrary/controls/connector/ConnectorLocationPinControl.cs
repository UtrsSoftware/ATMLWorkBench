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
using ATMLCommonLibrary.controls.connector;
using ATMLModelLibrary.model.common;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls
{
    public partial class ConnectorLocationPinControl : UserControl
    {
        private PhysicalInterfaceConnectors connectors;

        private ConnectorLocation connectorLocationPin;
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ConnectorLocation ConnectorLocationPin
        {
            get { ControlsToData();  return connectorLocationPin; }
            set { connectorLocationPin = value; DataToControls();  }
        }

        public PhysicalInterfaceConnectors Connectors
        {
            get { return connectors; }
            set { connectors = value; }
        }

        public ConnectorLocationPinControl()
        {
            InitializeComponent();
        }

        private void ControlsToData()
        {
            if (connectorLocationPin == null)
                connectorLocationPin = new ConnectorLocation();
            connectorLocationPin.connectorID = edtConnectorId.Text;
            connectorLocationPin.pinID = edtConnectorPinId.Text;
        }

        private void DataToControls()
        {
            if (connectorLocationPin != null)
            {
                edtConnectorId.Text = connectorLocationPin.connectorID;
                edtConnectorPinId.Text = connectorLocationPin.pinID;
            }
        }

        private void btnSelectConnector_Click(object sender, EventArgs e)
        {
            ConnectorSelectionForm form = new ConnectorSelectionForm();
            form.Connectors = connectors;
            if (DialogResult.OK == form.ShowDialog())
            {
                edtConnectorId.Text = form.SelectedConnectorName;
                edtConnectorPinId.Text = form.SelectedPinName;
            }
        }
    }
}
