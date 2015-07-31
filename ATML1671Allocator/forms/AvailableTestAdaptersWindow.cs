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
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ATML1671Allocator.allocator;
using ATMLCommonLibrary.model;
using ATMLManagerLibrary.managers;
using ATMLModelLibrary.model.common;
using ATMLModelLibrary.model.equipment;
using WeifenLuo.WinFormsUI.Docking;

namespace ATML1671Allocator.forms
{
    public partial class AvailableTestAdaptersWindow : DockContent, IATMLDockableWindow
    {
        public AvailableTestAdaptersWindow()
        {
            InitializeComponent();
            lvTestAdapters.Columns.Clear();
            lvTestAdapters.Columns.Add("Name");
            lvTestAdapters.Columns.Add("P/N");
            lvTestAdapters.Columns.Add("Description");

        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.F4))
            {
                Console.Beep();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }


        private void AddTestAdapter(String name, String partNumber, String description)
        {
            ListViewItem itm = new ListViewItem(name);
            itm.SubItems.Add(partNumber);
            itm.SubItems.Add(description);
            lvTestAdapters.Items.Add(itm);
        }

        public void CloseProject()
        {
            
        }
    }
}
