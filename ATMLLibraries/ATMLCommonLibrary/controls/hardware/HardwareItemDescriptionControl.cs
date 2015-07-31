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
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using ATMLCommonLibrary.managers;
using ATMLManagerLibrary.managers;
using ATMLModelLibrary.model.common;
using ATMLModelLibrary.model.equipment;
using ATMLSchemaLibrary.managers;
using Resources = ATMLCommonLibrary.Properties.Resources;

namespace ATMLCommonLibrary.controls.hardware
{
    public partial class HardwareItemDescriptionControl : ATMLControl
    {
        protected HardwareItemDescription _hardwareItemDescription = null;
        private int _lastTab = -1;

        public HardwareItemDescriptionControl()
        {
            InitializeComponent();
            InitControls();
            tabPanelControl.MouseMove += new MouseEventHandler(tabControl_MouseMove);
            tabPanelControl.MouseLeave += new EventHandler(tabControl_MouseLeave);
            RequirementsTabControl.ShowToolTips = true;
        }

        void tabControl_MouseLeave(object sender, EventArgs e)
        {
            ToolTip.SetToolTip(tabPanelControl, null);
            _lastTab = -1;
        }

        void tabControl_MouseMove(object sender, MouseEventArgs e)
        {
            int tabIdx = TestTab( new Point( e.X, e.Y ) );
            if (tabIdx != -1 && _lastTab != tabIdx)
            {
                _lastTab = tabIdx;
                ToolTip.SetToolTip( tabPanelControl, tabPanelControl.TabPages[tabIdx].ToolTipText );
            }
        }

        private int TestTab( Point pt )
        {
            int idx = -1;
            for ( int i = 0; i<tabPanelControl.TabPages.Count; i++ )
            {
                try
                {
                    if (tabPanelControl.GetTabRect(i).Contains(pt))
                    {
                        idx = i;
                    }
                }
                catch (Exception e)
                {
                    /* */
                    Console.WriteLine( e.StackTrace );
                }
            }
            return idx;
        }

