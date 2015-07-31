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
using ATMLSignalModelLibrary.managers;
using ATMLSignalModelLibrary.signal;

namespace ATMLCommonLibrary.controls.signal
{
    public partial class SignalInterfaceListControl : UserControl
    {

        public SignalInterfaceListControl()
        {
            InitializeComponent();
            if (dgInterfaces.Columns.Count >= 2)
            {
                dgInterfaces.Columns[0].Width = (int) ( Width*.10 );
                dgInterfaces.Columns[1].Width = Width - dgInterfaces.Columns[0].Width;
            }
        }

        public void Load(SignalModel model)
        {
            if (model != null)
            {
                foreach (SignalAttribute signalAttribute in model.Attributes)
                {
                    DataGridViewRow row = (DataGridViewRow)dgInterfaces.RowTemplate.Clone();
                    row.CreateCells(dgInterfaces, signalAttribute.Name, "");
                    dgInterfaces.Rows.Add(row);
                }
            }
        }

        public void Load(string nameSpace, string signalName )
        {
            SignalModel model = SignalManager.GetSignalModel( nameSpace, signalName );
            Load(model);
        }
    }
}
