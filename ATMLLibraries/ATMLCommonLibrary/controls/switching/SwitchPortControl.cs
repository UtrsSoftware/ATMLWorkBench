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
using ATMLCommonLibrary.controls;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.switching
{
    public partial class SwitchPortControl : RepeatedItemControl
    {

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SwitchPort SwitchPort
        {
            get { ControlsToData();  return (SwitchPort)RepeatedItem; }
            set { RepeatedItem = value; DataToControls(); }
        }

        public SwitchPortControl()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dataGridView.Rows.Add();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            SetEditMode(dataGridView);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteSelectedRows(dataGridView);
        }

        private void DataToControls()
        {
            SwitchPort switchPort = RepeatedItem as SwitchPort;
            if (switchPort != null)
            {
                if (switchPort.Pin != null)
                {
                    foreach (SwitchPortPin pin in switchPort.Pin)
                    {
                        //pin.line
                        int idx = dataGridView.Rows.Add();
                        DataGridViewRow row = dataGridView.Rows[idx];
                        row.Cells["line"].Value = "" + pin.line;
                        row.Cells["name"].Value = pin.name;
                    }
                }
            }
        }

        private void ControlsToData()
        {
            if (_item == null)
                _item = new SwitchPort();

            base.ControlsToData();

            SwitchPort switchPort = RepeatedItem as SwitchPort;

            if (dataGridView.Rows.Count == 0)
                switchPort.Pin = null;
            else
            {
                switchPort.Pin = new List<SwitchPortPin>();
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    int iLine = 0;
                    String line = row.Cells["line"].Value as String;
                    String name = row.Cells["name"].Value as String;
                    if (!String.IsNullOrEmpty(name) && line != null && int.TryParse( line, out iLine ) )
                    {
                        SwitchPortPin pin = new SwitchPortPin();
                        pin.line = iLine;
                        pin.name = name;
                        switchPort.Pin.Add(pin);
                    }
                }
            }
        }


        private void SetEditMode(DataGridView dataGridView)
        {
            if (dataGridView.SelectedCells.Count > 0)
            {
                DataGridViewCell cell = dataGridView.SelectedCells[0];
                dataGridView.CurrentCell = cell;
                dataGridView.BeginEdit(true);
            }
        }

        private void DeleteSelectedRows(DataGridView dataGridView)
        {
            foreach (DataGridViewCell cell in dataGridView.SelectedCells)
            {
                DataGridViewRow row = dataGridView.Rows[cell.RowIndex];
                if (!row.IsNewRow)
                    dataGridView.Rows.Remove(row);
            }
        }


    }
}
