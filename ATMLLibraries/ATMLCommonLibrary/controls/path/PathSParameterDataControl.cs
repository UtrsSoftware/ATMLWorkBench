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

namespace ATMLCommonLibrary.controls.path
{
    public partial class PathSParameterDataControl : ATMLControl
    {
        private PathSParameterSParameterData _pathSParameterSParameterData;

        public PathSParameterDataControl()
        {
            InitializeComponent();
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PathSParameterSParameterData PathSParameterSParameterData
        {
            get
            {
                ControlsToData();
                return _pathSParameterSParameterData;
            }
            set
            {
                _pathSParameterSParameterData = value;
                DataToControls();
            }
        }

        private void DataToControls()
        {
            if (_pathSParameterSParameterData != null)
            {
                DatumFrequency.DoubleValue = _pathSParameterSParameterData.Frequency;
                DatumMagnitude.DoubleValue = _pathSParameterSParameterData.Magnitude;
                DatumPhase.DoubleValue = _pathSParameterSParameterData.PhaseAngle;
            }
        }

        private void ControlsToData()
        {
            if (_pathSParameterSParameterData == null)
                _pathSParameterSParameterData = new PathSParameterSParameterData();
            _pathSParameterSParameterData.PhaseAngle = DatumPhase.DoubleValue;
            _pathSParameterSParameterData.Magnitude = DatumMagnitude.DoubleValue;
            _pathSParameterSParameterData.Frequency = DatumFrequency.DoubleValue;
        }

        private void DatumFrequency_Load(object sender, EventArgs e)
        {
        }
    }
}