/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Collections.Generic;
using System.Data.OleDb;
using ATMLDataAccessLibrary.db.daos;
using ATMLUtilitiesLibrary;

namespace ATMLDataAccessLibrary.db.beans
{
    public delegate void DataChangedEventHandler( object sender, EventArgs e );

    public delegate void RecordInsertedEventHandler( object sender, EventArgs e );

    public delegate void RecordUpdatedEventHandler( object sender, EventArgs e );

    public delegate void RecordDeletedEventHandler( object sender, EventArgs e );

    public abstract class BASEBean
    {
        public enum eDataState
        {
            DS_ADD,
            DS_EDIT,
            DS_DELETE,
            DS_NO_CHANGE
        };

        public static string _ALL = "*";

        private eDataState dataState;
        private bool dirty;

        protected SerializableDictionary<String, Object> fieldMap = new SerializableDictionary<String, Object>();

        protected SerializableDictionary<String, OleDbType> fieldTypeMap =
            new SerializableDictionary<String, OleDbType>();

        private bool includeKeyOnInsert;
        protected List<String> keys = new List<String>();
        protected SerializableDictionary<String, Object> originalFieldMap = new SerializableDictionary<String, Object>();
        private BASEBean parentBean;
        public BASEBean()
        {
        }

        public BASEBean( String tableName )
        {
            this.TableName = tableName;
        }
        public BASEBean( OleDbDataReader reader )
        {
            load( reader );
        }

        public bool IncludeKeyOnInsert
        {
            get { return includeKeyOnInsert; }
            set { includeKeyOnInsert = value; }
        }

        public bool isDirty
        {
            get
            {
                foreach (string key in fieldMap.Keys)
                {
                    object originalValue = originalFieldMap[key];
                    object newValue = fieldMap[key];
                    if (( originalValue == null && newValue != null )
                        || ( originalValue != null && newValue == null )
                        || !originalValue.Equals( newValue ))
                    {
                        dirty = true;
                    }
                }
                return dirty;
            }
        }

        public eDataState DataState
        {
            get { return dataState; }
            set { dataState = value; }
        }

        public string TableName { get; set; }

        public SerializableDictionary<String, Object> FieldMap
        {
            get { return fieldMap; }
            set { fieldMap = value; }
        }

        public List<String> Keys
        {
            get { return keys; }
            set { keys = value; }
        }


        public BASEBean ParentBean
        {
            get { return parentBean; }
            set { parentBean = value; }
        }

        public List<String> FieldNames
        {
            get
            {
                var fields = new List<String>();
                foreach (String key in fieldMap.Keys)
                {
                    if (!Keys.Contains( key ))
                        fields.Add( key );
                }
                return fields;
            }
        }

        public OleDbParameter[] UpdateValues
        {
            get
            {
                List<String> fieldNames = FieldNames;
                var parameters = new OleDbParameter[fieldMap.Count];
                int i = 0;
                for (i = 0; i < fieldNames.Count; i++)
                {
                    Object value = fieldMap[fieldNames[i]];
                    //parameters[i] = new OleDbParameter(fieldNames[i], getDBType(value));
                    //parameters[i].Value = value == null?DBNull.Value : value;
                    parameters[i] = new OleDbParameter( fieldNames[i], value );
                    if (value != null && value.GetType() == typeof (DateTime))
                        parameters[i].OleDbType = OleDbType.Date;
                    if (value == null)
                        parameters[i].Value = DBNull.Value;
                }

                for (int x = 0; x < Keys.Count; x++)
                {
                    Object value = fieldMap[Keys[x]];
                    if (value == null)
                        throw new Exception( "Key value for \"" + Keys[x] + "\" is null, keys cannot be null" );
                    parameters[i++] = new OleDbParameter( Keys[x], value );
                }
                return parameters;
            }
        }

        public OleDbParameter[] KeyValues
        {
            get
            {
                var parameters = new OleDbParameter[keys.Count];
                int i = 0;
                for (int x = 0; x < Keys.Count; x++)
                {
                    Object value = fieldMap[Keys[x]];
                    if (value == null)
                        throw new Exception( "Key value for \"" + Keys[x] + "\" is null, keys cannot be null" );
                    parameters[i++] = new OleDbParameter( Keys[x], value );
                }
                return parameters;
            }
        }


        public OleDbParameter[] InsertValues
        {
            get
            {
                List<String> fieldNames = FieldNames;
                var parameters = new OleDbParameter[fieldNames.Count + keys.Count];
                int i = 0;
                for (i = 0; i < fieldNames.Count; i++)
                {
                    Object value = fieldMap[fieldNames[i]];
                    parameters[i] = new OleDbParameter( "[" + fieldNames[i] + "]", value );
                    if (value != null && value.GetType() == typeof (DateTime))
                        parameters[i].OleDbType = OleDbType.Date;
                    if (value == null)
                        parameters[i].Value = DBNull.Value;
                }
                for (int x = 0; x < keys.Count; x++)
                {
                    Object value = fieldMap[keys[x]];
                    parameters[i] = new OleDbParameter( "[" + keys[x] + "]", value );
                    if (value != null && value.GetType() == typeof (DateTime))
                        parameters[i].OleDbType = OleDbType.Date;
                    if (value == null)
                        parameters[i].Value = DBNull.Value;
                    i++;
                }
                return parameters;
            }
        }

