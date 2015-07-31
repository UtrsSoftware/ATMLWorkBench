/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ATMLCommonLibrary.controls
{
    public static class Extensions
    {
        /// <summary>
        /// Extension method to return if the control is in design mode
        /// </summary>
        /// <param name="control">Control to examine</param>
        /// <returns>True if in design mode, otherwise false</returns>
        public static bool IsInDesignMode(this System.Windows.Forms.Control control)
        {
            return ResolveDesignMode(control) || (LicenseManager.UsageMode == LicenseUsageMode.Designtime);
        }


        /// <summary>
        /// Method to test if the control or it's parent is in design mode
        /// </summary>
        /// <param name="control">Control to examine</param>
        /// <returns>True if in design mode, otherwise false</returns>
        private static bool ResolveDesignMode(System.Windows.Forms.Control control)
        {
            System.Reflection.PropertyInfo designModeProperty;
            bool designMode;


            // Get the protected property
            designModeProperty = control.GetType().GetProperty(
                                    "DesignMode",
                                    System.Reflection.BindingFlags.Instance
                                    | System.Reflection.BindingFlags.NonPublic);


            // Get the controls DesignMode value
            designMode = (bool)designModeProperty.GetValue(control, null);


            // Test the parent if it exists
            if (control.Parent != null)
            {
                designMode |= ResolveDesignMode(control.Parent);
            }


            return designMode;
        }
    }
}

