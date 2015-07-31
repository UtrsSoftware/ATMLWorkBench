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
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;
using System.Xml.XPath;
using System.Xml.Xsl;
using ATMLCommonLibrary.model.navigator;
using ATMLDataAccessLibrary.db.beans;
using ATMLDataAccessLibrary.db.daos;
using ATMLDataAccessLibrary.managers;
using ATMLDataAccessLibrary.model;
using ATMLManagerLibrary.controllers;
using ATMLManagerLibrary.delegates;
using ATMLManagerLibrary.interfaces;
using ATMLManagerLibrary.managers;
using ATMLModelLibrary.model;
using ATMLModelLibrary.model.common;
using ATMLModelLibrary.model.equipment;
using ATMLModelLibrary.model.signal.basic;
using ATMLProject.managers;
using ATMLSchemaLibrary.managers;
using ATMLUtilitiesLibrary;
using Path = System.IO.Path;

namespace ATML1671Reader.reader
{

    public delegate void TranslatedInputDocumentDelegate( TestConfiguration15 testConfiguration );

    /**
     * 
     */

    public class ATMLReader
    {
        public static string SOURCE = "Reader";
        private const String ParsibleDocumentExtensions = ".xml, .tpsi";
        private const String NavigableDocumentExtensions = ".htm, .html";
        private byte[] _content;
        private string _currentProjectName;
        private string _documentName;
        private string _extension;
        private FileInfo _fileInfo;
        private IReaderNavigator _navigator;
        private TestConfiguration15 _testConfiguration;

        public event AtmlDocumentOpenDelegate AtmlDocumentOpened;
        public event AtmlFileOpenDelegate AtmlFileOpened;
        public event InputDocumentOpenDelegate OpenInputDocument;
        public event ParseableInputDocumentDelegate ParseableInputDocument;
        public event NavigableInputDocumentDelegate NavigableInputDocument;
        public event BeginDocumentOpenDelegate BeginOpenDocument;
        public event TranslatedInputDocumentDelegate InputDocumentTranslated;
        public event ProjectDelegate ProjectClosed;
        public event ProjectOpenDelegate ProjectOpened;

        public ATMLReader(IReaderNavigator navigator)
        {
            _navigator = navigator;
            _navigator.SelectATMLTestConfiguration += _navigator_SelectATMLTestConfiguration;
            _navigator.SelectReaderDocument += _navigator_SelectReaderDocument;
            ProjectManager.Instance.ProjectOpened += ATMLReader_ProjectOpened;
            ProjectManager.Instance.ProjectClosed += ATMLReader_ProjectClosed;
        }

        public TestConfiguration15 TestConfiguration
        {
            get { return _testConfiguration; }
        }

        protected virtual void OnProjectClosed()
        {
            ProjectDelegate handler = ProjectClosed;
            if (handler != null) handler();
        }

        protected virtual void OnProjectOpened(string testProgramSetName)
        {
            ProjectOpenDelegate handler = ProjectOpened;
            if (handler != null) handler(testProgramSetName);
        }

        protected virtual void OnAtmlFileOpened(Document document)
        {
            AtmlDocumentOpenDelegate handler = AtmlDocumentOpened;
            if (handler != null) handler(document);
        }

        protected virtual void OnAtmlFileOpened(FileInfo fi, byte[] content )
        {
            AtmlFileOpenDelegate handler = AtmlFileOpened;
            if (handler != null) handler(fi, content);
        }

        private void ATMLReader_ProjectClosed()
        {
            OnProjectClosed();
        }

        private void ATMLReader_ProjectOpened(string testProgramSetName)
        {
            OnProjectOpened(testProgramSetName);
            string projectPath = Path.Combine(ATMLContext.TESTSET_PATH, testProgramSetName, "atml");
            string fileName = Path.Combine(projectPath, testProgramSetName + ".1671.4.xml");
            LoadConfigFile(fileName);
        }

        /**
         * 
         */
        private void _navigator_SelectReaderDocument(object sender, FileInfo e, byte[] data)
        {
            SetContent(e, data);
        }

