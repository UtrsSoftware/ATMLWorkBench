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
	public partial class SignalAttributeBean : BASEBean
	{
		public static readonly System.String _TABLE_NAME = "signal_attribute";
		public static readonly System.String _ID = "ID";
		public static readonly System.String _NAME = "name";
		public static readonly System.String _DESCRIPTION = "description";


		public System.Int32? ID
		{
			get { return fieldMap[_ID]==System.DBNull.Value || fieldMap[_ID] == null ? null : (System.Int32? )fieldMap[_ID];  }
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
					fieldTypeMap.Add(_ID, OleDbType.Integer );
				}
				EventArgs arg = new DataChangedEventArgs(_ID, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.String name
		{
			get { return fieldMap[_NAME]==System.DBNull.Value || fieldMap[_NAME] == null ? null : fieldMap[_NAME].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_NAME) )
				{
					oldValue = fieldMap[_NAME];
					fieldMap[_NAME] = value;
				}
				else
				{
					fieldMap.Add(_NAME, value);
					fieldTypeMap.Add(_NAME, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_NAME, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.String description
		{
			get { return fieldMap[_DESCRIPTION]==System.DBNull.Value || fieldMap[_DESCRIPTION] == null ? null : fieldMap[_DESCRIPTION].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_DESCRIPTION) )
				{
					oldValue = fieldMap[_DESCRIPTION];
					fieldMap[_DESCRIPTION] = value;
				}
				else
				{
					fieldMap.Add(_DESCRIPTION, value);
					fieldTypeMap.Add(_DESCRIPTION, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_DESCRIPTION, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public SignalAttributeBean( ):base( _TABLE_NAME )
		{
			if( fieldMap.ContainsKey(_ID) )
				fieldMap[_ID] = null;
			else
				fieldMap.Add(_ID, null );
			if( fieldMap.ContainsKey(_NAME) )
				fieldMap[_NAME] = null;
			else
				fieldMap.Add(_NAME, null );
			if( fieldMap.ContainsKey(_DESCRIPTION) )
				fieldMap[_DESCRIPTION] = null;
			else
				fieldMap.Add(_DESCRIPTION, null );
			initialize();
		}

		public SignalAttributeBean( OleDbDataReader reader ):base( _TABLE_NAME )
		{
			if( fieldMap.ContainsKey(_ID) )
				fieldMap[_ID] = reader[_ID];
			else
				fieldMap.Add(_ID, reader[_ID]);
			if( fieldMap.ContainsKey(_NAME) )
				fieldMap[_NAME] = reader[_NAME];
			else
				fieldMap.Add(_NAME, reader[_NAME]);
			if( fieldMap.ContainsKey(_DESCRIPTION) )
				fieldMap[_DESCRIPTION] = reader[_DESCRIPTION];
			else
				fieldMap.Add(_DESCRIPTION, reader[_DESCRIPTION]);
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
			if( fieldMap.ContainsKey(_NAME) )
				fieldMap[_NAME] = reader[_NAME];
			else
				fieldMap.Add(_NAME, reader[_NAME]);
			if( originalFieldMap.ContainsKey(_NAME) )
				originalFieldMap[_NAME] = reader[_NAME];
			else
				originalFieldMap.Add(_NAME, reader[_NAME]);
			if( fieldMap.ContainsKey(_DESCRIPTION) )
				fieldMap[_DESCRIPTION] = reader[_DESCRIPTION];
			else
				fieldMap.Add(_DESCRIPTION, reader[_DESCRIPTION]);
			if( originalFieldMap.ContainsKey(_DESCRIPTION) )
				originalFieldMap[_DESCRIPTION] = reader[_DESCRIPTION];
			else
				originalFieldMap.Add(_DESCRIPTION, reader[_DESCRIPTION]);
		}

		public override void writeStartXML(UTRSXmlWriter xml)
		{
			xml.WriteStartElement(_TABLE_NAME.ToLower());
		}

		public override void writeXML(UTRSXmlWriter xml)
		{
			xml.WriteElementSafeString(_ID.ToLower(), ID);
			xml.WriteElementSafeString(_NAME.ToLower(), name);
			xml.WriteElementSafeString(_DESCRIPTION.ToLower(), description);
		}

		public override void writeEndXML(UTRSXmlWriter xml)
		{
			xml.WriteEndElement();
		}

	}
}
