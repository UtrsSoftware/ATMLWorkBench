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
	public partial class LuCountryBean : BASEBean
	{
		public static readonly System.String _TABLE_NAME = "lu_country";
		public static readonly System.String _COUNTRY_ID = "country_id";
		public static readonly System.String _COUNTRY_NAME = "country_name";
		public static readonly System.String _COUNTRY_CODE = "country_code";
		public static readonly System.String _ACTIVE_FLAG = "active_flag";


		public System.Int32? countryId
		{
			get { return fieldMap[_COUNTRY_ID]==System.DBNull.Value || fieldMap[_COUNTRY_ID] == null ? null : (System.Int32? )fieldMap[_COUNTRY_ID];  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_COUNTRY_ID) )
				{
					oldValue = fieldMap[_COUNTRY_ID];
					fieldMap[_COUNTRY_ID] = value;
				}
				else
				{
					fieldMap.Add(_COUNTRY_ID, value);
					fieldTypeMap.Add(_COUNTRY_ID, OleDbType.Integer );
				}
				EventArgs arg = new DataChangedEventArgs(_COUNTRY_ID, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.String countryName
		{
			get { return fieldMap[_COUNTRY_NAME]==System.DBNull.Value || fieldMap[_COUNTRY_NAME] == null ? null : fieldMap[_COUNTRY_NAME].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_COUNTRY_NAME) )
				{
					oldValue = fieldMap[_COUNTRY_NAME];
					fieldMap[_COUNTRY_NAME] = value;
				}
				else
				{
					fieldMap.Add(_COUNTRY_NAME, value);
					fieldTypeMap.Add(_COUNTRY_NAME, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_COUNTRY_NAME, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.String countryCode
		{
			get { return fieldMap[_COUNTRY_CODE]==System.DBNull.Value || fieldMap[_COUNTRY_CODE] == null ? null : fieldMap[_COUNTRY_CODE].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_COUNTRY_CODE) )
				{
					oldValue = fieldMap[_COUNTRY_CODE];
					fieldMap[_COUNTRY_CODE] = value;
				}
				else
				{
					fieldMap.Add(_COUNTRY_CODE, value);
					fieldTypeMap.Add(_COUNTRY_CODE, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_COUNTRY_CODE, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.String activeFlag
		{
			get { return fieldMap[_ACTIVE_FLAG]==System.DBNull.Value || fieldMap[_ACTIVE_FLAG] == null ? null : fieldMap[_ACTIVE_FLAG].ToString();  }
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
					fieldTypeMap.Add(_ACTIVE_FLAG, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_ACTIVE_FLAG, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public LuCountryBean( ):base( _TABLE_NAME )
		{
			if( fieldMap.ContainsKey(_COUNTRY_ID) )
				fieldMap[_COUNTRY_ID] = null;
			else
				fieldMap.Add(_COUNTRY_ID, null );
			if( fieldMap.ContainsKey(_COUNTRY_NAME) )
				fieldMap[_COUNTRY_NAME] = null;
			else
				fieldMap.Add(_COUNTRY_NAME, null );
			if( fieldMap.ContainsKey(_COUNTRY_CODE) )
				fieldMap[_COUNTRY_CODE] = null;
			else
				fieldMap.Add(_COUNTRY_CODE, null );
			if( fieldMap.ContainsKey(_ACTIVE_FLAG) )
				fieldMap[_ACTIVE_FLAG] = null;
			else
				fieldMap.Add(_ACTIVE_FLAG, null );
			initialize();
		}

		public LuCountryBean( OleDbDataReader reader ):base( _TABLE_NAME )
		{
			if( fieldMap.ContainsKey(_COUNTRY_ID) )
				fieldMap[_COUNTRY_ID] = reader[_COUNTRY_ID];
			else
				fieldMap.Add(_COUNTRY_ID, reader[_COUNTRY_ID]);
			if( fieldMap.ContainsKey(_COUNTRY_NAME) )
				fieldMap[_COUNTRY_NAME] = reader[_COUNTRY_NAME];
			else
				fieldMap.Add(_COUNTRY_NAME, reader[_COUNTRY_NAME]);
			if( fieldMap.ContainsKey(_COUNTRY_CODE) )
				fieldMap[_COUNTRY_CODE] = reader[_COUNTRY_CODE];
			else
				fieldMap.Add(_COUNTRY_CODE, reader[_COUNTRY_CODE]);
			if( fieldMap.ContainsKey(_ACTIVE_FLAG) )
				fieldMap[_ACTIVE_FLAG] = reader[_ACTIVE_FLAG];
			else
				fieldMap.Add(_ACTIVE_FLAG, reader[_ACTIVE_FLAG]);
			initialize();
		}

		private void initialize( )
		{
			keys.Add( "country_id" );
		}

		public override void load(  OleDbDataReader reader )
		{
			base.resetDirtyState();
			if( fieldMap.ContainsKey(_COUNTRY_ID) )
				fieldMap[_COUNTRY_ID] = reader[_COUNTRY_ID];
			else
				fieldMap.Add(_COUNTRY_ID, reader[_COUNTRY_ID]);
			if( originalFieldMap.ContainsKey(_COUNTRY_ID) )
				originalFieldMap[_COUNTRY_ID] = reader[_COUNTRY_ID];
			else
				originalFieldMap.Add(_COUNTRY_ID, reader[_COUNTRY_ID]);
			if( fieldMap.ContainsKey(_COUNTRY_NAME) )
				fieldMap[_COUNTRY_NAME] = reader[_COUNTRY_NAME];
			else
				fieldMap.Add(_COUNTRY_NAME, reader[_COUNTRY_NAME]);
			if( originalFieldMap.ContainsKey(_COUNTRY_NAME) )
				originalFieldMap[_COUNTRY_NAME] = reader[_COUNTRY_NAME];
			else
				originalFieldMap.Add(_COUNTRY_NAME, reader[_COUNTRY_NAME]);
			if( fieldMap.ContainsKey(_COUNTRY_CODE) )
				fieldMap[_COUNTRY_CODE] = reader[_COUNTRY_CODE];
			else
				fieldMap.Add(_COUNTRY_CODE, reader[_COUNTRY_CODE]);
			if( originalFieldMap.ContainsKey(_COUNTRY_CODE) )
				originalFieldMap[_COUNTRY_CODE] = reader[_COUNTRY_CODE];
			else
				originalFieldMap.Add(_COUNTRY_CODE, reader[_COUNTRY_CODE]);
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
			xml.WriteElementSafeString(_COUNTRY_ID.ToLower(), countryId);
			xml.WriteElementSafeString(_COUNTRY_NAME.ToLower(), countryName);
			xml.WriteElementSafeString(_COUNTRY_CODE.ToLower(), countryCode);
			xml.WriteElementSafeString(_ACTIVE_FLAG.ToLower(), activeFlag);
		}

		public override void writeEndXML(UTRSXmlWriter xml)
		{
			xml.WriteEndElement();
		}

	}
}
