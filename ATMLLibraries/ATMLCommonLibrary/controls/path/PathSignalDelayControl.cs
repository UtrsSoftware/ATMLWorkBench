/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Windows.Forms;
using ATMLCommonLibrary.controls.limit;
using ATMLModelLibrary.model.common;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.path
{
    public partial class PathSignalDelayControl : LimitControl
    {
        public PathSignalDelayControl()
        {
            InitializeComponent();
            _limit = new PathSignalDelay();
        }

        public PathSignalDelay PathSignaldelay
        {
            get
            {
                ControlsToData();
                return _limit as PathSignalDelay;
            }
            set
            {
                _limit = value;
                DataToControls();
            }
        }

        private new void DataToControls()
        {
            base.DataToControls();
            if (_limit != null)
            {
                edtInputPort.Value = ((PathSignalDelay) _limit).inputPort;
                edtOutputPort.Value = ((PathSignalDelay) _limit).outputPort;
                edtFrequency.Tag = ((PathSignalDelay) _limit).Frequency;
                ShowFrequencyValue();
            }
        }

        private new void ControlsToData()
        {
            if (_limit == null)
                _limit = new PathSignalDelay();
            base.ControlsToData();
            PathSignalDelay delay = _limit as PathSignalDelay;
            if (delay != null)
            {
                delay.inputPort = edtInputPort.GetValue<string>();
                delay.outputPort = edtOutputPort.GetValue<string>();
                delay.Frequency = edtFrequency.Tag as Limit;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            var form = new LimitForm();
            ControlsToData();
            form.Limit = ((PathSignalDelay) _limit).Frequency;
            if (DialogResult.OK == form.ShowDialog())
            {
                edtFrequency.Tag = form.Limit;
                if (edtFrequency.Tag != null )
                    edtFrequency.Value = edtFrequency.Tag.ToString();
            }
        }

        private void ShowFrequencyValue()
        {
            if (((PathSignalDelay) _limit).Frequency != null)
                edtFrequency.Value = _limit.ToString();
        }

        private void btnFrequencyLimit_Click(object sender, EventArgs e)
        {

        }
    }
}