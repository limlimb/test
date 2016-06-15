using System;
using System.Collections.Generic;
using System.Text;
using ClickMessenger.Native;

namespace ClickMessenger
{
    static class FlashHandle
    {
        static readonly string FlashHandleString = "MacromediaFlashPlayerActiveX";
        static List<IntPtr> handles = new List<IntPtr>();
        
        public static IntPtr Get()
        {
            // IEのウィンドウハンドルの取得
            var ieHandle = NativeMethods.FindWindowEx(IntPtr.Zero, IntPtr.Zero, "IEFrame", IntPtr.Zero);

            // IEの子ウィンドウのハンドルを列挙
            NativeMethods.EnumChildWindows(ieHandle, EnumWindowProc, IntPtr.Zero);

            // FlashPlayerのウィンドウハンドルの取得
            foreach(var handle in handles)
            {
                var sb = new StringBuilder(256);
                NativeMethods.GetClassName(handle, sb, sb.Capacity);
                if (sb.ToString() == FlashHandleString) return handle;
            }
            throw new InvalidOperationException("FlashPlayerのハンドルが見つかりません。");
        }

        static bool EnumWindowProc(IntPtr handle, IntPtr lParam)
        {
            handles.Add(handle);
            return true;
        }
    }
}
