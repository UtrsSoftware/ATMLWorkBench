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
	public class StatndardUnitMeasurmentBean : BASEBean
	{
		public static readonly System.String _TABLE_NAME = "statndard_unit_measurment";
		public static readonly System.String _ID = "ID";
		public static readonly System.String _UNIT = "unit";
		public static readonly System.String _SYMBOL = "symbol";
		public static readonly System.String _NOTES = "notes";
		public static readonly System.String _DEPRECATED = "deprecated";
		public static readonly System.String _LIMIT_LIST = "limit_list";
		public static readonly System.String _ELECTRICAL = "electrical";
		public static readonly System.String _OPTICAL = "optical";
		public static readonly System.String _CHEMICAL = "chemical";


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

		public System.String unit
		{
			get { return fieldMap[_UNIT]==System.DBNull.Value || fieldMap[_UNIT] == null ? null : fieldMap[_UNIT].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_UNIT) )
				{
					oldValue = fieldMap[_UNIT];
					fieldMap[_UNIT] = value;
				}
				else
				{
					fieldMap.Add(_UNIT, value);
					fieldTypeMap.Add(_UNIT, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_UNIT, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.String symbol
		{
			get { return fieldMap[_SYMBOL]==System.DBNull.Value || fieldMap[_SYMBOL] == null ? null : fieldMap[_SYMBOL].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_SYMBOL) )
				{
					oldValue = fieldMap[_SYMBOL];
					fieldMap[_SYMBOL] = value;
				}
				else
				{
					fieldMap.Add(_SYMBOL, value);
					fieldTypeMap.Add(_SYMBOL, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_SYMBOL, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.String notes
		{
			get { return fieldMap[_NOTES]==System.DBNull.Value || fieldMap[_NOTES] == null ? null : fieldMap[_NOTES].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_NOTES) )
				{
					oldValue = fieldMap[_NOTES];
					fieldMap[_NOTES] = value;
				}
				else
				{
					fieldMap.Add(_NOTES, value);
					fieldTypeMap.Add(_NOTES, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_NOTES, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.String deprecated
		{
			get { return fieldMap[_DEPRECATED]==System.DBNull.Value || fieldMap[_DEPRECATED] == null ? null : fieldMap[_DEPRECATED].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_DEPRECATED) )
				{
					oldValue = fieldMap[_DEPRECATED];
					fieldMap[_DEPRECATED] = value;
				}
				else
				{
					fieldMap.Add(_DEPRECATED, value);
					fieldTypeMap.Add(_DEPRECATED, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_DEPRECATED, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.String limitList
		{
			get { return fieldMap[_LIMIT_LIST]==System.DBNull.Value || fieldMap[_LIMIT_LIST] == null ? null : fieldMap[_LIMIT_LIST].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_LIMIT_LIST) )
				{
					oldValue = fieldMap[_LIMIT_LIST];
					fieldMap[_LIMIT_LIST] = value;
				}
				else
				{
					fieldMap.Add(_LIMIT_LIST, value);
					fieldTypeMap.Add(_LIMIT_LIST, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_LIMIT_LIST, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.String electrical
		{
			get { return fieldMap[_ELECTRICAL]==System.DBNull.Value || fieldMap[_ELECTRICAL] == null ? null : fieldMap[_ELECTRICAL].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_ELECTRICAL) )
				{
					oldValue = fieldMap[_ELECTRICAL];
					fieldMap[_ELECTRICAL] = value;
				}
				else
				{
					fieldMap.Add(_ELECTRICAL, value);
					fieldTypeMap.Add(_ELECTRICAL, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_ELECTRICAL, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.String optical
		{
			get { return fieldMap[_OPTICAL]==System.DBNull.Value || fieldMap[_OPTICAL] == null ? null : fieldMap[_OPTICAL].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_OPTICAL) )
				{
					oldValue = fieldMap[_OPTICAL];
					fieldMap[_OPTICAL] = value;
				}
				else
				{
					fieldMap.Add(_OPTICAL, value);
					fieldTypeMap.Add(_OPTICAL, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_OPTICAL, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.String chemical
		{
			get { return fieldMap[_CHEMICAL]==System.DBNull.Value || fieldMap[_CHEMICAL] == null ? null : fieldMap[_CHEMICAL].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_CHEMICAL) )
				{
					oldValue = fieldMap[_CHEMICAL];
					fieldMap[_CHEMICAL] = value;
				}
				else
				{
					fieldMap.Add(_CHEMICAL, value);
					fieldTypeMap.Add(_CHEMICAL, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_CHEMICAL, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public StatndardUnitMeasurmentBean( ):base( _TABLE_NAME )
		{
			if( fieldMap.ContainsKey(_ID) )
				fieldMap[_ID] = null;
			else
				fieldMap.Add(_ID, null );
			if( fieldMap.ContainsKey(_UNIT) )
				fieldMap[_UNIT] = null;
			else
				fieldMap.Add(_UNIT, null );
			if( fieldMap.ContainsKey(_SYMBOL) )
				fieldMap[_SYMBOL] = null;
			else
				fieldMap.Add(_SYMBOL, null );
			if( fieldMap.ContainsKey(_NOTES) )
				fieldMap[_NOTES] = null;
			else
				fieldMap.Add(_NOTES, null );
			if( fieldMap.ContainsKey(_DEPRECATED) )
				fieldMap[_DEPRECATED] = null;
			else
				fieldMap.Add(_DEPRECATED, null );
			if( fieldMap.ContainsKey(_LIMIT_LIST) )
				fieldMap[_LIMIT_LIST] = null;
			else
				fieldMap.Add(_LIMIT_LIST, null );
			if( fieldMap.ContainsKey(_ELECTRICAL) )
				fieldMap[_ELECTRICAL] = null;
			else
				fieldMap.Add(_ELECTRICAL, null );
			if( fieldMap.ContainsKey(_OPTICAL) )
				fieldMap[_OPTICAL] = null;
			else
				fieldMap.Add(_OPTICAL, null );
			if( fieldMap.ContainsKey(_CHEMICAL) )
				fieldMap[_CHEMICAL] = null;
			else
				fieldMap.Add(_CHEMICAL, null );
			initialize();
		}

		public StatndardUnitMeasurmentBean( OleDbDataReader reader ):base( _TABLE_NAME )
		{
			if( fieldMap.ContainsKey(_ID) )
				fieldMap[_ID] = reader[_ID];
			else
				fieldMap.Add(_ID, reader[_ID]);
			if( fieldMap.ContainsKey(_UNIT) )
				fieldMap[_UNIT] = reader[_UNIT];
			else
				fieldMap.Add(_UNIT, reader[_UNIT]);
			if( fieldMap.ContainsKey(_SYMBOL) )
				fieldMap[_SYMBOL] = reader[_SYMBOL];
			else
				fieldMap.Add(_SYMBOL, reader[_SYMBOL]);
			if( fieldMap.ContainsKey(_NOTES) )
				fieldMap[_NOTES] = reader[_NOTES];
			else
				fieldMap.Add(_NOTES, reader[_NOTES]);
			if( fieldMap.ContainsKey(_DEPRECATED) )
				fieldMap[_DEPRECATED] = reader[_DEPRECATED];
			else
				fieldMap.Add(_DEPRECATED, reader[_DEPRECATED]);
			if( fieldMap.ContainsKey(_LIMIT_LIST) )
				fieldMap[_LIMIT_LIST] = reader[_LIMIT_LIST];
			else
				fieldMap.Add(_LIMIT_LIST, reader[_LIMIT_LIST]);
			if( fieldMap.ContainsKey(_ELECTRICAL) )
				fieldMap[_ELECTRICAL] = reader[_ELECTRICAL];
			else
				fieldMap.Add(_ELECTRICAL, reader[_ELECTRICAL]);
			if( fieldMap.ContainsKey(_OPTICAL) )
				fieldMap[_OPTICAL] = reader[_OPTICAL];
			else
				fieldMap.Add(_OPTICAL, reader[_OPTICAL]);
			if( fieldMap.ContainsKey(_CHEMICAL) )
				fieldMap[_CHEMICAL] = reader[_CHEMICAL];
			else
				fieldMap.Add(_CHEMICAL, reader[_CHEMICAL]);
			initialize();
		}

		private void initialize( )
		{
			keys.Add( "ID" );
		}

		public override void load(  OleDbDataReader reader )
		{
			if( fieldMap.ContainsKey(_ID) )
				fieldMap[_ID] = reader[_ID];
			else
				fieldMap.Add(_ID, reader[_ID]);
			if( fieldMap.ContainsKey(_UNIT) )
				fieldMap[_UNIT] = reader[_UNIT];
			else
				fieldMap.Add(_UNIT, reader[_UNIT]);
			if( fieldMap.ContainsKey(_SYMBOL) )
				fieldMap[_SYMBOL] = reader[_SYMBOL];
			else
				fieldMap.Add(_SYMBOL, reader[_SYMBOL]);
			if( fieldMap.ContainsKey(_NOTES) )
				fieldMap[_NOTES] = reader[_NOTES];
			else
				fieldMap.Add(_NOTES, reader[_NOTES]);
			if( fieldMap.ContainsKey(_DEPRECATED) )
				fieldMap[_DEPRECATED] = reader[_DEPRECATED];
			else
				fieldMap.Add(_DEPRECATED, reader[_DEPRECATED]);
			if( fieldMap.ContainsKey(_LIMIT_LIST) )
				fieldMap[_LIMIT_LIST] = reader[_LIMIT_LIST];
			else
				fieldMap.Add(_LIMIT_LIST, reader[_LIMIT_LIST]);
			if( fieldMap.ContainsKey(_ELECTRICAL) )
				fieldMap[_ELECTRICAL] = reader[_ELECTRICAL];
			else
				fieldMap.Add(_ELECTRICAL, reader[_ELECTRICAL]);
			if( fieldMap.ContainsKey(_OPTICAL) )
				fieldMap[_OPTICAL] = reader[_OPTICAL];
			else
				fieldMap.Add(_OPTICAL, reader[_OPTICAL]);
			if( fieldMap.ContainsKey(_CHEMICAL) )
				fieldMap[_CHEMICAL] = reader[_CHEMICAL];
			else
				fieldMap.Add(_CHEMICAL, reader[_CHEMICAL]);
		}

		public override void writeStartXML(UTRSXmlWriter xml)
		{
			xml.WriteStartElement(_TABLE_NAME.ToLower());
		}

		public override void writeXML(UTRSXmlWriter xml)
		{
			xml.WriteElementSafeString(_ID.ToLower(), ID);
			xml.WriteElementSafeString(_UNIT.ToLower(), unit);
			xml.WriteElementSafeString(_SYMBOL.ToLower(), symbol);
			xml.WriteElementSafeString(_NOTES.ToLower(), notes);
			xml.WriteElementSafeString(_DEPRECATED.ToLower(), deprecated);
			xml.WriteElementSafeString(_LIMIT_LIST.ToLower(), limitList);
			xml.WriteElementSafeString(_ELECTRICAL.ToLower(), electrical);
			xml.WriteElementSafeString(_OPTICAL.ToLower(), optical);
			xml.WriteElementSafeString(_CHEMICAL.ToLower(), chemical);
		}

		public override void writeEndXML(UTRSXmlWriter xml)
		{
			xml.WriteEndElement();
		}

	}
}
