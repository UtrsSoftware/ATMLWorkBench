/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Collections.Generic;
using System.Data.OleDb;
using ATMLDataAccessLibrary.db.beans;
using ATMLDataAccessLibrary.model;

namespace ATMLDataAccessLibrary.db.daos
{
    public class EquipmentDAO : DAO
    {
        public dbConnector getConnector( Guid? connectorId )
        {
            var parameters = new OleDbParameter[] {new OleDbParameter( dbConnector._ID, connectorId )};
            var connector =
                CreateBean<dbConnector>(
                    BuildSqlSelect( dbConnector._TABLE_NAME, new String[] {"*"}, new String[] {dbConnector._ID} ),
                    parameters );
            connector.Configurations = getConnectorConfigurations( connector.ID );
            return connector;
        }

        public dbConnector getConnector( string connectorType )
        {
            var parameters = new OleDbParameter[] {new OleDbParameter( dbConnector._ID, connectorType )};
            var connector =
                CreateBean<dbConnector>(
                    BuildSqlSelect( dbConnector._TABLE_NAME, new String[] {"*"},
                                    new String[] {dbConnector._CONNECTOR_TYPE} ), parameters );
            if( connector != null )
                connector.Configurations = getConnectorConfigurations( connector.ID );
            return connector;
        }

        public List<dbConnector> getConnectors()
        {
            var parameters = new OleDbParameter[] {};
            return
                CreateList<dbConnector>(
                    BuildSqlSelect( dbConnector._TABLE_NAME, new String[] {"*"}, new String[] {} ), parameters );
        }

        public List<dbConnectorConfiguration> getConnectorConfigurations( Guid? id )
        {
            var parameters = new OleDbParameter[] {new OleDbParameter( dbConnectorConfiguration._CONNECTOR_ID, id )};
            List<dbConnectorConfiguration> list =
                CreateList<dbConnectorConfiguration>(
                    BuildSqlSelect( dbConnectorConfiguration._TABLE_NAME, new String[] {"*"},
                                    new String[] {dbConnectorConfiguration._CONNECTOR_ID} ), parameters );
            foreach (dbConnectorConfiguration config in list)
                config.Pins = getConnectorPins( config.ID );
            return list;
        }

        public dbConnectorConfiguration getConnectorConfiguration( Guid? id, string configName )
        {
            var parameters = new OleDbParameter[]
                             {
                                 new OleDbParameter( dbConnectorConfiguration._CONNECTOR_ID, id ),
                                 new OleDbParameter( dbConnectorConfiguration._CONFIG_NAME, configName )
                             };
            var bean =
                CreateBean<dbConnectorConfiguration>(
                    BuildSqlSelect( dbConnectorConfiguration._TABLE_NAME, new String[] {"*"},
                                    new String[]
                                    {dbConnectorConfiguration._CONNECTOR_ID, dbConnectorConfiguration._CONFIG_NAME} ),
                    parameters );
            return bean;
        }


        public List<dbConnectorPin> getConnectorPins( Guid? id )
        {
            String sql = BuildSqlSelect( dbConnectorPin._TABLE_NAME, new String[] {"*"},
                                         new String[] {dbConnectorPin._CONFIG_ID} );
            var parameters = new OleDbParameter[] {new OleDbParameter( dbConnectorPin._CONFIG_ID, id )};
            sql += " ORDER BY " + dbConnectorPin._PIN_IDX;
            return CreateList<dbConnectorPin>( sql, parameters );
        }

        public object deleteConnectorPins(Guid? id)
        {
            String sql = BuildDeleteSqlStatement(dbConnectorPin._TABLE_NAME, new List<string> { dbConnectorPin._CONFIG_ID });
            var parameters = new OleDbParameter[] { new OleDbParameter(dbConnectorPin._CONFIG_ID, id) };
            return ExecuteSqlCommand( sql, parameters);
        }

        public int ClearEquipmentCapabilities( Guid? atmlObjectId )
        {
            int count = 0;
            String sql = string.Format( "DELETE * FROM {0} WHERE {1} = ?",
                                        InstrumentCapabilitiesBean._TABLE_NAME,
                                        InstrumentCapabilitiesBean._INSTRUMENT_UUID
                );
            OleDbParameter[] dbParams =
            {
                CreateParameter( InstrumentCapabilitiesBean._INSTRUMENT_UUID,
                                 atmlObjectId.ToString() )
            };
            ExecuteSqlCommand( sql, dbParams, out count );
            return count;
        }


        public InstrumentCapabilitiesBean GetSignalCapabilityAttribute( Guid? atmlObjectId,
                                                                        String capabilityName,
                                                                        String signalName,
                                                                        String attributeName )
        {
            InstrumentCapabilitiesBean attribute = null;
            String sql = string.Format( "SELECT * FROM {0} WHERE {1} = ? AND {2} = ? AND {3} = ?  AND {4} = ?",
                                        //TODO: Change to use new fields
                                        InstrumentCapabilitiesBean._TABLE_NAME,
                                        InstrumentCapabilitiesBean._INSTRUMENT_UUID,
                                        InstrumentCapabilitiesBean._CAPABILITY_NAME,
                                        InstrumentCapabilitiesBean._SIGNAL_NAME,
                                        InstrumentCapabilitiesBean._ATTRIBUTE );
            OleDbParameter[] dbParams =
            {
                CreateParameter( InstrumentCapabilitiesBean._INSTRUMENT_UUID, atmlObjectId.ToString() ),
                CreateParameter( InstrumentCapabilitiesBean._CAPABILITY_NAME, capabilityName ),
                CreateParameter( InstrumentCapabilitiesBean._SIGNAL_NAME, signalName ),
                CreateParameter( InstrumentCapabilitiesBean._ATTRIBUTE, attributeName )
            };
            attribute = CreateBean<InstrumentCapabilitiesBean>( sql, dbParams );
            return attribute;
        }
    }
}