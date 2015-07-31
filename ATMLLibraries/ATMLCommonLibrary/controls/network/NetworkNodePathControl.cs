/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.network
{
    public partial class NetworkNodePathControl : ATMLControl
    {
        private NetworkNodePath _networkNodePath;

        public NetworkNodePathControl()
        {
            InitializeComponent();
        }

        public NetworkNodePath NetworkNodePath
        {
            get
            {
                ControlsToData();
                return _networkNodePath;
            }
            set
            {
                _networkNodePath = value;
                DataToControls();
            }
        }

        private void DataToControls()
        {
            if (_networkNodePath != null)
            {
                edtPathDocumentId.Value = _networkNodePath.documentId;
                edtPathValue.Value = _networkNodePath.Value;
            }
        }

        private void ControlsToData()
        {
            if (_networkNodePath == null)
                _networkNodePath = new NetworkNodePath();
            _networkNodePath.documentId = edtPathDocumentId.GetValue<string>();
            _networkNodePath.Value = edtPathValue.GetValue<string>();
        }
    }
}