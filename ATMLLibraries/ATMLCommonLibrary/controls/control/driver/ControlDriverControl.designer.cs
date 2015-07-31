/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using ATMLCommonLibrary.controls.driver.platform;
using ATMLCommonLibrary.controls.hardware;

namespace ATMLCommonLibrary.controls.control.driver
{
    partial class ControlDriverControl
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabDriverType = new System.Windows.Forms.TabPage();
            this.controlDriverSelectionControl = new ATMLCommonLibrary.controls.driver.DriverSelectionControl();
            this.tabDriverManufacturer = new System.Windows.Forms.TabPage();
            this.controlDriverManufacturerControl = new ATMLCommonLibrary.controls.manufacturer.ManufacturerControl();
            this.tabDriverDependencies = new System.Windows.Forms.TabPage();
            this.controlDriverDependenciesControl = new ATMLCommonLibrary.controls.control.driver.ControlDriverDependenciesControl();
            this.tabDriverPlatform = new System.Windows.Forms.TabPage();
            this.controlDriverPlatformControl = new ATMLCommonLibrary.controls.driver.platform.DriverPlatformControl();
            this.tabControl1.SuspendLayout();
            this.tabDriverType.SuspendLayout();
            this.tabDriverManufacturer.SuspendLayout();
            this.tabDriverDependencies.SuspendLayout();
            this.tabDriverPlatform.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabDriverType);
            this.tabControl1.Controls.Add(this.tabDriverManufacturer);
            this.tabControl1.Controls.Add(this.tabDriverDependencies);
            this.tabControl1.Controls.Add(this.tabDriverPlatform);
            this.tabControl1.Location = new System.Drawing.Point(13, 64);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(503, 289);
            this.tabControl1.TabIndex = 6;
            // 
            // tabDriverType
            // 
            this.tabDriverType.AutoScroll = true;
            this.tabDriverType.Controls.Add(this.controlDriverSelectionControl);
            this.tabDriverType.Location = new System.Drawing.Point(4, 22);
            this.tabDriverType.Name = "tabDriverType";
            this.tabDriverType.Padding = new System.Windows.Forms.Padding(3);
            this.tabDriverType.Size = new System.Drawing.Size(495, 263);
            this.tabDriverType.TabIndex = 0;
            this.tabDriverType.Text = "Type";
            this.tabDriverType.UseVisualStyleBackColor = true;
            // 
            // controlDriverSelectionControl
            // 
            this.controlDriverSelectionControl.AutoScroll = true;
            this.controlDriverSelectionControl.BackColor = System.Drawing.Color.AliceBlue;
            this.controlDriverSelectionControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlDriverSelectionControl.HasErrors = false;
            this.controlDriverSelectionControl.HelpKeyWord = null;
            this.controlDriverSelectionControl.LastError = null;
            this.controlDriverSelectionControl.Location = new System.Drawing.Point(3, 3);
            this.controlDriverSelectionControl.Margin = new System.Windows.Forms.Padding(0);
            this.controlDriverSelectionControl.Name = "controlDriverSelectionControl";
            this.controlDriverSelectionControl.SchemaTypeName = null;
            this.controlDriverSelectionControl.Size = new System.Drawing.Size(489, 257);
            this.controlDriverSelectionControl.TabIndex = 0;
            this.controlDriverSelectionControl.TargetNamespace = null;
            // 
            // tabDriverManufacturer
            // 
            this.tabDriverManufacturer.Controls.Add(this.controlDriverManufacturerControl);
            this.tabDriverManufacturer.Location = new System.Drawing.Point(4, 22);
            this.tabDriverManufacturer.Name = "tabDriverManufacturer";
            this.tabDriverManufacturer.Padding = new System.Windows.Forms.Padding(3);
            this.tabDriverManufacturer.Size = new System.Drawing.Size(495, 263);
            this.tabDriverManufacturer.TabIndex = 1;
            this.tabDriverManufacturer.Text = "Manufacturer";
            this.tabDriverManufacturer.UseVisualStyleBackColor = true;
            // 
            // controlDriverManufacturerControl
            // 
            this.controlDriverManufacturerControl.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.controlDriverManufacturerControl.BackColor = System.Drawing.Color.AliceBlue;
            this.controlDriverManufacturerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlDriverManufacturerControl.HasErrors = false;
            this.controlDriverManufacturerControl.HelpKeyWord = null;
            this.controlDriverManufacturerControl.LastError = null;
            this.controlDriverManufacturerControl.Location = new System.Drawing.Point(3, 3);
            this.controlDriverManufacturerControl.Name = "controlDriverManufacturerControl";
            this.controlDriverManufacturerControl.SchemaTypeName = null;
            this.controlDriverManufacturerControl.Size = new System.Drawing.Size(489, 257);
            this.controlDriverManufacturerControl.TabIndex = 0;
            this.controlDriverManufacturerControl.TargetNamespace = null;
            this.controlDriverManufacturerControl.ValidationEndabled = true;
            // 
            // tabDriverDependencies
            // 
            this.tabDriverDependencies.Controls.Add(this.controlDriverDependenciesControl);
            this.tabDriverDependencies.Location = new System.Drawing.Point(4, 22);
            this.tabDriverDependencies.Name = "tabDriverDependencies";
            this.tabDriverDependencies.Padding = new System.Windows.Forms.Padding(3);
            this.tabDriverDependencies.Size = new System.Drawing.Size(495, 263);
            this.tabDriverDependencies.TabIndex = 2;
            this.tabDriverDependencies.Text = "Dependencies";
            this.tabDriverDependencies.UseVisualStyleBackColor = true;
            // 
            // controlDriverDependenciesControl
            // 
            this.controlDriverDependenciesControl.BackColor = System.Drawing.Color.AliceBlue;
            this.controlDriverDependenciesControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlDriverDependenciesControl.HasErrors = false;
            this.controlDriverDependenciesControl.HelpKeyWord = null;
            this.controlDriverDependenciesControl.LastError = null;
            this.controlDriverDependenciesControl.Location = new System.Drawing.Point(3, 3);
            this.controlDriverDependenciesControl.Name = "controlDriverDependenciesControl";
            this.controlDriverDependenciesControl.SchemaTypeName = null;
            this.controlDriverDependenciesControl.Size = new System.Drawing.Size(489, 257);
            this.controlDriverDependenciesControl.TabIndex = 0;
            this.controlDriverDependenciesControl.TargetNamespace = null;
            // 
            // tabDriverPlatform
            // 
            this.tabDriverPlatform.Controls.Add(this.controlDriverPlatformControl);
            this.tabDriverPlatform.Location = new System.Drawing.Point(4, 22);
            this.tabDriverPlatform.Name = "tabDriverPlatform";
            this.tabDriverPlatform.Padding = new System.Windows.Forms.Padding(3);
            this.tabDriverPlatform.Size = new System.Drawing.Size(495, 263);
            this.tabDriverPlatform.TabIndex = 3;
            this.tabDriverPlatform.Text = "Platform";
            this.tabDriverPlatform.UseVisualStyleBackColor = true;
            // 
            // controlDriverPlatformControl
            // 
            this.controlDriverPlatformControl.BackColor = System.Drawing.Color.AliceBlue;
            this.controlDriverPlatformControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlDriverPlatformControl.HasErrors = false;
            this.controlDriverPlatformControl.HelpKeyWord = null;
            this.controlDriverPlatformControl.LastError = null;
            this.controlDriverPlatformControl.Location = new System.Drawing.Point(3, 3);
            this.controlDriverPlatformControl.Name = "controlDriverPlatformControl";
            this.controlDriverPlatformControl.SchemaTypeName = null;
            this.controlDriverPlatformControl.Size = new System.Drawing.Size(489, 257);
            this.controlDriverPlatformControl.TabIndex = 0;
            this.controlDriverPlatformControl.TargetNamespace = null;
            // 
            // ControlDriverControl
            // 
            this.Controls.Add(this.tabControl1);
            this.Name = "ControlDriverControl";
            this.Size = new System.Drawing.Size(532, 367);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.Controls.SetChildIndex(this.lblVersionName, 0);
            this.Controls.SetChildIndex(this.edtVersionName, 0);
            this.Controls.SetChildIndex(this.lblVersion, 0);
            this.Controls.SetChildIndex(this.edtVersion, 0);
            this.Controls.SetChildIndex(this.lblVersionQualifier, 0);
            this.Controls.SetChildIndex(this.cmbVersionIdentifierQualifier, 0);
            this.tabControl1.ResumeLayout(false);
            this.tabDriverType.ResumeLayout(false);
            this.tabDriverManufacturer.ResumeLayout(false);
            this.tabDriverDependencies.ResumeLayout(false);
            this.tabDriverPlatform.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabDriverType;
        private System.Windows.Forms.TabPage tabDriverManufacturer;
        private System.Windows.Forms.TabPage tabDriverDependencies;
        private System.Windows.Forms.TabPage tabDriverPlatform;
        private controls.driver.DriverSelectionControl controlDriverSelectionControl;
        private manufacturer.ManufacturerControl controlDriverManufacturerControl;
        private ControlDriverDependenciesControl controlDriverDependenciesControl;
        private DriverPlatformControl controlDriverPlatformControl;
    }
}
