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
	public partial class SignalAttributeMasterBean : BASEBean
	{
		public static readonly System.String _TABLE_NAME = "signal_attribute_master";
		public static readonly System.String _SIGNAL_ATTRIBUTE_ID = "signal_attribute_id";
		public static readonly System.String _SIGNAL_ID = "signal_id";
		public static readonly System.String _ATTRIBUTE_NAME = "attribute_name";
		public static readonly System.String _DEFAULT_VALUE = "default_value";
		public static readonly System.String _TYPE = "type";
		public static readonly System.String _FIXED_VALUE = "fixed_value";


		public System.Int32? signalAttributeId
		{
			get { return fieldMap[_SIGNAL_ATTRIBUTE_ID]==System.DBNull.Value || fieldMap[_SIGNAL_ATTRIBUTE_ID] == null ? null : (System.Int32? )fieldMap[_SIGNAL_ATTRIBUTE_ID];  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_SIGNAL_ATTRIBUTE_ID) )
				{
					oldValue = fieldMap[_SIGNAL_ATTRIBUTE_ID];
					fieldMap[_SIGNAL_ATTRIBUTE_ID] = value;
				}
				else
				{
					fieldMap.Add(_SIGNAL_ATTRIBUTE_ID, value);
					fieldTypeMap.Add(_SIGNAL_ATTRIBUTE_ID, OleDbType.Integer );
				}
				EventArgs arg = new DataChangedEventArgs(_SIGNAL_ATTRIBUTE_ID, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.Int32? signalId
		{
			get { return fieldMap[_SIGNAL_ID]==System.DBNull.Value || fieldMap[_SIGNAL_ID] == null ? null : (System.Int32? )fieldMap[_SIGNAL_ID];  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_SIGNAL_ID) )
				{
					oldValue = fieldMap[_SIGNAL_ID];
					fieldMap[_SIGNAL_ID] = value;
				}
				else
				{
					fieldMap.Add(_SIGNAL_ID, value);
					fieldTypeMap.Add(_SIGNAL_ID, OleDbType.Integer );
				}
				EventArgs arg = new DataChangedEventArgs(_SIGNAL_ID, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.String attributeName
		{
			get { return fieldMap[_ATTRIBUTE_NAME]==System.DBNull.Value || fieldMap[_ATTRIBUTE_NAME] == null ? null : fieldMap[_ATTRIBUTE_NAME].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_ATTRIBUTE_NAME) )
				{
					oldValue = fieldMap[_ATTRIBUTE_NAME];
					fieldMap[_ATTRIBUTE_NAME] = value;
				}
				else
				{
					fieldMap.Add(_ATTRIBUTE_NAME, value);
					fieldTypeMap.Add(_ATTRIBUTE_NAME, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_ATTRIBUTE_NAME, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.String defaultValue
		{
			get { return fieldMap[_DEFAULT_VALUE]==System.DBNull.Value || fieldMap[_DEFAULT_VALUE] == null ? null : fieldMap[_DEFAULT_VALUE].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_DEFAULT_VALUE) )
				{
					oldValue = fieldMap[_DEFAULT_VALUE];
					fieldMap[_DEFAULT_VALUE] = value;
				}
				else
				{
					fieldMap.Add(_DEFAULT_VALUE, value);
					fieldTypeMap.Add(_DEFAULT_VALUE, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_DEFAULT_VALUE, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.String type
		{
			get { return fieldMap[_TYPE]==System.DBNull.Value || fieldMap[_TYPE] == null ? null : fieldMap[_TYPE].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_TYPE) )
				{
					oldValue = fieldMap[_TYPE];
					fieldMap[_TYPE] = value;
				}
				else
				{
					fieldMap.Add(_TYPE, value);
					fieldTypeMap.Add(_TYPE, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_TYPE, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.String fixedValue
		{
			get { return fieldMap[_FIXED_VALUE]==System.DBNull.Value || fieldMap[_FIXED_VALUE] == null ? null : fieldMap[_FIXED_VALUE].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_FIXED_VALUE) )
				{
					oldValue = fieldMap[_FIXED_VALUE];
					fieldMap[_FIXED_VALUE] = value;
				}
				else
				{
					fieldMap.Add(_FIXED_VALUE, value);
					fieldTypeMap.Add(_FIXED_VALUE, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_FIXED_VALUE, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public SignalAttributeMasterBean( ):base( _TABLE_NAME )
		{
			if( fieldMap.ContainsKey(_SIGNAL_ATTRIBUTE_ID) )
				fieldMap[_SIGNAL_ATTRIBUTE_ID] = null;
			else
				fieldMap.Add(_SIGNAL_ATTRIBUTE_ID, null );
			if( fieldMap.ContainsKey(_SIGNAL_ID) )
				fieldMap[_SIGNAL_ID] = null;
			else
				fieldMap.Add(_SIGNAL_ID, null );
			if( fieldMap.ContainsKey(_ATTRIBUTE_NAME) )
				fieldMap[_ATTRIBUTE_NAME] = null;
			else
				fieldMap.Add(_ATTRIBUTE_NAME, null );
			if( fieldMap.ContainsKey(_DEFAULT_VALUE) )
				fieldMap[_DEFAULT_VALUE] = null;
			else
				fieldMap.Add(_DEFAULT_VALUE, null );
			if( fieldMap.ContainsKey(_TYPE) )
				fieldMap[_TYPE] = null;
			else
				fieldMap.Add(_TYPE, null );
			if( fieldMap.ContainsKey(_FIXED_VALUE) )
				fieldMap[_FIXED_VALUE] = null;
			else
				fieldMap.Add(_FIXED_VALUE, null );
			initialize();
		}

		public SignalAttributeMasterBean( OleDbDataReader reader ):base( _TABLE_NAME )
		{
			if( fieldMap.ContainsKey(_SIGNAL_ATTRIBUTE_ID) )
				fieldMap[_SIGNAL_ATTRIBUTE_ID] = reader[_SIGNAL_ATTRIBUTE_ID];
			else
				fieldMap.Add(_SIGNAL_ATTRIBUTE_ID, reader[_SIGNAL_ATTRIBUTE_ID]);
			if( fieldMap.ContainsKey(_SIGNAL_ID) )
				fieldMap[_SIGNAL_ID] = reader[_SIGNAL_ID];
			else
				fieldMap.Add(_SIGNAL_ID, reader[_SIGNAL_ID]);
			if( fieldMap.ContainsKey(_ATTRIBUTE_NAME) )
				fieldMap[_ATTRIBUTE_NAME] = reader[_ATTRIBUTE_NAME];
			else
				fieldMap.Add(_ATTRIBUTE_NAME, reader[_ATTRIBUTE_NAME]);
			if( fieldMap.ContainsKey(_DEFAULT_VALUE) )
				fieldMap[_DEFAULT_VALUE] = reader[_DEFAULT_VALUE];
			else
				fieldMap.Add(_DEFAULT_VALUE, reader[_DEFAULT_VALUE]);
			if( fieldMap.ContainsKey(_TYPE) )
				fieldMap[_TYPE] = reader[_TYPE];
			else
				fieldMap.Add(_TYPE, reader[_TYPE]);
			if( fieldMap.ContainsKey(_FIXED_VALUE) )
				fieldMap[_FIXED_VALUE] = reader[_FIXED_VALUE];
			else
				fieldMap.Add(_FIXED_VALUE, reader[_FIXED_VALUE]);
			initialize();
		}

		private void initialize( )
		{
			keys.Add( "signal_attribute_id" );
		}

		public override void load(  OleDbDataReader reader )
		{
			base.resetDirtyState();
			if( fieldMap.ContainsKey(_SIGNAL_ATTRIBUTE_ID) )
				fieldMap[_SIGNAL_ATTRIBUTE_ID] = reader[_SIGNAL_ATTRIBUTE_ID];
			else
				fieldMap.Add(_SIGNAL_ATTRIBUTE_ID, reader[_SIGNAL_ATTRIBUTE_ID]);
			if( originalFieldMap.ContainsKey(_SIGNAL_ATTRIBUTE_ID) )
				originalFieldMap[_SIGNAL_ATTRIBUTE_ID] = reader[_SIGNAL_ATTRIBUTE_ID];
			else
				originalFieldMap.Add(_SIGNAL_ATTRIBUTE_ID, reader[_SIGNAL_ATTRIBUTE_ID]);
			if( fieldMap.ContainsKey(_SIGNAL_ID) )
				fieldMap[_SIGNAL_ID] = reader[_SIGNAL_ID];
			else
				fieldMap.Add(_SIGNAL_ID, reader[_SIGNAL_ID]);
			if( originalFieldMap.ContainsKey(_SIGNAL_ID) )
				originalFieldMap[_SIGNAL_ID] = reader[_SIGNAL_ID];
			else
				originalFieldMap.Add(_SIGNAL_ID, reader[_SIGNAL_ID]);
			if( fieldMap.ContainsKey(_ATTRIBUTE_NAME) )
				fieldMap[_ATTRIBUTE_NAME] = reader[_ATTRIBUTE_NAME];
			else
				fieldMap.Add(_ATTRIBUTE_NAME, reader[_ATTRIBUTE_NAME]);
			if( originalFieldMap.ContainsKey(_ATTRIBUTE_NAME) )
				originalFieldMap[_ATTRIBUTE_NAME] = reader[_ATTRIBUTE_NAME];
			else
				originalFieldMap.Add(_ATTRIBUTE_NAME, reader[_ATTRIBUTE_NAME]);
			if( fieldMap.ContainsKey(_DEFAULT_VALUE) )
				fieldMap[_DEFAULT_VALUE] = reader[_DEFAULT_VALUE];
			else
				fieldMap.Add(_DEFAULT_VALUE, reader[_DEFAULT_VALUE]);
			if( originalFieldMap.ContainsKey(_DEFAULT_VALUE) )
				originalFieldMap[_DEFAULT_VALUE] = reader[_DEFAULT_VALUE];
			else
				originalFieldMap.Add(_DEFAULT_VALUE, reader[_DEFAULT_VALUE]);
			if( fieldMap.ContainsKey(_TYPE) )
				fieldMap[_TYPE] = reader[_TYPE];
			else
				fieldMap.Add(_TYPE, reader[_TYPE]);
			if( originalFieldMap.ContainsKey(_TYPE) )
				originalFieldMap[_TYPE] = reader[_TYPE];
			else
				originalFieldMap.Add(_TYPE, reader[_TYPE]);
			if( fieldMap.ContainsKey(_FIXED_VALUE) )
				fieldMap[_FIXED_VALUE] = reader[_FIXED_VALUE];
			else
				fieldMap.Add(_FIXED_VALUE, reader[_FIXED_VALUE]);
			if( originalFieldMap.ContainsKey(_FIXED_VALUE) )
				originalFieldMap[_FIXED_VALUE] = reader[_FIXED_VALUE];
			else
				originalFieldMap.Add(_FIXED_VALUE, reader[_FIXED_VALUE]);
		}

		public override void writeStartXML(UTRSXmlWriter xml)
		{
			xml.WriteStartElement(_TABLE_NAME.ToLower());
		}

		public override void writeXML(UTRSXmlWriter xml)
		{
			xml.WriteElementSafeString(_SIGNAL_ATTRIBUTE_ID.ToLower(), signalAttributeId);
			xml.WriteElementSafeString(_SIGNAL_ID.ToLower(), signalId);
			xml.WriteElementSafeString(_ATTRIBUTE_NAME.ToLower(), attributeName);
			xml.WriteElementSafeString(_DEFAULT_VALUE.ToLower(), defaultValue);
			xml.WriteElementSafeString(_TYPE.ToLower(), type);
			xml.WriteElementSafeString(_FIXED_VALUE.ToLower(), fixedValue);
		}

		public override void writeEndXML(UTRSXmlWriter xml)
		{
			xml.WriteEndElement();
		}

	}
}
