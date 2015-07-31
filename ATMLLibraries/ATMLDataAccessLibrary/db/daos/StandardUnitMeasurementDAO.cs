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
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using ATMLDataAccessLibrary.db.beans;
using ATMLDataAccessLibrary.model;

namespace ATMLDataAccessLibrary.db.daos
{
    public class StandardUnitMeasurementDAO : DAO
    {


        public List<StandardUnitPrefixBean> getAllStandardUnitPrefixBeans()
        {
            OleDbParameter[] parameters = new OleDbParameter[] { };
            return CreateList<StandardUnitPrefixBean>(BuildSqlSelect( StandardUnitPrefixBean._TABLE_NAME,
                                                                      new String[] { "*" },
                                                                      new String[] { }),
                                                                      parameters);
        }


        public List<StandardUnitMeasurementBean> getAllStandardUnitMeasurementBeans()
        {
            OleDbParameter[] parameters = new OleDbParameter[] { };
            return CreateList<StandardUnitMeasurementBean>( BuildSqlSelect( StandardUnitMeasurementBean._TABLE_NAME, 
                                                                            new String[] { "*" }, 
                                                                            new String[] { } ), 
                                                                            parameters);
        }

        public List<StandardUnitMeasurementBean> getAllActiveStandardUnitMeasurementBeans()
        {
            OleDbParameter[] parameters = new OleDbParameter[] {};
            return CreateList<StandardUnitMeasurementBean>(  "SELECT * FROM " 
                                                            + StandardUnitMeasurementBean._TABLE_NAME
                                                            + " WHERE ("
                                                            + StandardUnitMeasurementBean._DEPRECATED
                                                            + " <> 'Y' OR "
                                                            + StandardUnitMeasurementBean._DEPRECATED
                                                            + " IS NULL ) AND ( "
                                                            + StandardUnitMeasurementBean._PREFIX
                                                            + " <> 'Y' OR "
                                                            + StandardUnitMeasurementBean._PREFIX
                                                            + " IS NULL ) "
                                                            , parameters);
        }


        public List<StandardUnitMeasurementBean> getLimitsActiveStandardUnitMeasurementBeans()
        {
            OleDbParameter[] parameters = new OleDbParameter[] { };
            return CreateList<StandardUnitMeasurementBean>("SELECT * FROM "
                                                            + StandardUnitMeasurementBean._TABLE_NAME
                                                            + " WHERE ("
                                                            + StandardUnitMeasurementBean._DEPRECATED
                                                            + " <> 'Y' OR "
                                                            + StandardUnitMeasurementBean._DEPRECATED
                                                            + " IS NULL ) AND ( "
                                                            + StandardUnitMeasurementBean._LIMIT_LIST
                                                            + " = 'Y' ) "
                                                            , parameters);
        }


        public List<StandardUnitMeasurementBean> getAllElectricalStandardUnitMeasurementBeans()
        {
            OleDbParameter[] parameters = new OleDbParameter[] { };
            return CreateList<StandardUnitMeasurementBean>("SELECT * FROM "
                                                            + StandardUnitMeasurementBean._TABLE_NAME
                                                            + " WHERE ("
                                                            + StandardUnitMeasurementBean._DEPRECATED
                                                            + " <> 'Y' OR "
                                                            + StandardUnitMeasurementBean._DEPRECATED
                                                            + " IS NULL ) "
                                                            + " AND "
                                                            + StandardUnitMeasurementBean._ELECTRICAL
                                                            + " = 'Y'"
                                                            , parameters);
        }

        public List<StandardUnitMeasurementBean> getAllOpticalStandardUnitMeasurementBeans()
        {
            OleDbParameter[] parameters = new OleDbParameter[] { };
            return CreateList<StandardUnitMeasurementBean>("SELECT * FROM "
                                                            + StandardUnitMeasurementBean._TABLE_NAME
                                                            + " WHERE ("
                                                            + StandardUnitMeasurementBean._DEPRECATED
                                                            + " <> 'Y' OR " 
                                                            + StandardUnitMeasurementBean._DEPRECATED 
                                                            + " IS NULL ) "
                                                            + " AND "
                                                            + StandardUnitMeasurementBean._OPTICAL
                                                            + " = 'Y'"                                                            
                                                            , parameters);
        }

        public List<StandardUnitMeasurementBean> getAllChemicalStandardUnitMeasurementBeans()
        {
            OleDbParameter[] parameters = new OleDbParameter[] { };
            return CreateList<StandardUnitMeasurementBean>("SELECT * FROM "
                                                            + StandardUnitMeasurementBean._TABLE_NAME
                                                            + " WHERE ("
                                                            + StandardUnitMeasurementBean._DEPRECATED
                                                            + " <> 'Y' OR "
                                                            + StandardUnitMeasurementBean._DEPRECATED
                                                            + " IS NULL ) "
                                                            + " AND "
                                                            + StandardUnitMeasurementBean._CHEMICAL
                                                            + " = 'Y'"
                                                            , parameters);
        }


        public void saveStandardUnitMeasurementBean(StandardUnitMeasurementBean bean)
        {
            bean.save();
        }
    }
}
