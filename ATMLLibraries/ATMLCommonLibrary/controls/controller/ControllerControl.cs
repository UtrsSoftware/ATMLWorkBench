/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.controller
{
    public partial class ControllerControl : ItemDescriptionControl
    {
        public ControllerControl()
        {
            InitializeComponent();
            VideoCapabilities.AddColumn("Capability", "capability");
            AudioCapabilities1.AddColumn("Capability", "capability");
            Peripherals.InitializeForm += Peripherals_InitializeForm;
            InstalledSoftware.InitializeForm += InstalledSoftware_InitializeForm;
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Controller Controller
        {
            get
            {
                ControlsToData();
                return itemDescription as Controller;
            }
            set
            {
                itemDescription = value;
                DataToControls();
            }
        }

        private void InstalledSoftware_InitializeForm(Form form)
        {
            form.Text = @"Installed Software";
        }

        private void Peripherals_InitializeForm(Form form)
        {
            form.Text = @"Peripheral";
        }

        private new void DataToControls()
        {
            if (itemDescription != null)
            {
                var controller = itemDescription as Controller;
                base.DataToControls();
                if (controller != null)
                {
                    edtDatumPhysicalMemory.DoubleValue = controller.PhysicalMemory;
                    controllerOperatingSystemListControl1.OperatingSystems = controller.OperatingSystems;
                    controllerProcessorControl1.ControllerProcessor = controller.Processor;
                    ControllerDrive.ControllerDrive = controller.Storage;
                    InstalledSoftware.ItemsDescriptions = controller.InstalledSoftware;
                    Peripherals.ItemsDescriptions = controller.Peripherals;
                    if (controller.VideoCapabilities != null)
                    {
                        foreach (string video in controller.VideoCapabilities)
                        {
                            DataGridViewRow row = VideoCapabilities.AddRow();
                            VideoCapabilities.AddColumnData(row, "capability", video);
                        }
                    }
                    if (controller.AudioCapabilities != null)
                    {
                        foreach (string audio in controller.AudioCapabilities)
                        {
                            DataGridViewRow row = AudioCapabilities1.AddRow();
                            AudioCapabilities1.AddColumnData(row, "capability", audio);
                        }
                    }
                }
            }
        }

        private new void ControlsToData()
        {
            if (itemDescription == null)
                itemDescription = new Controller();
            base.ControlsToData();
            var controller = itemDescription as Controller;
            if (controller != null)
            {
                controller.PhysicalMemory = edtDatumPhysicalMemory.DoubleValue;
                controller.InstalledSoftware = InstalledSoftware.ItemsDescriptions;
                controller.Storage = ControllerDrive.ControllerDrive;
                controller.Processor = controllerProcessorControl1.ControllerProcessor;
                controller.Peripherals = Peripherals.ItemsDescriptions;
                controller.OperatingSystems = controllerOperatingSystemListControl1.OperatingSystems;
                List<List<string>> table = VideoCapabilities.GetTable();
                controller.VideoCapabilities = new List<string>();
                foreach (var tableRow in table)
                {
                    if (tableRow.Count > 0)
                        controller.VideoCapabilities.Add(tableRow[0]);
                }
                List<List<string>> table2 = AudioCapabilities1.GetTable();
                controller.AudioCapabilities = new List<string>();
                foreach (var tableRow in table2)
                {
                    if (tableRow.Count > 0)
                        controller.AudioCapabilities.Add(tableRow[0]);
                }
            }
        }
    }
}