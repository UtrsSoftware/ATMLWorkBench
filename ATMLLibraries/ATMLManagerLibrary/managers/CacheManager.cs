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
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ATMLDataAccessLibrary.db.beans;
using ATMLDataAccessLibrary.db.daos;
using ATMLDataAccessLibrary.managers;
using ATMLDataAccessLibrary.model;

namespace ATMLManagerLibrary.managers
{
    /**
     * Provides an interface into common cached data. Caches are loaded at the time of object construction and statically maintained.
     * The CacheManager is implemented as a Singleton where the entire application shares a single CacheManager instance.
     * @author Paul Garrison
     * @date December 2013
     */

    public class CacheManager
    {
        private static CacheManager _instance;

        private readonly Dictionary<String, Cache> cacheMap = new Dictionary<string, Cache>();

        private CacheManager()
        {
            EquipmentDAO equipmentDAO = DataManager.getEquipmentDAO();
            HelpDAO helpDAO = DataManager.getHelpDAO();
            StandardUnitMeasurementDAO sumDAO = DataManager.getStandardUnitMeasurementDAO();
            SignalDAO signalDAO = DataManager.getSignalDAO();
            LookupTablesDAO lookupTablesDAO = DataManager.getLookupTablesDAO();
            loadCacheItem<dbConnector>(equipmentDAO, LuConnectorBean._TABLE_NAME, 
                "getConnectors", LuConnectorBean._CONNECTOR_TYPE);
            loadCacheItem<LuNamespaceBean>(lookupTablesDAO, LuNamespaceBean._TABLE_NAME,
                "getNamespaceLookup", LuNamespaceBean._XMLNS);
            loadCacheItem<HelpMessageBean>(helpDAO, HelpMessageBean._TABLE_NAME, 
                "getHelpMessages", HelpMessageBean._MESSAGE_KEY);
            loadCacheItem<StandardUnitMeasurementBean>(sumDAO, StandardUnitMeasurementBean._TABLE_NAME,
                "getLimitsActiveStandardUnitMeasurementBeans", StandardUnitMeasurementBean._ID);
            loadCacheItem<StandardUnitPrefixBean>(sumDAO, StandardUnitPrefixBean._TABLE_NAME,
                "getAllStandardUnitPrefixBeans", StandardUnitPrefixBean._ID);
            loadCacheItem<dbSignal>(signalDAO, SignalMasterBean._TABLE_NAME, 
                "getAllSignals", SignalMasterBean._SIGNAL_ID);
            loadCacheItem<dbSignal>(signalDAO, TestSignalLibraryBean._TABLE_NAME,
                "GetAllTsfSignals", SignalMasterBean._SIGNAL_ID);
            loadCacheItem<dbCountry>(lookupTablesDAO, LuCountryBean._TABLE_NAME, 
                "getActiveCountries", LuCountryBean._COUNTRY_CODE);
            loadCacheItem<DocumentType>(lookupTablesDAO, LuDocumentTypeBean._TABLE_NAME, 
                "getDocumentTypes", LuDocumentTypeBean._TYPE_ID);
        }

        private void loadCacheItem<T>(DAO dao, String cacheName, String methodName, String keyName) where T : BASEBean
        {
            try
            {
                var connectorCache = new Cache(cacheName);
                MethodInfo method = dao.GetType().GetMethod(methodName);
                var list = (List<T>) method.Invoke(dao, null);
                foreach (T item in list)
                    connectorCache.addCacheItem(item.FieldMap[keyName].ToString(), item);
                if (!cacheMap.ContainsKey(connectorCache.Name))
                {
                    cacheMap.Add(connectorCache.Name, connectorCache);
                }
                else
                {
                    LogManager.Warn(string.Format("Duplicate cache name: \"{0}\" found and ignored", connectorCache.Name));
                }
            }
            catch (Exception e)
            {
                LogManager.Error(e);
            }
        }

        /**
         * Returns a Cache object determined by the name provided. If no cache exists for the name provided, an Exception will be thrown.
         * @param name The name of the Cache object to return
         * @throws Exception if the cache object does not exist for the name provided.
         */

        public static Cache getCache(String name)
        {
            if (!getInstance().cacheMap.ContainsKey(name))
                throw new Exception(String.Format(MessageManager.getMessage("CacheManager.noCacheError"), name));
            return getInstance().cacheMap[name];
        }

        public static Cache GetStandardUnitMeasurementCache()
        {
            return getCache(StandardUnitMeasurementBean._TABLE_NAME);
        }

        public static Cache GetTsfSignalCache()
        {
            return getCache(TestSignalLibraryBean._TABLE_NAME);
        }

        public static void LoadStandardUnitMeasurementComboBox(ComboBox comboBox)
        {
            Cache cache = getCache(StandardUnitMeasurementBean._TABLE_NAME);
            comboBox.DataSource = cache.getCacheValues().Cast<StandardUnitMeasurementBean>().ToList();
            comboBox.ValueMember = "symbol";
            comboBox.DisplayMember = "unit";
            comboBox.SelectedIndex = -1;
        }

