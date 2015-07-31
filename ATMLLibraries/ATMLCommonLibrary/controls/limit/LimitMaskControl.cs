/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Windows.Forms;
using ATMLCommonLibrary.forms;
using ATMLModelLibrary.model.common;

namespace ATMLCommonLibrary.controls.limit
{
    public partial class LimitMaskControl : UserControl
    {
        private LimitMask _limitMask;

        public LimitMaskControl()
        {
            InitializeComponent();
        }

        public LimitMask LimitMask
        {
            get
            {
                ControlsToData();
                return _limitMask;
            }
            set
            {
                _limitMask = value;
                DataToControls();
            }
        }

        protected void DataToControls()
        {
            if (_limitMask != null)
            {
            }
        }

        protected void ControlsToData()
        {
            if (_limitMask == null)
                _limitMask = new LimitMask();
        }


        private void btnExpectedLimit_Click(object sender, EventArgs e)
        {
            var form = new ValueForm();
            form.Value = _limitMask.Expected;
            if (DialogResult.OK == form.ShowDialog())
            {
                Value value = form.Value;
                edtExpectedValue.Tag = value;
                edtExpectedValue.Text = value.ToString();
            }
        }
    }
}