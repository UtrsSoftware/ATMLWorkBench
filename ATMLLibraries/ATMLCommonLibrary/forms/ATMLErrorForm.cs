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
using System.Windows.Forms;

namespace ATMLCommonLibrary.forms
{
    public partial class ATMLErrorForm : ATMLForm
    {
        public ATMLErrorForm( Exception e )
        {
            String message = e.Message;
            InitializeComponent();
            StringBuilder sb = new StringBuilder();
            sb.Append(e.Message);
            sb.Append("\r\n");
            sb.Append(e.StackTrace).Append("\r\n\r\n");
            e = e.InnerException;
            while (e != null)
            {
                message = e.Message;
                sb.Append(e.Message);
                sb.Append("\r\n");
                sb.Append(e.StackTrace).Append("\r\n\r\n");
                e = e.InnerException;
            }

            StringBuilder htmlError = new StringBuilder();
            if (sb.ToString().Contains("'Microsoft.ACE.OLEDB.12.0' provider is not registered on the local machine"))
            {
                htmlError.Append(
                    "<h2 style=\"color:red;\">The 'Microsoft.ACE.OLEDB.12.0; provider is not registered.</h2>");
                htmlError.Append(
                    "<p>The 'Microsoft.ACE.OLEDB.12.0' provider has not been registered on this machine. You may do so by visiting the <a href=\"http://www.microsoft.com/en-us/download/confirmation.aspx?id=23734\" >Microsoft web site (http://www.microsoft.com/en-us/download/confirmation.aspx?id=23734) </a>and installing the 'Microsoft.ACE.OLEDB.12.0' database engine.</p>");
            }
            else
            {
                htmlError.Append("<h2 style=\"color:red;\">").Append(message).Append("</h2>");
                htmlError.Append("<pre>").Append(sb).Append("</pre>");
            }

            webBrowser.DocumentText = htmlError.ToString();
        }


        public ATMLErrorForm( String title, String message, string note = null )
        {
            InitializeComponent();

            StringBuilder htmlError = new StringBuilder();
            htmlError.Append("<h3 style=\"color:red;\">").Append(title).Append("</h3>");
            htmlError.Append("<div style=\"font-family:monospace; white-space: pre-wrap;\">").Append(message).Append("</div>");
            if( note != null )
                htmlError.Append("<strong style=\"color:red;\">").Append(note).Append("</strong>");

            webBrowser.DocumentText = htmlError.ToString();
        }


        public static void ShowError(Exception e)
        {
            ATMLErrorForm form = new ATMLErrorForm(e);
            form.Show();
        }

        public static void ShowValidationMessage( string title, string message, string note = null )
        {
            ATMLErrorForm form = new ATMLErrorForm(title.Replace("\n", "<br/>"), message.Replace("\n", "<br/>"), note);
            form.Show();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            webBrowser.ShowPrintPreviewDialog();
        }




    }
}
