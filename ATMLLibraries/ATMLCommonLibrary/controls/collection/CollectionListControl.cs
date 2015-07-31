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
using ATMLCommonLibrary.controls.lists;
using ATMLModelLibrary.model.common;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.collection
{
    public partial class CollectionListControl : ATMLListControl
    {
        private List<CollectionItem> _collection = new List<CollectionItem>();

        public CollectionListControl()
        {
            InitializeComponent();
            InitListView();
        }

        private void InitListView()
        {
            Initialize(typeof(CollectionItem),
                       typeof(CollectionItemForm),
                       new Tuple<string, string, double>("Name", "name", .45),
                       new Tuple<string, string, double>("Value", "ToString()", .55) 
                );
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<CollectionItem> CollectionItems
        {
            get
            {
                ControlsToData();
                return (_collection == null || (_collection != null && _collection.Count == 0) ? null : _collection);
            }
            set
            {
                _collection = value;
                DataToControls();
            }
        }

        private void DataToControls()
        {
            Populate(_collection);
        }

        private void ControlsToData()
        {
            _collection = Harvest<CollectionItem>();
        }


    }
}
