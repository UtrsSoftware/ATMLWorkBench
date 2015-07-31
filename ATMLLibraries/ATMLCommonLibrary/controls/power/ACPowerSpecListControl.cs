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
    public partial class ACPowerSpecListControl : ATMLListControl
    {
        private List<PowerSpecificationsAC> _ACPower = new List<PowerSpecificationsAC>();

        public ACPowerSpecListControl()
        {
            InitializeComponent();
            InitListView();
        }

        [Browsable( false ), DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
        public List<PowerSpecificationsAC> ACPower
        {
            get { return ( _ACPower != null && _ACPower.Count == 0 ) ? null : _ACPower; }
            set { _ACPower = value; }
        }

        private void InitListView()
        {
            DataObjectName = "PowerSpecificationsAC";
            DataObjectFormType = typeof (ACPowerSpecificationControl);
            AddColumnData( "Frequency", "frequency", .25 );
            AddColumnData( "Voltage", "voltage", .25 );
            AddColumnData( "Item Name", "itemElementName", .25 );
            AddColumnData( "Description", "description", .25 );
            InitColumns();
        }

        private void DataToControls()
        {
            if (_ACPower != null)
            {
                lvList.Items.Clear();
                foreach (PowerSpecificationsAC acpower in _ACPower)
                {
                    AddListViewObject( acpower );
                }
            }
        }

        private void ControlsToData()
        {
            _ACPower = null;
            if (lvList.Items.Count > 0)
            {
                _ACPower = new List<PowerSpecificationsAC>();
                foreach (ListViewItem lvi in lvList.Items)
                {
                    var powerAC = (PowerSpecificationsAC) lvi.Tag;
                    _ACPower.Add( powerAC );
                }
            }
        }
    }
}