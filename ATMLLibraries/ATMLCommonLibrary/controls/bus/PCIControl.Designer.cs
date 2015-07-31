/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls.bus
{
    partial class PCIControl
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
            this.lblDeviceId = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtDeviceId = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.lblVendorId = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtVendorId = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.SuspendLayout();
            // 
            // lblDefaultAddress
            // 
            this.lblDefaultAddress.Location = new System.Drawing.Point(10, 65);
            // 
            // edtDefaultAddress
            // 
            this.edtDefaultAddress.Location = new System.Drawing.Point(93, 62);
            // 
            // lblDeviceId
            // 
            this.lblDeviceId.AutoSize = true;
            this.lblDeviceId.HelpMessageKey = "PCI.DeviceId";
            this.lblDeviceId.Location = new System.Drawing.Point(10, 39);
            this.lblDeviceId.Name = "lblDeviceId";
            this.lblDeviceId.RequiredField = false;
            this.lblDeviceId.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeviceId.Size = new System.Drawing.Size(53, 13);
            this.lblDeviceId.TabIndex = 2;
            this.lblDeviceId.Text = "Device Id";
            // 
            // edtDeviceId
            // 
            this.edtDeviceId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtDeviceId.Location = new System.Drawing.Point(93, 36);
            this.edtDeviceId.Name = "edtDeviceId";
            this.edtDeviceId.Size = new System.Drawing.Size(171, 20);
            this.edtDeviceId.TabIndex = 3;
            this.edtDeviceId.Value = null;
            this.edtDeviceId.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // lblVendorId
            // 
            this.lblVendorId.AutoSize = true;
            this.lblVendorId.HelpMessageKey = "PCI.VendorId";
            this.lblVendorId.Location = new System.Drawing.Point(10, 13);
            this.lblVendorId.Name = "lblVendorId";
            this.lblVendorId.RequiredField = false;
            this.lblVendorId.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVendorId.Size = new System.Drawing.Size(53, 13);
            this.lblVendorId.TabIndex = 0;
            this.lblVendorId.Text = "Vendor Id";
            // 
            // edtVendorId
            // 
            this.edtVendorId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtVendorId.Location = new System.Drawing.Point(93, 10);
            this.edtVendorId.Name = "edtVendorId";
            this.edtVendorId.Size = new System.Drawing.Size(171, 20);
            this.edtVendorId.TabIndex = 1;
            this.edtVendorId.Value = null;
            this.edtVendorId.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // PCIControl
            // 
            this.Controls.Add(this.lblDeviceId);
            this.Controls.Add(this.edtDeviceId);
            this.Controls.Add(this.lblVendorId);
            this.Controls.Add(this.edtVendorId);
            this.Name = "PCIControl";
            this.Size = new System.Drawing.Size(289, 90);
            this.Controls.SetChildIndex(this.edtVendorId, 0);
            this.Controls.SetChildIndex(this.lblVendorId, 0);
            this.Controls.SetChildIndex(this.edtDeviceId, 0);
            this.Controls.SetChildIndex(this.lblDeviceId, 0);
            this.Controls.SetChildIndex(this.edtDefaultAddress, 0);
            this.Controls.SetChildIndex(this.lblDefaultAddress, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected awb.AWBTextBox edtVendorId;
        protected HelpLabel lblVendorId;
        protected HelpLabel lblDeviceId;
        protected awb.AWBTextBox edtDeviceId;
    }
}
