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
	public partial class TestSignalSignalBean : BASEBean
	{
		public static readonly System.String _TABLE_NAME = "test_signal_signal";
		public static readonly System.String _ID = "id";
		public static readonly System.String _LIBRARY_UUID = "library_uuid";
		public static readonly System.String _SIGNAL_UUID = "signal_uuid";


		public System.Guid? id
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

		public System.String libraryUuid
		{
			get { return fieldMap[_LIBRARY_UUID]==System.DBNull.Value || fieldMap[_LIBRARY_UUID] == null ? null : fieldMap[_LIBRARY_UUID].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_LIBRARY_UUID) )
				{
					oldValue = fieldMap[_LIBRARY_UUID];
					fieldMap[_LIBRARY_UUID] = value;
				}
				else
				{
					fieldMap.Add(_LIBRARY_UUID, value);
					fieldTypeMap.Add(_LIBRARY_UUID, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_LIBRARY_UUID, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.String signalUuid
		{
			get { return fieldMap[_SIGNAL_UUID]==System.DBNull.Value || fieldMap[_SIGNAL_UUID] == null ? null : fieldMap[_SIGNAL_UUID].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_SIGNAL_UUID) )
				{
					oldValue = fieldMap[_SIGNAL_UUID];
					fieldMap[_SIGNAL_UUID] = value;
				}
				else
				{
					fieldMap.Add(_SIGNAL_UUID, value);
					fieldTypeMap.Add(_SIGNAL_UUID, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_SIGNAL_UUID, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public TestSignalSignalBean( ):base( _TABLE_NAME )
		{
			if( fieldMap.ContainsKey(_ID) )
				fieldMap[_ID] = null;
			else
				fieldMap.Add(_ID, null );
			if( fieldMap.ContainsKey(_LIBRARY_UUID) )
				fieldMap[_LIBRARY_UUID] = null;
			else
				fieldMap.Add(_LIBRARY_UUID, null );
			if( fieldMap.ContainsKey(_SIGNAL_UUID) )
				fieldMap[_SIGNAL_UUID] = null;
			else
				fieldMap.Add(_SIGNAL_UUID, null );
			initialize();
		}

		public TestSignalSignalBean( OleDbDataReader reader ):base( _TABLE_NAME )
		{
			if( fieldMap.ContainsKey(_ID) )
				fieldMap[_ID] = reader[_ID];
			else
				fieldMap.Add(_ID, reader[_ID]);
			if( fieldMap.ContainsKey(_LIBRARY_UUID) )
				fieldMap[_LIBRARY_UUID] = reader[_LIBRARY_UUID];
			else
				fieldMap.Add(_LIBRARY_UUID, reader[_LIBRARY_UUID]);
			if( fieldMap.ContainsKey(_SIGNAL_UUID) )
				fieldMap[_SIGNAL_UUID] = reader[_SIGNAL_UUID];
			else
				fieldMap.Add(_SIGNAL_UUID, reader[_SIGNAL_UUID]);
			initialize();
		}

		private void initialize( )
		{
			keys.Add( "id" );
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
			if( fieldMap.ContainsKey(_LIBRARY_UUID) )
				fieldMap[_LIBRARY_UUID] = reader[_LIBRARY_UUID];
			else
				fieldMap.Add(_LIBRARY_UUID, reader[_LIBRARY_UUID]);
			if( originalFieldMap.ContainsKey(_LIBRARY_UUID) )
				originalFieldMap[_LIBRARY_UUID] = reader[_LIBRARY_UUID];
			else
				originalFieldMap.Add(_LIBRARY_UUID, reader[_LIBRARY_UUID]);
			if( fieldMap.ContainsKey(_SIGNAL_UUID) )
				fieldMap[_SIGNAL_UUID] = reader[_SIGNAL_UUID];
			else
				fieldMap.Add(_SIGNAL_UUID, reader[_SIGNAL_UUID]);
			if( originalFieldMap.ContainsKey(_SIGNAL_UUID) )
				originalFieldMap[_SIGNAL_UUID] = reader[_SIGNAL_UUID];
			else
				originalFieldMap.Add(_SIGNAL_UUID, reader[_SIGNAL_UUID]);
		}

		public override void writeStartXML(UTRSXmlWriter xml)
		{
			xml.WriteStartElement(_TABLE_NAME.ToLower());
		}

		public override void writeXML(UTRSXmlWriter xml)
		{
			xml.WriteElementSafeString(_ID.ToLower(), id);
			xml.WriteElementSafeString(_LIBRARY_UUID.ToLower(), libraryUuid);
			xml.WriteElementSafeString(_SIGNAL_UUID.ToLower(), signalUuid);
		}

		public override void writeEndXML(UTRSXmlWriter xml)
		{
			xml.WriteEndElement();
		}

	}
}
