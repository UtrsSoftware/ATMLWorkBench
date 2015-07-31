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
using Resources = ATMLCommonLibrary.Properties.Resources;

namespace ATMLCommonLibrary.controls.power
{
    public partial class DCPowerSpecificationControl : ATMLControl
    {
        private PowerSpecificationsDC _DCPower;

        public DCPowerSpecificationControl()
        {
            InitializeComponent();
            rbAmpres.Checked = true;
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PowerSpecificationsDC DCPower
        {
            get
            {
                ControlsToData();
                return _DCPower;
            }
            set
            {
                _DCPower = value;
                DataToControls();
            }
        }

        private void DataToControls()
        {
            if (_DCPower != null)
            {
                chkHasPolarity.Checked = _DCPower.polaritySpecified;
                chkHasRipple.Checked = _DCPower.rippleSpecified;
                lmtVoltage.Limit = _DCPower.Voltage;
                edtDescription.Value = _DCPower.Description;
                edtPolarity.Value = _DCPower.polaritySpecified ? Convert.ToDecimal(_DCPower.polarity) : 0;
                edtRipple.Value = _DCPower.rippleSpecified ? Convert.ToDecimal(_DCPower.ripple) : 0;
                lmtAmpresPower.Limit = _DCPower.Item;
                connectorLocationPinListControl.ConnectorLocations = _DCPower.ConnectorPins;
                rbAmpres.Checked = _DCPower.ItemElementName == PowerSpecificationsDCItemChoiceType3.Amperage;
                rbPowerDraw.Checked = _DCPower.ItemElementName == PowerSpecificationsDCItemChoiceType3.PowerDraw;
            }
            SetControlStates();
        }

        private void ControlsToData()
        {
            if (_DCPower == null)
                _DCPower = new PowerSpecificationsDC();
            _DCPower.Voltage = lmtVoltage.Limit;
            if( rbAmpres.Checked )
                _DCPower.ItemElementName = PowerSpecificationsDCItemChoiceType3.Amperage;
            if( rbPowerDraw.Checked )
                _DCPower.ItemElementName = PowerSpecificationsDCItemChoiceType3.PowerDraw;
            _DCPower.Item = lmtAmpresPower.Limit;
            _DCPower.Description = edtDescription.GetValue<string>();
            _DCPower.polarity = Convert.ToDouble(edtPolarity.Value);
            _DCPower.polaritySpecified = chkHasPolarity.Checked;
            _DCPower.ripple = Convert.ToDouble(edtRipple.Value);
            _DCPower.rippleSpecified = chkHasRipple.Checked;
            _DCPower.ConnectorPins = connectorLocationPinListControl.ConnectorLocations;
        }

        private void chkHasPolarity_CheckedChanged(object sender, EventArgs e)
        {
            SetControlStates();
        }

        private void chkHasRipple_CheckedChanged(object sender, EventArgs e)
        {
            SetControlStates();
        }

        private void SetControlStates()
        {
            edtRipple.Enabled = chkHasRipple.Checked;
            edtPolarity.Enabled = chkHasPolarity.Checked;
        }

        private void rbAmpres_CheckedChanged(object sender, EventArgs e)
        {
            lblPower.Text = Resources.Ampres;
        }

        private void rbPowerDraw_CheckedChanged(object sender, EventArgs e)
        {
            lblPower.Text = Resources.Power_Draw;
        }
    }
}