/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System.Xml;
using System.Xml.Serialization;

namespace ATMLModelLibrary.model.signal.basic
{

    public partial class Signal
    {
        public string GetSignalNameSpace()
        {
            string nameSpace = null;
            if (_anyAttr != null)
            {
                foreach (XmlAttribute xmlAttribute in _anyAttr)
                {
                    if ("xsi:schemaLocation".Equals(xmlAttribute.Name) && xmlAttribute.Value != null)
                    {
                        string[] parts = xmlAttribute.Value.Split( ' ' );
                        if (parts.Length > 0)
                            nameSpace = parts[0];
                        break;
                    }
                }
            }
            return nameSpace;
        }
    }


    public partial class SignalFunctionType
    {
        private string _value;

        [XmlIgnore]
        public string Value
        {
            get { return this._value; }
            set { _value = value; }
        }
    }
}
