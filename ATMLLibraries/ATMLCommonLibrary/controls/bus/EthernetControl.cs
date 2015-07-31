/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
using System.ComponentModel;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.bus
{
    public partial class EthernetControl : BusControl
    {
        public EthernetControl()
        {
            InitializeComponent();
            InitControls();
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Ethernet Ethernet
        {
            set
            {
                Bus = value;
                DataToControls();
            }
            get
            {
                ControlsToData();
                return _bus as Ethernet;
            }
        }

        protected override void DataToControls()
        {
            if (_bus != null)
            {
                base.DataToControls();
                chkSupportsDHCP.Checked = ((Ethernet) _bus).supportsDHCP;
            }
        }

        protected override void ControlsToData()
        {
            if( _bus == null )
                _bus = new Ethernet();
            base.ControlsToData();
            ((Ethernet) _bus).supportsDHCP = chkSupportsDHCP.Checked;
        }
    }
}