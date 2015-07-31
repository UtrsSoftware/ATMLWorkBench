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

namespace ATMLCommonLibrary.controls.trigger
{
    public partial class TriggerListControl : ATMLListControl
    {
        private Resource _resource = new Resource();


        public TriggerListControl()
        {
            InitializeComponent();
            InitListView();
            CompletedAdd += new CompletedAddDelegate(TriggerListControl_CompletedAdd);
            CompletedEdit += new CompletedEditDelegate(TriggerListControl_CompletedEdit);
        }

        void TriggerListControl_CompletedEdit(object obj)
        {
        }

        void TriggerListControl_CompletedAdd(object obj)
        {
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Resource Resource
        {
            get
            {
                ControlsToData();
                return _resource;
            }
            set
            {
                _resource = value;
                DataToControls();
            }
        }

        private void InitListView()
        {
            DataObjectName = "Trigger";
            DataObjectFormType = typeof (TriggerForm);
            AddColumnData("Name", "name", .50);
            AddColumnData("Description", "Description", .50);
            InitColumns();
        }


        private void DataToControls()
        {
            if (_resource != null && _resource.Triggers != null)
            {
                lvList.Items.Clear();
                foreach (Trigger trigger in _resource.Triggers)
                {
                    AddListViewObject(trigger);
                }
            }
        }

        private void ControlsToData()
        {
            var list = new List<Trigger>();
            foreach (ListViewItem lvi in lvList.Items)
                list.Add(lvi.Tag as Trigger);
            _resource.Triggers = list.Count == 0 ? null : list;
        }
    }
}