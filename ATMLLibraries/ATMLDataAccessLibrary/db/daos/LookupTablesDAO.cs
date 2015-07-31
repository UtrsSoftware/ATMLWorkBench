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
using ATMLDataAccessLibrary.db.beans;
using ATMLDataAccessLibrary.model;

namespace ATMLDataAccessLibrary.db.daos
{
    public class LookupTablesDAO : DAO
    {
        private const string TRUE = "Y";
        private const string ALL = "*";

        public List<dbCountry> getActiveCountries()
        {
            var parameters = new[] { new OleDbParameter(dbCountry._ACTIVE_FLAG, TRUE) };
            List<dbCountry> list =
                CreateList<dbCountry>(
                    BuildSqlSelect(dbCountry._TABLE_NAME, new String[] { ALL }, new String[] { dbCountry._ACTIVE_FLAG }),
                    parameters);
            foreach (dbCountry country in list)
            {
                country.States = getCountryStates(country.countryCode);
            }
            return list;
        }

        public List<dbState> getCountryStates(String countryCode)
        {
            var parameters = new OleDbParameter[] {new OleDbParameter(dbState._COUNTRY_CODE, countryCode)};
            return
                CreateList<dbState>(
                    BuildSqlSelect(dbState._TABLE_NAME, new String[] { ALL }, new String[] { dbState._COUNTRY_CODE }),
                    parameters);
        }

        public List<DocumentType> getDocumentTypes()
        {
            var parameters = new OleDbParameter[] {};
            return
                CreateList<DocumentType>(
                    BuildSqlSelect(DocumentType._TABLE_NAME, new String[] { ALL }, new String[] { }), parameters);
        }


        public List<LuNamespaceBean> getNamespaceLookup()
        {
            var parameters = new OleDbParameter[] { };
            return
                CreateList<LuNamespaceBean>(
                    BuildSqlSelect(LuNamespaceBean._TABLE_NAME, new String[] { ALL }, new String[] { }), parameters);
        }
    }
}