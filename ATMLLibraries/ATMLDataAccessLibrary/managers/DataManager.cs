/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System.Runtime.CompilerServices;
using ATMLDataAccessLibrary.db.daos;

namespace ATMLDataAccessLibrary.managers
{
    /**
     * The DataManager provides a central location to obtain the data access objects required for the application.
     *@author Paul Garrison
     *@date January 2014
     */

    public class DataManager
    {
        private static DataManager instance;
        private readonly DocumentDAO documentDAO;

        private readonly EquipmentDAO equpmentDAO;
        private readonly HelpDAO helpDAO;
        private readonly LookupTablesDAO lookupTablesDAO;
        private readonly SchemaDAO schemaDAO;
        private readonly SignalDAO signalDAO;
        private readonly StandardUnitMeasurementDAO standardUnitMeasurementDAO;
        private DataManager()
        {
            equpmentDAO = new EquipmentDAO();
            signalDAO = new SignalDAO();
            helpDAO = new HelpDAO();
            standardUnitMeasurementDAO = new StandardUnitMeasurementDAO();
            lookupTablesDAO = new LookupTablesDAO();
            documentDAO = new DocumentDAO();
            schemaDAO = new SchemaDAO();
        }


        public static SchemaDAO getSchemaDAO()
        {
            return getInstance().schemaDAO;
        }

        public static DocumentDAO getDocumentDAO()
        {
            return getInstance().documentDAO;
        }

        /**
         * Returns a data access object for Equipment related tables.
         * @return EquipmentDAO
         */
        public static EquipmentDAO getEquipmentDAO()
        {
            return getInstance().equpmentDAO;
        }

        /**
         * Returns a data access object for Signal related tables.
         * @return SignalDAO
         */
        public static SignalDAO getSignalDAO()
        {
            return getInstance().signalDAO;
        }

        /**
         * Returns a data access object for Help related tables.
         * @return HelpDAO
         */
        public static HelpDAO getHelpDAO()
        {
            return getInstance().helpDAO;
        }

        /**
         * Returns a data access object for Lookup related tables.
         * @return LookupTablesDAO
         */
        public static LookupTablesDAO getLookupTablesDAO()
        {
            return getInstance().lookupTablesDAO;
        }

        /**
         * Returns a data access object for Stsndard Units of Measurement tables.
         * @return StandardUnitMeasurementDAO
         */
        public static StandardUnitMeasurementDAO getStandardUnitMeasurementDAO()
        {
            return getInstance().standardUnitMeasurementDAO;
        }

        [MethodImpl( MethodImplOptions.Synchronized )]
        protected static DataManager getInstance()
        {
            if (instance == null)
            {
                instance = new DataManager();
            }
            return instance;
        }
    }
}