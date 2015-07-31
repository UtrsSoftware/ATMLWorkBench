/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ATMLCommonLibrary.forms
{
    public partial class HelpMessageBox : Form//ATMLForm
    {
        public enum enumMessageButton
        {
            OK,
            YesNo,
            YesNoCancel,
            OKCancel
        }

        public enum enumMessageIcon
        {
            Error,
            Warning,
            Information,
            Question,
        }

        private static bool _editMode = true;
        private Point _startingLocation;

        public HelpMessageBox()
        {
            InitializeComponent();
            btnCancel.Visible = false;
            btnOk.Visible = false;
            edtMessageText.ReadOnly = !_editMode;
            Load += new System.EventHandler(HelpMessageBox_Load);
        }

        void HelpMessageBox_Load(object sender, System.EventArgs e)
        {

            GraphicsPath path = GetRoundedRect( this.DisplayRectangle, 20f );
            Region = new Region(path);
            Location = _startingLocation;
            if ((Location.Y + this.Height) > Convert.ToInt32(System.Windows.SystemParameters.PrimaryScreenHeight))
            {
                Location = new Point(Location.X, Location.Y - ((Location.Y + this.Height) - Convert.ToInt32(System.Windows.SystemParameters.PrimaryScreenHeight) ) );
            }

        }

        private const int CS_DROPSHADOW = 0x00020000;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        #region Get the desired Rounded Rectangle path.
        private GraphicsPath GetRoundedRect(RectangleF baseRect,
           float radius)
        {
            // if corner radius is less than or equal to zero, 
            // return the original rectangle 
            if (radius <= 0.0F)
            {
                GraphicsPath mPath = new GraphicsPath();
                mPath.AddRectangle(baseRect);
                mPath.CloseFigure();
                return mPath;
            }

            // if the corner radius is greater than or equal to 
            // half the width, or height (whichever is shorter) 
            // then return a capsule instead of a lozenge 
            if (radius >= (Math.Min(baseRect.Width, baseRect.Height)) / 2.0)
                return GetCapsule(baseRect);

            // create the arc for the rectangle sides and declare 
            // a graphics path object for the drawing 
            float diameter = radius * 2.0F;
            SizeF sizeF = new SizeF(diameter, diameter);
            RectangleF arc = new RectangleF(baseRect.Location, sizeF);
            GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();

            // top left arc 
            path.AddArc(arc, 180, 90);

            // top right arc 
            arc.X = baseRect.Right - diameter;
            path.AddArc(arc, 270, 90);

            // bottom right arc 
            arc.Y = baseRect.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            // bottom left arc
            arc.X = baseRect.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }
        #endregion 

        #region Gets the desired Capsular path.
        private GraphicsPath GetCapsule(RectangleF baseRect)
        {
            float diameter;
            RectangleF arc;
            GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            try
            {
                if (baseRect.Width > baseRect.Height)
                {
                    // return horizontal capsule 
                    diameter = baseRect.Height;
                    SizeF sizeF = new SizeF(diameter, diameter);
                    arc = new RectangleF(baseRect.Location, sizeF);
                    path.AddArc(arc, 90, 180);
                    arc.X = baseRect.Right - diameter;
                    path.AddArc(arc, 270, 180);
                }
                else if (baseRect.Width < baseRect.Height)
                {
                    // return vertical capsule 
                    diameter = baseRect.Width;
                    SizeF sizeF = new SizeF(diameter, diameter);
                    arc = new RectangleF(baseRect.Location, sizeF);
                    path.AddArc(arc, 180, 180);
                    arc.Y = baseRect.Bottom - diameter;
                    path.AddArc(arc, 0, 180);
                }
                else
                {
                    // return circle 
                    path.AddEllipse(baseRect);
                }
            }
            catch (Exception ex)
            {
                path.AddEllipse(baseRect);
            }
            finally
            {
                path.CloseFigure();
            }
            return path;
        }
        #endregion 

        public static bool EditMode
        {
            get { return _editMode; }
            set { _editMode = value; }
        }

        private void setMessage(string messageText)
        {
            edtMessageText.Text = messageText;

            Size tS = TextRenderer.MeasureText(edtMessageText.Text, edtMessageText.Font, this.PreferredSize, TextFormatFlags.WordBreak);
            int tbHeight = edtMessageText.ClientSize.Height;
            int sizeNeeded = tS.Height + (2*edtMessageText.Font.Height);
            if (sizeNeeded > tbHeight)
            {
                int halfTheScreen = Convert.ToInt32( System.Windows.SystemParameters.PrimaryScreenHeight*.50 );
                int sizeToGrow = sizeNeeded - tbHeight;
                if ((Height + sizeToGrow) > halfTheScreen)
                {
                    edtMessageText.ScrollBars = ScrollBars.Vertical;
                    this.Height = halfTheScreen;
                }
                else
                {
                    edtMessageText.ScrollBars = ScrollBars.None;
                    this.Height += sizeToGrow;
                }
            }
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x84:
                    base.WndProc(ref m);
                    if ((int)m.Result == 0x1)
                        m.Result = (IntPtr)0x2;
                    return;
            }

            base.WndProc(ref m);
        }

        private void addButton(enumMessageButton MessageButton)
        {
            switch (MessageButton)
            {
                case enumMessageButton.OK:
                {
                    //If type of enumButton is OK then we add OK button only.
                    var btnOk = new Button(); //Create object of Button.
                    btnOk.Text = "OK"; //Here we set text of Button.
                    btnOk.DialogResult = DialogResult.OK; //Set DialogResult 
                    btnOk.SetBounds(pnlShowMessage.ClientSize.Width - 80, 5, 75, 25); // Set bounds of button.
                    pnlShowMessage.Controls.Add(btnOk); //Finally Add button control
                    // on panel.
                }
                    break;
                case enumMessageButton.OKCancel:
                {
                    var btnOk = new Button();
                    btnOk.Text = "OK";
                    btnOk.DialogResult = DialogResult.OK;
                    btnOk.SetBounds((pnlShowMessage.ClientSize.Width - 70), 5, 65, 25);
                    pnlShowMessage.Controls.Add(btnOk);

                    var btnCancel = new Button();
                    btnCancel.Text = "Cancel";
                    btnCancel.DialogResult = DialogResult.Cancel;
                    btnCancel.SetBounds((pnlShowMessage.ClientSize.Width - (btnOk.ClientSize.Width + 5 + 80)), 5, 75, 25);
                    pnlShowMessage.Controls.Add(btnCancel);
                }
                    break;
                case enumMessageButton.YesNo:
                {
                    var btnNo = new Button();
                    btnNo.Text = "No";
                    btnNo.DialogResult = DialogResult.No;
                    btnNo.SetBounds((pnlShowMessage.ClientSize.Width - 70), 5, 65, 25);
                    pnlShowMessage.Controls.Add(btnNo);

                    var btnYes = new Button();
                    btnYes.Text = "Yes";
                    btnYes.DialogResult = DialogResult.Yes;
                    btnYes.SetBounds((pnlShowMessage.ClientSize.Width - (btnNo.ClientSize.Width + 5 + 80)), 5, 75, 25);
                    pnlShowMessage.Controls.Add(btnYes);
                }
                    break;
                case enumMessageButton.YesNoCancel:
                {
                    var btnCancel = new Button();
                    btnCancel.Text = "Cancel";
                    btnCancel.DialogResult = DialogResult.Cancel;
                    btnCancel.SetBounds((pnlShowMessage.ClientSize.Width - 70), 5, 65, 25);
                    pnlShowMessage.Controls.Add(btnCancel);

                    var btnNo = new Button();
                    btnNo.Text = "No";
                    btnNo.DialogResult = DialogResult.No;
                    btnNo.SetBounds((pnlShowMessage.ClientSize.Width - (btnCancel.ClientSize.Width + 5 + 80)), 5, 75, 25);
                    pnlShowMessage.Controls.Add(btnNo);

                    var btnYes = new Button();
                    btnYes.Text = "Yes";
                    btnYes.DialogResult = DialogResult.No;
                    btnYes.SetBounds(
                        (pnlShowMessage.ClientSize.Width -
                         (btnCancel.ClientSize.Width + btnNo.ClientSize.Width + 10 + 80)), 5, 75, 25);
                    pnlShowMessage.Controls.Add(btnYes);
                }
                    break;
            }
        }


        private void addIconImage(enumMessageIcon MessageIcon)
        {
            switch (MessageIcon)
            {
                case enumMessageIcon.Error:
                    pictureBox1.Image = imageList1.Images["Error"];
                    break;
                case enumMessageIcon.Information:
                    pictureBox1.Image = imageList1.Images["Information"];
                    break;
                case enumMessageIcon.Question:
                    pictureBox1.Image = imageList1.Images["Question"];
                    break;
                case enumMessageIcon.Warning:
                    pictureBox1.Image = imageList1.Images["Warning"];
                    break;
            }
        }

        public static string Show(string messageText)
        {
            var helpMessage = new HelpMessageBox();
            helpMessage.setMessage(messageText);
            helpMessage.addIconImage(enumMessageIcon.Information);
            helpMessage.addButton(enumMessageButton.OK);
            helpMessage.ShowDialog();
            return helpMessage.edtMessageText.Text;
        }

        public static string Show(string messageText, string messageTitle)
        {
            var helpMessage = new HelpMessageBox();
            helpMessage.Text = messageTitle;
            helpMessage.setMessage(messageText);
            helpMessage.addIconImage(enumMessageIcon.Information);
            helpMessage.addButton(enumMessageButton.OK);
            helpMessage.ShowDialog();
            return helpMessage.edtMessageText.Text;
        }

        public static string Show(string messageText,
            string messageTitle,
            enumMessageIcon messageIcon,
            enumMessageButton messageButton, Point location )
        {
            var helpMessage = new HelpMessageBox();
            helpMessage.setMessage(messageText);
            helpMessage.Text = messageTitle;
            helpMessage.addIconImage(messageIcon);
            helpMessage.addButton(messageButton);
            helpMessage._startingLocation = location;
            helpMessage.ShowDialog();
            return helpMessage.edtMessageText.Text;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}