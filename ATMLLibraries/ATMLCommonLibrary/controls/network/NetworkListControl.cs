/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using ATMLCommonLibrary.controls.lists;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.network
{
    public partial class NetworkListControl : ATMLListControl
    {
        private HardwareItemDescription _hardwareItemDescription;
        private Mapping _mapping;

        private List<Network> _network = new List<Network>();

        public NetworkListControl()
        {
            InitializeComponent();
            InitListView();
        }

        public bool CapabilityMapMode { set; get; }

        [Browsable( false ), DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
        public HardwareItemDescription HardwareItemDescription
        {
            get
            {
                ControlsToData();
                return _hardwareItemDescription;
            }
            set
            {
                _hardwareItemDescription = value;
                DataToControls();
            }
        }

        public Mapping Mapping
        {
            get
            {
                ControlsToData();
                return _mapping;
            }
            set
            {
                _mapping = value;
                DataToControls();
            }
        }


        [Browsable( false ), DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
        public List<Network> Network
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

        private void InitListView()
        {
            DataObjectName = "Network";
            DataObjectFormType = typeof (NetworkForm);
            AddColumnData( "Network", "ToString()", 1 );
            InitColumns();
            InitializeForm += NetworkListControl_InitializeForm;
        }

        private void NetworkListControl_InitializeForm( Form form )
        {
            var networkForm = form as NetworkForm;
            if (networkForm != null)
            {
                networkForm.CapabilityMapMode = CapabilityMapMode;
                networkForm.HardwareItemDescription = _hardwareItemDescription;
            }
        }


        private void DataToControls()
        {
            Items.Clear();
            if (CapabilityMapMode)
            {
                if (_mapping != null)
                {
                    foreach (Network network in _mapping.Map)
                        AddListViewObject( network );
                }
            }
            else if (_hardwareItemDescription != null && _hardwareItemDescription.NetworkList != null)
            {
                foreach (Network network in _hardwareItemDescription.NetworkList)
                    AddListViewObject( network );
            }
        }

        private void ControlsToData()
        {
            if (CapabilityMapMode)
            {
                if (lvList.Items.Count == 0)
                {
                    if( _mapping != null )
                        _mapping.Map = null;
                }
                else
                {
                    if (_mapping == null)
                        _mapping = new Mapping();
                    if (_mapping.Map == null)
                        _mapping.Map = new List<Network>();
                    _mapping.Map.Clear();
                    foreach (ListViewItem lvi in lvList.Items)
                        _mapping.Map.Add(lvi.Tag as Network);
                }
            }
            else if (_hardwareItemDescription != null)
            {
                if (lvList.Items.Count == 0)
                {
                    _hardwareItemDescription.NetworkList = null;
                }
                else
                {
                    if (_hardwareItemDescription.NetworkList == null)
                        _hardwareItemDescription.NetworkList = new List<Network>();
                    _hardwareItemDescription.NetworkList.Clear();
                    foreach (ListViewItem lvi in lvList.Items)
                        _hardwareItemDescription.NetworkList.Add( lvi.Tag as Network );
                }
            }
        }
    }
}