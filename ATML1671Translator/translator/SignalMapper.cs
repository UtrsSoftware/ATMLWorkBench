/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using ATMLCommonLibrary.utils;
using ATMLDataAccessLibrary.db.beans;
using ATMLDataAccessLibrary.db.daos;
using ATMLDataAccessLibrary.model;
using ATMLManagerLibrary.managers;
using ATMLModelLibrary.model.common;
using ATMLUtilitiesLibrary;

namespace ATML1671Translator.translator
{
    [GeneratedCode("System.Xml", "4.0.30319.18408")]
    [Serializable]
    [XmlRoot("signal-map")]
    public class SignalMapping
    {
        [XmlAttribute(AttributeName = "source_type")]
        public string SourceType { set; get; }
        [XmlAttribute(AttributeName = "model_library")]
        public string ModelLibrary { set; get; }
        [XmlElement("signal", Type = typeof(SignalMappingNoun))]
        public List<SignalMappingNoun> AtlasNouns { set; get; }
    }

    [GeneratedCode("System.Xml", "4.0.30319.18408")]
    [Serializable]
    [XmlRoot("signal")]
    public class SignalMappingNoun
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { set; get; }
        [XmlAttribute(AttributeName = "tsf")]
        public string Tsf { set; get; }
        [XmlElement("modifier", Type = typeof(SignalMappingNounModifier))]
        public List<SignalMappingNounModifier> Modifiers { set; get; } 
    }

    [GeneratedCode("System.Xml", "4.0.30319.18408")]
    [Serializable]
    [XmlRoot("modifier")]
    public class SignalMappingNounModifier
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { set; get; }
        [XmlAttribute(AttributeName = "tsf_attribute")]
        public string Attribute { set; get; }
        [XmlAttribute(AttributeName = "suffix")]
        public string Suffix { set; get; }
        [XmlAttribute(AttributeName = "tsf_qualifier")]
        public string Qualifier { set; get; }
        [XmlAttribute(AttributeName = "tsf_type")]
        public string Type { get; set; }
        [XmlAttribute(AttributeName = "tsf_default")]
        public string Default { get; set; }
    }


    public class SignalMapper
    {
        private readonly SignalDAO _signalDao;
        private readonly SignalMappingDAO _signalMappingDao;
        private List<string> _usedSignalsList = new List<string>();
 
        public SignalMapper()
        {
            _signalDao = new SignalDAO();
            _signalMappingDao = new SignalMappingDAO();
        }

        public List<string> UsedSignalsList
        {
            get { return _usedSignalsList; }
        }


        public void Process(byte[] aixmlDocument)
        {
            Dictionary<string, dbTSFSignal> signalLookup = new Dictionary<string, dbTSFSignal>();
            string xmlMapping = CreateSignalMappingXml( aixmlDocument );
            SignalMapping mapping = XmlUtils.DeserializeObject<SignalMapping>(xmlMapping);
            if (mapping != null)
            {
                string modelName = mapping.ModelLibrary;
                string sourceType = mapping.SourceType;
                _usedSignalsList.Clear();
                dbTSFLibrary library = GetTestSignalLibrary( mapping.ModelLibrary );
                foreach (var noun in mapping.AtlasNouns )
                {
                    string nounName = noun.Name;
                    string tsfSignalName = noun.Tsf;
                    _usedSignalsList.Add( nounName );

                    SourceSignalMapBean mapBean = _signalMappingDao.GetMappedSignal(sourceType, nounName);
                    if (mapBean == null)
                    {
                        mapBean = new SourceSignalMapBean();
                        mapBean.DataState = BASEBean.eDataState.DS_ADD;
                    }
                    else
                    {
                        mapBean.DataState = BASEBean.eDataState.DS_EDIT; 
                    }
                    mapBean.sourceName = nounName;
                    mapBean.sourceType = sourceType;
                    if (string.IsNullOrEmpty(mapBean.targetType))
                        mapBean.targetType = modelName;
                    if (string.IsNullOrEmpty(mapBean.targetName))
                        mapBean.targetName = tsfSignalName;
                    mapBean.save();

                    foreach (var modifier in noun.Modifiers)
                    {
                        SourceSignalAttributeMapBean attribute = _signalMappingDao.GetMappedSignalAttribute(
                            mapBean.id.ToString(), modifier.Name );
                        if (attribute == null)
                        {
                            attribute = new SourceSignalAttributeMapBean();
                            attribute.DataState = BASEBean.eDataState.DS_ADD;
                            attribute.mapId = mapBean.id;
                            attribute.sourceName = modifier.Name;
                            attribute.sourceSuffix = modifier.Suffix;
                            attribute.targetQualifier = modifier.Qualifier;
                            attribute.targetName = modifier.Attribute;
                            attribute.save();
                        }
                        else
                        {
                            attribute.DataState = BASEBean.eDataState.DS_EDIT;
                        }
                    }

                    if (!string.IsNullOrEmpty( tsfSignalName ))
                    {
                        List<TestSignalBean> signals = _signalDao.getTSFSignals( tsfSignalName );
                        foreach (TestSignalBean testSignalBean in signals)
                        {

                        }
                    }
                }




                if (library != null)
                {
                    //--- Create a lookup map for all the signals in the library ---//
                    foreach (dbTSFSignal tsfSignal in library.Signals)
                    {
                        if( !signalLookup.ContainsKey( tsfSignal.signalName ) )
                            signalLookup.Add(tsfSignal.signalName, tsfSignal);
                    }
                }
            }
        }


        //--- Create Signal Mapping XML ---//
        private string CreateSignalMappingXml( byte[] aixmlDocument )
        {
            Document xsl = DocumentManager.GetDocumentByName( "signal-mapping.xsl" );
            if( xsl == null )
                throw new Exception("Missing XSL File \"signal-mapping.xsl\"");
            return XmlUtils.Transform( xsl.DocumentContent, aixmlDocument );
        }


        //--- Get TSF Name for the signal ---//

        //--- Lookup signal name in signal model library ---//
        private dbTSFLibrary GetTestSignalLibrary(string name)
        {
            dbTSFLibrary library = _signalDao.getTSFLibraryByName( name );
            if( library.id == null )
                throw new Exception( string.Format( "Failed to locate TSF Library \"{0}\" - You may import this library using the Signal Model Library tool.", name ));
            library.Signals = _signalDao.getTSFLibrarySignals( library.id );
            return library;
        }

        //--- If multiple libraries exist for the signal - determine which would be a better fit based on the attributes ---//

        //--- Lookup signal name and tsf name in source signal map table ---//

        //--- Store all the attribute names ---//

        //--- Prompt user with mappings to allow user to map missing attributes ---//

    }
}
