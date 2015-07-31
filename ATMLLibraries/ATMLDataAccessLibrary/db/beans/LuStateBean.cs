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
	public partial class LuStateBean : BASEBean
	{
		public static readonly System.String _TABLE_NAME = "lu_state";
		public static readonly System.String _STATE_ID = "state_id";
		public static readonly System.String _STATE_NAME = "state_name";
		public static readonly System.String _STATE_CODE = "state_code";
		public static readonly System.String _COUNTRY_CODE = "country_code";
		public static readonly System.String _STATE_FIPS = "state_fips";


		public System.Int32? stateId
		{
			get { return fieldMap[_STATE_ID]==System.DBNull.Value || fieldMap[_STATE_ID] == null ? null : (System.Int32? )fieldMap[_STATE_ID];  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_STATE_ID) )
				{
					oldValue = fieldMap[_STATE_ID];
					fieldMap[_STATE_ID] = value;
				}
				else
				{
					fieldMap.Add(_STATE_ID, value);
					fieldTypeMap.Add(_STATE_ID, OleDbType.Integer );
				}
				EventArgs arg = new DataChangedEventArgs(_STATE_ID, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.String stateName
		{
			get { return fieldMap[_STATE_NAME]==System.DBNull.Value || fieldMap[_STATE_NAME] == null ? null : fieldMap[_STATE_NAME].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_STATE_NAME) )
				{
					oldValue = fieldMap[_STATE_NAME];
					fieldMap[_STATE_NAME] = value;
				}
				else
				{
					fieldMap.Add(_STATE_NAME, value);
					fieldTypeMap.Add(_STATE_NAME, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_STATE_NAME, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.String stateCode
		{
			get { return fieldMap[_STATE_CODE]==System.DBNull.Value || fieldMap[_STATE_CODE] == null ? null : fieldMap[_STATE_CODE].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_STATE_CODE) )
				{
					oldValue = fieldMap[_STATE_CODE];
					fieldMap[_STATE_CODE] = value;
				}
				else
				{
					fieldMap.Add(_STATE_CODE, value);
					fieldTypeMap.Add(_STATE_CODE, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_STATE_CODE, oldValue, value);
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

		public System.String stateFips
		{
			get { return fieldMap[_STATE_FIPS]==System.DBNull.Value || fieldMap[_STATE_FIPS] == null ? null : fieldMap[_STATE_FIPS].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_STATE_FIPS) )
				{
					oldValue = fieldMap[_STATE_FIPS];
					fieldMap[_STATE_FIPS] = value;
				}
				else
				{
					fieldMap.Add(_STATE_FIPS, value);
					fieldTypeMap.Add(_STATE_FIPS, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_STATE_FIPS, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public LuStateBean( ):base( _TABLE_NAME )
		{
			if( fieldMap.ContainsKey(_STATE_ID) )
				fieldMap[_STATE_ID] = null;
			else
				fieldMap.Add(_STATE_ID, null );
			if( fieldMap.ContainsKey(_STATE_NAME) )
				fieldMap[_STATE_NAME] = null;
			else
				fieldMap.Add(_STATE_NAME, null );
			if( fieldMap.ContainsKey(_STATE_CODE) )
				fieldMap[_STATE_CODE] = null;
			else
				fieldMap.Add(_STATE_CODE, null );
			if( fieldMap.ContainsKey(_COUNTRY_CODE) )
				fieldMap[_COUNTRY_CODE] = null;
			else
				fieldMap.Add(_COUNTRY_CODE, null );
			if( fieldMap.ContainsKey(_STATE_FIPS) )
				fieldMap[_STATE_FIPS] = null;
			else
				fieldMap.Add(_STATE_FIPS, null );
			initialize();
		}

		public LuStateBean( OleDbDataReader reader ):base( _TABLE_NAME )
		{
			if( fieldMap.ContainsKey(_STATE_ID) )
				fieldMap[_STATE_ID] = reader[_STATE_ID];
			else
				fieldMap.Add(_STATE_ID, reader[_STATE_ID]);
			if( fieldMap.ContainsKey(_STATE_NAME) )
				fieldMap[_STATE_NAME] = reader[_STATE_NAME];
			else
				fieldMap.Add(_STATE_NAME, reader[_STATE_NAME]);
			if( fieldMap.ContainsKey(_STATE_CODE) )
				fieldMap[_STATE_CODE] = reader[_STATE_CODE];
			else
				fieldMap.Add(_STATE_CODE, reader[_STATE_CODE]);
			if( fieldMap.ContainsKey(_COUNTRY_CODE) )
				fieldMap[_COUNTRY_CODE] = reader[_COUNTRY_CODE];
			else
				fieldMap.Add(_COUNTRY_CODE, reader[_COUNTRY_CODE]);
			if( fieldMap.ContainsKey(_STATE_FIPS) )
				fieldMap[_STATE_FIPS] = reader[_STATE_FIPS];
			else
				fieldMap.Add(_STATE_FIPS, reader[_STATE_FIPS]);
			initialize();
		}

		private void initialize( )
		{
			keys.Add( "state_id" );
		}

		public override void load(  OleDbDataReader reader )
		{
			base.resetDirtyState();
			if( fieldMap.ContainsKey(_STATE_ID) )
				fieldMap[_STATE_ID] = reader[_STATE_ID];
			else
				fieldMap.Add(_STATE_ID, reader[_STATE_ID]);
			if( originalFieldMap.ContainsKey(_STATE_ID) )
				originalFieldMap[_STATE_ID] = reader[_STATE_ID];
			else
				originalFieldMap.Add(_STATE_ID, reader[_STATE_ID]);
			if( fieldMap.ContainsKey(_STATE_NAME) )
				fieldMap[_STATE_NAME] = reader[_STATE_NAME];
			else
				fieldMap.Add(_STATE_NAME, reader[_STATE_NAME]);
			if( originalFieldMap.ContainsKey(_STATE_NAME) )
				originalFieldMap[_STATE_NAME] = reader[_STATE_NAME];
			else
				originalFieldMap.Add(_STATE_NAME, reader[_STATE_NAME]);
			if( fieldMap.ContainsKey(_STATE_CODE) )
				fieldMap[_STATE_CODE] = reader[_STATE_CODE];
			else
				fieldMap.Add(_STATE_CODE, reader[_STATE_CODE]);
			if( originalFieldMap.ContainsKey(_STATE_CODE) )
				originalFieldMap[_STATE_CODE] = reader[_STATE_CODE];
			else
				originalFieldMap.Add(_STATE_CODE, reader[_STATE_CODE]);
			if( fieldMap.ContainsKey(_COUNTRY_CODE) )
				fieldMap[_COUNTRY_CODE] = reader[_COUNTRY_CODE];
			else
				fieldMap.Add(_COUNTRY_CODE, reader[_COUNTRY_CODE]);
			if( originalFieldMap.ContainsKey(_COUNTRY_CODE) )
				originalFieldMap[_COUNTRY_CODE] = reader[_COUNTRY_CODE];
			else
				originalFieldMap.Add(_COUNTRY_CODE, reader[_COUNTRY_CODE]);
			if( fieldMap.ContainsKey(_STATE_FIPS) )
				fieldMap[_STATE_FIPS] = reader[_STATE_FIPS];
			else
				fieldMap.Add(_STATE_FIPS, reader[_STATE_FIPS]);
			if( originalFieldMap.ContainsKey(_STATE_FIPS) )
				originalFieldMap[_STATE_FIPS] = reader[_STATE_FIPS];
			else
				originalFieldMap.Add(_STATE_FIPS, reader[_STATE_FIPS]);
		}

		public override void writeStartXML(UTRSXmlWriter xml)
		{
			xml.WriteStartElement(_TABLE_NAME.ToLower());
		}

		public override void writeXML(UTRSXmlWriter xml)
		{
			xml.WriteElementSafeString(_STATE_ID.ToLower(), stateId);
			xml.WriteElementSafeString(_STATE_NAME.ToLower(), stateName);
			xml.WriteElementSafeString(_STATE_CODE.ToLower(), stateCode);
			xml.WriteElementSafeString(_COUNTRY_CODE.ToLower(), countryCode);
			xml.WriteElementSafeString(_STATE_FIPS.ToLower(), stateFips);
		}

		public override void writeEndXML(UTRSXmlWriter xml)
		{
			xml.WriteEndElement();
		}

	}
}
