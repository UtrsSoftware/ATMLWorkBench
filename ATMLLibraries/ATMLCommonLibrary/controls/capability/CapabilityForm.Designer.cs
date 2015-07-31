/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.forms
{
    partial class CapabilityForm
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
            this.capabilityControl = new ATMLCommonLibrary.controls.capability.CapabilityControl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.capabilityControl);
            this.panel1.Location = new System.Drawing.Point(9, 9);
            this.panel1.Size = new System.Drawing.Size(543, 524);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(477, 537);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(396, 537);
            // 
            // lblDenoteRequiredField
            // 
            this.lblDenoteRequiredField.Location = new System.Drawing.Point(1, 550);
            // 
            // capabilityControl
            // 
            this.capabilityControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.capabilityControl.Location = new System.Drawing.Point(0, 0);
            this.capabilityControl.Name = "capabilityControl";
            this.capabilityControl.Size = new System.Drawing.Size(543, 524);
            this.capabilityControl.TabIndex = 0;
            this.capabilityControl.Load += new System.EventHandler(this.capabilityControl_Load);
            // 
            // CapabilityForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 565);
            this.Name = "CapabilityForm";
            this.Text = "Capability";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private controls.capability.CapabilityControl capabilityControl;
    }
}