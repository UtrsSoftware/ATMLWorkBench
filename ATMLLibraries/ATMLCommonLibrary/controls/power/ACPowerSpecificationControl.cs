/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.ComponentModel;
using System.Windows.Forms;
using ATMLModelLibrary.model.equipment;
using Resources = ATMLCommonLibrary.Properties.Resources;

namespace ATMLCommonLibrary.controls.power
{
    public partial class ACPowerSpecificationControl : ATMLControl
    {
        private PowerSpecificationsAC _ACPower;


        public ACPowerSpecificationControl()
        {
            InitializeComponent();
            cmbPhase.Items.Add("");
            cmbPhase.Items.Add("1");
            cmbPhase.Items.Add("2");
            cmbPhase.Items.Add("3");
            rbAmpres.Checked = true;
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PowerSpecificationsAC ACPower
        {
            get
            {
                ControlsToData();
                return _ACPower;
            }
            set
            {
                _ACPower = value;
                DataToControls();
            }
        }

        private void DataToControls()
        {
            if (_ACPower != null)
            {
                cmbPhase.SelectedIndex = (int)_ACPower.phase;
                edtDescription.Value = _ACPower.Description;
                lmtVoltage.Limit = _ACPower.Voltage;
                lmtFrequency.Limit = _ACPower.Frequency;
                lmtAmpresPower.Limit = _ACPower.Item;
                rbAmpres.Checked = _ACPower.ItemElementName == PowerSpecificationsACItemChoiceType2.Amperage;
                rbPowerDraw.Checked = _ACPower.ItemElementName == PowerSpecificationsACItemChoiceType2.PowerDraw;
                connectorLocationPinListControl.ConnectorLocations = _ACPower.ConnectorPins;
            }
        }

        private void ControlsToData()
        {
            if (HasValue())
            {
                if (_ACPower == null)
                    _ACPower = new PowerSpecificationsAC();
                _ACPower.phaseSpecified = cmbPhase.SelectedIndex > 0;
                _ACPower.phase = cmbPhase.SelectedIndex;
                _ACPower.Description = edtDescription.GetValue<string>();
                _ACPower.Voltage = lmtVoltage.Limit;
                _ACPower.Frequency = lmtFrequency.Limit;
                _ACPower.Item = lmtAmpresPower.Limit;
                if (rbAmpres.Checked )
                    _ACPower.ItemElementName = PowerSpecificationsACItemChoiceType2.Amperage;
                else if( rbPowerDraw.Checked )
                    _ACPower.ItemElementName = PowerSpecificationsACItemChoiceType2.PowerDraw;
                _ACPower.ConnectorPins = connectorLocationPinListControl.ConnectorLocations;
            }
            else
            {
                _ACPower = null;
            }
        }

        public bool HasValue()
        {
            return cmbPhase.SelectedIndex > 0 
                   || edtDescription.HasValue()
                   || lmtVoltage.HasValue()
                   || lmtFrequency.HasValue()
                   || lmtAmpresPower.HasValue();
        }

        private void edtPhase_KeyUp(object sender, KeyEventArgs e)
        {
        }

        private void edtPhase_KeyDown(object sender, KeyEventArgs e)
        {
            //--- Suppress if a numeric key was not pressed ---//
            if (e.KeyCode < Keys.D0 && e.KeyCode > Keys.D9)
            {
                //--- Suppress if a numeric pad key was no pressed ---//
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    //--- Suppress if the backspace was no pressed pressed ---//
                    if (e.KeyCode != Keys.Back)
                    {
                        // A non-numerical keystroke was pressed.
                        // Set the flag to true and evaluate in KeyPress event.
                        e.SuppressKeyPress = true;
                    }
                }
            }

            //--- Suppress if the shift key was being pressed as well ---//
            if (ModifierKeys == Keys.Shift)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void edtPhase_TextChanged(object sender, EventArgs e)
        {
        }

        private void rbAmpres_CheckedChanged(object sender, EventArgs e)
        {
            lblPower.Text = Resources.Ampres;
        }

        private void rbPowerDraw_CheckedChanged(object sender, EventArgs e)
        {
            lblPower.Text = Resources.Power_Draw;
        }

        private void gbPower_Enter(object sender, EventArgs e)
        {

        }
    }
}