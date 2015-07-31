/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using ATMLUtilitiesLibrary;

namespace ATMLCommonLibrary.controls.awb
{
    public class AWBTabControl : TabControl
    {
        private const int nMargin = 5;
        private readonly Color _errColor = UTRSGraphicsUtils.LightenColor(Color.Red,50);
        private readonly ImageList leftRightImages;
        private ErrorProvider ep = new ErrorProvider();

        /// <summary>
        ///     Required designer variable.
        /// </summary>
        private Container _components;

        private Color _mainBackColor = SystemColors.Control;
        private SubClass _scUpDown;
        private bool _upDown; // true when the button UpDown is required
        private ToolTip _toolTip = new AWBToolTip();
        private int _lastTab = -1;

        private Color _tabColor;


        public AWBTabControl()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();
            MouseMove += tabControl_MouseMove;
            MouseLeave += tabControl_MouseLeave;

            // double buffering
            SetStyle( ControlStyles.UserPaint, true );
            SetStyle( ControlStyles.AllPaintingInWmPaint, true );
            SetStyle( ControlStyles.DoubleBuffer, true );
            SetStyle( ControlStyles.ResizeRedraw, true );
            SetStyle( ControlStyles.SupportsTransparentBackColor, true );

            _upDown = false;

            ControlAdded += AWBTabControl_ControlAdded;
            ControlRemoved += AWBTabControl_ControlRemoved;
            SelectedIndexChanged += AWBTabControl_SelectedIndexChanged;

            leftRightImages = new ImageList();
            //leftRightImages.ImageSize = new Size(16, 16); // default

            var resources = new ResourceManager( typeof (AWBTabControl) );
            //Bitmap updownImage = ((System.Drawing.Bitmap)(resources.GetObject("TabIcons.bmp")));

            //if (updownImage != null)
            //{
            //	updownImage.MakeTransparent(Color.White);
            //	leftRightImages.Images.AddStrip(updownImage);
            //}
        }


        void tabControl_MouseLeave(object sender, EventArgs e)
        {
            _toolTip.SetToolTip(this, null);
            _lastTab = -1;
        }

        void tabControl_MouseMove(object sender, MouseEventArgs e)
        {
            int tabIdx = TestTab(new Point(e.X, e.Y));
            if (tabIdx != -1 && _lastTab != tabIdx)
            {
                _lastTab = tabIdx;
                _toolTip.SetToolTip(this, this.TabPages[tabIdx].ToolTipText);
            }
        }

        private int TestTab(Point pt)
        {
            int idx = -1;
            foreach (TabPage tabPage in this.TabPages)
            {
                if (this.GetTabRect(tabPage.TabIndex).Contains(pt))
                {
                    idx = tabPage.TabIndex;
                }
            }
            return idx;
        }

        /// <summary>
        ///     Clean up any resources being used.
        /// </summary>
        protected override void Dispose( bool disposing )
        {
            if (disposing)
            {
                if (_components != null)
                {
                    _components.Dispose();
                }

                leftRightImages.Dispose();
            }
            base.Dispose( disposing );
        }

        protected override void OnPaint( PaintEventArgs e )
        {
            base.OnPaint( e );

            DrawControl( e.Graphics );
        }

        internal void DrawControl( Graphics g )
        {
            if (!Visible)
                return;

            Rectangle tabControlArea = ClientRectangle;
            Rectangle tabArea = DisplayRectangle;

            FillControlClientArea( g, ref tabControlArea );
            DrawControlBorder( g, ref tabArea );
            Region rsaved = SetControlClippingArea( g, ref tabArea, ref tabControlArea );
            DrawTabs( g );
            g.Clip = rsaved;
            DrawBackgroundFix( g, ref tabArea );
        }

        private void DrawBackgroundFix( Graphics g, ref Rectangle tabArea )
        {
            //--------------------------------------------------//
            //--- draw background to cover flat border areas ---//
            //--------------------------------------------------//
            if (SelectedTab != null)
            {
                TabPage tabPage = SelectedTab;
                Color color = tabPage.BackColor;
                using (var border = new Pen( color ))
                {
                    tabArea.Offset( 1, 1 );
                    tabArea.Width -= 2;
                    tabArea.Height -= 2;

                    g.DrawRectangle( border, tabArea );
                    tabArea.Width -= 1;
                    tabArea.Height -= 1;
                    g.DrawRectangle( border, tabArea );

                    border.Dispose();
                }
            }
        }

        private void DrawTabs( Graphics g )
        {
            for (int i = 0; i < TabCount; i++)
                DrawTab( g, TabPages[i], i );
        }

