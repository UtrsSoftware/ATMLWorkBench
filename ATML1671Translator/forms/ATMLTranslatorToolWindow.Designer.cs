/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

namespace ATML1671Translator.forms
{
    partial class ATMLTranslatorToolWindow
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ATMLTranslatorToolWindow));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.lblFileName = new System.Windows.Forms.ToolStripLabel();
            this.btnParseSourceDocument = new System.Windows.Forms.ToolStripButton();
            this.btnBuildSignalMap = new System.Windows.Forms.ToolStripButton();
            this.btnTranslateAIXML = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnUndo = new System.Windows.Forms.ToolStripButton();
            this.mainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.configurationSplitContainer = new System.Windows.Forms.SplitContainer();
            this.cmbSourceTypes = new System.Windows.Forms.ComboBox();
            this.helpLabel2 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.gridPanel = new System.Windows.Forms.Panel();
            this.dgBuildList = new System.Windows.Forms.DataGridView();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.btnAddSource = new System.Windows.Forms.ToolStripButton();
            this.btnDeleteSource = new System.Windows.Forms.ToolStripButton();
            this.btnMoveRowDown = new System.Windows.Forms.ToolStripButton();
            this.btnMoveRowUp = new System.Windows.Forms.ToolStripButton();
            this.btnSaveTranslationConfig = new System.Windows.Forms.ToolStripButton();
            this.chkSegmentedSource = new System.Windows.Forms.CheckBox();
            this.helpLabel1 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.dgPropertyInfo = new System.Windows.Forms.DataGridView();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.edtSourceDocument = new ATMLCommonLibrary.controls.awb.AWBEditor();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).BeginInit();
            this.mainSplitContainer.Panel1.SuspendLayout();
            this.mainSplitContainer.Panel2.SuspendLayout();
            this.mainSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.configurationSplitContainer)).BeginInit();
            this.configurationSplitContainer.Panel1.SuspendLayout();
            this.configurationSplitContainer.Panel2.SuspendLayout();
            this.configurationSplitContainer.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gridPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgBuildList)).BeginInit();
            this.toolStrip3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPropertyInfo)).BeginInit();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtSourceDocument)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblFileName,
            this.btnParseSourceDocument,
            this.btnBuildSignalMap,
            this.btnTranslateAIXML,
            this.btnSave,
            this.btnUndo});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(553, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // lblFileName
            // 
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(0, 22);
            // 
            // btnParseSourceDocument
            // 
            this.btnParseSourceDocument.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnParseSourceDocument.Image = ((System.Drawing.Image)(resources.GetObject("btnParseSourceDocument.Image")));
            this.btnParseSourceDocument.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnParseSourceDocument.Name = "btnParseSourceDocument";
            this.btnParseSourceDocument.Size = new System.Drawing.Size(23, 22);
            this.btnParseSourceDocument.Text = "Parse Source Document";
            this.btnParseSourceDocument.Click += new System.EventHandler(this.btnParseSourceDocument_Click);
            // 
            // btnBuildSignalMap
            // 
            this.btnBuildSignalMap.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnBuildSignalMap.Image = ((System.Drawing.Image)(resources.GetObject("btnBuildSignalMap.Image")));
            this.btnBuildSignalMap.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBuildSignalMap.Name = "btnBuildSignalMap";
            this.btnBuildSignalMap.Size = new System.Drawing.Size(23, 22);
            this.btnBuildSignalMap.Text = "Build Signal Map";
            this.btnBuildSignalMap.Click += new System.EventHandler(this.btnBuildSignalMap_Click);
            // 
            // btnTranslateAIXML
            // 
            this.btnTranslateAIXML.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnTranslateAIXML.Image = ((System.Drawing.Image)(resources.GetObject("btnTranslateAIXML.Image")));
            this.btnTranslateAIXML.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTranslateAIXML.Name = "btnTranslateAIXML";
            this.btnTranslateAIXML.Size = new System.Drawing.Size(23, 22);
            this.btnTranslateAIXML.ToolTipText = "Press to translate the project\'s AIXML file to ATML";
            this.btnTranslateAIXML.Click += new System.EventHandler(this.btnTranslateAIXML_Click);
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(23, 22);
            this.btnSave.Text = "Save Translation Configuration";
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUndo.Image = ((System.Drawing.Image)(resources.GetObject("btnUndo.Image")));
            this.btnUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(23, 22);
            this.btnUndo.ToolTipText = "Click to undo changes";
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // mainSplitContainer
            // 
            this.mainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSplitContainer.Location = new System.Drawing.Point(0, 25);
            this.mainSplitContainer.Name = "mainSplitContainer";
            // 
            // mainSplitContainer.Panel1
            // 
            this.mainSplitContainer.Panel1.Controls.Add(this.configurationSplitContainer);
            this.mainSplitContainer.Panel1.Controls.Add(this.toolStrip2);
            // 
            // mainSplitContainer.Panel2
            // 
            this.mainSplitContainer.Panel2.Controls.Add(this.edtSourceDocument);
            this.mainSplitContainer.Size = new System.Drawing.Size(553, 403);
            this.mainSplitContainer.SplitterDistance = 184;
            this.mainSplitContainer.TabIndex = 3;
            // 
            // configurationSplitContainer
            // 
            this.configurationSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.configurationSplitContainer.Location = new System.Drawing.Point(0, 25);
            this.configurationSplitContainer.Name = "configurationSplitContainer";
            this.configurationSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // configurationSplitContainer.Panel1
            // 
            this.configurationSplitContainer.Panel1.Controls.Add(this.cmbSourceTypes);
            this.configurationSplitContainer.Panel1.Controls.Add(this.helpLabel2);
            this.configurationSplitContainer.Panel1.Controls.Add(this.panel1);
            // 
            // configurationSplitContainer.Panel2
            // 
            this.configurationSplitContainer.Panel2.Controls.Add(this.dgPropertyInfo);
            this.configurationSplitContainer.Size = new System.Drawing.Size(184, 378);
            this.configurationSplitContainer.SplitterDistance = 242;
            this.configurationSplitContainer.TabIndex = 2;
            // 
            // cmbSourceTypes
            // 
            this.cmbSourceTypes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSourceTypes.FormattingEnabled = true;
            this.cmbSourceTypes.Location = new System.Drawing.Point(87, 5);
            this.cmbSourceTypes.Name = "cmbSourceTypes";
            this.cmbSourceTypes.Size = new System.Drawing.Size(91, 21);
            this.cmbSourceTypes.TabIndex = 3;
            // 
            // helpLabel2
            // 
            this.helpLabel2.AutoSize = true;
            this.helpLabel2.HelpMessageKey = null;
            this.helpLabel2.Location = new System.Drawing.Point(5, 7);
            this.helpLabel2.Name = "helpLabel2";
            this.helpLabel2.RequiredField = false;
            this.helpLabel2.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel2.Size = new System.Drawing.Size(77, 13);
            this.helpLabel2.TabIndex = 2;
            this.helpLabel2.Text = "Translate From";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.gridPanel);
            this.panel1.Controls.Add(this.chkSegmentedSource);
            this.panel1.Controls.Add(this.helpLabel1);
            this.panel1.Location = new System.Drawing.Point(0, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(184, 210);
            this.panel1.TabIndex = 1;
            // 
            // gridPanel
            // 
            this.gridPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridPanel.Controls.Add(this.dgBuildList);
            this.gridPanel.Controls.Add(this.toolStrip3);
            this.gridPanel.Location = new System.Drawing.Point(13, 30);
            this.gridPanel.Name = "gridPanel";
            this.gridPanel.Size = new System.Drawing.Size(168, 168);
            this.gridPanel.TabIndex = 4;
            // 
            // dgBuildList
            // 
            this.dgBuildList.AllowDrop = true;
            this.dgBuildList.AllowUserToAddRows = false;
            this.dgBuildList.AllowUserToDeleteRows = false;
            this.dgBuildList.AllowUserToResizeRows = false;
            this.dgBuildList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgBuildList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgBuildList.Location = new System.Drawing.Point(0, 0);
            this.dgBuildList.Name = "dgBuildList";
            this.dgBuildList.ReadOnly = true;
            this.dgBuildList.RowHeadersVisible = false;
            this.dgBuildList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgBuildList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgBuildList.Size = new System.Drawing.Size(131, 168);
            this.dgBuildList.TabIndex = 3;
            this.dgBuildList.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgBuildList_DragDrop);
            this.dgBuildList.DragEnter += new System.Windows.Forms.DragEventHandler(this.dgBuildList_DragEnter);
            this.dgBuildList.DragOver += new System.Windows.Forms.DragEventHandler(this.dgBuildList_DragOver);
            // 
            // toolStrip3
            // 
            this.toolStrip3.Dock = System.Windows.Forms.DockStyle.Right;
            this.toolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddSource,
            this.btnDeleteSource,
            this.btnMoveRowDown,
            this.btnMoveRowUp,
            this.btnSaveTranslationConfig});
            this.toolStrip3.Location = new System.Drawing.Point(131, 0);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip3.Size = new System.Drawing.Size(37, 168);
            this.toolStrip3.TabIndex = 0;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // btnAddSource
            // 
            this.btnAddSource.AutoSize = false;
            this.btnAddSource.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddSource.Image = ((System.Drawing.Image)(resources.GetObject("btnAddSource.Image")));
            this.btnAddSource.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAddSource.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddSource.Name = "btnAddSource";
            this.btnAddSource.Size = new System.Drawing.Size(36, 36);
            this.btnAddSource.Text = "Add Source File";
            this.btnAddSource.ToolTipText = "Click to add a new source file to the list.";
            this.btnAddSource.Click += new System.EventHandler(this.btnAddSource_Click);
            // 
            // btnDeleteSource
            // 
            this.btnDeleteSource.AutoSize = false;
            this.btnDeleteSource.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDeleteSource.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteSource.Image")));
            this.btnDeleteSource.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnDeleteSource.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteSource.Name = "btnDeleteSource";
            this.btnDeleteSource.Size = new System.Drawing.Size(36, 36);
            this.btnDeleteSource.Text = "Remove File";
            this.btnDeleteSource.ToolTipText = "Click to remove the selected source file from the list.";
            this.btnDeleteSource.Click += new System.EventHandler(this.btnDeleteSource_Click);
            // 
            // btnMoveRowDown
            // 
            this.btnMoveRowDown.AutoSize = false;
            this.btnMoveRowDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnMoveRowDown.Image = ((System.Drawing.Image)(resources.GetObject("btnMoveRowDown.Image")));
            this.btnMoveRowDown.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnMoveRowDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMoveRowDown.Name = "btnMoveRowDown";
            this.btnMoveRowDown.Size = new System.Drawing.Size(36, 36);
            this.btnMoveRowDown.Text = "Move Row Down";
            this.btnMoveRowDown.ToolTipText = "Click to move the selected row down.";
            this.btnMoveRowDown.Click += new System.EventHandler(this.btnMoveRowDown_Click);
            // 
            // btnMoveRowUp
            // 
            this.btnMoveRowUp.AutoSize = false;
            this.btnMoveRowUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnMoveRowUp.Image = ((System.Drawing.Image)(resources.GetObject("btnMoveRowUp.Image")));
            this.btnMoveRowUp.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnMoveRowUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMoveRowUp.Name = "btnMoveRowUp";
            this.btnMoveRowUp.Size = new System.Drawing.Size(36, 36);
            this.btnMoveRowUp.Text = "Move Row Up";
            this.btnMoveRowUp.ToolTipText = "Click to move the selected row up";
            this.btnMoveRowUp.Click += new System.EventHandler(this.btnMoveRowUp_Click);
            // 
            // btnSaveTranslationConfig
            // 
            this.btnSaveTranslationConfig.AutoSize = false;
            this.btnSaveTranslationConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSaveTranslationConfig.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveTranslationConfig.Image")));
            this.btnSaveTranslationConfig.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSaveTranslationConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveTranslationConfig.Name = "btnSaveTranslationConfig";
            this.btnSaveTranslationConfig.Size = new System.Drawing.Size(36, 36);
            this.btnSaveTranslationConfig.Text = "Save";
            this.btnSaveTranslationConfig.ToolTipText = "Click to save the translation configuration.";
            this.btnSaveTranslationConfig.Click += new System.EventHandler(this.btnSaveTranslationConfig_Click);
            // 
            // chkSegmentedSource
            // 
            this.chkSegmentedSource.AutoSize = true;
            this.chkSegmentedSource.Location = new System.Drawing.Point(13, 8);
            this.chkSegmentedSource.Name = "chkSegmentedSource";
            this.chkSegmentedSource.Size = new System.Drawing.Size(15, 14);
            this.chkSegmentedSource.TabIndex = 3;
            this.chkSegmentedSource.UseVisualStyleBackColor = true;
            this.chkSegmentedSource.CheckedChanged += new System.EventHandler(this.chkSegmentedSource_CheckedChanged);
            // 
            // helpLabel1
            // 
            this.helpLabel1.AutoSize = true;
            this.helpLabel1.HelpMessageKey = "ATMLTranslatorToolWindow.Segmented";
            this.helpLabel1.Location = new System.Drawing.Point(29, 8);
            this.helpLabel1.Name = "helpLabel1";
            this.helpLabel1.RequiredField = false;
            this.helpLabel1.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel1.Size = new System.Drawing.Size(126, 13);
            this.helpLabel1.TabIndex = 1;
            this.helpLabel1.Text = "Segmented Source Code";
            // 
            // dgPropertyInfo
            // 
            this.dgPropertyInfo.AllowUserToAddRows = false;
            this.dgPropertyInfo.AllowUserToDeleteRows = false;
            this.dgPropertyInfo.AllowUserToResizeRows = false;
            this.dgPropertyInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPropertyInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgPropertyInfo.Location = new System.Drawing.Point(0, 0);
            this.dgPropertyInfo.Name = "dgPropertyInfo";
            this.dgPropertyInfo.RowHeadersVisible = false;
            this.dgPropertyInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgPropertyInfo.Size = new System.Drawing.Size(184, 132);
            this.dgPropertyInfo.TabIndex = 0;
            // 
            // toolStrip2
            // 
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(184, 25);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(147, 22);
            this.toolStripLabel1.Text = "Translation Configuration";
            // 
            // edtSourceDocument
            // 
            this.edtSourceDocument.AllowDrop = true;
            this.edtSourceDocument.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtSourceDocument.Location = new System.Drawing.Point(0, 0);
            this.edtSourceDocument.Margins.Margin0.Width = 70;
            this.edtSourceDocument.Name = "edtSourceDocument";
            this.edtSourceDocument.Selection.Mode = ScintillaNET.SelectionMode.Lines;
            this.edtSourceDocument.Size = new System.Drawing.Size(365, 403);
            this.edtSourceDocument.Styles.BraceBad.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.edtSourceDocument.Styles.BraceLight.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.edtSourceDocument.Styles.CallTip.FontName = "Segoe UI\0\0\0\0\0\0\0\0\0\0\0\0";
            this.edtSourceDocument.Styles.ControlChar.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.edtSourceDocument.Styles.Default.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.edtSourceDocument.Styles.IndentGuide.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.edtSourceDocument.Styles.LastPredefined.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.edtSourceDocument.Styles.LineNumber.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.edtSourceDocument.Styles.Max.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.edtSourceDocument.TabIndex = 2;
            this.edtSourceDocument.TextChanged += new System.EventHandler(this.edtSourceDocument_TextChanged);
            this.edtSourceDocument.DragDrop += new System.Windows.Forms.DragEventHandler(this.edtSourceDocument_DragDrop);
            this.edtSourceDocument.DragEnter += new System.Windows.Forms.DragEventHandler(this.edtSourceDocument_DragEnter);
            this.edtSourceDocument.DragOver += new System.Windows.Forms.DragEventHandler(this.edtSourceDocument_DragOver);
            this.edtSourceDocument.DragLeave += new System.EventHandler(this.edtSourceDocument_DragLeave);
            // 
            // ATMLTranslatorToolWindow
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 428);
            this.Controls.Add(this.mainSplitContainer);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HideOnClose = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ATMLTranslatorToolWindow";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockLeftAutoHide;
            this.ShowInTaskbar = false;
            this.Text = "Translator";
            this.Activated += new System.EventHandler(this.ATMLTranslatorToolWindow_Activated);
            this.Deactivate += new System.EventHandler(this.ATMLTranslatorToolWindow_Deactivate);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.ATMLTranslatorToolWindow_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.ATMLTranslatorToolWindow_DragEnter);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.ATMLTranslatorToolWindow_DragOver);
            this.DragLeave += new System.EventHandler(this.ATMLTranslatorToolWindow_DragLeave);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.mainSplitContainer.Panel1.ResumeLayout(false);
            this.mainSplitContainer.Panel1.PerformLayout();
            this.mainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).EndInit();
            this.mainSplitContainer.ResumeLayout(false);
            this.configurationSplitContainer.Panel1.ResumeLayout(false);
            this.configurationSplitContainer.Panel1.PerformLayout();
            this.configurationSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.configurationSplitContainer)).EndInit();
            this.configurationSplitContainer.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gridPanel.ResumeLayout(false);
            this.gridPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgBuildList)).EndInit();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPropertyInfo)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtSourceDocument)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnParseSourceDocument;
        private ATMLCommonLibrary.controls.awb.AWBEditor edtSourceDocument;
        private System.Windows.Forms.ToolStripLabel lblFileName;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnTranslateAIXML;
        private System.Windows.Forms.ToolStripButton btnBuildSignalMap;
        private System.Windows.Forms.SplitContainer mainSplitContainer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private ATMLCommonLibrary.controls.HelpLabel helpLabel1;
        private System.Windows.Forms.CheckBox chkSegmentedSource;
        private System.Windows.Forms.Panel gridPanel;
        private System.Windows.Forms.DataGridView dgBuildList;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton btnAddSource;
        private System.Windows.Forms.ToolStripButton btnDeleteSource;
        private System.Windows.Forms.ToolStripButton btnMoveRowDown;
        private System.Windows.Forms.ToolStripButton btnMoveRowUp;
        private System.Windows.Forms.ToolStripButton btnSaveTranslationConfig;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.SplitContainer configurationSplitContainer;
        private System.Windows.Forms.DataGridView dgPropertyInfo;
        private System.Windows.Forms.ComboBox cmbSourceTypes;
        private ATMLCommonLibrary.controls.HelpLabel helpLabel2;
        private System.Windows.Forms.ToolStripButton btnUndo;
    }
}