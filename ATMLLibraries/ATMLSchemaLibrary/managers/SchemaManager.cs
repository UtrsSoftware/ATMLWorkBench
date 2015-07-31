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
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;
using ATMLDataAccessLibrary.db.beans;
using ATMLDataAccessLibrary.db.daos;

namespace ATMLSchemaLibrary.managers
{
    public delegate void LoggingDelegate( string message, params object[] list );

    public class SchemaManager
    {
        private static StringBuilder _validationErrors = new StringBuilder();

        private static SchemaManager _instance;

        private readonly Dictionary<string, XmlSchemaAttributeGroup> _attributeGroups =
            new Dictionary<string, XmlSchemaAttributeGroup>();

        private readonly Dictionary<string, XmlSchemaComplexType> _complexTypes =
            new Dictionary<string, XmlSchemaComplexType>();

        private readonly Dictionary<string, XmlSchemaElement> _elements = new Dictionary<string, XmlSchemaElement>();
        private readonly Dictionary<string, XmlSchemaGroup> _groups = new Dictionary<string, XmlSchemaGroup>();
        private readonly XmlSchemaSet _schemaCollection = new XmlSchemaSet();
        private readonly Dictionary<string, XmlSchemaSet> _schemaSets = new Dictionary<string, XmlSchemaSet>();

        private readonly Dictionary<string, XmlSchemaType> _schemaTypes =
            new Dictionary<string, XmlSchemaType>();

        private readonly Dictionary<string, XmlSchema> _schemas = new Dictionary<string, XmlSchema>();

        private readonly Dictionary<string, XmlSchemaSimpleType> _simpleTypes =
            new Dictionary<string, XmlSchemaSimpleType>();

        private String _schemaPath;

        private SchemaManager()
        {
        }

