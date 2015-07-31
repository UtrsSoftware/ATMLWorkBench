/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

namespace ATMLCommonLibrary.controls.physical
{
    partial class PhysicalTypeControl
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgErrorLimits = new System.Windows.Forms.DataGridView();
            this.cbQualifier = new System.Windows.Forms.ComboBox();
            this.edtValue = new System.Windows.Forms.NumericUpDown();
            this.edtPhysicalTypeValue = new System.Windows.Forms.TextBox();
            this.edtLoad = new System.Windows.Forms.NumericUpDown();
            this.helpLabel9 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.loadStandardUnitControl = new ATMLCommonLibrary.controls.StandardUnitControl();
            this.helpLabel8 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.helpLabel7 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.helpLabel5 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.helpLabel4 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.standardUnitControl = new ATMLCommonLibrary.controls.StandardUnitControl();
            this.helpLabel3 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.helpLabel2 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.helpLabel1 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.dataGridViewNumericUpDownColumn1 = new DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn();
            this.dataGridViewNumericUpDownColumn2 = new DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn();
            this.dataGridViewNumericUpDownColumn3 = new DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn();
            this.dataGridViewNumericUpDownColumn4 = new DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn();
            this.dgRanges = new System.Windows.Forms.DataGridView();
            this.dgRangesLLValueColumn = new DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn();
            this.dgRangesLLPrefixColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgRangesLLUnitColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgRangesULValueColumn = new DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn();
            this.dgRangesULPrefixColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgRangesULUnitColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgRangesULErrlmtColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnErrorLimit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dgErrlmtLLSignColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgErrlmtLLValueColumn = new DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn();
            this.dgErrlmtLLPrefixColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgErrlmtLLUnitColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgErrlmtULSignColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgErrlmtULValueColumn = new DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn();
            this.dgErrlmtULPrefixColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgErrlmtULUnitColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgErrlmtConfidenceColumn = new DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn();
            this.dgErrlmtResolutionColumn = new DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn();
            this.dgErrlmtResPrefixColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgErrlmtResUnitColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgErrorLimits)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLoad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgRanges)).BeginInit();
            this.SuspendLayout();
            // 
            // dgErrorLimits
            // 
            this.dgErrorLimits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgErrorLimits.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.btnErrorLimit,
            this.dgErrlmtLLSignColumn,
            this.dgErrlmtLLValueColumn,
            this.dgErrlmtLLPrefixColumn,
            this.dgErrlmtLLUnitColumn,
            this.dgErrlmtULSignColumn,
            this.dgErrlmtULValueColumn,
            this.dgErrlmtULPrefixColumn,
            this.dgErrlmtULUnitColumn,
            this.dgErrlmtConfidenceColumn,
            this.dgErrlmtResolutionColumn,
            this.dgErrlmtResPrefixColumn,
            this.dgErrlmtResUnitColumn});
            this.dgErrorLimits.Location = new System.Drawing.Point(15, 80);
            this.dgErrorLimits.Name = "dgErrorLimits";
            this.dgErrorLimits.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgErrorLimits.RowHeadersVisible = false;
            this.dgErrorLimits.Size = new System.Drawing.Size(953, 138);
            this.dgErrorLimits.TabIndex = 13;
            this.dgErrorLimits.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgErrorLimits_CellBeginEdit);
            this.dgErrorLimits.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgErrorLimits_CellContentClick);
            this.dgErrorLimits.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgErrorLimits_CellEndEdit);
            // 
            // cbQualifier
            // 
            this.cbQualifier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbQualifier.FormattingEnabled = true;
            this.cbQualifier.Location = new System.Drawing.Point(76, 10);
            this.cbQualifier.Name = "cbQualifier";
            this.cbQualifier.Size = new System.Drawing.Size(96, 21);
            this.cbQualifier.TabIndex = 1;
            // 
            // edtValue
            // 
            this.edtValue.DecimalPlaces = 2;
            this.edtValue.Location = new System.Drawing.Point(230, 10);
            this.edtValue.Name = "edtValue";
            this.edtValue.Size = new System.Drawing.Size(94, 20);
            this.edtValue.TabIndex = 3;
            this.edtValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // edtPhysicalTypeValue
            // 
            this.edtPhysicalTypeValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));
            this.edtPhysicalTypeValue.Location = new System.Drawing.Point(15, 427);
            this.edtPhysicalTypeValue.Name = "edtPhysicalTypeValue";
            this.edtPhysicalTypeValue.ReadOnly = true;
            this.edtPhysicalTypeValue.Size = new System.Drawing.Size(953, 20);
            this.edtPhysicalTypeValue.TabIndex = 17;
            // 
            // edtLoad
            // 
            this.edtLoad.DecimalPlaces = 2;
            this.edtLoad.Location = new System.Drawing.Point(230, 39);
            this.edtLoad.Name = "edtLoad";
            this.edtLoad.Size = new System.Drawing.Size(94, 20);
            this.edtLoad.TabIndex = 9;
            this.edtLoad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // helpLabel9
            // 
            this.helpLabel9.AutoSize = true;
            this.helpLabel9.HelpMessageKey = null;
            this.helpLabel9.Location = new System.Drawing.Point(348, 41);
            this.helpLabel9.Name = "helpLabel9";
            this.helpLabel9.RequiredField = false;
            this.helpLabel9.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel9.Size = new System.Drawing.Size(26, 13);
            this.helpLabel9.TabIndex = 10;
            this.helpLabel9.Text = "Unit";
            // 
            // loadStandardUnitControl
            // 
            this.loadStandardUnitControl.Location = new System.Drawing.Point(377, 39);
            this.loadStandardUnitControl.Name = "loadStandardUnitControl";
            this.loadStandardUnitControl.SchemaTypeName = null;
            this.loadStandardUnitControl.Size = new System.Drawing.Size(205, 21);
            this.loadStandardUnitControl.TabIndex = 11;
            this.loadStandardUnitControl.TargetNamespace = null;
            // 
            // helpLabel8
            // 
            this.helpLabel8.AutoSize = true;
            this.helpLabel8.HelpMessageKey = null;
            this.helpLabel8.Location = new System.Drawing.Point(190, 41);
            this.helpLabel8.Name = "helpLabel8";
            this.helpLabel8.RequiredField = false;
            this.helpLabel8.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel8.Size = new System.Drawing.Size(31, 13);
            this.helpLabel8.TabIndex = 8;
            this.helpLabel8.Text = "Load";
            // 
            // helpLabel7
            // 
            this.helpLabel7.AutoSize = true;
            this.helpLabel7.HelpMessageKey = null;
            this.helpLabel7.Location = new System.Drawing.Point(12, 409);
            this.helpLabel7.Name = "helpLabel7";
            this.helpLabel7.RequiredField = false;
            this.helpLabel7.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel7.Size = new System.Drawing.Size(103, 13);
            this.helpLabel7.TabIndex = 16;
            this.helpLabel7.Text = "Physical Type Value";
            // 
            // helpLabel5
            // 
            this.helpLabel5.AutoSize = true;
            this.helpLabel5.HelpMessageKey = null;
            this.helpLabel5.Location = new System.Drawing.Point(15, 238);
            this.helpLabel5.Name = "helpLabel5";
            this.helpLabel5.RequiredField = false;
            this.helpLabel5.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel5.Size = new System.Drawing.Size(44, 13);
            this.helpLabel5.TabIndex = 14;
            this.helpLabel5.Text = "Ranges";
            // 
            // helpLabel4
            // 
            this.helpLabel4.AutoSize = true;
            this.helpLabel4.HelpMessageKey = null;
            this.helpLabel4.Location = new System.Drawing.Point(348, 14);
            this.helpLabel4.Name = "helpLabel4";
            this.helpLabel4.RequiredField = false;
            this.helpLabel4.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel4.Size = new System.Drawing.Size(26, 13);
            this.helpLabel4.TabIndex = 4;
            this.helpLabel4.Text = "Unit";
            // 
            // standardUnitControl
            // 
            this.standardUnitControl.Location = new System.Drawing.Point(377, 10);
            this.standardUnitControl.Name = "standardUnitControl";
            this.standardUnitControl.SchemaTypeName = null;
            this.standardUnitControl.Size = new System.Drawing.Size(205, 21);
            this.standardUnitControl.TabIndex = 5;
            this.standardUnitControl.TargetNamespace = null;
            // 
            // helpLabel3
            // 
            this.helpLabel3.AutoSize = true;
            this.helpLabel3.HelpMessageKey = null;
            this.helpLabel3.Location = new System.Drawing.Point(190, 14);
            this.helpLabel3.Name = "helpLabel3";
            this.helpLabel3.RequiredField = false;
            this.helpLabel3.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel3.Size = new System.Drawing.Size(34, 13);
            this.helpLabel3.TabIndex = 2;
            this.helpLabel3.Text = "Value";
            // 
            // helpLabel2
            // 
            this.helpLabel2.AutoSize = true;
            this.helpLabel2.HelpMessageKey = null;
            this.helpLabel2.Location = new System.Drawing.Point(15, 14);
            this.helpLabel2.Name = "helpLabel2";
            this.helpLabel2.RequiredField = false;
            this.helpLabel2.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel2.Size = new System.Drawing.Size(45, 13);
            this.helpLabel2.TabIndex = 0;
            this.helpLabel2.Text = "Qualifier";
            // 
            // helpLabel1
            // 
            this.helpLabel1.AutoSize = true;
            this.helpLabel1.HelpMessageKey = null;
            this.helpLabel1.Location = new System.Drawing.Point(15, 63);
            this.helpLabel1.Name = "helpLabel1";
            this.helpLabel1.RequiredField = false;
            this.helpLabel1.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel1.Size = new System.Drawing.Size(96, 13);
            this.helpLabel1.TabIndex = 12;
            this.helpLabel1.Text = "Uncertainty Values";
            // 
            // dataGridViewNumericUpDownColumn1
            // 
            this.dataGridViewNumericUpDownColumn1.DecimalPlaces = 2;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewNumericUpDownColumn1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewNumericUpDownColumn1.HeaderText = "LL Value";
            this.dataGridViewNumericUpDownColumn1.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.dataGridViewNumericUpDownColumn1.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.dataGridViewNumericUpDownColumn1.Name = "dataGridViewNumericUpDownColumn1";
            this.dataGridViewNumericUpDownColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewNumericUpDownColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewNumericUpDownColumn1.Width = 75;
            // 
            // dataGridViewNumericUpDownColumn2
            // 
            this.dataGridViewNumericUpDownColumn2.DecimalPlaces = 2;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewNumericUpDownColumn2.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewNumericUpDownColumn2.HeaderText = "UL Value";
            this.dataGridViewNumericUpDownColumn2.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.dataGridViewNumericUpDownColumn2.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.dataGridViewNumericUpDownColumn2.Name = "dataGridViewNumericUpDownColumn2";
            this.dataGridViewNumericUpDownColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewNumericUpDownColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewNumericUpDownColumn2.Width = 75;
            // 
            // dataGridViewNumericUpDownColumn3
            // 
            this.dataGridViewNumericUpDownColumn3.DecimalPlaces = 2;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.NullValue = null;
            this.dataGridViewNumericUpDownColumn3.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewNumericUpDownColumn3.HeaderText = "Confidence";
            this.dataGridViewNumericUpDownColumn3.Name = "dataGridViewNumericUpDownColumn3";
            this.dataGridViewNumericUpDownColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewNumericUpDownColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewNumericUpDownColumn3.Width = 75;
            // 
            // dataGridViewNumericUpDownColumn4
            // 
            this.dataGridViewNumericUpDownColumn4.DecimalPlaces = 2;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewNumericUpDownColumn4.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewNumericUpDownColumn4.HeaderText = "Resolution";
            this.dataGridViewNumericUpDownColumn4.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.dataGridViewNumericUpDownColumn4.Minimum = new decimal(new int[] {
            999,
            0,
            0,
            -2147483648});
            this.dataGridViewNumericUpDownColumn4.Name = "dataGridViewNumericUpDownColumn4";
            this.dataGridViewNumericUpDownColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewNumericUpDownColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewNumericUpDownColumn4.Width = 75;
            // 
            // dgRanges
            // 
            this.dgRanges.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRanges.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgRangesLLValueColumn,
            this.dgRangesLLPrefixColumn,
            this.dgRangesLLUnitColumn,
            this.dgRangesULValueColumn,
            this.dgRangesULPrefixColumn,
            this.dgRangesULUnitColumn,
            this.dgRangesULErrlmtColumn});
            this.dgRanges.Location = new System.Drawing.Point(15, 255);
            this.dgRanges.Name = "dgRanges";
            this.dgRanges.Size = new System.Drawing.Size(953, 138);
            this.dgRanges.TabIndex = 15;
            this.dgRanges.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgRanges_CellContentClick);
            // 
            // dgRangesLLValueColumn
            // 
            this.dgRangesLLValueColumn.DecimalPlaces = 2;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dgRangesLLValueColumn.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgRangesLLValueColumn.HeaderText = "LL Value";
            this.dgRangesLLValueColumn.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.dgRangesLLValueColumn.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.dgRangesLLValueColumn.Name = "dgRangesLLValueColumn";
            this.dgRangesLLValueColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgRangesLLValueColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgRangesLLValueColumn.Width = 75;
            // 
            // dgRangesLLPrefixColumn
            // 
            this.dgRangesLLPrefixColumn.HeaderText = "LL Prefix";
            this.dgRangesLLPrefixColumn.Name = "dgRangesLLPrefixColumn";
            this.dgRangesLLPrefixColumn.Width = 75;
            // 
            // dgRangesLLUnitColumn
            // 
            this.dgRangesLLUnitColumn.HeaderText = "LL Unit";
            this.dgRangesLLUnitColumn.Name = "dgRangesLLUnitColumn";
            // 
            // dgRangesULValueColumn
            // 
            this.dgRangesULValueColumn.DecimalPlaces = 2;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dgRangesULValueColumn.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgRangesULValueColumn.HeaderText = "UL Value";
            this.dgRangesULValueColumn.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.dgRangesULValueColumn.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.dgRangesULValueColumn.Name = "dgRangesULValueColumn";
            this.dgRangesULValueColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgRangesULValueColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgRangesULValueColumn.Width = 75;
            // 
            // dgRangesULPrefixColumn
            // 
            this.dgRangesULPrefixColumn.HeaderText = "UL Prefix";
            this.dgRangesULPrefixColumn.Name = "dgRangesULPrefixColumn";
            this.dgRangesULPrefixColumn.Width = 75;
            // 
            // dgRangesULUnitColumn
            // 
            this.dgRangesULUnitColumn.HeaderText = "UL Unit";
            this.dgRangesULUnitColumn.Name = "dgRangesULUnitColumn";
            // 
            // dgRangesULErrlmtColumn
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dgRangesULErrlmtColumn.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgRangesULErrlmtColumn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dgRangesULErrlmtColumn.HeaderText = "Errlmt";
            this.dgRangesULErrlmtColumn.Name = "dgRangesULErrlmtColumn";
            this.dgRangesULErrlmtColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgRangesULErrlmtColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgRangesULErrlmtColumn.Width = 230;
            // 
            // btnErrorLimit
            // 
            this.btnErrorLimit.Frozen = true;
            this.btnErrorLimit.HeaderText = "";
            this.btnErrorLimit.Name = "btnErrorLimit";
            this.btnErrorLimit.Width = 23;
            // 
            // dgErrlmtLLSignColumn
            // 
            this.dgErrlmtLLSignColumn.Frozen = true;
            this.dgErrlmtLLSignColumn.HeaderText = "LL Sign";
            this.dgErrlmtLLSignColumn.Name = "dgErrlmtLLSignColumn";
            this.dgErrlmtLLSignColumn.Width = 50;
            // 
            // dgErrlmtLLValueColumn
            // 
            this.dgErrlmtLLValueColumn.DecimalPlaces = 2;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dgErrlmtLLValueColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgErrlmtLLValueColumn.HeaderText = "LL Value";
            this.dgErrlmtLLValueColumn.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.dgErrlmtLLValueColumn.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.dgErrlmtLLValueColumn.Name = "dgErrlmtLLValueColumn";
            this.dgErrlmtLLValueColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgErrlmtLLValueColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgErrlmtLLValueColumn.Width = 75;
            // 
            // dgErrlmtLLPrefixColumn
            // 
            this.dgErrlmtLLPrefixColumn.HeaderText = "LL Prefix";
            this.dgErrlmtLLPrefixColumn.Name = "dgErrlmtLLPrefixColumn";
            this.dgErrlmtLLPrefixColumn.Width = 75;
            // 
            // dgErrlmtLLUnitColumn
            // 
            this.dgErrlmtLLUnitColumn.HeaderText = "LL Unit";
            this.dgErrlmtLLUnitColumn.Name = "dgErrlmtLLUnitColumn";
            // 
            // dgErrlmtULSignColumn
            // 
            this.dgErrlmtULSignColumn.HeaderText = "UL Sign";
            this.dgErrlmtULSignColumn.Name = "dgErrlmtULSignColumn";
            this.dgErrlmtULSignColumn.Width = 50;
            // 
            // dgErrlmtULValueColumn
            // 
            this.dgErrlmtULValueColumn.DecimalPlaces = 2;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dgErrlmtULValueColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgErrlmtULValueColumn.HeaderText = "UL Value";
            this.dgErrlmtULValueColumn.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.dgErrlmtULValueColumn.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.dgErrlmtULValueColumn.Name = "dgErrlmtULValueColumn";
            this.dgErrlmtULValueColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgErrlmtULValueColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgErrlmtULValueColumn.Width = 75;
            // 
            // dgErrlmtULPrefixColumn
            // 
            this.dgErrlmtULPrefixColumn.HeaderText = "UL Prefix";
            this.dgErrlmtULPrefixColumn.Name = "dgErrlmtULPrefixColumn";
            this.dgErrlmtULPrefixColumn.Width = 75;
            // 
            // dgErrlmtULUnitColumn
            // 
            this.dgErrlmtULUnitColumn.HeaderText = "UL Unit";
            this.dgErrlmtULUnitColumn.Name = "dgErrlmtULUnitColumn";
            // 
            // dgErrlmtConfidenceColumn
            // 
            this.dgErrlmtConfidenceColumn.DecimalPlaces = 2;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.NullValue = null;
            this.dgErrlmtConfidenceColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgErrlmtConfidenceColumn.HeaderText = "Confidence";
            this.dgErrlmtConfidenceColumn.Name = "dgErrlmtConfidenceColumn";
            this.dgErrlmtConfidenceColumn.Percentage = true;
            this.dgErrlmtConfidenceColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgErrlmtConfidenceColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgErrlmtConfidenceColumn.Width = 75;
            // 
            // dgErrlmtResolutionColumn
            // 
            this.dgErrlmtResolutionColumn.DecimalPlaces = 2;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dgErrlmtResolutionColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgErrlmtResolutionColumn.HeaderText = "Resolution";
            this.dgErrlmtResolutionColumn.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.dgErrlmtResolutionColumn.Minimum = new decimal(new int[] {
            999,
            0,
            0,
            -2147483648});
            this.dgErrlmtResolutionColumn.Name = "dgErrlmtResolutionColumn";
            this.dgErrlmtResolutionColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgErrlmtResolutionColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgErrlmtResolutionColumn.Width = 75;
            // 
            // dgErrlmtResPrefixColumn
            // 
            this.dgErrlmtResPrefixColumn.HeaderText = "Res. Prefix";
            this.dgErrlmtResPrefixColumn.Name = "dgErrlmtResPrefixColumn";
            this.dgErrlmtResPrefixColumn.Width = 75;
            // 
            // dgErrlmtResUnitColumn
            // 
            this.dgErrlmtResUnitColumn.HeaderText = "Res. Unit";
            this.dgErrlmtResUnitColumn.Name = "dgErrlmtResUnitColumn";
            // 
            // PhysicalTypeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.helpLabel9);
            this.Controls.Add(this.loadStandardUnitControl);
            this.Controls.Add(this.edtLoad);
            this.Controls.Add(this.helpLabel8);
            this.Controls.Add(this.helpLabel7);
            this.Controls.Add(this.edtPhysicalTypeValue);
            this.Controls.Add(this.helpLabel5);
            this.Controls.Add(this.dgRanges);
            this.Controls.Add(this.helpLabel4);
            this.Controls.Add(this.standardUnitControl);
            this.Controls.Add(this.edtValue);
            this.Controls.Add(this.helpLabel3);
            this.Controls.Add(this.cbQualifier);
            this.Controls.Add(this.helpLabel2);
            this.Controls.Add(this.helpLabel1);
            this.Controls.Add(this.dgErrorLimits);
            this.Name = "PhysicalTypeControl";
            this.Size = new System.Drawing.Size(990, 466);
            ((System.ComponentModel.ISupportInitialize)(this.dgErrorLimits)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLoad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgRanges)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgErrorLimits;
        private HelpLabel helpLabel1;
        private HelpLabel helpLabel2;
        private System.Windows.Forms.ComboBox cbQualifier;
        private HelpLabel helpLabel3;
        private System.Windows.Forms.NumericUpDown edtValue;
        private StandardUnitControl standardUnitControl;
        private HelpLabel helpLabel4;
        private System.Windows.Forms.DataGridView dgRanges;
        private HelpLabel helpLabel5;
        private System.Windows.Forms.TextBox edtPhysicalTypeValue;
        private HelpLabel helpLabel7;
        private HelpLabel helpLabel8;
        private StandardUnitControl loadStandardUnitControl;
        private System.Windows.Forms.NumericUpDown edtLoad;
        private HelpLabel helpLabel9;
        private DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn dataGridViewNumericUpDownColumn1;
        private DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn dataGridViewNumericUpDownColumn2;
        private DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn dataGridViewNumericUpDownColumn3;
        private DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn dataGridViewNumericUpDownColumn4;
        private DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn dgRangesLLValueColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgRangesLLPrefixColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgRangesLLUnitColumn;
        private DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn dgRangesULValueColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgRangesULPrefixColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgRangesULUnitColumn;
        private System.Windows.Forms.DataGridViewButtonColumn dgRangesULErrlmtColumn;
        private System.Windows.Forms.DataGridViewButtonColumn btnErrorLimit;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgErrlmtLLSignColumn;
        private DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn dgErrlmtLLValueColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgErrlmtLLPrefixColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgErrlmtLLUnitColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgErrlmtULSignColumn;
        private DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn dgErrlmtULValueColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgErrlmtULPrefixColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgErrlmtULUnitColumn;
        private DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn dgErrlmtConfidenceColumn;
        private DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn dgErrlmtResolutionColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgErrlmtResPrefixColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgErrlmtResUnitColumn;
    }
}
