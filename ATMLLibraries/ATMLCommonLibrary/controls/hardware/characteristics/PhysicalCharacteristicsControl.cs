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
using ATMLModelLibrary.model.equipment;
using ATMLCommonLibrary;

namespace ATMLCommonLibrary.controls.hardware.characteristics
{
    public partial class PhysicalCharacteristicsControl : ATMLCommonLibrary.controls.ATMLControl
    {
        PhysicalCharacteristics _physicalCharacteristics;

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PhysicalCharacteristics PhysicalCharacteristics
        {
            get { ControlsToData(); return _physicalCharacteristics; }
            set { _physicalCharacteristics = value; DataToControls(); }
        }

        public PhysicalCharacteristicsControl()
        {
            InitializeComponent();
        }

        private void DataToControls()
        {
            if (_physicalCharacteristics != null)
            {
                physicalCharLinearControl.PhysicalCharacteristicsLinearMeasurements = _physicalCharacteristics.LinearMeasurements;
                DatumMass.DoubleValue = _physicalCharacteristics.Mass;
                DatumVolume.DoubleValue = _physicalCharacteristics.Volume;
                otherListControl.NamedValues = _physicalCharacteristics.Other;
            }

        }

        private void ControlsToData()
        {
            if (_physicalCharacteristics == null)
                _physicalCharacteristics = new PhysicalCharacteristics();

            _physicalCharacteristics.Mass = DatumMass.DoubleValue.value > 0 ? DatumMass.DoubleValue : null;
            _physicalCharacteristics.Volume = DatumVolume.DoubleValue.value > 0 ? DatumVolume.DoubleValue : null;

            if (_physicalCharacteristics.LinearMeasurements == null)
                _physicalCharacteristics.LinearMeasurements = new PhysicalCharacteristicsLinearMeasurements();

            _physicalCharacteristics.LinearMeasurements = physicalCharLinearControl.PhysicalCharacteristicsLinearMeasurements;
            _physicalCharacteristics.Other = otherListControl.NamedValues;
            if (_physicalCharacteristics.Mass == null
                && _physicalCharacteristics.Volume == null
                && _physicalCharacteristics.LinearMeasurements == null
                && _physicalCharacteristics.Other == null)
            {
                _physicalCharacteristics = null;
            }
        }

        private void physicalCharLinearControl_Load(object sender, EventArgs e)
        {

        }

    }
   
}

    
