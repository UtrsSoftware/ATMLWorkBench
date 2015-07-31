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
	public partial class SourceSignalMapBean : BASEBean
	{
		public static readonly System.String _TABLE_NAME = "source_signal_map";
		public static readonly System.String _ID = "id";
		public static readonly System.String _SOURCE_TYPE = "source_type";
		public static readonly System.String _SOURCE_NAME = "source_name";
		public static readonly System.String _TARGET_TYPE = "target_type";
		public static readonly System.String _TARGET_NAME = "target_name";


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

		public System.String sourceType
		{
			get { return fieldMap[_SOURCE_TYPE]==System.DBNull.Value || fieldMap[_SOURCE_TYPE] == null ? null : fieldMap[_SOURCE_TYPE].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_SOURCE_TYPE) )
				{
					oldValue = fieldMap[_SOURCE_TYPE];
					fieldMap[_SOURCE_TYPE] = value;
				}
				else
				{
					fieldMap.Add(_SOURCE_TYPE, value);
					fieldTypeMap.Add(_SOURCE_TYPE, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_SOURCE_TYPE, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.String sourceName
		{
			get { return fieldMap[_SOURCE_NAME]==System.DBNull.Value || fieldMap[_SOURCE_NAME] == null ? null : fieldMap[_SOURCE_NAME].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_SOURCE_NAME) )
				{
					oldValue = fieldMap[_SOURCE_NAME];
					fieldMap[_SOURCE_NAME] = value;
				}
				else
				{
					fieldMap.Add(_SOURCE_NAME, value);
					fieldTypeMap.Add(_SOURCE_NAME, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_SOURCE_NAME, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.String targetType
		{
			get { return fieldMap[_TARGET_TYPE]==System.DBNull.Value || fieldMap[_TARGET_TYPE] == null ? null : fieldMap[_TARGET_TYPE].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_TARGET_TYPE) )
				{
					oldValue = fieldMap[_TARGET_TYPE];
					fieldMap[_TARGET_TYPE] = value;
				}
				else
				{
					fieldMap.Add(_TARGET_TYPE, value);
					fieldTypeMap.Add(_TARGET_TYPE, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_TARGET_TYPE, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.String targetName
		{
			get { return fieldMap[_TARGET_NAME]==System.DBNull.Value || fieldMap[_TARGET_NAME] == null ? null : fieldMap[_TARGET_NAME].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_TARGET_NAME) )
				{
					oldValue = fieldMap[_TARGET_NAME];
					fieldMap[_TARGET_NAME] = value;
				}
				else
				{
					fieldMap.Add(_TARGET_NAME, value);
					fieldTypeMap.Add(_TARGET_NAME, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_TARGET_NAME, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public SourceSignalMapBean( ):base( _TABLE_NAME )
		{
			if( fieldMap.ContainsKey(_ID) )
				fieldMap[_ID] = null;
			else
				fieldMap.Add(_ID, null );
			if( fieldMap.ContainsKey(_SOURCE_TYPE) )
				fieldMap[_SOURCE_TYPE] = null;
			else
				fieldMap.Add(_SOURCE_TYPE, null );
			if( fieldMap.ContainsKey(_SOURCE_NAME) )
				fieldMap[_SOURCE_NAME] = null;
			else
				fieldMap.Add(_SOURCE_NAME, null );
			if( fieldMap.ContainsKey(_TARGET_TYPE) )
				fieldMap[_TARGET_TYPE] = null;
			else
				fieldMap.Add(_TARGET_TYPE, null );
			if( fieldMap.ContainsKey(_TARGET_NAME) )
				fieldMap[_TARGET_NAME] = null;
			else
				fieldMap.Add(_TARGET_NAME, null );
			initialize();
		}

		public SourceSignalMapBean( OleDbDataReader reader ):base( _TABLE_NAME )
		{
			if( fieldMap.ContainsKey(_ID) )
				fieldMap[_ID] = reader[_ID];
			else
				fieldMap.Add(_ID, reader[_ID]);
			if( fieldMap.ContainsKey(_SOURCE_TYPE) )
				fieldMap[_SOURCE_TYPE] = reader[_SOURCE_TYPE];
			else
				fieldMap.Add(_SOURCE_TYPE, reader[_SOURCE_TYPE]);
			if( fieldMap.ContainsKey(_SOURCE_NAME) )
				fieldMap[_SOURCE_NAME] = reader[_SOURCE_NAME];
			else
				fieldMap.Add(_SOURCE_NAME, reader[_SOURCE_NAME]);
			if( fieldMap.ContainsKey(_TARGET_TYPE) )
				fieldMap[_TARGET_TYPE] = reader[_TARGET_TYPE];
			else
				fieldMap.Add(_TARGET_TYPE, reader[_TARGET_TYPE]);
			if( fieldMap.ContainsKey(_TARGET_NAME) )
				fieldMap[_TARGET_NAME] = reader[_TARGET_NAME];
			else
				fieldMap.Add(_TARGET_NAME, reader[_TARGET_NAME]);
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
			if( fieldMap.ContainsKey(_SOURCE_TYPE) )
				fieldMap[_SOURCE_TYPE] = reader[_SOURCE_TYPE];
			else
				fieldMap.Add(_SOURCE_TYPE, reader[_SOURCE_TYPE]);
			if( originalFieldMap.ContainsKey(_SOURCE_TYPE) )
				originalFieldMap[_SOURCE_TYPE] = reader[_SOURCE_TYPE];
			else
				originalFieldMap.Add(_SOURCE_TYPE, reader[_SOURCE_TYPE]);
			if( fieldMap.ContainsKey(_SOURCE_NAME) )
				fieldMap[_SOURCE_NAME] = reader[_SOURCE_NAME];
			else
				fieldMap.Add(_SOURCE_NAME, reader[_SOURCE_NAME]);
			if( originalFieldMap.ContainsKey(_SOURCE_NAME) )
				originalFieldMap[_SOURCE_NAME] = reader[_SOURCE_NAME];
			else
				originalFieldMap.Add(_SOURCE_NAME, reader[_SOURCE_NAME]);
			if( fieldMap.ContainsKey(_TARGET_TYPE) )
				fieldMap[_TARGET_TYPE] = reader[_TARGET_TYPE];
			else
				fieldMap.Add(_TARGET_TYPE, reader[_TARGET_TYPE]);
			if( originalFieldMap.ContainsKey(_TARGET_TYPE) )
				originalFieldMap[_TARGET_TYPE] = reader[_TARGET_TYPE];
			else
				originalFieldMap.Add(_TARGET_TYPE, reader[_TARGET_TYPE]);
			if( fieldMap.ContainsKey(_TARGET_NAME) )
				fieldMap[_TARGET_NAME] = reader[_TARGET_NAME];
			else
				fieldMap.Add(_TARGET_NAME, reader[_TARGET_NAME]);
			if( originalFieldMap.ContainsKey(_TARGET_NAME) )
				originalFieldMap[_TARGET_NAME] = reader[_TARGET_NAME];
			else
				originalFieldMap.Add(_TARGET_NAME, reader[_TARGET_NAME]);
		}

		public override void writeStartXML(UTRSXmlWriter xml)
		{
			xml.WriteStartElement(_TABLE_NAME.ToLower());
		}

		public override void writeXML(UTRSXmlWriter xml)
		{
			xml.WriteElementSafeString(_ID.ToLower(), id);
			xml.WriteElementSafeString(_SOURCE_TYPE.ToLower(), sourceType);
			xml.WriteElementSafeString(_SOURCE_NAME.ToLower(), sourceName);
			xml.WriteElementSafeString(_TARGET_TYPE.ToLower(), targetType);
			xml.WriteElementSafeString(_TARGET_NAME.ToLower(), targetName);
		}

		public override void writeEndXML(UTRSXmlWriter xml)
		{
			xml.WriteEndElement();
		}

	}
}
