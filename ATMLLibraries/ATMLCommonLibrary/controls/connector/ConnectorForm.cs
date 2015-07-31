/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ATMLCommonLibrary.forms;
using ATMLDataAccessLibrary.db.beans;
using ATMLDataAccessLibrary.db.daos;
using ATMLDataAccessLibrary.managers;
using ATMLDataAccessLibrary.model;
using ATMLManagerLibrary.managers;
using ATMLModelLibrary.model.common;

namespace ATMLCommonLibrary.controls.connector
{
    public partial class ConnectorForm : ATMLForm
    {
        private Connector _connector;

        public ConnectorForm()
        {
            InitializeComponent();
            //dvPins.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Sunken;
            _connector = new Connector();
            CacheManager.getCache( LuConnectorBean._TABLE_NAME ).loadComboBox( cbConnectorType );
            CacheManager.getCache( LuConnectorBean._TABLE_NAME ).loadComboBox( cbConnectorMatingType );
            cmbConnectorLocation.Items.Clear();
            cmbConnectorLocation.Items.Add( ConnectorLocationEnum.Back );
            cmbConnectorLocation.Items.Add( ConnectorLocationEnum.Front );
            ValidateSchema += ConnectorForm_ValidateSchema;
            UndoChanges += ConnectorForm_UndoChanges;
        }

        public Connector Connector
        {
            get
            {
                ControlsToData();
                return _connector;
            }
            set
            {
                originalSerializedATMLObject = value.Serialize();
                _connector = value;
                DataToControls();
            }
        }

        private void ConnectorForm_UndoChanges( object sender, EventArgs e )
        {
            Connector = Connector.Deserialize( originalSerializedATMLObject );
        }

        protected void DataToControls()
        {
            if (_connector != null)
            {
                String type = extractSexFromConnectorType( _connector.type, cmbTypeSex );
                String matingType = extractSexFromConnectorType( _connector.matingConnectorType, cmbMatingTypeSex );
                if (String.IsNullOrEmpty( matingType ))
                    matingType = type;
                connectorPinList.ConnectorPins = _connector.Pins;
                edtDescription.Value = _connector.Description;
                edtName.Value = _connector.name;
                edtVersion.Value = _connector.version;
                edtConnectorID.Value = _connector.ID;
                edtConnectorPinCount.Value = _connector.Pins == null ? "0" : "" + _connector.Pins.Count;
                cbConnectorType.SelectedIndex = cbConnectorType.FindStringExact( type );
                PromptForNewConnector( type, cbConnectorType, cbConnectorMatingType );
                cbConnectorMatingType.SelectedIndex = cbConnectorMatingType.FindStringExact( matingType );
                PromptForNewConnector( matingType, cbConnectorMatingType, cbConnectorType );
                cbConnectorMatingType.SelectedText = matingType;
                cmbConnectorLocation.SelectedItem = _connector.location;
                identificationControl.Identification = _connector.Identification;
            }
        }

        private dbConnector PromptForNewConnector( String type, ComboBox cbPrimary, ComboBox cbSecondary )
        {
            dbConnector conn = null;
            if (type != null && cbPrimary.SelectedIndex == -1)
            {
                var dao = new EquipmentDAO();
                conn = dao.getConnector( type );
                if (conn == null)
                {
                    if (DialogResult.Yes ==
                        MessageBox.Show(
                            string.Format(
                                "Connector type \"{0}\" does not exist in the Connector Database, would you like to add it?",
                                type ),
                            @"Add Connector",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question ))
                    {
                        conn = new dbConnector();
                        conn.DataState = BASEBean.eDataState.DS_ADD;
                        conn.connectorType = type;
                        conn.ID = Guid.NewGuid();
                        conn.IncludeKeyOnInsert = true;
                        conn.pinCount = string.IsNullOrWhiteSpace( edtConnectorPinCount.Text )
                                            ? 0
                                            : int.Parse( edtConnectorPinCount.Text );
                        conn.save();
                    }
                }
                if (conn != null)
                {
                    cbPrimary.SelectedIndex = cbPrimary.Items.Add( conn );
                    cbSecondary.Items.Add( conn );
                }
            }
            else
            {
                conn = cbPrimary.SelectedItem as dbConnector;
            }
            return conn;
        }

