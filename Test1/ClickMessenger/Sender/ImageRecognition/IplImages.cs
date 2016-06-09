using OpenCvSharp;

namespace ClickMessenger.Sender.ImageRecognition
{
    static class IplImages
    {
        public static readonly IplImage clickableImage = IplImage.FromFile("img/clickable.bmp", LoadMode.GrayScale);

        public static void Dispose()
        {
            clickableImage?.Dispose();
        }
    }
}
