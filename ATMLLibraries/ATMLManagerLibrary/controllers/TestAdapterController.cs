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
using ATMLModelLibrary.model.equipment;

namespace ATMLManagerLibrary.controllers
{
    public class TestAdapterController : PersistanceController, IAtmlController<TestAdapterDescription1>
    {

        private static volatile TestAdapterController _instance;

        [MethodImpl(MethodImplOptions.Synchronized)]
        private TestAdapterController()
        {
            
        }

        public static TestAdapterController Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new TestAdapterController();
                return _instance;
            }
        }

        public string Create(string partNumber, string nomen, string model)
        {
            return null;
        }

        //public void Add(TestAdapterDescription1 atmlObject)
        //{
        //    atmlObject.IsDeleted(false);
        //    base.Save(atmlObject);
       // }

        public void Save(TestAdapterDescription1 atmlObject)
        {
            base.Save(atmlObject);
        }

        //public void Delete(TestAdapterDescription1 atmlObject)
        //{
        //    atmlObject.IsDeleted(true);
        //    base.Save(atmlObject);
       // }


        public TestAdapterDescription1 Find(string uuid)
        {
            return base.Find<TestAdapterDescription1>(uuid);
        }

        public TestAdapterDescription1 Find(Guid? uuid)
        {
            return Find(uuid.ToString());
        }

        public void AddInstrumentReference(TestAdapterDescription1 atmlObject, string partNumber, string documentUuid)
        {
            throw new NotImplementedException();
        }

        public bool HasInstrumentReference(TestAdapterDescription1 atmlObject, string partNumber)
        {
            throw new NotImplementedException();
        }
    }
}
