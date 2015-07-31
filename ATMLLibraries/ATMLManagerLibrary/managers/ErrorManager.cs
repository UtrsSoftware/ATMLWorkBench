/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace ATMLManagerLibrary.managers
{
    public class ErrorManager
    {
        public static ICollection<string> GatherErrorMessages(Form parentForm)
        {
            ICollection<ErrorProvider> errorProviders = new List<ErrorProvider>();
            ICollection<string> errorList = new List<string>();
            GetErrorProviders( parentForm, errorProviders );
            GetErrorMessages(parentForm, errorList, errorProviders);
            return errorList;
        }

        public static void GetErrorMessages(Control parentControl, ICollection<string> errorList, ICollection<ErrorProvider> errorProviders)
        {
            foreach (ErrorProvider errorProvider in errorProviders)
            {
                GetErrorMessages(parentControl, errorList, errorProvider);
            }
        }

        public static void GetErrorMessages(Control parentControl, ICollection<string> errorList, ErrorProvider errorProvider )
        {
            string error = errorProvider.GetError(parentControl);
            if (!string.IsNullOrWhiteSpace(error) && !errorList.Contains(error))
                errorList.Add(error);
            foreach (Control control in parentControl.Controls)
                GetErrorMessages(control, errorList, errorProvider);
        }


        private static void GetErrorProviders( Control control, ICollection<ErrorProvider> errorProviders)
        {
            ExtractErrorProviders(control, errorProviders);
            foreach (Control childControl in control.Controls)
                GetErrorProviders(childControl, errorProviders);
        }

        private static void ExtractErrorProviders(Control control, ICollection<ErrorProvider> errorProviders)
        {
            //use reflection to get to "components" field
            var containerControl = control.GetContainerControl();
            if (containerControl != null)
            {
                FieldInfo componentField = containerControl.GetType()
                                               .GetField( "components", BindingFlags.NonPublic | BindingFlags.Instance );

                if (componentField != null)
                {
                    //get the component collection from field
                    object components = componentField.GetValue(containerControl);
                    if (components != null)
                    {
                        //locate the ErrorProvider within the collection
                        var container = components as IContainer;
                        if (container != null)
                        {
                            foreach (ErrorProvider provider in container.Components.OfType<ErrorProvider>())
                            {
                                if (!errorProviders.Contains( provider ))
                                    errorProviders.Add( provider );
                            }
                        }
                    }
                }
            }
        }
    }
}