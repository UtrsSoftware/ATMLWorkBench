/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System.ComponentModel;
using ATMLModelLibrary.model.common;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.hardware
{
    public partial class FacilitiesRequirementsControl : ATMLControl
    {
        private FacilitiesRequirements _facilitiesRequirements;

        public FacilitiesRequirementsControl()
        {
            InitializeComponent();
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public FacilitiesRequirements FacilitiesRequirements
        {
            get
            {
                ControlsToData();
                return _facilitiesRequirements;
            }
            set
            {
                _facilitiesRequirements = value;
                DataToControls();
            }
        }

        private void DataToControls()
        {
            if (_facilitiesRequirements != null)
            {
                edtCooling.Value = _facilitiesRequirements.Cooling;
                edtHydraulic.Value = _facilitiesRequirements.Hydraulic;
                edtPneumatic.Value = _facilitiesRequirements.Pneumatic;
                documentListControl1.Documents = _facilitiesRequirements.FacilityRequirementsDocuments;
                if (_facilitiesRequirements.FacilitiesInterface != null && _facilitiesRequirements.FacilitiesInterface.Ports != null)
                    portListControl.Ports = _facilitiesRequirements.FacilitiesInterface.Ports;
            }
        }

        private void ControlsToData()
        {
            if (_facilitiesRequirements == null)
                _facilitiesRequirements = new FacilitiesRequirements();

            _facilitiesRequirements.Cooling = edtHydraulic.GetValue<string>();
            _facilitiesRequirements.Hydraulic = edtHydraulic.GetValue<string>();
            _facilitiesRequirements.Pneumatic = edtPneumatic.GetValue<string>();
            _facilitiesRequirements.FacilityRequirementsDocuments = documentListControl1.Documents;

            if (portListControl.Ports == null)
                _facilitiesRequirements.FacilitiesInterface = null;
            else
            {
                if( _facilitiesRequirements.FacilitiesInterface == null )
                    _facilitiesRequirements.FacilitiesInterface = new Interface();
                _facilitiesRequirements.FacilitiesInterface.Ports = portListControl.Ports;
            }


            if (string.IsNullOrEmpty( _facilitiesRequirements.Cooling ) &&
                string.IsNullOrEmpty( _facilitiesRequirements.Hydraulic ) &&
                string.IsNullOrEmpty( _facilitiesRequirements.Pneumatic ) &&
                ( _facilitiesRequirements.FacilitiesInterface == null
                  || _facilitiesRequirements.FacilitiesInterface.Ports == null
                  || _facilitiesRequirements.FacilitiesInterface.Ports.Count == 0 ) &&
                ( _facilitiesRequirements.FacilityRequirementsDocuments == null
                  || _facilitiesRequirements.FacilityRequirementsDocuments.Count == 0 ))
            {
                _facilitiesRequirements = null;
            }
            
        }
    }
}