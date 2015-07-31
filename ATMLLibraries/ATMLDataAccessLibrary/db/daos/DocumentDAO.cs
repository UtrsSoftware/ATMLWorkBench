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
using System.Windows.Forms;
using ATMLDataAccessLibrary.db.beans;
using ATMLDataAccessLibrary.model;

namespace ATMLDataAccessLibrary.db.daos
{
    public class DocumentDAO : DAO
    {
        public dbDocument openDatabaseDocument(String uuid)
        {
            dbDocument document = null;
            Guid guid;
            if (Guid.TryParse( uuid, out guid ))
            {
                var parameters = new[] {new OleDbParameter( dbDocument._UUID, guid )};
                document = CreateBean<dbDocument>(
                    BuildSqlSelect(DocumentBean._TABLE_NAME, new[] { "*" }, new[] { DocumentBean._UUID }), parameters);
                if (document != null)
                    document.DataState = BASEBean.eDataState.DS_NO_CHANGE;
            }
            return document;
        }

        public dbDocument openDatabaseDocumentByName(String fileName)
        {
            var parameters = new[] { new OleDbParameter(dbDocument._DOCUMENT_NAME, fileName) };
            dbDocument document = CreateBean<dbDocument>(
                BuildSqlSelect(dbDocument._TABLE_NAME, new[] { "*" }, new[] { dbDocument._DOCUMENT_NAME }), parameters);
            if( document != null )
                document.DataState = BASEBean.eDataState.DS_NO_CHANGE;
            return document;
        }

        public dbDocument openDatabaseDocument(string fileName, int documentType)
        {
            var parameters = new[] { new OleDbParameter(dbDocument._DOCUMENT_NAME, fileName), 
                                     new OleDbParameter(dbDocument._DOCUMENT_TYPE_ID, documentType) };
            dbDocument document = CreateBean<dbDocument>(
                BuildSqlSelect(dbDocument._TABLE_NAME, new[] { "*" }, new[] { dbDocument._DOCUMENT_NAME, dbDocument._DOCUMENT_TYPE_ID }), parameters);
            if (document != null)
                document.DataState = BASEBean.eDataState.DS_NO_CHANGE;
            return document;
        }


