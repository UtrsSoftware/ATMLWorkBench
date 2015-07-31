/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Drawing;

namespace ATMLUtilitiesLibrary
{
    public class UTRSGraphicsUtils
    {
        public static Color LightenColor( Color color, int percent )
        {
            return CreateColor( color, percent );
        }

        public static Color DarkenColor( Color color, int percent )
        {
            return CreateColor( color, -1*percent );
        }


        private static Color CreateColor( Color color, float percent )
        {
            float adjustmentAmount = percent/100f;
            float red = ( ( 1 - Math.Abs( adjustmentAmount ) )*color.R + adjustmentAmount*255 );
            float green = ( ( 1 - Math.Abs( adjustmentAmount ) )*color.G + adjustmentAmount*255 );
            float blue = ( ( 1 - Math.Abs( adjustmentAmount ) )*color.B + adjustmentAmount*255 );

            red = Math.Max( red, 0f );
            green = Math.Max( green, 0f );
            blue = Math.Max( blue, 0f );

            red = Math.Min( red, 255f );
            green = Math.Min( green, 255f );
            blue = Math.Min( blue, 255f );

            return Color.FromArgb( color.A, (int) red, (int) green, (int) blue );
        }
    }
}