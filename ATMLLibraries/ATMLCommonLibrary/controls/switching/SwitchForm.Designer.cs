/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls.switching
{
    partial class SwitchForm
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
            this.matrixSwitchControl = new ATMLCommonLibrary.controls.switching.MatrixSwitchControl();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbSwitchType = new System.Windows.Forms.ComboBox();
            this.switchControl = new ATMLCommonLibrary.controls.switching.SwitchControl();
            this.crossPointSwitchControl = new ATMLCommonLibrary.controls.switching.CrossPointSwitchControl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbSwitchType);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.crossPointSwitchControl);
            this.panel1.Controls.Add(this.switchControl);
            this.panel1.Controls.Add(this.matrixSwitchControl);
            this.panel1.Size = new System.Drawing.Size(543, 394);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(481, 412);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(400, 412);
            // 
            // lblDenoteRequiredField
            // 
            this.lblDenoteRequiredField.Location = new System.Drawing.Point(1, 423);
            // 
            // matrixSwitchControl
            // 
            this.matrixSwitchControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.matrixSwitchControl.Location = new System.Drawing.Point(10, 34);
            this.matrixSwitchControl.Name = "matrixSwitchControl";
            this.matrixSwitchControl.SchemaTypeName = null;
            this.matrixSwitchControl.Size = new System.Drawing.Size(530, 354);
            this.matrixSwitchControl.TabIndex = 0;
            this.matrixSwitchControl.TargetNamespace = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Switch Type";
            // 
            // cmbSwitchType
            // 
            this.cmbSwitchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSwitchType.FormattingEnabled = true;
            this.cmbSwitchType.Items.AddRange(new object[] {
            "Switch",
            "Matrix Switch",
            "Cross Point Switch"});
            this.cmbSwitchType.Location = new System.Drawing.Point(81, 7);
            this.cmbSwitchType.Name = "cmbSwitchType";
            this.cmbSwitchType.Size = new System.Drawing.Size(326, 21);
            this.cmbSwitchType.TabIndex = 2;
            this.cmbSwitchType.SelectedIndexChanged += new System.EventHandler(this.cmbSwitchType_SelectedIndexChanged);
            // 
            // switchControl
            // 
            this.switchControl.Location = new System.Drawing.Point(10, 34);
            this.switchControl.MinimumSize = new System.Drawing.Size(507, 167);
            this.switchControl.Name = "switchControl";
            this.switchControl.SchemaTypeName = null;
            this.switchControl.Size = new System.Drawing.Size(530, 354);
            this.switchControl.TabIndex = 3;
            this.switchControl.TargetNamespace = null;
            // 
            // crossPointSwitchControl
            // 
            this.crossPointSwitchControl.Location = new System.Drawing.Point(10, 34);
            this.crossPointSwitchControl.Name = "crossPointSwitchControl";
            this.crossPointSwitchControl.SchemaTypeName = null;
            this.crossPointSwitchControl.Size = new System.Drawing.Size(530, 354);
            this.crossPointSwitchControl.TabIndex = 4;
            this.crossPointSwitchControl.TargetNamespace = null;
            // 
            // SwitchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 439);
            this.Name = "SwitchForm";
            this.Text = "Switch";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MatrixSwitchControl matrixSwitchControl;
        private System.Windows.Forms.ComboBox cmbSwitchType;
        private System.Windows.Forms.Label label1;
        private SwitchControl switchControl;
        private CrossPointSwitchControl crossPointSwitchControl;
    }
}