/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

namespace ATMLCommonLibrary.controls.limit
{
    partial class LimitMaskValueForm
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
            this.limitMaskValueControl1 = new ATMLCommonLibrary.controls.limit.LimitMaskValueControl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.limitMaskValueControl1);
            this.panel1.Size = new System.Drawing.Size(594, 550);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(532, 568);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(451, 568);
            // 
            // lblDenoteRequiredField
            // 
            this.lblDenoteRequiredField.Location = new System.Drawing.Point(1, 579);
            // 
            // limitMaskValueControl1
            // 
            this.limitMaskValueControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.limitMaskValueControl1.Location = new System.Drawing.Point(0, 0);
            this.limitMaskValueControl1.MinimumSize = new System.Drawing.Size(595, 550);
            this.limitMaskValueControl1.Name = "limitMaskValueControl1";
            this.limitMaskValueControl1.Size = new System.Drawing.Size(595, 550);
            this.limitMaskValueControl1.TabIndex = 0;
            // 
            // LimitMaskValueForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 595);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "LimitMaskValueForm";
            this.Text = "Limit Mask Value";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LimitMaskValueControl limitMaskValueControl1;
    }
}