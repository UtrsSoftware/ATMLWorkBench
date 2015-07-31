/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ATMLModelLibrary.model.common;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.common
{

    public partial class ConnectorPinControl : UserControl
    {
        private ConnectorPin connectorPin = null;
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ConnectorPin ConnectorPin
        {
            get { ControlsToData();  return connectorPin; }
            set { connectorPin = value; DataToControls();  }
        }

        public ConnectorPinControl()
        {
            InitializeComponent();
        }

        private void DataToControls()
        {
            if (connectorPin != null)
            {
                edtBaseIndex.Text = ""+connectorPin.baseIndex;
                edtCount.Text = ""+connectorPin.count;
                edtId.Text = connectorPin.ID;
                edtIncrementBy.Text = ""+connectorPin.incrementBy;
                edtName.Text = connectorPin.name;
                edtReplacementCharacter.Text = connectorPin.replacementCharacter;
                edtName.Focus();
                edtName.SelectAll();
            }
        }

        private void ControlsToData()
        {
            if (connectorPin == null )
                connectorPin = new ConnectorPin();

            connectorPin.baseIndexSpecified = !String.IsNullOrEmpty(edtReplacementCharacter.Text);
            connectorPin.countSpecified = !String.IsNullOrEmpty(edtCount.Text) && int.Parse(edtCount.Text) > 0;
            connectorPin.incrementBySpecified = !String.IsNullOrEmpty(edtIncrementBy.Text) && int.Parse(edtIncrementBy.Text) > 0;
            if (connectorPin.baseIndexSpecified )
                connectorPin.baseIndex = connectorPin.baseIndexSpecified ? int.Parse(edtBaseIndex.Text) : 0;
            if (connectorPin.countSpecified )
                connectorPin.count = connectorPin.countSpecified ? int.Parse(edtCount.Text) : 0;
            if (connectorPin.incrementBySpecified)
                connectorPin.incrementBy = connectorPin.incrementBySpecified ? int.Parse(edtIncrementBy.Text) : 0;
            connectorPin.ID = edtId.Text;
            connectorPin.name = edtName.Text;
            connectorPin.replacementCharacter = !String.IsNullOrEmpty(edtReplacementCharacter.Text) ? edtReplacementCharacter.Text : null;
        }
    }
}
