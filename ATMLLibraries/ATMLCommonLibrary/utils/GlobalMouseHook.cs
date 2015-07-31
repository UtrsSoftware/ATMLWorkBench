/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ATMLCommonLibrary.utils
{
    public class GlobalMouseHook
    {
        public delegate IntPtr LowLevelMouseProc( int nCode, int wParam, IntPtr lParam );

        private const int WH_MOUSE_LL = 14;

        private static GlobalMouseHook _globalMouseHook;
        private static readonly object _lock = new object();

        private readonly LowLevelMouseProc _hookProc;
        private IntPtr _hookID = IntPtr.Zero;

        private GlobalMouseHook()
        {
            _hookProc = HookCallback;
            Hook();
        }

        public static GlobalMouseHook Instance
        {
            get
            {
                if (_globalMouseHook == null)
                {
                    lock (_lock)
                    {
                        if (_globalMouseHook == null)
                        {
                            _globalMouseHook = new GlobalMouseHook();
                        }
                    }
                }
                return _globalMouseHook;
            }
        }

        public event MouseEventHandler LeftButtonDown;
        public event MouseEventHandler RightButtonDown;
        public event MouseEventHandler LeftButtonUp;
        public event MouseEventHandler RightButtonUp;

        public void Hook()
        {
            IntPtr hInstance = LoadLibrary( "User32" );
            _hookID = SetWindowsHookEx( WH_MOUSE_LL, _hookProc, hInstance, 0 );
        }

        public void Unhook()
        {
            UnhookWindowsHookEx( _hookID );
        }

        private IntPtr HookCallback( int nCode, int wParam, IntPtr lParam )
        {
            var button = MouseButtons.None;
            short mouseDelta = 0;
            var hookStruct = (MSLLHOOKSTRUCT) Marshal.PtrToStructure( lParam, typeof (MSLLHOOKSTRUCT) );
            switch (wParam)
            {
                case (int) MouseMessages.WM_LBUTTONDOWN:
                    //case WM_LBUTTONUP: 
                    //case WM_LBUTTONDBLCLK: 
                    button = MouseButtons.Left;
                    break;
                case (int) MouseMessages.WM_RBUTTONDOWN:
                    //case WM_RBUTTONUP: 
                    //case WM_RBUTTONDBLCLK: 
                    button = MouseButtons.Right;
                    break;
                case (int) MouseMessages.WM_MOUSEWHEEL:
                    //If the message is WM_MOUSEWHEEL, the high-order word of mouseData member is the wheel delta. 
                    //One wheel click is defined as WHEEL_DELTA, which is 120. 
                    //(value >> 16) & 0xffff; retrieves the high-order word from the given 32-bit value
                    mouseDelta = (short) ( ( hookStruct.mouseData >> 16 ) & 0xffff );
                    //TODO: X BUTTONS (I havent them so was unable to test)
                    //If the message is WM_XBUTTONDOWN, WM_XBUTTONUP, WM_XBUTTONDBLCLK, WM_NCXBUTTONDOWN, WM_NCXBUTTONUP, 
                    //or WM_NCXBUTTONDBLCLK, the high-order word specifies which X button was pressed or released, 
                    //and the low-order word is reserved. This value can be one or more of the following values. 
                    //Otherwise, mouseData is not used. 
                    break;
            }

            int clickCount = 0;
            if (button != MouseButtons.None)
                if (wParam == (int) MouseMessages.WM_LBUTTONDBLCLK || wParam == (int) MouseMessages.WM_RBUTTONDBLCLK)
                    clickCount = 2;
                else clickCount = 1;

            var mea = new MouseEventArgs( MouseButtons.Left, clickCount, hookStruct.pt.x, hookStruct.pt.y, mouseDelta );

            if (nCode >= 0)
            {
                if (MouseMessages.WM_LBUTTONDOWN == (MouseMessages) wParam && LeftButtonDown != null)
                    LeftButtonDown( this, mea );
                else if (MouseMessages.WM_LBUTTONUP == (MouseMessages) wParam && LeftButtonUp != null)
                    LeftButtonUp( this, mea );
                else if (MouseMessages.WM_RBUTTONDOWN == (MouseMessages) wParam && RightButtonDown != null)
                    RightButtonDown( this, mea );
                else if (MouseMessages.WM_RBUTTONUP == (MouseMessages) wParam && RightButtonUp != null)
                    RightButtonUp( this, mea );
            }
            return CallNextHookEx( _hookID, nCode, wParam, lParam );
        }

        [DllImport( "user32.dll", CharSet = CharSet.Auto, SetLastError = true )]
        private static extern IntPtr SetWindowsHookEx( int idHook,
                                                       LowLevelMouseProc lpfn, IntPtr hMod, uint dwThreadId );

        [DllImport( "user32.dll", CharSet = CharSet.Auto, SetLastError = true )]
        [return: MarshalAs( UnmanagedType.Bool )]
        private static extern bool UnhookWindowsHookEx( IntPtr hhk );

        [DllImport( "user32.dll", CharSet = CharSet.Auto, SetLastError = true )]
        private static extern IntPtr CallNextHookEx( IntPtr hhk, int nCode,
                                                     int wParam, IntPtr lParam );

        [DllImport( "kernel32.dll", CharSet = CharSet.Auto, SetLastError = true )]
        private static extern IntPtr GetModuleHandle( string lpModuleName );

        [DllImport( "kernel32.dll" )]
        private static extern IntPtr LoadLibrary( string lpFileName );

        [StructLayout( LayoutKind.Sequential )]
        private class MouseHookStruct
        {
            /// <summary>
            ///     Specifies a POINT structure that contains the x- and y-coordinates of the cursor, in screen coordinates.
            /// </summary>
            public POINT pt;

            /// <summary>
            ///     Handle to the window that will receive the mouse message corresponding to the mouse event.
            /// </summary>
            public int hwnd;

            /// <summary>
            ///     Specifies the hit-test value. For a list of hit-test values, see the description of the WM_NCHITTEST message.
            /// </summary>
            public int wHitTestCode;

            /// <summary>
            ///     Specifies extra information associated with the message.
            /// </summary>
            public int dwExtraInfo;
        }

        [StructLayout( LayoutKind.Sequential )]
        private class MouseLLHookStruct
        {
            /// <summary>
            ///     Specifies a POINT structure that contains the x- and y-coordinates of the cursor, in screen coordinates.
            /// </summary>
            public POINT pt;

            /// <summary>
            ///     If the message is WM_MOUSEWHEEL, the high-order word of this member is the wheel delta.
            ///     The low-order word is reserved. A positive value indicates that the wheel was rotated forward,
            ///     away from the user; a negative value indicates that the wheel was rotated backward, toward the user.
            ///     One wheel click is defined as WHEEL_DELTA, which is 120.
            ///     If the message is WM_XBUTTONDOWN, WM_XBUTTONUP, WM_XBUTTONDBLCLK, WM_NCXBUTTONDOWN, WM_NCXBUTTONUP,
            ///     or WM_NCXBUTTONDBLCLK, the high-order word specifies which X button was pressed or released,
            ///     and the low-order word is reserved. This value can be one or more of the following values. Otherwise, mouseData is
            ///     not used.
            ///     XBUTTON1
            ///     The first X button was pressed or released.
            ///     XBUTTON2
            ///     The second X button was pressed or released.
            /// </summary>
            public int mouseData;

            /// <summary>
            ///     Specifies the event-injected flag. An application can use the following value to test the mouse flags. Value
            ///     Purpose
            ///     LLMHF_INJECTED Test the event-injected flag.
            ///     0
            ///     Specifies whether the event was injected. The value is 1 if the event was injected; otherwise, it is 0.
            ///     1-15
            ///     Reserved.
            /// </summary>
            public int flags;

            /// <summary>
            ///     Specifies the time stamp for this message.
            /// </summary>
            public int time;

            /// <summary>
            ///     Specifies extra information associated with the message.
            /// </summary>
            public int dwExtraInfo;
        }

        private enum MouseMessages
        {
            WM_LBUTTONDOWN = 0x0201,
            WM_LBUTTONUP = 0x0202,
            WM_MOUSEMOVE = 0x0200,
            WM_MOUSEWHEEL = 0x020A,
            WM_RBUTTONDOWN = 0x0204,
            WM_RBUTTONUP = 0x0205,
            WM_LBUTTONDBLCLK = 0x203,
            WM_RBUTTONDBLCLK = 0x206
        }

        [StructLayout( LayoutKind.Sequential )]
        private struct POINT
        {
            public readonly int x;
            public readonly int y;
        }
    }
}