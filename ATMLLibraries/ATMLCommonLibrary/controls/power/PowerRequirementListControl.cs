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

namespace ATMLCommonLibrary.controls.power
{
    public partial class PowerRequirementListControl : ATMLListControl
    {
        private List<object> _powerRequirements;

        public PowerRequirementListControl()
        {
            InitializeComponent();
            InitListView();
        }

        public List<object> PowerRequirements
        {
            get
            {
                ControlsToData();
                return _powerRequirements;
            }
            set
            {
                _powerRequirements = value;
                DataToControls();
            }
        }

        private void InitListView()
        {
            AddColumnData("Power Requirements", "ToString()", 1.00);
            InitColumns();

            OnAdd += PowerRequirementListControl_OnAdd;
            OnEdit += PowerRequirementListControl_OnEdit;
            OnDelete += PowerRequirementListControl_OnDelete;
        }

        private void PowerRequirementListControl_OnDelete()
        {
            if (HasSelected)
            {
                RemoveSelectedItem("Power Requirement", SelectedObject.ToString());
            }
        }

        private void PowerRequirementListControl_OnEdit()
        {
            if (HasSelected)
            {
                var form = new PowerSpecificationForm();
                form.PowerRequirement = SelectedObject;
                form.Closing += delegate
                {
                    if (DialogResult.OK == form.DialogResult)
                    {
                        object item = form.PowerRequirement;
                        SelectedListViewItem.SubItems[0].Text = item.ToString();
                    }
                };
                form.Show();
            }
        }

        private void PowerRequirementListControl_OnAdd()
        {
            var form = new PowerSpecificationForm();
            form.Closing += delegate
            {
                if (DialogResult.OK == form.DialogResult)
                {
                    object item = form.PowerRequirement;
                    var lvi = new ListViewItem( item.ToString() );
                    lvi.Tag = item;
                    Items.Add(lvi);
                }
            };
            form.Show();
        }

        private void ControlsToData()
        {
            _powerRequirements = null;
            if (Items.Count > 0)
            {
                _powerRequirements = new List<object>();
                foreach (ListViewItem lvi in Items)
                {
                    _powerRequirements.Add(lvi.Tag);    
                }
            }
        }

        private void DataToControls()
        {
            if (_powerRequirements != null)
            {
                Items.Clear();
                foreach (object item in _powerRequirements)
                {
                    var lvi = new ListViewItem(item.ToString());
                    lvi.Tag = item;
                    Items.Add(lvi);
                }
            }
        }
    }
}