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
using ATMLCommonLibrary.controls.hardware;
using ATMLCommonLibrary.controls.lists;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.control
{
    public partial class FirmwareListControl : ATMLListControl
    {
        private List<VersionIdentifier> _firmwares;

        public FirmwareListControl()
        {
            InitializeComponent();
            InitListView();
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<VersionIdentifier> Firmwares
        {
            get
            {
                ControlsToData();
                return _firmwares;
            }
            set
            {
                _firmwares = value;
                DataToControls();
            }
        }

        private void InitListView()
        {
            DataObjectName = "VersionIdentifier";
            DataObjectFormType = typeof (VersionIdentifierForm);
            FormTitle = "Firmware";
            AddColumnData("Name", "name", .60);
            AddColumnData("Version", "version", .40);
            InitColumns();
        }


        private void DataToControls()
        {
            if (_firmwares != null)
            {
                lvList.Items.Clear();
                foreach (VersionIdentifier item in _firmwares)
                {
                    AddListViewObject(item);
                }
            }
        }

        private void ControlsToData()
        {
            _firmwares = null;
            if (lvList.Items.Count > 0)
            {
                _firmwares = new List<VersionIdentifier>();
                foreach (ListViewItem lvi in lvList.Items)
                {
                    var item = (VersionIdentifier) lvi.Tag;
                    _firmwares.Add(item);
                }
            }
        }
    }
}