/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Schema;
using ATMLCommonLibrary.controls.capability;
using ATMLCommonLibrary.managers;
using ATMLModelLibrary.model.equipment;
using Resources = ATMLCommonLibrary.Properties.Resources;

namespace ATMLCommonLibrary.controls.equipment
{
    public partial class TestStationControl : TestEquipmentControl
    {
        public TestStationControl()
        {
            InitializeComponent();
            this.Validating += new CancelEventHandler(TestStationControl_Validating);

            //-------------------------//
            //--- Re Order the tabs ---//
            //-------------------------//
            tabPanelControl.TabPages.Clear();
            tabPanelControl.TabPages.Add(tabIdentification); //0
            tabPanelControl.TabPages.Add(tabDescription); //1
            tabPanelControl.TabPages.Add(tabInterface); //2
            tabPanelControl.TabPages.Add(tabResources); //3
            tabPanelControl.TabPages.Add(tabCapabilities); //4
            tabPanelControl.TabPages.Add(tabSwitching); //5
            tabPanelControl.TabPages.Add(tabInstruments); //6
            tabPanelControl.TabPages.Add(tabSpecifications); //7
            tabPanelControl.TabPages.Add(tabNetwork); //8
            tabPanelControl.TabPages.Add(tabPaths); //9
            tabPanelControl.TabPages.Add(tabSoftware); //10
            tabPanelControl.TabPages.Add(tabControllers); //11
            tabPanelControl.TabPages.Add(tabFacilities); //12
            tabPanelControl.TabPages.Add(tabTerminalBlocks); //13
            tabPanelControl.TabPages.Add(tabErrors); //14
            tabPanelControl.TabPages.Add(tabCharacteristics); //15
            tabPanelControl.TabPages.Add(tabRequirements); //16
            tabPanelControl.TabPages.Add(tabDefaults); //17
            tabPanelControl.TabPages.Add(tabConfiguration); //18
            tabPanelControl.TabPages.Add(tabDocumentation); //19
            tabPanelControl.TabPages.Add(tabLegal); //20
            tabPanelControl.TabPages.Add(tabControl); //21
            tabPanelControl.TabPages.Add(tabComponents); //22
            tabPanelControl.TabPages.Add(tabParentComponents); //23

            identificationControl.Error += identificationControl_Error;

            capabilitiesControl1.DataObjectRequested += delegate(object sender, EventArgs args)
            {
                var dataArgs = args as DataObjectRequestEventArgs;
                if (dataArgs != null)
                {
                    dataArgs.ObjectItemDescription = TestStationDescription;
                }
            };

        }

        void TestStationControl_Validating(object sender, CancelEventArgs e)
        {
            TestStationDescription testStationDescription = TestStationDescription;
            if (testStationDescription != null)
            {
                testStationDescriptionInstrumentListControl1.HasErrors = false;
                errorProvider.SetError(testStationDescriptionInstrumentListControl1, "");
                if (testStationDescription.Instruments == null || testStationDescription.Instruments.Count == 0)
                {
                    errorProvider.SetError(testStationDescriptionInstrumentListControl1,
                                            Resources.errMsg_You_must_add_at_least_one_instrument );
                    tabInstruments.ToolTipText = Resources.errMsg_You_must_add_at_least_one_instrument;
                    testStationDescriptionInstrumentListControl1.HasErrors = true;
                    e.Cancel = true;
                    OnError(sender, errorProvider.GetError(testStationDescriptionInstrumentListControl1));
                }
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TestStationDescription11 TestStationDescription
        {
            set
            {
                _hardwareItemDescription = value;
                DataToControls();
            }
            get
            {
                ControlsToData();
                return _hardwareItemDescription as TestStationDescription11;
            }
        }

        private void identificationControl_Error(object sender, EventArgs e)
        {
            ValidationEventArgs args = e as ValidationEventArgs;
            if (args != null)
            {
                Console.WriteLine( args.Message );
            }
        }


        protected override void DataToControls()
        {
            base.DataToControls();
            var testStation = _hardwareItemDescription as TestStationDescription11;
            if (testStation != null)
            {
                base.DataToControls();
                testStationDescriptionInstrumentListControl1.TestStationDescriptionInstruments = testStation.Instruments;
                capabilitiesControl1.TestStationDescription = testStation;
                edtUUID.Value = testStation.uuid;
            }
        }

        protected override void ControlsToData()
        {
            if( _hardwareItemDescription == null )
                _hardwareItemDescription = new TestStationDescription11();
            base.ControlsToData();
            var testStation = _hardwareItemDescription as TestStationDescription11;
            if (testStation != null)
            {
                testStation.Instruments = testStationDescriptionInstrumentListControl1.TestStationDescriptionInstruments;
                testStation.uuid = edtUUID.GetValue<string>();
            }
        }

        private void tabDocumentation_Click(object sender, EventArgs e)
        {
        }

        private void btnAddGUID_Click(object sender, EventArgs e)
        {
            bool ok2Create = true;
            Guid iid = Guid.NewGuid();
            if (edtUUID.Value != null)
            {
                ok2Create =
                    DialogResult.Yes == MessageBox.Show(@"Create a new UUID overwriting the existing one?",
                        @"Overwrite UUID",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
            }
            if (ok2Create)
            {
                edtUUID.Value = iid.ToString().ToUpper();
                errorProvider.SetError(edtUUID, ""); //Clear any error that may be on the control       
            }
        }
    }
}