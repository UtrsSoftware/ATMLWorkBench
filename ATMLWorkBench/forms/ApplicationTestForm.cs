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
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ATMLCommonLibrary.forms;
using ATMLManagerLibrary.managers;
using ATMLModelLibrary.model.common;
using ATMLWorkBench.Properties;

namespace ATMLWorkBench.forms
{
    public partial class ApplicationTestForm : ATMLForm
    {
        public ApplicationTestForm()
        {
            InitializeComponent();
            Document xmlDocument = DocumentManager.GetDocumentByName( "test-script.xml" );
            Document xslDocument = DocumentManager.GetDocumentByName("test-script-form.xsl");
            var form = new ATMLXslTranslationForm(xmlDocument, xslDocument);
            form.Text = @"Test";
            form.ShowDialog();
        }

        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
    }
}
