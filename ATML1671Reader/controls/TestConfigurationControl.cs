/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using ATML1671Reader.reader;
using ATMLCommonLibrary.controls;
using ATMLCommonLibrary.controls.document;
using ATMLCommonLibrary.forms;
using ATMLCommonLibrary.managers;
using ATMLCommonLibrary.model;
using ATMLDataAccessLibrary.model;
using ATMLManagerLibrary.delegates;
using ATMLManagerLibrary.managers;
using ATMLModelLibrary.interfaces;
using ATMLModelLibrary.model;
using ATMLModelLibrary.model.common;
using ATMLModelLibrary.model.uut;
using ATMLProject.managers;
using ATMLUtilitiesLibrary;
using Ionic.Crc;

namespace ATML1671Reader.controls
{
    public delegate void TestConfigurationSaveHandler(TestConfiguration15 testConfiguration);

    public partial class TestConfigurationControl : ATMLControl, IATMLDockableWindow
    {
        //private readonly Timer _refeshTimer;
        private readonly List<ITestConfigurationChangeListener> _changeListeners =
            new List<ITestConfigurationChangeListener>();

        private readonly Color _clrReadOnly = Color.Honeydew;
        private readonly Color _clrWrite = Color.White;

        private readonly List<TestConfigurationDocumentation> _tpsDocumentation =
            new List<TestConfigurationDocumentation>();

        private readonly List<ConfigurationResourceReference> _tpsResourceReferences =
            new List<ConfigurationResourceReference>();

        private readonly List<ConfigurationSoftwareReference> _tpsSoftwareReferences =
            new List<ConfigurationSoftwareReference>();

        private bool _editMode = true;
        private TestConfiguration15 _testConfiguration;

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TestConfiguration15 TestConfiguration
        {
            get
            {
                ControlsToData();
                return _testConfiguration;
            }
            set
            {
                _testConfiguration = value;
                DataToControls();
                if (value != null)
                    UndoBuffer = _testConfiguration.Serialize();
                //_refeshTimer.Start();
            }
        }

        #region Events

        public event TestConfigurationSaveHandler TestConfigurationSaved;
        public event AtmlActionDeligate<IAtmlObject> AtmlObjectAction;

        protected virtual void OnAtmlAction(IAtmlObject obj, AtmlActionType actiontype)
        {
            AtmlActionDeligate<IAtmlObject> handler = AtmlObjectAction;
            if (handler != null) handler(obj, actiontype, EventArgs.Empty);
        }

        protected virtual void OnTestConfigurationSaved(TestConfiguration15 testconfiguration)
        {
            TestConfigurationSaveHandler handler = TestConfigurationSaved;
            if (handler != null) handler(testconfiguration);
        }

        #endregion

        #region Constructors

        public TestConfigurationControl()
        {
            InitializeComponent();

            InitControls();
            InitUutList();
            InitDocumentationList();
            SetControlStates();
            //Enabled = false;

            //_refeshTimer = new Timer();
            //_refeshTimer.Interval = 1000;
            //_refeshTimer.Tick+=delegate( object sender, EventArgs args ) { btnUndo.Visible = IsDirty(); };
            btnUndo.Visible = true;

        }

        #endregion Constructors

        #region Data Binding

        private void DataToControls()
        {
            if (_testConfiguration != null)
            {
                UndoBuffer = _testConfiguration.Serialize();
                //Enabled = true;
                edtUUID.Value = _testConfiguration.uuid;
                securityClassificationControl.Classified = _testConfiguration.classified;
                securityClassificationControl.SecurityClassification = _testConfiguration.securityClassification;
                manufacturerControl1.ManufacturerData = _testConfiguration.ConfigurationManager;
                tpsAdditionalResourceReferenceListControl.ConfigurationResourceReferences
                    = _testConfiguration.AdditionalResources;
                tpsAdditionalSoftwareReferenceListControl.ConfigurationSoftwareReferences
                    = _testConfiguration.AdditionalSoftware;
                LoadUUTs(_testConfiguration.TestedUUTs);
                LoadTestEquipment(_testConfiguration.TestEquipment);
                LoadTestProgramElement();
            }
        }

