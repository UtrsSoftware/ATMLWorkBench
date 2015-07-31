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
using ATMLCommonLibrary.controls.lists;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.equipment
{
    public partial class TerminalBlockListControl : ATMLListControl
    {
        public TerminalBlockListControl()
        {
            InitializeComponent();
            InitListView();
        }

        private TestEquipmentTerminalBlocks _terminalBlocks;

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TestEquipmentTerminalBlocks TestEquipmentTerminalBlocks
        {
            get
            { 
                ControlsToData();
                return _terminalBlocks;
            }
            set
            {
                _terminalBlocks = value;
                DataToControls();
            }
        }

        private void InitListView()
        {
            DataObjectName = "TerminalBlock";
            DataObjectFormType = typeof(TerminalBlockForm);
            AddColumnData("Interface", "ToString()", 1.0);
            InitColumns();
        }

        protected void DataToControls()
        {
            if (_terminalBlocks != null && _terminalBlocks.TerminalBlock != null)
            {
                lvList.Items.Clear();
                foreach (TestEquipmentTerminalBlocksTerminalBlock terminalBlock in _terminalBlocks.TerminalBlock)
                {
                    AddListViewObject(terminalBlock);
                }
            }
        }

        protected void ControlsToData()
        {
            if (lvList.Items.Count > 0)
            {
                if (_terminalBlocks == null)
                    _terminalBlocks = new TestEquipmentTerminalBlocks();
                _terminalBlocks.TerminalBlock = new List<TestEquipmentTerminalBlocksTerminalBlock>();
                foreach (ListViewItem lvi in lvList.Items)
                {
                    var termBlock = (TestEquipmentTerminalBlocksTerminalBlock)lvi.Tag;
                    _terminalBlocks.TerminalBlock.Add(termBlock);
                }
            }
            else
            {
                _terminalBlocks = null;
            }
        }

    }
}