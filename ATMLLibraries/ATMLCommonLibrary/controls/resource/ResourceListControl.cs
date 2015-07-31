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
using ATMLCommonLibrary.controls.lists;
using ATMLCommonLibrary.forms;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.resource
{
    public partial class ResourceListControl : ATMLListControl
    {
        private List<Resource> _resources = new List<Resource>();

        public ResourceListControl()
        {
            InitializeComponent();
            InitListView();
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<Resource> Resources
        {
            get
            {
                ControlsToData();
                return (_resources == null || (_resources != null && _resources.Count == 0) ? null : _resources);
            }
            set
            {
                _resources = value;
                DataToControls();
            }
        }

        private void InitListView()
        {
            Initialize(typeof (Resource),
                       typeof (ResourceForm),
                       new Tuple<string, string, double>("Index", "index", .10),
                       new Tuple<string, string, double>("Name", "name", .25),
                       new Tuple<string, string, double>("Description", "Description", .25),
                       new Tuple<string, string, double>("Base Index", "baseIndex", .10),
                       new Tuple<string, string, double>("Count", "count", .10),
                       new Tuple<string, string, double>("Inc. By", "incrementBy", .10),
                       new Tuple<string, string, double>("Repl.Char", "replacementCharacter", .10)
                );
        }

        private void DataToControls()
        {
            Populate(_resources);
        }

        private void ControlsToData()
        {
            _resources = Harvest<Resource>();
        }
    }
}