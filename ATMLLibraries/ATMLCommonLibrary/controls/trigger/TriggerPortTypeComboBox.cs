/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.ComponentModel;
using System.Windows.Forms;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.trigger
{
    public partial class TriggerPortTypeComboBox : ComboBox
    {
        public TriggerPortTypeComboBox()
        {
            InitializeComponent();
            if (!this.IsInDesignMode())
                Items.AddRange(Enum.GetNames(typeof (TriggerPortType)));
        }

        public TriggerPortTypeComboBox(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            if (!this.IsInDesignMode())
                Items.AddRange(Enum.GetNames(typeof (TriggerPortType)));
        }
    }
}