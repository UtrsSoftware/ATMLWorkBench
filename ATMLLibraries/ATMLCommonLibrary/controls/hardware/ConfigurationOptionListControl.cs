/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ATMLCommonLibrary.controls.capability;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.hardware
{
    public partial class ConfigurationOptionListControl : ATMLCommonLibrary.controls.awb.AWBTextCollectionList
    {
        private List<HardwareItemDescriptionOption> _hardwareItemDescriptionOptions;

        public ConfigurationOptionListControl()
        {
            InitializeComponent();
            this.AddColumn( "Configuration Option", "configuration_option" );
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<HardwareItemDescriptionOption> HardwareItemDescriptionOptions
        {
            get{ControlsToData(); return _hardwareItemDescriptionOptions; }
            set { _hardwareItemDescriptionOptions = value; DataToControls(); }
        }

        private void DataToControls()
        {
            List<List<string>> table = GetTable();
            ClearData();
            foreach (HardwareItemDescriptionOption option in _hardwareItemDescriptionOptions)
            {
                AddColumnData(AddRow(), "configuration_option", option.name);    
            }
        }

        private void ControlsToData()
        {
            _hardwareItemDescriptionOptions = null;
            if (RowCount > 0)
            {
                _hardwareItemDescriptionOptions = new List<HardwareItemDescriptionOption>();
                foreach (List<string> list in GetTable())
                {
                    if (list.Count > 0)
                    {
                        HardwareItemDescriptionOption option = new HardwareItemDescriptionOption();
                        option.name = list[0];
                        _hardwareItemDescriptionOptions.Add( option );
                    }
                }
            }
        }
    }
}