        public static SchemaManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SchemaManager();
                return _instance;
            }
            set { _instance = value; }
        }

        public static Dictionary<string, XmlSchemaSet> SchemaSets
        {
            get { return Instance._schemaSets; }
        }

        public string SchemaPath
        {
            get { return _schemaPath; }
            set
            {
                _schemaPath = value;
                SetSchemaLocation();
            }
        }

        public event LoggingDelegate error;

        protected virtual void OnError( string message, params object[] list )
        {
            LoggingDelegate handler = error;
            if (handler != null) handler( message, list );
        }

        public event LoggingDelegate warning;

        protected virtual void OnWarning( string message, params object[] list )
        {
            LoggingDelegate handler = warning;
            if (handler != null) handler( message, list );
        }

        public void SetSchemaLocation()
        {
            if (string.IsNullOrEmpty( _schemaPath ))
                throw new Exception( "The Schema Path has not been set." );


            var dao = new SchemaDAO();

            List<DocumentBean> schemas = dao.GetSchemas();

            //List<string> list = Directory.GetFiles( _schemaPath, "*.xsd" ).ToList();

            //-------------------------------------//
            //--- Read schemas from file system ---//
            //-------------------------------------//
            //foreach (String fileName in list)
            foreach (DocumentBean schemaBean in schemas)
            {
                try
                {
                    string fileName = Path.Combine( _schemaPath, schemaBean.documentName );
                    FileInfo fi = new FileInfo( fileName );
                    if (!fi.Exists || fi.LastWriteTime < schemaBean.dateUpdated ) //We need to test if the database was updated
                        File.WriteAllBytes( fileName, schemaBean.documentContent );
                    XmlSchema myschema = XsdUtils.ReadSchema( fileName );
                    //XmlSchema myschema = XsdUtils.ReadSchemaFromText( Encoding.UTF8.GetString(schemaBean.documentContent));
                    String targetNamespace = myschema.TargetNamespace;
                    var schemaSet = new XmlSchemaSet();
                    schemaSet.ValidationEventHandler += ValidationCallback;
                    schemaSet.Add( myschema.TargetNamespace, fileName );
                    //schemaSet.Add(myschema);
                    schemaSet.Compile();
                    if (!_schemaSets.ContainsKey( targetNamespace ))
                        _schemaSets.Add( targetNamespace, schemaSet );
                    foreach (XmlSchema schema in schemaSet.Schemas())
                    {
                        if (myschema.SourceUri.Equals( schema.SourceUri ))
                            myschema = schema;
                    }
                    if (!_schemas.ContainsKey( myschema.TargetNamespace ))
                    {
                        _schemas.Add( myschema.TargetNamespace, myschema );
                        try
                        {
                            _schemaCollection.Add( myschema );
                        }
                        catch (Exception e)
                        {
                            OnError( e.Message, e );
                        }
                    }
                }
                catch (Exception e)
                {
                    OnError( e.Message, e );
                }
            }

            LoadSchemaItems();
        }

        public static XmlSchema GetSchema( String targetNamespace )
        {
            XmlSchema schema = null;
            if (Instance._schemas.ContainsKey( targetNamespace ))
                schema = Instance._schemas[targetNamespace];
            return schema;
        }

        private void LoadSchemaItems()
        {
            if (_schemas != null)
            {
                foreach (XmlSchema schema in _schemas.Values)
                {
                    foreach (object schemaObject in schema.SchemaTypes)
                    {
                        var schemaType = schemaObject as XmlSchemaType;
                        if (schemaType != null)
                        {
                            _schemaTypes.Add( schemaType.QualifiedName.ToString(), schemaType );
                        }
                        else if (schemaObject is DictionaryEntry)
                        {
                            _schemaTypes.Add( ( (DictionaryEntry) schemaObject ).Key.ToString(),
                                              (XmlSchemaType) ( (DictionaryEntry) schemaObject ).Value );
                        }
                        else
                        {
                            int i = 0;
                        }
                    }

                    List<XmlSchemaSimpleType> sts = XsdUtils.extractSimpleTypes( schema );
                    List<XmlSchemaComplexType> cts = XsdUtils.extractComplexTypes( schema );
                    List<XmlSchemaAttributeGroup> ats = XsdUtils.extractAttributeGroups( schema );
                    List<XmlSchemaGroup> gts = XsdUtils.extractGroups( schema );
                    List<XmlSchemaElement> els = XsdUtils.extractElements( schema );

                    String _namespace = schema.TargetNamespace;
                    foreach (XmlSchemaSimpleType simpleType in sts)
                    {
                        if (_simpleTypes.ContainsKey( _namespace + ":" + simpleType.Name ))
                            Console.WriteLine( @"Duplicate SimpleType Name: " + _namespace + @":" + simpleType.Name );
                        else
                            _simpleTypes.Add( _namespace + ":" + simpleType.Name, simpleType );
                    }
                    foreach (XmlSchemaComplexType complexType in cts)
                    {
                        if (_complexTypes.ContainsKey( _namespace + ":" + complexType.Name ))
                            Console.WriteLine( @"Duplicate ComplexType Name: " + _namespace + @":" + complexType.Name );
                        else
                            _complexTypes.Add( _namespace + ":" + complexType.Name, complexType );
                    }
                    foreach (XmlSchemaAttributeGroup group in ats)
                    {
                        if (_attributeGroups.ContainsKey( _namespace + ":" + group.Name ))
                            Console.WriteLine( @"Duplicate Attribute Group Name: " + _namespace + @":" + group.Name );
                        else
                            _attributeGroups.Add( _namespace + ":" + group.Name, group );
                    }
                    foreach (XmlSchemaGroup group in gts)
                    {
                        if (_groups.ContainsKey( _namespace + ":" + group.Name ))
                            Console.WriteLine( @"Duplicate Group Name: " + _namespace + @":" + group.Name );
                        else
                            _groups.Add( _namespace + ":" + group.Name, group );
                    }
                    foreach (XmlSchemaElement element in els)
                    {
                        if (_groups.ContainsKey( _namespace + ":" + element.Name ))
                            Console.WriteLine( @"Duplicate Element Name: " + _namespace + @":" + element.Name );
                        else
                            _elements.Add( _namespace + ":" + element.Name, element );
                    }
                }
            }
        }

        private String GetNamespace( XmlSerializerNamespaces namespaces )
        {
            var sb = new StringBuilder();
            foreach (XmlQualifiedName name in namespaces.ToArray())
            {
                sb.Append( name.Namespace );
            }
            return sb.ToString();
        }

        private static void ValidationCallback( object sender, ValidationEventArgs args )
        {
            if (args.Severity == XmlSeverityType.Warning)
                Console.Write( @"WARNING: " );
            else if (args.Severity == XmlSeverityType.Error)
            {
                _validationErrors.Append( args.Message ).Append( "<br/>" );
                Console.Write( @"ERROR: " );
            }

            Console.WriteLine( args.Message );
        }

        public static List<XmlSchemaSimpleTypeRestriction> GetRestrictions( String simpleTypeName,
                                                                            String targetNamespace )
        {
            var restrictions = new List<XmlSchemaSimpleTypeRestriction>();
            Instance.GetRestrictions( simpleTypeName + ":" + targetNamespace, restrictions );
            return restrictions;
        }

        /**
         * Recursively looks through a Simple Types ancestory for any restrictions 
         */

        public bool GetRestrictions( String name, List<XmlSchemaSimpleTypeRestriction> restrictions )
        {
            bool hasRestriction = false;
            //Lookup into Simple Type Map
            if (_simpleTypes.ContainsKey( name ))
            {
                XmlSchemaSimpleType simpleType = _simpleTypes[name];
                object item = simpleType.Content;
                if (item is XmlSchemaSimpleTypeRestriction)
                {
                    var restriction = (XmlSchemaSimpleTypeRestriction) item;
                    restrictions.Add( restriction );
                    if (restriction.BaseTypeName != null)
                    {
                        GetRestrictions( restriction.BaseTypeName.Name, restrictions );
                        hasRestriction = true;
                    }
                }
            }
            return hasRestriction;
        }

        public static List<XmlSchemaAttribute> GetAttributes( XmlSchemaComplexType complexType )
        {
            var attributes = new List<XmlSchemaAttribute>();
            if (complexType != null && complexType.ContentModel != null)
            {
                var items = new Dictionary<string, XmlSchemaObject>();
                ExtractContentItems( complexType.ContentModel, items );
                foreach (XmlSchemaObject item in items.Values)
                {
                    var attribute = item as XmlSchemaAttribute;
                    if (attribute != null)
                        attributes.Add( attribute );
                }
            }
            return attributes;
        }

        public static List<XmlSchemaAttribute> GetAttributes( XmlSchemaElement element )
        {
            var attributes = new List<XmlSchemaAttribute>();
            if (element != null && element.ElementSchemaType != null)
            {
                var complexType = element.ElementSchemaType as XmlSchemaComplexType;
                if (complexType != null)
                    attributes = GetAttributes( complexType );
            }
            return attributes;
        }

        public static bool GetComplexType( String targetNamespace, String typeName, out XmlSchemaComplexType complexType )
        {
            complexType = null;
            bool hasType = Instance._complexTypes.ContainsKey( targetNamespace + ":" + typeName );
            if (hasType)
                complexType = Instance._complexTypes[targetNamespace + ":" + typeName];
            return hasType;
        }

        public static bool GetElement( String targetNamespace, String typeName, out XmlSchemaElement element )
        {
            element = null;
            bool hasType = Instance._elements.ContainsKey( targetNamespace + ":" + typeName );
            if (hasType)
                element = Instance._elements[targetNamespace + ":" + typeName];
            return hasType;
        }

        public static bool GetSimpleType( String targetNamespace, String typeName, out XmlSchemaSimpleType simpleType )
        {
            simpleType = null;
            bool hasType = Instance._simpleTypes.ContainsKey( targetNamespace + ":" + typeName );
            if (hasType)
                simpleType = Instance._simpleTypes[targetNamespace + ":" + typeName];
            return hasType;
        }

        public static bool FindAttribute( String targetNamespace, String parentTypeName, String attributeName,
                                          out XmlSchemaAttribute attribute )
        {
            bool foundAttribute = false;
            attribute = null;
            XmlSchemaComplexType parentType = null;
            XmlSchemaElement parentElement = null;
            //---------------------------------------------//
            //--- First lets look into the Complex Type ---//
            //---------------------------------------------//
            if (GetComplexType( targetNamespace, parentTypeName, out parentType ))
            {
                foreach (object o in parentType.AttributeUses)
                {
                    if (o is DictionaryEntry && ( (DictionaryEntry) o ).Value is XmlSchemaAttribute)
                    {
                        var att = (XmlSchemaAttribute) ( (DictionaryEntry) o ).Value;
                        if (att != null && att.Name != null && att.Name.Equals( attributeName ))
                        {
                            attribute = att;
                            foundAttribute = true;
                            break;
                        }
                    }
                }
                if (!foundAttribute)
                {
                    Dictionary<string, XmlSchemaObject> xmlSchemaObjects = new Dictionary<string, XmlSchemaObject>();
                    ExtractAttributes(parentType, xmlSchemaObjects);
                    if (xmlSchemaObjects.Count > 0)
                    {
                        if (xmlSchemaObjects.ContainsKey( attributeName ))
                        {
                            attribute = xmlSchemaObjects[attributeName] as XmlSchemaAttribute;
                            foundAttribute = true;
                        }
                    }
                }
                if (!foundAttribute)
                {
                    XmlSchemaComplexContentExtension ext = parentType.ContentModel.Content as XmlSchemaComplexContentExtension;
                    Dictionary<string, XmlSchemaObject> xmlSchemaObjects = new Dictionary<string, XmlSchemaObject>();
                    ExtractAttributes(ext, xmlSchemaObjects);
                    if (xmlSchemaObjects.Count > 0)
                    {
                        if (xmlSchemaObjects.ContainsKey(attributeName))
                        {
                            attribute = xmlSchemaObjects[attributeName] as XmlSchemaAttribute;
                            foundAttribute = true;
                        }
                    }
                }

            }

            //------------------------------------------------------------------------------------------//
            //--- If the attribute was not found in the Complex Type then lets look into the Element ---//
            //------------------------------------------------------------------------------------------//
            if (!foundAttribute && GetElement(targetNamespace, parentTypeName, out parentElement))
            {
                var ct = parentElement.SchemaType as XmlSchemaComplexType;
                if (ct != null)
                {
                    if (ct.ContentModel != null)
                    {
                        var content = ct.ContentModel.Content as XmlSchemaComplexContentExtension;
                        if (content != null)
                        {
                            foreach (object o in content.Attributes)
                            {
                                var att = o as XmlSchemaAttribute;
                                var attGroupRef = o as XmlSchemaAttributeGroupRef;
                                if (att != null && att.Name != null && att.Name.Equals( attributeName ))
                                {
                                    attribute = att;
                                    foundAttribute = true;
                                    break;
                                }
                                //-----------------------------------------------------//
                                //--- Lets look into any Attribute Group References ---//
                                //-----------------------------------------------------//
                                if (attGroupRef != null && attGroupRef.RefName != null )
                                {
                                    XmlSchemaAttributeGroup attributeGroup;
                                    string ns = attGroupRef.RefName.Namespace;
                                    string name = attGroupRef.RefName.Name;
                                    GetAttributeGroup( ns, name, out attributeGroup );
                                    if (attributeGroup != null)
                                    {
                                        foreach (var attribute1 in attributeGroup.Attributes)
                                        {
                                            var att1 = attribute1 as XmlSchemaAttribute;
                                            if (att1 != null && att1.Name != null && att1.Name.Equals( attributeName ))
                                            {
                                                attribute = att1;
                                                foundAttribute = true;
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return foundAttribute;
        }

        public static bool GetAttributeGroup( String targetNamespace, String name,
                                              out XmlSchemaAttributeGroup attributeGroup )
        {
            bool found = false;
            attributeGroup = null;
            if (Instance._attributeGroups.ContainsKey( targetNamespace + ":" + name ))
            {
                found = true;
                attributeGroup = Instance._attributeGroups[targetNamespace + ":" + name];
            }
            return found;
        }

        private static bool ProcessPropertyInfo( object testSubject, SchemaValidationResult validationResults,
                                                 PropertyInfo propertyInfo,
                                                 Dictionary<string, XmlSchemaObject> xmlSchemaObjects, bool isValid )
        {
            string name = propertyInfo.Name;
            object oValue = propertyInfo.GetValue( testSubject, null );
            bool ok2Run = false;
            if (oValue != null)
            {
                MethodInfo mmi = oValue.GetType().GetMethod( "Validate" );
                var collection = oValue as ICollection;
                if (collection != null)
                {
                    //Need to get the type of each item schema
                    foreach (object obj in collection)
                    {
                        MethodInfo mi = obj.GetType().GetMethod( "Validate" );
                        if (mi != null)
                        {
                            var result = new SchemaValidationResult( name );
                            object[] p = {result};
                            try
                            {
                                mi.Invoke( obj, p );
                                object po = p[0];
                                validationResults.AddResult( result );
                            }
                            catch (Exception)
                            {
                                int i = 0;
                            }
                        }
                    }
                    ok2Run = true;
                }
                else if (mmi != null)
                {
                    var result = new SchemaValidationResult( name );
                    object[] p = {result};
                    mmi.Invoke( oValue, p );
                    validationResults.AddResult( result );
                    isValid = !result.HasErrors();
                }
                else
                {
                    ok2Run = true;
                }
            }
            else
            {
                ok2Run = true;
            }
            if (xmlSchemaObjects.ContainsKey( name ) && ok2Run)
            {
                string value = oValue != null ? oValue.ToString() : null;
                XmlSchemaObject schemaObject = xmlSchemaObjects[name];
                var attribute = schemaObject as XmlSchemaAttribute;
                var element = schemaObject as XmlSchemaElement;
                if (attribute != null)
                    isValid &= ValidateAttribute( attribute, value, validationResults );
                if (element != null)
                {
                    string ename = element.Name;
                    string enamespace = element.QualifiedName.Namespace;
                    bool isNillable = element.IsNillable;
                    isValid &= ValidateElement( element, oValue, validationResults );
                    var sct = element.ElementSchemaType as XmlSchemaComplexType;
                    if (sct != null)
                    {
                        //Validate(sct, o, errors);
                        int i = 0;
                    }

                    //Validate(enamespace, ename, o, errors);
                }
            }
            else
            {
                int i = 0;
            }
            return isValid;
        }

        private static void ExtractContentItems( XmlSchemaContentModel contentModel,
                                                 Dictionary<string, XmlSchemaObject> xmlSchemaObjects )
        {
            var cm = contentModel as XmlSchemaComplexContent;
            var cce = contentModel.Content as XmlSchemaComplexContentExtension;
            var sce = contentModel.Content as XmlSchemaSimpleContentExtension;
            var ccr = contentModel.Content as XmlSchemaComplexContentRestriction;
            var scr = contentModel.Content as XmlSchemaSimpleContentRestriction;

            bool isMixedContent = cm != null && cm.IsMixed;

            if (cce != null)
            {
                XmlQualifiedName baseTypeName = cce.BaseTypeName;
                ExtractSequenceItems( cce, xmlSchemaObjects );
                ExtractAttributes( cce, xmlSchemaObjects );
            }
            if (sce != null)
            {
                int i = 0;
            }
            if (ccr != null)
            {
                int i = 0;
            }
            if (scr != null)
            {
                int i = 0;
            }
        }

        public static void ExtractAttributes( XmlSchemaComplexContentExtension cce,
                                              Dictionary<string, XmlSchemaObject> xmlSchemaObjects )
        {
            if (cce != null)
            {
                XmlSchemaObjectCollection attributes = cce.Attributes;
                LoadAttributes( xmlSchemaObjects, attributes );
            }
        }

        public static void ExtractAttributes( XmlSchemaComplexType cce,
                                              Dictionary<string, XmlSchemaObject> xmlSchemaObjects )
        {
            if (cce != null)
            {
                XmlSchemaObjectCollection attributes = cce.Attributes;
                LoadAttributes( xmlSchemaObjects, attributes );

                if (cce.BaseXmlSchemaType != null)
                {
                    var ccee = cce.BaseXmlSchemaType as XmlSchemaComplexType;
                    if (ccee != null)
                    {
                        ExtractAttributes( ccee, xmlSchemaObjects );
                    }
                }
            }
        }

        private static void LoadAttributes( Dictionary<string, XmlSchemaObject> xmlSchemaObjects,
                                            XmlSchemaObjectCollection attributes )
        {
            foreach (XmlSchemaObject o in attributes)
            {
                var attribute = o as XmlSchemaAttribute;
                var attributeGroup = o as XmlSchemaAttributeGroup;
                var anyAttribute = o as XmlSchemaAnyAttribute;
                if (attribute != null && !string.IsNullOrWhiteSpace( attribute.Name ) &&
                    !xmlSchemaObjects.ContainsKey( attribute.Name ))
                {
                    xmlSchemaObjects.Add( attribute.Name, attribute );
                }
                if (attributeGroup != null)
                {
                    int ii = 0;
                }
                if (anyAttribute != null)
                {
                    int ii = 0;
                }
            }
        }

        public static void ExtractSequenceItems( XmlSchemaComplexContentExtension cce,
                                                 Dictionary<string, XmlSchemaObject> xmlSchemaObjects )
        {
            var sequence = cce.Particle as XmlSchemaSequence;
            if (sequence != null)
                ExtractSequenceItems( xmlSchemaObjects, sequence );
        }

        public static void ExtractSequenceItems( XmlSchemaComplexType cce,
                                                 Dictionary<string, XmlSchemaObject> xmlSchemaObjects )
        {
            var sequence = cce.Particle as XmlSchemaSequence;
            if (sequence != null)
                ExtractSequenceItems( xmlSchemaObjects, sequence );
        }

        private static void ExtractSequenceItems( Dictionary<string, XmlSchemaObject> xmlSchemaObjects,
                                                  XmlSchemaSequence sequence )
        {
            foreach (XmlSchemaObject xmlSchemaObject in sequence.Items)
            {
                var element = xmlSchemaObject as XmlSchemaElement;
                var any = xmlSchemaObject as XmlSchemaAny;
                var groupRef = xmlSchemaObject as XmlSchemaGroupRef;
                var sc = xmlSchemaObject as XmlSchemaChoice;
                var ss = xmlSchemaObject as XmlSchemaSequence;

                if (element != null)
                {
                    xmlSchemaObjects.Add( element.Name, element );
                }
                if (any != null)
                {
                    xmlSchemaObjects.Add( any.Id, any );
                }
                if (sc != null)
                {
                    //Process Group Items
                }
                if (ss != null)
                {
                    //Process Group Items
                }
                if (groupRef != null)
                {
                    //Process Group Ref
                }
            }
        }

        private static void ProcessSequence( SchemaValidationResult errors, XmlSchemaSequence sequence,
                                             ICollection collection,
                                             decimal minOccurrs )
        {
            foreach (XmlSchemaObject item in sequence.Items)
            {
                var se = item as XmlSchemaElement;
                var gr = item as XmlSchemaGroupRef;
                var sc = item as XmlSchemaChoice;
                var ss = item as XmlSchemaSequence;
                var sa = item as XmlSchemaAny;
                if (se != null)
                {
                    decimal max = se.MaxOccurs;
                    decimal min = se.MinOccurs;
                    string maxString = se.MaxOccursString;
                    string minString = se.MinOccursString;
                    if (collection.Count > max)
                        errors.AddError( string.Format( "{0} count may not be more than {1}", se.Name,
                                                        string.IsNullOrEmpty( maxString ) ? "" + max : maxString ) );
                    if (collection.Count < min && minOccurrs > 0)
                        errors.AddError( string.Format( "{0} count may not be less than {1}", se.Name,
                                                        ( string.IsNullOrEmpty( minString ) ? "" + min : minString ) ) );
                }
                else if (sc != null)
                {
                    foreach (XmlSchemaObject scItem in sc.Items)
                    {
                        var scse = scItem as XmlSchemaElement;
                        var scgr = scItem as XmlSchemaGroupRef;
                        var scsc = scItem as XmlSchemaChoice;
                        var scss = scItem as XmlSchemaSequence;
                        var scsa = scItem as XmlSchemaAny;
                    }
                }
                else if (ss != null)
                {
                    //ProcessSequence(errors, ss, ICollection collection,
                }
            }
        }

        private static bool ProcessRestrictions( string value,
                                                 SchemaValidationResult errors,
                                                 XmlSchemaSimpleTypeRestriction restriction,
                                                 string typeName,
                                                 string name )
        {
            bool isValid = true;
            if (restriction == null)
                return false;

            foreach (object facet in restriction.Facets)
            {
                if (facet is XmlSchemaMinInclusiveFacet)
                {
                    var lf = facet as XmlSchemaMinInclusiveFacet;
                    if (!string.IsNullOrEmpty( value ))
                    {
                        int iResult;
                        double dResult;
                        if (( typeName.Contains( "int" ) && int.TryParse( value, out iResult ) &&
                              iResult < int.Parse( lf.Value ) )
                            ||
                            ( typeName.Contains( "dou" ) && double.TryParse( value, out dResult ) &&
                              dResult < double.Parse( lf.Value ) ))
                        {
                            errors.AddError( String.Format( "The value of {0} must not be less than {1}", name, lf.Value ) );
                            isValid = false;
                        }
                    }
                }
                else if (facet is XmlSchemaMinExclusiveFacet)
                {
                    var lf = facet as XmlSchemaMinExclusiveFacet;
                    if (!string.IsNullOrEmpty( value ))
                    {
                        int iResult;
                        double dResult;
                        if (( typeName.Contains( "int" ) && int.TryParse( value, out iResult ) &&
                              iResult <= int.Parse( lf.Value ) )
                            ||
                            ( typeName.Contains( "dou" ) && double.TryParse( value, out dResult ) &&
                              dResult <= double.Parse( lf.Value ) ))
                        {
                            errors.AddError( String.Format( "The value of {0} must not be less than or equal to {1}",
                                                            name,
                                                            lf.Value ) );
                            isValid = false;
                        }
                    }
                }
                else if (facet is XmlSchemaMaxInclusiveFacet)
                {
                    var lf = facet as XmlSchemaMaxInclusiveFacet;
                    if (!string.IsNullOrEmpty( value ))
                    {
                        int iResult;
                        double dResult;
                        if (( typeName.Contains( "int" ) && int.TryParse( value, out iResult ) &&
                              iResult > int.Parse( lf.Value ) )
                            ||
                            ( typeName.Contains( "dou" ) && double.TryParse( value, out dResult ) &&
                              dResult > double.Parse( lf.Value ) ))
                        {
                            errors.AddError( String.Format( "The value of {0} must not be greater than {1}", name,
                                                            lf.Value ) );
                            isValid = false;
                        }
                    }
                }
                else if (facet is XmlSchemaMaxExclusiveFacet)
                {
                    var lf = facet as XmlSchemaMaxExclusiveFacet;
                    if (!string.IsNullOrEmpty( value ))
                    {
                        int iResult;
                        double dResult;
                        if (( typeName.Contains( "int" ) && int.TryParse( value, out iResult ) &&
                              iResult >= int.Parse( lf.Value ) )
                            ||
                            ( typeName.Contains( "dou" ) && double.TryParse( value, out dResult ) &&
                              dResult >= double.Parse( lf.Value ) ))
                        {
                            errors.AddError( String.Format( "The value of {0} must not be greater than or equal to {1}",
                                                            name, lf.Value ) );
                            isValid = false;
                        }
                    }
                }
                else if (facet is XmlSchemaLengthFacet)
                {
                    var lf = facet as XmlSchemaLengthFacet;
                    if (!String.IsNullOrEmpty( value ) && value.Length > int.Parse( lf.Value ))
                    {
                        errors.AddError( String.Format( "The value's length must not excede {0} characters", lf.Value ) );
                        isValid = false;
                    }
                }
                else if (facet is XmlSchemaMinLengthFacet)
                {
                    var lf = facet as XmlSchemaMinLengthFacet;
                    if (!String.IsNullOrEmpty( value ) && value.Length < int.Parse( lf.Value ))
                    {
                        errors.AddError( String.Format( "The value's length must not be less than {0} characters",
                                                        lf.Value ) );
                        isValid = false;
                    }
                }
                else if (facet is XmlSchemaMaxLengthFacet)
                {
                    var lf = facet as XmlSchemaMaxLengthFacet;
                    if (!String.IsNullOrEmpty( value ) && value.Length > int.Parse( lf.Value ))
                    {
                        errors.AddError( String.Format( "The value's length must not be greater than {0} characters",
                                                        lf.Value ) );
                        isValid = false;
                    }
                }
                else if (facet is XmlSchemaPatternFacet)
                {
                    var spf = facet as XmlSchemaPatternFacet;
                    Console.WriteLine( spf.Id + @" : " + spf.Value );
                    if (value != null && !Regex.Match( value, spf.Value ).Success)
                    {
                        errors.AddError( String.Format( "The \"{0}\" value must match the regular expression: {1}", name,
                                                        spf.Value ) );
                        isValid = false;
                    }
                }
                else if (facet is XmlSchemaEnumerationFacet)
                {
                    //TODO:XmlSchemaEnumerationFacet
                    int i = 0;
                }
                else if (facet is XmlSchemaTotalDigitsFacet)
                {
                    //TODO:XmlSchemaTotalDigitsFacet
                    int i = 0;
                }
                else if (facet is XmlSchemaWhiteSpaceFacet)
                {
                    //TODO:XmlSchemaWhiteSpaceFacet
                    int i = 0;
                }
            }

            return isValid;
        }

        public static string GetSchemaName( string content )
        {
            string xsdName = "";
            using (var sr = new StringReader( content ))
            {
                using (XmlReader xrXml = new XmlTextReader( sr ))
                {
                    var doc = new XmlDocument();
                    doc.Load( xrXml );
                    if (doc.DocumentElement == null)
                        throw new Exception( "Failed to load XML data." );

                    XmlNode nsp = doc.DocumentElement.Attributes["xmlns"];
                    XmlNode attribute = doc.DocumentElement.Attributes["xsi:schemaLocation"];
                    string nspn = "";
                    if (nsp != null)
                    {
                        if (attribute != null)
                        {
                            nspn = nsp.InnerText;
                            if (String.IsNullOrEmpty( nspn ))
                                throw new Exception( "Missing default namespace (xmlns) attribute." );

                            string[] parts = attribute.InnerText.Split( ' ' );
                            for (int i = 0; i < parts.Length; i++)
                            {
                                if (nspn.Equals( parts[i] ))
                                {
                                    xsdName = parts[i + 1];
                                    break;
                                }
                                i++;
                            }
                        }

                        if (String.IsNullOrEmpty( xsdName ))
                            throw new Exception( String.Format( "Missing schema location for namespace {0}", nspn ) );
                    }
                }
            }
            return xsdName;
        }

        public static bool IsPhysicalType( string nameSpace, string localName, string propertyName )
        {
            bool isPhysicalType = false;
            XmlSchemaAttribute schemaAttribute;
            FindAttribute( nameSpace, localName, propertyName, out schemaAttribute );
            string typeName = "";
            if (schemaAttribute != null)
            {
                XmlSchemaSimpleType simpleType = schemaAttribute.AttributeSchemaType;
                isPhysicalType = IsPhysicalType( simpleType );
            }
            return isPhysicalType;
        }


        public static bool IsPhysicalType( XmlSchemaType schemaType )
        {
            bool isPhysicalType = false;
            if (schemaType != null)
            {
                isPhysicalType = ( schemaType.Name != null && schemaType.Name.Contains( "Phys" ) );
                if (!isPhysicalType)
                {
                    if (schemaType.BaseXmlSchemaType != null)
                        isPhysicalType = IsPhysicalType( schemaType.BaseXmlSchemaType );
                }
            }
            return isPhysicalType;
        }


        public static bool IsPhysicalType(XmlQualifiedName qualifiedName)
        {
            bool isPhysicalType = false;
            if (qualifiedName != null)
            {
                isPhysicalType = (qualifiedName.Name != null && qualifiedName.Name.Contains("Phys"));
            }
            return isPhysicalType;
        }


        #region VALIDATION FUNCTIONS

        public static void ValidateToSchema( object item )
        {
            MethodInfo miValidate = item.GetType().GetMethod( "Validate" );
            if (miValidate == null)
                throw new Exception( string.Format( "{0} does not support the Validate Method", item.GetType().Name ) );

            var errors = new SchemaValidationResult();
            object[] p = {errors};
            miValidate.Invoke( item, p );
            if (errors.HasErrors())
            {
                throw new Exception( string.Format(
                    "This {0} has failed validation against the ATML Schema with the following errors:\n{1}",
                    item.GetType().Name, errors.ErrorMessage ) );
            }

            MessageBox.Show( string.Format(
                "This {0} has passed all validation against the ATML Schema.",
                item.GetType().Name ), @"V a l i d a t i o n", MessageBoxButtons.OK, MessageBoxIcon.Information );
        }

        public static bool ValidateXml( string xml, string targetNamespace, StringBuilder sb )
        {
            _validationErrors.Clear();

            //---------------------------------------------------------------//
            //--- TODO: Convert to xml and use XSLT to format for display ---//
            //---------------------------------------------------------------//
            string byteOrderMarkUtf8 = Encoding.UTF8.GetString( Encoding.UTF8.GetPreamble() );
            if (xml.StartsWith( byteOrderMarkUtf8 ))
                xml = xml.Remove( 0, byteOrderMarkUtf8.Length );

            sb.Append(
                "<h3 style=\"font-family:sans-serif;\" >The ATML XML has FAILED a standard validation against the specification XSD with the following errors: </h3>" );
            //error = null;
            bool validXml = true;
            try
            {
                var reader = new StringReader( xml );
                var settings = new XmlReaderSettings();
                settings.DtdProcessing = DtdProcessing.Parse;
                settings.ValidationType = ValidationType.Schema;
                settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessInlineSchema;
                settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessIdentityConstraints;
                settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessSchemaLocation;
                settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;
                settings.ValidationEventHandler += settings_ValidationEventHandler;

                XmlReader xr = XmlReader.Create( reader, settings );
                XDocument document = XDocument.Load( xr );
                if (!Instance._schemaSets.ContainsKey( targetNamespace ))
                {
                    string msg = string.Format( "<strong>Namespace \"{0}\" does not belong to the current schema set and therefore cannot be validated at this time.</strong>", targetNamespace );
                    throw new Exception( msg );
                }
                else
                {
                    XmlSchemaSet ss = Instance._schemaSets[targetNamespace];
                    var errors = new List<string>();

                    document.Validate( ss, ( o, err ) =>
                                           {
                                               var name =
                                                   new StringBuilder( "<strong><span style=\"font-family:sans-serif;\">" );
                                               var element = o as XElement;
                                               var attribute = o as XAttribute;
                                               if (attribute != null)
                                               {
                                                   element = attribute.Parent;
                                               }
                                               if (element != null)
                                               {
                                                   int indent = BuildParentTree( element, name );
                                                   name.Append( "</span></strong>" );
                                                   sb.Append( "<br/>" );
                                                   sb.Append( "<div style=\"border:black solid 1px;padding:5px;\">" );
                                                   sb.Append( name );
                                                   sb.Append( "<br/>" )
                                                     .Append(
                                                         "<div style=\"color:red;font-family:sans-serif;padding-left:" )
                                                     .Append( 20*indent )
                                                     .Append( "px;\">" );
                                                   sb.Append( err.Message ).Append( "</div><br/><br/>" );
                                                   errors.Add( sb.ToString() );
                                                   if (err.Severity == XmlSeverityType.Error)
                                                       Instance.OnError( err.Message, null );
                                                   if (err.Severity == XmlSeverityType.Warning)
                                                       Instance.OnWarning( err.Message, null );
                                                   validXml = false;
                                                   sb.Append( "</div>" );
                                               }
                                               else
                                               {
                                                   int i = 0;
                                               }
                                           }, true );
                }
            }
            catch (Exception e)
            {
                validXml = false;
                try
                {
                    Instance.OnError( e.Message, sb.ToString() );
                    sb.Append( e.Message + "<br/><pre>" + e.StackTrace + "</pre>" );
                }
                catch (Exception ee)
                {
                    sb.Append( "An error occurred while processing a validation error<br/>" + ee.Message + "<br/>" );
                }
            }

            if (!validXml)
            {
                try
                {
                    //error = sb.ToString();
                }
                catch (Exception)
                {
                    MessageBox.Show( string.Format( "Failed to retrieve validation error message - size:{0}", sb.Length ) );
                }
            }

            if (_validationErrors.Length > 0)
            {
                validXml = false;
                sb.Append( _validationErrors );
            }

            return validXml;
        }

        private static void settings_ValidationEventHandler( object sender, ValidationEventArgs e )
        {
            if (e.Severity == XmlSeverityType.Error || e.Severity == XmlSeverityType.Warning)
                Trace.WriteLine(
                    String.Format( "Line: {0}, Position: {1} \"{2}\"",
                                   e.Exception.LineNumber, e.Exception.LinePosition, e.Exception.Message ) );
        }

        private static int BuildParentTree( XElement element, StringBuilder sb, int level = 0 )
        {
            if (element.Parent != null)
                level = BuildParentTree( element.Parent, sb, level );

            sb.Append( "<div style=\"padding-left:" ).Append( 20*level ).Append( "px;\">" );
            sb.Append( element.Name.LocalName );

            XAttribute id = element.Attribute( "ID" );
            XAttribute name = element.Attribute( "name" );
            if (name != null)
                sb.Append( "[" ).Append( name ).Append( "]" );
            else if (id != null)
                sb.Append( "[" ).Append( id ).Append( "]" );
            sb.Append( "<br/></div>" );
            return level + 1;
        }

        public static bool Validate( string nameSpace, string elementName, object testSubject,
                                     SchemaValidationResult schemaValidationResult )
        {
            bool isValid = true;
            XmlSchemaComplexType complexType;
            XmlSchemaElement element;
            if (GetComplexType( nameSpace, elementName, out complexType ))
            {
                isValid &= ValidateComplexType( complexType, testSubject, schemaValidationResult );
            }
            else
            {
                if (Instance._schemaTypes.ContainsKey( nameSpace + ":" + elementName ))
                {
                    int i = 0;
                }
                if (GetElement( nameSpace, elementName, out element ))
                {
                    isValid &= ValidateElement( element, testSubject, schemaValidationResult );
                }
            }
            return !schemaValidationResult.HasErrors();
        }

        public static bool ValidateComplexType( XmlSchemaComplexType complexType, object testSubject,
                                                SchemaValidationResult parentValidationResult )
        {
            bool isValid = true;
            var result = new SchemaValidationResult( testSubject.GetType().Name, testSubject );
            var xmlSchemaObjects = new Dictionary<string, XmlSchemaObject>();
            XmlSchemaContentModel contentModel = complexType.ContentModel;
            ExtractSequenceItems( complexType, xmlSchemaObjects );
            parentValidationResult.AddResult( result );

            if (contentModel != null)
                ExtractContentItems( contentModel, xmlSchemaObjects );

            ExtractAttributes( complexType, xmlSchemaObjects );

            PropertyInfo[] props = testSubject.GetType().GetProperties();
            foreach (PropertyInfo propertyInfo in props)
            {
                try
                {
                    isValid &= ProcessPropertyInfo( testSubject, result, propertyInfo, xmlSchemaObjects, isValid );
                }
                catch (Exception e)
                {
                    int i = 0;
                }
            }
            return result.HasErrors();
        }

        public static bool ValidateElement( XmlSchemaElement element, object value, SchemaValidationResult errors )
        {
            bool isValid = true;
            XmlSchemaType schemaType = element.ElementSchemaType;
            bool isNillable = element.IsNillable;
            string defaultValue = element.DefaultValue;
            decimal minOccurrs = element.MinOccurs;
            decimal maxOccurrs = element.MaxOccurs;
            //SchemaValidationResult errors = new SchemaValidationResult(element.Name );

            var complexType = schemaType as XmlSchemaComplexType;
            var simpleType = schemaType as XmlSchemaSimpleType;

            if (minOccurrs > 0 && value == null && !isNillable)
            {
                isValid = false;
                errors.AddError( string.Format( "{0} cannot be null", element.Name ) );
            }
            else if (complexType != null)
            {
                var collection = value as ICollection;
                if (collection != null)
                {
                    XmlSchemaParticle contentTypeParticle = complexType.ContentTypeParticle;
                    XmlSchemaParticle particle = complexType.Particle;
                    XmlSchemaContentModel model = complexType.ContentModel;
                    var sequence = particle as XmlSchemaSequence;
                    if (sequence != null)
                    {
                        ProcessSequence( errors, sequence, collection, minOccurrs );
                    }
                }
            }
            else if (simpleType != null)
            {
                var union = simpleType.Content as XmlSchemaSimpleTypeUnion;
                var list = simpleType.Content as XmlSchemaSimpleTypeList;
                var restriction = simpleType.Content as XmlSchemaSimpleTypeRestriction;

                if (restriction != null)
                {
                    XmlQualifiedName qname = simpleType.BaseXmlSchemaType.QualifiedName;
                    String typeName = qname.Name;
                    isValid &= ProcessRestrictions( value == null ? null : value.ToString(), errors, restriction,
                                                    typeName, simpleType.Name );
                }

                foreach (XmlSchemaObject contraint in element.Constraints)
                {
                    var key = contraint as XmlSchemaKey;
                    var keyRef = contraint as XmlSchemaKeyref;
                    var unique = contraint as XmlSchemaUnique;
                    if (key != null)
                    {
                    }
                    if (keyRef != null)
                    {
                    }
                    if (unique != null)
                    {
                    }
                }
            }

            XmlTypeCode tc = schemaType.TypeCode;
            //validationResult.AddResult( errors );
            return isValid;
        }

        public static bool ValidateAttribute( XmlSchemaAttribute attribute, string value, SchemaValidationResult errors )
        {
            bool isValid = true;
            XmlSchemaSimpleType attributeSchemaType = attribute.AttributeSchemaType;
            XmlSchemaUse use = attribute.Use;
            string name = attribute.Name;
            bool required = ( use == XmlSchemaUse.Required );
            if (required && string.IsNullOrEmpty( value ))
            {
                isValid = false;
                errors.AddError( string.Format( "{0} is required\n", name ) );
            }
            if (attributeSchemaType.Content is XmlSchemaSimpleTypeRestriction)
            {
                XmlQualifiedName qname = attributeSchemaType.BaseXmlSchemaType.QualifiedName;
                String typeName = qname.Name;
                var restriction = (XmlSchemaSimpleTypeRestriction) attributeSchemaType.Content;
                isValid &= ProcessRestrictions( value, errors, restriction, typeName, name );
            }
            return isValid;
        }

        #endregion
    }

    public class SchemaValidationResult
    {
        private readonly List<string> _errors = new List<string>();
        private readonly string _name;
        private readonly List<SchemaValidationResult> _results = new List<SchemaValidationResult>();

        public SchemaValidationResult()
        {
        }


        public SchemaValidationResult( string name )
        {
            _name = name;
        }

        public SchemaValidationResult( string name, object item )
        {
            _name = name;
            if (item != null)
                _name += "[" + item + "]";
        }


        public List<SchemaValidationResult> Results
        {
            get { return _results; }
        }

        public string Name
        {
            get { return _name; }
        }

        public List<string> Errors
        {
            get { return _errors; }
        }

        public string ErrorMessage
        {
            get { return BuildErrorMessage( "" ); }
        }

        public void AddResult( SchemaValidationResult result )
        {
            _results.Add( result );
        }

        public void AddError( string result )
        {
            Errors.Add( result );
        }

        public bool HasErrors()
        {
            bool hasErrors = Errors.Count > 0;
            foreach (SchemaValidationResult result in _results)
            {
                hasErrors |= result.HasErrors();
            }
            return hasErrors;
        }


        public string BuildErrorMessage( string parentName )
        {
            var sb = new StringBuilder();
            var prefix = new StringBuilder();
            if (!String.IsNullOrEmpty( parentName ))
                prefix.Append( parentName ).Append( "." );
            if (!String.IsNullOrEmpty( _name ))
                prefix.Append( _name );

            foreach (string error in _errors)
            {
                sb.Append( prefix ).Append( " \"" ).Append( error ).Append( "\"\n\n" );
            }

            foreach (SchemaValidationResult result in _results)
            {
                if (result.HasErrors())
                {
                    sb.Append( result.BuildErrorMessage( prefix.ToString() ) );
                }
            }
            return sb.ToString();
        }
    }


    public class SimpleType
    {
        private String _baseName;
        private String _name;
        private String _namespace;
        private String _prefix;
    }
}