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
using ATMLDataAccessLibrary.model;
using ATMLManagerLibrary.delegates;
using ATMLManagerLibrary.interfaces;
using ATMLManagerLibrary.managers;
using ATMLModelLibrary.interfaces;
using ATMLModelLibrary.model.common;
using ATMLModelLibrary.model.equipment;
using Resources = ATMLCommonLibrary.Properties.Resources;

namespace ATMLCommonLibrary.controls.instrument
{
    public partial class InstrumentListControl : ATMLLibraryListControl, IAtmlActionable
    {
        private List<InstrumentDescription> _instrumentDescriptions = new List<InstrumentDescription>();

        public InstrumentListControl()
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
            InitializeForm += delegate( Form form )
                              {
                                  var atmlForm = form as ATMLForm;
                                  if (atmlForm != null) atmlForm.CloseOnSave = false;
                              };
        }

        protected override void LoadList()
        {
            Clear();
            _instrumentDescriptions.Clear();
            List<Document> instruments =
                DocumentManager.GetDocumentsByType( (int) dbDocument.DocumentType.INSTRUMENT_DESCRIPTION );
            foreach (Document document in instruments)
            {
                try
                {
                    InstrumentDescription id =
                        InstrumentDescription.Deserialize( Encoding.UTF8.GetString( document.DocumentContent ) );
                    _instrumentDescriptions.Add( id );
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
        public List<InstrumentDescription> InstrumentDescriptions
        {
            get
            {
                ControlsToData();
                return _instrumentDescriptions;
            }
            set
            {
                _instrumentDescriptions = value;
                DataToControls();
            }
        }

        public event AtmlActionDeligate<IAtmlObject> AtmlObjectAction;

        private void CallAtmlAction( object o, AtmlActionType type )
        {
            var id = o as InstrumentDescription;
            if (id != null)
            {
                OnAtmlObjectAction( id, type );
            }
        }

        protected virtual IAtmlObject OnAtmlObjectAction( IAtmlObject obj, AtmlActionType actiontype )
        {
            IAtmlObject results = null;
            AtmlActionDeligate<IAtmlObject> handler = AtmlObjectAction;
            if (handler != null) results = handler( obj, actiontype, EventArgs.Empty );
            return results;
        }

        public override void ApplyFilter( string filterString )
        {
            base.ApplyFilter( filterString );
            Items.Clear();
            DataToControls();
        }

        private void InitListView()
        {
            ListName = "Instrument Description";
            DataObjectName = "InstrumentDescription";
            DataObjectFormType = typeof (InstrumentForm);
            AddColumnData( "Instrument", "ToString()", 1.00 );
            InitColumns();
        }

        private void DataToControls()
        {
            if (_instrumentDescriptions != null)
            {
                lvList.Items.Clear();
                foreach (InstrumentDescription obj in _instrumentDescriptions)
                {
                    AddListViewObject( obj );
                }
            }
        }

        private void ControlsToData()
        {
            _instrumentDescriptions = null;
            if (lvList.Items.Count > 0)
            {
                _instrumentDescriptions = new List<InstrumentDescription>();
                foreach (ListViewItem lvi in lvList.Items)
                {
                    var obj = (InstrumentDescription) lvi.Tag;
                    _instrumentDescriptions.Add( obj );
                    obj.ToString();
                }
            }
        }
    }
}