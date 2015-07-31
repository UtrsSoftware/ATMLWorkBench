/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
using System.ComponentModel;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.bus
{
    public partial class VMEControl : BusControl
    {
        public VMEControl()
        {
            InitializeComponent();
            InitControls();
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public VME VME
        {
            set
            {
                _bus = value;
                DataToControls();
            }

            get
            {
                ControlsToData();
                return (VME) _bus;
            }
        }


        protected override void DataToControls()
        {
            if (_bus == null)
                return;
            var vme = (VME) _bus;
            base.DataToControls();
        }

        protected override void ControlsToData()
        {
            if (_bus == null)
                _bus = new VME();
            base.ControlsToData();
        }
    }
}