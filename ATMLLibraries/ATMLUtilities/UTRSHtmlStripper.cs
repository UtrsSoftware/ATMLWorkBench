/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Text.RegularExpressions;

namespace ATMLUtilitiesLibrary
{
    public class HtmlStripper
    {
        /// <summary>
        ///     Compiled regular expression for performance.
        /// </summary>
        private static readonly Regex _htmlRegex = new Regex( "<.*?>", RegexOptions.Compiled );

        /// <summary>
        ///     Remove HTML from string with Regex.
        /// </summary>
        public static string StripTagsRegex( string source )
        {
            String value = Regex.Replace( source, "<.*?>", string.Empty );
            return Regex.Replace( value, "&nbsp;", string.Empty );
        }

        /// <summary>
        ///     Remove HTML from string with compiled Regex.
        /// </summary>
        public static string StripTagsRegexCompiled( string source )
        {
            return _htmlRegex.Replace( source, string.Empty );
        }

        /// <summary>
        ///     Remove HTML tags from string using char array.
        /// </summary>
        public static string StripTagsCharArray( string source )
        {
            var array = new char[source.Length];
            int arrayIndex = 0;
            bool inside = false;

            for (int i = 0; i < source.Length; i++)
            {
                char let = source[i];
                if (let == '<')
                {
                    inside = true;
                    continue;
                }
                if (let == '>')
                {
                    inside = false;
                    continue;
                }
                if (!inside)
                {
                    array[arrayIndex] = let;
                    arrayIndex++;
                }
            }
            return new string( array, 0, arrayIndex );
        }
    }
}