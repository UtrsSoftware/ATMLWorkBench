/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System.Collections.Generic;
using System.Windows.Forms;
using ATMLCommonLibrary.controls.lists;
using ATMLCommonLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.hardware
{
    public partial class VersionIdentifierListControl : ATMLListControl
    {
        private List<VersionIdentifier> _versionIdentifiers;

        public VersionIdentifierListControl()
        {
            InitializeComponent();
            InitListView();
        }

        public List<VersionIdentifier> VersionIdentifiers
        {
            get
            {
                ControlsToData();
                return _versionIdentifiers;
            }
            set
            {
                _versionIdentifiers = value;
                DataToControls();
            }
        }

        private void InitListView()
        {
            DataObjectName = "VersionIdentifier";
            DataObjectFormType = typeof (VersionIdentifierForm);
            AddColumnData("Name", "name", .40);
            AddColumnData("Version", "version", .30);
            AddColumnData("Qualifier", "qualifier", .30);
            InitColumns();
        }

        private void DataToControls()
        {
            if (_versionIdentifiers != null)
            {
                lvList.Items.Clear();
                foreach (VersionIdentifier obj in _versionIdentifiers)
                {
                    AddListViewObject(obj);
                }
            }
        }

        private void ControlsToData()
        {
            _versionIdentifiers = null;
            if (lvList.Items.Count > 0)
            {
                _versionIdentifiers = new List<VersionIdentifier>();
                foreach (ListViewItem lvi in lvList.Items)
                {
                    var obj = (VersionIdentifier) lvi.Tag;
                    _versionIdentifiers.Add(obj);
                }
            }
        }
    }
}