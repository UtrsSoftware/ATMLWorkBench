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
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.control.language
{
    public partial class ControlLanguageListControl : ATMLListControl
    {
        private List<ControlLanguage> _controlLanguage = new List<ControlLanguage>();

        public ControlLanguageListControl()
        {
            InitializeComponent();
            InitListView();
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<ControlLanguage> ControlLanguages
        {
            get
            {
                ControlsToData();
                return (_controlLanguage != null && _controlLanguage.Count == 0) ? null : _controlLanguage;
            }
            set
            {
                _controlLanguage = value;
                DataToControls();
            }
        }

        private void InitListView()
        {
            DataObjectName = "ControlLanguage";
            DataObjectFormType = typeof (ControlLanguageForm);
            AddColumnData("Control Language", "ToString()", 1);
            InitColumns();
        }

        private void DataToControls()
        {
            if (_controlLanguage != null)
            {
                lvList.Items.Clear();
                foreach (ControlLanguage obj in _controlLanguage)
                {
                    AddListViewObject(obj);
                }
            }
        }

        private void ControlsToData()
        {
            _controlLanguage = null;
            if (lvList.Items.Count > 0)
            {
                _controlLanguage = new List<ControlLanguage>();
                foreach (ListViewItem lvi in lvList.Items)
                {
                    var obj = (ControlLanguage) lvi.Tag;
                    _controlLanguage.Add(obj);
                }
            }
        }
    }
}