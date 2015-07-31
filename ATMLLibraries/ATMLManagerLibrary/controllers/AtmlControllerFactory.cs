/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using ATMLManagerLibrary.interfaces;
using ATMLModelLibrary.model.common;
using ATMLModelLibrary.model.equipment;
using ATMLModelLibrary.model.uut;

namespace ATMLManagerLibrary.controllers
{
    public class AtmlControllerFactory<T>
    {
        public static IAtmlController<T> Controller
        {
            get
            {
                IAtmlController<T> _controller = default(IAtmlController<T>);
                if(typeof(TestStationDescription11).IsAssignableFrom(typeof(T)))
                    _controller = (IAtmlController<T>)TestStationController.Instance;
                else if (typeof(TestAdapterDescription1).IsAssignableFrom(typeof(T)))
                    _controller = (IAtmlController<T>)TestAdapterController.Instance;
                else if (typeof(UUTDescription).IsAssignableFrom(typeof(T)))
                    _controller = (IAtmlController<T>)UUTController.Instance;
                else if (typeof(TestConfiguration15).IsAssignableFrom(typeof(T)))
                    _controller = (IAtmlController<T>)TestConfigurationController.Instance;

                if( _controller == null )
                    throw new Exception( string.Format( "Failed to locate a controller for {0}", typeof(T).Name) );

                return _controller;
            }
        }


    }
}
