/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls.limit
{
    partial class SingleLimitForm
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
            this.singleLimitControl = new ATMLCommonLibrary.controls.limit.SingleLimitControl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.singleLimitControl);
            this.panel1.Size = new System.Drawing.Size(646, 546);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(584, 564);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(503, 564);
            // 
            // lblDenoteRequiredField
            // 
            this.lblDenoteRequiredField.Location = new System.Drawing.Point(1, 575);
            // 
            // singleLimitControl
            // 
            this.singleLimitControl.BackColor = System.Drawing.Color.AliceBlue;
            this.singleLimitControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.singleLimitControl.Location = new System.Drawing.Point(0, 0);
            this.singleLimitControl.MinimumSize = new System.Drawing.Size(541, 517);
            this.singleLimitControl.Name = "singleLimitControl";
            this.singleLimitControl.Size = new System.Drawing.Size(646, 546);
            this.singleLimitControl.TabIndex = 0;
            // 
            // SingleLimitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 591);
            this.Location = new System.Drawing.Point(0, 0);
            this.MinimumSize = new System.Drawing.Size(600, 629);
            this.Name = "SingleLimitForm";
            this.Text = "Single Limit";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SingleLimitControl singleLimitControl;
    }
}
