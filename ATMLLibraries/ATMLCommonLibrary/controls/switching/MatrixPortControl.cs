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

namespace ATMLCommonLibrary.controls.switching
{
    public partial class MatrixPortControl : RepeatedItemControl
    {
        private MatrixPort port;
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MatrixPort Port
        {
            get { ControlsToData();  return port; }
            set { port = value; DataToControls(); }
        }

        public MatrixPortControl()
        {
            InitializeComponent();
            InitControls();
        }

        private void DataToControls()
        {
            base.RepeatedItem = port;
        }

        private void ControlsToData()
        {
            port = base.RepeatedItem as MatrixPort;
        }
    }
}
