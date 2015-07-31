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
	public partial class StandardUnitPrefixBean : BASEBean
	{
		public static readonly System.String _TABLE_NAME = "standard_unit_prefix";
		public static readonly System.String _ID = "ID";
		public static readonly System.String _SYMBOL = "symbol";
		public static readonly System.String _SI_PREFIX = "si_prefix";
		public static readonly System.String _MULTIPLE = "multiple";


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

		public System.String siPrefix
		{
			get { return fieldMap[_SI_PREFIX]==System.DBNull.Value || fieldMap[_SI_PREFIX] == null ? null : fieldMap[_SI_PREFIX].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_SI_PREFIX) )
				{
					oldValue = fieldMap[_SI_PREFIX];
					fieldMap[_SI_PREFIX] = value;
				}
				else
				{
					fieldMap.Add(_SI_PREFIX, value);
					fieldTypeMap.Add(_SI_PREFIX, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_SI_PREFIX, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.Double? multiple
		{
			get { return fieldMap[_MULTIPLE]==System.DBNull.Value || fieldMap[_MULTIPLE] == null ? null : (System.Double? )fieldMap[_MULTIPLE];  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_MULTIPLE) )
				{
					oldValue = fieldMap[_MULTIPLE];
					fieldMap[_MULTIPLE] = value;
				}
				else
				{
					fieldMap.Add(_MULTIPLE, value);
					fieldTypeMap.Add(_MULTIPLE, OleDbType.Numeric );
				}
				EventArgs arg = new DataChangedEventArgs(_MULTIPLE, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public StandardUnitPrefixBean( ):base( _TABLE_NAME )
		{
			if( fieldMap.ContainsKey(_ID) )
				fieldMap[_ID] = null;
			else
				fieldMap.Add(_ID, null );
			if( fieldMap.ContainsKey(_SYMBOL) )
				fieldMap[_SYMBOL] = null;
			else
				fieldMap.Add(_SYMBOL, null );
			if( fieldMap.ContainsKey(_SI_PREFIX) )
				fieldMap[_SI_PREFIX] = null;
			else
				fieldMap.Add(_SI_PREFIX, null );
			if( fieldMap.ContainsKey(_MULTIPLE) )
				fieldMap[_MULTIPLE] = null;
			else
				fieldMap.Add(_MULTIPLE, null );
			initialize();
		}

		public StandardUnitPrefixBean( OleDbDataReader reader ):base( _TABLE_NAME )
		{
			if( fieldMap.ContainsKey(_ID) )
				fieldMap[_ID] = reader[_ID];
			else
				fieldMap.Add(_ID, reader[_ID]);
			if( fieldMap.ContainsKey(_SYMBOL) )
				fieldMap[_SYMBOL] = reader[_SYMBOL];
			else
				fieldMap.Add(_SYMBOL, reader[_SYMBOL]);
			if( fieldMap.ContainsKey(_SI_PREFIX) )
				fieldMap[_SI_PREFIX] = reader[_SI_PREFIX];
			else
				fieldMap.Add(_SI_PREFIX, reader[_SI_PREFIX]);
			if( fieldMap.ContainsKey(_MULTIPLE) )
				fieldMap[_MULTIPLE] = reader[_MULTIPLE];
			else
				fieldMap.Add(_MULTIPLE, reader[_MULTIPLE]);
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
			if( fieldMap.ContainsKey(_SYMBOL) )
				fieldMap[_SYMBOL] = reader[_SYMBOL];
			else
				fieldMap.Add(_SYMBOL, reader[_SYMBOL]);
			if( originalFieldMap.ContainsKey(_SYMBOL) )
				originalFieldMap[_SYMBOL] = reader[_SYMBOL];
			else
				originalFieldMap.Add(_SYMBOL, reader[_SYMBOL]);
			if( fieldMap.ContainsKey(_SI_PREFIX) )
				fieldMap[_SI_PREFIX] = reader[_SI_PREFIX];
			else
				fieldMap.Add(_SI_PREFIX, reader[_SI_PREFIX]);
			if( originalFieldMap.ContainsKey(_SI_PREFIX) )
				originalFieldMap[_SI_PREFIX] = reader[_SI_PREFIX];
			else
				originalFieldMap.Add(_SI_PREFIX, reader[_SI_PREFIX]);
			if( fieldMap.ContainsKey(_MULTIPLE) )
				fieldMap[_MULTIPLE] = reader[_MULTIPLE];
			else
				fieldMap.Add(_MULTIPLE, reader[_MULTIPLE]);
			if( originalFieldMap.ContainsKey(_MULTIPLE) )
				originalFieldMap[_MULTIPLE] = reader[_MULTIPLE];
			else
				originalFieldMap.Add(_MULTIPLE, reader[_MULTIPLE]);
		}

		public override void writeStartXML(UTRSXmlWriter xml)
		{
			xml.WriteStartElement(_TABLE_NAME.ToLower());
		}

		public override void writeXML(UTRSXmlWriter xml)
		{
			xml.WriteElementSafeString(_ID.ToLower(), ID);
			xml.WriteElementSafeString(_SYMBOL.ToLower(), symbol);
			xml.WriteElementSafeString(_SI_PREFIX.ToLower(), siPrefix);
			xml.WriteElementSafeString(_MULTIPLE.ToLower(), multiple);
		}

		public override void writeEndXML(UTRSXmlWriter xml)
		{
			xml.WriteEndElement();
		}

	}
}
