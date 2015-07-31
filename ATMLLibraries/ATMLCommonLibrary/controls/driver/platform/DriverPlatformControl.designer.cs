/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

namespace ATMLCommonLibrary.controls.driver.platform
{
    partial class DriverPlatformControl
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
            this.OperatingSystem = new ATMLCommonLibrary.controls.driver.platform.DriverControlOperatingSystemListControl();
            this.helpLabel1 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.HardDisk = new ATMLCommonLibrary.controls.driver.platform.DriverPlatformHardDiskControl();
            this.PhysicalMem = new ATMLCommonLibrary.controls.driver.platform.DriverPlatformPhysicalMemoryControl();
            this.Processor = new ATMLCommonLibrary.controls.driver.platform.DriverPlatformProcessorControl();
            this.SuspendLayout();
            // 
            // OperatingSystem
            // 
            this.OperatingSystem.AllowRowResequencing = false;
            this.OperatingSystem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OperatingSystem.BackColor = System.Drawing.Color.AliceBlue;
            this.OperatingSystem.FormTitle = null;
            this.OperatingSystem.HasErrors = false;
            this.OperatingSystem.HelpKeyWord = null;
            this.OperatingSystem.LastError = null;
            this.OperatingSystem.ListName = null;
            this.OperatingSystem.Location = new System.Drawing.Point(12, 152);
            this.OperatingSystem.Margin = new System.Windows.Forms.Padding(0);
            this.OperatingSystem.Name = "OperatingSystem";
            this.OperatingSystem.SchemaTypeName = null;
            this.OperatingSystem.ShowFind = false;
            this.OperatingSystem.Size = new System.Drawing.Size(338, 153);
            this.OperatingSystem.TabIndex = 0;
            this.OperatingSystem.TargetNamespace = null;
            this.OperatingSystem.TooltipTextAddButton = "Press to add a new ";
            this.OperatingSystem.TooltipTextDeleteButton = "Press to delete the selected ";
            this.OperatingSystem.TooltipTextEditButton = "Press to edit the selected ";
            // 
            // helpLabel1
            // 
            this.helpLabel1.AutoSize = true;
            this.helpLabel1.HelpMessageKey = "Driver.Platform.OperatingSystem";
            this.helpLabel1.Location = new System.Drawing.Point(12, 137);
            this.helpLabel1.Name = "helpLabel1";
            this.helpLabel1.RequiredField = false;
            this.helpLabel1.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel1.Size = new System.Drawing.Size(90, 13);
            this.helpLabel1.TabIndex = 1;
            this.helpLabel1.Text = "Operating System";
            // 
            // HardDisk
            // 
            this.HardDisk.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HardDisk.BackColor = System.Drawing.Color.AliceBlue;
            this.HardDisk.HasErrors = false;
            this.HardDisk.HelpKeyWord = "Driver.Platform.HardDisk";
            this.HardDisk.LastError = null;
            this.HardDisk.Location = new System.Drawing.Point(11, 10);
            this.HardDisk.Name = "HardDisk";
            this.HardDisk.SchemaTypeName = null;
            this.HardDisk.Size = new System.Drawing.Size(343, 35);
            this.HardDisk.TabIndex = 2;
            this.HardDisk.TargetNamespace = null;
            // 
            // PhysicalMem
            // 
            this.PhysicalMem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PhysicalMem.BackColor = System.Drawing.Color.AliceBlue;
            this.PhysicalMem.HasErrors = false;
            this.PhysicalMem.HelpKeyWord = "Driver.Platform.Memory";
            this.PhysicalMem.LastError = null;
            this.PhysicalMem.Location = new System.Drawing.Point(11, 51);
            this.PhysicalMem.Name = "PhysicalMem";
            this.PhysicalMem.SchemaTypeName = null;
            this.PhysicalMem.Size = new System.Drawing.Size(343, 34);
            this.PhysicalMem.TabIndex = 3;
            this.PhysicalMem.TargetNamespace = null;
            // 
            // Processor
            // 
            this.Processor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Processor.BackColor = System.Drawing.Color.AliceBlue;
            this.Processor.HasErrors = false;
            this.Processor.HelpKeyWord = "Driver.Platform.Processor";
            this.Processor.LastError = null;
            this.Processor.Location = new System.Drawing.Point(11, 91);
            this.Processor.Name = "Processor";
            this.Processor.SchemaTypeName = null;
            this.Processor.Size = new System.Drawing.Size(343, 30);
            this.Processor.TabIndex = 4;
            this.Processor.TargetNamespace = null;
            // 
            // DriverPlatformControl
            // 
            this.Controls.Add(this.Processor);
            this.Controls.Add(this.PhysicalMem);
            this.Controls.Add(this.HardDisk);
            this.Controls.Add(this.helpLabel1);
            this.Controls.Add(this.OperatingSystem);
            this.Name = "DriverPlatformControl";
            this.Size = new System.Drawing.Size(366, 324);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DriverControlOperatingSystemListControl OperatingSystem;
        private HelpLabel helpLabel1;
        private DriverPlatformHardDiskControl HardDisk;
        private DriverPlatformPhysicalMemoryControl PhysicalMem;
        private DriverPlatformProcessorControl Processor;
    }
}
