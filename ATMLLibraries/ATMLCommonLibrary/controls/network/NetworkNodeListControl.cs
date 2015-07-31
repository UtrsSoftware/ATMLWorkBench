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
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.network
{
    public partial class NetworkNodeListControl : ATMLListControl
    {
        private HardwareItemDescription _hardwareItemDescription;
        private List<NetworkNode> _networkNodes;


        public NetworkNodeListControl()
        {
            InitializeComponent();
            InitListView();
            toolStrip.Items.Add( btnMapNetwork );
            InitializeForm += NetworkNodeListControl_InitializeForm;
            AllowRowResequencing = true;
        }

        [Browsable( false ), DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
        public List<NetworkNode> NetworkNodes
        {
            get
            {
                ControlsToData();
                return _networkNodes;
            }
            set
            {
                _networkNodes = value;
                DataToControls();
            }
        }

        public bool CapabilityMapMode { set; get; }

        public HardwareItemDescription HardwareItemDescription
        {
            get { return _hardwareItemDescription; }
            set { _hardwareItemDescription = value; }
        }

        private void NetworkNodeListControl_InitializeForm( Form form )
        {
            var nodeForm = form as NetworkNodeForm;
            if (nodeForm != null)
                nodeForm.HardwareItemDescription = _hardwareItemDescription;
        }

        private void btnMapNetwork_Click( object sender, EventArgs e )
        {
            var form = new NetworkPathSelectionForm( _hardwareItemDescription, CapabilityMapMode );
            var nodePaths = new List<string>();
            if (_networkNodes == null)
                _networkNodes = new List<NetworkNode>();
            foreach (NetworkNode networkNode in _networkNodes)
                nodePaths.Add( networkNode.Path.Value );
            form.CheckedNodePaths = nodePaths;
            if (DialogResult.OK == form.ShowDialog())
            {
                nodePaths = form.CheckedNodePaths;
                //--- Check for unchecked paths and remove them
                RemoveUnselectedNodes( nodePaths );

                //--- Check if there are any matched nodes - if so leave them alone so we don't delete the id and description if already set
                //--- Check for new paths - create a edit instance and open form modeless to allow user to add an id and description
                foreach (string nodePath in nodePaths)
                {
                    if (!ListContainsValue( _networkNodes, nodePath ))
                    {
                        var node = new NetworkNode();
                        node.Path = new NetworkNodePath();
                        node.Path.Value = nodePath;
                        _networkNodes.Add( node );
                    }
                }

                //--- Reload the list view ---//
                DataToControls();
            }
        }

        private void RemoveUnselectedNodes( List<string> nodePaths )
        {
            if (_networkNodes == null)
                _networkNodes = new List<NetworkNode>();
            var removeThese = new List<NetworkNode>();
            foreach (NetworkNode networkNode in _networkNodes)
            {
                if (!ListContainsValue( nodePaths, networkNode.Path.Value ))
                    removeThese.Add( networkNode );
            }
            foreach (NetworkNode node in removeThese)
                _networkNodes.Remove( node );
        }

        private bool ListContainsValue( List<string> nodePaths, string value )
        {
            bool found = false;
            foreach (string nodePath in nodePaths)
            {
                if (nodePath == value)
                {
                    found = true;
                    break;
                }
            }
            return found;
        }


        private bool ListContainsValue( List<NetworkNode> nodePaths, string value )
        {
            bool found = false;
            foreach (NetworkNode nodePath in nodePaths)
            {
                if (nodePath.Path.Value == value)
                {
                    found = true;
                    break;
                }
            }
            return found;
        }

        private void ControlsToData()
        {
            _networkNodes = null;
            if (lvList.Items.Count > 0)
            {
                _networkNodes = new List<NetworkNode>();
                foreach (ListViewItem lvi in lvList.Items)
                {
                    var node = (NetworkNode) lvi.Tag;
                    _networkNodes.Add( node );
                }
            }
        }

        private void DataToControls()
        {
            if (_networkNodes != null)
            {
                lvList.Items.Clear();
                foreach (NetworkNode node in _networkNodes)
                {
                    AddListViewObject( node );
                }
            }
        }

        private void InitListView()
        {
            DataObjectName = "NetworkNode";
            DataObjectFormType = typeof (NetworkNodeForm);
            AddColumnData( "Path", "ToString()", 1 );
            InitColumns();
        }
    }
}