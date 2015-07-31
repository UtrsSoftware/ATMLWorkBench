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
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using ATMLCommonLibrary.managers;
using ATMLCommonLibrary.utils;
using ATMLDataAccessLibrary.db.beans;
using ATMLDataAccessLibrary.db.daos;
using ATMLManagerLibrary.managers;
using ATMLModelLibrary.model;
using ATMLModelLibrary.model.common;
using ATMLModelLibrary.model.signal.basic;
using ATMLModelLibrary.model.uut;
using ATMLProject.managers;
using ATMLUtilitiesLibrary;

namespace ATML1671Translator.translator
{
    public class TranslationLibrary
    {
        private readonly Dictionary<string, Dictionary<object, SignalMappingNounModifier>> _signalMap;
        private readonly Dictionary<string, SourceSignalMapBean> _sourceSignalMap;

        public TranslationLibrary()
        {
            var signalMappingDao = new SignalMappingDAO();
            _signalMap = new Dictionary<string, Dictionary<object, SignalMappingNounModifier>>();
            _sourceSignalMap = new Dictionary<string, SourceSignalMapBean>();

            List<SourceSignalMapBean> signals = signalMappingDao.GetSourceSignals("ATLAS");
            foreach (var sourceSignalMapBean in signals)
            {
                if (!_sourceSignalMap.ContainsKey(sourceSignalMapBean.sourceName))
                    _sourceSignalMap.Add(sourceSignalMapBean.sourceName, sourceSignalMapBean);
                if( !_signalMap.ContainsKey( sourceSignalMapBean.sourceName ) )
                    _signalMap.Add(sourceSignalMapBean.sourceName, new Dictionary<object, SignalMappingNounModifier>());
                Dictionary<object, SignalMappingNounModifier> attributeMap = _signalMap[sourceSignalMapBean.sourceName];
                List<SourceSignalAttributeMapBean> attributes = signalMappingDao.GetSignalAttributes(sourceSignalMapBean.id);
                foreach (var attribute in attributes)
                {
                    if (!attributeMap.ContainsKey( attribute.sourceName ))
                    {
                        var smnm = new SignalMappingNounModifier();
                        smnm.Name = attribute.sourceName;
                        smnm.Attribute = string.IsNullOrEmpty(attribute.targetName) ? attribute.sourceName + "->[UNKNOWN]" : attribute.targetName;
                        smnm.Default = attribute.targetDefault;
                        smnm.Type = attribute.targetType;
                        smnm.Suffix = attribute.sourceSuffix;
                        smnm.Qualifier = attribute.targetQualifier;
                        attributeMap.Add(smnm.Name, smnm);
                    }
                }
            }
        }

        public string ConvertToCommonType( string type )
        {
            if (string.IsNullOrEmpty( type ))
                type = "c:string";
            else
            {
                if (type.StartsWith( "c:" ))
                    type = type.Substring( 2 );
                if ("decimal".Equals(type))
                    type = "double";
                else if ("char".Equals(type))
                    type = "string";
                type = "c:" + type;
            }
            return type;
        }

        /**
         * Creates an XML Node of the signal mapping information for the source name provided.
         */
        public XPathNodeIterator LookupSourceSignalMap( string sourceName )
        {
            XPathNodeIterator navigator = null;
            XmlDocument xPathDocument = new XmlDocument();
            XmlNamespaceManager mngr = new XmlNamespaceManager(new NameTable());
            if (_sourceSignalMap.ContainsKey(sourceName))
            {
                SourceSignalMapBean sourceSignal = _sourceSignalMap[sourceName];
                Dictionary<object, SignalMappingNounModifier> modifiers = _signalMap[sourceName];
                XmlElement signalElement = xPathDocument.CreateElement( "signal" );
                signalElement.SetAttribute("sourceName", sourceSignal.sourceName );
                signalElement.SetAttribute("sourceType", sourceSignal.sourceType);
                signalElement.SetAttribute("targetName", sourceSignal.targetName);
                signalElement.SetAttribute("targetType", sourceSignal.targetType);
                foreach (var signalMappingNounModifier in modifiers.Values)
                {
                    XmlElement signalAttribute = xPathDocument.CreateElement("signal_attribute");
                    string name = signalMappingNounModifier.Name;
                    string value = signalMappingNounModifier.Attribute;
                    string qualifier = signalMappingNounModifier.Qualifier;
                    string type = signalMappingNounModifier.Type;
                    string defaultValue = signalMappingNounModifier.Default;
                    string suffix = signalMappingNounModifier.Suffix;
                    signalAttribute.SetAttribute("name", name);
                    signalAttribute.SetAttribute("value", value);
                    signalAttribute.SetAttribute("qualifier", qualifier);
                    signalAttribute.SetAttribute("type", type);
                    signalAttribute.SetAttribute("default", defaultValue);
                    signalAttribute.SetAttribute("suffix", suffix);
                    signalElement.AppendChild( signalAttribute );
                }
                xPathDocument.AppendChild( signalElement );
            }
            XPathNavigator nav = xPathDocument.CreateNavigator();
            navigator = nav.Select("/", mngr);
            return navigator;
        }

