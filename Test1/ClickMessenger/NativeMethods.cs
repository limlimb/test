using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ClickMessenger.Native
{
    static class NativeMethods
    {
        [DllImport("user32.dll")]
        internal static extern int SendMessage(IntPtr hWnd, uint Msg, uint wParam, uint lParam);

        [DllImport("user32.dll")]
        internal static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, IntPtr lpszWindow);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal delegate bool EnumWindowsDelegate(IntPtr windowHandle, IntPtr lParam);

        [DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool EnumChildWindows(
                IntPtr handle,
                [MarshalAs(UnmanagedType.FunctionPtr)] EnumWindowsDelegate lpEnumFunc,
                IntPtr lParam);

        [DllImport("User32.dll")]
        internal static extern bool PrintWindow(IntPtr hwnd, IntPtr hDC, uint nFlags);

        [DllImport("user32.dll")]
        internal static extern bool GetClientRect(IntPtr hwnd, out RECT lpRect);

        [StructLayout(LayoutKind.Sequential)]
        internal struct RECT
        {
            public int left, top, right, bottom;
        }
    }
}
