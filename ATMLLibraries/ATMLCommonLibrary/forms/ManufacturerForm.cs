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
using ATMLModelLibrary.model.common;

namespace ATMLCommonLibrary.forms
{
    public partial class ManufacturerForm : ATMLForm
    {

        public ManufacturerForm()
        {
            InitializeComponent();
        }


        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ManufacturerData ManufacturerData
        {
            get
            {
                return manufacturerControl.ManufacturerData; 
            }
            set
            {
                manufacturerControl.ManufacturerData = value;
            }
        }


        public bool ValidationEndabled
        {
            set { manufacturerControl.ValidationEndabled = value; }
            get { return manufacturerControl.ValidationEndabled; }
        }


    }
}