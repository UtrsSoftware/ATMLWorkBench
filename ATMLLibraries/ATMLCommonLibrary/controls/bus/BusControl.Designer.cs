/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls.bus
{
    partial class BusControl
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
            this.lblDefaultAddress = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtDefaultAddress = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.SuspendLayout();
            // 
            // lblDefaultAddress
            // 
            this.lblDefaultAddress.AutoSize = true;
            this.lblDefaultAddress.HelpMessageKey = "Bus.DefaultAddress";
            this.lblDefaultAddress.Location = new System.Drawing.Point(10, 13);
            this.lblDefaultAddress.Name = "lblDefaultAddress";
            this.lblDefaultAddress.RequiredField = false;
            this.lblDefaultAddress.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDefaultAddress.Size = new System.Drawing.Size(82, 13);
            this.lblDefaultAddress.TabIndex = 6;
            this.lblDefaultAddress.Text = "Default Address";
            // 
            // edtDefaultAddress
            // 
            this.edtDefaultAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtDefaultAddress.Location = new System.Drawing.Point(93, 10);
            this.edtDefaultAddress.Name = "edtDefaultAddress";
            this.edtDefaultAddress.Size = new System.Drawing.Size(170, 20);
            this.edtDefaultAddress.TabIndex = 7;
            this.edtDefaultAddress.Value = null;
            this.edtDefaultAddress.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // BusControl
            // 
            this.Controls.Add(this.lblDefaultAddress);
            this.Controls.Add(this.edtDefaultAddress);
            this.Name = "BusControl";
            this.Size = new System.Drawing.Size(289, 37);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected HelpLabel lblDefaultAddress;
        protected awb.AWBTextBox edtDefaultAddress;
    }
}
