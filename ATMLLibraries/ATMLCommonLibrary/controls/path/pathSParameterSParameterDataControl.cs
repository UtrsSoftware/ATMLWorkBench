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
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.path
{
    public partial class pathSParameterSParameterDataControl : ATMLCommonLibrary.controls.ATMLControl
    {
        private PathSParameterSParameterData _PathspData;

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PathSParameterSParameterData PathspData
        {
            get { ControlsToData(); return _PathspData; }
            set { _PathspData = value; DataToControls(); }
        }
        public pathSParameterSParameterDataControl()
        {
            InitializeComponent();
        }
        private void DataToControls()
        {
            if (_PathspData != null)
            {
                DatumFrequency.DoubleValue = _PathspData.Frequency;
                DatumMagnitude.DoubleValue = _PathspData.Magnitude;
                DatumPhase.DoubleValue = _PathspData.PhaseAngle;
            }
        }
        private void ControlsToData()
        {
            if (_PathspData == null)
                _PathspData = new PathSParameterSParameterData();
            _PathspData.PhaseAngle = DatumPhase.DoubleValue;
            _PathspData.Magnitude = DatumMagnitude.DoubleValue;
            _PathspData.Frequency = DatumFrequency.DoubleValue;
        }

        private void DatumFrequency_Load(object sender, EventArgs e)
        {

        }
    }
}
