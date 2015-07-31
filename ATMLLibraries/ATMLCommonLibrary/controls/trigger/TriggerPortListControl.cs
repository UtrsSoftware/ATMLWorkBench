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
using System.Linq;
using System.Windows.Forms;
using ATMLCommonLibrary.controls.lists;
using ATMLModelLibrary.model.common;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.trigger
{
    public partial class TriggerPortListControl : ATMLListControl
    {
        private List<TriggerPort> ports = new List<TriggerPort>();

        public TriggerPortListControl()
        {
            InitializeComponent();
            InitListView();
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<TriggerPort> Ports
        {
            get
            {
                ControlsToData();
                return ports.Count == 0 ? null : ports;
            }
            set
            {
                if (value != null)
                {
                    ports = value.ToList();
                }
                DataToControls();
            }
        }


        private void InitListView()
        {
            Initialize(typeof (TriggerPort),
                       typeof (TriggerPortForm),
                       new Tuple<string, string, double>("Name", "name", .30),
                       new Tuple<string, string, double>("Description", "Description", .30),
                       new Tuple<string, string, double>("Direction", "direction", .20),
                       new Tuple<string, string, double>("Type", "type", .20));

        }

        private void ControlsToData()
        {
            ports = Harvest<TriggerPort>();
        }

        private void DataToControls()
        {
            Populate(ports);
        }

    }
}