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
using System.Drawing;

namespace ATMLCommonLibrary.controls.awb
{
    public class AWBListView : ListView
    {
        public AWBListView()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.EnableNotifyMessage, true);
        }

        protected override void OnNotifyMessage(Message m)
        {
            //Filter out the WM_ERASEBKGND message
            if (m.Msg != 0x14)
            {
                base.OnNotifyMessage(m);
            }
        }

        private Color altColor1 = Color.White;
        public Color AltColor1
        {
            get { return altColor1; }
            set { altColor1 = value; }
        }

        private Color altColor2 = Color.Honeydew;
        public Color AltColor2
        {
            get { return altColor2; }
            set { altColor2 = value; }
        }

    }
}
