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
	public partial class SchemasBean : BASEBean
	{
		public static readonly System.String _TABLE_NAME = "schemas";
		public static readonly System.String _ID = "ID";
		public static readonly System.String _SCHEMA_NAMESPACE = "schema_namespace";
		public static readonly System.String _SCHEMA_CONTENT = "schema_content";
		public static readonly System.String _ACTIVE_FLAG = "active_flag";


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

		public System.String schemaNamespace
		{
			get { return fieldMap[_SCHEMA_NAMESPACE]==System.DBNull.Value || fieldMap[_SCHEMA_NAMESPACE] == null ? null : fieldMap[_SCHEMA_NAMESPACE].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_SCHEMA_NAMESPACE) )
				{
					oldValue = fieldMap[_SCHEMA_NAMESPACE];
					fieldMap[_SCHEMA_NAMESPACE] = value;
				}
				else
				{
					fieldMap.Add(_SCHEMA_NAMESPACE, value);
					fieldTypeMap.Add(_SCHEMA_NAMESPACE, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_SCHEMA_NAMESPACE, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.String schemaContent
		{
			get { return fieldMap[_SCHEMA_CONTENT]==System.DBNull.Value || fieldMap[_SCHEMA_CONTENT] == null ? null : fieldMap[_SCHEMA_CONTENT].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_SCHEMA_CONTENT) )
				{
					oldValue = fieldMap[_SCHEMA_CONTENT];
					fieldMap[_SCHEMA_CONTENT] = value;
				}
				else
				{
					fieldMap.Add(_SCHEMA_CONTENT, value);
					fieldTypeMap.Add(_SCHEMA_CONTENT, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_SCHEMA_CONTENT, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.Int32? activeFlag
		{
			get { return fieldMap[_ACTIVE_FLAG]==System.DBNull.Value || fieldMap[_ACTIVE_FLAG] == null ? null : (System.Int32? )fieldMap[_ACTIVE_FLAG];  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_ACTIVE_FLAG) )
				{
					oldValue = fieldMap[_ACTIVE_FLAG];
					fieldMap[_ACTIVE_FLAG] = value;
				}
				else
				{
					fieldMap.Add(_ACTIVE_FLAG, value);
					fieldTypeMap.Add(_ACTIVE_FLAG, OleDbType.Integer );
				}
				EventArgs arg = new DataChangedEventArgs(_ACTIVE_FLAG, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public SchemasBean( ):base( _TABLE_NAME )
		{
			if( fieldMap.ContainsKey(_ID) )
				fieldMap[_ID] = null;
			else
				fieldMap.Add(_ID, null );
			if( fieldMap.ContainsKey(_SCHEMA_NAMESPACE) )
				fieldMap[_SCHEMA_NAMESPACE] = null;
			else
				fieldMap.Add(_SCHEMA_NAMESPACE, null );
			if( fieldMap.ContainsKey(_SCHEMA_CONTENT) )
				fieldMap[_SCHEMA_CONTENT] = null;
			else
				fieldMap.Add(_SCHEMA_CONTENT, null );
			if( fieldMap.ContainsKey(_ACTIVE_FLAG) )
				fieldMap[_ACTIVE_FLAG] = null;
			else
				fieldMap.Add(_ACTIVE_FLAG, null );
			initialize();
		}

		public SchemasBean( OleDbDataReader reader ):base( _TABLE_NAME )
		{
			if( fieldMap.ContainsKey(_ID) )
				fieldMap[_ID] = reader[_ID];
			else
				fieldMap.Add(_ID, reader[_ID]);
			if( fieldMap.ContainsKey(_SCHEMA_NAMESPACE) )
				fieldMap[_SCHEMA_NAMESPACE] = reader[_SCHEMA_NAMESPACE];
			else
				fieldMap.Add(_SCHEMA_NAMESPACE, reader[_SCHEMA_NAMESPACE]);
			if( fieldMap.ContainsKey(_SCHEMA_CONTENT) )
				fieldMap[_SCHEMA_CONTENT] = reader[_SCHEMA_CONTENT];
			else
				fieldMap.Add(_SCHEMA_CONTENT, reader[_SCHEMA_CONTENT]);
			if( fieldMap.ContainsKey(_ACTIVE_FLAG) )
				fieldMap[_ACTIVE_FLAG] = reader[_ACTIVE_FLAG];
			else
				fieldMap.Add(_ACTIVE_FLAG, reader[_ACTIVE_FLAG]);
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
			if( fieldMap.ContainsKey(_SCHEMA_NAMESPACE) )
				fieldMap[_SCHEMA_NAMESPACE] = reader[_SCHEMA_NAMESPACE];
			else
				fieldMap.Add(_SCHEMA_NAMESPACE, reader[_SCHEMA_NAMESPACE]);
			if( originalFieldMap.ContainsKey(_SCHEMA_NAMESPACE) )
				originalFieldMap[_SCHEMA_NAMESPACE] = reader[_SCHEMA_NAMESPACE];
			else
				originalFieldMap.Add(_SCHEMA_NAMESPACE, reader[_SCHEMA_NAMESPACE]);
			if( fieldMap.ContainsKey(_SCHEMA_CONTENT) )
				fieldMap[_SCHEMA_CONTENT] = reader[_SCHEMA_CONTENT];
			else
				fieldMap.Add(_SCHEMA_CONTENT, reader[_SCHEMA_CONTENT]);
			if( originalFieldMap.ContainsKey(_SCHEMA_CONTENT) )
				originalFieldMap[_SCHEMA_CONTENT] = reader[_SCHEMA_CONTENT];
			else
				originalFieldMap.Add(_SCHEMA_CONTENT, reader[_SCHEMA_CONTENT]);
			if( fieldMap.ContainsKey(_ACTIVE_FLAG) )
				fieldMap[_ACTIVE_FLAG] = reader[_ACTIVE_FLAG];
			else
				fieldMap.Add(_ACTIVE_FLAG, reader[_ACTIVE_FLAG]);
			if( originalFieldMap.ContainsKey(_ACTIVE_FLAG) )
				originalFieldMap[_ACTIVE_FLAG] = reader[_ACTIVE_FLAG];
			else
				originalFieldMap.Add(_ACTIVE_FLAG, reader[_ACTIVE_FLAG]);
		}

		public override void writeStartXML(UTRSXmlWriter xml)
		{
			xml.WriteStartElement(_TABLE_NAME.ToLower());
		}

		public override void writeXML(UTRSXmlWriter xml)
		{
			xml.WriteElementSafeString(_ID.ToLower(), ID);
			xml.WriteElementSafeString(_SCHEMA_NAMESPACE.ToLower(), schemaNamespace);
			xml.WriteElementSafeString(_SCHEMA_CONTENT.ToLower(), schemaContent);
			xml.WriteElementSafeString(_ACTIVE_FLAG.ToLower(), activeFlag);
		}

		public override void writeEndXML(UTRSXmlWriter xml)
		{
			xml.WriteEndElement();
		}

	}
}
