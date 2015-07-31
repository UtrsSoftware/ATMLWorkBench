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
using ATMLModelLibrary.model.common;

namespace ATMLCommonLibrary.controls.common
{
    public partial class CollectionItemControl : ATMLCommonLibrary.controls.common.ValueControl
    {

        public CollectionItemControl()
        {
            InitializeComponent();
        }

        public CollectionItem CollectionItem
        {
            get { ControlsToData(); return _value as CollectionItem; }
            set { _value = value; DataToControls(); }
        }


        protected override void ControlsToData()
        {
            if (_value == null)
                _value = new CollectionItem();
            //_collection.Confidence = 
            base.ControlsToData();
            var collectionItem = _value as CollectionItem;
            if (collectionItem != null)
            {
                collectionItem.name = edtItemName.GetValue<string>();
            }
        }

        protected override void DataToControls()
        {
            base.DataToControls();
            var collectionItem = _value as CollectionItem;
            if (collectionItem != null)
            {
                edtItemName.Value = collectionItem.name;
            }
        }
    }
}
