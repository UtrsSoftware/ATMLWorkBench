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
using ATML1671Reader.forms;
using ATMLCommonLibrary.controls.lists;
using ATMLModelLibrary.model.common;

namespace ATML1671Reader.controls
{
    public partial class TpsSoftwareReferenceListControl : ATMLListControl
    {
        private List<ConfigurationSoftwareReference> _softwareReferences = new List<ConfigurationSoftwareReference>();

        public TpsSoftwareReferenceListControl()
        {
            InitializeComponent();
            InitListView();
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<ConfigurationSoftwareReference> ConfigurationSoftwareReferences
        {
            set
            {
                _softwareReferences = value;
                DataToControls();
            }
            get
            {
                ControlsToData();
                return _softwareReferences;
            }
        }

        private void InitListView()
        {
            DataObjectName = "ConfigurationSoftwareReference";
            DataObjectFormType = typeof (TPSSoftwareReferenceForm);
            AddColumnData("Value", "ToString()", 1.00);
            InitColumns();
        }

        private void DataToControls()
        {
            if (_softwareReferences != null)
            {
                lvList.Items.Clear();
                foreach (ConfigurationSoftwareReference resource in _softwareReferences)
                {
                    AddListViewObject(resource);
                }
            }
        }

        private void ControlsToData()
        {
            _softwareReferences = null;
            if (lvList.Items.Count > 0)
            {
                _softwareReferences = new List<ConfigurationSoftwareReference>();
                foreach (ListViewItem lvi in lvList.Items)
                {
                    var resource = (ConfigurationSoftwareReference) lvi.Tag;
                    _softwareReferences.Add(resource);
                }
            }
        }
    }
}