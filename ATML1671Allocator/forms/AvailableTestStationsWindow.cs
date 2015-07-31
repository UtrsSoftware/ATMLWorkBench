/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ATML1671Allocator.allocator;
using ATMLCommonLibrary.managers;
using ATMLCommonLibrary.model;
using ATMLDataAccessLibrary.db.daos;
using ATMLManagerLibrary.managers;
using ATMLModelLibrary.model;
using ATMLModelLibrary.model.common;
using ATMLModelLibrary.model.equipment;
using WeifenLuo.WinFormsUI.Docking;

namespace ATML1671Allocator.forms
{
    public partial class AvailableTestStationsWindow : DockContent, IATMLDockableWindow
    {
        public AvailableTestStationsWindow()
        {
            InitializeComponent();
            lvTestStations.Columns.Add( "Model" );
            lvTestStations.Columns.Add( "UUID" );

            List<TestStationDescription11> testStations = TestStationManager.TestStations;
            foreach (TestStationDescription11 testStation in testStations)
            {
                AddListItem( testStation, Color.White );
            }
            lvTestStations.AutoResizeColumns( ColumnHeaderAutoResizeStyle.ColumnContent );
            Load += ( sender, args ) => ProcessSelectedTestStations();
        }

        public void CloseProject()
        {
            /* Do Nothing Right Now */
        }

        protected override bool ProcessCmdKey( ref Message msg, Keys keyData )
        {
            if (keyData == ( Keys.Control | Keys.F4 ))
            {
                Console.Beep();
                return true;
            }
            return base.ProcessCmdKey( ref msg, keyData );
        }


        private void AddListItem( TestStationDescription11 testStation, Color bgColor )
        {
            var lv1 = new ListViewItem( testStation.name );
            lv1.Checked = true;
            lv1.SubItems.Add( testStation.uuid );
            lv1.BackColor = bgColor;
            lv1.Tag = testStation;
            lvTestStations.Items.Add( lv1 );
        }

        private void lvTestStations_ItemChecked( object sender, ItemCheckedEventArgs e )
        {
            ProcessSelectedTestStations();
        }

        private void ProcessSelectedTestStations()
        {
            bool anySelected = false;
            foreach (ListViewItem lvi in lvTestStations.CheckedItems)
            {
                var testStation = lvi.Tag as TestStationDescription11;
                if (testStation != null)
                {
                    ATMLAllocator.Instance.AddSelectedTestStation( testStation );
                    anySelected = true;
                }
            }
            if (anySelected)
                ATMLAllocator.OnTestStationSelected();
        }

        private void lvTestStations_ItemCheck( object sender, ItemCheckEventArgs e )
        {
            ATMLAllocator.Instance.ClearSelectedTestStations();
            ATMLAllocator.Instance.ClearAvailableInstruments();
        }

        public void ProcessSignal(SignalRequirementsSignalRequirement signalRequirement)
        {
            var dao = new InstrumentDAO();
            var attributes = ( from attribute 
                                 in signalRequirement.TsfClassAttribute 
                                let name = attribute.Name 
                              where attribute.Value != null 
                              where attribute.Value.Item is DatumType 
                                let value = Datum.GetNominalDatumValue( (DatumType) attribute.Value.Item )
                               let qualifier = ((DatumType)attribute.Value.Item).unitQualifier
                              where value != null 
                             select new Tuple<string, object, string>( name.Value, value, qualifier ) ).ToList();

            lvTestStations.BeginUpdate();
            try
            {
                foreach (ListViewItem lvi in lvTestStations.Items)
                    lvi.BackColor = Color.White;

                ICollection<object> ids = dao.FindCapableEquipment(attributes);
                foreach (ListViewItem lvi in lvTestStations.Items)
                {
                    var instrument = lvi.Tag as TestStationDescription11;
                    if (instrument != null)
                    {
                        foreach (var id in ids)
                        {
                            if (id.Equals(instrument.uuid))
                                lvi.BackColor = Color.PaleGreen;
                        }
                    }
                }
            }
            catch (Exception e2)
            {
                LogManager.Debug("Error In TSF Class: {0}", signalRequirement.TsfClass.tsfClassName);
                foreach (Tuple<string, object, string> tuple in attributes)
                {
                    LogManager.Debug("     {0} = {1} {2}", tuple.Item1, tuple.Item2, tuple.Item3);
                }

            }
            lvTestStations.EndUpdate();
        }


    }
}