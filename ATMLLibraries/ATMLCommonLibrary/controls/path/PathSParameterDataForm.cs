/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System.ComponentModel;
using ATMLCommonLibrary.forms;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.path
{
    public partial class PathSParameterDataForm : ATMLForm
    {
        public PathSParameterDataForm()
        {
            InitializeComponent();
        }

        [Browsable( false ), DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
        public PathSParameterSParameterData PathSParameterSParameterData
        {
            get { return pathSParameterDataControl.PathSParameterSParameterData; }
            set { pathSParameterDataControl.PathSParameterSParameterData = value; }
        }
    }
}