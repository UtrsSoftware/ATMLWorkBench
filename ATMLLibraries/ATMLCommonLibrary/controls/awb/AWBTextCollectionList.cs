/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ATMLCommonLibrary.controls.awb
{
    public partial class AWBTextCollectionList : ATMLControl
    {
        private readonly List<string> _columnNames = new List<string>();

        public AWBTextCollectionList()
        {
            InitializeComponent();
            dgTextData.SelectionChanged += new EventHandler(dgTextData_SelectionChanged);
        }

        void dgTextData_SelectionChanged(object sender, EventArgs e)
        {
            SetButtonStates();
        }

        public int RowCount
        {
            get { return dgTextData.Rows.Count; }
        }

        public void AddColumn(string columnTitle, string columnName)
        {
            DataGridViewColumn gc = new DataGridViewTextBoxColumn();
            gc.HeaderText = columnTitle;
            gc.Name = columnName;
            gc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            gc.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            gc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
            gc.Width = Width/(_columnNames.Count + 1);
            dgTextData.Columns.Add(gc);
            _columnNames.Add(columnName);
        }

        public void ClearData()
        {
            dgTextData.Rows.Clear();
        }

        public DataGridViewRow AddRow()
        {
            int idx = dgTextData.Rows.Add();
            DataGridViewRow row = dgTextData.Rows[idx];
            return row;
        }

        public void AddColumnData(DataGridViewRow row, string columnName, string value)
        {
            row.Cells[columnName].Value = value;
        }

        public List<string> GetRowValues(DataGridViewRow row)
        {
            var values = new List<string>();
            IEnumerator ie = row.Cells.GetEnumerator();
            while (ie.MoveNext())
            {
                var cell = ie.Current as DataGridViewTextBoxCell;
                string value = Convert.ToString(cell.Value);
                if (!String.IsNullOrWhiteSpace(value))
                    values.Add(value);
            }
            return values;
        }

        public List<List<string>> GetTable()
        {
            return (from DataGridViewRow row in dgTextData.Rows select GetRowValues(row)).ToList();
        }

        public List<object> GetColumnValues(int columnId)
        {
            List<object> colValues = new List<object>();
            foreach (DataGridViewRow row in dgTextData.Rows)
            {
                if( !row.IsNewRow )
                    colValues.Add(row.Cells[columnId].Value);
            }
            return colValues;
        }

        private void SetButtonStates()
        {
            btnEdit.Visible = btnDelete.Visible = dgTextData.SelectedCells.Count > 0 && !dgTextData.SelectedCells[0].OwningRow.IsNewRow;
        }

        private void usage()
        {
            var textCollectionList = new AWBTextCollectionList();

            //--- Goes In Contructor ---//
            textCollectionList.AddColumn("Title 1", "col1");
            textCollectionList.AddColumn("Title 2", "col2");

            //--- Goes in DataToControls ---//
            DataGridViewRow row = textCollectionList.AddRow();
            textCollectionList.AddColumnData(row, "col1", "cell 1 data");
            textCollectionList.AddColumnData(row, "col2", "cell 2 data");
            row = textCollectionList.AddRow();
            textCollectionList.AddColumnData(row, "col1", "more cell 1 data");
            textCollectionList.AddColumnData(row, "col2", "more cell 2 data");

            //--- Goes in ControlsToData ---//
            List<List<string>> table = textCollectionList.GetTable();
            foreach (var tableRow in table)
            {
                foreach (string rowColumn in tableRow)
                {
                }
            }
        }

        private void btnRowAdd_Click(object sender, EventArgs e)
        {
            AddRow();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            SetEditMode(dgTextData);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteSelectedRows(dgTextData);
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