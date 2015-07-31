/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

namespace ATMLCommonLibrary.controls.controller
{
    partial class ControllerOperatingSystemsForm
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
            this.controllerOperatingSystemControl1 = new ATMLCommonLibrary.controls.controller.ControllerOperatingSystemControl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.controllerOperatingSystemControl1);
            this.panel1.Size = new System.Drawing.Size(528, 515);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(466, 533);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(385, 533);
            // 
            // lblDenoteRequiredField
            // 
            this.lblDenoteRequiredField.Location = new System.Drawing.Point(1, 544);
            // 
            // controllerOperatingSystemControl1
            // 
            this.controllerOperatingSystemControl1.BackColor = System.Drawing.Color.AliceBlue;
            this.controllerOperatingSystemControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controllerOperatingSystemControl1.Location = new System.Drawing.Point(0, 0);
            this.controllerOperatingSystemControl1.Name = "controllerOperatingSystemControl1";
            this.controllerOperatingSystemControl1.Size = new System.Drawing.Size(528, 515);
            this.controllerOperatingSystemControl1.TabIndex = 0;
            // 
            // ControllerOperatingSystemsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 560);
            this.Name = "ControllerOperatingSystemsForm";
            this.Text = "Operating Systems";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ControllerOperatingSystemControl controllerOperatingSystemControl1;

    }
}