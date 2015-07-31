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

namespace ATMLCommonLibrary.controls.connector
{
    public partial class ConnectorLocationPinListControl : ATMLListControl
    {
        protected ToolStripButton BtnSelect;
        private List<ConnectorLocation> _connectorLocations;
        private PhysicalInterfaceConnectors _connectors;

        //---------------------------------------------------------//
        //--- Constructs a new ConnectorLocationPinList control ---//
        //---------------------------------------------------------//
        public ConnectorLocationPinListControl()
        {
            InitializeComponent();
            lvList.FullRowSelect = true;
            lvList.Columns.Add("Connector ID");
            lvList.Columns.Add("Pin ID");
            lvList.Columns[0].Width = -2;
            lvList.Columns[1].Width = -2;
            BtnSelect = new ToolStripButton();
            toolStrip.Items.Add(BtnSelect);
            BtnSelect.Click += btnSelect_Click;
            this.ShowFind = true;
            btnFind.Click += new EventHandler(btnFind_Click);

        }

        void btnFind_Click(object sender, EventArgs e)
        {
            ConnectorSelectionForm form = new ConnectorSelectionForm();
            form.Connectors = _connectors;
            form.MultiSelect = true;
            if (DialogResult.OK == form.ShowDialog())
            {
                foreach (ConnectorLocation location in form.SelectedConnectorPins)
                {
                    AddConnectorLocation( location );
                }
            }
        }

        public PhysicalInterfaceConnectors Connectors
        {
            get { return _connectors; }
            set { _connectors = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<ConnectorLocation> ConnectorLocations
        {
            get
            {
                ControlsToData();
                return _connectorLocations;
            }
            set
            {
                _connectorLocations = value;
                DataToControls();
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            var context = new ATMLSelectionCheckListContext();
            context.SelectionLabelText = "Connector";
            context.SelectionData = _connectors.Connector;
            context.SelectionListClassName = "Pins";
            context.ListItemClassName = "ATMLModelLibrary.model.common.ConnectorPin";

            var form = new ATMLSelectionCheckListForm(context);
            if (DialogResult.OK == form.ShowDialog())
            {
            }
        }

        //-----------------------------------------------------------------------------------//
        //--- Call to move all the form controls values to the appropriate data object(s) ---//
        //-----------------------------------------------------------------------------------//
        private void ControlsToData()
        {
            if (_connectorLocations == null)
                _connectorLocations = new List<ConnectorLocation>();
            _connectorLocations.Clear();
            foreach (ListViewItem lvi in Items )
            {
                _connectorLocations.Add( lvi.Tag as ConnectorLocation  );
            }

        }

        //----------------------------------------------------------------------------------------//
        //--- Call to move all the data in the data object(s) to the appropriate form controls ---//
        //----------------------------------------------------------------------------------------//
        private void DataToControls()
        {
            if (_connectorLocations != null)
            {
                foreach (ConnectorLocation connectorLocation in _connectorLocations)
                    AddListViewItem(connectorLocation);
            }
        }

        //-------------------------------------------------------------------------------------------//
        //--- Add a new connector location list control to the list view as well as the data list ---//
        //-------------------------------------------------------------------------------------------//
        public void AddConnectorLocation(ConnectorLocation connectorLocation)
        {
            if (!HasConnectorLocation(connectorLocation))
                AddListViewItem(connectorLocation);
        }

        private bool HasConnectorLocation( ConnectorLocation connectorLocation )
        {
            bool hasConnectorLocation = false;
            foreach (ListViewItem selectedItem in SelectedItems)
            {
                ConnectorLocation item = selectedItem.Tag as ConnectorLocation;
                if (item != null && item.connectorID.Equals( connectorLocation.connectorID ) &&
                    item.pinID.Equals( connectorLocation.pinID ))
                {
                    hasConnectorLocation = true;
                    break;
                }
            }
            return hasConnectorLocation;
        }

        //-------------------------------------------------------------//
        //--- Add a connector location pin to the list view control ---//
        //-------------------------------------------------------------//
        private int AddListViewItem(ConnectorLocation connectorLocation)
        {
            if (connectorLocation == null)
                connectorLocation = new ConnectorLocation();
            var item = new ListViewItem(connectorLocation.connectorID);
            item.SubItems.Add(connectorLocation.pinID);
            item.Tag = connectorLocation;
            if (lvList.Columns.Count >= 2)
            {
                lvList.Columns[0].Width = -2;
                lvList.Columns[1].Width = -2;
            }
            return lvList.Items.Add(item).Index;
        }

        //----------------------------------------//
        //--- Add a new connector location pin ---//
        //----------------------------------------//
        protected override void btnAdd_Click(object sender, EventArgs e)
        {
            var form = new ConnectorLocationPinForm(_connectors);
            //--------------------------------------------------------------------------------------------------------------//
            //--- If there already locations in the list, then lets grab the last connector id and set it on the new pin ---//
            //--------------------------------------------------------------------------------------------------------------//
            var locationPin = new ConnectorLocation();
            if (lvList.Items.Count > 0)
                locationPin.connectorID = ((ConnectorLocation) lvList.Items[lvList.Items.Count - 1].Tag).connectorID;
            form.ConnectorLocation = locationPin;
            if (DialogResult.OK == form.ShowDialog())
            {
                AddConnectorLocation(form.ConnectorLocation);
            }
        }

        //------------------------------------------------//
        //--- Edit the selected connector location pin ---//
        //------------------------------------------------//
        protected override void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvList.SelectedItems.Count > 0)
            {
                var location = (ConnectorLocation) lvList.SelectedItems[0].Tag;
                var form = new
                    ConnectorLocationPinForm(_connectors);
                form.ConnectorLocation = location;
                if (DialogResult.OK == form.ShowDialog())
                {
                    lvList.SelectedItems[0].Tag = form.ConnectorLocation;
                    lvList.SelectedItems[0].Text = form.ConnectorLocation.connectorID;
                    lvList.SelectedItems[0].SubItems[1].Text = form.ConnectorLocation.pinID;
                }
            }
        }

        //--------------------------------------------------//
        //--- Delete the selected connector location pin ---//
        //--------------------------------------------------//
        protected override void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvList.SelectedItems.Count > 0)
            {
                var location = (ConnectorLocation) lvList.SelectedItems[0].Tag;
                if (DialogResult.Yes ==
                    MessageBox.Show(
                        String.Format("Are you sure you want to delete Port Location Pin \"{0}-{1}\"?",
                            location.connectorID, location.pinID),
                        "Delete Port Location Pin",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question))
                {
                    lvList.Items.Remove(lvList.SelectedItems[0]);
                    _connectorLocations.Remove(location);
                }
            }
        }
    }
}