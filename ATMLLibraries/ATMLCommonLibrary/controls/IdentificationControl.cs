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
using ATMLModelLibrary.model.common;

namespace ATMLCommonLibrary.controls
{
    public partial class IdentificationControl : ATMLControl
    {
        private ItemDescriptionIdentification _identification;

        public IdentificationControl()
        {
            InitializeComponent();
            requiredModelNameValidator.IsEnabled = false;
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ItemDescriptionIdentification Identification
        {
            get
            {
                ControlsToData();
                return _identification;
            }
            set
            {
                _identification = value;
                DataToControls();
            }
        }

        public void DataToControls()
        {
            if (_identification != null)
            {
                edtIdModelName.Value = _identification.ModelName;
                edtIdVersion.Value = _identification.Version;
                edtDesignator.Value = _identification.designator;
                indentificationNumbersListControl.IdentificationNumbers = _identification.IdentificationNumbers;
                manufacturerListControl.Manufacturers = _identification.Manufacturers;
            }
            SetValidationState();
        }

        public void ControlsToData()
        {
            SetValidationState();
            if (!string.IsNullOrWhiteSpace(edtIdModelName.Text))
            {
                
                if (_identification == null)
                    _identification = new ItemDescriptionIdentification();

                _identification.ModelName = edtIdModelName.GetValue<string>();
                _identification.Version = edtIdVersion.GetValue<string>();
                _identification.designator = edtDesignator.GetValue<string>();
                _identification.IdentificationNumbers = indentificationNumbersListControl.IdentificationNumbers;
                _identification.Manufacturers = manufacturerListControl.Manufacturers;
                //TODO: Address when/if we handle extensions
                _identification.Extension = null;
            }
            else
            {
                _identification = null;
            }
        }

        private void manufacturerListControl_Load(object sender, EventArgs e)
        {
        }

        private void indentificationNumbersListControl_Load(object sender, EventArgs e)
        {
        }

        private void edtIdModelName_TextChanged(object sender, EventArgs e)
        {
            SetValidationState();
        }

        private void SetValidationState()
        {
            requiredModelNameValidator.IsEnabled = true;
//                                                    (!string.IsNullOrWhiteSpace(edtIdModelName.Text)
//                                                    || !string.IsNullOrWhiteSpace(edtDesignator.Text)
//                                                    || !string.IsNullOrWhiteSpace(edtIdVersion.Text)
//                                                    ||
//                                                    (manufacturerListControl.Manufacturers != null &&
//                                                     manufacturerListControl.Manufacturers.Count > 0)
//                                                    ||
//                                                    (indentificationNumbersListControl.IdentificationNumbers != null &&
//                                                     indentificationNumbersListControl.IdentificationNumbers.Count > 0));
        }

        public override bool ValidateChildren()
        {
            SetValidationState();
            return base.ValidateChildren();
        }

        public override bool ValidateChildren(ValidationConstraints validationConstraints)
        {
            SetValidationState();
            return base.ValidateChildren(validationConstraints);
        }
    }
}