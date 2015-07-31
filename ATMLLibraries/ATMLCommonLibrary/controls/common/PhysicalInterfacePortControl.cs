/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using ATMLModelLibrary.model.common;
using ATMLUtilitiesLibrary;

namespace ATMLCommonLibrary.controls.common
{
    public partial class PhysicalInterfacePortControl : UserControl
    {
        private PhysicalInterfaceConnectors connectors;

        private PhysicalInterfacePortsPort port;

        public PhysicalInterfacePortControl()
        {
            InitializeComponent();
            BackColor = ATMLContext.COLOR_PANEL;
        }

        public PhysicalInterfaceConnectors Connectors
        {
            get { return connectors; }
            set
            {
                connectors = value;
                connectorLocationPinListControl.Connectors = connectors;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PhysicalInterfacePortsPort Port
        {
            get
            {
                ControlsToData();
                return port;
            }
            set
            {
                port = value;
                DataToControls();
            }
        }

        private void DataToControls()
        {
            if (port != null)
            {
                portControl.Port = port;
                if (port.ConnectorPins != null)
                    connectorLocationPinListControl.ConnectorLocations = port.ConnectorPins.ToList();
            }
        }

        private void ControlsToData()
        {
            if (port == null)
                port = new PhysicalInterfacePortsPort();
            Port tempPort = portControl.Port;
            if (tempPort != null)
            {
                port.direction = tempPort.direction;
                port.directionSpecified = tempPort.directionSpecified;
                port.Extension = tempPort.Extension;
                port.name = tempPort.name;
                port.type = tempPort.type;
                port.typeSpecified = tempPort.typeSpecified;
                connectorLocationPinListControl.Connectors = connectors;
                if (connectorLocationPinListControl.ConnectorLocations != null
                    && connectorLocationPinListControl.ConnectorLocations.Count > 0)
                    port.ConnectorPins = connectorLocationPinListControl.ConnectorLocations;
                else
                    port.ConnectorPins = null;
                //TODO: Address if we start handling Extentions
                port.Extension = null;
            }
        }
    }
}