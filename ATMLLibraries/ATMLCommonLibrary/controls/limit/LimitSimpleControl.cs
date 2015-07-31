/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.ComponentModel;
using System.Windows.Forms;
using ATMLModelLibrary.model.common;

namespace ATMLCommonLibrary.controls.limit
{
    public partial class LimitSimpleControl : ATMLControl
    {
        private Limit _limit;

        public LimitSimpleControl()
        {
            InitializeComponent();
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Limit Limit
        {
            get { return _limit; }
            set
            {
                _limit = value;
                if (value != null) edtLimit.Text = _limit.ToString();
            }
        }

        private void btnLimit_Click(object sender, EventArgs e)
        {
            var form = new LimitForm();
            form.Limit = _limit;
            if (DialogResult.OK == form.ShowDialog())
            {
                Limit = form.Limit;
            }
        }

        public bool HasValue()
        {
            return _limit != null;
        }
    }
}