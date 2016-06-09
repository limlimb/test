using System;
using ClickMessenger.Native;

namespace ClickMessenger.Sender
{
    class MessageSender
    {
        const int MK_LBUTTON = 0x0001;
        const int WM_LBUTTONDOWN = 0x0201;
        const int WM_LBUTTONUP = 0x0202;
        const int WM_KEYDOWN = 0x0100;

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

        public void Key(KeyCode key)
        {
            var wParam = (uint)key;
            NativeMethods.SendMessage(windowHandle, WM_KEYDOWN, wParam, (uint)IntPtr.Zero);
        }
    }

    enum KeyCode : uint
    {
        VK_KEY_1 = 0x31,
        VK_KEY_2,
        VK_KEY_3,
        VK_KEY_4,
        VK_KEY_5,
        VK_KEY_6,
        VK_KEY_7,
        VK_KEY_8,
        VK_KEY_9,
    }
}
