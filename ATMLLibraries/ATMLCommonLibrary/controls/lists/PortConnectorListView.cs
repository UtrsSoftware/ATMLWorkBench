/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ATMLModelLibrary.model.common;

namespace ATMLCommonLibrary.controls.lists
{
    public partial class PortConnectorListView : ListView
    {
        private bool _hasErrors;
        private PhysicalInterfacePortsPort _port;

        public PortConnectorListView()
        {
            Columns.Add("Connector");
            Columns.Add("Pin Id");
            Columns[0].Width = -2;
            Columns[1].Width = -2;
        }

        public PhysicalInterfacePortsPort Port
        {
            get { return _port; }
            set
            {
                _port = value;
                Items.Clear();
                if (_port != null && _port.ConnectorPins != null)
                {
                    foreach (ConnectorLocation pin in _port.ConnectorPins)
                    {
                        var item = new ListViewItem(pin.connectorID);
                        item.SubItems.Add(pin.pinID);
                        item.Tag = pin;
                        Items.Add(item);
                    }
                }
            }
        }

        public bool HasErrors
        {
            get { return _hasErrors; }
            set { _hasErrors = value; }
        }
    }

    public class PortListView : ListView
    {
        private bool _hasErrors;
        private PhysicalInterfacePorts _portInterface;

        public PortListView()
        {
            Columns.Add("Name");
            Columns.Add("Direction");
            Columns.Add("Type");
            Columns.Add("Pins");
            Columns[0].Width = -2;
            Columns[1].Width = -2;
            Columns[2].Width = -2;
            Columns[3].Width = -2;
        }

        public PhysicalInterfacePorts PortInterface
        {
            get { return _portInterface; }
            set
            {
                _portInterface = value;
                if (_portInterface != null)
                {
                    Items.Clear();
                    List<PhysicalInterfacePortsPort> ports = _portInterface.Port;
                    foreach (PhysicalInterfacePortsPort port in ports)
                    {
                        AddPort(port);
                    }
                }
            }
        }

        public bool HasErrors
        {
            get { return _hasErrors; }
            set { _hasErrors = value; }
        }

        public void AddPort(PhysicalInterfacePortsPort port)
        {
            String name = port.name;
            int pinCount = 0;
            if (port.ConnectorPins != null)
                pinCount = port.ConnectorPins.Count;
            String directionText = port.directionSpecified ? port.direction.ToString() : "";
            String typeText = port.typeSpecified ? port.type.ToString() : "";
            var item = new ListViewItem(name);
            item.SubItems.Add(directionText);
            item.SubItems.Add(typeText);
            item.SubItems.Add("" + pinCount);
            item.Tag = port;
            Items.Add(item);
        }


        public void UpdatePort(ListViewItem item)
        {
            var port = (PhysicalInterfacePortsPort) item.Tag;
            item.SubItems[0].Text = port.name;
            item.SubItems[1].Text = port.directionSpecified ? Enum.GetName(typeof (PortDirection), port.direction) : "";
            item.SubItems[2].Text = port.typeSpecified ? Enum.GetName(typeof (PortType), port.type) : "";
            item.SubItems[3].Text = port.ConnectorPins == null ? "" : "" + port.ConnectorPins.Count;
        }
    }
}