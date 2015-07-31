/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using ATMLUtilitiesLibrary;

namespace ATMLManagerLibrary.managers
{
    public delegate void LogEventHandler(string message, object source = null);

    public delegate void ErrorEventHandler(string message, string stackTrace, object source=null);


    /**
     * The LogManager provides an interface into the ATML Workbench logging system.
     */

    public class LogManager
    {
        private const string CRLF = "\r\n";

        private static volatile LogManager _instance;
        private static readonly object syncRoot = new Object();

        private LogManager()
        {
            if (!EventLog.SourceExists(ATMLContext.APPLICATION_NAME))
                EventLog.CreateEventSource(ATMLContext.APPLICATION_NAME, "Application" );
        }

        public event LogEventHandler OnTrace;
        public event ErrorEventHandler OnError;
        public event LogEventHandler OnInfo;
        public event LogEventHandler OnWarn;
        public event LogEventHandler OnDebug;

        public static LogManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (syncRoot)
                    {
                        if (_instance == null)
                            _instance = new LogManager();
                    }
                }
                return _instance;
            }
        }

        public static void Debug(String message, params object[] list)
        {
            Instance.LocalDebug(message, list);
        }

        public static void Debug(Exception e )
        {
            Instance.LocalDebug(e);
        }

       
        public static void Trace(String message, params object[] list)
        {
            Instance.LocalTrace(message, list);
        }

        public static void SourceTrace(object source, String message, params object[] list)
        {
            Instance.LocalSourceTrace( source, message, list);
        }

        public static void Warn(String message, params object[] list)
        {
            Instance.LocalWarn(message, list);
        }

        public static void SourceWarn(object source, String message, params object[] list)
        {
            Instance.LocalSourceWarn(source, message, list);
        }

        private void LocalTrace(String message, params object[] list)
        {
            if (OnTrace != null)
                OnTrace((list.Length == 0 ? message : string.Format(message, list)));
        }

        private void LocalSourceTrace(object source, String message, params object[] list)
        {
            if (OnTrace != null)
                OnTrace((list.Length == 0 ? message : string.Format(message, list)), source);
        }


        private void LocalWarn(String message, params object[] list)
        {
            message = (list.Length == 0 ? message : string.Format(message, list));
            if (OnWarn != null)
                OnWarn(message);
            EventLog.WriteEntry(ATMLContext.APPLICATION_NAME, message, EventLogEntryType.Warning );
        }

        private void LocalSourceWarn(object source, String message, params object[] list)
        {
            message = (list.Length == 0 ? message : string.Format(message, list));
            if (OnWarn != null)
                OnWarn(message, source);
            EventLog.WriteEntry(ATMLContext.APPLICATION_NAME, message, EventLogEntryType.Warning);
        }


        protected virtual void LocalDebug(string message, params object[] list)
        {
            if (OnDebug != null && ATMLContext.IsValid)
                OnDebug((list.Length == 0 ? message : string.Format(message, list)));
        }

        protected virtual void LocalDebug(Exception e )
        {
            if (OnDebug != null && ATMLContext.IsValid)
            {
                StringBuilder sb = new StringBuilder(string.Format("{0}{1}{2}{3}", e.Message, CRLF, e.StackTrace, CRLF));
                Exception inner = e.InnerException;
                while (inner != null)
                {
                    sb.Append(inner.Message).Append(CRLF);
                    sb.Append(inner.StackTrace).Append(CRLF);
                    inner = inner.InnerException;
                }
                OnDebug(sb.ToString());
            }
        }

        private void LocalError(String message, string stackTrace, params object[] list)
        {
            message = list.Length == 0 ? message : string.Format(message, list);
            if (OnError != null)
                OnError(message, stackTrace);
            EventLog.WriteEntry(ATMLContext.APPLICATION_NAME, message, EventLogEntryType.Error );
        }

        private void LocalSourceError(object source, String message, string stackTrace, params object[] list)
        {
            message = list.Length == 0 ? message : string.Format(message, list);
            if (OnError != null)
                OnError(message, stackTrace, source);
            EventLog.WriteEntry(ATMLContext.APPLICATION_NAME, message, EventLogEntryType.Error);
        }

        private void LocalInfo(String message, params object[] list)
        {
            message = ( list.Length == 0 ? message : string.Format( message, list ) ); 
            if (OnInfo != null)
                OnInfo( message );
            EventLog.WriteEntry(ATMLContext.APPLICATION_NAME, message, EventLogEntryType.Information );
        }

        private void LocalSourceInfo(object source, String message, params object[] list)
        {
            message = (list.Length == 0 ? message : string.Format(message, list));
            if (OnInfo != null)
                OnInfo(message, source);
            EventLog.WriteEntry(ATMLContext.APPLICATION_NAME, message, EventLogEntryType.Information);
        }

        public static void Info(String message, params object[] list)
        {
            Instance.LocalInfo(message, list);
        }

        public static void SourceInfo(object source, String message, params object[] list)
        {
            Instance.LocalSourceInfo(source, message, list);
        }

        public static void Error(Exception e)
        {
            var sb = new StringBuilder();
            WriteException(e, sb);
            Instance.LocalError(e.Message, sb.ToString());
        }

        public static void SourceError(object source, Exception e)
        {
            var sb = new StringBuilder();
            WriteException(e, sb);
            Instance.LocalSourceError(source, e.Message, sb.ToString());
        }

        public static void Error(string message, params object[] list)
        {
            var sb = new StringBuilder();
            message = System.Security.SecurityElement.Escape(message) ?? "";
            sb.Append(String.Format(message, list)).Append(CRLF);
            Instance.LocalError(sb.ToString(), null);
        }

        public static void SourceError(object source, string message, params object[] list)
        {
            var sb = new StringBuilder();
            message = System.Security.SecurityElement.Escape(message) ?? "";
            sb.Append(String.Format(message, list)).Append(CRLF);
            Instance.LocalSourceError(source, sb.ToString(), null);
        }

        public static void Error(Exception e, string message, params object[] list)
        {
            var sb = new StringBuilder();
            message = list.Length == 0 ? message : string.Format(message, list);
            sb.Append(message).Append(CRLF);
            sb.Append(e.Message).Append(CRLF);
            WriteException(e, sb);
            Instance.LocalError(message, sb.ToString());
        }

        public static void SourceError(object source, Exception e, string message, params object[] list)
        {
            var sb = new StringBuilder();
            message = list.Length == 0 ? message : string.Format(message, list);
            sb.Append(message).Append(CRLF);
            sb.Append(e.Message).Append(CRLF);
            WriteException(e, sb);
            Instance.LocalSourceError(source, message, sb.ToString());
        }


        [Conditional("DEBUG")]
        private static void WriteException(Exception e, StringBuilder sb)
        {
            sb.Append(e.StackTrace).Append(CRLF);
            Exception inner = e.InnerException;
            while (inner != null)
            {
                sb.Append(inner.Message).Append(CRLF);
                sb.Append(inner.StackTrace).Append(CRLF);
                inner = inner.InnerException;
            }
        }
    }
}