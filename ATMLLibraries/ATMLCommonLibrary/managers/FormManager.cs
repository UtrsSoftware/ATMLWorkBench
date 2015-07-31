/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ATMLCommonLibrary.controls.signal;
using ATMLCommonLibrary.forms;

namespace ATMLCommonLibrary.managers
{
    public class FormManager
    {
        private static readonly object syncRoot = new Object();
        private static volatile FormManager _instance;
        private readonly Dictionary<Form, Form> _activeForms = new Dictionary<Form, Form>();

        private readonly SignalModelLibraryForm _signalModelLibraryForm;
        private Control _lastActiveControl;


        private FormManager()
        {
            _signalModelLibraryForm = new SignalModelLibraryForm();
        }

        public static Control LastActiveControl
        {
            get { return Instance._lastActiveControl; }
            set
            {
                FormManager instance = Instance;
                if (instance._lastActiveControl != null)
                    instance._lastActiveControl.BackColor = Color.White;
                instance._lastActiveControl = value;
                if (instance._lastActiveControl != null)
                    instance._lastActiveControl.BackColor = Color.PaleTurquoise;
            }
        }

        public static void CloseAllForms()
        {
            FormManager instance = Instance;
            Form[] forms = new Form[instance._activeForms.Count];
            instance._activeForms.Values.CopyTo(forms,0);
            foreach (Form form in forms )
            {
                form.Close();
                RemoveActiveForm(form);
            }
        }

        public static bool AddActiveForm(Form form)
        {
            string name = GetKeyName(form);
            bool formAdded = !Instance._activeForms.ContainsKey(form);
            if (formAdded)
                Instance._activeForms.Add(form, form);
            return formAdded;
        }

        public static bool RemoveActiveForm(Form form)
        {
            string name = GetKeyName(form);
            return Instance._activeForms.Remove(form);
        }

        public static FormManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (syncRoot)
                    {
                        if (_instance == null)
                        {
                            _instance = new FormManager();
                        }
                    }

                }
                return _instance;
            }
        }

        public static void ShowSignalModelLibraryForm()
        {
            Instance._signalModelLibraryForm.Show();
        }

        private static string GetKeyName(Form form)
        {
            String name = "";
            Form owner = form.Owner;
            if (owner != null)
                name = owner.GetType().FullName + ":";
            name += form.GetType().FullName;
            return name;
        }
    }
}