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
    public partial class VXIModuleCoolingControl : ATMLControl
    {
        private VXIModuleCooling _VXIModuleCooling;

        public VXIModuleCoolingControl()
        {
            InitializeComponent();
            InitControls();
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public VXIModuleCooling VXIModuleCooling
        {
            get
            {
                ControlsToData();
                return _VXIModuleCooling;
            }
            set
            {
                _VXIModuleCooling = value;
                DataToControls();
            }
        }


        private void DataToControls()
        {
            if (_VXIModuleCooling == null)
                return;
            edtAirFlow.Value = (decimal) _VXIModuleCooling.airFlow;
            edtBackPressure.Value = (decimal) _VXIModuleCooling.backPressure;
        }

        private void ControlsToData()
        {
            if (_VXIModuleCooling == null)
                _VXIModuleCooling = new VXIModuleCooling();
            _VXIModuleCooling.airFlow = (int) edtAirFlow.Value;
            _VXIModuleCooling.backPressure = (int) edtBackPressure.Value;
        }
    }
}