        private Region SetControlClippingArea( Graphics g, ref Rectangle tabArea, ref Rectangle  tabControlArea )
        {
            //------------------------------------//
            //--- clip region for drawing tabs ---//
            //------------------------------------//
            Region rsaved = g.Clip;
            Rectangle rreg;

            int nWidth = tabArea.Width + nMargin;
            if (_upDown)
            {
                // exclude updown control for painting
                if (Win32.IsWindowVisible( _scUpDown.Handle ))
                {
                    var rupdown = new Rectangle();
                    Win32.GetWindowRect( _scUpDown.Handle, ref rupdown );
                    Rectangle rupdown2 = RectangleToClient( rupdown );

                    nWidth = rupdown2.X;
                }
            }

            rreg = new Rectangle( tabArea.Left, tabControlArea.Top, nWidth - nMargin, tabControlArea.Height );

            g.SetClip( rreg );
            return rsaved;
        }

        private void FillControlClientArea( Graphics g, ref Rectangle tabControlArea )
        {
            //------------------------//
            //--- Fill client area ---//
            //------------------------//
            using (Brush br = new SolidBrush( _mainBackColor )) //(SystemColors.Control); UPDATED
            {
                g.FillRectangle( br, tabControlArea );
                br.Dispose();
            }
        }

        private static void DrawControlBorder( Graphics g, ref Rectangle tabArea )
        {
            //-------------------//
            //--- draw border ---//
            //-------------------//
            int nDelta = SystemInformation.Border3DSize.Width;

            using (var border = new Pen( SystemColors.ControlDark ))
            {
                tabArea.Inflate( nDelta, nDelta );
                g.DrawRectangle( border, tabArea );
                border.Dispose();
            }
        }

        internal void DrawTab( Graphics g, TabPage tabPage, int nIndex )
        {
            Rectangle recBounds = GetTabRect( nIndex );
            RectangleF tabTextArea = GetTabRect( nIndex );

            bool hasErrors = CheckForErrors( tabPage.Controls );

            bool isSelected = ( SelectedIndex == nIndex );

            var pt = GetPolyPoints( recBounds );

            //-------------------------------------------//
            //--- fill this tab with background color ---//
            //-------------------------------------------//
            Color tabBackColor = (hasErrors ? GetErrorColor( isSelected ) : 
                                  isSelected ? tabPage.BackColor : UTRSGraphicsUtils.DarkenColor( tabPage.BackColor, 10 )
                                 );
            DrawTabBackground( g, tabBackColor, pt );
            DrawTabBorder( g, tabPage, pt, isSelected, ref recBounds );
            DrawTabIcon( g, tabPage, nIndex, ref recBounds, ref tabTextArea, hasErrors );
            DrawTabText( g, tabPage, ref tabTextArea, hasErrors );
        }

        private Color GetErrorColor( bool isSelected )
        {
            return (isSelected ? _errColor : UTRSGraphicsUtils.DarkenColor(_errColor, 10));
        }

        private static bool CheckForErrors( ICollection controls )
        {
            bool hasError = false;
            foreach (Control control in controls )
            {
                PropertyInfo pi = control.GetType().GetProperty( "HasErrors" );
                if (pi != null )
                {
                    object obj = pi.GetValue( control, null );
                    if( obj is bool )
                        hasError |= (bool)obj;
                }
                hasError |= CheckForErrors( control.Controls );
                if (hasError)
                    break;
            }
            return hasError;
        }

        private Point[] GetPolyPoints( Rectangle recBounds )
        {
            var pt = new Point[7];
            if (Alignment == TabAlignment.Top)
            {
                pt[0] = new Point( recBounds.Left, recBounds.Bottom );
                pt[1] = new Point( recBounds.Left, recBounds.Top + 3 );
                pt[2] = new Point( recBounds.Left + 3, recBounds.Top );
                pt[3] = new Point( recBounds.Right - 3, recBounds.Top );
                pt[4] = new Point( recBounds.Right, recBounds.Top + 3 );
                pt[5] = new Point( recBounds.Right, recBounds.Bottom );
                pt[6] = new Point( recBounds.Left, recBounds.Bottom );
            }
            else
            {
                pt[0] = new Point( recBounds.Left, recBounds.Top );
                pt[1] = new Point( recBounds.Right, recBounds.Top );
                pt[2] = new Point( recBounds.Right, recBounds.Bottom - 3 );
                pt[3] = new Point( recBounds.Right - 3, recBounds.Bottom );
                pt[4] = new Point( recBounds.Left + 3, recBounds.Bottom );
                pt[5] = new Point( recBounds.Left, recBounds.Bottom - 3 );
                pt[6] = new Point( recBounds.Left, recBounds.Top );
            }
            return pt;
        }

