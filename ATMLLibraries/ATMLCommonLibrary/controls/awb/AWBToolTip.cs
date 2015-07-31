using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ATMLCommonLibrary.controls.awb
{
    public class AWBToolTip : ToolTip
    {
        private int _calculatedHeight;
        public int Width { set; get; }
        public int Height { set; get; }
        public int Padding { set; get; }
        public float GradientAngle { set; get; }
        public Color GradientColor1 { set; get; }
        public Color GradientColor2 { set; get; }
        public Color BorderColor { set; get; }
        public Color TextColor { set; get; }
        public Color TextShadowColor { set; get; }

        /**
         * Not used at this time
         */
        public AWBToolTip()
        {
            OwnerDraw = true;
            Draw += AWBToolTip_Draw;
            Popup += AWBToolTip_Popup;
            Width = 400;
            Height = 200;
            Padding = 3;
            GradientAngle = 45f;
            GradientColor1 = Color.LightYellow;
            GradientColor2 = Color.Khaki;
            BorderColor = Color.Red;
            TextColor = Color.DarkRed;
            TextShadowColor = Color.Black;

            this.ForeColor = Color.DarkRed;
            this.BackColor = Color.LightYellow;

        }


        private void AWBToolTip_Draw( object sender, DrawToolTipEventArgs e )
        {
            Graphics g = e.Graphics;

            using (
                LinearGradientBrush br = new LinearGradientBrush( e.Bounds, GradientColor1, GradientColor2,
                                                                  GradientAngle ))
            {
                
                //-----------------------//
                //--- Fill Background ---//
                //-----------------------//
                g.FillRectangle( br, e.Bounds );
                DrawBorder( g, e );
                //DrawTextShadow(g, e);
                DrawText(g, e);
            }
        }

        private void DrawBorder(Graphics g, DrawToolTipEventArgs e)
        {
            using (Pen pen = new Pen( BorderColor ))
            {
                g.DrawRectangle( pen, e.Bounds.X, e.Bounds.Y, e.Bounds.Width-1, e.Bounds.Height-1 );
            }
        }

        private void DrawText(Graphics g, DrawToolTipEventArgs e)
        {
            using (Brush br = new SolidBrush(TextColor))
            {
                Rectangle rc = new Rectangle();
                rc.X = e.Bounds.X + Padding;
                rc.Y = e.Bounds.Y + Padding;
                rc.Width = e.Bounds.Width;
                rc.Height = e.Bounds.Height;
                TextFormatFlags flags = TextFormatFlags.WordBreak;
                Font f = new Font( e.Font, FontStyle.Bold );
                TextRenderer.DrawText( g, e.ToolTipText, f, rc, TextColor, flags );
            }
        }

        private void DrawTextShadow(Graphics g, DrawToolTipEventArgs e)
        {
            Rectangle rc = new Rectangle();
            rc.X = e.Bounds.X + Padding+1;
            rc.Y = e.Bounds.Y + Padding + 1;
            rc.Width = e.Bounds.Width;
            rc.Height = e.Bounds.Height;
            TextFormatFlags flags = TextFormatFlags.WordBreak;
            Font f = new Font(e.AssociatedControl.Font, FontStyle.Bold);
            TextRenderer.DrawText(g, e.ToolTipText, f, rc, TextShadowColor, flags);
        }

        private void AWBToolTip_Popup( object sender, PopupEventArgs e )
        {
            string text = this.GetToolTip( e.AssociatedControl );
            string[] parts = text.Split( ' ' );
            int maxWidth = 400;
            SizeF sf;
            using (Font f = new Font( e.AssociatedControl.Font, FontStyle.Bold ))
            {
                using (Graphics g = e.AssociatedControl.CreateGraphics())
                {
                    int lineLength = (int)Math.Ceiling( g.MeasureString(text, f).Width) + 50;
                    foreach (string part in parts)
                    {
                        sf = g.MeasureString( part, f );
                        maxWidth = Math.Max( (int) Math.Ceiling( sf.Width ), maxWidth );
                    }
                    maxWidth = Math.Min( lineLength, maxWidth );
                    sf = g.MeasureString( text, f, maxWidth );
                    _calculatedHeight = (int) Math.Ceiling( sf.Height );
                    e.ToolTipSize = new Size(maxWidth + 2 * Padding, _calculatedHeight + 2 * Padding);
                }
            }
        }
    }
}