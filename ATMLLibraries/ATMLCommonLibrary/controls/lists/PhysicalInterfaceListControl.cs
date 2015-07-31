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
using System.Windows.Forms.VisualStyles;
using ATMLCommonLibrary.controls.connector;
using ATMLCommonLibrary.forms;
using ATMLCommonLibrary.Properties;
using ATMLModelLibrary.model.common;

namespace ATMLCommonLibrary.controls.lists
{
    public partial class PhysicalInterfaceListControl : ATMLControl
    {
        private bool _hasConnectors = true;
        private PhysicalInterface _physicalInterface = new PhysicalInterface();

        private PhysicalInterfaceConnectors _physicalInterfaceConnectors = new PhysicalInterfaceConnectors();
        private PhysicalInterfacePorts _physicalInterfacePorts = new PhysicalInterfacePorts();

        public PhysicalInterfaceListControl()
        {
            InitializeComponent();
            Validating += PhysicalInterfaceListControl_Validating;
            lvConnectors.SelectedIndexChanged += lvList_SelectedIndexChanged;
            lvPorts.SelectedIndexChanged += lvList_SelectedIndexChanged;
            tabControl4.ShowToolTips = true;
        }

        [Category( "Behaviour" )]
        [Description( "Show Connector Tab or not." )]
        public bool HasConnectors
        {
            get { return _hasConnectors; }
            set
            {
                _hasConnectors = value;
                if (!_hasConnectors)
                    tabControl4.TabPages.RemoveAt( 1 );
            }
        }

