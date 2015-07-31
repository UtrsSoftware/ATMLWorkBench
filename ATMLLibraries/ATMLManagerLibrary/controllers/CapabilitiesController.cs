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
using ATMLDataAccessLibrary.db.daos;
using ATMLModelLibrary.model.common;
using ATMLModelLibrary.model.equipment;
using ATMLModelLibrary.model.signal.basic;
using ATMLSignalModelLibrary.managers;

namespace ATMLManagerLibrary.controllers
{
    public class CapabilitiesController
    {

        public static void Save( string uuid, Capabilities capabilities )
        {
            SignalDAO dao = new SignalDAO();
            List<object> items = capabilities.Items;
            if (items != null)
            {
                foreach (object item in items)
                {
                    Capability capability = item as Capability;
                    DocumentReference documentReference = item as DocumentReference;
                    if (capability != null)
                        ProcessCapability(uuid, capability);
                    if( documentReference != null )
                        ProcessDocumentReference(uuid, documentReference);
                }
            }
        }

        private static void ProcessCapability( string uuid, Capability capability )
        {
            List<Signal> signals = SignalManager.ExtractSignalsFromExtension(capability.SignalDescription);
            if (signals != null)
            {
                foreach (Signal signal in signals)
                {
                    //SignalItemsChoiceType signalType = signal.
                    //signal.Items;
                }
            }
        }

        private static void ProcessDocumentReference(string uuid, DocumentReference capability)
        {

        }

    }
}
