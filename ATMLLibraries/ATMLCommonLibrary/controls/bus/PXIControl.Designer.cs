/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls.bus
{
    partial class PXIControl
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
            this.dynamicCurrentControl = new ATMLCommonLibrary.PXIBackplaneVoltagesControl();
            this.peakCurrentControl = new ATMLCommonLibrary.PXIBackplaneVoltagesControl();
            this.supportedClockServiceControl = new ATMLCommonLibrary.controls.bus.SupportedClockSourcesControl();
            this.helpLabel3 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtSlots = new System.Windows.Forms.NumericUpDown();
            this.helpLabel4 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.cmbSlotSize = new System.Windows.Forms.ComboBox();
            this.edtSlotWeight = new System.Windows.Forms.NumericUpDown();
            this.helpLabel5 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtMemorySize = new System.Windows.Forms.NumericUpDown();
            this.helpLabel6 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.edtSlots)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSlotWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMemorySize)).BeginInit();
            this.SuspendLayout();
            // 
            // edtVendorId
            // 
            this.edtVendorId.Location = new System.Drawing.Point(93, 13);
            this.edtVendorId.Size = new System.Drawing.Size(274, 20);
            // 
            // lblVendorId
            // 
            this.lblVendorId.Location = new System.Drawing.Point(9, 16);
            // 
            // lblDeviceId
            // 
            this.lblDeviceId.Location = new System.Drawing.Point(9, 41);
            // 
            // edtDeviceId
            // 
            this.edtDeviceId.Location = new System.Drawing.Point(93, 38);
            this.edtDeviceId.Size = new System.Drawing.Size(274, 20);
            // 
            // lblDefaultAddress
            // 
            this.lblDefaultAddress.Location = new System.Drawing.Point(9, 67);
            this.lblDefaultAddress.TabIndex = 4;
            // 
            // edtDefaultAddress
            // 
            this.edtDefaultAddress.Location = new System.Drawing.Point(93, 64);
            this.edtDefaultAddress.Size = new System.Drawing.Size(274, 20);
            this.edtDefaultAddress.TabIndex = 5;
            // 
            // dynamicCurrentControl
            // 
            this.dynamicCurrentControl.Location = new System.Drawing.Point(13, 88);
            this.dynamicCurrentControl.Name = "dynamicCurrentControl";
            this.dynamicCurrentControl.SchemaTypeName = null;
            this.dynamicCurrentControl.Size = new System.Drawing.Size(177, 143);
            this.dynamicCurrentControl.TabIndex = 6;
            this.dynamicCurrentControl.TargetNamespace = null;
            this.dynamicCurrentControl.Title = "Dynamic Current";
            // 
            // peakCurrentControl
            // 
            this.peakCurrentControl.Location = new System.Drawing.Point(207, 88);
            this.peakCurrentControl.Name = "peakCurrentControl";
            this.peakCurrentControl.SchemaTypeName = null;
            this.peakCurrentControl.Size = new System.Drawing.Size(177, 143);
            this.peakCurrentControl.TabIndex = 7;
            this.peakCurrentControl.TargetNamespace = null;
            this.peakCurrentControl.Title = "Peak Current";
            // 
            // supportedClockServiceControl
            // 
            this.supportedClockServiceControl.Location = new System.Drawing.Point(13, 249);
            this.supportedClockServiceControl.Name = "supportedClockServiceControl";
            this.supportedClockServiceControl.SchemaTypeName = null;
            this.supportedClockServiceControl.Size = new System.Drawing.Size(177, 116);
            this.supportedClockServiceControl.TabIndex = 8;
            this.supportedClockServiceControl.TargetNamespace = null;
            this.supportedClockServiceControl.Title = "Supported Clock Services";
            // 
            // helpLabel3
            // 
            this.helpLabel3.AutoSize = true;
            this.helpLabel3.HelpMessageKey = "PXI.Slots";
            this.helpLabel3.Location = new System.Drawing.Point(233, 259);
            this.helpLabel3.Name = "helpLabel3";
            this.helpLabel3.RequiredField = false;
            this.helpLabel3.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel3.Size = new System.Drawing.Size(30, 13);
            this.helpLabel3.TabIndex = 9;
            this.helpLabel3.Text = "Slots";
            // 
            // edtSlots
            // 
            this.edtSlots.Location = new System.Drawing.Point(267, 256);
            this.edtSlots.Name = "edtSlots";
            this.edtSlots.Size = new System.Drawing.Size(100, 20);
            this.edtSlots.TabIndex = 10;
            this.edtSlots.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // helpLabel4
            // 
            this.helpLabel4.AutoSize = true;
            this.helpLabel4.HelpMessageKey = "PXI.SlotSize";
            this.helpLabel4.Location = new System.Drawing.Point(215, 285);
            this.helpLabel4.Name = "helpLabel4";
            this.helpLabel4.RequiredField = false;
            this.helpLabel4.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel4.Size = new System.Drawing.Size(48, 13);
            this.helpLabel4.TabIndex = 11;
            this.helpLabel4.Text = "Slot Size";
            // 
            // cmbSlotSize
            // 
            this.cmbSlotSize.FormattingEnabled = true;
            this.cmbSlotSize.Location = new System.Drawing.Point(267, 283);
            this.cmbSlotSize.Name = "cmbSlotSize";
            this.cmbSlotSize.Size = new System.Drawing.Size(100, 21);
            this.cmbSlotSize.TabIndex = 12;
            // 
            // edtSlotWeight
            // 
            this.edtSlotWeight.DecimalPlaces = 4;
            this.edtSlotWeight.Location = new System.Drawing.Point(267, 310);
            this.edtSlotWeight.Name = "edtSlotWeight";
            this.edtSlotWeight.Size = new System.Drawing.Size(100, 20);
            this.edtSlotWeight.TabIndex = 14;
            this.edtSlotWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // helpLabel5
            // 
            this.helpLabel5.AutoSize = true;
            this.helpLabel5.HelpMessageKey = "PXI.SlotWeight";
            this.helpLabel5.Location = new System.Drawing.Point(201, 312);
            this.helpLabel5.Name = "helpLabel5";
            this.helpLabel5.RequiredField = false;
            this.helpLabel5.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel5.Size = new System.Drawing.Size(62, 13);
            this.helpLabel5.TabIndex = 13;
            this.helpLabel5.Text = "Slot Weight";
            // 
            // edtMemorySize
            // 
            this.edtMemorySize.Location = new System.Drawing.Point(267, 336);
            this.edtMemorySize.Name = "edtMemorySize";
            this.edtMemorySize.Size = new System.Drawing.Size(100, 20);
            this.edtMemorySize.TabIndex = 16;
            this.edtMemorySize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // helpLabel6
            // 
            this.helpLabel6.AutoSize = true;
            this.helpLabel6.HelpMessageKey = "PXI.MemorySize";
            this.helpLabel6.Location = new System.Drawing.Point(196, 339);
            this.helpLabel6.Name = "helpLabel6";
            this.helpLabel6.RequiredField = false;
            this.helpLabel6.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel6.Size = new System.Drawing.Size(67, 13);
            this.helpLabel6.TabIndex = 15;
            this.helpLabel6.Text = "Memory Size";
            // 
            // PXIControl
            // 
            this.Controls.Add(this.edtMemorySize);
            this.Controls.Add(this.helpLabel6);
            this.Controls.Add(this.edtSlotWeight);
            this.Controls.Add(this.helpLabel5);
            this.Controls.Add(this.cmbSlotSize);
            this.Controls.Add(this.helpLabel4);
            this.Controls.Add(this.edtSlots);
            this.Controls.Add(this.helpLabel3);
            this.Controls.Add(this.supportedClockServiceControl);
            this.Controls.Add(this.peakCurrentControl);
            this.Controls.Add(this.dynamicCurrentControl);
            this.Name = "PXIControl";
            this.Size = new System.Drawing.Size(397, 374);
            this.Controls.SetChildIndex(this.edtDefaultAddress, 0);
            this.Controls.SetChildIndex(this.lblDefaultAddress, 0);
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
            ((System.ComponentModel.ISupportInitialize)(this.edtSlots)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSlotWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMemorySize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected PXIBackplaneVoltagesControl dynamicCurrentControl;
        protected PXIBackplaneVoltagesControl peakCurrentControl;
        protected SupportedClockSourcesControl supportedClockServiceControl;
        protected HelpLabel helpLabel3;
        protected System.Windows.Forms.NumericUpDown edtSlots;
        protected HelpLabel helpLabel4;
        protected System.Windows.Forms.ComboBox cmbSlotSize;
        protected System.Windows.Forms.NumericUpDown edtSlotWeight;
        protected HelpLabel helpLabel5;
        protected System.Windows.Forms.NumericUpDown edtMemorySize;
        protected HelpLabel helpLabel6;

    }
}
