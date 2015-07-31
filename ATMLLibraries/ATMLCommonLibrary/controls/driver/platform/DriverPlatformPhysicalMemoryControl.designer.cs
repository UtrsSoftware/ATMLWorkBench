/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

namespace ATMLCommonLibrary.controls.driver.platform
{
    partial class DriverPlatformPhysicalMemoryControl
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
            this.helpLabel1 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtMinimum = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.SuspendLayout();
            // 
            // helpLabel1
            // 
            this.helpLabel1.AutoSize = true;
            this.helpLabel1.HelpMessageKey = "Driver.Platform.Memory";
            this.helpLabel1.Location = new System.Drawing.Point(9, 10);
            this.helpLabel1.Name = "helpLabel1";
            this.helpLabel1.RequiredField = false;
            this.helpLabel1.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel1.Size = new System.Drawing.Size(138, 13);
            this.helpLabel1.TabIndex = 0;
            this.helpLabel1.Text = "Memory (Minimum Capacity)";
            // 
            // edtMinimum
            // 
            this.edtMinimum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtMinimum.AttributeName = null;
            this.edtMinimum.DataLookupKey = null;
            this.edtMinimum.Location = new System.Drawing.Point(156, 7);
            this.edtMinimum.Name = "edtMinimum";
            this.edtMinimum.Size = new System.Drawing.Size(144, 20);
            this.edtMinimum.TabIndex = 1;
            this.edtMinimum.Value = null;
            this.edtMinimum.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // DriverPlatformPhysicalMemoryControl
            // 
            this.Controls.Add(this.edtMinimum);
            this.Controls.Add(this.helpLabel1);
            this.Name = "DriverPlatformPhysicalMemoryControl";
            this.Size = new System.Drawing.Size(308, 34);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HelpLabel helpLabel1;
        private awb.AWBTextBox edtMinimum;
    }
}