        public static void LoadStandardUnitMeasurementComboBox(DataGridViewComboBoxColumn comboBox)
        {
            Cache cache = getCache(StandardUnitMeasurementBean._TABLE_NAME);
            comboBox.DataSource = cache.getCacheValues().Cast<StandardUnitMeasurementBean>().ToList();
            comboBox.ValueMember = "symbol";
            comboBox.DisplayMember = "unit";
        }


        public static Cache GetStandardUnitPrefixCache()
        {
            return getCache(StandardUnitPrefixBean._TABLE_NAME);
        }

        public static void LoadStandardUnitPrefixComboBox(ComboBox comboBox)
        {
            Cache cache = getCache(StandardUnitPrefixBean._TABLE_NAME);
            comboBox.DataSource = cache.getCacheValues().Cast<StandardUnitPrefixBean>().ToList();
            comboBox.ValueMember = "symbol";
            comboBox.DisplayMember = "siPrefix";
            comboBox.SelectedIndex = -1;
        }

        public static void LoadStandardUnitPrefixComboBox(DataGridViewComboBoxColumn comboBox)
        {
            Cache cache = getCache(StandardUnitPrefixBean._TABLE_NAME);
            comboBox.DataSource = cache.getCacheValues().Cast<StandardUnitPrefixBean>().ToList();
            comboBox.ValueMember = "symbol";
            comboBox.DisplayMember = "siPrefix";
        }


        public static Cache GetDocumentTypeCache()
        {
            return getCache(LuDocumentTypeBean._TABLE_NAME);
        }

        public static Cache GetNamespaceCache()
        {
            return getCache(LuNamespaceBean._TABLE_NAME);
        }

        public static void LoadDocumentTypeComboBox(ComboBox comboBox)
        {
            Cache cache = getCache(LuDocumentTypeBean._TABLE_NAME);
            comboBox.DataSource = cache.getCacheValues().Cast<LuDocumentTypeBean>().ToList();
            comboBox.ValueMember = "typeId";
            comboBox.DisplayMember = "typeName";
        }


        public static void LoadSignalTypeComboBox(ComboBox comboBox)
        {
            Cache cache = getCache(dbSignal._TABLE_NAME);
            comboBox.DataSource = cache.getCacheValues().Cast<dbSignal>().ToList();
            comboBox.ValueMember = "signalId";
            comboBox.DisplayMember = "signalName";
            comboBox.SelectedIndex = -1;
        }

        public static void LoadTsfSignalTypeComboBox(ComboBox comboBox)
        {
            Cache cache = getCache(TestSignalLibraryBean._TABLE_NAME);
            comboBox.DataSource = cache.getCacheValues().Cast<dbSignal>().ToList();
            comboBox.ValueMember = "signalId";
            comboBox.DisplayMember = "signalName";
            comboBox.SelectedIndex = -1;
        }

        public static void LoadDocumentTypeComboBox(ToolStripComboBox comboBox)
        {
            Cache cache = GetDocumentTypeCache();
            comboBox.Items.Clear();
            comboBox.Items.AddRange(cache.getCacheValues().Cast<DocumentType>().ToArray<object>());
        }


        /**
         * Returns the instance of the CacheManager object.
         */

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static CacheManager getInstance()
        {
            if (_instance == null)
            {
                _instance = new CacheManager();
            }

            return _instance;
        }
    }

    /**
     * A Cache object is a collection of data beans that have been extended from the BASEBean base class. These
     * beans are stored with a key for each one. The beans can therefore be retrieved using their associated 
     * key.
     */

    public class Cache
    {
        /**
         * The name of the Cache object.
         */

        private readonly Dictionary<String, BASEBean> cacheMap = new Dictionary<string, BASEBean>();

        /**
         * Constructs a new Cache object with the given name.
         * @param name - The name of the Cach object
         * @return Cache - an instance of this class
         */

        public Cache(String name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        /**
         * Adds a new Cache item to the cache.
         * @param key - key value for the data provided
         * @param data - BASEBean data bean
         * @see BASEBean
         */

        public void addCacheItem(String key, BASEBean data)
        {
            if( !cacheMap.ContainsKey( key ) )
                cacheMap.Add(key, data);
            else
                LogManager.Warn( string.Format( "Cache \"{0}\" - Item Key \"{1}\" already exists - ignoring key", this.Name, key ) );
        }

        /**
         * Returns the data object for the key provided. If an object cnnot be found
         * then a null is returned.
         * @param key - key value for the data provided
         * @return The data bean object stored with the key spcified.
         * @see BASEBean
         */

        public BASEBean getItem(String key)
        {
            return cacheMap.ContainsKey(key) ? cacheMap[key] : null;
        }

        /**
         * Loads a ComboBox control with the data bean objects stored in the data cache.
         * @param ComboBox - an instance of a ComboBox control to be populated with the data objects
         * @see ComboBox
         */

        public void loadComboBox(ComboBox combo)
        {
            combo.Items.Clear();
            foreach (BASEBean bean in cacheMap.Values)
            {
                combo.Items.Add(bean);
            }
            combo.Sorted = true;
        }


        public List<BASEBean> getCacheValues()
        {
            return cacheMap.Values.ToList();
        }
    }
}