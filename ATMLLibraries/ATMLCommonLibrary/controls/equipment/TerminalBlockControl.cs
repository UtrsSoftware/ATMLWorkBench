/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System.ComponentModel;
using ATMLManagerLibrary.managers;
using ATMLModelLibrary;
using ATMLModelLibrary.model.common;
using ATMLModelLibrary.model.equipment;
using ATMLSchemaLibrary.managers;

namespace ATMLCommonLibrary.controls.equipment
{
    public partial class TerminalBlockControl : RepeatedItemControl
    {
        public TerminalBlockControl()
        {
            InitializeComponent();
            Validating += TerminalBlockControl_Validating;
        }

        public TestEquipmentTerminalBlocksTerminalBlock TerminalBlock
        {
            get
            {
                ControlsToData();
                return _item as TestEquipmentTerminalBlocksTerminalBlock;
            }
            set
            {
                _item = value;
                DataToControls();
            }
        }

        private void TerminalBlockControl_Validating(object sender, CancelEventArgs e)
        {
            var tb = _item as TestEquipmentTerminalBlocksTerminalBlock;
            string error;
            //if (tb != null && !SchemaManager.ValidateXml(tb.Serialize(), ATMLCommon.TestEquipmentNameSpace, out error))
            //    LogManager.Error(error);
            //if (tb != null) 
            //    ValidateToSchema(tb);
            e.Cancel = false;
        }

        protected override void ControlsToData()
        {
            if (_item == null)
                _item = new TestEquipmentTerminalBlocksTerminalBlock();
            base.ControlsToData();
            var tb = _item as TestEquipmentTerminalBlocksTerminalBlock;
            if (tb != null)
            {
                if (InterfaceportList.Ports != null && InterfaceportList.Ports.Count > 0)
                {
                    tb.Interface = new Interface();
                    tb.Interface.Ports = InterfaceportList.Ports;
                }
                else
                {
                    tb.Interface = null;
                }
            }
        }


        protected override void DataToControls()
        {
            base.DataToControls();
            if (_item != null)
            {
                var tb = _item as TestEquipmentTerminalBlocksTerminalBlock;
                if (tb != null && tb.Interface != null)
                    InterfaceportList.Ports = tb.Interface.Ports;
            }
        }
    }
}