        private static void DrawTabBackground( Graphics g, Color tabBackColor, Point[] pt )
        {
            Rectangle rc = new Rectangle(pt[0], new Size(pt[5]));
            GraphicsPath path = new GraphicsPath();
            path.AddLines(pt);
            using (LinearGradientBrush pthGrBrush = new LinearGradientBrush(rc, tabBackColor, UTRSGraphicsUtils.DarkenColor(tabBackColor, 5), LinearGradientMode.Vertical))
            {
                g.FillPath(pthGrBrush, path);
                pthGrBrush.Dispose();
            }
        }

        private void DrawTabBorder( Graphics g, TabPage tabPage, Point[] pt, bool isSelected, ref Rectangle recBounds )
        {
            //-------------------//
            //--- draw border ---//
            //-------------------//
            g.DrawPolygon( SystemPens.ControlDark, pt );

            if (isSelected)
            {
                //----------------------------
                // clear bottom lines
                using (var pen = new Pen( tabPage.BackColor ))
                {
                    switch (Alignment)
                    {
                        case TabAlignment.Top:
                            g.DrawLine( pen, recBounds.Left + 1, recBounds.Bottom, recBounds.Right - 1, recBounds.Bottom );
                            g.DrawLine( pen, recBounds.Left + 1, recBounds.Bottom + 1, recBounds.Right - 1,
                                        recBounds.Bottom + 1 );
                            break;

                        case TabAlignment.Bottom:
                            g.DrawLine( pen, recBounds.Left + 1, recBounds.Top, recBounds.Right - 1, recBounds.Top );
                            g.DrawLine( pen, recBounds.Left + 1, recBounds.Top - 1, recBounds.Right - 1,
                                        recBounds.Top - 1 );
                            g.DrawLine( pen, recBounds.Left + 1, recBounds.Top - 2, recBounds.Right - 1,
                                        recBounds.Top - 2 );
                            break;
                    }

                    pen.Dispose();
                }
                //----------------------------
            }
            //----------------------------
        }

        private void DrawTabText(Graphics g, TabPage tabPage, ref RectangleF tabTextArea, bool hasErrors)
        {
            //----------------------------
            // draw string
           
            var stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            using (Brush br = new SolidBrush(hasErrors ? Color.Black : tabPage.ForeColor))
            {
                g.DrawString( tabPage.Text, Font, br, tabTextArea, stringFormat );
            }
            //----------------------------
        }

        private void DrawTabIcon( Graphics g, TabPage tabPage, int nIndex, ref Rectangle recBounds, ref RectangleF tabTextArea, bool hasErrors )
        {
            //----------------------------
            // draw tab's icon
            if (( ( tabPage.ImageIndex >= 0 ) && ( ImageList != null ) &&
                  (ImageList.Images[tabPage.ImageIndex] != null)) || (hasErrors))
            {
                int nLeftMargin = 2;
                int nRightMargin = 2;
                Image img = ( hasErrors )
                                ? ep.Icon.ToBitmap()
                                : ImageList.Images[tabPage.ImageIndex];
                var rimage = new Rectangle( recBounds.X + nLeftMargin, recBounds.Y + 1, img.Width, img.Height );

                // adjust rectangles
                float nAdj = nLeftMargin + img.Width + nRightMargin;

                rimage.Y += ( recBounds.Height - img.Height )/2;
                tabTextArea.X += nAdj;
                tabTextArea.Width -= nAdj;

                // draw icon
                g.DrawImage( img, rimage );
            }
        }

        internal void DrawIcons( Graphics g )
        {
            if (( leftRightImages == null ) || ( leftRightImages.Images.Count != 4 ))
                return;

            //----------------------------
            // calc positions
            Rectangle tabControlArea = ClientRectangle;

            var r0 = new Rectangle();
            Win32.GetClientRect( _scUpDown.Handle, ref r0 );

            Brush br = new SolidBrush( SystemColors.Control );
            g.FillRectangle( br, r0 );
            br.Dispose();

            var border = new Pen( SystemColors.ControlDark );
            Rectangle rborder = r0;
            rborder.Inflate( -1, -1 );
            g.DrawRectangle( border, rborder );
            border.Dispose();

            int nMiddle = ( r0.Width/2 );
            int nTop = ( r0.Height - 16 )/2;
            int nLeft = ( nMiddle - 16 )/2;

            var r1 = new Rectangle( nLeft, nTop, 16, 16 );
            var r2 = new Rectangle( nMiddle + nLeft, nTop, 16, 16 );
            //----------------------------

            //----------------------------
            // draw buttons
            Image img = leftRightImages.Images[1];
            if (TabCount > 0)
            {
                Rectangle r3 = GetTabRect( 0 );
                if (r3.Left < tabControlArea.Left)
                    g.DrawImage( img, r1 );
                else
                {
                    img = leftRightImages.Images[3];
                    if (img != null)
                        g.DrawImage( img, r1 );
                }
            }

            img = leftRightImages.Images[0];
            if (TabCount > 0)
            {
                Rectangle r3 = GetTabRect( TabCount - 1 );
                if (r3.Right > ( tabControlArea.Width - r0.Width ))
                    g.DrawImage( img, r2 );
                else
                {
                    img = leftRightImages.Images[2];
                    g.DrawImage( img, r2 );
                }
            }
            //----------------------------
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            FindUpDown();
        }

