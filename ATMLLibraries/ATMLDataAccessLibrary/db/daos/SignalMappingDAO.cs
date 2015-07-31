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
using System.Security.Policy;
using System.Xml;
using System.Text;
using System.Data.OleDb;
using ATMLDataAccessLibrary.model;
using ATMLDataAccessLibrary.db.beans;

namespace ATMLDataAccessLibrary.db.daos
{
    public class SignalMappingDAO : DAO
    {

        public SourceSignalMapBean GetMappedSignal(String sourceType, String sourceName )
        {
            String sql = string.Format("SELECT * FROM {0} WHERE {1} = ? AND {2} = ?",
                                        SourceSignalMapBean._TABLE_NAME,
                                        SourceSignalMapBean._SOURCE_TYPE, 
                                        SourceSignalMapBean._SOURCE_NAME);
            OleDbParameter[] dbParams = { CreateParameter(SourceSignalMapBean._SOURCE_TYPE, sourceType), CreateParameter(SourceSignalMapBean._SOURCE_NAME, sourceName) };
            return CreateBean<SourceSignalMapBean>(sql, dbParams);
        }

        public SourceSignalAttributeMapBean GetMappedSignalAttribute(String mapId, String sourceName )
        {
            String sql = string.Format("SELECT * FROM {0} WHERE {1} = ? AND {2} = ?",
                                        SourceSignalAttributeMapBean._TABLE_NAME,
                                        SourceSignalAttributeMapBean._MAP_ID,
                                        SourceSignalAttributeMapBean._SOURCE_NAME);
            OleDbParameter[] dbParams = { CreateParameter(SourceSignalAttributeMapBean._MAP_ID, mapId), 
                                            CreateParameter(SourceSignalAttributeMapBean._SOURCE_NAME, sourceName) };
            return CreateBean<SourceSignalAttributeMapBean>(sql, dbParams);
        }


        public Dictionary<string, Dictionary<object, SourceSignalAttributeMapBean>> BuildSignalMap(String sourceType)
        {
            String sql = string.Format("SELECT * FROM {0} WHERE {1} = ?  ORDER BY {2} ",
                                        SourceSignalMapBean._TABLE_NAME,
                                        SourceSignalMapBean._SOURCE_TYPE,
                                        SourceSignalMapBean._SOURCE_NAME );
            OleDbParameter[] dbParams = { CreateParameter(SourceSignalMapBean._SOURCE_TYPE, sourceType)};
            List<SourceSignalMapBean> list = CreateList<SourceSignalMapBean>(sql, dbParams);
            return list.ToDictionary( sourceSignalMapBean 
                => sourceSignalMapBean.sourceName, sourceSignalMapBean 
                    => BuildSignalAttributeMap( sourceSignalMapBean.id ) );
        }

        public List<SourceSignalMapBean> GetSourceSignals(String sourceType)
        {
            String sql = string.Format("SELECT * FROM {0} WHERE {1} = ? ORDER BY {2} ",
                                        SourceSignalMapBean._TABLE_NAME,
                                        SourceSignalMapBean._SOURCE_TYPE,
                                        SourceSignalMapBean._SOURCE_NAME );
            OleDbParameter[] dbParams = { CreateParameter(SourceSignalMapBean._SOURCE_TYPE, sourceType) };
            List<SourceSignalMapBean> list = CreateList<SourceSignalMapBean>(sql, dbParams);
            return list;
        }

        public Dictionary<object, SourceSignalAttributeMapBean> BuildSignalAttributeMap(Guid? mapId)
        {
            String sql = string.Format("SELECT * FROM {0} WHERE {1} = ? ORDER BY {2}",
                                        SourceSignalAttributeMapBean._TABLE_NAME,
                                        SourceSignalAttributeMapBean._MAP_ID,
                                        SourceSignalAttributeMapBean._SOURCE_NAME);
            OleDbParameter[] dbParams = { CreateParameter(SourceSignalAttributeMapBean._MAP_ID, mapId) };

            List<SourceSignalAttributeMapBean> list = CreateList<SourceSignalAttributeMapBean>(sql, dbParams);
            return CreateMap<SourceSignalAttributeMapBean>(sql, dbParams, SourceSignalAttributeMapBean._SOURCE_NAME );
        }

        public List<SourceSignalAttributeMapBean> GetSignalAttributes(Guid? mapId)
        {
            String sql = string.Format("SELECT * FROM {0} WHERE {1} = ? ORDER BY {2}",
                                        SourceSignalAttributeMapBean._TABLE_NAME,
                                        SourceSignalAttributeMapBean._MAP_ID, 
                                        SourceSignalAttributeMapBean._SOURCE_NAME );
            OleDbParameter[] dbParams = { CreateParameter(SourceSignalAttributeMapBean._MAP_ID, mapId) };
            List<SourceSignalAttributeMapBean> list = CreateList<SourceSignalAttributeMapBean>(sql, dbParams);
            return list;
        }


    }
}
