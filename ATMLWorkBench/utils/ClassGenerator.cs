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
using System.IO;
using System.Xml;
//using xstream;
//using xstream.Converters;
//using xstream.Utilities;

namespace ATMLWorkBench.utils
{
    public class ClassGenerator
    {
        public void GenerateClassFiles( String inputFileName, String outputDirectory )
        {
            FileStream fs = new FileStream(inputFileName, FileMode.Open, FileAccess.Read);

            int read = 0;
            byte[] bytes = new byte[fs.Length];
            int numBytesToRead = (int)fs.Length;
            int numBytesRead = 0;
            while( numBytesToRead > 0 )
            {
                // Read may return anything from 0 to numBytesToRead.
                int n = fs.Read(bytes, numBytesRead, numBytesToRead);

                // Break when the end of the file is reached.
                if( n == 0 )
                    break;

                numBytesRead += n;
                numBytesToRead -= n;
            }

            String s = Encoding.UTF8.GetString(bytes);
            //XStream xs = new XStream();
            //Object obj = xs.FromXml(s);
            
            using( XmlTextReader reader = new XmlTextReader( inputFileName ) )
            {
                //System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(UTRSATMLWorkBench.atml.));


                XmlDocument document = new XmlDocument();
                document.Load( reader );

                XmlNodeList simpleTypes = document.GetElementsByTagName("xs:simpleType");
                foreach( XmlNode node in simpleTypes )
                {
                    XmlAttributeCollection attributes = node.Attributes;
                    XmlAttribute name = attributes["name"];
                    if( name != null )
                    {
                        //Console.WriteLine(name.Name + ":" + name.Value);
                        processSimpleType(node);
                    }
                 
                }
            }
        }

        private XmlNode getChild(String name, XmlNode node)
        {
            XmlNode child = null;
            foreach( XmlNode c in node.ChildNodes )
            {
                if( c.Name.Equals( name ) )
                {
                    child = c;
                    break;
                }
            }
            return child;
        }

        private void processSimpleType(XmlNode simpleTypeNode)
        {
            ClassBuilder cb = new ClassBuilder();
            XmlNodeList children = simpleTypeNode.ChildNodes;
            foreach( XmlNode child in children )
            {
                cb.Name = simpleTypeNode.Attributes["name"].Value.Replace( "cs:", "");
                if( child.Name.Equals("xs:annotation") )
                {
                    XmlNode docmentation = getChild("xs:documentation", child);
                    if( docmentation != null )
                        cb.Description = docmentation.Value;

                }
                else if( child.Name.Equals("xs:restriction") )
                {
                    XmlAttribute base_ = child.Attributes["base"];
                    if( base_ != null )
                        cb.Base_ = base_.Value.Replace("cs:", ""); 

                    XmlNode pattern = getChild("xs:pattern", child);
                    if( pattern != null )
                        cb.RegExp = pattern.Attributes["value"].Value;

                }
                else if( child.Name.Equals("xs:list") )
                {
                }
                else if( child.Name.Equals("xs:union") )
                {
                    XmlNodeList gcs = child.ChildNodes;
                    foreach( XmlNode gc in gcs )
                    {
                        if( gc.Name.Equals("xs:simpleType") )
                            processSimpleType(gc);
                    }
                }
                else if( child.Name.Equals("xs:enumeration") )
                {
                    cb.addEnumeration( child.Attributes["value"].Value );
                }
                else
                {
                }

            }

            Console.WriteLine(cb.writeClass());
        }
    }

    class ClassBuilder
    {
        String name;

        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        String base_;

        public String Base_
        {
            get { return base_; }
            set { base_ = value; }
        }
        String regExp;

        public String RegExp
        {
            get { return regExp; }
            set { regExp = value; }
        }

        String description;

        public String Description
        {
            get { return description; }
            set { description = value; }
        }

        List<String> enumerations = new List<string>();
        public List<String> Enumerations
        {
            get { return enumerations; }
            set { enumerations = value; }
        }
        public void addEnumeration(String value)
        {
            enumerations.Add(value);
        }

        public String writeClass()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append( "using System;\r\n" );
            sb.Append( "using System.Collections.Generic;\r\n" );
            sb.Append( "using System.Linq;\r\n" );
            sb.Append( "using System.Text;\r\n" );
            sb.Append( "using System.IO;\r\n" );
            sb.Append( "using System.Xml;\r\n" );
            sb.Append( "namespace UTRSATMLWorkBench.utils\r\n" );
            sb.Append( "{\r\n" );
            sb.Append("\t/*\r\n");
            sb.Append("\t").Append( Description ).Append( "\r\n" );
            sb.Append("\t*/\r\n");
            sb.Append("\tpublic class ").Append(name);
            if( base_ != null )
                sb.Append(" : ").Append(base_);
            sb.Append("\r\n");
            sb.Append("\t{\r\n");
            sb.Append("\t\tprivate String regularExpressionPattern =\"").Append( RegExp ).Append( "\";\r\n" );

            if( enumerations.Count > 0 )
            {
                sb.Append("\t\tpublic enum Enumeration\r\n\t\t\r\n" );
                foreach( String value in enumerations )
                {
                    sb.Append("\t\t\t").Append( value ).Append( ", \r\n" );
                }
                sb.Length = sb.Length - 4;
                sb.Append("\r\n\t\t}\r\n");
                
            }

            sb.Append("\t}\r\n");
            sb.Append("}\r\n");
            return sb.ToString();
        }

    }
}
 