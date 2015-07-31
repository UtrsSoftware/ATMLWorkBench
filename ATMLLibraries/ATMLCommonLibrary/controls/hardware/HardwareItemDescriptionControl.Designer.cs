/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using ATMLCommonLibrary.controls.document;
using ATMLCommonLibrary.controls.lists;
using ATMLCommonLibrary.controls.network;

namespace ATMLCommonLibrary.controls.hardware
{
    partial class HardwareItemDescriptionControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HardwareItemDescriptionControl));
            this.tabDescription = new System.Windows.Forms.TabPage();
            this.edtDescription = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.RequirementsTabControl = new ATMLCommonLibrary.controls.awb.AWBTabControl();
            this.tabCalibration = new System.Windows.Forms.TabPage();
            this.calibrationRequirementListControl = new ATMLCommonLibrary.controls.calibration.CalibrationRequirementListControl();
            this.tabOperational = new System.Windows.Forms.TabPage();
            this.operationalRequirementsControl = new ATMLCommonLibrary.controls.operational.OperationalRequirementsControl();
            this.tabEnvironmental = new System.Windows.Forms.TabPage();
            this.environmentalRequirementsControl1 = new ATMLCommonLibrary.controls.environmental.EnvironmentalRequirementsControl();
            this.tabPower = new System.Windows.Forms.TabPage();
            this.powerRequirementListControl = new ATMLCommonLibrary.controls.power.PowerRequirementListControl();
            this.tabIdentification = new System.Windows.Forms.TabPage();
            this.panelIdentification = new System.Windows.Forms.Panel();
            this.identificationControl = new ATMLCommonLibrary.controls.IdentificationControl();
            this.tabInterface = new System.Windows.Forms.TabPage();
            this.interfaceListControl = new ATMLCommonLibrary.controls.lists.PhysicalInterfaceListControl();
            this.tabComponents = new System.Windows.Forms.TabPage();
            this.componentListControl = new ATMLCommonLibrary.controls.lists.ComponentListControl();
            this.tabParentComponents = new System.Windows.Forms.TabPage();
            this.parentComponentListControl = new ATMLCommonLibrary.controls.component.ParentComponentListControl();
            this.tabControl = new System.Windows.Forms.TabPage();
            this.controlControl = new ATMLCommonLibrary.controls.control.ControlControl();
            this.tabDocumentation = new System.Windows.Forms.TabPage();
            this.documentListControl = new ATMLCommonLibrary.controls.document.DocumentListControl();
            this.tabConfiguration = new System.Windows.Forms.TabPage();
            this.configurationOptionListControl = new ATMLCommonLibrary.controls.hardware.ConfigurationOptionListControl();
            this.tabDefaults = new System.Windows.Forms.TabPage();
            this.factoryDefaultsListControl = new ATMLCommonLibrary.controls.hardware.FactoryDefaultsListControl();
            this.tabRequirements = new System.Windows.Forms.TabPage();
            this.tabPanelControl = new System.Windows.Forms.TabControl();
            this.tabCharacteristics = new System.Windows.Forms.TabPage();
            this.physicalCharacteristicsControl = new ATMLCommonLibrary.controls.hardware.characteristics.PhysicalCharacteristicsControl();
            this.tabNetwork = new System.Windows.Forms.TabPage();
            this.networkListControl = new ATMLCommonLibrary.controls.network.NetworkListControl();
            this.tabErrors = new System.Windows.Forms.TabPage();
            this.errorListControl = new ATMLCommonLibrary.controls.error.ErrorListControl();
            this.tabLegal = new System.Windows.Forms.TabPage();
            this.legalDocumentListControl = new ATMLCommonLibrary.controls.document.LegalDocumentListControl();
            this.helpLabel1 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtName = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.helpLabel2 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtVersion = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.tabDescription.SuspendLayout();
            this.RequirementsTabControl.SuspendLayout();
            this.tabCalibration.SuspendLayout();
            this.tabOperational.SuspendLayout();
            this.tabEnvironmental.SuspendLayout();
            this.tabPower.SuspendLayout();
            this.tabIdentification.SuspendLayout();
            this.panelIdentification.SuspendLayout();
            this.tabInterface.SuspendLayout();
            this.tabComponents.SuspendLayout();
            this.tabParentComponents.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabDocumentation.SuspendLayout();
            this.tabConfiguration.SuspendLayout();
            this.tabDefaults.SuspendLayout();
            this.tabRequirements.SuspendLayout();
            this.tabPanelControl.SuspendLayout();
            this.tabCharacteristics.SuspendLayout();
            this.tabNetwork.SuspendLayout();
            this.tabErrors.SuspendLayout();
            this.tabLegal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // tabDescription
            // 
            this.tabDescription.Controls.Add(this.edtDescription);
            this.tabDescription.Location = new System.Drawing.Point(129, 4);
            this.tabDescription.Margin = new System.Windows.Forms.Padding(0);
            this.tabDescription.Name = "tabDescription";
            this.tabDescription.Padding = new System.Windows.Forms.Padding(10);
            this.tabDescription.Size = new System.Drawing.Size(429, 340);
            this.tabDescription.TabIndex = 3;
            this.tabDescription.Text = "Description";
            this.tabDescription.UseVisualStyleBackColor = true;
            // 
            // edtDescription
            // 
            this.edtDescription.AcceptsReturn = true;
            this.edtDescription.AttributeName = null;
            this.edtDescription.BackColor = System.Drawing.Color.PaleTurquoise;
            this.edtDescription.DataLookupKey = null;
            this.edtDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtDescription.Location = new System.Drawing.Point(10, 10);
            this.edtDescription.Margin = new System.Windows.Forms.Padding(5);
            this.edtDescription.Multiline = true;
            this.edtDescription.Name = "edtDescription";
            this.edtDescription.Size = new System.Drawing.Size(409, 320);
            this.edtDescription.TabIndex = 0;
            this.edtDescription.Value = null;
            this.edtDescription.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // RequirementsTabControl
            // 
            this.RequirementsTabControl.Controls.Add(this.tabCalibration);
            this.RequirementsTabControl.Controls.Add(this.tabOperational);
            this.RequirementsTabControl.Controls.Add(this.tabEnvironmental);
            this.RequirementsTabControl.Controls.Add(this.tabPower);
            this.RequirementsTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RequirementsTabControl.Location = new System.Drawing.Point(0, 0);
            this.RequirementsTabControl.MainBackColor = System.Drawing.Color.AliceBlue;
            this.RequirementsTabControl.Name = "RequirementsTabControl";
            this.RequirementsTabControl.SelectedIndex = 0;
            this.RequirementsTabControl.Size = new System.Drawing.Size(429, 340);
            this.RequirementsTabControl.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.RequirementsTabControl.TabColor = System.Drawing.Color.Empty;
            this.RequirementsTabControl.TabIndex = 1;
            // 
            // tabCalibration
            // 
            this.tabCalibration.Controls.Add(this.calibrationRequirementListControl);
            this.tabCalibration.Location = new System.Drawing.Point(4, 25);
            this.tabCalibration.Name = "tabCalibration";
            this.tabCalibration.Padding = new System.Windows.Forms.Padding(3);
            this.tabCalibration.Size = new System.Drawing.Size(421, 311);
            this.tabCalibration.TabIndex = 0;
            this.tabCalibration.Text = "Calibration";
            // 
            // calibrationRequirementListControl
            // 
            this.calibrationRequirementListControl.AllowRowResequencing = false;
            this.calibrationRequirementListControl.BackColor = System.Drawing.Color.AliceBlue;
            this.calibrationRequirementListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.calibrationRequirementListControl.FormTitle = null;
            this.calibrationRequirementListControl.HasErrors = false;
            this.calibrationRequirementListControl.HelpKeyWord = null;
            this.calibrationRequirementListControl.LastError = null;
            this.calibrationRequirementListControl.ListName = null;
            this.calibrationRequirementListControl.Location = new System.Drawing.Point(3, 3);
            this.calibrationRequirementListControl.Margin = new System.Windows.Forms.Padding(0);
            this.calibrationRequirementListControl.Name = "calibrationRequirementListControl";
            this.calibrationRequirementListControl.SchemaTypeName = null;
            this.calibrationRequirementListControl.ShowFind = false;
            this.calibrationRequirementListControl.Size = new System.Drawing.Size(415, 305);
            this.calibrationRequirementListControl.TabIndex = 0;
            this.calibrationRequirementListControl.TargetNamespace = null;
            this.calibrationRequirementListControl.TooltipTextAddButton = "Press to add a new ";
            this.calibrationRequirementListControl.TooltipTextDeleteButton = "Press to delete the selected ";
            this.calibrationRequirementListControl.TooltipTextEditButton = "Press to edit the selected ";
            // 
            // tabOperational
            // 
            this.tabOperational.Controls.Add(this.operationalRequirementsControl);
            this.tabOperational.Location = new System.Drawing.Point(4, 25);
            this.tabOperational.Name = "tabOperational";
            this.tabOperational.Padding = new System.Windows.Forms.Padding(3);
            this.tabOperational.Size = new System.Drawing.Size(421, 311);
            this.tabOperational.TabIndex = 1;
            this.tabOperational.Text = "Operational";
            // 
            // operationalRequirementsControl
            // 
            this.operationalRequirementsControl.BackColor = System.Drawing.Color.AliceBlue;
            this.operationalRequirementsControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.operationalRequirementsControl.HasErrors = false;
            this.operationalRequirementsControl.HelpKeyWord = null;
            this.operationalRequirementsControl.LastError = null;
            this.operationalRequirementsControl.Location = new System.Drawing.Point(3, 3);
            this.operationalRequirementsControl.Name = "operationalRequirementsControl";
            this.operationalRequirementsControl.SchemaTypeName = null;
            this.operationalRequirementsControl.Size = new System.Drawing.Size(415, 305);
            this.operationalRequirementsControl.TabIndex = 0;
            this.operationalRequirementsControl.TargetNamespace = null;
            // 
            // tabEnvironmental
            // 
            this.tabEnvironmental.Controls.Add(this.environmentalRequirementsControl1);
            this.tabEnvironmental.Location = new System.Drawing.Point(4, 25);
            this.tabEnvironmental.Name = "tabEnvironmental";
            this.tabEnvironmental.Size = new System.Drawing.Size(421, 311);
            this.tabEnvironmental.TabIndex = 2;
            this.tabEnvironmental.Text = "Environmental";
            // 
            // environmentalRequirementsControl1
            // 
            this.environmentalRequirementsControl1.BackColor = System.Drawing.Color.AliceBlue;
            this.environmentalRequirementsControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.environmentalRequirementsControl1.HasErrors = false;
            this.environmentalRequirementsControl1.HelpKeyWord = null;
            this.environmentalRequirementsControl1.LastError = null;
            this.environmentalRequirementsControl1.Location = new System.Drawing.Point(0, 0);
            this.environmentalRequirementsControl1.Name = "environmentalRequirementsControl1";
            this.environmentalRequirementsControl1.SchemaTypeName = null;
            this.environmentalRequirementsControl1.Size = new System.Drawing.Size(421, 311);
            this.environmentalRequirementsControl1.TabIndex = 0;
            this.environmentalRequirementsControl1.TargetNamespace = null;
            // 
            // tabPower
            // 
            this.tabPower.Controls.Add(this.powerRequirementListControl);
            this.tabPower.Location = new System.Drawing.Point(4, 25);
            this.tabPower.Name = "tabPower";
            this.tabPower.Size = new System.Drawing.Size(421, 311);
            this.tabPower.TabIndex = 3;
            this.tabPower.Text = "Power";
            // 
            // powerRequirementListControl
            // 
            this.powerRequirementListControl.AllowRowResequencing = false;
            this.powerRequirementListControl.BackColor = System.Drawing.Color.AliceBlue;
            this.powerRequirementListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.powerRequirementListControl.FormTitle = null;
            this.powerRequirementListControl.HasErrors = false;
            this.powerRequirementListControl.HelpKeyWord = null;
            this.powerRequirementListControl.LastError = null;
            this.powerRequirementListControl.ListName = null;
            this.powerRequirementListControl.Location = new System.Drawing.Point(0, 0);
            this.powerRequirementListControl.Margin = new System.Windows.Forms.Padding(0);
            this.powerRequirementListControl.Name = "powerRequirementListControl";
            this.powerRequirementListControl.PowerRequirements = null;
            this.powerRequirementListControl.SchemaTypeName = null;
            this.powerRequirementListControl.ShowFind = false;
            this.powerRequirementListControl.Size = new System.Drawing.Size(421, 311);
            this.powerRequirementListControl.TabIndex = 0;
            this.powerRequirementListControl.TargetNamespace = null;
            this.powerRequirementListControl.TooltipTextAddButton = "Press to add a new ";
            this.powerRequirementListControl.TooltipTextDeleteButton = "Press to delete the selected ";
            this.powerRequirementListControl.TooltipTextEditButton = "Press to edit the selected ";
            // 
            // tabIdentification
            // 
            this.tabIdentification.Controls.Add(this.panelIdentification);
            this.tabIdentification.Location = new System.Drawing.Point(129, 4);
            this.tabIdentification.Name = "tabIdentification";
            this.tabIdentification.Size = new System.Drawing.Size(429, 340);
            this.tabIdentification.TabIndex = 4;
            this.tabIdentification.Text = "Identification";
            this.tabIdentification.UseVisualStyleBackColor = true;
            // 
            // panelIdentification
            // 
            this.panelIdentification.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(223)))), ((int)(((byte)(231)))));
            this.panelIdentification.Controls.Add(this.identificationControl);
            this.panelIdentification.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelIdentification.Location = new System.Drawing.Point(0, 0);
            this.panelIdentification.Margin = new System.Windows.Forms.Padding(0);
            this.panelIdentification.Name = "panelIdentification";
            this.panelIdentification.Size = new System.Drawing.Size(429, 340);
            this.panelIdentification.TabIndex = 1;
            // 
            // identificationControl
            // 
            this.identificationControl.BackColor = System.Drawing.Color.Transparent;
            this.identificationControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.identificationControl.HasErrors = false;
            this.identificationControl.HelpKeyWord = null;
            this.identificationControl.LastError = null;
            this.identificationControl.Location = new System.Drawing.Point(0, 0);
            this.identificationControl.Name = "identificationControl";
            this.identificationControl.SchemaTypeName = null;
            this.identificationControl.Size = new System.Drawing.Size(429, 340);
            this.identificationControl.TabIndex = 0;
            this.identificationControl.TargetNamespace = null;
            // 
            // tabInterface
            // 
            this.tabInterface.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(223)))), ((int)(((byte)(231)))));
            this.tabInterface.Controls.Add(this.interfaceListControl);
            this.tabInterface.Location = new System.Drawing.Point(129, 4);
            this.tabInterface.Name = "tabInterface";
            this.tabInterface.Size = new System.Drawing.Size(429, 340);
            this.tabInterface.TabIndex = 5;
            this.tabInterface.Text = "Interface";
            // 
            // interfaceListControl
            // 
            this.interfaceListControl.BackColor = System.Drawing.Color.AliceBlue;
            this.interfaceListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.interfaceListControl.HasConnectors = true;
            this.interfaceListControl.HasErrors = false;
            this.interfaceListControl.HelpKeyWord = null;
            this.interfaceListControl.LastError = null;
            this.interfaceListControl.Location = new System.Drawing.Point(0, 0);
            this.interfaceListControl.Name = "interfaceListControl";
            this.interfaceListControl.SchemaTypeName = null;
            this.interfaceListControl.Size = new System.Drawing.Size(429, 340);
            this.interfaceListControl.TabIndex = 0;
            this.interfaceListControl.TargetNamespace = null;
            // 
            // tabComponents
            // 
            this.tabComponents.Controls.Add(this.componentListControl);
            this.tabComponents.Location = new System.Drawing.Point(129, 4);
            this.tabComponents.Margin = new System.Windows.Forms.Padding(0);
            this.tabComponents.Name = "tabComponents";
            this.tabComponents.Size = new System.Drawing.Size(429, 340);
            this.tabComponents.TabIndex = 0;
            this.tabComponents.Text = "Components";
            this.tabComponents.UseVisualStyleBackColor = true;
            // 
            // componentListControl
            // 
            this.componentListControl.AllowRowResequencing = false;
            this.componentListControl.BackColor = System.Drawing.Color.AliceBlue;
            this.componentListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.componentListControl.FormTitle = null;
            this.componentListControl.HasErrors = false;
            this.componentListControl.HelpKeyWord = null;
            this.componentListControl.LastError = null;
            this.componentListControl.ListName = null;
            this.componentListControl.Location = new System.Drawing.Point(0, 0);
            this.componentListControl.Margin = new System.Windows.Forms.Padding(0);
            this.componentListControl.Name = "componentListControl";
            this.componentListControl.SchemaTypeName = null;
            this.componentListControl.ShowFind = false;
            this.componentListControl.Size = new System.Drawing.Size(429, 340);
            this.componentListControl.TabIndex = 0;
            this.componentListControl.TargetNamespace = null;
            this.componentListControl.TooltipTextAddButton = "Press to add a new ";
            this.componentListControl.TooltipTextDeleteButton = "Press to delete the selected ";
            this.componentListControl.TooltipTextEditButton = "Press to edit the selected ";
            // 
            // tabParentComponents
            // 
            this.tabParentComponents.Controls.Add(this.parentComponentListControl);
            this.tabParentComponents.Location = new System.Drawing.Point(129, 4);
            this.tabParentComponents.Name = "tabParentComponents";
            this.tabParentComponents.Size = new System.Drawing.Size(429, 340);
            this.tabParentComponents.TabIndex = 6;
            this.tabParentComponents.Text = "Parent Components";
            this.tabParentComponents.UseVisualStyleBackColor = true;
            // 
            // parentComponentListControl
            // 
            this.parentComponentListControl.AllowRowResequencing = false;
            this.parentComponentListControl.BackColor = System.Drawing.Color.AliceBlue;
            this.parentComponentListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.parentComponentListControl.FormTitle = null;
            this.parentComponentListControl.HasErrors = false;
            this.parentComponentListControl.HelpKeyWord = null;
            this.parentComponentListControl.LastError = null;
            this.parentComponentListControl.ListName = null;
            this.parentComponentListControl.Location = new System.Drawing.Point(0, 0);
            this.parentComponentListControl.Margin = new System.Windows.Forms.Padding(0);
            this.parentComponentListControl.Name = "parentComponentListControl";
            this.parentComponentListControl.SchemaTypeName = null;
            this.parentComponentListControl.ShowFind = false;
            this.parentComponentListControl.Size = new System.Drawing.Size(429, 340);
            this.parentComponentListControl.TabIndex = 0;
            this.parentComponentListControl.TargetNamespace = null;
            this.parentComponentListControl.TooltipTextAddButton = "Press to add a new ";
            this.parentComponentListControl.TooltipTextDeleteButton = "Press to delete the selected ";
            this.parentComponentListControl.TooltipTextEditButton = "Press to edit the selected ";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.controlControl);
            this.tabControl.Location = new System.Drawing.Point(129, 4);
            this.tabControl.Name = "tabControl";
            this.tabControl.Size = new System.Drawing.Size(429, 340);
            this.tabControl.TabIndex = 7;
            this.tabControl.Text = "Control";
            this.tabControl.UseVisualStyleBackColor = true;
            // 
            // controlControl
            // 
            this.controlControl.BackColor = System.Drawing.Color.AliceBlue;
            this.controlControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlControl.HasErrors = false;
            this.controlControl.HelpKeyWord = null;
            this.controlControl.LastError = null;
            this.controlControl.Location = new System.Drawing.Point(0, 0);
            this.controlControl.Name = "controlControl";
            this.controlControl.SchemaTypeName = null;
            this.controlControl.Size = new System.Drawing.Size(429, 340);
            this.controlControl.TabIndex = 0;
            this.controlControl.TargetNamespace = null;
            // 
            // tabDocumentation
            // 
            this.tabDocumentation.Controls.Add(this.documentListControl);
            this.tabDocumentation.Location = new System.Drawing.Point(129, 4);
            this.tabDocumentation.Name = "tabDocumentation";
            this.tabDocumentation.Size = new System.Drawing.Size(429, 340);
            this.tabDocumentation.TabIndex = 8;
            this.tabDocumentation.Text = "Documentation";
            this.tabDocumentation.UseVisualStyleBackColor = true;
            // 
            // documentListControl
            // 
            this.documentListControl.AllowRowResequencing = false;
            this.documentListControl.BackColor = System.Drawing.Color.AliceBlue;
            this.documentListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.documentListControl.DocumentType = ATMLDataAccessLibrary.model.dbDocument.DocumentType.NONE;
            this.documentListControl.FormTitle = null;
            this.documentListControl.HasErrors = false;
            this.documentListControl.HelpKeyWord = null;
            this.documentListControl.LastError = null;
            this.documentListControl.ListName = null;
            this.documentListControl.Location = new System.Drawing.Point(0, 0);
            this.documentListControl.Margin = new System.Windows.Forms.Padding(0);
            this.documentListControl.Name = "documentListControl";
            this.documentListControl.SchemaTypeName = null;
            this.documentListControl.ShowFind = false;
            this.documentListControl.Size = new System.Drawing.Size(429, 340);
            this.documentListControl.TabIndex = 0;
            this.documentListControl.TargetNamespace = null;
            this.documentListControl.TooltipTextAddButton = "Press to add a new ";
            this.documentListControl.TooltipTextDeleteButton = "Press to delete the selected ";
            this.documentListControl.TooltipTextEditButton = "Press to edit the selected ";
            // 
            // tabConfiguration
            // 
            this.tabConfiguration.Controls.Add(this.configurationOptionListControl);
            this.tabConfiguration.Location = new System.Drawing.Point(129, 4);
            this.tabConfiguration.Name = "tabConfiguration";
            this.tabConfiguration.Size = new System.Drawing.Size(429, 340);
            this.tabConfiguration.TabIndex = 9;
            this.tabConfiguration.Text = "Configuration";
            this.tabConfiguration.UseVisualStyleBackColor = true;
            // 
            // configurationOptionListControl
            // 
            this.configurationOptionListControl.BackColor = System.Drawing.Color.AliceBlue;
            this.configurationOptionListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.configurationOptionListControl.HasErrors = false;
            this.configurationOptionListControl.HelpKeyWord = null;
            this.configurationOptionListControl.LastError = null;
            this.configurationOptionListControl.Location = new System.Drawing.Point(0, 0);
            this.configurationOptionListControl.Name = "configurationOptionListControl";
            this.configurationOptionListControl.SchemaTypeName = null;
            this.configurationOptionListControl.Size = new System.Drawing.Size(429, 340);
            this.configurationOptionListControl.TabIndex = 0;
            this.configurationOptionListControl.TargetNamespace = null;
            // 
            // tabDefaults
            // 
            this.tabDefaults.Controls.Add(this.factoryDefaultsListControl);
            this.tabDefaults.Location = new System.Drawing.Point(129, 4);
            this.tabDefaults.Name = "tabDefaults";
            this.tabDefaults.Size = new System.Drawing.Size(429, 340);
            this.tabDefaults.TabIndex = 10;
            this.tabDefaults.Text = "Defaults";
            this.tabDefaults.UseVisualStyleBackColor = true;
            // 
            // factoryDefaultsListControl
            // 
            this.factoryDefaultsListControl.AllowRowResequencing = false;
            this.factoryDefaultsListControl.BackColor = System.Drawing.Color.AliceBlue;
            this.factoryDefaultsListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.factoryDefaultsListControl.FactoryDefaults = null;
            this.factoryDefaultsListControl.FormTitle = null;
            this.factoryDefaultsListControl.HasErrors = false;
            this.factoryDefaultsListControl.HelpKeyWord = null;
            this.factoryDefaultsListControl.LastError = null;
            this.factoryDefaultsListControl.ListName = null;
            this.factoryDefaultsListControl.Location = new System.Drawing.Point(0, 0);
            this.factoryDefaultsListControl.Margin = new System.Windows.Forms.Padding(0);
            this.factoryDefaultsListControl.Name = "factoryDefaultsListControl";
            this.factoryDefaultsListControl.SchemaTypeName = null;
            this.factoryDefaultsListControl.ShowFind = false;
            this.factoryDefaultsListControl.Size = new System.Drawing.Size(429, 340);
            this.factoryDefaultsListControl.TabIndex = 0;
            this.factoryDefaultsListControl.TargetNamespace = null;
            this.factoryDefaultsListControl.TooltipTextAddButton = "Press to add a new ";
            this.factoryDefaultsListControl.TooltipTextDeleteButton = "Press to delete the selected ";
            this.factoryDefaultsListControl.TooltipTextEditButton = "Press to edit the selected ";
            // 
            // tabRequirements
            // 
            this.tabRequirements.Controls.Add(this.RequirementsTabControl);
            this.tabRequirements.Location = new System.Drawing.Point(129, 4);
            this.tabRequirements.Name = "tabRequirements";
            this.tabRequirements.Size = new System.Drawing.Size(429, 340);
            this.tabRequirements.TabIndex = 11;
            this.tabRequirements.Text = "Requirements";
            this.tabRequirements.UseVisualStyleBackColor = true;
            // 
            // tabPanelControl
            // 
            this.tabPanelControl.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabPanelControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabPanelControl.Controls.Add(this.tabIdentification);
            this.tabPanelControl.Controls.Add(this.tabDescription);
            this.tabPanelControl.Controls.Add(this.tabInterface);
            this.tabPanelControl.Controls.Add(this.tabComponents);
            this.tabPanelControl.Controls.Add(this.tabParentComponents);
            this.tabPanelControl.Controls.Add(this.tabControl);
            this.tabPanelControl.Controls.Add(this.tabDocumentation);
            this.tabPanelControl.Controls.Add(this.tabConfiguration);
            this.tabPanelControl.Controls.Add(this.tabDefaults);
            this.tabPanelControl.Controls.Add(this.tabRequirements);
            this.tabPanelControl.Controls.Add(this.tabCharacteristics);
            this.tabPanelControl.Controls.Add(this.tabNetwork);
            this.tabPanelControl.Controls.Add(this.tabErrors);
            this.tabPanelControl.Controls.Add(this.tabLegal);
            this.tabPanelControl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabPanelControl.ItemSize = new System.Drawing.Size(22, 125);
            this.tabPanelControl.Location = new System.Drawing.Point(0, 32);
            this.tabPanelControl.Multiline = true;
            this.tabPanelControl.Name = "tabPanelControl";
            this.tabPanelControl.SelectedIndex = 0;
            this.tabPanelControl.Size = new System.Drawing.Size(562, 348);
            this.tabPanelControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabPanelControl.TabIndex = 4;
            this.tabPanelControl.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl1_DrawItem);
            // 
            // tabCharacteristics
            // 
            this.tabCharacteristics.Controls.Add(this.physicalCharacteristicsControl);
            this.tabCharacteristics.Location = new System.Drawing.Point(129, 4);
            this.tabCharacteristics.Name = "tabCharacteristics";
            this.tabCharacteristics.Size = new System.Drawing.Size(429, 340);
            this.tabCharacteristics.TabIndex = 12;
            this.tabCharacteristics.Text = "Characteristics";
            this.tabCharacteristics.UseVisualStyleBackColor = true;
            // 
            // physicalCharacteristicsControl
            // 
            this.physicalCharacteristicsControl.BackColor = System.Drawing.Color.AliceBlue;
            this.physicalCharacteristicsControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.physicalCharacteristicsControl.HasErrors = false;
            this.physicalCharacteristicsControl.HelpKeyWord = null;
            this.physicalCharacteristicsControl.LastError = null;
            this.physicalCharacteristicsControl.Location = new System.Drawing.Point(0, 0);
            this.physicalCharacteristicsControl.MinimumSize = new System.Drawing.Size(488, 248);
            this.physicalCharacteristicsControl.Name = "physicalCharacteristicsControl";
            this.physicalCharacteristicsControl.SchemaTypeName = null;
            this.physicalCharacteristicsControl.Size = new System.Drawing.Size(488, 340);
            this.physicalCharacteristicsControl.TabIndex = 0;
            this.physicalCharacteristicsControl.TargetNamespace = null;
            // 
            // tabNetwork
            // 
            this.tabNetwork.Controls.Add(this.networkListControl);
            this.tabNetwork.Location = new System.Drawing.Point(129, 4);
            this.tabNetwork.Name = "tabNetwork";
            this.tabNetwork.Size = new System.Drawing.Size(429, 340);
            this.tabNetwork.TabIndex = 13;
            this.tabNetwork.Text = "Network";
            this.tabNetwork.UseVisualStyleBackColor = true;
            // 
            // networkListControl
            // 
            this.networkListControl.AllowRowResequencing = false;
            this.networkListControl.BackColor = System.Drawing.Color.AliceBlue;
            this.networkListControl.CapabilityMapMode = false;
            this.networkListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.networkListControl.FormTitle = null;
            this.networkListControl.HasErrors = false;
            this.networkListControl.HelpKeyWord = null;
            this.networkListControl.LastError = null;
            this.networkListControl.ListName = null;
            this.networkListControl.Location = new System.Drawing.Point(0, 0);
            this.networkListControl.Mapping = null;
            this.networkListControl.Margin = new System.Windows.Forms.Padding(0);
            this.networkListControl.Name = "networkListControl";
            this.networkListControl.SchemaTypeName = null;
            this.networkListControl.ShowFind = false;
            this.networkListControl.Size = new System.Drawing.Size(429, 340);
            this.networkListControl.TabIndex = 0;
            this.networkListControl.TargetNamespace = null;
            this.networkListControl.TooltipTextAddButton = "Press to add a new ";
            this.networkListControl.TooltipTextDeleteButton = "Press to delete the selected ";
            this.networkListControl.TooltipTextEditButton = "Press to edit the selected ";
            // 
            // tabErrors
            // 
            this.tabErrors.Controls.Add(this.errorListControl);
            this.tabErrors.Location = new System.Drawing.Point(129, 4);
            this.tabErrors.Name = "tabErrors";
            this.tabErrors.Size = new System.Drawing.Size(429, 340);
            this.tabErrors.TabIndex = 2;
            this.tabErrors.Text = "Errors";
            this.tabErrors.UseVisualStyleBackColor = true;
            // 
            // errorListControl
            // 
            this.errorListControl.AllowRowResequencing = false;
            this.errorListControl.BackColor = System.Drawing.Color.AliceBlue;
            this.errorListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.errorListControl.FormTitle = null;
            this.errorListControl.HasErrors = false;
            this.errorListControl.HelpKeyWord = null;
            this.errorListControl.LastError = null;
            this.errorListControl.ListName = null;
            this.errorListControl.Location = new System.Drawing.Point(0, 0);
            this.errorListControl.Margin = new System.Windows.Forms.Padding(0);
            this.errorListControl.Name = "errorListControl";
            this.errorListControl.SchemaTypeName = null;
            this.errorListControl.ShowFind = false;
            this.errorListControl.Size = new System.Drawing.Size(429, 340);
            this.errorListControl.TabIndex = 0;
            this.errorListControl.TargetNamespace = null;
            this.errorListControl.TooltipTextAddButton = "Press to add a new ";
            this.errorListControl.TooltipTextDeleteButton = "Press to delete the selected ";
            this.errorListControl.TooltipTextEditButton = "Press to edit the selected ";
            // 
            // tabLegal
            // 
            this.tabLegal.Controls.Add(this.legalDocumentListControl);
            this.tabLegal.Location = new System.Drawing.Point(129, 4);
            this.tabLegal.Name = "tabLegal";
            this.tabLegal.Size = new System.Drawing.Size(429, 340);
            this.tabLegal.TabIndex = 14;
            this.tabLegal.Text = "Legal";
            this.tabLegal.UseVisualStyleBackColor = true;
            // 
            // legalDocumentListControl
            // 
            this.legalDocumentListControl.AllowRowResequencing = false;
            this.legalDocumentListControl.BackColor = System.Drawing.Color.AliceBlue;
            this.legalDocumentListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.legalDocumentListControl.FormTitle = null;
            this.legalDocumentListControl.HasErrors = false;
            this.legalDocumentListControl.HelpKeyWord = null;
            this.legalDocumentListControl.LastError = null;
            this.legalDocumentListControl.LegalDocuments = null;
            this.legalDocumentListControl.ListName = null;
            this.legalDocumentListControl.Location = new System.Drawing.Point(0, 0);
            this.legalDocumentListControl.Margin = new System.Windows.Forms.Padding(0);
            this.legalDocumentListControl.Name = "legalDocumentListControl";
            this.legalDocumentListControl.SchemaTypeName = null;
            this.legalDocumentListControl.ShowFind = false;
            this.legalDocumentListControl.Size = new System.Drawing.Size(429, 340);
            this.legalDocumentListControl.TabIndex = 0;
            this.legalDocumentListControl.TargetNamespace = null;
            this.legalDocumentListControl.TooltipTextAddButton = "Press to add a new ";
            this.legalDocumentListControl.TooltipTextDeleteButton = "Press to delete the selected ";
            this.legalDocumentListControl.TooltipTextEditButton = "Press to edit the selected ";
            // 
            // helpLabel1
            // 
            this.helpLabel1.AutoSize = true;
            this.helpLabel1.HelpMessageKey = null;
            this.helpLabel1.Location = new System.Drawing.Point(24, 9);
            this.helpLabel1.Name = "helpLabel1";
            this.helpLabel1.RequiredField = false;
            this.helpLabel1.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel1.Size = new System.Drawing.Size(35, 13);
            this.helpLabel1.TabIndex = 0;
            this.helpLabel1.Text = "Name";
            // 
            // edtName
            // 
            this.edtName.AttributeName = null;
            this.edtName.BackColor = System.Drawing.Color.PaleTurquoise;
            this.edtName.DataLookupKey = null;
            this.edtName.Location = new System.Drawing.Point(64, 6);
            this.edtName.Name = "edtName";
            this.edtName.Size = new System.Drawing.Size(309, 20);
            this.edtName.TabIndex = 1;
            this.edtName.Value = null;
            this.edtName.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // helpLabel2
            // 
            this.helpLabel2.AutoSize = true;
            this.helpLabel2.HelpMessageKey = null;
            this.helpLabel2.Location = new System.Drawing.Point(389, 9);
            this.helpLabel2.Name = "helpLabel2";
            this.helpLabel2.RequiredField = false;
            this.helpLabel2.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel2.Size = new System.Drawing.Size(42, 13);
            this.helpLabel2.TabIndex = 2;
            this.helpLabel2.Text = "Version";
            // 
            // edtVersion
            // 
            this.edtVersion.AttributeName = null;
            this.edtVersion.DataLookupKey = null;
            this.edtVersion.Location = new System.Drawing.Point(436, 6);
            this.edtVersion.Name = "edtVersion";
            this.edtVersion.Size = new System.Drawing.Size(104, 20);
            this.edtVersion.TabIndex = 3;
            this.edtVersion.Value = null;
            this.edtVersion.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "information.png");
            this.imageList.Images.SetKeyName(1, "text_area.png");
            this.imageList.Images.SetKeyName(2, "connect.png");
            this.imageList.Images.SetKeyName(3, "resources.png");
            this.imageList.Images.SetKeyName(4, "action_log.png");
            this.imageList.Images.SetKeyName(5, "switch.png");
            this.imageList.Images.SetKeyName(6, "control_panel.png");
            this.imageList.Images.SetKeyName(7, "document_properties.png");
            this.imageList.Images.SetKeyName(8, "networking.png");
            this.imageList.Images.SetKeyName(9, "edit_path.png");
            this.imageList.Images.SetKeyName(10, "file_extension_divx.png");
            this.imageList.Images.SetKeyName(11, "atm.png");
            this.imageList.Images.SetKeyName(12, "building.png");
            this.imageList.Images.SetKeyName(13, "location_pin.png");
            this.imageList.Images.SetKeyName(14, "error.png");
            this.imageList.Images.SetKeyName(15, "document_layout.png");
            this.imageList.Images.SetKeyName(16, "balance.png");
            this.imageList.Images.SetKeyName(17, "control_repeat_blue.png");
            this.imageList.Images.SetKeyName(18, "calculator.png");
            this.imageList.Images.SetKeyName(19, "terminal.png");
            this.imageList.Images.SetKeyName(20, "computer.png");
            this.imageList.Images.SetKeyName(21, "calculator_black.png");
            // 
            // HardwareItemDescriptionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.Controls.Add(this.edtVersion);
            this.Controls.Add(this.helpLabel2);
            this.Controls.Add(this.edtName);
            this.Controls.Add(this.helpLabel1);
            this.Controls.Add(this.tabPanelControl);
            this.Name = "HardwareItemDescriptionControl";
            this.Size = new System.Drawing.Size(562, 380);
            this.Validating += new System.ComponentModel.CancelEventHandler(this.HardwareItemDescriptionControl_Validating);
            this.tabDescription.ResumeLayout(false);
            this.tabDescription.PerformLayout();
            this.RequirementsTabControl.ResumeLayout(false);
            this.tabCalibration.ResumeLayout(false);
            this.tabOperational.ResumeLayout(false);
            this.tabEnvironmental.ResumeLayout(false);
            this.tabPower.ResumeLayout(false);
            this.tabIdentification.ResumeLayout(false);
            this.panelIdentification.ResumeLayout(false);
            this.tabInterface.ResumeLayout(false);
            this.tabComponents.ResumeLayout(false);
            this.tabParentComponents.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabDocumentation.ResumeLayout(false);
            this.tabConfiguration.ResumeLayout(false);
            this.tabDefaults.ResumeLayout(false);
            this.tabRequirements.ResumeLayout(false);
            this.tabPanelControl.ResumeLayout(false);
            this.tabCharacteristics.ResumeLayout(false);
            this.tabNetwork.ResumeLayout(false);
            this.tabErrors.ResumeLayout(false);
            this.tabLegal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.TabPage tabDescription;
        protected ATMLCommonLibrary.controls.awb.AWBTextBox edtDescription;
        protected ATMLCommonLibrary.controls.awb.AWBTabControl RequirementsTabControl;
        protected System.Windows.Forms.TabPage tabCalibration;
        protected System.Windows.Forms.TabPage tabOperational;
        protected System.Windows.Forms.TabPage tabEnvironmental;
        protected System.Windows.Forms.TabPage tabPower;
        protected System.Windows.Forms.TabPage tabIdentification;
        protected System.Windows.Forms.Panel panelIdentification;
        protected IdentificationControl identificationControl;
        protected System.Windows.Forms.TabPage tabInterface;
        protected PhysicalInterfaceListControl interfaceListControl;
        protected System.Windows.Forms.TabPage tabComponents;
        protected lists.ComponentListControl componentListControl;
        protected System.Windows.Forms.TabPage tabParentComponents;
        protected System.Windows.Forms.TabPage tabControl;
        protected System.Windows.Forms.TabPage tabDocumentation;
        protected System.Windows.Forms.TabPage tabConfiguration;
        protected System.Windows.Forms.TabPage tabDefaults;
        protected System.Windows.Forms.TabPage tabRequirements;
        protected System.Windows.Forms.TabControl tabPanelControl;
        protected System.Windows.Forms.TabPage tabNetwork;
        protected System.Windows.Forms.TabPage tabErrors;
        protected System.Windows.Forms.TabPage tabLegal;
        protected HelpLabel helpLabel1;
        protected ATMLCommonLibrary.controls.awb.AWBTextBox edtName;
        protected HelpLabel helpLabel2;
        protected ATMLCommonLibrary.controls.awb.AWBTextBox edtVersion;
        protected power.PowerRequirementListControl powerRequirementListControl;
        protected LegalDocumentListControl legalDocumentListControl;
        protected System.Windows.Forms.TabPage tabCharacteristics;
        protected hardware.characteristics.PhysicalCharacteristicsControl physicalCharacteristicsControl;
        protected environmental.EnvironmentalRequirementsControl environmentalRequirementsControl1;
        protected error.ErrorListControl errorListControl;
        protected hardware.ConfigurationOptionListControl configurationOptionListControl;
        protected operational.OperationalRequirementsControl operationalRequirementsControl;
        protected calibration.CalibrationRequirementListControl calibrationRequirementListControl;
        protected ATMLCommonLibrary.controls.hardware.FactoryDefaultsListControl factoryDefaultsListControl;
        protected NetworkListControl networkListControl;
        protected component.ParentComponentListControl parentComponentListControl;
        private control.ControlControl controlControl;
        protected System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.ImageList imageList;
        protected DocumentListControl documentListControl;
    }
}
