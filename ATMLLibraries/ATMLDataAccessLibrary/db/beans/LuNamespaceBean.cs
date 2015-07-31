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
	public partial class LuNamespaceBean : BASEBean
	{
		public static readonly System.String _TABLE_NAME = "lu_namespace";
		public static readonly System.String _ID = "ID";
		public static readonly System.String _XMLNS = "xmlns";
		public static readonly System.String _APP_NAMESPACE = "app_namespace";


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

		public System.String appNamespace
		{
			get { return fieldMap[_APP_NAMESPACE]==System.DBNull.Value || fieldMap[_APP_NAMESPACE] == null ? null : fieldMap[_APP_NAMESPACE].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_APP_NAMESPACE) )
				{
					oldValue = fieldMap[_APP_NAMESPACE];
					fieldMap[_APP_NAMESPACE] = value;
				}
				else
				{
					fieldMap.Add(_APP_NAMESPACE, value);
					fieldTypeMap.Add(_APP_NAMESPACE, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_APP_NAMESPACE, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public LuNamespaceBean( ):base( _TABLE_NAME )
		{
			if( fieldMap.ContainsKey(_ID) )
				fieldMap[_ID] = null;
			else
				fieldMap.Add(_ID, null );
			if( fieldMap.ContainsKey(_XMLNS) )
				fieldMap[_XMLNS] = null;
			else
				fieldMap.Add(_XMLNS, null );
			if( fieldMap.ContainsKey(_APP_NAMESPACE) )
				fieldMap[_APP_NAMESPACE] = null;
			else
				fieldMap.Add(_APP_NAMESPACE, null );
			initialize();
		}

		public LuNamespaceBean( OleDbDataReader reader ):base( _TABLE_NAME )
		{
			if( fieldMap.ContainsKey(_ID) )
				fieldMap[_ID] = reader[_ID];
			else
				fieldMap.Add(_ID, reader[_ID]);
			if( fieldMap.ContainsKey(_XMLNS) )
				fieldMap[_XMLNS] = reader[_XMLNS];
			else
				fieldMap.Add(_XMLNS, reader[_XMLNS]);
			if( fieldMap.ContainsKey(_APP_NAMESPACE) )
				fieldMap[_APP_NAMESPACE] = reader[_APP_NAMESPACE];
			else
				fieldMap.Add(_APP_NAMESPACE, reader[_APP_NAMESPACE]);
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
			if( fieldMap.ContainsKey(_XMLNS) )
				fieldMap[_XMLNS] = reader[_XMLNS];
			else
				fieldMap.Add(_XMLNS, reader[_XMLNS]);
			if( originalFieldMap.ContainsKey(_XMLNS) )
				originalFieldMap[_XMLNS] = reader[_XMLNS];
			else
				originalFieldMap.Add(_XMLNS, reader[_XMLNS]);
			if( fieldMap.ContainsKey(_APP_NAMESPACE) )
				fieldMap[_APP_NAMESPACE] = reader[_APP_NAMESPACE];
			else
				fieldMap.Add(_APP_NAMESPACE, reader[_APP_NAMESPACE]);
			if( originalFieldMap.ContainsKey(_APP_NAMESPACE) )
				originalFieldMap[_APP_NAMESPACE] = reader[_APP_NAMESPACE];
			else
				originalFieldMap.Add(_APP_NAMESPACE, reader[_APP_NAMESPACE]);
		}

		public override void writeStartXML(UTRSXmlWriter xml)
		{
			xml.WriteStartElement(_TABLE_NAME.ToLower());
		}

		public override void writeXML(UTRSXmlWriter xml)
		{
			xml.WriteElementSafeString(_ID.ToLower(), ID);
			xml.WriteElementSafeString(_XMLNS.ToLower(), xmlns);
			xml.WriteElementSafeString(_APP_NAMESPACE.ToLower(), appNamespace);
		}

		public override void writeEndXML(UTRSXmlWriter xml)
		{
			xml.WriteEndElement();
		}

	}
}
