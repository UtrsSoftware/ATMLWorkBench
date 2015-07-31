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
using System.Windows.Forms;
using ATMLCommonLibrary.controls.lists;
using ATMLCommonLibrary.forms;
using ATMLModelLibrary.model.common;
using ATMLUtilitiesLibrary;

namespace ATMLCommonLibrary.controls
{
    public partial class IndentificationNumbersListControl : ATMLListControl
    {
        private List<IdentificationNumber> _identificationNumbers;

        public IndentificationNumbersListControl()
        {
            InitializeComponent();
            InitListView();
        }


        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<IdentificationNumber> IdentificationNumbers
        {
            get
            {
                ControlsToData();
                return (_identificationNumbers != null && _identificationNumbers.Count == 0)
                    ? null
                    : _identificationNumbers;
            }
            set
            {
                _identificationNumbers = value;
                DataToControls();
            }
        }

        private void InitListView()
        {
            //DataObjectName = "IdentificationNumber";
            //DataObjectFormType = typeof(IdentificationNumberForm);
            btnAdd.ToolTipText = @"Press to add a new Identification Number";
            btnEdit.ToolTipText = @"Press to edit the selected Identification Number";
            btnDelete.ToolTipText = @"Press to delete the selected Identification Number";

            AddColumnData("Type", "type", .20);
            AddColumnData("Number", "number", .20);
            AddColumnData("Type", "type", .20);
            AddColumnData("Qualifier", "ToString()", .20);
            AddColumnData("Manufacturer", "ToString()", .20);
            OnAdd += IndentificationNumbersListControl_OnAdd;
            OnDelete += IndentificationNumbersListControl_OnDelete;
            OnEdit += IndentificationNumbersListControl_OnEdit;
            InitColumns();
        }

        public void DataToControls()
        {
            if (_identificationNumbers != null)
            {
                Items.Clear();
                foreach (IdentificationNumber number in _identificationNumbers)
                {
                    String idType = "";
                    if (number is ManufacturerIdentificationNumber)
                        idType = "MFR";
                    else if (number is UserDefinedIdentificationNumber)
                        idType = "USR";

                    var item = new ListViewItem(idType);
                    item.SubItems.Add(number.number);
                    item.SubItems.Add(Enum.GetName(typeof (IdentificationNumberType), number.type));
                    item.SubItems.Add(number is UserDefinedIdentificationNumber
                        ? ((UserDefinedIdentificationNumber) number).qualifier
                        : "");
                    if (number is ManufacturerIdentificationNumber)
                        item.SubItems.Add(((ManufacturerIdentificationNumber) number).manufacturerName);
                    else
                        item.SubItems.Add("");

                    item.Tag = number;
                    Items.Add(item);
                    item.BackColor = item.Index % 2 == 0 ? ATMLContext.COLOR_LIST_EVEN : ATMLContext.COLOR_LIST_ODD;
                }
            }
        }

        public void ControlsToData()
        {
            if (Items.Count == 0)
                _identificationNumbers = null;
            else
            {
                if (_identificationNumbers == null)
                    _identificationNumbers = new List<IdentificationNumber>();
                _identificationNumbers.Clear();
                foreach (ListViewItem lvi in Items)
                {
                    _identificationNumbers.Add(lvi.Tag as IdentificationNumber);
                }
            }
        }

        private void IndentificationNumbersListControl_OnAdd()
        {
            var form = new IdentificationNumberForm();
            form.IdentificationNumber = new IdentificationNumber();
            if (DialogResult.OK == form.ShowDialog())
            {
                IdentificationNumber id = form.IdentificationNumber;
                String idType = "";
                if (id is ManufacturerIdentificationNumber)
                    idType = "MFR";
                else if (id is UserDefinedIdentificationNumber)
                    idType = "USR";

                var lvi = new ListViewItem(idType);
                lvi.SubItems.Add(id.number);
                lvi.SubItems.Add(id.type.ToString());
                lvi.SubItems.Add(id is UserDefinedIdentificationNumber
                    ? ((UserDefinedIdentificationNumber) id).qualifier
                    : "");
                if (id is ManufacturerIdentificationNumber)
                    lvi.SubItems.Add(((ManufacturerIdentificationNumber)id).manufacturerName);
                else
                    lvi.SubItems.Add("");
                lvi.Tag = id;
                Items.Add(lvi);
                if (_identificationNumbers == null)
                    _identificationNumbers = new List<IdentificationNumber>();
                _identificationNumbers.Add(id);
                lvi.BackColor = lvi.Index % 2 == 0 ? ATMLContext.COLOR_LIST_EVEN : ATMLContext.COLOR_LIST_ODD;
            }
        }

        private void IndentificationNumbersListControl_OnEdit()
        {
            if (SelectedItems.Count > 0)
            {
                var id = (IdentificationNumber) SelectedItems[0].Tag;
                var form = new IdentificationNumberForm();
                form.IdentificationNumber = id;
                RegisterForm(form);
                form.Closed += delegate(object sndr, EventArgs ee)
                {
                    IdentificationNumberForm frm = sndr as IdentificationNumberForm;
                    UnRegisterForm(frm);
                    if (DialogResult.OK == frm.DialogResult )
                    {
                        id = frm.IdentificationNumber;
                        String idType = "";
                        if (id is ManufacturerIdentificationNumber)
                            idType = "MFR";
                        else if (id is UserDefinedIdentificationNumber)
                            idType = "USR";

                        ListViewItem lvi = SelectedItems[0];
                        lvi.SubItems[0].Text = idType;
                        lvi.SubItems[1].Text = id.number;
                        lvi.SubItems[2].Text = id.type.ToString();
                        lvi.SubItems[3].Text = id is UserDefinedIdentificationNumber
                            ? ((UserDefinedIdentificationNumber) id).qualifier
                            : "";
                        if (id is ManufacturerIdentificationNumber)
                            lvi.SubItems[4].Text = ((ManufacturerIdentificationNumber)id).manufacturerName;
                        else
                            lvi.SubItems[4].Text = "";
                        lvi.Tag = id;
                    }
                };
                form.Show();
            }
        }

        private void IndentificationNumbersListControl_OnDelete()
        {
            if (SelectedItems.Count > 0)
            {
                if (DialogResult.Yes == MessageBox.Show(@"Are you sure you want to delete this Identification Number?",
                    @"Delete Identification Number",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question))
                {
                    var id = (IdentificationNumber) SelectedItems[0].Tag;
                    Items.RemoveAt(SelectedItems[0].Index);
                    _identificationNumbers.Remove(id);
                }
            }
            foreach (ListViewItem lvi in Items)
                lvi.BackColor = lvi.Index % 2 == 0 ? ATMLContext.COLOR_LIST_EVEN : ATMLContext.COLOR_LIST_ODD;
        }
    }
}