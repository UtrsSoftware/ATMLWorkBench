/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.ComponentModel;
using ATMLCommonLibrary.controls.capability;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.equipment
{
    public partial class TestAdapterControl : TestEquipmentControl
    {
        public TestAdapterControl()
        {
            InitializeComponent();
            //----------------------------//
            //--- Resequence Tab Pages ---//
            //----------------------------//
            tabPanelControl.TabPages.Clear();
            tabPanelControl.TabPages.Add( tabIdentification );
            tabPanelControl.TabPages.Add( tabDescription );
            tabPanelControl.TabPages.Add( tabInterface );
            tabPanelControl.TabPages.Add( tabResources );
            tabPanelControl.TabPages.Add( tabSwitching );
            tabPanelControl.TabPages.Add( tabNetwork );
            tabPanelControl.TabPages.Add( tabCapabilities );
            tabPanelControl.TabPages.Add( tabComponents );
            tabPanelControl.TabPages.Add( tabParentComponents );
            tabPanelControl.TabPages.Add( tabControl );
            tabPanelControl.TabPages.Add( tabSpecifications );
            tabPanelControl.TabPages.Add( tabPaths );
            tabPanelControl.TabPages.Add( tabSoftware );
            tabPanelControl.TabPages.Add( tabControllers );
            tabPanelControl.TabPages.Add( tabFacilities );
            tabPanelControl.TabPages.Add( tabTerminalBlocks );
            tabPanelControl.TabPages.Add( tabErrors );
            tabPanelControl.TabPages.Add( tabCharacteristics );
            tabPanelControl.TabPages.Add( tabRequirements );
            tabPanelControl.TabPages.Add( tabDefaults );
            tabPanelControl.TabPages.Add( tabConfiguration );
            tabPanelControl.TabPages.Add( tabLegal );
            tabPanelControl.TabPages.Add( tabDocumentation );

            capabilitiesControl1.DataObjectRequested += delegate( object sender, EventArgs args )
                                                        {
                                                            var dataArgs = args as DataObjectRequestEventArgs;
                                                            if (dataArgs != null)
                                                            {
                                                                dataArgs.ObjectItemDescription = TestAdapter;
                                                            }
                                                        };

            Validating += TestAdapterControl_Validating;
        }


        [Browsable( false ), DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
        public TestAdapterDescription1 TestAdapter
        {
            get
            {
                ControlsToData();
                return _hardwareItemDescription as TestAdapterDescription1;
            }
            set
            {
                _hardwareItemDescription = value;
                DataToControls();
            }
        }

        private void TestAdapterControl_Validating( object sender, CancelEventArgs e )
        {
            TestAdapterDescription1 testAdapterDescription = TestAdapter;
            if (testAdapterDescription != null)
            {
            }
        }

        private void btnAddGUID_Click( object sender, EventArgs e )
        {
            Guid iid = Guid.NewGuid();
            edtUUID.Text = iid.ToString();
        }

        protected override void DataToControls()
        {
            base.DataToControls();
            pathListControl1.HardwareItemDescription = _hardwareItemDescription;
            var testAdapter = _hardwareItemDescription as TestAdapterDescription1;
            if (testAdapter != null)
            {
                capabilitiesControl1.TestAdapterDescription = testAdapter;
                edtUUID.Value = testAdapter.uuid;
                securityClassificationControl.Classified = testAdapter.classified;
                securityClassificationControl.SecurityClassification = testAdapter.securityClassification;
            }
        }

        protected override void ControlsToData()
        {
            if (_hardwareItemDescription == null)
                _hardwareItemDescription = new TestAdapterDescription1();
            base.ControlsToData();
            var testAdapter = _hardwareItemDescription as TestAdapterDescription1;
            if (testAdapter != null)
            {
                testAdapter.uuid = edtUUID.GetValue<string>();
                testAdapter.classified = securityClassificationControl.Classified;
                testAdapter.securityClassification = securityClassificationControl.SecurityClassification;
            }
        }
    }
}