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

namespace ATMLCommonLibrary.controls.hardware.characteristics
{
    public partial class PhysicalCharLinearControl : ATMLControl
    {
        private double _rackUSize;
        private double _rackUSizeInches;
        private double _rackUSizeMilli;
     
        private PhysicalCharacteristicsLinearMeasurements _physicalCharacteristicsLinearMeasurements;


        public PhysicalCharLinearControl()
        {
            InitializeComponent();
            
              
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PhysicalCharacteristicsLinearMeasurements PhysicalCharacteristicsLinearMeasurements
        {
            get
            {
                ControlsToData();
                return _physicalCharacteristicsLinearMeasurements;
            }
            set
            {
                _physicalCharacteristicsLinearMeasurements = value;
                DataToControls();
            }
        }

        private void rdoRack_CheckedChanged(object sender, EventArgs e)
        {
            edtTextRack.Value = _rackUSize;
            edtTextRack.Tag = "I";
        }

        private void rdoInch_CheckedChanged(object sender, EventArgs e)
        {
            _rackUSizeInches = Math.Round(_rackUSize * 1.75, 2);
            edtTextRack.Value = _rackUSizeInches;
            edtTextRack.Tag = "I";

        }

        private void rdoMilli_CheckedChanged(object sender, EventArgs e)
        {
            _rackUSizeMilli = Math.Round(_rackUSize * 44.45, 2);
            edtTextRack.Value = _rackUSizeMilli;
            edtTextRack.Tag = "M";
        }

        private void UpdateRacksize(bool textChanged = false )
        {
            if (rdoRack.Checked)
            {
                _rackUSize = edtTextRack.GetValue<double>();
                edtTextRack.Tag = "R";
            }

            if (rdoInch.Checked)
            {
                _rackUSize = Math.Round((edtTextRack.GetValue<double>()) / 1.75, 2);
                edtTextRack.Tag = "I";
            }

            if (rdoMilli.Checked)
            {
                _rackUSize = Math.Round((edtTextRack.GetValue<double>() / 44.45), 2);
                edtTextRack.Tag = "M";
            }
            _rackUSizeInches = Math.Round(_rackUSize * 1.75, 2);
            _rackUSizeMilli = Math.Round(_rackUSize * 44.45, 2);

            label2.Text = _rackUSize + @" Rack Unit(s)";
        }

        private void DataToControls()
        {
            if (_physicalCharacteristicsLinearMeasurements != null)
            {
                datumDepth.DoubleValue = _physicalCharacteristicsLinearMeasurements.Depth;
                datumHeight.DoubleValue = _physicalCharacteristicsLinearMeasurements.Height;
                datumWidth.DoubleValue = _physicalCharacteristicsLinearMeasurements.Width;
                if (_physicalCharacteristicsLinearMeasurements.RackUSize != null)
                {
                    _rackUSize = _physicalCharacteristicsLinearMeasurements.RackUSize.value;
                    _rackUSizeInches = Math.Round(_rackUSize * 1.75, 2);
                    _rackUSizeMilli = Math.Round(_rackUSize * 44.45, 2);
                    edtTextRack.Value = _rackUSize;
                    edtTextRack.Tag = "R";
                }
            }
        }

        private void ControlsToData()
        {
            if (_physicalCharacteristicsLinearMeasurements == null)
                _physicalCharacteristicsLinearMeasurements = new PhysicalCharacteristicsLinearMeasurements();

            _physicalCharacteristicsLinearMeasurements.Depth = datumDepth.DoubleValue.value>0?datumDepth.DoubleValue:null;
            _physicalCharacteristicsLinearMeasurements.Height = datumHeight.DoubleValue.value>0?datumHeight.DoubleValue:null;
            _physicalCharacteristicsLinearMeasurements.Width = datumWidth.DoubleValue.value>0?datumWidth.DoubleValue:null;
            if (_rackUSize > 0)
            {
                if (_physicalCharacteristicsLinearMeasurements.RackUSize == null)
                    _physicalCharacteristicsLinearMeasurements.RackUSize =
                        new PhysicalCharacteristicsLinearMeasurementsRackUSize();
                _physicalCharacteristicsLinearMeasurements.RackUSize.value = _rackUSize;
            }
            else
            {
                _physicalCharacteristicsLinearMeasurements.RackUSize = null;
            }

            if (_physicalCharacteristicsLinearMeasurements.Depth == null &&
                _physicalCharacteristicsLinearMeasurements.Height == null &&
                _physicalCharacteristicsLinearMeasurements.Width == null &&
                _physicalCharacteristicsLinearMeasurements.RackUSize == null)
            {
                _physicalCharacteristicsLinearMeasurements = null;
            }
        }

        private void edtTextRack_TextChanged(object sender, EventArgs e)
        {
            UpdateRacksize(true);
        }
    }
}

