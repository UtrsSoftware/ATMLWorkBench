/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using ATMLCommonLibrary.controls.lists;
using ATMLCommonLibrary.forms;
using ATMLModelLibrary.model.common;
using ATMLSchemaLibrary.managers;

namespace ATMLCommonLibrary.controls.hardware
{
    public partial class FactoryDefaultsListControl : ATMLListControl
    {
        private List<NamedValue> _factoryDefaults;

        public FactoryDefaultsListControl()
        {
            InitializeComponent();
            InitListView();
        }

        public List<NamedValue> FactoryDefaults
        {
            get
            {
                ControlsToData();
                return _factoryDefaults;
            }
            set
            {
                _factoryDefaults = value;
                DataToControls();
            }
        }

        private void InitListView()
        {
            DataObjectName = "NamedValue";
            DataObjectFormType = typeof (NameValueForm);
            AddColumnData("Name", "name", .50);
            AddColumnData("Value", "ToString()", .50);
            InitColumns();
        }

        private void DataToControls()
        {
            if (_factoryDefaults != null)
            {
                lvList.Items.Clear();
                foreach (NamedValue resource in _factoryDefaults)
                {
                    AddListViewObject(resource);
                }
            }
        }

        private void ControlsToData()
        {
            _factoryDefaults = null;
            if (lvList.Items.Count > 0)
            {
                _factoryDefaults = new List<NamedValue>();
                foreach (ListViewItem lvi in lvList.Items)
                {
                    var resource = (NamedValue) lvi.Tag;
                    _factoryDefaults.Add(resource);
                }
            }
        }


        public bool Validate( out string error )
        {
            bool isValid = true;
            StringBuilder sb = new StringBuilder();
            foreach (NamedValue factoryDefault in _factoryDefaults)
            {
                SchemaValidationResult svr = new SchemaValidationResult();
                isValid &= factoryDefault.Validate( svr );
                if (svr.HasErrors())
                    sb.Append( svr.ErrorMessage ).Append( ", " );
            }
            if( sb.ToString().EndsWith( ", " ) )
                sb.Length = sb.Length - 2;
            error = sb.ToString();
            return isValid;
        }

    }
}