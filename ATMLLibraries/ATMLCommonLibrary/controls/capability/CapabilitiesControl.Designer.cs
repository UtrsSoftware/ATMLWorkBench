/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using ATMLCommonLibrary.controls.network;

namespace ATMLCommonLibrary.controls.capability
{
    partial class CapabilitiesControl
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
            this.tabControl1 = new ATMLCommonLibrary.controls.awb.AWBTabControl();
            this.tabCapabilities = new System.Windows.Forms.TabPage();
            this.capabilityListControl1 = new ATMLCommonLibrary.controls.capability.CapabilityListControl();
            this.tabCapabilitiesMap = new System.Windows.Forms.TabPage();
            this.mappingListControl1 = new ATMLCommonLibrary.controls.network.MappingListControl();
            this.tabControl1.SuspendLayout();
            this.tabCapabilities.SuspendLayout();
            this.tabCapabilitiesMap.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabCapabilities);
            this.tabControl1.Controls.Add(this.tabCapabilitiesMap);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.MainBackColor = System.Drawing.Color.AliceBlue;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(543, 245);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight; 
            this.tabControl1.TabIndex = 1;
            // 
            // tabCapabilities
            // 
            this.tabCapabilities.BackColor = System.Drawing.SystemColors.Control;
            this.tabCapabilities.Controls.Add(this.capabilityListControl1);
            this.tabCapabilities.Location = new System.Drawing.Point(4, 25);
            this.tabCapabilities.Name = "tabCapabilities";
            this.tabCapabilities.Padding = new System.Windows.Forms.Padding(3);
            this.tabCapabilities.Size = new System.Drawing.Size(535, 216);
            this.tabCapabilities.TabIndex = 0;
            this.tabCapabilities.Text = "Capabilities";
            // 
            // capabilityListControl1
            // 
            this.capabilityListControl1.AllowRowResequencing = false;
            this.capabilityListControl1.BackColor = System.Drawing.Color.AliceBlue;
            this.capabilityListControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.capabilityListControl1.FormTitle = null;
            this.capabilityListControl1.HasErrors = false;
            this.capabilityListControl1.HelpKeyWord = null;
            this.capabilityListControl1.LastError = null;
            this.capabilityListControl1.ListName = null;
            this.capabilityListControl1.Location = new System.Drawing.Point(3, 3);
            this.capabilityListControl1.Margin = new System.Windows.Forms.Padding(0);
            this.capabilityListControl1.Name = "capabilityListControl1";
            this.capabilityListControl1.SchemaTypeName = null;
            this.capabilityListControl1.ShowFind = false;
            this.capabilityListControl1.Size = new System.Drawing.Size(529, 210);
            this.capabilityListControl1.TabIndex = 0;
            this.capabilityListControl1.TargetNamespace = null;
            this.capabilityListControl1.TooltipTextAddButton = "Click to add a new Capability";
            this.capabilityListControl1.TooltipTextDeleteButton = "Click to delete the selected Capability";
            this.capabilityListControl1.TooltipTextEditButton = "Click to edit the selected Capability";
            // 
            // tabCapabilitiesMap
            // 
            this.tabCapabilitiesMap.Controls.Add(this.mappingListControl1);
            this.tabCapabilitiesMap.Location = new System.Drawing.Point(4, 25);
            this.tabCapabilitiesMap.Name = "tabCapabilitiesMap";
            this.tabCapabilitiesMap.Padding = new System.Windows.Forms.Padding(3);
            this.tabCapabilitiesMap.Size = new System.Drawing.Size(535, 216);
            this.tabCapabilitiesMap.TabIndex = 1;
            this.tabCapabilitiesMap.Text = "Capabilities Map";
            // 
            // mappingListControl1
            // 
            this.mappingListControl1.AllowRowResequencing = false;
            this.mappingListControl1.BackColor = System.Drawing.Color.AliceBlue;
            this.mappingListControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mappingListControl1.FormTitle = null;
            this.mappingListControl1.HardwareItemDescription = null;
            this.mappingListControl1.HasErrors = false;
            this.mappingListControl1.HelpKeyWord = null;
            this.mappingListControl1.LastError = null;
            this.mappingListControl1.ListName = null;
            this.mappingListControl1.Location = new System.Drawing.Point(3, 3);
            this.mappingListControl1.Margin = new System.Windows.Forms.Padding(0);
            this.mappingListControl1.Name = "mappingListControl1";
            this.mappingListControl1.SchemaTypeName = null;
            this.mappingListControl1.ShowFind = false;
            this.mappingListControl1.Size = new System.Drawing.Size(529, 210);
            this.mappingListControl1.TabIndex = 0;
            this.mappingListControl1.TargetNamespace = null;
            this.mappingListControl1.TooltipTextAddButton = "Press to add a new ";
            this.mappingListControl1.TooltipTextDeleteButton = "Press to delete the selected ";
            this.mappingListControl1.TooltipTextEditButton = "Press to edit the selected ";
            // 
            // CapabilitiesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "CapabilitiesControl";
            this.Size = new System.Drawing.Size(543, 245);
            this.tabControl1.ResumeLayout(false);
            this.tabCapabilities.ResumeLayout(false);
            this.tabCapabilitiesMap.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ATMLCommonLibrary.controls.awb.AWBTabControl tabControl1;
        private System.Windows.Forms.TabPage tabCapabilities;
        private System.Windows.Forms.TabPage tabCapabilitiesMap;
        private CapabilityListControl capabilityListControl1;
        private MappingListControl mappingListControl1;
    }
}
