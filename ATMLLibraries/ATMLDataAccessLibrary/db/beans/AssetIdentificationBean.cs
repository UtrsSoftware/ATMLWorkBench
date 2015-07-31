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
	public partial class AssetIdentificationBean : BASEBean
	{
		public static readonly System.String _TABLE_NAME = "asset_identification";
		public static readonly System.String _ID = "ID";
		public static readonly System.String _ASSET_TYPE = "asset_type";
		public static readonly System.String _ASSET_NUMBER = "asset_number";
		public static readonly System.String _UUID = "uuid";


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

		public System.String assetType
		{
			get { return fieldMap[_ASSET_TYPE]==System.DBNull.Value || fieldMap[_ASSET_TYPE] == null ? null : fieldMap[_ASSET_TYPE].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_ASSET_TYPE) )
				{
					oldValue = fieldMap[_ASSET_TYPE];
					fieldMap[_ASSET_TYPE] = value;
				}
				else
				{
					fieldMap.Add(_ASSET_TYPE, value);
					fieldTypeMap.Add(_ASSET_TYPE, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_ASSET_TYPE, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.String assetNumber
		{
			get { return fieldMap[_ASSET_NUMBER]==System.DBNull.Value || fieldMap[_ASSET_NUMBER] == null ? null : fieldMap[_ASSET_NUMBER].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_ASSET_NUMBER) )
				{
					oldValue = fieldMap[_ASSET_NUMBER];
					fieldMap[_ASSET_NUMBER] = value;
				}
				else
				{
					fieldMap.Add(_ASSET_NUMBER, value);
					fieldTypeMap.Add(_ASSET_NUMBER, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_ASSET_NUMBER, oldValue, value);
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

		public AssetIdentificationBean( ):base( _TABLE_NAME )
		{
			if( fieldMap.ContainsKey(_ID) )
				fieldMap[_ID] = null;
			else
				fieldMap.Add(_ID, null );
			if( fieldMap.ContainsKey(_ASSET_TYPE) )
				fieldMap[_ASSET_TYPE] = null;
			else
				fieldMap.Add(_ASSET_TYPE, null );
			if( fieldMap.ContainsKey(_ASSET_NUMBER) )
				fieldMap[_ASSET_NUMBER] = null;
			else
				fieldMap.Add(_ASSET_NUMBER, null );
			if( fieldMap.ContainsKey(_UUID) )
				fieldMap[_UUID] = null;
			else
				fieldMap.Add(_UUID, null );
			initialize();
		}

		public AssetIdentificationBean( OleDbDataReader reader ):base( _TABLE_NAME )
		{
			if( fieldMap.ContainsKey(_ID) )
				fieldMap[_ID] = reader[_ID];
			else
				fieldMap.Add(_ID, reader[_ID]);
			if( fieldMap.ContainsKey(_ASSET_TYPE) )
				fieldMap[_ASSET_TYPE] = reader[_ASSET_TYPE];
			else
				fieldMap.Add(_ASSET_TYPE, reader[_ASSET_TYPE]);
			if( fieldMap.ContainsKey(_ASSET_NUMBER) )
				fieldMap[_ASSET_NUMBER] = reader[_ASSET_NUMBER];
			else
				fieldMap.Add(_ASSET_NUMBER, reader[_ASSET_NUMBER]);
			if( fieldMap.ContainsKey(_UUID) )
				fieldMap[_UUID] = reader[_UUID];
			else
				fieldMap.Add(_UUID, reader[_UUID]);
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
			if( fieldMap.ContainsKey(_ASSET_TYPE) )
				fieldMap[_ASSET_TYPE] = reader[_ASSET_TYPE];
			else
				fieldMap.Add(_ASSET_TYPE, reader[_ASSET_TYPE]);
			if( originalFieldMap.ContainsKey(_ASSET_TYPE) )
				originalFieldMap[_ASSET_TYPE] = reader[_ASSET_TYPE];
			else
				originalFieldMap.Add(_ASSET_TYPE, reader[_ASSET_TYPE]);
			if( fieldMap.ContainsKey(_ASSET_NUMBER) )
				fieldMap[_ASSET_NUMBER] = reader[_ASSET_NUMBER];
			else
				fieldMap.Add(_ASSET_NUMBER, reader[_ASSET_NUMBER]);
			if( originalFieldMap.ContainsKey(_ASSET_NUMBER) )
				originalFieldMap[_ASSET_NUMBER] = reader[_ASSET_NUMBER];
			else
				originalFieldMap.Add(_ASSET_NUMBER, reader[_ASSET_NUMBER]);
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
			xml.WriteElementSafeString(_ID.ToLower(), ID);
			xml.WriteElementSafeString(_ASSET_TYPE.ToLower(), assetType);
			xml.WriteElementSafeString(_ASSET_NUMBER.ToLower(), assetNumber);
			xml.WriteElementSafeString(_UUID.ToLower(), uuid);
		}

		public override void writeEndXML(UTRSXmlWriter xml)
		{
			xml.WriteEndElement();
		}

	}
}
