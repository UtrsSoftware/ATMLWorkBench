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
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.component
{
    public partial class ComponentControl : ItemDescriptionReferenceControl
    {
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public HardwareItemDescriptionComponent HardwareItemDescriptionComponent 
        {
            get { ControlsToData(); return _itemDescriptionReference as HardwareItemDescriptionComponent; }
            set { _itemDescriptionReference = value; DataToControls();}
        }

        public HardwareItemDescriptionComponent1 HardwareItemDescriptionComponent1
        {
            get { ControlsToData(); return _itemDescriptionReference as HardwareItemDescriptionComponent1; }
            set { 
                    _itemDescriptionReference = value;
                    IsParentComponent = true; 
                    DataToControls(); 
                }
        }

        public bool IsParentComponent { get; set; }

        public ComponentControl()
        {
            InitializeComponent();
        }

        protected override void DataToControls()
        {
            base.DataToControls();
            var item1 = _itemDescriptionReference as HardwareItemDescriptionComponent;
            var item2 = _itemDescriptionReference as HardwareItemDescriptionComponent1;
            if (item1 != null)
            {
                edtId.Value = item1.ID;
            }
            if (item2 != null)
            {
                edtId.Value = item2.ID;
            }
        }

        protected override void ControlsToData()
        {
            if (_itemDescriptionReference == null)
            {
                if (IsParentComponent)
                    _itemDescriptionReference = new HardwareItemDescriptionComponent1();
                else
                    _itemDescriptionReference = new HardwareItemDescriptionComponent();
            }
            base.ControlsToData();
            var item1 = _itemDescriptionReference as HardwareItemDescriptionComponent;
            var item2 = _itemDescriptionReference as HardwareItemDescriptionComponent1;
            if (item1 != null)
            {
                item1.ID = edtId.GetValue<string>();
            }
            if (item2 != null)
            {
                item2.ID = edtId.GetValue<string>();
            }

        }
    }
}
