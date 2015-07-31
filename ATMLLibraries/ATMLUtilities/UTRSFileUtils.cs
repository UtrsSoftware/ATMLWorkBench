/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.IO;
using System.Text;

namespace ATMLUtilitiesLibrary
{
    public class FileUtils
    {
        public static String getFileSizeAsText( long fileSize )
        {
            String value = "";
            if (fileSize/1000000L > 1)
                value = String.Format( "{0:00.0}", (double) ( fileSize/1000000L ) ) + " mb";
            else if (fileSize/1000L > 1)
                value = String.Format( "{0:00.0}", (double) ( fileSize/1000L ) ) + " kb";
            else
                value = fileSize + " bytes";
            return value;
        }


        public static String getMimeType( String extension )
        {
            String mimeType = "Unknown";
            extension = extension.ToLower();
            if (".jpg".Equals( extension ))
                mimeType = "image/jpeg";
            else if (".gif".Equals( extension ))
                mimeType = "image/gif";
            else if (".bmp".Equals( extension ))
                mimeType = "image/bmp";
            else if (".png".Equals( extension ))
                mimeType = "image/png";
            else if (".mp3".Equals( extension ))
                mimeType = "audio/mp3";
            else if (".mp2".Equals( extension ))
                mimeType = "video/mpeg";
            else if (".mpa".Equals( extension ))
                mimeType = "video/mpeg";
            else if (".m3u".Equals( extension ))
                mimeType = "audio/x-mpegurl";
            else if (".mid".Equals( extension ))
                mimeType = "audio/mid";
            else if (".midi".Equals( extension ))
                mimeType = "audio/mid";
            else if (".rmi".Equals( extension ))
                mimeType = "audio/mid";
            else if (".aif".Equals( extension ))
                mimeType = "audio/x-aiff";
            else if (".aifc".Equals( extension ))
                mimeType = "audio/x-aiff";
            else if (".aiff".Equals( extension ))
                mimeType = "audio/x-aiff";
            else if (".au".Equals( extension ))
                mimeType = "audio/basic";
            else if (".snd".Equals( extension ))
                mimeType = "audio/basic";
            else if (".wav".Equals( extension ))
                mimeType = "audio/x-wav";
            else if (".cda".Equals( extension ))
                mimeType = "unknown";
            else if (".wmz".Equals( extension ))
                mimeType = "unknown";
            else if (".wms".Equals( extension ))
                mimeType = "unknown";
            else if (".mov".Equals( extension ))
                mimeType = "video/quicktime";
            else if (".qt".Equals( extension ))
                mimeType = "video/quicktime";
            else if (".asf".Equals( extension ))
                mimeType = "video/x-ms-asf";
            else if (".asf".Equals( extension ))
                mimeType = "video/x-ms-asf";
            else if (".avi".Equals( extension ))
                mimeType = "video/x-msvideo";
            else if (".mpeg".Equals( extension ))
                mimeType = "video/mpeg";
            else if (".mpg".Equals( extension ))
                mimeType = "video/mpeg";
            else if (".m1v".Equals( extension ))
                mimeType = "video/mpeg";
            else if (".mp2".Equals( extension ))
                mimeType = "video/mpeg";
            else if (".mp3".Equals( extension ))
                mimeType = "video/mpeg";
            else if (".mpa".Equals( extension ))
                mimeType = "video/mpeg";
            else if (".mpe".Equals( extension ))
                mimeType = "video/mpeg";
            else if (".mpv2".Equals( extension ))
                mimeType = "video/mpeg";
            else if (".m3u".Equals( extension ))
                mimeType = "video/mpeg";
            /*

            */
            return mimeType;
        }

        public static string getUserDataPath( String projectName )
        {
            string dir = Environment.GetFolderPath( Environment.SpecialFolder.ApplicationData );
            dir = Path.Combine( dir, projectName );
            if (!Directory.Exists( dir ))
                Directory.CreateDirectory( dir );
            return dir;
        }

        public static string MakeGoodFileName( string fileName )
        {
            const string replacementChar = "-";
            return fileName.Replace( "/", replacementChar )
                           .Replace( "\\", replacementChar )
                           .Replace( "<", replacementChar )
                           .Replace( ">", replacementChar )
                           .Replace( ":", replacementChar )
                           .Replace( "\"", replacementChar )
                           .Replace( "|", replacementChar )
                           .Replace( "?", replacementChar )
                           .Replace( "*", replacementChar );
        }

        public static String EncodeFileName( String fileName )
        {
            return Convert.ToBase64String( Encoding.UTF8.GetBytes( fileName ) );
        }

        public static String DecodeFileName( String encodedFileName )
        {
            return Encoding.UTF8.GetString( Convert.FromBase64String( encodedFileName ) );
        }
    }
}