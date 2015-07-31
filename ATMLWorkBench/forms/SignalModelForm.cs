/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ATMLWorkBench.model;

namespace ATMLWorkBench.Forms
{
    public partial class SignalModelContainer : Form
    {

        public SignalModelContainer()
        {
            InitializeComponent();
        }

        private void tbAddSignal_Click(object sender, EventArgs e)
        {
            panel.addSignal();
        }

    }


    public class SignalContainer : Panel
    {
        private List<SignalComponent> signalComponents = new List<SignalComponent>();
        private List<SignalConnector> signalConnectors = new List<SignalConnector>();
        private SignalComponent activeSignal = null;
        private int activeLocationX = 0;
        private int activeLocationY = 0;

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            MouseUp += new MouseEventHandler(SignalModelContainer_MouseUp);
            MouseMove += new MouseEventHandler(SignalModelContainer_MouseMove);
        }


        private void clearSelected()
        {
            foreach( SignalComponent comps in signalComponents )
            {
                if( comps.Selected )
                    Invalidate(comps.getAffectedRegion());
                comps.Selected = false;
            }
        }


        void SignalModelContainer_MouseMove(object sender, MouseEventArgs e)
        {
            if( e.Button == MouseButtons.Left )
            {
                if( activeSignal != null && ClientRectangle.Contains( e.X, e.Y ) )
                 {
                    Rectangle r1 = activeSignal.Bounds;
                    activeSignal.Location = new Point(e.X - activeLocationX, e.Y - activeLocationY);
                    int left = Math.Max( 0, Math.Min(r1.Left, activeSignal.Location.X) );
                    int top = Math.Max( 0, Math.Min(r1.Top, activeSignal.Location.Y) );
                    int right = Math.Max(left + r1.Width, activeLocationX + activeSignal.Width);
                    int bottom = Math.Max(top + r1.Height, activeLocationY + activeSignal.Height);
                    Rectangle r2 = new Rectangle(left, top, right+10, bottom+10);
                    Region region = new Region(r1);
                    region.Union(r2);
                    region.Union(activeSignal.getAffectedRegion());
                    Invalidate(region);
                    Update();
                    activeLocationX = e.X - activeSignal.Location.X;
                    activeLocationY = e.Y - activeSignal.Location.Y;
                }
            }
        }

        void SignalModelContainer_MouseUp(object sender, MouseEventArgs e)
        {
            if( activeSignal != null )
            {
                Invalidate(activeSignal.getAffectedRegion());
                Update();
                activeSignal = null;
            }
        }

        public void addSignal()
        {
            SignalComponent priorSignal = null;
            SignalComponent signal = new SignalComponent( this );
            if( signalComponents.Count > 0 )
                priorSignal = signalComponents.Last();
            signalComponents.Add(signal);
            signal.Location = new Point(10, 10);
            if( priorSignal != null )
                signalConnectors.Add( new SignalConnector( ref priorSignal, ref signal ) );
            Invalidate();
            Update();
        }


