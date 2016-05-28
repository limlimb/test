using System;
using System.Drawing;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System.Drawing.Imaging;

namespace ClickMessenger.Sender.ImageRecognition
{
    static class ScreenCapture
    {
        public static IplImage GrayCapture(IntPtr handle)
        {
            var rect = new Native.NativeMethods.RECT();
            Native.NativeMethods.GetClientRect(handle, out rect);

            using (var img = new Bitmap(rect.right, rect.bottom, PixelFormat.Format32bppRgb))
            {
                using (var memg = Graphics.FromImage(img))
                {
                    var dc = memg.GetHdc();
                    Native.NativeMethods.PrintWindow(handle, dc, 0);
                    memg.ReleaseHdc(dc);
                }
                using (var screenImage = BitmapConverter.ToIplImage(img))
                {
                    var screenGrayImage = Cv.CreateImage(new CvSize(img.Width, img.Height), BitDepth.U8, 1);
                    Cv.CvtColor(screenImage, screenGrayImage, ColorConversion.BgrToGray);
                    return screenGrayImage;
                }
            }
        }
    }
}
