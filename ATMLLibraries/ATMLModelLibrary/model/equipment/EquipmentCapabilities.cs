/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATMLModelLibrary.model.equipment
{
    public class EquipmentCapabilities
    {
        private string _uuid;
        private ICollection<EquipmentCapability> _capabilities; 

        public string Uuid
        {
            get { return _uuid; }
            set { _uuid = value; }
        }

        public ICollection<EquipmentCapability> Capabilities
        {
            get { return _capabilities; }
            set { _capabilities = value; }
        }
    }

    public class EquipmentCapability
    {
        private string _uuid;
        private string _name;
        private ICollection<EquipmentCapabilityAttribute> _attributes;

        public ICollection<EquipmentCapabilityAttribute> Attributes
        {
            get { return _attributes; }
            set { _attributes = value; }
        }

        public string Uuid
        {
            get { return _uuid; }
            set { _uuid = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }

    public class EquipmentCapabilityAttribute
    {
        private double _lowValue;
        private double _highValue;
        private string _lowUnit;
        private string _highUnit;
        private string _name;

        public double MergeLowValues( double lowValue )
        {
            _lowValue = Math.Min( _lowValue, lowValue );
            return _lowValue;
        }

        public double MergeHighValues(double highValue)
        {
            _highValue = Math.Min(_highValue, highValue);
            return _highValue;
        }

    }
}
