/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls.limit
{
    partial class ExpectedLimitForm
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
            this.expectedLimitControl = new ATMLCommonLibrary.controls.limit.ExpectedLimitControl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.expectedLimitControl);
            this.panel1.Size = new System.Drawing.Size(632, 575);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(570, 593);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(489, 593);
            // 
            // lblDenoteRequiredField
            // 
            this.lblDenoteRequiredField.Location = new System.Drawing.Point(1, 604);
            // 
            // expectedLimitControl
            // 
            this.expectedLimitControl.BackColor = System.Drawing.Color.AliceBlue;
            this.expectedLimitControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.expectedLimitControl.Location = new System.Drawing.Point(0, 0);
            this.expectedLimitControl.MinimumSize = new System.Drawing.Size(541, 517);
            this.expectedLimitControl.Name = "expectedLimitControl";
            this.expectedLimitControl.Size = new System.Drawing.Size(632, 575);
            this.expectedLimitControl.TabIndex = 0;
            // 
            // ExpectedLimitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 620);
            this.Location = new System.Drawing.Point(0, 0);
            this.MinimumSize = new System.Drawing.Size(600, 629);
            this.Name = "ExpectedLimitForm";
            this.Text = "Expected Limit";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ExpectedLimitControl expectedLimitControl;
    }
}
