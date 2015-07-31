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
using System.Diagnostics;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ATMLCommonLibrary.forms;
using ATMLCommonLibrary.managers;
using ATMLManagerLibrary.managers;

namespace ATMLCommonLibrary.controls
{
    public partial class HelpLabel : Label
    {
        private Font requiredFieldMarkerFont;
        [Bindable(false)]
        [Browsable(true)]
        [Category("ATML"), Description("Set the font for the \"Requred Field\" marker.")]
        public Font RequiredFieldMarkerFont
        {
            get { return requiredFieldMarkerFont; }
            set { requiredFieldMarkerFont = value; }
        }

        private Boolean requiredField;
        [Bindable(false)]
        [Browsable(true)]
        [Category("ATML"), Description("Set to true if the field this label represents is required.")]
        public Boolean RequiredField
        {
            get { return requiredField; }
            set { requiredField = value; }
        }

        private String helpMessageKey;
        [Bindable(false)]
        [Browsable(true)]
        [Category("ATML"), Description("Enter the Help Message Key, usually the entity.field names. This value will be used to perform a lookup into the Message Manager for the proper help text.")]
        public String HelpMessageKey
        {
            get { return helpMessageKey; }
            set { helpMessageKey = value;  }
        }

        public HelpLabel()
        {
            InitializeComponent();
            this.MouseEnter += new EventHandler(HelpCursorOn);
            this.MouseLeave += new EventHandler(HelpCursorOff);
            this.MouseClick += new MouseEventHandler(HelpLabel_MouseClick);
            this.requiredFieldMarkerFont = this.Font;
            this.AutoSize = false;
        }

        void HelpLabel_MouseClick(object sender, MouseEventArgs e)
        {
            Point pt = new Point(Width,0);
            //--- Popup Help Message ---//
            String message = "The Help Key has not been set for this item.";
            if( !String.IsNullOrEmpty( helpMessageKey ) )
                message = MessageManager.getMessage(helpMessageKey);
            string newMessageText = HelpMessageBox.Show( message, 
                                        "Information", 
                                        HelpMessageBox.enumMessageIcon.Information,
                                        HelpMessageBox.enumMessageButton.OK, this.PointToScreen(pt));
            if ( HelpMessageBox.EditMode                   //--- Make sure we are in edit mode          ---//
                && !String.IsNullOrEmpty( helpMessageKey ) //--- Must have a help message key set       ---//
                && !newMessageText.Equals(message))        //--- Make sure the message actually changed ---//
            {                                              //----------------------------------------------//
                MessageManager.saveMessage( helpMessageKey, newMessageText );
            }
        }

        private Form GetParentForm(Control parent)
        {
            Form form = parent as Form;
            if (form == null && parent != null )
                return GetParentForm(parent.Parent);
            return form; 
        }

        public HelpLabel(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            this.MouseEnter += new EventHandler(HelpCursorOn);
            this.MouseLeave += new EventHandler(HelpCursorOff);
            this.MouseClick += new MouseEventHandler(HelpLabel_MouseClick);
            this.AutoSize = false;
        }

        private void HelpCursorOn(object sender, EventArgs e)
        {
            Cursor = Cursors.Help;
        }

        private void HelpCursorOff(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (requiredField)
            {
                string marker = "*";
                SizeF stringSize = new SizeF();
                stringSize = e.Graphics.MeasureString(marker, requiredFieldMarkerFont );
                e.Graphics.DrawString("*", this.requiredFieldMarkerFont, System.Drawing.Brushes.Red, this.Width - stringSize.Width, this.Height / 2 - stringSize.Height/2);
            }
        }

    }
}
