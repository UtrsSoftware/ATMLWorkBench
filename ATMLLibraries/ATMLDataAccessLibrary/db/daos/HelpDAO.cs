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
    public class HelpDAO : DAO
    {
        public List<HelpMessageBean> getHelpMessages()
        {
            OleDbParameter[] parameters = new OleDbParameter[] { };
            return CreateList<HelpMessageBean>(BuildSqlSelect(HelpMessageBean._TABLE_NAME, new String[] { "*" }, new String[] { }), parameters);
        }

    }
}