        private void ControlsToData()
        {
            if (_testConfiguration == null)
                _testConfiguration = new TestConfiguration15();
            if (_testConfiguration.ConfigurationManager == null)
                _testConfiguration.ConfigurationManager = new ManufacturerData();
            _testConfiguration.uuid = edtUUID.GetValue<string>();
            _testConfiguration.ConfigurationManager = manufacturerControl1.ManufacturerData;
            _testConfiguration.classified = securityClassificationControl.Classified;
            _testConfiguration.securityClassification = securityClassificationControl.SecurityClassification;
            _testConfiguration.TestProgramElements = new List<object>();
            //TPS Tab

                //-------------------------------//
                //--- Add Resource References ---//
                //-------------------------------//
                if (tpsResourceReferenceListControl.ConfigurationResourceReferences != null)
                    _testConfiguration.TestProgramElements.AddRange(tpsResourceReferenceListControl.ConfigurationResourceReferences);

                //-------------------------------//
                //--- Add Software References ---//
                //-------------------------------//
                if (tpsSoftwareReferenceListControl.ConfigurationSoftwareReferences != null)
                    _testConfiguration.TestProgramElements.AddRange(tpsSoftwareReferenceListControl.ConfigurationSoftwareReferences);

                //-------------------------------//
                //--- Add Document References ---//
                //-------------------------------//
                if (testProgramDocumentationListControl.TestConfigurationDocumentation != null)
                    _testConfiguration.TestProgramElements.AddRange(testProgramDocumentationListControl.TestConfigurationDocumentation);
            
            
            //--------------------------------//
            //--- Add Additional Resources ---//
            //--------------------------------//
            _testConfiguration.AdditionalResources =
                tpsAdditionalResourceReferenceListControl.ConfigurationResourceReferences;
            //------------------------------//
            //--- Add Addtional Software ---//
            //------------------------------//
            _testConfiguration.AdditionalSoftware =
                tpsAdditionalSoftwareReferenceListControl.ConfigurationSoftwareReferences;

            //--------------------------//
            //--- Add UUT References ---//
            //--------------------------//
            _testConfiguration.TestedUUTs.Clear();
            foreach (ListViewItem lvi in uutListControl.Items)
                _testConfiguration.TestedUUTs.Add(lvi.Tag as ItemDescriptionReference );

            //-----------------------------------//
            //--- Add Test Station References ---//
            //-----------------------------------//
            _testConfiguration.TestEquipment.Clear();
            _testConfiguration.TestEquipment = testStationReferenceControl.TestEquipment;
            _testConfiguration.AtmlName = ProjectManager.ProjectName;
            UndoBuffer = _testConfiguration.Serialize();
        }

        #endregion Data Binding

        public bool IsDirty()
        {
            bool dirtyFlag = false;
            if (_testConfiguration != null )
                dirtyFlag = !_testConfiguration.Serialize().Equals(UndoBuffer);
            return dirtyFlag;
        }

        public void CloseProject()
        {
            ClearControls();
            Enabled = false;
        }

        private void LoadTestProgramElement()
        {
            if (_testConfiguration.TestProgramElements != null)
            {
                _tpsDocumentation.Clear();
                _tpsResourceReferences.Clear();
                _tpsSoftwareReferences.Clear();
                foreach (object testProgramElement in _testConfiguration.TestProgramElements)
                {
                    var doc = testProgramElement as TestConfigurationDocumentation;
                    var res = testProgramElement as ConfigurationResourceReference;
                    var sft = testProgramElement as ConfigurationSoftwareReference;
                    if (doc != null)
                        _tpsDocumentation.Add(doc);
                    if (res != null)
                        _tpsResourceReferences.Add(res);
                    if (sft != null)
                        _tpsSoftwareReferences.Add(sft);
                }
                tpsResourceReferenceListControl.ConfigurationResourceReferences = _tpsResourceReferences;
                tpsSoftwareReferenceListControl.ConfigurationSoftwareReferences = _tpsSoftwareReferences;
                testProgramDocumentationListControl.TestConfigurationDocumentation = _tpsDocumentation;
            }
        }

        private void LoadTestEquipment(List<TestConfigurationTestEquipmentItem> testEquipment)
        {
            testStationReferenceControl.TestEquipment = testEquipment;
        }

        private void AddItemDescription(ItemDescriptionReference idr)
        {
            string partNo = "";
            var id = idr.Item as ItemDescription;
            if (id != null)
            {
                var lvi = new ListViewItem(id.Identification != null ? id.Identification.ModelName : "");
                if (id.Identification != null && id.Identification.IdentificationNumbers != null &&
                    id.Identification.IdentificationNumbers.Count > 0)
                    partNo = id.Identification.IdentificationNumbers[0].number;
                lvi.SubItems.Add(partNo);
                lvi.SubItems.Add(id.name);
                lvi.Tag = idr;
                uutListControl.Items.Add(lvi);
            }
        }

        public void AddChangeListener(ITestConfigurationChangeListener listener)
        {
            _changeListeners.Add(listener);
        }

        private void SetControlStates()
        {
            //--- Set Edit Mode ---//
            manufacturerControl1.Enabled = _editMode;
            edtUUID.Enabled = _editMode;

            //--- Set Edit Color ---//
            edtUUID.BackColor = _editMode ? _clrWrite : _clrReadOnly;
            btnSaveConfiguration.Visible = _editMode;
            btnUndo.Visible = _editMode;
        }


        private void ClearControls()
        {
            Clear();
            _testConfiguration = null;
            //if (_refeshTimer != null)
            //    _refeshTimer.Stop();
        }

