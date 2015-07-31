/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.ComponentModel;
using System.Xml;
using ATMLManagerLibrary.managers;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.operational
{
    public partial class OperationalRequirementsControl : ATMLControl
    {
        private OperationalRequirements _operationalReq;

        public OperationalRequirementsControl()
        {
            InitializeComponent();
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public OperationalRequirements OperationalRequirements
        {
            get
            {
                ControlsToData();
                return _operationalReq;
            }
            set
            {
                _operationalReq = value;
                DataToControls();
            }
        }

        private void DataToControls()
        {
            if (_operationalReq != null)
            {
                namedValueListControl1.NamedValues = _operationalReq.OperationalRequirement;
                try
                {
                    warmUpTimeSpan.TimeSpan = XmlConvert.ToTimeSpan(_operationalReq.warmUpTime);
                }
                catch (Exception e)
                {
                    LogManager.Error(e, "Operational Requirement has an invalid Warmup Time Duration ({0})",
                        _operationalReq.warmUpTime);
                }
            }
        }

        private void ControlsToData()
        {
            if (HasData())
            {
                if (_operationalReq == null)
                    _operationalReq = new OperationalRequirements();
                if (_operationalReq != null)
                {
                    _operationalReq.OperationalRequirement = namedValueListControl1.NamedValues;
                    _operationalReq.warmUpTime = XmlConvert.ToString(warmUpTimeSpan.TimeSpan);
                }
            }
            else
            {
                _operationalReq = null;
            }
        }

        private bool HasData()
        {
            return (namedValueListControl1.NamedValues != null && namedValueListControl1.NamedValues.Count > 0)
                   || (warmUpTimeSpan.TimeSpan.TotalMilliseconds > 0 );
        }
    }
}