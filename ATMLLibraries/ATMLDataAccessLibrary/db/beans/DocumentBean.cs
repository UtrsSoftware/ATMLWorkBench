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
	public partial class DocumentBean : BASEBean
	{
		public static readonly System.String _TABLE_NAME = "document";
		public static readonly System.String _UUID = "UUID";
		public static readonly System.String _DOCUMENT_NAME = "document_name";
		public static readonly System.String _DOCUMENT_DESCRIPTION = "document_description";
		public static readonly System.String _DOCUMENT_TYPE_ID = "document_type_id";
		public static readonly System.String _CONTENT_TYPE = "content_type";
		public static readonly System.String _DATE_ADDED = "date_added";
		public static readonly System.String _DATE_UPDATED = "date_updated";
		public static readonly System.String _DOCUMENT_SIZE = "document_size";
		public static readonly System.String _DOCUMENT_CONTENT = "document_content";
		public static readonly System.String _DOCUMENT_VERSION = "document_version";
		public static readonly System.String _CRC = "crc";


		public System.Guid? UUID
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

		public System.String documentName
		{
			get { return fieldMap[_DOCUMENT_NAME]==System.DBNull.Value || fieldMap[_DOCUMENT_NAME] == null ? null : fieldMap[_DOCUMENT_NAME].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_DOCUMENT_NAME) )
				{
					oldValue = fieldMap[_DOCUMENT_NAME];
					fieldMap[_DOCUMENT_NAME] = value;
				}
				else
				{
					fieldMap.Add(_DOCUMENT_NAME, value);
					fieldTypeMap.Add(_DOCUMENT_NAME, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_DOCUMENT_NAME, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.String documentDescription
		{
			get { return fieldMap[_DOCUMENT_DESCRIPTION]==System.DBNull.Value || fieldMap[_DOCUMENT_DESCRIPTION] == null ? null : fieldMap[_DOCUMENT_DESCRIPTION].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_DOCUMENT_DESCRIPTION) )
				{
					oldValue = fieldMap[_DOCUMENT_DESCRIPTION];
					fieldMap[_DOCUMENT_DESCRIPTION] = value;
				}
				else
				{
					fieldMap.Add(_DOCUMENT_DESCRIPTION, value);
					fieldTypeMap.Add(_DOCUMENT_DESCRIPTION, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_DOCUMENT_DESCRIPTION, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.Int32? documentTypeId
		{
			get { return fieldMap[_DOCUMENT_TYPE_ID]==System.DBNull.Value || fieldMap[_DOCUMENT_TYPE_ID] == null ? null : (System.Int32? )fieldMap[_DOCUMENT_TYPE_ID];  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_DOCUMENT_TYPE_ID) )
				{
					oldValue = fieldMap[_DOCUMENT_TYPE_ID];
					fieldMap[_DOCUMENT_TYPE_ID] = value;
				}
				else
				{
					fieldMap.Add(_DOCUMENT_TYPE_ID, value);
					fieldTypeMap.Add(_DOCUMENT_TYPE_ID, OleDbType.Integer );
				}
				EventArgs arg = new DataChangedEventArgs(_DOCUMENT_TYPE_ID, oldValue, value);
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

		public System.DateTime? dateAdded
		{
			get { return fieldMap[_DATE_ADDED]==System.DBNull.Value || fieldMap[_DATE_ADDED] == null ? null : (System.DateTime? )fieldMap[_DATE_ADDED];  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_DATE_ADDED) )
				{
					oldValue = fieldMap[_DATE_ADDED];
					fieldMap[_DATE_ADDED] = value;
				}
				else
				{
					fieldMap.Add(_DATE_ADDED, value);
					fieldTypeMap.Add(_DATE_ADDED, OleDbType.Date );
				}
				EventArgs arg = new DataChangedEventArgs(_DATE_ADDED, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.DateTime? dateUpdated
		{
			get { return fieldMap[_DATE_UPDATED]==System.DBNull.Value || fieldMap[_DATE_UPDATED] == null ? null : (System.DateTime? )fieldMap[_DATE_UPDATED];  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_DATE_UPDATED) )
				{
					oldValue = fieldMap[_DATE_UPDATED];
					fieldMap[_DATE_UPDATED] = value;
				}
				else
				{
					fieldMap.Add(_DATE_UPDATED, value);
					fieldTypeMap.Add(_DATE_UPDATED, OleDbType.Date );
				}
				EventArgs arg = new DataChangedEventArgs(_DATE_UPDATED, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.Int32? documentSize
		{
			get { return fieldMap[_DOCUMENT_SIZE]==System.DBNull.Value || fieldMap[_DOCUMENT_SIZE] == null ? null : (System.Int32? )fieldMap[_DOCUMENT_SIZE];  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_DOCUMENT_SIZE) )
				{
					oldValue = fieldMap[_DOCUMENT_SIZE];
					fieldMap[_DOCUMENT_SIZE] = value;
				}
				else
				{
					fieldMap.Add(_DOCUMENT_SIZE, value);
					fieldTypeMap.Add(_DOCUMENT_SIZE, OleDbType.Integer );
				}
				EventArgs arg = new DataChangedEventArgs(_DOCUMENT_SIZE, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.Byte[] documentContent
		{
			get { return fieldMap[_DOCUMENT_CONTENT]==System.DBNull.Value || fieldMap[_DOCUMENT_CONTENT] == null ? null : (System.Byte[] )fieldMap[_DOCUMENT_CONTENT];  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_DOCUMENT_CONTENT) )
				{
					oldValue = fieldMap[_DOCUMENT_CONTENT];
					fieldMap[_DOCUMENT_CONTENT] = value;
				}
				else
				{
					fieldMap.Add(_DOCUMENT_CONTENT, value);
					fieldTypeMap.Add(_DOCUMENT_CONTENT, OleDbType.LongVarBinary );
				}
				EventArgs arg = new DataChangedEventArgs(_DOCUMENT_CONTENT, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.String documentVersion
		{
			get { return fieldMap[_DOCUMENT_VERSION]==System.DBNull.Value || fieldMap[_DOCUMENT_VERSION] == null ? null : fieldMap[_DOCUMENT_VERSION].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_DOCUMENT_VERSION) )
				{
					oldValue = fieldMap[_DOCUMENT_VERSION];
					fieldMap[_DOCUMENT_VERSION] = value;
				}
				else
				{
					fieldMap.Add(_DOCUMENT_VERSION, value);
					fieldTypeMap.Add(_DOCUMENT_VERSION, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_DOCUMENT_VERSION, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.Int32? crc
		{
			get { return fieldMap[_CRC]==System.DBNull.Value || fieldMap[_CRC] == null ? null : (System.Int32? )fieldMap[_CRC];  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_CRC) )
				{
					oldValue = fieldMap[_CRC];
					fieldMap[_CRC] = value;
				}
				else
				{
					fieldMap.Add(_CRC, value);
					fieldTypeMap.Add(_CRC, OleDbType.Integer );
				}
				EventArgs arg = new DataChangedEventArgs(_CRC, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public DocumentBean( ):base( _TABLE_NAME )
		{
			if( fieldMap.ContainsKey(_UUID) )
				fieldMap[_UUID] = null;
			else
				fieldMap.Add(_UUID, null );
			if( fieldMap.ContainsKey(_DOCUMENT_NAME) )
				fieldMap[_DOCUMENT_NAME] = null;
			else
				fieldMap.Add(_DOCUMENT_NAME, null );
			if( fieldMap.ContainsKey(_DOCUMENT_DESCRIPTION) )
				fieldMap[_DOCUMENT_DESCRIPTION] = null;
			else
				fieldMap.Add(_DOCUMENT_DESCRIPTION, null );
			if( fieldMap.ContainsKey(_DOCUMENT_TYPE_ID) )
				fieldMap[_DOCUMENT_TYPE_ID] = null;
			else
				fieldMap.Add(_DOCUMENT_TYPE_ID, null );
			if( fieldMap.ContainsKey(_CONTENT_TYPE) )
				fieldMap[_CONTENT_TYPE] = null;
			else
				fieldMap.Add(_CONTENT_TYPE, null );
			if( fieldMap.ContainsKey(_DATE_ADDED) )
				fieldMap[_DATE_ADDED] = null;
			else
				fieldMap.Add(_DATE_ADDED, null );
			if( fieldMap.ContainsKey(_DATE_UPDATED) )
				fieldMap[_DATE_UPDATED] = null;
			else
				fieldMap.Add(_DATE_UPDATED, null );
			if( fieldMap.ContainsKey(_DOCUMENT_SIZE) )
				fieldMap[_DOCUMENT_SIZE] = null;
			else
				fieldMap.Add(_DOCUMENT_SIZE, null );
			if( fieldMap.ContainsKey(_DOCUMENT_CONTENT) )
				fieldMap[_DOCUMENT_CONTENT] = null;
			else
				fieldMap.Add(_DOCUMENT_CONTENT, null );
			if( fieldMap.ContainsKey(_DOCUMENT_VERSION) )
				fieldMap[_DOCUMENT_VERSION] = null;
			else
				fieldMap.Add(_DOCUMENT_VERSION, null );
			if( fieldMap.ContainsKey(_CRC) )
				fieldMap[_CRC] = null;
			else
				fieldMap.Add(_CRC, null );
			initialize();
		}

		public DocumentBean( OleDbDataReader reader ):base( _TABLE_NAME )
		{
			if( fieldMap.ContainsKey(_UUID) )
				fieldMap[_UUID] = reader[_UUID];
			else
				fieldMap.Add(_UUID, reader[_UUID]);
			if( fieldMap.ContainsKey(_DOCUMENT_NAME) )
				fieldMap[_DOCUMENT_NAME] = reader[_DOCUMENT_NAME];
			else
				fieldMap.Add(_DOCUMENT_NAME, reader[_DOCUMENT_NAME]);
			if( fieldMap.ContainsKey(_DOCUMENT_DESCRIPTION) )
				fieldMap[_DOCUMENT_DESCRIPTION] = reader[_DOCUMENT_DESCRIPTION];
			else
				fieldMap.Add(_DOCUMENT_DESCRIPTION, reader[_DOCUMENT_DESCRIPTION]);
			if( fieldMap.ContainsKey(_DOCUMENT_TYPE_ID) )
				fieldMap[_DOCUMENT_TYPE_ID] = reader[_DOCUMENT_TYPE_ID];
			else
				fieldMap.Add(_DOCUMENT_TYPE_ID, reader[_DOCUMENT_TYPE_ID]);
			if( fieldMap.ContainsKey(_CONTENT_TYPE) )
				fieldMap[_CONTENT_TYPE] = reader[_CONTENT_TYPE];
			else
				fieldMap.Add(_CONTENT_TYPE, reader[_CONTENT_TYPE]);
			if( fieldMap.ContainsKey(_DATE_ADDED) )
				fieldMap[_DATE_ADDED] = reader[_DATE_ADDED];
			else
				fieldMap.Add(_DATE_ADDED, reader[_DATE_ADDED]);
			if( fieldMap.ContainsKey(_DATE_UPDATED) )
				fieldMap[_DATE_UPDATED] = reader[_DATE_UPDATED];
			else
				fieldMap.Add(_DATE_UPDATED, reader[_DATE_UPDATED]);
			if( fieldMap.ContainsKey(_DOCUMENT_SIZE) )
				fieldMap[_DOCUMENT_SIZE] = reader[_DOCUMENT_SIZE];
			else
				fieldMap.Add(_DOCUMENT_SIZE, reader[_DOCUMENT_SIZE]);
			if( fieldMap.ContainsKey(_DOCUMENT_CONTENT) )
				fieldMap[_DOCUMENT_CONTENT] = reader[_DOCUMENT_CONTENT];
			else
				fieldMap.Add(_DOCUMENT_CONTENT, reader[_DOCUMENT_CONTENT]);
			if( fieldMap.ContainsKey(_DOCUMENT_VERSION) )
				fieldMap[_DOCUMENT_VERSION] = reader[_DOCUMENT_VERSION];
			else
				fieldMap.Add(_DOCUMENT_VERSION, reader[_DOCUMENT_VERSION]);
			if( fieldMap.ContainsKey(_CRC) )
				fieldMap[_CRC] = reader[_CRC];
			else
				fieldMap.Add(_CRC, reader[_CRC]);
			initialize();
		}

		private void initialize( )
		{
			keys.Add( "UUID" );
		}

		public override void load(  OleDbDataReader reader )
		{
			base.resetDirtyState();
			if( fieldMap.ContainsKey(_UUID) )
				fieldMap[_UUID] = reader[_UUID];
			else
				fieldMap.Add(_UUID, reader[_UUID]);
			if( originalFieldMap.ContainsKey(_UUID) )
				originalFieldMap[_UUID] = reader[_UUID];
			else
				originalFieldMap.Add(_UUID, reader[_UUID]);
			if( fieldMap.ContainsKey(_DOCUMENT_NAME) )
				fieldMap[_DOCUMENT_NAME] = reader[_DOCUMENT_NAME];
			else
				fieldMap.Add(_DOCUMENT_NAME, reader[_DOCUMENT_NAME]);
			if( originalFieldMap.ContainsKey(_DOCUMENT_NAME) )
				originalFieldMap[_DOCUMENT_NAME] = reader[_DOCUMENT_NAME];
			else
				originalFieldMap.Add(_DOCUMENT_NAME, reader[_DOCUMENT_NAME]);
			if( fieldMap.ContainsKey(_DOCUMENT_DESCRIPTION) )
				fieldMap[_DOCUMENT_DESCRIPTION] = reader[_DOCUMENT_DESCRIPTION];
			else
				fieldMap.Add(_DOCUMENT_DESCRIPTION, reader[_DOCUMENT_DESCRIPTION]);
			if( originalFieldMap.ContainsKey(_DOCUMENT_DESCRIPTION) )
				originalFieldMap[_DOCUMENT_DESCRIPTION] = reader[_DOCUMENT_DESCRIPTION];
			else
				originalFieldMap.Add(_DOCUMENT_DESCRIPTION, reader[_DOCUMENT_DESCRIPTION]);
			if( fieldMap.ContainsKey(_DOCUMENT_TYPE_ID) )
				fieldMap[_DOCUMENT_TYPE_ID] = reader[_DOCUMENT_TYPE_ID];
			else
				fieldMap.Add(_DOCUMENT_TYPE_ID, reader[_DOCUMENT_TYPE_ID]);
			if( originalFieldMap.ContainsKey(_DOCUMENT_TYPE_ID) )
				originalFieldMap[_DOCUMENT_TYPE_ID] = reader[_DOCUMENT_TYPE_ID];
			else
				originalFieldMap.Add(_DOCUMENT_TYPE_ID, reader[_DOCUMENT_TYPE_ID]);
			if( fieldMap.ContainsKey(_CONTENT_TYPE) )
				fieldMap[_CONTENT_TYPE] = reader[_CONTENT_TYPE];
			else
				fieldMap.Add(_CONTENT_TYPE, reader[_CONTENT_TYPE]);
			if( originalFieldMap.ContainsKey(_CONTENT_TYPE) )
				originalFieldMap[_CONTENT_TYPE] = reader[_CONTENT_TYPE];
			else
				originalFieldMap.Add(_CONTENT_TYPE, reader[_CONTENT_TYPE]);
			if( fieldMap.ContainsKey(_DATE_ADDED) )
				fieldMap[_DATE_ADDED] = reader[_DATE_ADDED];
			else
				fieldMap.Add(_DATE_ADDED, reader[_DATE_ADDED]);
			if( originalFieldMap.ContainsKey(_DATE_ADDED) )
				originalFieldMap[_DATE_ADDED] = reader[_DATE_ADDED];
			else
				originalFieldMap.Add(_DATE_ADDED, reader[_DATE_ADDED]);
			if( fieldMap.ContainsKey(_DATE_UPDATED) )
				fieldMap[_DATE_UPDATED] = reader[_DATE_UPDATED];
			else
				fieldMap.Add(_DATE_UPDATED, reader[_DATE_UPDATED]);
			if( originalFieldMap.ContainsKey(_DATE_UPDATED) )
				originalFieldMap[_DATE_UPDATED] = reader[_DATE_UPDATED];
			else
				originalFieldMap.Add(_DATE_UPDATED, reader[_DATE_UPDATED]);
			if( fieldMap.ContainsKey(_DOCUMENT_SIZE) )
				fieldMap[_DOCUMENT_SIZE] = reader[_DOCUMENT_SIZE];
			else
				fieldMap.Add(_DOCUMENT_SIZE, reader[_DOCUMENT_SIZE]);
			if( originalFieldMap.ContainsKey(_DOCUMENT_SIZE) )
				originalFieldMap[_DOCUMENT_SIZE] = reader[_DOCUMENT_SIZE];
			else
				originalFieldMap.Add(_DOCUMENT_SIZE, reader[_DOCUMENT_SIZE]);
			if( fieldMap.ContainsKey(_DOCUMENT_CONTENT) )
				fieldMap[_DOCUMENT_CONTENT] = reader[_DOCUMENT_CONTENT];
			else
				fieldMap.Add(_DOCUMENT_CONTENT, reader[_DOCUMENT_CONTENT]);
			if( originalFieldMap.ContainsKey(_DOCUMENT_CONTENT) )
				originalFieldMap[_DOCUMENT_CONTENT] = reader[_DOCUMENT_CONTENT];
			else
				originalFieldMap.Add(_DOCUMENT_CONTENT, reader[_DOCUMENT_CONTENT]);
			if( fieldMap.ContainsKey(_DOCUMENT_VERSION) )
				fieldMap[_DOCUMENT_VERSION] = reader[_DOCUMENT_VERSION];
			else
				fieldMap.Add(_DOCUMENT_VERSION, reader[_DOCUMENT_VERSION]);
			if( originalFieldMap.ContainsKey(_DOCUMENT_VERSION) )
				originalFieldMap[_DOCUMENT_VERSION] = reader[_DOCUMENT_VERSION];
			else
				originalFieldMap.Add(_DOCUMENT_VERSION, reader[_DOCUMENT_VERSION]);
			if( fieldMap.ContainsKey(_CRC) )
				fieldMap[_CRC] = reader[_CRC];
			else
				fieldMap.Add(_CRC, reader[_CRC]);
			if( originalFieldMap.ContainsKey(_CRC) )
				originalFieldMap[_CRC] = reader[_CRC];
			else
				originalFieldMap.Add(_CRC, reader[_CRC]);
		}

		public override void writeStartXML(UTRSXmlWriter xml)
		{
			xml.WriteStartElement(_TABLE_NAME.ToLower());
		}

		public override void writeXML(UTRSXmlWriter xml)
		{
			xml.WriteElementSafeString(_UUID.ToLower(), UUID);
			xml.WriteElementSafeString(_DOCUMENT_NAME.ToLower(), documentName);
			xml.WriteElementSafeString(_DOCUMENT_DESCRIPTION.ToLower(), documentDescription);
			xml.WriteElementSafeString(_DOCUMENT_TYPE_ID.ToLower(), documentTypeId);
			xml.WriteElementSafeString(_CONTENT_TYPE.ToLower(), contentType);
			xml.WriteElementSafeString(_DATE_ADDED.ToLower(), dateAdded);
			xml.WriteElementSafeString(_DATE_UPDATED.ToLower(), dateUpdated);
			xml.WriteElementSafeString(_DOCUMENT_SIZE.ToLower(), documentSize);
			xml.WriteElementSafeString(_DOCUMENT_CONTENT.ToLower(), documentContent);
			xml.WriteElementSafeString(_DOCUMENT_VERSION.ToLower(), documentVersion);
			xml.WriteElementSafeString(_CRC.ToLower(), crc);
		}

		public override void writeEndXML(UTRSXmlWriter xml)
		{
			xml.WriteEndElement();
		}

	}
}
