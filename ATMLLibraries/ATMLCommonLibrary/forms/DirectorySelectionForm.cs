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
using ATMLCommonLibrary.managers;
using ATMLManagerLibrary.managers;

namespace ATMLCommonLibrary.forms
{
    public partial class DirectorySelectionForm : ATMLForm
    {
        public string SelectedFolder {get;set;}

        public DirectorySelectionForm( string startingLocation )
        {
            InitializeComponent();
            //cmbDirectories.DataSource = FileManager.GetFolderNames(startingLocation);
            lbDirectories.DataSource = FileManager.GetFolderNames(startingLocation);
        }

        protected override void btnOk_Click(object sender, EventArgs e)
        {
            if (lbDirectories.SelectedIndex != -1)
                SelectedFolder = lbDirectories.SelectedItem as String;
            base.btnOk_Click(sender, e);
        }

        private void cmbDirectories_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnOk.PerformClick();
        }

        private void lbDirectories_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnOk.PerformClick();
        }

        private void lbDirectories_DrawItem(object sender, DrawItemEventArgs e)
        {
            //e.BackColor = ( (e.Index & 2 == 2) ? Color.White : Color.PaleGoldenrod );
        }
    }
}
