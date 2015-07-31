/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

namespace ATMLCommonLibrary.controls.driver.platform
{
    partial class DriverPlatformOperatingSystemControl
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
            this.edtServicePack = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.SuspendLayout();
            // 
            // helpLabel1
            // 
            this.helpLabel1.AutoSize = true;
            this.helpLabel1.HelpMessageKey = "DriverPlatformOperatingSystem.ServicePack";
            this.helpLabel1.Location = new System.Drawing.Point(10, 68);
            this.helpLabel1.Name = "helpLabel1";
            this.helpLabel1.RequiredField = false;
            this.helpLabel1.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel1.Size = new System.Drawing.Size(74, 13);
            this.helpLabel1.TabIndex = 6;
            this.helpLabel1.Text = "Service Pack:";
            // 
            // edtServicePack
            // 
            this.edtServicePack.AttributeName = null;
            this.edtServicePack.Location = new System.Drawing.Point(86, 65);
            this.edtServicePack.Name = "edtServicePack";
            this.edtServicePack.Size = new System.Drawing.Size(293, 20);
            this.edtServicePack.TabIndex = 7;
            this.edtServicePack.Value = null;
            this.edtServicePack.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // DriverPlatformOperatingSystemControl
            // 
            this.Controls.Add(this.edtServicePack);
            this.Controls.Add(this.helpLabel1);
            this.Name = "DriverPlatformOperatingSystemControl";
            this.Size = new System.Drawing.Size(405, 96);
            this.Controls.SetChildIndex(this.helpLabel1, 0);
            this.Controls.SetChildIndex(this.edtServicePack, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HelpLabel helpLabel1;
        private awb.AWBTextBox edtServicePack;
    }
}
