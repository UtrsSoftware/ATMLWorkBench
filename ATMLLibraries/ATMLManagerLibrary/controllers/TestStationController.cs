/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Runtime.CompilerServices;
using ATMLManagerLibrary.interfaces;
using ATMLModelLibrary.model.common;
using ATMLModelLibrary.model.equipment;

namespace ATMLManagerLibrary.controllers
{
    public class TestStationController : PersistanceController, IAtmlController<TestStationDescription11>
    {
        private static volatile TestStationController _instance;

        [MethodImpl(MethodImplOptions.Synchronized)]
        private TestStationController()
        {
        }

        public static IAtmlController<TestStationDescription11> Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new TestStationController();
                return _instance;
            }
        }


        public TestStationDescription11 Find(Guid? uuid)
        {
            return Find<TestStationDescription11>(uuid.ToString());
        }


        public TestStationDescription11 Find(string uuid)
        {
            return Find<TestStationDescription11>(uuid);
        }


        public void Save(TestStationDescription11 testStation)
        {
            base.Save(testStation);
            /*
            if (testStation != null)
            {
                string content = testStation.Serialize();
                Document document = new Document();
            
                document.DocumentContent = Encoding.UTF8.GetBytes(content);
                document.DocumentType = dbDocument.DocumentType.TEST_STATION_DESCRIPTION;
                document.ContentType = "text/xml";
                document.name = testStation.name;
                document.uuid = testStation.uuid;
                DocumentManager.SaveDocument( document );
            }
             
            return testStation;
             */
        }

        public void AddInstrumentReference(TestStationDescription11 testStation, string partNumber, string documentUuid)
        {
            string fullPartNumber = testStation.name + "." + partNumber.Split('#')[0];
            var tsdi = new TestStationDescriptionInstrument();
            tsdi.ID = partNumber;
            tsdi.Item = new DocumentReference();
            ((DocumentReference) tsdi.Item).ID = fullPartNumber;
            ((DocumentReference) tsdi.Item).uuid = documentUuid;
            testStation.Instruments.Add(tsdi);
            Save(testStation);
        }

        public bool HasInstrumentReference(TestStationDescription11 atmlObject, string partNumber)
        {
            bool hasReference = false;
            foreach (TestStationDescriptionInstrument instrument in atmlObject.Instruments)
            {
                if (instrument.ID.Equals(partNumber))
                {
                    hasReference = true;
                    break;
                }
            }
            return hasReference;
        }

        public string Create(string partNumber, string nomen, string model)
        {
            return null;
        }

        //public TestStationDescription11 Add(TestStationDescription11 atmlObject)
        //{
        //    return null;
        //}

        //public TestStationDescription11 Delete(TestStationDescription11 atmlObject)
        //{
        //    return null;
        // }
    }
}