        public XPathNodeIterator LookupSignalAttribute(string sourceName, string attributeName)
        {
            XPathNodeIterator navigator = null;
            XmlDocument xPathDocument = new XmlDocument();
            string attribute = null;
            if (_signalMap.ContainsKey( sourceName ))
            {
                Dictionary<object, SignalMappingNounModifier> attMap = _signalMap[sourceName];
                if (attMap.ContainsKey( attributeName ))
                {
                    xPathDocument.LoadXml(XmlUtils.SerializeObject(attMap[attributeName]));
                    var nav = xPathDocument.CreateNavigator();
                    var mngr = new XmlNamespaceManager(new NameTable());
                    navigator = nav.Select("/", mngr);
                }
            }
            if (navigator == null)
            {
                LogManager.SourceWarn(ATMLTranslator.SOURCE, "Signal Attribute not found - Source Signal: {0} Attribute: {1}", sourceName, attributeName);
                navigator = xPathDocument.CreateNavigator().Select("/");
            }
            return navigator;
        }

        public XPathNodeIterator GetTestParameters( XPathNodeIterator nodeIterator )
        {
            int i = 0;
            XPathNodeIterator navigator = null;
            XmlDocument xPathDocument = new XmlDocument();
            XmlElement xmlElement = xPathDocument.CreateElement( "parameters" );
            xPathDocument.AppendChild( xmlElement );
            XmlNamespaceManager mngr = new XmlNamespaceManager(new NameTable());
            List<string> varList = new List<string>();

            foreach (XPathNavigator statement in nodeIterator)
            {
                XPathNodeIterator variables = statement.Select( ".//*[@variable_name]" );
                foreach (XPathNavigator varNode in variables)
                {
                    XPathNodeIterator v = varNode.Select("@variable_name");
                    string varName = varNode.GetAttribute( "variable_name", "" );
                    if (!varList.Contains( varName ))
                    {
                        varList.Add( varName );
                        XmlElement param = xPathDocument.CreateElement( "parameter" );
                        param.SetAttribute( "ID", varName );
                        param.SetAttribute("name", varName);
                        xmlElement.AppendChild( param );
                    }
                }
            }

            XPathNavigator nav = xPathDocument.CreateNavigator();
            navigator = nav.Select("/", mngr);
            return navigator;
        }

        /**
         * Looks to see if there is already a test description and if so use it. Other
         * wise create a new one.
         */
        public string GenerateTestDescriptionUUID()
        {
            string uuid = Guid.NewGuid().ToString();
            if (ProjectManager.HasOpenProject())
            {
                if (ATMLTranslator.Instance.CurrentTestDescription != null)
                    uuid = ATMLTranslator.Instance.CurrentTestDescription.uuid;
            }
            return uuid;
        }


        public XPathNodeIterator GetMeasureSignal( XPathNodeIterator rootNode, int measureId )
        {
            int counter = 1;
            XPathNodeIterator navigator = null;
            XmlDocument xPathDocument = new XmlDocument();
            XmlElement xmlElement = xPathDocument.CreateElement("measure");
            xPathDocument.AppendChild(xmlElement);
            XmlNamespaceManager mngr = new XmlNamespaceManager(new NameTable());
            List<string> varList = new List<string>();
            foreach (XPathNavigator root in rootNode)
            {
                XPathNodeIterator measureStatements = root.Select(string.Format("//*/measure[@id={0}]", measureId));
                foreach (XPathNavigator measureStatement in measureStatements) //Should only be one
                {
                    ExtractAtlasSource(measureStatement, xmlElement);
                    var node = measureStatement.SelectSingleNode("signal_component/atlas/noun/@type");
                    if (node != null)
                        xmlElement.SetAttribute( "name", node.Value );
                    XPathNodeIterator modifiers = root.Select("measured_characteristics/noun_modifiers/noun_modifier");
                    XmlElement attributes = xPathDocument.CreateElement( "attributes" );
                    xmlElement.AppendChild( attributes );
                    foreach (XPathNavigator modifier in modifiers) 
                    {
                        node = modifier.SelectSingleNode("signal_component/atlas/noun_modifier/@type");
                        if (node != null)
                            attributes.SetAttribute( node.Name, node.Value );

                    }

                }
            }
            XPathNavigator nav = xPathDocument.CreateNavigator();
            navigator = nav.Select("/", mngr);
            return navigator;
        }

        private void ExtractAtlasSource(XPathNavigator measureStatement, XmlElement xmlElement)
        {
            XPathNavigator source = measureStatement.SelectSingleNode( "atlas_source" );
            if (source != null)
            {
                string file = source.GetAttribute( "file", "" );
                string statement = source.GetAttribute( "statement_number", "" );
                string line = source.GetAttribute( "line_number", "" );
                string type = source.GetAttribute("file_type", "");
                xmlElement.SetAttribute("file", file);
                xmlElement.SetAttribute("statement_number", statement);
                xmlElement.SetAttribute("line_number", line);
                xmlElement.SetAttribute("file_type", type);
            }
        }


