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
using System.Runtime.Remoting;
using System.Text;
using ATMLManagerLibrary.managers;
using ATMLModelLibrary.model.common;
using ATMLModelLibrary.model.equipment;
using ATMLDataAccessLibrary.model;

namespace ATMLCommonLibrary.managers
{
    public class TestStationManager
    {
        private TestStationManager _instance;
        private static readonly object syncRoot = new Object();

        private TestStationManager()
        {
            
        }

        public TestStationManager Instance
        {
            get { if (_instance == null)
                lock (syncRoot)
                {
                    if (_instance == null)
                    {
                        _instance = new TestStationManager();
                    }
                }
                return _instance; } 
            set { _instance = value; }
        }


        static public List<TestStationDescription11> TestStations
        {
            get
            {
                List<TestStationDescription11> testStations = new List<TestStationDescription11>();
                try
                {
                    List<Document> documents = DocumentManager.GetDocumentsByType((int)dbDocument.DocumentType.TEST_STATION_DESCRIPTION);
                    if (documents != null)
                    {
                        foreach (Document document in documents)
                        {
                            TestStationDescription11 testStation = TestStationDescription11.Deserialize(Encoding.UTF8.GetString(document.DocumentContent));
                            testStations.Add(testStation);
                        }
                    }
                }
                catch (Exception e)
                {
                    LogManager.Error(e.Message, e );
                }
                return testStations;
            }
        }

    }
}
