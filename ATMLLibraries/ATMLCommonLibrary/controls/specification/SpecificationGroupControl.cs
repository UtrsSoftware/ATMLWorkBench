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
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls
{
    public partial class SpecificationGroupControl : ATMLControl
    {
        private SpecificationGroup _specificationGroup;
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SpecificationGroup SpecificationGroup
        {
            get { ControlsToData();  return _specificationGroup; }
            set { _specificationGroup = value; DataToControls();  }
        }

        public SpecificationGroupControl()
        {
            InitializeComponent();
            Validating += new CancelEventHandler(SpecificationGroupControl_Validating);
        }


        void SpecificationGroupControl_Validating(object sender, CancelEventArgs e)
        {
            if (dgConditions.Rows.Count == 0)
            {
                e.Cancel = true;
                errorProvider.SetError( dgConditions, "There must be at least 1 Specification or Specification Group listed");
            }
        }

        /**
         * Stores all the controls data into the appropriate data objects.
         */
        private void ControlsToData()
        {
            _specificationGroup.Description = edtSpecDescription.GetValue<string>();
            _specificationGroup.name = edtSpecName.GetValue<string>();
            if (dgConditions.Rows.Count == 0)
                _specificationGroup.Conditions = null;
            else
            {
                _specificationGroup.Conditions = new List<string>();
                foreach (DataGridViewRow row in dgConditions.Rows)
                {
                    _specificationGroup.Conditions.Add((String)row.Cells["condition"].Value);
                }
            }
        }

        /**
         * Stores all the data objects data into the appropriate controls.
         */
        private void DataToControls()
        {

            edtSpecDescription.Value = _specificationGroup.Description;
            edtSpecName.Value = _specificationGroup.name;
            //-------------------------------------------//
            //--- Load the Specification List Control ---//
            //-------------------------------------------//
            specificationListControl.Items.Clear();
            if (_specificationGroup.Items != null)
            {
                foreach (object item in _specificationGroup.Items)
                {
                    specificationListControl.AddItem(item);
                }
            }

            //---------------------------------------//
            //--- Load the Condition List Control ---//
            //---------------------------------------//
            if (_specificationGroup.Conditions != null)
            {
                foreach (String condition in _specificationGroup.Conditions)
                {
                    int idx = dgConditions.Rows.Add();
                    DataGridViewRow row = dgConditions.Rows[idx];
                    row.Cells["condition"].Value = condition!=null?condition.Trim():"";
                }
            }


        }


    }
}
