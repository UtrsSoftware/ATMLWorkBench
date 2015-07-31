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
	public partial class LuDocumentTypeBean : BASEBean
	{
		public static readonly System.String _TABLE_NAME = "lu_document_type";
		public static readonly System.String _TYPE_ID = "type_id";
		public static readonly System.String _TYPE_NAME = "type_name";
		public static readonly System.String _CONTENT_TYPE = "content_type";
		public static readonly System.String _OBJECT_EDITABLE = "object_editable";


		public System.Int32? typeId
		{
			get { return fieldMap[_TYPE_ID]==System.DBNull.Value || fieldMap[_TYPE_ID] == null ? null : (System.Int32? )fieldMap[_TYPE_ID];  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_TYPE_ID) )
				{
					oldValue = fieldMap[_TYPE_ID];
					fieldMap[_TYPE_ID] = value;
				}
				else
				{
					fieldMap.Add(_TYPE_ID, value);
					fieldTypeMap.Add(_TYPE_ID, OleDbType.Integer );
				}
				EventArgs arg = new DataChangedEventArgs(_TYPE_ID, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.String typeName
		{
			get { return fieldMap[_TYPE_NAME]==System.DBNull.Value || fieldMap[_TYPE_NAME] == null ? null : fieldMap[_TYPE_NAME].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_TYPE_NAME) )
				{
					oldValue = fieldMap[_TYPE_NAME];
					fieldMap[_TYPE_NAME] = value;
				}
				else
				{
					fieldMap.Add(_TYPE_NAME, value);
					fieldTypeMap.Add(_TYPE_NAME, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_TYPE_NAME, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.String contentType
		{
			get { return fieldMap[_CONTENT_TYPE]==System.DBNull.Value || fieldMap[_CONTENT_TYPE] == null ? null : fieldMap[_CONTENT_TYPE].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_CONTENT_TYPE) )
				{
					oldValue = fieldMap[_CONTENT_TYPE];
					fieldMap[_CONTENT_TYPE] = value;
				}
				else
				{
					fieldMap.Add(_CONTENT_TYPE, value);
					fieldTypeMap.Add(_CONTENT_TYPE, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_CONTENT_TYPE, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.Boolean? objectEditable
		{
			get { return fieldMap[_OBJECT_EDITABLE]==System.DBNull.Value || fieldMap[_OBJECT_EDITABLE] == null ? null : (System.Boolean? )fieldMap[_OBJECT_EDITABLE];  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_OBJECT_EDITABLE) )
				{
					oldValue = fieldMap[_OBJECT_EDITABLE];
					fieldMap[_OBJECT_EDITABLE] = value;
				}
				else
				{
					fieldMap.Add(_OBJECT_EDITABLE, value);
					fieldTypeMap.Add(_OBJECT_EDITABLE, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_OBJECT_EDITABLE, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public LuDocumentTypeBean( ):base( _TABLE_NAME )
		{
			if( fieldMap.ContainsKey(_TYPE_ID) )
				fieldMap[_TYPE_ID] = null;
			else
				fieldMap.Add(_TYPE_ID, null );
			if( fieldMap.ContainsKey(_TYPE_NAME) )
				fieldMap[_TYPE_NAME] = null;
			else
				fieldMap.Add(_TYPE_NAME, null );
			if( fieldMap.ContainsKey(_CONTENT_TYPE) )
				fieldMap[_CONTENT_TYPE] = null;
			else
				fieldMap.Add(_CONTENT_TYPE, null );
			if( fieldMap.ContainsKey(_OBJECT_EDITABLE) )
				fieldMap[_OBJECT_EDITABLE] = null;
			else
				fieldMap.Add(_OBJECT_EDITABLE, null );
			initialize();
		}

		public LuDocumentTypeBean( OleDbDataReader reader ):base( _TABLE_NAME )
		{
			if( fieldMap.ContainsKey(_TYPE_ID) )
				fieldMap[_TYPE_ID] = reader[_TYPE_ID];
			else
				fieldMap.Add(_TYPE_ID, reader[_TYPE_ID]);
			if( fieldMap.ContainsKey(_TYPE_NAME) )
				fieldMap[_TYPE_NAME] = reader[_TYPE_NAME];
			else
				fieldMap.Add(_TYPE_NAME, reader[_TYPE_NAME]);
			if( fieldMap.ContainsKey(_CONTENT_TYPE) )
				fieldMap[_CONTENT_TYPE] = reader[_CONTENT_TYPE];
			else
				fieldMap.Add(_CONTENT_TYPE, reader[_CONTENT_TYPE]);
			if( fieldMap.ContainsKey(_OBJECT_EDITABLE) )
				fieldMap[_OBJECT_EDITABLE] = reader[_OBJECT_EDITABLE];
			else
				fieldMap.Add(_OBJECT_EDITABLE, reader[_OBJECT_EDITABLE]);
			initialize();
		}

		private void initialize( )
		{
			keys.Add( "type_id" );
		}

		public override void load(  OleDbDataReader reader )
		{
			base.resetDirtyState();
			if( fieldMap.ContainsKey(_TYPE_ID) )
				fieldMap[_TYPE_ID] = reader[_TYPE_ID];
			else
				fieldMap.Add(_TYPE_ID, reader[_TYPE_ID]);
			if( originalFieldMap.ContainsKey(_TYPE_ID) )
				originalFieldMap[_TYPE_ID] = reader[_TYPE_ID];
			else
				originalFieldMap.Add(_TYPE_ID, reader[_TYPE_ID]);
			if( fieldMap.ContainsKey(_TYPE_NAME) )
				fieldMap[_TYPE_NAME] = reader[_TYPE_NAME];
			else
				fieldMap.Add(_TYPE_NAME, reader[_TYPE_NAME]);
			if( originalFieldMap.ContainsKey(_TYPE_NAME) )
				originalFieldMap[_TYPE_NAME] = reader[_TYPE_NAME];
			else
				originalFieldMap.Add(_TYPE_NAME, reader[_TYPE_NAME]);
			if( fieldMap.ContainsKey(_CONTENT_TYPE) )
				fieldMap[_CONTENT_TYPE] = reader[_CONTENT_TYPE];
			else
				fieldMap.Add(_CONTENT_TYPE, reader[_CONTENT_TYPE]);
			if( originalFieldMap.ContainsKey(_CONTENT_TYPE) )
				originalFieldMap[_CONTENT_TYPE] = reader[_CONTENT_TYPE];
			else
				originalFieldMap.Add(_CONTENT_TYPE, reader[_CONTENT_TYPE]);
			if( fieldMap.ContainsKey(_OBJECT_EDITABLE) )
				fieldMap[_OBJECT_EDITABLE] = reader[_OBJECT_EDITABLE];
			else
				fieldMap.Add(_OBJECT_EDITABLE, reader[_OBJECT_EDITABLE]);
			if( originalFieldMap.ContainsKey(_OBJECT_EDITABLE) )
				originalFieldMap[_OBJECT_EDITABLE] = reader[_OBJECT_EDITABLE];
			else
				originalFieldMap.Add(_OBJECT_EDITABLE, reader[_OBJECT_EDITABLE]);
		}

		public override void writeStartXML(UTRSXmlWriter xml)
		{
			xml.WriteStartElement(_TABLE_NAME.ToLower());
		}

		public override void writeXML(UTRSXmlWriter xml)
		{
			xml.WriteElementSafeString(_TYPE_ID.ToLower(), typeId);
			xml.WriteElementSafeString(_TYPE_NAME.ToLower(), typeName);
			xml.WriteElementSafeString(_CONTENT_TYPE.ToLower(), contentType);
			xml.WriteElementSafeString(_OBJECT_EDITABLE.ToLower(), objectEditable);
		}

		public override void writeEndXML(UTRSXmlWriter xml)
		{
			xml.WriteEndElement();
		}

	}
}
