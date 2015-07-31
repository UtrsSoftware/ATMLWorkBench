/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ATMLModelLibrary.model.signal.analysis
{
    [XmlRoot( ElementName = "signal-analysis" )]
    public class SignalAnalysis
    {
        public enum CapabilityLevel
        {
            none,
            partial,
            fully
        }

        private readonly List<TestStationSignalAnalysis> _testStations = new List<TestStationSignalAnalysis>();

        [XmlAttribute( AttributeName = "ran" )]
        public string RunDateTime
        {
            get; set;
        }

        [XmlAttribute( AttributeName = "tps" )]
        public string Tps { get; set; }

        [XmlElement( ElementName = "uut" )]
        public Uut Uut { get; set; }

        [XmlElement( "test-station", Type = typeof (TestStationSignalAnalysis) )]
        public List<TestStationSignalAnalysis> TestStations
        {
            get { return _testStations; }
        }

        public void AddTestStation( TestStationSignalAnalysis testStation )
        {
            _testStations.Add( testStation );
        }
    }

    [XmlRoot( ElementName = "uut" )]
    public class Uut
    {
        [XmlElement( ElementName = "name" )]
        public string Name { get; set; }

        [XmlElement( ElementName = "uuid" )]
        public string Uuid { get; set; }

        [XmlElement( ElementName = "version" )]
        public string Version { get; set; }
    }

    [XmlRoot( ElementName = "test-station" )]
    public class TestStationSignalAnalysis
    {
        private SignalAnalysis.CapabilityLevel _capabilityLevel;

        private readonly List<SignalAnalysisType> _signals = new List<SignalAnalysisType>();

        [XmlAttribute( AttributeName = "capability" )]
        public string CapabilityLevel
        {
            get
            {
                bool partial = false;
                bool fully = true;
                foreach (var signalAnalysisType in Signals)
                {
                    foreach (var si in signalAnalysisType.SignalInstances)
                    {
                        partial |= (si.CapabilityLevel.Equals( Enum.GetName(typeof(SignalAnalysis.CapabilityLevel), SignalAnalysis.CapabilityLevel.partial)) );
                        fully &= (si.CapabilityLevel.Equals(Enum.GetName(typeof(SignalAnalysis.CapabilityLevel), SignalAnalysis.CapabilityLevel.fully)));
                    }
                }
                _capabilityLevel = fully
                                       ? SignalAnalysis.CapabilityLevel.fully : partial 
                                       ? SignalAnalysis.CapabilityLevel.partial : SignalAnalysis.CapabilityLevel.none;
                return Enum.GetName( typeof (SignalAnalysis.CapabilityLevel), _capabilityLevel );
            }
            set { _capabilityLevel = (SignalAnalysis.CapabilityLevel)Enum.Parse(typeof(SignalAnalysis.CapabilityLevel), value); }
        }

        [XmlAttribute( AttributeName = "name" )]
        public string Name { get; set; }

        [XmlAttribute( AttributeName = "uuid" )]
        public string Uuid { get; set; }

        [XmlElement( "signal", Type = typeof (SignalAnalysisType) )]
        public List<SignalAnalysisType> Signals
        {
            get { return _signals; }
        }

        public void AddSignal( SignalAnalysisType signal )
        {
            Signals.Add( signal );
        }
    }

    [XmlRoot( ElementName = "signal" )]
    public class SignalAnalysisType
    {
        private readonly List<SignalInstance> _signalInstances = new List<SignalInstance>();

        [XmlAttribute( AttributeName = "type" )]
        public string Type { get; set; }

        [XmlElement( "signal-instance", Type = typeof (SignalInstance) )]
        public List<SignalInstance> SignalInstances
        {
            get { return _signalInstances; }
        }

        public void AddSignal( SignalInstance signal )
        {
            _signalInstances.Add( signal );
        }

        public SignalAnalysisType Copy()
        {
            var copy = new SignalAnalysisType();
            copy.Type = Type;
            foreach (SignalInstance signalInstance in SignalInstances)
            {
                copy.AddSignal( signalInstance.Copy() );
            }
            return copy;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append( Type ).Append( " " );
            foreach (var signalInstance in SignalInstances)
            {
                sb.Append( signalInstance ).Append( "|" );
            }
            if (sb.ToString().EndsWith( "|" ))
                sb.Length = sb.Length - 1;
            return sb.ToString();
        }
    }

    [XmlRoot( ElementName = "signal-instance" )]
    public class SignalInstance
    {
        private SignalAnalysis.CapabilityLevel _capabilityLevel;
        private readonly List<SignalInstanceAttribute> _attributes = new List<SignalInstanceAttribute>();

        [XmlAttribute( AttributeName = "tsf" )]
        public string Tsf { get; set; }

        [XmlAttribute(AttributeName = "capability")]
        public string CapabilityLevel
        {
            get
            {
                bool partial = false;
                bool fully = true;
                foreach (var attribute in Attributes)
                {
                    partial |= attribute.IsValid;
                    fully &= attribute.IsValid;
                }
                _capabilityLevel = fully
                                       ? SignalAnalysis.CapabilityLevel.fully : partial
                                       ? SignalAnalysis.CapabilityLevel.partial : SignalAnalysis.CapabilityLevel.none;
                return Enum.GetName(typeof(SignalAnalysis.CapabilityLevel), _capabilityLevel);
            }
            set { _capabilityLevel = (SignalAnalysis.CapabilityLevel)Enum.Parse(typeof(SignalAnalysis.CapabilityLevel), value); }
        }

        [XmlElement( "attribute", Type = typeof (SignalInstanceAttribute) )]
        public List<SignalInstanceAttribute> Attributes
        {
            get { return _attributes; }
        }

        public SignalInstance Copy()
        {
            var copy = new SignalInstance();
            copy.Tsf = Tsf;
            foreach (SignalInstanceAttribute attribute in Attributes)
            {
                copy.AddAttribute( attribute.Copy() );
            }
            return copy;
        }

        public void AddAttribute( SignalInstanceAttribute attribute )
        {
            Attributes.Add( attribute );
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append( Tsf ).Append( " " );
            foreach (var signalInstanceAttribute in Attributes)
            {
                sb.Append( signalInstanceAttribute ).Append( ", " );
            }
            if (sb.ToString().Equals( ", " ))
                sb.Length = sb.Length - 2;
            return sb.ToString();
        }
    }

    [XmlRoot( ElementName = "signal-instance" )]
    public class SignalInstanceAttribute
    {
        [XmlAttribute( AttributeName = "name" )]
        public string Name { get; set; }

        [XmlText]
        public string Value { get; set; }

        [XmlAttribute(AttributeName = "valid")]
        public bool IsValid { get; set; }

        [XmlAttribute(AttributeName = "nominal")]
        public string NominalValue { get; set; }

        [XmlAttribute(AttributeName = "qualifier")]
        public string Qualifier { get; set; }

        public SignalInstanceAttribute Copy()
        {
            var copy = new SignalInstanceAttribute();
            copy.Name = Name;
            copy.Value = Value;
            copy.NominalValue = NominalValue;
            copy.IsValid = IsValid;
            copy.Qualifier = Qualifier;
            return copy;
        }

        public override string ToString()
        {
            return string.Format( "{0}={1} {2}", Name, Value, Qualifier );
        }
    }
}