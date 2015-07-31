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
using ATMLCommonLibrary.controls.common;

namespace ATMLCommonLibrary.controls
{
    public partial class RepeatedItemControl : ItemControl
    {
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public RepeatedItem RepeatedItem
        {
            get { ControlsToData(); return (RepeatedItem)_item; }
            set
            {
                Item = value; 
                DataToControls(); 
            }
        }

        public RepeatedItemControl()
        {
            InitializeComponent();
            InitControls();
        }

        protected override void ControlsToData()
        {
            if (_item == null)
                _item = new RepeatedItem();
            base.ControlsToData();
            RepeatedItem repeatedItem = _item as RepeatedItem;
            if (repeatedItem != null )
            {
                repeatedItem.replacementCharacter = edtReplacementChar.GetValue<string>();
                repeatedItem.count = edtCount.GetValue<int>();
                repeatedItem.countSpecified = edtCount.HasValue();
                repeatedItem.incrementBy = edtIncrementBy.GetValue<int>();
                repeatedItem.incrementBySpecified = edtIncrementBy.HasValue();
                repeatedItem.baseIndex = edtBaseIndex.GetValue<int>(); ;
                repeatedItem.baseIndexSpecified = edtBaseIndex.HasValue();
            }
        }

        protected override void DataToControls()
        {
            base.DataToControls();
            RepeatedItem repeatedItem = _item as RepeatedItem;
            if (repeatedItem != null )
            {
                edtCount.Value = repeatedItem.countSpecified ? (int?)repeatedItem.count : null;
                edtIncrementBy.Value = repeatedItem.incrementBySpecified ? (int?)repeatedItem.incrementBy : null;
                edtBaseIndex.Value = repeatedItem.baseIndexSpecified ? (int?)repeatedItem.baseIndex : null;
                edtReplacementChar.Value = repeatedItem.replacementCharacter;
            }
        }

        private void RepeatedItemControl_Validating(object sender, CancelEventArgs e)
        {
            if (edtReplacementChar.Value != null)
            {
                String replChar = edtReplacementChar.GetValue<string>();
                String name = edtName.GetValue<string>();
                if (name != null && !name.Contains(replChar))
                {
                    e.Cancel = true;
                    errorProvider.SetError(edtName, "When using a replacement character the replacement character must exist in the name.");
                }
            }
        }


    }
}
