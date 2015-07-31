/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using Microsoft.Win32;

namespace ATMLUtilitiesLibrary
{
    public class ATMLRegistryUtils
    {
        public const string SUBKEY = "Software\\UTRS\\ATMLWorkbench";
        public static String ReadRegistryAttribute( String name )
        {
            RegistryKey regCurrentUser = Registry.CurrentUser;

            RegistryKey regKeyRead = regCurrentUser.OpenSubKey(SUBKEY, true);
            if (regKeyRead == null)
                regKeyRead = regCurrentUser.CreateSubKey(SUBKEY);

            var value = (String) regKeyRead.GetValue( name );
            regCurrentUser.Close();
            regKeyRead.Close();
            return value;
        }

        public static void WriteRegistryAttribute( String name, String value )
        {
            RegistryKey regCurrentUser = Registry.CurrentUser;

            RegistryKey regKeyRead = regCurrentUser.OpenSubKey(SUBKEY, true);
            if (regKeyRead == null)
                regKeyRead = regCurrentUser.CreateSubKey(SUBKEY);

            regKeyRead.SetValue( name, value );
            regCurrentUser.Close();
            regKeyRead.Close();
        }
    }
}