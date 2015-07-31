/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.ComponentModel;
using System.Windows.Forms;
using ATMLModelLibrary.model.common;
using ATMLUtilitiesLibrary;

namespace ATMLCommonLibrary.forms
{
    public partial class PortForm : ATMLForm
    {
        private Port _port;

        public PortForm()
        {
            InitializeComponent();
            BackColor = ATMLContext.COLOR_FORM;
            ValidateSchema += PortForm_ValidateSchema;
            UndoChanges += PortForm_UndoChanges;
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
                if( value != null )
                    originalSerializedATMLObject = value.Serialize();
                _port = value;
                DataToControls();
            }
        }

        private void PortForm_UndoChanges(object sender, EventArgs e)
        {
            _port = Port.Deserialize(originalSerializedATMLObject);
            DataToControls();
        }

        private void PortForm_ValidateSchema(object sender, EventArgs e)
        {
            string save = _port.Serialize();
            ControlsToData();
            ValidateToSchema(_port);
            _port = Port.Deserialize(save);
        }

        private void DataToControls()
        {
            portControl.Port = _port;
        }

        private void ControlsToData()
        {
            _port = portControl.Port;
        }

        private void PortForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult.OK == DialogResult)
            {
                if (ValidateChildren())
                    ControlsToData();
            }
        }

        private void portControl_Load(object sender, EventArgs e)
        {
        }
    }
}