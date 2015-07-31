/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Windows.Forms;

namespace ATMLCommonLibrary.forms
{
    public partial class ATMLSpashScreen : Form
    {
        private const int CS_DROPSHADOW = 0x20000;
        private const string Ticks = "........................................";

        private static string _currentMessage = "";
        private readonly Timer _timer = new Timer();
        private int _tickCount;

        public ATMLSpashScreen(Version version, string buildDate)
        {
            InitializeComponent();
            _timer = new Timer();
            _timer.Tick += _timer_Tick;
            _timer.Interval = 100;
            lblVersion.Text = string.Format("Version: {0}.{1}", version.Major, version.Minor);
            lblBuild.Text = string.Format("Build: {0}", version.Build);
            lblBuildDate.Text = buildDate;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        public bool Completed { get; set; }

        public string CurrentMessage
        {
            get { return _currentMessage; }
        }

        public string Version { get; set; }

        public string Build { get; set; }

        public string BuildDate { get; set; }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _timer.Stop();
            base.OnFormClosing(e);
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(CurrentMessage))
            {
                string message = CurrentMessage + Ticks.Substring(0, _tickCount);
                _tickCount = _tickCount >= Ticks.Length ? 0 : _tickCount + 1;
                lblCaption.Invoke((MethodInvoker) (() => lblCaption.Text = message));
            }
        }

        public void UpdateProgress(string caption)
        {
            lblCaption.Invoke((MethodInvoker) (() => lblCaption.Text = caption));
            _currentMessage = caption;
            _tickCount = 0;
        }

        private void ATMLSpashScreen_Load(object sender, EventArgs e)
        {
            _timer.Start();
        }

        /*
        Constants in Windows API
        0x84 = WM_NCHITTEST - Mouse Capture Test
        0x1 = HTCLIENT - Application Client Area
        0x2 = HTCAPTION - Application Title Bar

        This function intercepts all the commands sent to the application. 
        It checks to see of the message is a mouse click in the application. 
        It passes the action to the base action by default. It reassigns 
        the action to the title bar if it occured in the client area
        to allow the drag and move behavior.
        */

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x84:
                    base.WndProc(ref m);
                    if ((int) m.Result == 0x1)
                        m.Result = (IntPtr) 0x2;
                    return;
            }

            base.WndProc(ref m);
        }
    }
}