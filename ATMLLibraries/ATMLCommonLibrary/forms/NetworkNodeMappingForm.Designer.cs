/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using ATMLCommonLibrary.controls.lists;

namespace ATMLCommonLibrary.forms
{
    partial class NetworkNodeMappingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.networkListControl1 = new ATMLCommonLibrary.controls.network.NetworkListControl();
            this.treeView2 = new ATMLCommonLibrary.controls.lists.InterfaceMappingTreeView();
            this.treeView1 = new ATMLCommonLibrary.controls.lists.InterfaceMappingTreeView();
            this.SuspendLayout();
            // 
            // networkListControl1
            // 
            this.networkListControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.networkListControl1.FormTitle = null;
            this.networkListControl1.ListName = null;
            this.networkListControl1.Location = new System.Drawing.Point(426, 12);
            this.networkListControl1.Margin = new System.Windows.Forms.Padding(0);
            this.networkListControl1.Name = "networkListControl1";
            this.networkListControl1.SchemaTypeName = null;
            this.networkListControl1.ShowFind = false;
            this.networkListControl1.Size = new System.Drawing.Size(321, 313);
            this.networkListControl1.TabIndex = 2;
            this.networkListControl1.TargetNamespace = null;
            this.networkListControl1.TooltipTextAddButton = "Press to add a new Network";
            this.networkListControl1.TooltipTextDeleteButton = "Press to delete the selected Network";
            this.networkListControl1.TooltipTextEditButton = "Press to edit the selected Network";
            // 
            // treeView2
            // 
            this.treeView2.AllowDrop = true;
            this.treeView2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView2.HotTracking = true;
            this.treeView2.Item = null;
            this.treeView2.Location = new System.Drawing.Point(219, 12);
            this.treeView2.Name = "treeView2";
            this.treeView2.Size = new System.Drawing.Size(201, 313);
            this.treeView2.TabIndex = 1;
            this.treeView2.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeView2_DragDrop);
            this.treeView2.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeView2_DragEnter);
            this.treeView2.DragOver += new System.Windows.Forms.DragEventHandler(this.treeView2_DragOver);
            // 
            // treeView1
            // 
            this.treeView1.AllowDrop = true;
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView1.HotTracking = true;
            this.treeView1.Item = null;
            this.treeView1.Location = new System.Drawing.Point(12, 12);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(201, 313);
            this.treeView1.TabIndex = 0;
            this.treeView1.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeView1_ItemDrag);
            this.treeView1.DragOver += new System.Windows.Forms.DragEventHandler(this.treeView1_DragOver);
            // 
            // NetworkNodeMappingForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 337);
            this.Controls.Add(this.networkListControl1);
            this.Controls.Add(this.treeView2);
            this.Controls.Add(this.treeView1);
            this.Name = "NetworkNodeMappingForm";
            this.Text = "Network Node Mapping";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.NetworkNodeMappingForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.NetworkNodeMappingForm_DragEnter);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.NetworkNodeMappingForm_DragOver);
            this.ResumeLayout(false);

        }

        #endregion

        private InterfaceMappingTreeView treeView1;
        private InterfaceMappingTreeView treeView2;
        private controls.network.NetworkListControl networkListControl1;
    }
}