/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls.limit
{
    partial class LimitSimpleControl
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
            this.btnLimit = new System.Windows.Forms.Button();
            this.edtLimit = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.SuspendLayout();
            // 
            // btnLimit
            // 
            this.btnLimit.FlatAppearance.BorderSize = 0;
            this.btnLimit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnLimit.Font = new System.Drawing.Font("Bell MT", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimit.Location = new System.Drawing.Point(0, 0);
            this.btnLimit.Margin = new System.Windows.Forms.Padding(0);
            this.btnLimit.Name = "btnLimit";
            this.btnLimit.Size = new System.Drawing.Size(48, 21);
            this.btnLimit.TabIndex = 1;
            this.btnLimit.Text = "Limit";
            this.btnLimit.UseVisualStyleBackColor = true;
            this.btnLimit.Click += new System.EventHandler(this.btnLimit_Click);
            // 
            // edtLimit
            // 
            this.edtLimit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtLimit.AttributeName = null;
            this.edtLimit.BackColor = System.Drawing.Color.Honeydew;
            this.edtLimit.Location = new System.Drawing.Point(52, 0);
            this.edtLimit.Multiline = true;
            this.edtLimit.Name = "edtLimit";
            this.edtLimit.ReadOnly = true;
            this.edtLimit.Size = new System.Drawing.Size(102, 20);
            this.edtLimit.TabIndex = 2;
            this.edtLimit.Value = null;
            this.edtLimit.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // LimitSimpleControl
            // 
            this.Controls.Add(this.edtLimit);
            this.Controls.Add(this.btnLimit);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "LimitSimpleControl";
            this.Size = new System.Drawing.Size(154, 20);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLimit;
        private awb.AWBTextBox edtLimit;
    }
}
