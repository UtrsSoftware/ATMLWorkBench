/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

namespace ATML1671Reader.controls
{
    partial class TestConfigurationControl
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestConfigurationControl));
            this.tsTestConfiguration = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.btnSaveConfiguration = new System.Windows.Forms.ToolStripButton();
            this.btnUndo = new System.Windows.Forms.ToolStripButton();
            this.edtUUID = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.label4 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabManager = new System.Windows.Forms.TabPage();
            this.manufacturerControl1 = new ATMLCommonLibrary.controls.manufacturer.ManufacturerControl();
            this.tabUUTs = new System.Windows.Forms.TabPage();
            this.uutListControl = new ATMLCommonLibrary.controls.lists.ATMLListControl();
            this.tabTestStations = new System.Windows.Forms.TabPage();
            this.tabTPS = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabHardware = new System.Windows.Forms.TabPage();
            this.tabTPSSoftware = new System.Windows.Forms.TabPage();
            this.tabDocumentation = new System.Windows.Forms.TabPage();
            this.tabAdtlSoftware = new System.Windows.Forms.TabPage();
            this.tabAdtlResources = new System.Windows.Forms.TabPage();
            this.securityClassificationControl = new WindowsFormsApplication10.SecurityClassificationControl();
            this.btnCreateUUID = new System.Windows.Forms.Button();
            this.testStationReferenceControl = new ATML1671Reader.controls.TestStationReferenceControl();
            this.tpsResourceReferenceListControl = new ATML1671Reader.controls.TpsResourceReferenceListControl();
            this.tpsSoftwareReferenceListControl = new ATML1671Reader.controls.TpsSoftwareReferenceListControl();
            this.testProgramDocumentationListControl = new ATML1671Reader.controls.TestProgramDocumentationListControl();
            this.tpsAdditionalSoftwareReferenceListControl = new ATML1671Reader.controls.TpsSoftwareReferenceListControl();
            this.tpsAdditionalResourceReferenceListControl = new ATML1671Reader.controls.TpsResourceReferenceListControl();
            this.tsTestConfiguration.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabManager.SuspendLayout();
            this.tabUUTs.SuspendLayout();
            this.tabTestStations.SuspendLayout();
            this.tabTPS.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabHardware.SuspendLayout();
            this.tabTPSSoftware.SuspendLayout();
            this.tabDocumentation.SuspendLayout();
            this.tabAdtlSoftware.SuspendLayout();
            this.tabAdtlResources.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsTestConfiguration
            // 
            this.tsTestConfiguration.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsTestConfiguration.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.btnSaveConfiguration,
            this.btnUndo});
            this.tsTestConfiguration.Location = new System.Drawing.Point(0, 0);
            this.tsTestConfiguration.Name = "tsTestConfiguration";
            this.tsTestConfiguration.Size = new System.Drawing.Size(255, 25);
            this.tsTestConfiguration.TabIndex = 0;
            this.tsTestConfiguration.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(111, 22);
            this.toolStripLabel1.Text = "Test Configuration";
            // 
            // btnSaveConfiguration
            // 
            this.btnSaveConfiguration.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSaveConfiguration.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveConfiguration.Image")));
            this.btnSaveConfiguration.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveConfiguration.Name = "btnSaveConfiguration";
            this.btnSaveConfiguration.Size = new System.Drawing.Size(23, 22);
            this.btnSaveConfiguration.Text = "Save Test Configuration";
            this.btnSaveConfiguration.Visible = false;
            this.btnSaveConfiguration.Click += new System.EventHandler(this.btnSaveConfiguration_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUndo.Image = ((System.Drawing.Image)(resources.GetObject("btnUndo.Image")));
            this.btnUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(23, 22);
            this.btnUndo.Text = "Undo Changes";
            this.btnUndo.Visible = false;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // edtUUID
            // 
            this.edtUUID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtUUID.AttributeName = null;
            this.edtUUID.BackColor = System.Drawing.Color.PaleTurquoise;
            this.edtUUID.DataLookupKey = null;
            this.edtUUID.Location = new System.Drawing.Point(56, 25);
            this.edtUUID.Name = "edtUUID";
            this.edtUUID.Size = new System.Drawing.Size(162, 20);
            this.edtUUID.TabIndex = 8;
            this.edtUUID.Value = null;
            this.edtUUID.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.HelpMessageKey = null;
            this.label4.Location = new System.Drawing.Point(19, 28);
            this.label4.Name = "label4";
            this.label4.RequiredField = false;
            this.label4.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "UUID";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabManager);
            this.tabControl1.Controls.Add(this.tabUUTs);
            this.tabControl1.Controls.Add(this.tabTestStations);
            this.tabControl1.Controls.Add(this.tabTPS);
            this.tabControl1.Controls.Add(this.tabAdtlSoftware);
            this.tabControl1.Controls.Add(this.tabAdtlResources);
            this.tabControl1.Location = new System.Drawing.Point(2, 75);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.ShowToolTips = true;
            this.tabControl1.Size = new System.Drawing.Size(251, 345);
            this.tabControl1.TabIndex = 14;
            // 
            // tabManager
            // 
            this.tabManager.Controls.Add(this.manufacturerControl1);
            this.tabManager.Location = new System.Drawing.Point(4, 40);
            this.tabManager.Name = "tabManager";
            this.tabManager.Size = new System.Drawing.Size(243, 301);
            this.tabManager.TabIndex = 5;
            this.tabManager.Text = "Manager";
            this.tabManager.ToolTipText = "Configuration Manager Information";
            this.tabManager.UseVisualStyleBackColor = true;
            // 
            // manufacturerControl1
            // 
            this.manufacturerControl1.AutoScroll = true;
            this.manufacturerControl1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.manufacturerControl1.BackColor = System.Drawing.Color.AliceBlue;
            this.manufacturerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.manufacturerControl1.HasErrors = false;
            this.manufacturerControl1.HelpKeyWord = null;
            this.manufacturerControl1.LastError = null;
            this.manufacturerControl1.Location = new System.Drawing.Point(0, 0);
            this.manufacturerControl1.Name = "manufacturerControl1";
            this.manufacturerControl1.SchemaTypeName = null;
            this.manufacturerControl1.Size = new System.Drawing.Size(243, 301);
            this.manufacturerControl1.TabIndex = 0;
            this.manufacturerControl1.TargetNamespace = null;
            this.manufacturerControl1.ValidationEndabled = true;
            // 
            // tabUUTs
            // 
            this.tabUUTs.Controls.Add(this.uutListControl);
            this.tabUUTs.Location = new System.Drawing.Point(4, 22);
            this.tabUUTs.Name = "tabUUTs";
            this.tabUUTs.Padding = new System.Windows.Forms.Padding(3);
            this.tabUUTs.Size = new System.Drawing.Size(243, 319);
            this.tabUUTs.TabIndex = 2;
            this.tabUUTs.Text = "UUTs";
            this.tabUUTs.ToolTipText = "Units Under Test";
            this.tabUUTs.UseVisualStyleBackColor = true;
            // 
            // uutListControl
            // 
            this.uutListControl.AllowRowResequencing = false;
            this.uutListControl.BackColor = System.Drawing.Color.AliceBlue;
            this.uutListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uutListControl.FormTitle = null;
            this.uutListControl.HasErrors = false;
            this.uutListControl.HelpKeyWord = null;
            this.uutListControl.LastError = null;
            this.uutListControl.ListName = null;
            this.uutListControl.Location = new System.Drawing.Point(3, 3);
            this.uutListControl.Margin = new System.Windows.Forms.Padding(0);
            this.uutListControl.Name = "uutListControl";
            this.uutListControl.SchemaTypeName = null;
            this.uutListControl.ShowFind = false;
            this.uutListControl.Size = new System.Drawing.Size(237, 313);
            this.uutListControl.TabIndex = 0;
            this.uutListControl.TargetNamespace = null;
            this.uutListControl.TooltipTextAddButton = "Press to add a new ";
            this.uutListControl.TooltipTextDeleteButton = "Press to delete the selected ";
            this.uutListControl.TooltipTextEditButton = "Press to edit the selected ";
            this.uutListControl.Load += new System.EventHandler(this.uutListControl_Load);
            // 
            // tabTestStations
            // 
            this.tabTestStations.Controls.Add(this.testStationReferenceControl);
            this.tabTestStations.Location = new System.Drawing.Point(4, 22);
            this.tabTestStations.Name = "tabTestStations";
            this.tabTestStations.Padding = new System.Windows.Forms.Padding(3);
            this.tabTestStations.Size = new System.Drawing.Size(243, 319);
            this.tabTestStations.TabIndex = 6;
            this.tabTestStations.Text = "Test Stations";
            this.tabTestStations.ToolTipText = "Test Stations and Related Data";
            this.tabTestStations.UseVisualStyleBackColor = true;
            // 
            // tabTPS
            // 
            this.tabTPS.Controls.Add(this.tabControl2);
            this.tabTPS.Location = new System.Drawing.Point(4, 22);
            this.tabTPS.Name = "tabTPS";
            this.tabTPS.Padding = new System.Windows.Forms.Padding(3);
            this.tabTPS.Size = new System.Drawing.Size(243, 319);
            this.tabTPS.TabIndex = 7;
            this.tabTPS.Text = "TPEs";
            this.tabTPS.ToolTipText = "Test Program Elements";
            this.tabTPS.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabHardware);
            this.tabControl2.Controls.Add(this.tabTPSSoftware);
            this.tabControl2.Controls.Add(this.tabDocumentation);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(3, 3);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(237, 313);
            this.tabControl2.TabIndex = 2;
            // 
            // tabHardware
            // 
            this.tabHardware.Controls.Add(this.tpsResourceReferenceListControl);
            this.tabHardware.Location = new System.Drawing.Point(4, 22);
            this.tabHardware.Name = "tabHardware";
            this.tabHardware.Padding = new System.Windows.Forms.Padding(3);
            this.tabHardware.Size = new System.Drawing.Size(229, 287);
            this.tabHardware.TabIndex = 0;
            this.tabHardware.Text = "Hardware";
            this.tabHardware.UseVisualStyleBackColor = true;
            // 
            // tabTPSSoftware
            // 
            this.tabTPSSoftware.Controls.Add(this.tpsSoftwareReferenceListControl);
            this.tabTPSSoftware.Location = new System.Drawing.Point(4, 22);
            this.tabTPSSoftware.Name = "tabTPSSoftware";
            this.tabTPSSoftware.Padding = new System.Windows.Forms.Padding(3);
            this.tabTPSSoftware.Size = new System.Drawing.Size(229, 287);
            this.tabTPSSoftware.TabIndex = 1;
            this.tabTPSSoftware.Text = "Software";
            this.tabTPSSoftware.UseVisualStyleBackColor = true;
            // 
            // tabDocumentation
            // 
            this.tabDocumentation.Controls.Add(this.testProgramDocumentationListControl);
            this.tabDocumentation.Location = new System.Drawing.Point(4, 22);
            this.tabDocumentation.Name = "tabDocumentation";
            this.tabDocumentation.Padding = new System.Windows.Forms.Padding(3);
            this.tabDocumentation.Size = new System.Drawing.Size(229, 287);
            this.tabDocumentation.TabIndex = 0;
            this.tabDocumentation.Text = "Documentation";
            this.tabDocumentation.UseVisualStyleBackColor = true;
            // 
            // tabAdtlSoftware
            // 
            this.tabAdtlSoftware.Controls.Add(this.tpsAdditionalSoftwareReferenceListControl);
            this.tabAdtlSoftware.Location = new System.Drawing.Point(4, 40);
            this.tabAdtlSoftware.Name = "tabAdtlSoftware";
            this.tabAdtlSoftware.Padding = new System.Windows.Forms.Padding(3);
            this.tabAdtlSoftware.Size = new System.Drawing.Size(243, 301);
            this.tabAdtlSoftware.TabIndex = 8;
            this.tabAdtlSoftware.Text = "Adtl Software";
            this.tabAdtlSoftware.ToolTipText = "Additional Software";
            this.tabAdtlSoftware.UseVisualStyleBackColor = true;
            // 
            // tabAdtlResources
            // 
            this.tabAdtlResources.Controls.Add(this.tpsAdditionalResourceReferenceListControl);
            this.tabAdtlResources.Location = new System.Drawing.Point(4, 40);
            this.tabAdtlResources.Name = "tabAdtlResources";
            this.tabAdtlResources.Padding = new System.Windows.Forms.Padding(3);
            this.tabAdtlResources.Size = new System.Drawing.Size(243, 301);
            this.tabAdtlResources.TabIndex = 9;
            this.tabAdtlResources.Text = "Adtl Resources";
            this.tabAdtlResources.ToolTipText = "Additional Resources";
            this.tabAdtlResources.UseVisualStyleBackColor = true;
            // 
            // securityClassificationControl
            // 
            this.securityClassificationControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.securityClassificationControl.BackColor = System.Drawing.Color.AliceBlue;
            this.securityClassificationControl.Classified = false;
            this.securityClassificationControl.HasErrors = false;
            this.securityClassificationControl.HelpKeyWord = null;
            this.securityClassificationControl.LastError = null;
            this.securityClassificationControl.Location = new System.Drawing.Point(6, 50);
            this.securityClassificationControl.Name = "securityClassificationControl";
            this.securityClassificationControl.SchemaTypeName = null;
            this.securityClassificationControl.SecurityClassification = null;
            this.securityClassificationControl.Size = new System.Drawing.Size(230, 21);
            this.securityClassificationControl.TabIndex = 15;
            this.securityClassificationControl.TargetNamespace = null;
            // 
            // btnCreateUUID
            // 
            this.btnCreateUUID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateUUID.FlatAppearance.BorderSize = 0;
            this.btnCreateUUID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateUUID.Image = ((System.Drawing.Image)(resources.GetObject("btnCreateUUID.Image")));
            this.btnCreateUUID.Location = new System.Drawing.Point(217, 23);
            this.btnCreateUUID.Name = "btnCreateUUID";
            this.btnCreateUUID.Size = new System.Drawing.Size(21, 21);
            this.btnCreateUUID.TabIndex = 16;
            this.btnCreateUUID.UseVisualStyleBackColor = true;
            this.btnCreateUUID.Click += new System.EventHandler(this.btnCreateUUID_Click);
            // 
            // testStationReferenceControl
            // 
            this.testStationReferenceControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.testStationReferenceControl.Location = new System.Drawing.Point(3, 3);
            this.testStationReferenceControl.Name = "testStationReferenceControl";
            this.testStationReferenceControl.Size = new System.Drawing.Size(237, 313);
            this.testStationReferenceControl.TabIndex = 0;
            // 
            // tpsResourceReferenceListControl
            // 
            this.tpsResourceReferenceListControl.AllowRowResequencing = false;
            this.tpsResourceReferenceListControl.BackColor = System.Drawing.Color.AliceBlue;
            this.tpsResourceReferenceListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tpsResourceReferenceListControl.FormTitle = null;
            this.tpsResourceReferenceListControl.HasErrors = false;
            this.tpsResourceReferenceListControl.HelpKeyWord = null;
            this.tpsResourceReferenceListControl.LastError = null;
            this.tpsResourceReferenceListControl.ListName = null;
            this.tpsResourceReferenceListControl.Location = new System.Drawing.Point(3, 3);
            this.tpsResourceReferenceListControl.Margin = new System.Windows.Forms.Padding(0);
            this.tpsResourceReferenceListControl.Name = "tpsResourceReferenceListControl";
            this.tpsResourceReferenceListControl.SchemaTypeName = null;
            this.tpsResourceReferenceListControl.ShowFind = false;
            this.tpsResourceReferenceListControl.Size = new System.Drawing.Size(223, 281);
            this.tpsResourceReferenceListControl.TabIndex = 0;
            this.tpsResourceReferenceListControl.TargetNamespace = null;
            this.tpsResourceReferenceListControl.TooltipTextAddButton = "Press to add a new ";
            this.tpsResourceReferenceListControl.TooltipTextDeleteButton = "Press to delete the selected ";
            this.tpsResourceReferenceListControl.TooltipTextEditButton = "Press to edit the selected ";
            // 
            // tpsSoftwareReferenceListControl
            // 
            this.tpsSoftwareReferenceListControl.AllowRowResequencing = false;
            this.tpsSoftwareReferenceListControl.BackColor = System.Drawing.Color.AliceBlue;
            this.tpsSoftwareReferenceListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tpsSoftwareReferenceListControl.FormTitle = null;
            this.tpsSoftwareReferenceListControl.HasErrors = false;
            this.tpsSoftwareReferenceListControl.HelpKeyWord = null;
            this.tpsSoftwareReferenceListControl.LastError = null;
            this.tpsSoftwareReferenceListControl.ListName = null;
            this.tpsSoftwareReferenceListControl.Location = new System.Drawing.Point(3, 3);
            this.tpsSoftwareReferenceListControl.Margin = new System.Windows.Forms.Padding(0);
            this.tpsSoftwareReferenceListControl.Name = "tpsSoftwareReferenceListControl";
            this.tpsSoftwareReferenceListControl.SchemaTypeName = null;
            this.tpsSoftwareReferenceListControl.ShowFind = false;
            this.tpsSoftwareReferenceListControl.Size = new System.Drawing.Size(223, 281);
            this.tpsSoftwareReferenceListControl.TabIndex = 2;
            this.tpsSoftwareReferenceListControl.TargetNamespace = null;
            this.tpsSoftwareReferenceListControl.TooltipTextAddButton = "Press to add a new ";
            this.tpsSoftwareReferenceListControl.TooltipTextDeleteButton = "Press to delete the selected ";
            this.tpsSoftwareReferenceListControl.TooltipTextEditButton = "Press to edit the selected ";
            // 
            // testProgramDocumentationListControl
            // 
            this.testProgramDocumentationListControl.AllowRowResequencing = false;
            this.testProgramDocumentationListControl.BackColor = System.Drawing.Color.AliceBlue;
            this.testProgramDocumentationListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.testProgramDocumentationListControl.FormTitle = null;
            this.testProgramDocumentationListControl.HasErrors = false;
            this.testProgramDocumentationListControl.HelpKeyWord = null;
            this.testProgramDocumentationListControl.LastError = null;
            this.testProgramDocumentationListControl.ListName = null;
            this.testProgramDocumentationListControl.Location = new System.Drawing.Point(3, 3);
            this.testProgramDocumentationListControl.Margin = new System.Windows.Forms.Padding(0);
            this.testProgramDocumentationListControl.Name = "testProgramDocumentationListControl";
            this.testProgramDocumentationListControl.SchemaTypeName = null;
            this.testProgramDocumentationListControl.ShowFind = false;
            this.testProgramDocumentationListControl.Size = new System.Drawing.Size(223, 281);
            this.testProgramDocumentationListControl.TabIndex = 0;
            this.testProgramDocumentationListControl.TargetNamespace = null;
            this.testProgramDocumentationListControl.TooltipTextAddButton = "Press to add a new ";
            this.testProgramDocumentationListControl.TooltipTextDeleteButton = "Press to delete the selected ";
            this.testProgramDocumentationListControl.TooltipTextEditButton = "Press to edit the selected ";
            // 
            // tpsAdditionalSoftwareReferenceListControl
            // 
            this.tpsAdditionalSoftwareReferenceListControl.AllowRowResequencing = false;
            this.tpsAdditionalSoftwareReferenceListControl.BackColor = System.Drawing.Color.AliceBlue;
            this.tpsAdditionalSoftwareReferenceListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tpsAdditionalSoftwareReferenceListControl.FormTitle = null;
            this.tpsAdditionalSoftwareReferenceListControl.HasErrors = false;
            this.tpsAdditionalSoftwareReferenceListControl.HelpKeyWord = null;
            this.tpsAdditionalSoftwareReferenceListControl.LastError = null;
            this.tpsAdditionalSoftwareReferenceListControl.ListName = null;
            this.tpsAdditionalSoftwareReferenceListControl.Location = new System.Drawing.Point(3, 3);
            this.tpsAdditionalSoftwareReferenceListControl.Margin = new System.Windows.Forms.Padding(0);
            this.tpsAdditionalSoftwareReferenceListControl.Name = "tpsAdditionalSoftwareReferenceListControl";
            this.tpsAdditionalSoftwareReferenceListControl.SchemaTypeName = null;
            this.tpsAdditionalSoftwareReferenceListControl.ShowFind = false;
            this.tpsAdditionalSoftwareReferenceListControl.Size = new System.Drawing.Size(237, 295);
            this.tpsAdditionalSoftwareReferenceListControl.TabIndex = 0;
            this.tpsAdditionalSoftwareReferenceListControl.TargetNamespace = null;
            this.tpsAdditionalSoftwareReferenceListControl.TooltipTextAddButton = "Press to add a new ";
            this.tpsAdditionalSoftwareReferenceListControl.TooltipTextDeleteButton = "Press to delete the selected ";
            this.tpsAdditionalSoftwareReferenceListControl.TooltipTextEditButton = "Press to edit the selected ";
            // 
            // tpsAdditionalResourceReferenceListControl
            // 
            this.tpsAdditionalResourceReferenceListControl.AllowRowResequencing = false;
            this.tpsAdditionalResourceReferenceListControl.BackColor = System.Drawing.Color.AliceBlue;
            this.tpsAdditionalResourceReferenceListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tpsAdditionalResourceReferenceListControl.FormTitle = null;
            this.tpsAdditionalResourceReferenceListControl.HasErrors = false;
            this.tpsAdditionalResourceReferenceListControl.HelpKeyWord = null;
            this.tpsAdditionalResourceReferenceListControl.LastError = null;
            this.tpsAdditionalResourceReferenceListControl.ListName = null;
            this.tpsAdditionalResourceReferenceListControl.Location = new System.Drawing.Point(3, 3);
            this.tpsAdditionalResourceReferenceListControl.Margin = new System.Windows.Forms.Padding(0);
            this.tpsAdditionalResourceReferenceListControl.Name = "tpsAdditionalResourceReferenceListControl";
            this.tpsAdditionalResourceReferenceListControl.SchemaTypeName = null;
            this.tpsAdditionalResourceReferenceListControl.ShowFind = false;
            this.tpsAdditionalResourceReferenceListControl.Size = new System.Drawing.Size(237, 295);
            this.tpsAdditionalResourceReferenceListControl.TabIndex = 0;
            this.tpsAdditionalResourceReferenceListControl.TargetNamespace = null;
            this.tpsAdditionalResourceReferenceListControl.TooltipTextAddButton = "Press to add a new ";
            this.tpsAdditionalResourceReferenceListControl.TooltipTextDeleteButton = "Press to delete the selected ";
            this.tpsAdditionalResourceReferenceListControl.TooltipTextEditButton = "Press to edit the selected ";
            // 
            // TestConfigurationControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMargin = new System.Drawing.Size(10, 10);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.btnCreateUUID);
            this.Controls.Add(this.securityClassificationControl);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.edtUUID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tsTestConfiguration);
            this.Name = "TestConfigurationControl";
            this.Size = new System.Drawing.Size(255, 421);
            this.tsTestConfiguration.ResumeLayout(false);
            this.tsTestConfiguration.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabManager.ResumeLayout(false);
            this.tabUUTs.ResumeLayout(false);
            this.tabTestStations.ResumeLayout(false);
            this.tabTPS.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabHardware.ResumeLayout(false);
            this.tabTPSSoftware.ResumeLayout(false);
            this.tabDocumentation.ResumeLayout(false);
            this.tabAdtlSoftware.ResumeLayout(false);
            this.tabAdtlResources.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsTestConfiguration;
        private ATMLCommonLibrary.controls.awb.AWBTextBox edtUUID;
        private ATMLCommonLibrary.controls.HelpLabel label4;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabUUTs;
        private System.Windows.Forms.ToolStripButton btnSaveConfiguration;
        private System.Windows.Forms.ToolStripButton btnUndo;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.TabPage tabManager;
        private ATMLCommonLibrary.controls.lists.ATMLListControl uutListControl;
        private System.Windows.Forms.TabPage tabTestStations;
        private System.Windows.Forms.TabPage tabTPS;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabHardware;
        private System.Windows.Forms.TabPage tabTPSSoftware;
        private System.Windows.Forms.TabPage tabDocumentation;
        private System.Windows.Forms.TabPage tabAdtlSoftware;
        private System.Windows.Forms.TabPage tabAdtlResources;
        private ATMLCommonLibrary.controls.manufacturer.ManufacturerControl manufacturerControl1;
        private controls.TestStationReferenceControl testStationReferenceControl;
        private WindowsFormsApplication10.SecurityClassificationControl securityClassificationControl;
        private TpsResourceReferenceListControl tpsResourceReferenceListControl;
        private TpsSoftwareReferenceListControl tpsSoftwareReferenceListControl;
        private TestProgramDocumentationListControl testProgramDocumentationListControl;
        private TpsSoftwareReferenceListControl tpsAdditionalSoftwareReferenceListControl;
        private TpsResourceReferenceListControl tpsAdditionalResourceReferenceListControl;
        private System.Windows.Forms.Button btnCreateUUID;
    }
}