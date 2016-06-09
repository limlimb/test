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
            clickThread = new Thread(() =>
            {
                while (true)
                {
                    sender.Click(900, 320);
                    var interval = 1000 / config.ClickInterval;
                    Thread.Sleep(interval);
                }
            })
            { IsBackground = true };
            capturingThread = new Thread(() =>
            {
                while (true)
                {
                    using (var screen = ScreenCapture.GrayCapture(flashHandle))
                    {
                        var recognizers = new ImageRecognitionBase[]
                        {
                            new Clickable(),
                        };
                        foreach (var recognizer in recognizers)
                        {
                            if (recognizer.Check(screen)) sender.Click(recognizer.X, recognizer.Y);
                        }
                    }
                    Thread.Sleep(15000);
                }
            })
            { IsBackground = true };

            // スレッドの開始
            clickThread.Start();
            capturingThread.Start();
        }

        public void ProgressiveClick()
        {
            // 靴アイコンは1113, 250
            sender.Click(1113, 250);
        }

        public void NextMapClick()
        {
            // 次のマップ: 907, 42
            sender.Click(907, 42);
        }

        public void PreviousMapClick()
        {
            // 前のマップ: 784, 42
            sender.Click(784, 42);
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
