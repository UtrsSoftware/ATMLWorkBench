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
using ATMLCommonLibrary.forms;
using ATMLModelLibrary.model.common;

namespace ATMLCommonLibrary.controls.connector
{
    public partial class ConnectorSelectionForm : ATMLForm
    {
        private PhysicalInterfaceConnectors _connectors;
        private string _selectedConnectorName;
        private string _selectedPinName;

        public ConnectorSelectionForm()
        {
            InitializeComponent();
            Closing += ConnectorSelectionForm_Closing;
            lvConnectorPins.MultiSelect = MultiSelect;
        }

        public bool MultiSelect
        {
            set { lvConnectorPins.MultiSelect = value; }
            get { return lvConnectorPins.MultiSelect; }
        }

        public ICollection<ConnectorLocation> SelectedConnectorPins
        {
            get
            {
                ICollection<ConnectorLocation> list = new List<ConnectorLocation>();
                foreach (ListViewItem lvi in lvConnectors.SelectedItems)
                {
                    var connector = lvi.Tag as Connector;
                    if (connector != null)
                    {
                        foreach (ListViewItem selectedItem in lvConnectorPins.SelectedItems)
                        {
                            var connectorPin = selectedItem.Tag as ConnectorPin;
                            if (connectorPin != null)
                            {
                                ConnectorLocation loc = new ConnectorLocation();
                                loc.connectorID = connector.ID;
                                loc.pinID = connectorPin.ID;
                                list.Add( loc );
                            }
                        }
                    }
                }
                return list;
            }
        }

        public PhysicalInterfaceConnectors Connectors
        {
            get
            {
                ControlsToData();
                return _connectors;
            }
            set
            {
                _connectors = value;
                DataToControls();
            }
        }

        public string SelectedConnectorName
        {
            get { return _selectedConnectorName; }
            set { _selectedConnectorName = value; }
        }

        public string SelectedPinName
        {
            get { return _selectedPinName; }
            set { _selectedPinName = value; }
        }

        private void ConnectorSelectionForm_Closing( object sender, CancelEventArgs e )
        {
            if (DialogResult == DialogResult.OK)
            {
                if (lvConnectors.SelectedItems.Count > 0)
                {
                    var connector = lvConnectors.SelectedItems[0].Tag as Connector;
                    if (connector != null)
                        _selectedConnectorName = connector.ID;
                }

                if (lvConnectorPins.SelectedItems.Count > 0)
                {
                    var connectorPin = lvConnectorPins.SelectedItems[0].Tag as ConnectorPin;
                    if (connectorPin != null)
                        _selectedPinName = connectorPin.ID;
                }
            }
        }

        private void DataToControls()
        {
            if (_connectors != null)
            {
                lvConnectors.ConnectorInterface = _connectors;
            }
        }

        private void ControlsToData()
        {
        }

        private void lvConnectors_SelectedIndexChanged( object sender, EventArgs e )
        {
            if (lvConnectors.SelectedItems.Count > 0)
            {
                var connector = lvConnectors.SelectedItems[0].Tag as Connector;
                if (connector != null)
                {
                    lvConnectorPins.Connector = connector;
                }
            }
        }
    }
}