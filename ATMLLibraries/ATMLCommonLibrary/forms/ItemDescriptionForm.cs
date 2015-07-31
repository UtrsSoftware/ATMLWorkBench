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
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.forms
{
    public partial class ItemDescriptionForm : ATMLCommonLibrary.forms.ATMLForm
    {

        public ItemDescription ItemDescription
        {
            set { itemDescriptionControl1.ItemDescription = value; }
            get { return itemDescriptionControl1.ItemDescription;  }
        }

        public ItemDescriptionForm()
        {
            InitializeComponent();
        }
    }
}
