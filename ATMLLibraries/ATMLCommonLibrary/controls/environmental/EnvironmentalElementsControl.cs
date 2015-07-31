/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.ComponentModel;
using ATMLModelLibrary.model.common;

namespace ATMLCommonLibrary.controls.environmental
{
    public partial class EnvironmentalElementsControl : ATMLControl
    {
        private EnvironmentalElements _environmentalElements;

        public EnvironmentalElementsControl()
        {
            InitializeComponent();
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public EnvironmentalElements EnvironmentalElements
        {
            get
            {
                ControlsToData();
                return _environmentalElements;
            }
            set
            {
                _environmentalElements = value;
                DataToControls();
            }
        }

        private void DataToControls()
        {
            if (_environmentalElements != null)
            {
                altitude.Limit = _environmentalElements.Altitude;
                humidity.Limit = _environmentalElements.Humidity;
                shock.Limit = _environmentalElements.Shock;
                temperature.Limit = _environmentalElements.Temperature;
                environmentalElementsVibrationControl.Vibration = _environmentalElements.Vibration;
            }
        }

        private void ControlsToData()
        {
            if (HasData())
            {
                if (_environmentalElements == null)
                    _environmentalElements = new EnvironmentalElements();
                _environmentalElements.Altitude = altitude.Limit;
                _environmentalElements.Humidity = humidity.Limit;
                _environmentalElements.Shock = shock.Limit;
                _environmentalElements.Temperature = temperature.Limit;
                _environmentalElements.Vibration = environmentalElementsVibrationControl.Vibration;
            }
            else
            {
                _environmentalElements = null;
            }
        }

        private bool HasData()
        {
            return altitude.Limit != null
                   || humidity.Limit != null
                   || shock.Limit != null
                   || temperature.Limit != null
                   || environmentalElementsVibrationControl.Vibration != null;
        }

        private void humidity_Load(object sender, EventArgs e)
        {
        }
    }
}