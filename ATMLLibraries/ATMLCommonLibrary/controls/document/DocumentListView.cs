/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using ATMLModelLibrary.model.common;

namespace ATMLCommonLibrary.controls.document
{
    public partial class DocumentListView : ListView
    {
        private List<Document> _documents = new List<Document>();
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<Document> Documents
        {
            get { ControlsToData();  return _documents.Count>0 ? _documents: null ; }
            set { _documents.Clear(); if( value != null ) _documents.AddRange( value ); DataToControls(); }
        }

        public DocumentListView()
        {
            InitializeComponent();
            InitColumns();
        }

        public DocumentListView(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            InitColumns();
        }

        public void AddDocument(Document document)
        {
            if (_documents == null)
                _documents = new List<Document>();
            _documents.Add(document);
            ListViewItem item = new ListViewItem(document.name);
            item.SubItems.Add(document.version);
            item.Tag = document;
            Items.Add(item);
        }

        public void UpdateDocument(Document document, ListViewItem item)
        {
            if (_documents == null)
                _documents = new List<Document>();
            item.SubItems[0].Text = document.name;
            item.SubItems[1].Text = document.version;
            item.Tag = document;
        }

        public Document SelectedDocument()
        {
            Document document = null;
            if( SelectedItems.Count > 0 )
                document = SelectedItems[0].Tag as Document;
            return document;
        }

        public void DeleteDocument(Document document)
        {
            _documents.Remove(document);
        }

        private void DataToControls()
        {
            if( _documents != null )
            {
                foreach( Document document in _documents )
                {
                    var item = new ListViewItem(document.name);
                    item.SubItems.Add(document.version);
                    item.Tag = document;
                    Items.Add(item);
                }
            }
        }

        private void ControlsToData()
        {
        }

        private void InitColumns()
        {
            Columns.Add("Name");
            Columns.Add("Version");
            Columns[0].Width = 200;
        }
    }
}
