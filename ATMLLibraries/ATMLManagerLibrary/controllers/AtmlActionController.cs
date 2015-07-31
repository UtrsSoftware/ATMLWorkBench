/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using ATMLDataAccessLibrary.db.beans;
using ATMLManagerLibrary.delegates;
using ATMLManagerLibrary.events;
using ATMLManagerLibrary.interfaces;
using ATMLModelLibrary.interfaces;
using ATMLModelLibrary.model.common;
using ATMLModelLibrary.model.equipment;
using ATMLModelLibrary.model.uut;

namespace ATMLManagerLibrary.controllers
{
    public class AtmlActionController
    {
        public static void Register(IAtmlActionable actionableItem)
        {
            if (actionableItem != null )
                actionableItem.AtmlObjectAction += ProcessAction;
        }

        static T ProcessAction<T>(T obj, 
                        AtmlActionType actionType, 
                        EventArgs args)
        {
            if (obj is IAtmlObject && actionType == AtmlActionType.Delete)
                ((IAtmlObject) obj).IsDeleted(true);

            T results = default(T);
            if (obj.GetType() == typeof (TestStationDescription11))
                results = (T)Convert.ChangeType(ProcessAction(obj as TestStationDescription11, actionType, args),typeof(T));
            else if (obj.GetType() == typeof(TestConfiguration15))
                results = (T)Convert.ChangeType(ProcessAction(obj as TestConfiguration15, actionType, args), typeof(T));
            else if (obj.GetType() == typeof(UUTDescription))
                results = (T)Convert.ChangeType(ProcessAction(obj as UUTDescription, actionType, args), typeof(T));
            else if (obj.GetType() == typeof(TestAdapterDescription1))
                results = (T)Convert.ChangeType(ProcessAction(obj as TestAdapterDescription1, actionType, args), typeof(T));
            else if (obj.GetType() == typeof(InstrumentDescription))
                results = (T)Convert.ChangeType(ProcessAction(obj as InstrumentDescription, actionType, args), typeof(T));
            return results;
        }

        private static TestConfiguration15 ProcessAction(TestConfiguration15 obj, AtmlActionType actionType,
            EventArgs args)
        {
            IAtmlController<TestConfiguration15> controller = TestConfigurationController.Instance;
            return Process(obj, actionType, controller, args);
        }

        private static InstrumentDescription ProcessAction(InstrumentDescription obj, AtmlActionType actionType, EventArgs args)
        {
            IAtmlController<InstrumentDescription> controller = InstrumentController.Instance;
            obj.DataState = actionType.Equals( AtmlActionType.Add )
                                ? BASEBean.eDataState.DS_ADD
                                : actionType.Equals( AtmlActionType.Edit )
                                      ? BASEBean.eDataState.DS_EDIT
                                      : actionType.Equals( AtmlActionType.Delete )
                                            ? BASEBean.eDataState.DS_DELETE
                                            : BASEBean.eDataState.DS_NO_CHANGE;
            return Process(obj, actionType, controller, args);
        }

        private static UUTDescription ProcessAction(UUTDescription obj, AtmlActionType actionType, EventArgs args)
        {
            IAtmlController<UUTDescription> controller = UUTController.Instance;
            return Process(obj, actionType, controller, args);
        }



        private static TestStationDescription11 ProcessAction(TestStationDescription11 obj, AtmlActionType actionType, EventArgs args)
        {
            IAtmlController<TestStationDescription11> controller = TestStationController.Instance;
            return Process(obj, actionType, controller, args);
        }

        private static TestAdapterDescription1 ProcessAction(TestAdapterDescription1 obj, AtmlActionType actionType, EventArgs args)
        {
            IAtmlController<TestAdapterDescription1> controller = TestAdapterController.Instance;
            return Process(obj, actionType, controller, args);
        }

        private static T Process<T>(T obj, AtmlActionType actionType, IAtmlController<T> controller, EventArgs args)
        {
            T retVal = default(T);
            switch (actionType)
            {
                case AtmlActionType.Add:
                    controller.Save(obj);
                    break;
                case AtmlActionType.Edit:
                    controller.Save(obj);
                    break;
                case AtmlActionType.Delete:
                    controller.Save(obj);
                    break;
                case AtmlActionType.Find:
                    AtmlActionEventArgs aeArgs = args as AtmlActionEventArgs;
                    if( aeArgs != null )
                        retVal = controller.Find(aeArgs.Guid);
                    break;
            }
            return retVal;
        }

    }
}