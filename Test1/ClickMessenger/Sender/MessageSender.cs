using System;
using ClickMessenger.Native;

namespace ClickMessenger.Sender
{
    class MessageSender
    {
        const int MK_LBUTTON = 0x0001;
        const int WM_LBUTTONDOWN = 0x0201;
        const int WM_LBUTTONUP = 0x0202;

        IntPtr windowHandle;

        public MessageSender(IntPtr windowHandle)
        {
            this.windowHandle = windowHandle;
        }

        public void Click(uint xPos, uint yPos)
        {
            var lParam = (xPos & 0xFFFF) | (yPos << 16);
            NativeMethods.SendMessage(windowHandle, WM_LBUTTONDOWN, MK_LBUTTON, lParam);
            NativeMethods.SendMessage(windowHandle, WM_LBUTTONUP, 0x00000000, lParam);
        }
    }
}
