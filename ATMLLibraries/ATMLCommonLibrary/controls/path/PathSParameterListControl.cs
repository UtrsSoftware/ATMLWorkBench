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
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ATMLCommonLibrary.controls.lists;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.path
{
    public partial class PathSParameterListControl : ATMLCommonLibrary.controls.lists.ATMLListControl
    {
        private List<PathSParameter> _PathSParam = new List<PathSParameter>();

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<PathSParameter> PathSParam
        {
            get { ControlsToData(); return (_PathSParam != null && _PathSParam.Count == 0) ? null : _PathSParam; }
            set { _PathSParam = value; DataToControls(); }
        }
        public PathSParameterListControl()
        {
            InitializeComponent();
            InitListView();
        }
        private void InitListView()
        {
            DataObjectName = "SParameter";
            DataObjectFormType = typeof(PathSParameterForm);
            AddColumnData("Index", "index", .10);
            AddColumnData("Name", "name", .25);
            AddColumnData("Description", "Description", .25);
            AddColumnData("Base Index", "baseIndex", .10);
            AddColumnData("Count", "count", .10);
            AddColumnData("Inc. By", "incrementBy", .10);
            AddColumnData("Repl.Char", "replacementCharacter", .10);
            InitColumns();
        }
        private void DataToControls()
        {
            if (_PathSParam != null)
            {
                lvList.Items.Clear();
                foreach (PathSParameter pathSParam in _PathSParam)
                {
                    AddListViewObject(pathSParam);
                }
            }
        }
        private void ControlsToData()
        {
            _PathSParam = null;
            if (lvList.Items.Count > 0)
            {
                _PathSParam = new List<PathSParameter>();
                foreach (ListViewItem lvi in lvList.Items)
                {
                    var pathSParam = (PathSParameter)lvi.Tag;
                    _PathSParam.Add(pathSParam);
                }
            }
        }

    }
}