        [Browsable( false ), DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
        public PhysicalInterface PhysicalInterface
        {
            get
            {
                ControlsToData();
                return _physicalInterface;
            }
            set
            {
                _physicalInterface = value;
                DataToControls();
            }
        }

        public void SetInterfaceItems( List<object> items )
        {
            PhysicalInterface.Items = items;
            DataToControls();
        }

        //----------------------------------------------------//
        //--- Constructs a new InterfaceListControl object ---//
        //----------------------------------------------------//

        private void PhysicalInterfaceListControl_Validating( object sender, CancelEventArgs e )
        {
            tabConnectors.ToolTipText = "";
            tabPorts.ToolTipText = "";
            lvConnectors.HasErrors = false;
            lvPorts.HasErrors = false;
            errorProvider.SetError( this, "" );
            if (_physicalInterface.Items == null || _physicalInterface.Items.Count == 0)
            {
                lvConnectors.HasErrors = true;
                lvPorts.HasErrors = true;
                tabConnectors.ToolTipText = Resources.errmsg_at_least_one_interface_item;
                tabPorts.ToolTipText = Resources.errmsg_at_least_one_interface_item;
                e.Cancel = true;
                errorProvider.SetError( this, Resources.errmsg_at_least_one_interface_item );
            }
        }

        private void lvList_SelectedIndexChanged( object sender, EventArgs e )
        {
            SetButtonstates();
        }

        private void SetButtonstates()
        {
            bool hasSelected1 = lvConnectors.SelectedItems.Count > 0;
            bool hasSelected2 = lvPorts.SelectedItems.Count > 0;
            btnEditConnector.Visible = hasSelected1;
            btnDeleteConnector.Visible = hasSelected1;
            btnEditPort.Visible = hasSelected2;
            btnDeletePort.Visible = hasSelected2;
        }


        public void DataToControls()
        {
            foreach (object obj in _physicalInterface.Items)
            {
                if (obj is PhysicalInterfaceConnectors)
                    _physicalInterfaceConnectors = obj as PhysicalInterfaceConnectors;
                if (obj is PhysicalInterfacePorts)
                    _physicalInterfacePorts = obj as PhysicalInterfacePorts;
            }

            DataToControls( _physicalInterface.Items );
        }


        public void ControlsToData()
        {
            _physicalInterface.Items = null;
            if (lvConnectors.Items.Count > 0 || lvPorts.Items.Count > 0)
            {
                _physicalInterface.Items = new List<object>();
                if (lvConnectors.Items.Count > 0)
                {
                    if (_physicalInterfaceConnectors.Connector == null )
                        _physicalInterfaceConnectors.Connector = new List<Connector>();
                    _physicalInterfaceConnectors.Connector.Clear();
                    foreach (ListViewItem item in lvConnectors.Items)
                    {
                        _physicalInterfaceConnectors.Connector.Add( item.Tag as Connector );
                    }
                    _physicalInterface.Items.Add( _physicalInterfaceConnectors );
                }
                if (lvPorts.Items.Count > 0)
                {
                    if (_physicalInterfacePorts.Port == null)
                        _physicalInterfacePorts.Port = new List<PhysicalInterfacePortsPort>();
                    _physicalInterfacePorts.Port.Clear();
                    foreach (ListViewItem item in lvPorts.Items)
                    {
                        _physicalInterfacePorts.Port.Add(item.Tag as PhysicalInterfacePortsPort);
                    }
                    _physicalInterface.Items.Add(_physicalInterfacePorts);
                }
            }
        }

        //------------------------------------------------------------------------//
        //--- Called when the list of interface objects is set on this control ---//
        //------------------------------------------------------------------------//
        public void DataToControls( List<object> interfaceItem )
        {
            //--------------------------------------------------------------------------------------------------//
            //--- Check to see the type of interface object and assign them to their cooresponding list view ---//
            //--------------------------------------------------------------------------------------------------//
            foreach (Object obj in interfaceItem)
            {
                if (obj is PhysicalInterfaceConnectors)
                {
                    var connectorInterface = (PhysicalInterfaceConnectors) obj;
                    lvConnectors.ConnectorInterface = connectorInterface;
                }
                else if (obj is PhysicalInterfacePorts)
                {
                    var portInterface = (PhysicalInterfacePorts) obj;
                    lvPorts.PortInterface = portInterface;
                }
            }
        }

        //---------------------------------------------------------//
        //--- Call to add a new connector item to the list view ---//
        //---------------------------------------------------------//
        private void btnAddConnector_Click( object sender, EventArgs e )
        {
            var form = new ConnectorForm();
            var connector = new Connector();
            form.Connector = connector;
            form.TopLevel = true;
            form.Closed += delegate
                           {
                               if (DialogResult.OK == form.DialogResult)
                               {
                                   connector = form.Connector;
                                   lvConnectors.AddConnector( connector );
                                   //if (_physicalInterfaceConnectors.Connector == null)
                                   //    _physicalInterfaceConnectors.Connector = new List<Connector>();
                                   //_physicalInterfaceConnectors.Connector.Add( connector );
                               }
                           };
            form.Show();
        }

        //-----------------------------------------------------------------//
        //--- Call to edit the selected connector item in the list view ---//
        //-----------------------------------------------------------------//
        private void btnEditConnector_Click( object sender, EventArgs e )
        {
            if (lvConnectors.SelectedItems.Count > 0)
            {
                var form = new ConnectorForm();
                var connector = (Connector) lvConnectors.SelectedItems[0].Tag;
                form.Connector = connector;
                form.TopLevel = true;
                form.Closed += delegate
                               {
                                   if (DialogResult.OK == form.DialogResult)
                                   {
                                       ListViewItem item = lvConnectors.SelectedItems[0];
                                       lvConnectors.UpdateConnector( item, form.Connector );
                                       lvPins.Connector = (Connector) lvConnectors.SelectedItems[0].Tag;
                                   }
                               };
                form.Show();
            }
        }


        //-----------------------------------------------------------------//
        //--- Call to delete the selected connector item in the list view ---//
        //-----------------------------------------------------------------//
        private void btnDeleteConnector_Click(object sender, EventArgs e)
        {
            if (lvConnectors.SelectedItems.Count > 0)
            {
                var connector = (Connector)lvConnectors.SelectedItems[0].Tag;
                if( DialogResult.Yes == MessageBox.Show( string.Format("Delete connector \"{0}\"?", connector.ID ), 
                                                         Resources.V_E_R_I_F_Y, 
                                                         MessageBoxButtons.YesNo, 
                                                         MessageBoxIcon.Question ))
                {
                    ListViewItem item = lvConnectors.SelectedItems[0];
                    item.Remove();
                };
            }
        }


        //--------------------------------------------------//
        //--- Called when the selected port item changes ---//
        //--------------------------------------------------//
        private void lvPorts_SelectedIndexChanged( object sender, EventArgs e )
        {
            //--- Load lvPortConnectors Pins ---//
            if (lvPorts.SelectedItems.Count > 0)
            {
                lvPortConnectors.Port = (PhysicalInterfacePortsPort) lvPorts.SelectedItems[0].Tag;
            }
        }

        //----------------------------------------------------------------//
        //--- Called when the selected connector list item has changed ---//
        //----------------------------------------------------------------//
        private void lvConnectors_SelectedIndexChanged( object sender, EventArgs e )
        {
            if (lvConnectors.SelectedItems.Count > 0)
            {
                lvPins.Connector = (Connector) lvConnectors.SelectedItems[0].Tag;
            }
        }

        //--------------------------------------------------//
        //--- Called when the add port button is clicked ---//
        //--------------------------------------------------//
        private void btnAddPort_Click( object sender, EventArgs e )
        {
            var port = new PhysicalInterfacePortsPort();
            var form = new PhysicalInterfacePortForm( _physicalInterfaceConnectors );
            if (DialogResult.OK == form.ShowDialog())
            {
                lvPorts.AddPort( form.Port );
                //if (_physicalInterfacePorts.Port == null)
                //    _physicalInterfacePorts.Port = new List<PhysicalInterfacePortsPort>();
                //_physicalInterfacePorts.Port.Add( form.Port );
            }
        }

        //---------------------------------------------------//
        //--- Called when the edit port button is clicked ---//
        //---------------------------------------------------//
        private void btnEditPort_Click( object sender, EventArgs e )
        {
            if (lvPorts.SelectedItems.Count > 0)
            {
                var form = new PhysicalInterfacePortForm( _physicalInterfaceConnectors );
                form.Port = (PhysicalInterfacePortsPort) lvPorts.SelectedItems[0].Tag;
                if (DialogResult.OK == form.ShowDialog())
                {
                    lvPorts.SelectedItems[0].Tag = form.Port;
                    lvPorts.UpdatePort( lvPorts.SelectedItems[0] );
                    lvPortConnectors.Port = (PhysicalInterfacePortsPort) lvPorts.SelectedItems[0].Tag;
                }
            }
        }

        //---------------------------------------------------//
        //--- Called when the delete port button is clicked ---//
        //---------------------------------------------------//
        private void btnDeletePort_Click(object sender, EventArgs e)
        {
            if (lvPorts.SelectedItems.Count > 0)
            {
                var port = (PhysicalInterfacePortsPort)lvPorts.SelectedItems[0].Tag;
                if (DialogResult.Yes == MessageBox.Show(string.Format("Delete port \"{0}\"?", port.name),
                                                         Resources.V_E_R_I_F_Y,
                                                         MessageBoxButtons.YesNo,
                                                         MessageBoxIcon.Question))
                {
                    ListViewItem item = lvPorts.SelectedItems[0];
                    item.Remove();
                }
            }
        }
    }
}