        protected override void OnPaint(PaintEventArgs e)
        {

            //Bitmap offScreenBmp;
            //Graphics offScreenDC;
            //offScreenBmp = new Bitmap(this.Width, this.Height);
            //offScreenDC = Graphics.FromImage(offScreenBmp);
            //Graphics clientDC = this.CreateGraphics(); 

            //base.OnPaint(e);
            //offScreenDC.FillRectangle(Brushes.White, ClientRectangle);
            foreach( SignalComponent comps in signalComponents )
            {
                comps.Paint(e.Graphics);
            }
            foreach( SignalConnector connector in signalConnectors )
            {
                connector.Paint(e.Graphics);
            }
            //clientDC.DrawImage(offScreenBmp, 0, 0);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {

            base.OnMouseDown(e);
            foreach( SignalComponent signal in signalComponents )
            {
                if( signal.Bounds.Contains(e.X, e.Y) )
                {
                    clearSelected();
                    activeSignal = signal;
                    activeSignal.Selected = true;
                    activeLocationX = e.X - signal.Location.X;
                    activeLocationY = e.Y - signal.Location.Y;
                    Invalidate(signal.getAffectedRegion());
                    Update();

                }
            }

        }
    }



    public class SignalComponent 
    {

        private List<SignalConnector> connectionsIn = new List<SignalConnector>();
        private List<SignalConnector> connectionsOut = new List<SignalConnector>();

        private Font titleFont = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold);
        private Font detailFont = new Font(FontFamily.GenericSansSerif, 8 );
        private Boolean selected = false;
        public Boolean Selected
        {
            get { return selected; }
            set { selected = value; }
        }

        private Signal signal;
        internal Signal Signal
        {
            get { return signal; }
            set { signal = value;maintainBounds();}
        }
        private int width = 150;
        public int Width
        {
            get { return width; }
            set { width = value; maintainBounds(); }
        }
        private int height = 100;
        public int Height
        {
            get { return height; }
            set { height = value; maintainBounds(); }
        }
        private Point location = new Point(0, 0);
        public Point Location
        {
            get { return location; }
            set { location = value; maintainBounds(); }
        }

        private Rectangle bounds;
        public Rectangle Bounds
        {
            get { return new Rectangle(location.X, location.Y, Width, Height); }
            set { location.X = value.Left; 
                    location.Y = value.Top;
                    Width = value.Width; 
                    Height = value.Height;
            }
        }

        public Region getAffectedRegion()
        {
            Region region = new Region();
            region.MakeEmpty();
            //region.Union(Bounds);
            foreach( SignalConnector conn in connectionsIn )
                region.Union(conn.getRegion());
            foreach( SignalConnector conn in connectionsOut )
                region.Union(conn.getRegion());
            return region;
        }

        private System.Windows.Forms.Control container;

        public SignalComponent(System.Windows.Forms.Control container)
        {
            this.container = container;
        }

        public void addConnectionIn(SignalConnector connector)
        {
            connectionsIn.Add(connector);
        }

        public void addConnectionOut(SignalConnector connector)
        {
            connectionsOut.Add(connector);
        }

        public void Paint(Graphics g )
        {
            Pen pen = new Pen(Color.Red, 2);
            using( pen )
            {
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                Rectangle r = new Rectangle(location.X, location.Y, width, height);
                DrawRoundRect(g, Brushes.LightSlateGray, Pens.SlateGray, r.Left, r.Top, r.Width, r.Height, 10f);
                if( selected )
                {
                    r.Inflate(-2, -2);
                    DrawRoundRect( g, null, pen, r.Left, r.Top, r.Width, r.Height, 10f );
                }
                r.Inflate( -5, -5 );
                g.DrawString( "AC_SIGNAL", titleFont, Brushes.Black, r.Left, r.Top );
                g.DrawString("Freq: 300hz", detailFont, Brushes.Black, r.Left, r.Top+20 );
                g.DrawString("Ampl: 1v", detailFont, Brushes.Black, r.Left, r.Top + 35);
                g.DrawString("Phase: 0r", detailFont, Brushes.Black, r.Left, r.Top + 50);
                pen.Dispose();
            }
        }


        public void DrawRoundRect(Graphics g, Brush b, Pen p, float x, float y, float width, float height, float radius )
        {
            GraphicsPath gp = new GraphicsPath();

            gp.AddLine(x + radius, y, x + width - ( radius * 2 ), y); // Line
            gp.AddArc(x + width - ( radius * 2 ), y, radius * 2, radius * 2, 270, 90); // Corner
            gp.AddLine(x + width, y + radius, x + width, y + height - ( radius * 2 )); // Line
            gp.AddArc(x + width - ( radius * 2 ), y + height - ( radius * 2 ), radius * 2, radius * 2, 0, 90); // Corner
            gp.AddLine(x + width - ( radius * 2 ), y + height, x + radius, y + height); // Line
            gp.AddArc(x, y + height - ( radius * 2 ), radius * 2, radius * 2, 90, 90); // Corner
            gp.AddLine(x, y + height - ( radius * 2 ), x, y + radius); // Line
            gp.AddArc(x, y, radius * 2, radius * 2, 180, 90); // Corner
            gp.CloseFigure();

            g.DrawPath(p, gp);
            if( b != null )
            {
                g.FillPath(b, gp);
            }
            gp.Dispose();
        }

        private void maintainBounds()
        {
            Rectangle r = new Rectangle(location.X, location.Y, width, height);
            if( !bounds.Contains(r) )
            {
                if( location.X <= container.ClientRectangle.Left )
                    location.X = container.ClientRectangle.Left;
                if( location.Y <= container.ClientRectangle.Top )
                    location.Y = container.ClientRectangle.Top;
                if( location.X + Width >= container.ClientRectangle.Width )
                    location.X = container.ClientRectangle.Width - Width;
                if( location.Y + Height >= container.ClientRectangle.Height )
                    location.Y = container.ClientRectangle.Height - Height;
            }
        }


    }

    public class SignalConnector
    {
        SignalComponent source;
        SignalComponent target;

        Point origin;
        Point destination;

        public SignalConnector(ref SignalComponent source, ref SignalComponent target)
        {
            this.source = source;
            this.target = target;
            source.addConnectionOut(this);
            target.addConnectionOut(this);
        }

        public Region getRegion()
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddLine(origin, destination);
            Region region = new Region();
            int l = Math.Min(source.Bounds.Left, target.Bounds.Left);
            int t = Math.Min(source.Bounds.Top, target.Bounds.Top);
            int r = Math.Max(source.Bounds.Right, target.Bounds.Right);
            int b = Math.Max(source.Bounds.Bottom, target.Bounds.Bottom);

            Rectangle rect = new Rectangle(1, t, r-1, b-t);
            region.MakeEmpty();
            region.Union(rect);
            return region;
        }

        public void Paint(Graphics g)
        {
            createLine();
            Pen pen = new Pen(Color.Red, 1);
            using( pen )
            {
                System.Drawing.Drawing2D.AdjustableArrowCap bigArrow = new System.Drawing.Drawing2D.AdjustableArrowCap(5, 5);
                pen.CustomEndCap = bigArrow;
                g.DrawLine(pen, origin, destination);
            }
        }

        private void createLine()
        {
            origin = new Point(source.Bounds.Right,
                                ( source.Bounds.Top + source.Bounds.Height / 2 ));

            destination = new Point(target.Bounds.Left,
                                ( target.Bounds.Top + target.Height / 2 ));
        }



    }



}
