/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
using System.ComponentModel;
using System.Net;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.bus
{
    public partial class PXIeControl : PXIControl
    {
        public PXIeControl()
        {
            InitializeComponent();
            InitControls();
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PXIe PXIe
        {
            set
            {
                Bus = value;
                DataToControls();
            }
            get
            {
                ControlsToData();
                return (PXIe) _bus;
            }
        }


        protected override void DataToControls()
        {
            base.DataToControls();
            if (_bus == null)
                return;
            var pxie = (PXIe) _bus;
            edtLanes.Text = "" + pxie.numberOfLanes;
        }

        protected override void ControlsToData()
        {
            if (_bus == null)
                _bus = new PXIe();
            base.ControlsToData();
            int d;
            if (int.TryParse(edtLanes.Text, out d))
                ((PXIe)_bus).numberOfLanes = d;

        }
    }
}