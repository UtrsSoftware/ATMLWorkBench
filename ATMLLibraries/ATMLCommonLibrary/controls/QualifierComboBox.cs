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
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ATMLCommonLibrary.controls
{
    public partial class QualifierComboBox : ComboBox
    {
        public QualifierComboBox()
        {
            InitializeComponent();
            InitCombo();
        }

        public QualifierComboBox(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            InitCombo();
        }

        private void InitCombo()
        {
            this.DropDownStyle = ComboBoxStyle.DropDownList;
            if (!this.IsInDesignMode())
            {
                this.Items.Clear();
                this.Items.Add("inst_max");
                this.Items.Add("inst_min");
                this.Items.Add("pk_pk");
                this.Items.Add("av");
                this.Items.Add("trms");
                this.Items.Add("pk");
                this.Items.Add("pk_pos");
                this.Items.Add("pk_neg");
            }
        }

    }
}
