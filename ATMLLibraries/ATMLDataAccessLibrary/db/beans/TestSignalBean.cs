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
	public partial class TestSignalBean : BASEBean
	{
		public static readonly System.String _TABLE_NAME = "test_signal";
		public static readonly System.String _ID = "id";
		public static readonly System.String _LIBRARY_UUID = "library_uuid";
		public static readonly System.String _SIGNAL_NAME = "signal_name";
		public static readonly System.String _SIGNAL_CONTENT = "signal_content";
		public static readonly System.String _LAST_UPDATE = "last_update";


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

		public System.String signalName
		{
			get { return fieldMap[_SIGNAL_NAME]==System.DBNull.Value || fieldMap[_SIGNAL_NAME] == null ? null : fieldMap[_SIGNAL_NAME].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_SIGNAL_NAME) )
				{
					oldValue = fieldMap[_SIGNAL_NAME];
					fieldMap[_SIGNAL_NAME] = value;
				}
				else
				{
					fieldMap.Add(_SIGNAL_NAME, value);
					fieldTypeMap.Add(_SIGNAL_NAME, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_SIGNAL_NAME, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.String signalContent
		{
			get { return fieldMap[_SIGNAL_CONTENT]==System.DBNull.Value || fieldMap[_SIGNAL_CONTENT] == null ? null : fieldMap[_SIGNAL_CONTENT].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_SIGNAL_CONTENT) )
				{
					oldValue = fieldMap[_SIGNAL_CONTENT];
					fieldMap[_SIGNAL_CONTENT] = value;
				}
				else
				{
					fieldMap.Add(_SIGNAL_CONTENT, value);
					fieldTypeMap.Add(_SIGNAL_CONTENT, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_SIGNAL_CONTENT, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.DateTime? lastUpdate
		{
			get { return fieldMap[_LAST_UPDATE]==System.DBNull.Value || fieldMap[_LAST_UPDATE] == null ? null : (System.DateTime? )fieldMap[_LAST_UPDATE];  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_LAST_UPDATE) )
				{
					oldValue = fieldMap[_LAST_UPDATE];
					fieldMap[_LAST_UPDATE] = value;
				}
				else
				{
					fieldMap.Add(_LAST_UPDATE, value);
					fieldTypeMap.Add(_LAST_UPDATE, OleDbType.Date );
				}
				EventArgs arg = new DataChangedEventArgs(_LAST_UPDATE, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public TestSignalBean( ):base( _TABLE_NAME )
		{
			if( fieldMap.ContainsKey(_ID) )
				fieldMap[_ID] = null;
			else
				fieldMap.Add(_ID, null );
			if( fieldMap.ContainsKey(_LIBRARY_UUID) )
				fieldMap[_LIBRARY_UUID] = null;
			else
				fieldMap.Add(_LIBRARY_UUID, null );
			if( fieldMap.ContainsKey(_SIGNAL_NAME) )
				fieldMap[_SIGNAL_NAME] = null;
			else
				fieldMap.Add(_SIGNAL_NAME, null );
			if( fieldMap.ContainsKey(_SIGNAL_CONTENT) )
				fieldMap[_SIGNAL_CONTENT] = null;
			else
				fieldMap.Add(_SIGNAL_CONTENT, null );
			if( fieldMap.ContainsKey(_LAST_UPDATE) )
				fieldMap[_LAST_UPDATE] = null;
			else
				fieldMap.Add(_LAST_UPDATE, null );
			initialize();
		}

		public TestSignalBean( OleDbDataReader reader ):base( _TABLE_NAME )
		{
			if( fieldMap.ContainsKey(_ID) )
				fieldMap[_ID] = reader[_ID];
			else
				fieldMap.Add(_ID, reader[_ID]);
			if( fieldMap.ContainsKey(_LIBRARY_UUID) )
				fieldMap[_LIBRARY_UUID] = reader[_LIBRARY_UUID];
			else
				fieldMap.Add(_LIBRARY_UUID, reader[_LIBRARY_UUID]);
			if( fieldMap.ContainsKey(_SIGNAL_NAME) )
				fieldMap[_SIGNAL_NAME] = reader[_SIGNAL_NAME];
			else
				fieldMap.Add(_SIGNAL_NAME, reader[_SIGNAL_NAME]);
			if( fieldMap.ContainsKey(_SIGNAL_CONTENT) )
				fieldMap[_SIGNAL_CONTENT] = reader[_SIGNAL_CONTENT];
			else
				fieldMap.Add(_SIGNAL_CONTENT, reader[_SIGNAL_CONTENT]);
			if( fieldMap.ContainsKey(_LAST_UPDATE) )
				fieldMap[_LAST_UPDATE] = reader[_LAST_UPDATE];
			else
				fieldMap.Add(_LAST_UPDATE, reader[_LAST_UPDATE]);
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
			if( fieldMap.ContainsKey(_SIGNAL_NAME) )
				fieldMap[_SIGNAL_NAME] = reader[_SIGNAL_NAME];
			else
				fieldMap.Add(_SIGNAL_NAME, reader[_SIGNAL_NAME]);
			if( originalFieldMap.ContainsKey(_SIGNAL_NAME) )
				originalFieldMap[_SIGNAL_NAME] = reader[_SIGNAL_NAME];
			else
				originalFieldMap.Add(_SIGNAL_NAME, reader[_SIGNAL_NAME]);
			if( fieldMap.ContainsKey(_SIGNAL_CONTENT) )
				fieldMap[_SIGNAL_CONTENT] = reader[_SIGNAL_CONTENT];
			else
				fieldMap.Add(_SIGNAL_CONTENT, reader[_SIGNAL_CONTENT]);
			if( originalFieldMap.ContainsKey(_SIGNAL_CONTENT) )
				originalFieldMap[_SIGNAL_CONTENT] = reader[_SIGNAL_CONTENT];
			else
				originalFieldMap.Add(_SIGNAL_CONTENT, reader[_SIGNAL_CONTENT]);
			if( fieldMap.ContainsKey(_LAST_UPDATE) )
				fieldMap[_LAST_UPDATE] = reader[_LAST_UPDATE];
			else
				fieldMap.Add(_LAST_UPDATE, reader[_LAST_UPDATE]);
			if( originalFieldMap.ContainsKey(_LAST_UPDATE) )
				originalFieldMap[_LAST_UPDATE] = reader[_LAST_UPDATE];
			else
				originalFieldMap.Add(_LAST_UPDATE, reader[_LAST_UPDATE]);
		}

		public override void writeStartXML(UTRSXmlWriter xml)
		{
			xml.WriteStartElement(_TABLE_NAME.ToLower());
		}

		public override void writeXML(UTRSXmlWriter xml)
		{
			xml.WriteElementSafeString(_ID.ToLower(), id);
			xml.WriteElementSafeString(_LIBRARY_UUID.ToLower(), libraryUuid);
			xml.WriteElementSafeString(_SIGNAL_NAME.ToLower(), signalName);
			xml.WriteElementSafeString(_SIGNAL_CONTENT.ToLower(), signalContent);
			xml.WriteElementSafeString(_LAST_UPDATE.ToLower(), lastUpdate);
		}

		public override void writeEndXML(UTRSXmlWriter xml)
		{
			xml.WriteEndElement();
		}

	}
}
