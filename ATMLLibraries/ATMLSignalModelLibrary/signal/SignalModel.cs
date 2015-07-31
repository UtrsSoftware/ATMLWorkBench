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
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using ATMLDataAccessLibrary.db.beans;
using ATMLDataAccessLibrary.db.daos;
using ATMLDataAccessLibrary.model;
using ATMLModelLibrary.model.signal;
using ATMLModelLibrary.model.signal.basic;
using ATMLUtilitiesLibrary;

namespace ATMLSignalModelLibrary.signal
{
    public class SignalModelLibrary
    {
        private const string XMLNS = "xmlns";
        private Dictionary<string, SignalModel> _signalModels = new Dictionary<string, SignalModel>();
        private TSFLibrary _tsfLibrary;
        private String _xmlContent;

        public SignalModelLibrary( Stream inputStream )
        {
            var xmlDocument = new XmlDocument();
            var sr = new StreamReader( inputStream );
            _xmlContent = sr.ReadToEnd();
            if (String.IsNullOrEmpty( _xmlContent ))
                throw new Exception( "Empty Input Document" );
            _xmlContent = _xmlContent.Trim();
            xmlDocument.LoadXml( _xmlContent );

            _tsfLibrary = TSFLibrary.Deserialize( _xmlContent );
            foreach (TSFType tsfType in _tsfLibrary.TSF)
            {
                string defaultSchema;
                string modelXml;
                string interfaceSchema = getInterface( xmlDocument, tsfType.name, out defaultSchema, out modelXml );
                if (string.IsNullOrEmpty( defaultSchema ))
                    if (xmlDocument.DocumentElement != null && xmlDocument.DocumentElement.Attributes[XMLNS] != null)
                        defaultSchema = xmlDocument.DocumentElement.Attributes[XMLNS].Value;
                var model = new SignalModel(
                    tsfType,
                    _tsfLibrary.targetNamespace,
                    defaultSchema,
                    interfaceSchema,
                    modelXml,
                    xmlDocument );

                SetSignalModel( tsfType.name, model );
            }
        }

        public String XmlContent
        {
            get { return _xmlContent; }
            set { _xmlContent = value; }
        }

        public TSFLibrary TSFLibrary
        {
            get { return _tsfLibrary; }
            set { _tsfLibrary = value; }
        }

        public Dictionary<string, SignalModel> SignalModels
        {
            get { return _signalModels; }
            set { _signalModels = value; }
        }

        public byte[] Serialize()
        {
            return Encoding.UTF8.GetBytes( _tsfLibrary.Serialize() );
        }

        public bool HasSignalModel( string name )
        {
            return _signalModels.ContainsKey( name );
        }

        public SignalModel GetSignalModel( string name )
        {
            return HasSignalModel( name ) ? _signalModels[name] : null;
        }

        public void SetSignalModel( string name, SignalModel model )
        {
            _signalModels.Add( name, model );
        }

        private string getInterface( XmlDocument xml, string name, out string defaultNameSpace, out string modelXml )
        {
            defaultNameSpace = null;
            var nsmgr = new XmlNamespaceManager( xml.NameTable );
            nsmgr.AddNamespace( "tsf", ATMLContext.NS_STDTSF );
            nsmgr.AddNamespace( "std", ATMLContext.NS_STDBSC );
            nsmgr.AddNamespace("std1", ATMLContext.NS_STDBSC);
            nsmgr.AddNamespace("this", ATMLContext.NS_STDBSC);
            nsmgr.AddNamespace( "xs", ATMLContext.NS_XS );
            nsmgr.AddNamespace( "xsi", ATMLContext.NS_XSI );
            XmlNode node = xml.SelectSingleNode( "descendant::tsf:TSF[@name='" + name + "']", nsmgr );
            if (node == null)
                throw new Exception( "Failed to find TSF name \"" + name + "\" in the supplied TSF Library File" );
            XmlNode interfaceNode = node.SelectSingleNode( "tsf:interface", nsmgr );
            XmlNode modelNode = node.SelectSingleNode( "tsf:model", nsmgr );
            if (interfaceNode == null)
                throw new Exception( "Failed to find the interface schema for TSF name \"" + name +
                                     "\" in the supplied TSF Library File" );
            if (modelNode == null)
                throw new Exception( "Failed to find the model schema for TSF name \"" + name +
                                     "\" in the supplied TSF Library File" );
            if (node.Attributes != null && node.Attributes.GetNamedItem( XMLNS ) != null)
                defaultNameSpace = node.Attributes.GetNamedItem( XMLNS ).Value;
            modelXml = modelNode.InnerXml;
            return interfaceNode.InnerXml;
        }
    }

