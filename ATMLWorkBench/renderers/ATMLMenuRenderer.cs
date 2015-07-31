/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ATMLWorkBench.renderers
{
    public class ATMLMenuRenderer : ToolStripProfessionalRenderer
    {
        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        {
            var r = e.AffectedBounds;
            var b = new LinearGradientBrush(r, Color.LightSteelBlue, Color.White,
                LinearGradientMode.Vertical);
            try
            {
                Point bl = new Point( e.AffectedBounds.X, e.AffectedBounds.Height-1 );
                Point br = new Point( e.AffectedBounds.X+e.AffectedBounds.Width, e.AffectedBounds.Height-1 );
                e.Graphics.FillRectangle(b, e.AffectedBounds);
                e.Graphics.DrawLine(Pens.DarkGray, bl, br );
            }
            finally
            {
                b.Dispose();
            }
        }

        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            if (!e.Item.Selected)
            {
                base.OnRenderMenuItemBackground(e);
            }
            else
            {
                var r = e.Item.ContentRectangle;
                var b = new LinearGradientBrush(r, Color.White, Color.Gold, LinearGradientMode.Vertical);
                try
                {
                    e.Graphics.FillRectangle(b, e.Item.ContentRectangle);
                    e.Graphics.DrawRectangle(Pens.Goldenrod, e.Item.ContentRectangle );
                }
                finally
                {
                    b.Dispose();
                }
            }
        }

        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            if (e.Item is ToolStripMenuItem && ((ToolStripMenuItem) e.Item).Checked)
            {
                Rectangle rect = e.TextRectangle;
                rect.X += 5;
                e.Graphics.DrawString( e.Text, e.Item.Font, Brushes.Black, new Point( rect.X+5, rect.Y ) );
            }
            else
            {
                base.OnRenderItemText(e);
            }
        }

        protected override void OnRenderItemImage(ToolStripItemImageRenderEventArgs e)
        {
            Rectangle rect = new Rectangle(25,1,16,16);
            if (e.Item is ToolStripMenuItem && ((ToolStripMenuItem)e.Item).Checked)
                e.Graphics.DrawImage(e.Image, rect);
            else
                base.OnRenderItemImage(e);
            
        }

        protected override void OnRenderImageMargin(ToolStripRenderEventArgs e)
        {
            base.OnRenderImageMargin(e);
        }

        protected override void OnRenderItemCheck(ToolStripItemImageRenderEventArgs e)
        {
            base.OnRenderItemCheck(e);
            /*
            if (e.Item is ToolStripMenuItem )
            {
                if (((ToolStripMenuItem) e.Item).Checked)
                {
                    Rectangle rect = new Rectangle(3, 3, 12, 12);
                    e.Graphics.DrawRectangle(Pens.Black, rect);
                    e.Graphics.DrawLine(Pens.Black, new Point(5,12), new Point( 8,12 ) );
                    e.Graphics.DrawLine(Pens.Black, new Point(8, 12), new Point(11, 4));
                }
                else
                {
                    Rectangle rect = new Rectangle(3, 3, 12, 12);
                    e.Graphics.DrawRectangle(Pens.Black, rect);
                }
            }
            else
            {
                base.OnRenderItemCheck(e);
            }
             * */
        }


    }
}
