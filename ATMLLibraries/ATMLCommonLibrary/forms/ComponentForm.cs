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
using ATMLDataAccessLibrary.model;
using ATMLModelLibrary.model.common;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.forms
{
    public partial class ComponentForm : ATMLForm
    {
        public bool IsParentComponent
        {
            set { componentControl.IsParentComponent = value;  }
            get { return componentControl.IsParentComponent;  }
        }
        public ComponentForm()
        {
            InitializeComponent();
            componentControl.DocumentType = dbDocument.DocumentType.COMPONENT_DESCRIPTION;
        }

        public ComponentForm(HardwareItemDescriptionComponent itemComponent)
        {
            InitializeComponent();
            componentControl.HardwareItemDescriptionComponent = itemComponent;
            componentControl.DocumentType = dbDocument.DocumentType.COMPONENT_DESCRIPTION;
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public HardwareItemDescriptionComponent ItemComponent
        {
            set
            {
                componentControl.HardwareItemDescriptionComponent = value;
            }
            get
            {
                return componentControl.HardwareItemDescriptionComponent;
            }
        }

        public HardwareItemDescriptionComponent1 ParentItemComponent
        {
            set
            {
                componentControl.HardwareItemDescriptionComponent1 = value;
            }
            get
            {
                return componentControl.HardwareItemDescriptionComponent1;
            }
        }


    }
}