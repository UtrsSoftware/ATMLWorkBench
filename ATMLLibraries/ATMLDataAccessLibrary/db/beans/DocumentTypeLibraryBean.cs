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
	public partial class DocumentTypeLibraryBean : BASEBean
	{
		public static readonly System.String _TABLE_NAME = "document_type_library";
		public static readonly System.String _ID = "ID";
		public static readonly System.String _EXTENSION = "extension";
		public static readonly System.String _ASCII = "ascii";
		public static readonly System.String _SIGNATURE = "signature";
		public static readonly System.String _OFFSET = "offset";
		public static readonly System.String _SIZE = "size";
		public static readonly System.String _CONTENT_TYPE = "content_type";


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

		public System.String extension
		{
			get { return fieldMap[_EXTENSION]==System.DBNull.Value || fieldMap[_EXTENSION] == null ? null : fieldMap[_EXTENSION].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_EXTENSION) )
				{
					oldValue = fieldMap[_EXTENSION];
					fieldMap[_EXTENSION] = value;
				}
				else
				{
					fieldMap.Add(_EXTENSION, value);
					fieldTypeMap.Add(_EXTENSION, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_EXTENSION, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.String ascii
		{
			get { return fieldMap[_ASCII]==System.DBNull.Value || fieldMap[_ASCII] == null ? null : fieldMap[_ASCII].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_ASCII) )
				{
					oldValue = fieldMap[_ASCII];
					fieldMap[_ASCII] = value;
				}
				else
				{
					fieldMap.Add(_ASCII, value);
					fieldTypeMap.Add(_ASCII, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_ASCII, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.Byte[] signature
		{
			get { return fieldMap[_SIGNATURE]==System.DBNull.Value || fieldMap[_SIGNATURE] == null ? null : (System.Byte[] )fieldMap[_SIGNATURE];  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_SIGNATURE) )
				{
					oldValue = fieldMap[_SIGNATURE];
					fieldMap[_SIGNATURE] = value;
				}
				else
				{
					fieldMap.Add(_SIGNATURE, value);
					fieldTypeMap.Add(_SIGNATURE, OleDbType.LongVarBinary );
				}
				EventArgs arg = new DataChangedEventArgs(_SIGNATURE, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.Int32? offset
		{
			get { return fieldMap[_OFFSET]==System.DBNull.Value || fieldMap[_OFFSET] == null ? null : (System.Int32? )fieldMap[_OFFSET];  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_OFFSET) )
				{
					oldValue = fieldMap[_OFFSET];
					fieldMap[_OFFSET] = value;
				}
				else
				{
					fieldMap.Add(_OFFSET, value);
					fieldTypeMap.Add(_OFFSET, OleDbType.Integer );
				}
				EventArgs arg = new DataChangedEventArgs(_OFFSET, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.Int32? size
		{
			get { return fieldMap[_SIZE]==System.DBNull.Value || fieldMap[_SIZE] == null ? null : (System.Int32? )fieldMap[_SIZE];  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_SIZE) )
				{
					oldValue = fieldMap[_SIZE];
					fieldMap[_SIZE] = value;
				}
				else
				{
					fieldMap.Add(_SIZE, value);
					fieldTypeMap.Add(_SIZE, OleDbType.Integer );
				}
				EventArgs arg = new DataChangedEventArgs(_SIZE, oldValue, value);
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

		public DocumentTypeLibraryBean( ):base( _TABLE_NAME )
		{
			if( fieldMap.ContainsKey(_ID) )
				fieldMap[_ID] = null;
			else
				fieldMap.Add(_ID, null );
			if( fieldMap.ContainsKey(_EXTENSION) )
				fieldMap[_EXTENSION] = null;
			else
				fieldMap.Add(_EXTENSION, null );
			if( fieldMap.ContainsKey(_ASCII) )
				fieldMap[_ASCII] = null;
			else
				fieldMap.Add(_ASCII, null );
			if( fieldMap.ContainsKey(_SIGNATURE) )
				fieldMap[_SIGNATURE] = null;
			else
				fieldMap.Add(_SIGNATURE, null );
			if( fieldMap.ContainsKey(_OFFSET) )
				fieldMap[_OFFSET] = null;
			else
				fieldMap.Add(_OFFSET, null );
			if( fieldMap.ContainsKey(_SIZE) )
				fieldMap[_SIZE] = null;
			else
				fieldMap.Add(_SIZE, null );
			if( fieldMap.ContainsKey(_CONTENT_TYPE) )
				fieldMap[_CONTENT_TYPE] = null;
			else
				fieldMap.Add(_CONTENT_TYPE, null );
			initialize();
		}

		public DocumentTypeLibraryBean( OleDbDataReader reader ):base( _TABLE_NAME )
		{
			if( fieldMap.ContainsKey(_ID) )
				fieldMap[_ID] = reader[_ID];
			else
				fieldMap.Add(_ID, reader[_ID]);
			if( fieldMap.ContainsKey(_EXTENSION) )
				fieldMap[_EXTENSION] = reader[_EXTENSION];
			else
				fieldMap.Add(_EXTENSION, reader[_EXTENSION]);
			if( fieldMap.ContainsKey(_ASCII) )
				fieldMap[_ASCII] = reader[_ASCII];
			else
				fieldMap.Add(_ASCII, reader[_ASCII]);
			if( fieldMap.ContainsKey(_SIGNATURE) )
				fieldMap[_SIGNATURE] = reader[_SIGNATURE];
			else
				fieldMap.Add(_SIGNATURE, reader[_SIGNATURE]);
			if( fieldMap.ContainsKey(_OFFSET) )
				fieldMap[_OFFSET] = reader[_OFFSET];
			else
				fieldMap.Add(_OFFSET, reader[_OFFSET]);
			if( fieldMap.ContainsKey(_SIZE) )
				fieldMap[_SIZE] = reader[_SIZE];
			else
				fieldMap.Add(_SIZE, reader[_SIZE]);
			if( fieldMap.ContainsKey(_CONTENT_TYPE) )
				fieldMap[_CONTENT_TYPE] = reader[_CONTENT_TYPE];
			else
				fieldMap.Add(_CONTENT_TYPE, reader[_CONTENT_TYPE]);
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
			if( fieldMap.ContainsKey(_EXTENSION) )
				fieldMap[_EXTENSION] = reader[_EXTENSION];
			else
				fieldMap.Add(_EXTENSION, reader[_EXTENSION]);
			if( originalFieldMap.ContainsKey(_EXTENSION) )
				originalFieldMap[_EXTENSION] = reader[_EXTENSION];
			else
				originalFieldMap.Add(_EXTENSION, reader[_EXTENSION]);
			if( fieldMap.ContainsKey(_ASCII) )
				fieldMap[_ASCII] = reader[_ASCII];
			else
				fieldMap.Add(_ASCII, reader[_ASCII]);
			if( originalFieldMap.ContainsKey(_ASCII) )
				originalFieldMap[_ASCII] = reader[_ASCII];
			else
				originalFieldMap.Add(_ASCII, reader[_ASCII]);
			if( fieldMap.ContainsKey(_SIGNATURE) )
				fieldMap[_SIGNATURE] = reader[_SIGNATURE];
			else
				fieldMap.Add(_SIGNATURE, reader[_SIGNATURE]);
			if( originalFieldMap.ContainsKey(_SIGNATURE) )
				originalFieldMap[_SIGNATURE] = reader[_SIGNATURE];
			else
				originalFieldMap.Add(_SIGNATURE, reader[_SIGNATURE]);
			if( fieldMap.ContainsKey(_OFFSET) )
				fieldMap[_OFFSET] = reader[_OFFSET];
			else
				fieldMap.Add(_OFFSET, reader[_OFFSET]);
			if( originalFieldMap.ContainsKey(_OFFSET) )
				originalFieldMap[_OFFSET] = reader[_OFFSET];
			else
				originalFieldMap.Add(_OFFSET, reader[_OFFSET]);
			if( fieldMap.ContainsKey(_SIZE) )
				fieldMap[_SIZE] = reader[_SIZE];
			else
				fieldMap.Add(_SIZE, reader[_SIZE]);
			if( originalFieldMap.ContainsKey(_SIZE) )
				originalFieldMap[_SIZE] = reader[_SIZE];
			else
				originalFieldMap.Add(_SIZE, reader[_SIZE]);
			if( fieldMap.ContainsKey(_CONTENT_TYPE) )
				fieldMap[_CONTENT_TYPE] = reader[_CONTENT_TYPE];
			else
				fieldMap.Add(_CONTENT_TYPE, reader[_CONTENT_TYPE]);
			if( originalFieldMap.ContainsKey(_CONTENT_TYPE) )
				originalFieldMap[_CONTENT_TYPE] = reader[_CONTENT_TYPE];
			else
				originalFieldMap.Add(_CONTENT_TYPE, reader[_CONTENT_TYPE]);
		}

		public override void writeStartXML(UTRSXmlWriter xml)
		{
			xml.WriteStartElement(_TABLE_NAME.ToLower());
		}

		public override void writeXML(UTRSXmlWriter xml)
		{
			xml.WriteElementSafeString(_ID.ToLower(), ID);
			xml.WriteElementSafeString(_EXTENSION.ToLower(), extension);
			xml.WriteElementSafeString(_ASCII.ToLower(), ascii);
			xml.WriteElementSafeString(_SIGNATURE.ToLower(), signature);
			xml.WriteElementSafeString(_OFFSET.ToLower(), offset);
			xml.WriteElementSafeString(_SIZE.ToLower(), size);
			xml.WriteElementSafeString(_CONTENT_TYPE.ToLower(), contentType);
		}

		public override void writeEndXML(UTRSXmlWriter xml)
		{
			xml.WriteEndElement();
		}

	}
}
