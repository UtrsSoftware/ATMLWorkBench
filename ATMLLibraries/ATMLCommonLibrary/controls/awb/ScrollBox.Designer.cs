/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

namespace ATMLCommonLibrary.controls.awb
{
    partial class ScrollBox
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
            this.edtValue = new System.Windows.Forms.TextBox();
            this.btnDrop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // edtValue
            // 
            this.edtValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtValue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.edtValue.Location = new System.Drawing.Point(3, 2);
            this.edtValue.Multiline = true;
            this.edtValue.Name = "edtValue";
            this.edtValue.Size = new System.Drawing.Size(20, 14);
            this.edtValue.TabIndex = 0;
            this.edtValue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.edtValue_KeyDown);
            this.edtValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.edtValue_KeyPress);
            this.edtValue.KeyUp += new System.Windows.Forms.KeyEventHandler(this.edtValue_KeyUp);
            // 
            // btnDrop
            // 
            this.btnDrop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDrop.BackColor = System.Drawing.Color.Transparent;
            this.btnDrop.FlatAppearance.BorderSize = 0;
            this.btnDrop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDrop.Location = new System.Drawing.Point(26, 0);
            this.btnDrop.Name = "btnDrop";
            this.btnDrop.Size = new System.Drawing.Size(5, 18);
            this.btnDrop.TabIndex = 1;
            this.btnDrop.TabStop = false;
            this.btnDrop.UseVisualStyleBackColor = false;
            this.btnDrop.Paint += new System.Windows.Forms.PaintEventHandler(this.btnDrop_Paint);
            this.btnDrop.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnDrop_MouseClick);
            // 
            // ScrollBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnDrop);
            this.Controls.Add(this.edtValue);
            this.MaximumSize = new System.Drawing.Size(600, 20);
            this.MinimumSize = new System.Drawing.Size(10, 16);
            this.Name = "ScrollBox";
            this.Size = new System.Drawing.Size(34, 18);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ScrollBox_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox edtValue;
        private System.Windows.Forms.Button btnDrop;
    }
}
