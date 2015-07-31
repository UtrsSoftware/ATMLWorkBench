/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System.ComponentModel;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.network
{
    public partial class NetworkControl : ATMLControl
    {
        private HardwareItemDescription _hardwareItemDescription;
        private Network _network;

        public NetworkControl()
        {
            InitializeComponent();
        }

        [Browsable( false ), DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
        public Network Network
        {
            get
            {
                ControlsToData();
                return _network;
            }
            set
            {
                _network = value;
                DataToControls();
            }
        }

        public HardwareItemDescription HardwareItemDescription
        {
            get { return _hardwareItemDescription; }
            set
            {
                _hardwareItemDescription = value;
                networkNodeListControl.HardwareItemDescription = value;
            }
        }

        public bool CapabilityMapMode {
            set { networkNodeListControl.CapabilityMapMode = value; }
            get { return networkNodeListControl.CapabilityMapMode;  } }

        private void ControlsToData()
        {
            if (_network == null)
                _network = new Network();
            _network.Description = edtDescription.GetValue<string>();
            _network.baseIndex = edtBaseIndex.GetValue<int>();
            _network.baseIndexSpecified = edtBaseIndex.HasValue();
            _network.count = edtCount.GetValue<int>();
            _network.countSpecified = edtCount.HasValue();
            _network.incrementBy = edtIncrementBy.GetValue<int>();
            _network.incrementBySpecified = edtIncrementBy.HasValue();
            _network.replacementCharacter = edtReplacementChar.GetValue<string>();
            _network.Node = networkNodeListControl.NetworkNodes;
        }

        private void DataToControls()
        {
            edtDescription.Value = _network.Description;
            edtBaseIndex.Value = _network.baseIndex;
            edtCount.Value = _network.count;
            edtIncrementBy.Value = _network.incrementBy;
            edtReplacementChar.Value = _network.replacementCharacter;
            networkNodeListControl.NetworkNodes = _network.Node;
        }
    }
}