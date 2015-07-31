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

namespace ATMLCommonLibrary.forms
{
    public partial class EditorForm : Form
    {
        public EditorForm()
        {
            InitializeComponent();

            ContextMenu mnu = new ContextMenu();
            MenuItem mnui = new MenuItem("UTRS Copy");
            mnui.Click += new EventHandler(mnu_Click);
            mnu.MenuItems.Add( mnui );
            webBrowser1.ContextMenu = mnu;

        }

        private void btnGoto_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(edtUrl.Text);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (DialogResult.OK == dlg.ShowDialog())
            {
                edtUrl.Text = dlg.FileName;
                webBrowser1.Navigate(edtUrl.Text);
            }

        }

        void mnu_Click(object sender, EventArgs e)
        {
            
        }
    }
}
