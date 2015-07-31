/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

namespace ATMLCommonLibrary.controls.controller
{
    partial class ControllerControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.edtDatumPhysicalMemory = new ATMLCommonLibrary.controls.datum.DatumTypeDoubleControl();
            this.helpLabel1 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.tab = new System.Windows.Forms.TabControl();
            this.tabOperatingSystems = new System.Windows.Forms.TabPage();
            this.controllerOperatingSystemListControl1 = new ATMLCommonLibrary.controls.controller.ControllerOperatingSystemListControl();
            this.tabVideoCapabilities = new System.Windows.Forms.TabPage();
            this.VideoCapabilities = new ATMLCommonLibrary.controls.awb.AWBTextCollectionList();
            this.tabAudioCapabilities = new System.Windows.Forms.TabPage();
            this.AudioCapabilities1 = new ATMLCommonLibrary.controls.awb.AWBTextCollectionList();
            this.tabProcessor = new System.Windows.Forms.TabPage();
            this.controllerProcessorControl1 = new ATMLCommonLibrary.controls.controller.ControllerProcessorControl();
            this.tabPeripherals = new System.Windows.Forms.TabPage();
            this.Peripherals = new ATMLCommonLibrary.controls.lists.ItemDescriptionListControl();
            this.tabInstalledSoftware = new System.Windows.Forms.TabPage();
            this.InstalledSoftware = new ATMLCommonLibrary.controls.lists.ItemDescriptionListControl();
            this.tabStorage = new System.Windows.Forms.TabPage();
            this.ControllerDrive = new ATMLCommonLibrary.controls.controller.ControllerDriveListControl();
            this.controllerOperatingSystemControl1 = new ATMLCommonLibrary.controls.controller.ControllerOperatingSystemControl();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.tab.SuspendLayout();
            this.tabOperatingSystems.SuspendLayout();
            this.tabVideoCapabilities.SuspendLayout();
            this.tabAudioCapabilities.SuspendLayout();
            this.tabProcessor.SuspendLayout();
            this.tabPeripherals.SuspendLayout();
            this.tabInstalledSoftware.SuspendLayout();
            this.tabStorage.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 7);
            // 
            // edtName
            // 
            this.edtName.Location = new System.Drawing.Point(103, 4);
            // 
            // identificationControl
            // 
            this.identificationControl.Location = new System.Drawing.Point(0, 174);
            this.identificationControl.Size = new System.Drawing.Size(640, 177);
            this.identificationControl.TabIndex = 8;
            // 
            // edtDescription
            // 
            this.edtDescription.Location = new System.Drawing.Point(103, 57);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 57);
            // 
            // edtVersion
            // 
            this.edtVersion.Location = new System.Drawing.Point(103, 30);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 33);
            // 
            // edtDatumPhysicalMemory
            // 
            this.edtDatumPhysicalMemory.BackColor = System.Drawing.Color.Maroon;
            this.edtDatumPhysicalMemory.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.edtDatumPhysicalMemory.HasErrors = false;
            this.edtDatumPhysicalMemory.HelpKeyWord = null;
            this.edtDatumPhysicalMemory.LastError = null;
            this.edtDatumPhysicalMemory.Location = new System.Drawing.Point(103, 125);
            this.edtDatumPhysicalMemory.Name = "edtDatumPhysicalMemory";
            this.edtDatumPhysicalMemory.SchemaTypeName = null;
            this.edtDatumPhysicalMemory.Size = new System.Drawing.Size(306, 29);
            this.edtDatumPhysicalMemory.TabIndex = 7;
            this.edtDatumPhysicalMemory.TargetNamespace = null;
            this.edtDatumPhysicalMemory.UseFlowControl = null;
            // 
            // helpLabel1
            // 
            this.helpLabel1.AutoSize = true;
            this.helpLabel1.HelpMessageKey = "Controller.PhysicalMemory";
            this.helpLabel1.Location = new System.Drawing.Point(8, 125);
            this.helpLabel1.Name = "helpLabel1";
            this.helpLabel1.RequiredField = false;
            this.helpLabel1.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel1.Size = new System.Drawing.Size(89, 13);
            this.helpLabel1.TabIndex = 6;
            this.helpLabel1.Text = "Physical Memory:";
            // 
            // tab
            // 
            this.tab.Controls.Add(this.tabOperatingSystems);
            this.tab.Controls.Add(this.tabVideoCapabilities);
            this.tab.Controls.Add(this.tabAudioCapabilities);
            this.tab.Controls.Add(this.tabProcessor);
            this.tab.Controls.Add(this.tabPeripherals);
            this.tab.Controls.Add(this.tabInstalledSoftware);
            this.tab.Controls.Add(this.tabStorage);
            this.tab.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tab.Location = new System.Drawing.Point(0, 357);
            this.tab.Name = "tab";
            this.tab.SelectedIndex = 0;
            this.tab.Size = new System.Drawing.Size(640, 174);
            this.tab.TabIndex = 9;
            // 
            // tabOperatingSystems
            // 
            this.tabOperatingSystems.Controls.Add(this.controllerOperatingSystemListControl1);
            this.tabOperatingSystems.Location = new System.Drawing.Point(4, 22);
            this.tabOperatingSystems.Name = "tabOperatingSystems";
            this.tabOperatingSystems.Padding = new System.Windows.Forms.Padding(3);
            this.tabOperatingSystems.Size = new System.Drawing.Size(632, 148);
            this.tabOperatingSystems.TabIndex = 0;
            this.tabOperatingSystems.Text = "Operating Systems";
            this.tabOperatingSystems.UseVisualStyleBackColor = true;
            // 
            // controllerOperatingSystemListControl1
            // 
            this.controllerOperatingSystemListControl1.AllowRowResequencing = false;
            this.controllerOperatingSystemListControl1.BackColor = System.Drawing.Color.AliceBlue;
            this.controllerOperatingSystemListControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controllerOperatingSystemListControl1.FormTitle = null;
            this.controllerOperatingSystemListControl1.HasErrors = false;
            this.controllerOperatingSystemListControl1.HelpKeyWord = null;
            this.controllerOperatingSystemListControl1.LastError = null;
            this.controllerOperatingSystemListControl1.ListName = null;
            this.controllerOperatingSystemListControl1.Location = new System.Drawing.Point(3, 3);
            this.controllerOperatingSystemListControl1.Margin = new System.Windows.Forms.Padding(0);
            this.controllerOperatingSystemListControl1.Name = "controllerOperatingSystemListControl1";
            this.controllerOperatingSystemListControl1.SchemaTypeName = null;
            this.controllerOperatingSystemListControl1.ShowFind = false;
            this.controllerOperatingSystemListControl1.Size = new System.Drawing.Size(626, 142);
            this.controllerOperatingSystemListControl1.TabIndex = 0;
            this.controllerOperatingSystemListControl1.TargetNamespace = null;
            this.controllerOperatingSystemListControl1.TooltipTextAddButton = "Press to add a new ";
            this.controllerOperatingSystemListControl1.TooltipTextDeleteButton = "Press to delete the selected ";
            this.controllerOperatingSystemListControl1.TooltipTextEditButton = "Press to edit the selected ";
            // 
            // tabVideoCapabilities
            // 
            this.tabVideoCapabilities.Controls.Add(this.VideoCapabilities);
            this.tabVideoCapabilities.Location = new System.Drawing.Point(4, 22);
            this.tabVideoCapabilities.Name = "tabVideoCapabilities";
            this.tabVideoCapabilities.Padding = new System.Windows.Forms.Padding(3);
            this.tabVideoCapabilities.Size = new System.Drawing.Size(632, 148);
            this.tabVideoCapabilities.TabIndex = 5;
            this.tabVideoCapabilities.Text = "Video Capabilities";
            this.tabVideoCapabilities.UseVisualStyleBackColor = true;
            // 
            // VideoCapabilities
            // 
            this.VideoCapabilities.BackColor = System.Drawing.Color.AliceBlue;
            this.VideoCapabilities.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VideoCapabilities.HasErrors = false;
            this.VideoCapabilities.HelpKeyWord = null;
            this.VideoCapabilities.LastError = null;
            this.VideoCapabilities.Location = new System.Drawing.Point(3, 3);
            this.VideoCapabilities.Name = "VideoCapabilities";
            this.VideoCapabilities.SchemaTypeName = null;
            this.VideoCapabilities.Size = new System.Drawing.Size(626, 142);
            this.VideoCapabilities.TabIndex = 0;
            this.VideoCapabilities.TargetNamespace = null;
            // 
            // tabAudioCapabilities
            // 
            this.tabAudioCapabilities.Controls.Add(this.AudioCapabilities1);
            this.tabAudioCapabilities.Location = new System.Drawing.Point(4, 22);
            this.tabAudioCapabilities.Name = "tabAudioCapabilities";
            this.tabAudioCapabilities.Padding = new System.Windows.Forms.Padding(3);
            this.tabAudioCapabilities.Size = new System.Drawing.Size(632, 148);
            this.tabAudioCapabilities.TabIndex = 6;
            this.tabAudioCapabilities.Text = "Audio Capabilities";
            this.tabAudioCapabilities.UseVisualStyleBackColor = true;
            // 
            // AudioCapabilities1
            // 
            this.AudioCapabilities1.BackColor = System.Drawing.Color.AliceBlue;
            this.AudioCapabilities1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AudioCapabilities1.HasErrors = false;
            this.AudioCapabilities1.HelpKeyWord = null;
            this.AudioCapabilities1.LastError = null;
            this.AudioCapabilities1.Location = new System.Drawing.Point(3, 3);
            this.AudioCapabilities1.Name = "AudioCapabilities1";
            this.AudioCapabilities1.SchemaTypeName = null;
            this.AudioCapabilities1.Size = new System.Drawing.Size(626, 142);
            this.AudioCapabilities1.TabIndex = 0;
            this.AudioCapabilities1.TargetNamespace = null;
            // 
            // tabProcessor
            // 
            this.tabProcessor.Controls.Add(this.controllerProcessorControl1);
            this.tabProcessor.Location = new System.Drawing.Point(4, 22);
            this.tabProcessor.Name = "tabProcessor";
            this.tabProcessor.Padding = new System.Windows.Forms.Padding(3);
            this.tabProcessor.Size = new System.Drawing.Size(632, 148);
            this.tabProcessor.TabIndex = 7;
            this.tabProcessor.Text = "Processor";
            this.tabProcessor.UseVisualStyleBackColor = true;
            // 
            // controllerProcessorControl1
            // 
            this.controllerProcessorControl1.AutoScroll = true;
            this.controllerProcessorControl1.BackColor = System.Drawing.Color.AliceBlue;
            this.controllerProcessorControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controllerProcessorControl1.HasErrors = false;
            this.controllerProcessorControl1.HelpKeyWord = null;
            this.controllerProcessorControl1.LastError = null;
            this.controllerProcessorControl1.Location = new System.Drawing.Point(3, 3);
            this.controllerProcessorControl1.Name = "controllerProcessorControl1";
            this.controllerProcessorControl1.SchemaTypeName = null;
            this.controllerProcessorControl1.Size = new System.Drawing.Size(626, 142);
            this.controllerProcessorControl1.TabIndex = 0;
            this.controllerProcessorControl1.TargetNamespace = null;
            // 
            // tabPeripherals
            // 
            this.tabPeripherals.Controls.Add(this.Peripherals);
            this.tabPeripherals.Location = new System.Drawing.Point(4, 22);
            this.tabPeripherals.Name = "tabPeripherals";
            this.tabPeripherals.Padding = new System.Windows.Forms.Padding(3);
            this.tabPeripherals.Size = new System.Drawing.Size(632, 148);
            this.tabPeripherals.TabIndex = 8;
            this.tabPeripherals.Text = "Peripherals";
            this.tabPeripherals.UseVisualStyleBackColor = true;
            // 
            // Peripherals
            // 
            this.Peripherals.AllowRowResequencing = false;
            this.Peripherals.BackColor = System.Drawing.Color.AliceBlue;
            this.Peripherals.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Peripherals.FormTitle = null;
            this.Peripherals.HasErrors = false;
            this.Peripherals.HelpKeyWord = null;
            this.Peripherals.ItemsDescriptions = null;
            this.Peripherals.LastError = null;
            this.Peripherals.ListName = null;
            this.Peripherals.Location = new System.Drawing.Point(3, 3);
            this.Peripherals.Margin = new System.Windows.Forms.Padding(0);
            this.Peripherals.Name = "Peripherals";
            this.Peripherals.SchemaTypeName = null;
            this.Peripherals.ShowFind = false;
            this.Peripherals.Size = new System.Drawing.Size(626, 142);
            this.Peripherals.TabIndex = 0;
            this.Peripherals.TargetNamespace = null;
            this.Peripherals.TooltipTextAddButton = "Press to add a new ";
            this.Peripherals.TooltipTextDeleteButton = "Press to delete the selected ";
            this.Peripherals.TooltipTextEditButton = "Press to edit the selected ";
            // 
            // tabInstalledSoftware
            // 
            this.tabInstalledSoftware.Controls.Add(this.InstalledSoftware);
            this.tabInstalledSoftware.Location = new System.Drawing.Point(4, 22);
            this.tabInstalledSoftware.Name = "tabInstalledSoftware";
            this.tabInstalledSoftware.Padding = new System.Windows.Forms.Padding(3);
            this.tabInstalledSoftware.Size = new System.Drawing.Size(632, 148);
            this.tabInstalledSoftware.TabIndex = 9;
            this.tabInstalledSoftware.Text = "Installed Software";
            this.tabInstalledSoftware.UseVisualStyleBackColor = true;
            // 
            // InstalledSoftware
            // 
            this.InstalledSoftware.AllowRowResequencing = false;
            this.InstalledSoftware.BackColor = System.Drawing.Color.AliceBlue;
            this.InstalledSoftware.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InstalledSoftware.FormTitle = null;
            this.InstalledSoftware.HasErrors = false;
            this.InstalledSoftware.HelpKeyWord = null;
            this.InstalledSoftware.ItemsDescriptions = null;
            this.InstalledSoftware.LastError = null;
            this.InstalledSoftware.ListName = null;
            this.InstalledSoftware.Location = new System.Drawing.Point(3, 3);
            this.InstalledSoftware.Margin = new System.Windows.Forms.Padding(0);
            this.InstalledSoftware.Name = "InstalledSoftware";
            this.InstalledSoftware.SchemaTypeName = null;
            this.InstalledSoftware.ShowFind = false;
            this.InstalledSoftware.Size = new System.Drawing.Size(626, 142);
            this.InstalledSoftware.TabIndex = 0;
            this.InstalledSoftware.TargetNamespace = null;
            this.InstalledSoftware.TooltipTextAddButton = "Press to add a new ";
            this.InstalledSoftware.TooltipTextDeleteButton = "Press to delete the selected ";
            this.InstalledSoftware.TooltipTextEditButton = "Press to edit the selected ";
            // 
            // tabStorage
            // 
            this.tabStorage.Controls.Add(this.ControllerDrive);
            this.tabStorage.Location = new System.Drawing.Point(4, 22);
            this.tabStorage.Name = "tabStorage";
            this.tabStorage.Padding = new System.Windows.Forms.Padding(3);
            this.tabStorage.Size = new System.Drawing.Size(632, 148);
            this.tabStorage.TabIndex = 10;
            this.tabStorage.Text = "Storage";
            this.tabStorage.UseVisualStyleBackColor = true;
            // 
            // ControllerDrive
            // 
            this.ControllerDrive.AllowRowResequencing = false;
            this.ControllerDrive.BackColor = System.Drawing.Color.AliceBlue;
            this.ControllerDrive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ControllerDrive.FormTitle = null;
            this.ControllerDrive.HasErrors = false;
            this.ControllerDrive.HelpKeyWord = null;
            this.ControllerDrive.LastError = null;
            this.ControllerDrive.ListName = null;
            this.ControllerDrive.Location = new System.Drawing.Point(3, 3);
            this.ControllerDrive.Margin = new System.Windows.Forms.Padding(0);
            this.ControllerDrive.Name = "ControllerDrive";
            this.ControllerDrive.SchemaTypeName = null;
            this.ControllerDrive.ShowFind = false;
            this.ControllerDrive.Size = new System.Drawing.Size(626, 142);
            this.ControllerDrive.TabIndex = 0;
            this.ControllerDrive.TargetNamespace = null;
            this.ControllerDrive.TooltipTextAddButton = "Press to add a new ";
            this.ControllerDrive.TooltipTextDeleteButton = "Press to delete the selected ";
            this.ControllerDrive.TooltipTextEditButton = "Press to edit the selected ";
            // 
            // controllerOperatingSystemControl1
            // 
            this.controllerOperatingSystemControl1.BackColor = System.Drawing.Color.AliceBlue;
            this.controllerOperatingSystemControl1.Location = new System.Drawing.Point(0, 0);
            this.controllerOperatingSystemControl1.Name = "controllerOperatingSystemControl1";
            this.controllerOperatingSystemControl1.Size = new System.Drawing.Size(640, 465);
            this.controllerOperatingSystemControl1.TabIndex = 0;
            // 
            // ControllerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tab);
            this.Controls.Add(this.helpLabel1);
            this.Controls.Add(this.edtDatumPhysicalMemory);
            this.Name = "ControllerControl";
            this.Size = new System.Drawing.Size(640, 531);
            this.Controls.SetChildIndex(this.edtDatumPhysicalMemory, 0);
            this.Controls.SetChildIndex(this.helpLabel1, 0);
            this.Controls.SetChildIndex(this.tab, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.edtName, 0);
            this.Controls.SetChildIndex(this.identificationControl, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.edtDescription, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.edtVersion, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.tab.ResumeLayout(false);
            this.tabOperatingSystems.ResumeLayout(false);
            this.tabVideoCapabilities.ResumeLayout(false);
            this.tabAudioCapabilities.ResumeLayout(false);
            this.tabProcessor.ResumeLayout(false);
            this.tabPeripherals.ResumeLayout(false);
            this.tabInstalledSoftware.ResumeLayout(false);
            this.tabStorage.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private datum.DatumTypeDoubleControl edtDatumPhysicalMemory;
        private HelpLabel helpLabel1;
        private System.Windows.Forms.TabControl tab;
        private System.Windows.Forms.TabPage tabOperatingSystems;
        private System.Windows.Forms.TabPage tabVideoCapabilities;
        private System.Windows.Forms.TabPage tabAudioCapabilities;
        private System.Windows.Forms.TabPage tabProcessor;
        private System.Windows.Forms.TabPage tabPeripherals;
        private System.Windows.Forms.TabPage tabInstalledSoftware;
        private System.Windows.Forms.TabPage tabStorage;
        private ControllerOperatingSystemControl controllerOperatingSystemControl1;
        private ControllerOperatingSystemControl controllerOperatingSystemControl2;
        private ControllerOperatingSystemControl controllerOperatingSystemControl3;
        private ControllerOperatingSystemControl controllerOperatingSystemControl4;
        private ControllerProcessorControl controllerProcessorControl1;
        private ControllerDriveListControl ControllerDrive;
        private awb.AWBTextCollectionList VideoCapabilities;
        private lists.ItemDescriptionListControl Peripherals;
        private lists.ItemDescriptionListControl InstalledSoftware;
        private awb.AWBTextCollectionList AudioCapabilities1;
        private ControllerOperatingSystemListControl controllerOperatingSystemListControl1;
    }
}
