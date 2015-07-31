/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System.ComponentModel;
using ATMLCommonLibrary.controls;
using ATMLModelLibrary.model.common;

namespace ATML1671Reader.controls
{
    public partial class ItemInstanceControl : ItemDescriptionReferenceControl
    {
        public ItemInstanceControl()
        {
            InitializeComponent();
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ItemInstance ItemInstance
        {
            set
            {
                _itemDescriptionReference = value;
                DataToControls();
            }
            get
            {
                ControlsToData();
                return _itemDescriptionReference as ItemInstance;
            }
        }


        protected new void DataToControls()
        {
            base.DataToControls();
            if (_itemDescriptionReference != null)
            {
                var itemInstance = _itemDescriptionReference as ItemInstance;
                if (itemInstance != null)
                {
                    edtSerialNumber.Value = itemInstance.SerialNumber;
                }
            }
        }

        protected new void ControlsToData()
        {
            if (_itemDescriptionReference == null)
                _itemDescriptionReference = new ItemInstance();
            base.ControlsToData();
            var itemInstance = _itemDescriptionReference as ItemInstance;
            if (itemInstance != null)
            {
                itemInstance.SerialNumber = edtSerialNumber.GetValue<string>();
            }
        }
    }
}