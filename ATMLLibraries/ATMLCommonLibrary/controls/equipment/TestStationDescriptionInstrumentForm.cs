/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using ATMLManagerLibrary.controllers;
using ATMLCommonLibrary.forms;
using ATMLCommonLibrary.managers;
using ATMLManagerLibrary.managers;
using ATMLModelLibrary.model.common;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.equipment
{
    public partial class TestStationDescriptionInstrumentForm : ATMLForm
    {
        public TestStationDescriptionInstrumentForm()
        {
            InitializeComponent();
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TestStationDescriptionInstrument TestStationDescriptionInstrument
        {
            set { testStationDescriptionInstrumentControl1.TestStationDescriptionInstrument = value; }
            get { return testStationDescriptionInstrumentControl1.TestStationDescriptionInstrument; }
        }

        public void AddSelectedDocumentId(string uuid)
        {
            testStationDescriptionInstrumentControl1.AddSelectedDocumentId(uuid);
        }

        private void btnEditObject_Click(object sender, EventArgs e)
        {
            TestStationDescriptionInstrument tsi =
                testStationDescriptionInstrumentControl1.TestStationDescriptionInstrument;

            if (tsi != null && tsi.Item != null)
            {
                var docRef = tsi.Item as DocumentReference;
                if (docRef != null)
                {
                    Document document = DocumentManager.GetDocument(docRef.uuid);
                    if (document == null)
                    {
                        MessageBox.Show(string.Format("Test Station Instrument \"{0}\" does not exist in the document database.", docRef.uuid));
                    }
                    else
                    {
                        InstrumentDescription instrument =
                            InstrumentDescription.Deserialize(Encoding.UTF8.GetString(document.DocumentContent));
                        var form = new InstrumentForm();
                        form.InstrumentDescription = instrument;
                        //form.TopMost = true;
                        Visible = false;
                        form.Closed += delegate
                        {
                            if (DialogResult.OK == form.DialogResult)
                            {
                                instrument = form.InstrumentDescription;
                                document.DocumentContent = Encoding.UTF8.GetBytes(instrument.Serialize());
                                PersistanceController.Save(document);
                            }
                            Visible = true;
                        };
                        form.Show(this);
                    }
                }
            }
        }
    }
}