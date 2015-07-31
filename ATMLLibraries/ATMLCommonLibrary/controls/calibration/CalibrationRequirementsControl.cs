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
using System.Windows.Forms;
using System.Xml;
using ATMLManagerLibrary.managers;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.calibration
{
    public partial class CalibrationRequirementsControl : ATMLControl
    {
        private HardwareItemDescriptionCalibrationRequirement _hardwareItemDescriptionCalibrationRequirement;

        public CalibrationRequirementsControl()
        {
            InitializeComponent();
            InitControls();
            supportEquipmentTextCollection.AddColumn("Support Equipment", "support_equipment");
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public HardwareItemDescriptionCalibrationRequirement HardwareItemDescriptionCalibrationRequirement
        {
            get
            {
                ControlsToData();
                return _hardwareItemDescriptionCalibrationRequirement;
            }
            set
            {
                _hardwareItemDescriptionCalibrationRequirement = value;
                DataToControls();
            }
        }

        private void DataToControls()
        {
            if (_hardwareItemDescriptionCalibrationRequirement != null)
            {
                //TimeSpan span = new TimeSpan();  return XmlConvert.ToString(_validThroughField); _validThroughField= XmlConvert.ToTimeSpan(value);
                try
                {
                    awbTimeSpan.TimeSpan =
                        XmlConvert.ToTimeSpan(_hardwareItemDescriptionCalibrationRequirement.frequency);
                }
                catch (Exception e)
                {
                    LogManager.Error(e, "The Calibration Requirement has an invalid duration value ({0})",
                        _hardwareItemDescriptionCalibrationRequirement.frequency);
                }
                procedureDocument.Documents = _hardwareItemDescriptionCalibrationRequirement.Procedure;

                foreach (string equip in _hardwareItemDescriptionCalibrationRequirement.SupportEquipment)
                {
                    DataGridViewRow row = supportEquipmentTextCollection.AddRow();
                    supportEquipmentTextCollection.AddColumnData(row, "support_equipment", equip);
                }
            }
        }

        private void ControlsToData()
        {
            if (_hardwareItemDescriptionCalibrationRequirement == null)
                _hardwareItemDescriptionCalibrationRequirement = new HardwareItemDescriptionCalibrationRequirement();
            _hardwareItemDescriptionCalibrationRequirement.frequency = XmlConvert.ToString(awbTimeSpan.TimeSpan);
            _hardwareItemDescriptionCalibrationRequirement.Procedure = procedureDocument.Documents;
            _hardwareItemDescriptionCalibrationRequirement.SupportEquipment = new List<string>();
            List<List<string>> table = supportEquipmentTextCollection.GetTable();
            foreach (var tableRow in table)
            {
                foreach (string rowColumn in tableRow)
                {
                    _hardwareItemDescriptionCalibrationRequirement.SupportEquipment.Add(rowColumn);
                }
            }
        }
    }
}