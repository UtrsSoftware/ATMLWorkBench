/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls.signal
{
    partial class SignalModelLibraryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignalModelLibraryForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.saveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outerSplitContainer = new System.Windows.Forms.SplitContainer();
            this.label4 = new System.Windows.Forms.Label();
            this.edtTargetNamespace = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbLibraryName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.edtUUID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.edtDescription = new System.Windows.Forms.TextBox();
            this.signalSplitContainer = new System.Windows.Forms.SplitContainer();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.lvSignals = new System.Windows.Forms.ListView();
            this.columnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnUUID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.modelSplitContainer = new System.Windows.Forms.SplitContainer();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.lvModel = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip4 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.lvAttributes = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDefault = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1.SuspendLayout();
            this.menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.outerSplitContainer)).BeginInit();
            this.outerSplitContainer.Panel1.SuspendLayout();
            this.outerSplitContainer.Panel2.SuspendLayout();
            this.outerSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.signalSplitContainer)).BeginInit();
            this.signalSplitContainer.Panel1.SuspendLayout();
            this.signalSplitContainer.Panel2.SuspendLayout();
            this.signalSplitContainer.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.modelSplitContainer)).BeginInit();
            this.modelSplitContainer.Panel1.SuspendLayout();
            this.modelSplitContainer.Panel2.SuspendLayout();
            this.modelSplitContainer.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            this.toolStrip4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.AliceBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.menu);
            this.panel1.Controls.Add(this.outerSplitContainer);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(643, 380);
            this.panel1.TabIndex = 0;
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveMenuItem,
            this.importMenuItem,
            this.exportMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(639, 24);
            this.menu.TabIndex = 13;
            this.menu.Text = "menuStrip1";
            // 
            // saveMenuItem
            // 
            this.saveMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveMenuItem.Image")));
            this.saveMenuItem.Name = "saveMenuItem";
            this.saveMenuItem.Size = new System.Drawing.Size(59, 20);
            this.saveMenuItem.Text = "Save";
            this.saveMenuItem.Click += new System.EventHandler(this.btnSaveSignal_Click);
            // 
            // importMenuItem
            // 
            this.importMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("importMenuItem.Image")));
            this.importMenuItem.Name = "importMenuItem";
            this.importMenuItem.Size = new System.Drawing.Size(71, 20);
            this.importMenuItem.Text = "Import";
            this.importMenuItem.Click += new System.EventHandler(this.btnImportTSF_Click);
            // 
            // exportMenuItem
            // 
            this.exportMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exportMenuItem.Image")));
            this.exportMenuItem.Name = "exportMenuItem";
            this.exportMenuItem.Size = new System.Drawing.Size(68, 20);
            this.exportMenuItem.Text = "Export";
            this.exportMenuItem.Click += new System.EventHandler(this.btnExportTSF_Click);
            // 
            // outerSplitContainer
            // 
            this.outerSplitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outerSplitContainer.Location = new System.Drawing.Point(0, 27);
            this.outerSplitContainer.Name = "outerSplitContainer";
            this.outerSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // outerSplitContainer.Panel1
            // 
            this.outerSplitContainer.Panel1.Controls.Add(this.label4);
            this.outerSplitContainer.Panel1.Controls.Add(this.edtTargetNamespace);
            this.outerSplitContainer.Panel1.Controls.Add(this.label3);
            this.outerSplitContainer.Panel1.Controls.Add(this.cmbLibraryName);
            this.outerSplitContainer.Panel1.Controls.Add(this.label1);
            this.outerSplitContainer.Panel1.Controls.Add(this.edtUUID);
            this.outerSplitContainer.Panel1.Controls.Add(this.label2);
            this.outerSplitContainer.Panel1.Controls.Add(this.edtDescription);
            this.outerSplitContainer.Panel1MinSize = 140;
            // 
            // outerSplitContainer.Panel2
            // 
            this.outerSplitContainer.Panel2.Controls.Add(this.signalSplitContainer);
            this.outerSplitContainer.Size = new System.Drawing.Size(642, 349);
            this.outerSplitContainer.SplitterDistance = 140;
            this.outerSplitContainer.SplitterWidth = 8;
            this.outerSplitContainer.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Target Namespace";
            // 
            // edtTargetNamespace
            // 
            this.edtTargetNamespace.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtTargetNamespace.BackColor = System.Drawing.Color.Honeydew;
            this.edtTargetNamespace.Location = new System.Drawing.Point(117, 66);
            this.edtTargetNamespace.Name = "edtTargetNamespace";
            this.edtTargetNamespace.ReadOnly = true;
            this.edtTargetNamespace.Size = new System.Drawing.Size(504, 20);
            this.edtTargetNamespace.TabIndex = 13;
            this.edtTargetNamespace.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(77, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "UUID";
            // 
            // cmbLibraryName
            // 
            this.cmbLibraryName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbLibraryName.BackColor = System.Drawing.Color.Honeydew;
            this.cmbLibraryName.FormattingEnabled = true;
            this.cmbLibraryName.Location = new System.Drawing.Point(117, 14);
            this.cmbLibraryName.Name = "cmbLibraryName";
            this.cmbLibraryName.Size = new System.Drawing.Size(504, 21);
            this.cmbLibraryName.TabIndex = 11;
            this.cmbLibraryName.SelectedIndexChanged += new System.EventHandler(this.cmbLibraryName_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Library Name";
            // 
            // edtUUID
            // 
            this.edtUUID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtUUID.BackColor = System.Drawing.Color.Honeydew;
            this.edtUUID.Location = new System.Drawing.Point(117, 40);
            this.edtUUID.Name = "edtUUID";
            this.edtUUID.ReadOnly = true;
            this.edtUUID.Size = new System.Drawing.Size(504, 20);
            this.edtUUID.TabIndex = 1;
            this.edtUUID.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Description";
            // 
            // edtDescription
            // 
            this.edtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtDescription.Location = new System.Drawing.Point(117, 93);
            this.edtDescription.MinimumSize = new System.Drawing.Size(500, 36);
            this.edtDescription.Multiline = true;
            this.edtDescription.Name = "edtDescription";
            this.edtDescription.Size = new System.Drawing.Size(504, 36);
            this.edtDescription.TabIndex = 3;
            // 
            // signalSplitContainer
            // 
            this.signalSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.signalSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.signalSplitContainer.Name = "signalSplitContainer";
            // 
            // signalSplitContainer.Panel1
            // 
            this.signalSplitContainer.Panel1.Controls.Add(this.toolStrip2);
            this.signalSplitContainer.Panel1.Controls.Add(this.lvSignals);
            // 
            // signalSplitContainer.Panel2
            // 
            this.signalSplitContainer.Panel2.Controls.Add(this.modelSplitContainer);
            this.signalSplitContainer.Size = new System.Drawing.Size(642, 201);
            this.signalSplitContainer.SplitterDistance = 214;
            this.signalSplitContainer.TabIndex = 0;
            // 
            // toolStrip2
            // 
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip2.Size = new System.Drawing.Size(214, 25);
            this.toolStrip2.TabIndex = 6;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(44, 22);
            this.toolStripLabel1.Text = "Signals";
            // 
            // lvSignals
            // 
            this.lvSignals.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvSignals.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnName,
            this.columnUUID});
            this.lvSignals.FullRowSelect = true;
            this.lvSignals.HideSelection = false;
            this.lvSignals.Location = new System.Drawing.Point(0, 25);
            this.lvSignals.Margin = new System.Windows.Forms.Padding(0);
            this.lvSignals.Name = "lvSignals";
            this.lvSignals.Size = new System.Drawing.Size(214, 176);
            this.lvSignals.TabIndex = 5;
            this.lvSignals.UseCompatibleStateImageBehavior = false;
            this.lvSignals.View = System.Windows.Forms.View.Details;
            this.lvSignals.SelectedIndexChanged += new System.EventHandler(this.lvSignals_SelectedIndexChanged);
            this.lvSignals.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lvSignals_MouseDown);
            // 
            // columnName
            // 
            this.columnName.Text = "Name";
            this.columnName.Width = 126;
            // 
            // columnUUID
            // 
            this.columnUUID.Text = "UUID";
            this.columnUUID.Width = 327;
            // 
            // modelSplitContainer
            // 
            this.modelSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.modelSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.modelSplitContainer.Name = "modelSplitContainer";
            this.modelSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // modelSplitContainer.Panel1
            // 
            this.modelSplitContainer.Panel1.Controls.Add(this.toolStrip3);
            this.modelSplitContainer.Panel1.Controls.Add(this.lvModel);
            // 
            // modelSplitContainer.Panel2
            // 
            this.modelSplitContainer.Panel2.Controls.Add(this.toolStrip4);
            this.modelSplitContainer.Panel2.Controls.Add(this.lvAttributes);
            this.modelSplitContainer.Size = new System.Drawing.Size(424, 201);
            this.modelSplitContainer.SplitterDistance = 92;
            this.modelSplitContainer.TabIndex = 0;
            // 
            // toolStrip3
            // 
            this.toolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2});
            this.toolStrip3.Location = new System.Drawing.Point(0, 0);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip3.Size = new System.Drawing.Size(424, 25);
            this.toolStrip3.TabIndex = 10;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(104, 22);
            this.toolStripLabel2.Text = "Model Description";
            // 
            // lvModel
            // 
            this.lvModel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvModel.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvModel.FullRowSelect = true;
            this.lvModel.Location = new System.Drawing.Point(0, 27);
            this.lvModel.Margin = new System.Windows.Forms.Padding(0);
            this.lvModel.Name = "lvModel";
            this.lvModel.Size = new System.Drawing.Size(425, 67);
            this.lvModel.TabIndex = 8;
            this.lvModel.UseCompatibleStateImageBehavior = false;
            this.lvModel.View = System.Windows.Forms.View.Details;
            this.lvModel.SelectedIndexChanged += new System.EventHandler(this.lvModel_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Class";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Type";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "In";
            // 
            // toolStrip4
            // 
            this.toolStrip4.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel3});
            this.toolStrip4.Location = new System.Drawing.Point(0, 0);
            this.toolStrip4.Name = "toolStrip4";
            this.toolStrip4.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip4.Size = new System.Drawing.Size(424, 25);
            this.toolStrip4.TabIndex = 11;
            this.toolStrip4.Text = "toolStrip4";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(105, 22);
            this.toolStripLabel3.Text = "Interface Poperties";
            // 
            // lvAttributes
            // 
            this.lvAttributes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvAttributes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colType,
            this.colDefault});
            this.lvAttributes.FullRowSelect = true;
            this.lvAttributes.Location = new System.Drawing.Point(0, 25);
            this.lvAttributes.Margin = new System.Windows.Forms.Padding(0);
            this.lvAttributes.Name = "lvAttributes";
            this.lvAttributes.Size = new System.Drawing.Size(425, 84);
            this.lvAttributes.TabIndex = 6;
            this.lvAttributes.UseCompatibleStateImageBehavior = false;
            this.lvAttributes.View = System.Windows.Forms.View.Details;
            this.lvAttributes.SelectedIndexChanged += new System.EventHandler(this.lvAttributes_SelectedIndexChanged);
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 100;
            // 
            // colType
            // 
            this.colType.Text = "Type";
            // 
            // colDefault
            // 
            this.colDefault.Text = "Default";
            // 
            // SignalModelLibraryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(643, 380);
            this.CloseButton = false;
            this.CloseButtonVisible = false;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "SignalModelLibraryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Signal Model Library";
            this.Load += new System.EventHandler(this.SignalModelLibraryForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.outerSplitContainer.Panel1.ResumeLayout(false);
            this.outerSplitContainer.Panel1.PerformLayout();
            this.outerSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.outerSplitContainer)).EndInit();
            this.outerSplitContainer.ResumeLayout(false);
            this.signalSplitContainer.Panel1.ResumeLayout(false);
            this.signalSplitContainer.Panel1.PerformLayout();
            this.signalSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.signalSplitContainer)).EndInit();
            this.signalSplitContainer.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.modelSplitContainer.Panel1.ResumeLayout(false);
            this.modelSplitContainer.Panel1.PerformLayout();
            this.modelSplitContainer.Panel2.ResumeLayout(false);
            this.modelSplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.modelSplitContainer)).EndInit();
            this.modelSplitContainer.ResumeLayout(false);
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.toolStrip4.ResumeLayout(false);
            this.toolStrip4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView lvSignals;
        private System.Windows.Forms.ColumnHeader columnName;
        private System.Windows.Forms.ColumnHeader columnUUID;
        private System.Windows.Forms.TextBox edtDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox edtUUID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lvAttributes;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colType;
        private System.Windows.Forms.ColumnHeader colDefault;
        private System.Windows.Forms.ListView lvModel;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.SplitContainer outerSplitContainer;
        private System.Windows.Forms.SplitContainer signalSplitContainer;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.SplitContainer modelSplitContainer;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStrip toolStrip4;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbLibraryName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox edtTargetNamespace;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem saveMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportMenuItem;
    }
}