    public class SignalModel
    {
        private readonly string _interfaceSchema;
        private readonly Signal _signal;
        private readonly string _signalNameSpace;
        private List<SignalAttribute> _attributes = new List<SignalAttribute>();
        private string _baseSignalName;
        private string _baseSignalNameSpace;

        private string _name;
        private TSFType _tsf;

        public SignalModel( TSFType tsf, 
                            string nameSpace, 
                            string defaultNameSpace, 
                            string interfaceSchema,
                            string modelXml, 
                            XmlDocument xml )
        {
            _tsf = tsf;
            _interfaceSchema = interfaceSchema;
            _name = tsf.name;
            Process( xml );

            _signalNameSpace = nameSpace;
            if (string.IsNullOrEmpty( _baseSignalNameSpace ))
                _baseSignalNameSpace = defaultNameSpace;

            _signal = Signal.Deserialize( modelXml );

            //SaveSignalModel();
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public TSFType TSF
        {
            get { return _tsf; }
            set { _tsf = value; }
        }

        public List<SignalAttribute> Attributes
        {
            get { return _attributes; }
            set { _attributes = value; }
        }

        public string BaseSignalName
        {
            get { return _baseSignalName; }
        }

        public string BaseSignalNameSpace
        {
            get { return _baseSignalNameSpace; }
        }

        public string SignalNameSpace
        {
            get { return _signalNameSpace; }
        }

        public Signal Signal
        {
            get { return _signal; }
        }

        public void SaveSignalModel()
        {
            //Check Database for _TSF.name
            //If not found add it
            //walk through attributes
            //check for attribute names
            //if not found add them

            var dao = new SignalDAO();
            dbSignal dataSignal = dao.getSignal( _name, _signalNameSpace );
            dbSignal baseSignal = dao.getSignal( _baseSignalName, _baseSignalNameSpace );
            if (dataSignal == null)
            {
                dataSignal = new dbSignal();
                dataSignal.parentSignalId = baseSignal != null ? baseSignal.signalId : 0;
                dataSignal.xmlns = _signalNameSpace;
                dataSignal.signalName = _name;
                dataSignal.uuid = Guid.Parse( _tsf.uuid );
                dataSignal.save();
            }

            foreach (SignalAttribute attr in _attributes)
            {
                bool hasAttribute = dao.hasAttribute( dataSignal.signalId, attr.Name );
                dbSignalAttribute dbAttribute;
                if (!hasAttribute)
                    dbAttribute = new dbSignalAttribute();
                else
                    dbAttribute = dao.GetAttribute( dataSignal.signalId, attr.Name );

                dbAttribute.DataState = hasAttribute ? BASEBean.eDataState.DS_EDIT : BASEBean.eDataState.DS_ADD;
                dbAttribute.attributeName = attr.Name;
                dbAttribute.signalId = dataSignal.signalId;
                dbAttribute.defaultValue = attr.DefaultValue;
                dbAttribute.fixedValue = attr.FixedValue;
                dbAttribute.type = attr.SchemaType;
                dbAttribute.save();
            }
        }

        private void Process( XmlDocument xml )
        {
            var nsmgr = new XmlNamespaceManager( xml.NameTable );
            //TODO: Interate through database list of available schema namespaces
            nsmgr.AddNamespace( "tsf", ATMLContext.NS_STDTSF );
            nsmgr.AddNamespace( "std", ATMLContext.NS_STDBSC );
            nsmgr.AddNamespace( "std1", ATMLContext.NS_STDBSC );
            nsmgr.AddNamespace( "this", ATMLContext.NS_STDTSFLIB );
            nsmgr.AddNamespace( "xsi", ATMLContext.NS_XSI );
            var settings = new XmlReaderSettings();
            settings.ValidationType = ValidationType.Schema;
            settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessInlineSchema;
            settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessSchemaLocation;
            settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;
            settings.ValidationEventHandler += ValidationCallBack;
            TextReader tr = new StringReader( _interfaceSchema );
            XmlSchema schema = XmlSchema.Read( tr, ValidationCallBack );
            if (schema.Attributes.Count > 0)
            {
                IDictionaryEnumerator enumerator = schema.Attributes.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    var attribute = (XmlSchemaAttribute) enumerator.Value;
                    Console.WriteLine( _tsf.name + @"." + attribute.Name + @" (attribute)" );
                }
            }
            String root = _tsf.name;
            XmlSchemaObjectCollection schemaItems = schema.Items;
            if (schemaItems != null)
            {
                foreach (XmlSchemaObject o in schemaItems)
                {
                    var childElement = (XmlSchemaElement) o;
                    root += String.Concat( ".", childElement.Name );
                    IterateOverElement( root, childElement );
                }
            }
        }

