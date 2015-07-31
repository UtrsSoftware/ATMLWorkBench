/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using ATMLCommonLibrary.controls.lists;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.power
{
    public partial class DCPowerSpecListControl : ATMLListControl
    {
        private List<PowerSpecificationsDC> _DCPower = new List<PowerSpecificationsDC>();

        public DCPowerSpecListControl()
        {
            InitializeComponent();
            InitListView();
        }

        [Browsable( false ), DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
        public List<PowerSpecificationsDC> DCPower
        {
            get { return ( _DCPower != null && _DCPower.Count == 0 ) ? null : _DCPower; }
            set { _DCPower = value; }
        }

        private void InitListView()
        {
            DataObjectName = "PowerSpecificationsDC";
            DataObjectFormType = typeof (DCPowerSpecificationControl);
            AddColumnData( "Polarity", "polarity", .25 );
            AddColumnData( "Voltage", "voltage", .25 );
            AddColumnData( "Ripple", "ripple", .25 );
            AddColumnData( "Description", "description", .25 );
            InitColumns();
        }

        private void DataToControls()
        {
            if (_DCPower != null)
            {
                lvList.Items.Clear();
                foreach (PowerSpecificationsDC dcpower in _DCPower)
                {
                    AddListViewObject( dcpower );
                }
            }
        }

        private void ControlsToData()
        {
            _DCPower = null;
            if (lvList.Items.Count > 0)
            {
                _DCPower = new List<PowerSpecificationsDC>();
                foreach (ListViewItem lvi in lvList.Items)
                {
                    var DCpower = (PowerSpecificationsDC) lvi.Tag;
                    _DCPower.Add( DCpower );
                }
            }
        }
    }
}