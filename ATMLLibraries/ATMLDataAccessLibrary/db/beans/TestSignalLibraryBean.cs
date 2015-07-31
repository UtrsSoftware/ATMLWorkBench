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
	public partial class TestSignalLibraryBean : BASEBean
	{
		public static readonly System.String _TABLE_NAME = "test_signal_library";
		public static readonly System.String _ID = "id";
		public static readonly System.String _LIBRARY_NAME = "library_name";
		public static readonly System.String _CONTENT = "content";
		public static readonly System.String _FILE_NAME = "file_name";
		public static readonly System.String _LAST_UPDATE = "last_update";
		public static readonly System.String _TARGET_NAMESPACE = "target_namespace";


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

		public System.String libraryName
		{
			get { return fieldMap[_LIBRARY_NAME]==System.DBNull.Value || fieldMap[_LIBRARY_NAME] == null ? null : fieldMap[_LIBRARY_NAME].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_LIBRARY_NAME) )
				{
					oldValue = fieldMap[_LIBRARY_NAME];
					fieldMap[_LIBRARY_NAME] = value;
				}
				else
				{
					fieldMap.Add(_LIBRARY_NAME, value);
					fieldTypeMap.Add(_LIBRARY_NAME, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_LIBRARY_NAME, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.String content
		{
			get { return fieldMap[_CONTENT]==System.DBNull.Value || fieldMap[_CONTENT] == null ? null : fieldMap[_CONTENT].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_CONTENT) )
				{
					oldValue = fieldMap[_CONTENT];
					fieldMap[_CONTENT] = value;
				}
				else
				{
					fieldMap.Add(_CONTENT, value);
					fieldTypeMap.Add(_CONTENT, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_CONTENT, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.String fileName
		{
			get { return fieldMap[_FILE_NAME]==System.DBNull.Value || fieldMap[_FILE_NAME] == null ? null : fieldMap[_FILE_NAME].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_FILE_NAME) )
				{
					oldValue = fieldMap[_FILE_NAME];
					fieldMap[_FILE_NAME] = value;
				}
				else
				{
					fieldMap.Add(_FILE_NAME, value);
					fieldTypeMap.Add(_FILE_NAME, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_FILE_NAME, oldValue, value);
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

		public System.String targetNamespace
		{
			get { return fieldMap[_TARGET_NAMESPACE]==System.DBNull.Value || fieldMap[_TARGET_NAMESPACE] == null ? null : fieldMap[_TARGET_NAMESPACE].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_TARGET_NAMESPACE) )
				{
					oldValue = fieldMap[_TARGET_NAMESPACE];
					fieldMap[_TARGET_NAMESPACE] = value;
				}
				else
				{
					fieldMap.Add(_TARGET_NAMESPACE, value);
					fieldTypeMap.Add(_TARGET_NAMESPACE, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_TARGET_NAMESPACE, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public TestSignalLibraryBean( ):base( _TABLE_NAME )
		{
			if( fieldMap.ContainsKey(_ID) )
				fieldMap[_ID] = null;
			else
				fieldMap.Add(_ID, null );
			if( fieldMap.ContainsKey(_LIBRARY_NAME) )
				fieldMap[_LIBRARY_NAME] = null;
			else
				fieldMap.Add(_LIBRARY_NAME, null );
			if( fieldMap.ContainsKey(_CONTENT) )
				fieldMap[_CONTENT] = null;
			else
				fieldMap.Add(_CONTENT, null );
			if( fieldMap.ContainsKey(_FILE_NAME) )
				fieldMap[_FILE_NAME] = null;
			else
				fieldMap.Add(_FILE_NAME, null );
			if( fieldMap.ContainsKey(_LAST_UPDATE) )
				fieldMap[_LAST_UPDATE] = null;
			else
				fieldMap.Add(_LAST_UPDATE, null );
			if( fieldMap.ContainsKey(_TARGET_NAMESPACE) )
				fieldMap[_TARGET_NAMESPACE] = null;
			else
				fieldMap.Add(_TARGET_NAMESPACE, null );
			initialize();
		}

		public TestSignalLibraryBean( OleDbDataReader reader ):base( _TABLE_NAME )
		{
			if( fieldMap.ContainsKey(_ID) )
				fieldMap[_ID] = reader[_ID];
			else
				fieldMap.Add(_ID, reader[_ID]);
			if( fieldMap.ContainsKey(_LIBRARY_NAME) )
				fieldMap[_LIBRARY_NAME] = reader[_LIBRARY_NAME];
			else
				fieldMap.Add(_LIBRARY_NAME, reader[_LIBRARY_NAME]);
			if( fieldMap.ContainsKey(_CONTENT) )
				fieldMap[_CONTENT] = reader[_CONTENT];
			else
				fieldMap.Add(_CONTENT, reader[_CONTENT]);
			if( fieldMap.ContainsKey(_FILE_NAME) )
				fieldMap[_FILE_NAME] = reader[_FILE_NAME];
			else
				fieldMap.Add(_FILE_NAME, reader[_FILE_NAME]);
			if( fieldMap.ContainsKey(_LAST_UPDATE) )
				fieldMap[_LAST_UPDATE] = reader[_LAST_UPDATE];
			else
				fieldMap.Add(_LAST_UPDATE, reader[_LAST_UPDATE]);
			if( fieldMap.ContainsKey(_TARGET_NAMESPACE) )
				fieldMap[_TARGET_NAMESPACE] = reader[_TARGET_NAMESPACE];
			else
				fieldMap.Add(_TARGET_NAMESPACE, reader[_TARGET_NAMESPACE]);
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
			if( fieldMap.ContainsKey(_LIBRARY_NAME) )
				fieldMap[_LIBRARY_NAME] = reader[_LIBRARY_NAME];
			else
				fieldMap.Add(_LIBRARY_NAME, reader[_LIBRARY_NAME]);
			if( originalFieldMap.ContainsKey(_LIBRARY_NAME) )
				originalFieldMap[_LIBRARY_NAME] = reader[_LIBRARY_NAME];
			else
				originalFieldMap.Add(_LIBRARY_NAME, reader[_LIBRARY_NAME]);
			if( fieldMap.ContainsKey(_CONTENT) )
				fieldMap[_CONTENT] = reader[_CONTENT];
			else
				fieldMap.Add(_CONTENT, reader[_CONTENT]);
			if( originalFieldMap.ContainsKey(_CONTENT) )
				originalFieldMap[_CONTENT] = reader[_CONTENT];
			else
				originalFieldMap.Add(_CONTENT, reader[_CONTENT]);
			if( fieldMap.ContainsKey(_FILE_NAME) )
				fieldMap[_FILE_NAME] = reader[_FILE_NAME];
			else
				fieldMap.Add(_FILE_NAME, reader[_FILE_NAME]);
			if( originalFieldMap.ContainsKey(_FILE_NAME) )
				originalFieldMap[_FILE_NAME] = reader[_FILE_NAME];
			else
				originalFieldMap.Add(_FILE_NAME, reader[_FILE_NAME]);
			if( fieldMap.ContainsKey(_LAST_UPDATE) )
				fieldMap[_LAST_UPDATE] = reader[_LAST_UPDATE];
			else
				fieldMap.Add(_LAST_UPDATE, reader[_LAST_UPDATE]);
			if( originalFieldMap.ContainsKey(_LAST_UPDATE) )
				originalFieldMap[_LAST_UPDATE] = reader[_LAST_UPDATE];
			else
				originalFieldMap.Add(_LAST_UPDATE, reader[_LAST_UPDATE]);
			if( fieldMap.ContainsKey(_TARGET_NAMESPACE) )
				fieldMap[_TARGET_NAMESPACE] = reader[_TARGET_NAMESPACE];
			else
				fieldMap.Add(_TARGET_NAMESPACE, reader[_TARGET_NAMESPACE]);
			if( originalFieldMap.ContainsKey(_TARGET_NAMESPACE) )
				originalFieldMap[_TARGET_NAMESPACE] = reader[_TARGET_NAMESPACE];
			else
				originalFieldMap.Add(_TARGET_NAMESPACE, reader[_TARGET_NAMESPACE]);
		}

		public override void writeStartXML(UTRSXmlWriter xml)
		{
			xml.WriteStartElement(_TABLE_NAME.ToLower());
		}

		public override void writeXML(UTRSXmlWriter xml)
		{
			xml.WriteElementSafeString(_ID.ToLower(), id);
			xml.WriteElementSafeString(_LIBRARY_NAME.ToLower(), libraryName);
			xml.WriteElementSafeString(_CONTENT.ToLower(), content);
			xml.WriteElementSafeString(_FILE_NAME.ToLower(), fileName);
			xml.WriteElementSafeString(_LAST_UPDATE.ToLower(), lastUpdate);
			xml.WriteElementSafeString(_TARGET_NAMESPACE.ToLower(), targetNamespace);
		}

		public override void writeEndXML(UTRSXmlWriter xml)
		{
			xml.WriteEndElement();
		}

	}
}
