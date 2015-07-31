/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

namespace ATMLCommonLibrary.controls.driver.platform
{
    partial class DriverPlatformProcessorControl
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
            this.edtSpeed = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.SuspendLayout();
            // 
            // helpLabel1
            // 
            this.helpLabel1.AutoSize = true;
            this.helpLabel1.HelpMessageKey = "Driver.Platform.Processor";
            this.helpLabel1.Location = new System.Drawing.Point(12, 9);
            this.helpLabel1.Name = "helpLabel1";
            this.helpLabel1.RequiredField = false;
            this.helpLabel1.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel1.Size = new System.Drawing.Size(138, 13);
            this.helpLabel1.TabIndex = 0;
            this.helpLabel1.Text = "Processor (Minimum Speed)";
            // 
            // edtSpeed
            // 
            this.edtSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtSpeed.AttributeName = null;
            this.edtSpeed.DataLookupKey = null;
            this.edtSpeed.Location = new System.Drawing.Point(156, 6);
            this.edtSpeed.Name = "edtSpeed";
            this.edtSpeed.Size = new System.Drawing.Size(144, 20);
            this.edtSpeed.TabIndex = 1;
            this.edtSpeed.Value = null;
            this.edtSpeed.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // DriverPlatformProcessorControl
            // 
            this.Controls.Add(this.edtSpeed);
            this.Controls.Add(this.helpLabel1);
            this.Name = "DriverPlatformProcessorControl";
            this.Size = new System.Drawing.Size(309, 30);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HelpLabel helpLabel1;
        private awb.AWBTextBox edtSpeed;
    }
}
