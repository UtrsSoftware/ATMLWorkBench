/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using ATMLCommonLibrary.controls.capability;
using ATMLCommonLibrary.controls.hardware;
using ATMLCommonLibrary.controls.network;
using ATMLCommonLibrary.controls.resource;
using ATMLCommonLibrary.controls.specification;

namespace ATMLCommonLibrary.controls.instrument
{
    partial class InstrumentControl
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
            if( disposing && ( components != null ) )
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InstrumentControl));
            this.cmbInstrumentType = new System.Windows.Forms.ComboBox();
            this.edtInstrumentUUID = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.tabCapabilities = new System.Windows.Forms.TabPage();
            this.capabilitiesControl1 = new ATMLCommonLibrary.controls.capability.CapabilitiesControl();
            this.tabHardware = new System.Windows.Forms.TabPage();
            this.hardwareItemDescriptionControl = new ATMLCommonLibrary.controls.hardware.HardwareItemDescriptionControl();
            this.tabResources = new System.Windows.Forms.TabPage();
            this.resourceListControl = new ATMLCommonLibrary.controls.resource.ResourceListControl();
            this.tabSwitching = new System.Windows.Forms.TabPage();
            this.switchingListControl = new ATMLCommonLibrary.controls.lists.SwitchingListControl();
            this.mappingListControl1 = new ATMLCommonLibrary.controls.network.MappingListControl();
            this.tabSpecifications = new System.Windows.Forms.TabPage();
            this.specificationsControl = new ATMLCommonLibrary.controls.specification.SpecificationsControl();
            this.tabPowerOnDefaults = new System.Windows.Forms.TabPage();
            this.powerOnDefaultsListControl = new ATMLCommonLibrary.controls.power.PowerOnDefaultListControl();
            this.tabBusses = new System.Windows.Forms.TabPage();
            this.busListControl = new ATMLCommonLibrary.controls.bus.BusListControl();
            this.xsdUUIDSchemaValidator = new ATMLCommonLibrary.controls.validators.XSDSchemaValidator();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnAddGUID = new ATMLCommonLibrary.controls.awb.AWBButton();
            this.lblInstrumentDescriptionUUID = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.lblInstrumentDescriptionType = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.tabPaths = new System.Windows.Forms.TabPage();
            this.pathListControl = new ATMLCommonLibrary.controls.path.PathListControl();
            this.securityClassificationControl = new WindowsFormsApplication10.SecurityClassificationControl();
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
            this.tabDocumentation.SuspendLayout();
            this.tabConfiguration.SuspendLayout();
            this.tabDefaults.SuspendLayout();
            this.tabRequirements.SuspendLayout();
            this.tabPanelControl.SuspendLayout();
            this.tabNetwork.SuspendLayout();
            this.tabErrors.SuspendLayout();
            this.tabLegal.SuspendLayout();
            this.tabCharacteristics.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.tabCapabilities.SuspendLayout();
            this.tabHardware.SuspendLayout();
            this.tabResources.SuspendLayout();
            this.tabSwitching.SuspendLayout();
            this.tabSpecifications.SuspendLayout();
            this.tabPowerOnDefaults.SuspendLayout();
            this.tabBusses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.tabPaths.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabDescription
            // 
            this.tabDescription.ForeColor = System.Drawing.Color.Black;
            this.tabDescription.Size = new System.Drawing.Size(529, 478);
            // 
            // edtDescription
            // 
            this.edtDescription.Size = new System.Drawing.Size(509, 458);
            // 
            // RequirementsTabControl
            // 
            this.RequirementsTabControl.Size = new System.Drawing.Size(529, 478);
            // 
            // tabCalibration
            // 
            this.tabCalibration.Size = new System.Drawing.Size(521, 452);
            // 
            // tabOperational
            // 
            this.tabOperational.Size = new System.Drawing.Size(421, 314);
            // 
            // tabEnvironmental
            // 
            this.tabEnvironmental.Size = new System.Drawing.Size(421, 314);
            // 
            // tabPower
            // 
            this.tabPower.Size = new System.Drawing.Size(421, 314);
            // 
            // tabIdentification
            // 
            this.tabIdentification.ForeColor = System.Drawing.Color.Black;
            this.tabIdentification.Size = new System.Drawing.Size(529, 478);
            // 
            // panelIdentification
            // 
            this.panelIdentification.Size = new System.Drawing.Size(529, 478);
            // 
            // identificationControl
            // 
            this.identificationControl.Size = new System.Drawing.Size(529, 478);
            // 
            // tabInterface
            // 
            this.tabInterface.ForeColor = System.Drawing.Color.Black;
            this.tabInterface.Size = new System.Drawing.Size(529, 478);
            // 
            // interfaceListControl
            // 
            this.interfaceListControl.Size = new System.Drawing.Size(529, 478);
            // 
            // tabComponents
            // 
            this.tabComponents.ForeColor = System.Drawing.Color.Black;
            this.tabComponents.Size = new System.Drawing.Size(529, 478);
            // 
            // componentListControl
            // 
            this.componentListControl.Size = new System.Drawing.Size(529, 478);
            // 
            // tabParentComponents
            // 
            this.tabParentComponents.ForeColor = System.Drawing.Color.Black;
            this.tabParentComponents.Size = new System.Drawing.Size(529, 478);
            // 
            // tabControl
            // 
            this.tabControl.ForeColor = System.Drawing.Color.Black;
            this.tabControl.Size = new System.Drawing.Size(529, 478);
            // 
            // tabDocumentation
            // 
            this.tabDocumentation.ForeColor = System.Drawing.Color.Black;
            this.tabDocumentation.Size = new System.Drawing.Size(529, 478);
            // 
            // tabConfiguration
            // 
            this.tabConfiguration.ForeColor = System.Drawing.Color.Black;
            this.tabConfiguration.Size = new System.Drawing.Size(529, 478);
            // 
            // tabDefaults
            // 
            this.tabDefaults.ForeColor = System.Drawing.Color.Black;
            this.tabDefaults.Size = new System.Drawing.Size(529, 478);
            // 
            // tabRequirements
            // 
            this.tabRequirements.ForeColor = System.Drawing.Color.Black;
            this.tabRequirements.Size = new System.Drawing.Size(529, 478);
            // 
            // tabPanelControl
            // 
            this.tabPanelControl.Controls.Add(this.tabResources);
            this.tabPanelControl.Controls.Add(this.tabSwitching);
            this.tabPanelControl.Controls.Add(this.tabCapabilities);
            this.tabPanelControl.Controls.Add(this.tabSpecifications);
            this.tabPanelControl.Controls.Add(this.tabPowerOnDefaults);
            this.tabPanelControl.Controls.Add(this.tabBusses);
            this.tabPanelControl.Controls.Add(this.tabPaths);
            this.tabPanelControl.Location = new System.Drawing.Point(12, 72);
            this.tabPanelControl.Size = new System.Drawing.Size(662, 486);
            this.tabPanelControl.TabIndex = 5;
            this.tabPanelControl.Controls.SetChildIndex(this.tabPaths, 0);
            this.tabPanelControl.Controls.SetChildIndex(this.tabBusses, 0);
            this.tabPanelControl.Controls.SetChildIndex(this.tabPowerOnDefaults, 0);
            this.tabPanelControl.Controls.SetChildIndex(this.tabSpecifications, 0);
            this.tabPanelControl.Controls.SetChildIndex(this.tabCapabilities, 0);
            this.tabPanelControl.Controls.SetChildIndex(this.tabSwitching, 0);
            this.tabPanelControl.Controls.SetChildIndex(this.tabResources, 0);
            this.tabPanelControl.Controls.SetChildIndex(this.tabLegal, 0);
            this.tabPanelControl.Controls.SetChildIndex(this.tabErrors, 0);
            this.tabPanelControl.Controls.SetChildIndex(this.tabNetwork, 0);
            this.tabPanelControl.Controls.SetChildIndex(this.tabCharacteristics, 0);
            this.tabPanelControl.Controls.SetChildIndex(this.tabRequirements, 0);
            this.tabPanelControl.Controls.SetChildIndex(this.tabDefaults, 0);
            this.tabPanelControl.Controls.SetChildIndex(this.tabConfiguration, 0);
            this.tabPanelControl.Controls.SetChildIndex(this.tabDocumentation, 0);
            this.tabPanelControl.Controls.SetChildIndex(this.tabControl, 0);
            this.tabPanelControl.Controls.SetChildIndex(this.tabParentComponents, 0);
            this.tabPanelControl.Controls.SetChildIndex(this.tabComponents, 0);
            this.tabPanelControl.Controls.SetChildIndex(this.tabInterface, 0);
            this.tabPanelControl.Controls.SetChildIndex(this.tabDescription, 0);
            this.tabPanelControl.Controls.SetChildIndex(this.tabIdentification, 0);
            // 
            // tabNetwork
            // 
            this.tabNetwork.ForeColor = System.Drawing.Color.Black;
            this.tabNetwork.Size = new System.Drawing.Size(529, 478);
            // 
            // tabErrors
            // 
            this.tabErrors.ForeColor = System.Drawing.Color.Black;
            this.tabErrors.Size = new System.Drawing.Size(529, 478);
            // 
            // tabLegal
            // 
            this.tabLegal.ForeColor = System.Drawing.Color.Black;
            this.tabLegal.Size = new System.Drawing.Size(529, 478);
            // 
            // helpLabel1
            // 
            this.helpLabel1.HelpMessageKey = "InstrumentDescription.name";
            this.helpLabel1.Location = new System.Drawing.Point(38, 42);
            // 
            // edtName
            // 
            this.edtName.BackColor = System.Drawing.Color.White;
            this.edtName.Location = new System.Drawing.Point(80, 39);
            this.edtName.Size = new System.Drawing.Size(238, 20);
            // 
            // helpLabel2
            // 
            this.helpLabel2.HelpMessageKey = "InstrumentDescription.version";
            this.helpLabel2.Location = new System.Drawing.Point(337, 43);
            // 
            // edtVersion
            // 
            this.edtVersion.BackColor = System.Drawing.Color.White;
            this.edtVersion.Location = new System.Drawing.Point(385, 40);
            this.edtVersion.Size = new System.Drawing.Size(77, 20);
            // 
            // legalDocumentListControl
            // 
            this.legalDocumentListControl.Size = new System.Drawing.Size(529, 478);
            // 
            // tabCharacteristics
            // 
            this.tabCharacteristics.ForeColor = System.Drawing.Color.Black;
            this.tabCharacteristics.Size = new System.Drawing.Size(529, 478);
            // 
            // physicalCharacteristicsControl
            // 
            this.physicalCharacteristicsControl.Size = new System.Drawing.Size(529, 478);
            // 
            // errorListControl
            // 
            this.errorListControl.Size = new System.Drawing.Size(529, 478);
            // 
            // configurationOptionListControl
            // 
            this.configurationOptionListControl.Size = new System.Drawing.Size(529, 478);
            // 
            // calibrationRequirementListControl
            // 
            this.calibrationRequirementListControl.Size = new System.Drawing.Size(515, 446);
            // 
            // factoryDefaultsListControl
            // 
            this.factoryDefaultsListControl.Size = new System.Drawing.Size(529, 478);
            // 
            // networkListControl
            // 
            this.networkListControl.Size = new System.Drawing.Size(529, 478);
            // 
            // parentComponentListControl
            // 
            this.parentComponentListControl.Size = new System.Drawing.Size(529, 478);
            // 
            // documentListControl
            // 
            this.documentListControl.Size = new System.Drawing.Size(529, 478);
            // 
            // cmbInstrumentType
            // 
            this.cmbInstrumentType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbInstrumentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInstrumentType.FormattingEnabled = true;
            this.cmbInstrumentType.Location = new System.Drawing.Point(384, 12);
            this.cmbInstrumentType.Name = "cmbInstrumentType";
            this.cmbInstrumentType.Size = new System.Drawing.Size(275, 21);
            this.cmbInstrumentType.TabIndex = 4;
            // 
            // edtInstrumentUUID
            // 
            this.edtInstrumentUUID.AttributeName = null;
            this.edtInstrumentUUID.BackColor = System.Drawing.Color.White;
            this.edtInstrumentUUID.Location = new System.Drawing.Point(80, 11);
            this.edtInstrumentUUID.Name = "edtInstrumentUUID";
            this.edtInstrumentUUID.Size = new System.Drawing.Size(238, 20);
            this.edtInstrumentUUID.TabIndex = 2;
            this.edtInstrumentUUID.Value = null;
            this.edtInstrumentUUID.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // tabCapabilities
            // 
            this.tabCapabilities.Controls.Add(this.capabilitiesControl1);
            this.tabCapabilities.ForeColor = System.Drawing.Color.Black;
            this.tabCapabilities.Location = new System.Drawing.Point(129, 4);
            this.tabCapabilities.Name = "tabCapabilities";
            this.tabCapabilities.Padding = new System.Windows.Forms.Padding(3);
            this.tabCapabilities.Size = new System.Drawing.Size(529, 478);
            this.tabCapabilities.TabIndex = 0;
            this.tabCapabilities.Text = "Capabilities";
            this.tabCapabilities.UseVisualStyleBackColor = true;
            // 
            // capabilitiesControl1
            // 
            this.capabilitiesControl1.BackColor = System.Drawing.Color.AliceBlue;
            this.capabilitiesControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.capabilitiesControl1.HasErrors = false;
            this.capabilitiesControl1.HelpKeyWord = null;
            this.capabilitiesControl1.LastError = null;
            this.capabilitiesControl1.Location = new System.Drawing.Point(3, 3);
            this.capabilitiesControl1.Name = "capabilitiesControl1";
            this.capabilitiesControl1.SchemaTypeName = null;
            this.capabilitiesControl1.Size = new System.Drawing.Size(523, 472);
            this.capabilitiesControl1.TabIndex = 2;
            this.capabilitiesControl1.TargetNamespace = null;
            // 
            // tabHardware
            // 
            this.tabHardware.Controls.Add(this.hardwareItemDescriptionControl);
            this.tabHardware.Location = new System.Drawing.Point(4, 22);
            this.tabHardware.Name = "tabHardware";
            this.tabHardware.Padding = new System.Windows.Forms.Padding(3);
            this.tabHardware.Size = new System.Drawing.Size(679, 333);
            this.tabHardware.TabIndex = 1;
            this.tabHardware.Text = "Hardware";
            this.tabHardware.UseVisualStyleBackColor = true;
            // 
            // hardwareItemDescriptionControl
            // 
            this.hardwareItemDescriptionControl.BackColor = System.Drawing.Color.AliceBlue;
            this.hardwareItemDescriptionControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hardwareItemDescriptionControl.HasErrors = false;
            this.hardwareItemDescriptionControl.HelpKeyWord = null;
            this.hardwareItemDescriptionControl.LastError = null;
            this.hardwareItemDescriptionControl.Location = new System.Drawing.Point(3, 3);
            this.hardwareItemDescriptionControl.Name = "hardwareItemDescriptionControl";
            this.hardwareItemDescriptionControl.SchemaTypeName = null;
            this.hardwareItemDescriptionControl.Size = new System.Drawing.Size(673, 327);
            this.hardwareItemDescriptionControl.TabIndex = 0;
            this.hardwareItemDescriptionControl.TargetNamespace = null;
            this.hardwareItemDescriptionControl.Load += new System.EventHandler(this.hardwareItemDescriptionControl1_Load);
            // 
            // tabResources
            // 
            this.tabResources.Controls.Add(this.resourceListControl);
            this.tabResources.ForeColor = System.Drawing.Color.Black;
            this.tabResources.Location = new System.Drawing.Point(129, 4);
            this.tabResources.Name = "tabResources";
            this.tabResources.Size = new System.Drawing.Size(529, 478);
            this.tabResources.TabIndex = 3;
            this.tabResources.Text = "Resources";
            this.tabResources.UseVisualStyleBackColor = true;
            // 
            // resourceListControl
            // 
            this.resourceListControl.AllowRowResequencing = false;
            this.resourceListControl.BackColor = System.Drawing.Color.AliceBlue;
            this.resourceListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resourceListControl.FormTitle = null;
            this.resourceListControl.HasErrors = false;
            this.resourceListControl.HelpKeyWord = null;
            this.resourceListControl.LastError = null;
            this.resourceListControl.ListName = null;
            this.resourceListControl.Location = new System.Drawing.Point(0, 0);
            this.resourceListControl.Margin = new System.Windows.Forms.Padding(0);
            this.resourceListControl.Name = "resourceListControl";
            this.resourceListControl.SchemaTypeName = null;
            this.resourceListControl.ShowFind = false;
            this.resourceListControl.Size = new System.Drawing.Size(529, 478);
            this.resourceListControl.TabIndex = 0;
            this.resourceListControl.TargetNamespace = null;
            this.resourceListControl.TooltipTextAddButton = "Press to add a new Resource";
            this.resourceListControl.TooltipTextDeleteButton = "Press to delete the selected Resource";
            this.resourceListControl.TooltipTextEditButton = "Press to edit the selected Resource";
            // 
            // tabSwitching
            // 
            this.tabSwitching.Controls.Add(this.switchingListControl);
            this.tabSwitching.ForeColor = System.Drawing.Color.Black;
            this.tabSwitching.Location = new System.Drawing.Point(129, 4);
            this.tabSwitching.Name = "tabSwitching";
            this.tabSwitching.Size = new System.Drawing.Size(529, 478);
            this.tabSwitching.TabIndex = 4;
            this.tabSwitching.Text = "Switching";
            this.tabSwitching.UseVisualStyleBackColor = true;
            // 
            // switchingListControl
            // 
            this.switchingListControl.AllowRowResequencing = false;
            this.switchingListControl.BackColor = System.Drawing.Color.AliceBlue;
            this.switchingListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.switchingListControl.FormTitle = null;
            this.switchingListControl.HasErrors = false;
            this.switchingListControl.HelpKeyWord = null;
            this.switchingListControl.LastError = null;
            this.switchingListControl.ListName = null;
            this.switchingListControl.Location = new System.Drawing.Point(0, 0);
            this.switchingListControl.Margin = new System.Windows.Forms.Padding(0);
            this.switchingListControl.Name = "switchingListControl";
            this.switchingListControl.SchemaTypeName = null;
            this.switchingListControl.ShowFind = false;
            this.switchingListControl.Size = new System.Drawing.Size(529, 478);
            this.switchingListControl.TabIndex = 0;
            this.switchingListControl.TargetNamespace = null;
            this.switchingListControl.TooltipTextAddButton = "Press to add a new Switch";
            this.switchingListControl.TooltipTextDeleteButton = "Press to delete the selected Switch";
            this.switchingListControl.TooltipTextEditButton = "Press to edit the selected Switch";
            // 
            // mappingListControl1
            // 
            this.mappingListControl1.AllowRowResequencing = false;
            this.mappingListControl1.BackColor = System.Drawing.Color.AliceBlue;
            this.mappingListControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mappingListControl1.FormTitle = null;
            this.mappingListControl1.HardwareItemDescription = null;
            this.mappingListControl1.HasErrors = false;
            this.mappingListControl1.HelpKeyWord = null;
            this.mappingListControl1.LastError = null;
            this.mappingListControl1.ListName = null;
            this.mappingListControl1.Location = new System.Drawing.Point(0, 0);
            this.mappingListControl1.Margin = new System.Windows.Forms.Padding(0);
            this.mappingListControl1.Name = "mappingListControl1";
            this.mappingListControl1.SchemaTypeName = null;
            this.mappingListControl1.ShowFind = false;
            this.mappingListControl1.Size = new System.Drawing.Size(525, 468);
            this.mappingListControl1.TabIndex = 0;
            this.mappingListControl1.TargetNamespace = null;
            this.mappingListControl1.TooltipTextAddButton = "Press to add a new Mapping";
            this.mappingListControl1.TooltipTextDeleteButton = "Press to delete the selected Mapping";
            this.mappingListControl1.TooltipTextEditButton = "Press to edit the selected Mapping";
            // 
            // tabSpecifications
            // 
            this.tabSpecifications.Controls.Add(this.specificationsControl);
            this.tabSpecifications.ForeColor = System.Drawing.Color.Black;
            this.tabSpecifications.Location = new System.Drawing.Point(129, 4);
            this.tabSpecifications.Name = "tabSpecifications";
            this.tabSpecifications.Size = new System.Drawing.Size(529, 478);
            this.tabSpecifications.TabIndex = 2;
            this.tabSpecifications.Text = "Specifications";
            this.tabSpecifications.UseVisualStyleBackColor = true;
            // 
            // specificationsControl
            // 
            this.specificationsControl.BackColor = System.Drawing.Color.Transparent;
            this.specificationsControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.specificationsControl.Location = new System.Drawing.Point(0, 0);
            this.specificationsControl.Name = "specificationsControl";
            this.specificationsControl.Size = new System.Drawing.Size(529, 478);
            this.specificationsControl.TabIndex = 1;
            // 
            // tabPowerOnDefaults
            // 
            this.tabPowerOnDefaults.Controls.Add(this.powerOnDefaultsListControl);
            this.tabPowerOnDefaults.ForeColor = System.Drawing.Color.Black;
            this.tabPowerOnDefaults.Location = new System.Drawing.Point(129, 4);
            this.tabPowerOnDefaults.Name = "tabPowerOnDefaults";
            this.tabPowerOnDefaults.Size = new System.Drawing.Size(529, 478);
            this.tabPowerOnDefaults.TabIndex = 6;
            this.tabPowerOnDefaults.Text = "Power On Defaults";
            this.tabPowerOnDefaults.UseVisualStyleBackColor = true;
            // 
            // powerOnDefaultsListControl
            // 
            this.powerOnDefaultsListControl.AllowRowResequencing = false;
            this.powerOnDefaultsListControl.BackColor = System.Drawing.Color.AliceBlue;
            this.powerOnDefaultsListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.powerOnDefaultsListControl.FormTitle = null;
            this.powerOnDefaultsListControl.HasErrors = false;
            this.powerOnDefaultsListControl.HelpKeyWord = null;
            this.powerOnDefaultsListControl.LastError = null;
            this.powerOnDefaultsListControl.ListName = "Power on Default";
            this.powerOnDefaultsListControl.Location = new System.Drawing.Point(0, 0);
            this.powerOnDefaultsListControl.Margin = new System.Windows.Forms.Padding(0);
            this.powerOnDefaultsListControl.Name = "powerOnDefaultsListControl";
            this.powerOnDefaultsListControl.SchemaTypeName = null;
            this.powerOnDefaultsListControl.ShowFind = false;
            this.powerOnDefaultsListControl.Size = new System.Drawing.Size(529, 478);
            this.powerOnDefaultsListControl.TabIndex = 0;
            this.powerOnDefaultsListControl.TargetNamespace = null;
            this.powerOnDefaultsListControl.TooltipTextAddButton = "Press to add a new Power on Default";
            this.powerOnDefaultsListControl.TooltipTextDeleteButton = "Press to delete the selected Power on Default";
            this.powerOnDefaultsListControl.TooltipTextEditButton = "Press to edit the selected Power on Default";
            // 
            // tabBusses
            // 
            this.tabBusses.Controls.Add(this.busListControl);
            this.tabBusses.ForeColor = System.Drawing.Color.Black;
            this.tabBusses.Location = new System.Drawing.Point(129, 4);
            this.tabBusses.Name = "tabBusses";
            this.tabBusses.Size = new System.Drawing.Size(529, 478);
            this.tabBusses.TabIndex = 5;
            this.tabBusses.Text = "Buses";
            this.tabBusses.UseVisualStyleBackColor = true;
            // 
            // busListControl
            // 
            this.busListControl.AllowRowResequencing = false;
            this.busListControl.BackColor = System.Drawing.Color.AliceBlue;
            this.busListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.busListControl.FormTitle = null;
            this.busListControl.HasErrors = false;
            this.busListControl.HelpKeyWord = null;
            this.busListControl.LastError = null;
            this.busListControl.ListName = "Bus";
            this.busListControl.Location = new System.Drawing.Point(0, 0);
            this.busListControl.Margin = new System.Windows.Forms.Padding(0);
            this.busListControl.Name = "busListControl";
            this.busListControl.SchemaTypeName = null;
            this.busListControl.ShowFind = false;
            this.busListControl.Size = new System.Drawing.Size(529, 478);
            this.busListControl.TabIndex = 0;
            this.busListControl.TargetNamespace = null;
            this.busListControl.TooltipTextAddButton = "Press to add a new Bus";
            this.busListControl.TooltipTextDeleteButton = "Press to delete the selected Bus";
            this.busListControl.TooltipTextEditButton = "Press to edit the selected Bus";
            // 
            // xsdUUIDSchemaValidator
            // 
            this.xsdUUIDSchemaValidator.ControlToValidate = this.edtInstrumentUUID;
            this.xsdUUIDSchemaValidator.ErrorMessage = null;
            this.xsdUUIDSchemaValidator.ErrorProvider = this.errorProvider1;
            this.xsdUUIDSchemaValidator.Icon = null;
            this.xsdUUIDSchemaValidator.InitialValue = null;
            this.xsdUUIDSchemaValidator.IsEnabled = true;
            this.xsdUUIDSchemaValidator.XSDAttributeName = "uuid";
            this.xsdUUIDSchemaValidator.XSDTargetNamespace = "urn:IEEE-1671.2:2012:InstrumentDescription";
            this.xsdUUIDSchemaValidator.XSDTypeName = "InstrumentDescription";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnAddGUID
            // 
            this.btnAddGUID.Active = true;
            this.btnAddGUID.BorderColor = System.Drawing.Color.Gray;
            this.btnAddGUID.ButtonStyle = ATMLCommonLibrary.controls.awb.AWBButton.ButtonStyles.Rectangle;
            this.btnAddGUID.FlatAppearance.BorderSize = 0;
            this.btnAddGUID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddGUID.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddGUID.GradientStyle = ATMLCommonLibrary.controls.awb.AWBButton.GradientStyles.Vertical;
            this.btnAddGUID.HoverBorderColor = System.Drawing.Color.LightSteelBlue;
            this.btnAddGUID.HoverColorA = System.Drawing.Color.SteelBlue;
            this.btnAddGUID.HoverColorB = System.Drawing.Color.SteelBlue;
            this.btnAddGUID.HoverTextColor = System.Drawing.Color.White;
            this.btnAddGUID.Image = ((System.Drawing.Image)(resources.GetObject("btnAddGUID.Image")));
            this.btnAddGUID.Location = new System.Drawing.Point(8, 10);
            this.btnAddGUID.Name = "btnAddGUID";
            this.btnAddGUID.NormalBorderColor = System.Drawing.Color.SteelBlue;
            this.btnAddGUID.NormalColorA = System.Drawing.Color.LightSteelBlue;
            this.btnAddGUID.NormalColorB = System.Drawing.Color.LightSteelBlue;
            this.btnAddGUID.Size = new System.Drawing.Size(24, 22);
            this.btnAddGUID.SmoothingQuality = ATMLCommonLibrary.controls.awb.AWBButton.SmoothingQualities.AntiAlias;
            this.btnAddGUID.TabIndex = 0;
            this.btnAddGUID.ToolTipText = "Press to generate a new UUID";
            this.btnAddGUID.UseVisualStyleBackColor = true;
            this.btnAddGUID.Click += new System.EventHandler(this.btnAddGUID_Click);
            // 
            // lblInstrumentDescriptionUUID
            // 
            this.lblInstrumentDescriptionUUID.HelpMessageKey = "InstrumentDescription.uuid";
            this.lblInstrumentDescriptionUUID.Location = new System.Drawing.Point(34, 14);
            this.lblInstrumentDescriptionUUID.Name = "lblInstrumentDescriptionUUID";
            this.lblInstrumentDescriptionUUID.RequiredField = true;
            this.lblInstrumentDescriptionUUID.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstrumentDescriptionUUID.Size = new System.Drawing.Size(40, 16);
            this.lblInstrumentDescriptionUUID.TabIndex = 1;
            this.lblInstrumentDescriptionUUID.Text = "UUID";
            // 
            // lblInstrumentDescriptionType
            // 
            this.lblInstrumentDescriptionType.HelpMessageKey = "InstrumentDescription.type";
            this.lblInstrumentDescriptionType.Location = new System.Drawing.Point(343, 16);
            this.lblInstrumentDescriptionType.Name = "lblInstrumentDescriptionType";
            this.lblInstrumentDescriptionType.RequiredField = true;
            this.lblInstrumentDescriptionType.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstrumentDescriptionType.Size = new System.Drawing.Size(36, 16);
            this.lblInstrumentDescriptionType.TabIndex = 3;
            this.lblInstrumentDescriptionType.Text = "Type";
            // 
            // tabPaths
            // 
            this.tabPaths.Controls.Add(this.pathListControl);
            this.tabPaths.ForeColor = System.Drawing.Color.Black;
            this.tabPaths.Location = new System.Drawing.Point(129, 4);
            this.tabPaths.Name = "tabPaths";
            this.tabPaths.Size = new System.Drawing.Size(529, 478);
            this.tabPaths.TabIndex = 15;
            this.tabPaths.Text = "Paths";
            this.tabPaths.UseVisualStyleBackColor = true;
            // 
            // pathListControl
            // 
            this.pathListControl.AllowRowResequencing = false;
            this.pathListControl.BackColor = System.Drawing.Color.AliceBlue;
            this.pathListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pathListControl.FormTitle = null;
            this.pathListControl.HardwareItemDescription = null;
            this.pathListControl.HasErrors = false;
            this.pathListControl.HelpKeyWord = null;
            this.pathListControl.LastError = null;
            this.pathListControl.ListName = null;
            this.pathListControl.Location = new System.Drawing.Point(0, 0);
            this.pathListControl.Margin = new System.Windows.Forms.Padding(0);
            this.pathListControl.Name = "pathListControl";
            this.pathListControl.SchemaTypeName = null;
            this.pathListControl.ShowFind = false;
            this.pathListControl.Size = new System.Drawing.Size(529, 478);
            this.pathListControl.TabIndex = 0;
            this.pathListControl.TargetNamespace = null;
            this.pathListControl.TooltipTextAddButton = "Press to add a new Path";
            this.pathListControl.TooltipTextDeleteButton = "Press to delete the selected Path";
            this.pathListControl.TooltipTextEditButton = "Press to edit the selected Path";
            // 
            // securityClassificationControl
            // 
            this.securityClassificationControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.securityClassificationControl.BackColor = System.Drawing.Color.Transparent;
            this.securityClassificationControl.Classified = false;
            this.securityClassificationControl.HasErrors = false;
            this.securityClassificationControl.HelpKeyWord = null;
            this.securityClassificationControl.LastError = null;
            this.securityClassificationControl.Location = new System.Drawing.Point(472, 39);
            this.securityClassificationControl.Name = "securityClassificationControl";
            this.securityClassificationControl.SchemaTypeName = null;
            this.securityClassificationControl.SecurityClassification = null;
            this.securityClassificationControl.Size = new System.Drawing.Size(187, 21);
            this.securityClassificationControl.TabIndex = 6;
            this.securityClassificationControl.TargetNamespace = null;
            // 
            // InstrumentControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Controls.Add(this.securityClassificationControl);
            this.Controls.Add(this.lblInstrumentDescriptionType);
            this.Controls.Add(this.lblInstrumentDescriptionUUID);
            this.Controls.Add(this.btnAddGUID);
            this.Controls.Add(this.cmbInstrumentType);
            this.Controls.Add(this.edtInstrumentUUID);
            this.Name = "InstrumentControl";
            this.SchemaTypeName = "InstrumentDescription";
            this.Size = new System.Drawing.Size(685, 572);
            this.TargetNamespace = "urn:IEEE-1671.2:2012:InstrumentDescription";
            this.Validating += new System.ComponentModel.CancelEventHandler(this.InstrumentControl_Validating);
            this.Controls.SetChildIndex(this.edtInstrumentUUID, 0);
            this.Controls.SetChildIndex(this.cmbInstrumentType, 0);
            this.Controls.SetChildIndex(this.btnAddGUID, 0);
            this.Controls.SetChildIndex(this.lblInstrumentDescriptionUUID, 0);
            this.Controls.SetChildIndex(this.lblInstrumentDescriptionType, 0);
            this.Controls.SetChildIndex(this.tabPanelControl, 0);
            this.Controls.SetChildIndex(this.helpLabel1, 0);
            this.Controls.SetChildIndex(this.edtName, 0);
            this.Controls.SetChildIndex(this.helpLabel2, 0);
            this.Controls.SetChildIndex(this.edtVersion, 0);
            this.Controls.SetChildIndex(this.securityClassificationControl, 0);
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
            this.tabDocumentation.ResumeLayout(false);
            this.tabConfiguration.ResumeLayout(false);
            this.tabDefaults.ResumeLayout(false);
            this.tabRequirements.ResumeLayout(false);
            this.tabPanelControl.ResumeLayout(false);
            this.tabNetwork.ResumeLayout(false);
            this.tabErrors.ResumeLayout(false);
            this.tabLegal.ResumeLayout(false);
            this.tabCharacteristics.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.tabCapabilities.ResumeLayout(false);
            this.tabHardware.ResumeLayout(false);
            this.tabResources.ResumeLayout(false);
            this.tabSwitching.ResumeLayout(false);
            this.tabSpecifications.ResumeLayout(false);
            this.tabPowerOnDefaults.ResumeLayout(false);
            this.tabBusses.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.tabPaths.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbInstrumentType;
        private awb.AWBTextBox edtInstrumentUUID;
        private System.Windows.Forms.TabPage tabCapabilities;
        private System.Windows.Forms.TabPage tabHardware;
        private HardwareItemDescriptionControl hardwareItemDescriptionControl;
        private System.Windows.Forms.TabPage tabResources;
        private System.Windows.Forms.TabPage tabSpecifications;
        private SpecificationsControl specificationsControl;
        private System.Windows.Forms.TabPage tabPowerOnDefaults;
        private System.Windows.Forms.TabPage tabSwitching;
        private System.Windows.Forms.TabPage tabBusses;
        private ResourceListControl resourceListControl;
        private lists.SwitchingListControl switchingListControl;
        private MappingListControl mappingListControl1;
        private validators.XSDSchemaValidator xsdUUIDSchemaValidator;
        private awb.AWBButton btnAddGUID;
        private HelpLabel lblInstrumentDescriptionType;
        private HelpLabel lblInstrumentDescriptionUUID;
        private power.PowerOnDefaultListControl powerOnDefaultsListControl;
        private bus.BusListControl busListControl;
        private CapabilitiesControl capabilitiesControl1;
        protected System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TabPage tabPaths;
        private path.PathListControl pathListControl;
        private WindowsFormsApplication10.SecurityClassificationControl securityClassificationControl;

    }
}
