/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.ComponentModel;
using ATMLCommonLibrary.forms;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.trigger
{
    public partial class TriggerPortForm : ATMLForm
    {
        public TriggerPortForm()
        {
            InitializeComponent();
            ValidateSchema += TriggerPortForm_ValidateSchema;
            UndoChanges += TriggerPortForm_UndoChanges;
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TriggerPort TriggerPort
        {
            get { return triggerPortControl.Port; }
            set
            {
                if( value != null )
                    originalSerializedATMLObject = value.Serialize();
                triggerPortControl.Port = value;
            }
        }

        private void TriggerPortForm_UndoChanges(object sender, EventArgs e)
        {
            triggerPortControl.Port = TriggerPort.Deserialize(originalSerializedATMLObject);
        }

        private void TriggerPortForm_ValidateSchema(object sender, EventArgs e)
        {
            ValidateToSchema(triggerPortControl.Port);
        }
    }
}