/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
using System;
using System.ComponentModel;
using ATMLCommonLibrary.forms;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.switching
{
    public partial class SwitchForm : ATMLForm
    {
        private const String MATRIX_SWITCH = "Matrix Switch";
        private const String SWITCH = "Switch";
        private const String CROSS_POINT_SWITCH = "Cross Point Switch";

        private Item switchItem;

        public SwitchForm(InstrumentDescription instrument)
        {
            InitializeComponent();
            matrixSwitchControl.Visible = false;
            switchControl.Instrument = instrument;
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Item SwitchItem
        {
            get
            {
                ControlsToData();
                return switchItem;
            }
            set
            {
                switchItem = value;
                DataToControls();
            }
        }

        private void DataToControls()
        {
            if (switchItem != null)
            {
                if (switchItem is MatrixSwitch)
                {
                    matrixSwitchControl.MatrixSwitch = (MatrixSwitch) switchItem;
                    cmbSwitchType.SelectedIndex = cmbSwitchType.FindStringExact(MATRIX_SWITCH);
                }
                else if (switchItem is Switch)
                {
                    switchControl.Switch = (Switch) switchItem;
                    cmbSwitchType.SelectedIndex = cmbSwitchType.FindStringExact(SWITCH);
                }
                else if (switchItem is CrossPointSwitch)
                {
                    crossPointSwitchControl.CrossPointSwitch = (CrossPointSwitch) switchItem;
                    cmbSwitchType.SelectedIndex = cmbSwitchType.FindStringExact(CROSS_POINT_SWITCH);
                }

                //----------------------------------------------------------------------------------//
                //--- We don't want the user to change the switch type once it has been created, ---//
                //--- they'll need to delete it and create a new one to change the type.         ---//
                //----------------------------------------------------------------------------------//
                cmbSwitchType.Enabled = false;
            }
        }

        private void ControlsToData()
        {
            if (SWITCH.Equals(cmbSwitchType.SelectedItem))
            {
                switchItem = switchControl.Switch;
            }
            else if (MATRIX_SWITCH.Equals(cmbSwitchType.SelectedItem))
            {
                switchItem = matrixSwitchControl.MatrixSwitch;
            }
            else if (CROSS_POINT_SWITCH.Equals(cmbSwitchType.SelectedItem))
            {
                switchItem = crossPointSwitchControl.CrossPointSwitch;
            }
        }

        private void cmbSwitchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetSwitchSelection();
        }

        private void SetSwitchSelection()
        {
            matrixSwitchControl.Enabled = matrixSwitchControl.Visible = false;
            switchControl.Enabled = switchControl.Visible = false;
            crossPointSwitchControl.Enabled = crossPointSwitchControl.Visible = false;

            if (SWITCH.Equals(cmbSwitchType.SelectedItem))
            {
                Text = SWITCH;
                switchControl.Enabled = switchControl.Visible = true;
                if (cmbSwitchType.Enabled && switchControl.Switch == null)
                    switchControl.Switch = new Switch();
            }
            else if (MATRIX_SWITCH.Equals(cmbSwitchType.SelectedItem))
            {
                Text = MATRIX_SWITCH;
                matrixSwitchControl.Enabled = matrixSwitchControl.Visible = true;
                if (cmbSwitchType.Enabled && matrixSwitchControl.MatrixSwitch == null)
                    matrixSwitchControl.MatrixSwitch = new MatrixSwitch();
            }
            else if (CROSS_POINT_SWITCH.Equals(cmbSwitchType.SelectedItem))
            {
                Text = CROSS_POINT_SWITCH;
                crossPointSwitchControl.Enabled = crossPointSwitchControl.Visible = true;
                if (cmbSwitchType.Enabled && crossPointSwitchControl.CrossPointSwitch == null)
                    crossPointSwitchControl.CrossPointSwitch = new CrossPointSwitch();
            }
        }
    }
}