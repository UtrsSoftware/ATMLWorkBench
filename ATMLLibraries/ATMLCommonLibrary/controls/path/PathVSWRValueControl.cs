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
using ATMLCommonLibrary.controls.limit;
using ATMLModelLibrary.model.common;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.path
{
    public partial class PathVSWRValueControl : LimitControl
    {
        public PathVSWRValueControl()
        {
            InitializeComponent();
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PathVSWRValue PathVSWRValue
        {
            get
            {
                ControlsToData();
                return _limit as PathVSWRValue;
            }
            set
            {
                _limit = value;
                DataToControls();
            }
        }

        protected override void DataToControls()
        {
            var pathVswrValue = GetPathVswrValue();
            base.DataToControls();
            edtInputPort.Value = pathVswrValue.inputPort;
            edtFrequency.Value = pathVswrValue.Frequency != null ? pathVswrValue.Frequency.ToString() : "";
            edtFrequency.Tag = pathVswrValue.Frequency;
            ShowFrequencyValue();
        }

        protected override void ControlsToData()
        {
            var pathVswrValue = GetPathVswrValue();
            base.ControlsToData();
            pathVswrValue.inputPort = edtInputPort.GetValue<string>();
            pathVswrValue.Frequency = edtFrequency.Tag as Limit;
        }

        private PathVSWRValue GetPathVswrValue()
        {
            if (_limit == null)
                _limit = new PathVSWRValue();

            if (!(_limit is PathVSWRValue))
            {
                var pv = new PathVSWRValue();
                _limit.CopyTo(pv);
                _limit = pv;
            }

            return _limit as PathVSWRValue;
        }

        private void ShowFrequencyValue()
        {
            var pathVswrValue = _limit as PathVSWRValue;
            if (pathVswrValue != null)
            {
                if (pathVswrValue.Frequency != null)
                    edtFrequency.Value = pathVswrValue.Frequency.ToString();
                edtFrequency.Tag = pathVswrValue.Frequency;
            }
        }

        private void btnFrequencyLimit_Click(object sender, EventArgs e)
        {
            var form = new LimitForm();
            ControlsToData();
            var pathVswrValue = _limit as PathVSWRValue;
            if (pathVswrValue != null)
            {
                form.Limit = pathVswrValue.Frequency;
                if (DialogResult.OK == form.ShowDialog())
                {
                    pathVswrValue.Frequency = form.Limit;
                    ShowFrequencyValue();
                }
            }
        }
    }
}