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
    public class StringUtils
    {
        public static String StripSpecialCharacters( String input )
        {
            if (input.IndexOf( '\u2013' ) > -1) input = input.Replace( '\u2013', '-' );
            if (input.IndexOf( '\u2014' ) > -1) input = input.Replace( '\u2014', '-' );
            if (input.IndexOf( '\u2015' ) > -1) input = input.Replace( '\u2015', '-' );
            if (input.IndexOf( '\u2017' ) > -1) input = input.Replace( '\u2017', '_' );
            if (input.IndexOf( '\u2018' ) > -1) input = input.Replace( '\u2018', '\'' );
            if (input.IndexOf( '\u2019' ) > -1) input = input.Replace( '\u2019', '\'' );
            if (input.IndexOf( '\u201a' ) > -1) input = input.Replace( '\u201a', ',' );
            if (input.IndexOf( '\u201b' ) > -1) input = input.Replace( '\u201b', '\'' );
            if (input.IndexOf( '\u201c' ) > -1) input = input.Replace( '\u201c', '\"' );
            if (input.IndexOf( '\u201d' ) > -1) input = input.Replace( '\u201d', '\"' );
            if (input.IndexOf( '\u201e' ) > -1) input = input.Replace( '\u201e', '\"' );
            if (input.IndexOf( '\u2026' ) > -1) input = input.Replace( "\u2026", "..." );
            if (input.IndexOf( '\u2032' ) > -1) input = input.Replace( '\u2032', '\'' );
            if (input.IndexOf( '\u2033' ) > -1) input = input.Replace( '\u2033', '\"' );
            return input;
        }


        public static MemoryStream GenerateStreamFromString( string value )
        {
            return new MemoryStream( Encoding.UTF8.GetBytes( value ?? "" ) );
        }

        public static string RemoveByteOrderMarkUTF8( string text )
        {
            string byteOrderMarkUtf8 = Encoding.UTF8.GetString( Encoding.UTF8.GetPreamble() );
            if (text.StartsWith( byteOrderMarkUtf8 ))
                text = text.Remove( 0, byteOrderMarkUtf8.Length );
            return text;
        }
    }
}