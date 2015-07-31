/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using ATMLDataAccessLibrary.db.beans;
using ATMLDataAccessLibrary.model;

namespace ATMLDataAccessLibrary.db.daos
{
    public class SchemaDAO : DAO
    {

        public bool hasSchema(String schemaNamespace)
        {
            int count = 0;
            String sql = this.builSelectSQLStatement(SchemasBean._TABLE_NAME, 
                                                     new String[] { "count(*)" }, 
                                                     new String[] { SchemasBean._SCHEMA_NAMESPACE });
            OleDbParameter[] dbParams = { CreateParameter(SchemasBean._SCHEMA_NAMESPACE, schemaNamespace) };
            OleDbDataReader reader = ExecuteSqlQuery(sql, dbParams);
            if (reader != null)
            {
                if (reader.Read())
                {
                    count = reader.GetInt32(0);
                }
                reader.Close();
                reader.Dispose();
            }
            return count > 0;
        }

        public SchemasBean getSchema(String schemaNamespace)
        {
            SchemasBean bean = null;
            String sql = this.builSelectSQLStatement(SchemasBean._TABLE_NAME,
                                                     new String[] { "*" },
                                                     new String[] { SchemasBean._SCHEMA_NAMESPACE });
            OleDbParameter[] dbParams = { CreateParameter(SchemasBean._SCHEMA_NAMESPACE, schemaNamespace) };
            OleDbDataReader reader = ExecuteSqlQuery(sql, dbParams);
            if (reader != null)
            {
                if (reader.Read())
                {
                    bean = new SchemasBean();
                    bean.load(reader);
                }
                reader.Close();
                reader.Dispose();
            }
            return bean;
        }


        public List<DocumentBean> GetSchemas()
        {
            DocumentBean bean = null;
            List<DocumentBean> list = new List<DocumentBean>();
            String sql = this.builSelectSQLStatement(DocumentBean._TABLE_NAME,
                                                     new String[] { "*" },
                                                     new String[] { DocumentBean._DOCUMENT_TYPE_ID });
            OleDbParameter[] dbParams = { CreateParameter(DocumentBean._DOCUMENT_TYPE_ID, (int)dbDocument.DocumentType.XML_SCHEMA ) };
            OleDbDataReader reader = ExecuteSqlQuery(sql, dbParams);
            if (reader != null)
            {
                while (reader.Read())
                {
                    bean = new DocumentBean();
                    bean.load(reader);
                    list.Add(bean);
                }
                reader.Close();
                reader.Dispose();
            }
            return list;
        }

    }
}
