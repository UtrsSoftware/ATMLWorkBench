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
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ATMLCommonLibrary.forms
{
    public partial class ATMLPleaseWait : Form
    {
        private static Dictionary<string, ATMLPleaseWait> _instances = new Dictionary<string, ATMLPleaseWait>();

        public ATMLPleaseWait()
        {
            InitializeComponent();
        }

        public static string Show(string message)
        {
            string key = Guid.NewGuid().ToString();
            ATMLPleaseWait form = new ATMLPleaseWait();
            form.lblMessage.Text = message;
            form.Show();
            _instances.Add( key, form );
            return key;
        }

        public static void Hide(string key)
        {
            if (_instances.ContainsKey(key))
            {
                ATMLPleaseWait form = _instances[key];
                form.Close();
                _instances.Remove(key);
            }
        }


    }



}
