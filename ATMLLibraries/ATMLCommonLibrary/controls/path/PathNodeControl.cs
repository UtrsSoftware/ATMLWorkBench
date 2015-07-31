/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System.ComponentModel;
using ATMLCommonLibrary.controls.network;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.path
{
    public partial class PathNodeControl : NetworkNodeControl
    {
        public PathNodeControl()
        {
            InitializeComponent();
        }

        [Browsable( false ), DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
        public PathNode PathNode
        {
            get
            {
                ControlsToData();
                return _networkNode as PathNode;
            }
            set
            {
                _networkNode = value;
                DataToControls();
            }
        }

        private new void ControlsToData()
        {
            if (_networkNode == null)
                _networkNode = new PathNode();
            base.ControlsToData();
            PathNode pnode = _networkNode as PathNode ?? new PathNode
                                                         {
                                                             Description = _networkNode.Description,
                                                             Extension = _networkNode.Extension,
                                                             Path = _networkNode.Path
                                                         };
            pnode.name = edtPathName.GetValue<string>();
            _networkNode = pnode;
        }

        private new void DataToControls()
        {
            if (_networkNode != null)
            {
                base.DataToControls();
                var pnode = _networkNode as PathNode;
                if (pnode != null)
                {
                    edtPathName.Value = pnode.name;
                }
            }
        }
    }
}