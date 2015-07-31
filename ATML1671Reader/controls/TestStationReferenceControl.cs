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
using System.Text;
using System.Windows.Forms;
using ATML1671Reader.forms;
using ATMLCommonLibrary.controls.equipment;
using ATMLCommonLibrary.controls.lists;
using ATMLCommonLibrary.forms;
using ATMLDataAccessLibrary.model;
using ATMLManagerLibrary.controllers;
using ATMLManagerLibrary.managers;
using ATMLModelLibrary.model.common;
using ATMLModelLibrary.model.equipment;
using ATMLUtilitiesLibrary;

namespace ATML1671Reader.controls
{
    public partial class TestStationReferenceControl : UserControl
    {
        private List<TestConfigurationTestEquipmentItem> _testEquipment =
            new List<TestConfigurationTestEquipmentItem>();

        public TestStationReferenceControl()
        {
            InitializeComponent();
            InitSoftwareList();
            InitInstrumentList();
            InitTestStationList();
            InitResourceList();
            SetControlStates();
        }

        [Browsable( false ), DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
        public List<TestConfigurationTestEquipmentItem> TestEquipment
        {
            get
            {
                ControlsToData();
                return _testEquipment;
            }
            set
            {
                _testEquipment = value;
                DataToControls();
            }
        }

        private void ControlsToData()
        {
            if (_testEquipment == null)
                _testEquipment = new List<TestConfigurationTestEquipmentItem>();

            if (testEquipmentListControl.Items.Count > 0)
            {
                foreach (ListViewItem lvi in testEquipmentListControl.Items)
                {
                    var item = lvi.Tag as TestConfigurationTestEquipmentItem;
                    if (item != null)
                    {
                        _testEquipment.Add( item );
                    }
                }
            }
        }

        private void DataToControls()
        {
            LoadTestStations( _testEquipment );
        }

        public void Clear()
        {
            resourceListControl.Items.Clear();
            softwareListControl.Items.Clear();
            testEquipmentListControl.Items.Clear();
            instrumentationListControl.Items.Clear();
        }

        private void InitInstrumentList()
        {
            instrumentationListControl.DataObjectName = "ItemDescriptionReference";
            instrumentationListControl.DataObjectFormType = typeof (ItemDescriptionReferenceForm);
            instrumentationListControl.AddColumnData( "Instrument", "ToString()", 1.00 );
            instrumentationListControl.InitColumns();
            instrumentationListControl.CompletedAdd += instrumentationListControl_CompletedAdd;
            instrumentationListControl.CompletedDelete += instrumentationListControl_CompletedDelete;
            instrumentationListControl.InitializeForm += delegate(Form form)
            {
                var itemReferenceForm =
                    form as ItemDescriptionReferenceForm;
                if (itemReferenceForm != null)
                {
                    itemReferenceForm.DocumentType = dbDocument.DocumentType.INSTRUMENT_DESCRIPTION;
                }
            };
        }


        private void InitResourceList()
        {
            resourceListControl.DataObjectName = "ItemDescriptionReference";
            resourceListControl.DataObjectFormType = typeof(ItemDescriptionReferenceForm);
            resourceListControl.AddColumnData("Resource", "ToString()", 1.00);
            resourceListControl.InitColumns();
            resourceListControl.CompletedAdd += resourceListControl_CompletedAdd;
            resourceListControl.CompletedDelete += resourceListControl_CompletedDelete;
            resourceListControl.InitializeForm += delegate(Form form)
            {
                var itemReferenceForm =
                    form as ItemDescriptionReferenceForm;
                if (itemReferenceForm != null)
                {
                    itemReferenceForm.DocumentType = dbDocument.DocumentType.INSTRUMENT_DESCRIPTION;
                }
            };
        }

        private void resourceListControl_CompletedDelete(object obj)
        {
            var item = testEquipmentListControl.SelectedObject as TestConfigurationTestEquipmentItem;
            var reference = obj as ItemDescriptionReference;
            if (item != null && reference != null)
            {
                item.Resource.Remove(reference);
            }
        }

        private void resourceListControl_CompletedAdd(object obj)
        {
            var item = testEquipmentListControl.SelectedObject as TestConfigurationTestEquipmentItem;
            var reference = obj as ItemDescriptionReference;
            if (item != null && reference != null)
            {
                item.Resource.Add(reference);
            }
        }



        private void instrumentationListControl_CompletedDelete( object obj )
        {
            var item = testEquipmentListControl.SelectedObject as TestConfigurationTestEquipmentItem;
            var reference = obj as ItemDescriptionReference;
            if (item != null && reference != null)
            {
                item.Instrumentation.Remove( reference );
            }
        }

        private void instrumentationListControl_CompletedAdd( object obj )
        {
            var item = testEquipmentListControl.SelectedObject as TestConfigurationTestEquipmentItem;
            var reference = obj as ItemDescriptionReference;
            if (item != null && reference != null)
            {
                item.Instrumentation.Add( reference );
            }
        }

        private void InitTestStationList()
        {
            testEquipmentListControl.DataObjectName = "ItemDescriptionReference";
            testEquipmentListControl.DataObjectFormType = typeof (ItemDescriptionReferenceForm);
            testEquipmentListControl.AddColumnData( "Equipment", "ToString()", 1.00 );
            testEquipmentListControl.InitColumns();
            testEquipmentListControl.CompletedAdd += testStationListControl_CompletedAdd;
            testEquipmentListControl.CompletedEdit += testStationListControl_CompletedEdit;
            testEquipmentListControl.CompletedDelete += testStationListControl_CompletedDelete;
            testEquipmentListControl.SelectedIndexChanged += testStationListControl_SelectedIndexChanged;
            testEquipmentListControl.OnFind += testStationListControl_OnFind;
            testEquipmentListControl.ShowFind = true;
            testEquipmentListControl.InitializeForm += delegate(Form form)
            {
                var itemReferenceForm =
                    form as ItemDescriptionReferenceForm;
                if (itemReferenceForm != null)
                {
                    ItemDescriptionReference itemRef = itemReferenceForm.ItemDescriptionReference;
                    if (!( itemRef is TestConfigurationTestEquipmentItem ))
                    {
                        itemReferenceForm.ItemDescriptionReference = new TestConfigurationTestEquipmentItem();
                        itemReferenceForm.ItemDescriptionReference.Item = itemRef.Item;
                    }
                    itemReferenceForm.DocumentType = dbDocument.DocumentType.TEST_STATION_DESCRIPTION;
                }
            };

        }

        private void testStationListControl_OnFind()
        {
            var form = new ATMLLibraryForm(typeof(TestStationListControl));
            if (DialogResult.OK == form.ShowDialog())
            {
                var testStation = form.SelectedObject as TestStationDescription11;
                Document document = DocumentManager.GetDocument( testStation.uuid );
                if (document != null)
                {
                    var reference = new TestConfigurationTestEquipmentItem();
                    var documentReference = new DocumentReference();
                    documentReference.ContentType = ATMLContext.CONTEXT_TYPE_XML;
                    documentReference.DocumentContent = Encoding.UTF8.GetBytes( testStation.Serialize() );
                    documentReference.DocumentName = document.name;
                    documentReference.DocumentType = document.DocumentType;
                    documentReference.ID = testStation.Identification.ModelName;
                    documentReference.uuid = testStation.uuid;
                    reference.Item = documentReference;
                    testEquipmentListControl.AddListViewObject( reference );
                }
            }
        }

        private void testStationListControl_CompletedDelete( object obj )
        {
            SaveTestStation( obj as TestStationDescription11 );
        }

        private void testStationListControl_CompletedEdit( object obj )
        {
            SaveTestStation( obj as TestStationDescription11 );
        }

        private void SaveTestStation( TestStationDescription11 testStation )
        {
            if (testStation != null)
            {
                string content = testStation.Serialize();
                Document document = DocumentManager.GetDocument( testStation.uuid );
                if (document != null)
                {
                    document.DocumentContent = Encoding.UTF8.GetBytes( content );
                    PersistanceController.Save( document );
                }
            }
        }

        private void testStationListControl_CompletedAdd( object obj )
        {
        }

        private void InitSoftwareList()
        {
            softwareListControl.DataObjectName = "SoftwareInstance";
            softwareListControl.DataObjectFormType = typeof (SoftwareInstanceForm);
            softwareListControl.AddColumnData( "Serial No", "SerialNumber", .20 );
            softwareListControl.AddColumnData( "Release Date", "ReleaseDate", .20 );
            softwareListControl.AddColumnData( "Value", "ToString()", .60 );
            softwareListControl.InitColumns();
            softwareListControl.ShowFind = false;
            softwareListControl.CompletedAdd += softwareListControl_CompletedAdd;
            softwareListControl.CompletedDelete += softwareListControl_CompletedDelete;
            softwareListControl.CompletedEdit += softwareListControl_CompletedEdit;
            softwareListControl.InitializeForm += delegate( Form form )
                                                  {
                                                      var softwareInstanceForm =
                                                          form as SoftwareInstanceForm;
                                                      if (softwareInstanceForm != null)
                                                      {
                                                          softwareInstanceForm.DocumentType =
                                                              dbDocument.DocumentType.SUP_SOFTWARE;
                                                      }
                                                  };
        }

        private void softwareListControl_CompletedEdit( object obj )
        {
            var item = testEquipmentListControl.SelectedObject as TestConfigurationTestEquipmentItem;
            var software = obj as SoftwareInstance;
            if (item != null && software != null)
            {
                software.ReleaseDateSpecified = UTRSDateUtils.IsGoodDate(software.ReleaseDate);
            }
        }

        private void softwareListControl_CompletedDelete( object obj )
        {
            var item = testEquipmentListControl.SelectedObject as TestConfigurationTestEquipmentItem;
            var software = obj as SoftwareInstance;
            if (item != null && software != null)
            {
                item.Software.Remove( software );
            }
        }

        private void softwareListControl_CompletedAdd( object obj )
        {
            var item = testEquipmentListControl.SelectedObject as TestConfigurationTestEquipmentItem;
            var software = obj as SoftwareInstance;
            if (item != null && software != null)
            {
                software.ReleaseDateSpecified = UTRSDateUtils.IsGoodDate(software.ReleaseDate);
                item.Software.Add(software);
            }
        }

        private void SetControlStates()
        {
            bool testEquipmentSelected = testEquipmentListControl.SelectedObject != null;
            instrumentationListControl.Enabled = testEquipmentSelected;
            softwareListControl.Enabled = testEquipmentSelected;
            resourceListControl.Enabled = testEquipmentSelected;
        }

        private void LoadTestStations( IEnumerable<TestConfigurationTestEquipmentItem> equipmentList )
        {
            testEquipmentListControl.Items.Clear();
            instrumentationListControl.Items.Clear();
            foreach (TestConfigurationTestEquipmentItem equipment in equipmentList)
            {
                testEquipmentListControl.AddListViewObject( equipment );
            }
        }


        private void ProcessInstruments( IEnumerable<ItemDescriptionReference> instrumentation )
        {
            ProcessItemControl( instrumentation, instrumentationListControl );
        }

        private void ProcessResources( IEnumerable<ItemDescriptionReference> resources )
        {
            ProcessItemControl( resources, resourceListControl );
        }

        private void ProcessSoftware( IEnumerable<SoftwareInstance> software )
        {
            ProcessItemControl( software, softwareListControl );
        }

        private void ProcessItemControl( IEnumerable<ItemDescriptionReference> referenceList,
                                         ATMLListControl listControl )
        {
            listControl.Items.Clear();
            foreach (object obj in referenceList)
            {
                listControl.AddListViewObject( obj );
            }
        }


        private void testStationListControl_SelectedIndexChanged( object sender, EventArgs e )
        {
            var item = testEquipmentListControl.SelectedObject as TestConfigurationTestEquipmentItem;
            if (item != null)
            {
                List<ItemDescriptionReference> instrumentation = item.Instrumentation;
                List<ItemDescriptionReference> resources = item.Resource;
                List<SoftwareInstance> software = item.Software;
                ProcessInstruments( instrumentation );
                ProcessResources( resources );
                ProcessSoftware( software );
            }
            SetControlStates();
        }
    }
}