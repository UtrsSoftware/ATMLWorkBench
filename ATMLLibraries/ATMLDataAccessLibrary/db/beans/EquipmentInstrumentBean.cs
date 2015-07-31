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
	public partial class EquipmentInstrumentBean : BASEBean
	{
		public static readonly System.String _TABLE_NAME = "equipment_instrument";
		public static readonly System.String _EQUIPMENT_UUID = "equipment_uuid";
		public static readonly System.String _INSTRUMENT_UUID = "instrument_uuid";
		public static readonly System.String _ASSET_IDENTIFIER = "asset_identifier";
		public static readonly System.String _QUANTITY = "quantity";


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

		public System.String instrumentUuid
		{
			get { return fieldMap[_INSTRUMENT_UUID]==System.DBNull.Value || fieldMap[_INSTRUMENT_UUID] == null ? null : fieldMap[_INSTRUMENT_UUID].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_INSTRUMENT_UUID) )
				{
					oldValue = fieldMap[_INSTRUMENT_UUID];
					fieldMap[_INSTRUMENT_UUID] = value;
				}
				else
				{
					fieldMap.Add(_INSTRUMENT_UUID, value);
					fieldTypeMap.Add(_INSTRUMENT_UUID, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_INSTRUMENT_UUID, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.String assetIdentifier
		{
			get { return fieldMap[_ASSET_IDENTIFIER]==System.DBNull.Value || fieldMap[_ASSET_IDENTIFIER] == null ? null : fieldMap[_ASSET_IDENTIFIER].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_ASSET_IDENTIFIER) )
				{
					oldValue = fieldMap[_ASSET_IDENTIFIER];
					fieldMap[_ASSET_IDENTIFIER] = value;
				}
				else
				{
					fieldMap.Add(_ASSET_IDENTIFIER, value);
					fieldTypeMap.Add(_ASSET_IDENTIFIER, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_ASSET_IDENTIFIER, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.String quantity
		{
			get { return fieldMap[_QUANTITY]==System.DBNull.Value || fieldMap[_QUANTITY] == null ? null : fieldMap[_QUANTITY].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_QUANTITY) )
				{
					oldValue = fieldMap[_QUANTITY];
					fieldMap[_QUANTITY] = value;
				}
				else
				{
					fieldMap.Add(_QUANTITY, value);
					fieldTypeMap.Add(_QUANTITY, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_QUANTITY, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public EquipmentInstrumentBean( ):base( _TABLE_NAME )
		{
			if( fieldMap.ContainsKey(_EQUIPMENT_UUID) )
				fieldMap[_EQUIPMENT_UUID] = null;
			else
				fieldMap.Add(_EQUIPMENT_UUID, null );
			if( fieldMap.ContainsKey(_INSTRUMENT_UUID) )
				fieldMap[_INSTRUMENT_UUID] = null;
			else
				fieldMap.Add(_INSTRUMENT_UUID, null );
			if( fieldMap.ContainsKey(_ASSET_IDENTIFIER) )
				fieldMap[_ASSET_IDENTIFIER] = null;
			else
				fieldMap.Add(_ASSET_IDENTIFIER, null );
			if( fieldMap.ContainsKey(_QUANTITY) )
				fieldMap[_QUANTITY] = null;
			else
				fieldMap.Add(_QUANTITY, null );
			initialize();
		}

		public EquipmentInstrumentBean( OleDbDataReader reader ):base( _TABLE_NAME )
		{
			if( fieldMap.ContainsKey(_EQUIPMENT_UUID) )
				fieldMap[_EQUIPMENT_UUID] = reader[_EQUIPMENT_UUID];
			else
				fieldMap.Add(_EQUIPMENT_UUID, reader[_EQUIPMENT_UUID]);
			if( fieldMap.ContainsKey(_INSTRUMENT_UUID) )
				fieldMap[_INSTRUMENT_UUID] = reader[_INSTRUMENT_UUID];
			else
				fieldMap.Add(_INSTRUMENT_UUID, reader[_INSTRUMENT_UUID]);
			if( fieldMap.ContainsKey(_ASSET_IDENTIFIER) )
				fieldMap[_ASSET_IDENTIFIER] = reader[_ASSET_IDENTIFIER];
			else
				fieldMap.Add(_ASSET_IDENTIFIER, reader[_ASSET_IDENTIFIER]);
			if( fieldMap.ContainsKey(_QUANTITY) )
				fieldMap[_QUANTITY] = reader[_QUANTITY];
			else
				fieldMap.Add(_QUANTITY, reader[_QUANTITY]);
			initialize();
		}

		private void initialize( )
		{
			keys.Add( "instrument_uuid" );
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
			if( fieldMap.ContainsKey(_INSTRUMENT_UUID) )
				fieldMap[_INSTRUMENT_UUID] = reader[_INSTRUMENT_UUID];
			else
				fieldMap.Add(_INSTRUMENT_UUID, reader[_INSTRUMENT_UUID]);
			if( originalFieldMap.ContainsKey(_INSTRUMENT_UUID) )
				originalFieldMap[_INSTRUMENT_UUID] = reader[_INSTRUMENT_UUID];
			else
				originalFieldMap.Add(_INSTRUMENT_UUID, reader[_INSTRUMENT_UUID]);
			if( fieldMap.ContainsKey(_ASSET_IDENTIFIER) )
				fieldMap[_ASSET_IDENTIFIER] = reader[_ASSET_IDENTIFIER];
			else
				fieldMap.Add(_ASSET_IDENTIFIER, reader[_ASSET_IDENTIFIER]);
			if( originalFieldMap.ContainsKey(_ASSET_IDENTIFIER) )
				originalFieldMap[_ASSET_IDENTIFIER] = reader[_ASSET_IDENTIFIER];
			else
				originalFieldMap.Add(_ASSET_IDENTIFIER, reader[_ASSET_IDENTIFIER]);
			if( fieldMap.ContainsKey(_QUANTITY) )
				fieldMap[_QUANTITY] = reader[_QUANTITY];
			else
				fieldMap.Add(_QUANTITY, reader[_QUANTITY]);
			if( originalFieldMap.ContainsKey(_QUANTITY) )
				originalFieldMap[_QUANTITY] = reader[_QUANTITY];
			else
				originalFieldMap.Add(_QUANTITY, reader[_QUANTITY]);
		}

		public override void writeStartXML(UTRSXmlWriter xml)
		{
			xml.WriteStartElement(_TABLE_NAME.ToLower());
		}

		public override void writeXML(UTRSXmlWriter xml)
		{
			xml.WriteElementSafeString(_EQUIPMENT_UUID.ToLower(), equipmentUuid);
			xml.WriteElementSafeString(_INSTRUMENT_UUID.ToLower(), instrumentUuid);
			xml.WriteElementSafeString(_ASSET_IDENTIFIER.ToLower(), assetIdentifier);
			xml.WriteElementSafeString(_QUANTITY.ToLower(), quantity);
		}

		public override void writeEndXML(UTRSXmlWriter xml)
		{
			xml.WriteEndElement();
		}

	}
}
