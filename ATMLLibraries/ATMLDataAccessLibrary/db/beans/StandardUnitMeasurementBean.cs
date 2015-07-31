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
	public partial class StandardUnitMeasurementBean : BASEBean
	{
		public static readonly System.String _TABLE_NAME = "standard_unit_measurement";
		public static readonly System.String _ID = "ID";
		public static readonly System.String _UNIT = "unit";
		public static readonly System.String _SYMBOL = "symbol";
		public static readonly System.String _NOTES = "notes";
		public static readonly System.String _DEPRECATED = "deprecated";
		public static readonly System.String _LIMIT_LIST = "limit_list";
		public static readonly System.String _ELECTRICAL = "electrical";
		public static readonly System.String _OPTICAL = "optical";
		public static readonly System.String _CHEMICAL = "chemical";
		public static readonly System.String _PREFIX = "prefix";
		public static readonly System.String _MASS = "mass";
		public static readonly System.String _LINEAR = "linear";
		public static readonly System.String _VOLUME = "volume";
		public static readonly System.String _PHYSICAL_TYPE = "physical_type";


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

		public System.String prefix
		{
			get { return fieldMap[_PREFIX]==System.DBNull.Value || fieldMap[_PREFIX] == null ? null : fieldMap[_PREFIX].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_PREFIX) )
				{
					oldValue = fieldMap[_PREFIX];
					fieldMap[_PREFIX] = value;
				}
				else
				{
					fieldMap.Add(_PREFIX, value);
					fieldTypeMap.Add(_PREFIX, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_PREFIX, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.String mass
		{
			get { return fieldMap[_MASS]==System.DBNull.Value || fieldMap[_MASS] == null ? null : fieldMap[_MASS].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_MASS) )
				{
					oldValue = fieldMap[_MASS];
					fieldMap[_MASS] = value;
				}
				else
				{
					fieldMap.Add(_MASS, value);
					fieldTypeMap.Add(_MASS, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_MASS, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.String linear
		{
			get { return fieldMap[_LINEAR]==System.DBNull.Value || fieldMap[_LINEAR] == null ? null : fieldMap[_LINEAR].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_LINEAR) )
				{
					oldValue = fieldMap[_LINEAR];
					fieldMap[_LINEAR] = value;
				}
				else
				{
					fieldMap.Add(_LINEAR, value);
					fieldTypeMap.Add(_LINEAR, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_LINEAR, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.String volume
		{
			get { return fieldMap[_VOLUME]==System.DBNull.Value || fieldMap[_VOLUME] == null ? null : fieldMap[_VOLUME].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_VOLUME) )
				{
					oldValue = fieldMap[_VOLUME];
					fieldMap[_VOLUME] = value;
				}
				else
				{
					fieldMap.Add(_VOLUME, value);
					fieldTypeMap.Add(_VOLUME, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_VOLUME, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.String physicalType
		{
			get { return fieldMap[_PHYSICAL_TYPE]==System.DBNull.Value || fieldMap[_PHYSICAL_TYPE] == null ? null : fieldMap[_PHYSICAL_TYPE].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_PHYSICAL_TYPE) )
				{
					oldValue = fieldMap[_PHYSICAL_TYPE];
					fieldMap[_PHYSICAL_TYPE] = value;
				}
				else
				{
					fieldMap.Add(_PHYSICAL_TYPE, value);
					fieldTypeMap.Add(_PHYSICAL_TYPE, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_PHYSICAL_TYPE, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public StandardUnitMeasurementBean( ):base( _TABLE_NAME )
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
			if( fieldMap.ContainsKey(_PREFIX) )
				fieldMap[_PREFIX] = null;
			else
				fieldMap.Add(_PREFIX, null );
			if( fieldMap.ContainsKey(_MASS) )
				fieldMap[_MASS] = null;
			else
				fieldMap.Add(_MASS, null );
			if( fieldMap.ContainsKey(_LINEAR) )
				fieldMap[_LINEAR] = null;
			else
				fieldMap.Add(_LINEAR, null );
			if( fieldMap.ContainsKey(_VOLUME) )
				fieldMap[_VOLUME] = null;
			else
				fieldMap.Add(_VOLUME, null );
			if( fieldMap.ContainsKey(_PHYSICAL_TYPE) )
				fieldMap[_PHYSICAL_TYPE] = null;
			else
				fieldMap.Add(_PHYSICAL_TYPE, null );
			initialize();
		}

		public StandardUnitMeasurementBean( OleDbDataReader reader ):base( _TABLE_NAME )
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
			if( fieldMap.ContainsKey(_PREFIX) )
				fieldMap[_PREFIX] = reader[_PREFIX];
			else
				fieldMap.Add(_PREFIX, reader[_PREFIX]);
			if( fieldMap.ContainsKey(_MASS) )
				fieldMap[_MASS] = reader[_MASS];
			else
				fieldMap.Add(_MASS, reader[_MASS]);
			if( fieldMap.ContainsKey(_LINEAR) )
				fieldMap[_LINEAR] = reader[_LINEAR];
			else
				fieldMap.Add(_LINEAR, reader[_LINEAR]);
			if( fieldMap.ContainsKey(_VOLUME) )
				fieldMap[_VOLUME] = reader[_VOLUME];
			else
				fieldMap.Add(_VOLUME, reader[_VOLUME]);
			if( fieldMap.ContainsKey(_PHYSICAL_TYPE) )
				fieldMap[_PHYSICAL_TYPE] = reader[_PHYSICAL_TYPE];
			else
				fieldMap.Add(_PHYSICAL_TYPE, reader[_PHYSICAL_TYPE]);
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
			if( fieldMap.ContainsKey(_UNIT) )
				fieldMap[_UNIT] = reader[_UNIT];
			else
				fieldMap.Add(_UNIT, reader[_UNIT]);
			if( originalFieldMap.ContainsKey(_UNIT) )
				originalFieldMap[_UNIT] = reader[_UNIT];
			else
				originalFieldMap.Add(_UNIT, reader[_UNIT]);
			if( fieldMap.ContainsKey(_SYMBOL) )
				fieldMap[_SYMBOL] = reader[_SYMBOL];
			else
				fieldMap.Add(_SYMBOL, reader[_SYMBOL]);
			if( originalFieldMap.ContainsKey(_SYMBOL) )
				originalFieldMap[_SYMBOL] = reader[_SYMBOL];
			else
				originalFieldMap.Add(_SYMBOL, reader[_SYMBOL]);
			if( fieldMap.ContainsKey(_NOTES) )
				fieldMap[_NOTES] = reader[_NOTES];
			else
				fieldMap.Add(_NOTES, reader[_NOTES]);
			if( originalFieldMap.ContainsKey(_NOTES) )
				originalFieldMap[_NOTES] = reader[_NOTES];
			else
				originalFieldMap.Add(_NOTES, reader[_NOTES]);
			if( fieldMap.ContainsKey(_DEPRECATED) )
				fieldMap[_DEPRECATED] = reader[_DEPRECATED];
			else
				fieldMap.Add(_DEPRECATED, reader[_DEPRECATED]);
			if( originalFieldMap.ContainsKey(_DEPRECATED) )
				originalFieldMap[_DEPRECATED] = reader[_DEPRECATED];
			else
				originalFieldMap.Add(_DEPRECATED, reader[_DEPRECATED]);
			if( fieldMap.ContainsKey(_LIMIT_LIST) )
				fieldMap[_LIMIT_LIST] = reader[_LIMIT_LIST];
			else
				fieldMap.Add(_LIMIT_LIST, reader[_LIMIT_LIST]);
			if( originalFieldMap.ContainsKey(_LIMIT_LIST) )
				originalFieldMap[_LIMIT_LIST] = reader[_LIMIT_LIST];
			else
				originalFieldMap.Add(_LIMIT_LIST, reader[_LIMIT_LIST]);
			if( fieldMap.ContainsKey(_ELECTRICAL) )
				fieldMap[_ELECTRICAL] = reader[_ELECTRICAL];
			else
				fieldMap.Add(_ELECTRICAL, reader[_ELECTRICAL]);
			if( originalFieldMap.ContainsKey(_ELECTRICAL) )
				originalFieldMap[_ELECTRICAL] = reader[_ELECTRICAL];
			else
				originalFieldMap.Add(_ELECTRICAL, reader[_ELECTRICAL]);
			if( fieldMap.ContainsKey(_OPTICAL) )
				fieldMap[_OPTICAL] = reader[_OPTICAL];
			else
				fieldMap.Add(_OPTICAL, reader[_OPTICAL]);
			if( originalFieldMap.ContainsKey(_OPTICAL) )
				originalFieldMap[_OPTICAL] = reader[_OPTICAL];
			else
				originalFieldMap.Add(_OPTICAL, reader[_OPTICAL]);
			if( fieldMap.ContainsKey(_CHEMICAL) )
				fieldMap[_CHEMICAL] = reader[_CHEMICAL];
			else
				fieldMap.Add(_CHEMICAL, reader[_CHEMICAL]);
			if( originalFieldMap.ContainsKey(_CHEMICAL) )
				originalFieldMap[_CHEMICAL] = reader[_CHEMICAL];
			else
				originalFieldMap.Add(_CHEMICAL, reader[_CHEMICAL]);
			if( fieldMap.ContainsKey(_PREFIX) )
				fieldMap[_PREFIX] = reader[_PREFIX];
			else
				fieldMap.Add(_PREFIX, reader[_PREFIX]);
			if( originalFieldMap.ContainsKey(_PREFIX) )
				originalFieldMap[_PREFIX] = reader[_PREFIX];
			else
				originalFieldMap.Add(_PREFIX, reader[_PREFIX]);
			if( fieldMap.ContainsKey(_MASS) )
				fieldMap[_MASS] = reader[_MASS];
			else
				fieldMap.Add(_MASS, reader[_MASS]);
			if( originalFieldMap.ContainsKey(_MASS) )
				originalFieldMap[_MASS] = reader[_MASS];
			else
				originalFieldMap.Add(_MASS, reader[_MASS]);
			if( fieldMap.ContainsKey(_LINEAR) )
				fieldMap[_LINEAR] = reader[_LINEAR];
			else
				fieldMap.Add(_LINEAR, reader[_LINEAR]);
			if( originalFieldMap.ContainsKey(_LINEAR) )
				originalFieldMap[_LINEAR] = reader[_LINEAR];
			else
				originalFieldMap.Add(_LINEAR, reader[_LINEAR]);
			if( fieldMap.ContainsKey(_VOLUME) )
				fieldMap[_VOLUME] = reader[_VOLUME];
			else
				fieldMap.Add(_VOLUME, reader[_VOLUME]);
			if( originalFieldMap.ContainsKey(_VOLUME) )
				originalFieldMap[_VOLUME] = reader[_VOLUME];
			else
				originalFieldMap.Add(_VOLUME, reader[_VOLUME]);
			if( fieldMap.ContainsKey(_PHYSICAL_TYPE) )
				fieldMap[_PHYSICAL_TYPE] = reader[_PHYSICAL_TYPE];
			else
				fieldMap.Add(_PHYSICAL_TYPE, reader[_PHYSICAL_TYPE]);
			if( originalFieldMap.ContainsKey(_PHYSICAL_TYPE) )
				originalFieldMap[_PHYSICAL_TYPE] = reader[_PHYSICAL_TYPE];
			else
				originalFieldMap.Add(_PHYSICAL_TYPE, reader[_PHYSICAL_TYPE]);
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
			xml.WriteElementSafeString(_PREFIX.ToLower(), prefix);
			xml.WriteElementSafeString(_MASS.ToLower(), mass);
			xml.WriteElementSafeString(_LINEAR.ToLower(), linear);
			xml.WriteElementSafeString(_VOLUME.ToLower(), volume);
			xml.WriteElementSafeString(_PHYSICAL_TYPE.ToLower(), physicalType);
		}

		public override void writeEndXML(UTRSXmlWriter xml)
		{
			xml.WriteEndElement();
		}

	}
}
