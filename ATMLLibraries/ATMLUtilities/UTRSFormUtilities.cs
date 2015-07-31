/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System.Drawing;
using System.Windows.Forms;

namespace ATMLUtilitiesLibrary
{
    public class UTRSFormUtilities
    {

        public static Control GetVisibleChildUnderMouse( Control topControl )
        {
            return GetVisibleChildAtDesktopPoint( topControl, Cursor.Position );
        }

        private static Control GetVisibleChildAtDesktopPoint( Control topControl, Point desktopPoint )
        {
            Control foundControl = topControl.GetChildAtPoint( topControl.PointToClient( desktopPoint ) );
            if (foundControl != null)
            {
                if (foundControl.HasChildren)
                {
                    foreach (Control control in foundControl.Controls)
                    {
                        foundControl = GetVisibleChildAtDesktopPoint(control, desktopPoint);
                        if (foundControl != null && foundControl.Visible)
                            break;
                    }
                }
            }
            return foundControl ?? topControl;
        }
    }
}