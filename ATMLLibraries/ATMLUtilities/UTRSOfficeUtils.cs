/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Globalization;
using System.Reflection;
using System.Threading;
using Microsoft.Office.Core;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.PowerPoint;
using Microsoft.Office.Interop.Word;
using Microsoft.Win32;
using Application = Microsoft.Office.Interop.Word.Application;

namespace ATMLUtilitiesLibrary
{
    public class UTRSOfficeUtils
    {
        public enum MSOfficeApplications
        {
            Access,
            Excel,
            Word,
            PowerPoint,
            Outlook
        }

        public static bool IsInstalled( MSOfficeApplications app )
        {
            string keyName = String.Empty;
            switch (app)
            {
                case MSOfficeApplications.Access:
                    keyName = "Access.Application";
                    break;
                case MSOfficeApplications.Excel:
                    keyName = "Excel.Application";
                    break;
                case MSOfficeApplications.Word:
                    keyName = "Word.Application";
                    break;
                case MSOfficeApplications.PowerPoint:
                    keyName = "PowerPoint.Application";
                    break;
                case MSOfficeApplications.Outlook:
                    keyName = "Outlook.Application";
                    break;
            }

            RegistryKey key = Registry.ClassesRoot;
            RegistryKey subKey = key.OpenSubKey( keyName );
            return ( subKey != null );
        }

        public static bool IsWordDocument( string fileExtension )
        {
            return ".doc, .docx, .rtf".Contains( fileExtension.ToLower() );
        }

        public static bool IsExcelDocument( string fileExtension )
        {
            return ".xls, .xlsx".Contains( fileExtension.ToLower() );
        }

        public static bool IsPowerPointDocument( string fileExtension )
        {
            return ".ppt, .pptx".Contains( fileExtension.ToLower() );
        }

        public static Uri OfficeDocToHtml( string fullFileName, MSOfficeApplications officeType )
        {
            Uri url = null;
            switch (officeType)
            {
                case MSOfficeApplications.Excel:
                    url = ProcessExcelDocument( fullFileName );
                    break;
                case MSOfficeApplications.Word:
                    url = ProcessWordDocument( fullFileName );
                    break;
                case MSOfficeApplications.PowerPoint:
                    url = ProcessPowerPointDocument( fullFileName );
                    break;
                case MSOfficeApplications.Outlook:
                    //keyName = "Outlook.Application";
                    break;
            }
            return url;
        }

        private static Uri ProcessWordDocument( string fullFileName )
        {
            object oTempFile = string.Format( "{0}\\{1}.html",
                                              Environment.GetFolderPath( Environment.SpecialFolder.InternetCache ),
                                              Guid.NewGuid() );
            object oFile = fullFileName;
            object oMissing = Missing.Value;
            object oReadOnly = true;
            object oFileType = WdSaveFormat.wdFormatHTML;
            CultureInfo saveCulture = Thread.CurrentThread.CurrentCulture;
            Application application = null;
            try
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo( "en-US" );
                application = new Application();
                Document document = application.Documents.Open( ref oFile, ref oMissing, ref oReadOnly, ref oMissing,
                                                                ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                                                                ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                                                                ref oMissing, ref oMissing, ref oMissing, ref oMissing );
                if (document != null)
                {
                    document.SaveAs( ref oTempFile, oFileType, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                                     ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                                     ref oMissing, ref oMissing, ref oMissing, ref oMissing );
                }
            }
            finally
            {
                if (application != null)
                    application.Quit();
                Thread.CurrentThread.CurrentCulture = saveCulture;
            }
            return new Uri( oTempFile.ToString() );
        }


        private static Uri ProcessExcelDocument( string fullFileName )
        {
            string tempFile = string.Format( "{0}\\{1}.html",
                                             Environment.GetFolderPath( Environment.SpecialFolder.InternetCache ),
                                             Guid.NewGuid() );
            object oMissing = Missing.Value;
            object oReadOnly = true;
            object oFileType = XlFileFormat.xlHtml;
            CultureInfo saveCulture = Thread.CurrentThread.CurrentCulture;
            Microsoft.Office.Interop.Excel.Application application = null;
            try
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo( "en-US" );
                application = new Microsoft.Office.Interop.Excel.Application();
                Workbook document = application.Workbooks.Open( fullFileName, oMissing, oReadOnly, oMissing,
                                                                oMissing, oMissing, oMissing, oMissing, oMissing,
                                                                oMissing, oMissing, oMissing, oMissing, oMissing,
                                                                oMissing );
                if (document != null)
                {
                    document.SaveAs( tempFile, //File Name
                                     oFileType, //File Format
                                     oMissing, //Password
                                     oMissing, //Write Res Password
                                     oMissing, //ReadOnly Recommended
                                     oMissing, //Create Backup
                                     XlSaveAsAccessMode.xlExclusive, //AccessMode
                                     oMissing, //Conflict Resolution
                                     oMissing, //Add To MRU
                                     oMissing, //Text Codepage
                                     oMissing, //Text Visual Layout
                                     oMissing //Local
                        );
                }
            }
            finally
            {
                if (application != null)
                    application.Quit();
                Thread.CurrentThread.CurrentCulture = saveCulture;
            }
            return new Uri( tempFile );
        }


        private static Uri ProcessPowerPointDocument( string fullFileName )
        {
            string tempFile = string.Format( "{0}\\{1}.html",
                                             Environment.GetFolderPath( Environment.SpecialFolder.InternetCache ),
                                             Guid.NewGuid() );
            CultureInfo saveCulture = Thread.CurrentThread.CurrentCulture;
            Microsoft.Office.Interop.PowerPoint.Application application = null;
            try
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo( "en-US" );
                application = new Microsoft.Office.Interop.PowerPoint.Application();
                Presentation document = application.Presentations.Open( fullFileName,
                                                                        MsoTriState.msoFalse,
                                                                        MsoTriState.msoFalse,
                                                                        MsoTriState.msoFalse );
                if (document != null)
                {
                    document.SaveAs( tempFile, //File Name
                                     PpSaveAsFileType.ppSaveAsHTML,
                                     MsoTriState.msoFalse
                        );
                }
            }
            finally
            {
                if (application != null)
                    application.Quit();
                Thread.CurrentThread.CurrentCulture = saveCulture;
            }
            return new Uri( tempFile );
        }
    }
}