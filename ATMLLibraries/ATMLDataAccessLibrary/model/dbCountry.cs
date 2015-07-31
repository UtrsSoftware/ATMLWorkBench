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
using ATMLDataAccessLibrary.db.beans;

namespace ATMLDataAccessLibrary.model
{
    public class dbCountry : LuCountryBean
    {
        private List<dbState> states = new List<dbState>();

        public List<dbState> States
        {
            get { return states; }
            set { states = value; }
        }

        public override void load(System.Data.OleDb.OleDbDataReader reader)
        {
            base.load(reader);
        }

        public override string ToString()
        {
            return base.countryName;
        }
    }
}