        public event DataChangedEventHandler DataChanged;
        public event RecordDeletedEventHandler RecordDeleted;
        public event RecordUpdatedEventHandler RecordUpdated;
        public event RecordInsertedEventHandler RecordInserted;

        private String getString( Object value )
        {
            if (value != null)
                return value.ToString();
            return null;
        }

        private Int32? getInt32( Object value )
        {
            if (value != null)
            {
                if (value is int)
                    return (Int32) value;
                return null;
            }
            return null;
        }

        private Double? getDouble( Object value )
        {
            if (value != null)
            {
                if (value is double)
                    return (Double) value;
                return null;
            }
            return null;
        }

        protected void resetDirtyState()
        {
            dirty = false;
        }

        // Invoke the Changed event; called whenever list changes
        protected virtual void OnDataChanged( EventArgs e )
        {
            if (DataChanged != null)
                DataChanged( this, e );
        }

        protected virtual void OnRecordInserted( EventArgs e )
        {
            if (RecordInserted != null)
                RecordInserted( this, e );
        }

        protected virtual void OnRecordUpdated( EventArgs e )
        {
            if (RecordUpdated != null)
                RecordUpdated( this, e );
        }

        protected virtual void OnRecordDeleted( EventArgs e )
        {
            if (RecordDeleted != null)
                RecordDeleted( this, e );
        }

        public BASEBean findRoot()
        {
            BASEBean root = null;
            if (parentBean == null)
                root = this;
            else
                root = parentBean.findRoot();
            return root;
        }


        private OleDbType getDBType( Object value )
        {
            var type = OleDbType.VarChar;
            if (value == null)
                type = OleDbType.VarChar;
            else if (value.GetType() == typeof (DateTime))
                type = OleDbType.Date;
            else if (value.GetType() == typeof (String))
                type = OleDbType.VarChar;
            else if (value.GetType() == typeof (Int32))
                type = OleDbType.Numeric;
            else
                type = OleDbType.VarChar;
            return type;
        }


        public override bool Equals( object obj )
        {
            bool equals = obj is BASEBean;
            if (obj is BASEBean)
            {
                var bean = (BASEBean) obj;
                foreach (string name in FieldMap.Keys)
                {
                    object obj1 = FieldMap[name];
                    object obj2 = bean.FieldMap[name];
                    bool eq = false;
                    if (obj1 != null && obj2 != null)
                        eq = ( obj1.Equals( obj2 ) );
                    if (obj1 == null && obj2 == null)
                        eq = true;
                    equals &= eq;
                }
            }
            return equals;
        }


        public virtual void load( OleDbDataReader reader )
        {
        }

        public object insert()
        {
            var dao = new DAO();
            dao.IncludeKeyOnInsert = includeKeyOnInsert;
            return dao.Insert( this );
        }

        public object update()
        {
            var dao = new DAO();
            return dao.Update( this );
        }

        public virtual void delete()
        {
            var dao = new DAO();
            dao.Delete( this );
        }

        public virtual void save()
        {
            var dao = new DAO();
            if (dataState == eDataState.DS_NO_CHANGE && isDirty)
                dataState = eDataState.DS_EDIT;

            switch (dataState)
            {
                case eDataState.DS_ADD:
                    object keyValue = insert(); //TODO: put keys as output parameters
                    if (( keyValue is int && ( (int) keyValue ) > 0 ) || !( keyValue is int ))
                    {
                        foreach (String key in keys)
                            fieldMap[key] = keyValue;
                        // We are assuming 1 key for now -- need to think about this for multiple keys
                    }
                    OnRecordInserted( null );
                    dataState = eDataState.DS_NO_CHANGE;
                        //Change the data state to edit so we don't try to insert it again
                    break;
                case eDataState.DS_EDIT:
                    update();
                    OnRecordUpdated( null );
                    break;
                case eDataState.DS_DELETE:
                    delete();
                    OnRecordDeleted( null );
                    break;
                case eDataState.DS_NO_CHANGE:
                    /* Do Nothing */
                    break;
            }
        }

        public virtual void writeStartXML( UTRSXmlWriter xml )
        {
        }
        public virtual void writeEndXML( UTRSXmlWriter xml )
        {
        }
        public virtual void writeXML( UTRSXmlWriter xml )
        {
        }
    }

    public class DataChangedEventArgs : EventArgs
    {
        public DataChangedEventArgs( String fieldName, Object oldValue, Object newValue )
        {
            this.FieldName = fieldName;
            this.OldValue = oldValue;
            this.NewValue = newValue;
        }
        public string FieldName { get; set; }

        public object OldValue { get; set; }

        public object NewValue { get; set; }
    }
}