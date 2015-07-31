/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ATMLCommonLibrary.forms
{
    public partial class ATMLErrorListBox : ATMLForm
    {
        private static readonly ATMLErrorListBox form = new ATMLErrorListBox();

        private String message = "";

        public ATMLErrorListBox()
        {
            InitializeComponent();
            InitGrid();
        }

        public String Message
        {
            get { return message; }
            set { message = value; }
        }

        private void InitGrid()
        {
            dbGrid.Rows.Clear();
            dbGrid.Columns.Clear();
            var col1 = new DataGridViewTextBoxColumn();
            var col2 = new DataGridViewTextBoxColumn();
            col1.HeaderText = @"Id";
            col1.Name = @"id";
            col2.HeaderText = @"Error";
            col2.Name = @"error";
            dbGrid.Columns.AddRange(new DataGridViewColumn[] {col1, col2});
            dbGrid.Columns[1].Width = dbGrid.Width - dbGrid.Columns[0].Width;
            dbGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dbGrid.RowsDefaultCellStyle.Padding = new Padding(3);
        }


        public static void Show(ICollection<String> messages)
        {
            int i = 1;
            //-------------------------------------------//
            //--- First lets remove any existing rows ---//
            //-------------------------------------------//
            form.InitGrid();
            foreach (String error in messages)
            {
                int rowId = form.dbGrid.Rows.Add(new object[] {"" + i++, error});
            }
            form.ShowDialog();
        }

        private void dbGrid_Resize(object sender, EventArgs e)
        {
            if (dbGrid.Columns.Count >= 2 )
                dbGrid.Columns[1].Width = dbGrid.Width - dbGrid.Columns[0].Width;
        }

        protected override void btnOk_Click(object sender, EventArgs e)
        {
            Hide();
        }

        protected override void btnCancel_Click(object sender, EventArgs e)
        {
            Hide();
        }

    }
}