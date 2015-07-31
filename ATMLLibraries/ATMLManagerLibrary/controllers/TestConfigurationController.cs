/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Runtime.CompilerServices;
using ATMLManagerLibrary.delegates;
using ATMLManagerLibrary.interfaces;
using ATMLManagerLibrary.managers;
using ATMLModelLibrary.model.common;
using ATMLUtilitiesLibrary;

namespace ATMLManagerLibrary.controllers
{
    public class TestConfigurationController : PersistanceController, IAtmlController<TestConfiguration15>
    {
        private static volatile TestConfigurationController _instance;

        public event ProjectTestConfigurationChangedDeligate TestConfigurationChanged;

        protected virtual void OnTestConfigurationChanged( TestConfiguration15 testconfiguration )
        {
            ProjectTestConfigurationChangedDeligate handler = TestConfigurationChanged;
            if (handler != null) handler( testconfiguration );
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        private TestConfigurationController()
        {
        }

        public static TestConfigurationController Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new TestConfigurationController();
                return _instance;
            }
        }


        [MethodImpl(MethodImplOptions.Synchronized)]
        public string Create(string partNumber, string nomen, string model)
        {
            return null;
        }

        //[MethodImpl(MethodImplOptions.Synchronized)]
        //public TestConfiguration15 Add(TestConfiguration15 atmlObject)
        //{
        //    return null;
       // }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void Save(TestConfiguration15 atmlObject)
        {
            if (base.Save( atmlObject ))
                OnTestConfigurationChanged( atmlObject );
        }

        //[MethodImpl(MethodImplOptions.Synchronized)]
        //public TestConfiguration15 Delete(TestConfiguration15 atmlObject)
        //{
        //    return null;
        //}

        [MethodImpl(MethodImplOptions.Synchronized)]
        public TestConfiguration15 Find(string uuid)
        {
            return base.Find<TestConfiguration15>(uuid) ;
        }

        public TestConfiguration15 Find(Guid? uuid)
        {
            return base.Find<TestConfiguration15>(uuid.ToString());
        }


        public void AddInstrumentReference(TestConfiguration15 atmlObject, string partNumber, string documentUuid)
        {
            throw new NotImplementedException();
        }

        public bool HasInstrumentReference(TestConfiguration15 atmlObject, string partNumber)
        {
            throw new NotImplementedException();
        }
    }
}