        private void AWBTabControl_ControlAdded( object sender, ControlEventArgs e )
        {
            FindUpDown();
            UpdateUpDown();
        }

        private void AWBTabControl_ControlRemoved( object sender, ControlEventArgs e )
        {
            FindUpDown();
            UpdateUpDown();
        }

        private void AWBTabControl_SelectedIndexChanged( object sender, EventArgs e )
        {
            UpdateUpDown();
            Invalidate(); // we need to update border and background colors
        }

        private void FindUpDown()
        {
            bool bFound = false;

            // find the UpDown control
            IntPtr pWnd = Win32.GetWindow( Handle, Win32.GW_CHILD );

            while (pWnd != IntPtr.Zero)
            {
                //----------------------------
                // Get the window class name
                var className = new char[33];

                int length = Win32.GetClassName( pWnd, className, 32 );

                var s = new string( className, 0, length );
                //----------------------------

                if (s == "msctls_updown32")
                {
                    bFound = true;

                    if (!_upDown)
                    {
                        //----------------------------
                        // Subclass it
                        _scUpDown = new SubClass( pWnd, true );
                        _scUpDown.SubClassedWndProc += scUpDown_SubClassedWndProc;
                        //----------------------------

                        _upDown = true;
                    }
                    break;
                }

                pWnd = Win32.GetWindow( pWnd, Win32.GW_HWNDNEXT );
            }

            if (( !bFound ) && ( _upDown ))
                _upDown = false;
        }

        private void UpdateUpDown()
        {
            if (_upDown)
            {
                if (Win32.IsWindowVisible( _scUpDown.Handle ))
                {
                    var rect = new Rectangle();

                    Win32.GetClientRect( _scUpDown.Handle, ref rect );
                    Win32.InvalidateRect( _scUpDown.Handle, ref rect, true );
                }
            }
        }

        #region scUpDown_SubClassedWndProc Event Handler

        private int scUpDown_SubClassedWndProc( ref Message m )
        {
            switch (m.Msg)
            {
                case Win32.WM_PAINT:
                {
                    //------------------------
                    // redraw
                    IntPtr hDC = Win32.GetWindowDC( _scUpDown.Handle );
                    Graphics g = Graphics.FromHdc( hDC );

                    DrawIcons( g );

                    g.Dispose();
                    Win32.ReleaseDC( _scUpDown.Handle, hDC );
                    //------------------------

                    // return 0 (processed)
                    m.Result = IntPtr.Zero;

                    //------------------------
                    // validate current rect
                    var rect = new Rectangle();

                    Win32.GetClientRect( _scUpDown.Handle, ref rect );
                    Win32.ValidateRect( _scUpDown.Handle, ref rect );
                    //------------------------
                }
                    return 1;
            }

            return 0;
        }

        #endregion

        #region Component Designer generated code

        /// <summary>
        ///     Required method for Designer support - do not modify
        ///     the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            _components = new System.ComponentModel.Container();
        }

        #endregion

        #region Properties

        [Editor( typeof (TabpageExCollectionEditor), typeof (UITypeEditor) )]
        public new TabPageCollection TabPages
        {
            get { return base.TabPages; }
        }

        public new TabAlignment Alignment
        {
            get { return base.Alignment; }
            set
            {
                TabAlignment ta = value;
                if (( ta != TabAlignment.Top ) && ( ta != TabAlignment.Bottom ))
                    ta = TabAlignment.Top;

                base.Alignment = ta;
            }
        }

        [Browsable( false )]
        public new bool Multiline
        {
            get { return base.Multiline; }
            set { base.Multiline = false; }
        }

        [Browsable( true )]
        public Color MainBackColor
        {
            get { return _mainBackColor; }
            set
            {
                _mainBackColor = value;
                Invalidate();
            }
        }

        public Color TabColor
        {
            get { return _tabColor; }
            set { _tabColor = value; }
        }

        #endregion

        #region TabpageExCollectionEditor

        internal class TabpageExCollectionEditor : CollectionEditor
        {
            public TabpageExCollectionEditor( Type type ) : base( type )
            {
            }

            protected override Type CreateCollectionItemType()
            {
                return typeof (TabPage);
            }
        }

        #endregion
    }

    //#endregion
}