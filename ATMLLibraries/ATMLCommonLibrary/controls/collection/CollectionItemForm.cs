/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
using ATMLCommonLibrary.forms;
using ATMLModelLibrary.model.common;

namespace ATMLCommonLibrary.controls.collection
{
    public partial class CollectionItemForm : ATMLForm
    {
        public CollectionItemForm()
        {
            InitializeComponent();
        }

        public CollectionItem CollectionItem
        {
            set { collectionItemControl.CollectionItem = value; }
            get { return collectionItemControl.CollectionItem; }
        }
    }
}