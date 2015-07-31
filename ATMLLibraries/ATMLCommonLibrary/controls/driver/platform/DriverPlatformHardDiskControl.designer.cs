/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

namespace ATMLCommonLibrary.controls.driver.platform
{
    partial class DriverPlatformHardDiskControl
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
            this.edtHardDisk = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.helpLabel1 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.SuspendLayout();
            // 
            // edtHardDisk
            // 
            this.edtHardDisk.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtHardDisk.AttributeName = null;
            this.edtHardDisk.DataLookupKey = null;
            this.edtHardDisk.Location = new System.Drawing.Point(156, 8);
            this.edtHardDisk.Name = "edtHardDisk";
            this.edtHardDisk.Size = new System.Drawing.Size(144, 20);
            this.edtHardDisk.TabIndex = 0;
            this.edtHardDisk.Value = null;
            this.edtHardDisk.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // helpLabel1
            // 
            this.helpLabel1.AutoSize = true;
            this.helpLabel1.HelpMessageKey = "Driver.Platform.HardDisk";
            this.helpLabel1.Location = new System.Drawing.Point(3, 11);
            this.helpLabel1.Name = "helpLabel1";
            this.helpLabel1.RequiredField = false;
            this.helpLabel1.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel1.Size = new System.Drawing.Size(148, 13);
            this.helpLabel1.TabIndex = 1;
            this.helpLabel1.Text = "Hard Disk (Minimum Capacity)";
            // 
            // DriverPlatformHardDiskControl
            // 
            this.Controls.Add(this.helpLabel1);
            this.Controls.Add(this.edtHardDisk);
            this.Name = "DriverPlatformHardDiskControl";
            this.Size = new System.Drawing.Size(311, 35);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private awb.AWBTextBox edtHardDisk;
        private HelpLabel helpLabel1;
    }
}
