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
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ATMLModelLibrary.model.common;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.forms
{
    public partial class DatumForm : ATMLForm
    {
        private DatumType datum;

        public DatumType Datum
        {
            get { ControlsToData(); return datum; }
            set { datum = value; DataToControls(); }
        }

        public DatumForm()
        {
            InitializeComponent();
            FormClosing += new FormClosingEventHandler(DatumForm_FormClosing);
        }

        void DatumForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult.OK == this.DialogResult)
            {

            }
        }

        private void DataToControls()
        {
            datumTypeControl.Datum = datum;
        }

        private void ControlsToData()
        {
            datum = datumTypeControl.Datum;
        }

    }
}
