/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls
{
    partial class StandardUnitControl
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
            this.edtStnUnit = new System.Windows.Forms.TextBox();
            this.cmbStdUnit = new System.Windows.Forms.ComboBox();
            this.cmbPrefix = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // edtStnUnit
            // 
            this.edtStnUnit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtStnUnit.Location = new System.Drawing.Point(0, 0);
            this.edtStnUnit.Name = "edtStnUnit";
            this.edtStnUnit.Size = new System.Drawing.Size(49, 20);
            this.edtStnUnit.TabIndex = 0;
            this.edtStnUnit.TextChanged += new System.EventHandler(this.edtStnUnit_TextChanged);
            this.edtStnUnit.KeyUp += new System.Windows.Forms.KeyEventHandler(this.edtStnUnit_KeyUp);
            // 
            // cmbStdUnit
            // 
            this.cmbStdUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbStdUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStdUnit.DropDownWidth = 125;
            this.cmbStdUnit.FormattingEnabled = true;
            this.cmbStdUnit.Location = new System.Drawing.Point(104, 0);
            this.cmbStdUnit.Name = "cmbStdUnit";
            this.cmbStdUnit.Size = new System.Drawing.Size(81, 21);
            this.cmbStdUnit.TabIndex = 2;
            this.cmbStdUnit.SelectedIndexChanged += new System.EventHandler(this.cmbStdUnit1_SelectedIndexChanged);
            // 
            // cmbPrefix
            // 
            this.cmbPrefix.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPrefix.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrefix.DropDownWidth = 100;
            this.cmbPrefix.FormattingEnabled = true;
            this.cmbPrefix.ItemHeight = 13;
            this.cmbPrefix.Location = new System.Drawing.Point(51, 0);
            this.cmbPrefix.Name = "cmbPrefix";
            this.cmbPrefix.Size = new System.Drawing.Size(52, 21);
            this.cmbPrefix.TabIndex = 1;
            this.cmbPrefix.SelectedIndexChanged += new System.EventHandler(this.cmbPrefix1_SelectedIndexChanged);
            // 
            // StandardUnitControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.edtStnUnit);
            this.Controls.Add(this.cmbStdUnit);
            this.Controls.Add(this.cmbPrefix);
            this.Name = "StandardUnitControl";
            this.Size = new System.Drawing.Size(185, 21);
            this.Load += new System.EventHandler(this.StandardUnitControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbStdUnit;
        private System.Windows.Forms.ComboBox cmbPrefix;
        private System.Windows.Forms.TextBox edtStnUnit;
    }
}
