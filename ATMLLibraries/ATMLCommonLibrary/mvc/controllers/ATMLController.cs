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
using ATMLCommonLibrary.controls.awb;

namespace ATMLCommonLibrary.mvc.controllers
{
    public class ATMLController
    {
        Dictionary<string, AWBTextBox > editBoxes = new Dictionary<string, AWBTextBox>();
 
        public void RegisterControls(ContainerControl container)
        {
            foreach (Control co in container.Controls)
            {
                if (co is AWBTextBox)
                {
                    AWBTextBox tb = co as AWBTextBox;
                    editBoxes.Add( tb.AttributeName, tb );
                }
            }
        }
    }
}
