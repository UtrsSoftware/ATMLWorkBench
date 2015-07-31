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
using ATMLDataAccessLibrary.db.daos;

namespace ATMLDataAccessLibrary.model
{
    public class dbConnectorConfiguration : LuConnectorConfigurationBean
    {
        private List<dbConnectorPin> pins = new List<dbConnectorPin>();

        public List<dbConnectorPin> Pins
        {
            get { return pins; }
            set { pins = value; }
        }


        public dbConnectorConfiguration()
        {
            DataState = eDataState.DS_NO_CHANGE;
        }

        public override string ToString()
        {
            return this.configName;
        }

        public override void save()
        {
            base.save();
            EquipmentDAO dao = new EquipmentDAO();
            dao.deleteConnectorPins( ID );
            foreach (dbConnectorPin pin in pins)
            {
                pin.IncludeKeyOnInsert = true;
                pin.DataState = eDataState.DS_ADD;
                pin.save();
            }
        }
    }
}
