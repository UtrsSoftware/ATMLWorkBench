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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ATMLWorkBench.controls
{
    public partial class Knob : UserControl
    {
        private int rotation=0;

        public int Rotation
        {
            get { return rotation; }
            set { rotation = value; }
        }


        public Knob()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Matrix matrix = new Matrix();
            base.OnPaint(e);

            Pen pen = new Pen( Color.Red, 2 );
            Pen penBlack = new Pen(Color.Black, 1);
            Brush brush = new SolidBrush(Color.Silver);

            Rectangle r = new Rectangle(this.ClientRectangle.Left, this.ClientRectangle.Top, this.ClientRectangle.Width, this.ClientRectangle.Height );
            r.Inflate(-1, -1);
            if( r.Width % 2 != 0 )
                r.Width = r.Width - 1;
            if( r.Height % 2 != 0 )
                r.Height = r.Height - 1;
            Point centerPoint = new Point(r.Width / 2, r.Height / 2);
            int diamaeter = this.ClientRectangle.Width;
            float radius = diamaeter / 2;

            double radians = (rotation-90) * Math.PI / 180;

            e.Graphics.FillEllipse(brush, r );
            e.Graphics.DrawEllipse(penBlack, r);
            r.Inflate(-2, -2);
            e.Graphics.Transform = matrix;
            e.Graphics.DrawLine(pen, (int)( centerPoint.X * Math.Cos(radians) + centerPoint.X ),
                                     (int)( centerPoint.Y * Math.Sin(radians) + centerPoint.Y ),
                                     centerPoint.X,
                                     centerPoint.Y);

        }
    }
}
