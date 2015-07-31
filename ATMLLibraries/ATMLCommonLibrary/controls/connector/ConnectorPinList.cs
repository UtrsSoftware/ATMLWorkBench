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
using ATMLDataAccessLibrary.model;

namespace ATMLCommonLibrary.controls.connector
{
    public partial class ConnectorPinList : ATMLListControl
    {
        private List<ConnectorPin> _connectorPins = new List<ConnectorPin>();

        public ConnectorPinList()
        {
            InitializeComponent();
            InitListView();
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<ConnectorPin> ConnectorPins
        {
            get
            {
                ControlsToData();
                return ( _connectorPins == null || _connectorPins.Count == 0 ) ? null : _connectorPins;
            }
            set
            {
                _connectorPins = value;
                DataToControls();
            }
        }

        private void InitListView()
        {
            DataObjectName = "ConnectorPin";
            DataObjectFormType = typeof (ConnectorPinForm);
            AddColumnData("Id", "ID", .20);
            AddColumnData("Name", "name", .80);
            InitColumns();
        }


        private void DataToControls()
        {
            if (_connectorPins != null)
            {
                foreach (ConnectorPin pin in _connectorPins)
                    AddListViewObject(pin);
            }
        }

        private void ControlsToData()
        {
            if (lvList.Items.Count == 0)
            {
                _connectorPins = null;
            }
            else
            {
                if (_connectorPins == null)
                    _connectorPins = new List<ConnectorPin>();
                _connectorPins.Clear();
                foreach (ListViewItem lvi in lvList.Items)
                    _connectorPins.Add(lvi.Tag as ConnectorPin);
            }
        }


        public void AddPin(dbConnectorPin pin)
        {
            var cpin = new ConnectorPin();
            cpin.ID = pin.pinIdx.ToString();
            cpin.name = pin.pinName;
            //------------------------------------------------------------------------------------------------------------//
            //--- Note: The description is intentially left out from this update due to a poor schema design for ATML. ---//
            //---       The Definition (ItemDescription) is for the manufacturer pin description and should not be     ---//
            //---       part of a pin instance.                                                                        ---//
            //------------------------------------------------------------------------------------------------------------//
            AddPin(cpin);
        }


        public void AddPin(ConnectorPin pin)
        {
            var item = new ListViewItem("" + pin.ID);
            item.SubItems.Add(pin.name);
            item.SubItems.Add(pin.Definition!=null?pin.Definition.Description:"");
            item.SubItems.Add("");
            item.Tag = pin;
            lvList.Items.Add(item);
        }

        public void Clear()
        {
            Items.Clear();
        }

        public void GeneratePinList(int pinCount)
        {
            int pins = Items.Count;
            if (pinCount > pins)
            {
                for (int i = 1; i <= (pinCount - pins); i++)
                {
                    var item = new ListViewItem("" + (pins + i + 1));
                    var pin = new ConnectorPin();
                    pin.ID = "" + (Items.Count + 1);
                    pin.name = "N/A";
                    AddPin(pin);
                }
            }
            else if (pinCount < pins)
            {
                for (int i = pins; i > pinCount; i--)
                {
                    try
                    {
                        Items.RemoveAt(i - 1);
                    }
                    catch (Exception er)
                    {
                        MessageBox.Show(string.Format("An Error occurred removing connector pin {0}\n{1}", i, er.Message));
                    }
                }
            }
        }
    }
}