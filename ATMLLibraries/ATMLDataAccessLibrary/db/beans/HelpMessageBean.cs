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
	public partial class HelpMessageBean : BASEBean
	{
		public static readonly System.String _TABLE_NAME = "help_message";
		public static readonly System.String _MESSAGE_KEY = "message_key";
		public static readonly System.String _MESSAGE = "message";


		public System.String messageKey
		{
			get { return fieldMap[_MESSAGE_KEY]==System.DBNull.Value || fieldMap[_MESSAGE_KEY] == null ? null : fieldMap[_MESSAGE_KEY].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_MESSAGE_KEY) )
				{
					oldValue = fieldMap[_MESSAGE_KEY];
					fieldMap[_MESSAGE_KEY] = value;
				}
				else
				{
					fieldMap.Add(_MESSAGE_KEY, value);
					fieldTypeMap.Add(_MESSAGE_KEY, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_MESSAGE_KEY, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.String message
		{
			get { return fieldMap[_MESSAGE]==System.DBNull.Value || fieldMap[_MESSAGE] == null ? null : fieldMap[_MESSAGE].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_MESSAGE) )
				{
					oldValue = fieldMap[_MESSAGE];
					fieldMap[_MESSAGE] = value;
				}
				else
				{
					fieldMap.Add(_MESSAGE, value);
					fieldTypeMap.Add(_MESSAGE, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_MESSAGE, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public HelpMessageBean( ):base( _TABLE_NAME )
		{
			if( fieldMap.ContainsKey(_MESSAGE_KEY) )
				fieldMap[_MESSAGE_KEY] = null;
			else
				fieldMap.Add(_MESSAGE_KEY, null );
			if( fieldMap.ContainsKey(_MESSAGE) )
				fieldMap[_MESSAGE] = null;
			else
				fieldMap.Add(_MESSAGE, null );
			initialize();
		}

		public HelpMessageBean( OleDbDataReader reader ):base( _TABLE_NAME )
		{
			if( fieldMap.ContainsKey(_MESSAGE_KEY) )
				fieldMap[_MESSAGE_KEY] = reader[_MESSAGE_KEY];
			else
				fieldMap.Add(_MESSAGE_KEY, reader[_MESSAGE_KEY]);
			if( fieldMap.ContainsKey(_MESSAGE) )
				fieldMap[_MESSAGE] = reader[_MESSAGE];
			else
				fieldMap.Add(_MESSAGE, reader[_MESSAGE]);
			initialize();
		}

		private void initialize( )
		{
			keys.Add( "message_key" );
		}

		public override void load(  OleDbDataReader reader )
		{
			base.resetDirtyState();
			if( fieldMap.ContainsKey(_MESSAGE_KEY) )
				fieldMap[_MESSAGE_KEY] = reader[_MESSAGE_KEY];
			else
				fieldMap.Add(_MESSAGE_KEY, reader[_MESSAGE_KEY]);
			if( originalFieldMap.ContainsKey(_MESSAGE_KEY) )
				originalFieldMap[_MESSAGE_KEY] = reader[_MESSAGE_KEY];
			else
				originalFieldMap.Add(_MESSAGE_KEY, reader[_MESSAGE_KEY]);
			if( fieldMap.ContainsKey(_MESSAGE) )
				fieldMap[_MESSAGE] = reader[_MESSAGE];
			else
				fieldMap.Add(_MESSAGE, reader[_MESSAGE]);
			if( originalFieldMap.ContainsKey(_MESSAGE) )
				originalFieldMap[_MESSAGE] = reader[_MESSAGE];
			else
				originalFieldMap.Add(_MESSAGE, reader[_MESSAGE]);
		}

		public override void writeStartXML(UTRSXmlWriter xml)
		{
			xml.WriteStartElement(_TABLE_NAME.ToLower());
		}

		public override void writeXML(UTRSXmlWriter xml)
		{
			xml.WriteElementSafeString(_MESSAGE_KEY.ToLower(), messageKey);
			xml.WriteElementSafeString(_MESSAGE.ToLower(), message);
		}

		public override void writeEndXML(UTRSXmlWriter xml)
		{
			xml.WriteEndElement();
		}

	}
}
