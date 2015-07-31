/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

namespace ATMLCommonLibrary.controls.driver.platform
{
    partial class DriverPlatformOperatingSystemForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DriverPlatformOperatingSystemForm));
            this._driverPlatformOperatingSystemControlDriverPlatformOperatingSystemControl1 = new DriverPlatformOperatingSystemControl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._driverPlatformOperatingSystemControlDriverPlatformOperatingSystemControl1);
            this.panel1.Size = new System.Drawing.Size(412, 104);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(350, 122);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(269, 122);
            // 
            // lblDenoteRequiredField
            // 
            this.lblDenoteRequiredField.Location = new System.Drawing.Point(1, 133);
            // 
            // _driverPlatformOperatingSystemControlDriverPlatformOperatingSystemControl1
            // 
            this._driverPlatformOperatingSystemControlDriverPlatformOperatingSystemControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._driverPlatformOperatingSystemControlDriverPlatformOperatingSystemControl1.Location = new System.Drawing.Point(0, 0);
            this._driverPlatformOperatingSystemControlDriverPlatformOperatingSystemControl1.Name = "_driverPlatformOperatingSystemControlDriverPlatformOperatingSystemControl1";
            this._driverPlatformOperatingSystemControlDriverPlatformOperatingSystemControl1.SchemaTypeName = null;
            this._driverPlatformOperatingSystemControlDriverPlatformOperatingSystemControl1.Size = new System.Drawing.Size(412, 104);
            this._driverPlatformOperatingSystemControlDriverPlatformOperatingSystemControl1.TabIndex = 0;
            this._driverPlatformOperatingSystemControlDriverPlatformOperatingSystemControl1.TargetNamespace = null;
            // 
            // DriverPlatformOperatingSystemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 149);
            this.Name = "DriverPlatformOperatingSystemForm";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DriverPlatformOperatingSystemControl _driverPlatformOperatingSystemControlDriverPlatformOperatingSystemControl1;
    }
}
