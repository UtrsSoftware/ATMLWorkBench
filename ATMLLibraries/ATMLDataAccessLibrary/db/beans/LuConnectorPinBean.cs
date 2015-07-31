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
	public partial class LuConnectorPinBean : BASEBean
	{
		public static readonly System.String _TABLE_NAME = "lu_connector_pin";
		public static readonly System.String _CONFIG_ID = "config_id";
		public static readonly System.String _PIN_IDX = "pin_idx";
		public static readonly System.String _PIN_NAME = "pin_name";
		public static readonly System.String _PIN_DIRECTION = "pin_direction";
		public static readonly System.String _PIN_DESCRIPTION = "pin_description";


		public System.Guid? configId
		{
			get { return fieldMap[_CONFIG_ID]==System.DBNull.Value || fieldMap[_CONFIG_ID] == null ? null : (System.Guid? )fieldMap[_CONFIG_ID];  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_CONFIG_ID) )
				{
					oldValue = fieldMap[_CONFIG_ID];
					fieldMap[_CONFIG_ID] = value;
				}
				else
				{
					fieldMap.Add(_CONFIG_ID, value);
					fieldTypeMap.Add(_CONFIG_ID, OleDbType.Guid );
				}
				EventArgs arg = new DataChangedEventArgs(_CONFIG_ID, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.Int32? pinIdx
		{
			get { return fieldMap[_PIN_IDX]==System.DBNull.Value || fieldMap[_PIN_IDX] == null ? null : (System.Int32? )fieldMap[_PIN_IDX];  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_PIN_IDX) )
				{
					oldValue = fieldMap[_PIN_IDX];
					fieldMap[_PIN_IDX] = value;
				}
				else
				{
					fieldMap.Add(_PIN_IDX, value);
					fieldTypeMap.Add(_PIN_IDX, OleDbType.Integer );
				}
				EventArgs arg = new DataChangedEventArgs(_PIN_IDX, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.String pinName
		{
			get { return fieldMap[_PIN_NAME]==System.DBNull.Value || fieldMap[_PIN_NAME] == null ? null : fieldMap[_PIN_NAME].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_PIN_NAME) )
				{
					oldValue = fieldMap[_PIN_NAME];
					fieldMap[_PIN_NAME] = value;
				}
				else
				{
					fieldMap.Add(_PIN_NAME, value);
					fieldTypeMap.Add(_PIN_NAME, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_PIN_NAME, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.String pinDirection
		{
			get { return fieldMap[_PIN_DIRECTION]==System.DBNull.Value || fieldMap[_PIN_DIRECTION] == null ? null : fieldMap[_PIN_DIRECTION].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_PIN_DIRECTION) )
				{
					oldValue = fieldMap[_PIN_DIRECTION];
					fieldMap[_PIN_DIRECTION] = value;
				}
				else
				{
					fieldMap.Add(_PIN_DIRECTION, value);
					fieldTypeMap.Add(_PIN_DIRECTION, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_PIN_DIRECTION, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.String pinDescription
		{
			get { return fieldMap[_PIN_DESCRIPTION]==System.DBNull.Value || fieldMap[_PIN_DESCRIPTION] == null ? null : fieldMap[_PIN_DESCRIPTION].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_PIN_DESCRIPTION) )
				{
					oldValue = fieldMap[_PIN_DESCRIPTION];
					fieldMap[_PIN_DESCRIPTION] = value;
				}
				else
				{
					fieldMap.Add(_PIN_DESCRIPTION, value);
					fieldTypeMap.Add(_PIN_DESCRIPTION, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_PIN_DESCRIPTION, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public LuConnectorPinBean( ):base( _TABLE_NAME )
		{
			if( fieldMap.ContainsKey(_CONFIG_ID) )
				fieldMap[_CONFIG_ID] = null;
			else
				fieldMap.Add(_CONFIG_ID, null );
			if( fieldMap.ContainsKey(_PIN_IDX) )
				fieldMap[_PIN_IDX] = null;
			else
				fieldMap.Add(_PIN_IDX, null );
			if( fieldMap.ContainsKey(_PIN_NAME) )
				fieldMap[_PIN_NAME] = null;
			else
				fieldMap.Add(_PIN_NAME, null );
			if( fieldMap.ContainsKey(_PIN_DIRECTION) )
				fieldMap[_PIN_DIRECTION] = null;
			else
				fieldMap.Add(_PIN_DIRECTION, null );
			if( fieldMap.ContainsKey(_PIN_DESCRIPTION) )
				fieldMap[_PIN_DESCRIPTION] = null;
			else
				fieldMap.Add(_PIN_DESCRIPTION, null );
			initialize();
		}

		public LuConnectorPinBean( OleDbDataReader reader ):base( _TABLE_NAME )
		{
			if( fieldMap.ContainsKey(_CONFIG_ID) )
				fieldMap[_CONFIG_ID] = reader[_CONFIG_ID];
			else
				fieldMap.Add(_CONFIG_ID, reader[_CONFIG_ID]);
			if( fieldMap.ContainsKey(_PIN_IDX) )
				fieldMap[_PIN_IDX] = reader[_PIN_IDX];
			else
				fieldMap.Add(_PIN_IDX, reader[_PIN_IDX]);
			if( fieldMap.ContainsKey(_PIN_NAME) )
				fieldMap[_PIN_NAME] = reader[_PIN_NAME];
			else
				fieldMap.Add(_PIN_NAME, reader[_PIN_NAME]);
			if( fieldMap.ContainsKey(_PIN_DIRECTION) )
				fieldMap[_PIN_DIRECTION] = reader[_PIN_DIRECTION];
			else
				fieldMap.Add(_PIN_DIRECTION, reader[_PIN_DIRECTION]);
			if( fieldMap.ContainsKey(_PIN_DESCRIPTION) )
				fieldMap[_PIN_DESCRIPTION] = reader[_PIN_DESCRIPTION];
			else
				fieldMap.Add(_PIN_DESCRIPTION, reader[_PIN_DESCRIPTION]);
			initialize();
		}

		private void initialize( )
		{
			keys.Add( "pin_idx" );
			keys.Add( "config_id" );
		}

		public override void load(  OleDbDataReader reader )
		{
			base.resetDirtyState();
			if( fieldMap.ContainsKey(_CONFIG_ID) )
				fieldMap[_CONFIG_ID] = reader[_CONFIG_ID];
			else
				fieldMap.Add(_CONFIG_ID, reader[_CONFIG_ID]);
			if( originalFieldMap.ContainsKey(_CONFIG_ID) )
				originalFieldMap[_CONFIG_ID] = reader[_CONFIG_ID];
			else
				originalFieldMap.Add(_CONFIG_ID, reader[_CONFIG_ID]);
			if( fieldMap.ContainsKey(_PIN_IDX) )
				fieldMap[_PIN_IDX] = reader[_PIN_IDX];
			else
				fieldMap.Add(_PIN_IDX, reader[_PIN_IDX]);
			if( originalFieldMap.ContainsKey(_PIN_IDX) )
				originalFieldMap[_PIN_IDX] = reader[_PIN_IDX];
			else
				originalFieldMap.Add(_PIN_IDX, reader[_PIN_IDX]);
			if( fieldMap.ContainsKey(_PIN_NAME) )
				fieldMap[_PIN_NAME] = reader[_PIN_NAME];
			else
				fieldMap.Add(_PIN_NAME, reader[_PIN_NAME]);
			if( originalFieldMap.ContainsKey(_PIN_NAME) )
				originalFieldMap[_PIN_NAME] = reader[_PIN_NAME];
			else
				originalFieldMap.Add(_PIN_NAME, reader[_PIN_NAME]);
			if( fieldMap.ContainsKey(_PIN_DIRECTION) )
				fieldMap[_PIN_DIRECTION] = reader[_PIN_DIRECTION];
			else
				fieldMap.Add(_PIN_DIRECTION, reader[_PIN_DIRECTION]);
			if( originalFieldMap.ContainsKey(_PIN_DIRECTION) )
				originalFieldMap[_PIN_DIRECTION] = reader[_PIN_DIRECTION];
			else
				originalFieldMap.Add(_PIN_DIRECTION, reader[_PIN_DIRECTION]);
			if( fieldMap.ContainsKey(_PIN_DESCRIPTION) )
				fieldMap[_PIN_DESCRIPTION] = reader[_PIN_DESCRIPTION];
			else
				fieldMap.Add(_PIN_DESCRIPTION, reader[_PIN_DESCRIPTION]);
			if( originalFieldMap.ContainsKey(_PIN_DESCRIPTION) )
				originalFieldMap[_PIN_DESCRIPTION] = reader[_PIN_DESCRIPTION];
			else
				originalFieldMap.Add(_PIN_DESCRIPTION, reader[_PIN_DESCRIPTION]);
		}

		public override void writeStartXML(UTRSXmlWriter xml)
		{
			xml.WriteStartElement(_TABLE_NAME.ToLower());
		}

		public override void writeXML(UTRSXmlWriter xml)
		{
			xml.WriteElementSafeString(_CONFIG_ID.ToLower(), configId);
			xml.WriteElementSafeString(_PIN_IDX.ToLower(), pinIdx);
			xml.WriteElementSafeString(_PIN_NAME.ToLower(), pinName);
			xml.WriteElementSafeString(_PIN_DIRECTION.ToLower(), pinDirection);
			xml.WriteElementSafeString(_PIN_DESCRIPTION.ToLower(), pinDescription);
		}

		public override void writeEndXML(UTRSXmlWriter xml)
		{
			xml.WriteEndElement();
		}

	}
}
