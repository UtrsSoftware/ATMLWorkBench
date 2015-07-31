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
using ATMLDataAccessLibrary.db.beans;
using ATMLDataAccessLibrary.db.daos;

namespace ATMLDataAccessLibrary.model
{
    public class dbTSFLibrary : TestSignalLibraryBean
    {
        private List<dbTSFSignal> signals = new List<dbTSFSignal>();
        public List<dbTSFSignal> Signals
        {
            get { return signals; }
            set { signals = value; }
        }


        public override void save()
        {
            base.save();
            foreach (dbTSFSignal signal in signals)
            {
                signal.libraryUuid = this.id.ToString();
                signal.save();
            }
        }


    }
}
