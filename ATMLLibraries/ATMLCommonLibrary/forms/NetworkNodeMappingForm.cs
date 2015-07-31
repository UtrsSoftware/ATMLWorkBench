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
using ATMLModelLibrary.model.common;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.forms
{
    public partial class NetworkNodeMappingForm : Form
    {
        public NetworkNodeMappingForm( HardwareItemDescription hardwareItemDescription )
        {
            InitializeComponent();
            treeView1.Item = hardwareItemDescription;
            treeView2.Item = hardwareItemDescription;
            treeView1.ExpandAll();
            treeView2.ExpandAll();
        }

        private void treeView1_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.None;
            
        }

        private void treeView2_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void treeView2_DragDrop(object sender, DragEventArgs e)
        {
            Point pt = ((TreeView)sender).PointToClient(new Point(e.X, e.Y));
            TreeNode node = treeView2.GetNodeAt(pt);
            if (node != null)
            {
                treeView2.SelectedNode = node;
                PhysicalInterfacePortsPort pipp1 = treeView1.SelectedNode.Tag as PhysicalInterfacePortsPort;
                PhysicalInterfacePortsPort pipp2 = treeView2.SelectedNode.Tag as PhysicalInterfacePortsPort;
                if( pipp1 != null && pipp2 != null )
                    MessageBox.Show("Mapping " + pipp1.name + " TO " + pipp2.name);
            }
        }

        private void treeView2_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void NetworkNodeMappingForm_DragDrop(object sender, DragEventArgs e)
        {

        }

        private void NetworkNodeMappingForm_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void treeView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void NetworkNodeMappingForm_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }
    }
}
