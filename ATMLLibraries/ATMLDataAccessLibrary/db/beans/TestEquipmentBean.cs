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
	public partial class TestEquipmentBean : BASEBean
	{
		public static readonly System.String _TABLE_NAME = "test_equipment";
		public static readonly System.String _EQUIPMENT_UUID = "equipment_uuid";
		public static readonly System.String _PART_NUMBER = "part_number";
		public static readonly System.String _STATION_TYPE = "station_type";
		public static readonly System.String _ATML = "atml";


		public System.String equipmentUuid
		{
			get { return fieldMap[_EQUIPMENT_UUID]==System.DBNull.Value || fieldMap[_EQUIPMENT_UUID] == null ? null : fieldMap[_EQUIPMENT_UUID].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_EQUIPMENT_UUID) )
				{
					oldValue = fieldMap[_EQUIPMENT_UUID];
					fieldMap[_EQUIPMENT_UUID] = value;
				}
				else
				{
					fieldMap.Add(_EQUIPMENT_UUID, value);
					fieldTypeMap.Add(_EQUIPMENT_UUID, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_EQUIPMENT_UUID, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.String partNumber
		{
			get { return fieldMap[_PART_NUMBER]==System.DBNull.Value || fieldMap[_PART_NUMBER] == null ? null : fieldMap[_PART_NUMBER].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_PART_NUMBER) )
				{
					oldValue = fieldMap[_PART_NUMBER];
					fieldMap[_PART_NUMBER] = value;
				}
				else
				{
					fieldMap.Add(_PART_NUMBER, value);
					fieldTypeMap.Add(_PART_NUMBER, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_PART_NUMBER, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.String stationType
		{
			get { return fieldMap[_STATION_TYPE]==System.DBNull.Value || fieldMap[_STATION_TYPE] == null ? null : fieldMap[_STATION_TYPE].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_STATION_TYPE) )
				{
					oldValue = fieldMap[_STATION_TYPE];
					fieldMap[_STATION_TYPE] = value;
				}
				else
				{
					fieldMap.Add(_STATION_TYPE, value);
					fieldTypeMap.Add(_STATION_TYPE, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_STATION_TYPE, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.String atml
		{
			get { return fieldMap[_ATML]==System.DBNull.Value || fieldMap[_ATML] == null ? null : fieldMap[_ATML].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_ATML) )
				{
					oldValue = fieldMap[_ATML];
					fieldMap[_ATML] = value;
				}
				else
				{
					fieldMap.Add(_ATML, value);
					fieldTypeMap.Add(_ATML, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_ATML, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public TestEquipmentBean( ):base( _TABLE_NAME )
		{
			if( fieldMap.ContainsKey(_EQUIPMENT_UUID) )
				fieldMap[_EQUIPMENT_UUID] = null;
			else
				fieldMap.Add(_EQUIPMENT_UUID, null );
			if( fieldMap.ContainsKey(_PART_NUMBER) )
				fieldMap[_PART_NUMBER] = null;
			else
				fieldMap.Add(_PART_NUMBER, null );
			if( fieldMap.ContainsKey(_STATION_TYPE) )
				fieldMap[_STATION_TYPE] = null;
			else
				fieldMap.Add(_STATION_TYPE, null );
			if( fieldMap.ContainsKey(_ATML) )
				fieldMap[_ATML] = null;
			else
				fieldMap.Add(_ATML, null );
			initialize();
		}

		public TestEquipmentBean( OleDbDataReader reader ):base( _TABLE_NAME )
		{
			if( fieldMap.ContainsKey(_EQUIPMENT_UUID) )
				fieldMap[_EQUIPMENT_UUID] = reader[_EQUIPMENT_UUID];
			else
				fieldMap.Add(_EQUIPMENT_UUID, reader[_EQUIPMENT_UUID]);
			if( fieldMap.ContainsKey(_PART_NUMBER) )
				fieldMap[_PART_NUMBER] = reader[_PART_NUMBER];
			else
				fieldMap.Add(_PART_NUMBER, reader[_PART_NUMBER]);
			if( fieldMap.ContainsKey(_STATION_TYPE) )
				fieldMap[_STATION_TYPE] = reader[_STATION_TYPE];
			else
				fieldMap.Add(_STATION_TYPE, reader[_STATION_TYPE]);
			if( fieldMap.ContainsKey(_ATML) )
				fieldMap[_ATML] = reader[_ATML];
			else
				fieldMap.Add(_ATML, reader[_ATML]);
			initialize();
		}

		private void initialize( )
		{
			keys.Add( "equipment_uuid" );
		}

		public override void load(  OleDbDataReader reader )
		{
			base.resetDirtyState();
			if( fieldMap.ContainsKey(_EQUIPMENT_UUID) )
				fieldMap[_EQUIPMENT_UUID] = reader[_EQUIPMENT_UUID];
			else
				fieldMap.Add(_EQUIPMENT_UUID, reader[_EQUIPMENT_UUID]);
			if( originalFieldMap.ContainsKey(_EQUIPMENT_UUID) )
				originalFieldMap[_EQUIPMENT_UUID] = reader[_EQUIPMENT_UUID];
			else
				originalFieldMap.Add(_EQUIPMENT_UUID, reader[_EQUIPMENT_UUID]);
			if( fieldMap.ContainsKey(_PART_NUMBER) )
				fieldMap[_PART_NUMBER] = reader[_PART_NUMBER];
			else
				fieldMap.Add(_PART_NUMBER, reader[_PART_NUMBER]);
			if( originalFieldMap.ContainsKey(_PART_NUMBER) )
				originalFieldMap[_PART_NUMBER] = reader[_PART_NUMBER];
			else
				originalFieldMap.Add(_PART_NUMBER, reader[_PART_NUMBER]);
			if( fieldMap.ContainsKey(_STATION_TYPE) )
				fieldMap[_STATION_TYPE] = reader[_STATION_TYPE];
			else
				fieldMap.Add(_STATION_TYPE, reader[_STATION_TYPE]);
			if( originalFieldMap.ContainsKey(_STATION_TYPE) )
				originalFieldMap[_STATION_TYPE] = reader[_STATION_TYPE];
			else
				originalFieldMap.Add(_STATION_TYPE, reader[_STATION_TYPE]);
			if( fieldMap.ContainsKey(_ATML) )
				fieldMap[_ATML] = reader[_ATML];
			else
				fieldMap.Add(_ATML, reader[_ATML]);
			if( originalFieldMap.ContainsKey(_ATML) )
				originalFieldMap[_ATML] = reader[_ATML];
			else
				originalFieldMap.Add(_ATML, reader[_ATML]);
		}

		public override void writeStartXML(UTRSXmlWriter xml)
		{
			xml.WriteStartElement(_TABLE_NAME.ToLower());
		}

		public override void writeXML(UTRSXmlWriter xml)
		{
			xml.WriteElementSafeString(_EQUIPMENT_UUID.ToLower(), equipmentUuid);
			xml.WriteElementSafeString(_PART_NUMBER.ToLower(), partNumber);
			xml.WriteElementSafeString(_STATION_TYPE.ToLower(), stationType);
			xml.WriteElementSafeString(_ATML.ToLower(), atml);
		}

		public override void writeEndXML(UTRSXmlWriter xml)
		{
			xml.WriteEndElement();
		}

	}
}
