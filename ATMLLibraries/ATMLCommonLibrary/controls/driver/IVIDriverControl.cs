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
using System.Windows.Forms;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.driver
{
    public partial class IVIDriverControl : DriverControl
    {
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IVI Driver
        {
            get { ControlsToData(); return _driver as IVI; }
            set { _driver = value; DataToControls(); }
        }

        public IVIDriverControl()
        {
            InitializeComponent();
            InitListView();
        }

        private void InitListView()
        {
            lvClassNames.AddColumn("Class", "class" );
            SetColumnWidths();
        }

        private void IVIDriverControl_Resize(object sender, EventArgs e)
        {
            SetColumnWidths();
        }

        private void SetColumnWidths()
        {
            //lvClassNames.Columns[0].Width = lvClassNames.Width;
        }

        protected override void ControlsToData()
        {
            if (_driver != null)
            {
                base.ControlsToData();
                IVI ivi = _driver as IVI;
                if (ivi != null)
                {
                    ivi.ComplianceDocument = documentControl.HasDocument ? documentControl.Document : null;
                    if( lvClassNames.RowCount > 0 )
                    {
                        if( ivi.Class == null )
                            ivi.Class = new List<string>();
                        ivi.Class.Clear();
                        foreach (List<string> row in lvClassNames.GetTable())
                        {
                            if( row.Count>0)
                                ivi.Class.Add( row[0] );
                        }
                    }
                    else
                    {
                        ivi.Class = null;
                    }
                }
            }
        }

        protected override void DataToControls()
        {
            if (_driver != null)
            {
                base.DataToControls();
                IVI ivi = _driver as IVI;
                if (ivi != null)
                {
                    documentControl.Document = ivi.ComplianceDocument;
                    if (ivi.Class != null)
                    {
                        foreach (String _class in ivi.Class)
                        {
                            var lvi = new ListViewItem( _class );
                            lvi.Tag = _class;
                            var row = lvClassNames.AddRow();
                            lvClassNames.AddColumnData(row, "class", _class);
                        }
                    }
                }
            }
        }

        private void cmbIVIType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
