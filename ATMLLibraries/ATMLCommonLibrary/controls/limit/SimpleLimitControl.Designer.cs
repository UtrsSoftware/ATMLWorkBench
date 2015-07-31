/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls.limit
{
    partial class SimpleLimitControl
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
            this.datumPanel = new System.Windows.Forms.Panel();
            this.edtDatumType = new ATMLCommonLibrary.controls.datum.DatumTextBox();
            this.standardUnitControl = new ATMLCommonLibrary.controls.StandardUnitControl();
            this.cmbLimitComparitor = new System.Windows.Forms.ComboBox();
            this.cmbLimitType = new System.Windows.Forms.ComboBox();
            this.lblStandardUnit = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.lblComparitor = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.lblValue = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.lblType = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.btnLimit = new System.Windows.Forms.Button();
            this.textPanel = new System.Windows.Forms.Panel();
            this.lblText = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.datumPanel.SuspendLayout();
            this.textPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // datumPanel
            // 
            this.datumPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.datumPanel.Controls.Add(this.edtDatumType);
            this.datumPanel.Controls.Add(this.standardUnitControl);
            this.datumPanel.Controls.Add(this.cmbLimitComparitor);
            this.datumPanel.Controls.Add(this.cmbLimitType);
            this.datumPanel.Controls.Add(this.lblStandardUnit);
            this.datumPanel.Controls.Add(this.lblComparitor);
            this.datumPanel.Controls.Add(this.lblValue);
            this.datumPanel.Controls.Add(this.lblType);
            this.datumPanel.Location = new System.Drawing.Point(61, 3);
            this.datumPanel.Name = "datumPanel";
            this.datumPanel.Size = new System.Drawing.Size(394, 37);
            this.datumPanel.TabIndex = 28;
            // 
            // edtDatumType
            // 
            this.edtDatumType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtDatumType.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.edtDatumType.DatumTypeIndex = -1;
            this.edtDatumType.HelpKeyWord = null;
            this.edtDatumType.Label = null;
            this.edtDatumType.Location = new System.Drawing.Point(150, 13);
            this.edtDatumType.Name = "edtDatumType";
            this.edtDatumType.SchemaTypeName = null;
            this.edtDatumType.Size = new System.Drawing.Size(44, 20);
            this.edtDatumType.TabIndex = 15;
            this.edtDatumType.TargetNamespace = null;
            this.edtDatumType.Value = null;
            // 
            // standardUnitControl
            // 
            this.standardUnitControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.standardUnitControl.HelpKeyWord = null;
            this.standardUnitControl.Location = new System.Drawing.Point(212, 12);
            this.standardUnitControl.Name = "standardUnitControl";
            this.standardUnitControl.SchemaTypeName = null;
            this.standardUnitControl.Size = new System.Drawing.Size(178, 24);
            this.standardUnitControl.TabIndex = 12;
            this.standardUnitControl.TargetNamespace = null;
            // 
            // cmbLimitComparitor
            // 
            this.cmbLimitComparitor.FormattingEnabled = true;
            this.cmbLimitComparitor.Items.AddRange(new object[] {
            "AND",
            "OR"});
            this.cmbLimitComparitor.Location = new System.Drawing.Point(4, 13);
            this.cmbLimitComparitor.Name = "cmbLimitComparitor";
            this.cmbLimitComparitor.Size = new System.Drawing.Size(54, 21);
            this.cmbLimitComparitor.TabIndex = 7;
            this.cmbLimitComparitor.SelectedIndexChanged += new System.EventHandler(this.cmbLimit1Comparitor_SelectedIndexChanged);
            // 
            // cmbLimitType
            // 
            this.cmbLimitType.DropDownWidth = 150;
            this.cmbLimitType.FormattingEnabled = true;
            this.cmbLimitType.Location = new System.Drawing.Point(61, 13);
            this.cmbLimitType.Name = "cmbLimitType";
            this.cmbLimitType.Size = new System.Drawing.Size(82, 21);
            this.cmbLimitType.TabIndex = 9;
            this.cmbLimitType.SelectedIndexChanged += new System.EventHandler(this.cmbLimit1Type_SelectedIndexChanged);
            // 
            // lblStandardUnit
            // 
            this.lblStandardUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStandardUnit.AutoSize = true;
            this.lblStandardUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStandardUnit.HelpMessageKey = "Limit.standardUnit";
            this.lblStandardUnit.Location = new System.Drawing.Point(217, 0);
            this.lblStandardUnit.Name = "lblStandardUnit";
            this.lblStandardUnit.RequiredField = false;
            this.lblStandardUnit.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStandardUnit.Size = new System.Drawing.Size(167, 12);
            this.lblStandardUnit.TabIndex = 14;
            this.lblStandardUnit.Text = "----------------- Standard Unit -----------------";
            // 
            // lblComparitor
            // 
            this.lblComparitor.AutoSize = true;
            this.lblComparitor.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComparitor.HelpMessageKey = "Limit.comparitor";
            this.lblComparitor.Location = new System.Drawing.Point(4, 0);
            this.lblComparitor.Name = "lblComparitor";
            this.lblComparitor.RequiredField = false;
            this.lblComparitor.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComparitor.Size = new System.Drawing.Size(51, 12);
            this.lblComparitor.TabIndex = 8;
            this.lblComparitor.Text = "Comparitor";
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValue.HelpMessageKey = "limit.value";
            this.lblValue.Location = new System.Drawing.Point(148, 0);
            this.lblValue.Name = "lblValue";
            this.lblValue.RequiredField = false;
            this.lblValue.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValue.Size = new System.Drawing.Size(29, 12);
            this.lblValue.TabIndex = 13;
            this.lblValue.Text = "Value";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType.HelpMessageKey = "Linit.datatype";
            this.lblType.Location = new System.Drawing.Point(61, 0);
            this.lblType.Name = "lblType";
            this.lblType.RequiredField = false;
            this.lblType.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType.Size = new System.Drawing.Size(25, 12);
            this.lblType.TabIndex = 10;
            this.lblType.Text = "Type";
            // 
            // btnLimit
            // 
            this.btnLimit.FlatAppearance.BorderSize = 0;
            this.btnLimit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnLimit.Font = new System.Drawing.Font("Bell MT", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimit.Location = new System.Drawing.Point(7, 16);
            this.btnLimit.Name = "btnLimit";
            this.btnLimit.Size = new System.Drawing.Size(48, 21);
            this.btnLimit.TabIndex = 0;
            this.btnLimit.Text = "Limit";
            this.btnLimit.UseVisualStyleBackColor = true;
            this.btnLimit.Click += new System.EventHandler(this.btnLimit1_Click);
            // 
            // textPanel
            // 
            this.textPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textPanel.Controls.Add(this.lblText);
            this.textPanel.Location = new System.Drawing.Point(61, 3);
            this.textPanel.Name = "textPanel";
            this.textPanel.Size = new System.Drawing.Size(394, 37);
            this.textPanel.TabIndex = 30;
            this.textPanel.Visible = false;
            // 
            // lblText
            // 
            this.lblText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblText.Location = new System.Drawing.Point(0, 0);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(394, 37);
            this.lblText.TabIndex = 0;
            this.lblText.Text = "textLabel";
            this.lblText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblText.Click += new System.EventHandler(this.lblText_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // SimpleLimitControl
            // 
            this.Controls.Add(this.datumPanel);
            this.Controls.Add(this.btnLimit);
            this.Controls.Add(this.textPanel);
            this.MinimumSize = new System.Drawing.Size(455, 42);
            this.Name = "SimpleLimitControl";
            this.Size = new System.Drawing.Size(455, 42);
            this.Load += new System.EventHandler(this.SimpleLimitControl_Load);
            this.datumPanel.ResumeLayout(false);
            this.datumPanel.PerformLayout();
            this.textPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Button btnLimit;
        protected System.Windows.Forms.Panel datumPanel;
        protected System.Windows.Forms.Panel textPanel;
        protected System.Windows.Forms.Label lblText;
        protected StandardUnitControl standardUnitControl;
        protected System.Windows.Forms.ComboBox cmbLimitComparitor;
        protected System.Windows.Forms.ComboBox cmbLimitType;
        protected HelpLabel lblStandardUnit;
        protected HelpLabel lblComparitor;
        protected HelpLabel lblValue;
        protected HelpLabel lblType;
        protected datum.DatumTextBox edtDatumType;
        protected System.Windows.Forms.ErrorProvider errorProvider;
    }
}
