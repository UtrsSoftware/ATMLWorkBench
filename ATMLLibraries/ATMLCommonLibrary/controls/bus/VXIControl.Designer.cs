/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System.Windows.Forms;

namespace ATMLCommonLibrary.controls.bus
{
    partial class VXIControl
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
            this.cmbVXIAddressSpace = new System.Windows.Forms.ComboBox();
            this.edtSlotWeight = new System.Windows.Forms.NumericUpDown();
            this.cmbSlotSize = new System.Windows.Forms.ComboBox();
            this.edtSlots = new System.Windows.Forms.NumericUpDown();
            this.cmbVXIDeviceClass = new System.Windows.Forms.ComboBox();
            this.chkDynamicConfig = new System.Windows.Forms.CheckBox();
            this.cmbDeviceCategory = new System.Windows.Forms.ComboBox();
            this.edtInteruptLines = new System.Windows.Forms.NumericUpDown();
            this.vxiKeyingControl = new ATMLCommonLibrary.controls.bus.VXIKeyingControl();
            this.lblInterruptLines = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtModelCode = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.lblModelCode = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.lblDeviceCategory = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtMfgId = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.lblManufacturerId = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.lblDeviceClass = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.lblrequiredMemory = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.lblSlotWeight = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.lblSlotSize = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.lblSlots = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.lblVXIAddressSpace = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.vxiModuleCoolingControl = new ATMLCommonLibrary.controls.bus.VXIModuleCoolingControl();
            this.supportedClockSourcesControl = new ATMLCommonLibrary.controls.bus.SupportedClockSourcesControl();
            this.vxiTTLTriggerControl = new ATMLCommonLibrary.controls.bus.VXITriggerLinesControl();
            this.vxiECLTriggerControl = new ATMLCommonLibrary.controls.bus.VXITriggerLinesControl();
            this.vxiPeakCurrentControl = new ATMLCommonLibrary.controls.bus.VXIBackplaneVoltagesControl();
            this.vxiDynamicCurrentControl = new ATMLCommonLibrary.controls.bus.VXIBackplaneVoltagesControl();
            this.edtRequiredMemory = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.requiredManufacturerValidator = new ATMLCommonLibrary.controls.validators.RequiredFieldValidator();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.requiredModelCodeValidator = new ATMLCommonLibrary.controls.validators.RequiredFieldValidator();
            this.label1 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.edtSlotWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSlots)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInteruptLines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDefaultAddress
            // 
            this.lblDefaultAddress.AutoSize = false;
            this.lblDefaultAddress.Location = new System.Drawing.Point(8, 166);
            this.lblDefaultAddress.Size = new System.Drawing.Size(96, 13);
            this.lblDefaultAddress.TabIndex = 21;
            this.lblDefaultAddress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // edtDefaultAddress
            // 
            this.edtDefaultAddress.Location = new System.Drawing.Point(107, 163);
            this.edtDefaultAddress.Size = new System.Drawing.Size(286, 20);
            this.edtDefaultAddress.TabIndex = 22;
            // 
            // cmbVXIAddressSpace
            // 
            this.cmbVXIAddressSpace.FormattingEnabled = true;
            this.cmbVXIAddressSpace.Location = new System.Drawing.Point(107, 85);
            this.cmbVXIAddressSpace.Name = "cmbVXIAddressSpace";
            this.cmbVXIAddressSpace.Size = new System.Drawing.Size(108, 21);
            this.cmbVXIAddressSpace.TabIndex = 10;
            // 
            // edtSlotWeight
            // 
            this.edtSlotWeight.DecimalPlaces = 4;
            this.edtSlotWeight.Location = new System.Drawing.Point(313, 137);
            this.edtSlotWeight.Name = "edtSlotWeight";
            this.edtSlotWeight.Size = new System.Drawing.Size(80, 20);
            this.edtSlotWeight.TabIndex = 20;
            this.edtSlotWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cmbSlotSize
            // 
            this.cmbSlotSize.FormattingEnabled = true;
            this.cmbSlotSize.Location = new System.Drawing.Point(313, 110);
            this.cmbSlotSize.Name = "cmbSlotSize";
            this.cmbSlotSize.Size = new System.Drawing.Size(80, 21);
            this.cmbSlotSize.TabIndex = 16;
            // 
            // edtSlots
            // 
            this.edtSlots.Location = new System.Drawing.Point(313, 85);
            this.edtSlots.Name = "edtSlots";
            this.edtSlots.Size = new System.Drawing.Size(80, 20);
            this.edtSlots.TabIndex = 12;
            this.edtSlots.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cmbVXIDeviceClass
            // 
            this.cmbVXIDeviceClass.FormattingEnabled = true;
            this.cmbVXIDeviceClass.Location = new System.Drawing.Point(107, 59);
            this.cmbVXIDeviceClass.Name = "cmbVXIDeviceClass";
            this.cmbVXIDeviceClass.Size = new System.Drawing.Size(108, 21);
            this.cmbVXIDeviceClass.TabIndex = 6;
            // 
            // chkDynamicConfig
            // 
            this.chkDynamicConfig.AutoSize = true;
            this.chkDynamicConfig.Location = new System.Drawing.Point(234, 36);
            this.chkDynamicConfig.Name = "chkDynamicConfig";
            this.chkDynamicConfig.Size = new System.Drawing.Size(15, 14);
            this.chkDynamicConfig.TabIndex = 4;
            this.chkDynamicConfig.UseVisualStyleBackColor = true;
            // 
            // cmbDeviceCategory
            // 
            this.cmbDeviceCategory.FormattingEnabled = true;
            this.cmbDeviceCategory.Location = new System.Drawing.Point(107, 110);
            this.cmbDeviceCategory.Name = "cmbDeviceCategory";
            this.cmbDeviceCategory.Size = new System.Drawing.Size(108, 21);
            this.cmbDeviceCategory.TabIndex = 14;
            // 
            // edtInteruptLines
            // 
            this.edtInteruptLines.Location = new System.Drawing.Point(313, 59);
            this.edtInteruptLines.Name = "edtInteruptLines";
            this.edtInteruptLines.Size = new System.Drawing.Size(80, 20);
            this.edtInteruptLines.TabIndex = 8;
            this.edtInteruptLines.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // vxiKeyingControl
            // 
            this.vxiKeyingControl.Location = new System.Drawing.Point(13, 687);
            this.vxiKeyingControl.Name = "vxiKeyingControl";
            this.vxiKeyingControl.SchemaTypeName = null;
            this.vxiKeyingControl.Size = new System.Drawing.Size(398, 91);
            this.vxiKeyingControl.TabIndex = 29;
            this.vxiKeyingControl.TargetNamespace = null;
            // 
            // lblInterruptLines
            // 
            this.lblInterruptLines.HelpMessageKey = "VXI.InterruptLines";
            this.lblInterruptLines.Location = new System.Drawing.Point(231, 63);
            this.lblInterruptLines.Name = "lblInterruptLines";
            this.lblInterruptLines.RequiredField = true;
            this.lblInterruptLines.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInterruptLines.Size = new System.Drawing.Size(78, 13);
            this.lblInterruptLines.TabIndex = 7;
            this.lblInterruptLines.Text = "Interrupt Lines";
            this.lblInterruptLines.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // edtModelCode
            // 
            this.edtModelCode.AttributeName = null;
            this.edtModelCode.Location = new System.Drawing.Point(107, 34);
            this.edtModelCode.Name = "edtModelCode";
            this.edtModelCode.Size = new System.Drawing.Size(108, 20);
            this.edtModelCode.TabIndex = 3;
            this.edtModelCode.Value = null;
            this.edtModelCode.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // lblModelCode
            // 
            this.lblModelCode.HelpMessageKey = "VXI.ModelCode";
            this.lblModelCode.Location = new System.Drawing.Point(8, 36);
            this.lblModelCode.Name = "lblModelCode";
            this.lblModelCode.RequiredField = true;
            this.lblModelCode.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModelCode.Size = new System.Drawing.Size(96, 13);
            this.lblModelCode.TabIndex = 2;
            this.lblModelCode.Text = "Model Code";
            this.lblModelCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDeviceCategory
            // 
            this.lblDeviceCategory.HelpMessageKey = "VXI.DeviceCategory";
            this.lblDeviceCategory.Location = new System.Drawing.Point(8, 113);
            this.lblDeviceCategory.Name = "lblDeviceCategory";
            this.lblDeviceCategory.RequiredField = true;
            this.lblDeviceCategory.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeviceCategory.Size = new System.Drawing.Size(96, 13);
            this.lblDeviceCategory.TabIndex = 13;
            this.lblDeviceCategory.Text = "Device Category";
            this.lblDeviceCategory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // edtMfgId
            // 
            this.edtMfgId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtMfgId.AttributeName = null;
            this.edtMfgId.Location = new System.Drawing.Point(107, 9);
            this.edtMfgId.Name = "edtMfgId";
            this.edtMfgId.Size = new System.Drawing.Size(286, 20);
            this.edtMfgId.TabIndex = 1;
            this.edtMfgId.Value = null;
            this.edtMfgId.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // lblManufacturerId
            // 
            this.lblManufacturerId.HelpMessageKey = "VXI.ManufacturerId";
            this.lblManufacturerId.Location = new System.Drawing.Point(8, 12);
            this.lblManufacturerId.Name = "lblManufacturerId";
            this.lblManufacturerId.RequiredField = true;
            this.lblManufacturerId.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblManufacturerId.Size = new System.Drawing.Size(96, 13);
            this.lblManufacturerId.TabIndex = 0;
            this.lblManufacturerId.Text = "Manufacturer Id";
            this.lblManufacturerId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDeviceClass
            // 
            this.lblDeviceClass.HelpMessageKey = "VXI.DeviceClass";
            this.lblDeviceClass.Location = new System.Drawing.Point(8, 63);
            this.lblDeviceClass.Name = "lblDeviceClass";
            this.lblDeviceClass.RequiredField = true;
            this.lblDeviceClass.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeviceClass.Size = new System.Drawing.Size(96, 13);
            this.lblDeviceClass.TabIndex = 5;
            this.lblDeviceClass.Text = "VXI Device Class";
            this.lblDeviceClass.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblrequiredMemory
            // 
            this.lblrequiredMemory.HelpMessageKey = "VXI.RequiredMemory";
            this.lblrequiredMemory.Location = new System.Drawing.Point(8, 140);
            this.lblrequiredMemory.Name = "lblrequiredMemory";
            this.lblrequiredMemory.RequiredField = true;
            this.lblrequiredMemory.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblrequiredMemory.Size = new System.Drawing.Size(96, 13);
            this.lblrequiredMemory.TabIndex = 17;
            this.lblrequiredMemory.Text = "Required Memory";
            this.lblrequiredMemory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSlotWeight
            // 
            this.lblSlotWeight.HelpMessageKey = "VXI.SlotWeight";
            this.lblSlotWeight.Location = new System.Drawing.Point(231, 139);
            this.lblSlotWeight.Name = "lblSlotWeight";
            this.lblSlotWeight.RequiredField = true;
            this.lblSlotWeight.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSlotWeight.Size = new System.Drawing.Size(78, 13);
            this.lblSlotWeight.TabIndex = 19;
            this.lblSlotWeight.Text = "Slot Weight";
            this.lblSlotWeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSlotSize
            // 
            this.lblSlotSize.HelpMessageKey = "VXI.SlotSize";
            this.lblSlotSize.Location = new System.Drawing.Point(231, 113);
            this.lblSlotSize.Name = "lblSlotSize";
            this.lblSlotSize.RequiredField = true;
            this.lblSlotSize.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSlotSize.Size = new System.Drawing.Size(78, 13);
            this.lblSlotSize.TabIndex = 15;
            this.lblSlotSize.Text = "Slot Size";
            this.lblSlotSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSlots
            // 
            this.lblSlots.HelpMessageKey = "VXI.Slots";
            this.lblSlots.Location = new System.Drawing.Point(231, 88);
            this.lblSlots.Name = "lblSlots";
            this.lblSlots.RequiredField = true;
            this.lblSlots.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSlots.Size = new System.Drawing.Size(78, 13);
            this.lblSlots.TabIndex = 11;
            this.lblSlots.Text = "Slots";
            this.lblSlots.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblVXIAddressSpace
            // 
            this.lblVXIAddressSpace.HelpMessageKey = "VXI.AddressSpace";
            this.lblVXIAddressSpace.Location = new System.Drawing.Point(8, 87);
            this.lblVXIAddressSpace.Name = "lblVXIAddressSpace";
            this.lblVXIAddressSpace.RequiredField = true;
            this.lblVXIAddressSpace.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVXIAddressSpace.Size = new System.Drawing.Size(96, 13);
            this.lblVXIAddressSpace.TabIndex = 9;
            this.lblVXIAddressSpace.Text = "VXI Addr Space";
            this.lblVXIAddressSpace.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // vxiModuleCoolingControl
            // 
            this.vxiModuleCoolingControl.Location = new System.Drawing.Point(212, 583);
            this.vxiModuleCoolingControl.Name = "vxiModuleCoolingControl";
            this.vxiModuleCoolingControl.SchemaTypeName = null;
            this.vxiModuleCoolingControl.Size = new System.Drawing.Size(199, 98);
            this.vxiModuleCoolingControl.TabIndex = 28;
            this.vxiModuleCoolingControl.TargetNamespace = null;
            // 
            // supportedClockSourcesControl
            // 
            this.supportedClockSourcesControl.Location = new System.Drawing.Point(13, 583);
            this.supportedClockSourcesControl.Name = "supportedClockSourcesControl";
            this.supportedClockSourcesControl.SchemaTypeName = null;
            this.supportedClockSourcesControl.Size = new System.Drawing.Size(187, 98);
            this.supportedClockSourcesControl.TabIndex = 27;
            this.supportedClockSourcesControl.TargetNamespace = null;
            this.supportedClockSourcesControl.Title = "Supported Clock Sources";
            // 
            // vxiTTLTriggerControl
            // 
            this.vxiTTLTriggerControl.Location = new System.Drawing.Point(212, 486);
            this.vxiTTLTriggerControl.Name = "vxiTTLTriggerControl";
            this.vxiTTLTriggerControl.SchemaTypeName = null;
            this.vxiTTLTriggerControl.Size = new System.Drawing.Size(199, 89);
            this.vxiTTLTriggerControl.TabIndex = 26;
            this.vxiTTLTriggerControl.TargetNamespace = null;
            this.vxiTTLTriggerControl.Title = "TTL Trigger ";
            // 
            // vxiECLTriggerControl
            // 
            this.vxiECLTriggerControl.Location = new System.Drawing.Point(13, 486);
            this.vxiECLTriggerControl.Name = "vxiECLTriggerControl";
            this.vxiECLTriggerControl.SchemaTypeName = null;
            this.vxiECLTriggerControl.Size = new System.Drawing.Size(187, 89);
            this.vxiECLTriggerControl.TabIndex = 25;
            this.vxiECLTriggerControl.TargetNamespace = null;
            this.vxiECLTriggerControl.Title = "ECL Trigger";
            // 
            // vxiPeakCurrentControl
            // 
            this.vxiPeakCurrentControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vxiPeakCurrentControl.Location = new System.Drawing.Point(13, 336);
            this.vxiPeakCurrentControl.Name = "vxiPeakCurrentControl";
            this.vxiPeakCurrentControl.SchemaTypeName = null;
            this.vxiPeakCurrentControl.Size = new System.Drawing.Size(398, 141);
            this.vxiPeakCurrentControl.TabIndex = 24;
            this.vxiPeakCurrentControl.TargetNamespace = null;
            this.vxiPeakCurrentControl.Title = "Peak Current";
            // 
            // vxiDynamicCurrentControl
            // 
            this.vxiDynamicCurrentControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vxiDynamicCurrentControl.Location = new System.Drawing.Point(9, 188);
            this.vxiDynamicCurrentControl.Name = "vxiDynamicCurrentControl";
            this.vxiDynamicCurrentControl.SchemaTypeName = null;
            this.vxiDynamicCurrentControl.Size = new System.Drawing.Size(402, 141);
            this.vxiDynamicCurrentControl.TabIndex = 23;
            this.vxiDynamicCurrentControl.TargetNamespace = null;
            this.vxiDynamicCurrentControl.Title = "Dynamic Current";
            // 
            // edtRequiredMemory
            // 
            this.edtRequiredMemory.AttributeName = null;
            this.edtRequiredMemory.Location = new System.Drawing.Point(107, 136);
            this.edtRequiredMemory.Name = "edtRequiredMemory";
            this.edtRequiredMemory.Size = new System.Drawing.Size(108, 20);
            this.edtRequiredMemory.TabIndex = 18;
            this.edtRequiredMemory.Value = null;
            this.edtRequiredMemory.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // requiredManufacturerValidator
            // 
            this.requiredManufacturerValidator.ControlToValidate = this.edtMfgId;
            this.requiredManufacturerValidator.ErrorMessage = "The Manufacturer Id is required.";
            this.requiredManufacturerValidator.ErrorProvider = this.errorProvider;
            this.requiredManufacturerValidator.Icon = null;
            this.requiredManufacturerValidator.InitialValue = null;
            this.requiredManufacturerValidator.IsEnabled = true;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // requiredModelCodeValidator
            // 
            this.requiredModelCodeValidator.ControlToValidate = this.edtModelCode;
            this.requiredModelCodeValidator.ErrorMessage = "The Model Code is required.";
            this.requiredModelCodeValidator.ErrorProvider = this.errorProvider;
            this.requiredModelCodeValidator.Icon = null;
            this.requiredModelCodeValidator.InitialValue = null;
            this.requiredModelCodeValidator.IsEnabled = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.HelpMessageKey = "VXI.DynamicallyConfigured";
            this.label1.Location = new System.Drawing.Point(254, 37);
            this.label1.Name = "label1";
            this.label1.RequiredField = false;
            this.label1.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Dynamically Configured";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // VXIControl
            // 
            this.Controls.Add(this.label1);
            this.Controls.Add(this.edtRequiredMemory);
            this.Controls.Add(this.vxiKeyingControl);
            this.Controls.Add(this.edtInteruptLines);
            this.Controls.Add(this.lblInterruptLines);
            this.Controls.Add(this.edtModelCode);
            this.Controls.Add(this.lblModelCode);
            this.Controls.Add(this.cmbDeviceCategory);
            this.Controls.Add(this.lblDeviceCategory);
            this.Controls.Add(this.chkDynamicConfig);
            this.Controls.Add(this.edtMfgId);
            this.Controls.Add(this.lblManufacturerId);
            this.Controls.Add(this.cmbVXIDeviceClass);
            this.Controls.Add(this.lblDeviceClass);
            this.Controls.Add(this.lblrequiredMemory);
            this.Controls.Add(this.edtSlotWeight);
            this.Controls.Add(this.lblSlotWeight);
            this.Controls.Add(this.cmbSlotSize);
            this.Controls.Add(this.lblSlotSize);
            this.Controls.Add(this.edtSlots);
            this.Controls.Add(this.lblSlots);
            this.Controls.Add(this.cmbVXIAddressSpace);
            this.Controls.Add(this.lblVXIAddressSpace);
            this.Controls.Add(this.vxiModuleCoolingControl);
            this.Controls.Add(this.supportedClockSourcesControl);
            this.Controls.Add(this.vxiTTLTriggerControl);
            this.Controls.Add(this.vxiECLTriggerControl);
            this.Controls.Add(this.vxiPeakCurrentControl);
            this.Controls.Add(this.vxiDynamicCurrentControl);
            this.Name = "VXIControl";
            this.Size = new System.Drawing.Size(435, 795);
            this.Controls.SetChildIndex(this.vxiDynamicCurrentControl, 0);
            this.Controls.SetChildIndex(this.vxiPeakCurrentControl, 0);
            this.Controls.SetChildIndex(this.vxiECLTriggerControl, 0);
            this.Controls.SetChildIndex(this.vxiTTLTriggerControl, 0);
            this.Controls.SetChildIndex(this.supportedClockSourcesControl, 0);
            this.Controls.SetChildIndex(this.vxiModuleCoolingControl, 0);
            this.Controls.SetChildIndex(this.lblVXIAddressSpace, 0);
            this.Controls.SetChildIndex(this.cmbVXIAddressSpace, 0);
            this.Controls.SetChildIndex(this.lblSlots, 0);
            this.Controls.SetChildIndex(this.edtSlots, 0);
            this.Controls.SetChildIndex(this.lblSlotSize, 0);
            this.Controls.SetChildIndex(this.cmbSlotSize, 0);
            this.Controls.SetChildIndex(this.lblSlotWeight, 0);
            this.Controls.SetChildIndex(this.edtSlotWeight, 0);
            this.Controls.SetChildIndex(this.lblrequiredMemory, 0);
            this.Controls.SetChildIndex(this.lblDeviceClass, 0);
            this.Controls.SetChildIndex(this.cmbVXIDeviceClass, 0);
            this.Controls.SetChildIndex(this.lblManufacturerId, 0);
            this.Controls.SetChildIndex(this.edtMfgId, 0);
            this.Controls.SetChildIndex(this.chkDynamicConfig, 0);
            this.Controls.SetChildIndex(this.lblDeviceCategory, 0);
            this.Controls.SetChildIndex(this.cmbDeviceCategory, 0);
            this.Controls.SetChildIndex(this.lblModelCode, 0);
            this.Controls.SetChildIndex(this.edtModelCode, 0);
            this.Controls.SetChildIndex(this.lblInterruptLines, 0);
            this.Controls.SetChildIndex(this.edtInteruptLines, 0);
            this.Controls.SetChildIndex(this.vxiKeyingControl, 0);
            this.Controls.SetChildIndex(this.edtDefaultAddress, 0);
            this.Controls.SetChildIndex(this.lblDefaultAddress, 0);
            this.Controls.SetChildIndex(this.edtRequiredMemory, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.edtSlotWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSlots)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInteruptLines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private VXIBackplaneVoltagesControl vxiDynamicCurrentControl;
        private VXIBackplaneVoltagesControl vxiPeakCurrentControl;
        private VXITriggerLinesControl vxiECLTriggerControl;
        private VXITriggerLinesControl vxiTTLTriggerControl;
        private SupportedClockSourcesControl supportedClockSourcesControl;
        private VXIModuleCoolingControl vxiModuleCoolingControl;
        private HelpLabel lblVXIAddressSpace;
        private System.Windows.Forms.ComboBox cmbVXIAddressSpace;
        protected HelpLabel lblrequiredMemory;
        protected System.Windows.Forms.NumericUpDown edtSlotWeight;
        protected HelpLabel lblSlotWeight;
        protected System.Windows.Forms.ComboBox cmbSlotSize;
        protected HelpLabel lblSlotSize;
        protected System.Windows.Forms.NumericUpDown edtSlots;
        protected HelpLabel lblSlots;
        private System.Windows.Forms.ComboBox cmbVXIDeviceClass;
        private HelpLabel lblDeviceClass;
        private HelpLabel lblManufacturerId;
        private awb.AWBTextBox edtMfgId;
        private System.Windows.Forms.CheckBox chkDynamicConfig;
        private System.Windows.Forms.ComboBox cmbDeviceCategory;
        private HelpLabel lblDeviceCategory;
        private awb.AWBTextBox edtModelCode;
        private HelpLabel lblModelCode;
        protected System.Windows.Forms.NumericUpDown edtInteruptLines;
        protected HelpLabel lblInterruptLines;
        private VXIKeyingControl vxiKeyingControl;
        private awb.AWBTextBox edtRequiredMemory;
        private validators.RequiredFieldValidator requiredManufacturerValidator;
        private validators.RequiredFieldValidator requiredModelCodeValidator;
        private ATMLCommonLibrary.controls.HelpLabel label1;
        protected ErrorProvider errorProvider;
    }
}