        [Browsable( false ), DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
        public HardwareItemDescription HardwareItemDescription
        {
            get
            {
                ControlsToData();
                return _hardwareItemDescription;
            }
            set
            {
                _hardwareItemDescription = value;
                DataToControls();
            }
        }

        protected virtual void DataToControls()
        {
            if (_hardwareItemDescription != null)
            {
                //--------------------------------------------------------------//
                //--- Only Enable the Add UUID Button if the uuid is missing ---//
                //--------------------------------------------------------------//
                List<object> interfaceItem = _hardwareItemDescription.Interface == null
                                                 ? new List<object>()
                                                 : _hardwareItemDescription.Interface.ToList();
                edtDescription.Value = _hardwareItemDescription.Description;
                interfaceListControl.SetInterfaceItems( interfaceItem );
                componentListControl.ItemComponents = _hardwareItemDescription.Components != null
                                                          ? _hardwareItemDescription.Components.ToList()
                                                          : new List<HardwareItemDescriptionComponent>();
                ItemDescription itemDescription = _hardwareItemDescription;
                ItemDescriptionIdentification identification = itemDescription.Identification;

                identificationControl.Identification =
                    identification;
                edtVersion.Value =
                    _hardwareItemDescription.version;
                edtName.Value =
                    _hardwareItemDescription.name;
                configurationOptionListControl.HardwareItemDescriptionOptions =
                    _hardwareItemDescription.ConfigurationOptions;
                documentListControl.Documents =
                    _hardwareItemDescription.Documentation;
                legalDocumentListControl.LegalDocuments =
                    _hardwareItemDescription.LegalDocuments;
                physicalCharacteristicsControl.PhysicalCharacteristics =
                    _hardwareItemDescription.PhysicalCharacteristics;
                operationalRequirementsControl.OperationalRequirements =
                    _hardwareItemDescription.OperationalRequirements;
                factoryDefaultsListControl.FactoryDefaults =
                    _hardwareItemDescription.FactoryDefaults;
                parentComponentListControl.ItemComponents =
                    _hardwareItemDescription.ParentComponents;
                networkListControl.HardwareItemDescription =
                    _hardwareItemDescription;
                controlControl.HardwareHardwareItemDescriptionControl
                    = _hardwareItemDescription.Control;
                calibrationRequirementListControl.CalibrationRequirements =
                    _hardwareItemDescription.CalibrationRequirements;
                environmentalRequirementsControl1.EnvironmentalRequirements =
                    _hardwareItemDescription.EnvironmentalRequirements;
                errorListControl.Errors = _hardwareItemDescription.Errors;
                powerRequirementListControl.PowerRequirements
                    = _hardwareItemDescription.PowerRequirements;
            }
        }

        protected virtual void ControlsToData()
        {
            if (_hardwareItemDescription != null)
            {
                _hardwareItemDescription.Description = edtDescription.GetValue<string>();
                //----------------------------------------//
                //--- Get Interface data from controls ---//
                //----------------------------------------//
                List<object> interfaceItem = interfaceListControl.PhysicalInterface.Items;
                _hardwareItemDescription.Interface = ( interfaceItem == null || interfaceItem.Count == 0 )
                                                         ? null
                                                         : interfaceItem;

                //----------------------------------------//
                //--- Get Component data from controls ---//
                //----------------------------------------//
                _hardwareItemDescription.Components = ( componentListControl.ItemComponents == null
                                                        || componentListControl.ItemComponents.Count == 0 )
                                                          ? null
                                                          : componentListControl.ItemComponents;

                //--------------------------------//
                //--- Get Hardware Description ---//
                //--------------------------------//
                ItemDescription itemDescription = _hardwareItemDescription;
                itemDescription.Identification = identificationControl.Identification;
                _hardwareItemDescription.version = edtVersion.GetValue<string>();
                _hardwareItemDescription.name = edtName.GetValue<string>();

                //-----------------------------//
                //--- Get Regular Documents ---//
                //-----------------------------//
                _hardwareItemDescription.Documentation = documentListControl.Documents;

                //---------------------------//
                //--- Get Legal Documents ---//
                //---------------------------//
                _hardwareItemDescription.LegalDocuments = legalDocumentListControl.LegalDocuments;

                //------------------------------------//
                //--- Get Physical Characteristics ---//
                //------------------------------------//
                _hardwareItemDescription.PhysicalCharacteristics =
                    physicalCharacteristicsControl.PhysicalCharacteristics;

                //-----------------------------//
                //--- Get Parent Components ---//
                //-----------------------------//
                _hardwareItemDescription.ParentComponents =
                    parentComponentListControl.ItemComponents;

                //------------------------------------//
                //--- Get Operational Requirements ---//
                //------------------------------------//
                _hardwareItemDescription.OperationalRequirements =
                    operationalRequirementsControl.OperationalRequirements;

                //------------------------//
                //--- Get Network List ---//
                //------------------------//
                if (networkListControl.HardwareItemDescription != null)
                {
                    _hardwareItemDescription.NetworkList =
                        networkListControl.HardwareItemDescription.NetworkList;
                }

                //----------------------------//
                //--- Get Factory Defaults ---//
                //----------------------------//
                _hardwareItemDescription.FactoryDefaults =
                    factoryDefaultsListControl.FactoryDefaults;

                //---------------------------------//
                //--- Get Configuration Options ---//
                //---------------------------------//
                _hardwareItemDescription.ConfigurationOptions =
                    configurationOptionListControl.HardwareItemDescriptionOptions;

                //----------------------------------//
                //--- Get Hardware Controll Data ---//
                //----------------------------------//
                _hardwareItemDescription.Control =
                    controlControl.HardwareHardwareItemDescriptionControl;

                //-----------------------------------------//
                //--- Get Calibration Requirements Data ---//
                //-----------------------------------------//
                _hardwareItemDescription.CalibrationRequirements =
                    calibrationRequirementListControl.CalibrationRequirements;

                //-----------------------------------------//
                //--- Get Environment Requirements Data ---//
                //-----------------------------------------//
                _hardwareItemDescription.EnvironmentalRequirements =
                    environmentalRequirementsControl1.EnvironmentalRequirements;

                //--------------------------//
                //--- Get Harware Errors ---//
                //--------------------------//
                _hardwareItemDescription.Errors = errorListControl.Errors;

                //------------------------------------//
                //--- Get Operational Requirements ---//
                //------------------------------------//
                _hardwareItemDescription.OperationalRequirements
                    = operationalRequirementsControl.OperationalRequirements;

                //------------------------------//
                //--- Get Power Requirements ---//
                //------------------------------//
                _hardwareItemDescription.PowerRequirements
                    = powerRequirementListControl.PowerRequirements;
            }
        }

        private void HardwareItemDescriptionControl_Validating( object sender, CancelEventArgs e )
        {
            tabInterface.BackColor = Color.White;
            operationalRequirementsControl.HasErrors = false;
            interfaceListControl.HasErrors = false;
            legalDocumentListControl.HasErrors = false;
            errorProvider.SetError( interfaceListControl, "" );
            errorProvider.SetError( operationalRequirementsControl, "" );
            errorProvider.SetError( legalDocumentListControl, "" );

            foreach (TabPage tabPage in tabPanelControl.TabPages)
                tabPage.ToolTipText = "";

            //-------------------------------------------------------------------------------------------------------//
            //--- TODO: Would like to generically walk all the tab controls to validate and set the tooltip text. ---//
            //-------------------------------------------------------------------------------------------------------//
            string defError;
            if (factoryDefaultsListControl.FactoryDefaults != null &&
                !factoryDefaultsListControl.Validate( out defError ))
            {
                errorProvider.SetError(factoryDefaultsListControl, defError );
                tabDefaults.ToolTipText = defError;
                OnError(sender, errorProvider.GetError(this));
            }

            if (identificationControl.Identification == null
                || string.IsNullOrEmpty( identificationControl.Identification.ModelName ))
            {
                errorProvider.SetError(identificationControl, Resources.errmsg_An_Identification_Model_Name_is_required_);
                tabIdentification.ToolTipText = Resources.errmsg_An_Identification_Model_Name_is_required_;
                e.Cancel = true;
                OnError(sender, errorProvider.GetError(this));
            }

            if (operationalRequirementsControl.OperationalRequirements != null)
            {
                var errors = new SchemaValidationResult();
                if (!operationalRequirementsControl.OperationalRequirements.Validate( errors ))
                {
                    errorProvider.SetError( operationalRequirementsControl, errors.ErrorMessage );
                    tabRequirements.ToolTipText = errors.ErrorMessage;
                    tabOperational.ToolTipText = errors.ErrorMessage;
                    operationalRequirementsControl.HasErrors = true;
                    OnError( sender, errors.ErrorMessage );
                }
            }

            if (interfaceListControl.PhysicalInterface != null
                && ( interfaceListControl.PhysicalInterface.Items == null || (interfaceListControl.PhysicalInterface.Items != null
                && interfaceListControl.PhysicalInterface.Items.Count == 0 )) )
            {
                errorProvider.SetError( interfaceListControl, Resources.errmsg_at_least_one_interface_item );
                tabInterface.ToolTipText = Resources.errmsg_at_least_one_interface_item;
                interfaceListControl.HasErrors = true;
                OnError( sender, errorProvider.GetError( this ) );
            }

            if (legalDocumentListControl.LegalDocuments != null)
            {
                string error;
                if (!legalDocumentListControl.Validate( out error ))
                {
                    tabLegal.ToolTipText = error;
                    legalDocumentListControl.HasErrors = true;
                    errorProvider.SetError(legalDocumentListControl, error );
                    OnError(sender, errorProvider.GetError(this));
                }
            }

        }

        private void tabControl1_DrawItem( object sender, DrawItemEventArgs e )
        {
            Graphics g;
            g = e.Graphics;
            bool hasErrors = CheckForErrors(tabPanelControl.TabPages[e.Index].Controls) || !String.IsNullOrEmpty(tabPanelControl.TabPages[e.Index].ToolTipText);
            bool isSelected = e.Index == tabPanelControl.SelectedIndex;
            string sText = tabPanelControl.TabPages[e.Index].Text;
            SizeF sizeText = g.MeasureString( sText, tabPanelControl.Font );
            int iX = e.Bounds.Left + 6;
            int iY = e.Bounds.Top + (int) ( e.Bounds.Height - sizeText.Height )/2;
            tabPanelControl.TabPages[e.Index].ForeColor = Color.Black;
            if (hasErrors)
            {
                g.FillRectangle( isSelected ? Brushes.Red : Brushes.DarkRed, e.Bounds );
            }
            else if (isSelected)
            {
                g.FillRectangle( Brushes.LightGreen, e.Bounds );
            }

            string imageName = sText.Replace( " ", "_" ).ToLower();
            Image image = hasErrors ? errorProvider.Icon.ToBitmap() : ImageManager.GetImage( imageName + "16" );
            if (image != null)
                g.DrawImage( image, iX - 1, iY - 1, 16, 16 );
            g.DrawString( sText, tabPanelControl.Font, hasErrors ? Brushes.Yellow : Brushes.Black, iX + 16, iY );
        }
    }
}