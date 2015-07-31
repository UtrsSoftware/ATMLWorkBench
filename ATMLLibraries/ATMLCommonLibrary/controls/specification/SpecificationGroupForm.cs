﻿/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ATMLModelLibrary.model.equipment;
using ATMLModelLibrary.model.common;

namespace ATMLCommonLibrary.forms
{
    public partial class SpecificationGroupForm : ATMLForm
    {
        public SpecificationGroup SpecificationGroup
        {
            get { return specificationGroupControl.SpecificationGroup; }
            set { specificationGroupControl.SpecificationGroup = value; }
        }

        public SpecificationGroupForm()
        {
            InitializeComponent();
        }
    }
}