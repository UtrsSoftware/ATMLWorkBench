/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls.bus
{
    partial class BusForm
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.ieeE488Control = new ATMLCommonLibrary.controls.bus.IEEE488Control();
            this.ieeE1394Control = new ATMLCommonLibrary.controls.bus.IEEE1394Control();
            this.lxiControl = new ATMLCommonLibrary.controls.bus.LXIControl();
            this.vmeControl = new ATMLCommonLibrary.controls.bus.VMEControl();
            this.usbControl = new ATMLCommonLibrary.controls.bus.USBControl();
            this.ethernetControl = new ATMLCommonLibrary.controls.bus.EthernetControl();
            this.eiA232Control = new ATMLCommonLibrary.controls.bus.EIA232Control();
            this.vxiControl = new ATMLCommonLibrary.controls.bus.VXIControl();
            this.pciControl = new ATMLCommonLibrary.controls.bus.PCIControl();
            this.pxiControl = new ATMLCommonLibrary.controls.bus.PXIControl();
            this.pxIeControl = new ATMLCommonLibrary.controls.bus.PXIeControl();
            this.pcIeControl = new ATMLCommonLibrary.controls.bus.PCIeControl();
            this.helpLabel1 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.cmbBusType = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(13, 35);
            this.panel1.Size = new System.Drawing.Size(434, 400);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(372, 440);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(291, 440);
            // 
            // lblDenoteRequiredField
            // 
            this.lblDenoteRequiredField.Location = new System.Drawing.Point(1, 451);
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.AutoScrollMargin = new System.Drawing.Size(10, 10);
            this.panel2.Controls.Add(this.ieeE488Control);
            this.panel2.Controls.Add(this.ieeE1394Control);
            this.panel2.Controls.Add(this.lxiControl);
            this.panel2.Controls.Add(this.vmeControl);
            this.panel2.Controls.Add(this.usbControl);
            this.panel2.Controls.Add(this.ethernetControl);
            this.panel2.Controls.Add(this.eiA232Control);
            this.panel2.Controls.Add(this.vxiControl);
            this.panel2.Controls.Add(this.pciControl);
            this.panel2.Controls.Add(this.pxiControl);
            this.panel2.Controls.Add(this.pxIeControl);
            this.panel2.Controls.Add(this.pcIeControl);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(430, 396);
            this.panel2.TabIndex = 0;
            // 
            // ieeE488Control
            // 
            this.ieeE488Control.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ieeE488Control.Location = new System.Drawing.Point(0, 0);
            this.ieeE488Control.Name = "ieeE488Control";
            this.ieeE488Control.SchemaTypeName = null;
            this.ieeE488Control.Size = new System.Drawing.Size(430, 396);
            this.ieeE488Control.TabIndex = 11;
            this.ieeE488Control.TargetNamespace = null;
            // 
            // ieeE1394Control
            // 
            this.ieeE1394Control.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ieeE1394Control.Location = new System.Drawing.Point(0, 0);
            this.ieeE1394Control.Name = "ieeE1394Control";
            this.ieeE1394Control.SchemaTypeName = null;
            this.ieeE1394Control.Size = new System.Drawing.Size(430, 396);
            this.ieeE1394Control.TabIndex = 10;
            this.ieeE1394Control.TargetNamespace = null;
            // 
            // lxiControl
            // 
            this.lxiControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lxiControl.Location = new System.Drawing.Point(0, 0);
            this.lxiControl.Name = "lxiControl";
            this.lxiControl.SchemaTypeName = null;
            this.lxiControl.Size = new System.Drawing.Size(430, 396);
            this.lxiControl.TabIndex = 9;
            this.lxiControl.TargetNamespace = null;
            // 
            // vmeControl
            // 
            this.vmeControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vmeControl.Location = new System.Drawing.Point(0, 0);
            this.vmeControl.Name = "vmeControl";
            this.vmeControl.SchemaTypeName = null;
            this.vmeControl.Size = new System.Drawing.Size(430, 396);
            this.vmeControl.TabIndex = 8;
            this.vmeControl.TargetNamespace = null;
            // 
            // usbControl
            // 
            this.usbControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usbControl.Location = new System.Drawing.Point(0, 0);
            this.usbControl.Name = "usbControl";
            this.usbControl.SchemaTypeName = null;
            this.usbControl.Size = new System.Drawing.Size(430, 396);
            this.usbControl.TabIndex = 7;
            this.usbControl.TargetNamespace = null;
            // 
            // ethernetControl
            // 
            this.ethernetControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ethernetControl.Location = new System.Drawing.Point(0, 0);
            this.ethernetControl.Name = "ethernetControl";
            this.ethernetControl.SchemaTypeName = null;
            this.ethernetControl.Size = new System.Drawing.Size(430, 396);
            this.ethernetControl.TabIndex = 6;
            this.ethernetControl.TargetNamespace = null;
            // 
            // eiA232Control
            // 
            this.eiA232Control.Dock = System.Windows.Forms.DockStyle.Fill;
            this.eiA232Control.Location = new System.Drawing.Point(0, 0);
            this.eiA232Control.Name = "eiA232Control";
            this.eiA232Control.SchemaTypeName = null;
            this.eiA232Control.Size = new System.Drawing.Size(430, 396);
            this.eiA232Control.TabIndex = 5;
            this.eiA232Control.TargetNamespace = null;
            // 
            // vxiControl
            // 
            this.vxiControl.AutoScroll = true;
            this.vxiControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vxiControl.Location = new System.Drawing.Point(0, 0);
            this.vxiControl.Name = "vxiControl";
            this.vxiControl.SchemaTypeName = null;
            this.vxiControl.Size = new System.Drawing.Size(430, 396);
            this.vxiControl.TabIndex = 2;
            this.vxiControl.TargetNamespace = null;
            // 
            // pciControl
            // 
            this.pciControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pciControl.Location = new System.Drawing.Point(0, 0);
            this.pciControl.Name = "pciControl";
            this.pciControl.SchemaTypeName = null;
            this.pciControl.Size = new System.Drawing.Size(430, 396);
            this.pciControl.TabIndex = 4;
            this.pciControl.TargetNamespace = null;
            // 
            // pxiControl
            // 
            this.pxiControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pxiControl.Location = new System.Drawing.Point(0, 0);
            this.pxiControl.Name = "pxiControl";
            this.pxiControl.SchemaTypeName = null;
            this.pxiControl.Size = new System.Drawing.Size(430, 396);
            this.pxiControl.TabIndex = 3;
            this.pxiControl.TargetNamespace = null;
            // 
            // pxIeControl
            // 
            this.pxIeControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pxIeControl.Location = new System.Drawing.Point(0, 0);
            this.pxIeControl.Name = "pxIeControl";
            this.pxIeControl.Padding = new System.Windows.Forms.Padding(1);
            this.pxIeControl.SchemaTypeName = null;
            this.pxIeControl.Size = new System.Drawing.Size(430, 396);
            this.pxIeControl.TabIndex = 0;
            this.pxIeControl.TargetNamespace = null;
            // 
            // pcIeControl
            // 
            this.pcIeControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcIeControl.Location = new System.Drawing.Point(0, 0);
            this.pcIeControl.Name = "pcIeControl";
            this.pcIeControl.SchemaTypeName = null;
            this.pcIeControl.Size = new System.Drawing.Size(430, 396);
            this.pcIeControl.TabIndex = 1;
            this.pcIeControl.TargetNamespace = null;
            // 
            // helpLabel1
            // 
            this.helpLabel1.AutoSize = true;
            this.helpLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel1.ForeColor = System.Drawing.Color.AliceBlue;
            this.helpLabel1.HelpMessageKey = null;
            this.helpLabel1.Location = new System.Drawing.Point(15, 9);
            this.helpLabel1.Name = "helpLabel1";
            this.helpLabel1.RequiredField = false;
            this.helpLabel1.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel1.Size = new System.Drawing.Size(57, 15);
            this.helpLabel1.TabIndex = 1;
            this.helpLabel1.Text = "Bus Type";
            this.helpLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbBusType
            // 
            this.cmbBusType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBusType.FormattingEnabled = true;
            this.cmbBusType.Items.AddRange(new object[] {
            "EIA232",
            "Ethernet",
            "IEEE488",
            "IEEE1394",
            "LXI",
            "PCI",
            "PCIe",
            "PXI",
            "PXIe",
            "USB",
            "VME",
            "VXI"});
            this.cmbBusType.Location = new System.Drawing.Point(81, 8);
            this.cmbBusType.Name = "cmbBusType";
            this.cmbBusType.Size = new System.Drawing.Size(159, 21);
            this.cmbBusType.TabIndex = 2;
            this.cmbBusType.SelectedIndexChanged += new System.EventHandler(this.cmbBusType_SelectedIndexChanged);
            // 
            // BusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 467);
            this.Controls.Add(this.cmbBusType);
            this.Controls.Add(this.helpLabel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "BusForm";
            this.Text = "Bus";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.lblDenoteRequiredField, 0);
            this.Controls.SetChildIndex(this.helpLabel1, 0);
            this.Controls.SetChildIndex(this.cmbBusType, 0);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cmbBusType;
        private HelpLabel helpLabel1;
        private PCIeControl pcIeControl;
        private VXIControl vxiControl;
        private PXIeControl pxIeControl;
        private PXIControl pxiControl;
        private PCIControl pciControl;
        private EIA232Control eiA232Control;
        private EthernetControl ethernetControl;
        private USBControl usbControl;
        private VMEControl vmeControl;
        private LXIControl lxiControl;
        private IEEE1394Control ieeE1394Control;
        private IEEE488Control ieeE488Control;
    }
}
