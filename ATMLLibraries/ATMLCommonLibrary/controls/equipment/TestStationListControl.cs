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
using System.Text;
using System.Windows.Forms;
using System.Xml;
using ATMLCommonLibrary.controls.lists;
using ATMLDataAccessLibrary.model;
using ATMLManagerLibrary.delegates;
using ATMLManagerLibrary.interfaces;
using ATMLManagerLibrary.managers;
using ATMLModelLibrary.interfaces;
using ATMLModelLibrary.model.common;
using ATMLModelLibrary.model.equipment;
using Resources = ATMLCommonLibrary.Properties.Resources;

namespace ATMLCommonLibrary.controls.equipment
{
    public partial class TestStationListControl : ATMLLibraryListControl, IAtmlActionable
    {
        private List<TestStationDescription11> _testStationDescriptions = new List<TestStationDescription11>();

        public TestStationListControl()
        {
            InitializeComponent();
            InitListView();

            //CompletedAdd += TestStationListControl_CompletedAdd;
            //CompletedEdit += TestStationListControl_CompletedEdit;

            CompletedAdd += delegate( object o ) { CallAtmlAction( o, AtmlActionType.Add ); };
            CompletedEdit += delegate( object o ) { CallAtmlAction( o, AtmlActionType.Edit ); };
            CompletedDelete += delegate( object o ) { CallAtmlAction( o, AtmlActionType.Delete ); };

            if (!this.IsInDesignMode())
            {
                LoadList();
            }
        }

        protected override void LoadList()
        {
            Clear();
            _testStationDescriptions.Clear();
            List<Document> instruments =
                DocumentManager.GetDocumentsByType( (int) dbDocument.DocumentType.TEST_STATION_DESCRIPTION );
            foreach (Document document in instruments)
            {
                try
                {
                    _testStationDescriptions.Add(
                        TestStationDescription11.Deserialize(
                            Encoding.UTF8.GetString( document.DocumentContent ).Replace( '\0', ' ' ).Trim() ) );
                }
                catch (Exception e)
                {
                    string msg = "";
                    try
                    {
                        var d = new XmlDocument();
                        d.LoadXml( Encoding.UTF8.GetString( document.DocumentContent ) );
                    }
                    catch (Exception ex)
                    {
                        msg = ex.Message;
                        if (ex.InnerException != null)
                            msg += Resources.HTML_BR + ex.InnerException.Message;
                    }
                    LogManager.Error( Resources.Deserialize_document_error, document.name, msg );
                }
            }
            DataToControls();
        }

        [Browsable( false ), DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
        public List<TestStationDescription11> TestStationDescriptions
        {
            get
            {
                ControlsToData();
                return _testStationDescriptions;
            }
            set
            {
                _testStationDescriptions = value;
                DataToControls();
            }
        }

        public event AtmlActionDeligate<IAtmlObject> AtmlObjectAction;

        protected virtual IAtmlObject OnAtmlObjectAction( IAtmlObject obj, AtmlActionType actiontype )
        {
            IAtmlObject results = null;
            AtmlActionDeligate<IAtmlObject> handler = AtmlObjectAction;
            if (handler != null) results = handler( obj, actiontype, EventArgs.Empty );
            return results;
        }


        private void CallAtmlAction( object o, AtmlActionType type )
        {
            var id = o as TestStationDescription11;
            if (id != null)
            {
                OnAtmlObjectAction( id, type );
            }
        }


        /*
        private void TestStationListControl_CompletedEdit(object obj)
        {
            var testStation = obj as TestStationDescription11;
            if (testStation != null)
            {
                Document document = DocumentManager.GetDocument(testStation.uuid);
                if (document == null)
                {
                    document = new Document();
                    document.uuid = string.IsNullOrEmpty(testStation.uuid)
                        ? Guid.NewGuid().ToString()
                        : testStation.uuid;
                    document.ContentType = "text/xml";
                    document.DocumentType = dbDocument.DocumentType.TEST_STATION_DESCRIPTION;
                    document.DataState = BASEBean.eDataState.DS_ADD;
                }
                else
                {
                    document.DataState = BASEBean.eDataState.DS_EDIT;
                }
                document.name = testStation.name;
                document.Description = testStation.Description;
                document.DocumentContent = Encoding.UTF8.GetBytes(testStation.Serialize());
                DocumentManager.SaveDocument(document);
                //------------------------------------//
                //--- Save Capabilities Separately ---//
                //------------------------------------//
                if (testStation.Capabilities != null && testStation.Capabilities.Items != null)
                {
                    foreach (object item in testStation.Capabilities.Items)
                    {
                        var capability = item as Capability;
                        if (capability != null)
                        {
                            PersistanceController.Save(capability);
                        }
                    }
                }
            }
        }

        private void TestStationListControl_CompletedAdd(object obj)
        {
        }
        */

        public override void ApplyFilter( string filterString )
        {
            base.ApplyFilter( filterString );
            Items.Clear();
            DataToControls();
        }

        private void InitListView()
        {
            ListName = "Test Station";
            DataObjectName = "TestStationDescription";
            DataObjectFormType = typeof (TestStationForm);
            AddColumnData( "Test Station", "ToString()", 1.00 );
            InitColumns();
        }

        private void DataToControls()
        {
            if (_testStationDescriptions != null)
            {
                lvList.Items.Clear();
                foreach (TestStationDescription11 obj in _testStationDescriptions)
                {
                    AddListViewObject( obj );
                }
            }
        }

        private void ControlsToData()
        {
            _testStationDescriptions = null;
            if (lvList.Items.Count > 0)
            {
                _testStationDescriptions = new List<TestStationDescription11>();
                foreach (ListViewItem lvi in lvList.Items)
                {
                    var obj = (TestStationDescription11) lvi.Tag;
                    _testStationDescriptions.Add( obj );
                }
            }
        }
    }
}