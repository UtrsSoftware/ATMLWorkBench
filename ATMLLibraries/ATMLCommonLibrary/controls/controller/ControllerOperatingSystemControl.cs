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
    public partial class ControllerOperatingSystemControl : ItemDescriptionControl
    {
        
        const string OPERATINGSYSTEMUPDATES = "operatingsystemupdates";

        public ControllerOperatingSystemControl()
        {
            InitializeComponent();
            OperatingSystemUpdates.AddColumn("Updates", OPERATINGSYSTEMUPDATES);
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ControllerOperatingSystem OperatingSystems
        {
            get
            {
                ControlsToData();
                return itemDescription as ControllerOperatingSystem;
            }
            set
            {
                itemDescription = value;
                DataToControls();
            }
        }

        private new void DataToControls()
        {
            if (itemDescription != null)
            {
                base.DataToControls();
                var operatingSystem = itemDescription as ControllerOperatingSystem;
                if (operatingSystem != null && operatingSystem.OperatingSystemUpdates != null)
                {
                    foreach (string OS in operatingSystem.OperatingSystemUpdates)
                    {
                        DataGridViewRow row = OperatingSystemUpdates.AddRow();
                        OperatingSystemUpdates.AddColumnData(row, OPERATINGSYSTEMUPDATES, OS);
                    }
                }
            }
        }

        private new void ControlsToData()
        {
            if (itemDescription == null)
                itemDescription = new ControllerOperatingSystem();
            base.ControlsToData();
            var operatingSystem = itemDescription as ControllerOperatingSystem;
            List<List<string>> table = OperatingSystemUpdates.GetTable();
            if (operatingSystem != null)
            {
                operatingSystem.OperatingSystemUpdates = new List<string>();
                foreach (var tableRow in table)
                {
                    if (tableRow.Count > 0)
                        operatingSystem.OperatingSystemUpdates.Add(tableRow[0]);
                }
            }
        }
    }
}