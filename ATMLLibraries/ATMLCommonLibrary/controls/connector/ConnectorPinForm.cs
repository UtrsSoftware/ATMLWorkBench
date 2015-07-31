/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ATMLCommonLibrary.forms;
using ATMLCommonLibrary.managers;
using ATMLModelLibrary.model.common;

namespace ATMLCommonLibrary.controls.connector
{
    public partial class ConnectorPinForm : ATMLForm
    {
        private ConnectorPin _connectorPin;

        public ConnectorPinForm()
        {
            InitializeComponent();
            SetControlStates();
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ConnectorPin ConnectorPin
        {
            get
            {
                ControlsToData();
                return _connectorPin;
            }
            set
            {
                _connectorPin = value;
                DataToControls();
            }
        }


        private void DataToControls()
        {
            if (_connectorPin != null)
            {
                chkIncludeDefinition.Checked = _connectorPin.Definition != null;
                itemDescriptionControl.ItemDescription = _connectorPin.Definition;
            }
            connectorPinControl.ConnectorPin = _connectorPin;
        }

        private void ControlsToData()
        {
            _connectorPin = connectorPinControl.ConnectorPin;
            _connectorPin.Definition = chkIncludeDefinition.Checked ? itemDescriptionControl.ItemDescription : null;
        }

        private void chkIncludeDefinition_CheckedChanged(object sender, EventArgs e)
        {
            SetControlStates();
        }

        private void SetControlStates()
        {
            if (chkIncludeDefinition.Checked)
            {
                Height = 600;
                panel1.Controls.Add(itemDescriptionControl);
                itemDescriptionControl.Location = new Point(11, 120);
                itemDescriptionControl.Size = new Size(621, 350);
                itemDescriptionControl.TabIndex = 2;
                itemDescriptionControl.Show();
            }
            else
            {
                Height = 205;
                panel1.Controls.Remove(itemDescriptionControl);
            }
        }


        public override bool ValidateChildren(ValidationConstraints validationConstraints)
        {
            bool v = base.ValidateChildren(validationConstraints);
            return v;
        }


        public override bool ValidateChildren()
        {
            bool v = base.ValidateChildren();
            return v;
        }
    }
}