        private String extractSexFromConnectorType( String type, ComboBox sexCombo )
        {
            String newType = type;
            if (newType != null)
            {
                if (newType.Contains( "Female" ))
                    sexCombo.SelectedIndex = sexCombo.FindString( "Female" );
                else if (newType.Contains( "Male" ))
                    sexCombo.SelectedIndex = sexCombo.FindString( "Male" );
                newType = newType.Replace( "Female", "" );
                newType = newType.Replace( "Male", "" );
                newType = newType.Trim();
            }
            return newType;
        }

        protected void ControlsToData()
        {
            if (_connector != null)
            {
                String type = "";
                String matingType = "";
                if (cmbTypeSex.SelectedItem == null)
                {
                    cmbTypeSex.SelectedIndex = 0;
                    cmbMatingTypeSex.SelectedIndex = 1;
                }
                _connector.Identification = identificationControl.Identification;
                if (-1 != cbConnectorType.SelectedIndex)
                    type = cbConnectorType.SelectedItem + " " + cmbTypeSex.SelectedItem;
                else if (!string.IsNullOrWhiteSpace( cbConnectorType.Text ))
                    type = cbConnectorType.Text + " " + cmbTypeSex.SelectedItem;
                if (-1 != cbConnectorMatingType.SelectedIndex)
                    matingType = cbConnectorMatingType.SelectedItem + " " + cmbMatingTypeSex.SelectedItem;
                else if (!string.IsNullOrWhiteSpace( cbConnectorMatingType.Text ))
                    type = cbConnectorMatingType.Text + " " + cmbMatingTypeSex.SelectedItem;

                PromptForNewConnector( type, cbConnectorType, cbConnectorMatingType );
                PromptForNewConnector( matingType, cbConnectorMatingType, cbConnectorType );

                _connector.matingConnectorType = matingType;
                _connector.type = type;
                _connector.version = edtVersion.GetValue<string>();
                _connector.name = edtName.GetValue<string>();
                _connector.ID = edtConnectorID.GetValue<string>();
                _connector.location = (ConnectorLocationEnum) cmbConnectorLocation.SelectedItem;
                _connector.Description = edtDescription.GetValue<string>();
                _connector.Pins = connectorPinList.ConnectorPins;
                //TODO: Address when/if we handle extensions
                _connector.Extension = null;
            }
        }


        //---------------------------------------------------------------//
        //--- Save the connector data to the appropriate model object ---//
        //---------------------------------------------------------------//
        private void btnOK_Click( object sender, EventArgs e )
        {
            //---------------------------------------------------------------------------------------------//
            //--- When Saving - Prompt to ask the user if they would like to save the pin configuration ---//
            //---------------------------------------------------------------------------------------------//


            _connector.ID = edtConnectorID.Text;
            _connector.matingConnectorType = cbConnectorMatingType.SelectedText;
        }

        //---------------------------------------------------------------------------------------------------------//
        //--- When the connector type changes make sure to select the mating connector type, load the potential ---//
        //--- pin configurations, set the pin count, and deselect the previously selected pin configuration.    ---//
        //---------------------------------------------------------------------------------------------------------//
        private void cbConnectorType_SelectedIndexChanged( object sender, EventArgs e )
        {
            if (-1 != cbConnectorType.SelectedIndex)
            {
                cbConnectorMatingType.SelectedIndex = cbConnectorType.SelectedIndex;
                var connector = (dbConnector) cbConnectorType.SelectedItem;
                connector = DataManager.getEquipmentDAO().getConnector( connector.ID );
                //The list has a shallow Connector object - this will provide a deep representation.
                List<dbConnectorConfiguration> configs = connector.Configurations;
                cmbConnectorPinConfiguration.Items.Clear();
                foreach (dbConnectorConfiguration config in configs)
                    cmbConnectorPinConfiguration.Items.Add( config );
                edtConnectorPinCount.Text = "" + connector.pinCount;
                cmbConnectorPinConfiguration.SelectedIndex = -1;
            }
        }

