/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls.bus
{
    partial class USBControl
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
            this.versionIdentifierControl = new ATMLCommonLibrary.controls.hardware.VersionIdentifierControl();
            this.SuspendLayout();
            // 
            // edtDefaultAddress
            // 
            this.edtDefaultAddress.Size = new System.Drawing.Size(273, 20);
            // 
            // versionIdentifierControl
            // 
            this.versionIdentifierControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.versionIdentifierControl.Location = new System.Drawing.Point(7, 24);
            this.versionIdentifierControl.Name = "versionIdentifierControl";
            this.versionIdentifierControl.SchemaTypeName = null;
            this.versionIdentifierControl.Size = new System.Drawing.Size(385, 70);
            this.versionIdentifierControl.TabIndex = 8;
            this.versionIdentifierControl.TargetNamespace = null;
            // 
            // USBControl
            // 
            this.Controls.Add(this.versionIdentifierControl);
            this.Name = "USBControl";
            this.Size = new System.Drawing.Size(392, 100);
            this.Controls.SetChildIndex(this.versionIdentifierControl, 0);
            this.Controls.SetChildIndex(this.edtDefaultAddress, 0);
            this.Controls.SetChildIndex(this.lblDefaultAddress, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private hardware.VersionIdentifierControl versionIdentifierControl;
    }
}
