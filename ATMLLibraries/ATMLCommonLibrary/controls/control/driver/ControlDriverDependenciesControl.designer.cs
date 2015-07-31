/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using ATMLCommonLibrary.controls.hardware;

namespace ATMLCommonLibrary.controls.control.driver
{
    partial class ControlDriverDependenciesControl
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
            this.Software = new System.Windows.Forms.TabControl();
            this.tabFirmware = new System.Windows.Forms.TabPage();
            this.versionIdentifierFirmwareListControl = new ATMLCommonLibrary.controls.hardware.VersionIdentifierListControl();
            this.tabSoftware = new System.Windows.Forms.TabPage();
            this.versionIdentifierSoftwareListControl = new ATMLCommonLibrary.controls.hardware.VersionIdentifierListControl();
            this.Software.SuspendLayout();
            this.tabFirmware.SuspendLayout();
            this.tabSoftware.SuspendLayout();
            this.SuspendLayout();
            // 
            // Software
            // 
            this.Software.Controls.Add(this.tabFirmware);
            this.Software.Controls.Add(this.tabSoftware);
            this.Software.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Software.Location = new System.Drawing.Point(0, 0);
            this.Software.Name = "Software";
            this.Software.SelectedIndex = 0;
            this.Software.Size = new System.Drawing.Size(468, 501);
            this.Software.TabIndex = 0;
            // 
            // tabFirmware
            // 
            this.tabFirmware.Controls.Add(this.versionIdentifierFirmwareListControl);
            this.tabFirmware.Location = new System.Drawing.Point(4, 22);
            this.tabFirmware.Name = "tabFirmware";
            this.tabFirmware.Padding = new System.Windows.Forms.Padding(3);
            this.tabFirmware.Size = new System.Drawing.Size(460, 475);
            this.tabFirmware.TabIndex = 0;
            this.tabFirmware.Text = "Firmware";
            this.tabFirmware.UseVisualStyleBackColor = true;
            // 
            // versionIdentifierFirmwareListControl
            // 
            this.versionIdentifierFirmwareListControl.AllowRowResequencing = false;
            this.versionIdentifierFirmwareListControl.BackColor = System.Drawing.Color.AliceBlue;
            this.versionIdentifierFirmwareListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.versionIdentifierFirmwareListControl.FormTitle = null;
            this.versionIdentifierFirmwareListControl.HasErrors = false;
            this.versionIdentifierFirmwareListControl.HelpKeyWord = null;
            this.versionIdentifierFirmwareListControl.LastError = null;
            this.versionIdentifierFirmwareListControl.ListName = null;
            this.versionIdentifierFirmwareListControl.Location = new System.Drawing.Point(3, 3);
            this.versionIdentifierFirmwareListControl.Margin = new System.Windows.Forms.Padding(0);
            this.versionIdentifierFirmwareListControl.Name = "versionIdentifierFirmwareListControl";
            this.versionIdentifierFirmwareListControl.SchemaTypeName = null;
            this.versionIdentifierFirmwareListControl.ShowFind = false;
            this.versionIdentifierFirmwareListControl.Size = new System.Drawing.Size(454, 469);
            this.versionIdentifierFirmwareListControl.TabIndex = 0;
            this.versionIdentifierFirmwareListControl.TargetNamespace = null;
            this.versionIdentifierFirmwareListControl.TooltipTextAddButton = "Press to add a new Version";
            this.versionIdentifierFirmwareListControl.TooltipTextDeleteButton = "Press to delete the selected Version";
            this.versionIdentifierFirmwareListControl.TooltipTextEditButton = "Press to edit the selected Version";
            this.versionIdentifierFirmwareListControl.VersionIdentifiers = null;
            // 
            // tabSoftware
            // 
            this.tabSoftware.Controls.Add(this.versionIdentifierSoftwareListControl);
            this.tabSoftware.Location = new System.Drawing.Point(4, 22);
            this.tabSoftware.Name = "tabSoftware";
            this.tabSoftware.Padding = new System.Windows.Forms.Padding(3);
            this.tabSoftware.Size = new System.Drawing.Size(460, 475);
            this.tabSoftware.TabIndex = 1;
            this.tabSoftware.Text = "Software";
            this.tabSoftware.UseVisualStyleBackColor = true;
            // 
            // versionIdentifierSoftwareListControl
            // 
            this.versionIdentifierSoftwareListControl.AllowRowResequencing = false;
            this.versionIdentifierSoftwareListControl.BackColor = System.Drawing.Color.AliceBlue;
            this.versionIdentifierSoftwareListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.versionIdentifierSoftwareListControl.FormTitle = null;
            this.versionIdentifierSoftwareListControl.HasErrors = false;
            this.versionIdentifierSoftwareListControl.HelpKeyWord = null;
            this.versionIdentifierSoftwareListControl.LastError = null;
            this.versionIdentifierSoftwareListControl.ListName = null;
            this.versionIdentifierSoftwareListControl.Location = new System.Drawing.Point(3, 3);
            this.versionIdentifierSoftwareListControl.Margin = new System.Windows.Forms.Padding(0);
            this.versionIdentifierSoftwareListControl.Name = "versionIdentifierSoftwareListControl";
            this.versionIdentifierSoftwareListControl.SchemaTypeName = null;
            this.versionIdentifierSoftwareListControl.ShowFind = false;
            this.versionIdentifierSoftwareListControl.Size = new System.Drawing.Size(454, 469);
            this.versionIdentifierSoftwareListControl.TabIndex = 0;
            this.versionIdentifierSoftwareListControl.TargetNamespace = null;
            this.versionIdentifierSoftwareListControl.TooltipTextAddButton = "Press to add a new Version";
            this.versionIdentifierSoftwareListControl.TooltipTextDeleteButton = "Press to delete the selected Version";
            this.versionIdentifierSoftwareListControl.TooltipTextEditButton = "Press to edit the selected Version";
            this.versionIdentifierSoftwareListControl.VersionIdentifiers = null;
            // 
            // ControlDriverDependenciesControl
            // 
            this.Controls.Add(this.Software);
            this.Name = "ControlDriverDependenciesControl";
            this.Size = new System.Drawing.Size(468, 501);
            this.Software.ResumeLayout(false);
            this.tabFirmware.ResumeLayout(false);
            this.tabSoftware.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl Software;
        private System.Windows.Forms.TabPage tabFirmware;
        private System.Windows.Forms.TabPage tabSoftware;
        private VersionIdentifierListControl versionIdentifierFirmwareListControl;
        private VersionIdentifierListControl versionIdentifierSoftwareListControl;
    }
}
