/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using ATMLCommonLibrary.forms;
using ATMLManagerLibrary.managers;
using ATMLSchemaLibrary.managers;
using ATMLSignalModelLibrary.managers;
using ATMLUtilitiesLibrary;
using ATMLWorkBench.Properties;

namespace ATMLWorkBench
{
    internal static class Program
    {
        private static ATMLSpashScreen _splashScreen;

        public static ATMLSpashScreen SplashScreen
        {
            get { return _splashScreen; }
        }


        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                CreateSplashScreen();

                var worker = new Worker();
                worker.ProgressUpdate += worker_ProgressUpdate;
                _splashScreen.UpdateProgress("Loading Framework");
                var mainFrame = new MainFrame();
                mainFrame.Closing += new System.ComponentModel.CancelEventHandler(mainFrame_Closing);
                _splashScreen.UpdateProgress("Initializing Context");
                ATMLContext.Initialize();
                var tr = new Thread(worker.DoWork);
                tr.Start();
                Application.Run(mainFrame);
            }
            catch (Exception e)
            {
                try
                {
                    Program.SplashScreen.Completed = true;
                    MessageBox.Show(e.Message + Resources.CRLF + e.StackTrace);
                    LogManager.Error(e);
                    //ATMLErrorForm.ShowError(e);
                }
                catch (Exception ee)
                {
                    LogManager.Error(ee);
                }
                Application.Exit();
            }
        }

        static void mainFrame_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_splashScreen != null)
            {
                _splashScreen.Completed = true;
                _splashScreen.Hide();
            }
        }

        private static void CreateSplashScreen()
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            FileInfo fi = new FileInfo(asm.Location);
            Version v = Assembly.GetExecutingAssembly().GetName().Version;
            _splashScreen = new ATMLSpashScreen(v, fi.CreationTime.ToShortDateString() );
            var tsSplash = new Thread(ShowSplashScreen);
            tsSplash.Start();
            while (!_splashScreen.Visible)
            {
                //TODO: Add a timer breakout here
            }
        }

        private static void worker_ProgressUpdate(string message)
        {
            _splashScreen.UpdateProgress(message);
        }

        private static void ShowSplashScreen()
        {
            _splashScreen.Show();
            while (!_splashScreen.Completed)
            {
                Application.DoEvents();
            }
            _splashScreen.Close();
            _splashScreen.Dispose();
        }
    }


    internal class Worker
    {
        public delegate void ProgressDeligate(string message);

        public event ProgressDeligate ProgressUpdate;

        protected virtual void OnProgressUpdate(string message)
        {
            ProgressDeligate handler = ProgressUpdate;
            if (handler != null) handler(message);
        }

        public void DoWork()
        {
            try
            {
                Application.ApplicationExit+=delegate(object sender, EventArgs args) { LogManager.Info("{0} has exited.", ATMLContext.APPLICATION_NAME); };
                LogManager.Debug("Loading Schemas... ", ATMLContext.APPLICATION_NAME);
                OnProgressUpdate("Loading Schemas");
                SchemaManager sm = SchemaManager.Instance;
                sm.SchemaPath = ATMLContext.SchemaPath;
                LogManager.Debug("Loading Signal Libraries... ", ATMLContext.APPLICATION_NAME);
                OnProgressUpdate("Loading Signal Libraries");
                XmlDocument tree = SignalManager.Instance.TSFSignalTree;
                Program.SplashScreen.Completed = true;
                LogManager.Info("{0} has completed loading.", ATMLContext.APPLICATION_NAME);
            }
            catch (Exception e )
            {
                Program.SplashScreen.Completed = true;
                MessageBox.Show(e.Message + @"\r\n" + e.StackTrace);  
                LogManager.Error( e );
            }
        }
    }
}