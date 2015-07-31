/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System.ComponentModel;
using ATMLCommonLibrary.controls;
using ATMLCommonLibrary.controls.document;
using ATMLModelLibrary.model.common;

namespace ATML1671Reader.controls
{
    public partial class TestEquipmentControl : ItemDescriptionReferenceControl
    {
        public TestEquipmentControl()
        {
            InitializeComponent();
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TestConfigurationTestEquipmentItem TestEquipmentItem
        {
            get
            {
                ControlsToData();
                return base.ItemDescriptionReference as TestConfigurationTestEquipmentItem;
            }
            set
            {
                base.ItemDescriptionReference = value;
                DataToControls();
            }
        }

        protected override void DataToControls()
        {
            base.DataToControls();
            TestConfigurationTestEquipmentItem testEquipmentItem =
                base.ItemDescriptionReference as TestConfigurationTestEquipmentItem;
            //Fill Tabbed Controls
            if (testEquipmentItem != null)
            {
                //testEquipmentItem.Instrumentation;
                //testEquipmentItem.Resource;
                //testEquipmentItem.Software;


            }
        }

        protected override void ControlsToData()
        {
            if (base.ItemDescriptionReference == null)
                base.ItemDescriptionReference = new TestConfigurationTestEquipmentItem();
            TestConfigurationTestEquipmentItem testEquipmentItem =
                base.ItemDescriptionReference as TestConfigurationTestEquipmentItem;
            base.ControlsToData();
            //Grab Tabbed Controls Data
            if (testEquipmentItem != null)
            {
                SoftwareInstance si;
                
            }
        }

        private void panel2_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {

        }

        private void itemDescriptionControl_Load(object sender, System.EventArgs e)
        {

        }
    }
}