        /**
         * 
         */
        private void _navigator_SelectATMLTestConfiguration(object sender, FileInfo e)
        {
            LoadConfigFile(e.FullName);
        }

        private void LoadConfigFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                byte[] content = FileManager.ReadFile(fileName);
                FileInfo fi = new FileInfo(fileName);
                OnAtmlFileOpened(fi, content);
            }
        }

        /**
         * 
         */

        protected virtual void OnBeginOpenDocument()
        {
            BeginDocumentOpenDelegate handler = BeginOpenDocument;
            if (handler != null) handler();
        }

        /**
         * 
         */

        protected virtual void OnNavigatableInputDocument()
        {
            NavigableInputDocumentDelegate handler = NavigableInputDocument;
            if (handler != null) handler();
        }

        /**
         * 
         */

        protected virtual void OnTranslatedInputDocument(TestConfiguration15 testConfiguration)
        {
            TranslatedInputDocumentDelegate handler = InputDocumentTranslated;
            if (handler != null) handler(testConfiguration);
        }

        /**
         * 
         */

        protected virtual void OnParseableInputDocument()
        {
            ParseableInputDocumentDelegate handler = ParseableInputDocument;
            if (handler != null) handler();
        }

        /**
         * 
         */

        protected virtual void OnOpenInputDocument(FileInfo fileInfo, byte[] content)
        {
            SetContent(fileInfo, content);
            InputDocumentOpenDelegate handler = OpenInputDocument;
            if (handler != null) handler(fileInfo, content);
        }

        /**
         * 
         */

        public void SetContent(FileInfo fileInfo, byte[] content)
        {
            OnBeginOpenDocument();
            _documentName = fileInfo.Name;
            _extension = fileInfo.Extension;
            _content = content;
            if (!string.IsNullOrWhiteSpace(_extension))
                _extension = _extension.ToLower();
            if (IsNavigatable())
                OnNavigatableInputDocument();
            if (IsParsible())
                OnParseableInputDocument();
        }

        /**
         * 
         */

        public void OpenReaderDocument()
        {
            try
            {
                OnBeginOpenDocument();
                //edtReaderInput.Text = getTPSIFile(out documentName);
                if (OpenInputFile(out _fileInfo, out _content))
                {
                    _documentName = _fileInfo.Name;
                    _extension = _fileInfo.Extension.ToLower();
                    bool ok2Open = true;

                    if (IsNavigatable())
                        OnNavigatableInputDocument();

                    if (IsParsible())
                    {
                        string tpsName = GetTPSName();
                        if (!string.IsNullOrEmpty(tpsName))
                        {
                            //Check to see if there is an open project
                            if (ProjectManager.HasOpenProject())
                            {
                                string projectName = ProjectManager.ProjectName;
                                if (projectName == tpsName)
                                {
                                }
                                else
                                {
                                    //If the project does not match the tps name ask user 
                                    //  if they would like to create a new project or add the 
                                    ProjectInfo pi = new ProjectInfo();
                                    pi.ProjectName = tpsName;
                                    ProjectManager.CreateProject(pi);
                                }
                                //Check to see if the project name matches the tps name
                                //  document to the current project if one is open
                            }
                            else
                            {
                                //If no project exists create one
                                if (ProjectManager.HasProject(tpsName))
                                {
                                    ProjectManager.OpenProject(tpsName);
                                }
                                else
                                {
                                    ProjectInfo pi = new ProjectInfo();
                                    pi.ProjectName = tpsName;
                                    ProjectManager.CreateProject(pi);
                                }
                            }
                        }
                    }

                    //------------------------------------------------------------------------------//
                    //--- Check if the document is in the current test set, if not ask to add it ---//
                    //------------------------------------------------------------------------------//
                    bool hasReaderDocument = ProjectManager.HasReaderDocument(_documentName);
                    if (hasReaderDocument)
                    {
                        ok2Open = false;
                        if (DialogResult.Yes ==
                            MessageBox.Show(
                                @"This file already exists as a reader document. Would you like to replace it?",
                                @"V E R I F Y",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question))
                        {
                            ok2Open = true;
                        }
                    }
                    if (ok2Open)
                    {
                        if (!hasReaderDocument && DialogResult.Yes ==
                            MessageBox.Show(
                                string.Format(
                                    @"Would you like store this document as a reader document in the {0} project?",
                                    ProjectManager.ProjectName),
                                @"V E R I F Y",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question))
                        {
                            ProjectManager.SaveReaderDocument(_documentName, _content);
                        }
                        OnOpenInputDocument(_fileInfo, _content);
                        if (IsParsible())
                            OnParseableInputDocument();
                    }
                }

                LogManager.SourceTrace( SOURCE, "Reader Input File \"{0}\" opened. ", _documentName);
            }
            catch (Exception err)
            {
                LogManager.SourceError(SOURCE, err);
            }
        }

        /**
         * 
         */

        private string GetTPSName()
        {
            string tpsiName = null;
            Stream stream = new MemoryStream(_content);
            var doc = new XPathDocument(stream);
            XPathNavigator nav = doc.CreateNavigator();
            nav.MoveToFollowing(XPathNodeType.Element);
            IDictionary<string, string> namespaces = nav.GetNamespacesInScope(XmlNamespaceScope.All);
            XPathExpression query = nav.Compile("/tpsi:CASS_MTPSI/tpsi:CASS_MTPSI_page/tpsi:UUT/tpsi:UUT_ID");
            var mngr = new XmlNamespaceManager(new NameTable());
            foreach (var nskvp in namespaces)
            {
                mngr.AddNamespace(nskvp.Key, nskvp.Value);
                if (nskvp.Key == "")
                    mngr.AddNamespace("tpsi", nskvp.Value);
            }
            //mngr.AddNamespace("bk", "urn:MyNamespace");
            query.SetContext(mngr);
            XPathNodeIterator xPathIt = nav.Select(query);
            if (xPathIt.Count > 0)
            {
                if (xPathIt.MoveNext())
                {
                    XPathNavigator curNav = xPathIt.Current;
                    if (curNav.HasAttributes)
                    {
                        tpsiName = curNav.GetAttribute("TPS_Name", "");
                        LogManager.SourceTrace(SOURCE,"TPS Name: " + tpsiName);
                    }
                }
            }
            return tpsiName;
        }

        private bool OpenInputFile(out FileInfo fileInfo, out byte[] content)
        {
            return FileManager.OpenFile(out content, out fileInfo);
        }

        /**
         * 
         */

        public void TranslateInputDocument()
        {
            if (_content != null && IsParsible())
            {
                try
                {
                    //---------------------------------//
                    //--- Setup XML reader settings ---//
                    //---------------------------------//
                    ValidationEventHandler validationHandler = (s, ee) => LogManager.SourceError(SOURCE, ee.Exception);
                    var settings = new XmlReaderSettings();
                    settings.ValidationType = ValidationType.None;
                    settings.ValidationFlags = XmlSchemaValidationFlags.None;
                    settings.ValidationEventHandler += validationHandler;

                    string content = Encoding.UTF8.GetString(_content);
                    if (string.IsNullOrWhiteSpace(content))
                        return;
                    using (var sr = new StringReader(content))
                    {
                        using (XmlReader xrXml = new XmlTextReader(sr))
                        {

                            var doc = new XPathDocument(xrXml);

                            string xsdName = SchemaManager.GetSchemaName(Encoding.UTF8.GetString(_content));
                            string xslName = xsdName.Replace(".xsd", ".xsl");

                            StringReader xslReader = GetXSLReader(xslName);
                            var xr = new XmlTextReader(xslReader);
                            var xslt = new XslCompiledTransform();
                            xslt.Load(xr);

                            //--------------------------------------------------------------------------//
                            //--- Create an XsltArgumentList for custom transformation functionality ---//
                            //--------------------------------------------------------------------------//
                            var xslArg = new XsltArgumentList();
                            var fileName = ProjectManager.ProjectName + ATMLContext.ATML_CONFIG_FILENAME_SUFFIX;
                            xslArg.AddParam("documentName", "", fileName );

                            // Add an object to calculate the new book price.
                            var obj = new ReaderTools();
                            //TODO: Figure out all the functionality required for translation
                            xslArg.AddExtensionObject("urn:utrs.atml-reader-tools", obj);

                            //---------------------------//
                            //--- Transform the file. ---//
                            //---------------------------//
                            using (var w = new StringWriter())
                            {
                                var stringBuilder = new StringBuilder();
                                var xws = new XmlWriterSettings();
                                xws.OmitXmlDeclaration = true;
                                xws.Indent = true;
                                xws.NewLineOnAttributes = false;
                                xws.NamespaceHandling = NamespaceHandling.OmitDuplicates;
                                using (XmlWriter xmlWriter = XmlWriter.Create(stringBuilder, xws))
                                {
                                    xslt.Transform(doc, xslArg, xmlWriter);
                                    LogManager.SourceTrace(SOURCE, "ATML translation Completed");
                                    try
                                    {
                                        Console.Write(stringBuilder.ToString());
                                        _testConfiguration = TestConfiguration15.Deserialize(stringBuilder.ToString());
                                    }
                                    catch (Exception e)
                                    {
                                        LogManager.SourceError(SOURCE,
                                            "An error has occurred attempting to marshall the translated document into an ATML Test Configuration object.",
                                            e);
                                    }
                                    OnTranslatedInputDocument(_testConfiguration);
                                }
                            }
                        }
                    }
                }
                catch (Exception ee)
                {
                    LogManager.SourceError(SOURCE, ee, "An error has occurred attempting to process the input document.");
                }
            }
        }

        /**
         * 
         */

        private static StringReader GetXSLReader(string xslName)
        {
            //-------------------------------------------//
            //--- Lookup the document in the database ---//
            //-------------------------------------------//
            int idx = xslName.LastIndexOf("\\");
            if (idx != -1)
                xslName = xslName.Substring(idx + 1);
            Document document = DocumentManager.GetDocument(xslName.ToLower(), 14);
            if (document == null)
                throw new Exception(string.Format("Failed to find XSL style sheet {0}", xslName));
            LogManager.SourceTrace(SOURCE, string.Format("Loading XSL Style Sheet {0}", xslName));
            var xslReader = new StringReader(StringUtils.RemoveByteOrderMarkUTF8(Encoding.UTF8.GetString(document.DocumentContent)));
            return xslReader;
        }


        /**
         * 
         */

        public bool IsParsible()
        {
            return (ParsibleDocumentExtensions.Contains(_extension) && _content.Length > 0);
        }

        /**
         * 
         */

        public bool IsNavigatable()
        {
            return (NavigableDocumentExtensions.Contains(_extension));
        }
    }

    /**
     * 
     */

    public class ReaderTools
    {
        private const string RF = "RF";
        private const string CNI = "CNI";
        private const string EO = "EO";
        private const string HPDTS = "HPDTS";
        private const string SGMA = "SGMA";
        private const string HYBRID = "HYBRID";
        private const string RTCASS = "RTCASS";
        private const string CASS = "CASS";
        private const string ECASS = "ECASS";

        private const string PromptToCreateInstrument =
            "An Instrument was not found for Part Number \"{0}.\" Would you like to create one?";

        private const string FailedToFindInstrument =
            "Failed to find instrument {0}";

        private const string ErrorSavingDocument =
            "An error has occurred attempting to save the Document information.\nError:{0}";

        private const string ErrorSavingInstrument =
            "An error has occurred attempting to save the Instrument information for part number \"{0}.\"\nError:{1}";

        private const string ErrorLocatingTestStation =
            "Failed to location Test Station for uuid: {0}";

        private const string AssetTypePart = "Part";

        /**
         * 
         */

        public string CreateUuid()
        {
            LogManager.SourceTrace(ATMLReader.SOURCE, "Creating new UUID");
            string guid = Guid.NewGuid().ToString();
            //TODO: Need to see if a configuration is open and if so use that uuid.
            return guid;
        }


        /**
         * 
         */

        public string LookupUUTByPartNumber(string partNumber)
        {
            string refUUID = "";

            return refUUID;
        }

        /**
         * 
         */

        public string CreateUUT(string partNumber,
            string tpsName, string ofpSwitchPin,
            string swNo, string testType, string nomen,
            string model, string system, string refDes,
            string wuc, string tpm, string tm, string tec)
        {
            return "Need To Implement This";
        }

        /**
         * 
         */

        public string GetDocumentReference(string partNumber, string docType)
        {
            return GetDocumentReference(partNumber, docType, null, null, null);
        }

        /**
         * 
         */

        public string GetDocumentReference(string partNumber, string docType, string description, string assetType,
            string contentType)
        {
            string refUUID = "";
            try
            {
                //Document is a Other type Asset.
                AssetIdentificationBean asset = DocumentManager.FindAsset(assetType, partNumber);
                if (asset != null)
                    refUUID = asset.uuid.ToString();
                else
                    refUUID = DocumentManager.CreateDocumentPlaceHolder(partNumber, assetType, contentType, docType,
                                                                        description);
            }
            catch (Exception e)
            {
                LogManager.SourceError(ATMLReader.SOURCE, ErrorSavingDocument,
                                 e.Message);
            }
            return refUUID;
        }

        /**
         * Determine the Reference UUID for the UUT Part Number provided.
         * @parameter partNumber the part number of the UUT
         * @parameter tpsName the name of the Test Program Set
         * @parameter ofpSwitchPin
         * @parameter swNo
         * @parameter testType
         * @parameter nomen
         * @parameter model
         * @parameter system
         * @parameter refDes
         * @parameter wuc
         * @parameter tpm
         * @parameter tm
         * @parameter tec
         * 
         */

        public string GetUUTReferenceId(string partNumber, string tpsName, string ofpSwitchPin,
            string swNo, string testType, string nomen, string model,
            string system, string refDes, string wuc, string tpm, string tm, string tec)
        {
            string refUUID = "";
            try
            {
                //UUT is a Model Number type Asset.
                //TODO: Verify that this is correct: UUT - if no model then use part no
                if (string.IsNullOrWhiteSpace(model))
                    model = partNumber;

                AssetIdentificationBean asset = DocumentManager.FindAsset("Model", model);
                if (asset != null)
                    refUUID = asset.uuid.ToString();
                else
                {
                    string prompt =
                        string.Format("A UUT was not found for Model Number \"{0}\" - Would you like to create one?",
                                      model);
                    if (DialogResult.Yes ==
                        MessageBox.Show(prompt, @"V E R I F Y", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        refUUID = UUTController.Instance.Create(partNumber, nomen, model);
                    }
                }
            }
            catch (Exception e)
            {
                LogManager.SourceError(ATMLReader.SOURCE, "An error has occurred attempting to save the UUT information.\nError:{0}", e.Message);
            }
            return refUUID;
        }

        /**
         * Lookup the Instrument by the part number and test station in the asset table.
         */

        public static String FindInstrumentReference(string partNumber, string stationId)
        {
            string referenceId = "";
            try
            {
                IAtmlController<TestStationDescription11> controller = AtmlControllerFactory<TestStationDescription11>.Controller;
                TestStationDescription11 testStation = controller.Find(Guid.Parse(stationId));
                if (testStation == null)
                    throw new Exception(string.Format(ErrorLocatingTestStation, stationId));
                string stationType = testStation.Identification.ModelName;
                string basePartNumber = partNumber.Split('#')[0];
                string fullPartNumber = stationType + "." + basePartNumber;
                string combinedPartNumber = stationType + "." + partNumber; //--- has "#xxx"
                string instrumentName = fullPartNumber + ATMLContext.ATML_INSTRUMENT_FILENAME_SUFFIX;

                //--------------------------------------------------------------------------------------------------------//
                //--- TODO: Need to adjust this process
                //---       Strip the #xxx off
                //---       Prefix it with the station name 
                //---       Check if instrument is in database - if not create a placeholder
                //---       Get instrument uuid for reference
                //---       Using the original part number (ie with #xxx) make sure its associated with the test station
                //---       This will provide quantities of an instrument via #xxx
                //--------------------------------------------------------------------------------------------------------//

                //-----------------------------------------//
                //--- Look for an asset in the database ---//
                //-----------------------------------------//
                AssetIdentificationBean asset = DocumentManager.FindAsset(AssetTypePart, combinedPartNumber);
                if (asset != null)
                {
                        //-----------------------------//
                        //--- Grab the reference id ---//
                        //-----------------------------//
                        referenceId = asset.uuid.ToString();
                }
                else
                {
                    //--- Lookup Document by Instrument Id ---//
                    Document document = DocumentManager.GetDocumentByName( instrumentName );
                    if (document == null)
                    {
                        //--- We should only prompt if the base part number is missing ---//
                        referenceId = PromptUserToAddInstrument(basePartNumber, stationType, referenceId);
                    }
                    else
                    {
                        referenceId = document.uuid;
                        CreateAsset( referenceId, combinedPartNumber );
                    }
                }

                //-------------------------------------------------------------------------------------------------------//
                //--- Let see if the test station has a reference to the instrument instance, if no we need to add it ---//
                //-------------------------------------------------------------------------------------------------------//
                if (!AtmlControllerFactory<TestStationDescription11>.Controller.HasInstrumentReference(testStation, partNumber))
                {
                    //InstrumentDescription instrument = InstrumentController.FindInstrument(partNumber);
                    AtmlControllerFactory<TestStationDescription11>.Controller.AddInstrumentReference(testStation as TestStationDescription11, partNumber,
                                                                 referenceId );
                }
            }
            catch (Exception e)
            {
                LogManager.SourceError(ATMLReader.SOURCE, ErrorSavingInstrument, partNumber, e.Message);
            }
            return referenceId;
        }

        private static void CreateAsset( string referenceId, string combinedPartNumber )
        {
            AssetIdentificationBean asset;
            asset = new AssetIdentificationBean();
            asset.uuid = Guid.Parse( referenceId );
            asset.assetType = "Part";
            asset.assetNumber = combinedPartNumber;
            asset.DataState = BASEBean.eDataState.DS_ADD;
            asset.save();
        }

        private static string PromptUserToAddInstrument(string basePartNumber, string stationType, string referenceId)
        {
            string prompt =
                string.Format(
                    PromptToCreateInstrument,
                    basePartNumber);
            if (DialogResult.Yes ==
                MessageBox.Show(prompt, @"V E R I F Y", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                InstrumentDescription instrument = InstrumentController.CreateInstrument(basePartNumber,
                                                                                         stationType);
                if (instrument == null)
                    throw new Exception(string.Format(FailedToFindInstrument, basePartNumber));
                referenceId = instrument.uuid;
            }
            return referenceId;
        }

        /**
         * 
         */

        public string InitializeTestStaion(string stationType,
            string station,
            string changeNo,
            string dateEntry,
            string fst)
        {
            string refNo = "";
            bool usesRF = false;
            bool usesCNI = false;
            bool usesEO = false;
            bool usesHPDTS = false;
            bool usesSGMA = false;
            bool isHybrid = false;
            bool isRTCass = false;
            bool isECass = false;

            stationType = stationType.ToUpper();
            station = station.ToUpper();

            if (string.IsNullOrWhiteSpace(station))
                station = CASS;

            if (string.IsNullOrWhiteSpace(stationType))
                stationType = station;

            usesRF = stationType.Contains(RF);
            usesCNI = stationType.Contains(CNI);
            usesEO = stationType.Contains(EO);
            usesHPDTS = stationType.Contains(HPDTS);
            usesSGMA = stationType.Contains(SGMA);
            isHybrid = stationType.Contains(HYBRID);
            isRTCass = stationType.Contains(RTCASS);
            isECass = stationType.Contains(ECASS);

            if (!isRTCass && stationType.Contains(CASS))
                station = CASS;
            else if (isRTCass)
                station = RTCASS;
            else if (isECass)
                station = ECASS;
            else if (isHybrid)
                station = HYBRID;

            if (usesRF)
                station = station + "_" + RF;
            if (usesCNI)
                station = station + "_" + CNI;
            if (usesEO)
                station = station + "_" + EO;
            if (usesHPDTS)
                station = station + "_" + HPDTS;
            if (usesSGMA)
                station = station + "_" + SGMA;

            const string assetType = "Model";
            const string contentType = "text/xml";
            string documentType = Enum.GetName(typeof (dbDocument.DocumentType),
                                               dbDocument.DocumentType.TEST_STATION_DESCRIPTION);

            AssetIdentificationBean asset = DocumentManager.FindAsset(assetType, station);
            if (asset != null)
            {
                refNo = asset.uuid.ToString();
            }
            else
            {
                refNo = DocumentManager.CreateDocumentPlaceHolder
                    (
                        station, //Part Number
                        assetType, //Asset Type
                        contentType, //Content Type
                        documentType, //Document Type
                        station + " 1671.6 Test Station Description" //Description
                    );
                var ts = new TestStationDescription11();
                ts.Identification = new ItemDescriptionIdentification();
                ts.name = station;
                ts.uuid = refNo;
                ts.Identification.ModelName = station;
                Document document = DocumentManager.GetDocument(refNo);
                document.DocumentContent = Encoding.UTF8.GetBytes(ts.Serialize());
                DocumentManager.SaveDocument(document);
            }

            return refNo;
        }

        /**
         * 
         */

        public string LookupReferenceByPartNumber(string partNumber, string className)
        {
            string refUUID = "";
            DocumentDAO dao = DataManager.getDocumentDAO();
            AssetIdentificationBean asset = dao.FindAsset(AssetTypePart, partNumber);
            if (asset == null)
            {
                string uuid = Guid.NewGuid().ToString();
                var id = new ItemDescriptionIdentification();
                var idNo = new ManufacturerIdentificationNumber();
                idNo.type = IdentificationNumberType.Part;
                idNo.number = partNumber;
                id.IdentificationNumbers = new List<IdentificationNumber>();
                id.IdentificationNumbers.Add(idNo);
                id.ModelName = partNumber;

                string test1 = idNo.Serialize();
                string test2 = id.Serialize();


                LogManager.SourceError(ATMLReader.SOURCE, "Failed to locate asset for part number: {0} ", partNumber);
                Type _type = Type.GetType(className + ",ATMLModelLibrary");
                if (_type == null)
                    LogManager.SourceError(ATMLReader.SOURCE, "Invalid Class Name: {0}", className);
                else
                {
                    object obj = Activator.CreateInstance(_type);
                    PropertyInfo pi = _type.GetProperty("uuid");
                    if (pi == null)
                        LogManager.SourceError(ATMLReader.SOURCE, "Class Name: {0} does not support the uuid property.", className);
                    else
                    {
                        pi.SetValue(obj, uuid, null);
                    }
                    PropertyInfo piId = _type.GetProperty("Identification");
                    if (piId == null)
                    {
                        //check to see if there is an Item property and if the Item property is an ItemDescription type
                        piId = _type.GetProperty("Item");
                        if (piId != null)
                            piId = piId.GetType().GetProperty("Identification");
                        if (piId == null)
                            LogManager.SourceError(ATMLReader.SOURCE, "Class Name: {0} does not support the Identification property.", className);
                        else
                        {
                            piId.SetValue(obj, id, null);
                        }
                    }
                    else
                    {
                        piId.SetValue(obj, id, null);
                    }

                    MethodInfo mi = _type.GetMethod("Save");
                    if (mi == null)
                        LogManager.SourceError(ATMLReader.SOURCE, "Class Name: {0} does not support a save() method.", className);
                    else
                    {
                        mi.Invoke(obj, null);
                        refUUID = uuid;
                        LogManager.SourceInfo(ATMLReader.SOURCE, "*** A Part Document has been created for part number: {0}.", partNumber);
                    }
                }
            }
            else
            {
                refUUID = asset.uuid.ToString();
            }

            return refUUID;
        }
    }
}