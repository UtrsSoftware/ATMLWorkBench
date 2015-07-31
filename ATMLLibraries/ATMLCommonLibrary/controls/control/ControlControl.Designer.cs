/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using ATMLCommonLibrary.controls.control.driver;
using ATMLCommonLibrary.controls.control.language;
using ATMLCommonLibrary.controls.control.tool;

namespace ATMLCommonLibrary.controls.control
{
    partial class ControlControl
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
            this.tabControl1 = new ATMLCommonLibrary.controls.awb.AWBTabControl();
            this.tabFirmwares = new System.Windows.Forms.TabPage();
            this.firmwareListControl = new ATMLCommonLibrary.controls.control.FirmwareListControl();
            this.tabDrivers = new System.Windows.Forms.TabPage();
            this.driverListControl = new ATMLCommonLibrary.controls.control.driver.ControlDriverListControl();
            this.tabControlLanguages = new System.Windows.Forms.TabPage();
            this.controlLanguageListControl = new ATMLCommonLibrary.controls.control.language.ControlLanguageListControl();
            this.tabTools = new System.Windows.Forms.TabPage();
            this.toolsListControl = new ATMLCommonLibrary.controls.control.tool.ControlToolListControl();
            this.tabControl1.SuspendLayout();
            this.tabFirmwares.SuspendLayout();
            this.tabDrivers.SuspendLayout();
            this.tabControlLanguages.SuspendLayout();
            this.tabTools.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabFirmwares);
            this.tabControl1.Controls.Add(this.tabDrivers);
            this.tabControl1.Controls.Add(this.tabControlLanguages);
            this.tabControl1.Controls.Add(this.tabTools);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.MainBackColor = System.Drawing.SystemColors.Control;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(438, 150);
            this.tabControl1.TabIndex = 0;
            // 
            // tabFirmwares
            // 
            this.tabFirmwares.BackColor = System.Drawing.SystemColors.Control;
            this.tabFirmwares.Controls.Add(this.firmwareListControl);
            this.tabFirmwares.ForeColor = System.Drawing.Color.Black;
            this.tabFirmwares.Location = new System.Drawing.Point(4, 25);
            this.tabFirmwares.Name = "tabFirmwares";
            this.tabFirmwares.Padding = new System.Windows.Forms.Padding(3);
            this.tabFirmwares.Size = new System.Drawing.Size(430, 121);
            this.tabFirmwares.TabIndex = 0;
            this.tabFirmwares.Text = "Firmwares";
            // 
            // firmwareListControl
            // 
            this.firmwareListControl.AllowRowResequencing = false;
            this.firmwareListControl.BackColor = System.Drawing.Color.AliceBlue;
            this.firmwareListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.firmwareListControl.FormTitle = "Firmware";
            this.firmwareListControl.HasErrors = false;
            this.firmwareListControl.HelpKeyWord = null;
            this.firmwareListControl.LastError = null;
            this.firmwareListControl.ListName = null;
            this.firmwareListControl.Location = new System.Drawing.Point(3, 3);
            this.firmwareListControl.Margin = new System.Windows.Forms.Padding(0);
            this.firmwareListControl.Name = "firmwareListControl";
            this.firmwareListControl.SchemaTypeName = null;
            this.firmwareListControl.ShowFind = false;
            this.firmwareListControl.Size = new System.Drawing.Size(424, 115);
            this.firmwareListControl.TabIndex = 0;
            this.firmwareListControl.TargetNamespace = null;
            this.firmwareListControl.TooltipTextAddButton = "Press to add a new ";
            this.firmwareListControl.TooltipTextDeleteButton = "Press to delete the selected ";
            this.firmwareListControl.TooltipTextEditButton = "Press to edit the selected ";
            // 
            // tabDrivers
            // 
            this.tabDrivers.BackColor = System.Drawing.SystemColors.Control;
            this.tabDrivers.Controls.Add(this.driverListControl);
            this.tabDrivers.Location = new System.Drawing.Point(4, 25);
            this.tabDrivers.Name = "tabDrivers";
            this.tabDrivers.Padding = new System.Windows.Forms.Padding(3);
            this.tabDrivers.Size = new System.Drawing.Size(430, 121);
            this.tabDrivers.TabIndex = 1;
            this.tabDrivers.Text = "Drivers";
            // 
            // driverListControl
            // 
            this.driverListControl.AllowRowResequencing = false;
            this.driverListControl.BackColor = System.Drawing.Color.AliceBlue;
            this.driverListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.driverListControl.FormTitle = null;
            this.driverListControl.HasErrors = false;
            this.driverListControl.HelpKeyWord = null;
            this.driverListControl.LastError = null;
            this.driverListControl.ListName = null;
            this.driverListControl.Location = new System.Drawing.Point(3, 3);
            this.driverListControl.Margin = new System.Windows.Forms.Padding(0);
            this.driverListControl.Name = "driverListControl";
            this.driverListControl.SchemaTypeName = null;
            this.driverListControl.ShowFind = false;
            this.driverListControl.Size = new System.Drawing.Size(424, 115);
            this.driverListControl.TabIndex = 0;
            this.driverListControl.TargetNamespace = null;
            this.driverListControl.TooltipTextAddButton = "Press to add a new ";
            this.driverListControl.TooltipTextDeleteButton = "Press to delete the selected ";
            this.driverListControl.TooltipTextEditButton = "Press to edit the selected ";
            // 
            // tabControlLanguages
            // 
            this.tabControlLanguages.BackColor = System.Drawing.SystemColors.Control;
            this.tabControlLanguages.Controls.Add(this.controlLanguageListControl);
            this.tabControlLanguages.Location = new System.Drawing.Point(4, 25);
            this.tabControlLanguages.Name = "tabControlLanguages";
            this.tabControlLanguages.Size = new System.Drawing.Size(430, 121);
            this.tabControlLanguages.TabIndex = 2;
            this.tabControlLanguages.Text = "Control Languages";
            // 
            // controlLanguageListControl
            // 
            this.controlLanguageListControl.AllowRowResequencing = false;
            this.controlLanguageListControl.BackColor = System.Drawing.Color.AliceBlue;
            this.controlLanguageListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlLanguageListControl.FormTitle = null;
            this.controlLanguageListControl.HasErrors = false;
            this.controlLanguageListControl.HelpKeyWord = null;
            this.controlLanguageListControl.LastError = null;
            this.controlLanguageListControl.ListName = null;
            this.controlLanguageListControl.Location = new System.Drawing.Point(0, 0);
            this.controlLanguageListControl.Margin = new System.Windows.Forms.Padding(0);
            this.controlLanguageListControl.Name = "controlLanguageListControl";
            this.controlLanguageListControl.SchemaTypeName = null;
            this.controlLanguageListControl.ShowFind = false;
            this.controlLanguageListControl.Size = new System.Drawing.Size(430, 121);
            this.controlLanguageListControl.TabIndex = 0;
            this.controlLanguageListControl.TargetNamespace = null;
            this.controlLanguageListControl.TooltipTextAddButton = "Press to add a new ";
            this.controlLanguageListControl.TooltipTextDeleteButton = "Press to delete the selected ";
            this.controlLanguageListControl.TooltipTextEditButton = "Press to edit the selected ";
            // 
            // tabTools
            // 
            this.tabTools.BackColor = System.Drawing.SystemColors.Control;
            this.tabTools.Controls.Add(this.toolsListControl);
            this.tabTools.Location = new System.Drawing.Point(4, 25);
            this.tabTools.Name = "tabTools";
            this.tabTools.Size = new System.Drawing.Size(430, 121);
            this.tabTools.TabIndex = 3;
            this.tabTools.Text = "Tools";
            // 
            // toolsListControl
            // 
            this.toolsListControl.AllowRowResequencing = false;
            this.toolsListControl.BackColor = System.Drawing.Color.AliceBlue;
            this.toolsListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolsListControl.FormTitle = null;
            this.toolsListControl.HardwareItemDescriptionControlTool = null;
            this.toolsListControl.HasErrors = false;
            this.toolsListControl.HelpKeyWord = null;
            this.toolsListControl.LastError = null;
            this.toolsListControl.ListName = null;
            this.toolsListControl.Location = new System.Drawing.Point(0, 0);
            this.toolsListControl.Margin = new System.Windows.Forms.Padding(0);
            this.toolsListControl.Name = "toolsListControl";
            this.toolsListControl.SchemaTypeName = null;
            this.toolsListControl.ShowFind = false;
            this.toolsListControl.Size = new System.Drawing.Size(430, 121);
            this.toolsListControl.TabIndex = 0;
            this.toolsListControl.TargetNamespace = null;
            this.toolsListControl.TooltipTextAddButton = "Press to add a new ";
            this.toolsListControl.TooltipTextDeleteButton = "Press to delete the selected ";
            this.toolsListControl.TooltipTextEditButton = "Press to edit the selected ";
            // 
            // ControlControl
            // 
            this.Controls.Add(this.tabControl1);
            this.Name = "ControlControl";
            this.Size = new System.Drawing.Size(438, 150);
            this.tabControl1.ResumeLayout(false);
            this.tabFirmwares.ResumeLayout(false);
            this.tabDrivers.ResumeLayout(false);
            this.tabControlLanguages.ResumeLayout(false);
            this.tabTools.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ATMLCommonLibrary.controls.awb.AWBTabControl tabControl1;
        private System.Windows.Forms.TabPage tabFirmwares;
        private System.Windows.Forms.TabPage tabDrivers;
        private System.Windows.Forms.TabPage tabControlLanguages;
        private System.Windows.Forms.TabPage tabTools;
        private FirmwareListControl firmwareListControl;
        private ControlDriverListControl driverListControl;
       // private ControlLanguageListControl controlLanguageListControl;
        private ControlToolListControl toolsListControl;
        private ControlLanguageListControl controlLanguageListControl;
    }
}
