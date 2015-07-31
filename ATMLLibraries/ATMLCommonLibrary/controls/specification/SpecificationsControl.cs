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
using System.Linq;
using System.Windows.Forms;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.specification
{
    public partial class SpecificationsControl : UserControl
    {
        private Specifications _specifications;
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Specifications Specifications
        {
            get { ControlsToData();  return _specifications; }
            set { _specifications = value; DataToControls();  }
        }

        public SpecificationsControl()
        {
            InitializeComponent();
            conditionListControl.AddColumn( "Condition", "condition" );
            certificationListControl.AddColumn("Certification", "certification");
        }

        private void ControlsToData()
        {
            if (specificationListControl.Items.Count == 0)
            {
                _specifications = null;
            }
            else
            {
                if( _specifications == null )
                    _specifications = new Specifications();
                _specifications.Items = new List<object>();
                foreach (ListViewItem lvi in specificationListControl.Items )
                {
                    _specifications.Items.Add(lvi.Tag);
                }

                if (conditionListControl.RowCount == 0 )
                    _specifications.Conditions = null;
                else
                {
                    _specifications.Conditions = conditionListControl.GetColumnValues( 0 ).Cast<string>().ToList();
                }


                if (certificationListControl.RowCount == 0)
                {
                    _specifications.Certifications = null;
                }
                else
                {
                    _specifications.Certifications = certificationListControl.GetColumnValues(0).Cast<string>().ToList();
                }
            }
        }

        private void DataToControls()
        {
            if (_specifications != null)
            {
                if (_specifications.Items != null)
                {
                    specificationListControl.Items.Clear();
                    foreach (object item in _specifications.Items)
                    {
                        specificationListControl.AddItem(item);
                    }
                }

                if (_specifications.Conditions != null)
                {

                    conditionListControl.Clear();

                    foreach (String condition in _specifications.Conditions)
                    {
                        conditionListControl.AddColumnData( conditionListControl.AddRow(), "condition", condition.Trim() );
                    }
                }

                if (_specifications.Certifications != null)
                {
                    certificationListControl.Clear();
                    foreach (String certification in _specifications.Certifications)
                    {
                        certificationListControl.AddColumnData( certificationListControl.AddRow(), "certification", certification.Trim() );
                    }
                }
            }

        }

    }
}
