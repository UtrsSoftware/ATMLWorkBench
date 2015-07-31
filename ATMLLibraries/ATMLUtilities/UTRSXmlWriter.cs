/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.IO;
using System.Xml;

namespace ATMLUtilitiesLibrary
{
    public class UTRSXmlWriter : XmlTextWriter
    {
        public UTRSXmlWriter( StringWriter writer ) : base( writer )
        {
            Formatting = Formatting.Indented;
            Indentation = 5;
        }


        public void WriteElementSafeString( String name, Object value )
        {
            base.WriteElementString( name, value == null ? "" : value.ToString() );
        }

        public void WriteAttributeSafeString( String name, Object value )
        {
            base.WriteAttributeString( name, value == null ? "" : value.ToString() );
        }
    }
}