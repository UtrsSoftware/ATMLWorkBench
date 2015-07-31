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
	public partial class LuConnectorBean : BASEBean
	{
		public static readonly System.String _TABLE_NAME = "lu_connector";
		public static readonly System.String _ID = "ID";
		public static readonly System.String _CONNECTOR_TYPE = "connector_type";
		public static readonly System.String _CONNECTOR_DESCRIPTION = "connector_description";
		public static readonly System.String _PIN_COUNT = "pin_count";


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

		public System.String connectorType
		{
			get { return fieldMap[_CONNECTOR_TYPE]==System.DBNull.Value || fieldMap[_CONNECTOR_TYPE] == null ? null : fieldMap[_CONNECTOR_TYPE].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_CONNECTOR_TYPE) )
				{
					oldValue = fieldMap[_CONNECTOR_TYPE];
					fieldMap[_CONNECTOR_TYPE] = value;
				}
				else
				{
					fieldMap.Add(_CONNECTOR_TYPE, value);
					fieldTypeMap.Add(_CONNECTOR_TYPE, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_CONNECTOR_TYPE, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.String connectorDescription
		{
			get { return fieldMap[_CONNECTOR_DESCRIPTION]==System.DBNull.Value || fieldMap[_CONNECTOR_DESCRIPTION] == null ? null : fieldMap[_CONNECTOR_DESCRIPTION].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_CONNECTOR_DESCRIPTION) )
				{
					oldValue = fieldMap[_CONNECTOR_DESCRIPTION];
					fieldMap[_CONNECTOR_DESCRIPTION] = value;
				}
				else
				{
					fieldMap.Add(_CONNECTOR_DESCRIPTION, value);
					fieldTypeMap.Add(_CONNECTOR_DESCRIPTION, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_CONNECTOR_DESCRIPTION, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.Int32? pinCount
		{
			get { return fieldMap[_PIN_COUNT]==System.DBNull.Value || fieldMap[_PIN_COUNT] == null ? null : (System.Int32? )fieldMap[_PIN_COUNT];  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_PIN_COUNT) )
				{
					oldValue = fieldMap[_PIN_COUNT];
					fieldMap[_PIN_COUNT] = value;
				}
				else
				{
					fieldMap.Add(_PIN_COUNT, value);
					fieldTypeMap.Add(_PIN_COUNT, OleDbType.Integer );
				}
				EventArgs arg = new DataChangedEventArgs(_PIN_COUNT, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public LuConnectorBean( ):base( _TABLE_NAME )
		{
			if( fieldMap.ContainsKey(_ID) )
				fieldMap[_ID] = null;
			else
				fieldMap.Add(_ID, null );
			if( fieldMap.ContainsKey(_CONNECTOR_TYPE) )
				fieldMap[_CONNECTOR_TYPE] = null;
			else
				fieldMap.Add(_CONNECTOR_TYPE, null );
			if( fieldMap.ContainsKey(_CONNECTOR_DESCRIPTION) )
				fieldMap[_CONNECTOR_DESCRIPTION] = null;
			else
				fieldMap.Add(_CONNECTOR_DESCRIPTION, null );
			if( fieldMap.ContainsKey(_PIN_COUNT) )
				fieldMap[_PIN_COUNT] = null;
			else
				fieldMap.Add(_PIN_COUNT, null );
			initialize();
		}

		public LuConnectorBean( OleDbDataReader reader ):base( _TABLE_NAME )
		{
			if( fieldMap.ContainsKey(_ID) )
				fieldMap[_ID] = reader[_ID];
			else
				fieldMap.Add(_ID, reader[_ID]);
			if( fieldMap.ContainsKey(_CONNECTOR_TYPE) )
				fieldMap[_CONNECTOR_TYPE] = reader[_CONNECTOR_TYPE];
			else
				fieldMap.Add(_CONNECTOR_TYPE, reader[_CONNECTOR_TYPE]);
			if( fieldMap.ContainsKey(_CONNECTOR_DESCRIPTION) )
				fieldMap[_CONNECTOR_DESCRIPTION] = reader[_CONNECTOR_DESCRIPTION];
			else
				fieldMap.Add(_CONNECTOR_DESCRIPTION, reader[_CONNECTOR_DESCRIPTION]);
			if( fieldMap.ContainsKey(_PIN_COUNT) )
				fieldMap[_PIN_COUNT] = reader[_PIN_COUNT];
			else
				fieldMap.Add(_PIN_COUNT, reader[_PIN_COUNT]);
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
			if( fieldMap.ContainsKey(_CONNECTOR_TYPE) )
				fieldMap[_CONNECTOR_TYPE] = reader[_CONNECTOR_TYPE];
			else
				fieldMap.Add(_CONNECTOR_TYPE, reader[_CONNECTOR_TYPE]);
			if( originalFieldMap.ContainsKey(_CONNECTOR_TYPE) )
				originalFieldMap[_CONNECTOR_TYPE] = reader[_CONNECTOR_TYPE];
			else
				originalFieldMap.Add(_CONNECTOR_TYPE, reader[_CONNECTOR_TYPE]);
			if( fieldMap.ContainsKey(_CONNECTOR_DESCRIPTION) )
				fieldMap[_CONNECTOR_DESCRIPTION] = reader[_CONNECTOR_DESCRIPTION];
			else
				fieldMap.Add(_CONNECTOR_DESCRIPTION, reader[_CONNECTOR_DESCRIPTION]);
			if( originalFieldMap.ContainsKey(_CONNECTOR_DESCRIPTION) )
				originalFieldMap[_CONNECTOR_DESCRIPTION] = reader[_CONNECTOR_DESCRIPTION];
			else
				originalFieldMap.Add(_CONNECTOR_DESCRIPTION, reader[_CONNECTOR_DESCRIPTION]);
			if( fieldMap.ContainsKey(_PIN_COUNT) )
				fieldMap[_PIN_COUNT] = reader[_PIN_COUNT];
			else
				fieldMap.Add(_PIN_COUNT, reader[_PIN_COUNT]);
			if( originalFieldMap.ContainsKey(_PIN_COUNT) )
				originalFieldMap[_PIN_COUNT] = reader[_PIN_COUNT];
			else
				originalFieldMap.Add(_PIN_COUNT, reader[_PIN_COUNT]);
		}

		public override void writeStartXML(UTRSXmlWriter xml)
		{
			xml.WriteStartElement(_TABLE_NAME.ToLower());
		}

		public override void writeXML(UTRSXmlWriter xml)
		{
			xml.WriteElementSafeString(_ID.ToLower(), ID);
			xml.WriteElementSafeString(_CONNECTOR_TYPE.ToLower(), connectorType);
			xml.WriteElementSafeString(_CONNECTOR_DESCRIPTION.ToLower(), connectorDescription);
			xml.WriteElementSafeString(_PIN_COUNT.ToLower(), pinCount);
		}

		public override void writeEndXML(UTRSXmlWriter xml)
		{
			xml.WriteEndElement();
		}

	}
}
