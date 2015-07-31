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
using System.Web;
using System.Xml.Linq;
using ATMLCommonLibrary.model.navigator;
using ATMLCommonLibrary.utils;
using ATMLManagerLibrary.delegates;
using ATMLManagerLibrary.managers;
using ATMLModelLibrary.model;
using ATMLModelLibrary.model.common;
using ATMLModelLibrary.model.equipment;
using ATMLProject.managers;
using ATMLUtilitiesLibrary;
using Path = System.IO.Path;

namespace ATML1671Allocator.allocator
{
    public class ATMLAllocator
    {
        public static string SOURCE = "Allocator";
        private static readonly object SYNC_ROOT = new Object();
        private static volatile ATMLAllocator _instance;

        private readonly List<TestStationInstrumentData> _availableInstruments =
            new List<TestStationInstrumentData>();
                                                                //Contains only the instruments contained in the selected test stations

        private readonly List<XElement> _monitors = new List<XElement>();

        private readonly List<object> _requiredSignals = new List<object>();
                                      //Contains all the signals required to execute the test

        private readonly List<TestStationDescription11> _selectedTestStations = new List<TestStationDescription11>();
        private readonly List<XElement> _sensors = new List<XElement>();
        private readonly List<XElement> _sources = new List<XElement>();
        private XDocument _document;
        private TestDescription _testDescription;
        private string _xmlDocument;

        private ATMLAllocator()
        {
            ProjectManager.Instance.ProjectOpened += OnProjectOpened;
            ProjectManager.Instance.ProjectClosed += OnProjectClosed;
            ATMLNavigator.Instance.TestDescriptionDocumentAdded += Instance_TestDescriptionDocumentAdded;
        }

