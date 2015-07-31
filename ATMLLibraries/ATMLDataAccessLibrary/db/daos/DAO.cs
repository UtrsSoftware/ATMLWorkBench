/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
using ATMLDataAccessLibrary.db.beans;
using ATMLUtilitiesLibrary;

namespace ATMLDataAccessLibrary.db.daos
{
    public class DAO
    {
        private bool _includeKeyOnInsert;

        public bool IncludeKeyOnInsert
        {
            get { return _includeKeyOnInsert; }
            set { _includeKeyOnInsert = value; }
        }

        public static Boolean Valid
        {
            get { return ConnectionManager.GetInstance().Valid; }
        }

        public bool IsInTransaction
        {
            get { return ConnectionManager.GetInstance().IsInTransaction; }
        }

        ~DAO()
        {
        }

        public static void Close()
        {
            ConnectionManager.GetInstance().Close();
        }

        protected List<T> CreateList<T>(String sql, OleDbParameter[] parameters) where T : BASEBean, new()
        {
            var l = new List<T>();
            OleDbDataReader rs = ExecuteSqlQuery(sql, parameters);
            if (rs != null)
            {
                try
                {
                    while (rs.Read())
                    {
                        var o = new T();
                        o.load(rs);
                        l.Add(o);
                    }
                }
                finally
                {
                    rs.Close();
                    rs.Dispose();
                }
            }
            return l;
        }


        protected Dictionary<object, T> CreateMap<T>(String sql, OleDbParameter[] parameters, String keyName)
            where T : BASEBean, new()
        {
            var m = new Dictionary<object, T>();
            OleDbDataReader rs = ExecuteSqlQuery(sql, parameters);
            if (rs != null)
            {
                try
                {
                    while (rs.Read())
                    {
                        var o = new T();
                        o.load(rs);
                        m.Add(rs[keyName], o);
                    }
                }
                finally
                {
                    rs.Close();
                    rs.Dispose();
                }
            }
            return m;
        }


        protected T CreateBean<T>(String sql, OleDbParameter[] parameters) where T : BASEBean, new()
        {
            T o = default(T);
            OleDbDataReader rs = ExecuteSqlQuery(sql, parameters);
            if (rs != null)
            {
                try
                {
                    if (rs.Read())
                    {
                        o = new T();
                        o.load(rs);
                    }
                }
                finally
                {
                    rs.Close();
                    rs.Dispose();
                }
            }
            return o;
        }


        public void StartTransaction()
        {
            ConnectionManager.GetInstance().StartTransaction();
        }

        public void RollbackTransaction()
        {
            ConnectionManager.GetInstance().RollbackTransaction();
        }

        public void CommitTransaction()
        {
            ConnectionManager.GetInstance().CommitTransaction();
        }

        public void EndTransaction()
        {
            ConnectionManager.GetInstance().EndTransaction();
        }

        protected object ExecuteSqlCommand(String sqlCommand, OleDbParameter[] parameters)
        {
            return ConnectionManager.GetInstance().ExecuteSqlCommand(sqlCommand, parameters);
        }

        protected object ExecuteSqlCommand(String sqlCommand, OleDbParameter[] parameters, out int count )
        {
            return ConnectionManager.GetInstance().ExecuteSqlCommand(sqlCommand, parameters, out count );
        }


        protected OleDbDataReader ExecuteSqlQuery(String sqlSelect, OleDbParameter[] parameters)
        {
            OleDbDataReader results = null;
            try
            {
                results = ConnectionManager.GetInstance().ExecuteSqlQuery(sqlSelect, parameters);
            }
            catch (Exception e)
            {
                HandleSQLException(sqlSelect, parameters, e);
            }
            return results;
        }

        private static void HandleSQLException(string sqlSelect, OleDbParameter[] parameters, Exception e)
        {
            string errMsg = string.Format("Error Executing SQL: {0} Parameters: {1} \r\n {2}\r\n {3}", sqlSelect,
                                          parameters, e.Message, e.StackTrace);
            try
            {
                string sSource = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
                string sLog = "Application";
                if (!EventLog.SourceExists(sSource))
                    EventLog.CreateEventSource(sSource, sLog);
                EventLog.WriteEntry(sSource, errMsg, EventLogEntryType.Error, 234);
            }
            catch (Exception ee )
            {

            }
            throw new Exception(errMsg);
        }

