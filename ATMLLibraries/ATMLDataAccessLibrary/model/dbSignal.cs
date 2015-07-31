/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Collections.Generic;
using ATMLDataAccessLibrary.db.beans;

namespace ATMLDataAccessLibrary.model
{
    public class dbSignal : SignalMasterBean
    {
        private List<dbSignalAttribute> attributes;
        private dbSignal _parentSignal;
        public dbSignal ParentSignal
        {
            get { return _parentSignal; } 
            set 
            {
                _parentSignal = value;
                if (value != null) parentSignalId = value.signalId;
            }
        }

        public List<dbSignal> ChildSignals { get; set; }

        public List<dbSignalAttribute> Attributes
        {
            get { return attributes; }
            set { attributes = value; }
        }

        public override String ToString()
        {
            return signalName;
        }

        public override void save()
        {
            base.save();
            if (attributes != null)
            {
                foreach (dbSignalAttribute dbSignalAttribute in attributes)
                {
                    dbSignalAttribute.signalId = signalId;
                    dbSignalAttribute.save();
                }
            }
        }
    }
}