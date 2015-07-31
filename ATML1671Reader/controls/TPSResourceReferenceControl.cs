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
    public partial class TpsResourceReferenceControl : ItemDescriptionReferenceControl
    {
        public TpsResourceReferenceControl()
        {
            InitializeComponent();
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ConfigurationResourceReference ConfigurationResourceReference
        {
            set
            {
                _itemDescriptionReference = value;
                DataToControls();
            }
            get
            {
                ControlsToData();
                return _itemDescriptionReference as ConfigurationResourceReference;
            }
        }

        protected override void DataToControls()
        {
            base.DataToControls();
            var resourceReference =
                _itemDescriptionReference as ConfigurationResourceReference;
            if (resourceReference != null)
            {
                edtLocation.Value = resourceReference.location;
                edtQuantity.Value = resourceReference.quantity;
                edtType.Value = resourceReference.type;
            }
        }

        protected override void ControlsToData()
        {
            if (_itemDescriptionReference == null)
                _itemDescriptionReference = new ConfigurationResourceReference();
            base.ControlsToData();
            var resourceReference =
                _itemDescriptionReference as ConfigurationResourceReference;
            if (resourceReference != null)
            {
                resourceReference.location = edtLocation.GetValue<string>();
                resourceReference.quantity = (int) edtQuantity.Value;
                resourceReference.type = edtType.GetValue<string>();
            }
        }
    }
}