        protected void ExecuteSqlQuery(String sqlSelect, OleDbParameter[] parameters, List<BASEBean> list, Type type)
        {
            try
            {
                ExecuteSqlQuery(sqlSelect, parameters, list, type);
            }
            catch (Exception e)
            {
                HandleSQLException(sqlSelect, parameters, e);
            }
        }

        protected OleDbParameter CreateParameter(String name, Object value)
        {
            var parameter = new OleDbParameter(name, value);
            return parameter;
        }

        protected String BuildSqlSelect(String tableName, String[] fieldNames, String[] keyNames)
        {
            var sb = new StringBuilder();
            sb.Append("SELECT ");
            foreach (String field in fieldNames)
                sb.Append(field).Append(", ");
            if (fieldNames.Length > 0)
                sb.Length = sb.Length - 2;
            sb.Append(" FROM ");
            sb.Append(tableName);
            if (keyNames != null && keyNames.Length > 0)
            {
                sb.Append(" WHERE ");
                foreach (String field in keyNames)
                    sb.Append(field).Append("=? and ");
                sb.Length = sb.Length - 5;
            }
            return sb.ToString();
        }


        protected String BuildUpdateSqlStatement(String tableName, List<String> updateFields, List<String> keyFields)
        {
            var sb = new StringBuilder("UPDATE ");
            sb.Append("[").Append(tableName).Append("]");
            sb.Append(" SET ");
            for (int i = 0; i < updateFields.Count; i++)
            {
                sb.Append("[").Append(updateFields[i]).Append("]");
                sb.Append(" = ?");
                if (i + 1 < updateFields.Count)
                    sb.Append(", ");
            }
            sb.Append(" WHERE ");
            for (int i = 0; i < keyFields.Count; i++)
            {
                sb.Append("[").Append(keyFields[i]).Append("]").Append(" = ? ");
                if (i + 1 < keyFields.Count)
                    sb.Append(" AND ");
            }
            return sb.ToString();
        }

        protected String BuildDeleteSqlStatement(String tableName, List<String> keyFields)
        {
            var sb = new StringBuilder("DELETE FROM ");
            sb.Append("[").Append(tableName).Append("]");
            sb.Append(" WHERE ");
            for (int i = 0; i < keyFields.Count; i++)
            {
                sb.Append(keyFields[i]).Append(" = ? ");
                if (i + 1 < keyFields.Count)
                    sb.Append(" AND ");
            }
            return sb.ToString();
        }


        protected String BuildInsertSqlStatement(String tableName, List<String> insertFields, List<String> keyFields)
        {
            var sb = new StringBuilder("INSERT INTO ");
            sb.Append("[").Append(tableName).Append("]");
            sb.Append(" ( ");
            for (int i = 0; i < insertFields.Count; i++)
            {
                sb.Append("[").Append(insertFields[i]).Append("]");
                sb.Append(", ");
            }
            if (_includeKeyOnInsert)
            {
                for (int i = 0; i < keyFields.Count; i++)
                {
                    sb.Append("[").Append(keyFields[i]).Append("]");
                    sb.Append(", ");
                }
            }
            if (sb.ToString().EndsWith(", "))
                sb.Length = sb.Length - 2;

            sb.Append(" ) VALUES ( ");
            for (int i = 0; i < insertFields.Count; i++)
            {
                sb.Append("?, ");
            }
            if (_includeKeyOnInsert)
            {
                for (int i = 0; i < keyFields.Count; i++)
                {
                    sb.Append("?, ");
                }
            }
            if (sb.ToString().EndsWith(", "))
                sb.Length = sb.Length - 2;

            sb.Append(" )");
            return sb.ToString();
        }

