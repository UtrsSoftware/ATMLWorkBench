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
using System.Reflection;
using System.Windows.Forms;

namespace ATMLUtilitiesLibrary
{
    public class UTRSValidator
    {
        public static bool hasValidationErrors(Control.ControlCollection controls, Dictionary<Control,List<string>> errors )
        {
            bool hasError = false;

            // Now we need to loop through the controls and deterime if any of them have errors
            foreach (Control control in controls)
            {
                // check the control and see what it returns
                bool validControl = IsValid(control, errors);
                // If it's not valid then set the flag and keep going.  We want to get through all
                // the validators so they will display on the screen if errorProviders were used.
                if (!validControl)
                    hasError = true;

                // If its a container control then it may have children that need to be checked
                if (control.HasChildren)
                {
                    if (hasValidationErrors(control.Controls, errors ))
                        hasError = true;
                }
            }
            return hasError;
        }

        // Here, let's determine if the control has a validating method attached to it
        // and if it does, let's execute it and return the result
        private static bool IsValid(object eventSource, Dictionary<Control, List<string>> errors  )
        {
            bool isValid = true;
            const string name = "EventValidating";

            Type targetType = eventSource.GetType();

            do
            {
                FieldInfo[] fields = targetType.GetFields(
                    BindingFlags.Static |
                    BindingFlags.Instance |
                    BindingFlags.NonPublic);

                foreach (FieldInfo field in fields)
                {
                    if (field.Name == name)
                    {
                        var eventHandlers = ((EventHandlerList) (eventSource.GetType().GetProperty("Events",
                                                                                                   (BindingFlags
                                                                                                        .FlattenHierarchy |
                                                                                                    (BindingFlags
                                                                                                         .NonPublic |
                                                                                                     BindingFlags
                                                                                                         .Instance)))
                                                                            .GetValue(eventSource, null)));

                        Delegate d = eventHandlers[field.GetValue(eventSource)];

                        if ((!(d == null)))
                        {
                            Delegate[] subscribers = d.GetInvocationList();

                            // ok we found the validation event,  let's get the event method and call it
                            foreach (Delegate d1 in subscribers)
                            {
                                // create the parameters
                                object sender = eventSource;
                                var eventArgs = new CancelEventArgs();
                                eventArgs.Cancel = false;
                                var parameters = new object[2];
                                parameters[0] = sender;
                                parameters[1] = eventArgs;
                                // call the method
                                d1.DynamicInvoke(parameters);
                                // if the validation failed we need to return that failure
                                isValid &= !eventArgs.Cancel;
                                if (!isValid)
                                {
                                    List<string> eee = new List<string>();
                                    Control ctr = eventSource as Control;
                                    if (ctr != null)
                                    {
                                        PropertyInfo pi = d1.Target.GetType().GetProperty("ErrorMessage");
                                        if (pi != null)
                                        {
                                            if (!errors.ContainsKey(ctr))
                                                errors.Add(ctr, eee);
                                            else
                                                eee = errors[ctr];

                                            string val = (string)pi.GetValue(d1.Target, null);
                                            eee.Add( val );
                                        }
                                    }
                                    int i = 0;
                                }
                                //if (eventArgs.Cancel)
                                //    return false;
                                //return true;
                            }
                        }
                    }
                }

                targetType = targetType.BaseType;
            } while (targetType != null);

            return isValid;
        }
    }
}