        //-----------------------------------------------------------------------------------------------------------------//
        //--- When the pin configuration changes, clear the pin list and load it with associated configuration pin data ---//
        //-----------------------------------------------------------------------------------------------------------------//
        private void cmbConnectorPinConfiguration_SelectedIndexChanged( object sender, EventArgs e )
        {
            if (-1 != cmbConnectorPinConfiguration.SelectedIndex)
            {
                connectorPinList.Clear();
                var config
                    = (dbConnectorConfiguration) cmbConnectorPinConfiguration.SelectedItem;
                foreach (dbConnectorPin pin in config.Pins)
                    connectorPinList.AddPin( pin );
            }
        }

        //-----------------------------------------------------------------------------------------------------//
        //--- When the connector type sex is selected, change the mating connector type to the opposite sex ---//
        //-----------------------------------------------------------------------------------------------------//
        private void cmbTypeSex_SelectedIndexChanged( object sender, EventArgs e )
        {
            if (0 == cmbTypeSex.SelectedIndex)
                cmbMatingTypeSex.SelectedIndex = 1;
            else if (1 == cmbTypeSex.SelectedIndex)
                cmbMatingTypeSex.SelectedIndex = 0;
        }

        //-----------------------------------------------------------------------------------------------------//
        //--- When the mating connector type sex is selected, change the connector type to the opposite sex ---//
        //-----------------------------------------------------------------------------------------------------//
        private void cmbMatingTypeSex_SelectedIndexChanged( object sender, EventArgs e )
        {
            if (0 == cmbMatingTypeSex.SelectedIndex)
                cmbTypeSex.SelectedIndex = 1;
            else if (1 == cmbMatingTypeSex.SelectedIndex)
                cmbTypeSex.SelectedIndex = 0;
        }

        //---------------------------------------------------------------------//
        //--- When the pin count changes, adjust the pin list appropriately ---//
        //---------------------------------------------------------------------//
        private void edtConnectorPinCount_KeyUp( object sender, KeyEventArgs e )
        {
        }

        private void btnGeneratePins_Click( object sender, EventArgs e )
        {
            int count;
            if (int.TryParse( edtConnectorPinCount.Text, out count ))
            {
                connectorPinList.GeneratePinList( count );
                tabControl1.SelectedIndex = 2;
            }
        }

        public override bool ValidateChildren( ValidationConstraints validationConstraints )
        {
            bool isValid = base.ValidateChildren( validationConstraints );
            string save = _connector.Serialize();
            ControlsToData();
            ValidateToSchema( _connector );
            _connector = Connector.Deserialize( save );
            return isValid;
        }

        private void ConnectorForm_ValidateSchema( object sender, EventArgs e )
        {
            string save = _connector.Serialize();
            ControlsToData();
            ValidateToSchema( _connector );
            _connector = Connector.Deserialize( save );
        }

        private void btnSavePinConfiguration_Click( object sender, EventArgs e )
        {
            string text = cbConnectorType.Text;
            dbConnector connector = PromptForNewConnector( text, cbConnectorType, cbConnectorMatingType );
            if (connector != null)
            {
                List<ConnectorPin> pins = connectorPinList.ConnectorPins;
                var form = new ConnectorConfigurationForm( connector, pins );
                form.Configuration = cmbConnectorPinConfiguration.SelectedItem as dbConnectorConfiguration;
                if (DialogResult.OK == form.ShowDialog())
                {
                    dbConnectorConfiguration configuration = form.Configuration;
                    foreach (object item in cmbConnectorPinConfiguration.Items)
                    {
                        if (configuration.configName.Equals( ( (dbConnectorConfiguration) item ).configName ))
                        {
                            cmbConnectorPinConfiguration.Items.Remove( item );
                            break;
                        }
                    }
                    cmbConnectorPinConfiguration.SelectedIndex = cmbConnectorPinConfiguration.Items.Add(form.Configuration);
                }
            }
        }
    }
}