        protected String builSelectSQLStatement(String tableName, String[] selectFields, String[] keyFields)
        {
            return builSelectSQLStatement(tableName, selectFields, keyFields, new String[] {});
        }

        protected String builSelectSQLStatement(String tableName, String[] selectFields, String[] keyFields,
            String[] orderFields)
        {
            var sb = new StringBuilder("SELECT ");
            for (int i = 0; i < selectFields.Length; i++)
            {
                sb.Append(selectFields[i]);
                if (i + 1 < selectFields.Length)
                    sb.Append(", ");
            }
            sb.Append(" FROM ").Append("[").Append(tableName).Append("]");
            if (keyFields.Length > 0)
            {
                sb.Append(" WHERE ");
                for (int i = 0; i < keyFields.Length; i++)
                {
                    sb.Append(keyFields[i]).Append(" = ? ");
                    if (i + 1 < keyFields.Length)
                        sb.Append(" AND ");
                }
            }
            if (orderFields.Length > 0)
            {
                sb.Append(" ORDER BY ");
                for (int i = 0; i < orderFields.Length; i++)
                {
                    sb.Append(orderFields[i]);
                    if (i + 1 < orderFields.Length)
                        sb.Append(", ");
                }
            }

            return sb.ToString();
        }

        public object Insert(BASEBean obj)
        {
            String sql = BuildInsertSqlStatement(obj.TableName, obj.FieldNames, obj.Keys);
            OleDbParameter[] parameters = obj.InsertValues;
            return ExecuteSqlCommand(sql, parameters);
        }

        public object Update(BASEBean obj)
        {
            String sql = BuildUpdateSqlStatement(obj.TableName, obj.FieldNames, obj.Keys);
            OleDbParameter[] parameters = obj.UpdateValues;
            return ExecuteSqlCommand(sql, parameters);
        }

        public void Delete(BASEBean obj)
        {
            String sql = BuildDeleteSqlStatement(obj.TableName, obj.Keys);
            OleDbParameter[] parameters = obj.KeyValues;
            ExecuteSqlCommand(sql, parameters);
        }

        public static void ReConnect()
        {
            ConnectionManager.GetInstance().Reconnect();
        }
    }

    internal class ConnectionManager
    {
        private static ConnectionManager instance;

        private OleDbConnection _connection;
        private String accessConnection;
        private OleDbTransaction transaction;

        private ConnectionManager()
        {
            Valid = false;
            Connect();
        }

        public bool Valid { get; set; }

        public void Close()
        {
            if (_connection != null)
                _connection.Close();
        }

        private void Connect()
        {
            string fullFileName = Path.Combine(ATMLContext.DB_PATH, ATMLContext.DB_NAME);
            Connect(fullFileName);
        }

        private void Connect(string fullFileName)
        {
            accessConnection = "Provider="
                               + ATMLContext.DB_PROVIDER
                               + "; Data Source="
                               + fullFileName + "; Mode=Share Deny None";
            try
            {
                _connection = new OleDbConnection(accessConnection);
                _connection.Open();
                ATMLContext.DB_PATH = Path.GetDirectoryName(fullFileName);
                Valid = true;
            }
            catch (Exception e)
            {
                if (DialogResult.Yes ==
                    MessageBox.Show(
                        "An error has occured attempting to open database \"" +
                        fullFileName + ".\" \r\nERROR: " + e.Message +
                        "\r\n\r\nWould you like to find another database file to open?",
                        "ERROR",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Error))
                {
                    var dlg = new OpenFileDialog();
                    dlg.Filter = "Access Database Files (.accdb)|*.accdb|All Files (*.*)|*.*";
                    dlg.FilterIndex = 1;
                    dlg.Multiselect = false;
                    dlg.RestoreDirectory = false;
                    if (DialogResult.OK == dlg.ShowDialog())
                    {
                        Connect(dlg.FileName);
                    }
                    else
                    {
                        Application.Exit();
                    }
                }
                else
                {
                    Application.Exit();
                }
            }
        }

        public bool IsInTransaction {get { return transaction != null; }}

