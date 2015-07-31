/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Xsl;

namespace ATMLUtilitiesLibrary
{
    public class XmlUtils
    {
        public static XmlElement Object2XmlElement( Object obj )
        {
            XmlElement element = null;
            if (obj != null)
            {
                var doc = new XmlDocument();
                string xml = GetXmlFromObject( obj );
                var serializer = new XmlSerializer( obj.GetType() );
                doc.LoadXml( xml );
                element = (XmlElement) doc.GetElementsByTagName( obj.GetType().Name ).Item( 0 );
            }
            return element;
        }


        public static string SerializeObject( Object toSerialize )
        {
            var xmlSerializer = new XmlSerializer( toSerialize.GetType() );
            using (var memoryStream = new MemoryStream())
            {
                using (var streamWriter = new StreamWriter( memoryStream, Encoding.UTF8 ))
                {
                    xmlSerializer.Serialize( streamWriter, toSerialize );
                    memoryStream.Seek( 0, SeekOrigin.Begin );
                    var streamReader = new StreamReader( memoryStream, Encoding.UTF8 );
                    return streamReader.ReadToEnd();
                }
            }
        }


        public static object DeserializeObject( object obj, string input )
        {
            if (input == null) throw new ArgumentNullException( "input" );
            if (obj == null) throw new ArgumentNullException( "obj" );
            StringReader stringReader = null;
            try
            {
                var xmlSerializer = new XmlSerializer( obj.GetType() );
                stringReader = new StringReader( input );
                return ( xmlSerializer.Deserialize( XmlReader.Create( stringReader ) ) );
            }
            finally
            {
                if (( stringReader != null ))
                {
                    stringReader.Dispose();
                }
            }
        }

        public static T DeserializeObject<T>( string input )
        {
            if (input == null) throw new ArgumentNullException( "input" );
            StringReader stringReader = null;
            try
            {
                var xmlSerializer = new XmlSerializer( typeof (T) );
                stringReader = new StringReader( input );
                return (T) ( xmlSerializer.Deserialize( XmlReader.Create( stringReader ) ) );
            }
            finally
            {
                if (( stringReader != null ))
                {
                    stringReader.Dispose();
                }
            }
        }


        public static String GetXmlFromObject( Object obj )
        {
            String xml = null;
            var doc = new XmlDocument();

            StreamReader streamReader = null;
            MemoryStream memoryStream = null;
            try
            {
                if (obj != null)
                {
                    var serializer = new XmlSerializer( obj.GetType() );
                    serializer.UnknownAttribute += delegate { int i = 0; };
                    serializer.UnknownElement += delegate { int i = 0; };
                    serializer.UnknownNode += delegate { int i = 0; };
                    serializer.UnreferencedObject += delegate { int i = 0; };
                    memoryStream = new MemoryStream();
                    serializer.Serialize( memoryStream, obj );
                    memoryStream.Seek( 0, SeekOrigin.Begin );
                    streamReader = new StreamReader( memoryStream );
                    xml = streamReader.ReadToEnd();
                }
            }
            finally
            {
                if (( streamReader != null ))
                {
                    streamReader.Dispose();
                }
                if (( memoryStream != null ))
                {
                    memoryStream.Dispose();
                }
            }
            return xml;
        }

        public static Dictionary<String, Dictionary<String, String>> ExtractElementsWithAttributes( XmlDocument document )
        {
            var map = new Dictionary<string, Dictionary<string, string>>();
            ProcessNode( map, document );

            return map;
        }

        private static void ProcessNode( Dictionary<String, Dictionary<String, String>> map, XmlNode parentNode )
        {
            XmlNodeList children = parentNode.ChildNodes;
            foreach (XmlNode node in children)
            {
                if (node.Attributes.Count > 0)
                {
                    var atMap = new Dictionary<string, string>();
                    foreach (XmlAttribute attr in node.Attributes)
                    {
                        atMap.Add( attr.LocalName, attr.Value );
                    }
                    map.Add( node.LocalName, atMap );
                }
                ProcessNode( map, node );
            }
        }

        public static XmlDocument XPath2XmlDocument( String path )
        {
            var document = new XmlDocument();
            String[] parts = path.Replace( "\n", "" )
                                 .Replace( "\t", "" )
                                 .Replace( "\r", "" )
                                 .Replace( "@", "" )
                                 .Split( '/' );
            XmlElement lastElement = null;
            XmlElement element = null;
            foreach (String part in parts)
            {
                if (!String.IsNullOrEmpty( part ))
                {
                    String attribute = null;
                    String name = null;
                    int idx = part.IndexOf( '[' );
                    if (idx != -1)
                    {
                        attribute = part.Substring( idx );
                        name = part.Substring( 0, idx );
                        attribute = attribute.Replace( "[", "" )
                                             .Replace( "]", "" )
                                             .Replace( "\"", "" );
                    }
                    else
                    {
                        name = part;
                    }
                    element = document.CreateElement( name );
                    if (attribute != null)
                    {
                        int aidx = attribute.IndexOf( "=" );
                        XmlAttribute attr = document.CreateAttribute( attribute.Substring( 0, aidx ) );
                        attr.Value = attribute.Substring( aidx + 1 );
                        element.Attributes.Append( attr );
                    }
                    if (lastElement == null)
                        document.AppendChild( element );
                    else
                        lastElement.AppendChild( element );
                    lastElement = element;
                }
            }
            return document;
        }

        public static string Transform( byte[] xslFile, byte[] xmlFile )
        {
            using (var xslStream = new MemoryStream( xslFile ))
            {
                using (var xmlStream = new MemoryStream( xmlFile ))
                {
                    return Transform( xslStream, xmlStream );
                }
            }
        }


        public static string Transform( Stream xslFile, Stream xmlFile )
        {
            String html;
            var xslTransform = new XslCompiledTransform();
            using (XmlReader xslt = XmlReader.Create( xslFile ))
            {
                xslTransform.Load( xslt );
            }

            using (var writer = new StringWriter())
            {
                using (XmlReader input = XmlReader.Create( xmlFile ))
                {
                    xslTransform.Transform( input, null, writer );
                    html = writer.ToString();
                }
            }
            return html;
        }
    }
}