/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;

namespace ATMLUtilitiesLibrary
{
    public class UTRSDateUtils
    {
        public static bool IsGoodDate( DateTime date )
        {
            return !date.Equals( DateTime.MinValue ) && !date.Equals( DateTime.MaxValue );
        }
    }
}