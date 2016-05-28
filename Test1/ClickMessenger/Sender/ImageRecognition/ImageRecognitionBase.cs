using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;
using OpenCvSharp;

namespace ClickMessenger.Sender.ImageRecognition
{
    abstract class ImageRecognitionBase
    {
        public uint X { get; private set; }
        public uint Y { get; private set; }
        
        public abstract bool Check(IplImage screenImage);

        protected bool Match(IplImage screenImage, IplImage tmplImage)
        {
            using (var result = new CvMat(screenImage.Height - tmplImage.Height + 1, screenImage.Width - tmplImage.Width + 1, MatrixType.F32C1))
            {
                Cv.MatchTemplate(screenImage, tmplImage, result, MatchTemplateMethod.CCoeffNormed);
                double minVal;
                double maxVal;
                var minPoint = new CvPoint();
                var maxPoint = new CvPoint();
                // Val = 相関係数, max/min = 最大/最小の相関係数または相関係数の座標を格納する
                Cv.MinMaxLoc(result, out minVal, out maxVal, out minPoint, out maxPoint);

                // 0.73, 0.82, 0.93あたりの値は確認
                if (maxVal > 0.7)
                {
                    X = (uint)maxPoint.X;
                    Y = (uint)maxPoint.Y;
                    return true;
                }
                else
                {
                    X = default(uint);
                    Y = default(uint);
                    return false;
                }
            }
        }

        [Conditional("DEBUG")]
        void ShowMarkedImages(IplImage scr, IplImage tmpl, CvPoint maxPoint)
        {
            var marked = scr.Clone();
            var rect = new CvRect(maxPoint, tmpl.Size);
            marked.DrawRect(rect, new CvScalar(0, 0, 255), 2);
            CvWindow.ShowImages(marked);
        }
    }
}
