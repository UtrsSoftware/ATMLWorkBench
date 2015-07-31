/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ATMLCommonLibrary.controls.awb
{
    public partial class ScrollBox : UserControl
    {

        private int _buttonPadding = 2;

        private int _currentIndex = -1;
        private int _index = -1;
        private List<string> _values = new List<string>();

        [DllImport("user32.dll")]
        static extern bool HideCaret(IntPtr hWnd);

        public ScrollBox()
        {
            InitializeComponent();
            edtValue.ReadOnly = true;
            edtValue.BackColor = Color.White;
            HideCaret(edtValue.Handle);
            edtValue.GotFocus += new EventHandler(edtValue_GotFocus);
            edtValue.LostFocus += new EventHandler(edtValue_LostFocus);
        }

        void edtValue_LostFocus(object sender, EventArgs e)
        {
            edtValue.BackColor = edtValue.Focused ? Color.Yellow : Color.White;
            BackColor = edtValue.Focused ? Color.Yellow : Color.White;
        }

        void edtValue_GotFocus(object sender, EventArgs e)
        {
            edtValue.BackColor = edtValue.Focused ? Color.Yellow : Color.White;
            BackColor = edtValue.Focused ? Color.Yellow : Color.White;
        }

        public List<string> Values
        {
            get { return _values; }
            set { _values = value; }
        }

        public int Index
        {
            get { return _index; }
            set { _index = value; }
        }

        public int CurrentIndex
        {
            get { return _currentIndex; }
            set { _currentIndex = value; }
        }

        public int ButtonPadding
        {
            get { return _buttonPadding; }
            set { _buttonPadding = value; }
        }

        public int AddValue(string value)
        {
            _values.Add(value);
            return _values.Count - 1;
        }

        private void btnDrop_Paint(object sender, PaintEventArgs e)
        {
            int width = btnDrop.Width;
            int height = btnDrop.Height;
            int center = width/2;
            //e.Graphics.FillRectangle(Brushes.White, 0, 0, width, height);
            //var pt1 = new Point(width/2, 0);
            //var pt2 = new Point(width/2, height);
            //e.Graphics.DrawLine(Pens.Black, width/2, 3, width/2, height - 3);


            if (_currentIndex > 0)
            {
                //--------------------------//
                //--- Draw Upper Trangle ---//
                //--------------------------//
                e.Graphics.DrawLine(Pens.Gray, center - 3, _buttonPadding + 3, center + 3, _buttonPadding + 3);
                e.Graphics.DrawLine(Pens.Gray, center - 2, _buttonPadding + 2, center + 2, _buttonPadding + 2);
                e.Graphics.DrawLine(Pens.Gray, center - 1, _buttonPadding + 1, center + 1, _buttonPadding + 1);
                e.Graphics.DrawLine(Pens.Gray, center - 0, _buttonPadding + 0, center + 0, _buttonPadding + 3);
            }

            if (_currentIndex < (_values.Count - 1))
            {
                //--------------------------//
                //--- Draw Lower Trangle ---//
                //--------------------------//
                e.Graphics.DrawLine(Pens.Gray, center - 3, ( height - _buttonPadding ) - 5, center + 3, ( height - _buttonPadding ) - 5 );
                e.Graphics.DrawLine(Pens.Gray, center - 2, ( height - _buttonPadding ) - 4, center + 2, ( height - _buttonPadding ) - 4 );
                e.Graphics.DrawLine(Pens.Gray, center - 1, ( height - _buttonPadding ) - 3, center + 1, ( height - _buttonPadding ) - 3 );
                e.Graphics.DrawLine(Pens.Gray, center - 0, ( height - _buttonPadding ) - 2, center + 0, ( height - _buttonPadding ) - 5 );
            }

            HideCaret(edtValue.Handle);

        }

        private void edtValue_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void ProcessKey(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                if (e.KeyCode == Keys.Up)
                {
                    _currentIndex--;
                }
                else if (e.KeyCode == Keys.Down)
                {
                    _currentIndex++;
                }
                _currentIndex = _currentIndex < 0 ? 0 : _currentIndex;
                _currentIndex = _currentIndex >= _values.Count ? _values.Count - 1 : _currentIndex;
                edtValue.Text = _values[_currentIndex];
            }
            else if (e.KeyCode == Keys.Delete)
            {
                _currentIndex = -1;
                edtValue.Text = "";
            }

            btnDrop.Invalidate();
            Update();
        }

        private void edtValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            string key = e.KeyChar.ToString();
                //Console.Out.WriteLine(key);
            foreach (string value in _values)
            {
                if (value.StartsWith(key) )
                {
                    _currentIndex = _values.IndexOf(value);
                    edtValue.Text = _values[_currentIndex];
                    break;
                }
            }
        }

        private void edtValue_KeyDown(object sender, KeyEventArgs e)
        {
            ProcessKey(e);
        }

        private void ScrollBox_Paint(object sender, PaintEventArgs e)
        {
            if (Focused || edtValue.Focused || btnDrop.Focused )
            {
                e.Graphics.DrawRectangle(Pens.Red, Bounds);
            }

        }

        private void btnDrop_KeyDown(object sender, KeyEventArgs e)
        {
            ProcessKey(e);
        }

        private void btnDrop_MouseClick(object sender, MouseEventArgs e)
        {
            edtValue.Focus();
            if (e.Y < btnDrop.Height/2)
            {
                SendKeys.Send("{UP}");
            }
            else
            {
                SendKeys.Send("{DOWN}");
            }
        }
    }
}