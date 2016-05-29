using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ClickMessenger.Sender.ImageRecognition;

namespace ClickMessenger.Sender
{
    class MessageClient : IDisposable
    {
        MessageSender sender;
        Thread clickThread;
        Thread capturingThread;

        public MessageClient(IntPtr flashHandle, Config config)
        {
            sender = new MessageSender(flashHandle);

            // スレッドの初期化
            clickThread = new Thread(new ThreadStart(() =>
            {
                while (true)
                {
                    sender.Click(900, 320);
                    var interval = 1000 / config.ClickInterval;
                    Thread.Sleep(interval);
                }
            }))
            { IsBackground = true };
            capturingThread = new Thread(new ThreadStart(() =>
            {
                var recognizers = new ImageRecognitionBase[]
                {
                    new Clickable(),
                };
                while (true)
                {
                    using (var screen = ScreenCapture.GrayCapture(flashHandle))
                    {
                        foreach(var recognizer in recognizers)
                        {
                            if (recognizer.Check(screen)) sender.Click(recognizer.X, recognizer.Y);
                        }
                    }
                    Thread.Sleep(15000);
                }
            }))
            { IsBackground = true };

            // スレッドの開始
            clickThread.Start();
            capturingThread.Start();
        }

        #region IDisposableメンバ

        public void Dispose()
        {
            try { clickThread.Abort(); } catch { }
            try { capturingThread.Abort(); } catch { }
        }

        #endregion
    }
}
