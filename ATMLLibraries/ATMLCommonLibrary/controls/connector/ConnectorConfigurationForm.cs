using System;
using System.Collections.Generic;
using ATMLCommonLibrary.forms;
using ATMLDataAccessLibrary.db.beans;
using ATMLDataAccessLibrary.db.daos;
using ATMLDataAccessLibrary.model;
using ATMLManagerLibrary.managers;
using ATMLModelLibrary.model.common;

namespace ATMLCommonLibrary.controls.connector
{
    public partial class ConnectorConfigurationForm : ATMLForm
    {
        private dbConnector _connector;
        private List<ConnectorPin> _pins;
        private dbConnectorConfiguration _configuration;

        public ConnectorConfigurationForm( dbConnector connector, List<ConnectorPin> pins )
        {
            InitializeComponent();
            _connector = connector;
            _pins = pins;
            Load += ConnectorConfigurationForm_Load;
            Saved += ConnectorConfigurationForm_Saved;
        }

        public dbConnectorConfiguration Configuration
        {
            get { return _configuration; }
            set { _configuration = value;
            if (_configuration != null )
                edtConfigurationName.Text = _configuration.configName;
            }
        }

        private void ConnectorConfigurationForm_Saved( object sender, EventArgs e )
        {
            bool added = false;
            Guid? uuid = _connector.ID;
            EquipmentDAO dao = new EquipmentDAO();
            _configuration = dao.getConnectorConfiguration(uuid, edtConfigurationName.Text);
            if (_configuration == null)
            {
                _configuration = new dbConnectorConfiguration();
                _configuration.ID = Guid.NewGuid();
                _configuration.connectorId = uuid;
                _configuration.configName = edtConfigurationName.Text;
                _configuration.DataState = BASEBean.eDataState.DS_ADD;
                _configuration.IncludeKeyOnInsert = true;
                added = true;
            }
            Configuration.Pins.Clear();
            int i = 1;
            if (_pins != null)
            {
                foreach (ConnectorPin connectorPin in _pins)
                {
                    dbConnectorPin pin = new dbConnectorPin();
                    pin.configId = _configuration.ID;
                    pin.pinIdx = i++;
                    pin.pinName = connectorPin.name;
                    if (connectorPin.Definition != null)
                        pin.pinDescription = connectorPin.Definition.Description;
                    Configuration.Pins.Add(pin);
                }
            }
            Configuration.save();
            LogManager.Info( "Connector Pin Configuration \"{0}\" has been {1}", _configuration.configName, added ? "Added" : "Saved" );
        }

        private void ConnectorConfigurationForm_Load( object sender, EventArgs e )
        {
        }
    }
}