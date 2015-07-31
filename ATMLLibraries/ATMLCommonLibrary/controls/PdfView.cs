/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MessageBox = System.Windows.MessageBox;

namespace ATMLCommonLibrary.controls
{
    public class PdfView : AxAcroPDFLib.AxAcroPDF
    {
        #region IPreview Members

        public void Preview(string path)
        {
            //this.MouseUp+=delegate( object sender, MouseEventArgs args )
            //{
            //    MessageBox.Show("Hit!");
            //};
            this.src = path;
        }

        #endregion
    }
}
