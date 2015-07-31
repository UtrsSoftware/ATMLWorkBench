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

namespace ATMLCommonLibrary.controls.error
{
    public partial class ErrorListControl : ATMLListControl
    {
        private List<HardwareItemDescriptionError> _errors = new List<HardwareItemDescriptionError>();

        public ErrorListControl()
        {
            InitializeComponent();
            InitListView();
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<HardwareItemDescriptionError> Errors
        {
            get
            {
                ControlsToData();
                return (_errors != null && _errors.Count == 0) ? null : _errors;
            }
            set
            {
                _errors = value;
                DataToControls();
            }
        }

        private void InitListView()
        {
            DataObjectName = "HardwareItemDescriptionError";
            DataObjectFormType = typeof (ErrorForm);
            AddColumnData("Description", "Description", .25);
            AddColumnData("Type", "type", .25);
            AddColumnData("Source", "source", .25);
            AddColumnData("ID", "ID", .25);
            InitColumns();
        }

        private void DataToControls()
        {
            if (_errors != null)
            {
                lvList.Items.Clear();
                foreach (HardwareItemDescriptionError resource in _errors)
                {
                    AddListViewObject(resource);
                }
            }
        }

        private void ControlsToData()
        {
            _errors = null;
            if (lvList.Items.Count > 0)
            {
                _errors = new List<HardwareItemDescriptionError>();
                foreach (ListViewItem lvi in lvList.Items)
                {
                    var error = (HardwareItemDescriptionError) lvi.Tag;
                    _errors.Add(error);
                }
            }
        }
    }
}