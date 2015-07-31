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
using ATMLCommonLibrary.model;
using ATMLModelLibrary.model.common;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.common
{
    public partial class ItemControl : ATMLControl
    {

        protected Item _item;
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Item Item
        {
            get { ControlsToData(); return _item; }
            set { _item = value; DataToControls(); }
        }

        public ItemControl()
        {
            InitializeComponent();
            InitControls();
        }

        protected virtual void DataToControls()
        {
            if (_item != null)
            {
                edtName.Value = _item.name;
                edtDescription.Value = _item.Description;
            }
        }

        protected virtual void ControlsToData()
        {
            if (_item != null)
            {
                _item.name = edtName.GetValue<string>();
                _item.Description = edtDescription.GetValue<string>();
            }
        }

    }
}
