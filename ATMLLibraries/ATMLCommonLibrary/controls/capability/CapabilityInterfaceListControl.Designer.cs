/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls.capability
{
    partial class CapabilityInterfaceListControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CapabilityInterfaceListControl));
            this.tabControl4 = new System.Windows.Forms.TabControl();
            this.tabPorts = new System.Windows.Forms.TabPage();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btnAddPort = new System.Windows.Forms.ToolStripButton();
            this.btnEditPort = new System.Windows.Forms.ToolStripButton();
            this.btnDeletePort = new System.Windows.Forms.ToolStripButton();
            this.btnMapping = new System.Windows.Forms.ToolStripButton();
            this.lvPorts = new ATMLCommonLibrary.controls.awb.AWBListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDirection = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabControl4.SuspendLayout();
            this.tabPorts.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl4
            // 
            this.tabControl4.Controls.Add(this.tabPorts);
            this.tabControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl4.Location = new System.Drawing.Point(0, 0);
            this.tabControl4.Name = "tabControl4";
            this.tabControl4.SelectedIndex = 0;
            this.tabControl4.Size = new System.Drawing.Size(530, 230);
            this.tabControl4.TabIndex = 2;
            // 
            // tabPorts
            // 
            this.tabPorts.Controls.Add(this.toolStrip2);
            this.tabPorts.Controls.Add(this.lvPorts);
            this.tabPorts.Location = new System.Drawing.Point(4, 22);
            this.tabPorts.Name = "tabPorts";
            this.tabPorts.Padding = new System.Windows.Forms.Padding(3);
            this.tabPorts.Size = new System.Drawing.Size(522, 204);
            this.tabPorts.TabIndex = 0;
            this.tabPorts.Text = "Ports";
            this.tabPorts.UseVisualStyleBackColor = true;
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Right;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddPort,
            this.btnEditPort,
            this.btnDeletePort,
            this.btnMapping});
            this.toolStrip2.Location = new System.Drawing.Point(488, 3);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip2.Size = new System.Drawing.Size(31, 198);
            this.toolStrip2.TabIndex = 30;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // btnAddPort
            // 
            this.btnAddPort.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddPort.Image = global::ATMLCommonLibrary.Properties.Resources.application_form_add24;
            this.btnAddPort.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAddPort.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddPort.Name = "btnAddPort";
            this.btnAddPort.Size = new System.Drawing.Size(30, 28);
            this.btnAddPort.Text = "Add";
            this.btnAddPort.ToolTipText = "Press to add a new Capability Port";
            this.btnAddPort.Click += new System.EventHandler(this.btnAddPort_Click);
            // 
            // btnEditPort
            // 
            this.btnEditPort.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEditPort.Image = global::ATMLCommonLibrary.Properties.Resources.application_form_edit24;
            this.btnEditPort.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnEditPort.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditPort.Name = "btnEditPort";
            this.btnEditPort.Size = new System.Drawing.Size(30, 28);
            this.btnEditPort.Text = "Edit";
            this.btnEditPort.ToolTipText = "Press to edit the selected  Capability Port";
            this.btnEditPort.Click += new System.EventHandler(this.btnEditPort_Click);
            // 
            // btnDeletePort
            // 
            this.btnDeletePort.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDeletePort.Image = global::ATMLCommonLibrary.Properties.Resources.application_form_delete24;
            this.btnDeletePort.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnDeletePort.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeletePort.Name = "btnDeletePort";
            this.btnDeletePort.Size = new System.Drawing.Size(30, 28);
            this.btnDeletePort.Text = "Delete";
            this.btnDeletePort.ToolTipText = "Press to delete the selected Capability Port";
            this.btnDeletePort.Click += new System.EventHandler(this.btnDeletePort_Click);
            // 
            // btnMapping
            // 
            this.btnMapping.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnMapping.Image = ((System.Drawing.Image)(resources.GetObject("btnMapping.Image")));
            this.btnMapping.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnMapping.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMapping.Name = "btnMapping";
            this.btnMapping.Size = new System.Drawing.Size(30, 28);
            this.btnMapping.ToolTipText = "Press to map Resource Ports to the selected Capability Port";
            this.btnMapping.Click += new System.EventHandler(this.btnMapping_Click);
            // 
            // lvPorts
            // 
            this.lvPorts.AltColor1 = System.Drawing.Color.White;
            this.lvPorts.AltColor2 = System.Drawing.Color.Honeydew;
            this.lvPorts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvPorts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colDirection,
            this.colType});
            this.lvPorts.FullRowSelect = true;
            this.lvPorts.HideSelection = false;
            this.lvPorts.Location = new System.Drawing.Point(3, 3);
            this.lvPorts.Name = "lvPorts";
            this.lvPorts.Size = new System.Drawing.Size(489, 195);
            this.lvPorts.TabIndex = 19;
            this.lvPorts.UseCompatibleStateImageBehavior = false;
            this.lvPorts.View = System.Windows.Forms.View.Details;
            this.lvPorts.SelectedIndexChanged += new System.EventHandler(this.lvPorts_SelectedIndexChanged);
            this.lvPorts.Resize += new System.EventHandler(this.lvPorts_Resize);
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 100;
            // 
            // colDirection
            // 
            this.colDirection.Text = "Direction";
            this.colDirection.Width = 100;
            // 
            // colType
            // 
            this.colType.Text = "Type";
            this.colType.Width = 100;
            // 
            // CapabilityInterfaceListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl4);
            this.Name = "CapabilityInterfaceListControl";
            this.Size = new System.Drawing.Size(530, 230);
            this.tabControl4.ResumeLayout(false);
            this.tabPorts.ResumeLayout(false);
            this.tabPorts.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl4;
        private System.Windows.Forms.TabPage tabPorts;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btnAddPort;
        private System.Windows.Forms.ToolStripButton btnEditPort;
        private System.Windows.Forms.ToolStripButton btnDeletePort;
        private ATMLCommonLibrary.controls.awb.AWBListView lvPorts;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colDirection;
        private System.Windows.Forms.ColumnHeader colType;
        private System.Windows.Forms.ToolStripButton btnMapping;
    }
}
