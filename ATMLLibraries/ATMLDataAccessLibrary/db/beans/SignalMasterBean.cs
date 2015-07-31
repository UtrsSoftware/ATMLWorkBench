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
	public partial class SignalMasterBean : BASEBean
	{
		public static readonly System.String _TABLE_NAME = "signal_master";
		public static readonly System.String _SIGNAL_ID = "signal_id";
		public static readonly System.String _SIGNAL_NAME = "signal_name";
		public static readonly System.String _PARENT_SIGNAL_ID = "parent_signal_id";
		public static readonly System.String _XMLNS = "xmlns";
		public static readonly System.String _UUID = "uuid";


		public System.Int32? signalId
		{
			get { return fieldMap[_SIGNAL_ID]==System.DBNull.Value || fieldMap[_SIGNAL_ID] == null ? null : (System.Int32? )fieldMap[_SIGNAL_ID];  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_SIGNAL_ID) )
				{
					oldValue = fieldMap[_SIGNAL_ID];
					fieldMap[_SIGNAL_ID] = value;
				}
				else
				{
					fieldMap.Add(_SIGNAL_ID, value);
					fieldTypeMap.Add(_SIGNAL_ID, OleDbType.Integer );
				}
				EventArgs arg = new DataChangedEventArgs(_SIGNAL_ID, oldValue, value);
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

		public System.Int32? parentSignalId
		{
			get { return fieldMap[_PARENT_SIGNAL_ID]==System.DBNull.Value || fieldMap[_PARENT_SIGNAL_ID] == null ? null : (System.Int32? )fieldMap[_PARENT_SIGNAL_ID];  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_PARENT_SIGNAL_ID) )
				{
					oldValue = fieldMap[_PARENT_SIGNAL_ID];
					fieldMap[_PARENT_SIGNAL_ID] = value;
				}
				else
				{
					fieldMap.Add(_PARENT_SIGNAL_ID, value);
					fieldTypeMap.Add(_PARENT_SIGNAL_ID, OleDbType.Integer );
				}
				EventArgs arg = new DataChangedEventArgs(_PARENT_SIGNAL_ID, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.String xmlns
		{
			get { return fieldMap[_XMLNS]==System.DBNull.Value || fieldMap[_XMLNS] == null ? null : fieldMap[_XMLNS].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_XMLNS) )
				{
					oldValue = fieldMap[_XMLNS];
					fieldMap[_XMLNS] = value;
				}
				else
				{
					fieldMap.Add(_XMLNS, value);
					fieldTypeMap.Add(_XMLNS, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_XMLNS, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.Guid? uuid
		{
			get { return fieldMap[_UUID]==System.DBNull.Value || fieldMap[_UUID] == null ? null : (System.Guid? )fieldMap[_UUID];  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_UUID) )
				{
					oldValue = fieldMap[_UUID];
					fieldMap[_UUID] = value;
				}
				else
				{
					fieldMap.Add(_UUID, value);
					fieldTypeMap.Add(_UUID, OleDbType.Guid );
				}
				EventArgs arg = new DataChangedEventArgs(_UUID, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public SignalMasterBean( ):base( _TABLE_NAME )
		{
			if( fieldMap.ContainsKey(_SIGNAL_ID) )
				fieldMap[_SIGNAL_ID] = null;
			else
				fieldMap.Add(_SIGNAL_ID, null );
			if( fieldMap.ContainsKey(_SIGNAL_NAME) )
				fieldMap[_SIGNAL_NAME] = null;
			else
				fieldMap.Add(_SIGNAL_NAME, null );
			if( fieldMap.ContainsKey(_PARENT_SIGNAL_ID) )
				fieldMap[_PARENT_SIGNAL_ID] = null;
			else
				fieldMap.Add(_PARENT_SIGNAL_ID, null );
			if( fieldMap.ContainsKey(_XMLNS) )
				fieldMap[_XMLNS] = null;
			else
				fieldMap.Add(_XMLNS, null );
			if( fieldMap.ContainsKey(_UUID) )
				fieldMap[_UUID] = null;
			else
				fieldMap.Add(_UUID, null );
			initialize();
		}

		public SignalMasterBean( OleDbDataReader reader ):base( _TABLE_NAME )
		{
			if( fieldMap.ContainsKey(_SIGNAL_ID) )
				fieldMap[_SIGNAL_ID] = reader[_SIGNAL_ID];
			else
				fieldMap.Add(_SIGNAL_ID, reader[_SIGNAL_ID]);
			if( fieldMap.ContainsKey(_SIGNAL_NAME) )
				fieldMap[_SIGNAL_NAME] = reader[_SIGNAL_NAME];
			else
				fieldMap.Add(_SIGNAL_NAME, reader[_SIGNAL_NAME]);
			if( fieldMap.ContainsKey(_PARENT_SIGNAL_ID) )
				fieldMap[_PARENT_SIGNAL_ID] = reader[_PARENT_SIGNAL_ID];
			else
				fieldMap.Add(_PARENT_SIGNAL_ID, reader[_PARENT_SIGNAL_ID]);
			if( fieldMap.ContainsKey(_XMLNS) )
				fieldMap[_XMLNS] = reader[_XMLNS];
			else
				fieldMap.Add(_XMLNS, reader[_XMLNS]);
			if( fieldMap.ContainsKey(_UUID) )
				fieldMap[_UUID] = reader[_UUID];
			else
				fieldMap.Add(_UUID, reader[_UUID]);
			initialize();
		}

		private void initialize( )
		{
			keys.Add( "signal_id" );
		}

		public override void load(  OleDbDataReader reader )
		{
			base.resetDirtyState();
			if( fieldMap.ContainsKey(_SIGNAL_ID) )
				fieldMap[_SIGNAL_ID] = reader[_SIGNAL_ID];
			else
				fieldMap.Add(_SIGNAL_ID, reader[_SIGNAL_ID]);
			if( originalFieldMap.ContainsKey(_SIGNAL_ID) )
				originalFieldMap[_SIGNAL_ID] = reader[_SIGNAL_ID];
			else
				originalFieldMap.Add(_SIGNAL_ID, reader[_SIGNAL_ID]);
			if( fieldMap.ContainsKey(_SIGNAL_NAME) )
				fieldMap[_SIGNAL_NAME] = reader[_SIGNAL_NAME];
			else
				fieldMap.Add(_SIGNAL_NAME, reader[_SIGNAL_NAME]);
			if( originalFieldMap.ContainsKey(_SIGNAL_NAME) )
				originalFieldMap[_SIGNAL_NAME] = reader[_SIGNAL_NAME];
			else
				originalFieldMap.Add(_SIGNAL_NAME, reader[_SIGNAL_NAME]);
			if( fieldMap.ContainsKey(_PARENT_SIGNAL_ID) )
				fieldMap[_PARENT_SIGNAL_ID] = reader[_PARENT_SIGNAL_ID];
			else
				fieldMap.Add(_PARENT_SIGNAL_ID, reader[_PARENT_SIGNAL_ID]);
			if( originalFieldMap.ContainsKey(_PARENT_SIGNAL_ID) )
				originalFieldMap[_PARENT_SIGNAL_ID] = reader[_PARENT_SIGNAL_ID];
			else
				originalFieldMap.Add(_PARENT_SIGNAL_ID, reader[_PARENT_SIGNAL_ID]);
			if( fieldMap.ContainsKey(_XMLNS) )
				fieldMap[_XMLNS] = reader[_XMLNS];
			else
				fieldMap.Add(_XMLNS, reader[_XMLNS]);
			if( originalFieldMap.ContainsKey(_XMLNS) )
				originalFieldMap[_XMLNS] = reader[_XMLNS];
			else
				originalFieldMap.Add(_XMLNS, reader[_XMLNS]);
			if( fieldMap.ContainsKey(_UUID) )
				fieldMap[_UUID] = reader[_UUID];
			else
				fieldMap.Add(_UUID, reader[_UUID]);
			if( originalFieldMap.ContainsKey(_UUID) )
				originalFieldMap[_UUID] = reader[_UUID];
			else
				originalFieldMap.Add(_UUID, reader[_UUID]);
		}

		public override void writeStartXML(UTRSXmlWriter xml)
		{
			xml.WriteStartElement(_TABLE_NAME.ToLower());
		}

		public override void writeXML(UTRSXmlWriter xml)
		{
			xml.WriteElementSafeString(_SIGNAL_ID.ToLower(), signalId);
			xml.WriteElementSafeString(_SIGNAL_NAME.ToLower(), signalName);
			xml.WriteElementSafeString(_PARENT_SIGNAL_ID.ToLower(), parentSignalId);
			xml.WriteElementSafeString(_XMLNS.ToLower(), xmlns);
			xml.WriteElementSafeString(_UUID.ToLower(), uuid);
		}

		public override void writeEndXML(UTRSXmlWriter xml)
		{
			xml.WriteEndElement();
		}

	}
}
