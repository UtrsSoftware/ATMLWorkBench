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
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ATMLWorkBench.controls
{
    public partial class SignalPlotter : UserControl
    {
        public SignalPlotter()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            DoPage(e.Graphics, Color.Red, ClientSize.Width, ClientSize.Height);
        }

        protected void DoPage(Graphics grfx, Color clr, int cx, int cy)
        {
            PointF[] aptf = new PointF[cx];

            for( int i = 0; i < cx; i++ )
            {
                aptf[i].X = i;
                aptf[i].Y = SupCarSignal(.3f, 1f, 1000f, 10000f, i);
                    //cy / 2 * ( 1 - (float)Math.Sin(i * 2 * Math.PI / ( cx - 1 )) );
            }
            grfx.DrawLines(new Pen(clr), aptf);
        }

        private float SupCarSignal(float modAmp, float unmodAmp, float modFreq, float carFreq, float t)
        {
            double wm = 2 * Math.PI * modFreq;
            double wc = 2 * Math.PI * carFreq;
            float e = 0f;
            e = (float)(( ( modAmp * unmodAmp ) / 2 ) * Math.Cos((wc + wm) * t) + ( ( modAmp * unmodAmp ) / 2 ) * Math.Cos((wc - wm) * t));
            return e;
        }

        //e = (EmEc/2)cos(ωc+ωm)t+(EmEc/2)cos(ωc-ωm)t
        /*
            Em is the modulation signal amplitude
            Ec is the carrier amplitude (unmodulated)
            ωm is 2π × modulating frequency
            ωc is 2π × carrier frequency
         */

    }
}
