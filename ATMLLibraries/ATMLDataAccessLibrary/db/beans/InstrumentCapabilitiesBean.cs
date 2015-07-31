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
	public partial class InstrumentCapabilitiesBean : BASEBean
	{
		public static readonly System.String _TABLE_NAME = "instrument_capabilities";
		public static readonly System.String _INSTRUMENT_UUID = "instrument_uuid";
		public static readonly System.String _ATTRIBUTE = "attribute";
		public static readonly System.String _SIGNAL_NAME = "signal_name";
		public static readonly System.String _LOW_VALUE = "low_value";
		public static readonly System.String _LOW_UNIT = "low_unit";
		public static readonly System.String _HIGH_VALUE = "high_value";
		public static readonly System.String _HIGH_UNIT = "high_unit";
		public static readonly System.String _ERR_VALUE = "err_value";
		public static readonly System.String _ERR_UNIT = "err_unit";
		public static readonly System.String _RES_VALUE = "res_value";
		public static readonly System.String _RES_UNIT = "res_unit";
		public static readonly System.String _LOAD_VALUE = "load_value";
		public static readonly System.String _LOAD_UNIT = "load_unit";
		public static readonly System.String _SIGNAL_TYPE = "signal_type";
		public static readonly System.String _SIGNAL_NAMESPACE = "signal_namespace";
		public static readonly System.String _CAPABILITY_NAME = "capability_name";
		public static readonly System.String _TSF_UUID = "tsf_uuid";


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

		public System.String attribute
		{
			get { return fieldMap[_ATTRIBUTE]==System.DBNull.Value || fieldMap[_ATTRIBUTE] == null ? null : fieldMap[_ATTRIBUTE].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_ATTRIBUTE) )
				{
					oldValue = fieldMap[_ATTRIBUTE];
					fieldMap[_ATTRIBUTE] = value;
				}
				else
				{
					fieldMap.Add(_ATTRIBUTE, value);
					fieldTypeMap.Add(_ATTRIBUTE, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_ATTRIBUTE, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.String signalName
		{
			get { return fieldMap[_SIGNAL_NAME]==System.DBNull.Value || fieldMap[_SIGNAL_NAME] == null ? null : fieldMap[_SIGNAL_NAME].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_SIGNAL_NAME) )
				{
					oldValue = fieldMap[_SIGNAL_NAME];
					fieldMap[_SIGNAL_NAME] = value;
				}
				else
				{
					fieldMap.Add(_SIGNAL_NAME, value);
					fieldTypeMap.Add(_SIGNAL_NAME, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_SIGNAL_NAME, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.Double? lowValue
		{
			get { return fieldMap[_LOW_VALUE]==System.DBNull.Value || fieldMap[_LOW_VALUE] == null ? null : (System.Double? )fieldMap[_LOW_VALUE];  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_LOW_VALUE) )
				{
					oldValue = fieldMap[_LOW_VALUE];
					fieldMap[_LOW_VALUE] = value;
				}
				else
				{
					fieldMap.Add(_LOW_VALUE, value);
					fieldTypeMap.Add(_LOW_VALUE, OleDbType.Numeric );
				}
				EventArgs arg = new DataChangedEventArgs(_LOW_VALUE, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.String lowUnit
		{
			get { return fieldMap[_LOW_UNIT]==System.DBNull.Value || fieldMap[_LOW_UNIT] == null ? null : fieldMap[_LOW_UNIT].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_LOW_UNIT) )
				{
					oldValue = fieldMap[_LOW_UNIT];
					fieldMap[_LOW_UNIT] = value;
				}
				else
				{
					fieldMap.Add(_LOW_UNIT, value);
					fieldTypeMap.Add(_LOW_UNIT, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_LOW_UNIT, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.Double? highValue
		{
			get { return fieldMap[_HIGH_VALUE]==System.DBNull.Value || fieldMap[_HIGH_VALUE] == null ? null : (System.Double? )fieldMap[_HIGH_VALUE];  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_HIGH_VALUE) )
				{
					oldValue = fieldMap[_HIGH_VALUE];
					fieldMap[_HIGH_VALUE] = value;
				}
				else
				{
					fieldMap.Add(_HIGH_VALUE, value);
					fieldTypeMap.Add(_HIGH_VALUE, OleDbType.Numeric );
				}
				EventArgs arg = new DataChangedEventArgs(_HIGH_VALUE, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.String highUnit
		{
			get { return fieldMap[_HIGH_UNIT]==System.DBNull.Value || fieldMap[_HIGH_UNIT] == null ? null : fieldMap[_HIGH_UNIT].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_HIGH_UNIT) )
				{
					oldValue = fieldMap[_HIGH_UNIT];
					fieldMap[_HIGH_UNIT] = value;
				}
				else
				{
					fieldMap.Add(_HIGH_UNIT, value);
					fieldTypeMap.Add(_HIGH_UNIT, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_HIGH_UNIT, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.Double? errValue
		{
			get { return fieldMap[_ERR_VALUE]==System.DBNull.Value || fieldMap[_ERR_VALUE] == null ? null : (System.Double? )fieldMap[_ERR_VALUE];  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_ERR_VALUE) )
				{
					oldValue = fieldMap[_ERR_VALUE];
					fieldMap[_ERR_VALUE] = value;
				}
				else
				{
					fieldMap.Add(_ERR_VALUE, value);
					fieldTypeMap.Add(_ERR_VALUE, OleDbType.Numeric );
				}
				EventArgs arg = new DataChangedEventArgs(_ERR_VALUE, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.String errUnit
		{
			get { return fieldMap[_ERR_UNIT]==System.DBNull.Value || fieldMap[_ERR_UNIT] == null ? null : fieldMap[_ERR_UNIT].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_ERR_UNIT) )
				{
					oldValue = fieldMap[_ERR_UNIT];
					fieldMap[_ERR_UNIT] = value;
				}
				else
				{
					fieldMap.Add(_ERR_UNIT, value);
					fieldTypeMap.Add(_ERR_UNIT, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_ERR_UNIT, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.Double? resValue
		{
			get { return fieldMap[_RES_VALUE]==System.DBNull.Value || fieldMap[_RES_VALUE] == null ? null : (System.Double? )fieldMap[_RES_VALUE];  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_RES_VALUE) )
				{
					oldValue = fieldMap[_RES_VALUE];
					fieldMap[_RES_VALUE] = value;
				}
				else
				{
					fieldMap.Add(_RES_VALUE, value);
					fieldTypeMap.Add(_RES_VALUE, OleDbType.Numeric );
				}
				EventArgs arg = new DataChangedEventArgs(_RES_VALUE, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.String resUnit
		{
			get { return fieldMap[_RES_UNIT]==System.DBNull.Value || fieldMap[_RES_UNIT] == null ? null : fieldMap[_RES_UNIT].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_RES_UNIT) )
				{
					oldValue = fieldMap[_RES_UNIT];
					fieldMap[_RES_UNIT] = value;
				}
				else
				{
					fieldMap.Add(_RES_UNIT, value);
					fieldTypeMap.Add(_RES_UNIT, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_RES_UNIT, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.Double? loadValue
		{
			get { return fieldMap[_LOAD_VALUE]==System.DBNull.Value || fieldMap[_LOAD_VALUE] == null ? null : (System.Double? )fieldMap[_LOAD_VALUE];  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_LOAD_VALUE) )
				{
					oldValue = fieldMap[_LOAD_VALUE];
					fieldMap[_LOAD_VALUE] = value;
				}
				else
				{
					fieldMap.Add(_LOAD_VALUE, value);
					fieldTypeMap.Add(_LOAD_VALUE, OleDbType.Numeric );
				}
				EventArgs arg = new DataChangedEventArgs(_LOAD_VALUE, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.String loadUnit
		{
			get { return fieldMap[_LOAD_UNIT]==System.DBNull.Value || fieldMap[_LOAD_UNIT] == null ? null : fieldMap[_LOAD_UNIT].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_LOAD_UNIT) )
				{
					oldValue = fieldMap[_LOAD_UNIT];
					fieldMap[_LOAD_UNIT] = value;
				}
				else
				{
					fieldMap.Add(_LOAD_UNIT, value);
					fieldTypeMap.Add(_LOAD_UNIT, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_LOAD_UNIT, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.String signalType
		{
			get { return fieldMap[_SIGNAL_TYPE]==System.DBNull.Value || fieldMap[_SIGNAL_TYPE] == null ? null : fieldMap[_SIGNAL_TYPE].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_SIGNAL_TYPE) )
				{
					oldValue = fieldMap[_SIGNAL_TYPE];
					fieldMap[_SIGNAL_TYPE] = value;
				}
				else
				{
					fieldMap.Add(_SIGNAL_TYPE, value);
					fieldTypeMap.Add(_SIGNAL_TYPE, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_SIGNAL_TYPE, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.String signalNamespace
		{
			get { return fieldMap[_SIGNAL_NAMESPACE]==System.DBNull.Value || fieldMap[_SIGNAL_NAMESPACE] == null ? null : fieldMap[_SIGNAL_NAMESPACE].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_SIGNAL_NAMESPACE) )
				{
					oldValue = fieldMap[_SIGNAL_NAMESPACE];
					fieldMap[_SIGNAL_NAMESPACE] = value;
				}
				else
				{
					fieldMap.Add(_SIGNAL_NAMESPACE, value);
					fieldTypeMap.Add(_SIGNAL_NAMESPACE, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_SIGNAL_NAMESPACE, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.String capabilityName
		{
			get { return fieldMap[_CAPABILITY_NAME]==System.DBNull.Value || fieldMap[_CAPABILITY_NAME] == null ? null : fieldMap[_CAPABILITY_NAME].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_CAPABILITY_NAME) )
				{
					oldValue = fieldMap[_CAPABILITY_NAME];
					fieldMap[_CAPABILITY_NAME] = value;
				}
				else
				{
					fieldMap.Add(_CAPABILITY_NAME, value);
					fieldTypeMap.Add(_CAPABILITY_NAME, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_CAPABILITY_NAME, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.Guid? tsfUuid
		{
			get { return fieldMap[_TSF_UUID]==System.DBNull.Value || fieldMap[_TSF_UUID] == null ? null : (System.Guid? )fieldMap[_TSF_UUID];  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_TSF_UUID) )
				{
					oldValue = fieldMap[_TSF_UUID];
					fieldMap[_TSF_UUID] = value;
				}
				else
				{
					fieldMap.Add(_TSF_UUID, value);
					fieldTypeMap.Add(_TSF_UUID, OleDbType.Guid );
				}
				EventArgs arg = new DataChangedEventArgs(_TSF_UUID, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public InstrumentCapabilitiesBean( ):base( _TABLE_NAME )
		{
			if( fieldMap.ContainsKey(_INSTRUMENT_UUID) )
				fieldMap[_INSTRUMENT_UUID] = null;
			else
				fieldMap.Add(_INSTRUMENT_UUID, null );
			if( fieldMap.ContainsKey(_ATTRIBUTE) )
				fieldMap[_ATTRIBUTE] = null;
			else
				fieldMap.Add(_ATTRIBUTE, null );
			if( fieldMap.ContainsKey(_SIGNAL_NAME) )
				fieldMap[_SIGNAL_NAME] = null;
			else
				fieldMap.Add(_SIGNAL_NAME, null );
			if( fieldMap.ContainsKey(_LOW_VALUE) )
				fieldMap[_LOW_VALUE] = null;
			else
				fieldMap.Add(_LOW_VALUE, null );
			if( fieldMap.ContainsKey(_LOW_UNIT) )
				fieldMap[_LOW_UNIT] = null;
			else
				fieldMap.Add(_LOW_UNIT, null );
			if( fieldMap.ContainsKey(_HIGH_VALUE) )
				fieldMap[_HIGH_VALUE] = null;
			else
				fieldMap.Add(_HIGH_VALUE, null );
			if( fieldMap.ContainsKey(_HIGH_UNIT) )
				fieldMap[_HIGH_UNIT] = null;
			else
				fieldMap.Add(_HIGH_UNIT, null );
			if( fieldMap.ContainsKey(_ERR_VALUE) )
				fieldMap[_ERR_VALUE] = null;
			else
				fieldMap.Add(_ERR_VALUE, null );
			if( fieldMap.ContainsKey(_ERR_UNIT) )
				fieldMap[_ERR_UNIT] = null;
			else
				fieldMap.Add(_ERR_UNIT, null );
			if( fieldMap.ContainsKey(_RES_VALUE) )
				fieldMap[_RES_VALUE] = null;
			else
				fieldMap.Add(_RES_VALUE, null );
			if( fieldMap.ContainsKey(_RES_UNIT) )
				fieldMap[_RES_UNIT] = null;
			else
				fieldMap.Add(_RES_UNIT, null );
			if( fieldMap.ContainsKey(_LOAD_VALUE) )
				fieldMap[_LOAD_VALUE] = null;
			else
				fieldMap.Add(_LOAD_VALUE, null );
			if( fieldMap.ContainsKey(_LOAD_UNIT) )
				fieldMap[_LOAD_UNIT] = null;
			else
				fieldMap.Add(_LOAD_UNIT, null );
			if( fieldMap.ContainsKey(_SIGNAL_TYPE) )
				fieldMap[_SIGNAL_TYPE] = null;
			else
				fieldMap.Add(_SIGNAL_TYPE, null );
			if( fieldMap.ContainsKey(_SIGNAL_NAMESPACE) )
				fieldMap[_SIGNAL_NAMESPACE] = null;
			else
				fieldMap.Add(_SIGNAL_NAMESPACE, null );
			if( fieldMap.ContainsKey(_CAPABILITY_NAME) )
				fieldMap[_CAPABILITY_NAME] = null;
			else
				fieldMap.Add(_CAPABILITY_NAME, null );
			if( fieldMap.ContainsKey(_TSF_UUID) )
				fieldMap[_TSF_UUID] = null;
			else
				fieldMap.Add(_TSF_UUID, null );
			initialize();
		}

		public InstrumentCapabilitiesBean( OleDbDataReader reader ):base( _TABLE_NAME )
		{
			if( fieldMap.ContainsKey(_INSTRUMENT_UUID) )
				fieldMap[_INSTRUMENT_UUID] = reader[_INSTRUMENT_UUID];
			else
				fieldMap.Add(_INSTRUMENT_UUID, reader[_INSTRUMENT_UUID]);
			if( fieldMap.ContainsKey(_ATTRIBUTE) )
				fieldMap[_ATTRIBUTE] = reader[_ATTRIBUTE];
			else
				fieldMap.Add(_ATTRIBUTE, reader[_ATTRIBUTE]);
			if( fieldMap.ContainsKey(_SIGNAL_NAME) )
				fieldMap[_SIGNAL_NAME] = reader[_SIGNAL_NAME];
			else
				fieldMap.Add(_SIGNAL_NAME, reader[_SIGNAL_NAME]);
			if( fieldMap.ContainsKey(_LOW_VALUE) )
				fieldMap[_LOW_VALUE] = reader[_LOW_VALUE];
			else
				fieldMap.Add(_LOW_VALUE, reader[_LOW_VALUE]);
			if( fieldMap.ContainsKey(_LOW_UNIT) )
				fieldMap[_LOW_UNIT] = reader[_LOW_UNIT];
			else
				fieldMap.Add(_LOW_UNIT, reader[_LOW_UNIT]);
			if( fieldMap.ContainsKey(_HIGH_VALUE) )
				fieldMap[_HIGH_VALUE] = reader[_HIGH_VALUE];
			else
				fieldMap.Add(_HIGH_VALUE, reader[_HIGH_VALUE]);
			if( fieldMap.ContainsKey(_HIGH_UNIT) )
				fieldMap[_HIGH_UNIT] = reader[_HIGH_UNIT];
			else
				fieldMap.Add(_HIGH_UNIT, reader[_HIGH_UNIT]);
			if( fieldMap.ContainsKey(_ERR_VALUE) )
				fieldMap[_ERR_VALUE] = reader[_ERR_VALUE];
			else
				fieldMap.Add(_ERR_VALUE, reader[_ERR_VALUE]);
			if( fieldMap.ContainsKey(_ERR_UNIT) )
				fieldMap[_ERR_UNIT] = reader[_ERR_UNIT];
			else
				fieldMap.Add(_ERR_UNIT, reader[_ERR_UNIT]);
			if( fieldMap.ContainsKey(_RES_VALUE) )
				fieldMap[_RES_VALUE] = reader[_RES_VALUE];
			else
				fieldMap.Add(_RES_VALUE, reader[_RES_VALUE]);
			if( fieldMap.ContainsKey(_RES_UNIT) )
				fieldMap[_RES_UNIT] = reader[_RES_UNIT];
			else
				fieldMap.Add(_RES_UNIT, reader[_RES_UNIT]);
			if( fieldMap.ContainsKey(_LOAD_VALUE) )
				fieldMap[_LOAD_VALUE] = reader[_LOAD_VALUE];
			else
				fieldMap.Add(_LOAD_VALUE, reader[_LOAD_VALUE]);
			if( fieldMap.ContainsKey(_LOAD_UNIT) )
				fieldMap[_LOAD_UNIT] = reader[_LOAD_UNIT];
			else
				fieldMap.Add(_LOAD_UNIT, reader[_LOAD_UNIT]);
			if( fieldMap.ContainsKey(_SIGNAL_TYPE) )
				fieldMap[_SIGNAL_TYPE] = reader[_SIGNAL_TYPE];
			else
				fieldMap.Add(_SIGNAL_TYPE, reader[_SIGNAL_TYPE]);
			if( fieldMap.ContainsKey(_SIGNAL_NAMESPACE) )
				fieldMap[_SIGNAL_NAMESPACE] = reader[_SIGNAL_NAMESPACE];
			else
				fieldMap.Add(_SIGNAL_NAMESPACE, reader[_SIGNAL_NAMESPACE]);
			if( fieldMap.ContainsKey(_CAPABILITY_NAME) )
				fieldMap[_CAPABILITY_NAME] = reader[_CAPABILITY_NAME];
			else
				fieldMap.Add(_CAPABILITY_NAME, reader[_CAPABILITY_NAME]);
			if( fieldMap.ContainsKey(_TSF_UUID) )
				fieldMap[_TSF_UUID] = reader[_TSF_UUID];
			else
				fieldMap.Add(_TSF_UUID, reader[_TSF_UUID]);
			initialize();
		}

		private void initialize( )
		{
			keys.Add( "attribute" );
			keys.Add( "signal_name" );
			keys.Add( "capability_name" );
			keys.Add( "instrument_uuid" );
		}

		public override void load(  OleDbDataReader reader )
		{
			base.resetDirtyState();
			if( fieldMap.ContainsKey(_INSTRUMENT_UUID) )
				fieldMap[_INSTRUMENT_UUID] = reader[_INSTRUMENT_UUID];
			else
				fieldMap.Add(_INSTRUMENT_UUID, reader[_INSTRUMENT_UUID]);
			if( originalFieldMap.ContainsKey(_INSTRUMENT_UUID) )
				originalFieldMap[_INSTRUMENT_UUID] = reader[_INSTRUMENT_UUID];
			else
				originalFieldMap.Add(_INSTRUMENT_UUID, reader[_INSTRUMENT_UUID]);
			if( fieldMap.ContainsKey(_ATTRIBUTE) )
				fieldMap[_ATTRIBUTE] = reader[_ATTRIBUTE];
			else
				fieldMap.Add(_ATTRIBUTE, reader[_ATTRIBUTE]);
			if( originalFieldMap.ContainsKey(_ATTRIBUTE) )
				originalFieldMap[_ATTRIBUTE] = reader[_ATTRIBUTE];
			else
				originalFieldMap.Add(_ATTRIBUTE, reader[_ATTRIBUTE]);
			if( fieldMap.ContainsKey(_SIGNAL_NAME) )
				fieldMap[_SIGNAL_NAME] = reader[_SIGNAL_NAME];
			else
				fieldMap.Add(_SIGNAL_NAME, reader[_SIGNAL_NAME]);
			if( originalFieldMap.ContainsKey(_SIGNAL_NAME) )
				originalFieldMap[_SIGNAL_NAME] = reader[_SIGNAL_NAME];
			else
				originalFieldMap.Add(_SIGNAL_NAME, reader[_SIGNAL_NAME]);
			if( fieldMap.ContainsKey(_LOW_VALUE) )
				fieldMap[_LOW_VALUE] = reader[_LOW_VALUE];
			else
				fieldMap.Add(_LOW_VALUE, reader[_LOW_VALUE]);
			if( originalFieldMap.ContainsKey(_LOW_VALUE) )
				originalFieldMap[_LOW_VALUE] = reader[_LOW_VALUE];
			else
				originalFieldMap.Add(_LOW_VALUE, reader[_LOW_VALUE]);
			if( fieldMap.ContainsKey(_LOW_UNIT) )
				fieldMap[_LOW_UNIT] = reader[_LOW_UNIT];
			else
				fieldMap.Add(_LOW_UNIT, reader[_LOW_UNIT]);
			if( originalFieldMap.ContainsKey(_LOW_UNIT) )
				originalFieldMap[_LOW_UNIT] = reader[_LOW_UNIT];
			else
				originalFieldMap.Add(_LOW_UNIT, reader[_LOW_UNIT]);
			if( fieldMap.ContainsKey(_HIGH_VALUE) )
				fieldMap[_HIGH_VALUE] = reader[_HIGH_VALUE];
			else
				fieldMap.Add(_HIGH_VALUE, reader[_HIGH_VALUE]);
			if( originalFieldMap.ContainsKey(_HIGH_VALUE) )
				originalFieldMap[_HIGH_VALUE] = reader[_HIGH_VALUE];
			else
				originalFieldMap.Add(_HIGH_VALUE, reader[_HIGH_VALUE]);
			if( fieldMap.ContainsKey(_HIGH_UNIT) )
				fieldMap[_HIGH_UNIT] = reader[_HIGH_UNIT];
			else
				fieldMap.Add(_HIGH_UNIT, reader[_HIGH_UNIT]);
			if( originalFieldMap.ContainsKey(_HIGH_UNIT) )
				originalFieldMap[_HIGH_UNIT] = reader[_HIGH_UNIT];
			else
				originalFieldMap.Add(_HIGH_UNIT, reader[_HIGH_UNIT]);
			if( fieldMap.ContainsKey(_ERR_VALUE) )
				fieldMap[_ERR_VALUE] = reader[_ERR_VALUE];
			else
				fieldMap.Add(_ERR_VALUE, reader[_ERR_VALUE]);
			if( originalFieldMap.ContainsKey(_ERR_VALUE) )
				originalFieldMap[_ERR_VALUE] = reader[_ERR_VALUE];
			else
				originalFieldMap.Add(_ERR_VALUE, reader[_ERR_VALUE]);
			if( fieldMap.ContainsKey(_ERR_UNIT) )
				fieldMap[_ERR_UNIT] = reader[_ERR_UNIT];
			else
				fieldMap.Add(_ERR_UNIT, reader[_ERR_UNIT]);
			if( originalFieldMap.ContainsKey(_ERR_UNIT) )
				originalFieldMap[_ERR_UNIT] = reader[_ERR_UNIT];
			else
				originalFieldMap.Add(_ERR_UNIT, reader[_ERR_UNIT]);
			if( fieldMap.ContainsKey(_RES_VALUE) )
				fieldMap[_RES_VALUE] = reader[_RES_VALUE];
			else
				fieldMap.Add(_RES_VALUE, reader[_RES_VALUE]);
			if( originalFieldMap.ContainsKey(_RES_VALUE) )
				originalFieldMap[_RES_VALUE] = reader[_RES_VALUE];
			else
				originalFieldMap.Add(_RES_VALUE, reader[_RES_VALUE]);
			if( fieldMap.ContainsKey(_RES_UNIT) )
				fieldMap[_RES_UNIT] = reader[_RES_UNIT];
			else
				fieldMap.Add(_RES_UNIT, reader[_RES_UNIT]);
			if( originalFieldMap.ContainsKey(_RES_UNIT) )
				originalFieldMap[_RES_UNIT] = reader[_RES_UNIT];
			else
				originalFieldMap.Add(_RES_UNIT, reader[_RES_UNIT]);
			if( fieldMap.ContainsKey(_LOAD_VALUE) )
				fieldMap[_LOAD_VALUE] = reader[_LOAD_VALUE];
			else
				fieldMap.Add(_LOAD_VALUE, reader[_LOAD_VALUE]);
			if( originalFieldMap.ContainsKey(_LOAD_VALUE) )
				originalFieldMap[_LOAD_VALUE] = reader[_LOAD_VALUE];
			else
				originalFieldMap.Add(_LOAD_VALUE, reader[_LOAD_VALUE]);
			if( fieldMap.ContainsKey(_LOAD_UNIT) )
				fieldMap[_LOAD_UNIT] = reader[_LOAD_UNIT];
			else
				fieldMap.Add(_LOAD_UNIT, reader[_LOAD_UNIT]);
			if( originalFieldMap.ContainsKey(_LOAD_UNIT) )
				originalFieldMap[_LOAD_UNIT] = reader[_LOAD_UNIT];
			else
				originalFieldMap.Add(_LOAD_UNIT, reader[_LOAD_UNIT]);
			if( fieldMap.ContainsKey(_SIGNAL_TYPE) )
				fieldMap[_SIGNAL_TYPE] = reader[_SIGNAL_TYPE];
			else
				fieldMap.Add(_SIGNAL_TYPE, reader[_SIGNAL_TYPE]);
			if( originalFieldMap.ContainsKey(_SIGNAL_TYPE) )
				originalFieldMap[_SIGNAL_TYPE] = reader[_SIGNAL_TYPE];
			else
				originalFieldMap.Add(_SIGNAL_TYPE, reader[_SIGNAL_TYPE]);
			if( fieldMap.ContainsKey(_SIGNAL_NAMESPACE) )
				fieldMap[_SIGNAL_NAMESPACE] = reader[_SIGNAL_NAMESPACE];
			else
				fieldMap.Add(_SIGNAL_NAMESPACE, reader[_SIGNAL_NAMESPACE]);
			if( originalFieldMap.ContainsKey(_SIGNAL_NAMESPACE) )
				originalFieldMap[_SIGNAL_NAMESPACE] = reader[_SIGNAL_NAMESPACE];
			else
				originalFieldMap.Add(_SIGNAL_NAMESPACE, reader[_SIGNAL_NAMESPACE]);
			if( fieldMap.ContainsKey(_CAPABILITY_NAME) )
				fieldMap[_CAPABILITY_NAME] = reader[_CAPABILITY_NAME];
			else
				fieldMap.Add(_CAPABILITY_NAME, reader[_CAPABILITY_NAME]);
			if( originalFieldMap.ContainsKey(_CAPABILITY_NAME) )
				originalFieldMap[_CAPABILITY_NAME] = reader[_CAPABILITY_NAME];
			else
				originalFieldMap.Add(_CAPABILITY_NAME, reader[_CAPABILITY_NAME]);
			if( fieldMap.ContainsKey(_TSF_UUID) )
				fieldMap[_TSF_UUID] = reader[_TSF_UUID];
			else
				fieldMap.Add(_TSF_UUID, reader[_TSF_UUID]);
			if( originalFieldMap.ContainsKey(_TSF_UUID) )
				originalFieldMap[_TSF_UUID] = reader[_TSF_UUID];
			else
				originalFieldMap.Add(_TSF_UUID, reader[_TSF_UUID]);
		}

		public override void writeStartXML(UTRSXmlWriter xml)
		{
			xml.WriteStartElement(_TABLE_NAME.ToLower());
		}

		public override void writeXML(UTRSXmlWriter xml)
		{
			xml.WriteElementSafeString(_INSTRUMENT_UUID.ToLower(), instrumentUuid);
			xml.WriteElementSafeString(_ATTRIBUTE.ToLower(), attribute);
			xml.WriteElementSafeString(_SIGNAL_NAME.ToLower(), signalName);
			xml.WriteElementSafeString(_LOW_VALUE.ToLower(), lowValue);
			xml.WriteElementSafeString(_LOW_UNIT.ToLower(), lowUnit);
			xml.WriteElementSafeString(_HIGH_VALUE.ToLower(), highValue);
			xml.WriteElementSafeString(_HIGH_UNIT.ToLower(), highUnit);
			xml.WriteElementSafeString(_ERR_VALUE.ToLower(), errValue);
			xml.WriteElementSafeString(_ERR_UNIT.ToLower(), errUnit);
			xml.WriteElementSafeString(_RES_VALUE.ToLower(), resValue);
			xml.WriteElementSafeString(_RES_UNIT.ToLower(), resUnit);
			xml.WriteElementSafeString(_LOAD_VALUE.ToLower(), loadValue);
			xml.WriteElementSafeString(_LOAD_UNIT.ToLower(), loadUnit);
			xml.WriteElementSafeString(_SIGNAL_TYPE.ToLower(), signalType);
			xml.WriteElementSafeString(_SIGNAL_NAMESPACE.ToLower(), signalNamespace);
			xml.WriteElementSafeString(_CAPABILITY_NAME.ToLower(), capabilityName);
			xml.WriteElementSafeString(_TSF_UUID.ToLower(), tsfUuid);
		}

		public override void writeEndXML(UTRSXmlWriter xml)
		{
			xml.WriteEndElement();
		}

	}
}
