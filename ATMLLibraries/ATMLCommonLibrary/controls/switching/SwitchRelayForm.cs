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
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ATMLCommonLibrary.forms;
using ATMLModelLibrary.model.equipment;
using ATMLModelLibrary.model.common;

namespace ATMLCommonLibrary.controls.switching
{
    public partial class SwitchRelayForm : ATMLForm
    {
        private List<Port> ports;

        private SwitchRelaySetting switchRelaySetting;
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SwitchRelaySetting SwitchRelaySetting
        {
            get { ControlsToData();  return switchRelaySetting; }
            set { switchRelaySetting = value; DataToControls();  }
        }

        public SwitchRelayForm(List<Port> ports)
        {
            const string NAME = "name";
            InitializeComponent();
            SetGridColumnWidths();
            Resize += new EventHandler(SwitchRelayForm_Resize);
            this.ports = ports;

            DataGridViewComboBoxColumn comboColumn1 = (DataGridViewComboBoxColumn)dgRelayConnections.Columns[0];
            DataGridViewComboBoxColumn comboColumn2 = (DataGridViewComboBoxColumn)dgRelayConnections.Columns[1];
            comboColumn1.DataSource = ports;
            comboColumn1.DisplayMember = NAME;
            comboColumn1.ValueMember = NAME;
            comboColumn2.DataSource = ports;
            comboColumn2.DisplayMember = NAME;
            comboColumn2.ValueMember = NAME;
        }

        protected void ControlsToData()
        {
            List<SwitchRelaySettingRelayConnection> list = new List<SwitchRelaySettingRelayConnection>();
            if (switchRelaySetting == null)
                switchRelaySetting = new SwitchRelaySetting();
            switchRelaySetting.name = edtName.GetValue<string>();
            foreach (DataGridViewRow row in dgRelayConnections.Rows)
            {
                SwitchRelaySettingRelayConnection connection = row.Tag as SwitchRelaySettingRelayConnection;
                if (connection == null)
                    connection = new SwitchRelaySettingRelayConnection();
                connection.from = row.Cells[0].Value as String;
                connection.to = row.Cells[1].Value as String;
                //----------------------------------------------------------------------//
                //--- Add the from and to ports as long as there are values for each ---//
                //----------------------------------------------------------------------//
                if (!String.IsNullOrEmpty(connection.from) && !String.IsNullOrEmpty(connection.to))
                    list.Add(connection);
            }
            switchRelaySetting.RelayConnection = list;
        }

        protected void DataToControls()
        {
            edtName.Value = switchRelaySetting.name;
            if (switchRelaySetting.RelayConnection != null)
            {
                foreach (SwitchRelaySettingRelayConnection connection in switchRelaySetting.RelayConnection)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(dgRelayConnections, connection.from, connection.to);
                    row.Tag = connection;
                    dgRelayConnections.Rows.Add(row);
                }
            }
            
        }

        void SwitchRelayForm_Resize(object sender, EventArgs e)
        {
            SetGridColumnWidths();
        }

        private void SetGridColumnWidths()
        {
            if (dgRelayConnections.Columns.Count >= 2)
            {
                dgRelayConnections.Columns[0].Width = dgRelayConnections.Width/2;
                dgRelayConnections.Columns[1].Width = dgRelayConnections.Width - dgRelayConnections.Columns[0].Width;
            }
        }

        private void dgRelayConnections_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
        }


    }
}
