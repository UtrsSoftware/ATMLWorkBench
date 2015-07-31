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
using System.Linq;
using System.Text;
using System.Xml.Schema;
using ATMLCommonLibrary.controls.capability;
using ATMLCommonLibrary.managers;
using ATMLModelLibrary.model.equipment;
using ATMLSchemaLibrary.managers;
using HardwareItemDescriptionControl = ATMLCommonLibrary.controls.hardware.HardwareItemDescriptionControl;
using Resources = ATMLCommonLibrary.Properties.Resources;

namespace ATMLCommonLibrary.controls.instrument
{
    public partial class InstrumentControl : HardwareItemDescriptionControl
    {
        //private InstrumentDescription _instrumentDescription;

        public InstrumentControl()
        {
            InitializeComponent();
            InitControls();

            capabilitiesControl1.DataObjectRequested+=delegate( object sender, EventArgs args )
                                                      {
                                                          var dataArgs = args as DataObjectRequestEventArgs;
                                                          if (dataArgs != null)
                                                          {
                                                              dataArgs.ObjectItemDescription = InstrumentDescription;
                                                          }
                                                      };

            if (!this.IsInDesignMode())
            {
                cmbInstrumentType.Items.Add(InstrumentDescriptionType.Instrument);
                cmbInstrumentType.Items.Add(InstrumentDescriptionType.Module);
                cmbInstrumentType.Items.Add(InstrumentDescriptionType.Option);
            }

            //-----------------------------------------------------//
            //--- Reorder the tab pages to that of Order of Use ---//
            //-----------------------------------------------------//
            tabPanelControl.TabPages.Clear();
            tabPanelControl.TabPages.Add(tabIdentification);
            tabPanelControl.TabPages.Add(tabDescription);
            tabPanelControl.TabPages.Add(tabInterface);
            tabPanelControl.TabPages.Add(tabResources);
            tabPanelControl.TabPages.Add(tabSwitching);
            tabPanelControl.TabPages.Add(tabNetwork);
            tabPanelControl.TabPages.Add(tabCapabilities);
            tabPanelControl.TabPages.Add(tabComponents);
            tabPanelControl.TabPages.Add(tabParentComponents);
            tabPanelControl.TabPages.Add(tabControl);
            tabPanelControl.TabPages.Add(tabDocumentation);
            tabPanelControl.TabPages.Add(tabConfiguration);
            tabPanelControl.TabPages.Add(tabDefaults);
            tabPanelControl.TabPages.Add(tabRequirements);
            tabPanelControl.TabPages.Add(tabCharacteristics);
            tabPanelControl.TabPages.Add(tabErrors);
            tabPanelControl.TabPages.Add(tabLegal);
            tabPanelControl.TabPages.Add(tabSpecifications);
            tabPanelControl.TabPages.Add(tabPowerOnDefaults);
            tabPanelControl.TabPages.Add(tabBusses);
            tabPanelControl.TabPages.Add(tabPaths);
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public InstrumentDescription InstrumentDescription
        {
            get
            {
                ControlsToData();
                return _hardwareItemDescription as InstrumentDescription;
            }
            set
            {
                _hardwareItemDescription = value;
                DataToControls();
            }
        }

        protected override void ControlsToData()
        {
            if (_hardwareItemDescription == null)
            {
                _hardwareItemDescription = new InstrumentDescription();
                capabilitiesControl1.InstrumentDescription = _hardwareItemDescription as InstrumentDescription;
            }
            if (_hardwareItemDescription != null)
            {
                base.ControlsToData();
                var instrumentDescription = _hardwareItemDescription as InstrumentDescription;
                if (instrumentDescription != null)
                {
                    instrumentDescription.securityClassification = securityClassificationControl.SecurityClassification;
                    instrumentDescription.classified = securityClassificationControl.Classified;
                    instrumentDescription.uuid = edtInstrumentUUID.GetValue<String>();
                    if (cmbInstrumentType.SelectedItem != null)
                        instrumentDescription.type = (InstrumentDescriptionType) cmbInstrumentType.SelectedItem;

                    //----------------------------//
                    //--- Get the capabilities ---//
                    //----------------------------//
                    List<object> capabilityItems = capabilitiesControl1.Capabilities != null ? capabilitiesControl1.Capabilities.Items : null;
                    if (capabilityItems != null && capabilityItems.Count > 0)
                    {
                        if (instrumentDescription.Capabilities == null)
                            instrumentDescription.Capabilities = new Capabilities();
                        instrumentDescription.Capabilities = capabilitiesControl1.Capabilities;
                    }
                    else
                    {
                        instrumentDescription.Capabilities = null;
                    }

                    instrumentDescription.Paths = pathListControl.Paths;

                    //---------------------//
                    //--- Get Resources ---//
                    //---------------------//
                    instrumentDescription.Resources = resourceListControl.Resources;

                    //TODO: Walk through all the capability resource port mappings and rebuild the Capability Mappings

                    //----------------------------//
                    //--- Get Power On Results ---//
                    //----------------------------//
                    instrumentDescription.PowerOnDefaults = powerOnDefaultsListControl.PowerOnDefaults;

                    //--------------------------//
                    //--- Get Specifications ---//
                    //--------------------------//
                    instrumentDescription.Specifications = specificationsControl.Specifications;

                    //---------------------//
                    //--- Get Switching ---//
                    //---------------------//
                    instrumentDescription.Switching = switchingListControl.Switching;

                    //-----------------//
                    //--- Get Buses ---//
                    //-----------------//
                    instrumentDescription.Buses = busListControl.Buses;

                    instrumentDescription.Extension = null;
                }
            }
        }

        protected override void DataToControls()
        {
            if (_hardwareItemDescription == null)
                _hardwareItemDescription = new InstrumentDescription();

            base.DataToControls();

            pathListControl.HardwareItemDescription = _hardwareItemDescription;

            var instrumentDescription = _hardwareItemDescription as InstrumentDescription;
            if (instrumentDescription != null)
            {
                //------------------------------------------------------------------------------------------------------------------------------------//
                //--- Set the Hardware Item Description on the Capabilities Control so any capability references can be added to the Documentation ---//
                //--- TODO: Think about using an Event to notify the Hardware Item Description                                                     ---//
                //------------------------------------------------------------------------------------------------------------------------------------//
                capabilitiesControl1.InstrumentDescription = instrumentDescription;

                securityClassificationControl.SecurityClassification = instrumentDescription.securityClassification;
                securityClassificationControl.Classified = instrumentDescription.classified;

                edtInstrumentUUID.Value = instrumentDescription.uuid;
                cmbInstrumentType.Text = instrumentDescription.type.ToString();

                //----------------------------------//
                //--- Set Hardaware Descriptions ---//
                //----------------------------------//
                hardwareItemDescriptionControl.HardwareItemDescription = instrumentDescription;

                pathListControl.Paths = instrumentDescription.Paths;

                //------------------//
                //--- Set Busses ---//
                //------------------//
                busListControl.Buses = instrumentDescription.Buses;

                //--------------------------//
                //--- Set Specifications ---//
                //--------------------------//
                specificationsControl.Specifications = instrumentDescription.Specifications;

                //------------------------//
                //--- Set Capabilities ---//
                //------------------------//
                if (instrumentDescription.Capabilities != null)
                {
                    capabilitiesControl1.Capabilities = instrumentDescription.Capabilities;
                    //capabilityListControl.CapabilityItems = _instrumentDescription.Capabilities.Items;
                    //capabilityListControl.InstrumentDescription = _instrumentDescription;
                    //TODO: Walk all the interface ports and set each ones mapped resource
                }

                //---------------------//
                //--- Set Resources ---//
                //---------------------//
                resourceListControl.Resources = instrumentDescription.Resources;

                //------------------------------//
                //--- Set Capability Mapping ---//
                //------------------------------//
                if (instrumentDescription.Capabilities != null &&
                    instrumentDescription.Capabilities.CapabilityMap != null)
                    mappingListControl1.Mappings = instrumentDescription.Capabilities.CapabilityMap.ToList();

                //---------------------//
                //--- Set Switching ---//
                //---------------------//
                switchingListControl.Instrument = instrumentDescription;

                //-----------------------------//
                //--- Set Power On Defaults ---//
                //-----------------------------//
                powerOnDefaultsListControl.PowerOnDefaults = instrumentDescription.PowerOnDefaults;

            }
        }

        private void hardwareItemDescriptionControl1_Load(object sender, EventArgs e)
        {
        }

        private void InstrumentControl_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(SchemaTypeName) && !String.IsNullOrEmpty(TargetNamespace))
            {
                XmlSchemaComplexType complexType;
                if (SchemaManager.GetComplexType(TargetNamespace, SchemaTypeName, out complexType))
                {
                }
            }

            errorProvider1.SetError(this, "");
            if (InstrumentDescription == null)
            {
                errorProvider1.SetError(this, "You cannot save an empty Instrument");
                e.Cancel = true;
            }
           //else if (InstrumentDescription.Interface == null)
           // {
           //     errorProvider1.SetError(this, Resources.errmsg_at_least_one_interface_item);
           //     e.Cancel = true;
           // }
        }

        public string GetErrorMessage()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append( errorProvider1.GetError(this) ).Append( Resources.CRLF );
            foreach (  System.Windows.Forms.Control control in this.Controls)
            {
                sb.Append( errorProvider.GetError( control ) );
            }
            return sb.ToString();
        }

        private void btnAddGUID_Click(object sender, EventArgs e)
        {
            Guid iid = Guid.NewGuid();
            edtInstrumentUUID.Value = iid.ToString().ToUpper();
            errorProvider1.SetError(edtInstrumentUUID, ""); //Clear any error that may be on the control
        }
    }
}