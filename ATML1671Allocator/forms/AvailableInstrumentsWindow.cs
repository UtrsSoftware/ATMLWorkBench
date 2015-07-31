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
using System.Text;
using System.Windows.Forms;
using ATML1671Allocator.allocator;
using ATMLCommonLibrary.model;
using ATMLDataAccessLibrary.db.daos;
using ATMLManagerLibrary.managers;
using ATMLModelLibrary.model;
using ATMLModelLibrary.model.common;
using ATMLModelLibrary.model.equipment;
using WeifenLuo.WinFormsUI.Docking;

namespace ATML1671Allocator.forms
{
    public partial class AvailableInstrumentsWindow : DockContent, IATMLDockableWindow
    {
        public AvailableInstrumentsWindow()
        {
            InitializeComponent();
            lvInstruments.Columns.Add("Station");
            lvInstruments.Columns.Add("Model");
            lvInstruments.Columns.Add("Description");
            ATMLAllocator.Instance.TestStationSelected += Instance_TestStationSelected;
            //ATMLAllocator.Instance.InstrumentsCleared += Instance_InstrumentsCleared;
            lvInstruments.Columns[0].Width = -2;
            lvInstruments.Columns[1].Width = -2;
            lvInstruments.Columns[2].Width = -2;
            lvInstruments.Sorting = SortOrder.Ascending;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.F4))
            {
                Console.Beep();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }


        public void CloseProject()
        {
            foreach (ListViewItem lvi in lvInstruments.Items)
                lvi.BackColor = Color.White;
        }

        //private void Instance_InstrumentsCleared(object sender, EventArgs e)
        //{
        //    lvInstruments.Items.Clear();
        //}

        private void Instance_TestStationSelected(object sender, EventArgs e)
        {
            lvInstruments.Items.Clear();

            foreach (TestStationInstrumentData instrument in ATMLAllocator.Instance.AvailableInstruments)
            {
                AddInstrument(instrument, Color.White);
            }
            lvInstruments.Sort();
            lvInstruments.AutoResizeColumns( ColumnHeaderAutoResizeStyle.ColumnContent );
        }

        private void AddInstrument(TestStationInstrumentData testStationInstrumentData, Color bgColor)
        {
            if (testStationInstrumentData != null)
            {
                TestStationDescriptionInstrument testStationInstrument = testStationInstrumentData.TestStationInstrument;
                InstrumentDescription instrument = testStationInstrumentData.InstrumentDescription;
                ItemDescription itemDescription = testStationInstrumentData.ItemDescription;
                string testStationName = testStationInstrumentData.TestStation.name;
                var itm = new ListViewItem( testStationName );
                var modelName = "";
                if (instrument != null)
                {
                    modelName = instrument.name;
                    if (instrument.Identification != null 
                        && instrument.Identification.ModelName != null)
                        modelName = instrument.Identification.ModelName;
                }
                else if (itemDescription != null)
                {
                    modelName = itemDescription.name;
                    if (itemDescription.Identification != null
                        && itemDescription.Identification.ModelName != null)
                        modelName = itemDescription.Identification.ModelName;
                }
                itm.SubItems.Add(modelName);
                itm.SubItems.Add(testStationInstrument.ID);
                itm.BackColor = bgColor;
                itm.Tag = testStationInstrumentData;
                lvInstruments.Items.Add( itm );
            }
        }


        public void ProcessSignal( SignalRequirementsSignalRequirement signalRequirement )
        {
            InstrumentDAO dao = new InstrumentDAO();
            List<Tuple<string, object, string>> attributes = new List<Tuple<string, object, string>>();
            foreach (SignalRequirementsSignalRequirementTsfClassAttribute attribute in signalRequirement.TsfClassAttribute)
            {
                TsfClassAttributeName name = attribute.Name;
                if (attribute.Value != null)
                {
                    if (attribute.Value.Item is DatumType)
                    {
                        DatumType datum = attribute.Value.Item as DatumType;
                        Object value = Datum.GetNominalDatumValue(datum);
                        if (value != null)
                        {
                            attributes.Add(new Tuple<string, object, string>(name.Value, value, datum.unitQualifier));
                        }
                    }
                }
            }

            lvInstruments.BeginUpdate();
            try
            {
                foreach (ListViewItem lvi in lvInstruments.Items)
                    lvi.BackColor = Color.White;

                ICollection<object> ids = dao.FindCapableEquipment(attributes);
                foreach (ListViewItem lvi in lvInstruments.Items)
                {
                    var testStationInstrumentData = lvi.Tag as TestStationInstrumentData;
                    if (testStationInstrumentData != null)
                    {
                        var instrument = testStationInstrumentData.InstrumentDescription;
                        if (instrument != null)
                        {
                            foreach (var id in ids)
                            {
                                if (id.Equals( instrument.uuid ))
                                    lvi.BackColor = Color.PaleGreen;
                            }
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
            lvInstruments.EndUpdate();
        }
    }
}