        private void InitDocumentationList()
        {
            //contactListControl.Columns.Add("Name");
            //contactListControl.Columns.Add("UUID");
            //contactListControl.Columns[0].Width = -2;
            //contactListControl.Columns[1].Width = -2;
        }


        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes ==
                MessageBox.Show( @"Undo your changes?", 
                                 @"V E R I F I C A T I O N", 
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question ))
            {
                if (!string.IsNullOrEmpty( UndoBuffer ))
                {
                    _testConfiguration = TestConfiguration15.Deserialize( UndoBuffer );
                    DataToControls();
                    SetControlStates();
                }
            }
        }

        private void btnSaveConfiguration_Click(object sender, EventArgs e)
        {
            //_editMode = false;
            //ControlsToData();
            SetControlStates();
            //OnAtmlAction(TestConfiguration, AtmlActionType.Edit);
            if (uutListControl.Items.Count > 0)
            {
                var lvi = uutListControl.Items[0];
                var uutRef = lvi.Tag as ItemDescriptionReference;
                if (uutRef != null)
                {
                    var pi = ProjectManager.ProjectInfo;
                    var itemDescription = uutRef.Item as ItemDescription;
                    var docRef = uutRef.Item as DocumentReference;
                    if (itemDescription != null)
                    {
                        pi.UutName = itemDescription.Identification.ModelName;
                        pi.UutId = null;
                    }
                    else if (docRef != null)
                    {
                        UUTDescription uut = UutManager.FindUut( uutRef );
                        pi.UutName = uut.name;
                        pi.UutId = uut.uuid;
                    }
                    ProjectManager.ProjectInfo = pi;
                }
            }
            OnTestConfigurationSaved(TestConfiguration);
        }

        private void btnCreateUUID_Click(object sender, EventArgs e)
        {
            edtUUID.Value = Guid.NewGuid().ToString();
        }

        #region UUT Related Functionality

        private void InitUutList()
        {
            uutListControl.DataObjectName = "ItemDescriptionReference";
            uutListControl.DataObjectFormType = typeof(ItemDescriptionReferenceForm);
            uutListControl.AddColumnData("UUT", "ToString()", 1.00);
            uutListControl.InitColumns();
            uutListControl.OnFind += uutListControl_OnFind;
            uutListControl.ShowFind = true;
        }

        private void uutListControl_OnFind()
        {
            var selectedUUTs = new List<string>();
            foreach (ListViewItem lvi in uutListControl.Items)
            {
                var itemRef = lvi.Tag as ItemDescriptionReference;
                if (itemRef != null)
                {
                    var docRef = itemRef.Item as DocumentReference;
                    if (docRef != null)
                    {
                        selectedUUTs.Add(docRef.uuid);
                    }
                }
            }
            var form = new DocumentLibrarySelectionForm(selectedUUTs, dbDocument.DocumentType.UUT_DESCRIPTION);
            if (DialogResult.OK == form.ShowDialog())
            {
                Document document = form.SelectedDocument;
                if (document != null)
                {
                    try
                    {
                        UUTDescription uut = UUTDescription.Deserialize(document.Item);
                        if (uut != null)
                        {
                            AddUutDocumentReference(uut);
                        }
                    }
                    catch (Exception e)
                    {
                        LogManager.SourceError(ATMLReader.SOURCE, e);
                    }
                }
            }
        }

        private void LoadUUTs(IEnumerable<ItemDescriptionReference> testedUUTs)
        {
            uutListControl.Items.Clear();

            if (testedUUTs != null)
            {
                foreach (ItemDescriptionReference idr in testedUUTs)
                {
                    uutListControl.AddListViewObject( idr );
                }
            }
        }

        private void AddUutDocumentReference(ItemDescriptionReference idr)
        {
            string model = "";
            string partNo = "";

            var id = idr.Item as DocumentReference;
            if (id != null)
            {
                Document document = DocumentManager.GetDocument(id.uuid);
                if (document != null)
                {
                    string content =
                        StringUtils.RemoveByteOrderMarkUTF8(Encoding.UTF8.GetString(document.DocumentContent));
                    UUTDescription uut = UUTDescription.Deserialize(content);
                    if (uut != null)
                    {
                        model = GetIdentity(uut.Item, model, ref partNo);
                    }
                    var lvi = new ListViewItem(model);
                    lvi.SubItems.Add(partNo);
                    lvi.SubItems.Add(id.uuid);
                    lvi.Tag = idr;
                    uutListControl.Items.Add(lvi);
                }
            }
        }

        private void AddUutDocumentReference(UUTDescription uut)
        {
            var docRef = new DocumentReference();
            var document = DocumentManager.GetDocument(uut.uuid);
            docRef.ID = "UUT" + uutListControl.Items.Count+1;
            docRef.uuid = uut.uuid;
            docRef.DocumentType = document.DocumentType;
            docRef.DocumentContent = document.DocumentContent;
            docRef.ContentType = document.ContentType;
            docRef.DocumentName = document.name;
            var idr = new ItemDescriptionReference {Item = docRef};
            uutListControl.AddListViewObject( idr );
        }


        private static string GetIdentity(ItemDescription itemDescription, string model, ref string partNo)
        {
            if (itemDescription != null && itemDescription.Identification != null)
            {
                model = itemDescription.Identification.ModelName;
                if (itemDescription.Identification.IdentificationNumbers != null
                    && itemDescription.Identification.IdentificationNumbers.Count > 0)
                    partNo = itemDescription.Identification.IdentificationNumbers[0].number;
            }
            return model;
        }


        #endregion UUT Related Functionality

        private void uutListControl_Load(object sender, EventArgs e)
        {

        }

    }
}