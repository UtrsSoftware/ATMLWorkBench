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
using ATMLCommonLibrary.forms;
using ATMLCommonLibrary.Properties;
using ATMLDataAccessLibrary.model;
using ATMLManagerLibrary.delegates;
using ATMLManagerLibrary.interfaces;
using ATMLManagerLibrary.managers;
using ATMLModelLibrary.interfaces;
using ATMLModelLibrary.model.common;
using ATMLModelLibrary.model.uut;

namespace ATMLCommonLibrary.controls.uut
{
    public partial class UUTDescriptionListControl : ATMLLibraryListControl, IAtmlActionable
    {
        private List<UUTDescription> _uutDescriptions = new List<UUTDescription>();

        public UUTDescriptionListControl()
        {
            InitializeComponent();
            InitListView();
            if (!this.IsInDesignMode())
            {
                LoadList();
            }

            CompletedAdd += delegate( object o )
                            {
                                var obj = o as UUTDescription;
                                if (obj != null)
                                {
                                    OnAtmlObjectAction( obj, AtmlActionType.Add );
                                }
                            };

            CompletedEdit += delegate( object o )
                             {
                                 var obj = o as UUTDescription;
                                 if (obj != null)
                                 {
                                     OnAtmlObjectAction( obj, AtmlActionType.Edit );
                                 }
                             };

            CompletedDelete += delegate( object o )
                               {
                                   var obj = o as UUTDescription;
                                   if (obj != null)
                                   {
                                       OnAtmlObjectAction( obj, AtmlActionType.Delete );
                                   }
                                   //TODO: Remove it from the local project if its open?
                               };
        }

        [Browsable( false ), DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
        public List<UUTDescription> UUTDescriptions
        {
            get
            {
                ControlsToData();
                return _uutDescriptions;
            }
            set
            {
                _uutDescriptions = value;
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

        public void RefreshList()
        {
            LoadList();
        }

        protected override void LoadList()
        {
            Clear();
            _uutDescriptions.Clear();
            List<Document> instruments =
                DocumentManager.GetDocumentsByType( (int) dbDocument.DocumentType.UUT_DESCRIPTION );
            foreach (Document document in instruments)
            {
                try
                {
                    UUTDescription ud = UUTDescription.Deserialize( Encoding.UTF8.GetString( document.DocumentContent ) );
                    _uutDescriptions.Add( ud );
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


        public override void ApplyFilter( string filterString )
        {
            base.ApplyFilter( filterString );
            Items.Clear();
            DataToControls();
        }

        private void InitListView()
        {
            ListName = "UUT Description";
            DataObjectName = "UUTDescription";
            DataObjectFormType = typeof (UUTDescriptionForm);
            AddColumnData( "UUT", "ToString()", 1.00 );
            InitColumns();
        }

        private void DataToControls()
        {
            if (_uutDescriptions != null)
            {
                lvList.Items.Clear();
                foreach (UUTDescription obj in _uutDescriptions)
                {
                    AddListViewObject( obj );
                }
            }
        }

        private void ControlsToData()
        {
            _uutDescriptions = null;
            if (lvList.Items.Count > 0)
            {
                _uutDescriptions = new List<UUTDescription>();
                foreach (ListViewItem lvi in lvList.Items)
                {
                    var obj = (UUTDescription) lvi.Tag;
                    _uutDescriptions.Add( obj );
                }
            }
        }
    }
}