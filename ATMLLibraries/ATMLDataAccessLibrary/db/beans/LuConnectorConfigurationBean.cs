/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Collections.Generic;
using ATMLUtilitiesLibrary;

using ATMLDataAccessLibrary.db.beans;

namespace ATMLDataAccessLibrary.db.beans
{
	public partial class LuConnectorConfigurationBean : BASEBean
	{
		public static readonly System.String _TABLE_NAME = "lu_connector_configuration";
		public static readonly System.String _ID = "ID";
		public static readonly System.String _CONNECTOR_ID = "connector_id";
		public static readonly System.String _CONFIG_NAME = "config_name";


		public System.Guid? ID
		{
			get { return fieldMap[_ID]==System.DBNull.Value || fieldMap[_ID] == null ? null : (System.Guid? )fieldMap[_ID];  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_ID) )
				{
					oldValue = fieldMap[_ID];
					fieldMap[_ID] = value;
				}
				else
				{
					fieldMap.Add(_ID, value);
					fieldTypeMap.Add(_ID, OleDbType.Guid );
				}
				EventArgs arg = new DataChangedEventArgs(_ID, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.Guid? connectorId
		{
			get { return fieldMap[_CONNECTOR_ID]==System.DBNull.Value || fieldMap[_CONNECTOR_ID] == null ? null : (System.Guid? )fieldMap[_CONNECTOR_ID];  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_CONNECTOR_ID) )
				{
					oldValue = fieldMap[_CONNECTOR_ID];
					fieldMap[_CONNECTOR_ID] = value;
				}
				else
				{
					fieldMap.Add(_CONNECTOR_ID, value);
					fieldTypeMap.Add(_CONNECTOR_ID, OleDbType.Guid );
				}
				EventArgs arg = new DataChangedEventArgs(_CONNECTOR_ID, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.String configName
		{
			get { return fieldMap[_CONFIG_NAME]==System.DBNull.Value || fieldMap[_CONFIG_NAME] == null ? null : fieldMap[_CONFIG_NAME].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_CONFIG_NAME) )
				{
					oldValue = fieldMap[_CONFIG_NAME];
					fieldMap[_CONFIG_NAME] = value;
				}
				else
				{
					fieldMap.Add(_CONFIG_NAME, value);
					fieldTypeMap.Add(_CONFIG_NAME, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_CONFIG_NAME, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public LuConnectorConfigurationBean( ):base( _TABLE_NAME )
		{
			if( fieldMap.ContainsKey(_ID) )
				fieldMap[_ID] = null;
			else
				fieldMap.Add(_ID, null );
			if( fieldMap.ContainsKey(_CONNECTOR_ID) )
				fieldMap[_CONNECTOR_ID] = null;
			else
				fieldMap.Add(_CONNECTOR_ID, null );
			if( fieldMap.ContainsKey(_CONFIG_NAME) )
				fieldMap[_CONFIG_NAME] = null;
			else
				fieldMap.Add(_CONFIG_NAME, null );
			initialize();
		}

		public LuConnectorConfigurationBean( OleDbDataReader reader ):base( _TABLE_NAME )
		{
			if( fieldMap.ContainsKey(_ID) )
				fieldMap[_ID] = reader[_ID];
			else
				fieldMap.Add(_ID, reader[_ID]);
			if( fieldMap.ContainsKey(_CONNECTOR_ID) )
				fieldMap[_CONNECTOR_ID] = reader[_CONNECTOR_ID];
			else
				fieldMap.Add(_CONNECTOR_ID, reader[_CONNECTOR_ID]);
			if( fieldMap.ContainsKey(_CONFIG_NAME) )
				fieldMap[_CONFIG_NAME] = reader[_CONFIG_NAME];
			else
				fieldMap.Add(_CONFIG_NAME, reader[_CONFIG_NAME]);
			initialize();
		}

		private void initialize( )
		{
			keys.Add( "ID" );
		}

		public override void load(  OleDbDataReader reader )
		{
			base.resetDirtyState();
			if( fieldMap.ContainsKey(_ID) )
				fieldMap[_ID] = reader[_ID];
			else
				fieldMap.Add(_ID, reader[_ID]);
			if( originalFieldMap.ContainsKey(_ID) )
				originalFieldMap[_ID] = reader[_ID];
			else
				originalFieldMap.Add(_ID, reader[_ID]);
			if( fieldMap.ContainsKey(_CONNECTOR_ID) )
				fieldMap[_CONNECTOR_ID] = reader[_CONNECTOR_ID];
			else
				fieldMap.Add(_CONNECTOR_ID, reader[_CONNECTOR_ID]);
			if( originalFieldMap.ContainsKey(_CONNECTOR_ID) )
				originalFieldMap[_CONNECTOR_ID] = reader[_CONNECTOR_ID];
			else
				originalFieldMap.Add(_CONNECTOR_ID, reader[_CONNECTOR_ID]);
			if( fieldMap.ContainsKey(_CONFIG_NAME) )
				fieldMap[_CONFIG_NAME] = reader[_CONFIG_NAME];
			else
				fieldMap.Add(_CONFIG_NAME, reader[_CONFIG_NAME]);
			if( originalFieldMap.ContainsKey(_CONFIG_NAME) )
				originalFieldMap[_CONFIG_NAME] = reader[_CONFIG_NAME];
			else
				originalFieldMap.Add(_CONFIG_NAME, reader[_CONFIG_NAME]);
		}

		public override void writeStartXML(UTRSXmlWriter xml)
		{
			xml.WriteStartElement(_TABLE_NAME.ToLower());
		}

		public override void writeXML(UTRSXmlWriter xml)
		{
			xml.WriteElementSafeString(_ID.ToLower(), ID);
			xml.WriteElementSafeString(_CONNECTOR_ID.ToLower(), connectorId);
			xml.WriteElementSafeString(_CONFIG_NAME.ToLower(), configName);
		}

		public override void writeEndXML(UTRSXmlWriter xml)
		{
			xml.WriteEndElement();
		}

	}
}
