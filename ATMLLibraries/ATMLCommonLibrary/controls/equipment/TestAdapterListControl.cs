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
    public partial class TestAdapterListControl : ATMLLibraryListControl, IAtmlActionable
    {
        private List<TestAdapterDescription1> _testAdapterDescriptions = new List<TestAdapterDescription1>();

        public TestAdapterListControl()
        {
            InitializeComponent();
            InitListView();
            if (!this.IsInDesignMode())
            {
                LoadList();
            }
            CompletedAdd += delegate( object o ) { CallAtmlAction( o, AtmlActionType.Add ); };
            CompletedEdit += delegate( object o ) { CallAtmlAction( o, AtmlActionType.Edit ); };
            CompletedDelete += delegate( object o ) { CallAtmlAction( o, AtmlActionType.Delete ); };
        }

        protected override void LoadList()
        {
            Clear();
            _testAdapterDescriptions.Clear();
            List<Document> instruments =
                DocumentManager.GetDocumentsByType( (int) dbDocument.DocumentType.TEST_ADAPTER_DESCRIPTION );
            foreach (Document document in instruments)
            {
                try
                {
                    TestAdapterDescription1 ta =
                        TestAdapterDescription1.Deserialize( Encoding.UTF8.GetString( document.DocumentContent ) );
                    _testAdapterDescriptions.Add( ta );
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
        public List<TestAdapterDescription1> TestAdapterDescriptions
        {
            get
            {
                ControlsToData();
                return _testAdapterDescriptions;
            }
            set
            {
                _testAdapterDescriptions = value;
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
            var id = o as TestAdapterDescription1;
            if (id != null)
            {
                OnAtmlObjectAction( id, type );
            }
        }

        private void InitListView()
        {
            ListName = "Test Adapter";
            DataObjectName = "TestAdapterDescription";
            DataObjectFormType = typeof (TestAdapterForm);
            AddColumnData( "Test Adapter", "ToString()", 1.00 );
            InitColumns();
        }

        private void DataToControls()
        {
            if (_testAdapterDescriptions != null)
            {
                lvList.Items.Clear();
                foreach (TestAdapterDescription1 obj in _testAdapterDescriptions)
                {
                    AddListViewObject( obj );
                }
            }
        }

        private void ControlsToData()
        {
            _testAdapterDescriptions = null;
            if (lvList.Items.Count > 0)
            {
                _testAdapterDescriptions = new List<TestAdapterDescription1>();
                foreach (ListViewItem lvi in lvList.Items)
                {
                    var obj = (TestAdapterDescription1) lvi.Tag;
                    _testAdapterDescriptions.Add( obj );
                }
            }
        }
    }
}