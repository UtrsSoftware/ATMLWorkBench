/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using ATMLCommonLibrary.utils;
using ATMLDataAccessLibrary.db.daos;
using ATMLManagerLibrary.managers;
using ATMLModelLibrary.model;
using ATMLModelLibrary.model.common;
using ATMLModelLibrary.model.signal.analysis;
using ATMLUtilitiesLibrary;

namespace ATML1671Allocator.allocator
{
    public class ATMLSignalAnalyzer
    {
       
        public string Analyze( string testDescriptionXml )
        {
            string xml = "";
            try
            {
                var dao = new InstrumentDAO();
                var testDescription = TestDescription.Deserialize( testDescriptionXml );
                var signalTypeLookup = new Dictionary<string, SignalAnalysisType>();
                var signalList = new List<string>();

                Dictionary<SignalRequirementsSignalRequirement, ICollection<object>> equips = Build( testDescription );

                foreach (SignalRequirementsSignalRequirement signalRequirement in testDescription.SignalRequirements)
                {
                    string name = signalRequirement.TsfClass.tsfClassName;
                    string id = signalRequirement.TsfClass.tsfLibraryID;
                    SignalRole role = signalRequirement.role;
                    if ("SHORT".Equals( name ))
                        continue;
                    if ("".Equals( name ))
                        continue;

                    SignalAnalysisType sat = null;
                    if (!signalTypeLookup.ContainsKey( name ))
                    {
                        sat = new SignalAnalysisType();
                        sat.Type = name;
                        signalTypeLookup.Add( name, sat );
                    }

                    sat = signalTypeLookup[name];
                    SignalInstance si = new SignalInstance();
                    si.Tsf = id;
                    foreach (
                        SignalRequirementsSignalRequirementTsfClassAttribute tsfClassAttribute in
                            signalRequirement.TsfClassAttribute)
                    {

                        SignalInstanceAttribute sia = new SignalInstanceAttribute();
                        sia.Name = tsfClassAttribute.Name.Value;
                        sia.Value = tsfClassAttribute.Value.ToString();
                        if (tsfClassAttribute.Value.Item is DatumType)
                        {
                            object v = Datum.GetNominalDatumValue( (DatumType) tsfClassAttribute.Value.Item );
                            sia.NominalValue = v==null?null:v.ToString();
                            sia.Qualifier = ( (DatumType) tsfClassAttribute.Value.Item ).unitQualifier;
                        }
                        si.AddAttribute(sia);
                    }
                    if (!signalList.Contains( name + id + si ))
                    {
                        signalList.Add( name + id + si );
                        sat.AddSignal( si );
                        Console.WriteLine( name + si );
                    }
                }

                SignalAnalysis signalAnalysis = new SignalAnalysis();
                signalAnalysis.Uut = new Uut();
                if (testDescription.UUT != null && testDescription.UUT.Description != null &&
                    testDescription.UUT.Description.Item != null)
                {
                    var id = testDescription.UUT.Description.Item as ItemDescription;
                    var docRef = testDescription.UUT.Description.Item as DocumentReference;
                    if (docRef != null)
                    {
                        signalAnalysis.Uut.Name = docRef.DocumentName;
                        signalAnalysis.Uut.Uuid = docRef.uuid;
                    }
                    else if (id != null)
                    {
                        signalAnalysis.Uut.Name = id.name;
                        signalAnalysis.Uut.Uuid = id.Identification.ModelName;
                        signalAnalysis.Uut.Version = id.version;
                    }

                }

                signalAnalysis.Tps = ATMLContext.CurrentProjectName;
                signalAnalysis.RunDateTime = String.Format("{0:yyyy-dd-MM HH:mm:ss}", DateTime.Now); 

                foreach (var testStation in ATMLAllocator.Instance.SelectedTestStations)
                {
                    var tsa = new TestStationSignalAnalysis();
                    tsa.Name = testStation.name;
                    tsa.Uuid = testStation.uuid;
                    signalAnalysis.AddTestStation( tsa );

                    foreach (SignalAnalysisType signalType in signalTypeLookup.Values)
                    {
                        SignalAnalysisType copy = signalType.Copy();
                        tsa.AddSignal(copy);
                        foreach (var signalInstance in copy.SignalInstances)
                        {
                            foreach (var signalInstanceAttribute in signalInstance.Attributes)
                            {
                                try
                                {
                                    if (signalInstanceAttribute.NominalValue != null)
                                    {
                                        bool isValid = dao.TestAttribute( testStation.uuid,
                                                                          signalInstanceAttribute.Name,
                                                                          signalInstanceAttribute.NominalValue, 
                                                                          signalInstanceAttribute.Qualifier);

                                        signalInstanceAttribute.IsValid = isValid;
                                    }
                                }
                                catch (Exception err)
                                {
                                    LogManager.SourceError(ATMLAllocator.SOURCE, err);
                                }
                            }
                        }
                        
                    }
                }

                xml = XmlUtils.SerializeObject( signalAnalysis );
            }
            catch (Exception e)
            {
                LogManager.SourceError(ATMLAllocator.SOURCE, e);
            }
            return xml;
        }


        public Dictionary<SignalRequirementsSignalRequirement, ICollection<object>> Build(TestDescription testDescription)
        {
            var requiredSignals = new Dictionary<SignalRequirementsSignalRequirement, ICollection<object>>();
            
            foreach (SignalRequirementsSignalRequirement signalRequirement in testDescription.SignalRequirements)
            {
                var attributes = new List<Tuple<string, object, string>>();
                var dao = new InstrumentDAO();
                TsfClass tsfClass = signalRequirement.TsfClass;
                if (tsfClass.tsfClassName.Equals("SHORT"))
                    continue;
                if (string.IsNullOrWhiteSpace(tsfClass.tsfClassName))
                    continue;
                foreach (SignalRequirementsSignalRequirementTsfClassAttribute attribute in
                    signalRequirement.TsfClassAttribute)
                {
                    TsfClassAttributeName name = attribute.Name;
                    if (attribute.Value != null)
                    {
                        if (attribute.Value.Item is DatumType)
                        {
                            DatumType datum = attribute.Value.Item as DatumType;
                            Object value = Datum.GetNominalDatumValue(datum);
                            if (value != null)
                            {
                                attributes.Add(new Tuple<string, object, string>(name.Value, value, datum.unitQualifier));
                            }
                        }
                    }
                }

                try
                {
                    ICollection<object> capableEquipment = dao.FindCapableEquipment(attributes);
                    requiredSignals.Add(signalRequirement, capableEquipment );
                }
                catch (Exception e2)
                {
                    LogManager.SourceError(ATMLAllocator.SOURCE, "Error In TSF Class: {0} - ERROR: {1}", tsfClass.tsfClassName, e2.Message );
                    LogManager.Debug( e2 );
                    foreach (var tuple in attributes)
                    {
                        LogManager.SourceError(ATMLAllocator.SOURCE, "     {0} = {1}", tuple.Item1, tuple.Item2);
                    }
                }
            }

            return requiredSignals;
        }


    }
}
