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
using ATMLModelLibrary.model.common;
using ATMLUtilitiesLibrary;

namespace ATMLCommonLibrary.controls.connector
{
    public partial class ConnectorPinListView : ListView
    {
        private bool _hasErrors;
        private Connector _connector;
        protected String _listName;

        public ConnectorPinListView()
        {
            FullRowSelect = true;
            View = View.Details;
            initColumns();
            Resize += ConnectorPinListView_Resize;
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Connector Connector
        {
            get { return _connector; }
            set
            {
                Items.Clear();
                _connector = value;
                if (_connector != null && _connector.Pins != null)
                {
                    foreach (ConnectorPin pin in _connector.Pins)
                    {
                        var item = new ListViewItem(pin.ID);
                        item.SubItems.Add(pin.name);
                        item.Tag = pin;
                        Items.Add(item);
                        item.BackColor = item.Index%2 == 0 ? ATMLContext.COLOR_LIST_EVEN : ATMLContext.COLOR_LIST_ODD;
                    }
                }
            }
        }

        public bool HasErrors
        {
            get { return _hasErrors; }
            set { _hasErrors = value; }
        }

        private void ConnectorPinListView_Resize(object sender, EventArgs e)
        {
            if (Columns.Count >= 2)
            {
                Columns[0].Width = (int) ( Width*.20 );
                Columns[1].Width = (int) ( Width*.80 );
            }
        }

        private void initColumns()
        {
            Columns.Clear();
            Columns.Add("Id");
            Columns.Add("Name");
            Columns[0].Width = (int) (Width*.20);
            Columns[1].Width = (int) (Width*.80);
        }
    }

    public class ConnectorListView : ListView
    {
        private bool _hasErrors;
        private PhysicalInterfaceConnectors connectorInterface;

        public ConnectorListView()
        {
            initColumns();
            FullRowSelect = true;
            View = View.Details;
            Resize += OnResize;
        }

        public ConnectorListView(IContainer container):this()
        {
            container.Add(this);
        }

        private void OnResize(object sender, EventArgs eventArgs)
        {
            if (Columns.Count >= 4)
            {
                Columns[0].Width = (int) ( Width*.15 );
                Columns[1].Width = (int) ( Width*.40 );
                Columns[2].Width = (int) ( Width*.30 );
                Columns[3].Width = (int) ( Width*.15 );
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PhysicalInterfaceConnectors ConnectorInterface
        {
            get
            {
                ControlsToData();
                return connectorInterface;
            }
            set
            {
                connectorInterface = value;
                DataToControls();
            }
        }

        public bool HasErrors
        {
            get { return _hasErrors; }
            set { _hasErrors = value; }
        }

        private void DataToControls()
        {
            Items.Clear();
            if (connectorInterface != null)
            {
                List<Connector> connectors = connectorInterface.Connector;
                if (connectors != null)
                {
                    foreach (Connector connector in connectors)
                    {
                        AddConnector(connector);
                    }
                }
            }
        }

        private void ControlsToData()
        {
        }

        public void AddConnector(Connector connector)
        {
            String description = connector.Description;
            String id = connector.ID;
            String name = connector.name;
            String type = connector.type;
            var item = new ListViewItem(id);
            item.SubItems.Add(name);
            item.SubItems.Add(type);
            item.SubItems.Add("" + (connector.Pins == null ? 0 : connector.Pins.Count));
            item.Tag = connector;
            Items.Add(item);
            item.BackColor = item.Index%2 == 0 ? ATMLContext.COLOR_LIST_EVEN : ATMLContext.COLOR_LIST_ODD;
        }

        public void UpdateConnector(ListViewItem item, Connector connector)
        {
            String description = connector.Description;
            String id = connector.ID;
            String name = connector.name;
            String type = connector.type;
            item.SubItems[0].Text = id;
            item.SubItems[1].Text = name;
            item.SubItems[2].Text = type;
            item.SubItems[3].Text = connector.Pins == null ? "0" : "" + connector.Pins.Count;
            item.Tag = connector;
        }

        private void initColumns()
        {
            Columns.Add("Id");
            Columns.Add("Name");
            Columns.Add("Type");
            Columns.Add("Pins");
            OnResize(this, null);
        }
    }
}