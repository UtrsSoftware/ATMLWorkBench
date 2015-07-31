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
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.forms
{
    public partial class SpecificationForm : ATMLForm
    {

        const int CHARACTERISTIC         = 0;
        const int FEATURE                = 1;
        const int GUARANTEED             = 2;
        const int NOMINAL                = 3;
        const int SPECIFICATION_GROUP    = 4;
        const int TYPICAL                = 5;



        private bool isNewSpecification = true;
        private object _specificaionItem;
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object SpecificaionItem
        {
            get { ControlsToData();  return _specificaionItem; }
            set { _specificaionItem = value; DataToControls(); }
        }

        private void ControlsToData()
        {
            if (_specificaionItem is SpecificationGroup)
                _specificaionItem = specificationGroupControl.SpecificationGroup;
            else
                _specificaionItem = specificationControl.Specification;
        }

        private void DataToControls()
        {
            if (_specificaionItem != null)
            {
                isNewSpecification = false;
                cmbSpecificationType.Enabled = false;
                specificationGroupControl.Visible = false;
                specificationControl.Visible = true;
                if (_specificaionItem is Feature)
                    cmbSpecificationType.SelectedIndex = FEATURE;
                else if (_specificaionItem is Typical)
                    cmbSpecificationType.SelectedIndex = TYPICAL;
                else if (_specificaionItem is Nominal)
                    cmbSpecificationType.SelectedIndex = NOMINAL;
                else if (_specificaionItem is Characteristic)
                    cmbSpecificationType.SelectedIndex = CHARACTERISTIC;
                else if (_specificaionItem is Guaranteed)
                    cmbSpecificationType.SelectedIndex = GUARANTEED;
                else if (_specificaionItem is SpecificationGroup)
                    cmbSpecificationType.SelectedIndex = SPECIFICATION_GROUP;
                SetControlStates();

                if( _specificaionItem is SpecificationGroup )
                    specificationGroupControl.SpecificationGroup = _specificaionItem as SpecificationGroup;
                else if (_specificaionItem is Specification)
                    specificationControl.Specification = _specificaionItem as Specification;
            }
            
        }

        public SpecificationForm()
        {
            InitializeComponent();
            SetControlStates();
        }

        private void SetControlStates()
        {
            specificationGroupControl.Visible = false;
            specificationControl.Visible = false;
            if (_specificaionItem is Feature)
                specificationControl.Visible = true;
            else if (_specificaionItem is Typical)
                specificationControl.Visible = true;
            else if (_specificaionItem is Nominal)
                specificationControl.Visible = true;
            else if (_specificaionItem is Characteristic)
                specificationControl.Visible = true;
            else if (_specificaionItem is Guaranteed)
                specificationControl.Visible = true;
            else if (_specificaionItem is SpecificationGroup)
                specificationGroupControl.Visible = true;
            
        }

        private void cmbSpecificationType_SelectedIndexChanged(object sender, EventArgs e)
        {
            String text = cmbSpecificationType.SelectedItem as String;
            if (isNewSpecification)
            {
                if ("Nominal".Equals(text))
                    _specificaionItem = new Nominal();
                else if ("Feature".Equals(text))
                    _specificaionItem = new Feature();
                else if ("Characteristic".Equals(text))
                    _specificaionItem = new Characteristic();
                else if ("Guaranteed".Equals(text))
                    _specificaionItem = new Guaranteed();
                else if ("Typical".Equals(text))
                    _specificaionItem = new Typical();
                else if ("Specification Group".Equals(text))
                    _specificaionItem = new SpecificationGroup();
            }
            if( _specificaionItem is Specification )
                specificationControl.Specification = _specificaionItem as Specification;
            else
                specificationGroupControl.SpecificationGroup = _specificaionItem as SpecificationGroup;
            SetControlStates();
        }
    }
}
