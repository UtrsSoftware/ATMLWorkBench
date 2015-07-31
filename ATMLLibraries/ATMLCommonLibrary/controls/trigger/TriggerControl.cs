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
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ATMLModelLibrary.model.common;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls
{
    public partial class TriggerControl : ATMLControl
    {

        private Trigger trigger = null;
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Trigger Trigger
        {
            get { ControlsToData();  return trigger; }
            set { trigger = value; DataToControls();  }
        }

        public TriggerControl()
        {
            InitializeComponent();
            InitControls();
        }

        protected void DataToControls()
        {
            if (trigger != null)
            {
                edtDescription.Value = trigger.Description;
                edtName.Value = trigger.name;
                propertyListControl.Properties = trigger.TriggerProperties;
                portListControl.Ports = trigger.TriggerPorts;
            }
        }

        protected void ControlsToData()
        {
            if( trigger == null )
                trigger = new Trigger();
            trigger.Description = edtDescription.GetValue<string>();
            trigger.name = edtName.GetValue<string>();
            trigger.TriggerProperties = propertyListControl.Properties;
            trigger.TriggerPorts = portListControl.Ports;
        }
    
    }
}
