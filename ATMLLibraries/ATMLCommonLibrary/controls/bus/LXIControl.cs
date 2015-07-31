/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
using System;
using System.ComponentModel;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.bus
{
    public partial class LXIControl : EthernetControl
    {
        public LXIControl()
        {
            InitControls();
            InitializeComponent();
            cmbLXIClass.DataSource = Enum.GetNames(typeof (LXIClass));
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public LXI LXI
        {
            set
            {
                Bus = value;
                DataToControls();
            }
            get
            {
                ControlsToData();
                return _bus as LXI;
            }
        }

        protected override void DataToControls()
        {
            if (_bus == null)
                return;
            base.DataToControls();
            LXI lxi = (LXI) _bus;
            edtLXIVersion.Value = lxi.LXIVersion;
            cmbLXIClass.SelectedItem = Enum.GetName( typeof(LXIClass), lxi.@class );
        }

        protected override void ControlsToData()
        {
            if (_bus == null)
                _bus = new LXI();
            base.ControlsToData();
            LXI lxi = (LXI)_bus;
            lxi.LXIVersion = edtLXIVersion.GetValue<string>();
            lxi.@class = (LXIClass) Enum.Parse(typeof (LXIClass), (String) cmbLXIClass.SelectedItem);
        }

    }
}