        public bool hasDocument(String uuid)
        {
            Int32 count = 0;
            String sql = "SELECT count(*) FROM " + DocumentBean._TABLE_NAME + " WHERE " + DocumentBean._UUID + "=?";
            OleDbParameter[] parameters = {new OleDbParameter(DocumentBean._UUID, Guid.Parse(uuid))};
            OleDbDataReader reader = ExecuteSqlQuery(sql, parameters);
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


        public bool hasDocument(string fileName, int documentType )
        {
            Int32 count = 0;
            String sql = "SELECT count(*) FROM " 
                + DocumentBean._TABLE_NAME 
                + " WHERE " 
                + DocumentBean._DOCUMENT_NAME 
                + "=? AND " 
                + DocumentBean._DOCUMENT_TYPE_ID 
                + "=?";
            OleDbParameter[] parameters = { new OleDbParameter(DocumentBean._DOCUMENT_NAME, fileName), 
                                            new OleDbParameter(DocumentBean._DOCUMENT_TYPE_ID, documentType) };
            OleDbDataReader reader = ExecuteSqlQuery(sql, parameters);
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


        /**
         * Returns a list of dbDocument objects where their document type id are the same as the one provided.
         *
         */

        public List<dbDocument> GetDocumentsByType(int documentTypeId)
        {
            String sql = BuildSqlSelect(DocumentBean._TABLE_NAME, new[] {"*"}, new[] {DocumentBean._DOCUMENT_TYPE_ID});
            var parameters = new[]
            {new OleDbParameter(DocumentBean._DOCUMENT_TYPE_ID, documentTypeId)};
            return CreateList<dbDocument>(sql, parameters);
        }


        public Dictionary<object, AssetIdentificationBean> GetAssetsByUuid(string uuid)
        {
            var list = new Dictionary<object, AssetIdentificationBean>();
            string sql = string.Format("SELECT ID, asset_type, TRIM(asset_number) as asset_number, uuid FROM {0} WHERE {1}=?",
                                        AssetIdentificationBean._TABLE_NAME,
                                        AssetIdentificationBean._UUID);
            OleDbParameter[] parameters = { new OleDbParameter(AssetIdentificationBean._UUID, Guid.Parse(uuid)) };
            return CreateMap<AssetIdentificationBean>(sql, parameters, AssetIdentificationBean._ASSET_NUMBER );
        }


        public object RemoveAssets( string uuid )
        {
            string sql = string.Format( "DELETE * FROM {0} WHERE {1}=?", 
                                        AssetIdentificationBean._TABLE_NAME,
                                        AssetIdentificationBean._UUID );
            OleDbParameter[] parameters = { new OleDbParameter(AssetIdentificationBean._UUID, Guid.Parse(uuid)) };
            return ExecuteSqlCommand( sql, parameters );
        }

        public object RemoveAsset(string assetNumber, string uuid)
        {
            string sql = string.Format("DELETE * FROM {0} WHERE {1}=? AND {2}=?",
                                        AssetIdentificationBean._TABLE_NAME,
                                        AssetIdentificationBean._UUID, 
                                        AssetIdentificationBean._ASSET_NUMBER);
            OleDbParameter[] parameters = { new OleDbParameter(AssetIdentificationBean._UUID, Guid.Parse(uuid)), 
                                            new OleDbParameter(AssetIdentificationBean._ASSET_NUMBER, assetNumber) };
            return ExecuteSqlCommand(sql, parameters);
        }


        public AssetIdentificationBean FindAsset(String type, String number, String uuid)
        {
            string sql = builSelectSQLStatement(AssetIdentificationBean._TABLE_NAME,
                new[] {"*"},
                new[]
                {
                    AssetIdentificationBean._ASSET_NUMBER,
                    AssetIdentificationBean._ASSET_TYPE,
                    AssetIdentificationBean._UUID
                });
            OleDbParameter[] parameters = { new OleDbParameter(AssetIdentificationBean._ASSET_NUMBER, number), 
                                            new OleDbParameter(AssetIdentificationBean._ASSET_TYPE, type),
                                            new OleDbParameter(AssetIdentificationBean._UUID, Guid.Parse(uuid))
                                          };

            return CreateBean<AssetIdentificationBean>(sql, parameters);
        }

        public AssetIdentificationBean FindAsset(String type, String number )
        {
            string sql = builSelectSQLStatement(AssetIdentificationBean._TABLE_NAME,
                new[] { "*" },
                new[]
                {
                    AssetIdentificationBean._ASSET_NUMBER,
                    AssetIdentificationBean._ASSET_TYPE
                });
            OleDbParameter[] parameters = { new OleDbParameter(AssetIdentificationBean._ASSET_NUMBER, number), 
                                            new OleDbParameter(AssetIdentificationBean._ASSET_TYPE, type)
                                          };

            return CreateBean<AssetIdentificationBean>(sql, parameters);
        }


        public AssetIdentificationBean FindAsset(String number)
        {
            string sql = builSelectSQLStatement(AssetIdentificationBean._TABLE_NAME,
                new[] { "*" },
                new[]
                {
                    AssetIdentificationBean._UUID
                });
            OleDbParameter[] parameters = { new OleDbParameter(AssetIdentificationBean._ASSET_NUMBER, number) 
                                          };

            return CreateBean<AssetIdentificationBean>(sql, parameters);
        }


        public Boolean HasAsset(String type, String number, String uuid)
        {
            int count = 0;
            string sql = builSelectSQLStatement(AssetIdentificationBean._TABLE_NAME,
                new[] { "count(*) as _count" },
                new[]
                {
                    AssetIdentificationBean._ASSET_NUMBER,
                    //AssetIdentificationBean._ASSET_TYPE,
                    AssetIdentificationBean._UUID
                });
            OleDbParameter[] parameters = { new OleDbParameter(AssetIdentificationBean._ASSET_NUMBER, number), 
                                            //new OleDbParameter(AssetIdentificationBean._ASSET_TYPE, type),
                                            new OleDbParameter(AssetIdentificationBean._UUID, Guid.Parse(uuid))
                                          };

            OleDbDataReader reader = ExecuteSqlQuery(sql, parameters);
            if (reader != null)
            {
                if (reader.Read())
                {
                    count = (int) reader["_count"];
                }
                reader.Close();
                reader.Dispose();
            }
            return count > 0;
        }

        public int DeleteAssets( string uuid )
        {
            int count = 0;
            string sql = BuildDeleteSqlStatement( AssetIdentificationBean._TABLE_NAME,
                                                  new List<string>() {AssetIdentificationBean._UUID} );
            OleDbParameter[] parameters = { new OleDbParameter(AssetIdentificationBean._UUID, Guid.Parse(uuid)) };
            ExecuteSqlCommand( sql, parameters, out count );
            return count;
        }

        public Boolean HasAssets(String uuid)
        {
            int count = 0;
            string sql = builSelectSQLStatement(AssetIdentificationBean._TABLE_NAME,
                new[] { "count(*) as _count" },
                new[]
                {
                    AssetIdentificationBean._UUID
                });
            OleDbParameter[] parameters = { new OleDbParameter(AssetIdentificationBean._UUID, Guid.Parse(uuid)) };

            OleDbDataReader reader = ExecuteSqlQuery(sql, parameters);
            if (reader != null)
            {
                if (reader.Read())
                {
                    count = (int)reader["_count"];
                }
                reader.Close();
                reader.Dispose();
            }
            return count > 0;
        }



    }
}