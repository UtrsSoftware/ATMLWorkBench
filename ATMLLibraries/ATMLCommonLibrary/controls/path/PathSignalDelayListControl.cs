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
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.path
{
    public partial class PathSignalDelayListControl : ATMLCommonLibrary.controls.lists.ATMLListControl
    {
        private List<PathSignalDelay> _PathSignalDelay = new List<PathSignalDelay>();


        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<PathSignalDelay> PathSignalDelay
        {
            get { DataToControls(); return (_PathSignalDelay != null && _PathSignalDelay.Count == 0) ? null : _PathSignalDelay; ; }
            set { _PathSignalDelay = value; ControlsToData(); }
        }
        public PathSignalDelayListControl()
        {
            InitializeComponent();
            InitListView();
            InitializeForm += new FormInitializationDelegate(PathSignalDelayListControl_InitializeForm);
        }

        void PathSignalDelayListControl_InitializeForm(Form form)
        {
            PathSignalDelayForm pathSignalDelayForm = form as PathSignalDelayForm;
            if (pathSignalDelayForm != null)
            {
                
            }
        }

        private void InitListView()
        {
            DataObjectName = "PathSignaldelay";
            DataObjectFormType = typeof(PathSignalDelayForm);
            AddColumnData("Frequency", "Frequency", .34);
            AddColumnData("Input Port", "inputPort", .33);
            AddColumnData("Output Port", "outputPort", .33);
            InitColumns();
        }

        private void DataToControls()
        {
            if (_PathSignalDelay != null)
            {
                lvList.Items.Clear();
                foreach (PathSignalDelay signaldelay in _PathSignalDelay)
                {
                    AddListViewObject(signaldelay);
                }
            }
        }

        private void ControlsToData()
        {
            _PathSignalDelay = null;
            if (lvList.Items.Count > 0)
            {
                _PathSignalDelay = new List<PathSignalDelay>();
                foreach (ListViewItem lvi in lvList.Items)
                {
                    var signaldelay = (PathSignalDelay)lvi.Tag;
                    _PathSignalDelay.Add(signaldelay);
                }
            }
        }
    }
}
