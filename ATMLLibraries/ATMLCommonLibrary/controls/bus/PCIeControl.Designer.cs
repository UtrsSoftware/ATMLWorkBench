/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls.bus
{
    partial class PCIeControl
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
            this.edtLanes = new System.Windows.Forms.NumericUpDown();
            this.lblPCIeLanes = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.edtLanes)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDefaultAddress
            // 
            this.lblDefaultAddress.TabIndex = 4;
            // 
            // edtDefaultAddress
            // 
            this.edtDefaultAddress.TabIndex = 5;
            // 
            // edtLanes
            // 
            this.edtLanes.Location = new System.Drawing.Point(93, 87);
            this.edtLanes.Name = "edtLanes";
            this.edtLanes.Size = new System.Drawing.Size(76, 20);
            this.edtLanes.TabIndex = 7;
            this.edtLanes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblPCIeLanes
            // 
            this.lblPCIeLanes.AutoSize = true;
            this.lblPCIeLanes.HelpMessageKey = "PCIe.Lanes";
            this.lblPCIeLanes.Location = new System.Drawing.Point(10, 89);
            this.lblPCIeLanes.Name = "lblPCIeLanes";
            this.lblPCIeLanes.RequiredField = false;
            this.lblPCIeLanes.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPCIeLanes.Size = new System.Drawing.Size(36, 13);
            this.lblPCIeLanes.TabIndex = 6;
            this.lblPCIeLanes.Text = "Lanes";
            // 
            // PCIeControl
            // 
            this.Controls.Add(this.edtLanes);
            this.Controls.Add(this.lblPCIeLanes);
            this.Name = "PCIeControl";
            this.Size = new System.Drawing.Size(289, 116);
            this.Controls.SetChildIndex(this.edtDefaultAddress, 0);
            this.Controls.SetChildIndex(this.lblDefaultAddress, 0);
            this.Controls.SetChildIndex(this.edtVendorId, 0);
            this.Controls.SetChildIndex(this.lblVendorId, 0);
            this.Controls.SetChildIndex(this.edtDeviceId, 0);
            this.Controls.SetChildIndex(this.lblDeviceId, 0);
            this.Controls.SetChildIndex(this.lblPCIeLanes, 0);
            this.Controls.SetChildIndex(this.edtLanes, 0);
            ((System.ComponentModel.ISupportInitialize)(this.edtLanes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.NumericUpDown edtLanes;
        protected HelpLabel lblPCIeLanes;
    }
}
