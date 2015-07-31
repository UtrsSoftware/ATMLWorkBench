/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using ATMLCommonLibrary.controls;

namespace ATML1671Reader.controls
{
    partial class CheckSumControl
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
            this.helpLabel1 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.helpLabel2 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.edtValue = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.edtType = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // helpLabel1
            // 
            this.helpLabel1.AutoSize = true;
            this.helpLabel1.BackColor = System.Drawing.SystemColors.Control;
            this.helpLabel1.ForeColor = System.Drawing.Color.Black;
            this.helpLabel1.HelpMessageKey = null;
            this.helpLabel1.Location = new System.Drawing.Point(6, 19);
            this.helpLabel1.Name = "helpLabel1";
            this.helpLabel1.RequiredField = false;
            this.helpLabel1.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel1.Size = new System.Drawing.Size(31, 13);
            this.helpLabel1.TabIndex = 0;
            this.helpLabel1.Text = "Type";
            // 
            // helpLabel2
            // 
            this.helpLabel2.AutoSize = true;
            this.helpLabel2.ForeColor = System.Drawing.Color.Black;
            this.helpLabel2.HelpMessageKey = null;
            this.helpLabel2.Location = new System.Drawing.Point(6, 43);
            this.helpLabel2.Name = "helpLabel2";
            this.helpLabel2.RequiredField = true;
            this.helpLabel2.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel2.Size = new System.Drawing.Size(34, 13);
            this.helpLabel2.TabIndex = 2;
            this.helpLabel2.Text = "Value";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.edtValue);
            this.groupBox1.Controls.Add(this.edtType);
            this.groupBox1.Controls.Add(this.helpLabel1);
            this.groupBox1.Controls.Add(this.helpLabel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(166, 75);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Check Sum";
            // 
            // edtValue
            // 
            this.edtValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtValue.AttributeName = null;
            this.edtValue.Location = new System.Drawing.Point(44, 45);
            this.edtValue.Name = "edtValue";
            this.edtValue.Size = new System.Drawing.Size(100, 20);
            this.edtValue.TabIndex = 3;
            this.edtValue.Value = null;
            this.edtValue.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // edtType
            // 
            this.edtType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtType.AttributeName = null;
            this.edtType.Location = new System.Drawing.Point(44, 19);
            this.edtType.Name = "edtType";
            this.edtType.Size = new System.Drawing.Size(100, 20);
            this.edtType.TabIndex = 1;
            this.edtType.Value = null;
            this.edtType.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // CheckSumControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "CheckSumControl";
            this.Size = new System.Drawing.Size(166, 75);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private HelpLabel helpLabel1;
        private HelpLabel helpLabel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private ATMLCommonLibrary.controls.awb.AWBTextBox edtValue;
        private ATMLCommonLibrary.controls.awb.AWBTextBox edtType;
    }
}
