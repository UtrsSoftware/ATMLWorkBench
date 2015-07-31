/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System.Collections.Generic;
using System.ComponentModel;
using ATMLCommonLibrary.controls.lists;
using ATMLCommonLibrary.forms;
using ATMLModelLibrary.model.signal.basic;

namespace ATMLCommonLibrary.controls.signal
{
    public partial class SignalInputListControl : ATMLListControl
    {
        private ICollection<SignalIN> _signalINs = new List<SignalIN>();

        public SignalInputListControl()
        {
            InitializeComponent();
            InitListView();
            _signalINs = new List<SignalIN>();
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ICollection<SignalIN> SignalINs
        {
            get
            {
                ControlsToData();
                return _signalINs;
            }
            set
            {
                _signalINs = value;
                DataToControls();
            }
        }

        private void InitListView()
        {
            DataObjectName = "SignalIN";
            DataObjectFormType = typeof (SignalInputForm);
            AddColumnData("Name", "name", .75);
            AddColumnData("Max Channels", "maxChannels", .25);
            InitColumns();
        }

        private void ControlsToData()
        {
            _signalINs = Harvest<SignalIN>();
        }


        private void DataToControls()
        {
            Populate(_signalINs);
        }

        public void Clear()
        {
            if (_signalINs != null)
                _signalINs.Clear();
            Items.Clear();
        }

        public void AddSignalInputs(SignalIN[] inputs)
        {
            foreach (SignalIN input in inputs)
                AddSignalInput(input);
        }

        public void AddSignalInput(SignalIN input)
        {
            if( _signalINs == null )
                _signalINs = new List<SignalIN>();
            _signalINs.Add(input);
            AddListViewObject(input);
        }
    }
}