        public XPathNodeIterator GetLocalSignals(XPathNodeIterator rootNode, int testNo)
        {
            int counter = 1;
            XPathNodeIterator navigator = null;
            XmlDocument xPathDocument = new XmlDocument();
            XmlElement xmlElement = xPathDocument.CreateElement("signals");
            xPathDocument.AppendChild(xmlElement);
            XmlNamespaceManager mngr = new XmlNamespaceManager(new NameTable());
            List<string> varList = new List<string>();
            foreach (XPathNavigator root in rootNode)
            {
                XPathNodeIterator statements = root.Select( string.Format("//*/statement[@test_number={0}]", testNo) );
                foreach (XPathNavigator statement in statements)
                {
                    string refId = statement.GetAttribute( "refid", "" );
                    if (!String.IsNullOrWhiteSpace( refId ))
                    {
                        XPathNodeIterator signals =
                            root.Select( string.Format( "//*[@id={0}]/signal_component/atlas/noun", int.Parse(refId) ) );
                        foreach (XPathNavigator signal in signals)
                        {
                            string type = signal.GetAttribute( "type", "" );
                            string resource = signal.GetAttribute( "resource", "" );
                            if (!varList.Contains( type ))
                            {
                                varList.Add( type );
                                XmlElement el = xPathDocument.CreateElement( "signal" );
                                el.SetAttribute( "type", type );
                                el.SetAttribute( "resource", resource );
                                el.SetAttribute( "id", string.Format( "ls{0}-{1}", testNo, counter++ ) );
                                xmlElement.AppendChild( el );
                            }
                        }
                    }
                }
            }
            XPathNavigator nav = xPathDocument.CreateNavigator();
            navigator = nav.Select("/", mngr);
            return navigator;
        }


        public XPathNodeIterator GetInterfacePorts(string uuid)
        {
            XPathNodeIterator navigator = null;
            XmlDocument xPathDocument = new XmlDocument();
            Document document = DocumentManager.GetDocument(uuid);
            if (document != null)
            {
                xPathDocument.LoadXml(Encoding.UTF8.GetString(document.DocumentContent));
                XPathNavigator nav = xPathDocument.CreateNavigator();
                XmlNamespaceManager mngr = new XmlNamespaceManager(new NameTable());
                mngr.AddNamespace("c", "urn:IEEE-1671:2010:Common");
                mngr.AddNamespace("hc", "urn:IEEE-1671:2010:HardwareCommon");
                mngr.AddNamespace("td", "urn:IEEE-1671.1:2009:TestDescription");
                mngr.AddNamespace("std", "urn:IEEE-1641:2010:STDBSC");
                mngr.AddNamespace("uut", "urn:IEEE-1671.3:2009.03:UUTDescription");
                mngr.AddNamespace("", "urn:IEEE-1671.3:2009.03:UUTDescription");
                navigator = nav.Select("uut:UUTDescription/uut:Hardware/hc:Interface/c:Ports/c:Port",mngr);
            }
            if (navigator == null)
            {
                LogManager.SourceWarn(ATMLTranslator.SOURCE, "Interface Ports not found for UUT {0}", uuid);
                navigator = xPathDocument.CreateNavigator().Select( "/" );
            }
            return navigator;
        }

        public XPathNodeIterator GetUUTDescription(string uuid)
        {
            XPathNodeIterator navigator = null;
            XmlDocument xPathDocument = new XmlDocument();
            Document document = DocumentManager.GetDocument(uuid);
            if (document != null)
            {
                xPathDocument.LoadXml(Encoding.UTF8.GetString(document.DocumentContent));
                XPathNavigator nav = xPathDocument.CreateNavigator();
                XmlNamespaceManager mngr = new XmlNamespaceManager(new NameTable());
                mngr.AddNamespace("c", "urn:IEEE-1671:2010:Common");
                mngr.AddNamespace("hc", "urn:IEEE-1671:2010:HardwareCommon");
                mngr.AddNamespace("td", "urn:IEEE-1671.1:2009:TestDescription");
                mngr.AddNamespace("std", "urn:IEEE-1641:2010:STDBSC");
                mngr.AddNamespace("uut", "urn:IEEE-1671.3:2009.03:UUTDescription");
                mngr.AddNamespace("", "urn:IEEE-1671.3:2009.03:UUTDescription");
                navigator = nav.Select("uut:UUTDescription", mngr);
            }
            if (navigator == null)
            {
                LogManager.SourceWarn(ATMLTranslator.SOURCE, "UUT Description not found for {0}", uuid);
                navigator = xPathDocument.CreateNavigator().Select( "/" );
            }
            return navigator;
        }


        public bool HasPowerRquirements(string uuid)
        {
            bool hasPowerRequirements = false;
            UUTDescription uut = UutManager.FindUut(uuid);
            if (uut != null)
            {
                HardwareUUT hardwareUut = uut.Item as HardwareUUT;
                if (hardwareUut != null)
                {
                    hasPowerRequirements = hardwareUut.PowerRequirements.Count > 0;
                }
            }
            return hasPowerRequirements;
        }


    }
}
