/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.ComponentModel;
using System.Linq;
using ATMLCommonLibrary.forms;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.trigger
{
    public partial class TriggerPropertyForm : ATMLForm
    {
        /*
            [System.Xml.Serialization.XmlIncludeAttribute(typeof(LANTriggerPropertyGroup))]
            [System.Xml.Serialization.XmlIncludeAttribute(typeof(SoftwareTriggerPropertyGroup))]
            [System.Xml.Serialization.XmlIncludeAttribute(typeof(DigitalTriggerPropertyGroup))]
            [System.Xml.Serialization.XmlIncludeAttribute(typeof(AnalogTriggerPropertyGroup))]
        */

        private enum enumPropertTypes
        {
            Analog,
            Digital,
            LAN,
            Software
        }

        private bool _newProperty = true;
        private TriggerPropertyGroup _property;

        public TriggerPropertyForm()
        {
            InitializeComponent();
            cmbEdgeDetection.Items.AddRange( Enum.GetNames(typeof (DigitalEdge)));
            cmbLevelDetection.Items.AddRange(Enum.GetNames(typeof(DigitalLevel)));
            cmbPulseUnits.Items.AddRange(Enum.GetNames(typeof(PulseUnits)));
            cmbLevelUnits.Items.AddRange(Enum.GetNames(typeof(LevelUnits)));
            ResetComboBoxes();
            gbAnalogTrigger.Enabled = false;
            gbDigitalTrigger.Enabled = false;
            Validating += TriggerPropertyForm_Validating;
        }

        public TriggerPropertyGroup Property
        {
            get
            {
                ControlsToData();
                return _property;
            }
            set
            {
                _property = value;
                DataToControls();
            }
        }

        private void TriggerPropertyForm_Validating(object sender, CancelEventArgs e)
        {
        }

        private void ResetComboBoxes()
        {
            cmbEdgeDetection.SelectedIndex = -1;
            cmbLevelDetection.SelectedIndex = -1;
            cmbPulseUnits.SelectedIndex = -1;
            cmbLevelUnits.SelectedIndex = -1;
        }

        protected void DataToControls()
        {
            if (_property != null)
            {
                _newProperty = false;
                edtName.Value = _property.name;
                edtDescription.Value = _property.Description;
                if (_property is SoftwareTriggerPropertyGroup)
                {
                    cmbPropertyType.SelectedIndex = (int)enumPropertTypes.Software;
                }
                else if (_property is LANTriggerPropertyGroup)
                {
                    cmbPropertyType.SelectedIndex = (int)enumPropertTypes.LAN;
                }
                else if (_property is DigitalTriggerPropertyGroup)
                {
                    cmbPropertyType.SelectedIndex = (int)enumPropertTypes.Digital; ;
                    var dpg = (DigitalTriggerPropertyGroup) _property;
                    if (dpg.MinPulseWidth == null)
                        dpg.MinPulseWidth = new MinPulseWidthType();
                    if (dpg.Detection == null)
                        dpg.Detection = new DetectionType();
                    edtPulseValue.Value = dpg.MinPulseWidth.value;
                    cmbPulseUnits.SelectedItem = Enum.GetName(typeof(PulseUnits), dpg.MinPulseWidth.units);
                    if (dpg.Detection.edgeDetectionSpecified)
                        cmbEdgeDetection.SelectedItem = Enum.GetName(typeof(DigitalEdge), dpg.Detection.edgeDetection);
                    else
                        cmbEdgeDetection.SelectedIndex = -1;

                    if (dpg.Detection.levelDetectionSpecified)
                        cmbLevelDetection.SelectedItem =Enum.GetName(typeof(DigitalLevel), dpg.Detection.levelDetection );
                    else
                        cmbLevelDetection.SelectedIndex = -1;
                }
                else if (_property is AnalogTriggerPropertyGroup)
                {
                    cmbPropertyType.SelectedIndex = (int)enumPropertTypes.Analog; ;
                    var apg = (AnalogTriggerPropertyGroup) _property;
                    if (apg.Level == null)
                        apg.Level = new LevelType();

                    edtLevelTypeValue.Value = apg.Level.value;
                    edtNumberOfBits.Value = apg.Level.numberOfBits;
                    cmbLevelUnits.SelectedItem = Enum.GetName(typeof(LevelUnits), apg.Level.units );
                }
                SetControlStates();
            }
        }

        protected void ControlsToData()
        {
            if (_property != null)
            {
                _property.name = edtName.GetValue<string>();
                _property.Description = edtDescription.GetValue<string>();

                if (_property is DigitalTriggerPropertyGroup)
                {
                    var dpg = (DigitalTriggerPropertyGroup) _property;
                    if (dpg.MinPulseWidth == null)
                        dpg.MinPulseWidth = new MinPulseWidthType();
                    if (dpg.Detection == null)
                        dpg.Detection = new DetectionType();
                    dpg.MinPulseWidth.value = edtPulseValue.GetValue<double>();
                    dpg.MinPulseWidth.units = (PulseUnits)Enum.Parse(typeof(PulseUnits), (string)cmbPulseUnits.SelectedItem );
                    if (cmbEdgeDetection.SelectedIndex != -1)
                        dpg.Detection.edgeDetection =
                            (DigitalEdge) Enum.Parse(typeof (DigitalEdge), (string) cmbEdgeDetection.SelectedItem);
                    else
                        dpg.Detection.edgeDetectionSpecified = false;
                    if (cmbLevelDetection.SelectedIndex != -1)
                        dpg.Detection.levelDetection =
                            (DigitalLevel) Enum.Parse(typeof (DigitalLevel), (string) cmbLevelDetection.SelectedItem);
                    else
                        dpg.Detection.levelDetectionSpecified = false;
                }
                else if (_property is AnalogTriggerPropertyGroup)
                {
                    var apg = (AnalogTriggerPropertyGroup) _property;
                    if (apg.Level == null)
                        apg.Level = new LevelType();

                    apg.Level.value = edtLevelTypeValue.GetValue<double>();
                    apg.Level.numberOfBits = edtNumberOfBits.GetValue<int>();
                    if (cmbLevelUnits.SelectedItem != null)
                        apg.Level.units = (LevelUnits)Enum.Parse(typeof(LevelUnits), (string)cmbLevelUnits.SelectedItem);
                }
            }
        }

        private void cmbPropertyType_SelectedIndexChanged(object sender, EventArgs e)
        {
            gbAnalogTrigger.Enabled = false;
            gbDigitalTrigger.Enabled = false;
            if (cmbPropertyType.SelectedItem != null && (_property == null || _newProperty))
            {
                ResetComboBoxes();
                SetControlStates();

                switch (cmbPropertyType.SelectedIndex)
                {
                    case (int) enumPropertTypes.Digital:
                        _property = new DigitalTriggerPropertyGroup();
                        break;
                    case (int) enumPropertTypes.Analog:
                        _property = new AnalogTriggerPropertyGroup();
                        break;
                    case (int) enumPropertTypes.LAN:
                        _property = new LANTriggerPropertyGroup();
                        break;
                    case (int) enumPropertTypes.Software:
                        _property = new SoftwareTriggerPropertyGroup();
                        break;
                }
            }
        }

        private void SetControlStates()
        {
            gbDigitalTrigger.Enabled = cmbPropertyType.SelectedIndex == (int)enumPropertTypes.Digital;
            gbAnalogTrigger.Enabled = cmbPropertyType.SelectedIndex == (int)enumPropertTypes.Analog;
        }

        private void helpLabel9_Click(object sender, EventArgs e)
        {
        }
    }
}