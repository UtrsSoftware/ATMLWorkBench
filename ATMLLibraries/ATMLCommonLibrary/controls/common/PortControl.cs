/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.ComponentModel;
using ATMLModelLibrary.model.common;

namespace ATMLCommonLibrary.controls.common
{
    public partial class PortControl : ATMLControl
    {
        private Port _port;

        public PortControl()
        {
            InitializeComponent();
            InitControls();
            cmbPortType.SelectedIndex = -1;
            cmbPortDirection.SelectedIndex = -1;
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Port Port
        {
            get
            {
                ControlsToData();
                return _port;
            }
            set
            {
                _port = value;
                DataToControls();
            }
        }

        private void DataToControls()
        {
            if (_port != null)
            {
                edtName.Text = _port.name;
                string direction = Enum.GetName(typeof (PortDirection), _port.direction);
                string type = Enum.GetName(typeof (PortType), _port.type);
                cmbPortDirection.SelectedItem = _port.directionSpecified ? direction : null;
                cmbPortType.SelectedItem = _port.typeSpecified ? type : null;
            }
        }

        private void ControlsToData()
        {
            if (_port == null)
                _port = new Port();
            _port.name = edtName.Text;

            if (cmbPortType.SelectedIndex > 0)
            {
                _port.type = (PortType) Enum.Parse( typeof (PortType), (string) cmbPortType.SelectedItem );
            }
            else
            {
                _port.typeSpecified = false;
            }

            if (cmbPortDirection.SelectedIndex > 0)
            {
                _port.direction = (PortDirection)Enum.Parse( typeof (PortDirection), (string) cmbPortDirection.SelectedItem );
            }
            else
            {
                _port.directionSpecified = false;
            }

            //TODO: Address when/if we handle extensions
            _port.Extension = null;
        }
    }
}