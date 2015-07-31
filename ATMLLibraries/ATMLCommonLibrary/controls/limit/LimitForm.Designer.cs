/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls.limit
{
    partial class LimitForm
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
            this.limitControl = new ATMLCommonLibrary.controls.limit.LimitControl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.limitControl);
            this.panel1.Size = new System.Drawing.Size(630, 520);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(568, 538);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(487, 538);
            // 
            // lblDenoteRequiredField
            // 
            this.lblDenoteRequiredField.Location = new System.Drawing.Point(1, 549);
            // 
            // limitControl
            // 
            this.limitControl.BackColor = System.Drawing.Color.AliceBlue;
            this.limitControl.DefaultComparitor = -1;
            this.limitControl.DefaultLimitType = -1;
            this.limitControl.DefaultStandardUnit = null;
            this.limitControl.DefaultValue = null;
            this.limitControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.limitControl.HasErrors = false;
            this.limitControl.HelpKeyWord = null;
            this.limitControl.LastError = null;
            this.limitControl.Location = new System.Drawing.Point(0, 0);
            this.limitControl.Name = "limitControl";
            this.limitControl.SchemaTypeName = null;
            this.limitControl.Size = new System.Drawing.Size(630, 520);
            this.limitControl.TabIndex = 0;
            this.limitControl.TargetNamespace = null;
            // 
            // LimitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 565);
            this.Location = new System.Drawing.Point(0, 0);
            this.MinimumSize = new System.Drawing.Size(579, 603);
            this.Name = "LimitForm";
            this.Text = "Limit";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LimitControl limitControl;
    }
}
