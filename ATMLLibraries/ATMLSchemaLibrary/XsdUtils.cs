/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;
using ATMLSchemaLibrary.managers;

namespace ATMLSchemaLibrary
{
    public class XsdUtils
    {
        public static XmlSchema ReadSchema(String fileName)
        {
            XmlSchema myschema = null; 
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.XmlResolver = null;
            settings.ProhibitDtd = false;
            settings.DtdProcessing = DtdProcessing.Ignore;
            XmlReader reader = XmlReader.Create(fileName, settings);
            try
            {
                myschema = XmlSchema.Read(reader, ValidationCallBack);
                XmlSchemaSet schemaSet = new XmlSchemaSet();
                schemaSet.ValidationEventHandler += new ValidationEventHandler(ValidationCallBack);
                schemaSet.Add(myschema.TargetNamespace, (fileName));
                schemaSet.Compile();
                //-----------------------------------------------------//
                //--- Do this to get all supporting schemas as well ---//
                //-----------------------------------------------------//
                //foreach (XmlSchema schema in schemaSet.Schemas())
                //{
                //    myschema = schema;
                //}
            }
            catch (Exception e)
            {
                MessageBox.Show("Failed to open file: " + fileName);
            }
            finally
            {
                reader.Close();
            }
            return myschema;
        }


        public static XmlSchema ReadSchemaFromText(String text)
        {
            StringReader reader = new StringReader( text );
            XmlSchema myschema = null;
            try
            {
                myschema = XmlSchema.Read(reader, ValidationCallBack);
            }
            finally
            {
                reader.Close();
            }
            return myschema;
        }


        private static void ValidationCallBack(object sender, ValidationEventArgs args)
        {
            if (args.Severity == XmlSeverityType.Warning)
                Console.WriteLine("\tWarning: Matching schema not found.  No validation occurred." + args.Message);
            else
                Console.WriteLine("\tValidation error: " + args.Message);
        }


        public static List<XmlSchemaElement> extractElements(XmlSchema schema)
        {
            List<XmlSchemaElement> elements = new List<XmlSchemaElement>();
            foreach (object item in schema.Elements)
            {
                if (item is DictionaryEntry)
                {
                    DictionaryEntry entry = (DictionaryEntry)item;
                    XmlSchemaElement element = entry.Value as XmlSchemaElement;
                    if (element != null)
                    {
                        elements.Add(element);
                    }
                }
            }
            foreach (object item in schema.Items)
            {
                if (item is XmlSchemaElement)
                {
                    XmlSchemaElement element = item as XmlSchemaElement;
                    if( !elements.Exists(el => el == element ))
                        elements.Add(element);
                }
            }

            return elements;
        }


        public static List<XmlSchemaSimpleType> extractSimpleTypes(XmlSchema schema)
        {
            List<XmlSchemaSimpleType> simpleTypes = new List<XmlSchemaSimpleType>();
            foreach (object item in schema.Items)
            {
                if (item is XmlSchemaSimpleType)
                {
                    XmlSchemaSimpleType simpleType = (XmlSchemaSimpleType)item;
                    simpleTypes.Add(simpleType);
                }
            }
            return simpleTypes;
        }

        public static List<XmlSchemaComplexType> extractComplexTypes(XmlSchema schema)
        {
            List<XmlSchemaComplexType> complexTypes = new List<XmlSchemaComplexType>();
            foreach (object item in schema.Items)
            {
                if (item is XmlSchemaComplexType)
                {
                    XmlSchemaComplexType complexType = (XmlSchemaComplexType)item;
                    complexTypes.Add(complexType);
                }
            }
            return complexTypes;
        }

        public static List<XmlSchemaAttributeGroup> extractAttributeGroups(XmlSchema schema)
        {
            List<XmlSchemaAttributeGroup> list = new List<XmlSchemaAttributeGroup>();
            foreach (object item in schema.Items)
            {
                if (item is XmlSchemaAttributeGroup)
                {
                    XmlSchemaAttributeGroup group = (XmlSchemaAttributeGroup)item;
                    list.Add(group);
                }
            }
            return list;
        }

        public static List<XmlSchemaGroup> extractGroups(XmlSchema schema)
        {
            List<XmlSchemaGroup> list = new List<XmlSchemaGroup>();
            foreach (object item in schema.Items)
            {
                if (item is XmlSchemaGroup)
                {
                    XmlSchemaGroup group = (XmlSchemaGroup)item;
                    list.Add(group);
                }
            }
            return list;
        }

        public static bool findAttribute( String name, XmlSchemaComplexType complexType )
        {
            bool found = false;


            return found;
        }

        public static bool getAttributes( object item, List<XmlSchemaAttribute> attributes )
        {

            if( item is XmlSchemaComplexType )
            {
                XmlSchemaComplexType complexType = (XmlSchemaComplexType)item;
                foreach (object entry in complexType.AttributeUses)
                {
                    object o  = null;
                    if (entry is System.Collections.DictionaryEntry)
                    {
                        System.Collections.DictionaryEntry de = (System.Collections.DictionaryEntry)entry;
                        object key = de.Key;
                        object value = de.Value;
                        o = value;
                    }
                    if (o is XmlSchemaAttribute)
                        attributes.Add((XmlSchemaAttribute)o);
                    else if (o is XmlSchemaAttributeGroupRef)
                    {
                        XmlSchemaAttributeGroupRef groupRef = (XmlSchemaAttributeGroupRef)o;
                        XmlQualifiedName qname = groupRef.RefName;
                        if (qname != null)
                        {
                            XmlSchemaAttributeGroup group = null;
                            if (SchemaManager.GetAttributeGroup(qname.Namespace, qname.Name, out group))
                            {
                                foreach (object oo in group.Attributes)
                                {
                                    if (oo is XmlSchemaAttribute)
                                    {
                                        attributes.Add((XmlSchemaAttribute)oo);
                                    }
                                }
                            }
                        }
                    }
                }

                if (complexType.ContentModel != null && complexType.ContentModel.Content is XmlSchemaComplexContentExtension)
                {
                    XmlSchemaComplexContentExtension ext = (XmlSchemaComplexContentExtension)complexType.ContentModel.Content;
                    XmlSchemaComplexType baseType;
                    if (ext.BaseTypeName != null && SchemaManager.GetComplexType(ext.BaseTypeName.Namespace, ext.BaseTypeName.Name, out baseType))
                    {
                        getAttributes(baseType, attributes);
                    }
                }
            }

            return attributes.Count > 0;
        }


    }
}
