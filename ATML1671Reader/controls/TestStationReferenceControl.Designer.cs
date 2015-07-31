/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

namespace ATML1671Reader.controls
{
    partial class TestStationReferenceControl
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.testEquipmentListControl = new ATMLCommonLibrary.controls.lists.ATMLListControl();
            this.instrumentationTab = new System.Windows.Forms.TabControl();
            this.tabInstrumentation = new System.Windows.Forms.TabPage();
            this.instrumentationListControl = new ATMLCommonLibrary.controls.lists.ATMLListControl();
            this.tabSoftware = new System.Windows.Forms.TabPage();
            this.softwareListControl = new ATMLCommonLibrary.controls.lists.ATMLListControl();
            this.tabResources = new System.Windows.Forms.TabPage();
            this.resourceListControl = new ATMLCommonLibrary.controls.lists.ATMLListControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.instrumentationTab.SuspendLayout();
            this.tabInstrumentation.SuspendLayout();
            this.tabSoftware.SuspendLayout();
            this.tabResources.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.testEquipmentListControl);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.instrumentationTab);
            this.splitContainer1.Size = new System.Drawing.Size(229, 320);
            this.splitContainer1.SplitterDistance = 118;
            this.splitContainer1.TabIndex = 0;
            // 
            // testEquipmentListControl
            // 
            this.testEquipmentListControl.AllowRowResequencing = false;
            this.testEquipmentListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.testEquipmentListControl.FormTitle = null;
            this.testEquipmentListControl.HelpKeyWord = null;
            this.testEquipmentListControl.ListName = null;
            this.testEquipmentListControl.Location = new System.Drawing.Point(0, 0);
            this.testEquipmentListControl.Margin = new System.Windows.Forms.Padding(0);
            this.testEquipmentListControl.Name = "testEquipmentListControl";
            this.testEquipmentListControl.SchemaTypeName = null;
            this.testEquipmentListControl.ShowFind = false;
            this.testEquipmentListControl.Size = new System.Drawing.Size(229, 118);
            this.testEquipmentListControl.TabIndex = 1;
            this.testEquipmentListControl.TargetNamespace = null;
            this.testEquipmentListControl.TooltipTextAddButton = "Press to add a new Test Station Reference";
            this.testEquipmentListControl.TooltipTextDeleteButton = "Press to delete the selected Test Station";
            this.testEquipmentListControl.TooltipTextEditButton = "Press to edit the selected Test Station";
            // 
            // instrumentationTab
            // 
            this.instrumentationTab.Controls.Add(this.tabInstrumentation);
            this.instrumentationTab.Controls.Add(this.tabSoftware);
            this.instrumentationTab.Controls.Add(this.tabResources);
            this.instrumentationTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.instrumentationTab.Location = new System.Drawing.Point(0, 0);
            this.instrumentationTab.Name = "instrumentationTab";
            this.instrumentationTab.SelectedIndex = 0;
            this.instrumentationTab.Size = new System.Drawing.Size(229, 198);
            this.instrumentationTab.TabIndex = 2;
            // 
            // tabInstrumentation
            // 
            this.tabInstrumentation.Controls.Add(this.instrumentationListControl);
            this.tabInstrumentation.Location = new System.Drawing.Point(4, 22);
            this.tabInstrumentation.Name = "tabInstrumentation";
            this.tabInstrumentation.Padding = new System.Windows.Forms.Padding(3);
            this.tabInstrumentation.Size = new System.Drawing.Size(221, 172);
            this.tabInstrumentation.TabIndex = 0;
            this.tabInstrumentation.Text = "Instrumentation";
            this.tabInstrumentation.UseVisualStyleBackColor = true;
            // 
            // instrumentationListControl
            // 
            this.instrumentationListControl.AllowRowResequencing = false;
            this.instrumentationListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.instrumentationListControl.FormTitle = null;
            this.instrumentationListControl.HelpKeyWord = null;
            this.instrumentationListControl.ListName = null;
            this.instrumentationListControl.Location = new System.Drawing.Point(3, 3);
            this.instrumentationListControl.Margin = new System.Windows.Forms.Padding(0);
            this.instrumentationListControl.Name = "instrumentationListControl";
            this.instrumentationListControl.SchemaTypeName = null;
            this.instrumentationListControl.ShowFind = false;
            this.instrumentationListControl.Size = new System.Drawing.Size(215, 166);
            this.instrumentationListControl.TabIndex = 1;
            this.instrumentationListControl.TargetNamespace = null;
            this.instrumentationListControl.TooltipTextAddButton = "Press to add a new Instrument Reference";
            this.instrumentationListControl.TooltipTextDeleteButton = "Press to delete the selected Instrument Reference";
            this.instrumentationListControl.TooltipTextEditButton = "Press to edit the selected Instrument Reference";
            // 
            // tabSoftware
            // 
            this.tabSoftware.Controls.Add(this.softwareListControl);
            this.tabSoftware.Location = new System.Drawing.Point(4, 22);
            this.tabSoftware.Name = "tabSoftware";
            this.tabSoftware.Padding = new System.Windows.Forms.Padding(3);
            this.tabSoftware.Size = new System.Drawing.Size(221, 172);
            this.tabSoftware.TabIndex = 1;
            this.tabSoftware.Text = "Software";
            this.tabSoftware.UseVisualStyleBackColor = true;
            // 
            // softwareListControl
            // 
            this.softwareListControl.AllowRowResequencing = false;
            this.softwareListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.softwareListControl.FormTitle = null;
            this.softwareListControl.HelpKeyWord = null;
            this.softwareListControl.ListName = null;
            this.softwareListControl.Location = new System.Drawing.Point(3, 3);
            this.softwareListControl.Margin = new System.Windows.Forms.Padding(0);
            this.softwareListControl.Name = "softwareListControl";
            this.softwareListControl.SchemaTypeName = null;
            this.softwareListControl.ShowFind = false;
            this.softwareListControl.Size = new System.Drawing.Size(215, 166);
            this.softwareListControl.TabIndex = 1;
            this.softwareListControl.TargetNamespace = null;
            this.softwareListControl.TooltipTextAddButton = "Press to add a new Software Reference";
            this.softwareListControl.TooltipTextDeleteButton = "Press to delete the selected Software Reference";
            this.softwareListControl.TooltipTextEditButton = "Press to edit the selected Software Reference";
            // 
            // tabResources
            // 
            this.tabResources.Controls.Add(this.resourceListControl);
            this.tabResources.Location = new System.Drawing.Point(4, 22);
            this.tabResources.Name = "tabResources";
            this.tabResources.Padding = new System.Windows.Forms.Padding(3);
            this.tabResources.Size = new System.Drawing.Size(221, 172);
            this.tabResources.TabIndex = 0;
            this.tabResources.Text = "Resources";
            this.tabResources.UseVisualStyleBackColor = true;
            // 
            // resourceListControl
            // 
            this.resourceListControl.AllowRowResequencing = false;
            this.resourceListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resourceListControl.FormTitle = null;
            this.resourceListControl.HelpKeyWord = null;
            this.resourceListControl.ListName = null;
            this.resourceListControl.Location = new System.Drawing.Point(3, 3);
            this.resourceListControl.Margin = new System.Windows.Forms.Padding(0);
            this.resourceListControl.Name = "resourceListControl";
            this.resourceListControl.SchemaTypeName = null;
            this.resourceListControl.ShowFind = false;
            this.resourceListControl.Size = new System.Drawing.Size(215, 166);
            this.resourceListControl.TabIndex = 2;
            this.resourceListControl.TargetNamespace = null;
            this.resourceListControl.TooltipTextAddButton = "Press to add a new Resource Reference";
            this.resourceListControl.TooltipTextDeleteButton = "Press to delete the selected Resource Reference";
            this.resourceListControl.TooltipTextEditButton = "Press to edit the selected Resource Reference";
            // 
            // TestStationReferenceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "TestStationReferenceControl";
            this.Size = new System.Drawing.Size(229, 320);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.instrumentationTab.ResumeLayout(false);
            this.tabInstrumentation.ResumeLayout(false);
            this.tabSoftware.ResumeLayout(false);
            this.tabResources.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private ATMLCommonLibrary.controls.lists.ATMLListControl testEquipmentListControl;
        private System.Windows.Forms.TabControl instrumentationTab;
        private System.Windows.Forms.TabPage tabInstrumentation;
        private ATMLCommonLibrary.controls.lists.ATMLListControl instrumentationListControl;
        private System.Windows.Forms.TabPage tabSoftware;
        private ATMLCommonLibrary.controls.lists.ATMLListControl softwareListControl;
        private System.Windows.Forms.TabPage tabResources;
        private ATMLCommonLibrary.controls.lists.ATMLListControl resourceListControl;
    }
}