        public void StartTransaction()
        {
            transaction = _connection.BeginTransaction();
        }

        public void EndTransaction()
        {
            if (transaction != null)
                transaction.Dispose();
            transaction = null;
        }

        public void CommitTransaction()
        {
            if (transaction != null)
                transaction.Commit();
        }

        public void RollbackTransaction()
        {
            if (transaction != null)
                transaction.Rollback();
        }

        public void Reconnect()
        {
            _connection.Close();
            Connect();
        }

        public static ConnectionManager GetInstance()
        {
            if (instance == null)
            {
                instance = new ConnectionManager();
            }
            return instance;
        }


        public object ExecuteSqlCommand(String sqlCommand, OleDbParameter[] parameters)
        {
            object key = null;
            try
            {
                var command = new OleDbCommand(sqlCommand, _connection);
                if (transaction != null)
                    command.Transaction = transaction;
                foreach (OleDbParameter parameter in parameters)
                    command.Parameters.Add(parameter);
                int count = command.ExecuteNonQuery();
                command.CommandText = "Select @@Identity";
                key = command.ExecuteScalar();
                command.Parameters.Clear();
                command.Dispose();
            }
            catch (Exception e)
            {
                string msg = string.Format("Error executing SQL - Error: {0}\r\n  SQL: \"{1}\"\r\n Parameters: {2}", e.Message, sqlCommand, OleParametersToString(parameters));
                throw new Exception(msg, e);
            }
            return key;
        }

        public object ExecuteSqlCommand(String sqlCommand, OleDbParameter[] parameters, out int count )
        {
            object key = null;
            try
            {
                var command = new OleDbCommand(sqlCommand, _connection);
                if (transaction != null)
                    command.Transaction = transaction;
                foreach (OleDbParameter parameter in parameters)
                    command.Parameters.Add(parameter);
                count = command.ExecuteNonQuery();
                command.CommandText = "Select @@Identity";
                key = command.ExecuteScalar();
                command.Parameters.Clear();
                command.Dispose();
            }
            catch (Exception e)
            {
                string msg = string.Format("Error executing SQL - Error: {0}\r\n  SQL: \"{1}\"\r\n Parameters: {2}", e.Message, sqlCommand, OleParametersToString(parameters));
                throw new Exception(msg, e);
            }

            return key;
        }


        public OleDbDataReader ExecuteSqlQuery(String sqlSelect, OleDbParameter[] parameters)
        {
            OleDbDataReader reader = null;
            try
            {
                if (_connection.State != ConnectionState.Closed && _connection.State != ConnectionState.Broken)
                {
                    var command = new OleDbCommand(sqlSelect, _connection);
                    if (transaction != null)
                        command.Transaction = transaction;
                    foreach (OleDbParameter parameter in parameters)
                        command.Parameters.Add(parameter);
                    reader = command.ExecuteReader();
                    command.Dispose();
                }
            }
            catch (Exception e)
            {
                string msg = string.Format("Error executing SQL - Error: {0}\r\n  SQL: \"{1}\"\r\n Parameters: {2}", e.Message, sqlSelect, OleParametersToString(parameters));
                throw new Exception(msg, e);
            }
            return reader;
        }

        public void ExecuteSqlQuery(String sqlSelect, OleDbParameter[] parameters, List<BASEBean> list, Type type)
        {
            var command = new OleDbCommand(sqlSelect, _connection);
            if (transaction != null)
                command.Transaction = transaction;
            foreach (OleDbParameter parameter in parameters)
                command.Parameters.Add(parameter);
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
            }
            command.Dispose();
        }

        private string OleParametersToString( OleDbParameter[] parameters )
        {
            StringBuilder sb = new StringBuilder();
            foreach (OleDbParameter oleDbParameter in parameters)
                sb.Append( oleDbParameter.ParameterName ).Append( "=" ).Append( oleDbParameter.Value ).Append( ", " );
            if( sb.ToString().EndsWith( ", " ) )
                sb.Length = sb.Length - 2;
            return sb.ToString();
        }
    }
}