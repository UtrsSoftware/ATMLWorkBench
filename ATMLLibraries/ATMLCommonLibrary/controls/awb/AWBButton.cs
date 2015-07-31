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
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ATMLCommonLibrary.controls.awb
{

    public partial class AWBButton : Button
    {
        public const string CAT_BUTTON = "AWBButton";

		private enum _States
		{
			Normal,
			MouseOver,
			Clicked
		}

		public enum SmoothingQualities
		{
			None,
			HighSpeed,
			AntiAlias,
			HighQuality
		}

		public enum ButtonStyles
		{
			Rectangle,
			Ellipse
		}

		public enum GradientStyles
		{
			Horizontal,
			Vertical,
			ForwardDiagonal,
			BackwardDiagonal
		}

        String _toolTipText;
        [Browsable(true), Category(CAT_BUTTON), Description("The text to be shown when hovering over the button.")]
        public String ToolTipText
        {
            get { return _toolTipText; }
            set
            {
                _toolTipText = value; 
                createToolTip();
            }
        }


        int _borderWidth = 1;
        [Browsable(true), Category(CAT_BUTTON), Description("The width of the border.") ]
        [DefaultValue(1)]
        public int BorderWidth
        {
            get { return _borderWidth; }
            set { _borderWidth = value; Invalidate(); }
        }

        Color _borderColor = Color.Gray;
        [Browsable(true), Category(CAT_BUTTON), Description("The color of the border.")]
        [DefaultValue("Color.Gray")]
        public Color BorderColor
        {
            get { return _borderColor; }
            set { _borderColor = value; Invalidate(); }
        }

        int _shadowOffSet = 5;
        [Browsable(true), Category(CAT_BUTTON), Description("The the width of the shadow.")]
        [DefaultValue(5)]
        public int ShadowOffSet
        {
            get
            {
                return _shadowOffSet;
            }
            set { _shadowOffSet = Math.Abs(value); Invalidate(); }
        }

        int _roundCornerRadius = 4;
        [Browsable(true), Category(CAT_BUTTON), Description("The radius used for the corners of the button.")]
        [DefaultValue(4)]
        public int RoundCornerRadius
        {
            get { return _roundCornerRadius; }
            set { _roundCornerRadius = Math.Abs(value); Invalidate(); }
        }

		// default values
		private bool _Active = true;
		private _States _State = _States.Normal;

		private GradientStyles _GradientStyle = GradientStyles.Vertical;
		private ButtonStyles _ButtonStyle = ButtonStyles.Rectangle;
		private SmoothingQualities _SmoothingQuality = SmoothingQualities.AntiAlias;

        private Color _NormalBorderColor = Color.SteelBlue;		
		private Color _NormalColorA = Color.LightSteelBlue;
        private Color _NormalColorB = Color.LightSteelBlue;

        private Color _HoverTextColor = Color.White;
        private Color _HoverBorderColor = Color.LightSteelBlue;
		private Color _HoverColorA = Color.SteelBlue;
        private Color _HoverColorB = Color.SteelBlue;

        private ToolTip _toolTip = null;

        public AWBButton()
		{
			// initiate button size and font
			base.Size = new Size(200, 40);
			base.Font = new Font("Verdana", 10, FontStyle.Bold);
			SetStyle(
				ControlStyles.AllPaintingInWmPaint |
				ControlStyles.ResizeRedraw |
				ControlStyles.DoubleBuffer |
				ControlStyles.Selectable | 
				ControlStyles.UserMouse, 
				true
				);
		}

        private void createToolTip()
        {

            if( _toolTipText != null )
            {
                _toolTip = new ToolTip();
                _toolTip.IsBalloon = true;
                _toolTip.ShowAlways = true;
                _toolTip.SetToolTip(this, _toolTipText);
            }
        }

        [Description("Smoothing Quality"), Category(CAT_BUTTON)]
		public SmoothingQualities SmoothingQuality
		{
			get
			{
				return _SmoothingQuality;
			}
			set
			{
				_SmoothingQuality = value;
				this.Invalidate();
			}
		}

        [Description("Gradient Style"), Category(CAT_BUTTON)]
		public GradientStyles GradientStyle
		{
			get
			{
				return _GradientStyle;
			}
			set
			{
				_GradientStyle = value;
				this.Invalidate();
			}

		}

        [Description("Button Style"), Category(CAT_BUTTON)]
		public ButtonStyles ButtonStyle
		{
			get
			{
				return _ButtonStyle;
			}
			set
			{
				_ButtonStyle = value;
				this.Invalidate();
			}
		}

        [Description("The border color of an active button"), Category(CAT_BUTTON)]
		public Color NormalBorderColor
		{
			get
			{
				return _NormalBorderColor;
			}
			set
			{
				_NormalBorderColor = value;
				this.Invalidate();
			}

		}

        [Description("The border color when the mouse is over the button."), Category(CAT_BUTTON)]
		public Color HoverBorderColor
		{
			get
			{
				return _HoverBorderColor;
			}
			set
			{
				_HoverBorderColor = value;
				this.Invalidate();
			}
		}

        [Description("The text color when the mouse is over the button."), Category(CAT_BUTTON)]
        public Color HoverTextColor
        {
            get
            {
                return _HoverTextColor;
            }
            set
            {
                _HoverTextColor = value;
                this.Invalidate();
            }

        }


        [Description("1st gradient color for an active button."), Category(CAT_BUTTON)]
		public Color NormalColorA
		{
			get
			{
				return _NormalColorA;
			}
			set
			{
				_NormalColorA = value;
				this.Invalidate();
			}
		}

        [Description("2nd gradient color for an active button."), Category(CAT_BUTTON)]
		public Color NormalColorB
		{
			get
			{
				return _NormalColorB;
			}
			set
			{
				_NormalColorB = value;
				this.Invalidate();
			}
		}

        [Description("1st gradient color shown when the mouse cursor is over the button."), Category(CAT_BUTTON)]
		public Color HoverColorA
		{
			get
			{
				return _HoverColorA;
			}
			set
			{
				_HoverColorA = value;
				this.Invalidate();
			}
		}

        [Description("2nd gradient color shown when the mouse cursor is over the button."), Category(CAT_BUTTON)]
		public Color HoverColorB
		{
			get
			{
				return _HoverColorB;
			}
			set
			{
				_HoverColorB = value;
				this.Invalidate();
			}
		}

        [Description("Enable the button?"), Category(CAT_BUTTON)]
		public bool Active
		{
			get
			{
				return _Active;
			}
			set
			{
				_Active = value;
				this.Invalidate();
			}
		}
		
		// to make sure the control is invalidated(repainted) when the text is changed
		public override string Text
		{
			get
			{
				return base.Text;
			}
			set
			{
				base.Text = value;
				this.Invalidate();
			}
		}

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            LinearGradientMode mode;
            int tmpShadowOffSet = Math.Min(Math.Min(_shadowOffSet, base.Width - 2), base.Height - 2);
            int tmpSoundCornerRadius = Math.Min(Math.Min(_roundCornerRadius, base.Width - 2), base.Height - 2);
            Rectangle rect = new Rectangle(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width - tmpShadowOffSet - 1, ClientRectangle.Height - tmpShadowOffSet - 1);
            Rectangle rectShadow = new Rectangle(tmpShadowOffSet, tmpShadowOffSet, ClientRectangle.Width - tmpShadowOffSet - 1, ClientRectangle.Height - tmpShadowOffSet - 1);
            GraphicsPath graphPathShadow = AWBGraphicsPath.GetRoundPath(rectShadow, tmpSoundCornerRadius);
            GraphicsPath graphPath = AWBGraphicsPath.GetRoundPath(rect, tmpSoundCornerRadius);


            //
            // set SmoothingMode
            //
            getSmoothingQuality(e);

            //
            // set LinearGradientMode
            //
            mode = getGradientMode();
            if (_Active)
            {
                switch (_State)
                {
                    case _States.Normal:
                        drawNormalStateBacground(e, mode, ref rect, tmpSoundCornerRadius, graphPathShadow, graphPath);
                        break;

                    case _States.MouseOver:
                        drawHoverStateBackground(e, mode, ref rect, tmpSoundCornerRadius, graphPathShadow, graphPath);
                        break;

                    case _States.Clicked:
                        drawClickStateBackground(e, mode, tmpSoundCornerRadius, tmpShadowOffSet );
                        break;
                }
            }
            else
            {
                drawInactiveStateBackground(e, mode, ref rect, tmpSoundCornerRadius, graphPathShadow, graphPath);
            }
        }

		protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
		{
            if( this.Image != null )
            {
                base.OnPaint(e);
                return;
            }

            OnPaintBackground(e);

			LinearGradientMode mode;

			//
			// set SmoothingMode
			//
            getSmoothingQuality(e);

			//
			// set LinearGradientMode
			//
            mode = getGradientMode();

			SizeF textSize = e.Graphics.MeasureString(this.Text, base.Font);
			int textX = (int)(base.Size.Width / 2) - (int)(textSize.Width / 2);
            int textY = (int)(( base.Size.Height/2 - _shadowOffSet/2 ) - (int)(textSize.Height / 2));
				
			if (_Active)
			{
				switch (_State)
				{
					case _States.Normal:
                        drawButtonText(e, base.ForeColor, textX, textY);
						break;

					case _States.MouseOver:
                        drawButtonText(e, _HoverTextColor, textX, textY);
                        break;

					case _States.Clicked:
                        textX += 3;
                        textY += 3;
                        drawButtonText(e, _HoverTextColor, textX, textY);
                        break;
				}
			}
			else
			{
                drawButtonText(e, Color.LightGray, textX, textY);
            }
		}

        private void drawBackground(System.Windows.Forms.PaintEventArgs e, Color borderColor, Color colorA, Color colorB, ref Rectangle rect, GraphicsPath graphPath)
        {
            LinearGradientBrush brush = new LinearGradientBrush( rect, 
                                                                 colorA,
                                                                 colorB,
                                                                 LinearGradientMode.BackwardDiagonal);
            int borderWidth = _borderWidth;
            if (IsDefault)
                borderWidth += 1;
            Pen pen = new Pen(Color.FromArgb(180, borderColor), borderWidth);
            e.Graphics.FillPath(brush, graphPath);
            e.Graphics.DrawPath(pen, graphPath);
            pen.Dispose();
            brush.Dispose();
        }

        private void drawShadow(System.Windows.Forms.PaintEventArgs e, int tmpSoundCornerRadius, GraphicsPath graphPathShadow)
        {
            if (tmpSoundCornerRadius > 0)
            {
                
                using (PathGradientBrush gBrush = new PathGradientBrush(graphPathShadow))
                {
                    gBrush.WrapMode = WrapMode.Clamp;
                    ColorBlend colorBlend = new ColorBlend(3);
                    colorBlend.Colors = new Color[]{Color.Transparent,
                        Color.FromArgb(190, Color.DimGray),
                        Color.FromArgb(190, Color.DimGray)};
                    colorBlend.Positions = new float[] { 0f, .5f, 1f };
                    gBrush.InterpolationColors = colorBlend;
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    e.Graphics.FillPath(gBrush, graphPathShadow);
                }
            }
        }

        private void drawInactiveStateBackground( System.Windows.Forms.PaintEventArgs e, 
                                                  LinearGradientMode mode, 
                                                  ref Rectangle newRect,
                                                  int tmpSoundCornerRadius,
                                                  GraphicsPath graphPathShadow,
                                                  GraphicsPath graphPath)
        {
            drawShadow(e, tmpSoundCornerRadius, graphPathShadow);
            drawBackground(e, Color.DarkGray, Color.Gray, Color.Gray, ref newRect, graphPath);
        }


        private void drawClickStateBackground( System.Windows.Forms.PaintEventArgs e,
                                               LinearGradientMode mode, 
                                               int tmpSoundCornerRadius,
                                               int tmpShadowOffSet
                                               )
        {
            Pen pen = new Pen(BackColor);
            Rectangle newRect = new Rectangle(ClientRectangle.X + tmpShadowOffSet / 2, ClientRectangle.Y + tmpShadowOffSet / 2, ClientRectangle.Width - tmpShadowOffSet, ClientRectangle.Height - tmpShadowOffSet);
            GraphicsPath graphPath = AWBGraphicsPath.GetRoundPath(newRect, tmpSoundCornerRadius);
            e.Graphics.DrawRectangle(pen, newRect);
            drawBackground(e, _HoverBorderColor, _HoverColorA, _HoverColorB, ref newRect, graphPath);
            pen.Dispose();
        }


        private void drawHoverStateBackground(System.Windows.Forms.PaintEventArgs e,
                                                             LinearGradientMode mode, ref Rectangle newRect,
                                                             int tmpSoundCornerRadius,
                                                             GraphicsPath graphPathShadow,
                                                             GraphicsPath graphPath)
        {
            drawShadow(e, tmpSoundCornerRadius, graphPathShadow);
            drawBackground(e, _HoverBorderColor, _HoverColorA, _HoverColorB, ref newRect, graphPath);
        }

        private void drawNormalStateBacground( System.Windows.Forms.PaintEventArgs e, 
                                               LinearGradientMode mode, 
                                               ref Rectangle newRect,
                                               int tmpSoundCornerRadius,
                                               GraphicsPath graphPathShadow, 
                                               GraphicsPath graphPath )
        {
            drawShadow(e, tmpSoundCornerRadius, graphPathShadow);
            drawBackground(e, _NormalBorderColor, _NormalColorA, _NormalColorB, ref newRect, graphPath);
        }

        private void drawButtonText(System.Windows.Forms.PaintEventArgs e,
                                    Color color,
                                    int textX,
                                    int textY )
        {
            SolidBrush brush = new SolidBrush(color);
            e.Graphics.DrawString(this.Text, base.Font, brush, textX, textY);
            brush.Dispose();
        }


        private void getSmoothingQuality(System.Windows.Forms.PaintEventArgs e)
        {
            switch (_SmoothingQuality)
            {
                case SmoothingQualities.None:
                    e.Graphics.SmoothingMode = SmoothingMode.Default;
                    break;
                case SmoothingQualities.HighSpeed:
                    e.Graphics.SmoothingMode = SmoothingMode.HighSpeed;
                    break;
                case SmoothingQualities.AntiAlias:
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    break;
                case SmoothingQualities.HighQuality:
                    e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                    break;
            }
        }

        private LinearGradientMode getGradientMode()
        {
            LinearGradientMode mode;
            switch (_GradientStyle)
            {
                case GradientStyles.Horizontal:
                    mode = LinearGradientMode.Horizontal;
                    break;
                case GradientStyles.Vertical:
                    mode = LinearGradientMode.Vertical;
                    break;
                case GradientStyles.ForwardDiagonal:
                    mode = LinearGradientMode.ForwardDiagonal;
                    break;
                case GradientStyles.BackwardDiagonal:
                    mode = LinearGradientMode.BackwardDiagonal;
                    break;
                default:
                    mode = LinearGradientMode.Vertical;
                    break;
            }
            return mode;
        }

		protected override void OnMouseLeave(System.EventArgs e)
		{
			if (_Active)
			{
				_State = _States.Normal;
				this.Invalidate();
				base.OnMouseLeave(e);
			}
		}

        protected override void OnLeave(System.EventArgs e)
        {
            if (_Active)
            {
                _State = _States.Normal;
                this.Invalidate();
                base.OnLeave(e);
            }
        }

        protected override void OnMouseEnter(System.EventArgs e)
		{
			if (_Active)
			{
				_State = _States.MouseOver;
				this.Invalidate();
				base.OnMouseEnter(e);
                if( _toolTip != null )
                {
                    _toolTip.Active = false;
                    _toolTip.Active = true;
                }
			}
		}

        protected override void OnEnter(System.EventArgs e)
        {
            if (_Active)
            {
                _State = _States.MouseOver;
                this.Invalidate();
                base.OnEnter(e);
            }
        }

		protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
		{
			if (_Active)
			{
				_State = _States.MouseOver;
				this.Invalidate();
				base.OnMouseUp(e);
			}
		}

		protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
		{
			if (_Active)
			{
				_State = _States.Clicked;
				this.Invalidate();
				base.OnMouseDown(e);
			}
		}

		protected override void OnClick(System.EventArgs e)
		{
			// prevent click when button is inactive
			if (_Active)
			{
				base.OnClick(e);
			}
        }
    }

    internal class AWBGraphicsPath
    {
        public static GraphicsPath GetRoundPath(Rectangle r, int depth)
        {
            GraphicsPath graphPath = new GraphicsPath();

            graphPath.AddArc(r.X, r.Y, depth, depth, 180, 90);
            graphPath.AddArc(r.X + r.Width - depth, r.Y, depth, depth, 270, 90);
            graphPath.AddArc(r.X + r.Width - depth, r.Y + r.Height - depth, depth, depth, 0, 90);
            graphPath.AddArc(r.X, r.Y + r.Height - depth, depth, depth, 90, 90);
            graphPath.AddLine(r.X, r.Y + r.Height - depth, r.X, r.Y + depth / 2);

            return graphPath;
        }
    }

}
