/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls.bus
{
    partial class PXIeControl
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
            this.helpLabel7 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.edtSlots)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSlotWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMemorySize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLanes)).BeginInit();
            this.SuspendLayout();
            // 
            // dynamicCurrentControl
            // 
            this.dynamicCurrentControl.Location = new System.Drawing.Point(13, 92);
            // 
            // peakCurrentControl
            // 
            this.peakCurrentControl.Location = new System.Drawing.Point(207, 92);
            // 
            // supportedClockServiceControl
            // 
            this.supportedClockServiceControl.Location = new System.Drawing.Point(13, 253);
            this.supportedClockServiceControl.Size = new System.Drawing.Size(177, 133);
            // 
            // helpLabel3
            // 
            this.helpLabel3.Location = new System.Drawing.Point(233, 263);
            // 
            // edtSlots
            // 
            this.edtSlots.Location = new System.Drawing.Point(267, 260);
            // 
            // helpLabel4
            // 
            this.helpLabel4.Location = new System.Drawing.Point(215, 289);
            // 
            // cmbSlotSize
            // 
            this.cmbSlotSize.Location = new System.Drawing.Point(267, 287);
            // 
            // edtSlotWeight
            // 
            this.edtSlotWeight.Location = new System.Drawing.Point(267, 314);
            // 
            // helpLabel5
            // 
            this.helpLabel5.Location = new System.Drawing.Point(201, 316);
            // 
            // edtMemorySize
            // 
            this.edtMemorySize.Location = new System.Drawing.Point(267, 340);
            // 
            // helpLabel6
            // 
            this.helpLabel6.Location = new System.Drawing.Point(196, 343);
            // 
            // lblVendorId
            // 
            this.lblVendorId.Location = new System.Drawing.Point(13, 13);
            // 
            // lblDeviceId
            // 
            this.lblDeviceId.Location = new System.Drawing.Point(13, 39);
            // 
            // edtDeviceId
            // 
            this.edtDeviceId.Location = new System.Drawing.Point(93, 39);
            // 
            // edtLanes
            // 
            this.edtLanes.Location = new System.Drawing.Point(267, 366);
            this.edtLanes.Name = "edtLanes";
            this.edtLanes.Size = new System.Drawing.Size(100, 20);
            this.edtLanes.TabIndex = 18;
            this.edtLanes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // helpLabel7
            // 
            this.helpLabel7.AutoSize = true;
            this.helpLabel7.HelpMessageKey = "PXIe.Lanes";
            this.helpLabel7.Location = new System.Drawing.Point(228, 368);
            this.helpLabel7.Name = "helpLabel7";
            this.helpLabel7.RequiredField = false;
            this.helpLabel7.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel7.Size = new System.Drawing.Size(36, 13);
            this.helpLabel7.TabIndex = 17;
            this.helpLabel7.Text = "Lanes";
            // 
            // PXIeControl
            // 
            this.Controls.Add(this.edtLanes);
            this.Controls.Add(this.helpLabel7);
            this.Name = "PXIeControl";
            this.Size = new System.Drawing.Size(397, 404);
            this.Controls.SetChildIndex(this.lblDefaultAddress, 0);
            this.Controls.SetChildIndex(this.edtDefaultAddress, 0);
            this.Controls.SetChildIndex(this.edtVendorId, 0);
            this.Controls.SetChildIndex(this.lblVendorId, 0);
            this.Controls.SetChildIndex(this.edtDeviceId, 0);
            this.Controls.SetChildIndex(this.lblDeviceId, 0);
            this.Controls.SetChildIndex(this.dynamicCurrentControl, 0);
            this.Controls.SetChildIndex(this.peakCurrentControl, 0);
            this.Controls.SetChildIndex(this.supportedClockServiceControl, 0);
            this.Controls.SetChildIndex(this.helpLabel3, 0);
            this.Controls.SetChildIndex(this.edtSlots, 0);
            this.Controls.SetChildIndex(this.helpLabel4, 0);
            this.Controls.SetChildIndex(this.cmbSlotSize, 0);
            this.Controls.SetChildIndex(this.helpLabel5, 0);
            this.Controls.SetChildIndex(this.edtSlotWeight, 0);
            this.Controls.SetChildIndex(this.helpLabel6, 0);
            this.Controls.SetChildIndex(this.edtMemorySize, 0);
            this.Controls.SetChildIndex(this.helpLabel7, 0);
            this.Controls.SetChildIndex(this.edtLanes, 0);
            ((System.ComponentModel.ISupportInitialize)(this.edtSlots)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSlotWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMemorySize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLanes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.NumericUpDown edtLanes;
        protected HelpLabel helpLabel7;
    }
}
