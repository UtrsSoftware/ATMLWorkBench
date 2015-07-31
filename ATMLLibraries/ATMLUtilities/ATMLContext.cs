/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace ATMLUtilitiesLibrary
{
    [Serializable]
    [XmlRoot( "context" )]
    public class ATMLContext
    {
        public static string NS_STDBSC = "urn:IEEE-1641:2010:STDBSC";
        public static string NS_STDTSF = "urn:IEEE-1641:2010:STDTSF";
        public static string NS_STDTSFLIB = "urn:IEEE-1641:2010:STDTSFLib";
        public static string NS_XSI = "http://www.w3.org/2001/XMLSchema-instance";
        public static string NS_XS = "http://www.w3.org/2001/XMLSchema";

        private const string DOC = "doc";
        private const string REPORTS = "reports";
        private const string ATML = "atml";
        private const string READER = "reader";
        private const string ALLOCATOR = "allocator";
        private const string TRANSLATOR = "translator";
        private const string SOURCE = "source";
        private const string OUT = "out";
        private const string AIXML = "aixml";
        private const string UTRS = "UTRS";
        private const string SCHEMAS = "schemas";
        private const string TESTSETS = "TestSets";
        private const string ATMLWORKBENCH = "ATMLWorkBench";
        private const string DEFAULT_DB = "sbir-n21-027.accdb";
        private const string DEFAULT_DB_PROVIDER = "Microsoft.ACE.OLEDB.12.0";
        private const string HELPFILENAME = "ATMLWorkbench.chm";
        private const string ARCHIVE_FILE_EXTENSION = ".tpar";
        

        private const string MSG_PLEASE_SELECT_PROJECT = "Please select a project";

        private static ATMLContext instance;
        private static object _lock = new object();
        private static XmlSerializer serializer;
        private String _applicationName;
        private String _currentProjectName;
        private String _databasePath;
        private bool _msWordInstalled;
        private bool _msExcelInstalled;
        private bool _msAccessInstalled;
        private bool _msPowerPointInstalled;
        private bool _msOutlookInstalled;


        private SerializableDictionary<string, object> _properties = new SerializableDictionary<string, object>();
        private String _workingPath;

        private ATMLContext()
        {
            //---------------------------------------------------------------------//
            //--- We will try the registry first for the database location      ---//
            //--- This way the installed database may be bypassed - primarily   ---//
            //--- for development reasons.                                      ---//
            //---------------------------------------------------------------------//
            LoadDatabasePathFromRegistry();

            //---------------------------------------------------------------------//
            //--- Under normal conditions we'll get the database path from the  ---//
            //--- common application data folder created for this application.  ---//
            //---------------------------------------------------------------------//
            LoadDatabasePathFromInstallationDataPath();

            _msWordInstalled = UTRSOfficeUtils.IsInstalled( UTRSOfficeUtils.MSOfficeApplications.Word );
            _msExcelInstalled = UTRSOfficeUtils.IsInstalled(UTRSOfficeUtils.MSOfficeApplications.Excel);
            _msAccessInstalled = UTRSOfficeUtils.IsInstalled(UTRSOfficeUtils.MSOfficeApplications.Access);
            _msPowerPointInstalled = UTRSOfficeUtils.IsInstalled(UTRSOfficeUtils.MSOfficeApplications.PowerPoint);
            _msOutlookInstalled = UTRSOfficeUtils.IsInstalled(UTRSOfficeUtils.MSOfficeApplications.Outlook);
        }

        public static bool HasProjectOpen
        {
            get { return !string.IsNullOrEmpty( CurrentProjectName ); }
        }

        public static string CONTEXT_TYPE_XML
        {
            get { return "text/xml"; }
        }

        public static string AIXML_FILENAME_SUFFIX
        {
            get { return ".aixml.xml"; }
        }

        public static string AIXML_HIER_FILENAME_SUFFIX
        {
            get { return ".proc_hier.aixml.xml"; }
        }
        public static string ATML_TEST_DESC_FILENAME_SUFFIX
        {
            get { return ".1671.1.xml"; }
        }

        public static string ATML_INSTRUMENT_FILENAME_SUFFIX
        {
            get { return ".1671.2.xml"; }
        }

        public static string ATML_UUT_FILENAME_SUFFIX
        {
            get { return ".1671.3.xml"; }
        }

        public static string ATML_CONFIG_FILENAME_SUFFIX
        {
            get { return ".1671.4.xml"; }
        }

        public static string ATML_ADAPTER_FILENAME_SUFFIX
        {
            get { return ".1671.5.xml"; }
        }

        public static string ATML_STATION_FILENAME_SUFFIX
        {
            get { return ".1671.6.xml"; }
        }

        public static string PROJECT_INFO_FILENAME
        {
            get { return "project-info.xml"; }
        }


        public static Color COLOR_SUBPANEL
        {
            get { return ( (Color) GetProperty( "environment.visual.sub-panel-color", Color.LightSteelBlue ) ); }
        }

        public static Color COLOR_PANEL
        {
            get { return ( (Color) GetProperty( "environment.visual.panel-color", Color.AliceBlue ) ); }
        }

        public static Color COLOR_FORM
        {
            get { return ( (Color) GetProperty( "environment.visual.form-color", Color.SteelBlue ) ); }
        }

        public static Color COLOR_LIST_ODD
        {
            get { return ( (Color) GetProperty( "environment.visual.list-odd-color", Color.White ) ); }
        }

        public static Color COLOR_LIST_EVEN
        {
            get { return ( (Color) GetProperty( "environment.visual.list-even-color", Color.DarkSeaGreen ) ); }
        }

        public static string DB_PROVIDER
        {
            get { return (string)GetProperty("environment.database.provider", DEFAULT_DB_PROVIDER); }
            set { SetProperty( "environment.database.provider", value ); }
        }

        public static string PROFILE_PATH
        {
            get
            {
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), UTRS,
                                     ATMLWORKBENCH);
            }
        }

        public static string CONTEXT_FILE_NAME
        {
            get { return Path.Combine( PROFILE_PATH, "context.xml" ); }
        }

        public static string APPLICATION_NAME
        {
            get { return (string) GetProperty( "environment.project-name", Instance._applicationName ); }
            set
            {
                Instance._applicationName = value;
                SetProperty( "environment.project-name", value );
            }
        }

        public static string PROGRAM_PATH
        {
            get { return Path.GetDirectoryName( Application.ExecutablePath ); }
        }

        public static string PROJECT_PATH
        {
            get
            {
                return Path.Combine(
                    Environment.GetFolderPath( Environment.SpecialFolder.CommonApplicationData ),
                    UTRS,
                    ATMLWORKBENCH);
            }
        }

        public static string DB_PATH
        {
            get { return Instance._databasePath; }
            set
            {
                Instance._databasePath = value;
                ATMLRegistryUtils.WriteRegistryAttribute( "db-location", value );
                Instance.Serialize();
            }
        }

        public static string DB_NAME
        {
            get { return (string)GetProperty("environment.database.name", DEFAULT_DB); }
            set { SetProperty( "environment.database.name", value ); }
        }

        public String DatabasePath
        {
            get { return _databasePath; }
            set { _databasePath = value; }
        }

        public String ApplicationName
        {
            get { return _applicationName; }
            set { _applicationName = value; }
        }


        public String WorkingPath
        {
            get { return _workingPath; }
            set { _workingPath = value; }
        }

        public static Boolean IsValid
        {
            get { return !String.IsNullOrEmpty( Instance.ApplicationName ); }
        }

        public static Boolean IsDebugging
        {
            get { return (bool) GetProperty( "logging.debug.messages", false ); }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if (( serializer == null ))
                {
                    serializer = new XmlSerializer( typeof (ATMLContext) );
                }
                return serializer;
            }
        }

        public static String TESTSET_ARCHIVE_EXT
        {
            get { return ARCHIVE_FILE_EXTENSION; }
        }


        public static String TESTSET_PATH
        {
            get { return Path.Combine(PROJECT_PATH, TESTSETS); }
        }

        public static String SchemaPath
        {
            get { return Path.Combine(Instance.DatabasePath, SCHEMAS); }
        }

        public SerializableDictionary<string, object> PropertyOptions
        {
            set { _properties = value; }
            get { return _properties; }
        }

        public static string HelpPath
        {
            get
            {
                return "file://" + Path.Combine(PROJECT_PATH, HELPFILENAME);
            }
        }

        public static string ProjectAtmlPath
        {
            get 
            { 
                if( string.IsNullOrEmpty( CurrentProjectName )  )
                    throw new Exception(MSG_PLEASE_SELECT_PROJECT); 
                return Path.Combine( TESTSET_PATH, CurrentProjectName, ATML ); 
            }
        }

        public static string ProjectReaderPath
        {
            get
            {
                if (string.IsNullOrEmpty(CurrentProjectName))
                    throw new Exception(MSG_PLEASE_SELECT_PROJECT);
                return Path.Combine(TESTSET_PATH, CurrentProjectName, READER);
            }
        }

        public static string ProjectAllocatorPath
        {
            get
            {
                if (string.IsNullOrEmpty(CurrentProjectName))
                    throw new Exception(MSG_PLEASE_SELECT_PROJECT);
                return Path.Combine(TESTSET_PATH, CurrentProjectName, ALLOCATOR);
            }
        }

        public static string ProjectDocumentPath
        {
            get
            {
                if (string.IsNullOrEmpty(CurrentProjectName))
                    throw new Exception(MSG_PLEASE_SELECT_PROJECT);
                return Path.Combine(TESTSET_PATH, CurrentProjectName, DOC);
            }
        }

        public static string ProjectReportPath
        {
            get
            {
                if (string.IsNullOrEmpty(CurrentProjectName))
                    throw new Exception(MSG_PLEASE_SELECT_PROJECT);
                return Path.Combine(TESTSET_PATH, CurrentProjectName, REPORTS);
            }
        }

        public static string ProjectTranslatorPath
        {
            get
            {
                if (string.IsNullOrEmpty(CurrentProjectName))
                    throw new Exception(MSG_PLEASE_SELECT_PROJECT);
                return Path.Combine(TESTSET_PATH, CurrentProjectName, TRANSLATOR);
            }
        }

        public static string ProjectTranslatorSourcePath
        {
            get
            {
                if (string.IsNullOrEmpty(CurrentProjectName))
                    throw new Exception(MSG_PLEASE_SELECT_PROJECT);
                return Path.Combine(ProjectTranslatorPath, SOURCE);
            }
        }

        public static string ProjectTranslatorAixmlPath
        {
            get
            {
                if (string.IsNullOrEmpty(CurrentProjectName))
                    throw new Exception(MSG_PLEASE_SELECT_PROJECT);
                return Path.Combine(ProjectTranslatorPath, AIXML);
            }
        }

        public static string ProjectTranslatorOutPath
        {
            get
            {
                if (string.IsNullOrEmpty(CurrentProjectName))
                    throw new Exception(MSG_PLEASE_SELECT_PROJECT);
                return Path.Combine(ProjectTranslatorPath, OUT);
            }
        }

        public static string CurrentProjectName
        {
            get { return Instance._currentProjectName; }
            set { Instance._currentProjectName = value; }
        }

        public bool MsWordInstalled
        {
            get { return _msWordInstalled; }
        }

        public bool MsExcelInstalled
        {
            get { return _msExcelInstalled; }
        }

        public bool MsAccessInstalled
        {
            get { return _msAccessInstalled; }
        }

        public bool MsPowerPointInstalled
        {
            get { return _msPowerPointInstalled; }
        }

        public bool MsOutlookInstalled
        {
            get { return _msOutlookInstalled; }
        }

        public static void ShowHelp( Control parent, string keyword )
        {
            Help.ShowHelp( parent, HelpPath, HelpNavigator.KeywordIndex, keyword );
        }

        public static event EventHandler PropertyChanged;

        private static void OnPropertyChanged()
        {
            EventHandler handler = PropertyChanged;
            if (handler != null) handler( null, EventArgs.Empty );
        }

        private void LoadDatabasePathFromInstallationDataPath()
        {
            if (string.IsNullOrWhiteSpace( _databasePath ))
            {
                try
                {
                    _databasePath = Environment.GetFolderPath( Environment.SpecialFolder.CommonApplicationData );
                    _databasePath = Path.Combine(_databasePath, UTRS, ATMLWORKBENCH);
                }
                catch (Exception e)
                {
                    /* Do Nothing */
                }
            }
        }

        [Conditional( "DEBUG" )]
        private void LoadDatabasePathFromRegistry()
        {
            try
            {
                _databasePath = ATMLRegistryUtils.ReadRegistryAttribute( "db-location" );
            }
            catch (Exception)
            {
                /* Do Nothing */
            }
        }

        public static object GetProperty( string name, object defaultValue )
        {
            return GetProperty( name ) ?? defaultValue;
        }

        public static object GetProperty( string name )
        {
            object value = null;
            if (Instance._properties.ContainsKey( name ))
                value = Instance._properties[name];
            if (name.Contains( "color" ) && value != null)
            {
                value = DeserializeColor( value.ToString() );
            }
            return value;
        }

        public static void SetProperty( string name, object value )
        {
            if (value is Color)
                value = SerializeColor( (Color) value );
            if (Instance._properties.ContainsKey( name ))
                Instance._properties[name] = value;
            else
                Instance._properties.Add( name, value );
        }

        public static void Initialize()
        {
            ATMLContext i = Instance;
        }

        public static ATMLContext Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (_lock)
                    {
                        if (instance == null)
                        {
                            if (!File.Exists( CONTEXT_FILE_NAME ))
                                instance = new ATMLContext();
                            else
                                instance = DeSerializeObject<ATMLContext>( CONTEXT_FILE_NAME );

                            if (instance == null)
                                instance = new ATMLContext();
                        }
                    }
                }
                return instance;
            }
        }

        public static void Save()
        {
            SerializeObject( Instance, CONTEXT_FILE_NAME );
            OnPropertyChanged();
        }


        public virtual string Serialize()
        {
            StreamReader streamReader = null;
            MemoryStream memoryStream = null;
            try
            {
                memoryStream = new MemoryStream();
                Serializer.Serialize( memoryStream, this );
                memoryStream.Seek( 0, SeekOrigin.Begin );
                streamReader = new StreamReader( memoryStream );
                return streamReader.ReadToEnd();
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
        }

        public static bool Deserialize( string input, out ATMLContext obj, out Exception exception )
        {
            exception = null;
            obj = default( ATMLContext );
            try
            {
                obj = Deserialize( input );
                return true;
            }
            catch (Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static ATMLContext Deserialize( string input )
        {
            StringReader stringReader = null;
            try
            {
                stringReader = new StringReader( input );
                return ( (ATMLContext) ( Serializer.Deserialize( XmlReader.Create( stringReader ) ) ) );
            }
            finally
            {
                if (( stringReader != null ))
                {
                    stringReader.Dispose();
                }
            }
        }


        public static string SerializeColor( Color color )
        {
            var sb = new StringBuilder();
            if (color.IsNamedColor)
                sb.Append( string.Format( "{0}", color.Name ) );
            else
                sb.Append( string.Format( "{0}:{1}:{2}:{3}", color.A, color.R, color.G, color.B ) );
            return sb.ToString();
        }

        public static Color DeserializeColor( string strColor )
        {
            Color color = Color.Empty;
            byte a, r, g, b;

            string[] pieces = strColor.Split( new[] {':'} );

            if (pieces.Length == 1)
                color = Color.FromName( pieces[0] );
            else
            {
                a = byte.Parse( pieces[0] );
                r = byte.Parse( pieces[1] );
                g = byte.Parse( pieces[2] );
                b = byte.Parse( pieces[3] );
                color = Color.FromArgb( a, r, g, b );
            }
            return color;
        }


        public static void SerializeObject<T>( T serializableObject, string fileName )
        {
            if (serializableObject == null)
            {
                return;
            }

            var xmlDocument = new XmlDocument();
            var serializer = new XmlSerializer( serializableObject.GetType() );
            using (var stream = new MemoryStream())
            {
                string path = Path.GetDirectoryName( fileName );
                if (!Directory.Exists( path ))
                    Directory.CreateDirectory( path );
                if (!File.Exists( fileName ))
                    File.Create( fileName );
                serializer.Serialize( stream, serializableObject );
                stream.Position = 0;
                xmlDocument.Load( stream );
                xmlDocument.Save( fileName );
                stream.Close();
            }
        }

        public static T DeSerializeObject<T>( string fileName )
        {
            if (string.IsNullOrEmpty( fileName ))
            {
                return default( T );
            }

            T objectOut = default( T );

            try
            {
                string attributeXml = string.Empty;

                var xmlDocument = new XmlDocument();
                xmlDocument.Load( fileName );
                string xmlString = xmlDocument.OuterXml;

                using (var read = new StringReader( xmlString ))
                {
                    Type outType = typeof (T);

                    var serializer = new XmlSerializer( outType );
                    using (XmlReader reader = new XmlTextReader( read ))
                    {
                        objectOut = (T) serializer.Deserialize( reader );
                        reader.Close();
                    }

                    read.Close();
                }
            }
            catch (Exception ex)
            {
            }

            return objectOut;
        }
    }

    public class PropertyOption
    {
        private readonly SerializableDictionary<string, PropertyOption> _options =
            new SerializableDictionary<string, PropertyOption>();

        public PropertyOption( string name )
        {
            Name = name;
        }

        public PropertyOption( string name, object value )
        {
            Name = name;
            Value = value;
        }

        public SerializableDictionary<string, PropertyOption> Options
        {
            get { return _options; }
        }

        public object Value { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public string Name { get; set; }

        public string Label { get; set; }

        public void AddOption( PropertyOption option )
        {
            Options.Add( option.Name, option );
        }
    }
}