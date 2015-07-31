/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using ATMLCommonLibrary.controls.document;

namespace ATMLCommonLibrary.controls.specification
{
    partial class SpecificationControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpecificationControl));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabSpecifications = new System.Windows.Forms.TabControl();
            this.tabDefinition = new System.Windows.Forms.TabPage();
            this.rbNone = new System.Windows.Forms.RadioButton();
            this.rbText = new System.Windows.Forms.RadioButton();
            this.rbDocument = new System.Windows.Forms.RadioButton();
            this.edtDefinitionText = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.documentControl = new DocumentControl();
            this.tabConditions = new System.Windows.Forms.TabPage();
            this.tsConditions = new System.Windows.Forms.ToolStrip();
            this.btnConditionsAdd = new System.Windows.Forms.ToolStripButton();
            this.btnConditionsEdit = new System.Windows.Forms.ToolStripButton();
            this.btnConditionsDelete = new System.Windows.Forms.ToolStripButton();
            this.dgConditions = new System.Windows.Forms.DataGridView();
            this.condition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lvConditions = new System.Windows.Forms.ListView();
            this.tabLimits = new System.Windows.Forms.TabPage();
            this.limitListControl = new ATMLCommonLibrary.controls.lists.ATMLListControl();
            this.tabSupplimentalInfo = new System.Windows.Forms.TabPage();
            this.lvSupplimentalInfo = new System.Windows.Forms.ListView();
            this.tabRequiredOptions = new System.Windows.Forms.TabPage();
            this.dgRequiredOptions = new System.Windows.Forms.DataGridView();
            this.requiredOption = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsRequiredOptions = new System.Windows.Forms.ToolStrip();
            this.btnReqOptionAdd = new System.Windows.Forms.ToolStripButton();
            this.btnReqOptionEdit = new System.Windows.Forms.ToolStripButton();
            this.btnReqOptionDelete = new System.Windows.Forms.ToolStripButton();
            this.lvRequiredOprions = new System.Windows.Forms.ListView();
            this.tabExclusiveOptions = new System.Windows.Forms.TabPage();
            this.dgExclusiveOptions = new System.Windows.Forms.DataGridView();
            this.exclusiveOption = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsExclusiveOptions = new System.Windows.Forms.ToolStrip();
            this.btnExcOptionAdd = new System.Windows.Forms.ToolStripButton();
            this.btnExcOptionEdit = new System.Windows.Forms.ToolStripButton();
            this.btnExcOptionDelete = new System.Windows.Forms.ToolStripButton();
            this.tabGraph = new System.Windows.Forms.TabPage();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.edtSpecDescription = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.edtSpecName = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.requiredNameFieldValidator = new ATMLCommonLibrary.controls.validators.RequiredFieldValidator();
            this.requiredDescriptionFieldValidator = new ATMLCommonLibrary.controls.validators.RequiredFieldValidator();
            this.requiredDefinitionTextValidator = new ATMLCommonLibrary.controls.validators.RequiredFieldValidator();
            this.lbloName = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.helpLabel2 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.btnSuppInfoAdd = new System.Windows.Forms.ToolStripButton();
            this.btnSuppInfoEdit = new System.Windows.Forms.ToolStripButton();
            this.btnSuppInfoDelete = new System.Windows.Forms.ToolStripButton();
            this.tsSupplimental = new System.Windows.Forms.ToolStrip();
            this.information = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgSupplimentalInfo = new System.Windows.Forms.DataGridView();
            this.tabSpecifications.SuspendLayout();
            this.tabDefinition.SuspendLayout();
            this.tabConditions.SuspendLayout();
            this.tsConditions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgConditions)).BeginInit();
            this.tabLimits.SuspendLayout();
            this.tabSupplimentalInfo.SuspendLayout();
            this.tabRequiredOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRequiredOptions)).BeginInit();
            this.tsRequiredOptions.SuspendLayout();
            this.tabExclusiveOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgExclusiveOptions)).BeginInit();
            this.tsExclusiveOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.tsSupplimental.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSupplimentalInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // tabSpecifications
            // 
            this.tabSpecifications.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabSpecifications.Controls.Add(this.tabDefinition);
            this.tabSpecifications.Controls.Add(this.tabConditions);
            this.tabSpecifications.Controls.Add(this.tabLimits);
            this.tabSpecifications.Controls.Add(this.tabSupplimentalInfo);
            this.tabSpecifications.Controls.Add(this.tabRequiredOptions);
            this.tabSpecifications.Controls.Add(this.tabExclusiveOptions);
            this.tabSpecifications.Controls.Add(this.tabGraph);
            this.tabSpecifications.Location = new System.Drawing.Point(11, 96);
            this.tabSpecifications.Name = "tabSpecifications";
            this.tabSpecifications.SelectedIndex = 0;
            this.tabSpecifications.Size = new System.Drawing.Size(575, 276);
            this.tabSpecifications.TabIndex = 4;
            this.tabSpecifications.SelectedIndexChanged += new System.EventHandler(this.tabSpecifications_SelectedIndexChanged);
            // 
            // tabDefinition
            // 
            this.tabDefinition.BackColor = System.Drawing.Color.AliceBlue;
            this.tabDefinition.Controls.Add(this.rbNone);
            this.tabDefinition.Controls.Add(this.rbText);
            this.tabDefinition.Controls.Add(this.rbDocument);
            this.tabDefinition.Controls.Add(this.edtDefinitionText);
            this.tabDefinition.Controls.Add(this.documentControl);
            this.tabDefinition.Location = new System.Drawing.Point(4, 22);
            this.tabDefinition.Name = "tabDefinition";
            this.tabDefinition.Padding = new System.Windows.Forms.Padding(3);
            this.tabDefinition.Size = new System.Drawing.Size(567, 250);
            this.tabDefinition.TabIndex = 0;
            this.tabDefinition.Text = "Definition";
            // 
            // rbNone
            // 
            this.rbNone.AutoSize = true;
            this.rbNone.Checked = true;
            this.rbNone.Location = new System.Drawing.Point(7, 7);
            this.rbNone.Name = "rbNone";
            this.rbNone.Size = new System.Drawing.Size(51, 17);
            this.rbNone.TabIndex = 0;
            this.rbNone.TabStop = true;
            this.rbNone.Text = "None";
            this.rbNone.UseVisualStyleBackColor = true;
            this.rbNone.CheckedChanged += new System.EventHandler(this.rbNone_CheckedChanged);
            // 
            // rbText
            // 
            this.rbText.AutoSize = true;
            this.rbText.Location = new System.Drawing.Point(69, 7);
            this.rbText.Name = "rbText";
            this.rbText.Size = new System.Drawing.Size(46, 17);
            this.rbText.TabIndex = 1;
            this.rbText.Text = "Text";
            this.rbText.UseVisualStyleBackColor = true;
            this.rbText.CheckedChanged += new System.EventHandler(this.rbText_CheckedChanged);
            // 
            // rbDocument
            // 
            this.rbDocument.AutoSize = true;
            this.rbDocument.Location = new System.Drawing.Point(126, 7);
            this.rbDocument.Name = "rbDocument";
            this.rbDocument.Size = new System.Drawing.Size(74, 17);
            this.rbDocument.TabIndex = 2;
            this.rbDocument.Text = "Document";
            this.rbDocument.UseVisualStyleBackColor = true;
            this.rbDocument.CheckedChanged += new System.EventHandler(this.rbDocument_CheckedChanged);
            // 
            // edtDefinitionText
            // 
            this.edtDefinitionText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtDefinitionText.AttributeName = null;
            this.edtDefinitionText.Location = new System.Drawing.Point(7, 30);
            this.edtDefinitionText.Multiline = true;
            this.edtDefinitionText.Name = "edtDefinitionText";
            this.edtDefinitionText.Size = new System.Drawing.Size(533, 215);
            this.edtDefinitionText.TabIndex = 2;
            this.edtDefinitionText.Value = null;
            this.edtDefinitionText.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // documentControl
            // 
            this.documentControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.documentControl.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.documentControl.BackColor = System.Drawing.Color.Transparent;
            this.documentControl.Location = new System.Drawing.Point(7, 29);
            this.documentControl.Name = "documentControl";
            this.documentControl.Size = new System.Drawing.Size(554, 215);
            this.documentControl.TabIndex = 3;
            this.documentControl.ValidationEnabled = true;
            // 
            // tabConditions
            // 
            this.tabConditions.BackColor = System.Drawing.Color.Transparent;
            this.tabConditions.Controls.Add(this.tsConditions);
            this.tabConditions.Controls.Add(this.dgConditions);
            this.tabConditions.Controls.Add(this.lvConditions);
            this.tabConditions.Location = new System.Drawing.Point(4, 22);
            this.tabConditions.Name = "tabConditions";
            this.tabConditions.Size = new System.Drawing.Size(567, 250);
            this.tabConditions.TabIndex = 1;
            this.tabConditions.Text = "Conditions";
            // 
            // tsConditions
            // 
            this.tsConditions.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tsConditions.Dock = System.Windows.Forms.DockStyle.Right;
            this.tsConditions.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsConditions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnConditionsAdd,
            this.btnConditionsEdit,
            this.btnConditionsDelete});
            this.tsConditions.Location = new System.Drawing.Point(543, 0);
            this.tsConditions.Name = "tsConditions";
            this.tsConditions.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tsConditions.Size = new System.Drawing.Size(24, 250);
            this.tsConditions.TabIndex = 35;
            this.tsConditions.Text = "toolStrip1";
            // 
            // btnConditionsAdd
            // 
            this.btnConditionsAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnConditionsAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnConditionsAdd.Image")));
            this.btnConditionsAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnConditionsAdd.Name = "btnConditionsAdd";
            this.btnConditionsAdd.Size = new System.Drawing.Size(21, 20);
            this.btnConditionsAdd.Text = "Add Condition";
            this.btnConditionsAdd.ToolTipText = "Press to add a new Condition.";
            this.btnConditionsAdd.Click += new System.EventHandler(this.btnConditionsAdd_Click);
            // 
            // btnConditionsEdit
            // 
            this.btnConditionsEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnConditionsEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnConditionsEdit.Image")));
            this.btnConditionsEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnConditionsEdit.Name = "btnConditionsEdit";
            this.btnConditionsEdit.Size = new System.Drawing.Size(21, 20);
            this.btnConditionsEdit.Text = "Edit Condition";
            this.btnConditionsEdit.ToolTipText = "Press to edit the selected Condition.";
            this.btnConditionsEdit.Click += new System.EventHandler(this.btnConditionsEdit_Click);
            // 
            // btnConditionsDelete
            // 
            this.btnConditionsDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnConditionsDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnConditionsDelete.Image")));
            this.btnConditionsDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnConditionsDelete.Name = "btnConditionsDelete";
            this.btnConditionsDelete.Size = new System.Drawing.Size(21, 20);
            this.btnConditionsDelete.Text = "Delete Condition";
            this.btnConditionsDelete.ToolTipText = "Press to delete the selected Condition.";
            this.btnConditionsDelete.Click += new System.EventHandler(this.btnConditionsDelete_Click);
            // 
            // dgConditions
            // 
            this.dgConditions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgConditions.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgConditions.BackgroundColor = System.Drawing.Color.SteelBlue;
            this.dgConditions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgConditions.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgConditions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgConditions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgConditions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.condition});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgConditions.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgConditions.Location = new System.Drawing.Point(0, 0);
            this.dgConditions.Margin = new System.Windows.Forms.Padding(0);
            this.dgConditions.Name = "dgConditions";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgConditions.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgConditions.RowHeadersVisible = false;
            this.dgConditions.Size = new System.Drawing.Size(543, 223);
            this.dgConditions.TabIndex = 34;
            // 
            // condition
            // 
            this.condition.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.condition.DefaultCellStyle = dataGridViewCellStyle2;
            this.condition.HeaderText = "Condition Name";
            this.condition.Name = "condition";
            // 
            // lvConditions
            // 
            this.lvConditions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvConditions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvConditions.Location = new System.Drawing.Point(1, 1);
            this.lvConditions.Margin = new System.Windows.Forms.Padding(0);
            this.lvConditions.Name = "lvConditions";
            this.lvConditions.Size = new System.Drawing.Size(542, 222);
            this.lvConditions.TabIndex = 0;
            this.lvConditions.UseCompatibleStateImageBehavior = false;
            this.lvConditions.View = System.Windows.Forms.View.Details;
            // 
            // tabLimits
            // 
            this.tabLimits.Controls.Add(this.limitListControl);
            this.tabLimits.Location = new System.Drawing.Point(4, 22);
            this.tabLimits.Margin = new System.Windows.Forms.Padding(0);
            this.tabLimits.Name = "tabLimits";
            this.tabLimits.Size = new System.Drawing.Size(567, 250);
            this.tabLimits.TabIndex = 2;
            this.tabLimits.Text = "Limits";
            this.tabLimits.UseVisualStyleBackColor = true;
            // 
            // limitListControl
            // 
            this.limitListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.limitListControl.ListName = null;
            this.limitListControl.Location = new System.Drawing.Point(0, 0);
            this.limitListControl.Margin = new System.Windows.Forms.Padding(0);
            this.limitListControl.Name = "limitListControl";
            this.limitListControl.SchemaTypeName = null;
            this.limitListControl.ShowFind = false;
            this.limitListControl.Size = new System.Drawing.Size(567, 250);
            this.limitListControl.TabIndex = 0;
            this.limitListControl.TargetNamespace = null;
            // 
            // tabSupplimentalInfo
            // 
            this.tabSupplimentalInfo.Controls.Add(this.dgSupplimentalInfo);
            this.tabSupplimentalInfo.Controls.Add(this.tsSupplimental);
            this.tabSupplimentalInfo.Controls.Add(this.lvSupplimentalInfo);
            this.tabSupplimentalInfo.Location = new System.Drawing.Point(4, 22);
            this.tabSupplimentalInfo.Margin = new System.Windows.Forms.Padding(0);
            this.tabSupplimentalInfo.Name = "tabSupplimentalInfo";
            this.tabSupplimentalInfo.Size = new System.Drawing.Size(567, 250);
            this.tabSupplimentalInfo.TabIndex = 3;
            this.tabSupplimentalInfo.Text = "Supplimental Info";
            this.tabSupplimentalInfo.UseVisualStyleBackColor = true;
            // 
            // lvSupplimentalInfo
            // 
            this.lvSupplimentalInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvSupplimentalInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvSupplimentalInfo.Location = new System.Drawing.Point(-3, -3);
            this.lvSupplimentalInfo.Margin = new System.Windows.Forms.Padding(0);
            this.lvSupplimentalInfo.Name = "lvSupplimentalInfo";
            this.lvSupplimentalInfo.Size = new System.Drawing.Size(546, 227);
            this.lvSupplimentalInfo.TabIndex = 1;
            this.lvSupplimentalInfo.UseCompatibleStateImageBehavior = false;
            this.lvSupplimentalInfo.View = System.Windows.Forms.View.Details;
            // 
            // tabRequiredOptions
            // 
            this.tabRequiredOptions.Controls.Add(this.dgRequiredOptions);
            this.tabRequiredOptions.Controls.Add(this.tsRequiredOptions);
            this.tabRequiredOptions.Controls.Add(this.lvRequiredOprions);
            this.tabRequiredOptions.Location = new System.Drawing.Point(4, 22);
            this.tabRequiredOptions.Margin = new System.Windows.Forms.Padding(0);
            this.tabRequiredOptions.Name = "tabRequiredOptions";
            this.tabRequiredOptions.Size = new System.Drawing.Size(567, 250);
            this.tabRequiredOptions.TabIndex = 4;
            this.tabRequiredOptions.Text = "Required Options";
            this.tabRequiredOptions.UseVisualStyleBackColor = true;
            // 
            // dgRequiredOptions
            // 
            this.dgRequiredOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgRequiredOptions.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgRequiredOptions.BackgroundColor = System.Drawing.Color.SteelBlue;
            this.dgRequiredOptions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgRequiredOptions.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgRequiredOptions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgRequiredOptions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRequiredOptions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.requiredOption});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgRequiredOptions.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgRequiredOptions.Location = new System.Drawing.Point(0, 0);
            this.dgRequiredOptions.Margin = new System.Windows.Forms.Padding(0);
            this.dgRequiredOptions.Name = "dgRequiredOptions";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgRequiredOptions.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgRequiredOptions.RowHeadersVisible = false;
            this.dgRequiredOptions.Size = new System.Drawing.Size(543, 224);
            this.dgRequiredOptions.TabIndex = 34;
            // 
            // requiredOption
            // 
            this.requiredOption.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.requiredOption.DefaultCellStyle = dataGridViewCellStyle10;
            this.requiredOption.HeaderText = "Required Option Name";
            this.requiredOption.Name = "requiredOption";
            // 
            // tsRequiredOptions
            // 
            this.tsRequiredOptions.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tsRequiredOptions.Dock = System.Windows.Forms.DockStyle.Right;
            this.tsRequiredOptions.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsRequiredOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnReqOptionAdd,
            this.btnReqOptionEdit,
            this.btnReqOptionDelete});
            this.tsRequiredOptions.Location = new System.Drawing.Point(543, 0);
            this.tsRequiredOptions.Name = "tsRequiredOptions";
            this.tsRequiredOptions.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tsRequiredOptions.Size = new System.Drawing.Size(24, 250);
            this.tsRequiredOptions.TabIndex = 2;
            this.tsRequiredOptions.Text = "toolStrip5";
            // 
            // btnReqOptionAdd
            // 
            this.btnReqOptionAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnReqOptionAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnReqOptionAdd.Image")));
            this.btnReqOptionAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReqOptionAdd.Name = "btnReqOptionAdd";
            this.btnReqOptionAdd.Size = new System.Drawing.Size(21, 20);
            this.btnReqOptionAdd.Text = "Add";
            this.btnReqOptionAdd.ToolTipText = "Press to add a new ";
            this.btnReqOptionAdd.Click += new System.EventHandler(this.btnReqOptionAdd_Click);
            // 
            // btnReqOptionEdit
            // 
            this.btnReqOptionEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnReqOptionEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnReqOptionEdit.Image")));
            this.btnReqOptionEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReqOptionEdit.Name = "btnReqOptionEdit";
            this.btnReqOptionEdit.Size = new System.Drawing.Size(21, 20);
            this.btnReqOptionEdit.Text = "Edit";
            this.btnReqOptionEdit.ToolTipText = "Press to edit the selected ";
            this.btnReqOptionEdit.Click += new System.EventHandler(this.btnReqOptionEdit_Click);
            // 
            // btnReqOptionDelete
            // 
            this.btnReqOptionDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnReqOptionDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnReqOptionDelete.Image")));
            this.btnReqOptionDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReqOptionDelete.Name = "btnReqOptionDelete";
            this.btnReqOptionDelete.Size = new System.Drawing.Size(21, 20);
            this.btnReqOptionDelete.Text = "Delete";
            this.btnReqOptionDelete.ToolTipText = "Press to delete the selected ";
            this.btnReqOptionDelete.Click += new System.EventHandler(this.btnReqOptionDelete_Click);
            // 
            // lvRequiredOprions
            // 
            this.lvRequiredOprions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvRequiredOprions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvRequiredOprions.Location = new System.Drawing.Point(-3, -3);
            this.lvRequiredOprions.Margin = new System.Windows.Forms.Padding(0);
            this.lvRequiredOprions.Name = "lvRequiredOprions";
            this.lvRequiredOprions.Size = new System.Drawing.Size(546, 227);
            this.lvRequiredOprions.TabIndex = 1;
            this.lvRequiredOprions.UseCompatibleStateImageBehavior = false;
            this.lvRequiredOprions.View = System.Windows.Forms.View.Details;
            // 
            // tabExclusiveOptions
            // 
            this.tabExclusiveOptions.Controls.Add(this.dgExclusiveOptions);
            this.tabExclusiveOptions.Controls.Add(this.tsExclusiveOptions);
            this.tabExclusiveOptions.Location = new System.Drawing.Point(4, 22);
            this.tabExclusiveOptions.Margin = new System.Windows.Forms.Padding(0);
            this.tabExclusiveOptions.Name = "tabExclusiveOptions";
            this.tabExclusiveOptions.Size = new System.Drawing.Size(567, 250);
            this.tabExclusiveOptions.TabIndex = 5;
            this.tabExclusiveOptions.Text = "Exclusive Options";
            this.tabExclusiveOptions.UseVisualStyleBackColor = true;
            // 
            // dgExclusiveOptions
            // 
            this.dgExclusiveOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgExclusiveOptions.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgExclusiveOptions.BackgroundColor = System.Drawing.Color.SteelBlue;
            this.dgExclusiveOptions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgExclusiveOptions.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgExclusiveOptions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dgExclusiveOptions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgExclusiveOptions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.exclusiveOption});
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgExclusiveOptions.DefaultCellStyle = dataGridViewCellStyle15;
            this.dgExclusiveOptions.Location = new System.Drawing.Point(0, 0);
            this.dgExclusiveOptions.Margin = new System.Windows.Forms.Padding(0);
            this.dgExclusiveOptions.Name = "dgExclusiveOptions";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgExclusiveOptions.RowHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.dgExclusiveOptions.RowHeadersVisible = false;
            this.dgExclusiveOptions.Size = new System.Drawing.Size(543, 224);
            this.dgExclusiveOptions.TabIndex = 34;
            // 
            // exclusiveOption
            // 
            this.exclusiveOption.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.exclusiveOption.DefaultCellStyle = dataGridViewCellStyle14;
            this.exclusiveOption.HeaderText = "Exclusive Option Name";
            this.exclusiveOption.Name = "exclusiveOption";
            // 
            // tsExclusiveOptions
            // 
            this.tsExclusiveOptions.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tsExclusiveOptions.Dock = System.Windows.Forms.DockStyle.Right;
            this.tsExclusiveOptions.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsExclusiveOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnExcOptionAdd,
            this.btnExcOptionEdit,
            this.btnExcOptionDelete});
            this.tsExclusiveOptions.Location = new System.Drawing.Point(543, 0);
            this.tsExclusiveOptions.Name = "tsExclusiveOptions";
            this.tsExclusiveOptions.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tsExclusiveOptions.Size = new System.Drawing.Size(24, 250);
            this.tsExclusiveOptions.TabIndex = 2;
            this.tsExclusiveOptions.Text = "toolStrip2";
            // 
            // btnExcOptionAdd
            // 
            this.btnExcOptionAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnExcOptionAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnExcOptionAdd.Image")));
            this.btnExcOptionAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExcOptionAdd.Name = "btnExcOptionAdd";
            this.btnExcOptionAdd.Size = new System.Drawing.Size(21, 20);
            this.btnExcOptionAdd.Text = "Add";
            this.btnExcOptionAdd.ToolTipText = "Press to add a new ";
            this.btnExcOptionAdd.Click += new System.EventHandler(this.btnExcOptionAdd_Click);
            // 
            // btnExcOptionEdit
            // 
            this.btnExcOptionEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnExcOptionEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnExcOptionEdit.Image")));
            this.btnExcOptionEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExcOptionEdit.Name = "btnExcOptionEdit";
            this.btnExcOptionEdit.Size = new System.Drawing.Size(21, 20);
            this.btnExcOptionEdit.Text = "Edit";
            this.btnExcOptionEdit.ToolTipText = "Press to edit the selected ";
            this.btnExcOptionEdit.Click += new System.EventHandler(this.btnExcOptionEdit_Click);
            // 
            // btnExcOptionDelete
            // 
            this.btnExcOptionDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnExcOptionDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnExcOptionDelete.Image")));
            this.btnExcOptionDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExcOptionDelete.Name = "btnExcOptionDelete";
            this.btnExcOptionDelete.Size = new System.Drawing.Size(21, 20);
            this.btnExcOptionDelete.Text = "Delete";
            this.btnExcOptionDelete.ToolTipText = "Press to delete the selected ";
            this.btnExcOptionDelete.Click += new System.EventHandler(this.btnExcOptionDelete_Click);
            // 
            // tabGraph
            // 
            this.tabGraph.Location = new System.Drawing.Point(4, 22);
            this.tabGraph.Name = "tabGraph";
            this.tabGraph.Size = new System.Drawing.Size(567, 250);
            this.tabGraph.TabIndex = 6;
            this.tabGraph.Text = "Graph";
            this.tabGraph.UseVisualStyleBackColor = true;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // edtSpecDescription
            // 
            this.edtSpecDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtSpecDescription.AttributeName = null;
            this.edtSpecDescription.Location = new System.Drawing.Point(71, 40);
            this.edtSpecDescription.Multiline = true;
            this.edtSpecDescription.Name = "edtSpecDescription";
            this.edtSpecDescription.Size = new System.Drawing.Size(511, 50);
            this.edtSpecDescription.TabIndex = 3;
            this.edtSpecDescription.Value = null;
            this.edtSpecDescription.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // edtSpecName
            // 
            this.edtSpecName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtSpecName.AttributeName = null;
            this.edtSpecName.Location = new System.Drawing.Point(71, 14);
            this.edtSpecName.Name = "edtSpecName";
            this.edtSpecName.Size = new System.Drawing.Size(511, 20);
            this.edtSpecName.TabIndex = 1;
            this.edtSpecName.Value = null;
            this.edtSpecName.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // requiredNameFieldValidator
            // 
            this.requiredNameFieldValidator.ControlToValidate = this.edtSpecName;
            this.requiredNameFieldValidator.ErrorMessage = "A Specification Name is required";
            this.requiredNameFieldValidator.ErrorProvider = this.errorProvider;
            this.requiredNameFieldValidator.Icon = null;
            this.requiredNameFieldValidator.InitialValue = null;
            this.requiredNameFieldValidator.IsEnabled = true;
            // 
            // requiredDescriptionFieldValidator
            // 
            this.requiredDescriptionFieldValidator.ControlToValidate = this.edtSpecDescription;
            this.requiredDescriptionFieldValidator.ErrorMessage = "A Specification Description is required";
            this.requiredDescriptionFieldValidator.ErrorProvider = this.errorProvider;
            this.requiredDescriptionFieldValidator.Icon = null;
            this.requiredDescriptionFieldValidator.InitialValue = null;
            this.requiredDescriptionFieldValidator.IsEnabled = true;
            // 
            // requiredDefinitionTextValidator
            // 
            this.requiredDefinitionTextValidator.ControlToValidate = this.edtDefinitionText;
            this.requiredDefinitionTextValidator.ErrorMessage = "The Definition Text is required";
            this.requiredDefinitionTextValidator.ErrorProvider = this.errorProvider;
            this.requiredDefinitionTextValidator.Icon = null;
            this.requiredDefinitionTextValidator.InitialValue = null;
            this.requiredDefinitionTextValidator.IsEnabled = true;
            // 
            // lbloName
            // 
            this.lbloName.HelpMessageKey = "SpecControl.Name";
            this.lbloName.Location = new System.Drawing.Point(28, 14);
            this.lbloName.Name = "lbloName";
            this.lbloName.RequiredField = true;
            this.lbloName.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbloName.Size = new System.Drawing.Size(39, 17);
            this.lbloName.TabIndex = 5;
            this.lbloName.Text = "Name";
            // 
            // helpLabel2
            // 
            this.helpLabel2.HelpMessageKey = "SpecControl.Description";
            this.helpLabel2.Location = new System.Drawing.Point(3, 40);
            this.helpLabel2.Name = "helpLabel2";
            this.helpLabel2.RequiredField = true;
            this.helpLabel2.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel2.Size = new System.Drawing.Size(64, 18);
            this.helpLabel2.TabIndex = 6;
            this.helpLabel2.Text = "Description";
            // 
            // btnSuppInfoAdd
            // 
            this.btnSuppInfoAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSuppInfoAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnSuppInfoAdd.Image")));
            this.btnSuppInfoAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSuppInfoAdd.Name = "btnSuppInfoAdd";
            this.btnSuppInfoAdd.Size = new System.Drawing.Size(29, 20);
            this.btnSuppInfoAdd.Text = "Add";
            this.btnSuppInfoAdd.ToolTipText = "Press to add a new ";
            this.btnSuppInfoAdd.Click += new System.EventHandler(this.btnSuppInfoAdd_Click);
            // 
            // btnSuppInfoEdit
            // 
            this.btnSuppInfoEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSuppInfoEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnSuppInfoEdit.Image")));
            this.btnSuppInfoEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSuppInfoEdit.Name = "btnSuppInfoEdit";
            this.btnSuppInfoEdit.Size = new System.Drawing.Size(29, 20);
            this.btnSuppInfoEdit.Text = "Edit";
            this.btnSuppInfoEdit.ToolTipText = "Press to edit the selected ";
            this.btnSuppInfoEdit.Click += new System.EventHandler(this.btnSuppInfoEdit_Click);
            // 
            // btnSuppInfoDelete
            // 
            this.btnSuppInfoDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSuppInfoDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnSuppInfoDelete.Image")));
            this.btnSuppInfoDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSuppInfoDelete.Name = "btnSuppInfoDelete";
            this.btnSuppInfoDelete.Size = new System.Drawing.Size(29, 20);
            this.btnSuppInfoDelete.Text = "Delete";
            this.btnSuppInfoDelete.ToolTipText = "Press to delete the selected ";
            this.btnSuppInfoDelete.Click += new System.EventHandler(this.btnSuppInfoDelete_Click);
            // 
            // tsSupplimental
            // 
            this.tsSupplimental.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tsSupplimental.Dock = System.Windows.Forms.DockStyle.Right;
            this.tsSupplimental.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsSupplimental.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSuppInfoAdd,
            this.btnSuppInfoEdit,
            this.btnSuppInfoDelete});
            this.tsSupplimental.Location = new System.Drawing.Point(535, 0);
            this.tsSupplimental.Name = "tsSupplimental";
            this.tsSupplimental.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tsSupplimental.Size = new System.Drawing.Size(32, 250);
            this.tsSupplimental.TabIndex = 2;
            this.tsSupplimental.Text = "toolStrip4";
            // 
            // information
            // 
            this.information.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.information.DefaultCellStyle = dataGridViewCellStyle6;
            this.information.HeaderText = "Supplimental Information Name";
            this.information.Name = "information";
            // 
            // dgSupplimentalInfo
            // 
            this.dgSupplimentalInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgSupplimentalInfo.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgSupplimentalInfo.BackgroundColor = System.Drawing.Color.SteelBlue;
            this.dgSupplimentalInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgSupplimentalInfo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgSupplimentalInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgSupplimentalInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSupplimentalInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.information});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgSupplimentalInfo.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgSupplimentalInfo.Location = new System.Drawing.Point(0, 0);
            this.dgSupplimentalInfo.Margin = new System.Windows.Forms.Padding(0);
            this.dgSupplimentalInfo.Name = "dgSupplimentalInfo";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgSupplimentalInfo.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgSupplimentalInfo.RowHeadersVisible = false;
            this.dgSupplimentalInfo.Size = new System.Drawing.Size(543, 224);
            this.dgSupplimentalInfo.TabIndex = 34;
            // 
            // SpecificationControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.helpLabel2);
            this.Controls.Add(this.lbloName);
            this.Controls.Add(this.tabSpecifications);
            this.Controls.Add(this.edtSpecDescription);
            this.Controls.Add(this.edtSpecName);
            this.Name = "SpecificationControl";
            this.Size = new System.Drawing.Size(597, 387);
            this.Load += new System.EventHandler(this.SpecificationControl_Load);
            this.SizeChanged += new System.EventHandler(this.SpecificationControl_SizeChanged);
            this.tabSpecifications.ResumeLayout(false);
            this.tabDefinition.ResumeLayout(false);
            this.tabDefinition.PerformLayout();
            this.tabConditions.ResumeLayout(false);
            this.tabConditions.PerformLayout();
            this.tsConditions.ResumeLayout(false);
            this.tsConditions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgConditions)).EndInit();
            this.tabLimits.ResumeLayout(false);
            this.tabSupplimentalInfo.ResumeLayout(false);
            this.tabSupplimentalInfo.PerformLayout();
            this.tabRequiredOptions.ResumeLayout(false);
            this.tabRequiredOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRequiredOptions)).EndInit();
            this.tsRequiredOptions.ResumeLayout(false);
            this.tsRequiredOptions.PerformLayout();
            this.tabExclusiveOptions.ResumeLayout(false);
            this.tabExclusiveOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgExclusiveOptions)).EndInit();
            this.tsExclusiveOptions.ResumeLayout(false);
            this.tsExclusiveOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.tsSupplimental.ResumeLayout(false);
            this.tsSupplimental.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSupplimentalInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private awb.AWBTextBox edtSpecName;
        private awb.AWBTextBox edtSpecDescription;
        private System.Windows.Forms.TabControl tabSpecifications;
        private System.Windows.Forms.TabPage tabDefinition;
        private System.Windows.Forms.TabPage tabConditions;
        private System.Windows.Forms.TabPage tabLimits;
        private System.Windows.Forms.TabPage tabSupplimentalInfo;
        private System.Windows.Forms.TabPage tabRequiredOptions;
        private System.Windows.Forms.TabPage tabExclusiveOptions;
        private awb.AWBTextBox  edtDefinitionText;
        private System.Windows.Forms.RadioButton rbText;
        private System.Windows.Forms.RadioButton rbDocument;
        private DocumentControl documentControl;
        private System.Windows.Forms.ListView lvConditions;
        private System.Windows.Forms.ListView lvSupplimentalInfo;
        private System.Windows.Forms.ListView lvRequiredOprions;
        private System.Windows.Forms.ToolStrip tsRequiredOptions;
        private System.Windows.Forms.ToolStripButton btnReqOptionAdd;
        private System.Windows.Forms.ToolStripButton btnReqOptionEdit;
        private System.Windows.Forms.ToolStripButton btnReqOptionDelete;
        private System.Windows.Forms.ToolStrip tsExclusiveOptions;
        private System.Windows.Forms.ToolStripButton btnExcOptionAdd;
        private System.Windows.Forms.ToolStripButton btnExcOptionEdit;
        private System.Windows.Forms.ToolStripButton btnExcOptionDelete;
        private System.Windows.Forms.DataGridView dgConditions;
        private System.Windows.Forms.DataGridView dgRequiredOptions;
        private System.Windows.Forms.DataGridView dgExclusiveOptions;
        private System.Windows.Forms.ToolStrip tsConditions;
        private System.Windows.Forms.ToolStripButton btnConditionsAdd;
        private System.Windows.Forms.ToolStripButton btnConditionsEdit;
        private System.Windows.Forms.ToolStripButton btnConditionsDelete;
        private lists.ATMLListControl limitListControl;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private validators.RequiredFieldValidator requiredNameFieldValidator;
        private validators.RequiredFieldValidator requiredDescriptionFieldValidator;
        private System.Windows.Forms.DataGridViewTextBoxColumn requiredOption;
        private System.Windows.Forms.DataGridViewTextBoxColumn exclusiveOption;
        private System.Windows.Forms.DataGridViewTextBoxColumn condition;
        private System.Windows.Forms.TabPage tabGraph;
        private System.Windows.Forms.RadioButton rbNone;
        private validators.RequiredFieldValidator requiredDefinitionTextValidator;
        private HelpLabel helpLabel2;
        private HelpLabel lbloName;
        private System.Windows.Forms.DataGridView dgSupplimentalInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn information;
        private System.Windows.Forms.ToolStrip tsSupplimental;
        private System.Windows.Forms.ToolStripButton btnSuppInfoAdd;
        private System.Windows.Forms.ToolStripButton btnSuppInfoEdit;
        private System.Windows.Forms.ToolStripButton btnSuppInfoDelete;
    }
}
