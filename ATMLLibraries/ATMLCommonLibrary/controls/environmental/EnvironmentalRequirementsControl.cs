/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System.ComponentModel;
using ATMLModelLibrary.model.common;

namespace ATMLCommonLibrary.controls.environmental
{
    public partial class EnvironmentalRequirementsControl : ATMLControl
    {
        private EnvironmentalRequirements _environmentalRequirements;

        public EnvironmentalRequirementsControl()
        {
            InitializeComponent();
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public EnvironmentalRequirements EnvironmentalRequirements
        {
            get
            {
                ControlsToData();
                return _environmentalRequirements;
            }
            set
            {
                _environmentalRequirements = value;
                DataToControls();
            }
        }

        private void DataToControls()
        {
            if (_environmentalRequirements != null)
            {
                storageElements.EnvironmentalElements = _environmentalRequirements.StorageTransport;
                operationElements.EnvironmentalElements = _environmentalRequirements.Operation;
            }
        }

        private void ControlsToData()
        {
            if (_environmentalRequirements == null)
                _environmentalRequirements = new EnvironmentalRequirements();
            _environmentalRequirements.Operation = operationElements.EnvironmentalElements;
            _environmentalRequirements.StorageTransport = storageElements.EnvironmentalElements;
            if (_environmentalRequirements.Operation == null && _environmentalRequirements.StorageTransport == null)
                _environmentalRequirements = null;
        }
    }
}