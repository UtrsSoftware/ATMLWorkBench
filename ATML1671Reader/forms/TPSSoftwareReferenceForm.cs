/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System.ComponentModel;
using ATMLCommonLibrary.forms;
using ATMLModelLibrary.model.common;

namespace ATML1671Reader.forms
{
    public partial class TPSSoftwareReferenceForm : ATMLForm
    {
        public TPSSoftwareReferenceForm()
        {
            InitializeComponent();
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ConfigurationSoftwareReference ConfigurationSoftwareReference
        {
            set { tpsSoftwareReferenceControl.ConfigurationSoftwareReference = value; }
            get { return tpsSoftwareReferenceControl.ConfigurationSoftwareReference; }
        }
    }
}