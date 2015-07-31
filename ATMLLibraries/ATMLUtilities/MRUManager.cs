/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;

namespace ATMLUtilitiesLibrary
{
    public class MRUManager
    {
        //----------------------------//
        //--- Add File Name to MRU ---//
        //----------------------------//
        public static void AddFileName( String fileName )
        {
            if (fileName == null)
                throw new Exception( "The file name is required." );

            var newMRUList = new List<string>();
            newMRUList.Add( fileName );

            RegistryKey regCurrentUser = Registry.CurrentUser;

            RegistryKey regKeyRead = regCurrentUser.OpenSubKey(ATMLRegistryUtils.SUBKEY, true);
            if (regKeyRead == null)
                regKeyRead = regCurrentUser.CreateSubKey(ATMLRegistryUtils.SUBKEY);

            var mruList = (String) regKeyRead.GetValue( "MRUList" );
            if (mruList != null)
            {
                String[] tempList = mruList.Split( ';' );
                foreach (String item in tempList)
                {
                    if (!item.Equals( fileName ))
                        newMRUList.Add( item );
                }
            }

            int Counter = 0;
            var sb = new StringBuilder();
            foreach (String item in newMRUList)
            {
                sb.Append( item ).Append( ";" );
                if (Counter++ == 4)
                    break;
            }
            if (sb.ToString().EndsWith( ";" ))
                sb.Length = sb.Length - 1;
            regKeyRead.SetValue( "MRUList", sb.ToString() );

            regCurrentUser.Close();
            regKeyRead.Close();
        }

        //--- Get MRU List ---//
        public static List<String> GetMNUList()
        {
            var newMRUList = new List<string>();
            RegistryKey regCurrentUser = Registry.CurrentUser;
            RegistryKey regKeyRead = regCurrentUser.OpenSubKey( ATMLRegistryUtils.SUBKEY, true );
            if (regKeyRead == null)
                regKeyRead = regCurrentUser.CreateSubKey(ATMLRegistryUtils.SUBKEY);

            var mruList = (String) regKeyRead.GetValue( "MRUList" );
            if (mruList != null)
            {
                String[] tempList = mruList.Split( ';' );
                foreach (String item in tempList)
                {
                    newMRUList.Add( item );
                }
            }
            regCurrentUser.Close();
            regKeyRead.Close();
            return newMRUList;
        }
    }
}