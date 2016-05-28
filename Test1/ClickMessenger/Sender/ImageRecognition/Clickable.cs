using OpenCvSharp;

namespace ClickMessenger.Sender.ImageRecognition
{
    // たまに画面に沸いてきてクリックすると金を撒き散らす奴
    class Clickable : ImageRecognitionBase
    {
        public Clickable() { }

        public override bool Check(IplImage screenImage)=> Match(screenImage, IplImages.clickableImage);
    }
}
