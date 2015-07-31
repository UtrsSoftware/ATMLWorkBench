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
    public partial class TpsResourceReferenceListControl : ATMLListControl
    {
        private List<ConfigurationResourceReference> _configurationResourceReferences =
            new List<ConfigurationResourceReference>();

        public TpsResourceReferenceListControl()
        {
            InitializeComponent();
            InitListView();
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<ConfigurationResourceReference> ConfigurationResourceReferences
        {
            get
            {
                ControlsToData();
                return _configurationResourceReferences;
            }
            set
            {
                _configurationResourceReferences = value;
                DataToControls();
            }
        }

        private void InitListView()
        {
            DataObjectName = "ConfigurationResourceReference";
            DataObjectFormType = typeof (TPSResourceReferenceForm);
            AddColumnData("Qty", "quantity", .20);
            AddColumnData("Value", "ToString()", .80);
            InitColumns();
        }

        private void DataToControls()
        {
            if (_configurationResourceReferences != null)
            {
                lvList.Items.Clear();
                foreach (ConfigurationResourceReference resource in _configurationResourceReferences)
                {
                    AddListViewObject(resource);
                }
            }
        }

        private void ControlsToData()
        {
            _configurationResourceReferences = null;
            if (lvList.Items.Count > 0)
            {
                _configurationResourceReferences = new List<ConfigurationResourceReference>();
                foreach (ListViewItem lvi in lvList.Items)
                {
                    var resource = (ConfigurationResourceReference) lvi.Tag;
                    _configurationResourceReferences.Add(resource);
                }
            }
        }
    }
}