﻿using System;

using System.Collections.Generic;

using System.Text;

using System.Windows.Forms;

using System.Runtime.InteropServices;

using System.Drawing;

using System.Threading;

namespace GUIControlling

{

    public abstract class Mouse
    {
        [DllImport("user32.dll")]
        static extern ushort GetAsyncKeyState(int vKey);

        [DllImport("user32.dll")]
        static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);
        private const int VK_LBUTTON = 0x01;
        private const int MOUSEEVENTF_MOVE = 0x0001;
        private const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const int MOUSEEVENTF_LEFTUP = 0x0004;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
        private const int MOUSEEVENTF_RIGHTUP = 0x0010;
        private const int MOUSEEVENTF_MIDDLEDOWN = 0x0020;
        private const int MOUSEEVENTF_MIDDLEUP = 0x0040;
        private const int MOUSEEVENTF_ABSOLUTE = 0x8000;

        public static bool Sol_TikaBasildiMi()
        {
            bool basildiMi;
            if (GetAsyncKeyState(VK_LBUTTON) == 0)
                basildiMi = false;
            else if (GetAsyncKeyState(VK_LBUTTON) == 1)
                basildiMi = false;
            else
                basildiMi = true;
            return basildiMi;
        }
        public static void Sol_Tiklama(int x, int y)
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN, x, y, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, x, y, 0, 0);
        }
        public static void Sag_Tiklama(int x, int y)
        {
            mouse_event(MOUSEEVENTF_RIGHTDOWN, x, y, 0, 0);
            mouse_event(MOUSEEVENTF_RIGHTUP, x, y, 0, 0);
        }
        public static void Orta_Tiklama(int x, int y)
        {
            mouse_event(MOUSEEVENTF_MIDDLEDOWN, x, y, 0, 0);
            mouse_event(MOUSEEVENTF_MIDDLEUP, x, y, 0, 0);
        }
    }

}