/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using ATMLCommonLibrary.controls.controller;
using ATMLCommonLibrary.controls.specification;

namespace ATMLCommonLibrary.controls.equipment
{
    partial class TestEquipmentControl
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
            this.tabFacilities = new System.Windows.Forms.TabPage();
            this.facilitiesRequirementsControl1 = new ATMLCommonLibrary.controls.hardware.FacilitiesRequirementsControl();
            this.tabControllers = new System.Windows.Forms.TabPage();
            this.controllerListControl1 = new ATMLCommonLibrary.controls.controller.ControllerListControl();
            this.tabSoftware = new System.Windows.Forms.TabPage();
            this.tabPaths = new System.Windows.Forms.TabPage();
            this.pathListControl1 = new ATMLCommonLibrary.controls.path.PathListControl();
            this.tabSpecifications = new System.Windows.Forms.TabPage();
            this.specificationsControl1 = new ATMLCommonLibrary.controls.specification.SpecificationsControl();
            this.tabResources = new System.Windows.Forms.TabPage();
            this.resourceListControl1 = new ATMLCommonLibrary.controls.resource.ResourceListControl();
            this.tabSwitching = new System.Windows.Forms.TabPage();
            this.switchingListControl1 = new ATMLCommonLibrary.controls.lists.SwitchingListControl();
            this.tabCapabilities = new System.Windows.Forms.TabPage();
            this.capabilitiesControl1 = new ATMLCommonLibrary.controls.capability.CapabilitiesControl();
            this.tabTerminalBlocks = new System.Windows.Forms.TabPage();
            this.terminalBlockListControl1 = new ATMLCommonLibrary.controls.equipment.TerminalBlockListControl();
            this.softwareItemListControl = new ATMLCommonLibrary.controls.lists.ItemDescriptionListControl();
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
            this.tabFacilities.SuspendLayout();
            this.tabControllers.SuspendLayout();
            this.tabSoftware.SuspendLayout();
            this.tabPaths.SuspendLayout();
            this.tabSpecifications.SuspendLayout();
            this.tabResources.SuspendLayout();
            this.tabSwitching.SuspendLayout();
            this.tabCapabilities.SuspendLayout();
            this.tabTerminalBlocks.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabDescription
            // 
            this.tabDescription.Location = new System.Drawing.Point(254, 4);
            this.tabDescription.Size = new System.Drawing.Size(565, 317);
            // 
            // edtDescription
            // 
            this.edtDescription.Size = new System.Drawing.Size(565, 317);
            // 
            // RequirementsTabControl
            // 
            this.RequirementsTabControl.Size = new System.Drawing.Size(565, 317);
            // 
            // tabCalibration
            // 
            this.tabCalibration.Size = new System.Drawing.Size(557, 291);
            // 
            // tabIdentification
            // 
            this.tabIdentification.Location = new System.Drawing.Point(254, 4);
            this.tabIdentification.Size = new System.Drawing.Size(565, 317);
            // 
            // panelIdentification
            // 
            this.panelIdentification.Size = new System.Drawing.Size(565, 317);
            // 
            // identificationControl
            // 
            this.identificationControl.Size = new System.Drawing.Size(565, 317);
            // 
            // tabInterface
            // 
            this.tabInterface.Location = new System.Drawing.Point(254, 4);
            this.tabInterface.Size = new System.Drawing.Size(565, 317);
            // 
            // interfaceListControl
            // 
            this.interfaceListControl.Size = new System.Drawing.Size(565, 317);
            // 
            // tabComponents
            // 
            this.tabComponents.Location = new System.Drawing.Point(254, 4);
            this.tabComponents.Size = new System.Drawing.Size(565, 317);
            // 
            // componentListControl
            // 
            this.componentListControl.Size = new System.Drawing.Size(565, 317);
            // 
            // tabParentComponents
            // 
            this.tabParentComponents.Location = new System.Drawing.Point(254, 4);
            this.tabParentComponents.Size = new System.Drawing.Size(565, 317);
            // 
            // tabControl
            // 
            this.tabControl.Location = new System.Drawing.Point(254, 4);
            this.tabControl.Size = new System.Drawing.Size(565, 317);
            // 
            // tabDocumentation
            // 
            this.tabDocumentation.Location = new System.Drawing.Point(254, 4);
            this.tabDocumentation.Size = new System.Drawing.Size(565, 317);
            // 
            // tabConfiguration
            // 
            this.tabConfiguration.Location = new System.Drawing.Point(254, 4);
            this.tabConfiguration.Size = new System.Drawing.Size(565, 317);
            // 
            // tabDefaults
            // 
            this.tabDefaults.Location = new System.Drawing.Point(254, 4);
            this.tabDefaults.Size = new System.Drawing.Size(565, 317);
            // 
            // tabRequirements
            // 
            this.tabRequirements.Location = new System.Drawing.Point(254, 4);
            this.tabRequirements.Size = new System.Drawing.Size(565, 317);
            // 
            // tabPanelControl
            // 
            this.tabPanelControl.Controls.Add(this.tabResources);
            this.tabPanelControl.Controls.Add(this.tabCapabilities);
            this.tabPanelControl.Controls.Add(this.tabSwitching);
            this.tabPanelControl.Controls.Add(this.tabTerminalBlocks);
            this.tabPanelControl.Controls.Add(this.tabFacilities);
            this.tabPanelControl.Controls.Add(this.tabControllers);
            this.tabPanelControl.Controls.Add(this.tabSoftware);
            this.tabPanelControl.Controls.Add(this.tabPaths);
            this.tabPanelControl.Controls.Add(this.tabSpecifications);
            this.tabPanelControl.Size = new System.Drawing.Size(823, 325);
            this.tabPanelControl.Controls.SetChildIndex(this.tabSpecifications, 0);
            this.tabPanelControl.Controls.SetChildIndex(this.tabPaths, 0);
            this.tabPanelControl.Controls.SetChildIndex(this.tabSoftware, 0);
            this.tabPanelControl.Controls.SetChildIndex(this.tabControllers, 0);
            this.tabPanelControl.Controls.SetChildIndex(this.tabFacilities, 0);
            this.tabPanelControl.Controls.SetChildIndex(this.tabTerminalBlocks, 0);
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
            this.tabPanelControl.Controls.SetChildIndex(this.tabSwitching, 0);
            this.tabPanelControl.Controls.SetChildIndex(this.tabCapabilities, 0);
            this.tabPanelControl.Controls.SetChildIndex(this.tabResources, 0);
            this.tabPanelControl.Controls.SetChildIndex(this.tabInterface, 0);
            this.tabPanelControl.Controls.SetChildIndex(this.tabDescription, 0);
            this.tabPanelControl.Controls.SetChildIndex(this.tabIdentification, 0);
            // 
            // tabNetwork
            // 
            this.tabNetwork.Location = new System.Drawing.Point(254, 4);
            this.tabNetwork.Size = new System.Drawing.Size(565, 317);
            // 
            // tabErrors
            // 
            this.tabErrors.Location = new System.Drawing.Point(254, 4);
            this.tabErrors.Size = new System.Drawing.Size(565, 317);
            // 
            // tabLegal
            // 
            this.tabLegal.Location = new System.Drawing.Point(254, 4);
            this.tabLegal.Size = new System.Drawing.Size(565, 317);
            // 
            // edtName
            // 
            this.edtName.BackColor = System.Drawing.Color.White;
            // 
            // edtVersion
            // 
            this.edtVersion.BackColor = System.Drawing.Color.White;
            // 
            // legalDocumentListControl
            // 
            this.legalDocumentListControl.Size = new System.Drawing.Size(565, 317);
            // 
            // tabCharacteristics
            // 
            this.tabCharacteristics.Location = new System.Drawing.Point(254, 4);
            this.tabCharacteristics.Size = new System.Drawing.Size(565, 317);
            // 
            // physicalCharacteristicsControl
            // 
            this.physicalCharacteristicsControl.Size = new System.Drawing.Size(565, 317);
            // 
            // errorListControl
            // 
            this.errorListControl.Size = new System.Drawing.Size(565, 317);
            // 
            // configurationOptionListControl
            // 
            this.configurationOptionListControl.Size = new System.Drawing.Size(565, 317);
            // 
            // calibrationRequirementListControl
            // 
            this.calibrationRequirementListControl.Size = new System.Drawing.Size(551, 285);
            // 
            // factoryDefaultsListControl
            // 
            this.factoryDefaultsListControl.Size = new System.Drawing.Size(565, 317);
            // 
            // networkListControl
            // 
            this.networkListControl.Size = new System.Drawing.Size(565, 317);
            // 
            // parentComponentListControl
            // 
            this.parentComponentListControl.Size = new System.Drawing.Size(565, 317);
            // 
            // documentListControl
            // 
            this.documentListControl.Size = new System.Drawing.Size(565, 317);
            // 
            // tabFacilities
            // 
            this.tabFacilities.Controls.Add(this.facilitiesRequirementsControl1);
            this.tabFacilities.Location = new System.Drawing.Point(254, 4);
            this.tabFacilities.Name = "tabFacilities";
            this.tabFacilities.Size = new System.Drawing.Size(565, 317);
            this.tabFacilities.TabIndex = 15;
            this.tabFacilities.Text = "Facilities";
            this.tabFacilities.UseVisualStyleBackColor = true;
            // 
            // facilitiesRequirementsControl1
            // 
            this.facilitiesRequirementsControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.facilitiesRequirementsControl1.Location = new System.Drawing.Point(0, 0);
            this.facilitiesRequirementsControl1.Name = "facilitiesRequirementsControl1";
            this.facilitiesRequirementsControl1.SchemaTypeName = null;
            this.facilitiesRequirementsControl1.Size = new System.Drawing.Size(565, 317);
            this.facilitiesRequirementsControl1.TabIndex = 0;
            this.facilitiesRequirementsControl1.TargetNamespace = null;
            // 
            // tabControllers
            // 
            this.tabControllers.Controls.Add(this.controllerListControl1);
            this.tabControllers.Location = new System.Drawing.Point(254, 4);
            this.tabControllers.Name = "tabControllers";
            this.tabControllers.Size = new System.Drawing.Size(565, 317);
            this.tabControllers.TabIndex = 16;
            this.tabControllers.Text = "Controllers";
            this.tabControllers.UseVisualStyleBackColor = true;
            // 
            // controllerListControl1
            // 
            this.controllerListControl1.AllowRowResequencing = false;
            this.controllerListControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controllerListControl1.FormTitle = null;
            this.controllerListControl1.ListName = null;
            this.controllerListControl1.Location = new System.Drawing.Point(0, 0);
            this.controllerListControl1.Margin = new System.Windows.Forms.Padding(0);
            this.controllerListControl1.Name = "controllerListControl1";
            this.controllerListControl1.SchemaTypeName = null;
            this.controllerListControl1.ShowFind = false;
            this.controllerListControl1.Size = new System.Drawing.Size(565, 317);
            this.controllerListControl1.TabIndex = 0;
            this.controllerListControl1.TargetNamespace = null;
            this.controllerListControl1.TooltipTextAddButton = "Press to add a new ";
            this.controllerListControl1.TooltipTextDeleteButton = "Press to delete the selected ";
            this.controllerListControl1.TooltipTextEditButton = "Press to edit the selected ";
            // 
            // tabSoftware
            // 
            this.tabSoftware.Controls.Add(this.softwareItemListControl);
            this.tabSoftware.Location = new System.Drawing.Point(254, 4);
            this.tabSoftware.Name = "tabSoftware";
            this.tabSoftware.Size = new System.Drawing.Size(565, 317);
            this.tabSoftware.TabIndex = 17;
            this.tabSoftware.Text = "Software";
            this.tabSoftware.UseVisualStyleBackColor = true;
            // 
            // tabPaths
            // 
            this.tabPaths.Controls.Add(this.pathListControl1);
            this.tabPaths.Location = new System.Drawing.Point(254, 4);
            this.tabPaths.Name = "tabPaths";
            this.tabPaths.Size = new System.Drawing.Size(565, 317);
            this.tabPaths.TabIndex = 18;
            this.tabPaths.Text = "Paths";
            this.tabPaths.UseVisualStyleBackColor = true;
            // 
            // pathListControl1
            // 
            this.pathListControl1.AllowRowResequencing = false;
            this.pathListControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pathListControl1.FormTitle = null;
            this.pathListControl1.ListName = null;
            this.pathListControl1.Location = new System.Drawing.Point(0, 0);
            this.pathListControl1.Margin = new System.Windows.Forms.Padding(0);
            this.pathListControl1.Name = "pathListControl1";
            this.pathListControl1.SchemaTypeName = null;
            this.pathListControl1.ShowFind = false;
            this.pathListControl1.Size = new System.Drawing.Size(565, 317);
            this.pathListControl1.TabIndex = 0;
            this.pathListControl1.TargetNamespace = null;
            this.pathListControl1.TooltipTextAddButton = "Press to add a new ";
            this.pathListControl1.TooltipTextDeleteButton = "Press to delete the selected ";
            this.pathListControl1.TooltipTextEditButton = "Press to edit the selected ";
            // 
            // tabSpecifications
            // 
            this.tabSpecifications.Controls.Add(this.specificationsControl1);
            this.tabSpecifications.Location = new System.Drawing.Point(254, 4);
            this.tabSpecifications.Name = "tabSpecifications";
            this.tabSpecifications.Size = new System.Drawing.Size(565, 317);
            this.tabSpecifications.TabIndex = 19;
            this.tabSpecifications.Text = "Specifications";
            this.tabSpecifications.UseVisualStyleBackColor = true;
            // 
            // specificationsControl1
            // 
            this.specificationsControl1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.specificationsControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.specificationsControl1.Location = new System.Drawing.Point(0, 0);
            this.specificationsControl1.Name = "specificationsControl1";
            this.specificationsControl1.Size = new System.Drawing.Size(565, 317);
            this.specificationsControl1.TabIndex = 0;
            // 
            // tabResources
            // 
            this.tabResources.Controls.Add(this.resourceListControl1);
            this.tabResources.Location = new System.Drawing.Point(254, 4);
            this.tabResources.Name = "tabResources";
            this.tabResources.Size = new System.Drawing.Size(565, 317);
            this.tabResources.TabIndex = 20;
            this.tabResources.Text = "Resources";
            this.tabResources.UseVisualStyleBackColor = true;
            // 
            // resourceListControl1
            // 
            this.resourceListControl1.AllowRowResequencing = false;
            this.resourceListControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resourceListControl1.FormTitle = null;
            this.resourceListControl1.ListName = null;
            this.resourceListControl1.Location = new System.Drawing.Point(0, 0);
            this.resourceListControl1.Margin = new System.Windows.Forms.Padding(0);
            this.resourceListControl1.Name = "resourceListControl1";
            this.resourceListControl1.SchemaTypeName = null;
            this.resourceListControl1.ShowFind = false;
            this.resourceListControl1.Size = new System.Drawing.Size(565, 317);
            this.resourceListControl1.TabIndex = 0;
            this.resourceListControl1.TargetNamespace = null;
            this.resourceListControl1.TooltipTextAddButton = "Press to add a new ";
            this.resourceListControl1.TooltipTextDeleteButton = "Press to delete the selected ";
            this.resourceListControl1.TooltipTextEditButton = "Press to edit the selected ";
            // 
            // tabSwitching
            // 
            this.tabSwitching.Controls.Add(this.switchingListControl1);
            this.tabSwitching.Location = new System.Drawing.Point(254, 4);
            this.tabSwitching.Name = "tabSwitching";
            this.tabSwitching.Size = new System.Drawing.Size(565, 317);
            this.tabSwitching.TabIndex = 21;
            this.tabSwitching.Text = "Switching";
            this.tabSwitching.UseVisualStyleBackColor = true;
            // 
            // switchingListControl1
            // 
            this.switchingListControl1.AllowRowResequencing = false;
            this.switchingListControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.switchingListControl1.FormTitle = null;
            this.switchingListControl1.ListName = null;
            this.switchingListControl1.Location = new System.Drawing.Point(0, 0);
            this.switchingListControl1.Margin = new System.Windows.Forms.Padding(0);
            this.switchingListControl1.Name = "switchingListControl1";
            this.switchingListControl1.SchemaTypeName = null;
            this.switchingListControl1.ShowFind = false;
            this.switchingListControl1.Size = new System.Drawing.Size(565, 317);
            this.switchingListControl1.TabIndex = 0;
            this.switchingListControl1.TargetNamespace = null;
            this.switchingListControl1.TooltipTextAddButton = "Press to add a new ";
            this.switchingListControl1.TooltipTextDeleteButton = "Press to delete the selected ";
            this.switchingListControl1.TooltipTextEditButton = "Press to edit the selected ";
            // 
            // tabCapabilities
            // 
            this.tabCapabilities.Controls.Add(this.capabilitiesControl1);
            this.tabCapabilities.Location = new System.Drawing.Point(254, 4);
            this.tabCapabilities.Name = "tabCapabilities";
            this.tabCapabilities.Size = new System.Drawing.Size(565, 317);
            this.tabCapabilities.TabIndex = 22;
            this.tabCapabilities.Text = "Capabilities";
            this.tabCapabilities.UseVisualStyleBackColor = true;
            // 
            // capabilitiesControl1
            // 
            this.capabilitiesControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.capabilitiesControl1.Location = new System.Drawing.Point(0, 0);
            this.capabilitiesControl1.Name = "capabilitiesControl1";
            this.capabilitiesControl1.SchemaTypeName = null;
            this.capabilitiesControl1.Size = new System.Drawing.Size(565, 317);
            this.capabilitiesControl1.TabIndex = 0;
            this.capabilitiesControl1.TargetNamespace = null;
            // 
            // tabTerminalBlocks
            // 
            this.tabTerminalBlocks.Controls.Add(this.terminalBlockListControl1);
            this.tabTerminalBlocks.Location = new System.Drawing.Point(254, 4);
            this.tabTerminalBlocks.Name = "tabTerminalBlocks";
            this.tabTerminalBlocks.Size = new System.Drawing.Size(565, 317);
            this.tabTerminalBlocks.TabIndex = 23;
            this.tabTerminalBlocks.Text = "Terminal Blocks";
            this.tabTerminalBlocks.UseVisualStyleBackColor = true;
            // 
            // terminalBlockListControl1
            // 
            this.terminalBlockListControl1.AllowRowResequencing = false;
            this.terminalBlockListControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.terminalBlockListControl1.FormTitle = null;
            this.terminalBlockListControl1.ListName = null;
            this.terminalBlockListControl1.Location = new System.Drawing.Point(0, 0);
            this.terminalBlockListControl1.Margin = new System.Windows.Forms.Padding(0);
            this.terminalBlockListControl1.Name = "terminalBlockListControl1";
            this.terminalBlockListControl1.SchemaTypeName = null;
            this.terminalBlockListControl1.ShowFind = false;
            this.terminalBlockListControl1.Size = new System.Drawing.Size(565, 317);
            this.terminalBlockListControl1.TabIndex = 0;
            this.terminalBlockListControl1.TargetNamespace = null;
            this.terminalBlockListControl1.TooltipTextAddButton = "Press to add a new ";
            this.terminalBlockListControl1.TooltipTextDeleteButton = "Press to delete the selected ";
            this.terminalBlockListControl1.TooltipTextEditButton = "Press to edit the selected ";
            // 
            // softwareItemListControl
            // 
            this.softwareItemListControl.AllowRowResequencing = false;
            this.softwareItemListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.softwareItemListControl.FormTitle = null;
            this.softwareItemListControl.ItemsDescriptions = null;
            this.softwareItemListControl.ListName = null;
            this.softwareItemListControl.Location = new System.Drawing.Point(0, 0);
            this.softwareItemListControl.Margin = new System.Windows.Forms.Padding(0);
            this.softwareItemListControl.Name = "softwareItemListControl";
            this.softwareItemListControl.SchemaTypeName = null;
            this.softwareItemListControl.ShowFind = false;
            this.softwareItemListControl.Size = new System.Drawing.Size(565, 317);
            this.softwareItemListControl.TabIndex = 0;
            this.softwareItemListControl.TargetNamespace = null;
            this.softwareItemListControl.TooltipTextAddButton = "Press to add a new Item";
            this.softwareItemListControl.TooltipTextDeleteButton = "Press to delete the selected Item";
            this.softwareItemListControl.TooltipTextEditButton = "Press to edit the selected Item";
            // 
            // TestEquipmentControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "TestEquipmentControl";
            this.Size = new System.Drawing.Size(823, 357);
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
            this.tabFacilities.ResumeLayout(false);
            this.tabControllers.ResumeLayout(false);
            this.tabSoftware.ResumeLayout(false);
            this.tabPaths.ResumeLayout(false);
            this.tabSpecifications.ResumeLayout(false);
            this.tabResources.ResumeLayout(false);
            this.tabSwitching.ResumeLayout(false);
            this.tabCapabilities.ResumeLayout(false);
            this.tabTerminalBlocks.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.TabPage tabFacilities;
        protected System.Windows.Forms.TabPage tabControllers;
        protected System.Windows.Forms.TabPage tabSoftware;
        protected System.Windows.Forms.TabPage tabPaths;
        protected System.Windows.Forms.TabPage tabSpecifications;
        protected System.Windows.Forms.TabPage tabResources;
        protected System.Windows.Forms.TabPage tabSwitching;
        protected System.Windows.Forms.TabPage tabCapabilities;
        protected System.Windows.Forms.TabPage tabTerminalBlocks;
        protected hardware.FacilitiesRequirementsControl facilitiesRequirementsControl1;
        protected SpecificationsControl specificationsControl1;
        protected resource.ResourceListControl resourceListControl1;
        protected lists.SwitchingListControl switchingListControl1;
        protected TerminalBlockListControl terminalBlockListControl1;
        protected ATMLCommonLibrary.controls.capability.CapabilitiesControl capabilitiesControl1;
        protected path.PathListControl pathListControl1;
        protected ControllerListControl controllerListControl1;
        protected lists.ItemDescriptionListControl softwareItemListControl;
    }
}
