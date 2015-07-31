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
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.trigger
{
    public partial class TriggerPortControl : ATMLControl
    {
        private TriggerPort _port;
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TriggerPort Port
        {
            get { ControlsToData();  return _port; }
            set { _port = value; DataToControls(); }
        }

        public TriggerPortControl()
        {
            InitializeComponent();
            InitControls();
        }

        private void DataToControls()
        {
            if (_port != null)
            {
                edtName.Text = _port.name;
                cmbPortDirection.SelectedIndex = cmbPortDirection.FindStringExact(Enum.GetName(typeof(PortDirection), _port.direction));
                cmbPortType.SelectedIndex = cmbPortType.FindStringExact(Enum.GetName(typeof(TriggerPortType), _port.type));
                edtDescription.Text = _port.Description;
            }
        }

        private void ControlsToData()
        {
            if (_port == null)
                _port = new TriggerPort();
            _port.name = edtName.Text;
            _port.type = (TriggerPortType)Enum.Parse(typeof(TriggerPortType), (string)cmbPortType.SelectedItem);
            _port.direction = (PortDirection)Enum.Parse(typeof(PortDirection), (string)cmbPortDirection.SelectedItem);
            _port.Description = edtDescription.Text;
        }


    }
}
