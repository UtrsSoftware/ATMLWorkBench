/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using ATMLCommonLibrary.controls.connector;

namespace ATMLCommonLibrary.controls.lists
{
    partial class PhysicalInterfaceListControl
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
            if( disposing && ( components != null ) )
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PhysicalInterfaceListControl));
            this.tabControl4 = new ATMLCommonLibrary.controls.awb.AWBTabControl();
            this.tabConnectors = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lvConnectors = new ATMLCommonLibrary.controls.connector.ConnectorListView(this.components);
            this.lvPins = new ATMLCommonLibrary.controls.connector.ConnectorPinListView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAddConnector = new System.Windows.Forms.ToolStripButton();
            this.btnEditConnector = new System.Windows.Forms.ToolStripButton();
            this.btnDeleteConnector = new System.Windows.Forms.ToolStripButton();
            this.tabPorts = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.lvPorts = new ATMLCommonLibrary.controls.lists.PortListView();
            this.lvPortConnectors = new ATMLCommonLibrary.controls.lists.PortConnectorListView();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btnAddPort = new System.Windows.Forms.ToolStripButton();
            this.btnEditPort = new System.Windows.Forms.ToolStripButton();
            this.btnDeletePort = new System.Windows.Forms.ToolStripButton();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabControl4.SuspendLayout();
            this.tabConnectors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tabPorts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl4
            // 
            this.tabControl4.Controls.Add(this.tabConnectors);
            this.tabControl4.Controls.Add(this.tabPorts);
            this.tabControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl4.Location = new System.Drawing.Point(0, 0);
            this.tabControl4.MainBackColor = System.Drawing.Color.AliceBlue;
            this.tabControl4.Name = "tabControl4";
            this.tabControl4.SelectedIndex = 0;
            this.tabControl4.Size = new System.Drawing.Size(718, 280);
            this.tabControl4.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl4.TabIndex = 1;
            // 
            // tabConnectors
            // 
            this.tabConnectors.BackColor = System.Drawing.SystemColors.Control;
            this.tabConnectors.Controls.Add(this.splitContainer1);
            this.tabConnectors.Controls.Add(this.toolStrip1);
            this.errorProvider.SetIconAlignment(this.tabConnectors, System.Windows.Forms.ErrorIconAlignment.TopLeft);
            this.tabConnectors.Location = new System.Drawing.Point(4, 25);
            this.tabConnectors.Name = "tabConnectors";
            this.tabConnectors.Padding = new System.Windows.Forms.Padding(3);
            this.tabConnectors.Size = new System.Drawing.Size(710, 251);
            this.tabConnectors.TabIndex = 1;
            this.tabConnectors.Text = "Connectors";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lvConnectors);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lvPins);
            this.splitContainer1.Size = new System.Drawing.Size(676, 245);
            this.splitContainer1.SplitterDistance = 397;
            this.splitContainer1.TabIndex = 32;
            // 
            // lvConnectors
            // 
            this.lvConnectors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvConnectors.FullRowSelect = true;
            this.lvConnectors.HasErrors = false;
            this.lvConnectors.HideSelection = false;
            this.lvConnectors.Location = new System.Drawing.Point(0, 0);
            this.lvConnectors.Name = "lvConnectors";
            this.lvConnectors.Size = new System.Drawing.Size(397, 245);
            this.lvConnectors.TabIndex = 23;
            this.lvConnectors.UseCompatibleStateImageBehavior = false;
            this.lvConnectors.View = System.Windows.Forms.View.Details;
            this.lvConnectors.SelectedIndexChanged += new System.EventHandler(this.lvConnectors_SelectedIndexChanged);
            // 
            // lvPins
            // 
            this.lvPins.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvPins.FullRowSelect = true;
            this.lvPins.HasErrors = false;
            this.lvPins.HideSelection = false;
            this.lvPins.Location = new System.Drawing.Point(0, 0);
            this.lvPins.MultiSelect = false;
            this.lvPins.Name = "lvPins";
            this.lvPins.Size = new System.Drawing.Size(275, 245);
            this.lvPins.TabIndex = 31;
            this.lvPins.UseCompatibleStateImageBehavior = false;
            this.lvPins.View = System.Windows.Forms.View.Details;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Right;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddConnector,
            this.btnEditConnector,
            this.btnDeleteConnector});
            this.toolStrip1.Location = new System.Drawing.Point(679, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(28, 245);
            this.toolStrip1.TabIndex = 30;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnAddConnector
            // 
            this.btnAddConnector.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddConnector.Image = ((System.Drawing.Image)(resources.GetObject("btnAddConnector.Image")));
            this.btnAddConnector.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAddConnector.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddConnector.Name = "btnAddConnector";
            this.btnAddConnector.Size = new System.Drawing.Size(27, 28);
            this.btnAddConnector.Text = "Add";
            this.btnAddConnector.ToolTipText = "Press to add a new Connector";
            this.btnAddConnector.Click += new System.EventHandler(this.btnAddConnector_Click);
            // 
            // btnEditConnector
            // 
            this.btnEditConnector.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEditConnector.Image = ((System.Drawing.Image)(resources.GetObject("btnEditConnector.Image")));
            this.btnEditConnector.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnEditConnector.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditConnector.Name = "btnEditConnector";
            this.btnEditConnector.Size = new System.Drawing.Size(27, 28);
            this.btnEditConnector.Text = "Edit";
            this.btnEditConnector.ToolTipText = "Press to edit the selected Connector";
            this.btnEditConnector.Visible = false;
            this.btnEditConnector.Click += new System.EventHandler(this.btnEditConnector_Click);
            // 
            // btnDeleteConnector
            // 
            this.btnDeleteConnector.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDeleteConnector.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteConnector.Image")));
            this.btnDeleteConnector.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnDeleteConnector.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteConnector.Name = "btnDeleteConnector";
            this.btnDeleteConnector.Size = new System.Drawing.Size(27, 28);
            this.btnDeleteConnector.Text = "Delete";
            this.btnDeleteConnector.ToolTipText = "Press to delete the selected Connector";
            this.btnDeleteConnector.Visible = false;
            this.btnDeleteConnector.Click += new System.EventHandler(this.btnDeleteConnector_Click);
            // 
            // tabPorts
            // 
            this.tabPorts.BackColor = System.Drawing.SystemColors.Control;
            this.tabPorts.Controls.Add(this.splitContainer2);
            this.tabPorts.Controls.Add(this.toolStrip2);
            this.errorProvider.SetIconAlignment(this.tabPorts, System.Windows.Forms.ErrorIconAlignment.TopLeft);
            this.tabPorts.Location = new System.Drawing.Point(4, 25);
            this.tabPorts.Name = "tabPorts";
            this.tabPorts.Padding = new System.Windows.Forms.Padding(3);
            this.tabPorts.Size = new System.Drawing.Size(710, 251);
            this.tabPorts.TabIndex = 0;
            this.tabPorts.Text = "Ports";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.lvPorts);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.lvPortConnectors);
            this.splitContainer2.Size = new System.Drawing.Size(676, 245);
            this.splitContainer2.SplitterDistance = 321;
            this.splitContainer2.TabIndex = 32;
            // 
            // lvPorts
            // 
            this.lvPorts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvPorts.FullRowSelect = true;
            this.lvPorts.HasErrors = false;
            this.lvPorts.HideSelection = false;
            this.lvPorts.Location = new System.Drawing.Point(0, 0);
            this.lvPorts.Name = "lvPorts";
            this.lvPorts.PortInterface = null;
            this.lvPorts.Size = new System.Drawing.Size(321, 245);
            this.lvPorts.TabIndex = 19;
            this.lvPorts.UseCompatibleStateImageBehavior = false;
            this.lvPorts.View = System.Windows.Forms.View.Details;
            this.lvPorts.SelectedIndexChanged += new System.EventHandler(this.lvPorts_SelectedIndexChanged);
            // 
            // lvPortConnectors
            // 
            this.lvPortConnectors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvPortConnectors.FullRowSelect = true;
            this.lvPortConnectors.HasErrors = false;
            this.lvPortConnectors.HideSelection = false;
            this.lvPortConnectors.Location = new System.Drawing.Point(0, 0);
            this.lvPortConnectors.Name = "lvPortConnectors";
            this.lvPortConnectors.Port = null;
            this.lvPortConnectors.Size = new System.Drawing.Size(351, 245);
            this.lvPortConnectors.TabIndex = 31;
            this.lvPortConnectors.UseCompatibleStateImageBehavior = false;
            this.lvPortConnectors.View = System.Windows.Forms.View.Details;
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Right;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddPort,
            this.btnEditPort,
            this.btnDeletePort});
            this.toolStrip2.Location = new System.Drawing.Point(679, 3);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip2.Size = new System.Drawing.Size(28, 245);
            this.toolStrip2.TabIndex = 30;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // btnAddPort
            // 
            this.btnAddPort.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddPort.Image = ((System.Drawing.Image)(resources.GetObject("btnAddPort.Image")));
            this.btnAddPort.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAddPort.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddPort.Name = "btnAddPort";
            this.btnAddPort.Size = new System.Drawing.Size(27, 28);
            this.btnAddPort.Text = "Add";
            this.btnAddPort.ToolTipText = "Press to add a new Port";
            this.btnAddPort.Click += new System.EventHandler(this.btnAddPort_Click);
            // 
            // btnEditPort
            // 
            this.btnEditPort.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEditPort.Image = ((System.Drawing.Image)(resources.GetObject("btnEditPort.Image")));
            this.btnEditPort.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnEditPort.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditPort.Name = "btnEditPort";
            this.btnEditPort.Size = new System.Drawing.Size(27, 28);
            this.btnEditPort.Text = "Edit";
            this.btnEditPort.ToolTipText = "Press to edit the selected Port";
            this.btnEditPort.Visible = false;
            this.btnEditPort.Click += new System.EventHandler(this.btnEditPort_Click);
            // 
            // btnDeletePort
            // 
            this.btnDeletePort.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDeletePort.Image = ((System.Drawing.Image)(resources.GetObject("btnDeletePort.Image")));
            this.btnDeletePort.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnDeletePort.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeletePort.Name = "btnDeletePort";
            this.btnDeletePort.Size = new System.Drawing.Size(27, 28);
            this.btnDeletePort.Text = "Delete";
            this.btnDeletePort.ToolTipText = "Press to delete the selected Port";
            this.btnDeletePort.Visible = false;
            this.btnDeletePort.Click += new System.EventHandler(this.btnDeletePort_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // PhysicalInterfaceListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl4);
            this.Name = "PhysicalInterfaceListControl";
            this.Size = new System.Drawing.Size(718, 280);
            this.tabControl4.ResumeLayout(false);
            this.tabConnectors.ResumeLayout(false);
            this.tabConnectors.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabPorts.ResumeLayout(false);
            this.tabPorts.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ATMLCommonLibrary.controls.awb.AWBTabControl tabControl4;
        private System.Windows.Forms.TabPage tabPorts;
        private System.Windows.Forms.TabPage tabConnectors;
        private ConnectorListView lvConnectors;
        private PortListView lvPorts;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btnAddPort;
        private System.Windows.Forms.ToolStripButton btnEditPort;
        private System.Windows.Forms.ToolStripButton btnDeletePort;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAddConnector;
        private System.Windows.Forms.ToolStripButton btnEditConnector;
        private System.Windows.Forms.ToolStripButton btnDeleteConnector;
        private PortConnectorListView lvPortConnectors;
        private ConnectorPinListView lvPins;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}
