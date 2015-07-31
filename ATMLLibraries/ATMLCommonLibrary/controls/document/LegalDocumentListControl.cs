/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
using System;
using System.Text;
using System.Windows.Forms;
using ATMLCommonLibrary.controls.lists;
using ATMLCommonLibrary.managers;
using ATMLManagerLibrary.managers;
using ATMLModelLibrary.model.common;
using ATMLModelLibrary.model.equipment;
using ATMLSchemaLibrary.managers;

namespace ATMLCommonLibrary.controls.document
{
    public partial class LegalDocumentListControl : ATMLListControl
    {
        private HardwareItemDescriptionLegalDocuments _legalDocuments;

        public LegalDocumentListControl()
        {
            InitializeComponent();
            InitListView();
            lvList.Resize += lvList_Resize;
            OnAdd += LegalDocumentListControl_OnAdd;
            OnEdit += LegalDocumentListControl_OnEdit;
            OnDelete += LegalDocumentListControl_OnDelete;
        }

        public HardwareItemDescriptionLegalDocuments LegalDocuments
        {
            get
            {
                ControlsToData();
                return _legalDocuments;
            }
            set
            {
                _legalDocuments = value;
                DataToControls();
            }
        }

        private void DataToControls()
        {
            if (_legalDocuments != null)
            {
                if (_legalDocuments.Items != null)
                {
                    if (_legalDocuments.Items.Length != _legalDocuments.ItemsElementName.Length)
                        throw new Exception("Inconsistant Data");
                    lvList.Items.Clear();
                    for (int i = 0; i < _legalDocuments.Items.Length; i++)
                    {
                        Document document = _legalDocuments.Items[i];
                        document.LegalDocumentType = _legalDocuments.ItemsElementName[i];
                        var lvi =
                            new ListViewItem(Enum.GetName(
                                typeof (HardwareItemDescriptionLegalDocumentsItemsChoiceType),
                                document.LegalDocumentType));
                        lvi.SubItems.Add(document.name);
                        lvi.SubItems.Add(document.version);
                        lvi.Tag = document;
                        lvList.Items.Add(lvi);
                    }
                }
            }
        }

        private void ControlsToData()
        {
            if (lvList.Items.Count > 0)
            {
                if (_legalDocuments == null)
                    _legalDocuments = new HardwareItemDescriptionLegalDocuments();

                var documents = new Document[lvList.Items.Count];
                var types =
                    new HardwareItemDescriptionLegalDocumentsItemsChoiceType[lvList.Items.Count];
                int idx = 0;
                foreach (ListViewItem lvi in lvList.Items)
                {
                    var document = (Document) lvi.Tag;
                    if (document != null)
                    {
                        documents[idx] = document;
                        types[idx++] = document.LegalDocumentType;
                    }
                }

                if (documents.Length == 0)
                    documents = null;
                if (types.Length == 0)
                    types = null;
                _legalDocuments.Items = documents;
                _legalDocuments.ItemsElementName = types;
            }
            else
            {
                _legalDocuments = null;
            }
        }

        private void LegalDocumentListControl_OnDelete()
        {
            if (HasSelected)
            {
                var document = SelectedObject as Document;
                if (document != null)
                {
                    String prompt = MessageManager.getMessage(MessageManager.GENERIC_DELETE_PROMPT);
                    String title = MessageManager.getMessage(MessageManager.GENERIC_TITLE_VERIFICATION);
                    if (DialogResult.Yes == MessageBox.Show(String.Format(prompt, "Legal Document", document.name),
                        title,
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question))
                    {
                        lvList.Items.Remove(SelectedListViewItem);
                    }
                }
            }
        }

        private void LegalDocumentListControl_OnEdit()
        {
            if (HasSelected)
            {
                var document = SelectedObject as Document;
                if (document != null)
                {
                    var form = new LegalDocumentForm(document);
                    if (DialogResult.OK == form.ShowDialog())
                    {
                        document = form.LegalDocument;
                        ListViewItem lvi = SelectedListViewItem;
                        lvi.SubItems[0].Text =
                            Enum.GetName(typeof (HardwareItemDescriptionLegalDocumentsItemsChoiceType),
                                document.LegalDocumentType);
                        lvi.SubItems[1].Text = document.name;
                        lvi.SubItems[2].Text = document.version;
                        lvi.Tag = document;
                    }
                }
            }
        }

        private void LegalDocumentListControl_OnAdd()
        {
            var document = new Document();
            var form = new LegalDocumentForm(document);
            if (DialogResult.OK == form.ShowDialog())
            {
                document = form.LegalDocument;
                var lvi = new ListViewItem();
                lvi.SubItems[0].Text = Enum.GetName(typeof (HardwareItemDescriptionLegalDocumentsItemsChoiceType),
                    document.LegalDocumentType);
                lvi.SubItems.Add(document.name);
                lvi.SubItems.Add(document.version);
                lvi.Tag = document;
                lvList.Items.Add(lvi);
            }
        }

        private void lvList_Resize(object sender, EventArgs e)
        {
            SetColumnSize();
        }

        private void InitListView()
        {
            lvList.Columns.Add("Type");
            lvList.Columns.Add("Name");
            lvList.Columns.Add("Version");
            SetColumnSize();
        }

        private void SetColumnSize()
        {
            SetDistributedColumnWidths(new[] {.20, .60, .20});
        }

        public bool Validate(out string error)
        {
            error = null;
            bool isValid = true;
            var sb = new StringBuilder();
            if (_legalDocuments.Items != null)
            {
                foreach (var document in _legalDocuments.Items)
                {
                    var svr = new SchemaValidationResult();
                    isValid &= document.Validate(svr);
                    if (svr.HasErrors())
                        sb.Append( svr.ErrorMessage ).Append( ", " );
                }
                if (sb.ToString().EndsWith( ", " ))
                    sb.Length = sb.Length - 2;
                error = sb.ToString();
            }
            return isValid;
        }

    }
}