        public static ATMLAllocator Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (SYNC_ROOT)
                    {
                        if (_instance == null)
                            _instance = new ATMLAllocator();
                    }
                }
                return _instance;
            }
        }

        public List<TestStationDescription11> SelectedTestStations
        {
            get { return _selectedTestStations; }
        }

        public List<TestStationInstrumentData> AvailableInstruments
        {
            get { return _availableInstruments; }
        }

        public event EventHandler TestStationSelected;
        public event EventHandler Closed;
        public event EventHandler InstrumentsCleared;
        public event ProjectTestDescriptionChangedDeligate TestDescriptionChanged;
        public event AtmlFileOpenDelegate TestDescriptionLoaded;
        public event AtmlFileOpenDelegate TestConfigurationLoaded;
        public event AtmlFileOpenDelegate SignalAnalysisPerformed;

        protected virtual void OnSignalAnalysisPerformed( FileInfo fileinfo, byte[] content )
        {
            AtmlFileOpenDelegate handler = SignalAnalysisPerformed;
            if (handler != null) handler( fileinfo, content );
        }

        protected virtual void OnTestDescriptionChanged( TestDescription testdescription )
        {
            ProjectTestDescriptionChangedDeligate handler = TestDescriptionChanged;
            if (handler != null) handler( testdescription );
        }

        protected virtual void OnInstrumentsCleared()
        {
            EventHandler handler = InstrumentsCleared;
            if (handler != null) handler( this, EventArgs.Empty );
        }

        protected virtual void OnTestDescriptionOpened( FileInfo fileinfo, byte[] content )
        {
            AtmlFileOpenDelegate handler = TestDescriptionLoaded;
            if (handler != null) handler( fileinfo, content );
        }

        protected virtual void OnTestConfigurationOpened( FileInfo fileinfo, byte[] content )
        {
            AtmlFileOpenDelegate handler = TestConfigurationLoaded;
            if (handler != null) handler( fileinfo, content );
        }

        protected virtual void OnClosed()
        {
            EventHandler handler = Closed;
            if (handler != null) handler( this, EventArgs.Empty );
        }

        public static void OnTestStationSelected()
        {
            EventHandler handler = Instance.TestStationSelected;
            if (handler != null) handler( Instance, EventArgs.Empty );
        }

        private void Instance_TestDescriptionDocumentAdded( FileInfo fi, string documentType )
        {
        }

        private void OnProjectClosed()
        {
            _testDescription = null;
            _xmlDocument = null;
            _requiredSignals.Clear();
            //_selectedTestStations.Clear();
            _sensors.Clear();
            _monitors.Clear();
            _sources.Clear();
            OnClosed();
        }

        private void OnProjectOpened( string testProgramSetName )
        {
            string projectPath = Path.Combine( ATMLContext.TESTSET_PATH, testProgramSetName, "atml" );
            string fileName1 = Path.Combine( projectPath,
                                             testProgramSetName + ATMLContext.ATML_TEST_DESC_FILENAME_SUFFIX );
            string fileName2 = Path.Combine( projectPath, testProgramSetName + ATMLContext.ATML_CONFIG_FILENAME_SUFFIX );
            LoadTestDescriptionFile( fileName1 );
            LoadTestConfigurationFile( fileName2 );
        }

        private void LoadTestDescriptionFile( string fileName )
        {
            if (File.Exists( fileName ))
            {
                byte[] content = FileManager.ReadFile( fileName );
                var fi = new FileInfo( fileName );
                TestDescriptionLoaded( fi, content );
            }
        }

        private void LoadTestConfigurationFile( string fileName )
        {
            if (File.Exists( fileName ))
            {
                byte[] content = FileManager.ReadFile( fileName );
                var fi = new FileInfo( fileName );
                TestConfigurationLoaded( fi, content );
            }
        }

        public void AnalyzeRequiredSignals( string testDescriptionXml )
        {
            try
            {
                LogManager.SourceTrace( ATMLAllocator.SOURCE, "Starting a Signal Analysis..." );
                var analyzer = new ATMLSignalAnalyzer();
                string xml = analyzer.Analyze(testDescriptionXml);
                string htmlFileName = Path.Combine(ATMLContext.ProjectReportPath, "signal-analysis.html");
                string xmlFileName = Path.Combine(ATMLContext.ProjectAllocatorPath, "signal-analysis.xml");
                var xsl = DocumentManager.GetDocumentByName("signal-analysis.xsl");
                if (xsl != null)
                {
                    var sXml = new MemoryStream(Encoding.UTF8.GetBytes(xml));
                    var sXsl = new MemoryStream(xsl.DocumentContent);
                    var html = Encoding.UTF8.GetBytes( XmlUtils.Transform( sXsl, sXml ) );
                    FileManager.WriteFile(htmlFileName, html);
                    FileManager.WriteFile(xmlFileName, Encoding.UTF8.GetBytes(xml));
                    LogManager.SourceInfo(ATMLAllocator.SOURCE, "The Signal Analysis has been completed.");
                    ATMLNavigator.Instance.RefreshTree();
                    FileInfo fi = new FileInfo(htmlFileName);
                    OnSignalAnalysisPerformed( fi, html );
                }
            }
            catch (Exception err)
            {
                LogManager.SourceError(ATMLAllocator.SOURCE, err);
            }
        }

        public void AddSelectedTestStation( TestStationDescription11 testStation )
        {
            if (!SelectedTestStations.Contains( testStation ))
            {
                SelectedTestStations.Add( testStation );
                List<TestStationDescriptionInstrument> instruments = testStation.Instruments;
                if (instruments != null)
                {
                    foreach (TestStationDescriptionInstrument testStationDescriptionInstrument in instruments)
                    {
                        AddAvailableInstrument( new TestStationInstrumentData(testStation, testStationDescriptionInstrument) );
                    }
                }
            }
        }

        public void ClearAvailableInstruments()
        {
            _availableInstruments.Clear();
            OnInstrumentsCleared();
        }

        public void AddAvailableInstrument(TestStationInstrumentData instrumentDescription)
        {
            if (!_availableInstruments.Contains( instrumentDescription ))
                _availableInstruments.Add( instrumentDescription );
        }

        public void ClearSelectedTestStations()
        {
            _selectedTestStations.Clear();
        }

        public void LoadXML( string xmlDocument )
        {
            try
            {
                _xmlDocument = xmlDocument;
                XNamespace ad = "urn:IEEE-1671.1:2009:TestDescription";
                _document = XDocument.Load( new StringReader( _xmlDocument ) );

                _testDescription = TestDescription.Deserialize( _xmlDocument );

                _sources.AddRange( _document.Descendants( ad + "Source" ) );
                _sensors.AddRange( _document.Descendants( ad + "Sensor" ) );
                _monitors.AddRange( _document.Descendants( ad + "Monitor" ) );

                foreach (SignalRequirementsSignalRequirement signalRequirement in _testDescription.SignalRequirements)
                {
                    _requiredSignals.Add( signalRequirement.TsfClass );
                }


                foreach (ActionType action in _testDescription.DetailedTestInformation.Actions)
                {
                    var operations = action.Behavior.Item as Operations1;
                    if (operations != null)
                    {
                        foreach (OperationType operation in operations.Operation)
                        {
                            var setup = operation as OperationSetup;
                            if (setup != null)
                            {
                                var source = setup.Item as OperationSetupSource;
                                if (source != null)
                                {
                                    LogManager.SourceTrace(ATMLAllocator.SOURCE, HttpUtility.HtmlEncode(source.Any.InnerXml.Trim()));
                                    XElement signal = XElement.Parse( source.Any.InnerXml.Trim() );
                                    LogManager.SourceTrace(ATMLAllocator.SOURCE, "{0}:{1}", signal.GetPrefixOfNamespace(signal.Name.Namespace),
                                                      signal.Name.NamespaceName );
                                }
                            }
                        }
                    }
                }
                OnTestDescriptionChanged( _testDescription );
            }
            catch (Exception e)
            {
                LogManager.SourceError(ATMLAllocator.SOURCE, e);
            }
        }
    }

    public class TestStationInstrumentData
    {
        private readonly TestStationDescription11 _testStation;
        private readonly TestStationDescriptionInstrument _testStationInstrument;
        private readonly InstrumentDescription _instrumentDescription;
        private readonly ItemDescription _itemDescription;

        public TestStationInstrumentData( TestStationDescription11 testStation,
                                      TestStationDescriptionInstrument testStationInstrument )
        {
            _testStation = testStation;
            _testStationInstrument = testStationInstrument;
            _instrumentDescription = GetInstrumentDescription( testStationInstrument );
            _itemDescription = GetItemDescription( testStationInstrument );
        }

        public TestStationDescription11 TestStation
        {
            get { return _testStation; }
        }

        public InstrumentDescription InstrumentDescription
        {
            get { return _instrumentDescription; }
        }

        public ItemDescription ItemDescription
        {
            get { return _itemDescription; }
        }

        public TestStationDescriptionInstrument TestStationInstrument
        {
            get { return _testStationInstrument; }
        }

        private ItemDescription GetItemDescription(TestStationDescriptionInstrument testStationDescriptionInstrument)
        {
            ItemDescription itemDescription = testStationDescriptionInstrument.Item as InstrumentDescription;
            if (itemDescription != null)
            {
                //TODO: Process Test Station Instrument as Item Description
            }
            return itemDescription;
        }

        private InstrumentDescription GetInstrumentDescription(TestStationDescriptionInstrument testStationDescriptionInstrument)
        {
            InstrumentDescription instrument = null;
            DocumentReference documentReference = testStationDescriptionInstrument.Item as DocumentReference;
            if (documentReference != null)
            {
                try
                {
                    Document document = DocumentManager.GetDocument(documentReference.uuid);
                    if (document != null)
                    {
                        instrument = InstrumentDescription.Deserialize(Encoding.UTF8.GetString(document.DocumentContent));
                    }
                }
                catch (Exception e)
                {
                    LogManager.SourceError(ATMLAllocator.SOURCE, 
                        string.Format(
                            "Error obtaining the Test Station ({0}) - Instrument Description Document for \"{1}\" - Error: {2}",
                            _testStation.name, documentReference, e.Message), e);
                }
            }
            return instrument;
        }

    }
}