        private void IterateOverElement( string root, XmlSchemaElement element )
        {
            var complexType = element.SchemaType as XmlSchemaComplexType;
            if (complexType == null) return;
            if (complexType.AttributeUses.Count > 0)
            {
                IDictionaryEnumerator enumerator = complexType.AttributeUses.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    var attribute = (XmlSchemaAttribute) enumerator.Value;
                    Console.WriteLine( root + @"." + attribute.Name + @" (attribute)" );
                }
            }
            XmlSchemaContentModel contentModel = complexType.ContentModel;
            if (contentModel == null) return;
            XmlSchemaContent content = contentModel.Content;
            if (content is XmlSchemaComplexContentExtension)
            {
                var ext = (XmlSchemaComplexContentExtension) content;

                XmlQualifiedName baseTypeField = ext.BaseTypeName;
                _baseSignalName = baseTypeField.Name;
                _baseSignalNameSpace = baseTypeField.Namespace; //Need to get the base target namespace

                foreach (XmlSchemaObject o in ext.Attributes)
                {
                    var attribute = (XmlSchemaAttribute) o;
                    XmlSchemaAnnotation annotation = attribute.Annotation;
                    XmlSchemaType schemaType = attribute.SchemaType;
                    String defaultValue = attribute.DefaultValue;
                    String fixedValue = attribute.FixedValue;
                    String name = attribute.Name;
                    var signalAttribute = new SignalAttribute( name );
                    signalAttribute.DefaultValue = defaultValue;
                    signalAttribute.FixedValue = fixedValue;
                    signalAttribute.SchemaType = attribute.SchemaTypeName.Name;
                    _attributes.Add( signalAttribute );

                    //Add AttributeRestrictions here
                    if (schemaType is XmlSchemaSimpleType)
                    {
                        var simpleType = (XmlSchemaSimpleType) schemaType;
                        XmlSchemaSimpleTypeContent simpleContent = simpleType.Content;
                        foreach (XmlAttribute ua in simpleContent.UnhandledAttributes)
                        {
                            //if( "minInclusive".Equals( ua.LocalName )
                            //    restriction = new RangeRestriction( 
                            //Console.WriteLine("\t\t\t\t" + ua.Name + "\t\t" + ua.Value);
                            var restriction = new AttributeRestriction( ua );
                            signalAttribute.AddRestriction( restriction );
                        }
                    }
                }
            }
        }

        private static void ValidationCallBack( object sender, ValidationEventArgs args )
        {
            if (args.Severity == XmlSeverityType.Warning)
                Console.WriteLine( @"\tWarning: Matching schema not found.  No validation occurred." + args.Message );
            else
                Console.WriteLine( @"\tValidation error: " + args.Message );
        }

        public static Signal ExtractSignalFromElement(XmlElement any)
        {
            Signal signal = null;
            //-------------------------------------------------//
            //--- Make sure we're dealing with a Signal tag ---//
            //-------------------------------------------------//
            if ("Signal".Equals(any.LocalName))
            {
                signal = Signal.Deserialize(any.OuterXml.Trim());

                //-------------------------------------//
                //--- Time to walk the Signal Items ---//
                //-------------------------------------//
                foreach (object item in signal.Items)
                {
                    String sigName = item.GetType().Name;
                    foreach (PropertyInfo prop in item.GetType().GetProperties())
                    {
                        try
                        {
                            //Console.Write(prop.Name);
                            //Console.Write("\t");
                            //Console.Write(prop.PropertyType);
                            //Console.Write("\t");
                            //Console.WriteLine(prop.GetValue(item, null));
                        }
                        catch (Exception eee)
                        {
                        }
                    }
                }
            }
            return signal;
        }

    }

    public class SignalAttribute
    {
        private List<AttributeRestriction> _restrictions = new List<AttributeRestriction>();

        public SignalAttribute( string name )
        {
            Name = name;
        }

        public string Name { get; set; }

        public List<AttributeRestriction> Restrictions
        {
            get { return _restrictions; }
            set { _restrictions = value; }
        }

        public string SchemaType { get; set; }

        public string DefaultValue { get; set; }

        public string FixedValue { get; set; }

        public string Annotation { get; set; }

        public void AddRestriction( AttributeRestriction restriction )
        {
            _restrictions.Add( restriction );
        }
    }

    public class AttributeRestriction
    {
        private string _name;
        private string _value;

        public AttributeRestriction( XmlAttribute attribute )
        {
            _name = attribute.LocalName;
            _value = attribute.Value;
        }
    }


}