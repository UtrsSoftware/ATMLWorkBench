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
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ATMLCommonLibrary.controls.equipment;
using ATMLModelLibrary.model.common;

namespace ATMLCommonLibrary.controls.environmental
{
    
    public partial class EnvironmentalElementsVibrationControl : ATMLControl
    {
        public EnvironmentalElementsVibrationControl()
        {
            InitializeComponent();
        }

        
        private EnvironmentalElementsVibration _vibration;
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public EnvironmentalElementsVibration Vibration
        {
            get { ControlsToData(); return _vibration; }
            set { _vibration = value; DataToControls(); }
        }

        private void DataToControls()
        {
            if (_vibration != null)
            {
                frequency.Limit = _vibration.Frequency;
                displacement.Limit = _vibration.Displacement;
                velocity.Limit = _vibration.Velocity;
            }

        }

        private void ControlsToData()
        {
            if (HasData())
            {
                if (_vibration == null)
                    _vibration = new EnvironmentalElementsVibration();
                _vibration.Frequency = frequency.Limit;
                _vibration.Displacement = displacement.Limit;
                _vibration.Velocity = velocity.Limit;
            }
            else
            {
                _vibration = null;
            }
        }

        private bool HasData()
        {
            return frequency.Limit != null 
                || displacement.Limit != null 
                || velocity.Limit != null;
        }
    }
}
