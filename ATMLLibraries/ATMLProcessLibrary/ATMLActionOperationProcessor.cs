/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System.Collections.Generic;
using System.Xml;
using ATMLModelLibrary.model;
using ATMLModelLibrary.model.signal.basic;
using ATMLSignalModelLibrary.signal;

namespace ATMLProcessLibrary
{
    public class ActionOperationProcessor
    {
        private readonly Dictionary<string, OperationType> _operations = new Dictionary<string, OperationType>();

        public Dictionary<string, OperationType> Operations
        {
            get { return _operations; }
        }

        public OperationType GetOperation(string id)
        {
            return Operations.ContainsKey(id) ? Operations[id] : null;
        }

        public void ProcessOperation(OperationType operation)
        {
            Operations.Add(operation.ID, operation);
            var change = operation as OperationChange;
            if (change != null)
                ProcessOperation(change);
            var other = operation as OperationOther;
            if (other != null)
                ProcessOperation(other);
            var conditional = operation as OperationConditional;
            if (conditional != null)
                ProcessOperation(conditional);
            var repeat = operation as OperationRepeat;
            if (repeat != null)
                ProcessOperation(repeat);
            var messageIn = operation as OperationMessageIn;
            if (messageIn != null)
                ProcessOperation(messageIn);
            var messageOut = operation as OperationMessageOut;
            if (messageOut != null)
                ProcessOperation(messageOut);
            var setStateVar = operation as OperationSetStateVariable;
            if (setStateVar != null)
                ProcessOperation(setStateVar);
            var readStateVar = operation as OperationReadStateVariable;
            if (readStateVar != null)
                ProcessOperation(readStateVar);
            var waitFor = operation as OperationWaitFor;
            if (waitFor != null)
                ProcessOperation(waitFor);
            var disable = operation as OperationDisable;
            if (disable != null)
                ProcessOperation(disable);
            var enable = operation as OperationEnable;
            if (enable != null)
                ProcessOperation(enable);
            var disconnect = operation as OperationDisconnect;
            if (disconnect != null)
                ProcessOperation(disconnect);
            var connect = operation as OperationConnect;
            if (connect != null)
                ProcessOperation(connect);
            var compare = operation as OperationCompare;
            if (compare != null)
                ProcessOperation(compare);
            var read = operation as OperationRead;
            if (read != null)
                ProcessOperation(read);
            var resetAll = operation as OperationResetAll;
            if (resetAll != null)
                ProcessOperation(resetAll);
            var reset = operation as OperationReset;
            if (reset != null)
                ProcessOperation(reset);
            var setup = operation as OperationSetup;
            if (setup != null)
                ProcessOperation(setup);
        }


        public void ProcessOperation(OperationOther operation)
        {
        }

        public void ProcessOperation(OperationConditional operation)
        {
        }

        public void ProcessOperation(OperationRepeat operation)
        {
        }

        public void ProcessOperation(OperationMessageIn operation)
        {
        }

        public void ProcessOperation(OperationMessageOut operation)
        {
        }

        public void ProcessOperation(OperationSetStateVariable operation)
        {
        }

        public void ProcessOperation(OperationReadStateVariable operation)
        {
        }

        public void ProcessOperation(OperationWaitFor operation)
        {
        }

        public void ProcessOperation(OperationDisable operation)
        {
        }

        public void ProcessOperation(OperationEnable operation)
        {
        }

        public void ProcessOperation(OperationDisconnect operation)
        {
        }

        public void ProcessOperation(OperationConnect operation)
        {
        }

        public void ProcessOperation(OperationCompare operation)
        {
        }

        public void ProcessOperation(OperationRead operation)
        {
        }

        public void ProcessOperation(OperationResetAll operation)
        {
        }

        public void ProcessOperation(OperationReset operation)
        {
        }

        public void ProcessOperation(OperationChange operation)
        {
        }

        public void ProcessOperation(OperationSetup operation)
        {
            OperationSetupProcessor.ProcessSetup(operation);
        }
    }


    public class OperationSetupProcessor
    {
        public static void ProcessSetup(object item)
        {
            var monitor = item as OperationSetupMonitor;
            var sensor = item as OperationSetupSensor;
            var source = item as OperationSetupSource;
            if (monitor != null) ProcessSetup(monitor);
            if (sensor != null) ProcessSetup(sensor);
            if (source != null) ProcessSetup(source);
        }

        public static void ProcessSetup(OperationSetupMonitor item)
        {
        }

        public static void ProcessSetup(OperationSetupSensor item)
        {
            XmlElement any = item.Any;
            Signal signal = SignalModel.ExtractSignalFromElement(any);
            if (signal != null)
            {
                int i = 0;
            }
        }

        public static void ProcessSetup(OperationSetupSource item)
        {
        }
    }
}