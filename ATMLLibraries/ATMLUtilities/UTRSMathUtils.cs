/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Text;

namespace ATMLUtilitiesLibrary
{
    public class MathUtils
    {
        public static string convertBase10ToBase3( long value )
        {
            int toBase = 3;
            string characters = "0123456789";
            var sb = new StringBuilder();
            while (value > 0)
            {
                var remainder = (int) ( value%toBase );
                sb.Insert( 0, characters[remainder] );
                value /= toBase;
            }
            return sb.ToString();
        }

        public static int convertBase3ToBase10( string value )
        {
            int fromBase = 3;
            string characters = "0123456789";
            int maxFromSchemeCharacter = 3;
            var fromValue = new StringBuilder( value );

            int power = 0;
            int result = 0;

            while (fromValue.Length > 0)
            {
                int index = Array.IndexOf( characters.ToCharArray(), fromValue[fromValue.Length - 1] );

                // check if character not in numbering scheme
                if (index < 0)
                    throw new FormatException( "Unsupported character in value string" );

                // check if character is legal for number base and numbering scheme
                if (index >= maxFromSchemeCharacter)
                    throw new FormatException( "Value contains character not valid for number base" );

                result += ( index*(int) Math.Pow( fromBase, power ) );

                // overflow check
                if (result < 0)
                    throw new OverflowException();

                fromValue.Length--;

                power++;
            }

            return result;
        }
    }
}