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

namespace ATMLCommonLibrary.controls.driver
{
    public partial class DriverSelectionForm : ATMLForm
    {
        public DriverSelectionForm()
        {
            InitializeComponent();
            driverSelectionControl1.DriverSelected += new System.EventHandler(driverSelectionControl1_DriverSelected);
        }

        void driverSelectionControl1_DriverSelected(object sender, System.EventArgs e)
        {
            DriverSelectEvent args = e as DriverSelectEvent;
            if (args != null)
                Text = string.Format( "Control {0} Driver", Enum.GetName(typeof(DriverSelectionControl.DriverType),args.DriverType) );

        }

        [Browsable( false ), DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
        public Driver Driver
        {
            get { return driverSelectionControl1.DriverSelect; }

            set { driverSelectionControl1.DriverSelect = value; }
        }
    }
}