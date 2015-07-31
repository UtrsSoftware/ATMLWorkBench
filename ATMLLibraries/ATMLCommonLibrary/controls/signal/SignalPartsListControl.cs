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
using System.Windows.Forms;
using System.Xml;
using ATMLCommonLibrary.controls.lists;
using ATMLCommonLibrary.forms;
using ATMLModelLibrary.model.signal.basic;

namespace ATMLCommonLibrary.controls.signal
{
    public partial class SignalPartsListControl : ATMLListControl
    {
        private List<object> _signalItems;

        public SignalPartsListControl()
        {
            InitializeComponent();
            InitListView();
            InitializeForm += SignalPartsListControl_InitializeForm;
            OnAdd += AddSignalPart;
            OnEdit += EditSignalPart;
            OnDelete += DeleteSignalPart;
            AllowRowResequencing = true;
            SequenceChanged += SignalPartsListControl_SequenceChanged;
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<object> SignalItems
        {
            get
            {
                ControlsToData();
                return _signalItems;
            }
            set
            {
                _signalItems = value;
                DataToControls();
            }
        }

        private void SignalPartsListControl_InitializeForm(Form form)
        {
            var stf = form as SignalFunctionTypeForm;
            if (stf != null)
            {
                stf.AvailableSignalParts.Clear();
                foreach (ListViewItem lvi in lvList.Items)
                {
                    stf.AvailableSignalParts.Add(lvi.SubItems[1].Text);
                }
            }
        }

        private void SignalPartsListControl_SequenceChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem item in Items)
            {
                item.BackColor = item.Index%2 == 0 ? Color.LightGreen : Color.White;
            }
        }


        public void Clear()
        {
            if (_signalItems != null)
                _signalItems.Clear();
            lvList.Items.Clear();
        }


        private void InitListView()
        {
            //DataObjectName = "SignalFunctionType";
            DataObjectFormType = typeof (SignalFunctionTypeForm);
            AddColumnData("Signal", "Name", .25);
            AddColumnData("Name", "name", .25);
            AddColumnData("Type", "type", .25);
            AddColumnData("Inputs", "In", .25);
            InitColumns();
        }

        private void ControlsToData()
        {
            if (Items.Count > 0)
            {
                if (_signalItems == null)
                    _signalItems = new List<object>();
                _signalItems.Clear();
                foreach (ListViewItem item in lvList.Items)
                {
                    _signalItems.Add(item.Tag);
                }
            }
        }

        private void DataToControls()
        {
            if (_signalItems != null)
            {
                Items.Clear();
                foreach (object obj in _signalItems)
                {
                    //if( obj is SignalFunctionType )
                    {
                        AddSignalPart(obj);
                    }
                }
            }
        }


        public void AddSignalPart(object signalType)
        {
            if (signalType is SignalFunctionType)
            {
                var item = new ListViewItem(signalType.GetType().Name);
                item.SubItems.Add(((SignalFunctionType) signalType).name);
                item.SubItems.Add(((SignalFunctionType) signalType).type);
                item.SubItems.Add(((SignalFunctionType) signalType).In);
                item.Tag = signalType;
                item = Items.Add(item);
                if (item.Index%2 == 0)
                {
                    item.BackColor = Color.LightGreen;
                }
                else
                {
                    item.BackColor = Color.White;
                }
            }
            else if (signalType is XmlElement)
            {
                var item = new ListViewItem(((XmlElement) signalType).LocalName);
                item.SubItems.Add((((XmlElement) signalType).HasAttribute("name"))
                    ? ((XmlElement) signalType).GetAttribute("name")
                    : "");
                item.SubItems.Add((((XmlElement) signalType).HasAttribute("type"))
                    ? ((XmlElement) signalType).GetAttribute("type")
                    : "");
                item.SubItems.Add((((XmlElement) signalType).HasAttribute("In"))
                    ? ((XmlElement) signalType).GetAttribute("In")
                    : "");
                item.Tag = signalType;
                item = Items.Add(item);
                if (item.Index%2 == 0)
                {
                    item.BackColor = Color.LightGreen;
                }
                else
                {
                    item.BackColor = Color.White;
                }
            }
        }


        private void AddSignalPart()
        {
            object sft = null;
            var form = new SignalFunctionTypeForm();
            SetAvailableParts(form);
            if (DialogResult.OK == form.ShowDialog())
            {
                sft = form.SignalFunctionType;
                AddSignalPart(sft);
            }
        }

        private void SetAvailableParts(SignalFunctionTypeForm form)
        {
            form.AvailableSignalParts.Clear();
            foreach (ListViewItem lvi in lvList.Items)
            {
                form.AvailableSignalParts.Add(lvi.SubItems[1].Text);
            }
        }

        private void EditSignalPart()
        {
            if (SelectedItems.Count > 0)
            {
                object sft = SelectedItems[0].Tag;
                var form = new SignalFunctionTypeForm();
                form.SignalFunctionType = sft;
                SetAvailableParts(form);
                if (DialogResult.OK == form.ShowDialog())
                {
                    sft = form.SignalFunctionType;
                    SelectedItems[0].Tag = sft;
                    var signalType = sft as SignalFunctionType;
                    var el = sft as XmlElement;
                    if (signalType != null)
                    {
                        SelectedItems[0].SubItems[0].Text = signalType.GetType().Name;
                        SelectedItems[0].SubItems[1].Text = signalType.name;
                        SelectedItems[0].SubItems[2].Text = signalType.type;
                        SelectedItems[0].SubItems[3].Text = signalType.In;
                    }
                    else if (el != null)
                    {
                        var item = new ListViewItem(el.LocalName);
                        item.SubItems.Add((el.HasAttribute("name"))
                            ? el.GetAttribute("name")
                            : "");
                        item.SubItems.Add((el.HasAttribute("type"))
                            ? el.GetAttribute("type")
                            : "");
                        item.SubItems.Add((el.HasAttribute("In"))
                            ? el.GetAttribute("In")
                            : "");
                        item.Tag = el;
                    }
                }
            }
        }

        private void DeleteSignalPart()
        {
        }
    }
}