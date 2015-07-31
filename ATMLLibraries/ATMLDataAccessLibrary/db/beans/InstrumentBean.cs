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
	public partial class InstrumentBean : BASEBean
	{
		public static readonly System.String _TABLE_NAME = "instrument";
		public static readonly System.String _INSTRUMENT_UUID = "instrument_uuid";
		public static readonly System.String _INSTRUMENT_NAME = "instrument_name";
		public static readonly System.String _MODEL_NAME = "model_name";
		public static readonly System.String _ATML = "atml";
		public static readonly System.String _DESCRIPTION = "description";
		public static readonly System.String _PART_NUMBER = "part_number";


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

		public System.String instrumentName
		{
			get { return fieldMap[_INSTRUMENT_NAME]==System.DBNull.Value || fieldMap[_INSTRUMENT_NAME] == null ? null : fieldMap[_INSTRUMENT_NAME].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_INSTRUMENT_NAME) )
				{
					oldValue = fieldMap[_INSTRUMENT_NAME];
					fieldMap[_INSTRUMENT_NAME] = value;
				}
				else
				{
					fieldMap.Add(_INSTRUMENT_NAME, value);
					fieldTypeMap.Add(_INSTRUMENT_NAME, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_INSTRUMENT_NAME, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.String modelName
		{
			get { return fieldMap[_MODEL_NAME]==System.DBNull.Value || fieldMap[_MODEL_NAME] == null ? null : fieldMap[_MODEL_NAME].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_MODEL_NAME) )
				{
					oldValue = fieldMap[_MODEL_NAME];
					fieldMap[_MODEL_NAME] = value;
				}
				else
				{
					fieldMap.Add(_MODEL_NAME, value);
					fieldTypeMap.Add(_MODEL_NAME, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_MODEL_NAME, oldValue, value);
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

		public System.String description
		{
			get { return fieldMap[_DESCRIPTION]==System.DBNull.Value || fieldMap[_DESCRIPTION] == null ? null : fieldMap[_DESCRIPTION].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_DESCRIPTION) )
				{
					oldValue = fieldMap[_DESCRIPTION];
					fieldMap[_DESCRIPTION] = value;
				}
				else
				{
					fieldMap.Add(_DESCRIPTION, value);
					fieldTypeMap.Add(_DESCRIPTION, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_DESCRIPTION, oldValue, value);
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

		public InstrumentBean( ):base( _TABLE_NAME )
		{
			if( fieldMap.ContainsKey(_INSTRUMENT_UUID) )
				fieldMap[_INSTRUMENT_UUID] = null;
			else
				fieldMap.Add(_INSTRUMENT_UUID, null );
			if( fieldMap.ContainsKey(_INSTRUMENT_NAME) )
				fieldMap[_INSTRUMENT_NAME] = null;
			else
				fieldMap.Add(_INSTRUMENT_NAME, null );
			if( fieldMap.ContainsKey(_MODEL_NAME) )
				fieldMap[_MODEL_NAME] = null;
			else
				fieldMap.Add(_MODEL_NAME, null );
			if( fieldMap.ContainsKey(_ATML) )
				fieldMap[_ATML] = null;
			else
				fieldMap.Add(_ATML, null );
			if( fieldMap.ContainsKey(_DESCRIPTION) )
				fieldMap[_DESCRIPTION] = null;
			else
				fieldMap.Add(_DESCRIPTION, null );
			if( fieldMap.ContainsKey(_PART_NUMBER) )
				fieldMap[_PART_NUMBER] = null;
			else
				fieldMap.Add(_PART_NUMBER, null );
			initialize();
		}

		public InstrumentBean( OleDbDataReader reader ):base( _TABLE_NAME )
		{
			if( fieldMap.ContainsKey(_INSTRUMENT_UUID) )
				fieldMap[_INSTRUMENT_UUID] = reader[_INSTRUMENT_UUID];
			else
				fieldMap.Add(_INSTRUMENT_UUID, reader[_INSTRUMENT_UUID]);
			if( fieldMap.ContainsKey(_INSTRUMENT_NAME) )
				fieldMap[_INSTRUMENT_NAME] = reader[_INSTRUMENT_NAME];
			else
				fieldMap.Add(_INSTRUMENT_NAME, reader[_INSTRUMENT_NAME]);
			if( fieldMap.ContainsKey(_MODEL_NAME) )
				fieldMap[_MODEL_NAME] = reader[_MODEL_NAME];
			else
				fieldMap.Add(_MODEL_NAME, reader[_MODEL_NAME]);
			if( fieldMap.ContainsKey(_ATML) )
				fieldMap[_ATML] = reader[_ATML];
			else
				fieldMap.Add(_ATML, reader[_ATML]);
			if( fieldMap.ContainsKey(_DESCRIPTION) )
				fieldMap[_DESCRIPTION] = reader[_DESCRIPTION];
			else
				fieldMap.Add(_DESCRIPTION, reader[_DESCRIPTION]);
			if( fieldMap.ContainsKey(_PART_NUMBER) )
				fieldMap[_PART_NUMBER] = reader[_PART_NUMBER];
			else
				fieldMap.Add(_PART_NUMBER, reader[_PART_NUMBER]);
			initialize();
		}

		private void initialize( )
		{
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
			if( fieldMap.ContainsKey(_INSTRUMENT_NAME) )
				fieldMap[_INSTRUMENT_NAME] = reader[_INSTRUMENT_NAME];
			else
				fieldMap.Add(_INSTRUMENT_NAME, reader[_INSTRUMENT_NAME]);
			if( originalFieldMap.ContainsKey(_INSTRUMENT_NAME) )
				originalFieldMap[_INSTRUMENT_NAME] = reader[_INSTRUMENT_NAME];
			else
				originalFieldMap.Add(_INSTRUMENT_NAME, reader[_INSTRUMENT_NAME]);
			if( fieldMap.ContainsKey(_MODEL_NAME) )
				fieldMap[_MODEL_NAME] = reader[_MODEL_NAME];
			else
				fieldMap.Add(_MODEL_NAME, reader[_MODEL_NAME]);
			if( originalFieldMap.ContainsKey(_MODEL_NAME) )
				originalFieldMap[_MODEL_NAME] = reader[_MODEL_NAME];
			else
				originalFieldMap.Add(_MODEL_NAME, reader[_MODEL_NAME]);
			if( fieldMap.ContainsKey(_ATML) )
				fieldMap[_ATML] = reader[_ATML];
			else
				fieldMap.Add(_ATML, reader[_ATML]);
			if( originalFieldMap.ContainsKey(_ATML) )
				originalFieldMap[_ATML] = reader[_ATML];
			else
				originalFieldMap.Add(_ATML, reader[_ATML]);
			if( fieldMap.ContainsKey(_DESCRIPTION) )
				fieldMap[_DESCRIPTION] = reader[_DESCRIPTION];
			else
				fieldMap.Add(_DESCRIPTION, reader[_DESCRIPTION]);
			if( originalFieldMap.ContainsKey(_DESCRIPTION) )
				originalFieldMap[_DESCRIPTION] = reader[_DESCRIPTION];
			else
				originalFieldMap.Add(_DESCRIPTION, reader[_DESCRIPTION]);
			if( fieldMap.ContainsKey(_PART_NUMBER) )
				fieldMap[_PART_NUMBER] = reader[_PART_NUMBER];
			else
				fieldMap.Add(_PART_NUMBER, reader[_PART_NUMBER]);
			if( originalFieldMap.ContainsKey(_PART_NUMBER) )
				originalFieldMap[_PART_NUMBER] = reader[_PART_NUMBER];
			else
				originalFieldMap.Add(_PART_NUMBER, reader[_PART_NUMBER]);
		}

		public override void writeStartXML(UTRSXmlWriter xml)
		{
			xml.WriteStartElement(_TABLE_NAME.ToLower());
		}

		public override void writeXML(UTRSXmlWriter xml)
		{
			xml.WriteElementSafeString(_INSTRUMENT_UUID.ToLower(), instrumentUuid);
			xml.WriteElementSafeString(_INSTRUMENT_NAME.ToLower(), instrumentName);
			xml.WriteElementSafeString(_MODEL_NAME.ToLower(), modelName);
			xml.WriteElementSafeString(_ATML.ToLower(), atml);
			xml.WriteElementSafeString(_DESCRIPTION.ToLower(), description);
			xml.WriteElementSafeString(_PART_NUMBER.ToLower(), partNumber);
		}

		public override void writeEndXML(UTRSXmlWriter xml)
		{
			xml.WriteEndElement();
		}

	}
}
