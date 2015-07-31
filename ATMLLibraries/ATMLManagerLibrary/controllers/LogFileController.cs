/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ATMLManagerLibrary.managers;
using ATMLUtilitiesLibrary;

namespace ATMLManagerLibrary.controllers
{
    public class LogFileController
    {
        private readonly string _buffer = "                              ";
        private readonly string _fileLocation;
        private readonly DateTime _today;
        private string _logFileName;
        private int _margin = 12;

        public LogFileController()
        {
            _fileLocation = Path.Combine(Path.GetTempPath(), "AWLogs");
            _today = DateTime.Now;
            BuildLogFileName();
            LogManager.Instance.OnDebug += Instance_OnDebug;
            LogManager.Instance.OnError += Instance_OnError;
            LogManager.Instance.OnInfo += Instance_OnInfo;
            LogManager.Instance.OnTrace += Instance_OnTrace;
            LogManager.Instance.OnWarn += Instance_OnWarn;
        }

        public bool OpenLogFile(out string fileName)
        {
            fileName = null;
            bool opened = false;
            var dlg = new OpenFileDialog();
            try
            {
                dlg.InitialDirectory = _fileLocation;
                dlg.Filter = "Log Files|AW*.log";
                dlg.FilterIndex = 1;
                dlg.RestoreDirectory = true;
                if (DialogResult.OK == dlg.ShowDialog())
                {
                    fileName = dlg.FileName;
                    //fs = new FileStream(dlg.FileName, FileMode.Open, FileAccess.Read);
                    opened = true;
                }
            }
            catch (Exception e)
            {
                LogManager.Error(e);
            }
            return opened;
        }

        private void Instance_OnWarn(string message, object source = null)
        {
            if (LogToFile())
            {
                WriteMessage("WRN", message);
            }
        }

        private void Instance_OnTrace(string message, object source = null)
        {
            if (LogToFile())
            {
                WriteMessage("TRC", message);
            }
        }

        private void Instance_OnInfo(string message, object source = null)
        {
            if (LogToFile())
            {
                WriteMessage("INF", message);
            }
        }

        private void Instance_OnError(string message, string stackTrace, object source = null)
        {
            if (LogToFile())
            {
                WriteMessage("ERR", message, stackTrace);
            }
        }

        private void Instance_OnDebug(string message, object source=null)
        {
            if (LogToFile() && LogDebugMessages())
            {
                WriteMessage("DBG", message);
            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        private void WriteMessage(string level, string message)
        {
            using (var fs = new FileStream(_logFileName, FileMode.Append, FileAccess.Write))
            using (var sw = new StreamWriter(fs))
            {
                string timeStamp = string.Format("{0}:{1:HH:mm:ss}", level, DateTime.Now);
                if (message == null)
                    message = "";

                message = message.Replace("<br/>", "\r\n");
                using (var sr = new StringReader(message))
                {
                    string blank = _buffer.Substring(0, _margin);
                    string line = sr.ReadLine();
                    while (line != null)
                    {
                        sw.WriteLine("{0} - {1}", timeStamp, line);
                        line = sr.ReadLine();
                        timeStamp = blank;
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        private void WriteMessage(string level, string message, string stackTrace)
        {
            using (var fs = new FileStream(_logFileName, FileMode.Append, FileAccess.Write))
            using (var sw = new StreamWriter(fs))
            {
                string blank = _buffer.Substring(0, _margin);
                message = message.Replace("<br/>", "\r\n");
                sw.WriteLine("{0}:{1:HH:mm:ss} - {2}", level, DateTime.Now, message);
                if (!string.IsNullOrWhiteSpace(stackTrace))
                {
                    using (var sr = new StringReader(stackTrace))
                    {
                        string line = sr.ReadLine();
                        while (line != null)
                        {
                            sw.Write(blank);
                            sw.WriteLine(line);
                            line = sr.ReadLine();
                        }
                    }
                }
            }
        }


        private bool LogToFile()
        {
            return (bool) ATMLContext.GetProperty("logging.log.file", false);
        }

        private bool LogDebugMessages()
        {
            return (bool) ATMLContext.GetProperty("logging.debug.messages", false);
        }

        private void BuildLogFileName()
        {
            _logFileName = Path.Combine(_fileLocation,
                                        string.Format("{0}{1:yyyy-MM-dd}.log",
                                                      "AW",
                                                      _today));
            if (!Directory.Exists(_fileLocation))
                Directory.CreateDirectory(_fileLocation);
        }
    }
}