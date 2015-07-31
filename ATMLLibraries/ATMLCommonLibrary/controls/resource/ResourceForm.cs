/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.ComponentModel;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.forms
{
    public partial class ResourceForm : ATMLForm
    {
        public ResourceForm()
        {
            InitializeComponent();
            resourceControl.Resource = new Resource();
            ValidateSchema += ResourceForm_ValidateSchema;
            UndoChanges += ResourceForm_UndoChanges;
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Resource Resource
        {
            get { return resourceControl.Resource; }
            set
            {
                originalSerializedATMLObject = value.Serialize();
                resourceControl.Resource = value;
            }
        }

        private void ResourceForm_UndoChanges(object sender, EventArgs e)
        {
            resourceControl.Resource = Resource.Deserialize(originalSerializedATMLObject);
        }

        private void ResourceForm_ValidateSchema(object sender, EventArgs e)
        {
            Resource resource = resourceControl.Resource;
            ValidateToSchema(resource);
        }
    }
}