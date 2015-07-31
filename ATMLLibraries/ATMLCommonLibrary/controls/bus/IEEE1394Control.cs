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
    public partial class IEEE1394Control : BusControl
    {
        public IEEE1394Control()
        {
            InitializeComponent();
            InitControls();
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IEEE1394 IEEE1394
        {
            set
            {
                Bus = value;
                DataToControls();
            }
            get
            {
                ControlsToData();
                return _bus as IEEE1394;
            }
        }

        protected override void DataToControls()
        {
            if (_bus != null)
            {
                base.DataToControls();
            }
        }

        protected override void ControlsToData()
        {
            if (_bus == null)
                _bus = new IEEE1394();
            base.ControlsToData();
        }
    }
}