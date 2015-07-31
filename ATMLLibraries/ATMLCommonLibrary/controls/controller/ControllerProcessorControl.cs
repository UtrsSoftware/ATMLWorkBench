/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System.ComponentModel;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.controller
{
    public partial class ControllerProcessorControl : ATMLControl
    {
        private ControllerProcessor _controllerProcessor;

        public ControllerProcessorControl()
        {
            InitializeComponent();
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ControllerProcessor ControllerProcessor
        {
            get
            {
                ControlsToData();
                return _controllerProcessor;
            }
            set
            {
                _controllerProcessor = value;
                DataToControls();
            }
        }

        private void DataToControls()
        {
            if (_controllerProcessor != null)
            {
                edtDatumSpeed.DoubleValue = _controllerProcessor.Speed;
                edtArchitecture.Value = _controllerProcessor.Architecture;
                edtQuantity.Value = _controllerProcessor.Quantity;
                edtType.Value = _controllerProcessor.Type;
            }
        }

        private void ControlsToData()
        {
            if (_controllerProcessor == null)
                _controllerProcessor = new ControllerProcessor();
            _controllerProcessor.Type = edtType.GetValue<string>();
            _controllerProcessor.Architecture = edtArchitecture.GetValue<string>();
            _controllerProcessor.Quantity = edtQuantity.GetValue<int>();
            _controllerProcessor.Speed = edtDatumSpeed.DoubleValue;
        }
    }
}