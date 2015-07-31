/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System.ComponentModel;
using System.Linq;
using ATMLModelLibrary.model.common;
using ATMLModelLibrary.model.equipment;
using ATMLSchemaLibrary.managers;
using HardwareItemDescriptionControl = ATMLCommonLibrary.controls.hardware.HardwareItemDescriptionControl;

namespace ATMLCommonLibrary.controls.equipment
{
    public partial class TestEquipmentControl : HardwareItemDescriptionControl
    {
        public TestEquipmentControl()
        {
            InitializeComponent();
            Validating += new CancelEventHandler(TestEquipmentControl_Validating);
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TestEquipment TestEquipment
        {
            set
            {
                _hardwareItemDescription = value;
                DataToControls();
                pathListControl1.HardwareItemDescription = value;
            }
            get
            {
                ControlsToData();
                return _hardwareItemDescription as TestEquipment;
            }
        }

        protected override void DataToControls()
        {
            if (_hardwareItemDescription != null)
            {
                pathListControl1.HardwareItemDescription = _hardwareItemDescription;
                var testEquipment = _hardwareItemDescription as TestEquipment;
                if (testEquipment != null)
                {
                    base.DataToControls();
                    facilitiesRequirementsControl1.FacilitiesRequirements = testEquipment.FacilitiesRequirements;
                    switchingListControl1.Switching = testEquipment.Switching;
                    specificationsControl1.Specifications = testEquipment.Specifications;
                    resourceListControl1.Resources = testEquipment.Resources;
                    capabilitiesControl1.Capabilities = testEquipment.Capabilities;
                    terminalBlockListControl1.TestEquipmentTerminalBlocks = testEquipment.TerminalBlocks;
                    pathListControl1.Paths = testEquipment.Paths;
                    controllerListControl1.Controller = testEquipment.Controllers;
                    softwareItemListControl.ItemsDescriptions = testEquipment.Software;
                }
            }
        }

        protected override void ControlsToData()
        {
            if (_hardwareItemDescription == null)
                _hardwareItemDescription = new TestEquipment();

            base.ControlsToData();

            var testEquipment = _hardwareItemDescription as TestEquipment;
            if (testEquipment != null)
            {
                testEquipment.FacilitiesRequirements = facilitiesRequirementsControl1.FacilitiesRequirements;
                testEquipment.Switching = switchingListControl1.Switching;
                testEquipment.Specifications = specificationsControl1.Specifications;
                testEquipment.Resources = resourceListControl1.Resources;
                testEquipment.Capabilities = capabilitiesControl1.Capabilities;
                testEquipment.TerminalBlocks = terminalBlockListControl1.TestEquipmentTerminalBlocks;
                testEquipment.Paths = pathListControl1.Paths;
                testEquipment.Controllers = controllerListControl1.Controller;
                testEquipment.Software = softwareItemListControl.ItemsDescriptions;
            }
        }


        void TestEquipmentControl_Validating(object sender, CancelEventArgs e)
        {
            TestEquipment testEquipment = TestEquipment;
            if (testEquipment != null)
            {
                if (testEquipment.FacilitiesRequirements != null)
                {
                    var svr = new SchemaValidationResult();
                    if (!testEquipment.FacilitiesRequirements.Validate( svr ))
                        tabFacilities.ToolTipText = svr.ErrorMessage;
                }
                if (testEquipment.Controllers != null)
                {
                    foreach (Controller controller in testEquipment.Controllers)
                    {
                        var svr = new SchemaValidationResult();
                        if (!controller.Validate(svr))
                            tabControllers.ToolTipText = svr.ErrorMessage;
                    }
                }
                if (testEquipment.Software != null)
                {
                    foreach (ItemDescription itemDescription in testEquipment.Software)
                    {
                        var svr = new SchemaValidationResult();
                        if (!itemDescription.Validate(svr))
                            tabSoftware.ToolTipText = svr.ErrorMessage;
                    }
                }
                if (testEquipment.Paths != null)
                {
                    foreach (Path item in testEquipment.Paths)
                    {
                        var svr = new SchemaValidationResult();
                        if (!item.Validate(svr))
                            tabPaths.ToolTipText = svr.ErrorMessage;
                    }
                }
                if (testEquipment.Specifications != null)
                {
                    var svr = new SchemaValidationResult();
                    if (!testEquipment.Specifications.Validate(svr))
                        tabSpecifications.ToolTipText = svr.ErrorMessage;
                }
                if (testEquipment.Switching != null)
                {
                    var svr = new SchemaValidationResult();
                    if (!testEquipment.Switching.Validate(svr))
                        tabSwitching.ToolTipText = svr.ErrorMessage;
                }
                if (testEquipment.Resources != null)
                {
                    foreach (Resource item in testEquipment.Resources)
                    {
                        var svr = new SchemaValidationResult();
                        if (!item.Validate(svr))
                            tabResources.ToolTipText = svr.ErrorMessage;
                    }
                }
                if (testEquipment.Capabilities != null)
                {
                    var svr = new SchemaValidationResult();
                    if (!testEquipment.Capabilities.Validate(svr))
                        tabCapabilities.ToolTipText = svr.ErrorMessage;
                }
                if (testEquipment.TerminalBlocks != null)
                {
                    var svr = new SchemaValidationResult();
                    if (!testEquipment.TerminalBlocks.Validate(svr))
                        tabTerminalBlocks.ToolTipText = svr.ErrorMessage;
                }

            }

        }


    }
}