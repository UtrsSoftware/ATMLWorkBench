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
	public partial class SourceSignalAttributeMapBean : BASEBean
	{
		public static readonly System.String _TABLE_NAME = "source_signal_attribute_map";
		public static readonly System.String _ID = "ID";
		public static readonly System.String _MAP_ID = "map_id";
		public static readonly System.String _SOURCE_NAME = "source_name";
		public static readonly System.String _SOURCE_TYPE = "source_type";
		public static readonly System.String _SOURCE_DEFAULT = "source_default";
		public static readonly System.String _SOURCE_SUFFIX = "source_suffix";
		public static readonly System.String _SOURCE_UNIT = "source_unit";
		public static readonly System.String _TARGET_NAME = "target_name";
		public static readonly System.String _TARGET_TYPE = "target_type";
		public static readonly System.String _TARGET_DEFAULT = "target_default";
		public static readonly System.String _TARGET_QUALIFIER = "target_qualifier";
		public static readonly System.String _TARGET_UNIT = "target_unit";


		public System.Guid? ID
		{
			get { return fieldMap[_ID]==System.DBNull.Value || fieldMap[_ID] == null ? null : (System.Guid? )fieldMap[_ID];  }
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
					fieldTypeMap.Add(_ID, OleDbType.Guid );
				}
				EventArgs arg = new DataChangedEventArgs(_ID, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.Guid? mapId
		{
			get { return fieldMap[_MAP_ID]==System.DBNull.Value || fieldMap[_MAP_ID] == null ? null : (System.Guid? )fieldMap[_MAP_ID];  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_MAP_ID) )
				{
					oldValue = fieldMap[_MAP_ID];
					fieldMap[_MAP_ID] = value;
				}
				else
				{
					fieldMap.Add(_MAP_ID, value);
					fieldTypeMap.Add(_MAP_ID, OleDbType.Guid );
				}
				EventArgs arg = new DataChangedEventArgs(_MAP_ID, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.String sourceName
		{
			get { return fieldMap[_SOURCE_NAME]==System.DBNull.Value || fieldMap[_SOURCE_NAME] == null ? null : fieldMap[_SOURCE_NAME].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_SOURCE_NAME) )
				{
					oldValue = fieldMap[_SOURCE_NAME];
					fieldMap[_SOURCE_NAME] = value;
				}
				else
				{
					fieldMap.Add(_SOURCE_NAME, value);
					fieldTypeMap.Add(_SOURCE_NAME, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_SOURCE_NAME, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.String sourceType
		{
			get { return fieldMap[_SOURCE_TYPE]==System.DBNull.Value || fieldMap[_SOURCE_TYPE] == null ? null : fieldMap[_SOURCE_TYPE].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_SOURCE_TYPE) )
				{
					oldValue = fieldMap[_SOURCE_TYPE];
					fieldMap[_SOURCE_TYPE] = value;
				}
				else
				{
					fieldMap.Add(_SOURCE_TYPE, value);
					fieldTypeMap.Add(_SOURCE_TYPE, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_SOURCE_TYPE, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.String sourceDefault
		{
			get { return fieldMap[_SOURCE_DEFAULT]==System.DBNull.Value || fieldMap[_SOURCE_DEFAULT] == null ? null : fieldMap[_SOURCE_DEFAULT].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_SOURCE_DEFAULT) )
				{
					oldValue = fieldMap[_SOURCE_DEFAULT];
					fieldMap[_SOURCE_DEFAULT] = value;
				}
				else
				{
					fieldMap.Add(_SOURCE_DEFAULT, value);
					fieldTypeMap.Add(_SOURCE_DEFAULT, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_SOURCE_DEFAULT, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.String sourceSuffix
		{
			get { return fieldMap[_SOURCE_SUFFIX]==System.DBNull.Value || fieldMap[_SOURCE_SUFFIX] == null ? null : fieldMap[_SOURCE_SUFFIX].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_SOURCE_SUFFIX) )
				{
					oldValue = fieldMap[_SOURCE_SUFFIX];
					fieldMap[_SOURCE_SUFFIX] = value;
				}
				else
				{
					fieldMap.Add(_SOURCE_SUFFIX, value);
					fieldTypeMap.Add(_SOURCE_SUFFIX, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_SOURCE_SUFFIX, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.String sourceUnit
		{
			get { return fieldMap[_SOURCE_UNIT]==System.DBNull.Value || fieldMap[_SOURCE_UNIT] == null ? null : fieldMap[_SOURCE_UNIT].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_SOURCE_UNIT) )
				{
					oldValue = fieldMap[_SOURCE_UNIT];
					fieldMap[_SOURCE_UNIT] = value;
				}
				else
				{
					fieldMap.Add(_SOURCE_UNIT, value);
					fieldTypeMap.Add(_SOURCE_UNIT, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_SOURCE_UNIT, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.String targetName
		{
			get { return fieldMap[_TARGET_NAME]==System.DBNull.Value || fieldMap[_TARGET_NAME] == null ? null : fieldMap[_TARGET_NAME].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_TARGET_NAME) )
				{
					oldValue = fieldMap[_TARGET_NAME];
					fieldMap[_TARGET_NAME] = value;
				}
				else
				{
					fieldMap.Add(_TARGET_NAME, value);
					fieldTypeMap.Add(_TARGET_NAME, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_TARGET_NAME, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.String targetType
		{
			get { return fieldMap[_TARGET_TYPE]==System.DBNull.Value || fieldMap[_TARGET_TYPE] == null ? null : fieldMap[_TARGET_TYPE].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_TARGET_TYPE) )
				{
					oldValue = fieldMap[_TARGET_TYPE];
					fieldMap[_TARGET_TYPE] = value;
				}
				else
				{
					fieldMap.Add(_TARGET_TYPE, value);
					fieldTypeMap.Add(_TARGET_TYPE, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_TARGET_TYPE, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.String targetDefault
		{
			get { return fieldMap[_TARGET_DEFAULT]==System.DBNull.Value || fieldMap[_TARGET_DEFAULT] == null ? null : fieldMap[_TARGET_DEFAULT].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_TARGET_DEFAULT) )
				{
					oldValue = fieldMap[_TARGET_DEFAULT];
					fieldMap[_TARGET_DEFAULT] = value;
				}
				else
				{
					fieldMap.Add(_TARGET_DEFAULT, value);
					fieldTypeMap.Add(_TARGET_DEFAULT, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_TARGET_DEFAULT, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.String targetQualifier
		{
			get { return fieldMap[_TARGET_QUALIFIER]==System.DBNull.Value || fieldMap[_TARGET_QUALIFIER] == null ? null : fieldMap[_TARGET_QUALIFIER].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_TARGET_QUALIFIER) )
				{
					oldValue = fieldMap[_TARGET_QUALIFIER];
					fieldMap[_TARGET_QUALIFIER] = value;
				}
				else
				{
					fieldMap.Add(_TARGET_QUALIFIER, value);
					fieldTypeMap.Add(_TARGET_QUALIFIER, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_TARGET_QUALIFIER, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public System.String targetUnit
		{
			get { return fieldMap[_TARGET_UNIT]==System.DBNull.Value || fieldMap[_TARGET_UNIT] == null ? null : fieldMap[_TARGET_UNIT].ToString();  }
			set
			{
				object oldValue = null;
				if( fieldMap.ContainsKey(_TARGET_UNIT) )
				{
					oldValue = fieldMap[_TARGET_UNIT];
					fieldMap[_TARGET_UNIT] = value;
				}
				else
				{
					fieldMap.Add(_TARGET_UNIT, value);
					fieldTypeMap.Add(_TARGET_UNIT, OleDbType.VarChar );
				}
				EventArgs arg = new DataChangedEventArgs(_TARGET_UNIT, oldValue, value);
				OnDataChanged(arg);
			}
		}

		public SourceSignalAttributeMapBean( ):base( _TABLE_NAME )
		{
			if( fieldMap.ContainsKey(_ID) )
				fieldMap[_ID] = null;
			else
				fieldMap.Add(_ID, null );
			if( fieldMap.ContainsKey(_MAP_ID) )
				fieldMap[_MAP_ID] = null;
			else
				fieldMap.Add(_MAP_ID, null );
			if( fieldMap.ContainsKey(_SOURCE_NAME) )
				fieldMap[_SOURCE_NAME] = null;
			else
				fieldMap.Add(_SOURCE_NAME, null );
			if( fieldMap.ContainsKey(_SOURCE_TYPE) )
				fieldMap[_SOURCE_TYPE] = null;
			else
				fieldMap.Add(_SOURCE_TYPE, null );
			if( fieldMap.ContainsKey(_SOURCE_DEFAULT) )
				fieldMap[_SOURCE_DEFAULT] = null;
			else
				fieldMap.Add(_SOURCE_DEFAULT, null );
			if( fieldMap.ContainsKey(_SOURCE_SUFFIX) )
				fieldMap[_SOURCE_SUFFIX] = null;
			else
				fieldMap.Add(_SOURCE_SUFFIX, null );
			if( fieldMap.ContainsKey(_SOURCE_UNIT) )
				fieldMap[_SOURCE_UNIT] = null;
			else
				fieldMap.Add(_SOURCE_UNIT, null );
			if( fieldMap.ContainsKey(_TARGET_NAME) )
				fieldMap[_TARGET_NAME] = null;
			else
				fieldMap.Add(_TARGET_NAME, null );
			if( fieldMap.ContainsKey(_TARGET_TYPE) )
				fieldMap[_TARGET_TYPE] = null;
			else
				fieldMap.Add(_TARGET_TYPE, null );
			if( fieldMap.ContainsKey(_TARGET_DEFAULT) )
				fieldMap[_TARGET_DEFAULT] = null;
			else
				fieldMap.Add(_TARGET_DEFAULT, null );
			if( fieldMap.ContainsKey(_TARGET_QUALIFIER) )
				fieldMap[_TARGET_QUALIFIER] = null;
			else
				fieldMap.Add(_TARGET_QUALIFIER, null );
			if( fieldMap.ContainsKey(_TARGET_UNIT) )
				fieldMap[_TARGET_UNIT] = null;
			else
				fieldMap.Add(_TARGET_UNIT, null );
			initialize();
		}

		public SourceSignalAttributeMapBean( OleDbDataReader reader ):base( _TABLE_NAME )
		{
			if( fieldMap.ContainsKey(_ID) )
				fieldMap[_ID] = reader[_ID];
			else
				fieldMap.Add(_ID, reader[_ID]);
			if( fieldMap.ContainsKey(_MAP_ID) )
				fieldMap[_MAP_ID] = reader[_MAP_ID];
			else
				fieldMap.Add(_MAP_ID, reader[_MAP_ID]);
			if( fieldMap.ContainsKey(_SOURCE_NAME) )
				fieldMap[_SOURCE_NAME] = reader[_SOURCE_NAME];
			else
				fieldMap.Add(_SOURCE_NAME, reader[_SOURCE_NAME]);
			if( fieldMap.ContainsKey(_SOURCE_TYPE) )
				fieldMap[_SOURCE_TYPE] = reader[_SOURCE_TYPE];
			else
				fieldMap.Add(_SOURCE_TYPE, reader[_SOURCE_TYPE]);
			if( fieldMap.ContainsKey(_SOURCE_DEFAULT) )
				fieldMap[_SOURCE_DEFAULT] = reader[_SOURCE_DEFAULT];
			else
				fieldMap.Add(_SOURCE_DEFAULT, reader[_SOURCE_DEFAULT]);
			if( fieldMap.ContainsKey(_SOURCE_SUFFIX) )
				fieldMap[_SOURCE_SUFFIX] = reader[_SOURCE_SUFFIX];
			else
				fieldMap.Add(_SOURCE_SUFFIX, reader[_SOURCE_SUFFIX]);
			if( fieldMap.ContainsKey(_SOURCE_UNIT) )
				fieldMap[_SOURCE_UNIT] = reader[_SOURCE_UNIT];
			else
				fieldMap.Add(_SOURCE_UNIT, reader[_SOURCE_UNIT]);
			if( fieldMap.ContainsKey(_TARGET_NAME) )
				fieldMap[_TARGET_NAME] = reader[_TARGET_NAME];
			else
				fieldMap.Add(_TARGET_NAME, reader[_TARGET_NAME]);
			if( fieldMap.ContainsKey(_TARGET_TYPE) )
				fieldMap[_TARGET_TYPE] = reader[_TARGET_TYPE];
			else
				fieldMap.Add(_TARGET_TYPE, reader[_TARGET_TYPE]);
			if( fieldMap.ContainsKey(_TARGET_DEFAULT) )
				fieldMap[_TARGET_DEFAULT] = reader[_TARGET_DEFAULT];
			else
				fieldMap.Add(_TARGET_DEFAULT, reader[_TARGET_DEFAULT]);
			if( fieldMap.ContainsKey(_TARGET_QUALIFIER) )
				fieldMap[_TARGET_QUALIFIER] = reader[_TARGET_QUALIFIER];
			else
				fieldMap.Add(_TARGET_QUALIFIER, reader[_TARGET_QUALIFIER]);
			if( fieldMap.ContainsKey(_TARGET_UNIT) )
				fieldMap[_TARGET_UNIT] = reader[_TARGET_UNIT];
			else
				fieldMap.Add(_TARGET_UNIT, reader[_TARGET_UNIT]);
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
			if( fieldMap.ContainsKey(_MAP_ID) )
				fieldMap[_MAP_ID] = reader[_MAP_ID];
			else
				fieldMap.Add(_MAP_ID, reader[_MAP_ID]);
			if( originalFieldMap.ContainsKey(_MAP_ID) )
				originalFieldMap[_MAP_ID] = reader[_MAP_ID];
			else
				originalFieldMap.Add(_MAP_ID, reader[_MAP_ID]);
			if( fieldMap.ContainsKey(_SOURCE_NAME) )
				fieldMap[_SOURCE_NAME] = reader[_SOURCE_NAME];
			else
				fieldMap.Add(_SOURCE_NAME, reader[_SOURCE_NAME]);
			if( originalFieldMap.ContainsKey(_SOURCE_NAME) )
				originalFieldMap[_SOURCE_NAME] = reader[_SOURCE_NAME];
			else
				originalFieldMap.Add(_SOURCE_NAME, reader[_SOURCE_NAME]);
			if( fieldMap.ContainsKey(_SOURCE_TYPE) )
				fieldMap[_SOURCE_TYPE] = reader[_SOURCE_TYPE];
			else
				fieldMap.Add(_SOURCE_TYPE, reader[_SOURCE_TYPE]);
			if( originalFieldMap.ContainsKey(_SOURCE_TYPE) )
				originalFieldMap[_SOURCE_TYPE] = reader[_SOURCE_TYPE];
			else
				originalFieldMap.Add(_SOURCE_TYPE, reader[_SOURCE_TYPE]);
			if( fieldMap.ContainsKey(_SOURCE_DEFAULT) )
				fieldMap[_SOURCE_DEFAULT] = reader[_SOURCE_DEFAULT];
			else
				fieldMap.Add(_SOURCE_DEFAULT, reader[_SOURCE_DEFAULT]);
			if( originalFieldMap.ContainsKey(_SOURCE_DEFAULT) )
				originalFieldMap[_SOURCE_DEFAULT] = reader[_SOURCE_DEFAULT];
			else
				originalFieldMap.Add(_SOURCE_DEFAULT, reader[_SOURCE_DEFAULT]);
			if( fieldMap.ContainsKey(_SOURCE_SUFFIX) )
				fieldMap[_SOURCE_SUFFIX] = reader[_SOURCE_SUFFIX];
			else
				fieldMap.Add(_SOURCE_SUFFIX, reader[_SOURCE_SUFFIX]);
			if( originalFieldMap.ContainsKey(_SOURCE_SUFFIX) )
				originalFieldMap[_SOURCE_SUFFIX] = reader[_SOURCE_SUFFIX];
			else
				originalFieldMap.Add(_SOURCE_SUFFIX, reader[_SOURCE_SUFFIX]);
			if( fieldMap.ContainsKey(_SOURCE_UNIT) )
				fieldMap[_SOURCE_UNIT] = reader[_SOURCE_UNIT];
			else
				fieldMap.Add(_SOURCE_UNIT, reader[_SOURCE_UNIT]);
			if( originalFieldMap.ContainsKey(_SOURCE_UNIT) )
				originalFieldMap[_SOURCE_UNIT] = reader[_SOURCE_UNIT];
			else
				originalFieldMap.Add(_SOURCE_UNIT, reader[_SOURCE_UNIT]);
			if( fieldMap.ContainsKey(_TARGET_NAME) )
				fieldMap[_TARGET_NAME] = reader[_TARGET_NAME];
			else
				fieldMap.Add(_TARGET_NAME, reader[_TARGET_NAME]);
			if( originalFieldMap.ContainsKey(_TARGET_NAME) )
				originalFieldMap[_TARGET_NAME] = reader[_TARGET_NAME];
			else
				originalFieldMap.Add(_TARGET_NAME, reader[_TARGET_NAME]);
			if( fieldMap.ContainsKey(_TARGET_TYPE) )
				fieldMap[_TARGET_TYPE] = reader[_TARGET_TYPE];
			else
				fieldMap.Add(_TARGET_TYPE, reader[_TARGET_TYPE]);
			if( originalFieldMap.ContainsKey(_TARGET_TYPE) )
				originalFieldMap[_TARGET_TYPE] = reader[_TARGET_TYPE];
			else
				originalFieldMap.Add(_TARGET_TYPE, reader[_TARGET_TYPE]);
			if( fieldMap.ContainsKey(_TARGET_DEFAULT) )
				fieldMap[_TARGET_DEFAULT] = reader[_TARGET_DEFAULT];
			else
				fieldMap.Add(_TARGET_DEFAULT, reader[_TARGET_DEFAULT]);
			if( originalFieldMap.ContainsKey(_TARGET_DEFAULT) )
				originalFieldMap[_TARGET_DEFAULT] = reader[_TARGET_DEFAULT];
			else
				originalFieldMap.Add(_TARGET_DEFAULT, reader[_TARGET_DEFAULT]);
			if( fieldMap.ContainsKey(_TARGET_QUALIFIER) )
				fieldMap[_TARGET_QUALIFIER] = reader[_TARGET_QUALIFIER];
			else
				fieldMap.Add(_TARGET_QUALIFIER, reader[_TARGET_QUALIFIER]);
			if( originalFieldMap.ContainsKey(_TARGET_QUALIFIER) )
				originalFieldMap[_TARGET_QUALIFIER] = reader[_TARGET_QUALIFIER];
			else
				originalFieldMap.Add(_TARGET_QUALIFIER, reader[_TARGET_QUALIFIER]);
			if( fieldMap.ContainsKey(_TARGET_UNIT) )
				fieldMap[_TARGET_UNIT] = reader[_TARGET_UNIT];
			else
				fieldMap.Add(_TARGET_UNIT, reader[_TARGET_UNIT]);
			if( originalFieldMap.ContainsKey(_TARGET_UNIT) )
				originalFieldMap[_TARGET_UNIT] = reader[_TARGET_UNIT];
			else
				originalFieldMap.Add(_TARGET_UNIT, reader[_TARGET_UNIT]);
		}

		public override void writeStartXML(UTRSXmlWriter xml)
		{
			xml.WriteStartElement(_TABLE_NAME.ToLower());
		}

		public override void writeXML(UTRSXmlWriter xml)
		{
			xml.WriteElementSafeString(_ID.ToLower(), ID);
			xml.WriteElementSafeString(_MAP_ID.ToLower(), mapId);
			xml.WriteElementSafeString(_SOURCE_NAME.ToLower(), sourceName);
			xml.WriteElementSafeString(_SOURCE_TYPE.ToLower(), sourceType);
			xml.WriteElementSafeString(_SOURCE_DEFAULT.ToLower(), sourceDefault);
			xml.WriteElementSafeString(_SOURCE_SUFFIX.ToLower(), sourceSuffix);
			xml.WriteElementSafeString(_SOURCE_UNIT.ToLower(), sourceUnit);
			xml.WriteElementSafeString(_TARGET_NAME.ToLower(), targetName);
			xml.WriteElementSafeString(_TARGET_TYPE.ToLower(), targetType);
			xml.WriteElementSafeString(_TARGET_DEFAULT.ToLower(), targetDefault);
			xml.WriteElementSafeString(_TARGET_QUALIFIER.ToLower(), targetQualifier);
			xml.WriteElementSafeString(_TARGET_UNIT.ToLower(), targetUnit);
		}

		public override void writeEndXML(UTRSXmlWriter xml)
		{
			xml.WriteEndElement();
		}

	}
}
