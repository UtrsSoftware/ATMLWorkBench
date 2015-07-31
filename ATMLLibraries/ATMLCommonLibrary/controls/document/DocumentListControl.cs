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
using ATMLCommonLibrary.controls.lists;
using ATMLModelLibrary.model.common;
using ATMLDataAccessLibrary.model;

namespace ATMLCommonLibrary.controls.document
{
    /**
     * The Document List Control maintains the the logic for adding, editing and deleting documents within an ATML specific object.
     */

    public partial class DocumentListControl : ATMLListControl
    {
        private dbDocument.DocumentType _documentType;

        private List<Document> _documents;

        public DocumentListControl()
        {
            InitializeComponent();
            InitListView();
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<Document> Documents
        {
            get
            {
                ControlsToData();
                return _documents != null && _documents.Count > 0 ? _documents : null;
            }
            set
            {
                _documents = value;
                DataToControls();
            }
        }

        public dbDocument.DocumentType DocumentType
        {
            get { return _documentType; }
            set { _documentType = value; }
        }

        private void InitListView()
        {
            DataObjectName = "Document";
            DataObjectFormType = typeof (DocumentForm);
            AddColumnData("Name", "name", .25);
            AddColumnData("Version", "version", .25);
            InitializeForm += DocumentListControl_InitializeForm;
            InitColumns();
        }

        private void DocumentListControl_InitializeForm(Form form)
        {
            var df = form as DocumentForm;
            if (df != null)
            {
                df.DocumentType = _documentType;
            }
        }

        private void DataToControls()
        {
            if (_documents != null)
            {
                lvList.Items.Clear();
                foreach (Document document in _documents)
                {
                    AddListViewObject(document);
                }
            }
        }

        private void ControlsToData()
        {
            _documents = null;
            if (lvList.Items.Count > 0)
            {
                _documents = new List<Document>();
                foreach (ListViewItem lvi in lvList.Items)
                {
                    var document = (Document) lvi.Tag;
                    _documents.Add(document);
                }
            }
        }
    }
}