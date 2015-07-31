/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.IO;
using Ionic.Zip;

namespace ATMLUtilitiesLibrary
{
    //--- This class is simply a wrapper around a 3rd party zip utility - currently set to dotnetZip
    public class UTRSCompressionManager
    {
        public static void CompressDirectory( string inputDir, string outputFile )
        {
            using (var zip = new ZipFile())
            {
                zip.AddDirectory( inputDir );
                zip.Comment = "Test Program Set Archive " + DateTime.Now.ToString( "G" );
                zip.Save( outputFile );
            }
        }

        public static void CompressFile( string directoryName, string fileName, ZipFile zipStream )
        {
            //---------------------------------//
            //--- Compress the file content ---//
            //---------------------------------//
            zipStream.AddFile( Path.Combine( directoryName, fileName ) );
        }
    }
}