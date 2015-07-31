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
using ATMLCommonLibrary.forms;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.network
{
    public partial class NetworkNodeControl : ATMLControl
    {
        protected NetworkNode _networkNode;

        public NetworkNodeControl()
        {
            InitializeComponent();
        }

        public bool CapabilityMapMode { set; get; }

        public NetworkNode NetworkNode
        {
            get
            {
                ControlsToData();
                return _networkNode;
            }
            set
            {
                _networkNode = value;
                DataToControls();
            }
        }

        public HardwareItemDescription HardwareItemDescription { get; set; }

        protected void ControlsToData()
        {
            if (_networkNode == null)
                _networkNode = new NetworkNode();
            _networkNode.Description = edtDescription.GetValue<string>();
            if (_networkNode.Path == null)
                _networkNode.Path = new NetworkNodePath();
            _networkNode.Path.Value = edtPathValue.GetValue<string>();
            _networkNode.Path.documentId = edtPathDocumentId.GetValue<string>();
        }

        protected void DataToControls()
        {
            if (_networkNode != null)
            {
                edtDescription.Value = _networkNode.Description;
                if (_networkNode.Path != null)
                {
                    edtPathValue.Value = _networkNode.Path.Value;
                    edtPathDocumentId.Value = _networkNode.Path.documentId;
                }
            }
        }

        private void btnSelectNetworkNode_Click(object sender, EventArgs e)
        {
            var form = new NetworkPathSelectionForm(HardwareItemDescription, CapabilityMapMode );
            var nodePaths = new List<string>();
            if (_networkNode != null && _networkNode.Path != null)
                nodePaths.Add(_networkNode.Path.Value);
            form.CheckedNodePaths = nodePaths;
            if (DialogResult.OK == form.ShowDialog())
            {
                nodePaths = form.CheckedNodePaths;
                if( nodePaths.Count > 0 )
                {
                    _networkNode = new NetworkNode();
                    _networkNode.Path = new NetworkNodePath();
                    _networkNode.Path.Value = nodePaths[0]; //Grab first node selected
                    edtPathValue.Value = _networkNode.Path.Value;
                    edtPathDocumentId.Value = _networkNode.Path.documentId;
                }
            }
        }
    }
}